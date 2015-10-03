<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ParentList.ascx.cs"
    Inherits="UserControlPublic_AdminInformationAdd" %>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div class="PanelContainerBig">
    <div class="PanelContainerTopBig">

    </div>
    <div class="PanelContainerBodyBig">
        <span class="PanelContainerBodySpanBig" style="margin-bottom: 20px;">لیست اولیاء</span>
        <div style="margin-right: 30px; margin-left: 30px;">
            <span class="SpanHelp">در این قسمت میتوانید لیست اولیاء را مشاهده نمایید :
            </span>
            <br />
            <br />
       
        </div>
        <div style="margin-right: 100px;">
       <span class="SpanNormal">بخش اول</span>  <asp:DropDownList ID="DropDownList1" 
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
                            <asp:Label ID="lblID" runat="server" Text='<%# Eval("Parent_ID") %>' Visible="False"></asp:Label>
                            <asp:Label ID="Label3" runat="server" Text='<%# Eval("PA_Name").ToString() %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="نام کاربری">
                        <ItemTemplate>
                          
                            <asp:Label ID="Labeluser" runat="server" Text='<%# Eval("PA_Username").ToString() %>'></asp:Label>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="مشخصات" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate>
                             <a href='<%# "./Index.aspx?Type=ParentDetail&ID_Parent="+ Eval("Parent_ID").ToString()%>'>
                               <asp:Image ID="Image1" ImageUrl="~/Images/vcard.png" runat="server" /></a>
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Center" Width="70px"/>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ارسال پیام" HeaderStyle-HorizontalAlign="Center">
                        <ItemTemplate >
                             <a href='<%# "./Index.aspx?Type=PersonalMessageInsert&Type_Role_Getter=Parent&ID_Role_Getter="+ Eval("Parent_ID").ToString()%>'> 
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