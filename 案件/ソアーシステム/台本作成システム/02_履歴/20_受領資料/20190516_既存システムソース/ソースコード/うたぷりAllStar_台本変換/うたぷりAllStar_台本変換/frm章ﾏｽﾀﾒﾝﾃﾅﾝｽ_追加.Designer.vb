<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frm章ﾏｽﾀﾒﾝﾃﾅﾝｽ_追加
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
        Me.btn追加 = New System.Windows.Forms.Button()
        Me.btn閉じる = New System.Windows.Forms.Button()
        Me.txt記号 = New System.Windows.Forms.TextBox()
        Me.txt章名 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btn追加
        '
        Me.btn追加.Location = New System.Drawing.Point(332, 66)
        Me.btn追加.Name = "btn追加"
        Me.btn追加.Size = New System.Drawing.Size(75, 33)
        Me.btn追加.TabIndex = 21
        Me.btn追加.Text = "追加"
        Me.btn追加.UseVisualStyleBackColor = True
        '
        'btn閉じる
        '
        Me.btn閉じる.Location = New System.Drawing.Point(413, 66)
        Me.btn閉じる.Name = "btn閉じる"
        Me.btn閉じる.Size = New System.Drawing.Size(75, 33)
        Me.btn閉じる.TabIndex = 20
        Me.btn閉じる.Text = "閉じる"
        Me.btn閉じる.UseVisualStyleBackColor = True
        '
        'txt記号
        '
        Me.txt記号.Location = New System.Drawing.Point(45, 37)
        Me.txt記号.Name = "txt記号"
        Me.txt記号.Size = New System.Drawing.Size(66, 19)
        Me.txt記号.TabIndex = 19
        '
        'txt章名
        '
        Me.txt章名.Location = New System.Drawing.Point(45, 12)
        Me.txt章名.Name = "txt章名"
        Me.txt章名.Size = New System.Drawing.Size(443, 19)
        Me.txt章名.TabIndex = 18
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(29, 12)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "記号"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(29, 12)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "章名"
        '
        'frm章ﾏｽﾀﾒﾝﾃﾅﾝｽ_追加
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(498, 110)
        Me.Controls.Add(Me.btn追加)
        Me.Controls.Add(Me.btn閉じる)
        Me.Controls.Add(Me.txt記号)
        Me.Controls.Add(Me.txt章名)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MinimizeBox = False
        Me.Name = "frm章ﾏｽﾀﾒﾝﾃﾅﾝｽ_追加"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "章ﾏｽﾀﾒﾝﾃﾅﾝｽ 追加"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn追加 As System.Windows.Forms.Button
    Friend WithEvents btn閉じる As System.Windows.Forms.Button
    Friend WithEvents txt記号 As System.Windows.Forms.TextBox
    Friend WithEvents txt章名 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
