Imports System.Drawing.Text
Imports System.Data.SqlClient

Public Class ImpPays

    Public Sub fill()
        odate.Value = Date.Today
        ovalue.Text = "0"
        otype.SelectedIndex = 0
        oinfo.Clear()
        connect()
        Try
            copen()
            cmd1 = New SqlCommand("SELECT inamear, ibal FROM importers WHERE id = " & iid.Text & "", con)
            Dim rd As SqlDataReader = cmd1.ExecuteReader
            While rd.Read
                inamear.Text = rd(0).ToString
                ibal.Text = rd(1)
            End While
            rd.Close()

            cmd = New SqlCommand("SELECT * FROM imppays WHERE iid = " & iid.Text & "", con)
            Dim rdr As SqlDataReader = cmd.ExecuteReader
            data.Rows.Clear()
            While rdr.Read
                data.Rows.Add({rdr("id"), rdr("ovalue"), rdr("odate"), rdr("otype")})
            End While
            rdr.Close()
            cclose()
        Catch ex As Exception
            MsgBox(ex.Message)
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
        otype.SelectedIndex = 0
        fill()
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
            alert("الرجاء كتابة المبلغ المدفوع!", 0)
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
            Dim cmd As New SqlCommand("INSERT INTO imppays (iid, odate, ovalue, oinfo, otype) VALUES (@a, @b, @c, @d, @e)", con)
            With cmd.Parameters
                .Add(New SqlParameter("@a", iid.Text))
                .Add(New SqlParameter("@b", odate.Value))
                .Add(New SqlParameter("@c", Val(ovalue.Text)))
                .Add(New SqlParameter("@d", oinfo.Text))
                .Add(New SqlParameter("@e", otype.SelectedItem))
                cmd.ExecuteNonQuery()
            End With

            Dim cmddd As New SqlCommand("UPDATE importers SET ibal = (ibal - " & Val(ovalue.Text) & ") WHERE iid = " & iid.Text & "", con)
            cmddd.ExecuteNonQuery()

            cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & "بتسجيل مدفوعات جديدة', '" & nowdate() & "')", con)
            cmdact.ExecuteNonQuery()
            cclose()
            fill()
            Cursor = Cursors.Default
            alert("تم تسجيل المدفوعات بنجاح", 1)
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If data.RowCount > 0 Then
            Confirm.table.Text = "imppays"
            Confirm.field.Text = "id"
            Confirm.id.Text = data.CurrentRow.Cells(0).Value
            Confirm.ShowDialog()
        End If
    End Sub
End Class
