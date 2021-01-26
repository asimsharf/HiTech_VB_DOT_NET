Imports System.Drawing.Text
Imports System.Data.SqlClient

Public Class Taxes

    '//////////////////////////////////////////// Form Load ////////////////////////////////////////////////
    Private Sub Clinics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 250
        changefont(Panel1)
        Cursor = Cursors.WaitCursor
        connect()
        copen()
        Try
            cmd = New SqlCommand("SELECT * FROM taxes", con)
            Dim rdr As SqlDataReader = cmd.ExecuteReader
            While rdr.Read
                taxno.Text = rdr("taxno")
                tax.Text = rdr("tax")
            End While
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
        cclose()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Cursor = Cursors.WaitCursor
        connect()
        copen()
        Try
            cmd = New SqlCommand("UPDATE taxes SET taxno = " & taxno.Text & ", tax = " & tax.Text & "", con)
            cmd.ExecuteNonQuery()
            cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بتغيير إعدادات الضرائب', '" & nowdate() & "')", con)
            cmdact.ExecuteNonQuery()
            Cursor = Cursors.Default
            alert("تم تعديل الضرائب بنجاح", 1)
            Me.Close()
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
        cclose()
    End Sub
End Class
