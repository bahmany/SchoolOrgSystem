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

    protected void Page_Load(object sender, EventArgs e)
    {

     
    }

   

   
    private void Cancel()
    {
        TextTitle.Text = "";
        TextBox1.Text = "";

        FCKeditor1.Value = "";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        new tbl_Call_USTableAdapter().Insert(
            TextTitle.Text,
            FCKeditor1.Value,
            TextBox1.Text,
            new main_class().GetDate(),
            "false");
        Label1.Visible = true;
        Cancel();
    }



    protected void Button2_Click(object sender, EventArgs e)
    {
        Cancel();
    }

}


