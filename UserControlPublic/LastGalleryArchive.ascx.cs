using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MainDataModuleTableAdapters;
using System.Data;

public partial class UserControlPublic_LastBook : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillGrid();
        }
    }
    private void FillGrid()
    {
        int ID_Category = -10;

        GridView1.SelectedIndex = -1;
        GridView1.DataSource = new tbl_GallerySubjectTableAdapter().GetDataByCategory_ID(ID_Category);
        GridView1.DataBind();

    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        FillGrid();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            int ID_Role = int.Parse(((Label)(e.Row.FindControl("ID_Role"))).Text.ToString());


            DataTable dt = new tbl_AdminInformationTableAdapter().GetDataByID(ID_Role);
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["AI_Name"].ToString().Length > 0)
                {
                    ((Label)(e.Row.FindControl("lblName"))).Text = "توسط : " + dt.Rows[0]["AI_Name"].ToString();
                }
                else
                {
                    ((Label)(e.Row.FindControl("lblName"))).Text = "توسط : " + dt.Rows[0]["AI_UserName"].ToString();
                }
            }
            int ID = int.Parse(((Label)(e.Row.FindControl("lblID"))).Text);
            DataTable dt2 = new tbl_GalleryPictureTableAdapter().GetDataBygp_ID_GallerySubject(ID);

            ((Label)(e.Row.FindControl("lblCount"))).Text =" ( "+ dt2.Rows.Count.ToString() + " تصویر )";
        }
    }
}
