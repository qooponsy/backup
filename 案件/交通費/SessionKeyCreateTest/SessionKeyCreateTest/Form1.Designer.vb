<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Me.btnConvert = New System.Windows.Forms.Button()
        Me.tbBaseStr = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbSessionKey = New System.Windows.Forms.TextBox()
        Me.tbSHA256 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btnConvert
        '
        Me.btnConvert.Location = New System.Drawing.Point(320, 28)
        Me.btnConvert.Name = "btnConvert"
        Me.btnConvert.Size = New System.Drawing.Size(75, 23)
        Me.btnConvert.TabIndex = 0
        Me.btnConvert.Text = "変換"
        Me.btnConvert.UseVisualStyleBackColor = True
        '
        'tbBaseStr
        '
        Me.tbBaseStr.Location = New System.Drawing.Point(82, 30)
        Me.tbBaseStr.Name = "tbBaseStr"
        Me.tbBaseStr.Size = New System.Drawing.Size(221, 19)
        Me.tbBaseStr.TabIndex = 1
        Me.tbBaseStr.Text = "sagae_201711"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 12)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "変換用Key"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 107)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "SHA256ハッシュ値"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 12)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "SessionKey"
        '
        'tbSessionKey
        '
        Me.tbSessionKey.Location = New System.Drawing.Point(82, 67)
        Me.tbSessionKey.Name = "tbSessionKey"
        Me.tbSessionKey.ReadOnly = True
        Me.tbSessionKey.Size = New System.Drawing.Size(313, 19)
        Me.tbSessionKey.TabIndex = 5
        '
        'tbSHA256
        '
        Me.tbSHA256.Location = New System.Drawing.Point(82, 122)
        Me.tbSHA256.Multiline = True
        Me.tbSHA256.Name = "tbSHA256"
        Me.tbSHA256.ReadOnly = True
        Me.tbSHA256.Size = New System.Drawing.Size(313, 109)
        Me.tbSHA256.TabIndex = 6
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(416, 254)
        Me.Controls.Add(Me.tbSHA256)
        Me.Controls.Add(Me.tbSessionKey)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbBaseStr)
        Me.Controls.Add(Me.btnConvert)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnConvert As Button
    Friend WithEvents tbBaseStr As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents tbSessionKey As TextBox
    Friend WithEvents tbSHA256 As TextBox
End Class
