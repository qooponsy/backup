Imports System.Text

Module MailSendBatch

    Private Const SUB_ErrorMail As String = "【交通費清算】システムエラー発生"
    Private Const SUB_Description As String = "【交通費清算】交通費清算依頼"
    Private Const SUB_Completion As String = "【交通費清算】{0}の記載報告完了"
    Private Const SUB_MailReminder As String = "【交通費清算】交通費を記載してください。"
    Private Const SUB_MailReminderReport As String = "【交通費清算】社員全員の交通費記載が完了していません。"

    Private Const SEARCH_FILE_FORMAT As String = "{0}_{1}_交通費_{2}.xls"

    '交通費ステータス
    Public Enum WriteStatus As Integer
        sTrue = 1   '交通費あり
        sFalse = 2  '交通費なし
    End Enum

    ' メイン処理
    Sub Main()

        '一括メールチェック
        SendBulkMail()

        '記載完了報告メールチェック
        SendCompCarfareMail()

    End Sub

    ''' <summary>
    ''' 一括メールチェック
    '''     BilkMailテーブルのステータス = 0のものをすべて取得する
    '''     取得したデータが1件以上でForEachを回す
    '''     データごとにMailCodeをチェックして分岐させる
    ''' </summary>
    Private Sub SendBulkMail()

        Dim bulkMailList As New List(Of S_BulkMail) 'BulkMail用のデータ収納リスト

        Dim checkBulkMail As Boolean = S_BulkMail.GetBulkMailList(bulkMailList)
        If bulkMailList.Count > 0 Then

            For Each mailData As S_BulkMail In bulkMailList 'データ件数ごとに回す
                Dim mailCode As Integer = mailData.MailCode
                Dim bulkMailID As Integer = mailData.BulkMailID

                Select Case mailCode
                    Case S_BulkMail.MailCodeSetting.REQ_CARFARE_MAIL
                        ' 交通費記載依頼メール送信
                        MailDescription(bulkMailID)  '社員用
                        MailCarfareRequestAdmin()    '管理者用
                    Case S_BulkMail.MailCodeSetting.UN_COMP_MAIL
                        ' 未記載報告メール
                        Dim success As Boolean = False
                        success = MailReminder()      '社員用
                        If success Then
                            success = MailReminderAdmin() '管理者用
                        End If

                        If success Then
                            '一括メールステータス変更
                            success = S_BulkMail.UpdateBulkMailSendStatus(bulkMailID)
                        End If

                        If success = False Then
                            'エラーメール送信
                            SendErrorMail()
                        End If

                End Select

            Next
        End If

    End Sub

    ''' <summary>
    ''' 記載完了報告処理
    '''     ターゲット:T_Carfare/Status = 2
    ''' </summary>
    Private Sub SendCompCarfareMail()

        Dim success As Boolean = False

        '交通費記載完了報告者取得
        Dim carfareList As New List(Of T_Carfare)
        success = T_Carfare.GetCarfareMailList(T_Carfare.StatusCode.WRK_COMP_REQ, carfareList)

        For Each carfare In carfareList

            Dim fileFlg As Boolean = False
            Select Case carfare.WriteStatus
                Case WriteStatus.sTrue
                    ' 交通費ファイルあり
                    success = SendFileThereMail(carfare)
                Case WriteStatus.sFalse
                    ' 交通費ファイルなし
                    success = SendFileNoneMail(carfare)
                Case Else
                    ' エラー発生
                    SendErrorMail()
            End Select

            If success Then
                '交通費ステータスの変更
                success = T_Carfare.UpdateAdminReportStatus(carfare.carfareID)
            End If

            If success Then
                '全員の報告が完了したか確認
                S_LastBusinessDay.CheckLastMail(carfare.LastBusinessDayID)
            End If

            If success = False Then
                SendErrorMail()
            End If

        Next

    End Sub

    ''' <summary>
    ''' 交通費記載依頼メール送信
    ''' </summary>
    Private Sub MailDescription(ByVal bulkMailID As Integer)

        Dim success As Boolean = False

        '交通費記載メール送信者取得
        Dim carfareList As New List(Of T_Carfare)
        success = T_Carfare.GetCarfareMailList(T_Carfare.StatusCode.REQ_MAIL_UNSEND, carfareList)

        If success Then

            '交通費記載メール送信
            Dim webIP As String = My.Settings.WebIPAddress
            Dim webName As String = My.Settings.WebName
            Dim from As String = My.Settings.SmtpID
            Dim subject As String = SUB_Description
            subject = AddSubject(subject) '環境情報の追加

            For Each carfare In carfareList

                Dim toAddress As String = carfare.Mail
                Dim body As String = String.Format(My.Resources.MailDescription, webIP, webName, carfare.SessionKey)

                success = clsSendMail.SendMail(from, toAddress, subject, body)

                If success Then
                    ' 送信ステータス変更
                    success = T_Carfare.UpdateCarfareMailSendStatus(carfare.carfareID)
                End If

                If success = False Then
                    Exit For
                End If
            Next

            If success Then
                '一括メールステータス変更
                success = S_BulkMail.UpdateBulkMailSendStatus(bulkMailID)
            End If
        End If

        If success = False Then
            'エラーメール送信
            SendErrorMail()
        End If

    End Sub

    Private Sub MailCarfareRequestAdmin()
        Dim success As Boolean = False

        '管理者取得
        Dim adminList As New List(Of M_Worker)
        success = M_Worker.GetAdmminWorker(adminList)

        If success Then
            Dim from As String = My.Settings.SmtpID
            Dim subject As String = SUB_Description
            subject = AddSubject(subject) '環境情報の追加
            Dim body As String = My.Resources.MailDescriptionAdmin

            For Each admin In adminList
                Dim toAddress As String = admin.Mail

                success = clsSendMail.SendMail(from, toAddress, subject, body)

                If success = False Then
                    Exit For
                End If
            Next

        End If

        If success = False Then
            SendErrorMail()
        End If

    End Sub

    Private Function MailReminder() As Boolean
        Dim success As Boolean = False

        '未報告者取得
        Dim notCompList As New List(Of T_Carfare)
        success = T_Carfare.GetCarfareMailList(T_Carfare.StatusCode.REQ_MAIL_SEND, notCompList)

        If success Then
            '交通費記載メール送信
            Dim webIP As String = My.Settings.WebIPAddress
            Dim webName As String = My.Settings.WebName
            Dim from As String = My.Settings.SmtpID
            Dim subject As String = SUB_MailReminder
            subject = AddSubject(subject) '環境情報の追加

            For Each carfare In notCompList
                Dim toAddress As String = carfare.Mail
                Dim body As String = String.Format(My.Resources.MailReminder, webIP, webName, carfare.SessionKey)

                success = clsSendMail.SendMail(from, toAddress, subject, body)

                If success = False Then
                    Exit For
                End If
            Next

        End If

        If success = False Then
            'エラーメール送信
            SendErrorMail()
        End If

        Return success
    End Function

    Private Function MailReminderAdmin() As Boolean
        Dim success As Boolean = False

        '管理者取得
        Dim adminList As New List(Of M_Worker)
        success = M_Worker.GetAdmminWorker(adminList)

        Dim notCompList As New List(Of T_Carfare)
        If success Then
            '未報告者取得
            success = T_Carfare.GetCarfareMailList(T_Carfare.StatusCode.REQ_MAIL_SEND, notCompList)
        End If

        Dim toList As New StringBuilder
        If success Then
            '宛先リストの作成
            For Each carfare In notCompList
                toList.AppendLine("　　" & carfare.LastName & " " & carfare.FirstName)
            Next
        End If

        If success Then
            Dim from As String = My.Settings.SmtpID
            Dim subject As String = SUB_MailReminderReport
            subject = AddSubject(subject) '環境情報の追加
            Dim body As String = String.Format(My.Resources.MailReminderReport, toList.ToString)

            For Each admin In adminList
                Dim toAddress As String = admin.Mail

                success = clsSendMail.SendMail(from, toAddress, subject, body)

                If success = False Then
                    Exit For
                End If
            Next

        End If

        If success = False Then
            SendErrorMail()
        End If

        Return success
    End Function

    'ファイルありメール送信
    Private Function SendFileThereMail(ByVal carfare As T_Carfare)
        Dim success As Boolean = False

        '管理者取得
        Dim adminList As New List(Of M_Worker)
        success = M_Worker.GetAdmminWorker(adminList)

        If success Then

            For Each admin In adminList
                '交通費記載メール送信
                Dim webIP As String = My.Settings.WebIPAddress
                Dim webName As String = My.Settings.WebName
                Dim from As String = My.Settings.SmtpID
                Dim toAddress As String = admin.Mail
                Dim subject As String = String.Format(SUB_Completion, carfare.LastName & carfare.FirstName)
                subject = AddSubject(subject) '環境情報の追加
                Dim body As String = String.Format(My.Resources.MailCompletion_1, carfare.LastName & carfare.FirstName, carfare.Month)

                success = clsSendMail.SendMail(from, toAddress, subject, body)

            Next
        End If

        If success = False Then
            SendErrorMail()
        End If

        Return success
    End Function

    'ファイルなしメール送信
    Private Function SendFileNoneMail(ByVal carfare As T_Carfare)
        Dim success As Boolean = False

        '管理者取得
        Dim adminList As New List(Of M_Worker)
        success = M_Worker.GetAdmminWorker(adminList)

        If success Then

            For Each admin In adminList
                '交通費記載メール送信
                Dim webIP As String = My.Settings.WebIPAddress
                Dim webName As String = My.Settings.WebName
                Dim from As String = My.Settings.SmtpID
                Dim toAddress As String = admin.Mail
                Dim subject As String = String.Format(SUB_Completion, carfare.LastName & carfare.FirstName)
                subject = AddSubject(subject) '環境情報の追加
                Dim body As String = String.Format(My.Resources.MailCompletion_2, carfare.LastName & carfare.FirstName, carfare.Month)

                success = clsSendMail.SendMail(from, toAddress, subject, body)

            Next
        End If

        If success = False Then
            SendErrorMail()
        End If

        Return success
    End Function

    'エラーメール送信
    Private Sub SendErrorMail()
        ' メール情報
        Dim from As String = My.Settings.SmtpID
        Dim subject As String = SUB_ErrorMail
        subject = AddSubject(subject) '環境情報の追加

        Dim body As New StringBuilder
        body.AppendLine("交通費システムのMailSendBatchにてシステムエラーが発生")
        body.AppendLine("DBサーバーのイベントログを確認してください。")
        body.AppendLine("エラー検知時刻：" & Now.ToString("yyyy/MM/dd HH:mm:ss"))

        ' DBエラーを考慮してアドレスは直接入力
        Dim toAddress As String = My.Settings.AdminAddress

        clsSendMail.SendMail(from, toAddress, subject, body.ToString())

    End Sub

    '件名に環境情報を追加
    Private Function AddSubject(ByVal subject As String)
        Dim ret As String = subject

        'テスト環境
        If (My.Settings.TestMode) Then
            ret = "【テスト環境】" + subject
        End If

        Return ret
    End Function

End Module
