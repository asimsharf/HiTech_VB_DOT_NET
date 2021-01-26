Imports System.Drawing.Text
Imports System.Data.SqlClient
Imports System.IO

Public Class Labinvoice
    Public testing As String
    Public Sub teth()
        If RadioButton1.Checked = True Then
            If List.Items.Count > 0 Then
                teeth.Clear()
                For Each item As String In List.Items
                    teeth.Text += item.ToString & ","
                Next
                teeth.Text = teeth.Text.Trim.TrimEnd(",")
            End If
        ElseIf RadioButton2.Checked = True Then
            teeth.Text = "Up teeth"
        ElseIf RadioButton3.Checked = True Then
            teeth.Text = "Down teeth"
        ElseIf RadioButton4.Checked = True Then
            teeth.Text = "All teeth"
        End If
    End Sub

    Public Sub allfill()
        Cursor = Cursors.WaitCursor
        connect()
        copen()
        Try
            cmd1 = New SqlCommand("SELECT * FROM labrequests WHERE rid = '" & rid.Text & "'", con)
            Dim rd As SqlDataReader = cmd1.ExecuteReader
            While rd.Read
                techs.SelectedItem = rd("tname").ToString
                If rd("aorc").ToString = "Adult" Then
                    aorc.SelectedIndex = 0
                End If
                If rd("aorc").ToString = "Child" Then
                    aorc.SelectedIndex = 1
                End If
            End While


            cmd = New SqlCommand("SELECT reqdetails.*, labrequests.aorc, labrequests.tname FROM reqdetails INNER JOIN labrequests ON labrequests.rid = reqdetails.rid WHERE reqdetails.rid = " & Val(rid.Text) & "", con)
            Dim rdr As SqlDataReader = cmd.ExecuteReader
            If Not rdr.HasRows Then
                reset()
                Cursor = Cursors.Default
            End If

            data.Rows.Clear()
            While rdr.Read
                Dim gl As New SqlCommand("SELECT snamear FROM labservices WHERE scode  = '" & rdr("scode").ToString & "'", con)
                Dim sn As String = gl.ExecuteScalar
                data.Rows.Add({rdr("teeth"), rdr("scode"), sn, rdr("color"), rdr("note")})
            End While

            Dim words As String() = testing.Split(New Char() {","c})
            Dim word As String
            List.Items.Clear()
            For Each word In words
                List.Items.Add(word)
            Next

            Dim b As Button
            For i As Integer = 0 To List.Items.Count - 1
                Dim btn As Integer = List.Items(i)
                b = DirectCast(GroupBox5.Controls("b" & btn.ToString), Button)
                b.BackColor = Color.FromArgb(238, 144, 61)
            Next
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
        cclose()
    End Sub

    Public Sub fill()
        Cursor = Cursors.WaitCursor
        connect()
        Try
            copen()

            cmd = New SqlCommand("SELECT dname FROM doctors WHERE uname = '" & un & "'", con)
            doctor.Text = cmd.ExecuteScalar.ToString

            Dim gt As New SqlCommand("SELECT pid,pname,page FROM patients WHERE pid = " & pid.Text & "", con)
            Dim rdr As SqlDataReader = gt.ExecuteReader
            While rdr.Read
                pid.Text = rdr(0).ToString
                pname.Text = rdr(1).ToString
                page.Text = rdr(2)
            End While
            rdr.Close()

            cclose()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Public Sub reset()
        For Each bt As Button In GroupBox5.Controls
            bt.BackColor = Color.Black
        Next
        For Each bt1 As Button In GroupBox7.Controls
            bt1.BackColor = Color.Black
        Next
        RadioButton1.Checked = True
        clear(GroupBox2)
        clear(GroupBox3)
        clr.SelectedItem = Nothing
        connect()
        Try
            If con.State = ConnectionState.Closed Then con.Open()
            Dim cmx As New SqlCommand("SELECT rid FROM labrequests WHERE rid = (SELECT MAX(rid) FROM labrequests)", con)
            Dim nID As Integer = cmx.ExecuteScalar()
            If nID = 0 Then
                rid.Text = NextID(0)
            Else
                rid.Text = NextID(nID)
            End If
            If con.State = ConnectionState.Open Then con.Close()
        Catch ex As Exception

        End Try
        fill()
        noru.Text = "n"
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
        aorc.SelectedIndex = 0

        connect()
        Try
            copen()
            Dim gt1 As New SqlCommand("SELECT tname FROM technicians", con)
            Dim rdr1 As SqlDataReader = gt1.ExecuteReader
            techs.Items.Clear()
            While rdr1.Read
                techs.Items.Add(rdr1("tname").ToString)
            End While
            rdr1.Close()
            cclose()
        Catch ex As Exception

        End Try

        Try
            copen()
            Dim gt11 As New SqlCommand("SELECT color FROM colors", con)
            Dim rdr11 As SqlDataReader = gt11.ExecuteReader
            clr.Items.Clear()
            While rdr11.Read
                clr.Items.Add(rdr11("color").ToString)
            End While
            rdr11.Close()
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

    '//////////////////////////////////// Alults /////////////////////////////////////////

    Private Sub b1_Click(sender As Object, e As EventArgs) Handles b1.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("1") Then
                b1.BackColor = Color.Black
                List.Items.Remove("1")
            Else
                b1.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("1")
            End If
        Else
            For Each bt As Button In GroupBox5.Controls
                bt.BackColor = Color.Black
            Next
            b1.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("1")
        End If
        teth()
    End Sub

    Private Sub b2_Click(sender As Object, e As EventArgs) Handles b2.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("2") Then
                b2.BackColor = Color.Black
                List.Items.Remove("2")
            Else
                b2.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("2")
            End If
        Else
            For Each bt As Button In GroupBox5.Controls
                bt.BackColor = Color.Black
            Next
            b2.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("2")
        End If
        teth()
    End Sub

    Private Sub b3_Click(sender As Object, e As EventArgs) Handles b3.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("3") Then
                b3.BackColor = Color.Black
                List.Items.Remove("3")
            Else
                b3.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("3")
            End If
        Else
            For Each bt As Button In GroupBox5.Controls
                bt.BackColor = Color.Black
            Next
            b3.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("3")
        End If
        teth()
    End Sub

    Private Sub b4_Click(sender As Object, e As EventArgs) Handles b4.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("4") Then
                b4.BackColor = Color.Black
                List.Items.Remove("4")
            Else
                b4.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("4")
            End If
        Else
            For Each bt As Button In GroupBox5.Controls
                bt.BackColor = Color.Black
            Next
            b4.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("4")
        End If
        teth()
    End Sub

    Private Sub b5_Click(sender As Object, e As EventArgs) Handles b5.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("5") Then
                b5.BackColor = Color.Black
                List.Items.Remove("5")
            Else
                b5.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("5")
            End If
        Else
            For Each bt As Button In GroupBox5.Controls
                bt.BackColor = Color.Black
            Next
            b5.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("5")
        End If
        teth()
    End Sub

    Private Sub b6_Click(sender As Object, e As EventArgs) Handles b6.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("6") Then
                b6.BackColor = Color.Black
                List.Items.Remove("6")
            Else
                b6.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("6")
            End If
        Else
            For Each bt As Button In GroupBox5.Controls
                bt.BackColor = Color.Black
            Next
            b6.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("6")
        End If
        teth()
    End Sub

    Private Sub b7_Click(sender As Object, e As EventArgs) Handles b7.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("7") Then
                b7.BackColor = Color.Black
                List.Items.Remove("7")
            Else
                b7.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("7")
            End If
        Else
            For Each bt As Button In GroupBox5.Controls
                bt.BackColor = Color.Black
            Next
            b7.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("7")
        End If
        teth()
    End Sub

    Private Sub b8_Click(sender As Object, e As EventArgs) Handles b8.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("8") Then
                b8.BackColor = Color.Black
                List.Items.Remove("8")
            Else
                b8.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("8")
            End If
        Else
            For Each bt As Button In GroupBox5.Controls
                bt.BackColor = Color.Black
            Next
            b8.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("8")
        End If
        teth()
    End Sub

    Private Sub b9_Click(sender As Object, e As EventArgs) Handles b9.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("9") Then
                b9.BackColor = Color.Black
                List.Items.Remove("9")
            Else
                b9.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("9")
            End If
        Else
            For Each bt As Button In GroupBox5.Controls
                bt.BackColor = Color.Black
            Next
            b9.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("9")
        End If
        teth()
    End Sub

    Private Sub b10_Click(sender As Object, e As EventArgs) Handles b10.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("10") Then
                b10.BackColor = Color.Black
                List.Items.Remove("10")
            Else
                b10.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("10")
            End If
        Else
            For Each bt As Button In GroupBox5.Controls
                bt.BackColor = Color.Black
            Next
            b10.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("10")
        End If
        teth()
    End Sub

    Private Sub b11_Click(sender As Object, e As EventArgs) Handles b11.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("11") Then
                b11.BackColor = Color.Black
                List.Items.Remove("11")
            Else
                b11.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("11")
            End If
        Else
            For Each bt As Button In GroupBox5.Controls
                bt.BackColor = Color.Black
            Next
            b11.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("11")
        End If
        teth()
    End Sub

    Private Sub b12_Click(sender As Object, e As EventArgs) Handles b12.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("12") Then
                b12.BackColor = Color.Black
                List.Items.Remove("12")
            Else
                b12.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("12")
            End If
        Else
            For Each bt As Button In GroupBox5.Controls
                bt.BackColor = Color.Black
            Next
            b12.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("12")
        End If
        teth()
    End Sub

    Private Sub b13_Click(sender As Object, e As EventArgs) Handles b13.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("13") Then
                b13.BackColor = Color.Black
                List.Items.Remove("13")
            Else
                b13.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("13")
            End If
        Else
            For Each bt As Button In GroupBox5.Controls
                bt.BackColor = Color.Black
            Next
            b13.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("13")
        End If
        teth()
    End Sub

    Private Sub b14_Click(sender As Object, e As EventArgs) Handles b14.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("14") Then
                b14.BackColor = Color.Black
                List.Items.Remove("14")
            Else
                b14.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("14")
            End If
        Else
            For Each bt As Button In GroupBox5.Controls
                bt.BackColor = Color.Black
            Next
            b14.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("14")
        End If
        teth()
    End Sub

    Private Sub b15_Click(sender As Object, e As EventArgs) Handles b15.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("15") Then
                b15.BackColor = Color.Black
                List.Items.Remove("15")
            Else
                b15.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("15")
            End If
        Else
            For Each bt As Button In GroupBox5.Controls
                bt.BackColor = Color.Black
            Next
            b15.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("15")
        End If
        teth()
    End Sub

    Private Sub b16_Click(sender As Object, e As EventArgs) Handles b16.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("16") Then
                b16.BackColor = Color.Black
                List.Items.Remove("16")
            Else
                b16.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("16")
            End If
        Else
            For Each bt As Button In GroupBox5.Controls
                bt.BackColor = Color.Black
            Next
            b16.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("16")
        End If
        teth()
    End Sub

    Private Sub b17_Click(sender As Object, e As EventArgs) Handles b17.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("17") Then
                b17.BackColor = Color.Black
                List.Items.Remove("17")
            Else
                b17.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("17")
            End If
        Else
            For Each bt As Button In GroupBox5.Controls
                bt.BackColor = Color.Black
            Next
            b17.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("17")
        End If
        teth()
    End Sub

    Private Sub b18_Click(sender As Object, e As EventArgs) Handles b18.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("18") Then
                b18.BackColor = Color.Black
                List.Items.Remove("18")
            Else
                b18.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("18")
            End If
        Else
            For Each bt As Button In GroupBox5.Controls
                bt.BackColor = Color.Black
            Next
            b18.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("18")
        End If
        teth()
    End Sub

    Private Sub bc19_Click(sender As Object, e As EventArgs) Handles bc19.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("19") Then
                bc19.BackColor = Color.Black
                List.Items.Remove("19")
            Else
                bc19.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("19")
            End If
        Else
            For Each bt As Button In GroupBox7.Controls
                bt.BackColor = Color.Black
            Next
            bc19.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("19")
        End If
        teth()
    End Sub

    Private Sub bc20_Click(sender As Object, e As EventArgs) Handles bc20.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("20") Then
                bc20.BackColor = Color.Black
                List.Items.Remove("20")
            Else
                bc20.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("20")
            End If
        Else
            For Each bt As Button In GroupBox5.Controls
                bt.BackColor = Color.Black
            Next
            bc20.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("20")
        End If
        teth()
    End Sub

    Private Sub b21_Click(sender As Object, e As EventArgs) Handles b21.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("21") Then
                b21.BackColor = Color.Black
                List.Items.Remove("21")
            Else
                b21.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("21")
            End If
        Else
            For Each bt As Button In GroupBox5.Controls
                bt.BackColor = Color.Black
            Next
            b21.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("21")
        End If
        teth()
    End Sub

    Private Sub b22_Click(sender As Object, e As EventArgs) Handles b22.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("22") Then
                b22.BackColor = Color.Black
                List.Items.Remove("22")
            Else
                b22.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("22")
            End If
        Else
            For Each bt As Button In GroupBox5.Controls
                bt.BackColor = Color.Black
            Next
            b22.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("22")
        End If
        teth()
    End Sub

    Private Sub b23_Click(sender As Object, e As EventArgs) Handles b23.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("23") Then
                b23.BackColor = Color.Black
                List.Items.Remove("23")
            Else
                b23.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("23")
            End If
        Else
            For Each bt As Button In GroupBox5.Controls
                bt.BackColor = Color.Black
            Next
            b23.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("23")
        End If
        teth()
    End Sub

    Private Sub b24_Click(sender As Object, e As EventArgs) Handles b24.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("24") Then
                b24.BackColor = Color.Black
                List.Items.Remove("24")
            Else
                b24.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("24")
            End If
        Else
            For Each bt As Button In GroupBox5.Controls
                bt.BackColor = Color.Black
            Next
            b24.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("24")
        End If
        teth()
    End Sub

    Private Sub b25_Click(sender As Object, e As EventArgs) Handles b25.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("25") Then
                b25.BackColor = Color.Black
                List.Items.Remove("25")
            Else
                b25.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("25")
            End If
        Else
            For Each bt As Button In GroupBox5.Controls
                bt.BackColor = Color.Black
            Next
            b25.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("25")
        End If
        teth()
    End Sub

    Private Sub b26_Click(sender As Object, e As EventArgs) Handles b26.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("26") Then
                b26.BackColor = Color.Black
                List.Items.Remove("26")
            Else
                b26.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("26")
            End If
        Else
            For Each bt As Button In GroupBox5.Controls
                bt.BackColor = Color.Black
            Next
            b26.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("26")
        End If
        teth()
    End Sub

    Private Sub b27_Click(sender As Object, e As EventArgs) Handles b27.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("27") Then
                b27.BackColor = Color.Black
                List.Items.Remove("27")
            Else
                b27.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("27")
            End If
        Else
            For Each bt As Button In GroupBox5.Controls
                bt.BackColor = Color.Black
            Next
            b27.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("27")
        End If
        teth()
    End Sub

    Private Sub b28_Click(sender As Object, e As EventArgs) Handles b28.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("28") Then
                b28.BackColor = Color.Black
                List.Items.Remove("28")
            Else
                b28.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("28")
            End If
        Else
            For Each bt As Button In GroupBox5.Controls
                bt.BackColor = Color.Black
            Next
            b28.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("28")
        End If
        teth()
    End Sub

    Private Sub b29_Click(sender As Object, e As EventArgs) Handles b29.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("29") Then
                b29.BackColor = Color.Black
                List.Items.Remove("29")
            Else
                b29.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("29")
            End If
        Else
            For Each bt As Button In GroupBox5.Controls
                bt.BackColor = Color.Black
            Next
            b29.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("29")
        End If
        teth()
    End Sub

    Private Sub b30_Click(sender As Object, e As EventArgs) Handles b30.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("30") Then
                b30.BackColor = Color.Black
                List.Items.Remove("30")
            Else
                b30.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("30")
            End If
        Else
            For Each bt As Button In GroupBox5.Controls
                bt.BackColor = Color.Black
            Next
            b30.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("30")
        End If
        teth()
    End Sub

    Private Sub b31_Click(sender As Object, e As EventArgs) Handles b31.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("31") Then
                b31.BackColor = Color.Black
                List.Items.Remove("31")
            Else
                b31.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("31")
            End If
        Else
            For Each bt As Button In GroupBox5.Controls
                bt.BackColor = Color.Black
            Next
            b31.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("31")
        End If
        teth()
    End Sub

    Private Sub b32_Click(sender As Object, e As EventArgs) Handles b32.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("32") Then
                b32.BackColor = Color.Black
                List.Items.Remove("32")
            Else
                b32.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("32")
            End If
        Else
            For Each bt As Button In GroupBox5.Controls
                bt.BackColor = Color.Black
            Next
            b32.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("32")
        End If
        teth()
    End Sub

    '/////////////////////////////////////// Childs //////////////////////////////////////

    Private Sub bc1_Click(sender As Object, e As EventArgs) Handles bc1.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("1") Then
                bc1.BackColor = Color.Black
                List.Items.Remove("1")
            Else
                bc1.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("1")
            End If
        Else
            For Each bt As Button In GroupBox7.Controls
                bt.BackColor = Color.Black
            Next
            bc1.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("1")
        End If
        teth()
    End Sub

    Private Sub bc2_Click(sender As Object, e As EventArgs) Handles bc2.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("2") Then
                bc2.BackColor = Color.Black
                List.Items.Remove("2")
            Else
                bc2.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("2")
            End If
        Else
            For Each bt As Button In GroupBox7.Controls
                bt.BackColor = Color.Black
            Next
            bc2.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("2")
        End If
        teth()
    End Sub

    Private Sub bc3_Click(sender As Object, e As EventArgs) Handles bc3.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("3") Then
                bc3.BackColor = Color.Black
                List.Items.Remove("3")
            Else
                bc3.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("3")
            End If
        Else
            For Each bt As Button In GroupBox7.Controls
                bt.BackColor = Color.Black
            Next
            bc3.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("3")
        End If
        teth()
    End Sub

    Private Sub bc4_Click(sender As Object, e As EventArgs) Handles bc4.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("4") Then
                bc4.BackColor = Color.Black
                List.Items.Remove("4")
            Else
                bc4.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("4")
            End If
        Else
            For Each bt As Button In GroupBox7.Controls
                bt.BackColor = Color.Black
            Next
            bc4.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("4")
        End If
        teth()
    End Sub

    Private Sub bc5_Click(sender As Object, e As EventArgs) Handles bc5.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("5") Then
                bc5.BackColor = Color.Black
                List.Items.Remove("5")
            Else
                bc5.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("5")
            End If
        Else
            For Each bt As Button In GroupBox7.Controls
                bt.BackColor = Color.Black
            Next
            bc5.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("5")
        End If
        teth()
    End Sub

    Private Sub bc6_Click(sender As Object, e As EventArgs) Handles bc6.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("6") Then
                bc6.BackColor = Color.Black
                List.Items.Remove("6")
            Else
                bc6.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("6")
            End If
        Else
            For Each bt As Button In GroupBox7.Controls
                bt.BackColor = Color.Black
            Next
            bc6.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("6")
        End If
        teth()
    End Sub

    Private Sub bc7_Click(sender As Object, e As EventArgs) Handles bc7.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("7") Then
                bc7.BackColor = Color.Black
                List.Items.Remove("7")
            Else
                bc7.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("7")
            End If
        Else
            For Each bt As Button In GroupBox7.Controls
                bt.BackColor = Color.Black
            Next
            bc7.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("7")
        End If
        teth()
    End Sub

    Private Sub bc8_Click(sender As Object, e As EventArgs) Handles bc8.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("8") Then
                bc8.BackColor = Color.Black
                List.Items.Remove("8")
            Else
                bc8.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("8")
            End If
        Else
            For Each bt As Button In GroupBox7.Controls
                bt.BackColor = Color.Black
            Next
            bc8.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("8")
        End If
        teth()
    End Sub

    Private Sub bc9_Click(sender As Object, e As EventArgs) Handles bc9.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("9") Then
                bc9.BackColor = Color.Black
                List.Items.Remove("9")
            Else
                bc9.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("9")
            End If
        Else
            For Each bt As Button In GroupBox7.Controls
                bt.BackColor = Color.Black
            Next
            bc9.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("9")
        End If
        teth()
    End Sub

    Private Sub bc10_Click(sender As Object, e As EventArgs) Handles bc10.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("10") Then
                bc10.BackColor = Color.Black
                List.Items.Remove("10")
            Else
                bc10.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("10")
            End If
        Else
            For Each bt As Button In GroupBox7.Controls
                bt.BackColor = Color.Black
            Next
            bc10.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("10")
        End If
        teth()
    End Sub

    Private Sub bc11_Click(sender As Object, e As EventArgs) Handles bc11.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("11") Then
                bc11.BackColor = Color.Black
                List.Items.Remove("11")
            Else
                bc11.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("11")
            End If
        Else
            For Each bt As Button In GroupBox7.Controls
                bt.BackColor = Color.Black
            Next
            bc11.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("11")
        End If
        teth()
    End Sub

    Private Sub bc12_Click(sender As Object, e As EventArgs) Handles bc12.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("12") Then
                bc12.BackColor = Color.Black
                List.Items.Remove("12")
            Else
                bc12.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("12")
            End If
        Else
            For Each bt As Button In GroupBox7.Controls
                bt.BackColor = Color.Black
            Next
            bc12.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("12")
        End If
        teth()
    End Sub

    Private Sub bc13_Click(sender As Object, e As EventArgs) Handles bc13.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("13") Then
                bc13.BackColor = Color.Black
                List.Items.Remove("13")
            Else
                bc13.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("13")
            End If
        Else
            For Each bt As Button In GroupBox7.Controls
                bt.BackColor = Color.Black
            Next
            bc13.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("13")
        End If
        teth()
    End Sub

    Private Sub bc14_Click(sender As Object, e As EventArgs) Handles bc14.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("14") Then
                bc14.BackColor = Color.Black
                List.Items.Remove("14")
            Else
                bc14.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("14")
            End If
        Else
            For Each bt As Button In GroupBox7.Controls
                bt.BackColor = Color.Black
            Next
            bc14.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("14")
        End If
        teth()
    End Sub

    Private Sub bc15_Click(sender As Object, e As EventArgs) Handles bc15.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("15") Then
                bc15.BackColor = Color.Black
                List.Items.Remove("15")
            Else
                bc15.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("15")
            End If
        Else
            For Each bt As Button In GroupBox7.Controls
                bt.BackColor = Color.Black
            Next
            bc15.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("15")
        End If
        teth()
    End Sub

    Private Sub bc16_Click(sender As Object, e As EventArgs) Handles bc16.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("16") Then
                bc16.BackColor = Color.Black
                List.Items.Remove("16")
            Else
                bc16.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("16")
            End If
        Else
            For Each bt As Button In GroupBox7.Controls
                bt.BackColor = Color.Black
            Next
            bc16.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("16")
        End If
        teth()
    End Sub

    Private Sub bc17_Click(sender As Object, e As EventArgs) Handles bc17.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("17") Then
                bc17.BackColor = Color.Black
                List.Items.Remove("17")
            Else
                bc17.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("17")
            End If
        Else
            For Each bt As Button In GroupBox7.Controls
                bt.BackColor = Color.Black
            Next
            bc17.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("17")
        End If
        teth()
    End Sub

    Private Sub bc18_Click(sender As Object, e As EventArgs) Handles bc18.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("18") Then
                bc18.BackColor = Color.Black
                List.Items.Remove("18")
            Else
                bc18.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("18")
            End If
        Else
            For Each bt As Button In GroupBox7.Controls
                bt.BackColor = Color.Black
            Next
            bc18.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("18")
        End If
        teth()
    End Sub

    Private Sub b19_Click(sender As Object, e As EventArgs) Handles b19.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("19") Then
                b19.BackColor = Color.Black
                List.Items.Remove("19")
            Else
                b19.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("19")
            End If
        Else
            For Each bt As Button In GroupBox5.Controls
                bt.BackColor = Color.Black
            Next
            b19.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("19")
        End If
        teth()
    End Sub

    Private Sub b20_Click(sender As Object, e As EventArgs) Handles b20.Click
        RadioButton1.Checked = True
        If Control.ModifierKeys = Keys.Control Then
            If List.Items.Contains("20") Then
                b20.BackColor = Color.Black
                List.Items.Remove("20")
            Else
                b20.BackColor = Color.FromArgb(238, 144, 61)
                List.Items.Add("20")
            End If
        Else
            For Each bt As Button In GroupBox5.Controls
                bt.BackColor = Color.Black
            Next
            b20.BackColor = Color.FromArgb(238, 144, 61)
            List.Items.Clear()
            List.Items.Add("20")
        End If
        teth()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        If teeth.Text = "" Or sname.Text = "" Or clr.SelectedItem = Nothing Or techs.SelectedItem = "" Then
            alert("الحقول المشار إليها بعلامة * مطلوبة!", 0)
            Exit Sub
        End If

        data.Rows.Add({teeth.Text, scode.Text, sname.Text, clr.SelectedItem, note.Text})
        clear(GroupBox2)
        clr.SelectedItem = Nothing
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        If data.RowCount = 0 Then
            alert("لا توجد عناصر في الطلب!", 0)
            Exit Sub
        End If

        If techs.SelectedItem = Nothing Then
            alert("يرجى اختيار الفني!", 0)
            Exit Sub
        End If

        connect()
        Try
            copen()
            Dim icmd As New SqlCommand("INSERT INTO labrequests (rid,pid,dname,tname,cdate,sdate,rdate,tdate,frdate,status,aorc) VALUES (@a,@b,@c,@d,@e,@f,@g,@h,@i,@j,@k)", con)
            With icmd.Parameters
                .Add(New SqlParameter("@a", rid.Text))
                .Add(New SqlParameter("@b", pid.Text))
                .Add(New SqlParameter("@c", doctor.Text))
                .Add(New SqlParameter("@d", techs.SelectedItem))
                .Add(New SqlParameter("@e", nowdate))
                .Add(New SqlParameter("@f", ""))
                .Add(New SqlParameter("@g", ""))
                .Add(New SqlParameter("@h", ""))
                .Add(New SqlParameter("@i", ""))
                .Add(New SqlParameter("@j", "تم إنشاء الطلب"))
                .Add(New SqlParameter("@k", aorc.SelectedItem))
            End With
            icmd.ExecuteNonQuery()

            For Each row As DataGridViewRow In data.Rows
                If Not row.IsNewRow Then
                    If row.Cells(2).Value <> "" Then
                        cmd1 = New SqlCommand("INSERT INTO reqdetails (rid,teeth,scode,color,note) VALUES (@a, @b, @c, @d, @e)", con)
                        With cmd1.Parameters
                            .Add(New SqlParameter("@a", rid.Text))
                            .Add(New SqlParameter("@b", row.Cells(0).Value))
                            .Add(New SqlParameter("@c", row.Cells(1).Value))
                            .Add(New SqlParameter("@d", row.Cells(3).Value))
                            .Add(New SqlParameter("@e", row.Cells(4).Value))
                        End With
                        cmd1.ExecuteNonQuery()
                    End If
                End If
            Next

            cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بإضافة طلب جديد بالرقم " & rid.Text & "', '" & nowdate() & "')", con)
            cmdact.ExecuteNonQuery()
            Cursor = Cursors.Default
            alert("تم إدخال بيانات الطلب بنجاح", 1)
            reset()
            cclose()
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        If data.RowCount = 0 Then
            alert("لا توجد عناصر في الطلب!", 0)
            Exit Sub
        End If

        If techs.SelectedItem = Nothing Then
            alert("يرجى اختيار الفني!", 0)
            Exit Sub
        End If

        connect()
        Try
            copen()
            Dim icmd As New SqlCommand("UPDATE labrequests SET tname=@a, aorc=@b WHERE rid='" & rid.Text & "'", con)
            With icmd.Parameters
                .Add(New SqlParameter("@a", techs.SelectedItem))
                .Add(New SqlParameter("@b", aorc.SelectedItem))
            End With
            icmd.ExecuteNonQuery()

            Dim dl As New SqlCommand("DELETE FROM reqdetails WHERE rid = '" & rid.Text & "'", con)
            dl.ExecuteNonQuery()

            For Each row As DataGridViewRow In data.Rows
                If Not row.IsNewRow Then
                    If row.Cells(2).Value <> "" Then
                        cmd1 = New SqlCommand("INSERT INTO reqdetails (rid,teeth,scode,color,note) VALUES (@a, @b, @c, @d, @e)", con)
                        With cmd1.Parameters
                            .Add(New SqlParameter("@a", rid.Text))
                            .Add(New SqlParameter("@b", row.Cells(0).Value))
                            .Add(New SqlParameter("@c", row.Cells(1).Value))
                            .Add(New SqlParameter("@d", row.Cells(3).Value))
                            .Add(New SqlParameter("@e", row.Cells(4).Value))
                        End With
                        cmd1.ExecuteNonQuery()
                    End If
                End If
            Next

            cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بتعديل بيانات الطلب الرقم " & rid.Text & "', '" & nowdate() & "')", con)
            cmdact.ExecuteNonQuery()
            Cursor = Cursors.Default
            alert("تم تعديل بيانات الطلب بنجاح", 1)
            reset()
            cclose()
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Confirm.table.Text = "labrequests"
        Confirm.field.Text = "rid"
        Confirm.id.Text = rid.Text
        Confirm.ShowDialog()
        allfill()
    End Sub

    Private Sub noru_TextChanged(sender As Object, e As EventArgs) Handles noru.TextChanged
        If noru.Text = "n" Then
            Button4.Enabled = True
            Button6.Enabled = False
            Button7.Enabled = False
            Button8.Enabled = False
        ElseIf noru.Text = "u" Then
            Button4.Enabled = False
            Button6.Enabled = True
            Button7.Enabled = True
            Button8.Enabled = True
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Searchrequest.frmtitle.Text = "التركيبات السابقة للمريض"
        Searchrequest.pid2.Text = pid.Text
        Searchrequest.ShowDialog()
    End Sub

    Private Sub pid_TextChanged(sender As Object, e As EventArgs) Handles pid.TextChanged
        fill()
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Cursor = Cursors.WaitCursor
        ' Checkrep.cid.Text = cid.Text
        Checkrep.frmtitle.Text = "تقرير زيارة مريض"
        Checkrep.Show()
        If Checkrep.WindowState = FormWindowState.Minimized Then
            Checkrep.WindowState = FormWindowState.Normal
        End If
        Checkrep.BringToFront()
        Cursor = Cursors.Default
    End Sub

    Private Sub RadioButton2_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton2.CheckedChanged
        If aorc.SelectedIndex = 0 Then
            List.Items.Clear()
            For Each bt As Button In GroupBox5.Controls
                bt.BackColor = Color.Black
            Next
            For x As Integer = 1 To 16
                List.Items.Add(x)
            Next
            teth()
            Dim b As Button
            For i As Integer = 0 To List.Items.Count - 1
                Dim btn As Integer = List.Items(i)
                b = DirectCast(GroupBox5.Controls("b" & btn.ToString), Button)
                b.BackColor = Color.FromArgb(238, 144, 61)
            Next
        Else

            List.Items.Clear()
            For Each bt As Button In GroupBox7.Controls
                bt.BackColor = Color.Black
            Next
            For x As Integer = 1 To 10
                List.Items.Add(x)
            Next
            teth()
            Dim b As Button
            For i As Integer = 0 To List.Items.Count - 1
                Dim btn As Integer = List.Items(i)
                b = DirectCast(GroupBox7.Controls("bc" & btn.ToString), Button)
                b.BackColor = Color.FromArgb(238, 144, 61)
            Next
        End If
    End Sub

    Private Sub RadioButton1_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton1.CheckedChanged
        If aorc.SelectedIndex = 0 Then
            teeth.Clear()
            List.Items.Clear()
            For Each bt As Button In GroupBox5.Controls
                bt.BackColor = Color.Black
            Next
        Else
            teeth.Clear()
            List.Items.Clear()
            For Each bt As Button In GroupBox7.Controls
                bt.BackColor = Color.Black
            Next
        End If
    End Sub

    Private Sub RadioButton3_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton3.CheckedChanged
        If aorc.SelectedIndex = 0 Then
            teeth.Clear()
            List.Items.Clear()
            For Each bt As Button In GroupBox5.Controls
                bt.BackColor = Color.Black
            Next
            For x As Integer = 17 To 32
                List.Items.Add(x)
            Next
            teth()
            Dim b As Button
            For i As Integer = 0 To List.Items.Count - 1
                Dim btn As Integer = List.Items(i)
                b = DirectCast(GroupBox5.Controls("b" & btn.ToString), Button)
                b.BackColor = Color.FromArgb(238, 144, 61)
            Next

        Else
            teeth.Clear()
            List.Items.Clear()
            For Each bt As Button In GroupBox7.Controls
                bt.BackColor = Color.Black
            Next
            For x As Integer = 11 To 20
                List.Items.Add(x)
            Next
            teth()
            Dim b As Button
            For i As Integer = 0 To List.Items.Count - 1
                Dim btn As Integer = List.Items(i)
                b = DirectCast(GroupBox7.Controls("bc" & btn.ToString), Button)
                b.BackColor = Color.FromArgb(238, 144, 61)
            Next
        End If
    End Sub

    Private Sub RadioButton4_CheckedChanged(sender As Object, e As EventArgs) Handles RadioButton4.CheckedChanged
        If aorc.SelectedIndex = 0 Then
            List.Items.Clear()
            For Each bt As Button In GroupBox5.Controls
                bt.BackColor = Color.Black
            Next
            For x As Integer = 1 To 32
                List.Items.Add(x)
            Next
            teth()
            Dim b As Button
            For i As Integer = 0 To List.Items.Count - 1
                Dim btn As Integer = List.Items(i)
                b = DirectCast(GroupBox5.Controls("b" & btn.ToString), Button)
                b.BackColor = Color.FromArgb(238, 144, 61)
            Next

        Else
            List.Items.Clear()
            For Each bt As Button In GroupBox7.Controls
                bt.BackColor = Color.Black
            Next
            For x As Integer = 1 To 20
                List.Items.Add(x)
            Next
            teth()
            Dim b As Button
            For i As Integer = 0 To List.Items.Count - 1
                Dim btn As Integer = List.Items(i)
                b = DirectCast(GroupBox7.Controls("bc" & btn.ToString), Button)
                b.BackColor = Color.FromArgb(238, 144, 61)
            Next
        End If
    End Sub

    Private Sub aorc_SelectedIndexChanged(sender As Object, e As EventArgs) Handles aorc.SelectedIndexChanged
        RadioButton1.Checked = True
        If aorc.SelectedIndex = 0 Then
            List.Items.Clear()
            teeth.Clear()
            For Each bt As Button In GroupBox5.Controls
                bt.BackColor = Color.Black
            Next
            GroupBox5.Visible = True
            GroupBox7.Visible = False
        Else
            List.Items.Clear()
            teeth.Clear()
            For Each bt As Button In GroupBox7.Controls
                bt.BackColor = Color.Black
            Next
            GroupBox7.Visible = True
            GroupBox5.Visible = False
        End If
    End Sub

    Private Sub serch2_Click(sender As Object, e As EventArgs) Handles serch2.Click
        Cursor = Cursors.WaitCursor
        connect()
        copen()
        Try
            cmd = New SqlCommand("SELECT snamear FROM labservices WHERE scode = '" & scode.Text & "'", con)
            sname.Text = cmd.ExecuteScalar.ToString
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
        cclose()
    End Sub

    Private Sub scode_TextChanged(sender As Object, e As EventArgs) Handles scode.TextChanged
        AcceptButton = serch2
    End Sub

    Private Sub rid_TextChanged(sender As Object, e As EventArgs) Handles rid.TextChanged
        If noru.Text = "u" Then
            allfill()
        End If
    End Sub

    Private Sub data_SelectionChanged(sender As Object, e As EventArgs) Handles data.SelectionChanged
        If data.RowCount > 0 Then
            If data.CurrentRow.Cells(0).Value = "Up teeth" Then
                RadioButton2.Checked = True
            ElseIf data.CurrentRow.Cells(0).Value = "Down teeth" Then
                RadioButton3.Checked = True
            ElseIf data.CurrentRow.Cells(0).Value = "All teeth" Then
                RadioButton4.Checked = True
            Else
                testing = data.CurrentRow.Cells(0).Value
                Dim words As String() = testing.Split(New Char() {","c})
                Dim word As String
                List.Items.Clear()
                For Each word In words
                    List.Items.Add(word)
                Next
                RadioButton1.Checked = True
            End If

            teeth.Text = data.CurrentRow.Cells(0).Value
            scode.Text = data.CurrentRow.Cells(1).Value
            sname.Text = data.CurrentRow.Cells(2).Value
            clr.SelectedItem = data.CurrentRow.Cells(3).Value
            note.Text = data.CurrentRow.Cells(4).Value
        End If
    End Sub

End Class