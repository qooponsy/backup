Public Class MatchData

    Public Property MatchCode As Long          ' 試合コード
    Public Property SectionCode As Long        ' セクションコード
    Public Property Section As Long        ' セクション
    Public Property HomeClubCode As Integer    ' ホームクラブ
    Public Property AwayClubCode As Integer    ' アウェイクラブ
    Public Property toto As Integer            ' toto予想
    Public Property Status As Integer          ' ステータス
    Public Property Result As Integer          ' 結果(ホームからみて)

    Public Enum MatchStatus
        MatchInput = 1      ' 試合入力
        totoInput = 2       ' toto入力
        ResultInput = 3     ' 結果入力
    End Enum
End Class
