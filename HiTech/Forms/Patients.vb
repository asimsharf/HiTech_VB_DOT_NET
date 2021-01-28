Imports System.Drawing.Text
Imports System.Data.SqlClient
Imports System.IO
Imports System.Data.SqlTypes

Public Class Patients
    Public Sub fill()
        Cursor = Cursors.WaitCursor
        connect()
        copen()
        Try
            cmd = New SqlCommand("SELECT * FROM patients WHERE pid = " & Val(id.Text) & "", con)
            Dim rdr As SqlDataReader = cmd.ExecuteReader

            If Not rdr.HasRows Then
                reset()
                Cursor = Cursors.Default
            End If

            While rdr.Read
                pid.Text = rdr("pid").ToString
                pname.Text = rdr("pname").ToString
                pident.Text = rdr("pident").ToString
                pbdate.Value = rdr("pbdate").ToString
                pbdatehij.Text = rdr("pbdatehij").ToString
                pgender.SelectedItem = rdr("pgender").ToString
                pnat.SelectedItem = rdr("pnat").ToString
                preg.SelectedItem = rdr("preg").ToString
                pmstat.SelectedItem = rdr("pmstat").ToString
                pjob.Text = rdr("pjob").ToString
                pbg.SelectedItem = rdr("pbg").ToString
                paddress.Text = rdr("paddress").ToString
                pwplace.Text = rdr("pwplace").ToString
                poldid.Text = rdr("poldid").ToString
                pphone.Text = rdr("pphone").ToString
                page.Text = rdr("page").ToString
                If rdr("pinscomp").ToString = "بدون" Then
                    CheckBox1.CheckState = CheckState.Unchecked
                Else
                    pinscomp.SelectedItem = rdr("pinscomp").ToString
                    CheckBox1.CheckState = CheckState.Checked
                End If
                pcardid.Text = rdr("pcardid").ToString
                pcardissue.Text = rdr("pcardissue").ToString
                pcardexp.Text = rdr("pcardexp").ToString
                pcardcat.Text = rdr("pcardcat").ToString
                memno.Text = rdr("memno").ToString
                code.Text = rdr("code").ToString
                Dim bytes As [Byte]() = rdr("ppic")
                Dim ms As New MemoryStream(bytes)
                ppic.Image = Image.FromStream(ms)
            End While
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try


        Try
            cmd1 = New SqlCommand("SELECT * FROM images WHERE pid = " & Val(id.Text) & "", con)
            Dim rdr1 As SqlDataReader = cmd1.ExecuteReader

            If Not rdr1.HasRows Then
                data.Rows.Clear()
            End If

            data.Rows.Clear()
            While rdr1.Read
                data.Rows.Add({rdr1("id").ToString, rdr1("imgname").ToString, "", rdr1("imginfo").ToString})
            End While
        Catch ex As Exception

        End Try
        cclose()
    End Sub



    '//////////////////////////////////////////// Form Effect ////////////////////////////////////////////////
    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        If Me.Opacity = 1 Then
            Timer1.Stop()
            Exit Sub
        End If
        Me.Opacity += 0.01
    End Sub

    '//////////////////////////////////////////// Form ControlBox ////////////////////////////////////////////////
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    '//////////////////////////////////////////// Form Load ////////////////////////////////////////////////
    Private Sub Patients_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 140
        changefont(Panel1)

        Try
            copen()
            Dim gt As SqlCommand = New SqlCommand("SELECT sname FROM insurance ORDER BY id", con)
            Dim rdr As SqlDataReader = gt.ExecuteReader
            pinscomp.Items.Clear()
            While rdr.Read
                pinscomp.Items.Add(rdr(0).ToString)
            End While
            rdr.Close()
            cclose()
        Catch ex As Exception

        End Try
        reset()
        pbdatehij.Text = ToHijra(pbdate.Value, "dddd, d MMMM yyyy")
        If pnat.Items.Count = 0 Then
            MsgBox("يُرجى إضافة الجنسيات من قسم الإعدادات أولاً", MsgBoxStyle.Information, "تنبيه")
            Me.Close()
        End If
    End Sub

    '//////////////////////////////////////////// Form Moving ////////////////////////////////////////////////
    Public drag As Boolean
    Public mousex As Integer
    Public mousey As Integer

    Private Sub Panel2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel2.MouseDown
        If Me.WindowState = FormWindowState.Normal Then
            drag = True
            mousex = Windows.Forms.Cursor.Position.X - Me.Left
            mousey = Windows.Forms.Cursor.Position.Y - Me.Top
        End If
    End Sub

    Private Sub Panel2_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel2.MouseMove
        If Me.WindowState = FormWindowState.Normal Then
            If drag Then
                Me.Top = Windows.Forms.Cursor.Position.Y - mousey
                Me.Left = Windows.Forms.Cursor.Position.X - mousex
            End If
        End If
    End Sub

    Private Sub Panel2_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Panel2.MouseUp
        If Me.WindowState = FormWindowState.Normal Then '
            drag = False
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles pbdate.ValueChanged
        pbdatehij.Text = ToHijra(pbdate.Value, "dddd, d MMMM yyyy")
        page.Text = GetAge(pbdate.Value)
    End Sub





    Public Sub reset()
        connect()
        Try
            copen()
            Dim gt As SqlCommand = New SqlCommand("SELECT nat FROM nats ORDER BY id", con)
            Dim rdr As SqlDataReader = gt.ExecuteReader
            pnat.Items.Clear()
            While rdr.Read
                pnat.Items.Add(rdr(0))
            End While
            rdr.Close()
            cclose()
        Catch ex As Exception

        End Try

        clear(GroupBox1)
        clear(GroupBox2)
        clear(GroupBox3)
        pbdatehij.Text = ToHijra(pbdate.Value, "dddd, d MMMM yyyy")
        pname.Focus()

        connect()
        Try
            If con.State = ConnectionState.Closed Then con.Open()
            Dim cmx As New SqlCommand("SELECT pid FROM patients WHERE pid = (SELECT MAX(pid) FROM patients)", con)
            Dim nID As Integer = cmx.ExecuteScalar()
            If nID = 0 Then
                pid.Text = NextID(0)
            Else
                pid.Text = NextID(nID)
            End If
            If con.State = ConnectionState.Open Then con.Close()
        Catch ex As Exception

        End Try
        noru.Text = "n"
    End Sub





    Private Sub pgender_KeyDown(sender As Object, e As KeyEventArgs) Handles preg.KeyDown, pnat.KeyDown, pmstat.KeyDown, pinscomp.KeyDown, pgender.KeyDown, pbg.KeyDown
        If e.KeyCode = Keys.Delete Then
            e.Handled = True
        End If
    End Sub

    Private Sub pgender_KeyPress(sender As Object, e As KeyPressEventArgs) Handles preg.KeyPress, pnat.KeyPress, pmstat.KeyPress, pinscomp.KeyPress, pgender.KeyPress, pbg.KeyPress
        e.Handled = True
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim dialog As New OpenFileDialog()
        dialog.Title = "اختر الملف"
        dialog.Filter = "Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG"
        If dialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'sidentpic.Image = Image.FromFile(dialog.FileName)
            Document.docpath.Text = dialog.FileName
            Document.ShowDialog()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Cursor = Cursors.WaitCursor
        Dim p As New MemoryStream()
        If pname.Text = "" Then
            Cursor = Cursors.Default
            alert("الرجاء إدخال اسم المريض على الأقل", 0)
            Exit Sub
        End If
        If pident.Text = "" Or pident.Text.Length < 10 Then
            Cursor = Cursors.Default
            alert("رقم الهوية غير صحيح", 0)
            Exit Sub
        End If
        If pphone.Text = "" Or pphone.Text.Length < 10 Then
            Cursor = Cursors.Default
            alert("رقم الهاتف غير صحيح", 0)
            Exit Sub
        End If
        connect()
        copen()

        Try
            cmd = New SqlCommand("INSERT INTO patients (pid,pname,pident,pbdate,pbdatehij,pgender,pnat,preg,pmstat,pjob,pbg,paddress,pwplace,poldid,pphone,page,pinscomp,pcardid,pcardissue,pcardexp,pcardcat,pstat,ppic,memno,code) VALUES (@a,@b,@c,@d,@e,@f,@g,@h,@i,@j,@k,@l,@m,@n,@o,@pg,@p,@q,@r,@s,@t,@u,@v,@w,@x)", con)
            With cmd.Parameters

                Dim cmx As New SqlCommand("SELECT COUNT(pid) FROM patients WHERE pid = " & Val(pid.Text) & "", con)
                Dim nID As Integer = cmx.ExecuteScalar()
                If nID = 0 Then
                    pid.Text = pid.Text
                Else
                    pid.Text = Val(pid.Text) + 1
                End If

                .Add(New SqlParameter("@a", pid.Text))
                .Add(New SqlParameter("@b", pname.Text))
                .Add(New SqlParameter("@c", pident.Text))
                .Add(New SqlParameter("@d", pbdate.Value))
                .Add(New SqlParameter("@e", pbdatehij.Text))
                .Add(New SqlParameter("@f", pgender.SelectedItem))
                .Add(New SqlParameter("@g", pnat.SelectedItem))
                .Add(New SqlParameter("@h", preg.SelectedItem))
                .Add(New SqlParameter("@i", pmstat.SelectedItem))
                .Add(New SqlParameter("@j", pjob.Text))
                .Add(New SqlParameter("@k", pbg.SelectedItem))
                .Add(New SqlParameter("@l", paddress.Text))
                .Add(New SqlParameter("@m", pwplace.Text))
                .Add(New SqlParameter("@n", poldid.Text))
                .Add(New SqlParameter("@o", pphone.Text))
                .Add(New SqlParameter("@pg", Val(page.Text)))
                If CheckBox1.CheckState = CheckState.Checked Then
                    .Add(New SqlParameter("@p", pinscomp.SelectedItem))
                    .Add(New SqlParameter("@q", pcardid.Text))
                    .Add(New SqlParameter("@r", pcardissue.Value))
                    .Add(New SqlParameter("@s", pcardexp.Value))
                    .Add(New SqlParameter("@t", pcardcat.Text))
                    .Add(New SqlParameter("@w", memno.Text))
                    .Add(New SqlParameter("@x", code.Text))
                Else
                    .Add(New SqlParameter("@p", "بدون"))
                    .Add(New SqlParameter("@q", "بدون"))
                    .Add(New SqlParameter("@r", ""))
                    .Add(New SqlParameter("@s", ""))
                    .Add(New SqlParameter("@t", "بدون"))
                    .Add(New SqlParameter("@w", "بدون"))
                    .Add(New SqlParameter("@x", "بدون"))
                End If
                .Add(New SqlParameter("@u", "نشط"))
                Dim ps As New Bitmap(ppic.Image)
                ps.Save(p, System.Drawing.Imaging.ImageFormat.Jpeg)
                Dim pdata As Byte() = p.GetBuffer()
                Dim pp As New SqlParameter("@v", SqlDbType.Image)
                pp.Value = pdata
                cmd.Parameters.Add(pp)
                p.Close()
            End With
            cmd.ExecuteNonQuery()

            For Each row As DataGridViewRow In data.Rows
                If Not row.IsNewRow Then
                    If row.Cells(2).Value <> "" Then
                        cmd1 = New SqlCommand("INSERT INTO images (pid,imgname,img,imginfo) VALUES (@a, @b, @c, @d)", con)
                        With cmd1.Parameters
                            .Add(New SqlParameter("@a", pid.Text))
                            .Add(New SqlParameter("@b", row.Cells(1).Value))

                            Dim im As Image = Image.FromFile(row.Cells(2).Value.ToString)
                            Dim ms As New System.IO.MemoryStream
                            im.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp)
                            Dim md As Byte() = ms.GetBuffer
                            Dim p1 As New SqlClient.SqlParameter("@c", SqlDbType.Image)
                            p1.Value = md
                            cmd1.Parameters.Add(p1)
                            .Add(New SqlParameter("@d", row.Cells(3).Value))
                        End With
                        cmd1.ExecuteNonQuery()
                    End If
                End If
            Next


            cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بإضافة مريض جديد بالرقم " & pid.Text & "', '" & nowdate() & "')", con)
            cmdact.ExecuteNonQuery()
            Cursor = Cursors.Default
            alert("تم إدخال بيانات المريض بنجاح", 1)
            reset()
        Catch ex As Exception
            Cursor = Cursors.Default
            If ex.Message.Contains("Cannot insert duplicate key") Then
                MsgBox("رقم الهوية موجود مسبقاً", MsgBoxStyle.Critical, "خطأ")
            End If
        End Try
        cclose()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        reset()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Searchpatient.from.Text = "patients"
        Searchpatient.frmtitle.Text = "بحث عن مريض"
        Searchpatient.ShowDialog()
    End Sub

    Private Sub id_TextChanged(sender As Object, e As EventArgs) Handles id.TextChanged
        fill()
    End Sub

    Private Sub noru_TextChanged(sender As Object, e As EventArgs) Handles noru.TextChanged
        If noru.Text = "n" Then
            Button4.Enabled = True
            Button6.Enabled = False
            Button7.Enabled = False
            Button8.Enabled = False
        ElseIf noru.Text = "u" Then
            Button4.Enabled = False
            Button6.Enabled = True
            Button7.Enabled = True
            Button8.Enabled = True
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Cursor = Cursors.WaitCursor
        Dim p As New MemoryStream()
        If pname.Text = "" Then
            Cursor = Cursors.Default
            alert("الرجاء إدخال اسم المريض على الأقل", 0)
            Exit Sub
        End If
        If pident.Text = "" Or pident.Text.Length < 10 Then
            Cursor = Cursors.Default
            alert("رقم الهوية غير صحيح", 0)
            Exit Sub
        End If
        If pphone.Text = "" Or pphone.Text.Length < 10 Then
            Cursor = Cursors.Default
            alert("رقم الهاتف غير صحيح", 0)
            Exit Sub
        End If
        connect()
        copen()
        Try
            cmd = New SqlCommand("UPDATE patients SET pid=@a,pname=@b,pident=@c,pbdate=@d,pbdatehij=@e,pgender=@f,pnat=@g,preg=@h,pmstat=@i,pjob=@j,pbg=@k,paddress=@l,pwplace=@m,poldid=@n,pphone=@o,page=@pg,pinscomp=@p,pcardid=@q,pcardissue=@r,pcardexp=@s,pcardcat=@t,pstat=@u,ppic=@v,memno=@w,code=@x WHERE pid='" & pid.Text & "'", con)
            With cmd.Parameters
                .Add(New SqlParameter("@a", pid.Text))
                .Add(New SqlParameter("@b", pname.Text))
                .Add(New SqlParameter("@c", pident.Text))
                .Add(New SqlParameter("@d", pbdate.Value))
                .Add(New SqlParameter("@e", pbdatehij.Text))
                .Add(New SqlParameter("@f", pgender.SelectedItem))
                .Add(New SqlParameter("@g", pnat.SelectedItem))
                .Add(New SqlParameter("@h", preg.SelectedItem))
                .Add(New SqlParameter("@i", pmstat.SelectedItem))
                .Add(New SqlParameter("@j", pjob.Text))
                .Add(New SqlParameter("@k", pbg.SelectedItem))
                .Add(New SqlParameter("@l", paddress.Text))
                .Add(New SqlParameter("@m", pwplace.Text))
                .Add(New SqlParameter("@n", poldid.Text))
                .Add(New SqlParameter("@o", pphone.Text))
                .Add(New SqlParameter("@pg", Val(page.Text)))
                If CheckBox1.CheckState = CheckState.Checked Then
                    .Add(New SqlParameter("@p", pinscomp.SelectedItem))
                    .Add(New SqlParameter("@q", pcardid.Text))
                    .Add(New SqlParameter("@r", pcardissue.Value))
                    .Add(New SqlParameter("@s", pcardexp.Value))
                    .Add(New SqlParameter("@t", pcardcat.Text))
                    .Add(New SqlParameter("@w", memno.Text))
                    .Add(New SqlParameter("@x", code.Text))
                Else
                    .Add(New SqlParameter("@p", "بدون"))
                    .Add(New SqlParameter("@q", "بدون"))
                    Dim gt As SqlDateTime
                    gt = SqlDateTime.Null
                    .Add(New SqlParameter("@r", gt))
                    .Add(New SqlParameter("@s", gt))
                    .Add(New SqlParameter("@t", "بدون"))
                    .Add(New SqlParameter("@w", "بدون"))
                    .Add(New SqlParameter("@x", "بدون"))
                End If
                .Add(New SqlParameter("@u", "نشط"))

                Dim ps As New Bitmap(ppic.Image)
                ps.Save(p, System.Drawing.Imaging.ImageFormat.Jpeg)
                Dim pdata As Byte() = p.GetBuffer()
                Dim pp As New SqlParameter("@v", SqlDbType.Image)
                pp.Value = pdata
                cmd.Parameters.Add(pp)
                p.Close()
            End With
            cmd.ExecuteNonQuery()

            For Each row As DataGridViewRow In data.Rows
                If Not row.IsNewRow Then
                    If row.Cells(2).Value <> "" Then
                        cmd1 = New SqlCommand("INSERT INTO images (pid,imgname,img,imginfo) VALUES (@a, @b, @c, @d)", con)
                        With cmd1.Parameters
                            .Add(New SqlParameter("@a", pid.Text))
                            .Add(New SqlParameter("@b", row.Cells(1).Value))


                            Dim im As Image = Image.FromFile(row.Cells(2).Value.ToString)
                            Dim ms As New System.IO.MemoryStream
                            im.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp)
                            Dim md As Byte() = ms.GetBuffer
                            Dim p1 As New SqlClient.SqlParameter("@c", SqlDbType.Image)
                            p1.Value = md
                            cmd1.Parameters.Add(p1)


                            .Add(New SqlParameter("@d", row.Cells(3).Value))
                        End With
                        cmd1.ExecuteNonQuery()
                    End If
                End If
            Next

            cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بتعديل بيانات المريض رقم " & pid.Text & "', '" & nowdate() & "')", con)
            cmdact.ExecuteNonQuery()

            fill()
            Cursor = Cursors.Default
            alert("تم تعديل بيانات المريض بنجاح", 1)
        Catch ex As Exception
            MsgBox(Err.Description)
            Cursor = Cursors.Default
        End Try
        cclose()
    End Sub

    Private Sub data_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles data.CellClick
        If data.RowCount > 0 Then
            If e.ColumnIndex = 5 Then
                Confirm.table.Text = "images"
                Confirm.field.Text = "id"
                Confirm.id.Text = data.CurrentRow.Cells(0).Value
                Confirm.ShowDialog()
            End If

            If e.ColumnIndex = 4 Then
                connect()
                copen()
                Try
                    cmd = New SqlCommand("SELECT img FROM images WHERE id = " & data.CurrentRow.Cells(0).Value & "", con)
                    Dim bytes As [Byte]() = cmd.ExecuteScalar
                    Dim ms As New MemoryStream(bytes)
                    ImageViewer.img.Image = Image.FromStream(ms)
                    ms.Dispose()
                    ImageViewer.frmtitle.Text = "عرض الملف"
                    If ImageViewer.WindowState = FormWindowState.Minimized Then
                        ImageViewer.WindowState = FormWindowState.Normal
                    End If
                    ImageViewer.ShowDialog()
                Catch ex As Exception

                End Try
                cclose()
            End If
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Confirm.table.Text = "patients"
        Confirm.field.Text = "pid"
        Confirm.id.Text = pid.Text
        Confirm.ShowDialog()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.CheckState = CheckState.Checked Then
            pinscomp.Enabled = True
            memno.Enabled = True
            pcardid.Enabled = True
            code.Enabled = True
            pcardissue.Enabled = True
            pcardissue.Value = nowdate()
            pcardexp.Enabled = True
            pcardexp.Value = nowdate()
            pcardcat.Enabled = True
        Else
            Try
                pinscomp.SelectedIndex = 0
            Catch ex As Exception

            End Try
            pinscomp.Enabled = False
            memno.Clear()
            memno.Enabled = False
            pcardid.Clear()
            pcardid.Enabled = False
            code.Clear()
            code.Enabled = False
            pcardissue.Enabled = False
            pcardissue.Value = nowdate()
            pcardexp.Enabled = False
            pcardexp.Value = nowdate()
            pcardcat.Enabled = False
        End If
    End Sub

    Private Sub ppic_Click(sender As Object, e As EventArgs) Handles ppic.Click
        Dim dialog As New OpenFileDialog()
        dialog.Title = "اختر الملف"
        dialog.Filter = "Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG"
        If dialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            ppic.Image = Image.FromFile(dialog.FileName)
        End If
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        ppic.Image = HiTech.My.Resources.profile_pic_png_3
    End Sub

    Private Sub HijriDatePicker1_VisibleChanged(sender As Object, e As EventArgs)

    End Sub
    Private Sub HijriDatePicker1_Load(sender As Object, e As EventArgs)

    End Sub
    Private Sub Button11_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub pgender_SelectedIndexChanged(sender As Object, e As EventArgs) Handles pgender.SelectedIndexChanged
        connect()
        Try
            copen()
            Dim gt As SqlCommand = New SqlCommand("SELECT nat,naten FROM nats ORDER BY id", con)
            Dim rdr As SqlDataReader = gt.ExecuteReader
            pnat.Items.Clear()
            If pgender.SelectedIndex = 0 Then
                While rdr.Read
                    pnat.Items.Add(rdr(0))
                End While
            Else
                While rdr.Read
                    pnat.Items.Add(rdr(1))
                End While
            End If
            pnat.SelectedIndex = 0
            rdr.Close()
            cclose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Cursor = Cursors.WaitCursor
        Patient.pid.Text = pid.Text
        Patient.frmtitle.Text = "بيانات المريض"
        Patient.Show()
        If Patient.WindowState = FormWindowState.Minimized Then
            Patient.WindowState = FormWindowState.Normal
        End If
        Patient.BringToFront()
        Cursor = Cursors.Default
    End Sub

End Class