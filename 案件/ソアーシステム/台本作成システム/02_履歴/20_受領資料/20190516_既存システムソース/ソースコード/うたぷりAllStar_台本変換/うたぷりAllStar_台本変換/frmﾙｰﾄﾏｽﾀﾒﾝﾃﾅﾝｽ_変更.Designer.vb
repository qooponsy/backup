<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmﾙｰﾄﾏｽﾀﾒﾝﾃﾅﾝｽ_変更
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
        Me.btn変更 = New System.Windows.Forms.Button()
        Me.btn閉じる = New System.Windows.Forms.Button()
        Me.txt記号 = New System.Windows.Forms.TextBox()
        Me.txtルート名 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btn変更
        '
        Me.btn変更.Location = New System.Drawing.Point(124, 68)
        Me.btn変更.Name = "btn変更"
        Me.btn変更.Size = New System.Drawing.Size(75, 33)
        Me.btn変更.TabIndex = 33
        Me.btn変更.Text = "変更"
        Me.btn変更.UseVisualStyleBackColor = True
        '
        'btn閉じる
        '
        Me.btn閉じる.Location = New System.Drawing.Point(205, 68)
        Me.btn閉じる.Name = "btn閉じる"
        Me.btn閉じる.Size = New System.Drawing.Size(75, 33)
        Me.btn閉じる.TabIndex = 32
        Me.btn閉じる.Text = "閉じる"
        Me.btn閉じる.UseVisualStyleBackColor = True
        '
        'txt記号
        '
        Me.txt記号.Location = New System.Drawing.Point(67, 37)
        Me.txt記号.Name = "txt記号"
        Me.txt記号.Size = New System.Drawing.Size(66, 19)
        Me.txt記号.TabIndex = 31
        '
        'txtルート名
        '
        Me.txtルート名.Location = New System.Drawing.Point(67, 12)
        Me.txtルート名.Name = "txtルート名"
        Me.txtルート名.Size = New System.Drawing.Size(213, 19)
        Me.txtルート名.TabIndex = 30
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 12)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "記号"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 12)
        Me.Label1.TabIndex = 28
        Me.Label1.Text = "ルート名"
        '
        'frmﾙｰﾄﾏｽﾀﾒﾝﾃﾅﾝｽ_変更
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(291, 114)
        Me.Controls.Add(Me.btn変更)
        Me.Controls.Add(Me.btn閉じる)
        Me.Controls.Add(Me.txt記号)
        Me.Controls.Add(Me.txtルート名)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmﾙｰﾄﾏｽﾀﾒﾝﾃﾅﾝｽ_変更"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ﾙｰﾄﾏｽﾀﾒﾝﾃﾅﾝｽ 変更"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn変更 As System.Windows.Forms.Button
    Friend WithEvents btn閉じる As System.Windows.Forms.Button
    Friend WithEvents txt記号 As System.Windows.Forms.TextBox
    Friend WithEvents txtルート名 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
