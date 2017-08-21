' ***********************************************************************
' Assembly         : Dev++
' Author           : Annael Samwel
' Created          : 08-18-2014
'
' Last Modified By : user
' Last Modified On : 11-30-2011
' ***********************************************************************
' <copyright file="UserManager.vb" company="Annael">
'     Copyright © Annael 2010
' </copyright>
' <summary></summary>
' ***********************************************************************
''' <summary>
''' The Security namespace.
''' </summary>
Namespace Security
    ''' <summary>
    ''' This class developed by Annael Samwel for Managing users rights
    ''' </summary>
    ''' <remarks></remarks>
    ''' <summary>
    ''' Class UserManager. This class cannot be inherited.
    ''' </summary>
    Friend NotInheritable Class UserManager
        ''' <summary>
        ''' The end v_bool
        ''' </summary>
        Friend Shared EndV_bool As Boolean
        ''' <summary>
        ''' The _list box
        ''' </summary>
        Private WithEvents _listBox As Windows.Forms.ListBox
        ''' <summary>
        ''' The _ treview
        ''' </summary>
        Private WithEvents _Treview As Windows.Forms.TreeView
        ''' <summary>
        ''' The SQL
        ''' </summary>
        Private Const sql As String = "SELECT * FROM [tblDevppUser] WHERE [usrIsGroup] = 1"
        ''' <summary>
        ''' The group right SQL
        ''' </summary>
        Private Const GroupRightSQL As String = "SELECT [UserID] ,[UserSecNr] FROM [tblDevppUserRights]"
        ''' <summary>
        ''' The g right adapter
        ''' </summary>
        Private GRightAdapter As SqlClient.SqlDataAdapter
        ''' <summary>
        ''' The g right data table
        ''' </summary>
        Private WithEvents GRightDataTable As New DataTable
        ''' <summary>
        ''' The g right bigind source
        ''' </summary>
        Private GRightBigindSource As New Windows.Forms.BindingSource
        ''' <summary>
        ''' The _ group binder
        ''' </summary>
        Private WithEvents _GroupBinder As Windows.Forms.BindingSource
        ''' <summary>
        ''' The group data table
        ''' </summary>
        Private WithEvents GroupDataTable As DataTable
        ''' <summary>
        ''' The group adapter
        ''' </summary>
        Private GroupAdapter As SqlClient.SqlDataAdapter
        ''' <summary>
        ''' The parent right data table
        ''' </summary>
        Public Shared ParentRightDataTable As New DataTable
        ''' <summary>
        ''' The child1 right data table
        ''' </summary>
        Public Shared Child1RightDataTable As New DataTable
        ''' <summary>
        ''' The child2 right data table
        ''' </summary>
        Public Shared Child2RightDataTable As New DataTable
        ''' <summary>
        ''' The child3 right data table
        ''' </summary>
        Public Shared Child3RightDataTable As New DataTable
        ''' <summary>
        ''' The bs child1
        ''' </summary>
        Private bsChild1 As New Windows.Forms.BindingSource
        ''' <summary>
        ''' The bs child2
        ''' </summary>
        Private bsChild2 As New Windows.Forms.BindingSource
        ''' <summary>
        ''' The bs child3
        ''' </summary>
        Private bsChild3 As New Windows.Forms.BindingSource
        ''' <summary>
        ''' The menu
        ''' </summary>
        Private menu As Windows.Forms.ContextMenuStrip
        ''' <summary>
        ''' The _ add group
        ''' </summary>
        Private WithEvents _AddGroup As New System.Windows.Forms.ToolStripMenuItem("Add group")
        ''' <summary>
        ''' The _ in activate
        ''' </summary>
        Private WithEvents _InActivate As New System.Windows.Forms.ToolStripMenuItem("In-Activate group")
        ''' <summary>
        ''' The _ activate
        ''' </summary>
        Private WithEvents _Activate As New System.Windows.Forms.ToolStripMenuItem("Activate group")
        ''' <summary>
        ''' The _ save
        ''' </summary>
        Private WithEvents _Save As New System.Windows.Forms.ToolStripMenuItem("Save")
        ''' <summary>
        ''' The _ cancel
        ''' </summary>
        Private WithEvents _Cancel As New System.Windows.Forms.ToolStripMenuItem("Cancel")
        ''' <summary>
        ''' The filter mode
        ''' </summary>
        Private filterMode As Integer = 1
        ''' <summary>
        ''' The allow add
        ''' </summary>
        Private AllowAdd As Boolean = False
        ''' <summary>
        ''' The _ data changed
        ''' </summary>
        Private _DataChanged As Boolean = False
        ''' <summary>
        ''' The adding mode
        ''' </summary>
        Private AddingMode As Boolean = False
        ''' <summary>
        ''' The users
        ''' </summary>
        Public Users As ucUsers
        ''' <summary>
        ''' The is loading
        ''' </summary>
        Private isLoading As Boolean = True
        ''' <summary>
        ''' Occurs when [right checked].
        ''' </summary>
        Public Event RightChecked(ByVal sender As Object, ByVal e As NodeCheckedEventarg)
        ''' <summary>
        ''' Occurs when [on data changed].
        ''' </summary>
        Public Event onDataChanged(ByVal sender As Object, ByVal e As EventArgs)
        ''' <summary>
        ''' Method for loading data from Database
        ''' </summary>
        Public Sub LoadData()
            GRightDataTable.Clear()
            GRightAdapter.Fill(GRightDataTable)
            _GroupBinder.ResetBindings(True)
            _DataChanged = False
        End Sub
        ''' <summary>
        ''' Used to chacke wether data changed
        ''' </summary>
        ''' <value><c>true</c> if [data changed]; otherwise, <c>false</c>.</value>
        Public ReadOnly Property DataChanged() As Boolean
            Get
                Return _DataChanged
            End Get
        End Property
        ''' <summary>
        ''' Initializes a new instance of the <see cref="UserManager"/> class.
        ''' </summary>
        Public Sub New()

            _listBox = New Windows.Forms.ListBox
            _Treview = New Windows.Forms.TreeView
            Dim font As New Drawing.Font(_Treview.Font.FontFamily, 10, Drawing.FontStyle.Regular)
            _listBox.Font = font
            _Treview.Font = font
            _listBox.ForeColor = Drawing.Color.Teal
            _Treview.ForeColor = Drawing.Color.Blue
            Dim imageLst As New Windows.Forms.ImageList
            imageLst.Images.Add(My.Resources.Users)
            _Treview.ImageList = imageLst
            _listBox.Dock = Windows.Forms.DockStyle.Fill
            _Treview.Dock = Windows.Forms.DockStyle.Fill
            _Treview.CheckBoxes = True
            _GroupBinder = New Windows.Forms.BindingSource
            GroupDataTable = New DataTable
            menu = New Windows.Forms.ContextMenuStrip
            Me.bsChild1.DataSource = Child1RightDataTable
            Me.bsChild2.DataSource = Child2RightDataTable
            Me.bsChild3.DataSource = Child3RightDataTable
            initializeReader()
        End Sub
        ''' <summary>
        ''' Used to unchack a tree before chacking
        ''' </summary>
        Private Sub UnchackTree()
            For Each nod As Windows.Forms.TreeNode In _Treview.Nodes
                nod.Checked = False
                For Each nod1 As Windows.Forms.TreeNode In nod.Nodes
                    nod1.Checked = False
                    For Each nod2 As Windows.Forms.TreeNode In nod1.Nodes
                        nod2.Checked = False
                        For Each nod3 As Windows.Forms.TreeNode In nod2.Nodes
                            nod3.Checked = False
                        Next
                    Next
                Next

            Next
        End Sub
        ''' <summary>
        ''' 'Chackes the tree
        ''' </summary>
        Private Sub CheckTree()
            isLoading = True

            For Each dr As DataRowView In GRightBigindSource.List

                Dim V_bool As Boolean = False
                For Each nd As Windows.Forms.TreeNode In _Treview.Nodes
                    If V_bool = True Then Exit For
                    If nd.Name = dr("UserSecNr") Then
                        nd.Checked = True
                        V_bool = True
                        Exit For
                    End If
                    For Each nd1 As Windows.Forms.TreeNode In nd.Nodes
                        If V_bool = True Then Exit For
                        If nd1.Name = dr("UserSecNr") Then
                            nd1.Checked = True
                            V_bool = True
                            Exit For
                        End If
                        For Each nd2 As Windows.Forms.TreeNode In nd1.Nodes
                            If V_bool = True Then Exit For
                            If nd2.Name = dr("UserSecNr") Then
                                nd2.Checked = True
                                V_bool = True
                                Exit For
                            End If
                            For Each nd3 As Windows.Forms.TreeNode In nd2.Nodes
                                If V_bool = True Then Exit For
                                If nd3.Name = dr("UserSecNr") Then
                                    nd3.Checked = True
                                    V_bool = True
                                    Exit For
                                End If
                            Next
                        Next
                    Next
                Next
            Next

            isLoading = False
        End Sub
        ''' <summary>
        ''' Delete rights in memory
        ''' </summary>
        ''' <param name="GroupID">The group identifier.</param>
        ''' <param name="RightID">The right identifier.</param>
        Private Sub RemoveRight(ByVal GroupID As Integer, ByVal RightID As Integer)
            If AllowAdd = False Then Exit Sub
            GRightBigindSource.Filter = "UserID = " & GroupID & "  AND UserSecNr = " & RightID
            If GRightBigindSource.Count > 0 Then
                GRightBigindSource.RemoveCurrent()
                GRightBigindSource.EndEdit()
            End If
        End Sub
        ''' <summary>
        ''' Adding new right in memory
        ''' </summary>
        ''' <param name="GroupID">The group identifier.</param>
        ''' <param name="RightID">The right identifier.</param>
        Private Sub AddRight(ByVal GroupID As Integer, ByVal RightID As Integer)
            If AllowAdd = False Then Exit Sub
            GRightBigindSource.Filter = "UserID = " & GroupID & "  AND UserSecNr = " & RightID
            If GRightBigindSource.Count > 0 Then Exit Sub
            GRightBigindSource.Filter = ""
            GRightBigindSource.AddNew()
            Dim dr As DataRowView = GRightBigindSource.Current
            dr.BeginEdit()
            dr("UserID") = GroupID
            dr("UserSecNr") = RightID
            dr.EndEdit()
        End Sub
        ''' <summary>
        ''' Read data from database
        ''' </summary>
        Public Sub initializeReader()
            Dim con As New SqlClient.SqlConnection(Devpp.Data.SQLSERVER.ConnectionString)
            GroupAdapter = New SqlClient.SqlDataAdapter(sql, con)
            GroupAdapter.Fill(GroupDataTable)
            _GroupBinder.DataSource = GroupDataTable
            _listBox.DataSource = _GroupBinder
            _listBox.DisplayMember = "usrName"
            _listBox.ValueMember = "usrPid"


            For Each dr As DataRow In ParentRightDataTable.Rows
                Dim PNode As New Windows.Forms.TreeNode(dr(1))
                PNode.Name = dr(0)
                bsChild1.Filter = "ParentID = " & dr(0)
                If bsChild1.Count > 0 Then
                    For Each dr1 As DataRowView In bsChild1.List
                        Dim Ch1Node As New Windows.Forms.TreeNode(dr1(2))
                        Ch1Node.Name = dr1(0)
                        bsChild2.Filter = "ParentID = " & dr1(0)
                        If bsChild2.Count > 0 Then
                            For Each dr2 As DataRowView In bsChild2.List
                                Dim Ch2Node As New Windows.Forms.TreeNode(dr2(2))
                                Ch2Node.Name = dr2(0)
                                bsChild3.Filter = "ParentID = " & dr2(0)
                                If bsChild3.Count > 0 Then
                                    For Each dr3 As DataRowView In bsChild3.List
                                        Dim Ch3Node As New Windows.Forms.TreeNode(dr3(2))
                                        Ch3Node.Name = dr3(0)
                                        Ch2Node.Nodes.Add(Ch3Node)
                                    Next
                                End If

                                Ch1Node.Nodes.Add(Ch2Node)
                            Next
                        End If
                        PNode.Nodes.Add(Ch1Node)
                    Next
                End If
                _Treview.Nodes.Add(PNode)
            Next
            _Treview.ExpandAll()

            GRightAdapter = New SqlClient.SqlDataAdapter(GroupRightSQL, con)
            GRightAdapter.Fill(GRightDataTable)
            GRightBigindSource.DataSource = GRightDataTable


        End Sub
        ''' <summary>
        ''' Stores groups in memory
        ''' </summary>
        ''' <value>The group binding source.</value>
        Public ReadOnly Property GroupBindingSource() As Windows.Forms.BindingSource
            Get
                Return _GroupBinder
            End Get
        End Property
        ''' <summary>
        ''' Gets the ListBox.
        ''' </summary>
        ''' <value>The ListBox.</value>
        Public ReadOnly Property ListBox() As Windows.Forms.ListBox
            Get
                Return _listBox
            End Get
        End Property
        ''' <summary>
        ''' Gets the treview.
        ''' </summary>
        ''' <value>The treview.</value>
        Public ReadOnly Property Treview() As Windows.Forms.TreeView
            Get
                Return _Treview
            End Get
        End Property
        ''' <summary>
        ''' Check if the all child nodes unchacked then unchake the parent node
        ''' </summary>
        ''' <param name="ChildNode">The child node.</param>
        Private Sub UnchackParentNode(ByVal ChildNode As System.Windows.Forms.TreeNode)
            If ChildNode.Level > 0 Then
                Dim V_bool As Boolean = False
                Dim ParentNode As System.Windows.Forms.TreeNode = ChildNode.Parent
                For Each nd As Windows.Forms.TreeNode In ParentNode.Nodes
                    If nd.Checked = True Then
                        V_bool = True
                        Exit For
                    End If
                Next
                If V_bool = False Then
                    ParentNode.Checked = False
                End If
            End If
        End Sub
        ''' <summary>
        ''' Method for canceling changes
        ''' </summary>
        Public Sub CancelRight()
            GRightDataTable.RejectChanges()
            GRightBigindSource.SuspendBinding()
            GRightBigindSource.ResumeBinding()
            _DataChanged = False
        End Sub
        ''' <summary>
        ''' Saving group right in the database
        ''' </summary>
        ''' <exception cref="Exception"></exception>
        Public Sub SaveRight()
            Try
                Me.GRightBigindSource.EndEdit()
                Dim ComBulder As New SqlClient.SqlCommandBuilder(GRightAdapter)
                GRightAdapter.UpdateCommand = ComBulder.GetUpdateCommand
                GRightAdapter.Update(GRightDataTable)
                GRightDataTable.Clear()
                GRightAdapter.Fill(GRightDataTable)
                Users.Refill()
                _DataChanged = False
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub
        ''' <summary>
        ''' Method for adding new group
        ''' </summary>
        Public Sub AddGroup()
            Dim frm As New frmAddGroup
            frm.usrManager = Me
            If frm.ShowDialog = Windows.Forms.DialogResult.OK Then
                AddingMode = True
                _GroupBinder.AddNew()
                Dim dr As DataRowView = _GroupBinder.Current
                dr.BeginEdit()
                dr("usrName") = frm.txtGroup.Text
                dr.EndEdit()
                Save()
            End If
        End Sub
        ''' <summary>
        ''' Filter blocked or unblocked groups
        ''' </summary>
        ''' <param name="mode">The mode.</param>
        Public Sub GroupFilter(ByVal mode As Integer)
            Me.filterMode = mode
            If mode = 1 Then
                GroupBindingSource.Filter = "usrIsBlocked = 0"
                Me._Treview.Enabled = True
                _Treview.ExpandAll()
            Else
                GroupBindingSource.Filter = "usrIsBlocked = 1"
                _Treview.CollapseAll()
                Me._Treview.Enabled = False

            End If
        End Sub
        ''' <summary>
        ''' Saving group after adding
        ''' </summary>
        Public Sub Save()
            Try
                GroupBindingSource.EndEdit()
                Dim ComB As New SqlClient.SqlCommandBuilder(GroupAdapter)
                Me.GroupAdapter.UpdateCommand = ComB.GetUpdateCommand
                Me.GroupAdapter.Update(Me.GroupDataTable)
                Me.GroupDataTable.Rows.Clear()
                AddingMode = False
                Me.GroupAdapter.Fill(Me.GroupDataTable)
                Users.Refill()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Sub
        ''' <summary>
        ''' Handles the TableNewRow event of the GroupDataTable control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.Data.DataTableNewRowEventArgs"/> instance containing the event data.</param>
        Private Sub GroupDataTable_TableNewRow(ByVal sender As Object, ByVal e As System.Data.DataTableNewRowEventArgs) Handles GroupDataTable.TableNewRow
            e.Row.BeginEdit()
            e.Row("usrIsGroup") = 1
            e.Row("usrIsBlocked") = 0

            e.Row.EndEdit()

        End Sub

        ''' <summary>
        ''' Handles the AfterCheck event of the _Treview control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.Windows.Forms.TreeViewEventArgs"/> instance containing the event data.</param>
        Private Sub _Treview_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles _Treview.AfterCheck
            If isLoading = False Then
                For Each nd1 As Windows.Forms.TreeNode In e.Node.Nodes
                    nd1.Checked = e.Node.Checked
                    For Each nd2 As Windows.Forms.TreeNode In nd1.Nodes
                        nd2.Checked = e.Node.Checked
                    Next
                Next
                If e.Node.Level > 0 Then
                    If e.Node.Checked = True Then
                        If e.Node.Parent.Checked = False Then
                            e.Node.Checked = False
                        End If
                    End If
                End If
            End If




            If Me._GroupBinder.Count > 0 Then

                Dim dr As DataRowView = _GroupBinder.Current
                If e.Node.Checked = True Then
                    AddRight(dr("usrPid"), e.Node.Name)
                Else
                    RemoveRight(dr("usrPid"), e.Node.Name)
                End If

            End If
            Dim lst As New List(Of Windows.Forms.TreeNode)
            For Each nd As Windows.Forms.TreeNode In e.Node.Nodes
                lst.Add(nd)
            Next
            Dim Plst As New List(Of Windows.Forms.TreeNode)
            For Each nd As Windows.Forms.TreeNode In Me.Treview.Nodes
                Plst.Add(nd)
            Next
            If AllowAdd Then
                RaiseEvent RightChecked(Me, New NodeCheckedEventarg(lst, Plst, e.Node.Name, e.Node.Checked, Me._Treview))
                If e.Node.Checked = False Then
                    UnchackParentNode(e.Node)

                End If
            End If
        End Sub

        ''' <summary>
        ''' Handles the Click event of the _AddGroup control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub _AddGroup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _AddGroup.Click
            AddGroup()
        End Sub

        ''' <summary>
        ''' Handles the MouseUp event of the _listBox control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        Private Sub _listBox_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles _listBox.MouseUp
            If e.Button = Windows.Forms.MouseButtons.Right Then
                Me.menu.Items.Clear()
                If filterMode = 1 Then
                    Me.menu.Items.Add(_AddGroup)
                    If Me.GroupBindingSource.Count > 0 Then
                        Me.menu.Items.Add(_InActivate)
                    End If
                Else
                    If Me.GroupBindingSource.Count > 0 Then
                        Me.menu.Items.Add(_Activate)
                    End If
                End If


                Me.menu.Show(ListBox, e.Location)
            End If

        End Sub

        ''' <summary>
        ''' Handles the Click event of the _InActivate control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub _InActivate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _InActivate.Click
            If isLicensed = False Then
                messageNoLicense()
            Else
                Dim dr As DataRowView = Me.GroupBindingSource.Current
                dr.BeginEdit()
                dr("usrIsBlocked") = 1
                dr.EndEdit()
                Save()
            End If
        End Sub

        ''' <summary>
        ''' Handles the Click event of the _Activate control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub _Activate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Activate.Click
            If isLicensed = False Then
                messageNoLicense()
            Else
                Dim dr As DataRowView = Me.GroupBindingSource.Current
                dr.BeginEdit()
                dr("usrIsBlocked") = 0
                dr.EndEdit()
                Save()
            End If
        End Sub

        ''' <summary>
        ''' Handles the CurrentChanged event of the _GroupBinder control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub _GroupBinder_CurrentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _GroupBinder.CurrentChanged
            If AddingMode = True Then Exit Sub
            If _GroupBinder.Count > 0 Then
                AllowAdd = False
                Dim dr As DataRowView = _GroupBinder.Current
                GRightBigindSource.Filter = "UserID = " & dr("usrPid")
                UnchackTree()
                CheckTree()
                AllowAdd = True
            Else
                UnchackTree()
            End If

        End Sub

        ''' <summary>
        ''' Handles the ColumnChanged event of the GRightDataTable control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.Data.DataColumnChangeEventArgs"/> instance containing the event data.</param>
        Private Sub GRightDataTable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles GRightDataTable.ColumnChanged
            _DataChanged = True
            RaiseEvent onDataChanged(Me, New EventArgs)
        End Sub

        ''' <summary>
        ''' Handles the RowDeleted event of the GRightDataTable control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.Data.DataRowChangeEventArgs"/> instance containing the event data.</param>
        Private Sub GRightDataTable_RowDeleted(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs) Handles GRightDataTable.RowDeleted
            _DataChanged = True
            RaiseEvent onDataChanged(Me, New EventArgs)
        End Sub

        ''' <summary>
        ''' Handles the TableNewRow event of the GRightDataTable control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.Data.DataTableNewRowEventArgs"/> instance containing the event data.</param>
        Private Sub GRightDataTable_TableNewRow(ByVal sender As Object, ByVal e As System.Data.DataTableNewRowEventArgs) Handles GRightDataTable.TableNewRow
            _DataChanged = True
            RaiseEvent onDataChanged(Me, New EventArgs)
        End Sub

        ''' <summary>
        ''' Handles the BeforeCheck event of the _Treview control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.Windows.Forms.TreeViewCancelEventArgs"/> instance containing the event data.</param>
        Private Sub _Treview_BeforeCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles _Treview.BeforeCheck
            If AllowAdd Then

                If e.Node.Level > 0 Then
                    If e.Node.Parent.Checked = False And e.Node.Checked = False Then

                        e.Cancel = True
                    End If
                End If
            End If


        End Sub


        ''' <summary>
        ''' Handles the BeforeSelect event of the _Treview control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.Windows.Forms.TreeViewCancelEventArgs"/> instance containing the event data.</param>
        Private Sub _Treview_BeforeSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles _Treview.BeforeSelect
            If Me._GroupBinder.Count = 0 Then
                e.Cancel = True
            End If
        End Sub
    End Class
    ''' <summary>
    ''' Node Event Argument class
    ''' </summary>
    Public NotInheritable Class NodeCheckedEventarg
        ''' <summary>
        ''' The node to check
        ''' </summary>
        Private NodeToCheck As System.Windows.Forms.TreeNode = Nothing
        ''' <summary>
        ''' The _ nodes
        ''' </summary>
        Private _Nodes As New List(Of Windows.Forms.TreeNode)
        ''' <summary>
        ''' The _ level1 nodes
        ''' </summary>
        Private _Level1Nodes As New List(Of Windows.Forms.TreeNode)
        ''' <summary>
        ''' The _ key
        ''' </summary>
        Private _Key As String
        ''' <summary>
        ''' The _is chacked
        ''' </summary>
        Private _isChacked As Boolean
        ''' <summary>
        ''' The internal tree
        ''' </summary>
        Private InternalTree As Windows.Forms.TreeView
        ''' <summary>
        ''' Gets the level1 nodes.
        ''' </summary>
        ''' <value>The level1 nodes.</value>
        Public ReadOnly Property Level1Nodes() As List(Of Windows.Forms.TreeNode)
            Get
                Return _Level1Nodes
            End Get
        End Property
        ''' <summary>
        ''' Gets the child nodes.
        ''' </summary>
        ''' <value>The child nodes.</value>
        Public ReadOnly Property ChildNodes() As List(Of Windows.Forms.TreeNode)
            Get
                Return _Nodes
            End Get
        End Property
        ''' <summary>
        ''' Initializes a new instance of the <see cref="NodeCheckedEventarg"/> class.
        ''' </summary>
        ''' <param name="_nd">The _ND.</param>
        ''' <param name="Level1">The level1.</param>
        ''' <param name="nodename">The nodename.</param>
        ''' <param name="check">if set to <c>true</c> [check].</param>
        ''' <param name="Tree">The tree.</param>
        Sub New(ByVal _nd As List(Of Windows.Forms.TreeNode), ByVal Level1 As List(Of Windows.Forms.TreeNode), ByVal nodename As String, ByVal check As Boolean, ByVal Tree As Windows.Forms.TreeView)
            _Key = nodename
            _isChacked = check
            _Nodes = _nd
            _Level1Nodes = Level1
            InternalTree = Tree
        End Sub
        ''' <summary>
        ''' Gets a value indicating whether this instance is checked.
        ''' </summary>
        ''' <value><c>true</c> if this instance is checked; otherwise, <c>false</c>.</value>
        Public ReadOnly Property isChecked() As Boolean
            Get
                Return _isChacked
            End Get
        End Property
        ''' <summary>
        ''' Gets the key.
        ''' </summary>
        ''' <value>The key.</value>
        Public ReadOnly Property Key() As String
            Get
                Return _Key
            End Get
        End Property

        ''' <summary>
        ''' Sets the check.
        ''' </summary>
        ''' <param name="nodeKey">The node key.</param>
        ''' <param name="value">if set to <c>true</c> [value].</param>
        ''' <exception cref="NodeCheckedEventargEx"></exception>
        Public Sub setCheck(ByVal nodeKey As String, ByVal value As Boolean)
            For Each nd As Windows.Forms.TreeNode In InternalTree.Nodes
                If nd.Name = nodeKey Then
                    NodeToCheck = nd
                Else
                    Me.FindNode(nodeKey, nd)
                End If

                If Not NodeToCheck Is Nothing Then
                    NodeToCheck.Checked = value
                    Exit Sub
                End If
            Next
            If NodeToCheck Is Nothing Then
                Throw New NodeCheckedEventargEx(nodeKey)

            End If
        End Sub
        ''' <summary>
        ''' Sets the color of the child fore.
        ''' </summary>
        ''' <param name="nodeKey">The node key.</param>
        ''' <param name="value">The value.</param>
        ''' <exception cref="NodeCheckedEventargEx"></exception>
        Public Sub setChildForeColor(ByVal nodeKey As String, ByVal value As System.Drawing.Color)
            For Each nod As Windows.Forms.TreeNode In _Nodes
                If nod.Name = nodeKey Then
                    nod.ForeColor = value
                    Exit Sub
                End If
            Next
            Throw New NodeCheckedEventargEx(nodeKey)
        End Sub
        ''' <summary>
        ''' Sets the color of the child back.
        ''' </summary>
        ''' <param name="nodeKey">The node key.</param>
        ''' <param name="value">The value.</param>
        ''' <exception cref="NodeCheckedEventargEx"></exception>
        Public Sub setChildBackColor(ByVal nodeKey As String, ByVal value As System.Drawing.Color)
            For Each nod As Windows.Forms.TreeNode In _Nodes
                If nod.Name = nodeKey Then
                    nod.BackColor = value
                    Exit Sub
                End If
            Next
            Throw New NodeCheckedEventargEx(nodeKey)
        End Sub
        ''' <summary>
        ''' Finds the node.
        ''' </summary>
        ''' <param name="_key">The _key.</param>
        ''' <param name="KeyNode">The key node.</param>
        Private Sub FindNode(ByVal _key As String, ByVal KeyNode As Windows.Forms.TreeNode)
            For Each nd As System.Windows.Forms.TreeNode In KeyNode.Nodes
                If nd.Name = _key Then
                    NodeToCheck = nd
                    Exit Sub
                End If
                FindNode(Key, nd)
            Next
        End Sub
    End Class
    ''' <summary>
    ''' Node Checking exception class
    ''' </summary>
    Public NotInheritable Class NodeCheckedEventargEx
        Inherits System.Exception
        ''' <summary>
        ''' The _ message
        ''' </summary>
        Private _Message As String
        ''' <summary>
        ''' Initializes a new instance of the <see cref="NodeCheckedEventargEx"/> class.
        ''' </summary>
        ''' <param name="KeyText">The key text.</param>
        Public Sub New(ByVal KeyText As String)
            _Message = "Key '" & KeyText & "' does not exists"
        End Sub



        ''' <summary>
        ''' The _ source
        ''' </summary>
        Private _Source As String = "Devpp.DLL"
        ''' <summary>
        ''' The _ help link
        ''' </summary>
        Private _HelpLink As String = "www.Devpp.com/support?Value = NodeCheckedEventargEx "
        ''' <summary>
        ''' Gets a message that describes the current exception.
        ''' </summary>
        ''' <value>The message.</value>
        Public Overrides ReadOnly Property Message() As String
            Get
                Return _Message
            End Get
        End Property
        ''' <summary>
        ''' Gets or sets the name of the application or the object that causes the error.
        ''' </summary>
        ''' <value>The source.</value>
        Public Overrides Property Source() As String
            Get
                Return _Source
            End Get
            Set(ByVal value As String)
                _Source = value
            End Set
        End Property
        ''' <summary>
        ''' Gets or sets a link to the help file associated with this exception.
        ''' </summary>
        ''' <value>The help link.</value>
        Public Overrides Property HelpLink() As String
            Get
                Return _HelpLink
            End Get
            Set(ByVal value As String)
                _HelpLink = value
            End Set
        End Property
    End Class
End Namespace