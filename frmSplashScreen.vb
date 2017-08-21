
Namespace Forms
    Public Class frmSplashScreen

        Friend Shared Event SplashScreenStatusChange(ByVal e As String)

       
        Public Overridable Sub [Exit]()
            MainForm.Close()
        End Sub

        Private Sub LoadSettings(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
            'If Not DLLRegistered Then
            '    Throw New Exception("Devpp DLL not registered")
            'End If
            ApplicationTitle.Text = My.Application.Info.Title
            Version.Text = "Version " + My.Application.Info.Version.ToString
            Copyright.Text = My.Application.Info.Copyright
            Me.lblDescription.Text = My.Application.Info.Description
            Me.lblStatus.Text = SplashScreenStatus
            Me.Timer1.Enabled = True
            Me.Timer1.Start()
            frmLogin.canExit = True
        End Sub

       
        Private Sub MainLayoutPanel_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MainLayoutPanel.Paint

        End Sub

        Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick
            If Me.lblStatus.Text <> SplashScreenStatus Then
                Me.lblStatus.Text = SplashScreenStatus
            End If
        End Sub

       
    End Class
   
End Namespace