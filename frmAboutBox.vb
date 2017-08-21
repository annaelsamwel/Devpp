Namespace Forms
    Public NotInheritable Class frmAboutBox

        Private Sub AboutBox1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim ApplicationTitle As String
            ApplicationTitle = My.Application.Info.Title
            Me.Text = String.Format("About {0}", ApplicationTitle)
            Me.LabelProductName.Text = My.Application.Info.ProductName
            Me.LabelVersion.Text = My.Application.Info.Version.ToString
            Me.LabelCopyright.Text = My.Application.Info.Copyright
            Me.LabelCompanyName.Text = My.Application.Info.CompanyName
            Me.TextBoxDescription.Text = My.Application.Info.Description
        End Sub
        Private Sub OKButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OKButton.Click
            Me.Dispose()
        End Sub

    End Class
End Namespace
