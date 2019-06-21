<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm章ﾏｽﾀﾒﾝﾃﾅﾝｽ
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
        Me.btn削除 = New System.Windows.Forms.Button()
        Me.btn追加 = New System.Windows.Forms.Button()
        Me.btn変更 = New System.Windows.Forms.Button()
        Me.btn閉じる = New System.Windows.Forms.Button()
        Me.GrdItem = New System.Windows.Forms.DataGridView()
        CType(Me.GrdItem, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn削除
        '
        Me.btn削除.Location = New System.Drawing.Point(395, 334)
        Me.btn削除.Name = "btn削除"
        Me.btn削除.Size = New System.Drawing.Size(88, 36)
        Me.btn削除.TabIndex = 14
        Me.btn削除.Text = "削除"
        Me.btn削除.UseVisualStyleBackColor = True
        '
        'btn追加
        '
        Me.btn追加.Location = New System.Drawing.Point(207, 334)
        Me.btn追加.Name = "btn追加"
        Me.btn追加.Size = New System.Drawing.Size(88, 36)
        Me.btn追加.TabIndex = 13
        Me.btn追加.Text = "追加"
        Me.btn追加.UseVisualStyleBackColor = True
        '
        'btn変更
        '
        Me.btn変更.Location = New System.Drawing.Point(301, 334)
        Me.btn変更.Name = "btn変更"
        Me.btn変更.Size = New System.Drawing.Size(88, 36)
        Me.btn変更.TabIndex = 12
        Me.btn変更.Text = "変更"
        Me.btn変更.UseVisualStyleBackColor = True
        '
        'btn閉じる
        '
        Me.btn閉じる.Location = New System.Drawing.Point(489, 334)
        Me.btn閉じる.Name = "btn閉じる"
        Me.btn閉じる.Size = New System.Drawing.Size(88, 36)
        Me.btn閉じる.TabIndex = 11
        Me.btn閉じる.Text = "閉じる"
        Me.btn閉じる.UseVisualStyleBackColor = True
        '
        'GrdItem
        '
        Me.GrdItem.AllowUserToAddRows = False
        Me.GrdItem.AllowUserToDeleteRows = False
        Me.GrdItem.ColumnHeadersHeight = 30
        Me.GrdItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.GrdItem.Location = New System.Drawing.Point(12, 12)
        Me.GrdItem.Name = "GrdItem"
        Me.GrdItem.ReadOnly = True
        Me.GrdItem.RowTemplate.Height = 30
        Me.GrdItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.GrdItem.Size = New System.Drawing.Size(565, 314)
        Me.GrdItem.TabIndex = 10
        '
        'frm章ﾏｽﾀﾒﾝﾃﾅﾝｽ
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(585, 378)
        Me.Controls.Add(Me.btn削除)
        Me.Controls.Add(Me.btn追加)
        Me.Controls.Add(Me.btn変更)
        Me.Controls.Add(Me.btn閉じる)
        Me.Controls.Add(Me.GrdItem)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frm章ﾏｽﾀﾒﾝﾃﾅﾝｽ"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "章ﾏｽﾀﾒﾝﾃﾅﾝｽ"
        CType(Me.GrdItem, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btn削除 As System.Windows.Forms.Button
    Friend WithEvents btn追加 As System.Windows.Forms.Button
    Friend WithEvents btn変更 As System.Windows.Forms.Button
    Friend WithEvents btn閉じる As System.Windows.Forms.Button
    Friend WithEvents GrdItem As System.Windows.Forms.DataGridView
End Class
