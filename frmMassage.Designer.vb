<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMassage
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
        Me.btnYes = New System.Windows.Forms.Button
        Me.btnNo = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblTitle = New System.Windows.Forms.Label
        Me.PictureBox1 = New System.Windows.Forms.PictureBox
        Me.lblText = New System.Windows.Forms.Label
        Me.CNetHelpProvider = New System.Windows.Forms.HelpProvider
        Me.Panel1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnYes
        '
        Me.btnYes.DialogResult = System.Windows.Forms.DialogResult.Yes
        Me.CNetHelpProvider.SetHelpKeyword(Me.btnYes, "Dev++_Form_frmMassage.htm#frmMassage_btnYes")
        Me.CNetHelpProvider.SetHelpNavigator(Me.btnYes, System.Windows.Forms.HelpNavigator.Topic)
        Me.btnYes.Location = New System.Drawing.Point(459, 255)
        Me.btnYes.Name = "btnYes"
        Me.CNetHelpProvider.SetShowHelp(Me.btnYes, True)
        Me.btnYes.Size = New System.Drawing.Size(75, 23)
        Me.btnYes.TabIndex = 1
        Me.btnYes.Text = "Yes"
        Me.btnYes.UseVisualStyleBackColor = True
        '
        'btnNo
        '
        Me.btnNo.DialogResult = System.Windows.Forms.DialogResult.No
        Me.CNetHelpProvider.SetHelpKeyword(Me.btnNo, "Dev++_Form_frmMassage.htm#frmMassage_btnNo")
        Me.CNetHelpProvider.SetHelpNavigator(Me.btnNo, System.Windows.Forms.HelpNavigator.Topic)
        Me.btnNo.Location = New System.Drawing.Point(565, 254)
        Me.btnNo.Name = "btnNo"
        Me.CNetHelpProvider.SetShowHelp(Me.btnNo, True)
        Me.btnNo.Size = New System.Drawing.Size(75, 23)
        Me.btnNo.TabIndex = 0
        Me.btnNo.Text = "No"
        Me.btnNo.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.LightSteelBlue
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.lblTitle)
        Me.Panel1.Controls.Add(Me.PictureBox1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.CNetHelpProvider.SetHelpKeyword(Me.Panel1, "Dev++_Form_frmMassage.htm#frmMassage_Panel1")
        Me.CNetHelpProvider.SetHelpNavigator(Me.Panel1, System.Windows.Forms.HelpNavigator.Topic)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.CNetHelpProvider.SetShowHelp(Me.Panel1, True)
        Me.Panel1.Size = New System.Drawing.Size(649, 57)
        Me.Panel1.TabIndex = 2
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CNetHelpProvider.SetHelpKeyword(Me.lblTitle, "Dev++_Form_frmMassage.htm#frmMassage_lblTitle")
        Me.CNetHelpProvider.SetHelpNavigator(Me.lblTitle, System.Windows.Forms.HelpNavigator.Topic)
        Me.lblTitle.Location = New System.Drawing.Point(3, 20)
        Me.lblTitle.Name = "lblTitle"
        Me.CNetHelpProvider.SetShowHelp(Me.lblTitle, True)
        Me.lblTitle.Size = New System.Drawing.Size(0, 17)
        Me.lblTitle.TabIndex = 1
        '
        'PictureBox1
        '
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Right
        Me.CNetHelpProvider.SetHelpKeyword(Me.PictureBox1, "Dev++_Form_frmMassage.htm#frmMassage_PictureBox1")
        Me.CNetHelpProvider.SetHelpNavigator(Me.PictureBox1, System.Windows.Forms.HelpNavigator.Topic)
        Me.PictureBox1.Location = New System.Drawing.Point(580, 0)
        Me.PictureBox1.Name = "PictureBox1"
        Me.CNetHelpProvider.SetShowHelp(Me.PictureBox1, True)
        Me.PictureBox1.Size = New System.Drawing.Size(65, 53)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'lblText
        '
        Me.lblText.BackColor = System.Drawing.Color.Snow
        Me.lblText.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblText.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblText.ForeColor = System.Drawing.Color.Red
        Me.CNetHelpProvider.SetHelpKeyword(Me.lblText, "Dev++_Form_frmMassage.htm#frmMassage_lblText")
        Me.CNetHelpProvider.SetHelpNavigator(Me.lblText, System.Windows.Forms.HelpNavigator.Topic)
        Me.lblText.Location = New System.Drawing.Point(0, 64)
        Me.lblText.Name = "lblText"
        Me.CNetHelpProvider.SetShowHelp(Me.lblText, True)
        Me.lblText.Size = New System.Drawing.Size(649, 183)
        Me.lblText.TabIndex = 3
        '
        'CNetHelpProvider
        '
        Me.CNetHelpProvider.HelpNamespace = "Dev++.chm"
        '
        'frmMassage
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnNo
        Me.ClientSize = New System.Drawing.Size(649, 285)
        Me.ControlBox = False
        Me.Controls.Add(Me.lblText)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnNo)
        Me.Controls.Add(Me.btnYes)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.CNetHelpProvider.SetHelpKeyword(Me, "Dev++_Form_frmMassage.htm")
        Me.CNetHelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.Topic)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmMassage"
        Me.CNetHelpProvider.SetShowHelp(Me, True)
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "  "
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnYes As System.Windows.Forms.Button
    Friend WithEvents btnNo As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblText As System.Windows.Forms.Label
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents CNetHelpProvider As System.Windows.Forms.HelpProvider
End Class
