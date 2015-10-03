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
            if (int.Parse(getRemainSeconds()) > 0 && int.Parse(getStartSeconds()) > 0)
            {
                lblTime.Text = getRemainSeconds();
                FillTest();
                FillGrid();
            }
            else
            {
                Response.Redirect("index.aspx?Type=StudentTestEndTime");
            }

        }

    }

    private void FillTest()
    {
        DataTable dt = new tbl_TestTableAdapter().GetDataByTest_ID(int.Parse(Request.QueryString["ID_Test"]));
        lblTestTitle=dt.Rows[0]["t_title"].ToString();

    }
    private void FillGrid()
    {
        GridView1.SelectedIndex = -1;
        GridView1.DataSource = new tbl_TestQuestionTableAdapter().GetDataBytq_ID_Test(int.Parse(Request.QueryString["ID_Test"]));
        GridView1.DataBind();
    }
    private void Cancel()
    {
        TextA.Text = "";
        TextAnswer.Text = "";
        TextB.Text = "";
        TextC.Text = "";
        TextD.Text = "";
        TextA.Checked = false;
        TextB.Checked = false;
        TextC.Checked = false;
        TextD.Checked = false;
        Panel2.Visible = false;
        TextTitle.Text = "";
       
    
        LblHidden.ToolTip = "";
        GridView1.SelectedIndex = -1;
        Label1.Visible = false;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        int ID_Question = int.Parse(hiddenIDQ.Value);
        int ID_Student=int.Parse(Request.Cookies["ID_Role"].Value);
        string strAnswer = "";

        if (hiddenTypeQ.Value == "Testi")
        {
            if (TextA.Checked)
            {
                strAnswer = "A";
            }
            else if (TextB.Checked)
            {
                strAnswer = "B";
            }
            else if (TextC.Checked)
            {
                strAnswer = "C";
            }
            else if (TextD.Checked)
            {
                strAnswer = "D";
            }

        }
        else
        {
            strAnswer = TextAnswer.Text;
        }

        if (bool.Parse( HiddenAnwerState.Value))
        {
            new tbl_TestResultDetailTableAdapter().Update_AnswerStudent(
                strAnswer,
                ID_Student,
                ID_Question);
        }
        else
        {
            new tbl_TestResultDetailTableAdapter().Insert(
                ID_Student,
                ID_Question,
                strAnswer,
                null);
        }
        FillGrid();
        Cancel();
        Label1.Text = "پاسخ شما به درستی ثبت گردید";
        Label1.Visible = true;
    }
  
    protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
    {
        Cancel();
        int ID = int.Parse(((Label)(GridView1.Rows[e.NewEditIndex].FindControl("lblID"))).Text);
        DataTable dt = new tbl_TestQuestionTableAdapter().GetDataByTestQuestion_ID(ID);
        if (dt.Rows.Count > 0)
        {
            TextA.Text = dt.Rows[0]["tq_A"].ToString();  
            TextB.Text = dt.Rows[0]["tq_B"].ToString();
            TextC.Text = dt.Rows[0]["tq_C"].ToString();
            TextD.Text = dt.Rows[0]["tq_D"].ToString();
            TextTitle.Text = dt.Rows[0]["tq_Title"].ToString();
            TypeChanged(dt.Rows[0]["tq_Type"].ToString());
            hiddenTypeQ.Value = dt.Rows[0]["tq_Type"].ToString();
            hiddenIDQ.Value= ID.ToString();
            HiddenAnwerState.Value = ((CheckBox)(GridView1.Rows[e.NewEditIndex].FindControl("CheckBox1"))).Checked.ToString();
            TextAnswer.Text = ((HiddenField)(GridView1.Rows[e.NewEditIndex].FindControl("hiddenAnswer"))).Value;
            if (hiddenTypeQ.Value == "Testi")
            {
                if (TextAnswer.Text == "A")
                {
                    TextA.Checked = true;
                }
                else if (TextAnswer.Text == "B")
                {
                    TextB.Checked = true;
                }
                else if (TextAnswer.Text == "C")
                {
                    TextC.Checked = true;
                }
                else if (TextAnswer.Text == "D")
                {
                    TextD.Checked = true;
                }

            }
            GridView1.SelectedIndex = e.NewEditIndex;
            Panel2.Visible = true;

        }

    }
   

    protected void Button2_Click(object sender, EventArgs e)
    {
        Cancel();
    }
   
    void TypeChanged(string Type)
    {
        if (Type == "Tashrihi")
        {
            Panel1.Visible = false;
            Panel3.Visible = true;
        }
        else if (Type == "Testi")
        {
            Panel1.Visible = true;
            Panel3.Visible = false;
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowIndex != -1)
        {

            int ID_Question = int.Parse(((Label)(e.Row.FindControl("lblID"))).Text);
            int ID_Student = int.Parse(Request.Cookies["ID_Role"].Value);
            DataTable dt=new tbl_TestResultDetailTableAdapter().GetDataByID_Student_ID_Question(ID_Student, ID_Question);
            if (dt.Rows.Count == 0)
            {
                ((CheckBox)(e.Row.FindControl("CheckBox1"))).Checked = false;
            }
            else
            {
                ((HiddenField)(e.Row.FindControl("hiddenAnswer"))).Value= dt.Rows[0]["trd_Result"].ToString();
                ((CheckBox)(e.Row.FindControl("CheckBox1"))).Checked = true;
            }
        }
    }

    public string getRemainSeconds()
    {
        int secondEndExam = (int)new tbl_TestTableAdapter().GetSecondDiffByEndDateToNow(
            int.Parse(Request.QueryString["ID_Test"]));
        return secondEndExam.ToString();
    }
    public string getStartSeconds()
    {
        int secondStartExam = (int)new tbl_TestTableAdapter().GetSecondDiffByStartTimeToNow(
            int.Parse(Request.QueryString["ID_Test"]));
        return secondStartExam.ToString();
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        int ID_Question = int.Parse(hiddenIDQ.Value);
        int ID_Student = int.Parse(Request.Cookies["ID_Role"].Value);
        new tbl_TestResultDetailTableAdapter().DeleteStudentAnswer(ID_Student, ID_Question);
        FillGrid();
        Cancel();
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        lblTime.Visible = true;
        lblTime.Text = (int.Parse(lblTime.Text) - 1).ToString();
        TextAnswer.Focus();
        if (int.Parse(lblTime.Text) <= 0)
        {
            Response.Redirect("index.aspx?Type=StudentTestEndTime");
        }
    }
}


