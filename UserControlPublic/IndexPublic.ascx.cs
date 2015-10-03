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

        PlaceHolder1.Controls.Add(LoadControl("~//UserControlPublic//AboutSchoolShort.ascx"));
            PlaceHolder6.Controls.Add(LoadControl("~//UserControlPublic//LastBreak.ascx"));
            PlaceHolder3.Controls.Add(LoadControl("~//UserControlPublic//LastLibrary.ascx"));
            PlaceHolder2.Controls.Add(LoadControl("~//UserControlPublic//LastNews.ascx"));
            PlaceHolder5.Controls.Add(LoadControl("~//UserControlPublic//LastGallery.ascx"));
            PlaceHolder4.Controls.Add(LoadControl("~//UserControlPublic//Login.ascx"));
            PlaceHolder7.Controls.Add(LoadControl("~//UserControlPublic//LastLink.ascx"));
            PlaceHolder8.Controls.Add(LoadControl("~//UserControlPublic//LastPoll.ascx"));

    }
}
