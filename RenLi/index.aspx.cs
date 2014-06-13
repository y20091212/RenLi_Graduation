using System;

public partial class index : System.Web.UI.Page
{
    protected string LeftUrl;
    protected void Page_Load(object sender, EventArgs e)
    {
        //Session["jobId"] = reader[4].ToString();
        //Session["departid"] = reader[3].ToString();
        if (Session["departid"].ToString() == "1" && Session["jobId"].ToString()=="1")//人事部主管
        {
            LeftUrl = "leftMenu_Manage.aspx";
        }
        else if (Session["jobId"].ToString() == "1") //其他部门主管
        {
            LeftUrl = "leftMenu_ZhuGuan.aspx";
        }
        else//部门员工
        {
            LeftUrl = "leftMenu_YuanGong.aspx";
        }
    }
}