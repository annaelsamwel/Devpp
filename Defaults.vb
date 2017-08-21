' ***********************************************************************
' Assembly         : Dev++
' Author           : Annael Samwel
' Created          : 08-18-2014
'
' Last Modified By : user
' Last Modified On : 09-08-2011
' ***********************************************************************
' <copyright file="Defaults.vb" company="Annael">
'     Copyright © Annael 2010
' </copyright>
' <summary></summary>
' ***********************************************************************
''' <summary>
''' The Common namespace.
''' </summary>
Namespace Common
    ''' <summary>
    ''' Used to created Default of the company
    ''' This object created by Annael Samwel (Tanzanian))
    ''' </summary>
    ''' <remarks></remarks>
    ''' <summary>
    ''' Class Defaults. This class cannot be inherited.
    ''' </summary>
    Public NotInheritable Class Defaults
        ''' <summary>
        ''' Initializes a new instance of the <see cref="Defaults"/> class.
        ''' </summary>
        Public Sub New()
            
            Try
                readDefault()
            Catch ex As Exception
            End Try
        End Sub
#Region "Constats fields"
        ''' <summary>
        ''' The SQLTBL devpp defaults
        ''' </summary>
        Private Const sqltblDevppDefaults As String = "SELECT [DefaultID],[DefaultName] ,[DefInt] ,[DefBit] ,[DefFloat] ,[DefDate] ,[DefNvarchar] " & _
                                                ",[DefImageID]  FROM [tblDevppDefaults]"
#End Region
#Region "Fields"
        ''' <summary>
        ''' The table devpp defaults
        ''' </summary>
        Private Shared tblDevppDefaults As DataTable
        ''' <summary>
        ''' The bs default
        ''' </summary>
        Private Shared bsDefault As System.Windows.Forms.BindingSource
        ''' <summary>
        ''' The _ default exists
        ''' </summary>
        Private _DefaultExists As Boolean
#End Region
#Region "Property"
        ''' <summary>
        ''' Gets a value indicating whether [default exists].
        ''' </summary>
        ''' <value><c>true</c> if [default exists]; otherwise, <c>false</c>.</value>
        Public ReadOnly Property DefaultExists() As Boolean
            Get
                Return _DefaultExists
            End Get
        End Property
