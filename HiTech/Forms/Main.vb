Imports System.Drawing.Text
Imports System.Data.SqlClient

Public Class Main
    Public Sub perms()
        If ugroup = "Admins" Then
            pt.Enabled = True
            cl.Enabled = True
            dc.Enabled = True
            ph.Enabled = True
            st.Enabled = True
            ac.Enabled = True
            rp.Enabled = True
            cf.Enabled = True
            us.Enabled = True
            lb.Enabled = True
        ElseIf ugroup = "Doctors" Then
            pt.Enabled = False
            cl.Enabled = False
            dc.Enabled = True
            ph.Enabled = False
            st.Enabled = False
            ac.Enabled = False
            rp.Enabled = False
            cf.Enabled = False
            us.Enabled = False
            lb.Enabled = False
        ElseIf ugroup = "Receptions" Then
            pt.Enabled = True
            inm.Enabled = True
            cl.Enabled = False
            dc.Enabled = False
            ph.Enabled = False
            st.Enabled = False
            ac.Enabled = False
            rp.Enabled = False
            cf.Enabled = False
            us.Enabled = False
            lb.Enabled = False
        ElseIf ugroup = "Pharmacists" Then
            pt.Enabled = False
            cl.Enabled = False
            dc.Enabled = False
            ph.Enabled = True
            st.Enabled = False
            ac.Enabled = False
            rp.Enabled = False
            cf.Enabled = False
            us.Enabled = False
            lb.Enabled = False
        ElseIf ugroup = "Chemists" Then
            pt.Enabled = False
            cl.Enabled = False
            dc.Enabled = False
            ph.Enabled = False
            st.Enabled = False
            ac.Enabled = False
            rp.Enabled = False
            cf.Enabled = False
            us.Enabled = False
            lb.Enabled = True
        ElseIf ugroup = "Accountants" Then
            pt.Enabled = False
            inm.Enabled = True
            pdt.Enabled = False
            cl.Enabled = False
            dc.Enabled = False
            ph.Enabled = False
            st.Enabled = True
            ac.Enabled = True
            rp.Enabled = True
            cf.Enabled = False
            us.Enabled = False
            lb.Enabled = False
        End If
    End Sub

    '/////////////////////////////////////////// Backup & Restore ////////////////////////////////////////////////
    Public filename As String
    Sub backup()
        Cursor = Cursors.WaitCursor
        Try
            Dim destdir As String = "HMS " & DateTime.Now.ToString("dd-MM-yyyy_HH-mm-ss") & ".bak"
            Dim objdlg As New SaveFileDialog
            objdlg.FileName = destdir
            objdlg.ShowDialog()
            filename = objdlg.FileName
            Timer1.Enabled = True
            connect()
            If con.State = ConnectionState.Closed Then con.Open()
            cmd = New SqlCommand("backup database HMS to disk='" & filename & "'with init,stats=10", con)
            cmd.ExecuteNonQuery()
            Cursor = Cursors.Default
            alert("تم إنشاء النسخة الإحتياطية بنجاح", 1)
            If con.State = ConnectionState.Open Then con.Close()
        Catch ex As Exception
            If ex.Message.Contains("Access is denied") Then
                Cursor = Cursors.Default
                alert("لا يمكنك النسخ في المسار المحدد لأنه محمي من قبل نظام التشغيل، حاول النسخ في مسار آخر", 0)
                Exit Sub
            End If
        End Try
        Cursor = Cursors.Default
    End Sub


    Sub restore()
        Cursor = Cursors.WaitCursor
        Try

            With OpenFileDialog1
                .Filter = ("DB Backup File|*.bak;")
                .FilterIndex = 4
            End With
            'Clear the file name
            OpenFileDialog1.FileName = ""

            If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
                Timer1.Enabled = True
                'SqlConnection.ClearAllPools()
                connect()
                If con.State = ConnectionState.Closed Then con.Open()
                Dim cb As String = "USE Master ALTER DATABASE HMS SET Single_User WITH Rollback Immediate Restore database HMS FROM disk='" & OpenFileDialog1.FileName & "' WITH REPLACE ALTER DATABASE HMS SET Multi_User "
                cmd = New SqlCommand(cb)
                cmd.Connection = con
                cmd.ExecuteReader()
                If con.State = ConnectionState.Open Then con.Close()
                alert("تم استعادة النسخة الإحتياطية بنجاح", 1)
            End If
        Catch ex As Exception
            Cursor = Cursors.Default
            alert(ex.Message, 0)
        End Try
        Cursor = Cursors.Default
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



    '//////////////////////////////////////////// Form Load ////////////////////////////////////////////////
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With Screen.PrimaryScreen.WorkingArea
            Me.SetBounds(.Left, .Top, .Width, .Height)
        End With

        Panel1.Width = My.Computer.Screen.Bounds.Width
        Panel2.Width = My.Computer.Screen.Bounds.Width
        Panel3.Width = My.Computer.Screen.Bounds.Width
        Button2.Visible = False
        Button4.Visible = True
        changefont(Panel1)
        perms()
    End Sub

    '//////////////////////////////////////////// Control Box ////////////////////////////////////////////////

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        With Screen.PrimaryScreen.WorkingArea
            Me.SetBounds(.Left, .Top, .Width, .Height)
        End With
        Button2.Visible = False
        Button4.Visible = True
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Me.WindowState = FormWindowState.Normal
        Button4.Visible = False
        Button2.Visible = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

    '//////////////////////////////////////////// Menu ////////////////////////////////////////////////
    Private Sub mcl_DropDownOpened(sender As Object, e As EventArgs) Handles cl.DropDownOpened
        cl.Image = HiTech.My.Resources.clinicsdark
        cl.ForeColor = Color.Black
    End Sub

    Private Sub mcl_DropDownClosed(sender As Object, e As EventArgs) Handles cl.DropDownClosed
        cl.Image = HiTech.My.Resources.clinicswhite
        cl.ForeColor = Color.White
    End Sub

    Private Sub msup_DropDownOpened(sender As Object, e As EventArgs) Handles pt.DropDownOpened
        pt.Image = HiTech.My.Resources.pationsdark
        pt.ForeColor = Color.Black
    End Sub

    Private Sub msup_DropDownClosed(sender As Object, e As EventArgs) Handles pt.DropDownClosed
        pt.Image = HiTech.My.Resources.pationswhite
        pt.ForeColor = Color.White
    End Sub

    Private Sub ph_DropDownOpened(sender As Object, e As EventArgs) Handles ph.DropDownOpened
        ph.Image = HiTech.My.Resources.pharmacydark
        ph.ForeColor = Color.Black
    End Sub

    Private Sub ph_DropDownClosed(sender As Object, e As EventArgs) Handles ph.DropDownClosed
        ph.Image = HiTech.My.Resources.pharmacywhite
        ph.ForeColor = Color.White
    End Sub

    Private Sub st_DropDownOpened(sender As Object, e As EventArgs) Handles st.DropDownOpened
        st.Image = HiTech.My.Resources.stockdark
        st.ForeColor = Color.Black
    End Sub

    Private Sub st_DropDownClosed(sender As Object, e As EventArgs) Handles st.DropDownClosed
        st.Image = HiTech.My.Resources.stockwhite
        st.ForeColor = Color.White
    End Sub

    Private Sub macn_DropDownOpened(sender As Object, e As EventArgs) Handles ac.DropDownOpened
        ac.Image = HiTech.My.Resources.accountsb
        ac.ForeColor = Color.Black
    End Sub

    Private Sub macn_DropDownClosed(sender As Object, e As EventArgs) Handles ac.DropDownClosed
        ac.Image = HiTech.My.Resources.accounts
        ac.ForeColor = Color.White
    End Sub

    Private Sub mmusr_DropDownOpened(sender As Object, e As EventArgs) Handles us.DropDownOpened
        us.Image = HiTech.My.Resources.usersb
        us.ForeColor = Color.Black
    End Sub

    Private Sub musr_DropDownClosed(sender As Object, e As EventArgs) Handles us.DropDownClosed
        us.Image = HiTech.My.Resources.users
        us.ForeColor = Color.White
    End Sub

    Private Sub mrpr_DropDownOpened(sender As Object, e As EventArgs) Handles rp.DropDownOpened
        rp.Image = HiTech.My.Resources.reportsb
        rp.ForeColor = Color.Black
    End Sub

    Private Sub mrpr_DropDownClosed(sender As Object, e As EventArgs) Handles rp.DropDownClosed
        rp.Image = HiTech.My.Resources.reports
        rp.ForeColor = Color.White
    End Sub

    Private Sub mcfg_DropDownOpened(sender As Object, e As EventArgs) Handles cf.DropDownOpened
        cf.Image = HiTech.My.Resources.settingsb
        cf.ForeColor = Color.Black
    End Sub

    Private Sub mcfg_DropDownClosed(sender As Object, e As EventArgs) Handles cf.DropDownClosed
        cf.Image = HiTech.My.Resources.settings
        cf.ForeColor = Color.White
    End Sub

    Private Sub mmnd_DropDownOpened(sender As Object, e As EventArgs) Handles dc.DropDownOpened
        dc.Image = HiTech.My.Resources.doctordark
        dc.ForeColor = Color.Black
    End Sub

    Private Sub mmndreq_DropDownClosed(sender As Object, e As EventArgs) Handles dc.DropDownClosed
        dc.Image = HiTech.My.Resources.doctorwhite
        dc.ForeColor = Color.White
    End Sub

    Private Sub mcl_Click(sender As Object, e As EventArgs) Handles cl.Click

    End Sub

    Private Sub بياناتالمرضىToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles pdt.Click
        Patients.frmtitle.Text = "المرضى"
        If Patients.WindowState = FormWindowState.Minimized Then
            Patients.WindowState = FormWindowState.Normal
        End If
        Patients.Show()
        Patients.BringToFront()
    End Sub

    Private Sub الخدماتToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles الخدماتToolStripMenuItem.Click
        Services.frmtitle.Text = "الخدمات"
        If Services.WindowState = FormWindowState.Minimized Then
            Services.WindowState = FormWindowState.Normal
        End If
        Services.Show()
        Services.BringToFront()
    End Sub

    Private Sub إضافةكشفToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Newcheck.frmtitle.Text = "فاتورة جديدة"
        If Newcheck.WindowState = FormWindowState.Minimized Then
            Newcheck.WindowState = FormWindowState.Normal
        End If
        Newcheck.Show()
        Newcheck.BringToFront()
    End Sub

    Private Sub مراجعةToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Checkback.frmtitle.Text = "مراجعة طبيب"
        If Checkback.WindowState = FormWindowState.Minimized Then
            Checkback.WindowState = FormWindowState.Normal
        End If
        Checkback.Show()
        Checkback.BringToFront()
    End Sub

    Private Sub الأقسامToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles الأقسامToolStripMenuItem.Click
        Depts.frmtitle.Text = "الأقسام"
        If Depts.WindowState = FormWindowState.Minimized Then
            Depts.WindowState = FormWindowState.Normal
        End If
        Depts.Show()
        Depts.BringToFront()
    End Sub

    Private Sub الضرائبToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles الضرائبToolStripMenuItem.Click
        Taxes.ShowDialog()
    End Sub

    Private Sub musr_Click(sender As Object, e As EventArgs) Handles us.Click
        Users.frmtitle.Text = "المستخدمين"
        If Users.WindowState = FormWindowState.Minimized Then
            Users.WindowState = FormWindowState.Normal
        End If
        Users.Show()
        Users.BringToFront()
    End Sub

    Private Sub Main_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Try
            For Each f As Form In My.Application.OpenForms
                If f IsNot Login Then
                    f.Close()
                    Me.Close()
                End If
            Next
            Login.pass.Clear()
            Login.Show()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub الفواتيرToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles inm.Click
        Invoices.frmtitle.Text = "فواتير اليوم"
        If Invoices.WindowState = FormWindowState.Minimized Then
            Invoices.WindowState = FormWindowState.Normal
        End If
        Invoices.Show()
        Invoices.BringToFront()
    End Sub

    Private Sub mact_Click(sender As Object, e As EventArgs) Handles ct.Click
        Useract.frmtitle.Text = "نشاط المستخدمين"
        If Useract.WindowState = FormWindowState.Minimized Then
            Useract.WindowState = FormWindowState.Normal
        End If
        Useract.Show()
        Useract.BringToFront()
    End Sub

    Private Sub الجنسياتToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles الجنسياتToolStripMenuItem.Click
        Nats.frmtitle.Text = "الخدمات"
        If Nats.WindowState = FormWindowState.Minimized Then
            Nats.WindowState = FormWindowState.Normal
        End If
        Nats.Show()
        Nats.BringToFront()
    End Sub

    Private Sub سدادالفواتيرToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Invpays.frmtitle.Text = "سداد الفواتير"
        If Invpays.WindowState = FormWindowState.Minimized Then
            Invpays.WindowState = FormWindowState.Normal
        End If
        Invpays.Show()
        Invpays.BringToFront()
    End Sub

    Private Sub سدادالفواتيرToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        Invpays.frmtitle.Text = "سداد الفواتير"
        If Invpays.WindowState = FormWindowState.Minimized Then
            Invpays.WindowState = FormWindowState.Normal
        End If
        Invpays.Show()
        Invpays.BringToFront()
    End Sub

    Private Sub بياناتالأطباءToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Doctors.frmtitle.Text = "الأطباء"
        If Doctors.WindowState = FormWindowState.Minimized Then
            Doctors.WindowState = FormWindowState.Normal
        End If
        Doctors.Show()
        Doctors.BringToFront()
    End Sub

    Private Sub تقريرايراداتالمجمعToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles تقريرايراداتالمجمعToolStripMenuItem.Click
        Revenue.frmtitle.Text = "تقرير الإيرادات"
        If Revenue.WindowState = FormWindowState.Minimized Then
            Revenue.WindowState = FormWindowState.Normal
        End If
        Revenue.Show()
        Revenue.BringToFront()
    End Sub

    Private Sub شركاتالتأمينToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles شركاتالتأمينToolStripMenuItem.Click
        Insurance.frmtitle.Text = "شركات التأمين"
        If Insurance.WindowState = FormWindowState.Minimized Then
            Insurance.WindowState = FormWindowState.Normal
        End If
        Insurance.Show()
        Insurance.BringToFront()
    End Sub

    Private Sub قائمةالإنتظارToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Waitlist.frmtitle.Text = "قائمة الإنتظار "
        If Waitlist.WindowState = FormWindowState.Minimized Then
            Waitlist.WindowState = FormWindowState.Normal
        End If
        Waitlist.Show()
        Waitlist.BringToFront()
    End Sub

    Private Sub قائمةالإنتظارToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles قائمةالإنتظارToolStripMenuItem1.Click
        Waitlist.frmtitle.Text = "قائمة الإنتظار "
        If Waitlist.WindowState = FormWindowState.Minimized Then
            Waitlist.WindowState = FormWindowState.Normal
        End If
        Waitlist.Show()
        Waitlist.BringToFront()
    End Sub

    Private Sub بياناتالأطباءToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles بياناتالأطباءToolStripMenuItem1.Click
        Doctors.frmtitle.Text = "الأطباء"
        If Doctors.WindowState = FormWindowState.Minimized Then
            Doctors.WindowState = FormWindowState.Normal
        End If
        Doctors.Show()
        Doctors.BringToFront()
    End Sub

    Private Sub إضافةعيادةToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles إضافةعيادةToolStripMenuItem.Click
        Clinics.frmtitle.Text = "العيادات"
        If Clinics.WindowState = FormWindowState.Minimized Then
            Clinics.WindowState = FormWindowState.Normal
        End If
        Clinics.Show()
        Clinics.BringToFront()
    End Sub

    Private Sub إنشاءتقريرطبيToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles إنشاءتقريرطبيToolStripMenuItem.Click
        Medicalreport.frmtitle.Text = "إنشاء تقرير طبي"
        If Medicalreport.WindowState = FormWindowState.Minimized Then
            Medicalreport.WindowState = FormWindowState.Normal
        End If
        Medicalreport.Show()
        Medicalreport.BringToFront()
    End Sub

    Private Sub عملنسخةاحتياطيةToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles عملنسخةاحتياطيةToolStripMenuItem.Click
        backup()
    End Sub

    Private Sub استرجاعنسخةاحتياطيةToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles استرجاعنسخةاحتياطيةToolStripMenuItem.Click
        restore()
    End Sub

    Private Sub سجلالزياراتToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles سجلالزياراتToolStripMenuItem.Click
        Clinicrecord.frmtitle.Text = "سجل الزيارات"
        If Clinicrecord.WindowState = FormWindowState.Minimized Then
            Clinicrecord.WindowState = FormWindowState.Normal
        End If
        Clinicrecord.Show()
        Clinicrecord.BringToFront()
    End Sub

    Private Sub وصفةطبيةToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Prescription.frmtitle.Text = "وصفة طبية"
        If Prescription.WindowState = FormWindowState.Minimized Then
            Prescription.WindowState = FormWindowState.Normal
        End If
        Prescription.Show()
        Prescription.BringToFront()
    End Sub

    Private Sub الوصفاتالطبيةToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles الوصفاتالطبيةToolStripMenuItem.Click
        Prescrips.frmtitle.Text = "الوصفات الطبية"
        If Prescrips.WindowState = FormWindowState.Minimized Then
            Prescrips.WindowState = FormWindowState.Normal
        End If
        Prescrips.Show()
        Prescrips.BringToFront()
    End Sub

    Private Sub طلبللمعملToolStripMenuItem_Click(sender As Object, e As EventArgs)
        Labrequest.frmtitle.Text = "طلب للمعمل"
        If Labrequest.WindowState = FormWindowState.Minimized Then
            Labrequest.WindowState = FormWindowState.Normal
        End If
        Labrequest.Show()
        Labrequest.BringToFront()
    End Sub

    Private Sub الطلباتToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles الطلباتToolStripMenuItem.Click
        Reqs.frmtitle.Text = "الطلبات"
        If Reqs.WindowState = FormWindowState.Minimized Then
            Reqs.WindowState = FormWindowState.Normal
        End If
        Reqs.Show()
        Reqs.BringToFront()
    End Sub

    Private Sub التصنيفاتToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles التصنيفاتToolStripMenuItem.Click
        Cats.frmtitle.Text = "التصنيفات"
        If Cats.WindowState = FormWindowState.Minimized Then
            Cats.WindowState = FormWindowState.Normal
        End If
        Cats.Show()
        Cats.BringToFront()
    End Sub

    Private Sub العناصرToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles العناصرToolStripMenuItem.Click
        Items.frmtitle.Text = "العناصر"
        If Items.WindowState = FormWindowState.Minimized Then
            Items.WindowState = FormWindowState.Normal
        End If
        Items.Show()
        Items.BringToFront()
    End Sub

    Private Sub الكمياتالحالةToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles الكمياتالحالةToolStripMenuItem.Click
        Stock.frmtitle.Text = "الكميات بالمخزن"
        If Stock.WindowState = FormWindowState.Minimized Then
            Stock.WindowState = FormWindowState.Normal
        End If
        Stock.Show()
        Stock.BringToFront()
    End Sub

    Private Sub طلبللمخزنToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles طلبللمخزنToolStripMenuItem.Click
        Stockrequest.frmtitle.Text = "طلب للمخزن"
        If Stockrequest.WindowState = FormWindowState.Minimized Then
            Stockrequest.WindowState = FormWindowState.Normal
        End If
        Stockrequest.Show()
        Stockrequest.BringToFront()
    End Sub

    Private Sub إرسالطلبيةToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles إرسالطلبيةToolStripMenuItem.Click
        Senditems.frmtitle.Text = "إرسال طلبية"
        If Senditems.WindowState = FormWindowState.Minimized Then
            Senditems.WindowState = FormWindowState.Normal
        End If
        Senditems.Show()
        Senditems.BringToFront()
    End Sub

    Private Sub إضافةكمياتجديدةToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles إضافةكمياتجديدةToolStripMenuItem.Click
        Purchases.frmtitle.Text = "إدخال كميات جديدة"
        If Purchases.WindowState = FormWindowState.Minimized Then
            Purchases.WindowState = FormWindowState.Normal
        End If
        Purchases.Show()
        Purchases.BringToFront()
    End Sub

    Private Sub سجلالصادرToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles سجلالصادرToolStripMenuItem.Click
        QtyOut.frmtitle.Text = "سجل الصادر"
        If QtyOut.WindowState = FormWindowState.Minimized Then
            QtyOut.WindowState = FormWindowState.Normal
        End If
        QtyOut.Show()
        QtyOut.BringToFront()
    End Sub

    Private Sub سجلالواردToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles سجلالواردToolStripMenuItem.Click
        QtyIn.frmtitle.Text = "سجل الوارد"
        If QtyIn.WindowState = FormWindowState.Minimized Then
            QtyIn.WindowState = FormWindowState.Normal
        End If
        QtyIn.Show()
        QtyIn.BringToFront()
    End Sub

    Private Sub الطلبياتToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles الطلبياتToolStripMenuItem.Click
        Reqs2.frmtitle.Text = "الطلبيات"
        If Reqs2.WindowState = FormWindowState.Minimized Then
            Reqs2.WindowState = FormWindowState.Normal
        End If
        Reqs2.Show()
        Reqs2.BringToFront()
    End Sub

    Private Sub المصروفاتToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles المصروفاتToolStripMenuItem.Click
        Masrofat.frmtitle.Text = "المصروفات"
        If Masrofat.WindowState = FormWindowState.Minimized Then
            Masrofat.WindowState = FormWindowState.Normal
        End If
        Masrofat.Show()
        Masrofat.BringToFront()
    End Sub

    Private Sub المصروفاتToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles المصروفاتToolStripMenuItem1.Click
        Masrofatrep.frmtitle.Text = "تقرير المصروفات"
        If Masrofatrep.WindowState = FormWindowState.Minimized Then
            Masrofatrep.WindowState = FormWindowState.Normal
        End If
        Masrofatrep.Show()
        Masrofatrep.BringToFront()
    End Sub

    Private Sub الكمياتالحاليةToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles الكمياتالحاليةToolStripMenuItem.Click
        Stockqty.frmtitle.Text = "المخزن"
        If Stockqty.WindowState = FormWindowState.Minimized Then
            Stockqty.WindowState = FormWindowState.Normal
        End If
        Stockqty.Show()
        Stockqty.BringToFront()
    End Sub

    Private Sub المشترياتToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles المشترياتToolStripMenuItem.Click
        Purchasesrep.frmtitle.Text = "تقرير المشتريات"
        If Purchasesrep.WindowState = FormWindowState.Minimized Then
            Purchasesrep.WindowState = FormWindowState.Normal
        End If
        Purchasesrep.Show()
        Purchasesrep.BringToFront()
    End Sub

    Private Sub الطلبياتToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles الطلبياتToolStripMenuItem1.Click
        Salesrep.frmtitle.Text = "تقرير الطلبيات"
        If Salesrep.WindowState = FormWindowState.Minimized Then
            Salesrep.WindowState = FormWindowState.Normal
        End If
        Salesrep.Show()
        Salesrep.BringToFront()
    End Sub

    Private Sub تقريرالمدفوعاتToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles تقريرالمدفوعاتToolStripMenuItem.Click
        Paymentsrep.frmtitle.Text = "تقرير المدفوعات"
        If Paymentsrep.WindowState = FormWindowState.Minimized Then
            Paymentsrep.WindowState = FormWindowState.Normal
        End If
        Paymentsrep.Show()
        Paymentsrep.BringToFront()
    End Sub

    Private Sub حسبالجنسياتToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles حسبالجنسياتToolStripMenuItem.Click
        Invoicesrep.frmtitle.Text = "تقرير الخدمات"
        If Invoicesrep.WindowState = FormWindowState.Minimized Then
            Invoicesrep.WindowState = FormWindowState.Normal
        End If
        Invoicesrep.Show()
        Invoicesrep.BringToFront()
    End Sub

    Private Sub حسبالأطباءToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles حسبالأطباءToolStripMenuItem.Click
        Invoicesrep_doc.frmtitle.Text = "تقرير الخدمات"
        If Invoicesrep_doc.WindowState = FormWindowState.Minimized Then
            Invoicesrep_doc.WindowState = FormWindowState.Normal
        End If
        Invoicesrep_doc.Show()
        Invoicesrep_doc.BringToFront()
    End Sub

    Private Sub فواتيرمريضToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles فواتيرمريضToolStripMenuItem.Click
        PatientInvoices.frmtitle.Text = "فواتير مريض"
        If PatientInvoices.WindowState = FormWindowState.Minimized Then
            PatientInvoices.WindowState = FormWindowState.Normal
        End If
        PatientInvoices.Show()
        PatientInvoices.BringToFront()
    End Sub

    Private Sub فواتيرمريضToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles فواتيرمريضToolStripMenuItem1.Click
        PatientInvoices.frmtitle.Text = "فواتير مريض"
        If PatientInvoices.WindowState = FormWindowState.Minimized Then
            PatientInvoices.WindowState = FormWindowState.Normal
        End If
        PatientInvoices.Show()
        PatientInvoices.BringToFront()
    End Sub

    Private Sub فواتيرمريضToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles فواتيرمريضToolStripMenuItem2.Click
        PatientInvoices.frmtitle.Text = "فواتير مريض"
        If PatientInvoices.WindowState = FormWindowState.Minimized Then
            PatientInvoices.WindowState = FormWindowState.Normal
        End If
        PatientInvoices.Show()
        PatientInvoices.BringToFront()
    End Sub

    Private Sub فواتيرالمشرياتToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles فواتيرالمشرياتToolStripMenuItem1.Click
        Pinvoices.frmtitle.Text = "فواتير المشتريات"
        If Pinvoices.WindowState = FormWindowState.Minimized Then
            Pinvoices.WindowState = FormWindowState.Normal
        End If
        Pinvoices.Show()
        Pinvoices.BringToFront()
    End Sub

    Private Sub فواتيرالمشرياتToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles فواتيرالمشرياتToolStripMenuItem.Click
        Pinvoices.frmtitle.Text = "فواتير المشتريات"
        If Pinvoices.WindowState = FormWindowState.Minimized Then
            Pinvoices.WindowState = FormWindowState.Normal
        End If
        Pinvoices.Show()
        Pinvoices.BringToFront()
    End Sub

    Private Sub الموردينToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles الموردينToolStripMenuItem1.Click
        Importers.frmtitle.Text = "الموردين"
        If Importers.WindowState = FormWindowState.Minimized Then
            Importers.WindowState = FormWindowState.Normal
        End If
        Importers.Show()
        Importers.BringToFront()
    End Sub

    Private Sub سجلالدفعللموردينToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles سجلالدفعللموردينToolStripMenuItem.Click
        Imppaymentsrep.frmtitle.Text = "تقرير الدفع للموردين"
        If Imppaymentsrep.WindowState = FormWindowState.Minimized Then
            Imppaymentsrep.WindowState = FormWindowState.Normal
        End If
        Imppaymentsrep.Show()
        Imppaymentsrep.BringToFront()
    End Sub

    Private Sub فاتورةجديدةToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles فاتورةجديدةToolStripMenuItem.Click
        Newcheck.frmtitle.Text = "فاتورة جديدة"
        If Newcheck.WindowState = FormWindowState.Minimized Then
            Newcheck.WindowState = FormWindowState.Normal
        End If
        Newcheck.Show()
        Newcheck.BringToFront()
    End Sub

    Private Sub تقريرضريبيToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles تقريرضريبيToolStripMenuItem.Click
        Invoicesrep2.frmtitle.Text = "تقرير ضريبي"
        If Invoicesrep2.WindowState = FormWindowState.Minimized Then
            Invoicesrep2.WindowState = FormWindowState.Normal
        End If
        Invoicesrep2.Show()
        Invoicesrep2.BringToFront()
    End Sub

    Private Sub بياناتالمرضىToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles بياناتالمرضىToolStripMenuItem.Click
        Patientsrep.frmtitle.Text = "بيانات المرضى"
        If Patientsrep.WindowState = FormWindowState.Minimized Then
            Patientsrep.WindowState = FormWindowState.Normal
        End If
        Patientsrep.Show()
        Patientsrep.BringToFront()
    End Sub

    Private Sub تقريرالفواتيرالضريبيToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles تقريرالفواتيرالضريبيToolStripMenuItem.Click
        Invoicesrep3.frmtitle.Text = "تقرير الفواتير الضريبي"
        If Invoicesrep3.WindowState = FormWindowState.Minimized Then
            Invoicesrep3.WindowState = FormWindowState.Normal
        End If
        Invoicesrep3.Show()
        Invoicesrep3.BringToFront()
    End Sub

    Private Sub تقريرالدخلToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles تقريرالدخلToolStripMenuItem.Click
        Uservenue.frmtitle.Text = "تقرير الدخل"
        If Uservenue.WindowState = FormWindowState.Minimized Then
            Uservenue.WindowState = FormWindowState.Normal
        End If
        Uservenue.Show()
        Uservenue.BringToFront()
    End Sub

    Private Sub خدماتالمعملToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles خدماتالمعملToolStripMenuItem.Click
        LabServices.frmtitle.Text = "خدمات المعمل"
        If LabServices.WindowState = FormWindowState.Minimized Then
            LabServices.WindowState = FormWindowState.Normal
        End If
        LabServices.Show()
        LabServices.BringToFront()
    End Sub

    Private Sub الأدويةToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles الأدويةToolStripMenuItem.Click
        Drugs.frmtitle.Text = "الأدوية"
        If Drugs.WindowState = FormWindowState.Minimized Then
            Drugs.WindowState = FormWindowState.Normal
        End If
        Drugs.Show()
        Drugs.BringToFront()
    End Sub

    Private Sub بياناتالفنيينToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles بياناتالفنيينToolStripMenuItem.Click
        Technicians.frmtitle.Text = "الفنيين"
        If Technicians.WindowState = FormWindowState.Minimized Then
            Technicians.WindowState = FormWindowState.Normal
        End If
        Technicians.Show()
        Technicians.BringToFront()
    End Sub

    Private Sub ألوانالتركيباتToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ألوانالتركيباتToolStripMenuItem.Click
        Colors.frmtitle.Text = "ألوان التركيبات"
        If Colors.WindowState = FormWindowState.Minimized Then
            Colors.WindowState = FormWindowState.Normal
        End If
        Colors.Show()
        Colors.BringToFront()
    End Sub

    Private Sub طلباتالمعملToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles طلباتالمعملToolStripMenuItem.Click
        Reqlist.frmtitle.Text = "طلبات المعمل"
        If Reqlist.WindowState = FormWindowState.Minimized Then
            Reqlist.WindowState = FormWindowState.Normal
        End If
        Reqlist.Show()
        Reqlist.BringToFront()
    End Sub

    Private Sub الوصفاتالسابقةToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles الوصفاتالسابقةToolStripMenuItem.Click
        Prescrips.frmtitle.Text = "الوصفات السابقة"
        If OldPrescrips.WindowState = FormWindowState.Minimized Then
            OldPrescrips.WindowState = FormWindowState.Normal
        End If
        OldPrescrips.Show()
        OldPrescrips.BringToFront()
    End Sub

    Private Sub مريضمراجعToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles مريضمراجعToolStripMenuItem.Click
        VisitPatient.frmtitle.Text = "مريض مراجع"
        If VisitPatient.WindowState = FormWindowState.Minimized Then
            VisitPatient.WindowState = FormWindowState.Normal
        End If
        VisitPatient.Show()
        VisitPatient.BringToFront()
    End Sub

    Private Sub قائمةالمراجعينToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles قائمةالمراجعينToolStripMenuItem.Click
        Waitlistold.frmtitle.Text = "قائمة المراجعين "
        If Waitlistold.WindowState = FormWindowState.Minimized Then
            Waitlistold.WindowState = FormWindowState.Normal
        End If
        Waitlistold.Show()
        Waitlistold.BringToFront()
    End Sub

    Private Sub إجماليالدخلToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles إجماليالدخلToolStripMenuItem.Click
        Userincome.frmtitle.Text = "تقرير الدخل "
        If Userincome.WindowState = FormWindowState.Minimized Then
            Userincome.WindowState = FormWindowState.Normal
        End If
        Userincome.Show()
        Userincome.BringToFront()
    End Sub
End Class
