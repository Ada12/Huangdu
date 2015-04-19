using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using AccessDAL;

/// <summary>
///Rank 的摘要说明
/// </summary>
namespace BLL
{
    public class Rank
    {
        public List<StudentInfo> getAllStudent(string classNum)
        {
            HDRank hr = new HDRank();
            List<StudentInfo> lsi = hr.getAllStudents(classNum);
            return lsi;
        }

        public List<GradeInfo> getAllGrade(List<StudentInfo> lsi) 
        {
            HDRank hr = new HDRank();
            List<GradeInfo> lgi = hr.getAllGrade(lsi);
            return lgi;
        }

        public RankInfo getGradeRank(string classNum)
        {
            HDRank hr = new HDRank();
            RankInfo ri = hr.getGradeRank(classNum);
            return ri;
        }

        public int getWeek()
        {
            HDRank hr = new HDRank();
            int week = hr.getHighestWeek();
            return week;
        }
    }
}