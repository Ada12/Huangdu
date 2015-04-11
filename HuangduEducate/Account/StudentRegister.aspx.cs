using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;
using System.Web;
using System.Net;
using System.Web.UI;
using Model;
using BLL;

public partial class Account_StudentRegister : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void registerBtn_Click(object sender, EventArgs e)
    {
        string studentID_rg = studentID_TB.Text;
        string name_rg = name_TB.Text;
        string class_rg = class_TB.Text;

        Student c = new Student();
        StudentInfo ci = new StudentInfo(studentID_rg, name_rg, class_rg);
        int result = c.SetStudentInfo(ci);
        if (result == 0) {
            System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('录入失败！');</script>");
        }
        System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('录入成功！');</script>");
    }
}