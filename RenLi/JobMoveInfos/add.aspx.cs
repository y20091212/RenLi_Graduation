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

public partial class JobMoveInfos_add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDDL4();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int NewJob = int.Parse(this.ddlNewJob.SelectedValue);
        int OldJob = int.Parse(this.ddlOldJob.SelectedValue);
        int UserId = int.Parse(Session["userid"].ToString());
        string Remark = this.txtRemark.Text;
        DateTime SubTime = DateTime.Now;

        JobMoveInfosInfo model = new JobMoveInfosInfo();
        model.NewJob = NewJob;
        model.OldJob = OldJob;
        model.UserId = UserId;
        model.Remark = Remark;
        model.SubTime = SubTime;

        Add(model);
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
        ddlNewJob.DataSource = ds;
        ddlNewJob.DataTextField = "JobName";
        ddlNewJob.DataValueField = "ID";
        ddlNewJob.DataBind();

        ddlOldJob.DataSource = ds;
        ddlOldJob.DataTextField = "JobName";
        ddlOldJob.DataValueField = "ID";
        ddlOldJob.DataBind();
    }

    public void Add(JobMoveInfosInfo model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into JobMoveInfos(");
        strSql.Append("NewJob,OldJob,UserId,Allow,Remark,SubTime)");
        strSql.Append(" values (");
        strSql.Append("'"+model.NewJob+"','"+model.OldJob+"','"+model.UserId+"','"+model.Allow+"','"+model.Remark+"','"+model.SubTime+"')");
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

    public partial class JobMoveInfosInfo
    {
        public JobMoveInfosInfo()
        { }
        #region Model
        private int _id;
        private int? _newjob;
        private int? _oldjob;
        private int? _userid;
        private int? _allow;
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
        public int? NewJob
        {
            set { _newjob = value; }
            get { return _newjob; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? OldJob
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