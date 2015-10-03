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
        if (!new main_class().CheckPermissionAdmin("ManageOneRecord", int.Parse(Request.Cookies["ID_Role"].Value)))
        {
            Response.Redirect("index.aspx?Type=AdminAccessDenied");
        }
        else
        {
            if (!IsPostBack)
            {
                Fill();
                FillPath();
            }
        }
    }

    private void FillPath()
    {
        string title = "";
        string Type = Request.QueryString["Kind"];
       
        if (Type == "AboutSchool")
        {
            title = "درباره مووسسه";
        }
        if (Type == "SchoolGoals")
        {
            title = "اهداف مجتمع";
        }
        if (Type == "SchoolGoalsWay")
        {
            title = "راه های رسیدن به اهداف";
        }
        if (Type == "SchoolRegister")
        {
            title = "راهنمای ثبت نام";
        }
        if (Type == "SchoolSiteRegister")
        {
            title = "راهنمای ثبت نام سایت";
        }
        if (Type == "SchoolAdvice")
        {
            title = "بخش مشاوره";
        }
        if (Type == "AboutSchoolShort")
        {
            title = "معرفی کوتاه و اجمالی";
        }
        if (Type == "SchoolPersonel")
        {
            title = "همکاران";
        }
        if (Type == "SchoolTeachPlan")
        {
            title = "برنامه های آموزشی";
        }

        lblPath.Text = lblPath.Text + " مدیریت تنظیمات >> " + title + " >>";


    }



    private void Fill()
    {
        DataTable dt = new tbl_OneRecordTableAdapter().GetDataByOR_Type(Request.QueryString["Kind"]);
        if (dt.Rows.Count > 0)
        {
            TextTitle.Text = dt.Rows[0]["OR_Title"].ToString();
            FCKeditor1.Value= dt.Rows[0]["OR_Text"].ToString();
        }
        Label1.Visible = false;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        DataTable dt = new tbl_OneRecordTableAdapter().GetDataByOR_Type(Request.QueryString["Kind"]);
        if (dt.Rows.Count > 0)
        {
            new tbl_OneRecordTableAdapter().UpdateOR_Type(
                TextTitle.Text,
                FCKeditor1.Value,
                Request.QueryString["Kind"]
                );
        }
        else
        {

            new tbl_OneRecordTableAdapter().Insert(
                TextTitle.Text,
                FCKeditor1.Value,
                Request.QueryString["Kind"]
                );
        }
        Label1.Visible = true;
    }



    protected void Button2_Click(object sender, EventArgs e)
    {
        
        Fill();
    }

}


