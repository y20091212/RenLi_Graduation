using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;

public partial class RecruitInfos_Modify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindDDL4();
            BindDDL3();
            if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
            {
                int ID = (Convert.ToInt32(Request.Params["id"]));
                ShowInfo(ID);
            }
        }
    }

    public void BindDDL4()
    {
        string str = "SELECT [JobName],ID FROM [JobInfos]";
        SqlConnection scon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        scon.Open();
        SqlDataAdapter dbAdapter = new SqlDataAdapter(str, scon);
        DataSet ds = new DataSet();
        dbAdapter.Fill(ds);
        scon.Close();
        ddlJob.DataSource = ds;
        ddlJob.DataTextField = "JobName";
        ddlJob.DataValueField = "ID";
        ddlJob.DataBind();
    }

    //绑定学历
    public void BindDDL3()
    {
        string str = "SELECT [DepName],ID FROM [DepartmentInfos]";
        SqlConnection scon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        scon.Open();
        SqlDataAdapter dbAdapter = new SqlDataAdapter(str, scon);
        DataSet ds = new DataSet();
        dbAdapter.Fill(ds);
        scon.Close();
        ddlDepartment.DataSource = ds;
        ddlDepartment.DataTextField = "DepName";
        ddlDepartment.DataValueField = "ID";
        ddlDepartment.DataBind();
    }

    private void ShowInfo(int ID)
    {
        RecruitInfosInfo model = GetModel(ID);
        this.lblID.Text = model.ID.ToString();
        ddlDepartment.SelectedValue = model.DepartId.ToString();
        ddlJob.SelectedValue = model.JobId.ToString();
        this.txtRemark.Text = model.Remark;
    }

    public RecruitInfosInfo GetModel(int ID)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append("select  top 1 ID,DepartId,JobId,UserId,Allow,IsHave,Remark,SubTime from RecruitInfos ");
        strSql.Append(" where ID=" + ID);
        SqlConnection scon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        scon.Open();
        SqlDataAdapter dbAdapter = new SqlDataAdapter(strSql.ToString(), scon);
        DataSet ds = new DataSet();
        dbAdapter.Fill(ds);
        scon.Close();


        if (ds.Tables[0].Rows.Count > 0)
        {
            return DataRowToModel(ds.Tables[0].Rows[0]);
        }
        else
        {
            return null;
        }
    }


    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public RecruitInfosInfo DataRowToModel(DataRow row)
    {
        RecruitInfosInfo model = new RecruitInfosInfo();
        if (row != null)
        {
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

    public void btnSave_Click(object sender, EventArgs e)
    {
        int ID = int.Parse(this.lblID.Text);
        int DepartId = int.Parse(ddlDepartment.SelectedValue);
        int JobId = int.Parse(ddlJob.SelectedValue);
        string Remark = this.txtRemark.Text;


        RecruitInfosInfo model = new RecruitInfosInfo();
        model.ID = ID;
        model.DepartId = DepartId;
        model.JobId = JobId;
        model.Remark = Remark;

        Update(model);
    }

    public void Update(RecruitInfosInfo model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update RecruitInfos set ");
        strSql.Append("DepartId='" + model.DepartId + "',");
        strSql.Append("JobId='" + model.JobId + "',");
        strSql.Append("Remark='" + model.Remark + "'");
        strSql.Append(" where ID='" + model.ID + "'");

        SqlConnection scon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        scon.Open();
        SqlCommand scmd = new SqlCommand(strSql.ToString(), scon);
        scmd.ExecuteNonQuery();
        scmd.Dispose();
        scon.Close();
        Response.Write("<script language='javascript'>alert('更新成功！');</script>");
        Server.Transfer("list.aspx");

    }

    public void btnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("list.aspx");
    }

    public partial class RecruitInfosInfo
    {
        public RecruitInfosInfo()
        { }
        #region Model
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