<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminTerm.ascx.cs"
    Inherits="UserControlPublic_AdminInformationAdd" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
<div class="PanelContainerBig">
    <div class="PanelContainerTopBig">
    </div>
    <div class="PanelContainerBodyBig">
        <span class="PanelContainerBodySpanBig" style="margin-bottom: 20px;">مدیریت ترم ها</span>
        <div style="margin-right: 30px;margin-left:30px;">
             <span class="SpanHelp" >در این قسمت ترم تحصیلی مربوط به مدرسه را میتوانید مدیریت کنید  : </span>
        <br /><br /><br /><br />
        </div>
        <div style="margin-right:95px; ">
        <span class="SpanNormal">عنوان</span><asp:TextBox ID="TextTitle" CssClass="TextBoxNormal"  runat="server"
            MaxLength="50"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextTitle"  Font-Names="Tahoma"
                            Font-Size="8pt" ErrorMessage="*" ValidationGroup="Register"></asp:RequiredFieldValidator>
                            <br /> <br />
                            </div>
                            <div style="margin-right:255px; ">
            <asp:CheckBox Text="فعال بودن" ID="CheckBox1" runat="server" />
          <br />   <br />
        <asp:Button ID="Button1" CssClass="ButtonNormal"  ValidationGroup="Register" runat="server" Text="ثبت" OnClick="Button1_Click" />
        </div>
         <div style="margin-right:20px;">
        <asp:Label ID="LblHidden" runat="server"></asp:Label>
       

        <br />
       
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
            CssClass="Grid" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging"
            OnRowDataBound="GridView1_RowDataBound" OnRowDeleting="GridView1_RowDeleting"
            OnRowEditing="GridView1_RowEditing" PageSize="50">
            <Columns>
                <asp:TemplateField HeaderText="عنوان">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("Te_Title") %>'></asp:Label>
                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("Term_ID") %>' Visible="False"></asp:Label>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" CssClass="FieldInputOneLine" MaxLength="50"
                            Text='<%# Eval("Te_Title") %>'></asp:TextBox>
                        <asp:Label ID="lblID0" runat="server" Text='<%# Eval("Term_ID") %>' Visible="False"></asp:Label>
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