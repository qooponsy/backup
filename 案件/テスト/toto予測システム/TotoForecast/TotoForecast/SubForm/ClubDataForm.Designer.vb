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
        Me.components = New System.ComponentModel.Container()
        Me.cbLeague = New System.Windows.Forms.ComboBox()
        Me.cbLeagueDetail = New System.Windows.Forms.ComboBox()
        Me.tbClubName = New System.Windows.Forms.TextBox()
        Me.tbShortName = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnInput = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbCLubNameKana = New System.Windows.Forms.TextBox()
        Me.btnCsvRead = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.tbShortNameKana = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.tbClubCode = New System.Windows.Forms.TextBox()
        Me.btnUpdate = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cbLeague
        '
        Me.cbLeague.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbLeague.FormattingEnabled = True
        Me.cbLeague.Location = New System.Drawing.Point(120, 79)
        Me.cbLeague.Name = "cbLeague"
        Me.cbLeague.Size = New System.Drawing.Size(140, 20)
        Me.cbLeague.TabIndex = 0
        '
        'cbLeagueDetail
        '
        Me.cbLeagueDetail.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbLeagueDetail.FormattingEnabled = True
        Me.cbLeagueDetail.Location = New System.Drawing.Point(120, 110)
        Me.cbLeagueDetail.Name = "cbLeagueDetail"
        Me.cbLeagueDetail.Size = New System.Drawing.Size(140, 20)
        Me.cbLeagueDetail.TabIndex = 1
        '
        'tbClubName
        '
        Me.tbClubName.Location = New System.Drawing.Point(120, 142)
        Me.tbClubName.Name = "tbClubName"
        Me.tbClubName.Size = New System.Drawing.Size(192, 19)
        Me.tbClubName.TabIndex = 2
        '
        'tbShortName
        '
        Me.tbShortName.Location = New System.Drawing.Point(120, 206)
        Me.tbShortName.Name = "tbShortName"
        Me.tbShortName.Size = New System.Drawing.Size(140, 19)
        Me.tbShortName.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(25, 79)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 12)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "リーグ"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 113)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 12)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "リーグ区分"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(25, 145)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 12)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "クラブ名"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(25, 209)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 12)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "クラブ短縮名"
        '
        'btnInput
        '
        Me.btnInput.Location = New System.Drawing.Point(120, 275)
        Me.btnInput.Name = "btnInput"
        Me.btnInput.Size = New System.Drawing.Size(75, 23)
        Me.btnInput.TabIndex = 8
        Me.btnInput.Text = "登録"
        Me.btnInput.UseVisualStyleBackColor = True
        Me.btnInput.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(25, 176)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(69, 12)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "クラブ名(カナ)"
        '
        'tbCLubNameKana
        '
        Me.tbCLubNameKana.Location = New System.Drawing.Point(120, 173)
        Me.tbCLubNameKana.Name = "tbCLubNameKana"
        Me.tbCLubNameKana.Size = New System.Drawing.Size(192, 19)
        Me.tbCLubNameKana.TabIndex = 3
        '
        'btnCsvRead
        '
        Me.btnCsvRead.Location = New System.Drawing.Point(228, 14)
        Me.btnCsvRead.Name = "btnCsvRead"
        Me.btnCsvRead.Size = New System.Drawing.Size(94, 23)
        Me.btnCsvRead.TabIndex = 16
        Me.btnCsvRead.Text = "csv読み込み"
        Me.ToolTip1.SetToolTip(Me.btnCsvRead, "リーグコード,リーグ区分コード,クラブ名,クラブ名(カナ),短縮名")
        Me.btnCsvRead.UseVisualStyleBackColor = True
        Me.btnCsvRead.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(25, 239)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 12)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "クラブ短縮名(カナ)"
        '
        'tbShortNameKana
        '
        Me.tbShortNameKana.Location = New System.Drawing.Point(120, 236)
        Me.tbShortNameKana.Name = "tbShortNameKana"
        Me.tbShortNameKana.Size = New System.Drawing.Size(140, 19)
        Me.tbShortNameKana.TabIndex = 10
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(25, 50)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 12)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "クラブコード"
        '
        'tbClubCode
        '
        Me.tbClubCode.Enabled = False
        Me.tbClubCode.Location = New System.Drawing.Point(120, 47)
        Me.tbClubCode.Name = "tbClubCode"
        Me.tbClubCode.Size = New System.Drawing.Size(140, 19)
        Me.tbClubCode.TabIndex = 14
        '
        'btnUpdate
        '
        Me.btnUpdate.Location = New System.Drawing.Point(120, 275)
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(75, 23)
        Me.btnUpdate.TabIndex = 17
        Me.btnUpdate.Text = "更新"
        Me.btnUpdate.UseVisualStyleBackColor = True
        Me.btnUpdate.Visible = False
        '
        'ClubDataForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(334, 318)
        Me.Controls.Add(Me.btnUpdate)
        Me.Controls.Add(Me.tbClubCode)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.tbShortNameKana)
        Me.Controls.Add(Me.btnCsvRead)
        Me.Controls.Add(Me.tbCLubNameKana)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btnInput)
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
    Friend WithEvents btnInput As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents tbCLubNameKana As TextBox
    Friend WithEvents btnCsvRead As Button
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents Label6 As Label
    Friend WithEvents tbShortNameKana As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents tbClubCode As TextBox
    Friend WithEvents btnUpdate As Button
End Class
