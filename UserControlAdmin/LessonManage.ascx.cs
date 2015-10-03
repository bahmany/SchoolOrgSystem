﻿using System;
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
        if (!new main_class().CheckPermissionAdmin("ManageLesson", int.Parse(Request.Cookies["ID_Role"].Value)))
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
                FillGrid();

            }
        }
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
            Dr.Items.Add("هیچکدام");
            Dr.Items[0].Value = "-2";
            Dr.DataBind();
            Dr.Visible = true;
        }
    }

    private void FillGrid()
    {
        int ID_Category = 0;
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
            ID_Category = 0;
        }
        GridView1.SelectedIndex = -1;
        GridView1.DataSource = new tbl_LessonTableAdapter().GetDataByCategory_ID(ID_Category);
        GridView1.DataBind();



    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int ID = int.Parse(((Label)(GridView1.Rows[e.RowIndex].FindControl("lblID"))).Text);
       

        DataTable dt4 = new tbl_ScoreTitleTableAdapter().GetDataByID_Lesson(ID);
        for (int j = 0; j < dt4.Rows.Count; j++)
        {
            new tbl_ScoreTableAdapter().DeleteTitle(int.Parse(dt4.Rows[j]["ScoreTitle_ID"].ToString()));
        }
        new tbl_ScoreTitleTableAdapter().DeleteLesson(ID);


        // Delete Test
        DataTable dt6 = new tbl_TestTableAdapter().GetDataByt_id_lesson(ID);
        for (int k = 0; k < dt4.Rows.Count; k++)
        {
            DataTable dt7 = new tbl_TestQuestionTableAdapter().GetDataByDetailStudent(int.Parse(dt6.Rows[k]["ID_Test"].ToString()));
            for (int f = 0; f < dt7.Rows.Count; f++)
            {
                new tbl_TestResultDetailTableAdapter().DeleteQuestion(int.Parse(dt7.Rows[f]["TestQuestion_ID"].ToString()));
            }
            new tbl_TestQuestionTableAdapter().DeleteTest(int.Parse(dt6.Rows[k]["ID_Test"].ToString()));

            new tbl_TestResultTableAdapter().DeleteTest(int.Parse(dt6.Rows[k]["ID_Test"].ToString()));
        }
        new tbl_TestTableAdapter().DeleteLesson(ID);


        new tbl_LessonTableAdapter().Delete(ID);
        FillGrid();


    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        FillGrid();
    }

    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

        FillDr(0, DropDownList3);
        FillDr(0, DropDownList4);
        FillDr(0, DropDownList5);
        FillDr(0, DropDownList6);
        FillDr(int.Parse(DropDownList1.SelectedValue), DropDownList2);

        FillGrid();

    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {

        FillDr(0, DropDownList4);
        FillDr(0, DropDownList5);
        FillDr(0, DropDownList6);
        FillDr(int.Parse(DropDownList2.SelectedValue), DropDownList3);

        FillGrid();
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {

        FillDr(0, DropDownList5);
        FillDr(0, DropDownList6);
        FillDr(int.Parse(DropDownList3.SelectedValue), DropDownList4);

        FillGrid();
    }
    protected void DropDownList4_SelectedIndexChanged(object sender, EventArgs e)
    {

        FillDr(0, DropDownList6);
        FillDr(int.Parse(DropDownList4.SelectedValue), DropDownList5);

        FillGrid();
    }
    protected void DropDownList5_SelectedIndexChanged(object sender, EventArgs e)
    {


        FillDr(int.Parse(DropDownList5.SelectedValue), DropDownList6);

        FillGrid();
    }
    protected void DropDownList6_SelectedIndexChanged(object sender, EventArgs e)
    {
        FillGrid();
    }
}


