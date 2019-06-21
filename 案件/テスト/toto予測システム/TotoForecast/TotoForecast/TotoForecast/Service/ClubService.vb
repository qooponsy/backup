Imports System.Data.SqlClient
Imports System.Text

Public Class ClubService

    Public Shared List As New List(Of ClubData)
    Public Shared CodeSet As New HashSet(Of String)

    Public Shared Sub Init()
        List.Clear()
        CodeSet.Clear()

        ' クラブ詳細情報
        Dim DBConnStr As String = My.Settings.DB
        Try
            Using con As New SqlConnection(DBConnStr)
                con.Open()
                Using cmd As SqlCommand = con.CreateCommand
                    cmd.CommandText = "select * from [M_Club] with ( nolock ) order by [ClubCode]"
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim item As New ClubData
                            item.ClubCode = reader("ClubCode")
                            item.LeagueCode = reader("LeagueCode")
                            item.LeagueDetailCode = reader("LeagueDetailCode")
                            item.ClubName = reader("ClubName")
                            item.ShortName = reader("ShortName")

                            List.Add(item)
                            CodeSet.Add(item.LeagueCode)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            SystemLog.ExceptionError(ex)
        End Try

    End Sub

    Public Shared Function GetList() As List(Of ClubData)
        Return List
    End Function

    Public Shared Function Regist(ByVal LeagueCode As String,
                             ByVal LeagueDetail As String,
                             ByVal ClubName As String,
                             ByVal ClubKanaName As String,
                             ByVal ShortName As String) As Boolean

        Dim DBSuccess As Boolean = False
        Dim DBConnStr As String = My.Settings.DB
        Try
            Using con As New SqlConnection(DBConnStr)
                con.Open()
                Using cmd As SqlCommand = con.CreateCommand
                    Dim SQL As New StringBuilder
                    SQL.AppendLine("insert into [M_Club] values (")
                    SQL.AppendLine("    @LeagueCode")
                    SQL.AppendLine("    ,@LeagueDetail")
                    SQL.AppendLine("    ,@ClubName")
                    SQL.AppendLine("    ,@ClubKanaName")
                    SQL.AppendLine("    ,@ShortName")
                    SQL.AppendLine(")")
                    cmd.CommandText = SQL.ToString()

                    cmd.Parameters.Add("@LeagueCode", SqlDbType.Char, 2).Value = LeagueCode
                    cmd.Parameters.Add("@LeagueDetail", SqlDbType.Char, 2).Value = LeagueDetail
                    cmd.Parameters.Add("@ClubName", SqlDbType.NVarChar, 50).Value = ClubName
                    cmd.Parameters.Add("@ClubKanaName", SqlDbType.NVarChar, 80).Value = ClubKanaName
                    cmd.Parameters.Add("@ShortName", SqlDbType.NVarChar, 20).Value = ShortName

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
