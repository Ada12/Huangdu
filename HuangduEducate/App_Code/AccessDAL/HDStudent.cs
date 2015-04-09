using System;
using System.Data;
using System.Data.OleDb;
using Model;
using System.Collections.Generic;

/// <summary>
///Content 的摘要说明
/// </summary>
namespace AccessDAL
{
    public class HDStudent
    {
        private const string PARM_ID = "@studentID";
        private const string PARM_NAME = "@name";
        private const string PARM_CLASS_NUM = "@class_num";
        private const string PARM_WEEK = "@week";

        private const string SQL_SELECT_CONTENT = "select studentID, name, class_num from student where studentID = @studentID ";
        private const string SQL_SELECT_CONTENT_BY_CLASS = "select studentID, name, class_num from student where class_num = @class_num;";
        private const string SQL_INSERT_CONTENT_BY_ID = "insert into student(studentID, name, class_num ) values (@studentID, @name, @class_num);";
        
        public static int InsertData(string sql, OleDbParameter[] cmdParms,OleDbConnection connection)
        {
            int result = -1;
            OleDbCommand oleCmd = new OleDbCommand(sql, connection);
            if(cmdParms != null)
            {
                foreach(OleDbParameter parm in cmdParms)
                {
                    oleCmd.Parameters.Add(parm);
                }
            }
            result = oleCmd.ExecuteNonQuery();
            //oleCmd.Parameters.Clear();
            return result;
        }

        public static OleDbDataReader GetData(string sql, OleDbParameter cmdParm, OleDbConnection connection)
        {
            OleDbCommand oleCmd = new OleDbCommand(sql, connection);
            oleCmd.Parameters.Add(cmdParm);
            OleDbDataReader odr = oleCmd.ExecuteReader();
            return odr;
        }
        
        public StudentInfo GetStudentInfo(string id)
        {
            StudentInfo ci = null;
            OleDbParameter studentInfo = new OleDbParameter(PARM_ID, OleDbType.VarChar);
            studentInfo.Value = id;
            OleDbConnection oledbc = (new DBConnection()).getConnection();
            oledbc.Open();

            OleDbDataReader odr = GetData(SQL_SELECT_CONTENT, studentInfo, oledbc);
            
             if (odr.Read()) 
            {
                ci = new StudentInfo(odr.GetString(0), odr.GetString(1), odr.GetString(2));                
            }
            oledbc.Close();
            return ci;
        }

        public List<StudentInfo> GetStudentInfoList(string classNum)
        {
            List<StudentInfo> studentList = new List<StudentInfo>();
            OleDbConnection oledbc = (new DBConnection()).getConnection();
            oledbc.Open();
            OleDbParameter param = new OleDbParameter(PARM_CLASS_NUM, OleDbType.VarChar);
            param.Value = classNum;
            OleDbDataReader reader= GetData(SQL_SELECT_CONTENT_BY_CLASS, param, oledbc);
            while (reader.Read())
            {
                StudentInfo onestudent = new StudentInfo(reader.GetString(0), reader.GetString(1), classNum);
                studentList.Add(onestudent);
            }
            oledbc.Close();
            return studentList;
        }


        public int addStudent(StudentInfo si)
        {
            int res = -1;
            OleDbParameter[] studentInfo = new OleDbParameter[] { new OleDbParameter(PARM_ID,OleDbType.VarChar),new OleDbParameter(PARM_NAME, OleDbType.VarChar),
                new OleDbParameter(PARM_CLASS_NUM, OleDbType.Integer)};

            OleDbConnection oledbc = (new DBConnection()).getConnection();
            oledbc.Open();
            studentInfo[0].Value = si.ID;
            studentInfo[1].Value = si.Name;
            studentInfo[2].Value = si.ClassNum;
            res=InsertData(SQL_INSERT_CONTENT_BY_ID, studentInfo, oledbc);
            oledbc.Close();
            return res;
        }
        

        
    }
}