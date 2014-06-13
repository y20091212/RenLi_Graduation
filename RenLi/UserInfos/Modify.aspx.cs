using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.WebControls;

public partial class UserInfos_Modify : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindDDL1();
            BindDDL2();
            BindDDL3();
            BindDDL4();
            if (Request.Params["id"] != null && Request.Params["id"].Trim() != "")
            {
                int ID = (Convert.ToInt32(Request.Params["id"]));
                ShowInfo(ID);
            }
        }
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

    private void ShowInfo(int ID)
    {
        UserInfosInfo model = GetModel(ID);
        this.lblID.Text = model.ID.ToString();
        this.txtUserName.Text = model.UserName;
        this.txtPwd.Text = model.Pwd;
        this.ddlGender.SelectedValue = model.Gender;
        this.txtMail.Text = model.Mail;
        this.txtBirthday.Text = model.Birthday.ToString();
        this.DropDownList1.SelectedValue = model.Marriage;
        this.ddlPolitical.SelectedValue = model.Political;
        this.txtNation.Text = model.Nation;
        this.txtProvince.Text = model.Province;
        this.txtHomeAddress.Text = model.HomeAddress;
        this.txtIDNumber.Text = model.IDNumber;
        this.txtTel.Text = model.Tel;
        this.txtCollege.Text = model.College;
        this.txtSpeciality.Text = model.Speciality;
        this.txtSalary.Text = model.Salary.ToString();
        this.ddlDepartment.SelectedValue = model.Department.ToString();
        this.ddlJob.SelectedValue = model.Job.ToString();
        this.ddlEducational.SelectedValue = model.Educational;
        this.txtEntryTime.Text = model.EntryTime.ToString();

    }

    public void btnSave_Click(object sender, EventArgs e)
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

            int ID = int.Parse(this.lblID.Text);
            string UserName = this.txtUserName.Text;
            string Pwd = this.txtPwd.Text;
            string Gender = this.ddlGender.SelectedValue;
            string Mail = this.txtMail.Text;
            DateTime? Birthday = txtBirthday.Text == "" ? (DateTime?)null : DateTime.Parse(this.txtBirthday.Text);
            string Marriage = this.DropDownList1.SelectedValue;
            string Political = this.ddlPolitical.SelectedValue;
            string Nation = this.txtNation.Text;
            string Province = this.txtProvince.Text;
            string HomeAddress = this.txtHomeAddress.Text;
            string IDNumber = this.txtIDNumber.Text;
            string Tel = this.txtTel.Text;
            string College = this.txtCollege.Text;
            string Speciality = this.txtSpeciality.Text;
            int Salary = int.Parse(this.txtSalary.Text);
            int Department = int.Parse(this.ddlDepartment.SelectedValue);
            int Job = int.Parse(this.ddlJob.SelectedValue);
            string Educational = this.ddlEducational.SelectedValue;
            DateTime EntryTime = DateTime.Parse(this.txtEntryTime.Text);


            UserInfosInfo model = new UserInfosInfo();
            model.ID = ID;
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
            model.KultuLevel = "";
            model.Salary = Salary;
            model.Department = Department;
            model.Job = Job;
            model.Educational = Educational;
            model.EntryTime = EntryTime;

            //Maticsoft.BLL.UserInfosBll bll = new Maticsoft.BLL.UserInfosBll();
            Update(model);
            //Maticsoft.Common.MessageBox.ShowAndRedirect(this, "保存成功！", "list.aspx");
        }
    }

    public void Update(UserInfosInfo model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update UserInfos set ");
        strSql.Append("UserName='"+model.UserName+"',");
        strSql.Append("Pwd='"+model.Pwd+"',");
        strSql.Append("Gender='"+model.Gender+"',");
        strSql.Append("Mail='"+model.Mail+"',");
        strSql.Append("Birthday='"+model.Birthday+"',");
        strSql.Append("Marriage='"+model.Marriage+"',");
        strSql.Append("Political='"+model.Political+"',");
        strSql.Append("Nation='"+model.Nation+"',");
        strSql.Append("Province='"+model.Province+"',");
        strSql.Append("HomeAddress='"+model.HomeAddress+"',");
        strSql.Append("IDNumber='"+model.IDNumber+"',");
        strSql.Append("Tel='"+model.Tel+"',");
        strSql.Append("College='"+model.College+"',");
        strSql.Append("Speciality='"+model.Speciality+"',");
        strSql.Append("KultuLevel='"+model.KultuLevel+"',");
        strSql.Append("Salary='"+model.Salary+"',");
        strSql.Append("Department='"+model.Department+"',");
        strSql.Append("Job='"+model.Job+"',");
        strSql.Append("Educational='"+model.Educational+"',");
        strSql.Append("EntryTime='"+model.EntryTime+"'");
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

    /// <summary>
    /// 得到一个对象实体
    /// </summary>
    public UserInfosInfo GetModel(int ID)
    {

        StringBuilder strSql = new StringBuilder();
        strSql.Append("select  top 1 UserInfos.ID,UserName,Pwd,Gender,Mail,Birthday,Marriage,Political,Nation,Province,HomeAddress,IDNumber,Tel,College,Speciality,KultuLevel,Salary,Department,departmentInfos.depName as DepartmentName,Job,jobinfos.JobName,Educational,EntryTime,FileName,FilePath,SubTime from UserInfos ");
        strSql.Append(" inner join departmentInfos on departmentInfos.Id = Department ");
        strSql.Append(" inner join jobinfos on jobinfos.Id = job ");
        strSql.Append(" where UserInfos.ID=" + ID);
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
    public UserInfosInfo DataRowToModel(DataRow row)
    {
        UserInfosInfo model = new UserInfosInfo();
        if (row != null)
        {
            if (row["DepartmentName"] != null)
            {
                model.DepartmentName = row["DepartmentName"].ToString();
            }
            if (row["JobName"] != null)
            {
                model.JobName = row["JobName"].ToString();
            }

            if (row["ID"] != null && row["ID"].ToString() != "")
            {
                model.ID = int.Parse(row["ID"].ToString());
            }
            if (row["UserName"] != null)
            {
                model.UserName = row["UserName"].ToString();
            }
            if (row["Pwd"] != null)
            {
                model.Pwd = row["Pwd"].ToString();
            }
            if (row["Gender"] != null)
            {
                model.Gender = row["Gender"].ToString();
            }
            if (row["Mail"] != null)
            {
                model.Mail = row["Mail"].ToString();
            }
            if (row["Birthday"] != null && row["Birthday"].ToString() != "")
            {
                model.Birthday = DateTime.Parse(row["Birthday"].ToString());
            }
            if (row["Marriage"] != null)
            {
                model.Marriage = row["Marriage"].ToString();
            }
            if (row["Political"] != null)
            {
                model.Political = row["Political"].ToString();
            }
            if (row["Nation"] != null)
            {
                model.Nation = row["Nation"].ToString();
            }
            if (row["Province"] != null)
            {
                model.Province = row["Province"].ToString();
            }
            if (row["HomeAddress"] != null)
            {
                model.HomeAddress = row["HomeAddress"].ToString();
            }
            if (row["IDNumber"] != null)
            {
                model.IDNumber = row["IDNumber"].ToString();
            }
            if (row["Tel"] != null)
            {
                model.Tel = row["Tel"].ToString();
            }
            if (row["College"] != null)
            {
                model.College = row["College"].ToString();
            }
            if (row["Speciality"] != null)
            {
                model.Speciality = row["Speciality"].ToString();
            }
            if (row["KultuLevel"] != null)
            {
                model.KultuLevel = row["KultuLevel"].ToString();
            }
            if (row["Salary"] != null && row["Salary"].ToString() != "")
            {
                model.Salary = int.Parse(row["Salary"].ToString());
            }
            if (row["Department"] != null && row["Department"].ToString() != "")
            {
                model.Department = int.Parse(row["Department"].ToString());
            }
            if (row["Job"] != null && row["Job"].ToString() != "")
            {
                model.Job = int.Parse(row["Job"].ToString());
            }
            if (row["Educational"] != null)
            {
                model.Educational = row["Educational"].ToString();
            }
            if (row["EntryTime"] != null && row["EntryTime"].ToString() != "")
            {
                model.EntryTime = DateTime.Parse(row["EntryTime"].ToString());
            }
            if (row["FileName"] != null)
            {
                model.FileName = row["FileName"].ToString();
            }
            if (row["FilePath"] != null)
            {
                model.FilePath = row["FilePath"].ToString();
            }
            if (row["SubTime"] != null && row["SubTime"].ToString() != "")
            {
                model.SubTime = DateTime.Parse(row["SubTime"].ToString());
            }
        }
        return model;
    }

    public void btnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("list.aspx");
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