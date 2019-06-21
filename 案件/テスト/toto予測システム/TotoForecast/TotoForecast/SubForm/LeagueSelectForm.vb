Public Class LeagueSelectForm

    Public LeagueCode As String
    Public LeagueDetailCode As String
    Public Year As String

    Public success As Boolean = False
    Public err As Boolean

    Private Sub LeagueSelectForm_Load(sender As Object, e As EventArgs) Handles Me.Load

        cbLeagueDetail.DisplayMember = "LeagueDetailName"
        cbLeagueDetail.ValueMember = "LeagueDetailCode"
        cbLeagueDetail.DataSource = LeagueDetailService.GetViewList(LeagueCode)

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        If GetSelectData() Then
            success = True
            Me.Close()
        Else
            MessageBox.Show("情報を正しく入力してください。",
                "エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
        End If

    End Sub

    Public Function GetSelectData() As Boolean
        Dim ret As Boolean = True

        Try
            LeagueDetailCode = cbLeagueDetail.SelectedValue.ToString
            Year = cbSeason.Text

            If LeagueDetailCode = "" Or Year = "" Then
                ret = False
            End If

        Catch ex As Exception
            SystemLog.ExceptionError(ex)
            ret = False
        End Try

        Return ret
    End Function

    Public Function IsSelectData() As Boolean
        Return success
    End Function

    Public Function IsError() As Boolean
        Return err = True
    End Function

    Private Sub cbLeagueDetail_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbLeagueDetail.SelectedIndexChanged
        Dim list As New List(Of SeasonData)
        Dim LeagueDetailCode As String = cbLeagueDetail.SelectedValue
        Dim success As Boolean = SeasonService.GetYearList(LeagueCode, LeagueDetailCode, list)

        If success Then
            cbSeason.Enabled = True

            cbSeason.DisplayMember = "SeasonName"
            cbSeason.ValueMember = "RegSeason"
            cbSeason.DataSource = list

        Else
            MessageBox.Show("情報の取得に失敗しました。",
                "エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
            err = True

            'btnOK.Enabled = False
        End If
    End Sub

End Class