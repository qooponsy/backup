Module CarfateBatch

    Sub Main(CmdArgs() As String)

        'Dim carfareID As Integer    '交通費ID
        Dim LastDay As New LastBusinessDay '最終営業日
        Dim Today As Date    '今日の日付
        Dim workerlist As New List(Of WorkerData)
        Dim Success As Boolean

        If CmdArgs.Count = 1 Then
            '本日の日付を取得
            Today = DateTime.Now.Date
            Debug.Write("今日の日付は" & Today.ToString("yyyy-MM-dd"))
        ElseIf CmdArgs.Count = 2 Then
            'テスト用データ日付を取得
            Today = DateTime.Parse(CmdArgs(1))
            Debug.Write("※テスト※今日の日付は" & Today.ToString("yyyy-MM-dd"))
        End If

        If CmdArgs.Length = 0 Then

            LogWrite.Warning("コマンドライン引数が指定されていません。バッチ処理を終了します")

            '朝バッチ
        ElseIf CmdArgs(0) = "M" Then

            'イベントログ出力
            LogWrite.Information("朝バッチ処理開始")

            '最終営業日判定＆取得
            Success = CarfareDB.GetLastBusinessDay(Today, LastDay)

            '社員取得（休職・退職者除く）
            If Success = True Then
                Success = CarfareDB.GetWorkerList(workerlist)
            End If

            If Success = True Then
                For Each worker In workerlist

                    Dim FolderName As String = worker.FolderName & Today.ToString("_yyyyMM")
                    'セッションキー生成
                    Dim SessionKey As String = clsSessionKey.CreateSession(FolderName)

                    '交通費記載確認用データ・セッションキー登録
                    If Success = True Then
                        Success = CarfareDB.InsertCarfareData_SessionKey(worker, LastDay.LastBusinessDayID, SessionKey, Today)
                    End If

                Next
            End If

            '一括メールのデータ登録（交通費記載依頼メール）
            If Success = True Then
                Success = CarfareDB.InsertCarfareMailData(Today, LastDay.LastBusinessDayID)
            End If

            If Success = True Then
                LogWrite.Information("朝バッチ処理終了")
            End If

            '夜バッチ
        ElseIf CmdArgs(0) = "N" Then

            LogWrite.Information("夜バッチ処理開始")

            'ステータス確認
            Success = CarfareDB.GetWriteStatus(workerlist)

            '一括メールデータ登録(未記載報告メール用)
            If Success = True Then
                Success = CarfareDB.InsertCarfareMailData_n(Today)
            End If

            If Success = True Then
                LogWrite.Information("夜バッチ処理終了")
            End If

        End If

    End Sub
End Module
