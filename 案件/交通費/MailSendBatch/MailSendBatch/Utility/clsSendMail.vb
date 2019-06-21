Imports System.Threading

Public Class clsSendMail
    Public Shared Function SendMail(MailFrom As String, MailTo As String, MailSubject As String, MailBody As String) As Boolean
        Dim bRet As Boolean = False
        For iCnt = 1 To 3
            If iCnt <> 1 Then
                '2回目以降は待機後に再送信させる
                System.Threading.Thread.Sleep(5000)
            End If
            Try
                Using msg As New System.Net.Mail.MailMessage(MailFrom, MailTo, MailSubject, MailBody)
                    Using sc As New System.Net.Mail.SmtpClient()
                        'SMTPサーバーなどを設定する
                        sc.Host = My.Settings.SmtpHost
                        sc.Port = My.Settings.SmtpPort
                        sc.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network
                        sc.Timeout = My.Settings.SmtpTimeout
                        sc.DeliveryFormat = Net.Mail.SmtpDeliveryFormat.International
                        sc.UseDefaultCredentials = True
                        'ユーザー名とパスワードを設定する
                        sc.Credentials = New System.Net.NetworkCredential(My.Settings.SmtpID, My.Settings.SmtpPassword)
                        'SSLを使用する
                        sc.EnableSsl = My.Settings.SmtpSSL
                        'メッセージを送信する
                        sc.Send(msg)
                        '後始末
                        sc.Dispose()
                    End Using
                    msg.Dispose()

                    bRet = True
                    Exit For
                End Using
            Catch ex As Exception
                LogWrite.ErrorLog(ex)
                ' SystemLog.ExceptionError(ex)
            End Try
        Next

        If Not bRet Then
            '   SystemLog.ErrorTEL("SendMail", "メール通知失敗")
        End If

        Return bRet
    End Function
End Class
