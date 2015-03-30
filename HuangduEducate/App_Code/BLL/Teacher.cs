using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using AccessDAL;

/// <summary>
///Teacher 的摘要说明
/// </summary>

namespace BLL
{
    public class Teacher
    {
        public TeacherInfo GetTeacherInfo(string id)
        {
            HDTeacher ht = new HDTeacher();
            TeacherInfo ti = new TeacherInfo();
            ti = ht.GetTeacherInfo(id);
            return ti;
        }

        public void SetTeacherInfo(TeacherInfo ti)
        {
            HDTeacher ht = new HDTeacher();
            ht.SetTeacherInfo(ti);
        }
    }
}