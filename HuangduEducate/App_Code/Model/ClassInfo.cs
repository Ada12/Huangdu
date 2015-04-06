using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///Class 的摘要说明
/// </summary>
namespace Model
{
    public class ClassInfo
    {
        private string _ID;
        private string _Password;
        private int _Grade;
        private int _Class;

        public ClassInfo()
        {

        }

        public ClassInfo(String my_id, int my_grade, int my_class, string my_password)
        {
            this._ID = my_id;
            this._Grade = my_grade;
            this._Class = my_class;
            this._Password = my_password;
        }

        public string ID
        {
            get { return _ID; }
        }

        public int Grade
        {
            get { return _Grade; }
        }

        public int Class
        {
            get { return _Class; }
        }

        public string Password
        {
            get { return _Password; }
        }
    }
}