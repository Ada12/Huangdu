using System;
using System.Data;
using System.Data.OleDb;
using System.Collections;
using Model;
using System.Collections.Generic;

/// <summary>
///Content 的摘要说明
/// </summary>
namespace AccessDAL
{
    public class HDGrade
    {
        private const string PARM_ID = "@ID";
        private const string PARM_WEEK = "@week";
        private const string PARM_CHINESE = "@chinese";
        private const string PARM_MATH = "@math";
        private const string PARM_ENGLISH = "@english";

        private const string SQL_SELECT_CONTENT = "select ID, week, chinese, math, english From grade Where ID = @ID ";
        private const string SQL_INSERT_CONTENT = "insert into grade (ID, week, chinese, math, english) values ('@ID', @week, @chinese, @math, @english);";

        private const string SQL_UPDATE_CHINSES = "UPDATE grade SET chinese = @chinese WHERE ID = @ID and week = @week ";
        private const string SQL_UPDATE_MATH = "UPDATE grade SET math = @math WHERE ID = @ID and week = @week ";
        private const string SQL_UPDATE_ENGLISH = "UPDATE grade SET english = @english WHERE ID = @ID and week = @week ";

        public static void InsertData(string sql, OleDbParameter[] cmdParms)
        {
            DBConnection dbconn = new DBConnection();
            OleDbConnection connection = dbconn.getConnection();
            connection.Open();
            OleDbCommand oleCmd = new OleDbCommand(sql, connection);
            if(cmdParms != null)
            {
                foreach(OleDbParameter parm in cmdParms)
                {
                    oleCmd.Parameters.Add(parm);
                }
            }
            oleCmd.ExecuteNonQuery();
            if(connection != null)
            {
                connection.Close();
            }
        }

        public static OleDbDataReader GetData(string sql, OleDbParameter cmdParm) {
            DBConnection dbconn = new DBConnection();
            OleDbConnection connection = dbconn.getConnection();
            connection.Open();
            OleDbCommand oleCmd = new OleDbCommand(sql, connection);
            oleCmd.Parameters.Add(cmdParm);
            
            OleDbDataReader odr = oleCmd.ExecuteReader();
            return odr;
        }

        public List<GradeInfo> GetGradeInfoList(string id)
        {

            List<GradeInfo> gi = new List<GradeInfo>();
            OleDbParameter gradeInfo = new OleDbParameter(PARM_ID, OleDbType.VarChar);
            gradeInfo.Value = id;
            OleDbDataReader odr = GetData(SQL_SELECT_CONTENT, gradeInfo);
            while (odr.Read())
            {
                gi.Add(new GradeInfo(odr.GetString(0), odr.GetInt32(1), odr.GetInt32(2), odr.GetInt32(3), odr.GetInt32(4)));
            }
            return gi;
        }

        public void SetGradeInfo(GradeInfo gi)
        {
            OleDbParameter[] gradeInfo = new OleDbParameter[] { new OleDbParameter(PARM_ID,OleDbType.VarChar),new OleDbParameter(PARM_WEEK, OleDbType.Integer),
                new OleDbParameter(PARM_CHINESE, OleDbType.Integer),new OleDbParameter(PARM_MATH, OleDbType.Integer),new OleDbParameter(PARM_ENGLISH, OleDbType.Integer)};
            gradeInfo[0].Value = gi.ID;
            gradeInfo[1].Value = gi.Week;
            gradeInfo[2].Value = gi.Chiness;
            gradeInfo[3].Value = gi.Math;
            gradeInfo[4].Value = gi.English;
            InsertData(SQL_INSERT_CONTENT, gradeInfo);
        }


        public void UpdateInfo(GradeInfo gi, int c)
        {
            if (c == 1)
            {
                OleDbParameter[] gradeInfo = new OleDbParameter[] { new OleDbParameter(PARM_CHINESE, OleDbType.Integer), new OleDbParameter(PARM_ID,OleDbType.VarChar),
                new OleDbParameter(PARM_WEEK, OleDbType.Integer)};
                gradeInfo[0].Value = gi.Chiness;
                gradeInfo[1].Value = gi.ID;
                gradeInfo[2].Value = gi.Week;
                InsertData(SQL_UPDATE_CHINSES, gradeInfo);
            }
            else if(c == 2)
            {
                OleDbParameter[] gradeInfo = new OleDbParameter[] { new OleDbParameter(PARM_MATH, OleDbType.Integer), new OleDbParameter(PARM_ID,OleDbType.VarChar),
                new OleDbParameter(PARM_WEEK, OleDbType.Integer)};
                gradeInfo[0].Value = gi.Math;
                gradeInfo[1].Value = gi.ID;
                gradeInfo[2].Value = gi.Week;
                InsertData(SQL_UPDATE_MATH, gradeInfo);
            }
            else
            {
                OleDbParameter[] gradeInfo = new OleDbParameter[] { new OleDbParameter(PARM_ENGLISH, OleDbType.Integer), new OleDbParameter(PARM_ID,OleDbType.VarChar),
                new OleDbParameter(PARM_WEEK, OleDbType.Integer)};
                gradeInfo[0].Value = gi.English;
                gradeInfo[1].Value = gi.ID;
                gradeInfo[2].Value = gi.Week;
                InsertData(SQL_UPDATE_ENGLISH, gradeInfo);
            }
        }
    }
}