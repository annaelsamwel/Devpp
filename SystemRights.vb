' ***********************************************************************
' Assembly         : Dev++
' Author           : Annael Samwel
' Created          : 08-18-2014
'
' Last Modified By : user
' Last Modified On : 04-28-2015
' ***********************************************************************
' <copyright file="SystemRights.vb" company="Annael">
'     Copyright © Annael 2010
' </copyright>
' <summary></summary>
' ***********************************************************************
Imports System.Data
Imports System.Windows.Forms
''' <summary>
''' The Security namespace.
''' </summary>
Namespace Security
    'This class Devppeloped by Annael Samwel
    ''' <summary>
    ''' This class used to define all rights of the system
    ''' Created by Annael Samwel
    ''' </summary>
    Public Class SystemRights
#Region "Fields"
        ''' <summary>
        ''' The temporary user name
        ''' </summary>
        Public Shared TempUserName As String
        ''' <summary>
        ''' The temporary password
        ''' </summary>
        Public Shared TempPassword As String
        ''' <summary>
        ''' The temporary user identifier
        ''' </summary>
        Friend Shared TempUserID As Integer
        ''' <summary>
        ''' The _ right identifier
        ''' </summary>
        Private _RightID As New DataColumn("RightID")
        ''' <summary>
        ''' The _ system right
        ''' </summary>
        Private _SystemRight As New DataColumn("SystemRight")
        ''' <summary>
        ''' The dt table
        ''' </summary>
        Private Shared DtTable As New DataTable
        ''' <summary>
        ''' The _ binder
        ''' </summary>
        Private Shared _Binder As New System.Windows.Forms.BindingSource
        ''' <summary>
        ''' The _ group bider
        ''' </summary>
        Private Shared _GroupBider As New System.Windows.Forms.BindingSource
        ''' <summary>
        ''' The _ users bider
        ''' </summary>
        Friend Shared WithEvents _UsersBider As New System.Windows.Forms.BindingSource
        ''' <summary>
        ''' The _ blocked users bider
        ''' </summary>
        Private Shared _BlockedUsersBider As New System.Windows.Forms.BindingSource
        ''' <summary>
        ''' The _ child group bider
        ''' </summary>
        Private Shared WithEvents _ChildGroupBider As New System.Windows.Forms.BindingSource
        ''' <summary>
        ''' The list right identifier
        ''' </summary>
        Private Shared ListRightId As New List(Of Integer)
        ''' <summary>
        ''' The list right
        ''' </summary>
        Private Shared ListRight As New List(Of String)
        ''' <summary>
        ''' The _ user rights
        ''' </summary>
        Private Shared WithEvents _UserRights As New System.Windows.Forms.BindingSource
        ''' <summary>
        ''' The _ datarow
        ''' </summary>
        Private _Datarow As DataRow
        ''' <summary>
        ''' The _ datarow1
        ''' </summary>
        Private Shared _Datarow1 As DataRow
        ''' <summary>
        ''' The list insert query
        ''' </summary>
        Private Shared ListInsertQuery As New List(Of String)
        ''' <summary>
        ''' The is new
        ''' </summary>
        Private Shared isNew As Boolean = True
        ''' <summary>
        ''' The _ nodes
        ''' </summary>
        Private Shared WithEvents _Nodes As New TreeView
        ''' <summary>
        ''' The _ user nodes
        ''' </summary>
        Private Shared WithEvents _UserNodes As New TreeView
        ''' <summary>
        ''' The _temp table
        ''' </summary>
        Private Shared _tempTable As New DataTable
        ''' <summary>
        ''' The men
        ''' </summary>
        Friend Shared WithEvents men As New ContextMenu
        ''' <summary>
        ''' The image LST
        ''' </summary>
        Private imageLst As ImageList
        ''' <summary>
        ''' The is nodeclear
        ''' </summary>
        Private Shared isNodeclear As Boolean = False
        ''' <summary>
        ''' The _ user ListView
        ''' </summary>
        Private Shared WithEvents _UserListView As New ListBox
        ''' <summary>
        ''' The _ user group list
        ''' </summary>
        Private Shared _UserGroupList As New ListBox
        ''' <summary>
        ''' The _ groups list
        ''' </summary>
        Private Shared _GroupsList As New ListBox
        ''' <summary>
        ''' The _ login user rights
        ''' </summary>
        Private Shared _LoginUserRights As New BindingSource
        ''' <summary>
        ''' The _ pop menu
        ''' </summary>
        Private Shared WithEvents _PopMenu As New ContextMenuStrip
        ''' <summary>
        ''' The _block user
        ''' </summary>
        Private Shared WithEvents _blockUser As ToolStripItem
        ''' <summary>
        ''' The _ create user
        ''' </summary>
        Private Shared WithEvents _CreateUser As ToolStripItem
        ''' <summary>
        ''' The _ edit user
        ''' </summary>
        Private Shared WithEvents _EditUser As ToolStripItem
        ''' <summary>
        ''' The v_mode
        ''' </summary>
        Private Shared v_mode As Integer = 0
        ''' <summary>
        ''' The is multiple add
        ''' </summary>
        Private Shared isMultipleAdd As Boolean = False
        ''' <summary>
        ''' The is agroup
        ''' </summary>
        Friend Shared isAgroup As Boolean
#End Region
#Region "Constractor"
        ''' <summary>
        ''' Initializes a new instance of the <see cref="SystemRights"/> class.
        ''' </summary>
        ''' <exception cref="Exception">Devpp DLL not registered</exception>
        Public Sub New()
            If Not DLLRegistered Then
                Throw New Exception("Devpp DLL not registered")
            End If
            If isNew = False Then
                Exit Sub
            End If
            _blockUser = New ToolStripMenuItem
            _EditUser = New ToolStripMenuItem
            _EditUser.Text = "Edit User"
            _blockUser.Text = "Block User"
            _CreateUser = New ToolStripMenuItem
            _CreateUser.Text = "Create User"
            Dim int As Integer
            _RightID.DataType = int.GetType
            _RightID.Unique = True
            _RightID.AllowDBNull = False
            _SystemRight.DataType = "".GetType
            _SystemRight.AllowDBNull = False
            DtTable.Columns.Add(_RightID)
            DtTable.Columns.Add(_SystemRight)
            _Binder.DataSource = DtTable
            isNew = False
            imageLst = New ImageList
            imageLst.Images.Add(My.Resources.Users)
            _Nodes.ImageList = imageLst
            _UserNodes.Dock = DockStyle.Fill
            _UserNodes.ImageList = imageLst
            _UserNodes.BackColor = Drawing.Color.AliceBlue
            _UserNodes.ForeColor = Drawing.Color.Blue
            _UserListView.Dock = DockStyle.Fill
            _UserGroupList.Dock = DockStyle.Fill
            _GroupsList.Dock = DockStyle.Fill

        End Sub
