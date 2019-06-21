Public Class GradingSettingData

    Public Property GradingSettingCode As Integer ' 採点設定コード
    Public Property GradingSetting As String ' 設定名
    Public Property buy As Integer ' 購入
    Public Property Memo As String ' メモ
    Public Property DrawValue As Integer ' ドロー基準
    Public Property EqualValue As Integer ' 同等クラブ基準

    Public Property ForecastCount As Integer ' 予想回数
    Public Property CorrectAnsAve As Integer ' 平均正解数
    Public Property CorrectAnsMax As Integer ' 最高正解数
    Public Property PrizeCount As Integer ' 賞金回数

End Class
