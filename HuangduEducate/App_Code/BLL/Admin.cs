using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AccessDAL;

/// <summary>
///Admin 的摘要说明
/// </summary>
namespace BLL
{
    public class Admin
    {
        public AdminInfo GetAdminInfo(string id)
        {
            HDAdmin ha = new HDAdmin();
            AdminInfo ai = new AdminInfo();
            ai = ha.GetAdminInfo(id);
            return ai;
        }
    }
}