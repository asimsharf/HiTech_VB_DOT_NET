Imports System.Drawing.Text
Imports System.Data.SqlClient

Public Class Pinvoices

    Public Sub fill()
        Cursor = Cursors.WaitCursor
        connect()
        Try
            copen()
            Dim gt As New SqlCommand("SELECT * FROM [purchases] ORDER BY id DESC", con)
            Dim rdr As SqlDataReader = gt.ExecuteReader
            data.Rows.Clear()
            While rdr.Read
                data.Rows.Add({rdr("invno"), rdr("sdate"), rdr("impname"), rdr("total")})
            End While
            rdr.Close()
            Cursor = Cursors.Default
            cclose()
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub search()
        Cursor = Cursors.WaitCursor
        connect()
        Try
            copen()
            Dim gt As New SqlCommand("SELECT * FROM [purchases] WHERE impname = '" & inamear.Text & "' ORDER BY id DESC", con)
            Dim rdr As SqlDataReader = gt.ExecuteReader
            data.Rows.Clear()
            While rdr.Read
                data.Rows.Add({rdr("invno"), rdr("sdate"), rdr("impname"), rdr("total")})
            End While
            rdr.Close()
            Cursor = Cursors.Default
            cclose()
        Catch ex As Exception
            MsgBox(ex.Message)
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
            If e.ColumnIndex = 4 Then
                Pinvoice.invno.Text = data.CurrentRow.Cells(0).Value
                Pinvoice.frmtitle.Text = "تفاصيل الفاتورة"
                Pinvoice.Show()
                If Pinvoice.WindowState = FormWindowState.Minimized Then
                    Pinvoice.WindowState = FormWindowState.Normal
                End If
                Pinvoice.BringToFront()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub serchn_Click(sender As Object, e As EventArgs) Handles serchn.Click
        Searchimporter.form.Text = "Pinvoices"
        Searchimporter.frmtitle.Text = "بحث عن شركة"
        Searchimporter.ShowDialog()
    End Sub

    Private Sub inamear_TextChanged(sender As Object, e As EventArgs) Handles inamear.TextChanged
        search()
    End Sub
End Class
