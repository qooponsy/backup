Public Class frmｷｬﾗｸﾀﾏｽﾀ_変更

    Private Sub btn閉じる_Click(sender As System.Object, e As System.EventArgs) Handles btn閉じる.Click

        Me.Close()
        Me.Dispose()

    End Sub

    Private Sub frmｷｬﾗｸﾀﾏｽﾀ_変更_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Me.txtキャラ略名.Text = frmｷｬﾗｸﾀﾏｽﾀ.GrdItem.CurrentRow.Cells(1).Value
        Me.txt正式キャラ名.Text = frmｷｬﾗｸﾀﾏｽﾀ.GrdItem.CurrentRow.Cells(2).Value
        Me.txtセリフキャラ名.Text = frmｷｬﾗｸﾀﾏｽﾀ.GrdItem.CurrentRow.Cells(3).Value

        Me.txt正式キャラ名.Focus()

    End Sub

    Private Sub btn変更_Click(sender As System.Object, e As System.EventArgs) Handles btn変更.Click

        Dim sCnn As SqlClient.SqlConnection = New SqlClient.SqlConnection
        Dim sCmd As SqlClient.SqlCommand = New SqlClient.SqlCommand

        Dim StrSQL As String

        StrSQL = "UPDATE 台本変換_うたぷりAllStar_ｷｬﾗﾏｽﾀ "
        StrSQL &= "SET "
        StrSQL &= "キャラクタ略名 = '" & Me.txtキャラ略名.Text & "',"
        StrSQL &= "正式キャラ名 = '" & Me.txt正式キャラ名.Text & "',"
        StrSQL &= "セリフキャラ名 = '" & Me.txtセリフキャラ名.Text & "' "
        StrSQL &= "WHERE No = " & frmｷｬﾗｸﾀﾏｽﾀ.GrdItem.CurrentRow.Cells(0).Value

        sCnn.ConnectionString = DB.DBBR
        sCnn.Open()

        sCmd.CommandText = StrSQL
        sCmd.Connection = sCnn
        sCmd.ExecuteNonQuery()

        If sCnn.State <> ConnectionState.Closed Then sCnn.Close()

        sCnn.Dispose()
        sCmd.Dispose()

        Me.Close()
        Me.Dispose()

        MsgBox("変更が完了しました", vbOKOnly + vbInformation, Application.ProductName)

    End Sub

End Class