<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="00_Main.aspx.vb" Inherits="Exp_Cal.Main" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="jp">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>マスタ一覧</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:TextBox ID="TextBox1" style="text-align:center; margin-left: 0px;" runat="server" BackColor="#3333CC" Font-Bold="True" Font-Size="XX-Large" ForeColor="White" Height="36px" ReadOnly="True" Width="276px" >社員マスタ一覧</asp:TextBox>
            <asp:Label ID="LblName" runat="server" Text="Label" ForeColor="Blue" style="margin-left:10px;" ></asp:Label>
            <br />
            <br />
            <asp:TextBox ID="TxtMSG" runat="server" ForeColor="Red" Height="21px" ReadOnly="True" style="margin-bottom: 0px" TextMode="MultiLine" Width="800px"></asp:TextBox>
            <br />
            <br /> 
        </div>
        <div style="overflow-y: scroll; height: 400px; Width: 840px; margin-left: 0px;">
            <table>
                <tr>
                    <td align="left" valign="middle" class="auto-style1" >
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="800px" >
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
                            <asp:CommandField ShowSelectButton="True">
                                <ItemStyle Width="50px" />
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:CommandField>
                            <asp:BoundField DataField="syain_cd" HeaderText="社員No" > 
                                <ItemStyle Width="60px"/>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="syain_name" HeaderText="氏名" > 
                                <ItemStyle Width="200px"/>
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Bank_Name" HeaderText="振込先銀行名" > 
                                <ItemStyle Width="400px"/>
                            </asp:BoundField>
                            <asp:BoundField DataField="Bank_branch" HeaderText="支店名" > 
                                <ItemStyle Width="200px"/>
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Bank_yokin" HeaderText="預金" > 
                                <ItemStyle Width="100px"/>
                                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Bank_account" HeaderText="口座No" > 
                                <ItemStyle Width="200px"/>
                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                            </asp:BoundField>
<%--                            <asp:ButtonField CommandName="Delete" Text="削除">
                                <ItemStyle Width="50px" HorizontalAlign="Center" />
                                <HeaderStyle Width="40px" HorizontalAlign="Center" />
                            </asp:ButtonField>--%>

                            
                        </Columns>
                    </asp:GridView>
                    </td>
                </tr>

            </table>
        </div>
        <div>
            <br />
            <br />
            <asp:Label ID="Label3" runat="server" Text="※マスタメンテする場合は、下記より、【CSV出力】して編集後、【CSV取込】をしてください。" Font-Bold="True" ForeColor="#0066FF"></asp:Label>
             <p>
                <asp:Button ID="Button1" runat="server" Height="33px" Text="CSV出力" Width="102px" BackColor="#009900" ForeColor="White" style="margin-left:100px;" /> 
                <asp:Label ID="Label2" runat="server" Text="　　　　"></asp:Label>
                <asp:FileUpload ID="FileUpload1" runat="server" />
                <asp:Button ID="Button5" runat="server" Height="33px" Text="CSV取込" Width="102px" BackColor="#009900" ForeColor="White" style="margin-left:100px;" /> 
            </p>
        </div>
        
    </form>

</body>
</html>
