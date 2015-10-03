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
        if (!new main_class().CheckPermissionAdmin("ManageCategory", int.Parse(Request.Cookies["ID_Role"].Value)))
        {
            Response.Redirect("index.aspx?Type=AdminAccessDenied");
        }
        else
        {
            if (!IsPostBack)
            {
                FillGrid();
                FillPath();
            }
        }
    }

   

    private void FillPath()
    {
        lblPath.Text = "";
        if (Request.QueryString["ID_Root"] != null)
        {
            if (Request.QueryString["ID_Root"] != "-1")
            {
                DataTable dt2 = new tbl_CategoryTableAdapter().GetDataByID(int.Parse(Request.QueryString["ID_Root"]));
                string delimitedInfo = dt2.Rows[0]["Cat_Path"].ToString();
                string[] discreteInfo = delimitedInfo.Split(new char[] { ',' });
                string title = "";
                foreach (string Data in discreteInfo)
                {
                    if (Data == "-1")
                    {
                        title = "بخش اصلی";
                    }
                    else
                    {
                        int ID = int.Parse(Data);
                        DataTable dt = new tbl_CategoryTableAdapter().GetDataByID(ID);
                        if (dt.Rows.Count > 0)
                        {
                            title = dt.Rows[0]["Cat_Title"].ToString();
                        }
                    }
                    lblPath.Text = lblPath.Text + "<a href='./index.aspx?Type=AdminCategory&ID_Root=" +
                        Data + "'>" + title + "</a>" + " >> ";
                }
                lblPath.Text = lblPath.Text + "<a href='./index.aspx?Type=AdminCategory&ID_Root=" +
                    dt2.Rows[0]["Category_ID"].ToString() + "'>" + dt2.Rows[0]["Cat_Title"].ToString() + "</a>" + " >> ";
            }
            else
            {
                lblPath.Text = lblPath.Text + "<a href='./index.aspx?Type=AdminCategory&ID_Root=-1'>بخش اصلی</a>  >> ";
            }
        }
        else
        {
            lblPath.Text = lblPath.Text + "<a href='./index.aspx?Type=AdminCategory&ID_Root=-1'>بخش اصلی</a>  >> ";
        }
    }

    private void FillGrid()
    {

        int ID_Admin = int.Parse(Request.Cookies["ID_Role"].Value);
        DataTable dt2 = new tbl_AdminPermissionCategoryTableAdapter().GetDataByAPC_ID_Admin(ID_Admin);
        if (dt2.Rows.Count > 0)
        {
            string APC_Cat_Patch = dt2.Rows[0]["APC_Cat_Patch"].ToString();

            int ID = -1;
            if (Request.QueryString["ID_Root"] != null)
            {
                ID = int.Parse(Request.QueryString["ID_Root"]);
            }

            string[] discreteInfo2 = APC_Cat_Patch.Split(new char[] { ',' });
            int SathKarbar = 0;
            foreach (string Data2 in discreteInfo2)
            {
                SathKarbar++;
            }

            int SathJari = 0;
            DataTable dt = new tbl_CategoryTableAdapter().GetDataByID(ID);
            if (dt.Rows.Count > 0)
            {
                string delimitedInfo = dt.Rows[0]["Cat_Path"].ToString();
                string[] discreteInfo = delimitedInfo.Split(new char[] { ',' });
                foreach (string Data in discreteInfo)
                {
                    SathJari++;
                }
            }

            if (SathJari < SathKarbar && APC_Cat_Patch.Trim() != "-1")
            {
                GridView1.SelectedIndex = -1;
                GridView1.DataSource = new tbl_CategoryTableAdapter().GetDataByIDRootPermissionAdmin(ID, APC_Cat_Patch);
                GridView1.DataBind();
            }
            else
            {
                GridView1.SelectedIndex = -1;
                GridView1.DataSource = new tbl_CategoryTableAdapter().GetDataByID_Root(ID);
                GridView1.DataBind();
            }

            if (SathJari >= SathKarbar || APC_Cat_Patch.Trim() == "-1")
            {
                Button1.Enabled = true;
            }
            else
            {
                Button1.Enabled = false;

            }
            if (SathJari == 6 )
            {
                Button1.Enabled = false;
            }
           
        }
        else
        {
            GridView1.DataBind();

        }

    }

    private void Cancel()
    {
        TextTitle.Text = "";
        LblHidden.ToolTip = "";

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string path = "-1";
        int ID = -1;
        if (Request.QueryString["ID_Root"] != null)
        {
             ID = int.Parse(Request.QueryString["ID_Root"]);
        }

        if (Request.QueryString["ID_Root"] != null && Request.QueryString["ID_Root"] != "-1")
        {
            DataTable dt = new tbl_CategoryTableAdapter().GetDataByID(ID);
            path = dt.Rows[0]["Cat_Path"].ToString() + "," + ID;
        }
        if (LblHidden.ToolTip.Length == 0)
        {
            new tbl_CategoryTableAdapter().Insert(TextTitle.Text, ID, path);
        }
        else
        {
            int ID2 = int.Parse(LblHidden.ToolTip);
            new tbl_CategoryTableAdapter().UpdateCategroy(TextTitle.Text, ID, ID2);
        }
        Cancel();
        FillGrid();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        FillGrid();
        Cancel();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }
    //---------------------------------------Delete ---------------------------------------------------
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int ID = int.Parse(((Label)(GridView1.Rows[e.RowIndex].FindControl("lblID"))).Text);
        int i=0;

        // Delete Student Parent
        DataTable dt= new tbl_StudentInformationTableAdapter().GetDataByCategory_ID(ID);
        for (i = 0; i < dt.Rows.Count; i++)
        {
            new tbl_PersonalMessageTableAdapter().DeleteUserMessage("Student",
                int.Parse(dt.Rows[i]["Student_ID"].ToString()));
            new tbl_ScoreTableAdapter().DeleteStudent(int.Parse(dt.Rows[i]["Student_ID"].ToString())); 
        }


        DataTable dt2 = new tbl_ParentInformationTableAdapter().GetDataByCategory_ID(ID);
        for (i = 0; i < dt2.Rows.Count; i++)
        {
            new tbl_PersonalMessageTableAdapter().DeleteUserMessage("Parent",
                int.Parse(dt2.Rows[i]["Parent_ID"].ToString()));
        }

        new tbl_ParentInformationTableAdapter().DeleteCategory(ID);
        new tbl_StudentInformationTableAdapter().DeleteCategory(ID);


        // Delete Lesson
        DataTable dt3 = new tbl_LessonTableAdapter().GetDataByCategory_ID(ID);
        for (i = 0; i < dt3.Rows.Count; i++)
        {
            DataTable dt4=new tbl_ScoreTitleTableAdapter().GetDataByID_Lesson(int.Parse( dt3.Rows[i]["Lesson_ID"].ToString()));
            for (int j = 0; j < dt4.Rows.Count; j++)
            {
                new tbl_ScoreTableAdapter().DeleteTitle(int.Parse(dt4.Rows[j]["ScoreTitle_ID"].ToString()));
            }
            new tbl_ScoreTitleTableAdapter().DeleteLesson(int.Parse(dt3.Rows[i]["Lesson_ID"].ToString()));


            // Delete Test
            DataTable dt6 = new tbl_TestTableAdapter().GetDataByt_id_lesson(int.Parse(dt3.Rows[i]["Lesson_ID"].ToString()));
            for (int k = 0; k < dt4.Rows.Count; k++)
            {
                DataTable dt7 = new tbl_TestQuestionTableAdapter().GetDataByDetailStudent(int.Parse(dt6.Rows[k]["ID_Test"].ToString()));
                for (int f = 0; f< dt7.Rows.Count; f++)
                {
                    new tbl_TestResultDetailTableAdapter().DeleteQuestion(int.Parse(dt7.Rows[f]["TestQuestion_ID"].ToString()));
                }
                new tbl_TestQuestionTableAdapter().DeleteTest(int.Parse(dt6.Rows[k]["ID_Test"].ToString()));

                new tbl_TestResultTableAdapter().DeleteTest(int.Parse(dt6.Rows[k]["ID_Test"].ToString()));
            }
            new tbl_TestTableAdapter().DeleteLesson(int.Parse(dt3.Rows[i]["Lesson_ID"].ToString()));
        }
        new tbl_LessonTableAdapter().DeleteCategory(ID);



        // Delete Gallery
        DataTable dt5 = new tbl_GallerySubjectTableAdapter().GetDataByCategory_ID(ID);
        for (i = 0; i < dt5.Rows.Count; i++)
        {
            new tbl_GalleryPictureTableAdapter().Deletegp_ID_GallerySubject(int.Parse(dt5.Rows[i]["GallerySubjet_ID"].ToString()));
        }
        new tbl_GallerySubjectTableAdapter().DeleteCategory(ID);

        new tbl_AdminPermissionCategoryTableAdapter().DeleteCategory(ID.ToString());
        new tbl_ContentTableAdapter().DeleteCategory(ID);
        new tbl_LinkTableAdapter().DeleteCategory(ID);
        new tbl_CategoryTableAdapter().DeleteCategory(ID);
        FillGrid();
        Cancel();
    }
    //----------------------------------------------------------------------------------------------

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        int ID = int.Parse(((Label)(GridView1.Rows[e.NewEditIndex].FindControl("lblID"))).Text);
        DataTable dt = new tbl_CategoryTableAdapter().GetDataByID(ID);
        if (dt.Rows.Count > 0)
        {
            TextTitle.Text = dt.Rows[0]["Cat_Title"].ToString();
        }
        LblHidden.ToolTip = ID.ToString();
        GridView1.SelectedIndex = e.NewEditIndex;
    }

}


