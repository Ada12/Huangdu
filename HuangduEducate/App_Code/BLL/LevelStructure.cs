using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Model;
using AccessDAL;


/// <summary>
///
/// </summary>
public class LevelStructure
{
    public List<LevelStructureInfo> getLevelStructureInfoAll()
    {
        HDLevelStructure hdls = new HDLevelStructure();
        return hdls.GetLevelInfoALL();
    }

    public List<LevelStructureInfo> getLevelStructurreInfoSimple()
    {
        HDLevelStructure hdls = new HDLevelStructure();
        List<LevelStructureInfo> lvsstlist= hdls.GetLevelStructureSimple();
        lvsstlist.Sort(this.comparetLevelStructure);
        return lvsstlist;
    }

    public int updateLevelInfo(LevelStructureInfo lsi,int level)
    {
        HDLevelStructure hdls = new HDLevelStructure();
        return hdls.UpdateLevelInfo(lsi, level);
    }

    public int addItemTitle(string item, string subitem)
    {
        HDLevelStructure hdls = new HDLevelStructure();
        return hdls.SetLevelInfo(item, subitem);
    }

    public int addItemWhole(LevelStructureInfo lsi)
    {
        HDLevelStructure hdls = new HDLevelStructure();
        return hdls.SetLevelInfo(lsi);
    }

	public LevelStructure()
	{
	}

    public int comparetLevelStructure(LevelStructureInfo lvix,LevelStructureInfo lviy)
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