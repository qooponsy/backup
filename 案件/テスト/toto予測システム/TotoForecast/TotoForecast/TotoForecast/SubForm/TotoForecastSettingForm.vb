Public Class TotoForecastSettingForm

    Public SelectFormMode As FormMode

    Public Enum FormMode
        INPUT = 1
        UPDATE = 2
    End Enum

    ' 初期処理
    Private Sub TotoForecastSettingForm_Load(sender As Object, e As EventArgs) Handles Me.Load

        Select Case SelectFormMode
            Case FormMode.INPUT
                Me.Text = "採点予想作成"
            Case FormMode.UPDATE
                Me.Text = "採点予想更新"

        End Select

    End Sub


    Private Sub TotoForecastSettingForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        Select Case SelectFormMode
            Case FormMode.INPUT

            Case FormMode.UPDATE

        End Select
    End Sub
End Class