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
    public string BazdidContent = "";
    public string AuthorContent = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            UpdateBazdid();
            Fill();
        }
    }

    private void UpdateBazdid()
    {
        new tbl_ContentTableAdapter().UpdateBazdid(int.Parse(Request.QueryString["ID_Content"]));
    }

    private void Fill()
    {
        int ID_Content = int.Parse(Request.QueryString["ID_Content"]);
        DataTable dt = new tbl_ContentTableAdapter().GetDataByContent_ID(ID_Content);
        TitleContent = dt.Rows[0]["con_title"].ToString();
        DateContent = dt.Rows[0]["Con_Date"].ToString();
        BazdidContent = dt.Rows[0]["Con_Bazdid"].ToString();
        Label1.Text = dt.Rows[0]["con_text"].ToString();

        // موضوع
        if (dt.Rows[0]["Con_Type"].ToString() == "News")
        {
            Label2.Text = "موضوع : <b>اخبار و اطلاعیه ها</b>";
        }
        else if (dt.Rows[0]["Con_Type"].ToString() == "Break")
        {
            Label2.Text = "موضوع : <b>زنگ تفریح</b>";
        }
        else if (dt.Rows[0]["Con_Type"].ToString() == "Library")
        {
            Label2.Text = "موضوع : <b>کتابخانه</b>";
        }

        // نویسنده مطلب
        DataTable dt2;
        string  Con_ID_Role = "0";
        if (dt.Rows[0]["Con_Type_Role"].ToString() == "Teacher")
        {
            dt2 = new tbl_TeacherInformationTableAdapter().GetDataByID(int.Parse(dt.Rows[0]["Con_ID_Role"].ToString()));
            AuthorContent = dt2.Rows[0]["TI_Name"].ToString();
            if (AuthorContent.Trim().Length == 0)
            {
                AuthorContent = dt2.Rows[0]["TI_UserName"].ToString();

            }
            Con_ID_Role = dt2.Rows[0]["Teacher_ID"].ToString();

        }
        else if (dt.Rows[0]["Con_Type_Role"].ToString() == "Admin")
        {
            dt2 = new tbl_AdminInformationTableAdapter().GetDataByID(int.Parse(dt.Rows[0]["Con_ID_Role"].ToString()));
            AuthorContent = dt2.Rows[0]["AI_Name"].ToString();
            if (AuthorContent.Trim().Length == 0)
            {
                AuthorContent = dt2.Rows[0]["AI_UserName"].ToString();

            }
            Con_ID_Role = dt2.Rows[0]["Admin_ID"].ToString();
        }
        AuthorContent = "<a href='./index.aspx?Type=" + dt.Rows[0]["Con_Type_Role"].ToString() + "Detail&" +
                "ID_" + dt.Rows[0]["Con_Type_Role"].ToString() + "=" + Con_ID_Role + "'>" +
                AuthorContent + "</a>";


        // فایل پیوست 
        if (System.IO.File.Exists(Server.MapPath(dt.Rows[0]["Con_Attach"].ToString())))
        {
            HyperLink1.NavigateUrl = dt.Rows[0]["Con_Attach"].ToString();
            System.IO.FileStream f = new System.IO.FileStream(Server.MapPath(dt.Rows[0]["Con_Attach"].ToString()), System.IO.FileMode.Open);
            double a = f.Length;
            double b = 1024;
            double size = a / b;
            Label3.Text = size.ToString();
            Label3.Text = Label3.Text.Substring(0, 6);
            f.Close();
        }
        else
        {
            HyperLink1.NavigateUrl = "";
            Panel1.Visible = false;
        }

        // مسیر قرارگیری مطلب
        FillPath(dt.Rows[0]["con_id_category"].ToString());


    }
    private void FillPath(string ID_Category)
    {
        lblPath.Text = "";
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
                    lblPath.Text = lblPath.Text + title + " >> ";
                }
            }
            lblPath.Text = lblPath.Text + dt.Rows[0]["cat_title"].ToString() + " >> ";
        }
        else
        {
            lblPath.Text = lblPath.Text + "بخش عمومی  >> ";
        }
    }
}






