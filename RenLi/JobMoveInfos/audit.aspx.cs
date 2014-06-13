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

public partial class JobMoveInfos_audit : System.Web.UI.Page
{
     protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindDDL4();
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
        ddlNewJob.DataSource = ds;
        ddlNewJob.DataTextField = "JobName";
        ddlNewJob.DataValueField = "ID";
        ddlNewJob.DataBind();

        ddlOldJob.DataSource = ds;
        ddlOldJob.DataTextField = "JobName";
        ddlOldJob.DataValueField = "ID";
        ddlOldJob.DataBind();
    }

    private void ShowInfo(int ID)
    {
        JobMoveInfosInfo model = GetModel(ID);
        this.lblID.Text = model.ID.ToString();
        this.ddlNewJob.SelectedValue = model.NewJob.ToString();
        this.ddlOldJob.SelectedValue = model.OldJob.ToString();
        this.txtRemark.Text = model.Remark;
        HiddenField1.Value = model.UserId.ToString();
    }

    public JobMoveInfosInfo GetModel(int ID)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append("select  top 1 ID,NewJob,OldJob,UserId,Allow,Remark,SubTime from JobMoveInfos ");
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
                model.NewJob = int.Parse(row["NewJob"].ToString());
            }
            if (row["OldJob"] != null && row["OldJob"].ToString() != "")
            {
                model.OldJob = int.Parse(row["OldJob"].ToString());
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
        int NewJob = int.Parse(this.ddlNewJob.SelectedValue);
        int OldJob = int.Parse(this.ddlOldJob.SelectedValue);
        string Remark = this.txtRemark.Text;


        JobMoveInfosInfo model = new JobMoveInfosInfo();
        model.ID = ID;
        model.NewJob = NewJob;
        model.OldJob = OldJob;
        model.Remark = Remark;
        if (rbNo.Checked==true)
        {
            model.Allow = 2;
        }
        if (rbYes.Checked == true)
        {
            //通过审核 将被审核人的职位改为申请职位
            UserInfosInfo info = new UserInfosInfo();
            info.ID = int.Parse(HiddenField1.Value);
            info.Job = NewJob;

            UpdateUserInfo(info);

            model.Allow = 1;
        }
        Update(model);
    }

    public void UpdateUserInfo(UserInfosInfo model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update UserInfos set ");
        strSql.Append("Job='" + model.Job + "'");
        strSql.Append(" where ID='" + model.ID + "'");

        SqlConnection scon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        scon.Open();
        SqlCommand scmd = new SqlCommand(strSql.ToString(), scon);
        scmd.ExecuteNonQuery();
        scmd.Dispose();
        scon.Close();
    }

    public void Update(JobMoveInfosInfo model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update JobMoveInfos set ");
        strSql.Append("NewJob='" + model.NewJob + "',");
        strSql.Append("OldJob='" + model.OldJob + "',");
        strSql.Append("Remark='" + model.Remark + "',");
        strSql.Append("Allow='" + model.Allow + "'");
        strSql.Append(" where ID='" + model.ID + "'");

        SqlConnection scon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        scon.Open();
        SqlCommand scmd = new SqlCommand(strSql.ToString(), scon);
        scmd.ExecuteNonQuery();
        scmd.Dispose();
        scon.Close();
        Response.Write("<script language='javascript'>alert('审核成功！');</script>");
        Server.Transfer("auditList.aspx");
    }

    public void btnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("auditList.aspx");
    }

    public partial class JobMoveInfosInfo
    {
        public JobMoveInfosInfo()
        {
        }

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

    public partial class UserInfosInfo
    {
        public UserInfosInfo()
        { }
        #region Model
        private string _departmentName;
        public string DepartmentName
        {
            set { _departmentName = value; }
            get { return _departmentName; }
        }
        private string _jobName;
        public string JobName
        {
            set { _jobName = value; }
            get { return _jobName; }
        }
        private int _id;
        private string _username;
        private string _pwd;
        private string _gender;
        private string _mail;
        private DateTime? _birthday;
        private string _marriage;
        private string _political;
        private string _nation;
        private string _province;
        private string _homeaddress;
        private string _idnumber;
        private string _tel;
        private string _college;
        private string _speciality;
        private string _kultulevel;
        private int? _salary;
        private int? _department;
        private int? _job;
        private string _educational;
        private DateTime? _entrytime;
        private string _filename;
        private string _filepath;
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
        public string UserName
        {
            set { _username = value; }
            get { return _username; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Pwd
        {
            set { _pwd = value; }
            get { return _pwd; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Gender
        {
            set { _gender = value; }
            get { return _gender; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Mail
        {
            set { _mail = value; }
            get { return _mail; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? Birthday
        {
            set { _birthday = value; }
            get { return _birthday; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Marriage
        {
            set { _marriage = value; }
            get { return _marriage; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Political
        {
            set { _political = value; }
            get { return _political; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Nation
        {
            set { _nation = value; }
            get { return _nation; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Province
        {
            set { _province = value; }
            get { return _province; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string HomeAddress
        {
            set { _homeaddress = value; }
            get { return _homeaddress; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string IDNumber
        {
            set { _idnumber = value; }
            get { return _idnumber; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Tel
        {
            set { _tel = value; }
            get { return _tel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string College
        {
            set { _college = value; }
            get { return _college; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Speciality
        {
            set { _speciality = value; }
            get { return _speciality; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string KultuLevel
        {
            set { _kultulevel = value; }
            get { return _kultulevel; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Salary
        {
            set { _salary = value; }
            get { return _salary; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Department
        {
            set { _department = value; }
            get { return _department; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Job
        {
            set { _job = value; }
            get { return _job; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string Educational
        {
            set { _educational = value; }
            get { return _educational; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? EntryTime
        {
            set { _entrytime = value; }
            get { return _entrytime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FileName
        {
            set { _filename = value; }
            get { return _filename; }
        }
        /// <summary>
        /// 
        /// </summary>
        public string FilePath
        {
            set { _filepath = value; }
            get { return _filepath; }
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