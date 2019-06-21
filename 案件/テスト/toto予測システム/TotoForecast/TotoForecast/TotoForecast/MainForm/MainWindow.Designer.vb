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
        Me.順位表ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.順位表ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.JリーグToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem()
        Me.miJ1Rank = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSectionResult = New System.Windows.Forms.ToolStripMenuItem()
        Me.登録ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.miClubReg = New System.Windows.Forms.ToolStripMenuItem()
        Me.入力ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSectionInput = New System.Windows.Forms.ToolStripMenuItem()
        Me.miSectionResultInput = New System.Windows.Forms.ToolStripMenuItem()
        Me.miTotoInput = New System.Windows.Forms.ToolStripMenuItem()
        Me.予想ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.採点予想ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.miEqualClubDetail = New System.Windows.Forms.ToolStripMenuItem()
        Me.結果比較ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.設定ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.miTotoForecastSetting = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ファイルToolStripMenuItem, Me.順位表ToolStripMenuItem, Me.登録ToolStripMenuItem, Me.入力ToolStripMenuItem, Me.予想ToolStripMenuItem, Me.設定ToolStripMenuItem})
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
        '順位表ToolStripMenuItem
        '
        Me.順位表ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.順位表ToolStripMenuItem1, Me.miSectionResult})
        Me.順位表ToolStripMenuItem.Name = "順位表ToolStripMenuItem"
        Me.順位表ToolStripMenuItem.Size = New System.Drawing.Size(44, 22)
        Me.順位表ToolStripMenuItem.Text = "確認"
        '
        '順位表ToolStripMenuItem1
        '
        Me.順位表ToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.JリーグToolStripMenuItem1})
        Me.順位表ToolStripMenuItem1.Name = "順位表ToolStripMenuItem1"
        Me.順位表ToolStripMenuItem1.Size = New System.Drawing.Size(124, 22)
        Me.順位表ToolStripMenuItem1.Text = "順位表"
        '
        'JリーグToolStripMenuItem1
        '
        Me.JリーグToolStripMenuItem1.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miJ1Rank})
        Me.JリーグToolStripMenuItem1.Name = "JリーグToolStripMenuItem1"
        Me.JリーグToolStripMenuItem1.Size = New System.Drawing.Size(117, 22)
        Me.JリーグToolStripMenuItem1.Text = "Jリーグ"
        '
        'miJ1Rank
        '
        Me.miJ1Rank.Name = "miJ1Rank"
        Me.miJ1Rank.Size = New System.Drawing.Size(88, 22)
        Me.miJ1Rank.Text = "J1"
        '
        'miSectionResult
        '
        Me.miSectionResult.Name = "miSectionResult"
        Me.miSectionResult.Size = New System.Drawing.Size(124, 22)
        Me.miSectionResult.Text = "試合結果"
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
        '入力ToolStripMenuItem
        '
        Me.入力ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.miSectionInput, Me.miSectionResultInput, Me.miTotoInput})
        Me.入力ToolStripMenuItem.Name = "入力ToolStripMenuItem"
        Me.入力ToolStripMenuItem.Size = New System.Drawing.Size(44, 22)
        Me.入力ToolStripMenuItem.Text = "入力"
        '
        'miSectionInput
        '
        Me.miSectionInput.Name = "miSectionInput"
        Me.miSectionInput.Size = New System.Drawing.Size(172, 22)
        Me.miSectionInput.Text = "試合入力"
        '
        'miSectionResultInput
        '
        Me.miSectionResultInput.Name = "miSectionResultInput"
        Me.miSectionResultInput.Size = New System.Drawing.Size(172, 22)
        Me.miSectionResultInput.Text = "試合結果入力"
        '
        'miTotoInput
        '
        Me.miTotoInput.Name = "miTotoInput"
        Me.miTotoInput.Size = New System.Drawing.Size(172, 22)
        Me.miTotoInput.Text = "toto予想試合入力"
        '
        '予想ToolStripMenuItem
        '
        Me.予想ToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.採点予想ToolStripMenuItem, Me.miEqualClubDetail, Me.結果比較ToolStripMenuItem})
        Me.予想ToolStripMenuItem.Name = "予想ToolStripMenuItem"
        Me.予想ToolStripMenuItem.Size = New System.Drawing.Size(44, 22)
        Me.予想ToolStripMenuItem.Text = "予想"
        '
        '採点予想ToolStripMenuItem
        '
        Me.採点予想ToolStripMenuItem.Name = "採点予想ToolStripMenuItem"
        Me.採点予想ToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.採点予想ToolStripMenuItem.Text = "採点予想"
        '
        'miEqualClubDetail
        '
        Me.miEqualClubDetail.Name = "miEqualClubDetail"
        Me.miEqualClubDetail.Size = New System.Drawing.Size(172, 22)
        Me.miEqualClubDetail.Text = "引き分け試合詳細"
        '
        '結果比較ToolStripMenuItem
        '
        Me.結果比較ToolStripMenuItem.Name = "結果比較ToolStripMenuItem"
        Me.結果比較ToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.結果比較ToolStripMenuItem.Text = "結果比較"
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
        Me.miTotoForecastSetting.Size = New System.Drawing.Size(152, 22)
        Me.miTotoForecastSetting.Text = "採点予想設定"
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
    Friend WithEvents miSectionInput As ToolStripMenuItem
    Friend WithEvents miSectionResultInput As ToolStripMenuItem
    Friend WithEvents miTotoInput As ToolStripMenuItem
    Friend WithEvents 予想ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 採点予想ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents miEqualClubDetail As ToolStripMenuItem
    Friend WithEvents 結果比較ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 設定ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents miTotoForecastSetting As ToolStripMenuItem
    Friend WithEvents 順位表ToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents JリーグToolStripMenuItem1 As ToolStripMenuItem
    Friend WithEvents miJ1Rank As ToolStripMenuItem
    Friend WithEvents miSectionResult As ToolStripMenuItem
End Class
