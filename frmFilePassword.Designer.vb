<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFilePassword
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
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnOk = New System.Windows.Forms.Button
        Me.CNetHelpProvider = New System.Windows.Forms.HelpProvider
        Me.SuspendLayout()
        '
        'txtPassword
        '
        Me.CNetHelpProvider.SetHelpKeyword(Me.txtPassword, "Dev++_Form_frmFilePassword.htm#frmFilePassword_txtPassword")
        Me.CNetHelpProvider.SetHelpNavigator(Me.txtPassword, System.Windows.Forms.HelpNavigator.Topic)
        Me.txtPassword.Location = New System.Drawing.Point(77, 12)
        Me.txtPassword.Name = "txtPassword"
        Me.CNetHelpProvider.SetShowHelp(Me.txtPassword, True)
        Me.txtPassword.Size = New System.Drawing.Size(240, 20)
        Me.txtPassword.TabIndex = 0
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.CNetHelpProvider.SetHelpKeyword(Me.Label1, "Dev++_Form_frmFilePassword.htm#frmFilePassword_Label1")
        Me.CNetHelpProvider.SetHelpNavigator(Me.Label1, System.Windows.Forms.HelpNavigator.Topic)
        Me.Label1.Location = New System.Drawing.Point(10, 16)
        Me.Label1.Name = "Label1"
        Me.CNetHelpProvider.SetShowHelp(Me.Label1, True)
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Password:"
        '
        'btnOk
        '
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.CNetHelpProvider.SetHelpKeyword(Me.btnOk, "Dev++_Form_frmFilePassword.htm#frmFilePassword_btnOk")
        Me.CNetHelpProvider.SetHelpNavigator(Me.btnOk, System.Windows.Forms.HelpNavigator.Topic)
        Me.btnOk.Location = New System.Drawing.Point(324, 11)
        Me.btnOk.Name = "btnOk"
        Me.CNetHelpProvider.SetShowHelp(Me.btnOk, True)
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 2
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'CNetHelpProvider
        '
        Me.CNetHelpProvider.HelpNamespace = "Dev++.chm"
        '
        'frmFilePassword
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(406, 46)
        Me.ControlBox = False
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtPassword)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.CNetHelpProvider.SetHelpKeyword(Me, "Dev++_Form_frmFilePassword.htm")
        Me.CNetHelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.Topic)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmFilePassword"
        Me.CNetHelpProvider.SetShowHelp(Me, True)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "File Password"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents CNetHelpProvider As System.Windows.Forms.HelpProvider

End Class
