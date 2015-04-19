using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AccessDAL;
using Model;

/// <summary>
///Class 的摘要说明
/// </summary>
namespace BLL
{
    public class Class
    {
        public ClassInfo GetClassInfo(string id)
        {
            HDClass hc = new HDClass();
            ClassInfo ci = new ClassInfo();
            ci = hc.GetCLassInfo(id);
            return ci;
        }

        public int SetClassInfo(ClassInfo ci)
        {
            HDClass hc = new HDClass();
            int result = hc.SetCLassInfo(ci);
            return result;
        }

        public int UpdataGrade()
        {
            int result;
            HDClass hc = new HDClass();
            result = hc.UpdateGrade();
            return result;
        }

        public int UpdatePassword(string classID, string password) 
        {
            HDClass hc = new HDClass();
            int result = hc.UpdateInfo(classID, password);
            return result;
        }
    }
}