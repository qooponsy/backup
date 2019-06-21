Public Class frm章ﾏｽﾀﾒﾝﾃﾅﾝｽ_追加

    Private Sub btn閉じる_Click(sender As System.Object, e As System.EventArgs) Handles btn閉じる.Click

        Me.Close()
        Me.Dispose()

    End Sub

    Private Sub btn追加_Click(sender As System.Object, e As System.EventArgs) Handles btn追加.Click

        Dim sCnn As SqlClient.SqlConnection = New SqlClient.SqlConnection
        Dim dApt As SqlClient.SqlDataAdapter
        Dim dTbl As Data.DataTable = New Data.DataTable
        Dim sCmd As SqlClient.SqlCommand = New SqlClient.SqlCommand

        Dim StrSQL As String

        Dim IntNo As Integer

        sCnn.ConnectionString = DB.DBBR
        sCnn.Open()

        StrSQL = "SELECT * "
        StrSQL &= "FROM 台本変換_うたぷりAllStar_章ﾏｽﾀ "
        StrSQL &= "WHERE 章記号 = '" & Me.txt記号.Text & "'"

        dApt = New SqlClient.SqlDataAdapter(StrSQL, sCnn)
        dApt.Fill(dTbl)

        If dTbl.Rows.Count > 0 Then

            MsgBox("同一記号が既に登録されています", vbOKOnly + vbInformation, Application.ProductName)
            Exit Sub

        End If

        sCmd.Connection = sCnn

        StrSQL = "SELECT ISNULL(MAX(No),0) "
        StrSQL &= "FROM 台本変換_うたぷりAllStar_章ﾏｽﾀ "

        sCmd.CommandText = StrSQL

        IntNo = sCmd.ExecuteScalar
        IntNo = IntNo + 1

        StrSQL = "INSERT INTO 台本変換_うたぷりAllStar_章ﾏｽﾀ "
        StrSQL &= "("
        StrSQL &= "No,"
        StrSQL &= "章名,"
        StrSQL &= "章記号"
        StrSQL &= ") VALUES ("
        StrSQL &= IntNo & ","
        StrSQL &= "'" & Me.txt章名.Text & "',"
        StrSQL &= "'" & Me.txt記号.Text & "'"
        StrSQL &= ")"

        sCmd.CommandText = StrSQL

        sCmd.ExecuteNonQuery()

        If sCnn.State <> ConnectionState.Closed Then sCnn.Close()

        sCnn.Dispose()

        Me.txt記号.Text = ""
        Me.txt章名.Text = ""

        MsgBox("登録が完了しました", vbOKOnly + vbInformation, Application.ProductName)

    End Sub

    Private Sub frm章ﾏｽﾀﾒﾝﾃﾅﾝｽ_追加_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub
End Class