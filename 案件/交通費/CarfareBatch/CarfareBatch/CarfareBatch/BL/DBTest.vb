Imports System.Data.SqlClient
Imports System.Text

Public Class DBTest

    '社員データ取得（交通費記載確認用のために現社員のみ取得）
    Public Shared Function GetWorkerList(ByRef WorkerID As String, ByRef WorkerStatus As String) As String
        Dim ret As String = ""
        Dim DBConnStr As String = My.Settings.DB
        Try
            Using con As New SqlConnection(DBConnStr)
                con.Open()
                'SQL実行処理
                Using cmd As SqlCommand = con.CreateCommand

                    Dim Sql As New StringBuilder

                    'SQL文作成
                    Sql.AppendLine("select WorkerID,FirstName,LastName,Mail,Status from M_Worker")
                    Sql.AppendLine("Where WorkerID = @WorkerID and Status = @Status")

                    cmd.Parameters.Add("@WorkerID", SqlDbType.Char, 4).Value = WorkerID
                    cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = WorkerStatus
                    cmd.CommandText = Sql.ToString()

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim user As New WorkerData
                            user.WorkerID = reader("WorkerID")
                            user.FirstName = reader("FirstName")
                            user.LastName = reader("LastName")
                            user.Mail = reader("Mail")
                            user.Status = reader("Status")

                            ret = user.LastName & " " & user.FirstName & ":" & user.Mail & "(id" & user.WorkerID & " status: " & user.Status & ")"

                        End While

                    End Using
                End Using
            End Using

        Catch ex As Exception
            ret = False
        End Try

        Return ret
    End Function

    '社員データ取得
    Public Shared Function GetWorkerList_1(ByRef WorkerStatus As Integer) As String
        Dim ret As String = ""
        Dim DBConnStr As String = My.Settings.DB
        Try
            Using con As New SqlConnection(DBConnStr)
                con.Open()
                'SQL実行処理
                Using cmd As SqlCommand = con.CreateCommand

                    Dim Sql As New StringBuilder

                    'SQL文作成
                    Sql.AppendLine("select WorkerID,Status from M_Worker")
                    Sql.AppendLine("Where Status =@Status")

                    cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = 1
                    cmd.CommandText = Sql.ToString()

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim user As New WorkerData
                            user.WorkerID = reader("WorkerID")
                            user.Status = reader("Status")

                            ret = user.WorkerID & " " & user.Status
                        End While

                    End Using
                End Using
            End Using

        Catch ex As Exception
            ret = False
        End Try

        Return ret
    End Function

    '社員アドレス取得
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
        End Try

        Return ret
    End Function

    '最終営業日取得
    Public Shared Function GetLastBusinessDay() As String
        Dim ret As String = ""
        Dim DBConnStr As String = My.Settings.DB
        Try
            Using con As New SqlConnection(DBConnStr)
                con.Open()
                'SQL実行処理
                Using cmd As SqlCommand = con.CreateCommand

                    Dim Sql As New StringBuilder

                    'SQL文作成
                    Sql.AppendLine("select LastBusinessDay from S_LastBusinessDay")
                    Sql.AppendLine("Where Status =@Status")

                    cmd.Parameters.Add("@Status", SqlDbType.Char, 3).Value = 0
                    cmd.CommandText = Sql.ToString()

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim BusinessDay As New LastBusinessDay

                            BusinessDay.LBDay = reader("LastBusinessDay")

                            ret = BusinessDay.LBDay
                        End While

                    End Using
                End Using
            End Using

        Catch ex As Exception
            ret = False
        End Try

        Return ret
    End Function


    '交通費記載確認用データ登録
    Public Shared Function InsertCarfareData(ByRef WorkerID As String) As String
        Dim ret As Boolean = ""
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

                    cmd.Parameters.Add("@WorkerID", SqlDbType.Char, 4).Value = WorkerID
                    cmd.Parameters.Add("@Year", SqlDbType.Char, 4).Value = ToDay_y
                    cmd.Parameters.Add("@Month", SqlDbType.Char, 3).Value = Today_m
                    cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = "0"
                    cmd.Parameters.Add("@WriteStatus", SqlDbType.Char, 1).Value = "0"

                    cmd.CommandText = Sql.ToString()

                    Dim InsertCarfareID As String = cmd.ExecuteScalar()

                    If InsertCarfareID <> "" Then
                        ret = InsertCarfareID
                    End If

                End Using
            End Using

        Catch ex As Exception
            ret = False
        End Try

        Return ret
    End Function

    'セッションデータ登録
    Public Shared Function InsertSessionKey(ByRef CarfareID As Integer) As Boolean
        Dim ret As Boolean = ""
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
                    Sql.AppendLine("")              '[, '9999'
                    Sql.AppendLine(", SYSDATETIME()")
                    Sql.AppendLine("")              '[, '9999'
                    Sql.AppendLine("@SessionKey")   '[, 'ここにはセッションキーが入る'
                    Sql.AppendLine("@CarfareID")    '[, 'ここには自動採番で生成した交通費IDが入る'

                    'Dim WKDate As New WorkerData

                    cmd.Parameters.Add("@SessionKey", SqlDbType.Char, 3).Value = ""
                    cmd.Parameters.Add("@CarfareID", SqlDbType.Char, 3).Value = ""

                    cmd.CommandText = Sql.ToString()

                    Dim InsertData As String = cmd.ExecuteNonQuery()

                    If InsertData > 0 Then
                        ret = True
                    End If

                End Using
            End Using

        Catch ex As Exception
            ret = False
        End Try

        Return ret
    End Function



End Class
