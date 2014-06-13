using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.WebControls;

public partial class UserInfos_Add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindDDL1();
            BindDDL2();
            BindDDL3();
            BindDDL4();
            txtEntryTime.Text = DateTime.Now.Date.ToString("yyyy-MM-dd");

            //判断是否是招聘申请入职人员 如果是 更新招聘表 绑定被招聘人员
            if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
            {
                int id = (Convert.ToInt32(Request.Params["id"]));

                //根据招聘编号查询部门与职位

                RecruitInfosInfo model = GetModel(id);

                if (model != null)
                {
                    ddlDepartment.SelectedValue = model.DepartId.ToString();
                    ddlJob.SelectedValue = model.JobId.ToString();
                    ddlDepartment.Enabled = false;
                    ddlJob.Enabled = false;
                }
            }
        }
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


    //绑定学历
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

    //绑定学历
    public void BindDDL2()
    {
        string str = "SELECT [SortName] FROM [EducationalSort]";
        SqlConnection scon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        scon.Open();
        SqlDataAdapter dbAdapter = new SqlDataAdapter(str, scon);
        DataSet ds = new DataSet();
        dbAdapter.Fill(ds);
        scon.Close();
        ddlEducational.DataSource = ds;
        ddlEducational.DataTextField = "SortName";
        ddlEducational.DataValueField = "SortName";
        ddlEducational.DataBind();
        ddlEducational.Items.Insert(0, new ListItem("未知", "0"));
    }

    //绑定政治面貌
    public void BindDDL1()
    {
        string str = "SELECT [PoliticalName] FROM [Pollan]";
        SqlConnection scon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        scon.Open();
        SqlDataAdapter dbAdapter = new SqlDataAdapter(str, scon);
        DataSet ds = new DataSet();
        dbAdapter.Fill(ds);
        scon.Close();
        ddlPolitical.DataSource = ds;
        ddlPolitical.DataTextField = "PoliticalName";
        ddlPolitical.DataValueField = "PoliticalName";
        ddlPolitical.DataBind();
        ddlPolitical.Items.Insert(0, new ListItem("未知", "0"));
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {

        string strErr = "";
        if (this.txtUserName.Text.Trim().Length == 0)
        {
            strErr += "姓名不能为空\\n";
        }
        if (txtSalary.Text.Trim().Length == 0)
        {
            strErr += "请输入正确的基本工资\\n";
        }
        if (txtEntryTime.Text.Trim().Length == 0)
        {
            strErr += "请输入入职时间\\n";
        }
        if (strErr != "")
        {
            Response.Write("<script language='javascript'>alert('" + strErr + "');</script>");
        }
        else
        {
            string UserName = this.txtUserName.Text;
            string Pwd = "123456";
            string Gender = ddlGender.SelectedValue;
            string Mail = this.txtMail.Text;

            DateTime? Birthday = txtBirthday.Text == "" ? (DateTime?)null : DateTime.Parse(this.txtBirthday.Text);
            string Marriage = this.ddlMarriage.SelectedValue;
            string Political = this.ddlPolitical.SelectedValue;
            string Nation = this.txtNation.Text;
            string Province = this.txtProvince.Text;
            string HomeAddress = this.txtHomeAddress.Text;
            string IDNumber = this.txtIDNumber.Text;
            string Tel = this.txtTel.Text;
            string College = this.txtCollege.Text;
            string Speciality = this.txtSpeciality.Text;
            int Salary = int.Parse(this.txtSalary.Text);
            int Department = int.Parse(ddlDepartment.SelectedValue);
            int Job = int.Parse(ddlJob.SelectedValue);
            string Educational = this.ddlEducational.SelectedValue;
            DateTime EntryTime = DateTime.Parse(this.txtEntryTime.Text);

            UserInfosInfo model = new UserInfosInfo();
            model.UserName = UserName;
            model.Pwd = Pwd;
            model.Gender = Gender;
            model.Mail = Mail;
            model.Birthday = Birthday;
            model.Marriage = Marriage;
            model.Political = Political;
            model.Nation = Nation;
            model.Province = Province;
            model.HomeAddress = HomeAddress;
            model.IDNumber = IDNumber;
            model.Tel = Tel;
            model.College = College;
            model.Speciality = Speciality;
            model.Salary = Salary;
            model.Department = Department;
            model.Job = Job;
            model.Educational = Educational;
            model.EntryTime = EntryTime;
            model.SubTime = DateTime.Now;
            model.KultuLevel = "";
            model.FileName = "";
            model.FilePath = "";
            Add(model);
        }
    }

    /// <summary>
    /// 增加一条数据
    /// </summary>
    public void Add(UserInfosInfo model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into UserInfos(");
        strSql.Append("UserName,Pwd,Gender,Mail,Birthday,Marriage,Political,Nation,Province,HomeAddress,IDNumber,Tel,College,Speciality,KultuLevel,Salary,Department,Job,Educational,EntryTime,FileName,FilePath,SubTime)");
        strSql.Append(" values (");
        strSql.Append("'" + model.UserName + "','" + model.Pwd + "','" + model.Gender + "','" + model.Mail + "','" + model.Birthday + "','" + model.Marriage + "','" + model.Political + "','" + model.Nation + "','" + model.Province + "','" + model.HomeAddress + "','" + model.IDNumber + "','" + model.Tel + "','" + model.College + "','" + model.Speciality + "','" + model.KultuLevel + "','" + model.Salary + "','" + model.Department + "','" + model.Job + "','" + model.Educational + "','" + model.EntryTime + "','" + model.FileName + "','" + model.FilePath + "','" + model.SubTime + "')");
        strSql.Append(";select @@IDENTITY");
        SqlConnection scon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        scon.Open();
        SqlCommand scmd = new SqlCommand(strSql.ToString(), scon);
        int userId = Convert.ToInt32(scmd.ExecuteScalar());
        scmd.Dispose();
        scon.Close();

        //判断是否是招聘申请入职人员 如果是 更新招聘表 绑定被招聘人员
        if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
        {
            int id = (Convert.ToInt32(Request.Params["id"]));
            RecruitInfosInfo info = new RecruitInfosInfo();
            info.ID = id;
            info.IsHave = userId;
            info.Allow = 3;
            Update(info);
        }

        Response.Write("<script language='javascript'>alert('添加成功！');</script>");
        Server.Transfer("list.aspx");
    }

    public void Update(RecruitInfosInfo model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update RecruitInfos set ");
        strSql.Append("IsHave='" + model.IsHave + "',");
        strSql.Append("Allow='" + model.Allow + "'");
        strSql.Append(" where ID='" + model.ID + "'");

        SqlConnection scon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        scon.Open();
        SqlCommand scmd = new SqlCommand(strSql.ToString(), scon);
        scmd.ExecuteNonQuery();
        scmd.Dispose();
        scon.Close();
    }

    public partial class UserInfosInfo
    {
        public UserInfosInfo()
        { }
        #region Model
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