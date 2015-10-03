<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TestInsert.ascx.cs" Inherits="UserControlPublic_AdminInformationAdd" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class="PanelContainerBig">
            <div class="PanelContainerTopBig">
            </div>
            <div class="PanelContainerBodyBig">
                <span class="PanelContainerBodySpanBig" style="margin-bottom: 20px;">ثبت آزمون آنلاین</span>
                <div style="margin-right: 30px; margin-left: 30px;">
                    <span class="SpanHelp">در این قسمت میتوانید آزمون آنلاینی را طراحی نمایید : </span>
                    <br />
                    <br />
                </div>
                <div style="margin-right: 100px;">
                    <span class="SpanNormal">نام درس :</span>
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                        CssClass="DropDownListNormal">
                    </asp:DropDownList>
                </div>
                <br />
                <div style="margin-right: 30px;">
                    <asp:Panel ID="Panel2" Font-Size="8pt" runat="server" GroupingText="<B>مسیر درس</B>"
                        Width="540px">
                        <div class="PanelStyle">
                            <asp:Label ID="lblPath" runat="server"></asp:Label>
                        </div>
                    </asp:Panel>
                </div>
                <br />
                <div style="margin-right: 100px;">
                    <span class="SpanNormal">عنوان آزمون :</span>
                    <asp:TextBox CssClass="TextBoxNormal" ID="TextName" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Register"
                        ControlToValidate="TextName" runat="server" ErrorMessage="اجباری"></asp:RequiredFieldValidator>
                    <br />
                    <span class="SpanNormal">نوع آزمون :</span>
                    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"
                        CssClass="DropDownListNormal">
                        <asp:ListItem Value="Both">تستی و تشریحی</asp:ListItem>
                        <asp:ListItem Value="Testi">تستی</asp:ListItem>
                        <asp:ListItem Value="Tashrihi">تشریحی</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <br />
                </div>
                <div style="margin-right: 70px;">
                    <span class="SpanNormal">تعداد سوال تشریحی :</span>
                    <asp:TextBox CssClass="TextBoxNormal" MaxLength="3" Style="text-align: center; width: 80px"
                        ID="TextBox1" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Register"
                        ControlToValidate="TextBox1" runat="server" ErrorMessage="اجباری"></asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span>نمره کل :</span>
                    <asp:TextBox CssClass="TextBoxNormal" MaxLength="3" Style="text-align: center; width: 50px"
                        ID="TextBox2" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="Register"
                        ControlToValidate="TextBox2" runat="server" ErrorMessage="اجباری"></asp:RequiredFieldValidator>
                    <br />
                    <span class="SpanNormal">تعداد سوال تستی :</span>
                    <asp:TextBox CssClass="TextBoxNormal" MaxLength="3" Style="text-align: center; width: 80px"
                        ID="TextBox3" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ValidationGroup="Register"
                        ControlToValidate="TextBox3" runat="server" ErrorMessage="اجباری"></asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span>نمره کل :</span>
                    <asp:TextBox CssClass="TextBoxNormal" MaxLength="3" Style="text-align: center; width: 50px"
                        ID="TextBox4" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ValidationGroup="Register"
                        ControlToValidate="TextBox4" runat="server" ErrorMessage="اجباری"></asp:RequiredFieldValidator>
                    <br />
                    <br />
                    <span style="margin-right: 75px; color: Green; direction: ltr;" class="SpanNormal">1300/00/00</span>
                    <span style="margin-right: 50px; color: Green;" class="SpanNormal">00:00</span>
                    <br />
                    <br />
                    <span class="SpanNormal">تاریخ شروع :</span>
                    <asp:TextBox CssClass="TextBoxNormal" MaxLength="10" Style="text-align: center; direction: ltr;
                        width: 80px" ID="TextBox5" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ValidationGroup="Register"
                        ControlToValidate="TextBox5" runat="server" ErrorMessage="اجباری"></asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span>ساعت :</span>
                    <asp:TextBox CssClass="TextBoxNormal" MaxLength="5" Style="text-align: center; direction: ltr;
                        width: 50px" ID="TextBox6" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ValidationGroup="Register"
                        ControlToValidate="TextBox6" runat="server" ErrorMessage="اجباری"></asp:RequiredFieldValidator>
                    <br />
                    <span class="SpanNormal">تاریخ اتمام :</span>
                    <asp:TextBox CssClass="TextBoxNormal" MaxLength="10" Style="text-align: center; direction: ltr;
                        width: 80px" ID="TextBox7" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ValidationGroup="Register"
                        ControlToValidate="TextBox7" runat="server" ErrorMessage="اجباری"></asp:RequiredFieldValidator>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <span>ساعت :</span>
                    <asp:TextBox CssClass="TextBoxNormal" MaxLength="5" Style="text-align: center; direction: ltr;
                        width: 50px" ID="TextBox8" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ValidationGroup="Register"
                        ControlToValidate="TextBox8" runat="server" ErrorMessage="اجباری"></asp:RequiredFieldValidator>
                    <br />
                </div>
                <br />
                <br />
                <div style="margin-right: 240px;">
                    <asp:Button ID="Button1" runat="server" Text="ثبت" ValidationGroup="Register" CssClass="ButtonNormal"
                        OnClick="Button1_Click" />
                    &nbsp;<asp:Button ID="Button2" runat="server" CssClass="ButtonNormal" OnClick="Button2_Click"
                        Text="انصراف" />
                    <br />
                </div>
                <br />
                <div style="margin-right: 150px;">
                    <asp:Label ID="Label1" CssClass="LabelButton" runat="server" Text="در ورود اطلاعات دقت نمایید ، امکان ویرایش وجود ندارد ..."></asp:Label>
                    <br />
                </div>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
