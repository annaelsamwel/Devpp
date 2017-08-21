Imports System.Data.SQLClient
Imports Devpp.Security

''' <summary>
''' This Mode Manages all General Information about retrieving data from database
''' Cannot be exposed autside the the Library.(Created By Annael samwel (Tanzanian))
''' </summary>
''' <remarks></remarks>
Friend Module InternalSP
    ''' <summary>
    ''' This Statement for Login 
    ''' Mode =0 for Domain, Mode = 1 for Devpp Authet mode 2 for Both and mode 3 for chacking if user exist 
    ''' </summary>
    ''' <remarks></remarks>
    Private Const _Login As String = "if @mode = 3 SELECT [usrDomain] ,[usrIsBlocked],[usrPid], [usrPasswordChanged] FROM [tblDevppUser] WHERE  [usrName] ='Guest' if @mode = 0 " & _
                                    "SELECT * FROM [tblDevppUser] WHERE  [usrName] =@UserName " & _
                                    "if (@mode = 1) or (@mode = 2) SELECT * FROM [tblDevppUser] " & _
                                    "WHERE  ([usrName] =@UserName) AND ([usrPassword] = @usrPassword)"
    ''' <summary>
    ''' This statement for geting user setings"
    ''' </summary>
    ''' <remarks></remarks>
    Private Const _GetUserSettings As String = "SELECT  [usrBackColour1] ,[usrBackColour2]  ,[usrFontColour] ,[usrLanguage] ,[usrFontName]  " & _
                                                 ",[usrFontSize] ,[usrIBold] FROM tblDevppUser  WHERE [usrPid] = @usrPid"
    ''' <summary>
    ''' This Statement for updating user settings
    ''' </summary>
    ''' <remarks></remarks>
    Private Const _UpdateUserSetting As String = "UPDATE tblDevppUser SET [usrBackColour1] = @Bcolor1 ,[usrBackColour2] = @Bcolor2  ,[usrFontColour] = @FontColor " & _
                                                    " ,[usrFontName] = @FontName   ,[usrFontSize] = @FontSize ,[usrIBold] = @fontBold ,[usrLanguage] = @Language WHERE [usrPid] = @usrPid"

    Private Const _GetUserGroups As String = "SELECT usrPid, usrName " & _
                                             " FROM   tblDevppUser WHERE  (usrIsGroup = 1) AND  (usrIsBlocked = 0)"

    Private Const _GetChildUserGroups As String = "SELECT     dbo.tblDevppMapUserGroup.UserId, dbo.tblDevppMapUserGroup.GroupId, dbo.tblDevppUser.usrName  FROM dbo.tblDevppUser INNER JOIN " & _
                                                     "dbo.tblDevppMapUserGroup ON dbo.tblDevppUser.usrPid = dbo.tblDevppMapUserGroup.GroupId"
    Private Const _GetUsers As String = "SELECT usrPid, usrName " & _
                                            " FROM   tblDevppUser WHERE  (usrIsGroup = 0) AND  (usrIsBlocked = 0)"
    Private Const _GetBlockedUsers As String = "SELECT usrPid, usrName " & _
                                             " FROM   tblDevppUser WHERE    (usrIsBlocked = 1)"

    Private Const _GetRight As String = "SELECT     UserSecNr, UserID FROM  tblDevppUserRights"

    Public Const _SQLDBPhysicalLocation As String = "SELECT top 1 physical_name FROM sys.master_files"

    Private int As Integer = Nothing
    Friend ds As New DataSet
    Private TblRight As New DataTable("TblRight")
    Private UserTable As New DataTable("UserTable")
    Private GroupTable As New DataTable("GroupTable")
    Private tblRightUserID As New DataColumn("UserID", int.GetType)
    Private UserID As New DataColumn("UserID", int.GetType)
    Private GroupID As New DataColumn("UserID", int.GetType)
    Private UserRight As DataRelation
    Private GroupRight As DataRelation
    Private ClientTable As New DataTable
    Private ChildGroupTable As New DataTable
    Friend GroupReader As New DataTable
    Friend ParentGroup As New DataTable
    Friend TempParentGroup As New DataTable
    Friend TempUserRights As New DataTable
    ''' <summary>
    ''' This method used to initialize rights, goups and users
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub Start()
        If ds.Tables.Count > 0 Then
            Exit Sub
        End If
        TblRight = New DataTable
        UserTable = New DataTable
        GroupTable = New DataTable
        ClientTable = New DataTable
        ChildGroupTable = New DataTable
        TempUserRights = New DataTable
        TempParentGroup = New DataTable
        GroupReader = New DataTable
        ParentGroup = New DataTable
        ClientTable.Columns.Add("UserID", int.GetType)
        ClientTable.Columns.Add("RightID", int.GetType)
        ClientTable.Columns.Add("SystemRight", "".GetType)
        UserTable.Columns.Add("UserID", int.GetType)
        UserTable.Columns.Add("UserName", "".GetType)

        GroupTable.Columns.Add("UserID", int.GetType)
        GroupTable.Columns.Add("UserName", "".GetType)

        TblRight.Columns.Add("UserID", int.GetType)
        TblRight.Columns.Add("RightID", int.GetType)
        TblRight.Columns.Add("Right", "".GetType)
        ChildGroupTable.Columns.Add("UserID", int.GetType)
        ChildGroupTable.Columns.Add("GroupID", int.GetType)
        ChildGroupTable.Columns.Add("GroupName", "".GetType)

        TempParentGroup.Columns.Add("UserID", int.GetType)
        TempParentGroup.Columns.Add("Name", "".GetType)
        Dim dt As New DataTable
        Dim com As New SqlCommand
        Dim con As New SqlConnection(Data.SQLSERVER.ConnectionString)
        Try
            com = New SqlCommand(_GetRight, con)
            Dim adp As New SqlDataAdapter(com)
            adp.Fill(dt)
            TempUserRights = dt
            For Each dr As DataRowView In SystemRights.RightsBindingSource.List
                For Each rows As DataRow In dt.Rows
                    If dr(0) = rows(0) Then
                        Dim dr1 As DataRow = TblRight.NewRow

                        dr1(0) = rows(1)
                        dr1(1) = rows(0)
                        dr1(2) = dr(1)


                        TblRight.Rows.Add(dr1)

                    End If
                Next
            Next

            GetUsers()
            ReadUserGroups()
            ds.Tables.Add(TblRight)
            ds.Tables.Add(UserTable)
            ds.Tables.Add(GroupTable)
            ds.Tables.Add(ClientTable)
            ds.Tables.Add(ChildGroupTable)

            'UserRight = New DataRelation("UserRight", New DataColumn() {UserTable.Columns(0)}, New DataColumn() {TblRight.Columns(0)}, True)
            'ds.Relations.Add(UserRight)
            'ds.Relations.Add(GroupRight)

            ' GroupRight = New DataRelation("GroupRight", GroupID, tblRightUserID)

            SystemRights._UsersBider.DataSource = InternalSP.ds.Tables(1)
        Catch ex As Exception

        End Try

    End Sub
    ''' <summary>
    ''' This method used to block user in a system
    ''' </summary>
    ''' <param name="UserId"></param>
    ''' <param name="Block"></param>
    ''' <remarks></remarks>
    Friend Sub BlockUser(ByVal UserId As Integer, ByVal Block As Boolean)
        Dim V_i As Integer = 0
        If Block = True Then
            V_i = 1
        Else
            V_i = 0
        End If
        Dim sql As String = "UPDATE  tblDevppUser SET usrIsBlocked =  " & V_i.ToString & " WHERE usrPid = " & UserId.ToString
        Dim con As New SqlConnection(Devpp.Data.SQLSERVER.ConnectionString)
        Dim com As New SqlCommand(sql, con)
        Try
            con.Open()
            com.ExecuteNonQuery()
            con.Close()
        Catch ex As Exception
            con.Close()
            Throw New Exception(ex.Message)
        End Try
    End Sub
    ''' <summary>
    ''' This method used to read data from database
    ''' </summary>
    ''' <remarks></remarks>
    Friend Sub ReadRights()
        Dim dt As New DataTable
        Dim com As New SqlCommand
        Dim con As New SqlConnection(Data.SQLSERVER.ConnectionString)
        Try
            com = New SqlCommand(_GetRight, con)
            Dim adp As New SqlDataAdapter(com)
            adp.Fill(dt)
            TempUserRights = dt
            TblRight.Clear()
            For Each dr As DataRowView In SystemRights.RightsBindingSource.List
                For Each rows As DataRow In dt.Rows
                    If dr(0) = rows(0) Then
                        Dim dr1 As DataRow = TblRight.NewRow

                        dr1(0) = rows(1)
                        dr1(1) = rows(0)
                        dr1(2) = dr(1)

                        TblRight.Rows.Add(dr1)

                    End If
                Next
            Next
        Catch ex As Exception

        End Try


    End Sub
    Friend Function GetLogin(ByVal UserName As String, ByVal Password As Integer, ByVal mode As Integer) As DataTable
        If mode = 3 Then
            Password = 123
        End If
        Try

            Dim dt As New DataTable
            dt = Data.SQLSERVER.GetSPDataTable("spGetLogin", mode, UserName, Password)

            If mode < 3 And dt.Rows.Count > 0 Then
                Try
                    Devpp.Common.Login.PassUserCreated = dt.Rows(0)("usrCreateUserID")
                    Devpp.Common.Login.PassdateCreated = dt.Rows(0)("usrAuditCreateDate")
                    Devpp.Common.Login.UserDomain = dt.Rows(0)("usrDomain")
                    Devpp.Common.Login.PassDateChanged = dt.Rows(0)("usrPasswordChanged")
                Catch ex As Exception

                End Try
            End If
            Return dt
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Friend Function UserSettings(ByVal UserId As Integer, ByVal SettTYpe As Common.UserSetting) As DataTable
        Try
            Dim dt As New DataTable
            Dim com As New SqlCommand
            Dim con As New SqlConnection(Data.SQLSERVER.ConnectionString)
            Select Case SettTYpe
                Case Common.UserSetting.GetSettings
                    com = New SqlCommand(_GetUserSettings, con)
                Case Common.UserSetting.UpdateSettings
                    com = New SqlCommand(_UpdateUserSetting, con)
                Case Else
                    Return Nothing
            End Select
            com.Parameters.Add("@usrPid", SqlDbType.Int)
            com.Parameters.Add("@Bcolor1", SqlDbType.Int)
            com.Parameters.Add("@Bcolor2", SqlDbType.Int)
            com.Parameters.Add("@FontColor", SqlDbType.Int)
            com.Parameters.Add("@FontName", SqlDbType.NVarChar, 50)
            com.Parameters.Add("@FontSize", SqlDbType.Decimal, 18)
            com.Parameters.Add("@fontBold", SqlDbType.Bit)
            com.Parameters.Add("@Language", SqlDbType.Int)
            com.Parameters("@usrPid").Value = UserId
            com.Parameters("@Bcolor1").Value = Settings.BackGroundColor1.ToArgb
            com.Parameters("@Bcolor2").Value = Settings.BackGroundColor2.ToArgb
            com.Parameters("@FontColor").Value = Settings.FontColor.ToArgb
            com.Parameters("@FontName").Value = Settings.Font.Name
            com.Parameters("@FontSize").Value = Settings.Font.Size
            com.Parameters("@fontBold").Value = Settings.Font.Bold
            com.Parameters("@Language").Value = Settings.Language
            Dim adp As New SqlDataAdapter(com)
            adp.Fill(dt)
            Return dt
        Catch ex As Exception
            Return Nothing
        End Try
    End Function
    Friend Function GetUserGroups() As DataTable
        Dim dt As New DataTable
        Dim com As New SqlCommand
        Dim con As New SqlConnection(Data.SQLSERVER.ConnectionString)
        Try
            com = New SqlCommand(_GetUserGroups, con)
            Dim adp As New SqlDataAdapter(com)
            adp.Fill(dt)
            UserTable.Clear()
            For Each dr As DataRow In dt.Rows
                Dim dr1 As DataRow = UserTable.NewRow
                dr1(0) = dr(0)
                dr1(1) = dr(1)
                UserTable.Rows.Add(dr1)
            Next
            Return UserTable
        Catch ex As Exception
            con.Close()
            Return Nothing
        End Try
    End Function
    Friend Function GetUsers() As DataTable
        Dim dt As New DataTable
        Dim com As New SqlCommand
        Dim con As New SqlConnection(Data.SQLSERVER.ConnectionString)

        Try
            com = New SqlCommand(_GetUsers, con)
            Dim adp As New SqlDataAdapter(com)
            adp.Fill(dt)
            UserTable.Clear()
            For Each dr As DataRow In dt.Rows
                Dim dr1 As DataRow = UserTable.NewRow
                dr1(0) = dr(0)
                dr1(1) = dr(1)
                UserTable.Rows.Add(dr1)
            Next

            Return UserTable

        Catch ex As Exception
            con.Close()
            Return Nothing
        End Try


    End Function
    Friend Sub ReadUserGroups()
        GroupReader.Clear()
        ParentGroup.Clear()
        Dim dt As New DataTable
        Dim com As New SqlCommand
        Dim con As New SqlConnection(Data.SQLSERVER.ConnectionString)
        com = New SqlCommand(_GetChildUserGroups, con)
        Dim adp As New SqlDataAdapter(com)
        adp.Fill(GroupReader)
        com = New SqlCommand(_GetUserGroups, con)
        adp = New SqlDataAdapter(com)
        adp.Fill(ParentGroup)
        TempParentGroup.Clear()
        For Each r As DataRow In ParentGroup.Rows
            Dim dr As DataRow = TempParentGroup.NewRow
            dr(0) = r(0)
            dr(1) = r(1)
            TempParentGroup.Rows.Add(dr)
        Next
    End Sub
    Friend Function GetAllUserGroups() As DataTable
        Return ParentGroup
    End Function
    Friend Function GetBlockedUsers() As DataTable
        Dim dt As New DataTable
        Dim com As New SqlCommand
        Dim con As New SqlConnection(Data.SQLSERVER.ConnectionString)

        Try
            com = New SqlCommand(_GetBlockedUsers, con)
            Dim adp As New SqlDataAdapter(com)
            adp.Fill(dt)
            UserTable.Clear()
            For Each dr As DataRow In dt.Rows
                Dim dr1 As DataRow = UserTable.NewRow
                dr1(0) = dr(0)
                dr1(1) = dr(1)
                UserTable.Rows.Add(dr1)
            Next

            Return UserTable

        Catch ex As Exception
            con.Close()
            Return Nothing
        End Try


    End Function
    Friend Function GetChildUserGroups(Optional ByVal UserID As Integer = Nothing) As DataTable

        If UserID = Nothing Then
            Return ChildGroupTable
        End If
        ChildGroupTable.Clear()
        For Each r As DataRow In GroupReader.Rows
            Try
                If r(0) = UserID Then
                    Dim dr As DataRow = ChildGroupTable.NewRow
                    dr(0) = r(0)
                    dr(1) = r(1)
                    dr(2) = r(2)
                    ChildGroupTable.Rows.Add(dr)

                End If
            Catch ex As Exception

            End Try
        Next
        Return ChildGroupTable
    End Function
    Friend Sub ManageUsrRights(ByVal UserID As Integer, ByVal IdRight As Integer, ByVal Right As String, ByVal mode As Integer)
        If mode = 0 Then
            For Each r As DataRow In TblRight.Rows
                If r(0) = UserID And r(1) = IdRight And r(2) = Right Then
                    Exit Sub
                End If
            Next
            Dim dr As DataRow = TblRight.NewRow
            dr(0) = UserID
            dr(1) = IdRight
            dr(2) = Right
            TblRight.Rows.Add(dr)
            GetUserRights(dr(0))
        ElseIf mode = 1 Then
            For x As Integer = 0 To TblRight.Rows.Count - 1
                If TblRight.Rows(x)(0) = UserID And TblRight.Rows(x)(1) = IdRight Then
                    TblRight.Rows.Remove(TblRight.Rows(x))
                    Exit For
                End If
            Next

        End If
    End Sub
    Friend Function GetUserRights(Optional ByVal UserID As Integer = Nothing) As DataTable
        ClientTable.Clear()

        If UserID = Nothing Then
            Return ClientTable
        End If

        For Each r As DataRow In TblRight.Rows

            If r(0) = UserID Then
                Dim dr As DataRow = ClientTable.NewRow
                dr(0) = r(0)
                dr(1) = r(1)
                dr(2) = r(2)
                ClientTable.Rows.Add(dr)
            End If

        Next

        Return ClientTable
    End Function

End Module
