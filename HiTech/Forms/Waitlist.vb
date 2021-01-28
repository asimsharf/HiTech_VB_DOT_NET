Imports System.Drawing.Text
Imports System.Data.SqlClient

Public Class Waitlist
    Public dr As String
    Public Sub fill()
        connect()
        copen()
        Dim gt As SqlCommand
        Try

            Dim dn As New SqlCommand("SELECT dname FROM doctors WHERE uname = '" & un & "'", con)
            dr = dn.ExecuteScalar
            '  gt = New SqlCommand("SELECT waitlist.id, waitlist.pid, waitlist.pname, waitlist.invno, waitlist.wstat FROM waitlist WHERE waitlist.doctor = '" & dr & "' AND wstat = 'wait'", con)
            gt = New SqlCommand("SELECT waitlist.id, waitlist.pid, waitlist.pname, waitlist.invno, waitlist.wstat FROM waitlist WHERE wstat = 'wait'", con)
            Dim rdr As SqlDataReader = gt.ExecuteReader
            data.Rows.Clear()
            While rdr.Read
                data.Rows.Add({rdr(0), rdr(1), rdr(2), rdr(3), rdr(4)})
            End While
            rdr.Close()
        Catch ex As Exception

        End Try
        cclose()
    End Sub

    '//////////////////////////////////////////// Form Load ////////////////////////////////////////////////
    Private Sub Searchdoctor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 140
        changefont(Panel1)
        fill()
        If ugroup = "Doctors" Or ugroup = "Admins" Then
            Button1.Visible = True
        Else
            Button1.Visible = False
        End If
        Timer1.Interval = 10000
        Timer1.Start()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        connect()
        Try
            copen()
            cmd = New SqlCommand("UPDATE waitlist SET wstat = 'done' WHERE id = " & data.CurrentRow.Cells(0).Value & "", con)
            cmd.ExecuteNonQuery()
            fill()
            cclose()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub data_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles data.CellClick
        If data.RowCount > 0 Then
            If e.ColumnIndex = 5 Then
                Clinic.pid.Text = data.CurrentRow.Cells(1).Value
                Clinic.invno.Text = data.CurrentRow.Cells(3).Value
                Clinic.frmtitle.Text = "العيادة"
                Clinic.Show()
                If Clinic.WindowState = FormWindowState.Minimized Then
                    Clinic.WindowState = FormWindowState.Normal
                End If
                Clinic.BringToFront()
                Cursor = Cursors.Default
            End If

            If e.ColumnIndex = 6 Then
                Labinvoice.pid.Text = data.CurrentRow.Cells(1).Value
                Labinvoice.frmtitle.Text = "طلب للمعمل"
                Labinvoice.Show()
                If Labinvoice.WindowState = FormWindowState.Minimized Then
                    Labinvoice.WindowState = FormWindowState.Normal
                End If
                Labinvoice.BringToFront()
                Cursor = Cursors.Default
            End If

            If e.ColumnIndex = 7 Then
                Prescription.frmtitle.Text = "وصفة طبية"
                Prescription.pid.Text = data.CurrentRow.Cells(1).Value
                Prescription.Show()
                If Prescription.WindowState = FormWindowState.Minimized Then
                    Prescription.WindowState = FormWindowState.Normal
                End If
                Prescription.BringToFront()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If data.RowCount > 0 Then
            Previnvoices.pid.Text = data.CurrentRow.Cells(1).Value
            Previnvoices.pname.Text = data.CurrentRow.Cells(2).Value
            Previnvoices.doctor.Text = dr
            Previnvoices.frmtitle.Text = "الفواتير السابقة"
            Previnvoices.Show()
            If Previnvoices.WindowState = FormWindowState.Minimized Then
                Previnvoices.WindowState = FormWindowState.Normal
            End If
            Previnvoices.BringToFront()
            Cursor = Cursors.Default
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        fill()
    End Sub

End Class
