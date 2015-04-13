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
    private List<StudentInfo> studentInfoList;
    private List<GradeInfo> gradeInfoList;

    public const string SessioIDForLevelStructure = "HDAddGradeLevelStructureInfoList";
    public const string SessioIDForStudent = "HDAddGradeLevelStudentInfoList";


    protected void Page_Load(object sender, EventArgs e)
    {
        //ddlWeek.SelectedIndexChanged+=new EventHandler(onWeekChanged);
        //ddlSubject.SelectedIndexChanged+=new EventHandler(onSubjectChanged);
        /*
        try
        {
            System.Web.UI.Page pg = (Page)sender;
            Table classListTable0 = (Table)pg.FindControl("classListTable");
            DropDownList ddl = (DropDownList)classListTable0.Rows[2].Cells[2].Controls[0];
            Button bt = (Button)sender;
            if (bt.ID == "saveButton")
            {
                return;
            }
        }
        catch (Exception excp)
        {
 
        }*/

        initialPage();
    }

    protected void initialPage()
    {
        #region 
        DropDownList ddlWeek = (DropDownList)this.FindControl("ddlWeek");
        DropDownList ddlSubject = (DropDownList)this.FindControl("ddlSubject");
        TableRow classHeaderRow1 = (TableRow)this.FindControl("classHeaderRow1");
        TableRow classHeaderRow2 = (TableRow)this.FindControl("classHeaderRow2");
        Table classListTable = (Table)this.FindControl("classListTable");
        levelstructureInfoList = new List<LevelStructureInfo>();
        studentInfoList = new List<StudentInfo>();
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
        ddlSubject.EnableViewState = false;
        ddlWeek.EnableViewState = true;
        for (int icounterw = 1; icounterw < 22; icounterw++)
        {
            ddlWeek.Items.Add(new ListItem(icounterw.ToString(), icounterw.ToString()));
        }
        #endregion
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
        string previousStr = "";
        classHeaderRow1.Cells.Clear();
        classHeaderRow2.Cells.Clear();
        classHeaderRow1.EnableViewState = false;//若设为true则column的值会累加
        classHeaderRow2.EnableViewState = false;//有了asp:UpdatePanel之后，这两句应该没用了吧，写于上一条注释二十四小时候，rzc怨念中，没错，我就是下文出现的那个变量
        TableHeaderCell IDcell = new TableHeaderCell();
        TableHeaderCell namecell = new TableHeaderCell();
        IDcell.Text = "学号";
        namecell.Text = "姓名";
        IDcell.RowSpan = 2;
        namecell.RowSpan = 2;
        classHeaderRow1.Cells.Add(IDcell);
        classHeaderRow1.Cells.Add(namecell);
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
                classHeaderRow1.Cells.Add(tbc01);
            }


            TableHeaderCell tbc02 = new TableHeaderCell();
            tbc02.Text = lvstri.Subiterm;
            classHeaderRow2.Cells.Add(tbc02);
        }
        #endregion
        #region addStudentList
        if (classID != "")
        {
            if (Page.IsPostBack)
            {
                studentInfoList = (List<StudentInfo>)Session[SessioIDForStudent];
            }
            else
            {
                Student hdstd = new Student();
                studentInfoList = hdstd.getStudentList(classID);
                Session.Remove(SessioIDForStudent);
                Session.Add(SessioIDForStudent, studentInfoList);

            }

            int itemNum = levelstructureInfoList.Count;
            for (int icounter1 = 0; icounter1 < studentInfoList.Count; icounter1++)
            {
                StudentInfo stdif = studentInfoList[icounter1];
                TableRow tbr = new TableRow();
                tbr.ID = "student:" + stdif.ID;

                TableCell tbc1 = new TableCell();
                TableCell tbc2 = new TableCell();
                tbc1.Text = stdif.ID;
                tbc1.ID = (icounter1 + 2).ToString();
                tbc2.Text = stdif.Name;
                tbr.Cells.Add(tbc1);
                tbr.Cells.Add(tbc2);

                for (int icounter2 = 0; icounter2 < itemNum; icounter2++)
                {
                    TableCell tbc3n = new TableCell();
                    DropDownList ddl = new DropDownList();
                    ddl.ID = "ddl:" + stdif.ID + ":" + icounter2.ToString();
                    ddl.Items.Add(new ListItem("请选择", "6"));
                    ddl.Items.Add(new ListItem("1", "1"));
                    ddl.Items.Add(new ListItem("2", "2"));
                    ddl.Items.Add(new ListItem("3", "3"));
                    ddl.Items.Add(new ListItem("4", "4"));
                    ddl.Items.Add(new ListItem("5", "5"));
                    tbc3n.Controls.Add(ddl);
                    tbr.Cells.Add(tbc3n);
                }

                classListTable.Rows.Add(tbr);
            }
        }
        #endregion
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

    protected void onWeekChanged(object sender, EventArgs e)
    {
        DropDownList ddlSubject = (DropDownList)this.FindControl("ddlSubject");
        DropDownList ddlWeek = (DropDownList)this.FindControl("ddlWeek");
        Table classListTable = (Table)this.FindControl("classListTable");

        if (ddlWeek.SelectedValue == "none")
        {
            return;
        }
        List<string> studentIdList = this.getStudentIdList();
        Grade grade = new Grade();
        this.gradeInfoList = grade.GetGradeInfoList(studentIdList, ddlWeek.SelectedValue);
        Session.Remove("hdStudentGradeStudentRecord");
        Session.Add("hdStudentGradeStudentRecord", gradeInfoList);
        if (ddlSubject.SelectedValue == "none")
        {
            return;
        }
        int ic1 = 0;

        for (ic1 = 0; ic1 < this.gradeInfoList.Count; ic1++)
        {
            for (int ic2 = 0; ic2 < levelstructureInfoList.Count; ic2++)
            {
                DropDownList ddl = (DropDownList)classListTable.Rows[2 + ic1].Cells[2 + ic2].Controls[0];
                if (ddlSubject.SelectedValue == "chinese")
                {
                    char[] rzc=gradeInfoList[ic1].Chinese.ToCharArray();
                    ddl.SelectedIndex = (rzc[ic2] - '0') % 6;
                }
                else if (ddlSubject.SelectedValue == "math")
                {
                    char[] rzc = gradeInfoList[ic1].Math.ToCharArray();
                    ddl.SelectedIndex = (rzc[ic2] - '0') % 6;
                }
                else
                {
                    char[] rzc = gradeInfoList[ic1].English.ToCharArray();
                    ddl.SelectedIndex = (rzc[ic2] - '0') % 6;
                }
            }
        }
        
    }
    
    protected void onSubjectChanged(object sender, EventArgs e)
    {
        DropDownList ddlWeek = (DropDownList)this.FindControl("ddlWeek");
        DropDownList ddlSubject = (DropDownList)this.FindControl("ddlSubject");
        if (ddlWeek.SelectedValue == "none" || ddlSubject.SelectedValue == "none")
        {
            return;
        }
        int ic1 = 0;
        this.gradeInfoList = (List<GradeInfo>)Session["hdStudentGradeStudentRecord"];
        for (ic1 = 0; ic1 < this.gradeInfoList.Count; ic1++)
        {
            //对于每一个student
            char[] rzc_cn = gradeInfoList[ic1].Chinese.ToCharArray();
            char[] rzc_mt = gradeInfoList[ic1].Math.ToCharArray();
            char[] rzc_en = gradeInfoList[ic1].English.ToCharArray();


            for (int ic2 = 0; ic2 < levelstructureInfoList.Count; ic2++)
            {
                //对于每一评分项
                DropDownList ddl = (DropDownList)this.classListTable.Rows[2 + ic1].Cells[2 + ic2].Controls[0];
                if (ddlSubject.SelectedValue == "chinese")
                {
                    try
                    {
                        ddl.SelectedIndex = (rzc_cn[levelstructureInfoList[ic2].Position] - '0') % 6;
                    }
                    catch (Exception e1)
                    {
                        ddl.SelectedIndex = 0;
                    }
                }
                else if (ddlSubject.SelectedValue == "math")
                {   
                    try
                    {
                        ddl.SelectedIndex = (rzc_mt[levelstructureInfoList[ic2].Position] - '0') % 6;
                    }
                    catch (Exception e2)
                    {
                        ddl.SelectedIndex = 0;
                    }
                }
                else
                {   
                    try
                    {
                        ddl.SelectedIndex = (rzc_en[levelstructureInfoList[ic2].Position] - '0') % 6;
                    }
                    catch (Exception e3)
                    {
                        ddl.SelectedIndex = 0;
                    }
                }
            }
        }
    }

    protected List<string> getStudentIdList()
    {
        List<string> liststr = new List<string>();
        for (int icounter = 0; icounter < this.studentInfoList.Count; icounter++)
        {
            liststr.Add(studentInfoList[icounter].ID);
        }
        return liststr;
    }

    protected void onSaveButtonClick(object sender, EventArgs e)
    {

        int maxLvStrPosition = LevelStructure.maxPosition(this.levelstructureInfoList);

        int ic1 = 0;
        int subject = ddlSubject.SelectedIndex;
        if (subject > 3 || subject < 1)
        {
            return;
        }
        //chineseResultTemp,mathResultTemp,EnglishResultTemp
        List<GradeInfo> resultLstGi = new List<GradeInfo>();
        this.gradeInfoList = (List<GradeInfo>)Session["hdStudentGradeStudentRecord"];
        for (ic1 = 0; ic1 < this.gradeInfoList.Count; ic1++)
        {
            string[] cnrt = new string[maxLvStrPosition + 1];
            string[] mtrt = new string[maxLvStrPosition + 1];
            string[] enrt = new string[maxLvStrPosition + 1];
            for (int ic3 = 0; ic3 <= maxLvStrPosition; ic3++)
            {
                cnrt[ic3] = "6";
                mtrt[ic3] = "6";
                enrt[ic3] = "6";
            }
            for (int ic2 = 0; ic2 < levelstructureInfoList.Count; ic2++)
            {
                DropDownList ddl = (DropDownList)classListTable.Rows[2 + ic1].Cells[2 + ic2].Controls[0];
                if (ddlSubject.SelectedValue == "chinese")
                {
                    cnrt[levelstructureInfoList[ic2].Position] = ddl.SelectedValue;
                }
                else if (ddlSubject.SelectedValue == "math")
                {
                    mtrt[levelstructureInfoList[ic2].Position] = ddl.SelectedValue;
                }
                else
                {
                    enrt[levelstructureInfoList[ic2].Position] = ddl.SelectedValue;
                }
            }
            string cnstr = "";
            string mtstr = "";
            string enstr = "";
            for (int ic4 = 0; ic4 <= maxLvStrPosition; ic4++)
            {
                cnstr = cnstr + cnrt[ic4];
                mtstr = mtstr + mtrt[ic4];
                enstr = enstr + enrt[ic4];
            }
            resultLstGi.Add(new GradeInfo(this.gradeInfoList[ic1].ID, ddlWeek.SelectedIndex, cnstr, mtstr, enstr));

        }
        Grade grade = new Grade();
        grade.UpdateInfo(resultLstGi, subject);

    }
}