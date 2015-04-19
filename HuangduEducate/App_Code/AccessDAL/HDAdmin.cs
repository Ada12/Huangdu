using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.OleDb;
using System.Web;
using Model;

/// <summary>
///HDAdmin 的摘要说明
/// </summary>
namespace AccessDAL
{
    public class HDAdmin
    {
        private const string PARM_ID = "@adminID";
        private const string PARM_PASSWORD = "@password";
        private const string SQL_SELECT_CONTENT = "select ID, password From admin Where ID = @adminID ";
        private const string SQL_UPDATE_CONTENT = "UPDATE [admin] SET [password] = @password WHERE [ID] = @adminID;";


        public static OleDbDataReader GetData(OleDbConnection connection, string sql, OleDbParameter cmdParm)
        {
            OleDbCommand oleCmd = new OleDbCommand(sql, connection);

            oleCmd.Parameters.Add(cmdParm);

            OleDbDataReader odr = oleCmd.ExecuteReader();
            return odr;
        }

        public AdminInfo GetAdminInfo(string id)
        {
            DBConnection dbconn = new DBConnection();
            OleDbConnection connection = dbconn.getConnection();
            connection.Open();

            AdminInfo ti = null;
            OleDbParameter adminInfo = new OleDbParameter(PARM_ID, OleDbType.VarChar);
            adminInfo.Value = id;
            using (OleDbDataReader odr = GetData(connection, SQL_SELECT_CONTENT, adminInfo))
            {
                if (odr.Read())
                {
                    ti = new AdminInfo(odr.GetString(0), odr.GetString(1));
                }
            }

            if (connection != null)
            {
                connection.Close();
            }
            return ti;
        }

        public int UpdateInfo(AdminInfo ai) {

            DBConnection dbconn = new DBConnection();
            OleDbConnection connection = dbconn.getConnection();
            connection.Open();
            OleDbParameter[] pw = new OleDbParameter[] { new OleDbParameter(PARM_ID, OleDbType.VarChar), new OleDbParameter(PARM_PASSWORD, OleDbType.VarChar) };
            pw[0].Value = ai.ID;
            pw[1].Value = ai.Password;
            OleDbCommand oleCmd = new OleDbCommand(SQL_UPDATE_CONTENT, connection);
            oleCmd.Parameters.AddWithValue("@password", pw[1].Value);
            oleCmd.Parameters.AddWithValue("@adminID", pw[0].Value);
            int result = oleCmd.ExecuteNonQuery();
            if (connection != null) 
            {
                connection.Close();
            }
            return result;
        } 
    }

}
