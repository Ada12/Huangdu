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

        public void SetStudentInfo(GradeInfo ci)
        {
            //SetContentInfo(ci);
            HDGrade mc = new HDGrade();
            mc.SetGradeInfo(ci);
        }

        public void UpdateInfo(GradeInfo gi, int c)
        {
            HDGrade hg = new HDGrade();
            hg.UpdateInfo(gi,c);
        }
    }
}