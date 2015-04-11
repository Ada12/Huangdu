using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class Account_AdminManagement : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void addStudent_Click(object sender, EventArgs e)
    {
        string studentID_rg = studentID_TB.Text;
        string name_rg = name_TB.Text;
        string str = entertime_DD.Text.Substring(entertime_DD.Text.Length - 2);
        str = str.Remove(0,str.Length - 2);
        string class_num = str + class_DD.Text;


        Student c = new Student();
        StudentInfo ci = new StudentInfo(studentID_rg, name_rg, class_num);
        int result = c.SetStudentInfo(ci);
        if (result == 0)
        {
            System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('录入失败！');</script>");
        }
        System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('录入成功！');</script>");
        studentID_TB.Text = "";
        name_TB.Text = "";
        class_DD.SelectedValue = "1";
        entertime_DD.SelectedValue = "2015";
    }

    protected void changePasswordBtn_Click(object sender, EventArgs e) 
    {
    
    }

    protected void changeGrade_Click(object sender, EventArgs e)
    {
        Class c = new Class();
        int result = c.UpdataGrade();
        if (result == 0)
        {
            System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('修改失败！');</script>");
        }
        else
        {
            System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('修改成功！');</script>");
        }

    }
}