<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="CSS/StyleSheet.css" type="text/css" rel="Stylesheet" />
    <link href="CSS/menu.css" type="text/css" rel="Stylesheet" />

    <script src="JavaScript/jquery-latest.pack.js" type="text/javascript"></script>

    <script src="JavaScript/coin-slider.min.js" type="text/javascript"></script>

    <link href="CSS/coin-slider-styles.css" type="text/css" rel="stylesheet" />

    <script type="text/javascript">
    $(document).ready(function() {$('#coin-slider').coinslider({ width: 930, height:256, navigation: false, delay: 5000 });    });
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="container">
        <div class="divTopClass" id="divTop">
            <div id="logo">
                <div style="width: 100%; height: 85px">
                    <div>
                        <img style="width: 802px; height: 83px; float: right;" alt="" src="Images/Top_Logo.png" />
                        <div style="padding-top: 55px; vertical-align: bottom; color: #e7c9d1; text-align: left;
                            float: right; width: 145px; height: 20px">
                            <span id="ctl00_lbl_currentDate">
                                <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                            </span>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div id="Border">
            <div id="divMenuTop">
                <div style="width: 930px; height: 15px; margin-right: 10px;">
                    <div style="padding-top: 3px; float: right">
                        <a href="index.aspx">صفحه اصلي</a>  |&nbsp;
                    </div>
                    <div style="padding-top: 3px; float: right">
                        <a href="index.aspx?Type=OneRecordDetail&Kind=AboutSchool">درباره ما</a>
                        |&nbsp;
                    </div>
                    <div style="padding-top: 3px; float: right">
                        <a href="index.aspx?Type=OneRecordDetail&Kind=SchoolPersonel">همکاران</a> 
                        |&nbsp;
                    </div>
                    <div style="padding-top: 3px; float: right">
                        <a href="index.aspx?Type=OneRecordDetail&Kind=SchoolTeachPlan">برنامه هاي آموزشي</a>
                        |&nbsp;
                    </div>
                    <div style="padding-top: 3px; float: right">
                        <a href="index.aspx?Type=LastNewsArchive">اخبار و رويدادها</a> |&nbsp;
                    </div>
                    <div style="padding-top: 3px; float: right">
                        <a href="index.aspx?Type=LastLibraryArchive">کتابخانه</a>  |&nbsp;
                    </div>
                    <div style="padding-top: 3px; float: right">
                        <a href="index.aspx?Type=LastGalleryArchive">گالری تصاویر</a> |&nbsp;
                    </div>
                    <div style="padding-top: 3px; float: right">
                        <a href="index.aspx?Type=Call_US">تماس با ما</a> |&nbsp;
                    </div>
                    <div style="padding-top: 3px; float: right">
                        <a target="_blank" href="ChatRoom.aspx">گفتگو آنلاین</a>  <img src='images/chat.gif'/>&nbsp;|&nbsp;
                    </div>
                    <div style="float: right;">
                        <asp:PlaceHolder ID="PlaceHolder3" runat="server"></asp:PlaceHolder>
                    </div>
                </div>
            </div>
            <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        </div>
    </div>
    </form>
</body>
</html>
