Public Class RankData

    Public Property ClubCode As Integer         ' クラブコード（PK）
    Public Property LeagueCode As String        ' リーグコード
    Public Property LeagueDetailCode As String  ' リーグ詳細コード
    Public Property Year As String              ' 年度
    Public Property CurrentYear As Integer      ' 年度試合数
    Public Property Rank As Integer             ' 順位
    Public Property Points As Integer           ' 勝ち点
    Public Property Win As Integer              ' 勝ち数
    Public Property Lose As Integer             ' 負け数
    Public Property Draw As Integer             ' 引き分け数
    Public Property Score As Integer            ' 得点数
    Public Property LostScore As Integer        ' 失点数
    Public Property ScoreDiff As Integer        ' 得失差

End Class
