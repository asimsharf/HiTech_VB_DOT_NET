Imports System.Drawing.Text
Imports System.Data.SqlClient

Public Class Confirm

    '//////////////////////////////////////////// Form Load ////////////////////////////////////////////////
    Private Sub Clinics_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Top = 250
        changefont(Panel1)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Cursor = Cursors.WaitCursor
        connect()
        copen()
        Dim va As Double = 0
        Dim iid As Integer
        Try
            If table.Text = "useract" Then
                cmd = New SqlCommand("DELETE FROM useract WHERE uname = '" & un & "'", con)
                cmd.ExecuteNonQuery()
                cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بحذف سجل النشاط الخاص به', '" & nowdate() & "')", con)
                cmdact.ExecuteNonQuery()
                Useract.fill()
                Cursor = Cursors.Default
                alert("تم حذف سجل النشاط بنجاح", 1)
            End If

            cmd = New SqlCommand("DELETE FROM " & table.Text & " WHERE " & field.Text & " = " & id.Text & "", con)
            cmd.ExecuteNonQuery()

            If table.Text = "patients" Then
                Patients.reset()
                cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بحذف المريض رقم " & id.Text & "', '" & nowdate() & "')", con)
                cmdact.ExecuteNonQuery()
            ElseIf table.Text = "images" Then
                Patients.fill()
            ElseIf table.Text = "doctors" Then
                Doctors.reset()
                cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بحذف الطبيب رقم " & id.Text & "', '" & nowdate() & "')", con)
                cmdact.ExecuteNonQuery()
            ElseIf table.Text = "technicians" Then
                Technicians.reset()
                cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بحذف الفني رقم " & id.Text & "', '" & nowdate() & "')", con)
                cmdact.ExecuteNonQuery()
            ElseIf table.Text = "doctorimgs" Then
                Doctors.fill()
            ElseIf table.Text = "technicianimgs" Then
                Technicians.fill()
            ElseIf table.Text = "services" Then
                Services.reset()
                cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بحذف الخدمة رقم " & id.Text & "', '" & nowdate() & "')", con)
                cmdact.ExecuteNonQuery()
            ElseIf table.Text = "labservices" Then
                labservices.reset()
                cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بحذف الدواء رقم " & id.Text & "', '" & nowdate() & "')", con)
                cmdact.ExecuteNonQuery()
            ElseIf table.Text = "drugs" Then
                Drugs.reset()
                cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بحذف الخدمة رقم " & id.Text & "', '" & nowdate() & "')", con)
                cmdact.ExecuteNonQuery()
            ElseIf table.Text = "depts" Then
                Depts.reset()
                cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بحذف القسم رقم " & id.Text & "', '" & nowdate() & "')", con)
                cmdact.ExecuteNonQuery()
            ElseIf table.Text = "colors" Then
                Colors.reset()
                cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بحذف اللون رقم " & id.Text & "', '" & nowdate() & "')", con)
                cmdact.ExecuteNonQuery()
            ElseIf table.Text = "clinics" Then
                Clinics.reset()
                cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بحذف العيادة رقم " & id.Text & "', '" & nowdate() & "')", con)
                cmdact.ExecuteNonQuery()
            ElseIf table.Text = "users" Then
                Users.reset()
                cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بحذف المستخدم رقم " & id.Text & "', '" & nowdate() & "')", con)
                cmdact.ExecuteNonQuery()
            ElseIf table.Text = "nats" Then
                Nats.reset()
                cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بحذف الجنسية رقم " & id.Text & "', '" & nowdate() & "')", con)
                cmdact.ExecuteNonQuery()
            ElseIf table.Text = "insurance" Then
                Insurance.reset()
                cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بحذف شركة التأمين رقم " & id.Text & "', '" & nowdate() & "')", con)
                cmdact.ExecuteNonQuery()
            ElseIf table.Text = "insurfiles" Then
                Insurance.fill()
            ElseIf table.Text = "importers" Then
                Importers.reset()
                cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بحذف المورد رقم " & id.Text & "', '" & nowdate() & "')", con)
                cmdact.ExecuteNonQuery()
            ElseIf table.Text = "impfiles" Then
                Importers.fill()
            ElseIf table.Text = "medrep" Then
                Medicalreport.reset()
                cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بحذف التقرير الطبي رقم " & id.Text & "', '" & nowdate() & "')", con)
                cmdact.ExecuteNonQuery()
            ElseIf table.Text = "clinic" Then
                Clinic.reset()
                cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بحذف الفحص رقم " & id.Text & "', '" & nowdate() & "')", con)
                cmdact.ExecuteNonQuery()
            ElseIf table.Text = "labrequests" Then
                Labinvoice.reset()
                cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بحذف الطلب رقم " & id.Text & "', '" & nowdate() & "')", con)
                cmdact.ExecuteNonQuery()
            ElseIf table.Text = "prescr" Then
                Prescription.reset()
                cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بحذف الوصفة رقم " & id.Text & "', '" & nowdate() & "')", con)
                cmdact.ExecuteNonQuery()
            ElseIf table.Text = "lab" Then
                Labrequest.reset()
                cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بحذف الطلب رقم " & id.Text & "', '" & nowdate() & "')", con)
                cmdact.ExecuteNonQuery()
            ElseIf table.Text = "categories" Then
                Cats.reset()
                cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بحذف التصنيف رقم " & id.Text & "', '" & nowdate() & "')", con)
                cmdact.ExecuteNonQuery()
            ElseIf table.Text = "items" Then
                Items.reset()
                cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بحذف العنصر رقم " & id.Text & "', '" & nowdate() & "')", con)
                cmdact.ExecuteNonQuery()
            ElseIf table.Text = "stockreq" Then
                Stockrequest.reset()
                cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بحذف الطلب رقم " & id.Text & "', '" & nowdate() & "')", con)
                cmdact.ExecuteNonQuery()
            ElseIf table.Text = "imppays" Then
                Dim cmddd As New SqlCommand("UPDATE importers SET ibal = (ibal + " & va & ") WHERE iid = " & iid & "", con)
                cmddd.ExecuteNonQuery()
                ImpPays.fill()
            ElseIf table.Text = "[check]" Then
                Dim cmdi As New SqlCommand("DELETE FROM checkdetails WHERE invno = '" & id.Text & "'", con)
                cmdi.ExecuteNonQuery()
                Dim pmd As New SqlCommand("DELETE FROM invpays WHERE invno = '" & id.Text & "'", con)
                pmd.ExecuteNonQuery()
                Invoices.fill()
                cmdact = New SqlCommand("INSERT INTO useract (uname,details,acdate) VALUES ('" & un & "', 'قام المستخدم " & un & " بحذف الفاتورة رقم " & id.Text & "', '" & nowdate() & "')", con)
                cmdact.ExecuteNonQuery()
            ElseIf table.Text = "clinicimgs" Then
                Clinic.allfill()
            End If
            Cursor = Cursors.Default
            Cursor = Cursors.Default
            Me.Close()
        Catch ex As Exception
            Cursor = Cursors.Default
            MsgBox(ex.Message)
        End Try
        cclose()
    End Sub
End Class
