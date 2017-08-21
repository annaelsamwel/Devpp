Imports System.Windows.Forms

Friend Class frmPopupSearch
    Private intMode As Integer
    Private strMemory As String = ""
    Private strSearch As String = ""
    Private _SearchSpName As String
    Private _invisibleColumn As Integer = Nothing
    Private _returnValue As String
    Private _spValues() As Object
    Private _intSourceColumns As New List(Of Integer)
    Private _strSourceColuns As New List(Of String)
    Friend WithEvents BinSearch As New BindingSource
    Private _FilterColumns As New List(Of String)
    Private Shared _canReturn As Boolean
    Private OKClicked As Boolean = False
    Private Shared _datarow As DataRowView
    Private _ShowChkBox As Boolean = False
    Friend WithEvents dtblSP As New DataTable
    Private ListNotFilter As New List(Of String)
    Private Editable As New List(Of Boolean)
    Private EditableColumns As New List(Of String)
    Friend Sub AddColumn(ByVal Column As DataColumn, Optional ByVal canFilter As Boolean = False, Optional ByVal canEdit As Boolean = True)
        dtblSP.Columns.Add(Column)
        If canEdit Then
            ListNotFilter.Add(Column.ColumnName)
        End If
        If canFilter = False Then
            ListNotFilter.Add(Column.ColumnName)

        End If
    End Sub
    Friend Property ShowChkBox() As Boolean
        Get
            Return _ShowChkBox
        End Get
        Set(ByVal value As Boolean)
            _ShowChkBox = value

        End Set
    End Property

    Public Property HeaderText(ByVal columnName As String) As String
        Get
            Try
                Return grvFound.Columns(columnName).HeaderText
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Get
        Set(ByVal value As String)
            grvFound.Columns(columnName).HeaderText = value
        End Set
    End Property
    Public Property HeaderText(ByVal columnIndex As Integer) As String
        Get
            Try
                Return grvFound.Columns(columnIndex).HeaderText
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Get
        Set(ByVal value As String)
            grvFound.Columns(columnIndex).HeaderText = value
        End Set
    End Property
    Public Property FilterColumns() As List(Of String)
        Get
            Return _FilterColumns
        End Get
        Set(ByVal value As List(Of String))
            _FilterColumns = value
        End Set
	End Property
Public WriteOnly Property SearchDataTable() As DataTable
 Set(ByVal value As DataTable)	

Try
dtblSP.Rows.Clear()
dtblSP.Columns.Clear()
dtblSP.Columns.Add("ChkBox", GetType(Boolean))
For Each cols As DataColumn In value.Columns
dtblSP.Columns.Add(cols.ColumnName, cols.DataType)
Next
For Each dr As DataRow In value.Rows
Dim newRow As DataRow = dtblSP.NewRow
  For Each col As DataColumn In value.Columns
newRow(col.ColumnName) = dr(col.ColumnName)
  Next
dtblSP.Rows.Add(newRow)
Next
BinSearch.DataSource = dtblSP
 Me.grvFound.DataSource = BinSearch
 grvFound.Columns("ChkBox").Visible = _ShowChkBox


 grvFound.Columns("ChkBox").ReadOnly = False
Catch ex As Exception
  Throw New Exception(ex.Message)
End Try
 End Set
End Property


	Public WriteOnly Property SearchSpName(ByVal ParamArray spValues() As Object) As String
		Set(ByVal value As String)
			Try
	 dtblSP.Rows.Clear()
