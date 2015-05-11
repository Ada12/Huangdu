using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AccessDAL;
using System.Data;

/// <summary>
///File 的摘要说明
/// </summary>
/// 
namespace BLL
{
    public class MyFile
    {
        public DataTable GetDataFromExcelWithAppointSheetName(string path)
        {
            HDFile hf = new HDFile();
            DataTable dt = hf.GetDataFromExcelWithAppointSheetName(path);
            return dt;
        }

        public bool insertData(DataTable dt)
        {
            HDFile hf = new HDFile();
            bool result = hf.insertData(dt);
            return result;
        }
    }
}