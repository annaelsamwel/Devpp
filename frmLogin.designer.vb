Namespace Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmLogin
        Inherits System.Windows.Forms.Form

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.lblPassword = New System.Windows.Forms.Label
            Me.txtPassword = New System.Windows.Forms.TextBox
            Me.lblUserName = New System.Windows.Forms.Label
            Me.btnOk = New System.Windows.Forms.Button
            Me.txtUserName = New System.Windows.Forms.TextBox
            Me.btnCancel = New System.Windows.Forms.Button
            Me.btnChange = New System.Windows.Forms.Button
            Me.CNetHelpProvider = New System.Windows.Forms.HelpProvider
            Me.SuspendLayout()
            '
            'lblPassword
            '
            Me.lblPassword.AutoSize = True
            Me.lblPassword.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.CNetHelpProvider.SetHelpKeyword(Me.lblPassword, "Dev++_Form_frmLogin.htm#frmLogin_lblPassword")
            Me.CNetHelpProvider.SetHelpNavigator(Me.lblPassword, System.Windows.Forms.HelpNavigator.Topic)
            Me.lblPassword.Location = New System.Drawing.Point(15, 34)
            Me.lblPassword.Name = "lblPassword"
            Me.CNetHelpProvider.SetShowHelp(Me.lblPassword, True)
            Me.lblPassword.Size = New System.Drawing.Size(56, 13)
            Me.lblPassword.TabIndex = 3
            Me.lblPassword.Text = "Password:"
            '
            'txtPassword
            '
            Me.txtPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CNetHelpProvider.SetHelpKeyword(Me.txtPassword, "Dev++_Form_frmLogin.htm#frmLogin_txtPassword")
            Me.CNetHelpProvider.SetHelpNavigator(Me.txtPassword, System.Windows.Forms.HelpNavigator.Topic)
            Me.txtPassword.Location = New System.Drawing.Point(87, 29)
            Me.txtPassword.Name = "txtPassword"
            Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
            Me.CNetHelpProvider.SetShowHelp(Me.txtPassword, True)
            Me.txtPassword.Size = New System.Drawing.Size(153, 21)
            Me.txtPassword.TabIndex = 2
            Me.txtPassword.UseSystemPasswordChar = True
            '
            'lblUserName
            '
            Me.lblUserName.AutoSize = True
            Me.lblUserName.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(0, Byte), Integer))
            Me.CNetHelpProvider.SetHelpKeyword(Me.lblUserName, "Dev++_Form_frmLogin.htm#frmLogin_lblUserName")
            Me.CNetHelpProvider.SetHelpNavigator(Me.lblUserName, System.Windows.Forms.HelpNavigator.Topic)
            Me.lblUserName.Location = New System.Drawing.Point(15, 10)
            Me.lblUserName.Name = "lblUserName"
            Me.CNetHelpProvider.SetShowHelp(Me.lblUserName, True)
            Me.lblUserName.Size = New System.Drawing.Size(63, 13)
            Me.lblUserName.TabIndex = 2
            Me.lblUserName.Text = "User Name:"
            '
            'btnOk
            '
            Me.btnOk.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CNetHelpProvider.SetHelpKeyword(Me.btnOk, "Dev++_Form_frmLogin.htm#frmLogin_btnOk")
            Me.CNetHelpProvider.SetHelpNavigator(Me.btnOk, System.Windows.Forms.HelpNavigator.Topic)
            Me.btnOk.Location = New System.Drawing.Point(8, 54)
            Me.btnOk.Name = "btnOk"
            Me.CNetHelpProvider.SetShowHelp(Me.btnOk, True)
            Me.btnOk.Size = New System.Drawing.Size(77, 22)
            Me.btnOk.TabIndex = 3
            Me.btnOk.Text = "OK"
            Me.btnOk.UseVisualStyleBackColor = True
            '
            'txtUserName
            '
            Me.txtUserName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CNetHelpProvider.SetHelpKeyword(Me.txtUserName, "Dev++_Form_frmLogin.htm#frmLogin_txtUserName")
            Me.CNetHelpProvider.SetHelpNavigator(Me.txtUserName, System.Windows.Forms.HelpNavigator.Topic)
            Me.txtUserName.Location = New System.Drawing.Point(87, 5)
            Me.txtUserName.Name = "txtUserName"
            Me.CNetHelpProvider.SetShowHelp(Me.txtUserName, True)
            Me.txtUserName.Size = New System.Drawing.Size(153, 21)
            Me.txtUserName.TabIndex = 1
            '
            'btnCancel
            '
            Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CNetHelpProvider.SetHelpKeyword(Me.btnCancel, "Dev++_Form_frmLogin.htm#frmLogin_btnCancel")
            Me.CNetHelpProvider.SetHelpNavigator(Me.btnCancel, System.Windows.Forms.HelpNavigator.Topic)
            Me.btnCancel.Location = New System.Drawing.Point(213, 54)
            Me.btnCancel.Name = "btnCancel"
            Me.CNetHelpProvider.SetShowHelp(Me.btnCancel, True)
            Me.btnCancel.Size = New System.Drawing.Size(77, 22)
            Me.btnCancel.TabIndex = 5
            Me.btnCancel.Text = "CANCEL"
            Me.btnCancel.UseVisualStyleBackColor = True
            '
            'btnChange
            '
            Me.btnChange.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CNetHelpProvider.SetHelpKeyword(Me.btnChange, "Dev++_Form_frmLogin.htm#frmLogin_btnChange")
            Me.CNetHelpProvider.SetHelpNavigator(Me.btnChange, System.Windows.Forms.HelpNavigator.Topic)
            Me.btnChange.Location = New System.Drawing.Point(112, 54)
            Me.btnChange.Name = "btnChange"
            Me.CNetHelpProvider.SetShowHelp(Me.btnChange, True)
            Me.btnChange.Size = New System.Drawing.Size(77, 22)
            Me.btnChange.TabIndex = 4
            Me.btnChange.Text = "CHANGE"
            Me.btnChange.UseVisualStyleBackColor = True
            '
            'CNetHelpProvider
            '
            Me.CNetHelpProvider.HelpNamespace = "Dev++.chm"
            '
            'frmLogin
            '
            Me.AcceptButton = Me.btnOk
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.WhiteSmoke
            Me.CancelButton = Me.btnCancel
            Me.ClientSize = New System.Drawing.Size(300, 90)
            Me.ControlBox = False
            Me.Controls.Add(Me.lblPassword)
            Me.Controls.Add(Me.btnChange)
            Me.Controls.Add(Me.txtPassword)
            Me.Controls.Add(Me.lblUserName)
            Me.Controls.Add(Me.btnOk)
            Me.Controls.Add(Me.txtUserName)
            Me.Controls.Add(Me.btnCancel)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.CNetHelpProvider.SetHelpKeyword(Me, "Dev++_Form_frmLogin.htm")
            Me.CNetHelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.Topic)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmLogin"
            Me.CNetHelpProvider.SetShowHelp(Me, True)
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "User Login"
            Me.TopMost = True
            Me.ResumeLayout(False)
            Me.PerformLayout()

        End Sub
        Friend WithEvents lblPassword As System.Windows.Forms.Label
        Friend WithEvents txtPassword As System.Windows.Forms.TextBox
        Friend WithEvents lblUserName As System.Windows.Forms.Label
        Friend WithEvents btnOk As System.Windows.Forms.Button
        Friend WithEvents txtUserName As System.Windows.Forms.TextBox
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents btnChange As System.Windows.Forms.Button
        Friend WithEvents CNetHelpProvider As System.Windows.Forms.HelpProvider
    End Class
End Namespace
