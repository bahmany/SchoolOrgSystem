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
        if (Request.QueryString["Kind"] == "Inbox")
        {
            new tbl_PersonalMessageTableAdapter().UpdateVision(int.Parse(Request.QueryString["ID_PersonalMessage"]));
        }
    }

    private void Fill()
    {
        DataTable dt = new tbl_PersonalMessageTableAdapter().GetDataByID(int.Parse(Request.QueryString["ID_PersonalMessage"]));
        TitleContent = dt.Rows[0]["PM_title"].ToString();
        DateContent = dt.Rows[0]["PM_Date"].ToString();
        Label1.Text = dt.Rows[0]["PM_text"].ToString();
        if (Request.QueryString["Kind"] == "Inbox")
        {
            FillPath(dt.Rows[0]["PM_Type_Role_Sender"].ToString(), dt.Rows[0]["PM_ID_Role_Sender"].ToString());
        }
        else if (Request.QueryString["Kind"] == "Outbox")
        {
            FillPath(dt.Rows[0]["PM_Type_Role_Getter"].ToString(), dt.Rows[0]["PM_ID_Role_Getter"].ToString());
        }

    }

    private void FillPath(string Type,string ID)
    {
        string title = "";
        string name = "";

        DataTable dt;
        if (Type == "Admin")
        {
            dt = new tbl_AdminInformationTableAdapter().GetDataByID(int.Parse(ID));
            name = dt.Rows[0]["AI_name"].ToString();
            if (name.Trim().Length == 0)
            {
                name = dt.Rows[0]["AI_username"].ToString();
            }
            title = " مدیران";
        }
        else if (Type == "Teacher")
        {
            dt = new tbl_TeacherInformationTableAdapter().GetDataByID(int.Parse(ID));
            name = dt.Rows[0]["TI_name"].ToString();
            if (name.Trim().Length == 0)
            {
                name = dt.Rows[0]["TI_username"].ToString();
            }
            title = " معلم ها";
        }
        else if (Type == "Parent")
        {
            dt = new tbl_ParentInformationTableAdapter().GetDataByID(int.Parse(ID));
            name = dt.Rows[0]["PA_name"].ToString();
            if (name.Trim().Length == 0)
            {
                name = dt.Rows[0]["PA_username"].ToString();
            }

            title = " اولیاء";
        }
        else if (Type == "Student")
        {
            dt = new tbl_StudentInformationTableAdapter().GetDataByStudent_ID(int.Parse(ID));
            name = dt.Rows[0]["SI_name"].ToString();
            if (name.Trim().Length == 0)
            {
                name = dt.Rows[0]["SI_username"].ToString();
            }

            title = " دانش آموزان";
        }
        if (Request.QueryString["Kind"] == "Inbox")
        {
            lblPath.Text = lblPath.Text + "<a href='index.aspx?Type=PersonalMessageInbox'> پیام های دریافتی </a> >> " +
                title + " >> " +
                "<a href='./index.aspx?Type=" + Type + "Detail&" +
                "ID_" + Type + "=" + ID + "'>" +
                name + "</a>";
        }
        else if (Request.QueryString["Kind"] == "Outbox")
        {
            lblPath.Text = lblPath.Text + "<a href='index.aspx?Type=PersonalMessageOutbox'> پیام های فرستاده شده </a> >> "+
                title +  " >> " +
                "<a href='./index.aspx?Type=" + Type + "Detail&" +
                "ID_" + Type + "=" + ID + "'>" +
                name + "</a>";

        }
        if (Request.QueryString["Kind"] == "Inbox")
        {
            AuthorContent = "<a href='index.aspx?Type=PersonalMessageInsert&Type_Role_Getter=" + Type + "&ID_Role_Getter=" + ID + "'>پاسخ به " + name + "</a>";
        }
        else if (Request.QueryString["Kind"] == "Outbox")
        {
            AuthorContent = "<a href='index.aspx?Type=PersonalMessageInsert&Type_Role_Getter=" + Type + "&ID_Role_Getter=" + ID + "'>ارسالی دیگر به " + name + "</a>";
        }
    }


}







