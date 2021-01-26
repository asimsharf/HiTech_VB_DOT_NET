Imports System.Drawing.Text
Imports System.Data.SqlClient

Public Class Invoices

    Public Sub fill()
        Dim gt As SqlCommand
        Cursor = Cursors.WaitCursor
        connect()
        Try
            copen()
            If un = "Admin" Then
                gt = New SqlCommand("SELECT * FROM [check] WHERE CONVERT(date, chdate) = CONVERT(date, GETDATE()) ORDER BY id DESC", con)
            Else
                gt = New SqlCommand("SELECT * FROM [check] WHERE [user] = '" & un & "' AND CONVERT(date, chdate) = CONVERT(date, GETDATE()) ORDER BY id DESC", con)
            End If
            Dim rdr As SqlDataReader = gt.ExecuteReader
            data.Rows.Clear()
            While rdr.Read
                Dim cp As New SqlCommand("SELECT ISNULL(SUM(cash + net),0) FROM invpays WHERE invno = " & rdr("invno") & "", con)
                Dim op As Double = cp.ExecuteScalar
                If rdr("total") <> op Then
                    data.Rows.Add({rdr("invno"), rdr("pname"), rdr("doctor"), rdr("dept"), rdr("total"), rdr("chdate"), rdr("invstat")})
                End If
            End While
            rdr.Close()
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
        fill()

        If ugroup = "Receptions" Or ugroup = "Admins" Then
            Button2.Enabled = True
        Else
            Button2.Enabled = False
        End If

        If ugroup = "Receptions" Then
            Button5.Enabled = False
        Else
            Button5.Enabled = True
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

    Private Sub data_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles data.CellClick
        connect()
        Try
            copen()
            Dim gn As New SqlCommand("SELECT pid FROM patients WHERE pname = '" & data.CurrentRow.Cells(1).Value.ToString & "'", con)
            pid.Text = gn.ExecuteScalar
            cclose()
        Catch ex As Exception

        End Try

        If data.RowCount > 0 Then
            If e.ColumnIndex = 7 Then
                Invoice.invno.Text = data.CurrentRow.Cells(0).Value
                Invoice.frmtitle.Text = "تفاصيل الفاتورة"
                Invoice.Show()
                If Invoice.WindowState = FormWindowState.Minimized Then
                    Invoice.WindowState = FormWindowState.Normal
                End If
                Invoice.BringToFront()
                Cursor = Cursors.Default

            ElseIf e.ColumnIndex = 8 Then
                Invpays.frmtitle.Text = "سداد الفواتير"
                Invpays.pid.Text = pid.Text
                If Invpays.WindowState = FormWindowState.Minimized Then
                    Invpays.WindowState = FormWindowState.Normal
                End If
                Invpays.Show()
                Invpays.BringToFront()
            End If

            If data.CurrentRow.Cells(6).Value.ToString = "مفتوحة" Then
                Button2.Visible = True
                Button6.Visible = False
            Else
                Button2.Visible = False
                Button6.Visible = True
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If data.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            connect()
            Try
                copen()
                cmd = New SqlCommand("UPDATE [check] SET invstat = 'مغلقة' WHERE invno = " & data.CurrentRow.Cells(0).Value & "", con)
                cmd.ExecuteNonQuery()
                fill()
                If data.CurrentRow.Cells(6).Value.ToString = "مفتوحة" Then
                    Button2.Visible = True
                    Button6.Visible = False
                Else
                    Button2.Visible = False
                    Button6.Visible = True
                End If
                Cursor = Cursors.Default
                alert("تم إغلاق الفاتورة", 1)
                cclose()
            Catch ex As Exception
                Cursor = Cursors.Default
            End Try
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
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

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        If data.RowCount > 0 Then
            Confirm.table.Text = "[check]"
            Confirm.field.Text = "invno"
            Confirm.id.Text = data.CurrentRow.Cells(0).Value
            Confirm.ShowDialog()
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If data.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            connect()
            Try
                copen()
                cmd = New SqlCommand("UPDATE [check] SET invstat = 'مفتوحة' WHERE invno = " & data.CurrentRow.Cells(0).Value & "", con)
                cmd.ExecuteNonQuery()
                fill()
                If data.CurrentRow.Cells(6).Value.ToString = "مغلقة" Then
                    Button2.Visible = False
                    Button6.Visible = True
                Else
                    Button2.Visible = True
                    Button6.Visible = False
                End If
                Cursor = Cursors.Default
                alert("تم فتح الفاتورة", 1)
                cclose()
            Catch ex As Exception
                Cursor = Cursors.Default
            End Try
        End If
    End Sub

    Private Sub data_SelectionChanged(sender As Object, e As EventArgs) Handles data.SelectionChanged
        If data.CurrentRow.Cells(6).Value.ToString = "مفتوحة" Then
            Button2.Visible = True
            Button6.Visible = False
        Else
            Button2.Visible = False
            Button6.Visible = True
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Newcheckrec.frmtitle.Text = "فاتورة جديدة"
        If Newcheckrec.WindowState = FormWindowState.Minimized Then
            Newcheckrec.WindowState = FormWindowState.Normal
        End If
        Newcheckrec.Show()
        Newcheckrec.BringToFront()
    End Sub
End Class
