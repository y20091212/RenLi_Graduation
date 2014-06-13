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

public partial class JobMoveInfos_Modify : System.Web.UI.Page
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
        Update(model);
    }

    public void Update(JobMoveInfosInfo model)
    {
        StringBuilder strSql = new StringBuilder();
        strSql.Append("update JobMoveInfos set ");
        strSql.Append("NewJob='" + model.NewJob + "',");
        strSql.Append("OldJob='" + model.OldJob + "',");
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