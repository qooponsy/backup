Public Class SectionForm

    Public SelectFormMode As FormMode
    Private init As Boolean = False

    Public Enum FormMode
        MATCH_INPUT = 1
        MATCH_UPD = 2
        TOTO_INPUT = 3
        TOTO_UPD = 4
        RESULT_INPUT = 5
        RESULT_UPD = 6
        RESULT_READ = 7
    End Enum

    ' 初期処理
    Private Sub SectionForm_Load(sender As Object, e As EventArgs) Handles Me.Load

        Select Case SelectFormMode
            Case FormMode.MATCH_INPUT
                Me.Text = "試合新規入力"
                btnMatchInput.Visible = True
                tbSection.Visible = True
            Case FormMode.MATCH_UPD
                Me.Text = "試合修正"
                btnMatchUpdate.Visible = True
                cbSection.Visible = True
            Case FormMode.RESULT_READ
                Me.Text = "試合結果確認"
                btnResult.Visible = True
                cbSection.Visible = True
            Case FormMode.RESULT_INPUT
                Me.Text = "試合結果新規入力"
                btnResultInput.Visible = True
                cbSection.Visible = True
            Case FormMode.TOTO_INPUT
                Me.Text = "toto予想試合新規入力"
                btnTotoInput.Visible = True
                cbSection.Visible = True
        End Select

        ' リーグリスト読み込み
        cbLeague.DisplayMember = "LeagueName"
        cbLeague.ValueMember = "LeagueCode"
        cbLeague.DataSource = LeagueService.GetList()

    End Sub

    Private Sub SectionForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        Select Case SelectFormMode
            Case FormMode.MATCH_INPUT
                MainWindow.SubFormSectionMatchInput = False
            Case FormMode.RESULT_READ
                MainWindow.SubFormSecitonResult = False
            Case FormMode.RESULT_INPUT
                MainWindow.SubFormSecitonResultInput = False
            Case FormMode.TOTO_INPUT
                MainWindow.SubFormSectionTotoInput = False
        End Select

    End Sub

    ' 試合入力ボタン押下
    Private Sub btnInput_Click(sender As Object, e As EventArgs) Handles btnMatchInput.Click

        Dim matchListForm As New MatchListInputForm
        matchListForm.SelectSection = GetFormData()

        matchListForm.SelectFormMode = FormMode.MATCH_INPUT
        matchListForm.ShowDialog()

        Dim section As String = ""
        SectionService.GetSection(cbLeague.SelectedValue, cbLeagueDetail.SelectedValue, cbSeason.SelectedValue, cbMatchClass.SelectedValue, section)
        tbSection.Text = section

    End Sub

    ' 試合修正ボタン押下
    Private Sub btnMatchUpdate_Click(sender As Object, e As EventArgs) Handles btnMatchUpdate.Click

        Dim matchListForm As New MatchListInputForm
        matchListForm.SelectSection = GetFormData()

        matchListForm.SelectFormMode = FormMode.MATCH_UPD
        matchListForm.ShowDialog()

    End Sub

    ' 結果確認ボタン押下
    Private Sub btnResult_Click(sender As Object, e As EventArgs) Handles btnResult.Click

        Dim matchListForm As New MatchListInputForm

        matchListForm.SelectFormMode = FormMode.RESULT_READ
        matchListForm.ShowDialog()

    End Sub

    ' 試合結果入力ボタン押下
    Private Sub btnResultInput_Click(sender As Object, e As EventArgs) Handles btnResultInput.Click

        Dim matchResultFormInput As New MatchResultInputForm

        matchResultFormInput.ShowDialog()

    End Sub

    ' toto予想試合入力
    Private Sub btnTotoInput_Click(sender As Object, e As EventArgs) Handles btnTotoInput.Click
        Dim totoSelectForm As New TotoSelectForm
        totoSelectForm.SelectSection = GetFormData()

        totoSelectForm.ShowDialog()

    End Sub

    Private Function GetFormData() As SectionData
        Dim item As New SectionData

        item.LeagueCode = cbLeague.SelectedValue
        item.LeagueDetailCode = cbLeagueDetail.SelectedValue
        item.Year = cbSeason.SelectedValue
        item.MatchClass = cbMatchClass.SelectedValue

        Select Case SelectFormMode
            Case FormMode.MATCH_INPUT
                item.Section = tbSection.Text
            Case Else
                item.Section = cbSection.SelectedValue
        End Select

        SectionService.GetSectionCode(item.LeagueCode, item.LeagueDetailCode, item.Year, item.MatchClass, item.SectionCode)

        Return item
    End Function

    Private Sub cbLeague_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbLeague.SelectedIndexChanged
        cbLeagueDetail.Enabled = True

        cbLeagueDetail.DisplayMember = "LeagueDetailName"
        cbLeagueDetail.ValueMember = "LeagueDetailCode"
        cbLeagueDetail.DataSource = LeagueDetailService.GetList(cbLeague.SelectedValue)
    End Sub

    Private Sub cbLeagueDetail_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbLeagueDetail.SelectedIndexChanged
        cbSeason.Enabled = True

        Dim list As New List(Of SeasonData)
        Dim success As Boolean = SeasonService.GetYearList(cbLeague.SelectedValue, cbLeagueDetail.SelectedValue, list)

        If success Then
            cbSeason.DisplayMember = "SeasonName"
            cbSeason.ValueMember = "RegSeason"
            cbSeason.DataSource = list
        Else
            MessageBox.Show("情報の取得に失敗しました。",
                "エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
        End If


    End Sub

    Private Sub cbSeason_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSeason.SelectedIndexChanged
        cbMatchClass.Enabled = True

        Dim list As New List(Of MatchClassData)
        Dim success As Boolean = MatchClassService.GetList(cbLeague.SelectedValue, list)

        If success Then
            cbMatchClass.DisplayMember = "MatchClassName"
            cbMatchClass.ValueMember = "MatchClass"
            cbMatchClass.DataSource = list
        Else
            MessageBox.Show("情報の取得に失敗しました。",
                "エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
        End If

    End Sub

    Private Sub cbMatchClass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbMatchClass.SelectedIndexChanged
        cbSection.Enabled = True

        Select Case SelectFormMode
            Case FormMode.MATCH_INPUT
                Dim section As String = ""
                Dim success As Boolean = SectionService.GetSection(cbLeague.SelectedValue, cbLeagueDetail.SelectedValue, cbSeason.SelectedValue, cbMatchClass.SelectedValue, section)

                If success Then
                    tbSection.Text = section
                End If
            Case FormMode.MATCH_UPD, FormMode.TOTO_INPUT
                Dim sectionCode As String = ""
                Dim success As Boolean = SectionService.GetSectionCode(cbLeague.SelectedValue, cbLeagueDetail.SelectedValue, cbSeason.SelectedValue, cbMatchClass.SelectedValue, sectionCode)

                Dim list As New List(Of SectionData)
                If success Then
                    success = MatchService.GetMatchSectionList(sectionCode, list)
                End If

                If success Then
                    cbSection.DisplayMember = "SectionView"
                    cbSection.ValueMember = "Section"
                    cbSection.DataSource = list
                Else
                    MessageBox.Show("情報の取得に失敗しました。",
                        "エラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error)
                End If

        End Select


    End Sub

End Class