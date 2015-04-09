using System;

/// <summary>
///contentInfo 的摘要说明
/// </summary>
namespace Model
{
    public class StudentInfo
    {
        private string _ID;
        private string _Name;
        private string _Class_Num;

        public StudentInfo() { }

        public StudentInfo(string my_id, string my_name, string my_class)
        {
            this._ID = my_id;
            this._Name = my_name;
            this._Class_Num = my_class;
        }

        public string ID
        {
            get { return _ID; }

        }

        public string Name
        {
            get { return _Name; }
        }

        public string ClassNum
        {
            get { return _Class_Num; }
        }
    }
}