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
    }
}