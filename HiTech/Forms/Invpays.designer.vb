<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Invpays
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Invpays))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.frmtitle = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.hpid = New System.Windows.Forms.TextBox()
        Me.pnat = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pgender = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pid = New System.Windows.Forms.TextBox()
        Me.pname = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.invs = New System.Windows.Forms.DataGridView()
        Me.Column4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.inps = New System.Windows.Forms.DataGridView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.ptype = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.paid = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tax = New System.Windows.Forms.TextBox()
        Me.invstat = New System.Windows.Forms.TextBox()
        Me.doctor = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.invdate = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.allremain = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.allpaid = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.invno = New System.Windows.Forms.TextBox()
        Me.invvalue = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.sid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewButtonColumn()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.serch = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.invs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.inps, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.Panel2.Controls.Add(Me.frmtitle)
        Me.Panel2.Controls.Add(Me.Button3)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1277, 38)
        Me.Panel2.TabIndex = 0
        '
        'frmtitle
        '
        Me.frmtitle.AutoSize = True
        Me.frmtitle.ForeColor = System.Drawing.Color.White
        Me.frmtitle.Location = New System.Drawing.Point(1000, 8)
        Me.frmtitle.MinimumSize = New System.Drawing.Size(200, 17)
        Me.frmtitle.Name = "frmtitle"
        Me.frmtitle.Size = New System.Drawing.Size(200, 17)
        Me.frmtitle.TabIndex = 7
        Me.frmtitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.hpid)
        Me.GroupBox2.Controls.Add(Me.pnat)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.serch)
        Me.GroupBox2.Controls.Add(Me.pgender)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.pid)
        Me.GroupBox2.Controls.Add(Me.pname)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Location = New System.Drawing.Point(28, 63)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1218, 88)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "بيانات المريض"
        '
        'hpid
        '
        Me.hpid.Location = New System.Drawing.Point(451, 58)
        Me.hpid.Name = "hpid"
        Me.hpid.ReadOnly = True
        Me.hpid.Size = New System.Drawing.Size(109, 24)
        Me.hpid.TabIndex = 64
        Me.hpid.Visible = False
        '
        'pnat
        '
        Me.pnat.Location = New System.Drawing.Point(20, 34)
        Me.pnat.Name = "pnat"
        Me.pnat.ReadOnly = True
        Me.pnat.Size = New System.Drawing.Size(143, 24)
        Me.pnat.TabIndex = 62
        Me.pnat.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(162, 34)
        Me.Label2.MinimumSize = New System.Drawing.Size(80, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 32)
        Me.Label2.TabIndex = 63
        Me.Label2.Text = "الجنسية"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pgender
        '
        Me.pgender.Location = New System.Drawing.Point(248, 34)
        Me.pgender.Name = "pgender"
        Me.pgender.ReadOnly = True
        Me.pgender.Size = New System.Drawing.Size(118, 24)
        Me.pgender.TabIndex = 3
        Me.pgender.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(365, 34)
        Me.Label1.MinimumSize = New System.Drawing.Size(80, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 32)
        Me.Label1.TabIndex = 47
        Me.Label1.Text = "الجنس"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'pid
        '
        Me.pid.Location = New System.Drawing.Point(986, 34)
        Me.pid.Name = "pid"
        Me.pid.ReadOnly = True
        Me.pid.Size = New System.Drawing.Size(109, 24)
        Me.pid.TabIndex = 1
        '
        'pname
        '
        Me.pname.Location = New System.Drawing.Point(451, 34)
        Me.pname.Name = "pname"
        Me.pname.ReadOnly = True
        Me.pname.Size = New System.Drawing.Size(381, 24)
        Me.pname.TabIndex = 2
        Me.pname.TabStop = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(831, 34)
        Me.Label19.MinimumSize = New System.Drawing.Size(120, 32)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(120, 32)
        Me.Label19.TabIndex = 36
        Me.Label19.Text = "اسم المريض"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.Label17.ForeColor = System.Drawing.Color.White
        Me.Label17.Location = New System.Drawing.Point(1094, 34)
        Me.Label17.MinimumSize = New System.Drawing.Size(105, 32)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(105, 32)
        Me.Label17.TabIndex = 41
        Me.Label17.Text = "رقم الملف"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(3, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.MaximumSize = New System.Drawing.Size(1283, 689)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1277, 685)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.invs)
        Me.GroupBox4.Controls.Add(Me.inps)
        Me.GroupBox4.Location = New System.Drawing.Point(28, 161)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1218, 287)
        Me.GroupBox4.TabIndex = 67
        Me.GroupBox4.TabStop = False
        '
        'invs
        '
        Me.invs.AllowUserToAddRows = False
        Me.invs.AllowUserToDeleteRows = False
        Me.invs.AllowUserToResizeColumns = False
        Me.invs.AllowUserToResizeRows = False
        Me.invs.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.invs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.invs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.invs.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Column4, Me.Column6})
        Me.invs.Location = New System.Drawing.Point(823, 22)
        Me.invs.MultiSelect = False
        Me.invs.Name = "invs"
        Me.invs.ReadOnly = True
        Me.invs.RowHeadersVisible = False
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White
        Me.invs.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.invs.RowTemplate.Height = 26
        Me.invs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.invs.Size = New System.Drawing.Size(376, 249)
        Me.invs.TabIndex = 67
        Me.invs.TabStop = False
        '
        'Column4
        '
        Me.Column4.HeaderText = "رقم الفاتورة"
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Width = 150
        '
        'Column6
        '
        Me.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle1.Format = "d"
        DataGridViewCellStyle1.NullValue = Nothing
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle1
        Me.Column6.HeaderText = "تاريخ الفاتورة"
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        '
        'inps
        '
        Me.inps.AllowUserToAddRows = False
        Me.inps.AllowUserToDeleteRows = False
        Me.inps.AllowUserToResizeColumns = False
        Me.inps.AllowUserToResizeRows = False
        Me.inps.BackgroundColor = System.Drawing.Color.Gainsboro
        Me.inps.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.inps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.inps.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.sid, Me.Column2, Me.Column7, Me.Column5, Me.Column3, Me.Column1})
        Me.inps.Location = New System.Drawing.Point(20, 22)
        Me.inps.MultiSelect = False
        Me.inps.Name = "inps"
        Me.inps.ReadOnly = True
        Me.inps.RowHeadersVisible = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        Me.inps.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.inps.RowTemplate.Height = 26
        Me.inps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.inps.Size = New System.Drawing.Size(797, 249)
        Me.inps.TabIndex = 66
        Me.inps.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Button4)
        Me.GroupBox3.Controls.Add(Me.ptype)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.paid)
        Me.GroupBox3.Controls.Add(Me.Label12)
        Me.GroupBox3.Location = New System.Drawing.Point(28, 553)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1218, 88)
        Me.GroupBox3.TabIndex = 66
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "بيانات السداد"
        '
        'ptype
        '
        Me.ptype.FormattingEnabled = True
        Me.ptype.Items.AddRange(New Object() {"نقدي", "شبكة"})
        Me.ptype.Location = New System.Drawing.Point(613, 34)
        Me.ptype.Name = "ptype"
        Me.ptype.Size = New System.Drawing.Size(163, 24)
        Me.ptype.TabIndex = 66
        Me.ptype.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(774, 34)
        Me.Label3.MinimumSize = New System.Drawing.Size(120, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(120, 32)
        Me.Label3.TabIndex = 65
        Me.Label3.Text = "طريقة الدفع"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'paid
        '
        Me.paid.Location = New System.Drawing.Point(900, 34)
        Me.paid.Name = "paid"
        Me.paid.Size = New System.Drawing.Size(170, 24)
        Me.paid.TabIndex = 1
        Me.paid.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.Label12.ForeColor = System.Drawing.Color.White
        Me.Label12.Location = New System.Drawing.Point(1069, 34)
        Me.Label12.MinimumSize = New System.Drawing.Size(130, 32)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(130, 32)
        Me.Label12.TabIndex = 41
        Me.Label12.Text = "المبلغ المدفوع"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tax)
        Me.GroupBox1.Controls.Add(Me.invstat)
        Me.GroupBox1.Controls.Add(Me.doctor)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.invdate)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.allremain)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.allpaid)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.invno)
        Me.GroupBox1.Controls.Add(Me.invvalue)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Location = New System.Drawing.Point(28, 456)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1218, 88)
        Me.GroupBox1.TabIndex = 64
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "بيانات الفاتورة"
        '
        'tax
        '
        Me.tax.Location = New System.Drawing.Point(20, 64)
        Me.tax.Name = "tax"
        Me.tax.Size = New System.Drawing.Size(100, 24)
        Me.tax.TabIndex = 68
        Me.tax.Visible = False
        '
        'invstat
        '
        Me.invstat.Location = New System.Drawing.Point(20, 34)
        Me.invstat.Name = "invstat"
        Me.invstat.ReadOnly = True
        Me.invstat.Size = New System.Drawing.Size(76, 24)
        Me.invstat.TabIndex = 69
        Me.invstat.TabStop = False
        Me.invstat.Visible = False
        '
        'doctor
        '
        Me.doctor.Location = New System.Drawing.Point(20, 34)
        Me.doctor.Name = "doctor"
        Me.doctor.ReadOnly = True
        Me.doctor.Size = New System.Drawing.Size(152, 24)
        Me.doctor.TabIndex = 67
        Me.doctor.TabStop = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(171, 34)
        Me.Label9.MinimumSize = New System.Drawing.Size(80, 32)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(80, 32)
        Me.Label9.TabIndex = 68
        Me.Label9.Text = "الطبيب"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'invdate
        '
        Me.invdate.Location = New System.Drawing.Point(794, 34)
        Me.invdate.Name = "invdate"
        Me.invdate.ReadOnly = True
        Me.invdate.Size = New System.Drawing.Size(95, 24)
        Me.invdate.TabIndex = 64
        Me.invdate.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(887, 34)
        Me.Label8.MinimumSize = New System.Drawing.Size(120, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(120, 32)
        Me.Label8.TabIndex = 65
        Me.Label8.Text = "تاريخ الفاتورة"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'allremain
        '
        Me.allremain.Location = New System.Drawing.Point(258, 34)
        Me.allremain.Name = "allremain"
        Me.allremain.ReadOnly = True
        Me.allremain.Size = New System.Drawing.Size(76, 24)
        Me.allremain.TabIndex = 62
        Me.allremain.TabStop = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(333, 34)
        Me.Label4.MinimumSize = New System.Drawing.Size(80, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 32)
        Me.Label4.TabIndex = 63
        Me.Label4.Text = "المتبقي"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'allpaid
        '
        Me.allpaid.Location = New System.Drawing.Point(420, 34)
        Me.allpaid.Name = "allpaid"
        Me.allpaid.ReadOnly = True
        Me.allpaid.Size = New System.Drawing.Size(76, 24)
        Me.allpaid.TabIndex = 3
        Me.allpaid.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(495, 34)
        Me.Label5.MinimumSize = New System.Drawing.Size(80, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 32)
        Me.Label5.TabIndex = 47
        Me.Label5.Text = "المدفوع"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'invno
        '
        Me.invno.Location = New System.Drawing.Point(1014, 34)
        Me.invno.Name = "invno"
        Me.invno.ReadOnly = True
        Me.invno.Size = New System.Drawing.Size(81, 24)
        Me.invno.TabIndex = 1
        Me.invno.TabStop = False
        '
        'invvalue
        '
        Me.invvalue.Location = New System.Drawing.Point(582, 34)
        Me.invvalue.Name = "invvalue"
        Me.invvalue.ReadOnly = True
        Me.invvalue.Size = New System.Drawing.Size(87, 24)
        Me.invvalue.TabIndex = 2
        Me.invvalue.TabStop = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(667, 34)
        Me.Label6.MinimumSize = New System.Drawing.Size(120, 32)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(120, 32)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "قيمة الفاتورة"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(1094, 34)
        Me.Label7.MinimumSize = New System.Drawing.Size(105, 32)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(105, 32)
        Me.Label7.TabIndex = 41
        Me.Label7.Text = "رقم الفاتورة"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'sid
        '
        Me.sid.HeaderText = "iid"
        Me.sid.Name = "sid"
        Me.sid.ReadOnly = True
        Me.sid.Visible = False
        '
        'Column2
        '
        Me.Column2.HeaderText = "نقدي"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Width = 150
        '
        'Column7
        '
        Me.Column7.HeaderText = "شبكة"
        Me.Column7.Name = "Column7"
        Me.Column7.ReadOnly = True
        '
        'Column5
        '
        Me.Column5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        DataGridViewCellStyle3.Format = "d"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Column5.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column5.HeaderText = "تاريخ الدفع"
        Me.Column5.Name = "Column5"
        Me.Column5.ReadOnly = True
        '
        'Column3
        '
        Me.Column3.HeaderText = "المتحصل"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        Me.Column3.Width = 200
        '
        'Column1
        '
        Me.Column1.HeaderText = "طباعة"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Text = "طباعة"
        Me.Column1.UseColumnTextForButtonValue = True
        '
        'Button4
        '
        Me.Button4.BackgroundImage = Global.HiTech.My.Resources.Resources.save
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Location = New System.Drawing.Point(20, 34)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(106, 32)
        Me.Button4.TabIndex = 67
        Me.Button4.TabStop = False
        Me.Button4.UseVisualStyleBackColor = True
        '
        'serch
        '
        Me.serch.BackgroundImage = Global.HiTech.My.Resources.Resources.srch
        Me.serch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.serch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.serch.Location = New System.Drawing.Point(957, 34)
        Me.serch.Name = "serch"
        Me.serch.Size = New System.Drawing.Size(32, 32)
        Me.serch.TabIndex = 61
        Me.serch.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.BackgroundImage = CType(resources.GetObject("Button3.BackgroundImage"), System.Drawing.Image)
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(1206, 2)
        Me.Button3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(30, 31)
        Me.Button3.TabIndex = 0
        Me.Button3.TabStop = False
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button1.BackgroundImage = CType(resources.GetObject("Button1.BackgroundImage"), System.Drawing.Image)
        Me.Button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button1.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Location = New System.Drawing.Point(1243, 1)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(30, 32)
        Me.Button1.TabIndex = 0
        Me.Button1.TabStop = False
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Invpays
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1283, 689)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximumSize = New System.Drawing.Size(1283, 689)
        Me.Name = "Invpays"
        Me.Opacity = 0.98R
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "سداد الفواتير"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.invs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.inps, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents frmtitle As System.Windows.Forms.Label
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents pgender As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pid As System.Windows.Forms.TextBox
    Friend WithEvents pname As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents pnat As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents serch As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents invdate As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents allremain As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents allpaid As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents invno As System.Windows.Forms.TextBox
    Friend WithEvents invvalue As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents paid As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ptype As System.Windows.Forms.ComboBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents invs As System.Windows.Forms.DataGridView
    Friend WithEvents inps As System.Windows.Forms.DataGridView
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents hpid As System.Windows.Forms.TextBox
    Friend WithEvents doctor As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents invstat As System.Windows.Forms.TextBox
    Friend WithEvents tax As System.Windows.Forms.TextBox
    Friend WithEvents sid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewButtonColumn

End Class
