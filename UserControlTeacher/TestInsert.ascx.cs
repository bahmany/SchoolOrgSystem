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
            FillPath();
            TextBox5.Text = new main_class().Convert_to_Shamsi(DateTime.Now);
            TextBox7.Text = new main_class().Convert_to_Shamsi(DateTime.Now);
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


        private void FillPath()
        {
            if (DropDownList1.Items.Count > 0)
            {


                DataTable dt5 = new tbl_LessonTableAdapter().GetDataByID(int.Parse(DropDownList1.SelectedValue));
                string ID_Category = dt5.Rows[0]["Les_ID_Category"].ToString();
                int ID = int.Parse(ID_Category);
                lblPath.Text = "";

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
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillPath();
        }
        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DropDownList2.SelectedValue == "Both")
            {
                TextBox1.Enabled = true;
                TextBox2.Enabled = true;
                TextBox3.Enabled = true;
                TextBox4.Enabled = true;
            }
            if (DropDownList2.SelectedValue == "Tashrihi")
            {
                TextBox1.Enabled = true;
                TextBox2.Enabled = true;
                TextBox3.Enabled = false;
                TextBox4.Enabled = false;
                TextBox3.Text = "0";
                TextBox4.Text = "0";

            }
            if (DropDownList2.SelectedValue == "Testi")
            {
                TextBox1.Enabled = false;
                TextBox2.Enabled = false;
                TextBox3.Enabled = true;
                TextBox4.Enabled = true;
                TextBox1.Text = "0";
                TextBox2.Text = "0";

            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                new tbl_TestTableAdapter().Insert(
                    TextName.Text,
                    DropDownList2.SelectedValue,
                    int.Parse(TextBox1.Text),
                    double.Parse(TextBox2.Text),
                    int.Parse(TextBox3.Text),
                    double.Parse(TextBox4.Text),
                    Convert.ToDateTime(new main_class().Convert_to_Midaly(TextBox5.Text, TextBox6.Text)),
                    Convert.ToDateTime(new main_class().Convert_to_Midaly(TextBox7.Text, TextBox8.Text)),
                    int.Parse(DropDownList1.SelectedValue));
                Response.Redirect("index.aspx?Type=TestManage");
            }
            catch
            {
                Label1.Text = "بعضی از اطالاعات اشتباه ثبت شده اند";
            }

        }
        protected void Button2_Click(object sender, EventArgs e)
        {

        }
}


