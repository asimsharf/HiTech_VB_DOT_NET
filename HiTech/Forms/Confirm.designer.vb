<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Confirm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Confirm))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.id = New System.Windows.Forms.TextBox()
        Me.field = New System.Windows.Forms.TextBox()
        Me.table = New System.Windows.Forms.TextBox()
        Me.imoji = New System.Windows.Forms.PictureBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.msgtxt = New System.Windows.Forms.Label()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel1.SuspendLayout()
        CType(Me.imoji, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.id)
        Me.Panel1.Controls.Add(Me.field)
        Me.Panel1.Controls.Add(Me.table)
        Me.Panel1.Controls.Add(Me.imoji)
        Me.Panel1.Controls.Add(Me.Button2)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.msgtxt)
        Me.Panel1.Location = New System.Drawing.Point(4, 5)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.MaximumSize = New System.Drawing.Size(1283, 689)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(492, 291)
        Me.Panel1.TabIndex = 0
        '
        'id
        '
        Me.id.Location = New System.Drawing.Point(384, 67)
        Me.id.Name = "id"
        Me.id.Size = New System.Drawing.Size(100, 24)
        Me.id.TabIndex = 16
        Me.id.Visible = False
        '
        'field
        '
        Me.field.Location = New System.Drawing.Point(384, 37)
        Me.field.Name = "field"
        Me.field.Size = New System.Drawing.Size(100, 24)
        Me.field.TabIndex = 16
        Me.field.Visible = False
        '
        'table
        '
        Me.table.Location = New System.Drawing.Point(384, 7)
        Me.table.Name = "table"
        Me.table.Size = New System.Drawing.Size(100, 24)
        Me.table.TabIndex = 16
        Me.table.Visible = False
        '
        'imoji
        '
        Me.imoji.Image = Global.HiTech.My.Resources.Resources.question
        Me.imoji.Location = New System.Drawing.Point(203, 27)
        Me.imoji.Name = "imoji"
        Me.imoji.Size = New System.Drawing.Size(81, 81)
        Me.imoji.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.imoji.TabIndex = 15
        Me.imoji.TabStop = False
        '
        'Button2
        '
        Me.Button2.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.Button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button2.ForeColor = System.Drawing.Color.White
        Me.Button2.Location = New System.Drawing.Point(79, 233)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(106, 39)
        Me.Button2.TabIndex = 14
        Me.Button2.TabStop = False
        Me.Button2.Text = "تراجع"
        Me.Button2.UseVisualStyleBackColor = False
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(317, 233)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(106, 39)
        Me.Button1.TabIndex = 14
        Me.Button1.TabStop = False
        Me.Button1.Text = "تأكيد"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'msgtxt
        '
        Me.msgtxt.AutoSize = True
        Me.msgtxt.Location = New System.Drawing.Point(47, 121)
        Me.msgtxt.MaximumSize = New System.Drawing.Size(400, 70)
        Me.msgtxt.MinimumSize = New System.Drawing.Size(400, 70)
        Me.msgtxt.Name = "msgtxt"
        Me.msgtxt.Size = New System.Drawing.Size(400, 70)
        Me.msgtxt.TabIndex = 0
        Me.msgtxt.Text = "هل ترغب بالفعل بتنفيذ عملية الحذف؟"
        Me.msgtxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Confirm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(238, Byte), Integer), CType(CType(144, Byte), Integer), CType(CType(61, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(500, 300)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximumSize = New System.Drawing.Size(500, 300)
        Me.MinimumSize = New System.Drawing.Size(500, 300)
        Me.Name = "Confirm"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.RightToLeftLayout = True
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "العيادات"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.imoji, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents msgtxt As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents imoji As System.Windows.Forms.PictureBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents id As System.Windows.Forms.TextBox
    Friend WithEvents table As System.Windows.Forms.TextBox
    Friend WithEvents field As System.Windows.Forms.TextBox

End Class
