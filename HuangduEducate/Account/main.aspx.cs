using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Account_main : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void studentBtn_Click(object sender, EventArgs e) 
    {
        Server.Transfer("StudentLogin.aspx");
    }

    protected void teacherBtn_Click(object sender, EventArgs e)
    {
        Server.Transfer("ClassLogin.aspx");
    }
}