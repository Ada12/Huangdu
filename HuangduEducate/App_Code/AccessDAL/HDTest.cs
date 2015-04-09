using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
/// <summary>
///HDTest 的摘要说明
/// </summary>
namespace AccessDAL
{
    public class HDTest
    {
        public HDTest()
	    {
           
	    }
        public void run()
        {
            DBConnection dbc = new DBConnection();
            OleDbConnection oledbc = dbc.getConnection();
            oledbc.Open();
            OleDbCommand cmd = new OleDbCommand("select * from levelstructure;", oledbc);
            cmd.ExecuteReader();
            oledbc.Close();
        }
    }
}