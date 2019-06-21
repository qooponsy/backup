Public Class frmｷｬﾗｸﾀﾏｽﾀ_追加

    Private Sub frmｷｬﾗｸﾀﾏｽﾀ_追加_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

    End Sub

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

        If Me.txtキャラ略名.Text = "" Then

            MsgBox("キャラクタ略名を入力してください", vbOKOnly + vbInformation, Application.ProductName)
            Exit Sub

        End If

        If Me.txt正式キャラ名.Text = "" Then

            MsgBox("正式キャラ名を入力してください", vbOKOnly + vbInformation, Application.ProductName)
            Exit Sub

        End If

        If Me.txtセリフキャラ名.Text = "" Then

            MsgBox("セリフキャラ名を入力してください", vbOKOnly + vbInformation, Application.ProductName)
            Exit Sub

        End If

        sCnn.ConnectionString = DB.DBBR
        sCnn.Open()

        StrSQL = "SELECT ISNULL(MAX(No),0) "
        StrSQL &= "FROM 台本変換_うたぷりAllStar_ｷｬﾗﾏｽﾀ"

        sCmd.Connection = sCnn
        sCmd.CommandText = StrSQL
        IntNo = sCmd.ExecuteScalar
        IntNo = IntNo + 1

        StrSQL = "SELECT "
        StrSQL &= " * "
        StrSQL &= "FROM 台本変換_うたぷりAllStar_ｷｬﾗﾏｽﾀ "
        StrSQL &= "WHERE キャラクタ略名 = '" & Me.txtキャラ略名.Text & "'"

        dApt = New SqlClient.SqlDataAdapter(StrSQL, sCnn)
        dApt.Fill(dTbl)

        If dTbl.Rows.Count > 0 Then

            MsgBox("「" & Me.txtキャラ略名.Text & "」は既に登録されています", vbOKOnly + vbInformation, Application.ProductName)
            Exit Sub

        End If

        StrSQL = "INSERT INTO 台本変換_うたぷりAllStar_ｷｬﾗﾏｽﾀ "
        StrSQL &= "("
        StrSQL &= "No,"
        StrSQL &= "キャラクタ略名,"
        StrSQL &= "正式キャラ名,"
        StrSQL &= "セリフキャラ名"
        StrSQL &= ") VALUES ("
        StrSQL &= IntNo & ","
        StrSQL &= "'" & Me.txtキャラ略名.Text & "',"
        StrSQL &= "'" & Me.txt正式キャラ名.Text & "',"
        StrSQL &= "'" & Me.txtセリフキャラ名.Text & "'"
        StrSQL &= ")"

        sCmd.CommandText = StrSQL
        sCmd.ExecuteNonQuery()

        If sCnn.State <> ConnectionState.Closed Then sCnn.Close()

        Me.txtキャラ略名.Text = ""
        Me.txtセリフキャラ名.Text = ""
        Me.txt正式キャラ名.Text = ""

        MsgBox("登録が完了しました", vbOKOnly + vbInformation, Application.ProductName)

        Exit Sub

    End Sub

End Class