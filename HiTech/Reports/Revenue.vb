Imports System.Drawing.Text
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class Revenue

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
        asdoctors.Checked = True
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If alldoctors.Checked = True Then
            Dim cr As New ReportDocument
            Dim logOnInfo As New TableLogOnInfo
            cr.Load("reports\Alldoctorsvenue.rpt")
            Try
                With logOnInfo.ConnectionInfo
                    .ServerName = server
                    .DatabaseName = db

                    If userid = "" Then
                        .IntegratedSecurity = True
                        '.UserID = userid
                        '.Password = passw
                    Else
                        .IntegratedSecurity = False
                        .UserID = userid
                        .Password = passw
                    End If

                End With
                cr.Database.Tables(0).ApplyLogOnInfo(logOnInfo)
                cr.Refresh()
                cr.SetParameterValue("d1", d1.Value.ToString("yyyy-MM-dd"))
                cr.SetParameterValue("d2", d2.Value.ToString("yyyy-MM-dd"))
                crv.ReportSource = cr
            Catch ex As Exception
                Exit Sub
            End Try
        End If



        If specdoctor.Checked = True Then
            If dname.Text = "" Then
                alert("الرجاء اختيار الطبيب!", 0)
                Exit Sub
            End If

            Dim cr As New ReportDocument
            Dim logOnInfo As New TableLogOnInfo
            cr.Load("reports\Doctorvenue.rpt")
            Try
                With logOnInfo.ConnectionInfo
                    .ServerName = server
                    .DatabaseName = db

                    If userid = "" Then
                        .IntegratedSecurity = True
                        '.UserID = userid
                        '.Password = passw
                    Else
                        .IntegratedSecurity = False
                        .UserID = userid
                        .Password = passw
                    End If

                End With
                cr.Database.Tables(0).ApplyLogOnInfo(logOnInfo)
                cr.Refresh()
                cr.SetParameterValue("doctor", dname.Text)
                cr.SetParameterValue("d1", d1.Value.ToString("yyyy-MM-dd"))
                cr.SetParameterValue("d2", d2.Value.ToString("yyyy-MM-dd"))
                crv.ReportSource = cr
            Catch ex As Exception
                Exit Sub
            End Try
        End If



        If allusers.Checked = True Then
            Dim cr As New ReportDocument
            Dim logOnInfo As New TableLogOnInfo
            cr.Load("reports\Allusersvenue.rpt")
            Try
                With logOnInfo.ConnectionInfo
                    .ServerName = server
                    .DatabaseName = db

                    If userid = "" Then
                        .IntegratedSecurity = True
                        '.UserID = userid
                        '.Password = passw
                    Else
                        .IntegratedSecurity = False
                        .UserID = userid
                        .Password = passw
                    End If

                End With
                cr.Database.Tables(0).ApplyLogOnInfo(logOnInfo)
                cr.Refresh()
                cr.SetParameterValue("d1", d1.Value.ToString("yyyy-MM-dd"))
                cr.SetParameterValue("d2", d2.Value.ToString("yyyy-MM-dd"))
                crv.ReportSource = cr
            Catch ex As Exception
                Exit Sub
            End Try
        End If



        If specuser.Checked = True Then
            If uname.Text = "" Then
                alert("الرجاء اختيار المستخدم!", 0)
                Exit Sub
            End If

            Dim cr As New ReportDocument
            Dim logOnInfo As New TableLogOnInfo
            cr.Load("reports\Uservenue.rpt")
            Try
                With logOnInfo.ConnectionInfo
                    .ServerName = server
                    .DatabaseName = db

                    If userid = "" Then
                        .IntegratedSecurity = True
                        '.UserID = userid
                        '.Password = passw
                    Else
                        .IntegratedSecurity = False
                        .UserID = userid
                        .Password = passw
                    End If

                End With
                cr.Database.Tables(0).ApplyLogOnInfo(logOnInfo)
                cr.Refresh()
                cr.SetParameterValue("uname", uname.Text)
                cr.SetParameterValue("d1", d1.Value.ToString("yyyy-MM-dd"))
                cr.SetParameterValue("d2", d2.Value.ToString("yyyy-MM-dd"))
                crv.ReportSource = cr
            Catch ex As Exception
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub asdoctors_CheckedChanged(sender As Object, e As EventArgs) Handles asdoctors.CheckedChanged
        If asdoctors.Checked = True Then
            alldoctors.Checked = True
            asusers.Checked = False
            uname.Clear()
            allusers.Checked = False
            specuser.Checked = False
            asdoctors.Enabled = True
            GroupBox1.Enabled = True
            GroupBox3.Enabled = False
        End If
    End Sub

    Private Sub asusers_CheckedChanged(sender As Object, e As EventArgs) Handles asusers.CheckedChanged
        If asusers.Checked = True Then
            allusers.Checked = True
            asdoctors.Checked = False
            dname.Clear()
            alldoctors.Checked = False
            specdoctor.Checked = False
            GroupBox1.Enabled = False
            GroupBox3.Enabled = True
        End If
    End Sub

    Private Sub alldoctors_CheckedChanged(sender As Object, e As EventArgs) Handles alldoctors.CheckedChanged
        If alldoctors.Checked = True Then
            serchd.Enabled = False
            dname.Clear()
            dname.Enabled = False
        End If
    End Sub

    Private Sub specdoctor_CheckedChanged(sender As Object, e As EventArgs) Handles specdoctor.CheckedChanged
        If specdoctor.Checked = True Then
            serchd.Enabled = True
            dname.Enabled = True
        End If
    End Sub

    Private Sub allusers_CheckedChanged(sender As Object, e As EventArgs) Handles allusers.CheckedChanged
        If allusers.Checked = True Then
            serchu.Enabled = False
            uname.Clear()
            uname.Enabled = False
        End If
    End Sub

    Private Sub specuser_CheckedChanged(sender As Object, e As EventArgs) Handles specuser.CheckedChanged
        If specuser.Checked = True Then
            serchu.Enabled = True
            uname.Enabled = True
        End If
    End Sub

    Private Sub serchd_Click(sender As Object, e As EventArgs) Handles serchd.Click
        Searchdoctor.frmtitle.Text = "بحث عن طبيب"
        Searchdoctor.form.Text = "Revenue"
        Searchdoctor.ShowDialog()
    End Sub

    Private Sub serchu_Click(sender As Object, e As EventArgs) Handles serchu.Click
        Searchuser.frmtitle.Text = "بحث عن مستخدم"
        Searchuser.form.Text = "Revenue"
        Searchuser.ShowDialog()
    End Sub
End Class