#End Region
#Region "Methods"
        ''' <summary>
        ''' Reads the default.
        ''' </summary>
        Private Sub readDefault()
            tblDevppDefaults = New DataTable
            bsDefault = New System.Windows.Forms.BindingSource
            Dim con As New SqlClient.SqlConnection(Devpp.Data.SQLSERVER.ConnectionString)
            Dim dapt As New SqlClient.SqlDataAdapter(sqltblDevppDefaults, con)
            dapt.Fill(tblDevppDefaults)
            bsDefault.DataSource = tblDevppDefaults
        End Sub
        ''' <summary>
        ''' Returns string after passing the string parameter
        ''' </summary>
        ''' <param name="strValue">The string value.</param>
        ''' <param name="DefaultID">The default identifier.</param>
        ''' <returns>System.String.</returns>
        Public Function GetDefault(ByVal strValue As String, ByVal DefaultID As Integer) As String
            For Each dr As DataRow In tblDevppDefaults.Rows
                If dr(0) = DefaultID Then
                    _DefaultExists = True
                    Return IIf(dr("DefNvarchar") Is DBNull.Value, "", dr("DefNvarchar"))
                End If
            Next
            _DefaultExists = False
            Return strValue
        End Function
        ''' <summary>
        ''' Returns string
        ''' </summary>
        ''' <param name="strValue">Returns the value if value not exists</param>
        ''' <param name="DefaultName">Name of default</param>
        ''' <returns>System.String.</returns>
        Public Function GetDefault(ByVal strValue As String, ByVal DefaultName As String) As String
            For Each dr As DataRow In tblDevppDefaults.Rows
                If dr("DefaultName") = DefaultName Then
                    _DefaultExists = True
                    Return IIf(dr("DefNvarchar") Is DBNull.Value, "", dr("DefNvarchar"))
                End If
            Next
            _DefaultExists = False
            Return strValue
        End Function
        ''' <summary>
        ''' Returns true or false after passing boolean
        ''' </summary>
        ''' <param name="blValue">if set to <c>true</c> [bl value].</param>
        ''' <param name="DefaultID">The default identifier.</param>
        ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        Public Function GetDefault(ByVal blValue As Boolean, ByVal DefaultID As Integer) As Boolean
            For Each dr As DataRow In tblDevppDefaults.Rows
                If dr(0) = DefaultID Then
                    _DefaultExists = True
                    Return IIf(dr("DefBit") Is DBNull.Value, 0, dr("DefBit"))
                End If
            Next
            _DefaultExists = False
            Return blValue
        End Function
        ''' <summary>
        ''' Returns boolean value
        ''' </summary>
        ''' <param name="blValue">Returns the value if value not exists</param>
        ''' <param name="DefaultName">Name of default</param>
        ''' <returns>Boolean</returns>
        Public Function GetDefault(ByVal blValue As Boolean, ByVal DefaultName As String) As Boolean
            For Each dr As DataRow In tblDevppDefaults.Rows
                If dr("DefaultName") = DefaultName Then
                    _DefaultExists = True
                    Return IIf(dr("DefBit") Is DBNull.Value, 0, dr("DefBit"))
                End If
            Next
            _DefaultExists = False
            Return blValue
        End Function
        ''' <summary>
        ''' Returns Integer after passing inte
        ''' </summary>
        ''' <param name="intValue">The int value.</param>
        ''' <param name="DefaultID">The default identifier.</param>
        ''' <returns>System.Int32.</returns>
        Public Function GetDefault(ByVal intValue As Integer, ByVal DefaultID As Integer) As Integer
            For Each dr As DataRow In tblDevppDefaults.Rows
                If dr(0) = DefaultID Then
                    _DefaultExists = True
                    Return IIf(dr("DefInt") Is DBNull.Value, Nothing, dr("DefInt"))
                End If
            Next
            _DefaultExists = False
            Return intValue
        End Function
        ''' <summary>
        ''' Return integer value
        ''' </summary>
        ''' <param name="intValue">Returns the value if value not exists</param>
        ''' <param name="DefaultName">Name of default</param>
        ''' <returns>Integer value</returns>
        Public Function GetDefault(ByVal intValue As Integer, ByVal DefaultName As String) As Integer
            For Each dr As DataRow In tblDevppDefaults.Rows
                If dr("DefaultName") = DefaultName Then
                    _DefaultExists = True
                    Return IIf(dr("DefInt") Is DBNull.Value, Nothing, dr("DefInt"))
                End If
            Next
            _DefaultExists = False
            Return intValue
        End Function
        ''' <summary>
        ''' Return double value
        ''' </summary>
        ''' <param name="BoubleValue">Returns the value if value not exists</param>
        ''' <param name="DefaultID">ID of default</param>
        ''' <returns>Double Value</returns>
        Public Function GetDefault(ByVal BoubleValue As Double, ByVal DefaultID As Integer) As Double
            For Each dr As DataRow In tblDevppDefaults.Rows
                If dr(0) = DefaultID Then
                    _DefaultExists = True
                    Return IIf(dr("DefFloat") Is DBNull.Value, Nothing, dr("DefFloat"))
                End If
            Next
            _DefaultExists = False
            Return BoubleValue
        End Function
        ''' <summary>
        ''' Returns double value
        ''' </summary>
        ''' <param name="BoubleValue">Returns the value if value not exists</param>
        ''' <param name="DefaultName">Name of default</param>
        ''' <returns>Double value</returns>
        Public Function GetDefault(ByVal BoubleValue As Double, ByVal DefaultName As String) As Double
            For Each dr As DataRow In tblDevppDefaults.Rows
                If dr("DefaultName") = DefaultName Then
                    _DefaultExists = True
                    Return IIf(dr("DefFloat") Is DBNull.Value, Nothing, dr("DefFloat"))
                End If
            Next
            _DefaultExists = False
            Return BoubleValue
        End Function
        ''' <summary>
        ''' Return date value
        ''' </summary>
        ''' <param name="DateValue">Returns the value if value not exists</param>
        ''' <param name="DefaultID">ID of default</param>
        ''' <returns>Date Value</returns>
        Public Function GetDefault(ByVal DateValue As Date, ByVal DefaultID As Integer) As Date
            For Each dr As DataRow In tblDevppDefaults.Rows
                If dr(0) = DefaultID Then
                    _DefaultExists = True
                    Return IIf(dr("DefDate") Is DBNull.Value, Nothing, dr("DefDate"))
                End If
            Next
            _DefaultExists = False
            Return DateValue
        End Function
        ''' <summary>
        ''' Return date value
        ''' </summary>
        ''' <param name="DateValue">Returns the value if value not exists</param>
        ''' <param name="DefaultName">Name of default</param>
        ''' <returns>Date value</returns>
        Public Function GetDefault(ByVal DateValue As Date, ByVal DefaultName As String) As Date
            For Each dr As DataRow In tblDevppDefaults.Rows
                If dr("DefaultName") = DefaultName Then
                    _DefaultExists = True
                    Return IIf(dr("DefDate") Is DBNull.Value, Nothing, dr("DefDate"))
                End If
            Next
            _DefaultExists = False
            Return DateValue
        End Function
        ''' <summary>
        ''' Returns Byte array
        ''' </summary>
        ''' <param name="ImageValue">Returns the value if value not exists</param>
        ''' <param name="DefaultID">ID of default</param>
        ''' <returns>Byte array</returns>
        Public Function GetDefault(ByVal ImageValue As Byte(), ByVal DefaultID As Integer) As Byte()
            Try
                Dim intImage As Integer = 0
                Dim imageID As Integer = GetDefault(intImage, DefaultID)
                Dim img As New Imaging
                Return img.GetBytes(imageID)
            Catch ex As Exception
                Return ImageValue
            End Try


        End Function
        ''' <summary>
        ''' Return Byte array
        ''' </summary>
        ''' <param name="ImageValue">Returns the value if value not exists</param>
        ''' <param name="DefaultName">Name of default</param>
        ''' <returns>Byte array</returns>
        Public Function GetDefault(ByVal ImageValue As Byte(), ByVal DefaultName As String) As Byte()
            Try
                Dim intImage As Integer = 0
                Dim imageID As Integer = GetDefault(intImage, DefaultName)
                Dim img As New Imaging
                Return img.GetBytes(imageID)
            Catch ex As Exception
                Return ImageValue
            End Try


        End Function
        ''' <summary>
        ''' Sets the default.
        ''' </summary>
        ''' <param name="strValue">The string value.</param>
        ''' <param name="DefaultID">The default identifier.</param>
        ''' <param name="DefaultName">The default name.</param>
        ''' <exception cref="Exception">
        ''' Default name cannot be empty
        ''' or
        ''' Default name [ & DefaultName & ] already used
        ''' or
        ''' or
        ''' </exception>
        Public Sub SetDefault(ByVal strValue As String, ByVal DefaultID As Integer, ByVal DefaultName As String)

            readDefault()
            Dim v_bl As Boolean = False
            If tblDevppDefaults.Rows.Count > 0 Then
                For Each dr As DataRow In tblDevppDefaults.Rows
                    If dr(0) = DefaultID Then
                        v_bl = True
                    End If
                Next
            End If
            If v_bl = False Then
                If DefaultName = "" Then
                    Throw New Exception("Default name cannot be empty")
                End If
                bsDefault.Filter = "DefaultName = '" & DefaultName & "'"
                If bsDefault.Count > 0 Then
                    Throw New Exception("Default name [" & DefaultName & "] already used")
                End If
                bsDefault.Filter = ""
                Dim strInsert As String = "INSERT INTO [tblDevppDefaults](DefNvarchar, DefaultID,DefaultName) VALUES(@DefNvarchar ,@DefaultID,@DefaultName)"
                Dim sqlcon As New SqlClient.SqlConnection(Data.SQLSERVER.ConnectionString)
                Dim sqlCom As New SqlClient.SqlCommand(strInsert, sqlcon)
                sqlCom.Parameters.Add("@DefNvarchar", SqlDbType.NVarChar)
                sqlCom.Parameters.Add("@DefaultID", SqlDbType.Int)
                sqlCom.Parameters.Add("@DefaultName", SqlDbType.NVarChar).Value = DefaultName
                sqlCom.Parameters("@DefNvarchar").Value = strValue
                sqlCom.Parameters("@DefaultID").Value = DefaultID
                Try
                    sqlcon.Open()
                    sqlCom.ExecuteNonQuery()
                    sqlcon.Close()
                Catch ex As Exception
                    sqlcon.Close()
                    Throw New Exception(ex.Message)
                End Try
            Else
                Dim strInsert As String = "UPDATE [tblDevppDefaults] SET DefNvarchar = @DefNvarchar WHERE DefaultID = @DefaultID "
                Dim sqlcon As New SqlClient.SqlConnection(Data.SQLSERVER.ConnectionString)
                Dim sqlCom As New SqlClient.SqlCommand(strInsert, sqlcon)
                sqlCom.Parameters.Add("@DefNvarchar", SqlDbType.NVarChar)
                sqlCom.Parameters.Add("@DefaultID", SqlDbType.Int)
                sqlCom.Parameters("@DefNvarchar").Value = strValue
                sqlCom.Parameters("@DefaultID").Value = DefaultID
                Try
                    sqlcon.Open()
                    sqlCom.ExecuteNonQuery()
                    sqlcon.Close()
                Catch ex As Exception
                    sqlcon.Close()
                    Throw New Exception(ex.Message)
                End Try
            End If
            readDefault()
        End Sub
        ''' <summary>
        ''' Sets the default.
        ''' </summary>
        ''' <param name="intValue">The int value.</param>
        ''' <param name="DefaultID">The default identifier.</param>
        ''' <param name="DefaultName">The default name.</param>
        ''' <exception cref="Exception">
        ''' Default name cannot be empty
        ''' or
        ''' Default name [ & DefaultName & ] already used
        ''' or
        ''' or
        ''' </exception>
        Public Sub SetDefault(ByVal intValue As Integer, ByVal DefaultID As Integer, ByVal DefaultName As String)

            readDefault()
            Dim v_bl As Boolean = False
            If tblDevppDefaults.Rows.Count > 0 Then
                For Each dr As DataRow In tblDevppDefaults.Rows
                    If dr(0) = DefaultID Then
                        v_bl = True
                        Exit For
                    End If
                Next
            End If
            If v_bl = False Then
                If DefaultName = "" Then
                    Throw New Exception("Default name cannot be empty")
                End If
                bsDefault.Filter = "DefaultName = '" & DefaultName & "'"
                If bsDefault.Count > 0 Then
                    Throw New Exception("Default name [" & DefaultName & "] already used")
                End If
                bsDefault.Filter = ""
                Dim strInsert As String = "INSERT INTO [tblDevppDefaults](DefInt, DefaultID,DefaultName) VALUES(@DefInt ,@DefaultID ,@DefaultName)"
                Dim sqlcon As New SqlClient.SqlConnection(Data.SQLSERVER.ConnectionString)
                Dim sqlCom As New SqlClient.SqlCommand(strInsert, sqlcon)
                sqlCom.Parameters.Add("@DefInt", SqlDbType.Int)
                sqlCom.Parameters.Add("@DefaultID", SqlDbType.Int)
                sqlCom.Parameters.Add("@DefaultName", SqlDbType.NVarChar).Value = DefaultName
                sqlCom.Parameters("@DefInt").Value = intValue
                sqlCom.Parameters("@DefaultID").Value = DefaultID
                Try
                    sqlcon.Open()
                    sqlCom.ExecuteNonQuery()
                    sqlcon.Close()
                Catch ex As Exception
                    sqlcon.Close()
                    Throw New Exception(ex.Message)
                End Try
            Else
                Dim strInsert As String = "UPDATE [tblDevppDefaults] SET DefInt = @DefInt WHERE DefaultID = @DefaultID"
                Dim sqlcon As New SqlClient.SqlConnection(Data.SQLSERVER.ConnectionString)
                Dim sqlCom As New SqlClient.SqlCommand(strInsert, sqlcon)
                sqlCom.Parameters.Add("@DefInt", SqlDbType.Int)
                sqlCom.Parameters.Add("@DefaultID", SqlDbType.Int)
                sqlCom.Parameters("@DefInt").Value = intValue
                sqlCom.Parameters("@DefaultID").Value = DefaultID
                Try
                    sqlcon.Open()
                    sqlCom.ExecuteNonQuery()
                    sqlcon.Close()
                Catch ex As Exception
                    sqlcon.Close()
                    Throw New Exception(ex.Message)
                End Try
            End If
            readDefault()
        End Sub
        ''' <summary>
        ''' Sets the default.
        ''' </summary>
        ''' <param name="doubleValue">The double value.</param>
        ''' <param name="DefaultID">The default identifier.</param>
        ''' <param name="DefaultName">The default name.</param>
        ''' <exception cref="Exception">
        ''' Default name cannot be empty
        ''' or
        ''' Default name [ & DefaultName & ] already used
        ''' or
        ''' or
        ''' </exception>
        Public Sub SetDefault(ByVal doubleValue As Double, ByVal DefaultID As Integer, ByVal DefaultName As String)
            readDefault()
            Dim v_bl As Boolean = False
            If tblDevppDefaults.Rows.Count > 0 Then
                For Each dr As DataRow In tblDevppDefaults.Rows
                    If dr(0) = DefaultID Then
                        v_bl = True
                    End If
                Next
            End If
            If v_bl = False Then
                If DefaultName = "" Then
                    Throw New Exception("Default name cannot be empty")
                End If
                bsDefault.Filter = "DefaultName = '" & DefaultName & "'"
                If bsDefault.Count > 0 Then
                    Throw New Exception("Default name [" & DefaultName & "] already used")
                End If
                bsDefault.Filter = ""
                Dim strInsert As String = "INSERT INTO [tblDevppDefaults](DefFloat, DefaultID,DefaultName) VALUES(@DefFloat ,@DefaultID,@DefaultName)"
                Dim sqlcon As New SqlClient.SqlConnection(Data.SQLSERVER.ConnectionString)
                Dim sqlCom As New SqlClient.SqlCommand(strInsert, sqlcon)
                sqlCom.Parameters.Add("@DefFloat", SqlDbType.Float)
                sqlCom.Parameters.Add("@DefaultID", SqlDbType.Int)
                sqlCom.Parameters.Add("@DefaultName", SqlDbType.NVarChar).Value = DefaultName
                sqlCom.Parameters("@DefFloat").Value = doubleValue
                sqlCom.Parameters("@DefaultID").Value = DefaultID
                Try
                    sqlcon.Open()
                    sqlCom.ExecuteNonQuery()
                    sqlcon.Close()
                Catch ex As Exception
                    sqlcon.Close()
                    Throw New Exception(ex.Message)
                End Try
            Else
                Dim strInsert As String = "UPDATE [tblDevppDefaults] SET DefFloat = @DefFloat WHERE DefaultID = @DefaultID"
                Dim sqlcon As New SqlClient.SqlConnection(Data.SQLSERVER.ConnectionString)
                Dim sqlCom As New SqlClient.SqlCommand(strInsert, sqlcon)
                sqlCom.Parameters.Add("@DefFloat", SqlDbType.Float)
                sqlCom.Parameters.Add("@DefaultID", SqlDbType.Int)
                sqlCom.Parameters("@DefFloat").Value = doubleValue
                sqlCom.Parameters("@DefaultID").Value = DefaultID
                Try
                    sqlcon.Open()
                    sqlCom.ExecuteNonQuery()
                    sqlcon.Close()
                Catch ex As Exception
                    sqlcon.Close()
                    Throw New Exception(ex.Message)
                End Try
            End If
            readDefault()
        End Sub
        ''' <summary>
        ''' Sets the default.
        ''' </summary>
        ''' <param name="blValue">if set to <c>true</c> [bl value].</param>
        ''' <param name="DefaultID">The default identifier.</param>
        ''' <param name="DefaultName">The default name.</param>
        ''' <exception cref="Exception">
        ''' Default name cannot be empty
        ''' or
        ''' Default name [ & DefaultName & ] already used
        ''' or
        ''' or
        ''' </exception>
        Public Sub SetDefault(ByVal blValue As Boolean, ByVal DefaultID As Integer, ByVal DefaultName As String)
            readDefault()
            Dim v_bl As Boolean = False
            If tblDevppDefaults.Rows.Count > 0 Then
                For Each dr As DataRow In tblDevppDefaults.Rows
                    If dr(0) = DefaultID Then
                        v_bl = True
                    End If
                Next
            End If
            If v_bl = False Then
                If DefaultName = "" Then
                    Throw New Exception("Default name cannot be empty")
                End If
                bsDefault.Filter = "DefaultName = '" & DefaultName & "'"
                If bsDefault.Count > 0 Then
                    Throw New Exception("Default name [" & DefaultName & "] already used")
                End If
                bsDefault.Filter = ""
                Dim strInsert As String = "INSERT INTO [tblDevppDefaults](DefBit, DefaultID,DefaultName) VALUES(@DefBit ,@DefaultID,@DefaultName)"
                Dim sqlcon As New SqlClient.SqlConnection(Data.SQLSERVER.ConnectionString)
                Dim sqlCom As New SqlClient.SqlCommand(strInsert, sqlcon)
                sqlCom.Parameters.Add("@DefBit", SqlDbType.Bit)
                sqlCom.Parameters.Add("@DefaultID", SqlDbType.Int)
                sqlCom.Parameters.Add("@DefaultName", SqlDbType.NVarChar).Value = DefaultName
                sqlCom.Parameters("@DefBit").Value = blValue
                sqlCom.Parameters("@DefaultID").Value = DefaultID
                Try
                    sqlcon.Open()
                    sqlCom.ExecuteNonQuery()
                    sqlcon.Close()
                Catch ex As Exception
                    sqlcon.Close()
                    Throw New Exception(ex.Message)
                End Try
            Else
                Dim strInsert As String = "UPDATE [tblDevppDefaults] SET DefBit = @DefBit WHERE DefaultID = @DefaultID"
                Dim sqlcon As New SqlClient.SqlConnection(Data.SQLSERVER.ConnectionString)
                Dim sqlCom As New SqlClient.SqlCommand(strInsert, sqlcon)
                sqlCom.Parameters.Add("@DefBit", SqlDbType.Bit)
                sqlCom.Parameters.Add("@DefaultID", SqlDbType.Int)

                sqlCom.Parameters("@DefBit").Value = blValue
                sqlCom.Parameters("@DefaultID").Value = DefaultID
                Try
                    sqlcon.Open()
                    sqlCom.ExecuteNonQuery()
                    sqlcon.Close()
                Catch ex As Exception
                    sqlcon.Close()
                    Throw New Exception(ex.Message)
                End Try
            End If
            readDefault()
        End Sub
        ''' <summary>
        ''' Sets the default.
        ''' </summary>
        ''' <param name="DateValue">The date value.</param>
        ''' <param name="DefaultID">The default identifier.</param>
        ''' <param name="DefaultName">The default name.</param>
        ''' <exception cref="Exception">
        ''' Default name cannot be empty
        ''' or
        ''' Default name [ & DefaultName & ] already used
        ''' or
        ''' or
        ''' </exception>
        Public Sub SetDefault(ByVal DateValue As Date, ByVal DefaultID As Integer, ByVal DefaultName As String)
            readDefault()
            Dim v_bl As Boolean = False
            If tblDevppDefaults.Rows.Count > 0 Then
                For Each dr As DataRow In tblDevppDefaults.Rows
                    If dr(0) = DefaultID Then
                        v_bl = True
                    End If
                Next
            End If
            If v_bl = False Then
                If DefaultName = "" Then
                    Throw New Exception("Default name cannot be empty")
                End If
                bsDefault.Filter = "DefaultName = '" & DefaultName & "'"
                If bsDefault.Count > 0 Then
                    Throw New Exception("Default name [" & DefaultName & "] already used")
                End If
                bsDefault.Filter = ""
                Dim strInsert As String = "INSERT INTO [tblDevppDefaults](DefDate, DefaultID,DefaultName) VALUES(@DefDate ,@DefaultID,@DefaultName)"
                Dim sqlcon As New SqlClient.SqlConnection(Data.SQLSERVER.ConnectionString)
                Dim sqlCom As New SqlClient.SqlCommand(strInsert, sqlcon)
                sqlCom.Parameters.Add("@DefDate", SqlDbType.DateTime)
                sqlCom.Parameters.Add("@DefaultID", SqlDbType.Int)
                sqlCom.Parameters.Add("@DefaultName", SqlDbType.NVarChar).Value = DefaultName
                sqlCom.Parameters("@DefDate").Value = DateValue
                sqlCom.Parameters("@DefaultID").Value = DefaultID
                Try
                    sqlcon.Open()
                    sqlCom.ExecuteNonQuery()
                    sqlcon.Close()
                Catch ex As Exception
                    sqlcon.Close()
                    Throw New Exception(ex.Message)
                End Try
            Else
                Dim strInsert As String = "UPDATE [tblDevppDefaults] SET DefDate = @DefDate WHERE DefaultID = @DefaultID"
                Dim sqlcon As New SqlClient.SqlConnection(Data.SQLSERVER.ConnectionString)
                Dim sqlCom As New SqlClient.SqlCommand(strInsert, sqlcon)
                sqlCom.Parameters.Add("@DefDate", SqlDbType.DateTime)
                sqlCom.Parameters.Add("@DefaultID", SqlDbType.Int)
                sqlCom.Parameters("@DefDate").Value = DateValue
                sqlCom.Parameters("@DefaultID").Value = DefaultID
                Try
                    sqlcon.Open()
                    sqlCom.ExecuteNonQuery()
                    sqlcon.Close()
                Catch ex As Exception
                    sqlcon.Close()
                    Throw New Exception(ex.Message)
                End Try
            End If
            readDefault()
        End Sub
#End Region
    End Class
End Namespace
