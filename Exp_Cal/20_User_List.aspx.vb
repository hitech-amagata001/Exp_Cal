Imports System.Data.SqlClient

Public Class User_List
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            If User.Identity.IsAuthenticated Then
                Dim userName As String = User.Identity.Name
                If AD_Get(1, Mid(User.Identity.Name, 13, Len(User.Identity.Name))) = True Then
                    Txt_Syain_name.Text = displayName
                End If
            Else
                If AD_Get(0, Mid(User.Identity.Name, 13, Len(User.Identity.Name))) = True Then
                    Txt_Syain_name.Text = displayName
                End If
            End If

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

        dt.Rows.Add("2026/07/10", "文具一式", "330", "2026/07/15")
        dt.Rows.Add("2026/07/07", "健康診断費用", "3,500", "2026/07/15")


        ViewState("DT") = dt

        GridView1.DataSource = dt
        GridView1.DataBind()
    End Sub

End Class