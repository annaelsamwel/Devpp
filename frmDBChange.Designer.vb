<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDBChange
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
        Me.txtDatabaseName = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnOk = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.CNetHelpProvider = New System.Windows.Forms.HelpProvider
        Me.SuspendLayout()
        '
        'txtDatabaseName
        '
        Me.CNetHelpProvider.SetHelpKeyword(Me.txtDatabaseName, "Dev++_Form_frmDBChange.htm#frmDBChange_txtDatabaseName")
        Me.CNetHelpProvider.SetHelpNavigator(Me.txtDatabaseName, System.Windows.Forms.HelpNavigator.Topic)
        Me.txtDatabaseName.Location = New System.Drawing.Point(94, 97)
        Me.txtDatabaseName.Name = "txtDatabaseName"
        Me.CNetHelpProvider.SetShowHelp(Me.txtDatabaseName, True)
        Me.txtDatabaseName.Size = New System.Drawing.Size(216, 20)
        Me.txtDatabaseName.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.CNetHelpProvider.SetHelpKeyword(Me.Label1, "Dev++_Form_frmDBChange.htm#frmDBChange_Label1")
        Me.CNetHelpProvider.SetHelpNavigator(Me.Label1, System.Windows.Forms.HelpNavigator.Topic)
        Me.Label1.Location = New System.Drawing.Point(3, 100)
        Me.Label1.Name = "Label1"
        Me.CNetHelpProvider.SetShowHelp(Me.Label1, True)
        Me.Label1.Size = New System.Drawing.Size(85, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Database name:"
        '
        'btnOk
        '
        Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.CNetHelpProvider.SetHelpKeyword(Me.btnOk, "Dev++_Form_frmDBChange.htm#frmDBChange_btnOk")
        Me.CNetHelpProvider.SetHelpNavigator(Me.btnOk, System.Windows.Forms.HelpNavigator.Topic)
        Me.btnOk.Location = New System.Drawing.Point(143, 162)
        Me.btnOk.Name = "btnOk"
        Me.CNetHelpProvider.SetShowHelp(Me.btnOk, True)
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 2
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CNetHelpProvider.SetHelpKeyword(Me.btnCancel, "Dev++_Form_frmDBChange.htm#frmDBChange_btnCancel")
        Me.CNetHelpProvider.SetHelpNavigator(Me.btnCancel, System.Windows.Forms.HelpNavigator.Topic)
        Me.btnCancel.Location = New System.Drawing.Point(235, 163)
        Me.btnCancel.Name = "btnCancel"
        Me.CNetHelpProvider.SetShowHelp(Me.btnCancel, True)
        Me.btnCancel.Size = New System.Drawing.Size(75, 23)
        Me.btnCancel.TabIndex = 3
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.SystemColors.Window
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.CornflowerBlue
        Me.CNetHelpProvider.SetHelpKeyword(Me.Label2, "Dev++_Form_frmDBChange.htm#frmDBChange_Label2")
        Me.CNetHelpProvider.SetHelpNavigator(Me.Label2, System.Windows.Forms.HelpNavigator.Topic)
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.CNetHelpProvider.SetShowHelp(Me.Label2, True)
        Me.Label2.Size = New System.Drawing.Size(322, 52)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Change Database Name"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.DodgerBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.CNetHelpProvider.SetHelpKeyword(Me.Panel1, "Dev++_Form_frmDBChange.htm#frmDBChange_Panel1")
        Me.CNetHelpProvider.SetHelpNavigator(Me.Panel1, System.Windows.Forms.HelpNavigator.Topic)
        Me.Panel1.Location = New System.Drawing.Point(0, 52)
        Me.Panel1.Name = "Panel1"
        Me.CNetHelpProvider.SetShowHelp(Me.Panel1, True)
        Me.Panel1.Size = New System.Drawing.Size(322, 16)
        Me.Panel1.TabIndex = 5
        '
        'CNetHelpProvider
        '
        Me.CNetHelpProvider.HelpNamespace = "Dev++.chm"
        '
        'frmDBChange
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.LightSteelBlue
        Me.ClientSize = New System.Drawing.Size(322, 191)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOk)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDatabaseName)
        Me.ForeColor = System.Drawing.Color.Teal
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.CNetHelpProvider.SetHelpKeyword(Me, "Dev++_Form_frmDBChange.htm")
        Me.CNetHelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.Topic)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDBChange"
        Me.CNetHelpProvider.SetShowHelp(Me, True)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Change database name"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtDatabaseName As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnOk As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents CNetHelpProvider As System.Windows.Forms.HelpProvider

End Class
