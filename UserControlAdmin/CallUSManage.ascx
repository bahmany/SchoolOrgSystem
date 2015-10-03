<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CallUSManage.ascx.cs"
    Inherits="UserControlPublic_AdminInformationAdd" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div class="PanelContainerBig">
    <div class="PanelContainerTopBig">
    </div>
    <div class="PanelContainerBodyBig">
        <span class="PanelContainerBodySpanBig" style="margin-bottom: 20px;">مدیریت تماس با ما</span>
        <div style="margin-right: 30px;margin-left:30px;">
             <span class="SpanHelp" >در این قسمت میتوانید پیغام های دریافتی را مدیریت نمایید  : </span>
        <br /><br />
        </div>
       
                            
         <div style="margin-right:20px;">
        <asp:Label ID="LblHidden" runat="server"></asp:Label>
       

        <br />
       
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            CssClass="Grid" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging"
             OnRowDeleting="GridView1_RowDeleting"
             PageSize="50">
            <Columns>
                <asp:TemplateField HeaderText="عنوان" HeaderStyle-HorizontalAlign=Center>
                    <ItemTemplate>
                        <a  href='<%# "index.aspx?Type=CallUSDetail&CallUS_ID="+ Eval("Call_US_ID").ToString() %>' >
                        <asp:Label  ID="Label2" runat="server" Text='<%# Eval("cu_Title") %>'></asp:Label>
                        </a>
                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("Call_US_ID") %>' Visible="False"></asp:Label>
                    </ItemTemplate>
                    <ItemStyle  HorizontalAlign="Center"/>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="نام نویسنده" HeaderStyle-HorizontalAlign=Center>
                    <ItemTemplate>
                        <asp:Label  ID="Label222" runat="server" Text='<%# Eval("cu_name") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle  HorizontalAlign="Center"/>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="تاریخ ثبت" HeaderStyle-HorizontalAlign=Center>
                    <ItemTemplate>
                        <asp:Label  ID="Label112" runat="server" Text='<%# Eval("cu_date") %>'></asp:Label>
                    </ItemTemplate>
                    <ItemStyle  HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="مشاهده شده" HeaderStyle-HorizontalAlign=Center>
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckBox1" Enabled=false Checked='<%# bool.Parse(Eval("cu_Visit").ToString()) %>'  runat="server" />
                    </ItemTemplate>
                    <ItemStyle  HorizontalAlign="Center" Width=100/>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Delete" ImageUrl="~/Images/delete.gif"
                            OnClientClick="return confirm('آیا از این کار اطمینان دارید؟');" ToolTip="حذف" />
                    </ItemTemplate>
                    
                    <ItemStyle CssClass="GridItemButton" />
                </asp:TemplateField>
                
            </Columns>
            <EmptyDataTemplate>
                <asp:Label ID="Label1" runat="server" Text="مطلبی به ثبت نرسیده است"></asp:Label>
            </EmptyDataTemplate>
            <EmptyDataRowStyle CssClass="GridEmpty" />
            <AlternatingRowStyle CssClass="GridRowAlternating" />
            <RowStyle CssClass="GridRow" />
            <HeaderStyle CssClass="GridHeader" />
            <PagerStyle CssClass="GridPaging" />
            <EditRowStyle BorderWidth="0px" CssClass="GridEditing" />
        </asp:GridView>
        </div>
    </div>
</div>
</ContentTemplate>
</asp:UpdatePanel>