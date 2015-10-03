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
        if (!new main_class().CheckPermissionAdmin("ManageAdmin", int.Parse(Request.Cookies["ID_Role"].Value)))
        {
            Response.Redirect("index.aspx?Type=AdminAccessDenied");
        }
        else
        {
            if (!IsPostBack)
            {

                FillDr(-1, DropDownList1);
                FillDr(int.Parse(DropDownList1.SelectedValue), DropDownList2);
                FillDr(int.Parse(DropDownList2.SelectedValue), DropDownList3);
                FillDr(int.Parse(DropDownList3.SelectedValue), DropDownList4);
                FillDr(int.Parse(DropDownList4.SelectedValue), DropDownList5);
                FillDr(int.Parse(DropDownList5.SelectedValue), DropDownList6);



                Fill();
                FillPath(Request.QueryString["ID_Admin"]);
                FillPart();
                FillPart(int.Parse(Request.QueryString["ID_Admin"]));
            }
        }
    }

    private void FillPart(int  id_admin)
    {
        DataTable dt = new tbl_AdminSecurityTableAdapter().GetDataByAS_ID_Admin(id_admin);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            CheckBoxList1.Items.FindByValue(dt.Rows[i]["AS_Security"].ToString()).Selected = true;
        }

    }

    private void FillPart()
    {
        int id_admin = int.Parse(Request.Cookies["ID_Role"].Value);
        DataTable dt = new tbl_AdminSecurityTableAdapter().GetDataByAS_ID_Admin(id_admin);
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            CheckBoxList1.Items.FindByValue(dt.Rows[i]["AS_Security"].ToString()).Enabled = true;
        }
    }

   


    private void Fill()
    {
        int ID = int.Parse(Request.QueryString["ID_Admin"]);
        DataTable dt = new tbl_AdminPermissionCategoryTableAdapter().GetDataByAPC_ID_Admin(ID);
        if (dt.Rows.Count > 0)
        {
            string delimitedInfo = dt.Rows[0]["APC_Cat_Patch"].ToString();
            string[] discreteInfo = delimitedInfo.Split(new char[] { ',' });
            int i = 1;
            foreach (string Data in discreteInfo)
            {
                if (Data != "-1")
                {
                    ((DropDownList)(FindControl("DropDownList" + i.ToString()))).SelectedIndex = -1;
                    ((DropDownList)(FindControl("DropDownList" + i.ToString()))).Items.FindByValue(Data).Selected = true;
                    if (i <= 5)
                    {
                        FillDr(int.Parse(Data), (DropDownList)FindControl("DropDownList" + (i + 1).ToString()));
                    }
                }
                i++;
            }
            Label1.Visible = true;
            Label1.Text = "برای این مدیر دسترسی زیر تعریف شده است :";
            LinkButton1.Text = "لغو دسترسی";
            PanelDrop.Enabled = true;
        }
        else
        {
            Label1.Text = "برای این مدیر دسترسی ای تعریف نشده است";
            LinkButton1.Text = "ایجاد دسترسی جدید";
            Label1.Visible = true;
            PanelDrop.Enabled = false;

        }
        Label2.Visible = false;

    }

    private void FillPath(string ID)
    {
        DataTable dt = new tbl_AdminInformationTableAdapter().GetDataByID(int.Parse(Request.QueryString["ID_Admin"]));
        string name = dt.Rows[0]["AI_Name"].ToString();
        if (name.Trim().Length == 0)
        {
            name = dt.Rows[0]["AI_UserName"].ToString();
        }
        lblPath.Text = "<a href='./index.aspx?Type=AdminInformationManage'>" +
         "مدیریت مدیران" + "</a>" + " >> مدیریت دسترسی >> " +
         "<a href='./index.aspx?Type=AdminDetail&ID_Admin=" + ID + "'>" + name + "</a> >> ";
    }

    private void FillDr(int ID_Category, DropDownList Dr)
    {
        int ID = int.Parse(Request.Cookies["ID_Role"].Value);
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
                Dr.Items.Add("همه");
                Dr.Items[0].Value = "0";
                Dr.DataSource = new tbl_CategoryTableAdapter().GetDataByID_Root(ID_Category);
                Dr.DataBind();
                Dr.Visible = true;
            }
        }
        else
        {
            Dr.Items.Add("هیچکدام");
            Dr.Items[0].Value = "-2";
            Dr.DataBind();
            Dr.Visible = true;
        }
    }




    protected void Button1_Click(object sender, EventArgs e)
    {
        //new tbl_AdminInformationTableAdapter().Delete(
        if (DropDownList1.SelectedValue != "-2")
        {
            string APC_CatPath = "";
            for (int i = 1; i <= 6; i++)
            {
                DropDownList dr = ((DropDownList)(FindControl("DropDownList" + i.ToString())));
                if (dr.SelectedValue != "0")
                {
                    APC_CatPath = APC_CatPath + dr.SelectedValue + ",";
                }
            }
            if (APC_CatPath.Length == 0)
            {
                APC_CatPath = "-1,";
            }

            APC_CatPath = APC_CatPath.Remove(APC_CatPath.Length - 1, 1);

            int ID = int.Parse(Request.QueryString["ID_Admin"]);
            new tbl_AdminPermissionCategoryTableAdapter().DeleteAPC_ID_Admin(ID);


            new tbl_AdminPermissionCategoryTableAdapter().Insert(APC_CatPath,
                int.Parse(Request.QueryString["ID_Admin"]));

        }
        else
        {

        }
        // Response.Redirect("index.aspx?Type=AdminInformationManage");
        Fill();
        Label2.Visible = true;


    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Fill();
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        new tbl_AdminSecurityTableAdapter().DeleteAS_ID_Admin(int.Parse(Request.QueryString["ID_Admin"]));
        for (int i = 0; i < CheckBoxList1.Items.Count; i++)
        {
            if (CheckBoxList1.Items[i].Selected)
            {
                new tbl_AdminSecurityTableAdapter().Insert(
                    int.Parse(Request.QueryString["ID_Admin"]),
                    CheckBoxList1.Items[i].Value);
            }
        }
        Label3.Visible = true;

    }
    protected void Button4_Click(object sender, EventArgs e)
    {
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue == "-1")
        {
            FillDr(0, DropDownList2);
            FillDr(0, DropDownList3);
            FillDr(0, DropDownList4);
            FillDr(0, DropDownList5);
            FillDr(0, DropDownList6);
        }
        else
        {
            FillDr(int.Parse(DropDownList1.SelectedValue), DropDownList2);
        }

    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList2.SelectedValue == "-1")
        {
            FillDr(0, DropDownList3);
            FillDr(0, DropDownList4);
            FillDr(0, DropDownList5);
            FillDr(0, DropDownList6);
        }
        else
        {
            FillDr(int.Parse(DropDownList2.SelectedValue), DropDownList3);
        }
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList3.SelectedValue == "-1")
        {
            FillDr(0, DropDownList4);
            FillDr(0, DropDownList5);
            FillDr(0, DropDownList6);
        }
        else
        {
            FillDr(int.Parse(DropDownList3.SelectedValue), DropDownList4);
        }
    }
    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList4.SelectedValue == "-1")
        {
            FillDr(0, DropDownList5);
            FillDr(0, DropDownList6);
        }
        else
        {
            FillDr(int.Parse(DropDownList4.SelectedValue), DropDownList5);
        }
    }
    protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList5.SelectedValue == "-1")
        {
            FillDr(0, DropDownList6);
        }
        else
        {
            FillDr(int.Parse(DropDownList5.SelectedValue), DropDownList6);
        }
    }
    protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
    {



    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        if (PanelDrop.Enabled == false)
        {
            PanelDrop.Enabled = true;
        }
        else
        {
            new tbl_AdminPermissionCategoryTableAdapter().DeleteAPC_ID_Admin(int.Parse(Request.QueryString["ID_Admin"]));
            Fill();
            PanelDrop.Enabled = false;
            FillDr(-1, DropDownList1);
            FillDr(int.Parse(DropDownList1.SelectedValue), DropDownList2);
            FillDr(int.Parse(DropDownList2.SelectedValue), DropDownList3);
            FillDr(int.Parse(DropDownList3.SelectedValue), DropDownList4);
            FillDr(int.Parse(DropDownList4.SelectedValue), DropDownList5);
            FillDr(int.Parse(DropDownList5.SelectedValue), DropDownList6);

        }
    }
}
