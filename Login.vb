' ***********************************************************************
' Assembly         : Dev++
' Author           : Annael Samwel
' Created          : 08-18-2014
'
' Last Modified By : user
' Last Modified On : 03-21-2014
' ***********************************************************************
' <copyright file="Login.vb" company="Annael">
'     Copyright © Annael 2010
' </copyright>
' <summary></summary>
' ***********************************************************************
Imports System.Data
Imports System.Data.SqlClient
Imports System.DirectoryServices
Imports System.DirectoryServices.ActiveDirectory
Imports Devpp.Forms
Imports Devpp.Security

''' <summary>
''' The Common namespace.
''' </summary>
Namespace Common
    ''' <summary>
    ''' This class used to manage logins
    ''' Cleated by Annael
    ''' </summary>
    ''' <remarks></remarks>
    ''' <summary>
    ''' Class Login. This class cannot be inherited.
    ''' </summary>
    Public NotInheritable Class Login
        Inherits Object
#Region "Fields"
        ''' <summary>
        ''' The _ guest user
        ''' </summary>
        Private Shared _GuestUser As Long
        ''' <summary>
        ''' The _ user name
        ''' </summary>
        Private Shared _UserName As String
        ''' <summary>
        ''' The _ password
        ''' </summary>
        Private Shared _Password As Integer
        ''' <summary>
        ''' The _SP change login
        ''' </summary>
        Private Const _spChangeLogin As String = "spChangeLogin"
        ''' <summary>
        ''' The _SP login
        ''' </summary>
        Private Shared _spLogin As String
        ''' <summary>
        ''' The _SP block user
        ''' </summary>
        Private Shared _spBlockUser As String = "spBlockUser"
        ''' <summary>
        ''' The _ user blocked
        ''' </summary>
        Private Shared _UserBlocked As Boolean
        ''' <summary>
        ''' The _ pass change trial
        ''' </summary>
        Private Shared _PassChangeTrial As Integer
        ''' <summary>
        ''' The _pass expiration days
        ''' </summary>
        Private Shared _passExpirationDays As Integer
        ''' <summary>
        ''' The trials
        ''' </summary>
        Friend Shared Trials As Integer
        ''' <summary>
        ''' The _ pass maximum character
        ''' </summary>
        Private Shared _PassMaxChar As Integer
        ''' <summary>
        ''' The _pass minimum character
        ''' </summary>
        Private Shared _passMinChar As Integer
        ''' <summary>
        ''' The _ allow strong password
        ''' </summary>
        Private Shared _AllowStrongPassword As Boolean = False
        ''' <summary>
        ''' The _ allow block password
        ''' </summary>
        Private Shared _AllowBlockPassword As Boolean = False
        ''' <summary>
        ''' The _ user identifier
        ''' </summary>
        Private Shared _UserId As Integer
        ''' <summary>
        ''' The _default
        ''' </summary>
        Private Shared _default As Defaults
        ''' <summary>
        ''' The pass user created
        ''' </summary>
        Friend Shared PassUserCreated As Integer
        ''' <summary>
        ''' The passdate created
        ''' </summary>
        Friend Shared PassdateCreated As Date
        ''' <summary>
        ''' The user domain
        ''' </summary>
        Friend Shared UserDomain As Integer
        ''' <summary>
        ''' The pass date changed
        ''' </summary>
        Friend Shared PassDateChanged As Date
        ''' <summary>
        ''' The _usr strong pass
        ''' </summary>
        Private Shared _usrStrongPass As Boolean
        ''' <summary>
        ''' The _ action after atempt
        ''' </summary>
        Private Shared _ActionAfterAtempt As ActionUserBlocking

#End Region
#Region "Property"
        ''' <summary>
        ''' Gets or sets the action after atempt.
        ''' </summary>
        ''' <value>The action after atempt.</value>
        Public Shared Property ActionAfterAtempt() As ActionUserBlocking
            Get

                Return _ActionAfterAtempt
            End Get
            Set(ByVal value As ActionUserBlocking)
                _ActionAfterAtempt = value
            End Set
        End Property
        ''' <summary>
        ''' Gets a value indicating whether [usr strong pass].
        ''' </summary>
        ''' <value><c>true</c> if [usr strong pass]; otherwise, <c>false</c>.</value>
        Friend Shared ReadOnly Property usrStrongPass() As Boolean
            Get
                Return _usrStrongPass
            End Get
        End Property
        ''' <summary>
        ''' Gets the guest user.
        ''' </summary>
        ''' <value>The guest user.</value>
        Friend Shared ReadOnly Property GuestUser() As Long
            Get
                _GuestUser = PasswordToKeyCode("Guest")
                Return _GuestUser
            End Get

        End Property
        ''' <summary>
        ''' Gets or sets the pass expiration days.
        ''' </summary>
        ''' <value>The pass expiration days.</value>
        Public Shared Property PassExpirationDays() As Integer
            Get

                Return _passExpirationDays
            End Get
            Set(ByVal value As Integer)
                _passExpirationDays = value
            End Set
        End Property
        ''' <summary>
        ''' Gets or sets the user identifier.
        ''' </summary>
        ''' <value>The user identifier.</value>
        Public Shared Property UserID() As Integer
            Get
                Return _UserId
            End Get
            Set(ByVal value As Integer)
                _UserId = value
                SystemRights.LoginUserRights.DataSource = RightManager.GetUserRights(_UserId)
                LoadUserSettings()
            End Set
        End Property
        ''' <summary>
        ''' Gets or sets a value indicating whether [allow block password].
        ''' </summary>
        ''' <value><c>true</c> if [allow block password]; otherwise, <c>false</c>.</value>
        Public Shared Property AllowBlockPassword() As Boolean
            Get

                Return _AllowBlockPassword
            End Get
            Set(ByVal value As Boolean)
                _AllowBlockPassword = value
            End Set
        End Property
        ''' <summary>
        ''' Gets or sets the pass maximum character.
        ''' </summary>
        ''' <value>The pass maximum character.</value>
        Public Shared Property PassMaxChar() As Integer
            Get

                Return _PassMaxChar
            End Get
            Set(ByVal value As Integer)
                _PassMaxChar = value
            End Set
        End Property
        ''' <summary>
        ''' Gets or sets the pass minimum character.
        ''' </summary>
        ''' <value>The pass minimum character.</value>
        Public Shared Property PassMinChar() As Integer
            Get

                Return _passMinChar
            End Get
            Set(ByVal value As Integer)
                _passMinChar = value
            End Set
        End Property
        ''' <summary>
        ''' Gets or sets a value indicating whether [allow strong password].
        ''' </summary>
        ''' <value><c>true</c> if [allow strong password]; otherwise, <c>false</c>.</value>
        Public Shared Property AllowStrongPassword() As Boolean
            Get
                Dim bl As Boolean
                _AllowStrongPassword = _default.GetDefault(bl, 102)
                Return _AllowStrongPassword
            End Get
            Set(ByVal value As Boolean)
                _AllowStrongPassword = value
            End Set
        End Property
        ''' <summary>
        ''' Gets or sets the login retrial.
        ''' </summary>
        ''' <value>The login retrial.</value>
        Public Shared Property LoginRetrial() As Integer
            Get

                Return _PassChangeTrial
            End Get
            Set(ByVal value As Integer)
                _PassChangeTrial = value
            End Set
        End Property
        ''' <summary>
        ''' Checks the login.
        ''' </summary>
        Friend Shared Sub CheckLogin()



        End Sub
        ''' <summary>
        ''' Gets a value indicating whether [user blocked].
        ''' </summary>
        ''' <value><c>true</c> if [user blocked]; otherwise, <c>false</c>.</value>
        Public Shared ReadOnly Property UserBlocked() As Boolean
            Get
                Return _UserBlocked
            End Get
        End Property
        ''' <summary>
        ''' Gets or sets the name of the user.
        ''' </summary>
        ''' <value>The name of the user.</value>
        Public Shared Property UserName() As String
            Set(ByVal value As String)
                Settings.UserName = value
                _UserName = value

            End Set
            Get
                Return _UserName
            End Get

        End Property
        ''' <summary>
        ''' Gets the password.
        ''' </summary>
        ''' <value>The password.</value>
        Public Shared ReadOnly Property Password() As Integer
            Get
                Return _Password
            End Get

        End Property
