Public Class MatchDetailData

    Public Property MatchDetailCode As Long     ' 試合詳細コード
    Public Property SectionCode As Long         ' セクションコード
    Public Property MatchCode As Long           ' 試合コード
    Public Property ClubCode As Integer         ' クラブコード
    Public Property Rank As Integer             ' 順位
    Public Property OpponentClubCode As Integer ' 相手クラブコード
    Public Property OpponentRank As Integer     ' 相手順位
    Public Property Result As String            ' 結果（0=引き分け,1=勝ち,2=負け,3=その他）
    Public Property Score As Integer            ' 得点数
    Public Property LostScore As Integer        ' 失点数

End Class
