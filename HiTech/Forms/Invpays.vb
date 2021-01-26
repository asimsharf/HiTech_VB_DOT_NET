Imports System.Drawing.Text
Imports System.Data.SqlClient

Public Class Invpays
    Public Sub fillinvdata()
        Cursor = Cursors.WaitCursor
        connect()
        copen()
        Try
            cmd = New SqlCommand("SELECT id,cash,net,pdate,[user] FROM invpays WHERE invno = " & invs.CurrentRow.Cells(0).Value & "", con)
            Dim rdr As SqlDataReader = cmd.ExecuteReader
            inps.Rows.Clear()
            While rdr.Read
                inps.Rows.Add({rdr("id"), rdr("cash"), rdr("net"), rdr("pdate"), rdr("user")})
            End While
            rdr.Close()
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try

        Try
            cmd1 = New SqlCommand("SELECT invno, chdate, total, doctor, invstat FROM [check] WHERE invno = " & invs.CurrentRow.Cells(0).Value & "", con)
            Dim rdr1 As SqlDataReader = cmd1.ExecuteReader
            While rdr1.Read
                invno.Text = rdr1("invno")
                invdate.Text = CDate(rdr1("chdate")).ToString("yyyy-MM-dd")
                invvalue.Text = rdr1("total")
                doctor.Text = rdr1("doctor")
                invstat.Text = rdr1("invstat")
            End While
            rdr1.Close()
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try

        Try
            Dim cmt As New SqlCommand("SELECT SUM(stax) FROM checkdetails WHERE invno = " & invs.CurrentRow.Cells(0).Value & "", con)
            tax.Text = cmt.ExecuteScalar
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try

        Try
            Dim cmd2 = New SqlCommand("SELECT ISNULL(SUM(cash) + SUM(net), 0) FROM invpays WHERE pid = " & pid.Text & " AND invno = " & invs.CurrentRow.Cells(0).Value & "", con)
            allpaid.Text = cmd2.ExecuteScalar
            allremain.Text = Val(invvalue.Text) - Val(allpaid.Text)
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
        clear(GroupBox3)
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
    Private Sub Clinics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 140
        changefont(Panel1)
        ptype.SelectedIndex = 0
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

    Private Sub serch_Click(sender As Object, e As EventArgs) Handles serch.Click
        Searchpatient.from.Text = "invpays"
        Searchpatient.frmtitle.Text = "بحث عن مريض"
        Searchpatient.ShowDialog()
    End Sub

    Private Sub pid_TextChanged(sender As Object, e As EventArgs) Handles pid.TextChanged
        connect()
        copen()
        Try
            cmd = New SqlCommand("SELECT pid,pname,pgender,pnat FROM patients WHERE pid = " & pid.Text & "", con)
            Dim rdr As SqlDataReader = cmd.ExecuteReader
            If Not rdr.HasRows Then
                clear(GroupBox4)
                clear(GroupBox1)
                clear(GroupBox3)
                clear(GroupBox2)
                Cursor = Cursors.Default
            End If
            While rdr.Read
                hpid.Text = rdr("pid")
                pname.Text = rdr("pname").ToString
                pgender.Text = rdr("pgender").ToString
                pnat.Text = rdr("pnat").ToString
            End While
            rdr.Close()

            cmd1 = New SqlCommand("SELECT invno,chdate FROM [check] WHERE pid = " & pid.Text & " ORDER BY chdate DESC", con)
            Dim rdr1 As SqlDataReader = cmd1.ExecuteReader
            invs.Rows.Clear()
            While rdr1.Read
                invs.Rows.Add({rdr1("invno"), rdr1("chdate")})
            End While
            rdr1.Close()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
        cclose()
    End Sub

    Private Sub invs_SelectionChanged(sender As Object, e As EventArgs) Handles invs.SelectionChanged
        fillinvdata()
    End Sub

    Private Sub ptype_KeyDown(sender As Object, e As KeyEventArgs) Handles ptype.KeyDown
        If e.KeyCode = Keys.Delete Then
            e.Handled = True
        End If
    End Sub

    Private Sub ptype_KeyPress(sender As Object, e As KeyPressEventArgs) Handles ptype.KeyPress
        e.Handled = True
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If hpid.Text = "" Then
            alert("رقم الملف غير موجود!", 0)
            Exit Sub
        End If
        If invs.RowCount = 0 Then
            alert("لا توجد فواتير لهذا المريض!", 0)
            Exit Sub
        End If
        If Val(paid.Text) = 0 Then
            alert("الرجاء كتابة القيمة المراد تسديدها بصورة صحيحة!", 0)
            Exit Sub
        End If
        If Val(paid.Text) > Val(allremain.Text) Then
            alert("القيمة المسددة أكبر من المبلغ المتبقي!", 0)
            Exit Sub
        End If
        If invstat.Text = "مفتوحة" Then
            alert("لا يمكن تنفيذ العملية، الفاتورة مفتوحة، الرجاء اغلاق الفاتورة أولاً!", 0)
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        connect()
        copen()
        Try
            Dim cmdx As SqlCommand = New SqlCommand("INSERT INTO invpays (pid,pname,invno,cash,net,pdate,[user],doctor,tax) VALUES (@a,@b,@c,@d,@e,@f,@g,@h,@i)", con)
            With cmdx.Parameters
                .Add(New SqlParameter("@a", hpid.Text))
                .Add(New SqlParameter("@b", pname.Text))
                .Add(New SqlParameter("@c", invno.Text))
                If ptype.SelectedItem = "نقدي" Then
                    .Add(New SqlParameter("@d", Val(paid.Text)))
                    .Add(New SqlParameter("@e", 0))
                Else
                    .Add(New SqlParameter("@d", 0))
                    .Add(New SqlParameter("@e", Val(paid.Text)))
                End If
                .Add(New SqlParameter("@f", nowdate))
                .Add(New SqlParameter("@g", un))
                .Add(New SqlParameter("@h", doctor.Text))
                .Add(New SqlParameter("@i", Val(tax.Text)))
                cmdx.ExecuteNonQuery()
            End With

            cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بتسديد مبلغ " & Val(paid.Text) & " للفاتورة " & invno.Text & "', '" & nowdate() & "')", con)
            cmdact.ExecuteNonQuery()
            fillinvdata()
            Cursor = Cursors.Default
            Invoices.fill()
            alert("تم تسديد المبلغ بنجاح", 1)
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
        cclose()
    End Sub

    Private Sub inps_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles inps.CellClick
        If e.ColumnIndex = 5 Then
            Reciept.frmtitle.Text = "إيصال سداد"
            Reciept.id.Text = inps.CurrentRow.Cells(0).Value
            Reciept.invno.Text = invno.Text
            Reciept.numb.Text = NoToTxt(inps.CurrentRow.Cells(1).Value + inps.CurrentRow.Cells(2).Value, "ريال", "هللة")
            If Reciept.WindowState = FormWindowState.Minimized Then
                Reciept.WindowState = FormWindowState.Normal
            End If
            Reciept.Show()
            Reciept.BringToFront()
        End If
    End Sub
End Class
