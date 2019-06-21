<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClubListForm
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
        Me.lblLeagueTitle = New System.Windows.Forms.Label()
        Me.grid = New System.Windows.Forms.DataGridView()
        Me.ClubCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LeagueCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LeagueCodeName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LeagueDetailCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LeagueDetailCodeName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClubName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClubNameKana = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ShortName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ShortNameKana = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblLeagueTitle
        '
        Me.lblLeagueTitle.AutoSize = True
        Me.lblLeagueTitle.Font = New System.Drawing.Font("MS UI Gothic", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.lblLeagueTitle.Location = New System.Drawing.Point(12, 18)
        Me.lblLeagueTitle.Name = "lblLeagueTitle"
        Me.lblLeagueTitle.Size = New System.Drawing.Size(158, 24)
        Me.lblLeagueTitle.TabIndex = 4
        Me.lblLeagueTitle.Text = "リーグ名一覧表"
        '
        'grid
        '
        Me.grid.AllowUserToAddRows = False
        Me.grid.AllowUserToDeleteRows = False
        Me.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ClubCode, Me.LeagueCode, Me.LeagueCodeName, Me.LeagueDetailCode, Me.LeagueDetailCodeName, Me.ClubName, Me.ClubNameKana, Me.ShortName, Me.ShortNameKana})
        Me.grid.Location = New System.Drawing.Point(16, 70)
        Me.grid.Name = "grid"
        Me.grid.RowTemplate.Height = 21
        Me.grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.grid.Size = New System.Drawing.Size(758, 356)
        Me.grid.TabIndex = 5
        '
        'ClubCode
        '
        Me.ClubCode.DataPropertyName = "ClubCode"
        Me.ClubCode.HeaderText = "クラブコード"
        Me.ClubCode.Name = "ClubCode"
        '
        'LeagueCode
        '
        Me.LeagueCode.DataPropertyName = "LeagueCode"
        Me.LeagueCode.HeaderText = "リーグコード"
        Me.LeagueCode.Name = "LeagueCode"
        Me.LeagueCode.Visible = False
        '
        'LeagueCodeName
        '
        Me.LeagueCodeName.DataPropertyName = "LeagueCodeName"
        Me.LeagueCodeName.HeaderText = "リーグ名"
        Me.LeagueCodeName.Name = "LeagueCodeName"
        '
        'LeagueDetailCode
        '
        Me.LeagueDetailCode.DataPropertyName = "LeagueDetailCode"
        Me.LeagueDetailCode.HeaderText = "リーグ詳細コード"
        Me.LeagueDetailCode.Name = "LeagueDetailCode"
        Me.LeagueDetailCode.Visible = False
        '
        'LeagueDetailCodeName
        '
        Me.LeagueDetailCodeName.DataPropertyName = "LeagueDetailCodeName"
        Me.LeagueDetailCodeName.HeaderText = "リーグ詳細名"
        Me.LeagueDetailCodeName.Name = "LeagueDetailCodeName"
        '
        'ClubName
        '
        Me.ClubName.DataPropertyName = "ClubName"
        Me.ClubName.HeaderText = "クラブ名"
        Me.ClubName.Name = "ClubName"
        '
        'ClubNameKana
        '
        Me.ClubNameKana.DataPropertyName = "ClubNameKana"
        Me.ClubNameKana.HeaderText = "クラブ名カナ"
        Me.ClubNameKana.Name = "ClubNameKana"
        '
        'ShortName
        '
        Me.ShortName.DataPropertyName = "ShortName"
        Me.ShortName.HeaderText = "短縮名"
        Me.ShortName.Name = "ShortName"
        '
        'ShortNameKana
        '
        Me.ShortNameKana.DataPropertyName = "ShortNameKana"
        Me.ShortNameKana.HeaderText = "短縮名カナ"
        Me.ShortNameKana.Name = "ShortNameKana"
        '
        'ClubListForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(786, 438)
        Me.Controls.Add(Me.grid)
        Me.Controls.Add(Me.lblLeagueTitle)
        Me.Name = "ClubListForm"
        Me.Text = "ClubListForm"
        CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblLeagueTitle As Label
    Friend WithEvents grid As DataGridView
    Friend WithEvents ClubCode As DataGridViewTextBoxColumn
    Friend WithEvents LeagueCode As DataGridViewTextBoxColumn
    Friend WithEvents LeagueCodeName As DataGridViewTextBoxColumn
    Friend WithEvents LeagueDetailCode As DataGridViewTextBoxColumn
    Friend WithEvents LeagueDetailCodeName As DataGridViewTextBoxColumn
    Friend WithEvents ClubName As DataGridViewTextBoxColumn
    Friend WithEvents ClubNameKana As DataGridViewTextBoxColumn
    Friend WithEvents ShortName As DataGridViewTextBoxColumn
    Friend WithEvents ShortNameKana As DataGridViewTextBoxColumn
End Class
