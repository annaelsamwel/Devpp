Imports Devpp.Common
Imports Devpp.Security
Namespace Forms

    Public Class frmLogin
        Public Event LoginStarted()
        Public Event UserLogedIn(ByVal sender As Object, ByVal e As EventArgs)
        Public Event ConnectionChangedCom(ByVal sender As Object, ByVal e As EventArgs)
        Private domainName As String = paramsLogin(0)
        Private V_integer As Integer = 0
        Private userDom As Integer = Nothing
        Friend Shared UserId As Integer
        Friend Shared UserLoged As Boolean = False
        Friend Shared fixedPassword As Boolean = False
        Friend Shared canExit As Boolean
        Friend GetDateChanged As Date
        Private GetValidation As Integer
        Private count As Integer
        Private log As Login
        Private _passExipire As Integer
        Private _usrExipire As Integer
        Private _default As Defaults
        Protected CanLogin As Boolean = False
        Private Atemp As Integer = 1
        Public Shared GetMainform As Windows.Forms.Form
        Private _AllowChangeDatabase As Boolean = True
        Friend QuickLogin As Boolean = False
        Public Property AllowChangeDatabase() As Boolean
            Get
                Return _AllowChangeDatabase
            End Get
            Set(ByVal value As Boolean)
                _AllowChangeDatabase = value
                Me.btnChange.Enabled = value
            End Set
        End Property
        Private LoginAtempt As New List(Of String)
        Private chValid As Boolean
        Private Const userLog As String = "INSERT INTO [dbo].[tblDevppUserLog]  ([MachineName]  ,[UserName] ,[NetAddress] ,[Date]  ,[Description]) VALUES (@MachineName ,@UserName ,@NetAddress ,@Date ,@Description) "
        Private Shared _NewForm As New Windows.Forms.Form
        Public Shared Property GetNewForm()
            Get
                Return _NewForm
            End Get
            Set(ByVal value)
                oldFom = MainForm
                _NewForm = value
                MainForm = _NewForm
            End Set
        End Property
        Friend Sub OKQuick()
            log = New Common.Login
            OKClicked(Me, New EventArgs)
        End Sub
        Protected Overridable Sub OKClicked(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click
            If Not DLLRegistered Then
                Throw New Exception("Devpp DLL not registered")
            End If
            CanLogin = False
            If Len(Me.txtUserName.Text) = 0 Or Len(Me.txtPassword.Text) = 0 Then
                Me.txtUserName.Text = ""
                Me.txtPassword.Text = ""
                Me.txtUserName.Focus()
                Return
            End If


            Try
                If ValidateUser() = False Then
                    Me.txtUserName.Text = ""
                    Me.txtPassword.Text = ""
                    Me.txtUserName.Focus()
                    If chValid = True Then
                        Return
                    Else
                        Throw New Exception(LoginException)
                    End If
                End If
                If log.login(Me.txtUserName.Text, Me.txtPassword.Text, userDom) = True Then
                    RaiseEvent LoginStarted()
                    SystemRights.LoginUserRights.DataSource = RightManager.GetUserRights(UserId)

                    If QuickLogin Then
                        Me.Close()
                        Return
                    End If
                    Security.SystemRights.TempUserID = Common.Login.UserID
                    Security.SystemRights.TempUserName = Me.txtUserName.Text
                    Security.SystemRights.TempPassword = Me.txtPassword.Text
                    Dim sqlcon As New SqlClient.SqlConnection(Devpp.Data.SQLSERVER.ConnectionString)
                    Dim sqlcom As New SqlClient.SqlCommand(userLog, sqlcon)
                    sqlcom.Parameters.Add("@MachineName", SqlDbType.NVarChar, 50).Value = My.Computer.Name
                    sqlcom.Parameters.Add("@UserName", SqlDbType.NVarChar, 50).Value = Me.txtUserName.Text
                    Dim str As String = ""
                    Dim heserver As Net.IPHostEntry = Net.Dns.GetHostEntry(My.Computer.Name)
                    For Each ip As Net.IPAddress In heserver.AddressList

                        str = ip.ToString
                    Next
                    sqlcom.Parameters.Add("@NetAddress ", SqlDbType.NVarChar, 50).Value = str
                    sqlcom.Parameters.Add("@Date", SqlDbType.DateTime).Value = Devpp.Data.SQLSERVER.GetCurrentDate
                    sqlcom.Parameters.Add("@Description", SqlDbType.NVarChar, 50).Value = "User login"
                    sqlcon.Open()
                    sqlcom.ExecuteNonQuery()
                    sqlcon.Close()
                    Try
                        Dim app As AppSetting
                        app = New AppSetting
                        Try
                            LoadUserSettings()
                        Catch ex As Exception

                        End Try

                        If Not MainForm Is Nothing Then
                            If isComclass Then
                            Else
                                MainForm.WindowState = Windows.Forms.FormWindowState.Maximized
                                LoadMainform()
                            End If

                        End If
                        isConnected = True
                        isFromfrmLogin = False
                        RaiseEvent UserLogedIn(sender, e)
                        Me.Close()
                        frmLogin.canExit = False
                        If Not oldFom Is Nothing Then
                            oldFom.Close()
                        End If
                        canExit = False
                    Catch ex As Exception
                        MsgBox(ex.Message)
                        ExitApplication()

                    End Try
                    UserLoged = True
                    Settings.UserName = Me.txtUserName.Text
                    Me.Close()
                    If Common.Login.Password = Devpp.Common.Login.PasswordToKeyCode("ABCabc123") Then
                        notfy.Visible = True
                        notfy.Icon = MainForm.Icon
                        notfy.ShowBalloonTip(4000, MainForm.Text, Common.Login.UserName + ": you have to change your password now!", Windows.Forms.ToolTipIcon.Warning)
                        Dim frmChangePassword As New frmFilePasswordChange

                        frmChangePassword.txtCurrentPwd.Text = "ABCabc123"
                        frmChangePassword.txtCurrentPwd.ReadOnly = True
                        frmChangePassword.ShowDialog()

                    End If
                    If isComclass Then
                        MainForm.Close()
                    End If
                End If

            Catch ex As Exception


                Try
                    If Login.ActionAfterAtempt <> 0 Then
                        If Login.AllowBlockPassword = True Then
                            If Login.LoginRetrial > 0 Then

                                If Atemp = Login.LoginRetrial - 1 Then
                                    MsgBox("The system will block the user if you provide wrong login", MsgBoxStyle.Information)
                                    Atemp += 1
                                    Me.txtUserName.Text = ""
                                    Me.txtPassword.Text = ""
                                    Me.txtUserName.Focus()
                                    Return
                                End If
                                If Atemp = Login.LoginRetrial Then
                                    If Login.ActionAfterAtempt = ActionUserBlocking.ExitApplication Then
                                        Try
                                            Me.Close()
                                            ExitApplication()
                                        Catch ex2 As Exception

                                        End Try
                                    Else
                                        Try
                                            Dim query1 As String = "SELECT [usrName] FROM [dbo].[tblDevppUser] WHERE ([usrName] = @value)"
                                            Dim con As New SqlClient.SqlConnection(Data.SQLSERVER.ConnectionString)
                                            Dim com As New SqlClient.SqlCommand(query1, con)
                                            com.Parameters.Add("@value", SqlDbType.NVarChar, 50).Value = Me.txtUserName.Text
                                            Dim dt As New DataTable
                                            Dim adapter As New SqlClient.SqlDataAdapter(com)
                                            adapter.Fill(dt)
                                            If dt.Rows.Count <= 0 Then
                                                Try
                                                    Me.Close()
                                                    ExitApplication()
                                                Catch ex2 As Exception

                                                End Try
                                            Else
                                                query1 = "UPDATE [dbo].[tblDevppUser] SET [usrIsBlocked] = @Block WHERE ([usrName] = @value)"
                                                com = New SqlClient.SqlCommand(query1, con)
                                                com.Parameters.Add("@value", SqlDbType.NVarChar, 50).Value = Me.txtUserName.Text
                                                com.Parameters.Add("@Block", SqlDbType.Bit).Value = True
                                                Try
                                                    Dim sqlcon As New SqlClient.SqlConnection(Devpp.Data.SQLSERVER.ConnectionString)
                                                    Dim sqlcom As New SqlClient.SqlCommand(userLog, sqlcon)
                                                    sqlcom.Parameters.Add("@MachineName", SqlDbType.NVarChar, 50).Value = My.Computer.Name
                                                    sqlcom.Parameters.Add("@UserName", SqlDbType.NVarChar, 50).Value = Me.txtUserName.Text
                                                    Dim str As String = ""

                                                    Dim heserver As Net.IPHostEntry = Net.Dns.GetHostEntry(My.Computer.Name)
                                                    For Each ip As Net.IPAddress In heserver.AddressList

                                                        str = ip.ToString
                                                    Next
                                                    sqlcom.Parameters.Add("@NetAddress ", SqlDbType.NVarChar, 50).Value = str
                                                    sqlcom.Parameters.Add("@Date", SqlDbType.DateTime).Value = Devpp.Data.SQLSERVER.GetCurrentDate
                                                    sqlcom.Parameters.Add("@Description", SqlDbType.NVarChar, 50).Value = "User Blocked"
                                                    sqlcon.Open()

                                                    con.Open()
                                                    com.ExecuteNonQuery()
                                                    con.Close()
                                                    sqlcom.ExecuteNonQuery()
                                                    sqlcon.Close()
                                                    MsgBox("The system blocks a user")
                                                    Me.Close()
                                                    ExitApplication()
                                                    Return
                                                Catch ex4 As Exception
                                                    Try
                                                        Me.Close()
                                                        ExitApplication()
                                                    Catch ex5 As Exception

                                                    End Try
                                                End Try


                                            End If


                                        Catch ex3 As Exception

                                        End Try
                                    End If
                                End If
                                Atemp += 1
                            End If

                        End If
                    End If
                Catch ex1 As Exception

                End Try
                MsgBox(ex.Message)

                Me.txtUserName.Text = ""
                Me.txtPassword.Text = ""
                Me.txtUserName.Focus()
            End Try

        End Sub

        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Try
                Me.Close()
                If canExit Then
                    ExitApplication()
                End If

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub
        Friend WithEvents frmUtil As Forms.frmDBUtilities
        Private Sub btnChange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChange.Click
            LoginStatus = True
            isFromfrmLogin = True
            frmUtil.Close()
            frmUtil = New frmDBUtilities
            frmUtil.StartPosition = Windows.Forms.FormStartPosition.CenterScreen
            Me.Hide()

            Windows.Forms.Application.DoEvents()

            frmUtil.ShowDialog(MainForm)


        End Sub

        Private Function ValidateUser() As Boolean
            chValid = False
            If Me.txtUserName.Text.ToUpper = "Devpp".ToUpper Then
                userDom = -1
                UserId = -1
                Return True
            End If
            Try
                Dim dt As DataTable = GetLogin(Me.txtUserName.Text, 0, 3)
                If dt.Rows.Count > 0 Then
                    Try
                        GetDateChanged = dt.Rows(0)("usrPasswordChanged")
                        If _passExipire = 0 Then
                            _passExipire = dt.Rows(0)("usrPasswordValidity")
                        End If
                    Catch ex As Exception

                    End Try

                    Dim bol As Boolean = dt.Rows(0)(1)
                    If bol = True Then
                        MsgBox("User blocked please communicat with a system administrator", MsgBoxStyle.Information)
                        chValid = True
                        Return False
                    Else
                        userDom = dt.Rows(0)(0)
                        If userDom <> 0 Then

                            If GetDateChanged.DayOfYear <> Date.Now.DayOfYear Then
                                If _passExipire <> 0 Then
                                    If GetDateChanged.DayOfYear > Date.Now.DayOfYear Or GetDateChanged.DayOfYear + _passExipire < Date.Now.DayOfYear Or GetDateChanged.Year <> Date.Now.Year Then
                                        MsgBox("User login expired", MsgBoxStyle.Information)
                                        chValid = True
                                        Return False
                                    End If
                                End If
                            End If
                        End If
                        userDom = dt.Rows(0)(0)
                        UserId = dt.Rows(0)(2)
                        Return True
                    End If
                Else
                    Return False
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try
        End Function
        Private Function GetLogin(ByVal GetUserName As String, ByVal GetPassword As Integer, ByVal mode As Integer) As DataTable
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
                    Catch ex As Exception

                    End Try
                End If

            Catch ex As Exception

            End Try
            Return dt
        End Function
        Protected Overrides Sub Finalize()
            MyBase.Finalize()
        End Sub
        Private Sub frmLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Try
                _default = New Defaults
                log = New Login
            Catch ex As Exception

            End Try


            Dim bol As Boolean = True
            Dim objDefault As New Devpp.Common.Defaults
            If AllowChangeDatabase Then
                If UserLoged Then

                    If objDefault.GetDefault(bol, 112) Then

                        Me.btnChange.Enabled = Security.GeneralRights.DBConnection

                    Else
                        Me.btnChange.Enabled = False
                    End If
                Else

                    Me.btnChange.Enabled = objDefault.GetDefault(bol, 112)


                End If

            End If


            frmUtil = New frmDBUtilities
            Me.Text = Me.Text & " - " & Devpp.ServerName & "\" & Devpp.DatabaseName
            _usrExipire = 0
            LoginStatus = False
            isFromfrmLogin = False
            If intLogin = 100 Then
                intLogin = 101
            End If
            Dim int As Integer
            Try
                _passExipire = _default.GetDefault(int, 107)
            Catch ex As Exception

            End Try
        End Sub

        Private Sub frmLogin_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
            If intLogin = 101 Then
                intLogin = 0
                Me.Close()
            End If
        End Sub



        Private Sub frmUtil_ConnectionChangedCom(ByVal sender As Object, ByVal e As System.EventArgs) Handles frmUtil.ConnectionChangedCom
            RaiseEvent ConnectionChangedCom(sender, e)
        End Sub
    End Class

End Namespace