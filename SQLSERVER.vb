' ***********************************************************************
' Assembly         : Dev++
' Author           : Annael Samwel
' Created          : 08-18-2014
'
' Last Modified By : user
' Last Modified On : 11-14-2014
' ***********************************************************************
' <copyright file="SQLSERVER.vb" company="Annael">
'     Copyright © Annael 2010
' </copyright>
' <summary></summary>
' ***********************************************************************
Imports System.Data.Sql
Imports Microsoft.SqlServer.Management.Smo
Imports System.Data.SqlClient
Imports System.Data
Imports Microsoft.SqlServer.Management.Common
''' <summary>
''' The Data namespace.
''' </summary>
Namespace Data
    ''' <summary>
    ''' Calss for managing SQLs for Database(SQL Server).
    ''' Created by Annael Samwel
    ''' </summary>
    Public NotInheritable Class SQLSERVER
        Inherits Object
#Region "Contractor"
        ''' <summary>
        ''' Initializes a new instance of the <see cref="SQLSERVER"/> class.
        ''' </summary>
        ''' <exception cref="Exception">Devpp DLL not registered</exception>
        Public Sub New()
            If Not DLLRegistered Then
                Throw New Exception("Devpp DLL not registered")
            End If
            Common.Reporting.Mytime.Interval = 60000
            Common.Reporting.Mytime.Enabled = True
            Common.Reporting.Mytime.Start()
        End Sub
#End Region
#Region "Fields"
        ''' <summary>
        ''' The table devpp user
        ''' </summary>
        Private tblDevppUser As DataTable
        ''' <summary>
        ''' The _FRM utility
        ''' </summary>
        Private Shared _frmUtil As New Forms.frmDBUtilities
        ''' <summary>
        ''' The exa instance
        ''' </summary>
        Private Shared exaInstance As String = Nothing
        ''' <summary>
        ''' The exa database
        ''' </summary>
        Private Shared exaDatabase As String = Nothing
        ''' <summary>
        ''' The exa instance ii
        ''' </summary>
        Private Shared exaInstanceII As String = exaInstance
        ''' <summary>
        ''' The exa database ii
        ''' </summary>
        Private Shared exaDatabaseII As String = exaDatabase
        ''' <summary>
        ''' The exa username
        ''' </summary>
        Private Shared exaUsername As String = "DevppBuiltIn"
        ''' <summary>
        ''' The exa password
        ''' </summary>
        Private Shared exaPassword As String = "!ob1Devpp2008"
        ''' <summary>
        ''' The sa password
        ''' </summary>
        Private Shared saPassword As String = "DevppBuiltIn"
        ''' <summary>
        ''' The exa windows authentication
        ''' </summary>
        Private Shared exaWindowsAuth As Boolean = False
        ''' <summary>
        ''' The exa windows authentication ii
        ''' </summary>
        Private Shared exaWindowsAuthII As Boolean = False
        ''' <summary>
        ''' The exa connection string
        ''' </summary>
        Private Shared exaConnString As String
        ''' <summary>
        ''' The exa connection string ii
        ''' </summary>
        Private Shared exaConnStringII As String
        ''' <summary>
        ''' The _ get current date
        ''' </summary>
        Private Shared _GetCurrentDate As Date
        ''' <summary>
        ''' The _ image connection string
        ''' </summary>
        Private Shared _ImageConnectionString As String
        ''' <summary>
        ''' The version
        ''' </summary>
        Private Const Version As String = "CREATE TABLE [dbo].[tblDevppVersion]([Devpp] [int] NULL, [Client] [int] NULl ) ON [PRIMARY]"
        ''' <summary>
        ''' The parameter command
        ''' </summary>
        Private Const ParamCmd As String = "SELECT parm.name AS Parameter, " + _
                                           "typ.name AS [Type]  " + _
                                           "FROM sys.procedures sp " + _
                                           "JOIN sys.parameters parm ON sp.object_id = parm.object_id " + _
                                           "JOIN sys.types typ ON parm.system_type_id = typ.system_type_id  " + _
                                           " WHERE typ.name <> 'sysname' and sp.name = @spName order by parm.parameter_id"
        ''' <summary>
        ''' The SQLTBL devpp user
        ''' </summary>
        Private Const sqltblDevppUser As String = "SELECT clm.name FROM sys.tables tbl  JOIN sys.columns clm ON tbl.object_id = clm.object_id " & _
                                            "WHERE tbl.Name = 'tblDevppUser'"


        ''' <summary>
        ''' The curent date
        ''' </summary>
        Private Const CurentDate As String = "SELECT getDate() AS [CURRENTDATE]"

        ''' <summary>
        ''' The createtbl devpp user
        ''' </summary>
        Private Const createtblDevppUser As String = "CREATE TABLE [dbo].[tblDevppUser]( " & _
                                                "[usrPid] [int] IDENTITY(1,1) NOT NULL,  " & _
                                                 "[usrName] [nvarchar](50) NOT NULL,  " & _
                                                 "[usrPassword] [int] NULL, " & _
                                                 "[PepId] [int] NULL CONSTRAINT [DF_tblDevppUser_PepId]  DEFAULT ((0)), " & _
                                                 "[usrIsGroup] [bit] NULL CONSTRAINT [DF_tblDevppUser_IsGroup]  DEFAULT ((0)), " & _
                                                 "[usrIsBlocked] [bit] NULL CONSTRAINT [DF_tblDevppUser_IsBlocked]  DEFAULT ((0)), " & _
                                                 "[usrDomain] [int] NULL CONSTRAINT [DF_tblDevppUser_usrDomain]  DEFAULT ((0)), " & _
                                                 "[usrLanguage] [int] NULL CONSTRAINT [DF_tblDevppUser_usrLanguage]  DEFAULT ((0)), " & _
                                                 "[usrRetryBlock] [bit] NULL CONSTRAINT [DF_tblDevppUser_usrRetries]  DEFAULT ((0)), " & _
                                                 "[usrPasswordValidity] [int] NULL CONSTRAINT [DF_tblDevppUser_usrPasswordValidity]  DEFAULT ((0)), " & _
                                                 "[usrPasswordChanged] [smalldatetime] NULL, " & _
                                                 "[usrStrongPassword] [bit] NULL CONSTRAINT [DF_tblDevppUser_usrStrongPassword]  DEFAULT ((0)), " & _
                                                 "[usrBackColour1] [bigint] NULL CONSTRAINT [DF_tblDevppUser_usrBackColour1]  DEFAULT ((0)), " & _
                                                 "[usrBackColour2] [bigint] NULL CONSTRAINT [DF_tblDevppUser_usrBackColour2]  DEFAULT ((0)), " & _
                                                 "[usrFontColour] [bigint] NULL CONSTRAINT [DF_tblDevppUser_usrFontColour]  DEFAULT ((0)), " & _
                                                 "[usrFlag] [int] NULL CONSTRAINT [DF_tblDevppUser_usrFlag]  DEFAULT ((0)), " & _
                                                 "[usrCreateUserID] [int] NULL CONSTRAINT [DF_tblDevppUser_usrCreateUserID]  DEFAULT ((0)), " & _
                                                 "[usrAuditCreateDate] [datetime] NULL CONSTRAINT [DF_tblDevppUser_AuditCreateDate]  DEFAULT (getdate()), " & _
                                                 "[usrFontName] [nvarchar](50) NULL CONSTRAINT [DF_tblDevppUser_usrFontName]  DEFAULT (N'N''Microsoft Sans Serif'), " & _
                                                 "[usrFontSize] [decimal](18, 1) NULL CONSTRAINT [DF_tblDevppUser_usrFontSize]  DEFAULT ((8)), " & _
                                                 "[usrIBold] [bit] NULL CONSTRAINT [DF_tblDevppUser_usrIBold]  DEFAULT ((0)), " & _
                                                 "CONSTRAINT [PK_tblDevppUser] PRIMARY KEY CLUSTERED  " & _
                                                "( [usrPid] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] " & _
                                                 ") ON [PRIMARY]"

        ''' <summary>
        ''' The table devpp user rights
        ''' </summary>
        Private Const tblDevppUserRights As String = "CREATE TABLE [dbo].[tblDevppUserRights](" & _
                                                 "[UserID] [int] NOT NULL, [UserSecNr] [int] NOT NULL, 	[UserSecValue] [int] NULL, [UserCreateID] [int] NULL, " & _
                                                 "[AuditCreateDate] [datetime] NULL, [UserUpdateID] [int] NULL, [AuditUpdateDate] [datetime] NULL, CONSTRAINT [PK_tblDevppUserSecurity] PRIMARY KEY CLUSTERED " & _
                                                "(	[UserID] ASC,	[UserSecNr] ASC " & _
                                                ")WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] " & _
                                                ") ON [PRIMARY] ALTER TABLE [dbo].[tblDevppUserRights]  WITH CHECK ADD  CONSTRAINT [FK_tblDevppUserRights_tblDevppUser] FOREIGN KEY([UserID]) " & _
                                                "REFERENCES [dbo].[tblDevppUser] ([usrPid]) ALTER TABLE [dbo].[tblDevppUserRights] CHECK CONSTRAINT [FK_tblDevppUserRights_tblDevppUser] "

        ''' <summary>
        ''' The table devpp user maping
        ''' </summary>
        Private Const tblDevppUserMaping As String = "CREATE TABLE [dbo].[tblDevppMapUserGroup]( [UserId] [int] NOT NULL, [GroupId] [int] NOT NULL, " & _
                                                 "CONSTRAINT [PK_tblDevppMapUserGroup] PRIMARY KEY CLUSTERED ( [UserId] ASC, [GroupId] ASC " & _
                                                ")WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] " & _
                                                ") ON [PRIMARY] ALTER TABLE [dbo].[tblDevppMapUserGroup]  WITH CHECK ADD  CONSTRAINT [FK_tblDevppMapUserGroup_tblDevppUser] FOREIGN KEY([UserId]) " & _
                                                " REFERENCES [dbo].[tblDevppUser] ([usrPid]) ALTER TABLE [dbo].[tblDevppMapUserGroup] CHECK CONSTRAINT [FK_tblDevppMapUserGroup_tblDevppUser] " & _
                                                "ALTER TABLE [dbo].[tblDevppMapUserGroup]  WITH CHECK ADD  CONSTRAINT [FK_tblDevppMapUserGroup_tblDevppUser1] FOREIGN KEY([GroupId]) " & _
                                                "REFERENCES [dbo].[tblDevppUser] ([usrPid]) ALTER TABLE [dbo].[tblDevppMapUserGroup] CHECK CONSTRAINT [FK_tblDevppMapUserGroup_tblDevppUser1] "

        ''' <summary>
        ''' The table devpp defaults
        ''' </summary>
        Private Const tblDevppDefaults As String = "CREATE TABLE [dbo].[tblDevppDefaults]( [DefaultID] [int] NOT NULL, [DefInt] [int] NULL CONSTRAINT [DF_tblDevppDefaults_DefInt]  DEFAULT ((0)), " & _
                                             "[DefBit] [bit] NULL, [DefFloat] [float] NULL, [DefDate] [datetime] NULL, [DefNvarchar] [nvarchar](max) NULL, [DefImageID] [int] NULL, " & _
                                             "CONSTRAINT [PK_tblDevppDefaults] PRIMARY KEY CLUSTERED  ( [DefaultID] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] " & _
                                            " ) ON [PRIMARY] "


        ''' <summary>
        ''' The table image
        ''' </summary>
        Private Const tblImage As String = "CREATE TABLE [dbo].[tblImage]( [ImageID] [int] IDENTITY(1,1) NOT NULL, [ImageValue] [varbinary](max) NOT NULL,  " & _
                                             "CONSTRAINT [PK_tblImage] PRIMARY KEY CLUSTERED (  [ImageID] ASC ) " & _
                                            "WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] " & _
                                            ") ON [PRIMARY]"

        ''' <summary>
        ''' The table devpp attribute type
        ''' </summary>
        Private Const tblDevppAttrType As String = "CREATE TABLE [dbo].[tblDevppAttrType]( [AttrTypeId] [int]  NOT NULL, [AttrTypeDescription] [nvarchar](50) NULL, " & _
                                                 "[AttrTypeHasCode] [bit] NULL, [isBlocked] [bit] NULL CONSTRAINT [DF_tblDevppAttrType_isBlocked]  DEFAULT ((0)), [isSystem] [bit] NULL CONSTRAINT [DF_tblDevppAttrType_isSystem]  DEFAULT ((0)), CONSTRAINT [PK_tblDevppAttrType] PRIMARY KEY CLUSTERED  " & _
                                                "( [AttrTypeId] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] " & _
                                                ") ON [PRIMARY]"

        ''' <summary>
        ''' The table devpp attribute
        ''' </summary>
        Private Const tblDevppAttr As String = "CREATE TABLE [dbo].[tblDevppAttr]( [attrId] [int] IDENTITY(1,1) NOT NULL, [AttrTypeId] [int] NULL, [AttrDescription] [nvarchar](50) NULL, " & _
                                             "[AttrIsBlocked] [bit] NULL CONSTRAINT [DF_tblDevppAttr_AttrIsBlocked]  DEFAULT ((0)), [AttrIsSystem] [bit] NULL CONSTRAINT [DF_tblDevppAttr_AttrIsSystem]  DEFAULT ((0)), " & _
                                             "[AttrCode] [nvarchar](8) NULL, CONSTRAINT [PK_tblDevppAttr] PRIMARY KEY CLUSTERED  ( [attrId] ASC )WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] " & _
                                             ") ON [PRIMARY] "



        ''' <summary>
        ''' The sp devpp get login
        ''' </summary>
        Private Const spDevppGetLogin As String = "CREATE PROC uspDevppGetLogin(@mode int, @UserName nvarchar(50), @usrPassword int) AS " & _
                                    "if @mode = 3 SELECT [usrDomain] ,[usrIsBlocked],[usrPid], [usrPasswordChanged], [usrPasswordValidity], [usrRetryBlock] FROM [tblDevppUser] WHERE  [usrName] =@UserName if @mode = 0 " & _
                                    " SELECT * FROM [tblDevppUser] WHERE  [usrName] =@UserName  " & _
                                    " if (@mode = 1) or (@mode = 2) SELECT * FROM [tblDevppUser]  " & _
                                   " WHERE  ([usrName] =@UserName) AND ([usrPassword] = @usrPassword) "

        ''' <summary>
        ''' The table devpp user log
        ''' </summary>
        Private Const tblDevppUserLog As String = "IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[tblDevppUserLog]') AND type in (N'U')) " & _
                                            "BEGIN " & _
                                            "CREATE TABLE [dbo].[tblDevppUserLog]( " & _
                                             "[RecID] [int] IDENTITY(1,1) NOT NULL, " & _
                                             "[MachineName] [nvarchar](50) NULL, " & _
                                             "[UserName] [nvarchar](50) NULL, " & _
                                             "[NetAddress] [nvarchar](50) NULL, " & _
                                             "[Date] [datetime] NULL, " & _
                                             "[Description] [nvarchar](50) NULL, " & _
                                             "CONSTRAINT [PK_tblDevppUserLog] PRIMARY KEY CLUSTERED  " & _
                                            "( [RecID] ASC " & _
                                            ")WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] " & _
                                            ") ON [PRIMARY]  END "

        ''' <summary>
        ''' The table contacts
        ''' </summary>
        Private Const tblContacts As String = "CREATE TABLE [dbo].[tblContacts]([IdNumber] [int] IDENTITY(1,1) NOT NULL, " & _
                                                "[Company] [int] NULL, [FirstName] [nvarchar](50) NULL, [LastName] [nvarchar](50) NULL, " & _
                                                "[Position] [nvarchar](50) NULL, [Telephone] [nvarchar](50) NULL, [Fax] [nvarchar](50) NULL, " & _
                                                "[Mobile] [nvarchar](50) NULL, [email] [nvarchar](50) NULL, [Address] [nvarchar](50) NULL, [POBox] [nvarchar](50) NULL, [City] [nvarchar](50) NULL, [Country] [nvarchar](50) NULL, " & _
                                                "[Notes] [nvarchar](1000) NULL, [IsBlocked] [bit] NULL, [Flag] [bit] NULL, [IsUsed] [bit] NULL, " & _
                                                "[bdeleted] [bit] NULL, [PepFirstName] [int] NULL, [PepLastName] [int] NULL, " & _
                                                "[PepEmail] [int] NULL, [PepAddress] [int] NULL, " & _
                                                "[PepCity] [int] NULL, [PepCountry] [int] NULL, " & _
                                                " CONSTRAINT [PK_tblContacts] PRIMARY KEY CLUSTERED  " & _
                                                "( [IdNumber] ASC " & _
                                                ")WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY] " & _
                                                ") ON [PRIMARY]"

        ''' <summary>
        ''' The sq LCMD
        ''' </summary>
        Private Shared SQLcmd As String
        ''' <summary>
        ''' The _ SQL connection
        ''' </summary>
        Private Shared _SQLConn As New SqlConnection()
        ''' <summary>
        ''' The _ SQL connection ii
        ''' </summary>
        Private Shared _SQLConnII As New SqlConnection()
        ''' <summary>
        ''' The command
        ''' </summary>
        Private Shared cmd As New SqlCommand(SQLcmd)
        ''' <summary>
        ''' The _usp name
        ''' </summary>
        Private Shared _uspName As String
        ''' <summary>
        ''' The _ return rows
        ''' </summary>
        Private Shared _ReturnRows As Integer


