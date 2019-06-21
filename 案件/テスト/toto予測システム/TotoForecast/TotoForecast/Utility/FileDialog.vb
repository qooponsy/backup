Public Class FileDialog

    Public Shared Function GetFilePath() As String
        Dim retPath As String = ""

        'OpenFileDialogクラスのインスタンスを作成
        Dim ofd As New OpenFileDialog()

        '[ファイルの種類]に表示される選択肢を指定する
        '指定しないとすべてのファイルが表示される
        ofd.Filter = "CSVファイル(*.csv)|*.csv"
        'タイトルを設定する
        ofd.Title = "開くファイルを選択してください"

        'ダイアログを表示する
        If ofd.ShowDialog() = DialogResult.OK Then
            'OKボタンがクリックされたとき、選択されたファイル名を表示する
            retPath = ofd.FileName
        End If

        Return retPath
    End Function

End Class
