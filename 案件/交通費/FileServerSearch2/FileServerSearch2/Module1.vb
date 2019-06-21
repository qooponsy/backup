Module Module1

    Sub Main()

        Dim sds As New ServerDirectorySearch
        sds.f_Domain = "fate-i.lo"
        sds.f_UserID = "carfare"
        sds.f_Password = "carfare"

        sds.FolderPath = "\\192.168.0.12\personal\sagae"
        sds.SeachFileName = "2017.12勤務表（寒河江）.xls"

        Dim ret As Integer = 0
        ret = sds.isSearchFile()

        Debug.Write("リターン値：" & ret.ToString)

    End Sub

End Module
