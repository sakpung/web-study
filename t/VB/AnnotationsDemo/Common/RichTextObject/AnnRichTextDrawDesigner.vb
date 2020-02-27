' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports Leadtools.Annotations.Engine
Imports System.Collections.Generic
Imports System.Text
Imports Leadtools.Annotations.Designers

Public Class AnnRichDrawDesigner
   Inherits AnnRectangleDrawDesigner
   Private _richTextEditor As RichTextBoxEditor = Nothing
   Public Sub New(automationControl As IAnnAutomationControl, container As AnnContainer, annRichTextObject As AnnRichTextObject)
      MyBase.New(automationControl, container, annRichTextObject)
      _richTextEditor = New RichTextBoxEditor(automationControl, TargetObject, container)
   End Sub

   Public Overrides Function OnPointerUp(sender As AnnContainer, e As AnnPointerEventArgs) As Boolean
      Dim handled As Boolean = MyBase.OnPointerUp(sender, e)

      _richTextEditor.ShowRichTextDialog(TryCast(TargetObject, AnnRichTextObject))
      Return handled
   End Function
End Class
