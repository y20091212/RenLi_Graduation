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

public partial class ClockingInInfos_list : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txtKeyword.Text = DateTime.Now.Date.ToString();
            BindData();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindData();
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
    }

    #region gridView

    public void BindData()
    {
        DataSet ds = new DataSet();
        StringBuilder strWhere = new StringBuilder();
        if (txtKeyword.Text.Trim() != "")
        {
            strWhere.Append(" DATEDIFF(m,ClockingInInfos.SubTime,'" + txtKeyword.Text + "')=0  ");
        }
        ds = GetList(strWhere.ToString());
        gridView.DataSource = ds;
        gridView.DataBind();
    }

    public DataSet GetList(string strWhere)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select ClockingInInfos.ID,UserId,userinfos.UserName,Money,IsInOut,case isinout when '0' then '下班打卡' when '1' then '上班打卡' end as inout,ClockingInInfos.SubTime,departmentInfos.DepName,jobinfos.JobName ");
        strSql.Append(" FROM ClockingInInfos ");
        strSql.Append(" inner join userinfos on userinfos.id = UserId ");
        strSql.Append(" inner join departmentInfos on departmentInfos.Id = userinfos.Department ");
        strSql.Append(" inner join jobinfos on jobinfos.Id = userinfos.job ");
        if (strWhere.Trim() != "")
        {
            strSql.Append(" where " + strWhere);
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