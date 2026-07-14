Imports System.Data.Common
Imports System.Net.Mail
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices
Imports System.Web.Mail
Imports System.Web.Services.Discovery
Imports System.Windows.Forms
Imports Microsoft.VisualBasic.FileIO

Public Class detail
    Inherits System.Web.UI.Page
    'Dim Mnt_low As Integer = 0
    'フォームロード
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            Dim syainCd As String =
            Request.QueryString("syain_cd")

            Dim syainName As String =
            Request.QueryString("syain_name")

            Txt_syain_cd.Text = syainCd
            Txt_Syain_name.Text = syainName

            Txt_sday.Attributes("type") = "date"
            Txt_fday.Attributes("type") = "date"
            Txt_sdayM.Attributes("type") = "date"
            Txt_fdayM.Attributes("type") = "date"

            BindGridView()

        End If
    End Sub

    'データ表示
    Private Sub BindGridView()

        Dim dt As New DataTable

        dt.Columns.Add("s_date")
        dt.Columns.Add("content")
        dt.Columns.Add("amount")
        dt.Columns.Add("f_date")
        dt.Columns.Add("mail_um")

        If Txt_syain_cd.Text = "024" Then
            dt.Rows.Add("2026/07/10", "文具一式", "330", "2026/07/15", "")
            dt.Rows.Add("2026/07/07", "健康診断費用", "3,500", "2026/07/15", "")
            dt.Rows.Add("2026/07/03", "会議費用", "2,000", "2026/07/15", "")
            dt.Rows.Add("2026/07/02", "昼食代", "500", "2026/07/15", "済")
            dt.Rows.Add("2026/07/01", "交通費", "1,000", "2026/07/15", "済")
            dt.Rows.Add("2026/07/01", "交通費", "1,000", "2026/07/15", "済")
            dt.Rows.Add("2026/07/01", "昼食代", "1,000", "2026/07/15", "済")
            dt.Rows.Add("2026/07/01", "交通費", "1,000", "2026/07/15", "済")
            dt.Rows.Add("2026/07/01", "交通費", "1,000", "2026/07/15", "済")
            dt.Rows.Add("2026/07/01", "昼食代", "1,000", "2026/07/15", "済")
            dt.Rows.Add("2026/07/01", "交通費", "1,000", "2026/07/15", "済")
            dt.Rows.Add("2026/07/01", "昼食代", "1,000", "2026/07/15", "済")
            dt.Rows.Add("2026/07/01", "交通費", "1,000", "2026/07/15", "済")
            dt.Rows.Add("2026/07/01", "昼食代", "1,000", "2026/07/15", "済")
            dt.Rows.Add("2026/07/01", "交通費", "1,000", "2026/07/15", "済")
            dt.Rows.Add("2026/07/01", "昼食代", "1,000", "2026/07/15", "済")
            dt.Rows.Add("2026/07/01", "交通費", "1,000", "2026/07/15", "済")
        Else
            dt.Rows.Add("2026/07/10", "文具一式", "330", "2026/07/15")
            dt.Rows.Add("2026/07/03", "会議費用", "2,000", "2026/07/15")
            dt.Rows.Add("2026/07/02", "昼食代", "500", "2026/07/15", "済")
            dt.Rows.Add("2026/07/01", "交通費", "1,000", "2026/07/15", "済")

        End If

        ViewState("DT") = dt

        GridView1.DataSource = dt
        GridView1.DataBind()
    End Sub

    '閉じる
    Protected Sub But_End_Click(sender As Object, e As EventArgs) Handles But_End.Click
        Response.Redirect("00_Main.aspx")
    End Sub

    '登録ボタン
    Protected Sub But_Add_Click(sender As Object, e As EventArgs) Handles But_Add.Click
        Dim sday As Date
        Dim fday As Date

        If Txt_sday.Text <> "" Then
            sday = Txt_sday.Text
        End If
        If Txt_fday.Text <> "" Then
            fday = Txt_fday.Text
        End If


        Dim dt As DataTable =
            CType(ViewState("DT"), DataTable)

        Dim dr As DataRow = dt.NewRow()

        dr("s_date") = Format(sday, "yyyy/MM/dd")
        dr("content") = Txt_content.Text
        dr("amount") = Val(Replace(Txt_amount.Text, ",", "")).ToString("#,##0")
        dr("f_date") = IIf(Txt_fday.Text = "", "", Format(fday, "yyyy/MM/dd"))

        dt.Rows.InsertAt(dr, 0)

        ViewState("DT") = dt

        GridView1.DataSource = dt
        GridView1.DataBind()

    End Sub

    '削除
    Protected Sub GridView1_RowDeleting(sender As Object, e As GridViewDeleteEventArgs) Handles GridView1.RowDeleting
        TxtMSG.Text = ""

        Dim dt As DataTable =
        CType(ViewState("DT"), DataTable)

        dt.Rows.RemoveAt(e.RowIndex)

        ViewState("DT") = dt

        GridView1.DataSource = dt
        GridView1.DataBind()

        TxtMSG.Height = "20"
        TxtMSG.ForeColor = System.Drawing.Color.Blue
        TxtMSG.Text = "削除しました。"
        TxtMSG.Focus()
    End Sub

    '選択
    Protected Sub GridView1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles GridView1.SelectedIndexChanged
        TxtMSG.Text = ""

        'Mnt_low = GridView1.SelectedIndex

        Dim dt As DateTime

        If DateTime.TryParse(GridView1.SelectedRow.Cells(1).Text, dt) Then
            Txt_sdayM.Text = dt.ToString("yyyy-MM-dd")
        End If
        Txt_contentM.Text = GridView1.SelectedRow.Cells(2).Text
        Txt_amountM.Text = Replace(GridView1.SelectedRow.Cells(3).Text, ",", "")
        If DateTime.TryParse(GridView1.SelectedRow.Cells(4).Text, dt) Then
            Txt_fdayM.Text = dt.ToString("yyyy-MM-dd")
        End If

    End Sub

    '編集ボタン
    Protected Sub But_Mnt_Click(sender As Object, e As EventArgs) Handles But_Mnt.Click
        Dim rowIndex As Integer = GridView1.SelectedIndex

        Dim sday As Date
        Dim fday As Date

        If Txt_sdayM.Text <> "" Then
            sday = Txt_sdayM.Text
        End If
        If Txt_fdayM.Text <> "" Then
            fday = Txt_fdayM.Text
        End If


        Dim dt As DataTable =
            CType(ViewState("DT"), DataTable)

        Dim dr As DataRow = dt.NewRow()

        dt.Rows(rowIndex)("s_date") = Format(sday, "yyyy/MM/dd")
        dt.Rows(rowIndex)("content") = Txt_contentM.Text
        dt.Rows(rowIndex)("amount") = Val(Replace(Txt_amountM.Text, ",", "")).ToString("#,##0")
        dt.Rows(rowIndex)("f_date") = IIf(Txt_fdayM.Text = "", "", Format(fday, "yyyy/MM/dd"))

        GridView1.DataSource = dt
        GridView1.DataBind()

        Session("dt") = dt
    End Sub
End Class