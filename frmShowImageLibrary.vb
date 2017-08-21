Imports System.Windows.Forms
Namespace Forms
    Public Class frmShowImageLibrary

        Public ID As Integer
        Public Image As System.Drawing.Image
        Public ImageDescription As String
        Private ImageLibrary As UserControls.ucImageLibrary

        Private Sub frmShowImageLibrary_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
            ID = ImageLibrary.ReturnID
            Image = ImageLibrary.ReturnImage
            ImageDescription = ImageLibrary.ReturnDescription
        End Sub
        Private Sub frmShowImageLibrary_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ImageLibrary = New UserControls.ucImageLibrary
            ImageLibrary.Dock = DockStyle.Fill
            Me.Controls.Add(ImageLibrary)
        End Sub
    End Class
End Namespace