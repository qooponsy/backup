Imports System.Data.SqlClient
Imports System.Text

Public Class ClubService

    Public Shared Function GetList(ByVal LeagueCode As String, ByRef list As List(Of ClubData)) As Boolean
        Dim ret As Boolean = True

        ' クラブ詳細情報
        Dim DBConnStr As String = My.Settings.DB
        Try
            Using con As New SqlConnection(DBConnStr)
                con.Open()
                Using cmd As SqlCommand = con.CreateCommand
                    Dim sql As New StringBuilder
                    sql.AppendLine("select * from [M_Club] with ( nolock )")
                    sql.AppendLine("where [LeagueCode] = @LeagueCode")
                    sql.AppendLine("order by [LeagueDetailCode],[ClubCode]")

                    cmd.CommandText = sql.ToString
                    cmd.Parameters.Add("@LeagueCode", SqlDbType.Char, 2).Value = LeagueCode

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim item As New ClubData
                            item.ClubCode = reader("ClubCode")
                            item.LeagueCode = reader("LeagueCode")
                            item.LeagueDetailCode = reader("LeagueDetailCode")
                            item.ClubName = reader("ClubName")
                            item.ClubNameKana = reader("ClubNameKana")
                            item.ShortName = reader("ShortName")
                            item.ShortNameKana = reader("ShortNameKana")

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

    Public Shared Function GetLeagueList(ByVal LeagueCode As String, ByVal LeagueDetailCode As String) As List(Of ClubData)
        Dim list As New List(Of ClubData)

        Dim nullItem As New ClubData
        nullItem.ViewName = ""
        list.Add(nullItem)

        ' クラブ詳細情報
        Dim DBConnStr As String = My.Settings.DB
        Try
            Using con As New SqlConnection(DBConnStr)
                con.Open()
                Using cmd As SqlCommand = con.CreateCommand
                    Dim sql As New StringBuilder
                    sql.AppendLine("select * from [M_Club] with ( nolock )")
                    sql.AppendLine("where [LeagueCode] = @LeagueCode")
                    sql.AppendLine("and [LeagueDetailCode] = @LeagueDetailCode")
                    sql.AppendLine("order by [ShortNameKana]")

                    cmd.CommandText = sql.ToString
                    cmd.Parameters.Add("@LeagueCode", SqlDbType.Char, 2).Value = LeagueCode
                    cmd.Parameters.Add("@LeagueDetailCode", SqlDbType.Char, 2).Value = LeagueDetailCode

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim item As New ClubData
                            item.ClubCode = reader("ClubCode")
                            item.LeagueCode = reader("LeagueCode")
                            item.LeagueDetailCode = reader("LeagueDetailCode")
                            item.ClubName = reader("ClubName")
                            item.ClubNameKana = reader("ClubNameKana")
                            item.ShortName = reader("ShortName")
                            item.ShortNameKana = reader("ShortNameKana")

                            item.ViewName = item.ShortNameKana.Substring(0, 1) & " : " & item.ShortName

                            list.Add(item)
                        End While
                    End Using
                End Using
            End Using

            If List.Count = 0 Then

            End If

        Catch ex As Exception
            SystemLog.ExceptionError(ex)
        End Try

        Return list
    End Function

    Public Shared Function Regist(ByVal item As ClubData) As Boolean

        Dim DBSuccess As Boolean = False
        Dim DBConnStr As String = My.Settings.DB
        Try
            Using con As New SqlConnection(DBConnStr)
                con.Open()
                Using cmd As SqlCommand = con.CreateCommand
                    Dim SQL As New StringBuilder
                    SQL.AppendLine("insert into [M_Club] values (")
                    SQL.AppendLine("     @LeagueCode")
                    SQL.AppendLine("    ,@LeagueDetailCode")
                    SQL.AppendLine("    ,@ClubName")
                    SQL.AppendLine("    ,@ClubNameKana")
                    SQL.AppendLine("    ,@ShortName")
                    SQL.AppendLine("    ,@ShortNameKana")
                    SQL.AppendLine(")")
                    SQL.AppendLine("select @ClubCode = IDENT_CURRENT('M_Club')")
                    SQL.AppendLine("insert into [T_Rank] values (")
                    SQL.AppendLine("    @ClubCode")
                    SQL.AppendLine("    ,@LeagueCode")
                    SQL.AppendLine("    ,@LeagueDetailCode")
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

                    Dim param As SqlParameter
                    param = cmd.Parameters.Add("@ClubCode", SqlDbType.Int)
                    param.Direction = ParameterDirection.Output

                    cmd.Parameters.Add("@LeagueCode", SqlDbType.Char, 2).Value = item.LeagueCode
                    cmd.Parameters.Add("@LeagueDetailCode", SqlDbType.Char, 2).Value = item.LeagueDetailCode
                    cmd.Parameters.Add("@ClubName", SqlDbType.NVarChar, 50).Value = item.ClubName
                    cmd.Parameters.Add("@ClubNameKana", SqlDbType.NVarChar, 80).Value = item.ClubNameKana
                    cmd.Parameters.Add("@ShortName", SqlDbType.NVarChar, 20).Value = item.ShortName
                    cmd.Parameters.Add("@ShortNameKana", SqlDbType.NVarChar, 30).Value = item.ShortNameKana

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

    Public Shared Function CsvDataRegist(ByVal path As String) As Boolean
        Dim ret As Boolean = True

        'CSV形式ファイルパスを設定してください。
        Dim objFile As New System.IO.StreamReader(path)

        Dim strLine As String       '１行
        Dim strTemp() As String     '戻り配列

        '次の行へ
        strLine = objFile.ReadLine()
        While (strLine <> "")
            Try
                '行単位データをカンマ部分で分割し、配列へ格納
                strTemp = Split(strLine, ",")

                Dim item As New ClubData

                item.LeagueCode = strTemp(0)
                item.LeagueDetailCode = strTemp(1)
                item.ClubName = strTemp(2)
                item.ClubNameKana = strTemp(3)
                item.ShortName = strTemp(4)
                item.ShortNameKana = strTemp(5)

                ' 登録
                Regist(item)

            Catch ex As Exception
                ret = False
            End Try
            '次の行へ
            strLine = objFile.ReadLine()
        End While


        'ファイルのクローズ
        objFile.Close()

        Return ret
    End Function

    Public Shared Function Update(ByVal item As ClubData) As Boolean

        Dim DBSuccess As Boolean = False
        Dim DBConnStr As String = My.Settings.DB
        Try
            Using con As New SqlConnection(DBConnStr)
                con.Open()
                Using cmd As SqlCommand = con.CreateCommand
                    Dim SQL As New StringBuilder
                    SQL.AppendLine("update [M_Club] set ")
                    SQL.AppendLine("     [LeagueCode] = @LeagueCode")
                    SQL.AppendLine("    ,[LeagueDetailCode] = @LeagueDetailCode")
                    SQL.AppendLine("    ,[ClubName] = @ClubName")
                    SQL.AppendLine("    ,[ClubNameKana] = @ClubNameKana")
                    SQL.AppendLine("    ,[ShortName] = @ShortName")
                    SQL.AppendLine("    ,[ShortNameKana] = @ShortNameKana")
                    SQL.AppendLine("where [ClubCode] = @ClubCode")
                    cmd.CommandText = SQL.ToString()

                    cmd.Parameters.Add("@LeagueCode", SqlDbType.Char, 2).Value = item.LeagueCode
                    cmd.Parameters.Add("@LeagueDetailCode", SqlDbType.Char, 2).Value = item.LeagueDetailCode
                    cmd.Parameters.Add("@ClubName", SqlDbType.NVarChar, 50).Value = item.ClubName
                    cmd.Parameters.Add("@ClubNameKana", SqlDbType.NVarChar, 80).Value = item.ClubNameKana
                    cmd.Parameters.Add("@ShortName", SqlDbType.NVarChar, 20).Value = item.ShortName
                    cmd.Parameters.Add("@ShortNameKana", SqlDbType.NVarChar, 30).Value = item.ShortNameKana
                    cmd.Parameters.Add("@ClubCode", SqlDbType.Int).Value = item.ClubCode

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

    Public Shared Function GetData(ByVal ClubCode As Integer) As ClubData
        Dim ClubObject As New ClubData

        ' クラブ詳細情報
        Dim DBConnStr As String = My.Settings.DB
        Try
            Using con As New SqlConnection(DBConnStr)
                con.Open()
                Using cmd As SqlCommand = con.CreateCommand
                    Dim sql As New StringBuilder
                    sql.AppendLine("select * from [M_Club] with ( nolock )")
                    sql.AppendLine("where [ClubCode] = @ClubCode")

                    cmd.CommandText = sql.ToString
                    cmd.Parameters.Add("@ClubCode", SqlDbType.Int).Value = ClubCode

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            ClubObject.ClubCode = reader("ClubCode")
                            ClubObject.LeagueCode = reader("LeagueCode")
                            ClubObject.LeagueDetailCode = reader("LeagueDetailCode")
                            ClubObject.ClubName = reader("ClubName")
                            ClubObject.ClubNameKana = reader("ClubNameKana")
                            ClubObject.ShortName = reader("ShortName")
                            ClubObject.ShortNameKana = reader("ShortNameKana")
                        End If
                    End Using
                End Using
            End Using

        Catch ex As Exception
            SystemLog.ExceptionError(ex)
        End Try

        Return ClubObject
    End Function

    Public Shared Function GetViewData(ByVal ClubCode As Integer) As String
        Dim ViewName As String = ""

        ' クラブ詳細情報
        Dim DBConnStr As String = My.Settings.DB
        Try
            Using con As New SqlConnection(DBConnStr)
                con.Open()
                Using cmd As SqlCommand = con.CreateCommand
                    Dim sql As New StringBuilder
                    sql.AppendLine("select * from [M_Club] with ( nolock )")
                    sql.AppendLine("where [ClubCode] = @ClubCode")

                    cmd.CommandText = sql.ToString
                    cmd.Parameters.Add("@ClubCode", SqlDbType.Int).Value = ClubCode

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then

                            Dim ShortName As String = reader("ShortName")
                            Dim ShortNameKana As String = reader("ShortNameKana")

                            ViewName = ShortNameKana.Substring(0, 1) & " : " & ShortName
                        End If
                    End Using
                End Using
            End Using

        Catch ex As Exception
            SystemLog.ExceptionError(ex)
        End Try

        Return ViewName
    End Function

End Class
