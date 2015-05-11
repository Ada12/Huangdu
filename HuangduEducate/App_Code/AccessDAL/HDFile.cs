using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using System.Data;

/// <summary>
///HDFile 的摘要说明
/// </summary>
namespace AccessDAL
{
    public class HDFile
    {
        //excel数据源 path为excel的路径
        public DataTable GetDataFromExcelWithAppointSheetName(string path) 
        {

            string strConn = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + path + ";" + "Extended Properties=Excel 8.0;";
            OleDbConnection conn = new OleDbConnection(strConn);
            conn.Open();
            //返回Excel的架构，包括各个sheet表的名称,类型，创建时间和修改时间等
            DataTable dtSheetName = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "Table" });
            //包含excel中表名的字符串数组
            string[] strTableNames = new string[dtSheetName.Rows.Count];
            for (int k = 0; k < dtSheetName.Rows.Count; k ++)
            {
                strTableNames[k] = dtSheetName.Rows[k]["TABLE_NAME"].ToString();//获取table sheet name
            }
            OleDbDataAdapter odr = null;
            DataTable dt = new DataTable();
            //从指定的表明查询数据,可先把所有表明列出来供用户选择
            string strExcel = "select * from [" + strTableNames[0] + "]";
            odr = new OleDbDataAdapter(strExcel, conn);
            dt = new DataTable();
            odr.Fill(dt);
            conn.Close();
            conn.Dispose();
            return dt;
        }


        //插入数据 dt为获取的excel，dataname为数据库名字
        public bool insertData(DataTable dt)
        {
            try
            {
                DBConnection dbconn = new DBConnection();
                OleDbConnection conn = dbconn.getConnection();
                conn.Open();
                string strSQL;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    strSQL = "INSERT INTO student VALUES (";
                    for (int k = 0; k < dt.Columns.Count; k++)
                    {
                        strSQL += "'" + dt.Rows[i][k].ToString() + "',";
                    }
                    strSQL = strSQL.Substring(0, strSQL.Length - 1);
                    strSQL += ")";
                    OleDbCommand oleCmd = new OleDbCommand(strSQL, conn);
                    oleCmd.ExecuteNonQuery();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
} 