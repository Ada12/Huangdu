using System; 
using Model;
using AccessDAL;
using System.Collections.Generic;
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

        public List<StudentInfo> getStudentList(string classNum)
        {
            HDStudent hs = new HDStudent();
            List<StudentInfo> stdlst = hs.GetStudentInfoList(classNum);
            stdlst.Sort(this.studentCompare);
            return stdlst;
        }

        public int SetStudentInfo(StudentInfo si)
        {
            //SetContentInfo(ci);
            HDStudent hs = new HDStudent();
            int result = hs.addStudent(si);
            return result;
        }
        public int studentCompare(StudentInfo x, StudentInfo y)
        {
            return QYDCompare.stringCompare(x.ID, y.ID);
        }

        public void deleteOutOfDateStudent()
        {
            HDStudent hs = new HDStudent();
            hs.deleteOutOfDateStudent();
        }

        public int changeStudentInfo(StudentInfo si)
        {
            HDStudent hs = new HDStudent();
            int result = hs.changeStudentInfo(si);
            return result;
        }

        public int deleteStudent(string studentID)
        {
            HDStudent hs = new HDStudent();
            int result = hs.deleteStudent(studentID);
            return result;
        }

    }

}