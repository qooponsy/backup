Imports System.Data.SqlClient
Imports System.Text

''' <summary>
''' S_Sessionテーブル接続クラス
''' </summary>
Public Class S_Session

    'テーブルデータ格納変数
    Public SessionKey As String
    Public carfareID As Integer

    ''' <summary>
    ''' セッションキーを使ってデータを持ってくる
    ''' </summary>
    ''' <param name="sessionKey">送られてきたセッションキー</param>
    ''' <param name="sessionData">セッションテーブルデータ格納用インスタンス</param>
    ''' <returns>データがあればTrue, なければFalse</returns>
    Public Shared Function GetSession(ByVal sessionKey As String, ByRef sessionData As S_Session) As String
        Dim result As Boolean = False
        'Try入れる
        Try
            Using con As New SqlConnection(My.Settings.DB)
                con.Open()
                'SQL実行処理
                Using cmd As SqlCommand = con.CreateCommand
                    Dim Sql As New StringBuilder

                    'SQL文作成
                    'SELECT [SessionKey], [carfareID] FROM [S_Session] WHERE [SessionKey] = '098f6bcd4621d373cade4e832627b4f6'
                    Sql.AppendLine("SELECT [SessionKey], [carfareID] FROM [S_Session] WHERE [SessionKey] = @sessionKey")

                    cmd.Parameters.Add("@sessionKey", SqlDbType.Char, 32).Value = sessionKey
                    cmd.CommandText = Sql.ToString()

                    '読み込みの開始
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            sessionData.SessionKey = reader("SessionKey")
                            sessionData.carfareID = reader("carfareID")
                            result = True
                        Else
                            result = False
                        End If
                    End Using '読み込みの終了

                End Using 'SQL処理終了 (closeコマンドは必要？)

            End Using 'SQLコマンド終了

        Catch ex As Exception
            LogWrite.ErrorLog(ex)
            result = False

        End Try

        Return result
    End Function

    ''' <summary>
    ''' 処理に使ったセッションデータを削除する
    ''' </summary>
    ''' <param name="carfareID">記載ステータスを変更した交通費ID</param>
    ''' <returns>処理が最後まで終わったらTrue, どこかで失敗したらFalse</returns>
    Public Shared Function DeleteSession(ByVal carfareID As Integer)
        Dim result As Boolean = False
        Try
            Using con As New SqlConnection(My.Settings.DB)
                con.Open()
                'SQL実行処理
                Using cmd As SqlCommand = con.CreateCommand
                    Dim Sql As New StringBuilder

                    'SQL文作成
                    'DELETE FROM [S_Session] WHERE [carfareID] = 1
                    Sql.AppendLine("DELETE FROM [S_Session] WHERE [carfareID] = @carfareID")

                    cmd.Parameters.Add("@carfareID", SqlDbType.Int).Value = carfareID
                    cmd.CommandText = Sql.ToString()
                    'ここで実行
                    Dim updData As Integer = cmd.ExecuteNonQuery()
                    If updData > 0 Then
                        result = True
                    End If

                End Using 'SQL処理終了

            End Using 'SQLコマンド終了

        Catch ex As Exception
            LogWrite.ErrorLog(ex)
            result = False
        End Try

        Return result
    End Function

End Class
