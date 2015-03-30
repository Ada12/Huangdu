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


        public static OleDbDataReader GetData(string sql, OleDbParameter cmdParm)
        {
            DBConnection dbconn = new DBConnection();
            OleDbConnection connection = dbconn.getConnection();
            connection.Open();
            OleDbCommand oleCmd = new OleDbCommand(sql, connection);

            oleCmd.Parameters.Add(cmdParm);

            OleDbDataReader odr = oleCmd.ExecuteReader();
            return odr;
        }

        public AdminInfo GetAdminInfo(string id)
        {
            AdminInfo ti = null;
            OleDbParameter adminInfo = new OleDbParameter(PARM_ID, OleDbType.VarChar);
            adminInfo.Value = id;
            using (OleDbDataReader odr = GetData(SQL_SELECT_CONTENT, adminInfo))
            {
                if (odr.Read())
                {
                    ti = new AdminInfo(odr.GetString(0), odr.GetString(1));
                }
            }
            return ti;
        }


    }
}
