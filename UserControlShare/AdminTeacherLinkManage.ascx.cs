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
        int i = 0;
        if (Request.Cookies["Type_Role"].Value == "Admin")
        {
            if (!new main_class().CheckPermissionAdmin("ManageLink" , int.Parse(Request.Cookies["ID_Role"].Value)))
            {
                Response.Redirect("index.aspx?Type=AdminAccessDenied");
                i++;
            }
        }

        if (i == 0)
        {
            if (!IsPostBack)
            {
                FillDr(-1, DropDownList1);
                FillDr(int.Parse(DropDownList1.SelectedValue), DropDownList2);
                FillDr(int.Parse(DropDownList2.SelectedValue), DropDownList3);
                FillDr(int.Parse(DropDownList3.SelectedValue), DropDownList4);
                FillDr(int.Parse(DropDownList4.SelectedValue), DropDownList5);
                FillDr(int.Parse(DropDownList5.SelectedValue), DropDownList6);
                FillGrid();


                Label1.Text = "مدیریت لینک های مفید";
                Label2.Text = "در این قسمت میتوانید لینک های مفید را مدیریت نمایید : ";

            }
        }
    }

    private void FillDr(int ID_Category, DropDownList Dr)
    {
        int ID = 0;
        if (Request.Cookies["Type_Role"].Value == "Admin")
        {
            ID = int.Parse(Request.Cookies["ID_Role"].Value);
        }
        else if (Request.Cookies["Type_Role"].Value == "Teacher")
        {
            DataTable dt3 = new tbl_TeacherInformationTableAdapter().GetDataByID(int.Parse(Request.Cookies["ID_Role"].Value));
            ID = int.Parse(dt3.Rows[0]["TI_ID_Admin"].ToString());
        }

        DataTable dt = new tbl_AdminPermissionCategoryTableAdapter().GetDataByAPC_ID_Admin(ID);
        string DR_ID = Dr.ID.Substring(Dr.ID.Length - 1, 1);
        if (dt.Rows.Count > 0)
        {
            string APC_Cat_Patch = dt.Rows[0]["APC_Cat_Patch"].ToString();
            string[] discreteInfo = APC_Cat_Patch.Split(new char[] { ',' });
            int i = 0;
            foreach (string Data in discreteInfo)
            {
                i++;
            }
            Dr.Items.Clear();
            Dr.DataValueField = "Category_ID";
            Dr.DataTextField = "Cat_Title";

            if (i >= int.Parse(DR_ID) && APC_Cat_Patch.Trim() != "-1")
            {
                Dr.DataSource = new tbl_CategoryTableAdapter().GetDataByIDRootPermissionAdmin(ID_Category, APC_Cat_Patch);
                Dr.DataBind();
                Dr.Visible = true;
            }
            else
            {
                if (DR_ID != "1")
                {
                    Dr.Items.Add("همه");
                    Dr.Items[0].Value = "0";
                }
                Dr.DataSource = new tbl_CategoryTableAdapter().GetDataByID_Root(ID_Category);
                Dr.DataBind();
                Dr.Visible = true;
            }
        }
        else
        {
            if (DR_ID != "1")
            {
                Dr.Items.Add("هیچکدام");
                Dr.Items[0].Value = "-2";
                Dr.DataBind();
                Dr.Visible = true;
            }
        }
        if (DR_ID == "1")
        {
            Dr.Items.Insert(0, "عمومی");
            Dr.Items[0].Value = "-10";
            Dr.Visible = true;

        }
    }

    private void FillGrid()
    {
        int ID_Category = -10;
        if (DropDownList6.SelectedValue != "0")
        {
            ID_Category = int.Parse(DropDownList6.SelectedValue.ToString());
        }
        else if (DropDownList5.SelectedValue != "0")
        {
            ID_Category = int.Parse(DropDownList5.SelectedValue.ToString());
        }
        else if (DropDownList4.SelectedValue != "0")
        {
            ID_Category = int.Parse(DropDownList4.SelectedValue.ToString());
        }
        else if (DropDownList3.SelectedValue != "0")
        {
            ID_Category = int.Parse(DropDownList3.SelectedValue.ToString());
        }
        else if (DropDownList2.SelectedValue != "0")
        {
            ID_Category = int.Parse(DropDownList2.SelectedValue.ToString());
        }
        else if (DropDownList1.SelectedValue != "0")
        {
            ID_Category = int.Parse(DropDownList1.SelectedValue.ToString());
        }
        else
        {
            ID_Category = -10;
        }


        if (Request.Cookies["Type_Role"].Value.ToString() == "Admin")
        {

            GridView1.SelectedIndex = -1;
            GridView1.DataSource = new tbl_LinkTableAdapter().GetDataByCategory(ID_Category);
            GridView1.DataBind();

        }
        else if (Request.Cookies["Type_Role"].Value.ToString() == "Teacher")
        {

            GridView1.SelectedIndex = -1;
            GridView1.DataSource = new tbl_LinkTableAdapter().GetDataByCategoryIDType(int.Parse(Request.Cookies["ID_Role"].Value.ToString()), Request.Cookies["Type_Role"].Value.ToString(), ID_Category);
            GridView1.DataBind();


            GridView1.Columns[2].Visible = false;
        }

    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int ID = int.Parse(((Label)(GridView1.Rows[e.RowIndex].FindControl("lblID"))).Text);
        new tbl_LinkTableAdapter().Delete(ID);
        FillGrid();

    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {


    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        FillGrid();
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

        FillDr(0, DropDownList3);
        FillDr(0, DropDownList4);
        FillDr(0, DropDownList5);
        FillDr(0, DropDownList6);
        FillDr(int.Parse(DropDownList1.SelectedValue), DropDownList2);

        FillGrid();

    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {

        FillDr(0, DropDownList4);
        FillDr(0, DropDownList5);
        FillDr(0, DropDownList6);
        FillDr(int.Parse(DropDownList2.SelectedValue), DropDownList3);

        FillGrid();
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {

        FillDr(0, DropDownList5);
        FillDr(0, DropDownList6);
        FillDr(int.Parse(DropDownList3.SelectedValue), DropDownList4);

        FillGrid();
    }
    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {

        FillDr(0, DropDownList6);
        FillDr(int.Parse(DropDownList4.SelectedValue), DropDownList5);

        FillGrid();
    }
    protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
    {

        FillDr(int.Parse(DropDownList5.SelectedValue), DropDownList6);

        FillGrid();
    }
    protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGrid();
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            int ID_Role = int.Parse(((Label)(e.Row.FindControl("ID_Role"))).Text);

            if (((Label)(e.Row.FindControl("Type_Role"))).Text == "Admin")
            {
                DataTable dt = new tbl_AdminInformationTableAdapter().GetDataByID(ID_Role);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["AI_Name"].ToString().Length > 0)
                    {
                        ((Label)(e.Row.FindControl("lblName"))).Text = dt.Rows[0]["AI_Name"].ToString();
                    }
                    else
                    {
                        ((Label)(e.Row.FindControl("lblName"))).Text = dt.Rows[0]["AI_UserName"].ToString();
                    }
                    ((Label)(e.Row.FindControl("lblName"))).Text = "<a href='index.aspx?Type=AdminDetail&ID_Admin=" + ID_Role.ToString() +
                           "'>" + ((Label)(e.Row.FindControl("lblName"))).Text + " ( مدیر ) " + "</a>";
                }
            }
            else if (((Label)(e.Row.FindControl("Type_Role"))).Text == "Teacher")
            {
                DataTable dt = new tbl_TeacherInformationTableAdapter().GetDataByID(ID_Role);
                if (dt.Rows.Count > 0)
                {
                    if (dt.Rows[0]["TI_Name"].ToString().Length > 0)
                    {
                        ((Label)(e.Row.FindControl("lblName"))).Text = dt.Rows[0]["TI_Name"].ToString();
                    }
                    else
                    {
                        ((Label)(e.Row.FindControl("lblName"))).Text = dt.Rows[0]["TI_UserName"].ToString();
                    }
                    ((Label)(e.Row.FindControl("lblName"))).Text = "<a href='index.aspx?Type=TeacherDetail&ID_Teacher=" + ID_Role.ToString() +
                          "'>" + ((Label)(e.Row.FindControl("lblName"))).Text + " ( معلم ) " + "</a>";
                }
            }
        }

    }
}


