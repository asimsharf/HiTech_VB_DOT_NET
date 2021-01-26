Imports System.Drawing.Text
Imports System.Data.SqlClient

Public Class Searchuser
    '//////////////////////////////////////////// Form Load ////////////////////////////////////////////////
    Private Sub Searchdoctor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 140
        changefont(Panel1)
        Cursor = Cursors.WaitCursor
        connect()
        copen()
        Dim gt As SqlCommand
        Try
            gt = New SqlCommand("SELECT id, uname, ugroup FROM users WHERE ustat = 'Active'", con)
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

    Private Sub data_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles data.CellClick
        If data.RowCount > 0 Then
            If form.Text = "Revenue" Then
                Revenue.uname.Text = data.CurrentRow.Cells(1).Value.ToString
            End If
            Me.Close()
        End If
    End Sub
End Class
