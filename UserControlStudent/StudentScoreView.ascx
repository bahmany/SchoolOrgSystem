<%@ Control Language="C#" AutoEventWireup="true" CodeFile="StudentScoreView.ascx.cs" Inherits="UserControlPublic_AdminInformationAdd" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
        <div class="PanelContainerBig">
            <div class="PanelContainerTopBig">
            </div>
            <div class="PanelContainerBodyBig">
                <span class="PanelContainerBodySpanBig" style="margin-bottom: 20px;">مشاهده نمرات</span>
                <div style="margin-right: 30px; margin-left: 30px;">
                    <span class="SpanHelp">در این قسمت میتوانید نمرات مربوط به دروس خود را مشاهده نمایید 
                        نمایید : </span>
                    <br />
                    <br />
                </div>
                <div style="margin-right: 100px;">
                    <span class="SpanNormal">نام درس :</span>
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                        Visible="False" CssClass="DropDownListNormal">
                    </asp:DropDownList>
                </div>
              
               
                
                <br />
                <div style="margin-right: 20px;">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        CssClass="Grid" GridLines="None" OnPageIndexChanging="GridView1_PageIndexChanging">
                        <RowStyle CssClass="GridRow" />
                        <EmptyDataRowStyle CssClass="GridEmpty" />
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1%>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="عنوان آزمون">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("ScoreTitle_ID") %>' Visible="False"></asp:Label>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("StTitle").ToString() %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="نوع آزمون">
                                <ItemTemplate>
                                   
                                    <asp:Label ID="Labeltype" runat="server" Text='<%# Eval("StType").ToString().Replace("continuous", "مستمر").Replace("Final", "پایانی") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                           
                    <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="نمره">
                                <ItemTemplate>
                                   
                                    <asp:Label ID="Labelscore" runat="server" Text='<%# Eval("Sc_score")%>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle Width="30px" HorizontalAlign="Center" />
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
                    <br>
                    
                </div>
            </div>
        </div>
</ContentTemplate>
</asp:UpdatePanel>