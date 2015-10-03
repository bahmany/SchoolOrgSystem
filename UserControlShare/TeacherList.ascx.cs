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
            FillGrid();
        }
    }
    private void FillGrid()
    {
        GridView1.SelectedIndex = -1;
        DataTable dt = new tbl_TeacherInformationTableAdapter().GetDataByID(int.Parse(Request.Cookies["ID_Role"].Value.ToString()));

        GridView1.DataSource = new tbl_TeacherInformationTableAdapter().GetDataByTeacherTeacher(int.Parse(dt.Rows[0]["TI_ID_Admin"].ToString()));
        GridView1.DataBind();
    }
  
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        FillGrid();
      
    }

    
}


