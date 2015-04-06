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

        public static int InsertData(string sql, OleDbParameter[] cmdParms)
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
            int result = oleCmd.ExecuteNonQuery();
            if(connection != null)
            {
                connection.Close();
            }
            return result;
        }

        public static OleDbDataReader GetData(OleDbConnection connection, string sql, OleDbParameter cmdParm) {
            OleDbCommand oleCmd = new OleDbCommand(sql, connection);
            oleCmd.Parameters.Add(cmdParm);
            
            OleDbDataReader odr = oleCmd.ExecuteReader();
            return odr;
        }

        public List<GradeInfo> GetGradeInfoList(string id)
        {
            DBConnection dbconn = new DBConnection();
            OleDbConnection connection = dbconn.getConnection();
            connection.Open();

            List<GradeInfo> gi = new List<GradeInfo>();
            OleDbParameter gradeInfo = new OleDbParameter(PARM_ID, OleDbType.VarChar);
            gradeInfo.Value = id;
            OleDbDataReader odr = GetData(connection, SQL_SELECT_CONTENT, gradeInfo);
            while (odr.Read())
            {
                gi.Add(new GradeInfo(odr.GetString(0), odr.GetInt32(1), odr.GetString(2), odr.GetString(3), odr.GetString(4)));
            }
            if (connection != null)
            {
                connection.Close();
            }

            return gi;
        }

        public int SetGradeInfo(GradeInfo gi)
        {
            OleDbParameter[] gradeInfo = new OleDbParameter[] { new OleDbParameter(PARM_ID,OleDbType.VarChar),new OleDbParameter(PARM_WEEK, OleDbType.Integer),
                new OleDbParameter(PARM_CHINESE, OleDbType.VarChar),new OleDbParameter(PARM_MATH, OleDbType.VarChar),new OleDbParameter(PARM_ENGLISH, OleDbType.VarChar)};
            gradeInfo[0].Value = gi.ID;
            gradeInfo[1].Value = gi.Week;
            gradeInfo[2].Value = gi.Chinese;
            gradeInfo[3].Value = gi.Math;
            gradeInfo[4].Value = gi.English;
            int result = InsertData(SQL_INSERT_CONTENT, gradeInfo);
            return result;
        }


        public int UpdateInfo(GradeInfo gi, int c)
        {
            int result;
            if (c == 1)
            {
                OleDbParameter[] gradeInfo = new OleDbParameter[] { new OleDbParameter(PARM_CHINESE, OleDbType.Integer), new OleDbParameter(PARM_ID,OleDbType.VarChar),
                new OleDbParameter(PARM_WEEK, OleDbType.Integer)};
                gradeInfo[0].Value = gi.Chinese;
                gradeInfo[1].Value = gi.ID;
                gradeInfo[2].Value = gi.Week;
                result = InsertData(SQL_UPDATE_CHINSES, gradeInfo);
                return result;
            }
            else if(c == 2)
            {
                OleDbParameter[] gradeInfo = new OleDbParameter[] { new OleDbParameter(PARM_MATH, OleDbType.Integer), new OleDbParameter(PARM_ID,OleDbType.VarChar),
                new OleDbParameter(PARM_WEEK, OleDbType.Integer)};
                gradeInfo[0].Value = gi.Math;
                gradeInfo[1].Value = gi.ID;
                gradeInfo[2].Value = gi.Week;
                result = InsertData(SQL_UPDATE_MATH, gradeInfo);
                return result;
            }
            else
            {
                OleDbParameter[] gradeInfo = new OleDbParameter[] { new OleDbParameter(PARM_ENGLISH, OleDbType.Integer), new OleDbParameter(PARM_ID,OleDbType.VarChar),
                new OleDbParameter(PARM_WEEK, OleDbType.Integer)};
                gradeInfo[0].Value = gi.English;
                gradeInfo[1].Value = gi.ID;
                gradeInfo[2].Value = gi.Week;
                result = InsertData(SQL_UPDATE_ENGLISH, gradeInfo);
                return result;
            }
        }
    }
}