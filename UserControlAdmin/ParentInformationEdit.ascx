<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ParentInformationEdit.ascx.cs"
    Inherits="UserControlPublic_AdminInformationAdd" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class="PanelContainerBig">
            <div class="PanelContainerTopBig">
            </div>
            <div class="PanelContainerBodyBig">
                <span class="PanelContainerBodySpanBig" style="margin-bottom: 20px;">مدیریت اولیاء دانش
                    آموزان</span>
                <div style="margin-right: 20px; margin-left: 20px;">
                    <span class="SpanHelp">در این قسمت میتوانید اطلاعات اولیاء انتخاب شده را ویرایش نمایید
                        : </span>
                    <br />
                    <br />
                    <asp:Panel ID="Panel1" Font-Size="8pt" runat="server" GroupingText="<B>مسیر جاری</B>"
                        Width="540px">
                        <div class="PanelStyle">
                            <asp:Label ID="lblPath" runat="server"></asp:Label>
                        </div>
                    </asp:Panel>
                    <br />
                </div>
                <div style="margin-right: 100px;">
                    <span class="SpanNormal">نام فرزند :</span> <span class="SpanNormalShow">
                        <%= ChildName %></span>
                    <br />
                    <br />
                    <span class="SpanNormal">نام و نام خانوادگی :</span><asp:TextBox CssClass="TextBoxNormal"
                        ID="TextName" runat="server"></asp:TextBox>
                    <br />
                    <span class="SpanNormal">نام کاربری :</span>
                    <asp:TextBox ID="TextUserName" CssClass="TextBoxNormal" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Register"
                        ControlToValidate="TextUserName" runat="server" ErrorMessage="اجباری"></asp:RequiredFieldValidator>
                    <br />
                    <span class="SpanNormal">رمز عبور :</span>
                    <asp:TextBox ID="TextPassword" CssClass="TextBoxNormal" TextMode="Password" runat="server"></asp:TextBox>
                    <br />
                    <span class="SpanNormal">تکرار رمز عبور :</span>
                    <asp:TextBox ID="TextBox1" CssClass="TextBoxNormal" TextMode="Password" runat="server"></asp:TextBox>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="تکرار رمز عبور اشتباه است"
                        ControlToCompare="TextPassword" ControlToValidate="TextBox1" ValidationGroup="Register"></asp:CompareValidator>
                    <br />
                    <span class="SpanNormal">شماره همراه :</span><asp:TextBox CssClass="TextBoxNormal"
                        ID="TextMobile" runat="server"></asp:TextBox>
                    <br />
                    <span class="SpanNormal">شغل :</span><asp:TextBox CssClass="TextBoxNormal" ID="TextJob"
                        runat="server"></asp:TextBox>
                    <br />
                    <span class="SpanNormal">شماره تماس :</span>
                    <asp:TextBox ID="TextTell" CssClass="TextBoxNormal" runat="server"></asp:TextBox>
                    <br />
                    <span class="SpanNormal">آدرس :</span>
                    <asp:TextBox CssClass="TextBoxNormal" ID="TextAddress" TextMode="MultiLine" runat="server"></asp:TextBox>
                    <br />
                    <br />
                    <span class="SpanNormal">تصویر :</span>
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
                    &nbsp;<asp:Button ID="Button3" runat="server" CssClass="ButtonNormal" OnClick="Button1_Click"
                        Text="ویرایش" ValidationGroup="Register" />
                    &nbsp;<asp:Button ID="Button2" runat="server" CssClass="ButtonNormal" OnClick="Button2_Click"
                        Text="انصراف" />
                    <br />
                    <br />
                   
                </div>
                <div style="margin-right: 210px;">
                    <asp:Label ID="Label1" CssClass="LabelButton" Visible="false" runat="server" Text=""></asp:Label>
                </div>
            </div>
        </div>
        <asp:HiddenField ID="HiddenField2" runat="server" />
        <asp:HiddenField ID="HiddenField1" runat="server" />
    </ContentTemplate>
</asp:UpdatePanel>
