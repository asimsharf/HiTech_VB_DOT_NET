Imports System.Drawing.Text
Imports System.Data.SqlClient
Imports System.IO

Public Class Insurance

    Public Sub fill()
        Cursor = Cursors.WaitCursor
        connect()
        copen()
        Try
            cmd = New SqlCommand("SELECT * FROM insurance WHERE iid = " & Val(id.Text) & "", con)
            Dim rdr As SqlDataReader = cmd.ExecuteReader

            If Not rdr.HasRows Then
                reset()
            End If

            While rdr.Read
                iid.Text = rdr("iid").ToString
                inamear.Text = rdr("inamear").ToString
                inameen.Text = rdr("inameen").ToString
                sname.Text = rdr("sname").ToString
                regno.Text = rdr("regno").ToString
                mregno.Text = rdr("mregno").ToString
                tregno.Text = rdr("tregno").ToString
                contdate.Value = rdr("contdate").ToString
                contexp.Value = rdr("contexp").ToString
                phone.Text = rdr("phone").ToString
                fax.Text = rdr("fax").ToString
                address.Text = rdr("address").ToString
                email.Text = rdr("email").ToString
                empname.Text = rdr("empname").ToString
                job.Text = rdr("job").ToString
                empmobile.Text = rdr("empmobile").ToString
                empemail.Text = rdr("empemail").ToString
                empphone.Text = rdr("empphone").ToString
                empfax.Text = rdr("empfax").ToString
            End While
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try


        Try
            cmd1 = New SqlCommand("SELECT * FROM insurfiles WHERE iid = " & Val(id.Text) & "", con)
            Dim rdr1 As SqlDataReader = cmd1.ExecuteReader

            If Not rdr1.HasRows Then
                data.Rows.Clear()
            End If

            data.Rows.Clear()
            While rdr1.Read
                data.Rows.Add({rdr1("id").ToString, rdr1("filename").ToString, "", rdr1("fileinfo").ToString, rdr1("fileext").ToString})
            End While
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
        Cursor = Cursors.Default
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
        reset()
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
        Try
            clear(GroupBox1)
            clear(GroupBox2)
            clear(GroupBox3)
        Catch ex As Exception

        End Try

        connect()
        Try
            If con.State = ConnectionState.Closed Then con.Open()
            Dim cmx As New SqlCommand("SELECT iid FROM insurance WHERE iid = (SELECT MAX(iid) FROM insurance)", con)
            Dim nID As Integer = cmx.ExecuteScalar()
            If nID = 0 Then
                iid.Text = NextID(0)
            Else
                iid.Text = NextID(nID)
            End If
            If con.State = ConnectionState.Open Then con.Close()
        Catch ex As Exception

        End Try

        inamear.Focus()
        noru.Text = "n"
    End Sub


    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Dim dialog As New OpenFileDialog()
        dialog.Title = "اختر الملف"
        dialog.Filter = "Files(*.pdf)|*.PDF"
        If dialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            'sidentpic.Image = Image.FromFile(dialog.FileName)
            Documentinsur.docpath.Text = dialog.FileName
            Documentinsur.ext.Text = Path.GetExtension(dialog.FileName)
            Documentinsur.ShowDialog()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If inamear.Text = "" Then
            alert("الرجاء إدخال اسم الشركة!", 0)
            Exit Sub
        End If
        If sname.Text = "" Then
            alert("الرجاء ادخال الإسم المختصر", 0)
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        connect()
        copen()
        Try
            cmd = New SqlCommand("INSERT INTO insurance (iid, inamear, inameen, sname, regno, mregno, tregno, contdate, contexp, phone, fax, address, email, empname, job, empmobile, empemail, empphone, empfax, istat) VALUES (@a,@b,@c,@d,@e,@f,@g,@h,@i,@j,@k,@l,@m,@n,@o,@p,@q,@r,@s,@t)", con)
            With cmd.Parameters
                .Add(New SqlParameter("@a", iid.Text))
                .Add(New SqlParameter("@b", inamear.Text))
                .Add(New SqlParameter("@c", inameen.Text))
                .Add(New SqlParameter("@d", sname.Text))
                .Add(New SqlParameter("@e", regno.Text))
                .Add(New SqlParameter("@f", mregno.Text))
                .Add(New SqlParameter("@g", tregno.Text))
                .Add(New SqlParameter("@h", contdate.Value))
                .Add(New SqlParameter("@i", contexp.Value))
                .Add(New SqlParameter("@j", phone.Text))
                .Add(New SqlParameter("@k", fax.Text))
                .Add(New SqlParameter("@l", address.Text))
                .Add(New SqlParameter("@m", email.Text))
                .Add(New SqlParameter("@n", empname.Text))
                .Add(New SqlParameter("@o", job.Text))
                .Add(New SqlParameter("@p", empmobile.Text))
                .Add(New SqlParameter("@q", empemail.Text))
                .Add(New SqlParameter("@r", empphone.Text))
                .Add(New SqlParameter("@s", empfax.Text))
                .Add(New SqlParameter("@t", "نشط"))
            End With
            cmd.ExecuteNonQuery()

            For Each row As DataGridViewRow In data.Rows
                If Not row.IsNewRow Then
                    If row.Cells(2).Value <> "" Then

                        cmd1 = New SqlCommand("INSERT INTO insurfiles (iid,filename,[file],fileinfo,fileext) VALUES (@a, @b, @c, @d, @e)", con)
                        With cmd1.Parameters
                            .Add(New SqlParameter("@a", iid.Text))
                            .Add(New SqlParameter("@b", row.Cells(1).Value))

                            Dim fs As FileStream
                            fs = New FileStream(row.Cells(2).Value.ToString, FileMode.Open, FileAccess.Read)
                            Dim docByte As Byte() = New Byte(fs.Length - 1) {}
                            fs.Read(docByte, 0, System.Convert.ToInt32(fs.Length))
                            fs.Close()
                            Dim docfile As New SqlParameter
                            docfile.SqlDbType = SqlDbType.Binary
                            docfile.ParameterName = "c"
                            docfile.Value = docByte
                            cmd1.Parameters.Add(docfile)

                            .Add(New SqlParameter("@d", row.Cells(3).Value))
                            .Add(New SqlParameter("@e", row.Cells(4).Value))
                        End With
                        cmd1.ExecuteNonQuery()
                    End If
                End If
            Next

            cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بإضافة شركة تأمين جديدة بالرقم " & iid.Text & "', '" & nowdate() & "')", con)
            cmdact.ExecuteNonQuery()
            reset()
            Cursor = Cursors.Default
            alert("تم إدخال بيانات شركة التأمين بنجاح", 1)
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
        cclose()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        reset()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Searchinsurance.frmtitle.Text = "بحث عن شركة تأمين"
        Searchinsurance.form.Text = "Insurance"
        Searchinsurance.ShowDialog()
    End Sub

    Private Sub id_TextChanged(sender As Object, e As EventArgs) Handles id.TextChanged
        fill()
    End Sub

    Private Sub noru_TextChanged(sender As Object, e As EventArgs) Handles noru.TextChanged
        If noru.Text = "n" Then
            Button4.Enabled = True
            Button6.Enabled = False
            Button7.Enabled = False
        ElseIf noru.Text = "u" Then
            Button4.Enabled = False
            Button6.Enabled = True
            Button7.Enabled = True
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If inamear.Text = "" Then
            alert("الرجاء إدخال اسم الشركة!", 0)
            Exit Sub
        End If
        If sname.Text = "" Then
            alert("الرجاء ادخال الإسم المختصر", 0)
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        connect()
        copen()
        Try
            cmd = New SqlCommand("UPDATE insurance SET iid=@a, inamear=@b, inameen=@c, sname=@d, regno=@e, mregno=@f, tregno=@g, contdate=@h, contexp=@i, phone=@j, fax=@k, address=@l, email=@m, empname=@n, job=@o, empmobile=@p, empemail=@q, empphone=@r, empfax=@s, istat=@t WHERE id = " & id.Text & "", con)
            With cmd.Parameters
                .Add(New SqlParameter("@a", iid.Text))
                .Add(New SqlParameter("@b", inamear.Text))
                .Add(New SqlParameter("@c", inameen.Text))
                .Add(New SqlParameter("@d", sname.Text))
                .Add(New SqlParameter("@e", regno.Text))
                .Add(New SqlParameter("@f", mregno.Text))
                .Add(New SqlParameter("@g", tregno.Text))
                .Add(New SqlParameter("@h", contdate.Value))
                .Add(New SqlParameter("@i", contexp.Value))
                .Add(New SqlParameter("@j", phone.Text))
                .Add(New SqlParameter("@k", fax.Text))
                .Add(New SqlParameter("@l", address.Text))
                .Add(New SqlParameter("@m", email.Text))
                .Add(New SqlParameter("@n", empname.Text))
                .Add(New SqlParameter("@o", job.Text))
                .Add(New SqlParameter("@p", empmobile.Text))
                .Add(New SqlParameter("@q", empemail.Text))
                .Add(New SqlParameter("@r", empphone.Text))
                .Add(New SqlParameter("@s", empfax.Text))
                .Add(New SqlParameter("@t", "نشط"))
            End With
            cmd.ExecuteNonQuery()

            For Each row As DataGridViewRow In data.Rows
                If Not row.IsNewRow Then
                    If row.Cells(2).Value <> "" Then
                        cmd1 = New SqlCommand("INSERT INTO insurfiles (iid,filename,[file],fileinfo,fileext) VALUES (@a, @b, @c, @d, @e)", con)
                        With cmd1.Parameters
                            .Add(New SqlParameter("@a", iid.Text))
                            .Add(New SqlParameter("@b", row.Cells(1).Value))


                            Dim fs As FileStream
                            fs = New FileStream(row.Cells(2).Value.ToString, FileMode.Open, FileAccess.Read)
                            Dim docByte As Byte() = New Byte(fs.Length - 1) {}
                            fs.Read(docByte, 0, System.Convert.ToInt32(fs.Length))
                            fs.Close()
                            Dim docfile As New SqlParameter
                            docfile.SqlDbType = SqlDbType.Binary
                            docfile.ParameterName = "c"
                            docfile.Value = docByte
                            cmd1.Parameters.Add(docfile)


                            .Add(New SqlParameter("@d", row.Cells(3).Value))
                            .Add(New SqlParameter("@e", row.Cells(4).Value))
                        End With
                        cmd1.ExecuteNonQuery()
                    End If
                End If
            Next

            cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بتعديل بيانات شركة التأمين رقم " & iid.Text & "', '" & nowdate() & "')", con)
            cmdact.ExecuteNonQuery()

            fill()
            Cursor = Cursors.Default
            alert("تم تعديل بيانات شركة التأمين بنجاح", 1)
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
        cclose()
    End Sub

    Private Sub data_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles data.CellClick
        If data.RowCount > 0 Then
            If e.ColumnIndex = 6 Then
                If data.CurrentRow.Cells(2).Value.ToString = "" Then
                    Confirm.table.Text = "insurfiles"
                    Confirm.field.Text = "id"
                    Confirm.id.Text = data.CurrentRow.Cells(0).Value
                    Confirm.ShowDialog()
                Else
                    data.Rows.Remove(data.Rows(data.CurrentRow.Index))
                End If
            End If

            If e.ColumnIndex = 5 Then
                connect()
                copen()
                Try

                    cmd = New SqlCommand("SELECT [file],filename,fileext FROM insurfiles WHERE id = " & data.CurrentRow.Cells(0).Value & "", con)
                    Dim rdr As SqlDataReader = cmd.ExecuteReader
                    Dim buffer() As Byte
                    While rdr.Read
                        buffer = CType(rdr(0), Byte())
                        Dim fs As FileStream = New FileStream("C:\" & rdr(1).ToString & rdr(2).ToString & "", FileMode.Create)
                        fs.Write(buffer, 0, buffer.Length)
                        fs.Close()

                        Pdfreader.frmtitle.Text = "عرض الملف"
                        If Pdfreader.WindowState = FormWindowState.Minimized Then
                            Pdfreader.WindowState = FormWindowState.Normal
                        End If
                        Pdfreader.Show()
                        Pdfreader.BringToFront()
                        Pdfreader.pdf.src = fs.Name 
                    End While

                Catch ex As Exception

                End Try
                cclose()
            End If
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Confirm.table.Text = "insurance"
        Confirm.field.Text = "iid"
        Confirm.id.Text = iid.Text
        Confirm.ShowDialog()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs)

    End Sub
End Class