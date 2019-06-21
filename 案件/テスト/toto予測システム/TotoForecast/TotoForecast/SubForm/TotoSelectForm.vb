Public Class TotoSelectForm

    Private Const INPUT_TOOL_POSITION As Integer = 50 ' 高さ初期値

    Public SelectSection As SectionData
    Private MatchNum As Integer

    Private Sub TotoSelectForm_Load(sender As Object, e As EventArgs) Handles Me.Load

        FormInit()

    End Sub

    Private Sub FormInit()

        ' 試合数を計算
        Dim clubNum As Integer = SeasonService.GetClubNum(SelectSection)
        MatchNum = clubNum / 2

        ' 試合一覧
        Dim MatchList As List(Of MatchData) = MatchService.GetMatchList(SelectSection)

        ' Formの大きさを調整
        Me.Size = New System.Drawing.Size(330, INPUT_TOOL_POSITION + 46 * MatchNum)

        ' テキストボックスを試合分配置
        For i As Integer = 1 To MatchNum

            ' コンボボックス設定用試合一覧
            Dim ViewList As List(Of ClubData) = New List(Of ClubData)(MatchList)

            ' セクション番号ラベル配置
            Dim lblNumber As New Label
            lblNumber.Name = "number" & i
            lblNumber.Text = i & "."
            lblNumber.Location = New Point(10, INPUT_TOOL_POSITION + i * 40 + 5)
            lblNumber.Size = New Size(20, 20)
            Me.Controls.Add(lblNumber)

            ' セクションごとにコンボボックスを配置
            Dim cbSection As New ComboBox
            cbSection.Name = "section" & i
            cbSection.Location = New Point(30, INPUT_TOOL_POSITION + i * 40)
            cbSection.Size = New Size(280, 20)
            cbSection.DropDownStyle = ComboBoxStyle.DropDownList

            Me.Controls.Add(cbSection)

        Next

    End Sub

End Class