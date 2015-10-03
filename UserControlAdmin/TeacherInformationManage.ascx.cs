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
        if (!new main_class().CheckPermissionAdmin("ManageTeacher", int.Parse(Request.Cookies["ID_Role"].Value)))
        {
            Response.Redirect("index.aspx?Type=AdminAccessDenied");
        }
        else
        {
            if (!IsPostBack)
            {
                FillGrid();
            }
        }
    }
    private void FillGrid()
    {
        GridView1.SelectedIndex = -1;
        GridView1.DataSource = new tbl_TeacherInformationTableAdapter().GetDataByTI_ID_Admin(int.Parse(Request.Cookies["ID_Role"].Value));
        GridView1.DataBind();
    }
    private void Cancel()
    {
        TextName.Text = "";
        TextFatherName.Text = "";
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
        GridView1.SelectedIndex = -1;
        Image1.Visible = false;
        FileUpload1.ToolTip = "";
        Label1.Visible = false;

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string Folder1 = "~\\Image_User\\Image_Teacher\\";
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
        if (LblHidden.ToolTip.Length == 0)
        {
            if (new tbl_TeacherInformationTableAdapter().GetDataByUserName(TextUserName.Text).Rows.Count == 0)
            {
            if (FileUpload1.HasFile)
            {
                

                    if (FileUpload1.PostedFile.ContentLength < 5120000)
                    {
                        string pic = Address_Full1;
                        new tbl_TeacherInformationTableAdapter().Insert1(
                            TextName.Text,
                            TextFatherName.Text,
                            TextAddress.Text,
                            TextTell.Text,
                            pic,
                            TextPostalCode.Text,
                            TextExportPlace.Text,
                            TextBirthDate.Text,
                            TextAdminCode.Text, TextUserName.Text, pass, new main_class().GetDate(), "",
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
                    string pic = "";
                    new tbl_TeacherInformationTableAdapter().Insert1(
                        TextName.Text,
                        TextFatherName.Text,
                        TextAddress.Text,
                        TextTell.Text,
                        pic,
                        TextPostalCode.Text,
                        TextExportPlace.Text,
                        TextBirthDate.Text,
                        TextAdminCode.Text, TextUserName.Text, pass, new main_class().GetDate(), "",
                        int.Parse(Request.Cookies["ID_Role"].Value));
                    /////////////////////////////////////////
                    if (FileUpload1.HasFile)
                    {
                        Save_File(FileUpload1, Address_Full1);
                    }

                }
                FillGrid();
                Cancel();

            }
            else
            {
                Label1.Text = "نام کاربری تکراری می باشد";
                Label1.Visible = true;
            }
        }
        else
        {
            if (new tbl_TeacherInformationTableAdapter().GetDataByUserName(TextUserName.Text).Rows.Count == 0 || TextUserName.Text == HiddenField2.Value)
            {

                if (FileUpload1.HasFile)
                {
                    if (FileUpload1.PostedFile.ContentLength < 5120000)
                    {
                        string pic1 = Address_Full1;
                        int ID = int.Parse(LblHidden.ToolTip);
                        new tbl_TeacherInformationTableAdapter().Update1(
                            TextName.Text,
                            TextFatherName.Text,
                            TextAddress.Text,
                            TextTell.Text,
                            pic1,
                            TextPostalCode.Text,
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
                    string pic1 = FileUpload1.ToolTip; ;
                    int ID = int.Parse(LblHidden.ToolTip);
                    new tbl_TeacherInformationTableAdapter().Update1(
                        TextName.Text,
                        TextFatherName.Text,
                        TextAddress.Text,
                        TextTell.Text,
                        pic1,
                        TextPostalCode.Text,
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
                FillGrid();
                Cancel();

            }
            else
            {
                Label1.Text = "نام کاربری تکراری می باشد";
                Label1.Visible = true;
            }
        }


    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int ID = int.Parse(((Label)(GridView1.Rows[e.RowIndex].FindControl("lblID"))).Text);


        int i = 0;

        // Delete Lesson
        DataTable dt3 = new tbl_LessonTableAdapter().GetDataByAllTeacher(ID);
        for (i = 0; i < dt3.Rows.Count; i++)
        {
            DataTable dt4 = new tbl_ScoreTitleTableAdapter().GetDataByID_Lesson(int.Parse(dt3.Rows[i]["Lesson_ID"].ToString()));
            for (int j = 0; j < dt4.Rows.Count; j++)
            {
                new tbl_ScoreTableAdapter().DeleteTitle(int.Parse(dt4.Rows[j]["ScoreTitle_ID"].ToString()));
            }
            new tbl_ScoreTitleTableAdapter().DeleteLesson(int.Parse(dt3.Rows[i]["Lesson_ID"].ToString()));


            // Delete Test
            DataTable dt6 = new tbl_TestTableAdapter().GetDataByt_id_lesson(int.Parse(dt3.Rows[i]["Lesson_ID"].ToString()));
            for (int k = 0; k < dt4.Rows.Count; k++)
            {
                DataTable dt7 = new tbl_TestQuestionTableAdapter().GetDataByDetailStudent(int.Parse(dt6.Rows[k]["ID_Test"].ToString()));
                for (int f = 0; f < dt7.Rows.Count; f++)
                {
                    new tbl_TestResultDetailTableAdapter().DeleteQuestion(int.Parse(dt7.Rows[f]["TestQuestion_ID"].ToString()));
                }
                new tbl_TestQuestionTableAdapter().DeleteTest(int.Parse(dt6.Rows[k]["ID_Test"].ToString()));

                new tbl_TestResultTableAdapter().DeleteTest(int.Parse(dt6.Rows[k]["ID_Test"].ToString()));
            }
            new tbl_TestTableAdapter().DeleteLesson(int.Parse(dt3.Rows[i]["Lesson_ID"].ToString()));
        }
        new tbl_LessonTableAdapter().DeleteTeacher(ID);



        new tbl_ContentTableAdapter().DeletePerson("Teacher", ID);
        new tbl_LinkTableAdapter().DeletePerson(ID, "Teacher");
        new tbl_PersonalMessageTableAdapter().DeleteUserMessage("Teacher", ID);

        new tbl_TeacherInformationTableAdapter().Delete(ID);

        FillGrid();
        Cancel();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int ID = int.Parse(((Label)(GridView1.Rows[e.NewEditIndex].FindControl("lblID"))).Text);
        DataTable dt = new tbl_TeacherInformationTableAdapter().GetDataByID(ID);
        if (dt.Rows.Count > 0)
        {
            TextName.Text = dt.Rows[0]["TI_Name"].ToString();
            TextFatherName.Text = dt.Rows[0]["TI_FatherName"].ToString();
            TextAddress.Text = dt.Rows[0]["TI_Address"].ToString();
            TextTell.Text = dt.Rows[0]["TI_Tell"].ToString();
            TextPostalCode.Text = dt.Rows[0]["TI_PostalCode"].ToString();
            TextExportPlace.Text = dt.Rows[0]["TI_ExportPlace"].ToString();
            TextBirthDate.Text = dt.Rows[0]["TI_BirthDate"].ToString();
            TextAdminCode.Text = dt.Rows[0]["TI_TeacherCode"].ToString();
            TextUserName.Text = dt.Rows[0]["TI_UserName"].ToString();
            HiddenField2.Value = dt.Rows[0]["TI_UserName"].ToString();
            HiddenField1.Value = new main_class().Decode(dt.Rows[0]["TI_Password"].ToString());

            FileUpload1.ToolTip = dt.Rows[0]["TI_Picutre"].ToString();
            Image1.ImageUrl = dt.Rows[0]["TI_Picutre"].ToString();
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
        LblHidden.ToolTip = ID.ToString();
        GridView1.SelectedIndex = e.NewEditIndex;
        Button3.Visible = true;
        Button1.Visible = false;

    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        FillGrid();
        Cancel();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Cancel();
    }
}


