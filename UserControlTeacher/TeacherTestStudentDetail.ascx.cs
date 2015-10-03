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
    public string lblTestTitle = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            FillPath();
                FillTest();
                FillGrid();
        }
    }

    private void FillPath()
    {
        lblPath.Text = "<a href='index.aspx?Type=TestManage'>مدیریت آزمون آنلاین</a>" + " >> ";
        DataTable dt = new tbl_TestTableAdapter().GetDataByTest_ID(int.Parse(Request.QueryString["ID_Test"]));
        lblPath.Text = lblPath.Text + " مشاهده نتایج  >>  " + "<a href='index.aspx?Type=TeacherTestResultManage&ID_Test="+
            dt.Rows[0]["ID_Test"].ToString() + "'> "
            + dt.Rows[0]["T_Title"].ToString()+ "</a>" + " >> ";
    }

    private void FillTest()
    {
        int ID_Student = int.Parse(Request.QueryString["ID_Student"]);
        int ID_Test = int.Parse(Request.QueryString["ID_Test"]);

        DataTable dt = new tbl_TestTableAdapter().GetDataByTest_ID(ID_Test);
        lblTestTitle=dt.Rows[0]["t_title"].ToString();

        DataTable dt2= new tbl_TestResultTableAdapter().GetDataByScoreStudent(ID_Test,ID_Student);
        if (dt2.Rows.Count > 0)
        {
            txtScoreAllTest.Text = dt2.Rows[0]["tr_Score"].ToString();
        }

        DataTable dt3 = new tbl_StudentInformationTableAdapter().GetDataByStudent_ID(ID_Student);
        lblName.Text = dt3.Rows[0]["SI_Name"].ToString();
        if (lblName.Text.Length == 0)
        {
            lblName.Text = dt3.Rows[0]["SI_UserName"].ToString();

        }
        lblName.Text = "<a href='index.aspx?Type=StudentDetail&ID_Student=" + dt3.Rows[0]["Student_ID"].ToString() +
            "'>" + lblName.Text + "</a>";

    }
    private void FillGrid()
    {
        GridView1.SelectedIndex = -1;
        GridView1.DataSource = new tbl_TestQuestionTableAdapter().GetDataByDetailStudent(
            int.Parse(Request.QueryString["ID_Test"]));
        GridView1.DataBind();
    }
    private void Cancel()
    {
        Panel2.Visible = false;
        TextTitle.Text = "";
        LblHidden.ToolTip = "";
        GridView1.SelectedIndex = -1;
        Label1.Visible = false;
    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        int ID_Student = int.Parse(Request.QueryString["ID_Student"]);
        int ID_Test = int.Parse(Request.QueryString["ID_Test"]);
        DataTable dt= new tbl_TestResultTableAdapter().GetDataByScoreStudent(ID_Test,ID_Student);
        if (dt.Rows.Count > 0)
        {
            new tbl_TestResultTableAdapter().UpdateScoreStudent(double.Parse(txtScoreAllTest.Text),ID_Test, ID_Student );
        }
        else
        {
            new tbl_TestResultTableAdapter().Insert(ID_Test, ID_Student, double.Parse(txtScoreAllTest.Text));
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        int ID_Question = int.Parse(hiddenIDQ.Value);
        int ID_Student=int.Parse(Request.QueryString["ID_Student"]);
        DataTable dt = new tbl_TestResultDetailTableAdapter().GetDataByID_Student_ID_Question(ID_Student, ID_Question);
        if (dt.Rows.Count > 0)
        {
            new tbl_TestResultDetailTableAdapter().UpdateScoreStudent( double.Parse(TextBox1.Text),ID_Student, ID_Question);
        }
        else
        {
            new tbl_TestResultDetailTableAdapter().Insert(ID_Student, ID_Question, "", double.Parse(TextBox1.Text));
        }
        FillGrid();
        Cancel();
        Label1.Text = "نمره به درستی ثبت گردید";
        Label1.Visible = true;
    }

    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Cancel();
        hiddenIDQ.Value = ((Label)(GridView1.Rows[e.NewEditIndex].FindControl("lblID"))).Text;
        TextTitle.Text = ((HiddenField)(GridView1.Rows[e.NewEditIndex].FindControl("hiddenTitle"))).Value;
        lblAnswerWrite.Text = ((HiddenField)(GridView1.Rows[e.NewEditIndex].FindControl("hiddenAnswerWrite"))).Value;
        lblAnswerStudent.Text = ((HiddenField)(GridView1.Rows[e.NewEditIndex].FindControl("hiddenAnswerStudent"))).Value;
        TextBox1.Text = ((HiddenField)(GridView1.Rows[e.NewEditIndex].FindControl("hiddenScore"))).Value;
        if (((HiddenField)(GridView1.Rows[e.NewEditIndex].FindControl("hiddenType"))).Value=="Testi")
        {
            lblAnswerWrite.Text = lblAnswerWrite.Text.Replace("A", "گزینه الف").Replace("B", "گزینه ب").Replace("C", "گزینه ج").Replace("D", "گزینه د");
            lblAnswerStudent.Text = lblAnswerStudent.Text.Replace("A", "گزینه الف").Replace("B", "گزینه ب").Replace("C", "گزینه ج").Replace("D", "گزینه د");
        }
        GridView1.SelectedIndex = e.NewEditIndex;
        Panel2.Visible = true;
        TextBox1.Focus();
        
    }
   

    protected void Button2_Click(object sender, EventArgs e)
    {
        Cancel();
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {
            int ID_Student=int.Parse(Request.QueryString["ID_Student"]);
            int ID_Question=int.Parse( ((Label)(e.Row.FindControl("lblID"))).Text);
            DataTable dt = new tbl_TestResultDetailTableAdapter().GetDataByID_Student_ID_Question(ID_Student, ID_Question);
            if (dt.Rows.Count > 0)
            {
                ((Label)(e.Row.FindControl("lbl_MarkStudent"))).Text=dt.Rows[0]["trd_Score"].ToString();
                ((HiddenField)(e.Row.FindControl("hiddenAnswerStudent"))).Value = dt.Rows[0]["trd_result"].ToString();
                ((HiddenField)(e.Row.FindControl("hiddenScore"))).Value = dt.Rows[0]["trd_Score"].ToString();

            }
            else
            {
                ((Label)(e.Row.FindControl("lbl_MarkStudent"))).Text = "";
                ((HiddenField)(e.Row.FindControl("hiddenAnswerStudent"))).Value = "";
                ((HiddenField)(e.Row.FindControl("hiddenScore"))).Value = "";
            }
        }
    }
}


