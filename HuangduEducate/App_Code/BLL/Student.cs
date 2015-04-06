using System; 
using Model;
using AccessDAL;

/// <summary>
///Content 的摘要说明
/// </summary>
namespace BLL
{
    public class Student
    {
        public StudentInfo GetStudentInfo(string id)
        {
            HDStudent hs = new HDStudent();
            StudentInfo si = hs.GetStudentInfo(id);
            return si;
        }

        public int SetStudentInfo(StudentInfo si)
        {
            //SetContentInfo(ci);
            HDStudent hs = new HDStudent();
            int result = hs.SetStudentInfo(si);
            return result;
        }
    }
}