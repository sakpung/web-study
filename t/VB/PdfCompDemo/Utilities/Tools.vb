' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Windows.Forms

Imports Leadtools

#If (Not LEADTOOLS_V17_OR_LATER) Then
Imports LeadPoint = System.Drawing.Point
Imports LeadSize = System.Drawing.Size
Imports LeadRect = System.Drawing.Rectangle
#End If ' #if !LEADTOOLS_V17_OR_LATER

#If LEADTOOLS_V17_OR_LATER Then
Imports Leadtools.Drawing
#End If ' #if LEADTOOLS_V17_OR_LATER

Public NotInheritable Class Tools
   Private Sub New()
   End Sub

   Public Shared Function ShowColorDialog(ByVal owner As IWin32Window, ByRef color As RasterColor) As Boolean
      Dim dlg As ColorDialog = New ColorDialog()
      dlg.AllowFullOpen = True
      dlg.AnyColor = True
      dlg.Color = Leadtools.Demos.Converters.ToGdiPlusColor(color)
      Dim res As DialogResult = dlg.ShowDialog(owner)
      If res = System.Windows.Forms.DialogResult.OK Then
         color = Leadtools.Demos.Converters.FromGdiPlusColor(dlg.Color)
      End If

      Return res = System.Windows.Forms.DialogResult.OK
   End Function

   Public Shared Function CanDrop(ByVal data As IDataObject) As Boolean
      Return data.GetDataPresent(DataFormats.Text) OrElse data.GetDataPresent(DataFormats.FileDrop)
   End Function

   Public Shared Function GetDropFiles(ByVal data As IDataObject) As String()
      If data.GetDataPresent(DataFormats.Text) Then
         Dim files As String() = New String(0) {}
         files(0) = TryCast(data.GetData(DataFormats.Text), String)
         Return files
      ElseIf data.GetDataPresent(DataFormats.FileDrop) Then
         Dim files As String() = TryCast(data.GetData(DataFormats.FileDrop), String())
         Return files
      End If

      Return Nothing
   End Function
End Class

