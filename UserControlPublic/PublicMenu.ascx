<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PublicMenu.ascx.cs" Inherits="UserControlPublic_AdminInformationAdd" %>
<div class="PanelContainer">
    <div class="PanelContainerTop">
    </div>
    <div class="PanelContainerBody">
        <span class="PanelContainerBodySpan" style="margin-bottom: 10px;">منوی اصلی</span>
        <div style="float: right;">
            <ul id="menu">
                <li><a href="./index.aspx">
                    <asp:Image ID="Image1" ImageUrl="~/Images/house.png" runat="server" />&nbsp;صفحه
                    اصلی </a></li>
                
                <li><a href="#">
                    <asp:Image ID="Image10" ImageUrl="~/Images/sitemap_color.png" runat="server" />&nbsp;بخش معرفی&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Image ID="Image13"
                        ImageUrl="~/Images/MenuJahat.gif" runat="server" /></a>
                    <ul class="submenu">
                        <li><a href="./index.aspx?Type=OneRecordDetail&Kind=AboutSchool">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image14"
                            ImageUrl="~/Images/door.png" runat="server" />&nbsp;درباره مووسسه</a></li>
                        <li><a href="./index.aspx?Type=OneRecordDetail&Kind=SchoolGoals">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image15"
                            ImageUrl="~/Images/door_open.png" runat="server" />&nbsp;اهداف مجتمع </a>
                        </li>
                        <li><a href="./index.aspx?Type=OneRecordDetail&Kind=SchoolGoalsWay">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image16"
                            ImageUrl="~/Images/door_in.png" runat="server" />&nbsp;راه های رسیدن به اهداف </a></li>
                             <li><a href="./index.aspx?Type=OneRecordDetail&Kind=SchoolPersonel">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image7"
                            ImageUrl="~/Images/group.png" runat="server" />&nbsp;همکاران </a></li>
                             <li><a href="./index.aspx?Type=OneRecordDetail&Kind=SchoolTeachPlan">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image8"
                            ImageUrl="~/Images/calendar.png" runat="server" />&nbsp;برنامه های آموزشی </a></li>
                             <li><a href="./index.aspx?Type=OneRecordDetail&Kind=SchoolRegister">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image2"
                            ImageUrl="~/Images/user_comment.png" runat="server" />&nbsp;راهنمای ثبت نام </a></li>
                       
                    </ul>
                </li>
                <li><a href="#">
                    <asp:Image ID="Image3" ImageUrl="~/Images/user_go.png" runat="server" />&nbsp;بخش
                    ثبت نام سایت&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Image
                        ID="Image4" ImageUrl="~/Images/MenuJahat.gif" runat="server" /></a>
                    <ul class="submenu">
                        <li><a href="./index.aspx?Type=OneRecordDetail&Kind=SchoolSiteRegister">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image30"
                            ImageUrl="~/Images/help.png" runat="server" />&nbsp;راهنمای ثبت نام سایت</a></li>
                        <li><a href="./index.aspx?Type=ParentRegister">&nbsp;&nbsp;&nbsp;<asp:Image ID="Image5"
                            ImageUrl="~/Images/user_edit.png" runat="server" />&nbsp;ثبت نام اولیاء</a></li>
                        
                    </ul>
                </li>
                <li><a href="./index.aspx?Type=OneRecordDetail&Kind=SchoolAdvice">
                    <asp:Image ID="Image6" ImageUrl="~/Images/comments.png" runat="server" />&nbsp;بخش مشاوره </a></li>
                    <li><a href="./index.aspx?Type=LastNewsArchive">
                    <asp:Image ID="Image9" ImageUrl="~/Images/comment.png" runat="server" />&nbsp;آرشیو اخبار و رویدادها </a></li>
                    <li><a href="./index.aspx?Type=LastLibraryArchive">
                    <asp:Image ID="Image11" ImageUrl="~/Images/book.png" runat="server" />&nbsp;آرشیو کتابخانه </a></li>
                    <li><a href="./index.aspx?Type=LastGalleryArchive">
                    <asp:Image ID="Image12" ImageUrl="~/Images/camera.png" runat="server" />&nbsp;آرشیو گالری تصاویر </a></li>
                     <li><a href="./index.aspx?Type=Call_US">
                    <asp:Image ID="Image17" ImageUrl="~/Images/report_edit.png" runat="server" />&nbsp;تماس با ما </a></li>
            </ul>
        </div>
    </div>
</div>
