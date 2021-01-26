Imports System.Drawing.Text
Imports System.Data.SqlClient

Public Class Purchases

    Public Sub totalcost()
        Dim totalc As Double = 0
        For i As Integer = 0 To invdata.RowCount - 1
            totalc += Val(invdata.Rows(i).Cells(3).Value)
        Next
        tot.Text = totalc
    End Sub

    Public Sub reset()

        Cursor = Cursors.WaitCursor
        connect()
        Try
            copen()
            Dim cmx As New SqlCommand("SELECT invno FROM [purchases] WHERE invno = (SELECT MAX(invno) FROM [purchases])", con)
            Dim nID As Integer = cmx.ExecuteScalar()
            If nID = 0 Then
                invno.Text = NextID(0)
            Else
                invno.Text = NextID(nID)
            End If
            cclose()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try

        copen()
        Dim gt As SqlCommand
        Try
            gt = New SqlCommand("SELECT iname, ino, itax, qty FROM items INNER JOIN stock ON stock.name = items.iname", con)
            Dim rdr As SqlDataReader = gt.ExecuteReader
            idata.Rows.Clear()
            While rdr.Read
                idata.Rows.Add({rdr("iname"), rdr("qty"), rdr("itax"), rdr("ino")})
            End While
            rdr.Close()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
        cclose()

        sear.Clear()
        rdate.Value = Date.Now
        iname.Clear()
        iqty.Value = 1
        invdata.Rows.Clear()

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

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If iname.Text <> "" Then
            Dim Updated As Boolean
            For Each row As DataGridViewRow In invdata.Rows
                If CType(row.Cells(0).Value, String) = iname.Text Then
                    alert("العنصر موجود بالفاتورة!", 0)
                    Exit Sub
                End If
            Next

            If Not Updated Then
                invdata.Rows.Add({iname.Text, Val(iprice.Text), iqty.Value, (Val(iprice.Text) * iqty.Value) + (Val(itax.Text) / 100 * Val(iprice.Text)) * iqty.Value, Val(itax.Text), ino.Text})
            End If
            totalcost()
            iprice.Clear()
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If impinvno.Text = "" Then
            alert("أدخل رقم فاتورة المورد !", 0)
            Exit Sub
        End If

        Dim cmdd, cmddd As SqlCommand
        If invdata.RowCount = 0 Then
            alert("لا توجد عناصر بالفاتورة!", 0)
            Exit Sub
        End If
        Cursor = Cursors.WaitCursor
        connect()
        copen()
        Try
            cmd = New SqlCommand("INSERT INTO [purchases] (sdate,[user],invno,total,impname,impinvno) VALUES (@b,@c,@d,@e,@f,@g)", con)
            With cmd.Parameters
                .Add(New SqlParameter("@b", rdate.Value))
                .Add(New SqlParameter("@c", un))
                .Add(New SqlParameter("@d", invno.Text))
                .Add(New SqlParameter("@e", Val(tot.Text)))
                .Add(New SqlParameter("@f", impname.Text))
                .Add(New SqlParameter("@g", impinvno.Text))
                cmd.ExecuteNonQuery()
            End With

            For i As Integer = 0 To invdata.Rows.Count - 1
                cmd1 = New SqlCommand("INSERT INTO purchasesdet (invno,iname,iqty,iprice,ino,itax) VALUES (@a,@b,@c,@d,@e,@f)", con)
                With cmd1.Parameters
                    .Add(New SqlParameter("@a", invno.Text))
                    .Add(New SqlParameter("@b", invdata.Rows(i).Cells(0).Value.ToString))
                    .Add(New SqlParameter("@c", invdata.Rows(i).Cells(2).Value))
                    .Add(New SqlParameter("@d", invdata.Rows(i).Cells(1).Value))
                    .Add(New SqlParameter("@e", invdata.Rows(i).Cells(5).Value))
                    .Add(New SqlParameter("@f", invdata.Rows(i).Cells(4).Value))
                    cmd1.ExecuteNonQuery()
                End With

                cmdd = New SqlCommand("UPDATE stock SET qty = (qty + " & invdata.Rows(i).Cells(2).Value & ") WHERE name = '" & invdata.Rows(i).Cells(0).Value.ToString & "'", con)
                cmdd.ExecuteNonQuery()

                cmddd = New SqlCommand("UPDATE importers SET ibal = (ibal + " & invdata.Rows(i).Cells(3).Value & ") WHERE inamear = '" & impname.Text & "'", con)
                cmddd.ExecuteNonQuery()
            Next

            cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بإضافة كميات جديدة برقم فاتورة " & invno.Text & "', '" & nowdate() & "')", con)
            cmdact.ExecuteNonQuery()

            Cursor = Cursors.Default
            alert("تم إدخال الكمية بنجاح", 1)
            reset()
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
        cclose()
    End Sub

    Private Sub doctor_KeyDown(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Delete Then
            e.Handled = True
        End If
    End Sub

    Private Sub doctor_KeyPress(sender As Object, e As KeyPressEventArgs)
        e.Handled = True
    End Sub

    Private Sub idata_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles idata.CellClick
        If idata.Rows.Count > 0 Then
            iname.Text = idata.CurrentRow.Cells(0).Value
            ino.Text = idata.CurrentRow.Cells(3).Value
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        reset()
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

    Private Sub invdata_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles invdata.CellValueChanged
        totalcost()
    End Sub

    Private Sub invdata_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles invdata.RowsRemoved
        totalcost()
    End Sub

    Private Sub serchimp_Click(sender As Object, e As EventArgs) Handles serchimp.Click
        Searchimporter.frmtitle.Text = "بحث عن مورد"
        Searchimporter.form.Text = "Purchases"
        Searchimporter.ShowDialog()
    End Sub
End Class
