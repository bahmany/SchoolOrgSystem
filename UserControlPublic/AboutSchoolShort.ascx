<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AboutSchoolShort.ascx.cs"
    Inherits="UserControlPublic_Introduction" %>
<div class="PanelContainer">
    <div class="PanelContainerTop">
    </div>
    <div class="PanelContainerBody">
        <span class="PanelContainerBodySpan">معرفی کوتاه و اجمالی مجموعه</span>
        <asp:Panel Style="padding-top: 5px; padding-left: 5px; padding-right: 5px; height: 293px;padding-bottom:5px;
             float: right; width: 284px;" runat="server" ID="Panel1" ScrollBars="Auto">
            <%= text %>
        </asp:Panel>
    </div>
</div>
