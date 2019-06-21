Imports System.Data.SqlClient
Imports System.Text

''' <summary>
''' T_Carfareテーブル接続クラス
''' </summary>
Public Class T_Carfare
    '交通費ステータス
    Public Enum WriteStatusCode As Integer
        sTrue = 1   '交通費あり
        sFalse = 2  '交通費なし
    End Enum


    'テーブルデータ格納変数
    Public carfareID As Integer
    Public WorkerID As String
    Public Year As String
    Public Month As String
    Public Status As String

    Public LastBusinessDayID As Integer
    Public FirstName As String
    Public FirstNameKana As String
    Public LastName As String
    Public LastNameKana As String
    Public Status_w As String     '社員テーブルのステータス
    Public Class_w As String      '社員テーブルのクラス
    Public Mail As String
    Public FolderName As String
    Public AdminFlg As String
    Public Status_c As String     '交通費テーブルのステータス
    Public WriteStatus As String
    Public SessionKey As String

    ''' <summary>
    ''' 交通費IDを使って交通費データを取ってくる
    ''' </summary>
    ''' <param name="carfareID">セッションから取得した交通費ID</param>
    ''' <param name="CarfareData">交通費テーブルデータ格納用インスタンス</param>
    ''' <returns>処理が全て成功したらTrue, どこかで失敗したらFalse</returns>
    Public Shared Function GetCarfare(ByVal carfareID As String, ByRef carfareData As T_Carfare) As Boolean
        Dim result As Boolean = False
        'Try入れる
        Try
            Using con As New SqlConnection(My.Settings.DB)
                con.Open()
                'SQL実行処理
                Using cmd As SqlCommand = con.CreateCommand
                    Dim Sql As New StringBuilder

                    'SQL文作成
                    'SELECT [carfareID], [WorkerID], [Year], [Month], [Status] FROM [T_Carfare] WHERE [carfareID] = 1
                    Sql.AppendLine("SELECT [carfareID], [WorkerID], [Year], [Month], [Status] FROM [T_Carfare] WHERE [carfareID] = @carfareID")

                    cmd.Parameters.Add("@carfareID", SqlDbType.Int).Value = carfareID
                    cmd.CommandText = Sql.ToString()

                    '読み込みの開始
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            carfareData.carfareID = reader("carfareID")
                            carfareData.WorkerID = reader("WorkerID")
                            carfareData.Year = reader("Year")
                            carfareData.Month = reader("Month")
                            carfareData.Status = reader("Status")
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

    ''' <summary>
    ''' 指定されたCarfareIDの交通費データのステータスを「記載済み」に変更する
    ''' </summary>
    ''' <param name="carfareID">ステータスを変更する交通費ID</param>
    ''' <returns>処理が全て成功したらTrue, どこかで失敗したらFalse</returns>
    Public Shared Function UpdateCarfare(ByVal carfareID As Integer, ByVal updUser As String) As Boolean
        Dim result As Boolean
        'Try入れる
        Try
            Using con As New SqlConnection(My.Settings.DB)
                con.Open()
                'SQL実行処理
                Using cmd As SqlCommand = con.CreateCommand
                    Dim Sql As New StringBuilder

                    'SQL文作成
                    'UPDATE [T_Carfare] SET [Status] = 1, [UpdTime] = SYSDATETIME(), [UpdUser] = '0014' WHERE [carfareID] = 1
                    'DBのカラム順に変更 仕様変更に伴いStatusを1ではなく2に更新するように変更
                    Sql.AppendLine("UPDATE [T_Carfare] SET [UpdTime] = SYSDATETIME(), [UpdUser] = @UpdUser, [Status] = 2 WHERE [carfareID] = @carfareID")

                    cmd.Parameters.Add("@UpdUser", SqlDbType.Char, 4).Value = updUser
                    cmd.Parameters.Add("@carfareID", SqlDbType.Int).Value = carfareID
                    cmd.CommandText = Sql.ToString()
                    'ここで実行
                    Dim updData As Integer = cmd.ExecuteNonQuery()
                    If updData > 0 Then
                        result = True
                    End If


                    result = True
                End Using 'SQL処理終了

            End Using 'SQLコマンド終了

        Catch ex As Exception
            LogWrite.ErrorLog(ex)
            result = False
        End Try

        Return result
    End Function

    Public Shared Function UpdDelCarfareSession(ByVal carfareID As Integer, ByVal updUser As String, ByVal WriteStatus As String) As Boolean
        Dim result As Boolean = False
        Try
            Using con As New SqlConnection(My.Settings.DB)
                con.Open()
                'SQL実行処理
                Using cmd As SqlCommand = con.CreateCommand
                    Dim Sql As New StringBuilder

                    Sql.Append(My.Resources.script)
                    cmd.Parameters.Add("@UpdUser", SqlDbType.Char, 4).Value = updUser
                    cmd.Parameters.Add("@carfareID", SqlDbType.Int).Value = carfareID
                    cmd.Parameters.Add("@WriteStatus", SqlDbType.Char, 1).Value = WriteStatus

                    cmd.CommandText = Sql.ToString()

                    cmd.ExecuteNonQuery()

                    result = True
                End Using

            End Using

        Catch ex As Exception
            LogWrite.ErrorLog(ex)
            result = False
        End Try


        Return result
    End Function

    Public Shared Function GetSearchWorker(ByVal SessionKey As String, ByRef carfareData As T_Carfare) As Boolean
        Dim result As Boolean = False
        Try
            Using con As New SqlConnection(My.Settings.DB)
                con.Open()
                'SQL実行処理
                Using cmd As SqlCommand = con.CreateCommand
                    Dim Sql As New StringBuilder
                    'SQL文作成
                    Sql.AppendLine("SELECT")
                    Sql.AppendLine("	c.carfareID, w.WorkerID, c.LastBusinessDayID,")
                    Sql.AppendLine("	w.FirstName, w.FirstNameKana, w.LastName, w.LastNameKana,")
                    Sql.AppendLine("	w.Status AS W_Status, w.Class, w.Mail, w.FolderName, w.AdminFlg,")
                    Sql.AppendLine("	c.Year, c.Month, c.Status AS C_Status, c.WriteStatus, s.SessionKey")
                    Sql.AppendLine("FROM")
                    Sql.AppendLine("	T_Carfare AS c")
                    Sql.AppendLine("	LEFT JOIN M_Worker AS w ON c.WorkerID = w.WorkerID")
                    Sql.AppendLine("	LEFT JOIN S_Session AS s ON c.carfareID = s.carfareID")
                    Sql.AppendLine("WHERE")
                    Sql.AppendLine("	s.SessionKey = @SessionKey")
                    Sql.AppendLine("ORDER BY")
                    Sql.AppendLine("	c.Year, c.Month, w.Class")

                    cmd.Parameters.Add("@SessionKey", SqlDbType.Char, 32).Value = SessionKey

                    cmd.CommandText = Sql.ToString()
                    '読み込みの開始
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            'Dim carfareData As New T_Carfare
                            carfareData.carfareID = reader("carfareID")
                            carfareData.WorkerID = reader("WorkerID")
                            carfareData.LastBusinessDayID = reader("LastBusinessDayID")
                            carfareData.FirstName = reader("FirstName")
                            carfareData.FirstNameKana = reader("FirstNameKana")
                            carfareData.LastName = reader("LastName")
                            carfareData.LastNameKana = reader("LastNameKana")
                            carfareData.Status_w = reader("W_Status")
                            carfareData.Class_w = reader("Class")
                            carfareData.Mail = reader("Mail")
                            carfareData.FolderName = reader("FolderName")
                            carfareData.AdminFlg = reader("AdminFlg")
                            carfareData.Year = reader("Year")
                            carfareData.Month = reader("Month")
                            carfareData.Status_c = reader("C_Status")
                            carfareData.WriteStatus = reader("WriteStatus")
                        End While
                        result = True

                    End Using '読み込みの終了

                End Using 'SQL処理の終了

            End Using 'SQLコマンド終了

        Catch ex As Exception
            LogWrite.ErrorLog(ex)
            result = False
        End Try


        Return result
    End Function
End Class
