Imports System.Data.SqlClient
Imports System.Text

Public Class S_Session
    'テーブルデータ格納用変数


    Public Shared Function GetBulkMailList(ByRef bulkMailList As List(Of S_BulkMail)) As Boolean
        Dim result As Boolean
        Try
            Using con As New SqlConnection(My.Settings.DB)
                con.Open()
                'SQL実行処理
                Using cmd As SqlCommand = con.CreateCommand
                    Dim Sql As New StringBuilder
                    'SQL文作成
                    Sql.AppendLine("")

                    cmd.CommandText = Sql.ToString()
                    '読み込みの開始
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then

                            result = True
                        Else
                            result = False
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


End Class
