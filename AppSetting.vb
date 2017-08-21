Imports System.Drawing
Imports System.Data
Imports System.ComponentModel
Imports System.Windows.Forms
''' <summary>
''' This is the friend class which used to manage user settings and application settins
''' Created by Annael Samwel
''' </summary>
''' <remarks></remarks>
Friend Class AppSetting
    Inherits Component
    ''' <summary>
    ''' '
    ''' </summary>
    ''' <remarks></remarks>
#Region "Fields"

   
    Public Shared uspValues() As Object
    Private Shared _rootNamespace As String
    Private _BackGroundColor1 As Color = Settings.BackGroundColor1
    Private _BackGroundColor2 As New Color
    Private _FontColor As New Color
    Private _UserName As String
    Private _Language As Settings.Languages
    Private _ControlList As New List(Of Control)
    Friend Shared GetUserName As String

    Private _Font As Font
#End Region
#Region "Constractor"
    Public Sub New()
        _BackGroundColor1 = Devpp.Settings.BackGroundColor1
        _BackGroundColor2 = Devpp.Settings.BackGroundColor2
        _UserName = Devpp.Common.Login.UserName
        Settings.UserName = _UserName
        _Language = Devpp.Settings.Language
        _FontColor = Devpp.Settings.FontColor
        Try
            MainForm.BackColor = Settings.BackGroundColor1
            For Each f As Form In AppForms
                f.BackColor = _BackGroundColor1
                f.Font = _Font
                
            Next
            For Each col As Control In AppControls
                col.BackColor = _BackGroundColor2
            Next
        Catch ex As Exception

        End Try
        
    End Sub
#End Region
#Region "Property"
    <Browsable(False)> _
    Public ReadOnly Property ControlList() As List(Of Control)
        Get
            Return _ControlList
        End Get
    End Property
   
    Public Property BackGroundColor1() As Color
        Get
            Return _BackGroundColor1
        End Get
        Set(ByVal value As Color)
            _BackGroundColor1 = value
            Settings.BackGroundColor1 = value
            MainForm.BackColor = value
            For Each f As Form In AppForms
                f.BackColor = value

            Next
        End Set
    End Property
    <Browsable(False)> _
    Public Property Font() As Font
        Get
            Return _Font
        End Get
        Set(ByVal value As Font)
            _Font = value
            MainForm.Font = value
            Settings.Font = value
            For Each f As Form In AppForms
                f.Font = value

            Next

        End Set
    End Property
    Public Property BackGroundColor2() As Color
        Get
            Return _BackGroundColor2
        End Get
        Set(ByVal value As Color)
            _BackGroundColor2 = value
            Settings.BackGroundColor2 = value
            For Each cont As Control In _ControlList
                cont.BackColor = value
            Next
            For Each frm As Form In AppForms
                For Each cot As Control In frm.Controls
                    cot.BackColor = value
                Next

            Next
        End Set
    End Property
    Public Property FontColor() As Color
        Get
            Return _FontColor
        End Get
        Set(ByVal value As Color)
            _FontColor = value
            Settings.FontColor = value
            MainForm.ForeColor = value
            For Each f As Form In AppForms
                f.ForeColor = value
            Next
        End Set
    End Property
    Public ReadOnly Property UserName() As String
        Get
            GetUserName = _UserName
            Return _UserName
        End Get

    End Property
    <Browsable(False)> _
    Public Property Language() As Settings.Languages
        Get
            Return _Language
        End Get
        Set(ByVal value As Settings.Languages)
            _Language = value
            Settings.Language = value
        End Set
    End Property

    
#End Region

End Class
