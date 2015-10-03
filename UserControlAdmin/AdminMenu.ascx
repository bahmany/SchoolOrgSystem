<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminMenu.ascx.cs" Inherits="UserControlPublic_AdminInformationAdd" %>
<div class="PanelContainer">
    <div class="PanelContainerTop">
    </div>
    <div class="PanelContainerBody">
        <span class="PanelContainerBodySpan" style="margin-bottom: 10px;">منوی مدیریت</span>
        <div style="float: right;">
            <ul id="menu">
                <li><a href="./index.aspx?Type=IndexAdmin">
                    <asp:Image ID="Image21" ImageUrl="~/Images/house.png" runat="server" />&nbsp;صفحه
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
                            ID="Image6" ImageUrl="~/Images/email_go.png" runat="server" />&nbsp;پیام های فرستاده
                            شده</a></li>
                        <li><a href="./index.aspx?Type=AdminInformation">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image27"
                            ImageUrl="~/Images/user_edit.png" runat="server" />&nbsp;ویرایش اطلاعات شخصی</a></li>
                    </ul>
                </li>
                <li><a href="#">
                    <asp:Image ID="Image23" ImageUrl="~/Images/group.png" runat="server" />&nbsp;مدیریت
                    کاربران &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Image
                        ID="Image24" ImageUrl="~/Images/MenuJahat.gif" runat="server" /></a>
                    <ul class="submenu">
                        <li><a href="./index.aspx?Type=AdminInformationManage">&nbsp;&nbsp;&nbsp;<asp:Image
                            ID="Image30" ImageUrl="~/Images/group_key.png" runat="server" />&nbsp;مدیریت مدیران</a></li>
                        <li><a href="./index.aspx?Type=TeacherInformationManage">&nbsp;&nbsp;&nbsp;<asp:Image
                            ID="Image1" ImageUrl="~/Images/group_gear.png" runat="server" />&nbsp;مدیریت معلمان
                        </a></li>
                        <li><a href="./index.aspx?Type=StudentInformationInsertEdit">&nbsp;&nbsp;&nbsp;<asp:Image
                            ID="Image2" ImageUrl="~/Images/group_add.png" runat="server" />&nbsp;ثبت دانش آموز
                        </a></li>
                        <li><a href="./index.aspx?Type=StudentInformationManage">&nbsp;&nbsp;&nbsp;<asp:Image
                            ID="Image25" ImageUrl="~/Images/group_edit.png" runat="server" />&nbsp;مدیریت دانش
                            آموزان </a></li>
                        <li><a href="./index.aspx?Type=ParentInformationManage">&nbsp;&nbsp;&nbsp;<asp:Image
                            ID="Image29" ImageUrl="~/Images/group_link.png" runat="server" />&nbsp;مدیریت اولیاء
                            دانش آموزان</a></li>
                    </ul>
                </li>
                <li><a href="#">
                    <asp:Image ID="Image7" ImageUrl="~/Images/comment.png" runat="server" />&nbsp;مدیریت
                    محتوا&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Image
                        ID="Image8" ImageUrl="~/Images/MenuJahat.gif" runat="server" /></a>
                    <ul class="submenu">
                        <li><a href="./index.aspx?Type=AdminContentInsert&TypeContent=News">&nbsp;&nbsp;&nbsp;<asp:Image
                            ID="Image9" ImageUrl="~/Images/comment_add.png" runat="server" />&nbsp;افزودن اطلاعیه
                            و خبر</a></li>
                        <li><a href="./index.aspx?Type=AdminContentManage&TypeContent=News">&nbsp;&nbsp;&nbsp;<asp:Image
                            ID="Image4" ImageUrl="~/Images/comment_edit.png" runat="server" />&nbsp;مدیریت اطلاعیه
                            و خبر </a></li>
                        <li><a href="./index.aspx?Type=AdminContentInsert&TypeContent=Library">&nbsp;&nbsp;&nbsp;<asp:Image
                            ID="Image5" ImageUrl="~/Images/book_add.png" runat="server" />&nbsp;افزودن کتابهاومقالات
                        </a></li>
                        <li><a href="./index.aspx?Type=AdminContentManage&TypeContent=Library">&nbsp;&nbsp;&nbsp;<asp:Image
                            ID="Image22" ImageUrl="~/Images/book_edit.png" runat="server" />&nbsp;مدیریت کتابهاومقالات</a></li>
                        <li><a href="./index.aspx?Type=LinkInsert">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image10"
                            ImageUrl="~/Images/link_add.png" runat="server" />&nbsp;افزودن لینک های مفید </a>
                        </li>
                        <li><a href="./index.aspx?Type=LinkManage">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image13"
                            ImageUrl="~/Images/link_edit.png" runat="server" />&nbsp;مدیریت لینک های مفید</a></li>
                    </ul>
                </li>
                <li><a href="#">
                    <asp:Image ID="Image31" ImageUrl="~/Images/book_open.png" runat="server" />&nbsp;بخش
                    دروس&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Image
                        ID="Image32" ImageUrl="~/Images/MenuJahat.gif" runat="server" /></a>
                    <ul class="submenu">
                        <li><a href="./index.aspx?Type=LessonInsert">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image36"
                            ImageUrl="~/Images/page_edit.png" runat="server" />&nbsp;ثبت درس</a></li>
                        <li><a href="./index.aspx?Type=LessonManage">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image35"
                            ImageUrl="~/Images/page_copy.png" runat="server" />&nbsp;مدیریت دروس</a></li>
                        <li><a href="./index.aspx?Type=AdminTerm">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image38"
                            ImageUrl="~/Images/time.png" runat="server" />&nbsp;مدیریت ترم ها</a></li>
                    </ul>
                </li>
                <li><a href="#">
                    <asp:Image ID="Image17" ImageUrl="~/Images/lightbulb.png" runat="server" />&nbsp;بخش
                    غیر درسی&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Image
                        ID="Image18" ImageUrl="~/Images/MenuJahat.gif" runat="server" /></a>
                    <ul class="submenu">
                        <li><a href="./index.aspx?Type=GalleryInsert">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image16"
                            ImageUrl="~/Images/camera_add.png" runat="server" />&nbsp;افزایش گالری تصاویر</a></li>
                        <li><a href="./index.aspx?Type=GalleryManage">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image26"
                            ImageUrl="~/Images/camera_edit.png" runat="server" />&nbsp;مدیریت گالری تصاویر </a>
                        </li>
                        <li><a href="./index.aspx?Type=AdminWait">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image19"
                            ImageUrl="~/Images/chart_bar_add.png" runat="server" />&nbsp;افزایش نظر سنجی</a></li>
                        <li><a href="./index.aspx?Type=AdminWait">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image20"
                            ImageUrl="~/Images/chart_bar_edit.png" runat="server" />&nbsp;مدیریت نظرسنجی </a>
                        </li>
                        <li><a href="./index.aspx?Type=AdminContentInsert&TypeContent=Break">&nbsp;&nbsp;&nbsp;<asp:Image
                            ID="Image33" ImageUrl="~/Images/bug.png" runat="server" />&nbsp;افزایش زنگ تفریح
                        </a></li>
                        <li><a href="./index.aspx?Type=AdminContentManage&TypeContent=Break">&nbsp;&nbsp;&nbsp;<asp:Image
                            ID="Image34" ImageUrl="~/Images/bug_edit.png" runat="server" />&nbsp;مدیریت زنگ
                            تفریح</a></li>
                    </ul>
                </li>
                <li><a href="#">
                    <asp:Image ID="Image37" ImageUrl="~/Images/cog.png" runat="server" />&nbsp;بخش تنظیمات&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Image ID="Image39" ImageUrl="~/Images/MenuJahat.gif" runat="server" /></a>
                    <ul class="submenu">
                    <li><a href="./index.aspx?Type=SubTitleManage">&nbsp;&nbsp;&nbsp;<asp:Image
                            ID="Image48" ImageUrl="~/Images/comment_Edit.png" runat="server" />&nbsp;پیام های زیرنویس
                            </a></li>
                        <li><a href="./index.aspx?Type=AdminOneRecord&Kind=AboutSchoolShort">&nbsp;&nbsp;&nbsp;<asp:Image
                            ID="Image40" ImageUrl="~/Images/comment.png" runat="server" />&nbsp;معرفی کوتاه
                            و اجمالی</a></li>
                        <li><a href="./index.aspx?Type=AdminOneRecord&Kind=AboutSchool">&nbsp;&nbsp;&nbsp;<asp:Image
                            ID="Image46" ImageUrl="~/Images/door.png" runat="server" />&nbsp;درباره مووسسه</a></li>
                        <li><a href="./index.aspx?Type=AdminOneRecord&Kind=SchoolGoals">&nbsp;&nbsp;&nbsp;<asp:Image
                            ID="Image41" ImageUrl="~/Images/door_open.png" runat="server" />&nbsp;اهداف مجتمع
                        </a></li>
                        <li><a href="./index.aspx?Type=AdminOneRecord&Kind=SchoolGoalsWay">&nbsp;&nbsp;&nbsp;<asp:Image
                            ID="Image42" ImageUrl="~/Images/door_in.png" runat="server" />&nbsp;راه های رسیدن
                            به اهداف </a></li>
                        <li><a href="./index.aspx?Type=AdminOneRecord&Kind=SchoolPersonel">&nbsp;&nbsp;&nbsp;<asp:Image
                            ID="Image14" ImageUrl="~/Images/group.png" runat="server" />&nbsp;همکاران </a>
                        </li>
                        <li><a href="./index.aspx?Type=AdminOneRecord&Kind=SchoolTeachPlan">&nbsp;&nbsp;&nbsp;<asp:Image
                            ID="Image15" ImageUrl="~/Images/calendar.png" runat="server" />&nbsp;برنامه های
                            آموزشی </a></li>
                        <li><a href="./index.aspx?Type=AdminOneRecord&Kind=SchoolRegister">&nbsp;&nbsp;&nbsp;<asp:Image
                            ID="Image43" ImageUrl="~/Images/user_comment.png" runat="server" />&nbsp;راهنمای
                            ثبت نام</a></li>
                        <li><a href="./index.aspx?Type=AdminOneRecord&Kind=SchoolSiteRegister">&nbsp;&nbsp;&nbsp;<asp:Image
                            ID="Image44" ImageUrl="~/Images/user_comment.png" runat="server" />&nbsp;راهنمای
                            ثبت نام سایت</a></li>
                        <li><a href="./index.aspx?Type=AdminOneRecord&Kind=SchoolAdvice">&nbsp;&nbsp;&nbsp;<asp:Image
                            ID="Image45" ImageUrl="~/Images/comments.png" runat="server" />&nbsp;بخش مشاوره</a></li>
                    </ul>
                </li>
                <li><a href="./index.aspx?Type=AdminCategory">
                    <asp:Image ID="Image3" ImageUrl="~/Images/folder.png" runat="server" />&nbsp; مدیریت
                    بخش ها </a></li>
                     <li><a href="./index.aspx?Type=CallUSManage">
                    <asp:Image ID="Image47" ImageUrl="~/Images/report_edit.png" runat="server" />&nbsp;مدیریت تماس با ما </a></li>
                <li><a href="./index.aspx?Type=Exit">
                    <asp:Image ID="Image2337" ImageUrl="~/Images/close.gif" runat="server" />&nbsp;خروج
                    از مدیریت </a></li>
            </ul>
        </div>
    </div>
</div>
