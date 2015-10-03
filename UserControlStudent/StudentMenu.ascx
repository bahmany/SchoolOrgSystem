<%@ Control Language="C#" AutoEventWireup="true" CodeFile="StudentMenu.ascx.cs" Inherits="UserControlPublic_AdminInformationAdd" %>
<div class="PanelContainer">
    <div class="PanelContainerTop">
    </div>
    <div class="PanelContainerBody">
        <span class="PanelContainerBodySpan" style="margin-bottom: 10px;">منوی مدیریت</span>
        <div style="float: right;">
            <ul id="menu">
                <li><a href="./index.aspx?Type=IndexStudent">
                    <asp:Image ID="Image1" ImageUrl="~/Images/house.png" runat="server" />&nbsp;صفحه
                    اصلی شخصی</a></li>
                <li><a href="#">
                    <asp:Image ID="Image11" ImageUrl="~/Images/user.png" runat="server" />&nbsp;مشخصات
                    شخصی &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Image ID="Image12" ImageUrl="~/Images/MenuJahat.gif"
                        runat="server" /></a>
                    <ul class="submenu">
                        <li><a href="./index.aspx?Type=PersonalMessageInbox">&nbsp;&nbsp;&nbsp;<asp:Image
                            ID="Image28" ImageUrl="~/Images/email.png" runat="server" />&nbsp;پیام های دریافتی
                            (
                            <%= MessageUnread %>
                            )</a></li>
                        <li><a href="./index.aspx?Type=PersonalMessageOutbox">&nbsp;&nbsp;&nbsp;<asp:Image
                            ID="Image2" ImageUrl="~/Images/email_go.png" runat="server" />&nbsp;پیام های فرستاده
                            شده</a></li>
                        <li><a href="./index.aspx?Type=StudentInformation">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image27"
                            ImageUrl="~/Images/user_edit.png" runat="server" />&nbsp;ویرایش اطلاعات شخصی</a></li>
                    </ul>
                </li>
                <li><a href="#">
                    <asp:Image ID="Image10" ImageUrl="~/Images/group.png" runat="server" />&nbsp;لیست
                    های کاربری&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Image ID="Image13"
                        ImageUrl="~/Images/MenuJahat.gif" runat="server" /></a>
                    <ul class="submenu">
                       
                         <li><a href="./index.aspx?Type=StudentClassmateList">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image30"
                            ImageUrl="~/Images/group.png" runat="server" />&nbsp; لیست هم کلاسی ها</a></li>
                       
                       <li><a href="./index.aspx?Type=StudentLessonView">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image5"
                            ImageUrl="~/Images/page_copy.png" runat="server" />&nbsp;لیست دروس و معلمان</a></li>
                        <li><a href="./index.aspx?Type=AdminList">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image26"
                            ImageUrl="~/Images/group_key.png" runat="server" />&nbsp;لیست مدیران</a></li>
                    </ul>
                </li>
                <li><a href="#">
                    <asp:Image ID="Image3" ImageUrl="~/Images/book_open.png" runat="server" />&nbsp;بخش
                    درسی&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Image
                        ID="Image4" ImageUrl="~/Images/MenuJahat.gif" runat="server" /></a>
                    <ul class="submenu">
                       
                        <li><a href="./index.aspx?Type=StudentTestView">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image7"
                            ImageUrl="~/Images/time.png" runat="server" />&nbsp;آزمون آنلاین </a></li>
                        <li><a href="./index.aspx?Type=StudentScoreView">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image124"
                            ImageUrl="~/Images/pencil_add.png" runat="server" />&nbsp;مشاهده نمرات </a></li>
                        <li><a href="./index.aspx?Type=StudentWait">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image32"
                            ImageUrl="~/Images/page_delete.png" runat="server" />&nbsp;مشاهده موارد اخلاقی</a></li>
                    </ul>
                </li>
                <li><a href="./index.aspx?Type=Exit">
                    <asp:Image ID="Image6" ImageUrl="~/Images/close.gif" runat="server" />&nbsp;خروج
                    از مدیریت </a></li>
            </ul>
        </div>
    </div>
</div>
