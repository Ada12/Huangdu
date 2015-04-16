using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using AccessDAL;


/// <summary>
///
/// </summary>
namespace BLL
{
    public class LevelStructure
    {
        public List<LevelStructureInfo> getLevelStructureInfoAll()
        {
            HDLevelStructure hdls = new HDLevelStructure();
            List<LevelStructureInfo> lvsstlist = hdls.GetLevelInfoALL();
            lvsstlist.Sort(LevelStructure.comparetLevelStructureByPosition);
            return lvsstlist;
        }

        public List<LevelStructureInfo> getLevelStructurreInfoSimple()
        {
            HDLevelStructure hdls = new HDLevelStructure();
            List<LevelStructureInfo> lvsstlist = hdls.GetLevelStructureSimple();
            lvsstlist.Sort(LevelStructure.comparetLevelStructureByPosition);
            return lvsstlist;
        }

        public int updateLevelInfo(LevelStructureInfo lsi, int level)
        {
            HDLevelStructure hdls = new HDLevelStructure();
            return hdls.UpdateLevelInfo(lsi, level);
        }

        public int addItem(string item, string subitem)
        {
            HDLevelStructure hdls = new HDLevelStructure();
            return hdls.SetLevelInfo(item, subitem);
        }

        public int addItem(LevelStructureInfo lsi)
        {
            HDLevelStructure hdls = new HDLevelStructure();
            return hdls.SetLevelInfo(lsi);
        }

        public int deleteItem(string item, string subitem)
        {
            HDLevelStructure hdls = new HDLevelStructure();
            return hdls.delete(item, subitem);
        }

        public int deleteItem(int iposition)
        {
            HDLevelStructure hdls = new HDLevelStructure();
            return hdls.delete(iposition);
        }

        public LevelStructure()
        {
        }

        static public int comparetLevelStructureByName(LevelStructureInfo lvix, LevelStructureInfo lviy)
        {
            int step1 = QYDCompare.stringCompare(lvix.Iterm, lviy.Iterm);
            if (step1 != 0)
            {
                return step1;
            }
            else
            {
                return QYDCompare.stringCompare(lvix.Subiterm, lviy.Subiterm);
            }
        }

        static public int comparetLevelStructureByPosition(LevelStructureInfo lvix, LevelStructureInfo lviy)
        {
            if (lvix.Position > lviy.Position)
            {
                return 1;
            }
            if (lvix.Position < lviy.Position)
            {
                return -1;
            }
            return 0;
        }

        static public int maxPosition(List<LevelStructureInfo> lvs)
        {
            if (lvs == null)
            {
                return -2;
            }
            if (lvs.Count == 0)
            {
                return -1;
            }
            int maxp = int.MinValue;
            foreach (LevelStructureInfo lvi in lvs)
            {
                maxp = Math.Max(lvi.Position, maxp);
            }
            return maxp;
        }
    }
}