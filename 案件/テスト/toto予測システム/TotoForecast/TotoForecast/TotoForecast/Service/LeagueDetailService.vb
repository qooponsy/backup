Imports System.Data.SqlClient

Public Class LeagueDetailService

    Public Shared List As New List(Of LeagueDetailData)
    Public Shared CodeSet As New HashSet(Of String)

    Public Shared Sub Init()
        List.Clear()
        CodeSet.Clear()

        ' League情報取得 
        Dim DBConnStr As String = My.Settings.DB
        Try
            Using con As New SqlConnection(DBConnStr)
                con.Open()
                Using cmd As SqlCommand = con.CreateCommand
                    cmd.CommandText = "select * from [M_LeagueDetail] with ( nolock ) order by [LeagueDetailCode]"
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim item As New LeagueDetailData
                            item.LeagueDetailCode = reader("LeagueDetailCode")
                            item.LeagueCode = reader("LeagueCode")
                            item.LeagueDetailName = reader("LeagueDetailName")

                            List.Add(item)
                            CodeSet.Add(item.LeagueDetailCode)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            SystemLog.ExceptionError(ex)
        End Try

    End Sub

    Public Shared Function GetList() As List(Of LeagueDetailData)
        Return List
    End Function

    Public Shared Function GetViewList(code As String) As List(Of LeagueDetailData)
        Dim retList As New List(Of LeagueDetailData)

        For Each item As LeagueDetailData In List
            If code = item.LeagueCode Then
                retList.Add(item)
            End If
        Next

        Return retList
    End Function

End Class
