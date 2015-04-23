using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using BLL;
using System.Data;
using System.Web.UI.DataVisualization.Charting;

public partial class search_search : System.Web.UI.Page
{
    private string studentID;
    private string studentName;
    private List<GradeInfo> searchResult;
    private List<LevelStructureInfo> levelstructureInfoList;
    public const string SessioIDForLevelStructure = "HDSearchGradeLevelStructure";
    public const string SessioIDForLevelGrades = "HDSearchGradeGrades";
    private List<LevelStructureInfo> llsi;

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
        this.drawLvs();
        this.initialTables();
        this.fillTables();
        this.drawCharts();
        
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
            namecell.Text = "周";
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

        for (int subject = 0; subject < 3; subject++)
        {
            TableRow HeaderRow3 = (TableRow)this.FindControl("rankHeaderRow" + (2 * subject).ToString());
            TableRow HeaderRow4 = (TableRow)this.FindControl("rankHeaderRow" + (2 * subject + 1).ToString());
            string previousStr1 = "";
            HeaderRow3.Cells.Clear();
            HeaderRow4.Cells.Clear();
            HeaderRow3.EnableViewState = false;
            HeaderRow4.EnableViewState = false;
            TableHeaderCell PointCell = new TableHeaderCell();
            PointCell.Text = "星级状态";
            PointCell.RowSpan = 2;
            HeaderRow3.Cells.Add(PointCell);
            TableHeaderCell t00 = new TableHeaderCell();
            for (int icounter1 = 0; icounter1 < this.levelstructureInfoList.Count; ++icounter1)
            {
                LevelStructureInfo lvstri1 = this.levelstructureInfoList[icounter1];
                if (previousStr1 == lvstri1.Iterm)
                {
                    t00.ColumnSpan += 1;
                }
                else
                {
                    TableHeaderCell t01 = new TableHeaderCell();
                    t00 = t01;
                    t00.ColumnSpan = 1;
                    t01.Text = lvstri1.Iterm;
                    previousStr1 = t01.Text;
                    HeaderRow3.Cells.Add(t01);
                }
                TableHeaderCell t02 = new TableHeaderCell();
                t02.Text = lvstri1.Subiterm;
                HeaderRow4.Cells.Add(t02);
            }
        }

