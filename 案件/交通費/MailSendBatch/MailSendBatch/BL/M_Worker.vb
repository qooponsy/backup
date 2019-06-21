Imports System.Data.SqlClient
Imports System.Text

Public Class M_Worker
    'テーブルデータ格納用変数
    Public WorkerID As String
    Public FirstName As String
    Public FirstNameKana As String
    Public LastName As String
    Public LastNameKana As String
    Public Status As String
    Public Class_w As String
    Public Mail As String
    'Public FolderName As String
    Public AdminFlg As String

    Public Class StatusCode
        Public Const NORMAL As Integer = 1      '通常
        Public Const ABSENCE As Integer = 2     '休職
        Public Const RETIREMENT As Integer = 9  '退職
    End Class

    Public Class AdminFlgCode
        Public Const ADMIN As Integer = 1       '管理者
        Public Const SYS_ADMIN As Integer = 2   'システム管理者
        Public Const ATHER As Integer = 9       'その他
    End Class


    Public Shared Function GetWorkerList(ByRef workerList As List(Of M_Worker)) As Boolean
        Dim result As Boolean = False
        Try
            Using con As New SqlConnection(My.Settings.DB)
                con.Open()
                'SQL実行処理
                Using cmd As SqlCommand = con.CreateCommand
                    Dim Sql As New StringBuilder
                    'SQL文作成
                    Sql.AppendLine("SELECT")
                    Sql.AppendLine("	WorkerID, LastName, LastNameKana, FirstName, FirstNameKana,")
                    Sql.AppendLine("	Status as W_Status, Class as W_Class, Mail, AdminFlg")
                    Sql.AppendLine("FROM")
                    Sql.AppendLine("	M_Worker")
                    Sql.AppendLine("WHERE")
                    Sql.AppendLine("	Status = @Status")
                    Sql.AppendLine("ORDER BY")
                    Sql.AppendLine("	Class")

                    cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = StatusCode.NORMAL

                    cmd.CommandText = Sql.ToString()
                    '読み込みの開始
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim workerData As New M_Worker
                            workerData.WorkerID = reader("WorkerID")
                            workerData.FirstName = reader("FirstName")
                            workerData.FirstNameKana = reader("FirstNameKana")
                            workerData.LastName = reader("LastName")
                            workerData.LastNameKana = reader("LastNameKana")
                            workerData.Status = reader("W_Status")
                            workerData.Class_w = reader("W_Class")
                            workerData.Mail = reader("Mail")
                            workerData.AdminFlg = reader("AdminFlg")

                            workerList.Add(workerData)

                        End While
                        If workerList.Count > 0 Then
                            result = True
                        End If

                    End Using '読み込みの終了

                End Using 'SQL処理の終了

            End Using 'SQLコマンドの終了
        Catch ex As Exception
            LogWrite.ErrorLog(ex)
            result = False
        End Try

        Return result
    End Function

    Public Shared Function GetAdmminWorker(ByRef workerList As List(Of M_Worker)) As Boolean
        Dim result As Boolean = False

        Try
            Using con As New SqlConnection(My.Settings.DB)
                con.Open()
                'SQL実行処理
                Using cmd As SqlCommand = con.CreateCommand
                    Dim Sql As New StringBuilder
                    'SQL文作成
                    Sql.AppendLine("SELECT")
                    Sql.AppendLine("	WorkerID, LastName, LastNameKana, FirstName, FirstNameKana,")
                    Sql.AppendLine("	Status as W_Status, Class as W_Class, Mail, AdminFlg")
                    Sql.AppendLine("FROM")
                    Sql.AppendLine("	M_Worker")
                    Sql.AppendLine("WHERE")
                    Sql.AppendLine("	AdminFlg in ( @Admin, @SysAdmin)")
                    Sql.AppendLine("AND")
                    Sql.AppendLine("	Status = @Status")
                    Sql.AppendLine("ORDER BY")
                    Sql.AppendLine("	Class")

                    cmd.Parameters.Add("@Admin", SqlDbType.Char, 1).Value = AdminFlgCode.ADMIN
                    cmd.Parameters.Add("@SysAdmin", SqlDbType.Char, 1).Value = AdminFlgCode.SYS_ADMIN
                    cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = StatusCode.NORMAL

                    cmd.CommandText = Sql.ToString()
                    '読み込みの開始
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim workerData As New M_Worker
                            workerData.WorkerID = reader("WorkerID")
                            workerData.FirstName = reader("FirstName")
                            workerData.FirstNameKana = reader("FirstNameKana")
                            workerData.LastName = reader("LastName")
                            workerData.LastNameKana = reader("LastNameKana")
                            workerData.Status = reader("W_Status")
                            workerData.Class_w = reader("W_Class")
                            workerData.Mail = reader("Mail")
                            workerData.AdminFlg = reader("AdminFlg")

                            workerList.Add(workerData)

                        End While
                        If workerList.Count > 0 Then
                            result = True
                        End If

                    End Using '読み込みの終了

                End Using 'SQL処理の終了

            End Using 'SQLコマンドの終了
        Catch ex As Exception
            LogWrite.ErrorLog(ex)
            result = False
        End Try

        Return result

    End Function

End Class
