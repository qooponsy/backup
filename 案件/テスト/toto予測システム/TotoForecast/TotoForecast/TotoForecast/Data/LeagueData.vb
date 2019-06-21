Public Class LeagueData
    Public Property LeagueCode As String
    Public Property LeagueName As String
    Public Property Country As String

    Public Function IsMatch(item As LeagueData)
        If LeagueCode <> item.LeagueCode Then Return False
        If LeagueName <> item.LeagueName Then Return False
        If Country <> item.Country Then Return False

        Return True
    End Function

End Class