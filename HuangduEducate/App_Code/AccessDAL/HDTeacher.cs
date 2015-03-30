using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.OleDb;
using System.Web;
using Model;

/// <summary>
///HDTeacher 的摘要说明
/// </summary>

namespace AccessDAL
{
    public class HDTeacher
    {
        private const string PARM_ID = "@teacherID";
        private const string PARM_NAME = "@name";
        private const string PARM_PASSWORD = "@password";
        private const string SQL_SELECT_CONTENT = "select teacherID, name, password From teacher Where teacherID = @teacherID ";
        private const string SQL_INSERT_CONTENT = "insert into teacher(teacherID, name, password) values (@teacherID, @name, @password);";


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
        
        public TeacherInfo GetTeacherInfo(string id)
        {
            TeacherInfo ti = null;
            OleDbParameter teacherInfo = new OleDbParameter(PARM_ID, OleDbType.VarChar);
            teacherInfo.Value = id;
            using (OleDbDataReader odr = GetData(SQL_SELECT_CONTENT, teacherInfo)) 
            {
                if (odr.Read()) 
                {
                    ti = new TeacherInfo(odr.GetString(0), odr.GetString(1), odr.GetString(2));
                }
            }
            return ti;
        }

        public void SetTeacherInfo(TeacherInfo ti)
        {
            OleDbParameter[] teacherInfo = new OleDbParameter[] { new OleDbParameter(PARM_ID,OleDbType.VarChar),new OleDbParameter(PARM_NAME, OleDbType.VarChar),
                new OleDbParameter(PARM_PASSWORD, OleDbType.VarChar)};
            teacherInfo[0].Value = ti.ID;
            teacherInfo[1].Value = ti.Name;
            teacherInfo[2].Value = ti.Password;

            InsertData(SQL_INSERT_CONTENT, teacherInfo);
        }
        
    }
}