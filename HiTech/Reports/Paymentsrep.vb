Imports System.Drawing.Text
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class Paymentsrep

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
        Dim cr As New ReportDocument
        Dim logOnInfo As New TableLogOnInfo
        If alldoctors.Checked = True Then
            cr.Load("reports\Alldoctorsinvoices2.rpt")
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
        ElseIf specdoctor.Checked = True Then
            cr.Load("reports\Doctorinvoices2.rpt")
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
                cr.SetParameterValue("dname", dname.Text)
                crv.ReportSource = cr
            Catch ex As Exception
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub alldoctors_CheckedChanged(sender As Object, e As EventArgs) Handles alldoctors.CheckedChanged
        If alldoctors.Checked = True Then
            dname.Enabled = False
            serchd.Enabled = False
        End If
    End Sub

    Private Sub specdoctor_CheckedChanged(sender As Object, e As EventArgs) Handles specdoctor.CheckedChanged
        If specdoctor.Checked = True Then
            dname.Enabled = True
            serchd.Enabled = True
        End If
    End Sub

    Private Sub serchd_Click(sender As Object, e As EventArgs) Handles serchd.Click
        Searchdoctor.frmtitle.Text = "بحث عن طبيب"
        Searchdoctor.form.Text = "Paymentsrep"
        Searchdoctor.ShowDialog()
    End Sub
End Class
