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

        public string ID
        {
            get { return _ID; }
        }
        private int _Week;

        public int Week
        {
            get { return _Week; }
        }
        private int _Chinese;

        public int Chiness
        {
            get { return _Chinese; }
        }
        private int _Math;

        public int Math
        {
            get { return _Math; }
        }
        private int _English;

        public int English
        {
            get { return _English; }
        }

        public GradeInfo(string id,int week,int chinese,int math,int english)
        {
            this._ID = id;
            this._Week = week;
            this._Chinese = chinese;
            this._Math = math;
            this._English = english;
        }
        
    }
}