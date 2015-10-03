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
            FillPath();
            FillGrid();
        }
    }

    private void FillPath()
    {
        lblPath.Text = "<a href='index.aspx?Type=TestManage'>مدیریت آزمون آنلاین</a>" + " >> ";
        DataTable dt = new tbl_TestTableAdapter().GetDataByTest_ID(int.Parse(Request.QueryString["ID_Test"]));
        lblPath.Text = lblPath.Text + "مشاهده نتایج آزمون آنلاین >> " + dt.Rows[0]["T_Title"].ToString() + " >> ";
    }
    private void FillGrid()
    {
       
            DataTable dt = new tbl_TestTableAdapter().GetDataByTest_ID(int.Parse(Request.QueryString["ID_Test"]));
            int ID_Category =int.Parse( dt.Rows[0]["Les_ID_Category"].ToString());

            GridView1.SelectedIndex = -1;
            GridView1.DataSource = new tbl_TestResultTableAdapter().GetDataByCategory(ID_Category);
            GridView1.DataBind();
            
      
    }

   
  
      

       
       
}


