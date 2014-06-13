using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RewardsInfos_add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int Money = 0;

        if (!int.TryParse(this.txtMoney.Text, out Money))
        {
            Response.Write("<script language='javascript'>alert('请输入正确的金额！');</script>");
        }
        else
        {

            int JiannChengId = int.Parse(ddlJiannChengId.SelectedValue);
            //int Money = int.Parse(this.txtMoney.Text);
            int UserId = int.Parse(ddlUserInfos.SelectedValue);
            int LuRuUserId = int.Parse(Session["userid"].ToString());
            string Remark = this.txtRemark.Text;
            DateTime SubTime = DateTime.Now;

            RewardsInfosInfo model = new RewardsInfosInfo();
            model.JiannChengId = JiannChengId;
            if (JiannChengId == 0)
            {
                model.Money = -Money;
            }
            else
            {
                model.Money = Money;
            }


            model.UserId = UserId;
            model.LuRuUserId = LuRuUserId;
            model.Remark = Remark;
            model.SubTime = SubTime;

            Add(model);

        }
    }

    public void Add(RewardsInfosInfo model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("insert into RewardsInfos(");
        strSql.Append("JiannChengId,Money,UserId,LuRuUserId,Remark,SubTime)");
        strSql.Append(" values (");
        strSql.Append("'" + model.JiannChengId + "','" + model.Money + "','" + model.UserId + "','" + model.LuRuUserId + "','" + model.Remark + "','" + model.SubTime + "')");
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

    public partial class RewardsInfosInfo
    {
        public RewardsInfosInfo()
        { }
        #region Model
        private int _id;
        private int? _jiannchengid;
        private int? _money;
        private int? _userid;
        private int? _luruuserid;
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
        public int? JiannChengId
        {
            set { _jiannchengid = value; }
            get { return _jiannchengid; }
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
        public int? UserId
        {
            set { _userid = value; }
            get { return _userid; }
        }
        /// <summary>
        /// 
        /// </summary>
        public int? LuRuUserId
        {
            set { _luruuserid = value; }
            get { return _luruuserid; }
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