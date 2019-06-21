Public Class SectionInput

    ' 入力ボタン押下
    Private Sub btnInput_Click(sender As Object, e As EventArgs) Handles btnInput.Click

        Dim matchListForm As New MatchListInput

        matchListForm.ShowDialog()

    End Sub

    Private Sub FormGetting()

    End Sub

End Class