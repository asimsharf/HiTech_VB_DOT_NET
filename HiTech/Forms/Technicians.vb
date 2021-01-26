Imports System.Drawing.Text
Imports System.Data.SqlClient
Imports System.IO

Public Class Technicians

    Public Sub fill()
        connect()
        copen()
        Try
            cmd = New SqlCommand("SELECT * FROM technicians WHERE tid = " & Val(id.Text) & "", con)
            Dim rdr As SqlDataReader = cmd.ExecuteReader

            If Not rdr.HasRows Then
                reset()
            End If

            While rdr.Read
                tid.Text = rdr("tid").ToString
                tname.Text = rdr("tname").ToString
                dept.Text = rdr("dept").ToString
                tident.Text = rdr("tident").ToString
                tgender.SelectedItem = rdr("tgender").ToString
                tnat.SelectedItem = rdr("tnat").ToString
                treg.SelectedItem = rdr("treg").ToString
                tmstat.SelectedItem = rdr("tmstat").ToString
                tspec.Text = rdr("tspec").ToString
                tphone.Text = rdr("tphone").ToString
                taddress.Text = rdr("taddress").ToString
                uname.Text = rdr("uname").ToString
            End While



            Dim cmdv = New SqlCommand("SELECT id, upass FROM users WHERE uname = '" & uname.Text & "'", con)
            Dim rdrv As SqlDataReader = cmdv.ExecuteReader

            If Not rdrv.HasRows Then
                uname.Clear()
                uid.Clear()
                upass.Clear()
            End If

            While rdrv.Read
                uid.Text = rdrv("id")
                upass.Text = rdrv("upass").ToString
            End While

        Catch ex As Exception

        End Try


        Try
            cmd1 = New SqlCommand("SELECT * FROM technicianimgs WHERE did = " & Val(id.Text) & "", con)
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

        connect()
        Try
            copen()
            Dim gt As New SqlCommand("SELECT * FROM depts", con)
            Dim rdr As SqlDataReader = gt.ExecuteReader
            dept.Items.Clear()
            While rdr.Read
                dept.Items.Add(rdr("dept").ToString)
            End While
            rdr.Close()
            cclose()
        Catch ex As Exception

        End Try

        reset()
        If dept.Items.Count = 0 Then
            MsgBox("يُرجى التأكد من إدخال (الأقسام) أولاً", MsgBoxStyle.Information, "تنبيه")
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





    Public Sub reset()
        connect()
        Try
            If con.State = ConnectionState.Closed Then con.Open()
            Dim gt As SqlCommand = New SqlCommand("SELECT nat FROM nats ORDER BY id", con)
            Dim rdr As SqlDataReader = gt.ExecuteReader
            tnat.Items.Clear()
            While rdr.Read
                tnat.Items.Add(rdr(0))
            End While
            rdr.Close()
            If con.State = ConnectionState.Open Then con.Close()
        Catch ex As Exception

        End Try

        Try
            clear(GroupBox1)
            clear(GroupBox3)
        Catch ex As Exception

        End Try

        connect()
        Try
            If con.State = ConnectionState.Closed Then con.Open()
            Dim cmx As New SqlCommand("SELECT tid FROM technicians WHERE tid = (SELECT MAX(tid) FROM technicians)", con)
            Dim nID As Integer = cmx.ExecuteScalar()
            If nID = 0 Then
                tid.Text = NextID(0)
            Else
                tid.Text = NextID(nID)
            End If
            If con.State = ConnectionState.Open Then con.Close()
        Catch ex As Exception

        End Try

        tname.Focus()
        noru.Text = "n"
    End Sub





    Private Sub pgender_KeyDown(sender As Object, e As KeyEventArgs) Handles treg.KeyDown, tnat.KeyDown, tmstat.KeyDown, tgender.KeyDown, dept.KeyDown
        If e.KeyCode = Keys.Delete Then
            e.Handled = True
        End If
    End Sub

    Private Sub pgender_KeyPress(sender As Object, e As KeyPressEventArgs) Handles treg.KeyPress, tnat.KeyPress, tmstat.KeyPress, tgender.KeyPress, dept.KeyPress
        e.Handled = True
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim dialog As New OpenFileDialog()
        dialog.Title = "اختر الملف"
        dialog.Filter = "Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG"
        If dialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'sidentpic.Image = Image.FromFile(dialog.FileName)
            Documenttec.docpath.Text = dialog.FileName
            Documenttec.ShowDialog()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If tname.Text = "" Then
            alert("الرجاء إدخال اسم الفني على الأقل", 0)
            Exit Sub
        End If
        If tident.Text <> "" And tident.Text.Length < 10 Then
            alert("رقم الهوية غير صحيح", 0)
            Exit Sub
        End If
        If tphone.Text <> "" And tphone.Text.Length < 10 Then
            alert("رقم الهاتف غير صحيح", 0)
            Exit Sub
        End If
        If uname.Text = "" Or upass.Text = "" Then
            alert("اسم المستخدم وكلمة المرور مطلوبة!", 0)
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        connect()
        copen()
        Try
            cmd = New SqlCommand("INSERT INTO technicians (tid, tname,dept,tident,tgender,tnat,treg,tmstat,tspec,taddress,tphone,tstat,uname) VALUES (@a,@b,@c,@e,@f,@g,@h,@i,@j,@k,@l,@m,@n)", con)
            With cmd.Parameters
                .Add(New SqlParameter("@a", tid.Text))
                .Add(New SqlParameter("@b", tname.Text))
                .Add(New SqlParameter("@c", dept.SelectedItem))
                .Add(New SqlParameter("@e", tident.Text))
                .Add(New SqlParameter("@f", tgender.SelectedItem))
                .Add(New SqlParameter("@g", tnat.SelectedItem))
                .Add(New SqlParameter("@h", treg.SelectedItem))
                .Add(New SqlParameter("@i", tmstat.SelectedItem))
                .Add(New SqlParameter("@j", tspec.Text))
                .Add(New SqlParameter("@k", taddress.Text))
                .Add(New SqlParameter("@l", tphone.Text))
                .Add(New SqlParameter("@m", "نشط"))
                .Add(New SqlParameter("@n", uname.Text))
            End With
            cmd.ExecuteNonQuery()

            For Each row As DataGridViewRow In data.Rows
                If Not row.IsNewRow Then
                    If row.Cells(2).Value <> "" Then
                        cmd1 = New SqlCommand("INSERT INTO technicianimgs (did,imgname,img,imginfo) VALUES (@a, @b, @c, @d)", con)
                        With cmd1.Parameters
                            .Add(New SqlParameter("@a", tid.Text))
                            .Add(New SqlParameter("@b", row.Cells(1).Value))

                            Dim im As Image = Image.FromFile(row.Cells(2).Value.ToString)
                            Dim ms As New System.IO.MemoryStream
                            im.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp)
                            Dim md As Byte() = ms.GetBuffer
                            Dim p As New SqlClient.SqlParameter("@c", SqlDbType.Image)
                            p.Value = md
                            cmd1.Parameters.Add(p)

                            .Add(New SqlParameter("@d", row.Cells(3).Value))
                        End With
                        cmd1.ExecuteNonQuery()
                    End If
                End If
            Next

            Dim cmdu As New SqlCommand("INSERT INTO users (uname,upass,ugroup,ustat) VALUES (@a,@b,@c,@d)", con)
            With cmdu.Parameters
                .Add(New SqlParameter("@a", uname.Text))
                .Add(New SqlParameter("@b", upass.Text))
                .Add(New SqlParameter("@c", "Technicians"))
                .Add(New SqlParameter("@d", "Active"))
                cmdu.ExecuteNonQuery()
            End With

            cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بإضافة فني جديد بالرقم " & tid.Text & "', '" & nowdate() & "')", con)
            cmdact.ExecuteNonQuery()
            reset()
            Cursor = Cursors.Default
            alert("تم إدخال بيانات الفني بنجاح", 1)
        Catch ex As Exception
            MsgBox(ex.Message)
            If ex.Message.Contains("Cannot insert duplicate key") Then
                MsgBox("رقم الهوية موجود مسبقاً", MsgBoxStyle.Critical, "خطأ")
            End If

            If ex.Message.Contains("duplicate key") Then
                alert("اسم المستخدم مسجل مسبقاً!", 0)
                Exit Sub
            End If
            Cursor = Cursors.Default
        End Try
        cclose()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        reset()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Searchtechnicians.frmtitle.Text = "بحث عن فني"
        Searchtechnicians.form.Text = "Technicians"
        Searchtechnicians.ShowDialog()
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
        If tname.Text = "" Then
            alert("الرجاء إدخال اسم الفني على الأقل", 0)
            Exit Sub
        End If
        If tident.Text <> "" And tident.Text.Length < 10 Then
            alert("رقم الهوية غير صحيح", 0)
            Exit Sub
        End If
        If tphone.Text <> "" And tphone.Text.Length < 10 Then
            alert("رقم الهاتف غير صحيح", 0)
            Exit Sub
        End If
        If uname.Text = "" Or upass.Text = "" Then
            alert("اسم المستخدم وكلمة المرور مطلوبة!", 0)
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        connect()
        copen()
        Try
            cmd = New SqlCommand("UPDATE technicians SET tid=@a,tname=@b,dept=@c,tident=@e,tgender=@f,tnat=@g,treg=@h,tmstat=@i,tspec=@j,taddress=@k,tphone=@l,tstat=@m,uname=@n WHERE did = " & id.Text & "", con)
            With cmd.Parameters
                .Add(New SqlParameter("@a", tid.Text))
                .Add(New SqlParameter("@b", tname.Text))
                .Add(New SqlParameter("@c", dept.SelectedItem))
                .Add(New SqlParameter("@e", tident.Text))
                .Add(New SqlParameter("@f", tgender.SelectedItem))
                .Add(New SqlParameter("@g", tnat.SelectedItem))
                .Add(New SqlParameter("@h", treg.SelectedItem))
                .Add(New SqlParameter("@i", tmstat.SelectedItem))
                .Add(New SqlParameter("@j", tspec.Text))
                .Add(New SqlParameter("@k", taddress.Text))
                .Add(New SqlParameter("@l", tphone.Text))
                .Add(New SqlParameter("@m", "نشط"))
                .Add(New SqlParameter("@n", uname.Text))
            End With
            cmd.ExecuteNonQuery()

            For Each row As DataGridViewRow In data.Rows
                If Not row.IsNewRow Then
                    If row.Cells(2).Value <> "" Then
                        cmd1 = New SqlCommand("INSERT INTO technicianimgs (did,imgname,img,imginfo) VALUES (@a, @b, @c, @d)", con)
                        With cmd1.Parameters
                            .Add(New SqlParameter("@a", tid.Text))
                            .Add(New SqlParameter("@b", row.Cells(1).Value))


                            Dim im As Image = Image.FromFile(row.Cells(2).Value.ToString)
                            Dim ms As New System.IO.MemoryStream
                            im.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp)
                            Dim md As Byte() = ms.GetBuffer
                            Dim p As New SqlClient.SqlParameter("@c", SqlDbType.Image)
                            p.Value = md
                            cmd1.Parameters.Add(p)


                            .Add(New SqlParameter("@d", row.Cells(3).Value))
                        End With
                        cmd1.ExecuteNonQuery()
                    End If
                End If
            Next

            Dim cmdu As New SqlCommand("UPDATE users SET uname=@a,upass=@b,ugroup=@c,ustat=@d WHERE id = " & uid.Text & "", con)
            With cmdu.Parameters
                .Add(New SqlParameter("@a", uname.Text))
                .Add(New SqlParameter("@b", upass.Text))
                .Add(New SqlParameter("@c", "Technicians"))
                .Add(New SqlParameter("@d", "Active"))
                cmdu.ExecuteNonQuery()
            End With

            cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بتعديل بيانات الفني رقم " & tid.Text & "', '" & nowdate() & "')", con)
            cmdact.ExecuteNonQuery()

            fill()
            Cursor = Cursors.Default
            alert("تم تعديل بيانات الفني بنجاح", 1)
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
        cclose()
    End Sub

    Private Sub data_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles data.CellClick
        If data.RowCount > 0 Then
            If e.ColumnIndex = 5 Then
                Confirm.table.Text = "technicianimgs"
                Confirm.field.Text = "id"
                Confirm.id.Text = data.CurrentRow.Cells(0).Value
                Confirm.ShowDialog()
            End If

            If e.ColumnIndex = 4 Then
                connect()
                copen()
                Try
                    cmd = New SqlCommand("SELECT img FROM technicianimgs WHERE id = " & data.CurrentRow.Cells(0).Value & "", con)
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
        Confirm.table.Text = "technicians"
        Confirm.field.Text = "tid"
        Confirm.id.Text = tid.Text
        Confirm.ShowDialog()
    End Sub

    Private Sub dgender_SelectedIndexChanged(sender As Object, e As EventArgs) Handles tgender.SelectedIndexChanged
        connect()
        Try
            copen()
            Dim gt As SqlCommand = New SqlCommand("SELECT nat,naten FROM nats ORDER BY id", con)
            Dim rdr As SqlDataReader = gt.ExecuteReader
            tnat.Items.Clear()
            If tgender.SelectedIndex = 0 Then
                While rdr.Read
                    tnat.Items.Add(rdr(0))
                End While
            Else
                While rdr.Read
                    tnat.Items.Add(rdr(1))
                End While
            End If
            tnat.SelectedIndex = 0
            rdr.Close()
            cclose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Cursor = Cursors.WaitCursor
        Technician.tid.Text = tid.Text
        Technician.frmtitle.Text = "بيانات الفني"
        Technician.Show()
        If Technician.WindowState = FormWindowState.Minimized Then
            Technician.WindowState = FormWindowState.Normal
        End If
        Technician.BringToFront()
        Cursor = Cursors.Default
    End Sub
End Class