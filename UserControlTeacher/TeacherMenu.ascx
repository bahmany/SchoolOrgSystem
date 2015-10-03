<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TeacherMenu.ascx.cs" Inherits="UserControlPublic_AdminInformationAdd" %>
<div class="PanelContainer">
    <div class="PanelContainerTop">
    </div>
    <div class="PanelContainerBody">
        <span class="PanelContainerBodySpan" style="margin-bottom: 10px;">منوی کاربری</span>
        <div style="float: right;">
            <ul id="menu">
                <li><a href="./index.aspx?Type=IndexTeacher">
                    <asp:Image ID="Image21" ImageUrl="~/Images/house.png" runat="server" />&nbsp;صفحه
                    اصلی شخصی</a></li>
                <li><a href="#">
                    <asp:Image ID="Image2" ImageUrl="~/Images/user.png" runat="server" />&nbsp;مشخصات
                    شخصی &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Image ID="Image3" ImageUrl="~/Images/MenuJahat.gif"
                        runat="server" /></a>
                    <ul class="submenu">
                        <li><a href="./index.aspx?Type=PersonalMessageInbox">&nbsp;&nbsp;&nbsp;<asp:Image
                            ID="Image28" ImageUrl="~/Images/email.png" runat="server" />&nbsp;پیام های دریافتی
                            (
                            <%= MessageUnread %>
                            )</a></li>
                        <li><a href="./index.aspx?Type=PersonalMessageOutbox">&nbsp;&nbsp;&nbsp;<asp:Image
                            ID="Image15" ImageUrl="~/Images/email_go.png" runat="server" />&nbsp;پیام های فرستاده
                            شده</a></li>
                        <li><a href="./index.aspx?Type=TeacherInformation">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image27"
                            ImageUrl="~/Images/user_edit.png" runat="server" />&nbsp;ویرایش اطلاعات شخصی</a></li>
                    </ul>
                </li>
                <li><a href="#">
                    <asp:Image ID="Image6" ImageUrl="~/Images/group.png" runat="server" />&nbsp;لیست
                    های کاربری&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Image ID="Image16"
                        ImageUrl="~/Images/MenuJahat.gif" runat="server" /></a>
                    <ul class="submenu">
                      <li><a href="./index.aspx?Type=TeacherStudentList">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image30"
                            ImageUrl="~/Images/group.png" runat="server" />&nbsp; لیست دانش آموزان</a></li>
                        <li><a href="./index.aspx?Type=ParentList">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image23"
                            ImageUrl="~/Images/group_link.png" runat="server" />&nbsp;لیست اولیاء دانش آموزان</a></li>
                        
                        <li><a href="./index.aspx?Type=TeacherList">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image25"
                            ImageUrl="~/Images/group_gear.png" runat="server" />&nbsp;لیست معلمان </a></li>
                        <li><a href="./index.aspx?Type=AdminList">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image29"
                            ImageUrl="~/Images/group_key.png" runat="server" />&nbsp;لیست مدیران</a></li>
                    </ul>
                </li>
                <li><a href="#">
                    <asp:Image ID="Image7" ImageUrl="~/Images/comment.png" runat="server" />&nbsp;مدیریت
                    محتوا&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Image
                        ID="Image8" ImageUrl="~/Images/MenuJahat.gif" runat="server" /></a>
                    <ul class="submenu">
                        <li><a href="./index.aspx?Type=TeacherContentInsert&TypeContent=News">&nbsp;&nbsp;&nbsp;<asp:Image
                            ID="Image9" ImageUrl="~/Images/comment_add.png" runat="server" />&nbsp;افزودن اطلاعیه
                            و خبر</a></li>
                        <li><a href="./index.aspx?Type=TeacherContentManage&TypeContent=News">&nbsp;&nbsp;&nbsp;<asp:Image
                            ID="Image11" ImageUrl="~/Images/comment_edit.png" runat="server" />&nbsp;مدیریت
                            اطلاعیه و خبر </a></li>
                        <li><a href="./index.aspx?Type=TeacherContentInsert&TypeContent=Library">&nbsp;&nbsp;&nbsp;<asp:Image
                            ID="Image12" ImageUrl="~/Images/book_add.png" runat="server" />&nbsp;افزودن کتابهاومقالات
                        </a></li>
                        <li><a href="./index.aspx?Type=TeacherContentManage&TypeContent=Library">&nbsp;&nbsp;&nbsp;<asp:Image
                            ID="Image22" ImageUrl="~/Images/book_edit.png" runat="server" />&nbsp;مدیریت کتابهاومقالات</a></li>
                            <li><a href="./index.aspx?Type=LinkInsert">&nbsp;&nbsp;&nbsp;<asp:Image
                            ID="Image24" ImageUrl="~/Images/link_add.png" runat="server" />&nbsp;افزودن لینک های مفید
                        </a></li>
                        <li><a href="./index.aspx?Type=LinkManage">&nbsp;&nbsp;&nbsp;<asp:Image
                            ID="Image34" ImageUrl="~/Images/link_edit.png" runat="server" />&nbsp;مدیریت لینک های مفید</a></li>
                    </ul>
                </li>
                <li><a href="#">
                    <asp:Image ID="Image1" ImageUrl="~/Images/book_open.png" runat="server" />&nbsp;بخش
                    دروس&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Image
                        ID="Image4" ImageUrl="~/Images/MenuJahat.gif" runat="server" /></a>
                    <ul class="submenu">
                      
                        <li><a href="./index.aspx?Type=TeacherLessonView">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image5"
                            ImageUrl="~/Images/page_copy.png" runat="server" />&nbsp;مشاهده دروس واگذار شده</a></li>
                        <li><a href="./index.aspx?Type=ScoreInsert">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image10"
                            ImageUrl="~/Images/pencil_add.png" runat="server" />&nbsp;ثبت آزمون و نمرات </a>
                        </li>
                        <li><a href="./index.aspx?Type=ScoreManage">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image33"
                            ImageUrl="~/Images/page_edit.png" runat="server" />&nbsp;مدیریت آزمون و نمرات </a>
                        </li>
                        <li><a href="./index.aspx?Type=TeacherWait">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image32"
                            ImageUrl="~/Images/page_delete.png" runat="server" />&nbsp;ثبت موارد اخلاقی</a></li>
                        
                    </ul>
                </li>
                 <li><a href="#">
                    <asp:Image ID="Image35" ImageUrl="~/Images/time.png" runat="server" />&nbsp;بخش
                    آزمون آنلاین&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Image
                        ID="Image36" ImageUrl="~/Images/MenuJahat.gif" runat="server" /></a>
                    <ul class="submenu">
                      
                        
                        <li><a href="./index.aspx?Type=TestInsert">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image38"
                            ImageUrl="~/Images/pencil_add.png" runat="server" />&nbsp;ثبت آزمون آنلاین جدید </a>
                        </li>
                        <li><a href="./index.aspx?Type=TestManage">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image39"
                            ImageUrl="~/Images/page_edit.png" runat="server" />&nbsp;مدیریت آزمون آنلاین </a>
                        </li>
                        
                    </ul>
                </li>
                <li><a href="#">
                    <asp:Image ID="Image17" ImageUrl="~/Images/lightbulb.png" runat="server" />&nbsp;بخش
                    غیر درسی&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Image
                        ID="Image18" ImageUrl="~/Images/MenuJahat.gif" runat="server" /></a>
                    <ul class="submenu">
                        <li><a href="./index.aspx?Type=TeacherContentInsert&TypeContent=Break">&nbsp;&nbsp;&nbsp;<asp:Image
                            ID="Image19" ImageUrl="~/Images/chart_bar_add.png" runat="server" />&nbsp;افزایش
                            زنگ تفریح</a></li>
                        <li><a href="./index.aspx?Type=TeacherContentManage&TypeContent=Break">&nbsp;&nbsp;&nbsp;<asp:Image
                            ID="Image20" ImageUrl="~/Images/chart_bar_edit.png" runat="server" />&nbsp; مدیریت
                            زنگ تفریح</a> </li>
                        <li><a href="./index.aspx?Type=TeacherWait">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image13"
                            ImageUrl="~/Images/chart_bar_add.png" runat="server" />&nbsp;افزایش نظر سنجی</a></li>
                        <li><a href="./index.aspx?Type=TeacherWait">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image14"
                            ImageUrl="~/Images/chart_bar_edit.png" runat="server" />&nbsp;مدیریت نظرسنجی </a>
                        </li>
                    </ul>
                </li>
                <li><a href="./index.aspx?Type=Exit">
                    <asp:Image ID="Image26" ImageUrl="~/Images/close.gif" runat="server" />&nbsp;خروج
                    از مدیریت </a></li>
            </ul>
        </div>
    </div>
</div>
