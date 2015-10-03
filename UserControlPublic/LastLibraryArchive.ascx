<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LastLibraryArchive.ascx.cs" Inherits="UserControlPublic_LastBook" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div class="PanelContainerBig">
    <div class="PanelContainerTopBig">
    </div>
    <div class="PanelContainerBodyBig">
        <span class="PanelContainerBodySpanBig">آخرین کتب </span>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            CssClass="GridBox" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging"
            OnRowDataBound="GridView1_RowDataBound" ShowHeader="False" Width="594px" PageSize="20">
            <RowStyle CssClass="GridRow" />
            <EmptyDataRowStyle CssClass="GridEmptyBox" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("Content_ID") %>' Visible="False"></asp:Label>
                        <asp:Image ID="Image1" Style="margin-left: 0px;" ImageUrl="~/Images/mosbat-abi.gif"
                            runat="server" />
                        <a style="font-size: 9pt" href='<%#"./index.aspx?Type=ContentPublic&ID_Content=" +Eval("Content_ID").ToString() %>'>
                            <%# Eval("Con_Title").ToString() %></a>
                        <br />
                        <asp:Label Style="margin-top: 2px;" Width="150" Font-Size="8pt" ForeColor="Gray"
                            ID="lblName" runat="server"></asp:Label>
                        <asp:Label Font-Size="8pt" ForeColor="Gray" Text='<%# "در تاریخ : " + Eval("Con_Date").ToString() %>'
                            ID="Label2" runat="server"></asp:Label>
                        <asp:Label ID="Type_Role" runat="server" Text='<%# Eval("Con_Type_Role") %>' Visible="False"></asp:Label>
                        <asp:Label ID="ID_Role" runat="server" Text='<%# Eval("Con_ID_Role") %>' Visible="False"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle HorizontalAlign="Right" CssClass="GridRowBox" />
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
</ContentTemplate>
</asp:UpdatePanel>