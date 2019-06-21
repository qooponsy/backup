Public Class Test
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim message As String = ""

        If DBTest.DBConnectionTest() Then
            ' DB接続テスト成功
            message = "正常起動"
        Else
            ' DB接続テスト失敗
            message = "DB接続に失敗しました。"
        End If

        Response.Write(message)

    End Sub

End Class