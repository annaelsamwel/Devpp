Imports System.Windows.Forms
Namespace Forms

    Public NotInheritable Class frmDBUtilities
        Private WithEvents ucDbUtil As ucDbUtilities
        Private _RunScript As Boolean = False
        Friend MyfrmLogin As New Devpp.Forms.frmLogin
        Public Event ConnectionChangedCom(ByVal sender As Object, ByVal e As EventArgs)
        Public Property RunScript() As Boolean
            Get
                Return _RunScript
            End Get
            Set(ByVal value As Boolean)
                _RunScript = value
            End Set
        End Property



        Private Sub frmDBUtilities_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

            Me.Controls.Clear()

            ucDbUtil = New ucDbUtilities
            ucDbUtil.MyfrmLogin = MyfrmLogin
            ucDbUtil.RunScript = RunScript
            ucDbUtil.Dock = DockStyle.Fill
            Me.Controls.Add(ucDbUtil)

        End Sub

        Public Sub New()

            ' This call is required by the Windows Form Designer.
            InitializeComponent()

            ' Add any initialization after the InitializeComponent() call.

        End Sub

        Private Sub ucDbUtil_ConnectionChangedCom(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucDbUtil.ConnectionChangedCom
            RaiseEvent ConnectionChangedCom(sender, e)
        End Sub
    End Class
End Namespace
