﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SqlServerSetting
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SqlServerSetting))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnBlankDataDB = New System.Windows.Forms.Button()
        Me.btnTestConnection = New System.Windows.Forms.Button()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbAuthentication = New System.Windows.Forms.ComboBox()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.cmbServerName = New System.Windows.Forms.ComboBox()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.txtUserName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnCreateDemoDataDB = New System.Windows.Forms.Button()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblSet = New System.Windows.Forms.Label()
        Me.Timer3 = New System.Windows.Forms.Timer(Me.components)
        Me.Panel1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Location = New System.Drawing.Point(3, 4)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(729, 289)
        Me.Panel1.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnBlankDataDB)
        Me.GroupBox1.Controls.Add(Me.btnTestConnection)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cmbAuthentication)
        Me.GroupBox1.Controls.Add(Me.LinkLabel1)
        Me.GroupBox1.Controls.Add(Me.cmbServerName)
        Me.GroupBox1.Controls.Add(Me.txtPassword)
        Me.GroupBox1.Controls.Add(Me.txtUserName)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.btnClose)
        Me.GroupBox1.Controls.Add(Me.btnCreateDemoDataDB)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 59)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.GroupBox1.Size = New System.Drawing.Size(714, 223)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "SQL Server Configuration"
        '
        'btnBlankDataDB
        '
        Me.btnBlankDataDB.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnBlankDataDB.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnBlankDataDB.FlatAppearance.BorderSize = 0
        Me.btnBlankDataDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBlankDataDB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBlankDataDB.ForeColor = System.Drawing.Color.Black
        Me.btnBlankDataDB.Image = CType(resources.GetObject("btnBlankDataDB.Image"), System.Drawing.Image)
        Me.btnBlankDataDB.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBlankDataDB.Location = New System.Drawing.Point(248, 159)
        Me.btnBlankDataDB.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnBlankDataDB.Name = "btnBlankDataDB"
        Me.btnBlankDataDB.Size = New System.Drawing.Size(346, 49)
        Me.btnBlankDataDB.TabIndex = 19
        Me.btnBlankDataDB.Text = "Connect To Server"
        Me.btnBlankDataDB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBlankDataDB.UseVisualStyleBackColor = False
        '
        'btnTestConnection
        '
        Me.btnTestConnection.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnTestConnection.FlatAppearance.BorderSize = 0
        Me.btnTestConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTestConnection.ForeColor = System.Drawing.Color.Black
        Me.btnTestConnection.Image = CType(resources.GetObject("btnTestConnection.Image"), System.Drawing.Image)
        Me.btnTestConnection.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnTestConnection.Location = New System.Drawing.Point(16, 160)
        Me.btnTestConnection.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnTestConnection.Name = "btnTestConnection"
        Me.btnTestConnection.Size = New System.Drawing.Size(226, 49)
        Me.btnTestConnection.TabIndex = 18
        Me.btnTestConnection.Text = "Test DB Connection"
        Me.btnTestConnection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnTestConnection.UseVisualStyleBackColor = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(13, 63)
        Me.Label7.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(118, 20)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Authentication :"
        '
        'cmbAuthentication
        '
        Me.cmbAuthentication.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAuthentication.FormattingEnabled = True
        Me.cmbAuthentication.Items.AddRange(New Object() {"Windows Authentication", "SQL Server Authentication"})
        Me.cmbAuthentication.Location = New System.Drawing.Point(182, 63)
        Me.cmbAuthentication.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbAuthentication.Name = "cmbAuthentication"
        Me.cmbAuthentication.Size = New System.Drawing.Size(301, 24)
        Me.cmbAuthentication.TabIndex = 2
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LinkLabel1.Location = New System.Drawing.Point(490, 30)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(122, 23)
        Me.LinkLabel1.TabIndex = 1
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Search Servers"
        '
        'cmbServerName
        '
        Me.cmbServerName.FormattingEnabled = True
        Me.cmbServerName.Location = New System.Drawing.Point(182, 30)
        Me.cmbServerName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.cmbServerName.Name = "cmbServerName"
        Me.cmbServerName.Size = New System.Drawing.Size(301, 24)
        Me.cmbServerName.TabIndex = 0
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(182, 128)
        Me.txtPassword.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(301, 24)
        Me.txtPassword.TabIndex = 6
        '
        'txtUserName
        '
        Me.txtUserName.Location = New System.Drawing.Point(182, 96)
        Me.txtUserName.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.txtUserName.Name = "txtUserName"
        Me.txtUserName.Size = New System.Drawing.Size(301, 24)
        Me.txtUserName.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(13, 96)
        Me.Label3.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(172, 20)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "SQL Server User Name :"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(13, 128)
        Me.Label2.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(146, 20)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "SQL User Password :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(13, 30)
        Me.Label5.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(137, 20)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "SQL Server Name :"
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnClose.FlatAppearance.BorderSize = 0
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Black
        Me.btnClose.Image = CType(resources.GetObject("btnClose.Image"), System.Drawing.Image)
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnClose.Location = New System.Drawing.Point(600, 160)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(101, 49)
        Me.btnClose.TabIndex = 9
        Me.btnClose.Text = "Close"
        Me.btnClose.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnCreateDemoDataDB
        '
        Me.btnCreateDemoDataDB.BackColor = System.Drawing.Color.WhiteSmoke
        Me.btnCreateDemoDataDB.Cursor = System.Windows.Forms.Cursors.Hand
        Me.btnCreateDemoDataDB.Enabled = False
        Me.btnCreateDemoDataDB.FlatAppearance.BorderSize = 0
        Me.btnCreateDemoDataDB.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCreateDemoDataDB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCreateDemoDataDB.ForeColor = System.Drawing.Color.Black
        Me.btnCreateDemoDataDB.Image = CType(resources.GetObject("btnCreateDemoDataDB.Image"), System.Drawing.Image)
        Me.btnCreateDemoDataDB.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCreateDemoDataDB.Location = New System.Drawing.Point(391, 159)
        Me.btnCreateDemoDataDB.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnCreateDemoDataDB.Name = "btnCreateDemoDataDB"
        Me.btnCreateDemoDataDB.Size = New System.Drawing.Size(202, 49)
        Me.btnCreateDemoDataDB.TabIndex = 8
        Me.btnCreateDemoDataDB.Text = "Create Demo Data DB " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "and Proceed"
        Me.btnCreateDemoDataDB.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCreateDemoDataDB.UseVisualStyleBackColor = False
        Me.btnCreateDemoDataDB.Visible = False
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.lblSet)
        Me.Panel2.Location = New System.Drawing.Point(7, 6)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(714, 46)
        Me.Panel2.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(253, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(237, 29)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "SQL Server Setting"
        '
        'lblSet
        '
        Me.lblSet.AutoSize = True
        Me.lblSet.Location = New System.Drawing.Point(93, 18)
        Me.lblSet.Name = "lblSet"
        Me.lblSet.Size = New System.Drawing.Size(28, 17)
        Me.lblSet.TabIndex = 21
        Me.lblSet.Text = "Set"
        Me.lblSet.Visible = False
        '
        'Timer3
        '
        '
        'SqlServerSetting
        '
        Me.AcceptButton = Me.btnCreateDemoDataDB
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(2, Byte), Integer), CType(CType(136, Byte), Integer), CType(CType(209, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(736, 298)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SqlServerSetting"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnCreateDemoDataDB As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents LinkLabel1 As System.Windows.Forms.LinkLabel
    Friend WithEvents cmbServerName As System.Windows.Forms.ComboBox
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtUserName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbAuthentication As System.Windows.Forms.ComboBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents lblSet As System.Windows.Forms.Label
    Friend WithEvents btnTestConnection As System.Windows.Forms.Button
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents btnBlankDataDB As System.Windows.Forms.Button
    Friend WithEvents Timer3 As System.Windows.Forms.Timer

End Class
