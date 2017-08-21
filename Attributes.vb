' ***********************************************************************
' Assembly         : Dev++
' Author           : Annael Samwel
' Created          : 08-18-2014
'
' Last Modified By : user
' Last Modified On : 10-03-2011
' ***********************************************************************
' <copyright file="Attributes.vb" company="Annael">
'     Copyright © Annael 2010
' </copyright>
' <summary></summary>
' ***********************************************************************
''' <summary>
''' The Common namespace.
''' </summary>
Namespace Common
    ''' <summary>
    ''' This class used to manage Attribues.
    ''' Created by Annael Samwel (Tanzania)
    ''' </summary>
    ''' <remarks></remarks>
    ''' <summary>
    ''' Class Attributes. This class cannot be inherited.
    ''' </summary>
    Friend NotInheritable Class Attributes
        ''' <summary>
        ''' The load ended
        ''' </summary>
        Private LoadEnded As Boolean = False
        ''' <summary>
        ''' Initializations this instance.
        ''' </summary>
        Private Sub initialization()

            frmAddAttrType.ShowInTaskbar = False
            frmAddAttrType.MinimizeBox = False
            frmAddAttrType.MaximizeBox = False
            frmAddAttrType.StartPosition = Windows.Forms.FormStartPosition.CenterParent
            frmAddAttrType.ShowIcon = False
            frmAddAttrType.Text = "Add attribute type"
            frmAddAttrType.Width = 300
            frmAddAttrType.Height = 150

            'Button
            btnSave.Text = "Save"


            'lbl
            lblAttrTypedesc.AutoSize = True
            lblAttrTypedesc.Text = "Description:"
            lblAttrTypedesc.Location = New Drawing.Point(0, 10)
            txtAttrTypedescr.Location = New Drawing.Point(lblAttrTypedesc.Width + 2, 10)
            txtAttrTypedescr.Width = lblAttrTypedesc.Width + lblAttrTypedesc.Width / 2
            btnSave.Location = New Drawing.Point(lblAttrTypedesc.Width + 2, 10 + txtAttrTypedescr.Height + 5)

            frmAddAttrType.Controls.Add(lblAttrTypedesc)
            frmAddAttrType.Controls.Add(txtAttrTypedescr)
            frmAddAttrType.Controls.Add(btnSave)
        End Sub
        ''' <summary>
        ''' Initializes a new instance of the <see cref="Attributes"/> class.
        ''' </summary>
        Public Sub New()

            Dim con As New SqlClient.SqlConnection(Data.SQLSERVER.ConnectionString)
            Me.AtrrTyepAdapter = New SqlClient.SqlDataAdapter(QueryAttrType, con)
            Me.AtrrAdapter = New SqlClient.SqlDataAdapter(QueryAttr, con)
            ReadAttributes()
            AttrDataset.Tables.Add(AttrTypeDatatable)
            AttrDataset.Tables.Add(AttrDatatable)
            AttrRelation = New DataRelation("AttrRelation", New DataColumn() {AttrTypeDatatable.Columns(0)}, New DataColumn() {AttrDatatable.Columns(1)}, False)
            AttrDataset.Relations.Add(AttrRelation)
            _AttrTypeBindingSource.DataSource = AttrDataset.Tables(0)
            _AttrBindingSource.DataMember = "AttrRelation"
            _AttrBindingSource.DataSource = _AttrTypeBindingSource
            initialization()
        End Sub
