Public Class frmMain

    Dim SEQ As Integer

    Private Sub Button1_Click(sender As System.Object, e As System.EventArgs)

        Dim sCnn As SqlClient.SqlConnection = New SqlClient.SqlConnection
        Dim sCmd As SqlClient.SqlCommand = New SqlClient.SqlCommand
        Dim dApt As SqlClient.SqlDataAdapter
        Dim dTbl As Data.DataTable = New Data.DataTable
        Dim dTblキャラ As Data.DataTable = New Data.DataTable

        Dim StrSQL As String

        Dim FileNum As Integer
        Dim OutFileName As String

        Dim ImputDat As String
        Dim Strキャラ As String

        Dim WordDoc As Microsoft.Office.Interop.Word.Application = New Microsoft.Office.Interop.Word.Application
        Dim i As Integer

        With Me.OpenFileDialog1

            .Filter = "*.doc|*.doc"

        End With

        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

        Else

            Exit Sub

        End If

        FileNum = FreeFile()

        Me.txtファイル名.Text = Me.OpenFileDialog1.FileName
        OutFileName = Application.CommonAppDataPath & "\temp.txt"
        WordDoc.Documents.Open(Me.txtファイル名.Text, , [ReadOnly]:=True)
        WordDoc.Documents(1).Select()

        FileOpen(FileNum, OutFileName, OpenMode.Output, OpenAccess.Default, OpenShare.Default)

        Print(FileNum, WordDoc.Selection.Text)

        FileClose(FileNum)
        FileNum = FreeFile()
        FileOpen(FileNum, OutFileName, OpenMode.Input, OpenAccess.Read, OpenShare.Default)

        sCnn.ConnectionString = DB.DBBR
        sCnn.Open()

        sCmd.Connection = sCnn

        ImputDat = ""

        i = 1

        Do Until EOF(FileNum) = True

            ImputDat = LineInput(FileNum)

            If ImputDat Like "【*" Then

                Strキャラ = ImputDat


                ImputDat = LineInput(FileNum)

                StrSQL = "INSERT INTO 台本変換_うたぷりAllStar_WORK "
                StrSQL &= "("
                StrSQL &= "SEQ,"
                StrSQL &= "No,"
                StrSQL &= "キャラ名,"
                StrSQL &= "テキスト,"
                StrSQL &= "種別"
                StrSQL &= ") VALUES ("
                StrSQL &= SEQ & ","
                StrSQL &= i & ","
                StrSQL &= "'" & Strキャラ & "',"
                StrSQL &= "'" & ImputDat & "',"
                StrSQL &= 1
                StrSQL &= ")"

                sCmd.CommandText = StrSQL
                sCmd.ExecuteNonQuery()

            Else

                StrSQL = "INSERT INTO 台本変換_うたぷりAllStar_WORK "
                StrSQL &= "("
                StrSQL &= "SEQ,"
                StrSQL &= "No,"
                StrSQL &= "テキスト,"
                StrSQL &= "種別"
                StrSQL &= ") VALUES ("
                StrSQL &= SEQ & ","
                StrSQL &= i & ","
                StrSQL &= "'" & ImputDat & "',"
                StrSQL &= 0
                StrSQL &= ")"

                sCmd.CommandText = StrSQL
                sCmd.ExecuteNonQuery()

            End If

            Application.DoEvents()

            If ImputDat = "" Then

                For k = 0 To Me.Cmb行間.SelectedIndex - 1

                    If Me.Cmb行間.SelectedIndex = 0 Then Exit For

                    i = i + 1

                    StrSQL = "INSERT INTO 台本変換_うたぷりAllStar_WORK "
                    StrSQL &= "("
                    StrSQL &= "SEQ,"
                    StrSQL &= "No,"
                    StrSQL &= "テキスト,"
                    StrSQL &= "種別"
                    StrSQL &= ") VALUES ("
                    StrSQL &= SEQ & ","
                    StrSQL &= i & ","
                    StrSQL &= "'" & ImputDat & "',"
                    StrSQL &= 0
                    StrSQL &= ")"

                    sCmd.CommandText = StrSQL
                    sCmd.ExecuteNonQuery()

                Next k

            End If
            i = i + 1

        Loop

        WordDoc.Quit()

        StrSQL = "SELECT "
        StrSQL &= "No AS #,"
        StrSQL &= "ボイスNo,"
        StrSQL &= "キャラ名,"
        StrSQL &= "テキスト "
        StrSQL &= "FROM 台本変換_うたぷりAllStar_WORK "
        StrSQL &= "WHERE SEQ = " & SEQ & " "
        StrSQL &= "ORDER BY No"

        dApt = New SqlClient.SqlDataAdapter(StrSQL, sCnn)
        dApt.Fill(dTbl)

        Me.dgvItem.DataSource = dTbl


        If sCnn.State <> ConnectionState.Closed Then sCnn.Close()

        sCnn.Dispose()

        With Me.dgvItem

            .Columns(0).Width = 50
            .Columns(0).DefaultCellStyle.Format = "0000000"
            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns(1).Width = 150
            .Columns(2).Width = 500
            .Columns(3).Width = 180

        End With

    End Sub

    Private Sub キャラクターマスタメンテナンスToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ｷｬﾗｸﾀﾏｽﾀﾒﾝﾃﾅﾝｽToolStripMenuItem.Click

        frmｷｬﾗｸﾀﾏｽﾀ.ShowDialog()

    End Sub

    Private Sub frmMain_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load

        Dim sCnn As SqlClient.SqlConnection = New SqlClient.SqlConnection
        Dim sCmd As SqlClient.SqlCommand = New SqlClient.SqlCommand

        Dim dApt As SqlClient.SqlDataAdapter

        Dim dTbl As Data.DataTable = New Data.DataTable
        Dim dTblルート As Data.DataTable = New Data.DataTable
        Dim dTbl編 As Data.DataTable = New Data.DataTable

        Dim StrSQL As String

        With Me.Cmb行間

            .Items.Clear()
            .Items.Add("1行")
            .Items.Add("2行")
            .Items.Add("3行")
            .Items.Add("4行")
            .Items.Add("5行")
            .SelectedIndex = 1

        End With

        sCnn.ConnectionString = DB.DBBR
        sCnn.Open()

        sCmd.Connection = sCnn

        StrSQL = "SELECT "
        StrSQL &= "No AS #,"
        StrSQL &= "ボイスNo,"
        StrSQL &= "キャラ名,"
        StrSQL &= "テキスト,"
        StrSQL &= "種別,"
        StrSQL &= "太字 "
        StrSQL &= "FROM 台本変換_うたぷりAllStar_WORK "
        StrSQL &= "WHERE SEQ = -999 "
        StrSQL &= "ORDER BY No"

        dApt = New SqlClient.SqlDataAdapter(StrSQL, sCnn)
        dApt.Fill(dTbl)

        Me.dgvItem.DataSource = dTbl


        StrSQL = "SELECT "
        StrSQL &= "章記号,"
        StrSQL &= "章名 "
        StrSQL &= "FROM 台本変換_うたぷりAllStar_章ﾏｽﾀ "

        dApt = New SqlClient.SqlDataAdapter(StrSQL, sCnn)
        dApt.Fill(dTblルート)

        Me.cmb章.Items.Add("章を選択してください")

        For i = 0 To dTblルート.Rows.Count - 1

            Me.cmb章.Items.Add(dTblルート(i)(0) & " " & dTblルート(i)(1))

        Next i

        Me.cmb章.SelectedIndex = 0

        StrSQL = "SELECT "
        StrSQL &= "記号,"
        StrSQL &= "ﾙｰﾄ "
        StrSQL &= "FROM 台本変換_うたぷりAllStar_ﾙｰﾄﾏｽﾀ "

        dApt = New SqlClient.SqlDataAdapter(StrSQL, sCnn)
        dApt.Fill(dTbl編)

        Me.Cmbルート.Items.Add("ルートを選択してください")

        For i = 0 To dTbl編.Rows.Count - 1

            Me.Cmbルート.Items.Add(dTbl編(i)(0) & " " & dTbl編(i)(1))

        Next i

        Me.Cmbルート.SelectedIndex = 0

        If sCnn.State <> ConnectionState.Closed Then sCnn.Close()

        sCnn.Dispose()

        With Me.dgvItem

            .Columns(0).Width = 50
            .Columns(0).DefaultCellStyle.Format = "0000000"
            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns(1).Width = 180
            .Columns(2).Width = 150
            .Columns(3).Width = 500
            .Columns(4).Visible = False
            .Columns(5).Visible = False

        End With

    End Sub

    Private Sub btn参照_Click(sender As System.Object, e As System.EventArgs) Handles btn参照.Click

        Dim sCnn As SqlClient.SqlConnection = New SqlClient.SqlConnection
        Dim sCmd As SqlClient.SqlCommand = New SqlClient.SqlCommand
        Dim dApt As SqlClient.SqlDataAdapter
        Dim dTbl As Data.DataTable = New Data.DataTable
        Dim dTblキャラ As Data.DataTable = New Data.DataTable

        Dim StrSQL As String

        Dim FileNum As Integer
        Dim OutFileName As String

        Dim ImputDat As String
        Dim Strキャラ As String

        Dim WordDoc As Microsoft.Office.Interop.Word.Application = New Microsoft.Office.Interop.Word.Application
        Dim i As Integer

        SEQ = DateAndTime.Hour(Now) & DateAndTime.Minute(Now) & DateAndTime.Second(Now)

        With Me.OpenFileDialog1

            .FileName = ""
            .Filter = "*.doc|*.doc"

        End With

        If OpenFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then

        Else

            Exit Sub

        End If

        For j = 0 To Me.dgvItem.Rows.Count - 1

            Me.dgvItem.Rows.RemoveAt(0)

        Next j

        Application.DoEvents()
        FileNum = FreeFile()

        Me.txtファイル名.Text = Me.OpenFileDialog1.FileName
        OutFileName = Application.CommonAppDataPath & "\temp.txt"
        WordDoc.Documents.Open(Me.txtファイル名.Text, , [ReadOnly]:=True)
        WordDoc.Documents(1).Select()

        FileOpen(FileNum, OutFileName, OpenMode.Output, OpenAccess.Default, OpenShare.Default)

        Print(FileNum, WordDoc.Selection.Text)

        FileClose(FileNum)

        FileNum = FreeFile()
        FileOpen(FileNum, OutFileName, OpenMode.Input, OpenAccess.Read, OpenShare.Default)

        sCnn.ConnectionString = DB.DBBR
        sCnn.Open()

        sCmd.Connection = sCnn

        ImputDat = ""

        i = 1

        Do Until EOF(FileNum) = True

            ImputDat = LineInput(FileNum)

            If ImputDat Like "【*" Then

                Strキャラ = ImputDat


                ImputDat = LineInput(FileNum)

                StrSQL = "INSERT INTO 台本変換_うたぷりAllStar_WORK "
                StrSQL &= "("
                StrSQL &= "SEQ,"
                StrSQL &= "No,"
                StrSQL &= "キャラ名,"
                StrSQL &= "テキスト,"
                StrSQL &= "種別"
                StrSQL &= ") VALUES ("
                StrSQL &= SEQ & ","
                StrSQL &= i & ","
                StrSQL &= "'" & Strキャラ & "',"
                StrSQL &= "'" & ImputDat & "',"
                StrSQL &= 1
                StrSQL &= ")"

                sCmd.CommandText = StrSQL
                sCmd.ExecuteNonQuery()

            Else

                StrSQL = "INSERT INTO 台本変換_うたぷりAllStar_WORK "
                StrSQL &= "("
                StrSQL &= "SEQ,"
                StrSQL &= "No,"
                StrSQL &= "テキスト,"
                StrSQL &= "種別"
                StrSQL &= ") VALUES ("
                StrSQL &= SEQ & ","
                StrSQL &= i & ","
                StrSQL &= "'" & ImputDat & "',"
                StrSQL &= 0
                StrSQL &= ")"

                sCmd.CommandText = StrSQL
                sCmd.ExecuteNonQuery()

            End If

            Application.DoEvents()

            If ImputDat = "" Then

                For k = 0 To Me.Cmb行間.SelectedIndex - 1

                    If Me.Cmb行間.SelectedIndex = 0 Then Exit For

                    i = i + 1

                    StrSQL = "INSERT INTO 台本変換_うたぷりAllStar_WORK "
                    StrSQL &= "("
                    StrSQL &= "SEQ,"
                    StrSQL &= "No,"
                    StrSQL &= "テキスト,"
                    StrSQL &= "種別"
                    StrSQL &= ") VALUES ("
                    StrSQL &= SEQ & ","
                    StrSQL &= i & ","
                    StrSQL &= "'" & ImputDat & "',"
                    StrSQL &= 0
                    StrSQL &= ")"

                    sCmd.CommandText = StrSQL
                    sCmd.ExecuteNonQuery()

                Next k

            End If

            i = i + 1

        Loop

        FileClose(FileNum)

        WordDoc.Quit()

        StrSQL = "SELECT "
        StrSQL &= "No AS #,"
        StrSQL &= "ボイスNo,"
        StrSQL &= "キャラ名,"
        StrSQL &= "テキスト,"
        StrSQL &= "種別,"
        StrSQL &= "太字 "
        StrSQL &= "FROM 台本変換_うたぷりAllStar_WORK "
        StrSQL &= "WHERE SEQ = '" & SEQ & "' "
        StrSQL &= "ORDER BY No"

        dApt = New SqlClient.SqlDataAdapter(StrSQL, sCnn)
        dApt.Fill(dTbl)

        Me.dgvItem.DataSource = dTbl

        StrSQL = "SELECT "
        StrSQL &= "キャラ名 "
        StrSQL &= "FROM 台本変換_うたぷりAllStar_WORK "
        StrSQL &= "WHERE 種別 = 1 "
        StrSQL &= "GROUP BY キャラ名 "

        dApt = New SqlClient.SqlDataAdapter(StrSQL, sCnn)
        dApt.Fill(dTblキャラ)

        Me.Cmbキャラ.Items.Add("指定しない")

        For i = 0 To dTblキャラ.Rows.Count - 1

            Me.Cmbキャラ.Items.Add(dTblキャラ(i)(0))

        Next i

        Me.Cmbキャラ.SelectedIndex = 0

        If sCnn.State <> ConnectionState.Closed Then sCnn.Close()

        sCnn.Dispose()

        With Me.dgvItem

            .Columns(0).Width = 50
            .Columns(0).DefaultCellStyle.Format = "0000000"
            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns(1).Width = 180
            .Columns(2).Width = 150
            .Columns(3).Width = 500
            .Columns(4).Visible = False
            .Columns(5).Visible = False

        End With

        Me.Cmbキャラ.Enabled = True
        Me.cmb章.Enabled = True
        Me.Cmbルート.Enabled = True
        Me.btnボイスナンバー.Enabled = True

    End Sub

    Private Sub btnボイスナンバー_Click(sender As System.Object, e As System.EventArgs) Handles btnボイスナンバー.Click

        Dim sCnn As SqlClient.SqlConnection = New SqlClient.SqlConnection
        Dim sCmd As SqlClient.SqlCommand = New SqlClient.SqlCommand

        Dim Str編() As String
        Dim Strルート() As String

        Dim Strキャラ As String

        Dim Cnt As Integer
        Dim intエラー件数 As Integer

        If Me.cmb章.SelectedIndex = 0 Then

            MsgBox("章を選択してください", vbOKOnly + vbInformation, Application.ProductName)
            cmb章.Focus()

            Exit Sub

        End If

        If Me.Cmbルート.SelectedIndex = 0 Then

            MsgBox("ルートを選択してください", vbOKOnly + vbInformation, Application.ProductName)
            Cmbルート.Focus()

            Exit Sub

        End If

        Str編 = Split(Me.Cmbルート.Text, " ")
        Strルート = Split(Me.cmb章.Text, " ")

        sCnn.ConnectionString = DB.DBBR
        sCnn.Open()

        sCmd.Connection = sCnn

        For i = 0 To Me.dgvItem.Rows.Count - 1

            If Me.dgvItem.Rows(i).Cells(4).Value = 1 Then

                sCmd.CommandText = "SELECT セリフキャラ名 FROM 台本変換_うたぷりAllStar_ｷｬﾗﾏｽﾀ WHERE キャラクタ略名 = '" & Me.dgvItem.Rows(i).Cells(2).Value & "'"
                Strキャラ = sCmd.ExecuteScalar

                If Strキャラ = "" Then

                    Strキャラ = "ｴﾗｰ!!!"

                End If

                Me.dgvItem.Rows(i).Cells(1).Value = Strキャラ & "_" & Str編(0).ToString & "_" & Strルート(0)

                If Strキャラ = "ｴﾗｰ!!!" Then

                    Me.dgvItem.Rows(i).DefaultCellStyle.BackColor = Color.Yellow
                    intエラー件数 += 1

                End If

            Else

            End If

        Next i

        If sCnn.State <> ConnectionState.Closed Then sCnn.Close()

        sCnn.Dispose()

        For i = 0 To Me.Cmbキャラ.Items.Count - 1

            Cnt = 1

            For j = 0 To Me.dgvItem.Rows.Count - 1

                If Me.dgvItem.Rows(j).Cells(4).Value = 0 Then

                Else

                    If Me.Cmbキャラ.Items(i).ToString = Me.dgvItem.Rows(j).Cells(2).Value Then

                        Me.dgvItem.Rows(j).Cells(1).Value &= "_" & Format(Cnt, "000")

                        Cnt = Cnt + 1

                    End If

                End If

            Next j

        Next i

        Me.btnExcel.Enabled = True
        Me.Cmbキャラ.Enabled = True
        Me.lblエラー件数.Text = "エラー件数：" & intエラー件数
        MsgBox("ボイスナンバーの付与が完了しました", vbOKOnly + vbInformation, Application.ProductName)

    End Sub

    Private Sub btnExcel_Click(sender As System.Object, e As System.EventArgs) Handles btnExcel.Click

        Dim ExApp As Microsoft.Office.Interop.Excel.Application = New Microsoft.Office.Interop.Excel.Application
        Dim ExSheet As Microsoft.Office.Interop.Excel.Worksheet = New Microsoft.Office.Interop.Excel.Worksheet

        Dim j As Integer

        ExApp.Workbooks.Add()
        ExSheet = ExApp.Workbooks(1).Sheets(1)
        ExApp.Application.Visible = False

        With ExSheet

            .Range("A:A").ColumnWidth = 28
            .Range("B:B").ColumnWidth = 18
            .Range("C:C").ColumnWidth = 55

            .Range("A:A").Font.Name = "@ＭＳ 明朝"
            .Range("B:B").Font.Name = "@ＭＳ 明朝"
            .Range("C:C").Font.Name = "@ＭＳ 明朝"

            .Range("A:A").Font.Size = 12
            .Range("B:B").Font.Size = 12
            .Range("C:C").Font.Size = 12

        End With

        j = 1

        Me.lblExcel.Visible = True
        Me.ProgressBar.Visible = True
        Me.ProgressBar.Maximum = Me.dgvItem.Rows.Count

        For i = 0 To Me.dgvItem.Rows.Count - 1

            With ExSheet

                .Range("A1").Offset(i, 0).Value = Me.dgvItem.Rows(i).Cells(1).Value
                .Range("B1").Offset(i, 0).Value = Me.dgvItem.Rows(i).Cells(2).Value
                .Range("C1").Offset(i, 0).Value = Me.dgvItem.Rows(i).Cells(3).Value

                Try

                    If Me.dgvItem.Rows(i).Cells(1).Value Like "*ｴﾗｰ*" Then

                        .Range("A1").Offset(i, 0).Interior.ColorIndex = 6
                        .Range("B1").Offset(i, 0).Interior.ColorIndex = 6
                        .Range("C1").Offset(i, 0).Interior.ColorIndex = 6

                    End If

                Catch ex As Exception

                End Try
                
                If Me.dgvItem.Rows(i).Cells(5).Value = 1 Then

                    .Range("A1").Offset(i, 0).Font.Bold = True
                    .Range("A1").Offset(i, 0).Font.Name = "@HGP明朝E"
                    .Range("B1").Offset(i, 0).Font.Bold = True
                    .Range("B1").Offset(i, 0).Font.Name = "@HGP明朝E"
                    .Range("C1").Offset(i, 0).Font.Bold = True
                    .Range("C1").Offset(i, 0).Font.Name = "@HGP明朝E"

                End If

                .Range("C1").Offset(i, 0).WrapText = True
                .Range("C1").Offset(i, 0).EntireRow.AutoFit()

            End With

            Me.ProgressBar.Value = j
            j = j + 1

            Me.lblExcel.Text = "Excel出力中 " & j & "/" & Me.dgvItem.Rows.Count

            Application.DoEvents()

        Next i

        With ExSheet.PageSetup

            .RightFooter = "&P / &N"

            .Zoom = False
            .FitToPagesWide = 1
            .FitToPagesTall = 999

        End With

        Me.lblExcel.Visible = False
        Me.ProgressBar.Visible = False

        ExApp.ActiveWindow.DisplayGridlines = False

        ExApp.Application.Visible = True


    End Sub

    Private Sub Cmbキャラ_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Cmbキャラ.SelectedIndexChanged

        Dim BoldFlg As Integer

        BoldFlg = 0

        For i = 0 To Me.dgvItem.Rows.Count - 1

            Me.dgvItem.Rows(i).Cells(5).Value = 0
            Me.dgvItem.Rows(i).DefaultCellStyle.Font = New Font("MS UI Gothic", 9, FontStyle.Regular)

        Next i

        For i = 0 To Me.dgvItem.Rows.Count - 1

            If Me.dgvItem.Rows(i).Cells(3).Value = "" Then

                BoldFlg = 0

            End If

            If BoldFlg = 1 Then

                Me.dgvItem.Rows(i).Cells(5).Value = 1
                Me.dgvItem.Rows(i).DefaultCellStyle.Font = New Font("MS UI Gothic", 9, FontStyle.Bold)

            End If

            If Me.dgvItem.Rows(i).Cells(2).Value = Me.Cmbキャラ.Text Then

                Me.dgvItem.Rows(i).Cells(5).Value = 1
                Me.dgvItem.Rows(i).DefaultCellStyle.Font = New Font("MS UI Gothic", 9, FontStyle.Bold)

                BoldFlg = 1

            End If

        Next i

        Me.dgvItem.Columns(0).DefaultCellStyle.Font = New Font("MS UI Gothic", 9, FontStyle.Regular)


    End Sub


    Private Sub 章ﾏｽﾀﾒﾝﾃﾅﾝｽToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 章ﾏｽﾀﾒﾝﾃﾅﾝｽToolStripMenuItem.Click

        frm章ﾏｽﾀﾒﾝﾃﾅﾝｽ.ShowDialog()

    End Sub

    Private Sub ﾙｰﾄﾏｽﾀﾒﾝﾃﾅﾝｽToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles ﾙｰﾄﾏｽﾀﾒﾝﾃﾅﾝｽToolStripMenuItem.Click

        frmﾙｰﾄﾏｽﾀﾒﾝﾃﾅﾝｽ.ShowDialog()

    End Sub

    Private Sub 終了XToolStripMenuItem_Click(sender As System.Object, e As System.EventArgs) Handles 終了XToolStripMenuItem.Click

        Me.Close()

    End Sub

    Private Sub Cmb行間_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles Cmb行間.SelectedIndexChanged

        Dim sCnn As SqlClient.SqlConnection = New SqlClient.SqlConnection
        Dim sCmd As SqlClient.SqlCommand = New SqlClient.SqlCommand
        Dim dApt As SqlClient.SqlDataAdapter
        Dim dTbl As Data.DataTable = New Data.DataTable
        Dim dTblキャラ As Data.DataTable = New Data.DataTable

        Dim StrSQL As String

        Dim FileNum As Integer
        Dim OutFileName As String

        Dim ImputDat As String
        Dim Strキャラ As String

        Dim WordDoc As Microsoft.Office.Interop.Word.Application = New Microsoft.Office.Interop.Word.Application
        Dim i As Integer

        If Me.txtファイル名.Text = "" Then Exit Sub

        SEQ = DateAndTime.Hour(Now) & DateAndTime.Minute(Now) & DateAndTime.Second(Now)

        Application.DoEvents()
        Me.Cmb行間.Enabled = False


        For j = 0 To Me.dgvItem.Rows.Count - 1

            Me.dgvItem.Rows.RemoveAt(0)

        Next j

        Application.DoEvents()
        FileNum = FreeFile()

        OutFileName = Application.CommonAppDataPath & "\temp.txt"
        WordDoc.Documents.Open(Me.txtファイル名.Text, , [ReadOnly]:=True)
        WordDoc.Documents(1).Select()

        FileOpen(FileNum, OutFileName, OpenMode.Output, OpenAccess.Default, OpenShare.Default)

        Print(FileNum, WordDoc.Selection.Text)

        FileClose(FileNum)

        FileNum = FreeFile()
        FileOpen(FileNum, OutFileName, OpenMode.Input, OpenAccess.Read, OpenShare.Default)

        sCnn.ConnectionString = DB.DBBR
        sCnn.Open()

        sCmd.Connection = sCnn

        ImputDat = ""

        i = 1

        Do Until EOF(FileNum) = True

            ImputDat = LineInput(FileNum)

            If ImputDat Like "【*" Then

                Strキャラ = ImputDat


                ImputDat = LineInput(FileNum)

                StrSQL = "INSERT INTO 台本変換_うたぷりAllStar_WORK "
                StrSQL &= "("
                StrSQL &= "SEQ,"
                StrSQL &= "No,"
                StrSQL &= "キャラ名,"
                StrSQL &= "テキスト,"
                StrSQL &= "種別"
                StrSQL &= ") VALUES ("
                StrSQL &= SEQ & ","
                StrSQL &= i & ","
                StrSQL &= "'" & Strキャラ & "',"
                StrSQL &= "'" & ImputDat & "',"
                StrSQL &= 1
                StrSQL &= ")"

                sCmd.CommandText = StrSQL
                sCmd.ExecuteNonQuery()

            Else

                StrSQL = "INSERT INTO 台本変換_うたぷりAllStar_WORK "
                StrSQL &= "("
                StrSQL &= "SEQ,"
                StrSQL &= "No,"
                StrSQL &= "テキスト,"
                StrSQL &= "種別"
                StrSQL &= ") VALUES ("
                StrSQL &= SEQ & ","
                StrSQL &= i & ","
                StrSQL &= "'" & ImputDat & "',"
                StrSQL &= 0
                StrSQL &= ")"

                sCmd.CommandText = StrSQL
                sCmd.ExecuteNonQuery()

            End If

            Application.DoEvents()

            If ImputDat = "" Then

                For k = 0 To Me.Cmb行間.SelectedIndex - 1

                    If Me.Cmb行間.SelectedIndex = 0 Then Exit For

                    i = i + 1

                    StrSQL = "INSERT INTO 台本変換_うたぷりAllStar_WORK "
                    StrSQL &= "("
                    StrSQL &= "SEQ,"
                    StrSQL &= "No,"
                    StrSQL &= "テキスト,"
                    StrSQL &= "種別"
                    StrSQL &= ") VALUES ("
                    StrSQL &= SEQ & ","
                    StrSQL &= i & ","
                    StrSQL &= "'" & ImputDat & "',"
                    StrSQL &= 0
                    StrSQL &= ")"

                    sCmd.CommandText = StrSQL
                    sCmd.ExecuteNonQuery()

                Next k

            End If

            i = i + 1

        Loop

        FileClose(FileNum)

        WordDoc.Quit()

        StrSQL = "SELECT "
        StrSQL &= "No AS #,"
        StrSQL &= "ボイスNo,"
        StrSQL &= "キャラ名,"
        StrSQL &= "テキスト,"
        StrSQL &= "種別,"
        StrSQL &= "太字 "
        StrSQL &= "FROM 台本変換_うたぷりAllStar_WORK "
        StrSQL &= "WHERE SEQ = '" & SEQ & "' "
        StrSQL &= "ORDER BY No"

        dApt = New SqlClient.SqlDataAdapter(StrSQL, sCnn)
        dApt.Fill(dTbl)

        Me.dgvItem.DataSource = dTbl

        If sCnn.State <> ConnectionState.Closed Then sCnn.Close()

        sCnn.Dispose()

        With Me.dgvItem

            .Columns(0).Width = 50
            .Columns(0).DefaultCellStyle.Format = "0000000"
            .Columns(0).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            .Columns(1).Width = 180
            .Columns(2).Width = 150
            .Columns(3).Width = 500
            .Columns(4).Visible = False
            .Columns(5).Visible = False

        End With

        Me.Cmbキャラ.Enabled = True
        Me.cmb章.Enabled = True
        Me.Cmbルート.Enabled = True
        Me.btnボイスナンバー.Enabled = True
        Me.Cmb行間.Enabled = True

    End Sub

End Class
