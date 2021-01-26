Imports System.Drawing.Text
Imports System.Data.SqlClient

Public Class OldPrescrips
    Public Sub search()
        If ser.Text <> "" Then
            Cursor = Cursors.WaitCursor
            connect()
            copen()
            Dim gt As SqlCommand
            Try
                gt = New SqlCommand("SELECT prescriptions.*, patients.pname FROM prescriptions, patients WHERE prescriptions.pid = patients.pid AND prescriptions.pid = '" & ser.Text & "' AND prescriptions.dstat = 0", con)
                Dim rdr As SqlDataReader = gt.ExecuteReader
                data.Rows.Clear()
                While rdr.Read
                    data.Rows.Add({rdr("did"), rdr("pname"), rdr("doctor"), rdr("ddate"), rdr("dstat")})
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
            gt = New SqlCommand("SELECT prescriptions.*, patients.pname FROM prescriptions, patients WHERE prescriptions.pid = patients.pid AND prescriptions.dstat = 0", con)
            Dim rdr As SqlDataReader = gt.ExecuteReader
            data.Rows.Clear()
            While rdr.Read
                data.Rows.Add({rdr("did"), rdr("pname"), rdr("doctor"), rdr("ddate"), rdr("dstat")})
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
            If e.ColumnIndex = 5 Then
                Cursor = Cursors.WaitCursor
                Prescrip.id.Text = data.CurrentRow.Cells(0).Value
                Prescrip.frmtitle.Text = "وصفة طبية"
                Prescrip.Show()
                If Prescrip.WindowState = FormWindowState.Minimized Then
                    Prescrip.WindowState = FormWindowState.Normal
                End If
                Prescrip.BringToFront()
                Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        connect()
        Try
            copen()
            Cursor = Cursors.WaitCursor
            cmd = New SqlCommand("UPDATE prescriptions SET dstat = 0 WHERE did = " & data.CurrentRow.Cells(0).Value & "", con)
            cmd.ExecuteNonQuery()
            Cursor = Cursors.Default
            cclose()
            fill()
        Catch ex As Exception

        End Try
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
