Public Class LastBusinessDay

    Public Property LastBusinessDayID As Integer '最終営業日ID
    Public Property LastBusinessDay As Date '最終営業日
    Public Property Status As String 'ステータス
    Public Property CarfareCount As Integer '交通費データ作成数

    '月の交通費記載ステータス
    Public Class StatusCode
        Public Const NON_COMP As String = "0"   '未完了
        Public Const MAIL_COMP As String = "1"  '通知完了
        Public Const COMPLETE As String = "2"   '記載完了
    End Class



    Public Shared Function JudgeLastBusinessDay(ByVal LastDay As String, ByVal Today As Date) As Boolean
        Dim ret As Boolean = True
        Dim LastDayData As DateTime = DateTime.Parse(LastDay)

        If LastDayData = Today Then
        Else
            ret = False
        End If

        Return ret

    End Function


End Class
