Imports System.Windows.Forms
Namespace Forms
    Public NotInheritable Class frmRightManagement
        Private WithEvents ucusr As ucUsers
        Private WithEvents ucgrp As UserControls.ucGroups
        Public Event RightChecked(ByVal sender As Object, ByVal e As Security.NodeCheckedEventarg)
        Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            Me.Close()
        End Sub
        Private isGroup As Boolean = False
        Private isUserBlochked As Boolean = False
        Private Sub frmRightManagement_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            If ucgrp.grpList.DataChanged = True Or Me.ucusr.DataChanged = True Then
                Dim result As Windows.Forms.DialogResult = MsgBox("Sorry! you have made changes" & vbNewLine & "Do you want to save changes?", MsgBoxStyle.Information + MsgBoxStyle.YesNoCancel, My.Application.Info.Title)
                If result = Windows.Forms.DialogResult.Cancel Then
                    ucusr.LoadData()
                    ucgrp.grpList.LoadData()
                    e.Cancel = True
                ElseIf result = Windows.Forms.DialogResult.Yes Then
                    Try
                        ucusr.SaveMaping()
                        ucgrp.grpList.SaveRight()
                        MsgBox("Data saved successfully", MsgBoxStyle.Information, My.Application.Info.Title)
                    Catch ex As Exception
                        MsgBox(ex.Message)
                        e.Cancel = True
                    End Try
                End If
            End If
        End Sub

        Private Sub frmRightManagement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            If Not DLLRegistered Then
                Throw New Exception("Devpp DLL not registered")
            End If

            ucgrp = New UserControls.ucGroups
            ucgrp.Dock = DockStyle.Fill
            ucusr = New ucUsers
            ucusr.Initialize()
            ucgrp.grpList.Users = ucusr
            ucusr.Dock = DockStyle.Fill
            Me.TabPage1.Controls.Add(ucusr)
            Me.TabPage2.Controls.Add(ucgrp)
        End Sub


        Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
            Try
                If ucusr.DataChanged = True Or ucgrp.grpList.DataChanged = True Then
                    ucusr.SaveMaping()
                    ucgrp.grpList.SaveRight()
                    Me.btnOK.Enabled = False
                    Try
                        Security.SystemRights.LoginUserRights.DataSource = Security.RightManager.GetUserRights(Common.Login.UserID)
                    Catch ex As Exception

                    End Try
                    MsgBox("Data saved successfully", MsgBoxStyle.Information, My.Application.Info.Title)

                End If

            Catch ex As Exception
                MsgBox(ex.Message)

            End Try
        End Sub

        Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

            Dim frmreport As New frmRightReport
            If isGroup = True Then
                frmreport.IsGroup = True
                frmreport.isBlocked = ucgrp.rdoNonActiveGroups.Checked
                If ucgrp.rdoNonActiveGroups.Checked = True Then
                    frmreport.ReportParam = "Non-Active Groups"
                Else
                    frmreport.ReportParam = "Active Groups"
                End If
            Else
                frmreport.IsGroup = False
                frmreport.isBlocked = ucusr.rdoBlocked.Checked
                If ucusr.rdoBlocked.Checked = True Then
                    frmreport.ReportParam = "Blocked users"
                Else
                    frmreport.ReportParam = "Active Users"
                End If

            End If
            frmreport.ShowDialog()
        End Sub


        Private Sub TabPage1_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage1.Enter
            isGroup = False
        End Sub

        Private Sub TabPage2_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabPage2.Enter
            isGroup = True
        End Sub

        Private Sub ucgrp_DataChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucgrp.DataChanged
            Me.btnOK.Enabled = True
        End Sub

        Private Sub ucgrp_RightChecked(ByVal sender As Object, ByVal e As Security.NodeCheckedEventarg) Handles ucgrp.RightChecked
            RaiseEvent RightChecked(sender, e)
        End Sub

        Private Sub TabRightManagement_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabRightManagement.SelectedIndexChanged

            Try
                If ucusr.DataChanged = True Or ucgrp.grpList.DataChanged = True Then
                    ucusr.SaveMaping()
                    ucgrp.grpList.SaveRight()
                End If
                Try
                    Security.SystemRights.LoginUserRights.DataSource = Security.RightManager.GetUserRights(Common.Login.UserID)
                Catch ex As Exception

                End Try
            Catch ex As Exception

            End Try

        End Sub




        Private Sub ucusr_onDataChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucusr.onDataChanged
            Me.btnOK.Enabled = True
        End Sub
    End Class
End Namespace