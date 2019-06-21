Imports System.Data.SqlClient
Imports System.Text

Public Class SectionService

    Public Shared Function GetSection(ByVal LeagueCode As String, ByVal LeagueDetailCode As String, ByVal Year As String, ByVal MatchClass As String, ByRef section As String) As Boolean
        Dim ret As Boolean = True

        ' セクション情報取得 
        Dim DBConnStr As String = My.Settings.DB
        Try
            Using con As New SqlConnection(DBConnStr)
                con.Open()
                Using cmd As SqlCommand = con.CreateCommand
                    Dim sql As New StringBuilder
                    sql.AppendLine("select [Section] from [T_Section] with ( nolock ) ")
                    sql.AppendLine("where [LeagueCode] = @LeagueCode")
                    sql.AppendLine("and [LeagueDetailCode] = @LeagueDetailCode")
                    sql.AppendLine("and [Year] = @Year")
                    sql.AppendLine("and [MatchClass] = @MatchClass")

                    cmd.CommandText = sql.ToString
                    cmd.Parameters.Add("@LeagueCode", SqlDbType.Char, 2).Value = LeagueCode
                    cmd.Parameters.Add("@LeagueDetailCode", SqlDbType.Char, 2).Value = LeagueDetailCode
                    cmd.Parameters.Add("@Year", SqlDbType.Char, 4).Value = Year
                    cmd.Parameters.Add("@MatchClass", SqlDbType.Char, 2).Value = MatchClass

                    Using reader As SqlDataReader = cmd.ExecuteReader()

                        If reader.Read() Then

                            section = reader("Section")

                        End If

                    End Using
                End Using
            End Using
        Catch ex As Exception
            SystemLog.ExceptionError(ex)
            ret = False
        End Try

        Return ret
    End Function

    Public Shared Function GetSectionCode(ByVal LeagueCode As String, ByVal LeagueDetailCode As String, ByVal Year As String, ByVal MatchClass As String, ByRef sectionCode As String) As Boolean
        Dim ret As Boolean = True

        ' セクション情報取得 
        Dim DBConnStr As String = My.Settings.DB
        Try
            Using con As New SqlConnection(DBConnStr)
                con.Open()
                Using cmd As SqlCommand = con.CreateCommand
                    Dim sql As New StringBuilder
                    sql.AppendLine("select [SectionCode] from [T_Section] with ( nolock ) ")
                    sql.AppendLine("where [LeagueCode] = @LeagueCode")
                    sql.AppendLine("and [LeagueDetailCode] = @LeagueDetailCode")
                    sql.AppendLine("and [Year] = @Year")
                    sql.AppendLine("and [MatchClass] = @MatchClass")

                    cmd.CommandText = sql.ToString
                    cmd.Parameters.Add("@LeagueCode", SqlDbType.Char, 2).Value = LeagueCode
                    cmd.Parameters.Add("@LeagueDetailCode", SqlDbType.Char, 2).Value = LeagueDetailCode
                    cmd.Parameters.Add("@Year", SqlDbType.Char, 4).Value = Year
                    cmd.Parameters.Add("@MatchClass", SqlDbType.Char, 2).Value = MatchClass

                    Using reader As SqlDataReader = cmd.ExecuteReader()

                        If reader.Read() Then

                            sectionCode = reader("SectionCode")

                        End If

                    End Using
                End Using
            End Using
        Catch ex As Exception
            SystemLog.ExceptionError(ex)
            ret = False
        End Try

        Return ret
    End Function

    Public Shared Function Update(ByRef item As SectionData) As Boolean

        Dim DBSuccess As Boolean = False
        Dim DBConnStr As String = My.Settings.DB
        Try

            Using con As New SqlConnection(DBConnStr)
                con.Open()
                Using cmd As SqlCommand = con.CreateCommand
                    Dim SQL As New StringBuilder
                    SQL.AppendLine("select @SectionCode = [SectionCode] from [T_Section] with ( nolock ) ")
                    SQL.AppendLine("    where [LeagueCode] = @LeagueCode")
                    SQL.AppendLine("     and [LeagueDetailCode] = @LeagueDetailCode")
                    SQL.AppendLine("     and [MatchClass] = @MatchClass")
                    SQL.AppendLine("update [T_Section] set ")
                    SQL.AppendLine("     [Section] = @Section + 1 ")
                    SQL.AppendLine("    where [SectionCode] = @SectionCode")

                    cmd.CommandText = SQL.ToString()

                    Dim param As SqlParameter
                    param = cmd.Parameters.Add("@SectionCode", SqlDbType.Int)
                    param.Direction = ParameterDirection.Output

                    cmd.Parameters.Add("@Section", SqlDbType.Int).Value = item.Section
                    cmd.Parameters.Add("@LeagueCode", SqlDbType.Char, 2).Value = item.LeagueCode
                    cmd.Parameters.Add("@LeagueDetailCode", SqlDbType.Char, 2).Value = item.LeagueDetailCode
                    cmd.Parameters.Add("@MatchClass", SqlDbType.Char, 2).Value = item.MatchClass

                    Dim insData As Integer = cmd.ExecuteNonQuery()
                    If insData > 0 Then
                        item.SectionCode = cmd.Parameters("@SectionCode").Value
                        DBSuccess = True
                    End If

                End Using

            End Using

        Catch ex As Exception
            SystemLog.ExceptionError(ex)
        End Try

        Return DBSuccess
    End Function

End Class
