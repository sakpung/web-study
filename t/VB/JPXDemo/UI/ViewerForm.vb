' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Controls
Imports Leadtools.ImageProcessing
Imports System.Collections.Generic
Imports Leadtools.Jpeg2000
Imports Leadtools.ImageProcessing.Effects
Imports System.Drawing.Drawing2D
Imports Leadtools.Drawing

Public Class ViewerForm
   Inherits System.Windows.Forms.Form

   ''' <summary>
   ''' Required designer variable.
   ''' </summary>
   Private components As System.ComponentModel.Container = Nothing

   Public Sub New(ByVal parent As Form, ByVal bIsComposite As Boolean)
      '
      ' Required for Windows Form Designer support
      '
      InitializeComponent()

      '
      ' TODO: Add any constructor code after InitializeComponent call
      '
      MdiParent = parent
      IsComposite = bIsComposite
      InitClass()
   End Sub

   ''' <summary>
   ''' Clean up any resources being used.
   ''' </summary>
   Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
         If Not components Is Nothing Then
            components.Dispose()
         End If

         If Not ImageListControl Is Nothing Then
            ImageListControl.Items.Clear()
         End If

         If Not ImagesList Is Nothing Then
            ImagesList.Clear()
         End If

         If Not ColorList Is Nothing Then
            ColorList.Clear()
         End If

         If Not OpacityList Is Nothing Then
            OpacityList.Clear()
         End If

         If Not PreOpacityList Is Nothing Then
            PreOpacityList.Clear()
         End If


      End If
      MyBase.Dispose(disposing)
   End Sub

#Region "Windows Form Designer generated code"
   ''' <summary>
   ''' Required method for Designer support - do not modify
   ''' the contents of Me method with the code editor.
   ''' </summary>
   Private Sub InitializeComponent()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewerForm))
      Me._pnlViewer = New System.Windows.Forms.Panel()
      Me._pnlImageList = New System.Windows.Forms.Panel()
      Me.SuspendLayout()
      '
      '_pnlViewer
      '
      Me._pnlViewer.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me._pnlViewer.Location = New System.Drawing.Point(133, -2)
      Me._pnlViewer.Name = "_pnlViewer"
      Me._pnlViewer.Size = New System.Drawing.Size(679, 420)
      Me._pnlViewer.TabIndex = 3
      '
      '_pnlImageList
      '
      Me._pnlImageList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me._pnlImageList.Location = New System.Drawing.Point(-1, -2)
      Me._pnlImageList.Name = "_pnlImageList"
      Me._pnlImageList.Size = New System.Drawing.Size(132, 421)
      Me._pnlImageList.TabIndex = 2
      '
      'ViewerForm
      '
      Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
      Me.ClientSize = New System.Drawing.Size(810, 418)
      Me.Controls.Add(Me._pnlViewer)
      Me.Controls.Add(Me._pnlImageList)
      Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
      Me.Name = "ViewerForm"
      Me.ShowInTaskbar = False
      Me.Text = "ViewerForm"
      Me.ResumeLayout(False)

   End Sub
