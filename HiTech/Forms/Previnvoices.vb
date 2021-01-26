Imports System.Drawing.Text
Imports System.Data.SqlClient

Public Class Previnvoices

    Public Sub fill()
        Cursor = Cursors.WaitCursor
        connect()
        Try
            copen()
            Dim dn As New SqlCommand("SELECT dname FROM doctors WHERE uname = '" & un & "'", con)
            Dim dr As String = dn.ExecuteScalar

            Dim gt As New SqlCommand("SELECT [check].invno, [check].chdate, [check].total, SUM(invpays.cash + invpays.net), [check].invstat FROM [check], invpays WHERE [check].invno = invpays.invno AND [check].doctor = '" & dr & "' AND [check].pid = '" & pid.Text & "' GROUP BY [check].invno, [check].chdate, [check].total, [check].invstat, [check].id ORDER BY [check].id DESC", con)
            Dim rdr As SqlDataReader = gt.ExecuteReader
            data.Rows.Clear()
            While rdr.Read
                data.Rows.Add({rdr(0), rdr(1), rdr(2), rdr(3), rdr(2) - rdr(3), rdr(4)})
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
        If data.RowCount > 0 Then
            Dim totalc As Double = 0
            For i As Integer = 0 To data.RowCount - 1
                totalc += Val(data.Rows(i).Cells(4).Value)
            Next
            total.Text = totalc
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
            End If
        End If
    End Sub

End Class