dtblSP.Columns.Clear()
				Dim lstCols As New List(Of String)
				Dim lstType As New List(Of Type)

				lstCols.Add("ChkBox")
				lstType.Add(GetType(Boolean))
				dtblSP.Columns.Add("ChkBox", GetType(Boolean))
                dtblSP = Devpp.Data.SQLSERVER.GetSPDataTable(value, lstCols, lstType, False, spValues)

				BinSearch.DataSource = dtblSP
				Me.grvFound.DataSource = BinSearch
				grvFound.Columns("ChkBox").Visible = _ShowChkBox


				grvFound.Columns("ChkBox").ReadOnly = False
			Catch ex As Exception
				Throw New Exception(ex.Message)
			End Try
		End Set
	End Property
	Public WriteOnly Property ColumnWidth(ByVal ColumnName As String) As Single

		Set(ByVal value As Single)
			Try
				Me.grvFound.Columns(ColumnName).Width = value
			Catch ex As Exception
				Throw New Exception(ex.Message)
			End Try
		End Set
	End Property
	Public WriteOnly Property ColumnWidth(ByVal ColumnIndex As Integer) As Single

		Set(ByVal value As Single)
			Try
				Me.grvFound.Columns(ColumnIndex).Width = value
			Catch ex As Exception
				Throw New Exception(ex.Message)
			End Try
		End Set
	End Property
	Private Property Mode() As Integer
		Get
			Return intMode
		End Get
		Set(ByVal value As Integer)
			intMode = value
		End Set
	End Property
	Public Sub InvisibleColumn(ByVal ColumnName As String)
		Try
			Me.grvFound.Columns(ColumnName).Visible = False
		Catch ex As Exception
			Throw New Exception(ex.Message)
		End Try
	End Sub
	Public Sub InvisibleColumn(ByVal ColumnIndex As Integer)
		Try
			Me.grvFound.Columns(ColumnIndex).Visible = False
		Catch ex As Exception
			Throw New Exception(ex.Message)
		End Try
	End Sub

	Public Shared Function ReturnValue(ByVal index As Integer) As Object

		Try
			If _canReturn = True Then
				Return _datarow(index)

			Else
				Return DBNull.Value
			End If
		Catch ex As Exception
			Return DBNull.Value
		End Try

	End Function
	Public Shared Function ReturnValue(ByVal columnName As String) As Object
		Try
			If _canReturn = True Then
				Return _datarow(columnName)

			Else
				Return DBNull.Value
			End If
		Catch ex As Exception
			Return DBNull.Value
		End Try


	End Function
    Public Sub ReadOnlyColumn(ByVal ColumnName As String, ByVal value As Boolean)
        Try
            If value = False Then
                Me.ListNotFilter.Add(ColumnName)
            Else

                Me.grvFound.Columns(ColumnName).ReadOnly = True
            End If

        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
    Public Sub ReadOnlyColumn(ByVal ColumnIndex As Integer)
        Try
            Me.grvFound.Columns(ColumnIndex).ReadOnly = True
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Sub
	Public Sub LoadValue(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs)
		If e.KeyCode = Keys.Escape Then
			btnCancel_Click(sender, e)
		End If
		If e.KeyValue > 40 And e.KeyValue < 150 Or e.KeyValue = 32 Then
			grvFound_KeyDown(sender, e)
		Else
			btnCancel_Click(sender, e)
		End If


	End Sub
	Private Sub frmPopupSearch_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
		_canReturn = OKClicked
	End Sub
	Private Sub frmPopUpSearch_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
		If Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None Then
			Me.Panel1.Visible = True
		End If
		OKClicked = False

		grvFound.AllowUserToAddRows = False
		grvFound.AllowUserToDeleteRows = False

		sbRefreshGridView()
		grvFound.DataSource = BinSearch
		Dim intwidth As Integer = 0
		Dim x As Integer = Me.grvFound.Columns.Count
		For i = 0 To x - 1
			If grvFound.Columns(i).Visible = True Then
				intwidth += grvFound.Columns(i).Width
			End If
		Next
		If intwidth < 250 Then intwidth = 250
		Me.grvFound.RowHeadersWidth = 4
		Me.Width = intwidth + 35
		For Each col As DataGridViewColumn In grvFound.Columns
			If ListNotFilter.Contains(col.HeaderText) Then
				col.ReadOnly = False
			Else
				col.ReadOnly = True
			End If
		Next
		grvFound.Columns("ChkBox").Visible = _ShowChkBox
		Me.PanelCheckbox.Visible = _ShowChkBox
		Me.PanelOK.Visible = _ShowChkBox
        grvFound.ReadOnly = False
		grvFound.Columns("ChkBox").ReadOnly = False
		grvFound.Columns("ChkBox").HeaderText = "Check"
		grvFound.Columns("ChkBox").Width = 50
		grvFound.Columns("chkbox").DataPropertyName = "chkbox"
		chkSortByChecked.Checked = True
	End Sub

	Private Sub grvFound_CellContentClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grvFound.CellContentClick

        If _ShowChkBox = True Then
            If e.ColumnIndex = grvFound.CurrentRow.Cells("ChkBox").ColumnIndex Then
                If grvFound.Rows.Count = 0 Then Exit Sub

                If grvFound.CurrentRow.Cells("ChkBox").Value Is DBNull.Value Then
                    grvFound.CurrentRow.Cells("ChkBox").Value = True
                Else
                    If grvFound.CurrentRow.Cells("ChkBox").Value = True Then
                        grvFound.CurrentRow.Cells("ChkBox").Value = False
                    Else
                        grvFound.CurrentRow.Cells("ChkBox").Value = True
                    End If
                End If
                BinSearch.EndEdit()
            End If
        End If
	End Sub
	Private Sub grvFound_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grvFound.DoubleClick
		btnOK_Click(sender, e)
	End Sub
	Private Sub sbRefreshGridView()
		Try
			'Dim tbl As New DataTable()
			BinSearch.EndEdit()
			Dim strToFind As String = ""
			strToFind = strMemory
			Dim Filter As String = ""
			Dim int As Integer = 0
			For Each strFilter As String In _FilterColumns
				If int = 0 Then
					Filter = Filter & "[" & strFilter & "] LIKE '%" & strMemory & "%' "
				Else
					Filter = Filter + " OR [" & strFilter & "] LIKE '%" & strMemory & "%' "
				End If
				int += 1
			Next
			BinSearch.Filter = Filter
			BinSearch.EndEdit()
			' 
			'BinSearch.ResetCurrentItem()
		Catch ex As Exception
			Throw New Exception(ex.Message)
		End Try
	End Sub
	Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
		If _ShowChkBox = True Then
			BinSearch.Filter = ""
		End If
		_canReturn = True
		OKClicked = True
		_datarow = BinSearch.Current
		Me.Close()
	End Sub
	Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
		_canReturn = False
		OKClicked = False
		Me.Close()
	End Sub
	Private Sub grvFound_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grvFound.KeyDown

		If e.KeyCode = Keys.Escape Then
            btnCancel_Click(sender, e)
            Return
		End If
        If e.KeyCode = Keys.Enter Then
            If ShowChkBox = False Then
                btnOK_Click(sender, e)
                Return
            End If

        End If
		If e.KeyCode = Windows.Forms.Keys.Back Then
			Try
				If ListNotFilter.Contains(Me.grvFound.Columns(Me.grvFound.CurrentCell.ColumnIndex).HeaderText) Then
					Return
				End If
			Catch ex As Exception

			End Try

			If strMemory.Length > 0 Then
				strMemory = LSet(strMemory, strMemory.Length - 1)
			End If
		Else
			If e.KeyValue > 40 And e.KeyValue < 150 Or e.KeyValue = 32 Then

				strMemory += Chr(e.KeyValue)
			Else
				If e.KeyCode = Keys.Enter Then

					btnOK_Click(sender, e)
				End If
				Exit Sub
			End If
		End If
		Me.Text = "Searching for " & strMemory
		Me.lblSearch.Text = Me.Text
		sbRefreshGridView()
	End Sub
	Friend Sub SetColumnValue(ByVal dtTable As DataTable, ByVal Column As String, ByVal IDColumn As String)
		For Each dr As DataRow In dtTable.Rows
			For Each r As DataRow In dtblSP.Select(IDColumn & " = " & dr(IDColumn))
				r.BeginEdit()
				r(Column) = dr(Column)
				r("ChkBox") = 1
				r.EndEdit()
			Next

		Next
	End Sub
	Private Sub chkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAll.CheckedChanged
		Try
			'BinSearch.Sort = ""
			' Me.BinSearch.Filter = ""
			If Me.chkAll.Checked Then
				Me.chkAll.Text = "Uncheck all"

			Else
				Me.chkAll.Text = "Check all"
			End If
			'For Each dr In dtblSP.Rows
			'    dr.item("ChkBox") = chkAll.Checked
			'Next
   For Each dr As DataRowView In BinSearch.List
