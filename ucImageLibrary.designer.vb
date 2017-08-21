Namespace UserControls
    <Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
    Partial Class ucImageLibrary
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
            Me.Panel1 = New System.Windows.Forms.Panel
            Me.btnDelete = New System.Windows.Forms.Button
            Me.btnAdd = New System.Windows.Forms.Button
            Me.btnLoad = New System.Windows.Forms.Button
            Me.Panel2 = New System.Windows.Forms.Panel
            Me.PictureBox1 = New System.Windows.Forms.PictureBox
            Me.MenuStrip1 = New System.Windows.Forms.MenuStrip
            Me.ToolStripMenuItem1 = New System.Windows.Forms.ToolStripMenuItem
            Me.Panel6 = New System.Windows.Forms.Panel
            Me.txtSearch = New System.Windows.Forms.TextBox
            Me.Label2 = New System.Windows.Forms.Label
            Me.Panel3 = New System.Windows.Forms.Panel
            Me.lblDescription = New System.Windows.Forms.Label
            Me.Panel5 = New System.Windows.Forms.Panel
            Me.btnOk = New System.Windows.Forms.Button
            Me.lblRecord = New System.Windows.Forms.Label
            Me.btnLast = New System.Windows.Forms.Button
            Me.btnNext = New System.Windows.Forms.Button
            Me.btnPreviouse = New System.Windows.Forms.Button
            Me.btnFirst = New System.Windows.Forms.Button
            Me.Panel4 = New System.Windows.Forms.Panel
            Me.Label1 = New System.Windows.Forms.Label
            Me.Panel1.SuspendLayout()
            Me.Panel2.SuspendLayout()
            CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.MenuStrip1.SuspendLayout()
            Me.Panel6.SuspendLayout()
            Me.Panel3.SuspendLayout()
            Me.Panel5.SuspendLayout()
            Me.Panel4.SuspendLayout()
            Me.SuspendLayout()
            '
            'Panel1
            '
            Me.Panel1.BackColor = System.Drawing.Color.Tan
            Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel1.Controls.Add(Me.btnDelete)
            Me.Panel1.Controls.Add(Me.btnAdd)
            Me.Panel1.Controls.Add(Me.btnLoad)
            Me.Panel1.Dock = System.Windows.Forms.DockStyle.Right
            Me.Panel1.Location = New System.Drawing.Point(355, 27)
            Me.Panel1.Name = "Panel1"
            Me.Panel1.Size = New System.Drawing.Size(62, 312)
            Me.Panel1.TabIndex = 0
            '
            'btnDelete
            '
            Me.btnDelete.Dock = System.Windows.Forms.DockStyle.Top
            Me.btnDelete.Location = New System.Drawing.Point(0, 46)
            Me.btnDelete.Name = "btnDelete"
            Me.btnDelete.Size = New System.Drawing.Size(60, 23)
            Me.btnDelete.TabIndex = 2
            Me.btnDelete.Text = "Delete"
            Me.btnDelete.UseVisualStyleBackColor = True
            '
            'btnAdd
            '
            Me.btnAdd.Dock = System.Windows.Forms.DockStyle.Top
            Me.btnAdd.Location = New System.Drawing.Point(0, 23)
            Me.btnAdd.Name = "btnAdd"
            Me.btnAdd.Size = New System.Drawing.Size(60, 23)
            Me.btnAdd.TabIndex = 1
            Me.btnAdd.Text = "Add"
            Me.btnAdd.UseVisualStyleBackColor = True
            '
            'btnLoad
            '
            Me.btnLoad.Dock = System.Windows.Forms.DockStyle.Top
            Me.btnLoad.Location = New System.Drawing.Point(0, 0)
            Me.btnLoad.Name = "btnLoad"
            Me.btnLoad.Size = New System.Drawing.Size(60, 23)
            Me.btnLoad.TabIndex = 0
            Me.btnLoad.Text = "Load"
            Me.btnLoad.UseVisualStyleBackColor = True
            '
            'Panel2
            '
            Me.Panel2.Controls.Add(Me.PictureBox1)
            Me.Panel2.Controls.Add(Me.MenuStrip1)
            Me.Panel2.Controls.Add(Me.Panel6)
            Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Panel2.Location = New System.Drawing.Point(0, 27)
            Me.Panel2.Name = "Panel2"
            Me.Panel2.Size = New System.Drawing.Size(355, 312)
            Me.Panel2.TabIndex = 1
            '
            'PictureBox1
            '
            Me.PictureBox1.BackColor = System.Drawing.Color.White
            Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
            Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.PictureBox1.Location = New System.Drawing.Point(0, 31)
            Me.PictureBox1.Name = "PictureBox1"
            Me.PictureBox1.Size = New System.Drawing.Size(355, 281)
            Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
            Me.PictureBox1.TabIndex = 2
            Me.PictureBox1.TabStop = False
            '
            'MenuStrip1
            '
            Me.MenuStrip1.Dock = System.Windows.Forms.DockStyle.None
            Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem1})
            Me.MenuStrip1.Location = New System.Drawing.Point(176, 93)
            Me.MenuStrip1.Name = "MenuStrip1"
            Me.MenuStrip1.Size = New System.Drawing.Size(35, 24)
            Me.MenuStrip1.TabIndex = 3
            Me.MenuStrip1.Text = "MenuStrip1"
            '
            'ToolStripMenuItem1
            '
            Me.ToolStripMenuItem1.Name = "ToolStripMenuItem1"
            Me.ToolStripMenuItem1.ShortcutKeys = System.Windows.Forms.Keys.F5
            Me.ToolStripMenuItem1.Size = New System.Drawing.Size(27, 20)
            Me.ToolStripMenuItem1.Text = "rf"
            '
            'Panel6
            '
            Me.Panel6.Controls.Add(Me.txtSearch)
            Me.Panel6.Controls.Add(Me.Label2)
            Me.Panel6.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel6.Location = New System.Drawing.Point(0, 0)
            Me.Panel6.Name = "Panel6"
            Me.Panel6.Size = New System.Drawing.Size(355, 31)
            Me.Panel6.TabIndex = 4
            '
            'txtSearch
            '
            Me.txtSearch.Location = New System.Drawing.Point(55, 6)
            Me.txtSearch.Name = "txtSearch"
            Me.txtSearch.Size = New System.Drawing.Size(294, 20)
            Me.txtSearch.TabIndex = 1
            '
            'Label2
            '
            Me.Label2.AutoSize = True
            Me.Label2.Location = New System.Drawing.Point(6, 10)
            Me.Label2.Name = "Label2"
            Me.Label2.Size = New System.Drawing.Size(44, 13)
            Me.Label2.TabIndex = 0
            Me.Label2.Text = "Search:"
            '
            'Panel3
            '
            Me.Panel3.BackColor = System.Drawing.Color.MediumSeaGreen
            Me.Panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel3.Controls.Add(Me.lblDescription)
            Me.Panel3.Controls.Add(Me.Panel5)
            Me.Panel3.Controls.Add(Me.lblRecord)
            Me.Panel3.Controls.Add(Me.btnLast)
            Me.Panel3.Controls.Add(Me.btnNext)
            Me.Panel3.Controls.Add(Me.btnPreviouse)
            Me.Panel3.Controls.Add(Me.btnFirst)
            Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.Panel3.Location = New System.Drawing.Point(0, 339)
            Me.Panel3.Name = "Panel3"
            Me.Panel3.Size = New System.Drawing.Size(417, 61)
            Me.Panel3.TabIndex = 0
            '
            'lblDescription
            '
            Me.lblDescription.Dock = System.Windows.Forms.DockStyle.Bottom
            Me.lblDescription.Location = New System.Drawing.Point(0, 31)
            Me.lblDescription.Name = "lblDescription"
            Me.lblDescription.Size = New System.Drawing.Size(354, 28)
            Me.lblDescription.TabIndex = 7
            Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'Panel5
            '
            Me.Panel5.Controls.Add(Me.btnOk)
            Me.Panel5.Dock = System.Windows.Forms.DockStyle.Right
            Me.Panel5.Location = New System.Drawing.Point(354, 0)
            Me.Panel5.Name = "Panel5"
            Me.Panel5.Size = New System.Drawing.Size(61, 59)
            Me.Panel5.TabIndex = 6
            '
            'btnOk
            '
            Me.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK
            Me.btnOk.Location = New System.Drawing.Point(2, 6)
            Me.btnOk.Name = "btnOk"
            Me.btnOk.Size = New System.Drawing.Size(57, 23)
            Me.btnOk.TabIndex = 5
            Me.btnOk.Text = "OK"
            Me.btnOk.UseVisualStyleBackColor = True
            '
            'lblRecord
            '
            Me.lblRecord.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.lblRecord.Location = New System.Drawing.Point(111, 5)
            Me.lblRecord.Name = "lblRecord"
            Me.lblRecord.Size = New System.Drawing.Size(111, 23)
            Me.lblRecord.TabIndex = 5
            Me.lblRecord.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnLast
            '
            Me.btnLast.Image = Global.Devpp.My.Resources.Resources.DataContainer_MoveLastHS
            Me.btnLast.Location = New System.Drawing.Point(283, 5)
            Me.btnLast.Name = "btnLast"
            Me.btnLast.Size = New System.Drawing.Size(47, 23)
            Me.btnLast.TabIndex = 3
            Me.btnLast.UseVisualStyleBackColor = True
            '
            'btnNext
            '
            Me.btnNext.Image = Global.Devpp.My.Resources.Resources.DataContainer_MoveNextHS
            Me.btnNext.Location = New System.Drawing.Point(228, 5)
            Me.btnNext.Name = "btnNext"
            Me.btnNext.Size = New System.Drawing.Size(49, 23)
            Me.btnNext.TabIndex = 2
            Me.btnNext.UseVisualStyleBackColor = True
            '
            'btnPreviouse
            '
            Me.btnPreviouse.Image = Global.Devpp.My.Resources.Resources.DataContainer_MovePreviousHS
            Me.btnPreviouse.Location = New System.Drawing.Point(58, 5)
            Me.btnPreviouse.Name = "btnPreviouse"
            Me.btnPreviouse.Size = New System.Drawing.Size(47, 23)
            Me.btnPreviouse.TabIndex = 1
            Me.btnPreviouse.UseVisualStyleBackColor = True
            '
            'btnFirst
            '
            Me.btnFirst.Image = Global.Devpp.My.Resources.Resources.DataContainer_MoveFirstHS
            Me.btnFirst.Location = New System.Drawing.Point(3, 5)
            Me.btnFirst.Name = "btnFirst"
            Me.btnFirst.Size = New System.Drawing.Size(49, 23)
            Me.btnFirst.TabIndex = 0
            Me.btnFirst.UseVisualStyleBackColor = True
            '
            'Panel4
            '
            Me.Panel4.BackColor = System.Drawing.Color.DodgerBlue
            Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Panel4.Controls.Add(Me.Label1)
            Me.Panel4.Dock = System.Windows.Forms.DockStyle.Top
            Me.Panel4.Location = New System.Drawing.Point(0, 0)
            Me.Panel4.Name = "Panel4"
            Me.Panel4.Size = New System.Drawing.Size(417, 27)
            Me.Panel4.TabIndex = 1
            '
            'Label1
            '
            Me.Label1.BackColor = System.Drawing.Color.DarkGreen
            Me.Label1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Ivory
            Me.Label1.Location = New System.Drawing.Point(0, 0)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(415, 25)
            Me.Label1.TabIndex = 0
            Me.Label1.Text = "Photos Library"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'ucImageLibrary
            '
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.BackColor = System.Drawing.Color.WhiteSmoke
            Me.Controls.Add(Me.Panel2)
            Me.Controls.Add(Me.Panel1)
            Me.Controls.Add(Me.Panel3)
            Me.Controls.Add(Me.Panel4)
            Me.Name = "ucImageLibrary"
            Me.Size = New System.Drawing.Size(417, 400)
            Me.Panel1.ResumeLayout(False)
            Me.Panel2.ResumeLayout(False)
            Me.Panel2.PerformLayout()
            CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.MenuStrip1.ResumeLayout(False)
            Me.MenuStrip1.PerformLayout()
            Me.Panel6.ResumeLayout(False)
            Me.Panel6.PerformLayout()
            Me.Panel3.ResumeLayout(False)
            Me.Panel5.ResumeLayout(False)
            Me.Panel4.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
        Friend WithEvents Panel1 As System.Windows.Forms.Panel
        Friend WithEvents Panel2 As System.Windows.Forms.Panel
        Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
        Friend WithEvents Panel4 As System.Windows.Forms.Panel
        Friend WithEvents Panel3 As System.Windows.Forms.Panel
        Friend WithEvents btnDelete As System.Windows.Forms.Button
        Friend WithEvents btnAdd As System.Windows.Forms.Button
        Friend WithEvents btnLoad As System.Windows.Forms.Button
        Friend WithEvents btnLast As System.Windows.Forms.Button
        Friend WithEvents btnNext As System.Windows.Forms.Button
        Friend WithEvents btnPreviouse As System.Windows.Forms.Button
        Friend WithEvents btnFirst As System.Windows.Forms.Button
        Friend WithEvents lblRecord As System.Windows.Forms.Label
        Friend WithEvents Panel5 As System.Windows.Forms.Panel
        Friend WithEvents btnOk As System.Windows.Forms.Button
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
        Friend WithEvents ToolStripMenuItem1 As System.Windows.Forms.ToolStripMenuItem
        Friend WithEvents Panel6 As System.Windows.Forms.Panel
        Friend WithEvents Label2 As System.Windows.Forms.Label
        Friend WithEvents txtSearch As System.Windows.Forms.TextBox
        Friend WithEvents lblDescription As System.Windows.Forms.Label

    End Class
End Namespace

