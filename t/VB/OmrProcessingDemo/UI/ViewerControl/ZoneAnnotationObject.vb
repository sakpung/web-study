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
Imports Leadtools.Forms.Processing.Omr.Fields
Imports Leadtools.Forms.Processing.Omr

Public Class ZoneAnnotationObject
   Inherits AnnRectangleObject

   Private _zoneIndex As Integer
   Private _ocrPage As Page
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

   Public Sub SetZone(ByVal ocrPage As Page, ByVal zoneIndex As Integer, ByVal isVisible As Boolean, ByVal isNameVisible As Boolean)
      _ocrPage = ocrPage
      _zoneIndex = zoneIndex
      isVisible = isVisible
      mylabel.IsVisible = isNameVisible

      If _ocrPage IsNot Nothing AndAlso _zoneIndex >= 0 AndAlso _zoneIndex < _ocrPage.Fields.Count Then
         Dim zone As Field = _ocrPage.Fields(_zoneIndex)

         If String.IsNullOrEmpty(zone.Name) Then
            mylabel.Text = "Zone " & (_zoneIndex + 1).ToString()
         Else
            mylabel.Text = zone.Name
         End If

         Me.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Red"), New LeadLengthD(1))
      End If
   End Sub

   Public Sub ClearTableCells()
   End Sub

   Public ReadOnly Property ZoneIndex As Integer
      Get
         Return _zoneIndex
      End Get
   End Property

   Public Property CellPen As AnnStroke
      Get
         Return _cellPen
      End Get
      Set(ByVal value As AnnStroke)
         _cellPen = value
      End Set
   End Property

   Public Property Label As AnnLabel
      Get
         Return mylabel
      End Get
      Set(ByVal value As AnnLabel)
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
