Public Class CarfareWeb
    Inherits System.Web.UI.Page
    Private Const SEARCH_FILE_FORMAT As String = "{0}_{1}_交通費_{2}.xls"

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim message As String = ""
        Dim sessionData As New S_Session
        Dim carfareData As New T_Carfare
        Dim workerData As New M_Worker
        'リクエストの受け取り
        Dim sessionKey As String = Request("key")

        Dim success As Boolean = True
        'セッションキーの有無、文字数のチェック
        If sessionKey Is Nothing OrElse sessionKey.Length <> 32 Then
            success = False
        End If

        If success Then
            'セッションキーの問い合わせ
            Dim checkKey As Boolean = S_Session.GetSession(sessionKey, sessionData)
            If checkKey Then
                'セッションデータからcarfareIDを使って交通費データの問い合わせ
                Dim checkCarfare As Boolean = T_Carfare.GetCarfare(sessionData.carfareID, carfareData)
                If checkCarfare Then
                    '対象のユーザーデータを取得
                    Dim checkGetWorker As Boolean = M_Worker.GetWorker(carfareData.WorkerID, workerData)
                    If checkGetWorker Then
                        '交通費記載完了報告者取得
                        Dim checkSearchWorker As Boolean = T_Carfare.GetSearchWorker(sessionKey, carfareData)
                        If checkSearchWorker Then
                            '▲ファイルサーバーを検索▲
                            Dim writeStatus As String = "0"
                            Dim checkSearchFile As Boolean = SearchFile(sessionKey, carfareData, writeStatus)
                            If checkSearchFile Then
                                '交通費記載ステータスの変更(UPDATE)とセッションデータの削除(DELETE) 新規 トランザクション対応
                                Dim checkUpdDelCarfareSession As Boolean = T_Carfare.UpdDelCarfareSession(sessionData.carfareID, workerData.WorkerID, writeStatus)
                                If checkUpdDelCarfareSession Then
                                    Dim isFileMsg As String
                                    If (writeStatus = T_Carfare.WriteStatusCode.sTrue) Then
                                        isFileMsg = "「今月の交通費清算は<font color=""red"">あり</font>」で報告しました。"
                                    Else
                                        isFileMsg = "「今月の交通費清算は<font color=""red"">なし</font>」で報告しました。"
                                    End If
                                    message = workerData.LastName & " " & workerData.FirstName & "さんの " & carfareData.Year & "年度 " & carfareData.Month & "月 の交通費記載完了報告が完了しました。" & vbCrLf & isFileMsg
                                Else
                                    message = "書き込み処理に失敗しました。" & vbCrLf & "管理者へ連絡をしてください。"
                                End If
                            Else
                                message = "交通費ファイルの検索に失敗しました。" & vbCrLf & "管理者へ連絡をしてください。"
                            End If
                        Else    'ユーザーの情報取得に失敗
                            message = "ユーザーの情報が見つかりませんでした。" & vbCrLf & "管理者へ連絡をしてください。"
                        End If
                    Else 'ユーザーデータが存在しない場合
                        message = "ユーザーが見つかりませんでした。" & vbCrLf & "管理者へ連絡をしてください。"
                    End If
                Else '交通費記載データが存在しない場合
                    message = "交通費データが存在しません。" & vbCrLf & "管理者へ連絡をしてください。"
                End If
            Else 'セッションデータが存在しない場合
                message = "存在しないセッションキーです。" & vbCrLf & "管理者へ連絡をしてください。"
            End If
        Else 'パラメータが存在しない場合
            message = "不正なURLです。" & vbCrLf & "管理者へ連絡をしてください。"
        End If

        Response.Write(message)
    End Sub

    Private Function SearchFile(ByVal sessionKey As String, ByVal carfareData As T_Carfare, ByRef writeStatus As String) As Boolean

        'ファイルサーバーに交通費ファイルの有無を確認
        Dim ret As Boolean = True
        Dim sds As New ServerDirectorySearch
        sds.f_Domain = My.Settings.DomainName
        sds.f_UserID = My.Settings.SrvUserID
        sds.f_Password = My.Settings.SrvPass

        sds.FolderPath = My.Settings.SearchPath & carfareData.FolderName
        sds.SeachFileName = String.Format(SEARCH_FILE_FORMAT, carfareData.Year, carfareData.Month, carfareData.LastName & carfareData.FirstName)

        'サーバー検索処理
        Dim authFlg As Boolean = My.Settings.ServerAuth
        Dim result As Integer = 0
        If authFlg = True Then
            ' サーバー認証あり
            result = sds.isSearchFile()
        Else
            ' サーバー認証なし
            result = sds.DirectorySeach
        End If

        Select Case result
            Case ServerDirectorySearch.FileCheck.fTrue
                ' 交通費ファイルあり
                writeStatus = T_Carfare.WriteStatusCode.sTrue
            Case ServerDirectorySearch.FileCheck.fFalse
                ' 交通費ファイルなし
                writeStatus = T_Carfare.WriteStatusCode.sFalse
            Case ServerDirectorySearch.FileCheck.fError
                ' エラー発生
                Response.Write("エラー")
                ret = False
                'SendErrorMail()
        End Select


        Return ret
    End Function
End Class