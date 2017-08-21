Namespace UserControls
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ucCreateUser
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
            Me.lblUserName = New System.Windows.Forms.Label
            Me.txtUserName = New System.Windows.Forms.TextBox
            Me.grpAuthSettings = New System.Windows.Forms.GroupBox
            Me.optBoth = New System.Windows.Forms.RadioButton
            Me.optDomain = New System.Windows.Forms.RadioButton
            Me.optDevpp = New System.Windows.Forms.RadioButton
            Me.btnSave = New System.Windows.Forms.Button
            Me.btnCancel = New System.Windows.Forms.Button
            Me.Panel1 = New System.Windows.Forms.Panel
            Me.grpAuthSettings.SuspendLayout()
            Me.SuspendLayout()
            '
            'lblUserName
            '
            Me.lblUserName.AutoSize = True
            Me.lblUserName.Location = New System.Drawing.Point(29, 65)
            Me.lblUserName.Name = "lblUserName"
            Me.lblUserName.Size = New System.Drawing.Size(61, 13)
            Me.lblUserName.TabIndex = 0
            Me.lblUserName.Text = "User name:"
            '
            'txtUserName
            '
            Me.txtUserName.Location = New System.Drawing.Point(96, 62)
            Me.txtUserName.Name = "txtUserName"
            Me.txtUserName.Size = New System.Drawing.Size(186, 20)
            Me.txtUserName.TabIndex = 3
            '
            'grpAuthSettings
            '
            Me.grpAuthSettings.Controls.Add(Me.optBoth)
            Me.grpAuthSettings.Controls.Add(Me.optDomain)
            Me.grpAuthSettings.Controls.Add(Me.optDevpp)
            Me.grpAuthSettings.Location = New System.Drawing.Point(32, 93)
            Me.grpAuthSettings.Name = "grpAuthSettings"
            Me.grpAuthSettings.Size = New System.Drawing.Size(250, 85)
            Me.grpAuthSettings.TabIndex = 6
            Me.grpAuthSettings.TabStop = False
            Me.grpAuthSettings.Text = "Authentication Settings"
            '
            'optBoth
            '
            Me.optBoth.Location = New System.Drawing.Point(18, 56)
            Me.optBoth.Name = "optBoth"
            Me.optBoth.Size = New System.Drawing.Size(104, 24)
            Me.optBoth.TabIndex = 7
            Me.optBoth.Text = "Both"
            Me.optBoth.UseVisualStyleBackColor = True
            '
            'optDomain
            '
            Me.optDomain.Checked = True
            Me.optDomain.Location = New System.Drawing.Point(18, 15)
            Me.optDomain.Name = "optDomain"
            Me.optDomain.Size = New System.Drawing.Size(137, 24)
            Me.optDomain.TabIndex = 5
            Me.optDomain.TabStop = True
            Me.optDomain.Text = "Domain Controlled"
            Me.optDomain.UseVisualStyleBackColor = True
            '
            'optDevpp
            '
            Me.optDevpp.Location = New System.Drawing.Point(18, 37)
            Me.optDevpp.Name = "optDevpp"
            Me.optDevpp.Size = New System.Drawing.Size(214, 20)
            Me.optDevpp.TabIndex = 6
            Me.optDevpp.Text = "Devpp Authentication" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
            Me.optDevpp.UseVisualStyleBackColor = True
            '
            'btnSave
            '
            Me.btnSave.Location = New System.Drawing.Point(32, 184)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(75, 23)
            Me.btnSave.TabIndex = 7
            Me.btnSave.Text = "&Save"
            Me.btnSave.UseVisualStyleBackColor = True
            '
            'btnCancel
            '
            Me.btnCancel.Location = New System.Drawing.Point(126, 184)
            Me.btnCancel.Name = "btnCancel"
            Me.btnCancel.Size = New System.Drawing.Size(75, 23)
            Me.btnCancel.TabIndex = 8
            Me.btnCancel.Text = "Cancel"
            Me.btnCancel.UseVisualStyleBackColor = True
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel1.Location = New System.Drawing.Point(0, 0)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(413, 31)
            Me.Panel1.TabIndex = 9
            '
            'ucCreateUser
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.Panel1)
            Me.Controls.Add(Me.btnCancel)
            Me.Controls.Add(Me.btnSave)
            Me.Controls.Add(Me.grpAuthSettings)
            Me.Controls.Add(Me.txtUserName)
            Me.Controls.Add(Me.lblUserName)
            Me.Name = "ucCreateUser"
            Me.Size = New System.Drawing.Size(413, 222)
            Me.grpAuthSettings.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents lblUserName As System.Windows.Forms.Label
        Friend WithEvents txtUserName As System.Windows.Forms.TextBox
        Friend WithEvents grpAuthSettings As System.Windows.Forms.GroupBox
        Friend WithEvents optBoth As System.Windows.Forms.RadioButton
        Friend WithEvents optDomain As System.Windows.Forms.RadioButton
        Friend WithEvents optDevpp As System.Windows.Forms.RadioButton
        Friend WithEvents btnSave As System.Windows.Forms.Button
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents Panel1 As System.Windows.Forms.Panel

    End Class
End Namespace