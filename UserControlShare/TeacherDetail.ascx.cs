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
    public string TextEndTime = "";
    public string TextStartTime = "";

    public string Message = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Fill();
        }
    }
    private void Fill()
    {
        int ID = int.Parse(Request.QueryString["ID_Teacher"]);
        DataTable dt = new tbl_TeacherInformationTableAdapter().GetDataByID(ID);
        if (dt.Rows.Count > 0)
        {
            TextName = dt.Rows[0]["TI_Name"].ToString();
            TextFatherName = dt.Rows[0]["TI_FatherName"].ToString();
            TextAddress = dt.Rows[0]["TI_Address"].ToString();
            TextTell = dt.Rows[0]["TI_Tell"].ToString();
            TextPostalCode = dt.Rows[0]["TI_PostalCode"].ToString();
            TextExportPlace = dt.Rows[0]["TI_ExportPlace"].ToString();
            TextBirthDate = dt.Rows[0]["TI_BirthDate"].ToString();
            TextAdminCode = dt.Rows[0]["TI_TeacherCode"].ToString();
            TextUserName = dt.Rows[0]["TI_UserName"].ToString();
            TextEndTime = dt.Rows[0]["TI_Teacher_End_Time"].ToString();
            TextStartTime = dt.Rows[0]["TI_Teacher_Start_Time"].ToString();

            Image1.ImageUrl = dt.Rows[0]["TI_Picutre"].ToString();
            if (System.IO.File.Exists(Server.MapPath(Image1.ImageUrl)))
            {
                Image1.Visible = true;
            }
            else
            {
                Image1.Visible = true;
                Image1.ImageUrl = "~//Image_User//default_pic.png";
            }
            FillPath("Teacher", dt.Rows[0]["Teacher_ID"].ToString());
            
        }

    }


    private void FillPath(string Type, string ID)
    {
        string title = "";
        string name = "";

        DataTable dt= new tbl_TeacherInformationTableAdapter().GetDataByID(int.Parse(ID));
            name = dt.Rows[0]["TI_name"].ToString();
            if (name.Trim().Length == 0)
            {
                name = dt.Rows[0]["TI_username"].ToString();
            }
            title = " معلم ها";
            lblPath.Text = lblPath.Text +
                title + " >> " +
                "<a href='./index.aspx?Type=" + Type + "Detail&" +
                "ID_" + Type + "=" + ID + "'>" +
                name + "</a>";

            Message = "<a  href='index.aspx?Type=PersonalMessageInsert&Type_Role_Getter=" +
                Type + "&ID_Role_Getter=" + ID + "'>ارسال پیام شخصی</a>";
    }

   
}


