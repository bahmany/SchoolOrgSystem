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
    public string UserInfo="";
    protected void Page_Load(object sender, EventArgs e)
    {
       // if (!IsPostBack)
        {
          
            string Type = Request.Cookies["Type_Role"].Value;


            UserInfo = "<a href='./index.aspx?Type=Index" + Type + "" +
            "'><img style='border:0px;padding:0px;' src='./Images/user_go.png'/>&nbsp;محیط اختصاصی</a>";
                
        }
    }

}
      
 




