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
            FillDr(-1, DropDownList1);
            FillDr(0, DropDownList2);
            FillDr(0, DropDownList3);
            FillDr(0, DropDownList4);
            FillDr(0, DropDownList5);
            FillDr(0, DropDownList6);
            FillGrid();
            
        }
    }

    private void FillDr(int ID_Category,DropDownList Dr)
    {
        Dr.Items.Clear();
        Dr.Items.Add("همه");
        Dr.Items[0].Value = "-1";
        Dr.DataValueField = "Category_ID";
        Dr.DataTextField = "Cat_Title";
        Dr.DataSource = new tbl_CategoryTableAdapter().GetDataByID_Root(ID_Category);
        Dr.DataBind();
        Dr.Visible = true;
    }

    private void FillGrid()
    {
        int ID_Category = -1;
        if (DropDownList6.SelectedValue != "-1")
        {
            ID_Category = int.Parse(DropDownList6.SelectedValue.ToString());
        }
        else if (DropDownList5.SelectedValue != "-1")
        {
            ID_Category = int.Parse(DropDownList5.SelectedValue.ToString());
        }
        else if (DropDownList4.SelectedValue != "-1")
        {
            ID_Category = int.Parse(DropDownList4.SelectedValue.ToString());
        }
        else if (DropDownList3.SelectedValue != "-1")
        {
            ID_Category = int.Parse(DropDownList3.SelectedValue.ToString());
        }
        else if (DropDownList2.SelectedValue != "-1")
        {
            ID_Category = int.Parse(DropDownList2.SelectedValue.ToString());
        }
        else if (DropDownList1.SelectedValue != "-1")
        {
            ID_Category = int.Parse(DropDownList1.SelectedValue.ToString());
        }
        else
        {
            ID_Category = -1;
        }
        if (ID_Category == -1)
        {
            GridView1.SelectedIndex = -1;
            GridView1.DataSource = new tbl_LessonTableAdapter().GetDataByAllTeacher(int.Parse(Request.Cookies["ID_Role"].Value.ToString()));
            GridView1.DataBind();
        }
        else
        {
            GridView1.SelectedIndex = -1;
            GridView1.DataSource = new tbl_LessonTableAdapter().GetDataByCategory_IDTeacher(int.Parse(Request.Cookies["ID_Role"].Value.ToString()), ID_Category);
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
            if (DropDownList1.SelectedValue == "-1")
            {
                //DropDownList2.Visible = false;
                FillDr(0, DropDownList2);
                //DropDownList3.Visible = false;
                FillDr(0, DropDownList3);
                //DropDownList4.Visible = false;
                FillDr(0, DropDownList4);
                //DropDownList5.Visible = false;
                FillDr(0, DropDownList5);
                //DropDownList6.Visible = false;
                FillDr(0, DropDownList6);
            }
            else
            {
                //DropDownList3.Visible = false;
                FillDr(0, DropDownList3);
                //DropDownList4.Visible = false;
                FillDr(0, DropDownList4);
                //DropDownList5.Visible = false;
                FillDr(0, DropDownList5);
                //DropDownList6.Visible = false;
                FillDr(0, DropDownList6);
                FillDr(int.Parse(DropDownList1.SelectedValue), DropDownList2);
            }
            FillGrid();
           
        }
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedValue == "-1")
            {
                //DropDownList3.Visible = false;
                FillDr(0, DropDownList3);
                //DropDownList4.Visible = false;
                FillDr(0, DropDownList4);
                //DropDownList5.Visible = false;
                FillDr(0, DropDownList5);
                //DropDownList6.Visible = false;
                FillDr(0, DropDownList6);
            }
            else
            {
                //DropDownList4.Visible = false;
                FillDr(0, DropDownList4);
                //DropDownList5.Visible = false;
                FillDr(0, DropDownList5);
                //DropDownList6.Visible = false;
                FillDr(0, DropDownList6);
                FillDr(int.Parse(DropDownList2.SelectedValue), DropDownList3);
            }
            FillGrid();
        }
        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList3.SelectedValue == "-1")
            {
                //DropDownList4.Visible = false;
                FillDr(0, DropDownList4);
                //DropDownList5.Visible = false;
                FillDr(0, DropDownList5);
                //DropDownList6.Visible = false;
                FillDr(0, DropDownList6);
            }
            else
            {
                //DropDownList5.Visible = false;
                FillDr(0, DropDownList5);
                //DropDownList6.Visible = false;
                FillDr(0, DropDownList6);
                FillDr(int.Parse(DropDownList3.SelectedValue), DropDownList4);
            }
            FillGrid();
        }
        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList4.SelectedValue == "-1")
            {
                //DropDownList5.Visible = false;
                FillDr(0, DropDownList5);
               // DropDownList6.Visible = false;
                FillDr(0, DropDownList6);
            }
            else
            {
               
                FillDr(0, DropDownList6);
                FillDr(int.Parse(DropDownList4.SelectedValue), DropDownList5);
            }
            FillGrid();
        }
        protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList5.SelectedValue == "-1")
            {
                //DropDownList6.Visible = false;
                FillDr(0, DropDownList6);
            }
            else
            {
                FillDr(int.Parse(DropDownList5.SelectedValue), DropDownList6);
            }
            FillGrid();
        }
        protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGrid();
        }
}


