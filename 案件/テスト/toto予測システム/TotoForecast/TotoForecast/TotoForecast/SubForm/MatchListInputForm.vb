Public Class MatchListInputForm

    Private tbList As List(Of Button)
    Private Const INPUT_TOOL_POSITION As Integer = 50

    Public FormMode As Integer

    Public Shared Sub SetSection()

    End Sub

    Private Sub MatchListInput_Load(sender As Object, e As EventArgs) Handles Me.Load

        FormInit()

    End Sub

    Private Sub FormInit()

        ' 試合数を計算
        ' Dim MatchNum As Integer = SeasonService.getClubNum()
        Dim clubNum As Integer = 10
        Dim MatchNum As Integer = clubNum / 2

        ' Formの大きさを調整
        Me.Size = New System.Drawing.Size(330, 70 * MatchNum)

        ' テキストボックスを試合分配置
        For i As Integer = 1 To MatchNum

            ' ホームクラブのテキスト配置
            Dim cbHome As New ComboBox
            cbHome.Name = "Home" & i
            cbHome.Location = New Point(10, INPUT_TOOL_POSITION + i * 40)
            Me.Controls.Add(cbHome)

            ' vsラベル
            Dim lblVS As New Label
            lblVS.Name = "VS" & i
            lblVS.Text = "vs"
            lblVS.AutoSize = True
            lblVS.Location = New Point(150, INPUT_TOOL_POSITION + 5 + i * 40)
            Me.Controls.Add(lblVS)

            ' アウェイクラブのテキスト配置
            Dim cbAway As New ComboBox
            cbAway.Name = "Away" & i
            cbAway.Location = New Point(185, INPUT_TOOL_POSITION + i * 40)
            Me.Controls.Add(cbAway)

        Next

    End Sub

End Class