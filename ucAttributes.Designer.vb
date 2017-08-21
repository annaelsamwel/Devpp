Namespace UserControls
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ucAttributes
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
            Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
            Me.cmbAttrType = New System.Windows.Forms.ComboBox()
            Me.grvAttributes = New System.Windows.Forms.DataGridView()
            Me.txtFilter = New System.Windows.Forms.TextBox()
            Me.pnlCode = New System.Windows.Forms.Panel()
            Me.lblCode = New System.Windows.Forms.Label()
            Me.txtCode = New System.Windows.Forms.TextBox()
            Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
            CType(Me.grvAttributes, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.pnlCode.SuspendLayout()
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SplitContainer1.Panel1.SuspendLayout()
            Me.SplitContainer1.Panel2.SuspendLayout()
            Me.SplitContainer1.SuspendLayout()
            Me.SuspendLayout()
            '
            'cmbAttrType
            '
            Me.cmbAttrType.DisplayMember = "AttrTypeDescription"
            Me.cmbAttrType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbAttrType.FormattingEnabled = True
            Me.cmbAttrType.Location = New System.Drawing.Point(3, 13)
            Me.cmbAttrType.Name = "cmbAttrType"
            Me.cmbAttrType.Size = New System.Drawing.Size(212, 21)
            Me.cmbAttrType.TabIndex = 0
            Me.cmbAttrType.ValueMember = "AttrTypeDescription"
            '
            'grvAttributes
            '
            Me.grvAttributes.AllowUserToResizeRows = False
            DataGridViewCellStyle1.BackColor = System.Drawing.Color.Tan
            Me.grvAttributes.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
            Me.grvAttributes.BackgroundColor = System.Drawing.Color.White
            Me.grvAttributes.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.grvAttributes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
            Me.grvAttributes.Dock = System.Windows.Forms.DockStyle.Fill
            Me.grvAttributes.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke
            Me.grvAttributes.GridColor = System.Drawing.SystemColors.ActiveCaption
            Me.grvAttributes.Location = New System.Drawing.Point(0, 0)
            Me.grvAttributes.Name = "grvAttributes"
            DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Info
            DataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black
            DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.Teal
            Me.grvAttributes.RowsDefaultCellStyle = DataGridViewCellStyle2
            Me.grvAttributes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
            Me.grvAttributes.Size = New System.Drawing.Size(688, 400)
            Me.grvAttributes.TabIndex = 1
            '
            'txtFilter
            '
            Me.txtFilter.Location = New System.Drawing.Point(225, 13)
            Me.txtFilter.Name = "txtFilter"
            Me.txtFilter.Size = New System.Drawing.Size(265, 20)
            Me.txtFilter.TabIndex = 2
            '
            'pnlCode
            '
            Me.pnlCode.Controls.Add(Me.lblCode)
            Me.pnlCode.Controls.Add(Me.txtCode)
            Me.pnlCode.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.pnlCode.Location = New System.Drawing.Point(0, 447)
            Me.pnlCode.Name = "pnlCode"
            Me.pnlCode.Size = New System.Drawing.Size(688, 34)
            Me.pnlCode.TabIndex = 3
            Me.pnlCode.Visible = False
            '
            'lblCode
            '
            Me.lblCode.AutoSize = True
            Me.lblCode.Location = New System.Drawing.Point(10, 10)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(32, 13)
            Me.lblCode.TabIndex = 1
            Me.lblCode.Text = "Code"
            '
            'txtCode
            '
            Me.txtCode.Location = New System.Drawing.Point(55, 7)
            Me.txtCode.Name = "txtCode"
            Me.txtCode.Size = New System.Drawing.Size(100, 20)
            Me.txtCode.TabIndex = 0
            '
            'SplitContainer1
            '
            Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
            Me.SplitContainer1.IsSplitterFixed = True
            Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
            Me.SplitContainer1.Name = "SplitContainer1"
            Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
            '
            'SplitContainer1.Panel1
            '
            Me.SplitContainer1.Panel1.Controls.Add(Me.txtFilter)
            Me.SplitContainer1.Panel1.Controls.Add(Me.cmbAttrType)
            '
            'SplitContainer1.Panel2
            '
            Me.SplitContainer1.Panel2.Controls.Add(Me.grvAttributes)
            Me.SplitContainer1.Size = New System.Drawing.Size(688, 447)
            Me.SplitContainer1.SplitterDistance = 43
            Me.SplitContainer1.TabIndex = 4
            '
            'ucAttributes
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.Controls.Add(Me.SplitContainer1)
            Me.Controls.Add(Me.pnlCode)
            Me.Name = "ucAttributes"
            Me.Size = New System.Drawing.Size(688, 481)
            CType(Me.grvAttributes, System.ComponentModel.ISupportInitialize).EndInit()
            Me.pnlCode.ResumeLayout(False)
            Me.pnlCode.PerformLayout()
            Me.SplitContainer1.Panel1.ResumeLayout(False)
            Me.SplitContainer1.Panel1.PerformLayout()
            Me.SplitContainer1.Panel2.ResumeLayout(False)
            CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.SplitContainer1.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents cmbAttrType As System.Windows.Forms.ComboBox
        Friend WithEvents grvAttributes As System.Windows.Forms.DataGridView
        Friend WithEvents txtFilter As System.Windows.Forms.TextBox
        Friend WithEvents pnlCode As System.Windows.Forms.Panel
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer

    End Class
End Namespace