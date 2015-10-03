<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ParentStudentLastGallery.ascx.cs" Inherits="UserControlPublic_LastBook" %>
 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div class="PanelContainer">
    <div class="PanelContainerTop">
     </div>
    <div class="PanelContainerBody">
        <span class="PanelContainerBodySpan">گالری تصاویر </span>
         <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            CssClass="GridBox" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging"
            OnRowDataBound="GridView1_RowDataBound" ShowHeader="False" Width="294px" PageSize="5">
            <RowStyle CssClass="GridRow" />
            <EmptyDataRowStyle CssClass="GridEmptyBox" />
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("GallerySubjet_ID") %>' Visible="False"></asp:Label>
                        <asp:Image ID="Image1" Style="margin-left: 0px;" ImageUrl="~/Images/mosbat-abi.gif"
                            runat="server" />
                        <a style="font-size: 9pt" href='<%#"./index.aspx?Type=GalleryDetail"+Request.Cookies["Type_Role"].Value.ToString()+"&ID_GallerySubject=" + Eval("GallerySubjet_ID").ToString() %>'>
                            <%# Eval("gs_Title").ToString() %></a>
                            <asp:Label ID="lblCount" style="font-size: 9pt;color:Gray" runat="server" Text="Label"></asp:Label>
                        <br />
                        <asp:Label Style="margin-top: 2px;" Width="150" Font-Size="8pt" ForeColor="Gray"
                            ID="lblName" runat="server"></asp:Label>
                        <asp:Label Font-Size="8pt" ForeColor="Gray" Text='<%# "در تاریخ : " + Eval("gs_Date").ToString() %>'
                            ID="Label2" runat="server"></asp:Label>
                        
                        <asp:Label ID="ID_Role" runat="server" Text='<%# Eval("gs_ID_Admin") %>' Visible="False"></asp:Label>
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