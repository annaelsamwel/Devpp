Namespace UserControls
    Public Class ucAttributes
        Private WithEvents Attr As New Common.Attributes
        Private WithEvents strpAddAttrType As New Windows.Forms.ToolStripMenuItem
        Private Sub ucAttributes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
           
            Try

                Me.cmbAttrType.DataSource = Attr.AttrTypeBindingSource
                Me.cmbAttrType.DisplayMember = "AttrTypeDescription"
                Me.cmbAttrType.ValueMember = "AttrTypeDescription"
                Me.grvAttributes.DataSource = Attr.AttrBindingSource
                Me.txtCode.DataBindings.Clear()
                Me.txtCode.DataBindings.Add("Text", Attr.AttrBindingSource, "AttrCode")
                Me.grvAttributes.Columns(0).Visible = False
                Me.grvAttributes.Columns(1).Visible = False
                Me.grvAttributes.Columns("AttrCode").Visible = False
                Me.grvAttributes.Columns("AttrCode").HeaderText = "Code"
                Me.grvAttributes.Columns("AttrDescription").HeaderText = "Description"
                Me.grvAttributes.Columns("AttrIsBlocked").HeaderText = "Blocked"
                Me.grvAttributes.Columns("AttrIsSystem").HeaderText = "System"
                Me.grvAttributes.Columns("AttrIsSystem").ReadOnly = True
                Me.grvAttributes.Columns("AttrDescription").ReadOnly = False
                Me.grvAttributes.Columns("AttrDescription").Width = Me.grvAttributes.Width - 165
                Me.grvAttributes.Columns("AttrIsBlocked").Width = 50
                Me.grvAttributes.Columns("AttrIsSystem").Width = 50
                Me.grvAttributes.Columns("AttrCode").Width = 50
                Me.grvAttributes.AllowUserToResizeColumns = False
                Attr.InitEnded()
            Catch ex As Exception

            End Try

        End Sub
        Private Sub strpAddAttrType_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles strpAddAttrType.Click
            Attr.AddAttrType()
        End Sub

        Private Sub grvAttributes_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles grvAttributes.KeyUp

            If e.KeyCode = Windows.Forms.Keys.Delete Then
                Dim con As New SqlClient.SqlConnection(Data.SQLSERVER.ConnectionString)
                Try
                    Dim com As New SqlClient.SqlCommand("DELETE FROM tblDevppAttr WHERE attrId = " & grvAttributes.CurrentRow.Cells("attrId").Value, con)
                    con.Open()
                    com.ExecuteNonQuery()
                    con.Close()
                Catch ex As Exception
                    con.Close()
                End Try
            End If
        End Sub

        Private Sub grvAttributes_RowsAdded(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewRowsAddedEventArgs) Handles grvAttributes.RowsAdded

        End Sub

        Private Sub txtFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFilter.TextChanged
            Attr.AttrBindingSource.Filter = "AttrDescription LIKE '%" + Me.txtFilter.Text + "%'"
            Me.grvAttributes.DataSource = Attr.AttrBindingSource
        End Sub

        Private Sub grvAttributes_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grvAttributes.CellContentClick

        End Sub

        Private Sub Attr_HasCodeChanged(ByVal obj As Boolean) Handles Attr.HasCodeChanged
            Try

                Me.grvAttributes.Columns("AttrCode").Visible = obj
            Catch ex As Exception

            End Try
        End Sub
    End Class
End Namespace