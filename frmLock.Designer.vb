<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLock
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
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.CNetHelpProvider = New System.Windows.Forms.HelpProvider()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.CNetHelpProvider.SetHelpKeyword(Me.Panel1, "Dev++_Form_frmLock.htm#frmLock_Panel1")
        Me.CNetHelpProvider.SetHelpNavigator(Me.Panel1, System.Windows.Forms.HelpNavigator.Topic)
        Me.Panel1.Location = New System.Drawing.Point(12, 13)
        Me.Panel1.Name = "Panel1"
        Me.CNetHelpProvider.SetShowHelp(Me.Panel1, True)
        Me.Panel1.Size = New System.Drawing.Size(277, 81)
        Me.Panel1.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.CNetHelpProvider.SetHelpKeyword(Me.Label1, "Dev++_Form_frmLock.htm#frmLock_Label1")
        Me.CNetHelpProvider.SetHelpNavigator(Me.Label1, System.Windows.Forms.HelpNavigator.Topic)
        Me.Label1.Location = New System.Drawing.Point(5, 16)
        Me.Label1.Name = "Label1"
        Me.CNetHelpProvider.SetShowHelp(Me.Label1, True)
        Me.Label1.Size = New System.Drawing.Size(56, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Password:"
        '
        'Button1
        '
        Me.CNetHelpProvider.SetHelpKeyword(Me.Button1, "Dev++_Form_frmLock.htm#frmLock_Button1")
        Me.CNetHelpProvider.SetHelpNavigator(Me.Button1, System.Windows.Forms.HelpNavigator.Topic)
        Me.Button1.Location = New System.Drawing.Point(197, 42)
        Me.Button1.Name = "Button1"
        Me.CNetHelpProvider.SetShowHelp(Me.Button1, True)
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "&OK"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.CNetHelpProvider.SetHelpKeyword(Me.TextBox1, "Dev++_Form_frmLock.htm#frmLock_TextBox1")
        Me.CNetHelpProvider.SetHelpNavigator(Me.TextBox1, System.Windows.Forms.HelpNavigator.Topic)
        Me.TextBox1.Location = New System.Drawing.Point(67, 16)
        Me.TextBox1.Name = "TextBox1"
        Me.CNetHelpProvider.SetShowHelp(Me.TextBox1, True)
        Me.TextBox1.Size = New System.Drawing.Size(205, 20)
        Me.TextBox1.TabIndex = 3
        Me.TextBox1.UseSystemPasswordChar = True
        '
        'CNetHelpProvider
        '
        Me.CNetHelpProvider.HelpNamespace = "Dev++.chm"
        '
        'frmLock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(301, 106)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.CNetHelpProvider.SetHelpKeyword(Me, "Dev++_Form_frmLock.htm")
        Me.CNetHelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.Topic)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLock"
        Me.CNetHelpProvider.SetShowHelp(Me, True)
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Unlock"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents CNetHelpProvider As System.Windows.Forms.HelpProvider

End Class
