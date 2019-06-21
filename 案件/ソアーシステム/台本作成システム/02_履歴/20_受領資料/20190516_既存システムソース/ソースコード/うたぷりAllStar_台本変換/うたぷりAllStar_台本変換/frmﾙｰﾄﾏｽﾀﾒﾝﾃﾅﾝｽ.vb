Public Class frmﾙｰﾄﾏｽﾀﾒﾝﾃﾅﾝｽ

    Private Sub frmﾙｰﾄﾏｽﾀﾒﾝﾃﾅﾝｽ_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim sCnn As SqlClient.SqlConnection = New SqlClient.SqlConnection
        Dim dApt As SqlClient.SqlDataAdapter
        Dim dTbl As Data.DataTable = New Data.DataTable

        Dim StrSQL As String

        StrSQL = "SELECT "
        StrSQL &= "No,"
        StrSQL &= "ﾙｰﾄ AS ルート名,"
        StrSQL &= "記号 "
        StrSQL &= "FROM 台本変換_うたぷりAllStar_ﾙｰﾄﾏｽﾀ "

        sCnn.ConnectionString = DB.DBBR
        sCnn.Open()

        dApt = New SqlClient.SqlDataAdapter(StrSQL, sCnn)
        dApt.Fill(dTbl)

        Me.GrdItem.DataSource = dTbl

        If sCnn.State <> ConnectionState.Closed Then sCnn.Close()

        sCnn.Dispose()

        With Me.GrdItem

            .Columns(0).Visible = False
            .Columns(1).Width = 300
            .Columns(2).Width = 70

        End With

    End Sub

    Private Sub btn追加_Click(sender As System.Object, e As System.EventArgs) Handles btn追加.Click

        frmﾙｰﾄﾏｽﾀﾒﾝﾃﾅﾝｽ_追加.ShowDialog()

        Call frmﾙｰﾄﾏｽﾀﾒﾝﾃﾅﾝｽ_Load(Me, e)

    End Sub

    Private Sub btn変更_Click(sender As System.Object, e As System.EventArgs) Handles btn変更.Click

        frmﾙｰﾄﾏｽﾀﾒﾝﾃﾅﾝｽ_変更.ShowDialog()

        Call frmﾙｰﾄﾏｽﾀﾒﾝﾃﾅﾝｽ_Load(Me, e)

    End Sub

    Private Sub btn閉じる_Click(sender As System.Object, e As System.EventArgs) Handles btn閉じる.Click

        Me.Close()
        Me.Dispose()

    End Sub

    Private Sub btn削除_Click(sender As System.Object, e As System.EventArgs) Handles btn削除.Click

        Dim sCnn As SqlClient.SqlConnection = New SqlClient.SqlConnection
        Dim sCmd As SqlClient.SqlCommand = New SqlClient.SqlCommand

        Dim StrSQL As String

        Dim IntRes As Integer

        IntRes = MsgBox("「" & Me.GrdItem.CurrentRow.Cells(1).Value & "」を削除しますか?", vbYesNo + vbQuestion, Application.ProductName)

        If IntRes = vbNo Then

            Exit Sub

        End If

        sCnn.ConnectionString = DB.DBBR
        sCnn.Open()

        StrSQL = "DELETE "
        StrSQL &= "FROM 台本変換_うたぷりAllStar_ﾙｰﾄﾏｽﾀ "
        StrSQL &= "WHERE No = " & Me.GrdItem.CurrentRow.Cells(0).Value

        sCmd.Connection = sCnn
        sCmd.CommandText = StrSQL
        sCmd.ExecuteNonQuery()

        If sCnn.State <> ConnectionState.Closed Then sCnn.Close()

        sCnn.Dispose()

        MsgBox("削除が完了しました", vbOKOnly + vbInformation, Application.ProductName)

        Call frmﾙｰﾄﾏｽﾀﾒﾝﾃﾅﾝｽ_Load(Me, e)

    End Sub

End Class