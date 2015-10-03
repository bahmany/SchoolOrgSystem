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
        if (!IsPostBack)
        {

            Fill();
        }
    }

    private void Fill()
    {
        int ID = int.Parse(Request.Cookies["ID_Role"].Value.ToString());
        DataTable dt = new tbl_StudentInformationTableAdapter().GetDataByStudent_ID(ID);
        if (dt.Rows.Count > 0)
        {
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

    }

    private void Cancel()
    {
        Fill();
        Label1.Visible = false;

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string Folder1 = "~\\Image_User\\Image_Student\\";
        string File_Name1 = FileUpload1.FileName.ToString().Trim();
        string Address_Full1 = check_name_File(Folder1, File_Name1);
        string pass = "";

        if (TextPassword.Text.Trim().Length > 0)
        {
            pass = new main_class().Encode(TextPassword.Text);
        }
        else
        {
            pass = new main_class().Encode(HiddenField1.Value);
        }
        //////
        if (new tbl_StudentInformationTableAdapter().GetDataByUserName(TextUserName.Text).Rows.Count == 0 || TextUserName.Text == HiddenField2.Value)
        {
            string pic1 = Address_Full1;
            if (FileUpload1.HasFile)
            {
                if (FileUpload1.PostedFile.ContentLength < 5120000)
                {
                    int ID = int.Parse(Request.Cookies["ID_Role"].Value.ToString());
                    new tbl_StudentInformationTableAdapter().UpdateStudent_ID(
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
                    TextAdminCode.Text, TextUserName.Text, pass, ID);

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
                string Pic2 = FileUpload1.ToolTip;
                int ID = int.Parse(Request.Cookies["ID_Role"].Value.ToString());
                new tbl_StudentInformationTableAdapter().UpdateStudent_ID(
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
                    Pic2,
                    TextExportPlace.Text,
                    TextBirthDate.Text,
                    TextAdminCode.Text, TextUserName.Text, pass, ID);
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

            Fill();
            Label1.Text = "عملیات با موفقیت انجام شد";
            Label1.Visible = true;
        }
        else
        {
            Label1.Text = "نام کاربری تکراری می باشد";
            Label1.Visible = true;

        }

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Cancel();
    }
}


