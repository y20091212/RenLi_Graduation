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

public partial class Salary_list : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtTime.Text = DateTime.Now.ToString("yyyy-MM");
            BindData();
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

    protected void gridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridView.PageIndex = e.NewPageIndex;
        BindData();
    }

    public void BindData()
    {
        DataSet ds = new DataSet();
        StringBuilder strWhere = new StringBuilder();
        
        ds = GetList(strWhere.ToString());

        List<UserInfosInfo> list = new List<UserInfosInfo>();

        foreach (DataRow dataSet in ds.Tables[0].Rows)
        {
            list.Add(DataRowToModel(dataSet));
        }

        DateTime dateTime = Convert.ToDateTime(txtTime.Text);

        foreach (UserInfosInfo info in list)
        {
            //获取奖金列表
            int jiangcheng = GetList_JiangCheng(info.ID, dateTime);
            info.JiangFa = jiangcheng;

            //获取考勤列表
            int kaoqin = GetList_KaoQin(info.ID, dateTime);
            info.KaoQin = kaoqin;

            //获取请假列表
            int qingjia = GetList_QingJia(info.ID, dateTime);
            info.QingJia = qingjia;

            info.Total = Convert.ToInt32(info.Salary) + info.JiangFa + info.KaoQin + info.QingJia;
        }

        gridView.DataSource = list;
        gridView.DataBind();
    }

    public int GetList_QingJia(int userid, DateTime time)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select sum(Money) ");
        strSql.Append(" FROM VacateInfos ");
        strSql.Append(" where DATEDIFF(m,StartTime,'" + time + "')=0 and UserId = " + userid);


        SqlConnection scon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        scon.Open();
        SqlCommand com = new SqlCommand(strSql.ToString(), scon);

        object obj = com.ExecuteScalar();
        int count = 0;

        if (!DBNull.Value.Equals(obj) && !string.IsNullOrEmpty(obj.ToString()))
        {
            count = Convert.ToInt32(obj);
        }

        scon.Close();

        return count;
    }

    public int GetList_KaoQin(int userid, DateTime time)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select sum(Money) ");
        strSql.Append(" FROM ClockingInInfos ");
        strSql.Append(" where DATEDIFF(m,SubTime,'" + time + "')=0 and UserId = " + userid);


        SqlConnection scon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        scon.Open();
        SqlCommand com = new SqlCommand(strSql.ToString(), scon);

        object obj = com.ExecuteScalar();
        int count = 0;

        if (!DBNull.Value.Equals(obj) && !string.IsNullOrEmpty(obj.ToString()))
        {
            count = Convert.ToInt32(obj);
        }

        scon.Close();

        return count;
    }

    public int GetList_JiangCheng(int userid, DateTime time)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select sum(Money) ");
        strSql.Append(" FROM RewardsInfos ");
        strSql.Append(" where DATEDIFF(m,SubTime,'" + time + "')=0 and UserId = " + userid);


        SqlConnection scon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        scon.Open();
        SqlCommand com = new SqlCommand(strSql.ToString(), scon);

        object obj = com.ExecuteScalar();
        int count = 0;

        if (!DBNull.Value.Equals(obj) && !string.IsNullOrEmpty(obj.ToString()))
        {
            count = Convert.ToInt32(obj);
        }

        scon.Close();

        return count;
    }

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
            if (row["Salary"] != null && row["Salary"].ToString() != "")
            {
                model.Salary = int.Parse(row["Salary"].ToString());
            }

        }
        return model;
    }


    /// <summary>
    /// 获得数据列表
    /// </summary>
    public DataSet GetList(string strWhere)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("select userinfos.ID,UserName,Salary,departmentInfos.depName as DepartmentName,jobinfos.JobName ");
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

    protected void gridView_OnRowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.Header)
        {
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        BindData();
    }

    public partial class UserInfosInfo
    {
        public UserInfosInfo()
        { }
        #region Model
        private int _Total;
        public int Total
        {
            set { _Total = value; }
            get { return _Total; }
        }


        private int _QingJia;
        public int QingJia
        {
            set { _QingJia = value; }
            get { return _QingJia; }
        }

        private int _KaoQin;
        public int KaoQin
        {
            set { _KaoQin = value; }
            get { return _KaoQin; }
        }

        private int _JiangFa;
        public int JiangFa
        {
            set { _JiangFa = value; }
            get { return _JiangFa; }
        }

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