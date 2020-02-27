' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System.Collections.Generic
Imports System.Text
Imports System.Runtime.Serialization
Imports System.Drawing
Imports System.Drawing.Drawing2D

Imports Leadtools
Imports Leadtools.Ocr
Imports Leadtools.Drawing
Imports Leadtools.Annotations.Engine
Imports Leadtools.Annotations.Designers
Imports System

Namespace OcrDemo
   Public Class ZoneAnnotationObjectEditDesigner
      Inherits AnnRectangleEditDesigner
      Public Sub New(automationControl As IAnnAutomationControl, container As AnnContainer, zoneAnnotationObject As ZoneAnnotationObject)
         MyBase.New(automationControl, container, zoneAnnotationObject)
      End Sub

      Protected Overrides Sub Move(offsetX As Double, offsetY As Double)
         TryCast(Me.TargetObject, ZoneAnnotationObject).ClearTableCells()
         MyBase.Move(offsetX, offsetY)
      End Sub

      Protected Overrides Sub MoveThumb(controlPointIndex As Integer, pt As LeadPointD)
         Dim locations As LeadPointD() = GetThumbLocations()

         ' This event gets fired event on small fraction differences so we are giving the user some margin to 
         ' be able to select the control point without deleting the table cells
         If (locations(controlPointIndex).X <> pt.X AndAlso Math.Abs(locations(controlPointIndex).X - pt.X) > 1) OrElse (locations(controlPointIndex).Y <> pt.Y AndAlso Math.Abs(locations(controlPointIndex).Y - pt.Y) > 1) Then
            TryCast(Me.TargetObject, ZoneAnnotationObject).ClearTableCells()
         End If
         MyBase.MoveThumb(controlPointIndex, pt)
      End Sub

   End Class
End Namespace
