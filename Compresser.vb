' ***********************************************************************
' Assembly         : Dev++
' Author           : Annael Samwel
' Created          : 08-18-2014
'
' Last Modified By : user
' Last Modified On : 11-27-2011
' ***********************************************************************
' <copyright file="Compresser.vb" company="Annael">
'     Copyright © Annael 2010
' </copyright>
' <summary></summary>
' ***********************************************************************
Imports System
Imports System.IO
Imports System.IO.Compression
Imports System.Security.Cryptography
Imports System.Text
Imports Devpp.Global

''' <summary>
''' The Common namespace.
''' </summary>
Namespace Common
    ''' <summary>
    ''' This class used to manage Compress/Decompress Files
    ''' Devppelioped By Annael Samwel 03/2010
    ''' </summary>
    Public Class Compresser

        ''' <summary>
        ''' Key for encypting or Decrypting
        ''' </summary>
        Private Const Key As String = "ASRM1519"
        ''' <summary>
        ''' The filed for output file
        ''' </summary>
        Private _outFile As String
        ''' <summary>
        ''' Table for storing information of the file before compressing
        ''' </summary>
        Private dtTable As New DataTable("dtCompression")
        ''' <summary>
        ''' Name of the file
        ''' </summary>
        Private GetFileName As String
        ''' <summary>
        ''' Original Length of the file
        ''' </summary>
        Private FileLength As Long
        ''' <summary>
        ''' Password stored in the file after compressing
        ''' will be used for decompressing
        ''' </summary>
        Private _Password As String = "xxxx"
        ''' <summary>
        ''' The _ file password
        ''' </summary>
        Private _FilePassword As String
        ''' <summary>
        ''' Stores the value for allowing password restriction
        ''' </summary>
        Private _Overrider As Boolean = False
        ''' <summary>
        ''' The year1
        ''' </summary>
        Friend Shared Year1 As String = "2"
        ''' <summary>
        ''' This used to diplay password in the file
        ''' </summary>
        ''' <returns>System.String.</returns>
        Public Function GetfilePassword() As String
            Return _FilePassword
        End Function
        ''' <summary>
        ''' Is the writeonly property used to set password in a file
        ''' </summary>
        ''' <value>The password.</value>
        Public WriteOnly Property Password() As String

            Set(ByVal value As String)

                _Password = value
            End Set
        End Property
        ''' <summary>
        ''' This is the writeonly property used to set true for file contain password and false for file
        ''' do not contain password.
        ''' </summary>
        ''' <value><c>true</c> if overrider; otherwise, <c>false</c>.</value>
        Public WriteOnly Property Overrider() As Boolean
            Set(ByVal value As Boolean)
                _Overrider = value
            End Set
        End Property
        ''' <summary>
        ''' This is the get propery used to return out file after compress or dicompress
        ''' </summary>
        ''' <value>The out file.</value>
        Public ReadOnly Property OutFile() As String
            Get
                Return _outFile
            End Get
        End Property
        ''' <summary>
        ''' Initializes a new instance of the <see cref="Compresser"/> class.
        ''' </summary>
        ''' <exception cref="System.Exception">Devpp DLL not registered</exception>
        Public Sub New()

            If Not DLLRegistered Then
                Throw New Exception("Devpp DLL not registered")
            End If
            dtTable.Columns.Add("FileName", GetType(String))
            dtTable.Columns.Add("FileLeng", GetType(Long))
            dtTable.Columns.Add("Password", GetType(String))
            dtTable.Columns.Add("Overrider", GetType(Boolean))
            dtTable.Columns.Add("Value", GetType(Byte()))
        End Sub
        ''' <summary>
        ''' Gets the file.
        ''' </summary>
        ''' <param name="fileName">Name of the file.</param>
        ''' <returns>System.Byte().</returns>
        ''' <exception cref="System.Exception"></exception>
        Private Function GetFile(ByVal fileName As String) As Byte()
            Try

                Dim fileInf As New FileInfo(fileName)
                GetFileName = fileInf.Name


                Dim strem As New StreamReader(fileName)
                Dim str As String = strem.ReadToEnd
                strem.Close()
                Dim objEncod As Encoding = Encoding.ASCII
                Dim objByte As Byte() = objEncod.GetBytes(str)
                FileLength = objByte.Length
                Return objByte
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function
        ''' <summary>
        ''' Method for Encrypting Data
        ''' </summary>
        ''' <param name="Data">Data to be encrypted</param>
        ''' <param name="outFile">Output file aftrer encription</param>
        ''' <exception cref="System.Exception"></exception>
        Private Sub Encrypt(ByVal Data As Byte(), ByVal outFile As String)
            Try
                Dim DESalg As New System.Security.Cryptography.DESCryptoServiceProvider

                Dim objEncod As Encoding = Encoding.ASCII
                DESalg.Key = objEncod.GetBytes(Key)
                DESalg.IV = objEncod.GetBytes("11110000")
                Dim outStream As New FileStream(outFile, FileMode.Create, FileAccess.Write)

                Dim CryFile As New CryptoStream(outStream, DESalg.CreateEncryptor(DESalg.Key, DESalg.IV), CryptoStreamMode.Write)
                CryFile.Write(Data, 0, Data.Length)

                CryFile.Close()
                outStream.Close()
                _outFile = outFile

            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Sub
        ''' <summary>
        ''' Compresses files
        ''' </summary>
        ''' <param name="filename">The filename.</param>
        Public Sub Compress(ByVal filename As String)
            Try
                Dim fileInfo As New FileInfo(filename)
                Dim directory As String = IIf(fileInfo.DirectoryName.EndsWith("\"), fileInfo.DirectoryName, fileInfo.DirectoryName & "\")
                Dim CurrentfileName As String = fileInfo.Name.Replace(fileInfo.Extension, "")
                GetFileName = fileInfo.Name
                Dim infs As New FileStream(filename, FileMode.Open, FileAccess.Read)
                Dim SourceBuf(fileInfo.Length) As Byte
                infs.Read(SourceBuf, 0, SourceBuf.Length)
                infs.Close()
                FileLength = SourceBuf.Length
                Dim TempLocation As String = IIf(My.Computer.FileSystem.SpecialDirectories.Temp.EndsWith("\"), My.Computer.FileSystem.SpecialDirectories.Temp, My.Computer.FileSystem.SpecialDirectories.Temp & "\")
                Dim ms As New FileStream(TempLocation & "Tempostrem", FileMode.Create)
                Dim compressedzipStream As New IO.Compression.GZipStream(ms, CompressionMode.Compress)
                compressedzipStream.Write(SourceBuf, 0, SourceBuf.Length)
                compressedzipStream.Close()
                ms.Close()
                Dim TempStream As New FileStream(TempLocation & "Tempostrem", FileMode.Open, FileAccess.Read)
                Dim fileInfor As New FileInfo(TempLocation & "Tempostrem")
                Dim buf2(fileInfor.Length) As Byte
                TempStream.Read(buf2, 0, buf2.Length)
                TempStream.Close()
                My.Computer.FileSystem.DeleteFile(TempLocation & "Tempostrem")
                dtTable.Rows.Clear()
                dtTable.Rows.Add(GetFileName, FileLength, _Password, _Overrider, buf2)

                Dim fel As String = IIf(My.Computer.FileSystem.SpecialDirectories.Temp.EndsWith("\"), My.Computer.FileSystem.SpecialDirectories.Temp & Guid.NewGuid.ToString, _
                                        My.Computer.FileSystem.SpecialDirectories.Temp & "\" & Guid.NewGuid.ToString)
                dtTable.WriteXml(fel)
                Dim fileInform As New FileInfo(fel)

                Dim buff2(fileInform.Length) As Byte
                Dim fsTemp As New FileStream(fel, FileMode.Open, FileAccess.Read)
                fsTemp.Read(buff2, 0, buff2.Length)
                fsTemp.Close()
                My.Computer.FileSystem.DeleteFile(fel)

                Encrypt(buff2, directory & CurrentfileName & ".EZP")


            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub
        ''' <summary>
        ''' Method for Decripting file
        ''' </summary>
        ''' <param name="inFile">The in file.</param>
        ''' <exception cref="System.Exception"></exception>
        Private Sub Decrypt(ByVal inFile As String)
            Try
                dtTable.Rows.Clear()
                Dim DESalg As New DESCryptoServiceProvider
                Dim fs As New FileStream(inFile, FileMode.Open)
                Dim objEncod As Encoding = Encoding.ASCII
                DESalg.IV = objEncod.GetBytes("11110000")
                DESalg.Key = objEncod.GetBytes(Key)
                Dim cryp As New CryptoStream(fs, DESalg.CreateDecryptor(DESalg.Key, DESalg.IV), CryptoStreamMode.Read)
                dtTable.ReadXml(cryp)


                cryp.Close()
                fs.Close()


            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try


        End Sub
        ''' <summary>
        ''' The function used to dicompress the file returns true if the dicompress aither false for
        ''' unsuccesifuly dicompression
        ''' </summary>
        ''' <param name="filename">The filename.</param>
        ''' <param name="isLoging">if set to <c>true</c> [is loging].</param>
        ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        ''' <exception cref="System.Exception"></exception>
        Public Function Uncompress(ByVal filename As String, Optional ByVal isLoging As Boolean = False) As Boolean
            Try

                Decrypt(filename) 'This Method encrypts Data
                Dim objfileInf As New FileInfo(filename)

                Dim Directory As String = IIf(objfileInf.DirectoryName.EndsWith("\"), objfileInf.DirectoryName, objfileInf.DirectoryName & "\")
                If dtTable.Rows.Count > 0 Then
                    Dim pass As String = dtTable.Rows(0)("Password")
                    Dim bool As Boolean = dtTable.Rows(0)("Overrider")
                    If Not isLoging Then
                        If bool = True And IIf(Devpp.Common.Login.UserName Is Nothing, "", Devpp.Common.Login.UserName.ToUpper) <> "Devpp" Then
                            Dim V_string As String = _Password
                            If _Password = "" Then
                                Dim frm As New frmFilePassword
                                frm.ShowDialog()
                                V_string = frm.txtPassword.Text
                            End If
                            If V_string <> pass Then
                                MsgBox("Wrong password!", MsgBoxStyle.Information, My.Application.Info.Title)
                                Return False
                            End If
                        End If
                        If Devpp.Common.Login.UserName.ToUpper <> "Devpp" Then
                            _FilePassword = pass
                        End If
                    Else
                        If bool = True Then
                            Dim V_string As String = _Password
                            If _Password = "" Then
                                Dim frm As New frmFilePassword
                                frm.ShowDialog()
                                V_string = frm.txtPassword.Text
                            End If
                            If V_string <> pass Then
                                MsgBox("Wrong password!", MsgBoxStyle.Information, My.Application.Info.Title)
                                Return False
                            End If
                        End If
                    End If
                   

                Else
                    MsgBox("Cannot read the file", MsgBoxStyle.Information, My.Application.Info.Title)
                    Return False
                End If
                Dim TempLocation As String = IIf(My.Computer.FileSystem.SpecialDirectories.Temp.EndsWith("\"), My.Computer.FileSystem.SpecialDirectories.Temp, My.Computer.FileSystem.SpecialDirectories.Temp & "\")
                Dim FName As String = dtTable.Rows(0)("FileName")
                Dim FLength As Long = dtTable.Rows(0)("FileLeng")
                Dim byt As Byte() = dtTable.Rows(0)("Value")
                Dim tempstr As New FileStream(TempLocation & "Mytep1", FileMode.Create, FileAccess.Write)
                tempstr.Write(byt, 0, byt.Length)
                tempstr.Close()
                Dim memoStr As New IO.FileStream(TempLocation & "Mytep1", FileMode.Open)

                Dim decompre As New GZipStream(memoStr, CompressionMode.Decompress)
                Dim newBuff(FLength) As Byte
                Dim st As String = ""

                decompre.Read(newBuff, 0, newBuff.Length)
                decompre.Close()
                memoStr.Close()
                Dim outStream As New FileStream(Directory & FName, FileMode.Create, FileAccess.Write)
                outStream.Write(newBuff, 0, FLength)
                outStream.Close()
                _outFile = Directory & FName
                Return True
            Catch ex As Exception
                Throw New Exception(ex.Message)
            End Try
        End Function
    End Class
End Namespace

