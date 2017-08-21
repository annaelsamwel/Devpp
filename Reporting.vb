' ***********************************************************************
' Assembly         : Dev++
' Author           : Annael Samwel
' Created          : 08-18-2014
'
' Last Modified By : user
' Last Modified On : 06-29-2014
' ***********************************************************************
' <copyright file="Reporting.vb" company="Annael">
'     Copyright © Annael 2010
' </copyright>
' <summary></summary>
' ***********************************************************************
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
Imports System.ComponentModel
''' <summary>
''' The Common namespace.
''' </summary>
Namespace Common
    ''' <summary>
    ''' This used to manage Reporting things
    ''' Created by Annael and Paul
    ''' </summary>
    Public Class Reporting
        Inherits System.ComponentModel.Component
#Region "Fields"
        ''' <summary>
        ''' The _report location
        ''' </summary>
        Private _reportLocation As String
        ''' <summary>
        ''' The _report name
        ''' </summary>
        Private _reportName As String
        ''' <summary>
        ''' The _return rows
        ''' </summary>
        Private _returnRows As Integer
        ''' <summary>
        ''' The _ company name
        ''' </summary>
        Private _CompanyName As String
        ''' <summary>
        ''' The _param value
        ''' </summary>
        Private _paramValue As New List(Of String)
        ''' <summary>
        ''' The _ report data sources
        ''' </summary>
        Private _ReportDataSources As New List(Of Microsoft.Reporting.WinForms.ReportDataSource)
        ''' <summary>
        ''' The _uc report
        ''' </summary>
        Private _ucReport As New UserControl
        ''' <summary>
        ''' The dialog print
        ''' </summary>
        Private dlgPrint As New PrintDialog
        ''' <summary>
        ''' The _ embedded resource
        ''' </summary>
        Private _EmbeddedResource As Byte()
        ''' <summary>
        ''' The m_streams
        ''' </summary>
        Private m_streams As IList(Of Stream)
        ''' <summary>
        ''' The _ page width
        ''' </summary>
        Private _PageWidth As Single = 8.27
        ''' <summary>
        ''' The _ page height
        ''' </summary>
        Private _PageHeight As Single = 11.69
        ''' <summary>
        ''' The _ margin top
        ''' </summary>
        Private _MarginTop As Single = 0.25
        ''' <summary>
        ''' The _ margin left
        ''' </summary>
        Private _MarginLeft As Single = 0.25
        ''' <summary>
        ''' The _ margin right
        ''' </summary>
        Private _MarginRight As Single = 0.25
        ''' <summary>
        ''' The _ margin bottom
        ''' </summary>
        Private _MarginBottom As Single = 0.25
        ''' <summary>
        ''' The print marg
        ''' </summary>
        Private printMarg As Margins
        ''' <summary>
        ''' The print pg size
        ''' </summary>
        Private PrintPgSize As PaperSize
        ''' <summary>
        ''' The newrpt viewer
        ''' </summary>
        Private WithEvents NewrptViewer As New rpt
        ''' <summary>
        ''' The _ print layout
        ''' </summary>
        Dim _PrintLayout As PrintLayouts = PrintLayouts.Landscape
        ''' <summary>
        ''' The m_current page index
        ''' </summary>
        Private m_currentPageIndex As Integer
        ''' <summary>
        ''' The _page unit
        ''' </summary>
        Private _pageUnit As PageUnits = PageUnits.in
        ''' <summary>
        ''' The print document
        ''' </summary>
        Private WithEvents printDoc As New PrintDocument()
        ''' <summary>
        ''' The show priter setting
        ''' </summary>
        Private ShowPriterSetting As Boolean = False
        ''' <summary>
        ''' The _is imbended
        ''' </summary>
        Private _isImbended As Boolean = False

