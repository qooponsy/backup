<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
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
        Me.lblエラー件数 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblExcel = New System.Windows.Forms.Label()
        Me.ProgressBar = New System.Windows.Forms.ProgressBar()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.btnボイスナンバー = New System.Windows.Forms.Button()
        Me.cmb章 = New System.Windows.Forms.ComboBox()
        Me.Cmbルート = New System.Windows.Forms.ComboBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn参照 = New System.Windows.Forms.Button()
        Me.txtファイル名 = New System.Windows.Forms.TextBox()
        Me.dgvItem = New System.Windows.Forms.DataGridView()
        Me.Cmbキャラ = New System.Windows.Forms.ComboBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ﾌｧｲﾙToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.終了XToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ﾏｽﾀﾒﾝﾃﾅﾝｽToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ｷｬﾗｸﾀﾏｽﾀﾒﾝﾃﾅﾝｽToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.章ﾏｽﾀﾒﾝﾃﾅﾝｽToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ﾙｰﾄﾏｽﾀﾒﾝﾃﾅﾝｽToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.Cmb行間 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblエラー件数
        '
        Me.lblエラー件数.AutoSize = True
        Me.lblエラー件数.Location = New System.Drawing.Point(666, 115)
        Me.lblエラー件数.Name = "lblエラー件数"
        Me.lblエラー件数.Size = New System.Drawing.Size(62, 12)
        Me.lblエラー件数.TabIndex = 30
        Me.lblエラー件数.Text = "エラー件数："
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(709, 623)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(53, 12)
        Me.Label1.TabIndex = 29
        Me.Label1.Text = "太字指定"
        '
        'lblExcel
        '
        Me.lblExcel.AutoSize = True
        Me.lblExcel.Location = New System.Drawing.Point(20, 625)
        Me.lblExcel.Name = "lblExcel"
        Me.lblExcel.Size = New System.Drawing.Size(41, 12)
        Me.lblExcel.TabIndex = 28
        Me.lblExcel.Text = "出力中"
        Me.lblExcel.Visible = False
        '
        'ProgressBar
        '
        Me.ProgressBar.Location = New System.Drawing.Point(20, 638)
        Me.ProgressBar.Name = "ProgressBar"
        Me.ProgressBar.Size = New System.Drawing.Size(325, 18)
        Me.ProgressBar.TabIndex = 27
        Me.ProgressBar.Visible = False
        '
        'btnExcel
        '
        Me.btnExcel.Enabled = False
        Me.btnExcel.Location = New System.Drawing.Point(862, 623)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(97, 37)
        Me.btnExcel.TabIndex = 26
        Me.btnExcel.Text = "Excel出力"
        Me.btnExcel.UseVisualStyleBackColor = True
        '
        'btnボイスナンバー
        '
        Me.btnボイスナンバー.Enabled = False
        Me.btnボイスナンバー.Location = New System.Drawing.Point(543, 99)
        Me.btnボイスナンバー.Name = "btnボイスナンバー"
        Me.btnボイスナンバー.Size = New System.Drawing.Size(117, 33)
        Me.btnボイスナンバー.TabIndex = 25
        Me.btnボイスナンバー.Text = "ボイスナンバー付与"
        Me.btnボイスナンバー.UseVisualStyleBackColor = True
        '
        'cmb章
        '
        Me.cmb章.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmb章.Enabled = False
        Me.cmb章.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.cmb章.FormattingEnabled = True
        Me.cmb章.Location = New System.Drawing.Point(14, 109)
        Me.cmb章.Name = "cmb章"
        Me.cmb章.Size = New System.Drawing.Size(340, 23)
        Me.cmb章.TabIndex = 24
        '
        'Cmbルート
        '
        Me.Cmbルート.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmbルート.Enabled = False
        Me.Cmbルート.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Cmbルート.FormattingEnabled = True
        Me.Cmbルート.Location = New System.Drawing.Point(360, 109)
        Me.Cmbルート.Name = "Cmbルート"
        Me.Cmbルート.Size = New System.Drawing.Size(177, 23)
        Me.Cmbルート.TabIndex = 23
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn参照)
        Me.GroupBox1.Controls.Add(Me.txtファイル名)
        Me.GroupBox1.Location = New System.Drawing.Point(14, 29)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(945, 64)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "ファイル名"
        '
        'btn参照
        '
        Me.btn参照.Location = New System.Drawing.Point(848, 16)
        Me.btn参照.Name = "btn参照"
        Me.btn参照.Size = New System.Drawing.Size(87, 34)
        Me.btn参照.TabIndex = 6
        Me.btn参照.Text = "ファイル選択"
        Me.btn参照.UseVisualStyleBackColor = True
        '
        'txtファイル名
        '
        Me.txtファイル名.Font = New System.Drawing.Font("MS UI Gothic", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.txtファイル名.Location = New System.Drawing.Point(6, 27)
        Me.txtファイル名.Name = "txtファイル名"
        Me.txtファイル名.ReadOnly = True
        Me.txtファイル名.Size = New System.Drawing.Size(836, 23)
        Me.txtファイル名.TabIndex = 5
        '
        'dgvItem
        '
        Me.dgvItem.AllowUserToAddRows = False
        Me.dgvItem.AllowUserToDeleteRows = False
        Me.dgvItem.ColumnHeadersHeight = 30
        Me.dgvItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.dgvItem.Location = New System.Drawing.Point(17, 138)
        Me.dgvItem.Name = "dgvItem"
        Me.dgvItem.ReadOnly = True
        Me.dgvItem.RowTemplate.Height = 30
        Me.dgvItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvItem.Size = New System.Drawing.Size(942, 475)
        Me.dgvItem.TabIndex = 21
        '
        'Cmbキャラ
        '
        Me.Cmbキャラ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmbキャラ.Enabled = False
        Me.Cmbキャラ.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Cmbキャラ.FormattingEnabled = True
        Me.Cmbキャラ.Location = New System.Drawing.Point(711, 637)
        Me.Cmbキャラ.Name = "Cmbキャラ"
        Me.Cmbキャラ.Size = New System.Drawing.Size(145, 23)
        Me.Cmbキャラ.TabIndex = 20
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ﾌｧｲﾙToolStripMenuItem, Me.ﾏｽﾀﾒﾝﾃﾅﾝｽToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(971, 26)
        Me.MenuStrip1.TabIndex = 31
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ﾌｧｲﾙToolStripMenuItem
        '
        Me.ﾌｧｲﾙToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.終了XToolStripMenuItem})
        Me.ﾌｧｲﾙToolStripMenuItem.Name = "ﾌｧｲﾙToolStripMenuItem"
        Me.ﾌｧｲﾙToolStripMenuItem.Size = New System.Drawing.Size(61, 22)
        Me.ﾌｧｲﾙToolStripMenuItem.Text = "ﾌｧｲﾙ(&F)"
        '
        '終了XToolStripMenuItem
        '
        Me.終了XToolStripMenuItem.Name = "終了XToolStripMenuItem"
        Me.終了XToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
        Me.終了XToolStripMenuItem.Text = "終了(&X)"
        '
        'ﾏｽﾀﾒﾝﾃﾅﾝｽToolStripMenuItem
        '
        Me.ﾏｽﾀﾒﾝﾃﾅﾝｽToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ｷｬﾗｸﾀﾏｽﾀﾒﾝﾃﾅﾝｽToolStripMenuItem, Me.章ﾏｽﾀﾒﾝﾃﾅﾝｽToolStripMenuItem, Me.ﾙｰﾄﾏｽﾀﾒﾝﾃﾅﾝｽToolStripMenuItem})
        Me.ﾏｽﾀﾒﾝﾃﾅﾝｽToolStripMenuItem.Name = "ﾏｽﾀﾒﾝﾃﾅﾝｽToolStripMenuItem"
        Me.ﾏｽﾀﾒﾝﾃﾅﾝｽToolStripMenuItem.Size = New System.Drawing.Size(94, 22)
        Me.ﾏｽﾀﾒﾝﾃﾅﾝｽToolStripMenuItem.Text = "ﾏｽﾀﾒﾝﾃﾅﾝｽ(&M)"
        '
        'ｷｬﾗｸﾀﾏｽﾀﾒﾝﾃﾅﾝｽToolStripMenuItem
        '
        Me.ｷｬﾗｸﾀﾏｽﾀﾒﾝﾃﾅﾝｽToolStripMenuItem.Name = "ｷｬﾗｸﾀﾏｽﾀﾒﾝﾃﾅﾝｽToolStripMenuItem"
        Me.ｷｬﾗｸﾀﾏｽﾀﾒﾝﾃﾅﾝｽToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.ｷｬﾗｸﾀﾏｽﾀﾒﾝﾃﾅﾝｽToolStripMenuItem.Text = "ｷｬﾗｸﾀﾏｽﾀﾒﾝﾃﾅﾝｽ..."
        '
        '章ﾏｽﾀﾒﾝﾃﾅﾝｽToolStripMenuItem
        '
        Me.章ﾏｽﾀﾒﾝﾃﾅﾝｽToolStripMenuItem.Name = "章ﾏｽﾀﾒﾝﾃﾅﾝｽToolStripMenuItem"
        Me.章ﾏｽﾀﾒﾝﾃﾅﾝｽToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.章ﾏｽﾀﾒﾝﾃﾅﾝｽToolStripMenuItem.Text = "章ﾏｽﾀﾒﾝﾃﾅﾝｽ..."
        '
        'ﾙｰﾄﾏｽﾀﾒﾝﾃﾅﾝｽToolStripMenuItem
        '
        Me.ﾙｰﾄﾏｽﾀﾒﾝﾃﾅﾝｽToolStripMenuItem.Name = "ﾙｰﾄﾏｽﾀﾒﾝﾃﾅﾝｽToolStripMenuItem"
        Me.ﾙｰﾄﾏｽﾀﾒﾝﾃﾅﾝｽToolStripMenuItem.Size = New System.Drawing.Size(172, 22)
        Me.ﾙｰﾄﾏｽﾀﾒﾝﾃﾅﾝｽToolStripMenuItem.Text = "ﾙｰﾄﾏｽﾀﾒﾝﾃﾅﾝｽ..."
        '
        'Cmb行間
        '
        Me.Cmb行間.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Cmb行間.Font = New System.Drawing.Font("MS UI Gothic", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(128, Byte))
        Me.Cmb行間.FormattingEnabled = True
        Me.Cmb行間.Location = New System.Drawing.Point(654, 637)
        Me.Cmb行間.Name = "Cmb行間"
        Me.Cmb行間.Size = New System.Drawing.Size(51, 23)
        Me.Cmb行間.TabIndex = 32
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(655, 623)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 33
        Me.Label2.Text = "行間"
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(971, 671)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Cmb行間)
        Me.Controls.Add(Me.lblエラー件数)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblExcel)
        Me.Controls.Add(Me.ProgressBar)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.btnボイスナンバー)
        Me.Controls.Add(Me.cmb章)
        Me.Controls.Add(Me.Cmbルート)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dgvItem)
        Me.Controls.Add(Me.Cmbキャラ)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "frmMain"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "うたの☆プリンスさまっ♪AllStar 台本変換"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblエラー件数 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblExcel As System.Windows.Forms.Label
    Friend WithEvents ProgressBar As System.Windows.Forms.ProgressBar
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents btnボイスナンバー As System.Windows.Forms.Button
    Friend WithEvents cmb章 As System.Windows.Forms.ComboBox
    Friend WithEvents Cmbルート As System.Windows.Forms.ComboBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btn参照 As System.Windows.Forms.Button
    Friend WithEvents txtファイル名 As System.Windows.Forms.TextBox
    Friend WithEvents dgvItem As System.Windows.Forms.DataGridView
    Friend WithEvents Cmbキャラ As System.Windows.Forms.ComboBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents PrintDocument1 As System.Drawing.Printing.PrintDocument
    Friend WithEvents ﾌｧｲﾙToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 終了XToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ﾏｽﾀﾒﾝﾃﾅﾝｽToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ｷｬﾗｸﾀﾏｽﾀﾒﾝﾃﾅﾝｽToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 章ﾏｽﾀﾒﾝﾃﾅﾝｽToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ﾙｰﾄﾏｽﾀﾒﾝﾃﾅﾝｽToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents Cmb行間 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
