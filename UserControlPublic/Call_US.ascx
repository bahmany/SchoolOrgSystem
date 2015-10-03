<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Call_US.ascx.cs"
    Inherits="UserControlPublic_AdminInformationAdd" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>

<div class="PanelContainerBig">
    <div class="PanelContainerTopBig">
    </div>
    <div class="PanelContainerBodyBig">
        <span class="PanelContainerBodySpanBig" style="margin-bottom: 20px;">تماس با ما</asp:Label></span>
        <div style="margin-right: 20px; margin-left: 10px;">
            <span class="SpanHelp">شما در این بخش میتوانید به مدیریت پیامی ارسال نمایید :
            </span>
            <br />
            <br />
        </div>
        <div style="margin-right: 30px;">
            <span class="SpanNormal">عنوان :</span><asp:TextBox style="width: 350px;" CssClass="TextBoxNormal" ID="TextTitle"
                runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Register" ControlToValidate="TextTitle" runat="server"
             ErrorMessage="اجباری"></asp:RequiredFieldValidator>
            <br />
             <span class="SpanNormal">نام و نام خانوادگی :</span><asp:TextBox style="width: 350px;" CssClass="TextBoxNormal" ID="TextBox1"
                runat="server"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Register" ControlToValidate="TextBox1" runat="server"
             ErrorMessage="اجباری"></asp:RequiredFieldValidator>
            <br />
            
             <span class="SpanNormal">متن :</span>
        </div>
       
        <br />
        <br />
        <div style="margin-right: 30px;">
            <FCKeditorV2:FCKeditor ID="FCKeditor1" Width="530" Height="400" runat="server" BasePath="~/fckeditor/">
            </FCKeditorV2:FCKeditor>
        </div>
        <br />
        <div style="margin-right: 100px;">
            <br />
        </div>
        <br />
        <div style="margin-right: 220px;">
            <asp:Button ID="Button1" runat="server" Text="ثبت" ValidationGroup="Register" CssClass="ButtonNormal"
                OnClick="Button1_Click" />
            &nbsp;<asp:Button ID="Button2" runat="server" CssClass="ButtonNormal" OnClick="Button2_Click"
                Text="انصراف" />
            <br />
            <br />
             <asp:Label ID="Label1" CssClass="LabelButton" Visible=false runat="server" Text="پیغام شما به ثبت رسید."></asp:Label>
            <br />
        </div>
    </div>
</div>
</ContentTemplate>
</asp:UpdatePanel>