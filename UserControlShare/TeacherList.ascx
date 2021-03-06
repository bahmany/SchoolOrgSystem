﻿<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TeacherList.ascx.cs"
    Inherits="UserControlPublic_AdminInformationAdd" %>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div class="PanelContainerBig">
    <div class="PanelContainerTopBig">
    </div>
    <div class="PanelContainerBodyBig">
        <span class="PanelContainerBodySpanBig" style="margin-bottom: 20px;">لیست معلم ها</span>
        <div style="margin-right: 30px; margin-left: 30px;">
            <span class="SpanHelp">در این قسمت میتوانید لیست معلم هارا مشاهده نمایید :
            </span>
            <br />
            <br />
         
        </div>
    
      
        <div style="margin-right: 20px;">
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                CssClass="Grid" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging"
                PageSize="10">
                <RowStyle CssClass="GridRow" />
                <EmptyDataRowStyle CssClass="GridEmpty" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="نام و نام خانوادگی">
                        <ItemTemplate>
                          
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("TI_Name").ToString() %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="نام کاربری">
                        <ItemTemplate>
                          
                            <asp:Label ID="Labeluser" runat="server" Text='<%# Eval("TI_Username").ToString() %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="مشخصات" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                             <a href='<%# "./Index.aspx?Type=TeacherDetail&ID_Teacher="+ Eval("Teacher_ID").ToString()%>'>
                               <asp:Image ID="Image1" ImageUrl="~/Images/vcard.png" runat="server" /></a>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="70px"/>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ارسال پیام" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate >
                             <a href='<%# "./Index.aspx?Type=PersonalMessageInsert&Type_Role_Getter=Teacher&ID_Role_Getter="+ Eval("Teacher_ID").ToString()%>'> 
                              <asp:Image ID="Image1" ImageUrl="~/Images/email_add.png" runat="server" /></a>
                        </ItemTemplate>
                         <ItemStyle HorizontalAlign="Center" Width="70px"/>
                    </asp:TemplateField>
                </Columns>
                <PagerStyle CssClass="GridPaging" />
                <EmptyDataTemplate>
                    <asp:Label ID="Label1" runat="server" Text="اطلاعات کاربری ای به ثبت نرسیده است"></asp:Label>
                </EmptyDataTemplate>
                <HeaderStyle CssClass="GridHeader" />
                <AlternatingRowStyle CssClass="GridRowAlternating" />
                <SelectedRowStyle BackColor="Gray" />
            </asp:GridView>
        </div>
    </div>
</div>
<asp:HiddenField ID="HiddenField1" runat="server" />
</ContentTemplate>
</asp:UpdatePanel>