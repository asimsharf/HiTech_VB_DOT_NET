Imports System.Drawing.Text
Imports System.Data.SqlClient

Public Class Items

    Public Sub fill()
        connect()
        Try
            copen()
            Dim gt As New SqlCommand("SELECT * FROM categories", con)
            Dim rdr As SqlDataReader = gt.ExecuteReader
            icat.Items.Clear()
            While rdr.Read
                icat.Items.Add(rdr("cat").ToString)
            End While
            icat.SelectedIndex = 0
            rdr.Close()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub reset()
        clear(GroupBox2)
        fill()
        noru.Text = "n"
        iname.Focus()
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
        Me.Top = 170
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
        If iname.Text = "" Then
            alert("اكتب اسم العنصر!", 0)
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        connect()
        Try
            copen()
            Dim cmd As New SqlCommand("INSERT INTO items (iname, icat, idesc, iprice, ino, itax) VALUES (@a, @b, @c, @d, @e, @f)", con)
            With cmd.Parameters
                .Add(New SqlParameter("@a", iname.Text))
                .Add(New SqlParameter("@b", icat.SelectedItem))
                .Add(New SqlParameter("@c", idesc.Text))
                .Add(New SqlParameter("@d", Val(iprice.Text)))
                .Add(New SqlParameter("@e", ino.Text))
                .Add(New SqlParameter("@f", Val(itax.Text)))
                cmd.ExecuteNonQuery()
            End With

            Dim cmds As New SqlCommand("INSERT INTO stock (name, qty) VALUES (@a, @b)", con)
            With cmds.Parameters
                .Add(New SqlParameter("@a", iname.Text))
                .Add(New SqlParameter("@b", Val(iostock.Text)))
                cmds.ExecuteNonQuery()
            End With

            Dim cmdos As New SqlCommand("INSERT INTO opstock (name, qty) VALUES (@a, @b)", con)
            With cmdos.Parameters
                .Add(New SqlParameter("@a", iname.Text))
                .Add(New SqlParameter("@b", Val(iostock.Text)))
                cmdos.ExecuteNonQuery()
            End With

            cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بإضافة عنصر جديد بإسم (" & iname.Text & ")', '" & nowdate() & "')", con)
            cmdact.ExecuteNonQuery()
            cclose()
            reset()
            Cursor = Cursors.Default
            alert("تم تعريف العنصر بنجاح", 1)
        Catch ex As Exception
            Cursor = Cursors.Default
            If ex.Message.Contains("duplicate key") Then
                Cursor = Cursors.Default
                alert("اسم العنصر مسجل مسبقاً!", 0)
                Exit Sub
            End If
        End Try
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Searchitem.frmtitle.Text = "بحث عن عنصر"
        Searchitem.form.Text = "items"
        Searchitem.ShowDialog()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If iname.Text = "" Then
            alert("اكتب اسم العنصر!", 0)
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        connect()
        Try
            copen()
            Dim cmd As New SqlCommand("UPDATE items SET iname=@a, icat=@b, idesc=@c, iprice=@d, ino=@e, itax=@f WHERE id = " & id.Text & "", con)
            With cmd.Parameters
                .Add(New SqlParameter("@a", iname.Text))
                .Add(New SqlParameter("@b", icat.SelectedItem))
                .Add(New SqlParameter("@c", idesc.Text))
                .Add(New SqlParameter("@d", Val(iprice.Text)))
                .Add(New SqlParameter("@e", ino.Text))
                .Add(New SqlParameter("@f", Val(itax.Text)))
                cmd.ExecuteNonQuery()
            End With

            cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بتعديل بيانات العنصر رقم " & id.Text & "', '" & nowdate() & "')", con)
            cmdact.ExecuteNonQuery()

            cclose()
            reset()
            Cursor = Cursors.Default
            alert("تم تعديل بيانات العنصر بنجاح", 1)
        Catch ex As Exception
            If ex.Message.Contains("duplicate key") Then
                Cursor = Cursors.Default
                alert("اسم العنصر مسجل مسبقاً!", 0)
                Exit Sub
            End If
        End Try
    End Sub

    Private Sub noru_TextChanged(sender As Object, e As EventArgs) Handles noru.TextChanged
        If noru.Text = "n" Then
            Button4.Enabled = True
            Button6.Enabled = False
            Button7.Enabled = False
            iostock.Enabled = True
        ElseIf noru.Text = "u" Then
            Button4.Enabled = False
            Button6.Enabled = True
            Button7.Enabled = True
            iostock.Enabled = False
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Confirm.table.Text = "items"
        Confirm.field.Text = "id"
        Confirm.id.Text = id.Text
        Confirm.ShowDialog()
    End Sub

    Private Sub dept_TextChanged(sender As Object, e As EventArgs) Handles iname.TextChanged
        AcceptButton = Button4
    End Sub

    Private Sub iostock_TextChanged(sender As Object, e As EventArgs) Handles iostock.TextChanged
        If iostock.Text = "" Then
            iostock.Text = "0"
        End If
        If Val(iostock.Text) < 0 Then
            iostock.Text = "0"
        End If
        If Not IsNumeric(iostock.Text) Then
            iostock.Text = "0"
        End If
    End Sub

    Private Sub icat_KeyDown(sender As Object, e As KeyEventArgs) Handles icat.KeyDown
        If e.KeyCode = Keys.Delete Then
            e.Handled = True
        End If
    End Sub

    Private Sub icat_KeyPress(sender As Object, e As KeyPressEventArgs) Handles icat.KeyPress
        e.Handled = True
    End Sub

    Private Sub iprice_TextChanged(sender As Object, e As EventArgs) Handles iprice.TextChanged
        If iprice.Text = "" Then
            iprice.Text = "0"
        End If
        If Val(iprice.Text) < 0 Then
            iprice.Text = "0"
        End If
        If Not IsNumeric(iprice.Text) Then
            iprice.Text = "0"
        End If
    End Sub

    Private Sub Button10_Click_1(sender As Object, e As EventArgs) Handles Button10.Click
        reset()
    End Sub
End Class
