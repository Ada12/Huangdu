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
    public class HDLevelStructure
    {
        private const string PARM_ITEM = "@item";
        private const string PARM_SUBITEM = "@subitem";
        private const string PARM_POSITION = "@posit";
        private const string PARM_FIVE = "@five";
        private const string PARM_FOUR = "@four";
        private const string PARM_THREE = "@three";
        private const string PARM_TWO = "@two";
        private const string PARM_ONE = "@one";


        private const string SQL_SELECT_CONTENT_SIMPLE = "select item, subitem, posit From levelstructure";
        private const string SQL_SELECT_CONTENT_ALL = "select item, subitem, posit, five, four, three, two, one From levelstructure";
        private const string SQL_SELECT_CONTENT_ONE = "select * from levelstructure where item=@item and subitem=@subitem";
        // position 可能是数据库的保留字，故用posit代替
        private const string SQL_INSERT_CONTENT = "insert into levelstructure (item, subitem, posit) values (@item, @subitem ,@posit);";
        private const string SQL_UPDATE_FIVE = "update levelstructure set five = @five where item=@item and subitem=@subitem";
        private const string SQL_UPDATE_FOUR = "update levelstructure set four = @four where item=@item and subitem=@subitem";
        private const string SQL_UPDATE_THREE = "update levelstructure set three = @three where item=@item and subitem=@subitem";
        private const string SQL_UPDATE_TWO = "update levelstructure set two = @two where item=@item and subitem=@subitem";
        private const string SQL_UPDATE_ONE = "update levelstructure set one = @one where item=@item and subitem=@subitem";
        private const string SQL_UPDATE_ALL = "update levelstructure set five = @five, four = @four, three = @three, two = @two,one = @one where item = @item and subitem = @subitem";

        public int InsertData(string sql, OleDbParameter[] cmdParms, OleDbConnection connection)
        {
            int ret = -1;
            //DBConnection dbconn = new DBConnection();
            //OleDbConnection connection = dbconn.getConnection();
            //connection.Open();
            OleDbCommand oleCmd = new OleDbCommand(sql, connection);
            if(cmdParms != null)
            {
                foreach(OleDbParameter parm in cmdParms)
                {
                    oleCmd.Parameters.Add(parm);
                }
            }
            
            ret=oleCmd.ExecuteNonQuery();
            return ret;
        }
        
        public OleDbDataReader GetData(string sql, OleDbParameter[] cmdParms,OleDbConnection connection) {
            //DBConnection dbconn = new DBConnection();
            //OleDbConnection connection = dbconn.getConnection();
            //connection.Open();
            OleDbCommand oleCmd = new OleDbCommand(sql, connection);
            if (cmdParms != null)
            {
                foreach (OleDbParameter parm in cmdParms)
                {
                    oleCmd.Parameters.Add(parm);
                }
            }
            
            OleDbDataReader odr = oleCmd.ExecuteReader();
            return odr;

        }
        
        public List<LevelStructureInfo> GetLevelStructureSimple()
        {

            List<LevelStructureInfo> li = new List<LevelStructureInfo>();
            OleDbParameter[] sqlParams=new OleDbParameter[0];
            OleDbConnection oledbc = (new DBConnection()).getConnection();
            oledbc.Open();
            OleDbDataReader odr = GetData(SQL_SELECT_CONTENT_SIMPLE, sqlParams,oledbc);
            while (odr.Read())
            {
                li.Add(new LevelStructureInfo(odr.GetString(0), odr.GetString(1), odr.GetInt32(2)));
            }
            oledbc.Close();
            return li;
            
        }

        public List<LevelStructureInfo> GetLevelInfoALL()
        {
            List<LevelStructureInfo> li = new List<LevelStructureInfo>();
            OleDbParameter[] sqlParams = new OleDbParameter[0] ;
            OleDbConnection oledbcon = (new DBConnection()).getConnection();
            oledbcon.Open();
            OleDbDataReader odr = GetData(SQL_SELECT_CONTENT_ALL , sqlParams,oledbcon);
            while (odr.Read())
            {
                li.Add(new LevelStructureInfo(odr.GetString(0), odr.GetString(1), odr.GetInt32(2),
                    new string[5] { odr.GetString(3), odr.GetString(4), odr.GetString(5), odr.GetString(6), odr.GetString(7) }));
            }
            oledbcon.Close();
            return li;
        }

        public bool existItem(string item, string subitem)
        {
            OleDbConnection oledbcon = (new DBConnection()).getConnection();
            oledbcon.Open();
            OleDbParameter[] sqlParams = new OleDbParameter[2];
            sqlParams[0] = new OleDbParameter(PARM_ITEM, OleDbType.VarChar);
            sqlParams[1] = new OleDbParameter(PARM_SUBITEM, OleDbType.VarChar);
            sqlParams[0].Value = item;
            sqlParams[1].Value = subitem;
            OleDbDataReader odr = GetData(SQL_SELECT_CONTENT_ONE, sqlParams, oledbcon);
            bool result = false;
            if (odr.Read())
            {
                result = true;
            }
            oledbcon.Close();
            return result;
        }

        public int SetLevelInfo(string item,string subitem)
        {
            if (this.existItem(item, subitem))
            {
                return -2;
            }

            List<LevelStructureInfo> allCurrent=  this.GetLevelStructureSimple();
            HashSet<int> currentPosition = new HashSet<int>();
            int icount = 0;
            int maxPosition = -1;
            
            for (icount = 0; icount < allCurrent.Count; icount++)
            {
                currentPosition.Add(allCurrent[icount].Position);
                maxPosition = Math.Max(allCurrent[icount].Position, maxPosition);
            }
            int targetPosition = maxPosition + 1;
            for (icount = 0; icount < maxPosition; icount++)
            {
                if (!currentPosition.Contains(icount))
                {
                    targetPosition = icount;
                    break;
                }
            }
            
            OleDbParameter[] LevelInfoParams = new OleDbParameter[] { new OleDbParameter(PARM_ITEM, OleDbType.VarChar),
                new OleDbParameter(PARM_SUBITEM, OleDbType.VarChar), new OleDbParameter(PARM_POSITION, OleDbType.Integer) };
            LevelInfoParams[0].Value = item;
            LevelInfoParams[1].Value = subitem;
            LevelInfoParams[2].Value = targetPosition;
            OleDbConnection oledbcon = (new DBConnection()).getConnection();
            oledbcon.Open();
            int result=InsertData(SQL_INSERT_CONTENT, LevelInfoParams,oledbcon);
            oledbcon.Close();
            return result;
        }

        public int SetLevelInfo(LevelStructureInfo li)
        {
            int firststep=this.SetLevelInfo(li.Iterm, li.Subiterm);
            if (firststep > 0)
            {
                return this.UpdateLevelInfo(li, 0);
            }
            else
            {
                return firststep;
            }
        }

        public int UpdateLevelInfo(LevelStructureInfo lsi,int level)
        {
            string[] sqlCandidate = new string[6] {SQL_UPDATE_ALL,SQL_UPDATE_ONE,SQL_UPDATE_TWO,SQL_UPDATE_THREE,SQL_UPDATE_FOUR,SQL_UPDATE_FIVE };
            string[] paraCandidate = new string[6] { "", PARM_ONE, PARM_TWO, PARM_THREE, PARM_FOUR, PARM_FIVE };
            string[] paraValue = new string[6] { "", lsi.One, lsi.Two, lsi.Three, lsi.Four, lsi.Five };
            OleDbConnection oledbcon = (new DBConnection()).getConnection();
            oledbcon.Open();
            if (level>0 && level<6)
            {
                OleDbParameter[] sqlParams = new OleDbParameter[] { new OleDbParameter(paraCandidate[level], OleDbType.VarChar), 
                    new OleDbParameter(PARM_ITEM,OleDbType.VarChar),new OleDbParameter(PARM_SUBITEM, OleDbType.VarChar)};
                sqlParams[0].Value = (paraValue[level] == "" ? "empty" : paraValue[level]);
                sqlParams[1].Value = lsi.Iterm;
                sqlParams[2].Value = lsi.Subiterm;
                int result= InsertData(sqlCandidate[level], sqlParams,oledbcon);
                oledbcon.Close();
                return result;
            }
            else if (level == 0)
            {
                OleDbParameter[] sqlParams = new OleDbParameter[7];
                sqlParams[0] = new OleDbParameter(PARM_FIVE, OleDbType.VarChar);
                sqlParams[1] = new OleDbParameter(PARM_FOUR, OleDbType.VarChar);
                sqlParams[2] = new OleDbParameter(PARM_THREE, OleDbType.VarChar);
                sqlParams[3] = new OleDbParameter(PARM_TWO, OleDbType.VarChar);
                sqlParams[4] = new OleDbParameter(PARM_ONE, OleDbType.VarChar);
                sqlParams[5] = new OleDbParameter(PARM_ITEM, OleDbType.VarChar);
                sqlParams[6] = new OleDbParameter(PARM_SUBITEM, OleDbType.VarChar);
                sqlParams[0].Value = (lsi.Five == "" ? "empty" : lsi.Five);
                sqlParams[1].Value = (lsi.Four == "" ? "empty" : lsi.Four);
                sqlParams[2].Value = (lsi.Three == "" ? "empty" : lsi.Three);
                sqlParams[3].Value = (lsi.Two == "" ? "empty" : lsi.Two);
                sqlParams[4].Value = (lsi.One == "" ? "empty" : lsi.One);
                sqlParams[5].Value = lsi.Iterm;
                sqlParams[6].Value = lsi.Subiterm;
                int result= InsertData(SQL_UPDATE_ALL, sqlParams,oledbcon);
                oledbcon.Close();
                return result;
            }
            else 
            {
                oledbcon.Close();
                return -1;
            }
            
        }
    }
}