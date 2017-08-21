Namespace UserControls
    Public Class ucImageLibrary
        Private WithEvents BindinSource As New Windows.Forms.BindingSource
        Private _ReturnID As Integer
        Private _ReturnImage As System.Drawing.Image
        Private _ReturnDescription As String
        Private Imaging As New Common.Imaging
        Private Sub LoadImage()
            Me.PictureBox1.Image = Nothing
            Me.Imaging.ImageList.Clear()
            Me.Imaging.FillImageList()
            Me.BindinSource.DataSource = Imaging.ImageList
        End Sub
        Public ReadOnly Property ReturnID() As Integer
            Get
                Return _ReturnID
            End Get
        End Property
        Public ReadOnly Property ReturnImage()
            Get
                Return _ReturnImage
            End Get
        End Property
        Public ReadOnly Property ReturnDescription() As String
            Get
                Return _ReturnDescription
            End Get
        End Property
        Private Sub SetImageToPictureBox()
            If Me.BindinSource.Count = 0 Then
                Me.PictureBox1.Image = Nothing
                Return
            End If
            Try
                Dim dr As DataRowView = BindinSource.Current
                Dim buff As Byte() = dr("ImageValue")
                Me.lblDescription.Text = dr("ImageDescription")
                Dim imConv As New System.Drawing.ImageConverter
                Dim newImage As System.Drawing.Image = imConv.ConvertFrom(buff)

                Me.PictureBox1.Image = newImage
            Catch ex As Exception
                Me.PictureBox1.Image = Nothing
            End Try
        End Sub
        Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
            Me.lblRecord.Text = ""
            LoadImage()

        End Sub

        Private Sub BindinSource_CurrentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles BindinSource.CurrentChanged
            Me.lblRecord.Text = Me.BindinSource.Position + 1 & "/" & Me.BindinSource.Count
            If Me.BindinSource.Count > 0 Then
                SetImageToPictureBox()
            End If
        End Sub

        Private Sub btnFirst_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirst.Click
            If Me.BindinSource.Count > 0 Then
                Me.BindinSource.MoveFirst()
            End If
        End Sub

        Private Sub btnPreviouse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPreviouse.Click
            If Me.BindinSource.Count > 0 Then
                Me.BindinSource.MovePrevious()
            End If
        End Sub

        Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
            If Me.BindinSource.Count > 0 Then
                Me.BindinSource.MoveNext()
            End If
        End Sub

        Private Sub btnLast_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLast.Click
            If Me.BindinSource.Count > 0 Then
                Me.BindinSource.MoveLast()
            End If
        End Sub

        Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOk.Click, PictureBox1.DoubleClick
            Me._ReturnID = 0
            Me.ParentForm.DialogResult = Windows.Forms.DialogResult.OK
            Me._ReturnImage = Nothing
            If Me.BindinSource.Count > 0 Then
                Dim dr As DataRowView = Me.BindinSource.Current
                _ReturnID = dr("ImageID")
                _ReturnImage = Me.PictureBox1.Image
                _ReturnDescription = dr("ImageDescription")
            End If
            Me.ParentForm.Close()
        End Sub

        Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
            Cursor = Windows.Forms.Cursors.WaitCursor
            Dim buff() As Byte
            Try
                Dim dlgopen As New Windows.Forms.OpenFileDialog
                dlgopen.Filter = "Image files|*.JPG;*.BMP;*.PNG;*.JIF;*.PNG;*.DIB;*.JPE;*.JPEG;*.TIF;*.TIFF;*.JFIF"
                If dlgopen.ShowDialog <> Windows.Forms.DialogResult.Cancel Then
                    Dim filInfo As New IO.FileInfo(dlgopen.FileName)
                    ReDim buff(filInfo.Length - 1)
                    Dim fstr As New IO.FileStream(dlgopen.FileName, IO.FileMode.Open)
                    fstr.Read(buff, 0, filInfo.Length - 1)
                    fstr.Close()
                    PictureBox1.Image = System.Drawing.Image.FromFile(dlgopen.FileName)
                    Imaging.InsertImage(Me.PictureBox1, filInfo.Name.Replace(filInfo.Extension, ""))
                    Me.lblRecord.Text = ""
                    LoadImage()
                    Me.BindinSource.MoveLast()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
            Cursor = Windows.Forms.Cursors.Default
        End Sub

        Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
            If Me.BindinSource.Count > 0 Then
                Dim result As Windows.Forms.DialogResult = MsgBox("Are you sure you want to delete this photo?", MsgBoxStyle.Information + MsgBoxStyle.YesNo, "Deleting")
                If result = Windows.Forms.DialogResult.No Then
                    Return
                End If
                Dim dr As DataRowView = Me.BindinSource.Current
                Imaging.DeleteImage(dr("ImageID"))
                Me.lblRecord.Text = ""
                LoadImage()
            End If
        End Sub

        Private Sub ToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem1.Click
            Me.lblRecord.Text = ""
            LoadImage()
        End Sub

        Private Sub PictureBox1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PictureBox1.Click

        End Sub

        'Private Sub PictureBox1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles PictureBox1.DoubleClick
        '    If Me.PictureBox1.Image IsNot Nothing Then
        '        Dim frm As New frmEditImage
        '        frm.PictureBox1.Image = Me.PictureBox1.Image
        '        frm.ShowDialog()
        '    End If
        'End Sub

        Private Sub txtSearch_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSearch.TextChanged
            If Me.txtSearch.Text <> "" Then
                Me.BindinSource.Filter = "ImageDescription = '" & Me.txtSearch.Text & "'"
            Else
                Me.BindinSource.Filter = ""
            End If

        End Sub
    End Class
End Namespace