#End Region

   Private _viewer As ImageViewer
   Private _imageListControl As ImageViewer

   Private _imagesList As List(Of RasterImage)
   Private _colorList As List(Of RasterImage)
   Private _opacityList As List(Of RasterImage)
   Private _preOpacityList As List(Of RasterImage)
   Private _name As String
   Private _activeList As ActiveImageLists
   Private _isComposite As Boolean
   Private _delay As Integer
   Private _renderWidth As Integer
   Private _renderHeight As Integer
   Private _playingAnnimation As Boolean
   Private _stopAnimation As Boolean
   Private _loopAnimation As Boolean

   Private Const DefaultViewerWidth As Integer = 600
   Private Const DefaultViewerHeight As Integer = 600
   Private WithEvents _pnlViewer As System.Windows.Forms.Panel
   Private WithEvents _pnlImageList As System.Windows.Forms.Panel
   Private Const DefaultDelay As Integer = 100

   Public Enum ActiveImageLists
      ImagesList = 0
      ColorList = 1
      OpacityList = 2
      PreOpacityList = 3
   End Enum

   Public Property LoopAnimation() As Boolean
      Get
         Return _loopAnimation
      End Get

      Set(ByVal value As Boolean)
         _loopAnimation = value
      End Set
   End Property

   Public Property StopAnimation() As Boolean
      Get
         Return _stopAnimation
      End Get
      Set(ByVal value As Boolean)
         _stopAnimation = value
      End Set
   End Property

   Public Property RenderHeight() As Integer
      Get
         Return _renderHeight
      End Get
      Set(ByVal value As Integer)
         _renderHeight = value
      End Set
   End Property

   Public Property RenderWidth() As Integer
      Get
         Return _renderWidth
      End Get
      Set(ByVal value As Integer)
         _renderWidth = value
      End Set
   End Property

   Public Property PlayingAnnimation() As Boolean
      Get
         Return _playingAnnimation
      End Get
      Set(ByVal value As Boolean)
         _playingAnnimation = value
      End Set
   End Property

   Public Property AnimationDelay() As Integer
      Get
         Return _delay
      End Get
      Set(ByVal value As Integer)
         _delay = value
      End Set
   End Property

   Public ReadOnly Property Image() As RasterImage
      Get
         Return _viewer.Image
      End Get
   End Property

   Public Property IsComposite() As Boolean
      Get
         Return _isComposite
      End Get
      Set(ByVal value As Boolean)
         _isComposite = value
      End Set
   End Property

   Public Property ImageListControl() As ImageViewer
      Get
         Return _imageListControl
      End Get
      Set(ByVal value As ImageViewer)
         _imageListControl = value
      End Set
   End Property

   Public Property ImagesList() As List(Of RasterImage)
      Get
         Return _imagesList
      End Get
      Set(ByVal value As List(Of RasterImage))
         _imagesList = value
      End Set
   End Property

   Public Property ActiveList() As ActiveImageLists
      Get
         Return _activeList
      End Get
      Set(ByVal value As ActiveImageLists)
         _activeList = value
      End Set
   End Property

   Public Property ColorList() As List(Of RasterImage)
      Get
         Return _colorList
      End Get
      Set(ByVal value As List(Of RasterImage))
         _colorList = value
      End Set
   End Property

   Private Property OpacityList() As List(Of RasterImage)
      Get
         Return _opacityList
      End Get

      Set(ByVal value As List(Of RasterImage))
         _opacityList = value
      End Set
   End Property

   Private Property PreOpacityList() As List(Of RasterImage)
      Get
         Return _preOpacityList
      End Get
      Set(ByVal value As List(Of RasterImage))
         _preOpacityList = value
      End Set
   End Property

   Public ReadOnly Property Viewer() As ImageViewer
      Get
         Return _viewer
      End Get
   End Property

   Private Sub InitClass()
      _viewer = New ImageViewer()
      _viewer.Dock = DockStyle.Fill
      _viewer.BorderStyle = BorderStyle.None
      AddHandler _viewer.TransformChanged, AddressOf _viewer_SizeModeChanged
      AddHandler _viewer.PostRender, AddressOf _viewer_PostTransformPaint
      _pnlViewer.Controls.Add(_viewer)
      _viewer.BringToFront()
      _viewer.AllowDrop = True
      _viewer.AutoDisposeImages = False

      '  Create a new RasterImageList control. 
      ImageListControl = New ImageViewer(New ImageViewerVerticalViewLayout() With {.Columns = 1})
      ImageListControl.SelectedItemBorderColor = Color.Red
      ImageListControl.SelectedItemBackgroundColor = Color.LightBlue
      ImageListControl.BackColor = Color.LightGray
      ImageListControl.BorderStyle = BorderStyle.FixedSingle
      ImageListControl.ImageBorderThickness = 1
      ImageListControl.ImageHorizontalAlignment = ControlAlignment.Far
      ImageListControl.ImageVerticalAlignment = ControlAlignment.Center
      ImageListControl.ItemBackgroundColor = Color.LightGray
      ImageListControl.ItemBorderThickness = 0
      ImageListControl.ItemPadding = New Padding(20)
      ImageListControl.ItemTextColor = Color.Black
      ImageListControl.ItemSize = LeadSize.Create(60, 80)
      ImageListControl.ItemSizeMode = ControlSizeMode.Fit
      ImageListControl.Dock = DockStyle.Fill
      Dim paintProperties As RasterPaintProperties
      paintProperties = ImageListControl.PaintProperties
      paintProperties.PaintDisplayMode = RasterPaintDisplayModeFlags.Bicubic
      ImageListControl.PaintProperties = paintProperties
      ImageListControl.Height = _viewer.Height
      ImageListControl.TextHorizontalAlignment = ControlAlignment.Center
      ImageListControl.TextVerticalAlignment = ControlAlignment.Center
      ImageListControl.InteractiveModes.BeginUpdate()
      ImageListControl.InteractiveModes.Add((New ImageViewerSelectItemsInteractiveMode() With {.SelectionMode = ImageViewerSelectionMode.Single}))
      ImageListControl.InteractiveModes.EndUpdate()
      AddHandler ImageListControl.SelectedItemsChanged, AddressOf ImageListControl_SelectedItemsChanged
      ImageListControl.AutoDisposeImages = False
      '  Add the RasterImageList to the control collection. 
      _pnlImageList.Controls.Add(ImageListControl)

      PlayingAnnimation = False
      StopAnimation = False
      LoopAnimation = False

      ActiveList = ActiveImageLists.ColorList

      ImagesList = New List(Of RasterImage)
      ColorList = New List(Of RasterImage)
      OpacityList = New List(Of RasterImage)
      PreOpacityList = New List(Of RasterImage)

      CType(MdiParent, MainForm).ClearCheck()
      CType(MdiParent, MainForm).SetCheck(ActiveList)

      RenderHeight = DefaultViewerHeight
      RenderWidth = DefaultViewerWidth
      AnimationDelay = DefaultDelay

      '  Add a handler to the PaintBackground event 
      ' ImageList.PaintBackground += new PaintEventHandler(rasterImageList_PaintBackground)
   End Sub

   Private Sub ImageListControl_SelectedItemsChanged(sender As Object, e As EventArgs)
      Dim items() As ImageViewerItem = ImageListControl.Items.GetSelected()
      If (items.Length = 0) Then
         _viewer.Image = Nothing
      Else
         ' Get the only item in the list since it is single selection
         Dim item As ImageViewerItem = items(0)
         Dim itemIndex As Integer = ImageListControl.Items.IndexOf(item)

         _viewer.Image = ImageListControl.Items(itemIndex).Image
      End If
      Viewer.Invalidate()
   End Sub


   Private Function LoadSaveAnimationStruct() As Boolean
      Dim _compositionBox As New CompositionBox()

      Try
         _compositionBox = CType(CType(MdiParent, MainForm).Jpeg2000Eng.ReadBox(_name, Jpeg2000BoxType.CompositionBox, 0), CompositionBox)
      Catch
         Return False
      End Try

      ' There must be only one composition box
      RenderHeight = _compositionBox.CompositionOptions.Height
      If (RenderHeight = 0) Then
         RenderHeight = DefaultViewerHeight
      End If

      RenderWidth = _compositionBox.CompositionOptions.Width
      If (RenderWidth = 0) Then
         RenderWidth = DefaultViewerWidth
      End If

      If ((Convert.ToInt32(_compositionBox.CompositionOptions.Loop) = 255)) Then
         LoopAnimation = True
      Else
         LoopAnimation = False
      End If

      AnimationDelay = 0

      If (_compositionBox.Instructions(0).Type = 4) Then
         AnimationDelay = _compositionBox.Instructions(0).Instructions(0).Life * _compositionBox.Instructions(0).Tick
      End If

      If (AnimationDelay = 0) Then
         AnimationDelay = DefaultDelay
      End If


      Return True
   End Function


   Private Function GetActiveList() As List(Of RasterImage)
      Select Case (ActiveList)
         Case ActiveImageLists.ColorList
            Return ColorList

         Case ActiveImageLists.OpacityList
            Return OpacityList

         Case ActiveImageLists.PreOpacityList
            Return PreOpacityList

         Case Else
            Return ImagesList
      End Select
   End Function

   Private Sub ImageList_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
      Viewer.Image = ImageListControl.Items.GetSelected()(0).Image

      Viewer.Image.Page = ImageListControl.Items.GetSelected()(0).PageNumber

      Viewer.Invalidate()
   End Sub

   Private Sub FillImageList(ByVal image As RasterImage)
      Using Codecs As New RasterCodecs()

         ImageListControl.Items.Clear()

         For index As Integer = 1 To image.PageCount
            image.Page = index
            '  Create the item of the image list 
            Dim item As New ImageViewerItem()
            item.Size = LeadSize.Create(120, 120)
            item.Text = "Page: " + (index - 1).ToString()
            item.Image = image.Clone()
            item.Tag = index

            ' Add the item to the image list 
            ImageListControl.Items.Add(item)
         Next index
         ImageListControl.Items(0).IsSelected = True
         _viewer.Image = ImageListControl.Items(0).Image
      End Using
   End Sub

   Public Sub FillImageList()
      Using codecs As New RasterCodecs()

         Dim activeList As List(Of RasterImage) = GetActiveList()

         If (IsNothing(activeList)) Then
            Messager.ShowError(Me, "No List Avaliable")
            Return
         End If

         Dim tempImage As New RasterImage(activeList(0))

         For index As Integer = 1 To activeList.Count - 1
            tempImage.AddPage(activeList(index).CloneAll())
         Next index

         FillImageList(tempImage)
      End Using
   End Sub

   Public Sub FillImages(ByVal compositeImage As List(Of CompositeJpxImages))
      For index As Integer = 0 To compositeImage.Count - 1

         ColorList.Add(compositeImage(index).ColorImage)

         If Not (IsNothing(compositeImage(index).OpacityImage)) Then
            OpacityList.Add(compositeImage(index).OpacityImage)
         Else
            OpacityList.Add(CType(MdiParent, MainForm).NoOpacityBitmap)
         End If

         If Not (IsNothing(compositeImage(index).PreOpacityImage)) Then
            PreOpacityList.Add(compositeImage(index).PreOpacityImage)
         Else
            PreOpacityList.Add(CType(MdiParent, MainForm).NoPreOpacityBitmap)
         End If

         If Not (IsNothing(compositeImage(index).OpacityImage)) Then
            Dim combineImage As New RasterImage(compositeImage(index).ColorImage)

            Dim Command As New CombineCommand(compositeImage(index).OpacityImage, _
                                                        New LeadRect(0, 0, compositeImage(index).OpacityImage.Width, compositeImage(index).OpacityImage.Height), _
                                                        New LeadPoint(0, 0), _
                                                        CombineCommandFlags.OperationMultiply)
            Command.Run(combineImage)

            ImagesList.Add(combineImage)
         Else
            ImagesList.Add(compositeImage(index).ColorImage)
         End If
      Next index
   End Sub

   Public Sub Initialize(ByVal info As ImageInformation, ByVal paintProperties As RasterPaintProperties, ByVal bSnap As Boolean, ByVal isfile As Boolean)
      _viewer.BeginUpdate()
      UpdatePaintProperties(paintProperties)
      FillImageList(info.Image)

      If Not (IsNothing(_viewer.Image)) Then
         AddHandler _viewer.Image.Changed, AddressOf Image_Changed
      End If
      _name = info.Name

      If (bSnap) Then
         Snap()
      End If
      If (isfile) Then
         LoadSaveAnimationStruct()
      End If
      UpdateCaption()
      _viewer.EndUpdate()
   End Sub

   Public Sub Initialize(ByVal compositeImage As List(Of CompositeJpxImages), ByVal fileName As String, ByVal paintProperties As RasterPaintProperties, ByVal bSnap As Boolean)
      _viewer.BeginUpdate()
      UpdatePaintProperties(paintProperties)

      ' _viewer.Image = compositeImage[0].ColorImage
      FillImages(compositeImage)
      FillImageList()

      If Not (IsNothing(_viewer.Image)) Then
         AddHandler _viewer.Image.Changed, AddressOf Image_Changed
      End If

      _name = fileName
      If (bSnap) Then
         Snap()
      End If

      LoadSaveAnimationStruct()
      UpdateCaption()
      _viewer.EndUpdate()
   End Sub

   Public Sub UpdatePaintProperties(ByVal paintProperties As RasterPaintProperties)
      _viewer.PaintProperties = paintProperties
   End Sub

   Private Sub UpdateCaption()
      Text = String.Format(_name)
   End Sub

   Private Sub Image_Changed(ByVal sender As Object, ByVal e As RasterImageChangedEventArgs)
      UpdateCaption()
      If (Not IsNothing(MdiParent) AndAlso Not PlayingAnnimation) Then
         CType(MdiParent, MainForm).UpdateControls()
      End If
   End Sub

   Private Sub _viewer_SizeModeChanged(ByVal sender As Object, ByVal e As EventArgs)
      CType(MdiParent, MainForm).UpdateControls()
   End Sub

   Public Sub Snap()
      _viewer.ClientSize = New Size(_pnlImageList.Width + DefaultViewerWidth, DefaultViewerHeight)
      ClientSize = _viewer.ClientSize
   End Sub

   Private Sub _viewer_PostTransformPaint(ByVal sender As Object, e As ImageViewerRenderEventArgs)
      Dim drawFont As Font = New Font("Arial", 9, FontStyle.Bold)
      Try
         Dim g As Graphics = e.PaintEventArgs.Graphics
         Dim mm As LeadMatrix = _viewer.ViewTransform
         Dim m As Matrix = New Matrix(CSng(mm.M11), CSng(mm.M12), CSng(mm.M21), CSng(mm.M22), CSng(mm.OffsetX), CSng(mm.OffsetY))
         Dim t As Transformer = New Transformer(m)
      Finally
         drawFont.Dispose()
      End Try
   End Sub
End Class
