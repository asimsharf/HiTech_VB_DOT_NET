Imports System.Drawing.Text
Imports System.Data.SqlClient

Public Class Stockrequest

    Public Sub fill()
        Cursor = Cursors.WaitCursor
        connect()
        Try
            copen()

            cmd = New SqlCommand("SELECT dname FROM doctors WHERE uname = '" & un & "'", con)
            doctor.Text = cmd.ExecuteScalar.ToString

            Dim gt As New SqlCommand("SELECT * FROM stockreq WHERE un = '" & un & "' AND rstat = 0 ORDER BY id ASC", con)
            Dim rdr As SqlDataReader = gt.ExecuteReader
            data.Rows.Clear()
            While rdr.Read
                data.Rows.Add({rdr("id"), rdr("request"), rdr("rdate")})
            End While
            rdr.Close()
            cclose()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub reset()
        noru.Text = "n"
        id.Clear()
        fill()
        requ.Clear()
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
        If doctor.Text = "" Then
            alert("اسم الطبيب غير متوفر", 0)
            Exit Sub
        End If

        Cursor = Cursors.WaitCursor
        connect()
        Try
            copen()
            Dim cmd As New SqlCommand("INSERT INTO stockreq (un,request,rdate,rstat) VALUES (@a,@b,@c,@d)", con)
            With cmd.Parameters
                .Add(New SqlParameter("@a", un))
                .Add(New SqlParameter("@b", requ.Text))
                .Add(New SqlParameter("@c", rdate.Value))
                .Add(New SqlParameter("@d", 0))
                cmd.ExecuteNonQuery()
            End With

            cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بإنشاء طلب بإسم (" & doctor.Text & ")', '" & nowdate() & "')", con)
            cmdact.ExecuteNonQuery()
            cclose()
            fill()
            reset()
            Cursor = Cursors.Default
            alert("تم إنشاء الطلب بنجاح", 1)
        Catch ex As Exception
            Cursor = Cursors.Default
            Exit Sub
        End Try
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        reset()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Cursor = Cursors.WaitCursor
        connect()
        Try
            copen()
            Dim cmd As New SqlCommand("UPDATE stockreq SET rdate=@a, request=@b WHERE id = " & id.Text & "", con)
            With cmd.Parameters
                .Add(New SqlParameter("@a", rdate.Value))
                .Add(New SqlParameter("@b", requ.Text))
                cmd.ExecuteNonQuery()
            End With

            cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بتعديل بيانات الطلب رقم " & id.Text & "', '" & nowdate() & "')", con)
            cmdact.ExecuteNonQuery()

            cclose()
            reset()
            fill()
            Cursor = Cursors.Default
            alert("تم تعديل بيانات الطلب بنجاح", 1)
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
        ElseIf noru.Text = "u" Then
            Button4.Enabled = False
            Button6.Enabled = True
            Button7.Enabled = True
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Confirm.table.Text = "stockreq"
        Confirm.field.Text = "id"
        Confirm.id.Text = id.Text
        Confirm.ShowDialog()
    End Sub

    Private Sub data_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles data.CellClick
        If data.RowCount > 0 Then
            noru.Text = "u"
            connect()
            Try
                copen()
                Dim gtx As New SqlCommand("SELECT * FROM stockreq WHERE id = '" & data.CurrentRow.Cells(0).Value & "'", con)
                Dim rdrx As SqlDataReader = gtx.ExecuteReader
                While rdrx.Read
                    id.Text = rdrx("id")
                    Dim cmdn As New SqlCommand("SELECT dname FROM doctors WHERE uname = '" & rdrx("un") & "'", con)
                    doctor.Text = cmdn.ExecuteScalar.ToString

                    requ.Text = rdrx("request")
                    rdate.Value = rdrx("rdate")
                End While
                cclose()
            Catch ex As Exception

            End Try
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        If data.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Req2.id.Text = data.CurrentRow.Cells(0).Value
            Req2.frmtitle.Text = "طلب"
            Req2.Show()
            If Req2.WindowState = FormWindowState.Minimized Then
                Req2.WindowState = FormWindowState.Normal
            End If
            Req2.BringToFront()
            Cursor = Cursors.Default
        End If
    End Sub

End Class
