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
        Me.tbGradingSetting = New System.Windows.Forms.TextBox()
        Me.tbMemo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.grid = New System.Windows.Forms.DataGridView()
        Me.GradingSettingDetailCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GradingSettingCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CategoryCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CategoryName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Magnification = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.chkBuy = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnInput = New System.Windows.Forms.Button()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbDrawValue = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbEqualValue = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
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
        'tbGradingSetting
        '
        Me.tbGradingSetting.Location = New System.Drawing.Point(59, 15)
        Me.tbGradingSetting.Name = "tbGradingSetting"
        Me.tbGradingSetting.Size = New System.Drawing.Size(273, 19)
        Me.tbGradingSetting.TabIndex = 1
        '
        'tbMemo
        '
        Me.tbMemo.Location = New System.Drawing.Point(59, 62)
        Me.tbMemo.Multiline = True
        Me.tbMemo.Name = "tbMemo"
        Me.tbMemo.Size = New System.Drawing.Size(273, 41)
        Me.tbMemo.TabIndex = 2
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
        Me.grid.AllowUserToAddRows = False
        Me.grid.AllowUserToDeleteRows = False
        Me.grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.GradingSettingDetailCode, Me.GradingSettingCode, Me.CategoryCode, Me.CategoryName, Me.Magnification})
        Me.grid.Location = New System.Drawing.Point(12, 209)
        Me.grid.Name = "grid"
        Me.grid.RowTemplate.Height = 21
        Me.grid.Size = New System.Drawing.Size(318, 278)
        Me.grid.TabIndex = 4
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
        Me.CategoryName.ReadOnly = True
        Me.CategoryName.Width = 200
        '
        'Magnification
        '
        Me.Magnification.DataPropertyName = "Magnification"
        Me.Magnification.HeaderText = "倍率"
        Me.Magnification.Name = "Magnification"
        Me.Magnification.Width = 60
        '
        'chkBuy
        '
        Me.chkBuy.AutoSize = True
        Me.chkBuy.Location = New System.Drawing.Point(12, 40)
        Me.chkBuy.Name = "chkBuy"
        Me.chkBuy.Size = New System.Drawing.Size(48, 16)
        Me.chkBuy.TabIndex = 6
        Me.chkBuy.Text = "購入"
        Me.chkBuy.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 194)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 12)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "採点設定"
        '
        'btnInput
        '
        Me.btnInput.Location = New System.Drawing.Point(139, 498)
        Me.btnInput.Name = "btnInput"
        Me.btnInput.Size = New System.Drawing.Size(75, 23)
        Me.btnInput.TabIndex = 8
        Me.btnInput.Text = "登録"
        Me.btnInput.UseVisualStyleBackColor = True
        Me.btnInput.Visible = False
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(138, 498)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 9
        Me.btnUpdate.Text = "更新"
        Me.btnUpdate.UseVisualStyleBackColor = True
        Me.btnUpdate.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 114)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 12)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "ドロー基準"
        '
        'tbDrawValue
        '
        Me.tbDrawValue.Location = New System.Drawing.Point(59, 132)
        Me.tbDrawValue.Name = "tbDrawValue"
        Me.tbDrawValue.Size = New System.Drawing.Size(63, 19)
        Me.tbDrawValue.TabIndex = 11
        Me.tbDrawValue.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(128, 135)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(86, 12)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "点以内だとドロー"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 154)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(78, 12)
        Me.Label6.TabIndex = 13
        Me.Label6.Text = "同等クラブ基準"
        '
        'tbEqualValue
        '
        Me.tbEqualValue.Location = New System.Drawing.Point(59, 172)
        Me.tbEqualValue.Name = "tbEqualValue"
        Me.tbEqualValue.Size = New System.Drawing.Size(63, 19)
        Me.tbEqualValue.TabIndex = 14
        Me.tbEqualValue.Text = "0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(128, 175)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(104, 12)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "点以内だと同等扱い"
        '
        'TotoForecastSettingForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(344, 536)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tbEqualValue)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.tbDrawValue)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.btnInput)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.chkBuy)
        Me.Controls.Add(Me.grid)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.tbMemo)
        Me.Controls.Add(Me.tbGradingSetting)
        Me.Controls.Add(Me.Label1)
        Me.Name = "TotoForecastSettingForm"
        Me.Text = "採点予想作成"
        CType(Me.grid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents tbGradingSetting As TextBox
    Friend WithEvents tbMemo As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents grid As DataGridView
    Friend WithEvents chkBuy As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents btnInput As Button
    Friend WithEvents btnUpdate As Button
    Friend WithEvents GradingSettingDetailCode As DataGridViewTextBoxColumn
    Friend WithEvents GradingSettingCode As DataGridViewTextBoxColumn
    Friend WithEvents CategoryCode As DataGridViewTextBoxColumn
    Friend WithEvents CategoryName As DataGridViewTextBoxColumn
    Friend WithEvents Magnification As DataGridViewTextBoxColumn
    Friend WithEvents Label4 As Label
    Friend WithEvents tbDrawValue As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents tbEqualValue As TextBox
    Friend WithEvents Label7 As Label
End Class
