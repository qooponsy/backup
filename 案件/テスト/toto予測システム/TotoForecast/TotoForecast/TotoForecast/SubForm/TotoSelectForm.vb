Public Class TotoSelectForm

    Private Const INPUT_TOOL_POSITION As Integer = 50 ' 高さ初期値

    Private Sub TotoSelectForm_Load(sender As Object, e As EventArgs) Handles Me.Load

        FormInit()

    End Sub

    Private Sub FormInit()

        ' セクション数を取得
        Dim SectionCnt As Integer = 13

        ' Formの大きさを調整
        Me.Size = New System.Drawing.Size(330, INPUT_TOOL_POSITION + 46 * SectionCnt)

        ' テキストボックスを試合分配置
        For i As Integer = 1 To SectionCnt

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
            Me.Controls.Add(cbSection)

        Next

    End Sub

End Class