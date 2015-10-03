<%@ Control Language="C#" AutoEventWireup="true" CodeFile="StudentTestQuestionView.ascx.cs"
    Inherits="UserControlPublic_AdminInformationAdd" %>
<div class="PanelContainerBig">
    <div class="PanelContainerTopBig">
    </div>
    <div class="PanelContainerBodyBig">
        <span class="PanelContainerBodySpanBig" style="margin-bottom: 20px;"><%= lblTestTitle %></span>
        
            <asp:UpdatePanel ID="UpdatePanel2" runat="server" >
                <ContentTemplate>
                <div style="margin-right: 220px;" >
            
                   
                    زمان باقیمانده : <asp:Label ID="lblTime" Style="font-weight: bold;" runat="server" Text="0"></asp:Label> &nbsp;ثانیه
                  
                         </div>
                        
                    <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick">
                    </asp:Timer>
                </ContentTemplate>
            </asp:UpdatePanel>
       
     
      
        <br /><br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div style="margin-right: 20px;">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="Grid"
                        GridLines="None" OnRowEditing="GridView1_RowEditing" OnRowDataBound="GridView1_RowDataBound">
                        <RowStyle CssClass="GridRow" />
                        <EmptyDataRowStyle CssClass="GridEmpty" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 + " - "%>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="20" VerticalAlign="Top" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="متن سوال">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("TestQuestion_ID") %>' Visible="False"></asp:Label>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("tq_Title").ToString() %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="نوع سوال">
                                <ItemTemplate>
                                    <asp:Label ID="lblType" runat="server" Text='<%# Eval("tq_Type").ToString().Replace("Testi","تستی").Replace("Tashrihi","تشریحی") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="بارم">
                                <ItemTemplate>
                                    <asp:Label ID="lbltq_Mark" runat="server" Text='<%# Eval("tq_Mark").ToString() %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="نمره منفی">
                                <ItemTemplate>
                                    <asp:Label ID="lbltq_Minus_Mark" runat="server" Text='<%# Eval("tq_Minus_Mark").ToString() %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="پاسخ داده">
                                <ItemTemplate>
                                    <asp:CheckBox Enabled="false" ID="CheckBox1" runat="server" />
                                    <asp:HiddenField ID="hiddenAnswer" Value="" runat="server" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton CommandName="Edit" ForeColor="Blue" ID="LinkButton1" runat="server">مشاهده سوال</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle CssClass="GridItemButton" Width="80px" />
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle CssClass="GridPaging" />
                        <EmptyDataTemplate>
                            <asp:Label ID="Label1" runat="server" Text="سوالی طرح نشده است"></asp:Label>
                        </EmptyDataTemplate>
                        <HeaderStyle CssClass="GridHeader" />
                        <AlternatingRowStyle CssClass="GridRowAlternating" />
                        <SelectedRowStyle BackColor="#cccccc" />
                    </asp:GridView>
                </div>
                <br />
                <asp:Panel ID="Panel2" Visible="false" runat="server">
                    <div style="margin-right: 0px;">
                        <span class="SpanNormal">متن سوال :</span>
                        <asp:Label ID="TextTitle" Style="font-weight: bold; padding-top: 5px; float: right"
                            runat="server" Text=""></asp:Label>
                        <br />
                        <br />
                        <asp:Panel ID="Panel1" runat="server">
                            <span class="SpanNormal">گزینه الف :</span>
                            <asp:RadioButton ID="TextA" GroupName="Test"  Style="font-weight: bold;
                                padding-top: 4px; float: right" runat="server" />
                            <br />
                            <br />
                            <span class="SpanNormal">گزینه ب :</span>
                            <asp:RadioButton ID="TextB" GroupName="Test" Style="font-weight: bold; padding-top: 4px;
                                float: right" runat="server" />
                            <br />
                            <br />
                            <span class="SpanNormal">گزینه ج :</span>
                            <asp:RadioButton ID="TextC" GroupName="Test" Style="font-weight: bold; padding-top: 4px;
                                float: right" runat="server" />
                            <br />
                            <br />
                            <span class="SpanNormal">گزینه د :</span>
                            <asp:RadioButton ID="TextD" GroupName="Test" Style="font-weight: bold; padding-top: 4px;
                                float: right" runat="server" />
                            <br />
                            <br />
                        </asp:Panel>
                        <asp:Panel ID="Panel3" Visible="false" runat="server">
                            <span class="SpanNormal">پاسخ شما :</span>
                            <asp:TextBox ID="TextAnswer" TextMode="MultiLine" Width="400" Height="100" CssClass="TextBoxNormal"
                                runat="server"></asp:TextBox>
                        </asp:Panel>
                    </div>
                    <br />
                    <div style="margin-right: 220px;">
                        &nbsp;<asp:Button ID="Button3" runat="server" CssClass="ButtonNormal" OnClick="Button1_Click"
                            Text="ثبت" ValidationGroup="Register" />
                        &nbsp;<asp:Button ID="Button2" runat="server" CssClass="ButtonNormal" OnClick="Button2_Click"
                            Text="انصراف" />&nbsp;
                        <asp:Button ID="Button4" runat="server" CssClass="ButtonNormal" OnClick="Button4_Click"
                            Text="حذف " />
                    </div>
                </asp:Panel>
                <br />
                <div style="margin-right: 210px;">
                    <asp:Label ID="Label1" CssClass="LabelButton" Visible="false" runat="server" Text=""></asp:Label>
                </div>
                <br />
                <br />
                <asp:Label ID="LblHidden" runat="server"></asp:Label>
                <asp:HiddenField ID="hiddenTypeQ" runat="server" />
                <asp:HiddenField ID="hiddenIDQ" runat="server" />
                <asp:HiddenField ID="HiddenAnwerState" runat="server" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</div>
