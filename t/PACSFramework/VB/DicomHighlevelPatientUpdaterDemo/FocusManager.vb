' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms

Namespace DicomDemo
   Public Class FocusManager
      Private _Controls As List(Of Control) = New List(Of Control)()

      Public Sub New(ByVal ParamArray textboxes As Control())
         For Each textbox As Control In textboxes
            AddHandler textbox.KeyDown, AddressOf textbox_KeyDown
            _Controls.Add(textbox)
         Next textbox
      End Sub

      Private Sub textbox_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
         If e.KeyCode = Keys.Enter Then
            Dim index As Integer = _Controls.IndexOf(TryCast(sender, Control))
            Dim focused As Boolean = False

            Do While Not focused
               Dim controlToFocus As Control
               If (index + 1) = _Controls.Count Then
                  controlToFocus = _Controls(0)
               Else
                  controlToFocus = _Controls(index + 1)
               End If

               If controlToFocus.Enabled Then
                  controlToFocus.Focus()
                  Exit Do
               End If

               index += 1
               If index = _Controls.Count Then
                  index = 0
               End If
            Loop
         End If
      End Sub
   End Class
End Namespace
