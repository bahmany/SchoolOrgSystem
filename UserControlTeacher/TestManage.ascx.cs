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

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            FillDr();
            FillGrid();
        }
    }

    private void FillDr()
    {
        DropDownList1.Items.Clear();
        DropDownList1.DataValueField = "Lesson_ID";
        DropDownList1.DataTextField = "NameLessonCategory";
        DropDownList1.DataSource = new tbl_LessonTableAdapter().GetDataByLessonWithTeacher(
            int.Parse(Request.Cookies["ID_Role"].Value.ToString()));
        DropDownList1.DataBind();
        DropDownList1.Visible = true;
    }

    private void FillGrid()
    {
        if (DropDownList1.Items.Count > 0)
        {
            DataTable dt = new tbl_LessonTableAdapter().GetDataByID(int.Parse(DropDownList1.SelectedValue));
            int ID_Category =int.Parse( dt.Rows[0]["Les_ID_Category"].ToString());
            FillPath(ID_Category.ToString());

            GridView1.SelectedIndex = -1;
            GridView1.DataSource = new tbl_TestTableAdapter().GetDataByt_id_lesson(int.Parse(DropDownList1.SelectedValue));
            GridView1.DataBind();
        }
        else
        {
            GridView1.DataBind();
        }
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int ID = int.Parse(((Label)(GridView1.Rows[e.RowIndex].FindControl("lblID"))).Text);
        new tbl_TestQuestionTableAdapter().DeleteTest(ID);
        new tbl_TestTableAdapter().Delete(ID);
        FillGrid();
   
    }
    
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        FillGrid();
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
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGrid();
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowIndex != -1)
            {
                if (((HiddenField)(e.Row.FindControl("HiddenField1"))).Value == "BargozarNashode")
                {
                    ((HyperLink)(e.Row.FindControl("HyperLink2"))).Visible = true;
                    ((ImageButton)(e.Row.FindControl("ImageButton1"))).Visible = true;

                }
                else
                {
                    ((HyperLink)(e.Row.FindControl("HyperLink2"))).Visible = false;

                }

                if (((HiddenField)(e.Row.FindControl("HiddenField1"))).Value == "BargozarShode")
                {
                    ((HyperLink)(e.Row.FindControl("HyperLink1"))).Visible = true;
                }
                else
                {
                    ((HyperLink)(e.Row.FindControl("HyperLink1"))).Visible = false;

                }
            }
        }
}


