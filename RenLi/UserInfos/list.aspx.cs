using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.WebControls;

public partial class UserInfos_list : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            btnDelete.Attributes.Add("onclick", "return confirm(\"你确认要删除吗？\")");
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
    /// <summary>
    /// 批量删除数据
    /// </summary>
    public bool DeleteList(string IDlist)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("delete from UserInfos ");
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
        if (txtKeyword.Text.Trim() != "")
        {
            strWhere.Append(" UserName like '%" + txtKeyword.Text + "%' ");
        }
        ds = GetList(strWhere.ToString());
        gridView.DataSource = ds;
        gridView.DataBind();
    }

    /// <summary>
    /// 获得数据列表
    /// </summary>
    public DataSet GetList(string strWhere)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select userinfos.ID,UserName,Pwd,Gender,Mail,Birthday,Marriage,Political,Nation,Province,HomeAddress,IDNumber,Tel,College,Speciality,KultuLevel,Salary,Department,departmentInfos.depName as DepartmentName,Job,jobinfos.JobName,Educational,EntryTime,FileName,FilePath,SubTime ");
        strSql.Append(" from userinfos ");
        strSql.Append(" inner join departmentInfos on departmentInfos.Id = Department ");
        strSql.Append(" inner join jobinfos on jobinfos.Id = job ");
        
        if (strWhere.Trim() != "")
        {
            strSql.Append(" where " + strWhere);
        }
        strSql.Append(" order by SubTime desc ");
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
            linkbtnDel.Attributes.Add("onclick", "return confirm(\"你确认要删除吗\")");
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