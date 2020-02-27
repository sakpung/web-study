' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO

Imports Leadtools.Demos
Imports Leadtools.Demos.Dialogs
Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Controls
Imports Leadtools.Svg
Imports System

Partial Public Class MainForm
   Inherits Form
   Public Sub New()
      InitializeComponent()
   End Sub

   Protected Overrides Sub OnLoad(e As EventArgs)
      If Not Me.DesignMode Then
         InitDemo()
      End If

      MyBase.OnLoad(e)
   End Sub

   ' Name of last image file loaded successfully
   Private _imageFileName As String

   ' Options to use when loading the image
   Private _demoOptions As DemoOptions

   ' LEADTOOLS object used to load image files
   Private _rasterCodecs As RasterCodecs

   ' LEADTOOLS control to view images
   Private _imageViewer As ImageViewer

   ' Image viewer layours used in this demo
   ' Single images (only one visible at any time)
   ' Vertical with a single column
   ' Vertical with two columns (double)
   ' Horizontal with single row
   Private ReadOnly _viewLayouts As ImageViewerViewLayout() = {New ImageViewerSingleViewLayout(), New ImageViewerVerticalViewLayout() With { _
     .Columns = 1 _
   }, New ImageViewerVerticalViewLayout() With { _
     .Columns = 2 _
   }, New ImageViewerHorizontalViewLayout() With { _
     .Rows = 1 _
   }}

   Private Sub InitDemo()
      Messager.Caption = "VB Image Viewer Demo"
      Text = Messager.Caption

      _imageInfoLabel.Text = [String].Empty
      _imageInfoLabel.Text = [String].Empty

      ' Load the last options used
      _demoOptions = New DemoOptions()

      ' Initialize the LEADTOOLS object used to load image files
      _rasterCodecs = New RasterCodecs()
      ' Load documents at 300 DPI for better viewing
      _rasterCodecs.Options.RasterizeDocument.Load.Resolution = 300

      ' Initialize the LEADTOOLS control used to view images
      InitImageViewer()

      ' Load the default image
#If LT_CLICKONCE Then
			Dim defaultFileName = Path.Combine(Application.StartupPath, "Documents\Leadtools.pdf")
#Else
      Dim defaultFileName As String = Path.Combine(DemosGlobal.ImagesFolder, "Leadtools.pdf")
