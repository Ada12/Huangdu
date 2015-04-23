using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using Model;

/// <summary>
///HDClass 的摘要说明
/// </summary>
namespace AccessDAL
{
    public class HDClass
    {
        private const string PARM_ID = "@classID";
        private const string PARM_PASSWORD = "@password";
        private const string PARM_GRADE = "@grade";
        private const string PARM_CLASS = "@classNum";
        private const string SQL_SELECT_CONTENT = "select classID, classGrade, classNum, password From class Where classID = @classID ";
        private const string SQL_INSERT_CONTENT = "insert into class values(@classID, @grade, @classNum, @password);";
        private const string SQL_UPDATE_GRADE = "update class set classGrade = classGrade + 1";
        private const string SQL_UPDATE_CONTENT = "UPDATE [class] SET [password] = @password WHERE [classID] = @classID;";
        private const string SQL_DELETE_CLASS = "DELETE FROM class WHERE classGrade = 6 ";
        private const string SQL_CLASS_NUM = "select classID from class Where classGrade = 5";

        public static int InsertData(string sql, OleDbParameter[] cmdParms)
        {
            DBConnection dbconn = new DBConnection();
            OleDbConnection connection = dbconn.getConnection();
            connection.Open();
            OleDbCommand oleCmd = new OleDbCommand(sql, connection);
            if (cmdParms != null)
            {
                foreach (OleDbParameter parm in cmdParms)
                {
                    oleCmd.Parameters.Add(parm);
                }
            }
            int result = oleCmd.ExecuteNonQuery();
            if (connection != null)
            {
                connection.Close();
            }
            return result;
        }

        public int SetCLassInfo(ClassInfo ci)
        {
            OleDbParameter[] classInfo = new OleDbParameter[] { new OleDbParameter(PARM_ID,OleDbType.VarChar),new OleDbParameter(PARM_GRADE, OleDbType.Integer),
                new OleDbParameter(PARM_CLASS, OleDbType.Integer), new OleDbParameter(PARM_PASSWORD, OleDbType.VarChar)};
            classInfo[0].Value = ci.ID;
            classInfo[1].Value = ci.Grade;
            classInfo[2].Value = ci.Class;
            classInfo[3].Value = ci.Password;
            int result = InsertData(SQL_INSERT_CONTENT, classInfo);
            return result;
        }

        public static OleDbDataReader GetData(OleDbConnection connection, string sql, OleDbParameter cmdParm)
        {
            OleDbCommand oleCmd = new OleDbCommand(sql, connection);

            oleCmd.Parameters.Add(cmdParm);

            OleDbDataReader odr = oleCmd.ExecuteReader();
            return odr;
        }

        public ClassInfo GetCLassInfo(string id)
        {
            DBConnection dbconn = new DBConnection();
            OleDbConnection connection = dbconn.getConnection();
            connection.Open();

            ClassInfo ci = null;
            OleDbParameter classID = new OleDbParameter(PARM_ID, OleDbType.VarChar);
            classID.Value = id;
            using (OleDbDataReader odr = GetData(connection, SQL_SELECT_CONTENT, classID))
            {
                if (odr.Read())
                {
                    ci = new ClassInfo(odr.GetString(0), odr.GetInt32(1), odr.GetInt32(2), odr.GetString(3));
                }
            }
            if (connection != null)
            {
                connection.Close();
            }
            return ci;
        }

        public int UpdateGrade() {
            DBConnection dbconn = new DBConnection();
            OleDbConnection connection = dbconn.getConnection();
            connection.Open();
            OleDbCommand oleCmd = new OleDbCommand(SQL_UPDATE_GRADE, connection);
            int result = oleCmd.ExecuteNonQuery();
            if (connection != null) 
            {
                connection.Close();
            }
            return result;
        }

        public int UpdateInfo(string classID, string password)
        {

            DBConnection dbconn = new DBConnection();
            OleDbConnection connection = dbconn.getConnection();
            connection.Open();
            OleDbParameter[] pw = new OleDbParameter[] { new OleDbParameter(PARM_ID, OleDbType.VarChar), new OleDbParameter(PARM_PASSWORD, OleDbType.VarChar) };
            pw[0].Value = classID;
            pw[1].Value = password;
            OleDbCommand oleCmd = new OleDbCommand(SQL_UPDATE_CONTENT, connection);
            oleCmd.Parameters.AddWithValue("@password", pw[1].Value);
            oleCmd.Parameters.AddWithValue("@classID", pw[0].Value);
            int result = oleCmd.ExecuteNonQuery();
            if (connection != null)
            {
                connection.Close();
            }
            return result;
        }

        public int DeleteOutOfDateClass()
        {
            DBConnection dbconn = new DBConnection();
            OleDbConnection connection = dbconn.getConnection();
            connection.Open();
            OleDbCommand oleCmd = new OleDbCommand(SQL_DELETE_CLASS, connection);
            int result = oleCmd.ExecuteNonQuery();
            if(connection != null)
            {
                connection.Close();
            }
            return result;
        }

        public int GetClassNum()
        {
            DBConnection dbconn = new DBConnection();
            OleDbConnection connection = dbconn.getConnection();
            connection.Open();
            OleDbCommand oleCmd = new OleDbCommand(SQL_CLASS_NUM, connection);
            OleDbDataReader odr = oleCmd.ExecuteReader();
            int count = 0;
            while(odr.Read())
            {
                count = count + 1;
            }
            return count;
        }
    }
}