using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;

public partial class ChatRoom : System.Web.UI.Page
{
    XHandle xmll;
    
    List<string> names;
    List<string> msgs;

    private delegate void AsyncCallingNames();
    private delegate void AsyncCallingMessages();

    AsyncCallingNames callerNames;
    AsyncCallingMessages callerMessages;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["userName"] = null;
        }
        Anthem.Manager.Register(this);

        xmll = new XHandle(Server.MapPath("App_Data"), "FirstChatRoom");
        //Get chat room name from user or chat admin

        int x = xmll.GetNumberOfOnlines();
        if (Session["userName"] != null)
        {
            LabelError.Text = "Online, Users Online: " + x.ToString();
        }
        else
        {
            LabelError.Text = "Offline, Users Online: " + x.ToString();
        }

        Timer1.Interval = 2;
        //I set it to 1 second, and it wroked very well

        Timer1.Tick += new EventHandler(Timer1_Tick);

        callerNames = new AsyncCallingNames(this.RefreshListNames);
        callerMessages = new AsyncCallingMessages(this.RefreshMessages);
    }


    void Timer1_Tick(object sender, EventArgs e)
    {
        if (Session["userName"] != null)
        {
            IAsyncResult resultN = callerNames.BeginInvoke(null, null);
            if (!resultN.IsCompleted)
            {
                callerNames.EndInvoke(resultN);
            }

            IAsyncResult resultM = callerMessages.BeginInvoke(null, null);
            if (!resultM.IsCompleted)
            {
                callerMessages.EndInvoke(resultM);
            }
            TextBoxType2.Focus();
        }
        else
        {
            Timer1.StopTimer();
            TextBoxType2.Text = "You have to join with a name first..";
        }
    }


    private void RefreshListNames()
    {
        ListBox1.Items.Clear();
        names = xmll.GetOnlineNames();
        foreach (var name in names)
        {
            ListBox1.Items.Add(name);
        }
    }

    private void RefreshMessages()
    {
        ListBox2.Items.Clear();
        msgs = xmll.GetMessagesHistory();
        foreach (var msg in msgs)
        {
            ListBox2.Items.Add(msg);
        }
    }

    protected void ButtonJoin_Click(object sender, EventArgs e)
    {
        if (Session["userName"] == null)
        {
            Session["userName"] = TextBoxName.Text.ToString();
            xmll.Join(Session["userName"].ToString(), DateTime.Now);

            TextBoxName.Enabled = false;

            Timer1.StartTimer();

            TextBoxType2.Focus(); 
        }
    }
    protected void ButtonSend_Click(object sender, EventArgs e)
    {
        if (Session["userName"] != null)
        {
            string name = (string)Session["userName"];
            string msg = TextBoxType2.Text.ToString();
            xmll.Say(name, msg, DateTime.Now);
            TextBoxType2.Text = "";
            TextBoxType2.Focus();
        }
        else
        {
            LabelError.Text = "You have to join with a name first..";
        }
    }

    [Anthem.Method]
    public void Leave()
    {
        Timer1.StopTimer();

        if (Session["userName"] != null)
        {
            string name = (string)Session["userName"];
            xmll.Leave(name, DateTime.Now);

            LabelError.Text = "Offline";
        }
    }
}





