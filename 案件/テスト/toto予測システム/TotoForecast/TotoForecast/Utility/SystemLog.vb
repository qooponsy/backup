Public Class SystemLog

    Private Const EVENT_SOURCE As String = "TotoForecast"
    Private Const ProcessID As String = "TotoForecast"

    Public Shared Sub ExceptionError(ex As Exception)
        Dim objErr As Exception = ex
        While (objErr IsNot Nothing)
            Dim st As StackTrace = New StackTrace(3, True)
            EventLog.WriteEntry(EVENT_SOURCE,
                                "PROCESS:" & ProcessID & vbCrLf &
                                "SOURCE:" & objErr.Source & vbCrLf &
                                "TYPE NAME:" & TypeName(objErr) & vbCrLf &
                                "MESSAGE:" & objErr.Message & vbCrLf &
                                "TARGET SITE:" & If(Not objErr.TargetSite Is Nothing, objErr.TargetSite.ToString(), "") & vbCrLf &
                                "STACK TRACE:" & If(Not objErr.StackTrace Is Nothing, vbCrLf & objErr.StackTrace.ToString(), "") & vbCrLf & st.ToString(),
                                EventLogEntryType.Warning)

            objErr = objErr.InnerException
        End While
    End Sub


End Class
