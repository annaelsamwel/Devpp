' ***********************************************************************
' Assembly         : Dev++
' Author           : Annael
' Created          : 08-18-2014
'
' Last Modified By : user
' Last Modified On : 10-11-2013
' ***********************************************************************
' <copyright file="DBInitialization.vb" company="Annael">
'     Copyright © Annael 2010
' </copyright>
' <summary></summary>
' ***********************************************************************
Imports Microsoft.SqlServer.Management.Smo
Imports Microsoft.SqlServer.Management.Smo.Wmi
Imports Microsoft.SqlServer.Management.Common
Imports System.Windows.Forms
''' <summary>
''' This is the friend function used to manage initialization of new Database
''' Created by Annael Samwel
''' </summary>
Public Class DBInitialization
#Region "Fields"
    ''' <summary>
    ''' The _is new database
    ''' </summary>
    Private Shared _isNewDB As Boolean
    ''' <summary>
    ''' The _ new database
    ''' </summary>
    Private Shared _NewDB As String
    ''' <summary>
    ''' The _ demo database
    ''' </summary>
    Private Shared _DemoDB As String
    ''' <summary>
    ''' The _ sever name
    ''' </summary>
    Private Shared _SeverName As String
    ''' <summary>
    ''' The _ database attach option
    ''' </summary>
    Private Shared _DatabaseAttachOption As AttachOptions
    ''' <summary>
    ''' The time
    ''' </summary>
    Private Shared WithEvents time As Windows.Forms.Timer
    ''' <summary>
    ''' The devpp user
    ''' </summary>
    Private Const DevppUser As String = "DevppBuiltIn"
    ''' <summary>
    ''' The devpp pass
    ''' </summary>
    Private Const DevppPass As String = "!ob1Devpp2008"
    ''' <summary>
    ''' The server shuted down
    ''' </summary>
    Public Shared ServerShutedDown As Boolean

    ''' <summary>
    ''' The year2
    ''' </summary>
    Friend Shared Year2 As String = "0"
