Imports System.Data.SqlClient
Imports System.Text

Public Class MatchService

    Private Const MATCH_CLUB_NUM As Integer = 2



    Public Shared Function Regist(ByRef section As SectionData, ByRef MatchList As List(Of MatchData)) As Boolean

        Dim DBSuccess As Boolean = False
        Dim DBConnStr As String = My.Settings.DB
        Try
            ' セクションを更新
            Using con As New SqlConnection(DBConnStr)
                con.Open()
                ' 試合情報挿入
                Using cmd As SqlCommand = con.CreateCommand
                    Dim SQL As New StringBuilder
                    For i As Integer = 0 To MatchList.Count - 1
                        Dim item As MatchData = MatchList(i)

                        SQL.AppendLine("insert into [T_Match] values (")
                        SQL.AppendLine("     @SectionCode")
                        SQL.AppendLine("    ,@Section")
                        SQL.AppendLine("    ,@HomeClubCode" & i)
                        SQL.AppendLine("    ,@AwayClubCode" & i)
                        SQL.AppendLine("    ,@toto")
                        SQL.AppendLine("    ,@Status")
                        SQL.AppendLine("    ,@Result")
                        SQL.AppendLine(")")

                        cmd.Parameters.Add("@HomeClubCode" & i, SqlDbType.Int).Value = item.HomeClubCode
                        cmd.Parameters.Add("@AwayClubCode" & i, SqlDbType.Int).Value = item.AwayClubCode
                    Next

                    cmd.Parameters.Add("@SectionCode", SqlDbType.BigInt).Value = section.SectionCode
                    cmd.Parameters.Add("@Section", SqlDbType.Int).Value = section.Section
                    cmd.Parameters.Add("@toto", SqlDbType.Int).Value = 0
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Value = MatchData.MatchStatus.MatchInput
                    cmd.Parameters.Add("@Result", SqlDbType.Int).Value = -1

                    cmd.CommandText = SQL.ToString()

                    Dim insData As Integer = cmd.ExecuteNonQuery()
                    If insData > 0 Then
                        DBSuccess = True
                    End If
                End Using

                If DBSuccess Then
                    Using cmd As SqlCommand = con.CreateCommand
                        Dim SQL As New StringBuilder
                        SQL.AppendLine("update [T_Section] set ")
                        SQL.AppendLine("     [Section] = @Section + 1 ")
                        SQL.AppendLine("    where [SectionCode] = @SectionCode")

                        cmd.CommandText = SQL.ToString()

                        cmd.Parameters.Add("@SectionCode", SqlDbType.BigInt).Value = section.SectionCode
                        cmd.Parameters.Add("@Section", SqlDbType.Int).Value = section.Section

                        Dim insData As Integer = cmd.ExecuteNonQuery()
                        If insData > 0 Then
                            DBSuccess = True
                        End If

                    End Using
                End If

            End Using

        Catch ex As Exception
            SystemLog.ExceptionError(ex)
        End Try

        Return DBSuccess
    End Function

    Public Shared Function Update(ByRef section As SectionData, ByRef MatchList As List(Of MatchData)) As Boolean

        Dim DBSuccess As Boolean = False
        Dim DBConnStr As String = My.Settings.DB
        Try
            ' セクションを更新
            Using con As New SqlConnection(DBConnStr)
                con.Open()

                ' 更新セクションを削除
                Using cmd As SqlCommand = con.CreateCommand
                    Dim SQL As New StringBuilder
                    SQL.AppendLine("delete [T_Match] where [Section] = @Section")

                    cmd.Parameters.Add("@Section", SqlDbType.Int).Value = section.Section
                    cmd.CommandText = SQL.ToString()

                    Dim dleData As Integer = cmd.ExecuteNonQuery()
                    If dleData > 0 Then
                        DBSuccess = True
                    End If
                End Using

                ' 試合情報挿入
                Using cmd As SqlCommand = con.CreateCommand
                    Dim SQL As New StringBuilder
                    For i As Integer = 0 To MatchList.Count - 1
                        Dim item As MatchData = MatchList(i)
                        SQL.AppendLine("delete [T_Match] where [Section] = @Section")
                        SQL.AppendLine("insert into [T_Match] values (")
                        SQL.AppendLine("     @SectionCode")
                        SQL.AppendLine("    ,@Section")
                        SQL.AppendLine("    ,@HomeClubCode" & i)
                        SQL.AppendLine("    ,@AwayClubCode" & i)
                        SQL.AppendLine("    ,@toto")
                        SQL.AppendLine("    ,@Status")
                        SQL.AppendLine("    ,@Result")
                        SQL.AppendLine(")")

                        cmd.Parameters.Add("@HomeClubCode" & i, SqlDbType.Int).Value = item.HomeClubCode
                        cmd.Parameters.Add("@AwayClubCode" & i, SqlDbType.Int).Value = item.AwayClubCode
                    Next

                    cmd.Parameters.Add("@SectionCode", SqlDbType.BigInt).Value = section.SectionCode
                    cmd.Parameters.Add("@Section", SqlDbType.Int).Value = section.Section
                    cmd.Parameters.Add("@toto", SqlDbType.Int).Value = 0
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Value = MatchData.MatchStatus.MatchInput
                    cmd.Parameters.Add("@Result", SqlDbType.Int).Value = -1

                    cmd.CommandText = SQL.ToString()

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

    Public Shared Function GetMatchList(ByVal section As SectionData) As List(Of MatchData)
        Dim List As New List(Of MatchData)

        ' クラブ詳細情報
        Dim DBConnStr As String = My.Settings.DB
        Try
            Using con As New SqlConnection(DBConnStr)
                con.Open()
                Using cmd As SqlCommand = con.CreateCommand
                    Dim sql As New StringBuilder
                    sql.AppendLine("select * from T_Match with ( nolock )")
                    sql.AppendLine("where [SectionCode] = @SectionCode")
                    sql.AppendLine("and [Section] = @Section")
                    sql.AppendLine("order by [MatchCode]")

                    cmd.CommandText = sql.ToString
                    cmd.Parameters.Add("@SectionCode", SqlDbType.BigInt).Value = section.SectionCode
                    cmd.Parameters.Add("@Section", SqlDbType.Int).Value = section.Section

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim item As New MatchData
                            item.MatchCode = reader("MatchCode")
                            item.SectionCode = reader("SectionCode")
                            item.Section = reader("Section")
                            item.HomeClubCode = reader("HomeClubCode")
                            item.AwayClubCode = reader("AwayClubCode")
                            item.toto = reader("toto")
                            item.Status = reader("Status")
                            item.Result = reader("Result")

                            List.Add(item)
                        End While
                    End Using
                End Using
            End Using

        Catch ex As Exception
            SystemLog.ExceptionError(ex)
        End Try

        Return List
    End Function

    Public Shared Function GetMatchSectionList(ByVal sectionCode As Long, ByRef list As List(Of SectionData)) As Boolean
        Dim ret As Boolean = True

        ' クラブ詳細情報
        Dim DBConnStr As String = My.Settings.DB
        Try
            Using con As New SqlConnection(DBConnStr)
                con.Open()
                Using cmd As SqlCommand = con.CreateCommand
                    Dim sql As New StringBuilder
                    sql.AppendLine("select [Section] from [T_Match] with ( nolock )")
                    sql.AppendLine("where [SectionCode] = @SectionCode")
                    sql.AppendLine("and [Status] = @Status")
                    sql.AppendLine("group by [Section]")
                    sql.AppendLine("order by [Section] desc")

                    cmd.CommandText = sql.ToString
                    cmd.Parameters.Add("@SectionCode", SqlDbType.BigInt).Value = sectionCode
                    cmd.Parameters.Add("@Status", SqlDbType.Int).Value = MatchData.MatchStatus.MatchInput

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim item As New SectionData
                            item.Section = reader("Section")
                            item.SectionView = reader("Section")

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
