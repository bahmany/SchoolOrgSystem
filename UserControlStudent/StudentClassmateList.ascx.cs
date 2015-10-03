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

            FillGrid();
        }
    }

    
    private void FillGrid()
    {
            DataTable dt = new tbl_StudentInformationTableAdapter().GetDataByStudent_ID(int.Parse(Request.Cookies["ID_Role"].Value));
            int ID_Category =int.Parse( dt.Rows[0]["SI_ID_Category"].ToString());

            GridView1.SelectedIndex = -1;
            GridView1.DataSource = new tbl_StudentInformationTableAdapter().GetDataByCategory_ID(ID_Category);
            GridView1.DataBind();
            FillPath(ID_Category.ToString());
    }

   
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        FillGrid();
    }

        private void FillPath(string ID_Category)
        {
            lblPath.Text = "";
            int ID = int.Parse(ID_Category);

            DataTable dt = new tbl_CategoryTableAdapter().GetDataByID(ID);
            if (dt.Rows.Count > 0)
            {
                string delimitedInfo = dt.Rows[0]["cat_Path"].ToString();
                string[] discreteInfo = delimitedInfo.Split(new char[] { ',' });
                string title = "";
                foreach (string Data in discreteInfo)
                {
                    if (Data != "-1")
                    {
                        int ID2 = int.Parse(Data);
                        DataTable dt2 = new tbl_CategoryTableAdapter().GetDataByID(ID2);
                        if (dt2.Rows.Count > 0)
                        {
                            title = dt2.Rows[0]["Cat_Title"].ToString();
                        }
                        lblPath.Text = lblPath.Text + title + " >> ";
                    }
                }
                lblPath.Text = lblPath.Text + dt.Rows[0]["cat_title"].ToString() + " >> ";
            }
            else
            {
                lblPath.Text = lblPath.Text + "بخش عمومی  >> ";
            }
        }
       
}


