<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using Model;
using BLL;
using AccessDAL;
using System.Collections.Generic;

public class Handler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        //context.Response.Write("Hello World");
        String selectWeek = context.Request.Params["week"].ToString().Trim();
        String selectSubject = context.Request.Params["subject"].ToString().Trim();
        String student = context.Request.Params["studentID"].ToString().Trim();
        String gradeInfo = context.Request.Params["grade"].ToString().Trim();
        String[] studentSet = student.Split('_');
        String[] gradeInfoSet = gradeInfo.Split('_');
        List<GradeInfo> lstgi = new List<GradeInfo>();
        String msg = "";
        int iss = -1;
        if (selectSubject == "chinese")
        {
            iss = 1;
            for (int i = 0; i < studentSet.Length; i ++ )
            {
                GradeInfo gi = new GradeInfo(studentSet[i], Int32.Parse(selectWeek), gradeInfoSet[i], HDGrade.evil, HDGrade.evil);
                lstgi.Add(gi);
            }
            msg = "录入成功";
        }
        else if (selectSubject == "math") 
        {
            iss = 2;
            for (int i = 0; i < studentSet.Length; i++)
            {
                GradeInfo gi = new GradeInfo(studentSet[i], Int32.Parse(selectWeek), HDGrade.evil, gradeInfoSet[i], HDGrade.evil);
                lstgi.Add(gi);
            }
            msg = "录入成功";
        }
        else if (selectSubject == "english")
        {
            iss = 3;
            for (int i = 0; i < studentSet.Length; i++)
            {
                GradeInfo gi = new GradeInfo(studentSet[i], Int32.Parse(selectWeek), HDGrade.evil, HDGrade.evil, gradeInfoSet[i]);
                lstgi.Add(gi);
            }
            msg = "录入成功";
        }
        else
        {
            msg = "录入失败";
        }
        Grade g = new Grade();
        int result = g.UpdateInfo(lstgi, iss);
        if (result == 0) {
            msg = "录入失败";
        }
        
        context.Response.Write(msg);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}