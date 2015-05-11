using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.OleDb;
using Model;

/// <summary>
///HDRank 的摘要说明
/// </summary>
namespace AccessDAL
{
    public class HDRank
    {

        private const string PARM_ID = "@studentID";
        private const string PARM_NAME = "@name";
        private const string PARM_CLASS_NUM = "@class_num";
        private const string PARM_WEEK = "@week";

        private const string SQL_SELECT_CONTENT = "select studentID, name, class_num from student where class_num = @class_num ";
        private const string SQL_SELECT_GRADE = "select week, chinese, math, english from grade where ID = @studentID";
        private const string SQL_SELECT_WEEK = "SELECT week FROM grade ORDER BY week DESC";
        //   private const string SQL_SELECT_CONTENT_BY_CLASS = "select studentID, name, class_num from student where class_num = @class_num;";
        // private const string SQL_INSERT_CONTENT_BY_ID = "insert into student(studentID, name, class_num ) values (@studentID, @name, @class_num);";

        public static OleDbDataReader GetData(string sql, OleDbParameter cmdParm, OleDbConnection connection)
        {
            OleDbCommand oleCmd = new OleDbCommand(sql, connection);
            oleCmd.Parameters.Add(cmdParm);
            OleDbDataReader odr = oleCmd.ExecuteReader();
            return odr;
        }
        public List<StudentInfo> getAllStudents(string classNum)
        {
            OleDbParameter cn = new OleDbParameter(PARM_CLASS_NUM, OleDbType.VarChar);
            cn.Value = classNum;
            OleDbConnection oledbc = (new DBConnection()).getConnection();
            oledbc.Open();
            OleDbDataReader odr = GetData(SQL_SELECT_CONTENT, cn, oledbc);
            List<StudentInfo> lsi = new List<StudentInfo>();
            while(odr.Read()){
                StudentInfo si = new StudentInfo(odr.GetString(0), odr.GetString(1), odr.GetString(2));
                lsi.Add(si);
            }
            oledbc.Close();
            return lsi;
        }

        public List<GradeInfo> getAllGrade(List<StudentInfo> lsi) 
        {
            //lsi[0].ID
            
            List<GradeInfo> lgi = new List<GradeInfo>();
            OleDbConnection oledbc = (new DBConnection()).getConnection();
            oledbc.Open();
            for (int i = 0; i < lsi.Count(); i++ )
            {
                OleDbParameter studentId = new OleDbParameter(PARM_ID, OleDbType.VarChar);
                studentId.Value = lsi[i].ID;
                OleDbDataReader odr = GetData(SQL_SELECT_GRADE, studentId, oledbc);
                while(odr.Read())
                {
                    GradeInfo gi = new GradeInfo(lsi[i].ID, odr.GetInt32(0), odr.GetString(1), odr.GetString(2), odr.GetString(3));
                    lgi.Add(gi);
                }
            }
            return lgi;
        }

