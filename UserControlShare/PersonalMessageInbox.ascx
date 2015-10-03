<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PersonalMessageInbox.ascx.cs"
    Inherits="UserControlPublic_AdminInformationAdd" %>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div class="PanelContainerBig">
    <div class="PanelContainerTopBig">

    </div>
    <div class="PanelContainerBodyBig">
        <span class="PanelContainerBodySpanBig" style="margin-bottom: 20px;">پیام های دریافتی</span>
        <div style="margin-right: 30px; margin-left: 30px;">
            <span class="SpanHelp">در این قسمت میتوانید پیام های دریافتی خود را مشاهده و مدیریت نمایید :
            </span>
            <br />
            <br />
            <br />
            <br />
        </div>

        <div style="margin-right: 20px;">
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                CssClass="Grid" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging"
                OnRowDeleting="GridView1_RowDeleting"  
                PageSize="10" onrowdatabound="GridView1_RowDataBound">
                <RowStyle CssClass="GridRow" />
                <EmptyDataRowStyle CssClass="GridEmpty" />
                <Columns>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="#">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 +" -"%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" VerticalAlign=Top  Width="25px"/>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="عنوان">
                        <ItemTemplate>
                        <a  href="index.aspx?Type=PersonalMessageDetail&Kind=Inbox&ID_PersonalMessage=<%# Eval("Personal_Message_ID") %>"><%# Eval("PM_Title").ToString() %> </a>
                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("Personal_Message_ID") %>' Visible="False"></asp:Label>
                            <asp:Label ID="lblTypeSender" runat="server" Text='<%# Eval("PM_Type_Role_Sender") %>' Visible="False"></asp:Label>
                            <asp:Label ID="lblIDSender" runat="server" Text='<%# Eval("PM_ID_Role_Sender") %>' Visible="False"></asp:Label>
                            <asp:Label ID="lblVision" runat="server" Text='<%# Eval("PM_vision") %>' Visible="False"></asp:Label>
                            <asp:Label ID="lblDelete_Sender" runat="server" Text='<%# Eval("PM_Delete_Sender") %>' Visible="False"></asp:Label>
                            <asp:Label ID="lblDelete_Getter" runat="server" Text='<%# Eval("PM_Delete_Getter") %>' Visible="False"></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" VerticalAlign=Top />
                    </asp:TemplateField>
                    
                     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="ارسال کننده">
                        <ItemTemplate>
                            <asp:Label ID="lblName" runat="server" Text=""></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="تاریخ ارسال">
                        <ItemTemplate>
                            <asp:Label ID="lbldate" runat="server" Text='<%# Eval("PM_date") %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="100px"/>
                    </asp:TemplateField>
                    
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Delete" ImageUrl="~/Images/delete.gif"
                                OnClientClick="return confirm('آیا از این کار اطمینان دارید؟');" ToolTip="حذف" />
                        </ItemTemplate>
                        <ItemStyle CssClass="GridItemButton" Width="20px" />
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
</div>
</ContentTemplate>
</asp:UpdatePanel>