#End Region
#Region "Property"

    ''' <summary>
    ''' Gets or sets a value indicating whether this instance is new bd.
    ''' </summary>
    ''' <value><c>true</c> if this instance is new bd; otherwise, <c>false</c>.</value>
    Friend Shared Property isNewBD() As Boolean
        Get
            Return _isNewDB
        End Get
        Set(ByVal value As Boolean)
            _isNewDB = value
        End Set
    End Property
    ''' <summary>
    ''' The database user name
    ''' </summary>
    Friend Shared DbUserName As String
    ''' <summary>
    ''' The database password
    ''' </summary>
    Friend Shared DBPassword As String
    ''' <summary>
    ''' The _ instance name
    ''' </summary>
    Private Shared _InstanceName As String
    ''' <summary>
    ''' The st bar
    ''' </summary>
    Friend Shared stBar As Windows.Forms.ProgressBar
    ''' <summary>
    ''' The label service
    ''' </summary>
    Friend Shared lblService As Windows.Forms.Label
    ''' <summary>
    ''' Gets or sets the name of the database instance.
    ''' </summary>
    ''' <value>The name of the database instance.</value>
    Friend Shared Property DBInstanceName() As String
        Get
            Return _InstanceName
        End Get
        Set(ByVal value As String)
            _InstanceName = value
        End Set
    End Property
    ''' <summary>
    ''' Attaches the specified database name.
    ''' </summary>
    ''' <param name="dbName">Name of the database.</param>
    ''' <param name="InstanceName">Name of the instance.</param>
    Friend Shared Sub Attach(ByVal dbName, ByVal InstanceName)
        Devpp.Data.SQLSERVER.ServerName = InstanceName
        Devpp.Data.SQLSERVER.DatabaseName = "master"
        Devpp.Data.SQLSERVER.ConnectionString = "Data Source=" & InstanceName & ";Initial Catalog= master"
        If Data.SQLSERVER.SelectedWinAuth = True Then
            Devpp.Data.SQLSERVER.ConnectionString += ";integrated security=SSPI;persist security info=False; Trusted_Connection=Yes"
        Else
            Devpp.Data.SQLSERVER.ConnectionString += ";User ID= " & DbUserName & ";Password=" & DBPassword
        End If
        Dim con As New SqlClient.SqlConnection(Devpp.Data.SQLSERVER.ConnectionString)
    End Sub
    ''' <summary>
    ''' Method used to create database and manage security of the database
    ''' </summary>
    ''' <param name="dbName">Is the name of the new database</param>
    ''' <param name="InstanceName">Is the name of the instance for creation of new database</param>
    ''' <param name="MasterDB">Is the master database in the selected instance</param>
    ''' <param name="DBQuery">This are the query for database creation</param>
    ''' <exception cref="System.Exception">
    ''' Restarting service fail
    ''' or
    ''' Failed to re-connect
    ''' or
    ''' Failed to re-connect.
    ''' or
    ''' Failed to delete:  & V_str
    ''' or
    ''' or
    ''' or
    ''' </exception>
    Public Shared Sub Initialize(ByVal dbName As String, ByVal InstanceName As String, ByVal MasterDB As String, ByVal DBQuery As String)

        Devpp.Data.SQLSERVER.ServerName = InstanceName
        Devpp.Data.SQLSERVER.DatabaseName = MasterDB
        Devpp.Data.SQLSERVER.ConnectionString = "Data Source = " & InstanceName & "; Initial Catalog = " & MasterDB

        AddLogFile(Now & " Checking database login authentication ")
        If Data.SQLSERVER.SelectedWinAuth = True Then
            Devpp.Data.SQLSERVER.ConnectionString += ";integrated security=SSPI;persist security info=False; Trusted_Connection=Yes"

            AddLogFile(Now & " Detecting current authentication is: windows  ")
        Else
            Devpp.Data.SQLSERVER.ConnectionString += ";User ID= " & DbUserName & ";Password=" & DBPassword

            AddLogFile(Now & " Detecting current authentication is: SQLSERVER  ")
        End If
        Dim con As New SqlClient.SqlConnection(Devpp.Data.SQLSERVER.ConnectionString)
        Try
            Dim serv As New Server()
            serv.ConnectionContext.ConnectionString = Data.SQLSERVER.ConnectionString
            If ucDbUtilities.isDevppAllowed = True Then
                AddLogFile(Now & " Checking database login mode ")
                If serv.Settings.LoginMode <> ServerLoginMode.Mixed Then
                    AddLogFile(Now & " Detected database login is not mixed mode ")
                    serv.Settings.LoginMode = ServerLoginMode.Mixed
                    serv.Alter()
                    AddLogFile(Now & " Chenging database login to mixed mode ")
                    ServerShutedDown = True
                End If
            End If

            AddLogFile(Now & " Checking if Devpp SOFTWARE user exists ")

            Dim isDevppBulitInExists As Boolean = False
            For Each log As Login In serv.Logins
                If log.Name = DevppUser Then


                    If log.Name = DevppUser Then
                        isDevppBulitInExists = True
                        AddLogFile(Now & " Devpp user exists ")
                        Exit For
                    End If

                End If
            Next
            If con.State = ConnectionState.Closed Then con.Open()
            If isDevppBulitInExists = False Then
                AddLogFile(Now & " Creating Devpp user ")
                Dim com1 As New SqlClient.SqlCommand("CREATE LOGIN [" & DevppUser & "] WITH PASSWORD=N'" & DevppPass & "', DEFAULT_DATABASE=[master], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF", con)
                com1.ExecuteNonQuery()
                com1 = New SqlClient.SqlCommand("EXEC master..sp_addsrvrolemember @loginame = N'" & DevppUser & "', @rolename = N'sysadmin'", con)
                com1.ExecuteNonQuery()
                AddLogFile(Now & " Creating Devpp user completed successfully ")
                con.Close()


            End If


            If ServerShutedDown = True Then
                AddLogFile(Now & " Restarting service. ")

                Try
                    Dim ServiceQuery As String = "SELECT * FROM sys.dm_server_registry Where value_name = 'DependOnService'"
                    Dim adp As New SqlClient.SqlDataAdapter(ServiceQuery, con)
                    Dim ServiedtTable As New DataTable
                    adp.Fill(ServiedtTable)
                    Dim Srv As String = ServiedtTable.Rows(0)("value_data")
                    Dim theController As New System.ServiceProcess.ServiceController(Srv)
                    theController.Stop()

                    theController.WaitForStatus(ServiceProcess.ServiceControllerStatus.Stopped)
                    theController.Start()
                    theController.WaitForStatus(ServiceProcess.ServiceControllerStatus.Running)


                    AddLogFile(Now & " Restarting service completed successfully. ")
                    ServerShutedDown = False
                Catch ex As Exception
                    Throw New Exception("Restarting service fail")
                End Try

            End If
            'Test to connect with Devpp Built In================================
            If isDevppBulitInExists = False Then
                Try
                    AddLogFile(Now & " Test to connect using Devpp user. ")
                    Devpp.Data.SQLSERVER.ConnectionString = "Data Source=" & InstanceName & ";Initial Catalog=" & MasterDB
                    Devpp.Data.SQLSERVER.ConnectionString += ";User ID= " & DevppUser & ";Password=" & DevppPass
                    Devpp.Data.SQLSERVER.SelectedWinAuth = False
                    Dim TestCon As New SqlClient.SqlConnection(Devpp.Data.SQLSERVER.ConnectionString)
                    Dim TestQuery As String = "SELECT TOP 1 * FROM sys.Databases"
                    Dim Testadp As New SqlClient.SqlDataAdapter(TestQuery, TestCon)
                    Dim TestDt As New DataTable
                    Testadp.Fill(TestDt)
                    AddLogFile(Now & " User connected successfully.")
                Catch ex As Exception
                    Throw New Exception("Failed to re-connect.")
                End Try
            End If

            '====================================================================

            '========================CHECKING NON-Devpp USERS===================
            Dim SQLServer As New Server()
            SQLServer.ConnectionContext.ConnectionString = Data.SQLSERVER.ConnectionString
            Dim lstUser As New List(Of String)

            For Each log As Login In SQLServer.Logins
                If log.Name <> DevppUser Then
                    If log.Name <> "sa" Then
                        lstUser.Add(log.Name)
                    End If

                End If
            Next
            '================================================================

            'DELETING NON-Devpp USER=========================================
            If lstUser.Count > 0 Then
                AddLogFile(Now & " Deleting non-Devpp database logins.")
                Try
                    Dim MyConnection As New SqlClient.SqlConnection(Data.SQLSERVER.ConnectionString)
                    For Each V_str As String In lstUser
                        Try
                            Dim myCom As New SqlClient.SqlCommand("DROP LOGIN [" & V_str & "]", MyConnection)
                            If MyConnection.State = ConnectionState.Closed Then MyConnection.Open()
                            myCom.ExecuteNonQuery()

                        Catch ex As Exception
                            MyConnection.Close()
                            ' Throw New Exception("Failed to delete: " & V_str)

                        End Try
                    Next
                    AddLogFile(Now & " Deleting non-Devpp database logins completed successfully.")
                    MyConnection.Close()
                Catch ex As Exception
                    ''  Throw New Exception(ex.Message)
                End Try
            End If
            '=====================================================================


            '===============Creating new database=================================
            Try
                Dim MyConnection As New SqlClient.SqlConnection(Data.SQLSERVER.ConnectionString)
                AddLogFile(Now & " Creating new database name: " & dbName)
                Dim CreateQuery As String = "CREATE DATABASE " & dbName

                Dim CreateCom As New SqlClient.SqlCommand(CreateQuery, MyConnection)
                Dim adp As New SqlClient.SqlDataAdapter(_SQLDBPhysicalLocation, MyConnection)


                Dim dt As New DataTable
                adp.Fill(dt)

                If dt.Rows.Count > 0 Then
                    Dim fileInf As New IO.FileInfo(dt.Rows(0)(0))
                    DBPhysicalLocation = fileInf.DirectoryName

                End If

                MyConnection.Open()
                CreateCom.ExecuteNonQuery()
                MyConnection.Close()
                AddLogFile(Now & " Database created successfully ")
            Catch ex As Exception

                con.Close()
                Throw New Exception(ex.Message)
            End Try
            '=====================================================================


            '==================Connecting to new database and run script=====================
            AddLogFile(Now & " Re-connecting to " & dbName)
            Devpp.Data.SQLSERVER.DatabaseName = dbName
            Devpp.Data.SQLSERVER.ConnectionString = "Data Source=" & InstanceName & ";Initial Catalog=" & dbName
            Devpp.Data.SQLSERVER.ConnectionString += ";User ID= " & DevppUser & ";Password=" & DevppPass
            Devpp.Data.SQLSERVER.DatabaseName = dbName
            Devpp.Data.SQLSERVER.ServerName = InstanceName
            Devpp.Data.SQLSERVER.SelectedWinAuth = False


            con = New SqlClient.SqlConnection(Devpp.Data.SQLSERVER.ConnectionString)
            Dim sqlcom As New SqlClient.SqlCommand

            If isNewBD = True Then
                sqlcom = New SqlClient.SqlCommand(DBQuery, con)

            Else
                sqlcom = New SqlClient.SqlCommand(DBQuery, con)

            End If
            con.Open()
            sqlcom.ExecuteNonQuery()
            con.Close()
            AddLogFile(Now & " Connected to " & dbName & " completed successfully")

            ' DBInstanceName = serv.InstanceName
            '====================================================================
        Catch ex As Exception

            Throw New Exception(ex.Message)
        End Try
    End Sub
#End Region

    ''' <summary>
    ''' Initializes a new instance of the <see cref="DBInitialization"/> class.
    ''' </summary>
    ''' <exception cref="System.Exception">Devpp DLL not registered</exception>
    Public Sub New()
        If Not DLLRegistered Then
            Throw New Exception("Devpp DLL not registered")
        End If
    End Sub
End Class
