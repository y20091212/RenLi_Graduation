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

public partial class RecruitInfos_auditList : System.Web.UI.Page
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
        strSql.Append("delete from RecruitInfos ");
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

        List<RecruitInfosInfo> list = new List<RecruitInfosInfo>();

        foreach (DataRow dataSet in ds.Tables[0].Rows)
        {
            list.Add(DataRowToModel(dataSet));
        }

        foreach (RecruitInfosInfo info in list)
        { //style='color:green'
            
            if (info.Allow == 1)
            {
                info.Status = "<spna style='color:green'>审核通过</span>";
            }
            else if (info.Allow == 2)
            {
                info.Status = "<spna style='color:red'>未通过</span>";
            }
            else
            {
                info.Status = "<spna>未审核</span>";
            }
        }

        gridView.DataSource = list;
        gridView.DataBind();
    }

    public RecruitInfosInfo DataRowToModel(DataRow row)
    {
        RecruitInfosInfo model = new RecruitInfosInfo();
        if (row != null)
        {
            if (row["ShenQingRen"] != null)
            {
                model.ShenQingRen = row["ShenQingRen"].ToString();
            }
            if (row["UserName"] != null)
            {
                model.UserName = row["UserName"].ToString();
            }
            if (row["JobName"] != null)
            {
                model.JobName = row["JobName"].ToString();
            }
            if (row["DepName"] != null)
            {
                model.DepName = row["DepName"].ToString();
            }

            if (row["ID"] != null && row["ID"].ToString() != "")
            {
                model.ID = int.Parse(row["ID"].ToString());
            }
            if (row["DepartId"] != null && row["DepartId"].ToString() != "")
            {
                model.DepartId = int.Parse(row["DepartId"].ToString());
            }
            if (row["JobId"] != null && row["JobId"].ToString() != "")
            {
                model.JobId = int.Parse(row["JobId"].ToString());
            }
            if (row["UserId"] != null && row["UserId"].ToString() != "")
            {
                model.UserId = int.Parse(row["UserId"].ToString());
            }
            if (row["Allow"] != null && row["Allow"].ToString() != "")
            {
                model.Allow = int.Parse(row["Allow"].ToString());
            }
            if (row["IsHave"] != null && row["IsHave"].ToString() != "")
            {
                model.IsHave = int.Parse(row["IsHave"].ToString());
            }
            if (row["Remark"] != null)
            {
                model.Remark = row["Remark"].ToString();
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
        strSql.Append("select RecruitInfos.ID,RecruitInfos.DepartId,departmentInfos.DepName,JobId,jobinfos.JobName,UserId,userinfos.UserName as ShenQingRen,Allow,IsHave,users.UserName,Remark,RecruitInfos.SubTime ");
        strSql.Append(" FROM RecruitInfos ");
        strSql.Append(" inner join departmentInfos on departmentInfos.Id = DepartId ");
        strSql.Append(" inner join jobinfos on jobinfos.Id = JobId ");
        strSql.Append(" inner join userinfos on userinfos.Id = UserId ");
        strSql.Append(" left join userinfos as users on users.Id = IsHave ");
        strSql.Append(" where Allow is null ");
        
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


    public partial class RecruitInfosInfo
    {
        public RecruitInfosInfo()
        {
        }

        #region Model

        private string _depName;

        public string DepName
        {
            set { _depName = value; }
            get { return _depName; }
        }

        private string _jobname;

        public string JobName
        {
            set { _jobname = value; }
            get { return _jobname; }
        }


        private string _shenqingren;

        public string ShenQingRen
        {
            set { _shenqingren = value; }
            get { return _shenqingren; }
        }

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


        private int _id;
        private int? _departid;
        private int? _jobid;
        private int? _userid;
        private int? _allow;
        private int? _ishave = 0;
        private string _remark;
        private DateTime? _subtime;

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
        public int? DepartId
        {
            set { _departid = value; }
            get { return _departid; }
        }

        /// <summary>
        /// 
        /// </summary>
        public int? JobId
        {
            set { _jobid = value; }
            get { return _jobid; }
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
        public int? IsHave
        {
            set { _ishave = value; }
            get { return _ishave; }
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