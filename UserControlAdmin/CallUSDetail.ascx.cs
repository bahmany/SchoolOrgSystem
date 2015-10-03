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
    public string DateContent = "";
    public string AuthorContent = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UpdateVision();
            Fill();
        }
    }

    private void UpdateVision()
    {

        new tbl_Call_USTableAdapter().UpdateVision(int.Parse(Request.QueryString["CallUS_ID"]));
        
    }

    private void Fill()
    {
        DataTable dt = new tbl_Call_USTableAdapter().GetDataByCall_US_ID(int.Parse(Request.QueryString["CallUS_ID"]));
        TitleContent = dt.Rows[0]["cu_title"].ToString();
        DateContent = dt.Rows[0]["cu_Date"].ToString();
        Label1.Text = dt.Rows[0]["cu_text"].ToString();
       
        
        AuthorContent=" توسط : " +dt.Rows[0]["cu_name"].ToString();
        lblPath.Text = lblPath.Text + "<a href='index.aspx?Type=CallUSManage'> مدیریت تماس ما </a> >> ";
    }

 

}







