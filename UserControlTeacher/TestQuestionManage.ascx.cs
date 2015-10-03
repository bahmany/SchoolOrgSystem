using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MainDataModuleTableAdapters;
using System.Data;


public partial class UserControlPublic_AdminInformationAdd : System.Web.UI.UserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            FillPath();
            FillGrid();
        }

    }

    private void FillPath()
    {
        lblPath.Text = "<a href='index.aspx?Type=TestManage'>مدیریت آزمون آنلاین</a>" + " >> ";
        DataTable dt = new tbl_TestTableAdapter().GetDataByTest_ID(int.Parse(Request.QueryString["ID_Test"]));
        lblPath.Text = lblPath.Text + "طراحی سوالات آزمون >> " + dt.Rows[0]["T_Title"].ToString() + " >> "; 
    }
    private void FillGrid()
    {
        GridView1.SelectedIndex = -1;
        GridView1.DataSource = new tbl_TestQuestionTableAdapter().GetDataBytq_ID_Test(int.Parse(Request.QueryString["ID_Test"]));
        GridView1.DataBind();
    }
    private void Cancel()
    {
        TextA.Text = "";
        TextAnswer.Text = "";
        TextB.Text = "";
        TextC.Text = "";
        TextD.Text = "";

        TextTitle.Text = "";
        Button1.Visible = true;
        Button3.Visible = false;
        LblHidden.ToolTip = "";
        GridView1.SelectedIndex = -1;
        Label1.Visible = false;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (LblHidden.ToolTip.Length == 0)
        {
            new tbl_TestQuestionTableAdapter().Insert(
                DropDownList2.SelectedValue,
                TextTitle.Text,
                TextA.Text,
                TextB.Text,
                TextC.Text,
                TextD.Text,
                double.Parse(TextMark.Text),
                double.Parse(TextMinusMark.Text),
                TextAnswer.Text,
                int.Parse(Request.QueryString["ID_Test"]));
            FillGrid();
            Cancel();
        }
        else
        {
            int ID = int.Parse(LblHidden.ToolTip);
            new tbl_TestQuestionTableAdapter().Update(
                 DropDownList2.SelectedValue,
                 TextTitle.Text,
                 TextA.Text,
                 TextB.Text,
                 TextC.Text,
                 TextD.Text,
                 double.Parse(TextMark.Text),
                 double.Parse(TextMinusMark.Text),
                 TextAnswer.Text,
                 int.Parse(Request.QueryString["ID_Test"]), ID);

            FillGrid();
            Cancel();
        }
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int ID = int.Parse(((Label)(GridView1.Rows[e.RowIndex].FindControl("lblID"))).Text);
        new tbl_TestQuestionTableAdapter().Delete(ID);
        FillGrid();
        Cancel();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Cancel();
        int ID = int.Parse(((Label)(GridView1.Rows[e.NewEditIndex].FindControl("lblID"))).Text);
        DataTable dt = new tbl_TestQuestionTableAdapter().GetDataByTestQuestion_ID(ID);
        if (dt.Rows.Count > 0)
        {
            TextA.Text = dt.Rows[0]["tq_A"].ToString();
            TextAnswer.Text = dt.Rows[0]["tq_Answer"].ToString();
            TextB.Text = dt.Rows[0]["tq_B"].ToString();
            TextC.Text = dt.Rows[0]["tq_C"].ToString();
            TextD.Text = dt.Rows[0]["tq_D"].ToString();
            TextMark.Text = dt.Rows[0]["tq_Mark"].ToString();
            TextMinusMark.Text = dt.Rows[0]["tq_Minus_Mark"].ToString();
            TextTitle.Text = dt.Rows[0]["tq_Title"].ToString();
            DropDownList2.SelectedIndex = -1;

            DropDownList2.Items.FindByValue(dt.Rows[0]["tq_Type"].ToString()).Selected = true;
            TypeChanged();
            LblHidden.ToolTip = ID.ToString();
            GridView1.SelectedIndex = e.NewEditIndex;
            Button3.Visible = true;
            Button1.Visible = false;
        }

    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        FillGrid();
        Cancel();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Cancel();
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        TypeChanged();
    }
    void TypeChanged()
    {
        if (DropDownList2.SelectedValue == "Tashrihi")
        {
            Panel1.Visible = false;
        }
        else if (DropDownList2.SelectedValue == "Testi")
        {
            Panel1.Visible = true;
        }
    }
}


