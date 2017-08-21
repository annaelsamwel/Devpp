Imports System.Windows.Forms


Friend Class frmApplicationAttributes

    Private Sub frmApplicationAttributes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim x As New AppSetting
        Me.PropertyGrid1.SelectedObject = x
        Me.BackColor = Settings.BackGroundColor1
        Me.ForeColor = Settings.FontColor
        Me.Font = Settings.Font
    End Sub

    Private Sub btnApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApply.Click
        Try
            Settings.ApplySetting()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Settings.ReadSettings()
        Me.Close()
    End Sub
    Private Sub PropertyGrid1_PropertyValueChanged(ByVal s As Object, ByVal e As System.Windows.Forms.PropertyValueChangedEventArgs) Handles PropertyGrid1.PropertyValueChanged
        Me.BackColor = Settings.BackGroundColor1
        Me.ForeColor = Settings.FontColor
        Me.Font = Settings.Font
    End Sub

   
    Private Sub PropertyGrid1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PropertyGrid1.Click

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        Try
            Settings.ApplySetting()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Settings.ReadSettings()
        Me.Close()
    End Sub
End Class