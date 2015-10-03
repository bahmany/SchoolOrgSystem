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
        if (!IsPostBack)
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
        DropDownList1.DataSource = new tbl_LessonTableAdapter().GetDataByLessonWithTeacher(int.Parse(Request.Cookies["ID_Role"].Value.ToString()));
        DropDownList1.DataBind();
        DropDownList1.Visible = true;
    }

    private void FillGrid()
    {
        if (DropDownList1.Items.Count > 0)
        {
            DataTable dt = new tbl_LessonTableAdapter().GetDataByID(int.Parse(DropDownList1.SelectedValue));
            int ID_Category = int.Parse(dt.Rows[0]["Les_ID_Category"].ToString());

            GridView1.SelectedIndex = -1;
            GridView1.DataSource = new tbl_StudentInformationTableAdapter().GetDataByCategory_ID(ID_Category);
            GridView1.DataBind();
            FillPath(ID_Category.ToString());
        }
        else
        {
            GridView1.DataBind();
        }
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        //DataTable dt = new tbl_ScoreTitleTableAdapter().GetDataByInsertScoreTitle(int.Parse(DropDownList1.SelectedValue),DropDownList2.SelectedValue,TextName.Text);
        //DataTable dt = new tbl_ScoreTitleTableAdapter().GetDataByInsertScoreTitle(
        // 1, "Patani", TextName.Text);

        SqlConnection con = new SqlConnection(new main_class().get_connection_string());
        SqlCommand cmd = new SqlCommand("InsertScoreTitle", con);
        cmd.Parameters.AddWithValue("@StID_Lesson", int.Parse(DropDownList1.SelectedValue));
        cmd.Parameters.AddWithValue("@StType", DropDownList2.SelectedValue);
        cmd.Parameters.AddWithValue("@StTitle", TextName.Text);
        cmd.CommandType = CommandType.StoredProcedure;
        con.Open();
        SqlDataReader dr = cmd.ExecuteReader();
        dr.Read();
        int identity = int.Parse(dr["ID_ScoreTitle2"].ToString());
        dr.Close();
        con.Close();

        int Grid_Rows_Count = GridView1.Rows.Count;
        int id = 0;
        for (int i = 0; i < Grid_Rows_Count; i++)
        {
            id = int.Parse(((Label)(GridView1.Rows[i].FindControl("lblID"))).Text);
            new tbl_ScoreTableAdapter().Insert(id, identity, ((TextBox)(GridView1.Rows[i].FindControl("TextBox1"))).Text);
        }
        Response.Redirect("index.aspx?Type=ScoreManage");

    }
}


