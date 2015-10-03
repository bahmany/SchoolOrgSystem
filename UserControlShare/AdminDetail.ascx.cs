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

    public string TextName = "";
    public string TextFatherName = "";
    public string TextAddress = "";
    public string TextTell = "";
    public string TextPostalCode = "";
    public string TextExportPlace = "";
    public string TextBirthDate = "";
    public string TextAdminCode = "";
    public string TextUserName = "";
    public string TextRoll = "";
    public string Message = "";
    public string TextEndTime = "";
    public string TextStartTime = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Fill();
        }
    }

    private void Fill()
    {
        int ID = int.Parse(Request.QueryString["ID_Admin"]);
        DataTable dt = new tbl_AdminInformationTableAdapter().GetDataByID(ID);
        if (dt.Rows.Count > 0)
        {
            TextName = dt.Rows[0]["AI_Name"].ToString();
            TextFatherName = dt.Rows[0]["AI_FatherName"].ToString();
            TextAddress = dt.Rows[0]["AI_Address"].ToString();
            TextTell = dt.Rows[0]["AI_Tell"].ToString();
            TextPostalCode = dt.Rows[0]["AI_PostalCode"].ToString();
            TextExportPlace = dt.Rows[0]["AI_ExportPlace"].ToString();
            TextBirthDate = dt.Rows[0]["AI_BirthDate"].ToString();
            TextAdminCode = dt.Rows[0]["AI_AdminCode"].ToString();
            TextUserName = dt.Rows[0]["AI_UserName"].ToString();
            TextRoll = dt.Rows[0]["AI_Role_Admin"].ToString();
            TextEndTime = dt.Rows[0]["AI_Admin_End_Time"].ToString();
            TextStartTime = dt.Rows[0]["AI_Admin_Start_Time"].ToString();

            Image1.ImageUrl = dt.Rows[0]["AI_Pic"].ToString();
            if (System.IO.File.Exists(Server.MapPath(Image1.ImageUrl)))
            {
            }
            else
            {
                Image1.ImageUrl = "~//Image_User//default_pic.png";
            }
            FillPath("Admin", dt.Rows[0]["Admin_ID"].ToString());

        }

    }

    private void FillPath(string Type, string ID)
    {
        string title = "";
        string name = "";

        DataTable dt = new tbl_AdminInformationTableAdapter().GetDataByID(int.Parse(ID));
        name = dt.Rows[0]["AI_name"].ToString();
        if (name.Trim().Length == 0)
        {
            name = dt.Rows[0]["AI_username"].ToString();
        }
        title = " مدیران";
        lblPath.Text = lblPath.Text  +
            title + " >> " +
            "<a href='./index.aspx?Type=" + Type + "Detail&" +
            "ID_" + Type + "=" + ID + "'>" +
            name + "</a>";

        Message = "<a  href='index.aspx?Type=PersonalMessageInsert&Type_Role_Getter=" +
            Type + "&ID_Role_Getter=" + ID + "'>ارسال پیام شخصی</a>";
    }



}


