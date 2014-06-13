using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class updatepwd : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string oldPwd = txtOldPwd.Value;
        string userid = Session["userid"].ToString();
        if (TextBox1.Value == "" || TextBox2.Value == "" || TextBox1.Value != TextBox2.Value)
        {
            lbError.Text = "两次输入新密码不一致！";
        }
        else if (CheckOldPwd(oldPwd, userid))
        {
            //定义变量
            string word;
            word = this.TextBox1.Value;
            SqlConnection scon = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
            scon.Open();

            SqlCommand scmd = new SqlCommand("update UserInfos set Pwd='" + word + "' where id='" + userid + "'", scon);
            if (scmd.ExecuteNonQuery() > 0)
            {
                Response.Write("<script language='javascript'>alert('密码修改成功！');</script>");
                this.TextBox1.Value = "";
                this.TextBox2.Value = "";
            }
            else
            {
                Response.Write("<script language='javascript'>alert('密码修改失败！');</script>");
            }
            scmd.Dispose();
            scon.Close();
        }
    }

    public bool CheckOldPwd(string oldPwd, string userid)
    {
        bool flag = false;

        string ConnectionString = ConfigurationManager.ConnectionStrings["constr"].ToString();
        string sqlstr = "select Pwd from UserInfos where id=@id";
        SqlConnection scon = new SqlConnection(ConnectionString);
        SqlCommand scm = new SqlCommand(sqlstr, scon);
        scm.Parameters.Add(new SqlParameter("@id", userid));
        scon.Open();
        SqlDataReader reader = scm.ExecuteReader();
        if (reader.Read())
        {
            string strPwd = reader[0].ToString();

            reader.Close();
            if (strPwd != oldPwd)
            {
                lbError.Text = "旧密码错误！";
                flag = false;
            }
            else
            {
                flag = true;
            }

        }
        else
        {
            flag = false;
        }
        scon.Close();
        return flag;
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        this.TextBox1.Value = "";
        this.TextBox2.Value = "";
        txtOldPwd.Value = "";
        lbError.Text = "";
    }
}