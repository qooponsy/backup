Imports System.Data.SqlClient
Imports System.Text

''' <summary>
''' S_BulkMailテーブルへの接続クラス
''' </summary>
Public Class S_BulkMail
    'テーブルデータ格納用変数
    Public BulkMailID As Integer
    Public MailCode As String
    Public Year As String
    Public Month As String
    Public Status As String

    Public Class MailCodeSetting
        Public Const REQ_CARFARE_MAIL As Integer = 1    '交通費記載依頼メール
        Public Const UN_COMP_MAIL As Integer = 2        '未記載報告メール
        Public Const ERROR_MAIL As Integer = 9          'エラー通知メール
    End Class

    Public Class StatusCode
        Public Const UN_SEND As Integer = 0     '未送信
        Public Const SEND As Integer = 1        '送信済み
    End Class

    Public Shared Function GetBulkMailList(ByRef bulkMailList As List(Of S_BulkMail)) As Boolean
        Dim result As Boolean
        Try
            Using con As New SqlConnection(My.Settings.DB)
                con.Open()
                'SQL実行処理
                Using cmd As SqlCommand = con.CreateCommand
                    Dim Sql As New StringBuilder
                    'SQL文作成
                    Sql.AppendLine("SELECT")
                    Sql.AppendLine("	BulkMailID, MailCode, Year, Month, Status")
                    Sql.AppendLine("FROM")
                    Sql.AppendLine("	S_BulkMail")
                    Sql.AppendLine("WHERE")
                    Sql.AppendLine("	Status = @Status")

                    cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = StatusCode.UN_SEND

                    cmd.CommandText = Sql.ToString()
                    '読み込みの開始
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim bulkMailData As New S_BulkMail
                            bulkMailData.BulkMailID = reader("BulkMailID")
                            bulkMailData.MailCode = reader("MailCode")
                            bulkMailData.Year = reader("Year")
                            bulkMailData.Month = reader("Month")
                            bulkMailData.Status = reader("Status")

                            bulkMailList.Add(bulkMailData)
                        End While
                        If bulkMailList.Count > 0 Then
                            result = True
                        End If

                    End Using '読み込みの開始

                End Using 'SQL処理の終了

            End Using 'SQLコマンド終了

        Catch ex As Exception
            LogWrite.ErrorLog(ex)
            result = False
        End Try

        Return result
    End Function

    Public Shared Function UpdateBulkMailSendStatus(ByVal bulkMailID As Integer)
        Dim result As Boolean = False

        Try
            Using con As New SqlConnection(My.Settings.DB)
                con.Open()
                'SQL実行処理
                Using cmd As SqlCommand = con.CreateCommand
                    Dim Sql As New StringBuilder
                    Sql.AppendLine("update S_BulkMail set Status = @Status")
                    Sql.AppendLine("where BulkMailID = @BulkMailID")

                    cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = StatusCode.SEND
                    cmd.Parameters.Add("@BulkMailID", SqlDbType.Int).Value = bulkMailID
                    cmd.CommandText = Sql.ToString()

                    cmd.ExecuteNonQuery()

                End Using
            End Using

            result = True
        Catch ex As Exception
            LogWrite.ErrorLog(ex)
            result = False
        End Try

        Return result
    End Function

End Class
