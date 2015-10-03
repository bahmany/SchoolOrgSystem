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
        PlaceHolder1.Controls.Add(LoadControl("~//UserControlShare//ParentStudentLastNews.ascx"));
        PlaceHolder2.Controls.Add(LoadControl("~//UserControlShare//ParentStudentLastLibrary.ascx"));
        PlaceHolder3.Controls.Add(LoadControl("~//UserControlShare//PersonalMessageInboxBox.ascx"));
        PlaceHolder4.Controls.Add(LoadControl("~//UserControlShare//ParentStudentLastGallery.ascx"));

    }
}
