<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LessonInsertEdit.ascx.cs"
    Inherits="UserControlPublic_AdminInformationAdd" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class="PanelContainerBig">
            <div class="PanelContainerTopBig">
            </div>
            <div class="PanelContainerBodyBig">
                <span class="PanelContainerBodySpanBig" style="margin-bottom: 20px;">ویرایش و ثبت درس
                    </span>
                <div style="margin-right: 30px; margin-left: 30px;">
                    <span class="SpanHelp">در این قسمت میتوانید دروس را ایجاد و یا ویرایش نمایید :
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
                    <span class="SpanNormal">نام درس :</span><asp:TextBox CssClass="TextBoxNormal"
                        ID="TextName" runat="server"></asp:TextBox>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Register"
                        ControlToValidate="TextName" runat="server" ErrorMessage="اجباری"></asp:RequiredFieldValidator>
                    <asp:Label ID="LblHidden" runat="server"></asp:Label>
                    <br />
                    <span class="SpanNormal">تعداد واحد :</span><asp:TextBox ID="TextUnit" CssClass="TextBoxNormal"
                        runat="server"></asp:TextBox>
                    <br />
                    <span class="SpanNormal">زمان برگزاری :</span>
                    <asp:TextBox ID="TextTime" TextMode="MultiLine" CssClass="TextBoxNormal" runat="server"></asp:TextBox>
                    <br />
                   <span class="SpanNormal">معلم مربوطه :</span><asp:DropDownList ID="DropDownList7" runat="server"
                     CssClass="DropDownListNormal">
                    </asp:DropDownList>
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Register"
                        ControlToValidate="DropDownList7" runat="server" ErrorMessage="اجباری"></asp:RequiredFieldValidator>
                    <br />
                </div>
                 <br /> <br />
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
               
            </div>
        </div>
       
    </ContentTemplate>
</asp:UpdatePanel>
