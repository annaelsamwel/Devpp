Imports System.Windows.Forms
Friend Class frmLock
    Private v_bl As Boolean = False
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim x As New Common.Login
        If x.unlock(Me.TextBox1.Text) = True Then
            v_bl = True
            Me.Close()
        Else
            MsgBox("Wrong Password")
            Me.TextBox1.Text = ""
            Me.TextBox1.Focus()
        End If
    End Sub
    Private Sub frmLock_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If v_bl = False Then
            e.Cancel = True
        Else
            v_bl = False
        End If
    End Sub
    Private Sub frmLock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
       
        Me.TextBox1.Focus()
    End Sub
    
    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As System.Object, e As System.EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class
