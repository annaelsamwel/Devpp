<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucDbUtilities
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
        Me.lblCurrentCon = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.tabTools = New System.Windows.Forms.TabPage
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtConfirmPassword = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtFilePassword = New System.Windows.Forms.TextBox
        Me.chkZip = New System.Windows.Forms.CheckBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.btnBrowseScript = New System.Windows.Forms.Button
        Me.txtScriptLocation = New System.Windows.Forms.TextBox
        Me.lblDbName = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnRunScript = New System.Windows.Forms.Button
        Me.btnOpen = New System.Windows.Forms.Button
        Me.txtDbBackup = New System.Windows.Forms.TextBox
        Me.btnDBBackup = New System.Windows.Forms.Button
        Me.btnDbRestore = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.tabInit = New System.Windows.Forms.TabPage
        Me.prgService = New System.Windows.Forms.ProgressBar
        Me.lblService = New System.Windows.Forms.Label
        Me.grpInit = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtInitPass = New System.Windows.Forms.TextBox
        Me.txtInitUser = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.chkInitAdv = New System.Windows.Forms.CheckBox
        Me.chkInitWinauth = New System.Windows.Forms.CheckBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbInitInstances = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmbScriptType = New System.Windows.Forms.ComboBox
        Me.btnChangeName = New System.Windows.Forms.Button
        Me.chkNewDatabase = New System.Windows.Forms.CheckBox
        Me.txtCompNameInit = New System.Windows.Forms.TextBox
        Me.txtNewDbInit = New System.Windows.Forms.TextBox
        Me.lblCompNameInit = New System.Windows.Forms.Label
        Me.btnInitAndConn = New System.Windows.Forms.Button
        Me.lblNewDbInit = New System.Windows.Forms.Label
        Me.tabConnect = New System.Windows.Forms.TabPage
        Me.chkUseSecondConection = New System.Windows.Forms.CheckBox
        Me.chkWinAuth = New System.Windows.Forms.CheckBox
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnConnect = New System.Windows.Forms.Button
        Me.chkAdvanced = New System.Windows.Forms.CheckBox
        Me.btnRefresh = New System.Windows.Forms.Button
        Me.lblInstance = New System.Windows.Forms.Label
        Me.cmbDBInstance = New System.Windows.Forms.ComboBox
        Me.grpAdvConn = New System.Windows.Forms.GroupBox
        Me.lblSpecUserName = New System.Windows.Forms.Label
        Me.txtPassword = New System.Windows.Forms.TextBox
        Me.txtSpecUserName = New System.Windows.Forms.TextBox
        Me.lblPassword = New System.Windows.Forms.Label
        Me.cmbDBName = New System.Windows.Forms.ComboBox
        Me.lblDbToSelect = New System.Windows.Forms.Label
        Me.tabManagement = New System.Windows.Forms.TabControl
        Me.fbdRestoreFile = New System.Windows.Forms.OpenFileDialog
        Me.fbdBackup = New System.Windows.Forms.FolderBrowserDialog
        Me.tabTools.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.tabInit.SuspendLayout()
        Me.grpInit.SuspendLayout()
        Me.tabConnect.SuspendLayout()
        Me.grpAdvConn.SuspendLayout()
        Me.tabManagement.SuspendLayout()
        Me.SuspendLayout()
        '
        'lblCurrentCon
        '
        Me.lblCurrentCon.BackColor = System.Drawing.Color.Silver
        Me.lblCurrentCon.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lblCurrentCon.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCurrentCon.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.lblCurrentCon.Location = New System.Drawing.Point(4, 21)
        Me.lblCurrentCon.Name = "lblCurrentCon"
        Me.lblCurrentCon.Size = New System.Drawing.Size(562, 21)
        Me.lblCurrentCon.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label1.Location = New System.Drawing.Point(5, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(132, 15)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Current connection:"
        '
        'tabTools
        '
        Me.tabTools.BackColor = System.Drawing.SystemColors.Window
        Me.tabTools.Controls.Add(Me.Panel1)
        Me.tabTools.Controls.Add(Me.chkZip)
        Me.tabTools.Controls.Add(Me.Label4)
        Me.tabTools.Controls.Add(Me.btnBrowseScript)
        Me.tabTools.Controls.Add(Me.txtScriptLocation)
        Me.tabTools.Controls.Add(Me.lblDbName)
        Me.tabTools.Controls.Add(Me.Label2)
        Me.tabTools.Controls.Add(Me.btnRunScript)
        Me.tabTools.Controls.Add(Me.btnOpen)
        Me.tabTools.Controls.Add(Me.txtDbBackup)
        Me.tabTools.Controls.Add(Me.btnDBBackup)
        Me.tabTools.Controls.Add(Me.btnDbRestore)
        Me.tabTools.ForeColor = System.Drawing.Color.DarkGreen
        Me.tabTools.Location = New System.Drawing.Point(4, 22)
        Me.tabTools.Name = "tabTools"
        Me.tabTools.Size = New System.Drawing.Size(558, 204)
        Me.tabTools.TabIndex = 2
        Me.tabTools.Text = "Tools"
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.Transparent
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.txtConfirmPassword)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.txtFilePassword)
        Me.Panel1.Location = New System.Drawing.Point(149, 67)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(365, 38)
        Me.Panel1.TabIndex = 15
        Me.Panel1.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(175, 13)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(42, 13)
        Me.Label7.TabIndex = 3
        Me.Label7.Text = "Confirm"
        '
        'txtConfirmPassword
        '
        Me.txtConfirmPassword.Location = New System.Drawing.Point(234, 9)
        Me.txtConfirmPassword.Name = "txtConfirmPassword"
        Me.txtConfirmPassword.Size = New System.Drawing.Size(120, 20)
        Me.txtConfirmPassword.TabIndex = 2
        Me.txtConfirmPassword.UseSystemPasswordChar = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 13)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Password"
        '
        'txtFilePassword
        '
        Me.txtFilePassword.Location = New System.Drawing.Point(71, 9)
        Me.txtFilePassword.Name = "txtFilePassword"
        Me.txtFilePassword.Size = New System.Drawing.Size(98, 20)
        Me.txtFilePassword.TabIndex = 0
        Me.txtFilePassword.UseSystemPasswordChar = True
        '
        'chkZip
        '
        Me.chkZip.AutoSize = True
        Me.chkZip.BackColor = System.Drawing.Color.Transparent
        Me.chkZip.Location = New System.Drawing.Point(20, 75)
        Me.chkZip.Name = "chkZip"
        Me.chkZip.Size = New System.Drawing.Size(127, 17)
        Me.chkZip.TabIndex = 14
        Me.chkZip.Text = "Compresed file option"
        Me.chkZip.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.Transparent
        Me.Label4.Location = New System.Drawing.Point(13, 117)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Script Location:"
        '
        'btnBrowseScript
        '
        Me.btnBrowseScript.Location = New System.Drawing.Point(392, 110)
        Me.btnBrowseScript.Name = "btnBrowseScript"
        Me.btnBrowseScript.Size = New System.Drawing.Size(122, 30)
        Me.btnBrowseScript.TabIndex = 12
        Me.btnBrowseScript.Text = "Browse"
        Me.btnBrowseScript.UseVisualStyleBackColor = True
        '
        'txtScriptLocation
        '
        Me.txtScriptLocation.Location = New System.Drawing.Point(117, 115)
        Me.txtScriptLocation.Name = "txtScriptLocation"
        Me.txtScriptLocation.ReadOnly = True
        Me.txtScriptLocation.Size = New System.Drawing.Size(269, 20)
        Me.txtScriptLocation.TabIndex = 11
        '
        'lblDbName
        '
        Me.lblDbName.AutoSize = True
        Me.lblDbName.BackColor = System.Drawing.Color.Transparent
        Me.lblDbName.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDbName.Location = New System.Drawing.Point(214, 47)
        Me.lblDbName.Name = "lblDbName"
        Me.lblDbName.Size = New System.Drawing.Size(10, 13)
        Me.lblDbName.TabIndex = 10
        Me.lblDbName.Text = "-"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.ForeColor = System.Drawing.SystemColors.Desktop
        Me.Label2.Location = New System.Drawing.Point(156, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Database :"
        '
        'btnRunScript
        '
        Me.btnRunScript.BackColor = System.Drawing.Color.Transparent
        Me.btnRunScript.Enabled = False
        Me.btnRunScript.Location = New System.Drawing.Point(392, 147)
        Me.btnRunScript.Name = "btnRunScript"
        Me.btnRunScript.Size = New System.Drawing.Size(122, 28)
        Me.btnRunScript.TabIndex = 6
        Me.btnRunScript.Text = "Run script"
        Me.btnRunScript.UseVisualStyleBackColor = False
        '
        'btnOpen
        '
        Me.btnOpen.BackColor = System.Drawing.Color.Transparent
        Me.btnOpen.ForeColor = System.Drawing.Color.Teal
        Me.btnOpen.Location = New System.Drawing.Point(392, 10)
        Me.btnOpen.Name = "btnOpen"
        Me.btnOpen.Size = New System.Drawing.Size(122, 28)
        Me.btnOpen.TabIndex = 8
        Me.btnOpen.Text = "Location..."
        Me.btnOpen.UseVisualStyleBackColor = False
        '
        'txtDbBackup
        '
        Me.txtDbBackup.Location = New System.Drawing.Point(159, 15)
        Me.txtDbBackup.Name = "txtDbBackup"
        Me.txtDbBackup.Size = New System.Drawing.Size(227, 20)
        Me.txtDbBackup.TabIndex = 6
        '
        'btnDBBackup
        '
        Me.btnDBBackup.BackColor = System.Drawing.Color.Transparent
        Me.btnDBBackup.ForeColor = System.Drawing.Color.Teal
        Me.btnDBBackup.Location = New System.Drawing.Point(16, 10)
        Me.btnDBBackup.Name = "btnDBBackup"
        Me.btnDBBackup.Size = New System.Drawing.Size(122, 28)
        Me.btnDBBackup.TabIndex = 4
        Me.btnDBBackup.Text = "Database backup"
        Me.btnDBBackup.UseVisualStyleBackColor = False
        '
        'btnDbRestore
        '
        Me.btnDbRestore.BackColor = System.Drawing.Color.Transparent
        Me.btnDbRestore.ForeColor = System.Drawing.Color.Teal
        Me.btnDbRestore.Location = New System.Drawing.Point(16, 39)
        Me.btnDbRestore.Name = "btnDbRestore"
        Me.btnDbRestore.Size = New System.Drawing.Size(122, 28)
        Me.btnDbRestore.TabIndex = 5
        Me.btnDbRestore.Text = "Restore database"
        Me.btnDbRestore.UseVisualStyleBackColor = False
        '
        'btnExit
        '
        Me.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExit.Location = New System.Drawing.Point(444, 280)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(122, 22)
        Me.btnExit.TabIndex = 7
        Me.btnExit.Text = "EXIT"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'tabInit
        '
        Me.tabInit.BackColor = System.Drawing.Color.White
        Me.tabInit.Controls.Add(Me.prgService)
        Me.tabInit.Controls.Add(Me.lblService)
        Me.tabInit.Controls.Add(Me.grpInit)
        Me.tabInit.Controls.Add(Me.chkInitAdv)
        Me.tabInit.Controls.Add(Me.chkInitWinauth)
        Me.tabInit.Controls.Add(Me.Button2)
        Me.tabInit.Controls.Add(Me.Label3)
        Me.tabInit.Controls.Add(Me.cmbInitInstances)
        Me.tabInit.Controls.Add(Me.Label5)
        Me.tabInit.Controls.Add(Me.cmbScriptType)
        Me.tabInit.Controls.Add(Me.btnChangeName)
        Me.tabInit.Controls.Add(Me.chkNewDatabase)
        Me.tabInit.Controls.Add(Me.txtCompNameInit)
        Me.tabInit.Controls.Add(Me.txtNewDbInit)
        Me.tabInit.Controls.Add(Me.lblCompNameInit)
        Me.tabInit.Controls.Add(Me.btnInitAndConn)
        Me.tabInit.Controls.Add(Me.lblNewDbInit)
        Me.tabInit.ForeColor = System.Drawing.Color.DarkGreen
        Me.tabInit.Location = New System.Drawing.Point(4, 22)
        Me.tabInit.Name = "tabInit"
        Me.tabInit.Padding = New System.Windows.Forms.Padding(3)
        Me.tabInit.Size = New System.Drawing.Size(558, 204)
        Me.tabInit.TabIndex = 1
        Me.tabInit.Text = "Initialization"
        '
        'prgService
        '
        Me.prgService.Location = New System.Drawing.Point(6, 179)
        Me.prgService.Name = "prgService"
        Me.prgService.Size = New System.Drawing.Size(546, 19)
        Me.prgService.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.prgService.TabIndex = 10
        Me.prgService.Visible = False
        '
        'lblService
        '
        Me.lblService.AutoSize = True
        Me.lblService.Location = New System.Drawing.Point(9, 159)
        Me.lblService.Name = "lblService"
        Me.lblService.Size = New System.Drawing.Size(10, 13)
        Me.lblService.TabIndex = 11
        Me.lblService.Text = ":"
        Me.lblService.Visible = False
        '
        'grpInit
        '
        Me.grpInit.BackColor = System.Drawing.Color.Transparent
        Me.grpInit.Controls.Add(Me.Label8)
        Me.grpInit.Controls.Add(Me.txtInitPass)
        Me.grpInit.Controls.Add(Me.txtInitUser)
        Me.grpInit.Controls.Add(Me.Label9)
        Me.grpInit.Location = New System.Drawing.Point(382, 61)
        Me.grpInit.Name = "grpInit"
        Me.grpInit.Size = New System.Drawing.Size(170, 73)
        Me.grpInit.TabIndex = 26
        Me.grpInit.TabStop = False
        Me.grpInit.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.ForeColor = System.Drawing.Color.Teal
        Me.Label8.Location = New System.Drawing.Point(8, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(29, 13)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "User"
        '
        'txtInitPass
        '
        Me.txtInitPass.Location = New System.Drawing.Point(65, 44)
        Me.txtInitPass.Name = "txtInitPass"
        Me.txtInitPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtInitPass.Size = New System.Drawing.Size(100, 20)
        Me.txtInitPass.TabIndex = 7
        Me.txtInitPass.UseSystemPasswordChar = True
        '
        'txtInitUser
        '
        Me.txtInitUser.Location = New System.Drawing.Point(64, 17)
        Me.txtInitUser.Name = "txtInitUser"
        Me.txtInitUser.Size = New System.Drawing.Size(101, 20)
        Me.txtInitUser.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.ForeColor = System.Drawing.Color.Teal
        Me.Label9.Location = New System.Drawing.Point(8, 50)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 13)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "Password:"
        '
        'chkInitAdv
        '
        Me.chkInitAdv.AutoSize = True
        Me.chkInitAdv.Location = New System.Drawing.Point(393, 35)
        Me.chkInitAdv.Name = "chkInitAdv"
        Me.chkInitAdv.Size = New System.Drawing.Size(81, 17)
        Me.chkInitAdv.TabIndex = 25
        Me.chkInitAdv.Text = "Advanced.."
        Me.chkInitAdv.UseVisualStyleBackColor = True
        '
        'chkInitWinauth
        '
        Me.chkInitWinauth.AutoSize = True
        Me.chkInitWinauth.Location = New System.Drawing.Point(393, 9)
        Me.chkInitWinauth.Name = "chkInitWinauth"
        Me.chkInitWinauth.Size = New System.Drawing.Size(146, 17)
        Me.chkInitWinauth.TabIndex = 24
        Me.chkInitWinauth.Text = "Windows Authentification" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.chkInitWinauth.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(304, 4)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 23
        Me.Button2.Text = "Refresh"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 13)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "Select SQL Instance"
        '
        'cmbInitInstances
        '
        Me.cmbInitInstances.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbInitInstances.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbInitInstances.FormattingEnabled = True
        Me.cmbInitInstances.Location = New System.Drawing.Point(120, 5)
        Me.cmbInitInstances.Name = "cmbInitInstances"
        Me.cmbInitInstances.Size = New System.Drawing.Size(178, 21)
        Me.cmbInitInstances.TabIndex = 21
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(26, 82)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 13)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "Script type"
        '
        'cmbScriptType
        '
        Me.cmbScriptType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbScriptType.FormattingEnabled = True
        Me.cmbScriptType.Location = New System.Drawing.Point(120, 82)
        Me.cmbScriptType.Name = "cmbScriptType"
        Me.cmbScriptType.Size = New System.Drawing.Size(178, 21)
        Me.cmbScriptType.TabIndex = 18
        '
        'btnChangeName
        '
        Me.btnChangeName.ForeColor = System.Drawing.Color.Teal
        Me.btnChangeName.Location = New System.Drawing.Point(304, 57)
        Me.btnChangeName.Name = "btnChangeName"
        Me.btnChangeName.Size = New System.Drawing.Size(75, 21)
        Me.btnChangeName.TabIndex = 17
        Me.btnChangeName.Text = "Change"
        Me.btnChangeName.UseVisualStyleBackColor = True
        '
        'chkNewDatabase
        '
        Me.chkNewDatabase.AutoSize = True
        Me.chkNewDatabase.Location = New System.Drawing.Point(120, 109)
        Me.chkNewDatabase.Name = "chkNewDatabase"
        Me.chkNewDatabase.Size = New System.Drawing.Size(97, 17)
        Me.chkNewDatabase.TabIndex = 13
        Me.chkNewDatabase.Text = "New Database"
        Me.chkNewDatabase.UseVisualStyleBackColor = True
        Me.chkNewDatabase.Visible = False
        '
        'txtCompNameInit
        '
        Me.txtCompNameInit.Location = New System.Drawing.Point(120, 33)
        Me.txtCompNameInit.Name = "txtCompNameInit"
        Me.txtCompNameInit.Size = New System.Drawing.Size(178, 20)
        Me.txtCompNameInit.TabIndex = 10
        '
        'txtNewDbInit
        '
        Me.txtNewDbInit.BackColor = System.Drawing.Color.DarkSeaGreen
        Me.txtNewDbInit.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNewDbInit.ForeColor = System.Drawing.SystemColors.Menu
        Me.txtNewDbInit.Location = New System.Drawing.Point(120, 57)
        Me.txtNewDbInit.Name = "txtNewDbInit"
        Me.txtNewDbInit.ReadOnly = True
        Me.txtNewDbInit.Size = New System.Drawing.Size(178, 21)
        Me.txtNewDbInit.TabIndex = 9
        '
        'lblCompNameInit
        '
        Me.lblCompNameInit.AutoSize = True
        Me.lblCompNameInit.Location = New System.Drawing.Point(26, 33)
        Me.lblCompNameInit.Name = "lblCompNameInit"
        Me.lblCompNameInit.Size = New System.Drawing.Size(83, 13)
        Me.lblCompNameInit.TabIndex = 4
        Me.lblCompNameInit.Text = "Company name:"
        '
        'btnInitAndConn
        '
        Me.btnInitAndConn.ForeColor = System.Drawing.Color.Teal
        Me.btnInitAndConn.Location = New System.Drawing.Point(225, 106)
        Me.btnInitAndConn.Name = "btnInitAndConn"
        Me.btnInitAndConn.Size = New System.Drawing.Size(154, 28)
        Me.btnInitAndConn.TabIndex = 2
        Me.btnInitAndConn.Text = "Initialize and Connect"
        Me.btnInitAndConn.UseVisualStyleBackColor = True
        '
        'lblNewDbInit
        '
        Me.lblNewDbInit.AutoSize = True
        Me.lblNewDbInit.Location = New System.Drawing.Point(26, 57)
        Me.lblNewDbInit.Name = "lblNewDbInit"
        Me.lblNewDbInit.Size = New System.Drawing.Size(85, 13)
        Me.lblNewDbInit.TabIndex = 3
        Me.lblNewDbInit.Text = "Database name:"
        '
        'tabConnect
        '
        Me.tabConnect.BackColor = System.Drawing.SystemColors.Window
        Me.tabConnect.Controls.Add(Me.chkUseSecondConection)
        Me.tabConnect.Controls.Add(Me.chkWinAuth)
        Me.tabConnect.Controls.Add(Me.btnSave)
        Me.tabConnect.Controls.Add(Me.btnConnect)
        Me.tabConnect.Controls.Add(Me.chkAdvanced)
        Me.tabConnect.Controls.Add(Me.btnRefresh)
        Me.tabConnect.Controls.Add(Me.lblInstance)
        Me.tabConnect.Controls.Add(Me.cmbDBInstance)
        Me.tabConnect.Controls.Add(Me.grpAdvConn)
        Me.tabConnect.Controls.Add(Me.cmbDBName)
        Me.tabConnect.Controls.Add(Me.lblDbToSelect)
        Me.tabConnect.ForeColor = System.Drawing.Color.DarkGreen
        Me.tabConnect.Location = New System.Drawing.Point(4, 22)
        Me.tabConnect.Name = "tabConnect"
        Me.tabConnect.Padding = New System.Windows.Forms.Padding(3)
        Me.tabConnect.Size = New System.Drawing.Size(558, 204)
        Me.tabConnect.TabIndex = 0
        Me.tabConnect.Text = "Connection"
        '
        'chkUseSecondConection
        '
        Me.chkUseSecondConection.AutoSize = True
        Me.chkUseSecondConection.Location = New System.Drawing.Point(285, 9)
        Me.chkUseSecondConection.Name = "chkUseSecondConection"
        Me.chkUseSecondConection.Size = New System.Drawing.Size(142, 17)
        Me.chkUseSecondConection.TabIndex = 19
        Me.chkUseSecondConection.Text = "Use Second Connection"
        Me.chkUseSecondConection.UseVisualStyleBackColor = True
        '
        'chkWinAuth
        '
        Me.chkWinAuth.AutoSize = True
        Me.chkWinAuth.Location = New System.Drawing.Point(159, 90)
        Me.chkWinAuth.Name = "chkWinAuth"
        Me.chkWinAuth.Size = New System.Drawing.Size(146, 17)
        Me.chkWinAuth.TabIndex = 17
        Me.chkWinAuth.Text = "Windows Authentification" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        Me.chkWinAuth.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.Teal
        Me.btnSave.Location = New System.Drawing.Point(420, 29)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(122, 22)
        Me.btnSave.TabIndex = 16
        Me.btnSave.Text = "SAVE CHANGES"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnConnect
        '
        Me.btnConnect.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnConnect.ForeColor = System.Drawing.Color.Teal
        Me.btnConnect.Location = New System.Drawing.Point(420, 59)
        Me.btnConnect.Name = "btnConnect"
        Me.btnConnect.Size = New System.Drawing.Size(122, 22)
        Me.btnConnect.TabIndex = 15
        Me.btnConnect.Text = "CONNECT"
        Me.btnConnect.UseVisualStyleBackColor = True
        '
        'chkAdvanced
        '
        Me.chkAdvanced.AutoSize = True
        Me.chkAdvanced.Location = New System.Drawing.Point(159, 113)
        Me.chkAdvanced.Name = "chkAdvanced"
        Me.chkAdvanced.Size = New System.Drawing.Size(81, 17)
        Me.chkAdvanced.TabIndex = 18
        Me.chkAdvanced.Text = "Advanced.."
        Me.chkAdvanced.UseVisualStyleBackColor = True
        Me.chkAdvanced.Visible = False
        '
        'btnRefresh
        '
        Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.Location = New System.Drawing.Point(159, 6)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(120, 22)
        Me.btnRefresh.TabIndex = 13
        Me.btnRefresh.Text = "REFRESH SERVERS"
        Me.btnRefresh.UseVisualStyleBackColor = True
        '
        'lblInstance
        '
        Me.lblInstance.AutoSize = True
        Me.lblInstance.Location = New System.Drawing.Point(32, 36)
        Me.lblInstance.Name = "lblInstance"
        Me.lblInstance.Size = New System.Drawing.Size(105, 13)
        Me.lblInstance.TabIndex = 12
        Me.lblInstance.Text = "Select SQL Instance"
        '
        'cmbDBInstance
        '
        Me.cmbDBInstance.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbDBInstance.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbDBInstance.FormattingEnabled = True
        Me.cmbDBInstance.Location = New System.Drawing.Point(159, 35)
        Me.cmbDBInstance.Name = "cmbDBInstance"
        Me.cmbDBInstance.Size = New System.Drawing.Size(227, 21)
        Me.cmbDBInstance.TabIndex = 11
        '
        'grpAdvConn
        '
        Me.grpAdvConn.BackColor = System.Drawing.Color.Transparent
        Me.grpAdvConn.Controls.Add(Me.lblSpecUserName)
        Me.grpAdvConn.Controls.Add(Me.txtPassword)
        Me.grpAdvConn.Controls.Add(Me.txtSpecUserName)
        Me.grpAdvConn.Controls.Add(Me.lblPassword)
        Me.grpAdvConn.Location = New System.Drawing.Point(159, 126)
        Me.grpAdvConn.Name = "grpAdvConn"
        Me.grpAdvConn.Size = New System.Drawing.Size(227, 73)
        Me.grpAdvConn.TabIndex = 10
        Me.grpAdvConn.TabStop = False
        Me.grpAdvConn.Visible = False
        '
        'lblSpecUserName
        '
        Me.lblSpecUserName.AutoSize = True
        Me.lblSpecUserName.ForeColor = System.Drawing.Color.Teal
        Me.lblSpecUserName.Location = New System.Drawing.Point(8, 22)
        Me.lblSpecUserName.Name = "lblSpecUserName"
        Me.lblSpecUserName.Size = New System.Drawing.Size(87, 13)
        Me.lblSpecUserName.TabIndex = 10
        Me.lblSpecUserName.Text = "SQL Server User"
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(101, 43)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(120, 20)
        Me.txtPassword.TabIndex = 7
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'txtSpecUserName
        '
        Me.txtSpecUserName.Location = New System.Drawing.Point(101, 18)
        Me.txtSpecUserName.Name = "txtSpecUserName"
        Me.txtSpecUserName.Size = New System.Drawing.Size(120, 20)
        Me.txtSpecUserName.TabIndex = 6
        '
        'lblPassword
        '
        Me.lblPassword.AutoSize = True
        Me.lblPassword.ForeColor = System.Drawing.Color.Teal
        Me.lblPassword.Location = New System.Drawing.Point(8, 50)
        Me.lblPassword.Name = "lblPassword"
        Me.lblPassword.Size = New System.Drawing.Size(56, 13)
        Me.lblPassword.TabIndex = 4
        Me.lblPassword.Text = "Password:"
        '
        'cmbDBName
        '
        Me.cmbDBName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.cmbDBName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.cmbDBName.Cursor = System.Windows.Forms.Cursors.Default
        Me.cmbDBName.FormatString = "indexed"
        Me.cmbDBName.FormattingEnabled = True
        Me.cmbDBName.Location = New System.Drawing.Point(159, 65)
        Me.cmbDBName.Name = "cmbDBName"
        Me.cmbDBName.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cmbDBName.Size = New System.Drawing.Size(227, 21)
        Me.cmbDBName.TabIndex = 8
        '
        'lblDbToSelect
        '
        Me.lblDbToSelect.AutoSize = True
        Me.lblDbToSelect.Location = New System.Drawing.Point(30, 65)
        Me.lblDbToSelect.Name = "lblDbToSelect"
        Me.lblDbToSelect.Size = New System.Drawing.Size(121, 13)
        Me.lblDbToSelect.TabIndex = 5
        Me.lblDbToSelect.Text = "Company data to select:"
        '
        'tabManagement
        '
        Me.tabManagement.Controls.Add(Me.tabConnect)
        Me.tabManagement.Controls.Add(Me.tabInit)
        Me.tabManagement.Controls.Add(Me.tabTools)
        Me.tabManagement.Location = New System.Drawing.Point(4, 44)
        Me.tabManagement.Name = "tabManagement"
        Me.tabManagement.SelectedIndex = 0
        Me.tabManagement.Size = New System.Drawing.Size(566, 230)
        Me.tabManagement.TabIndex = 7
        '
        'fbdRestoreFile
        '
        Me.fbdRestoreFile.Filter = "SQL files (*.ebk)|*.ebk|All files (*.*)|*.*"
        '
        'ucDbUtilities
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Controls.Add(Me.lblCurrentCon)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.tabManagement)
        Me.Controls.Add(Me.btnExit)
        Me.ForeColor = System.Drawing.Color.Teal
        Me.Name = "ucDbUtilities"
        Me.Size = New System.Drawing.Size(573, 309)
        Me.tabTools.ResumeLayout(False)
        Me.tabTools.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.tabInit.ResumeLayout(False)
        Me.tabInit.PerformLayout()
        Me.grpInit.ResumeLayout(False)
        Me.grpInit.PerformLayout()
        Me.tabConnect.ResumeLayout(False)
        Me.tabConnect.PerformLayout()
        Me.grpAdvConn.ResumeLayout(False)
        Me.grpAdvConn.PerformLayout()
        Me.tabManagement.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblCurrentCon As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents tabTools As System.Windows.Forms.TabPage
    Friend WithEvents lblDbName As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnOpen As System.Windows.Forms.Button
    Friend WithEvents txtDbBackup As System.Windows.Forms.TextBox
    Friend WithEvents btnDBBackup As System.Windows.Forms.Button
    Friend WithEvents btnDbRestore As System.Windows.Forms.Button
    Friend WithEvents btnRunScript As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents tabInit As System.Windows.Forms.TabPage
    Friend WithEvents txtCompNameInit As System.Windows.Forms.TextBox
    Friend WithEvents lblCompNameInit As System.Windows.Forms.Label
    Friend WithEvents btnInitAndConn As System.Windows.Forms.Button
    Friend WithEvents lblNewDbInit As System.Windows.Forms.Label
    Friend WithEvents tabConnect As System.Windows.Forms.TabPage
    Friend WithEvents btnRefresh As System.Windows.Forms.Button
    Friend WithEvents lblInstance As System.Windows.Forms.Label
    Friend WithEvents cmbDBInstance As System.Windows.Forms.ComboBox
    Friend WithEvents grpAdvConn As System.Windows.Forms.GroupBox
    Friend WithEvents lblSpecUserName As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents txtSpecUserName As System.Windows.Forms.TextBox
    Friend WithEvents lblPassword As System.Windows.Forms.Label
    Friend WithEvents cmbDBName As System.Windows.Forms.ComboBox
    Friend WithEvents lblDbToSelect As System.Windows.Forms.Label
    Friend WithEvents tabManagement As System.Windows.Forms.TabControl

    Friend WithEvents btnConnect As System.Windows.Forms.Button
    Friend WithEvents fbdRestoreFile As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents chkWinAuth As System.Windows.Forms.CheckBox
    Friend WithEvents fbdBackup As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents chkAdvanced As System.Windows.Forms.CheckBox
    Friend WithEvents chkNewDatabase As System.Windows.Forms.CheckBox
    Friend WithEvents btnBrowseScript As System.Windows.Forms.Button
    Friend WithEvents txtScriptLocation As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnChangeName As System.Windows.Forms.Button
    Friend WithEvents chkUseSecondConection As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbScriptType As System.Windows.Forms.ComboBox
    Friend WithEvents txtNewDbInit As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbInitInstances As System.Windows.Forms.ComboBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents chkZip As System.Windows.Forms.CheckBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtConfirmPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtFilePassword As System.Windows.Forms.TextBox
    Friend WithEvents grpInit As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtInitPass As System.Windows.Forms.TextBox
    Friend WithEvents txtInitUser As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents chkInitAdv As System.Windows.Forms.CheckBox
    Friend WithEvents chkInitWinauth As System.Windows.Forms.CheckBox
    Friend WithEvents prgService As System.Windows.Forms.ProgressBar
    Friend WithEvents lblService As System.Windows.Forms.Label

End Class
