Imports System.Drawing.Text
Imports System.Data.SqlClient

Public Class Masrofat

    Public Sub reset()
        clear(GroupBox2)
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
        reset()
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

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If Val(ovalue.Text) <= 0 Then
            alert("الرجاء كتابة قيمة المصروفات!", 0)
            Exit Sub
        End If
        If oinfo.Text = "" Then
            alert("الرجاء كتابة البيان!", 0)
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        connect()
        Try
            copen()
            Dim cmd As New SqlCommand("INSERT INTO masrofat (odate, ovalue, oinfo, un) VALUES (@a, @b, @c, @d)", con)
            With cmd.Parameters
                .Add(New SqlParameter("@a", odate.Value))
                .Add(New SqlParameter("@b", Val(ovalue.Text)))
                .Add(New SqlParameter("@c", oinfo.Text))
                .Add(New SqlParameter("@d", un))
                cmd.ExecuteNonQuery()
            End With

            cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & "بتسجيل مصروفات جديدة', '" & nowdate() & "')", con)
            cmdact.ExecuteNonQuery()
            cclose()
            reset()
            Cursor = Cursors.Default
            alert("تم تسجيل المصروفات بنجاح", 1)
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub ovalue_TextChanged(sender As Object, e As EventArgs) Handles ovalue.TextChanged
        If ovalue.Text = "" Then
            ovalue.Text = "0"
        End If
        If Val(ovalue.Text) < 0 Then
            ovalue.Text = "0"
        End If
        If Not IsNumeric(ovalue.Text) Then
            ovalue.Text = "0"
        End If
    End Sub
End Class
