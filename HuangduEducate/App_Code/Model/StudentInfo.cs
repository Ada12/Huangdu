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
        private int _Class;
        private int _Grade;

        public StudentInfo() { }

        public StudentInfo(string my_id, string my_name, int my_class, int my_grade)
        {
            this._ID = my_id;
            this._Name = my_name;
            this._Class = my_class;
            this._Grade = my_grade;
        }

        public string ID
        {
            get { return _ID; }
           
        }

        public string Name
        {
            get { return _Name; }
        }

        public int Class
        {
            get { return _Class; }
        }

        public int Grade
        {
            get { return _Grade; }
        }


    }
}