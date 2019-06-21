Public Class frmｷｬﾗｸﾀﾏｽﾀ

    Private Sub frmｷｬﾗｸﾀﾏｽｳﾀ_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim sCnn As SqlClient.SqlConnection = New SqlClient.SqlConnection
        Dim dApt As SqlClient.SqlDataAdapter
        Dim dTbl As Data.DataTable = New Data.DataTable

        Dim StrSQL As String

        sCnn.ConnectionString = DB.DBBR
        sCnn.Open()

        StrSQL = "SELECT "
        StrSQL &= "No,"
        StrSQL &= "キャラクタ略名,"
        StrSQL &= "正式キャラ名,"
        StrSQL &= "セリフキャラ名 "
        StrSQL &= "FROM 台本変換_うたぷりAllStar_ｷｬﾗﾏｽﾀ "

        dApt = New SqlClient.SqlDataAdapter(StrSQL, sCnn)
        dApt.Fill(dTbl)

        Me.GrdItem.DataSource = dTbl

        If sCnn.State <> ConnectionState.Closed Then sCnn.Close()

        sCnn.Dispose()

        Call GrdInit()

    End Sub

    Private Sub GrdInit()

        With Me.GrdItem

            .Columns(0).Visible = False
            .Columns(1).Width = 150
            .Columns(2).Width = 250
            .Columns(3).Width = 100

        End With

    End Sub

    Private Sub btn閉じる_Click(sender As System.Object, e As System.EventArgs) Handles btn閉じる.Click

        Me.Close()
        Me.Dispose()

    End Sub

    Private Sub btn追加_Click(sender As System.Object, e As System.EventArgs) Handles btn追加.Click

        frmｷｬﾗｸﾀﾏｽﾀ_追加.ShowDialog()

        Call frmｷｬﾗｸﾀﾏｽｳﾀ_Load(Me, e)

    End Sub

    Private Sub btn削除_Click(sender As System.Object, e As System.EventArgs) Handles btn削除.Click

        Dim sCnn As SqlClient.SqlConnection = New SqlClient.SqlConnection
        Dim sCmd As SqlClient.SqlCommand = New SqlClient.SqlCommand

        Dim StrSQL As String

        Dim IntRes As Integer

        IntRes = MsgBox(Me.GrdItem.CurrentRow.Cells(1).Value & "を削除してもよろしいですか?", vbYesNo + vbInformation, Application.ProductName)

        If IntRes = vbYes Then

        Else

            Exit Sub

        End If

        sCnn.ConnectionString = DB.DBBR
        sCnn.Open()

        StrSQL = "DELETE "
        StrSQL &= "FROM 台本変換_うたぷりAllStar_ｷｬﾗﾏｽﾀ "
        StrSQL &= "WHERE No = " & Me.GrdItem.CurrentRow.Cells(0).Value

        sCmd.Connection = sCnn
        sCmd.CommandText = StrSQL

        sCmd.ExecuteNonQuery()

        If sCnn.State <> ConnectionState.Closed Then sCnn.Close()

        sCnn.Dispose()

        MsgBox("削除が完了しました", vbOKOnly + vbInformation, Application.ProductName)

        Call frmｷｬﾗｸﾀﾏｽｳﾀ_Load(Me, e)

    End Sub

    Private Sub btn変更_Click(sender As System.Object, e As System.EventArgs) Handles btn変更.Click

        frmｷｬﾗｸﾀﾏｽﾀ_変更.ShowDialog()

        Call frmｷｬﾗｸﾀﾏｽｳﾀ_Load(Me, e)

    End Sub

End Class