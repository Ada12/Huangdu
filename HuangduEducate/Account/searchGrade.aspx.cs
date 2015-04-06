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

        Table resulttable = (Table)this.FindControl("resulttable");
        Student student = new Student();
        Grade grade = new Grade();
        searchResult = grade.GetGradeInfoList(studentID);
        foreach (GradeInfo info in searchResult)
        {
            if (info.Chinese == null  &&
                info.Math == null &&
                info.English == null )
            {
                continue;
            }
            TableRow tbr = new TableRow();
            TableCell[] resCells = new TableCell[5];
            for (int i = 0; i < 5; i++)
            {
                resCells[i] = new TableCell();
            }
            resCells[0].Text = info.ID;
            resCells[1].Text = info.Week.ToString();
            resCells[2].Text = info.Chinese == null ? "" : info.Chinese.ToString();
            resCells[3].Text = info.Math == null? "" : info.Math.ToString();
            resCells[4].Text = info.English == null ? "" : info.English.ToString();
            tbr.Cells.AddRange(resCells);
            resulttable.Rows.Add(tbr);
        }
    }

    void fillCharts()
    {
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
        }

         
    }
    /*
    protected void chineseImageLoad(object sender, EventArgs e)
    {
        
        int[] chineseGrades = new int[searchResult.Count];
        int[] mathGrades = new int[searchResult.Count];
        int[] englishGrades = new int[searchResult.Count];
        //this.searchResult.Sort
        for (int i = 0; i < this.searchResult.Count; ++i)
        {
            chineseGrades[i] = searchResult[i].Chiness;
            mathGrades[i] = searchResult[i].Math;
            englishGrades[i] = searchResult[i].English;
        }
        int[][] grades = new int[3][];
        grades[0] = chineseGrades;
        grades[1] = mathGrades;
        grades[2] = englishGrades;
        string[] titles = { "语文成绩","数学成绩","英语成绩"};
        MemoryStream chineseMemoryStream = new MemoryStream();
        Bitmap bitmap = new Bitmap(800, 900);
        Graphics g = Graphics.FromImage(bitmap);
        

        
    }*/
}