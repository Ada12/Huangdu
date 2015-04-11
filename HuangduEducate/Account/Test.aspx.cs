using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;
using AccessDAL;

public partial class Account_Test : System.Web.UI.Page
{
    protected void onSubjectChanged(object sender, EventArgs e)
    {
        ddlTextShow.Text = ddlSubject.SelectedValue;
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        
       
    }

    protected void sss(object sender, EventArgs e)
    {
        List<GradeInfo> lstgradeinfo = new List<GradeInfo>();
        lstgradeinfo.Add(new GradeInfo("200635010", 1, "411111114", "55511555", "333333333"));
        lstgradeinfo.Add(new GradeInfo("200635010", 2, "4111111144", "2222222222", "335555553"));
        lstgradeinfo.Add(new GradeInfo("200635010", 3, "4445555444", "2222222225", "3355555533"));
        lstgradeinfo.Add(new GradeInfo("200635008", 1, "345343443434", "344443433", "234123123"));
        lstgradeinfo.Add(new GradeInfo("200635008",2,"34534544433","23432534242","23432432423"));
        lstgradeinfo.Add(new GradeInfo("200635008", 3, "34543543345", "124213245", "232324242"));
        
        HDGrade hdg = new HDGrade();
        hdg.InsertData(lstgradeinfo,1);
    }
}