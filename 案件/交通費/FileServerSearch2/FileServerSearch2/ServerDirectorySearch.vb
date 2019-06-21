Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Security.Principal
Imports System.Text

Public Class ServerDirectorySearch

    Public f_Domain As String
    Public f_UserID As String
    Public f_Password As String
    Public FolderPath As String
    Public SeachFileName As String

    Public Enum FileCheck As Integer
        fTrue = 1   'ファイルあり
        fFalse = 2  'ファイルなし
        fError = -1 '異常終了
    End Enum

    ''' <summary>
    ''' サーバーのファイル検索
    ''' </summary>
    ''' <returns>ファイルあり：1, ファイルなし：2, 異常終了：-1</returns>
    Public Function isSearchFile() As Integer
        Dim ret As Integer = 0

        Dim error_msg = New StringBuilder(255)
        Dim token As IntPtr

        Try
            ' 別ユーザーのトークン取得
            If Not LogonUser(f_UserID, f_Domain, f_Password, LOGON_TYPE.LOGON32_LOGON_NEW_CREDENTIALS, LOGON_PROVIDER.LOGON32_PROVIDER_DEFAULT, token) Then
                ret = FileCheck.fError
            End If

            If ret <> FileCheck.fError Then
                ' Try/Finally
                Try
                    '発行トークンで別ユーザーに偽装
                    Dim token2 As IntPtr
                    If Not DuplicateToken(token, SECURITY_IMPERSONATION_LEVEL.SecurityImpersonation, token2) Then
                        ret = FileCheck.fError
                    End If

                    If ret <> FileCheck.fError Then
                        Try
                            Dim identity = New WindowsIdentity(token2)
                            Dim idContext = identity.Impersonate()

                            ret = DirectorySeach()

                        Finally
                            'トークン2削除
                            CloseHandle(token2)
                        End Try
                    End If

                Finally
                    'トークン削除
                    CloseHandle(token)
                End Try
            End If

        Catch ex As Exception
            ret = FileCheck.fError
        End Try

        Return ret
    End Function

    ''' <summary>
    ''' ファイルサーチ
    ''' </summary>
    ''' <returns>ファイルあり：1, ファイルなし：2, 異常終了：-1</returns>
    Public Function DirectorySeach() As Integer
        Dim ret As Integer = FileCheck.fFalse

        Try
            Dim files As String() = Nothing
            files = Directory.GetFiles(FolderPath)

            For Each f In files
                Dim fileName As String = Path.GetFileName(f)
                If fileName = SeachFileName Then
                    ret = FileCheck.fTrue
                    Exit For
                End If
            Next
        Catch ex As Exception
            ret = FileCheck.fError
        End Try


        Return ret
    End Function

    Declare Function LogonUser Lib "advapi32.dll" Alias "LogonUserA" (
        ByVal lpszUsername As String,
        ByVal lpszDomain As String,
        ByVal lpszPassword As String,
        ByVal dwLogonType As Integer,
        ByVal dwLogonProvider As Integer,
        ByRef phToken As IntPtr) As Boolean

    Enum LOGON_TYPE
        LOGON32_LOGON_INTERACTIVE = 2
        LOGON32_LOGON_NETWORK
        LOGON32_LOGON_BATCH
        LOGON32_LOGON_SERVICE
        LOGON32_LOGON_UNLOCK = 7
        LOGON32_LOGON_NETWORK_CLEARTEXT
        LOGON32_LOGON_NEW_CREDENTIALS
    End Enum

    Enum LOGON_PROVIDER
        LOGON32_PROVIDER_DEFAULT = 0
        LOGON32_PROVIDER_WINNT35 = 1
        LOGON32_PROVIDER_WINNT40 = 2
        LOGON32_PROVIDER_WINNT50 = 3
    End Enum

    Declare Auto Function DuplicateToken Lib "advapi32.dll" (
       ByVal ExistingTokenHandle As IntPtr,
       ByVal ImpersonationLevel As Integer,
       ByRef DuplicateTokenHandle As System.IntPtr) As Boolean

    Enum SECURITY_IMPERSONATION_LEVEL
        SecurityAnonymous
        SecurityIdentification
        SecurityImpersonation
        SecurityDelegation
    End Enum

    Declare Function CloseHandle Lib "kernel32" Alias "CloseHandle" (ByVal hObject As Integer) As Integer

End Class
