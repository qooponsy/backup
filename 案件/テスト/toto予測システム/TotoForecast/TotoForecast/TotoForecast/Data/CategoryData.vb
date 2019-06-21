Public Class CategoryData

    Public Property CategoryCode As Integer        ' カテゴリーコード
    Public Property CategoryName As String        ' 採点名

    Public Enum CATEGORY
        AddRank = 1  ' 順位の加算
        WinAll = 2    ' 全年度の勝率
        WinNow = 3    ' 今年度の勝率
        WinPast5 = 4  ' 最近5試合の勝率
        WinVenuePast5 = 5    ' 最近5試合の試合会場での勝率
        WinOpponentAll = 6  ' 全年度の対戦相手との勝率
        WinOpponentNow = 7  ' 今年度の対戦相手との勝率
        ScoreDiffAll = 8  ' 全年度の得失点
        ScoreDiffNow = 9  ' 今年度の得失点
        ScoreDiffPast5 = 10  ' 最近5試合の得失点
        WinHighRankOpponentAll = 11    ' 全年度の格上相手との勝率
        WinHighRankOpponentNow = 12    '今年度の格上相手との勝率
        WinHighRankOpponentPast5 = 13    '最近5試合の格上相手との勝率
        WinLowRankOpponentAll = 14    ' 全年度の格下相手との勝率
        WinLowRankOpponentNow = 15    '今年度の格下相手との勝率
        WinLowRankOpponentPast5 = 16    '最近5試合の格下相手との勝率
        WinEqualRankOpponentAll = 17    ' 全年度の同等相手との勝率
        WinEqualRankOpponentNow = 18    ' 今年度の同等相手との勝率
        WinEqualRankOpponentPast5 = 19    ' 最近5試合の同等相手との勝率
    End Enum


End Class
