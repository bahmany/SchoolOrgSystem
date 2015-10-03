using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MainDataModuleTableAdapters;

public partial class UserControlPublic_AdminInformationAdd : System.Web.UI.UserControl
{
    public string MessageUnread="0";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            DataTable dt = new tbl_PersonalMessageTableAdapter().GetDataByUnreadMessage(
                Request.Cookies["Type_Role"].Value.ToString(),
                  int.Parse(Request.Cookies["ID_Role"].Value.ToString()));
            MessageUnread = dt.Rows.Count.ToString();
        }
    }
}
