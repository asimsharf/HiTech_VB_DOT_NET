Imports System.Drawing.Text
Imports System.Data.SqlClient

Public Class Reqs2

    Public Sub fill()
        Cursor = Cursors.WaitCursor
        connect()
        copen()
        Dim gt As SqlCommand
        Try
            gt = New SqlCommand("SELECT stockreq.id, stockreq.rdate, doctors.dname FROM stockreq, doctors WHERE stockreq.un = doctors.uname AND stockreq.rstat = 0", con)
            Dim rdr As SqlDataReader = gt.ExecuteReader
            data.Rows.Clear()
            While rdr.Read
                data.Rows.Add({rdr("id"), rdr("rdate"), rdr("dname")})
            End While
            rdr.Close()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
            MsgBox(ex.Message)
        End Try
        cclose()
    End Sub

    '//////////////////////////////////////////// Form Load ////////////////////////////////////////////////
    Private Sub Searchdoctor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 140
        changefont(Panel1)
        fill()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub data_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles data.CellClick
        If data.RowCount > 0 Then
            If e.ColumnIndex = 3 Then
                Cursor = Cursors.WaitCursor
                Req2.id.Text = data.CurrentRow.Cells(0).Value
                Req2.frmtitle.Text = "طلبية"
                Req2.Show()
                If Req2.WindowState = FormWindowState.Minimized Then
                    Req2.WindowState = FormWindowState.Normal
                End If
                Req2.BringToFront()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If data.Rows.Count > 0 Then
            connect()
            Try
                copen()
                Cursor = Cursors.WaitCursor
                cmd = New SqlCommand("UPDATE stockreq SET rstat = 1 WHERE id = " & data.CurrentRow.Cells(0).Value & "", con)
                cmd.ExecuteNonQuery()
                Cursor = Cursors.Default
                cclose()
                fill()
            Catch ex As Exception

            End Try
        End If
    End Sub

End Class
