using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MainDataModuleTableAdapters;
using System.Data;
using System;


public partial class UserControlPublic_Login : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {

        Panel1.DefaultButton = Button1.ID.ToString();

       

        //if (!IsPostBack)
        //{
        //    string[] cookies = Request.Cookies.AllKeys;
        //    foreach (string cookie in cookies)
        //    {
        //        Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
        //    }
        //}
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       // Response.Redirect("~//index.aspx?Type=IndexAdmin");
        if (RadioButtonList1.SelectedValue == "Parent")
        {
            DataTable dt = new tbl_ParentInformationTableAdapter().GetByUserNameAndPassword(TextBox1.Text, new main_class().Encode(TextBox2.Text));
            if (dt.Rows.Count > 0)
            {
                //      Response.Cookies.Add(new HttpCookie("username", TextBox1.Text));
                //    Response.Cookies.Add(new HttpCookie("password", new main_class().Encode(TextBox2.Text)));
                Response.Cookies.Add(new HttpCookie("ID_Role", dt.Rows[0]["Parent_ID"].ToString()));
                Response.Cookies.Add(new HttpCookie("Type_Role", RadioButtonList1.SelectedValue));
                Response.Redirect("~//index.aspx?Type=IndexParent");
            }
            else
            {
                lblEror.Visible = true;
            }
        }
        else if (RadioButtonList1.SelectedValue == "Student")
        {
            DataTable dt = new tbl_StudentInformationTableAdapter().GetDataByUserNameAndPassword(TextBox1.Text, new main_class().Encode(TextBox2.Text));
            if (dt.Rows.Count > 0)
            {
                //      Response.Cookies.Add(new HttpCookie("username", TextBox1.Text));
                //    Response.Cookies.Add(new HttpCookie("password", new main_class().Encode(TextBox2.Text)));
                Response.Cookies.Add(new HttpCookie("ID_Role", dt.Rows[0]["Student_ID"].ToString()));
                Response.Cookies.Add(new HttpCookie("Type_Role", RadioButtonList1.SelectedValue));
                Response.Redirect("~//index.aspx?Type=IndexStudent");
            }
            else
            {
                lblEror.Visible = true;
            }
        }
        else if (RadioButtonList1.SelectedValue == "Teacher")
        {
            DataTable dt = new tbl_TeacherInformationTableAdapter().GetDataByUserNameAndPassword(TextBox1.Text, new main_class().Encode(TextBox2.Text));
            if (dt.Rows.Count > 0)
            {
                //      Response.Cookies.Add(new HttpCookie("username", TextBox1.Text));
                //    Response.Cookies.Add(new HttpCookie("password", new main_class().Encode(TextBox2.Text)));
                Response.Cookies.Add(new HttpCookie("ID_Role", dt.Rows[0]["Teacher_ID"].ToString()));
                Response.Cookies.Add(new HttpCookie("Type_Role", RadioButtonList1.SelectedValue));
                Response.Redirect("~//index.aspx?Type=IndexTeacher");
            }
            else
            {
                lblEror.Visible = true;
            }
        }
        else if (RadioButtonList1.SelectedValue == "Admin")
        {
            DataTable dt = new tbl_AdminInformationTableAdapter().GetByUserNameAndPassword(TextBox1.Text, new main_class().Encode(TextBox2.Text));
            if (dt.Rows.Count > 0)
            {
                //      Response.Cookies.Add(new HttpCookie("username", TextBox1.Text));
                //    Response.Cookies.Add(new HttpCookie("password", new main_class().Encode(TextBox2.Text)));
                Response.Cookies.Add(new HttpCookie("ID_Role", dt.Rows[0]["Admin_ID"].ToString()));
                Response.Cookies.Add(new HttpCookie("Type_Role", RadioButtonList1.SelectedValue));
                Response.Redirect("~//index.aspx?Type=IndexAdmin");
            }
            else
            {
                lblEror.Visible = true;
            }
        }
        else
        {

        }

    }
}
