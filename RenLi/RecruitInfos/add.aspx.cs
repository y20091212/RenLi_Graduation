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

public partial class RecruitInfos_add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDDL4();
            BindDDL3();
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

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int DepartId = int.Parse(this.ddlDepartment.SelectedValue);
        int JobId = int.Parse(this.ddlJob.SelectedValue);
        string Remark = this.txtRemark.Text;
        DateTime SubTime = DateTime.Now;

        RecruitInfosInfo model = new RecruitInfosInfo();
        model.DepartId = DepartId;
        model.JobId = JobId;
        model.UserId = Convert.ToInt32(Session["userid"]);
        model.Remark = Remark;
        model.SubTime = SubTime;

        Add(model);
    }

    public void Add(RecruitInfosInfo model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into RecruitInfos(");
        strSql.Append("DepartId,JobId,UserId,Remark,SubTime)");
        strSql.Append(" values (");
        strSql.Append("'" + model.DepartId + "','" + model.JobId + "','" + model.UserId + "','" + model.Remark + "','" + model.SubTime + "')");
        strSql.Append(";select @@IDENTITY");

        SqlConnection scon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        scon.Open();
        SqlCommand scmd = new SqlCommand(strSql.ToString(), scon);
        scmd.ExecuteNonQuery();
        scmd.Dispose();
        scon.Close();
        Response.Write("<script language='javascript'>alert('添加成功！');</script>");
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