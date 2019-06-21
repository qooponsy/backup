Public Class frm章ﾏｽﾀﾒﾝﾃﾅﾝｽ_変更

    Private Sub btn閉じる_Click(sender As System.Object, e As System.EventArgs) Handles btn閉じる.Click

        Me.Close()
        Me.Dispose()

    End Sub

    Private Sub frm章ﾏｽﾀﾒﾝﾃﾅﾝｽ_変更_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.txt章名.Text = frm章ﾏｽﾀﾒﾝﾃﾅﾝｽ.GrdItem.CurrentRow.Cells(1).Value
        Me.txt記号.Text = frm章ﾏｽﾀﾒﾝﾃﾅﾝｽ.GrdItem.CurrentRow.Cells(2).Value

    End Sub

    Private Sub btn変更_Click(sender As System.Object, e As System.EventArgs) Handles btn変更.Click

        Dim sCnn As SqlClient.SqlConnection = New SqlClient.SqlConnection
        Dim sCmd As SqlClient.SqlCommand = New SqlClient.SqlCommand

        Dim StrSQL As String

        StrSQL = "UPDATE 台本変換_うたぷりAllStar_章ﾏｽﾀ "
        StrSQL &= "SET "
        StrSQL &= "章名 = '" & Me.txt章名.Text & "',"
        StrSQL &= "章記号 = '" & Me.txt記号.Text & "' "
        StrSQL &= "WHERE No = " & frm章ﾏｽﾀﾒﾝﾃﾅﾝｽ.GrdItem.CurrentRow.Cells(0).Value

        sCnn.ConnectionString = DB.DBBR
        sCnn.Open()

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