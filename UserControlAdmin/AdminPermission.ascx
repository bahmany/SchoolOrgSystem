<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminPermission.ascx.cs"
    Inherits="UserControlPublic_AdminInformationAdd" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class="PanelContainerBig">
            <div class="PanelContainerTopBig">
            </div>
            <div class="PanelContainerBodyBig">
                <span class="PanelContainerBodySpanBig" style="margin-bottom: 20px;">مدیریت دسترسی مدیر
                </span>
                <div style="margin-right: 30px; margin-left: 30px;">
                    <span class="SpanHelp">در این قسمت میتوانید دسترسی مدیر مورد نظر خود را تغییر دهید :
                    </span>
                    <br />
                    <br />
                    <asp:Panel ID="Panel1" Font-Size="8pt" runat="server" GroupingText="<B>مسیر جاری</B>"
                        Width="540px">
                        <div class="PanelStyle">
                            <asp:Label ID="lblPath" runat="server"></asp:Label>
                        </div>
                    </asp:Panel>
                </div>
                <br />
                <asp:Panel ID="Panel3" Style="margin-right: 20px;" Font-Size="8pt" runat="server"
                    Width="540px" GroupingText="<B>دسترسی بخش ها</B>">
                    <div class="PanelStyle">
                        <asp:Label ID="Label1" runat="server" Visible="false" Text="برای این مدیر دسترسی ای تعریف نشده است"></asp:Label>
                        &nbsp;&nbsp;
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">ایجاد دسترسی جدید</asp:LinkButton>
                    </div>
                    <br />
                    <asp:Panel ID="PanelDrop" Style="margin-right: 60px;" Font-Size="8pt" runat="server">
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
                        <br />
                        <div style="margin-right: 130px;">
                            <asp:Button ID="Button1" runat="server" Text="ثبت" ValidationGroup="Register" CssClass="ButtonNormal"
                                OnClick="Button1_Click" />
                            &nbsp;<asp:Button ID="Button2" runat="server" CssClass="ButtonNormal" OnClick="Button2_Click"
                                Text="انصراف" />
                            <br />
                            <br />
                            <div style="margin-right: 0px;">
                                <asp:Label ID="Label2" CssClass="LabelButton" Visible="false" runat="server" Text="اطلاعات به ثبت رسید"></asp:Label>
                            </div>
                        </div>
                        <br />
                    </asp:Panel>
                </asp:Panel>
                <br />
                <asp:Panel ID="Panel2" Style="margin-right: 20px;" Font-Size="8pt" runat="server"
                    Width="540px" GroupingText="<B>دسترسی به قسمت ها</B>">
                    <div class="PanelStyle">
                        <br />
                        <asp:CheckBoxList Style="margin-right: 20px" RepeatColumns="4" CellSpacing="5" ID="CheckBoxList1"
                            runat="server">
                            <asp:ListItem Enabled=false Text="مدیریت مدیران" Value="ManageAdmin"></asp:ListItem>
                            <asp:ListItem Enabled=false Text="مدیریت معلمان" Value="ManageTeacher"></asp:ListItem>
                            <asp:ListItem Enabled=false Text="مدیریت اولیاء" Value="ManageParent"></asp:ListItem>
                            <asp:ListItem Enabled=false  Text="مدیریت دانش آموزان" Value="ManageStudent"></asp:ListItem>
                            <asp:ListItem Enabled=false  Text="مدیریت اخبار و رویداد" Value="ManageNews"></asp:ListItem>
                            <asp:ListItem Enabled=false  Text="مدیریت کتابخانه" Value="ManageLibrary"></asp:ListItem>
                            <asp:ListItem Enabled=false  Text="مدیریت گالری تصاویر" Value="ManageGallery"></asp:ListItem>
                            <asp:ListItem Enabled=false  Text="مدیریت لینک های مفید" Value="ManageLink"></asp:ListItem>
                            <asp:ListItem  Enabled=false Text="مدیریت نظر سنجی" Value="ManagePoll"></asp:ListItem>
                            <asp:ListItem Enabled=false  Text="مدیریت زنگ تفریح" Value="ManageBreak"></asp:ListItem>
                            <asp:ListItem Enabled=false  Text="مدیریت دروس" Value="ManageLesson"></asp:ListItem>
                            <asp:ListItem Enabled=false  Text="مدیریت تماس با ما" Value="ManageCallUS"></asp:ListItem>
                            <asp:ListItem Enabled=false  Text="مدیریت پیام های زیرنویس" Value="ManageTerm"></asp:ListItem>
                            <asp:ListItem Enabled=false  Text="مدیریت ترم ها" Value="ManageTerm"></asp:ListItem>
                            <asp:ListItem Enabled=false  Text="مدیریت تنظیمات" Value="ManageOneRecord"></asp:ListItem>
                            <asp:ListItem Enabled=false  Text="مدیریت بخش ها" Value="ManageCategory"></asp:ListItem>

                        </asp:CheckBoxList>
                        <br />
                        <asp:Panel ID="Panel4" Style="margin-right: 60px;" Font-Size="8pt" runat="server">
                            <br />
                            <div style="margin-right: 130px;">
                                <asp:Button ID="Button3" runat="server" Text="ثبت" ValidationGroup="Register2" CssClass="ButtonNormal"
                                    OnClick="Button3_Click" />
                                &nbsp;<asp:Button ID="Button4" runat="server" CssClass="ButtonNormal" OnClick="Button4_Click"
                                    Text="انصراف" />
                                <br />
                                <br />
                                <div style="margin-right: 0px;">
                                    <asp:Label ID="Label3" CssClass="LabelButton" Visible="false" runat="server" Text="اطلاعات به ثبت رسید"></asp:Label>
                                </div>
                            </div>
                        </asp:Panel>
                        <br />
                    </div>
                </asp:Panel>
                <br />
            </div>
        </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
