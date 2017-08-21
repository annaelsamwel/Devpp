<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmApplicationAttributes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmApplicationAttributes))
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnApply = New System.Windows.Forms.Button
        Me.PropertyGrid1 = New System.Windows.Forms.PropertyGrid
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton
        Me.CNetHelpProvider = New System.Windows.Forms.HelpProvider
        Me.ToolStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CNetHelpProvider.SetHelpKeyword(Me.btnCancel, "Dev++_Form_frmApplicationAttributes.htm#frmApplicationAttributes_btnCancel")
        Me.CNetHelpProvider.SetHelpNavigator(Me.btnCancel, System.Windows.Forms.HelpNavigator.Topic)
        Me.btnCancel.Location = New System.Drawing.Point(100, 307)
        Me.btnCancel.Name = "btnCancel"
        Me.CNetHelpProvider.SetShowHelp(Me.btnCancel, True)
        Me.btnCancel.Size = New System.Drawing.Size(75, 22)
        Me.btnCancel.TabIndex = 8
        Me.btnCancel.Text = "CANCEL"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnApply
        '
        Me.btnApply.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CNetHelpProvider.SetHelpKeyword(Me.btnApply, "Dev++_Form_frmApplicationAttributes.htm#frmApplicationAttributes_btnApply")
        Me.CNetHelpProvider.SetHelpNavigator(Me.btnApply, System.Windows.Forms.HelpNavigator.Topic)
        Me.btnApply.Location = New System.Drawing.Point(212, 307)
        Me.btnApply.Name = "btnApply"
        Me.CNetHelpProvider.SetShowHelp(Me.btnApply, True)
        Me.btnApply.Size = New System.Drawing.Size(75, 22)
        Me.btnApply.TabIndex = 4
        Me.btnApply.Text = "APPLY"
        Me.btnApply.UseVisualStyleBackColor = True
        '
        'PropertyGrid1
        '
        Me.PropertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CNetHelpProvider.SetHelpKeyword(Me.PropertyGrid1, "Dev++_Form_frmApplicationAttributes.htm#frmApplicationAttributes_PropertyGrid1")
        Me.CNetHelpProvider.SetHelpNavigator(Me.PropertyGrid1, System.Windows.Forms.HelpNavigator.Topic)
        Me.PropertyGrid1.Location = New System.Drawing.Point(0, 25)
        Me.PropertyGrid1.Name = "PropertyGrid1"
        Me.CNetHelpProvider.SetShowHelp(Me.PropertyGrid1, True)
        Me.PropertyGrid1.Size = New System.Drawing.Size(328, 316)
        Me.PropertyGrid1.TabIndex = 4
        '
        'ToolStrip1
        '
        Me.CNetHelpProvider.SetHelpKeyword(Me.ToolStrip1, "Dev++_Form_frmApplicationAttributes.htm#frmApplicationAttributes_ToolStrip1")
        Me.CNetHelpProvider.SetHelpNavigator(Me.ToolStrip1, System.Windows.Forms.HelpNavigator.Topic)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripButton1, Me.ToolStripButton2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.CNetHelpProvider.SetShowHelp(Me.ToolStrip1, True)
        Me.ToolStrip1.Size = New System.Drawing.Size(328, 25)
        Me.ToolStrip1.TabIndex = 9
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(38, 22)
        Me.ToolStripButton1.Text = "Apply"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.ToolStripButton2.Image = CType(resources.GetObject("ToolStripButton2.Image"), System.Drawing.Image)
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(43, 22)
        Me.ToolStripButton2.Text = "Cancel"
        '
        'CNetHelpProvider
        '
        Me.CNetHelpProvider.HelpNamespace = "Dev++.chm"
        '
        'frmApplicationAttributes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(328, 341)
        Me.ControlBox = False
        Me.Controls.Add(Me.PropertyGrid1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnApply)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.CNetHelpProvider.SetHelpKeyword(Me, "Dev++_Form_frmApplicationAttributes.htm")
        Me.CNetHelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.Topic)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmApplicationAttributes"
        Me.CNetHelpProvider.SetShowHelp(Me, True)
        Me.ShowInTaskbar = False
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Application Attributes"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnApply As System.Windows.Forms.Button
    Friend WithEvents PropertyGrid1 As System.Windows.Forms.PropertyGrid
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton2 As System.Windows.Forms.ToolStripButton
    Friend WithEvents CNetHelpProvider As System.Windows.Forms.HelpProvider

End Class
