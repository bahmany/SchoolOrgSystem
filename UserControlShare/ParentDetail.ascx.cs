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
    public string TextAddress = "";
    public string TextTell = "";
    public string TextUserName = "";
    public string Message = "";
    public string TextEndTime = "";
    public string TextStartTime = "";
    public string TextMobile = "";
    public string TextJob = "";
    public string ChildName = "";


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Fill();
        }
    }

    private void Fill()
    {
        int ID = int.Parse(Request.QueryString["ID_Parent"]);
        DataTable dt = new tbl_ParentInformationTableAdapter().GetDataByID(ID);
        if (dt.Rows.Count > 0)
        {
            TextName = dt.Rows[0]["PA_Name"].ToString();
            TextAddress = dt.Rows[0]["PA_Address"].ToString();
            TextTell = dt.Rows[0]["PA_Tell"].ToString();
            TextUserName = dt.Rows[0]["PA_UserName"].ToString();
            TextEndTime = dt.Rows[0]["PA_End_Time"].ToString();
            TextStartTime = dt.Rows[0]["PA_Start_Time"].ToString();
            TextMobile = dt.Rows[0]["PA_Mobile"].ToString();
            TextJob = dt.Rows[0]["PA_Job"].ToString();

            Image1.ImageUrl = dt.Rows[0]["PA_Pic"].ToString();
            if (System.IO.File.Exists(Server.MapPath(Image1.ImageUrl)))
            {
            }
            else
            {
                Image1.ImageUrl = "~//Image_User//default_pic.png";
            }
            FillPath("Parent", dt.Rows[0]["Parent_ID"].ToString());
            FillChild("Student",dt.Rows[0]["PA_ID_Student"].ToString());
        }

    }

    private void FillPath(string Type, string ID)
    {
        string title = "";
        string name = "";

        DataTable dt = new tbl_ParentInformationTableAdapter().GetDataByID(int.Parse(ID));
        name = dt.Rows[0]["PA_name"].ToString();
        if (name.Trim().Length == 0)
        {
            name = dt.Rows[0]["PA_username"].ToString();
        }
        title = " اولیاء";
        lblPath.Text = lblPath.Text +
            title  + " >> " +
            "<a href='./index.aspx?Type=" + Type + "Detail&" +
            "ID_" + Type + "=" + ID + "'>" + 
            name + "</a>";

        Message = "<a  href='index.aspx?Type=PersonalMessageInsert&Type_Role_Getter=" +
            Type + "&ID_Role_Getter=" + ID + "'>ارسال پیام شخصی</a>";
    }

    private void FillChild(string Type,string ID)
    {
        string name = "";

        DataTable dt = new tbl_StudentInformationTableAdapter().GetDataByStudent_ID(int.Parse(ID));
        name = dt.Rows[0]["SI_name"].ToString();
        if (name.Trim().Length == 0)
        {
            name = dt.Rows[0]["SI_username"].ToString();
        }
        if (Request.Cookies["Type_Role"].Value != "Parent")
        {

            ChildName = "<a href='./index.aspx?Type=" + Type + "Detail&" +
                "ID_" + Type + "=" + ID + "'>" +
                name + "</a>";
        }
        else
        {
            ChildName = name;
        }

    }

}