#End Region
        ''' <summary>
        ''' Gets or sets the FRM utility.
        ''' </summary>
        ''' <value>The FRM utility.</value>
        Private Shared Property frmUtil() As Forms.frmDBUtilities
            Get
                Return _frmUtil
            End Get
            Set(ByVal value As Forms.frmDBUtilities)
                _frmUtil = value
            End Set
        End Property
#Region "Initialization"
        ''' <summary>
        ''' Initializes this instance.
        ''' </summary>
        ''' <exception cref="Exception">
        ''' Devpp DLL not registered
        ''' or
        ''' </exception>
        Friend Sub initialize()
            If Not DLLRegistered Then
                Throw New Exception("Devpp DLL not registered")
            End If
            SplashScreenStatus = "Initialize database connection"
            frmUtil.Dispose() ' This used manage Dbutili to limit multple display when backhand not compatoble with the front hand

            Try
                checkSvrConn()
                ImageConnectionString = "Data Source=" & ServerName & ";Initial Catalog=" & DatabaseName & "_EXTRA"
                ConnectionString = "Data Source=" & ServerName & ";Initial Catalog=" & DatabaseName
                If exaWindowsAuth = True Then
                    ImageConnectionString += ";integrated security=SSPI;persist security info=False; Trusted_Connection=Yes"
                    ConnectionString += ";integrated security=SSPI;persist security info=False; Trusted_Connection=Yes"
                Else
                    ConnectionString += ";User ID= " & SelectedUsername & ";Password=" & SelectedPassword
                    ImageConnectionString += ";User ID= " & SelectedUsername & ";Password=" & SelectedPassword
                End If



                _SQLConn = New SqlConnection(ConnectionString)


                Dim con As New SqlConnection(ConnectionString)

                _ContactTable.Clear()
                Dim ContactAdapter As New SqlDataAdapter(ContactSQL, con)


                Dim getVersion As String = "if exists (SELECT * FROM sys.tables WHERE name = 'tblDevppVersion')" & vbNewLine & _
                                            "SELECT [Devpp] ,[Client],[Application] FROM [tblDevppVersion] else BEGIN " & vbNewLine & _
                                            "CREATE TABLE [dbo].[tblDevppVersion]([Devpp] [int] NULL, [Client] [int] NULl, [Application] [int] Null ) ON [PRIMARY] " & vbNewLine & _
                                            "INSERT INTO [tblDevppVersion] ([Devpp] ,[Client],[Application])   VALUES(0,0," & My.Application.Info.Version.MinorRevision & ")  " & vbNewLine & _
                                            "SELECT [Devpp] ,[Client],[Application] FROM [tblDevppVersion] END"




                Dim adp As New SqlDataAdapter(CurentDate, con)
                Dim adp1 As New SqlDataAdapter(getVersion, con)
                Dim dtTable As New DataTable
                Try
                    Dim dt As New DataTable
                    adp.Fill(dt)
                    _GetCurrentDate = dt.Rows(0)(0)
                Catch ex As Exception

                End Try
                adp1.Fill(dtTable)
                If dtTable.Rows.Count > 0 Then

                    _DevppScriptVersion = dtTable.Rows(0)(0)
                    _ClientScriptVersion = dtTable.Rows(0)(1)
                    _DBApplicationVersion = dtTable.Rows(0)(2)
                Else
                    _DevppScriptVersion = 0
                    _ClientScriptVersion = 0
                    _DBApplicationVersion = 0
                End If

                If DBApplicationVersion > applicationVersion Then
                    Dim frm As New frmMassage
                    frm.btnNo.Text = "OK"
                    frm.btnYes.Visible = False

                    frm.lblTitle.Text = "Database not compatible"
                    frm.lblText.Text = "Database is not compatible to the application(" & My.Application.Info.Title & ")." & vbNewLine & "You have to upgrade the application." & _
                    " or select database which is compatible to the application." & _
                    vbNewLine & "Application Version: " & applicationVersion & _
                    vbNewLine & "Database Version: " & DBApplicationVersion

                    frm.ShowDialog()
                    Dim frmu As New Devpp.Forms.frmDBUtilities
                    frmu.RunScript = True
                    frmUtil = frmu
                    frmu.ShowDialog()
                    Return
                End If
                If DBApplicationVersion < applicationVersion Then
                    Dim frm As New frmMassage
                    frm.btnNo.Text = "OK"
                    frm.btnYes.Visible = False
                    frm.lblTitle.Text = "Need to upgrade database"

                    frm.lblText.Text = "Database is not compatible to application" & vbNewLine & "You have to upgrade the database" & _
                     vbNewLine & "Application Version: " & applicationVersion & _
                    vbNewLine & "Database Version: " & DBApplicationVersion
                    frm.ShowDialog()

                    Dim frmu As New Devpp.Forms.frmDBUtilities
                    frmu.RunScript = True
                    frmUtil = frmu
                    frmu.ShowDialog()
                    Return
                End If
                gentblDevppUser()
                Try
                    ContactAdapter.Fill(_ContactTable)
                Catch ex As Exception

                End Try
                Dim DBQuery As String = "if not exists(SELECT * FROM sys.databases WHERE [name] = '" & DatabaseName & "_EXTRA') " & vbNewLine & _
               " begin  CREATE DATABASE " & DatabaseName & "_EXTRA   End"

                Dim Cone As New SqlConnection(ConnectionString)
                Dim ExtraDBCom As New SqlClient.SqlCommand(DBQuery, Cone)
                Try

                    Cone.Open()
                    ExtraDBCom.ExecuteNonQuery()
                    Cone.Close()
                    Cone = New SqlConnection(ImageConnectionString)
                    ExtraDBCom = New SqlCommand(My.Resources.ExtraImageTable, Cone)
                    Cone.Open()
                    ExtraDBCom.ExecuteNonQuery()
                    Cone.Close()
                Catch ex As Exception
                    Cone.Close()
                    MsgBox("Failed to create " & DatabaseName & "_EXTRA")
                End Try
            Catch ex As Exception
                intLogin = 100
                Throw New Exception(ex.Message)
            End Try
        End Sub
        ''' <summary>
        ''' Initializes the ii.
        ''' </summary>
        ''' <exception cref="Exception">
        ''' Devpp DLL not registered
        ''' or
        ''' </exception>
        Friend Sub initializeII()
            If Not DLLRegistered Then
                Throw New Exception("Devpp DLL not registered")
            End If

            Try

                checkSvrConnII()
                ConnectionStringII = "Data Source=" & ServerNameII & ";Initial Catalog=" & DatabaseNameII
                If exaWindowsAuthII = True Then
                    ConnectionStringII += ";integrated security=SSPI;persist security info=False; Trusted_Connection=Yes"
                Else
                    ConnectionStringII += ";User ID= " & SelectedUsername & ";Password=" & SelectedPassword
                End If
                _SQLConnII = New SqlConnection(ConnectionStringII)
                Dim conII As New SqlConnection(ConnectionStringII)
                Dim adpII As New SqlDataAdapter(CurentDate, conII)

            Catch ex As Exception
                intLogin = 100
                Throw New Exception(ex.Message)
            End Try
        End Sub
