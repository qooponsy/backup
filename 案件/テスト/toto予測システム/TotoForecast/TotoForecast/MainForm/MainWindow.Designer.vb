<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainWindow
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ファイルToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.miExit = New System.Windows.Forms.ToolStripMenuItem()
        Me.予想ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.採点予想ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.結果比較ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.入力ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMatch = New System.Windows.Forms.ToolStripMenuItem()
        Me.miMatchUpd = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.miTotoInput = New System.Windows.Forms.ToolStripMenuItem()
        Me.miTotoUpd = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.miResultInput = New System.Windows.Forms.ToolStripMenuItem()
        Me.新規ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.修正ToolStripMenuItem2 = New System.Windows.Forms.ToolStripMenuItem()
        Me.miResultUpd = New System.Windows.Forms.ToolStripMenuItem()
        Me.順位表ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.クラブ情報ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.miClubJLeague = New System.Windows.Forms.ToolStripMenuItem()
        Me.順位表ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.miRankJLeague = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSectionResult = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEqualClubDetail = New System.Windows.Forms.ToolStripMenuItem()
        Me.登録ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.miClubReg = New System.Windows.Forms.ToolStripMenuItem()
        Me.設定ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.miTotoForecastSetting = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.過去試合結果入力ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.過去試合結果修正ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ファイルToolStripMenuItem, Me.予想ToolStripMenuItem, Me.入力ToolStripMenuItem, Me.順位表ToolStripMenuItem, Me.登録ToolStripMenuItem, Me.設定ToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1135, 26)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ファイルToolStripMenuItem
        '
        Me.ファイルToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miExit})
        Me.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem"
        Me.ファイルToolStripMenuItem.Size = New System.Drawing.Size(68, 22)
        Me.ファイルToolStripMenuItem.Text = "ファイル"
        '
        'miExit
        '
        Me.miExit.Name = "miExit"
        Me.miExit.Size = New System.Drawing.Size(100, 22)
        Me.miExit.Text = "終了"
        '
        '予想ToolStripMenuItem
        '
        Me.予想ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.採点予想ToolStripMenuItem, Me.結果比較ToolStripMenuItem})
        Me.予想ToolStripMenuItem.Name = "予想ToolStripMenuItem"
        Me.予想ToolStripMenuItem.Size = New System.Drawing.Size(44, 22)
        Me.予想ToolStripMenuItem.Text = "予想"
        '
        '採点予想ToolStripMenuItem
        '
        Me.採点予想ToolStripMenuItem.Name = "採点予想ToolStripMenuItem"
        Me.採点予想ToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.採点予想ToolStripMenuItem.Text = "採点予想"
        '
        '結果比較ToolStripMenuItem
        '
        Me.結果比較ToolStripMenuItem.Name = "結果比較ToolStripMenuItem"
        Me.結果比較ToolStripMenuItem.Size = New System.Drawing.Size(124, 22)
        Me.結果比較ToolStripMenuItem.Text = "結果比較"
        '
        '入力ToolStripMenuItem
        '
        Me.入力ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miMatch, Me.miMatchUpd, Me.ToolStripSeparator1, Me.miTotoInput, Me.miTotoUpd, Me.ToolStripSeparator2, Me.miResultInput, Me.miResultUpd, Me.ToolStripSeparator3, Me.過去試合結果入力ToolStripMenuItem, Me.過去試合結果修正ToolStripMenuItem})
        Me.入力ToolStripMenuItem.Name = "入力ToolStripMenuItem"
        Me.入力ToolStripMenuItem.Size = New System.Drawing.Size(44, 22)
        Me.入力ToolStripMenuItem.Text = "入力"
        '
        'miMatch
        '
        Me.miMatch.Name = "miMatch"
        Me.miMatch.Size = New System.Drawing.Size(172, 22)
        Me.miMatch.Text = "試合入力"
        '
        'miMatchUpd
        '
        Me.miMatchUpd.Name = "miMatchUpd"
        Me.miMatchUpd.Size = New System.Drawing.Size(172, 22)
        Me.miMatchUpd.Text = "試合修正"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(169, 6)
        '
        'miTotoInput
        '
        Me.miTotoInput.Name = "miTotoInput"
        Me.miTotoInput.Size = New System.Drawing.Size(172, 22)
        Me.miTotoInput.Text = "toto予想試合入力"
        '
        'miTotoUpd
        '
        Me.miTotoUpd.Name = "miTotoUpd"
        Me.miTotoUpd.Size = New System.Drawing.Size(172, 22)
        Me.miTotoUpd.Text = "toto予想試合修正"
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(169, 6)
        '
        'miResultInput
        '
        Me.miResultInput.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.新規ToolStripMenuItem1, Me.修正ToolStripMenuItem2})
        Me.miResultInput.Name = "miResultInput"
        Me.miResultInput.Size = New System.Drawing.Size(172, 22)
        Me.miResultInput.Text = "試合結果入力"
        '
        '新規ToolStripMenuItem1
        '
        Me.新規ToolStripMenuItem1.Name = "新規ToolStripMenuItem1"
        Me.新規ToolStripMenuItem1.Size = New System.Drawing.Size(100, 22)
        Me.新規ToolStripMenuItem1.Text = "新規"
        '
        '修正ToolStripMenuItem2
        '
        Me.修正ToolStripMenuItem2.Name = "修正ToolStripMenuItem2"
        Me.修正ToolStripMenuItem2.Size = New System.Drawing.Size(100, 22)
        Me.修正ToolStripMenuItem2.Text = "修正"
        '
        'miResultUpd
        '
        Me.miResultUpd.Name = "miResultUpd"
        Me.miResultUpd.Size = New System.Drawing.Size(172, 22)
        Me.miResultUpd.Text = "試合結果修正"
        '
        '順位表ToolStripMenuItem
        '
        Me.順位表ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.クラブ情報ToolStripMenuItem, Me.順位表ToolStripMenuItem1, Me.miSectionResult, Me.miEqualClubDetail})
        Me.順位表ToolStripMenuItem.Name = "順位表ToolStripMenuItem"
        Me.順位表ToolStripMenuItem.Size = New System.Drawing.Size(44, 22)
        Me.順位表ToolStripMenuItem.Text = "確認"
        '
        'クラブ情報ToolStripMenuItem
        '
        Me.クラブ情報ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miClubJLeague})
        Me.クラブ情報ToolStripMenuItem.Name = "クラブ情報ToolStripMenuItem"
        Me.クラブ情報ToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.クラブ情報ToolStripMenuItem.Text = "クラブ情報"
        '
        'miClubJLeague
        '
        Me.miClubJLeague.Name = "miClubJLeague"
        Me.miClubJLeague.Size = New System.Drawing.Size(117, 22)
        Me.miClubJLeague.Text = "Jリーグ"
        '
        '順位表ToolStripMenuItem1
        '
        Me.順位表ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miRankJLeague})
        Me.順位表ToolStripMenuItem1.Name = "順位表ToolStripMenuItem1"
        Me.順位表ToolStripMenuItem1.Size = New System.Drawing.Size(172, 22)
        Me.順位表ToolStripMenuItem1.Text = "順位表"
        '
        'miRankJLeague
        '
        Me.miRankJLeague.Name = "miRankJLeague"
        Me.miRankJLeague.Size = New System.Drawing.Size(117, 22)
        Me.miRankJLeague.Text = "Jリーグ"
        '
        'miSectionResult
        '
        Me.miSectionResult.Name = "miSectionResult"
        Me.miSectionResult.Size = New System.Drawing.Size(172, 22)
        Me.miSectionResult.Text = "試合結果"
        '
        'miEqualClubDetail
        '
        Me.miEqualClubDetail.Name = "miEqualClubDetail"
        Me.miEqualClubDetail.Size = New System.Drawing.Size(172, 22)
        Me.miEqualClubDetail.Text = "引き分け試合詳細"
        '
        '登録ToolStripMenuItem
        '
        Me.登録ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miClubReg})
        Me.登録ToolStripMenuItem.Name = "登録ToolStripMenuItem"
        Me.登録ToolStripMenuItem.Size = New System.Drawing.Size(44, 22)
        Me.登録ToolStripMenuItem.Text = "登録"
        '
        'miClubReg
        '
        Me.miClubReg.Name = "miClubReg"
        Me.miClubReg.Size = New System.Drawing.Size(136, 22)
        Me.miClubReg.Text = "クラブ登録"
        '
        '設定ToolStripMenuItem
        '
        Me.設定ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miTotoForecastSetting})
        Me.設定ToolStripMenuItem.Name = "設定ToolStripMenuItem"
        Me.設定ToolStripMenuItem.Size = New System.Drawing.Size(44, 22)
        Me.設定ToolStripMenuItem.Text = "設定"
        '
        'miTotoForecastSetting
        '
        Me.miTotoForecastSetting.Name = "miTotoForecastSetting"
        Me.miTotoForecastSetting.Size = New System.Drawing.Size(148, 22)
        Me.miTotoForecastSetting.Text = "採点予想設定"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(169, 6)
        '
        '過去試合結果入力ToolStripMenuItem
        '
        Me.過去試合結果入力ToolStripMenuItem.Name = "過去試合結果入力ToolStripMenuItem"
        Me.過去試合結果入力ToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.過去試合結果入力ToolStripMenuItem.Text = "過去試合結果入力"
        '
        '過去試合結果修正ToolStripMenuItem
        '
        Me.過去試合結果修正ToolStripMenuItem.Name = "過去試合結果修正ToolStripMenuItem"
        Me.過去試合結果修正ToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.過去試合結果修正ToolStripMenuItem.Text = "過去試合結果修正"
        '
        'MainWindow
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1135, 574)
        Me.Controls.Add(Me.MenuStrip1)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip1
        Me.Name = "MainWindow"
        Me.Text = "TotoForecast"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ファイルToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents miExit As ToolStripMenuItem
    Friend WithEvents 順位表ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 登録ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents miClubReg As ToolStripMenuItem
    Friend WithEvents 入力ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents miMatch As ToolStripMenuItem
    Friend WithEvents miResultInput As ToolStripMenuItem
    Friend WithEvents miTotoInput As ToolStripMenuItem
    Friend WithEvents 予想ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 採点予想ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 結果比較ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 設定ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents miTotoForecastSetting As ToolStripMenuItem
    Friend WithEvents 順位表ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents miRankJLeague As ToolStripMenuItem
    Friend WithEvents miSectionResult As ToolStripMenuItem
    Friend WithEvents クラブ情報ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents miClubJLeague As ToolStripMenuItem
    Friend WithEvents miEqualClubDetail As ToolStripMenuItem
    Friend WithEvents 新規ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents 修正ToolStripMenuItem2 As ToolStripMenuItem
    Friend WithEvents miMatchUpd As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator1 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents miTotoUpd As ToolStripMenuItem
    Friend WithEvents miResultUpd As ToolStripMenuItem
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents 過去試合結果入力ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 過去試合結果修正ToolStripMenuItem As ToolStripMenuItem
End Class
