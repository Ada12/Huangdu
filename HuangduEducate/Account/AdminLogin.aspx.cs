using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class Account_AdminLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void loginBtn_Click(object sender, EventArgs e) 
    {
        string adminID_lg = adminID_TB.Text;
        string password_lg = password_TB.Text;
        if(adminID_lg == null || password_lg == null)
        {
            errorMessage.Text = "用户名或密码不能为空";
        }

        Admin a = new Admin();
        AdminInfo ai = new AdminInfo();
        ai = a.GetAdminInfo(adminID_lg);
        if (ai == null)
        {
            errorMessage.Text = "用户名或密码错误";
        }
        else if (ai.Password == password_lg)
        {
            Session["adminID"] = ai.ID;
            errorMessage.Text = "";
            //Server.Transfer("AdminManagement.aspx");
            Response.Redirect("AdminManagement.aspx");
        }
        else
        {
            errorMessage.Text = "用户名或密码错误";
        }
    }
}