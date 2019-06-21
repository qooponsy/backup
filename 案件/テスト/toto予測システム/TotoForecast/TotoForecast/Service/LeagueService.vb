Imports System.Data.SqlClient

Public Class LeagueService

    'Private Shared DataList As New List(Of LeagueData)
    Public Shared List As New List(Of LeagueData)
    Public Shared CodeSet As New HashSet(Of String)

    Public Class LeagueCategory
        Public Const JLeague As String = "01"
    End Class

    Public Shared Sub Init()
        List.Clear()
        CodeSet.Clear()

        ' League情報取得 
        Dim DBConnStr As String = My.Settings.DB
        Try
            Using con As New SqlConnection(DBConnStr)
                con.Open()
                Using cmd As SqlCommand = con.CreateCommand
                    cmd.CommandText = "select * from [M_League] with ( nolock ) order by [LeagueCode]"
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim item As New LeagueData
                            item.LeagueCode = reader("LeagueCode")
                            item.LeagueName = reader("LeagueName")
                            item.Country = reader("Country")

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

    Public Shared Function GetList() As List(Of LeagueData)
        Return List
    End Function

    Public Shared Function GetViewList() As List(Of LeagueData)
        Dim retList As New List(Of LeagueData)

        Dim item As New LeagueData
        item.LeagueCode = ""
        item.LeagueName = ""

        retList.Add(item)
        retList.AddRange(List)

        Return retList
    End Function

    Public Shared Function GetData(Code As String) As LeagueData
        Dim obj As LeagueData = Nothing
        For Each item As LeagueData In List
            If Code = item.LeagueCode Then
                Return item
            End If
        Next
        Return Nothing
    End Function

End Class
