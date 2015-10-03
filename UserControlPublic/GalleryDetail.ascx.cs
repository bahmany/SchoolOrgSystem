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
        new tbl_GallerySubjectTableAdapter().UpdateBazdid(int.Parse(Request.QueryString["ID_GallerySubject"]));
    }

    private void Fill()
    {
        int GallerySubjet_ID = int.Parse(Request.QueryString["ID_GallerySubject"]);
        DataTable dt = new tbl_GallerySubjectTableAdapter().GetDataByGallerySubjet_ID(GallerySubjet_ID);
        TitleContent = dt.Rows[0]["gs_title"].ToString();
        DateContent = dt.Rows[0]["gs_Date"].ToString();
        BazdidContent = dt.Rows[0]["gs_Bazdid"].ToString();

        // موضوع

        Label2.Text = "موضوع : <b>گالری تصاویر</b>";


        // نویسنده مطلب
        DataTable dt2;
        string Con_ID_Role = "0";

        dt2 = new tbl_AdminInformationTableAdapter().GetDataByID(int.Parse(dt.Rows[0]["gs_ID_Admin"].ToString()));
        AuthorContent = dt2.Rows[0]["AI_Name"].ToString();
        if (AuthorContent.Trim().Length == 0)
        {
            AuthorContent = dt2.Rows[0]["AI_UserName"].ToString();

        }
        Con_ID_Role = dt2.Rows[0]["Admin_ID"].ToString();

        AuthorContent = "<a href='./index.aspx?Type=AdminDetail&" +
                "ID_Admin=" + Con_ID_Role + "'>" +
                AuthorContent + "</a>";

        DataTable dt3 = new tbl_GalleryPictureTableAdapter().GetDataBygp_ID_GallerySubject(GallerySubjet_ID);
        DataList1.DataSource = dt3;
        DataList1.DataBind();


        // مسیر قرارگیری مطلب
        FillPath(dt.Rows[0]["gs_id_category"].ToString());


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






