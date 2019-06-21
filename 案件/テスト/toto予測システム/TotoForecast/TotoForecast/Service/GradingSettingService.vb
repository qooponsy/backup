Imports System.Data.SqlClient
Imports System.Text

Public Class GradingSettingService

    Public Shared Function GetGradingSettingList(ByRef list As List(Of GradingSettingData)) As Boolean
        Dim ret As Boolean = True

        ' 採点設定情報取得 
        Dim DBConnStr As String = My.Settings.DB
        Try
            Using con As New SqlConnection(DBConnStr)
                con.Open()
                Using cmd As SqlCommand = con.CreateCommand
                    Dim sql As New StringBuilder
                    sql.AppendLine("select ")
                    sql.AppendLine("  gs.[GradingSettingCode] as gs_GradingSettingCode")
                    sql.AppendLine(" ,gs.[GradingSetting] as gs_GradingSetting")
                    sql.AppendLine(" ,gs.[Memo] as gs_Memo")
                    sql.AppendLine(" ,gs.[buy] as gs_buy")
                    sql.AppendLine(" ,gs.[DrawValue] as gs_DrawValue")
                    sql.AppendLine(" ,gs.[EqualValue] as gs_EqualValue")
                    sql.AppendLine(" ,ac.[ForecastCount] as ac_ForecastCount")
                    sql.AppendLine(" ,ac.[CorrectAnsAve] as ac_CorrectAnsAve")
                    sql.AppendLine(" ,ac.[CorrectAnsMax] as ac_CorrectAnsMax")
                    sql.AppendLine(" ,ac.[PrizeCount] as ac_PrizeCount")
                    sql.AppendLine("from [M_GradingSetting] gs with ( nolock ) ")
                    sql.AppendLine("left join [T_Achievement] ac with ( nolock )")
                    sql.AppendLine("on gs.[GradingSettingCode] = ac.[GradingSettingCode]")
                    sql.AppendLine("order by gs.[buy] desc, ac.[CorrectAnsAve]")

                    cmd.CommandText = sql.ToString

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim item As New GradingSettingData

                            item.GradingSettingCode = reader("gs_GradingSettingCode")
                            item.GradingSetting = reader("gs_GradingSetting")
                            item.Memo = reader("gs_Memo")
                            item.buy = reader("gs_buy")
                            item.DrawValue = reader("gs_DrawValue")
                            item.EqualValue = reader("gs_EqualValue")

                            item.ForecastCount = reader("ac_ForecastCount")
                            item.CorrectAnsAve = reader("ac_CorrectAnsAve")
                            item.CorrectAnsMax = reader("ac_CorrectAnsMax")
                            item.PrizeCount = reader("ac_PrizeCount")

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

    Public Shared Function GetHeaderData(ByVal code As String) As GradingSettingData
        Dim SettingObject As New GradingSettingData

        ' 採点設定情報
        Dim DBConnStr As String = My.Settings.DB
        Try
            Using con As New SqlConnection(DBConnStr)
                con.Open()
                Using cmd As SqlCommand = con.CreateCommand
                    Dim sql As New StringBuilder
                    sql.AppendLine("select * from [M_GradingSetting]  with ( nolock )")
                    sql.AppendLine("where [GradingSettingCode] = @GradingSettingCode")

                    cmd.CommandText = sql.ToString
                    cmd.Parameters.Add("@GradingSettingCode", SqlDbType.Int).Value = code

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            SettingObject.GradingSettingCode = reader("GradingSettingCode")
                            SettingObject.GradingSetting = reader("GradingSetting")
                            SettingObject.Memo = reader("Memo")
                            SettingObject.buy = reader("buy")
                            SettingObject.DrawValue = reader("DrawValue")
                            SettingObject.EqualValue = reader("EqualValue")
                        End If
                    End Using
                End Using
            End Using

        Catch ex As Exception
            SystemLog.ExceptionError(ex)
        End Try

        Return SettingObject
    End Function

    Public Shared Function GetDetailDataList(ByVal code As String) As List(Of GradingSettingDetailData)
        Dim list As New List(Of GradingSettingDetailData)

        ' 採点設定情報
        Dim DBConnStr As String = My.Settings.DB
        Try
            Using con As New SqlConnection(DBConnStr)
                con.Open()
                Using cmd As SqlCommand = con.CreateCommand
                    Dim sql As New StringBuilder
                    sql.AppendLine("select * from [M_GradingSettingDetail]  with ( nolock )")
                    sql.AppendLine("where [GradingSettingCode] = @GradingSettingCode")

                    cmd.CommandText = sql.ToString
                    cmd.Parameters.Add("@GradingSettingCode", SqlDbType.Int).Value = code

                    Using reader As SqlDataReader = cmd.ExecuteReader()
                        While reader.Read()
                            Dim item As New GradingSettingDetailData

                            item.GradingSettingDetailCode = reader("GradingSettingDetailCode")
                            item.GradingSettingCode = reader("GradingSettingCode")
                            item.CategoryCode = reader("CategoryCode")
                            item.Magnification = reader("Magnification")

                            list.Add(item)
                        End While
                    End Using
                End Using
            End Using

        Catch ex As Exception
            SystemLog.ExceptionError(ex)
        End Try

        Return list
    End Function

    Public Shared Function Regist(ByRef headerItem As GradingSettingData, ByRef detailItemList As List(Of GradingSettingDetailData)) As Boolean
        Dim DBSuccess As Boolean = False
        Dim DBConnStr As String = My.Settings.DB

        Try
            Dim GradingSettingCode As Integer
            Using con As New SqlConnection(DBConnStr)
                con.Open()

                ' 採点設定（ヘッダ）を登録
                Using cmd As SqlCommand = con.CreateCommand
                    Dim SQL As New StringBuilder
                    SQL.AppendLine("insert into [M_GradingSetting] values (")
                    SQL.AppendLine("     @GradingSetting")
                    SQL.AppendLine("    ,@buy")
                    SQL.AppendLine("    ,@Memo")
                    SQL.AppendLine("    ,@DrawValue")
                    SQL.AppendLine("    ,@EqualValue")
                    SQL.AppendLine(")")
                    SQL.AppendLine("select @id = IDENT_CURRENT('M_GradingSetting')")
                    cmd.CommandText = SQL.ToString()

                    cmd.Parameters.Add("@GradingSetting", SqlDbType.NVarChar, 100).Value = headerItem.GradingSetting
                    cmd.Parameters.Add("@buy", SqlDbType.Char, 1).Value = headerItem.buy
                    cmd.Parameters.Add("@Memo", SqlDbType.NVarChar, 100).Value = headerItem.Memo
                    cmd.Parameters.Add("@DrawValue", SqlDbType.Int).Value = headerItem.DrawValue
                    cmd.Parameters.Add("@EqualValue", SqlDbType.Int).Value = headerItem.EqualValue

                    cmd.Parameters.Add("@id", SqlDbType.Int).Direction = ParameterDirection.Output

                    Dim insData As Integer = cmd.ExecuteNonQuery()
                    If insData > 0 Then
                        GradingSettingCode = cmd.Parameters("@id").Value
                        DBSuccess = True
                    End If
                End Using

                ' 採点設定（詳細）を登録
                If DBSuccess Then
                    For Each item As GradingSettingDetailData In detailItemList
                        Using cmd As SqlCommand = con.CreateCommand
                            Dim SQL As New StringBuilder
                            SQL.AppendLine("insert into [M_GradingSettingDetail] values (")
                            SQL.AppendLine("     @GradingSettingCode")
                            SQL.AppendLine("    ,@CategoryCode")
                            SQL.AppendLine("    ,@Magnification")
                            SQL.AppendLine(")")
                            cmd.CommandText = SQL.ToString()

                            cmd.Parameters.Add("@GradingSettingCode", SqlDbType.Int).Value = GradingSettingCode
                            cmd.Parameters.Add("@CategoryCode", SqlDbType.Int).Value = item.CategoryCode
                            cmd.Parameters.Add("@Magnification", SqlDbType.Int).Value = item.Magnification

                            Dim insData As Integer = cmd.ExecuteNonQuery
                            If insData <= 0 Then
                                DBSuccess = False
                                Exit For
                            End If
                        End Using
                    Next

                End If

                ' 採点設定（成果）を登録
                If DBSuccess Then
                    Using cmd As SqlCommand = con.CreateCommand
                        Dim SQL As New StringBuilder
                        SQL.AppendLine("insert into [T_Achievement] values (")
                        SQL.AppendLine("     @GradingSettingCode")
                        SQL.AppendLine("    ,0")
                        SQL.AppendLine("    ,0")
                        SQL.AppendLine("    ,0")
                        SQL.AppendLine("    ,0")
                        SQL.AppendLine(")")
                        cmd.CommandText = SQL.ToString()

                        cmd.Parameters.Add("@GradingSettingCode", SqlDbType.Int).Value = GradingSettingCode

                        Dim insData As Integer = cmd.ExecuteNonQuery
                        If insData <= 0 Then
                            DBSuccess = False
                        End If
                    End Using
                End If

            End Using

        Catch ex As Exception
            SystemLog.ExceptionError(ex)
            DBSuccess = False
        End Try

        Return DBSuccess
    End Function

    Public Shared Function Update(ByVal GradingSettingCode As String, ByRef headerItem As GradingSettingData, ByRef detailItemList As List(Of GradingSettingDetailData)) As Boolean

        Dim DBSuccess As Boolean = False
        Dim DBConnStr As String = My.Settings.DB
        Try

            ' 採点設定更新
            Using con As New SqlConnection(DBConnStr)
                con.Open()
                Using cmd As SqlCommand = con.CreateCommand
                    Dim SQL As New StringBuilder
                    SQL.AppendLine("update [M_GradingSetting] set ")
                    SQL.AppendLine("     [GradingSetting] = @GradingSetting")
                    SQL.AppendLine("    ,[Memo] = @Memo")
                    SQL.AppendLine("    ,[buy] = @buy")
                    SQL.AppendLine("    ,[DrawValue] = @DrawValue")
                    SQL.AppendLine("    ,[EqualValue] = @EqualValue")
                    SQL.AppendLine("where [GradingSettingCode] = @GradingSettingCode")
                    cmd.CommandText = SQL.ToString()

                    cmd.Parameters.Add("@GradingSettingCode", SqlDbType.NVarChar, 30).Value = GradingSettingCode

                    cmd.Parameters.Add("@GradingSetting", SqlDbType.NVarChar, 100).Value = headerItem.GradingSetting
                    cmd.Parameters.Add("@buy", SqlDbType.Char, 1).Value = headerItem.buy
                    cmd.Parameters.Add("@Memo", SqlDbType.NVarChar, 100).Value = headerItem.Memo
                    cmd.Parameters.Add("@DrawValue", SqlDbType.Int).Value = headerItem.DrawValue
                    cmd.Parameters.Add("@EqualValue", SqlDbType.Int).Value = headerItem.EqualValue

                    Dim insData As Integer = cmd.ExecuteNonQuery()
                    If insData > 0 Then
                        DBSuccess = True
                    End If
                End Using

                ' 採点設定（詳細）更新
                For Each item In detailItemList
                    Using cmd As SqlCommand = con.CreateCommand
                        Dim SQL As New StringBuilder
                        SQL.AppendLine("update [M_GradingSettingDetail] set ")
                        SQL.AppendLine("     [Magnification] = @Magnification")
                        SQL.AppendLine("where [GradingSettingCode] = @GradingSettingCode")
                        SQL.AppendLine("  and [CategoryCode] = @CategoryCode")
                        cmd.CommandText = SQL.ToString()

                        cmd.Parameters.Add("@GradingSettingCode", SqlDbType.NVarChar, 30).Value = GradingSettingCode
                        cmd.Parameters.Add("@CategoryCode", SqlDbType.Int).Value = item.CategoryCode
                        cmd.Parameters.Add("@Magnification", SqlDbType.Int).Value = item.Magnification

                        Dim insData As Integer = cmd.ExecuteNonQuery()
                        If insData > 0 Then
                            DBSuccess = True
                        End If
                    End Using
                Next

            End Using

        Catch ex As Exception
            SystemLog.ExceptionError(ex)
        End Try

        Return DBSuccess
    End Function

End Class