#Region "Fields"
        ''' <summary>
        ''' The query attribute type
        ''' </summary>
        Private Const QueryAttrType As String = "SELECT [AttrTypeId] ,[AttrTypeDescription] ,[AttrTypeHasCode] " & _
                                                 " ,[isBlocked]  ,[isSystem] FROM [tblDevppAttrType] WHERE isNull([isSystem], 0) <> 1   ORDER BY [AttrTypeDescription]"
        ''' <summary>
        ''' The query attribute
        ''' </summary>
        Private Const QueryAttr As String = "SELECT [attrId] ,[AttrTypeId],[AttrCode] ,[AttrDescription] ,[AttrIsBlocked] " & _
                                            ",[AttrIsSystem]  FROM [tblDevppAttr] WHERE isNull([AttrIsSystem], 0) <> 1  "


        ''' <summary>
        ''' The attribute dataset
        ''' </summary>
        Private AttrDataset As New DataSet
        ''' <summary>
        ''' The attribute datatable
        ''' </summary>
        Private WithEvents AttrDatatable As New DataTable
        ''' <summary>
        ''' The attribute type datatable
        ''' </summary>
        Private AttrTypeDatatable As New DataTable
        ''' <summary>
        ''' The attribute relation
        ''' </summary>
        Private AttrRelation As DataRelation
        ''' <summary>
        ''' The _ attribute type binding source
        ''' </summary>
        Private WithEvents _AttrTypeBindingSource As New System.Windows.Forms.BindingSource
        ''' <summary>
        ''' The _ attribute binding source
        ''' </summary>
        Private WithEvents _AttrBindingSource As New System.Windows.Forms.BindingSource
        ''' <summary>
        ''' The check change
        ''' </summary>
        Private CheckChange As Boolean = False
        ''' <summary>
        ''' The attribute identifier
        ''' </summary>
        Private AttrID As Integer
        ''' <summary>
        ''' The description
        ''' </summary>
        Private Description As String
        ''' <summary>
        ''' The blocked
        ''' </summary>
        Private Blocked As Boolean
        ''' <summary>
        ''' The row created
        ''' </summary>
        Private rowCreated As Boolean = False
        ''' <summary>
        ''' The attri delete identifier
        ''' </summary>
        Private AttriDelID As Integer
        ''' <summary>
        ''' The type identifier
        ''' </summary>
        Private TypeID As Integer
        ''' <summary>
        ''' The FRM add attribute type
        ''' </summary>
        Private WithEvents frmAddAttrType As New Windows.Forms.Form
        ''' <summary>
        ''' The BTN save
        ''' </summary>
        Private WithEvents btnSave As New Windows.Forms.Button
        ''' <summary>
        ''' The text attribute typedescr
        ''' </summary>
        Private WithEvents txtAttrTypedescr As New Windows.Forms.TextBox
        ''' <summary>
        ''' The label attribute typedesc
        ''' </summary>
        Private lblAttrTypedesc As New Windows.Forms.Label
        ''' <summary>
        ''' The atrr adapter
        ''' </summary>
        Private AtrrAdapter As SqlClient.SqlDataAdapter
        ''' <summary>
        ''' The atrr tyep adapter
        ''' </summary>
        Private AtrrTyepAdapter As SqlClient.SqlDataAdapter
        ''' <summary>
        ''' Occurs when [has code changed].
        ''' </summary>
        Public Event HasCodeChanged(ByVal obj As Boolean)
#End Region
#Region "Property"
        ''' <summary>
        ''' Gets the attribute type binding source.
        ''' </summary>
        ''' <value>The attribute type binding source.</value>
        Public ReadOnly Property AttrTypeBindingSource() As Windows.Forms.BindingSource
            Get
                Return _AttrTypeBindingSource
            End Get
        End Property
        ''' <summary>
        ''' Gets the attribute binding source.
        ''' </summary>
        ''' <value>The attribute binding source.</value>
        Public ReadOnly Property AttrBindingSource() As Windows.Forms.BindingSource
            Get
                Return _AttrBindingSource
            End Get
        End Property