        public RankInfo getGradeRank(string classNum) 
        {
            HDGrade hg = new HDGrade();
            List<StudentInfo> lsi = getAllStudents(classNum);
            List<string> ids = new List<string>();
            for (int i = 0; i < lsi.Count(); i++)
            {
                string id = lsi[i].ID;
                ids.Add(id);
            }
            List<GradeInfo> lgiCount = hg.GetGradeInfo(ids, 1);
            List<RankInfo> lri = new List<RankInfo>();
            int count = lgiCount[0].Chinese.Count();
            int[] onePoint = new int[3 * count];
            int[] twoPoint = new int[3 * count];
            int[] threePoint = new int[3 * count];
            int[] fourPoint = new int[3 * count];
            int[] fivePoint = new int[3 * count];
            for (int i = 0; i < 3 * count; i++)
            {
                onePoint[i] = 0;
                twoPoint[i] = 0;
                threePoint[i] = 0;
                fourPoint[i] = 0;
                fivePoint[i] = 0;
            }
            int hightestWeek = getHighestWeek();
            for (int w = 1; w < hightestWeek+1; w++)
            {
                List<GradeInfo> lgi = hg.GetGradeInfo(ids, w);
                for (int j = 0; j < lgi.Count(); j++)
                {
                    for (int k = 0; k < 3 * count; k++)
                    {
                        int result;
                        if (k < count)
                        {
                            result = Int32.Parse(lgi[j].Chinese.Substring(k, 1));
                        }
                        else if ((k > count - 1) && (k < 2 * count))
                        {
                            result = Int32.Parse(lgi[j].Math.Substring(k % count, 1));
                        }
                        else
                        {
                            result = Int32.Parse(lgi[j].English.Substring(k % count, 1));
                        }
                        switch (result)
                        {
                            case 1: onePoint[k]++;
                                break;
                            case 2: twoPoint[k]++;
                                break;
                            case 3: threePoint[k]++;
                                break;
                            case 4: fourPoint[k]++;
                                break;
                            case 5: fivePoint[k]++;
                                break;
                        }

                    }
                }
                RankInfo ri = new RankInfo(classNum, w, onePoint, twoPoint, threePoint, fourPoint, fivePoint);
                lri.Add(ri);
            }
            if (lri.Count() == 0)
            {
                    int[] t1 = new int[3 * count];
                    int[] t2 = new int[3 * count];
                    int[] t3 = new int[3 * count];
                    int[] t4 = new int[3 * count];
                    int[] t5 = new int[3 * count];

                    for (int tt = 0; tt < 3 * count; tt++)
                    {
                        t1[tt] = 0;
                        t2[tt] = 0;
                        t3[tt] = 0;
                        t4[tt] = 0;
                        t5[tt] = 0;
                    }
                    RankInfo testAvg = new RankInfo(classNum, 1, t1, t2, t3, t4, t5);
                    return testAvg;
            }
            int len = lri[0].One.Count();
            int[] oneAvg = new int[len];
            int[] twoAvg = new int[len];
            int[] threeAvg = new int[len];
            int[] fourAvg = new int[len];
            int[] fiveAvg = new int[len];
            for (int i = 0; i < len; i++)
            {
                oneAvg[i] = 0;
                twoAvg[i] = 0;
                threeAvg[i] = 0;
                fourAvg[i] = 0;
                fiveAvg[i] = 0;
            }
            for (int p = 0; p < len; p ++)
            {
                for(int n = 0; n < hightestWeek; n++)
                {
                    oneAvg[p] = oneAvg[p] + lri[n].One[p];
                    twoAvg[p] = twoAvg[p] + lri[n].Two[p];
                    threeAvg[p] = threeAvg[p] + lri[n].Three[p];
                    fourAvg[p] = fourAvg[p] + lri[n].Four[p];
                    fiveAvg[p] = fiveAvg[p] + lri[n].Five[p];
                }
            }
            for (int q = 0; q < len; q ++)
            {
                oneAvg[q] = oneAvg[q] / hightestWeek;
                twoAvg[q] = twoAvg[q] / hightestWeek;
                threeAvg[q] = threeAvg[q] / hightestWeek;
                fourAvg[q] = fourAvg[q] / hightestWeek;
                fiveAvg[q] = fiveAvg[q] / hightestWeek;
            }

            RankInfo riAvg = new RankInfo(classNum, 1, oneAvg, twoAvg, threeAvg, fourAvg, fiveAvg);
            return riAvg;
        }

        public int getHighestWeek()
        {
            DBConnection dbconn = new DBConnection();
            OleDbConnection connection = dbconn.getConnection();
            connection.Open();
            OleDbCommand oleCmd = new OleDbCommand(SQL_SELECT_WEEK, connection);
            OleDbDataReader odr = oleCmd.ExecuteReader();
            int hightWeek = 0;
            if(odr.Read()){
                hightWeek = odr.GetInt32(0);
            }
            return hightWeek;
        }

        
    }
}