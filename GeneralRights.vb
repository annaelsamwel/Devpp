' ***********************************************************************
' Assembly         : Dev++
' Author           : Annael Samwel
' Created          : 08-18-2014
'
' Last Modified By : user
' Last Modified On : 06-01-2010
' ***********************************************************************
' <copyright file="GeneralRights.vb" company="Annael">
'     Copyright © Annael 2010
' </copyright>
' <summary></summary>
' ***********************************************************************
''' <summary>
''' The Security namespace.
''' </summary>
Namespace Security
    ''' <summary>
    ''' Class GeneralRights. This class cannot be inherited.
    ''' </summary>
    Public NotInheritable Class GeneralRights
        ''' <summary>
        ''' The _ initialize bd
        ''' </summary>
        Private Shared _InitializeBD As Boolean = True
        ''' <summary>
        ''' The _ database connection
        ''' </summary>
        Private Shared _DBConnection As Boolean = True
        ''' <summary>
        ''' The _ database utility tools
        ''' </summary>
        Private Shared _DBUtilityTools As Boolean = True
        ''' <summary>
        ''' The _ back up database
        ''' </summary>
        Private Shared _BackUpDB As Boolean = True
        ''' <summary>
        ''' The _ restore database
        ''' </summary>
        Private Shared _RestoreDB As Boolean = True
        ''' <summary>
        ''' The _ run script
        ''' </summary>
        Private Shared _RunScript As Boolean = True
        ''' <summary>
        ''' The _ database utility
        ''' </summary>
        Private Shared _DBUtility As Boolean = True
       
        ''' <summary>
        ''' Gets or sets a value indicating whether [initialize bd].
        ''' </summary>
        ''' <value><c>true</c> if [initialize bd]; otherwise, <c>false</c>.</value>
        Public Shared Property InitializeBD() As Boolean
            Get
                Return _InitializeBD
            End Get
            Set(ByVal value As Boolean)
                _InitializeBD = value
            End Set
        End Property
        ''' <summary>
        ''' Gets or sets a value indicating whether [database connection].
        ''' </summary>
        ''' <value><c>true</c> if [database connection]; otherwise, <c>false</c>.</value>
        Public Shared Property DBConnection() As Boolean
            Get
                Return _DBConnection
            End Get
            Set(ByVal value As Boolean)
                _DBConnection = value
            End Set
        End Property
        ''' <summary>
        ''' Gets or sets a value indicating whether [database utility tools].
        ''' </summary>
        ''' <value><c>true</c> if [database utility tools]; otherwise, <c>false</c>.</value>
        Public Shared Property DBUtilityTools() As Boolean
            Get
                Return _DBUtilityTools
            End Get
            Set(ByVal value As Boolean)
                _DBUtilityTools = value
            End Set
        End Property
        ''' <summary>
        ''' Gets or sets a value indicating whether [back up database].
        ''' </summary>
        ''' <value><c>true</c> if [back up database]; otherwise, <c>false</c>.</value>
        Public Shared Property BackUpDB() As Boolean
            Get
                Return _BackUpDB
            End Get
            Set(ByVal value As Boolean)
                _BackUpDB = value
            End Set
        End Property
        ''' <summary>
        ''' Gets or sets a value indicating whether [restore database].
        ''' </summary>
        ''' <value><c>true</c> if [restore database]; otherwise, <c>false</c>.</value>
        Public Shared Property RestoreDB() As Boolean
            Get
                Return _RestoreDB
            End Get
            Set(ByVal value As Boolean)
                _RestoreDB = value
            End Set
        End Property
        ''' <summary>
        ''' Gets or sets a value indicating whether [run script].
        ''' </summary>
        ''' <value><c>true</c> if [run script]; otherwise, <c>false</c>.</value>
        Public Shared Property RunScript() As Boolean
            Get
                Return _RunScript
            End Get
            Set(ByVal value As Boolean)
                _RunScript = value
            End Set
        End Property
        ''' <summary>
        ''' Gets or sets a value indicating whether [database utility].
        ''' </summary>
        ''' <value><c>true</c> if [database utility]; otherwise, <c>false</c>.</value>
        Public Shared Property DBUtility() As Boolean
            Get
                Return _DBUtility
            End Get
            Set(ByVal value As Boolean)
                _DBUtility = value
            End Set
        End Property
    End Class

End Namespace
