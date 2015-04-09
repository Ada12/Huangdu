using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class Account_Test : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        LevelStructure lvStrctr = new LevelStructure();
        List<LevelStructureInfo> lsiList=lvStrctr.getLevelStructureInfoAll();
        foreach (LevelStructureInfo lsi in lsiList)
        {
            string[] strlst = lsi.toStringToShow();
            TableRow tbr = new TableRow();
            foreach (string str in strlst)
            {
                TableCell tbcl = new TableCell();
                tbcl.Text = str;
                tbr.Cells.Add(tbcl);
            }
            testTB1.Rows.Add(tbr);
            
        }
        AccessDAL.HDTest tt = new AccessDAL.HDTest();
        tt.run();
    }

    protected void addLevelStructure(object sender, EventArgs e)
    {
        LevelStructure lvStrctr = new LevelStructure();
        string[] fivetoone = new string[]{fiveTextBox.Text,fourTextBox.Text,
            threeTextBox.Text,twoTextBox.Text,oneTextBox.Text};
        LevelStructureInfo lsi= new LevelStructureInfo(itemTextBox.Text,subitemTextBox.Text,-1,fivetoone);
        toshow.Text = lvStrctr.addItemWhole(lsi).ToString();
    }
}