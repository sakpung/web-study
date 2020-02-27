' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Text
Imports System.Diagnostics
Imports System.Windows.Forms
Imports System.Drawing
Imports Microsoft.VisualBasic
Imports System.Runtime.InteropServices


Namespace Leadtools.DicomDemos
    Public Class TextBoxTraceListener : Inherits TraceListener
        Private _TextBox As RichTextBox = Nothing

        <DllImport("user32.dll")> _
        Public Shared Function SendMessage(ByVal window As IntPtr, ByVal message As Integer, ByVal wparam As Integer, ByVal lparam As Integer) As IntPtr
        End Function
        Public Const WM_VSCROLL As Integer = &H115
        Public Const SB_BOTTOM As Integer = 7

        Public Delegate Sub AddTextDelegate(ByVal text As String)

        Public Sub New(ByVal textbox As RichTextBox)
            _TextBox = textbox
        End Sub

        Public Overrides Sub WriteLine(ByVal message As String)
            If _TextBox.InvokeRequired Then
                _TextBox.Invoke(New AddTextDelegate(AddressOf WriteLine), message)
                Return
            End If

            Dim oldColor As Color = _TextBox.SelectionColor
            Dim lines As String() = message.Split(New Char() {ControlChars.Cr}, StringSplitOptions.RemoveEmptyEntries)

            _TextBox.SelectionLength = 0
            _TextBox.SelectionStart = _TextBox.Text.Length
            _TextBox.SelectionColor = Color.Green
            _TextBox.SelectionFont = New Font(_TextBox.SelectionFont, FontStyle.Bold)

            _TextBox.AppendText(lines(0))
            _TextBox.SelectionFont = New Font(_TextBox.SelectionFont, FontStyle.Regular)
            Dim i As Integer = 1
            Do While i < lines.Length - 1
                _TextBox.AppendText(lines(i))
                SendMessage(_TextBox.Handle, WM_VSCROLL, SB_BOTTOM, 0)
                i += 1
            Loop
            _TextBox.AppendText(Constants.vbCrLf)
            _TextBox.SelectionColor = oldColor
        End Sub

        Public Overrides Sub Write(ByVal message As String)
            WriteLine(message)
        End Sub
    End Class
End Namespace
