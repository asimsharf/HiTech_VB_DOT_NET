Imports System.Drawing.Text
Imports System.Data.SqlClient

Public Class Clinicrecord
    '//////////////////////////////////////////// Form Load ////////////////////////////////////////////////
    Private Sub Clinics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 140
        changefont(Panel1)
        Cursor = Cursors.WaitCursor
        connect()
        copen()
        Dim gt As SqlCommand
        Try
            Dim dn As New SqlCommand("select dname from doctors where uname = '" & un & "'", con)
            Dim dcn As String = dn.ExecuteScalar.ToString
            gt = New SqlCommand("SELECT cid, pname, cdate FROM clinic WHERE doctor = '" & dcn & "' ORDER BY cdate DESC", con)
            Dim rdr As SqlDataReader = gt.ExecuteReader
            data.Rows.Clear()
            While rdr.Read
                data.Rows.Add({rdr(0), rdr(1), rdr(2)})
            End While
            rdr.Close()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
        cclose()
    End Sub

    Private Sub sear_TextChanged(sender As Object, e As EventArgs) Handles sear.TextChanged
        Try
            For Each row As DataGridViewRow In data.Rows
                If row.Cells(0).Value = Val(sear.Text) Or row.Cells(1).Value Like "*" & sear.Text & "*" Then
                    data.CurrentRow.Selected = False
                    row.Selected = True
                    data.FirstDisplayedScrollingRowIndex = row.Index
                    sear.Focus()
                    Exit For
                End If
            Next
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If data.RowCount > 0 Then
            Cursor = Cursors.WaitCursor
            Checkrep.cid.Text = data.CurrentRow.Cells(0).Value.ToString
            Checkrep.frmtitle.Text = "تقرير زيارة مريض"
            Checkrep.Show()
            If Checkrep.WindowState = FormWindowState.Minimized Then
                Checkrep.WindowState = FormWindowState.Normal
            End If
            Checkrep.BringToFront()
            Cursor = Cursors.Default
        End If
    End Sub
End Class
