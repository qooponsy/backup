Imports System.Data.SqlClient
Imports System.Text

Public Class DBTest

    Public Shared Function DBConnectionTest() As Boolean
        Dim result As Boolean = True

        Try
            Using con As New SqlConnection(My.Settings.DB)

                con.Open()
                'SQL実行処理
                Using cmd As SqlCommand = con.CreateCommand

                    Dim Sql As New StringBuilder

                    'SQL文作成
                    Sql.AppendLine("select * from [M_Worker]")
                    cmd.CommandText = Sql.ToString()

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then

                            'DB接続OK
                            result = True

                        Else

                            'DB接続NG
                            result = False

                        End If
                    End Using
                End Using
            End Using

        Catch ex As Exception
            result = False
        End Try

        Return result
    End Function

    Public Shared Function GetWorker(ByVal workerId As String) As String
        Dim lastName As String = ""
        Dim lastNameKana As String = ""


        Using con As New SqlConnection(My.Settings.DB)

            con.Open()
            'SQL実行処理
            Using cmd As SqlCommand = con.CreateCommand

                Dim Sql As New StringBuilder

                'SQL文作成
                Sql.AppendLine("select * from [M_Worker] where [WorkerID] = @workerId")

                cmd.Parameters.Add("@workerId", SqlDbType.Char).Value = workerId
                cmd.CommandText = Sql.ToString()

                Using reader As SqlDataReader = cmd.ExecuteReader()
                    If reader.Read() Then
                        lastName = reader("LastName")
                        lastNameKana = reader("LastNameKana")

                    End If

                End Using


            End Using
        End Using
        Dim name As String = lastName & " " & lastNameKana

        Return name
    End Function

End Class
