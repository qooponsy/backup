Public Class TotoForecastSettingForm

    Public SelectFormMode As FormMode
    Public SettingCode As String

    Private Table As DataTable
    Private View As DataView

    Public SuccessFlg As Boolean = False

    Public Enum FormMode
        INPUT = 1
        UPDATE = 2
    End Enum

    ' 初期処理
    Private Sub TotoForecastSettingForm_Load(sender As Object, e As EventArgs) Handles Me.Load

        Init()

        Select Case SelectFormMode
            Case FormMode.INPUT
                Me.Text = "採点予想作成"
                btnInput.Visible = True
                SetInitGrid()
            Case FormMode.UPDATE
                Me.Text = "採点予想更新"
                btnUpdate.Visible = True

                SetFormData(SettingCode)
        End Select

    End Sub

    Private Sub SetFormData(ByVal code As String)
        Dim headerItem As GradingSettingData = GradingSettingService.GetHeaderData(SettingCode)
        Dim detailList As List(Of GradingSettingDetailData) = GradingSettingService.GetDetailDataList(SettingCode)

        SetUpdGrid(headerItem, detailList)

    End Sub

    Private Sub TotoForecastSettingForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

    End Sub

    Private Sub btnInput_Click(sender As Object, e As EventArgs) Handles btnInput.Click

        Dim headerItem As New GradingSettingData
        Dim detailItemList As New List(Of GradingSettingDetailData)
        Dim success As Boolean = GetFormData(headerItem, detailItemList)

        If success Then
            success = GradingSettingService.Regist(headerItem, detailItemList)

            If success Then
                SuccessFlg = True
                Me.Close()
            Else
                MessageBox.Show("登録に失敗しました。",
                "エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
            End If

        End If

    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        Dim headerItem As New GradingSettingData
        Dim detailItemList As New List(Of GradingSettingDetailData)
        Dim success As Boolean = GetFormData(headerItem, detailItemList)

        If success Then
            success = GradingSettingService.Update(SettingCode, headerItem, detailItemList)

            If success Then
                SuccessFlg = True
                Me.Close()
            Else
                MessageBox.Show("更新に失敗しました。",
                "エラー",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error)
            End If
        End If

    End Sub

    Private Sub Init()

        grid.AutoGenerateColumns = False

        Table = New DataTable
        Table.Columns.Add("GradingSettingDetailCode", GetType(String))
        Table.Columns.Add("GradingSettingCode", GetType(String))
        Table.Columns.Add("CategoryCode", GetType(String))
        Table.Columns.Add("CategoryName", GetType(String))
        Table.Columns.Add("Magnification", GetType(String))

        grid.DataSource = Table

    End Sub

    Private Sub SetInitGrid()

        Dim list As List(Of CategoryData) = CategoryService.GetList()

        For Each item In list
            Dim row As DataRow = Table.NewRow

            row("CategoryCode") = item.CategoryCode
            row("CategoryName") = CategoryService.GetData(item.CategoryCode).CategoryName
            row("Magnification") = 0

            Table.Rows.Add(row)
        Next

    End Sub

    Private Sub SetUpdGrid(ByVal headerItem As GradingSettingData, ByVal detailList As List(Of GradingSettingDetailData))

        tbGradingSetting.Text = headerItem.GradingSetting
        chkBuy.Checked = headerItem.buy
        tbMemo.Text = headerItem.Memo
        tbDrawValue.Text = headerItem.DrawValue
        tbEqualValue.Text = headerItem.EqualValue

        For Each item In detailList
            Dim row As DataRow = Table.NewRow

            row("CategoryCode") = item.CategoryCode
            row("CategoryName") = CategoryService.GetData(item.CategoryCode).CategoryName
            row("Magnification") = item.Magnification

            Table.Rows.Add(row)
        Next

    End Sub

    Private Function GetFormData(ByRef headerItem As GradingSettingData, ByRef detailItemList As List(Of GradingSettingDetailData)) As Boolean
        Dim success As Boolean = True

        Try
            ' ヘッダー項目取得
            headerItem.GradingSetting = tbGradingSetting.Text
            If chkBuy.Checked Then
                headerItem.buy = 1
            Else
                headerItem.buy = 0
            End If

            headerItem.Memo = tbMemo.Text
            headerItem.DrawValue = tbDrawValue.Text
            headerItem.EqualValue = tbEqualValue.Text

            ' 詳細項目取得
            detailItemList = GetGridList(grid)

        Catch ex As Exception
            success = False
        End Try

        Return success
    End Function

    Private Function GetGridList(ByVal baseGrid As DataGridView) As List(Of GradingSettingDetailData)
        Dim ret As New List(Of GradingSettingDetailData)

        For i As Integer = 0 To baseGrid.Rows.Count - 1
            Dim item As New GradingSettingDetailData

            Dim GradingSettingDetailCode As String = baseGrid.Rows(i).Cells("GradingSettingDetailCode").Value.ToString()
            If GradingSettingDetailCode <> "" Then
                item.GradingSettingDetailCode = Long.Parse(GradingSettingDetailCode)
            End If

            item.GradingSettingCode = baseGrid.Rows(i).Cells("GradingSettingCode").Value.ToString()
            item.CategoryCode = baseGrid.Rows(i).Cells("CategoryCode").Value.ToString()
            item.Magnification = baseGrid.Rows(i).Cells("Magnification").Value.ToString()

            ret.Add(item)
        Next

        Return ret
    End Function

End Class