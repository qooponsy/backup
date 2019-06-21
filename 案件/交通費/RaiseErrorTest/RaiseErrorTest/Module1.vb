Imports System.Data.SqlClient
Imports System.Text

Module Module1

    Sub Main()

        Dim DBConnStr As String = "Server=tcp:192.168.53.204;Database=CarfareTest;UID=Carfare;PWD=Carfare;Connection Timeout=5"

        Try
            Using con As New SqlConnection(DBConnStr)

                con.Open()

                Using cmd As SqlCommand = con.CreateCommand

                    Dim sql As String = My.Resources.script

                    cmd.CommandText = sql

                    cmd.ExecuteNonQuery()

                End Using

            End Using
        Catch ex As Exception

            Dim a As Integer
            a = 0

        End Try

    End Sub

End Module
