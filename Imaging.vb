' ***********************************************************************
' Assembly         : Dev++
' Author           : Annael Samwel
' Created          : 08-18-2014
'
' Last Modified By : user
' Last Modified On : 09-08-2011
' ***********************************************************************
' <copyright file="Imaging.vb" company="Annael">
'     '     Copyright © Annael 2010
'
' </copyright>
' <summary></summary>
' *************************************************************************

''' <summary>
''' The Common namespace.
''' </summary>
Namespace Common
    ''' <summary>
    ''' This class used to manage imaging
    ''' This Class created by Annael Samwel 5/2010
    ''' </summary>
    Public NotInheritable Class Imaging
        Inherits Object
        ''' <summary>
        ''' The insert query
        ''' </summary>
        Private Const INSERTQuery As String = "INSERT INTO [tblImage] ([ImageValue],isImage,ImageDescription) VALUES (@ImageValue, 1 ,@ImageDescription) "
        ''' <summary>
        ''' The insert query bin
        ''' </summary>
  Private Const INSERTQueryBin As String = "INSERT INTO [tblImage] ([ImageValue],isImage,ImageDescription) VALUES (@ImageValue, 0 ,@ImageDescription) "

        ''' <summary>
        ''' The select query
        ''' </summary>
Private Const SELECTQuery As String = "SELECT [ImageValue] FROM [tblImage] WHERE [ImageID] = @ImageID "
        ''' <summary>
        ''' The select all query
        ''' </summary>
        Private Const SELECTAllQuery As String = "SELECT [ImageValue] FROM [tblImage] WHERE [ImageID] = @ImageID "
        ''' <summary>
        ''' The delete query
        ''' </summary>
        Private Const DELETEQuery As String = "DELETE FROM [tblImage] WHERE [ImageID] = @ImageID "
        ''' <summary>
        ''' The selecti mage identifier
        ''' </summary>
        Private Const SELECTIMageID As String = "SELECT MAX(ImageID) AS ID FROM [tblImage]"
        ''' <summary>
        ''' The select all image ids
        ''' </summary>
        Private Const SELECTAllImageIds As String = "SELECT  [ImageID],[ImageValue],[ImageDescription] FROM [tblImage]WHERE isImage = 1"
        ''' <summary>
        ''' The updatequery
        ''' </summary>
        Private Const UPDATEQUERY As String = "UPDATE [tblImage] SET ImageDescription = @ImageDescription WHERE [ImageID] = @ImageID"
        ''' <summary>
        ''' The _ control
        ''' </summary>
        Private _Control As New System.Windows.Forms.Control
        ''' <summary>
        ''' The _ new image identifier
        ''' </summary>
        Private _NewImageID As Integer = Nothing
        ''' <summary>
        ''' The DTBL image list
        ''' </summary>
        Private dtblImageList As New DataTable
        ''' <summary>
        ''' The Get Property returns the ID of image after inserting an Image
        ''' </summary>
        ''' <value>The new image identifier.</value>
        Public ReadOnly Property NewImageID() As Integer
            Get
                Return _NewImageID
            End Get
        End Property
        ''' <summary>
        ''' Control for displaying image
        ''' </summary>
        ''' <value>The control.</value>
        Public Property Control() As System.Windows.Forms.Control
            Get
                Return _Control
            End Get
            Set(ByVal value As System.Windows.Forms.Control)
                _Control = value
            End Set
        End Property
        ''' <summary>
        ''' Gets the image list.
        ''' </summary>
        ''' <value>The image list.</value>
        Public ReadOnly Property ImageList() As DataTable
            Get
                Return dtblImageList
            End Get
        End Property
        ''' <summary>
        ''' The img buff
        ''' </summary>
        Private imgBuff As Byte()
        ''' <summary>
        ''' Insert image in the database
        ''' </summary>
        Public Sub FillImageList()

            Dim con As New SqlClient.SqlConnection(Data.SQLSERVER.ImageConnectionString)
            Try
                Dim com As New SqlClient.SqlCommand(SELECTAllImageIds, con)
                con.Open()
                com.ExecuteNonQuery()
                con.Close()
                Dim Adapter As New SqlClient.SqlDataAdapter(com)
                dtblImageList.Clear()
                Adapter.Fill(dtblImageList)

            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
            End Try

        End Sub
        ''' <summary>
        ''' Updates the specified identifier.
        ''' </summary>
        ''' <param name="ID">The identifier.</param>
        ''' <param name="Description">The description.</param>
        ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        Public Function Update(ByVal ID As Integer, ByVal Description As String) As Boolean
            Dim con As New SqlClient.SqlConnection(Data.SQLSERVER.ImageConnectionString)
            Try
                Dim com As New SqlClient.SqlCommand(UPDATEQUERY, con)
                com.Parameters.Add("@ImageID", SqlDbType.Int).Value = ID
                com.Parameters.Add("@ImageDescription", SqlDbType.NVarChar).Value = Description
                con.Open()
                com.ExecuteNonQuery()
                con.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Function
        ''' <summary>
        ''' Inserts the image.
        ''' </summary>
        ''' <param name="value">The value.</param>
        ''' <param name="Description">The description.</param>
        ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        Public Function InsertImage(ByVal value As Byte(), Optional ByVal Description As String = "") As Boolean
            Dim con As New SqlClient.SqlConnection(Data.SQLSERVER.ImageConnectionString)
            Try
                Dim com As New SqlClient.SqlCommand(INSERTQuery, con)
                com.Parameters.Add("@ImageValue", SqlDbType.Binary).Value = value
                com.Parameters.Add("@ImageDescription", SqlDbType.NVarChar).Value = Description
                con.Open()
                com.ExecuteNonQuery()
                con.Close()
                Dim Adapter As New SqlClient.SqlDataAdapter(SELECTIMageID, con)
                Dim MyDataTable As New DataTable
                Adapter.Fill(MyDataTable)
                _NewImageID = MyDataTable.Rows(0)(0)
                Return True
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
            End Try
            Return False
        End Function
        ''' <summary>
        ''' Inserts the binary.
        ''' </summary>
        ''' <param name="value">The value.</param>
        ''' <param name="Description">The description.</param>
        ''' <returns><c>true</c> if XXXX, <c>false</c> otherwise.</returns>
        Public Function InsertBinary(ByVal value As Byte(), Optional ByVal Description As String = "") As Boolean
            Dim con As New SqlClient.SqlConnection(Data.SQLSERVER.ImageConnectionString)
            Try
                Dim com As New SqlClient.SqlCommand(INSERTQueryBin, con)
                com.Parameters.Add("@ImageValue", SqlDbType.Image).Value = value
                com.Parameters.Add("@ImageDescription", SqlDbType.NVarChar).Value = Description
                con.Open()
                com.ExecuteNonQuery()
                con.Close()
                Dim Adapter As New SqlClient.SqlDataAdapter(SELECTIMageID, con)
                Dim MyDataTable As New DataTable
                Adapter.Fill(MyDataTable)
                _NewImageID = MyDataTable.Rows(0)(0)
                Return True
            Catch ex As Exception
                con.Close()
                MsgBox(ex.Message)
            End Try
            Return False
        End Function
        ''' <summary>
        ''' Insert image in the database
        ''' </summary>
        ''' <param name="value">system.Drawing.Image</param>
        ''' <param name="Description">The description.</param>
        ''' <returns>Return true if succeded else false</returns>
        Public Function InsertImage(ByVal value As System.Drawing.Image, Optional ByVal Description As String = "") As Boolean
            Try
                Dim im As New System.Drawing.ImageConverter
                If im.CanConvertTo(GetType(Byte())) = True Then
                    Dim Val As Byte() = im.ConvertTo(value, GetType(Byte()))
                    Return InsertImage(Val, Description)
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try

        End Function
        ''' <summary>
        ''' Insert image in the database
        ''' </summary>
        ''' <param name="value">System.Windows.Forms.PictureBox (picture box contains image)</param>
        ''' <param name="Description">The description.</param>
        ''' <returns>Return true if succeded else false</returns>
        Public Function InsertImage(ByVal value As System.Windows.Forms.PictureBox, Optional ByVal Description As String = "") As Boolean
            Return InsertImage(value.Image, Description)
        End Function
        ''' <summary>
        ''' Insert image in the database
        ''' </summary>
        ''' <param name="value">Sream which reads the image</param>
        ''' <param name="Description">The description.</param>
        ''' <returns>Return true if succeded else false</returns>
        Public Function InsertImage(ByVal value As IO.Stream, Optional ByVal Description As String = "") As Boolean
            Try
                Dim buff(value.Length) As Byte
                value.Read(buff, 0, buff.Length)
                value.Close()
                Return InsertImage(buff, Description)
            Catch ex As Exception
                MsgBox(ex.Message)
                Return False
            End Try
        End Function
        ''' <summary>
        ''' Insert image in the database
        ''' </summary>
        ''' <param name="fileName">File location which contains image</param>
        ''' <param name="Description">The description.</param>
        ''' <returns>Return true if succeded else false</returns>
        Public Function InsertImage(ByVal fileName As String, Optional ByVal Description As String = "") As Boolean
            Try
                Dim fs As New IO.FileStream(fileName, IO.FileMode.Open)
                Return InsertImage(fs, Description)
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End Function

        ''' <summary>
        ''' Gets the binary.
        ''' </summary>
        ''' <param name="ID">The identifier.</param>
        ''' <returns>System.Byte().</returns>
        Public Function GetBinary(ByVal ID As Integer) As Byte()
            Try
                imgBuff = Nothing
                Dim con As New SqlClient.SqlConnection(Data.SQLSERVER.ImageConnectionString)
                Dim com As New SqlClient.SqlCommand(SELECTQuery, con)
                com.Parameters.Add("@ImageID", SqlDbType.Int).Value = ID
                Dim Adapter As New SqlClient.SqlDataAdapter(com)
                Dim DataTable As New System.Data.DataTable
                Adapter.Fill(DataTable)
                If DataTable.Rows.Count = 0 Then
                    Return Nothing
                End If
                Dim buff As Byte() = DataTable.Rows(0)(0)
                Return buff


            Catch ex As Exception

                Return Nothing
            End Try
            Return Nothing
        End Function
        ''' <summary>
        ''' Load image in from the database
        ''' </summary>
        ''' <param name="ID">ID of image in the database</param>
        ''' <returns>Image in memory if exists else nothing</returns>
        Public Function LoadImageFromDB(ByVal ID As Integer) As System.Drawing.Image
            Try
                imgBuff = Nothing
                Dim con As New SqlClient.SqlConnection(Data.SQLSERVER.ImageConnectionString)
                Dim com As New SqlClient.SqlCommand(SELECTQuery, con)
                com.Parameters.Add("@ImageID", SqlDbType.Int).Value = ID
                Dim Adapter As New SqlClient.SqlDataAdapter(com)
                Dim DataTable As New System.Data.DataTable
                Adapter.Fill(DataTable)
                If DataTable.Rows.Count = 0 Then
                    Return Nothing
                End If
                Dim buff As Byte() = DataTable.Rows(0)(0)

                Dim imConv As New System.Drawing.ImageConverter
                Dim newImage As System.Drawing.Image = imConv.ConvertFrom(buff)
                imgBuff = buff
                Return newImage
            Catch ex As Exception

                Return Nothing
            End Try
            Return Nothing
        End Function
        ''' <summary>
        ''' Function used to delete image in database
        ''' </summary>
        ''' <param name="ID">Id of Image</param>
        ''' <returns>Return true if succeded else false</returns>
        Public Function DeleteImage(ByVal ID As Integer) As Boolean
            Dim con As New SqlClient.SqlConnection(Data.SQLSERVER.ImageConnectionString)
            Try
                con.Open()
                Dim com As New SqlClient.SqlCommand(DELETEQuery, con)
                com.Parameters.Add("@ImageID", SqlDbType.Int).Value = ID
                com.ExecuteNonQuery()
                con.Close()
                Return True
            Catch ex As Exception
                MsgBox(ex.Message)
                con.Close()
                Return False
            End Try
            Return False
        End Function
        ''' <summary>
        ''' Display windows form conatian the image
        ''' </summary>
        ''' <param name="ID">ID of the image</param>
        Public Sub ShowDialog(ByVal ID As Integer)
            Try
                Dim frm As New Windows.Forms.Form
                frm.Text = "Image"
                frm.ShowIcon = False
                frm.ShowInTaskbar = False
                frm.StartPosition = Windows.Forms.FormStartPosition.CenterParent
                Dim imageBox As New System.Windows.Forms.PictureBox
                imageBox.SizeMode = Windows.Forms.PictureBoxSizeMode.StretchImage
                imageBox.BorderStyle = Windows.Forms.BorderStyle.Fixed3D
                imageBox.Dock = Windows.Forms.DockStyle.Fill
                imageBox.Image = LoadImageFromDB(ID)
                frm.Controls.Add(imageBox)
                frm.ShowDialog()

            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Sub
        ''' <summary>
        ''' Save image in stream
        ''' </summary>
        ''' <param name="stream">Stream for storing Image</param>
        ''' <param name="ID">Id of Image</param>
        ''' <returns>Returns true if image stored else false</returns>
        ''' <exception cref="Exception"></exception>
        Public Function SaveImage(ByVal stream As IO.Stream, ByVal ID As Integer) As Boolean
            If LoadImageFromDB(ID) Is Nothing Then Return False
            Try
                If imgBuff Is Nothing Then
                    Throw New Exception
                End If
                stream.Write(imgBuff, 0, imgBuff.Length)
                stream.Close()
                Return True
            Catch ex As Exception
                Return False
            End Try


        End Function
        ''' <summary>
        ''' Gets the bytes.
        ''' </summary>
        ''' <param name="ID">The identifier.</param>
        ''' <returns>System.Byte().</returns>
        Public Function GetBytes(ByVal ID As Integer) As Byte()
            imgBuff = Nothing
            Dim con As New SqlClient.SqlConnection(Data.SQLSERVER.ImageConnectionString)
            Dim com As New SqlClient.SqlCommand(SELECTQuery, con)
            com.Parameters.Add("@ImageID", SqlDbType.Int).Value = ID
            Dim Adapter As New SqlClient.SqlDataAdapter(com)
            Dim DataTable As New System.Data.DataTable
            Adapter.Fill(DataTable)
            If DataTable.Rows.Count = 0 Then
                Return Nothing
            End If
            Dim buff As Byte() = DataTable.Rows(0)(0)
            Try
                Return buff
            Catch ex As Exception
                Return Nothing
            End Try
        End Function
        ''' <summary>
        ''' Save image in the file location
        ''' </summary>
        ''' <param name="FileName">Location of the file the image to be saved</param>
        ''' <param name="ID">ID of image</param>
        ''' <returns>Returns true if image saved succesifully else false</returns>
        Public Function SaveImage(ByVal FileName As String, ByVal ID As Integer) As Boolean
            Try

                LoadImageFromDB(ID).Save(FileName)
                Return True
            Catch ex As Exception
                Return False
            End Try
        End Function
        ''' <summary>
        ''' Display image in the control
        ''' </summary>
        ''' <param name="ID">ID of image</param>
        Public Sub ShowImageToControl(ByVal ID As Integer)
            Dim imageBox As New System.Windows.Forms.PictureBox
            imageBox.SizeMode = Windows.Forms.PictureBoxSizeMode.StretchImage
            imageBox.BorderStyle = Windows.Forms.BorderStyle.Fixed3D
            imageBox.Dock = Windows.Forms.DockStyle.Fill
            imageBox.Image = LoadImageFromDB(ID)
            Me.Control.Controls.Add(imageBox)
        End Sub
        ''' <summary>
        ''' Initializes a new instance of the <see cref="Imaging" /> class.
        ''' </summary>
        ''' <exception cref="Exception">Exact DLL not registered</exception>
        Public Sub New()
           
            MyBase.New()
            If Not DLLRegistered Then
                Throw New Exception("Exact DLL not registered")
            End If
        End Sub
    End Class
End Namespace

