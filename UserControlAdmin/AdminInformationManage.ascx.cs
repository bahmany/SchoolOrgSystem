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
        if (!new main_class().CheckPermissionAdmin("ManageAdmin", int.Parse(Request.Cookies["ID_Role"].Value)))
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
        GridView1.DataSource = new tbl_AdminInformationTableAdapter().GetDataByAI_ID_Admin(int.Parse(Request.Cookies["ID_Role"].Value));
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
        TextRoll.Text = "";
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
        string Folder1 = "~\\Image_User\\Image_Admin\\";
        string File_Name1 = FileUpload1.FileName.ToString().Trim();
        string Address_Full1 = check_name_File(Folder1, File_Name1);

        DataTable dt = new tbl_AdminInformationTableAdapter().GetDataByID(int.Parse(Request.Cookies["ID_Role"].Value));
        string ID_Admin_Path = dt.Rows[0]["AI_ID_Admin_Path"].ToString();



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
        int err = 0;
        string pic="";
        if (LblHidden.ToolTip.Length == 0)
        {
            if (new tbl_AdminInformationTableAdapter().GetDataByUserName(TextUserName.Text).Rows.Count == 0)
            {

                if (FileUpload1.HasFile)
                {
                    if (FileUpload1.PostedFile.ContentLength < 5120000)
                    {
                        pic = Address_Full1;
                        
                    }
                    else
                    {
                        err++;
                        Response.Write("<script>alert('حجم باید کمتر از 5000 کیلو بایت باشد')</script>");
                    }
                }
                else
                {
                     pic = "";
                }
                if (err == 0)
                {
                    new tbl_AdminInformationTableAdapter().Insert1(
                                TextName.Text,
                                TextFatherName.Text,
                                TextAddress.Text,
                                TextTell.Text,
                                TextPostalCode.Text,
                                TextExportPlace.Text,
                                TextBirthDate.Text,
                                TextAdminCode.Text, TextUserName.Text, pass, TextRoll.Text, pic, new main_class().GetDate(),
                                "", int.Parse(Request.Cookies["ID_Role"].Value),
                                ID_Admin_Path + "," + Request.Cookies["ID_Role"].Value);

                    /////////////////////////////////////////
                    if (FileUpload1.HasFile)
                    {
                        Save_File(FileUpload1, Address_Full1);
                    }
                    FillGrid();
                    Cancel();
                }
            }
            else
            {
                Label1.Text = "نام کاربری تکراری می باشد";
                Label1.Visible = true;
            }
        }
        else
        {
            string pic1 = "";
            if (new tbl_AdminInformationTableAdapter().GetDataByUserName(TextUserName.Text).Rows.Count == 0 || TextUserName.Text == HiddenField2.Value)
            {
                if (FileUpload1.HasFile)
                {
                    if (FileUpload1.PostedFile.ContentLength < 5120000)
                    {
                         pic1 = Address_Full1;
                       
                    }
                    else
                    {
                        err++;
                        Response.Write("<script>alert('حجم باید کمتر از 5000 کیلو بایت باشد')</script>");
                    }
                }
                else
                {
                     pic1 = FileUpload1.ToolTip; ;
                }
                if (err == 0)
                {
                    int ID = int.Parse(LblHidden.ToolTip);
                    new tbl_AdminInformationTableAdapter().Update1(
                        TextName.Text,
                        TextFatherName.Text,
                        TextAddress.Text,
                        TextTell.Text,
                        TextPostalCode.Text,
                        TextExportPlace.Text,
                        TextBirthDate.Text,
                        TextAdminCode.Text, TextUserName.Text, pass, TextRoll.Text, pic1, ID);
                    /////////////////////////////////////////
                    if (FileUpload1.HasFile)
                    {
                        Save_File(FileUpload1, Address_Full1);
                        if (System.IO.File.Exists(Server.MapPath(FileUpload1.ToolTip)))
                        {
                            System.IO.File.Delete(Server.MapPath(FileUpload1.ToolTip));
                        }
                    }
                    FillGrid();
                    Cancel();
                }
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

        // Delete Teacher
        DataTable dt20 = new tbl_TeacherInformationTableAdapter().GetDataByAdmin(ID);
        for (int h = 0; h < dt20.Rows.Count; h++)
        {
            new tbl_LinkTableAdapter().DeletePerson(int.Parse(dt20.Rows[i]["Teacher_ID"].ToString()),"Teacher");
            new tbl_ContentTableAdapter().DeletePerson("Teacher",int.Parse(dt20.Rows[i]["Teacher_ID"].ToString()));
            new tbl_PersonalMessageTableAdapter().DeleteUserMessage("Teacher", int.Parse(dt20.Rows[i]["Teacher_ID"].ToString()));


            // Delete Lesson
            DataTable dt3 = new tbl_LessonTableAdapter().GetDataByAllTeacher(int.Parse(dt20.Rows[i]["Teacher_ID"].ToString()));
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
            new tbl_LessonTableAdapter().DeleteTeacher(int.Parse(dt20.Rows[i]["Teacher_ID"].ToString()));

        }
        new tbl_TeacherInformationTableAdapter().DeleteAdmin(ID);




        // Delete Student Parent
        DataTable dt = new tbl_StudentInformationTableAdapter().GetDataByAdmin(ID);
        for (i = 0; i < dt.Rows.Count; i++)
        {
            new tbl_PersonalMessageTableAdapter().DeleteUserMessage("Student",
                int.Parse(dt.Rows[i]["Student_ID"].ToString()));
            new tbl_ScoreTableAdapter().DeleteStudent(int.Parse(dt.Rows[i]["Student_ID"].ToString()));

            DataTable dt10 = new tbl_ParentInformationTableAdapter().GetDataByPA_ID_Student(int.Parse(dt.Rows[i]["Student_ID"].ToString()));
            for (int f = 0; f < dt10.Rows.Count; f++)
            {
                new tbl_PersonalMessageTableAdapter().DeleteUserMessage("Parent",
                    int.Parse(dt10.Rows[f]["Parent_ID"].ToString()));
            }
            new tbl_ParentInformationTableAdapter().DeleteStudent(int.Parse(dt.Rows[i]["Student_ID"].ToString()));
        }
        new tbl_StudentInformationTableAdapter().DeleteAdmin(ID);


        // Delete Gallery
        DataTable dt5 = new tbl_GallerySubjectTableAdapter().GetDataByAdmin(ID);
        for (i = 0; i < dt5.Rows.Count; i++)
        {
            new tbl_GalleryPictureTableAdapter().Deletegp_ID_GallerySubject(int.Parse(dt5.Rows[i]["GallerySubjet_ID"].ToString()));
        }
        new tbl_GallerySubjectTableAdapter().DeleteAdmin(ID);


        new tbl_AdminSecurityTableAdapter().DeleteAS_ID_Admin(ID);
        new tbl_AdminPermissionCategoryTableAdapter().DeleteAPC_ID_Admin(ID);
         new tbl_ContentTableAdapter().DeletePerson("Admin", ID);
       new tbl_LinkTableAdapter().DeletePerson(ID, "Admin");
        new tbl_PersonalMessageTableAdapter().DeleteUserMessage("Admin", ID);
        new tbl_AdminInformationTableAdapter().DeleteAdmin(ID);
        FillGrid();
        Cancel();
    }
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Cancel();
        int ID = int.Parse(((Label)(GridView1.Rows[e.NewEditIndex].FindControl("lblID"))).Text);
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
            HiddenField2.Value = dt.Rows[0]["AI_UserName"].ToString();
            HiddenField1.Value = new main_class().Decode(dt.Rows[0]["AI_Password"].ToString());
            TextRoll.Text = dt.Rows[0]["AI_Role_Admin"].ToString();
            FileUpload1.ToolTip = dt.Rows[0]["AI_Pic"].ToString();

            Image1.Visible = true;

            Image1.ImageUrl = dt.Rows[0]["AI_Pic"].ToString();
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


