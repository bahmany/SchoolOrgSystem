<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GalleryDetail.ascx.cs"
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
            <asp:DataList RepeatColumns="5" ID="DataList1" runat="server">
                <ItemTemplate>
                    <asp:HyperLink NavigateUrl='<%# Eval("gp_Address")  %>' Target="_blank" ID="HyperLink1"
                        runat="server">
                        <asp:Image Style="border: solid 1px gray; margin: 1px;" Height="100px" Width="100px"
                            ImageUrl='<%# Eval("gp_Address")  %>' ID="Image4" runat="server" />
                    </asp:HyperLink>
                </ItemTemplate>
            </asp:DataList>
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
