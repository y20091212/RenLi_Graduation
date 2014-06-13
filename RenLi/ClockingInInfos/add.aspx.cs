using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

public partial class ClockingInInfos_add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DateTime dt = DateTime.Now;
            //判断上午下午 
            if (dt.Hour > 0 && dt.Hour <= 12)
            {
                ddlInOut.SelectedValue = "1";
            }
            else if (dt.Hour > 12)
            {
                ddlInOut.SelectedValue = "0";
            }

            lbtime.Text = dt.ToString();
        }
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        int UserId = int.Parse(Session["userid"].ToString());
        DateTime SubTime = Convert.ToDateTime(lbtime.Text);


        int Money = 0;
        //九点上班 九点之后打卡 30分钟以内按迟到算 每次扣10元  30分钟以上按严重迟到算 每次扣100元   
        //五点下班 五点之前打卡 30分钟以内按早退算 每次扣10元  30分钟以上按严重早退算 每次扣100元
        //上班
        if (ddlInOut.SelectedValue == "1" && SubTime.Hour == 9 && SubTime.Minute <= 10)
        {
            Money = -10;
        }
        else if (ddlInOut.SelectedValue == "1" && SubTime.Hour == 9 && SubTime.Minute <= 30)
        {
            Money = -40;
        }
        else if (ddlInOut.SelectedValue == "1" && SubTime.Hour == 9 && SubTime.Minute <= 60)
        {
            Money = -80;
        }
        else if (ddlInOut.SelectedValue == "1" && SubTime.Hour > 9 || SubTime.Hour <= 12)
        {
            Money = -160;
        }
        //下班
        else if (ddlInOut.SelectedValue == "0" && SubTime.Hour == 16 && SubTime.Minute < 60 && SubTime.Minute >= 50)
        {
            Money = -10;
        }
        else if (ddlInOut.SelectedValue == "0" && SubTime.Hour == 16 && SubTime.Minute < 50 && SubTime.Minute >= 30)
        {
            Money = -40;
        }
        else if (ddlInOut.SelectedValue == "0" && SubTime.Hour == 16 && SubTime.Minute < 30 && SubTime.Minute >= 0)
        {
            Money = -80;
        }
        else if (ddlInOut.SelectedValue == "0" && SubTime.Hour > 12 || SubTime.Hour <= 16)
        {
            Money = -160;
        }

        int IsInOut = int.Parse(ddlInOut.SelectedValue);


        ClockingInInfosInfo model = new ClockingInInfosInfo();
        model.UserId = UserId;
        model.Money = Money;
        model.IsInOut = IsInOut;
        model.SubTime = SubTime;

        Add(model);
    }

    public void Add(ClockingInInfosInfo model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into ClockingInInfos(");
        strSql.Append("UserId,Money,IsInOut,SubTime)");
        strSql.Append(" values (");
        strSql.Append("'" + model.UserId + "','" + model.Money + "','" + model.IsInOut + "','" + model.SubTime + "')");
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

    public partial class ClockingInInfosInfo
    {
        public ClockingInInfosInfo()
        { }
        #region Model
        private int _id;
        private int? _userid;
        private int? _money;
        private int? _isinout;
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
        public int? Money
        {
            set { _money = value; }
            get { return _money; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? IsInOut
        {
            set { _isinout = value; }
            get { return _isinout; }
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