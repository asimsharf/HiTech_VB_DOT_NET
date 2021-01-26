Imports System.Drawing.Text
Imports System.Data.SqlClient

Public Class Reqs
    Public Sub search()
        If ser.Text <> "" Then
            Cursor = Cursors.WaitCursor
            connect()
            copen()
            Dim gt As SqlCommand
            Try
                gt = New SqlCommand("SELECT lab.id, lab.pid, lab.un, patients.pname, lab.ldate, lab.lstat FROM lab, patients WHERE lab.pid = patients.pid AND lab.pid = '" & ser.Text & "' AND lab.lstat = 1", con)
                Dim rdr As SqlDataReader = gt.ExecuteReader
                data.Rows.Clear()
                While rdr.Read
                    data.Rows.Add({rdr("id"), rdr("pid"), rdr("un"), rdr("pname"), rdr("ldate"), rdr("lstat")})
                End While
                rdr.Close()
                cclose()
                Cursor = Cursors.Default
            Catch ex As Exception
                Cursor = Cursors.Default
            End Try
        End If
    End Sub

    Public Sub fill()
        Cursor = Cursors.WaitCursor
        connect()
        copen()
        Dim gt As SqlCommand
        Try
            gt = New SqlCommand("SELECT lab.id, lab.pid, lab.un, patients.pname, lab.ldate, lab.lstat FROM lab, patients WHERE lab.pid = patients.pid AND lab.lstat = 0", con)
            Dim rdr As SqlDataReader = gt.ExecuteReader
            data.Rows.Clear()
            While rdr.Read
                data.Rows.Add({rdr("id"), rdr("pid"), rdr("un"), rdr("pname"), rdr("ldate"), rdr("lstat")})
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
            If e.ColumnIndex = 6 Then
                Cursor = Cursors.WaitCursor
                Req.id.Text = data.CurrentRow.Cells(0).Value
                Req.frmtitle.Text = "طلب"
                Req.Show()
                If Req.WindowState = FormWindowState.Minimized Then
                    Req.WindowState = FormWindowState.Normal
                End If
                Req.BringToFront()
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
                cmd = New SqlCommand("UPDATE lab SET lstat = 1 WHERE id = " & data.CurrentRow.Cells(0).Value & "", con)
                cmd.ExecuteNonQuery()
                Cursor = Cursors.Default
                cclose()
                fill()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub serch_Click(sender As Object, e As EventArgs) Handles serch.Click
        search()
    End Sub

    Private Sub ser_TextChanged(sender As Object, e As EventArgs) Handles ser.TextChanged
        AcceptButton = serch
        If ser.Text = "" Then
            fill()
        End If
    End Sub
End Class
