' ***********************************************************************
' Assembly         : Dev++
' Author           : Annael Samwel
' Created          : 08-18-2014
'
' Last Modified By : user
' Last Modified On : 09-09-2011
' ***********************************************************************
' <copyright file="ModApplication.vb" company="Annael">
'     Copyright © Annael 2010
' </copyright>
' <summary></summary>
' ***********************************************************************
Imports System.Xml
Imports Microsoft.VisualBasic.ApplicationServices.WindowsFormsApplicationBase
Imports System.IO
Imports System.Windows.Forms
#Const ComKey = ""
''' <summary>
''' This is the public module for defining public information
''' Created by Annael Samwel
''' </summary>
Public Module [Global]
    ''' <summary>
    ''' The _ show version control
    ''' </summary>
    Private _ShowVersionControl As Boolean = True
    ''' <summary>
    ''' The _ create devpp tables
    ''' </summary>
    Private _CreateDevppTables As Boolean = True
    ''' <summary>
    ''' The _ use confing file
    ''' </summary>
    Private _UseConfingFile As Boolean = True
    ''' <summary>
    ''' The _ splash screen status
    ''' </summary>
    Private _SplashScreenStatus As String
    ''' <summary>
    ''' The notfy
    ''' </summary>
    Friend WithEvents notfy As New Windows.Forms.NotifyIcon
    ''' <summary>
    ''' The login status
    ''' </summary>
    Friend LoginStatus As Boolean
    ''' <summary>
    ''' The is connected
    ''' </summary>
    Friend isConnected As Boolean
    ''' <summary>
    ''' The is fromfrm login
    ''' </summary>
    Friend isFromfrmLogin As Boolean
    ''' <summary>
    ''' The common default
    ''' </summary>
    Friend commonDefault As Boolean
    ''' <summary>
    ''' The _ application location
    ''' </summary>
    Private _ApplicationLocation As String
    ''' <summary>
    ''' The _ allow secend connection
    ''' </summary>
    Private _AllowSecendConnection As Boolean
    ''' <summary>
    ''' The _ script data table
    ''' </summary>
    Private _ScriptDataTable As New DataTable
    ''' <summary>
    ''' The database physical location
    ''' </summary>
    Friend DBPhysicalLocation As String
    ''' <summary>
    ''' The _ client script version
    ''' </summary>
    Friend _ClientScriptVersion As Integer
    ''' <summary>
    ''' The _ devpp script version
    ''' </summary>
    Friend _DevppScriptVersion As Integer
    ''' <summary>
    ''' The _ database application version
    ''' </summary>
    Friend _DBApplicationVersion As Integer
    ''' <summary>
    ''' The _ log file
    ''' </summary>
    Private _LogFile As String
    ''' <summary>
    ''' The _ contact table
    ''' </summary>
    Friend _ContactTable As New DataTable
    ''' <summary>
    ''' The contact SQL
    ''' </summary>
    Friend ContactSQL As String
    ''' <summary>
    ''' The _TXT rich box
    ''' </summary>
    Private _txtRichBox As New Windows.Forms.RichTextBox
    ''' <summary>
    ''' The _ DLL registered
    ''' </summary>
    Private _DLLRegistered As Boolean = True
    ''' <summary>
    ''' The _ user query
    ''' </summary>
    Private _UserQuery As String
    ''' <summary>
    ''' The _ where initialize user query
    ''' </summary>
    Private _WhereInitUserQuery As Boolean
    ''' <summary>
    ''' The _is comclass
    ''' </summary>
    Private _isComclass As Boolean
    ''' <summary>
    ''' The _ application version
    ''' </summary>
    Private _ApplicationVersion As Integer
    ''' <summary>
    ''' The _ configuration file
    ''' </summary>
    Private _ConfigFile As String
    ''' <summary>
    ''' The _is licensed
    ''' </summary>
    Private _isLicensed As Boolean = False
    ''' <summary>
    ''' The _ license stream
    ''' </summary>
    Private _LicenseStream As Integer
    ''' <summary>
    ''' The _ license number
    ''' </summary>
    Private _LicenseNumber As Integer
    ''' <summary>
    ''' The _ license date
    ''' </summary>
    Private _LicenseDate As Integer
    ''' <summary>
    ''' The _ licensed employees
    ''' </summary>
    Private _LicensedEmployees As Integer

    ''' <summary>
    ''' The _is logged in
    ''' </summary>
    Friend _isLoggedIn As Boolean
    ''' <summary>
    ''' The _ application title
    ''' </summary>
    Friend _ApplicationTitle As String = ""
    ''' <summary>
    ''' The _ application display version
    ''' </summary>
    Friend _ApplicationDisplayVersion As String = ""
    ''' <summary>
    ''' The _ application description
    ''' </summary>
    Friend _ApplicationDescription As String
    ''' <summary>
    ''' The _ application copyright
    ''' </summary>
    Friend _ApplicationCopyright As String
    ''' <summary>
    ''' The company query
    ''' </summary>
    Friend CompanyQuery As String = ""
    ''' <summary>
    ''' The not allowed no license message
    ''' </summary>
    Public Const NotAllowedNoLicenseMessage As String = "Action not allowed while in un-licensed mode"
    ''' <summary>
    ''' Gets the company.
    ''' </summary>
    ''' <param name="TableName">Name of the table.</param>
    ''' <param name="IDColumn">The identifier column.</param>
    ''' <param name="DisplayColumn">The display column.</param>
    ''' <param name="Filter">The filter.</param>
    Public Sub GetCompany(ByVal TableName As String, ByVal IDColumn As String, ByVal DisplayColumn As String, Optional ByVal Filter As String = "Where Column = Value")
        Dim TestQuery As String = "SELECT " & IDColumn & ", " & DisplayColumn & " FROM [" & TableName & "]"
        Dim WHERE As String = ""
        If Filter <> "Where Column = Value" Then
            WHERE = Filter
        End If
        TestQuery += WHERE & "ORDER BY " & DisplayColumn
        Dim con As New System.Data.SQLClient.SqlConnection(Data.SQLSERVER.ConnectionString)

        CompanyQuery = TestQuery


    End Sub
    ''' <summary>
    ''' Gets or sets a value indicating whether [use configuration file].
    ''' </summary>
    ''' <value><c>true</c> if [use configuration file]; otherwise, <c>false</c>.</value>
    Public Property UseConfigFile() As Boolean
        Get
            Return _UseConfingFile
        End Get
        Set(ByVal value As Boolean)
            _UseConfingFile = value
        End Set
    End Property
    ''' <summary>
    ''' Gets or sets a value indicating whether [create devpp tables].
    ''' </summary>
    ''' <value><c>true</c> if [create devpp tables]; otherwise, <c>false</c>.</value>
    Public Property CreateDevppTables() As Boolean
        Get
            Return _CreateDevppTables
        End Get
        Set(ByVal value As Boolean)
            _CreateDevppTables = value
        End Set
    End Property
    ''' <summary>
    ''' Sets the application title.
    ''' </summary>
    ''' <value>The application title.</value>
    Public WriteOnly Property ApplicationTitle() As String
        Set(ByVal value As String)
            _ApplicationTitle = value
        End Set
    End Property
    ''' <summary>
    ''' Gets or sets a value indicating whether [show version control].
    ''' </summary>
    ''' <value><c>true</c> if [show version control]; otherwise, <c>false</c>.</value>
    Public Property ShowVersionControl() As Boolean
        Get
            Return _ShowVersionControl
        End Get
        Set(ByVal value As Boolean)
            _ShowVersionControl = value
        End Set
    End Property
    ''' <summary>
    ''' Sets the application display version.
    ''' </summary>
    ''' <value>The application display version.</value>
    Public WriteOnly Property ApplicationDisplayVersion() As String
        Set(ByVal value As String)
            _ApplicationDisplayVersion = value
        End Set
    End Property
    ''' <summary>
    ''' Sets the application description.
    ''' </summary>
    ''' <value>The application description.</value>
    Public WriteOnly Property ApplicationDescription() As String
        Set(ByVal value As String)
            _ApplicationDescription = value
        End Set
    End Property
    ''' <summary>
    ''' Sets the application copyright.
    ''' </summary>
    ''' <value>The application copyright.</value>
    Public WriteOnly Property ApplicationCopyright() As String
        Set(ByVal value As String)
            _ApplicationCopyright = value
        End Set
    End Property

    ''' <summary>
    ''' Gets a value indicating whether this instance is logged in.
    ''' </summary>
    ''' <value><c>true</c> if this instance is logged in; otherwise, <c>false</c>.</value>
    Public ReadOnly Property isLoggedIn() As Boolean
        Get
            Return _isLoggedIn
        End Get
    End Property
    ''' <summary>
    ''' Gets or sets the configuration file.
    ''' </summary>
    ''' <value>The configuration file.</value>
    Public Property ConfigFile() As String
        Get
            Return _ConfigFile
        End Get
        Set(ByVal value As String)
            _ConfigFile = value
        End Set
    End Property



    ''' <summary>
    ''' Gets or sets a value indicating whether this instance is licensed.
    ''' </summary>
    ''' <value><c>true</c> if this instance is licensed; otherwise, <c>false</c>.</value>
    Public Property isLicensed() As Boolean
        Get
            Return _isLicensed
        End Get
        Set(ByVal value As Boolean)
            _isLicensed = value
        End Set
    End Property
    ''' <summary>
    ''' Gets or sets the license stream.
    ''' </summary>
    ''' <value>The license stream.</value>
    Public Property LicenseStream() As Integer
        Get
            Return _LicenseStream
        End Get
        Set(ByVal value As Integer)
            _LicenseStream = value
        End Set
    End Property
    ''' <summary>
    ''' Gets or sets the license number.
    ''' </summary>
    ''' <value>The license number.</value>
    Public Property LicenseNumber() As Integer
        Get
            Return _LicenseNumber
        End Get
        Set(ByVal value As Integer)
            _LicenseNumber = value
        End Set
    End Property
    ''' <summary>
    ''' Gets or sets the license date.
    ''' </summary>
    ''' <value>The license date.</value>
    Public Property LicenseDate() As Integer
        Get
            Return _LicenseDate
        End Get
        Set(ByVal value As Integer)
            _LicenseDate = value
        End Set
    End Property
    ''' <summary>
    ''' Gets or sets the licensed employees.
    ''' </summary>
    ''' <value>The licensed employees.</value>
    Public Property LicensedEmployees() As Integer
        Get
            Return _LicensedEmployees
        End Get
        Set(ByVal value As Integer)
            _LicensedEmployees = value
        End Set
    End Property


    ''' <summary>
    ''' Gets or sets the application version.
    ''' </summary>
    ''' <value>The application version.</value>
    Public Property applicationVersion() As Integer
        Get
            If isComclass Then
                Return _ApplicationVersion
            Else
                Return My.Application.Info.Version.MinorRevision
            End If
        End Get
        Set(ByVal value As Integer)
            _ApplicationVersion = value
        End Set
    End Property
    ''' <summary>
    ''' Gets or sets a value indicating whether this instance is comclass.
    ''' </summary>
    ''' <value><c>true</c> if this instance is comclass; otherwise, <c>false</c>.</value>
    Public Property isComclass() As Boolean
        Get
            Return _isComclass
        End Get
        Set(ByVal value As Boolean)
            _isComclass = value
        End Set
    End Property
    ''' <summary>
    ''' Gets the where initialize user query.
    ''' </summary>
    ''' <value>The where initialize user query.</value>
    Friend ReadOnly Property WhereInitUserQuery()
        Get
            Return _WhereInitUserQuery
        End Get
    End Property
    ''' <summary>
    ''' Gets the user query.
    ''' </summary>
    ''' <value>The user query.</value>
    Friend ReadOnly Property UserQuery() As String
        Get
            Return _UserQuery
        End Get
    End Property

    ''' <summary>
    ''' Gets or sets a value indicating whether [DLL registered].
    ''' </summary>
    ''' <value><c>true</c> if [DLL registered]; otherwise, <c>false</c>.</value>
    Public Property DLLRegistered() As Boolean
        Get
            Return _DLLRegistered
        End Get
        Set(ByVal value As Boolean)
            _DLLRegistered = value
        End Set
    End Property
    ''' <summary>
    ''' Gets or sets the application location.
    ''' </summary>
    ''' <value>The application location.</value>
    Public Property ApplicationLocation() As String
        Get
            If _ApplicationLocation = "" Then
                Try
                    Dim filiInf As New IO.FileInfo(System.Windows.Forms.Application.ExecutablePath) 'Telling the DLL Location of EXE
                    _ApplicationLocation = filiInf.DirectoryName
                Catch ex As Exception

                End Try
            End If
            Return _ApplicationLocation
        End Get
        Set(ByVal value As String)
            _ApplicationLocation = value
        End Set
    End Property
    ''' <summary>
    ''' Gets or sets the text rich box.
    ''' </summary>
    ''' <value>The text rich box.</value>
    Friend Property txtRichBox() As Windows.Forms.RichTextBox
        Get
            Return _txtRichBox
        End Get
        Set(ByVal value As Windows.Forms.RichTextBox)
            _txtRichBox = value
        End Set
    End Property
    ''' <summary>
    ''' Gets or sets the splash screen status.
    ''' </summary>
    ''' <value>The splash screen status.</value>
    Public Property SplashScreenStatus() As String
        Get
            Return _SplashScreenStatus
        End Get
        Set(ByVal value As String)
            _SplashScreenStatus = value
        End Set
    End Property
    ''' <summary>
    ''' Gets the contact table.
    ''' </summary>
    ''' <value>The contact table.</value>
    Friend ReadOnly Property ContactTable() As DataTable
        Get
            Return _ContactTable
        End Get
    End Property
    ''' <summary>
    ''' Initializes the contact.
    ''' </summary>
    ''' <param name="TableName">Name of the table.</param>
    ''' <param name="IDColumn">The identifier column.</param>
    ''' <param name="FirstNameColumn">The first name column.</param>
    ''' <param name="MiddleName">Name of the middle.</param>
    ''' <param name="LastName">The last name.</param>
    ''' <param name="ExatraFilter">The exatra filter.</param>
    Public Sub InitContact(ByVal TableName As String, ByVal IDColumn As String, ByVal FirstNameColumn As String, Optional ByVal MiddleName As String = "", Optional ByVal LastName As String = "", Optional ByVal ExatraFilter As String = "CulumnName=Value")
        ContactSQL = "SELECT " & IDColumn & " AS ID, isNull(" & FirstNameColumn & ", '')" & _
        IIf(MiddleName = "", "", " + ' ' + isNull(" & MiddleName & ", '')") & _
         IIf(LastName = "", "", " + ' ' + isNull(" & LastName & ", '')") & " AS FullName FROM " & TableName
        _UserQuery = "SELECT " & FirstNameColumn & IIf(MiddleName = "", "", ", " & MiddleName) & IIf(LastName = "", "", ", " & LastName) & " FROM " & TableName & vbNewLine
        If ExatraFilter <> "CulumnName=Value" Then
            ContactSQL = ContactSQL & " WHERE " & ExatraFilter
            _UserQuery = _UserQuery & " WHERE " & ExatraFilter
            _WhereInitUserQuery = True

        End If
    End Sub


    ''' <summary>
    ''' Gets the database application version.
    ''' </summary>
    ''' <value>The database application version.</value>
    Public ReadOnly Property DBApplicationVersion() As Integer
        Get
            Return _DBApplicationVersion
        End Get
    End Property
    ''' <summary>
    ''' Adds the log file.
    ''' </summary>
    ''' <param name="Text">The text.</param>
    ''' <param name="FileName">Name of the file.</param>
    ''' <param name="Title">The title.</param>
    ''' <exception cref="Exception"></exception>
    Friend Sub AddLogFile(ByVal Text As String, Optional ByVal FileName As String = "", Optional ByVal Title As String = "")

        Try
            DBInitialization.lblService.Text = Text
            Application.DoEvents()
            If DBInitialization.stBar.Value = 100 Then
                DBInitialization.stBar.Value = 0
                Application.DoEvents()
            End If
            DBInitialization.stBar.Value += 2
            Application.DoEvents()
        Catch ex As Exception

        End Try
        Try
            If FileName <> "" Then
                _LogFile = "Log_" & IIf(Today.Day < 10, "0" & Today.Day, Today.Day) & IIf(Today.Month < 10, "0" & Today.Month, Today.Month) & "" & Today.Year & "_" & FileName
            End If
            If _LogFile = "" Then
                _LogFile = "Log_" & IIf(Today.Day < 10, "0" & Today.Day, Today.Day) & IIf(Today.Month < 10, "0" & Today.Month, Today.Month) & "" & Today.Year & "_log.txt"
            End If

            If Not My.Computer.FileSystem.FileExists(ApplicationLocation & "\" & _LogFile) Then
                Dim fs As New IO.StreamWriter(ApplicationLocation & "\" & _LogFile)
                fs.WriteLine(Now)
                fs.Close()

            End If
            Dim strwrite As New IO.StreamWriter(ApplicationLocation & "\" & _LogFile, True)
            If Title = "" Then
                strwrite.WriteLine(Text)


            Else
                strwrite.WriteLine(vbNewLine & Title)


                strwrite.WriteLine(Text)
                Try


                Catch ex As Exception

                End Try
            End If
            strwrite.Close()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    ''' <summary>
    ''' Gets the log file.
    ''' </summary>
    ''' <value>The log file.</value>
    Public ReadOnly Property LogFile() As String
        Get
            Return _LogFile
        End Get
    End Property
    ''' <summary>
    ''' Gets the client script version.
    ''' </summary>
    ''' <value>The client script version.</value>
    Public ReadOnly Property ClientScriptVersion() As Integer
        Get
            Return _ClientScriptVersion
        End Get
    End Property
    ''' <summary>
    ''' Gets the devpp script version.
    ''' </summary>
    ''' <value>The devpp script version.</value>
    Public ReadOnly Property DevppScriptVersion() As Integer
        Get
            Return _DevppScriptVersion
        End Get
    End Property
    ''' <summary>
    ''' Gets or sets the script data table.
    ''' </summary>
    ''' <value>The script data table.</value>
    ''' <exception cref="Exception">
    ''' Script table contain unknown columns
    ''' or
    ''' Script table many columns
    ''' or
    ''' Script table few columns
    ''' </exception>
    Public Property ScriptDataTable() As DataTable
        Get
            Return _ScriptDataTable
        End Get
        Set(ByVal value As DataTable)
            'Other Column for Extra = Extra
            If value.Columns(0).ColumnName <> "ScriptName" Or value.Columns(1).ColumnName <> "MDF" Or value.Columns(2).ColumnName <> "LDF" Or value.Columns(3).ColumnName <> "ScriptValue" Or value.Columns(4).ColumnName <> "Backup" Then

                Throw New Exception("Script table contain unknown columns")
            End If
            If value.Columns.Count > 6 Then
                Throw New Exception("Script table many columns")
            End If
            If value.Columns.Count < 5 Then
                Throw New Exception("Script table few columns")
            End If
            _ScriptDataTable = value
        End Set
    End Property
    ''' <summary>
    ''' Gets or sets a value indicating whether [allow second connection].
    ''' </summary>
    ''' <value><c>true</c> if [allow second connection]; otherwise, <c>false</c>.</value>
    Public Property AllowSecondConnection() As Boolean
        Get
            Return _AllowSecendConnection
        End Get
        Set(ByVal value As Boolean)
            _AllowSecendConnection = value
        End Set
    End Property
    ''' <summary>
    ''' The login exception
    ''' </summary>
    Public Const LoginException As String = "The system could not allow access using the provided credential, please try again."
    ''' <summary>
    ''' This used to assign the main form of application
    ''' </summary>
    Private WithEvents _MainForm As Windows.Forms.Form
    ''' <summary>
    ''' Gets or sets the main form.
    ''' </summary>
    ''' <value>The main form.</value>
    Public Property MainForm() As Windows.Forms.Form
        Get
            Return _MainForm
        End Get
        Set(ByVal value As Windows.Forms.Form)
            _MainForm = value

        End Set
    End Property
    ''' <summary>
    ''' The database name
    ''' </summary>
    Public DatabaseName As String
    ''' <summary>
    ''' The database name ii
    ''' </summary>
    Public DatabaseNameII As String
    ''' <summary>
    ''' database server used in application
    ''' </summary>
    Public ServerName As String
    ''' <summary>
    ''' The server name ii
    ''' </summary>
    Public ServerNameII As String
    ''' <summary>
    ''' The is configuration loded
    ''' </summary>
    Friend isConfigLoded As Boolean
    ''' <summary>
    ''' The is windows authentication
    ''' </summary>
    Public isWindowsAuthentication As Boolean
    ''' <summary>
    ''' The selected authentication ii
    ''' </summary>
    Public SelectedAuthenticationII As Boolean
    ''' <summary>
    ''' The old fom
    ''' </summary>
    Friend oldFom As New System.Windows.Forms.Form
    ''' <summary>
    ''' The new form
    ''' </summary>
    Friend NewForm As System.Windows.Forms.Form
    ''' <summary>
    ''' The _ application form
    ''' </summary>
    Private _AppForm As New List(Of Windows.Forms.Form)
    ''' <summary>
    ''' The _ application controls
    ''' </summary>
    Private _AppControls As New List(Of Windows.Forms.Control)
    ''' <summary>
    ''' The sp login
    ''' </summary>
    Friend Const spLogin As String = "uspUserLogin"
    ''' <summary>
    ''' The domain user
    ''' </summary>
    Friend domainUser As String = System.Security.Principal.WindowsIdentity.GetCurrent().Name
    ''' <summary>
    ''' The parameters login
    ''' </summary>
    Friend paramsLogin() As String = domainUser.Split("\\")
    ''' <summary>
    ''' The database prefix
    ''' </summary>
    Public DatabasePrefix As String = ""
    ''' <summary>
    ''' The int login
    ''' </summary>
    Friend intLogin As Integer
    ''' <summary>
    ''' Used to define all cotrol used in application
    ''' is not necessary
    ''' </summary>
    ''' <value>The application controls.</value>
    Public ReadOnly Property AppControls() As List(Of Windows.Forms.Control)
        Get
            Return _AppControls
        End Get
    End Property
    ''' <summary>
    ''' This used to add all forms and dialog used in the application
    ''' </summary>
    ''' <value>The application forms.</value>
    Public Property AppForms() As List(Of Windows.Forms.Form)
        Get
            Return _AppForm
        End Get
        Set(ByVal value As List(Of Windows.Forms.Form))
            _AppForm = value
        End Set
    End Property
    ''' <summary>
    ''' This is after just affter asgninig
    ''' database name  and server name
    ''' </summary>
    ''' <param name="useCommonDeffault">if set to <c>true</c> [use common deffault].</param>
    ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
    ''' <exception cref="Exception"></exception>
    Public Function InitializeConnection(ByVal useCommonDeffault As Boolean) As Boolean
        Try
            If UseConfigFile Then
                If Not isConfigLoded Then

                    GetConnectionLocation()
                    isConfigLoded = True
                End If
                My.Settings.DBInstance = ServerName
                My.Settings.DBName = DatabaseName
                My.Settings.WindowsAuth = isWindowsAuthentication
                My.Settings.Save()
            End If

            Devpp.Data.SQLSERVER.DatabaseName = DatabaseName
            Devpp.Data.SQLSERVER.ServerName = ServerName
            Devpp.Data.SQLSERVER.SelectedWinAuth = isWindowsAuthentication
            '=======================
            'Insert here security info


            Dim sql As New Devpp.Data.SQLSERVER
            sql.initialize()
            If useCommonDeffault = True Then
                initCommonDefaults()
            End If
            commonDefault = useCommonDeffault
            Return True

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function
    ''' <summary>
    ''' Initializations the ii.
    ''' </summary>
    Public Sub InitializationII()
        Try
            Devpp.Data.SQLSERVER.DatabaseNameII = DatabaseNameII
            Devpp.Data.SQLSERVER.ServerNameII = ServerNameII
            ' Devpp.Data.SQLSERVER.SelectedAuthenticationII = SelectedAuthenticationII

            Dim sql As New Devpp.Data.SQLSERVER
            sql.initializeII()



        Catch ex As Exception
            'Throw New Exception(ex.Message)
        End Try

    End Sub
    ''' <summary>
    ''' Loads the mainform.
    ''' </summary>
    Friend Sub LoadMainform() Handles _MainForm.Load
        MainForm.Invalidate(True)
        MainForm.Show()

        'MainForm.Show()
    End Sub
    ''' <summary>
    ''' Updates the configuration.
    ''' </summary>
    ''' <param name="BackupPath">The backup path.</param>
    Friend Sub updateConfig(ByVal BackupPath As String)
        Dim doc As New XmlDocument
        If isComclass Then
            doc.Load(ApplicationLocation & "\" & ConfigFile)
        Else
            doc.Load(ApplicationLocation & "\" & My.Application.Info.AssemblyName + ".exe.config")

        End If
        Dim nolist As Xml.XmlNodeList = doc.GetElementsByTagName("userSettings")
        Dim st As String = ""
        For Each nod As XmlNode In nolist
            For Each nd As XmlNode In nod
                For Each nd1 As XmlNode In nd
                    Try
                        If nd1.Attributes(0).Value = "BackupPath" Then
                            nd1.ChildNodes(0).InnerText = BackupPath
                            Exit For
                        End If
                    Catch ex As Exception

                    End Try
                Next

            Next

        Next
        If isComclass Then
            doc.Save(ApplicationLocation & "\" & ConfigFile)
        Else
            doc.Save(ApplicationLocation & "\" & My.Application.Info.AssemblyName + ".exe.config")

        End If


    End Sub
    ''' <summary>
    ''' Updates the config2.
    ''' </summary>
    ''' <param name="DbName">Name of the database.</param>
    ''' <param name="instance">The instance.</param>
    ''' <param name="WinAuthe">if set to <c>true</c> [win authe].</param>
    Friend Sub updateConfig2(ByVal DbName As String, ByVal instance As String, ByVal WinAuthe As Boolean)
        Dim doc As New XmlDocument
        If isComclass Then
            doc.Load(ApplicationLocation & "\" & ConfigFile)
        Else
            doc.Load(ApplicationLocation & "\" & My.Application.Info.AssemblyName + ".exe.config")

        End If
        Dim nolist As Xml.XmlNodeList = doc.GetElementsByTagName("userSettings")
        Dim st As String = ""
        For Each nod As XmlNode In nolist
            For Each nd As XmlNode In nod
                For Each nd1 As XmlNode In nd
                    Try
                        If nd1.Attributes(0).Value = "WindowsAuth2" Then
                            nd1.ChildNodes(0).InnerText = WinAuthe
                        ElseIf nd1.Attributes(0).Value = "DBInstance2" Then
                            nd1.ChildNodes(0).InnerText = instance
                        ElseIf nd1.Attributes(0).Value = "DBName2" Then
                            nd1.ChildNodes(0).InnerText = DbName
                        End If
                        st = st + nd1.ChildNodes(0).InnerText + vbNewLine
                    Catch ex As Exception

                    End Try
                Next

            Next

        Next
        If isComclass Then
            doc.Save(ApplicationLocation & "\" & ConfigFile)
        Else
            doc.Save(ApplicationLocation & "\" & My.Application.Info.AssemblyName + ".exe.config")

        End If

    End Sub
    ''' <summary>
    ''' Gets the connection location.
    ''' </summary>
    Private Sub GetConnectionLocation()
        If isComclass Then
            Dim doc As New XmlDocument

            doc.Load(ApplicationLocation & "\" & ConfigFile)
            Dim nolist As Xml.XmlNodeList = doc.GetElementsByTagName("userSettings")
            Dim st As String = ""
            For Each nod As XmlNode In nolist
                For Each nd As XmlNode In nod
                    For Each nd1 As XmlNode In nd
                        Try
                            If nd1.Attributes(0).Value = "WindowsAuth" Then
                                Devpp.isWindowsAuthentication = nd1.ChildNodes(0).InnerText
                            ElseIf nd1.Attributes(0).Value = "DBInstance" Then
                                Devpp.ServerName = nd1.ChildNodes(0).InnerText
                            ElseIf nd1.Attributes(0).Value = "DBName" Then
                                Devpp.DatabaseName = nd1.ChildNodes(0).InnerText
                            End If

                        Catch ex As Exception

                        End Try
                    Next

                Next

            Next
        End If
    End Sub
    ''' <summary>
    ''' Gets the get database.
    ''' </summary>
    ''' <value>The get database.</value>
    Public ReadOnly Property GetDatabase() As String
        Get

            Return Devpp.DatabaseName
        End Get
    End Property
    ''' <summary>
    ''' Gets the get instance.
    ''' </summary>
    ''' <value>The get instance.</value>
    Public ReadOnly Property GetInstance() As String
        Get
            Return Devpp.ServerName
        End Get
    End Property
    ''' <summary>
    ''' Gets a value indicating whether [get win authe].
    ''' </summary>
    ''' <value><c>true</c> if [get win authe]; otherwise, <c>false</c>.</value>
    Public ReadOnly Property GetWinAuthe() As Boolean
        Get

            Return Devpp.isWindowsAuthentication
        End Get
    End Property

    ''' <summary>
    ''' Updates the configuration.
    ''' </summary>
    ''' <param name="DbName">Name of the database.</param>
    ''' <param name="instance">The instance.</param>
    ''' <param name="WinAuthe">if set to <c>true</c> [win authe].</param>
    Friend Sub updateConfig(ByVal DbName As String, ByVal instance As String, ByVal WinAuthe As Boolean)
        Dim doc As New XmlDocument
        If isComclass Then
            doc.Load(ApplicationLocation & "\" & ConfigFile)
        Else
            doc.Load(ApplicationLocation & "\" & My.Application.Info.AssemblyName + ".exe.config")

        End If
        Dim nolist As Xml.XmlNodeList = doc.GetElementsByTagName("userSettings")
        Dim st As String = ""
        For Each nod As XmlNode In nolist
            For Each nd As XmlNode In nod
                For Each nd1 As XmlNode In nd
                    Try
                        If nd1.Attributes(0).Value = "DBInstance" Then
                            nd1.ChildNodes(0).InnerText = instance
                        ElseIf nd1.Attributes(0).Value = "DBName" Then
                            nd1.ChildNodes(0).InnerText = DbName
                        ElseIf nd1.Attributes(0).Value = "WindowsAuth" Then
                            nd1.ChildNodes(0).InnerText = WinAuthe
                            'ElseIf nd1.Attributes(0).Value = "WindowsAuth2" Then
                            '    nd1.ChildNodes(0).InnerText = WinAuthe
                            'ElseIf nd1.Attributes(0).Value = "DBInstance2" Then
                            '    nd1.ChildNodes(0).InnerText = instance
                            'ElseIf nd1.Attributes(0).Value = "DBName2" Then
                            '    nd1.ChildNodes(0).InnerText = DbName
                        End If
                        st = st + nd1.ChildNodes(0).InnerText + vbNewLine
                    Catch ex As Exception

                    End Try
                Next

            Next

        Next
        If isComclass Then
            doc.Save(ApplicationLocation & "\" & ConfigFile)
        Else
            doc.Save(ApplicationLocation & "\" & My.Application.Info.AssemblyName + ".exe.config")

        End If
    End Sub
    ''' <summary>
    ''' Used to show user application settings
    ''' </summary>
    Public Sub ShowApplicationAttributes()
        Settings.ShowApplicationAttributes()
    End Sub
    ''' <summary>
    ''' Used to load user setting just after login
    ''' </summary>
    ''' <exception cref="Exception"></exception>
    Friend Sub LoadUserSettings()
        Try
            Settings.ReadSettings()

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    ''' <summary>
    ''' This is the grobal exiting the system
    ''' </summary>
    Public Sub ExitApplication()
        Try
            notfy.Visible = False
            notfy.Dispose()
        Catch ex As Exception

        End Try


        Try
            Environment.Exit(1)



        Catch ex As Exception

        End Try
    End Sub
    ''' <summary>
    ''' This is the user setting for declaring new form or dialog
    ''' </summary>
    ''' <param name="frm">form for setting attribute</param>
    ''' <param name="ctr">control for setting attribute</param>
    Public Sub UIUserSettings(ByVal frm As Windows.Forms.Form, Optional ByVal ctr As List(Of System.Windows.Forms.Control) = Nothing)
        frm.BackColor = Settings.BackGroundColor1
        frm.ForeColor = Settings.FontColor
        frm.Font = Settings.Font
        If Not ctr Is Nothing Then
            For Each ct As System.Windows.Forms.Control In ctr
                ct.BackColor = Settings.BackGroundColor2
            Next
        End If
    End Sub
    ''' <summary>
    ''' Initializes the common defaults.
    ''' </summary>
    Friend Sub initCommonDefaults()
        On Error Resume Next
        Dim deff As New Common.Defaults
        Dim v_bl As Boolean
        Dim v_i As Integer
        Dim v_double As Double

        Common.Login.AllowStrongPassword = deff.GetDefault(v_bl, 102)
        Common.Login.PassExpirationDays = deff.GetDefault(v_i, 107)
        Common.Login.AllowBlockPassword = deff.GetDefault(v_bl, 110)
        Common.Login.LoginRetrial = deff.GetDefault(v_i, 103)
        Common.Login.ActionAfterAtempt = deff.GetDefault(v_i, 111)
    End Sub
    ''' <summary>
    ''' Handles the Click event of the notfy control.
    ''' </summary>
    ''' <param name="sender">The source of the event.</param>
    ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
    Private Sub notfy_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles notfy.Click
        If Common.Login.Password = Devpp.Common.Login.PasswordToKeyCode("ABCabc123") Then
            notfy.Visible = True
            notfy.Icon = MainForm.Icon
            notfy.ShowBalloonTip(4000, MainForm.Text, Common.Login.UserName + ": you have to change your password now!", Windows.Forms.ToolTipIcon.Warning)
        End If
    End Sub
    ''' <summary>
    ''' Messages the no license.
    ''' </summary>
    Public Sub messageNoLicense()
        MsgBox(NotAllowedNoLicenseMessage, MsgBoxStyle.Information, "Un-Licensed")
    End Sub
End Module
