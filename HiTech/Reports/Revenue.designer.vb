<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Revenue
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Revenue))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.invno = New System.Windows.Forms.TextBox()
        Me.frmtitle = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.asusers = New System.Windows.Forms.RadioButton()
        Me.asdoctors = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.uname = New System.Windows.Forms.TextBox()
        Me.specuser = New System.Windows.Forms.RadioButton()
        Me.allusers = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.d2 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.d1 = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dname = New System.Windows.Forms.TextBox()
        Me.specdoctor = New System.Windows.Forms.RadioButton()
        Me.alldoctors = New System.Windows.Forms.RadioButton()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.crv = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.serchu = New System.Windows.Forms.Button()
        Me.serchd = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.Panel2.Controls.Add(Me.invno)
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
        'invno
        '
        Me.invno.Location = New System.Drawing.Point(3, 8)
        Me.invno.Name = "invno"
        Me.invno.ReadOnly = True
        Me.invno.Size = New System.Drawing.Size(89, 24)
        Me.invno.TabIndex = 2
        Me.invno.Visible = False
        '
        'frmtitle
        '
        Me.frmtitle.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.frmtitle.AutoSize = True
        Me.frmtitle.ForeColor = System.Drawing.Color.White
        Me.frmtitle.Location = New System.Drawing.Point(1000, 8)
        Me.frmtitle.MinimumSize = New System.Drawing.Size(200, 17)
        Me.frmtitle.Name = "frmtitle"
        Me.frmtitle.Size = New System.Drawing.Size(200, 17)
        Me.frmtitle.TabIndex = 7
        Me.frmtitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.asusers)
        Me.Panel1.Controls.Add(Me.asdoctors)
        Me.Panel1.Controls.Add(Me.GroupBox3)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.crv)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(3, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1277, 685)
        Me.Panel1.TabIndex = 0
        '
        'asusers
        '
        Me.asusers.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.asusers.AutoSize = True
        Me.asusers.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.asusers.Location = New System.Drawing.Point(1104, 267)
        Me.asusers.Name = "asusers"
        Me.asusers.Size = New System.Drawing.Size(147, 21)
        Me.asusers.TabIndex = 63
        Me.asusers.TabStop = True
        Me.asusers.Text = "حسب المستخدمين"
        Me.asusers.UseVisualStyleBackColor = True
        '
        'asdoctors
        '
        Me.asdoctors.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.asdoctors.AutoSize = True
        Me.asdoctors.ForeColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.asdoctors.Location = New System.Drawing.Point(1146, 52)
        Me.asdoctors.Name = "asdoctors"
        Me.asdoctors.Size = New System.Drawing.Size(105, 21)
        Me.asdoctors.TabIndex = 63
        Me.asdoctors.TabStop = True
        Me.asdoctors.Text = "حسب الأطباء"
        Me.asdoctors.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox3.Controls.Add(Me.serchu)
        Me.GroupBox3.Controls.Add(Me.uname)
        Me.GroupBox3.Controls.Add(Me.specuser)
        Me.GroupBox3.Controls.Add(Me.allusers)
        Me.GroupBox3.Location = New System.Drawing.Point(1000, 285)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(251, 179)
        Me.GroupBox3.TabIndex = 64
        Me.GroupBox3.TabStop = False
        '
        'uname
        '
        Me.uname.BackColor = System.Drawing.Color.White
        Me.uname.Location = New System.Drawing.Point(45, 133)
        Me.uname.Name = "uname"
        Me.uname.ReadOnly = True
        Me.uname.Size = New System.Drawing.Size(191, 24)
        Me.uname.TabIndex = 61
        '
        'specuser
        '
        Me.specuser.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.specuser.AutoSize = True
        Me.specuser.Location = New System.Drawing.Point(118, 78)
        Me.specuser.Name = "specuser"
        Me.specuser.Size = New System.Drawing.Size(118, 21)
        Me.specuser.TabIndex = 6
        Me.specuser.TabStop = True
        Me.specuser.Text = "مستخدم محدد"
        Me.specuser.UseVisualStyleBackColor = True
        '
        'allusers
        '
        Me.allusers.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.allusers.AutoSize = True
        Me.allusers.Location = New System.Drawing.Point(109, 41)
        Me.allusers.Name = "allusers"
        Me.allusers.Size = New System.Drawing.Size(127, 21)
        Me.allusers.TabIndex = 5
        Me.allusers.TabStop = True
        Me.allusers.Text = "كل المستخدمين"
        Me.allusers.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.d2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.d1)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(1000, 470)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(251, 139)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "الفترة"
        '
        'd2
        '
        Me.d2.CustomFormat = "yyyy-MM-dd"
        Me.d2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.d2.Location = New System.Drawing.Point(14, 82)
        Me.d2.Name = "d2"
        Me.d2.RightToLeftLayout = True
        Me.d2.Size = New System.Drawing.Size(178, 24)
        Me.d2.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(192, 82)
        Me.Label1.MinimumSize = New System.Drawing.Size(45, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 32)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "إلى"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'd1
        '
        Me.d1.CustomFormat = "yyyy-MM-dd"
        Me.d1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.d1.Location = New System.Drawing.Point(14, 34)
        Me.d1.Name = "d1"
        Me.d1.RightToLeftLayout = True
        Me.d1.Size = New System.Drawing.Size(178, 24)
        Me.d1.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(193, 34)
        Me.Label5.MinimumSize = New System.Drawing.Size(45, 32)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 32)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "من"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.serchd)
        Me.GroupBox1.Controls.Add(Me.dname)
        Me.GroupBox1.Controls.Add(Me.specdoctor)
        Me.GroupBox1.Controls.Add(Me.alldoctors)
        Me.GroupBox1.Location = New System.Drawing.Point(1000, 75)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(251, 179)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'dname
        '
        Me.dname.BackColor = System.Drawing.Color.White
        Me.dname.Location = New System.Drawing.Point(45, 133)
        Me.dname.Name = "dname"
        Me.dname.ReadOnly = True
        Me.dname.Size = New System.Drawing.Size(191, 24)
        Me.dname.TabIndex = 61
        '
        'specdoctor
        '
        Me.specdoctor.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.specdoctor.AutoSize = True
        Me.specdoctor.Location = New System.Drawing.Point(139, 78)
        Me.specdoctor.Name = "specdoctor"
        Me.specdoctor.Size = New System.Drawing.Size(97, 21)
        Me.specdoctor.TabIndex = 6
        Me.specdoctor.TabStop = True
        Me.specdoctor.Text = "طبيب محدد"
        Me.specdoctor.UseVisualStyleBackColor = True
        '
        'alldoctors
        '
        Me.alldoctors.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.alldoctors.AutoSize = True
        Me.alldoctors.Location = New System.Drawing.Point(151, 41)
        Me.alldoctors.Name = "alldoctors"
        Me.alldoctors.Size = New System.Drawing.Size(85, 21)
        Me.alldoctors.TabIndex = 5
        Me.alldoctors.TabStop = True
        Me.alldoctors.Text = "كل الأطباء"
        Me.alldoctors.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.Button2.FlatAppearance.BorderSize = 0
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(1000, 625)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(251, 46)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "عرض التقرير"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'crv
        '
        Me.crv.ActiveViewIndex = -1
        Me.crv.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.crv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crv.Cursor = System.Windows.Forms.Cursors.Default
        Me.crv.Location = New System.Drawing.Point(0, 37)
        Me.crv.Name = "crv"
        Me.crv.ShowCloseButton = False
        Me.crv.ShowGroupTreeButton = False
        Me.crv.ShowLogo = False
        Me.crv.ShowParameterPanelButton = False
        Me.crv.ShowRefreshButton = False
        Me.crv.Size = New System.Drawing.Size(975, 647)
        Me.crv.TabIndex = 1
        Me.crv.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'serchu
        '
        Me.serchu.BackgroundImage = Global.HiTech.My.Resources.Resources.srch
        Me.serchu.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.serchu.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.serchu.Location = New System.Drawing.Point(15, 133)
        Me.serchu.Name = "serchu"
        Me.serchu.Size = New System.Drawing.Size(32, 32)
        Me.serchu.TabIndex = 62
        Me.serchu.UseVisualStyleBackColor = True
        '
        'serchd
        '
        Me.serchd.BackgroundImage = Global.HiTech.My.Resources.Resources.srch
        Me.serchd.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.serchd.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.serchd.Location = New System.Drawing.Point(15, 133)
        Me.serchd.Name = "serchd"
        Me.serchd.Size = New System.Drawing.Size(32, 32)
        Me.serchd.TabIndex = 62
        Me.serchd.UseVisualStyleBackColor = True
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
        'Revenue
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1283, 689)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Revenue"
        Me.Opacity = 0.98R
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تقرير الإيرادات"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
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
    Friend WithEvents crv As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents invno As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents specdoctor As System.Windows.Forms.RadioButton
    Friend WithEvents alldoctors As System.Windows.Forms.RadioButton
    Friend WithEvents d1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents d2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents serchd As System.Windows.Forms.Button
    Friend WithEvents dname As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents asusers As System.Windows.Forms.RadioButton
    Friend WithEvents serchu As System.Windows.Forms.Button
    Friend WithEvents uname As System.Windows.Forms.TextBox
    Friend WithEvents specuser As System.Windows.Forms.RadioButton
    Friend WithEvents allusers As System.Windows.Forms.RadioButton
    Friend WithEvents asdoctors As System.Windows.Forms.RadioButton

End Class
