Imports System.IO
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Imaging
Imports System.Drawing.Printing
Imports System.Collections.Generic
Imports Microsoft.Reporting.WinForms
Imports System.Text
Imports System
Imports System.Net.Mail
Friend Class Mail

End Class

Namespace Common
    Friend Class rpt

        Inherits ReportViewer
        Public isPrinting As Boolean = False
        Public NoCopy As Integer = 1
        Public Sub New()
            'Common.Reporting.Mytime.Interval = 10
            'Common.Reporting.Mytime.Enabled = True
            'Common.Reporting.Mytime.Start()
        

        End Sub
       
        Private Sub rpt_StatusChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.StatusChanged
            If Me.CurrentStatus.IsDocumentMapVisible And isPrinting Then
                MsgBox("Now test")
                For x As Integer = 1 To NoCopy
                    Me.PrintDialog()
                Next
                Me.ParentForm.Close()
            End If
        End Sub
    End Class
    Partial Class Reporting


#Region "Fields"
        Private WithEvents timer1 As New Timer
        Friend Shared WithEvents Mytime As New Timer
        Private FileLoc As New List(Of String)
        Private _EmailServer As String = Nothing
        Private _SourceEmail As String = Nothing
        Private _AttachFileName As String
        Private _EmailPort As Integer
        Private _EmailPassword As String

#End Region
#Region "Property"
        Public Property EmailPassword() As String
            Get
                Return _EmailPassword
            End Get
            Set(ByVal value As String)
                _EmailPassword = value

            End Set
        End Property
        ''' <summary>
        ''' Set and get Property for name of atarchent
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property AttachFileName() As String
            Get
                Return _AttachFileName
            End Get
            Set(ByVal value As String)
                _AttachFileName = value
            End Set
        End Property
        ''' <summary>
        ''' Set and get Propert for Emailserver
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property EmailServer() As String
            Get
                Return _EmailServer
            End Get
            Set(ByVal value As String)
                _EmailServer = value
            End Set
        End Property
        Public Property EmailPort() As Integer
            Get
                Return _EmailPort
            End Get
            Set(ByVal value As Integer)
                _EmailPort = value
            End Set
        End Property

        ''' <summary>
        ''' The source Email Address
        ''' </summary>
        ''' <value></value>
        ''' <returns></returns>
        ''' <remarks></remarks>
        Public Property SourceEmailAddress() As String
            Get
                Return _SourceEmail
            End Get
            Set(ByVal value As String)
                _SourceEmail = value
            End Set
        End Property

#End Region
        ''' <summary>
        ''' Method fo sending email
        ''' </summary>
        ''' <param name="DestEmailAddress">Source Email</param>
        ''' <param name="isEmbeddedResource">If is true read EmbeddedResource byte array else read the location of the report
        ''' </param>
        ''' <param name="subject">Subject for Email</param>
        ''' <param name="useAtarchment">Default for atarchment allowing </param>
        ''' <remarks></remarks>
        Public Sub SendEmail(ByVal DestEmailAddress As List(Of String), ByVal isEmbeddedResource As Boolean, ByVal subject As String, Optional ByVal useAtarchment As Boolean = True)

            Try
                If _EmailServer = Nothing Then
                    Throw New Exception("Email Server has not been set")
                End If
                If _SourceEmail = Nothing Then
                    Throw New Exception("Source Email address  has not been set")
                End If

                Dim EmaiDoc As New MailMessage
                Dim attach As String = Me.getAttachment(isEmbeddedResource)
                If useAtarchment Then
                    If _AttachFileName = Nothing Then
                        Throw New Exception("Attachment file name has not been set")
                    End If
                    Dim attachment As New System.Net.Mail.Attachment(attach)
                    EmaiDoc.Attachments.Add(attachment)
                End If
               
                Dim fromAddress As New MailAddress(SourceEmailAddress)
                EmaiDoc.From = fromAddress

                Dim server As System.Net.Mail.SmtpClient = New SmtpClient(EmailServer)
                For Each V_string As String In DestEmailAddress
                    EmaiDoc.CC.Add(V_string)
                Next
                EmaiDoc.Subject = subject
                server.Port = EmailPort
                server.Timeout = 1000000
                server.Credentials = New System.Net.NetworkCredential(Me.SourceEmailAddress, EmailPassword)
                server.Send(EmaiDoc)
                Me.FileLoc.Add(attach)
                Me.timer1.Enabled = True
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
           

        End Sub
        ''' <summary>
        ''' Method fo sending email with HTML body
        ''' </summary>
        ''' <param name="DestEmailAddress">Source Email</param>
        ''' <param name="isEmbeddedResource">If is true read EmbeddedResource byte array else read the location of the report</param>
        ''' <param name="subject">Subject for Email</param>
        ''' <param name="HTMBody">HTML Codes</param>
        ''' <param name="useAtarchment">Default for atarchment allowing </param>
        ''' <remarks></remarks>
        Public Sub SendEmail(ByVal DestEmailAddress As List(Of String), ByVal isEmbeddedResource As Boolean, ByVal subject As String, ByVal HTMBody As String, Optional ByVal useAtarchment As Boolean = True)

            Try
                If _EmailServer = Nothing Then
                    Throw New Exception("Email Saver doesn`t initialized")
                End If
                If _SourceEmail = Nothing Then
                    Throw New Exception("Source Email address  doesn't initialized")
                End If
                Dim attach As String = Me.getAttachment(isEmbeddedResource)
                Dim EmaiDoc As New MailMessage
                EmaiDoc.IsBodyHtml = True
                EmaiDoc.Body = HTMBody
                If useAtarchment Then


                    If _AttachFileName = Nothing Then
                        Throw New Exception("Attachment file name has not been set")
                    End If
                    Dim attachment As New System.Net.Mail.Attachment(attach)
                    EmaiDoc.Attachments.Add(attachment)
                End If
                Dim fromAddress As New MailAddress(SourceEmailAddress)
                EmaiDoc.From = fromAddress
                Dim server As System.Net.Mail.SmtpClient = New SmtpClient(EmailServer)
                For Each V_string As String In DestEmailAddress
                    EmaiDoc.Bcc.Add(V_string)
                Next
                EmaiDoc.Subject = subject
                server.Port = EmailPort
                server.Timeout = 1000000
                server.Credentials = New System.Net.NetworkCredential(Me.SourceEmailAddress, EmailPassword)
                server.Send(EmaiDoc)
                Me.FileLoc.Add(attach)
                Me.timer1.Enabled = True
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try

        End Sub
        Private Sub timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles timer1.Tick
            For Each V_str As String In FileLoc
                Try
                    My.Computer.FileSystem.DeleteFile(V_str)
                Catch ex As Exception

                End Try
            Next
            Me.FileLoc.Clear()
            Me.timer1.Enabled = False
        End Sub

        'Private Shared Sub Mytime_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Mytime.Tick
        '    Login.CheckLogin()
        '    If Security.UserManager.EndV_bool = True Then
        '        Environment.Exit(1)
        '    End If
        'End Sub
    End Class

End Namespace