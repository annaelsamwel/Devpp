Namespace UserControls
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ucDefaults
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
            Me.components = New System.ComponentModel.Container
            Dim UsrPasswordValidityLabel As System.Windows.Forms.Label
            Me.lblCompanyName = New System.Windows.Forms.Label
            Me.btnBrowse = New System.Windows.Forms.Button
            Me.Label1 = New System.Windows.Forms.Label
            Me.dtCompanyStarted = New System.Windows.Forms.DateTimePicker
            Me.grpPasswordLogin = New System.Windows.Forms.GroupBox
            Me.chkAllowChangeDB = New System.Windows.Forms.CheckBox
            Me.Label4 = New System.Windows.Forms.Label
            Me.cmbAction = New System.Windows.Forms.ComboBox
            Me.chkStrongPassword = New System.Windows.Forms.CheckBox
            Me.chkBlockuser = New System.Windows.Forms.CheckBox
            Me.txtPassValidity = New System.Windows.Forms.TextBox
            Me.txtPassMinChar = New System.Windows.Forms.TextBox
            Me.Label3 = New System.Windows.Forms.Label
            Me.txtPassMaxChar = New System.Windows.Forms.TextBox
            Me.lblPassMaxChar = New System.Windows.Forms.Label
            Me.txtAttepts = New System.Windows.Forms.TextBox
            Me.lblAtempts = New System.Windows.Forms.Label
            Me.imgLogo = New System.Windows.Forms.PictureBox
            Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
            Me.CopyToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.PasteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.LibraryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
            Me.grpLogoSettings = New System.Windows.Forms.GroupBox
            Me.grpLogoType = New System.Windows.Forms.GroupBox
            Me.chkSguare = New System.Windows.Forms.CheckBox
            Me.rbHeader = New System.Windows.Forms.RadioButton
            Me.rbFooter = New System.Windows.Forms.RadioButton
            Me.btnSave = New System.Windows.Forms.Button
            Me.cmbCompany = New System.Windows.Forms.ComboBox
            Me.btnAdd = New System.Windows.Forms.Button
            Me.grpCompanyInfo = New System.Windows.Forms.GroupBox
            UsrPasswordValidityLabel = New System.Windows.Forms.Label
            Me.grpPasswordLogin.SuspendLayout()
            CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.ContextMenuStrip1.SuspendLayout()
            Me.grpLogoSettings.SuspendLayout()
            Me.grpLogoType.SuspendLayout()
            Me.grpCompanyInfo.SuspendLayout()
            Me.SuspendLayout()
            '
            'UsrPasswordValidityLabel
            '
            UsrPasswordValidityLabel.AutoSize = True
            UsrPasswordValidityLabel.Location = New System.Drawing.Point(7, 90)
            UsrPasswordValidityLabel.Name = "UsrPasswordValidityLabel"
            UsrPasswordValidityLabel.Size = New System.Drawing.Size(91, 13)
            UsrPasswordValidityLabel.TabIndex = 8
            UsrPasswordValidityLabel.Text = "Password validity:"
            '
            'lblCompanyName
            '
            Me.lblCompanyName.AutoSize = True
            Me.lblCompanyName.Location = New System.Drawing.Point(12, 24)
            Me.lblCompanyName.Name = "lblCompanyName"
            Me.lblCompanyName.Size = New System.Drawing.Size(83, 13)
            Me.lblCompanyName.TabIndex = 0
            Me.lblCompanyName.Text = "Company name:"
            '
            'btnBrowse
            '
            Me.btnBrowse.Location = New System.Drawing.Point(6, 108)
            Me.btnBrowse.Name = "btnBrowse"
            Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
            Me.btnBrowse.TabIndex = 4
            Me.btnBrowse.Text = "&Browse"
            Me.btnBrowse.UseVisualStyleBackColor = True
            '
            'Label1
            '
            Me.Label1.AutoSize = True
            Me.Label1.Location = New System.Drawing.Point(11, 47)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(103, 13)
            Me.Label1.TabIndex = 5
            Me.Label1.Text = "Reporting base date"
            '
            'dtCompanyStarted
            '
            Me.dtCompanyStarted.CustomFormat = "dd/MMMM/yyyy"
            Me.dtCompanyStarted.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtCompanyStarted.Location = New System.Drawing.Point(133, 45)
            Me.dtCompanyStarted.Name = "dtCompanyStarted"
            Me.dtCompanyStarted.Size = New System.Drawing.Size(187, 20)
            Me.dtCompanyStarted.TabIndex = 6
            '
            'grpPasswordLogin
            '
            Me.grpPasswordLogin.Controls.Add(Me.chkAllowChangeDB)
            Me.grpPasswordLogin.Controls.Add(Me.Label4)
            Me.grpPasswordLogin.Controls.Add(Me.cmbAction)
            Me.grpPasswordLogin.Controls.Add(Me.chkStrongPassword)
            Me.grpPasswordLogin.Controls.Add(Me.chkBlockuser)
            Me.grpPasswordLogin.Controls.Add(UsrPasswordValidityLabel)
            Me.grpPasswordLogin.Controls.Add(Me.txtPassValidity)
            Me.grpPasswordLogin.Controls.Add(Me.txtPassMinChar)
            Me.grpPasswordLogin.Controls.Add(Me.Label3)
            Me.grpPasswordLogin.Controls.Add(Me.txtPassMaxChar)
            Me.grpPasswordLogin.Controls.Add(Me.lblPassMaxChar)
            Me.grpPasswordLogin.Controls.Add(Me.txtAttepts)
            Me.grpPasswordLogin.Controls.Add(Me.lblAtempts)
            Me.grpPasswordLogin.Location = New System.Drawing.Point(15, 236)
            Me.grpPasswordLogin.Name = "grpPasswordLogin"
            Me.grpPasswordLogin.Size = New System.Drawing.Size(327, 193)
            Me.grpPasswordLogin.TabIndex = 7
            Me.grpPasswordLogin.TabStop = False
            Me.grpPasswordLogin.Text = "User Login Settings"
            '
            'chkAllowChangeDB
            '
            Me.chkAllowChangeDB.AutoSize = True
            Me.chkAllowChangeDB.Location = New System.Drawing.Point(10, 166)
            Me.chkAllowChangeDB.Name = "chkAllowChangeDB"
            Me.chkAllowChangeDB.Size = New System.Drawing.Size(149, 17)
            Me.chkAllowChangeDB.TabIndex = 15
            Me.chkAllowChangeDB.Text = "Allow change of Company"
            Me.chkAllowChangeDB.UseVisualStyleBackColor = True
            '
            'Label4
            '
            Me.Label4.AutoSize = True
            Me.Label4.Location = New System.Drawing.Point(7, 140)
            Me.Label4.Name = "Label4"
            Me.Label4.Size = New System.Drawing.Size(160, 13)
            Me.Label4.TabIndex = 14
            Me.Label4.Text = "Action, after failed login attempts"
            '
            'cmbAction
            '
            Me.cmbAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbAction.FormattingEnabled = True
            Me.cmbAction.Items.AddRange(New Object() {"Do nothing", "Block user", "Exit"})
            Me.cmbAction.Location = New System.Drawing.Point(229, 135)
            Me.cmbAction.Name = "cmbAction"
            Me.cmbAction.Size = New System.Drawing.Size(91, 21)
            Me.cmbAction.TabIndex = 13
            '
            'chkStrongPassword
            '
            Me.chkStrongPassword.Location = New System.Drawing.Point(10, 111)
            Me.chkStrongPassword.Name = "chkStrongPassword"
            Me.chkStrongPassword.Size = New System.Drawing.Size(144, 24)
            Me.chkStrongPassword.TabIndex = 10
            Me.chkStrongPassword.Text = "Strong password"
            Me.chkStrongPassword.UseVisualStyleBackColor = True
            '
            'chkBlockuser
            '
            Me.chkBlockuser.AutoSize = True
            Me.chkBlockuser.Location = New System.Drawing.Point(166, 166)
            Me.chkBlockuser.Name = "chkBlockuser"
            Me.chkBlockuser.Size = New System.Drawing.Size(72, 17)
            Me.chkBlockuser.TabIndex = 12
            Me.chkBlockuser.Text = "Atempte#"
            Me.chkBlockuser.UseVisualStyleBackColor = True
            Me.chkBlockuser.Visible = False
            '
            'txtPassValidity
            '
            Me.txtPassValidity.Location = New System.Drawing.Point(229, 87)
            Me.txtPassValidity.Name = "txtPassValidity"
            Me.txtPassValidity.Size = New System.Drawing.Size(91, 20)
            Me.txtPassValidity.TabIndex = 7
            '
            'txtPassMinChar
            '
            Me.txtPassMinChar.Location = New System.Drawing.Point(229, 63)
            Me.txtPassMinChar.Name = "txtPassMinChar"
            Me.txtPassMinChar.Size = New System.Drawing.Size(91, 20)
            Me.txtPassMinChar.TabIndex = 5
            '
            'Label3
            '
            Me.Label3.AutoSize = True
            Me.Label3.Location = New System.Drawing.Point(7, 67)
            Me.Label3.Name = "Label3"
            Me.Label3.Size = New System.Drawing.Size(149, 13)
            Me.Label3.TabIndex = 4
            Me.Label3.Text = "Password minimum characters"
            '
            'txtPassMaxChar
            '
            Me.txtPassMaxChar.Location = New System.Drawing.Point(229, 40)
            Me.txtPassMaxChar.Name = "txtPassMaxChar"
            Me.txtPassMaxChar.Size = New System.Drawing.Size(91, 20)
            Me.txtPassMaxChar.TabIndex = 3
            '
            'lblPassMaxChar
            '
            Me.lblPassMaxChar.AutoSize = True
            Me.lblPassMaxChar.Location = New System.Drawing.Point(7, 43)
            Me.lblPassMaxChar.Name = "lblPassMaxChar"
            Me.lblPassMaxChar.Size = New System.Drawing.Size(152, 13)
            Me.lblPassMaxChar.TabIndex = 2
            Me.lblPassMaxChar.Text = "Password maximum characters"
            '
            'txtAttepts
            '
            Me.txtAttepts.Location = New System.Drawing.Point(229, 17)
            Me.txtAttepts.Name = "txtAttepts"
            Me.txtAttepts.Size = New System.Drawing.Size(91, 20)
            Me.txtAttepts.TabIndex = 1
            '
            'lblAtempts
            '
            Me.lblAtempts.AutoSize = True
            Me.lblAtempts.Location = New System.Drawing.Point(7, 20)
            Me.lblAtempts.Name = "lblAtempts"
            Me.lblAtempts.Size = New System.Drawing.Size(127, 13)
            Me.lblAtempts.TabIndex = 0
            Me.lblAtempts.Text = "Number of login attempts:"
            '
            'imgLogo
            '
            Me.imgLogo.BackColor = System.Drawing.SystemColors.ButtonHighlight
            Me.imgLogo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.imgLogo.ContextMenuStrip = Me.ContextMenuStrip1
            Me.imgLogo.Location = New System.Drawing.Point(6, 16)
            Me.imgLogo.Name = "imgLogo"
            Me.imgLogo.Size = New System.Drawing.Size(639, 83)
            Me.imgLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
            Me.imgLogo.TabIndex = 2
            Me.imgLogo.TabStop = False
            '
            'ContextMenuStrip1
            '
            Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CopyToolStripMenuItem, Me.PasteToolStripMenuItem, Me.LibraryToolStripMenuItem})
            Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
            Me.ContextMenuStrip1.Size = New System.Drawing.Size(119, 70)
            '
            'CopyToolStripMenuItem
            '
            Me.CopyToolStripMenuItem.Name = "CopyToolStripMenuItem"
            Me.CopyToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
            Me.CopyToolStripMenuItem.Text = "Copy"
            '
            'PasteToolStripMenuItem
            '
            Me.PasteToolStripMenuItem.Name = "PasteToolStripMenuItem"
            Me.PasteToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
            Me.PasteToolStripMenuItem.Text = "Paste"
            '
            'LibraryToolStripMenuItem
            '
            Me.LibraryToolStripMenuItem.Name = "LibraryToolStripMenuItem"
            Me.LibraryToolStripMenuItem.Size = New System.Drawing.Size(118, 22)
            Me.LibraryToolStripMenuItem.Text = "Library"
            '
            'grpLogoSettings
            '
            Me.grpLogoSettings.Controls.Add(Me.grpLogoType)
            Me.grpLogoSettings.Controls.Add(Me.btnBrowse)
            Me.grpLogoSettings.Controls.Add(Me.imgLogo)
            Me.grpLogoSettings.Location = New System.Drawing.Point(13, 11)
            Me.grpLogoSettings.Name = "grpLogoSettings"
            Me.grpLogoSettings.Size = New System.Drawing.Size(651, 141)
            Me.grpLogoSettings.TabIndex = 8
            Me.grpLogoSettings.TabStop = False
            Me.grpLogoSettings.Text = "Logo Settings"
            Me.grpLogoSettings.UseCompatibleTextRendering = True
            '
            'grpLogoType
            '
            Me.grpLogoType.Controls.Add(Me.chkSguare)
            Me.grpLogoType.Controls.Add(Me.rbHeader)
            Me.grpLogoType.Controls.Add(Me.rbFooter)
            Me.grpLogoType.Location = New System.Drawing.Point(87, 99)
            Me.grpLogoType.Name = "grpLogoType"
            Me.grpLogoType.Size = New System.Drawing.Size(557, 37)
            Me.grpLogoType.TabIndex = 18
            Me.grpLogoType.TabStop = False
            Me.grpLogoType.Text = "Logo Type"
            '
            'chkSguare
            '
            Me.chkSguare.AutoSize = True
            Me.chkSguare.Location = New System.Drawing.Point(440, 15)
            Me.chkSguare.Name = "chkSguare"
            Me.chkSguare.Size = New System.Drawing.Size(70, 17)
            Me.chkSguare.TabIndex = 0
            Me.chkSguare.Text = "Fit to size"
            Me.chkSguare.UseVisualStyleBackColor = True
            '
            'rbHeader
            '
            Me.rbHeader.AutoSize = True
            Me.rbHeader.Checked = True
            Me.rbHeader.Location = New System.Drawing.Point(48, 14)
            Me.rbHeader.Name = "rbHeader"
            Me.rbHeader.Size = New System.Drawing.Size(60, 17)
            Me.rbHeader.TabIndex = 16
            Me.rbHeader.TabStop = True
            Me.rbHeader.Text = "Header"
            Me.rbHeader.UseVisualStyleBackColor = True
            '
            'rbFooter
            '
            Me.rbFooter.AutoSize = True
            Me.rbFooter.Location = New System.Drawing.Point(234, 14)
            Me.rbFooter.Name = "rbFooter"
            Me.rbFooter.Size = New System.Drawing.Size(55, 17)
            Me.rbFooter.TabIndex = 17
            Me.rbFooter.Text = "Footer"
            Me.rbFooter.UseVisualStyleBackColor = True
            '
            'btnSave
            '
            Me.btnSave.Location = New System.Drawing.Point(257, 435)
            Me.btnSave.Name = "btnSave"
            Me.btnSave.Size = New System.Drawing.Size(85, 44)
            Me.btnSave.TabIndex = 9
            Me.btnSave.Text = "&Save"
            Me.btnSave.UseVisualStyleBackColor = True
            '
            'cmbCompany
            '
            Me.cmbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbCompany.FormattingEnabled = True
            Me.cmbCompany.Location = New System.Drawing.Point(133, 16)
            Me.cmbCompany.Name = "cmbCompany"
            Me.cmbCompany.Size = New System.Drawing.Size(187, 21)
            Me.cmbCompany.TabIndex = 10
            '
            'btnAdd
            '
            Me.btnAdd.Location = New System.Drawing.Point(326, 16)
            Me.btnAdd.Name = "btnAdd"
            Me.btnAdd.Size = New System.Drawing.Size(54, 23)
            Me.btnAdd.TabIndex = 11
            Me.btnAdd.Text = "Add"
            Me.btnAdd.UseVisualStyleBackColor = True
            '
            'grpCompanyInfo
            '
            Me.grpCompanyInfo.Controls.Add(Me.cmbCompany)
            Me.grpCompanyInfo.Controls.Add(Me.lblCompanyName)
            Me.grpCompanyInfo.Controls.Add(Me.Label1)
            Me.grpCompanyInfo.Controls.Add(Me.btnAdd)
            Me.grpCompanyInfo.Controls.Add(Me.dtCompanyStarted)
            Me.grpCompanyInfo.Location = New System.Drawing.Point(15, 158)
            Me.grpCompanyInfo.Name = "grpCompanyInfo"
            Me.grpCompanyInfo.Size = New System.Drawing.Size(649, 72)
            Me.grpCompanyInfo.TabIndex = 13
            Me.grpCompanyInfo.TabStop = False
            Me.grpCompanyInfo.Text = "Company Information"
            '
            'ucDefaults
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.btnSave)
            Me.Controls.Add(Me.grpLogoSettings)
            Me.Controls.Add(Me.grpCompanyInfo)
            Me.Controls.Add(Me.grpPasswordLogin)
            Me.Name = "ucDefaults"
            Me.Size = New System.Drawing.Size(673, 482)
            Me.grpPasswordLogin.ResumeLayout(False)
            Me.grpPasswordLogin.PerformLayout()
            CType(Me.imgLogo, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ContextMenuStrip1.ResumeLayout(False)
            Me.grpLogoSettings.ResumeLayout(False)
            Me.grpLogoType.ResumeLayout(False)
            Me.grpLogoType.PerformLayout()
            Me.grpCompanyInfo.ResumeLayout(False)
            Me.grpCompanyInfo.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents lblCompanyName As System.Windows.Forms.Label
        Friend WithEvents imgLogo As System.Windows.Forms.PictureBox
        Friend WithEvents btnBrowse As System.Windows.Forms.Button
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents dtCompanyStarted As System.Windows.Forms.DateTimePicker
        Friend WithEvents grpPasswordLogin As System.Windows.Forms.GroupBox
        Friend WithEvents lblAtempts As System.Windows.Forms.Label
        Friend WithEvents txtPassValidity As System.Windows.Forms.TextBox
        Friend WithEvents txtPassMinChar As System.Windows.Forms.TextBox
        Friend WithEvents Label3 As System.Windows.Forms.Label
        Friend WithEvents txtPassMaxChar As System.Windows.Forms.TextBox
        Friend WithEvents lblPassMaxChar As System.Windows.Forms.Label
        Friend WithEvents txtAttepts As System.Windows.Forms.TextBox
        Friend WithEvents grpLogoSettings As System.Windows.Forms.GroupBox
        Friend WithEvents chkSguare As System.Windows.Forms.CheckBox
        Friend WithEvents chkStrongPassword As System.Windows.Forms.CheckBox
        Friend WithEvents btnSave As System.Windows.Forms.Button
        Friend WithEvents chkBlockuser As System.Windows.Forms.CheckBox
        Friend WithEvents Label4 As System.Windows.Forms.Label
        Friend WithEvents cmbAction As System.Windows.Forms.ComboBox
        Friend WithEvents chkAllowChangeDB As System.Windows.Forms.CheckBox
        Friend WithEvents cmbCompany As System.Windows.Forms.ComboBox
        Protected WithEvents btnAdd As System.Windows.Forms.Button
        Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
        Friend WithEvents CopyToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents PasteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents LibraryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents rbFooter As System.Windows.Forms.RadioButton
        Friend WithEvents rbHeader As System.Windows.Forms.RadioButton
        Friend WithEvents grpCompanyInfo As System.Windows.Forms.GroupBox
        Friend WithEvents grpLogoType As System.Windows.Forms.GroupBox

    End Class
End Namespace