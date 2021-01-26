<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Invoicesrep3
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Invoicesrep3))
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.frmtitle = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.nat = New System.Windows.Forms.ComboBox()
        Me.serchn = New System.Windows.Forms.Button()
        Me.specnat = New System.Windows.Forms.RadioButton()
        Me.allnats = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.d2 = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.d1 = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.crv = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
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
        'Panel1
        '
        Me.Panel1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.crv)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(3, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1277, 685)
        Me.Panel1.TabIndex = 0
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.nat)
        Me.GroupBox1.Controls.Add(Me.serchn)
        Me.GroupBox1.Controls.Add(Me.specnat)
        Me.GroupBox1.Controls.Add(Me.allnats)
        Me.GroupBox1.Location = New System.Drawing.Point(1000, 209)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(251, 179)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'nat
        '
        Me.nat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.nat.Location = New System.Drawing.Point(47, 133)
        Me.nat.Name = "nat"
        Me.nat.Size = New System.Drawing.Size(189, 24)
        Me.nat.TabIndex = 63
        '
        'serchn
        '
        Me.serchn.BackgroundImage = Global.HiTech.My.Resources.Resources.srch
        Me.serchn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.serchn.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.serchn.Location = New System.Drawing.Point(15, 133)
        Me.serchn.Name = "serchn"
        Me.serchn.Size = New System.Drawing.Size(32, 32)
        Me.serchn.TabIndex = 62
        Me.serchn.UseVisualStyleBackColor = True
        '
        'specnat
        '
        Me.specnat.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.specnat.AutoSize = True
        Me.specnat.Location = New System.Drawing.Point(122, 78)
        Me.specnat.Name = "specnat"
        Me.specnat.Size = New System.Drawing.Size(114, 21)
        Me.specnat.TabIndex = 6
        Me.specnat.Text = "جنسية محددة"
        Me.specnat.UseVisualStyleBackColor = True
        '
        'allnats
        '
        Me.allnats.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.allnats.AutoSize = True
        Me.allnats.Checked = True
        Me.allnats.Location = New System.Drawing.Point(129, 41)
        Me.allnats.Name = "allnats"
        Me.allnats.Size = New System.Drawing.Size(107, 21)
        Me.allnats.TabIndex = 5
        Me.allnats.TabStop = True
        Me.allnats.Text = "كل الجنسيات"
        Me.allnats.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox2.Controls.Add(Me.d2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.d1)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(1000, 47)
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
        'Invoicesrep2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1283, 689)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Name = "Invoicesrep2"
        Me.Opacity = 0.98R
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "تقرير ضريبي"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents frmtitle As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents crv As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents d1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents d2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents serchn As System.Windows.Forms.Button
    Friend WithEvents specnat As System.Windows.Forms.RadioButton
    Friend WithEvents allnats As System.Windows.Forms.RadioButton
    Friend WithEvents nat As System.Windows.Forms.ComboBox

End Class
