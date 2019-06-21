Imports System.Data.SqlClient
Imports System.Text

''' <summary>
''' M_Workerテーブル接続クラス
''' </summary>
Public Class M_Worker

    'テーブルデータ格納変数
    Public WorkerID
    Public LastName
    Public LastNameKana
    Public FirstName
    Public FirstNameKana
    Public Status
    Public Class_w
    Public Mail
    Public AdminFlg

    ''' <summary>
    ''' セッションの交通費データの社員IDからデータを取得する
    ''' </summary>
    ''' <param name="workerID">交通費データから得た社員ID</param>
    ''' <param name="workerData">社員テーブルデータ格納用インスタンス</param>
    ''' <returns></returns>
    Public Shared Function GetWorker(ByVal workerID As String, ByRef workerData As M_Worker) As Boolean
        Dim result As Boolean = False
        'Try入れる
        Try
            Using con As New SqlConnection(My.Settings.DB)
                con.Open()
                'SQL実行処理
                Using cmd As SqlCommand = con.CreateCommand
                    Dim Sql As New StringBuilder

                    'SQL文作成
                    Sql.AppendLine("SELECT * FROM [M_Worker] WHERE [WorkerID] = @workerID")

                    cmd.Parameters.Add("@workerID", SqlDbType.Char, 4).Value = workerID
                    cmd.CommandText = Sql.ToString()

                    '読み込みの開始
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            workerData.WorkerID = reader("WorkerID")
                            workerData.LastName = reader("LastName")
                            workerData.LastNameKana = reader("LastNameKana")
                            workerData.FirstName = reader("FirstName")
                            workerData.FirstNameKana = reader("FirstNameKana")
                            workerData.Status = reader("Status")
                            workerData.Class_w = reader("Class")
                            workerData.Mail = reader("Mail")
                            workerData.AdminFlg = reader("AdminFlg")
                            result = True

                        Else
                            result = False
                        End If

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
