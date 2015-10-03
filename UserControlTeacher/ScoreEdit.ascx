<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ScoreEdit.ascx.cs" Inherits="UserControlPublic_AdminInformationAdd" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
        <div class="PanelContainerBig">
            <div class="PanelContainerTopBig">
            </div>
            <div class="PanelContainerBodyBig">
                <span class="PanelContainerBodySpanBig" style="margin-bottom: 20px;">ویرایش آزمون و نمره دانش آموزان</span>
                <div style="margin-right: 30px; margin-left: 30px;">
                    <span class="SpanHelp">در این قسمت میتوانید آزمون انتخاب شده را ویرایش نمایید : </span>
                    <br />
                    <br />
                </div>
                
               
                <div style="margin-right: 30px;">
                    <asp:Panel ID="Panel2" Font-Size="8pt" runat="server" GroupingText="<B>مسیر درس آزمون</B>"
                        Width="540px">
                        <div class="PanelStyle">
                            <asp:Label ID="lblPath" runat="server"></asp:Label>
                        </div>
                    </asp:Panel>
                </div>
                <br />
                <br />
                <div style="margin-right: 100px;">
                    <span class="SpanNormal">عنوان آزمون :</span>
                    <asp:TextBox CssClass="TextBoxNormal" ID="TextName" runat="server"></asp:TextBox>
                    <br />
                    <span class="SpanNormal">نوع آزمون :</span>
                    <asp:DropDownList ID="DropDownList2" runat="server"  CssClass="DropDownListNormal">
                        <asp:ListItem Value="continuous">مستمر</asp:ListItem>
                        <asp:ListItem Value="Final">پایانی</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <br />
                <br />
                <div style="margin-right: 20px;">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        CssClass="Grid" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging">
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
                                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("Score_ID") %>' Visible="False"></asp:Label>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("SI_Name").ToString() %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="نام کاربری">
                                <ItemTemplate>
                                      <a  href='<%# "./Index.aspx?Type=StudentDetail&ID_Student="+ Eval("Student_ID").ToString()%>'>
                                      <asp:Label ID="Labeluser" runat="server" Text='<%# Eval("SI_Username").ToString() %>'></asp:Label>
                                      </a>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="نمره">
                                <ItemTemplate>
                                    <asp:TextBox ID="TextBox1" Style="width: 30px; text-align: center; border: solid 1px black;"
                                        runat="server" CssClass="TextBoxNormal" Text='<%# Eval("Sc_Score") %>'></asp:TextBox>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="50px" HorizontalAlign="Center" />
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
                    <br>
                    <div style="margin-right: 500px;">
                    <asp:Button ID="Button1" runat="server" Text="ویرایش" ValidationGroup="Register" CssClass="ButtonNormal"
                        OnClick="Button1_Click" />
                        </div>
                </div>
            </div>
        </div>
    <asp:HiddenField ID="HiddenField1" runat="server" />
</ContentTemplate>
</asp:UpdatePanel>