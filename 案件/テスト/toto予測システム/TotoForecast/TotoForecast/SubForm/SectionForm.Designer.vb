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
        Me.btnMatchInput = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnResult = New System.Windows.Forms.Button()
        Me.btnResultInput = New System.Windows.Forms.Button()
        Me.btnTotoInput = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbSection = New System.Windows.Forms.ComboBox()
        Me.tbSection = New System.Windows.Forms.TextBox()
        Me.btnMatchUpdate = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cbMatchClass
        '
        Me.cbMatchClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbMatchClass.Enabled = False
        Me.cbMatchClass.FormattingEnabled = True
        Me.cbMatchClass.Location = New System.Drawing.Point(96, 121)
        Me.cbMatchClass.Name = "cbMatchClass"
        Me.cbMatchClass.Size = New System.Drawing.Size(138, 20)
        Me.cbMatchClass.TabIndex = 17
        '
        'cbLeagueDetail
        '
        Me.cbLeagueDetail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbLeagueDetail.Enabled = False
        Me.cbLeagueDetail.FormattingEnabled = True
        Me.cbLeagueDetail.Location = New System.Drawing.Point(96, 57)
        Me.cbLeagueDetail.Name = "cbLeagueDetail"
        Me.cbLeagueDetail.Size = New System.Drawing.Size(138, 20)
        Me.cbLeagueDetail.TabIndex = 16
        '
        'cbLeague
        '
        Me.cbLeague.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbLeague.FormattingEnabled = True
        Me.cbLeague.Location = New System.Drawing.Point(96, 27)
        Me.cbLeague.Name = "cbLeague"
        Me.cbLeague.Size = New System.Drawing.Size(138, 20)
        Me.cbLeague.TabIndex = 15
        '
        'cbSeason
        '
        Me.cbSeason.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSeason.Enabled = False
        Me.cbSeason.FormattingEnabled = True
        Me.cbSeason.Location = New System.Drawing.Point(96, 89)
        Me.cbSeason.Name = "cbSeason"
        Me.cbSeason.Size = New System.Drawing.Size(138, 20)
        Me.cbSeason.TabIndex = 14
        '
        'btnMatchInput
        '
        Me.btnMatchInput.Location = New System.Drawing.Point(76, 198)
        Me.btnMatchInput.Name = "btnMatchInput"
        Me.btnMatchInput.Size = New System.Drawing.Size(75, 23)
        Me.btnMatchInput.TabIndex = 13
        Me.btnMatchInput.Text = "試合入力"
        Me.btnMatchInput.UseVisualStyleBackColor = True
        Me.btnMatchInput.Visible = False
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
        Me.Label3.Location = New System.Drawing.Point(23, 93)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 12)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "シーズン"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 60)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 12)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "リーグ詳細"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 12)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "リーグ"
        '
        'btnResult
        '
        Me.btnResult.Location = New System.Drawing.Point(76, 198)
        Me.btnResult.Name = "btnResult"
        Me.btnResult.Size = New System.Drawing.Size(75, 23)
        Me.btnResult.TabIndex = 18
        Me.btnResult.Text = "結果確認"
        Me.btnResult.UseVisualStyleBackColor = True
        Me.btnResult.Visible = False
        '
        'btnResultInput
        '
        Me.btnResultInput.Location = New System.Drawing.Point(76, 198)
        Me.btnResultInput.Name = "btnResultInput"
        Me.btnResultInput.Size = New System.Drawing.Size(90, 23)
        Me.btnResultInput.TabIndex = 19
        Me.btnResultInput.Text = "試合結果入力"
        Me.btnResultInput.UseVisualStyleBackColor = True
        Me.btnResultInput.Visible = False
        '
        'btnTotoInput
        '
        Me.btnTotoInput.Location = New System.Drawing.Point(76, 198)
        Me.btnTotoInput.Name = "btnTotoInput"
        Me.btnTotoInput.Size = New System.Drawing.Size(90, 23)
        Me.btnTotoInput.TabIndex = 20
        Me.btnTotoInput.Text = "予想試合入力"
        Me.btnTotoInput.UseVisualStyleBackColor = True
        Me.btnTotoInput.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 157)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 12)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "セクション"
        '
        'cbSection
        '
        Me.cbSection.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbSection.Enabled = False
        Me.cbSection.FormattingEnabled = True
        Me.cbSection.Location = New System.Drawing.Point(96, 154)
        Me.cbSection.Name = "cbSection"
        Me.cbSection.Size = New System.Drawing.Size(138, 20)
        Me.cbSection.TabIndex = 17
        Me.cbSection.Visible = False
        '
        'tbSection
        '
        Me.tbSection.Enabled = False
        Me.tbSection.Location = New System.Drawing.Point(96, 153)
        Me.tbSection.Name = "tbSection"
        Me.tbSection.Size = New System.Drawing.Size(138, 19)
        Me.tbSection.TabIndex = 21
        Me.tbSection.Visible = False
        '
        'btnMatchUpdate
        '
        Me.btnMatchUpdate.Location = New System.Drawing.Point(76, 198)
        Me.btnMatchUpdate.Name = "btnMatchUpdate"
        Me.btnMatchUpdate.Size = New System.Drawing.Size(90, 23)
        Me.btnMatchUpdate.TabIndex = 22
        Me.btnMatchUpdate.Text = "試合修正"
        Me.btnMatchUpdate.UseVisualStyleBackColor = True
        Me.btnMatchUpdate.Visible = False
        '
        'SectionForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(248, 235)
        Me.Controls.Add(Me.btnMatchUpdate)
        Me.Controls.Add(Me.tbSection)
        Me.Controls.Add(Me.btnTotoInput)
        Me.Controls.Add(Me.btnResultInput)
        Me.Controls.Add(Me.cbSection)
        Me.Controls.Add(Me.cbMatchClass)
        Me.Controls.Add(Me.cbLeagueDetail)
        Me.Controls.Add(Me.cbLeague)
        Me.Controls.Add(Me.cbSeason)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnMatchInput)
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
    Friend WithEvents btnMatchInput As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnResult As Button
    Friend WithEvents btnResultInput As Button
    Friend WithEvents btnTotoInput As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents cbSection As ComboBox
    Friend WithEvents tbSection As TextBox
    Friend WithEvents btnMatchUpdate As Button
End Class