#End Region
#Region "Methods"
        ''' <summary>
        ''' Deletes the attribute.
        ''' </summary>
        Public Sub DeleteAttribute()
            Dim strQuery As String = "DELETE FROM [tblDevppAttr] WHERE WHERE attrId = " & AttriDelID.ToString
            Dim con As New SqlClient.SqlConnection(Devpp.Data.SQLSERVER.ConnectionString)
            Dim com As New SqlClient.SqlCommand(strQuery, con)
            Try
                con.Open()
                com.ExecuteNonQuery()
                con.Close()
                ReadAttributes()
            Catch ex As Exception
                con.Close()
            End Try
        End Sub
        ''' <summary>
        ''' Reads the attributes.
        ''' </summary>
        Private Sub ReadAttributes()
            Try
                AttrTypeDatatable.Clear()
                AttrDatatable.Clear()
                Me.AtrrTyepAdapter.Fill(AttrTypeDatatable)
                Me.AtrrAdapter.Fill(AttrDatatable)
                LoadEnded = True
            Catch ex As Exception

            End Try
        End Sub
        ''' <summary>
        ''' Updates the attribute.
        ''' </summary>
        Friend Sub UpdateAttribute()
            Try
                Me.AttrBindingSource.EndEdit()
                Dim ID As Integer = 0
                If Me.AttrBindingSource.Count > 0 Then
                    Dim dr As DataRowView = Me.AttrBindingSource.Current
                    ID = IIf(dr("attrId") Is DBNull.Value, 0, dr("attrId"))
                End If

                Dim QueryBulder As New SqlClient.SqlCommandBuilder(Me.AtrrAdapter)
                Me.AtrrAdapter.UpdateCommand = QueryBulder.GetUpdateCommand
                Me.AtrrAdapter.Update(Me.AttrDatatable)
                LoadEnded = False
                Me.AttrDatatable.Clear()
                Me.AtrrAdapter.Fill(Me.AttrDatatable)
                LoadEnded = True
                If ID > 0 Then
                    Me.AttrBindingSource.Position = Me.AttrBindingSource.Find("attrId", ID)
                Else
                    Me.AttrBindingSource.MoveLast()
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub
#End Region


        ''' <summary>
        ''' Handles the CurrentChanged event of the _AttrBindingSource control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub _AttrBindingSource_CurrentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _AttrBindingSource.CurrentChanged
            'If CheckChange = True Then
            '    UpdateAttribute()
            'End If
            Try
                Dim dr As DataRowView = _AttrBindingSource.Current
                AttriDelID = dr(0)
            Catch ex As Exception

            End Try
        End Sub

        ''' <summary>
        ''' Handles the ColumnChanged event of the AttrDatatable control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.Data.DataColumnChangeEventArgs"/> instance containing the event data.</param>
        Private Sub AttrDatatable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs) Handles AttrDatatable.ColumnChanged
            Try
                'Me.UpdateAttribute()
            Catch ex As Exception

            End Try
        End Sub
        ''' <summary>
        ''' Handles the Load event of the frmAddAttrType control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub frmAddAttrType_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles frmAddAttrType.Load
            frmAddAttrType.BackColor = Settings.BackGroundColor1
            frmAddAttrType.ForeColor = Settings.FontColor
            frmAddAttrType.Font = Settings.Font
        End Sub
        ''' <summary>
        ''' Adds the type of the attribute.
        ''' </summary>
        Public Sub AddAttrType()
            frmAddAttrType.ShowDialog()
        End Sub
        ''' <summary>
        ''' Handles the Click event of the btnSave control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
            If Me.txtAttrTypedescr.Text <> "" Then
                Dim con As New SqlClient.SqlConnection(Devpp.Data.SQLSERVER.ConnectionString)
                Dim updateQuery As String = "INSERT INTO [tblDevppAttrType] ( [AttrTypeDescription]) VALUES(@AttrDescription )"
                Dim com As New SqlClient.SqlCommand(updateQuery, con)
                com.Parameters.Add("@AttrDescription", SqlDbType.NVarChar, 50)
                com.Parameters("@AttrDescription").Value = txtAttrTypedescr.Text
                Try
                    con.Open()
                    com.ExecuteNonQuery()
                    con.Close()
                    ReadAttributes()
                    frmAddAttrType.Close()
                Catch ex As Exception
                    con.Close()
                End Try
            Else
                MsgBox("Enter Description")
                txtAttrTypedescr.Focus()
            End If
        End Sub

        ''' <summary>
        ''' Handles the RowChanged event of the AttrDatatable control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.Data.DataRowChangeEventArgs"/> instance containing the event data.</param>
        Private Sub AttrDatatable_RowChanged(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs) Handles AttrDatatable.RowChanged
            If LoadEnded = True Then
                Me.UpdateAttribute()

            End If

        End Sub

        ''' <summary>
        ''' Handles the RowDeleted event of the AttrDatatable control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.Data.DataRowChangeEventArgs"/> instance containing the event data.</param>
        Private Sub AttrDatatable_RowDeleted(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs) Handles AttrDatatable.RowDeleted
            If LoadEnded = True Then
                Me.UpdateAttribute()

            End If
        End Sub
        ''' <summary>
        ''' Initializes the ended.
        ''' </summary>
        Friend Sub InitEnded()
            If _AttrTypeBindingSource.Count > 0 Then
                Dim dr As DataRowView = _AttrTypeBindingSource.Current
                RaiseEvent HasCodeChanged(IIf(dr("AttrTypeHasCode") Is DBNull.Value, False, dr("AttrTypeHasCode")))
            End If
        End Sub
        ''' <summary>
        ''' Handles the CurrentChanged event of the _AttrTypeBindingSource control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        Private Sub _AttrTypeBindingSource_CurrentChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles _AttrTypeBindingSource.CurrentChanged
            If _AttrTypeBindingSource.Count > 0 Then
                Dim dr As DataRowView = _AttrTypeBindingSource.Current
                RaiseEvent HasCodeChanged(IIf(dr("AttrTypeHasCode") Is DBNull.Value, False, dr("AttrTypeHasCode")))
            End If
        End Sub
    End Class

   
End Namespace
