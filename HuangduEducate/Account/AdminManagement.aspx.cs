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

    protected void addClassBtn_Click(object sender, EventArgs e) 
    {
        Class c = new Class();
        string enterTime = addClassEnterTime_DD.SelectedValue;
        string str = enterTime.Substring(enterTime.Length - 2);
        string classID = str.Remove(0, str.Length - 2) + addClassClass_DD.SelectedValue;
        int enterClass = Int32.Parse(addClassClass_DD.SelectedValue);
        DateTime now = DateTime.Now;
        int enterGrade = now.Year - Int32.Parse(enterTime);
        ClassInfo ci = new ClassInfo(classID, enterGrade, enterClass, classID);
        int result = c.SetClassInfo(ci);
        if (result == 0)
        {
            System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('添加失败！');</script>");
        }
        else
        {
            addClassResultMsg.Text = "添加成功！"+ enterGrade +"年级"+ enterClass +"班的账号为："+ classID +"密码为：" + classID;
            addClassEnterTime_DD.SelectedValue = "2009";
            addClassClass_DD.SelectedValue = "1";
        }
    }

    protected void changeCLassPasswordBtn_Click(object sender, EventArgs e) 
    {
        string classID = changePasswordAccountNum_TB.Text;
        string oldPassword = oldPassword_TB.Text;
        string newPassword = newPassword_TB.Text;
        Class c = new Class();
        ClassInfo ci = c.GetClassInfo(classID);
        if (ci.Password != oldPassword)
        {
            changeClassErrorMsg.Text = "原密码不正确";
        }
        else if(newPassword != newPasswordConfirm_TB.Text)
        {
            System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('密码不相同！');</script>");
        }
        else
        {
            
        }
    }

    protected void changeAdminPasswordBtn_Click(object sender, EventArgs e)
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