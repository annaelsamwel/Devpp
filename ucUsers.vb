Friend Class ucUsers
    Private Const Groupssql As String = "SELECT * FROM [tblDevppUser] WHERE [usrIsGroup] = 1 AND usrIsBlocked = 0"
    Private Const UsersSQL As String = "SELECT * FROM [tblDevppUser] WHERE [usrIsGroup] = 0"
    Private Const SQLMapping As String = "SELECT * FROM [tblDevppMapUserGroup]"
    Private GroupAdapter As SqlClient.SqlDataAdapter
    Private GroupDataTable As New DataTable
    Private GroupBindingSource As New Windows.Forms.BindingSource
    Private Const GroupRightSQL As String = "SELECT [UserID] ,[UserSecNr] FROM [tblDevppUserRights]"
    Private GRightAdapter As SqlClient.SqlDataAdapter
    Private WithEvents GRightDataTable As New DataTable
    Private GRightBigindSource As New Windows.Forms.BindingSource

    Private userAdapter As SqlClient.SqlDataAdapter
    Private userDataTable As New DataTable
    Private WithEvents UserBindingSource As New Windows.Forms.BindingSource

    Private MapingAdapter As SqlClient.SqlDataAdapter
    Private WithEvents MapingDataTable As New DataTable
    Private MapingBindingSource As New Windows.Forms.BindingSource
    Private bsChild1 As New Windows.Forms.BindingSource
    Private bsChild2 As New Windows.Forms.BindingSource
    Private bsChild3 As New Windows.Forms.BindingSource
    Private menu As New Windows.Forms.ContextMenuStrip
    Private WithEvents _AddUser As New System.Windows.Forms.ToolStripMenuItem("Add User")
    Private WithEvents _EditUser As New System.Windows.Forms.ToolStripMenuItem("Edit User")
    Private WithEvents _Block As New System.Windows.Forms.ToolStripMenuItem("Block User")
    Private WithEvents _Activate As New System.Windows.Forms.ToolStripMenuItem("Activate User")
    Private _DataCahnged As Boolean = False
    Private AllowAdd As Boolean = False
    Private Mode As Boolean = False
    Private UserIsChecking As Boolean = False
    Private _GetCurrentID As Integer
    Public Event onDataChanged(ByVal sender As Object, ByVal e As EventArgs)
    Public ReadOnly Property DataChanged() As Boolean
        Get
            Return _DataCahnged
        End Get
    End Property

    Public Sub LoadData()
        GroupDataTable.Clear()
        GroupAdapter.Fill(GroupDataTable)
        GRightDataTable.Clear()
        GRightAdapter.Fill(GRightDataTable)
        Me.UserBindingSource.ResetBindings(True)
        _DataCahnged = False
    End Sub
    Public Sub Refill()
        SaveMaping()
        GroupDataTable.Clear()
        LoadData()

        Me.TreeView1.Nodes.Clear()
        For Each dr As DataRowView In GroupBindingSource.List
            Dim nod As New Windows.Forms.TreeNode
            nod.Text = dr("usrName")
            nod.Name = dr("usrPid")
            Me.TreeView1.Nodes.Add(nod)
        Next
        ChekingGroup()
        Re_CheckRight()
    End Sub

    Private Sub RefillUser()

        userDataTable.Clear()
        userAdapter.Fill(userDataTable)
    End Sub
    Public Sub Initialize()


        Me.bsChild1.DataSource = Security.UserManager.Child1RightDataTable
        Me.bsChild2.DataSource = Security.UserManager.Child2RightDataTable
        Me.bsChild3.DataSource = Security.UserManager.Child3RightDataTable
        For Each dr As DataRow In Security.UserManager.ParentRightDataTable.Rows
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
            TreeView2.Nodes.Add(PNode)
        Next
        TreeView2.ExpandAll()


        Dim con As New SqlClient.SqlConnection(Devpp.Data.SQLSERVER.ConnectionString)

        GRightAdapter = New SqlClient.SqlDataAdapter(GroupRightSQL, con)
        GRightAdapter.Fill(GRightDataTable)
        GRightBigindSource.DataSource = GRightDataTable

        GroupAdapter = New SqlClient.SqlDataAdapter(Groupssql, con)
        GroupDataTable.Clear()
        GroupAdapter.Fill(GroupDataTable)
        GroupBindingSource.DataSource = GroupDataTable

        For Each dr As DataRowView In GroupBindingSource.List
            Dim nod As New Windows.Forms.TreeNode
            nod.Text = dr("usrName")
            nod.Name = dr("usrPid")
            Me.TreeView1.Nodes.Add(nod)
        Next
        userAdapter = New SqlClient.SqlDataAdapter(UsersSQL, con)
        userDataTable.Clear()
        userAdapter.Fill(userDataTable)
        UserBindingSource.DataSource = userDataTable
        Me.ListBox1.DataSource = UserBindingSource
        Me.ListBox1.DisplayMember = "usrName"
        Me.ListBox1.ValueMember = "usrPid"


        MapingAdapter = New SqlClient.SqlDataAdapter(SQLMapping, con)
        MapingDataTable.Clear()
        MapingAdapter.Fill(MapingDataTable)
        MapingBindingSource.DataSource = MapingDataTable
    End Sub
    Private Sub AddNewMaping(ByVal UserID As Integer, ByVal GroupID As Integer)
        MapingBindingSource.Filter = "[UserId] = " & UserID & " AND [GroupId] = " & GroupID
        If MapingBindingSource.Count > 0 Then Exit Sub
        MapingBindingSource.Filter = ""
        MapingBindingSource.AddNew()
        Dim dr As DataRowView = MapingBindingSource.Current
        dr.BeginEdit()
        dr("UserId") = UserID
        dr("GroupId") = GroupID
        dr.EndEdit()

    End Sub
    Private Sub DeleteMaping(ByVal UserID As Integer, ByVal GroupID As Integer)
        MapingBindingSource.Filter = "[UserId] = " & UserID & " AND [GroupId] = " & GroupID
        If MapingBindingSource.Count > 0 Then
            Me.MapingBindingSource.RemoveCurrent()
        End If
        MapingBindingSource.Filter = ""
    End Sub
    Private Sub rdoActive_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoActive.CheckedChanged
        If rdoActive.Checked = True Then
            Me.TreeView1.Enabled = True
            UserBindingSource.Filter = "usrIsBlocked = 0"

        Else
            UserBindingSource.Filter = "usrIsBlocked = 1"
            Me.TreeView1.Enabled = False

        End If

    End Sub
    Private Sub ListBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.DoubleClick
        Me._EditUser_Click(sender, e)
    End Sub
    Private Sub ListBox1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListBox1.MouseUp
        If Me.UserBindingSource.Count > 0 Then
            If e.Button = Windows.Forms.MouseButtons.Right Then
                menu.Items.Clear()
                If rdoActive.Checked = True Then
                    menu.Items.Add(_AddUser)
                    menu.Items.Add(_EditUser)
                    menu.Items.Add(_Block)
                Else
                    menu.Items.Add(_Activate)
                End If
                menu.Show(Me.ListBox1, e.Location)
            End If
        End If
    End Sub
    Private Sub Re_CheckRight()
        For Each pnd1 As Windows.Forms.TreeNode In Me.TreeView1.Nodes
            If pnd1.Checked = True Then
                GRightBigindSource.Filter = "UserID = " & pnd1.Name
                For Each dr As DataRowView In Me.GRightBigindSource.List
                    Dim v_bool As Boolean = False
                    For Each nd As Windows.Forms.TreeNode In TreeView2.Nodes
                        If v_bool = True Then
                            Exit For
                        End If
                        If nd.Name = dr("UserSecNr") Then
                            nd.Checked = True
                            Exit For
                        End If
                        For Each nd1 As Windows.Forms.TreeNode In nd.Nodes
                            If v_bool = True Then
                                Exit For
                            End If
                            If nd1.Name = dr("UserSecNr") Then
                                nd1.Checked = True
                                v_bool = True
                                Exit For
                            End If
                            For Each nd2 As Windows.Forms.TreeNode In nd1.Nodes
                                If nd2.Name = dr("UserSecNr") Then
                                    v_bool = True
                                    nd2.Checked = True
                                    Exit For
                                End If
                                For Each nd3 As Windows.Forms.TreeNode In nd2.Nodes
                                    If v_bool = True Then Exit For
                                    If nd3.Name = dr("UserSecNr") Then
                                        nd3.Checked = True
                                        v_bool = True
                                        Exit For
                                    End If
                                Next
                            Next
                        Next

                    Next
                Next


            End If
        Next
    End Sub
    Private Sub GroupUchacked(ByVal nod As Windows.Forms.TreeNode)
        GRightBigindSource.Filter = "UserID = " & nod.Name
        For Each dr As DataRowView In Me.GRightBigindSource.List
            Dim v_bool As Boolean = False
            For Each nd As Windows.Forms.TreeNode In TreeView2.Nodes
                If v_bool = True Then
                    Exit For
                End If
                If nd.Name = dr("UserSecNr") Then
                    nd.Checked = False
                    Exit For
                End If
                For Each nd1 As Windows.Forms.TreeNode In nd.Nodes
                    If v_bool = True Then
                        Exit For
                    End If
                    If nd1.Name = dr("UserSecNr") Then
                        nd1.Checked = False
                        v_bool = True
                        Exit For
                    End If
                    For Each nd2 As Windows.Forms.TreeNode In nd1.Nodes
                        If nd2.Name = dr("UserSecNr") Then
                            v_bool = True
                            nd2.Checked = False
                            Exit For
                        End If
                        For Each nd3 As Windows.Forms.TreeNode In nd2.Nodes
                            If nd3.Name = dr("UserSecNr") Then
                                v_bool = True
                                nd3.Checked = False
                                Exit For
                            End If
                        Next
                    Next
                Next

            Next
        Next

        Re_CheckRight()
    End Sub
    Private Sub _AddUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _AddUser.Click
        Mode = True
        Dim frm As New frmCreateUser
        frm.ShowDialog()
        RefillUser()
        Mode = False
        Me.UserBindingSource.MoveLast()
    End Sub
    Private Sub _EditUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _EditUser.Click
        If UserBindingSource.Count > 0 Then

            Dim dr As DataRowView = UserBindingSource.Current
            Dim frmUserSetup As New Forms.frmUserSetup
            frmUserSetup.txtUserName.Text = dr("usrName")
            frmUserSetup.CurrenUserID = dr("usrPid")
            Dim ID As Integer = dr("usrPid")
            If dr("usrName").ToString.ToUpper = "GUEST" Then
                MsgBox("Your can't Edit Guest is the default user!", MsgBoxStyle.Information, My.Application.Info.Title)
                Return
            End If
            frmUserSetup.ShowDialog()
            RefillUser()
            Me.UserBindingSource.Position = Me.UserBindingSource.Find("usrPid", ID)
        End If
    End Sub
    Private Sub SaveUser()
        Dim comBulder As New SqlClient.SqlCommandBuilder(userAdapter)
        Try
            userAdapter.UpdateCommand = comBulder.GetUpdateCommand
            userAdapter.Update(userDataTable)
            RefillUser()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Private Sub _Block_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Block.Click
        Dim dr As DataRowView = Me.UserBindingSource.Current
        If dr("usrPid") = Common.Login.UserID Then
            MsgBox("You can't block yourself. ", MsgBoxStyle.Information, My.Application.Info.Title)
            Exit Sub
        End If
        dr.BeginEdit()
        dr("usrIsBlocked") = 1
        dr.EndEdit()
        SaveUser()
    End Sub
    Private Sub _Activate_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _Activate.Click
        Dim dr As DataRowView = Me.UserBindingSource.Current
        dr.BeginEdit()
        dr("usrIsBlocked") = 0
        dr.EndEdit()
        SaveUser()
    End Sub
    Private Sub UnChack()
        For Each nod As Windows.Forms.TreeNode In Me.TreeView1.Nodes
            nod.Checked = False
        Next
    End Sub
    Private Sub Chack()
        For Each dr As DataRowView In MapingBindingSource.List
            If Me.TreeView1.Nodes.ContainsKey(dr("GroupId").ToString) Then

                Me.TreeView1.Nodes(dr("GroupId").ToString).Checked = True
            End If

        Next
    End Sub
    Private Sub CheckRight()
        For Each dr As DataRowView In Me.GRightBigindSource.List
            Dim v_bool As Boolean = False
            For Each nd As Windows.Forms.TreeNode In TreeView2.Nodes
                If v_bool = True Then
                    Exit For
                End If
                If nd.Name = dr("UserSecNr") Then
                    nd.Checked = True
                    Exit For
                End If
                For Each nd1 As Windows.Forms.TreeNode In nd.Nodes
                    If v_bool = True Then
                        Exit For
                    End If
                    If nd1.Name = dr("UserSecNr") Then
                        nd1.Checked = True
                        v_bool = True
                        Exit For
                    End If
                    For Each nd2 As Windows.Forms.TreeNode In nd1.Nodes
                        If nd2.Name = dr("UserSecNr") Then
                            v_bool = True
                            nd2.Checked = True
                            Exit For
                        End If
                        For Each nd3 As Windows.Forms.TreeNode In nd2.Nodes
                            If v_bool = True Then Exit For
                            If nd3.Name = dr("UserSecNr") Then
                                nd3.Checked = True
                                v_bool = True
                                Exit For
                            End If
                        Next
                    Next
                Next

            Next
        Next
    End Sub
    Private Sub MapingDataTable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles MapingDataTable.ColumnChanged
        _DataCahnged = True
        RaiseEvent onDataChanged(Me, New EventArgs)
    End Sub

    Private Sub MapingDataTable_RowDeleted(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs) Handles MapingDataTable.RowDeleted
        _DataCahnged = True
        RaiseEvent onDataChanged(Me, New EventArgs)
    End Sub

    Private Sub MapingDataTable_TableNewRow(ByVal sender As Object, ByVal e As System.Data.DataTableNewRowEventArgs) Handles MapingDataTable.TableNewRow
        _DataCahnged = True
        RaiseEvent onDataChanged(Me, New EventArgs)
    End Sub

    Private Sub TreeView1_AfterCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterCheck

        If Me.UserBindingSource.Count > 0 Then
            Dim dr As DataRowView = Me.UserBindingSource.Current
            GRightBigindSource.Filter = "UserID = " & e.Node.Name
            If e.Node.Checked = True Then
                CheckRight()
            Else
                GroupUchacked(e.Node)
            End If

            If AllowAdd = True Then
                If e.Node.Checked = True Then
                    If dr("usrName").ToString.ToUpper = "GUEST" Then
                        e.Node.Checked = False
                        MsgBox("Sorry! Guest user is the default user, you can`t assign in a group", MsgBoxStyle.Information, My.Application.Info.Title)

                        Exit Sub
                    End If
                    Me.AddNewMaping(dr("usrPid"), e.Node.Name)

                Else
                    Me.DeleteMaping(dr("usrPid"), e.Node.Name)
                End If
            End If

        Else

        End If
    End Sub
    Public Sub SaveMaping()
        Try
            Me.MapingBindingSource.EndEdit()
            Dim comBulder As New SqlClient.SqlCommandBuilder(MapingAdapter)
            Me.MapingAdapter.UpdateCommand = comBulder.GetUpdateCommand
            Me.MapingAdapter.Update(Me.MapingDataTable)
            MapingDataTable.Clear()
            Me.MapingAdapter.Fill(Me.MapingDataTable)
            _DataCahnged = False
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Private Sub ChekingGroup()
        AllowAdd = False
        UnChackRight()
        If Me.UserBindingSource.Count > 0 Then
            UnChack()
            Dim dr As DataRowView = Me.UserBindingSource.Current
            MapingBindingSource.Filter = "UserId = " & dr("usrPid")
            Chack()
        Else
            UnChack()
        End If
        AllowAdd = True
    End Sub
    Private Sub UserBindingSource_CurrentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UserBindingSource.CurrentChanged
        If Mode = True Then Exit Sub
        ChekingGroup()
    End Sub
    Private Sub UnChackRight()
        For Each nd As Windows.Forms.TreeNode In Me.TreeView2.Nodes
            nd.Checked = False
            For Each nd1 As Windows.Forms.TreeNode In nd.Nodes
                nd1.Checked = False
                For Each nd2 As Windows.Forms.TreeNode In nd1.Nodes
                    nd2.Checked = False
                    For Each nd3 As Windows.Forms.TreeNode In nd2.Nodes
                        nd3.Checked = False
                    Next
                Next
            Next
        Next
    End Sub


    Private Sub TreeView2_BeforeCheck(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewCancelEventArgs) Handles TreeView2.BeforeCheck
        If UserIsChecking = True Then

            e.Cancel = True

        End If
    End Sub

    Private Sub TreeView2_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TreeView2.MouseEnter
        UserIsChecking = True
    End Sub

    Private Sub TreeView2_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TreeView2.MouseLeave
        UserIsChecking = False
    End Sub

    Private Sub TreeView1_AfterSelect(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles TreeView1.AfterSelect

    End Sub
End Class
