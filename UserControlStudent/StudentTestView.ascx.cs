using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MainDataModuleTableAdapters;
using System.Data;
using System.Data.SqlClient;


public partial class UserControlPublic_AdminInformationAdd : System.Web.UI.UserControl
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            FillDr();
            FillGrid();
        }
    }
    private void FillDr()
    {
        DataTable dt = new tbl_StudentInformationTableAdapter().GetDataByStudent_ID(int.Parse(Request.Cookies["ID_Role"].Value));
        int ID_Category = int.Parse(dt.Rows[0]["SI_ID_Category"].ToString());

        DropDownList1.Items.Clear();
        DropDownList1.DataValueField = "Lesson_ID";
        DropDownList1.DataTextField = "Les_Name";
        DropDownList1.DataSource = new tbl_LessonTableAdapter().GetDataByCategory_ID(ID_Category);
        DropDownList1.DataBind();
        DropDownList1.Visible = true;
    }
    private void FillGrid()
    {
        if (DropDownList1.Items.Count > 0)
        {
           
            GridView1.SelectedIndex = -1;
            GridView1.DataSource = new tbl_TestTableAdapter().GetDataByt_id_lesson(int.Parse(DropDownList1.SelectedValue));
            GridView1.DataBind();
        }
        else
        {
            GridView1.DataBind();

        }
    }
    
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        FillGrid();
    }


        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                if (((HiddenField)(e.Row.FindControl("HiddenField1"))).Value == "DarhalBargozari")
                {
                    ((HyperLink)(e.Row.FindControl("HyperLink1"))).Visible = true;
                }
                else
                {
                    ((HyperLink)(e.Row.FindControl("HyperLink1"))).Visible = false;

                }
                if (((HiddenField)(e.Row.FindControl("HiddenField1"))).Value == "BargozarShode")
                {
                    int ID_Test=int.Parse( ((Label)(e.Row.FindControl("lblID"))).Text);
                    DataTable dt = new tbl_TestResultTableAdapter().GetDataByScoreStudent(ID_Test, int.Parse(Request.Cookies["ID_Role"].Value));
                    if (dt.Rows.Count > 0)
                    {
                        ((Label)(e.Row.FindControl("lblScore"))).Text = dt.Rows[0]["tr_Score"].ToString();
                    }
                    else
                    {
                        ((Label)(e.Row.FindControl("lblScore"))).Text = "";
                    }
                }
            }
        }
}


