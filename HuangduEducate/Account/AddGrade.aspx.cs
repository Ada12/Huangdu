using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;


public partial class Account_AddGrade : System.Web.UI.Page
{

    private List<LevelStructureInfo> levelstructureInfoList; 

    protected void Page_Load(object sender, EventArgs e)
    {
        levelstructureInfoList = new List<LevelStructureInfo>();
        string classID = "";
        try
        {
            classID = Session["HDClassID"].ToString();
        }
        catch (Exception excep)
        {
            excep.ToString();
            Server.Transfer("ClassLogin.aspx");
        }
        if(classID != "")
        {
            Student hdstd = new Student();
            LevelStructure lvstr=new LevelStructure();
            List<StudentInfo> stdlist = hdstd.getStudentList(classID);
            this.levelstructureInfoList = lvstr.getLevelStructurreInfoSimple();
            string previousStr = "";
            TableHeaderCell tbc00 = new TableHeaderCell();
            foreach (LevelStructureInfo lvstri in this.levelstructureInfoList)
            {
                if (previousStr == lvstri.Iterm)
                {
                    tbc00.ColumnSpan += 1;
                }
                else
                {
                    TableHeaderCell tbc01 = new TableHeaderCell();
                    tbc00 = tbc01;
                    tbc00.ColumnSpan = 1;
                    tbc01.Text = lvstri.Iterm;
                    previousStr = tbc01.Text;
                    classHeaderRow1.Cells.Add(tbc01);
                }


                TableHeaderCell tbc02 = new TableHeaderCell();
                tbc02.Text = lvstri.Subiterm;
                classHeaderRow2.Cells.Add(tbc02);
            }

            int itemNum = levelstructureInfoList.Count;
            foreach (StudentInfo stdif in stdlist)
            {
                TableRow tbr = new TableRow();
                TableCell tbc1 = new TableCell();
                TableCell tbc2 = new TableCell();
                tbc1.Text = stdif.ID;
                tbc2.Text = stdif.Name;
                tbr.Cells.Add(tbc1);
                tbr.Cells.Add(tbc2);

                for (int icounter = 0; icounter < itemNum; icounter++)
                {
                    TableCell tbc3n = new TableCell();
                    DropDownList ddl=new DropDownList();
                    ddl.Items.Add(new ListItem("1","1"));
                    ddl.Items.Add(new ListItem("2","2"));
                    ddl.Items.Add(new ListItem("3","3"));
                    ddl.Items.Add(new ListItem("4","4"));
                    ddl.Items.Add(new ListItem("5","5"));
                    tbc3n.Controls.Add(ddl);
                    tbr.Cells.Add(tbc3n);
                }
                
                classListTable.Rows.Add(tbr);
                
            }

        }
    }

    protected void logoffBtn_Click(object sender, EventArgs e)
    {
        Session["HDClassID"] = null;
        ClearClientPageCache();
        Response.Redirect("main.aspx");
    }

    protected void ClearClientPageCache()
    {
        Response.Buffer = true;
        Response.ExpiresAbsolute = DateTime.Now.AddDays(-1);
        Response.Cache.SetExpires(DateTime.Now.AddDays(-1));
        Response.Expires = 0;
        Response.CacheControl = "no-cache";
        Response.Cache.SetNoStore();
    }

    protected void submitBtn_Click(object sender, EventArgs e)
    {
        
    }
}