<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TestQuestionManage.ascx.cs"
    Inherits="UserControlPublic_AdminInformationAdd" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class="PanelContainerBig">
            <div class="PanelContainerTopBig">
            </div>
            <div class="PanelContainerBodyBig">
                <span class="PanelContainerBodySpanBig" style="margin-bottom: 20px;">مدیریت سوالات آزمون
                    آنلاین</span>
                <div style="margin-right: 30px; margin-left: 30px;">
                    <span class="SpanHelp">در این قسمت میتوانید سوالات آزمون آنلاین را ایجاد و مدیریت نمایید
                        :</span>
                    
                    <br />
                </div>
                <br />
                  <div style="margin-right: 30px;">
                    <asp:Panel ID="Panel2" Font-Size="8pt" runat="server" GroupingText="<B>مسیر جاری</B>"
                        Width="540px">
                        <div class="PanelStyle">
                            <asp:Label ID="lblPath" runat="server"></asp:Label>
                        </div>
                    </asp:Panel>
                </div>
                <br />
                <div style="margin-right: 100px;">
                    <span class="SpanNormal">نوع سوال :</span>
                    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"
                        CssClass="DropDownListNormal" Style="text-align: center; width: 80px">
                        <asp:ListItem Value="Testi">تستی</asp:ListItem>
                        <asp:ListItem Value="Tashrihi">تشریحی</asp:ListItem>
                    </asp:DropDownList>
                    <br />
                    <span class="SpanNormal">متن سوال :</span><asp:TextBox ID="TextTitle" CssClass="TextBoxNormal"
                        runat="server"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Register" ControlToValidate="TextTitle" runat="server"
             ErrorMessage="اجباری"></asp:RequiredFieldValidator>
                    <br />
                    <asp:Panel ID="Panel1" runat="server">
                        <span class="SpanNormal">گزینه الف :</span><asp:TextBox ID="TextA" CssClass="TextBoxNormal"
                            runat="server"></asp:TextBox>
                        <br />
                        <span class="SpanNormal">گزینه ب :</span>
                        <asp:TextBox ID="TextB" CssClass="TextBoxNormal" runat="server"></asp:TextBox>
                        <br />
                        <span class="SpanNormal">گزینه ج :</span>
                        <asp:TextBox ID="TextC" CssClass="TextBoxNormal" runat="server"></asp:TextBox>
                        <br />
                        <span class="SpanNormal">گزینه د :</span>
                        <asp:TextBox ID="TextD" CssClass="TextBoxNormal" runat="server"></asp:TextBox>
                       
                        <br />
                    </asp:Panel>
                    
                     <span class="SpanNormal"> پاسخ صحیح :</span>
                        <asp:TextBox ID="TextAnswer" CssClass="TextBoxNormal" runat="server"></asp:TextBox>
                        <br />
                    <span class="SpanNormal">بارم :</span>
                    <asp:TextBox ID="TextMark" MaxLength="3" Text="2" Style="text-align: center; width: 80px" CssClass="TextBoxNormal" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Register" ControlToValidate="TextMark" runat="server"
             ErrorMessage="اجباری"></asp:RequiredFieldValidator>
                    <br />
                    <span class="SpanNormal">نمره منفی :</span>
                    <asp:TextBox ID="TextMinusMark" MaxLength="3" Text="0" Style="text-align: center; width: 80px" CssClass="TextBoxNormal" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ValidationGroup="Register" ControlToValidate="TextMinusMark" runat="server"
             ErrorMessage="اجباری"></asp:RequiredFieldValidator>
                    <br />
                </div>
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
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="متن سوال">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("TestQuestion_ID") %>' Visible="False"></asp:Label>
                                    &nbsp;
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("tq_Title").ToString() %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="نوع سوال">
                                <ItemTemplate>
                                    
                                    <asp:Label ID="Lasdbel3" runat="server"
                                     Text='<%# Eval("tq_Type").ToString().Replace("Testi","تستی").Replace("Tashrihi","تشریحی") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="بارم">
                                <ItemTemplate>
                                   
                                    <asp:Label ID="Labaael3" runat="server" Text='<%# Eval("tq_Mark").ToString() %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                              <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="نمره منفی">
                                <ItemTemplate>
                                   
                                    <asp:Label ID="Labelss3" runat="server" Text='<%# Eval("tq_Minus_Mark").ToString() %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
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
                            <asp:Label ID="Label1" runat="server" Text="اطلاعاتی به ثبت نرسیده است"></asp:Label>
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
