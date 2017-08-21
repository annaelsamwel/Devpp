' ***********************************************************************
' Assembly         : Dev++
' Author           : Annael Samwel
' Created          : 08-18-2014
'
' Last Modified By : user
' Last Modified On : 11-30-2011
' ***********************************************************************
' <copyright file="RightManager.vb" company="Annael">
'     Copyright © Annael 2010
' </copyright>
' <summary></summary>
' ***********************************************************************
Imports System.Data
''' <summary>
''' The Security namespace.
''' </summary>
Namespace Security
    ''' <summary>
    ''' This class used for initializing rights of the system
    ''' all rights are defined in this class and stored in the logical table
    ''' Created by Annael Samwel
    ''' </summary>
    ''' <remarks></remarks>
    ''' <summary>
    ''' Class RightManager. This class cannot be inherited.
    ''' </summary>
    Public NotInheritable Class RightManager
        ''' <summary>
        ''' Enum ChildRights
        ''' </summary>
        Public Enum ChildRights
            ''' <summary>
            ''' The child1
            ''' </summary>
            Child1
            ''' <summary>
            ''' The child2
            ''' </summary>
            Child2
            ''' <summary>
            ''' The child3
            ''' </summary>
            Child3
            'Child3
        End Enum
#Region "Filds"
        ''' <summary>
        ''' The v_i
        ''' </summary>
        Private v_i As Integer
        ''' <summary>
        ''' The p_i
        ''' </summary>
        Private p_i As Integer = 0
        ''' <summary>
        ''' The ch1_i
        ''' </summary>
        Private ch1_i As Integer = 0
        ''' <summary>
        ''' The ch2_i
        ''' </summary>
        Private ch2_i As Integer = 0
        ''' <summary>
        ''' The ch3_i
        ''' </summary>
        Private ch3_i As Integer = 0
        ''' <summary>
        ''' The system
        ''' </summary>
        Private sys As New SystemRights
        ''' <summary>
        ''' The _ parent
        ''' </summary>
        Private _Parent As New DataTable("Parent")
        ''' <summary>
        ''' The _ child1
        ''' </summary>
        Private _Child1 As New DataTable("Child1")
        ''' <summary>
        ''' The _ child2
        ''' </summary>
        Private _Child2 As New DataTable("Child2")
        ''' <summary>
        ''' The _ child3
        ''' </summary>
        Private _Child3 As New DataTable("Child3")
        ''' <summary>
        ''' The _ child4
        ''' </summary>
        Private _Child4 As New DataTable("Child4")

        ''' <summary>
        ''' The _ parent address
        ''' </summary>
        Private _ParentAddress As New DataColumn("Address", v_i.GetType)
        ''' <summary>
        ''' The _ child1 address
        ''' </summary>
        Private _Child1Address As New DataColumn("Addresss", v_i.GetType)
        ''' <summary>
        ''' The _ child2 address
        ''' </summary>
        Private _Child2Address As New DataColumn("Addresss", v_i.GetType)
        ''' <summary>
        ''' The _ child3 address
        ''' </summary>
        Private _Child3Address As New DataColumn("Addresss", v_i.GetType)
        ''' <summary>
        ''' The _ child4 address
        ''' </summary>
        Private _Child4Address As New DataColumn("Addresss", v_i.GetType)

        ''' <summary>
        ''' The _ child1 identifier
        ''' </summary>
        Private _Child1ID As New DataColumn("FAddress", v_i.GetType)
        ''' <summary>
        ''' The _ child2 identifier
        ''' </summary>
        Private _Child2ID As New DataColumn("FAddress", v_i.GetType)
        ''' <summary>
        ''' The _ child3 identifier
        ''' </summary>
        Private _Child3ID As New DataColumn("FAddress", v_i.GetType)
        ''' <summary>
        ''' The _ child4 identifier
        ''' </summary>
        Private _Child4ID As New DataColumn("FAddress", v_i.GetType)

        ''' <summary>
        ''' The _ parent description
        ''' </summary>
        Private _ParentDescription As New DataColumn("Description", "".GetType)
        ''' <summary>
        ''' The _ child1 description
        ''' </summary>
        Private _Child1Description As New DataColumn("Description", "".GetType)
        ''' <summary>
        ''' The _ child2 description
        ''' </summary>
        Private _Child2Description As New DataColumn("Description", "".GetType)
        ''' <summary>
        ''' The _ child3 description
        ''' </summary>
        Private _Child3Description As New DataColumn("Description", "".GetType)
        ''' <summary>
        ''' The _ child4 description
        ''' </summary>
        Private _Child4Description As New DataColumn("Description", "".GetType)


#End Region
#Region "Constractor"
        ''' <summary>
        ''' Initializes a new instance of the <see cref="RightManager"/> class.
        ''' </summary>
        ''' <exception cref="Exception">Devpp DLL not registered</exception>
        Public Sub New()
            If Not DLLRegistered Then
                Throw New Exception("Devpp DLL not registered")
            End If
            Initialize()
            UserManager.ParentRightDataTable = New DataTable
            UserManager.Child1RightDataTable = New DataTable
            UserManager.Child2RightDataTable = New DataTable
            UserManager.Child3RightDataTable = New DataTable

            UserManager.ParentRightDataTable.Columns.Add("ID", GetType(Integer))
            UserManager.ParentRightDataTable.Columns.Add("Desc", GetType(String))

            UserManager.Child1RightDataTable.Columns.Add("ID", GetType(Integer))
            UserManager.Child1RightDataTable.Columns.Add("ParentID", GetType(Integer))
            UserManager.Child1RightDataTable.Columns.Add("Desc", GetType(String))

            UserManager.Child2RightDataTable.Columns.Add("ID", GetType(Integer))
            UserManager.Child2RightDataTable.Columns.Add("ParentID", GetType(Integer))
            UserManager.Child2RightDataTable.Columns.Add("Desc", GetType(String))


            UserManager.Child3RightDataTable.Columns.Add("ID", GetType(Integer))
            UserManager.Child3RightDataTable.Columns.Add("ParentID", GetType(Integer))
            UserManager.Child3RightDataTable.Columns.Add("Desc", GetType(String))
            SplashScreenStatus = "Configure system rights"
            Threading.Thread.Sleep(2000)
        End Sub
#End Region
#Region "Methods"
        ''' <summary>
        ''' This is the inithialization of logical tables
        ''' </summary>
        Private Sub Initialize()
            'For Parent table
            _ParentAddress.AllowDBNull = False
            _ParentAddress.Unique = True
            _ParentDescription.AllowDBNull = False
            _ParentDescription.Unique = True
            _Parent.Columns.Add(_ParentAddress)
            _Parent.Columns.Add(_ParentDescription)

            'For child1 Table
            _Child1Address.Unique = True
            '  _Child1Description.Unique = True
            _Child1Address.AllowDBNull = False
            _Child1Description.AllowDBNull = False
            _Child1ID.AllowDBNull = False
            _Child1.Columns.Add(_Child1Address)
            _Child1.Columns.Add(_Child1ID)
            _Child1.Columns.Add(_Child1Description)

            'For Child2 Table
            _Child2Address.AllowDBNull = False
            _Child2Description.AllowDBNull = False
            _Child2ID.AllowDBNull = False
            _Child2Address.Unique = True
            ' _Child2Description.Unique = True
            _Child2.Columns.Add(_Child2Address)
            _Child2.Columns.Add(_Child2ID)
            _Child2.Columns.Add(_Child2Description)

            'For Child3 Table
            _Child3Address.AllowDBNull = False
            _Child3Description.AllowDBNull = False
            _Child3ID.AllowDBNull = False
            _Child3Address.Unique = True
            _Child3Description.Unique = True
            _Child3.Columns.Add(_Child3Address)
            _Child3.Columns.Add(_Child3ID)
            _Child3.Columns.Add(_Child3Description)

            'For Child4 Table
            _Child4Address.AllowDBNull = False
            _Child4Description.AllowDBNull = False
            _Child4ID.AllowDBNull = False
            _Child4Address.Unique = True
            _Child4Description.Unique = True
            _Child4.Columns.Add(_Child4Address)
            _Child4.Columns.Add(_Child4ID)
            _Child4.Columns.Add(_Child4Description)
        End Sub
        ''' <summary>
        ''' This method used to add parent rights
        ''' </summary>
        ''' <param name="Address">The unique Identification of rights</param>
        ''' <param name="Description">Right name</param>
        ''' <exception cref="Exception"></exception>
        Public Sub AddNewRight(ByVal Address As Integer, ByVal Description As String)
            Try
                Dim dr As DataRow = _Parent.NewRow
                dr(0) = Address
                dr(1) = Description
                sys.AddRow(dr(0), dr(1))

                _Parent.Rows.Add(dr)
                Dim nod As New System.Windows.Forms.TreeNode(Description)
                nod.Name = Address.ToString
                SystemRights.RightsNodes.Nodes.Add(nod)
                UserManager.ParentRightDataTable.Rows.Add(Address, Description)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub
        ''' <summary>
        ''' This method used to add logical child table
        ''' </summary>
        ''' <param name="Address">Unique Identification Address</param>
        ''' <param name="ForeignAddress">The parent Identification Address</param>
        ''' <param name="Description">Name of right</param>
        ''' <param name="Child">The child level</param>
        ''' <exception cref="Exception">
        ''' Foreign Address  & ForeignAddress.ToString &  does not belong in the parent
        ''' or
        ''' Foreign Address  & ForeignAddress.ToString &  does not belong in the parent
        ''' or
        ''' Foreign Address  & ForeignAddress.ToString &  does not belong in the parent
        ''' or
        ''' </exception>
        Public Sub AddNewRight(ByVal Address As Integer, ByVal ForeignAddress As Integer, ByVal Description As String, ByVal Child As ChildRights)
            Dim v_bl As Boolean = False
            Dim ParentDec As String = ""
            Dim pa1 As Integer = Nothing
            Try
                Select Case Child
                    Case ChildRights.Child1

                        For Each r As DataRow In _Parent.Rows
                            If r(0) = ForeignAddress Then
                                ParentDec = r(1)
                                v_bl = True
                                Exit For
                            End If
                        Next

                        If v_bl = False Then
                            Throw New Exception("Foreign Address " & ForeignAddress.ToString & " does not belong in the parent")

                        End If
                        UserManager.Child1RightDataTable.Rows.Add(Address, ForeignAddress, Description)
                        Dim dr As DataRow = _Child1.NewRow
                        dr(0) = Address
                        dr(1) = ForeignAddress
                        dr(2) = Description
                        sys.AddRow(dr(0), dr(2))
                        _Child1.Rows.Add(dr)
                        Dim nod As New System.Windows.Forms.TreeNode(Description)
                        nod.Name = Address.ToString
                        SystemRights.RightsNodes.Nodes(ForeignAddress.ToString).Nodes.Add(nod)

                    Case ChildRights.Child2
                        For Each r As DataRow In _Child1.Rows
                            If r(0) = ForeignAddress Then
                                ParentDec = r(2)
                                pa1 = r(1)
                                v_bl = True
                                Exit For
                            End If
                        Next
                        If v_bl = False Then
                            Throw New Exception("Foreign Address " & ForeignAddress.ToString & " does not belong in the parent")

                        End If
                        UserManager.Child2RightDataTable.Rows.Add(Address, ForeignAddress, Description)
                        'For Each r As DataRow In _Parent.Rows
                        '    If pa1 = r(0) Then
                        '        pa1()
                        '    End If
                        'Next
                        Dim dr As DataRow = _Child2.NewRow
                        dr(0) = Address
                        dr(1) = ForeignAddress
                        dr(2) = Description
                        sys.AddRow(dr(0), dr(2))
                        _Child2.Rows.Add(dr)
                        Dim nod As New System.Windows.Forms.TreeNode(Description)
                        nod.Name = Address.ToString
                        SystemRights.RightsNodes.Nodes(pa1.ToString).Nodes(ForeignAddress.ToString).Nodes.Add(nod)

                        '************
                        ' Don't delete this code is for fututre
                        '************
                    Case ChildRights.Child3
                        For Each r As DataRow In _Child2.Rows
                            If r(0) = ForeignAddress Then
                                ParentDec = r(2)
                                v_bl = True
                                Exit For
                            End If
                        Next
                        If v_bl = False Then
                            Throw New Exception("Foreign Address " & ForeignAddress.ToString & " does not belong in the parent")

                        End If
                        Dim dr As DataRow = _Child3.NewRow
                        dr(0) = Address
                        dr(1) = ForeignAddress
                        dr(2) = Description
                        sys.AddRow(dr(0), dr(2))
                        _Child3.Rows.Add(dr)
                        UserManager.Child3RightDataTable.Rows.Add(Address, ForeignAddress, Description)
                        'Case ChildRights.Child4

                        '    For Each r As DataRow In _Child3.Rows
                        '        If r(0) = ForeignAddress Then
                        '            ParentDec = r(2)
                        '            v_bl = True
                        '            Exit For
                        '        End If
                        '    Next
                        '    If v_bl = False Then
                        '        Throw New Exception("Foreign Address " & ForeignAddress.ToString & " does not belong in the parent")

                        '    End If
                        '    Dim dr As DataRow = _Child4.NewRow
                        '    dr(0) = Address
                        '    dr(1) = ForeignAddress
                        '    dr(2) = ParentDec & " -> " & Description
                        '    sys.AddRow(dr(0), dr(2))
                        '    _Child4.Rows.Add(dr)

                End Select
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub
        ''' <summary>
        ''' Clears this instance.
        ''' </summary>
        Public Sub Clear()
            UserManager.Child1RightDataTable.Rows.Clear()
            UserManager.Child2RightDataTable.Rows.Clear()
            UserManager.Child3RightDataTable.Rows.Clear()
            UserManager.ParentRightDataTable.Rows.Clear()
            _Parent.Rows.Clear()
            _Child1.Rows.Clear()
            _Child2.Rows.Clear()
            _Child3.Rows.Clear()
            _Child4.Rows.Clear()
        End Sub
        ''' <summary>
        ''' After adding all rights save them. and translate in one logical table
        ''' </summary>
        Public Sub SaveRights()
            sys.Save()
            SystemRights.RightsNodes.Dock = Windows.Forms.DockStyle.Fill
        End Sub
        ''' <summary>
        ''' This method used to store user loged in rights
        ''' </summary>
        ''' <param name="UserId">The user identifier.</param>
        ''' <returns>DataTable.</returns>
        Friend Shared Function GetUserRights(ByVal UserId As Integer) As DataTable
            Dim dtbl As New DataTable
            Dim int As Integer = Nothing
            Dim RightID As New DataColumn("RightID", int.GetType)
            RightID.AllowDBNull = False
            RightID.Unique = True
            dtbl.Columns.Add(RightID)
            dtbl.Columns.Add("Right", "".GetType)
            If UserId = -1 Or Settings.UserName.ToLower = "guest" Then
                For Each r As DataRowView In SystemRights.RightsBindingSource.List
                    Dim dr As DataRow = dtbl.NewRow
                    dr(0) = r(0)
                    dr(1) = r(1)
                    Try
                        dtbl.Rows.Add(dr)
                    Catch ex As Exception

                    End Try
                Next
                Return dtbl
            End If
            Dim SQL1 As String = "SELECT UserSecNr FROM tblDevppUserRights WHERE UserID = " & UserId.ToString
            Dim SQL2 As String = "SELECT GroupId  FROM tblDevppMapUserGroup WHERE UserID = " & UserId.ToString
            Dim con As New SqlClient.SqlConnection(Devpp.Data.SQLSERVER.ConnectionString)
            Dim com As New SqlClient.SqlDataAdapter(SQL1, con)
            Dim tbl1 As New DataTable
            com.Fill(tbl1)




            For Each r As DataRowView In SystemRights.RightsBindingSource.List
                For Each rw As DataRow In tbl1.Rows
                    If rw(0) = r(0) Then
                        Dim dr As DataRow = dtbl.NewRow
                        dr(0) = r(0)
                        dr(1) = r(1)
                        Try
                            dtbl.Rows.Add(dr)
                        Catch ex As Exception

                        End Try
                    End If
                Next
            Next
            com = New SqlClient.SqlDataAdapter(SQL2, con)
            Dim tbl2 As New DataTable
            com.Fill(tbl2)
            For Each r As DataRow In tbl2.Rows
                com = New SqlClient.SqlDataAdapter("SELECT UserSecNr FROM tblDevppUserRights WHERE UserID = " & r(0).ToString, con)
                Dim tbl3 As New DataTable
                com.Fill(tbl3)
                For Each l As DataRowView In SystemRights.RightsBindingSource.List
                    For Each rw As DataRow In tbl3.Rows
                        If rw(0) = l(0) Then
                            Dim dr As DataRow = dtbl.NewRow
                            dr(0) = l(0)
                            dr(1) = l(1)
                            Try
                                dtbl.Rows.Add(dr)
                            Catch ex As Exception

                            End Try
                        End If
                    Next
                Next

            Next
            Return dtbl
        End Function
#End Region
    End Class
End Namespace