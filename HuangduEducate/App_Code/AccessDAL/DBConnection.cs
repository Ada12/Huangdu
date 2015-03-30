using System;
using System.Data;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Data.OleDb;

/// <summary>
///DBConnection 的摘要说明
/// </summary>
namespace AccessDAL
{
    public class DBConnection
    {
        //从配置文件中得到数据库名称  
        public static readonly string access_con = ConfigurationManager.ConnectionStrings["access_con"].ConnectionString;
        //从配置文件中得到数据库驱动 
        public static readonly string access_path = ConfigurationManager.ConnectionStrings["access_path"].ConnectionString;
        //得到数据库连接字符串  
        public static readonly string DBConnectionString = access_con + HttpContext.Current.Server.MapPath(access_path);
        //建立数据库连接对象  
        private OleDbConnection OleDbConn = new OleDbConnection(DBConnectionString);//初始化数据库连接对象

        public DBConnection()
        {
            //
            //TODO: 在此处添加构造函数逻辑
            //
        }

        public OleDbConnection getConnection()
        {
            return OleDbConn;
        }
    }
}