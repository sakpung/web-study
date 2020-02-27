' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.Svg
Imports Leadtools.Drawing
Imports System.Collections.Generic
Imports System.Drawing.Drawing2D
Imports System

Namespace SvgDemo
   Public Class Viewer
      Inherits Control
      Public Sub New()
         Dim styles As ControlStyles = ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw Or ControlStyles.UserPaint
         SetStyle(styles, True)
         _currentPageIndex = 0
         _totalPages = 1
      End Sub

      Private _borderStyle As BorderStyle = BorderStyle.None
      <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public Property BorderStyle() As BorderStyle
         Get
            Return _borderStyle
         End Get
         Set(value As BorderStyle)
            If _borderStyle <> value Then
               _borderStyle = value
               UpdateStyles()
               Invalidate()
            End If
         End Set
      End Property

      ' To support border styles
      Protected Overrides ReadOnly Property CreateParams() As CreateParams
         Get
            Dim cp As CreateParams = MyBase.CreateParams

            Select Case BorderStyle
               Case BorderStyle.None
                  cp.Style = cp.Style And Not SafeNativeMethods.WS_BORDER
                  cp.ExStyle = cp.ExStyle And Not SafeNativeMethods.WS_EX_CLIENTEDGE
                  Exit Select

               Case BorderStyle.FixedSingle
                  cp.Style = cp.Style Or SafeNativeMethods.WS_BORDER
                  cp.ExStyle = cp.ExStyle And Not SafeNativeMethods.WS_EX_CLIENTEDGE
                  Exit Select

               Case BorderStyle.Fixed3D
                  cp.Style = cp.Style And Not SafeNativeMethods.WS_BORDER
                  cp.ExStyle = cp.ExStyle Or SafeNativeMethods.WS_EX_CLIENTEDGE
                  Exit Select
            End Select

            Return cp
         End Get
      End Property

      Private _transformInverse As LeadMatrix = LeadMatrix.Identity
      Private _transform As LeadMatrix = LeadMatrix.Identity
      <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public Property Transform() As LeadMatrix
         Get
            Return _transform
         End Get
         Set(value As LeadMatrix)
            _transform = value
            _transformInverse = _transform.Clone()
            If _transformInverse.HasInverse Then
               _transformInverse.Invert()
            End If

            Invalidate()
         End Set
      End Property

      Private _documents As New List(Of SvgDocumentInformation)()
      Public Property DocumentList() As List(Of SvgDocumentInformation)
         Get
            Return _documents
         End Get

         Set(value As List(Of SvgDocumentInformation))
            For Each doc As SvgDocumentInformation In _documents
               doc.Document.Dispose()
            Next

            _documents.Clear()
            _currentPageIndex = 0
            _totalPages = 0

            If value IsNot Nothing Then
               For Each doc As SvgDocumentInformation In value
                  _documents.Add(doc)
               Next
            End If
         End Set
      End Property

      <DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)> _
      Public ReadOnly Property CurrentDocument() As SvgDocument
         Get
            If _documents.Count = 0 Then
               Return Nothing
            End If

            Return _documents(_currentPageIndex).Document
         End Get
      End Property

      Public Enum CoordinateType
         Image
         Control
      End Enum

      Public Function ConvertPoint(source As CoordinateType, destination As CoordinateType, point As LeadPointD) As LeadPointD
         If source = destination Then
            Return point
         End If

         Dim points As LeadPointD() = {point}

         If source = CoordinateType.Control Then
            _transformInverse.TransformPoints(points)
         Else
            _transform.TransformPoints(points)
         End If

         Return points(0)
      End Function

      Private _isPanning As Boolean = False

      Private Sub StopPanning()
         If _documents.Count <> 0 AndAlso _isPanning Then
            Me.Capture = False
            _isPanning = False

            RaiseEvent PanEnd(Me, EventArgs.Empty)
         End If
      End Sub

      Private Sub StartPanning(e As MouseEventArgs)
         If _documents.Count = 0 Then
            Return
         End If

         _isPanning = True
         Me.Capture = True

         RaiseEvent PanBegin(Me, e)
      End Sub

      Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
         StopPanning()

         Focus()
         StartPanning(e)

         MyBase.OnMouseDown(e)
      End Sub

      Public Event Panning As MouseEventHandler
      Public Event PanBegin As MouseEventHandler
      Public Event PanEnd As EventHandler

      Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
         If _documents.Count <> 0 AndAlso _isPanning Then
            RaiseEvent Panning(Me, e)
         End If

         MyBase.OnMouseMove(e)
      End Sub

      Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
         StopPanning()

         MyBase.OnMouseUp(e)
      End Sub

      Protected Overrides Sub OnLostFocus(e As EventArgs)
         StopPanning()

         MyBase.OnLostFocus(e)
      End Sub

      Private _useDpi As Boolean

      Public Property UseDpi() As Boolean
         Get
            Return _useDpi
         End Get
         Set(value As Boolean)
            _useDpi = value
            Identity()
         End Set
      End Property

      Public ReadOnly Property ImageSize() As LeadSize
         Get
            If _documents(_currentPageIndex).Document Is Nothing Then
               Return LeadSize.Create(0, 0)
            End If

            Dim svgBounds As SvgBounds = _documents(_currentPageIndex).Document.Bounds



            Return LeadSize.Create(Tools.ToInt(svgBounds.Bounds.Width), Tools.ToInt(svgBounds.Bounds.Height))
         End Get
      End Property

      Public Sub Identity()
         If _documents.Count = 0 Then
            Return
         End If

         If _documents(_currentPageIndex).Document Is Nothing Then
            Return
         End If

         Dim svgBounds As SvgBounds = _documents(_currentPageIndex).Document.Bounds



         Dim bounds As LeadRectD = svgBounds.Bounds
         Dim transform As LeadMatrix = LeadMatrix.Identity

         If _useDpi Then
            Dim imageSize As LeadSize = Me.ImageSize
            Dim resolution As LeadSizeD = LeadSizeD.Create(96, 96)
            If Not svgBounds.Resolution.IsEmpty Then
               If svgBounds.Resolution.Width > 0 Then
                  resolution.Width = svgBounds.Resolution.Width
               End If
               If svgBounds.Resolution.Height > 0 Then
                  resolution.Height = svgBounds.Resolution.Height
               End If
            End If

            transform.Scale(CDbl(96.0) / resolution.Width, CDbl(96.0) / resolution.Height)
         End If

         Me.Transform = transform
         Invalidate()
      End Sub

      Private _drawClipRectangle As Boolean = True
      Public Property DrawClipRectangle() As Boolean
         Get
            Return _drawClipRectangle
         End Get
         Set(value As Boolean)
            _drawClipRectangle = value
            Invalidate()
         End Set
      End Property

      Private _updateCounter As Integer = 0
      Public Sub BeginUpdate()
         _updateCounter += 1
      End Sub

      Public Sub EndUpdate()
         If _updateCounter = 0 Then
            Throw New InvalidOperationException("EndUpdate without matching BeginUpdate")
         End If
         _updateCounter -= 1

         If _updateCounter = 0 Then
            Invalidate()
         End If
      End Sub

      Protected ReadOnly Property CanUpdate() As Boolean
         Get
            Return _updateCounter = 0
         End Get
      End Property

      Protected Overrides Sub OnPaint(e As PaintEventArgs)
         DrawImage(e, Me.ClientRectangle)
         MyBase.OnPaint(e)
      End Sub

      Private Shared Sub DrawBounds(graphics As Graphics, pen As Pen, brush As Brush, textBrush As Brush, font As Font, text As String, _
       bounds As LeadRectD, transform As LeadMatrix)
         Dim corners As LeadPointD() = Tools.GetCornerPoints(bounds)
         transform.TransformPoints(corners)
         Dim cornersBounds As LeadRectD = Tools.GetBoundingRect(corners)

         Dim cornersF As PointF() = New PointF(3) {}
         For i As Integer = 0 To cornersF.Length - 1
            ' if any point empty, then return
            If corners(i).IsEmpty Then
               Return
            End If

            cornersF(i) = New PointF(CSng(corners(i).X), CSng(corners(i).Y))
         Next

         If pen IsNot Nothing Then
            graphics.DrawPolygon(pen, cornersF)
         End If
         If brush IsNot Nothing Then
            graphics.FillPolygon(brush, cornersF)
         End If
         If text IsNot Nothing AndAlso textBrush IsNot Nothing Then
            graphics.DrawString(text, font, textBrush, CSng(cornersBounds.X), CSng(cornersBounds.Y))
         End If
      End Sub

      Private Sub DrawImage(e As PaintEventArgs, clipRect As Rectangle)
         If _documents.Count = 0 Then
            Return
         End If

         If _documents(_currentPageIndex).Document Is Nothing OrElse Not Me.CanUpdate Then
            Return
         End If

         Dim graphics As Graphics = e.Graphics

         Dim options As SvgRenderOptions = New SvgRenderOptions()
         options.Transform = _transform
         options.Bounds = _documents(_currentPageIndex).Document.Bounds.Bounds
         options.UseBackgroundColor = True
         options.ClipBounds = LeadRectD.Create(clipRect.X, clipRect.Y, clipRect.Width, clipRect.Height)
         options.BackgroundColor = RasterColor.FromKnownColor(RasterKnownColor.White)

         Try
            Using engine As IRenderingEngine = RenderingEngineFactory.Create(graphics)
               _documents(_currentPageIndex).Document.Render(engine, options)
            End Using
         Catch
            Console.WriteLine()
         End Try

         DrawBounds(graphics, Pens.Black, Nothing, Nothing, Nothing, Nothing, _
          options.Bounds, options.Transform)

         If _documents(_currentPageIndex).DocumentText IsNot Nothing AndAlso _documents(_currentPageIndex).ShowText Then
            Dim docBounds As LeadRectD = _documents(_currentPageIndex).Document.Bounds.Bounds

            ' Could be rotated, so
            Dim topLeft As LeadPointD = docBounds.TopLeft
            Dim bottomRight As LeadPointD = docBounds.BottomRight

            Dim corners As LeadPointD() = New LeadPointD(3) {}
            corners(0).X = topLeft.X
            corners(0).Y = topLeft.Y
            corners(1).X = bottomRight.X
            corners(1).Y = topLeft.Y
            corners(2).X = bottomRight.X
            corners(2).Y = bottomRight.Y
            corners(3).X = topLeft.X
            corners(3).Y = bottomRight.Y

            options.Transform.TransformPoints(corners)

            Dim path As New GraphicsPath()
            Dim pts As PointF() = New PointF(3) {}
            For i As Integer = 0 To corners.Length - 1
               pts(i).X = CSng(corners(i).X)
               pts(i).Y = CSng(corners(i).Y)
            Next
            path.AddPolygon(pts)
            graphics.SetClip(path, System.Drawing.Drawing2D.CombineMode.Intersect)

            Using brush As SolidBrush = New SolidBrush(Color.FromArgb(64, Color.Black))
               For Each character As DocumentCharacter In _documents(_currentPageIndex).DocumentText.Characters
                  Dim bounds As LeadRectD = character.Bounds
                  Dim text As String = New String(New Char() {character.Code})

                  DrawBounds(graphics, Pens.Yellow, brush, Brushes.Yellow, Font, text, _
                   character.Bounds, options.Transform)
               Next
            End Using
         End If

         MyBase.OnPaint(e)
      End Sub

      Private _currentPageIndex As Integer
      Public Property CurrentPageIndex() As Integer
         Get
            Return _currentPageIndex
         End Get
         Set(value As Integer)
            _currentPageIndex = value




            Identity()
            Invalidate()
         End Set
      End Property

      Private _totalPages As Integer
      Public Property TotalPages() As Integer
         Get
            Return _totalPages
         End Get
         Set(value As Integer)
            _totalPages = value
         End Set
      End Property
   End Class
End Namespace
