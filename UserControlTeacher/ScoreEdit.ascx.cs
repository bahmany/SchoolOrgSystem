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
            Fill();
            FillGrid();
        }
    }

    private void Fill()
    {
        DataTable dt = new tbl_ScoreTitleTableAdapter().GetDataByID(int.Parse(Request.QueryString["ScoreTitle_ID"]));
        TextName.Text = dt.Rows[0]["StTitle"].ToString();
        DropDownList2.Items.FindByValue(dt.Rows[0]["StType"].ToString()).Selected = true;
        HiddenField1.Value = dt.Rows[0]["StID_Lesson"].ToString();
        FillPath(dt.Rows[0]["StID_Lesson"].ToString());
    }

   
    private void FillGrid()
    {
            GridView1.SelectedIndex = -1;
            GridView1.DataSource = new tbl_ScoreTableAdapter().GetDataByID_ScoreTitle(int.Parse(Request.QueryString["ScoreTitle_ID"]));
            GridView1.DataBind();
    }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        FillGrid();
    }

        private void FillPath(string ID_Lesson)
        {

            DataTable dt3 = new tbl_LessonTableAdapter().GetDataByID(int.Parse(ID_Lesson));
            int ID_Category = int.Parse(dt3.Rows[0]["Les_ID_Category"].ToString());

            lblPath.Text = "";
            int ID = ID_Category;

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
            lblPath.Text = lblPath.Text + " درس " + dt3.Rows[0]["Les_Name"].ToString() + " >> ";
        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGrid();
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            new tbl_ScoreTitleTableAdapter().Update(
                int.Parse(HiddenField1.Value),
                DropDownList2.SelectedValue,
                TextName.Text,
                int.Parse(Request.QueryString["ScoreTitle_ID"]));

            int Grid_Rows_Count = GridView1.Rows.Count;
            int id = 0;
            for (int i = 0; i < Grid_Rows_Count; i++)
            {
                id = int.Parse(((Label)(GridView1.Rows[i].FindControl("lblID"))).Text);
                new tbl_ScoreTableAdapter().UpdateScore(
                     ((TextBox)(GridView1.Rows[i].FindControl("TextBox1"))).Text,id);
            }
            Response.Redirect("index.aspx?Type=ScoreManage");

        }
}


