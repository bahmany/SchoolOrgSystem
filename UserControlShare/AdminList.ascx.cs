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
        int ID_Admin = 0;
        if (Request.Cookies["Type_Role"].Value.ToString() == "Teacher")
        {
            DataTable dt = new tbl_TeacherInformationTableAdapter().GetDataByID(int.Parse(Request.Cookies["ID_Role"].Value.ToString()));
            ID_Admin=int.Parse(dt.Rows[0]["TI_ID_Admin"].ToString());
        }
        else if (Request.Cookies["Type_Role"].Value.ToString() == "Parent")
        {
          
            DataTable dt2 = new tbl_ParentInformationTableAdapter().GetDataByID(int.Parse(Request.Cookies["ID_Role"].Value.ToString()));

            DataTable dt = new tbl_StudentInformationTableAdapter().GetDataByStudent_ID(int.Parse(dt2.Rows[0]["PA_ID_Student"].ToString()));
            ID_Admin = int.Parse(dt.Rows[0]["SI_ID_Admin"].ToString());
        }
        else if (Request.Cookies["Type_Role"].Value.ToString() == "Student")
        {
            DataTable dt = new tbl_StudentInformationTableAdapter().GetDataByStudent_ID(int.Parse(Request.Cookies["ID_Role"].Value.ToString()));
            ID_Admin= int.Parse(dt.Rows[0]["SI_ID_Admin"].ToString());
        }
        GridView1.DataSource = new tbl_AdminInformationTableAdapter().GetDataByAdminListTeacher(ID_Admin);

        GridView1.DataBind();
    }
  
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        FillGrid();
      
    }

    
}


