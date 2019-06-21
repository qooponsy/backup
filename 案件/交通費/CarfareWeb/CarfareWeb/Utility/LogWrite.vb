''' <summary>
''' イベントログへの書き込み
''' </summary>
Public Class LogWrite
    Private Const EVENT_SOURCE As String = "Carfare"
    Private Const SYSTEM_NAME As String = "CarfareWeb"

    Public Shared Sub Information(info As String)
        EventLog.WriteEntry(EVENT_SOURCE, "【" & SYSTEM_NAME & "】" & info, EventLogEntryType.Information)

    End Sub

    Public Shared Sub Warning(warnig As String)
        EventLog.WriteEntry(EVENT_SOURCE, "【" & SYSTEM_NAME & "】" & warnig, EventLogEntryType.Warning)

    End Sub

    Public Shared Sub ErrorLog(ex As Exception)
        EventLog.WriteEntry(EVENT_SOURCE, "【" & SYSTEM_NAME & "】" & ex.Message & vbCrLf & If(Not ex.StackTrace Is Nothing, vbCrLf & ex.StackTrace.ToString(), ""), EventLogEntryType.Error)
        SendErrorMail()
    End Sub

    'エラーメール送信
    Private Shared Sub SendErrorMail()
        ' メール情報
        Dim from As String = My.Settings.SmtpID
        Dim subject As String = "【交通費清算】システムエラー発生"
        If (My.Settings.TestMode) Then
            subject = "【テスト環境】" + subject
        End If

        Dim body As New StringBuilder
        body.AppendLine("交通費システムの" & SYSTEM_NAME & "にてシステムエラーが発生")
        body.AppendLine("Webサーバーのイベントログを確認してください。")
        body.AppendLine("エラー検知時刻：" & Now.ToString("yyyy/MM/dd HH:mm:ss"))

        ' DBエラーを考慮してアドレスは直接入力
        Dim toAddress As String = My.Settings.AdminAddress

        clsSendMail.SendMail(from, toAddress, subject, body.ToString())

    End Sub

End Class
