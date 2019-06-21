Public Class RankListForm

    Public selectLeagueCode As String
    Public selectLeagueDetailCode As String
    Public selectYear As String

    Private Table As DataTable
    Private View As DataView

    Private Sub RankList_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        InitGrid()
        SetGrid()

    End Sub

    Public Sub SetParamerter(ByVal LeagueCode As String, ByVal LeagueDetailCode As String, ByVal Year As String)
        selectLeagueCode = LeagueCode
        selectLeagueDetailCode = LeagueDetailCode
        selectYear = Year
    End Sub

    Private Sub InitGrid()

        grid.AutoGenerateColumns = False

        Table = New DataTable
        Table.Columns.Add("ClubCode", GetType(String))
        Table.Columns.Add("ClubCodeName", GetType(String))
        Table.Columns.Add("LeagueCode", GetType(String))
        Table.Columns.Add("LeagueDetailCode", GetType(String))
        Table.Columns.Add("Year", GetType(String))
        Table.Columns.Add("CurrentYear", GetType(String))
        Table.Columns.Add("Rank", GetType(String))
        Table.Columns.Add("Points", GetType(String))
        Table.Columns.Add("Win", GetType(String))
        Table.Columns.Add("Lose", GetType(String))
        Table.Columns.Add("Draw", GetType(String))
        Table.Columns.Add("Score", GetType(String))
        Table.Columns.Add("LostScore", GetType(String))
        Table.Columns.Add("ScoreDiff", GetType(String))
        View = New DataView(Table)
        grid.DataSource = View

    End Sub

    Private Sub SetGrid()

        Dim list As New List(Of RankData)
        Dim ret As Boolean = RankService.GetRankList(selectLeagueCode, selectLeagueDetailCode, selectYear, list)

        If ret Then

            For Each item As RankData In list
                Dim row As DataRow = Table.NewRow

                row("ClubCode") = item.ClubCode
                row("ClubCodeName") = ClubService.GetData(item.ClubCode).ClubName
                row("LeagueCode") = item.LeagueCode
                row("LeagueDetailCode") = item.LeagueDetailCode
                row("Year") = item.Year
                row("CurrentYear") = item.CurrentYear
                row("Rank") = item.Rank
                row("Points") = item.Points
                row("Win") = item.Win
                row("Lose") = item.Lose
                row("Draw") = item.Draw
                row("Score") = item.Score
                row("LostScore") = item.LostScore
                row("ScoreDiff") = item.ScoreDiff

                Table.Rows.Add(row)
            Next

        End If

    End Sub

    Private Sub RankListForm_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        MainWindow.SubFormLeagueRank.Remove(selectLeagueCode + selectLeagueDetailCode + selectYear)
    End Sub

End Class