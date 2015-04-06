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
    }
}