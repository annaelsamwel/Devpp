' ***********************************************************************
' Assembly         : Dev++
' Author           : Annael Samwel
' Created          : 08-18-2014
'
' Last Modified By : user
' Last Modified On : 10-17-2011
' ***********************************************************************
' <copyright file="PopupSearch.vb" company="Annael">
'     Copyright © Annael 2010
' </copyright>
' <summary></summary>
' ***********************************************************************
Imports Devpp.Common
Imports Devpp.Forms
''' <summary>
''' The Common namespace.
''' </summary>
Namespace Common
    ''' <summary>
    ''' Used to Manage Searching
    ''' Created by Annael Samwel (Tanzania)
    ''' </summary>
    Public NotInheritable Class PopupSearch
        ''' <summary>
        ''' The _ search sp name
        ''' </summary>
        Private _SearchSpName As String
        ''' <summary>
        ''' The FRM popupsearch1
        ''' </summary>
        Private frmPopupsearch1 As frmPopupSearch
        ''' <summary>
        ''' The bs memory
        ''' </summary>
        Private bsMemory As New System.Windows.Forms.BindingSource
        ''' <summary>
        ''' The DTBL
        ''' </summary>
        Private dtbl As New DataTable
        ''' <summary>
        ''' The _ border sytle
        ''' </summary>
        Private _BorderSytle As Windows.Forms.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
        ''' <summary>
        ''' The _ list of identifier
        ''' </summary>
        Private _ListOfID As New List(Of Object)
        ''' <summary>
        ''' The _ identifier column
        ''' </summary>
        Private _IDColumn As String
        ''' <summary>
        ''' The _ string type
        ''' </summary>
        Private _StrType As Boolean = True
        ''' <summary>
        ''' Sets the column value.
        ''' </summary>
        ''' <param name="dtTable">The dt table.</param>
        ''' <param name="ValueColumn">The value column.</param>
        Public Sub SetColumnValue(ByVal dtTable As DataTable, ByVal ValueColumn As String)
            frmPopupsearch1.SetColumnValue(dtTable, ValueColumn, _IDColumn)
        End Sub
        ''' <summary>
        ''' Adds the column.
        ''' </summary>
        ''' <param name="Column">The column.</param>
        ''' <param name="canFilter">if set to <c>true</c> [can filter].</param>
        ''' <param name="canEdit">if set to <c>true</c> [can edit].</param>
        Public Sub AddColumn(ByVal Column As DataColumn, Optional ByVal canFilter As Boolean = False, Optional ByVal canEdit As Boolean = True)
            frmPopupsearch1.AddColumn(Column, canFilter, canEdit)
        End Sub
        ''' <summary>
        ''' Gets or sets the list of identifier.
        ''' </summary>
        ''' <value>The list of identifier.</value>
        Public Property ListOfID() As List(Of Object)
            Get
                Return _ListOfID
            End Get
            Set(ByVal value As List(Of Object))
                _ListOfID = value
            End Set
        End Property
        ''' <summary>
        ''' Gets or sets the identifier column.
        ''' </summary>
        ''' <value>The identifier column.</value>
        Public Property IDColumn() As String
            Get
                Return _IDColumn
            End Get
            Set(ByVal value As String)

                _IDColumn = value
            End Set
        End Property
        ''' <summary>
        ''' Initializes a new instance of the <see cref="PopupSearch"/> class.
        ''' </summary>
        ''' <exception cref="Exception">Exact DLL not registered</exception>
        Public Sub New()
            If Not DLLRegistered Then
                Throw New Exception("Exact DLL not registered")
            End If
            frmPopupsearch1 = New frmPopupSearch
            bsMemory = frmPopupsearch1.BinSearch
        End Sub
        ''' <summary>
        ''' Keys down.
        ''' </summary>
        ''' <param name="sender">The sender.</param>
        ''' <param name="e">The <see cref="System.Windows.Forms.KeyEventArgs"/> instance containing the event data.</param>
        Public Sub KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
            frmPopupsearch1.LoadValue(sender, e)
        End Sub
        ''' <summary>
        ''' Shows the popup search.
        ''' </summary>
        Public Sub ShowPopupSearch()
            Try
                frmPopupsearch1.FormBorderStyle = _BorderSytle
                frmPopupsearch1.ShowDialog()
            Catch ex As Exception

            End Try
        End Sub
        ''' <summary>
        ''' Shows the popup search.
        ''' </summary>
        ''' <param name="startLocation">The start location.</param>
        Public Sub ShowPopupSearch(ByVal startLocation As System.Windows.Forms.FormStartPosition)
            Try
                frmPopupsearch1.FormBorderStyle = _BorderSytle
                frmPopupsearch1.StartPosition = startLocation
                frmPopupsearch1.ShowDialog()
            Catch ex As Exception

            End Try
        End Sub
        ''' <summary>
        ''' Sets a value indicating whether [show CheckBox].
        ''' </summary>
        ''' <value><c>true</c> if [show CheckBox]; otherwise, <c>false</c>.</value>
        Public WriteOnly Property ShowCheckBox() As Boolean
            Set(ByVal value As Boolean)
                frmPopupsearch1.ShowChkBox = value
            End Set
        End Property
        ''' <summary>
        ''' Shows the popup search.
        ''' </summary>
        ''' <param name="StartLOcation">The start l ocation.</param>
        Public Sub ShowPopupSearch(ByVal StartLOcation As Drawing.Point)
            Try
                frmPopupsearch1.StartPosition = Windows.Forms.FormStartPosition.Manual
                frmPopupsearch1.FormBorderStyle = _BorderSytle
                frmPopupsearch1.Location = StartLOcation
                frmPopupsearch1.ShowDialog()
            Catch ex As Exception

            End Try
        End Sub
        ''' <summary>
        ''' Sets the border style.
        ''' </summary>
        ''' <value>The border style.</value>
        Public WriteOnly Property BorderStyle() As Windows.Forms.FormBorderStyle

            Set(ByVal value As Windows.Forms.FormBorderStyle)
                _BorderSytle = value
            End Set
        End Property

        ''' <summary>
        ''' Gets or sets the column header text.
        ''' </summary>
        ''' <value>The column header text.</value>
        ''' <exception cref="Exception">
        ''' </exception>
        Public Property ColumnHeaderText(ByVal columnName As String) As String
            Get
                Try
                    Return frmPopupsearch1.HeaderText(columnName)
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End Get
            Set(ByVal value As String)
                Try
                    frmPopupsearch1.HeaderText(columnName) = value

                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End Set
        End Property
        ''' <summary>
        ''' Gets or sets the column header text.
        ''' </summary>
        ''' <value>The column header text.</value>
        ''' <exception cref="Exception">
        ''' </exception>
        Public Property ColumnHeaderText(ByVal columnIndex As Integer) As String
            Get
                Try
                    Return frmPopupsearch1.HeaderText(columnIndex)
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try
            End Get
            Set(ByVal value As String)
                Try
                    frmPopupsearch1.HeaderText(columnIndex) = value
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try

            End Set
        End Property
        ''' <summary>
        ''' Sbs the type of the check.
        ''' </summary>
        ''' <param name="obj">The object.</param>
        Private Sub sbCheckType(ByVal obj As Object)
            If IsNumeric(obj) Or IsDate(obj) Then
                _StrType = False
            End If
        End Sub
        ''' <summary>
        ''' Gets or sets the filter columns.
        ''' </summary>
        ''' <value>The filter columns.</value>
        Public Property FilterColumns() As List(Of String)
            Get
                Return frmPopupsearch1.FilterColumns
            End Get
            Set(ByVal value As List(Of String))
                frmPopupsearch1.FilterColumns = value
            End Set
        End Property
        ''' <summary>
        ''' Sets the search data table.
        ''' </summary>
        ''' <value>The search data table.</value>
   Public WriteOnly Property SearchDataTable() As DataTable
 Set(ByVal value As DataTable)
   frmPopupsearch1.SearchDataTable = value
 dtbl = frmPopupsearch1.dtblSP
				bsMemory.DataSource = dtbl
				If frmPopupsearch1.ShowChkBox = True Then
					sbCheckType(dtbl.Columns(IDColumn).DataType)

					For Each obj As Object In ListOfID
						If _StrType = True Then
							Dim str As String = IDColumn & " ='" & obj & "'"
							bsMemory.Filter = str
						Else
							bsMemory.Filter = IDColumn & " =" & obj
						End If
						If bsMemory.Count > 0 Then
							Dim dr As DataRowView = bsMemory.Current
							dr.BeginEdit()
							dr("chkbox") = True
							dr.EndEdit()
							bsMemory.EndEdit()
						End If
					Next

					bsMemory.Filter = ""
					'bsMemory.Sort = "chkbox DESC"


				End If
 End Set
   End Property
        ''' <summary>
        ''' Sets the name of the search sp.
        ''' </summary>
        ''' <value>The name of the search sp.</value>
        Public WriteOnly Property SearchSpName(ByVal ParamArray spValues() As Object) As String
            Set(ByVal value As String)

                frmPopupsearch1.SearchSpName(spValues) = value
                dtbl = frmPopupsearch1.dtblSP
                bsMemory.DataSource = dtbl

                If frmPopupsearch1.ShowChkBox = True Then
                    sbCheckType(dtbl.Columns(IDColumn).DataType)

                    For Each obj As Object In ListOfID
                        If _StrType = True Then
                            Dim str As String = IDColumn & " ='" & obj & "'"
                            bsMemory.Filter = str
                        Else
                            bsMemory.Filter = IDColumn & " =" & obj
                        End If
                        If bsMemory.Count > 0 Then
                            Dim dr As DataRowView = bsMemory.Current
                            dr.BeginEdit()
                            dr("chkbox") = True
                            dr.EndEdit()
                            bsMemory.EndEdit()
                        End If
                    Next

                    bsMemory.Filter = ""
                    'bsMemory.Sort = "chkbox DESC"


                End If

            End Set
        End Property
        ''' <summary>
        ''' Sets the width of the column.
        ''' </summary>
        ''' <value>The width of the column.</value>
        Public WriteOnly Property ColumnWidth(ByVal ColumnName As String) As Single

            Set(ByVal value As Single)
                frmPopupsearch1.ColumnWidth(ColumnName) = value
            End Set
        End Property
        ''' <summary>
        ''' Sets the width of the column.
        ''' </summary>
        ''' <value>The width of the column.</value>
        Public WriteOnly Property ColumnWidth(ByVal ColumnIndex As Integer) As Single
            Set(ByVal value As Single)
                frmPopupsearch1.ColumnWidth(ColumnIndex) = value
            End Set
        End Property
        ''' <summary>
        ''' Invisibles the column.
        ''' </summary>
        ''' <param name="ColumnName">Name of the column.</param>
        Public Sub InvisibleColumn(ByVal ColumnName As String)
            frmPopupsearch1.InvisibleColumn(ColumnName)
        End Sub
        ''' <summary>
        ''' Invisibles the column.
        ''' </summary>
        ''' <param name="ColumnIndex">Index of the column.</param>
        Public Sub InvisibleColumn(ByVal ColumnIndex As Integer)
            frmPopupsearch1.InvisibleColumn(ColumnIndex)
        End Sub
        ''' <summary>
        ''' Returns the value.
        ''' </summary>
        ''' <param name="index">The index.</param>
        ''' <returns>System.Object.</returns>
        Public Function ReturnValue(ByVal index As Integer) As Object
            Try
                Return frmPopupSearch.ReturnValue(index)
            Catch ex As Exception
                Return DBNull.Value
            End Try
        End Function
        ''' <summary>
        ''' Returns the value.
        ''' </summary>
        ''' <param name="columnName">Name of the column.</param>
        ''' <returns>System.Object.</returns>
        Public Function ReturnValue(ByVal columnName As String) As Object
            Try
                Return frmPopupSearch.ReturnValue(columnName)
            Catch ex As Exception
                Return DBNull.Value
            End Try
        End Function
        ''' <summary>
        ''' Gets the return data table.
        ''' </summary>
        ''' <value>The return data table.</value>
        Public ReadOnly Property ReturnDataTable() As DataTable
            Get
                Dim dtblMEM As New DataTable
                ListOfID.Clear()
                For Each cols As DataColumn In dtbl.Columns
                    dtblMEM.Columns.Add(cols.ColumnName, cols.DataType)
                Next
                For Each dr As DataRowView In bsMemory.List
                    If dr("chkbox") Is DBNull.Value Then
                    ElseIf dr("chkbox") = True Then

                        If IDColumn <> Nothing Then
                            ListOfID.Add(dr(IDColumn))
                        End If

                        Dim newrow As DataRow = dtblMEM.NewRow
                        For Each cols As DataColumn In dtblMEM.Columns
                            newrow(cols.ColumnName) = dr(cols.ColumnName)
                        Next

                        dtblMEM.Rows.Add(newrow)
                    End If
                Next
                Return dtblMEM
            End Get
        End Property

        ''' <summary>
        ''' Reads the only column.
        ''' </summary>
        ''' <param name="ColumnName">Name of the column.</param>
        ''' <param name="bool">if set to <c>true</c> [bool].</param>
        Public Sub ReadOnlyColumn(ByVal ColumnName As String, ByVal bool As Boolean)
            frmPopupsearch1.ReadOnlyColumn(ColumnName, bool)
        End Sub
        ''' <summary>
        ''' Reads the only column.
        ''' </summary>
        ''' <param name="ColumnIndex">Index of the column.</param>
        Public Sub ReadOnlyColumn(ByVal ColumnIndex As Integer)
            frmPopupsearch1.ReadOnlyColumn(ColumnIndex)
        End Sub
    End Class
End Namespace