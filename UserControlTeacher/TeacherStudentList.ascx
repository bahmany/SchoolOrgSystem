<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TeacherStudentList.ascx.cs"
    Inherits="UserControlPublic_AdminInformationAdd" %>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div class="PanelContainerBig">
    <div class="PanelContainerTopBig">

    </div>
    <div class="PanelContainerBodyBig">
        <span class="PanelContainerBodySpanBig" style="margin-bottom: 20px;">لیست دانش آموزان</span>
        <div style="margin-right: 30px; margin-left: 30px;">
            <span class="SpanHelp">در این قسمت میتوانید لیست دانش آموزان مربوط به خود را مشاهده نمایید :
            </span>
            <br />
            <br />
         
        </div>
        <div style="margin-right: 100px;">
       <span class="SpanNormal">لیست دروس :</span> 
            <asp:DropDownList ID="DropDownList1" 
                runat="server" AppendDataBoundItems="True" AutoPostBack="True" 
                onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                Visible="False" CssClass="DropDownListNormal">
        </asp:DropDownList>
         </div>
         
            <br /><div style="margin-right: 10px;">
                        <asp:Panel ID="Panel2" Font-Size="8pt" runat="server" GroupingText="<B>مسیر جاری</B>"
                Width="540px">
                <div class="PanelStyle">
                    <asp:Label ID="lblPath" runat="server"></asp:Label>
                </div>
            </asp:Panel></div>
            <br />
       
        <div style="margin-right: 20px;">
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                CssClass="Grid" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging"
                OnRowDeleting="GridView1_RowDeleting" OnRowEditing="GridView1_RowEditing" PageSize="10">
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
                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("Student_ID") %>' Visible="False"></asp:Label>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("SI_Name").ToString() %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="نام کاربری">
                        <ItemTemplate>
                          
                            <asp:Label ID="Labeluser" runat="server" Text='<%# Eval("SI_Username").ToString() %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="مشخصات" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                             <a href='<%# "./Index.aspx?Type=StudentDetail&ID_Student="+ Eval("Student_ID").ToString()%>'>
                               <asp:Image ID="Image1" ImageUrl="~/Images/vcard.png" runat="server" /></a>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="70px"/>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ارسال پیام" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate >
                             <a href='<%# "./Index.aspx?Type=PersonalMessageInsert&Type_Role_Getter=Student&ID_Role_Getter="+ Eval("Student_ID").ToString()%>'> 
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
</ContentTemplate>
</asp:UpdatePanel>