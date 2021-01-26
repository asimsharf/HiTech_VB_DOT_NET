Imports System.Drawing.Text
Imports System.Data.SqlClient
Imports System.IO

Public Class Importers

    Public Sub fill()
        Cursor = Cursors.WaitCursor
        connect()
        copen()
        Try
            cmd = New SqlCommand("SELECT * FROM importers WHERE iid = " & Val(id.Text) & "", con)
            Dim rdr As SqlDataReader = cmd.ExecuteReader

            If Not rdr.HasRows Then
                reset()
            End If

            While rdr.Read
                iid.Text = rdr("iid").ToString
                inamear.Text = rdr("inamear").ToString
                inameen.Text = rdr("inameen").ToString
                ino.Text = rdr("ino").ToString
                phone.Text = rdr("phone").ToString
                fax.Text = rdr("fax").ToString
                email.Text = rdr("email").ToString
                website.Text = rdr("website").ToString
                address.Text = rdr("address").ToString
                empname.Text = rdr("empname").ToString
                empident.Text = rdr("empident").ToString
                empmobile.Text = rdr("empmobile").ToString
                empemail.Text = rdr("empemail").ToString
                empphone.Text = rdr("empphone").ToString
                empfax.Text = rdr("empfax").ToString
                refno.Text = rdr("refno").ToString
                ibal.Text = rdr("ibal")
            End While
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try


        Try
            cmd1 = New SqlCommand("SELECT * FROM impfiles WHERE iid = " & Val(id.Text) & "", con)
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
            Dim cmx As New SqlCommand("SELECT iid FROM importers WHERE iid = (SELECT MAX(iid) FROM importers)", con)
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
            Documentimp.docpath.Text = dialog.FileName
            Documentimp.ext.Text = Path.GetExtension(dialog.FileName)
            Documentimp.ShowDialog()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If inamear.Text = "" Then
            alert("الرجاء إدخال اسم الشركة!", 0)
            Exit Sub
        End If
        If empname.Text = "" Then
            alert("الرجاء ادخال إسم المندوب", 0)
            Exit Sub
        End If
        If empident.Text <> "" And empident.Text.Length < 10 Then
            Cursor = Cursors.Default
            alert("رقم الهوية غير صحيح", 0)
            Exit Sub
        End If
        If phone.Text <> "" And phone.Text.Length < 10 Then
            Cursor = Cursors.Default
            alert("رقم هاتف الشركة غير صحيح", 0)
            Exit Sub
        End If
        If empmobile.Text <> "" And empmobile.Text.Length < 10 Then
            Cursor = Cursors.Default
            alert("رقم الجوال غير صحيح", 0)
            Exit Sub
        End If
        If empphone.Text <> "" And empphone.Text.Length < 10 Then
            Cursor = Cursors.Default
            alert("رقم هاتف المندوب غير صحيح", 0)
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        connect()
        copen()
        Try
            cmd = New SqlCommand("INSERT INTO importers (iid, inamear, inameen, ino, phone, fax, email, website, address, empname, empident, empmobile, empemail, empphone, empfax, istat, refno, ibal) VALUES (@a,@b,@c,@d,@e,@f,@g,@h,@i,@j,@k,@l,@m,@n,@o,@p,@q,@r)", con)
            With cmd.Parameters
                .Add(New SqlParameter("@a", iid.Text))
                .Add(New SqlParameter("@b", inamear.Text))
                .Add(New SqlParameter("@c", inameen.Text))
                .Add(New SqlParameter("@d", ino.Text))
                .Add(New SqlParameter("@e", phone.Text))
                .Add(New SqlParameter("@f", fax.Text))
                .Add(New SqlParameter("@g", email.Text))
                .Add(New SqlParameter("@h", website.Text))
                .Add(New SqlParameter("@i", address.Text))
                .Add(New SqlParameter("@j", empname.Text))
                .Add(New SqlParameter("@k", empident.Text))
                .Add(New SqlParameter("@l", empmobile.Text))
                .Add(New SqlParameter("@m", empemail.Text))
                .Add(New SqlParameter("@n", empphone.Text))
                .Add(New SqlParameter("@o", empfax.Text))
                .Add(New SqlParameter("@p", ""))
                .Add(New SqlParameter("@q", refno.Text))
                .Add(New SqlParameter("@r", 0))
            End With
            cmd.ExecuteNonQuery()

            For Each row As DataGridViewRow In data.Rows
                If Not row.IsNewRow Then
                    If row.Cells(2).Value <> "" Then

                        cmd1 = New SqlCommand("INSERT INTO impfiles (iid,filename,[file],fileinfo,fileext) VALUES (@a, @b, @c, @d, @e)", con)
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

            cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بإضافة مورد جديد بالرقم " & iid.Text & "', '" & nowdate() & "')", con)
            cmdact.ExecuteNonQuery()
            reset()
            Cursor = Cursors.Default
            alert("تم إدخال بيانات المورد بنجاح", 1)
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
        cclose()
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        reset()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Searchimporter.frmtitle.Text = "بحث عن مورد"
        Searchimporter.form.Text = "Importers"
        Searchimporter.ShowDialog()
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
        If inamear.Text = "" Then
            alert("الرجاء إدخال اسم الشركة!", 0)
            Exit Sub
        End If
        If empname.Text = "" Then
            alert("الرجاء ادخال إسم المندوب", 0)
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        connect()
        copen()
        Try
            cmd = New SqlCommand("UPDATE importers SET inamear=@b, inameen=@c, ino=@d, phone=@e, fax=@f, email=@g, website=@h, address=@i, empname=@j, empident=@k, empmobile=@l, empemail=@m, empphone=@n, empfax=@o, refno=@p WHERE id = " & id.Text & "", con)
            With cmd.Parameters
                .Add(New SqlParameter("@b", inamear.Text))
                .Add(New SqlParameter("@c", inameen.Text))
                .Add(New SqlParameter("@d", ino.Text))
                .Add(New SqlParameter("@e", phone.Text))
                .Add(New SqlParameter("@f", fax.Text))
                .Add(New SqlParameter("@g", email.Text))
                .Add(New SqlParameter("@h", website.Text))
                .Add(New SqlParameter("@i", address.Text))
                .Add(New SqlParameter("@j", empname.Text))
                .Add(New SqlParameter("@k", empident.Text))
                .Add(New SqlParameter("@l", empmobile.Text))
                .Add(New SqlParameter("@m", empemail.Text))
                .Add(New SqlParameter("@n", empphone.Text))
                .Add(New SqlParameter("@o", empfax.Text))
                .Add(New SqlParameter("@p", refno.Text))
            End With
            cmd.ExecuteNonQuery()

            For Each row As DataGridViewRow In data.Rows
                If Not row.IsNewRow Then
                    If row.Cells(2).Value <> "" Then
                        cmd1 = New SqlCommand("INSERT INTO impfiles (iid,filename,[file],fileinfo,fileext) VALUES (@a, @b, @c, @d, @e)", con)
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

            cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بتعديل بيانات المورد رقم " & iid.Text & "', '" & nowdate() & "')", con)
            cmdact.ExecuteNonQuery()

            fill()
            Cursor = Cursors.Default
            alert("تم تعديل بيانات المورد بنجاح", 1)
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
        cclose()
    End Sub

    Private Sub data_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles data.CellClick
        If data.RowCount > 0 Then
            If e.ColumnIndex = 6 Then
                If data.CurrentRow.Cells(2).Value.ToString = "" Then
                    Confirm.table.Text = "impfiles"
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

                    cmd = New SqlCommand("SELECT [file],filename,fileext FROM impfiles WHERE id = " & data.CurrentRow.Cells(0).Value & "", con)
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
        Confirm.table.Text = "importers"
        Confirm.field.Text = "iid"
        Confirm.id.Text = iid.Text
        Confirm.ShowDialog()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        ImpPays.frmtitle.Text = "بيانات الدفع"
        ImpPays.iid.Text = iid.Text
        If ImpPays.WindowState = FormWindowState.Minimized Then
            ImpPays.WindowState = FormWindowState.Normal
        End If
        ImpPays.ShowDialog()
    End Sub

End Class