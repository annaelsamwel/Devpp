Imports System.Windows.Forms
Imports Microsoft.SqlServer.Management.Smo.Wmi
Friend Class frmRestartServer
    Public txt As New RichTextBox
    Dim V_int As Integer = 0
    Public InstanceName As String
    Private Retarted As Boolean = False
    'Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
    '    Me.ProgressBar1.Value = Me.ProgressBar1.Value + 10
    '    If Me.ProgressBar1.Value = 100 Then
    '        Me.ProgressBar1.Value = 0
    '    End If
    '    Try
    '        If V_int = 0 Then
    '            Dim con As New SqlClient.SqlConnection(Devpp.Data.SQLSERVER.ConnectionString)
    '            Dim com As New SqlClient.SqlCommand("SHUTDOWN WITH NOWAIT", con)
    '            AddLogFile(Now & " SERVER Shuting down ")
    '            Try
    '                con.Open()
    '                com.ExecuteNonQuery()

    '                con.Close()
    '            Catch ex As Exception
    '                MsgBox("Shutdown failed you need to restart manualy")

    '                AddLogFile(Now & " SERVER shut down failed ")
    '                Me.Close()
    '                Me.ParentForm.Close()
    '                Me.Timer1.Enabled = False
    '            End Try
    '            Me.lblMessage.Text = "Stoping service..."
    '            txt.Text = txt.Text & Me.lblMessage.Text & vbNewLine
    '            Dim strcommand As String = "NET START " & """" & "SQL SERVER (" & DBInitialization.DBInstanceName & ")" & """"
    '            Dim strm As New IO.StreamWriter(ApplicationLocation & "\EtempSQL.BAT")
    '            strm.Write(strcommand)
    '            strm.Close()

    '        ElseIf V_int = 30 Then
    '            AddLogFile(Now & " SERVER shut down successfully ")
    '            Me.lblMessage.Text = "Checking system configulation..."
    '            txt.Text = txt.Text & Me.lblMessage.Text & vbNewLine
    '            Shell(ApplicationLocation & "\EtempSQL.BAT", AppWinStyle.Hide)
    '        ElseIf V_int = 60 Then
    '            AddLogFile(Now & " Starting SERVICE ")
    '            Me.lblMessage.Text = "Starting service..."
    '            txt.Text = txt.Text & Me.lblMessage.Text & vbNewLine
    '        ElseIf V_int = 140 Then
    '            AddLogFile(Now & " SERVICE started successfully ")
    '            V_int = 0
    '            Timer1.Enabled = False
    '            txt.Text = txt.Text & "Deleting temp files..." & vbNewLine
    '            My.Computer.FileSystem.DeleteFile(ApplicationLocation & "\EtempSQL.BAT")
    '            AddLogFile(Now & " Deleting temp files ")
    '            Cursor = Cursors.Default
    '            Me.Close()
    '            Exit Sub
    '        End If

    '    Catch ex As Exception
    '        AddLogFile("Process failed because of " & ex.Message & " " & Now)
    '        Me.Timer1.Enabled = False
    '        MsgBox(ex.Message)
    '        Cursor = Cursors.Default
    '    End Try
    '    V_int += 1
    'End Sub

    Private Sub frmRestartServer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Timer1.Enabled = True
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        If Retarted = True Then Exit Sub
        Retarted = True
        Dim con As New System.Data.SqlClient.SqlConnection(Data.SQLSERVER.ConnectionString)
        Dim WMiMann As New Microsoft.SqlServer.Management.Smo.Wmi.ManagedComputer(Split(InstanceName, "\")(0))

        Dim WMIService As Microsoft.SqlServer.Management.Smo.Wmi.Service = WMiMann.Services("MSSQL$" & Split(InstanceName, "\")(1))

        If WMIService.ServiceState = ServiceState.Running Then



            stBar.Visible = True
            Windows.Forms.Application.DoEvents()
            lblService.Visible = True
            Windows.Forms.Application.DoEvents()
            lblService.Text = "Stoping Service"
            Windows.Forms.Application.DoEvents()
            If con.State = ConnectionState.Closed Then con.Open()
            Dim com1 As New SqlClient.SqlCommand("SHUTDOWN WITH NOWAIT", con)
            com1.ExecuteNonQuery()
            con.Close()
            Do Until WMIService.ServiceState = ServiceState.Stopped
                If stBar.Value = 100 Then
                    stBar.Value = 0
                    Windows.Forms.Application.DoEvents()

                End If
                stBar.Value += 10
                Windows.Forms.Application.DoEvents()

                Windows.Forms.Application.DoEvents()
                WMIService.Refresh()
                Windows.Forms.Application.DoEvents()
            Loop
            stBar.Value = 0
            Windows.Forms.Application.DoEvents()
            lblService.Text = ""
            Windows.Forms.Application.DoEvents()
            System.Threading.Thread.Sleep(1000)
        End If
        If WMIService.ServiceState = ServiceState.Stopped Then
            WMIService.Start()

            lblService.Text = "Start Service"
            Windows.Forms.Application.DoEvents()
            Do Until WMIService.ServiceState = ServiceState.Running
                WMIService.Refresh()
                If stBar.Value = 100 Then
                    stBar.Value = 0
                    Windows.Forms.Application.DoEvents()
                End If
                stBar.Value += 10
                Windows.Forms.Application.DoEvents()


            Loop
        End If
        stBar.Value = 0
        Windows.Forms.Application.DoEvents()
        lblService.Text = ""
        Windows.Forms.Application.DoEvents()
        System.Threading.Thread.Sleep(1000)

        stBar.Visible = False
        Windows.Forms.Application.DoEvents()
        lblService.Visible = False
        Windows.Forms.Application.DoEvents()
        Me.Close()
    End Sub
End Class
