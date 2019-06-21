Imports System.Data.SqlClient
Imports System.Text

''' <summary>
''' T_Carfareテーブルへの接続クラス
''' </summary>
Public Class T_Carfare
    'テーブルデータ格納用変数
    Public carfareID As Integer
    Public WorkerID As String
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
    Public Year As String
    Public Month As String
    Public Status_c As String     '交通費テーブルのステータス
    Public WriteStatus As String
    Public SessionKey As String

    Public Class StatusCode
        Public Const REQ_MAIL_UNSEND As Integer = 0 '依頼メール未送信
        Public Const REQ_MAIL_SEND As Integer = 1   '依頼メール送信
        Public Const WRK_COMP_REQ As Integer = 2    '社員記載完了
        Public Const COMP_MAIL_SEND As Integer = 3  '完了メール送信済み
    End Class

    Public Class WriteStatusCode
        Public Const THERE As Integer = 1   '交通費あり
        Public Const NONE As Integer = 2    '交通費なし
    End Class

    Public Shared Function GetCarfareMailList(ByVal Status As Integer, ByRef carfareList As List(Of T_Carfare)) As Boolean
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
                    Sql.AppendLine("	c.Status = @Status")
                    Sql.AppendLine("ORDER BY")
                    Sql.AppendLine("	c.Year, c.Month, w.Class")

                    cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = Status

                    cmd.CommandText = Sql.ToString()
                    '読み込みの開始
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim carfareData As New T_Carfare
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

                            Dim SessionKey As Object = reader("SessionKey")
                            If Not IsDBNull(SessionKey) Then
                                carfareData.SessionKey = SessionKey
                            End If

                            carfareList.Add(carfareData)

                        End While
                        If carfareList.Count > 0 Then '件数が1件以上あった時点でTrue
                            result = True
                        End If

                    End Using '読み込みの終了

                End Using 'SQL処理の終了

            End Using 'SQLコマンド終了

        Catch ex As Exception
            LogWrite.ErrorLog(ex)
            result = False
        End Try


        Return result
    End Function

    Public Shared Function getRequestMailList(ByRef requestMailList As List(Of T_Carfare)) As Boolean
        Dim result As Boolean = False
        Try
            Using con As New SqlConnection(My.Settings.DB)
                con.Open()
                'SQL実行処理
                Using cmd As SqlCommand = con.CreateCommand
                    Dim Sql As New StringBuilder
                    'SQL文作成
                    Sql.AppendLine("SELECT")
                    Sql.AppendLine("	c.carfareID, c.Year, c.Month, w.WorkerID, w.Mail, s.SessionKey")
                    Sql.AppendLine("FROM")
                    Sql.AppendLine("	T_Carfare AS c")
                    Sql.AppendLine("	LEFT JOIN S_Session AS s ON c.carfareID = s.carfareID")
                    Sql.AppendLine("	LEFT JOIN M_Worker AS w ON c.WorkerID = w.WorkerID")
                    Sql.AppendLine("WHERE")
                    Sql.AppendLine("	c.Status = 0")


                    cmd.CommandText = Sql.ToString()
                    '読み込みの開始
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim carfareData As New T_Carfare
                            carfareData.carfareID = reader("carfareID")

                            requestMailList.Add(carfareData)

                        End While
                        If requestMailList.Count > 0 Then '件数が1件以上あった時点でTrue
                            result = True
                        End If

                    End Using '読み込みの終了

                End Using 'SQL処理の終了

            End Using 'SQLコマンド終了

        Catch ex As Exception
            LogWrite.ErrorLog(ex)
            result = False
        End Try


        Return result
    End Function

    Public Shared Function UpdateCarfareMailSendStatus(ByVal carfareID As String) As Boolean
        Dim result As Boolean = False

        Try
            Using con As New SqlConnection(My.Settings.DB)
                con.Open()
                'SQL実行処理
                Using cmd As SqlCommand = con.CreateCommand
                    Dim Sql As New StringBuilder
                    Sql.AppendLine("update T_Carfare set Status = @Status")
                    Sql.AppendLine("where carfareID = @CarfareID")

                    cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = StatusCode.REQ_MAIL_SEND
                    cmd.Parameters.Add("@CarfareID", SqlDbType.Int).Value = carfareID
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

    Public Shared Function UpdateAdminReportStatus(ByVal carfareID As String) As Boolean
        Dim result As Boolean = False

        Try
            Using con As New SqlConnection(My.Settings.DB)
                con.Open()
                'SQL実行処理
                Using cmd As SqlCommand = con.CreateCommand
                    Dim Sql As New StringBuilder
                    Sql.AppendLine("update T_Carfare set Status = @Status")
                    Sql.AppendLine("where carfareID = @CarfareID")

                    cmd.Parameters.Add("@Status", SqlDbType.Char, 1).Value = StatusCode.COMP_MAIL_SEND
                    cmd.Parameters.Add("@CarfareID", SqlDbType.Int).Value = carfareID
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
