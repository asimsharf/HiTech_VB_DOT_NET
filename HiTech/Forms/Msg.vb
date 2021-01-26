Imports System.Drawing.Text

Public Class Msg

    '//////////////////////////////////////////// Form Load ////////////////////////////////////////////////
    Private Sub Clinics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 250
        changefont(Panel1)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub
End Class
