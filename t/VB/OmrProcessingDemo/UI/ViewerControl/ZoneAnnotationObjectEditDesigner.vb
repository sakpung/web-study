Imports System
Imports System.Collections.Generic
Imports System.Text
Imports System.Runtime.Serialization
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Leadtools
Imports Leadtools.Forms.Common
Imports Leadtools.Ocr
Imports Leadtools.Drawing
Imports Leadtools.Annotations.Engine
Imports Leadtools.Annotations.Designers

Public Class ZoneAnnotationObjectEditDesigner
   Inherits AnnRectangleEditDesigner

   Public Sub New(ByVal automationControl As IAnnAutomationControl, ByVal container As AnnContainer, ByVal zoneAnnotationObject As ZoneAnnotationObject)
      MyBase.New(automationControl, container, zoneAnnotationObject)
   End Sub

   Protected Overrides Sub Move(ByVal offsetX As Double, ByVal offsetY As Double)
      TryCast(Me.TargetObject, ZoneAnnotationObject).ClearTableCells()
      MyBase.Move(offsetX, offsetY)
   End Sub

   Protected Overrides Sub MoveThumb(ByVal controlPointIndex As Integer, ByVal pt As LeadPointD)
      Dim locations As LeadPointD() = GetThumbLocations()

      If (locations(controlPointIndex).X <> pt.X AndAlso Math.Abs(locations(controlPointIndex).X - pt.X) > 1) OrElse (locations(controlPointIndex).Y <> pt.Y AndAlso Math.Abs(locations(controlPointIndex).Y - pt.Y) > 1) Then
         TryCast(Me.TargetObject, ZoneAnnotationObject).ClearTableCells()
      End If

      MyBase.MoveThumb(controlPointIndex, pt)
   End Sub
End Class
