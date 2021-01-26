Imports System.Drawing.Text
Imports System.Data.SqlClient
Imports System.IO

Public Class Doctors

    Public Sub fill()
        connect()
        copen()
        Try
            cmd = New SqlCommand("SELECT * FROM doctors WHERE did = " & Val(id.Text) & "", con)
            Dim rdr As SqlDataReader = cmd.ExecuteReader

            If Not rdr.HasRows Then
                reset()
            End If

            While rdr.Read
                did.Text = rdr("did").ToString
                dname.Text = rdr("dname").ToString
                dept.Text = rdr("dept").ToString
                clinic.Text = rdr("clinic").ToString
                dident.Text = rdr("dident").ToString
                dgender.SelectedItem = rdr("dgender").ToString
                dnat.SelectedItem = rdr("dnat").ToString
                dreg.SelectedItem = rdr("dreg").ToString
                dmstat.SelectedItem = rdr("dmstat").ToString
                dspec.Text = rdr("dspec").ToString
                dphone.Text = rdr("dphone").ToString
                daddress.Text = rdr("daddress").ToString
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
            cmd1 = New SqlCommand("SELECT * FROM doctorimgs WHERE did = " & Val(id.Text) & "", con)
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

        connect()
        Try
            copen()
            Dim gt As New SqlCommand("SELECT * FROM clinics", con)
            Dim rdr As SqlDataReader = gt.ExecuteReader
            clinic.Items.Clear()
            While rdr.Read
                clinic.Items.Add(rdr("cname").ToString)
            End While
            rdr.Close()
            cclose()
        Catch ex As Exception

        End Try

        reset()
        If dept.Items.Count = 0 Or clinic.Items.Count = 0 Or dnat.Items.Count = 0 Then
            MsgBox("يُرجى التأكد من إدخال (الأقسام، العيادات، الجنسيات) أولاً", MsgBoxStyle.Information, "تنبيه")
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
            dnat.Items.Clear()
            While rdr.Read
                dnat.Items.Add(rdr(0))
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
            Dim cmx As New SqlCommand("SELECT did FROM doctors WHERE did = (SELECT MAX(did) FROM doctors)", con)
            Dim nID As Integer = cmx.ExecuteScalar()
            If nID = 0 Then
                did.Text = NextID(0)
            Else
                did.Text = NextID(nID)
            End If
            If con.State = ConnectionState.Open Then con.Close()
        Catch ex As Exception

        End Try

        dname.Focus()
        noru.Text = "n"
    End Sub





    Private Sub pgender_KeyDown(sender As Object, e As KeyEventArgs) Handles dreg.KeyDown, dnat.KeyDown, dmstat.KeyDown, dgender.KeyDown, dept.KeyDown, clinic.KeyDown
        If e.KeyCode = Keys.Delete Then
            e.Handled = True
        End If
    End Sub

    Private Sub pgender_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dreg.KeyPress, dnat.KeyPress, dmstat.KeyPress, dgender.KeyPress, dept.KeyPress, clinic.KeyPress
        e.Handled = True
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim dialog As New OpenFileDialog()
        dialog.Title = "اختر الملف"
        dialog.Filter = "Files(*.BMP;*.JPG;*.GIF;*.PNG)|*.BMP;*.JPG;*.GIF;*.PNG"
        If dialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'sidentpic.Image = Image.FromFile(dialog.FileName)
            Documentdoc.docpath.Text = dialog.FileName
            Documentdoc.ShowDialog()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If dname.Text = "" Then
            alert("الرجاء إدخال اسم الطبيب على الأقل", 0)
            Exit Sub
        End If
        If dident.Text <> "" And dident.Text.Length < 10 Then
            alert("رقم الهوية غير صحيح", 0)
            Exit Sub
        End If
        If dphone.Text <> "" And dphone.Text.Length < 10 Then
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
            cmd = New SqlCommand("INSERT INTO doctors (did, dname,dept,clinic,dident,dgender,dnat,dreg,dmstat,dspec,daddress,dphone,dstat,uname) VALUES (@a,@b,@c,@d,@e,@f,@g,@h,@i,@j,@k,@l,@m,@n)", con)
            With cmd.Parameters
                .Add(New SqlParameter("@a", did.Text))
                .Add(New SqlParameter("@b", dname.Text))
                .Add(New SqlParameter("@c", dept.SelectedItem))
                .Add(New SqlParameter("@d", clinic.Text))
                .Add(New SqlParameter("@e", dident.Text))
                .Add(New SqlParameter("@f", dgender.SelectedItem))
                .Add(New SqlParameter("@g", dnat.SelectedItem))
                .Add(New SqlParameter("@h", dreg.SelectedItem))
                .Add(New SqlParameter("@i", dmstat.SelectedItem))
                .Add(New SqlParameter("@j", dspec.Text))
                .Add(New SqlParameter("@k", daddress.Text))
                .Add(New SqlParameter("@l", dphone.Text))
                .Add(New SqlParameter("@m", "نشط"))
                .Add(New SqlParameter("@n", uname.Text))
            End With
            cmd.ExecuteNonQuery()

            For Each row As DataGridViewRow In data.Rows
                If Not row.IsNewRow Then
                    If row.Cells(2).Value <> "" Then
                        cmd1 = New SqlCommand("INSERT INTO doctorimgs (did,imgname,img,imginfo) VALUES (@a, @b, @c, @d)", con)
                        With cmd1.Parameters
                            .Add(New SqlParameter("@a", did.Text))
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
                .Add(New SqlParameter("@c", "Doctors"))
                .Add(New SqlParameter("@d", "Active"))
                cmdu.ExecuteNonQuery()
            End With

            cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بإضافة طبيب جديد بالرقم " & did.Text & "', '" & nowdate() & "')", con)
            cmdact.ExecuteNonQuery()
            reset()
            Cursor = Cursors.Default
            alert("تم إدخال بيانات الطبيب بنجاح", 1)
        Catch ex As Exception
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
        Searchdoctor.frmtitle.Text = "بحث عن طبيب"
        Searchdoctor.form.Text = "Doctors"
        Searchdoctor.ShowDialog()
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
        If dname.Text = "" Then
            alert("الرجاء إدخال اسم الطبيب على الأقل", 0)
            Exit Sub
        End If
        If dident.Text <> "" And dident.Text.Length < 10 Then
            alert("رقم الهوية غير صحيح", 0)
            Exit Sub
        End If
        If dphone.Text <> "" And dphone.Text.Length < 10 Then
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
            cmd = New SqlCommand("UPDATE doctors SET did=@a,dname=@b,dept=@c,clinic=@d,dident=@e,dgender=@f,dnat=@g,dreg=@h,dmstat=@i,dspec=@j,daddress=@k,dphone=@l,dstat=@m,uname=@n WHERE did = " & id.Text & "", con)
            With cmd.Parameters
                .Add(New SqlParameter("@a", did.Text))
                .Add(New SqlParameter("@b", dname.Text))
                .Add(New SqlParameter("@c", dept.SelectedItem))
                .Add(New SqlParameter("@d", clinic.Text))
                .Add(New SqlParameter("@e", dident.Text))
                .Add(New SqlParameter("@f", dgender.SelectedItem))
                .Add(New SqlParameter("@g", dnat.SelectedItem))
                .Add(New SqlParameter("@h", dreg.SelectedItem))
                .Add(New SqlParameter("@i", dmstat.SelectedItem))
                .Add(New SqlParameter("@j", dspec.Text))
                .Add(New SqlParameter("@k", daddress.Text))
                .Add(New SqlParameter("@l", dphone.Text))
                .Add(New SqlParameter("@m", "نشط"))
                .Add(New SqlParameter("@n", uname.Text))
            End With
            cmd.ExecuteNonQuery()

            For Each row As DataGridViewRow In data.Rows
                If Not row.IsNewRow Then
                    If row.Cells(2).Value <> "" Then
                        cmd1 = New SqlCommand("INSERT INTO doctorimgs (did,imgname,img,imginfo) VALUES (@a, @b, @c, @d)", con)
                        With cmd1.Parameters
                            .Add(New SqlParameter("@a", did.Text))
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
                .Add(New SqlParameter("@c", "Doctors"))
                .Add(New SqlParameter("@d", "Active"))
                cmdu.ExecuteNonQuery()
            End With

            cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بتعديل بيانات الطبيب رقم " & did.Text & "', '" & nowdate() & "')", con)
            cmdact.ExecuteNonQuery()

            fill()
            Cursor = Cursors.Default
            alert("تم تعديل بيانات الطبيب بنجاح", 1)
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
        cclose()
    End Sub

    Private Sub data_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles data.CellClick
        If data.RowCount > 0 Then
            If e.ColumnIndex = 5 Then
                Confirm.table.Text = "doctorimgs"
                Confirm.field.Text = "id"
                Confirm.id.Text = data.CurrentRow.Cells(0).Value
                Confirm.ShowDialog()
            End If

            If e.ColumnIndex = 4 Then
                connect()
                copen()
                Try
                    cmd = New SqlCommand("SELECT img FROM doctorimgs WHERE id = " & data.CurrentRow.Cells(0).Value & "", con)
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
        Confirm.table.Text = "doctors"
        Confirm.field.Text = "did"
        Confirm.id.Text = did.Text
        Confirm.ShowDialog()
    End Sub

    Private Sub dgender_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dgender.SelectedIndexChanged
        connect()
        Try
            copen()
            Dim gt As SqlCommand = New SqlCommand("SELECT nat,naten FROM nats ORDER BY id", con)
            Dim rdr As SqlDataReader = gt.ExecuteReader
            dnat.Items.Clear()
            If dgender.SelectedIndex = 0 Then
                While rdr.Read
                    dnat.Items.Add(rdr(0))
                End While
            Else
                While rdr.Read
                    dnat.Items.Add(rdr(1))
                End While
            End If
            dnat.SelectedIndex = 0
            rdr.Close()
            cclose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Cursor = Cursors.WaitCursor
        Doctor.did.Text = did.Text
        Doctor.frmtitle.Text = "بيانات الطبيب"
        Doctor.Show()
        If Doctor.WindowState = FormWindowState.Minimized Then
            Doctor.WindowState = FormWindowState.Normal
        End If
        Doctor.BringToFront()
        Cursor = Cursors.Default
    End Sub
End Class