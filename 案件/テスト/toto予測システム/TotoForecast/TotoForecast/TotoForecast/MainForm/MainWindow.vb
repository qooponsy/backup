
''' <summary>
''' メインメニュー
''' </summary>
Public Class MainWindow
    Public SubFormClubData As Boolean = False
    Public SubFormJ1Rank As Boolean = False
    Public SubFormSectionInput As Boolean = False
    Public SubFormSecitonResult As Boolean = False
    Public SubFormSecitonResultInput As Boolean = False
    Public SubFormSectionTotoInput As Boolean = False
    Public SubFormTotoForecastSetting As Boolean = False

    Private SectionResultForm As SectionForm
    Private SectionInputForm As SectionForm
    Private SecitonResultInputForm As SectionForm
    Private SectionTotoInputForm As SectionForm

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
            ClubDataForm.Show()
        End If
    End Sub

    Private Sub Init()
        ' DBデータ参照
        LeagueService.Init()        ' リーグ情報
        LeagueDetailService.Init()  ' リーグ詳細情報
        CategoryService.Init()      ' カテゴリー情報
    End Sub

    ' 試合入力
    Private Sub miSectionInput_Click(sender As Object, e As EventArgs) Handles miSectionInput.Click
        If SubFormSectionInput Then
            SectionInputForm.Activate()
        Else
            SubFormSectionInput = True

            SectionInputForm = New SectionForm
            SectionInputForm.MdiParent = Me
            SectionInputForm.SelectFormMode = SectionForm.FormMode.INPUT
            SectionInputForm.Show()
        End If
    End Sub

    ' J1順位表
    Private Sub miJ1Rank_Click_1(sender As Object, e As EventArgs) Handles miJ1Rank.Click
        If SubFormJ1Rank Then
            RankListForm.Activate()
        Else
            RankListForm.MdiParent = Me
            RankListForm.Show()
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
            SectionResultForm.SelectFormMode = SectionForm.FormMode.READ
            SectionResultForm.Show()
        End If
    End Sub

    ' 試合結果入力
    Private Sub miSectionResultInput_Click(sender As Object, e As EventArgs) Handles miSectionResultInput.Click
        If SubFormSecitonResultInput Then
            SecitonResultInputForm.Activate()
        Else
            SubFormSecitonResultInput = True

            SecitonResultInputForm = New SectionForm
            SecitonResultInputForm.MdiParent = Me
            SecitonResultInputForm.SelectFormMode = SectionForm.FormMode.RESULT
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
            SectionTotoInputForm.SelectFormMode = SectionForm.FormMode.TOTO
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


End Class
