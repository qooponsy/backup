<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class RankListForm
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.grid = New System.Windows.Forms.DataGridView()
        Me.ClubCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LeagueCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LeagueDetailCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Year = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Rank = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClubCodeName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CurrentYear = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Points = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Win = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Lose = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Draw = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Score = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LostScore = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ScoreDiff = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lblYear = New System.Windows.Forms.Label()
        Me.lblRankTitle = New System.Windows.Forms.Label()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grid
        '
        Me.grid.AllowUserToAddRows = False
        Me.grid.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("MS UI Gothic", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grid.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ClubCode, Me.LeagueCode, Me.LeagueDetailCode, Me.Year, Me.Rank, Me.ClubCodeName, Me.CurrentYear, Me.Points, Me.Win, Me.Lose, Me.Draw, Me.Score, Me.LostScore, Me.ScoreDiff})
        Me.grid.Location = New System.Drawing.Point(12, 79)
        Me.grid.Name = "grid"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.grid.RowsDefaultCellStyle = DataGridViewCellStyle10
        Me.grid.RowTemplate.Height = 21
        Me.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grid.Size = New System.Drawing.Size(846, 366)
        Me.grid.TabIndex = 5
        '
        'ClubCode
        '
        Me.ClubCode.DataPropertyName = "ClubCode"
        Me.ClubCode.HeaderText = "クラブコード"
        Me.ClubCode.Name = "ClubCode"
        Me.ClubCode.Visible = False
        '
        'LeagueCode
        '
        Me.LeagueCode.DataPropertyName = "LeagueCode"
        Me.LeagueCode.HeaderText = "リーグコード"
        Me.LeagueCode.Name = "LeagueCode"
        Me.LeagueCode.Visible = False
        '
        'LeagueDetailCode
        '
        Me.LeagueDetailCode.DataPropertyName = "LeagueDetailCode"
        Me.LeagueDetailCode.HeaderText = "リーグ詳細コード"
        Me.LeagueDetailCode.Name = "LeagueDetailCode"
        Me.LeagueDetailCode.Visible = False
        '
        'Year
        '
        Me.Year.DataPropertyName = "Year"
        Me.Year.HeaderText = "年度"
        Me.Year.Name = "Year"
        Me.Year.Visible = False
        '
        'Rank
        '
        Me.Rank.DataPropertyName = "Rank"
        Me.Rank.HeaderText = "順位"
        Me.Rank.Name = "Rank"
        Me.Rank.ReadOnly = True
        Me.Rank.Width = 35
        '
        'ClubCodeName
        '
        Me.ClubCodeName.DataPropertyName = "ClubCodeName"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ClubCodeName.DefaultCellStyle = DataGridViewCellStyle2
        Me.ClubCodeName.HeaderText = "クラブ"
        Me.ClubCodeName.Name = "ClubCodeName"
        Me.ClubCodeName.ReadOnly = True
        '
        'CurrentYear
        '
        Me.CurrentYear.DataPropertyName = "CurrentYear"
        Me.CurrentYear.HeaderText = "試合数"
        Me.CurrentYear.Name = "CurrentYear"
        Me.CurrentYear.Visible = False
        '
        'Points
        '
        Me.Points.DataPropertyName = "Points"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Points.DefaultCellStyle = DataGridViewCellStyle3
        Me.Points.HeaderText = "勝ち点"
        Me.Points.Name = "Points"
        Me.Points.ReadOnly = True
        Me.Points.Width = 50
        '
        'Win
        '
        Me.Win.DataPropertyName = "Win"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Win.DefaultCellStyle = DataGridViewCellStyle4
        Me.Win.HeaderText = "勝ち数"
        Me.Win.Name = "Win"
        Me.Win.ReadOnly = True
        '
        'Lose
        '
        Me.Lose.DataPropertyName = "Lose"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Lose.DefaultCellStyle = DataGridViewCellStyle5
        Me.Lose.HeaderText = "負け数"
        Me.Lose.Name = "Lose"
        Me.Lose.ReadOnly = True
        '
        'Draw
        '
        Me.Draw.DataPropertyName = "Draw"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Draw.DefaultCellStyle = DataGridViewCellStyle6
        Me.Draw.HeaderText = "引き分け数"
        Me.Draw.Name = "Draw"
        Me.Draw.ReadOnly = True
        '
        'Score
        '
        Me.Score.DataPropertyName = "Score"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.Score.DefaultCellStyle = DataGridViewCellStyle7
        Me.Score.HeaderText = "得点数"
        Me.Score.Name = "Score"
        Me.Score.ReadOnly = True
        '
        'LostScore
        '
        Me.LostScore.DataPropertyName = "LostScore"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.LostScore.DefaultCellStyle = DataGridViewCellStyle8
        Me.LostScore.HeaderText = "失点数"
        Me.LostScore.Name = "LostScore"
        Me.LostScore.ReadOnly = True
        '
        'ScoreDiff
        '
        Me.ScoreDiff.DataPropertyName = "ScoreDiff"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.ScoreDiff.DefaultCellStyle = DataGridViewCellStyle9
        Me.ScoreDiff.HeaderText = "得失点"
        Me.ScoreDiff.Name = "ScoreDiff"
        Me.ScoreDiff.ReadOnly = True
        '
        'lblYear
        '
        Me.lblYear.AutoSize = True
        Me.lblYear.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblYear.Location = New System.Drawing.Point(13, 56)
        Me.lblYear.Name = "lblYear"
        Me.lblYear.Size = New System.Drawing.Size(76, 16)
        Me.lblYear.TabIndex = 4
        Me.lblYear.Text = "YYYY年度"
        '
        'lblRankTitle
        '
        Me.lblRankTitle.AutoSize = True
        Me.lblRankTitle.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblRankTitle.Location = New System.Drawing.Point(12, 21)
        Me.lblRankTitle.Name = "lblRankTitle"
        Me.lblRankTitle.Size = New System.Drawing.Size(206, 24)
        Me.lblRankTitle.TabIndex = 3
        Me.lblRankTitle.Text = "リーグ詳細名順位表"
        '
        'RankListForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(872, 457)
        Me.Controls.Add(Me.grid)
        Me.Controls.Add(Me.lblYear)
        Me.Controls.Add(Me.lblRankTitle)
        Me.Name = "RankListForm"
        Me.Text = "順位表"
        CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents grid As DataGridView
    Friend WithEvents lblYear As Label
    Friend WithEvents lblRankTitle As Label
    Friend WithEvents ClubCode As DataGridViewTextBoxColumn
    Friend WithEvents LeagueCode As DataGridViewTextBoxColumn
    Friend WithEvents LeagueDetailCode As DataGridViewTextBoxColumn
    Friend WithEvents Year As DataGridViewTextBoxColumn
    Friend WithEvents Rank As DataGridViewTextBoxColumn
    Friend WithEvents ClubCodeName As DataGridViewTextBoxColumn
    Friend WithEvents CurrentYear As DataGridViewTextBoxColumn
    Friend WithEvents Points As DataGridViewTextBoxColumn
    Friend WithEvents Win As DataGridViewTextBoxColumn
    Friend WithEvents Lose As DataGridViewTextBoxColumn
    Friend WithEvents Draw As DataGridViewTextBoxColumn
    Friend WithEvents Score As DataGridViewTextBoxColumn
    Friend WithEvents LostScore As DataGridViewTextBoxColumn
    Friend WithEvents ScoreDiff As DataGridViewTextBoxColumn
End Class
