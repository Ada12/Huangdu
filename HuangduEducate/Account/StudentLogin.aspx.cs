using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using Model;
using BLL;

public partial class Account_StudentLogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void loginBtn_Click(object sender, EventArgs e)
    {
        string studentID_lg = studentID_TB.Text;
        string name_lg = name_TB.Text;
        if (name_lg == "" || studentID_lg == "")
        {
            errorMessage.Text = "学号和姓名不能为空";
            return;
        }

        Student s = new Student();
        StudentInfo si = new StudentInfo();
        si = s.GetStudentInfo(studentID_lg);
        
        if (si == null)
        {
            errorMessage.Text = "学号或姓名错误";
        }
        else if (si.Name == name_lg)
        {
            Session["huangdueducateid"] = si.ID;
            Session["huangdueducatename"] = si.Name;
            errorMessage.Text = "";
            Response.Redirect("searchGrade.aspx");
        }
        else
        {
            errorMessage.Text = "学号或姓名错误";
        }

    }
}