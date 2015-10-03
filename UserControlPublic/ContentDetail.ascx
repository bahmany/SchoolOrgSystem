<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ContentDetail.ascx.cs"
    Inherits="UserControlPublic_AdminInformationAdd" %>
<div class="PanelContainerBig">
    <div class="PanelContainerTopBig">
    </div>
    <div class="PanelContainerBodyBig">
        <span class="PanelContainerBodySpanBig" style="margin-bottom: 20px;">
            <%= TitleContent %></span>
        <div style="margin-right: 20px; margin-left: 20px;">
            <p>
                <asp:Label ID="Label2" runat="server"></asp:Label>
            </p>
      
            <asp:Panel ID="Panel2" Font-Size="8pt" runat="server" GroupingText="<B>مسیر جاری</B>"
                Width="540px">
                <div class="PanelStyle">
                    <asp:Label ID="lblPath" runat="server"></asp:Label>
                </div>
            </asp:Panel>
            <br />
            <p>
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </p>
            <br />
            <asp:Panel ID="Panel1" Font-Size="8pt" runat="server" Font-Bold="True" GroupingText="فایل پیوست"
                Width="550px">
                 <div class="PanelStyle">
                <asp:Image ID="Image4" runat="server" ImageUrl="~/images/rar.gif" Style="margin-left: 5px;" />
                <asp:HyperLink ID="HyperLink1" runat="server" Font-Bold="False" Font-Size="8pt" Style="margin-left: 5px;
                    margin-right: 5px;" Target="_blank">دانلود فایل</asp:HyperLink>
                <asp:Label ID="Label3" runat="server" Font-Bold="False" Font-Names="Tahoma" Font-Size="8pt"
                    Style="margin-left: 5px; text-align: right;"></asp:Label>
                <asp:Label ID="Label4" runat="server" Font-Bold="False" Font-Size="8pt" Style="text-align: right">کیلو بایت</asp:Label>
                </div>
            </asp:Panel>
        </div>
    </div>
    <span class="PanelContainerBodySpanBigDown">
        <asp:Image Style="margin-right: 15px;" ID="Image1" ImageUrl="~/Images/puce_menu.gif"
            runat="server" />
        تاریخ ثبت :
        <%= DateContent %>
        <asp:Image Style="margin-right: 15px;" ID="Image2" ImageUrl="~/Images/puce_menu.gif"
            runat="server" />
        توسط :
        <%= AuthorContent %>
        <asp:Image Style="margin-right: 15px;" ID="Image3" ImageUrl="~/Images/puce_menu.gif"
            runat="server" />
        تعداد بازدید :
        <%= BazdidContent %>
    </span>
</div>
