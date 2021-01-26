Imports System.Data.SqlClient
Imports System.IO
Imports System.Drawing.Text

Module Func
    Public con As SqlConnection
    Public server, db, userid, passw, un, ugroup As String
    Public cmd, cmd1, cmdact As SqlCommand


    Public pfc As New PrivateFontCollection()
    Public Sub changefont(p As Panel)
        Try
            pfc.AddFontFile("fonts/droid.ttf")
            For Each ctrl As Control In p.Controls
                ctrl.Font = New Font(pfc.Families(0), 10)
            Next
        Catch ex As Exception

        End Try
    End Sub




    Public Function tx() As Integer
        Try
            copen()
            Dim gt As New SqlCommand("SELECT tax FROM taxes", con)
            tx = gt.ExecuteScalar
            cclose()
            Return tx
        Catch ex As Exception
            Return 0
        End Try
    End Function




    Public Function GetAge(ByVal Birthdate As System.DateTime, _
        Optional ByVal AsOf As System.DateTime = #1/1/1700#) _
        As String
        Dim iMonths As Integer
        Dim iYears As Integer
        Dim dYears As Decimal
        Dim lDayOfBirth As Long
        Dim lAsOf As Long
        Dim iBirthMonth As Integer
        Dim iAsOFMonth As Integer

        If AsOf = "#1/1/1700#" Then
            AsOf = DateTime.Now
        End If
        lDayOfBirth = DatePart(DateInterval.Day, Birthdate)
        lAsOf = DatePart(DateInterval.Day, AsOf)

        iBirthMonth = DatePart(DateInterval.Month, Birthdate)
        iAsOFMonth = DatePart(DateInterval.Month, AsOf)

        iMonths = DateDiff(DateInterval.Month, Birthdate, AsOf)

        dYears = iMonths / 12

        iYears = Math.Floor(dYears)

        If iBirthMonth = iAsOFMonth Then
            If lAsOf < lDayOfBirth Then
                iYears = iYears - 1
            End If
        End If

        Return iYears
    End Function




    Public Sub copen()
        If con.State = ConnectionState.Closed Then con.Open()
    End Sub




    Public Sub cclose()
        If con.State = ConnectionState.Open Then con.Close()
    End Sub




    Public Function nowdate()
        connect()
        copen()
        Try
            cmd = New SqlCommand("SELECT GETDATE();", con)
            Return cmd.ExecuteScalar
        Catch ex As Exception
            Return False
        End Try
        cclose()
    End Function





    Function ToHijra(ByVal gDate As Date, Optional ByVal format As String = Nothing) As String
        Try
            Return gDate.ToString(format, New Globalization.CultureInfo("ar-SA"))
        Catch ex As Exception
            Return ""
        End Try
    End Function





    Function NoToTxt(ByVal TheNo As Double, ByVal MyCur As String, ByVal MySubCur As String) As String
        Dim MyArry1(0 To 9) As String
        Dim MyArry2(0 To 9) As String
        Dim MyArry3(0 To 9) As String
        Dim MyNo As String = ""
        Dim GetNo As String = ""
        Dim RdNo As String = ""
        Dim My100 As String = ""
        Dim My10 As String = ""
        Dim My1 As String = ""
        Dim My11 As String = ""
        Dim My12 As String = ""
        Dim GetTxt As String = ""
        Dim Mybillion As String = ""
        Dim MyMillion As String = ""
        Dim MyThou As String = ""
        Dim MyHun As String = ""
        Dim MyFraction As String = ""
        Dim MyAnd As String = ""
        Dim i As Integer
        Dim ReMark As String = ""


        If TheNo > 999999999999.99 Then

        End If


        If TheNo = 0 Then
            NoToTxt = "صفر"
            Exit Function
        End If

        MyAnd = " و"
        MyArry1(0) = ""
        MyArry1(1) = "مائة"
        MyArry1(2) = "مائتان"
        MyArry1(3) = "ثلاثمائة"
        MyArry1(4) = "أربعمائة"
        MyArry1(5) = "خمسمائة"
        MyArry1(6) = "ستمائة"
        MyArry1(7) = "سبعمائة"
        MyArry1(8) = "ثمانمائة"
        MyArry1(9) = "تسعمائة"

        MyArry2(0) = ""
        MyArry2(1) = " عشر"
        MyArry2(2) = "عشرون"
        MyArry2(3) = "ثلاثون"
        MyArry2(4) = "أربعون"
        MyArry2(5) = "خمسون"
        MyArry2(6) = "ستون"
        MyArry2(7) = "سبعون"
        MyArry2(8) = "ثمانون"
        MyArry2(9) = "تسعون"

        MyArry3(0) = ""
        MyArry3(1) = "واحد"
        MyArry3(2) = "اثنان"
        MyArry3(3) = "ثلاثة"
        MyArry3(4) = "أربعة"
        MyArry3(5) = "خمسة"
        MyArry3(6) = "ستة"
        MyArry3(7) = "سبعة"
        MyArry3(8) = "ثمانية"
        MyArry3(9) = "تسعة"
        '======================
        GetNo = Format(TheNo, "000000000000.00")

        i = 0
        Do While i < 15

            If i < 12 Then
                MyNo = Mid$(GetNo, i + 1, 3)
            Else
                MyNo = "0" + Mid$(GetNo, i + 2, 2)
            End If

            If (Mid$(MyNo, 1, 3)) > 0 Then

                RdNo = Mid$(MyNo, 1, 1)
                My100 = MyArry1(RdNo)
                RdNo = Mid$(MyNo, 3, 1)
                My1 = MyArry3(RdNo)
                RdNo = Mid$(MyNo, 2, 1)
                My10 = MyArry2(RdNo)

                If Mid$(MyNo, 2, 2) = 11 Then My11 = "إحدى عشر"
                If Mid$(MyNo, 2, 2) = 12 Then My12 = "إثنى عشر"
                If Mid$(MyNo, 2, 2) = 10 Then My10 = "عشرة"

                If ((Mid$(MyNo, 1, 1)) > 0) And ((Mid$(MyNo, 2, 2)) > 0) Then My100 = My100 + MyAnd
                If ((Mid$(MyNo, 3, 1)) > 0) And ((Mid$(MyNo, 2, 1)) > 1) Then My1 = My1 + MyAnd

                GetTxt = My100 + My1 + My10

                If ((Mid$(MyNo, 3, 1)) = 1) And ((Mid$(MyNo, 2, 1)) = 1) Then
                    GetTxt = My100 + My11
                    If ((Mid$(MyNo, 1, 1)) = 0) Then GetTxt = My11
                End If

                If ((Mid$(MyNo, 3, 1)) = 2) And ((Mid$(MyNo, 2, 1)) = 1) Then
                    GetTxt = My100 + My12
                    If ((Mid$(MyNo, 1, 1)) = 0) Then GetTxt = My12
                End If

                If (i = 0) And (GetTxt <> "") Then
                    If ((Mid$(MyNo, 1, 3)) > 10) Then
                        Mybillion = GetTxt + " مليار"
                    Else
                        Mybillion = GetTxt + " مليارات"
                        If ((Mid$(MyNo, 1, 3)) = 2) Then Mybillion = " مليار"
                        If ((Mid$(MyNo, 1, 3)) = 2) Then Mybillion = " ملياران"
                    End If
                End If

                If (i = 3) And (GetTxt <> "") Then

                    If ((Mid$(MyNo, 1, 3)) > 10) Then
                        MyMillion = GetTxt + " مليون"
                    Else
                        MyMillion = GetTxt + " ملايين"
                        If ((Mid$(MyNo, 1, 3)) = 1) Then MyMillion = " مليون"
                        If ((Mid$(MyNo, 1, 3)) = 2) Then MyMillion = " مليونان"
                    End If
                End If

                If (i = 6) And (GetTxt <> "") Then
                    If ((Mid$(MyNo, 1, 3)) > 10) Then
                        MyThou = GetTxt + " ألف"
                    Else
                        MyThou = GetTxt + " آلاف"
                        If ((Mid$(MyNo, 3, 1)) = 1) Then MyThou = " ألف"
                        If ((Mid$(MyNo, 3, 1)) = 2) Then MyThou = " ألفان"
                    End If
                End If

                If (i = 9) And (GetTxt <> "") Then MyHun = GetTxt
                If (i = 12) And (GetTxt <> "") Then MyFraction = GetTxt
            End If

            i = i + 3
        Loop

        If (Mybillion <> "") Then
            If (MyMillion <> "") Or (MyThou <> "") Or (MyHun <> "") Then Mybillion = Mybillion + MyAnd
        End If

        If (MyMillion <> "") Then
            If (MyThou <> "") Or (MyHun <> "") Then MyMillion = MyMillion + MyAnd
        End If

        If (MyThou <> "") Then
            If (MyHun <> "") Then MyThou = MyThou + MyAnd
        End If

        If MyFraction <> "" Then
            If (Mybillion <> "") Or (MyMillion <> "") Or (MyThou <> "") Or (MyHun <> "") Then
                NoToTxt = ReMark + Mybillion + MyMillion + MyThou + MyHun + " " + MyCur + MyAnd + MyFraction + " " + MySubCur
            Else
                NoToTxt = ReMark + MyFraction + " " + MySubCur
            End If
        Else
            NoToTxt = ReMark + Mybillion + MyMillion + MyThou + MyHun + " " + MyCur
        End If
    End Function





    Public Sub alert(txt As String, fg As Integer)
        Msg.msgtxt.Text = txt
        If fg = 1 Then
            Msg.imoji.Image = My.Resources.success
            Msg.BackColor = Color.LimeGreen
            Msg.Button1.BackColor = Color.LimeGreen
        ElseIf fg = 0 Then
            Msg.imoji.Image = My.Resources.fail
            Msg.BackColor = Color.FromArgb(219, 41, 66)
            Msg.Button1.BackColor = Color.FromArgb(219, 41, 66)
        End If
        Try
            Msg.ShowDialog()
        Catch ex As Exception

        End Try
    End Sub





    Public Sub connect()
        Try
            Dim st As String
            Using sr As StreamReader = New StreamReader(Application.StartupPath & "\SQLSettings.dat")
                st = sr.ReadLine()
            End Using

            con = New SqlConnection(st)
            con.Open()
            con.Close()
        Catch ex As Exception
            alert("النظام غير قادر على الإتصال بالخادم، حاول مرة اخرى", 0)
            Exit Sub
        End Try
    End Sub





    Public Function NextID(value As Integer) As Integer
        value += 1
        Return value
    End Function





    Public Sub clear(gb As GroupBox)
        Try
            For Each tb In gb.Controls.OfType(Of TextBox)()
                Try
                    tb.Clear()
                Catch ex As Exception

                End Try
            Next tb
            For Each dte In gb.Controls.OfType(Of DateTimePicker)()
                Try
                    dte.Value = nowdate()
                Catch ex As Exception

                End Try
            Next dte
            For Each rt In gb.Controls.OfType(Of RichTextBox)()
                Try
                    rt.Clear()
                Catch ex As Exception

                End Try
            Next rt
            For Each dg In gb.Controls.OfType(Of DataGridView)()
                Try
                    dg.Rows.Clear()
                Catch ex As Exception

                End Try
            Next dg
            For Each cb In gb.Controls.OfType(Of ComboBox)()
                Try
                    cb.SelectedIndex = 0
                Catch ex As Exception

                End Try
            Next cb
            For Each nu In gb.Controls.OfType(Of NumericUpDown)()
                Try
                    nu.Value = 1
                Catch ex As Exception

                End Try
            Next nu
            For Each ci In gb.Controls.OfType(Of PictureBox)()
                If ci.Name = "ppic" Then
                    Try
                        ci.Image = HiTech.My.Resources.profile_pic_png_3
                    Catch ex As Exception

                    End Try
                Else
                    Try
                        ci.Image = HiTech.My.Resources.file_explorer
                    Catch ex As Exception

                    End Try
                End If
            Next
            For Each cb In gb.Controls.OfType(Of CheckBox)()
                Try
                    cb.CheckState = CheckState.Checked
                Catch ex As Exception

                End Try
            Next cb
        Catch ex As Exception

        End Try
    End Sub

End Module
