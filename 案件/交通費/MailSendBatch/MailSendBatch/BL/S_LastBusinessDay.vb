Imports System.Data.SqlClient
Imports System.Text

Public Class S_LastBusinessDay

    Public Class StatusCode
        Public Const NON_COMP As Integer = 0    '未完了
        Public Const MAIL_COMP As Integer = 1   '通知完了
        Public Const WRITE_COMP As Integer = 2  '全社員記載完了
    End Class

    Public Shared Function CheckLastMail(ByVal LastBusinessDayID As Integer) As Boolean
        Dim result As Boolean = True

        Try
            Using con As New SqlConnection(My.Settings.DB)
                con.Open()
                'SQL実行処理
                Using cmd As SqlCommand = con.CreateCommand
                    Dim Sql As New StringBuilder
                    Sql.Append(My.Resources.CheckLastMail)

                    cmd.Parameters.Add("@LastBusinessDayID", SqlDbType.Int).Value = LastBusinessDayID
                    cmd.Parameters.Add("@cStatus", SqlDbType.Char, 1).Value = T_Carfare.StatusCode.COMP_MAIL_SEND
                    cmd.Parameters.Add("@lStatus", SqlDbType.Char, 1).Value = StatusCode.WRITE_COMP

                    cmd.CommandText = Sql.ToString()

                    cmd.ExecuteNonQuery()

                End Using
            End Using

        Catch ex As Exception
            LogWrite.ErrorLog(ex)
            result = False
        End Try

        Return result
    End Function

End Class
