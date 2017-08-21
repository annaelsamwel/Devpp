
Namespace Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmRightManagement
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
            Me.Panel3 = New System.Windows.Forms.Panel
            Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
            Me.btnCancel = New System.Windows.Forms.Button
            Me.btnOK = New System.Windows.Forms.Button
            Me.Button1 = New System.Windows.Forms.Button
            Me.TabRightManagement = New System.Windows.Forms.TabControl
            Me.TabPage1 = New System.Windows.Forms.TabPage
            Me.TabPage2 = New System.Windows.Forms.TabPage
            Me.CNetHelpProvider = New System.Windows.Forms.HelpProvider
            Me.Panel3.SuspendLayout()
            Me.TableLayoutPanel1.SuspendLayout()
            Me.TabRightManagement.SuspendLayout()
            Me.SuspendLayout()
            '
            'Panel3
            '
            Me.Panel3.BackColor = System.Drawing.Color.LightSteelBlue
            Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel3.Controls.Add(Me.TableLayoutPanel1)
            Me.Panel3.Controls.Add(Me.Button1)
            Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.CNetHelpProvider.SetHelpKeyword(Me.Panel3, "Dev++_Form_frmRightManagement.htm#frmRightManagement_Panel3")
            Me.CNetHelpProvider.SetHelpNavigator(Me.Panel3, System.Windows.Forms.HelpNavigator.Topic)
            Me.Panel3.Location = New System.Drawing.Point(0, 470)
            Me.Panel3.Name = "Panel3"
            Me.CNetHelpProvider.SetShowHelp(Me.Panel3, True)
            Me.Panel3.Size = New System.Drawing.Size(653, 32)
            Me.Panel3.TabIndex = 2
            '
            'TableLayoutPanel1
            '
            Me.TableLayoutPanel1.ColumnCount = 2
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.TableLayoutPanel1.Controls.Add(Me.btnCancel, 1, 0)
            Me.TableLayoutPanel1.Controls.Add(Me.btnOK, 0, 0)
            Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Right
            Me.CNetHelpProvider.SetHelpKeyword(Me.TableLayoutPanel1, "Dev++_Form_frmRightManagement.htm#frmRightManagement_TableLayoutPanel1")
            Me.CNetHelpProvider.SetHelpNavigator(Me.TableLayoutPanel1, System.Windows.Forms.HelpNavigator.Topic)
            Me.TableLayoutPanel1.Location = New System.Drawing.Point(451, 0)
            Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
            Me.TableLayoutPanel1.RowCount = 1
            Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
            Me.CNetHelpProvider.SetShowHelp(Me.TableLayoutPanel1, True)
            Me.TableLayoutPanel1.Size = New System.Drawing.Size(200, 30)
            Me.TableLayoutPanel1.TabIndex = 3
            '
            'btnCancel
            '
            Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
            Me.CNetHelpProvider.SetHelpKeyword(Me.btnCancel, "Dev++_Form_frmRightManagement.htm#frmRightManagement_btnCancel")
            Me.CNetHelpProvider.SetHelpNavigator(Me.btnCancel, System.Windows.Forms.HelpNavigator.Topic)
            Me.btnCancel.Location = New System.Drawing.Point(103, 3)
            Me.btnCancel.Name = "btnCancel"
            Me.CNetHelpProvider.SetShowHelp(Me.btnCancel, True)
            Me.btnCancel.Size = New System.Drawing.Size(75, 23)
            Me.btnCancel.TabIndex = 1
            Me.btnCancel.Text = "&Close"
            Me.btnCancel.UseVisualStyleBackColor = True
            '
            'btnOK
            '
            Me.btnOK.Enabled = False
            Me.CNetHelpProvider.SetHelpKeyword(Me.btnOK, "Dev++_Form_frmRightManagement.htm#frmRightManagement_btnOK")
            Me.CNetHelpProvider.SetHelpNavigator(Me.btnOK, System.Windows.Forms.HelpNavigator.Topic)
            Me.btnOK.Location = New System.Drawing.Point(3, 3)
            Me.btnOK.Name = "btnOK"
            Me.CNetHelpProvider.SetShowHelp(Me.btnOK, True)
            Me.btnOK.Size = New System.Drawing.Size(75, 23)
            Me.btnOK.TabIndex = 0
            Me.btnOK.Text = "&Save"
            Me.btnOK.UseVisualStyleBackColor = True
            '
            'Button1
            '
            Me.CNetHelpProvider.SetHelpKeyword(Me.Button1, "Dev++_Form_frmRightManagement.htm#frmRightManagement_Button1")
            Me.CNetHelpProvider.SetHelpNavigator(Me.Button1, System.Windows.Forms.HelpNavigator.Topic)
            Me.Button1.Location = New System.Drawing.Point(3, 2)
            Me.Button1.Name = "Button1"
            Me.CNetHelpProvider.SetShowHelp(Me.Button1, True)
            Me.Button1.Size = New System.Drawing.Size(145, 23)
            Me.Button1.TabIndex = 2
            Me.Button1.Text = "&Preview user right"
            Me.Button1.UseVisualStyleBackColor = True
            '
            'TabRightManagement
            '
            Me.TabRightManagement.Controls.Add(Me.TabPage1)
            Me.TabRightManagement.Controls.Add(Me.TabPage2)
            Me.TabRightManagement.Dock = System.Windows.Forms.DockStyle.Fill
            Me.CNetHelpProvider.SetHelpKeyword(Me.TabRightManagement, "Dev++_Form_frmRightManagement.htm#frmRightManagement_TabRightManagement")
            Me.CNetHelpProvider.SetHelpNavigator(Me.TabRightManagement, System.Windows.Forms.HelpNavigator.Topic)
            Me.TabRightManagement.Location = New System.Drawing.Point(0, 0)
            Me.TabRightManagement.Multiline = True
            Me.TabRightManagement.Name = "TabRightManagement"
            Me.TabRightManagement.SelectedIndex = 0
            Me.CNetHelpProvider.SetShowHelp(Me.TabRightManagement, True)
            Me.TabRightManagement.ShowToolTips = True
            Me.TabRightManagement.Size = New System.Drawing.Size(653, 470)
            Me.TabRightManagement.SizeMode = System.Windows.Forms.TabSizeMode.Fixed
            Me.TabRightManagement.TabIndex = 3
            '
            'TabPage1
            '
            Me.TabPage1.BackColor = System.Drawing.Color.White
            Me.TabPage1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.CNetHelpProvider.SetHelpKeyword(Me.TabPage1, "Dev++_Form_frmRightManagement.htm#frmRightManagement_TabPage1_0")
            Me.CNetHelpProvider.SetHelpNavigator(Me.TabPage1, System.Windows.Forms.HelpNavigator.Topic)
            Me.TabPage1.Location = New System.Drawing.Point(4, 22)
            Me.TabPage1.Name = "TabPage1"
            Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
            Me.CNetHelpProvider.SetShowHelp(Me.TabPage1, True)
            Me.TabPage1.Size = New System.Drawing.Size(645, 444)
            Me.TabPage1.TabIndex = 0
            Me.TabPage1.Text = "Users"
            '
            'TabPage2
            '
            Me.TabPage2.BackColor = System.Drawing.Color.White
            Me.TabPage2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.CNetHelpProvider.SetHelpKeyword(Me.TabPage2, "Dev++_Form_frmRightManagement.htm#frmRightManagement_TabPage2_1")
            Me.CNetHelpProvider.SetHelpNavigator(Me.TabPage2, System.Windows.Forms.HelpNavigator.Topic)
            Me.TabPage2.Location = New System.Drawing.Point(4, 22)
            Me.TabPage2.Name = "TabPage2"
            Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
            Me.CNetHelpProvider.SetShowHelp(Me.TabPage2, True)
            Me.TabPage2.Size = New System.Drawing.Size(645, 362)
            Me.TabPage2.TabIndex = 1
            Me.TabPage2.Text = "Groups"
            '
            'CNetHelpProvider
            '
            Me.CNetHelpProvider.HelpNamespace = "Dev++.chm"
            '
            'frmRightManagement
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.WhiteSmoke
            Me.ClientSize = New System.Drawing.Size(653, 502)
            Me.ControlBox = False
            Me.Controls.Add(Me.TabRightManagement)
            Me.Controls.Add(Me.Panel3)
            Me.ForeColor = System.Drawing.Color.Teal
            Me.CNetHelpProvider.SetHelpKeyword(Me, "Dev++_Form_frmRightManagement.htm")
            Me.CNetHelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.Topic)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmRightManagement"
            Me.CNetHelpProvider.SetShowHelp(Me, True)
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
            Me.Text = "Right Management"
            Me.Panel3.ResumeLayout(False)
            Me.TableLayoutPanel1.ResumeLayout(False)
            Me.TabRightManagement.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents btnOK As System.Windows.Forms.Button
        Friend WithEvents btnCancel As System.Windows.Forms.Button
        Friend WithEvents TabRightManagement As System.Windows.Forms.TabControl
        Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
        Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
        Friend WithEvents Button1 As System.Windows.Forms.Button
        Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
        Friend WithEvents CNetHelpProvider As System.Windows.Forms.HelpProvider

    End Class
End Namespace