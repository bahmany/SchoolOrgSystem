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
        if(!IsPostBack)
        {
            fill();
        }
    }

    private void Cancel()
    {
        Label1.Visible = false;
        fill();

    }
    void fill()
    {
        int ID =int.Parse( Request.Cookies["ID_Role"].Value.ToString());
        DataTable dt = new tbl_AdminInformationTableAdapter().GetDataByID(ID);
        if (dt.Rows.Count > 0)
        {
            TextName.Text = dt.Rows[0]["AI_Name"].ToString();
            TextFatherName.Text = dt.Rows[0]["AI_FatherName"].ToString();
            TextAddress.Text = dt.Rows[0]["AI_Address"].ToString();
            TextTell.Text = dt.Rows[0]["AI_Tell"].ToString();
            TextPostalCode.Text = dt.Rows[0]["AI_PostalCode"].ToString();
            TextExportPlace.Text = dt.Rows[0]["AI_ExportPlace"].ToString();
            TextBirthDate.Text = dt.Rows[0]["AI_BirthDate"].ToString();
            TextAdminCode.Text = dt.Rows[0]["AI_AdminCode"].ToString();
            TextUserName.Text = dt.Rows[0]["AI_UserName"].ToString();
            HiddenField2.Value= dt.Rows[0]["AI_UserName"].ToString();
            HiddenField1.Value = new main_class().Decode(dt.Rows[0]["AI_Password"].ToString());
            TextRoll.Text = dt.Rows[0]["AI_Role_Admin"].ToString();
            Image1.ImageUrl = dt.Rows[0]["AI_Pic"].ToString();
            if (System.IO.File.Exists(Server.MapPath( Image1.ImageUrl)))
            {
                Image1.Visible = true;
            }
            else
            {
                Image1.Visible = true;
                Image1.ImageUrl = "~//Image_User//default_pic.png";
            }
            FileUpload1.ToolTip = dt.Rows[0]["AI_Pic"].ToString();

        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string Folder1 = "~\\Image_User\\Image_Admin\\";
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
        if (new tbl_AdminInformationTableAdapter().GetDataByUserName(TextUserName.Text).Rows.Count == 0 || TextUserName.Text==HiddenField2.Value)
        {
            if (FileUpload1.HasFile)
            {
                if (FileUpload1.PostedFile.ContentLength < 5120000)
                {
                    string pic = Address_Full1;

                    int ID = int.Parse(Request.Cookies["ID_Role"].Value.ToString());

                    new tbl_AdminInformationTableAdapter().Update1(
                        TextName.Text,
                        TextFatherName.Text,
                        TextAddress.Text,
                        TextTell.Text,
                        TextPostalCode.Text,
                        TextExportPlace.Text,
                        TextBirthDate.Text,
                        TextAdminCode.Text, TextUserName.Text, pass, TextRoll.Text, pic, ID);

                }
                else
                {
                    Response.Write("<script>alert('حجم باید کمتر از 5000 کیلو بایت باشد')</script>");
                }
            }
            else
            {
                string pic = FileUpload1.ToolTip;
                int ID = int.Parse(Request.Cookies["ID_Role"].Value.ToString());
                new tbl_AdminInformationTableAdapter().Update1(
                    TextName.Text,
                    TextFatherName.Text,
                    TextAddress.Text,
                    TextTell.Text,
                    TextPostalCode.Text,
                    TextExportPlace.Text,
                    TextBirthDate.Text,
                    TextAdminCode.Text, TextUserName.Text, pass, TextRoll.Text, pic, ID);

            }
            /////////////////////////////////////////
            if (FileUpload1.HasFile)
            {
                Save_File(FileUpload1, Address_Full1);
                if (System.IO.File.Exists(Server.MapPath(FileUpload1.ToolTip)))
                {
                    System.IO.File.Delete(Server.MapPath(FileUpload1.ToolTip));
                }
            }

            fill();
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


