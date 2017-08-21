Imports System.Drawing

Friend Class frmMassage

    Private Sub frmMassage_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Text = My.Application.Info.Title
        Dim icon1 As New Drawing.Icon(SystemIcons.Warning, 40, 40)
        Dim btm As Bitmap = icon1.ToBitmap
        Me.PictureBox1.Image = btm
        Me.btnNo.Focus()
    End Sub

    Private Sub frmMassage_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint

    End Sub

    Private Sub btnYes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYes.Click
        Me.DialogResult = Windows.Forms.DialogResult.Yes
        Me.Close()
    End Sub
End Class