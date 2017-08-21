Imports Devpp.Security

Friend Class frmRightReport
    Private Const UsersSQL As String = "SELECT * FROM [tblDevppUser] WHERE [usrIsGroup] = @usrIsGroup AND  usrIsBlocked = @usrIsBlocked AND usrName <> 'Guest' "
    Private Const SQLMapping As String = "SELECT     tblDevppUserRights.UserSecNr, tblDevppMapUserGroup.UserId " & _
                                            "FROM         tblDevppUserRights INNER JOIN " & _
                                         " tblDevppMapUserGroup ON tblDevppUserRights.UserID = tblDevppMapUserGroup.GroupId"
    Private UserAdapter As SqlClient.SqlDataAdapter
    Private UserDataTable As New DataTable

    Private MapingAdapter As SqlClient.SqlDataAdapter
    Private MapingDataTable As New DataTable
    Private MapingBindingSource As New Windows.Forms.BindingSource
    Friend IsGroup As Boolean = False
    Friend isBlocked As Boolean = False
    Friend ReportParam As String
    Private Sub frmRightReport_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ReportDataTable As New DataTable("UserRight")
        ReportDataTable.Columns.Add("User", GetType(String))
        ReportDataTable.Columns.Add("Right", GetType(String))
        ReportDataTable.Columns.Add("Value", GetType(Integer))

        Dim con As New SqlClient.SqlConnection(Data.SQLSERVER.ConnectionString)
        Dim com As New SqlClient.SqlCommand(UsersSQL, con)
        com.Parameters.Add("@usrIsGroup", SqlDbType.Bit).Value = IsGroup
        com.Parameters.Add("@usrIsBlocked", SqlDbType.Bit).Value = isBlocked
        UserAdapter = New SqlClient.SqlDataAdapter(com)
        UserAdapter.Fill(UserDataTable)

        MapingAdapter = New SqlClient.SqlDataAdapter(SQLMapping, con)
        MapingAdapter.Fill(MapingDataTable)
        MapingBindingSource.DataSource = MapingDataTable
        For Each r As DataRow In UserManager.ParentRightDataTable.Rows
            For Each ur As DataRow In UserDataTable.Rows
                MapingBindingSource.Filter = "UserId = " & ur("usrPid") & " AND  " & " UserSecNr =  " & r(0)
                If MapingBindingSource.Count > 0 Then
                    ReportDataTable.Rows.Add(ur("usrName"), r(1), 1)
                Else
                    ReportDataTable.Rows.Add(ur("usrName"), r(1), 0)
                End If
            Next
        Next

        For Each r As DataRow In UserManager.Child1RightDataTable.Rows
            For Each ur As DataRow In UserDataTable.Rows
                MapingBindingSource.Filter = "UserId = " & ur("usrPid") & " AND  " & " UserSecNr =  " & r(0)
                If MapingBindingSource.Count > 0 Then
                    ReportDataTable.Rows.Add(ur("usrName"), r(2), 1)
                Else
                    ReportDataTable.Rows.Add(ur("usrName"), r(2), 0)
                End If
            Next
        Next
        For Each r As DataRow In UserManager.Child2RightDataTable.Rows
            For Each ur As DataRow In UserDataTable.Rows
                MapingBindingSource.Filter = "UserId = " & ur("usrPid") & " AND  " & " UserSecNr =  " & r(0)
                If MapingBindingSource.Count > 0 Then
                    ReportDataTable.Rows.Add(ur("usrName"), r(2), 1)
                Else
                    ReportDataTable.Rows.Add(ur("usrName"), r(2), 0)
                End If
            Next
        Next

        Dim rpt As New Devpp.Common.Reporting
        rpt.EmbeddedResource = My.Resources.rp123870114e
        rpt.paramValues.Add(ReportParam)
        rpt.ReportDataSources.Add(Devpp.Data.SQLSERVER.GetSPReportDataSource("UserRight", ReportDataTable))
        rpt.PreviewReport(True)
        Me.Controls.Add(rpt.ucReport)

    End Sub
End Class