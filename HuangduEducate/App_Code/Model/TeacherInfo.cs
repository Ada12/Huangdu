using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///TeacherInfo 的摘要说明
/// </summary>

namespace Model
{
    public class TeacherInfo
    {
        private string _ID;
        private string _Name;
        private string _Password;

        public TeacherInfo()
        {
        }

        public TeacherInfo(string my_id, string my_name, string my_password)
        {
            this._ID = my_id;
            this._Name = my_name;
            this._Password = my_password;
        }

        public string ID
        {
            get { return _ID; }
        }

        public string Name
        {
            get { return _Name; }
        }

        public string Password
        {
            get { return _Password; }
        }
    }
}