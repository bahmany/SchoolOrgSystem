<%@ Control Language="C#" AutoEventWireup="true" CodeFile="StudentInformationInsertEdit.ascx.cs"
    Inherits="UserControlPublic_AdminInformationAdd" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class="PanelContainerBig">
            <div class="PanelContainerTopBig">
            </div>
            <div class="PanelContainerBodyBig">
                <span class="PanelContainerBodySpanBig" style="margin-bottom: 20px;">ویرایش و ثبت دانش
                    آموز</span>
                <div style="margin-right: 30px; margin-left: 30px;">
                    <span class="SpanHelp">در این قسمت میتوانید دانش آموزی را ایجاد و یا ویرایش نمایید :
                    </span>
                    <br />
                    <br />
                    <asp:Panel ID="Panel1" Visible="false" Font-Size="8pt" runat="server" GroupingText="<B>مسیر جاری</B>"
                        Width="540px">
                        <div class="PanelStyle">
                            <asp:Label ID="lblPath" runat="server"></asp:Label>
                        </div>
                    </asp:Panel>
                    <br />
                    <br />
                </div>
                <div style="margin-right: 100px;">
                    <span class="SpanNormal">بخش اول :</span>
                    <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                        OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Visible="False" CssClass="DropDownListNormal">
                    </asp:DropDownList>
                    <br />
                    <span class="SpanNormal">بخش دوم :</span><asp:DropDownList ID="DropDownList2" runat="server"
                        AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"
                        Visible="False" CssClass="DropDownListNormal">
                    </asp:DropDownList>
                    <br />
                    <span class="SpanNormal">بخش سوم :</span><asp:DropDownList ID="DropDownList3" runat="server"
                        AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged"
                        Visible="False" CssClass="DropDownListNormal">
                    </asp:DropDownList>
                    <br />
                    <span class="SpanNormal">بخش چهارم :</span>
                    <asp:DropDownList ID="DropDownList4" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                        OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged" Visible="False" CssClass="DropDownListNormal">
                    </asp:DropDownList>
                    <br />
                    <span class="SpanNormal">بخش پنجم :</span><asp:DropDownList ID="DropDownList5" runat="server"
                        AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged"
                        Visible="False" CssClass="DropDownListNormal">
                    </asp:DropDownList>
                    <br />
                    <span class="SpanNormal">بخش ششم :</span>
                    <asp:DropDownList ID="DropDownList6" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                        OnSelectedIndexChanged="DropDownList6_SelectedIndexChanged" Visible="False" CssClass="DropDownListNormal">
                    </asp:DropDownList>
                    <br />
                    <span class="SpanNormal">نام و نام خانوادگی :</span><asp:TextBox CssClass="TextBoxNormal"
                        ID="TextName" runat="server"></asp:TextBox>
                    <asp:Label ID="LblHidden" runat="server"></asp:Label>
                    <br />
                    <span class="SpanNormal">نام پدر :</span><asp:TextBox ID="TextFatherName" CssClass="TextBoxNormal"
                        runat="server"></asp:TextBox>
                    <br />
                    <span class="SpanNormal">شماره همراه پدر :</span><asp:TextBox CssClass="TextBoxNormal"
                        ID="TextFatherMobile" runat="server"></asp:TextBox>
                    <br />
                    <span class="SpanNormal">شغل پدر :</span><asp:TextBox CssClass="TextBoxNormal" ID="TextFatherJob"
                        runat="server"></asp:TextBox>
                    <br />
                    <span class="SpanNormal">نام مادر :</span><asp:TextBox CssClass="TextBoxNormal" ID="TextMotherName"
                        runat="server"></asp:TextBox>
                    <br />
                    <span class="SpanNormal">شغل مادر :</span><asp:TextBox CssClass="TextBoxNormal" ID="TextMotherJob"
                        runat="server"></asp:TextBox>
                    <br />
                    <span class="SpanNormal">شماره همراه مادر :</span><asp:TextBox CssClass="TextBoxNormal"
                        ID="TextMotherMobile" runat="server"></asp:TextBox>
                    <br />
                    <span class="SpanNormal">آدرس :</span>
                    <asp:TextBox ID="TextAddress" TextMode="MultiLine" CssClass="TextBoxNormal" runat="server"></asp:TextBox>
                    <br />
                    <span class="SpanNormal">شماره تماس :</span>
                    <asp:TextBox ID="TextTell" CssClass="TextBoxNormal" runat="server"></asp:TextBox>
                    <br />
                    <span class="SpanNormal">کد پستی :</span>
                    <asp:TextBox ID="TextPostalCode" CssClass="TextBoxNormal" runat="server"></asp:TextBox>
                    <br />
                    <span class="SpanNormal">محل صدور :</span>
                    <asp:TextBox ID="TextExportPlace" CssClass="TextBoxNormal" runat="server"></asp:TextBox>
                    <br />
                    <span class="SpanNormal">تاریخ تولد :</span>
                    <asp:TextBox ID="TextBirthDate" CssClass="TextBoxNormal" runat="server"></asp:TextBox>
                    <br />
                    <span class="SpanNormal">کد پرسنلی :</span>
                    <asp:TextBox ID="TextAdminCode" CssClass="TextBoxNormal" runat="server"></asp:TextBox>
                    <br />
                    <span class="SpanNormal">نام کاربری :</span>
                    <asp:TextBox ID="TextUserName" CssClass="TextBoxNormal" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Register"
                        ControlToValidate="TextUserName" runat="server" ErrorMessage="اجباری"></asp:RequiredFieldValidator>
                    <br />
                    <span class="SpanNormal">رمز عبور :</span>
                    <asp:TextBox ID="TextPassword" CssClass="TextBoxNormal" TextMode="Password" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Register"
                        ControlToValidate="TextPassword" runat="server" ErrorMessage="اجباری"></asp:RequiredFieldValidator>
                    <br />
                    <span class="SpanNormal">تکرار رمز عبور :</span>
                    <asp:TextBox ID="TextBox1" CssClass="TextBoxNormal" TextMode="Password" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="Register"
                        ControlToValidate="TextBox1" runat="server" ErrorMessage="اجباری"></asp:RequiredFieldValidator>
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
                <div style="margin-right: 220px;">
                    <asp:Button ID="Button1" runat="server" Text="ثبت" ValidationGroup="Register" CssClass="ButtonNormal"
                        OnClick="Button1_Click" />
                    &nbsp;<asp:Button ID="Button3" runat="server" CssClass="ButtonNormal" OnClick="Button1_Click"
                        Text="ویرایش" ValidationGroup="Register" Visible="false" />
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
