' ***********************************************************************
' Assembly         : Dev++
' Author           : Annael Samwel
' Created          : 08-18-2014
'
' Last Modified By : user
' Last Modified On : 04-22-2014
' ***********************************************************************
' <copyright file="Utility.vb" company="Annael">
'     Copyright © Annael 2010
' </copyright>
' <summary></summary>
' ***********************************************************************
''' <summary>
''' The Common namespace.
''' </summary>
Namespace Common
    ''' <summary>
    ''' Class Utility.
    ''' </summary>
    Public Class Utility
        ''' <summary>
        ''' The dt number
        ''' </summary>
        Private dtNumber As DataTable
        ''' <summary>
        ''' The dt number length
        ''' </summary>
        Private dtNumberLength As DataTable
        ''' <summary>
        ''' The return number
        ''' </summary>
        Private ReturnNumber As String = ""
        ''' <summary>
        ''' The jump
        ''' </summary>
        Private Shared Jump As Boolean
        ''' <summary>
        ''' The v_ list
        ''' </summary>
        Private V_List As New List(Of String)
        ''' <summary>
        ''' Initializes a new instance of the <see cref="Utility"/> class.
        ''' </summary>
        Public Sub New()

            dtNumber = New DataTable
            dtNumberLength = New DataTable
            dtNumber.Columns.Add("Number", GetType(Integer))
            dtNumber.Columns.Add("Desc", GetType(String))
            dtNumberLength.Columns.Add("Number", GetType(Integer))
            dtNumberLength.Columns.Add("Desc", GetType(String))
            dtNumber.Rows.Add(1, "One")
            dtNumber.Rows.Add(2, "Two")
            dtNumber.Rows.Add(3, "Three")
            dtNumber.Rows.Add(4, "Four")
            dtNumber.Rows.Add(5, "Five")
            dtNumber.Rows.Add(6, "Six")
            dtNumber.Rows.Add(7, "Seven")
            dtNumber.Rows.Add(8, "Eight")
            dtNumber.Rows.Add(9, "Nine")
            dtNumber.Rows.Add(10, "Ten")
            dtNumber.Rows.Add(20, "Twenty")
            dtNumber.Rows.Add(30, "Thirty")
            dtNumber.Rows.Add(40, "Forty")
            dtNumber.Rows.Add(50, "Fifty")
            dtNumber.Rows.Add(60, "Sixty")
            dtNumber.Rows.Add(70, "Seventy")
            dtNumber.Rows.Add(80, "Eighty")
            dtNumber.Rows.Add(90, "Ninety")
            dtNumber.Rows.Add(11, "Eleven")
            dtNumber.Rows.Add(12, "Twelve")
            dtNumber.Rows.Add(13, "Thirteen")
            dtNumber.Rows.Add(14, "Forteen")
            dtNumber.Rows.Add(15, "Fifteen")
            dtNumber.Rows.Add(16, "Sixteen")
            dtNumber.Rows.Add(17, "Seventeen")
            dtNumber.Rows.Add(18, "Eighteen")
            dtNumber.Rows.Add(19, "Nineteen")
            'dtNumberLength.Rows.Add(3, "Hundred")
            'dtNumberLength.Rows.Add(4, "Thousand")
            'dtNumberLength.Rows.Add(7, "Million")
            'dtNumberLength.Rows.Add(10, "Billion")
            'dtNumberLength.Rows.Add(13, "Trillion")
        End Sub

        ''' <summary>
        ''' Numbers to word.
        ''' </summary>
        ''' <param name="Number">The number.</param>
        ''' <returns>System.String.</returns>
        Public Function NumberToWord(ByVal Number As Double) As String
            Dim StNumber As String = Number
            Dim CharRemove As Integer = 0
            Jump = False
            For Each c As Char In StNumber
                If CInt(c.ToString) = 0 Then GoTo leb

                If CharRemove = 0 Then
                    GetNumberWord(StNumber)
                Else
                    GetNumberWord(Right(StNumber, StNumber.Length - CharRemove))
                End If

leb:
                CharRemove += 1

            Next
            ReturnNumber = ""
            For x As Integer = 0 To Me.V_List.Count - 1
                If V_List.Count - 1 = 0 Then
                    ReturnNumber = ReturnNumber & " " & V_List(x)
                Else
                    If x = V_List.Count - 1 Then
                        ReturnNumber = ReturnNumber & IIf(ReturnNumber.EndsWith("y"), " ", " and ") & V_List(x)
                    Else
                        If x = V_List.Count - 2 Then
                            If V_List(x).EndsWith("y") Then
                                ReturnNumber = ReturnNumber & IIf(ReturnNumber = "", "", " and ") & V_List(x)
                            Else
                                ReturnNumber = ReturnNumber & IIf(ReturnNumber = "", "", ",") & " " & V_List(x)
                            End If

                        Else
                            ReturnNumber = ReturnNumber & IIf(ReturnNumber = "", "", ",") & " " & V_List(x)
                        End If

                    End If
                End If

            Next
            Return ReturnNumber.Trim
        End Function
        ''' <summary>
        ''' Gets the number word.
        ''' </summary>
        ''' <param name="Number">The number.</param>
        Private Sub GetNumberWord(ByVal Number As Double)
            If Jump = True Then
                Jump = False
                Return
            End If
            Select Case Number.ToString.Length
                Case Is = 1



                    ReturnNumber = ReturnNumber & " " & dtNumber.Select("Number =" & Number)(0)(1)
                    V_List.Add(dtNumber.Select("Number =" & Number)(0)(1))
                Case Is = 2
                    Dim A As String = ""
                    If Number.ToString.EndsWith(0) Then
                        A = Number
                    Else
                        A = Left(Number.ToString, 1) & 0
                    End If
                    ReturnNumber = ReturnNumber & " " & dtNumber.Select("Number =" & A)(0)(1)
                    V_List.Add(dtNumber.Select("Number =" & A)(0)(1))
                Case Is = 3
                    ReturnNumber = ReturnNumber & " " & dtNumber.Select("Number =" & Left(Number.ToString, 1))(0)(1) & " Hundred"
                    V_List.Add(dtNumber.Select("Number =" & Left(Number.ToString, 1))(0)(1) & " Hundred" & EndWiths(dtNumber.Select("Number =" & Left(Number.ToString, 1))(0)(1)))
                Case Is = 4
                    ReturnNumber = ReturnNumber & " " & dtNumber.Select("Number =" & Left(Number.ToString, 1))(0)(1) & " Thousand"
                    V_List.Add(dtNumber.Select("Number =" & Left(Number.ToString, 1))(0)(1) & " Thousand" & EndWiths(dtNumber.Select("Number =" & Left(Number.ToString, 1))(0)(1)))
                Case Is = 5
                    Dim N As String = Left(Number.ToString, 2)
                    If Left(N, 1) = 1 Then
                        N = dtNumber.Select("Number =" & N)(0)(1)
                    Else
                        If Right(N, 1) > 0 Then
                            N = dtNumber.Select("Number =" & Left(N, 1) & "0")(0)(1) & " " & dtNumber.Select("Number =" & Right(N, 1))(0)(1)
                        Else
                            N = dtNumber.Select("Number =" & Left(N, 1) & "0")(0)(1)
                        End If

                    End If

                    ReturnNumber = ReturnNumber & " " & N & " Thousand"
                    V_List.Add(N & " Thousand" & EndWiths(N))
                    Jump = True
                Case Is = 6
                    ReturnNumber = ReturnNumber & " " & dtNumber.Select("Number =" & Left(Number.ToString, 1))(0)(1) & " Hundred Thousand"
                    V_List.Add(dtNumber.Select("Number =" & Left(Number.ToString, 1))(0)(1) & " Hundred Thousand" & EndWiths(dtNumber.Select("Number =" & Left(Number.ToString, 1))(0)(1)))
                Case Is = 7
                    ReturnNumber = ReturnNumber & " " & dtNumber.Select("Number =" & Left(Number.ToString, 1))(0)(1) & " Million"
                    V_List.Add(dtNumber.Select("Number =" & Left(Number.ToString, 1))(0)(1) & " Million" & EndWiths(dtNumber.Select("Number =" & Left(Number.ToString, 1))(0)(1)))
                Case Is = 8
                    Dim N As String = Left(Number.ToString, 2)
                    If Left(N, 1) = 1 Then
                        N = dtNumber.Select("Number =" & N)(0)(1)
                    Else
                        If Right(N, 1) > 0 Then
                            N = dtNumber.Select("Number =" & Left(N, 1) & "0")(0)(1) & " " & dtNumber.Select("Number =" & Right(N, 1))(0)(1)
                        Else
                            N = dtNumber.Select("Number =" & Left(N, 1) & "0")(0)(1)
                        End If

                    End If
                    ReturnNumber = ReturnNumber & " " & N & " Million"
                    V_List.Add(N & " Million" & EndWiths(N))
                    Jump = True
                Case Is = 9
                    ReturnNumber = ReturnNumber & " " & dtNumber.Select("Number =" & Left(Number.ToString, 1))(0)(1) & " Hundred Million"
                    V_List.Add(dtNumber.Select("Number =" & Left(Number.ToString, 1))(0)(1) & " Hundred Million" & EndWiths(dtNumber.Select("Number =" & Left(Number.ToString, 1))(0)(1)))
                Case Is = 10
                    ReturnNumber = ReturnNumber & " " & dtNumber.Select("Number =" & Left(Number.ToString, 1))(0)(1) & " Billion"
                    V_List.Add(dtNumber.Select("Number =" & Left(Number.ToString, 1))(0)(1) & " Billion" & EndWiths(dtNumber.Select("Number =" & Left(Number.ToString, 1))(0)(1)))
                Case Is = 11
                    Dim N As String = Left(Number.ToString, 2)
                    If Left(N, 1) = 1 Then
                        N = dtNumber.Select("Number =" & N)(0)(1)
                    Else
                        If Right(N, 1) > 0 Then
                            N = dtNumber.Select("Number =" & Left(N, 1) & "0")(0)(1) & " " & dtNumber.Select("Number =" & Right(N, 1))(0)(1)
                        Else
                            N = dtNumber.Select("Number =" & Left(N, 1) & "0")(0)(1)
                        End If

                    End If
                    ReturnNumber = ReturnNumber & " " & N & " Billion"
                    V_List.Add(N & " Billion" & EndWiths(N))
                    Jump = True
                Case Is = 12
                    ReturnNumber = ReturnNumber & " " & dtNumber.Select("Number =" & Left(Number.ToString, 1))(0)(1) & " Hundred Billion"
                    V_List.Add(dtNumber.Select("Number =" & Left(Number.ToString, 1))(0)(1) & " Hundred Billion" & EndWiths(dtNumber.Select("Number =" & Left(Number.ToString, 1))(0)(1)))
                Case Is = 13
                    ReturnNumber = ReturnNumber & " " & dtNumber.Select("Number =" & Left(Number.ToString, 1))(0)(1) & " Trillion"
                    V_List.Add(dtNumber.Select("Number =" & Left(Number.ToString, 1))(0)(1) & " Trillion" & EndWiths(dtNumber.Select("Number =" & Left(Number.ToString, 1))(0)(1)))
                Case Is = 14
                    Dim N As String = Left(Number.ToString, 2)
                    If Left(N, 1) = 1 Then
                        N = dtNumber.Select("Number =" & N)(0)(1)
                    Else
                        If Right(N, 1) > 0 Then
                            N = dtNumber.Select("Number =" & Left(N, 1) & "0")(0)(1) & " " & dtNumber.Select("Number =" & Right(N, 1))(0)(1)
                        Else
                            N = dtNumber.Select("Number =" & Left(N, 1) & "0")(0)(1)
                        End If

                    End If
                    ReturnNumber = ReturnNumber & " " & N & " Trillion"
                    V_List.Add(N & " Trillion" & EndWiths(N))
                    Jump = True
                Case Is = 15
                    ReturnNumber = ReturnNumber & " " & dtNumber.Select("Number =" & Left(Number.ToString, 1))(0)(1) & " Hundred Trillion"
                    V_List.Add(dtNumber.Select("Number =" & Left(Number.ToString, 1))(0)(1) & " Hundred Trillion" & EndWiths(dtNumber.Select("Number =" & Left(Number.ToString, 1))(0)(1)))
            End Select

        End Sub

        Private Function EndWiths(N As String) As String
            If N <> "One" Then
                Return "s"
            End If
            Return ""
        End Function
    End Class
End Namespace
