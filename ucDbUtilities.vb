Imports System.Windows.Forms
Imports System.Security.Cryptography
Imports System.IO
Imports System.Text
Imports Microsoft.SqlServer.Management.Smo
Imports Microsoft.SqlServer.Management.Common

Friend Class ucDbUtilities
    Private Shared xMode As Integer = 0
    Private Binder As New BindingSource
    Private FileLocation As String
    Private buff() As Byte
    Private Const PublicKey As String = ":-+A7V@="
    Private bsScript As New System.Windows.Forms.BindingSource
    Private Shared TemLocation As String
    Private WithEvents tim As Timer
    Private dtTable As New DataTable("DevppScript")
    Private WithEvents chk As New CheckBox
    Private objReader As IO.StreamReader
    Public Shared isDevppAllowed As Boolean
    Private _RunScript As Boolean
    Public Event ConnectionChangedCom(ByVal sender As Object, ByVal e As EventArgs)
    Public Property RunScript() As Boolean
        Get
            Return _RunScript
        End Get
        Set(ByVal value As Boolean)
            _RunScript = value
        End Set
    End Property
    Public Shared Property SelectedMode() As Integer
        Get
            Return xMode
        End Get
        Set(ByVal value As Integer)
            xMode = value
        End Set
    End Property



    Private Sub frmSupDBUtils_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cmbInitInstances.Text = My.Computer.Name & "\SOFTNET2016"
        If Not DLLRegistered Then
            Throw New Exception("Devpp DLL not registered")
        End If
        DBInitialization.lblService = Me.lblService
        DBInitialization.stBar = Me.prgService
        Me.chkUseSecondConection.Visible = AllowSecondConnection
        bsScript.DataSource = ScriptDataTable
        Try
            Me.cmbScriptType.DataSource = bsScript
            Me.cmbScriptType.DisplayMember = "ScriptName"
            Me.cmbScriptType.ValueMember = "ScriptName"
        Catch ex As Exception

        End Try
        chkUseSecondConection.Checked = False
        If RunScript = False Then
            Me.chkNewDatabase.Checked = True
            If Forms.frmLogin.UserLoged = False Then
                Me.tabManagement.TabPages(2).Dispose()
            Else
                If Not Security.GeneralRights.DBConnection Then
                    Me.tabManagement.TabPages(tabConnect.Name).Dispose()
                End If
                If Not Security.GeneralRights.InitializeBD Then
                    Me.tabManagement.TabPages(tabInit.Name).Dispose()
                End If
                If Not Security.GeneralRights.DBUtilityTools Then
                    Me.tabManagement.TabPages(tabTools.Name).Dispose()
                Else
                    Me.btnBrowseScript.Enabled = Security.GeneralRights.RunScript
                    Me.btnDBBackup.Enabled = Security.GeneralRights.BackUpDB
                    Me.btnDbRestore.Enabled = Security.GeneralRights.RestoreDB
                    Me.btnOpen.Enabled = Security.GeneralRights.BackUpDB
                    Me.chkZip.Enabled = Security.GeneralRights.RestoreDB
                    Me.txtDbBackup.Enabled = Security.GeneralRights.BackUpDB
                End If
                If Not Security.GeneralRights.DBUtility Then
                    Me.ParentForm.Close()
                End If

            End If
            If LoginStatus = True Then
                Try
                    Me.tabManagement.TabPages(1).Dispose()
                    Me.tabManagement.TabPages(1).Dispose()
                Catch ex As Exception

                End Try
            End If
        Else
            RunScript = False

        End If
        Try
            Me.txtDbBackup.Text = My.Settings.BackupPath
            lblCurrentCon.Text = Devpp.Data.SQLSERVER.ServerName & "\" & Devpp.Data.SQLSERVER.DatabaseName
            cmbDBInstance.Text = Devpp.Data.SQLSERVER.ServerName
            cmbDBName.Text = Devpp.Data.SQLSERVER.DatabaseName
            txtSpecUserName.Text = Devpp.Data.SQLSERVER.SelectedUsername
            txtPassword.Text = Devpp.Data.SQLSERVER.SelectedPassword
            chkWinAuth.Checked = Devpp.Data.SQLSERVER.SelectedWinAuth
            Me.chkInitWinauth.Checked = Devpp.Data.SQLSERVER.SelectedWinAuth
            Me.txtInitUser.Text = Devpp.Data.SQLSERVER.SelectedUsername
            Me.txtInitPass.Text = Devpp.Data.SQLSERVER.SelectedPassword
            txtDbBackup.Text = My.Settings.BackupPath

            If chkWinAuth.Checked = False Then
                chkAdvanced.Visible = True
            End If

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub Databases()
        Try
            Binder = New BindingSource
            If chkUseSecondConection.Checked = True Then
                Binder.DataSource = Devpp.Data.SQLSERVER.getDatabasesII(DatabasePrefix)
            Else
                Binder.DataSource = Devpp.Data.SQLSERVER.getDatabases(DatabasePrefix)
            End If

            cmbDBName.DataSource = Binder
            cmbDBName.DisplayMember = "Database"
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Private Sub cmbDBName_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbDBName.Enter
        Cursor = Cursors.WaitCursor
        Databases()
        Cursor = Cursors.Default
    End Sub
    Private Sub cmbDBInstance_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles cmbDBInstance.Validating
        Devpp.Data.SQLSERVER.ServerName = cmbDBInstance.Text

    End Sub
    Private Sub txtSpecUserName_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtSpecUserName.Validating
        Devpp.Data.SQLSERVER.SelectedUsername = txtSpecUserName.Text
    End Sub
    Private Sub txtPassword_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtPassword.Validating
        Devpp.Data.SQLSERVER.SelectedUsername = txtPassword.Text
    End Sub
    Private Sub chkWinAuth_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkWinAuth.CheckedChanged
        If chkUseSecondConection.Checked = True Then
            Devpp.Data.SQLSERVER.WinAuthII = sender.checked
        Else
            Devpp.Data.SQLSERVER.SelectedWinAuth = sender.checked
        End If
        Dim bChecked As Boolean = IIf(sender.checked, False, True)
        grpAdvConn.Visible = IIf(sender.checked, False, chkAdvanced.Checked)
        chkAdvanced.Visible = bChecked
    End Sub
    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        Try
            btnRefresh.Cursor = Cursors.WaitCursor
            cmbDBInstance.DataSource = Devpp.Data.SQLSERVER.getSqlInstances()
            cmbDBInstance.DisplayMember = "Instance"
            btnRefresh.Cursor = Cursors.Default
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    Friend MyfrmLogin As New Devpp.Forms.frmLogin
    Private Sub btnConnect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConnect.Click
        isConfigLoded = True
        btnConnect.Cursor = Cursors.WaitCursor
        Forms.frmLogin.canExit = True
        Try

            My.Settings.DBInstance = cmbDBInstance.Text
            My.Settings.DBName = cmbDBName.Text
            My.Settings.WindowsAuth = chkWinAuth.Checked
            My.Settings.BackupPath = txtDbBackup.Text
            My.Settings.Save()

            Devpp.DatabaseName = Me.cmbDBName.Text
            Devpp.ServerName = Me.cmbDBInstance.Text
            Data.SQLSERVER.SelectedUsername = Me.txtSpecUserName.Text
            Data.SQLSERVER.SelectedPassword = Me.txtPassword.Text
            Data.SQLSERVER.SelectedWinAuth = Me.chkWinAuth.Checked
            If isComclass Then
                ' updateConfig(cmbDBName.Text, cmbDBInstance.Text, chkWinAuth.Checked)
                RaiseEvent ConnectionChangedCom(sender, e)

            End If
            If Devpp.Data.SQLSERVER.CheckServerConnection = True Then

                InitializeConnection(commonDefault)
                MyfrmLogin.Close()
                MyfrmLogin = New Devpp.Forms.frmLogin

                ds.Tables.Clear()
                Start()

                ' MyfrmLogin.frmUtil = Me.ParentForm

                Me.ParentForm.Hide()
                MyfrmLogin.ShowDialog(MainForm)





            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        btnConnect.Cursor = Cursors.Default
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        isConfigLoded = False
        Try
            If chkUseSecondConection.Checked = True Then
                My.Settings.DBInstance2 = cmbDBInstance.Text
                My.Settings.DBName2 = cmbDBName.Text
                My.Settings.WindowsAuth2 = chkWinAuth.Checked
                My.Settings.Save()
                updateConfig2(cmbDBName.Text, cmbDBInstance.Text, chkWinAuth.Checked)
                Devpp.Data.SQLSERVER.ConnectionStringII = "Data Source=" & cmbDBInstance.Text & ";Initial Catalog=" & cmbDBName.Text
                If chkWinAuth.Checked = True Then
                    Devpp.Data.SQLSERVER.ConnectionStringII += ";integrated security=SSPI;persist security info=False; Trusted_Connection=Yes"
                Else
                    Devpp.Data.SQLSERVER.ConnectionStringII += ";User ID= " & Devpp.Data.SQLSERVER.SelectedUsername & ";Password=" & Devpp.Data.SQLSERVER.SelectedPassword
                End If

            Else
                My.Settings.DBInstance = cmbDBInstance.Text
                My.Settings.DBName = cmbDBName.Text
                My.Settings.WindowsAuth = chkWinAuth.Checked
                My.Settings.BackupPath = txtDbBackup.Text
                My.Settings.Save()
                updateConfig(cmbDBName.Text, cmbDBInstance.Text, chkWinAuth.Checked)
            End If

            Devpp.DatabaseName = My.Settings.DBName
            Devpp.ServerName = My.Settings.DBInstance
            Devpp.Data.SQLSERVER.SelectedWinAuth = My.Settings.WindowsAuth
            Devpp.DatabaseNameII = My.Settings.DBName2
            Devpp.ServerNameII = My.Settings.DBInstance2
            Devpp.Data.SQLSERVER.WinAuthII = My.Settings.WindowsAuth2
            Forms.frmLogin.canExit = True
            'Devpp.Data.SQLSERVER. .exaInstanceIi = My.Settings.DBInstance2

        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub
    'Private Sub rbAdvConnection_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAdvanced.CheckedChanged
    '    grpAdvConn.Visible = sender.checked
    'End Sub
    Private Sub btnDBBackup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDBBackup.Click

        If txtDbBackup.Text = "" Then
            MsgBox("You must specify location for backup.", MsgBoxStyle.Information, "Backup info.")
            Exit Sub
        End If
        Try
            btnDBBackup.Cursor = Cursors.WaitCursor
            Dim DevppName As String = ""
            If chkZip.Checked = True Then
                If Me.txtFilePassword.Text <> Me.txtConfirmPassword.Text Then
                    MsgBox("Password do not match", MsgBoxStyle.Information, My.Application.Info.Title)
                    Return
                End If
                Dim objZiping As New Common.Compresser
                If Me.txtFilePassword.Text <> "" Then
                    objZiping.Password = Me.txtFilePassword.Text
                    objZiping.Overrider = True
                End If

                DevppName = Devpp.Data.SQLSERVER.backup(txtDbBackup.Text)
                objZiping.Compress(DevppName)
                MsgBox("Backup" & "[" & objZiping.OutFile & "] successfully created.", MsgBoxStyle.Information, "Backup created.")
                My.Computer.FileSystem.DeleteFile(DevppName)
            Else

                DevppName = Devpp.Data.SQLSERVER.backup(txtDbBackup.Text)
                MsgBox("Backup" & "[" & DevppName & "] successfully created.", MsgBoxStyle.Information, "Backup created.")

            End If


        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        btnDBBackup.Cursor = Cursors.Default
    End Sub
    Private Sub btnDbRestore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDbRestore.Click

        Dim DlgResult As DialogResult

        If chkZip.Checked = False Then
            fbdRestoreFile.Filter = "SQL files |*.bak;*.ebk|All files (*.*)|*.*"
            DlgResult = fbdRestoreFile.ShowDialog()
            If DlgResult = Windows.Forms.DialogResult.OK Or DlgResult = Windows.Forms.DialogResult.Yes Then
                Dim DBDest As String = fbdRestoreFile.FileName
                If MsgBox("Are you sure you want to restore from file [" & DBDest & "] ?" & vbCrLf & _
                          "Restore operation is IRREVERSIBLE; your current data WILL BE OVERWRITTEN." & vbCrLf & _
                          "Click Yes to proceed or No to Cancel this operation.", MsgBoxStyle.YesNo) = MsgBoxResult.No _
                Then
                    MsgBox("Database restore was cancelled", MsgBoxStyle.Information, "Database not restored")
                    Exit Sub
                End If

                Cursor = Cursors.WaitCursor
                Try

                    If Devpp.Data.SQLSERVER.Restore(DBDest) = True Then
                        MsgBox("The restore was successful")
                        Me.ParentForm.Close()
                        Dim x As New Devpp.Forms.frmLogin
                        x.ShowDialog()
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                Cursor = Cursors.Default
            Else
                MsgBox("Database restore was cancelled", MsgBoxStyle.Information, "Database not restored")
            End If


        Else
            fbdRestoreFile.Filter = "Devpp copressed file|*.EZP|All files|*.*"
            DlgResult = fbdRestoreFile.ShowDialog()
            Dim objCompres As New Common.Compresser
            If DlgResult = Windows.Forms.DialogResult.OK Or DlgResult = Windows.Forms.DialogResult.Yes Then
                Dim DBDest As String = fbdRestoreFile.FileName
                If MsgBox("Are you sure you want to restore from file [" & DBDest & "] ?" & vbCrLf & _
                          "Restore operation is IRREVERSIBLE; your current data WILL BE OVERWRITTEN." & vbCrLf & _
                          "Click Yes to proceed or No to Cancel this operation.", MsgBoxStyle.YesNo) = MsgBoxResult.No _
                Then
                    MsgBox("Database restore was cancelled", MsgBoxStyle.Information, "Database not restored")
                    Exit Sub
                End If
                Cursor = Cursors.WaitCursor
                Try

                    If objCompres.Uncompress(DBDest) = True Then
                        If Devpp.Data.SQLSERVER.Restore(objCompres.OutFile) = True Then
                            MsgBox("The restore was successful")
                            My.Computer.FileSystem.DeleteFile(objCompres.OutFile)
                            Me.ParentForm.Close()
                            Dim x As New Devpp.Forms.frmLogin
                            x.ShowDialog()

                        End If
                    Else
                        Return
                    End If

                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
                Cursor = Cursors.Default
            Else
                MsgBox("Database restore was cancelled", MsgBoxStyle.Information, "Database not restored")
            End If
        End If
    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        If isConnected = True And isFromfrmLogin = True Then
            Dim x As New Forms.frmLogin
            isFromfrmLogin = False
            x.Show()
            Me.ParentForm.Close()
        Else
            Try
                If LoginStatus = True Then
                    Me.ParentForm.Close()
                    Devpp.ExitApplication()
                End If
            Catch ex As Exception

            End Try
        End If

        Try
            If Forms.frmLogin.UserLoged = False Then
                Me.ParentForm.Close()
                Devpp.ExitApplication()
            Else
                Me.ParentForm.Close()
            End If
        Catch ex As Exception

        End Try



    End Sub

    Private Sub btnOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpen.Click
        Dim dlgResult As DialogResult
        dlgResult = fbdBackup.ShowDialog()
        If dlgResult = DialogResult.OK Then
            txtDbBackup.Text = fbdBackup.SelectedPath
            Dim msg As DialogResult = MsgBox("Do you want to save changes?", MsgBoxStyle.Information + MsgBoxStyle.YesNo)
            If msg = DialogResult.Yes Then
                My.Settings.BackupPath = Me.txtDbBackup.Text
                updateConfig(Me.txtDbBackup.Text)
                My.Settings.Save()
            End If
        End If

    End Sub

    Private Sub btnRunScript_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRunScript.Click
        Dim con As New SqlClient.SqlConnection(Data.SQLSERVER.ConnectionString)
        If Me.txtScriptLocation.Text = "" Then
            MsgBox("Browse script location")
            Return
        End If
        Try

            For Each dr As DataRow In dtTable.Rows
                con.Open()
                Dim gu As Guid = Guid.NewGuid
                Dim strfile As String = IIf(My.Computer.FileSystem.SpecialDirectories.Temp.EndsWith("\"), My.Computer.FileSystem.SpecialDirectories.Temp & gu.ToString, My.Computer.FileSystem.SpecialDirectories.Temp & "\" & gu.ToString)
                Dim fs As New IO.FileStream(strfile, FileMode.Create, FileAccess.Write)
                Dim byts() As Byte = dr("Value")
                fs.Write(byts, 0, byts.Length)
                fs.Close()
                Dim strRea As New StreamReader(strfile)
                Dim strin As String = strRea.ReadToEnd

                Dim com As New SqlClient.SqlCommand(strin, con)
                strRea.Close()
                My.Computer.FileSystem.DeleteFile(strfile)


                com.ExecuteNonQuery()
                Dim V_string As String = "SELECT [Devpp] ,[Client],[Application] FROM [tblDevppVersion]"
                Dim adp As New SqlClient.SqlDataAdapter(V_string, con)
                Dim dt As New DataTable
                adp.Fill(dt)
                _DevppScriptVersion = dt.Rows(0)(0)
                _ClientScriptVersion = dt.Rows(0)(1)


                con.Close()
            Next

            chk.Checked = False
            MsgBox("Script excuted successfully")




        Catch ex As Exception
            con.Close()
            MsgBox("Script failed because of " & vbNewLine & ex.Message)
        End Try
    End Sub



    Private Sub cmbDBName_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbDBName.SelectedIndexChanged

    End Sub

    Private Sub chkAdvanced_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAdvanced.CheckedChanged
        If Devpp.Data.SQLSERVER.SelectedWinAuth = False And Me.chkAdvanced.Checked = True Then

            grpAdvConn.Visible = Me.chkAdvanced.Checked
        Else

            grpAdvConn.Visible = False
        End If
    End Sub
    Public Function Decrypt(ByVal key As String, ByVal inFile As String) As String
        Try
            Dim DESalg As New DESCryptoServiceProvider
            Dim fs As New FileStream(inFile, FileMode.Open)
            Dim objEncod As Encoding = Encoding.ASCII
            DESalg.IV = objEncod.GetBytes("11110000")

            DESalg.Key = objEncod.GetBytes(key)
            Dim cryp As New CryptoStream(fs, DESalg.CreateDecryptor(DESalg.Key, DESalg.IV), CryptoStreamMode.Read)
            Dim fileInf As New IO.FileInfo(inFile)
            Dim strReader As New StreamReader(cryp)

            Dim str As String = strReader.ReadToEnd
            strReader.Close()
            cryp.Close()
            fs.Close()

            Return str
        Catch ex As Exception
            Return "SELECT [name] FROM sys.databases"
        End Try
    End Function
    Public Function Decrypt(ByVal Key As String) As String
        Try
            Dim DESalg As New DESCryptoServiceProvider
            Dim dr As DataRowView = bsScript.Current
            Dim bytes() As Byte = dr("ScriptValue")
            Dim memStrm As New IO.MemoryStream(bytes)

            Dim objEncod As Encoding = Encoding.ASCII
            DESalg.IV = objEncod.GetBytes("11110000")

            DESalg.Key = objEncod.GetBytes(Key)
            Dim cryp As New CryptoStream(memStrm, DESalg.CreateDecryptor(DESalg.Key, DESalg.IV), CryptoStreamMode.Read)

            Dim strReader As New StreamReader(cryp)

            Dim str As String = strReader.ReadToEnd
            strReader.Close()
            cryp.Close()
            memStrm.Close()
            objReader = strReader
            Return str
        Catch ex As Exception
            Return "SELECT [name] FROM sys.databases"
        End Try

    End Function


    Private Sub Execution(Q As String)
        Dim con As New SqlClient.SqlConnection(Devpp.Data.SQLSERVER.ConnectionString)
        Try
            CurrentCount += 1
            AddLogFile(Now & "Executing Query: " & CurrentCount & " of " & TotalCount)
            con.Open()
          

            If Q.Split(" ")(0).ToUpper.Trim = "INSERT" Then
                Dim Table As String = Split(Q, " ")(1)
                Table = Table.Replace("[", "")
                Table = Table.Replace("]", "")

                Dim adp As New SqlClient.SqlDataAdapter(My.Resources.CHECKIDENTITY.Replace("<TABLE>", Table), con)
                Dim dTable As New DataTable
                adp.Fill(dTable)
                If dTable.Rows.Count > 0 Then
                  



                    Dim query As String = "SET IDENTITY_INSERT [" & Table & "] ON " & vbNewLine & Q & vbNewLine & "SET IDENTITY_INSERT [" & Table & "] OFF "
                    Q = query
                End If
            End If
           
           

            If con.State = ConnectionState.Closed Then
                con.Open()
            End If
            Dim com As New SqlClient.SqlCommand(Q, con)
            com.ExecuteNonQuery()
            AddLogFile(Now & "Executing Completed.")
           

        Catch ex As Exception
            AddLogFile(Now & "Executing fail Query:" & Q & " Error: " & ex.Message)


        End Try
        con.Close()

    End Sub
    Private Shared CurrentCount As Integer
    Private Shared TotalCount As Integer
    Friend Function DbInitBackUp() As Boolean

        Try
            CurrentCount = 0
            Dim txt As String = System.IO.File.ReadAllText(TemLocation)

            txt = txt.Replace(My.Resources._ANSI, "")
            txt = txt.Replace("$", "")
            txt = txt.Replace("GO" & vbNewLine, "$" & vbNewLine)

            Dim arr() As String = txt.Split("$")
            TotalCount = arr.Length

            For Each Q As String In arr
                Execution(Q)


            Next

           
            AddLogFile(Now & " Run template  completed successfully")
            Return True
        Catch ex As Exception
            My.Computer.FileSystem.DeleteFile(TemLocation)
            MsgBox("Failed to run template. Error:" & ex.Message, MsgBoxStyle.Information, My.Application.Info.Title)
            Throw New Exception("Failed to run template. Error:" & ex.Message)
        End Try
        Return True
    End Function




    Private Sub btnInitAndConn_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInitAndConn.Click
        If cmbInitInstances.Text = "" Then

            MsgBox("Cannot initialize without instance selected", MsgBoxStyle.Information, "Database initialization")
            Me.cmbInitInstances.Focus()
            Return
        End If
        If Me.txtCompNameInit.Text = "" Then
            MsgBox("Enter Company name ", MsgBoxStyle.Information, "Database initialization")
            Me.txtCompNameInit.Focus()
            Return
        End If
        If bsScript.Count <= 0 Then

            MsgBox("Cannot initialize Database template is empty", MsgBoxStyle.Information, "Database initialization")
            Me.cmbScriptType.Focus()
            Return
        End If
        Cursor = Cursors.WaitCursor
        Me.lblService.Visible = True
        Windows.Forms.Application.DoEvents()
        Me.prgService.Visible = True
        Windows.Forms.Application.DoEvents()
        Me.prgService.Value = 0
        Windows.Forms.Application.DoEvents()

        AddLogFile(Now & " Initializing Database ", "DBInit.txt", "DATABASE INITIALIZATION" & vbNewLine & "=====================")
        AddLogFile(Now & " Userlogin: " & Devpp.Common.Login.UserName)
        Me.lblService.Text = "Starting database initialization"
        Windows.Forms.Application.DoEvents()
        Threading.Thread.Sleep(1000)
        AddLogFile(Now & " Instance selected: " & Me.cmbInitInstances.Text)
        Threading.Thread.Sleep(1000)
        AddLogFile(Now & " Company name: " & Me.txtCompNameInit.Text)
        Threading.Thread.Sleep(1000)
        AddLogFile(Now & " Database name: " & Me.txtNewDbInit.Text)
        Threading.Thread.Sleep(1000)
        DBInitialization.isNewBD = chkNewDatabase.Checked
        If Me.txtNewDbInit.Text <> "" Then
            Try
                DBInitialization.DBPassword = Me.txtInitPass.Text
                DBInitialization.DbUserName = Me.txtInitUser.Text
                AddLogFile(Now & " Database initialization starts ")
                DBInitialization.Initialize(Me.txtNewDbInit.Text, Me.cmbInitInstances.Text, "master", Decrypt(PublicKey))
                Try
                    Dim dr As DataRowView = bsScript.Current
                    Dim bytes() As Byte = dr("Backup")

                    Dim strDevppice As String = ""
                    For Each Devppi As DriveInfo In My.Computer.FileSystem.Drives
                        If Devppi.IsReady Then

                            strDevppice = Devppi.Name
                            Exit For
                        End If

                    Next
                    If Not My.Computer.FileSystem.DirectoryExists(strDevppice & "DevppTemp") Then
                        My.Computer.FileSystem.CreateDirectory(strDevppice & "DevppTemp")
                    End If
                    TemLocation = strDevppice & "DevppTemp\DevppDB.bak"
                    AddLogFile(Now & " Creating database template files ")
                    Dim fs As New IO.FileStream(TemLocation, FileMode.Create, FileAccess.Write)
                    fs.Write(bytes, 0, bytes.Length)
                    fs.Close()

                Catch ex As Exception
                    MsgBox("Process failed because failed to create template file", MsgBoxStyle.Information, "Database initialization")
                    AddLogFile(Now & " Process failed because failed to create template file. ")
                    Return
                End Try
                Try
                    AddLogFile(Now & " Changing application configuration ")
                    chkWinAuth.Checked = True
                    Me.cmbDBInstance.Text = cmbInitInstances.Text
                    chkWinAuth.Checked = chkInitWinauth.Checked
                    My.Settings.DBInstance = cmbDBInstance.Text
                    My.Settings.DBName = Me.txtNewDbInit.Text
                    My.Settings.WindowsAuth = chkWinAuth.Checked
                    My.Settings.BackupPath = txtDbBackup.Text
                    My.Settings.Save()
                    updateConfig(Me.txtNewDbInit.Text, cmbDBInstance.Text, chkWinAuth.Checked)
                    Devpp.DatabaseName = My.Settings.DBName
                    Devpp.ServerName = My.Settings.DBInstance
                    Devpp.Data.SQLSERVER.SelectedWinAuth = My.Settings.WindowsAuth
                    RaiseEvent ConnectionChangedCom(Me, e)


                    If Devpp.Data.SQLSERVER.CheckServerConnection = True Then
                        AddLogFile(Now & " Initializing Application-Database connection")
                        InitializeConnection(commonDefault)
                        AddLogFile(Now & " connection Initialized successfully ")
                        Threading.Thread.Sleep(1000)
                        AddLogFile(Now & " Running templates ")
                        If DbInitBackUp() = True Then
                            Try


                                Dim v_bool As Boolean = False
                                AddLogFile(Now & " Checking sa configuration ")
                                Dim connect As New ServerConnection(ServerName, "sa", Data.SQLSERVER.SelectedPassword)

                                Dim objServer As New Server(connect)

                                Try
                                    Dim dbser As New Database(objServer, DatabaseName)
                                    dbser.ExecuteNonQuery("Select * from tblDevppUser")

                                Catch ex As Exception
                                    AddLogFile(Now & " Chenging sa settings ")

                                    v_bool = True
                                    Try
                                        connect = New ServerConnection(ServerName, Data.SQLSERVER.SelectedUsername, Data.SQLSERVER.SelectedPassword)
                                        objServer = New Server(connect)

                                        objServer.Logins("sa").ChangePassword(Data.SQLSERVER.SelectedPassword)
                                        AddLogFile(Now & " Changing sa password ")
                                        Threading.Thread.Sleep(1000)
                                        objServer.Logins("sa").Enable()
                                        AddLogFile(Now & " Enable sa login ")
                                        Threading.Thread.Sleep(1000)
                                    Catch exv As Exception
                                        AddLogFile(Now & " Failed to configure sa ")
                                    End Try

                                End Try
                            Catch ex As Exception
                                AddLogFile(Now & " Failed to configure sa to Devpp SOFTWARE configuration because of " & ex.Message)
                                MsgBox("Failed to configure sa to SOFTNET SOFTWARE configuration ", MsgBoxStyle.Information, "Database initialization")
                            End Try
                            My.Computer.FileSystem.DeleteFile(TemLocation)
                            AddLogFile(Now & " Deleting temp files")
                            System.Threading.Thread.Sleep(1000)
                            AddLogFile(Now & " Initialization completed successfully ")
                            Me.prgService.Value = 100
                            System.Windows.Forms.Application.DoEvents()
                            Me.lblService.Text = " Initialization completed successfully "
                            System.Windows.Forms.Application.DoEvents()
                            System.Threading.Thread.Sleep(3000)
                            Me.lblService.Visible = False
                            System.Windows.Forms.Application.DoEvents()
                            Me.prgService.Visible = False
                            System.Windows.Forms.Application.DoEvents()
                            prgService.Value = 0
                            lblService.Text = ""
                            Dim result As Windows.Forms.DialogResult = MsgBox("The log file location:- " & vbNewLine & ApplicationLocation & "\" & LogFile & _
                                                                              vbNewLine & "Do you want to open file?", MsgBoxStyle.YesNo + MsgBoxStyle.Information, My.Application.Info.Title)
                            If result = DialogResult.Yes Then
                                Try
                                    Process.Start(ApplicationLocation & "\" & LogFile)
                                Catch ex As Exception
                                    MsgBox("Connot able to open a file " & ex.Message)
                                End Try
                            End If

                            Forms.frmLogin.canExit = True
                            Dim x As New Devpp.Forms.frmLogin
                            Dim SQLSERVER As New Devpp.Data.SQLSERVER
                            SQLSERVER.initialize()
                            x.Show()
                            Try
                                Me.ParentForm.Close()
                            Catch ex As Exception

                            End Try


                            Cursor = Cursors.Default
                        End If
                    End If
                Catch ex As Exception
                    AddLogFile(Now & " process failed because of " & ex.Message)
                    Cursor = Cursors.Default
                    MsgBox(ex.Message & vbNewLine & "The log file location" & vbNewLine & ApplicationLocation & "\" & LogFile)
                    isDevppAllowed = False
                    DBInitialization.ServerShutedDown = False
                End Try
            Catch ex As Exception
                AddLogFile(Now & " process failed because of " & ex.Message)
                MsgBox(ex.Message & vbNewLine & "The log file location" & vbNewLine & ApplicationLocation & "\" & LogFile)
                isDevppAllowed = False
                DBInitialization.ServerShutedDown = False
                Cursor = Cursors.Default

            End Try

        End If
        Cursor = Cursors.Default
    End Sub
    Private DatabaseName As String = Nothing

    Private Sub txtCompNameInit_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCompNameInit.LostFocus
        If Not Devpp.Data.SQLSERVER.CheckServerConnection Or Me.cmbInitInstances.Text = "" Then Exit Sub


        Cursor = Cursors.WaitCursor
        Try
            AddLogFile(Now & " Checking database ")
            Databases()
            Dim dtBase As String = Nothing
            Dim chkDB As Boolean = False

            For Each dr As DataRowView In Binder.List
                If dr(0).ToString.ToUpper = DatabaseName.ToUpper Then
                    chkDB = True
                    Exit For
                End If
            Next
            If chkDB = True Then
                For i As Integer = 1 To 10
                    Dim chk As Boolean = False
                    dtBase = DatabaseName + i.ToString

                    For Each dr As DataRowView In Binder.List
                        If dr(0) = dtBase Then
                            chk = True
                            Exit For
                        End If

                    Next
                    If chk = False Then
                        Me.txtNewDbInit.Text = dtBase
                        Cursor = Cursors.Default
                        Exit Sub
                    End If
                Next

            End If
            Me.txtNewDbInit.Text = DatabaseName
            AddLogFile(Now & " " & DatabaseName & " will be created")
        Catch ex As Exception
            AddLogFile(Now & " " & "Process failed because of " & ex.Message)
            tim.Enabled = False

        End Try
        Cursor = Cursors.Default
    End Sub

    
    Private Sub txtCompNameInit_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCompNameInit.TextChanged
        DatabaseName = Devpp.DatabasePrefix + "_" + Me.txtCompNameInit.Text.Replace(" ", "_")
    End Sub








    Private Sub btnBrowseScript_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowseScript.Click
        Try
            Dim opendlg As New Windows.Forms.OpenFileDialog
            opendlg.Filter = "Devpp file|*.exf"
            If opendlg.ShowDialog <> DialogResult.Cancel Then
                FileLocation = opendlg.FileName
                Me.txtScriptLocation.Text = FileLocation



                Dim gu As Guid = Guid.NewGuid
                Dim strfile As String = IIf(My.Computer.FileSystem.SpecialDirectories.Temp.EndsWith("\"), My.Computer.FileSystem.SpecialDirectories.Temp & gu.ToString, My.Computer.FileSystem.SpecialDirectories.Temp & "\" & gu.ToString)
                Dim StrWr As New IO.StreamWriter(strfile)
                Dim str2 As String = Decrypt(PublicKey, opendlg.FileName)

                StrWr.WriteLine(str2)
                StrWr.Close()
                dtTable.Clear()
                Try

                    dtTable.ReadXml(strfile)
                    My.Computer.FileSystem.DeleteFile(strfile)
                    If dtTable.Rows(0)("AppVersion") <> My.Application.Info.Version.MinorRevision Then
                        MsgBox("This script is not compatible to this application" & vbNewLine & "Application version " & _
                                My.Application.Info.Version.MinorRevision & " but script application version is " & dtTable.Rows(0)("AppVersion"))
                        Exit Sub
                    End If
                    If dtTable.Rows(0)("Version") <= DevppScriptVersion And dtTable.Rows(0)("Type") = "Devpp" Then
                        MsgBox("Devpp script is already in use")
                        chk.Checked = False
                        Exit Sub
                    End If
                    If DevppScriptVersion + 2 < dtTable.Rows(0)("Version") And dtTable.Rows(0)("Type") = "Devpp" Then
                        Dim str As String = ""
                        Dim v_int As Integer = 0
                        For x As Integer = DevppScriptVersion + 1 To CShort(dtTable.Rows(0)("Version")) - 1
                            If x = CShort(dtTable.Rows(0)("Version")) - 1 Then
                                str = str & ", " & x & ". "
                                Exit For
                            End If
                            If v_int = 0 Then
                                str = str & x
                            Else
                                str = str & ", " & x
                            End If
                            v_int += 1
                        Next
                        MsgBox("You have to run script " & str & "before runnung this script", MsgBoxStyle.Information, "Devpp Script")
                        chk.Checked = False
                        Exit Sub
                    End If
                    If dtTable.Rows(0)("Version") <= ClientScriptVersion And dtTable.Rows(0)("Type") = "Client" Then
                        MsgBox("Client script is already in use")
                        chk.Checked = False
                        Exit Sub
                    End If
                    If ClientScriptVersion + 2 < dtTable.Rows(0)("Version") And dtTable.Rows(0)("Type") = "Client" Then
                        Dim str As String = ""
                        Dim v_int As Integer = 0
                        For x As Integer = ClientScriptVersion + 1 To CShort(dtTable.Rows(0)("Version")) - 1
                            If x = CShort(dtTable.Rows(0)("Version")) - 1 Then
                                str = str & ", " & x & ". "
                                Exit For
                            End If
                            If v_int = 0 Then
                                str = str & x
                            Else
                                str = str & ", " & x
                            End If
                            v_int += 1
                        Next
                        MsgBox("You have to run script " & str & "before runnung this script", MsgBoxStyle.Information, "Client Script")
                        chk.Checked = False
                        Exit Sub
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                    chk.Checked = False
                    Exit Sub
                End Try
            Else
                Exit Sub
            End If


        Catch ex As Exception
            MsgBox(ex.Message)
            chk.Checked = False
            Exit Sub
        End Try
        chk.Checked = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeName.Click

        Dim frmChange As New frmDBChange
        frmChange.BackColor = Me.BackColor
        If frmChange.ShowDialog <> DialogResult.Cancel Then

            DatabaseName = Devpp.DatabasePrefix + "_" + frmChange.txtDatabaseName.Text.Replace(" ", "_")
            Cursor = Cursors.WaitCursor
            Try
                Databases()
                Dim dtBase As String = Nothing
                Dim chkDB As Boolean = False

                For Each dr As DataRowView In Binder.List
                    If dr(0) = DatabaseName Then
                        chkDB = True
                        Exit For
                    End If
                Next
                If chkDB = True Then
                    For i As Integer = 1 To 10
                        Dim chk As Boolean = False
                        dtBase = DatabaseName + i.ToString

                        For Each dr As DataRowView In Binder.List
                            If dr(0) = dtBase Then
                                chk = True
                                Exit For
                            End If

                        Next
                        If chk = False Then
                            Me.txtNewDbInit.Text = dtBase
                            Cursor = Cursors.Default
                            Exit Sub
                        End If
                    Next

                End If
                Me.txtNewDbInit.Text = DatabaseName
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
        Cursor = Cursors.Default
    End Sub

    Private Sub chkUseSecondConection_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkUseSecondConection.CheckedChanged
        sbCHKSecondConnection()
    End Sub
    Private Sub sbCHKSecondConnection()
        Dim MDatabasePrefix = DatabasePrefix
        If chkUseSecondConection.Checked = True Then
            btnConnect.Visible = False
            chkAdvanced.Visible = False
            DatabasePrefix = ""
        Else
            btnConnect.Visible = True
            chkAdvanced.Visible = True
            DatabasePrefix = MDatabasePrefix
        End If
    End Sub

    Dim V_int As Integer = 0

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Me.tim = New Timer
        Me.tim.Interval = 1000
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub chk_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chk.CheckedChanged
        Me.btnRunScript.Enabled = chk.Checked
    End Sub

    Private Sub cmbInitInstances_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbInitInstances.TextChanged
        Me.txtCompNameInit.Enabled = True
        btnInitAndConn.Enabled = True
        btnChangeName.Enabled = True
    End Sub



    Private Sub ComboBox1_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbInitInstances.Validated
        If vBool = False Or Me.cmbInitInstances.Text = "" Then Exit Sub
        Me.txtCompNameInit.Enabled = True
        btnInitAndConn.Enabled = True
        If cmbInitInstances.Text <> "System.Data.DataRowView" Or cmbInitInstances.Text <> "" Then
            Devpp.Data.SQLSERVER.ServerName = cmbInitInstances.Text
            Devpp.Data.SQLSERVER.SelectedWinAuth = Me.chkInitWinauth.Checked
            Devpp.Data.SQLSERVER.SelectedUsername = Me.txtInitUser.Text
            Devpp.Data.SQLSERVER.SelectedPassword = Me.txtInitPass.Text
            If Not Devpp.Data.SQLSERVER.CheckServerConnection Then
                MsgBox("Cannot be able to connect to selected instance.", MsgBoxStyle.Information, "Connection")
                Me.cmbInitInstances.SelectedIndex = -1
                txtNewDbInit.Text = ""
                Me.cmbInitInstances.Focus()
                Me.txtCompNameInit.Enabled = False
                btnInitAndConn.Enabled = False
                btnChangeName.Enabled = False
                Me.txtCompNameInit.Text = ""
                Return
            End If

            Dim frm As New frmMassage
            Dim serv As New Server()
            Dim dimTempCon As String = "Data Source=" & Me.cmbInitInstances.Text & ";Initial Catalog = master"

            Try
                If Data.SQLSERVER.SelectedWinAuth = True Then

                    dimTempCon += ";integrated security=SSPI;persist security info=False; Trusted_Connection=Yes"
                Else

                    dimTempCon += ";User ID= " & Me.txtSpecUserName.Text & ";Password=" & Me.txtPassword.Text
                End If

                serv.ConnectionContext.ConnectionString = dimTempCon
                If serv.Settings.LoginMode <> ServerLoginMode.Mixed Then

                    frm.lblText.Text = "The software has detected that the SQL SERVER INSTANCE SELECTED" & _
               " HAS NOT PREVIOUSLY BEEN SET UP FOR SOFTNET SOFTWARE PRODUCT. " & vbNewLine & vbNewLine & _
               "By continuing this PROCESS The software will clear all current logins and secure the SQL SERVER for " & _
               "Devpp SOFTWARE only." & vbNewLine & vbNewLine & _
               "Do you want to continue?"
                    Me.txtCompNameInit.Text = "DB"
                    If frm.ShowDialog = DialogResult.Yes Then

                        isDevppAllowed = True
                        DBInitialization.ServerShutedDown = True
                        txtCompNameInit.Text = ""
                        txtNewDbInit.Text = ""
                        txtCompNameInit.Focus()
                    Else
                        Me.txtCompNameInit.Text = ""
                        txtNewDbInit.Text = ""
                        Me.txtCompNameInit.Enabled = False
                        btnInitAndConn.Enabled = False
                        btnChangeName.Enabled = False
                        Me.cmbInitInstances.Focus()
                    End If
                End If
            Catch ex As Exception

                MsgBox(ex.Message)
            End Try
        End If
    End Sub


    Dim vBool As Boolean = False
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Cursor = Cursors.WaitCursor

        Try
            btnRefresh.Cursor = Cursors.WaitCursor

            cmbInitInstances.DataSource = Devpp.Data.SQLSERVER.getSqlInstances()
            cmbInitInstances.DisplayMember = "Instance"
            cmbDBInstance.DataSource = cmbInitInstances.DataSource
            cmbDBInstance.DisplayMember = "Instance"
            vBool = True
            btnRefresh.Cursor = Cursors.Default

        Catch ex As Exception

            MsgBox(ex.Message)
        End Try
        Cursor = Cursors.Default
    End Sub




    Private Sub chkZip_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkZip.CheckedChanged
        Me.Panel1.Visible = Me.chkZip.Checked
    End Sub




    Private Sub chkInitAdv_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkInitAdv.CheckedChanged
        Me.grpInit.Visible = Me.chkInitAdv.Checked
    End Sub

    Private Sub chkInitWinauth_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkInitWinauth.CheckedChanged
        If Me.chkInitWinauth.Checked Then
            Me.chkInitAdv.Visible = False
            Me.chkInitAdv.Checked = False
        Else
            Me.chkInitAdv.Visible = True
        End If
        Data.SQLSERVER.SelectedWinAuth = chkInitWinauth.Checked
    End Sub

  
   
End Class

