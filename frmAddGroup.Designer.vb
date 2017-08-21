<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddGroup
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
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel()
        Me.OK_Button = New System.Windows.Forms.Button()
        Me.Cancel_Button = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtGroup = New System.Windows.Forms.TextBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.CNetHelpProvider = New System.Windows.Forms.HelpProvider()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TableLayoutPanel1.ColumnCount = 2
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.OK_Button, 0, 0)
        Me.TableLayoutPanel1.Controls.Add(Me.Cancel_Button, 1, 0)
        Me.CNetHelpProvider.SetHelpKeyword(Me.TableLayoutPanel1, "Dev++_Form_frmAddGroup.htm#frmAddGroup_TableLayoutPanel1")
        Me.CNetHelpProvider.SetHelpNavigator(Me.TableLayoutPanel1, System.Windows.Forms.HelpNavigator.Topic)
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(192, 0)
        Me.TableLayoutPanel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 1
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.CNetHelpProvider.SetShowHelp(Me.TableLayoutPanel1, True)
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(195, 36)
        Me.TableLayoutPanel1.TabIndex = 0
        '
        'OK_Button
        '
        Me.OK_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.OK_Button.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.CNetHelpProvider.SetHelpKeyword(Me.OK_Button, "Dev++_Form_frmAddGroup.htm#frmAddGroup_OK_Button")
        Me.CNetHelpProvider.SetHelpNavigator(Me.OK_Button, System.Windows.Forms.HelpNavigator.Topic)
        Me.OK_Button.Location = New System.Drawing.Point(4, 4)
        Me.OK_Button.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.OK_Button.Name = "OK_Button"
        Me.CNetHelpProvider.SetShowHelp(Me.OK_Button, True)
        Me.OK_Button.Size = New System.Drawing.Size(89, 28)
        Me.OK_Button.TabIndex = 0
        Me.OK_Button.Text = "OK"
        Me.OK_Button.UseVisualStyleBackColor = False
        '
        'Cancel_Button
        '
        Me.Cancel_Button.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.Cancel_Button.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.Cancel_Button.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CNetHelpProvider.SetHelpKeyword(Me.Cancel_Button, "Dev++_Form_frmAddGroup.htm#frmAddGroup_Cancel_Button")
        Me.CNetHelpProvider.SetHelpNavigator(Me.Cancel_Button, System.Windows.Forms.HelpNavigator.Topic)
        Me.Cancel_Button.Location = New System.Drawing.Point(101, 4)
        Me.Cancel_Button.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.CNetHelpProvider.SetShowHelp(Me.Cancel_Button, True)
        Me.Cancel_Button.Size = New System.Drawing.Size(89, 28)
        Me.Cancel_Button.TabIndex = 1
        Me.Cancel_Button.Text = "Cancel"
        Me.Cancel_Button.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.CNetHelpProvider.SetHelpKeyword(Me.Label1, "Dev++_Form_frmAddGroup.htm#frmAddGroup_Label1")
        Me.CNetHelpProvider.SetHelpNavigator(Me.Label1, System.Windows.Forms.HelpNavigator.Topic)
        Me.Label1.Location = New System.Drawing.Point(16, 98)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.CNetHelpProvider.SetShowHelp(Me.Label1, True)
        Me.Label1.Size = New System.Drawing.Size(87, 17)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Group name"
        '
        'txtGroup
        '
        Me.CNetHelpProvider.SetHelpKeyword(Me.txtGroup, "Dev++_Form_frmAddGroup.htm#frmAddGroup_txtGroup")
        Me.CNetHelpProvider.SetHelpNavigator(Me.txtGroup, System.Windows.Forms.HelpNavigator.Topic)
        Me.txtGroup.Location = New System.Drawing.Point(111, 98)
        Me.txtGroup.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.txtGroup.Name = "txtGroup"
        Me.CNetHelpProvider.SetShowHelp(Me.txtGroup, True)
        Me.txtGroup.Size = New System.Drawing.Size(247, 22)
        Me.txtGroup.TabIndex = 2
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.TableLayoutPanel1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.CNetHelpProvider.SetHelpKeyword(Me.Panel1, "Dev++_Form_frmAddGroup.htm#frmAddGroup_Panel1")
        Me.CNetHelpProvider.SetHelpNavigator(Me.Panel1, System.Windows.Forms.HelpNavigator.Topic)
        Me.Panel1.Location = New System.Drawing.Point(0, 167)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel1.Name = "Panel1"
        Me.CNetHelpProvider.SetShowHelp(Me.Panel1, True)
        Me.Panel1.Size = New System.Drawing.Size(392, 36)
        Me.Panel1.TabIndex = 3
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.SystemColors.Window
        Me.Panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Top
        Me.CNetHelpProvider.SetHelpKeyword(Me.Panel2, "Dev++_Form_frmAddGroup.htm#frmAddGroup_Panel2")
        Me.CNetHelpProvider.SetHelpNavigator(Me.Panel2, System.Windows.Forms.HelpNavigator.Topic)
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel2.Name = "Panel2"
        Me.CNetHelpProvider.SetShowHelp(Me.Panel2, True)
        Me.Panel2.Size = New System.Drawing.Size(392, 59)
        Me.Panel2.TabIndex = 4
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.RoyalBlue
        Me.CNetHelpProvider.SetHelpKeyword(Me.Label2, "Dev++_Form_frmAddGroup.htm#frmAddGroup_Label2")
        Me.CNetHelpProvider.SetHelpNavigator(Me.Label2, System.Windows.Forms.HelpNavigator.Topic)
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.CNetHelpProvider.SetShowHelp(Me.Label2, True)
        Me.Label2.Size = New System.Drawing.Size(388, 55)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "New User Group"
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.DodgerBlue
        Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Top
        Me.CNetHelpProvider.SetHelpKeyword(Me.Panel3, "Dev++_Form_frmAddGroup.htm#frmAddGroup_Panel3")
        Me.CNetHelpProvider.SetHelpNavigator(Me.Panel3, System.Windows.Forms.HelpNavigator.Topic)
        Me.Panel3.Location = New System.Drawing.Point(0, 59)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Panel3.Name = "Panel3"
        Me.CNetHelpProvider.SetShowHelp(Me.Panel3, True)
        Me.Panel3.Size = New System.Drawing.Size(392, 18)
        Me.Panel3.TabIndex = 5
        '
        'CNetHelpProvider
        '
        Me.CNetHelpProvider.HelpNamespace = "Dev++.chm"
        '
        'frmAddGroup
        '
        Me.AcceptButton = Me.OK_Button
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FloralWhite
        Me.CancelButton = Me.Cancel_Button
        Me.ClientSize = New System.Drawing.Size(392, 203)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtGroup)
        Me.Controls.Add(Me.Label1)
        Me.ForeColor = System.Drawing.Color.Teal
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.CNetHelpProvider.SetHelpKeyword(Me, "Dev++_Form_frmAddGroup.htm")
        Me.CNetHelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.Topic)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddGroup"
        Me.CNetHelpProvider.SetShowHelp(Me, True)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Add Group"
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents OK_Button As System.Windows.Forms.Button
    Friend WithEvents Cancel_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtGroup As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents CNetHelpProvider As System.Windows.Forms.HelpProvider

End Class
