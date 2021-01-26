Imports System.Drawing.Text
Imports System.Data.SqlClient

Public Class Reqlist
    Public dr As String
    Public Sub fill()
        connect()
        copen()
        Dim gt As SqlCommand
        Try
            gt = New SqlCommand("SELECT labrequests.*, patients.pname FROM labrequests INNER JOIN patients ON patients.pid = labrequests.pid WHERE labrequests.status = 'تم إنشاء الطلب'", con)
            Dim rdr As SqlDataReader = gt.ExecuteReader
            data.Rows.Clear()
            While rdr.Read
                data.Rows.Add({rdr("rid"), rdr("pid"), rdr("pname"), rdr("tname"), rdr("dname"), rdr("cdate")})
            End While
            rdr.Close()
        Catch ex As Exception

        End Try
        cclose()
    End Sub

    '//////////////////////////////////////////// Form Load ////////////////////////////////////////////////
    Private Sub Searchdoctor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 140
        changefont(Panel1)
        fill()
        Timer1.Interval = 1000
        Timer1.Start()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

End Class
