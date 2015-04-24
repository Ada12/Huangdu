using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using System.Data;

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

    protected void addBatchStudentBtn_Click(object sender, EventArgs e)
    {
        File f = new File();
        if (FuloadExcelFile.FileName == "")
            {
                return;
            }
            else
            {
                string fileExt = System.IO.Path.GetExtension(FuloadExcelFile.FileName);
                if (fileExt != ".xlsx")//必须是EXCEL文件
                {
                    return;
                }
                else
                {
                    FuloadExcelFile.SaveAs(Server.MapPath("~/") + FuloadExcelFile.FileName);
                    //string filepath = FuloadExcelFile.PostedFile.FileName;//文件路径，FuloadExcelFile为上传文件的控件
                    string filepath = Server.MapPath("~/") + FuloadExcelFile.FileName;
                    DataTable dt = new DataTable();
                    dt = f.GetDataFromExcelWithAppointSheetName(filepath);
                    if (f.insertData(dt))//导入数据库
                    {
                        Response.Write("成功");
                    }
                    else
                    {
                        Response.Write("失败！");
                    }
 
                }
            }
    }

    protected void changeStudent_Click(object sender, EventArgs e)
    {
        string studentID = changeStudentID_TB.Text;
        string classnum = changeCurrentClass_DD.Text; //changeCurrentClass_TB.Text;
        string gradenum = changeCurrentGrade_DD.Text; //changeCurrentGrade_TB.Text;
        DateTime now = DateTime.Now;
        int enterGrade = now.Year - Int32.Parse(gradenum) - 2000;
        string class_num = enterGrade.ToString() + classnum;
        StudentInfo si = new StudentInfo(studentID, "student", class_num);
        Student s = new Student();
        int result = s.changeStudentInfo(si);
        if (result == 0)
        {
            System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('修改失败！');</script>");
        }
        else
        {
            System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('修改成功！学号"+ studentID +"的年级已经更改为"+ gradenum +"年级，班级更改为"+ classnum +"班');</script>");
        }
    }

    protected void logoffBtn_Click(object sender, EventArgs e)
    {
        Session["huangdueducateid"] = null;
        Session["huangdueducatename"] = null;
        ClearClientPageCache();
        Response.Redirect("main.aspx");
    }

    protected void ClearClientPageCache()
    {
        Response.Buffer = true;
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
        Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
        Response.Expires = 0;
        Response.CacheControl = "no-cache";
        Response.Cache.SetNoStore();
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
            int result = c.UpdatePassword(classID, newPassword);
            if(result > 0){
                System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('密码修改成功！');</script>");
            }
        }
    }

    protected void changeAdminPasswordBtn_Click(object sender, EventArgs e)
    {
        string oldPassword = oldAdminPassword_TB.Text;
        string newPassword = newAdminPassword_TB.Text;
        string newPasswordConfirm = newAdminPasswordConfirm_TB.Text;
        Admin a = new Admin();
        AdminInfo ai = new AdminInfo();
        string uid = (string)HttpContext.Current.Session["adminID"];
        ai = a.GetAdminInfo(uid);
        
        if (ai.Password != oldPassword)
        {
            changeClassErrorMsg.Text = "原密码不正确";
        }
        else if (newPassword != newPasswordConfirm)
        {
            System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('密码不相同！');</script>");
        }
        else
        {
            AdminInfo ainew = new AdminInfo(uid, newPassword);
            int result = a.UpdateInfo(ainew);
        }
    }

    protected void changeLevelStructureBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("LevelStructureManageMent.aspx");
    }

    protected void changeGrade_Click(object sender, EventArgs e)
    {
        Class c = new Class();
        Student s = new Student();
        s.deleteOutOfDateStudent();
        int result = c.UpdataGrade();
        int changedClasses = c.DeleteOutOfDateClass();
        if (result == 0)
        {
            System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('修改失败！');</script>"); 
        }
        else
        {
            System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('年级修改成功！');</script>");
        }

    }

    protected void changeTerm_Click(object sender, EventArgs e)
    {
        Grade g = new Grade();
        int result = g.ClearAllData();
        if(result == 0)
        {
            System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('修改失败！');</script>"); 
        }
        else
        {
            System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('学期修改成功！');</script>");
        }
    }
}