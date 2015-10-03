<%@ Control Language="C#" AutoEventWireup="true" CodeFile="StudentTestView.ascx.cs" Inherits="UserControlPublic_AdminInformationAdd" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <div class="PanelContainerBig">
            <div class="PanelContainerTopBig">
            </div>
            <div class="PanelContainerBodyBig">
                <span class="PanelContainerBodySpanBig" style="margin-bottom: 20px;"> آزمون آنلاین</span>
                <div style="margin-right: 30px; margin-left: 30px;">
                    <span class="SpanHelp">در این قسمت میتوانید آزمون های آنلاین را مشاهده و شرکت نمایید :
                    </span>
                    <br />
                    <br />
                </div>
                <br />
                 <div style="margin-right: 100px;">
                    <span class="SpanNormal">نام درس :</span>
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"
                        Visible="False" CssClass="DropDownListNormal">
                    </asp:DropDownList>
                </div>
              
               
                
                <br />
                <div style="margin-right: 20px;">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                        CssClass="Grid" GridLines="None" 
                        OnPageIndexChanging="GridView1_PageIndexChanging" 
                        onrowdatabound="GridView1_RowDataBound">
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
                                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID_Test") %>' Visible="False"></asp:Label>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Eval("t_Title").ToString() %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="زمان برگزاری">
                                <ItemTemplate>
                                    <asp:Label ID="Label213" runat="server"  Text='<%# Eval("ds").ToString() %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" CssClass="LTRRow"/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="زمان پایان">
                                <ItemTemplate>
                                    <asp:Label ID="Label3213" runat="server"  Text='<%# Eval("de").ToString() %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" CssClass="LTRRow"/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="وضعیت">
                                <ItemTemplate>
                                    <asp:HiddenField ID="HiddenField1" Value='<%# Eval("position").ToString() %>' runat="server" />
                                    <asp:Label ID="Label2213" runat="server" 
                                    Text='<%# Eval("position").ToString().Replace("DarhalBargozari","در حال برگزاری").Replace("BargozarShode","برگزار شده").Replace("BargozarNashode","برگزار نشده") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField >
                                <ItemTemplate >
                                    
                                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl='<%# "~/index.aspx?Type=StudentTestQuestionView&ID_Test=" + Eval("ID_Test").ToString() %>'>شرکت در آزمون</asp:HyperLink>
                                     
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderStyle-HorizontalAlign="Center" HeaderText="نمره">
                                <ItemTemplate>
                                    <asp:Label ID="lblScore" runat="server" Text=""></asp:Label>
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
                        <SelectedRowStyle BackColor="Gray" />
                    </asp:GridView>
                    <br>
                </div>
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