#End Region
#Region "Methods"
        ''' <summary>
        ''' Method for displaying Login form
        ''' </summary>
        ''' <remarks></remarks>
        ''' <summary>
        ''' Shows the login form.
        ''' </summary>
        Public Sub ShowLoginForm()
            Dim frmlog As New frmLogin
            frmlog.ShowDialog()
        End Sub
        ''' <summary>
        ''' This method used to manage back door password
        ''' </summary>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ''' <summary>
        ''' Gets the devpp password.
        ''' </summary>
        ''' <returns>System.String.</returns>
        Private Function getDevppPassword() As String
            Dim x As String
            x = Date.Today.ToOADate + Weekday(Date.Today)
            Return x
        End Function

        ''' <summary>
        ''' This method used to lock application
        ''' </summary>
        ''' <remarks></remarks>
        ''' <summary>
        ''' Locks the application.
        ''' </summary>
        Public Sub LockApplication()
            Dim x As New frmLock
            x.ShowDialog()
        End Sub

        ''' <summary>
        ''' This method used to manage strong password
        ''' </summary>
        ''' <param name="Password">User password</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ''' 
        ''' <summary>
        ''' Checks the strong password.
        ''' </summary>
        ''' <param name="Password">The password.</param>
        ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        ''' <exception cref="System.Exception">
        ''' Password Length must be Between  + _passMinChar.ToString +  and  + _PassMaxChar.ToString
        ''' or
        ''' Strong Password should contain at least 1 Number, 1 Capital and 1 small capital
        ''' or
        ''' </exception>
        Friend Function CheckStrongPassword(ByVal Password As String) As Boolean
            Try
                Dim Captital As Integer = 0
                Dim Small As Integer = 0
                Dim numeric As Integer = 0
                For Each Chs As Char In Password
                    If Char.IsNumber(Chs) Then
                        numeric += 1
                    ElseIf Char.IsUpper(Chs) Then
                        Captital += 1
                    ElseIf Char.IsLower(Chs) Then
                        Small += 1
                    Else

                    End If
                Next
                If (Password.Length > PassMaxChar Or Password.Length < PassMinChar) And (PassMaxChar > 0 Or PassMinChar > 0) Then
                    Throw New Exception("Password Length must be Between " + _passMinChar.ToString + " and " + _PassMaxChar.ToString)
                    Return False
                End If
                If Captital = 0 Or Small = 0 Or numeric = 0 Then
                    Throw New Exception("Strong Password should contain at least 1 Number, 1 Capital and 1 small capital")
                    Return False
                End If

                Return True
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function
        ''' <summary>
        ''' This method used to manage login when the user login
        ''' </summary>
        ''' <param name="UserName">The username of the user</param>
        ''' <param name="passWord">Password of the user</param>
        ''' <param name="domain">Authentification type</param>
        ''' <returns>Return True or false</returns>
        ''' <remarks></remarks>
        ''' <summary>
        ''' Logins the specified user name.
        ''' </summary>
        ''' <param name="UserName">Name of the user.</param>
        ''' <param name="passWord">The pass word.</param>
        ''' <param name="domain">The domain.</param>
        ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        ''' <exception cref="System.Exception">
        ''' </exception>
        Friend Function login(ByVal UserName As String, ByVal passWord As String, ByVal domain As Authetification) As Boolean
            Settings.UserName = UserName
            If (UserName.ToUpper = "Devpp".ToUpper And passWord = getDevppPassword()) Then
                frmLogin.fixedPassword = True
                _UserName = UserName
                _UserId = 0
                Return True
            End If
            Dim tbl As New DataTable

            Try
                _default = New Defaults
                _UserId = frmLogin.UserId

                Select Case domain
                    Case Authetification.Devpp
                        tbl = GetLogin(UserName, PasswordToKeyCode(passWord), 1)
                        If tbl.Rows.Count > 0 Then
                            _UserName = UserName
                            _Password = PasswordToKeyCode(passWord)
                            Settings.ReadSettings()
                            frmLogin.fixedPassword = False
                            Return True
                        Else
                            _UserId = Nothing
                            Throw New Exception(LoginException)

                        End If
                    Case Authetification.Domain
                        If LoginManager.Authentification(UserName, passWord) = True Then
                            _UserName = UserName
                            _Password = PasswordToKeyCode(passWord)
                            Settings.ReadSettings()
                            frmLogin.fixedPassword = True
                            Return True
                        Else
                            _UserId = Nothing
                            Throw New Exception(LoginException)

                        End If
                    Case Authetification.Both
                        tbl = GetLogin(UserName, PasswordToKeyCode(passWord), 1)
                        If tbl.Rows.Count > 0 Then
                            _UserName = UserName
                            _Password = PasswordToKeyCode(passWord)
                            Settings.ReadSettings()
                            frmLogin.fixedPassword = False
                            Return True
                        Else
                            If LoginManager.Authentification(UserName, passWord) = True Then
                                _UserName = UserName
                                _Password = PasswordToKeyCode(passWord)
                                Settings.ReadSettings()
                                frmLogin.fixedPassword = True
                                Return True
                            Else
                                _UserId = Nothing
                                Throw New Exception(LoginException)
                            End If
                        End If
                    Case Else
                        _UserId = Nothing
                        Throw New Exception(LoginException)
                        Return False
                End Select



            Catch ex As Exception
                _UserId = Nothing
                Throw New Exception(ex.Message)
                Return False
            End Try
            Return False
        End Function
        ''' <summary>
        ''' Method for encoding password
        ''' </summary>
        ''' <param name="Password">user password</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ''' <summary>
        ''' Passwords to key code.
        ''' </summary>
        ''' <param name="Password">The password.</param>
        ''' <returns>System.Int64.</returns>
        Friend Shared Function PasswordToKeyCode(ByVal Password As String) As Long
            Dim i As Integer
            Dim hold As Long
            For i = 1 To Len(Password)
                Select Case (Asc(Left(Password, 1)) * i) Mod 4
                    Case Is = 0
                        hold = hold + (Asc(Mid(Password, i, 1)) * i)
                    Case Is = 1
                        hold = hold - (Asc(Mid(Password, i, 1)) * i)
                    Case Is = 2
                        hold = hold + (Asc(Mid(Password, i, 1)) * _
                        (i - Asc(Mid(Password, i, 1))))
                    Case Is = 3
                        hold = hold - (Asc(Mid(Password, i, 1)) * _
                        (i + Len(Password)))
                End Select
            Next i
            Return hold
        End Function
        ''' <summary>
        ''' Friend method for unlocking the system
        ''' </summary>
        ''' <param name="uspassword">password of the user loged in</param>
        ''' <returns></returns>
        ''' <remarks></remarks>
        ''' <summary>
        ''' Unlocks the specified uspassword.
        ''' </summary>
        ''' <param name="uspassword">The uspassword.</param>
        ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        Friend Function unlock(ByVal uspassword As String) As Boolean
            If _Password = PasswordToKeyCode(uspassword) Then
                Return True
            Else
                Return False
            End If
        End Function
        ''' <summary>
        ''' Gets the month.
        ''' </summary>
        ''' <returns>System.Int32.</returns>
        Friend Shared Function GetMonth() As Integer
            Return Data.SQLSERVER.GetCurrentDate.Month
        End Function
        ''' <summary>
        ''' Gets the year.
        ''' </summary>
        ''' <returns>System.Int32.</returns>
        Friend Shared Function GetYear() As Integer
            Return Data.SQLSERVER.GetCurrentDate.Year
        End Function
        ''' <summary>
        ''' Method for changing password
        ''' </summary>
        ''' <param name="NewPassword">User password</param>
        ''' <remarks></remarks>
        ''' <summary>
        ''' Changes the pass word.
        ''' </summary>
        ''' <param name="NewPassword">The new password.</param>
        ''' <exception cref="System.Exception"></exception>
        Private Sub ChangePassWord(ByVal NewPassword As String)
            Dim sqlcon As New SqlConnection(Data.SQLSERVER.ConnectionString)
            Try
                If AllowStrongPassword = True Then
                    CheckStrongPassword(NewPassword)


                End If

                Dim strQuery As String = "UPDATE [tblDevppUser] SET " & _
                "[usrPassword] =  " & PasswordToKeyCode(NewPassword).ToString & ", [usrPasswordChanged] = @date WHERE [usrPid] = " & _UserId

                Dim sqlcom As New SqlCommand(strQuery, sqlcon)
                sqlcom.Parameters.Add("@date", SqlDbType.SmallDateTime)
                sqlcom.Parameters("@date").Value = Devpp.Data.SQLSERVER.GetCurrentDate
                sqlcon.Open()
                sqlcom.ExecuteNonQuery()
                sqlcon.Close()
            Catch ex As Exception
                sqlcon.Close()
                Throw New Exception(ex.Message)
            End Try
        End Sub
        ''' <summary>
        ''' Method for changing password
        ''' </summary>
        ''' <param name="OldPassword">Old password</param>
        ''' <param name="NewPassword">New password</param>
        ''' <remarks></remarks>
        ''' <summary>
        ''' Changes the pass word.
        ''' </summary>
        ''' <param name="OldPassword">The old password.</param>
        ''' <param name="NewPassword">The new password.</param>
        ''' <exception cref="System.Exception">
        ''' You have tried  + CStr(Trials) +  Times to change Password + vbNewLine + _
        '''                                     THIS IS THE LAST TRIAL IF YOU SUPPLY WRONG OLD PASSWORD, SYSTEM WILL BLOCK  + UserName
        ''' or
        ''' Old Password does not Match
        ''' or
        ''' Old Password does not Match
        ''' or
        ''' </exception>
        Friend Sub ChangePassWord(ByVal OldPassword As String, ByVal NewPassword As String)
            Try
                If PasswordToKeyCode(OldPassword) <> Password Then
                    If LoginRetrial <> 0 And AllowBlockPassword = True Then
                        Trials = Trials + 1
                        If Trials = LoginRetrial - 1 Then
                            Throw New Exception("You have tried " + CStr(Trials) + " Times to change Password" + vbNewLine + _
                                    "THIS IS THE LAST TRIAL IF YOU SUPPLY WRONG OLD PASSWORD, SYSTEM WILL BLOCK " + UserName)

                        ElseIf Trials >= LoginRetrial Then
                            Dim sqlcon As New SqlConnection(Data.SQLSERVER.ConnectionString)
                            Dim strQuery As String = "UPDATE [tblDevppUser] SET " & _
                             "[usrIsBlocked] = 1  WHERE [usrPid] = " & _UserId

                            Dim sqlcom As New SqlCommand(strQuery, sqlcon)
                            sqlcon.Open()
                            sqlcom.ExecuteNonQuery()
                            sqlcon.Close()
                            ExitApplication()
                        Else
                            Throw New Exception("Old Password does not Match")

                        End If
                    Else
                        Throw New Exception("Old Password does not Match")

                    End If
                End If
                ChangePassWord(NewPassword)
                _Password = PasswordToKeyCode(NewPassword)
                Trials = 0
            Catch ex As Exception

                Throw New Exception(ex.Message)
            End Try
        End Sub

        ''' <summary>
        ''' Gets the login.
        ''' </summary>
        ''' <param name="GetUserName">Name of the get user.</param>
        ''' <param name="GetPassword">The get password.</param>
        ''' <param name="mode">The mode.</param>
        ''' <returns>DataTable.</returns>
        Friend Shared Function GetLogin(ByVal GetUserName As String, ByVal GetPassword As Integer, ByVal mode As Integer) As DataTable
            Dim strGuery As String = ""
            Dim con As New SqlClient.SqlConnection(Devpp.Data.SQLSERVER.ConnectionString)
            Dim com As New SqlClient.SqlCommand
            Dim dt As New DataTable

            Try
                com.CommandText = "uspDevppGetLogin"
                com.CommandType = CommandType.StoredProcedure
                com.Connection = con
                com.Parameters.Add("@mode", SqlDbType.Int)
                com.Parameters.Add("@UserName", SqlDbType.NVarChar)
                com.Parameters.Add("@usrPassword", SqlDbType.Int)
                com.Parameters("@mode").Value = mode
                com.Parameters("@UserName").Value = GetUserName
                com.Parameters("@usrPassword").Value = GetPassword
                Dim adapter As New SqlClient.SqlDataAdapter(com)
                adapter.Fill(dt)
                If mode < 3 And dt.Rows.Count > 0 Then
                    Try
                        Devpp.Common.Login.PassUserCreated = dt.Rows(0)("usrCreateUserID")
                        Devpp.Common.Login.PassdateCreated = dt.Rows(0)("usrAuditCreateDate")
                        Devpp.Common.Login.UserDomain = dt.Rows(0)("usrDomain")
                        Devpp.Common.Login.PassDateChanged = dt.Rows(0)("usrPasswordChanged")
                        _usrStrongPass = dt.Rows(0)("usrStrongPassword")
                    Catch ex As Exception

                    End Try
                End If
                Return dt
            Catch ex As Exception
                Return Nothing
            End Try
        End Function
