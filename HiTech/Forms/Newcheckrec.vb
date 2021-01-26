Imports System.Drawing.Text
Imports System.Data.SqlClient

Public Class Newcheckrec
    Public Sub stotpat()
        If pnat.Text = "سعودي" Or pnat.Text = "سعودية" Then
            stax.Text = 0
        Else
            Dim pr As Double = (Val(sprice.Text) * sqty.Value) - Val(sdiscount.Text)
            stax.Text = tx() / 100 * pr
        End If
        stotal.Text = (Val(sprice.Text) * sqty.Value) + Val(stax.Text) - Val(sdiscount.Text)
        pat.Text = Val(stotal.Text) - Val(insu.Text)
    End Sub

    Public Sub totalcost()
        Dim totalc As Double = 0
        For i As Integer = 0 To data.RowCount - 1
            totalc += Val(data.Rows(i).Cells(6).Value)
        Next
        total.Text = totalc
    End Sub

    Public Sub reset()
        clear(GroupBox1)

        connect()
        Try
            copen()
            Dim cmx As New SqlCommand("SELECT invno FROM [check] WHERE invno = (SELECT MAX(invno) FROM [check])", con)
            Dim nID As Integer = cmx.ExecuteScalar()
            If nID = 0 Then
                invno.Text = NextID(0)
            Else
                invno.Text = NextID(nID)
            End If
            cclose()
        Catch ex As Exception

        End Try

        sqty.Value = 1
        stax.Text = 0
        sdiscount.Text = 0
        stotal.Text = 0
        insu.Text = 0
        pat.Text = 0
        scode.Clear()
        sname.Clear()
        sprice.Text = 0
        data.Rows.Clear()
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

        If ugroup = "Receptions" Or ugroup = "Admins" Then
            Button2.Enabled = True
        Else
            Button2.Enabled = False
        End If

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
            cclose()
        Catch ex As Exception

        End Try

        connect()
        Try
            copen()
            Dim gt1 As New SqlCommand("SELECT dname FROM doctors", con)
            Dim rdr1 As SqlDataReader = gt1.ExecuteReader
            doctor.Items.Clear()
            While rdr1.Read
                doctor.Items.Add(rdr1("dname").ToString)
            End While
            rdr1.Close()
            cclose()
        Catch ex As Exception

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

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If pname.Text = "" Then
            alert("يرجى اختيار المريض !", 0)
            Exit Sub
        End If

        If dept.SelectedItem = Nothing Then
            alert("يرجى اختيار القسم !", 0)
            Exit Sub
        End If

        If doctor.SelectedItem = Nothing Then
            alert("يرجى اختيار الطبيب !", 0)
            Exit Sub
        End If

        If sname.Text = "" Then
            alert("يرجى اختيار الخدمة!", 0)
            Exit Sub
        End If

        If pname.Text <> "" And sname.Text <> "" Then
            Dim Updated As Boolean
            For Each row As DataGridViewRow In data.Rows
                If CType(row.Cells(0).Value, String) = scode.Text Then
                    alert("الخدمة موجودة بالفاتورة!", 0)
                    Exit Sub
                End If
            Next

            If Not Updated Then
                data.Rows.Add({scode.Text, sname.Text, Val(sprice.Text), sqty.Value, Val(stax.Text), Val(sdiscount.Text), Val(stotal.Text), Val(insu.Text), Val(pat.Text)})
            End If
            totalcost()


            sqty.Value = 1
            stax.Text = 0
            sdiscount.Text = 0
            stotal.Text = 0
            insu.Text = 0
            pat.Text = 0
            scode.Clear()
            sname.Clear()
            sprice.Text = 0


            scode.Focus()
        End If
    End Sub

    Private Sub data_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles data.CellValueChanged
        totalcost()
    End Sub

    Private Sub dept_KeyDown(sender As Object, e As KeyEventArgs) Handles doctor.KeyDown, dept.KeyDown
        If e.KeyCode = Keys.Delete Then
            e.Handled = True
        End If
    End Sub

    Private Sub dept_KeyPress(sender As Object, e As KeyPressEventArgs) Handles doctor.KeyPress, dept.KeyPress
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
                If r(2).ToString = "بدون" Then
                    insu.Text = 0
                    insu.Enabled = False
                Else
                    insu.Enabled = True
                End If
            End While
            r.Close()
            Cursor = Cursors.Default
            cclose()
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub scode_TextChanged(sender As Object, e As EventArgs) Handles scode.TextChanged
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

            Dim cmx As New SqlCommand("SELECT COUNT(invno) FROM [check] WHERE invno = " & Val(invno.Text) & "", con)
            Dim nID As Integer = cmx.ExecuteScalar()
            If nID = 0 Then
                invno.Text = invno.Text
            Else
                invno.Text = Val(invno.Text) + 1
            End If

            cmd = New SqlCommand("INSERT INTO [check] (pid,pname,chdate,dept,doctor,chtype,total,[user],invno,invstat) VALUES (@a,@b,@c,@d,@e,@f,@g,@h,@i,@j)", con)
            With cmd.Parameters
                .Add(New SqlParameter("@a", pid.Text))
                .Add(New SqlParameter("@b", pname.Text))
                .Add(New SqlParameter("@c", chdate.Value))
                .Add(New SqlParameter("@d", dept.SelectedItem))
                .Add(New SqlParameter("@e", doctor.SelectedItem))
                .Add(New SqlParameter("@f", "كشف جديد"))
                .Add(New SqlParameter("@g", Val(total.Text)))
                .Add(New SqlParameter("@h", un))
                .Add(New SqlParameter("@i", invno.Text))
                .Add(New SqlParameter("@j", "مفتوحة"))
                cmd.ExecuteNonQuery()
            End With

            For i As Integer = 0 To data.Rows.Count - 1
                cmd1 = New SqlCommand("INSERT INTO checkdetails (pid,pname,scode,sname,sprice,sqty,stax,sdiscount,stotal,insu,pat,invno) VALUES (@a,@b,@c,@d,@e,@f,@g,@h,@i,@j,@k,@l)", con)
                With cmd1.Parameters
                    .Add(New SqlParameter("@a", pid.Text))
                    .Add(New SqlParameter("@b", pname.Text))
                    .Add(New SqlParameter("@c", data.Rows(i).Cells(0).Value.ToString))
                    .Add(New SqlParameter("@d", data.Rows(i).Cells(1).Value.ToString))
                    .Add(New SqlParameter("@e", data.Rows(i).Cells(2).Value))
                    .Add(New SqlParameter("@f", data.Rows(i).Cells(3).Value))
                    .Add(New SqlParameter("@g", data.Rows(i).Cells(4).Value))
                    .Add(New SqlParameter("@h", data.Rows(i).Cells(5).Value))
                    .Add(New SqlParameter("@i", data.Rows(i).Cells(6).Value))
                    .Add(New SqlParameter("@j", data.Rows(i).Cells(7).Value))
                    .Add(New SqlParameter("@k", data.Rows(i).Cells(8).Value))
                    .Add(New SqlParameter("@l", invno.Text))
                    cmd1.ExecuteNonQuery()
                End With
            Next

            Dim wl As New SqlCommand("INSERT INTO waitlist(pid,pname,invno,chdate,wstat,doctor) VALUES (@a,@b,@c,@d,@e,@f)", con)
            With wl.Parameters
                .Add(New SqlParameter("@a", pid.Text))
                .Add(New SqlParameter("@b", pname.Text))
                .Add(New SqlParameter("@c", invno.Text))
                .Add(New SqlParameter("@d", chdate.Value))
                .Add(New SqlParameter("@e", "wait"))
                .Add(New SqlParameter("@f", doctor.SelectedItem))
                wl.ExecuteNonQuery()
            End With

            cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بإنشاء فاتورة جديدة بالرقم " & invno.Text & "', '" & nowdate() & "')", con)
            cmdact.ExecuteNonQuery()

            Cursor = Cursors.Default
            Invoices.fill()
            alert("تم إنشاء فاتورة الكشف بنجاح", 1)
            reset()
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
        cclose()
    End Sub

    Private Sub serch_Click(sender As Object, e As EventArgs) Handles serch.Click
        Searchpatient.from.Text = "newcheckrec"
        Searchpatient.frmtitle.Text = "بحث عن مريض"
        Searchpatient.ShowDialog()
    End Sub

    Private Sub serch2_Click(sender As Object, e As EventArgs) Handles serch2.Click
        Cursor = Cursors.WaitCursor
        connect()
        copen()
        Try
            cmd = New SqlCommand("SELECT snamear, sprice FROM services WHERE scode = '" & scode.Text & "' AND dept = '" & dept.SelectedItem & "'", con)
            Dim rdr As SqlDataReader = cmd.ExecuteReader
            If Not rdr.HasRows Then
                sname.Clear()
                sprice.Clear()
                Cursor = Cursors.Default
            End If
            While rdr.Read
                sname.Text = rdr(0).ToString
                sprice.Text = rdr(1).ToString
            End While
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
        cclose()
    End Sub

    Private Sub dept_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dept.SelectedIndexChanged
        sqty.Value = 1
        stax.Text = 0
        sdiscount.Text = 0
        stotal.Text = 0
        sprice.Text = 0
        insu.Text = 0
        pat.Text = 0
        scode.Clear()
        sname.Clear()
        sprice.Text = 0
        scode.Focus()
    End Sub

    Private Sub sprice_TextChanged(sender As Object, e As EventArgs) Handles sprice.TextChanged
        stotpat()
    End Sub

    Private Sub sqty_ValueChanged(sender As Object, e As EventArgs) Handles sqty.ValueChanged
        stotpat()
    End Sub

    Private Sub sdiscount_TextChanged(sender As Object, e As EventArgs) Handles sdiscount.TextChanged
        stotpat()
    End Sub

    Private Sub insu_TextChanged(sender As Object, e As EventArgs) Handles insu.TextChanged
        stotpat()
    End Sub

    Private Sub data_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles data.RowsRemoved
        totalcost()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If data.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            connect()
            Try
                copen()
                cmd1 = New SqlCommand("SELECT COUNT(id) FROM [check] WHERE invno = " & invno.Text & "", con)
                Dim co As Integer = cmd1.ExecuteScalar
                If co = 0 Then
                    Cursor = Cursors.Default
                    alert("الرجاء حفظ الفاتورة أولاً!", 0)
                    Exit Sub
                End If
                cclose()
            Catch ex As Exception
                Cursor = Cursors.Default
            End Try

            Try
                copen()
                cmd = New SqlCommand("UPDATE [check] SET invstat = 'مغلقة' WHERE invno = " & invno.Text & "", con)
                cmd.ExecuteNonQuery()

                cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بإغلاق الفاتورة رقم " & invno.Text & "', '" & nowdate() & "')", con)
                cmdact.ExecuteNonQuery()

                Cursor = Cursors.Default
                alert("تم إغلاق الفاتورة", 1)
                cclose()
            Catch ex As Exception
                Cursor = Cursors.Default
            End Try
        End If
    End Sub

    Private Sub pnat_TextChanged(sender As Object, e As EventArgs) Handles pnat.TextChanged
        stotpat()
        If pnat.Text = "سعودي" Or pnat.Text = "سعودية" Or pnat.Text = "" Then
            Label15.Text = "الضريبة (0%)"
        Else
            Label15.Text = "الضريبة (" & tx() & "%)"
        End If
    End Sub

End Class
