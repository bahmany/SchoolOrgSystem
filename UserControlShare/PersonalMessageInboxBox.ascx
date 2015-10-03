<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PersonalMessageInboxBox.ascx.cs"
    Inherits="UserControlPublic_AdminInformationAdd" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class="PanelContainer">
            <div class="PanelContainerTop">
            </div>
            <div class="PanelContainerBody">
                <span class="PanelContainerBodySpan" >آخرین پیام های دریافتی ( <%= MessageUnread %> )</span>
                <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    CssClass="GridBox" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging"
                     ShowHeader=false PageSize="5" OnRowDataBound="GridView1_RowDataBound">
                    <RowStyle CssClass="GridRow" />
                    <EmptyDataRowStyle CssClass="GridEmptyBox" />
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-HorizontalAlign="Center" >
                            <ItemTemplate>
                                <asp:Image ImageUrl="~/Images/mosbat-abi.gif" ID="Image1" runat="server" />
                                <a style="font-size: 9pt" href="index.aspx?Type=PersonalMessageDetail&Kind=Inbox&ID_PersonalMessage=<%# Eval("Personal_Message_ID") %>">
                                    <%# Eval("PM_Title").ToString() %>
                                </a>
                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("Personal_Message_ID") %>' Visible="False"></asp:Label>
                                <asp:Label ID="lblTypeSender" runat="server" Text='<%# Eval("PM_Type_Role_Sender") %>'
                                    Visible="False"></asp:Label>
                                <asp:Label ID="lblIDSender" runat="server" Text='<%# Eval("PM_ID_Role_Sender") %>'
                                    Visible="False"></asp:Label>
                                <asp:Label ID="lblVision" runat="server" Text='<%# Eval("PM_vision") %>' Visible="False"></asp:Label>
                                <asp:Label ID="lblDelete_Sender" runat="server" Text='<%# Eval("PM_Delete_Sender") %>'
                                    Visible="False"></asp:Label>
                                <asp:Label ID="lblDelete_Getter" runat="server" Text='<%# Eval("PM_Delete_Getter") %>'
                                    Visible="False"></asp:Label>
                                    <br />
                                     <asp:Label Style="margin-top: 2px;" Width="150" Font-Size="8pt" ForeColor="Gray"
                            ID="lblName" runat="server"></asp:Label>
                        <asp:Label Font-Size="8pt" ForeColor="Gray" Text='<%# "در تاریخ : " + Eval("PM_date").ToString() %>'
                            ID="Label2" runat="server"></asp:Label>
                            
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Right" CssClass="GridRowBox" />
                        </asp:TemplateField>
                        
                        
                        
                    </Columns>
                    <PagerStyle CssClass="GridPaging" />
                    <EmptyDataTemplate>
                        <asp:Label ID="Label1" runat="server" Text="اطلاعاتی به ثبت نرسیده است"></asp:Label>
                    </EmptyDataTemplate>
                    <HeaderStyle CssClass="GridHeader" />
                    <SelectedRowStyle BackColor="Gray" />
                </asp:GridView>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
