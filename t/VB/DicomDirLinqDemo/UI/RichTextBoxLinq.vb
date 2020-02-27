' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Text.RegularExpressions

Namespace CSLinqDicomDirDemo.UI
    Public Class RichTextBoxLinq
        Inherits RichTextBox

		Private _Keywords As New Dictionary(Of String,Color)() { {"from",Color.Blue}, {"select",Color.Blue}, {"where",Color.Blue}, {"in",Color.Blue }, {"PatientBase",Color.Green}, {"StudyBase",Color.Green}, {"SeriesBase",Color.Green}, {"ImageBase",Color.Green} }

        Private Const WM_SETREDRAW As Integer = &HB

        <DllImport("User32")> _
        Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As Integer, ByVal wParam As Integer, ByVal lParam As Integer) As Boolean
        End Function

        <DllImport("User32.dll")> _
        Private Shared Function SendMessage(ByVal hWnd As IntPtr, ByVal msg As UInteger, ByVal wParam As IntPtr, ByVal lParam As IntPtr) As Integer
        End Function

        Public Sub New()
            MyBase.New()
            AddHandler TextChanged, AddressOf RichTextBoxLinq_TextChanged
        End Sub

        Private Sub Freeze()
            SendMessage(Handle, WM_SETREDRAW, 0, 0)
        End Sub

        Private Sub Unfreeze()
            SendMessage(Handle, WM_SETREDRAW, 1, 0)
            Invalidate(True)
        End Sub

        Private Sub RichTextBoxLinq_TextChanged(ByVal sender As Object, ByVal e As EventArgs)
            HighLight()
        End Sub

        Public Sub HighLight()
            Dim RegExp As MatchCollection = Nothing
            Dim startPosition As Integer = SelectionStart

            Freeze()
            Try
                For Each keyword As String In _Keywords.Keys
                    RegExp = Regex.Matches(Text, "\b" & keyword & "\b", RegexOptions.IgnoreCase Or RegexOptions.Singleline)
                    For Each match As Match In RegExp
                        Try
							Select(match.Index, match.Length)
							SelectionColor = _Keywords(keyword)
							SelectionStart = startPosition
							SelectionColor = Color.Black
						Catch
                        End Try
					Next match
				Next keyword
			Finally
				Unfreeze()
            End Try
        End Sub
    End Class
End Namespace
