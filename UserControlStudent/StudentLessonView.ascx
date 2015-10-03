<%@ Control Language="C#" AutoEventWireup="true" CodeFile="StudentLessonView.ascx.cs"
    Inherits="UserControlPublic_AdminInformationAdd" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class="PanelContainerBig">
            <div class="PanelContainerTopBig">
            </div>
            <div class="PanelContainerBodyBig">
                <span class="PanelContainerBodySpanBig" style="margin-bottom: 20px;">لیست دروس و معلمان</span>
                <div style="margin-right: 20px; margin-left: 20px;">
                    <span class="SpanHelp">در این قسمت میتوانید دروس کلاس خود را مشاهده نمایید : </span>
                    <br />
                    <br />
                    <asp:Panel ID="Panel2" Font-Size="8pt" runat="server" GroupingText="<B>مسیر کلاس</B>"
                        Width="540px">
                        <div class="PanelStyle">
                            <asp:Label ID="lblPath" runat="server"></asp:Label>
                        </div>
                    </asp:Panel>
                    <br />
                </div>
                <div style="margin-right: 20px;">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        CssClass="Grid" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging"
                        PageSize="10">
                        <RowStyle CssClass="GridRow" />
                        <EmptyDataRowStyle CssClass="GridEmpty" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1%>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="نام درس">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("Lesson_ID") %>' Visible="False"></asp:Label>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("Les_Name").ToString() %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="تعداد واحد">
                                <ItemTemplate>
                                    <asp:Label ID="Labelunit" runat="server" Text='<%# Eval("Les_Unit").ToString() %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="زمان برگزاری">
                                <ItemTemplate>
                                    <asp:Label ID="Labelusername" runat="server" Text='<%# Eval("Les_Lesson_Time").ToString().Replace("\n", "<br>") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="نام معلم">
                                <ItemTemplate>
                                    <asp:Label ID="Labelusername" runat="server" Text='<%# Eval("TI_Name") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="مشخصات معلم" HeaderStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <a href='<%# "./Index.aspx?Type=TeacherDetail&ID_Teacher="+ Eval("Teacher_ID").ToString()%>'>
                                        <asp:Image ID="Image1" ImageUrl="~/Images/vcard.png" runat="server" /></a>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
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
    </ContentTemplate>
</asp:UpdatePanel>
