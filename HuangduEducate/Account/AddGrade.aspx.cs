using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;


public partial class Account_AddGrade : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string classID = "";
        try
        {
            classID = Session["HDClassID"].ToString();
        }
        catch (Exception excep)
        {
            excep.ToString();
            Server.Transfer("ClassLogin.aspx");
        }
        if(classID != "")
        {
            Class c = new Class();
            ClassInfo ci = new ClassInfo();
            ci = c.GetClassInfo(classID);
            class_LB.Text = ci.Class.ToString();
            grade_LB.Text = ci.Grade.ToString();
        }
    }

    protected void logoffBtn_Click(object sender, EventArgs e)
    {
        Session["HDClassID"] = null;
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
        if (studentID_TB.Text == "" || weekNum_TB.Text == null || subject_DD.SelectedValue == "" || grade_TB.Text == null)
        {
            System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('输入项不能为空！');</script>");
            return;
        }
        else
        {
            string studentID = studentID_TB.Text;
            int week = int.Parse(weekNum_TB.Text);
            string subject = subject_DD.SelectedValue;
            string grade = grade_TB.Text;
            int category;
            Grade g = new Grade();

            if (subject == "语文")
            {
                GradeInfo gi = new GradeInfo(studentID, week, grade, null, null);
                category = 1;
                int r = g.UpdateInfo(gi, category);
                if (r != 0)
                {
                    System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('录入成功！');</script>");
                }
                else 
                {
                    System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('录入失败！');</script>");
                }
            }
            else if (subject == "数学")
            {
                GradeInfo gi = new GradeInfo(studentID, week, null, grade, null);
                category = 2;
                int r = g.UpdateInfo(gi, category);
                if (r != 0)
                {
                    System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('录入成功！');</script>");
                }
                else
                {
                    System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('录入失败！');</script>");
                }
            }
            else
            {
                GradeInfo gi = new GradeInfo(studentID, week, null, null, grade);
                category = 3;
                int r = g.UpdateInfo(gi, category);
                if (r != 0)
                {
                    System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('录入成功！');</script>");
                }
                else
                {
                    System.Web.HttpContext.Current.Response.Write("<script language=javascript>alert('录入失败！');</script>");
                }
            }
        }


    }
}