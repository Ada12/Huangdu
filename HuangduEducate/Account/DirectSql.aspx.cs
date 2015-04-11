using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AccessDAL;
using System.Data.OleDb;
using Model;

public partial class Account_DirectSql : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void runNQ(object sender, EventArgs e)
    {
        OleDbConnection oledbc = (new DBConnection()).getConnection();
        OleDbCommand cmd = new OleDbCommand(NonQueryCmd.Text, oledbc);
        oledbc.Open();
        cmd.ExecuteNonQuery();
        oledbc.Close();
    }
    protected void runER(object sender, EventArgs e)
    {
        table1.Rows.Clear();
        OleDbConnection oledbc = (new DBConnection()).getConnection();
        oledbc.Open();
        OleDbCommand cmd = new OleDbCommand(ExeReaderCmd.Text, oledbc);
        OleDbDataReader reader= cmd.ExecuteReader();
        while (reader.Read())
        {
            TableRow tbr = new TableRow();
            for (int icount = 0; icount < reader.FieldCount; icount++)
            {
                try
                {
                    TableCell tbc = new TableCell();
                    tbc.Text = reader.GetString(icount);
                    tbr.Cells.Add(tbc);
                }
                catch (Exception exc)
                {
                    try
                    {
                        TableCell tbc = new TableCell();
                        tbc.Text = reader.GetInt32(icount).ToString();
                        tbr.Cells.Add(tbc);
                    }
                    catch (Exception ex2)
                    {
                        TableCell tbc = new TableCell();
                        tbc.Text = ex2.ToString();
                        tbr.Cells.Add(tbc);
                    }
                }
            }
            table2.Rows.Add(tbr);
        }
        oledbc.Close();
    }

    protected void runPG(object sender, EventArgs e)
    {
        table2.Rows.Clear();
        HDGrade hg = new HDGrade();
        List<string> lststr = new List<string>();
        lststr.Add("200635001");
        lststr.Add("200635010");
        lststr.Add("200735010");
        List<GradeInfo> lg = hg.GetGradeInfo(lststr,2);
        foreach (GradeInfo gi in lg)
        {
            TableRow tbr=new TableRow();
            TableCell tbc1 = new TableCell();
            TableCell tbc2 = new TableCell();
            TableCell tbc3 = new TableCell();
            TableCell tbc4 = new TableCell();
            tbc1.Text = gi.ID;
            tbc2.Text = gi.Chinese;
            tbc3.Text = gi.Math;
            tbc4.Text = gi.English;
            tbr.Cells.AddRange(new TableCell[] { tbc1, tbc2, tbc3, tbc4});
            table2.Rows.Add(tbr);
        }
    }
}