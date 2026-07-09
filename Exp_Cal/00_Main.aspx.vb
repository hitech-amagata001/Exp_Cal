Imports System.Reflection.Emit

Public Class Main
    Inherits System.Web.UI.Page

    Dim Test_flg As Boolean = False

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            If User.Identity.IsAuthenticated Then
                Dim userName As String = User.Identity.Name
                If AD_Get(1, Mid(User.Identity.Name, 13, Len(User.Identity.Name))) = True Then
                    LblName.Text = displayName
                End If
            Else
                If AD_Get(0, Mid(User.Identity.Name, 13, Len(User.Identity.Name))) = True Then
                    LblName.Text = displayName
                End If
            End If


            If Test_flg = True Then
                'Response.End()
                ClientScript.RegisterStartupScript(
                Me.GetType(),
                "err",
                "alert('権限がありません。');location.href='Err_Gamen.aspx';",
                True
                )

                Return

            End If

            BindGridView()

        End If
    End Sub

    'データ表示
    Private Sub BindGridView()

        Dim dt As New DataTable

        dt.Columns.Add("syain_cd")
        dt.Columns.Add("syain_name")
        dt.Columns.Add("Bank_Name")
        dt.Columns.Add("Bank_branch")
        dt.Columns.Add("Bank_yokin")
        dt.Columns.Add("Bank_account")

        dt.Rows.Add("024", "吉山　誠一", "●●銀行", "▲▲支店", "普通", "0123456")
        dt.Rows.Add("041", "安井　和幸", "●●銀行", "▲▲支店", "普通", "0123457")
        dt.Rows.Add("044", "安川　徳一", "●●銀行", "▲▲支店", "普通", "0123458")
        dt.Rows.Add("046", "村松　茂幸", "●●銀行", "▲▲支店", "普通", "0123459")
        dt.Rows.Add("050", "大村　康二", "●●銀行", "▲▲支店", "普通", "0123460")
        dt.Rows.Add("054", "中村　光男", "●●銀行", "▲▲支店", "普通", "0123461")
        dt.Rows.Add("086", "佐野　昌彦", "●●銀行", "▲▲支店", "普通", "0123462")
        dt.Rows.Add("102", "鵜飼　裕典", "●●銀行", "▲▲支店", "普通", "0123463")
        dt.Rows.Add("104", "佐藤　喜彦", "●●銀行", "▲▲支店", "普通", "0123464")
        dt.Rows.Add("121", "割鞘　浩二", "●●銀行", "▲▲支店", "普通", "0123465")
        dt.Rows.Add("129", "鈴木　宏光", "●●銀行", "▲▲支店", "普通", "0123466")
        dt.Rows.Add("150", "浅野　国宏", "●●銀行", "▲▲支店", "普通", "0123467")
        dt.Rows.Add("151", "小島　久仁彦", "●●銀行", "▲▲支店", "普通", "0123468")
        dt.Rows.Add("152", "鈴木　利孝", "●●銀行", "▲▲支店", "普通", "0123469")
        dt.Rows.Add("154", "宮木　一", "●●銀行", "▲▲支店", "普通", "0123470")
        dt.Rows.Add("161", "花井　孝人", "●●銀行", "▲▲支店", "普通", "0123471")
        dt.Rows.Add("173", "古橋　孝晃", "●●銀行", "▲▲支店", "普通", "0123472")
        dt.Rows.Add("175", "荒井　武史", "●●銀行", "▲▲支店", "普通", "0123473")
        dt.Rows.Add("177", "大高　久典", "●●銀行", "▲▲支店", "普通", "0123474")
        dt.Rows.Add("178", "斎藤　平治", "●●銀行", "▲▲支店", "普通", "0123475")
        dt.Rows.Add("180", "瀧口　典", "●●銀行", "▲▲支店", "普通", "0123476")
        dt.Rows.Add("182", "坪井　雅史", "●●銀行", "▲▲支店", "普通", "0123477")
        dt.Rows.Add("184", "松本　吉央", "●●銀行", "▲▲支店", "普通", "0123478")

        GridView1.DataSource = dt
        GridView1.DataBind()
    End Sub

    '選択
    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        TxtMSG.Text = ""
        Dim syainCd As String
        Dim syainName As String

        syainCd = GridView1.SelectedRow.Cells(1).Text
        syainName = GridView1.SelectedRow.Cells(2).Text

        Response.Redirect(
            "10_detail.aspx?syain_cd=" &
            Server.UrlEncode(syainCd) &
            "&syain_name=" &
            Server.UrlEncode(syainName)
        )

    End Sub
End Class