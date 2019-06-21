
''' <summary>
''' メインメニュー
''' </summary>
Public Class MainWindow
    Public SubFormClubData As Boolean = False
    Public SubFormSectionMatchInput As Boolean = False
    Public SubFormSectionMatchUpd As Boolean = False
    Public SubFormSecitonResult As Boolean = False
    Public SubFormSecitonResultInput As Boolean = False
    Public SubFormSectionTotoInput As Boolean = False
    Public SubFormTotoForecastSetting As Boolean = False
    Public SubFormClubList As New Dictionary(Of String, ClubListForm)
    Public SubFormLeagueRank As New Dictionary(Of String, RankListForm)

    Private SectionResultForm As SectionForm
    Private SectionMatchInputForm As SectionForm
    Private SectionMatchUpdForm As SectionForm
    Private SecitonResultInputForm As SectionForm
    Private SectionTotoInputForm As SectionForm
    Private LeagueSelectForm As New LeagueSelectForm

    Private WithEvents serviceLeagueSelect As LeagueSelectForm

    Private RankListForm As RankListForm
    Private ClubListForm As ClubListForm

    Private Sub MainWindow_Load(sender As Object, e As EventArgs) Handles Me.Load

        ' 初期化処理
        Init()

    End Sub



    Private Sub miExit_Click(sender As Object, e As EventArgs) Handles miExit.Click

    End Sub

    ' クラブ登録ボタン押下
    Private Sub miClubReg_Click(sender As Object, e As EventArgs) Handles miClubReg.Click
        If SubFormClubData Then
            ClubDataForm.Activate()
        Else
            ClubDataForm.MdiParent = Me
            ClubDataForm.selectFormMode = ClubDataForm.FormMode.INPUT
            ClubDataForm.Show()
        End If
    End Sub

    Private Sub Init()
        ' DBデータ参照
        LeagueService.Init()        ' リーグ情報
        LeagueDetailService.Init()  ' リーグ詳細情報
        CategoryService.Init()      ' カテゴリー情報
    End Sub

    ' Jリーグクラブ一覧
    Private Sub miClubJLeague_Click(sender As Object, e As EventArgs) Handles miClubJLeague.Click

        Dim key As String = LeagueService.LeagueCategory.JLeague

        If SubFormClubList.ContainsKey(key) Then
            SubFormClubList.Item(key).Activate()
        Else
            ClubListForm = New ClubListForm
            ClubListForm.MdiParent = Me
            ClubListForm.selectLeagueCode = LeagueService.LeagueCategory.JLeague

            SubFormClubList.Add(key, ClubListForm)

            ClubListForm.Show()
        End If

    End Sub

    ' Jリーグ順位表
    Private Sub miJLeagueRank_Click(sender As Object, e As EventArgs) Handles miRankJLeague.Click

        ' リーグ詳細選択画面を表示
        LeagueSelectForm = New LeagueSelectForm
        LeagueSelectForm.LeagueCode = LeagueService.LeagueCategory.JLeague
        LeagueSelectForm.ShowDialog()

        ' 順位表画面を表示
        If LeagueSelectForm.IsSelectData() Then

            Dim key As String = LeagueService.LeagueCategory.JLeague +
                                              LeagueSelectForm.LeagueDetailCode +
                                              LeagueSelectForm.Year

            If SubFormLeagueRank.ContainsKey(key) Then
                SubFormLeagueRank.Item(key).Activate()
            Else
                RankListForm = New RankListForm
                RankListForm.MdiParent = Me
                RankListForm.SetParamerter(LeagueSelectForm.LeagueCode,
                                           LeagueSelectForm.LeagueDetailCode,
                                           LeagueSelectForm.Year)

                SubFormLeagueRank.Add(key, RankListForm)

                RankListForm.Show()
            End If

        End If

    End Sub

    ' 試合結果
    Private Sub miSectionResult_Click(sender As Object, e As EventArgs) Handles miSectionResult.Click
        If SubFormSecitonResult Then
            SectionResultForm.Activate()
        Else
            SubFormSecitonResult = True

            SectionResultForm = New SectionForm
            SectionResultForm.MdiParent = Me
            SectionResultForm.SelectFormMode = SectionForm.FormMode.RESULT_READ
            SectionResultForm.Show()
        End If
    End Sub

    ' 試合結果入力
    Private Sub miSectionResultInput_Click(sender As Object, e As EventArgs) Handles miResultInput.Click
        If SubFormSecitonResultInput Then
            SecitonResultInputForm.Activate()
        Else
            SubFormSecitonResultInput = True

            SecitonResultInputForm = New SectionForm
            SecitonResultInputForm.MdiParent = Me
            SecitonResultInputForm.SelectFormMode = SectionForm.FormMode.RESULT_INPUT
            SecitonResultInputForm.Show()
        End If
    End Sub

    ' toto予想試合入力
    Private Sub miTotoInput_Click(sender As Object, e As EventArgs) Handles miTotoInput.Click
        If SubFormSectionTotoInput Then
            SectionTotoInputForm.Activate()
        Else
            SubFormSectionTotoInput = True

            SectionTotoInputForm = New SectionForm
            SectionTotoInputForm.MdiParent = Me
            SectionTotoInputForm.SelectFormMode = SectionForm.FormMode.TOTO_INPUT
            SectionTotoInputForm.Show()
        End If

    End Sub

    ' 採点予想作成
    Private Sub miTotoForecastSetting_Click(sender As Object, e As EventArgs) Handles miTotoForecastSetting.Click
        If SubFormTotoForecastSetting Then
            GradingSettingListForm.Activate()
        Else
            GradingSettingListForm.MdiParent = Me
            GradingSettingListForm.Show()
        End If
    End Sub

    ' 試合入力新規
    Private Sub miMatch_Click(sender As Object, e As EventArgs) Handles miMatch.Click
        If SubFormSectionMatchInput Then
            SectionMatchInputForm.Activate()
        Else
            SubFormSectionMatchInput = True

            SectionMatchInputForm = New SectionForm
            SectionMatchInputForm.MdiParent = Me
            SectionMatchInputForm.SelectFormMode = MatchListInputForm.FormMode.INPUT
            SectionMatchInputForm.Show()
        End If
    End Sub

    ' 試合入力修正
    Private Sub miMatchUpd_Click_1(sender As Object, e As EventArgs) Handles miMatchUpd.Click
        If SubFormSectionMatchUpd Then
            SectionMatchUpdForm.Activate()
        Else
            SubFormSectionMatchUpd = True

            SectionMatchUpdForm = New SectionForm
            SectionMatchUpdForm.MdiParent = Me
            SectionMatchUpdForm.SelectFormMode = MatchListInputForm.FormMode.UPD
            SectionMatchUpdForm.Show()
        End If
    End Sub

End Class