#End Region
#Region "Property"
        ''' <summary>
        ''' This is the get property returns database date and time
        ''' </summary>
        ''' <value>The get current date.</value>
        Public Shared ReadOnly Property GetCurrentDate() As Date
            Get
                Return _GetCurrentDate
            End Get
        End Property
        ''' <summary>
        ''' This is the get property returns number of rows for execution of stored procedure.
        ''' </summary>
        ''' <value>The return rows.</value>

        Public Shared ReadOnly Property ReturnRows() As Integer
            Get
                Return _ReturnRows
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets the image connection string.
        ''' </summary>
        ''' <value>The image connection string.</value>
        ''' <exception cref="Exception">Devpp DLL not registered</exception>
        Public Shared Property ImageConnectionString() As String
            Get
                If Not DLLRegistered Then
                    Throw New Exception("Devpp DLL not registered")
                End If
                Return _ImageConnectionString
            End Get
            Set(ByVal value As String)
                _ImageConnectionString = value
            End Set
        End Property
        ''' <summary>
        ''' Gets or sets the name of the server.
        ''' </summary>
        ''' <value>The name of the server.</value>
        Friend Shared Property ServerName() As String
            Get
                Return exaInstance
            End Get
            Set(ByVal value As String)
                exaInstance = value
            End Set
        End Property
        ''' <summary>
        ''' Gets or sets the name of the database.
        ''' </summary>
        ''' <value>The name of the database.</value>
        Friend Shared Property DatabaseName() As String
            Get
                Return exaDatabase
            End Get
            Set(ByVal value As String)
                exaDatabase = value
            End Set
        End Property
        ''' <summary>
        ''' Gets or sets the server name ii.
        ''' </summary>
        ''' <value>The server name ii.</value>
        Friend Shared Property ServerNameII() As String
            Get
                Return exaInstanceII
            End Get
            Set(ByVal value As String)
                exaInstanceII = value
            End Set
        End Property
        ''' <summary>
        ''' Gets or sets the database name ii.
        ''' </summary>
        ''' <value>The database name ii.</value>
        Friend Shared Property DatabaseNameII() As String
            Get
                Return exaDatabaseII
            End Get
            Set(ByVal value As String)
                exaDatabaseII = value
            End Set
        End Property
        ''' <summary>
        ''' Gets or sets a value indicating whether [selected win authentication].
        ''' </summary>
        ''' <value><c>true</c> if [selected win authentication]; otherwise, <c>false</c>.</value>
        Public Shared Property SelectedWinAuth() As Boolean
            Get
                Return exaWindowsAuth
            End Get
            Set(ByVal value As Boolean)
                exaWindowsAuth = value

            End Set
        End Property
        ''' <summary>
        ''' Gets or sets a value indicating whether [selected authentification ii].
        ''' </summary>
        ''' <value><c>true</c> if [selected authentification ii]; otherwise, <c>false</c>.</value>
        Friend Shared Property SelectedAuthentificationII() As Boolean
            Get
                Return exaWindowsAuthII
            End Get
            Set(ByVal value As Boolean)
                exaWindowsAuthII = value
            End Set
        End Property
        ''' <summary>
        ''' Set and Get property returns database username.
        ''' </summary>
        ''' <value>The selected username.</value>
        Public Shared Property SelectedUsername() As String
            Get
                Return exaUsername
            End Get
            Set(ByVal value As String)
                exaUsername = value
            End Set
        End Property
        ''' <summary>
        ''' This is the Set and Get property for database password
        ''' </summary>
        ''' <value>The selected password.</value>
        Public Shared Property SelectedPassword() As String
            Get
                Return exaPassword
            End Get
            Set(ByVal value As String)
                exaPassword = value
            End Set
        End Property
        ''' <summary>
        ''' This is the Set and Get Property for connection string.
        ''' </summary>
        ''' <value>The connection string.</value>
        ''' <exception cref="Exception">Devpp DLL not registered</exception>
        Public Shared Property ConnectionString() As String
            Get
                If Not DLLRegistered Then
                    Throw New Exception("Devpp DLL not registered")
                End If
                Return exaConnString
            End Get
            Set(ByVal value As String)
                exaConnString = value
            End Set
        End Property
        ''' <summary>
        ''' Gets or sets the connection string ii.
        ''' </summary>
        ''' <value>The connection string ii.</value>
        Public Shared Property ConnectionStringII() As String
            Get
                Return exaConnStringII
            End Get
            Set(ByVal value As String)
                exaConnStringII = value
            End Set
        End Property
        'Friend Shared Property WinAuth() As Boolean
        '    Get
        '        Return exaWindowsAuth
        '    End Get
        '    Set(ByVal value As Boolean)
        '        exaWindowsAuth = value

        '    End Set
        'End Property
        ''' <summary>
        ''' Gets or sets a value indicating whether [win authentication ii].
        ''' </summary>
        ''' <value><c>true</c> if [win authentication ii]; otherwise, <c>false</c>.</value>
        Friend Shared Property WinAuthII() As Boolean
            Get
                Return exaWindowsAuthII
            End Get
            Set(ByVal value As Boolean)
                exaWindowsAuthII = value
            End Set
        End Property
        ''' <summary>
        ''' This is the Set and Get Property for SQL Connection
        ''' </summary>
        ''' <value>The SQL connection.</value>
        Public Shared Property SQLConn() As SqlConnection
            Get
                Return _SQLConn
            End Get
            Set(ByVal value As SqlConnection)
                _SQLConn = value
            End Set
        End Property

