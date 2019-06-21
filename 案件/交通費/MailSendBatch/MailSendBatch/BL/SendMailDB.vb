Imports System.Data.SqlClient
Imports System.Text

''' <summary>
''' DB接続処理のクラス
''' </summary>
Public Class SendMailDB

    'テーブルデータ格納用変数
    Dim lastName As String
    Dim firstName As String
    Dim mail As String
    Dim folderName As String
    Dim year As String
    Dim month As String

    Public Shared Function GetMailData(ByRef sendMailDataList As List(Of SendMailDB)) As Boolean
        Dim result As Boolean = False
        Try
            Using con As New SqlConnection(My.Settings.DB)
                con.Open()
                'SQL実行処理
                Using cmd As SqlCommand = con.CreateCommand
                    Dim Sql As New StringBuilder

                    'SQL文作成
                    Sql.AppendLine("SELECT w.[LastName], w.[FirstName], w.[Mail], w.[FolderName], c.[Year], c.[Month]")
                    Sql.AppendLine(" FROM [T_Carfare] AS c ")
                    Sql.AppendLine(" LEFT OUTER JOIN [M_Worker] AS w ON c.[WorkerID] = w.[WorkerID]")
                    Sql.AppendLine(" WHERE c.Status = 1")
                    Sql.AppendLine(" ORDER BY c.[Year], c.[Month]")

                    cmd.CommandText = Sql.ToString()

                    '読み込みの開始
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()

                            Dim obj As New SendMailDB
                            obj.lastName = reader("LastName")
                            obj.firstName = reader("FirstName")
                            obj.mail = reader("Mail")
                            obj.folderName = reader("FolderName")
                            obj.year = reader("Year")
                            obj.month = reader("Month")


                            sendMailDataList.Add(obj)

                        End While
                        result = True

                    End Using '読み込みの終了

                End Using 'SQL処理終了

            End Using 'SQLコマンド終了

        Catch ex As Exception
            LogWrite.ErrorLog(ex)
            result = False

        End Try


        Return result
    End Function

End Class
