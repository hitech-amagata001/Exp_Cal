Imports System.Data.SqlClient
Imports System.DirectoryServices
Imports System.IO

Module 共通関数
    'DB オープン
    Public Sub DB_OPEN()
        cn = New SqlConnection("Data Source=" & SERVERX & ";Initial Catalog=" & DATABASE & ";User ID=" & UID & ";Password=" & PWD)

        cn.Open()

    End Sub

    'DB クローズ
    Public Sub DB_CLOSE()

        cn.Close()
        cn = Nothing

    End Sub

    'テーブルセレクト
    '　引数1：SQL文
    '  戻り値：レコードセット
    Function Teble_Select(ByVal s1 As String) As SqlDataReader


        cmd = New SqlCommand(s1, cn)

        'On Error GoTo Err_Teble_Select

        ' ExcecuteReaderメソッドでDataReaderを作成

        Teble_Select = cmd.ExecuteReader()

        Exit Function

Err_Teble_Select:
        'Response.Redirect("予期せぬエラーが発生しました。(テーブルセレクト)")
        DB_CLOSE()
    End Function

    ' Active Directoryから取得
    'Function AD_Get(s1 As String) As Boolean
    Function AD_Get(s0 As Integer, s1 As String) As Boolean
        ' Active Directoryへの接続文字列を設定する
        Dim ldapPath As String = "LDAP://amagata-net.local" ' あなたのドメインに置き換える
        ' DirectoryEntryオブジェクトを作成し、Active Directoryに接続する
        Dim entry As New DirectoryEntry(ldapPath)

        ' DirectorySearcherオブジェクトを作成し、検索条件を設定する
        Dim searcher As New DirectorySearcher(entry)

        If s0 = 0 Then
            searcher.Filter = "(&(objectClass=user)(samAccountName=" & System.Environment.UserName & "))" ' ユーザー名を指定
        Else
            searcher.Filter = "(&(objectClass=user)(samAccountName=" & s1 & "))" ' ユーザー名を指定
        End If

        '

        ' 検索を実行し、検索結果を取得する
        Dim result As SearchResult = searcher.FindOne()

        ' ユーザーが見つかった場合、属性を取得する
        displayName = result.Properties("displayName")(0).ToString()          '漢字姓名
        samAccountName = result.Properties("samAccountName")(0).ToString()    'ログインユーザ名
        email = result.Properties("mail")(0).ToString()                       'email

        AD_Get = True

    End Function

    'NULL処理(文字列)
    Function FuncIsNull(ByVal s1 As Object, Optional ByVal s2 As Object = "")
        '引数：S1＞対象文字列、S2＞変換文字列
        '    If IsNull(s1) Then FuncIsNull2 = s2 Else FuncIsNull2 = s1
        FuncIsNull = IIf(IsDBNull(s1), s2, s1)
    End Function

    'NULL処理(数字）
    Function FuncIsNullC(ByVal s1 As Object, Optional ByVal s2 As Object = 0)
        '引数：S1＞対象文字列、S2＞変換文字列
        '    If IsNull(s1) Then FuncIsNull2 = s2 Else FuncIsNull2 = s1
        FuncIsNullC = IIf(IsDBNull(s1), s2, s1)
    End Function

    '社員情報（基本）登録確認
    '　引数1：s1=社員コード
    '  戻り値：社員名
    Function SYAIN_GET(s1 As String) As String
        SYAIN_GET = ""
        Dim cn1 As SqlConnection                        'sql接続コネクション
        Dim cmd1 As SqlCommand                          'sqlコマンド
        Dim dr1 As SqlDataReader

        Dim sqlstr As String

        sqlstr = "SELECT * FROM SYAIN_BASIC Where syain_cd='" & s1 & "'"
        Try
            cn1 = New SqlConnection("Data Source=" & SERVERX & ";Initial Catalog=" & DATABASE & ";User ID=" & UID & ";Password=" & PWD)
            cn1.Open()

            cmd1 = New SqlCommand(sqlstr, cn1)

            dr1 = cmd1.ExecuteReader()

            While dr1.Read()
                SYAIN_GET = FuncIsNull(dr1("sur_name")) & " " & FuncIsNull(dr1("given_name"))
            End While
            dr1.Close()
            dr1 = Nothing

            cn1.Close()
            cn1 = Nothing

        Catch ex As Exception
            SYAIN_GET = ""
        End Try


    End Function

End Module