#End Region
#Region "Methods"
        ''' <summary>
        ''' SQLs the data.
        ''' </summary>
        ''' <param name="val">if set to <c>true</c> [value].</param>
        Friend Shared Sub SQLData(ByVal val As Boolean)
            Security.UserManager.EndV_bool = True
        End Sub
        ''' <summary>
        ''' Gentbls the devpp user.
        ''' </summary>
        Private Sub gentblDevppUser()

            Dim con As New SqlConnection(ConnectionString)
            Dim com As New SqlCommand(sqltblDevppUser, con)
            Dim adp As New SqlDataAdapter(com)
            Dim v_datatable As New DataTable
            adp.Fill(v_datatable)

            com = New SqlCommand(My.Resources.DevppTables, con)
            con.Open()
            Try
                com.Parameters.Add("@usrPasswordChanged", SqlDbType.SmallDateTime)
                com.Parameters("@usrPasswordChanged").Value = GetCurrentDate
                com.ExecuteNonQuery()
                com = New SqlCommand(spDevppGetLogin, con)
                com.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception

                con.Close()
            End Try
            ' Else

            'End If



        End Sub
        ''' <summary>
        ''' Function for chacking connectivity.
        ''' </summary>
        ''' <returns>True or False</returns>
        Public Shared Function CheckServerConnection() As Boolean
            Return checkSvrConn()

        End Function
        ''' <summary>
        ''' Returns datatable contains database servers
        ''' </summary>
        ''' <returns>DataTable.</returns>
        ''' <exception cref="Exception"></exception>
        Public Shared Function getSqlInstances() As DataTable
            Try

                Dim i As Integer = 0
                Dim dtblInstances As New System.Data.DataTable
                '    Dim instance As SqlDataSourceEnumerator = SqlDataSourceEnumerator.Instance

                dtblInstances = SmoApplication.EnumAvailableSqlServers(False)

                '   dtblInstances = instance.GetDataSources()
                Dim dtblReturnInstances As New DataTable
                dtblReturnInstances.Columns.Add("Instance")
                For Each dr As DataRow In dtblInstances.Rows
                    dtblReturnInstances.Rows.Add(dr("Name"))
                Next
                Return dtblReturnInstances
            Catch ex As Exception
                Throw New Exception(ex.Message)
                Exit Function
            End Try
        End Function
        ''' <summary>
        ''' Checks the SVR connection.
        ''' </summary>
        ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        Private Shared Function checkSvrConn() As Boolean
            Try
                If SelectedWinAuth = True Then
                    Dim srvConn = New ServerConnection(exaInstance)
                    Dim srv = New Server(srvConn)
                    srvConn.Connect()
                    Return True
                Else
                    Dim srvConn = New ServerConnection(exaInstance, exaUsername, exaPassword)
                    srvConn.LoginSecure = False
                    Dim srv = New Server(srvConn)

                    srvConn.Connect()
                    Return True
                End If
                'Dim srvConn = New ServerConnection(exaInstance, exaUsername, exaPassword)
                'Dim srv = New Server(srvConn)
                'srvConn.Connect()
                'Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
        ''' <summary>
        ''' Checks the SVR connection ii.
        ''' </summary>
        ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        ''' <exception cref="Exception"></exception>
        Private Shared Function checkSvrConnII() As Boolean
            Try
                If WinAuthII = True Then
                    Dim srvConn = New ServerConnection(exaInstanceII)
                    Dim srv = New Server(srvConn)
                    srvConn.Connect()
                    Return True
                Else
                    Dim srvConn = New ServerConnection(exaInstanceII, exaUsername, exaPassword)
                    Dim srv = New Server(srvConn)
                    srvConn.Connect()
                    Return True
                End If


            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function
        ''' <summary>
        ''' Gets the type of the database.
        ''' </summary>
        ''' <param name="value">The value.</param>
        ''' <returns>System.Int32.</returns>
        Friend Shared Function GetDbType(ByVal value As String) As Integer
            Dim int As Integer = Nothing

            Select Case value.ToString
                Case "bigint"
                    Return 0
                Case "binary"
                    Return 1
                Case "bit"
                    Return 2
                Case "char"
                    Return 3
                Case "datetime"
                    Return 4
                Case "decimal"
                    Return 5
                Case "float"
                    Return 6
                Case "image"
                    Return 7
                Case "int"
                    Return 8
                Case "money"
                    Return 9
                Case "nchar"
                    Return 10
                Case "ntext"
                    Return 11
                Case "nvarchar"
                    Return 12
                Case "real"
                    Return 13
                Case "smalldatetime"
                    Return 15
                Case "smallint"
                    Return 16
                Case "smallmoney"
                    Return 17
                Case "text"
                    Return 18
                Case "timestamp"
                    Return 19
                Case "varchar"
                    Return 21
                Case "varbinary"
                    Return 22
                Case "date"
                    Return 31
                Case "time"
                    Return 32
                Case "uniqueidentifier"
                    Return 14
            End Select
            Return int
        End Function
        ''' <summary>
        ''' Reads the storedprocedure ii.
        ''' </summary>
        ''' <param name="spName">Name of the sp.</param>
        ''' <param name="spValue">The sp value.</param>
        ''' <exception cref="Exception">
        ''' </exception>
        Private Shared Sub ReadStoredprocedureII(ByVal spName As String, ByVal ParamArray spValue() As Object)

            Try

                checkSvrConnII()
                Dim con As New SqlConnection(ConnectionStringII)
                Dim uspParamCmd As New SqlCommand(ParamCmd, con)
                uspParamCmd.Parameters.Add("@spName", SqlDbType.NVarChar)
                uspParamCmd.Parameters("@spName").Value = spName
                Dim uspTable As New DataTable
                Dim adp As New SqlDataAdapter(uspParamCmd)
                adp.Fill(uspTable)
                Dim i As Integer = 0
                If uspTable.Rows.Count > 0 Then
                    If spValue.Length <> uspTable.Rows.Count Then
                        Throw New Exception(spName & " has " & CStr(uspTable.Rows.Count) & ", Only " & CStr(spValue.Length) & "have been passed")
                    End If
                End If
                Dim x As Integer = 0
                cmd = New SqlCommand()
                cmd.CommandText = spName
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Connection = con
                For Each rw As DataRow In uspTable.Rows
                    If rw(1) <> "sysname" Then
                        cmd.Parameters.Add(rw(0), CType(GetDbType(rw(1)), SqlDbType))
                        cmd.Parameters(rw(0).ToString).Value = spValue(x)
                    End If


                    x += 1
                Next

            Catch ex As Exception

                Throw New Exception(ex.Message)
            End Try
        End Sub
        ''' <summary>
        ''' Reads the storedprocedure.
        ''' </summary>
        ''' <param name="spName">Name of the sp.</param>
        ''' <param name="spValue">The sp value.</param>
        ''' <exception cref="Exception">
        ''' Devpp DLL not registered
        ''' or
        ''' or
        ''' </exception>
        Private Shared Sub ReadStoredprocedure(ByVal spName As String, ByVal ParamArray spValue() As Object)
            If Not DLLRegistered Then
                Throw New Exception("Devpp DLL not registered")
            End If
            Try

                GC.Collect()
                Dim con As New SqlConnection(ConnectionString)
                Dim uspParamCmd As New SqlCommand(ParamCmd, con)
                uspParamCmd.Parameters.Add("@spName", SqlDbType.NVarChar)
                uspParamCmd.Parameters("@spName").Value = spName
                Dim uspTable As New DataTable
                Dim adp As New SqlDataAdapter(uspParamCmd)
                adp.Fill(uspTable)
                Dim i As Integer = 0
                If uspTable.Rows.Count > 0 Then
                    If spValue.Length <> uspTable.Rows.Count Then
                        uspTable = Nothing
                        Throw New Exception(spName & " has " & CStr(uspTable.Rows.Count) & ", Only " & CStr(spValue.Length) & "have been passed")
                    End If
                End If
                Dim x As Integer = 0
                cmd = New SqlCommand()
                cmd.CommandText = spName
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Connection = con
                For Each rw As DataRow In uspTable.Rows
                    If rw(1) <> "sysname" Then
                        cmd.Parameters.Add(rw(0), CType(GetDbType(rw(1)), SqlDbType))
                        cmd.Parameters(rw(0).ToString).Value = spValue(x)
                    End If


                    x += 1
                Next
                uspTable = Nothing
            Catch ex As Exception

                Throw New Exception(ex.Message)
            End Try
        End Sub
        ''' <summary>
        ''' Execunting stored procedure and return Datatable.
        ''' </summary>
        ''' <param name="spName">Stored procedure name.</param>
        ''' <param name="spValue">Parameters for stored propcedure.</param>
        ''' <returns>Datatable</returns>
        ''' <exception cref="Exception"></exception>
        Public Shared Function GetSPDataTable(ByVal spName As String, ByVal ParamArray spValue() As Object) As DataTable
            ReadStoredprocedure(spName, spValue)
            Dim dtTable As New DataTable
            Try

                Dim sqlAdp As New SqlDataAdapter(cmd)
                sqlAdp.Fill(dtTable)
                sqlAdp.Dispose()
                sqlAdp = Nothing
                cmd.Dispose()
                cmd = Nothing
            Catch ex As Exception
                dtTable = Nothing
                cmd.Dispose()
                cmd = Nothing
                Throw New Exception(ex.Message)
            End Try
            Return dtTable
        End Function
        ''' <summary>
        ''' Gets the sp data table.
        ''' </summary>
        ''' <param name="spName">Name of the sp.</param>
        ''' <param name="colNameList">The col name list.</param>
        ''' <param name="ColType">Type of the col.</param>
        ''' <param name="addAtEnd">if set to <c>true</c> [add at end].</param>
        ''' <param name="spValue">The sp value.</param>
        ''' <returns>DataTable.</returns>
        ''' <exception cref="Exception">
        ''' Number of items in colName must be equal to coltype
        ''' or
        ''' Number of items in colName must be equal to coltype
        ''' or
        ''' </exception>
        Public Shared Function GetSPDataTable(ByVal spName As String, ByVal colNameList As List(Of String), ByVal ColType As List(Of Type), ByVal addAtEnd As Boolean, ByVal ParamArray spValue() As Object) As DataTable
            ReadStoredprocedure(spName, spValue)
            Dim dtTable As New DataTable

            Try
                If addAtEnd = False Then
                    For i As Integer = 0 To colNameList.Count - 1
                        If colNameList.Count <> ColType.Count Then
                            Throw New Exception("Number of items in colName must be equal to coltype")
                        End If
                        dtTable.Columns.Add(colNameList(i), ColType(i))
                    Next
                End If

                Dim sqlAdp As New SqlDataAdapter(cmd)
                sqlAdp.Fill(dtTable)
                If addAtEnd = True Then
                    For i As Integer = 0 To colNameList.Count - 1
                        If colNameList.Count <> ColType.Count Then
                            Throw New Exception("Number of items in colName must be equal to coltype")
                        End If
                        dtTable.Columns.Add(colNameList(i), ColType(i))
                    Next
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
            Return dtTable
        End Function
        ''' <summary>
        ''' Execute stored procedure and returns SQL Command
        ''' </summary>
        ''' <param name="spName">Stored procedure name</param>
        ''' <param name="spValue">Stored procedure parameter values</param>
        ''' <returns>SQL Command</returns>
        ''' <exception cref="Exception"></exception>
        Public Shared Function GetSPSQLCom(ByVal spName As String, ByVal ParamArray spValue() As Object) As SqlCommand
            ReadStoredprocedure(spName, spValue)

            Try
                Return cmd

            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function
        ''' <summary>
        ''' Execute stored procedure and returns true or false
        ''' </summary>
        ''' <param name="spName">Stored procedure name</param>
        ''' <param name="spValue">Stored procedure parameter values</param>
        ''' <returns>True or False</returns>
        ''' <exception cref="Exception"></exception>
        Public Shared Function GetSPBoolean(ByVal spName As String, ByVal ParamArray spValue() As Object) As Boolean
            ReadStoredprocedure(spName, spValue)
            Dim dtTable As New DataTable
            Try

                Dim sqlAdp As New SqlDataAdapter(cmd)
                sqlAdp.Fill(dtTable)
                dtTable.Dispose()
                dtTable = Nothing
                sqlAdp.Dispose()
                sqlAdp = Nothing
                cmd.Dispose()
                cmd = Nothing
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
            Return True
        End Function
        ''' <summary>
        ''' Runusps the ret bol ii.
        ''' </summary>
        ''' <param name="spName">Name of the sp.</param>
        ''' <param name="spValue">The sp value.</param>
        ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        ''' <exception cref="Exception"></exception>
        Public Shared Function RunuspRetBolII(ByVal spName As String, ByVal ParamArray spValue() As Object) As Boolean
            ReadStoredprocedureII(spName, spValue)
            Dim dtTable As New DataTable
            Try

                Dim sqlAdp As New SqlDataAdapter(cmd)
                sqlAdp.Fill(dtTable)
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
            Return True
        End Function
        ''' <summary>
        ''' Execute stored procedure and returns Report dataset
        ''' </summary>
        ''' <param name="uspName">Stored procedure name</param>
        ''' <param name="spValues">Stored procedure parameter values</param>
        ''' <returns>Report dataset</returns>
        ''' <exception cref="Exception"></exception>
        Public Shared Function GetSPReportDataSource(ByVal uspName As String, _
                                             ByVal ParamArray spValues() As Object) _
                                                As Microsoft.Reporting.WinForms.ReportDataSource
            ReadStoredprocedure(uspName, spValues)
            Dim Adapter As New SqlDataAdapter(cmd)
            Dim dtTable As New DataTable
            Try

                Adapter.Fill(dtTable)
                Dim dtSource As New Microsoft.Reporting.WinForms.ReportDataSource("dsReports_" & uspName, dtTable)
                _ReturnRows = dtTable.Rows.Count
                Return dtSource
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function
        ''' <summary>
        ''' Gets the sp report data source.
        ''' </summary>
        ''' <param name="DatatableName">Name of the datatable.</param>
        ''' <param name="DataTable">The data table.</param>
        ''' <returns>Microsoft.Reporting.WinForms.ReportDataSource.</returns>
        ''' <exception cref="Exception"></exception>
        Public Shared Function GetSPReportDataSource(ByVal DatatableName As String, _
                                             ByVal DataTable As DataTable) _
                                               As Microsoft.Reporting.WinForms.ReportDataSource

            Try


                Dim dtSource As New Microsoft.Reporting.WinForms.ReportDataSource("dsReports_" & DatatableName, DataTable)
                _ReturnRows = DataTable.Rows.Count
                Return dtSource
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function
        ''' <summary>
        ''' Execute stored procedure and returns Report dataset
        ''' </summary>
        ''' <param name="spName">Stored procedure name</param>
        ''' <returns>Dataset</returns>
        ''' <exception cref="Exception"></exception>
        Private Shared Function RunuspRetDset(ByVal spName As String) As DataSet
            ReadStoredprocedure(spName)
            Dim Ds As New DataSet
            Dim Adapter As New SqlDataAdapter(cmd)
            Try
                Adapter.Fill(Ds, "DataSet")
                _ReturnRows = Ds.Tables(0).Rows.Count
                Return Ds
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function
        ''' <summary>
        ''' Fuction for retrieving databases in a selected instance
        ''' </summary>
        ''' <param name="dbType">Option parameter for Database prefix</param>
        ''' <returns>Datatable</returns>
        ''' <exception cref="Exception"></exception>
        Public Shared Function getDatabases(Optional ByVal dbType As String = "") As DataTable
            Dim db As Database
            Try
                checkSvrConn()
                Dim srvConn = New ServerConnection()
                If SelectedWinAuth = True Then
                    srvConn = New ServerConnection(ServerName)
                Else
                    srvConn = New ServerConnection(exaInstance, exaUsername, exaPassword)
                End If

                Dim srv = New Server(srvConn)

                srvConn.Connect()
                Dim dtblReturnDatabses As New DataTable
                dtblReturnDatabses.Columns.Add("Database")
                For Each db In srv.Databases
                    If Not Right(db.Name, "_EXTRA".Length).Contains("_EXTRA") Then
                        If Left(db.Name, Len(db.Name)).Contains(dbType) Then
                            If Not db.IsSystemObject Then
                                dtblReturnDatabses.Rows.Add(db.Name)
                            End If
                        End If
                    End If
                Next
                Return dtblReturnDatabses
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try

        End Function
        ''' <summary>
        ''' Gets the databases ii.
        ''' </summary>
        ''' <param name="dbType">Type of the database.</param>
        ''' <returns>DataTable.</returns>
        ''' <exception cref="Exception"></exception>
        Public Shared Function getDatabasesII(Optional ByVal dbType As String = "") As DataTable
            Dim db As Database
            Try
                checkSvrConnII()
                Dim srvConn = New ServerConnection(exaInstanceII)
                Dim srv = New Server(srvConn)
                srvConn.Connect()
                Dim dtblReturnDatabses As New DataTable
                dtblReturnDatabses.Columns.Add("Database")
                For Each db In srv.Databases
                    If Left(db.Name, Len(db.Name)).Contains(dbType) Then
                        If Not db.IsSystemObject Then
                            dtblReturnDatabses.Rows.Add(db.Name)
                        End If
                    End If
                Next
                Return dtblReturnDatabses
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try

        End Function
#Region "Database Backup/Restore"
        ''' <summary>
        ''' The SQL restore
        ''' </summary>
        Private Shared WithEvents sqlRestore As New Restore()
        ''' <summary>
        ''' The function for database restoring
        ''' </summary>
        ''' <param name="RestoreDevppice">Location of backup</param>
        ''' <returns>True or False</returns>
        ''' <exception cref="Exception"></exception>
        Public Shared Function Restore(ByVal RestoreDevppice As String) As Boolean

            Dim strSQL As String = "SELECT     sys.master_files.type, sys.master_files.type_desc, sys.master_files.name, sys.master_files.physical_name, sys.databases.name AS DBName " & _
                                     " FROM         sys.master_files INNER JOIN " & _
                                                   "        sys.databases ON sys.master_files.database_id = sys.databases.database_id " & _
                                    "WHERE  sys.databases.name = @DBNname"

            Try
                sqlRestore = New Restore()

                Dim ioInf As New IO.FileInfo(RestoreDevppice)
                Dim srvConn = New ServerConnection(ServerName)

                If Not isWindowsAuthentication Then


                    srvConn = New ServerConnection(ServerName, SelectedUsername, SelectedPassword)
                    srvConn.LoginSecure = False
                End If
                Dim srv = New Server(srvConn)

                Dim resDevpp As New BackupDeviceItem()
                resDevpp.Name = RestoreDevppice
                resDevpp.DeviceType = DeviceType.File
                sqlRestore.Action = RestoreActionType.Database
                srvConn.Connect()
                sqlRestore.Database = exaDatabase
                Dim con As New SqlConnection(ConnectionString)
                Dim com As New SqlCommand(strSQL, con)
                com.Parameters.Add("@DBNname", SqlDbType.NChar).Value = exaDatabase
                Dim adpt As New SqlDataAdapter(com)
                Dim datTable As New DataTable
                adpt.Fill(datTable)
                Dim dataFileLocation As String = ioInf.Name.Replace(ioInf.Extension, "") & ".MDF"
                Dim logFileLocation As String = ioInf.Name.Replace(ioInf.Extension, "") & "_log.LDF"
                For Each dr As DataRow In datTable.Rows
                    If dr("Type") = 0 Then
                        dataFileLocation = dr("physical_name")

                    End If
                    If dr("Type") = 1 Then
                        logFileLocation = dr("physical_name")

                    End If
                Next
                sqlRestore.Devices.Add(resDevpp)
                Dim dtb As DataTable = sqlRestore.ReadFileList(srv)
                Dim str As String = ""
                Dim LogicalDat As String = ""
                Dim LogicalLog As String = ""
                For Each dr As DataRow In dtb.Rows
                    If dr("Type") = "D" Then
                        LogicalDat = dr(0)
                    End If
                    If dr("Type") = "L" Then
                        LogicalLog = dr(0)
                    End If
                Next
                Dim rf As New RelocateFile(exaDatabase, dataFileLocation)
                sqlRestore.RelocateFiles.Add(New RelocateFile(LogicalDat, dataFileLocation))
                sqlRestore.RelocateFiles.Add(New RelocateFile(LogicalLog, logFileLocation))
                sqlRestore.ReplaceDatabase = True
                srv.KillAllProcesses(exaDatabase)
                tm.Interval = 100
                tm.Enabled = True
                sqlRestore.SqlRestore(srv)
                srv.Refresh()
                '
                Return True
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Function for making database backup
        ''' </summary>
        ''' <param name="BackupDest">Destination location</param>
        ''' <param name="BackupInc">if set to <c>true</c> [backup inc].</param>
        ''' <returns>Location of the backup</returns>
        Public Shared Function backup(ByVal BackupDest As String, Optional ByVal BackupInc As Boolean = False) As String
            Dim TimeSuffix As String
            TimeSuffix = Format(Now, "ddMMyyy_HHmm")
            Dim BackType As String = "F"
            If BackupInc = True Then BackType = "I"
            If Not BackupDest.EndsWith("\") Then BackupDest += "\"
            Dim bkName As String = BackupDest & "DevppBck" & BackType & "_" & exaDatabase & "_" & TimeSuffix & ".ebk"
            Dim query As String = "BACKUP DATABASE [" & DatabaseName & "] TO  DISK = N'" & bkName & "' WITH NOFORMAT, NOINIT,  NAME = N'" & DatabaseName & "-Full Database Backup', SKIP, NOREWIND, NOUNLOAD,  STATS = 10"
            Dim con As New SqlClient.SqlConnection(ConnectionString)
            Dim com As New SqlCommand(query, con)
            con.Open()
            com.ExecuteNonQuery()
            con.Close()
            Return bkName

        End Function
#End Region
#End Region
        ''' <summary>
        ''' The tm
        ''' </summary>
        Private Shared WithEvents tm As New Windows.Forms.Timer
    End Class
End Namespace