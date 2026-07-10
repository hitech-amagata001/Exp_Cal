<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="20_User_List.aspx.vb" Inherits="Exp_Cal.User_List" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="jp">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>経費一覧</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox1" style="text-align:center; margin-left: 0px;" runat="server" BackColor="#3333CC" Font-Bold="True" Font-Size="XX-Large" ForeColor="White" Height="37px" ReadOnly="True" Width="638px" >経費一覧</asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="Black" Text="氏　名：" style="margin-left:10px;"　></asp:Label>
            <asp:TextBox ID="Txt_Syain_name" runat="server" Width="140px" Height="20px" Font-Bold="True " style="margin-left: 5px;" TabIndex="1" ForeColor="#0066FF" ReadOnly="True" ></asp:TextBox>
        </div>
        <br />
         <div style="overflow-y: scroll; height: 400px; Width: 670px; margin-left: 0px;">
            <table>
                <tr>
                    <td align="left" valign="middle" class="auto-style1" >
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  Width="640px">
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
                            
                        </Columns>
                    </asp:GridView>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
