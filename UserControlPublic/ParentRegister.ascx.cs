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

        }
    }
    private void Cancel()
    {
        TextName.Text = "";
        TextMobile.Text = "";
        TextJob.Text = "";
        TextAddress.Text = "";
        TextTell.Text = "";
        TextUserName.Text = "";
        TextPassword.Text = "";
        TextUserName.Text = "";
        Button1.Visible = true;
        Image1.Visible = false;
        TextCode.Text = "";
        TextStudentCode.Text = "";
        lblError.Visible = false;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string Folder1 = "~\\Image_User\\Image_Parent\\";
        string File_Name1 = FileUpload1.FileName.ToString().Trim();
        string Address_Full1 = check_name_File(Folder1, File_Name1);
        

        ////////////////////////////////////////////////////////////////////////
        string Code = TextCode.Text;
        string StudentCode = TextStudentCode.Text;
        DataTable dt = new tbl_StudentInformationTableAdapter().GetDataByUserNameAndStudentCode(Code, StudentCode);
        if (dt.Rows.Count > 0)
        {
            int id_Student = int.Parse(dt.Rows[0]["Student_ID"].ToString());
            DataTable dt5 = new tbl_ParentInformationTableAdapter().GetDataByPA_ID_Student(id_Student);
            if (dt5.Rows.Count == 0)
            {
                if (new tbl_ParentInformationTableAdapter().GetDataByUsername(TextUserName.Text).Rows.Count == 0)
                {
                    int ID_Stdent = int.Parse(dt.Rows[0]["Student_ID"].ToString());
                    if (FileUpload1.HasFile)
                    {
                        if (FileUpload1.PostedFile.ContentLength < 5120000)
                        {
                            string pic = Address_Full1;
                            new tbl_ParentInformationTableAdapter().Insert1(
                                TextName.Text,
                                TextMobile.Text,
                                TextUserName.Text,
                                new main_class().Encode(TextPassword.Text),
                                ID_Stdent,
                                TextJob.Text,
                                TextTell.Text,
                                TextAddress.Text,
                                pic, new main_class().GetDate(), "");

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
                        string pic1 = "";
                        new tbl_ParentInformationTableAdapter().Insert1(
                            TextName.Text,
                            TextMobile.Text,
                            TextUserName.Text,
                            new main_class().Encode(TextPassword.Text),
                            ID_Stdent,
                            TextJob.Text,
                            TextTell.Text,
                            TextAddress.Text,
                            pic1, new main_class().GetDate(), "");
                        /////////////////////////////////////////
                        if (FileUpload1.HasFile)
                        {
                            Save_File(FileUpload1, Address_Full1);
                        }

                    }

                    lblError.Text = "ثبت نام به درستی انجام شد";
                    lblError.Visible = true;

                }

                else
                {
                    lblError.Text = "نام کاربری وارد شده تکراری میباشد";
                    lblError.Visible = true;
                }
            }
            else
            {
                lblError.Text = "برای این دانش آموز قبلا اولیایی به ثبت رسیده است";
                lblError.Visible = true;

            }
        }
        else
        {
            lblError.Text = "دانش آموزی با این مشخصات یافت نشد";
            lblError.Visible = true;
        }
        //////////// //////////////////////// //////////////////////// //////////////////////// ////////////

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Cancel();
    }
}
      
 




