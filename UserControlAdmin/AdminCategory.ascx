<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminCategory.ascx.cs"
    Inherits="UserControlPublic_AdminInformationAdd" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div class="PanelContainerBig">
    <div class="PanelContainerTopBig">
    </div>
    <div class="PanelContainerBodyBig">
        <span class="PanelContainerBodySpanBig" style="margin-bottom: 20px;">مدیریت بخش ها</span>
        <div style="margin-right: 30px;margin-left:30px;">
             <span class="SpanHelp" >در این قسمت برای بخش بندی پایه های درسی و شاخه ها و کلاس های مربوط به مدرسه میتوانید اقدام نمایید . 
             <br /><br />
                          توجه داشته باشید که در صورت حذف یک بخش تمامی مطالب مرتبط با آن بخش نیز حذف می شوند . پس ابتدا مطالب مرتبط را در نظر گرفته و سپس بخش مورد نظر را حذف نمایید: </span>
        <br /><br />
        </div>
        <div style="margin-right:95px;">
        <span class="SpanNormal">عنوان</span><asp:TextBox ID="TextTitle" CssClass="TextBoxNormal"  runat="server"
            MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextTitle"  Font-Names="Tahoma"
                            Font-Size="8pt" ErrorMessage="*" ValidationGroup="Register"></asp:RequiredFieldValidator>
            
            
        <asp:Button ID="Button1" CssClass="ButtonNormal"  ValidationGroup="Register" runat="server" Text="ثبت" OnClick="Button1_Click" />
        </div>
         <div style="margin-right:20px;">
        <asp:Label ID="LblHidden" runat="server"></asp:Label>
        <p>
            <asp:Label ID="lblError" runat="server" ForeColor="Red" Text="این بخش شامل محتویاتی است که ابتدا باید آنها پاک شوند."
                Visible="False"></asp:Label>
        </p>
       
        <p>
            <asp:Panel ID="Panel1" Font-Size="8pt" runat="server" GroupingText="<B>مسیر جاری</B>"
                    Width="550px">
                    <div class="PanelStyle">
                        <asp:Label ID="lblPath" runat="server"></asp:Label>
                    </div>
                </asp:Panel>
        </p>
        <br />
       
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            CssClass="Grid" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging"
            OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting"
            OnRowEditing="GridView1_RowEditing" PageSize="50">
            <Columns>
                <asp:TemplateField HeaderText="عنوان">
                    <ItemTemplate>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~//Index.aspx?Type=AdminCategory&ID_Root="+Eval("Category_ID").ToString() %>'
                            Text='<%# Eval("Cat_Title") %>'></asp:HyperLink>
                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("Category_ID") %>' Visible="False"></asp:Label>
                         <asp:Label ID="lblPath" runat="server" Text='<%# Eval("Cat_Path") %>' Visible="False"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="FieldInputOneLine" MaxLength="50"
                            Text='<%# Eval("Cat_Title") %>'></asp:TextBox>
                        <asp:Label ID="lblID0" runat="server" Text='<%# Eval("Category_ID") %>' Visible="False"></asp:Label>
                    </EditItemTemplate>
                    <ItemStyle CssClass="GridItemNormal" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Delete" ImageUrl="~/Images/delete.gif"
                            OnClientClick="return confirm('آیا از این کار اطمینان دارید؟');" ToolTip="حذف" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:ImageButton ID="ImageButton3" runat="server" CommandName="Cancel" ImageUrl="~/Images/undo.gif"
                            ToolTip="انصراف" />
                    </EditItemTemplate>
                    <ItemStyle CssClass="GridItemButton" />
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:ImageButton ID="ImageButton2" runat="server" CommandName="Edit" ImageUrl="~/Images/edit.gif"
                            ToolTip="ویرایش" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:ImageButton ID="ImageButton4" runat="server" CommandName="Update" ImageUrl="~/Images/save.gif"
                            ToolTip="ذخیره تغییرات" />
                    </EditItemTemplate>
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