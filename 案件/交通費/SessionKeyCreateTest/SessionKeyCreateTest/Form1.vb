Imports System.Data.SqlClient

Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnConvert.Click

        Dim baseStr As String = tbBaseStr.Text

        tbSessionKey.Text = clsSessionKey.CreateSession(baseStr)
        tbSHA256.Text = clsSessionKey.ConvSHA256(baseStr)


    End Sub

End Class
