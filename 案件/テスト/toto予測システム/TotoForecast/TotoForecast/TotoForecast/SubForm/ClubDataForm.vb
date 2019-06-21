Public Class ClubDataForm

    Private Sub ClubDataForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        MainWindow.SubFormClubData = True

        ' リーグリスト読み込み
        cbLeague.DisplayMember = "LeagueName"
        cbLeague.ValueMember = "LeagueCode"
        cbLeague.DataSource = LeagueService.GetViewList()

        ' リーグ詳細リストはリーグを選ばれるまで無効
        cbLeagueDetail.Enabled = False

    End Sub

    Private Sub ClubDataForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        MainWindow.SubFormClubData = False
    End Sub

    ' League情報選択時
    Private Sub cbLeague_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbLeague.SelectedIndexChanged
        cbLeagueDetail.Enabled = True

        cbLeagueDetail.DisplayMember = "LeagueDetailName"
        cbLeagueDetail.ValueMember = "LeagueDetailCode"
        cbLeagueDetail.DataSource = LeagueDetailService.GetViewList(cbLeague.SelectedValue)

    End Sub

    Private Sub btnReg_Click(sender As Object, e As EventArgs) Handles btnReg.Click
        Dim LeagueCode As String = cbLeague.SelectedIndex
        Dim LeagueDetialCode As String = cbLeagueDetail.SelectedIndex
        Dim ClubName As String = tbClubName.Text
        Dim ClubKanaName As String = tbCLubKanaName.Text
        Dim ShortName As String = tbShortName.Text

        Dim success As Boolean = ClubService.Regist(LeagueCode, LeagueDetialCode, ClubName, ClubKanaName, ShortName)

        If success Then
            MsgBox("登録完了しました。", "正常終了", MsgBoxStyle.OkOnly)

        Else
            MessageBox.Show("登録に失敗しました。",
                "エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
        End If

    End Sub

End Class