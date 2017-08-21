Public Class ucLicenseInfo

    Private Sub ucLicenseInfo_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Windows.Forms.Keys.Enter Then
            Me.ParentForm.Close()
        End If
    End Sub



    Private Sub ucLicenseInfo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            If isLicensed = True Then
                Dim def As New Devpp.Common.Defaults
                Dim dateOffset As Integer = def.GetDefault(1, -1)
                lblAccounts.Checked = IIf((128 And LicenseStream) > 0, True, False)
                lblSales.Checked = IIf((2 And LicenseStream) > 0, True, False)
                lblInventory.Checked = IIf((1 And LicenseStream) > 0, True, False)
                lblStockTransfer.Checked = IIf((16 And LicenseStream) > 0, True, False)
                lblPayRoll.Checked = IIf((32 And LicenseStream) > 0, True, False)
                lblHumanResource.Checked = IIf((4096 And LicenseStream) > 0, True, False)
                lblTimeSheets.Checked = IIf((8192 And LicenseStream) > 0, True, False)
                lblAssets.Checked = IIf((64 And LicenseStream) > 0, True, False)
                If LicenseDate = 0 Or LicenseDate = 65535 Then
                    lblDueDate.Text += "Unknown"
                Else
                    lblDueDate.Text += DateAdd(DateInterval.Year, dateOffset, Date.FromOADate(LicenseDate))
                End If

                lblEmployeeCount.Text = LicensedEmployees
                If LicenseNumber = 0 Or LicenseNumber = 65535 Then
                    lblLicenseNumber.Text += "Unknown"
                Else
                    lblLicenseNumber.Text += CStr(LicenseNumber)
                End If
            End If
        Catch ex As Exception
            Throw New Exception("Error reading license information")
        End Try

    End Sub


End Class
