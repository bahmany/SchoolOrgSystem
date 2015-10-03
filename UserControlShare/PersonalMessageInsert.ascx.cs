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

        if (!IsPostBack)
        {
            FillPath();
        }
    }

    private void FillPath()
    {
        string title = "";
        string name = "";
        string Type = Request.QueryString["Type_Role_Getter"];
        string ID = Request.QueryString["ID_Role_Getter"];
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
        lblPath.Text = lblPath.Text+ "ارسال پیام برای >> " +
            title  + " >> " +
            "<a href='./index.aspx?Type=" + Type + "Detail&" +
            "ID_"+Type +"=" + ID + "'>" +
            name + "</a>";


    }

    private void Cancel()
    {
        TextTitle.Text = "";
        FCKeditor1.Value = "";
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        new tbl_PersonalMessageTableAdapter().Insert(
            TextTitle.Text,
            FCKeditor1.Value,
            new main_class().GetDate(),
            "false",
            Request.QueryString["Type_Role_Getter"],
            int.Parse(Request.QueryString["ID_Role_Getter"]),
             Request.Cookies["Type_Role"].Value.ToString(),
              int.Parse(Request.Cookies["ID_Role"].Value.ToString()),
              "false",
              "false"
            );
        Response.Redirect("index.aspx?Type=PersonalMessageOutbox");

    }



    protected void Button2_Click(object sender, EventArgs e)
    {
        Cancel();
    }

}


