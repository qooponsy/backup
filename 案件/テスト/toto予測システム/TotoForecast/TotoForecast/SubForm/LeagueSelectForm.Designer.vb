<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LeagueSelectForm
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
        Me.cbLeagueDetail = New System.Windows.Forms.ComboBox()
        Me.cbSeason = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnOK = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cbLeagueDetail
        '
        Me.cbLeagueDetail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbLeagueDetail.FormattingEnabled = True
        Me.cbLeagueDetail.Location = New System.Drawing.Point(101, 30)
        Me.cbLeagueDetail.Name = "cbLeagueDetail"
        Me.cbLeagueDetail.Size = New System.Drawing.Size(138, 20)
        Me.cbLeagueDetail.TabIndex = 20
        '
        'cbSeason
        '
        Me.cbSeason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSeason.Enabled = False
        Me.cbSeason.FormattingEnabled = True
        Me.cbSeason.Location = New System.Drawing.Point(101, 67)
        Me.cbSeason.Name = "cbSeason"
        Me.cbSeason.Size = New System.Drawing.Size(138, 20)
        Me.cbSeason.TabIndex = 19
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 12)
        Me.Label3.TabIndex = 18
        Me.Label3.Text = "シーズン"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 12)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "リーグ詳細"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(101, 109)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(75, 23)
        Me.btnOK.TabIndex = 21
        Me.btnOK.Text = "OK"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'LeagueSelectForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 151)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.cbLeagueDetail)
        Me.Controls.Add(Me.cbSeason)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Name = "LeagueSelectForm"
        Me.Text = "LeagueForm"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cbLeagueDetail As ComboBox
    Friend WithEvents cbSeason As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnOK As Button
End Class
