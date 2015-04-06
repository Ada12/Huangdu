using System;
/// <summary>
///GradeInfo 的摘要说明
/// </summary>
/// 
namespace Model
{
    public class GradeInfo
    {
        private string _ID;
        private int _Week;
        private string _Chinese;
        private string _Math;
        private string _English;

        public GradeInfo()
        { 
        }

        public GradeInfo(string my_id, int my_week, string my_chinese, string my_math, string my_english) 
        {
            this._ID = my_id;
            this._Week = my_week;
            this._Chinese = my_chinese;
            this._Math = my_math;
            this._English = my_english;
        }

        public string ID
        {
            get { return this._ID; }
        }

        public int Week
        {
            get { return this._Week; }
        }

        public string Chinese
        {
            get { return this._Chinese; }
        }

        public string Math
        {
            get { return this._Math; }
        }

        public string English
        {
            get { return this._English; }
        }
    }
}