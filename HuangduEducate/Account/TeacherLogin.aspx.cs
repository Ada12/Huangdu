using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class Account_TeacherLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void loginBtn_Click(object sender, EventArgs e)
    {
        string teacherID = teacherID_TB.Text;
        string password = password_TB.Text;

        Teacher t = new Teacher();
        TeacherInfo ti = new TeacherInfo();
        ti = t.GetTeacherInfo(teacherID);

        Admin a = new Admin();
        AdminInfo ai = new AdminInfo();
        ai = a.GetAdminInfo(teacherID);

        if (ti == null && ai == null)
        {
            errorMessage.Text = "用户不存在";
        }
        else if (ti == null && ai.Password == password)
        {
            System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('登录成功！');</script>");
            Session["HDTeacherID"] = ai.ID;
            Server.Transfer("StudentRegister.aspx");
            errorMessage.Text = "";
        }
        else if (ai == null && ti.Password == password)
        {
            System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('登录成功！');</script>");
            Session["HDTeacherID"] = ti.ID;
            Server.Transfer("AddGrade.aspx");
            errorMessage.Text = "";
        }
        else
        {
            errorMessage.Text = "密码不正确";
        }
    }
}