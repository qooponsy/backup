Public Class ClubDataForm

    Public selectFormMode As FormMode
    Public ClubCode As String

    Public Enum FormMode
        INPUT = 1
        EDIT = 2
    End Enum

    Private Sub ClubDataForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        MainWindow.SubFormClubData = True

        ' リーグリスト読み込み
        cbLeague.DisplayMember = "LeagueName"
        cbLeague.ValueMember = "LeagueCode"
        cbLeague.DataSource = LeagueService.GetViewList()

        Select Case selectFormMode
            Case FormMode.INPUT
                cbLeagueDetail.Enabled = False　' リーグ詳細リストはリーグを選ばれるまで無効
                btnCsvRead.Visible = True
                btnInput.Visible = True
            Case FormMode.EDIT
                btnUpdate.Visible = True
                SetFormData(ClubCode)
        End Select

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

    Private Sub btnReg_Click(sender As Object, e As EventArgs) Handles btnInput.Click

        Dim item As ClubData = GetFormData()

        Dim success As Boolean = ClubService.Regist(item)

        If success Then
            MsgBox("登録完了しました。", MsgBoxStyle.OkOnly, "正常終了")
            Me.Close()
        Else
            MessageBox.Show("登録に失敗しました。",
                "エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim item As ClubData = GetFormData()

        Dim success As Boolean = ClubService.Update(item)

        If success Then
            MsgBox("更新が完了しました。", MsgBoxStyle.OkOnly, "正常終了")
            Me.Close()
        Else
            MessageBox.Show("更新に失敗しました。",
                "エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub btnCsvRead_Click(sender As Object, e As EventArgs) Handles btnCsvRead.Click

        Dim path As String = FileDialog.GetFilePath()
        Dim success As Boolean = ClubService.CsvDataRegist(path)

        If success Then
            MsgBox("登録完了しました。", MsgBoxStyle.OkOnly, "正常終了")
            Me.Close()
        Else
            MessageBox.Show("一部、または全てのクラブの登録に失敗しました。",
                "エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub SetFormData(ByVal ClubCode As String)
        Dim item As ClubData = ClubService.GetData(ClubCode)

        tbClubCode.Text = item.ClubCode
        cbLeague.SelectedValue = item.LeagueCode
        cbLeagueDetail.SelectedValue = item.LeagueDetailCode
        tbClubName.Text = item.ClubName
        tbCLubNameKana.Text = item.ClubNameKana
        tbShortName.Text = item.ShortName
        tbShortNameKana.Text = item.ShortNameKana

    End Sub

    Private Function GetFormData() As ClubData
        Dim item As New ClubData

        If selectFormMode <> FormMode.INPUT Then
            item.ClubCode = tbClubCode.Text
        End If

        item.LeagueCode = cbLeague.SelectedValue
        item.LeagueDetailCode = cbLeagueDetail.SelectedValue
        item.ClubName = tbClubName.Text
        item.ClubNameKana = tbCLubNameKana.Text
        item.ShortName = tbShortName.Text
        item.ShortNameKana = tbShortNameKana.Text

        Return item
    End Function

End Class