Imports System.Data.SqlClient
Imports System.Text

Public Class SeasonService

    Public Shared Function GetYearList(ByVal LeagueCode As String, ByVal LeagueDetailCode As String, ByRef list As List(Of SeasonData)) As Boolean
        Dim ret As Boolean = True

        ' 年度情報取得 
        Dim DBConnStr As String = My.Settings.DB
        Try
            Using con As New SqlConnection(DBConnStr)
                con.Open()
                Using cmd As SqlCommand = con.CreateCommand
                    Dim sql As New StringBuilder
                    sql.AppendLine("select [RegSeason] from [S_Season] with ( nolock ) ")
                    sql.AppendLine("where [LeagueCode] = @LeagueCode")
                    sql.AppendLine("and [LeagueDetailCode] = @LeagueDetailCode")

                    cmd.CommandText = sql.ToString
                    cmd.Parameters.Add("@LeagueCode", SqlDbType.Char, 2).Value = LeagueCode
                    cmd.Parameters.Add("@LeagueDetailCode", SqlDbType.Char, 2).Value = LeagueDetailCode

                    Using reader As SqlDataReader = cmd.ExecuteReader()

                        While reader.Read()
                            Dim item As New SeasonData

                            item.RegSeason = reader("RegSeason")
                            item.SeasonName = reader("RegSeason")

                            list.Add(item)
                        End While

                        Dim totalItem As New SeasonData
                        totalItem.RegSeason = "0"
                        totalItem.SeasonName = "(トータル)"
                        list.Add(totalItem)

                    End Using
                End Using
            End Using
        Catch ex As Exception
            SystemLog.ExceptionError(ex)
            ret = False
        End Try

        Return ret
    End Function

    Public Shared Function GetClubNum(ByVal item As SectionData) As Integer
        Dim clubNum As Integer = 0

        ' シーズン中のクラブ数取得 
        Dim DBConnStr As String = My.Settings.DB
        Try
            Using con As New SqlConnection(DBConnStr)
                con.Open()
                Using cmd As SqlCommand = con.CreateCommand
                    Dim sql As New StringBuilder
                    sql.AppendLine("select [ClubNum] from [S_Season] with ( nolock ) ")
                    sql.AppendLine("where [RegSeason] = @RegSeason")
                    sql.AppendLine("and [LeagueCode] = @LeagueCode")
                    sql.AppendLine("and [LeagueDetailCode] = @LeagueDetailCode")

                    cmd.CommandText = sql.ToString
                    cmd.Parameters.Add("@RegSeason", SqlDbType.Char, 4).Value = item.Year
                    cmd.Parameters.Add("@LeagueCode", SqlDbType.Char, 2).Value = item.LeagueCode
                    cmd.Parameters.Add("@LeagueDetailCode", SqlDbType.Char, 2).Value = item.LeagueDetailCode

                    Using reader As SqlDataReader = cmd.ExecuteReader()

                        If reader.Read() Then
                            clubNum = reader("ClubNum")
                        End If

                    End Using
                End Using
            End Using
        Catch ex As Exception
            SystemLog.ExceptionError(ex)
        End Try

        Return clubNum
    End Function

End Class
