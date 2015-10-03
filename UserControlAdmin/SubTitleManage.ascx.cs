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
        if (!new main_class().CheckPermissionAdmin("ManageSubTitle", int.Parse(Request.Cookies["ID_Role"].Value)))
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
            GridView1.DataSource = new tbl_SubTitleTableAdapter().GetData();
            GridView1.DataBind();

    }

    private void Cancel()
    {
        TextTitle.Text = "";
        LblHidden.ToolTip = "";

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (LblHidden.ToolTip.Length == 0)
        {

                new tbl_SubTitleTableAdapter().Insert(TextTitle.Text);

        }
        else
        {
            int ID = int.Parse(LblHidden.ToolTip);

                new tbl_SubTitleTableAdapter().Update(TextTitle.Text,ID);

        }
        Cancel();
        FillGrid();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        FillGrid();
        Cancel();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int ID = int.Parse(((Label)(GridView1.Rows[e.RowIndex].FindControl("lblID"))).Text);
        new tbl_SubTitleTableAdapter().Delete(ID);
        FillGrid();
        Cancel();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int ID = int.Parse(((Label)(GridView1.Rows[e.NewEditIndex].FindControl("lblID"))).Text);
        DataTable dt = new tbl_SubTitleTableAdapter().GetDataBySubTitle_ID(ID);
        if (dt.Rows.Count > 0)
        {
            TextTitle.Text = dt.Rows[0]["Sb_Title"].ToString();
        }
        LblHidden.ToolTip = ID.ToString();
        GridView1.SelectedIndex = e.NewEditIndex;
    }

}


