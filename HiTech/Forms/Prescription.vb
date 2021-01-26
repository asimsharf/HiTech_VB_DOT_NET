Imports System.Drawing.Text
Imports System.Data.SqlClient

Public Class Prescription

    Public Sub reset()
        dcode.Clear()
        dname.Clear()
        dformat.Clear()
        dcon.Clear()
        dos.Clear()
        note.Clear()
        dcode.Focus()
        data.Rows.Clear()
        connect()
        Try
            copen()
            Dim cmx As New SqlCommand("SELECT did FROM prescriptions WHERE did = (SELECT MAX(did) FROM prescriptions)", con)
            Dim nID As Integer = cmx.ExecuteScalar()
            If nID = 0 Then
                did.Text = NextID(0)
            Else
                did.Text = NextID(nID)
            End If
            cclose()
        Catch ex As Exception

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
        reset()
        connect()
        Try
            copen()
            Dim gt As New SqlCommand("SELECT dname, dept FROM doctors WHERE uname = '" & un & "'", con)
            Dim rdr As SqlDataReader = gt.ExecuteReader
            While rdr.Read
                drname.Text = rdr(1).ToString
                doctor.Text = rdr(0).ToString
            End While
            rdr.Close()
            cclose()
        Catch ex As Exception

        End Try
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

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If pname.Text = "" Then
            alert("يرجى اختيار المريض !", 0)
            Exit Sub
        End If

        If doctor.Text = Nothing Then
            alert("يرجى اختيار الطبيب !", 0)
            Exit Sub
        End If

        If dname.Text = "" Then
            alert("يرجى اختيار الخدمة!", 0)
            Exit Sub
        End If
        data.Rows.Add({dcode.Text, dname.Text, dos.Text, note.Text})
        dcode.Clear()
        dname.Clear()
        dformat.Clear()
        dcon.Clear()
        dos.Clear()
        note.Clear()
        dcode.Focus()
    End Sub

    Private Sub dept_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Delete Then
            e.Handled = True
        End If
    End Sub

    Private Sub dept_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub pid_TextChanged(sender As Object, e As EventArgs) Handles pid.TextChanged
        Cursor = Cursors.WaitCursor
        connect()
        Try
            copen()
            cmd = New SqlCommand("SELECT pname,pnat,pinscomp FROM patients WHERE pid = " & pid.Text & "", con)
            Dim r As SqlDataReader = cmd.ExecuteReader
            If Not r.HasRows Then
                pname.Clear()
                pnat.Clear()
            End If
            While r.Read
                pname.Text = r(0).ToString
                pnat.Text = r(1).ToString
            End While
            r.Close()
            Cursor = Cursors.Default
            cclose()
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub scode_TextChanged(sender As Object, e As EventArgs) Handles dcode.TextChanged
        AcceptButton = serch2
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If data.RowCount = 0 Then
            alert("لا توجد عناصر بالفاتورة!", 0)
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        connect()
        copen()
        Try
            cmd = New SqlCommand("INSERT INTO prescriptions (did,pid,doctor,ddate,dstat) VALUES (@a,@b,@c,@d,@e)", con)
            With cmd.Parameters
                .Add(New SqlParameter("@a", Val(did.Text)))
                .Add(New SqlParameter("@b", pid.Text))
                .Add(New SqlParameter("@c", doctor.Text))
                .Add(New SqlParameter("@d", Date.Today.ToString("yyyy-MM-dd")))
                .Add(New SqlParameter("@e", 1))
                cmd.ExecuteNonQuery()
            End With

            For i As Integer = 0 To data.Rows.Count - 1
                cmd1 = New SqlCommand("INSERT INTO predetails (did,dcode,dos,note) VALUES (@a,@b,@c,@d)", con)
                With cmd1.Parameters
                    .Add(New SqlParameter("@a", Val(did.Text)))
                    .Add(New SqlParameter("@b", data.Rows(i).Cells(0).Value.ToString))
                    .Add(New SqlParameter("@c", data.Rows(i).Cells(2).Value.ToString))
                    .Add(New SqlParameter("@d", data.Rows(i).Cells(3).Value.ToString))
                    cmd1.ExecuteNonQuery()
                End With
            Next

            cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بإنشاء وصفة جديدة بالرقم " & did.Text & "', '" & nowdate() & "')", con)
            cmdact.ExecuteNonQuery()

            Cursor = Cursors.Default
            Invoices.fill()
            alert("تم إنشاء الوصفة بنجاح", 1)
            reset()
        Catch ex As Exception
            Cursor = Cursors.Default
            MsgBox(ex.Message)
        End Try
        cclose()
    End Sub

    Private Sub serch2_Click(sender As Object, e As EventArgs) Handles serch2.Click
        Cursor = Cursors.WaitCursor
        connect()
        copen()
        Try
            cmd = New SqlCommand("SELECT dname, dformat, dcon FROM drugs WHERE dcode = '" & dcode.Text & "'", con)
            Dim rdr As SqlDataReader = cmd.ExecuteReader
            If Not rdr.HasRows Then
                dname.Clear()
                dformat.Clear()
                dcon.Clear()
                Cursor = Cursors.Default
            End If
            While rdr.Read
                dname.Text = rdr(0).ToString
                dformat.Text = rdr(1).ToString
                dcon.Text = rdr(2).ToString
            End While
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
        cclose()
    End Sub

End Class
