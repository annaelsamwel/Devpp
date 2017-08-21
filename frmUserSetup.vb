Imports System.Data.SqlClient
Imports System.Data
Imports Devpp.Common

Namespace Forms
    Friend Class frmUserSetup
        Private authentification As Devpp.Common.Authetification
        Friend CurrenUserID As Integer

        Private Sub switchOptionBox()
            If Me.optDomain.Checked = True Then
                Me.txtConfirmPassword.ReadOnly = True
                Me.txtPassword.ReadOnly = True
                authentification = Common.Authetification.Domain
            Else
                Me.txtConfirmPassword.ReadOnly = False
                Me.txtPassword.ReadOnly = False
                If Me.optBoth.Checked = True Then
                    authentification = Common.Authetification.Both
                ElseIf optDevpp.Checked = True Then
                    authentification = Common.Authetification.Devpp
                End If
            End If
        End Sub

        Private Sub frmUserSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            On Error Resume Next
            Me.cmbContact.DataSource = _ContactTable
            Me.cmbContact.DisplayMember = "FullName"
            Me.cmbContact.ValueMember = "ID"
            Dim selSQL As String = "SELECT [usrPid], [usrName] ,[usrPassword] ,[PepId] ,[usrIsGroup] ,[usrIsBlocked] ,[usrDomain] " & _
                                     " ,[usrLanguage] ,[usrRetryBlock] ,[usrPasswordValidity] ,[usrPasswordChanged] ,[usrStrongPassword] " & _
                                      ",[usrBackColour1] ,[usrBackColour2] ,[usrFontColour] ,[usrFlag] ,[usrCreateUserID] ,[usrAuditCreateDate] " & _
                                     " ,[usrFontName] ,[usrFontSize] ,[usrIBold] " & _
                                    " FROM [tblDevppUser] WHERE [usrPid] =  " & CurrenUserID.ToString
            Me.BackColor = Settings.BackGroundColor1
            Me.ForeColor = Settings.FontColor
            Me.Font = Settings.Font

            Me.btnAdd.Focus()
            Dim sqlcon As New SqlClient.SqlConnection(Devpp.Data.SQLSERVER.ConnectionString)
            Dim Adapter As New SqlClient.SqlDataAdapter(selSQL, sqlcon)
            Dim dtTable As New DataTable
            Adapter.Fill(dtTable)
            If dtTable.Rows(0)("usrDomain") = 0 Then
                Me.optDomain.Checked = True
            ElseIf dtTable.Rows(0)("usrDomain") = 1 Then
                Me.optDevpp.Checked = True
            ElseIf dtTable.Rows(0)("usrDomain") = 2 Then
                Me.optBoth.Checked = True
            Else
                Me.optDomain.Checked = True
            End If
            Dim getuser As String = "SELECT  [usrName] FROM [tblDevppUser] WHERE [usrPid] =  " & IIf(dtTable.Rows(0)("usrCreateUserID") Is DBNull.Value, 0, dtTable.Rows(0)("usrCreateUserID"))
            Dim userDapter As New SqlClient.SqlDataAdapter(getuser, sqlcon)
            Dim userdtTable As New DataTable
            userDapter.Fill(userdtTable)
            Me.txtCreateUserId.Text = IIf(userdtTable.Rows(0)("usrName") Is DBNull.Value, "", userdtTable.Rows(0)("usrName"))
            Me.cmbContact.SelectedValue = dtTable.Rows(0)("PepId")
            Me.dtpCreateDate.Value = dtTable.Rows(0)("usrAuditCreateDate")
            Me.dtpPasswordChanged.Value = dtTable.Rows(0)("usrPasswordChanged")
            Me.chkStrongPassword.Checked = Login.AllowStrongPassword
            Me.chkStrongPassword.Enabled = IIf(Login.AllowStrongPassword = True, False, True)
            If Me.chkStrongPassword.Enabled = True Then
                Me.chkStrongPassword.Checked = dtTable.Rows(0)("usrStrongPassword")
            End If
            If Login.LoginRetrial > 0 Then
                Me.Label2.Text = "Blocked After " + Login.LoginRetrial.ToString + " Attempts:"
            Else
                Me.Label2.Text = ""
            End If
            Me.txtPasswordValidity.Text = Login.PassExpirationDays()
            Me.chkRetryBlockCheckBox.Checked = Login.AllowBlockPassword
            If Login.LoginRetrial > 0 Then
                Me.chkRetryBlockCheckBox.Visible = True
                Me.chkRetryBlockCheckBox.Enabled = IIf(Login.AllowBlockPassword = True, False, True)
            Else
                Me.chkRetryBlockCheckBox.Visible = False
            End If

            If chkRetryBlockCheckBox.Enabled = True Then
                chkRetryBlockCheckBox.Checked = dtTable.Rows(0)("usrRetryBlock")
            End If
            Me.txtPasswordValidity.ReadOnly = IIf(Login.PassExpirationDays = 0, False, True)
            If Me.txtPasswordValidity.Text = 0 Then

                Me.txtPasswordValidity.Text = dtTable.Rows(0)("usrPasswordValidity")

            End If

        End Sub




        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me.Close()
        End Sub

        Private Sub optDomain_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optDomain.CheckedChanged
            switchOptionBox()
        End Sub

        Private Sub optDevpp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optDevpp.CheckedChanged
            switchOptionBox()
        End Sub

        Private Sub optBoth_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optBoth.CheckedChanged
            switchOptionBox()
        End Sub

        Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
            Dim atemp As Integer = 0
            If Me.chkRetryBlockCheckBox.Checked = True Then
                atemp = Login.LoginRetrial
            End If

            Dim v_i As Integer = authentification
            Dim strUpdatesql As String = "UPDATE [tblDevppUser] SET [usrPassword] = " & Common.Login.PasswordToKeyCode(Me.txtPassword.Text).ToString & _
            ", [usrDomain]= " & v_i.ToString & ", [usrPasswordChanged] = @date, [usrPasswordValidity] = @validity " & _
           ", [usrRetryBlock] = @retry, [usrStrongPassword] = '" + Me.chkStrongPassword.Checked.ToString + "', [PepId] = " & iif(Me.cmbContact.SelectedValue = Nothing, 0, Me.cmbContact.SelectedValue) & " WHERE [usrPid] = " & CurrenUserID.ToString

            Dim sqlcon As New SqlClient.SqlConnection(Data.SQLSERVER.ConnectionString)
            Dim com As New SqlClient.SqlCommand(strUpdatesql, sqlcon)
            com.Parameters.Add("@date", SqlDbType.SmallDateTime)
            com.Parameters("@date").Value = Devpp.Data.SQLSERVER.GetCurrentDate
            com.Parameters.Add("@validity", SqlDbType.Int).Value = Me.txtPasswordValidity.Text
            com.Parameters.Add("@retry", SqlDbType.Bit).Value = chkRetryBlockCheckBox.Checked
            Try
                If optDomain.Checked = False Then
                    If Me.txtPassword.Text = "" Or Me.txtConfirmPassword.Text = "" Then
                        Throw New Exception("Your must enter password")
                    End If
                    If Me.txtConfirmPassword.Text <> Me.txtPassword.Text Then
                        Throw New Exception("Password does not match")
                    End If
                    If chkStrongPassword.Checked = True Then
                        Dim login As New Common.Login
                        login.CheckStrongPassword(Me.txtPassword.Text)
                    End If
                End If
                sqlcon.Open()
                com.ExecuteNonQuery()
                sqlcon.Close()
                Me.Close()
            Catch ex As Exception
                sqlcon.Close()
                MsgBox(ex.Message)

            End Try
        End Sub

        Private Sub pnUinfo_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pnUinfo.Paint

        End Sub


        Private Sub cmbContact_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles cmbContact.KeyDown
            If e.KeyCode = Windows.Forms.Keys.Back Then
                Me.cmbContact.SelectedIndex = -1
            End If
        End Sub

        Private Sub cmbContact_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles cmbContact.MouseDown
            If e.Button = Windows.Forms.MouseButtons.Right Then
                Me.cmbContact.SelectedIndex = -1
            End If
        End Sub
    End Class
End Namespace
