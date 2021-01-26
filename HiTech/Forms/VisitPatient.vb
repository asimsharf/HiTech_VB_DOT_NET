Imports System.Drawing.Text
Imports System.Data.SqlClient

Public Class VisitPatient

    Public Sub fill()
        Cursor = Cursors.WaitCursor
        connect()
        Try
            copen()
            Dim gt As New SqlCommand("SELECT * FROM [check] WHERE [check].pid = '" & pid.Text & "' ORDER BY id DESC", con)
            Dim rdr As SqlDataReader = gt.ExecuteReader
            data.Rows.Clear()
            While rdr.Read
                data.Rows.Add({rdr("invno"), rdr("doctor"), rdr("dept"), rdr("total"), rdr("chdate"), rdr("invstat")})
            End While
            rdr.Close()

            cmd1 = New SqlCommand("SELECT SUM(total) as total FROM [check] WHERE pid = '" & pid.Text & "'", con)
            Dim tt As Double = cmd1.ExecuteScalar

            Dim cmd2 As SqlCommand = New SqlCommand("SELECT SUM(cash + net) as paid FROM [invpays] WHERE pid = '" & pid.Text & "'", con)
            Dim sp As Double = cmd2.ExecuteScalar

            Dim rema As Double = tt - sp

            remain.Text = rema

            Cursor = Cursors.Default
            cclose()
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
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
        connect()
        Try
            copen()
            Dim gt1 As New SqlCommand("SELECT dname FROM doctors", con)
            Dim rdr1 As SqlDataReader = gt1.ExecuteReader
            doctor.Items.Clear()
            While rdr1.Read
                doctor.Items.Add(rdr1("dname").ToString)
            End While
            rdr1.Close()
            cclose()
        Catch ex As Exception

        End Try
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

    Private Sub data_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles data.CellClick
        If data.RowCount > 0 Then
            If e.ColumnIndex = 6 Then
                Invoice.invno.Text = data.CurrentRow.Cells(0).Value
                Invoice.frmtitle.Text = "تفاصيل الفاتورة"
                Invoice.Show()
                If Invoice.WindowState = FormWindowState.Minimized Then
                    Invoice.WindowState = FormWindowState.Normal
                End If
                Invoice.BringToFront()
                Cursor = Cursors.Default
            ElseIf e.ColumnIndex = 7 Then
                Invpays.frmtitle.Text = "سداد الفواتير"
                Invpays.pid.Text = pid.Text
                If Invpays.WindowState = FormWindowState.Minimized Then
                    Invpays.WindowState = FormWindowState.Normal
                End If
                Invpays.Show()
                Invpays.BringToFront()
            End If
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)
        If data.RowCount > 0 Then
            InvEdit.invno.Text = data.CurrentRow.Cells(0).Value
            InvEdit.frmtitle.Text = "تعديل الفاتورة"
            If InvEdit.WindowState = FormWindowState.Minimized Then
                InvEdit.WindowState = FormWindowState.Normal
            End If
            InvEdit.Show()
            InvEdit.BringToFront()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs)
        If data.RowCount > 0 Then
            Confirm.table.Text = "[check]"
            Confirm.field.Text = "invno"
            Confirm.id.Text = data.CurrentRow.Cells(0).Value
            Confirm.ShowDialog()
        End If
    End Sub

    Private Sub serchn_Click(sender As Object, e As EventArgs) Handles serchn.Click
        Searchpatient.from.Text = "VisitPatient"
        Searchpatient.frmtitle.Text = "بحث عن مريض"
        Searchpatient.ShowDialog()
    End Sub

    Private Sub pid_TextChanged(sender As Object, e As EventArgs) Handles pid.TextChanged
        fill()
    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles Button4.Click
        If data.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            connect()
            Try
                copen()
                cmd = New SqlCommand("UPDATE [check] SET invstat = 'مغلقة' WHERE invno = " & data.CurrentRow.Cells(0).Value & "", con)
                cmd.ExecuteNonQuery()
                fill()
                Cursor = Cursors.Default
                alert("تم إغلاق الفاتورة", 1)
                cclose()
            Catch ex As Exception
                Cursor = Cursors.Default
            End Try
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        connect()
        Try
            copen()
            Dim wl As New SqlCommand("INSERT INTO waitlist(pid,pname,invno,chdate,wstat,doctor) VALUES (@a,@b,@c,@d,@e,@f)", con)
            With wl.Parameters
                .Add(New SqlParameter("@a", pid.Text))
                .Add(New SqlParameter("@b", pname.Text))
                .Add(New SqlParameter("@c", ""))
                .Add(New SqlParameter("@d", ""))
                .Add(New SqlParameter("@e", "wait"))
                .Add(New SqlParameter("@f", doctor.SelectedItem))
                wl.ExecuteNonQuery()
            End With
            cclose()
            alert("تم الإرسال إلى الطبيب", 1)
        Catch ex As Exception

        End Try
    End Sub
End Class
