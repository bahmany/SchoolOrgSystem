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
                FillDrTeachher();
                if (Request.QueryString["Lesson_ID"] != null)
                {
                    Fill();
                }
            }
        }
    }

    private void FillDrTeachher()
    {
        DropDownList7.DataValueField = "Teacher_ID";
        DropDownList7.DataTextField = "TI_Name";
        DropDownList7.DataSource = new tbl_TeacherInformationTableAdapter().GetDataByTI_ID_Admin(int.Parse(Request.Cookies["ID_Role"].Value));
        DropDownList7.DataBind();

    }

    private void Fill()
    {
        int ID = int.Parse(Request.QueryString["Lesson_ID"].ToString());
        DataTable dt = new tbl_LessonTableAdapter().GetDataByID(ID);
        if (dt.Rows.Count > 0)
        {
            LblHidden.ToolTip = Request.QueryString["Lesson_ID"].ToString();
            TextName.Text = dt.Rows[0]["Les_Name"].ToString();
            TextUnit.Text = dt.Rows[0]["Les_Unit"].ToString();
            TextTime.Text = dt.Rows[0]["Les_Lesson_time"].ToString();
            if (DropDownList7.Items.Count > 0)
            {
                DropDownList7.Items.FindByValue(dt.Rows[0]["Les_ID_Teacher"].ToString()).Selected = true;
            }
        }
        FillDr(-1, DropDownList1);
        DataTable dt2 = new tbl_CategoryTableAdapter().GetDataByID(int.Parse(dt.Rows[0]["Les_ID_Category"].ToString()));
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
            ((DropDownList)(FindControl("DropDownList" + (i - 1).ToString()))).Items.FindByValue(dt.Rows[0]["Les_ID_Category"].ToString()).Selected = true;

        }
        Panel1.Visible = true;
        FillPath();


    }
    private void FillPath()
    {
        lblPath.Text = "<a href='./index.aspx?Type=LessonManage'>" +
         "مدیریت دروس" + "</a>" + " >> ";
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


    private void Cancel()
    {
        TextName.Text = "";
        TextTime.Text = "";


        TextUnit.Text = "";
        Button1.Visible = true;
        Button3.Visible = false;
        LblHidden.ToolTip = "";

    }

    protected void Button1_Click(object sender, EventArgs e)
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
        
        DataTable dt=new  tbl_TermTableAdapter().GetDataByWithActive("True");
        int ID_Term=int.Parse(dt.Rows[0]["Term_ID"].ToString());

        if (LblHidden.ToolTip.Length == 0)
        {

            new tbl_LessonTableAdapter().Insert(
                TextName.Text,
                int.Parse(TextUnit.Text),
                int.Parse(DropDownList7.SelectedValue),
                TextTime.Text,
                ID_Category,ID_Term);
        }
        else
        {
            int ID = int.Parse(Request.QueryString["Lesson_ID"].ToString());
            new tbl_LessonTableAdapter().Update(
                TextName.Text,
                int.Parse(TextUnit.Text),
                int.Parse(DropDownList7.SelectedValue),
                TextTime.Text,
                ID_Category, ID_Term,ID);
        }
        Response.Redirect("~//index.aspx?Type=LessonManage");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Request.QueryString["Lesson_ID"] != null)
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
}


