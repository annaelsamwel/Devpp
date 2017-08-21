Imports System.Text
Namespace Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmUserSetup
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
            Me.components = New System.ComponentModel.Container
            Dim UsrStrongPasswordLabel1 As System.Windows.Forms.Label
            Dim UsrPasswordValidityLabel As System.Windows.Forms.Label
            Dim UsrPasswordChangedLabel As System.Windows.Forms.Label
            Dim Label1 As System.Windows.Forms.Label
            Dim lblCreateDate As System.Windows.Forms.Label
            Me.grpUserSetup = New System.Windows.Forms.GroupBox
            Me.pnUinfo = New System.Windows.Forms.Panel
            Me.grpDetails = New System.Windows.Forms.GroupBox
            Me.btnCancel = New System.Windows.Forms.Button
            Me.btnAdd = New System.Windows.Forms.Button
            Me.grpPasswordValidation = New System.Windows.Forms.GroupBox
            Me.lblDays = New System.Windows.Forms.Label
            Me.Label2 = New System.Windows.Forms.Label
            Me.chkRetryBlockCheckBox = New System.Windows.Forms.CheckBox
            Me.dtpPasswordChanged = New System.Windows.Forms.DateTimePicker
            Me.txtPasswordValidity = New System.Windows.Forms.TextBox
            Me.chkStrongPassword = New System.Windows.Forms.CheckBox
            Me.pnColorScheme = New System.Windows.Forms.Panel
            Me.grpCreateInfo = New System.Windows.Forms.GroupBox
            Me.txtCreateUserId = New System.Windows.Forms.TextBox
            Me.dtpCreateDate = New System.Windows.Forms.DateTimePicker
            Me.pnSetup = New System.Windows.Forms.Panel
            Me.grpAuthSettings = New System.Windows.Forms.GroupBox
            Me.optBoth = New System.Windows.Forms.RadioButton
            Me.optDomain = New System.Windows.Forms.RadioButton
            Me.optDevpp = New System.Windows.Forms.RadioButton
            Me.grpUdetails = New System.Windows.Forms.GroupBox
            Me.pnlPassword = New System.Windows.Forms.Panel
            Me.lblPass = New System.Windows.Forms.Label
            Me.txtPassword = New System.Windows.Forms.TextBox
            Me.txtConfirmPassword = New System.Windows.Forms.TextBox
            Me.lblConfirmPassword = New System.Windows.Forms.Label
            Me.cmbContact = New System.Windows.Forms.ComboBox
            Me.lblContact = New System.Windows.Forms.Label
            Me.lblUserName = New System.Windows.Forms.Label
            Me.txtUserName = New System.Windows.Forms.TextBox
            Me.ttUserDetails = New System.Windows.Forms.ToolTip(Me.components)
            Me.CNetHelpProvider = New System.Windows.Forms.HelpProvider
            UsrStrongPasswordLabel1 = New System.Windows.Forms.Label
            UsrPasswordValidityLabel = New System.Windows.Forms.Label
            UsrPasswordChangedLabel = New System.Windows.Forms.Label
            Label1 = New System.Windows.Forms.Label
            lblCreateDate = New System.Windows.Forms.Label
            Me.grpUserSetup.SuspendLayout()
            Me.pnUinfo.SuspendLayout()
            Me.grpDetails.SuspendLayout()
            Me.grpPasswordValidation.SuspendLayout()
            Me.pnColorScheme.SuspendLayout()
            Me.grpCreateInfo.SuspendLayout()
            Me.pnSetup.SuspendLayout()
            Me.grpAuthSettings.SuspendLayout()
            Me.grpUdetails.SuspendLayout()
            Me.pnlPassword.SuspendLayout()
            Me.SuspendLayout()
            '
            'UsrStrongPasswordLabel1
            '
            UsrStrongPasswordLabel1.AutoSize = True
            Me.CNetHelpProvider.SetHelpKeyword(UsrStrongPasswordLabel1, "Dev++_Form_frmUserSetup.htm#frmUserSetup_UsrStrongPasswordLabel1")
            Me.CNetHelpProvider.SetHelpNavigator(UsrStrongPasswordLabel1, System.Windows.Forms.HelpNavigator.Topic)
            UsrStrongPasswordLabel1.Location = New System.Drawing.Point(62, 44)
            UsrStrongPasswordLabel1.Name = "UsrStrongPasswordLabel1"
            Me.CNetHelpProvider.SetShowHelp(UsrStrongPasswordLabel1, True)
            UsrStrongPasswordLabel1.Size = New System.Drawing.Size(93, 13)
            UsrStrongPasswordLabel1.TabIndex = 0
            UsrStrongPasswordLabel1.Text = " Strong Password:"
            '
            'UsrPasswordValidityLabel
            '
            UsrPasswordValidityLabel.AutoSize = True
            Me.CNetHelpProvider.SetHelpKeyword(UsrPasswordValidityLabel, "Dev++_Form_frmUserSetup.htm#frmUserSetup_UsrPasswordValidityLabel")
            Me.CNetHelpProvider.SetHelpNavigator(UsrPasswordValidityLabel, System.Windows.Forms.HelpNavigator.Topic)
            UsrPasswordValidityLabel.Location = New System.Drawing.Point(58, 88)
            UsrPasswordValidityLabel.Name = "UsrPasswordValidityLabel"
            Me.CNetHelpProvider.SetShowHelp(UsrPasswordValidityLabel, True)
            UsrPasswordValidityLabel.Size = New System.Drawing.Size(92, 13)
            UsrPasswordValidityLabel.TabIndex = 2
            UsrPasswordValidityLabel.Text = "Password Validity:"
            '
            'UsrPasswordChangedLabel
            '
            UsrPasswordChangedLabel.AutoSize = True
            Me.CNetHelpProvider.SetHelpKeyword(UsrPasswordChangedLabel, "Dev++_Form_frmUserSetup.htm#frmUserSetup_UsrPasswordChangedLabel")
            Me.CNetHelpProvider.SetHelpNavigator(UsrPasswordChangedLabel, System.Windows.Forms.HelpNavigator.Topic)
            UsrPasswordChangedLabel.Location = New System.Drawing.Point(30, 21)
            UsrPasswordChangedLabel.Name = "UsrPasswordChangedLabel"
            Me.CNetHelpProvider.SetShowHelp(UsrPasswordChangedLabel, True)
            UsrPasswordChangedLabel.Size = New System.Drawing.Size(125, 13)
            UsrPasswordChangedLabel.TabIndex = 8
            UsrPasswordChangedLabel.Text = "Password Last Changed:"
            Me.ttUserDetails.SetToolTip(UsrPasswordChangedLabel, "Date password last changed")
            '
            'Label1
            '
            Label1.AutoSize = True
            Me.CNetHelpProvider.SetHelpKeyword(Label1, "Dev++_Form_frmUserSetup.htm#frmUserSetup_Label1")
            Me.CNetHelpProvider.SetHelpNavigator(Label1, System.Windows.Forms.HelpNavigator.Topic)
            Label1.Location = New System.Drawing.Point(12, 20)
            Label1.Name = "Label1"
            Me.CNetHelpProvider.SetShowHelp(Label1, True)
            Label1.Size = New System.Drawing.Size(66, 13)
            Label1.TabIndex = 45
            Label1.Text = "Create User:"
            Me.ttUserDetails.SetToolTip(Label1, "Enter Create User")
            '
            'lblCreateDate
            '
            lblCreateDate.AutoSize = True
            Me.CNetHelpProvider.SetHelpKeyword(lblCreateDate, "Dev++_Form_frmUserSetup.htm#frmUserSetup_lblCreateDate")
            Me.CNetHelpProvider.SetHelpNavigator(lblCreateDate, System.Windows.Forms.HelpNavigator.Topic)
            lblCreateDate.Location = New System.Drawing.Point(19, 45)
            lblCreateDate.Name = "lblCreateDate"
            Me.CNetHelpProvider.SetShowHelp(lblCreateDate, True)
            lblCreateDate.Size = New System.Drawing.Size(70, 13)
            lblCreateDate.TabIndex = 4
            lblCreateDate.Text = " Create Date:"
            Me.ttUserDetails.SetToolTip(lblCreateDate, "Date Account created")
            '
            'grpUserSetup
            '
            Me.grpUserSetup.BackColor = System.Drawing.Color.AliceBlue
            Me.grpUserSetup.Controls.Add(Me.pnUinfo)
            Me.grpUserSetup.Controls.Add(Me.pnColorScheme)
            Me.grpUserSetup.Controls.Add(Me.pnSetup)
            Me.CNetHelpProvider.SetHelpKeyword(Me.grpUserSetup, "Dev++_Form_frmUserSetup.htm#frmUserSetup_grpUserSetup")
            Me.CNetHelpProvider.SetHelpNavigator(Me.grpUserSetup, System.Windows.Forms.HelpNavigator.Topic)
            Me.grpUserSetup.Location = New System.Drawing.Point(6, 8)
            Me.grpUserSetup.Name = "grpUserSetup"
            Me.CNetHelpProvider.SetShowHelp(Me.grpUserSetup, True)
            Me.grpUserSetup.Size = New System.Drawing.Size(646, 351)
            Me.grpUserSetup.TabIndex = 0
            Me.grpUserSetup.TabStop = False
            Me.grpUserSetup.Text = "User Setup"
            '
            'pnUinfo
            '
            Me.pnUinfo.BackColor = System.Drawing.Color.AliceBlue
            Me.pnUinfo.Controls.Add(Me.grpDetails)
            Me.pnUinfo.Controls.Add(Me.grpPasswordValidation)
            Me.CNetHelpProvider.SetHelpKeyword(Me.pnUinfo, "Dev++_Form_frmUserSetup.htm#frmUserSetup_pnUinfo")
            Me.CNetHelpProvider.SetHelpNavigator(Me.pnUinfo, System.Windows.Forms.HelpNavigator.Topic)
            Me.pnUinfo.Location = New System.Drawing.Point(362, 19)
            Me.pnUinfo.Name = "pnUinfo"
            Me.CNetHelpProvider.SetShowHelp(Me.pnUinfo, True)
            Me.pnUinfo.Size = New System.Drawing.Size(278, 321)
            Me.pnUinfo.TabIndex = 32
            '
            'grpDetails
            '
            Me.grpDetails.Controls.Add(Me.btnCancel)
            Me.grpDetails.Controls.Add(Me.btnAdd)
            Me.CNetHelpProvider.SetHelpKeyword(Me.grpDetails, "Dev++_Form_frmUserSetup.htm#frmUserSetup_grpDetails")
            Me.CNetHelpProvider.SetHelpNavigator(Me.grpDetails, System.Windows.Forms.HelpNavigator.Topic)
            Me.grpDetails.Location = New System.Drawing.Point(9, 272)
            Me.grpDetails.Name = "grpDetails"
            Me.CNetHelpProvider.SetShowHelp(Me.grpDetails, True)
            Me.grpDetails.Size = New System.Drawing.Size(258, 39)
            Me.grpDetails.TabIndex = 11
            Me.grpDetails.TabStop = False
            '
            'btnCancel
            '
            Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.btnCancel.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CNetHelpProvider.SetHelpKeyword(Me.btnCancel, "Dev++_Form_frmUserSetup.htm#frmUserSetup_btnCancel")
            Me.CNetHelpProvider.SetHelpNavigator(Me.btnCancel, System.Windows.Forms.HelpNavigator.Topic)
            Me.btnCancel.Location = New System.Drawing.Point(147, 13)
            Me.btnCancel.Name = "btnCancel"
            Me.CNetHelpProvider.SetShowHelp(Me.btnCancel, True)
            Me.btnCancel.Size = New System.Drawing.Size(105, 22)
            Me.btnCancel.TabIndex = 12
            Me.btnCancel.Text = "&CANCEL"
            Me.btnCancel.UseVisualStyleBackColor = True
            '
            'btnAdd
            '
            Me.btnAdd.Font = New System.Drawing.Font("Arial", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CNetHelpProvider.SetHelpKeyword(Me.btnAdd, "Dev++_Form_frmUserSetup.htm#frmUserSetup_btnAdd")
            Me.CNetHelpProvider.SetHelpNavigator(Me.btnAdd, System.Windows.Forms.HelpNavigator.Topic)
            Me.btnAdd.Location = New System.Drawing.Point(7, 13)
            Me.btnAdd.Name = "btnAdd"
            Me.CNetHelpProvider.SetShowHelp(Me.btnAdd, True)
            Me.btnAdd.Size = New System.Drawing.Size(123, 22)
            Me.btnAdd.TabIndex = 11
            Me.btnAdd.Text = "&SAVE SETTINGS"
            Me.btnAdd.UseVisualStyleBackColor = True
            '
            'grpPasswordValidation
            '
            Me.grpPasswordValidation.Controls.Add(Me.lblDays)
            Me.grpPasswordValidation.Controls.Add(Me.Label2)
            Me.grpPasswordValidation.Controls.Add(Me.chkRetryBlockCheckBox)
            Me.grpPasswordValidation.Controls.Add(UsrPasswordChangedLabel)
            Me.grpPasswordValidation.Controls.Add(Me.dtpPasswordChanged)
            Me.grpPasswordValidation.Controls.Add(UsrPasswordValidityLabel)
            Me.grpPasswordValidation.Controls.Add(UsrStrongPasswordLabel1)
            Me.grpPasswordValidation.Controls.Add(Me.txtPasswordValidity)
            Me.grpPasswordValidation.Controls.Add(Me.chkStrongPassword)
            Me.CNetHelpProvider.SetHelpKeyword(Me.grpPasswordValidation, "Dev++_Form_frmUserSetup.htm#frmUserSetup_grpPasswordValidation")
            Me.CNetHelpProvider.SetHelpNavigator(Me.grpPasswordValidation, System.Windows.Forms.HelpNavigator.Topic)
            Me.grpPasswordValidation.Location = New System.Drawing.Point(9, 8)
            Me.grpPasswordValidation.Name = "grpPasswordValidation"
            Me.CNetHelpProvider.SetShowHelp(Me.grpPasswordValidation, True)
            Me.grpPasswordValidation.Size = New System.Drawing.Size(263, 153)
            Me.grpPasswordValidation.TabIndex = 8
            Me.grpPasswordValidation.TabStop = False
            Me.grpPasswordValidation.Text = "Password Validation Settings"
            Me.ttUserDetails.SetToolTip(Me.grpPasswordValidation, "Password Information")
            '
            'lblDays
            '
            Me.lblDays.AutoSize = True
            Me.CNetHelpProvider.SetHelpKeyword(Me.lblDays, "Dev++_Form_frmUserSetup.htm#frmUserSetup_lblDays")
            Me.CNetHelpProvider.SetHelpNavigator(Me.lblDays, System.Windows.Forms.HelpNavigator.Topic)
            Me.lblDays.Location = New System.Drawing.Point(203, 88)
            Me.lblDays.Name = "lblDays"
            Me.CNetHelpProvider.SetShowHelp(Me.lblDays, True)
            Me.lblDays.Size = New System.Drawing.Size(31, 13)
            Me.lblDays.TabIndex = 19
            Me.lblDays.Text = "Days"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.CNetHelpProvider.SetHelpKeyword(Me.Label2, "Dev++_Form_frmUserSetup.htm#frmUserSetup_Label2")
            Me.CNetHelpProvider.SetHelpNavigator(Me.Label2, System.Windows.Forms.HelpNavigator.Topic)
            Me.Label2.Location = New System.Drawing.Point(15, 64)
            Me.Label2.Name = "Label2"
            Me.CNetHelpProvider.SetShowHelp(Me.Label2, True)
            Me.Label2.Size = New System.Drawing.Size(52, 13)
            Me.Label2.TabIndex = 18
            Me.Label2.Text = "Atempts#"
            '
            'chkRetryBlockCheckBox
            '
            Me.CNetHelpProvider.SetHelpKeyword(Me.chkRetryBlockCheckBox, "Dev++_Form_frmUserSetup.htm#frmUserSetup_chkRetryBlockCheckBox")
            Me.CNetHelpProvider.SetHelpNavigator(Me.chkRetryBlockCheckBox, System.Windows.Forms.HelpNavigator.Topic)
            Me.chkRetryBlockCheckBox.Location = New System.Drawing.Point(159, 59)
            Me.chkRetryBlockCheckBox.Name = "chkRetryBlockCheckBox"
            Me.CNetHelpProvider.SetShowHelp(Me.chkRetryBlockCheckBox, True)
            Me.chkRetryBlockCheckBox.Size = New System.Drawing.Size(17, 24)
            Me.chkRetryBlockCheckBox.TabIndex = 17
            Me.chkRetryBlockCheckBox.UseVisualStyleBackColor = True
            '
            'dtpPasswordChanged
            '
            Me.dtpPasswordChanged.Enabled = False
            Me.dtpPasswordChanged.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.CNetHelpProvider.SetHelpKeyword(Me.dtpPasswordChanged, "Dev++_Form_frmUserSetup.htm#frmUserSetup_dtpPasswordChanged")
            Me.CNetHelpProvider.SetHelpNavigator(Me.dtpPasswordChanged, System.Windows.Forms.HelpNavigator.Topic)
            Me.dtpPasswordChanged.Location = New System.Drawing.Point(160, 14)
            Me.dtpPasswordChanged.Name = "dtpPasswordChanged"
            Me.CNetHelpProvider.SetShowHelp(Me.dtpPasswordChanged, True)
            Me.dtpPasswordChanged.Size = New System.Drawing.Size(98, 20)
            Me.dtpPasswordChanged.TabIndex = 9
            Me.dtpPasswordChanged.TabStop = False
            '
            'txtPasswordValidity
            '
            Me.CNetHelpProvider.SetHelpKeyword(Me.txtPasswordValidity, "Dev++_Form_frmUserSetup.htm#frmUserSetup_txtPasswordValidity")
            Me.CNetHelpProvider.SetHelpNavigator(Me.txtPasswordValidity, System.Windows.Forms.HelpNavigator.Topic)
            Me.txtPasswordValidity.Location = New System.Drawing.Point(158, 85)
            Me.txtPasswordValidity.MaxLength = 3
            Me.txtPasswordValidity.Name = "txtPasswordValidity"
            Me.CNetHelpProvider.SetShowHelp(Me.txtPasswordValidity, True)
            Me.txtPasswordValidity.Size = New System.Drawing.Size(42, 20)
            Me.txtPasswordValidity.TabIndex = 10
            '
            'chkStrongPassword
            '
            Me.CNetHelpProvider.SetHelpKeyword(Me.chkStrongPassword, "Dev++_Form_frmUserSetup.htm#frmUserSetup_chkStrongPassword")
            Me.CNetHelpProvider.SetHelpNavigator(Me.chkStrongPassword, System.Windows.Forms.HelpNavigator.Topic)
            Me.chkStrongPassword.Location = New System.Drawing.Point(160, 39)
            Me.chkStrongPassword.Name = "chkStrongPassword"
            Me.CNetHelpProvider.SetShowHelp(Me.chkStrongPassword, True)
            Me.chkStrongPassword.Size = New System.Drawing.Size(23, 24)
            Me.chkStrongPassword.TabIndex = 8
            Me.chkStrongPassword.UseVisualStyleBackColor = True
            '
            'pnColorScheme
            '
            Me.pnColorScheme.Controls.Add(Me.grpCreateInfo)
            Me.CNetHelpProvider.SetHelpKeyword(Me.pnColorScheme, "Dev++_Form_frmUserSetup.htm#frmUserSetup_pnColorScheme")
            Me.CNetHelpProvider.SetHelpNavigator(Me.pnColorScheme, System.Windows.Forms.HelpNavigator.Topic)
            Me.pnColorScheme.Location = New System.Drawing.Point(6, 262)
            Me.pnColorScheme.Name = "pnColorScheme"
            Me.CNetHelpProvider.SetShowHelp(Me.pnColorScheme, True)
            Me.pnColorScheme.Size = New System.Drawing.Size(350, 78)
            Me.pnColorScheme.TabIndex = 30
            '
            'grpCreateInfo
            '
            Me.grpCreateInfo.Controls.Add(Me.txtCreateUserId)
            Me.grpCreateInfo.Controls.Add(Label1)
            Me.grpCreateInfo.Controls.Add(lblCreateDate)
            Me.grpCreateInfo.Controls.Add(Me.dtpCreateDate)
            Me.CNetHelpProvider.SetHelpKeyword(Me.grpCreateInfo, "Dev++_Form_frmUserSetup.htm#frmUserSetup_grpCreateInfo")
            Me.CNetHelpProvider.SetHelpNavigator(Me.grpCreateInfo, System.Windows.Forms.HelpNavigator.Topic)
            Me.grpCreateInfo.Location = New System.Drawing.Point(11, 9)
            Me.grpCreateInfo.Name = "grpCreateInfo"
            Me.CNetHelpProvider.SetShowHelp(Me.grpCreateInfo, True)
            Me.grpCreateInfo.Size = New System.Drawing.Size(336, 66)
            Me.grpCreateInfo.TabIndex = 13
            Me.grpCreateInfo.TabStop = False
            Me.grpCreateInfo.Text = "Creator Information"
            Me.ttUserDetails.SetToolTip(Me.grpCreateInfo, "Enter Creator information")
            '
            'txtCreateUserId
            '
            Me.txtCreateUserId.Enabled = False
            Me.CNetHelpProvider.SetHelpKeyword(Me.txtCreateUserId, "Dev++_Form_frmUserSetup.htm#frmUserSetup_txtCreateUserId")
            Me.CNetHelpProvider.SetHelpNavigator(Me.txtCreateUserId, System.Windows.Forms.HelpNavigator.Topic)
            Me.txtCreateUserId.Location = New System.Drawing.Point(102, 17)
            Me.txtCreateUserId.Name = "txtCreateUserId"
            Me.txtCreateUserId.ReadOnly = True
            Me.CNetHelpProvider.SetShowHelp(Me.txtCreateUserId, True)
            Me.txtCreateUserId.Size = New System.Drawing.Size(168, 20)
            Me.txtCreateUserId.TabIndex = 48
            Me.txtCreateUserId.TabStop = False
            '
            'dtpCreateDate
            '
            Me.dtpCreateDate.Enabled = False
            Me.dtpCreateDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.CNetHelpProvider.SetHelpKeyword(Me.dtpCreateDate, "Dev++_Form_frmUserSetup.htm#frmUserSetup_dtpCreateDate")
            Me.CNetHelpProvider.SetHelpNavigator(Me.dtpCreateDate, System.Windows.Forms.HelpNavigator.Topic)
            Me.dtpCreateDate.Location = New System.Drawing.Point(101, 41)
            Me.dtpCreateDate.Name = "dtpCreateDate"
            Me.CNetHelpProvider.SetShowHelp(Me.dtpCreateDate, True)
            Me.dtpCreateDate.Size = New System.Drawing.Size(170, 20)
            Me.dtpCreateDate.TabIndex = 5
            Me.dtpCreateDate.TabStop = False
            Me.ttUserDetails.SetToolTip(Me.dtpCreateDate, "Date Account created")
            '
            'pnSetup
            '
            Me.pnSetup.Controls.Add(Me.grpAuthSettings)
            Me.pnSetup.Controls.Add(Me.grpUdetails)
            Me.CNetHelpProvider.SetHelpKeyword(Me.pnSetup, "Dev++_Form_frmUserSetup.htm#frmUserSetup_pnSetup")
            Me.CNetHelpProvider.SetHelpNavigator(Me.pnSetup, System.Windows.Forms.HelpNavigator.Topic)
            Me.pnSetup.Location = New System.Drawing.Point(6, 19)
            Me.pnSetup.Name = "pnSetup"
            Me.CNetHelpProvider.SetShowHelp(Me.pnSetup, True)
            Me.pnSetup.Size = New System.Drawing.Size(350, 240)
            Me.pnSetup.TabIndex = 23
            '
            'grpAuthSettings
            '
            Me.grpAuthSettings.Controls.Add(Me.optBoth)
            Me.grpAuthSettings.Controls.Add(Me.optDomain)
            Me.grpAuthSettings.Controls.Add(Me.optDevpp)
            Me.CNetHelpProvider.SetHelpKeyword(Me.grpAuthSettings, "Dev++_Form_frmUserSetup.htm#frmUserSetup_grpAuthSettings")
            Me.CNetHelpProvider.SetHelpNavigator(Me.grpAuthSettings, System.Windows.Forms.HelpNavigator.Topic)
            Me.grpAuthSettings.Location = New System.Drawing.Point(11, 152)
            Me.grpAuthSettings.Name = "grpAuthSettings"
            Me.CNetHelpProvider.SetShowHelp(Me.grpAuthSettings, True)
            Me.grpAuthSettings.Size = New System.Drawing.Size(336, 85)
            Me.grpAuthSettings.TabIndex = 4
            Me.grpAuthSettings.TabStop = False
            Me.grpAuthSettings.Text = "Authentication Settings"
            Me.ttUserDetails.SetToolTip(Me.grpAuthSettings, "User Authentication Settings")
            '
            'optBoth
            '
            Me.CNetHelpProvider.SetHelpKeyword(Me.optBoth, "Dev++_Form_frmUserSetup.htm#frmUserSetup_optBoth")
            Me.CNetHelpProvider.SetHelpNavigator(Me.optBoth, System.Windows.Forms.HelpNavigator.Topic)
            Me.optBoth.Location = New System.Drawing.Point(18, 56)
            Me.optBoth.Name = "optBoth"
            Me.CNetHelpProvider.SetShowHelp(Me.optBoth, True)
            Me.optBoth.Size = New System.Drawing.Size(104, 24)
            Me.optBoth.TabIndex = 7
            Me.optBoth.TabStop = True
            Me.optBoth.Text = "Both"
            Me.ttUserDetails.SetToolTip(Me.optBoth, "Both Domain and Devpp Controlled Authentication")
            Me.optBoth.UseVisualStyleBackColor = True
            '
            'optDomain
            '
            Me.CNetHelpProvider.SetHelpKeyword(Me.optDomain, "Dev++_Form_frmUserSetup.htm#frmUserSetup_optDomain")
            Me.CNetHelpProvider.SetHelpNavigator(Me.optDomain, System.Windows.Forms.HelpNavigator.Topic)
            Me.optDomain.Location = New System.Drawing.Point(18, 15)
            Me.optDomain.Name = "optDomain"
            Me.CNetHelpProvider.SetShowHelp(Me.optDomain, True)
            Me.optDomain.Size = New System.Drawing.Size(137, 24)
            Me.optDomain.TabIndex = 5
            Me.optDomain.TabStop = True
            Me.optDomain.Text = "Domain Controlled"
            Me.ttUserDetails.SetToolTip(Me.optDomain, "Domain Controlled Authentication")
            Me.optDomain.UseVisualStyleBackColor = True
            '
            'optDevpp
            '
            Me.CNetHelpProvider.SetHelpKeyword(Me.optDevpp, "Dev++_Form_frmUserSetup.htm#frmUserSetup_optDevpp")
            Me.CNetHelpProvider.SetHelpNavigator(Me.optDevpp, System.Windows.Forms.HelpNavigator.Topic)
            Me.optDevpp.Location = New System.Drawing.Point(18, 37)
            Me.optDevpp.Name = "optDevpp"
            Me.CNetHelpProvider.SetShowHelp(Me.optDevpp, True)
            Me.optDevpp.Size = New System.Drawing.Size(214, 20)
            Me.optDevpp.TabIndex = 6
            Me.optDevpp.TabStop = True
            Me.optDevpp.Text = "Devpp Authentication" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
            Me.ttUserDetails.SetToolTip(Me.optDevpp, "Devpp Controlled Authentication")
            Me.optDevpp.UseVisualStyleBackColor = True
            '
            'grpUdetails
            '
            Me.grpUdetails.Controls.Add(Me.pnlPassword)
            Me.grpUdetails.Controls.Add(Me.cmbContact)
            Me.grpUdetails.Controls.Add(Me.lblContact)
            Me.grpUdetails.Controls.Add(Me.lblUserName)
            Me.grpUdetails.Controls.Add(Me.txtUserName)
            Me.CNetHelpProvider.SetHelpKeyword(Me.grpUdetails, "Dev++_Form_frmUserSetup.htm#frmUserSetup_grpUdetails")
            Me.CNetHelpProvider.SetHelpNavigator(Me.grpUdetails, System.Windows.Forms.HelpNavigator.Topic)
            Me.grpUdetails.Location = New System.Drawing.Point(3, 0)
            Me.grpUdetails.Name = "grpUdetails"
            Me.CNetHelpProvider.SetShowHelp(Me.grpUdetails, True)
            Me.grpUdetails.Size = New System.Drawing.Size(344, 146)
            Me.grpUdetails.TabIndex = 0
            Me.grpUdetails.TabStop = False
            Me.grpUdetails.Text = "User Details"
            '
            'pnlPassword
            '
            Me.pnlPassword.Controls.Add(Me.lblPass)
            Me.pnlPassword.Controls.Add(Me.txtPassword)
            Me.pnlPassword.Controls.Add(Me.txtConfirmPassword)
            Me.pnlPassword.Controls.Add(Me.lblConfirmPassword)
            Me.CNetHelpProvider.SetHelpKeyword(Me.pnlPassword, "Dev++_Form_frmUserSetup.htm#frmUserSetup_pnlPassword")
            Me.CNetHelpProvider.SetHelpNavigator(Me.pnlPassword, System.Windows.Forms.HelpNavigator.Topic)
            Me.pnlPassword.Location = New System.Drawing.Point(8, 46)
            Me.pnlPassword.Name = "pnlPassword"
            Me.CNetHelpProvider.SetShowHelp(Me.pnlPassword, True)
            Me.pnlPassword.Size = New System.Drawing.Size(322, 63)
            Me.pnlPassword.TabIndex = 54
            '
            'lblPass
            '
            Me.lblPass.AutoSize = True
            Me.CNetHelpProvider.SetHelpKeyword(Me.lblPass, "Dev++_Form_frmUserSetup.htm#frmUserSetup_lblPass")
            Me.CNetHelpProvider.SetHelpNavigator(Me.lblPass, System.Windows.Forms.HelpNavigator.Topic)
            Me.lblPass.Location = New System.Drawing.Point(55, 15)
            Me.lblPass.Name = "lblPass"
            Me.CNetHelpProvider.SetShowHelp(Me.lblPass, True)
            Me.lblPass.Size = New System.Drawing.Size(56, 13)
            Me.lblPass.TabIndex = 46
            Me.lblPass.Text = "Password:"
            Me.ttUserDetails.SetToolTip(Me.lblPass, "Enter User Password")
            '
            'txtPassword
            '
            Me.txtPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CNetHelpProvider.SetHelpKeyword(Me.txtPassword, "Dev++_Form_frmUserSetup.htm#frmUserSetup_txtPassword")
            Me.CNetHelpProvider.SetHelpNavigator(Me.txtPassword, System.Windows.Forms.HelpNavigator.Topic)
            Me.txtPassword.Location = New System.Drawing.Point(117, 11)
            Me.txtPassword.Name = "txtPassword"
            Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
            Me.CNetHelpProvider.SetShowHelp(Me.txtPassword, True)
            Me.txtPassword.Size = New System.Drawing.Size(154, 20)
            Me.txtPassword.TabIndex = 1
            Me.txtPassword.Tag = ""
            Me.ttUserDetails.SetToolTip(Me.txtPassword, "Enter User Password")
            Me.txtPassword.UseSystemPasswordChar = True
            '
            'txtConfirmPassword
            '
            Me.txtConfirmPassword.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CNetHelpProvider.SetHelpKeyword(Me.txtConfirmPassword, "Dev++_Form_frmUserSetup.htm#frmUserSetup_txtConfirmPassword")
            Me.CNetHelpProvider.SetHelpNavigator(Me.txtConfirmPassword, System.Windows.Forms.HelpNavigator.Topic)
            Me.txtConfirmPassword.Location = New System.Drawing.Point(117, 34)
            Me.txtConfirmPassword.Name = "txtConfirmPassword"
            Me.txtConfirmPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
            Me.CNetHelpProvider.SetShowHelp(Me.txtConfirmPassword, True)
            Me.txtConfirmPassword.Size = New System.Drawing.Size(154, 20)
            Me.txtConfirmPassword.TabIndex = 2
            Me.ttUserDetails.SetToolTip(Me.txtConfirmPassword, "Confirm User Password")
            Me.txtConfirmPassword.UseSystemPasswordChar = True
            '
            'lblConfirmPassword
            '
            Me.lblConfirmPassword.AutoSize = True
            Me.lblConfirmPassword.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CNetHelpProvider.SetHelpKeyword(Me.lblConfirmPassword, "Dev++_Form_frmUserSetup.htm#frmUserSetup_lblConfirmPassword")
            Me.CNetHelpProvider.SetHelpNavigator(Me.lblConfirmPassword, System.Windows.Forms.HelpNavigator.Topic)
            Me.lblConfirmPassword.Location = New System.Drawing.Point(11, 40)
            Me.lblConfirmPassword.Name = "lblConfirmPassword"
            Me.CNetHelpProvider.SetShowHelp(Me.lblConfirmPassword, True)
            Me.lblConfirmPassword.Size = New System.Drawing.Size(100, 14)
            Me.lblConfirmPassword.TabIndex = 44
            Me.lblConfirmPassword.Text = "Confirm Password:"
            Me.ttUserDetails.SetToolTip(Me.lblConfirmPassword, "Confirm User Password")
            '
            'cmbContact
            '
            Me.cmbContact.AccessibleName = "IdNumber"
            Me.cmbContact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbContact.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.cmbContact.FormattingEnabled = True
            Me.CNetHelpProvider.SetHelpKeyword(Me.cmbContact, "Dev++_Form_frmUserSetup.htm#frmUserSetup_cmbContact")
            Me.CNetHelpProvider.SetHelpNavigator(Me.cmbContact, System.Windows.Forms.HelpNavigator.Topic)
            Me.cmbContact.Location = New System.Drawing.Point(83, 119)
            Me.cmbContact.Name = "cmbContact"
            Me.CNetHelpProvider.SetShowHelp(Me.cmbContact, True)
            Me.cmbContact.Size = New System.Drawing.Size(197, 21)
            Me.cmbContact.TabIndex = 3
            Me.ttUserDetails.SetToolTip(Me.cmbContact, "Select the user to which the account is being created")
            '
            'lblContact
            '
            Me.lblContact.AutoSize = True
            Me.lblContact.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CNetHelpProvider.SetHelpKeyword(Me.lblContact, "Dev++_Form_frmUserSetup.htm#frmUserSetup_lblContact")
            Me.CNetHelpProvider.SetHelpNavigator(Me.lblContact, System.Windows.Forms.HelpNavigator.Topic)
            Me.lblContact.Location = New System.Drawing.Point(6, 122)
            Me.lblContact.Name = "lblContact"
            Me.CNetHelpProvider.SetShowHelp(Me.lblContact, True)
            Me.lblContact.Size = New System.Drawing.Size(76, 14)
            Me.lblContact.TabIndex = 52
            Me.lblContact.Text = "Reference To:"
            Me.ttUserDetails.SetToolTip(Me.lblContact, "Select the user to which the account is being created")
            '
            'lblUserName
            '
            Me.lblUserName.AutoSize = True
            Me.CNetHelpProvider.SetHelpKeyword(Me.lblUserName, "Dev++_Form_frmUserSetup.htm#frmUserSetup_lblUserName")
            Me.CNetHelpProvider.SetHelpNavigator(Me.lblUserName, System.Windows.Forms.HelpNavigator.Topic)
            Me.lblUserName.Location = New System.Drawing.Point(42, 24)
            Me.lblUserName.Name = "lblUserName"
            Me.CNetHelpProvider.SetShowHelp(Me.lblUserName, True)
            Me.lblUserName.Size = New System.Drawing.Size(63, 13)
            Me.lblUserName.TabIndex = 45
            Me.lblUserName.Text = "User Name:"
            Me.ttUserDetails.SetToolTip(Me.lblUserName, "Enter User name")
            '
            'txtUserName
            '
            Me.CNetHelpProvider.SetHelpKeyword(Me.txtUserName, "Dev++_Form_frmUserSetup.htm#frmUserSetup_txtUserName")
            Me.CNetHelpProvider.SetHelpNavigator(Me.txtUserName, System.Windows.Forms.HelpNavigator.Topic)
            Me.txtUserName.Location = New System.Drawing.Point(125, 17)
            Me.txtUserName.Name = "txtUserName"
            Me.txtUserName.ReadOnly = True
            Me.CNetHelpProvider.SetShowHelp(Me.txtUserName, True)
            Me.txtUserName.Size = New System.Drawing.Size(155, 20)
            Me.txtUserName.TabIndex = 0
            Me.ttUserDetails.SetToolTip(Me.txtUserName, "Enter User name")
            '
            'CNetHelpProvider
            '
            Me.CNetHelpProvider.HelpNamespace = "Dev++.chm"
            '
            'frmUserSetup
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.LightSteelBlue
            Me.CancelButton = Me.btnCancel
            Me.ClientSize = New System.Drawing.Size(656, 366)
            Me.ControlBox = False
            Me.Controls.Add(Me.grpUserSetup)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.CNetHelpProvider.SetHelpKeyword(Me, "Dev++_Form_frmUserSetup.htm")
            Me.CNetHelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.Topic)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmUserSetup"
            Me.CNetHelpProvider.SetShowHelp(Me, True)
            Me.ShowIcon = False
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "User Setup"
            Me.grpUserSetup.ResumeLayout(False)
            Me.pnUinfo.ResumeLayout(False)
            Me.grpDetails.ResumeLayout(False)
            Me.grpPasswordValidation.ResumeLayout(False)
            Me.grpPasswordValidation.PerformLayout()
            Me.pnColorScheme.ResumeLayout(False)
            Me.grpCreateInfo.ResumeLayout(False)
            Me.grpCreateInfo.PerformLayout()
            Me.pnSetup.ResumeLayout(False)
            Me.grpAuthSettings.ResumeLayout(False)
            Me.grpUdetails.ResumeLayout(False)
            Me.grpUdetails.PerformLayout()
            Me.pnlPassword.ResumeLayout(False)
            Me.pnlPassword.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents label4 As System.Windows.Forms.Label
        Friend WithEvents grpUserSetup As System.Windows.Forms.GroupBox
        Friend WithEvents pnColorScheme As System.Windows.Forms.Panel
        Friend WithEvents pnUinfo As System.Windows.Forms.Panel
        Friend WithEvents grpPasswordValidation As System.Windows.Forms.GroupBox
        Friend WithEvents txtPasswordValidity As System.Windows.Forms.TextBox
        Friend WithEvents chkStrongPassword As System.Windows.Forms.CheckBox
        Friend WithEvents dtpPasswordChanged As System.Windows.Forms.DateTimePicker
        Friend WithEvents grpDetails As System.Windows.Forms.GroupBox
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents btnAdd As System.Windows.Forms.Button
        Friend WithEvents cmbContact As System.Windows.Forms.ComboBox
        Friend WithEvents lblContact As System.Windows.Forms.Label
        Friend WithEvents pnSetup As System.Windows.Forms.Panel
        Friend WithEvents grpUdetails As System.Windows.Forms.GroupBox
        Friend WithEvents lblUserName As System.Windows.Forms.Label
        Friend WithEvents txtPassword As System.Windows.Forms.TextBox
        Friend WithEvents txtConfirmPassword As System.Windows.Forms.TextBox
        Friend WithEvents lblConfirmPassword As System.Windows.Forms.Label
        Friend WithEvents txtUserName As System.Windows.Forms.TextBox
        Friend WithEvents grpAuthSettings As System.Windows.Forms.GroupBox
        Friend WithEvents optBoth As System.Windows.Forms.RadioButton
        Friend WithEvents optDomain As System.Windows.Forms.RadioButton
        Friend WithEvents optDevpp As System.Windows.Forms.RadioButton
        Friend WithEvents lblPass As System.Windows.Forms.Label
        Friend WithEvents ttUserDetails As System.Windows.Forms.ToolTip
        Friend WithEvents grpCreateInfo As System.Windows.Forms.GroupBox
        Friend WithEvents dtpCreateDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents txtCreateUserId As System.Windows.Forms.TextBox
        Friend WithEvents pnlPassword As System.Windows.Forms.Panel
        Friend WithEvents chkRetryBlockCheckBox As System.Windows.Forms.CheckBox
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents lblDays As System.Windows.Forms.Label
        Friend WithEvents CNetHelpProvider As System.Windows.Forms.HelpProvider
    End Class
End Namespace