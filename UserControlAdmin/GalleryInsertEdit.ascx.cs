using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MainDataModuleTableAdapters;
using System.Data;
using System.Data.SqlClient;


public partial class UserControlPublic_AdminInformationAdd : System.Web.UI.UserControl
{
    public void Save_File(System.Web.UI.WebControls.FileUpload File_Upload, string Address)
    {
        string str = "";
        str = Server.MapPath(Address);
        File_Upload.PostedFile.SaveAs(str);
    }
    string check_name_File(string Folder, string File_Name)
    {
        while (System.IO.File.Exists(Server.MapPath(Folder + File_Name)))
            File_Name = 'a' + File_Name;
        return Folder + File_Name;
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!new main_class().CheckPermissionAdmin("ManageGallery", int.Parse(Request.Cookies["ID_Role"].Value)))
        {
            Response.Redirect("index.aspx?Type=AdminAccessDenied");
        }
        else
        {
            if (!IsPostBack)
            {

                FillDr(-1, DropDownList1);
                FillDr(int.Parse(DropDownList1.SelectedValue), DropDownList2);
                FillDr(int.Parse(DropDownList2.SelectedValue), DropDownList3);
                FillDr(int.Parse(DropDownList3.SelectedValue), DropDownList4);
                FillDr(int.Parse(DropDownList4.SelectedValue), DropDownList5);
                FillDr(int.Parse(DropDownList5.SelectedValue), DropDownList6);
                if (Request.QueryString["ID_GallerySubject"] != null)
                {
                    Fill();
                }
                else
                {
                }
            }
        }
    }



    private void Fill()
    {
        int ID = int.Parse(Request.QueryString["ID_GallerySubject"].ToString());
        DataTable dt = new tbl_GallerySubjectTableAdapter().GetDataByGallerySubjet_ID(ID);
        if (dt.Rows.Count > 0)
        {
            LblHidden.ToolTip = Request.QueryString["ID_GallerySubject"].ToString();
            TextName.Text = dt.Rows[0]["gs_title"].ToString();
            CheckBox1.Checked=bool.Parse( dt.Rows[0]["gs_Active"].ToString());

        }
        FillFileUpload();
        DataTable dt2 = new tbl_CategoryTableAdapter().GetDataByID(int.Parse(dt.Rows[0]["gs_ID_Category"].ToString()));
        if (dt2.Rows.Count > 0)
        {
            string delimitedInfo = dt2.Rows[0]["Cat_Path"].ToString();
            string[] discreteInfo = delimitedInfo.Split(new char[] { ',' });
            int i = 1;
            foreach (string Data in discreteInfo)
            {
                if (Data == "-1")
                {
                    FillDr(int.Parse(Data), (DropDownList)FindControl("DropDownList" + i.ToString()));
                }
                else
                {
                    ((DropDownList)(FindControl("DropDownList" + (i - 1).ToString()))).Items.FindByValue(Data).Selected = true;
                    FillDr(int.Parse(Data), (DropDownList)FindControl("DropDownList" + i.ToString()));
                }
                i++;
            }
            ((DropDownList)(FindControl("DropDownList" + (i - 1).ToString()))).Items.FindByValue(dt.Rows[0]["gs_ID_Category"].ToString()).Selected = true;

        }
        Panel1.Visible = true;
        FillPath();


    }
    private void FillPath()
    {
        lblPath.Text = "<a href='./index.aspx?Type=GalleryManage'>" +
         "مدیریت گالری عکس" + "</a>" + " >> ";
    }
    private void FillDr(int ID_Category, DropDownList Dr)
    {

        int ID = int.Parse(Request.Cookies["ID_Role"].Value);
        DataTable dt = new tbl_AdminPermissionCategoryTableAdapter().GetDataByAPC_ID_Admin(ID);
        string DR_ID = Dr.ID.Substring(Dr.ID.Length - 1, 1);
        if (dt.Rows.Count > 0)
        {
            string APC_Cat_Patch = dt.Rows[0]["APC_Cat_Patch"].ToString();
            string[] discreteInfo = APC_Cat_Patch.Split(new char[] { ',' });
            int i = 0;
            foreach (string Data in discreteInfo)
            {
                i++;
            }
            Dr.Items.Clear();
            Dr.DataValueField = "Category_ID";
            Dr.DataTextField = "Cat_Title";

            if (i >= int.Parse(DR_ID) && APC_Cat_Patch.Trim() != "-1")
            {
                Dr.DataSource = new tbl_CategoryTableAdapter().GetDataByIDRootPermissionAdmin(ID_Category, APC_Cat_Patch);
                Dr.DataBind();
                Dr.Visible = true;
            }
            else
            {
                if (DR_ID != "1")
                {
                    Dr.Items.Add("همه");
                    Dr.Items[0].Value = "0";
                }
                Dr.DataSource = new tbl_CategoryTableAdapter().GetDataByID_Root(ID_Category);
                Dr.DataBind();
                Dr.Visible = true;
            }
        }
        else
        {
            if (DR_ID != "1")
            {
                Dr.Items.Add("هیچکدام");
                Dr.Items[0].Value = "-2";
                Dr.DataBind();
                Dr.Visible = true;
            }
        }
        if (DR_ID == "1")
        {
            Dr.Visible = true;
            Dr.Items.Insert(0, "عمومی");
            Dr.Items[0].Value = "-10";
        }

    }


    private void Cancel()
    {
        TextName.Text = "";
        Button1.Visible = true;
        Button3.Visible = false;
        LblHidden.ToolTip = "";

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string Folder = "~\\Image_User\\GalleryPicture\\";
        string File_Name = "";
        string Address_Full ="";
        int ID_Category = -10;
        if (DropDownList6.SelectedValue != "0")
        {
            ID_Category = int.Parse(DropDownList6.SelectedValue.ToString());
        }
        else if (DropDownList5.SelectedValue != "0")
        {
            ID_Category = int.Parse(DropDownList5.SelectedValue.ToString());
        }
        else if (DropDownList4.SelectedValue != "0")
        {
            ID_Category = int.Parse(DropDownList4.SelectedValue.ToString());
        }
        else if (DropDownList3.SelectedValue != "0")
        {
            ID_Category = int.Parse(DropDownList3.SelectedValue.ToString());
        }
        else if (DropDownList2.SelectedValue != "0")
        {
            ID_Category = int.Parse(DropDownList2.SelectedValue.ToString());
        }
        else if (DropDownList1.SelectedValue != "0")
        {
            ID_Category = int.Parse(DropDownList1.SelectedValue.ToString());
        }
        else
        {
            ID_Category = -10;
        }
        int ID_Admin = int.Parse(Request.Cookies["ID_Role"].Value);
        if (ID_Category == -2)
        {
            ID_Category = -10;
        }

        if (LblHidden.ToolTip.Length == 0)
        {
            SqlConnection con = new SqlConnection(new main_class().get_connection_string());
            SqlCommand cmd = new SqlCommand("InsertGallerySubject", con);
            cmd.Parameters.AddWithValue("@gs_Title", TextName.Text);
            cmd.Parameters.AddWithValue("@gs_ID_Admin", ID_Admin);
            cmd.Parameters.AddWithValue("@gs_ID_Category", ID_Category);
            cmd.Parameters.AddWithValue("@gs_Date", new main_class().GetDate());
            cmd.Parameters.AddWithValue("@gs_Active", CheckBox1.Checked.ToString());
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            dr.Read();
            int identity = int.Parse(dr["ID_GallerySubject2"].ToString());
            dr.Close();
            con.Close();

            FileUpload fp;
            for (int i = 1; i <= 10; i++)
            {
                fp = (FileUpload)this.FindControl("FileUpload" + i.ToString());
                File_Name = fp.FileName.ToString().Trim();
                Address_Full = check_name_File(Folder, File_Name);
                if (fp.HasFile && fp.PostedFile.ContentLength < 5120000)
                {

                    new tbl_GalleryPictureTableAdapter().Insert(Address_Full, identity);
                    Save_File(fp, Address_Full);
                }
            }
            
        }
        else
        {
            int ID = int.Parse(Request.QueryString["ID_GallerySubject"].ToString());
            new tbl_GallerySubjectTableAdapter().Update(
                TextName.Text,
                new main_class().GetDate(),
                CheckBox1.Checked.ToString(),
                ID_Admin,
                ID_Category,
                ID);
            FileUpload fp;
            HyperLink hl;
            new tbl_GalleryPictureTableAdapter().Deletegp_ID_GallerySubject(ID);
            for (int i = 1; i <= 10; i++)
            {
                fp = (FileUpload)this.FindControl("FileUpload" + i.ToString());
                hl = (HyperLink)this.FindControl("HyperLink" + i.ToString());
                File_Name = fp.FileName.ToString().Trim();
                Address_Full = check_name_File(Folder, File_Name);
                if ((fp.HasFile && fp.PostedFile.ContentLength < 5120000) || hl.NavigateUrl.Length>0)
                {
                    if (fp.HasFile)
                    {
                        new tbl_GalleryPictureTableAdapter().Insert(Address_Full, ID);
                        Save_File(fp, Address_Full);
                    }
                    else if (hl.NavigateUrl.Length > 0)
                    {
                        new tbl_GalleryPictureTableAdapter().Insert(hl.NavigateUrl, ID);
                    }

                }
            }
        }
        Response.Redirect("~//index.aspx?Type=GalleryManage");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["GallerySubject_ID"] != null)
        {
            Fill();
        }
        else
        {
            Cancel();
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1.SelectedValue == "-1")
        {
            FillDr(0, DropDownList2);
            FillDr(0, DropDownList3);
            FillDr(0, DropDownList4);
            FillDr(0, DropDownList5);
            FillDr(0, DropDownList6);
        }
        else
        {
            FillDr(int.Parse(DropDownList1.SelectedValue), DropDownList2);
        }

    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList2.SelectedValue == "-1")
        {
            FillDr(0, DropDownList3);
            FillDr(0, DropDownList4);
            FillDr(0, DropDownList5);
            FillDr(0, DropDownList6);
        }
        else
        {
            FillDr(int.Parse(DropDownList2.SelectedValue), DropDownList3);
        }
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList3.SelectedValue == "-1")
        {
            FillDr(0, DropDownList4);
            FillDr(0, DropDownList5);
            FillDr(0, DropDownList6);
        }
        else
        {
            FillDr(int.Parse(DropDownList3.SelectedValue), DropDownList4);
        }
    }
    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList4.SelectedValue == "-1")
        {
            FillDr(0, DropDownList5);
            FillDr(0, DropDownList6);
        }
        else
        {
            FillDr(int.Parse(DropDownList4.SelectedValue), DropDownList5);
        }
    }
    protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList5.SelectedValue == "-1")
        {
            FillDr(0, DropDownList6);
        }
        else
        {
            FillDr(int.Parse(DropDownList5.SelectedValue), DropDownList6);
        }
    }
    protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        int ID= int.Parse(lb.ToolTip);
        new tbl_GalleryPictureTableAdapter().Delete(ID);
        FillFileUpload();
    }

    private void FillFileUpload()
    {
        DataTable dt3 = new tbl_GalleryPictureTableAdapter().GetDataBygp_ID_GallerySubject(int.Parse(Request.QueryString["ID_GallerySubject"].ToString()));
        HyperLink hl;
        Image im;
        LinkButton lb;
        for (int i = 1; i <= dt3.Rows.Count; i++)
        {
            im = (Image)this.FindControl("Image" + (i * 2).ToString());
            im.Visible = true;
            im = (Image)this.FindControl("Image" + ((i * 2) - 1).ToString());
            im.Visible = true;
            lb = (LinkButton)this.FindControl("LinkButton" + i.ToString());
            lb.Visible = true;
            lb.ToolTip = dt3.Rows[i - 1]["GalleryPicture_ID"].ToString();
            hl = (HyperLink)this.FindControl("HyperLink" + i.ToString());
            hl.ToolTip = dt3.Rows[i - 1]["GalleryPicture_ID"].ToString();
            hl.Visible = true;
            hl.NavigateUrl = dt3.Rows[i - 1]["gp_Address"].ToString();
        }
        for (int j = dt3.Rows.Count + 1; j <= 10; j++)
        {
            im = (Image)this.FindControl("Image" + (j * 2).ToString());
            im.Visible = false;
            im = (Image)this.FindControl("Image" + ((j * 2) - 1).ToString());
            im.Visible = false;
            lb = (LinkButton)this.FindControl("LinkButton" + j.ToString());
            lb.Visible = false;
            lb.ToolTip = "";
            hl = (HyperLink)this.FindControl("HyperLink" + j.ToString());
            hl.ToolTip = "";
            hl.Visible = false;
            hl.NavigateUrl = "";

        }
    }
}