        #endregion
    }

    void fillTables()
    {
        
        Table tableen = (Table)this.FindControl("englishGradeTable");
        Table tablecn = (Table)this.FindControl("chineseGradeTable");
        Table tablemt = (Table)this.FindControl("mathGradeTable");

        Table tablerkcn = (Table)this.FindControl("chineseRankTable");
        Table tablerkmt = (Table)this.FindControl("mathRankTable");
        Table tablerken = (Table)this.FindControl("englishRankTable");
        
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
                    tbc.Text = (prepare == "0" ? "" : prepare);
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
                    tbc.Text = (prepare == "0" ? "" : prepare);
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
                    tbc.Text = (prepare == "0" ? "" : prepare);
                    tbren.Cells.Add(tbc);
                }
            }
            tablecn.Rows.Add(tbrcn);
            tablemt.Rows.Add(tbrmt);
            tableen.Rows.Add(tbren);
        }

        Rank rank = new Rank();
        RankInfo ri = new RankInfo();
        Student s = new Student();
        StudentInfo si = new StudentInfo();
        si = s.GetStudentInfo(studentID);
        ri = rank.getGradeRank(si.ClassNum);
        List<int[]> lri = new List<int[]>();
        lri.Add(ri.One);
        lri.Add(ri.Two);
        lri.Add(ri.Three);
        lri.Add(ri.Four);
        lri.Add(ri.Five);
        for (int icounter2 = 0; icounter2 < 5; icounter2++)
        {
            TableRow tbr1cn = new TableRow();
            TableRow tbr1mt = new TableRow();
            TableRow tbr1en = new TableRow();
            TableCell PointCell1 = new TableCell();
            TableCell PointCell2 = new TableCell();
            TableCell PointCell3 = new TableCell();
            string[] star = {};
            //PointCell1.Text = (icounter2 + 1).ToString() + "分人数";
            PointCell1.ID = "chinese"+ icounter2 + "pic";
            tbr1cn.Cells.Add(PointCell1);
            for (int icounter3 = 0; icounter3 < levelstructureInfoList.Count; icounter3 ++)
            {
                int prepare1 = lri[icounter2][icounter3];
                TableCell tbc1 = new TableCell();
                tbc1.Text = prepare1.ToString();
                tbr1cn.Cells.Add(tbc1);
            }
            //PointCell2.Text = (icounter2 + 1).ToString() + "分人数";
            PointCell2.ID = "math" + icounter2 +"pic";
            tbr1mt.Cells.Add(PointCell2);
            for (int icounter4 = levelstructureInfoList.Count; icounter4 < 2 * levelstructureInfoList.Count; icounter4 ++)
            {
                int prepare2 = lri[icounter2][icounter4];
                TableCell tbc2 = new TableCell();
                tbc2.Text = prepare2.ToString();
                tbr1mt.Cells.Add(tbc2);
            }
            //PointCell3.Text = (icounter2 + 1).ToString() + "分人数";
            PointCell3.ID = "english" + icounter2 + "pic";
            tbr1en.Cells.Add(PointCell3);
            for (int icounter5 = 2 * levelstructureInfoList.Count; icounter5 < 3 * levelstructureInfoList.Count; icounter5 ++)
            {
                int prepare3 = lri[icounter2][icounter5];
                TableCell tbc3 = new TableCell();
                tbc3.Text = prepare3.ToString();
                tbr1en.Cells.Add(tbc3);
            }
            tablerkcn.Rows.Add(tbr1cn);
            tablerkmt.Rows.Add(tbr1mt);
            tablerken.Rows.Add(tbr1en);
        }
        
        
    }

    void drawLvs() 
    {
        
        LevelStructure ls = new LevelStructure();
        this.llsi = ls.getLevelStructureInfoAll();
        Table llstb = (Table)this.FindControl("lvsTable");
        while (llstb.Rows.Count > 1)
        {
            llstb.Rows.RemoveAt(1);
        }
        for (int ic0 = 0; ic0 < llsi.Count; ic0++)
        {
            TableRow tbr = new TableRow();
            string[] contents = llsi[ic0].toStringToShow();

            for (int ic1 = 0; ic1 < 7; ic1++)
            {
                TableCell tbc = new TableCell();
                tbc.Text = (contents[ic1] == "empty" ? "" : contents[ic1]);
                tbc.ID = ic0.ToString() + ":" + ic1.ToString();
                tbr.Cells.Add(tbc);
            }
            llstb.Rows.Add(tbr);
        }
    }

    void drawCharts()
    {
        Control chineseChartRoot = this.FindControl("cChartRoot");
        Control mathChartRoot = this.FindControl("mChartRoot");
        Control englishChartRoot = this.FindControl("eChartRoot");
        Control[] chartRoots=new Control[4]{null,chineseChartRoot,mathChartRoot,englishChartRoot};
        string[] titleForSubject = new string[4] { "", "语文", "数学", "英语" };
        
        List<int> chartThePositionBelongsTo=new List<int>();
        List<string> Items = new List<string>();
        int chartNumForSingleSubject=0;
        string currentItem = "";
        int columnNum = levelstructureInfoList.Count;
        for (int ic = 0; ic < columnNum; ic++)
        {
            if (this.levelstructureInfoList[ic].Iterm != currentItem)
            {
                ++chartNumForSingleSubject;
                currentItem = this.levelstructureInfoList[ic].Iterm;
                Items.Add(currentItem);
            }
            chartThePositionBelongsTo.Add(chartNumForSingleSubject-1);
            
        }
        for (int isubject = 1; isubject < 4; isubject++)
        {
            List<Chart> chartList = new List<Chart>();
            for (int ichart = 0; ichart < chartNumForSingleSubject; ichart++)
            {
                Chart newchart = new Chart();
                newchart.Width = 1000;
                newchart.Height = 500;
                ChartArea ca = new ChartArea();
                
                newchart.Titles.Add(titleForSubject[isubject] + ":" + Items[ichart]);
                newchart.Titles[0].Font = new System.Drawing.Font("微软雅黑", 16);
                ca.AxisX.Title = "星期";
                ca.AxisX.TitleFont = new System.Drawing.Font("微软雅黑", 12);
                ca.AxisX.TitleAlignment = System.Drawing.StringAlignment.Far;
                ca.AxisY.Title = "成绩";
                ca.AxisY.TitleFont = new System.Drawing.Font("微软雅黑", 12);
                ca.AxisY.TitleAlignment = System.Drawing.StringAlignment.Far;
                ca.AxisX.MajorGrid.Enabled = false;//不显示竖着的分割线
                newchart.ChartAreas.Add(ca);
                chartList.Add(newchart);
            }
            drawChartForOneSubject(chartList, chartThePositionBelongsTo, isubject);
            for (int ichart = 0; ichart < chartNumForSingleSubject; ichart++)
            {
                chartRoots[isubject].Controls.Add(chartList[ichart]);
            }
        }
    }

    void drawChartForOneSubject(List<Chart> chartRoot, List<int> chartsItBelongsTo, int isubject)
    {
        int chartAmount = chartRoot.Count;
        int columnNum = levelstructureInfoList.Count;
        DataTable dttbs = new DataTable();
        dttbs.Columns.Add("week");
        for(int icounter1=0;icounter1<columnNum;icounter1++)
        {
            dttbs.Columns.Add(levelstructureInfoList[icounter1].Subiterm);
        }


        for (int ig = 0; ig < searchResult.Count; ig++)
        {

            string gradeString = "";
            if (isubject == 2)
            {
                gradeString = searchResult[ig].Math;
            }
            if (isubject == 1)
            {
                gradeString = searchResult[ig].Chinese;
            }
            if (isubject == 3)
            {
                gradeString = searchResult[ig].English;
            }

            while (gradeString.Length < columnNum)
            {
                gradeString = gradeString + "00000000";
            }
            DataRow dtr = dttbs.NewRow();
            dtr["week"] = searchResult[ig].Week;
            for (int icounter2 = 0; icounter2 < columnNum; icounter2++)
            {
                try
                {
                    int iii = Convert.ToInt32(gradeString.Substring(icounter2, 1));
                    if ((iii % 6) != 0)
                    {
                        dtr[levelstructureInfoList[icounter2].Subiterm] = iii;
                    }
                }
                catch (Exception manyException)
                {
                    dtr[levelstructureInfoList[icounter2].Subiterm] = 0;
                    manyException.ToString();
                }
            }
            dttbs.Rows.Add(dtr);
        }

        for (int icounter3 = 0; icounter3 < chartAmount; icounter3++)
        {
            Chart currentChart = (Chart)chartRoot[icounter3];
            currentChart.DataSource = dttbs;
        }

        for (int icounter4 = 0; icounter4 < columnNum; icounter4++)
        {
            Chart currentChart = (Chart)chartRoot[chartsItBelongsTo[icounter4]];
            Series sss = new Series();
            sss.ChartType = SeriesChartType.Line;
            Legend legend = new Legend("legend" + icounter4.ToString());
            legend.Font = new System.Drawing.Font("微软雅黑", 12);
            legend.Docking = Docking.Top;
            currentChart.Legends.Add(legend);
            sss.XValueMember = "week";
            sss.YValueMembers = levelstructureInfoList[icounter4].Subiterm;
            sss.Legend = "legend" + icounter4.ToString(); 
            sss.LegendText = levelstructureInfoList[icounter4].Subiterm;
            sss.IsValueShownAsLabel = true;//显示坐标
            sss.Font = new System.Drawing.Font("微软雅黑", 12);
            sss.BorderWidth = 6;
            sss.MarkerSize = 12;
            sss.MarkerStyle = System.Web.UI.DataVisualization.Charting.MarkerStyle.Circle;
            currentChart.Series.Add(sss);
        }
    }
}

#region previous code

//
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
