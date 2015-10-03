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
    public void Save_File(System.Web.UI.WebControls.FileUpload File_Upload, string Address)
    {
        string str = "";
        str = Server.MapPath(Address);
        File_Upload.PostedFile.SaveAs(str);
    }
    string check_name_File(string Folder, string File_Name)
    {
        while (System.IO.File.Exists(Server.MapPath(Folder + File_Name)))
            File_Name = 'a' + File_Name;
        return Folder + File_Name;
    }
    public string AuthorContent = "";
    public string DateContent = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        int i = 0;
        string TypeContent = Request.QueryString["TypeContent"].ToString();
        if (Request.Cookies["Type_Role"].Value == "Admin")
        {
            if (!new main_class().CheckPermissionAdmin("Manage" + TypeContent, int.Parse(Request.Cookies["ID_Role"].Value)))
            {
                Response.Redirect("index.aspx?Type=AdminAccessDenied");
                i++;
            }
        }
       
        if(i==0)
        {
            FillPath();

            if (!IsPostBack)
            {

                FillDr(-1, DropDownList1);
                FillDr(int.Parse(DropDownList1.SelectedValue), DropDownList2);
                FillDr(int.Parse(DropDownList2.SelectedValue), DropDownList3);
                FillDr(int.Parse(DropDownList3.SelectedValue), DropDownList4);
                FillDr(int.Parse(DropDownList4.SelectedValue), DropDownList5);
                FillDr(int.Parse(DropDownList5.SelectedValue), DropDownList6);
                if (Request.QueryString["Content_ID"] != null)
                {
                    Fill();
                }
                if (Request.Cookies["Type_Role"].Value.ToString() == "Admin")
                {
                    CheckBox1.Visible = true;
                }
                if (TypeContent == "News")
                {
                    Label1.Text = "ویرایش و ثبت اخبار و اطلاعیه ها";
                    Label2.Text = "در این قسمت میتوانید اخبار و اطلاعیه ها  را ایجاد و یا ویرایش نمایید : ";
                }
                else if (TypeContent == "Library")
                {
                    Label1.Text = "ویرایش و ثبت کتابخانه و مقالات";
                    Label2.Text = "در این قسمت میتوانید کتابخانه و مقالات  را ایجاد و یا ویرایش نمایید : ";
                }
                else if (TypeContent == "Break")
                {
                    Label1.Text = "ویرایش و ثبت زنگ تفریح ";
                    Label2.Text = "در این قسمت میتوانید زنگ تفریح  را ایجاد و یا ویرایش نمایید : ";
                }
            }
        }
    }

    private void Fill()
    {
        int ID = int.Parse(Request.QueryString["Content_ID"].ToString());
        DataTable dt = new tbl_ContentTableAdapter().GetDataByContent_ID(ID);
        if (dt.Rows.Count > 0)
        {
            LblHidden.ToolTip = Request.QueryString["Content_ID"].ToString();
            TextTitle.Text = dt.Rows[0]["Con_Title"].ToString();
            FCKeditor1.Value = dt.Rows[0]["Con_Text"].ToString();
            FileUpload1.ToolTip = dt.Rows[0]["Con_Attach"].ToString();
            CheckBox1.Checked = bool.Parse(dt.Rows[0]["Con_Active"].ToString());
            DateContent = dt.Rows[0]["Con_date"].ToString();
            Panel1.Visible = true;
            Panel2.Visible = true;
            FillPath(dt.Rows[0]["Con_Type_Role"].ToString(), dt.Rows[0]["Con_ID_Role"].ToString());

        }
        FillDr(-1, DropDownList1);
        DataTable dt2 = new tbl_CategoryTableAdapter().GetDataByID(int.Parse(dt.Rows[0]["Con_ID_Category"].ToString()));
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
            ((DropDownList)(FindControl("DropDownList" + (i - 1).ToString()))).Items.FindByValue(dt.Rows[0]["Con_ID_Category"].ToString()).Selected = true;

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
        string Type = Request.QueryString["TypeContent"].ToString();
        string title = "";
        if (Type == "News")
        {
            title = "مدیریت اطلاعیه و خبر";
        }
        else if (Type == "Break")
        {
            title = "مدیریت زنگ تفریح";
        }
        else if (Type == "Library")
        {
            title = "مدیریت کتاب ها و مقالات";
        }

        lblPath.Text = lblPath.Text +
            "<a href='./index.aspx?Type=AdminContentManage&TypeContent=" + Type + "'>" +
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
        FCKeditor1.Value = "";

        Button1.Visible = true;
        Button3.Visible = false;
        LblHidden.ToolTip = "";

        FileUpload1.ToolTip = "";

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string Folder1 = "~\\Image_User\\File_Content\\";
        string File_Name1 = FileUpload1.FileName.ToString().Trim();
        string Address_Full1 = check_name_File(Folder1, File_Name1);
        //////
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
        string Attach1 = "";
        string Attach = "";
        int i = 0;
        if (LblHidden.ToolTip.Length == 0)
        {
            if (FileUpload1.HasFile)
            {
                if (FileUpload1.PostedFile.ContentLength < 5120000)
                {
                     Attach = Address_Full1; 
                }
                else
                {
                    i++;
                    Response.Write("<script>alert('حجم باید کمتر از 5000 کیلو بایت باشد')</script>");
                }
            }
            else
            {
                 Attach = "";
            }
            if (i == 0)
            {
                new tbl_ContentTableAdapter().Insert1(
                            TextTitle.Text,
                            FCKeditor1.Value,
                            Attach,
                            "False",
                            new main_class().GetDate(),
                            Request.QueryString["TypeContent"].ToString(),
                             Request.Cookies["Type_Role"].Value.ToString(),
                              int.Parse(Request.Cookies["ID_Role"].Value.ToString()),
                            ID_Category);
                if (FileUpload1.HasFile)
                {
                    Save_File(FileUpload1, Address_Full1);
                }
            }
        }
        else
        {
            if (FileUpload1.HasFile)
            {
                if (FileUpload1.PostedFile.ContentLength < 5120000)
                {
                     Attach1 = Address_Full1;
                }
                else
                {
                    i++;
                    Response.Write("<script>alert('حجم باید کمتر از 5000 کیلو بایت باشد')</script>");
                }
            }
            else
            {
                 Attach1 = FileUpload1.ToolTip;
            }
            if (i == 0)
            {
                int ID = int.Parse(Request.QueryString["Content_ID"].ToString());
                new tbl_ContentTableAdapter().Update1(
                    TextTitle.Text,
                    FCKeditor1.Value,
                    Attach1,
                   CheckBox1.Checked.ToString(),
                    new main_class().GetDate(),
                    ID_Category, ID);

                /////////////////////////////////////////
                if (FileUpload1.HasFile)
                {
                    Save_File(FileUpload1, Address_Full1);
                    if (System.IO.File.Exists(Server.MapPath(FileUpload1.ToolTip)))
                    {
                        System.IO.File.Delete(Server.MapPath(FileUpload1.ToolTip));
                    }
                }
            }
        }




        if (Request.Cookies["Type_Role"].Value.ToString() == "Admin")
        {
            Response.Redirect("~//index.aspx?Type=AdminContentManage&TypeContent="+ Request.QueryString["TypeContent"].ToString());
        }
        else if(Request.Cookies["Type_Role"].Value.ToString() == "Teacher")
        {
            Response.Redirect("~//index.aspx?Type=TeacherContentManage&TypeContent="+ Request.QueryString["TypeContent"].ToString());
        }

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


