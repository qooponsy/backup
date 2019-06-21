Public Class ClubListForm

    Public selectLeagueCode As String

    Private Table As DataTable
    Private View As DataView

    Private Sub ClubListForm_Load(sender As Object, e As EventArgs) Handles Me.Load

        lblLeagueTitle.Text = LeagueService.GetData(selectLeagueCode).LeagueName & "クラブ一覧表"

        Initgrid()
        SetGrid()

    End Sub

    Public Sub Initgrid()

        grid.AutoGenerateColumns = False

        Table = New DataTable
        Table.Columns.Add("ClubCode", GetType(String))
        Table.Columns.Add("LeagueCode", GetType(String))
        Table.Columns.Add("LeagueCodeName", GetType(String))
        Table.Columns.Add("LeagueDetailCode", GetType(String))
        Table.Columns.Add("LeagueDetailCodeName", GetType(String))
        Table.Columns.Add("ClubName", GetType(String))
        Table.Columns.Add("ClubNameKana", GetType(String))
        Table.Columns.Add("ShortName", GetType(String))
        Table.Columns.Add("ShortNameKana", GetType(String))

        grid.DataSource = Table

    End Sub

    Private Sub SetGrid()

        Dim list As New List(Of ClubData)
        Dim ret As Boolean = ClubService.GetList(selectLeagueCode, list)

        If ret Then

            For Each item As ClubData In list
                Dim row As DataRow = Table.NewRow

                row("ClubCode") = item.ClubCode
                row("LeagueCode") = item.LeagueCode
                row("LeagueCodeName") = LeagueService.GetData(item.LeagueCode).LeagueName
                row("LeagueDetailCode") = item.LeagueDetailCode
                row("LeagueDetailCodeName") = LeagueDetailService.GetData(item.LeagueDetailCode).LeagueDetailName
                row("ClubName") = item.ClubName
                row("ClubNameKana") = item.ClubNameKana
                row("ShortName") = item.ShortName
                row("ShortNameKana") = item.ShortNameKana

                Table.Rows.Add(row)
            Next

        End If

    End Sub

    Private Sub grid_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles grid.CellDoubleClick
        If e.RowIndex < 0 Then Exit Sub
        Dim code As String = grid.SelectedRows(0).Cells("ClubCode").Value

        Dim clubDataForm As New ClubDataForm
        clubDataForm.selectFormMode = ClubDataForm.FormMode.EDIT
        clubDataForm.ClubCode = code

        clubDataForm.ShowDialog()

        Table.Clear()
        SetGrid()
    End Sub

    Private Sub ClubListForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        MainWindow.SubFormClubList.Remove(LeagueService.LeagueCategory.JLeague)
    End Sub
End Class