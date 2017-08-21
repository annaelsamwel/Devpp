<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucLicenseInfo
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Me.grpLicenseInfo = New System.Windows.Forms.GroupBox
        Me.lblEmployeeCount = New System.Windows.Forms.Label
        Me.lblDueDate = New System.Windows.Forms.Label
        Me.lblLicensedEmployees = New System.Windows.Forms.Label
        Me.lblLicenseNumber = New System.Windows.Forms.Label
        Me.lblAssets = New System.Windows.Forms.RadioButton
        Me.lblTimeSheets = New System.Windows.Forms.RadioButton
        Me.lblHumanResource = New System.Windows.Forms.RadioButton
        Me.lblPayRoll = New System.Windows.Forms.RadioButton
        Me.lblStockTransfer = New System.Windows.Forms.RadioButton
        Me.lblInventory = New System.Windows.Forms.RadioButton
        Me.lblSales = New System.Windows.Forms.RadioButton
        Me.lblAccounts = New System.Windows.Forms.RadioButton
        Me.grpLicenseInfo.SuspendLayout()
        Me.SuspendLayout()
        '
        'grpLicenseInfo
        '
        Me.grpLicenseInfo.Controls.Add(Me.lblEmployeeCount)
        Me.grpLicenseInfo.Controls.Add(Me.lblDueDate)
        Me.grpLicenseInfo.Controls.Add(Me.lblLicensedEmployees)
        Me.grpLicenseInfo.Controls.Add(Me.lblLicenseNumber)
        Me.grpLicenseInfo.Controls.Add(Me.lblAssets)
        Me.grpLicenseInfo.Controls.Add(Me.lblTimeSheets)
        Me.grpLicenseInfo.Controls.Add(Me.lblHumanResource)
        Me.grpLicenseInfo.Controls.Add(Me.lblPayRoll)
        Me.grpLicenseInfo.Controls.Add(Me.lblStockTransfer)
        Me.grpLicenseInfo.Controls.Add(Me.lblInventory)
        Me.grpLicenseInfo.Controls.Add(Me.lblSales)
        Me.grpLicenseInfo.Controls.Add(Me.lblAccounts)
        Me.grpLicenseInfo.Location = New System.Drawing.Point(3, 3)
        Me.grpLicenseInfo.Name = "grpLicenseInfo"
        Me.grpLicenseInfo.Size = New System.Drawing.Size(358, 180)
        Me.grpLicenseInfo.TabIndex = 0
        Me.grpLicenseInfo.TabStop = False
        Me.grpLicenseInfo.Text = "License Info"
        '
        'lblEmployeeCount
        '
        Me.lblEmployeeCount.AutoSize = True
        Me.lblEmployeeCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmployeeCount.Location = New System.Drawing.Point(247, 156)
        Me.lblEmployeeCount.Name = "lblEmployeeCount"
        Me.lblEmployeeCount.Size = New System.Drawing.Size(45, 13)
        Me.lblEmployeeCount.TabIndex = 11
        Me.lblEmployeeCount.Text = "Label1"
        '
        'lblDueDate
        '
        Me.lblDueDate.AutoSize = True
        Me.lblDueDate.Location = New System.Drawing.Point(22, 156)
        Me.lblDueDate.Name = "lblDueDate"
        Me.lblDueDate.Size = New System.Drawing.Size(98, 13)
        Me.lblDueDate.TabIndex = 10
        Me.lblDueDate.Text = "License due date : "
        '
        'lblLicensedEmployees
        '
        Me.lblLicensedEmployees.AutoSize = True
        Me.lblLicensedEmployees.Location = New System.Drawing.Point(222, 133)
        Me.lblLicensedEmployees.Name = "lblLicensedEmployees"
        Me.lblLicensedEmployees.Size = New System.Drawing.Size(103, 13)
        Me.lblLicensedEmployees.TabIndex = 9
        Me.lblLicensedEmployees.Text = "Licensed employees"
        '
        'lblLicenseNumber
        '
        Me.lblLicenseNumber.AutoSize = True
        Me.lblLicenseNumber.Location = New System.Drawing.Point(22, 133)
        Me.lblLicenseNumber.Name = "lblLicenseNumber"
        Me.lblLicenseNumber.Size = New System.Drawing.Size(91, 13)
        Me.lblLicenseNumber.TabIndex = 8
        Me.lblLicenseNumber.Text = "License number : "
        '
        'lblAssets
        '
        Me.lblAssets.AutoCheck = False
        Me.lblAssets.AutoSize = True
        Me.lblAssets.Location = New System.Drawing.Point(225, 95)
        Me.lblAssets.Name = "lblAssets"
        Me.lblAssets.Size = New System.Drawing.Size(56, 17)
        Me.lblAssets.TabIndex = 7
        Me.lblAssets.Text = "Assets"
        Me.lblAssets.UseVisualStyleBackColor = True
        '
        'lblTimeSheets
        '
        Me.lblTimeSheets.AutoCheck = False
        Me.lblTimeSheets.AutoSize = True
        Me.lblTimeSheets.Location = New System.Drawing.Point(225, 72)
        Me.lblTimeSheets.Name = "lblTimeSheets"
        Me.lblTimeSheets.Size = New System.Drawing.Size(79, 17)
        Me.lblTimeSheets.TabIndex = 6
        Me.lblTimeSheets.Text = "Timesheets"
        Me.lblTimeSheets.UseVisualStyleBackColor = True
        '
        'lblHumanResource
        '
        Me.lblHumanResource.AutoCheck = False
        Me.lblHumanResource.AutoSize = True
        Me.lblHumanResource.Location = New System.Drawing.Point(225, 49)
        Me.lblHumanResource.Name = "lblHumanResource"
        Me.lblHumanResource.Size = New System.Drawing.Size(113, 17)
        Me.lblHumanResource.TabIndex = 5
        Me.lblHumanResource.Text = "Human Resources"
        Me.lblHumanResource.UseVisualStyleBackColor = True
        '
        'lblPayRoll
        '
        Me.lblPayRoll.AutoCheck = False
        Me.lblPayRoll.AutoSize = True
        Me.lblPayRoll.Location = New System.Drawing.Point(225, 26)
        Me.lblPayRoll.Name = "lblPayRoll"
        Me.lblPayRoll.Size = New System.Drawing.Size(56, 17)
        Me.lblPayRoll.TabIndex = 4
        Me.lblPayRoll.Text = "Payroll"
        Me.lblPayRoll.UseVisualStyleBackColor = True
        '
        'lblStockTransfer
        '
        Me.lblStockTransfer.AutoCheck = False
        Me.lblStockTransfer.AutoSize = True
        Me.lblStockTransfer.Location = New System.Drawing.Point(24, 95)
        Me.lblStockTransfer.Name = "lblStockTransfer"
        Me.lblStockTransfer.Size = New System.Drawing.Size(95, 17)
        Me.lblStockTransfer.TabIndex = 3
        Me.lblStockTransfer.Text = "Stock Transfer"
        Me.lblStockTransfer.UseVisualStyleBackColor = True
        '
        'lblInventory
        '
        Me.lblInventory.AutoCheck = False
        Me.lblInventory.AutoSize = True
        Me.lblInventory.Location = New System.Drawing.Point(24, 72)
        Me.lblInventory.Name = "lblInventory"
        Me.lblInventory.Size = New System.Drawing.Size(69, 17)
        Me.lblInventory.TabIndex = 2
        Me.lblInventory.Text = "Inventory"
        Me.lblInventory.UseVisualStyleBackColor = True
        '
        'lblSales
        '
        Me.lblSales.AutoCheck = False
        Me.lblSales.AutoSize = True
        Me.lblSales.Location = New System.Drawing.Point(24, 49)
        Me.lblSales.Name = "lblSales"
        Me.lblSales.Size = New System.Drawing.Size(78, 17)
        Me.lblSales.TabIndex = 1
        Me.lblSales.Text = "Sales/POS"
        Me.lblSales.UseVisualStyleBackColor = True
        '
        'lblAccounts
        '
        Me.lblAccounts.AutoCheck = False
        Me.lblAccounts.AutoSize = True
        Me.lblAccounts.Location = New System.Drawing.Point(24, 26)
        Me.lblAccounts.Name = "lblAccounts"
        Me.lblAccounts.Size = New System.Drawing.Size(70, 17)
        Me.lblAccounts.TabIndex = 0
        Me.lblAccounts.Text = "Accounts"
        Me.lblAccounts.UseVisualStyleBackColor = True
        '
        'ucLicenseInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.grpLicenseInfo)
        Me.Name = "ucLicenseInfo"
        Me.Size = New System.Drawing.Size(368, 192)
        Me.grpLicenseInfo.ResumeLayout(False)
        Me.grpLicenseInfo.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpLicenseInfo As System.Windows.Forms.GroupBox
    Friend WithEvents lblStockTransfer As System.Windows.Forms.RadioButton
    Friend WithEvents lblInventory As System.Windows.Forms.RadioButton
    Friend WithEvents lblSales As System.Windows.Forms.RadioButton
    Friend WithEvents lblAccounts As System.Windows.Forms.RadioButton
    Friend WithEvents lblDueDate As System.Windows.Forms.Label
    Friend WithEvents lblLicensedEmployees As System.Windows.Forms.Label
    Friend WithEvents lblLicenseNumber As System.Windows.Forms.Label
    Friend WithEvents lblAssets As System.Windows.Forms.RadioButton
    Friend WithEvents lblTimeSheets As System.Windows.Forms.RadioButton
    Friend WithEvents lblHumanResource As System.Windows.Forms.RadioButton
    Friend WithEvents lblPayRoll As System.Windows.Forms.RadioButton
    Friend WithEvents lblEmployeeCount As System.Windows.Forms.Label

End Class
