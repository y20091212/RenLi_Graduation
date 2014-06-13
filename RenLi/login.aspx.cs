using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void lbClear_Click(object sender, EventArgs e)
    {
        txtPwd.Text = "";
        txtUserName.Text = "";
        lbError.Text = "";
    }
    protected void lbLogin_Click(object sender, EventArgs e)
    {
        string ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
        string sqlstr;
        sqlstr = "select ID,UserName,Pwd,Department,Job from UserInfos where UserName=@adminname and Pwd=@Pwd";
        SqlConnection scon = new SqlConnection(ConnectionString);
        SqlCommand scm = new SqlCommand(sqlstr, scon);
        scm.Parameters.Add("@adminname", SqlDbType.VarChar, 20);
        scm.Parameters.Add("@Pwd", SqlDbType.VarChar, 20);
        scm.Parameters["@adminname"].Value = this.txtUserName.Text;
        scm.Parameters["@Pwd"].Value = this.txtPwd.Text;
        scon.Open();
        SqlDataReader reader = scm.ExecuteReader();
        if (reader.Read())
        {
            Session["username"] = this.txtUserName.Text.ToString();
            Session["userid"] = reader[0].ToString(); ;
            Session["jobid"] = reader[4].ToString();
            Session["departid"] = reader[3].ToString();
            Response.Redirect("index.aspx");

            reader.Close();
        }
        else
        {
            this.lbError.Text = "用户名或密码错误";
        }
        scon.Close();
    }
}