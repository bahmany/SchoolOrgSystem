<%@ Control Language="C#" AutoEventWireup="true" CodeFile="LessonManage.ascx.cs"
    Inherits="UserControlPublic_AdminInformationAdd" %>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div class="PanelContainerBig">
    <div class="PanelContainerTopBig">

    </div>
    <div class="PanelContainerBodyBig">
        <span class="PanelContainerBodySpanBig" style="margin-bottom: 20px;">مدیریت دروس</span>
        <div style="margin-right: 30px; margin-left: 30px;">
            <span class="SpanHelp">در این قسمت میتوانید دروس را مدیریت را نمایید :
            </span>
            <br />
            <br />
         
        </div>
        <div style="margin-right: 100px;">
       <span class="SpanNormal">بخش اول :</span>  <asp:DropDownList ID="DropDownList1" 
                runat="server" AppendDataBoundItems="True" AutoPostBack="True" 
                onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
                Visible="False" CssClass="DropDownListNormal">
        </asp:DropDownList><br />
        <span class="SpanNormal">بخش دوم :</span><asp:DropDownList ID="DropDownList2" 
                runat="server" AppendDataBoundItems="True" AutoPostBack="True" 
                onselectedindexchanged="DropDownList2_SelectedIndexChanged" 
                Visible="False" CssClass="DropDownListNormal">
        </asp:DropDownList><br />
        <span class="SpanNormal">بخش سوم :</span><asp:DropDownList ID="DropDownList3" 
                runat="server" AppendDataBoundItems="True" AutoPostBack="True" 
                onselectedindexchanged="DropDownList3_SelectedIndexChanged" 
                Visible="False" CssClass="DropDownListNormal">
        </asp:DropDownList><br />
       <span class="SpanNormal">بخش چهارم :</span> <asp:DropDownList ID="DropDownList4" 
                runat="server" AppendDataBoundItems="True" AutoPostBack="True" 
                onselectedindexchanged="DropDownList4_SelectedIndexChanged" 
                Visible="False" CssClass="DropDownListNormal">
        </asp:DropDownList><br />
        <span class="SpanNormal">بخش پنجم :</span><asp:DropDownList ID="DropDownList5" 
                runat="server" AppendDataBoundItems="True" AutoPostBack="True" 
                onselectedindexchanged="DropDownList5_SelectedIndexChanged" 
                Visible="False" CssClass="DropDownListNormal">
        </asp:DropDownList><br />
       <span class="SpanNormal">بخش ششم :</span> <asp:DropDownList ID="DropDownList6" 
                runat="server" AppendDataBoundItems="True" AutoPostBack="True" 
                onselectedindexchanged="DropDownList6_SelectedIndexChanged" 
                Visible="False" CssClass="DropDownListNormal">
        </asp:DropDownList>
            <br />
            <br />
        </div>
        <div style="margin-right: 20px;">
            <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                CssClass="Grid" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging"
                OnRowDeleting="GridView1_RowDeleting"  PageSize="10">
                <RowStyle CssClass="GridRow" />
                <EmptyDataRowStyle CssClass="GridEmpty" />
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1%>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="نام درس">
                        <ItemTemplate>
                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("Lesson_ID") %>' Visible="False"></asp:Label>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("Les_Name").ToString() %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="تعداد واحد">
                        <ItemTemplate>
                            
                            <asp:Label ID="Labelunit" runat="server" Text='<%# Eval("Les_Unit").ToString() %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    
                     <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="نام کاربری استاد">
                        <ItemTemplate>
                            
                            <asp:Label ID="Labelusername" runat="server" Text='<%# Eval("TI_UserName").ToString() %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                                         <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="نام استاد">
                        <ItemTemplate>
                            
                            <asp:Label ID="Labelname" runat="server" Text='<%# Eval("TI_Name").ToString() %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Delete" ImageUrl="~/Images/delete.gif"
                                OnClientClick="return confirm('آیا از این کار اطمینان دارید؟');" ToolTip="حذف" />
                        </ItemTemplate>
                        <ItemStyle CssClass="GridItemButton" />
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                          <a href='<%# "./Index.aspx?Type=LessonEdit&Lesson_ID="+ Eval("Lesson_ID").ToString()%>'>  <asp:Image ID="Image1" ImageUrl="~/Images/edit.gif" runat="server" /></a>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <PagerStyle CssClass="GridPaging" />
                <EmptyDataTemplate>
                    <asp:Label ID="Label1" runat="server" Text="اطلاعاتی به ثبت نرسیده است"></asp:Label>
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