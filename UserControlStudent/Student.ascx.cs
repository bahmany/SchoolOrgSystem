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
        if (Request.Cookies["Type_Role"] != null)
        {
            if (Request.Cookies["Type_Role"].Value.ToString() == "Student")
            {
                PlaceHolder1.Controls.Add(LoadControl("~//UserControlStudent//StudentMenu.ascx"));
                if (Request.QueryString["Type"] != null)
                {
                    switch (Request.QueryString["Type"].ToString())
                    {
                        case "StudentTestEndTime":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlStudent//StudentTestEndTime.ascx"));
                            break;
                        case "StudentTestQuestionView":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlStudent//StudentTestQuestionView.ascx"));
                            break;
                        case "IndexStudent":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlStudent//StudentIndex.ascx"));
                            break;
                        case "StudentTestView":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlStudent//StudentTestView.ascx"));
                            break;
                        case "GalleryDetailStudent":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlPublic//GalleryDetail.ascx"));
                            break;

                        case "StudentInformation":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlStudent//StudentInformation.ascx"));
                            break;
                        case "StudentClassmateList":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlStudent//StudentClassmateList.ascx"));
                            break;
                            
                        case "StudentScoreView":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlStudent//StudentScoreView.ascx"));
                            break;
                        case "StudentLessonView":
                            PlaceHolder1.Controls.Add(LoadControl("~//UserControlStudent//StudentLessonView.ascx"));
                            break;
                        case "StudentWait":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlPublic//Wait.ascx"));
                            break;
                        case "ContentStudent":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlPublic//ContentDetail.ascx"));
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
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlShare//ParentList.ascx"));
                            break;
                        case "StudentList":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlShare//StudentList.ascx"));
                            break;
                    }
                }
                else
                {
                    Response.Redirect("~//index.aspx");

                }

            }
            else
            {
                Response.Redirect("index.aspx");
            }
        }
    }
}