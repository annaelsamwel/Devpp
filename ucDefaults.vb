Namespace UserControls
    Public Class ucDefaults
        Private Headerbuff() As Byte
        Private Footerbuff() As Byte
        Protected objDefault As Common.Defaults
        Private GetImageID As Integer
        Private IMgID As Integer
        Private intAction As Integer
        Public Event EditCompanyClick()
        Private HeaderID As Integer
        Private FooterID As Integer
        Private HeaderFitToSize As Boolean = False
        Private FooterFitToSize As Boolean = False
        Private HeaderImage As Drawing.Image
        Private FooterImage As Drawing.Image
        Protected Sub LoadCompany()
            If CompanyQuery <> "" Then

                Dim con As New SqlClient.SqlConnection(Data.SQLSERVER.ConnectionString)
                Dim Adapter As New SqlClient.SqlDataAdapter(CompanyQuery, con)
                Dim dtTable As New DataTable
                Adapter.Fill(dtTable)
                Me.cmbCompany.DataSource = dtTable
                Me.cmbCompany.DisplayMember = dtTable.Columns(1).ColumnName
                Me.cmbCompany.ValueMember = dtTable.Columns(0).ColumnName
            End If
        End Sub
        Private Sub btnBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBrowse.Click
            'Cursor = Windows.Forms.Cursors.WaitCursor
            Try
                Dim dlgopen As New Forms.frmShowImageLibrary
                'dlgopen.Filter = "Image files|*.JPG;*.BMP;*.PNG;*.JIF;*.PNG;*.DIB;*.JPE;*.JPEG;*.TIF;*.TIFF;*.JFIF"
                If dlgopen.ShowDialog = Windows.Forms.DialogResult.OK Then
                    
                    Me.imgLogo.Image = dlgopen.Image

                    SetImage(Me.imgLogo.Image)
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            'Cursor = Windows.Forms.Cursors.Default
        End Sub
        Private Sub SetImage(ByVal Image As Drawing.Image)
            If Me.rbHeader.Checked Then
                HeaderImage = Image
            Else
                FooterImage = Image
            End If
        End Sub
        
        Private Sub chkSguare_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSguare.CheckedChanged
            If chkSguare.Checked = True Then
                Me.imgLogo.SizeMode = Windows.Forms.PictureBoxSizeMode.Normal
            Else
                Me.imgLogo.SizeMode = Windows.Forms.PictureBoxSizeMode.StretchImage
            End If
            If Me.rbHeader.Checked Then
                HeaderFitToSize = chkSguare.Checked
            Else
                FooterFitToSize = chkSguare.Checked
            End If
        End Sub
        Private Sub GetImage()
            On Error Resume Next
            If Me.rbHeader.Checked Then
                imgLogo.Image = HeaderImage
                chkSguare.Checked = HeaderFitToSize
            Else
                imgLogo.Image = FooterImage
                chkSguare.Checked = FooterFitToSize
            End If
        End Sub
        Private Sub GetDefault()
            Dim img As New Common.Imaging
            Me.cmbAction.Text = "Do nothing"
            On Error Resume Next
            Dim dt As Date
            Dim int As Integer = 0
            Dim str As String = ""
            Dim arr() As Byte
            Dim bl As Boolean
            Me.chkAllowChangeDB.Checked = objDefault.GetDefault(bl, 112)
            HeaderID = objDefault.GetDefault(int, 105)
            FooterID = objDefault.GetDefault(int, 113)
            HeaderImage = img.LoadImageFromDB(HeaderID)
            FooterImage = img.LoadImageFromDB(FooterID)
            Me.cmbCompany.SelectedValue = objDefault.GetDefault(0I, 101)
            Me.chkStrongPassword.Checked = objDefault.GetDefault(bl, 102)
            Me.txtAttepts.Text = objDefault.GetDefault(int, 103)
            Me.txtPassMaxChar.Text = objDefault.GetDefault(int, 108)
            Me.txtPassMinChar.Text = objDefault.GetDefault(int, 109)
            Me.txtPassValidity.Text = objDefault.GetDefault(int, 107)
            Me.dtCompanyStarted.Value = objDefault.GetDefault(dt, 104)
            Me.chkBlockuser.Checked = objDefault.GetDefault(bl, 110)
            HeaderFitToSize = objDefault.GetDefault(bl, 105)
            FooterFitToSize = objDefault.GetDefault(bl, 113)
            If Me.rbHeader.Checked Then
                chkSguare.Checked = HeaderFitToSize
            Else
                chkSguare.Checked = FooterFitToSize
            End If
            intAction = objDefault.GetDefault(intAction, 111)
            If intAction = 0 Then
                Me.cmbAction.Text = "Do nothing"
            ElseIf intAction = 1 Then
                Me.cmbAction.Text = "Block user"
            Else
                Me.cmbAction.Text = "Exit"
            End If
            GetImageID = HeaderID
        End Sub
        Private Function SetDefaults() As Boolean
            'On Error Resume Next

            Dim dt As Date = Me.dtCompanyStarted.Value

            objDefault.SetDefault(dt, 104, "Reporting date offset")
            objDefault.SetDefault(intAction, 111, "Block user or exit the system")
            Dim int As Integer = Me.txtPassValidity.Text
            objDefault.SetDefault(int, 107, "Password Expiration Days")
            int = Me.txtPassMinChar.Text
            objDefault.SetDefault(int, 109, "PassMinChar")
            int = Me.txtPassMaxChar.Text
            objDefault.SetDefault(int, 108, "PassMaxChar")
            int = Me.txtAttepts.Text
            objDefault.SetDefault(int, 103, "Retry Password count")
            Dim str As String = cmbCompany.Text
            objDefault.SetDefault(str, 101, "Company Name")
            int = cmbCompany.SelectedValue
            objDefault.SetDefault(int, 101, "Company Name")
            Dim bl As Boolean = Me.chkStrongPassword.Checked
            objDefault.SetDefault(bl, 102, "Strong Password")
            bl = Me.chkAllowChangeDB.Checked
            objDefault.SetDefault(bl, 112, "Allow change database")

            Dim img As New Common.Imaging
            img.InsertImage(HeaderImage)
            HeaderID = img.NewImageID
            img.InsertImage(FooterImage)
            FooterID = img.NewImageID

            objDefault.SetDefault(HeaderID, 105, "Company Logo")
            objDefault.SetDefault(FooterID, 113, "Footer")
            ' bl = Me.chkSguare.CheckState
            objDefault.SetDefault(HeaderFitToSize, 105, "Fit to Size")
            objDefault.SetDefault(FooterFitToSize, 113, "Fit to Size")
            bl = Me.chkBlockuser.Checked
            objDefault.SetDefault(bl, 110, "Allow Block Password")
            Return True
        End Function
        Protected Overridable Sub GetDefault(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
            Dim v_bool As Boolean = DLLRegistered
            DLLRegistered = True
            If Not DLLRegistered Then
                Throw New Exception("Devpp DLL not registered")
            End If
            objDefault = New Common.Defaults
            LoadCompany()
            GetDefault()
            DLLRegistered = v_bool
            GetImage()
        End Sub

        Protected Overridable Sub Save(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
            If isLicensed = True Then
                If SetDefaults() = True Then
                    MsgBox("Saved OK", MsgBoxStyle.Information, "Save")
                Else
                    MsgBox("En error occured during the save process", MsgBoxStyle.Information, "Save")
                End If
                GetDefault()
                initCommonDefaults()
            Else
                messageNoLicense()
            End If
        End Sub

        Private Sub txtAttepts_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAttepts.TextChanged
            Me.chkBlockuser.Width = Me.grpPasswordLogin.Width - 1
            Me.chkBlockuser.Text = "Block user after " & Me.txtAttepts.Text.ToString & " attempts"
        End Sub

        Private Sub cmbAction_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAction.SelectedIndexChanged
            If Me.cmbAction.Text = "Do nothing" Then
                intAction = 0
            ElseIf Me.cmbAction.Text = "Block user" Then
                intAction = 1
            Else
                intAction = 2
            End If

        End Sub



        Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
            RaiseEvent EditCompanyClick()
        End Sub

        Private Sub CopyToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CopyToolStripMenuItem.Click
            If Me.imgLogo.Image IsNot Nothing Then
                Windows.Forms.Clipboard.SetImage(Me.imgLogo.Image)
            End If


        End Sub

        Private Sub PasteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasteToolStripMenuItem.Click
            If Windows.Forms.Clipboard.GetImage IsNot Nothing Then
                Me.imgLogo.Image = Windows.Forms.Clipboard.GetImage

                SetImage(Me.imgLogo.Image)
                Return
            End If
            If Windows.Forms.Clipboard.GetFileDropList.Count > 0 Then
                Dim V_string As String = Windows.Forms.Clipboard.GetFileDropList(Windows.Forms.Clipboard.GetFileDropList.Count - 1)
                Try
                    Me.imgLogo.Image = Drawing.Image.FromFile(V_string)
                    SetImage(Me.imgLogo.Image)
                Catch ex As Exception
                    MsgBox(ex.Message)
                Finally

                End Try
            End If
        End Sub

        Private Sub LibraryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LibraryToolStripMenuItem.Click
            btnBrowse_Click(sender, e)
        End Sub

        Private Sub rbHeader_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbHeader.CheckedChanged
            GetImage()
        End Sub

        
        Public Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub
    End Class
End Namespace