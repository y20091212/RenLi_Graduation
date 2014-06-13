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

public partial class VacateInfos_add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int UserId = int.Parse(Session["userid"].ToString());
        int TypeId = int.Parse(ddlTylpe.SelectedValue);
        int Money = 0;
        DateTime sTime = Convert.ToDateTime(txtSTime.Text);
        DateTime eTime = Convert.ToDateTime(txtETime.Text);
        UserInfosInfo info = GetModel(UserId);

        TimeSpan span = eTime - sTime;

        
        if (TypeId == 1) //事假 100
        {
            Money = -Convert.ToInt32(info.Salary) / 30 * span.Days;
        }
        else if (TypeId == 0)//病假 50
        {
            Money = -Convert.ToInt32(info.Salary) / 60 * span.Days;
        }

        string Remark = this.txtRemark.Text;
        DateTime SubTime = DateTime.Now;

        VacateInfosInfo model = new VacateInfosInfo();
        model.UserId = UserId;
        model.TypeId = TypeId;
        model.Money = Money;
        model.Remark = Remark;
        model.SubTime = SubTime;
        model.StartTime = sTime;
        model.EndTime = eTime;
        Add(model);

    }


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

    public void Add(VacateInfosInfo model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into VacateInfos(");
        strSql.Append("UserId,TypeId,Money,Remark,SubTime,StartTime,EndTime)");
        strSql.Append(" values (");
        strSql.Append("'" + model.UserId + "','" + model.TypeId + "','" + model.Money + "','" + model.Remark + "','" + model.SubTime + "','" + model.StartTime + "','" + model.EndTime + "')");
        strSql.Append(";select @@IDENTITY");
        SqlConnection scon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        scon.Open();
        SqlCommand scmd = new SqlCommand(strSql.ToString(), scon);
        scmd.ExecuteScalar();
        scmd.Dispose();
        scon.Close();

        Response.Write("<script language='javascript'>alert('添加成功！');</script>");
        Server.Transfer("list.aspx");
    }


    public void btnCancle_Click(object sender, EventArgs e)
    {
        Response.Redirect("list.aspx");
    }

    public partial class VacateInfosInfo
    {
        public VacateInfosInfo()
        { }
        #region Model
        private int _id;
        private int? _userid;
        private int? _typeid;
        private int? _money;
        private string _remark;
        private DateTime? _starttime;
        private DateTime? _endtime;
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
        public int? UserId
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? TypeId
        {
            set { _typeid = value; }
            get { return _typeid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? Money
        {
            set { _money = value; }
            get { return _money; }
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
        public DateTime? StartTime
        {
            set { _starttime = value; }
            get { return _starttime; }
        }
        /// <summary>
        /// 
        /// </summary>
        public DateTime? EndTime
        {
            set { _endtime = value; }
            get { return _endtime; }
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