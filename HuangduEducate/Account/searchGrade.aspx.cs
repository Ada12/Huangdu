using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using System.Data;

public partial class search_search : System.Web.UI.Page
{
    private string studentID;
    private string studentName;
    private List<GradeInfo> searchResult;
    private List<LevelStructureInfo> levelstructureInfoList;
    public const string SessioIDForLevelStructure = "HDSearchGradeLevelStructure";
    public const string SessioIDForLevelGrades = "HDSearchGradeGrades";

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            studentID = Session["huangdueducateid"].ToString();
            studentName = Session["huangdueducatename"].ToString();
        }
        catch (Exception exception1)
        {
            exception1.ToString();
            Server.Transfer("StudentLogin.aspx");
            return;
        }
        this.initialTables();
        this.fillCharts();

        
    }

    protected void logoffBtn_Click(object sender, EventArgs e)
    {
        Session["huangdueducateid"] = null;
        Session["huangdueducatename"] = null;
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

    private void initialTables()
    {
        titleTable.Rows[0].Cells[1].Text = studentID;
        titleTable.Rows[1].Cells[1].Text = studentName;

        #region addLevestructure
        if (Page.IsPostBack)
        {
            this.levelstructureInfoList = (List<LevelStructureInfo>)Session[SessioIDForLevelStructure];
        }
        else
        {
            LevelStructure lvstr = new LevelStructure();
            this.levelstructureInfoList = lvstr.getLevelStructurreInfoSimple();
            Session.Remove(SessioIDForLevelStructure);
            Session.Add(SessioIDForLevelStructure, this.levelstructureInfoList);
        }

        for (int icSubject = 0; icSubject < 3; icSubject++)
        {
            TableRow HeaderRow1 = (TableRow)this.FindControl("gradeHeaderRow" + (2 * icSubject).ToString());
            TableRow HeaderRow2 = (TableRow)this.FindControl("gradeHeaderRow" + (2 * icSubject + 1).ToString());
            string previousStr = "";
            HeaderRow1.Cells.Clear();
            HeaderRow2.Cells.Clear();
            HeaderRow1.EnableViewState = false;//若设为true则column的值会累加
            HeaderRow2.EnableViewState = false;//有了asp:UpdatePanel之后，这两句应该没用了吧，写于上一条注释二十四小时候，rzc怨念中，没错，我就是下文出现的那个变量
            TableHeaderCell IDcell = new TableHeaderCell();
            TableHeaderCell namecell = new TableHeaderCell();
            IDcell.Text = "学号";
            namecell.Text = "姓名";
            IDcell.RowSpan = 2;
            namecell.RowSpan = 2;
            HeaderRow1.Cells.Add(IDcell);
            HeaderRow1.Cells.Add(namecell);
            TableHeaderCell tbc00 = new TableHeaderCell();
            for (int icounter = 0; icounter < this.levelstructureInfoList.Count; ++icounter)
            {
                LevelStructureInfo lvstri = this.levelstructureInfoList[icounter];

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
                    HeaderRow1.Cells.Add(tbc01);
                }


                TableHeaderCell tbc02 = new TableHeaderCell();
                tbc02.Text = lvstri.Subiterm;
                HeaderRow2.Cells.Add(tbc02);
            }
        }
        #endregion
    }

    void fillCharts()
    {
        #region previous code
        /*
        string[] titles = { "语文成绩","数学成绩","英语成绩"};
        DataTable[] GradesDT =new DataTable[3];
        int isubjects=0;
        for(isubjects=0;isubjects<3;isubjects++)
        {
            GradesDT[isubjects]=new DataTable();
            GradesDT[isubjects].Columns.Add("week");
            GradesDT[isubjects].Columns.Add("grade");
        }

        //this.searchResult.Sort
        for (int iweek = 0; iweek < this.searchResult.Count; ++iweek)
        {
            if (searchResult[iweek].Chinese == null &&
                searchResult[iweek].Math == null &&
                searchResult[iweek].English == null)
            {
                continue;
            }
            String [] gradesSingleRow=new String[3];
            gradesSingleRow[0]=searchResult[iweek].Chinese;
            gradesSingleRow[1]=searchResult[iweek].Math;
            gradesSingleRow[2]=searchResult[iweek].English;
            for(isubjects=0;isubjects<3;isubjects++)
            {
                if (gradesSingleRow[isubjects] == null )
                {
                    continue;
                }

                DataRow dtr=GradesDT[isubjects].NewRow();
                dtr["week"] = searchResult[iweek].Week;
                dtr["grade"] = gradesSingleRow[isubjects];
                GradesDT[isubjects].Rows.Add(dtr);
            }
        }
        System.Web.UI.DataVisualization.Charting.Chart[] charts=new System.Web.UI.DataVisualization.Charting.Chart[3];
        charts[0] = ChartChinese;
        charts[1] = ChartMath;
        charts[2] = ChartEnglish;

        for (isubjects = 0; isubjects < 3; isubjects++)
        {
            charts[isubjects].Titles[0].Text = titles[isubjects];
            charts[isubjects].DataSource = GradesDT[isubjects];
            charts[isubjects].Series[0].XValueMember = "week";
            charts[isubjects].Series[0].YValueMembers = "grade";
            charts[isubjects].ChartAreas[0].AxisX.Title = "星期";
            charts[isubjects].ChartAreas[0].AxisX.TitleAlignment = System.Drawing.StringAlignment.Far;
            charts[isubjects].ChartAreas[0].AxisY.Title = "成绩";
            charts[isubjects].ChartAreas[0].AxisY.TitleAlignment = System.Drawing.StringAlignment.Far;
            charts[isubjects].ChartAreas[0].AxisX.Interval = 1;
            ///charts[isubjects].ChartAreas[0].AxisY.Interval = 1;
            charts[isubjects].ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;//不显示竖着的分割线
            charts[isubjects].Series[0].IsValueShownAsLabel = true;//显示坐标值
        }*/
        #endregion
        Table tableen = (Table)this.FindControl("englishGradeTable");
        Table tablecn = (Table)this.FindControl("chineseGradeTable");
        Table tablemt = (Table)this.FindControl("mathGradeTable");
        
        if (Page.IsPostBack)
        {
            searchResult = (List<GradeInfo>)Session[SessioIDForLevelGrades];
        }
        else
        {
            Grade grade = new Grade();
            searchResult = grade.GetGradeInfoList(studentID);
            Session.Remove(SessioIDForLevelGrades);
            Session.Add(SessioIDForLevelGrades, searchResult);
        }
        for (int icounter1 = 0; icounter1 < searchResult.Count; icounter1++)
        {
            TableRow tbrcn = new TableRow(), tbrmt = new TableRow(), tbren = new TableRow();
            GradeInfo gi = searchResult[icounter1];
            if (gi.Chinese.Length >= levelstructureInfoList.Count)
            {
                TableCell idcell = new TableCell(), weekcell = new TableCell();
                idcell.Text = gi.ID;
                weekcell.Text = gi.Week.ToString();
                tbrcn.Cells.Add(idcell);
                tbrcn.Cells.Add(weekcell);
                for (int icounter2 = 0; icounter2 < levelstructureInfoList.Count; icounter2++)
                {
                    string prepare = gi.Chinese.Substring(icounter2, 1);
                    TableCell tbc = new TableCell();
                    tbc.Text = (prepare == "6" ? "" : prepare);
                    tbrcn.Cells.Add(tbc);
                }
            }
            if (gi.Math.Length >= levelstructureInfoList.Count)
            {
                TableCell idcell = new TableCell(), weekcell = new TableCell();
                idcell.Text = gi.ID;
                weekcell.Text = gi.Week.ToString();
                tbrmt.Cells.Add(idcell);
                tbrmt.Cells.Add(weekcell);
                for (int icounter2 = 0; icounter2 < levelstructureInfoList.Count; icounter2++)
                {
                    string prepare = gi.Math.Substring(icounter2, 1);
                    TableCell tbc = new TableCell();
                    tbc.Text = (prepare == "6" ? "" : prepare);
                    tbrmt.Cells.Add(tbc);
                }
            } 
            if (gi.English.Length >= levelstructureInfoList.Count)
            {
                TableCell idcell = new TableCell(), weekcell = new TableCell();
                idcell.Text = gi.ID;
                weekcell.Text = gi.Week.ToString();
                tbren.Cells.Add(idcell);
                tbren.Cells.Add(weekcell);
                for (int icounter2 = 0; icounter2 < levelstructureInfoList.Count; icounter2++)
                {
                    string prepare = gi.English.Substring(icounter2, 1);
                    TableCell tbc = new TableCell();
                    tbc.Text = (prepare == "6" ? "" : prepare);
                    tbren.Cells.Add(tbc);
                }
            }
            tablecn.Rows.Add(tbrcn);
            tablemt.Rows.Add(tbrmt);
            tableen.Rows.Add(tbren);
        }
        
    }
   
}