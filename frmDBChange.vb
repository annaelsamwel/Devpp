Imports System.Windows.Forms

Friend Class frmDBChange

    Private Sub txtDatabaseName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDatabaseName.KeyUp
        If e.KeyCode = Keys.Enter Then
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

End Class
