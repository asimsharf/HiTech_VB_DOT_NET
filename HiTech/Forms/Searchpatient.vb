Imports System.Drawing.Text
Imports System.Data.SqlClient
Imports DataSet = System.Data.DataSet

Public Class Searchpatient
    '//////////////////////////////////////////// Form Load ////////////////////////////////////////////////
    Private Sub Clinics_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        fillPatient()
    End Sub

    Private Sub fillPatient()

        Me.Top = 140
        changefont(Panel1)
        Cursor = Cursors.WaitCursor
        connect()
        copen()
        Dim gt As SqlCommand
        Try
            gt = New SqlCommand("SELECT pid, pname, pinscomp, pident, pphone FROM patients WHERE pname = '" & sear.Text & "'", con)
            Dim rdr As SqlDataReader = gt.ExecuteReader
            data.Rows.Clear()
            While rdr.Read
                data.Rows.Add({rdr(0), rdr(1), rdr(2), rdr(3), rdr(4)})
            End While
            rdr.Close()
            Cursor = Cursors.Default
        Catch ex As Exception
            Cursor = Cursors.Default
        End Try
        cclose()
    End Sub

    Private Sub getData(ByVal dataCollection As AutoCompleteStringCollection)

        Dim adapter As New SqlDataAdapter()
        Dim ds As New DataSet()

        cmd = New SqlCommand("select [pname] from [patients] ", con)
        connect()
        Try
            copen()
            adapter.SelectCommand = cmd
            adapter.Fill(ds)
            adapter.Dispose()
            cclose()

            For Each row As DataRow In ds.Tables(0).Rows
                dataCollection.Add(row(0).ToString())
            Next


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub sear_TextChanged(sender As Object, e As EventArgs) Handles sear.TextChanged
        sear.AutoCompleteMode = AutoCompleteMode.Suggest
        sear.AutoCompleteSource = AutoCompleteSource.CustomSource
        Dim DataCollection As New AutoCompleteStringCollection()
        getData(DataCollection)
        sear.AutoCompleteCustomSource = DataCollection

        Try
            For Each row As DataGridViewRow In data.Rows
                If row.Cells(0).Value = Val(sear.Text) Or row.Cells(1).Value Like "*" & sear.Text & "*" Or row.Cells(3).Value Like "*" & sear.Text & "*" Or row.Cells(4).Value Like "*" & sear.Text & "*" Then
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

    Private Sub data_SelectionChanged(sender As Object, e As EventArgs) Handles data.CellClick
        If data.RowCount > 0 Then
            If from.Text = "patients" Then
                Patients.id.Clear()
                Patients.noru.Clear()
                Patients.noru.Text = "u"
                Patients.id.Text = data.CurrentRow.Cells(0).Value
                Me.Close()
            End If

            If from.Text = "patientinvoices" Then
                PatientInvoices.pid.Clear()
                PatientInvoices.pid.Text = data.CurrentRow.Cells(0).Value
                PatientInvoices.pname.Text = data.CurrentRow.Cells(1).Value
                PatientInvoices.pident.Text = data.CurrentRow.Cells(3).Value
                PatientInvoices.pphone.Text = data.CurrentRow.Cells(4).Value
                Me.Close()
            End If

            If from.Text = "VisitPatient" Then
                VisitPatient.pid.Clear()
                VisitPatient.pid.Text = data.CurrentRow.Cells(0).Value
                VisitPatient.pname.Text = data.CurrentRow.Cells(1).Value
                VisitPatient.pident.Text = data.CurrentRow.Cells(3).Value
                VisitPatient.pphone.Text = data.CurrentRow.Cells(4).Value
                Me.Close()
            End If

            If from.Text = "newcheck" Then
                Newcheck.pid.Text = data.CurrentRow.Cells(0).Value
                Me.Close()
            End If

            If from.Text = "newcheckrec" Then
                Newcheckrec.pid.Text = data.CurrentRow.Cells(0).Value
                Me.Close()
            End If

            If from.Text = "newcheckdoc" Then
                Newcheck.pid.Text = data.CurrentRow.Cells(0).Value
                Me.Close()
            End If

            If from.Text = "invpays" Then
                Invpays.pid.Text = data.CurrentRow.Cells(0).Value
                Me.Close()
            End If
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        fillPatient()
    End Sub
End Class
