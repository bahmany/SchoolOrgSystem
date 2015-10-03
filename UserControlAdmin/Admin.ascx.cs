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
            if (Request.Cookies["Type_Role"].Value.ToString() == "Admin")
            {
                PlaceHolder1.Controls.Add(LoadControl("~//UserControlAdmin//AdminMenu.ascx"));
                if (Request.QueryString["Type"] != null)
                {
                    switch (Request.QueryString["Type"].ToString())
                    {
                        case "CallUSManage":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlAdmin//CallUSManage.ascx"));
                            break;
                        case "SubTitleManage":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlAdmin//SubTitleManage.ascx"));
                            break;
                        case "CallUSDetail":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlAdmin//CallUSDetail.ascx"));
                            break;

                        case "GalleryInsert":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlAdmin//GalleryInsertEdit.ascx"));
                            break;
                        case "GalleryManage":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlAdmin//GalleryManage.ascx"));
                            break;
                        case "GalleryEdit":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlAdmin//GalleryInsertEdit.ascx"));
                            break;

                        case "AdminPermission":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlAdmin//AdminPermission.ascx"));
                           
                            break;
                        case "AdminTerm":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlAdmin//AdminTerm.ascx"));
                            break;
                        case "AdminOneRecord":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlAdmin//AdminOneRecord.ascx"));
                            break;
                        case "LessonManage":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlAdmin//LessonManage.ascx"));
                            break;
                        case "LessonEdit":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlAdmin//LessonInsertEdit.ascx"));
                            break;
                        case "LessonInsert":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlAdmin//LessonInsertEdit.ascx"));
                            break;

                        case "LinkInsert":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlShare//AdminTeacherLinkInsertEdit.ascx"));
                            break;
                        case "LinkEdit":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlShare//AdminTeacherLinkInsertEdit.ascx"));
                            break;
                        case "LinkManage":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlShare//AdminTeacherLinkManage.ascx"));
                            break;


                        case "AdminContentInsert":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlShare//AdminTeacherContentInsertEdit.ascx"));
                            break;
                        case "ContentEdit":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlShare//AdminTeacherContentInsertEdit.ascx"));
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
                        case "AdminContentManage":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlShare//AdminTeacherContentManage.ascx"));
                            break;
                        case "IndexAdmin":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlAdmin//AdminIndex.ascx"));
                            break;
                        case "AdminInformation":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlAdmin//AdminInformation.ascx"));
                            break;
                        case "AdminInformationManage":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlAdmin//AdminInformationManage.ascx"));
                            break;
                        case "AdminCategory":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlAdmin//AdminCategory.ascx"));
                            break;
                        case "TeacherInformationManage":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlAdmin//TeacherInformationManage.ascx"));
                            break;
                        case "StudentInformationInsertEdit":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlAdmin//StudentInformationInsertEdit.ascx"));
                            break;
                        case "StudentInformationManage":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlAdmin//StudentInformationManage.ascx"));
                            break;
                        case "AdminEditStudent":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlAdmin//StudentInformationInsertEdit.ascx"));
                            break;
                        case "AdminParentEdit":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlAdmin//ParentInformationEdit.ascx"));
                            break;
                        case "ParentInformationManage":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlAdmin//ParentInformationManage.ascx"));
                            break;
                        case "AdminWait":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlPublic//Wait.ascx"));
                            break;
                        case "AdminAccessDenied":
                            PlaceHolder2.Controls.Add(LoadControl("~//UserControlPublic//AccessDenied.ascx"));
                            break;

                    }
                }
            }
            else
            {
                Response.Redirect("~//index.aspx?Type=PublicAccessDenied");

            }
        }
        else
        {
            Response.Redirect("index.aspx?Type=PublicAccessDenied");
        }
    }
}
