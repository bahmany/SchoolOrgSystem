<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ParentMenu.ascx.cs" Inherits="UserControlPublic_AdminInformationAdd" %>
<div class="PanelContainer">
    <div class="PanelContainerTop">
    </div>
    <div class="PanelContainerBody">
        <span class="PanelContainerBodySpan" style="margin-bottom:10px;">منوی مدیریت</span>
        <div style="float:right;">
        
          <ul id="menu">
                <li><a href="./index.aspx?Type=IndexParent">
                    <asp:Image ID="Image1" ImageUrl="~/Images/house.png" runat="server" />&nbsp;صفحه
                    اصلی شخصی</a></li>
                    
                    <li><a href="#">
                    <asp:Image ID="Image11" ImageUrl="~/Images/user.png" runat="server" />&nbsp;مشخصات
                    شخصی &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Image ID="Image12" ImageUrl="~/Images/MenuJahat.gif"
                        runat="server" /></a>
                    <ul class="submenu">
                        <li><a href="./index.aspx?Type=PersonalMessageInbox">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image28"
                            ImageUrl="~/Images/email.png" runat="server" />&nbsp;پیام های دریافتی ( <%= MessageUnread %> )</a></li>
                             <li><a href="./index.aspx?Type=PersonalMessageOutbox">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image2"
                            ImageUrl="~/Images/email_go.png" runat="server" />&nbsp;پیام های فرستاده شده</a></li>
                        <li><a href="./index.aspx?Type=ParentInformation">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image27"
                            ImageUrl="~/Images/user_edit.png" runat="server" />&nbsp;ویرایش اطلاعات شخصی</a></li>
                    </ul>
                </li>
                    
               <li><a href="#">
                    <asp:Image ID="Image10" ImageUrl="~/Images/group.png" runat="server" />&nbsp;لیست
                    های کاربری&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Image ID="Image13"
                        ImageUrl="~/Images/MenuJahat.gif" runat="server" /></a>
                    <ul class="submenu">
                        <li><a href="./index.aspx?Type=ParentList">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image14"
                            ImageUrl="~/Images/group_link.png" runat="server" />&nbsp;لیست اولیاء دانش آموزان</a></li>
                         <li><a href="./index.aspx?Type=TeacherList">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image25"
                            ImageUrl="~/Images/group_gear.png" runat="server" />&nbsp;لیست دروس و معلمان </a></li>
                       
                        <li><a href="./index.aspx?Type=AdminList">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image26"
                            ImageUrl="~/Images/group_key.png" runat="server" />&nbsp;لیست مدیران</a></li>
                    </ul>
                </li>
                <li><a href="./index.aspx?Type=Exit">
                    <asp:Image ID="Image6" ImageUrl="~/Images/close.gif" runat="server" />&nbsp;خروج
                    از مدیریت </a></li>
            </ul>
      </div>

    </div>
</div>
