Public Class SectionForm

    Public SelectFormMode As FormMode

    Public Enum FormMode
        INPUT = 1
        READ = 2
        RESULT = 3
        TOTO = 4
    End Enum

    ' 初期処理
    Private Sub SectionForm_Load(sender As Object, e As EventArgs) Handles Me.Load

        Select Case SelectFormMode
            Case FormMode.INPUT
                Me.Text = "試合入力"
                btnInput.Visible = True
            Case FormMode.READ
                Me.Text = "試合結果確認"
                btnResult.Visible = True
            Case FormMode.RESULT
                Me.Text = "試合結果入力"
                btnResultInput.Visible = True
            Case FormMode.TOTO
                Me.Text = "toto予想試合入力"
                btnTotoInput.Visible = True
        End Select

    End Sub

    Private Sub SectionForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        Select Case SelectFormMode
            Case FormMode.INPUT
                MainWindow.SubFormSectionInput = False
            Case FormMode.READ
                MainWindow.SubFormSecitonResult = False
            Case FormMode.RESULT
                MainWindow.SubFormSecitonResultInput = False
            Case FormMode.TOTO
                MainWindow.SubFormSectionTotoInput = False
        End Select

    End Sub

    ' 試合入力ボタン押下
    Private Sub btnInput_Click(sender As Object, e As EventArgs) Handles btnInput.Click

        Dim matchListForm As New MatchListInputForm

        matchListForm.FormMode = FormMode.INPUT
        matchListForm.ShowDialog()

    End Sub

    ' 結果確認ボタン押下
    Private Sub btnResult_Click(sender As Object, e As EventArgs) Handles btnResult.Click

        Dim matchListForm As New MatchListInputForm

        matchListForm.FormMode = FormMode.READ
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

        totoSelectForm.ShowDialog()

    End Sub

    Private Sub FormGetting()

    End Sub


End Class