#End Region

        ''' <summary>
        ''' Initializes a new instance of the <see cref="Login"/> class.
        ''' </summary>
        Public Sub New()

        End Sub
    End Class
    ''' <summary>
    ''' Authentification enum
    ''' </summary>
    ''' <remarks></remarks>
    ''' <summary>
    ''' Enum Authetification
    ''' </summary>
    Public Enum Authetification
        ''' <summary>
        ''' For domain Login
        ''' </summary>
        ''' <summary>
        ''' The domain
        ''' </summary>
        Domain = 0
        ''' <summary>
        ''' For Devpp Login
        ''' </summary>
        ''' <summary>
        ''' The devpp
        ''' </summary>
        Devpp = 1
        ''' <summary>
        ''' For both Login
        ''' </summary>
        ''' <summary>
        ''' The both
        ''' </summary>
        Both = 2
    End Enum
    ''' <summary>
    ''' Enum UserSetting
    ''' </summary>
    Public Enum UserSetting
        ''' <summary>
        ''' The update settings
        ''' </summary>
        UpdateSettings = 0
        ''' <summary>
        ''' The get settings
        ''' </summary>
        GetSettings = 1
    End Enum
    ''' <summary>
    ''' Enum ActionUserBlocking
    ''' </summary>
    Public Enum ActionUserBlocking
        ''' <summary>
        ''' value =0
        ''' </summary>
        DoNothing = 0
        ''' <summary>
        ''' Value = 1
        ''' </summary>
        BlockUser = 1
        ''' <summary>
        ''' Value = 2
        ''' </summary>
        ExitApplication = 2

    End Enum
    ''' <summary>
    ''' This is the friend class which used to manage daomain login.
    ''' </summary>
    Friend Class LoginManager
        ''' <summary>
        ''' Authentifications the specified username.
        ''' </summary>
        ''' <param name="username">The username.</param>
        ''' <param name="pwd">The password.</param>
        ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        Friend Shared Function Authentification(ByVal username As String, ByVal pwd As String) As Boolean


            Dim entry As New DirectoryEntry("LDAP://" & Environment.UserDomainName, username, pwd)

            Dim obj As Object
            Try
                obj = entry.NativeObject
                Dim search As New DirectorySearcher(entry)
                Dim result As SearchResult
                search.Filter = "(SAMAccountName=" + username + ")"
                search.PropertiesToLoad.Add("cn")
                result = search.FindOne()
                If result Is Nothing Then
                    Return False
                End If
            Catch ex As Exception
                Return False
            End Try

            Return True
        End Function
    End Class
End Namespace