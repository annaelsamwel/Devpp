Namespace UserControls
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ucGroups
        Inherits System.Windows.Forms.UserControl

        'UserControl overrides dispose to clean up the component list.
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
            Me.SplitContainer1 = New System.Windows.Forms.SplitContainer
            Me.Panel1 = New System.Windows.Forms.Panel
            Me.rdoNonActiveGroups = New System.Windows.Forms.RadioButton
            Me.rdoActiveGroup = New System.Windows.Forms.RadioButton
            Me.Label2 = New System.Windows.Forms.Label
            Me.pnlGroups = New System.Windows.Forms.Panel
            Me.Label1 = New System.Windows.Forms.Label
            Me.Panel3 = New System.Windows.Forms.Panel
            Me.pnlRight = New System.Windows.Forms.Panel
            Me.Panel2 = New System.Windows.Forms.Panel
            Me.btnCancel = New System.Windows.Forms.Label
            Me.Label3 = New System.Windows.Forms.Label
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            Me.Panel1.SuspendLayout()
            Me.Panel3.SuspendLayout()
            Me.Panel2.SuspendLayout()
            Me.SuspendLayout()
            '
            'SplitContainer1
            '
            Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Left
            Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
            Me.SplitContainer1.IsSplitterFixed = True
            Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
            Me.SplitContainer1.Name = "SplitContainer1"
            Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
            '
            'SplitContainer1.Panel1
            '
            Me.SplitContainer1.Panel1.Controls.Add(Me.Panel1)
            Me.SplitContainer1.Panel1.Controls.Add(Me.Label2)
            '
            'SplitContainer1.Panel2
            '
            Me.SplitContainer1.Panel2.Controls.Add(Me.pnlGroups)
            Me.SplitContainer1.Panel2.Controls.Add(Me.Label1)
            Me.SplitContainer1.Size = New System.Drawing.Size(150, 491)
            Me.SplitContainer1.SplitterDistance = 112
            Me.SplitContainer1.TabIndex = 0
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel1.Controls.Add(Me.rdoNonActiveGroups)
            Me.Panel1.Controls.Add(Me.rdoActiveGroup)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Panel1.Location = New System.Drawing.Point(0, 22)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(148, 88)
            Me.Panel1.TabIndex = 2
            '
            'rdoNonActiveGroups
            '
            Me.rdoNonActiveGroups.AutoSize = True
            Me.rdoNonActiveGroups.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rdoNonActiveGroups.ForeColor = System.Drawing.Color.DarkGreen
            Me.rdoNonActiveGroups.Location = New System.Drawing.Point(4, 35)
            Me.rdoNonActiveGroups.Name = "rdoNonActiveGroups"
            Me.rdoNonActiveGroups.Size = New System.Drawing.Size(119, 17)
            Me.rdoNonActiveGroups.TabIndex = 1
            Me.rdoNonActiveGroups.Text = "In-active Groups"
            Me.rdoNonActiveGroups.UseVisualStyleBackColor = True
            '
            'rdoActiveGroup
            '
            Me.rdoActiveGroup.AutoSize = True
            Me.rdoActiveGroup.Checked = True
            Me.rdoActiveGroup.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.rdoActiveGroup.ForeColor = System.Drawing.Color.DarkGreen
            Me.rdoActiveGroup.Location = New System.Drawing.Point(3, 3)
            Me.rdoActiveGroup.Name = "rdoActiveGroup"
            Me.rdoActiveGroup.Size = New System.Drawing.Size(105, 17)
            Me.rdoActiveGroup.TabIndex = 0
            Me.rdoActiveGroup.TabStop = True
            Me.rdoActiveGroup.Text = "Active Groups"
            Me.rdoActiveGroup.UseVisualStyleBackColor = True
            '
            'Label2
            '
            Me.Label2.BackColor = System.Drawing.Color.White
            Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
            Me.Label2.Location = New System.Drawing.Point(0, 0)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(148, 22)
            Me.Label2.TabIndex = 1
            '
            'pnlGroups
            '
            Me.pnlGroups.BackColor = System.Drawing.Color.AliceBlue
            Me.pnlGroups.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlGroups.ForeColor = System.Drawing.Color.Blue
            Me.pnlGroups.Location = New System.Drawing.Point(0, 28)
            Me.pnlGroups.Name = "pnlGroups"
            Me.pnlGroups.Size = New System.Drawing.Size(148, 345)
            Me.pnlGroups.TabIndex = 1
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.White
            Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.DarkGreen
            Me.Label1.Location = New System.Drawing.Point(0, 0)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(148, 28)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Groups"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'Panel3
            '
            Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel3.Controls.Add(Me.pnlRight)
            Me.Panel3.Controls.Add(Me.Panel2)
            Me.Panel3.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Panel3.Location = New System.Drawing.Point(150, 0)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(263, 491)
            Me.Panel3.TabIndex = 1
            '
            'pnlRight
            '
            Me.pnlRight.BackColor = System.Drawing.Color.White
            Me.pnlRight.Dock = System.Windows.Forms.DockStyle.Fill
            Me.pnlRight.Location = New System.Drawing.Point(0, 22)
            Me.pnlRight.Name = "pnlRight"
            Me.pnlRight.Size = New System.Drawing.Size(261, 467)
            Me.pnlRight.TabIndex = 3
            '
            'Panel2
            '
            Me.Panel2.BackColor = System.Drawing.Color.WhiteSmoke
            Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel2.Controls.Add(Me.btnCancel)
            Me.Panel2.Controls.Add(Me.Label3)
            Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel2.Location = New System.Drawing.Point(0, 0)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(261, 22)
            Me.Panel2.TabIndex = 4
            '
            'btnCancel
            '
            Me.btnCancel.BackColor = System.Drawing.Color.Silver
            Me.btnCancel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Right
            Me.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.btnCancel.ForeColor = System.Drawing.Color.Black
            Me.btnCancel.Location = New System.Drawing.Point(198, 0)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(61, 20)
            Me.btnCancel.TabIndex = 6
            Me.btnCancel.Text = "&Cancel"
            Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.TopCenter
            '
            'Label3
            '
            Me.Label3.BackColor = System.Drawing.Color.WhiteSmoke
            Me.Label3.Dock = System.Windows.Forms.DockStyle.Left
            Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label3.ForeColor = System.Drawing.Color.DarkGreen
            Me.Label3.Location = New System.Drawing.Point(0, 0)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(102, 20)
            Me.Label3.TabIndex = 3
            Me.Label3.Text = "System Rights"
            '
            'ucGroups
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.Panel3)
            Me.Controls.Add(Me.SplitContainer1)
            Me.Name = "ucGroups"
            Me.Size = New System.Drawing.Size(413, 491)
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            Me.SplitContainer1.ResumeLayout(False)
            Me.Panel1.ResumeLayout(False)
            Me.Panel1.PerformLayout()
            Me.Panel3.ResumeLayout(False)
            Me.Panel2.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents rdoNonActiveGroups As System.Windows.Forms.RadioButton
        Friend WithEvents rdoActiveGroup As System.Windows.Forms.RadioButton
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents pnlGroups As System.Windows.Forms.Panel
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents pnlRight As System.Windows.Forms.Panel
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents btnCancel As System.Windows.Forms.Label

    End Class
End Namespace