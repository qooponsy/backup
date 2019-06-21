''' <summary>
''' イベントログへの書き込み
''' </summary>
Public Class LogWrite
    Private Const EVENT_SOURCE As String = "Carfare"
    Private Const SYSTEM_NAME As String = "MailSendBatch"

    Public Shared Sub Information(info As String)
        EventLog.WriteEntry(EVENT_SOURCE, "【" & SYSTEM_NAME & "】" & info, EventLogEntryType.Information)

    End Sub

    Public Shared Sub Warning(warnig As String)
        EventLog.WriteEntry(EVENT_SOURCE, "【" & SYSTEM_NAME & "】" & warnig, EventLogEntryType.Warning)

    End Sub

    Public Shared Sub ErrorLog(ex As Exception)
        EventLog.WriteEntry(EVENT_SOURCE, "【" & SYSTEM_NAME & "】" & ex.Message & vbCrLf & If(Not ex.StackTrace Is Nothing, vbCrLf & ex.StackTrace.ToString(), ""), EventLogEntryType.Error)

    End Sub

End Class
