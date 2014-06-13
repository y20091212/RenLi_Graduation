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

public partial class JobMoveInfos_list : System.Web.UI.Page
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

        List<JobMoveInfosInfo> list = new List<JobMoveInfosInfo>();

        foreach (DataRow dataSet in ds.Tables[0].Rows)
        {
            list.Add(DataRowToModel(dataSet));
        }

        foreach (JobMoveInfosInfo info in list)
        { //style='color:green'
            if (info.Allow ==0)
            {
                info.Status = "<spna>未审核</span>";
            }
            else if (info.Allow == 1)
            {
                info.Status = "<spna style='color:green'>审核通过</span>";
            }
            else if (info.Allow == 2)
            {
                info.Status = "<spna style='color:red'>未通过</span>";
            }
        }

        gridView.DataSource = list;
        gridView.DataBind();
    }

    public JobMoveInfosInfo DataRowToModel(DataRow row)
    {
        JobMoveInfosInfo model = new JobMoveInfosInfo();
        if (row != null)
        {
            if (row["ID"] != null && row["ID"].ToString() != "")
            {
                model.ID = int.Parse(row["ID"].ToString());
            }
            if (row["NewJob"] != null && row["NewJob"].ToString() != "")
            {
                model.NewJob = row["NewJob"].ToString();
            }
            if (row["OldJob"] != null && row["OldJob"].ToString() != "")
            {
                model.OldJob = row["OldJob"].ToString();
            }
            if (row["UserId"] != null && row["UserId"].ToString() != "")
            {
                model.UserId = int.Parse(row["UserId"].ToString());
            }
            if (row["Allow"] != null && row["Allow"].ToString() != "")
            {
                model.Allow = int.Parse(row["Allow"].ToString());
            }
            if (row["Remark"] != null)
            {
                model.Remark = row["Remark"].ToString();
            }
            if (row["UserName"] != null)
            {
                model.UserName = row["UserName"].ToString();
            }
            if (row["SubTime"] != null && row["SubTime"].ToString() != "")
            {
                model.SubTime = DateTime.Parse(row["SubTime"].ToString());
            }
        }
        return model;
    }

    public DataSet GetList(string strWhere)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select JobMoveInfos.ID,(select jobname from jobinfos where jobinfos.id = NewJob) as NewJob,(select jobname from jobinfos where jobinfos.id = OldJob) as OldJob,UserId,userinfos.UserName,Allow,Remark,JobMoveInfos.SubTime ");
        strSql.Append(" FROM JobMoveInfos ");
        strSql.Append(" inner join userinfos on userinfos.id = UserId ");
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

    public partial class JobMoveInfosInfo
    {
        public JobMoveInfosInfo()
        {
        }

        #region Model

        private int _id;
        private string _newjob;
        private string _oldjob;
        private int? _userid;
        private int? _allow;
        private string _remark;
        private DateTime? _subtime;

        private string _username;
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }

        private string _status;
        public string Status
        {
            set { _status = value; }
            get { return _status; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int ID
        {
            set { _id = value; }
            get { return _id; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string NewJob
        {
            set { _newjob = value; }
            get { return _newjob; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string OldJob
        {
            set { _oldjob = value; }
            get { return _oldjob; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int? UserId
        {
            set { _userid = value; }
            get { return _userid; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int? Allow
        {
            set { _allow = value; }
            get { return _allow; }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Remark
        {
            set { _remark = value; }
            get { return _remark; }
        }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? SubTime
        {
            set { _subtime = value; }
            get { return _subtime; }
        }

        #endregion Model
    }
}