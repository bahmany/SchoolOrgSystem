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
        if(!IsPostBack)
        {
            FillGrid();
        }
    }

    private void FillGrid()
    {
        if (Request.Cookies["Type_Role"].Value.ToString() == "Parent")
        {
            int ID_Role = int.Parse(Request.Cookies["ID_Role"].Value.ToString());
            DataTable dt = new tbl_ParentInformationTableAdapter().GetDataByParentInformationCategoryStudentInformationPersonParent(ID_Role);
            string cat_path = dt.Rows[0]["Cat_Path"].ToString();
            //Label4.Text = dt.Rows[0]["Cat_Path"].ToString();
            //TextBox1.Text = dt.Rows[0]["Cat_Path"].ToString();
            int ID_Category = int.Parse(dt.Rows[0]["Category_ID"].ToString());
            // Label4.Text = dt.Rows[0]["SI_ID_Category"].ToString();
            GridView1.DataSource = new tbl_ContentTableAdapter().GetDataByPersonCategory(ID_Category, "News", cat_path);
            GridView1.DataBind();
        }
        else
        {

            int ID_Role = int.Parse(Request.Cookies["ID_Role"].Value.ToString());
            DataTable dt = new tbl_StudentInformationTableAdapter().GetDataByStudentInformationCategoryWhereID_Student(ID_Role);
            string cat_path = dt.Rows[0]["Cat_Path"].ToString();
            //Label4.Text = dt.Rows[0]["Cat_Path"].ToString();
            //TextBox1.Text = dt.Rows[0]["Cat_Path"].ToString();
            int ID_Category = int.Parse(dt.Rows[0]["SI_ID_Category"].ToString());
            // Label4.Text = dt.Rows[0]["SI_ID_Category"].ToString();
            GridView1.DataSource = new tbl_ContentTableAdapter().GetDataByPersonCategory(ID_Category, "News", cat_path);
            GridView1.DataBind();
        }



    }


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        FillGrid();
    }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                int ID_Role = int.Parse(((Label)(e.Row.FindControl("ID_Role"))).Text.ToString());

                if (((Label)(e.Row.FindControl("Type_Role"))).Text == "Admin")
                {
                    DataTable dt = new tbl_AdminInformationTableAdapter().GetDataByID(ID_Role);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["AI_Name"].ToString().Length > 0)
                        {
                            ((Label)(e.Row.FindControl("lblName"))).Text = "توسط : " + dt.Rows[0]["AI_Name"].ToString();
                        }
                        else
                        {
                            ((Label)(e.Row.FindControl("lblName"))).Text = "توسط : " + dt.Rows[0]["AI_UserName"].ToString();

                        }
                    }
                }
                else
                {
                    DataTable dt = new tbl_TeacherInformationTableAdapter().GetDataByID(ID_Role);
                    if (dt.Rows.Count > 0)
                    {
                        if (dt.Rows[0]["TI_Name"].ToString().Length > 0)
                        {
                            ((Label)(e.Row.FindControl("lblName"))).Text = "توسط : " + dt.Rows[0]["TI_Name"].ToString();
                        }
                        else
                        {
                            ((Label)(e.Row.FindControl("lblName"))).Text = "توسط : " + dt.Rows[0]["TI_UserName"].ToString();
                        }
                    }
                }
            }

        }
}


