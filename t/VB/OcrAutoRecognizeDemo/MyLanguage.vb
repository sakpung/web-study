' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Globalization

' Language/Friendly name combo
Public Structure MyLanguage
   Public Language As String
   Public FriendlyName As String

   Public Sub New(ByVal l As String, ByVal f As String)
      Language = l
      FriendlyName = f
   End Sub

   Public Overrides Function ToString() As String
      Return FriendlyName
   End Function

   Public Shared Function GetLanguageFriendlyName(ByVal language As String) As String
      Dim ci As CultureInfo

      If language = "sr-Cyrl-CS" OrElse language = "sr-SP-Cyrl" Then
         ci = New CultureInfo(&HC1A)
      ElseIf language = "sr-Latn-CS" Then
         ci = New CultureInfo(&H81A)
      ElseIf language = "zh-Hans" Then
         ci = New CultureInfo(&H4)
      ElseIf language = "zh-Hant" Then
         ci = New CultureInfo(&H7C04)
      Else
         ci = New CultureInfo(language)
      End If

      Return ci.EnglishName
   End Function
End Structure
