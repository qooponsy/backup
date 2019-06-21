Public Class MatchResultInputForm

    Private Const INPUT_TOOL_POSITION As Integer = 50

    Private Sub MatchResultInput_Load(sender As Object, e As EventArgs) Handles Me.Load
        FormInit()
    End Sub

    Private Sub FormInit()

        ' 選択されたセクションを取得

        ' セクションの試合数を取得
        Dim MatchNum As Integer = 5


        ' Formの大きさを調整
        Me.Size = New System.Drawing.Size(330, 70 * MatchNum)

        ' テキストボックスを試合分配置
        For i As Integer = 1 To MatchNum

            ' ホームクラブ名のラベル配置
            Dim lblHome As New Label
            lblHome.Name = "Home" & i
            lblHome.Location = New Point(10, INPUT_TOOL_POSITION + i * 40)
            Me.Controls.Add(lblHome)

            ' ホームクラブの得点数のテキスト配置
            Dim tbHomeScore As New TextBox
            tbHomeScore.Name = "HomeScore" & i
            tbHomeScore.Location = New Point(150, INPUT_TOOL_POSITION + i * 40)
            Me.Controls.Add(tbHomeScore)

            ' vsラベル
            Dim lblVS As New Label
            lblVS.Name = "VS" & i
            lblVS.Text = "vs"
            lblVS.AutoSize = True
            lblVS.Location = New Point(180, INPUT_TOOL_POSITION + 5 + i * 40)
            Me.Controls.Add(lblVS)

            ' アウェイクラブの得点数のテキスト配置
            Dim tbAway As New TextBox
            tbAway.Name = "AwayScore" & i
            tbAway.Location = New Point(185, INPUT_TOOL_POSITION + i * 40)
            Me.Controls.Add(tbAway)

            ' アウェイクラブ名のラベル配置
            Dim lblAway As New Label
            lblAway.Name = "Away" & i
            lblAway.Location = New Point(200, INPUT_TOOL_POSITION + i * 40)
            Me.Controls.Add(lblAway)

        Next

    End Sub

End Class