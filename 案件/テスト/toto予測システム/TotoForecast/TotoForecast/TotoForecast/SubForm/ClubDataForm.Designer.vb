<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ClubDataForm
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
        Me.cbLeague = New System.Windows.Forms.ComboBox()
        Me.cbLeagueDetail = New System.Windows.Forms.ComboBox()
        Me.tbClubName = New System.Windows.Forms.TextBox()
        Me.tbShortName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnReg = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbCLubKanaName = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'cbLeague
        '
        Me.cbLeague.FormattingEnabled = True
        Me.cbLeague.Location = New System.Drawing.Point(119, 33)
        Me.cbLeague.Name = "cbLeague"
        Me.cbLeague.Size = New System.Drawing.Size(140, 20)
        Me.cbLeague.TabIndex = 0
        '
        'cbLeagueDetail
        '
        Me.cbLeagueDetail.FormattingEnabled = True
        Me.cbLeagueDetail.Location = New System.Drawing.Point(119, 64)
        Me.cbLeagueDetail.Name = "cbLeagueDetail"
        Me.cbLeagueDetail.Size = New System.Drawing.Size(140, 20)
        Me.cbLeagueDetail.TabIndex = 1
        '
        'tbClubName
        '
        Me.tbClubName.Location = New System.Drawing.Point(119, 96)
        Me.tbClubName.Name = "tbClubName"
        Me.tbClubName.Size = New System.Drawing.Size(192, 19)
        Me.tbClubName.TabIndex = 2
        '
        'tbShortName
        '
        Me.tbShortName.Location = New System.Drawing.Point(119, 160)
        Me.tbShortName.Name = "tbShortName"
        Me.tbShortName.Size = New System.Drawing.Size(140, 19)
        Me.tbShortName.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 12)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "リーグ"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 12)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "リーグ区分"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 12)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "クラブ名"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(24, 163)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 12)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "クラブ短縮名"
        '
        'btnReg
        '
        Me.btnReg.Location = New System.Drawing.Point(119, 193)
        Me.btnReg.Name = "btnReg"
        Me.btnReg.Size = New System.Drawing.Size(75, 23)
        Me.btnReg.TabIndex = 8
        Me.btnReg.Text = "登録"
        Me.btnReg.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(24, 130)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 12)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "クラブ名(カナ)"
        '
        'tbCLubKanaName
        '
        Me.tbCLubKanaName.Location = New System.Drawing.Point(119, 127)
        Me.tbCLubKanaName.Name = "tbCLubKanaName"
        Me.tbCLubKanaName.Size = New System.Drawing.Size(192, 19)
        Me.tbCLubKanaName.TabIndex = 3
        '
        'ClubDataForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(334, 228)
        Me.Controls.Add(Me.tbCLubKanaName)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnReg)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tbShortName)
        Me.Controls.Add(Me.tbClubName)
        Me.Controls.Add(Me.cbLeagueDetail)
        Me.Controls.Add(Me.cbLeague)
        Me.Name = "ClubDataForm"
        Me.Text = "クラブデータ"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cbLeague As ComboBox
    Friend WithEvents cbLeagueDetail As ComboBox
    Friend WithEvents tbClubName As TextBox
    Friend WithEvents tbShortName As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btnReg As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents tbCLubKanaName As TextBox
End Class
