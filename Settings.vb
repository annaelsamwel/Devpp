Imports System.Drawing
Imports System.Data
Friend Class Settings
#Region "Fields"
    Private Shared _BackGroundColor1 As Color = Color.FromName("Control")
    Private Shared _BackGroundColor2 As Color = Color.FromName("Control")
    Private Shared _FontColor As Color = Color.FromName("Black")
    Private Shared _UserName As String
    Private Shared _Language As Languages

    Private Shared _ExControls As New List(Of System.Type)
    Private Shared _Font As Font = New Drawing.Font("Microsoft Sans Serif", 8, FontStyle.Regular)

#End Region
#Region "Property"


    Public Shared Property Font() As Font
        Get
            Return _Font
        End Get
        Set(ByVal value As Font)
            _Font = value
        End Set
    End Property


    ''' <summary>
    ''' The background of the main form for each form for user loged in
    ''' </summary>
    Public Shared Property BackGroundColor1() As Color
        Get
            Return _BackGroundColor1
        End Get
        Set(ByVal value As Color)
            _BackGroundColor1 = value
        End Set
    End Property
    Public Shared Property BackGroundColor2() As Color
        Get
            Return _BackGroundColor2
        End Get
        Set(ByVal value As Color)
            _BackGroundColor2 = value
        End Set
    End Property
    Public Shared Property FontColor() As Color
        Get
            Return _FontColor
        End Get
        Set(ByVal value As Color)
            _FontColor = value
        End Set
    End Property
    Public Shared Property UserName() As String
        Get
            Return _UserName
        End Get
        Set(ByVal value As String)
            _UserName = value
            AppSetting.GetUserName = value
        End Set
    End Property
    Public Shared Property Language() As Languages
        Get
            Return _Language
        End Get
        Set(ByVal value As Languages)
            _Language = value
        End Set
    End Property

#End Region
#Region "Methods"
    Friend Shared Sub ShowApplicationAttributes()
        Dim x As New frmApplicationAttributes
        x.ShowDialog()
    End Sub
    Friend Shared Sub ApplySetting()
        Try

            Dim dtTa As DataTable = Devpp.UserSettings(Devpp.Common.Login.UserID, Common.UserSetting.UpdateSettings)
            ReadSettings()
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Friend Shared Sub ReadSettings()
        If Devpp.Common.Login.UserName = Nothing Then
            Return
        End If
        Try
            Dim dtTable As New DataTable
            dtTable = Devpp.UserSettings(Devpp.Common.Login.UserID, Common.UserSetting.GetSettings)
            If dtTable.Rows.Count > 0 Then
                _BackGroundColor1 = Color.FromArgb(dtTable.Rows(0)(0))
                _BackGroundColor2 = Color.FromArgb(dtTable.Rows(0)(1))
                _FontColor = Color.FromArgb(dtTable.Rows(0)(2))
                _Language = dtTable.Rows(0)(3)
                Dim bo As Boolean = False
                Dim sng As Single = 8
                Dim fontName As String = "Microsoft Sans Serif"
                If Not dtTable.Rows(0).IsNull(6) Then
                    bo = dtTable.Rows(0)(6)

                End If

                If Not dtTable.Rows(0).IsNull(5) Then
                    sng = dtTable.Rows(0)(5)
                End If
                If Not dtTable.Rows(0).IsNull(4) Then
                    fontName = dtTable.Rows(0)(4)
                End If
                If bo = True Then
                    Dim ft As New Font(fontName, sng, FontStyle.Bold)
                    _Font = ft
                Else
                    Dim ft As New Font(fontName, sng, FontStyle.Regular)
                    _Font = ft
                End If

            End If

            Try
                MainForm.BackColor = _BackGroundColor1

            Catch ex As Exception
                _BackGroundColor1 = Color.FromName("Control")
                MainForm.BackColor = _BackGroundColor1
            End Try
            MainForm.Font = _Font
            MainForm.ForeColor = _FontColor
            For Each f As System.Windows.Forms.Form In AppForms
                f.BackColor = _BackGroundColor1
                f.ForeColor = _FontColor
                f.Font = _Font
            Next
            For Each cont As Windows.Forms.Control In AppControls
                cont.BackColor = _BackGroundColor2
            Next
        Catch ex As Exception

        End Try
    End Sub
#End Region
    Public Enum Languages
        English = 0
        Swahili = 1
        Japanese = 2
        Chinese = 3
    End Enum
End Class
