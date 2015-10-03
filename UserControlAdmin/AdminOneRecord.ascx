<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AdminOneRecord.ascx.cs"
    Inherits="UserControlPublic_AdminInformationAdd" %>
<%@ Register Assembly="FredCK.FCKeditorV2" Namespace="FredCK.FCKeditorV2" TagPrefix="FCKeditorV2" %>


<div class="PanelContainerBig">
    <div class="PanelContainerTopBig">
    </div>
    <div class="PanelContainerBodyBig">
        <span class="PanelContainerBodySpanBig" style="margin-bottom: 20px;">مدیریت متون سایت</asp:Label></span>
        <div style="margin-right: 20px; margin-left: 10px;">
            <span class="SpanHelp">شما در این بخش میتوانید متن مورد نظر برای بخش انتخابی را مدیریت نمایید :
            </span>
            <br />
            <br />
            
                <asp:Panel ID="Panel1" Font-Size="8pt" runat="server" GroupingText="<B>مسیر جاری</B>"
                    Width="540px">
                    <div class="PanelStyle">
                        <asp:Label ID="lblPath" runat="server"></asp:Label>
                    </div>
                </asp:Panel>
        
          
        </div>
         <br />
          <br />
        <div style="margin-right: 0px;">
            <span class="SpanNormal">عنوان :</span><asp:TextBox CssClass="TextBoxNormal" ID="TextTitle"
                runat="server" Width="420px"></asp:TextBox>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Register" ControlToValidate="TextTitle" runat="server"
             ErrorMessage="اجباری"></asp:RequiredFieldValidator>
            <br />
       
         <br />
        <span class="SpanNormal">متن :</span>
         </div>
        <br />
        <br />
        <div style="margin-right: 30px;">
            <FCKeditorV2:FCKeditor ID="FCKeditor1" Width="530" Height="400" runat="server" BasePath="~/fckeditor/">
            </FCKeditorV2:FCKeditor>
        </div>
        <br />
        <div style="margin-right: 100px;">
            <br />
        </div>
        <br />
        <div style="margin-right: 220px;">
            <asp:Button ID="Button1" runat="server" Text="ثبت" ValidationGroup="Register" CssClass="ButtonNormal"
                OnClick="Button1_Click" />
            &nbsp;<asp:Button ID="Button2" runat="server" CssClass="ButtonNormal" OnClick="Button2_Click"
                Text="انصراف" />
            <br />
            <br />
             <div style="margin-right: 0px;">
                    <asp:Label ID="Label1" CssClass="LabelButton" Visible="false" runat="server" Text="اطلاعات به ثبت رسید"></asp:Label>
                </div>
            <br />
        </div>
    </div>
</div>