#End Region
        ''' <summary>
        ''' The loc
        ''' </summary>
        Private WithEvents Loc As LocalReport
        ''' <summary>
        ''' Occurs when [subreport processing].
        ''' </summary>
        Public Event SubreportProcessing(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.SubreportProcessingEventArgs)
        ''' <summary>
        ''' Occurs when [drillthrough].
        ''' </summary>
        Public Event Drillthrough(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.DrillthroughEventArgs)
        ''' <summary>
        ''' Get Property wich return the current Reportviewer
        ''' </summary>
        ''' <value>The report view.</value>
        Public ReadOnly Property ReportView() As ReportViewer
            Get

                Return NewrptViewer
            End Get
        End Property
        ''' <summary>
        ''' The is printing
        ''' </summary>
        Public isPrinting As Boolean
           

        ''' <summary>
        ''' The no copy
        ''' </summary>
        Public NoCopy As Integer
           
        ''' <summary>
        ''' Get or set Property for measure used for printing
        ''' </summary>
        ''' <value>The page unit.</value>
        Public Property PageUnit() As PageUnits

            Get

                Return _pageUnit
            End Get
            Set(ByVal value As PageUnits)
                _pageUnit = value
            End Set
        End Property
        ''' <summary>
        ''' Bottom marging of page for printing
        ''' </summary>
        ''' <value>The margin bottom.</value>
        Public Property MarginBottom() As Single
            Get
                Return _MarginBottom
            End Get
            Set(ByVal value As Single)
                _MarginBottom = value
            End Set
        End Property
        ''' <summary>
        ''' Right margin of the page for printing
        ''' </summary>
        ''' <value>The margin right.</value>
        Public Property MarginRight() As Single
            Get
                Return _MarginRight
            End Get
            Set(ByVal value As Single)
                _MarginRight = value
            End Set
        End Property
        ''' <summary>
        ''' Left Margin for page printing
        ''' </summary>
        ''' <value>The margin left.</value>
        Public Property MarginLeft() As Single
            Get
                Return _MarginLeft
            End Get
            Set(ByVal value As Single)
                _MarginLeft = value
            End Set
        End Property
        ''' <summary>
        ''' Top marigin of the page for printing
        ''' </summary>
        ''' <value>The margin top.</value>
        Public Property MarginTop() As Single
            Get
                Return _MarginTop
            End Get
            Set(ByVal value As Single)
                _MarginTop = value
            End Set
        End Property
        ''' <summary>
        ''' Height of the page for printing
        ''' </summary>
        ''' <value>The height of the page.</value>
        Public Property PageHeight() As Single
            Get
                Return _PageHeight
            End Get
            Set(ByVal value As Single)
                _PageHeight = value
            End Set
        End Property
        ''' <summary>
        ''' Width of the page for printing
        ''' </summary>
        ''' <value>The width of the page.</value>
        Public Property PageWidth() As Single
            Get
                Return _PageWidth
            End Get
            Set(ByVal value As Single)
                _PageWidth = value
            End Set
        End Property
        ''' <summary>
        ''' The byte array format of the report
        ''' </summary>
        ''' <value>The embedded resource.</value>
        Public WriteOnly Property EmbeddedResource() As Byte()
            Set(ByVal value() As Byte)
                _EmbeddedResource = value
            End Set
        End Property
        ''' <summary>
        ''' Set property for Printing layout
        ''' </summary>
        ''' <value>The print layout.</value>
        Public WriteOnly Property PrintLayout() As PrintLayouts
            Set(ByVal value As PrintLayouts)
                _PrintLayout = value
            End Set
        End Property
        ''' <summary>
        ''' Number of rows to be return after priviewing report
        ''' </summary>
        ''' <value>The return rows.</value>
        Public ReadOnly Property returnRows() As Integer
            Get
                Return _returnRows
            End Get
        End Property
        ''' <summary>
        ''' A user control wich displays report
        ''' </summary>
        ''' <value>The uc report.</value>
        Public ReadOnly Property ucReport() As UserControl
            Get
                Return _ucReport
            End Get
        End Property
        ''' <summary>
        ''' The schema location of the report in the hard drive
        ''' </summary>
        ''' <value>The report location.</value>
        Public Property ReportLocation() As String
            Get
                Return _reportLocation
            End Get
            Set(ByVal value As String)
                _reportLocation = value
            End Set
        End Property
        ''' <summary>
        ''' The name of the report which will be default during exporting
        ''' </summary>
        ''' <value>The name of the report.</value>
        Public Property ReportName() As String
            Get
                Return _reportName
            End Get
            Set(ByVal value As String)
                _reportName = value
            End Set
        End Property
        ''' <summary>
        ''' List of parameter value to be passed for report
        ''' </summary>
        ''' <value>The parameter values.</value>
        Public ReadOnly Property paramValues() As List(Of String)
            Get
                Return _paramValue
            End Get

        End Property
        ''' <summary>
        ''' List of datasources for report
        ''' </summary>
        ''' <value>The report data sources.</value>
        Public Property ReportDataSources() As List(Of Microsoft.Reporting.WinForms.ReportDataSource)
            Get
                Return _ReportDataSources
            End Get
            Set(ByVal value As List(Of Microsoft.Reporting.WinForms.ReportDataSource))
                _ReportDataSources = value
            End Set
        End Property

        ''' <summary>
        ''' Initializes a new instance of the <see cref="Reporting"/> class.
        ''' </summary>
        ''' <exception cref="Exception">Devpp DLL not registered</exception>
        Public Sub New()
            If Not DLLRegistered Then
                Throw New Exception("Devpp DLL not registered")
            End If
            _ucReport.Dock = DockStyle.Fill
            NewrptViewer = New rpt
            AddHandler NewrptViewer.LocalReport.SubreportProcessing, AddressOf Me.SubreportProcessingHandler
        End Sub
        ''' <summary>
        ''' Method for previwing report
        ''' </summary>
        ''' <param name="isEmbeddedResource">If is true read EmbeddedResource byte array else read the location of the report</param>
        ''' <param name="subReports">The sub reports.</param>
        ''' <param name="SubReportNames">The sub report names.</param>
        ''' <exception cref="Exception"></exception>
        Public Sub PreviewReport(ByVal isEmbeddedResource As Boolean, Optional ByVal subReports As List(Of Byte()) = Nothing, Optional ByVal SubReportNames As List(Of String) = Nothing)
            _isImbended = isEmbeddedResource

            NewrptViewer.isPrinting = Me.isPrinting
            NewrptViewer.NoCopy = Me.NoCopy
            Dim locReport As LocalReport = NewrptViewer.LocalReport
            NewrptViewer.Dock = DockStyle.Fill
            _ucReport.Controls.Clear()
            _ucReport.Controls.Add(NewrptViewer)

            Try

                'NewrptViewer.Reset()
                'NewrptViewer.LocalReport.DataSources.Clear()
                For Each x As Microsoft.Reporting.WinForms.ReportDataSource In _ReportDataSources
                    NewrptViewer.LocalReport.DataSources.Add(x)
                Next
                _returnRows = Data.SQLSERVER.ReturnRows
                If isEmbeddedResource = True Then
                    Dim MemStr As New MemoryStream(_EmbeddedResource)

                    NewrptViewer.LocalReport.LoadReportDefinition(MemStr)
                    MemStr.Close()
                    'If Not subReports Is Nothing Then
                    '    For x As Integer = 0 To subReports.Count - 1
                    '        Dim memS As New IO.MemoryStream(subReports(x))
                    '        NewrptViewer.LocalReport.LoadSubreportDefinition(SubReportNames(x), memS)
                    '    Next
                    'End If
                Else
                    NewrptViewer.LocalReport.ReportPath = _reportLocation

                End If

                NewrptViewer.LocalReport.DisplayName = _reportName
                Dim params As New List(Of Microsoft.Reporting.WinForms.ReportParameter)
                Dim i As Integer = 0
                For Each obj As String In _paramValue
                    params.Add(New Microsoft.Reporting.WinForms.ReportParameter("Param" + i.ToString, obj, False))
                    i = i + 1
                Next
                If i > 0 Then
                    NewrptViewer.LocalReport.SetParameters(params)
                End If
                If _returnRows > 0 Then
                    NewrptViewer.RefreshReport()

                    ' NewrptViewer.PrintDialog()
                    ' NewrptViewer.SetDisplayMode(DisplayMode.PrintLayout)
                End If

            Catch ex As Exception

                Throw New Exception(ex.Message)

            End Try
        End Sub
        ''' <summary>
        ''' Exports to excel.
        ''' </summary>
        ''' <param name="isEmbeddedResource">if set to <c>true</c> [is embedded resource].</param>
        ''' <exception cref="Exception"></exception>
        Public Sub ExportToExcel(ByVal isEmbeddedResource As Boolean)
            Dim SaveDlg As New Windows.Forms.SaveFileDialog
            SaveDlg.Filter = "Excel File|*.xls"
            If SaveDlg.ShowDialog <> DialogResult.Cancel Then
                Dim rptViewer As LocalReport = New LocalReport()
                Dim strAttachment As String = ""
                Try

                    rptViewer.DataSources.Clear()
                    For Each x As Microsoft.Reporting.WinForms.ReportDataSource In _ReportDataSources
                        rptViewer.DataSources.Add(x)
                    Next
                    _returnRows = Data.SQLSERVER.ReturnRows
                    If isEmbeddedResource = True Then
                        Dim MemStr As New MemoryStream(_EmbeddedResource)
                        Dim strm As New StreamReader(MemStr)
                        Dim txtR As TextReader = strm
                        rptViewer.LoadReportDefinition(txtR)
                        txtR.Close()
                        strm.Close()
                        MemStr.Close()
                        txtR.Dispose()
                        strm.Dispose()
                        MemStr.Dispose()
                    Else
                        rptViewer.ReportPath = _reportLocation

                    End If

                    rptViewer.DisplayName = _reportName
                    Dim params As New List(Of Microsoft.Reporting.WinForms.ReportParameter)
                    Dim i As Integer = 0
                    For Each obj As String In _paramValue
                        params.Add(New Microsoft.Reporting.WinForms.ReportParameter("Param" + i.ToString, obj, False))
                        i += 1
                    Next
                    If i > 0 Then
                        rptViewer.SetParameters(params)
                    End If

                    If _returnRows > 0 Then
                        Dim TempStream As Stream = Export(rptViewer, "Excel")(0)
                        Dim buff(TempStream.Length) As Byte
                        TempStream.Read(buff, 0, buff.Length)
                        TempStream.Close()



                        Dim fs As New FileStream(SaveDlg.FileName, FileMode.Create, FileAccess.Write)
                        fs.Write(buff, 0, buff.Length)
                        fs.Close()
                    End If
                Catch ex As Exception
                    Throw New Exception(ex.Message)
                End Try

            End If
        End Sub
        ''' <summary>
        ''' Return the PDF File location for report
        ''' </summary>
        ''' <param name="isEmbeddedResource">If is true read EmbeddedResource byte array else read the location of the report</param>
        ''' <returns>System.String.</returns>
        ''' <exception cref="Exception"></exception>
        Public Function GetAttachment(ByVal isEmbeddedResource As Boolean) As String
            Dim rptViewer As LocalReport = New LocalReport()
            Dim strAttachment As String = ""
            Try

                rptViewer.DataSources.Clear()
                For Each x As Microsoft.Reporting.WinForms.ReportDataSource In _ReportDataSources
                    rptViewer.DataSources.Add(x)
                Next
                _returnRows = Data.SQLSERVER.ReturnRows
                If isEmbeddedResource = True Then
                    Dim MemStr As New MemoryStream(_EmbeddedResource)
                    Dim strm As New StreamReader(MemStr)
                    Dim txtR As TextReader = strm
                    rptViewer.LoadReportDefinition(txtR)
                    txtR.Close()
                    strm.Close()
                    MemStr.Close()
                    txtR.Dispose()
                    strm.Dispose()
                    MemStr.Dispose()
                Else
                    rptViewer.ReportPath = _reportLocation

                End If

                rptViewer.DisplayName = _reportName
                Dim params As New List(Of Microsoft.Reporting.WinForms.ReportParameter)
                Dim i As Integer = 0
                For Each obj As String In _paramValue
                    params.Add(New Microsoft.Reporting.WinForms.ReportParameter("Param" + i.ToString, obj, False))
                    i += 1
                Next
                If i > 0 Then
                    rptViewer.SetParameters(params)
                End If

                If _returnRows > 0 Then
                    Dim TempStream As Stream = Export(rptViewer, "PDF")(0)
                    Dim buff(TempStream.Length) As Byte
                    TempStream.Read(buff, 0, buff.Length)
                    TempStream.Close()
                    If AttachFileName.Trim = "" Then
                        AttachFileName = Guid.NewGuid.ToString
                    End If
                    Dim location As String = IIf(My.Computer.FileSystem.SpecialDirectories.Temp.EndsWith("\"), My.Computer.FileSystem.SpecialDirectories.Temp, My.Computer.FileSystem.SpecialDirectories.Temp _
                                                 & "\") & AttachFileName & ".PDF"

                    strAttachment = location
                    Dim fs As New FileStream(location, FileMode.Create, FileAccess.Write)
                    fs.Write(buff, 0, buff.Length)
                    fs.Close()
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
            Return strAttachment
        End Function
        ''' <summary>
        ''' Method for printing report
        ''' </summary>
        ''' <param name="isEmbeddedResource">If is true read EmbeddedResource byte array else read the location of the report</param>
        ''' <exception cref="Exception"></exception>
        Public Sub PrintReport(ByVal isEmbeddedResource As Boolean)
            _isImbended = isEmbeddedResource
            NewrptViewer = New rpt
            NewrptViewer.isPrinting = Me.isPrinting
            NewrptViewer.NoCopy = Me.NoCopy
            Dim locReport As LocalReport = NewrptViewer.LocalReport
            Try

                NewrptViewer.Reset()
                NewrptViewer.LocalReport.DataSources.Clear()
                For Each x As Microsoft.Reporting.WinForms.ReportDataSource In _ReportDataSources
                    NewrptViewer.LocalReport.DataSources.Add(x)
                Next
                _returnRows = Data.SQLSERVER.ReturnRows
                If isEmbeddedResource = True Then
                    Dim MemStr As New MemoryStream(_EmbeddedResource)
                    Dim strm As New StreamReader(MemStr)
                    Dim txtR As TextReader = strm
                    NewrptViewer.LocalReport.LoadReportDefinition(txtR)
                    txtR.Close()
                    strm.Close()
                    MemStr.Close()
                    txtR.Dispose()
                    strm.Dispose()
                    MemStr.Dispose()
                Else
                    NewrptViewer.LocalReport.ReportPath = _reportLocation

                End If

                NewrptViewer.LocalReport.DisplayName = _reportName
                Dim params As New List(Of Microsoft.Reporting.WinForms.ReportParameter)
                Dim i As Integer = 0
                For Each obj As String In _paramValue
                    params.Add(New Microsoft.Reporting.WinForms.ReportParameter("Param" + i.ToString, obj, False))
                    i += 1
                Next
                If i > 0 Then
                    NewrptViewer.LocalReport.SetParameters(params)
                End If
                If _returnRows > 0 Then
                    Export(NewrptViewer.LocalReport, "Image")

                    m_currentPageIndex = 0
                    Print()
                End If
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub
        ''' <summary>
        ''' Creates the stream.
        ''' </summary>
        ''' <param name="name">The name.</param>
        ''' <param name="fileNameExtension">The file name extension.</param>
        ''' <param name="encoding">The encoding.</param>
        ''' <param name="mimeType">Type of the MIME.</param>
        ''' <param name="willSeek">if set to <c>true</c> [will seek].</param>
        ''' <returns>Stream.</returns>
        Private Function CreateStream(ByVal name As String, _
       ByVal fileNameExtension As String, _
       ByVal encoding As Encoding, ByVal mimeType As String, _
       ByVal willSeek As Boolean) As Stream
            Try
                Dim stream As Stream = _
                    New FileStream("..\..\" + _
                     name + "." + fileNameExtension, FileMode.Create)
                m_streams.Add(stream)

                Return stream
            Catch ex As Exception
                MsgBox("Printing in progress..")
                Return Nothing
                Me.Dispose()
            End Try
        End Function
        ''' <summary>
        ''' Exports the specified report.
        ''' </summary>
        ''' <param name="report">The report.</param>
        ''' <param name="ReaderType">Type of the reader.</param>
        ''' <returns>List(Of Stream).</returns>
        ''' <exception cref="Exception"></exception>
        Private Function Export(ByVal report As LocalReport, ByVal ReaderType As String) As List(Of Stream)
            report.Refresh()
            Dim DevppiceInfo As String = Nothing

            Select Case _PrintLayout
                Case Is = PrintLayouts.Portrait
                    DevppiceInfo = _
                    "<DevppiceInfo>" + _
                      "  <OutputFormat>EMF</OutputFormat>" + _
                      "  <PageWidth>8.27in</PageWidth>" + _
                      "  <PageHeight>11.69in</PageHeight>" + _
                      "  <MarginTop>0.25in</MarginTop>" + _
                      "  <MarginLeft>0.25in</MarginLeft>" + _
                      "  <MarginRight>0.25in</MarginRight>" + _
                      "  <MarginBottom>0.25in</MarginBottom>" + _
                      "</DevppiceInfo>"
                Case Is = PrintLayouts.Landscape

                    DevppiceInfo = _
                  "<DevppiceInfo>" + _
                  "  <OutputFormat>EMF</OutputFormat>" + _
                  "  <PageWidth>210mm</PageWidth>" + _
                  "  <PageHeight>297mm</PageHeight>" + _
                  "  <MarginTop>10mm</MarginTop>" + _
                  "  <MarginLeft>10mm</MarginLeft>" + _
                  "  <MarginRight>10mm</MarginRight>" + _
                  "  <MarginBottom>10mm</MarginBottom>" + _
                  "</DevppiceInfo>"
                Case Is = PrintLayouts.Custom
                    Dim unit As String = ""
                    If _pageUnit = PageUnits.in Then
                        unit = "in"
                    ElseIf _pageUnit = PageUnits.cm Then
                        unit = "cm"
                    ElseIf _pageUnit = PageUnits.mm Then
                        unit = "mm"
                    End If
                    DevppiceInfo = _
                     "<DevppiceInfo>" + _
                     "  <OutputFormat>EMF</OutputFormat>" + _
                     "  <PageWidth>" + _PageWidth.ToString + unit + "</PageWidth>" + _
                     "  <PageHeight>" + _PageHeight.ToString + unit + "</PageHeight>" + _
                     "  <MarginTop>" + _MarginTop.ToString + unit + "</MarginTop>" + _
                     "  <MarginLeft>" + _MarginLeft.ToString + unit + "</MarginLeft>" + _
                     "  <MarginRight>" + _MarginRight.ToString + unit + "</MarginRight>" + _
                     "  <MarginBottom>" + _MarginBottom.ToString + unit + "</MarginBottom>" + _
                     "</DevppiceInfo>"
                Case Else
                    DevppiceInfo = _
                    "<DevppiceInfo>" + _
                      "  <OutputFormat>EMF</OutputFormat>" + _
                      "  <PageWidth>8.27in</PageWidth>" + _
                      "  <PageHeight>11.69in</PageHeight>" + _
                      "  <MarginTop>0.25in</MarginTop>" + _
                      "  <MarginLeft>0.25in</MarginLeft>" + _
                      "  <MarginRight>0.25in</MarginRight>" + _
                      "  <MarginBottom>0.25in</MarginBottom>" + _
                      "</DevppiceInfo>"
            End Select
            Dim warnings() As Warning = Nothing
            m_streams = New List(Of Stream)()

            Try
                report.Render(ReaderType, "", AddressOf CreateStream, _
                   warnings)

                Dim stream As Stream
                For Each stream In m_streams
                    stream.Position = 0
                Next
                Return m_streams
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function

        ''' <summary>
        ''' Prints this instance.
        ''' </summary>
        ''' <exception cref="Exception"></exception>
        Private Sub Print()
            Try
                If m_streams Is Nothing Or m_streams.Count = 0 Then
                    Return
                End If
                If _PrintLayout = PrintLayouts.Landscape Then
                    printDoc.DefaultPageSettings.Landscape = True
                ElseIf _PrintLayout = PrintLayouts.Portrait Then
                    printDoc.DefaultPageSettings.Landscape = False
                End If
                printDoc.Print()
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub
        ''' <summary>
        ''' Handles the PrintPage event of the printDoc control.
        ''' </summary>
        ''' <param name="sender">The source of the event.</param>
        ''' <param name="e">The <see cref="System.Drawing.Printing.PrintPageEventArgs"/> instance containing the event data.</param>
        ''' <exception cref="Exception"></exception>
        Private Sub printDoc_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles printDoc.PrintPage

            Try

                Dim pageImage As New Metafile(m_streams(m_currentPageIndex))
                e.Graphics.DrawImage(pageImage, e.PageBounds)

                m_currentPageIndex += 1
                e.HasMorePages = (m_currentPageIndex < m_streams.Count)

            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub

        ''' <summary>
        ''' Subreports the processing handler.
        ''' </summary>
        ''' <param name="sender">The sender.</param>
        ''' <param name="e">The <see cref="Microsoft.Reporting.WinForms.SubreportProcessingEventArgs"/> instance containing the event data.</param>
        Private Sub SubreportProcessingHandler(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.SubreportProcessingEventArgs)
            RaiseEvent SubreportProcessing(sender, e)
        End Sub

        ''' <summary>
        ''' Drillthroughes the handler.
        ''' </summary>
        ''' <param name="sender">The sender.</param>
        ''' <param name="e">The <see cref="Microsoft.Reporting.WinForms.DrillthroughEventArgs"/> instance containing the event data.</param>
        Private Sub DrillthroughHandler(ByVal sender As Object, ByVal e As Microsoft.Reporting.WinForms.DrillthroughEventArgs) Handles NewrptViewer.Drillthrough

            RaiseEvent Drillthrough(sender, e)


        End Sub
        ''' <summary>
        ''' Enum PrintLayouts
        ''' </summary>
        Public Enum PrintLayouts
            ''' <summary>
            ''' The portrait
            ''' </summary>
            Portrait
            ''' <summary>
            ''' The landscape
            ''' </summary>
            Landscape
            ''' <summary>
            ''' The custom
            ''' </summary>
            Custom
        End Enum
        ''' <summary>
        ''' Enum PageUnits
        ''' </summary>
        Public Enum PageUnits
            ''' <summary>
            ''' The in
            ''' </summary>
            [in]
            ''' <summary>
            ''' The cm
            ''' </summary>
            cm
            ''' <summary>
            ''' The mm
            ''' </summary>
            mm
        End Enum

      
    End Class



End Namespace

