using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class JobMoveInfos_auditList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindData();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindData();
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string idlist = GetSelIDlist();
        if (idlist.Trim().Length == 0)
            return;
        DeleteList(idlist);
        BindData();
    }
    public bool DeleteList(string IDlist)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("delete from JobMoveInfos ");
        strSql.Append(" where ID in (" + IDlist + ")  ");
        SqlConnection scon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        scon.Open();
        SqlCommand scmd = new SqlCommand(strSql.ToString(), scon);
        int rows = scmd.ExecuteNonQuery();
        scon.Close();

        if (rows > 0)
        {
            BindData();
            return true;
        }
        else
        {
            return false;
        }
    }
    #region gridView

    public void BindData()
    {
        DataSet ds = new DataSet();
        StringBuilder strWhere = new StringBuilder();
        ds = GetList(strWhere.ToString());
        gridView.DataSource = ds;
        gridView.DataBind();
    }

    public DataSet GetList(string strWhere)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select JobMoveInfos.ID,(select jobname from jobinfos where jobinfos.id = NewJob) as NewJob,(select jobname from jobinfos where jobinfos.id = OldJob) as OldJob,UserId,userinfos.UserName,Allow,Remark,JobMoveInfos.SubTime ");
        strSql.Append(" FROM JobMoveInfos ");
        strSql.Append(" inner join userinfos on userinfos.id = UserId ");
        strSql.Append(" where Allow=0 ");
        if (strWhere.Trim() != "")
        {
            strSql.Append(strWhere);
        }
        SqlConnection scon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        scon.Open();
        SqlDataAdapter dbAdapter = new SqlDataAdapter(strSql.ToString(), scon);
        DataSet ds = new DataSet();
        dbAdapter.Fill(ds);
        scon.Close();

        return ds;
    }

    protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridView.PageIndex = e.NewPageIndex;
        BindData();
    }
    protected void gridView_OnRowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
        }
    }
    protected void gridView_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        e.Row.Attributes.Add("style", "background:#FFF");
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            LinkButton linkbtnDel = (LinkButton)e.Row.FindControl("LinkButton1");
        }
    }

    protected void gridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
    }

    private string GetSelIDlist()
    {
        string idlist = "";
        bool BxsChkd = false;
        for (int i = 0; i < gridView.Rows.Count; i++)
        {
            CheckBox ChkBxItem = (CheckBox)gridView.Rows[i].FindControl("DeleteThis");
            if (ChkBxItem != null && ChkBxItem.Checked)
            {
                BxsChkd = true;
                if (gridView.DataKeys[i].Value != null)
                {
                    idlist += gridView.DataKeys[i].Value.ToString() + ",";
                }
            }
        }
        if (BxsChkd)
        {
            idlist = idlist.Substring(0, idlist.LastIndexOf(","));
        }
        return idlist;
    }

    #endregion
}