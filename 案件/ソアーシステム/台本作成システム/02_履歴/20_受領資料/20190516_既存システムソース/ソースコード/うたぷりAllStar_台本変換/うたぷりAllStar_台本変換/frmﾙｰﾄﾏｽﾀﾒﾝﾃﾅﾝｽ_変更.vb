Public Class frmﾙｰﾄﾏｽﾀﾒﾝﾃﾅﾝｽ_変更

    Private Sub btn閉じる_Click(sender As System.Object, e As System.EventArgs) Handles btn閉じる.Click

        Me.Close()
        Me.Dispose()

    End Sub

    Private Sub frmﾙｰﾄﾏｽﾀﾒﾝﾃﾅﾝｽ_変更_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.txtルート名.Text = frmﾙｰﾄﾏｽﾀﾒﾝﾃﾅﾝｽ.GrdItem.CurrentRow.Cells(1).Value
        Me.txt記号.Text = frmﾙｰﾄﾏｽﾀﾒﾝﾃﾅﾝｽ.GrdItem.CurrentRow.Cells(2).Value

    End Sub

    Private Sub btn変更_Click(sender As System.Object, e As System.EventArgs) Handles btn変更.Click

        Dim sCnn As SqlClient.SqlConnection = New SqlClient.SqlConnection
        Dim sCmd As SqlClient.SqlCommand = New SqlClient.SqlCommand

        Dim StrSQL As String

        sCnn.ConnectionString = DB.DBBR
        sCnn.Open()

        StrSQL = "UPDATE 台本変換_うたぷりAllStar_ﾙｰﾄﾏｽﾀ "
        StrSQL &= "SET "
        StrSQL &= "ﾙｰﾄ = '" & Me.txtルート名.Text & "',"
        StrSQL &= "記号 = '" & Me.txt記号.Text & "' "
        StrSQL &= "WHERE No = " & frmﾙｰﾄﾏｽﾀﾒﾝﾃﾅﾝｽ.GrdItem.CurrentRow.Cells(0).Value

        sCmd.Connection = sCnn
        sCmd.CommandText = StrSQL

        sCmd.ExecuteNonQuery()

        If sCnn.State <> ConnectionState.Closed Then sCnn.Close()

        sCnn.Dispose()

        MsgBox("変更が完了しました", vbOKOnly + vbInformation, Application.ProductName)

        Me.Close()
        Me.Dispose()

    End Sub

End Class