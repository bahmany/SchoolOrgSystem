<%@ Control Language="C#" AutoEventWireup="true" CodeFile="GalleryInsertEdit.ascx.cs"
    Inherits="UserControlPublic_AdminInformationAdd" %>
<div class="PanelContainerBig" enableviewstate="true">
    <div class="PanelContainerTopBig">
    </div>
    <div class="PanelContainerBodyBig">
        <span class="PanelContainerBodySpanBig" style="margin-bottom: 20px;">ویرایش و ثبت گالری
            تصاویر </span>
        <div style="margin-right: 30px; margin-left: 30px;">
            <span class="SpanHelp">در این قسمت میتوانید گالری تصویری را ایجاد و یا ویرایش نمایید
                : </span>
            <br />
            <br />
            <asp:Panel ID="Panel1" Visible="false" Font-Size="8pt" runat="server" GroupingText="<B>مسیر جاری</B>"
                Width="540px">
                <div class="PanelStyle">
                    <asp:Label ID="lblPath" runat="server"></asp:Label>
                </div>
            </asp:Panel>
            <br />
            <br />
        </div>
        <div style="margin-right: 100px;">
            <span class="SpanNormal">بخش اول :</span>
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
            <span class="SpanNormal">عنوان موضوع گالری :</span><asp:TextBox CssClass="TextBoxNormal"
                ID="TextName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Register"
                ControlToValidate="TextName" runat="server" ErrorMessage="اجباری"></asp:RequiredFieldValidator>
            <asp:Label ID="LblHidden" runat="server"></asp:Label>
            <br />
            <br />
            <div style="margin-right: 100px;">
                <asp:CheckBox ID="CheckBox1" TextAlign="Left" runat="server" Text="تایید" Checked="true" />
            </div>
        </div>
        <br />
        <asp:Panel ID="Panel3" Style="margin-right: 20px;" Font-Size="8pt" runat="server"
            GroupingText="<B>تصاویر این موضوع</B>" Width="540px">
            <div class="PanelStyle" style="margin-right: 40px;">
                <span class="SpanNormal">عکس شماره 1 :</span>
                <asp:FileUpload ID="FileUpload1" runat="server"></asp:FileUpload>&nbsp;&nbsp;
                <asp:HyperLink Target="_blank" Visible="false" ID="HyperLink1" runat="server">مشاهده </asp:HyperLink>
                <asp:Image Visible="false" ID="Image1" runat="server" ImageUrl="~/images/Search_small.gif" />
                &nbsp;&nbsp;
                <asp:LinkButton CommandArgument="1" Visible="false" ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">حذف</asp:LinkButton>
                <asp:Image Visible="false" ID="Image2" runat="server" ImageUrl="~/images/delete_small.gif" />
                <br />
                <span class="SpanNormal">عکس شماره 2 :</span>
                <asp:FileUpload ID="FileUpload2" runat="server"></asp:FileUpload>&nbsp;&nbsp;
                <asp:HyperLink Target="_blank" Visible="false" ID="HyperLink2" runat="server">مشاهده </asp:HyperLink>
                <asp:Image Visible="false" ID="Image3" runat="server" ImageUrl="~/images/Search_small.gif" />
                &nbsp;&nbsp;
                <asp:LinkButton CommandArgument="2"  Visible="false" ID="LinkButton2" runat="server" OnClick="LinkButton1_Click">حذف</asp:LinkButton>
                <asp:Image Visible="false" ID="Image4" runat="server" ImageUrl="~/images/delete_small.gif" />
                <br />
                <span class="SpanNormal">عکس شماره 3 :</span>
                <asp:FileUpload ID="FileUpload3" runat="server"></asp:FileUpload>&nbsp;&nbsp;
                <asp:HyperLink Target="_blank" Visible="false" ID="HyperLink3" runat="server">مشاهده </asp:HyperLink>
                <asp:Image Visible="false" ID="Image5" runat="server" ImageUrl="~/images/Search_small.gif" />
                &nbsp;&nbsp;
                <asp:LinkButton CommandArgument="3"  Visible="false" ID="LinkButton3" runat="server" OnClick="LinkButton1_Click">حذف</asp:LinkButton>
                <asp:Image Visible="false" ID="Image6" runat="server" ImageUrl="~/images/delete_small.gif" />
                <br />
                <span class="SpanNormal">عکس شماره 4 :</span>
                <asp:FileUpload ID="FileUpload4" runat="server"></asp:FileUpload>&nbsp;&nbsp;
                <asp:HyperLink Target="_blank" Visible="false" ID="HyperLink4" runat="server">مشاهده </asp:HyperLink>
                <asp:Image Visible="false" ID="Image7" runat="server" ImageUrl="~/images/Search_small.gif" />
                &nbsp;&nbsp;
                <asp:LinkButton CommandArgument="4"  Visible="false" ID="LinkButton4" runat="server" OnClick="LinkButton1_Click">حذف</asp:LinkButton>
                <asp:Image Visible="false" ID="Image8" runat="server" ImageUrl="~/images/delete_small.gif" />
                <br />
                <span class="SpanNormal">عکس شماره 5 :</span>
                <asp:FileUpload ID="FileUpload5" runat="server"></asp:FileUpload>&nbsp;&nbsp;
                <asp:HyperLink Target="_blank" Visible="false" ID="HyperLink5" runat="server">مشاهده </asp:HyperLink>
                <asp:Image Visible="false" ID="Image9" runat="server" ImageUrl="~/images/Search_small.gif" />
                &nbsp;&nbsp;
                <asp:LinkButton CommandArgument="5"  Visible="false" ID="LinkButton5" runat="server" OnClick="LinkButton1_Click">حذف</asp:LinkButton>
                <asp:Image Visible="false" ID="Image10" runat="server" ImageUrl="~/images/delete_small.gif" />
                <br />
                <span class="SpanNormal">عکس شماره 6 :</span>
                <asp:FileUpload ID="FileUpload6" runat="server"></asp:FileUpload>&nbsp;&nbsp;
                <asp:HyperLink Target="_blank" Visible="false" ID="HyperLink6" runat="server">مشاهده </asp:HyperLink>
                <asp:Image Visible="false" ID="Image11" runat="server" ImageUrl="~/images/Search_small.gif" />
                &nbsp;&nbsp;
                <asp:LinkButton  CommandArgument="6" Visible="false" ID="LinkButton6" runat="server" OnClick="LinkButton1_Click">حذف</asp:LinkButton>
                <asp:Image Visible="false" ID="Image12" runat="server" ImageUrl="~/images/delete_small.gif" />
                <br />
                <span class="SpanNormal">عکس شماره 7 :</span>
                <asp:FileUpload ID="FileUpload7" runat="server"></asp:FileUpload>&nbsp;&nbsp;
                <asp:HyperLink Target="_blank" Visible="false" ID="HyperLink7" runat="server">مشاهده </asp:HyperLink>
                <asp:Image Visible="false" ID="Image13" runat="server" ImageUrl="~/images/Search_small.gif" />
                &nbsp;&nbsp;
                <asp:LinkButton CommandArgument="7"  Visible="false" ID="LinkButton7" runat="server" OnClick="LinkButton1_Click">حذف</asp:LinkButton>
                <asp:Image Visible="false" ID="Image14" runat="server" ImageUrl="~/images/delete_small.gif" />
                <br />
                <span class="SpanNormal">عکس شماره 8 :</span>
                <asp:FileUpload ID="FileUpload8" runat="server"></asp:FileUpload>&nbsp;&nbsp;
                <asp:HyperLink Target="_blank" Visible="false" ID="HyperLink8" runat="server">مشاهده </asp:HyperLink>
                <asp:Image Visible="false" ID="Image15" runat="server" ImageUrl="~/images/Search_small.gif" />
                &nbsp;&nbsp;
                <asp:LinkButton CommandArgument="8"  Visible="false" ID="LinkButton8" runat="server" OnClick="LinkButton1_Click">حذف</asp:LinkButton>
                <asp:Image Visible="false" ID="Image16" runat="server" ImageUrl="~/images/delete_small.gif" />
                <br />
                <span class="SpanNormal">عکس شماره 9 :</span>
                <asp:FileUpload ID="FileUpload9" runat="server"></asp:FileUpload>&nbsp;&nbsp;
                <asp:HyperLink Target="_blank" Visible="false" ID="HyperLink9" runat="server">مشاهده </asp:HyperLink>
                <asp:Image Visible="false" ID="Image17" runat="server" ImageUrl="~/images/Search_small.gif" />
                &nbsp;&nbsp;
                <asp:LinkButton CommandArgument="9"  Visible="false" ID="LinkButton9" runat="server" OnClick="LinkButton1_Click">حذف</asp:LinkButton>
                <asp:Image Visible="false" ID="Image18" runat="server" ImageUrl="~/images/delete_small.gif" />
                <br />
                <span class="SpanNormal">عکس شماره 10 :</span>
                <asp:FileUpload ID="FileUpload10" runat="server"></asp:FileUpload>&nbsp;&nbsp;
                <asp:HyperLink Target="_blank" Visible="false" ID="HyperLink10" runat="server">مشاهده </asp:HyperLink>
                <asp:Image Visible="false" ID="Image19" runat="server" ImageUrl="~/images/Search_small.gif" />
                &nbsp;&nbsp;
                <asp:LinkButton CommandArgument="10"  ID="LinkButton10" Visible="false" runat="server" OnClick="LinkButton1_Click">حذف</asp:LinkButton>
                <asp:Image Visible="false" ID="Image20" runat="server" ImageUrl="~/images/delete_small.gif" />
            </div>
        </asp:Panel>
        <asp:HiddenField ID="HiddenField1" Value="0" runat="server" />
        <br />
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
        </div>
    </div>
</div>
