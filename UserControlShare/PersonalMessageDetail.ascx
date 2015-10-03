<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PersonalMessageDetail.ascx.cs"
    Inherits="UserControlPublic_AdminInformationAdd" %>
<div class="PanelContainerBig">
    <div class="PanelContainerTopBig">
    </div>
    <div class="PanelContainerBodyBig">
        <span class="PanelContainerBodySpanBig" style="margin-bottom: 20px;">
            <%= TitleContent %></span>
        <div style="margin-right: 20px; margin-left: 20px;">
            <asp:Panel ID="Panel1" Font-Size="8pt" runat="server" GroupingText="<B>مسیر جاری</B>"
                Width="540px">
                <div class="PanelStyle">
                    <asp:Label ID="lblPath" runat="server"></asp:Label>
                </div>
            </asp:Panel>
            <br />
            <br />
            <p>
                <asp:Label ID="Label1" runat="server"></asp:Label>
            </p>
            <br />
        </div>
    </div>
    <span class="PanelContainerBodySpanBigDown">
        <asp:Image Style="margin-right: 15px;" ID="Image1" ImageUrl="~/Images/entry.gif"
            runat="server" />
        تاریخ ثبت :
        <%= DateContent %>
        <asp:Image Style="margin-right: 15px;" ID="Image2" ImageUrl="~/Images/entry.gif"
            runat="server" />
            
              <%= AuthorContent %>
             
      
    </span>
</div>
