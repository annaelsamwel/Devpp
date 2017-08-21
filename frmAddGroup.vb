Imports System.Windows.Forms

Friend Class frmAddGroup
    Public usrManager As Security.UserManager
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        For Each dr As DataRowView In usrManager.GroupBindingSource.List
            If Me.txtGroup.Text.ToUpper = dr("usrName").ToString.ToUpper Then
                MsgBox("Sorry! the group is already exists")
                Exit Sub
            End If
        Next
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

   
End Class
