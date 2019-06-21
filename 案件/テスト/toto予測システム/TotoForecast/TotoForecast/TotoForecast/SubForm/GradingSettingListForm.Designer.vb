<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GradingSettingListForm
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnReg = New System.Windows.Forms.Button()
        Me.grid = New System.Windows.Forms.DataGridView()
        Me.GradingSettingCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GradingSetting = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.buy = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.ForecastCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CorrectAnsAve = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CorrectAnsMax = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrizeCount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.memo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnSave = New System.Windows.Forms.Button()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnReg
        '
        Me.btnReg.Location = New System.Drawing.Point(12, 12)
        Me.btnReg.Name = "btnReg"
        Me.btnReg.Size = New System.Drawing.Size(75, 23)
        Me.btnReg.TabIndex = 0
        Me.btnReg.Text = "設定追加"
        Me.btnReg.UseVisualStyleBackColor = True
        '
        'grid
        '
        Me.grid.AllowUserToAddRows = False
        Me.grid.AllowUserToDeleteRows = False
        Me.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GradingSettingCode, Me.GradingSetting, Me.buy, Me.ForecastCount, Me.CorrectAnsAve, Me.CorrectAnsMax, Me.PrizeCount, Me.memo})
        Me.grid.Location = New System.Drawing.Point(0, 41)
        Me.grid.Name = "grid"
        Me.grid.RowTemplate.Height = 21
        Me.grid.Size = New System.Drawing.Size(617, 333)
        Me.grid.TabIndex = 1
        '
        'GradingSettingCode
        '
        Me.GradingSettingCode.DataPropertyName = "GradingSettingCode"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.GradingSettingCode.DefaultCellStyle = DataGridViewCellStyle1
        Me.GradingSettingCode.HeaderText = "採点設定コード"
        Me.GradingSettingCode.Name = "GradingSettingCode"
        Me.GradingSettingCode.Visible = False
        '
        'GradingSetting
        '
        Me.GradingSetting.DataPropertyName = "GradingSetting"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.GradingSetting.DefaultCellStyle = DataGridViewCellStyle2
        Me.GradingSetting.HeaderText = "設定名"
        Me.GradingSetting.Name = "GradingSetting"
        Me.GradingSetting.ReadOnly = True
        Me.GradingSetting.Width = 200
        '
        'buy
        '
        Me.buy.DataPropertyName = "buy"
        Me.buy.HeaderText = "購入"
        Me.buy.Name = "buy"
        Me.buy.Width = 40
        '
        'ForecastCount
        '
        Me.ForecastCount.DataPropertyName = "ForecastCount"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.ForecastCount.DefaultCellStyle = DataGridViewCellStyle3
        Me.ForecastCount.HeaderText = "予想回数"
        Me.ForecastCount.Name = "ForecastCount"
        Me.ForecastCount.ReadOnly = True
        Me.ForecastCount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.ForecastCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ForecastCount.Width = 50
        '
        'CorrectAnsAve
        '
        Me.CorrectAnsAve.DataPropertyName = "CorrectAnsAve"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.CorrectAnsAve.DefaultCellStyle = DataGridViewCellStyle4
        Me.CorrectAnsAve.HeaderText = "平均正解数"
        Me.CorrectAnsAve.Name = "CorrectAnsAve"
        Me.CorrectAnsAve.ReadOnly = True
        Me.CorrectAnsAve.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CorrectAnsAve.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CorrectAnsAve.Width = 50
        '
        'CorrectAnsMax
        '
        Me.CorrectAnsMax.DataPropertyName = "CorrectAnsMax"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.CorrectAnsMax.DefaultCellStyle = DataGridViewCellStyle5
        Me.CorrectAnsMax.HeaderText = "最高正解数"
        Me.CorrectAnsMax.Name = "CorrectAnsMax"
        Me.CorrectAnsMax.ReadOnly = True
        Me.CorrectAnsMax.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CorrectAnsMax.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.CorrectAnsMax.Width = 50
        '
        'PrizeCount
        '
        Me.PrizeCount.DataPropertyName = "PrizeCount"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.PrizeCount.DefaultCellStyle = DataGridViewCellStyle6
        Me.PrizeCount.HeaderText = "賞金回数"
        Me.PrizeCount.Name = "PrizeCount"
        Me.PrizeCount.ReadOnly = True
        Me.PrizeCount.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.PrizeCount.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.PrizeCount.Width = 50
        '
        'memo
        '
        Me.memo.DataPropertyName = "memo"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.memo.DefaultCellStyle = DataGridViewCellStyle7
        Me.memo.HeaderText = "メモ"
        Me.memo.Name = "memo"
        Me.memo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.memo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.memo.Width = 120
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(93, 12)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 23)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "保存"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'GradingSettingListForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(633, 395)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.grid)
        Me.Controls.Add(Me.btnReg)
        Me.Name = "GradingSettingListForm"
        Me.Text = "採点設定一覧"
        CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnReg As Button
    Friend WithEvents grid As DataGridView
    Friend WithEvents btnSave As Button
    Friend WithEvents GradingSettingCode As DataGridViewTextBoxColumn
    Friend WithEvents GradingSetting As DataGridViewTextBoxColumn
    Friend WithEvents buy As DataGridViewCheckBoxColumn
    Friend WithEvents ForecastCount As DataGridViewTextBoxColumn
    Friend WithEvents CorrectAnsAve As DataGridViewTextBoxColumn
    Friend WithEvents CorrectAnsMax As DataGridViewTextBoxColumn
    Friend WithEvents PrizeCount As DataGridViewTextBoxColumn
    Friend WithEvents memo As DataGridViewTextBoxColumn
End Class