dr.BeginEdit()
   dr("ChkBox") = chkAll.Checked

  dr.EndEdit()

   Next
		Catch ex As Exception
			MsgBox(ex.Message)
		End Try

	End Sub

	Private Sub btnFilterChecked_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFilterChecked.Click
		'Me.BinSearch.Filter = "ChkBox = " & 1
		BinSearch.Sort = "chkbox DESC"

	End Sub

	Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
		Me.BinSearch.Filter = ""
		strMemory = ""
		Me.Text = "Search"
	End Sub

	Private Sub chkSortByChecked_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSortByChecked.CheckedChanged
		If sender.checked = True Then
			BinSearch.Sort = "chkbox DESC"
		Else
			BinSearch.RemoveSort()
		End If
	End Sub
	Private Sub grvFound_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grvFound.CellEndEdit
        If Not ShowChkBox Then Return
        If ListNotFilter.Contains(Me.grvFound.Columns(Me.grvFound.CurrentCell.ColumnIndex).HeaderText) Then
            If Not grvFound.CurrentCell.Value Is Nothing And Not grvFound.CurrentCell.Value Is DBNull.Value Then
                If grvFound.CurrentCell.Value <> 0 Then
                    grvFound.CurrentRow.Cells("ChkBox").Value = 1
                Else
                    grvFound.CurrentCell.Value = DBNull.Value

                End If

            Else
                grvFound.CurrentRow.Cells("ChkBox").Value = 0
            End If

        End If
	End Sub

	Private Sub dtblSP_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles dtblSP.ColumnChanged
		Try
			If Me.grvFound.CurrentCell.ColumnIndex = Me.grvFound.Columns("ChkBox").Index Then
				For Each txt As String In ListNotFilter
					If Me.grvFound.CurrentCell.Value = True And (Me.grvFound.CurrentRow.Cells(txt).Value Is Nothing Or Me.grvFound.CurrentRow.Cells(txt).Value Is DBNull.Value) Then
						Me.grvFound.CurrentRow.Cells(txt).Value = 1
					End If

				Next

			End If

		Catch ex As Exception

		End Try
	End Sub
End Class

