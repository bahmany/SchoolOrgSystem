<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminInformationManage.ascx.cs"
    Inherits="UserControlPublic_AdminInformationAdd" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class="PanelContainerBig">
            <div class="PanelContainerTopBig">
            </div>
            <div class="PanelContainerBodyBig">
                <span class="PanelContainerBodySpanBig" style="margin-bottom: 20px;">مدیریت مدیران</span>
                <div style="margin-right: 30px; margin-left: 30px;">
                    <span class="SpanHelp">در این قسمت میتوانید مدیران سایت را ایجاد و مدیریت نمایید :</span>
                    <br />
                    <br />
                </div>
                <div style="margin-right: 100px;">
                    <span class="SpanNormal">نام و نام خانوادگی :</span><asp:TextBox ID="TextName" CssClass="TextBoxNormal"
                        runat="server"></asp:TextBox>
                    <br />
                    <span class="SpanNormal">نام پدر :</span><asp:TextBox ID="TextFatherName" CssClass="TextBoxNormal"
                        runat="server"></asp:TextBox>
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
                    <br />
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="تکرار رمز عبور اشتباه است"
                        ControlToCompare="TextPassword" ControlToValidate="TextBox1" ValidationGroup="Register"></asp:CompareValidator>
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
                    <span class="SpanNormal">سمت :</span>
                    <asp:TextBox ID="TextRoll" CssClass="TextBoxNormal" runat="server"></asp:TextBox>
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
                    <asp:Button ID="Button1" runat="server" Text="ثبت" ValidationGroup="Register" CssClass="ButtonNormal"
                        OnClick="Button1_Click" />
                    &nbsp;<asp:Button ID="Button3" runat="server" CssClass="ButtonNormal" OnClick="Button1_Click"
                        Text="ویرایش" ValidationGroup="Register" Visible="false" />
                    &nbsp;<asp:Button ID="Button2" runat="server" CssClass="ButtonNormal" OnClick="Button2_Click"
                        Text="انصراف" />
                </div>
                <br />
                <div style="margin-right: 210px;">
                    <asp:Label ID="Label1" CssClass="LabelButton" Visible="false" runat="server" Text=""></asp:Label>
                </div>
                <br />
                <div style="margin-right: 20px;">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        CssClass="Grid" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging"
                        OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" PageSize="10">
                        <RowStyle CssClass="GridRow" />
                        <EmptyDataRowStyle CssClass="GridEmpty" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1%>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="نام و نام خانوادگی">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("Admin_ID") %>' Visible="False"></asp:Label>
                                    &nbsp;
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("AI_Name").ToString() %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="نام کاربری">
                                <ItemTemplate>
                                    <asp:Label ID="Labeluser" runat="server" Text='<%# Eval("AI_UserName").ToString() %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <a href='<%# "./Index.aspx?Type=AdminPermission&ID_Admin="+ Eval("Admin_ID").ToString()%>'>
                                        <asp:Image ID="Image2" ImageUrl="~/Images/key.png" runat="server" /></a>
                                </ItemTemplate>
                                <ItemStyle Width="20px" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Delete" ImageUrl="~/Images/delete.gif"
                                        OnClientClick="return confirm('آیا از این کار اطمینان دارید؟');" ToolTip="حذف" />
                                </ItemTemplate>
                                <ItemStyle CssClass="GridItemButton" Width="20px" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton2" runat="server" CommandName="Edit" ImageUrl="~/Images/edit.gif"
                                        ToolTip="ویرایش" />
                                </ItemTemplate>
                                <ItemStyle CssClass="GridItemButton" Width="20px" />
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle CssClass="GridPaging" />
                        <EmptyDataTemplate>
                            <asp:Label ID="Label1" runat="server" Text="اطلاعات کاربری ای به ثبت نرسیده است"></asp:Label>
                        </EmptyDataTemplate>
                        <HeaderStyle CssClass="GridHeader" />
                        <AlternatingRowStyle CssClass="GridRowAlternating" />
                        <SelectedRowStyle BackColor="Gray" />
                    </asp:GridView>
                </div>
            </div>
        </div>
        <asp:Label ID="LblHidden" runat="server"></asp:Label>
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="HiddenField2" runat="server" />
    </ContentTemplate>
</asp:UpdatePanel>
