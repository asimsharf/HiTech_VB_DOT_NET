Imports System.Drawing.Text
Imports System.Data.SqlClient

Public Class Searchrequest
    '//////////////////////////////////////////// Form Load ////////////////////////////////////////////////
    Private Sub Clinics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 140
        changefont(Panel1)
        Cursor = Cursors.WaitCursor
        connect()
        copen()
        Dim gt As SqlCommand
        Try
            gt = New SqlCommand("SELECT rid,cdate FROM labrequests WHERE pid = '" & pid2.Text & "' ORDER BY cdate DESC", con)
            Dim rdr As SqlDataReader = gt.ExecuteReader
            data.Rows.Clear()
            While rdr.Read
                data.Rows.Add({rdr(0), rdr(1)})
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
                If row.Cells(0).Value = Val(sear.Text) Or row.Cells(1).Value.ToString Like "*" & sear.Text & "*" Then
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

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub data_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles data.CellClick
        If data.RowCount > 0 Then
            Labinvoice.rid.Clear()
            Labinvoice.noru.Clear()
            Labinvoice.noru.Text = "u"
            Labinvoice.rid.Text = data.CurrentRow.Cells(0).Value
            Me.Close()
        End If
    End Sub
End Class
