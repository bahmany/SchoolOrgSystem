<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ScoreManage.ascx.cs" Inherits="UserControlPublic_AdminInformationAdd" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
        <div class="PanelContainerBig">
            <div class="PanelContainerTopBig">
            </div>
            <div class="PanelContainerBodyBig">
                <span class="PanelContainerBodySpanBig" style="margin-bottom: 20px;">مدیریت آزمون و نمرات دانش آموزان</span>
                <div style="margin-right: 30px; margin-left: 30px;">
                    <span class="SpanHelp">در این قسمت میتوانید آزمون و نمرات دانش آموزان مربوط به خود را مدیریت
                        نمایید : </span>
                    <br />
                    <br />
                </div>
                <div style="margin-right: 100px;">
                    <span class="SpanNormal">نام درس :</span>
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                        Visible="False" CssClass="DropDownListNormal">
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
                <span class="SpanNormal">نوع آزمون :</span>
                    <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack=true CssClass="DropDownListNormal"  OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                        <asp:ListItem Value="continuous">مستمر</asp:ListItem>
                        <asp:ListItem Value="Final">پایانی</asp:ListItem>
                    </asp:DropDownList>
                    </div>
                <br />
                <div style="margin-right: 20px;">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        CssClass="Grid" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging"
                        OnRowDeleting="GridView1_RowDeleting">
                        <RowStyle CssClass="GridRow" />
                        <EmptyDataRowStyle CssClass="GridEmpty" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1%>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="عنوان آزمون">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("ScoreTitle_ID") %>' Visible="False"></asp:Label>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("StTitle").ToString() %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        
                            <asp:TemplateField >

                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Delete" ImageUrl="~/Images/delete.gif"
                                OnClientClick="return confirm('آیا از این کار اطمینان دارید؟');" ToolTip="حذف" />
                        </ItemTemplate>
                        <ItemStyle CssClass="GridItemButton" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                          <a href='<%# "./Index.aspx?Type=ScoreEdit&ScoreTitle_ID="+ Eval("ScoreTitle_ID").ToString()%>'>  <asp:Image ID="Image1" ImageUrl="~/Images/edit.gif" runat="server" /></a>
                        </ItemTemplate>
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
                    
                </div>
            </div>
        </div>
</ContentTemplate>
</asp:UpdatePanel>