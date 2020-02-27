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

Namespace OcrDemo
   Public Class ZoneAnnotationObject
      Inherits AnnRectangleObject
      Private _zoneIndex As Integer
      Private _ocrPage As IOcrPage
      Private _cellPen As AnnStroke
      Private mylabel As AnnLabel

      Public Sub New()
         MyBase.New()
         _ocrPage = Nothing
         _zoneIndex = 0
         _cellPen = Nothing
         SetId(AnnObject.UserObjectId)

         mylabel = Me.Labels("AnnObjectName")
         mylabel.Background = AnnSolidColorBrush.Create("Black")
         mylabel.Foreground = AnnSolidColorBrush.Create("White")
         mylabel.RestrictionMode = AnnLabelRestriction.None
         mylabel.IsVisible = True
      End Sub

      Public Sub SetZone(ocrPage As IOcrPage, zoneIndex As Integer, isVisible__1 As Boolean, isNameVisible As Boolean)
         _ocrPage = ocrPage
         _zoneIndex = zoneIndex

         IsVisible = isVisible__1
         mylabel.IsVisible = isNameVisible

         If _ocrPage IsNot Nothing AndAlso _zoneIndex >= 0 AndAlso _zoneIndex < _ocrPage.Zones.Count Then
            Dim zone As OcrZone = _ocrPage.Zones(_zoneIndex)
            If String.IsNullOrEmpty(zone.Name) Then
               mylabel.Text = "Zone " & (_zoneIndex + 1).ToString()
            Else
               mylabel.Text = zone.Name
            End If

            If zone.ZoneType = OcrZoneType.None OrElse zone.ZoneType = OcrZoneType.Graphic OrElse zone.ZoneType = OcrZoneType.Barcode Then
               Dim color__2 As RasterColor = RasterColorConverter.FromColor(Color.FromArgb(32, Color.Yellow))
               Me.Fill = AnnSolidColorBrush.Create(color__2.ToString())
               'Color.FromArgb(32, Color.Yellow)
               Me.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Blue"), New LeadLengthD(1))
            Else
               Me.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Red"), New LeadLengthD(1))

            End If
         End If
      End Sub

      Public Sub ClearTableCells()
         If _ocrPage IsNot Nothing AndAlso _zoneIndex >= 0 AndAlso _ocrPage.Zones IsNot Nothing AndAlso _zoneIndex < _ocrPage.Zones.Count Then
            Dim zone As OcrZone = _ocrPage.Zones(_zoneIndex)
            Dim cells As OcrZoneCell() = Nothing

            cells = _ocrPage.Zones.GetZoneCells(zone)

            If cells IsNot Nothing Then
               _ocrPage.Zones.SetZoneCells(zone, Nothing)
            End If
         End If
      End Sub

      Public ReadOnly Property ZoneIndex() As Integer
         Get
            Return _zoneIndex
         End Get
      End Property

      Public Property CellPen() As AnnStroke
         Get
            Return _cellPen
         End Get
         Set(value As AnnStroke)
            _cellPen = value
         End Set
      End Property

      Public Property Label() As AnnLabel
         Get
            Return mylabel
         End Get
         Set(value As AnnLabel)
            mylabel = value
         End Set
      End Property

      Protected Overrides Function Create() As AnnObject
         Return New ZoneAnnotationObject()
      End Function

      Public Overrides Function Clone() As AnnObject
         Dim obj As ZoneAnnotationObject = TryCast(MyBase.Clone(), ZoneAnnotationObject)
         obj._ocrPage = _ocrPage
         obj._zoneIndex = _zoneIndex
         obj.CellPen = If(CellPen IsNot Nothing, TryCast(CellPen.Clone(), AnnStroke), Nothing)

         Return obj
      End Function
   End Class
End Namespace
