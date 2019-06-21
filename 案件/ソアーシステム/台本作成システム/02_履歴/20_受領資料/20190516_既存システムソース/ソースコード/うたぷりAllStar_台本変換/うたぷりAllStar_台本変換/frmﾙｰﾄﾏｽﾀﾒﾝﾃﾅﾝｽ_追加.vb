Public Class frmﾙｰﾄﾏｽﾀﾒﾝﾃﾅﾝｽ_追加

    Private Sub btn追加_Click(sender As System.Object, e As System.EventArgs) Handles btn追加.Click

        Dim sCnn As SqlClient.SqlConnection = New SqlClient.SqlConnection
        Dim dApt As SqlClient.SqlDataAdapter
        Dim sCmd As SqlClient.SqlCommand = New SqlClient.SqlCommand
        Dim dTbl As Data.DataTable = New Data.DataTable

        Dim StrSQL As String
        Dim IntNo As Integer

        sCnn.ConnectionString = DB.DBBR
        sCnn.Open()

        StrSQL = "SELECT ISNULL(MAX(No),0) "
        StrSQL &= "FROM 台本変換_うたぷりAllStar_ﾙｰﾄﾏｽﾀ "

        sCmd.Connection = sCnn
        sCmd.CommandText = StrSQL

        IntNo = sCmd.ExecuteScalar
        IntNo = IntNo + 1

        StrSQL = "INSERT INTO 台本変換_うたぷりAllStar_ﾙｰﾄﾏｽﾀ "
        StrSQL &= "("
        StrSQL &= "No,"
        StrSQL &= "ﾙｰﾄ,"
        StrSQL &= "記号"
        StrSQL &= ") VALUES ("
        StrSQL &= IntNo & ","
        StrSQL &= "'" & Me.txtルート名.Text & "',"
        StrSQL &= "'" & Me.txt記号.Text & "'"
        StrSQL &= ")"

        sCmd.CommandText = StrSQL
        sCmd.ExecuteNonQuery()

        If sCnn.State <> ConnectionState.Closed Then sCnn.Close()

        sCnn.Dispose()

        Me.txtルート名.Text = ""
        Me.txt記号.Text = ""

        MsgBox("登録が完了しました", vbOKOnly + vbInformation, Application.ProductName)


    End Sub

    Private Sub btn閉じる_Click(sender As System.Object, e As System.EventArgs) Handles btn閉じる.Click

        Me.Close()
        Me.Dispose()

    End Sub
End Class