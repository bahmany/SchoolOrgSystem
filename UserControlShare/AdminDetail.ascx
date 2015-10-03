<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminDetail.ascx.cs" Inherits="UserControlPublic_AdminInformationAdd" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class="PanelContainerBig">
            <div class="PanelContainerTopBig">
            </div>
            <div class="PanelContainerBodyBig">
                <span class="PanelContainerBodySpanBig" style="margin-bottom: 20px;">مشاهده مشخصات فردی
                    مدیر</span>
                <div style="margin-right: 30px; margin-left: 30px;">
                    <span class="SpanHelp">در این قسمت میتوانید مشخصات فردی کاربر مورد نظر خود را مشاهده
                        نمایید : </span>
                    <br />
                    <br />
                    <asp:Panel ID="Panel1" Font-Size="8pt" runat="server" GroupingText="<B>مسیر جاری</B>"
                        Width="540px">
                        <div class="PanelStyle">
                            <asp:Label ID="lblPath" runat="server"></asp:Label>
                        </div>
                    </asp:Panel>
                    <br />
                    <br />
                </div>
                <div style="margin-right: 70px; float: right; width: 300px">
                    <span class="SpanNormal">نام و نام خانوادگی :</span> <span class="SpanNormalShow">
                        <%=TextName%></span>
                    <br />
                    <br />
                   
                    <span class="SpanNormal">نام کاربری :</span> <span class="SpanNormalShow">
                        <%=TextUserName%></span>
                    <br />
                    <br />
                    
                    
                    <span class="SpanNormal">سمت :</span> <span class="SpanNormalShow">
                        <%=TextRoll%></span>
                    <br />
                    <br />
                    <span class="SpanNormal">تاریخ عضویت :</span> <span class="SpanNormalShow">
                        <%=TextStartTime%></span>
                    <br />
                    <br />
                    <span class="SpanNormal">آخرین بازدید :</span> <span class="SpanNormalShow">
                        <%=TextEndTime%></span>
                    <br />
                    <br />
                    
                </div>
                <div style="margin-right: 20px; float: right; width: 100px; margin-top: 5px;">
                    <asp:Image ID="Image1" runat="server" BorderColor="Black" BorderStyle="Solid" BorderWidth="1px"
                        Height="100px" Width="100px" />
                    <span style="text-align: center; width: 100px; float: right; margin-top: 20px;">
                        <%=Message %>
                    </span>
                </div>
                <br />
                <br />
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
