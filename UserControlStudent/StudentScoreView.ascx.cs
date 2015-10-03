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
            GridView1.DataSource = new tbl_ScoreTitleTableAdapter().GetDataByStudent(int.Parse(DropDownList1.SelectedValue),
                int.Parse(Request.Cookies["ID_Role"].Value));
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
}


