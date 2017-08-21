Namespace UserControls
    Friend Class ucCreateUser
        Private Const UPassword As String = "ABCabc123"
        Private authentification As Devpp.Common.Authetification
        Private Sub switchOptionBox()
            If Me.optDomain.Checked = True Then

                authentification = Common.Authetification.Domain
            Else

                If Me.optBoth.Checked = True Then
                    authentification = Common.Authetification.Both
                ElseIf optDevpp.Checked = True Then
                    authentification = Common.Authetification.Devpp
                End If
            End If
        End Sub
        Private Sub ucCreateUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            authentification = Common.Authetification.Domain
            Try
                Dim str As String = ParentForm.Text
                Me.ParentForm.BackColor = Settings.BackGroundColor1
                Me.ParentForm.ForeColor = Settings.FontColor
                Me.ParentForm.Font = Settings.Font

            Catch ex As Exception
                Me.btnCancel.Visible = False
            End Try
        End Sub

        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Try
                ParentForm.Close()
            Catch ex As Exception

            End Try
        End Sub

        Private Sub optDomain_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optDomain.CheckedChanged

            switchOptionBox()
        End Sub
        Private Sub CreateUser()
            Dim sqlcon As New SqlClient.SqlConnection(Data.SQLSERVER.ConnectionString)

            Try
                If txtUserName.Text.ToUpper = "Devpp" Or txtUserName.Text.ToUpper = "GUEST" Then
                    Me.txtUserName.Focus()
                    Me.txtUserName.SelectAll()

                    Throw New Exception("Sorry! Devpp or Guest not allowed, please change the user name. ")
                End If
                If authentification = Common.Authetification.Devpp Then
                    If txtUserName.Text = "" Then
                        Throw New Exception("Enter User name, password and confirm password")
                    End If
                Else
                    If txtUserName.Text = "" Then
                        Throw New Exception("Enter user name")
                    End If
                End If

                If Common.Login.GetLogin(Me.txtUserName.Text, 0, 3).Rows.Count > 0 Then

                    Throw New Exception("Sorry! You can`t create user: ''" & Me.txtUserName.Text & "'' is arleady exists")
                End If
                Dim strSQL As String = "INSERT INTO tblDevppUser (usrName, usrPassword, usrDomain, usrCreateUserID, usrAuditCreateDate, usrIsGroup ,[usrPasswordChanged]) " & _
                " VALUES (@usrName, @usrPassword, @usrDomain, @usrCreateUserID, @usrAuditCreateDate, @usrIsGroup, @usrPasswordChanged)"
                Dim sqlCom As New SqlClient.SqlCommand(strSQL, sqlcon)
                sqlCom.Parameters.Add("@usrName", SqlDbType.NVarChar, 50)
                sqlCom.Parameters.Add("@usrPassword", SqlDbType.Int)
                sqlCom.Parameters.Add("@usrDomain", SqlDbType.Int)
                sqlCom.Parameters.Add("@usrCreateUserID", SqlDbType.Int)
                sqlCom.Parameters.Add("@usrAuditCreateDate", SqlDbType.DateTime)
                sqlCom.Parameters.Add("@usrIsGroup", SqlDbType.Bit)

                sqlCom.Parameters("@usrName").Value = Me.txtUserName.Text
                sqlCom.Parameters("@usrPassword").Value = Common.Login.PasswordToKeyCode(UPassword)
                sqlCom.Parameters("@usrDomain").Value = authentification
                sqlCom.Parameters("@usrCreateUserID").Value = Common.Login.UserID
                sqlCom.Parameters("@usrAuditCreateDate").Value = Devpp.Data.SQLSERVER.GetCurrentDate
                sqlCom.Parameters("@usrIsGroup").Value = False
                sqlCom.Parameters.Add("@usrPasswordChanged", SqlDbType.SmallDateTime)
                sqlCom.Parameters("@usrPasswordChanged").Value = Devpp.Data.SQLSERVER.GetCurrentDate
                sqlcon.Open()
                sqlCom.ExecuteNonQuery()
                sqlcon.Close()
                Me.txtUserName.Text = Nothing
                ReadUserGroups()
                GetUsers()
            Catch ex As Exception
                sqlcon.Close()
                Throw New Exception(ex.Message)
            End Try

        End Sub

        Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
            Try
                CreateUser()
                ParentForm.Close()
            Catch ex As Exception
                MsgBox(ex.Message, MsgBoxStyle.Information, My.Application.Info.Title)
            End Try
        End Sub

        Private Sub optDevpp_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optDevpp.CheckedChanged
            switchOptionBox()
        End Sub

        Private Sub optBoth_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles optBoth.CheckedChanged
            switchOptionBox()
        End Sub

        
    End Class
End Namespace