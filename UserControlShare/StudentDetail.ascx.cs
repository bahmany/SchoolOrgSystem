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
    public string Message = "";
    public string TextEndTime = "";
    public string TextStartTime = "";
    public string TextFatherMobile = "";
    public string TextFatherJob = "";
    public string TextMotherMobile = "";
    public string TextMotherName = "";
    public string TextMotherJob = "";



    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Fill();
        }
    }

    private void Fill()
    {
        int ID = int.Parse(Request.QueryString["ID_Student"]);
        DataTable dt = new tbl_StudentInformationTableAdapter().GetDataByStudent_ID(ID);
        if (dt.Rows.Count > 0)
        {
            TextName = dt.Rows[0]["SI_Name"].ToString();
            TextFatherName = dt.Rows[0]["SI_FatherName"].ToString();
            TextAddress = dt.Rows[0]["SI_Address"].ToString();
            TextTell = dt.Rows[0]["SI_Tell"].ToString();
            TextPostalCode = dt.Rows[0]["SI_PostalCode"].ToString();
            TextExportPlace = dt.Rows[0]["SI_ExportPlace"].ToString();
            TextBirthDate = dt.Rows[0]["SI_BirthDate"].ToString();
            TextAdminCode = dt.Rows[0]["SI_StudentCode"].ToString();
            TextUserName = dt.Rows[0]["SI_UserName"].ToString();
            TextEndTime = dt.Rows[0]["SI_Stu_End_Time"].ToString();
            TextStartTime = dt.Rows[0]["SI_Stu_Start_Time"].ToString();

            TextFatherMobile = dt.Rows[0]["SI_FatherMobile"].ToString();
            TextFatherJob = dt.Rows[0]["SI_FatherJob"].ToString();
            TextMotherMobile = dt.Rows[0]["SI_MotherMobile"].ToString();
            TextMotherName = dt.Rows[0]["SI_MotherName"].ToString();
            TextMotherJob = dt.Rows[0]["SI_MotherJob"].ToString();

            Image1.ImageUrl = dt.Rows[0]["SI_Picture"].ToString();
            if (System.IO.File.Exists(Server.MapPath(Image1.ImageUrl)))
            {
            }
            else
            {
                Image1.ImageUrl = "~//Image_User//default_pic.png";
            }
            FillPath("Student", dt.Rows[0]["Student_ID"].ToString(), dt.Rows[0]["SI_ID_Category"].ToString());
        }

    }

    private void FillPath(string Type, string ID, string ID_Category)
    {
        string title = "";
        string name = "";

        DataTable dt = new tbl_StudentInformationTableAdapter().GetDataByStudent_ID(int.Parse(ID));
        name = dt.Rows[0]["SI_name"].ToString();
        if (name.Trim().Length == 0)
        {
            name = dt.Rows[0]["SI_username"].ToString();
        }
        title = " دانش آموزان";
        lblPath.Text = lblPath.Text  +
            title +  " >> " + FillPath2(ID_Category) +
            "<a href='./index.aspx?Type=" + Type + "Detail&" +
            "ID_" + Type + "=" + ID + "'>" + 
            name + "</a>";

        Message = "<a  href='index.aspx?Type=PersonalMessageInsert&Type_Role_Getter=" +
            Type + "&ID_Role_Getter=" + ID + "'>ارسال پیام شخصی</a>";
    }

    private string FillPath2(string ID_Category)
    {
        string Cat_Path = "";
        int ID = int.Parse(ID_Category);

        DataTable dt = new tbl_CategoryTableAdapter().GetDataByID(ID);
        if (dt.Rows.Count > 0)
        {
            string delimitedInfo = dt.Rows[0]["cat_Path"].ToString();
            string[] discreteInfo = delimitedInfo.Split(new char[] { ',' });
            string title = "";
            foreach (string Data in discreteInfo)
            {
                if (Data != "-1")
                {
                    int ID2 = int.Parse(Data);
                    DataTable dt2 = new tbl_CategoryTableAdapter().GetDataByID(ID2);
                    if (dt2.Rows.Count > 0)
                    {
                        title = dt2.Rows[0]["Cat_Title"].ToString();
                    }
                    Cat_Path = Cat_Path + title + " >> ";
                }
            }
             Cat_Path = Cat_Path + dt.Rows[0]["cat_title"].ToString() + " >> ";
        }
        else
        {
            Cat_Path = Cat_Path + "بدون بخش  >> ";
        }
        return Cat_Path;
    }

}


