using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class Account_ClassLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void loginBtn_Click(object sender, EventArgs e)
    {
        string classID = classID_TB.Text;
        string password = password_TB.Text;

        Class c = new Class();
        ClassInfo ci = c.GetClassInfo(classID);
        if (ci == null)
        {
            errorMessage.Text = "班级不存在";
            return;
        }


        if (password == ci.Password)
        {
            //System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('登录成功！');</script>");
            Session["HDClassID"] = ci.ID;
            Response.Redirect("AddGrade.aspx");
            errorMessage.Text = "";
        }
        else
        {
            errorMessage.Text = "密码不正确";
        }
    }
}