using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MainDataModuleTableAdapters;
public partial class UserControlPublic_WebUserControl : System.Web.UI.UserControl
{
    public string SubTitle = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        DataTable dt = new tbl_SubTitleTableAdapter().GetData();
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            SubTitle = SubTitle + dt.Rows[i]["SB_Title"].ToString() + "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;";
        }
    }
}
