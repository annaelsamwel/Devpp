<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ucUsers
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ucUsers))
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.rdoBlocked = New System.Windows.Forms.RadioButton()
        Me.rdoActive = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.TreeView2 = New System.Windows.Forms.TreeView()
        Me.ImageList2 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer2)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel2)
        Me.SplitContainer1.Panel2.Controls.Add(Me.Panel1)
        Me.SplitContainer1.Size = New System.Drawing.Size(445, 555)
        Me.SplitContainer1.SplitterDistance = 150
        Me.SplitContainer1.TabIndex = 0
        '
        'SplitContainer2
        '
        Me.SplitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer2.IsSplitterFixed = True
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.BackColor = System.Drawing.Color.Snow
        Me.SplitContainer2.Panel1.Controls.Add(Me.rdoBlocked)
        Me.SplitContainer2.Panel1.Controls.Add(Me.rdoActive)
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.BackColor = System.Drawing.SystemColors.Window
        Me.SplitContainer2.Panel2.Controls.Add(Me.ListBox1)
        Me.SplitContainer2.Panel2.Controls.Add(Me.Label2)
        Me.SplitContainer2.Size = New System.Drawing.Size(150, 555)
        Me.SplitContainer2.SplitterDistance = 99
        Me.SplitContainer2.TabIndex = 0
        '
        'rdoBlocked
        '
        Me.rdoBlocked.AutoSize = True
        Me.rdoBlocked.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoBlocked.ForeColor = System.Drawing.Color.DarkGreen
        Me.rdoBlocked.Location = New System.Drawing.Point(16, 59)
        Me.rdoBlocked.Name = "rdoBlocked"
        Me.rdoBlocked.Size = New System.Drawing.Size(71, 17)
        Me.rdoBlocked.TabIndex = 2
        Me.rdoBlocked.Text = "Blocked"
        Me.rdoBlocked.UseVisualStyleBackColor = True
        '
        'rdoActive
        '
        Me.rdoActive.AutoSize = True
        Me.rdoActive.Checked = True
        Me.rdoActive.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoActive.ForeColor = System.Drawing.Color.DarkGreen
        Me.rdoActive.Location = New System.Drawing.Point(15, 25)
        Me.rdoActive.Name = "rdoActive"
        Me.rdoActive.Size = New System.Drawing.Size(61, 17)
        Me.rdoActive.TabIndex = 1
        Me.rdoActive.TabStop = True
        Me.rdoActive.Text = "Active"
        Me.rdoActive.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(148, 22)
        Me.Label1.TabIndex = 0
        '
        'ListBox1
        '
        Me.ListBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ListBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.ForeColor = System.Drawing.Color.Blue
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 16
        Me.ListBox1.Location = New System.Drawing.Point(0, 22)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(148, 428)
        Me.ListBox1.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label2.Location = New System.Drawing.Point(0, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(148, 22)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Users"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.TreeView2)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(145, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(144, 553)
        Me.Panel2.TabIndex = 4
        '
        'TreeView2
        '
        Me.TreeView2.BackColor = System.Drawing.Color.AliceBlue
        Me.TreeView2.CheckBoxes = True
        Me.TreeView2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeView2.ForeColor = System.Drawing.Color.Olive
        Me.TreeView2.HideSelection = False
        Me.TreeView2.ImageIndex = 0
        Me.TreeView2.ImageList = Me.ImageList2
        Me.TreeView2.Location = New System.Drawing.Point(0, 22)
        Me.TreeView2.Name = "TreeView2"
        Me.TreeView2.SelectedImageIndex = 0
        Me.TreeView2.ShowLines = False
        Me.TreeView2.ShowPlusMinus = False
        Me.TreeView2.ShowRootLines = False
        Me.TreeView2.Size = New System.Drawing.Size(144, 531)
        Me.TreeView2.TabIndex = 3
        '
        'ImageList2
        '
        Me.ImageList2.ImageStream = CType(resources.GetObject("ImageList2.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList2.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList2.Images.SetKeyName(0, "Users.png")
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label4.Location = New System.Drawing.Point(0, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(144, 22)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "User Rights"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TreeView1)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(145, 553)
        Me.Panel1.TabIndex = 3
        '
        'TreeView1
        '
        Me.TreeView1.BackColor = System.Drawing.Color.White
        Me.TreeView1.CheckBoxes = True
        Me.TreeView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TreeView1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TreeView1.ForeColor = System.Drawing.Color.Blue
        Me.TreeView1.ImageIndex = 0
        Me.TreeView1.ImageList = Me.ImageList1
        Me.TreeView1.Location = New System.Drawing.Point(0, 22)
        Me.TreeView1.Name = "TreeView1"
        Me.TreeView1.SelectedImageIndex = 0
        Me.TreeView1.ShowLines = False
        Me.TreeView1.ShowPlusMinus = False
        Me.TreeView1.ShowRootLines = False
        Me.TreeView1.Size = New System.Drawing.Size(145, 531)
        Me.TreeView1.TabIndex = 2
        '
        'ImageList1
        '
        Me.ImageList1.ImageStream = CType(resources.GetObject("ImageList1.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList1.Images.SetKeyName(0, "Group.png")
        '
        'Label3
        '
        Me.Label3.BackColor = System.Drawing.Color.WhiteSmoke
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.DarkGreen
        Me.Label3.Location = New System.Drawing.Point(0, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(145, 22)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Groups"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ucUsers
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.SplitContainer1)
        Me.Name = "ucUsers"
        Me.Size = New System.Drawing.Size(445, 555)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents SplitContainer1 As System.Windows.Forms.SplitContainer
    Friend WithEvents SplitContainer2 As System.Windows.Forms.SplitContainer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents rdoBlocked As System.Windows.Forms.RadioButton
    Friend WithEvents rdoActive As System.Windows.Forms.RadioButton
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents TreeView2 As System.Windows.Forms.TreeView
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ImageList2 As System.Windows.Forms.ImageList

End Class
