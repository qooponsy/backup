
Imports System.Security.Cryptography
Imports System.Text


Public Class clsSessionKey

    Private Shared SESSION_TEXT_COUNT As Integer = 32

    ''' <summary>
    ''' ハッシュ値を32文字で生成
    ''' base = (ユーザーフォルダ名)_yyyyMM
    ''' </summary>
    ''' <param name="base">SHA256ハッシュ値の変換値</param>
    ''' <returns></returns>
    Public Shared Function CreateSession(ByVal base As String) As String

        Dim hash As String = ConvSHA256(base)
        Dim hash32 As String = hash.Substring(0, SESSION_TEXT_COUNT)

        Return hash32
    End Function

    ''' <summary>
    ''' SHA256ハッシュでセッションキー作成
    ''' </summary>
    ''' <param name="base">ハッシュ元の文字列</param>
    ''' <returns>SHA256ハッシュ値の変換値</returns>
    Public Shared Function ConvSHA256(ByVal base As String) As String

        ' ハッシュ元文字列をUTF-8エンコードでバイト配列として取り出す
        Dim enc = Encoding.GetEncoding("utf-8")
        Dim bBase As Byte() = enc.GetBytes(base)

        'SHA256ハッシュ値を計算する
        Dim s256 As New SHA256CryptoServiceProvider
        Dim hashValue As Byte() = s256.ComputeHash(bBase)

        'SHA256の計算結果をUTF8で取り出す
        Dim hash As New StringBuilder

        For i As Integer = 0 To hashValue.Length - 1
            hash.AppendFormat("{0:X2}", hashValue(i))
        Next

        Return hash.ToString()
    End Function


End Class
