<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminTeacherLinkInsertEdit.ascx.cs"
    Inherits="UserControlPublic_AdminInformationAdd" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>
<div class="PanelContainerBig">
    <div class="PanelContainerTopBig">
    </div>
    <div class="PanelContainerBodyBig">
        <span class="PanelContainerBodySpanBig" style="margin-bottom: 20px;">
            <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></span>
        <div style="margin-right: 30px; margin-left: 30px;">
            <span class="SpanHelp">
                <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
            </span>
            <br />
            <br />
            <asp:Panel ID="Panel1" Font-Size="8pt" Visible=false runat="server" GroupingText="<B>مسیر جاری</B>"
                Width="540px">
                <div class="PanelStyle">
                    <asp:Label ID="lblPath" runat="server"></asp:Label>
                </div>
            </asp:Panel>
            <br />
           
        </div>
        <div style="margin-right: 100px;">
            
                    <div runat="server" id="Panel2" visible="false">
                        <span class="SpanNormal">توسط :</span> <span class="SpanNormalShow">
                            <%=AuthorContent%></span>
                        
                    </div>
                    <br />
                    <br />
                    
                    <span class="SpanNormal">بخش اول</span>
                    <asp:DropDownList ID="DropDownList1" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                        OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Visible="False" CssClass="DropDownListNormal">
                    </asp:DropDownList>
                    <br />
                    <span class="SpanNormal">بخش دوم :</span><asp:DropDownList ID="DropDownList2" runat="server"
                        AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"
                        Visible="False" CssClass="DropDownListNormal">
                    </asp:DropDownList>
                    <br />
                    <span class="SpanNormal">بخش سوم :</span><asp:DropDownList ID="DropDownList3" runat="server"
                        AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged"
                        Visible="False" CssClass="DropDownListNormal">
                    </asp:DropDownList>
                    <br />
                    <span class="SpanNormal">بخش چهارم :</span>
                    <asp:DropDownList ID="DropDownList4" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                        OnSelectedIndexChanged="DropDownList4_SelectedIndexChanged" Visible="False" CssClass="DropDownListNormal">
                    </asp:DropDownList>
                    <br />
                    <span class="SpanNormal">بخش پنجم :</span><asp:DropDownList ID="DropDownList5" runat="server"
                        AppendDataBoundItems="True" AutoPostBack="True" OnSelectedIndexChanged="DropDownList5_SelectedIndexChanged"
                        Visible="False" CssClass="DropDownListNormal">
                    </asp:DropDownList>
                    <br />
                    <span class="SpanNormal">بخش ششم :</span>
                    <asp:DropDownList ID="DropDownList6" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                        OnSelectedIndexChanged="DropDownList6_SelectedIndexChanged" Visible="False" CssClass="DropDownListNormal">
                    </asp:DropDownList>
                    <br />
               <br />
            <span class="SpanNormal">عنوان :</span><asp:TextBox CssClass="TextBoxNormal" ID="TextTitle"
                runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFiesslssdValidator1" ValidationGroup="Register"
                ControlToValidate="TextTitle" runat="server" ErrorMessage="اجباری"></asp:RequiredFieldValidator>
               
               <br />
                <span class="SpanNormal">لینک :</span><asp:TextBox CssClass="TextBoxNormal" ID="txtLink"
                runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequirasaasedFieldValidator1" ValidationGroup="Register"
                ControlToValidate="txtLink" runat="server" ErrorMessage="اجباری"></asp:RequiredFieldValidator>
                
            <asp:Label ID="LblHidden" runat="server"></asp:Label>
            <br />
        </div>
       
        <br />
       
        <div style="margin-right: 260px;">
            <br />
            <asp:CheckBox ID="CheckBox1" runat="server" Text="تایید" Visible="False" />
            <br />
        </div>
        <br />
        <div style="margin-right: 220px;">
            <asp:Button ID="Button1" runat="server" Text="ثبت" ValidationGroup="Register" CssClass="ButtonNormal"
                OnClick="Button1_Click" />
            &nbsp;<asp:Button ID="Button3" runat="server" CssClass="ButtonNormal" OnClick="Button1_Click"
                Text="ویرایش" ValidationGroup="Register" Visible="false" />
            &nbsp;<asp:Button ID="Button2" runat="server" CssClass="ButtonNormal" OnClick="Button2_Click"
                Text="انصراف" />
            <br />
            <br />
            <br />
        </div>
       
    </div>
</div>
<asp:HiddenField ID="HiddenField1" runat="server" />
