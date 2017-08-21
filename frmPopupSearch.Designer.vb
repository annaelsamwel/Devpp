<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPopupSearch
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.grvFound = New System.Windows.Forms.DataGridView
        Me.chkSel = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.lblSearch = New System.Windows.Forms.Label
        Me.PanelCheckbox = New System.Windows.Forms.Panel
        Me.chkSortByChecked = New System.Windows.Forms.CheckBox
        Me.btnClear = New System.Windows.Forms.Button
        Me.btnFilterChecked = New System.Windows.Forms.Button
        Me.chkAll = New System.Windows.Forms.CheckBox
        Me.PanelOK = New System.Windows.Forms.Panel
        CType(Me.grvFound, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.PanelCheckbox.SuspendLayout()
        Me.PanelOK.SuspendLayout()
        Me.SuspendLayout()
        '
        'grvFound
        '
        Me.grvFound.AllowUserToAddRows = False
        Me.grvFound.AllowUserToDeleteRows = False
        Me.grvFound.BackgroundColor = System.Drawing.Color.White
        Me.grvFound.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.grvFound.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleVertical
        Me.grvFound.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grvFound.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.chkSel})
        Me.grvFound.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grvFound.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.grvFound.Location = New System.Drawing.Point(0, 47)
        Me.grvFound.MultiSelect = False
        Me.grvFound.Name = "grvFound"
        Me.grvFound.RowHeadersWidth = 20
        Me.grvFound.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect
        Me.grvFound.Size = New System.Drawing.Size(293, 184)
        Me.grvFound.StandardTab = True
        Me.grvFound.TabIndex = 3
        '
        'chkSel
        '
        Me.chkSel.HeaderText = "Sel"
        Me.chkSel.Name = "chkSel"
        Me.chkSel.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.chkSel.Visible = False
        Me.chkSel.Width = 25
        '
        'btnOK
        '
        Me.btnOK.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.btnOK.Location = New System.Drawing.Point(0, 159)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.Size = New System.Drawing.Size(33, 25)
        Me.btnOK.TabIndex = 4
        Me.btnOK.Text = "Ok"
        Me.btnOK.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(151, 95)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(43, 48)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Panel1.Controls.Add(Me.lblSearch)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(326, 22)
        Me.Panel1.TabIndex = 6
        Me.Panel1.Visible = False
        '
        'lblSearch
        '
        Me.lblSearch.AutoSize = True
        Me.lblSearch.Location = New System.Drawing.Point(3, 5)
        Me.lblSearch.Name = "lblSearch"
        Me.lblSearch.Size = New System.Drawing.Size(0, 13)
        Me.lblSearch.TabIndex = 0
        '
        'PanelCheckbox
        '
        Me.PanelCheckbox.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PanelCheckbox.Controls.Add(Me.chkSortByChecked)
        Me.PanelCheckbox.Controls.Add(Me.btnClear)
        Me.PanelCheckbox.Controls.Add(Me.btnFilterChecked)
        Me.PanelCheckbox.Controls.Add(Me.chkAll)
        Me.PanelCheckbox.Dock = System.Windows.Forms.DockStyle.Top
        Me.PanelCheckbox.Location = New System.Drawing.Point(0, 22)
        Me.PanelCheckbox.Name = "PanelCheckbox"
        Me.PanelCheckbox.Size = New System.Drawing.Size(326, 25)
        Me.PanelCheckbox.TabIndex = 7
        '
        'chkSortByChecked
        '
        Me.chkSortByChecked.AutoSize = True
        Me.chkSortByChecked.Location = New System.Drawing.Point(87, 4)
        Me.chkSortByChecked.Name = "chkSortByChecked"
        Me.chkSortByChecked.Size = New System.Drawing.Size(104, 17)
        Me.chkSortByChecked.TabIndex = 5
        Me.chkSortByChecked.Text = "Sort by checked"
        Me.chkSortByChecked.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.Lavender
        Me.btnClear.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Location = New System.Drawing.Point(266, 0)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(60, 25)
        Me.btnClear.TabIndex = 2
        Me.btnClear.Text = "Show All"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'btnFilterChecked
        '
        Me.btnFilterChecked.BackColor = System.Drawing.Color.Lavender
        Me.btnFilterChecked.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFilterChecked.Location = New System.Drawing.Point(219, 3)
        Me.btnFilterChecked.Name = "btnFilterChecked"
        Me.btnFilterChecked.Size = New System.Drawing.Size(10, 16)
        Me.btnFilterChecked.TabIndex = 1
        Me.btnFilterChecked.Text = "Auto Sort"
        Me.btnFilterChecked.UseVisualStyleBackColor = False
        Me.btnFilterChecked.Visible = False
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.Location = New System.Drawing.Point(5, 4)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(70, 17)
        Me.chkAll.TabIndex = 0
        Me.chkAll.Text = "Check all"
        Me.chkAll.UseVisualStyleBackColor = True
        '
        'PanelOK
        '
        Me.PanelOK.BackColor = System.Drawing.Color.WhiteSmoke
        Me.PanelOK.Controls.Add(Me.btnOK)
        Me.PanelOK.Dock = System.Windows.Forms.DockStyle.Right
        Me.PanelOK.Location = New System.Drawing.Point(293, 47)
        Me.PanelOK.Name = "PanelOK"
        Me.PanelOK.Size = New System.Drawing.Size(33, 184)
        Me.PanelOK.TabIndex = 8
        '
        'frmPopupSearch
        '
        Me.AcceptButton = Me.btnOK
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(326, 231)
        Me.Controls.Add(Me.grvFound)
        Me.Controls.Add(Me.PanelOK)
        Me.Controls.Add(Me.PanelCheckbox)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnCancel)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmPopupSearch"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Search"
        CType(Me.grvFound, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.PanelCheckbox.ResumeLayout(False)
        Me.PanelCheckbox.PerformLayout()
        Me.PanelOK.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grvFound As System.Windows.Forms.DataGridView
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lblSearch As System.Windows.Forms.Label
    Friend WithEvents PanelCheckbox As System.Windows.Forms.Panel
    Friend WithEvents chkAll As System.Windows.Forms.CheckBox
    Friend WithEvents btnFilterChecked As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents chkSel As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents chkSortByChecked As System.Windows.Forms.CheckBox
    Friend WithEvents PanelOK As System.Windows.Forms.Panel
End Class
