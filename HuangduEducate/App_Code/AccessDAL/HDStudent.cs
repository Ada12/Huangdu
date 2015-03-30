using System;
using System.Data;
using System.Data.OleDb;
using Model;

/// <summary>
///Content 的摘要说明
/// </summary>
namespace AccessDAL
{
    public class HDStudent
    {
        private const string PARM_ID = "@studentID";
        private const string PARM_NAME = "@name";
        private const string PARM_CLASS = "@class";
        private const string PARM_GRADE = "@grade";
        private const string PARM_WEEK = "@week";

        private const string SQL_SELECT_CONTENT = "select studentID, name, class, grade From student Where studentID = @studentID ";
        private const string SQL_INSERT_CONTENT = "insert into student(studentID, name, class, grade) values (@studentID, @name, @class, @grade);";
        private const string SQL_INSERT_ALL = "insert into grade(ID, week, chinese, math, english) values (@ID, @week, -1, -1, -1)";

        public static void InsertData(string sql, OleDbParameter[] cmdParms)
        {
            DBConnection dbconn = new DBConnection();
            OleDbConnection connection = dbconn.getConnection();
            connection.Open();
            OleDbCommand oleCmd = new OleDbCommand(sql, connection);
            if(cmdParms != null)
            {
                foreach(OleDbParameter parm in cmdParms)
                {
                    oleCmd.Parameters.Add(parm);
                }
            }
            oleCmd.ExecuteNonQuery();
            oleCmd.Parameters.Clear();
            if(connection != null)
            {
                connection.Close();
            }
        }

        public static OleDbDataReader GetData(string sql, OleDbParameter cmdParm) {
            DBConnection dbconn = new DBConnection();
            OleDbConnection connection = dbconn.getConnection();
            connection.Open();
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
            using(OleDbDataReader odr = GetData(SQL_SELECT_CONTENT, studentInfo)) 
            {
                if (odr.Read()) 
                {
                    ci = new StudentInfo(odr.GetString(0), odr.GetString(1), odr.GetInt32(2), odr.GetInt32(3));
                    
                }
            }
            return ci;
        }

        public void SetStudentInfo(StudentInfo ci)
        {
            OleDbParameter[] studentInfo = new OleDbParameter[] { new OleDbParameter(PARM_ID,OleDbType.VarChar),new OleDbParameter(PARM_NAME, OleDbType.VarChar),
                new OleDbParameter(PARM_CLASS, OleDbType.Integer),new OleDbParameter(PARM_GRADE, OleDbType.Integer)};
            studentInfo[0].Value = ci.ID;
            studentInfo[1].Value = ci.Name;
            studentInfo[2].Value = ci.Class;
            studentInfo[3].Value = ci.Grade;
            InsertData(SQL_INSERT_CONTENT, studentInfo);
            
            OleDbParameter[] gradeInfo = new OleDbParameter[] { new OleDbParameter(PARM_ID,OleDbType.VarChar),new OleDbParameter(PARM_WEEK, OleDbType.Integer)};
            gradeInfo[0].Value = ci.ID;
            for (int w = 1; w < 27; w ++)
            {
                gradeInfo[1].Value = w;
                InsertData(SQL_INSERT_ALL, gradeInfo);
            }
        }
        
    }
}