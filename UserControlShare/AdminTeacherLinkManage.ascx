<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminTeacherLinkManage.ascx.cs"
    Inherits="UserControlPublic_AdminInformationAdd" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class="PanelContainerBig">
            <div class="PanelContainerTopBig">
            </div>
            <div class="PanelContainerBodyBig">
                <span class="PanelContainerBodySpanBig" style="margin-bottom: 20px;">
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></span>
                <div style="margin-right: 30px; margin-left: 30px;">
                    <span class="SpanHelp">
                        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                    </span>
                    <br />
                    <br />
                   
                </div>
                <div style="margin-right: 100px;">
                    <span class="SpanNormal">بخش اول</span>
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
                </div>
                <div style="margin-right: 20px;">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        CssClass="Grid" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging"
                        OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" OnRowDataBound="GridView1_RowDataBound">
                        <RowStyle CssClass="GridRow" />
                        <EmptyDataRowStyle CssClass="GridEmpty" />
                        <Columns>
                            <asp:TemplateField HeaderText="#" HeaderStyle-HorizontalAlign="Center" >
                                <ItemTemplate >
                                    <%# Container.DataItemIndex + 1 + " -"%>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign=Top Width="30px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="عنوان">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("Link_ID") %>' Visible="False"></asp:Label>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("Li_Title").ToString() %>'></asp:Label>
                                </ItemTemplate>
                               
                                <ItemStyle HorizontalAlign="Right" VerticalAlign=Top/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="توسط">
                                <ItemTemplate>
                                    <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label>
                                    <asp:Label ID="Type_Role" runat="server" Text='<%# Eval("Li_Type_Role") %>' Visible="False"></asp:Label>
                                    <asp:Label ID="ID_Role" runat="server" Text='<%# Eval("Li_ID_Role") %>' Visible="False"></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="120px"/>
                            </asp:TemplateField>
                            
                          
                            
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Delete" ImageUrl="~/Images/delete.gif"
                                        OnClientClick="return confirm('آیا از این کار اطمینان دارید؟');" ToolTip="حذف" />
                                </ItemTemplate>
                                <ItemStyle Width="20px" CssClass="GridItemButton" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <a href='<%# "./Index.aspx?Type=LinkEdit"+"&Link_ID="+ Eval("Link_ID").ToString() %>'>
                                        <asp:Image ID="Image1" ImageUrl="~/Images/edit.gif" runat="server" /></a>
                                </ItemTemplate>
                                <ItemStyle Width="20px" CssClass="GridItemButton" />
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
