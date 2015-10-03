using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class UserControlPublic_MainContent : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Request.Cookies["Type_Role"]!=null)
        {
            if (Request.Cookies["Type_Role"].Value.ToString() == "Teacher")
            {
                PlaceHolder1.Controls.Add(LoadControl("~//UserControlTeacher//TeacherMenu.ascx"));
                if (Request.QueryString["Type"] != null)
                {
                    switch (Request.QueryString["Type"].ToString())
                    {
                        case "TeacherTestResultManage":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlTeacher//TeacherTestResultManage.ascx"));
                            break;
                        case "TeacherTestStudentDetail":
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlTeacher//TeacherTestStudentDetail.ascx"));
                            break;
                        case "TestQuestionManage":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlTeacher//TestQuestionManage.ascx"));
                            break;
                        case "LinkInsert":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlShare//AdminTeacherLinkInsertEdit.ascx"));
                            break;
                        case "TestInsert":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlTeacher//TestInsert.ascx"));
                            break;
                        case "TestManage":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlTeacher//TestManage.ascx"));
                            break;
                        case "LinkEdit":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlShare//AdminTeacherLinkInsertEdit.ascx"));
                            break;
                        case "LinkManage":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlShare//AdminTeacherLinkManage.ascx"));
                            break;

                        case "ScoreInsert":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlTeacher//ScoreInsert.ascx"));
                            break;
                       case "TeacherStudentList":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlTeacher//TeacherStudentList.ascx"));
                            break;
                       case "TeacherLessonView":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlTeacher//TeacherLessonView.ascx"));
                            break;
                        case "ScoreManage":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlTeacher//ScoreManage.ascx"));
                            break;
                        case "ScoreEdit":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlTeacher//ScoreEdit.ascx"));
                            break;
                        case "ContentEdit":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlShare//AdminTeacherContentInsertEdit.ascx"));
                            break;
                        case "TeacherContentInsert":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlShare//AdminTeacherContentInsertEdit.ascx"));
                            break;
                        case "TeacherContentManage":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlShare//AdminTeacherContentManage.ascx"));
                            break;
                        case "IndexTeacher":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlTeacher//TeacherIndex.ascx"));
                            break;
                        case "TeacherInformation":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlTeacher//TeacherInformation.ascx"));
                            break;
                        case "TeacherWait":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlPublic//Wait.ascx"));
                            break;
                        case "TeacherDetail":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlShare//TeacherDetail.ascx"));
                            break;
                        case "AdminDetail":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlShare//AdminDetail.ascx"));
                            break;
                        case "ParentDetail":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlShare//ParentDetail.ascx"));
                            break;
                        case "StudentDetail":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlShare//StudentDetail.ascx"));
                            break;
                        case "PersonalMessageInsert":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlShare//PersonalMessageInsert.ascx"));
                            break;
                        case "PersonalMessageInbox":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlShare//PersonalMessageInbox.ascx"));
                            break;
                        case "PersonalMessageOutbox":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlShare//PersonalMessageOutbox.ascx"));
                            break;
                        case "PersonalMessageDetail":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlShare//PersonalMessageDetail.ascx"));
                            break;
                        case "TeacherList":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlShare//TeacherList.ascx"));
                            break;
                        case "AdminList":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlShare//AdminList.ascx"));
                            break;
                        case "ParentList":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlTeacher//TeacherStudentParentList.ascx"));
                            break;
                        case "StudentList":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlShare//StudentList.ascx"));
                            break;
                    }
                }
            }
            else
            {
                Response.Redirect("~//index.aspx?Type=AccessDenied");

            }

        }
        else
        {
            Response.Redirect("index.aspx?Type=AccessDenied");
        }
    }
}
