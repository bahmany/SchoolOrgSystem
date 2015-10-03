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
        PlaceHolder1.Controls.Add(LoadControl("~//UserControlPublic//PublicMenu.ascx"));
        if (Request.QueryString["Type"] != null)
        {
            switch (Request.QueryString["Type"].ToString())
            {
                case "ParentRegister":
                    PlaceHolder2.Controls.Add(LoadControl("~//UserControlPublic//ParentRegister.ascx"));
                    break;
                case "GalleryDetailPublic":
                    PlaceHolder2.Controls.Add(LoadControl("~//UserControlPublic//GalleryDetail.ascx"));
                    break;

                case "OneRecordDetail":
                    PlaceHolder2.Controls.Add(LoadControl("~//UserControlPublic//OneRecordDetail.ascx"));
                    break;
                case "Call_US":
                    PlaceHolder2.Controls.Add(LoadControl("~//UserControlPublic//Call_US.ascx"));
                    break;
                case "PublicWait":
                    PlaceHolder2.Controls.Add(LoadControl("~//UserControlPublic//Wait.ascx"));
                    break;
                case "ContentPublic":
                    PlaceHolder2.Controls.Add(LoadControl("~//UserControlPublic//ContentDetail.ascx"));
                    break;
                case "IndexPublic":
                    PlaceHolder2.Controls.Add(LoadControl("~//UserControlPublic//PublicIndex.ascx"));
                    break;
                case "LastNewsArchive":
                    PlaceHolder2.Controls.Add(LoadControl("~//UserControlPublic//LastNewsArchive.ascx"));
                    break;
                case "LastLibraryArchive":
                    PlaceHolder2.Controls.Add(LoadControl("~//UserControlPublic//LastLibraryArchive.ascx"));
                    break;
                case "LastGalleryArchive":
                    PlaceHolder2.Controls.Add(LoadControl("~//UserControlPublic//LastGalleryArchive.ascx"));
                    break;
                case "PublicAccessDenied":
                    PlaceHolder2.Controls.Add(LoadControl("~//UserControlPublic//AccessDenied.ascx"));
                    break;
                case "ContentEdit":
                case "PersonalMessageInsert":
                case "PersonalMessageInbox":
                case "PersonalMessageOutbox":
                case "PersonalMessageDetail":
                case "TeacherList":
                case "AdminList":
                case "StudentList":
                case "ParentList":
                case "TeacherDetail":
                case "AdminDetail":
                case "ParentDetail":
                case "StudentDetail":
                    PlaceHolder2.Controls.Add(LoadControl("~//UserControlPublic//AccessDenied.ascx"));
                    break;



                default:
                    PlaceHolder2.Controls.Add(LoadControl("~//UserControlPublic//IndexPublic.ascx"));
                    break;



            }
        }
        else
        {
            PlaceHolder2.Controls.Add(LoadControl("~//UserControlPublic//IndexPublic.ascx"));
        }




    }
}
