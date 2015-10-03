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
    
    public string AuthorContent = "";
    public string DateContent = "";

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
                if (Request.QueryString["Link_ID"] != null)
                {
                    Fill();
                }
                if (Request.Cookies["Type_Role"].Value.ToString() == "Admin")
                {
                    CheckBox1.Visible = true;
                }

                Label1.Text = "ویرایش و ثبت لینک ها";
                Label2.Text = "در این قسمت میتوانید لینک هایی  را ایجاد و یا ویرایش نمایید : ";

            }
        }
    }

    private void Fill()
    {
        int ID = int.Parse(Request.QueryString["Link_ID"].ToString());
        DataTable dt = new tbl_LinkTableAdapter().GetDataByLink_ID(ID);
        if (dt.Rows.Count > 0)
        {
            LblHidden.ToolTip = Request.QueryString["Link_ID"].ToString();
            TextTitle.Text = dt.Rows[0]["li_Title"].ToString();
            txtLink.Text = dt.Rows[0]["li_link"].ToString();
            CheckBox1.Checked = bool.Parse(dt.Rows[0]["li_Active"].ToString());
            Panel1.Visible = true;
            Panel2.Visible = true;
            FillPath(dt.Rows[0]["li_Type_Role"].ToString(), dt.Rows[0]["li_ID_Role"].ToString());
            FillPath();

        }
        FillDr(-1, DropDownList1);
        DataTable dt2 = new tbl_CategoryTableAdapter().GetDataByID(int.Parse(dt.Rows[0]["li_ID_Category"].ToString()));
        if (dt2.Rows.Count > 0)
        {
            string delimitedInfo = dt2.Rows[0]["Cat_Path"].ToString();
            string[] discreteInfo = delimitedInfo.Split(new char[] { ',' });
            int i = 1;
            foreach (string Data in discreteInfo)
            {
                if (Data == "-1")
                {
                    FillDr(int.Parse(Data), (DropDownList)FindControl("DropDownList" + i.ToString()));
                }
                else
                {
                    ((DropDownList)(FindControl("DropDownList" + (i - 1).ToString()))).Items.FindByValue(Data).Selected = true;
                    FillDr(int.Parse(Data), (DropDownList)FindControl("DropDownList" + i.ToString()));
                }
                i++;
            }
            ((DropDownList)(FindControl("DropDownList" + (i - 1).ToString()))).Items.FindByValue(dt.Rows[0]["li_ID_Category"].ToString()).Selected = true;

        }
    }
    private void FillPath(string Type, string ID)
    {
        string title = "";
        string name = "";

        DataTable dt;
        if (Type == "Admin")
        {
            dt = new tbl_AdminInformationTableAdapter().GetDataByID(int.Parse(ID));
            name = dt.Rows[0]["AI_name"].ToString();
            if (name.Trim().Length == 0)
            {
                name = dt.Rows[0]["AI_username"].ToString();
            }
            title = "مدیر";
        }
        else if (Type == "Teacher")
        {
            dt = new tbl_TeacherInformationTableAdapter().GetDataByID(int.Parse(ID));
            name = dt.Rows[0]["TI_name"].ToString();
            if (name.Trim().Length == 0)
            {
                name = dt.Rows[0]["TI_username"].ToString();
            }
            title = " معلم ";
        }
       
            AuthorContent = " <a href='./index.aspx?Type=" + Type + "Detail&" +
                "ID_" + Type + "=" + ID + "'>" + name + " ( "+ title+ " )</a>";
    }
    private void FillPath()
    {
        string title = "";
       
            title = "مدیریت لینک ها";
        
       

        lblPath.Text = lblPath.Text +
            "<a href='./index.aspx?Type=LinkManage'>" +
            title + "</a>" + " >> " ;


    }

    private void FillDr(int ID_Category,DropDownList Dr)
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


    private void Cancel()
    {
        TextTitle.Text = "";
        txtLink.Text = "";

        Button1.Visible = true;
        Button3.Visible = false;
        LblHidden.ToolTip = "";


    }

    protected void Button1_Click(object sender, EventArgs e)
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

        if (LblHidden.ToolTip.Length == 0)
        {

            new tbl_LinkTableAdapter().Insert(
                        TextTitle.Text,
                        txtLink.Text,
                        CheckBox1.Checked.ToString(),
                         int.Parse(Request.Cookies["ID_Role"].Value.ToString()),
                         Request.Cookies["Type_Role"].Value.ToString(),
                        ID_Category);
        }
        else
        {

            int ID = int.Parse(Request.QueryString["Link_ID"].ToString());
            new tbl_LinkTableAdapter().Update(
                TextTitle.Text,
                        txtLink.Text,
                        CheckBox1.Checked.ToString(),
                         int.Parse(Request.Cookies["ID_Role"].Value.ToString()),
                         Request.Cookies["Type_Role"].Value.ToString(),
                        ID_Category, ID);

        }
        Response.Redirect("~//index.aspx?Type=LinkManage");

    }
        protected void Button2_Click(object sender, EventArgs e)
        {
            Cancel();
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                FillDr(0, DropDownList2);
                FillDr(0, DropDownList3);
                FillDr(0, DropDownList4);
                FillDr(0, DropDownList5);
                FillDr(0, DropDownList6);
            
            
                FillDr(int.Parse(DropDownList1.SelectedValue), DropDownList2);
            
           
        }
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                FillDr(0, DropDownList3);
                FillDr(0, DropDownList4);
                FillDr(0, DropDownList5);
                FillDr(0, DropDownList6);
           
                FillDr(int.Parse(DropDownList2.SelectedValue), DropDownList3);
            
        }
        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
          
                FillDr(0, DropDownList4);
                FillDr(0, DropDownList5);
                FillDr(0, DropDownList6);
           
                FillDr(int.Parse(DropDownList3.SelectedValue), DropDownList4);
            
        }
        protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
        {
                FillDr(0, DropDownList5);
                FillDr(0, DropDownList6);
           
                FillDr(int.Parse(DropDownList4.SelectedValue), DropDownList5);
            
        }
        protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
        {
           
                FillDr(0, DropDownList6);
           
                FillDr(int.Parse(DropDownList5.SelectedValue), DropDownList6);
            
        }
        protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


}


