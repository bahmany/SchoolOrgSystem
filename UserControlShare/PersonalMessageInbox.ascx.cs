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
        if(!IsPostBack)
        {
            FillGrid();
        }
    }

  
    private void FillGrid()
    {
     
            GridView1.SelectedIndex = -1;
            GridView1.DataSource = new tbl_PersonalMessageTableAdapter().GetDataByInbox(
              Request.Cookies["Type_Role"].Value.ToString(),
              int.Parse(Request.Cookies["ID_Role"].Value.ToString()));
            GridView1.DataBind();
    }

    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int ID = int.Parse(((Label)(GridView1.Rows[e.RowIndex].FindControl("lblID"))).Text);
        if (bool.Parse(((Label)(GridView1.Rows[e.RowIndex].FindControl("lblDelete_Sender"))).Text))
        {
            new tbl_PersonalMessageTableAdapter().Delete(ID);
        }
        else
        {
            new tbl_PersonalMessageTableAdapter().UpdateDeleteGetter(ID);
        }
        FillGrid();
   
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
                string title = "";
                string name = "";
                string Type = ((Label)(e.Row.FindControl("lblTypeSender"))).Text;
                string ID = ((Label)(e.Row.FindControl("lblIDSender"))).Text;
                DataTable dt;
                if (Type == "Admin")
                {
                    dt = new tbl_AdminInformationTableAdapter().GetDataByID(int.Parse(ID));
                    name = dt.Rows[0]["AI_name"].ToString();
                    if (name.Trim().Length == 0)
                    {
                        name = dt.Rows[0]["AI_username"].ToString();
                    }
                    title = "مدیر";
                }
                else if (Type == "Teacher")
                {
                    dt = new tbl_TeacherInformationTableAdapter().GetDataByID(int.Parse(ID));
                    name = dt.Rows[0]["TI_name"].ToString();
                    if (name.Trim().Length == 0)
                    {
                        name = dt.Rows[0]["TI_username"].ToString();
                    }
                    title = "معلم";
                }
                else if (Type == "Parent")
                {
                    dt = new tbl_ParentInformationTableAdapter().GetDataByID(int.Parse(ID));
                    name = dt.Rows[0]["PA_name"].ToString();
                    if (name.Trim().Length == 0)
                    {
                        name = dt.Rows[0]["PA_username"].ToString();
                    }

                    title = "اولیاء";
                }
                else if (Type == "Student")
                {
                    dt = new tbl_StudentInformationTableAdapter().GetDataByStudent_ID(int.Parse(ID));
                    name = dt.Rows[0]["SI_name"].ToString();
                    if (name.Trim().Length == 0)
                    {
                        name = dt.Rows[0]["SI_username"].ToString();
                    }
                    title = "دانش آموز";
                }

                ((Label)(e.Row.FindControl("lblName"))).Text = name + " ( " + title + " ) ";

                if (bool.Parse(((Label)(e.Row.FindControl("lblVision"))).Text))
                {
                    e.Row.Attributes.Add("onMouseOver", "this.style.background='#eeff00'");
                    e.Row.Attributes.Add("onMouseOut", "this.style.background='#EFF3FB'");
                    e.Row.BackColor = System.Drawing.Color.FromName("#EFF3FB");
                }
                else
                {
                    e.Row.BackColor = System.Drawing.Color.White;
                    e.Row.Attributes.Add("onMouseOver", "this.style.background='#eeff00'");
                    e.Row.Attributes.Add("onMouseOut", "this.style.background='White'");

                }

            }
        }
}


