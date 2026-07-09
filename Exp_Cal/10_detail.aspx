<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="10_detail.aspx.vb" Inherits="Exp_Cal.detail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="jp">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>マスタ一覧</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox1" style="text-align:center; margin-left: 0px;" runat="server" BackColor="#3333CC" Font-Bold="True" Font-Size="XX-Large" ForeColor="White" Height="36px" ReadOnly="True" Width="276px" >経費一覧</asp:TextBox>
            <br />
            <br />
            <asp:TextBox ID="TxtMSG" runat="server" ForeColor="Red" Height="21px" ReadOnly="True" style="margin-bottom: 0px" TextMode="MultiLine" Width="620px"></asp:TextBox>
            <br />
            <br /> 
            <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="Black" Text="社員番号：" style="margin-left:5px;"　></asp:Label>
            <asp:TextBox ID="Txt_syain_cd" runat="server" Width="55px" Height="20px" Font-Bold="True" ForeColor="#0066FF" ReadOnly="True" Style="margin-left:5px; text-align:center;"></asp:TextBox>
            <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Black" Text="氏　名：" style="margin-left:50px;"　></asp:Label>
            <asp:TextBox ID="Txt_Syain_name" runat="server" Width="140px" Height="20px" Font-Bold="True " style="margin-left: 5px;" TabIndex="1" ForeColor="#0066FF" ReadOnly="True" ></asp:TextBox>
        </div>
        <br />
        <div>
            <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="Black" Text="使用日" style="margin-left:25px;"　></asp:Label>
            <asp:Label ID="Label5" runat="server" Font-Bold="True" ForeColor="Black" Text="内　容" style="margin-left:140px;"　></asp:Label>
            <asp:Label ID="Label6" runat="server" Font-Bold="True" ForeColor="Black" Text="金　額" style="margin-left:150px;"　></asp:Label>
            <asp:Label ID="Label7" runat="server" Font-Bold="True" ForeColor="Black" Text="振込日" style="margin-left:50px;"　></asp:Label>
            <br /> 
            <asp:TextBox ID="Txt_sday" runat="server" Width="95px" Height="20px" Font-Bold="True " style="margin-left: 0px;" TabIndex="2" ></asp:TextBox>
            <asp:TextBox ID="Txt_content" runat="server" Width="270px" Height="20px" Font-Bold="True " style="margin-left:0px;" TabIndex="3" ></asp:TextBox>
            <asp:TextBox ID="Txt_amount" runat="server" Width="95px" Height="20px" Font-Bold="True " style="margin-left: 0px; text-align:right;" TabIndex="4"></asp:TextBox>
            <asp:TextBox ID="Txt_fday" runat="server" Width="95px" Height="20px" Font-Bold="True " style="margin-left: 0px;" TabIndex="5" ></asp:TextBox>
            <asp:Button ID="But_Add" runat="server" Height="33px" Text="登録" Width="60px" BackColor="#009900" ForeColor="White" style="margin-left:50px;" TabIndex="6" /> 
        </div>
        <br />
         <div style="overflow-y: scroll; height: 400px; Width: 665px; margin-left: 0px;">
            <table>
                <tr>
                    <td align="left" valign="middle" class="auto-style1" >
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  Width="640px" OnRowDeleting="GridView1_RowDeleting" >
                        <AlternatingRowStyle BackColor="White" />  
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    
                        <Columns>
                            <asp:BoundField DataField="s_date" HeaderText="使用日" > 
                                <ItemStyle Width="100px"/>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="content" HeaderText="内　容" > 
                                <ItemStyle Width="300px"/>
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="amount" HeaderText="金　額" > 
                                <ItemStyle Width="100px"/>
                                <ItemStyle HorizontalAlign="Right" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="f_date" HeaderText="振込日" > 
                                <ItemStyle Width="100px"/>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="mail_um" HeaderText="メール" > 
                                <ItemStyle Width="70px"/>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="削除">
                                 <ItemStyle Width="50px" HorizontalAlign="Center" />
                                <HeaderStyle Width="40px" HorizontalAlign="Center" />
                                <ItemTemplate>
                                    <asp:LinkButton ID="btnDelete"
                                        runat="server"
                                        CommandName="Delete"
                                        Text="削除"
                                        OnClientClick="return confirm('削除しますか？');">
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                           <%-- </asp:TemplateField>
                            <asp:ButtonField CommandName="Delete" Text="削除">
                                <ItemStyle Width="50px" HorizontalAlign="Center" />
                                <HeaderStyle Width="40px" HorizontalAlign="Center" />
                            </asp:ButtonField>--%>

                            
                        </Columns>
                    </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <asp:Button ID="But_Mail" runat="server" Height="33px" Text="メール送信" Width="99px" BackColor="#009900" ForeColor="White" style="margin-left:200px;" TabIndex="7" /> 
        <asp:Button ID="But_End" runat="server" Height="33px" Text="戻る" Width="67px" BackColor="#009900" ForeColor="White" style="margin-left:250px;" /> 
    </form>

</body>
</html>

