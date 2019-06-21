Imports System.Data.SqlClient

Public Class CategoryService

    Public Shared List As New List(Of CategoryData)
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
                    cmd.CommandText = "select * from [M_Category] with ( nolock ) order by [CategoryCode]"
                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim item As New CategoryData
                            item.CategoryCode = reader("CategoryCode")
                            item.CategoryName = reader("Category")

                            List.Add(item)
                            CodeSet.Add(item.CategoryCode)
                        End While
                    End Using
                End Using
            End Using
        Catch ex As Exception
            SystemLog.ExceptionError(ex)
        End Try

    End Sub

    Public Shared Function GetList() As List(Of CategoryData)
        Return List
    End Function

    Public Shared Function GetData(Code As String) As CategoryData
        Dim obj As CategoryData = Nothing
        For Each item As CategoryData In List
            If Code = item.CategoryCode Then
                Return item
            End If
        Next
        Return Nothing
    End Function

End Class
