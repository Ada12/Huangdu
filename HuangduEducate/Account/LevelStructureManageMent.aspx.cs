using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Model;

public partial class Account_LevelStructureManageMent : System.Web.UI.Page
{
    private List<LevelStructureInfo> llsi;
    private const string SessionIdLevelStructuers="HDLevelStructMgmt";
    string[] header = new string[7] { "i", "s", "5", "4", "3", "2", "1" };
    private string adminID;

    bool inputTableVisibility = false;
    protected void Page_Load(object sender, EventArgs e)
    {
        /// <summary>
        ///此处添加关于权限的代码
        /// </summary>
        /// 
        try
        {
            adminID = Session["adminID"].ToString();
        }
        catch (Exception exception1)
        {
            exception1.ToString();
            Response.Redirect("AdminLogin.aspx");
            return;
        }
        
        if (Page.IsPostBack)
        {
            this.llsi = (List<LevelStructureInfo>)Session[SessionIdLevelStructuers];
        }
        else
        {
            LevelStructure ls = new LevelStructure();
            this.llsi = ls.getLevelStructureInfoAll();
            Session.Remove(SessionIdLevelStructuers);
            Session.Add(SessionIdLevelStructuers, this.llsi);
            markCell.Text = "none";
        }

        this.fillTable();

        Table textBoxTable = (Table)this.FindControl("inputTable");
        textBoxTable.Visible = inputTableVisibility;
        
    }

    private void fillTable()
    {
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

            TableCell buttonCellDelete = new TableCell();
            buttonCellDelete.Text = "<input type=\"button\" name=\"chgdat\" id=\"chgdat\" value=\"删除\" onclick=\"deleteData(" + ic0.ToString() + ")\"/>";
            tbr.Cells.Add(buttonCellDelete);
            TableCell buttonCellChange = new TableCell();
            buttonCellChange.Text = "<input type=\"button\" name=\"deldat\" id=\"deldat\" value=\"修改\" onclick=\"selectChangeRow(" + ic0.ToString() + ")\"/>";
            tbr.Cells.Add(buttonCellChange);

            llstb.Rows.Add(tbr);
        }
    }

    protected void backBtn_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminManagement.aspx");
    }

    protected void addNewRow_Click(object sender, EventArgs e)
    {
        ((Button)this.FindControl("addNewRow")).Visible=false;
        inputTableVisibility = true;
        Table textBoxTable = (Table)this.FindControl("inputTable");
        textBoxTable.Visible = inputTableVisibility;
        markCell.Text = "add";
        
    }

    protected void submit_Click(object sender, EventArgs e)
    {
        string iptItem = ((TextBox)this.FindControl("STi")).Text;
        string iptSubitem = ((TextBox)this.FindControl("STs")).Text;
        string iptfive = ((TextBox)this.FindControl("ST5")).Text;
        string iptfour = ((TextBox)this.FindControl("ST4")).Text;
        string iptthree = ((TextBox)this.FindControl("ST3")).Text;
        string ipttwo = ((TextBox)this.FindControl("ST2")).Text;
        string iptone = ((TextBox)this.FindControl("ST1")).Text;
        LevelStructure lvs = new LevelStructure();
        LevelStructureInfo li = new LevelStructureInfo(iptItem, iptSubitem, 0,
            new string[5] { iptfive, iptfour, iptthree, ipttwo, iptone });
        if (iptItem == "" || iptSubitem == "")
        {
            inputTableVisibility = true;
            errorMessageCell.Text = "类别名称不能为空";
            Table textBoxTable = (Table)this.FindControl("inputTable");
            textBoxTable.Visible = inputTableVisibility;
            return;
        }
        if (markCell.Text == "add")
        {
            int it=lvs.addItem(li);
            if (it == -2)
            {
                errorMessageCell.Text = "同一项已存在";
                inputTableVisibility = true;
                Table textBoxTable = (Table)this.FindControl("inputTable");
                textBoxTable.Visible = inputTableVisibility;
                return;
            }
        }
        else if(markCell.Text=="change")
        {
            lvs.updateLevelInfo(li, 0);
        }
        this.llsi = lvs.getLevelStructureInfoAll();
        Session.Remove(SessionIdLevelStructuers);
        Session.Add(SessionIdLevelStructuers, this.llsi);
        fillTable();
        Cancel_Click(sender,e);
    }


    protected void Cancel_Click(object sender, EventArgs e)
    {
        ((TextBox)this.FindControl("STi")).ReadOnly = false;
        ((TextBox)this.FindControl("STs")).ReadOnly = false;
        ((TextBox)this.FindControl("STi")).Text="";
        ((TextBox)this.FindControl("STs")).Text="";
        ((TextBox)this.FindControl("ST5")).Text="";
        ((TextBox)this.FindControl("ST4")).Text="";
        ((TextBox)this.FindControl("ST3")).Text="";
        ((TextBox)this.FindControl("ST2")).Text="";
        ((TextBox)this.FindControl("ST1")).Text="";
        markCell.Text = "none";
        errorMessageCell.Text = "";
        ((Button)this.FindControl("addNewRow")).Visible = false;
        Response.Redirect(Request.Url.ToString());
    }


    public string Change_Click(string str)
    {
        int irow = 0;
        try
        {
            irow = Convert.ToInt32(str);
        }
        catch (Exception exc)
        {
            return "fail";
        }
        LevelStructureInfo li = this.llsi[irow];
        ((TextBox)this.FindControl("STi")).Text = li.Iterm;
        ((TextBox)this.FindControl("STs")).Text = li.Subiterm;
        ((TextBox)this.FindControl("ST5")).Text = li.Five;
        ((TextBox)this.FindControl("ST4")).Text = li.Four;
        ((TextBox)this.FindControl("ST3")).Text = li.Three;
        ((TextBox)this.FindControl("ST2")).Text = li.Two;
        ((TextBox)this.FindControl("ST1")).Text = li.One;

        ((TextBox)this.FindControl("STi")).ReadOnly = true;
        ((TextBox)this.FindControl("STs")).ReadOnly = true;
        ((Button)this.FindControl("addNewRow")).Visible = false;

        return "success";
    }
}
/*
 * 遗嘱   by秦乙丹
 * 这个页面可以算是典范了
 * 
 * 添加数据是纯用asp.net。各元素都是静态元素，直接获取对应属性传给后端即可
 * 
 * 删除数据用ajax传到对应的handler，在handler里执行。
 * 
 * 修改，js大量前端操纵，之后传handler
 * 
 * 好吧，看自己两天前写的代码跟渣渣一样 
 * 
 */