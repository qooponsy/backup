Imports System.Data.SqlClient
Imports System.Text

Public Class MatchClassService

    Public Shared Function GetList(ByVal LeagueCode As String, ByRef list As List(Of MatchClassData)) As Boolean
        Dim ret As Boolean = True

        ' クラブ詳細情報
        Dim DBConnStr As String = My.Settings.DB
        Try
            Using con As New SqlConnection(DBConnStr)
                con.Open()
                Using cmd As SqlCommand = con.CreateCommand
                    Dim sql As New StringBuilder
                    sql.AppendLine("select * from [M_MatchClass] with ( nolock )")
                    sql.AppendLine("where [LeagueCode] = @LeagueCode")
                    sql.AppendLine("order by [MatchClass]")

                    cmd.CommandText = sql.ToString
                    cmd.Parameters.Add("@LeagueCode", SqlDbType.Char, 2).Value = LeagueCode

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim item As New MatchClassData
                            item.MatchClass = reader("MatchClass")
                            item.LeagueCode = reader("LeagueCode")
                            item.MatchClassName = reader("MatchClassName")

                            list.Add(item)
                        End While
                    End Using
                End Using
            End Using

            If list.Count = 0 Then
                ret = False
            End If

        Catch ex As Exception
            SystemLog.ExceptionError(ex)
            ret = False
        End Try

        Return ret
    End Function

End Class
