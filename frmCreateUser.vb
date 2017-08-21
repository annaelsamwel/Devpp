Imports System.Windows.Forms
Imports Devpp.UserControls

Friend Class frmCreateUser

    Private Sub frmCreateUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim x As New ucCreateUser
        x.BackColor = Me.BackColor
        x.Dock = DockStyle.Fill
        Me.Panel1.Controls.Clear()
        Me.Panel1.Controls.Add(x)
    End Sub
End Class
