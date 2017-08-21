Namespace Security

    Public MustInherit Class EntryPoint

        Public Sub New()
            DLLRegistered = False
        End Sub
        Public MustOverride Property Key() As Object
        Protected Sub Register(ByVal V_bool As Boolean)
            DLLRegistered = V_bool


        End Sub
    End Class
End Namespace

