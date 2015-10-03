using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MainDataModuleTableAdapters;

public partial class UserControlPublic_Introduction : System.Web.UI.UserControl
{
    public string text = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Fill();
        }
    }


    private void Fill()
    {
        string Type = "AboutSchoolShort";
        DataTable dt = new tbl_OneRecordTableAdapter().GetDataByOR_Type(Type);
        if (dt.Rows.Count > 0)
        {
            text = dt.Rows[0]["OR_text"].ToString();
        }
        else
        {

            text = "متنی در این بخش به ثبت نرسیده است.";

        }






    }
}
