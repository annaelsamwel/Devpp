<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRestartServer
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
        Me.stBar = New System.Windows.Forms.ProgressBar
        Me.lblService = New System.Windows.Forms.Label
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.CNetHelpProvider = New System.Windows.Forms.HelpProvider
        Me.SuspendLayout()
        '
        'stBar
        '
        Me.CNetHelpProvider.SetHelpKeyword(Me.stBar, "Dev++_Form_frmRestartServer.htm#frmRestartServer_stBar")
        Me.CNetHelpProvider.SetHelpNavigator(Me.stBar, System.Windows.Forms.HelpNavigator.Topic)
        Me.stBar.Location = New System.Drawing.Point(12, 39)
        Me.stBar.Name = "stBar"
        Me.CNetHelpProvider.SetShowHelp(Me.stBar, True)
        Me.stBar.Size = New System.Drawing.Size(543, 23)
        Me.stBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.stBar.TabIndex = 0
        '
        'lblService
        '
        Me.CNetHelpProvider.SetHelpKeyword(Me.lblService, "Dev++_Form_frmRestartServer.htm#frmRestartServer_lblService")
        Me.CNetHelpProvider.SetHelpNavigator(Me.lblService, System.Windows.Forms.HelpNavigator.Topic)
        Me.lblService.Location = New System.Drawing.Point(13, 11)
        Me.lblService.Name = "lblService"
        Me.CNetHelpProvider.SetShowHelp(Me.lblService, True)
        Me.lblService.Size = New System.Drawing.Size(542, 24)
        Me.lblService.TabIndex = 1
        '
        'Timer1
        '
        '
        'CNetHelpProvider
        '
        Me.CNetHelpProvider.HelpNamespace = "Dev++.chm"
        '
        'frmRestartServer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(577, 68)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblService)
        Me.Controls.Add(Me.stBar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.CNetHelpProvider.SetHelpKeyword(Me, "Dev++_Form_frmRestartServer.htm")
        Me.CNetHelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.Topic)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmRestartServer"
        Me.CNetHelpProvider.SetShowHelp(Me, True)
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Restart Server"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents stBar As System.Windows.Forms.ProgressBar
    Friend WithEvents lblService As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents CNetHelpProvider As System.Windows.Forms.HelpProvider

End Class
