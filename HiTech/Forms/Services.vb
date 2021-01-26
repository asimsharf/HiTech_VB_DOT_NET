Imports System.Drawing.Text
Imports System.Data.SqlClient

Public Class Services

    Public Sub fill()
        connect()
        Try
            copen()
            Dim gt As New SqlCommand("SELECT * FROM services ORDER BY id ASC", con)
            Dim rdr As SqlDataReader = gt.ExecuteReader
            data.Rows.Clear()
            While rdr.Read
                data.Rows.Add({rdr("id"), rdr("scode"), rdr("snamear"), rdr("snameen"), rdr("dept"), rdr("sprice")})
            End While
            rdr.Close()
            cclose()
            scode.SelectAll()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub reset()
        clear(GroupBox2)
        fill()
        noru.Text = "n"
        scode.Focus()
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
        Cursor = Cursors.WaitCursor
        connect()
        Try
            copen()
            Dim gt As New SqlCommand("SELECT * FROM depts", con)
            Dim rdr As SqlDataReader = gt.ExecuteReader
            dept.Items.Clear()
            While rdr.Read
                dept.Items.Add(rdr("dept").ToString)
            End While
            rdr.Close()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try

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
        If scode.Text = "" Or snamear.Text = "" Or snameen.Text = "" Or sprice.Text = "" Or dept.SelectedItem = Nothing Then
            alert("كل الحقول مطلوبة!", 0)
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        connect()
        Try
            copen()
            Dim cmd As New SqlCommand("INSERT INTO services (scode,snamear,snameen,dept,sprice) VALUES (@a,@b,@c,@d,@e)", con)
            With cmd.Parameters
                .Add(New SqlParameter("@a", scode.Text))
                .Add(New SqlParameter("@b", snamear.Text))
                .Add(New SqlParameter("@c", snameen.Text))
                .Add(New SqlParameter("@d", dept.SelectedItem))
                .Add(New SqlParameter("@e", Val(sprice.Text)))
                cmd.ExecuteNonQuery()
            End With

            cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بإضافة خدمة جديدة بالرقم " & scode.Text & "', '" & nowdate() & "')", con)
            cmdact.ExecuteNonQuery()
            cclose()
            reset()
            Cursor = Cursors.Default
            alert("تم إدخال الخدمة بنجاح", 1)
        Catch ex As Exception
            If ex.Message.Contains("duplicate key") Then
                Cursor = Cursors.Default
                alert("كود الخدمة او اسم الخدمو مسجل مسبقاً!", 0)
                Exit Sub
            End If
        End Try
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        reset()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If scode.Text = "" Or snamear.Text = "" Or snameen.Text = "" Or Val(sprice.Text) = 0 Or dept.SelectedItem = Nothing Then
            alert("كل الحقول مطلوبة!", 0)
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        connect()
        Try
            copen()
            Dim cmd As New SqlCommand("UPDATE services SET scode=@a,snamear=@b,snameen=@c,dept=@d,sprice=@e WHERE id = " & id.text & "", con)
            With cmd.Parameters
                .Add(New SqlParameter("@a", scode.Text))
                .Add(New SqlParameter("@b", snamear.Text))
                .Add(New SqlParameter("@c", snameen.Text))
                .Add(New SqlParameter("@d", dept.SelectedItem))
                .Add(New SqlParameter("@e", Val(sprice.Text)))
                cmd.ExecuteNonQuery()
            End With

            cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بتعديل بيانات الخدمة رقم " & scode.Text & "', '" & nowdate() & "')", con)
            cmdact.ExecuteNonQuery()
            cclose()
            reset()
            Cursor = Cursors.Default
            alert("تم تعديل بيانات الخدمة بنجاح", 1)
        Catch ex As Exception
            If ex.Message.Contains("duplicate key") Then
                Cursor = Cursors.Default
                alert("كود الخدمة او اسم الخدمو مسجل مسبقاً!", 0)
                Exit Sub
            End If
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
        Confirm.table.Text = "services"
        Confirm.field.Text = "id"
        Confirm.id.Text = id.Text
        Confirm.ShowDialog()
    End Sub

    Private Sub data_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles data.CellClick
        If data.RowCount > 0 Then
            id.Text = data.CurrentRow.Cells(0).Value
            scode.Text = data.CurrentRow.Cells(1).Value.ToString
            snamear.Text = data.CurrentRow.Cells(2).Value.ToString
            snameen.Text = data.CurrentRow.Cells(3).Value.ToString
            dept.SelectedItem = data.CurrentRow.Cells(4).Value.ToString
            sprice.Text = data.CurrentRow.Cells(5).Value
            noru.Text = "u"
        End If
    End Sub

    Private Sub dept_KeyDown(sender As Object, e As KeyEventArgs) Handles dept.KeyDown
        If e.KeyCode = Keys.Delete Then
            e.Handled = True
        End If
    End Sub

    Private Sub dept_KeyPress(sender As Object, e As KeyPressEventArgs) Handles dept.KeyPress
        e.Handled = True
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles search.TextChanged
        Try
            For Each row As DataGridViewRow In data.Rows
                If row.Cells(1).Value.ToString = "" & search.Text & "" Or row.Cells(2).Value.ToString Like "*" & search.Text & "*" Or row.Cells(3).Value.ToString Like "*" & search.Text & "*" Then
                    data.CurrentRow.Selected = False
                    row.Selected = True
                    data.FirstDisplayedScrollingRowIndex = row.Index
                    search.Focus()
                    Exit For
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub
End Class
