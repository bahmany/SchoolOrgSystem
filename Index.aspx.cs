using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)

        //{
        if (Request.Cookies["Type_Role"] != null)
        {
            PlaceHolder3.Controls.Add(LoadControl("~//UserControlPublic//PanelUser.ascx"));
        }
        else
        {
            PlaceHolder3.Controls.Add(LoadControl("~//UserControlPublic//PanelGuest.ascx"));
        }


        Label1.Text = FarsiLibrary.Utils.PersianDate.Now.ToWritten();

        if (Request.QueryString["Type"] != null)
        {
            switch (Request.QueryString["Type"].ToString())
            {
                #region Share


                case "ContentEdit":
                    if (Request.Cookies["Type_Role"] != null)
                    {
                        if (Request.Cookies["Type_Role"].Value.ToString() == "Admin")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlAdmin//Admin.ascx"));
                            Title = "ویرایش محتوا";
                        }
                        else if (Request.Cookies["Type_Role"].Value.ToString() == "Teacher")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlTeacher//Teacher.ascx"));
                            Title = "ویرایش محتوا";
                        }
                        else
                        {
                            //                   Title = "عدم مجوز دسترسی";

                        }
                    }
                    else
                    {
                        Title = "عدم مجوز دسترسی";

                        PlaceHolder1.Controls.Add(LoadControl("~//UserControlPublic//Public.ascx"));
                    }
                    break;
                case "LinkEdit":
                    if (Request.Cookies["Type_Role"] != null)
                    {
                        if (Request.Cookies["Type_Role"].Value.ToString() == "Admin")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlAdmin//Admin.ascx"));
                            Title = "ویرایش لینک مفید";
                        }
                        else if (Request.Cookies["Type_Role"].Value.ToString() == "Teacher")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlTeacher//Teacher.ascx"));
                            Title = "ویرایش لینک مفید";
                        }
                        else
                        {
                            //                   Title = "عدم مجوز دسترسی";

                        }
                    }
                    else
                    {
                        Title = "عدم مجوز دسترسی";

                        PlaceHolder1.Controls.Add(LoadControl("~//UserControlPublic//Public.ascx"));
                    }
                    break;
                case "LinkInsert":
                    if (Request.Cookies["Type_Role"] != null)
                    {
                        if (Request.Cookies["Type_Role"].Value.ToString() == "Admin")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlAdmin//Admin.ascx"));
                            Title = "ثبت لینک مفید";
                        }
                        else if (Request.Cookies["Type_Role"].Value.ToString() == "Teacher")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlTeacher//Teacher.ascx"));
                            Title = "ثبت لینک مفید";
                        }
                        else
                        {
                            //                   Title = "عدم مجوز دسترسی";

                        }
                    }
                    else
                    {
                        Title = "عدم مجوز دسترسی";

                        PlaceHolder1.Controls.Add(LoadControl("~//UserControlPublic//Public.ascx"));
                    }
                    break;
                case "LinkManage":
                    if (Request.Cookies["Type_Role"] != null)
                    {
                        if (Request.Cookies["Type_Role"].Value.ToString() == "Admin")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlAdmin//Admin.ascx"));
                            Title = "مدیریت لینک مفید";
                        }
                        else if (Request.Cookies["Type_Role"].Value.ToString() == "Teacher")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlTeacher//Teacher.ascx"));
                            Title = "مدیریت لینک مفید";
                        }
                        else
                        {
                            //                   Title = "عدم مجوز دسترسی";

                        }
                    }
                    else
                    {
                        Title = "عدم مجوز دسترسی";

                        PlaceHolder1.Controls.Add(LoadControl("~//UserControlPublic//Public.ascx"));
                    }
                    break;
                case "PersonalMessageInsert":
                    if (Request.Cookies["Type_Role"] != null)
                    {

                        Title = "ثبت پیغام شخصی";
                        if (Request.Cookies["Type_Role"].Value.ToString() == "Admin")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlAdmin//Admin.ascx"));
                        }
                        else if (Request.Cookies["Type_Role"].Value.ToString() == "Teacher")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlTeacher//Teacher.ascx"));
                        }
                        else if (Request.Cookies["Type_Role"].Value.ToString() == "Parent")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlParent//Parent.ascx"));
                        }
                        else if (Request.Cookies["Type_Role"].Value.ToString() == "Student")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlStudent//Student.ascx"));
                        }
                    }
                    else
                    {
                        Title = "عدم مجوز دسترسی";

                        PlaceHolder1.Controls.Add(LoadControl("~//UserControlPublic//Public.ascx"));
                    }

                    break;

                case "PersonalMessageInbox":
                    if (Request.Cookies["Type_Role"] != null)
                    {

                        Title = "پیام های دریافتی";
                        if (Request.Cookies["Type_Role"].Value.ToString() == "Admin")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlAdmin//Admin.ascx"));
                        }
                        else if (Request.Cookies["Type_Role"].Value.ToString() == "Teacher")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlTeacher//Teacher.ascx"));
                        }
                        else if (Request.Cookies["Type_Role"].Value.ToString() == "Parent")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlParent//Parent.ascx"));
                        }
                        else if (Request.Cookies["Type_Role"].Value.ToString() == "Student")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlStudent//Student.ascx"));
                        }
                    }
                    else
                    {
                        Title = "عدم مجوز دسترسی";

                        PlaceHolder1.Controls.Add(LoadControl("~//UserControlPublic//Public.ascx"));
                    }

                    break;
                case "PersonalMessageOutbox":
                    if (Request.Cookies["Type_Role"] != null)
                    {

                        Title = "پیام های فرستاده شده";
                        if (Request.Cookies["Type_Role"].Value.ToString() == "Admin")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlAdmin//Admin.ascx"));
                        }
                        else if (Request.Cookies["Type_Role"].Value.ToString() == "Teacher")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlTeacher//Teacher.ascx"));
                        }
                        else if (Request.Cookies["Type_Role"].Value.ToString() == "Parent")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlParent//Parent.ascx"));
                        }
                        else if (Request.Cookies["Type_Role"].Value.ToString() == "Student")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlStudent//Student.ascx"));
                        }
                    }
                    else
                    {
                        Title = "عدم مجوز دسترسی";

                        PlaceHolder1.Controls.Add(LoadControl("~//UserControlPublic//Public.ascx"));
                    }

                    break;
                case "PersonalMessageDetail":
                    if (Request.Cookies["Type_Role"] != null)
                    {

                        Title = "مشاهده پیام";
                        if (Request.Cookies["Type_Role"].Value.ToString() == "Admin")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlAdmin//Admin.ascx"));
                        }
                        else if (Request.Cookies["Type_Role"].Value.ToString() == "Teacher")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlTeacher//Teacher.ascx"));
                        }
                        else if (Request.Cookies["Type_Role"].Value.ToString() == "Parent")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlParent//Parent.ascx"));
                        }
                        else if (Request.Cookies["Type_Role"].Value.ToString() == "Student")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlStudent//Student.ascx"));
                        }
                    }
                    else
                    {
                        Title = "عدم مجوز دسترسی";

                        PlaceHolder1.Controls.Add(LoadControl("~//UserControlPublic//Public.ascx"));
                    }

                    break;
                case "TeacherList":
                    if (Request.Cookies["Type_Role"] != null)
                    {

                        Title = "لیست معلم ها";
                        if (Request.Cookies["Type_Role"].Value.ToString() == "Admin")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlAdmin//Admin.ascx"));
                        }
                        else if (Request.Cookies["Type_Role"].Value.ToString() == "Teacher")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlTeacher//Teacher.ascx"));
                        }
                        else if (Request.Cookies["Type_Role"].Value.ToString() == "Parent")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlParent//Parent.ascx"));
                        }
                        
                    }
                    else
                    {
                        Title = "عدم مجوز دسترسی";

                        PlaceHolder1.Controls.Add(LoadControl("~//UserControlPublic//Public.ascx"));
                    }

                    break;

                case "AdminList":
                    if (Request.Cookies["Type_Role"] != null)
                    {

                        Title = "لیست مدیران";
                        if (Request.Cookies["Type_Role"].Value.ToString() == "Admin")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlAdmin//Admin.ascx"));
                        }
                        else if (Request.Cookies["Type_Role"].Value.ToString() == "Teacher")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlTeacher//Teacher.ascx"));
                        }
                        else if (Request.Cookies["Type_Role"].Value.ToString() == "Parent")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlParent//Parent.ascx"));
                        }
                        else if (Request.Cookies["Type_Role"].Value.ToString() == "Student")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlStudent//Student.ascx"));
                        }
                    }
                    else
                    {
                        Title = "عدم مجوز دسترسی";

                        PlaceHolder1.Controls.Add(LoadControl("~//UserControlPublic//Public.ascx"));
                    }

                    break;

                

                case "ParentList":
                    if (Request.Cookies["Type_Role"] != null)
                    {

                        Title = "لیست اولیاء";
                        if (Request.Cookies["Type_Role"].Value.ToString() == "Admin")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlAdmin//Admin.ascx"));
                        }
                        else if (Request.Cookies["Type_Role"].Value.ToString() == "Teacher")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlTeacher//Teacher.ascx"));
                        }
                        else if (Request.Cookies["Type_Role"].Value.ToString() == "Parent")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlParent//Parent.ascx"));
                        }
                      
                    }
                    else
                    {
                        Title = "عدم مجوز دسترسی";

                        PlaceHolder1.Controls.Add(LoadControl("~//UserControlPublic//Public.ascx"));
                    }

                    break;

                case "TeacherDetail":
                    if (Request.Cookies["Type_Role"] != null)
                    {

                        Title = "مشاهده مشخصات فردی معلم";
                        if (Request.Cookies["Type_Role"].Value.ToString() == "Admin")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlAdmin//Admin.ascx"));
                        }
                        else if (Request.Cookies["Type_Role"].Value.ToString() == "Teacher")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlTeacher//Teacher.ascx"));
                        }
                        else if (Request.Cookies["Type_Role"].Value.ToString() == "Parent")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlParent//Parent.ascx"));
                        }
                        else if (Request.Cookies["Type_Role"].Value.ToString() == "Student")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlStudent//Student.ascx"));
                        }
                    }
                    else
                    {
                        Title = "عدم مجوز دسترسی";

                        PlaceHolder1.Controls.Add(LoadControl("~//UserControlPublic//Public.ascx"));
                    }

                    break;
                case "AdminDetail":
                    if (Request.Cookies["Type_Role"] != null)
                    {

                        Title = "مشاهده مشخصات فردی مدیر";
                        if (Request.Cookies["Type_Role"].Value.ToString() == "Admin")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlAdmin//Admin.ascx"));
                        }
                        else if (Request.Cookies["Type_Role"].Value.ToString() == "Teacher")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlTeacher//Teacher.ascx"));
                        }
                        else if (Request.Cookies["Type_Role"].Value.ToString() == "Parent")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlParent//Parent.ascx"));
                        }
                        else if (Request.Cookies["Type_Role"].Value.ToString() == "Student")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlStudent//Student.ascx"));
                        }
                    }
                    else
                    {
                        Title = "عدم مجوز دسترسی";

                        PlaceHolder1.Controls.Add(LoadControl("~//UserControlPublic//Public.ascx"));
                    }

                    break;
                case "ParentDetail":
                    if (Request.Cookies["Type_Role"] != null)
                    {

                        Title = "مشاهده مشخصات فردی اولیاء";
                        if (Request.Cookies["Type_Role"].Value.ToString() == "Admin")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlAdmin//Admin.ascx"));
                        }
                        else if (Request.Cookies["Type_Role"].Value.ToString() == "Teacher")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlTeacher//Teacher.ascx"));
                        }
                        else if (Request.Cookies["Type_Role"].Value.ToString() == "Parent")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlParent//Parent.ascx"));
                        }
                        else if (Request.Cookies["Type_Role"].Value.ToString() == "Student")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlStudent//Student.ascx"));
                        }
                    }
                    else
                    {
                        Title = "عدم مجوز دسترسی";

                        PlaceHolder1.Controls.Add(LoadControl("~//UserControlPublic//Public.ascx"));
                    }

                    break;
                case "StudentDetail":
                    if (Request.Cookies["Type_Role"] != null)
                    {

                        Title = "مشاهده مشخصات فردی دانش آموز";
                        if (Request.Cookies["Type_Role"].Value.ToString() == "Admin")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlAdmin//Admin.ascx"));
                        }
                        else if (Request.Cookies["Type_Role"].Value.ToString() == "Teacher")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlTeacher//Teacher.ascx"));
                        }
                        else if (Request.Cookies["Type_Role"].Value.ToString() == "Parent")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlParent//Parent.ascx"));
                        }
                        else if (Request.Cookies["Type_Role"].Value.ToString() == "Student")
                        {
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlStudent//Student.ascx"));
                        }
                    }
                    else
                    {
                        PlaceHolder1.Controls.Add(LoadControl("~//UserControlPublic//Public.ascx"));
                        Title = "عدم مجوز دسترسی";

                    }

                    break;
                #endregion


                #region Admin
                case "IndexAdmin":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlAdmin//Admin.ascx"));
                    Title = "صفحه اصلی شخصی";
                    break;
                case "AdminAccessDenied":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlAdmin//Admin.ascx"));
                    Title = "عدم مجوز دسترسی";
                    break;
                case "CallUSManage":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlAdmin//Admin.ascx"));
                    Title = "مدیریت تماس با ما";
                    break;
                case "CallUSDetail":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlAdmin//Admin.ascx"));
                    Title = "مشاهده تماس با ما";
                    break;
                case "AdminOneRecord":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlAdmin//Admin.ascx"));
                    Title = "مدیریت متن های سایت";
                    break;

                case "AdminTerm":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlAdmin//Admin.ascx"));
                    Title = "ثبت ترم";
                    break;
                case "AdminContentInsert":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlAdmin//Admin.ascx"));
                    Title = "ثبت محتوا";
                    break;
                case "LessonManage":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlAdmin//Admin.ascx"));
                    Title = "مدیریت دروس";
                    break;
                case "LessonEdit":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlAdmin//Admin.ascx"));
                    Title = "ویرایش درس";
                    break;
                case "LessonInsert":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlAdmin//Admin.ascx"));
                    Title = "ثبت درس";
                    break;
                case "AdminContentManage":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlAdmin//Admin.ascx"));
                    Title = "مدیریت محتوا";
                    break;
                case "AdminInformationManage":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlAdmin//Admin.ascx"));
                    Title = "مدیریت مدیران";
                    break;
                case "TeacherInformationManage":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlAdmin//Admin.ascx"));
                    Title = "مدیریت معلم ها";
                    break;
                case "AdminInformation":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlAdmin//Admin.ascx"));
                    Title = "مدیریت اطلاعات شخصی";
                    break;
                case "AdminCategory":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlAdmin//Admin.ascx"));
                    Title = "مدیریت بخش ها";
                    break;
                case "StudentInformationInsertEdit":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlAdmin//Admin.ascx"));
                    Title = "ثبت و ویرایش دانش آموز";
                    break;
                case "StudentInformationManage":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlAdmin//Admin.ascx"));
                    Title = "مدیریت دانش آموز";
                    break;
                case "GalleryInsert":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlAdmin//Admin.ascx"));
                    Title = "ثبت گالری عکس جدید";
                    break;
                case "GalleryManage":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlAdmin//Admin.ascx"));
                    Title = "مدیریت گالری عکس ها";
                    break;
                case "GalleryEdit":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlAdmin//Admin.ascx"));
                    Title = "ویرایش گالری عکس";
                    break;
                case "AdminEditStudent":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlAdmin//Admin.ascx"));
                    Title = "ویرایش دانش آموز";
                    break;
                case "AdminParentEdit":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlAdmin//Admin.ascx"));
                    Title = "ویرایش اولیاء";
                    break;
                case "ParentInformationManage":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlAdmin//Admin.ascx"));
                    Title = "مدیریت اولیاء";
                    break;
                case "AdminPermission":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlAdmin//Admin.ascx"));
                    Title = "مدیریت دسترسی مدیران";
                    break;
                case "SubTitleManage":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlAdmin//Admin.ascx"));
                    Title = "مدیریت پیام های زیرنویس";
                    break;

                case "AdminWait":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlAdmin//Admin.ascx"));
                    Title = "عدم راه اندازی بخش";
                    break;
                #endregion


                #region Public
                case "IndexPublic":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlPublic//Public.ascx"));
                    Title = "صفحه اصلی سایت مدرسه";
                    break;
                case "Call_US":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlPublic//Public.ascx"));
                    Title = "تماس با ما";
                    break;

                case "OneRecordShow":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlPublic//Public.ascx"));
                    Title = "نمایش متن";
                    break;
                case "LastLibraryArchive":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlPublic//Public.ascx"));
                    Title = "آرشیو کتابخانه";
                    break;
                case "LastNewsArchive":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlPublic//Public.ascx"));
                    Title = "آرشیو اخبار و رویداد ها";
                    break;
                case "LastGalleryArchive":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlPublic//Public.ascx"));
                    Title = "آرشیو گالری تصاویر";
                    break;
                case "ContentPublic":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlPublic//Public.ascx"));
                    Title = "مشاهده محتوا";
                    break;
                case "GalleryDetailPublic":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlPublic//Public.ascx"));
                    Title = "مشاهده گالری تصاویر";
                    break;

                case "ParentRegister":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlPublic//Public.ascx"));
                    Title = "ثبت نام والدین";
                    break;
                case "PublicAccessDenied":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlPublic//Public.ascx"));
                    Title = "عدم مجوز دسترسی";
                    break;
                case "PublicWait":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlPublic//Public.ascx"));
                    Title = "عدم راه اندازی بخش";
                    break;
                #endregion


                #region Parent
                case "IndexParent":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlParent//Parent.ascx"));
                    Title = "صفحه اصلی شخصی";
                    break;
                case "GalleryDetailParent":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlParent//Parent.ascx"));
                    Title = "مشاهده گالری تصاویر";
                    break;
                case "ParentInformation":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlParent//Parent.ascx"));
                    Title = "ویرایش اطلاعات شخصی";
                    break;
                case "ContentParent":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlParent//Parent.ascx"));
                    Title = "مشاهده محتوا";
                    break;
                case "ParentWait":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlParent//Parent.ascx"));
                    Title = "عدم راه اندازی بخش";
                    break;

                #endregion

                #region Student
                case "IndexStudent":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlStudent//Student.ascx"));
                    Title = "صفحه اصلی شخصی";
                    break;
                case "GalleryDetailStudent":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlStudent//Student.ascx"));
                    Title = "مشاهده گالری تصاویر";
                    break;
                case "ContentStudent":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlStudent//Student.ascx"));
                    Title = "مشاهده محتوا";
                    break;
                case "StudentClassmateList":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlStudent//Student.ascx"));
                    Title = "مشاهده هم کلاسی ها";
                    break;
                case "StudentScoreView":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlStudent//Student.ascx"));
                    Title = "مشاهده نمرات";
                    break;

                case "StudentTestView":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlStudent//Student.ascx"));
                    Title = "آزمون آنلاین";
                    break;

                case "StudentTestEndTime":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlStudent//Student.ascx"));
                    Title = "پایان وقت آزمون";
                    break;
                case "StudentTestQuestionView":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlStudent//Student.ascx"));
                    Title = "شرکت در آزمون آنلاین";
                    break;

                case "StudentLessonView":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlStudent//Student.ascx"));
                    Title = "لیست دروس و معلمان";
                    break;

                case "StudentInformation":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlStudent//Student.ascx"));
                    Title = "ویرایش اطلاعات شخصی";
                    break;
                case "StudentWait": PlaceHolder1.Controls.Add(LoadControl("~//UserControlStudent//Student.ascx"));
                    Title = "عدم راه اندازی بخش";
                    break;
                #endregion

                #region Teacher

                case "TeacherStudentList":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlTeacher//Teacher.ascx"));
                    Title = "صفحه اصلی شخصی";
                    break;
                case "TestInsert":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlTeacher//Teacher.ascx"));
                    Title = "ثبت آزمون آنلاین جدید";
                    break;
                case "TeacherTestResultManage":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlTeacher//Teacher.ascx"));
                    Title = "مشاهده نتیجه آزمون";
                    break;
                case "TeacherTestStudentDetail":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlTeacher//Teacher.ascx"));
                    Title = "مشاهده برگه دانش آموز";
                    break;
                case "TestQuestionManage":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlTeacher//Teacher.ascx"));
                    Title = "مدیریت سوالات آزمون آنلاین";
                    break;
                case "TestManage":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlTeacher//Teacher.ascx"));
                    Title = "مدیریت آزمون آنلاین ";
                    break;
                case "TeacherContentInsert":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlTeacher//Teacher.ascx"));
                    Title = "صفحه اصلی شخصی";
                    break;
                case "TeacherLessonView":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlTeacher//Teacher.ascx"));
                    Title = "مشاهده دروس واگذار شده";
                    break;

                case "TeacherContentManage":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlTeacher//Teacher.ascx"));
                    Title = "صفحه اصلی شخصی";
                    break;
                case "ScoreManage":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlTeacher//Teacher.ascx"));
                    Title = "مدیریت آزمون و نمرات دانش آموزان";
                    break;
                case "ScoreEdit":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlTeacher//Teacher.ascx"));
                    Title = "ویرایش آزمون و نمرات دانش آموزان";
                    break;
                case "IndexTeacher":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlTeacher//Teacher.ascx"));
                    Title = "صفحه اصلی شخصی";
                    break;
                case "TeacherWait": PlaceHolder1.Controls.Add(LoadControl("~//UserControlTeacher//Teacher.ascx"));
                    Title = "عدم راه اندازی بخش";
                    break;
                case "TeacherInformation":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlTeacher//Teacher.ascx"));
                    Title = "ویرایش مشخصات شخصی";
                    break;
                case "ScoreInsert":
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlTeacher//Teacher.ascx"));
                    Title = "ثبت آزمون و نمرات دانش آموزان";
                    break;
                #endregion


                case "Exit":
                    string[] cookies = Request.Cookies.AllKeys;
                    foreach (string cookie in cookies)
                    {
                        Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
                    }
                    Response.Redirect("~//index.aspx");
                    break;

                default:
                    PlaceHolder2.Controls.Add(LoadControl("~//UserControlPublic//HeaderImageNavigator.ascx"));
                    PlaceHolder1.Controls.Add(LoadControl("~//UserControlPublic//Public.ascx"));
                    Title = "صفحه اصلی سایت";
                    break;
            }
        }
        else
        {
            PlaceHolder2.Controls.Add(LoadControl("~//UserControlPublic//HeaderImageNavigator.ascx"));
            PlaceHolder1.Controls.Add(LoadControl("~//UserControlPublic//Public.ascx"));
            Title = "صفحه اصلی سایت";

        }
        //}
    }
}
