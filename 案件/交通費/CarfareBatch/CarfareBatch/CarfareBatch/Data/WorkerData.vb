Public Class WorkerData

    Public Property WorkerID As String       'id
    Public Property FirstName As String       '名前
    Public Property LastName As String       '苗字
    Public Property Mail As String       'メールアドレス
    Public Property FolderName As String 'フォルダ名
    Public Property WriteWorkerStatus As String '交通費記載ステータス(個人)

    Public Const WORKER_TSUJYO As String = "1"    '社員ステータス

    Public Const CLASS_OTHER As String = "9"  '役職


End Class
