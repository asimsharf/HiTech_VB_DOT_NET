<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Doctors
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Doctors))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.id = New System.Windows.Forms.TextBox()
        Me.noru = New System.Windows.Forms.TextBox()
        Me.frmtitle = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.data = New System.Windows.Forms.DataGridView()
        Me.serial = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Column4 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Column6 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.uid = New System.Windows.Forms.TextBox()
        Me.upass = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.uname = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.did = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dident = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.clinic = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dept = New System.Windows.Forms.ComboBox()
        Me.dspec = New System.Windows.Forms.TextBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.dphone = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.daddress = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.dmstat = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dreg = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dnat = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dgender = New System.Windows.Forms.ComboBox()
        Me.dname = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.DataGridViewImageColumn1 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewImageColumn2 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.DataGridViewImageColumn3 = New System.Windows.Forms.DataGridViewImageColumn()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.data, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.Panel2.Controls.Add(Me.id)
        Me.Panel2.Controls.Add(Me.noru)
        Me.Panel2.Controls.Add(Me.frmtitle)
        Me.Panel2.Controls.Add(Me.Button3)
        Me.Panel2.Controls.Add(Me.Button1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1276, 38)
        Me.Panel2.TabIndex = 0
        '
        'id
        '
        Me.id.Location = New System.Drawing.Point(500, 8)
        Me.id.Name = "id"
        Me.id.Size = New System.Drawing.Size(100, 24)
        Me.id.TabIndex = 8
        Me.id.Visible = False
        '
        'noru
        '
        Me.noru.Location = New System.Drawing.Point(394, 7)
        Me.noru.Name = "noru"
        Me.noru.Size = New System.Drawing.Size(100, 24)
        Me.noru.TabIndex = 8
        Me.noru.Visible = False
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
        'Button3
        '
        Me.Button3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button3.BackgroundImage = CType(resources.GetObject("Button3.BackgroundImage"), System.Drawing.Image)
        Me.Button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button3.FlatAppearance.BorderColor = System.Drawing.Color.White
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Location = New System.Drawing.Point(1205, 4)
        Me.Button3.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(30, 29)
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
        Me.Button1.Location = New System.Drawing.Point(1242, 4)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(30, 29)
        Me.Button1.TabIndex = 0
        Me.Button1.TabStop = False
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel1.Controls.Add(Me.GroupBox4)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(3, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.MaximumSize = New System.Drawing.Size(1283, 689)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1276, 685)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Button7)
        Me.GroupBox4.Controls.Add(Me.Button9)
        Me.GroupBox4.Controls.Add(Me.Button4)
        Me.GroupBox4.Controls.Add(Me.Button10)
        Me.GroupBox4.Controls.Add(Me.Button5)
        Me.GroupBox4.Controls.Add(Me.Button6)
        Me.GroupBox4.Controls.Add(Me.Button8)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 603)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(1259, 67)
        Me.GroupBox4.TabIndex = 4
        Me.GroupBox4.TabStop = False
        '
        'Button7
        '
        Me.Button7.BackgroundImage = Global.HiTech.My.Resources.Resources.delete
        Me.Button7.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button7.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button7.FlatAppearance.BorderSize = 0
        Me.Button7.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button7.Location = New System.Drawing.Point(154, 19)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(128, 35)
        Me.Button7.TabIndex = 0
        Me.Button7.TabStop = False
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.BackgroundImage = Global.HiTech.My.Resources.Resources.attach
        Me.Button9.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button9.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button9.FlatAppearance.BorderSize = 0
        Me.Button9.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button9.Location = New System.Drawing.Point(1111, 19)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(128, 35)
        Me.Button9.TabIndex = 0
        Me.Button9.TabStop = False
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button4
        '
        Me.Button4.BackgroundImage = Global.HiTech.My.Resources.Resources.save
        Me.Button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button4.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button4.FlatAppearance.BorderSize = 0
        Me.Button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button4.Location = New System.Drawing.Point(553, 19)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(128, 35)
        Me.Button4.TabIndex = 0
        Me.Button4.TabStop = False
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.BackgroundImage = Global.HiTech.My.Resources.Resources.add
        Me.Button10.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button10.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button10.FlatAppearance.BorderSize = 0
        Me.Button10.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button10.Location = New System.Drawing.Point(686, 19)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(128, 35)
        Me.Button10.TabIndex = 0
        Me.Button10.TabStop = False
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.BackgroundImage = Global.HiTech.My.Resources.Resources.search
        Me.Button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button5.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button5.FlatAppearance.BorderSize = 0
        Me.Button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button5.Location = New System.Drawing.Point(420, 19)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(128, 35)
        Me.Button5.TabIndex = 0
        Me.Button5.TabStop = False
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.BackgroundImage = Global.HiTech.My.Resources.Resources.edit
        Me.Button6.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button6.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button6.FlatAppearance.BorderSize = 0
        Me.Button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button6.Location = New System.Drawing.Point(287, 19)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(128, 35)
        Me.Button6.TabIndex = 0
        Me.Button6.TabStop = False
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.BackgroundImage = Global.HiTech.My.Resources.Resources.print
        Me.Button8.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button8.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Button8.FlatAppearance.BorderSize = 0
        Me.Button8.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button8.Location = New System.Drawing.Point(21, 19)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(128, 35)
        Me.Button8.TabIndex = 0
        Me.Button8.TabStop = False
        Me.Button8.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.data)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 235)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(1259, 362)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "المستندات"
        '
        'data
        '
        Me.data.AllowUserToAddRows = False
        Me.data.AllowUserToDeleteRows = False
        Me.data.AllowUserToResizeColumns = False
        Me.data.AllowUserToResizeRows = False
        Me.data.BackgroundColor = System.Drawing.Color.WhiteSmoke
        Me.data.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Gainsboro
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Tahoma", 8.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.data.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.data.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.serial, Me.Column1, Me.Column2, Me.Column3, Me.Column4, Me.Column6})
        Me.data.Location = New System.Drawing.Point(21, 30)
        Me.data.MultiSelect = False
        Me.data.Name = "data"
        Me.data.ReadOnly = True
        Me.data.RowHeadersVisible = False
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.White
        DataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.White
        Me.data.RowsDefaultCellStyle = DataGridViewCellStyle4
        Me.data.RowTemplate.Height = 26
        Me.data.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.data.Size = New System.Drawing.Size(1218, 313)
        Me.data.TabIndex = 0
        Me.data.TabStop = False
        '
        'serial
        '
        Me.serial.HeaderText = "متسلسل"
        Me.serial.Name = "serial"
        Me.serial.ReadOnly = True
        Me.serial.Visible = False
        '
        'Column1
        '
        Me.Column1.HeaderText = "المرفق"
        Me.Column1.Name = "Column1"
        Me.Column1.ReadOnly = True
        Me.Column1.Width = 400
        '
        'Column2
        '
        Me.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column2.HeaderText = "المسار"
        Me.Column2.Name = "Column2"
        Me.Column2.ReadOnly = True
        Me.Column2.Visible = False
        '
        'Column3
        '
        Me.Column3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Column3.HeaderText = "معلومات"
        Me.Column3.Name = "Column3"
        Me.Column3.ReadOnly = True
        '
        'Column4
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        DataGridViewCellStyle2.NullValue = Nothing
        Me.Column4.DefaultCellStyle = DataGridViewCellStyle2
        Me.Column4.HeaderText = "عرض"
        Me.Column4.Image = Global.HiTech.My.Resources.Resources.view
        Me.Column4.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.Column4.Name = "Column4"
        Me.Column4.ReadOnly = True
        Me.Column4.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column4.Width = 50
        '
        'Column6
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(66, Byte), Integer))
        DataGridViewCellStyle3.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle3.NullValue = Nothing
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(66, Byte), Integer))
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White
        Me.Column6.DefaultCellStyle = DataGridViewCellStyle3
        Me.Column6.HeaderText = "حذف"
        Me.Column6.Image = Global.HiTech.My.Resources.Resources.del
        Me.Column6.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.Column6.Name = "Column6"
        Me.Column6.ReadOnly = True
        Me.Column6.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Column6.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Column6.Width = 50
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.uid)
        Me.GroupBox1.Controls.Add(Me.upass)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.uname)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.did)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.dident)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.clinic)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.dept)
        Me.GroupBox1.Controls.Add(Me.dspec)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.dphone)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.daddress)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.dmstat)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.dreg)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.dnat)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.dgender)
        Me.GroupBox1.Controls.Add(Me.dname)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 50)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1259, 179)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "بيانات الطبيب"
        '
        'uid
        '
        Me.uid.Location = New System.Drawing.Point(19, 149)
        Me.uid.Name = "uid"
        Me.uid.Size = New System.Drawing.Size(93, 24)
        Me.uid.TabIndex = 52
        Me.uid.Visible = False
        '
        'upass
        '
        Me.upass.Location = New System.Drawing.Point(19, 127)
        Me.upass.Name = "upass"
        Me.upass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.upass.Size = New System.Drawing.Size(148, 24)
        Me.upass.TabIndex = 15
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(166, 127)
        Me.Label6.MinimumSize = New System.Drawing.Size(110, 32)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 32)
        Me.Label6.TabIndex = 51
        Me.Label6.Text = "كلمة المرور:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'uname
        '
        Me.uname.Location = New System.Drawing.Point(282, 127)
        Me.uname.Name = "uname"
        Me.uname.Size = New System.Drawing.Size(140, 24)
        Me.uname.TabIndex = 14
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(421, 127)
        Me.Label19.MinimumSize = New System.Drawing.Size(110, 32)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(110, 32)
        Me.Label19.TabIndex = 50
        Me.Label19.Text = "اسم المستخدم"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'did
        '
        Me.did.Location = New System.Drawing.Point(1038, 23)
        Me.did.Name = "did"
        Me.did.ReadOnly = True
        Me.did.Size = New System.Drawing.Size(110, 24)
        Me.did.TabIndex = 1
        Me.did.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(1147, 23)
        Me.Label5.MinimumSize = New System.Drawing.Size(95, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(95, 32)
        Me.Label5.TabIndex = 42
        Me.Label5.Text = "رقم الطبيب"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dident
        '
        Me.dident.Location = New System.Drawing.Point(1031, 80)
        Me.dident.MaxLength = 10
        Me.dident.Name = "dident"
        Me.dident.Size = New System.Drawing.Size(121, 24)
        Me.dident.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(1151, 80)
        Me.Label4.MinimumSize = New System.Drawing.Size(90, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(90, 32)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "رقم الهوية"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(270, 23)
        Me.Label3.MinimumSize = New System.Drawing.Size(70, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 32)
        Me.Label3.TabIndex = 38
        Me.Label3.Text = "العيادة"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'clinic
        '
        Me.clinic.Location = New System.Drawing.Point(19, 23)
        Me.clinic.Name = "clinic"
        Me.clinic.Size = New System.Drawing.Size(251, 24)
        Me.clinic.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(589, 23)
        Me.Label1.MinimumSize = New System.Drawing.Size(70, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(70, 32)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "القسم"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dept
        '
        Me.dept.Location = New System.Drawing.Point(346, 23)
        Me.dept.Name = "dept"
        Me.dept.Size = New System.Drawing.Size(244, 24)
        Me.dept.TabIndex = 3
        '
        'dspec
        '
        Me.dspec.Location = New System.Drawing.Point(19, 80)
        Me.dspec.Name = "dspec"
        Me.dspec.Size = New System.Drawing.Size(172, 24)
        Me.dspec.TabIndex = 11
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.Label11.ForeColor = System.Drawing.Color.White
        Me.Label11.Location = New System.Drawing.Point(190, 80)
        Me.Label11.MinimumSize = New System.Drawing.Size(65, 32)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(65, 32)
        Me.Label11.TabIndex = 24
        Me.Label11.Text = "التخصص"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dphone
        '
        Me.dphone.Location = New System.Drawing.Point(967, 127)
        Me.dphone.MaxLength = 10
        Me.dphone.Name = "dphone"
        Me.dphone.Size = New System.Drawing.Size(166, 24)
        Me.dphone.TabIndex = 12
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.Label16.ForeColor = System.Drawing.Color.White
        Me.Label16.Location = New System.Drawing.Point(1132, 127)
        Me.Label16.MinimumSize = New System.Drawing.Size(110, 32)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(110, 32)
        Me.Label16.TabIndex = 34
        Me.Label16.Text = "رقــــم الجـــوال"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'daddress
        '
        Me.daddress.Location = New System.Drawing.Point(537, 127)
        Me.daddress.Name = "daddress"
        Me.daddress.Size = New System.Drawing.Size(329, 24)
        Me.daddress.TabIndex = 13
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.Label13.ForeColor = System.Drawing.Color.White
        Me.Label13.Location = New System.Drawing.Point(865, 127)
        Me.Label13.MinimumSize = New System.Drawing.Size(80, 32)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(80, 32)
        Me.Label13.TabIndex = 28
        Me.Label13.Text = "العنـــوان"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.Label10.ForeColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(378, 80)
        Me.Label10.MinimumSize = New System.Drawing.Size(115, 32)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(115, 32)
        Me.Label10.TabIndex = 23
        Me.Label10.Text = "الحالة الإجتماعية"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dmstat
        '
        Me.dmstat.Items.AddRange(New Object() {"ـــــــــــــــــــــ", "متزوج", "غير متزوج"})
        Me.dmstat.Location = New System.Drawing.Point(263, 80)
        Me.dmstat.Name = "dmstat"
        Me.dmstat.Size = New System.Drawing.Size(116, 24)
        Me.dmstat.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.Label9.ForeColor = System.Drawing.Color.White
        Me.Label9.Location = New System.Drawing.Point(624, 80)
        Me.Label9.MinimumSize = New System.Drawing.Size(65, 32)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(65, 32)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "الديــانة"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dreg
        '
        Me.dreg.Items.AddRange(New Object() {"ـــــــــــــــــــــ", "الإسلام", "المسيحية", "اليهودية", "الهندوسية", "اخرى"})
        Me.dreg.Location = New System.Drawing.Point(500, 80)
        Me.dreg.Name = "dreg"
        Me.dreg.Size = New System.Drawing.Size(125, 24)
        Me.dreg.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(804, 80)
        Me.Label8.MinimumSize = New System.Drawing.Size(70, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(70, 32)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "الجنسية"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dnat
        '
        Me.dnat.Location = New System.Drawing.Point(696, 80)
        Me.dnat.Name = "dnat"
        Me.dnat.Size = New System.Drawing.Size(108, 24)
        Me.dnat.TabIndex = 8
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(964, 80)
        Me.Label7.MinimumSize = New System.Drawing.Size(60, 32)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(60, 32)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "الجنس"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'dgender
        '
        Me.dgender.Items.AddRange(New Object() {"ذكر", "انثى"})
        Me.dgender.Location = New System.Drawing.Point(881, 80)
        Me.dgender.Name = "dgender"
        Me.dgender.Size = New System.Drawing.Size(84, 24)
        Me.dgender.TabIndex = 6
        '
        'dname
        '
        Me.dname.Location = New System.Drawing.Point(666, 23)
        Me.dname.Name = "dname"
        Me.dname.Size = New System.Drawing.Size(276, 24)
        Me.dname.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(941, 23)
        Me.Label2.MinimumSize = New System.Drawing.Size(90, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 32)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "اسم الطبيب"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Button2
        '
        Me.Button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.Location = New System.Drawing.Point(678, 645)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(128, 35)
        Me.Button2.TabIndex = 1
        Me.Button2.TabStop = False
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        '
        'DataGridViewImageColumn1
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        DataGridViewCellStyle5.NullValue = Nothing
        Me.DataGridViewImageColumn1.DefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridViewImageColumn1.HeaderText = "عرض"
        Me.DataGridViewImageColumn1.Image = Global.HiTech.My.Resources.Resources.view
        Me.DataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch
        Me.DataGridViewImageColumn1.Name = "DataGridViewImageColumn1"
        Me.DataGridViewImageColumn1.ReadOnly = True
        Me.DataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewImageColumn1.Width = 50
        '
        'DataGridViewImageColumn2
        '
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        DataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle6.NullValue = Nothing
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black
        Me.DataGridViewImageColumn2.DefaultCellStyle = DataGridViewCellStyle6
        Me.DataGridViewImageColumn2.HeaderText = "طباعة"
        Me.DataGridViewImageColumn2.Image = Global.HiTech.My.Resources.Resources.print1
        Me.DataGridViewImageColumn2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.DataGridViewImageColumn2.Name = "DataGridViewImageColumn2"
        Me.DataGridViewImageColumn2.ReadOnly = True
        Me.DataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewImageColumn2.Width = 50
        '
        'DataGridViewImageColumn3
        '
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(66, Byte), Integer))
        DataGridViewCellStyle7.ForeColor = System.Drawing.Color.White
        DataGridViewCellStyle7.NullValue = Nothing
        DataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(CType(CType(219, Byte), Integer), CType(CType(41, Byte), Integer), CType(CType(66, Byte), Integer))
        DataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White
        Me.DataGridViewImageColumn3.DefaultCellStyle = DataGridViewCellStyle7
        Me.DataGridViewImageColumn3.HeaderText = "حذف"
        Me.DataGridViewImageColumn3.Image = Global.HiTech.My.Resources.Resources.delete
        Me.DataGridViewImageColumn3.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom
        Me.DataGridViewImageColumn3.Name = "DataGridViewImageColumn3"
        Me.DataGridViewImageColumn3.ReadOnly = True
        Me.DataGridViewImageColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewImageColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.DataGridViewImageColumn3.Width = 50
        '
        'Doctors
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
        Me.Name = "Doctors"
        Me.Opacity = 0.98R
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "الأطباء"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.data, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents frmtitle As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dname As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dgender As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dnat As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents dmstat As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dreg As System.Windows.Forms.ComboBox
    Friend WithEvents dspec As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents daddress As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents dphone As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents data As System.Windows.Forms.DataGridView
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents id As System.Windows.Forms.TextBox
    Friend WithEvents noru As System.Windows.Forms.TextBox
    Friend WithEvents DataGridViewImageColumn1 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents DataGridViewImageColumn2 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents DataGridViewImageColumn3 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents serial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Column4 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Column6 As System.Windows.Forms.DataGridViewImageColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents clinic As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dept As System.Windows.Forms.ComboBox
    Friend WithEvents dident As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents did As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents upass As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents uname As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents uid As System.Windows.Forms.TextBox

End Class
