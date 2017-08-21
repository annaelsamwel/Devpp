Namespace Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmAboutBox
        Inherits System.Windows.Forms.Form

        'Form overrides dispose to clean up the component list.
        <System.Diagnostics.DebuggerNonUserCode()> _
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        Friend WithEvents TableLayoutPanel As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents LabelProductName As System.Windows.Forms.Label
        Friend WithEvents LabelVersion As System.Windows.Forms.Label
        Friend WithEvents LabelCompanyName As System.Windows.Forms.Label
        Friend WithEvents OKButton As System.Windows.Forms.Button
        Friend WithEvents LabelCopyright As System.Windows.Forms.Label

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        <System.Diagnostics.DebuggerStepThrough()> _
        Private Sub InitializeComponent()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmAboutBox))
            Me.TableLayoutPanel = New System.Windows.Forms.TableLayoutPanel()
            Me.LabelProductName = New System.Windows.Forms.Label()
            Me.LabelVersion = New System.Windows.Forms.Label()
            Me.LabelCopyright = New System.Windows.Forms.Label()
            Me.LabelCompanyName = New System.Windows.Forms.Label()
            Me.TextBoxDescription = New System.Windows.Forms.TextBox()
            Me.OKButton = New System.Windows.Forms.Button()
            Me.CNetHelpProvider = New System.Windows.Forms.HelpProvider()
            Me.TableLayoutPanel.SuspendLayout()
            Me.SuspendLayout()
            '
            'TableLayoutPanel
            '
            Me.TableLayoutPanel.ColumnCount = 2
            Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.01005!))
            Me.TableLayoutPanel.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 97.98995!))
            Me.TableLayoutPanel.Controls.Add(Me.LabelProductName, 1, 0)
            Me.TableLayoutPanel.Controls.Add(Me.LabelVersion, 1, 1)
            Me.TableLayoutPanel.Controls.Add(Me.LabelCopyright, 1, 2)
            Me.TableLayoutPanel.Controls.Add(Me.LabelCompanyName, 1, 3)
            Me.TableLayoutPanel.Controls.Add(Me.TextBoxDescription, 1, 4)
            Me.TableLayoutPanel.Controls.Add(Me.OKButton, 1, 5)
            Me.TableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CNetHelpProvider.SetHelpKeyword(Me.TableLayoutPanel, "Dev++_Form_frmAboutBox.htm#frmAboutBox_TableLayoutPanel")
            Me.CNetHelpProvider.SetHelpNavigator(Me.TableLayoutPanel, System.Windows.Forms.HelpNavigator.Topic)
            Me.TableLayoutPanel.Location = New System.Drawing.Point(12, 11)
            Me.TableLayoutPanel.Margin = New System.Windows.Forms.Padding(4)
            Me.TableLayoutPanel.Name = "TableLayoutPanel"
            Me.TableLayoutPanel.RowCount = 6
            Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
            Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
            Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
            Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.0!))
            Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.26368!))
            Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.92537!))
            Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.TableLayoutPanel.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25.0!))
            Me.CNetHelpProvider.SetShowHelp(Me.TableLayoutPanel, True)
            Me.TableLayoutPanel.Size = New System.Drawing.Size(531, 248)
            Me.TableLayoutPanel.TabIndex = 0
            '
            'LabelProductName
            '
            Me.LabelProductName.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CNetHelpProvider.SetHelpKeyword(Me.LabelProductName, "Dev++_Form_frmAboutBox.htm#frmAboutBox_LabelProductName")
            Me.CNetHelpProvider.SetHelpNavigator(Me.LabelProductName, System.Windows.Forms.HelpNavigator.Topic)
            Me.LabelProductName.Location = New System.Drawing.Point(18, 0)
            Me.LabelProductName.Margin = New System.Windows.Forms.Padding(8, 0, 4, 0)
            Me.LabelProductName.MaximumSize = New System.Drawing.Size(0, 21)
            Me.LabelProductName.Name = "LabelProductName"
            Me.CNetHelpProvider.SetShowHelp(Me.LabelProductName, True)
            Me.LabelProductName.Size = New System.Drawing.Size(509, 21)
            Me.LabelProductName.TabIndex = 0
            Me.LabelProductName.Text = "Reception Master"
            Me.LabelProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'LabelVersion
            '
            Me.LabelVersion.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CNetHelpProvider.SetHelpKeyword(Me.LabelVersion, "Dev++_Form_frmAboutBox.htm#frmAboutBox_LabelVersion")
            Me.CNetHelpProvider.SetHelpNavigator(Me.LabelVersion, System.Windows.Forms.HelpNavigator.Topic)
            Me.LabelVersion.Location = New System.Drawing.Point(18, 24)
            Me.LabelVersion.Margin = New System.Windows.Forms.Padding(8, 0, 4, 0)
            Me.LabelVersion.MaximumSize = New System.Drawing.Size(0, 21)
            Me.LabelVersion.Name = "LabelVersion"
            Me.CNetHelpProvider.SetShowHelp(Me.LabelVersion, True)
            Me.LabelVersion.Size = New System.Drawing.Size(509, 21)
            Me.LabelVersion.TabIndex = 0
            Me.LabelVersion.Text = "Version "
            Me.LabelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'LabelCopyright
            '
            Me.LabelCopyright.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CNetHelpProvider.SetHelpKeyword(Me.LabelCopyright, "Dev++_Form_frmAboutBox.htm#frmAboutBox_LabelCopyright")
            Me.CNetHelpProvider.SetHelpNavigator(Me.LabelCopyright, System.Windows.Forms.HelpNavigator.Topic)
            Me.LabelCopyright.Location = New System.Drawing.Point(18, 48)
            Me.LabelCopyright.Margin = New System.Windows.Forms.Padding(8, 0, 4, 0)
            Me.LabelCopyright.MaximumSize = New System.Drawing.Size(0, 21)
            Me.LabelCopyright.Name = "LabelCopyright"
            Me.CNetHelpProvider.SetShowHelp(Me.LabelCopyright, True)
            Me.LabelCopyright.Size = New System.Drawing.Size(509, 21)
            Me.LabelCopyright.TabIndex = 0
            Me.LabelCopyright.Text = "Copyright"
            Me.LabelCopyright.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'LabelCompanyName
            '
            Me.LabelCompanyName.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CNetHelpProvider.SetHelpKeyword(Me.LabelCompanyName, "Dev++_Form_frmAboutBox.htm#frmAboutBox_LabelCompanyName")
            Me.CNetHelpProvider.SetHelpNavigator(Me.LabelCompanyName, System.Windows.Forms.HelpNavigator.Topic)
            Me.LabelCompanyName.Location = New System.Drawing.Point(18, 72)
            Me.LabelCompanyName.Margin = New System.Windows.Forms.Padding(8, 0, 4, 0)
            Me.LabelCompanyName.MaximumSize = New System.Drawing.Size(0, 21)
            Me.LabelCompanyName.Name = "LabelCompanyName"
            Me.CNetHelpProvider.SetShowHelp(Me.LabelCompanyName, True)
            Me.LabelCompanyName.Size = New System.Drawing.Size(509, 21)
            Me.LabelCompanyName.TabIndex = 0
            Me.LabelCompanyName.Text = "Devpp "
            Me.LabelCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'TextBoxDescription
            '
            Me.TextBoxDescription.BackColor = System.Drawing.Color.White
            Me.TextBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.None
            Me.TextBoxDescription.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CNetHelpProvider.SetHelpKeyword(Me.TextBoxDescription, "Dev++_Form_frmAboutBox.htm#frmAboutBox_TextBoxDescription")
            Me.CNetHelpProvider.SetHelpNavigator(Me.TextBoxDescription, System.Windows.Forms.HelpNavigator.Topic)
            Me.TextBoxDescription.Location = New System.Drawing.Point(18, 100)
            Me.TextBoxDescription.Margin = New System.Windows.Forms.Padding(8, 4, 4, 4)
            Me.TextBoxDescription.Multiline = True
            Me.TextBoxDescription.Name = "TextBoxDescription"
            Me.TextBoxDescription.ReadOnly = True
            Me.TextBoxDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both
            Me.CNetHelpProvider.SetShowHelp(Me.TextBoxDescription, True)
            Me.TextBoxDescription.Size = New System.Drawing.Size(509, 106)
            Me.TextBoxDescription.TabIndex = 0
            Me.TextBoxDescription.TabStop = False
            Me.TextBoxDescription.Text = resources.GetString("TextBoxDescription.Text")
            '
            'OKButton
            '
            Me.OKButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.OKButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.OKButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.CNetHelpProvider.SetHelpKeyword(Me.OKButton, "Dev++_Form_frmAboutBox.htm#frmAboutBox_OKButton")
            Me.CNetHelpProvider.SetHelpNavigator(Me.OKButton, System.Windows.Forms.HelpNavigator.Topic)
            Me.OKButton.Location = New System.Drawing.Point(427, 217)
            Me.OKButton.Margin = New System.Windows.Forms.Padding(4)
            Me.OKButton.Name = "OKButton"
            Me.CNetHelpProvider.SetShowHelp(Me.OKButton, True)
            Me.OKButton.Size = New System.Drawing.Size(100, 27)
            Me.OKButton.TabIndex = 0
            Me.OKButton.Text = "OK"
            '
            'CNetHelpProvider
            '
            Me.CNetHelpProvider.HelpNamespace = "Dev++.chm"
            '
            'frmAboutBox
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.White
            Me.ClientSize = New System.Drawing.Size(555, 270)
            Me.Controls.Add(Me.TableLayoutPanel)
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.CNetHelpProvider.SetHelpKeyword(Me, "Dev++_Form_frmAboutBox.htm")
            Me.CNetHelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.Topic)
            Me.Margin = New System.Windows.Forms.Padding(4)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmAboutBox"
            Me.Padding = New System.Windows.Forms.Padding(12, 11, 12, 11)
            Me.CNetHelpProvider.SetShowHelp(Me, True)
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "AboutBox1"
            Me.TableLayoutPanel.ResumeLayout(False)
            Me.TableLayoutPanel.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents TextBoxDescription As System.Windows.Forms.TextBox
        Friend WithEvents CNetHelpProvider As System.Windows.Forms.HelpProvider

    End Class
End Namespace