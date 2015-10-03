<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ParentRegister.ascx.cs"
    Inherits="UserControlPublic_AdminInformationAdd" %>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div class="PanelContainerBig">
    <div class="PanelContainerTopBig">

    </div>
    <div class="PanelContainerBodyBig">
<span class="PanelContainerBodySpanBig" style="margin-bottom: 20px;">فرم ثبت نام والدین</span>
         <div style="margin-right: 30px; margin-left: 30px;">
            <span class="SpanHelp">در این قسمت میتوانید با داشتن کد دانش آموزی و کد ملی فرزندتان در سایت ثبت نام کنید و از امکانات سایت استفاده نمایید :
            </span>
            <br />
            <br />
             
           
        </div>
        <div style="margin-right: 100px;">
            <br />
            <span class="SpanNormal">نام و نام خانوادگی :</span><asp:TextBox  CssClass="TextBoxNormal" ID="TextName" runat="server"></asp:TextBox>
            <br />
            <span class="SpanNormal">شماره همراه :</span><asp:TextBox CssClass="TextBoxNormal"  ID="TextMobile" runat="server"></asp:TextBox>
            <br />
            <span class="SpanNormal">شغل  :</span><asp:TextBox  CssClass="TextBoxNormal" ID="TextJob" runat="server"></asp:TextBox>
            <br />
            <span class="SpanNormal">آدرس :</span>
            <asp:TextBox ID="TextAddress" CssClass="TextBoxNormal"  runat="server"></asp:TextBox>
            <br />
            <span class="SpanNormal">شماره تماس :</span>
            <asp:TextBox ID="TextTell"  CssClass="TextBoxNormal" runat="server"></asp:TextBox>
            <br />
            <span class="SpanNormal">نام کاربری :</span>
            <asp:TextBox ID="TextUserName" CssClass="TextBoxNormal"  runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Register" ControlToValidate="TextUserName" runat="server"
             ErrorMessage="اجباری"></asp:RequiredFieldValidator>
            <br />
            <span class="SpanNormal">رمز عبور :</span>
            <asp:TextBox ID="TextPassword" CssClass="TextBoxNormal" TextMode="Password" runat="server"></asp:TextBox>
            <br />
            <span class="SpanNormal">تکرار رمز عبور :</span>
            <asp:TextBox ID="TextBox1" CssClass="TextBoxNormal" TextMode="Password" runat="server"></asp:TextBox>
            <br />
            <span class="SpanNormal">تصویر :</span>
            <asp:FileUpload ID="FileUpload1"  runat="server" />
            <br />
            <br />
            <asp:Image ID="Image1" runat="server" Visible="False" BorderColor="Maroon" 
                BorderStyle="Solid" BorderWidth="1px" Height="90px" Width="90px" />
            <br />
            <br />
            <span class="SpanNormal">نام کاربری فرزند :</span>
            <asp:TextBox ID="TextCode" CssClass="TextBoxNormal"  runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Register" ControlToValidate="TextCode" runat="server"
             ErrorMessage="اجباری"></asp:RequiredFieldValidator>
            <br />
            <span class="SpanNormal">کد دانش آموزی :</span>
            <asp:TextBox ID="TextStudentCode" CssClass="TextBoxNormal"  runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="Register" ControlToValidate="TextStudentCode" runat="server"
             ErrorMessage="اجباری"></asp:RequiredFieldValidator>
            <br />
            <br />
            
            <br />
        </div>
        <div style="margin-right: 220px;">
            <asp:Button ID="Button1" runat="server" Text="ثبت" ValidationGroup="Register" CssClass="ButtonNormal" OnClick="Button1_Click" />
            &nbsp;&nbsp;<asp:Button ID="Button2" runat="server" CssClass="ButtonNormal" OnClick="Button2_Click"
                Text="انصراف" />
            <br />
        </div>
        <br /><br />
         <div style="margin-right: 170px;">
            <asp:Label ID="lblError" runat="server" Font-Bold="True" Visible="False" Font-Names="Tahoma" 
                Font-Size="9pt" ForeColor="#FF3300" 
                Text=""></asp:Label>
                </div>
    </div>
</div>
</ContentTemplate>
</asp:UpdatePanel>