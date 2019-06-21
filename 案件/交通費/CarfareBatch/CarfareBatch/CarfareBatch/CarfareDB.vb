Imports System.Data.SqlClient
Imports System.Text

Public Class CarfareDB
    ''' <summary>
    ''' 社員データ取得（交通費記載確認用のために現社員のみ取得）
    ''' </summary>
    ''' <param name="Workerlist">社員情報を保持するリスト</param>
    ''' <returns></returns>
    Public Shared Function GetWorkerList(ByRef Workerlist As List(Of WorkerData)) As Boolean
        Dim ret As Boolean = True
        Dim DBConnStr As String = My.Settings.DB
        Try
            Using con As New SqlConnection(DBConnStr)
                con.Open()
                'SQL実行処理
                Using cmd As SqlCommand = con.CreateCommand

                    Dim Sql As New StringBuilder

                    'SQL文作成
                    Sql.AppendLine("select WorkerID,FirstName,LastName,Status,Mail,FolderName from M_Worker")
                    Sql.AppendLine("Where Status = @Status")
                    Sql.AppendLine("And AdminFlg = 0")


                    cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = WorkerData.WORKER_TSUJYO

                    cmd.CommandText = Sql.ToString()

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim user As New WorkerData
                            user.WorkerID = reader("WorkerID")
                            user.FirstName = reader("FirstName")
                            user.LastName = reader("LastName")
                            user.Mail = reader("Mail")
                            user.FolderName = reader("FolderName")

                            Dim NowWorkerList As String = user.LastName & "," & user.FirstName & "," & user.Mail & "," & user.WorkerID
                            Workerlist.Add(user)

                        End While
                        If Workerlist.Count = 0 Then
                            ret = False
                            LogWrite.Warning("社員情報は0件です。朝バッチ処理を終了します。")
                        End If

                    End Using
                End Using
            End Using

        Catch ex As Exception
            ret = False
            LogWrite.ErrorLog(ex)
        End Try

        Return ret
    End Function
    ''' <summary>
    ''' 社員アドレス取得　※使用しない
    ''' </summary>
    ''' <param name="WorkerID">社員ID</param>
    ''' <returns></returns>
    Public Shared Function GetAddress(ByRef WorkerID As String) As String
        Dim ret As String = ""
        Dim DBConnStr As String = My.Settings.DB
        Try
            Using con As New SqlConnection(DBConnStr)
                con.Open()
                'SQL実行処理
                Using cmd As SqlCommand = con.CreateCommand

                    Dim Sql As New StringBuilder

                    'SQL文作成
                    Sql.AppendLine("select Mail from M_Worker")
                    Sql.AppendLine("Where WorkerID =@WorkerID")

                    cmd.Parameters.Add("@WorkerID", SqlDbType.Char, 4).Value = WorkerID
                    cmd.CommandText = Sql.ToString()

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim user As New WorkerData
                            user.Mail = reader("Mail")

                            ret = user.Mail
                        End While


                    End Using
                End Using
            End Using

        Catch ex As Exception
            ret = False
            LogWrite.ErrorLog(ex)
        End Try

        Return ret
    End Function

    ''' <summary>
    ''' 最終営業日取得
    ''' </summary>
    ''' <param name="LastDay">最終営業日</param>
    ''' <returns></returns>
    Public Shared Function GetLastBusinessDay(ByVal ToDay As String, ByRef LastDay As LastBusinessDay) As Boolean
        Dim ret As Boolean = True
        Dim DBConnStr As String = My.Settings.DB

        LastDay = Nothing

        Try

            Using con As New SqlConnection(DBConnStr)
                con.Open()
                'SQL実行処理
                Using cmd As SqlCommand = con.CreateCommand

                    Dim Sql As New StringBuilder

                    'SQL文作成
                    Sql.AppendLine("select * from S_LastBusinessDay")
                    Sql.AppendLine("Where Status =@Status")
                    Sql.AppendLine(" and LastBusinessDay =@LastBusinessDay")

                    cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = LastBusinessDay.StatusCode.NON_COMP
                    cmd.Parameters.Add("@LastBusinessDay", SqlDbType.Date).Value = Date.Parse(ToDay)
                    cmd.CommandText = Sql.ToString()

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            LastDay = New LastBusinessDay

                            LastDay.LastBusinessDayID = reader("LastBusinessDayID")
                            LastDay.LastBusinessDay = reader("LastBusinessDay")
                            LastDay.Status = reader("Status")
                            LastDay.CarfareCount = reader("CarfareCount")

                        End If

                    End Using

                    If LastDay Is Nothing Then
                        ret = False
                        LogWrite.Information("本日は最終営業日ではありません。朝バッチ処理を終了します。")
                    End If

                End Using
            End Using

        Catch ex As Exception
            ret = False
            LogWrite.ErrorLog(ex)
        End Try

        Return ret
    End Function
    ''' <summary>
    ''' 交通費記載確認用データ登録　※使用しない
    ''' </summary>
    ''' <param name="Worker">社員情報</param>
    ''' <param name="CarfareID">交通費ID</param>
    ''' <param name="count">登録件数確認用</param>
    ''' <returns></returns>
    Public Shared Function InsertCarfareData(ByRef Worker As WorkerData, ByRef CarfareID As Integer, ByRef count As Integer) As Boolean
        Dim ret As Boolean = True
        Dim DBConnStr As String = My.Settings.DB

        '当日の日付を取得
        Dim Today As Date
        Dim ToDay_y, Today_m As String
        Today = DateTime.Now.Date
        ToDay_y = (Today.ToString("yyyy"))
        Today_m = (Today.ToString("MM"))

        Try
            Using con As New SqlConnection(DBConnStr)
                con.Open()
                'SQL実行処理
                Using cmd As SqlCommand = con.CreateCommand

                    Dim Sql As New StringBuilder

                    'SQL文作成
                    Sql.AppendLine("INSERT INTO [T_Carfare] VALUES(")
                    Sql.AppendLine("SYSDATETIME()")
                    Sql.AppendLine(", '9999'")
                    Sql.AppendLine(", SYSDATETIME()")
                    Sql.AppendLine(", '9999'")
                    Sql.AppendLine(", @WorkerID")
                    Sql.AppendLine(", @Year")
                    Sql.AppendLine(", @Month")
                    Sql.AppendLine(", @Status")
                    Sql.AppendLine(", @WriteStatus);")
                    Sql.AppendLine("SELECT SCOPE_IDENTITY()")  '交通費IDを取得

                    Dim WKDate As New WorkerData

                    cmd.Parameters.Add("@WorkerID", SqlDbType.Char, 4).Value = Worker.WorkerID
                    cmd.Parameters.Add("@Year", SqlDbType.Char, 4).Value = ToDay_y
                    cmd.Parameters.Add("@Month", SqlDbType.Char, 2).Value = Today_m
                    cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = CarfareData.PROCESS_STATUS
                    cmd.Parameters.Add("@WriteStatus", SqlDbType.Char, 1).Value = CarfareData.WORKER_WRITE_STATUS
                    cmd.CommandText = Sql.ToString()

                    Dim GetCarfareID As String = cmd.ExecuteScalar()

                    If GetCarfareID <> "" Then
                        CarfareID = GetCarfareID
                    End If

                End Using
            End Using

        Catch ex As Exception
            ret = False
            LogWrite.ErrorLog(ex)
        End Try

        Return ret
    End Function
    ''' <summary>
    ''' セッションキー登録   ※使用しない
    ''' </summary>
    ''' <param name="CarfareID">交通費ID</param>
    ''' <param name="SessionKey">セッションキー</param>
    ''' <returns></returns>
    Public Shared Function InsertSessionKey(ByVal CarfareID As Integer, ByVal SessionKey As String) As Boolean
        Dim ret As Boolean = True
        Dim DBConnStr As String = My.Settings.DB

        Try
            Using con As New SqlConnection(DBConnStr)
                con.Open()
                'SQL実行処理
                Using cmd As SqlCommand = con.CreateCommand

                    Dim Sql As New StringBuilder

                    'SQL文作成
                    Sql.AppendLine("INSERT INTO [S_Session] VALUES(")
                    Sql.AppendLine("SYSDATETIME()")
                    Sql.AppendLine(", '9999'")
                    Sql.AppendLine(", SYSDATETIME()")
                    Sql.AppendLine(", '9999'")
                    Sql.AppendLine(", @SessionKey")
                    Sql.AppendLine(", @CarfareID)")

                    'Dim WKDate As New WorkerData

                    cmd.Parameters.Add("@SessionKey", SqlDbType.Char, 32).Value = SessionKey
                    cmd.Parameters.Add("@CarfareID", SqlDbType.Int).Value = CarfareID

                    cmd.CommandText = Sql.ToString()

                    Dim InsertData As String = cmd.ExecuteNonQuery()

                    If InsertData <= 0 Then
                        ret = False
                    End If

                End Using
            End Using

        Catch ex As Exception
            ret = False
            LogWrite.ErrorLog(ex)
        End Try

        Return ret
    End Function
    ''' <summary>
    ''' 一括メールデータ登録(交通費記載依頼メール用)
    ''' </summary>
    ''' <param name="Today">本日の日付</param>
    ''' <returns></returns>
    Public Shared Function InsertCarfareMailData(ByVal Today As Date, ByVal LastBusinessDayID As Integer) As Boolean
        Dim ret As Boolean = True
        Dim DBConnStr As String = My.Settings.DB

        '当日の日付を取得
        Dim ToDay_y, Today_m As String

        ToDay_y = (Today.ToString("yyyy"))
        Today_m = (Today.ToString("MM"))

        Try
            Using con As New SqlConnection(DBConnStr)
                con.Open()
                'SQL実行処理
                Using cmd As SqlCommand = con.CreateCommand

                    Dim Sql As New StringBuilder

                    'SQL文作成
                    Sql.Append(My.Resources.BulkMailInsert)
                    Dim WKDate As New WorkerData

                    cmd.Parameters.Add("@MailCode", SqlDbType.Char, 1).Value = CarfareData.MAILCODE_M
                    cmd.Parameters.Add("@Year", SqlDbType.Char, 4).Value = ToDay_y
                    cmd.Parameters.Add("@Month", SqlDbType.Char, 2).Value = Today_m
                    cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = CarfareData.MAIL_STATUS
                    cmd.Parameters.Add("@LastBusinessDayID", SqlDbType.Int).Value = LastBusinessDayID
                    cmd.Parameters.Add("@lbdStatus", SqlDbType.Int).Value = LastBusinessDay.StatusCode.MAIL_COMP

                    cmd.CommandText = Sql.ToString()

                    Dim InsertData As String = cmd.ExecuteNonQuery()

                    If InsertData = 0 Then
                        ret = False
                        LogWrite.Warning("交通費記載依頼メール用データの登録件数は0件です。朝バッチ処理を終了します。")
                    End If

                End Using
            End Using

        Catch ex As Exception
            ret = False
            LogWrite.ErrorLog(ex)
        End Try

        Return ret
    End Function

    ''' <summary>
    ''' 一括メールデータ登録(未記載報告メール用)
    ''' </summary>
    ''' <param name="Today">本日の日付</param>
    ''' <returns></returns>
    Public Shared Function InsertCarfareMailData_n(ByVal Today As Date) As Boolean
        Dim ret As Boolean = True
        Dim DBConnStr As String = My.Settings.DB

        '当日の日付を取得
        Dim ToDay_y, Today_m As String

        ToDay_y = (Today.ToString("yyyy"))
        Today_m = (Today.ToString("MM"))

        Try
            Using con As New SqlConnection(DBConnStr)
                con.Open()
                'SQL実行処理
                Using cmd As SqlCommand = con.CreateCommand

                    Dim Sql As New StringBuilder

                    'SQL文作成
                    Sql.AppendLine("INSERT INTO [S_BulkMail] VALUES(")
                    Sql.AppendLine("SYSDATETIME()")
                    Sql.AppendLine(", '9999'")
                    Sql.AppendLine(", SYSDATETIME()")
                    Sql.AppendLine(", '9999'")
                    Sql.AppendLine(", @MailCode")
                    Sql.AppendLine(", @Year")
                    Sql.AppendLine(", @Month")
                    Sql.AppendLine(", @Status)")

                    Dim WKDate As New WorkerData

                    cmd.Parameters.Add("@MailCode", SqlDbType.Char, 1).Value = CarfareData.MAILCODE_N
                    cmd.Parameters.Add("@Year", SqlDbType.Char, 4).Value = ToDay_y
                    cmd.Parameters.Add("@Month", SqlDbType.Char, 2).Value = Today_m
                    cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = CarfareData.MAIL_STATUS

                    cmd.CommandText = Sql.ToString()

                    Dim InsertData As String = cmd.ExecuteNonQuery()

                    If InsertData = 0 Then
                        ret = False
                        LogWrite.Warning("未記載報告メール用データの登録件数は0件です。夜バッチ処理を終了します。")
                    End If

                End Using
            End Using

        Catch ex As Exception
            ret = False
            LogWrite.ErrorLog(ex)
        End Try

        Return ret
    End Function
    ''' <summary>
    '''     交通費記載ステータス取得(交通費未記載の人のみ)
    ''' </summary>
    ''' <param name="Workerlist">社員情報</param>
    ''' <returns></returns>
    Public Shared Function GetWriteStatus(ByRef Workerlist As List(Of WorkerData)) As Boolean
        Dim ret As Boolean = True
        Dim DBConnStr As String = My.Settings.DB
        Try
            Using con As New SqlConnection(DBConnStr)
                con.Open()
                'SQL実行処理
                Using cmd As SqlCommand = con.CreateCommand

                    Dim Sql As New StringBuilder

                    'SQL文作成
                    Sql.AppendLine("select WorkerID,Year,Month,WriteStatus from T_Carfare")
                    Sql.AppendLine("Where WriteStatus = @WriteStatus")


                    cmd.Parameters.Add("@WriteStatus", SqlDbType.Char, 1).Value = CarfareData.WORKER_WRITE_STATUS
                    cmd.CommandText = Sql.ToString()

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim user As New WorkerData
                            user.WorkerID = reader("WorkerID")
                            user.FirstName = reader("Year")
                            user.LastName = reader("Month")
                            user.WriteWorkerStatus = reader("WriteStatus")

                            Workerlist.Add(user)

                        End While
                        If Workerlist.Count < 1 Then

                            ret = False
                            LogWrite.Information("交通費未記載の社員は0人です。夜バッチ処理を終了します。")

                        End If

                    End Using
                End Using
            End Using

        Catch ex As Exception
            ret = False
            LogWrite.ErrorLog(ex)
        End Try

        Return ret
    End Function
    ''' <summary>
    ''' 交通費記載確認用データ・セッションキー登録
    ''' トランザクション処理のため、個別の関数を統合。
    ''' </summary>
    ''' <param name="Worker">社員情報</param>
    ''' <param name="SessionKey">セッションキー</param>
    ''' <returns></returns>
    Public Shared Function InsertCarfareData_SessionKey(ByRef Worker As WorkerData, ByVal LastBusinessDayID As Integer,
                                                        ByVal SessionKey As String, ByVal Today As Date) As Boolean
        Dim ret As Boolean = True
        Dim DBConnStr As String = My.Settings.DB

        '当日の日付を取得
        Dim ToDay_y, Today_m As String
        ToDay_y = (Today.ToString("yyyy"))
        Today_m = (Today.ToString("MM"))


        Try
            Using con As New SqlConnection(DBConnStr)
                con.Open()
                'SQL実行処理
                Using cmd As SqlCommand = con.CreateCommand

                    Dim Sql As New StringBuilder

                    'SQL文作成
                    Sql.Append(My.Resources.CarfareInsert)

                    cmd.Parameters.Add("@WorkerID", SqlDbType.Char, 4).Value = Worker.WorkerID
                    cmd.Parameters.Add("@LastBusinessDayID", SqlDbType.Int).Value = LastBusinessDayID
                    cmd.Parameters.Add("@Year", SqlDbType.Char, 4).Value = ToDay_y
                    cmd.Parameters.Add("@Month", SqlDbType.Char, 2).Value = Today_m
                    cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = CarfareData.PROCESS_STATUS
                    cmd.Parameters.Add("@WriteStatus", SqlDbType.Char, 1).Value = CarfareData.WORKER_WRITE_STATUS
                    cmd.Parameters.Add("@SessionKey", SqlDbType.Char, 32).Value = SessionKey

                    cmd.CommandText = Sql.ToString()

                    Dim InsertData As String = cmd.ExecuteNonQuery()

                    If InsertData <= 0 Then
                        ret = False
                        LogWrite.Warning("交通費記載確認用データ、セッションキー登録件数は0件です。朝バッチ処理を終了します。")

                    End If

                End Using
            End Using

        Catch ex As Exception
            ret = False
            LogWrite.ErrorLog(ex)
        End Try

        Return ret
    End Function

End Class
