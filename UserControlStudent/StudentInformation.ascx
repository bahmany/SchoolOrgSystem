<%@ Control Language="C#" AutoEventWireup="true" CodeFile="StudentInformation.ascx.cs"
    Inherits="UserControlPublic_AdminInformationAdd" %>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div class="PanelContainerBig">
    <div class="PanelContainerTopBig">
    </div>
    <div class="PanelContainerBodyBig">
        <span class="PanelContainerBodySpanBig" style="margin-bottom: 20px;">ویرایش اطلاعات
            شخصی</span>
        <div style="margin-right: 30px; margin-left: 30px;">
            <span class="SpanHelp">در این قسمت میتوانید مشخصات فردی خود را تغییر دهید : </span>
            <br />
            <br />
            <br />
            <br />
        </div>
        <div style="margin-right: 100px;">
            <span class="SpanNormal">نام و نام خانوادگی :</span><asp:TextBox CssClass="TextBoxNormal" ID="TextName" runat="server"></asp:TextBox>
            <br />
            <span class="SpanNormal">نام پدر :</span><asp:TextBox  CssClass="TextBoxNormal" ID="TextFatherName" runat="server"></asp:TextBox>
            <br />
            <span class="SpanNormal">شماره همراه پدر :</span><asp:TextBox  CssClass="TextBoxNormal" ID="TextFatherMobile"
                runat="server"></asp:TextBox>
            <br />
            <span class="SpanNormal">شغل پدر :</span><asp:TextBox  CssClass="TextBoxNormal" ID="TextFatherJob" runat="server"></asp:TextBox>
            <br />
            <span class="SpanNormal">نام مادر :</span><asp:TextBox CssClass="TextBoxNormal"  ID="TextMotherName" runat="server"></asp:TextBox>
            <br />
            <span class="SpanNormal">شغل مادر :</span><asp:TextBox  CssClass="TextBoxNormal" ID="TextMotherJob" runat="server"></asp:TextBox>
            <br />
            <span class="SpanNormal">شماره همراه مادر :</span><asp:TextBox  CssClass="TextBoxNormal" ID="TextMotherMobile"
                runat="server"></asp:TextBox>
            <br />
            <span class="SpanNormal">آدرس :</span>
            <asp:TextBox ID="TextAddress" CssClass="TextBoxNormal"  TextMode=MultiLine runat="server"></asp:TextBox>
            <br />
            <span class="SpanNormal">شماره تماس :</span>
            <asp:TextBox ID="TextTell"  CssClass="TextBoxNormal" runat="server"></asp:TextBox>
            <br />
            <span class="SpanNormal">کد پستی :</span>
            <asp:TextBox ID="TextPostalCode" CssClass="TextBoxNormal"  runat="server"></asp:TextBox>
            <br />
            <span class="SpanNormal">محل صدور :</span>
            <asp:TextBox ID="TextExportPlace"  CssClass="TextBoxNormal" runat="server"></asp:TextBox>
            <br />
            <span class="SpanNormal">تاریخ تولد :</span>
            <asp:TextBox ID="TextBirthDate" CssClass="TextBoxNormal"  runat="server"></asp:TextBox>
            <br />
            <span class="SpanNormal">کد پرسنلی :</span>
            <asp:TextBox ID="TextAdminCode"  CssClass="TextBoxNormal" runat="server"></asp:TextBox>
            <br />
            <span class="SpanNormal">نام کاربری :</span>
            <asp:TextBox ID="TextUserName"  CssClass="TextBoxNormal" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Register" ControlToValidate="TextUserName" runat="server"
             ErrorMessage="اجباری"></asp:RequiredFieldValidator>
            <br />
            <span class="SpanNormal">رمز عبور :</span>
            <asp:TextBox ID="TextPassword" CssClass="TextBoxNormal" TextMode="Password" runat="server"></asp:TextBox>
            <br />
            <span class="SpanNormal">تکرار رمز عبور :</span>
            <asp:TextBox ID="TextBox1" CssClass="TextBoxNormal" TextMode="Password" runat="server"></asp:TextBox>
            <br />
            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="تکرار رمز عبور اشتباه است"
                ControlToCompare="TextPassword" ControlToValidate="TextBox1" ValidationGroup="Register"></asp:CompareValidator>
            <br />
            <span class="SpanNormal">تصویر:</span>
            <asp:FileUpload ID="FileUpload1" runat="server" />
            <br />
            <br />
           
        </div>
        <asp:Image Style="margin-right: 220px;" ID="Image1" runat="server" BorderColor="Black"
            BorderStyle="Solid" BorderWidth="1px" Height="100px" Width="100px" Visible="False" />
        <br />
        <br />
        <br />
        <div style="margin-right: 220px;">
            <asp:Button ID="Button1" ValidationGroup="Register" runat="server" Text="ثبت" CssClass="ButtonNormal" OnClick="Button1_Click" />
            &nbsp;<asp:Button ID="Button3" runat="server" CssClass="ButtonNormal" OnClick="Button1_Click"
                Text="ویرایش" ValidationGroup="Register" Visible="false" />
            &nbsp;<asp:Button ID="Button2" runat="server" CssClass="ButtonNormal" OnClick="Button2_Click"
                Text="انصراف" />
            <br />
            <br />
            <br />
        </div>
        <br />
        <div style="margin-right: 210px;">
            <asp:Label ID="Label1" CssClass="LabelButton" Visible=false runat="server" Text="عملیات با موفقیت انجام شد"></asp:Label>
                </div>
    </div>
</div>
<asp:HiddenField ID="HiddenField1" runat="server" />
<asp:HiddenField ID="HiddenField2" runat="server" />
</ContentTemplate>
</asp:UpdatePanel>