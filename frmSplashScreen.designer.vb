Namespace Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmSplashScreen
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
        Friend WithEvents ApplicationTitle As System.Windows.Forms.Label
        Friend WithEvents Version As System.Windows.Forms.Label
        Friend WithEvents Copyright As System.Windows.Forms.Label
        Friend WithEvents MainLayoutPanel As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents DetailsLayoutPanel As System.Windows.Forms.TableLayoutPanel

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.MainLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
            Me.ApplicationTitle = New System.Windows.Forms.Label()
            Me.DetailsLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
            Me.Version = New System.Windows.Forms.Label()
            Me.Copyright = New System.Windows.Forms.Label()
            Me.Panel1 = New System.Windows.Forms.Panel()
            Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
            Me.lblStatus = New System.Windows.Forms.Label()
            Me.Panel2 = New System.Windows.Forms.Panel()
            Me.lblDescription = New System.Windows.Forms.Label()
            Me.Label2 = New System.Windows.Forms.Label()
            Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
            Me.CNetHelpProvider = New System.Windows.Forms.HelpProvider()
            Me.PictureBox2 = New System.Windows.Forms.PictureBox()
            Me.MainLayoutPanel.SuspendLayout()
            Me.DetailsLayoutPanel.SuspendLayout()
            Me.Panel1.SuspendLayout()
            Me.Panel2.SuspendLayout()
            CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'MainLayoutPanel
            '
            Me.MainLayoutPanel.BackColor = System.Drawing.Color.Transparent
            Me.MainLayoutPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
            Me.MainLayoutPanel.ColumnCount = 2
            Me.MainLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 243.0!))
            Me.MainLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 253.0!))
            Me.MainLayoutPanel.Controls.Add(Me.ApplicationTitle, 1, 0)
            Me.MainLayoutPanel.Controls.Add(Me.DetailsLayoutPanel, 1, 1)
            Me.MainLayoutPanel.Controls.Add(Me.Panel1, 0, 1)
            Me.MainLayoutPanel.Controls.Add(Me.Panel2, 0, 0)
            Me.MainLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.MainLayoutPanel.ForeColor = System.Drawing.Color.White
            Me.CNetHelpProvider.SetHelpKeyword(Me.MainLayoutPanel, "Dev++_Form_frmSplashScreen.htm#frmSplashScreen_MainLayoutPanel")
            Me.CNetHelpProvider.SetHelpNavigator(Me.MainLayoutPanel, System.Windows.Forms.HelpNavigator.Topic)
            Me.MainLayoutPanel.Location = New System.Drawing.Point(0, 0)
            Me.MainLayoutPanel.Name = "MainLayoutPanel"
            Me.MainLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 218.0!))
            Me.MainLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 38.0!))
            Me.CNetHelpProvider.SetShowHelp(Me.MainLayoutPanel, True)
            Me.MainLayoutPanel.Size = New System.Drawing.Size(496, 303)
            Me.MainLayoutPanel.TabIndex = 0
            '
            'ApplicationTitle
            '
            Me.ApplicationTitle.BackColor = System.Drawing.Color.Transparent
            Me.ApplicationTitle.Dock = System.Windows.Forms.DockStyle.Fill
            Me.ApplicationTitle.Font = New System.Drawing.Font("Elephant", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.ApplicationTitle.ForeColor = System.Drawing.Color.RoyalBlue
            Me.CNetHelpProvider.SetHelpKeyword(Me.ApplicationTitle, "Dev++_Form_frmSplashScreen.htm#frmSplashScreen_ApplicationTitle")
            Me.CNetHelpProvider.SetHelpNavigator(Me.ApplicationTitle, System.Windows.Forms.HelpNavigator.Topic)
            Me.ApplicationTitle.ImageAlign = System.Drawing.ContentAlignment.TopLeft
            Me.ApplicationTitle.Location = New System.Drawing.Point(246, 0)
            Me.ApplicationTitle.Name = "ApplicationTitle"
            Me.CNetHelpProvider.SetShowHelp(Me.ApplicationTitle, True)
            Me.ApplicationTitle.Size = New System.Drawing.Size(247, 218)
            Me.ApplicationTitle.TabIndex = 0
            Me.ApplicationTitle.Text = "Application Title"
            Me.ApplicationTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'DetailsLayoutPanel
            '
            Me.DetailsLayoutPanel.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.DetailsLayoutPanel.BackColor = System.Drawing.Color.Transparent
            Me.DetailsLayoutPanel.ColumnCount = 1
            Me.DetailsLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 247.0!))
            Me.DetailsLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 142.0!))
            Me.DetailsLayoutPanel.Controls.Add(Me.Version, 0, 0)
            Me.DetailsLayoutPanel.Controls.Add(Me.Copyright, 0, 1)
            Me.DetailsLayoutPanel.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CNetHelpProvider.SetHelpKeyword(Me.DetailsLayoutPanel, "Dev++_Form_frmSplashScreen.htm#frmSplashScreen_DetailsLayoutPanel")
            Me.CNetHelpProvider.SetHelpNavigator(Me.DetailsLayoutPanel, System.Windows.Forms.HelpNavigator.Topic)
            Me.DetailsLayoutPanel.Location = New System.Drawing.Point(246, 232)
            Me.DetailsLayoutPanel.Name = "DetailsLayoutPanel"
            Me.DetailsLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
            Me.DetailsLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.0!))
            Me.CNetHelpProvider.SetShowHelp(Me.DetailsLayoutPanel, True)
            Me.DetailsLayoutPanel.Size = New System.Drawing.Size(247, 57)
            Me.DetailsLayoutPanel.TabIndex = 1
            '
            'Version
            '
            Me.Version.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.Version.BackColor = System.Drawing.Color.Transparent
            Me.Version.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Version.ForeColor = System.Drawing.Color.RoyalBlue
            Me.CNetHelpProvider.SetHelpKeyword(Me.Version, "Dev++_Form_frmSplashScreen.htm#frmSplashScreen_Version")
            Me.CNetHelpProvider.SetHelpNavigator(Me.Version, System.Windows.Forms.HelpNavigator.Topic)
            Me.Version.Location = New System.Drawing.Point(3, 4)
            Me.Version.Name = "Version"
            Me.CNetHelpProvider.SetShowHelp(Me.Version, True)
            Me.Version.Size = New System.Drawing.Size(241, 20)
            Me.Version.TabIndex = 1
            Me.Version.Text = "Version"
            '
            'Copyright
            '
            Me.Copyright.Anchor = System.Windows.Forms.AnchorStyles.None
            Me.Copyright.BackColor = System.Drawing.Color.Transparent
            Me.Copyright.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Copyright.ForeColor = System.Drawing.Color.RoyalBlue
            Me.CNetHelpProvider.SetHelpKeyword(Me.Copyright, "Dev++_Form_frmSplashScreen.htm#frmSplashScreen_Copyright")
            Me.CNetHelpProvider.SetHelpNavigator(Me.Copyright, System.Windows.Forms.HelpNavigator.Topic)
            Me.Copyright.Location = New System.Drawing.Point(3, 28)
            Me.Copyright.Name = "Copyright"
            Me.CNetHelpProvider.SetShowHelp(Me.Copyright, True)
            Me.Copyright.Size = New System.Drawing.Size(241, 28)
            Me.Copyright.TabIndex = 2
            Me.Copyright.Text = "Copyright"
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.Transparent
            Me.Panel1.Controls.Add(Me.ProgressBar1)
            Me.Panel1.Controls.Add(Me.lblStatus)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Panel1.ForeColor = System.Drawing.Color.SteelBlue
            Me.CNetHelpProvider.SetHelpKeyword(Me.Panel1, "Dev++_Form_frmSplashScreen.htm#frmSplashScreen_Panel1")
            Me.CNetHelpProvider.SetHelpNavigator(Me.Panel1, System.Windows.Forms.HelpNavigator.Topic)
            Me.Panel1.Location = New System.Drawing.Point(3, 221)
            Me.Panel1.Name = "Panel1"
            Me.CNetHelpProvider.SetShowHelp(Me.Panel1, True)
            Me.Panel1.Size = New System.Drawing.Size(237, 79)
            Me.Panel1.TabIndex = 2
            '
            'ProgressBar1
            '
            Me.ProgressBar1.BackColor = System.Drawing.Color.Yellow
            Me.ProgressBar1.Location = New System.Drawing.Point(3, 6)
            Me.ProgressBar1.Name = "ProgressBar1"
            Me.ProgressBar1.Size = New System.Drawing.Size(229, 23)
            Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee
            Me.ProgressBar1.TabIndex = 4
            '
            'lblStatus
            '
            Me.lblStatus.BackColor = System.Drawing.Color.Transparent
            Me.lblStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.lblStatus.ForeColor = System.Drawing.Color.RoyalBlue
            Me.CNetHelpProvider.SetHelpKeyword(Me.lblStatus, "Dev++_Form_frmSplashScreen.htm#frmSplashScreen_lblStatus")
            Me.CNetHelpProvider.SetHelpNavigator(Me.lblStatus, System.Windows.Forms.HelpNavigator.Topic)
            Me.lblStatus.Location = New System.Drawing.Point(0, 45)
            Me.lblStatus.Name = "lblStatus"
            Me.CNetHelpProvider.SetShowHelp(Me.lblStatus, True)
            Me.lblStatus.Size = New System.Drawing.Size(232, 27)
            Me.lblStatus.TabIndex = 3
            '
            'Panel2
            '
            Me.Panel2.Controls.Add(Me.PictureBox2)
            Me.Panel2.Controls.Add(Me.lblDescription)
            Me.Panel2.Controls.Add(Me.Label2)
            Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Panel2.Location = New System.Drawing.Point(3, 3)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(237, 212)
            Me.Panel2.TabIndex = 3
            '
            'lblDescription
            '
            Me.lblDescription.ForeColor = System.Drawing.Color.RoyalBlue
            Me.lblDescription.Location = New System.Drawing.Point(5, 135)
            Me.lblDescription.Name = "lblDescription"
            Me.lblDescription.Size = New System.Drawing.Size(232, 76)
            Me.lblDescription.TabIndex = 2
            Me.lblDescription.Text = "#"
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label2.Location = New System.Drawing.Point(5, 104)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(0, 13)
            Me.Label2.TabIndex = 1
            '
            'Timer1
            '
            '
            'CNetHelpProvider
            '
            Me.CNetHelpProvider.HelpNamespace = "Dev++.chm"
            '
            'PictureBox2
            '
            Me.PictureBox2.Image = Global.Devpp.My.Resources.Resources.NVT
            Me.PictureBox2.Location = New System.Drawing.Point(3, 0)
            Me.PictureBox2.Name = "PictureBox2"
            Me.PictureBox2.Size = New System.Drawing.Size(156, 127)
            Me.PictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
            Me.PictureBox2.TabIndex = 4
            Me.PictureBox2.TabStop = False
            '
            'frmSplashScreen
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.White
            Me.ClientSize = New System.Drawing.Size(496, 303)
            Me.ControlBox = False
            Me.Controls.Add(Me.MainLayoutPanel)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
            Me.CNetHelpProvider.SetHelpKeyword(Me, "Dev++_Form_frmSplashScreen.htm")
            Me.CNetHelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.Topic)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmSplashScreen"
            Me.CNetHelpProvider.SetShowHelp(Me, True)
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.MainLayoutPanel.ResumeLayout(False)
            Me.DetailsLayoutPanel.ResumeLayout(False)
            Me.Panel1.ResumeLayout(False)
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents lblStatus As System.Windows.Forms.Label
        Friend WithEvents Timer1 As System.Windows.Forms.Timer
        Friend WithEvents CNetHelpProvider As System.Windows.Forms.HelpProvider
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents lblDescription As System.Windows.Forms.Label
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
        Friend WithEvents PictureBox2 As System.Windows.Forms.PictureBox

    End Class
End Namespace