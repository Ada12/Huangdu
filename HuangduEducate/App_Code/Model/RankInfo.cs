using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
///RankInfo 的摘要说明
/// </summary>
namespace Model
{
    public class RankInfo
    {
        private string _ID;
        private int _week;
        private int[] _one;
        private int[] _two;
        private int[] _three;
        private int[] _four;
        private int[] _five;

        public RankInfo()
        {
        }

        public RankInfo(string my_classID, int my_week, int[] my_one, int[] my_two, int[] my_three, int[] my_four, int[] my_five)
        {
            this._ID = my_classID;
            this._week = my_week;
            this._one = my_one;
            this._two = my_two;
            this._three = my_three;
            this._four = my_four;
            this._five = my_five;
        }

        public string ID
        {
            get { return this._ID; }
        }

        public int Week
        {
            get { return this._week; }
        }

        public int[] One
        {
            get { return this._one; }
        }

        public int[] Two
        {
            get { return this._two; }
        }

        public int[] Three
        {
            get { return this._three; }
        }

        public int[] Four
        {
            get { return this._four; }
        }

        public int[] Five
        {
            get { return this._five; }
        }
    }
}