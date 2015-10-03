<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Login.ascx.cs" Inherits="UserControlPublic_Login" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div class="PanelContainer">
    <div class="PanelContainerTop">
    </div>
    <div class="PanelContainerBody">
        <span class="PanelContainerBodySpan">ورود کاربران </span>
        <asp:Panel ID="Panel1" runat="server">
            <div style="margin-top: 50px; margin-right: 40px;">
                <span style="width: 60px; clear: none; float: right; padding-top: 5px;">نام کاربری :</span>&nbsp;<asp:TextBox
                    ID="TextBox1" runat="server" CssClass="TextBoxNormal"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="TextBox1" ValidationGroup="Login" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
                <br />
                <br />
                <span style="width: 60px; clear: none; float: right; padding-top: 5px;">رمز عبور :</span>&nbsp;<asp:TextBox
                    ID="TextBox2" runat="server" TextMode=Password CssClass="TextBoxNormal"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="TextBox2" ValidationGroup="Login" runat="server" ErrorMessage="*"></asp:RequiredFieldValidator>
               
                <br />
                <br />
                <asp:RadioButtonList ID="RadioButtonList1" CellSpacing="10" runat="server" Style="margin-right: 20px;"
                    RepeatColumns="2">
                    <asp:ListItem Selected="True" Value="Student">دانش آموزان</asp:ListItem>
                    <asp:ListItem Value="Parent">اولیاء</asp:ListItem>
                    <asp:ListItem Value="Teacher">معلمان</asp:ListItem>
                    <asp:ListItem Value="Admin">مدیران</asp:ListItem>
                </asp:RadioButtonList>
            </div>
            <br />
            <div style="margin-right: 120px;">
                <asp:Button ID="Button1" ValidationGroup="Login" CssClass="ButtonNormal" runat="server" OnClick="Button1_Click"
                    Text="ورود" />
            </div>
            <br />
             <div style="margin-right: 80px;">
                <asp:Label ID="lblEror" runat="server" Style="color: Red;" Text="اطلاعات اشتباه وارد شده اند"
                    Visible="False"></asp:Label>
            </div>
            <br />
           
            <div style="margin-right: 110px;">
                <asp:HyperLink ID="HyperLink1" runat="server" Font-Names="Tahoma" Font-Size="10pt"
                    Font-Underline="true" Font-Bold="true" NavigateUrl="~/Index.aspx?Type=ParentRegister">ثبت نام اولیاء</asp:HyperLink>
                <br />
            </div>
            <br />
        </asp:Panel>
    </div>
</div>
</ContentTemplate>
</asp:UpdatePanel>