#End If

      If Not String.IsNullOrEmpty(defaultFileName) AndAlso File.Exists(defaultFileName) Then
         LoadImage(defaultFileName)
      End If
   End Sub

   Private Sub InitImageViewer()
      ' Create the control
      _imageViewer = New ImageViewer(_viewLayouts(1))
      _imageViewer.BackColor = SystemColors.AppWorkspace
      _imageViewer.Dock = DockStyle.Fill

      ' Use the image true resolution
      _imageViewer.UseDpi = True

      ' We want some padding between the overall viewer and the pages, so
      _imageViewer.ViewPadding = New Padding(10)

      ' Center the pages horizontally and vertically in the viewer
      _imageViewer.ViewHorizontalAlignment = ControlAlignment.Center
      _imageViewer.ViewVerticalAlignment = ControlAlignment.Center

      ' Add some spacing between the pages
      _imageViewer.ItemSpacing = New LeadSize(8, 8)

      ' Add a border to each page
      _imageViewer.ItemBorderThickness = 2
      _imageViewer.ItemBorderColor = Color.Black

      ' Since we can load SVG documents that has no background color, set one
      _imageViewer.ImageBackgroundColor = Color.White

      Me.Controls.Add(_imageViewer)
      _imageViewer.BringToFront()

      ' Add the pan/zoom interactive mode
      Dim panZoomMode As ImageViewerPanZoomInteractiveMode = New ImageViewerPanZoomInteractiveMode() With { _
        .DoubleTapSizeMode = ControlSizeMode.ActualSize _
      }

      _imageViewer.InteractiveModes.Add(panZoomMode)
   End Sub

   Private Sub _exitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _exitToolStripMenuItem.Click
      Me.Close()
   End Sub

   Private Sub _aboutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _aboutToolStripMenuItem.Click
      Using aboutDialog As AboutDialog = New AboutDialog("Image Viewer", ProgrammingInterface.VB)
         aboutDialog.ShowDialog(Me)
      End Using
   End Sub

   Private Sub _openToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _openToolStripMenuItem.Click
      Using dlg As LoadFileDialog = New LoadFileDialog()
         ' Clone the options, if Cancel, we do not want them changed
         dlg.ImageFileName = _imageFileName
         dlg.DemoOptions = _demoOptions.Clone()
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            ' Copy the options (exluding the current file name)
            _demoOptions = dlg.DemoOptions.Clone()

            ' Load the image
            LoadImage(dlg.ImageFileName)
         End If
      End Using
   End Sub

   Private Sub _loadToolStripButton_Click(sender As Object, e As EventArgs)
      _openToolStripMenuItem.PerformClick()
   End Sub

   Private Sub _layoutToolStripMenuItem_DropDownOpening(sender As Object, e As EventArgs) Handles _layoutToolStripMenuItem.DropDownOpening
      _singleLayoutToolStripMenuItem.Checked = (_imageViewer.ViewLayout Is _viewLayouts(0))
      _verticalLayoutToolStripMenuItem.Checked = (_imageViewer.ViewLayout Is _viewLayouts(1))
      _doubleLayoutToolStripMenuItem.Checked = (_imageViewer.ViewLayout Is _viewLayouts(2))
      _horizontalLayoutToolStripMenuItem.Checked = (_imageViewer.ViewLayout Is _viewLayouts(3))
   End Sub

   Private Sub _layoutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles _singleLayoutToolStripMenuItem.Click, _verticalLayoutToolStripMenuItem.Click, _doubleLayoutToolStripMenuItem.Click, _horizontalLayoutToolStripMenuItem.Click
      ' Select the layout
      If sender Is _singleLayoutToolStripMenuItem Then
         _imageViewer.ViewLayout = _viewLayouts(0)
      ElseIf sender Is _verticalLayoutToolStripMenuItem Then
         _imageViewer.ViewLayout = _viewLayouts(1)
      ElseIf sender Is _doubleLayoutToolStripMenuItem Then
         _imageViewer.ViewLayout = _viewLayouts(2)
      ElseIf sender Is _horizontalLayoutToolStripMenuItem Then
         _imageViewer.ViewLayout = _viewLayouts(3)
      End If
   End Sub

   Private Sub LoadImage(imageFileName As String)
      Try
         Using wait As WaitCursor = New WaitCursor()
            ' Get the image number of pages
            Dim pageCount As Integer
            Using imageInfo As CodecsImageInfo = _rasterCodecs.GetInformation(imageFileName, True)
               pageCount = imageInfo.TotalPages
            End Using

            ' At this point, we can probably load this image, so save it
            _imageFileName = imageFileName

            ' See if we can load this image as SVG
            ' If the user selected that and if the format supports it
            Dim useSVG As Boolean = (_demoOptions.UseSVG AndAlso _rasterCodecs.CanLoadSvg(imageFileName))

            ' See if we need the virtualizer
            ' If the user selected that and if we have more than one page
            Dim useVirtualizer As Boolean = (_demoOptions.UseVirtiualizer AndAlso pageCount > 1)

            ' We are ready
            ' Ensure that the image viewer will not perform any unnecessary calculations in the middle of adding
            ' and removing items
            _imageViewer.BeginUpdate()

            Try
               ' Remove the previous pages
               _imageViewer.Items.Clear()

               ' Set the image info label
               Me.Text = String.Format("{0} - {1}", imageFileName, Messager.Caption)
               _imageInfoLabel.Text = String.Format("Pages:{0} - Use SVG:{1} - Use Virtualizer:{2}", pageCount, If(useSVG, "Yes", "No"), If(useVirtualizer, "Yes", "No"))

               If useVirtualizer Then
                  LoadPagesWithVirtualizer(imageFileName, pageCount, useSVG)
               Else
                  LoadPagesDirect(imageFileName, pageCount, useSVG)
               End If
            Finally
               _imageViewer.EndUpdate()
            End Try
         End Using
      Catch ex As Exception
         Messager.ShowError(Me, ex)
      End Try
   End Sub

   Private Sub LoadPagesWithVirtualizer(imageFileName As String, pageCount As Integer, useSVG As Boolean)
      ' Load the pages using a virtualizer

      ' Note that the code below will get the width and height for each page indvidually
      ' This is important because some file formats such as PDF, DOCX and TIFF supports pages
      ' with different sizes.
      ' If this behavior is not desired, then the code can be optimized by only obtaining the size
      ' of the first page and re-using it for all items

      ' First thing, we need to add empty items that are the same size as each page
      For pageNumber As Integer = 1 To pageCount
         ' This page size in pixels
         Dim pagePixelSize As LeadSize
         Dim resolution As LeadSizeD

         Using imageInfo As CodecsImageInfo = _rasterCodecs.GetInformation(imageFileName, False, pageNumber)
            pagePixelSize = New LeadSize(imageInfo.Width, imageInfo.Height)
            resolution = New LeadSizeD(imageInfo.XResolution, imageInfo.YResolution)
         End Using

         ' Set up the item with the size and resolution
         Dim item As ImageViewerItem = New ImageViewerItem() With { _
           .ImageSize = pagePixelSize, _
           .Resolution = resolution _
         }

         ' Add it to the viewer
         _imageViewer.Items.Add(item)
      Next

      ' All the items are added and ready, create a new virtualizer and use it
      Dim virtualizer As MyImageViewerVirtualizer = New MyImageViewerVirtualizer(imageFileName, _rasterCodecs, useSVG)
      _imageViewer.Virtualizer = virtualizer
   End Sub

   Private Sub LoadPagesDirect(imageFileName As String, pageCount As Integer, useSVG As Boolean)
      ' Loads all the pages into the viewer
      For pageNumber As Integer = 1 To pageCount
         If useSVG Then
            ' Load it as an SVG and add it
            Dim svgDocument As SvgDocument = TryCast(_rasterCodecs.LoadSvg(imageFileName, pageNumber, Nothing), SvgDocument)

            ' Ensure the SVG optimized for fast viewing
            OptimizeForView(svgDocument)
            Me._imageViewer.Items.AddFromSvgDocument(svgDocument)
         Else
            ' Load it as a raster image and add it
            Dim rasterImage As RasterImage = _rasterCodecs.Load(imageFileName, pageNumber)
            Me._imageViewer.Items.AddFromImage(rasterImage, 1)
         End If
      Next
   End Sub

   Friend Shared Sub OptimizeForView(svgDocument As SvgDocument)
      ' Ensure the SVG optimized for fast viewing
      If Not svgDocument.IsFlat Then
         svgDocument.Flat(Nothing)
      End If

      If Not svgDocument.Bounds.IsValid OrElse svgDocument.Bounds.IsTrimmed Then
         svgDocument.CalculateBounds(False)
      End If

      If Not svgDocument.IsRenderOptimized Then
         svgDocument.BeginRenderOptimize()
      End If
   End Sub
End Class
