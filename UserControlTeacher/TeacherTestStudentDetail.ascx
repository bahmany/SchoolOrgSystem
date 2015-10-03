<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TeacherTestStudentDetail.ascx.cs"
    Inherits="UserControlPublic_AdminInformationAdd" %>
<div class="PanelContainerBig">
    <div class="PanelContainerTopBig">
    </div>
    <div class="PanelContainerBodyBig">
        <span class="PanelContainerBodySpanBig" style="margin-bottom: 20px;"><%= lblTestTitle %></span>
        

      
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
            
             <div style="margin-right: 30px;">
                    <asp:Panel ID="Panel3" Font-Size="8pt" runat="server" GroupingText="<B>مسیر جاری</B>"
                        Width="540px">
                        <div class="PanelStyle">
                            <asp:Label ID="lblPath" runat="server"></asp:Label>
                        </div>
                    </asp:Panel>
                </div>
                <br />
            
                           <asp:Panel ID="Panel1"  runat="server">
                    <div style="margin-right: 0px;">
                        <span class="SpanNormal">نام دانش آموز :</span>
                        <asp:Label ID="lblName" Style="font-weight: bold; padding-top: 5px; float: right"
                            runat="server" Text=""></asp:Label>
                        <br />
                        <br />
                        
                        <span class="SpanNormal">نمره امتحان :</span>
                        <asp:TextBox CssClass="TextBoxNormal" style="border:solid 1px black;width:50px;text-align:center" ID="txtScoreAllTest" runat="server"></asp:TextBox>
                        &nbsp;<asp:Button ID="Button1" runat="server" CssClass="ButtonNormal" OnClick="Button3_Click"
                            Text="ثبت" ValidationGroup="Register" />
                         <br />
                        <br />
                    </div>
                  
                   
                        
                       
                        
                    
                </asp:Panel>
               
            
                <div style="margin-right: 20px;">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CssClass="Grid"
                        GridLines="None" OnRowEditing="GridView1_RowEditing" 
                        onrowdatabound="GridView1_RowDataBound" >
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
                           
                            <asp:TemplateField>
                                <ItemTemplate>
                                <asp:HiddenField ID="hiddenType" Value='<%# Eval("tq_type").ToString() %>' runat="server" />
                                <asp:HiddenField ID="hiddenTitle" Value='<%# Eval("tq_title").ToString() %>' runat="server" />
                                <asp:HiddenField ID="hiddenAnswerWrite" Value='<%# Eval("tq_Answer").ToString() %>' runat="server" />
                                <asp:HiddenField ID="hiddenAnswerStudent" Value="" runat="server" />
                                <asp:HiddenField ID="hiddenScore" Value="" runat="server" />
                                    <asp:LinkButton CommandName="Edit" ForeColor="Blue" ID="LinkButton1" runat="server">مشاهده پاسخ</asp:LinkButton>
                                </ItemTemplate>
                                <ItemStyle CssClass="GridItemButton" Width="80px" />
                            </asp:TemplateField>
                             <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="نمره">
                                <ItemTemplate>
                                    <asp:Label ID="lbl_MarkStudent" runat="server" Text=""></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        <PagerStyle CssClass="GridPaging" />
                        <EmptyDataTemplate>
                            <asp:Label ID="Label1" runat="server" Text="اطلاعاتی به ثبت نرسیده است"></asp:Label>
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
                        <span class="SpanNormal">پاسخ صحیح :</span>
                        <asp:Label ID="lblAnswerWrite" Style="font-weight: bold; padding-top: 5px; float: right"
                            runat="server" Text=""></asp:Label>
                        <br />
                        <br />
                       
                            <span class="SpanNormal">پاسخ دانش آموز :</span>
                            <asp:Label ID="lblAnswerStudent" Style="font-weight: bold; padding-top: 5px; float: right"
                            runat="server" Text=""></asp:Label>
                         <br />
                        <br />
                        <span class="SpanNormal">نمره سوال :</span>
                        <asp:TextBox CssClass="TextBoxNormal" style="border:solid 1px black;width:50px;text-align:center" ID="TextBox1" runat="server"></asp:TextBox>
                         <br />
                        <br />
                    </div>
                    <br />
                    <div style="margin-right: 220px;">
                        &nbsp;<asp:Button ID="Button3" runat="server" CssClass="ButtonNormal" OnClick="Button1_Click"
                            Text="ثبت" ValidationGroup="Register" />
                        &nbsp;<asp:Button ID="Button2" runat="server" CssClass="ButtonNormal" OnClick="Button2_Click"
                            Text="انصراف" />
                        
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
