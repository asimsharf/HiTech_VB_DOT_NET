Imports System.Drawing.Text
Imports System.Data.SqlClient

Public Class Newcheckdoc
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
        If pnat.Text = "سعودي" Or pnat.Text = "سعودية" Or pnat.Text = "" Then
            Label15.Text = "الضريبة (0%)"
        Else
            Label15.Text = "الضريبة (" & tx() & "%)"
        End If
        totalcost()
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
        If sname.Text = "" Then
            alert("يرجى اختيار والخدمة!", 0)
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
                data.Rows.Add({scode.Text, sname.Text, Val(sprice.Text), sqty.Value, Val(stax.Text), Val(sdiscount.Text), Val(stotal.Text), Val(insu.Text), Val(pat.Text), "new"})
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

    Private Sub dept_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Delete Then
            e.Handled = True
        End If
    End Sub

    Private Sub dept_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub scode_TextChanged(sender As Object, e As EventArgs) Handles scode.TextChanged
        AcceptButton = serch2
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Cursor = Cursors.WaitCursor
        connect()
        copen()
        Try
            Dim clr As New SqlCommand("DELETE from checkdetails WHERE invno = " & invno.Text & "", con)
            clr.ExecuteNonQuery()

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

            cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بإضافة عناصر جديدة للفاتورة رقم " & invno.Text & "', '" & nowdate() & "')", con)
            cmdact.ExecuteNonQuery()

            Dim upd As New SqlCommand("UPDATE [check] SET total = " & total.Text & " WHERE invno = " & invno.Text & "", con)
            upd.ExecuteNonQuery()

            Cursor = Cursors.Default
            alert("تم حفظ البيانات بنجاح", 1)
            Reset()
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
        cclose()
    End Sub

    Private Sub serch2_Click(sender As Object, e As EventArgs) Handles serch2.Click
        Cursor = Cursors.WaitCursor
        connect()
        copen()
        Try
            cmd = New SqlCommand("SELECT snamear, sprice FROM services WHERE scode = '" & scode.Text & "' AND dept = '" & dept.Text & "'", con)
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

    Private Sub invno_TextChanged(sender As Object, e As EventArgs) Handles invno.TextChanged
        Cursor = Cursors.WaitCursor
        connect()
        Try
            copen()
            cmd = New SqlCommand("SELECT pid, pname, chdate, dept, doctor FROM [check] WHERE invno = " & invno.Text & "", con)
            Dim rdr As SqlDataReader = cmd.ExecuteReader

            While rdr.Read
                pid.Text = rdr(0)
                pname.Text = rdr(1).ToString
                chdate.Text = CDate(rdr(2)).ToString("yyyy-MM-dd")
                dept.Text = rdr(3).ToString
                doctor.Text = rdr(4).ToString
            End While
            rdr.Close()
            cclose()
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try

        Try
            copen()
            cmd1 = New SqlCommand("SELECT * FROM checkdetails WHERE invno = " & invno.Text & "", con)
            Dim rdr1 As SqlDataReader = cmd1.ExecuteReader
            data.Rows.Clear()
            While rdr1.Read
                data.Rows.Add({rdr1("scode"), rdr1("sname").ToString, rdr1("sprice"), rdr1("sqty"), rdr1("stax"), rdr1("sdiscount"), rdr1("stotal"), rdr1("insu"), rdr1("pat"), "old"})
            End While
            rdr1.Close()
            cclose()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try

        connect()
        Try
            copen()
            Dim cmdnat As New SqlCommand("SELECT pnat FROM patients WHERE pid = " & pid.Text & "", con)
            pnat.Text = cmdnat.ExecuteScalar.ToString

            Dim cmddat As New SqlCommand("SELECT pinscomp FROM patients WHERE pid = " & pid.Text & "", con)
            Dim pic As String = cmddat.ExecuteScalar.ToString
            If pic = "بدون" Then
                insu.Text = 0
                insu.Enabled = False
            Else
                insu.Enabled = True
            End If
            cclose()
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
        Cursor = Cursors.Default
    End Sub

    Private Sub pnat_TextChanged(sender As Object, e As EventArgs) Handles pnat.TextChanged
        stotpat()
        If pnat.Text = "سعودي" Or pnat.Text = "سعودية" Or pnat.Text = "" Then
            Label15.Text = "الضريبة (0%)"
        Else
            Label15.Text = "الضريبة (" & tx() & "%)"
        End If
    End Sub

    Private Sub pid_TextChanged(sender As Object, e As EventArgs) Handles pid.TextChanged

    End Sub
End Class
