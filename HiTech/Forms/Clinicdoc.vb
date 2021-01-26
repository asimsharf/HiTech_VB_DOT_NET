Imports System.Drawing.Text

Public Class Clinicdoc

    '//////////////////////////////////////////// Form Load ////////////////////////////////////////////////
    Private Sub Clinics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 250
        changefont(Panel1)
        docname.Clear()
        docinf.Clear()
        docname.Focus()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If docname.Text = "" Then
            docname.BackColor = Color.Coral
            Exit Sub
        End If
        Clinic.data.Rows.Add({"NULL", docname.Text, docpath.Text, docinf.Text})
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub docname_TextChanged(sender As Object, e As EventArgs) Handles docname.TextChanged
        docname.BackColor = Color.White
    End Sub
End Class
