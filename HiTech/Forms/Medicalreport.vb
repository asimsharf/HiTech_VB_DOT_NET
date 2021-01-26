Imports System.Drawing.Text
Imports System.Data.SqlClient

Public Class Medicalreport

    Public Sub fill()
        Cursor = Cursors.WaitCursor
        connect()
        Try
            copen()

            cmd = New SqlCommand("SELECT dname FROM doctors WHERE uname = '" & un & "'", con)
            doctor.Text = cmd.ExecuteScalar.ToString

            Dim gt As New SqlCommand("SELECT * FROM medrep ORDER BY id ASC", con)
            Dim rdr As SqlDataReader = gt.ExecuteReader
            data.Rows.Clear()
            While rdr.Read
                data.Rows.Add({rdr(0), rdr(1), rdr(2), rdr(3), rdr(4), rdr(5), rdr(6), rdr(7)})
            End While
            rdr.Close()
            cclose()
            Cursor = Cursors.Default
            pid.SelectAll()
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub reset()
        clear(GroupBox2)
        fill()
        noru.Text = "n"
        pid.Focus()
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
        If pname.Text = "" Then
            alert("الرجاء اختيار المريض!", 0)
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        connect()
        Try
            copen()
            Dim cmd As New SqlCommand("INSERT INTO medrep (pid,pname,mdate,mstat,mneed,doctor,medmng) VALUES (@a,@b,@c,@d,@e,@f,@g)", con)
            With cmd.Parameters
                .Add(New SqlParameter("@a", pid.Text))
                .Add(New SqlParameter("@b", pname.Text))
                .Add(New SqlParameter("@c", mdate.Value))
                .Add(New SqlParameter("@d", mstat.Text))
                .Add(New SqlParameter("@e", mneed.Text))
                .Add(New SqlParameter("@f", doctor.Text))
                .Add(New SqlParameter("@g", medmng.Text))
                cmd.ExecuteNonQuery()
            End With

            cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بإنشاء تقرير طبي بإسم (" & pname.Text & ")', '" & nowdate() & "')", con)
            cmdact.ExecuteNonQuery()
            cclose()
            reset()
            Cursor = Cursors.Default
            alert("تم إنشاء التقرير بنجاح", 1)
        Catch ex As Exception
            Cursor = Cursors.Default
            Exit Sub
        End Try
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        reset()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If pname.Text = "" Then
            alert("الرجاء اختيار المريض!", 0)
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        connect()
        Try
            copen()
            Dim cmd As New SqlCommand("UPDATE medrep SET pid=@a, pname=@b, mdate=@c, mstat=@d, mneed=@e, doctor=@f, medmng=@g WHERE id = " & id.Text & "", con)
            With cmd.Parameters
                .Add(New SqlParameter("@a", pid.Text))
                .Add(New SqlParameter("@b", pname.Text))
                .Add(New SqlParameter("@c", mdate.Value))
                .Add(New SqlParameter("@d", mstat.Text))
                .Add(New SqlParameter("@e", mneed.Text))
                .Add(New SqlParameter("@f", doctor.Text))
                .Add(New SqlParameter("@g", medmng.Text))
                cmd.ExecuteNonQuery()
            End With

            cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بتعديل بيانات التقرير رقم " & id.Text & "', '" & nowdate() & "')", con)
            cmdact.ExecuteNonQuery()

            cclose()
            reset()
            Cursor = Cursors.Default
            alert("تم تعديل بيانات التقرير بنجاح", 1)
        Catch ex As Exception
            Cursor = Cursors.Default
            Exit Sub
        End Try
    End Sub

    Private Sub noru_TextChanged(sender As Object, e As EventArgs) Handles noru.TextChanged
        If noru.Text = "n" Then
            Button4.Enabled = True
            Button6.Enabled = False
            Button7.Enabled = False
            pid.Enabled = True
        ElseIf noru.Text = "u" Then
            Button4.Enabled = False
            Button6.Enabled = True
            Button7.Enabled = True
            pid.Enabled = False
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Confirm.table.Text = "medrep"
        Confirm.field.Text = "id"
        Confirm.id.Text = id.Text
        Confirm.ShowDialog()
    End Sub

    Private Sub data_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles data.CellClick
        If data.RowCount > 0 Then
            id.Text = data.CurrentRow.Cells(0).Value
            pid.Text = data.CurrentRow.Cells(1).Value
            pname.Text = data.CurrentRow.Cells(2).Value.ToString
            mdate.Value = data.CurrentRow.Cells(3).Value.ToString
            mstat.Text = data.CurrentRow.Cells(4).Value.ToString
            mneed.Text = data.CurrentRow.Cells(5).Value.ToString
            doctor.Text = data.CurrentRow.Cells(6).Value.ToString
            medmng.Text = data.CurrentRow.Cells(7).Value.ToString
            noru.Text = "u"
        End If
    End Sub

    Private Sub dept_TextChanged(sender As Object, e As EventArgs)
        AcceptButton = Button4
    End Sub

    Private Sub pid_TextChanged(sender As Object, e As EventArgs) Handles pid.TextChanged
        AcceptButton = serch
    End Sub

    Private Sub serch_Click(sender As Object, e As EventArgs) Handles serch.Click
        Cursor = Cursors.WaitCursor
        connect()
        copen()
        Try
            cmd = New SqlCommand("SELECT pname FROM patients WHERE pid = " & pid.Text & " AND pstat = 'نشط'", con)
            pname.Text = cmd.ExecuteScalar.ToString
            Cursor = Cursors.Default
        Catch ex As Exception
            pname.Clear()
            Cursor = Cursors.Default
        End Try
        cclose()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If data.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Medrep.id.Text = data.CurrentRow.Cells(0).Value
            Medrep.frmtitle.Text = "تقرير طبي"
            Medrep.Show()
            If Medrep.WindowState = FormWindowState.Minimized Then
                Medrep.WindowState = FormWindowState.Normal
            End If
            Medrep.BringToFront()
            Cursor = Cursors.Default
        End If
    End Sub

End Class
