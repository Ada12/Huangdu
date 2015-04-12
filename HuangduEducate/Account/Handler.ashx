<%@ WebHandler Language="C#" Class="Handler" %>

using System;
using System.Web;
using Model;
using BLL;
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
        if (selectSubject == "chinese")
        { 
            for (int i = 0; i < studentSet.Length; i ++ )
            {
                GradeInfo gi = new GradeInfo(studentSet[i], Int32.Parse(selectWeek), gradeInfoSet[i], "666", "666");
                lstgi.Add(gi);
            }
            msg = "录入成功";
        }
        else if (selectSubject == "math") 
        {
            for (int i = 0; i < studentSet.Length; i++)
            {
                GradeInfo gi = new GradeInfo(studentSet[i], Int32.Parse(selectWeek), "666", gradeInfoSet[i], "666");
                lstgi.Add(gi);
            }
            msg = "录入成功";
        }
        else if (selectSubject == "english")
        {
            for (int i = 0; i < studentSet.Length; i++)
            {
                GradeInfo gi = new GradeInfo(studentSet[i], Int32.Parse(selectWeek), "666", "666", gradeInfoSet[i]);
                lstgi.Add(gi);
            }
            msg = "录入成功";
        }
        else
        {
            msg = "录入失败";
        }
        Grade g = new Grade();
        int result = g.UpdateInfo(lstgi, Convert.ToInt32(selectSubject));
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