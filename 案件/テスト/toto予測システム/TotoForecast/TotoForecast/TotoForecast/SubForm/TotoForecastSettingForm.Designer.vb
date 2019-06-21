<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TotoForecastSettingForm
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grid = New System.Windows.Forms.DataGridView()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GradingSettingDetailCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GradingSettingCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CategoryCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CategoryName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Magnification = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.grid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 12)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "採点名"
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(59, 15)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(245, 19)
        Me.TextBox1.TabIndex = 1
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(59, 62)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(245, 41)
        Me.TextBox2.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(22, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "メモ"
        '
        'grid
        '
        Me.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GradingSettingDetailCode, Me.GradingSettingCode, Me.CategoryCode, Me.CategoryName, Me.Magnification})
        Me.grid.Location = New System.Drawing.Point(14, 129)
        Me.grid.Name = "grid"
        Me.grid.RowTemplate.Height = 21
        Me.grid.Size = New System.Drawing.Size(292, 278)
        Me.grid.TabIndex = 4
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(12, 40)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(48, 16)
        Me.CheckBox1.TabIndex = 6
        Me.CheckBox1.Text = "購入"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "採点設定"
        '
        'GradingSettingDetailCode
        '
        Me.GradingSettingDetailCode.DataPropertyName = "GradingSettingDetailCode"
        Me.GradingSettingDetailCode.HeaderText = "採点設定詳細コード"
        Me.GradingSettingDetailCode.Name = "GradingSettingDetailCode"
        Me.GradingSettingDetailCode.Visible = False
        '
        'GradingSettingCode
        '
        Me.GradingSettingCode.DataPropertyName = "GradingSettingCode"
        Me.GradingSettingCode.HeaderText = "採点設定コード"
        Me.GradingSettingCode.Name = "GradingSettingCode"
        Me.GradingSettingCode.Visible = False
        '
        'CategoryCode
        '
        Me.CategoryCode.DataPropertyName = "CategoryCode"
        Me.CategoryCode.HeaderText = "採点カテゴリーコード"
        Me.CategoryCode.Name = "CategoryCode"
        Me.CategoryCode.Visible = False
        '
        'CategoryName
        '
        Me.CategoryName.DataPropertyName = "CategoryName"
        Me.CategoryName.HeaderText = "カテゴリー名"
        Me.CategoryName.Name = "CategoryName"
        Me.CategoryName.Width = 200
        '
        'Magnification
        '
        Me.Magnification.DataPropertyName = "Magnification"
        Me.Magnification.HeaderText = "倍率"
        Me.Magnification.Name = "Magnification"
        Me.Magnification.Width = 40
        '
        'TotoForecastCreateForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(316, 419)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.grid)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "TotoForecastCreateForm"
        Me.Text = "採点予想作成"
        CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents grid As DataGridView
    Friend WithEvents GradingSettingDetailCode As DataGridViewTextBoxColumn
    Friend WithEvents GradingSettingCode As DataGridViewTextBoxColumn
    Friend WithEvents CategoryCode As DataGridViewTextBoxColumn
    Friend WithEvents CategoryName As DataGridViewTextBoxColumn
    Friend WithEvents Magnification As DataGridViewTextBoxColumn
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents Label3 As Label
End Class
