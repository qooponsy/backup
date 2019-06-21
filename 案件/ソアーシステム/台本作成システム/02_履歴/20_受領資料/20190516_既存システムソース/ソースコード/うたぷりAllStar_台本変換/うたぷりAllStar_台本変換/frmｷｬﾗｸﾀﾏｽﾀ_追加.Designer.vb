<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmｷｬﾗｸﾀﾏｽﾀ_追加
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
        Me.txtセリフキャラ名 = New System.Windows.Forms.TextBox()
        Me.txt正式キャラ名 = New System.Windows.Forms.TextBox()
        Me.txtキャラ略名 = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btn追加
        '
        Me.btn追加.Location = New System.Drawing.Point(194, 95)
        Me.btn追加.Name = "btn追加"
        Me.btn追加.Size = New System.Drawing.Size(75, 33)
        Me.btn追加.TabIndex = 15
        Me.btn追加.Text = "追加"
        Me.btn追加.UseVisualStyleBackColor = True
        '
        'btn閉じる
        '
        Me.btn閉じる.Location = New System.Drawing.Point(275, 95)
        Me.btn閉じる.Name = "btn閉じる"
        Me.btn閉じる.Size = New System.Drawing.Size(75, 33)
        Me.btn閉じる.TabIndex = 14
        Me.btn閉じる.Text = "閉じる"
        Me.btn閉じる.UseVisualStyleBackColor = True
        '
        'txtセリフキャラ名
        '
        Me.txtセリフキャラ名.Location = New System.Drawing.Point(102, 68)
        Me.txtセリフキャラ名.Name = "txtセリフキャラ名"
        Me.txtセリフキャラ名.Size = New System.Drawing.Size(66, 19)
        Me.txtセリフキャラ名.TabIndex = 13
        '
        'txt正式キャラ名
        '
        Me.txt正式キャラ名.Location = New System.Drawing.Point(102, 39)
        Me.txt正式キャラ名.Name = "txt正式キャラ名"
        Me.txt正式キャラ名.Size = New System.Drawing.Size(248, 19)
        Me.txt正式キャラ名.TabIndex = 12
        '
        'txtキャラ略名
        '
        Me.txtキャラ略名.Location = New System.Drawing.Point(102, 12)
        Me.txtキャラ略名.Name = "txtキャラ略名"
        Me.txtキャラ略名.Size = New System.Drawing.Size(248, 19)
        Me.txtキャラ略名.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 72)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 12)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "セリフキャラ名"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 12)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "正式キャラクタ名"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 12)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "キャラクタ略名"
        '
        'frmｷｬﾗｸﾀﾏｽﾀ_追加
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(358, 140)
        Me.Controls.Add(Me.btn追加)
        Me.Controls.Add(Me.btn閉じる)
        Me.Controls.Add(Me.txtセリフキャラ名)
        Me.Controls.Add(Me.txt正式キャラ名)
        Me.Controls.Add(Me.txtキャラ略名)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "frmｷｬﾗｸﾀﾏｽﾀ_追加"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "ｷｬﾗｸﾀﾏｽﾀﾒﾝﾃﾅﾝｽ 追加"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn追加 As System.Windows.Forms.Button
    Friend WithEvents btn閉じる As System.Windows.Forms.Button
    Friend WithEvents txtセリフキャラ名 As System.Windows.Forms.TextBox
    Friend WithEvents txt正式キャラ名 As System.Windows.Forms.TextBox
    Friend WithEvents txtキャラ略名 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
