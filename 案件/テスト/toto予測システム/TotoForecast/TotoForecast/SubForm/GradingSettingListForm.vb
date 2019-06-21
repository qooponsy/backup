Public Class GradingSettingListForm

    Private Table As DataTable
    Private View As DataView

    Private Sub GradingSettingListForm_Load(sender As Object, e As EventArgs) Handles Me.Load

        InitGrid()
        SetGrid()

    End Sub

    Private Sub btnReg_Click(sender As Object, e As EventArgs) Handles btnReg.Click

        Dim settingForm As New TotoForecastSettingForm
        settingForm.SelectFormMode = TotoForecastSettingForm.FormMode.INPUT
        settingForm.ShowDialog()

        If settingForm.SuccessFlg Then
            SetGrid()
        End If

    End Sub

    Private Sub InitGrid()
        grid.AutoGenerateColumns = False

        Table = New DataTable
        Table.Columns.Add("GradingSettingCode", GetType(String))
        Table.Columns.Add("GradingSetting", GetType(String))
        Table.Columns.Add("buy", GetType(Boolean))
        Table.Columns.Add("ForecastCount", GetType(String))
        Table.Columns.Add("CorrectAnsAve", GetType(String))
        Table.Columns.Add("CorrectAnsMax", GetType(String))
        Table.Columns.Add("PrizeCount", GetType(String))
        Table.Columns.Add("memo", GetType(String))

        grid.DataSource = Table
    End Sub

    Private Sub SetGrid()

        Table.Rows.Clear()

        Dim list As New List(Of GradingSettingData)
        Dim ret As Boolean = GradingSettingService.GetGradingSettingList(list)

        If ret Then
            For Each item As GradingSettingData In list
                Dim row As DataRow = Table.NewRow

                row("GradingSettingCode") = item.GradingSettingCode
                row("GradingSetting") = item.GradingSetting
                row("buy") = item.buy
                row("ForecastCount") = item.ForecastCount
                row("CorrectAnsAve") = item.CorrectAnsAve
                row("CorrectAnsMax") = item.CorrectAnsMax
                row("PrizeCount") = item.PrizeCount
                row("memo") = item.Memo

                Table.Rows.Add(row)
            Next
        End If

    End Sub

    Private Sub grid_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grid.CellDoubleClick

        If e.RowIndex < 0 Then Exit Sub
        Dim code As String = grid.SelectedRows(0).Cells("GradingSettingCode").Value

        Dim settingForm As New TotoForecastSettingForm
        settingForm.SelectFormMode = TotoForecastSettingForm.FormMode.UPDATE
        settingForm.SettingCode = code
        settingForm.ShowDialog()

        If settingForm.SuccessFlg Then
            SetGrid()
        End If

    End Sub
End Class