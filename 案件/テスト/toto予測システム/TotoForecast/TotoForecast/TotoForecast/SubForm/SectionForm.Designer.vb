<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SectionForm
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
        Me.cbMatchClass = New System.Windows.Forms.ComboBox()
        Me.cbLeagueDetail = New System.Windows.Forms.ComboBox()
        Me.cbLeague = New System.Windows.Forms.ComboBox()
        Me.cbSeason = New System.Windows.Forms.ComboBox()
        Me.btnInput = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnResult = New System.Windows.Forms.Button()
        Me.btnResultInput = New System.Windows.Forms.Button()
        Me.btnTotoInput = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cbMatchClass
        '
        Me.cbMatchClass.FormattingEnabled = True
        Me.cbMatchClass.Location = New System.Drawing.Point(96, 121)
        Me.cbMatchClass.Name = "cbMatchClass"
        Me.cbMatchClass.Size = New System.Drawing.Size(138, 20)
        Me.cbMatchClass.TabIndex = 17
        '
        'cbLeagueDetail
        '
        Me.cbLeagueDetail.FormattingEnabled = True
        Me.cbLeagueDetail.Location = New System.Drawing.Point(96, 88)
        Me.cbLeagueDetail.Name = "cbLeagueDetail"
        Me.cbLeagueDetail.Size = New System.Drawing.Size(138, 20)
        Me.cbLeagueDetail.TabIndex = 16
        '
        'cbLeague
        '
        Me.cbLeague.FormattingEnabled = True
        Me.cbLeague.Location = New System.Drawing.Point(96, 58)
        Me.cbLeague.Name = "cbLeague"
        Me.cbLeague.Size = New System.Drawing.Size(138, 20)
        Me.cbLeague.TabIndex = 15
        '
        'cbSeason
        '
        Me.cbSeason.FormattingEnabled = True
        Me.cbSeason.Location = New System.Drawing.Point(96, 24)
        Me.cbSeason.Name = "cbSeason"
        Me.cbSeason.Size = New System.Drawing.Size(138, 20)
        Me.cbSeason.TabIndex = 14
        '
        'btnInput
        '
        Me.btnInput.Location = New System.Drawing.Point(76, 169)
        Me.btnInput.Name = "btnInput"
        Me.btnInput.Size = New System.Drawing.Size(75, 23)
        Me.btnInput.TabIndex = 13
        Me.btnInput.Text = "試合入力"
        Me.btnInput.UseVisualStyleBackColor = True
        Me.btnInput.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 124)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 12)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "試合区分"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 27)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 12)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "シーズン"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 91)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 12)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "リーグ詳細"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 12)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "リーグ"
        '
        'btnResult
        '
        Me.btnResult.Location = New System.Drawing.Point(76, 169)
        Me.btnResult.Name = "btnResult"
        Me.btnResult.Size = New System.Drawing.Size(75, 23)
        Me.btnResult.TabIndex = 18
        Me.btnResult.Text = "結果確認"
        Me.btnResult.UseVisualStyleBackColor = True
        Me.btnResult.Visible = False
        '
        'btnResultInput
        '
        Me.btnResultInput.Location = New System.Drawing.Point(76, 169)
        Me.btnResultInput.Name = "btnResultInput"
        Me.btnResultInput.Size = New System.Drawing.Size(90, 23)
        Me.btnResultInput.TabIndex = 19
        Me.btnResultInput.Text = "試合結果入力"
        Me.btnResultInput.UseVisualStyleBackColor = True
        Me.btnResultInput.Visible = False
        '
        'btnTotoInput
        '
        Me.btnTotoInput.Location = New System.Drawing.Point(76, 170)
        Me.btnTotoInput.Name = "btnTotoInput"
        Me.btnTotoInput.Size = New System.Drawing.Size(90, 23)
        Me.btnTotoInput.TabIndex = 20
        Me.btnTotoInput.Text = "予想試合入力"
        Me.btnTotoInput.UseVisualStyleBackColor = True
        Me.btnTotoInput.Visible = False
        '
        'SectionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(248, 205)
        Me.Controls.Add(Me.btnTotoInput)
        Me.Controls.Add(Me.btnResultInput)
        Me.Controls.Add(Me.cbMatchClass)
        Me.Controls.Add(Me.cbLeagueDetail)
        Me.Controls.Add(Me.cbLeague)
        Me.Controls.Add(Me.cbSeason)
        Me.Controls.Add(Me.btnInput)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnResult)
        Me.Name = "SectionForm"
        Me.Text = "試合入力"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cbMatchClass As ComboBox
    Friend WithEvents cbLeagueDetail As ComboBox
    Friend WithEvents cbLeague As ComboBox
    Friend WithEvents cbSeason As ComboBox
    Friend WithEvents btnInput As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnResult As Button
    Friend WithEvents btnResultInput As Button
    Friend WithEvents btnTotoInput As Button
End Class
