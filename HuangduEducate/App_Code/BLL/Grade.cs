using System; 
using Model;
using AccessDAL;
using System.Collections.Generic;

/// <summary>
///Content 的摘要说明
/// </summary>
namespace BLL
{
    public class Grade
    {
        public List<GradeInfo> GetGradeInfoList(string id)
        {
            HDGrade mc = new HDGrade();
            List<GradeInfo> ci = mc.GetGradeInfoList(id);
            ci.Sort(Grade.compareGradeInfo);
            return ci;
        }

        public List<GradeInfo> GetGradeInfoList(List<string> ids, int week)
        {
            HDGrade mc = new HDGrade();
            List<GradeInfo> ci = mc.GetGradeInfo(ids, week);
            return ci;
        }

        public List<GradeInfo> GetGradeInfoList(List<string> ids, string week)
        {
            HDGrade mc = new HDGrade();
            int iweek=0;
            try 
            {
                iweek=Convert.ToInt32(week);
            }
            catch (Exception exp) 
            {
                return null;
            }
            List<GradeInfo> ci = mc.GetGradeInfo(ids, iweek);
            
            return ci;
        }

        public int SetStudentInfo(GradeInfo ci)
        {
            //SetContentInfo(ci);
            HDGrade mc = new HDGrade();
            int result = mc.SetGradeInfo(ci);
            return result;
        }

        public int UpdateInfo(GradeInfo gi, int c)
        {
            HDGrade hg = new HDGrade();
            int result = hg.UpdateInfo(gi,c);
            return result;
        }

        public int UpdateInfo(List<GradeInfo> lgi, int c)
        {
            HDGrade hg = new HDGrade();
            int result = hg.InsertData(lgi, c);
            return result;
        }

        static public int compareGradeInfo(GradeInfo gix, GradeInfo giy)
        {
            int step1 = QYDCompare.stringCompare(gix.ID, giy.ID);
            if (step1 == 0)
            {
                if (gix.Week > giy.Week) 
                {
                    return 1;
                }
                if (gix.Week < giy.Week)
                {
                    return -1;
                }
                return 0;
            }
            else
            {
                return step1;
            }

        }

        public int ClearAllData()
        {
            HDGrade hg = new HDGrade();
            int result = hg.ClearAllData();
            return result;
        }
    }
}