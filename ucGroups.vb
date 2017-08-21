Namespace UserControls
    Friend Class ucGroups
        Public WithEvents grpList As New Security.UserManager
        Public Event RightChecked(ByVal sender As Object, ByVal e As Security.NodeCheckedEventarg)
        Public Event DataChanged(ByVal sender As Object, ByVal e As EventArgs)

        Public Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            Me.pnlGroups.Controls.Add(grpList.ListBox)
            Me.pnlRight.Controls.Add(grpList.Treview)
            ' Add any initialization after the InitializeComponent() call.

        End Sub

        Private Sub rdoActiveGroup_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoActiveGroup.CheckedChanged
            If rdoActiveGroup.Checked = True Then
                grpList.GroupFilter(1)
            Else
                grpList.GroupFilter(0)
            End If
        End Sub





        Private Sub btnSave_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.LostFocus
            sender.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
            sender.BackColor = Drawing.Color.Silver
            sender.ForeColor = Drawing.Color.Black

        End Sub

        Private Sub btnSave_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnCancel.MouseDown
            sender.BorderStyle = Windows.Forms.BorderStyle.Fixed3D
            sender.BackColor = Drawing.Color.Gray
            sender.ForeColor = Drawing.Color.Black
        End Sub

        Private Sub btnSave_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.MouseEnter
            sender.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
            sender.BackColor = Drawing.Color.Gold
            sender.ForeColor = Drawing.Color.White
        End Sub

        Private Sub btnSave_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.MouseLeave
            sender.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
            sender.BackColor = Drawing.Color.Silver
            sender.ForeColor = Drawing.Color.Black
        End Sub

        Private Sub btnSave_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnCancel.MouseUp
            sender.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
            sender.BackColor = Drawing.Color.Silver
            sender.ForeColor = Drawing.Color.Black
            If grpList.DataChanged = True Then
                grpList.SaveRight()
                sender.BorderStyle = Windows.Forms.BorderStyle.FixedSingle
                sender.BackColor = Drawing.Color.Silver
                sender.ForeColor = Drawing.Color.Black
                MsgBox("Data saved succesifull!", MsgBoxStyle.Information, My.Application.Info.Title)
            End If

        End Sub

        Private Sub grpList_onDataChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles grpList.onDataChanged
            RaiseEvent DataChanged(sender, e)
        End Sub





        Private Sub grpList_RightChecked(ByVal sender As Object, ByVal e As Security.NodeCheckedEventarg) Handles grpList.RightChecked

            RaiseEvent RightChecked(Me, e)
        End Sub

        Private Sub btnCancel_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
            grpList.LoadData()
        End Sub
    End Class
End Namespace

