Imports System.Drawing.Text
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class Invoicesrep2

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
        connect()
        Try
            copen()
            Dim gt As SqlCommand = New SqlCommand("SELECT nat FROM nats ORDER BY id", con)
            Dim rdr As SqlDataReader = gt.ExecuteReader
            nat.Items.Clear()
            While rdr.Read
                nat.Items.Add(rdr(0))
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If allnats.Checked = True Then
            Dim cr As New ReportDocument
            Dim logOnInfo As New TableLogOnInfo
            cr.Load("reports\Taxinvoices_all.rpt")
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
        ElseIf specnat.Checked = True Then
            Dim cr As New ReportDocument
            Dim logOnInfo As New TableLogOnInfo
            cr.Load("reports\Taxinvoices.rpt")
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
                cr.SetParameterValue("nat", nat.SelectedItem)
                crv.ReportSource = cr
            Catch ex As Exception
                Exit Sub
            End Try
        End If
    End Sub

    Private Sub allnats_CheckedChanged(sender As Object, e As EventArgs) Handles allnats.CheckedChanged
        If allnats.Checked = True Then
            nat.Enabled = False
            serchn.Enabled = False
        End If
    End Sub

    Private Sub specnat_CheckedChanged(sender As Object, e As EventArgs) Handles specnat.CheckedChanged
        If specnat.Checked = True Then
            nat.Enabled = True
            serchn.Enabled = True
        End If
    End Sub
End Class
