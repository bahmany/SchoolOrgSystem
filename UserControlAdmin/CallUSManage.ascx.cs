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
        if (!new main_class().CheckPermissionAdmin("ManageCallUS", int.Parse(Request.Cookies["ID_Role"].Value)))
        {
            Response.Redirect("index.aspx?Type=AdminAccessDenied");
        }
        else
        {
            if (!IsPostBack)
            {
                FillGrid();
            }
        }
    }



    private void FillGrid()
    {

            GridView1.SelectedIndex = -1;
            GridView1.DataSource = new tbl_Call_USTableAdapter().GetDataByOrder();
            GridView1.DataBind();

    }

    
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        FillGrid();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int ID = int.Parse(((Label)(GridView1.Rows[e.RowIndex].FindControl("lblID"))).Text);
        new tbl_Call_USTableAdapter().Delete(ID);
        FillGrid();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
    
    }

}


