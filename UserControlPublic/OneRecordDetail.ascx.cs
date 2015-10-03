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
    public string TitleContent = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Fill();
        }
    }


    private void Fill()
    {
        string  Type = Request.QueryString["Kind"];
        DataTable dt = new tbl_OneRecordTableAdapter().GetDataByOR_Type(Type);
        if (dt.Rows.Count > 0)
        {
            TitleContent = dt.Rows[0]["OR_title"].ToString();
            Label1.Text = dt.Rows[0]["OR_text"].ToString();
        }
        else
        {
            TitleContent = "عدم وجود متن";
            Label1.Text = "متنی در این بخش به ثبت نرسیده است.";

        }

       


    

    }
}






