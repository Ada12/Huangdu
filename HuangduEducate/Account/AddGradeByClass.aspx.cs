using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;

public partial class Account_AddGradeByClass : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string teacherID = "";
        try
        {
            teacherID = Session["HDTeacherID"].ToString();
        }
        catch (Exception excep)
        {
            excep.ToString();
            Server.Transfer("TeacherLogin.aspx");
        }
        if (teacherID != "")
        {
            Teacher t = new Teacher();
            TeacherInfo ti = new TeacherInfo();
            ti = t.GetTeacherInfo(teacherID);
            teacherID_LB.Text = ti.ID;
            teacherName_LB.Text = ti.Name;
        }
    }

    protected void logoffBtn_Click(object sender, EventArgs e)
    {
        Session["HDTeacherID"] = null;
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

    protected void submitBtn_Click(object sender, EventArgs e)
    {
        if (weekNum_TB.Text == null || subject_DD.SelectedValue == "" || grade_TB.Text == null)
        {
            System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('输入项不能为空！');</script>");
            return;
        }
        else
        {
            
            int week = int.Parse(weekNum_TB.Text);
            string subject = subject_DD.SelectedValue;
            int grade = int.Parse(grade_TB.Text);
            int category;
            Grade g = new Grade();
            /*
            if (subject == "语文")
            {
                GradeInfo gi = new GradeInfo(studentID, week, grade, -1, -1);
                category = 1;
                g.UpdateInfo(gi, category);
                System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('录入成功！');</script>");
            }
            else if (subject == "数学")
            {
                GradeInfo gi = new GradeInfo(studentID, week, -1, grade, -1);
                category = 2;
                g.UpdateInfo(gi, category);
                System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('录入成功！');</script>");
            }
            else
            {
                GradeInfo gi = new GradeInfo(studentID, week, -1, -1, grade);
                category = 3;
                g.UpdateInfo(gi, category);
                System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('录入成功！');</script>");
            }*/
        }


    }
}