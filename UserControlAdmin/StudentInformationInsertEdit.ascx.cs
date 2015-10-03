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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!new main_class().CheckPermissionAdmin("ManageStudent", int.Parse(Request.Cookies["ID_Role"].Value)))
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
                if (Request.QueryString["Student_ID"] != null)
                {
                    Fill();
                    RequiredFieldValidator2.Visible = false;
                    RequiredFieldValidator3.Visible = false;
                }
            }
        }
    }

    private void Fill()
    {
        int ID = int.Parse(Request.QueryString["Student_ID"].ToString());
        DataTable dt = new tbl_StudentInformationTableAdapter().GetDataByStudent_ID(ID);
        if (dt.Rows.Count > 0)
        {
            LblHidden.ToolTip = Request.QueryString["Student_ID"].ToString();
            TextName.Text = dt.Rows[0]["SI_Name"].ToString();
            TextFatherMobile.Text = dt.Rows[0]["SI_FatherMobile"].ToString();
            TextFatherName.Text = dt.Rows[0]["SI_FatherName"].ToString();
            TextFatherJob.Text = dt.Rows[0]["SI_FatherJob"].ToString();
            TextMotherMobile.Text = dt.Rows[0]["SI_MotherMobile"].ToString();
            TextMotherName.Text = dt.Rows[0]["SI_MotherName"].ToString();
            TextMotherJob.Text = dt.Rows[0]["SI_MotherJob"].ToString();
            TextAddress.Text = dt.Rows[0]["SI_Address"].ToString();
            TextTell.Text = dt.Rows[0]["SI_Tell"].ToString();
            TextPostalCode.Text = dt.Rows[0]["SI_PostalCode"].ToString();
            TextExportPlace.Text = dt.Rows[0]["SI_ExportPlace"].ToString();
            TextBirthDate.Text = dt.Rows[0]["SI_BirthDate"].ToString();
            TextAdminCode.Text = dt.Rows[0]["SI_StudentCode"].ToString();
            TextUserName.Text = dt.Rows[0]["SI_UserName"].ToString();
            HiddenField2.Value = dt.Rows[0]["SI_UserName"].ToString();
            HiddenField1.Value = new main_class().Decode(dt.Rows[0]["SI_Password"].ToString());
            Image1.Visible = true;
            Image1.ImageUrl = dt.Rows[0]["SI_Picture"].ToString();
            if (System.IO.File.Exists(Server.MapPath(Image1.ImageUrl)))
            {
                Image1.Visible = true;
            }
            else
            {
                Image1.Visible = true;
                Image1.ImageUrl = "~//Image_User//default_pic.png";
            }
        }
        FillDr(-1, DropDownList1);
        DataTable dt2 = new tbl_CategoryTableAdapter().GetDataByID(int.Parse(dt.Rows[0]["SI_ID_Category"].ToString()));
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
            ((DropDownList)(FindControl("DropDownList" + (i - 1).ToString()))).Items.FindByValue(dt.Rows[0]["SI_ID_Category"].ToString()).Selected = true;

            if (i != 6)
            {
                FillDr(int.Parse(dt.Rows[0]["SI_ID_Category"].ToString()), (DropDownList)FindControl("DropDownList" + (i + 1).ToString()));
            }
        }
        Panel1.Visible = true;
        FillPath("Student", dt.Rows[0]["Student_ID"].ToString());


    }
    private void FillPath(string Type, string ID)
    {
        string title = "";
        string name = "";

        DataTable dt = new tbl_StudentInformationTableAdapter().GetDataByStudent_ID(int.Parse(ID));
        name = dt.Rows[0]["SI_name"].ToString();
        if (name.Trim().Length == 0)
        {
            name = dt.Rows[0]["SI_username"].ToString();
        }
        title = "مدیریت دانش آموزان";
        lblPath.Text = lblPath.Text + "<a href='./index.aspx?Type=StudentInformationManage'>" +
            title + "</a>" + " >> " +
            "<a href='./index.aspx?Type=AdminEditStudent&Student_ID=" + ID + "'>" +
            name + "</a>";


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


    private void Cancel()
    {
        TextName.Text = "";
        TextFatherMobile.Text = "";
        TextFatherName.Text = "";
        TextFatherJob.Text = "";

        TextMotherMobile.Text = "";
        TextMotherName.Text = "";
        TextMotherJob.Text = "";

        TextAddress.Text = "";
        TextTell.Text = "";
        TextPostalCode.Text = "";
        TextExportPlace.Text = "";
        TextBirthDate.Text = "";
        TextAdminCode.Text = "";
        TextUserName.Text = "";
        TextPassword.Text = "";
        TextUserName.Text = "";
        Button1.Visible = true;
        Button3.Visible = false;
        LblHidden.ToolTip = "";
        Image1.Visible = false;
        FileUpload1.ToolTip = "";

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string Folder1 = "~\\Image_User\\Image_Student\\";
        string File_Name1 = FileUpload1.FileName.ToString().Trim();
        string Address_Full1 = check_name_File(Folder1, File_Name1);
        //////
        string pass = "";

        if (TextPassword.Text.Trim().Length > 0)
        {
            pass = new main_class().Encode(TextPassword.Text);
        }
        else
        {
            pass = new main_class().Encode(HiddenField1.Value);
        }
        if (LblHidden.ToolTip.Length == 0)
        {
            if (new tbl_StudentInformationTableAdapter().GetDataByUserName(TextUserName.Text).Rows.Count == 0)
            {
                if (FileUpload1.HasFile)
                {
                    if (FileUpload1.PostedFile.ContentLength < 5120000)
                    {
                        string pic = Address_Full1;
                        int ID_Category = 0;
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
                            ID_Category = 0;
                        }
                        new tbl_StudentInformationTableAdapter().Insert1(
                            TextName.Text,
                            TextFatherName.Text,
                            TextFatherMobile.Text,
                            TextFatherJob.Text,
                            TextMotherName.Text,
                            TextMotherJob.Text,
                            TextMotherMobile.Text,
                            TextAddress.Text,
                            TextTell.Text,
                            TextPostalCode.Text,
                            pic,
                            TextExportPlace.Text,
                            TextBirthDate.Text,
                            TextAdminCode.Text, TextUserName.Text, pass, ID_Category, new main_class().GetDate(), "",
                            int.Parse(Request.Cookies["ID_Role"].Value));

                        /////////////////////////////////////////
                        if (FileUpload1.HasFile)
                        {
                            Save_File(FileUpload1, Address_Full1);
                        }
                    }
                    else
                    {
                        Response.Write("<script>alert('حجم باید کمتر از 5000 کیلو بایت باشد')</script>");
                    }
                }
                else
                {
                    #region Parameter
                    string pic = "";
                    int ID_Category = 0;
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
                        ID_Category = 0;
                    }
                    #endregion
                    new tbl_StudentInformationTableAdapter().Insert1(
                        TextName.Text,
                        TextFatherName.Text,
                        TextFatherMobile.Text,
                        TextFatherJob.Text,
                        TextMotherName.Text,
                        TextMotherJob.Text,
                        TextMotherMobile.Text,
                        TextAddress.Text,
                        TextTell.Text,
                        TextPostalCode.Text,
                        pic,
                        TextExportPlace.Text,
                        TextBirthDate.Text,
                        TextAdminCode.Text, TextUserName.Text, pass, ID_Category, new main_class().GetDate(), "",
                        int.Parse(Request.Cookies["ID_Role"].Value));
                    /////////////////////////////////////////
                    if (FileUpload1.HasFile)
                    {
                        Save_File(FileUpload1, Address_Full1);
                    }

                }
                Response.Redirect("~//index.aspx?Type=StudentInformationManage");

            }
            else
            {
                Label1.Text = "نام کاربری تکراری می باشد";
                Label1.Visible = true;
            }
        }
        else
        {
            if (new tbl_StudentInformationTableAdapter().GetDataByUserName(TextUserName.Text).Rows.Count == 0 || TextUserName.Text == HiddenField2.Value)
            {

                if (FileUpload1.HasFile)
                {
                    if (FileUpload1.PostedFile.ContentLength < 5120000)
                    {
                        #region Parameter
                        string pic1 = Address_Full1;
                        int ID_Category = 0;
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
                            ID_Category = 0;
                        }
                        #endregion

                        int ID = int.Parse(Request.QueryString["Student_ID"].ToString());
                        new tbl_StudentInformationTableAdapter().Update1(
                        TextName.Text,
                        TextFatherName.Text,
                        TextFatherMobile.Text,
                        TextFatherJob.Text,
                        TextMotherName.Text,
                        TextMotherJob.Text,
                        TextMotherMobile.Text,
                        TextAddress.Text,
                        TextTell.Text,
                        TextPostalCode.Text,
                        pic1,
                        TextExportPlace.Text,
                        TextBirthDate.Text,
                        TextAdminCode.Text, TextUserName.Text, pass, ID_Category, ID);

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
                    else
                    {
                        Response.Write("<script>alert('حجم باید کمتر از 5000 کیلو بایت باشد')</script>");
                    }
                }
                else
                {
                    #region Parameter
                    string pic1 = FileUpload1.ToolTip;
                    int ID_Category = 0;
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
                        ID_Category = 0;
                    }
                    #endregion


                    int ID = int.Parse(Request.QueryString["Student_ID"].ToString());
                    new tbl_StudentInformationTableAdapter().Update1(
                        TextName.Text,
                        TextFatherName.Text,
                        TextFatherMobile.Text,
                        TextFatherJob.Text,
                        TextMotherName.Text,
                        TextMotherJob.Text,
                        TextMotherMobile.Text,
                        TextAddress.Text,
                        TextTell.Text,
                        TextPostalCode.Text,
                        pic1,
                        TextExportPlace.Text,
                        TextBirthDate.Text,
                        TextAdminCode.Text, TextUserName.Text, pass, ID_Category, ID);
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
                Response.Redirect("~//index.aspx?Type=StudentInformationManage");

            }
            else
            {
                Label1.Text = "نام کاربری تکراری می باشد";
                Label1.Visible = true;
            }
        }

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["Student_ID"] != null)
        {
            Fill();
        }
        else
        {
            Cancel();
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDr(0, DropDownList3);
        FillDr(0, DropDownList4);
        FillDr(0, DropDownList5);
        FillDr(0, DropDownList6);

        FillDr(int.Parse(DropDownList1.SelectedValue), DropDownList2);


    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDr(0, DropDownList4);
        FillDr(0, DropDownList5);
        FillDr(0, DropDownList6);
        FillDr(int.Parse(DropDownList2.SelectedValue), DropDownList3);

    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillDr(0, DropDownList5);
        FillDr(0, DropDownList6);

        FillDr(int.Parse(DropDownList3.SelectedValue), DropDownList4);

    }
    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {

        FillDr(0, DropDownList6);

        FillDr(int.Parse(DropDownList4.SelectedValue), DropDownList5);

    }
    protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
    {

        FillDr(int.Parse(DropDownList5.SelectedValue), DropDownList6);

    }
    protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}