#End Region
        ''' <summary>
        ''' This method is the friend used to save rights
        ''' </summary>
        Friend Sub Save()
            Try
                _Binder.EndEdit()
                Start()

                Dim v_i As Integer = Nothing
                _tempTable.Columns.Add("ID", v_i.GetType)
                _tempTable.Columns.Add("Desc", "".GetType)
            Catch ex As Exception

            End Try
        End Sub
        ''' <summary>
        ''' Determines whether the specified node name is group.
        ''' </summary>
        ''' <param name="nodeName">Name of the node.</param>
        ''' <returns><c>true</c> if the specified node name is group; otherwise, <c>false</c>.</returns>
        Private Function isGroup(ByVal nodeName As String) As Boolean
            For Each gpr As DataRowView In _ChildGroupBider.List
                For Each r As DataRow In ds.Tables(0).Rows
                    For Each nod As TreeNode In _UserNodes.Nodes
                        If gpr(1) = r(0) And nod.Name = r(1).ToString Then
                            Return True
                        End If
                    Next
                Next
            Next
            Return False

        End Function
        ''' <summary>
        ''' This method used to manage user groups
        ''' </summary>
        ''' <param name="mode">The mode.</param>
        ''' <exception cref="Exception"></exception>
        Friend Sub ManageGroups(ByVal mode As RightManager)

            Dim intUserID As Integer = Nothing
            Dim intGroupID As Integer = Nothing
            Dim intRightID As Integer = Nothing
            Dim strUserName As String = ""

            isAgroup = True
            Try
                If mode = RightManager.Add Then
                    If _GroupBider.Count <= 0 Then
                        Exit Sub
                    End If
                    Dim gpr As DataRowView = _GroupBider.Current
                    Dim usr As DataRowView = _UsersBider.Current

                    intGroupID = gpr(0)
                    intUserID = usr(0)
                    strUserName = gpr(1)
                    For Each rw As DataRowView In _ChildGroupBider.List
                        If rw(0) = intUserID And rw(1) = intGroupID Then
                            Exit Sub
                        End If
                    Next
                    Dim dr As DataRow = GroupReader.NewRow
                    dr(0) = intUserID
                    dr(1) = intGroupID
                    dr(2) = strUserName
                    GroupReader.Rows.Add(dr)
                    For Each nd As TreeNode In _UserNodes.Nodes
                        For Each r As DataRow In TempUserRights.Rows

                            If nd.Name = r(0).ToString And r(1) = intGroupID Then

                                Dim v_bl As Boolean = False
                                Dim strDeleteRight As String = "DELETE FROM tblDevppUserRights WHERE UserID = " + intUserID.ToString + " AND UserSecNr = " + nd.Name

                                For v_i As Integer = 0 To ListInsertQuery.Count - 1
                                    If ListInsertQuery(v_i) = strDeleteRight Then
                                        v_bl = True
                                        Exit For
                                    End If
                                Next
                                If v_bl = False Then
                                    ListInsertQuery.Add(strDeleteRight)
                                End If
                            Else

                            End If
                            For Each nd1 As TreeNode In nd.Nodes

                                If nd1.Name = r(0).ToString And r(1) = intGroupID Then

                                    Dim v_bl As Boolean = False
                                    Dim strDeleteRight As String = "DELETE FROM tblDevppUserRights WHERE UserID = " + intUserID.ToString + " AND UserSecNr = " + nd1.Name

                                    For v_i As Integer = 0 To ListInsertQuery.Count - 1
                                        If ListInsertQuery(v_i) = strDeleteRight Then
                                            v_bl = True
                                            Exit For
                                        End If
                                    Next
                                    If v_bl = False Then
                                        ListInsertQuery.Add(strDeleteRight)
                                    End If
                                Else

                                End If
                                For Each nd2 As TreeNode In nd1.Nodes

                                    If nd2.Name = r(0).ToString And r(1) = intGroupID Then
                                        Dim v_bl As Boolean = False
                                        Dim strDeleteRight As String = "DELETE FROM tblDevppUserRights WHERE UserID = " + intUserID.ToString + " AND UserSecNr = " + nd2.Name

                                        For v_i As Integer = 0 To ListInsertQuery.Count - 1
                                            If ListInsertQuery(v_i) = strDeleteRight Then
                                                v_bl = True
                                                Exit For
                                            End If
                                        Next
                                        If v_bl = False Then
                                            ListInsertQuery.Add(strDeleteRight)
                                        End If
                                    Else

                                    End If
                                Next
                            Next
                        Next
                    Next
                    Dim strInsertGroup As String = "INSERT INTO [tblDevppMapUserGroup]([UserId] ,[GroupId]) VALUES ( " + intUserID.ToString + " ," + intGroupID.ToString + " )"
                    Dim v_b1 As Boolean = False
                    For Each Str As String In ListInsertQuery
                        If Str = strInsertGroup Then
                            v_b1 = True
                        End If
                    Next
                    If v_b1 = False Then
                        ListInsertQuery.Add(strInsertGroup)
                    End If

                    _GroupBider.RemoveCurrent()
                Else
                    If _ChildGroupBider.Count <= 0 Then
                        Exit Sub
                    End If
                    Dim gpr As DataRowView = _ChildGroupBider.Current
                    Dim usr As DataRowView = _UsersBider.Current
                    intGroupID = gpr(1)
                    intUserID = usr(0)
                    strUserName = gpr(2)
                    For Each r As DataRowView In _GroupBider.List
                        If r(0) = gpr(1) Then
                            Exit Sub
                        End If
                    Next
                    Dim dr As DataRow = ParentGroup.NewRow
                    dr(0) = intGroupID
                    dr(1) = strUserName
                    ParentGroup.Rows.Add(dr)
                    Dim strDeleteGroup As String = "DELETE FROM [tblDevppMapUserGroup] WHERE [UserId] = " + intUserID.ToString + " AND [GroupId]= " + intGroupID.ToString
                    Dim v_dr As DataRow = Nothing
                    Dim V_boolRow As Boolean = False
                    For v_i As Integer = 0 To GroupReader.Rows.Count - 1
                        If GroupReader.Rows(v_i)(0) = intUserID And GroupReader.Rows(v_i)(1) = intGroupID Then

                            v_dr = GroupReader.Rows(v_i)
                            V_boolRow = True
                            Exit For
                        End If
                    Next
                    If V_boolRow = True Then
                        GroupReader.Rows.Remove(v_dr)
                    End If

                    Dim v_b As Boolean = False
                    For Each Str As String In ListInsertQuery
                        If Str = strDeleteGroup Then
                            v_b = True
                            Exit For
                        End If
                    Next
                    ListInsertQuery.Add(strDeleteGroup)
                End If






                Saveright(intUserID)

                _UsersBider.ResetBindings(True)

            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub
        ''' <summary>
        ''' This method used to add nodes on the user rights
        ''' </summary>
        ''' <param name="nodeName">Name of the node.</param>
        Private Shared Sub addUserToNode(ByVal nodeName As String)
            If isSureUserNodeAdd(nodeName) = False Then
                Exit Sub
            End If


            Dim isAdded As Boolean = False
            For Each nd As TreeNode In _Nodes.Nodes
                If isAdded = True Then
                    Exit For
                End If
                If nd.Name = nodeName Then
                    Dim usrNode As New TreeNode
                    usrNode.Name = nodeName
                    usrNode.Text = nd.Text

                    _UserNodes.Nodes.Add(usrNode)
                    nd.ForeColor = Drawing.Color.LightGray
                    For Each nodes As TreeNode In nd.Nodes
                        Dim usr1Node As New TreeNode
                        usr1Node.Name = nodes.Name
                        usr1Node.Text = nodes.Text

                        _UserNodes.Nodes(nd.Name).Nodes.Add(usr1Node)
                        nodes.ForeColor = Drawing.Color.LightGray
                        For Each nodes1 As TreeNode In nodes.Nodes
                            Dim usr2Node As New TreeNode
                            usr2Node.Name = nodes1.Name
                            usr2Node.Text = nodes1.Text

                            _UserNodes.Nodes(nd.Name).Nodes(nodes.Name).Nodes.Add(usr2Node)
                            nodes1.ForeColor = Drawing.Color.LightGray
                        Next
                    Next
                    isAdded = True
                End If
                For Each nd1 As TreeNode In nd.Nodes
                    If isAdded = True Then
                        Exit For
                    End If
                    If nd1.Name = nodeName Then
                        Dim usrNode As New TreeNode
                        usrNode.Name = nd.Name
                        usrNode.Text = nd.Text

                        If isSureUserNodeAdd(nd.Name) = True Then
                            _UserNodes.Nodes.Add(usrNode)

                        End If
                        Dim usr1Node As New TreeNode
                        usr1Node.Name = nd1.Name
                        usr1Node.Text = nd1.Text

                        If isSureUserNodeAdd(nd1.Name) = True Then
                            _UserNodes.Nodes(nd.Name).Nodes.Add(usr1Node)

                        End If
                        For Each nodes1 As TreeNode In nd1.Nodes
                            Dim usr2Node As New TreeNode
                            usr2Node.Name = nodes1.Name
                            usr2Node.Text = nodes1.Text

                            _UserNodes.Nodes(nd.Name).Nodes(nd1.Name).Nodes.Add(usr2Node)

                        Next
                        isAdded = True
                    End If
                    For Each nd2 As TreeNode In nd1.Nodes
                        If isAdded = True Then
                            Exit For
                        End If
                        If nd2.Name = nodeName Then
                            Dim usrNode As New TreeNode
                            usrNode.Name = nd.Name
                            usrNode.Text = nd.Text

                            If isSureUserNodeAdd(nd.Name) = True Then
                                _UserNodes.Nodes.Add(usrNode)

                            End If
                            Dim usr1Node As New TreeNode
                            usr1Node.Name = nd1.Name
                            usr1Node.Text = nd1.Text

                            If isSureUserNodeAdd(nd1.Name) = True Then
                                _UserNodes.Nodes(nd.Name).Nodes.Add(usr1Node)

                            End If
                            Dim usr2Node As New TreeNode
                            usr2Node.Name = nd2.Name
                            usr2Node.Text = nd2.Text

                            _UserNodes.Nodes(nd.Name).Nodes(nd1.Name).Nodes.Add(usr2Node)

                            isAdded = True
                        End If
                    Next
                Next
            Next
            isMultipleAdd = False
            NodeChanges("", 0)
            NodeChanges("", 2)

        End Sub
        ''' <summary>
        ''' This class used to remove nodes
        ''' </summary>
        Private Shared Sub RemoveNode()
            NodeChanges("", 0)
            Dim childNode As New List(Of String)
            Dim ParentNode As New List(Of String)
            For Each r As DataRow In _tempTable.Rows
                Try
                    For Each nd As TreeNode In _Nodes.Nodes

                        If nd.Name = r(0) Then
                            isNodeclear = True
                            _UserNodes.Nodes(nd.Name).Remove()

                            Exit For
                        End If
                        For Each nd1 As TreeNode In nd.Nodes
                            If nd1.Name = r(0) Then
                                isNodeclear = True
                                _UserNodes.Nodes(nd.Name).Nodes(nd1.Name).Remove()

                                Exit For
                            End If
                            For Each nd2 As TreeNode In nd1.Nodes
                                If nd2.Name = r(0) Then
                                    isNodeclear = True
                                    _UserNodes.Nodes(nd.Name).Nodes(nd1.Name).Nodes(nd2.Name).Remove()

                                    Exit For
                                End If
                            Next
                        Next
                    Next

                Catch ex As Exception

                End Try
            Next


            For Each pNode As TreeNode In _UserNodes.Nodes
                For Each childNod As TreeNode In pNode.Nodes
                    If childNod.Nodes.Count = 0 Then
                        ParentNode.Add(pNode.Name)
                        childNode.Add(childNod.Name)
                    End If
                Next
            Next
            'For v_i As Integer = 0 To childNode.Count - 1
            '    _UserNodes.Nodes(ParentNode(v_i)).Nodes(childNode(v_i)).Remove()
            'Next
            ParentNode.Clear()
            For Each usNode As TreeNode In _UserNodes.Nodes
                If usNode.Nodes.Count = 0 Then
                    ParentNode.Add(usNode.Name)
                End If
            Next
            For Each Str As String In ParentNode
                _UserNodes.Nodes(Str).Remove()
            Next

            NodeChanges("", 2)
            isNodeclear = False
        End Sub
        ''' <summary>
        ''' This method used to asure adding of node
        ''' </summary>
        ''' <param name="nodeName">Name of the node.</param>
        ''' <returns><c>true</c> if [is sure user node add] [the specified node name]; otherwise, <c>false</c>.</returns>
        Private Shared Function isSureUserNodeAdd(ByVal nodeName As String) As Boolean
            For Each nd As TreeNode In _UserNodes.Nodes
                If nd.Name = nodeName Then

                    Return False
                End If
                For Each nd1 As TreeNode In nd.Nodes
                    If nd1.Name = nodeName Then

                        Return False
                    End If
                    For Each nd2 As TreeNode In nd1.Nodes
                        If nd2.Name = nodeName Then

                            Return False
                        End If
                    Next
                Next
            Next
            Return True
        End Function

        ''' <summary>
        ''' Quicks the login.
        ''' </summary>
        ''' <param name="RightID">The right identifier.</param>
        ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        Public Shared Function QuickLogin(ByVal RightID As Integer) As Boolean
            If GetCurrentUserRight(RightID) Then
                Return True
            End If

            Dim frm As New Forms.frmLogin
            frm.QuickLogin = True
            frm.AllowChangeDatabase = False
            frm.ShowDialog()
            Dim oReturn As Boolean = GetCurrentUserRight(RightID)
            Common.Login.UserID = TempUserID
            EndQuickLogin()
            Return oReturn
        End Function

        ''' <summary>
        ''' Ends the quick login.
        ''' </summary>
        Private Shared Sub EndQuickLogin()
            Dim frm As New Forms.frmLogin

            frm.QuickLogin = True
            frm.txtUserName.Text = TempUserName
            frm.txtPassword.Text = TempPassword
            frm.OKQuick()

        End Sub
        ''' <summary>
        ''' This manage each change of node when user clicked
        ''' </summary>
        ''' <param name="nodeName">Name of the node.</param>
        ''' <param name="mode">The mode.</param>
        Private Shared Sub NodeChanges(ByVal nodeName As String, ByVal mode As Integer)

            Select Case mode
                Case Is = 0
                    For Each nd As System.Windows.Forms.TreeNode In _Nodes.Nodes



                        nd.ForeColor = Drawing.Color.Black
                        nd.BackColor = _Nodes.BackColor

                        For Each nd1 As System.Windows.Forms.TreeNode In nd.Nodes
                            nd1.ForeColor = Drawing.Color.Black
                            nd1.BackColor = _Nodes.BackColor
                            For Each nd2 As System.Windows.Forms.TreeNode In nd1.Nodes
                                nd2.ForeColor = Drawing.Color.Black
                                nd2.BackColor = _Nodes.BackColor
                            Next
                        Next
                    Next
                Case Is = 1
                    For Each nd As System.Windows.Forms.TreeNode In _Nodes.Nodes

                        If nd.Name = nodeName Then
                            Dim v_node As New TreeNode
                            v_node.Name = nd.Name
                            v_node.Text = nd.Text
                            _UserNodes.Nodes.Add(v_node)
                            nd.ForeColor = Drawing.Color.LightGray
                            For Each nd1 As System.Windows.Forms.TreeNode In nd.Nodes
                                Dim v_node1 As New TreeNode
                                v_node1.Name = nd1.Name
                                v_node1.Text = nd1.Text
                                _UserNodes.Nodes(nd.Name).Nodes.Add(v_node1)
                                nd1.ForeColor = Drawing.Color.LightGray
                                For Each nd2 As System.Windows.Forms.TreeNode In nd1.Nodes
                                    nd2.ForeColor = Drawing.Color.LightGray
                                    Dim v_node2 As New TreeNode
                                    v_node2.Name = nd2.Name
                                    v_node2.Text = nd2.Text
                                    _UserNodes.Nodes(nd.Name).Nodes(nd1.Name).Nodes.Add(v_node2)
                                Next
                            Next
                            Exit For
                        Else

                            For Each nd1 As System.Windows.Forms.TreeNode In nd.Nodes

                                If nd1.Name = nodeName Then
                                    nd1.ForeColor = Drawing.Color.LightGray

                                    Dim v_node1 As New TreeNode
                                    v_node1.Name = nd1.Name
                                    v_node1.Text = nd1.Text
                                    If isSureUserNodeAdd(nodeName) = True Then
                                        _UserNodes.Nodes(nd.Name).Nodes.Add(v_node1)
                                    End If




                                    For Each nd2 As System.Windows.Forms.TreeNode In nd1.Nodes
                                        nd2.ForeColor = Drawing.Color.LightGray
                                        Dim v_node2 As New TreeNode
                                        v_node2.Name = nd2.Name
                                        v_node2.Text = nd2.Text
                                        If isSureUserNodeAdd(nodeName) = True Then
                                            _UserNodes.Nodes(nd.Name).Nodes(nd1.Name).Nodes.Add(v_node2)
                                        End If
                                        nd2.ForeColor = Drawing.Color.LightGray
                                    Next
                                Else


                                    Dim pa1 As String = Nothing
                                    Dim pa2 As String = Nothing
                                    For Each nd2 As System.Windows.Forms.TreeNode In nd1.Nodes

                                        If nd2.Name = nodeName Then

                                            Dim v_node2 As New TreeNode
                                            v_node2.Name = nd2.Name
                                            v_node2.Text = nd2.Text
                                            If isSureUserNodeAdd(nodeName) = True Then
                                                _UserNodes.Nodes(nd.Name).Nodes(nd1.Name).Nodes.Add(v_node2)
                                            End If
                                            nd2.ForeColor = Drawing.Color.LightGray
                                        End If
                                    Next
                                End If
                            Next
                        End If


                    Next
                Case Is = 2
                    For Each nd As TreeNode In _UserNodes.Nodes
                        _Nodes.Nodes(nd.Name).ForeColor = Drawing.Color.LightGray
                        For Each nd1 As TreeNode In nd.Nodes
                            _Nodes.Nodes(nd.Name).Nodes(nd1.Name).ForeColor = Drawing.Color.LightGray
                            For Each nd2 As TreeNode In nd1.Nodes
                                _Nodes.Nodes(nd.Name).Nodes(nd1.Name).Nodes(nd2.Name).ForeColor = Drawing.Color.LightGray
                            Next
                        Next
                    Next
            End Select
        End Sub
        ''' <summary>
        ''' This method used to remaind the use for saving
        ''' </summary>
        ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        Public Shared Function Reminder() As Boolean

            If ListInsertQuery.Count > 0 Then
                _tempTable.Clear()
                Dim msg As String = MsgBox("Do you want to save changes?", MsgBoxStyle.YesNo, "Reminder")
                If msg = vbYes Then
                    Dim str As String = ""
                    For Each st As String In ListInsertQuery
                        Dim con As New SqlClient.SqlConnection(Devpp.Data.SQLSERVER.ConnectionString)
                        Dim com As New SqlClient.SqlCommand(str, con)
                        Try
                            con.Open()
                            com.ExecuteNonQuery()

                            con.Close()
                        Catch ex As Exception
                            con.Close()
                        End Try
                    Next
                    ListInsertQuery.Clear()
                    If str <> "" Then

                        Try

                            ReadRights()
                            ReadUserGroups()
                            If v_mode = 0 Then
                                _UserRights.DataSource = GetUsers()
                            ElseIf v_mode = 1 Then
                                _UserRights.DataSource = GetUserGroups()
                            ElseIf v_mode = 2 Then
                                _UserRights.DataSource = GetBlockedUsers()
                            Else
                                _UserRights.DataSource = GetUsers()
                            End If
                            BindingChanges()
                        Catch ex As Exception



                        End Try
                    End If
                    Return False
                Else
                    ListInsertQuery.Clear()
                    ReadRights()
                    ReadUserGroups()
                    If v_mode = 0 Then
                        _UserRights.DataSource = GetUsers()
                    ElseIf v_mode = 1 Then
                        _UserRights.DataSource = GetUserGroups()
                    ElseIf v_mode = 2 Then
                        _UserRights.DataSource = GetBlockedUsers()
                    Else
                        _UserRights.DataSource = GetUsers()
                    End If
                    BindingChanges()
                    Return True
                End If
            End If
            Return True
        End Function
        ''' <summary>
        ''' This is the friend method used to save data to the database
        ''' </summary>
        Friend Sub SaveChages()
            Dim str As String = ""
            For Each st As String In ListInsertQuery
                Dim con As New SqlClient.SqlConnection(Devpp.Data.SQLSERVER.ConnectionString)
                Dim com As New SqlClient.SqlCommand(str, con)
                Try
                    con.Open()
                    com.ExecuteNonQuery()

                    con.Close()
                Catch ex As Exception
                    con.Close()
                End Try
            Next
            ListInsertQuery.Clear()
            If str <> "" Then

                Try

                    ReadRights()
                    ReadUserGroups()
                    If v_mode = 0 Then
                        _UserRights.DataSource = GetUsers()
                    ElseIf v_mode = 1 Then
                        _UserRights.DataSource = GetUserGroups()
                    ElseIf v_mode = 2 Then
                        _UserRights.DataSource = GetBlockedUsers()
                    Else
                        _UserRights.DataSource = GetUsers()
                    End If
                    BindingChanges()
                Catch ex As Exception



                End Try
            End If
        End Sub
        ''' <summary>
        ''' Saverights the specified user identifier.
        ''' </summary>
        ''' <param name="userID">The user identifier.</param>
        Private Shared Sub Saveright(ByVal userID As Integer)
            Dim str As String = ""
            For Each st As String In ListInsertQuery
                Dim con As New SqlClient.SqlConnection(Devpp.Data.SQLSERVER.ConnectionString)
                Dim com As New SqlClient.SqlCommand(st, con)
                Try
                    con.Open()
                    com.ExecuteNonQuery()

                    con.Close()
                Catch ex As Exception
                    con.Close()

                End Try



            Next
            ListInsertQuery.Clear()
            If str <> "" Then

                Try

                    ReadRights()
                    ReadUserGroups()
                    If v_mode = 0 Then
                        _UserRights.DataSource = GetUsers()
                    ElseIf v_mode = 1 Then
                        _UserRights.DataSource = GetUserGroups()
                    ElseIf v_mode = 2 Then
                        _UserRights.DataSource = GetBlockedUsers()
                    Else
                        _UserRights.DataSource = GetUsers()
                    End If
                    _UsersBider.MoveFirst()
                    For v_1 As Integer = 0 To _UsersBider.Count - 1
                        Dim rw As DataRowView = _UsersBider.Current
                        If rw(0) = userID Then
                            Exit For
                        End If
                        _UsersBider.MoveNext()

                    Next
                    BindingChanges()
                Catch ex As Exception


                End Try
            End If
        End Sub

        ''' <summary>
        ''' This method used to add or delete user rights
        ''' </summary>
        ''' <param name="mode">The mode.</param>
        Friend Sub ManageUserRight(ByVal mode As RightManager)
            Dim rw As DataRowView = _UsersBider.Current
            Dim rw1 As DataRowView = _Binder.Current
            Dim UserId As Integer
            Dim RightID As Integer
            Dim right As String
            Try

            Catch ex As Exception
                Exit Sub
            End Try
            For Each r As DataRow In _tempTable.Rows
                If isGroup(r(0)) = True And mode = RightManager.Remove Then
                Else
                    UserId = rw(0)
                    RightID = r(0)
                    right = r(1)
                    Dim sql As String = "INSERT INTO [tblDevppUserRights]  ([UserID] ,[UserSecNr]) VALUES ( " + UserId.ToString + ", " + RightID.ToString + ")"
                    Dim sql1 As String = "DELETE [tblDevppUserRights] WHERE [UserID] = " + UserId.ToString + " AND [UserSecNr] = " + RightID.ToString
                    'If ListInsertQuery.Count > 0 Then
                    '    For x As Integer = 0 To ListInsertQuery.Count - 1
                    '        If ListInsertQuery(x) = sql Or ListInsertQuery(x) = sql1 Then
                    '            Dim str As String = ListInsertQuery(x)
                    '            ListInsertQuery.Remove(str)

                    '        End If
                    '    Next
                    'End If

                    If mode = RightManager.Add Then
                        ListInsertQuery.Add(sql)
                        ManageUsrRights(UserId, RightID, right, 0)

                        addUserToNode(r(0))

                    Else
                        ListInsertQuery.Add(sql1)
                        ManageUsrRights(UserId, RightID, right, 1)
                        RemoveNode()
                    End If

                End If

            Next
            Saveright(UserId)
            _tempTable.Clear()
        End Sub
        ''' <summary>
        ''' This method used to add rights in the logical table
        ''' </summary>
        ''' <param name="RightID">The right identifier.</param>
        ''' <param name="SystemRight">The system right.</param>
        ''' <exception cref="Exception"></exception>
        Friend Sub AddRow(ByVal RightID As Integer, ByVal SystemRight As String)
            Try
                _Datarow = DtTable.NewRow
                _Datarow(0) = RightID
                _Datarow(1) = SystemRight
                DtTable.Rows.Add(_Datarow)
                ListRightId.Add(RightID)
                ListRight.Add(SystemRight)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub
        ''' <summary>
        ''' This is the shared method used to add rights of the user int he logical
        ''' table for each change of the user
        ''' </summary>
        ''' <param name="RightID">The right identifier.</param>
        ''' <param name="SystemRight">The system right.</param>
        ''' <param name="value">The value.</param>
        ''' <exception cref="Exception"></exception>
        Private Shared Sub AddRow(ByVal RightID As Integer, ByVal SystemRight As String, ByVal value As Integer)
            Try
                _Datarow1 = DtTable.NewRow
                _Datarow1(0) = RightID
                _Datarow1(1) = SystemRight
                DtTable.Rows.Add(_Datarow1)

            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub
        ''' <summary>
        ''' This id the get property used to display user rights nodes
        ''' </summary>
        ''' <value>The user right nodes.</value>
        Friend Shared ReadOnly Property UserRightNodes() As TreeView
            Get
                Return _UserNodes
            End Get
        End Property
        ''' <summary>
        ''' This is the get property used to display system rights
        ''' </summary>
        ''' <value>The rights nodes.</value>
        Friend Shared ReadOnly Property RightsNodes() As TreeView
            Get
                _Nodes.Dock = DockStyle.Fill
                Return _Nodes
            End Get
        End Property
        ''' <summary>
        ''' This is the get property Temporary logical table for user rights
        ''' </summary>
        ''' <value>The temporary table.</value>
        Friend ReadOnly Property tempTable() As DataTable
            Get
                Return _tempTable
            End Get
        End Property
        ''' <summary>
        ''' Thisis the get property used to return system rights
        ''' </summary>
        ''' <value>The rights binding source.</value>
        Friend Shared ReadOnly Property RightsBindingSource() As System.Windows.Forms.BindingSource
            Get
                _Binder.DataSource = DtTable

                Return _Binder
            End Get
        End Property
        ''' <summary>
        ''' This is the get property used to return system groups
        ''' </summary>
        ''' <value>The user group binding source.</value>
        Friend Shared ReadOnly Property UserGroupBindingSource() As System.Windows.Forms.BindingSource
            Get
                _GroupBider.DataSource = GetAllUserGroups()
                Return _GroupBider
            End Get
        End Property
        ''' <summary>
        ''' Gets the current user right.
        ''' </summary>
        ''' <param name="RightID">The right identifier.</param>
        ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        Public Shared Function GetCurrentUserRight(ByVal RightID As Integer) As Boolean
            For Each r As DataRowView In _LoginUserRights.List
                If r(0) = RightID Then
                    Return True
                End If
            Next
            Return False
        End Function
        ''' <summary>
        ''' Gets the get internal user.
        ''' </summary>
        ''' <value>The get internal user.</value>
        Private Shared ReadOnly Property GetInternalUser() As System.Windows.Forms.BindingSource
            Get
                Return _UsersBider
            End Get
        End Property
        ''' <summary>
        ''' This is the get property used to return rights of the user loged in
        ''' </summary>
        ''' <value>The login user rights.</value>
        Public Shared ReadOnly Property LoginUserRights() As BindingSource
            Get
                Return _LoginUserRights
            End Get
        End Property
        ''' <summary>
        ''' This is the get property used to return user groups
        ''' </summary>
        ''' <value>The child user group binding source.</value>
        Friend Shared ReadOnly Property ChildUserGroupBindingSource() As System.Windows.Forms.BindingSource
            Get

                _ChildGroupBider.DataSource = GetChildUserGroups()

                Return _ChildGroupBider
            End Get
        End Property
        ''' <summary>
        ''' Gets the internal child user group binding source.
        ''' </summary>
        ''' <value>The internal child user group binding source.</value>
        Private Shared ReadOnly Property InternalChildUserGroupBindingSource() As System.Windows.Forms.BindingSource
            Get
                Return _ChildGroupBider
            End Get
        End Property
        ''' <summary>
        ''' This is the get property used to return list of users
        ''' </summary>
        ''' <value>The user l ist view.</value>
        Friend Shared ReadOnly Property UserLIstView() As ListBox
            Get
                _UserListView.DataSource = _UsersBider
                _UserListView.DisplayMember = "UserName"
                _UserListView.FormattingEnabled = True
                _UserListView.ValueMember = "UserName"
                Return _UserListView
            End Get
        End Property
        ''' <summary>
        ''' This is the get property used to return users(list of users)
        ''' </summary>
        ''' <value>The users binding source.</value>
        ''' <param name="mode"></param>
        Friend Shared ReadOnly Property UsersBindingSource(ByVal mode As Integer) As System.Windows.Forms.BindingSource
            Get
                v_mode = mode
                If mode = 0 Then
                    _UserRights.DataSource = GetUsers()
                ElseIf mode = 1 Then
                    _UserRights.DataSource = GetUserGroups()
                ElseIf mode = 2 Then
                    _UserRights.DataSource = GetBlockedUsers()
                Else
                    _UserRights.DataSource = GetUsers()
                End If

                Return _UsersBider
            End Get
        End Property
        ''' <summary>
        ''' This is the get property used to return List of system groups on the interface
        ''' </summary>
        ''' <value>The groups list.</value>
        Friend Shared ReadOnly Property GroupsList() As ListBox
            Get
                _GroupBider.DataSource = GetAllUserGroups()
                _GroupsList.DataSource = _GroupBider
                _GroupsList.DisplayMember = "usrName"
                _GroupsList.ValueMember = "usrName"
                Return _GroupsList
            End Get
        End Property
        ''' <summary>
        ''' This is the get property used to return rights of user selected
        ''' </summary>
        ''' <value>The user rights binding source.</value>
        Friend Shared ReadOnly Property UserRightsBindingSource() As System.Windows.Forms.BindingSource
            Get


                _UserRights.DataSource = GetUserRights()
                Return _UserRights
            End Get
        End Property
        ''' <summary>
        ''' This is the get property used to return list of groups of users
        ''' </summary>
        ''' <value>The user group list.</value>
        Friend Shared ReadOnly Property UserGroupList() As ListBox
            Get
                _UserGroupList.DataSource = _ChildGroupBider
                _UserGroupList.DisplayMember = "GroupName"
                _UserGroupList.ValueMember = "GroupName"
                Return _UserGroupList
            End Get
        End Property
        ''' <summary>
        ''' This method used to manage rights for each change of user on interface
        ''' </summary>
        Private Shared Sub BindingChanges()
            _UserNodes.Nodes.Clear()
            Try
                Dim dr As DataRowView = GetInternalUser.Current
                _UserRights.DataSource = GetUserRights(dr(0))
                _ChildGroupBider.DataSource = GetChildUserGroups(dr(0))
                DtTable.Clear()

                For x As Integer = 0 To ListRight.Count - 1
                    AddRow(ListRightId(x), ListRight(x), 0)
                Next

                NodeChanges("", 0)

                For Each r As DataRowView In _Binder.List

                    For Each l As DataRowView In _UserRights.List

                        If l(1) = r(0) Then


                            addUserToNode(l(1).ToString)

                            Exit For
                        End If
                    Next

                    For Each rw As DataRow In ds.Tables(0).Rows
                        If _ChildGroupBider.Count > 0 Then
                            For Each row As DataRowView In _ChildGroupBider.List
                                If rw(0) = row(1) And rw(1) = r(0) Then

                                    addUserToNode(rw(1).ToString)
                                End If
                            Next
                        Else
                            Exit For

                        End If




                    Next




                Next

            Catch ex As Exception
                ds.Tables(3).Clear()
                ds.Tables(4).Clear()
            End Try
        End Sub
        ''' <summary>
        ''' Handles the CurrentChanged event of the _UsersBider control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Shared Sub _UsersBider_CurrentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _UsersBider.CurrentChanged
            If isAgroup = True Then

            Else
                Reminder()

            End If

            BindingChanges()
            ParentGroup.Clear()
            If _ChildGroupBider.Count > 0 Then

                For Each r As DataRow In TempParentGroup.Rows
                    Dim v_bl As Boolean = False
                    For Each rw As DataRowView In _ChildGroupBider.List
                        If r(1) = rw(2) Then
                            v_bl = True
                        End If
                    Next
                    If v_bl = False Then
                        Dim dr As DataRow = ParentGroup.NewRow
                        dr(0) = r(0)
                        dr(1) = r(1)
                        ParentGroup.Rows.Add(dr)
                    End If
                Next
            Else
                For Each r As DataRow In TempParentGroup.Rows

                    Dim dr As DataRow = ParentGroup.NewRow
                    dr(0) = r(0)
                    dr(1) = r(1)
                    ParentGroup.Rows.Add(dr)
                Next
            End If



        End Sub
        ''' <summary>
        ''' Enum RightManager
        ''' </summary>
        Public Enum RightManager
            ''' <summary>
            ''' The add
            ''' </summary>
            Add
            ''' <summary>
            ''' The remove
            ''' </summary>
            Remove
        End Enum
        ''' <summary>
        ''' Handles the MouseDown event of the _UserListView control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.Windows.Forms.MouseEventArgs"/> instance containing the event data.</param>
        Private Shared Sub _UserListView_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles _UserListView.MouseDown
            If _UserListView.Items.Count <= 0 Then
                Exit Sub
            End If
            Select Case v_mode
                Case Is = 0
                    _CreateUser.Text = "Add user"
                    _blockUser.Text = "Block user"
                    _EditUser.Text = "Edit user"
                    _PopMenu.Items.Clear()
                    _PopMenu.DropShadowEnabled = True

                    _PopMenu.Items.Add(_CreateUser)
                    _PopMenu.Items.Add(_EditUser)
                    _PopMenu.Items.Add(_blockUser)
                Case Is = 1
                    _CreateUser.Text = "Add group"
                    _blockUser.Text = "Block group"
                    _PopMenu.Items.Clear()
                    _PopMenu.DropShadowEnabled = True
                    _PopMenu.Items.Add(_CreateUser)
                    _PopMenu.Items.Add(_blockUser)


                Case Is = 2
                    _blockUser.Text = "Unblock user or Group"
                    _PopMenu.Items.Clear()
                    _PopMenu.DropShadowEnabled = True
                    _PopMenu.Items.Add(_blockUser)
            End Select

            If e.Button = MouseButtons.Right Then

                Dim v_point As New Drawing.Point(e.X + 20, e.Y)
                _PopMenu.Show(_UserListView, v_point)
            End If
        End Sub
        ''' <summary>
        ''' Handles the Click event of the _blockUser control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Shared Sub _blockUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _blockUser.Click
            If _UsersBider.Count > 0 Then
                Dim rw As DataRowView = _UsersBider.Current
                If v_mode = 0 Or v_mode = 1 Then
                    BlockUser(rw(0), True)
                Else
                    BlockUser(rw(0), False)
                End If
                If v_mode = 0 Then
                    _UserRights.DataSource = GetUsers()
                ElseIf v_mode = 1 Then
                    _UserRights.DataSource = GetUserGroups()
                ElseIf v_mode = 2 Then
                    _UserRights.DataSource = GetBlockedUsers()
                Else
                    _UserRights.DataSource = GetUsers()
                End If
                _UsersBider.DataSource = ds.Tables(1)
            End If
        End Sub

        ''' <summary>
        ''' Handles the AfterSelect event of the _Nodes control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.Windows.Forms.TreeViewEventArgs"/> instance containing the event data.</param>
        Private Shared Sub _Nodes_AfterSelect(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeViewEventArgs) Handles _Nodes.AfterSelect
            'If isMultipleAdd = True Then
            '    e.Node.BackColor = Drawing.Color.LightBlue
            '    e.Node.ForeColor = Drawing.Color.White
            'Else

            'End If


        End Sub



        ''Private Shared Sub _Nodes_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _Nodes.KeyDown
        ''    If e.KeyCode = Keys.ControlKey Then
        ''        isMultipleAdd = True


        ''    End If
        ''End Sub




        ''Private Shared Sub _Nodes_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles _Nodes.KeyUp
        ''    If e.KeyCode = Keys.ControlKey Then
        ''        isMultipleAdd = False
        ''        _tempTable.Clear()
        ''        For Each nd As TreeNode In _Nodes.Nodes
        '            nd.BackColor = _Nodes.BackColor
        '            nd.ForeColor = Drawing.Color.Black
        '            For Each nd1 As TreeNode In nd.Nodes
        '                nd1.BackColor = _Nodes.BackColor
        '                nd1.ForeColor = Drawing.Color.Black
        '                For Each nd2 As TreeNode In nd1.Nodes
        '                    nd2.BackColor = _Nodes.BackColor
        '                    nd2.ForeColor = Drawing.Color.Black
        '                Next
        '            Next
        '        Next
        '    End If
        'End Sub






        ''' <summary>
        ''' Handles the NodeMouseClick event of the _UserNodes control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.Windows.Forms.TreeNodeMouseClickEventArgs"/> instance containing the event data.</param>
        Private Shared Sub _UserNodes_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles _UserNodes.NodeMouseClick

            If e.Button = MouseButtons.Left Then

                _tempTable.Clear()
                Dim removed As Boolean = False
                For Each nd As System.Windows.Forms.TreeNode In _UserNodes.Nodes

                    Dim dr As DataRow = _tempTable.NewRow
                    If nd.Name = e.Node.Name Then
                        removed = True
                        dr(0) = CInt(e.Node.Name)
                        dr(1) = e.Node.Text
                        _tempTable.Rows.Add(dr)
                        For Each nd1 As System.Windows.Forms.TreeNode In nd.Nodes
                            dr = _tempTable.NewRow
                            dr(0) = CInt(nd1.Name)
                            dr(1) = nd1.Text
                            _tempTable.Rows.Add(dr)
                            For Each nd2 As System.Windows.Forms.TreeNode In nd1.Nodes
                                dr = _tempTable.NewRow
                                dr(0) = CInt(nd2.Name)
                                dr(1) = nd2.Text
                                _tempTable.Rows.Add(dr)
                            Next
                        Next

                    Else
                        For Each nd1 As System.Windows.Forms.TreeNode In nd.Nodes
                            If nd1.Name = e.Node.Name Then
                                dr = _tempTable.NewRow
                                dr(0) = CInt(nd1.Name)
                                dr(1) = nd1.Text
                                _tempTable.Rows.Add(dr)
                                For Each nd2 As System.Windows.Forms.TreeNode In nd1.Nodes
                                    dr = _tempTable.NewRow
                                    dr(0) = CInt(nd2.Name)
                                    dr(1) = nd2.Text
                                    _tempTable.Rows.Add(dr)
                                Next
                            Else
                                For Each nd2 As System.Windows.Forms.TreeNode In nd1.Nodes
                                    If nd2.Name = e.Node.Name Then
                                        dr = _tempTable.NewRow
                                        dr(0) = CInt(nd2.Name)
                                        dr(1) = nd2.Text
                                        _tempTable.Rows.Add(dr)
                                    End If
                                Next
                            End If
                        Next
                    End If


                Next
            End If
        End Sub

        ''' <summary>
        ''' Handles the Click event of the _CreateUser control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Shared Sub _CreateUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _CreateUser.Click
            Dim x As New frmCreateUser
            x.ShowDialog()
        End Sub

        ''' <summary>
        ''' Handles the Click event of the _EditUser control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Shared Sub _EditUser_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _EditUser.Click
            If _UsersBider.Count > 0 Then
                Dim dr As DataRowView = _UsersBider.Current
                Dim frmUserSetup As New Forms.frmUserSetup
                frmUserSetup.txtUserName.Text = dr(1)
                frmUserSetup.CurrenUserID = dr(0)
                frmUserSetup.ShowDialog()
            End If
        End Sub


        ''' <summary>
        ''' Handles the NodeMouseClick event of the _Nodes control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.Windows.Forms.TreeNodeMouseClickEventArgs"/> instance containing the event data.</param>
        Private Shared Sub _Nodes_NodeMouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.TreeNodeMouseClickEventArgs) Handles _Nodes.NodeMouseClick
            _tempTable.Clear()
            If e.Button = MouseButtons.Left Then
                For Each nd As System.Windows.Forms.TreeNode In _Nodes.Nodes
                    Dim dr As DataRow = _tempTable.NewRow
                    If nd.Name = e.Node.Name Then

                        dr(0) = CInt(e.Node.Name)
                        dr(1) = e.Node.Text
                        _tempTable.Rows.Add(dr)
                        For Each nd1 As System.Windows.Forms.TreeNode In nd.Nodes
                            dr = _tempTable.NewRow
                            dr(0) = CInt(nd1.Name)
                            dr(1) = nd1.Text
                            _tempTable.Rows.Add(dr)
                            For Each nd2 As System.Windows.Forms.TreeNode In nd1.Nodes
                                dr = _tempTable.NewRow
                                dr(0) = CInt(nd2.Name)
                                dr(1) = nd2.Text
                                _tempTable.Rows.Add(dr)
                            Next
                        Next
                    Else
                        For Each nd1 As System.Windows.Forms.TreeNode In nd.Nodes
                            If nd1.Name = e.Node.Name Then
                                dr = _tempTable.NewRow
                                dr(0) = CInt(nd1.Name)
                                dr(1) = nd1.Text
                                _tempTable.Rows.Add(dr)
                                For Each nd2 As System.Windows.Forms.TreeNode In nd1.Nodes
                                    dr = _tempTable.NewRow
                                    dr(0) = CInt(nd2.Name)
                                    dr(1) = nd2.Text
                                    _tempTable.Rows.Add(dr)
                                Next
                            Else
                                For Each nd2 As System.Windows.Forms.TreeNode In nd1.Nodes
                                    If nd2.Name = e.Node.Name Then
                                        dr = _tempTable.NewRow
                                        dr(0) = CInt(nd2.Name)
                                        dr(1) = nd2.Text
                                        _tempTable.Rows.Add(dr)
                                    End If
                                Next
                            End If
                        Next
                    End If
                Next
            End If
        End Sub
    End Class
End Namespace