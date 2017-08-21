Imports system.data
Imports System.Data.SqlClient

Namespace Forms

    Public Class frmFilePasswordChange

        Private strCurrentPwd As String
        'Private strPwd As String
        Private strNewPwd As String
        Private strConfirmNewPwd As String
        Private strUserName As String


        Private Sub frmApplPasswordChange_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Devpp.Common.Login.UserName.ToUpper = "GUEST" Or Devpp.Common.Login.UserName.ToUpper = "Devpp" Then
                MsgBox("Not allowed to edit this user", MsgBoxStyle.Information, My.Application.Info.Title)
                Me.Close()
            End If

            lblCurrentUser.Text = "User: " & strUserName

            '===========================================================



        End Sub

        Private Sub btnCancelPwd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelPwd.Click
            If Common.Login.Password = Devpp.Common.Login.PasswordToKeyCode("ABCabc123") Then
                Devpp.Global.ExitApplication()
            End If


            txtCurrentPwd.Text = Nothing
            txtNewPwd.Text = Nothing
            txtConfirmPwd.Text = Nothing
            Me.Close()
        End Sub

        Private Sub btnChangePwd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangePwd.Click
            Dim log As New Common.Login
            strCurrentPwd = txtCurrentPwd.Text
            strNewPwd = txtNewPwd.Text
            strConfirmNewPwd = txtConfirmPwd.Text
            If strCurrentPwd = strCurrentPwd Then
                If strNewPwd = "" Or strConfirmNewPwd = "" Then
                    MsgBox("Empty Password not allowed", MsgBoxStyle.Information, "User information")
                    Exit Sub
                End If
                If strNewPwd = strConfirmNewPwd Then

                    Try
                        If Common.Login.usrStrongPass = True Then
                            log.CheckStrongPassword(Me.txtNewPwd.Text)
                        End If
                        log.ChangePassWord(Me.txtCurrentPwd.Text, Me.txtNewPwd.Text)
                        MsgBox("Password changed successfully!", MsgBoxStyle.Information, "User information")
                        txtCurrentPwd.Text = Nothing
                        txtNewPwd.Text = Nothing
                        txtConfirmPwd.Text = Nothing
                        Me.Close()
                        Exit Sub
                    Catch ex As Exception
                        MsgBox(ex.Message)
                        Exit Sub
                    End Try
                Else
                    MsgBox("Failed to confirm the password! Please re-enter the same password for confirmation.", _
                             MsgBoxStyle.Information, "User information")
                    Exit Sub
                End If
            Else
                MsgBox("Please make sure the current password is entered correctly.", MsgBoxStyle.Information, "User information")
                Exit Sub
            End If
        End Sub
    End Class
End Namespace