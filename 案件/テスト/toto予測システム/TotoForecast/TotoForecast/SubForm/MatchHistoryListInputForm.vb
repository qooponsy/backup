﻿Public Class MatchHistoryListInputForm


    Private HomeList As New List(Of ComboBox)
    Private AwayList As New List(Of ComboBox)
    Private Const INPUT_TOOL_POSITION As Integer = 50

    Private MatchNum As Integer

    Public SelectFormMode As FormMode
    Public SelectSection As SectionData

    Public Enum FormMode
        INPUT = 1
        UPD = 2
    End Enum

    Private Sub MatchHistoryListInputForm_Load(sender As Object, e As EventArgs) Handles Me.Load

        Select Case SelectFormMode
            Case FormMode.INPUT
                Me.Text = "試合入力画面"
                Dim LeagueName As String = LeagueDetailService.GetData(SelectSection.LeagueDetailCode).LeagueDetailName
                lblSection.Text = LeagueName & " 第" & SelectSection.Section & "節　試合入力"
                btnInput.Visible = True

                FormInit()
            Case FormMode.UPD
                Me.Text = "入力試合修正"
                Dim LeagueName As String = LeagueDetailService.GetData(SelectSection.LeagueDetailCode).LeagueDetailName
                lblSection.Text = LeagueName & " 第" & SelectSection.Section & "節　試合修正"
                btnUpdate.Visible = True

                'FormSetMatch()
        End Select

    End Sub

    Private Sub FormInit()

        ' 試合数を計算
        Dim clubNum As Integer = SeasonService.GetClubNum(SelectSection)
        MatchNum = clubNum / 2

        ' リーグ所属クラブの一覧
        Dim clubList As List(Of ClubData) = ClubService.GetLeagueList(SelectSection.LeagueCode, SelectSection.LeagueDetailCode)

        ' Formの大きさを調整
        Me.Size = New System.Drawing.Size(330, 50 * MatchNum + INPUT_TOOL_POSITION)

        ' テキストボックスを試合分配置
        For i As Integer = 0 To MatchNum - 1

            ' ホームクラブのテキスト配置
            Dim homeViewList As List(Of ClubData) = New List(Of ClubData)(clubList)

            Dim cbHome As New ComboBox
            cbHome.Name = "Home" & i
            cbHome.Location = New Point(10, INPUT_TOOL_POSITION + (i + 1) * 40)
            cbHome.DropDownStyle = ComboBoxStyle.DropDownList

            cbHome.DisplayMember = "ViewName"
            cbHome.ValueMember = "ClubCode"
            cbHome.DataSource = homeViewList

            HomeList.Add(cbHome)
            Me.Controls.Add(cbHome)

            ' vsラベル
            Dim lblVS As New Label
            lblVS.Name = "VS" & i
            lblVS.Text = "vs"
            lblVS.AutoSize = True
            lblVS.Location = New Point(150, INPUT_TOOL_POSITION + 5 + (i + 1) * 40)
            Me.Controls.Add(lblVS)

            ' アウェークラブのテキスト配置
            Dim awayViewList As List(Of ClubData) = New List(Of ClubData)(clubList)

            Dim cbAway As New ComboBox
            cbAway.Name = "Away" & i
            cbAway.Location = New Point(185, INPUT_TOOL_POSITION + (i + 1) * 40)
            cbAway.DropDownStyle = ComboBoxStyle.DropDownList

            cbAway.DisplayMember = "ViewName"
            cbAway.ValueMember = "ClubCode"
            cbAway.DataSource = awayViewList

            AwayList.Add(cbAway)
            Me.Controls.Add(cbAway)

        Next

    End Sub

End Class