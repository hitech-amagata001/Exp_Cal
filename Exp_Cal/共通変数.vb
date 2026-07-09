Imports System.Data.SqlClient
Module 共通変数
    Public cn As SqlConnection                        'sql接続コネクション
    Public cmd As SqlCommand                          'sqlコマンド
    Public dr As SqlDataReader                        'sqlレコードセット

    Public Const Ver As String = "Ver.1.0.00"

    Public Const SERVERX As String = "192.168.10.211"      'テスト
    'Public Const SERVERX As String = "192.168.10.212"      'テスト
    'Public Const SERVERX As String = "LSD211V"      'テスト
    'Public Const SERVERX As String = "LSD212V"      '本番
    Public Const DATABASE As String = "HR_DB"
    Public Const UID As String = "sa"
    Public Const PWD As String = "Amagata2024"

    Public displayName As String     '漢字姓名
    Public samAccountName As String  'ログインユーザ名
    Public email As String           'email

End Module
