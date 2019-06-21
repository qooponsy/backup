Imports System.Data.SqlClient
Imports System.Text

Public Class RankService

    Public Shared Function GetRankList(ByVal LeagueCode As String, ByVal LeagueDetailCode As String, ByVal Year As String, list As List(Of RankData)) As Boolean
        Dim ret As Boolean = True

        ' Rank情報取得 
        Dim DBConnStr As String = My.Settings.DB
        Try
            Using con As New SqlConnection(DBConnStr)
                con.Open()
                Using cmd As SqlCommand = con.CreateCommand
                    Dim sql As New StringBuilder
                    sql.AppendLine("select * from [T_Rank] with ( nolock ) ")
                    sql.AppendLine("where [LeagueCode] = @LeagueCode")
                    sql.AppendLine(" And [LeagueDetailCode] = @LeagueDetailCode")
                    sql.AppendLine(" And [Year] = @Year")
                    sql.AppendLine("order by [Rank]")

                    cmd.CommandText = sql.ToString
                    cmd.Parameters.Add("@LeagueCode", SqlDbType.Char, 2).Value = LeagueCode
                    cmd.Parameters.Add("@LeagueDetailCode", SqlDbType.Char, 2).Value = LeagueDetailCode
                    cmd.Parameters.Add("@Year", SqlDbType.Char, 4).Value = Year

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim item As New RankData

                            item.ClubCode = reader("ClubCode")
                            item.LeagueCode = reader("LeagueCode")
                            item.LeagueDetailCode = reader("LeagueDetailCode")
                            item.Year = reader("Year")
                            item.CurrentYear = reader("CurrentYear")
                            item.Rank = reader("Rank")
                            item.Points = reader("Points")
                            item.Win = reader("Win")
                            item.Lose = reader("Lose")
                            item.Draw = reader("Draw")
                            item.Score = reader("Score")
                            item.LostScore = reader("LostScore")
                            item.ScoreDiff = reader("ScoreDiff")

                            list.Add(item)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            SystemLog.ExceptionError(ex)
            ret = False
        End Try


        Return ret
    End Function

    Public Shared Function Regist(ByVal ClubCode As String, ByVal LeagueCode As String, ByVal LeagueDetailCode As String)

        Dim DBSuccess As Boolean = False
        Dim DBConnStr As String = My.Settings.DB
        Try
            Using con As New SqlConnection(DBConnStr)
                con.Open()
                Using cmd As SqlCommand = con.CreateCommand
                    Dim SQL As New StringBuilder
                    SQL.AppendLine("insert into [T_Rank] values (")
                    SQL.AppendLine("    @ClubCode")
                    SQL.AppendLine("    ,@LeagueCode")
                    SQL.AppendLine("    ,@LeagueDetail")
                    SQL.AppendLine("    ,@Year")
                    SQL.AppendLine("    ,@CurrentYear")
                    SQL.AppendLine("    ,@Rank")
                    SQL.AppendLine("    ,@Points")
                    SQL.AppendLine("    ,@Win")
                    SQL.AppendLine("    ,@Lose")
                    SQL.AppendLine("    ,@Draw")
                    SQL.AppendLine("    ,@Score")
                    SQL.AppendLine("    ,@LostScore")
                    SQL.AppendLine("    ,@ScoreDiff")
                    SQL.AppendLine(")")
                    cmd.CommandText = SQL.ToString()

                    cmd.Parameters.Add("@ClubCode", SqlDbType.Int).Value = ClubCode
                    cmd.Parameters.Add("@LeagueCode", SqlDbType.Char, 2).Value = LeagueCode
                    cmd.Parameters.Add("@LeagueDetail", SqlDbType.Char, 2).Value = LeagueDetailCode
                    cmd.Parameters.Add("@Year", SqlDbType.VarChar, 4).Value = Now.Year
                    cmd.Parameters.Add("@CurrentYear", SqlDbType.Int).Value = 0
                    cmd.Parameters.Add("@Rank", SqlDbType.Int).Value = 0
                    cmd.Parameters.Add("@Points", SqlDbType.Int).Value = 0
                    cmd.Parameters.Add("@Win", SqlDbType.Int).Value = 0
                    cmd.Parameters.Add("@Lose", SqlDbType.Int).Value = 0
                    cmd.Parameters.Add("@Draw", SqlDbType.Int).Value = 0
                    cmd.Parameters.Add("@Score", SqlDbType.Int).Value = 0
                    cmd.Parameters.Add("@LostScore", SqlDbType.Int).Value = 0
                    cmd.Parameters.Add("@ScoreDiff", SqlDbType.Int).Value = 0

                    Dim insData As Integer = cmd.ExecuteNonQuery()
                    If insData > 0 Then
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
