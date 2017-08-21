Namespace Forms
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class frmDBUtilities
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
            Me.CNetHelpProvider = New System.Windows.Forms.HelpProvider
            Me.SuspendLayout()
            '
            'CNetHelpProvider
            '
            Me.CNetHelpProvider.HelpNamespace = "Dev++.chm"
            '
            'frmDBUtilities
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(567, 333)
            Me.ControlBox = False
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.CNetHelpProvider.SetHelpKeyword(Me, "Dev++_Form_frmDBUtilities.htm")
            Me.CNetHelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.Topic)
            Me.MaximizeBox = False
            Me.MinimizeBox = False
            Me.Name = "frmDBUtilities"
            Me.CNetHelpProvider.SetShowHelp(Me, True)
            Me.ShowInTaskbar = False
            Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
            Me.Text = "Database utility"
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents CNetHelpProvider As System.Windows.Forms.HelpProvider

    End Class
End Namespace
