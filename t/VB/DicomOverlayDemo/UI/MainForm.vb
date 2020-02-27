' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Dicom
Imports Leadtools
Imports Leadtools.Controls
Imports Leadtools.Codecs
Imports Leadtools.Demos.Dialogs

Imports System.IO

Namespace DicomOverlay
   Public Class MainForm : Inherits Form
      Private statusStrip1 As System.Windows.Forms.StatusStrip
      Private menuStrip1 As System.Windows.Forms.MenuStrip
      Private m_splitContainer As System.Windows.Forms.SplitContainer
      Private _mnuFile As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _mnuFileOpen As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _mnuFileSave As System.Windows.Forms.ToolStripMenuItem
      Private toolStripMenuItem1 As System.Windows.Forms.ToolStripSeparator
      Private WithEvents _mnuFileExit As System.Windows.Forms.ToolStripMenuItem
      Private _mnuOverlays As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _mnuOverlaysShowOverlay As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _mnuOverlaysChangeOverlayColor As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _mnuOverlaysSaveOverlay As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _mnuOverlaysShowOverlayAttributes As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _mnuOverlaysInsertOverlay As System.Windows.Forms.ToolStripMenuItem
      Private _mnuHelp As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _mnuHelpAboutOverlay As System.Windows.Forms.ToolStripMenuItem

      Private _PixelElement As DicomElement
      Private _DataSet As DicomDataSet
      Private _overlayColor As Color = Color.White
      Private _rasterImageViewer As ImageViewer
      Private _rasterImageList As ImageViewer
      Private _openInitialPath As String = ""

      <STAThread()> _
      Shared Sub Main()
         
         If Not Support.SetLicense() Then
            Return
         End If

         Application.EnableVisualStyles()
         Application.SetCompatibleTextRenderingDefault(False)
         Application.Run(New MainForm())
      End Sub

      Private components As System.ComponentModel.IContainer = Nothing

      ''' <summary>
      ''' Clean up any resources being used.
      ''' </summary>
      ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
         If disposing AndAlso (Not components Is Nothing) Then
            components.Dispose()
         End If
         MyBase.Dispose(disposing)
      End Sub

      Private Sub InitializeComponent()
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
         Me.statusStrip1 = New System.Windows.Forms.StatusStrip
         Me.menuStrip1 = New System.Windows.Forms.MenuStrip
         Me._mnuFile = New System.Windows.Forms.ToolStripMenuItem
         Me._mnuFileOpen = New System.Windows.Forms.ToolStripMenuItem
         Me._mnuFileSave = New System.Windows.Forms.ToolStripMenuItem
         Me.toolStripMenuItem1 = New System.Windows.Forms.ToolStripSeparator
         Me._mnuFileExit = New System.Windows.Forms.ToolStripMenuItem
         Me._mnuOverlays = New System.Windows.Forms.ToolStripMenuItem
         Me._mnuOverlaysShowOverlay = New System.Windows.Forms.ToolStripMenuItem
         Me._mnuOverlaysChangeOverlayColor = New System.Windows.Forms.ToolStripMenuItem
         Me._mnuOverlaysSaveOverlay = New System.Windows.Forms.ToolStripMenuItem
         Me._mnuOverlaysShowOverlayAttributes = New System.Windows.Forms.ToolStripMenuItem
         Me._mnuOverlaysInsertOverlay = New System.Windows.Forms.ToolStripMenuItem
         Me._mnuHelp = New System.Windows.Forms.ToolStripMenuItem
         Me._mnuHelpAboutOverlay = New System.Windows.Forms.ToolStripMenuItem
         Me.m_splitContainer = New System.Windows.Forms.SplitContainer
         Me.menuStrip1.SuspendLayout()
         Me.m_splitContainer.SuspendLayout()
         Me.SuspendLayout()
         '
         'statusStrip1
         '
         Me.statusStrip1.Location = New System.Drawing.Point(0, 562)
         Me.statusStrip1.Name = "statusStrip1"
         Me.statusStrip1.Size = New System.Drawing.Size(911, 22)
         Me.statusStrip1.TabIndex = 0
         Me.statusStrip1.Text = "statusStrip1"
         '
         'menuStrip1
         '
         Me.menuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._mnuFile, Me._mnuOverlays, Me._mnuHelp})
         Me.menuStrip1.Location = New System.Drawing.Point(0, 0)
         Me.menuStrip1.Name = "menuStrip1"
         Me.menuStrip1.Size = New System.Drawing.Size(911, 24)
         Me.menuStrip1.TabIndex = 1
         Me.menuStrip1.Text = "menuStrip1"
         '
         '_mnuFile
         '
         Me._mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._mnuFileOpen, Me._mnuFileSave, Me.toolStripMenuItem1, Me._mnuFileExit})
         Me._mnuFile.Name = "_mnuFile"
         Me._mnuFile.Size = New System.Drawing.Size(37, 20)
         Me._mnuFile.Text = "&File"
         '
         '_mnuFileOpen
         '
         Me._mnuFileOpen.Name = "_mnuFileOpen"
         Me._mnuFileOpen.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.O), System.Windows.Forms.Keys)
         Me._mnuFileOpen.Size = New System.Drawing.Size(152, 22)
         Me._mnuFileOpen.Text = "&Open"
         '
         '_mnuFileSave
         '
         Me._mnuFileSave.Name = "_mnuFileSave"
         Me._mnuFileSave.ShortcutKeys = CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys)
         Me._mnuFileSave.Size = New System.Drawing.Size(152, 22)
         Me._mnuFileSave.Text = "&Save"
         '
         'toolStripMenuItem1
         '
         Me.toolStripMenuItem1.Name = "toolStripMenuItem1"
         Me.toolStripMenuItem1.Size = New System.Drawing.Size(149, 6)
         '
         '_mnuFileExit
         '
         Me._mnuFileExit.Name = "_mnuFileExit"
         Me._mnuFileExit.Size = New System.Drawing.Size(152, 22)
         Me._mnuFileExit.Text = "E&xit"
         '
         '_mnuOverlays
         '
         Me._mnuOverlays.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._mnuOverlaysShowOverlay, Me._mnuOverlaysChangeOverlayColor, Me._mnuOverlaysSaveOverlay, Me._mnuOverlaysShowOverlayAttributes, Me._mnuOverlaysInsertOverlay})
         Me._mnuOverlays.Name = "_mnuOverlays"
         Me._mnuOverlays.Size = New System.Drawing.Size(64, 20)
         Me._mnuOverlays.Text = "&Overlays"
         '
         '_mnuOverlaysShowOverlay
         '
         Me._mnuOverlaysShowOverlay.Name = "_mnuOverlaysShowOverlay"
         Me._mnuOverlaysShowOverlay.Size = New System.Drawing.Size(201, 22)
         Me._mnuOverlaysShowOverlay.Text = "&Show Overlay"
         '
         '_mnuOverlaysChangeOverlayColor
         '
         Me._mnuOverlaysChangeOverlayColor.Name = "_mnuOverlaysChangeOverlayColor"
         Me._mnuOverlaysChangeOverlayColor.Size = New System.Drawing.Size(201, 22)
         Me._mnuOverlaysChangeOverlayColor.Text = "Change Overlay &Color"
         '
         '_mnuOverlaysSaveOverlay
         '
         Me._mnuOverlaysSaveOverlay.Name = "_mnuOverlaysSaveOverlay"
         Me._mnuOverlaysSaveOverlay.Size = New System.Drawing.Size(201, 22)
         Me._mnuOverlaysSaveOverlay.Text = "&Save Overlay"
         '
         '_mnuOverlaysShowOverlayAttributes
         '
         Me._mnuOverlaysShowOverlayAttributes.Name = "_mnuOverlaysShowOverlayAttributes"
         Me._mnuOverlaysShowOverlayAttributes.Size = New System.Drawing.Size(201, 22)
         Me._mnuOverlaysShowOverlayAttributes.Text = "Show Overlay A&ttributes"
         '
         '_mnuOverlaysInsertOverlay
         '
         Me._mnuOverlaysInsertOverlay.Name = "_mnuOverlaysInsertOverlay"
         Me._mnuOverlaysInsertOverlay.Size = New System.Drawing.Size(201, 22)
         Me._mnuOverlaysInsertOverlay.Text = "&Insert Overlay"
         '
         '_mnuHelp
         '
         Me._mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._mnuHelpAboutOverlay})
         Me._mnuHelp.Name = "_mnuHelp"
         Me._mnuHelp.Size = New System.Drawing.Size(44, 20)
         Me._mnuHelp.Text = "&Help"
         '
         '_mnuHelpAboutOverlay
         '
         Me._mnuHelpAboutOverlay.Name = "_mnuHelpAboutOverlay"
         Me._mnuHelpAboutOverlay.Size = New System.Drawing.Size(159, 22)
         Me._mnuHelpAboutOverlay.Text = "&About Overlay..."
         '
         'm_splitContainer
         '
         Me.m_splitContainer.Dock = System.Windows.Forms.DockStyle.Fill
         Me.m_splitContainer.Location = New System.Drawing.Point(0, 24)
         Me.m_splitContainer.Name = "m_splitContainer"
         Me.m_splitContainer.Size = New System.Drawing.Size(911, 538)
         Me.m_splitContainer.SplitterDistance = 165
         Me.m_splitContainer.TabIndex = 2
         '
         'MainForm
         '
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(911, 584)
         Me.Controls.Add(Me.m_splitContainer)
         Me.Controls.Add(Me.statusStrip1)
         Me.Controls.Add(Me.menuStrip1)
         Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
         Me.MainMenuStrip = Me.menuStrip1
         Me.Name = "MainForm"
         Me.Text = "DICOM Overlay Demo"
         Me.menuStrip1.ResumeLayout(False)
         Me.menuStrip1.PerformLayout()
         Me.m_splitContainer.ResumeLayout(False)
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

      Public Sub New()
         InitializeComponent()
         InitClass()
         InitControls()
         _mnuOverlaysShowOverlay.Checked = True

         If File.Exists(Path.Combine(DemosGlobal.ImagesFolder, "Overlay.dcm")) Then
            OpenDataset(Path.Combine(DemosGlobal.ImagesFolder, "Overlay.dcm"))
         End If
      End Sub

      Private Sub InitClass()
         DicomEngine.Startup()
         Messager.Caption = "LEADTOOLS for .NET VB DICOM Overlay"
         Text = Messager.Caption

         _DataSet = New DicomDataSet()
      End Sub

      Private Sub InitControls()
         Me._rasterImageList = New ImageViewer(New ImageViewerVerticalViewLayout() With {.Columns = 1})
         Me._rasterImageViewer = New ImageViewer
         Me._rasterImageList.BackColor = System.Drawing.SystemColors.Control
         Me._rasterImageList.ViewHorizontalAlignment = ControlAlignment.Center
         Me._rasterImageList.ViewHorizontalAlignment = ControlAlignment.Center
         Me._rasterImageList.ItemSpacing = New LeadSize(20, 20)
         Me._rasterImageList.ItemBorderThickness = 2
         Me._rasterImageList.SelectedItemBorderColor = System.Drawing.Color.Blue
         Me._rasterImageList.BorderStyle = System.Windows.Forms.BorderStyle.None
         Me._rasterImageList.Dock = System.Windows.Forms.DockStyle.Left
         Me._rasterImageList.ItemSize = New LeadSize(160, 160)
         Me._rasterImageList.ItemSizeMode = ControlSizeMode.Fit
         Me._rasterImageList.Location = New System.Drawing.Point(0, 93)
         Me._rasterImageList.Name = "_imageList"
         Me._rasterImageList.Size = New System.Drawing.Size(197, 475)
         Me._rasterImageList.TabIndex = 11
         Me._rasterImageList.InteractiveModes.Add((New ImageViewerSelectItemsInteractiveMode() With {.SelectionMode = ImageViewerSelectionMode.Single}))
         AddHandler Me._rasterImageList.SelectedItemsChanged, AddressOf _rasterImageList_SelectedItemsChanged
         Me.m_splitContainer.Panel1.Controls.Add(Me._rasterImageList)

         Me._rasterImageViewer.Dock = System.Windows.Forms.DockStyle.Fill
         Me._rasterImageViewer.Location = New System.Drawing.Point(0, 0)
         Me._rasterImageViewer.Name = "rasterImageViewer1"
         Me._rasterImageViewer.Size = New System.Drawing.Size(742, 538)
         Me._rasterImageViewer.TabIndex = 0
         Me.m_splitContainer.Panel2.Controls.Add(Me._rasterImageViewer)
      End Sub

      Private Sub _rasterImageList_SelectedItemsChanged(sender As Object, e As EventArgs)
         If (_rasterImageList.Items.GetSelected().Length > 0) Then
            Dim SelectedItems(Me._rasterImageList.Items.GetSelected().Length) As ImageViewerItem
            SelectedItems = Me._rasterImageList.Items.GetSelected()
            Dim selected As Integer = _rasterImageList.Items.IndexOf(SelectedItems(0))
            Dim attributes As RasterOverlayAttributes = _rasterImageViewer.Image.GetOverlayAttributes(selected, RasterGetSetOverlayAttributesFlags.Flags)
            _mnuOverlaysShowOverlay.Checked = attributes.AutoPaint
         End If

      End Sub

      Private Sub _mnuFileOpen_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _mnuFileOpen.Click
         Dim openFileDialog As OpenFileDialog = New OpenFileDialog()
         openFileDialog.Filter = "DICOM Files (*.dcm;*.dic)|*.dcm;*.dic|All files (*.*)|*.*"
         openFileDialog.Title = "Open Dicom File"
         openFileDialog.InitialDirectory = _openInitialPath
         If openFileDialog.ShowDialog() = DialogResult.OK Then
            _openInitialPath = Path.GetDirectoryName(openFileDialog.FileName)
            ' Reset Globals
            ResetGlobals()

            OpenDataset(openFileDialog.FileName)
         End If
      End Sub
      Private Sub OpenDataset(ByVal filename As String)
         Try

            _DataSet.Load(filename, DicomDataSetLoadFlags.LoadAndClose)

            ' Find Pixel Data
            _PixelElement = _DataSet.FindFirstElement(Nothing, DicomTag.PixelData, True)
            If Not _PixelElement Is Nothing Then
               ' Load Base Image 
#If Not LEADTOOLS_V20_OR_LATER Then
               Dim getImageFlags As DicomGetImageFlags = DicomGetImageFlags.AutoApplyModalityLut Or DicomGetImageFlags.AutoApplyVoiLut Or DicomGetImageFlags.AutoScaleModalityLut Or DicomGetImageFlags.AutoScaleVoiLut Or DicomGetImageFlags.AutoDectectInvalidRleCompression Or DicomGetImageFlags.AutoLoadOverlays
#Else
               Dim getImageFlags As DicomGetImageFlags = DicomGetImageFlags.AutoApplyModalityLut Or DicomGetImageFlags.AutoApplyVoiLut Or DicomGetImageFlags.AutoScaleModalityLut Or DicomGetImageFlags.AutoScaleVoiLut Or DicomGetImageFlags.AutoDetectInvalidRleCompression Or DicomGetImageFlags.AutoLoadOverlays
#End If ' #If Not LEADTOOLS_V20_OR_LATER Then

               _rasterImageViewer.Image = _DataSet.GetImage(_PixelElement, 0, 0, RasterByteOrder.Gray, getImageFlags)
               LoadOverlays()
               _mnuOverlaysInsertOverlay.Enabled = True
               _mnuFileSave.Enabled = True
            Else
               Messager.ShowError(Me, "NO Pixel Data")
               _mnuOverlaysInsertOverlay.Enabled = False
               _mnuFileSave.Enabled = False
            End If

         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub
      Private Sub LoadOverlays()
         Try
            If _DataSet.OverlayCount > 0 Then
               Dim i As Integer = 0
               Do While i < _DataSet.OverlayCount
                  Dim item As ImageViewerItem = New ImageViewerItem()
                  item.Size = New LeadSize(100, 100)
                  item.Zoom(ControlSizeMode.FitAlways, 1, _rasterImageList.DefaultZoomOrigin.ToLeadPointD())
                  Dim attribte As RasterOverlayAttributes = _DataSet.GetOverlayAttributes(0)
                  If attribte.FramesInOverlay > 1 Then
                     item.Image = _DataSet.GetOverlayImages(0, 0, attribte.FramesInOverlay)
                  Else
                     ' Add to image list
                     ' item.Image = _DataSet.GetOverlayImage(i)

                     item.Image = _rasterImageViewer.Image.GetOverlayImage(i, RasterGetSetOverlayImageMode.Copy)
                     _rasterImageList.Items.Add(item)
                     _rasterImageList.Items.Select(Nothing)
                     _rasterImageList.Items(i).IsSelected = True

                     ' Add to Viewer               
                     _rasterImageViewer.Image.SetOverlayImage(i, item.Image, RasterGetSetOverlayImageMode.Copy)

                     ' Update Attributes
                     Dim attributes As RasterOverlayAttributes = _rasterImageViewer.Image.GetOverlayAttributes(i, RasterGetSetOverlayAttributesFlags.Flags)
                     attributes.AutoPaint = _mnuOverlaysShowOverlay.Checked
                     attributes.AutoProcess = True
                     attributes.Origin = New LeadPoint(0, 0)
                     attributes.Color = New RasterColor(_overlayColor.R, _overlayColor.G, _overlayColor.B)
                     attributes.Columns = item.Image.ImageWidth
                     attributes.Rows = item.Image.ImageHeight
                     attributes.BitsAllocated = 1
                     attributes.FramesInOverlay = item.Image.PageCount
                     attributes.ImageFrameOrigin = 1
                     attributes.Type = "G"
                     _rasterImageViewer.Image.UpdateOverlayAttributes(i, attributes, RasterGetSetOverlayAttributesFlags.Flags Or RasterGetSetOverlayAttributesFlags.Origin Or RasterGetSetOverlayAttributesFlags.Color Or RasterGetSetOverlayAttributesFlags.Dicom)
                  End If
                  i += 1
               Loop
            Else
               MessageBox.Show("This dataset has no overlays." & Constants.vbNewLine & "To insert a new overlay, please select (Overlays Insert Overlay) from the menu.")
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         Finally
            EnableOverlayOptions()
         End Try
      End Sub

      Private Sub _mnuOverlaysShowOverlay_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _mnuOverlaysShowOverlay.Click
         _mnuOverlaysShowOverlay.Checked = Not _mnuOverlaysShowOverlay.Checked
      End Sub

      Private Sub _mnuOverlaysChangeOverlayColor_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _mnuOverlaysChangeOverlayColor.Click

         Dim clrDlg As ColorDialog = New ColorDialog()
         clrDlg.Color = _overlayColor
         Dim selected As Integer = _rasterImageList.Items.IndexOf(_rasterImageList.Items.GetSelected()(0))

         If clrDlg.ShowDialog() = DialogResult.OK Then
            _overlayColor = clrDlg.Color
            ' Update all overlays with new color            
            Dim attributes As RasterOverlayAttributes = _rasterImageViewer.Image.GetOverlayAttributes(selected, RasterGetSetOverlayAttributesFlags.Color)
            attributes.Color = New RasterColor(_overlayColor.R, _overlayColor.G, _overlayColor.B)
            _rasterImageViewer.Image.UpdateOverlayAttributes(selected, attributes, RasterGetSetOverlayAttributesFlags.Color)
            Dim img As RasterImage = _rasterImageViewer.Image.GetOverlayImage(selected, RasterGetSetOverlayImageMode.Copy)
            img.MakeRegionEmpty()
            Dim aPalette As RasterColor() = {New RasterColor(0, 0, 0), New RasterColor(clrDlg.Color.R, clrDlg.Color.G, clrDlg.Color.B)}
            img.SetPalette(aPalette, 0, 2)
            If Not _rasterImageList Is Nothing Then
               If _rasterImageList.Items.Count > 0 Then
                  _rasterImageList.Items(selected).Image.Dispose()
                  _rasterImageList.Items(selected).Image = img
                  _rasterImageList.Invalidate()
               End If
            End If
         End If
      End Sub

      Private Sub _mnuOverlaysSaveOverlay_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _mnuOverlaysSaveOverlay.Click

         Dim dlg As SaveFileDialog = New SaveFileDialog()
         dlg.Filter = "Windows Bitmap (*.bmp)|*.bmp"
         dlg.FilterIndex = 0

         If dlg.ShowDialog() = DialogResult.OK Then
            Dim selected As Integer = _rasterImageList.Items.IndexOf(_rasterImageList.Items.GetSelected()(0))
            Dim overlay As RasterImage = _rasterImageViewer.Image.GetOverlayImage(selected, RasterGetSetOverlayImageMode.Copy)

            Dim codecs As RasterCodecs = New RasterCodecs()
            codecs.Save(overlay, dlg.FileName, RasterImageFormat.Bmp, overlay.BitsPerPixel)

            codecs.Dispose()
            overlay.Dispose()
         End If
      End Sub

      Private Sub _mnuOverlaysShowOverlayAttributes_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _mnuOverlaysShowOverlayAttributes.Click

         Dim strAttributes As String = String.Empty
         Dim selected As Integer = _rasterImageList.Items.IndexOf(_rasterImageList.Items.GetSelected()(0))

         Dim flags As RasterGetSetOverlayAttributesFlags = RasterGetSetOverlayAttributesFlags.Color Or RasterGetSetOverlayAttributesFlags.BitIndex Or RasterGetSetOverlayAttributesFlags.Dicom Or RasterGetSetOverlayAttributesFlags.Origin Or RasterGetSetOverlayAttributesFlags.Flags
         Dim attributes As RasterOverlayAttributes = _rasterImageViewer.Image.GetOverlayAttributes(selected, flags)

         strAttributes = "Overlay Origin" & Constants.vbTab + Constants.vbTab & "X: " & attributes.Origin.X.ToString() & "  Y: " & attributes.Origin.Y.ToString() & Constants.vbLf
         strAttributes &= "Overlay Color" & Constants.vbTab + Constants.vbTab + attributes.Color.ToRgb().ToString() + Constants.vbLf
         strAttributes &= "Overlay Index" & Constants.vbTab + Constants.vbTab + selected.ToString() & Constants.vbLf
         If attributes.AutoPaint Then
            strAttributes &= "AutoPaint Flag" & Constants.vbTab + Constants.vbTab + ("On") + Constants.vbLf
         Else
            strAttributes &= "AutoPaint Flag" & Constants.vbTab + Constants.vbTab + ("Off") + Constants.vbLf
         End If
         If attributes.AutoProcess Then
            strAttributes &= "AutoProcess Flag" & Constants.vbTab + Constants.vbTab + ("On") + Constants.vbLf
         Else
            strAttributes &= "AutoProcess Flag" & Constants.vbTab + Constants.vbTab + ("Off") + Constants.vbLf
         End If
         If attributes.UseBitPlane Then
            strAttributes &= "UseBitPlane Flag" & Constants.vbTab + Constants.vbTab + ("On") + Constants.vbLf
         Else
            strAttributes &= "UseBitPlane Flag" & Constants.vbTab + Constants.vbTab + ("Off") + Constants.vbLf
         End If
         strAttributes &= "Num. Of Overlay Rows" & Constants.vbTab + attributes.Rows.ToString() & Constants.vbLf
         strAttributes &= "Num. Of Overlay Columns" & Constants.vbTab + attributes.Columns.ToString() & Constants.vbLf
         strAttributes &= "Overlay Type:" & Constants.vbTab + Constants.vbTab + attributes.Type + Constants.vbLf
         strAttributes &= "Num. Of Allocated Bits" & Constants.vbTab + attributes.BitsAllocated.ToString() & Constants.vbLf
         strAttributes &= "Overlay Subtype" & Constants.vbTab + attributes.Subtype + Constants.vbLf
         strAttributes &= "Overlay Label" & Constants.vbTab + attributes.Label + Constants.vbLf
         strAttributes &= "ROI Area" & Constants.vbTab + Constants.vbTab + Constants.vbTab + attributes.RoiArea.ToString() & Constants.vbLf
         strAttributes &= "ROI Mean" & Constants.vbTab + Constants.vbTab + Constants.vbTab + attributes.RoiMean.ToString() & Constants.vbLf
         strAttributes &= "ROI Standard Deviation" & Constants.vbTab + attributes.RoiStandardDeviation.ToString() & Constants.vbLf
         strAttributes &= "Num. Of Overlay Frames" & Constants.vbTab + attributes.FramesInOverlay.ToString() & Constants.vbLf
         strAttributes &= "Image Frame Origin" & Constants.vbTab + Constants.vbTab + attributes.ImageFrameOrigin.ToString() & Constants.vbLf
         strAttributes &= "Overlay Activation Layer" & Constants.vbTab + Constants.vbTab + attributes.ActivationLayer + Constants.vbLf
         strAttributes &= "Overlay Description" & Constants.vbTab + Constants.vbTab + attributes.Description + Constants.vbLf

         MessageBox.Show(strAttributes, "Overlay " & selected & " Attributes")
      End Sub

      Private Sub _mnuOverlaysInsertOverlay_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _mnuOverlaysInsertOverlay.Click
            Try
                Dim dlg As New OpenFileDialog()
                dlg.Filter = "All Files (*.*)|*.*"
                dlg.FilterIndex = 0

                If dlg.ShowDialog() = DialogResult.OK Then
                    Dim overlay As RasterImage
                    Dim codecs As New RasterCodecs()

                    overlay = codecs.Load(dlg.FileName, 1, CodecsLoadByteOrder.Bgr, 1, 1)

                    Dim item As New ImageViewerItem()
                    Dim overlayIndex As Integer

                    ' Add to image list
                    item.Image = overlay
                    _rasterImageList.Items.Add(item)
                    overlayIndex = _rasterImageList.Items.Count - 1
                    _rasterImageList.Items.Select(Nothing) '.SelectAll(false);

                    ' Add to Viewer               
                    _rasterImageViewer.Image.SetOverlayImage(overlayIndex, item.Image, RasterGetSetOverlayImageMode.Copy)

                    ' Update Attributes
                    Dim attributes As RasterOverlayAttributes = _rasterImageViewer.Image.GetOverlayAttributes(overlayIndex, RasterGetSetOverlayAttributesFlags.Flags)
                    attributes.AutoPaint = _mnuOverlaysShowOverlay.Checked
                    attributes.Origin = New LeadPoint(0, 0)
                    attributes.Color = New RasterColor(&HFF, &HFF, &HFF)
                    attributes.Columns = item.Image.ImageWidth
                    attributes.Rows = item.Image.ImageHeight
                    attributes.BitsAllocated = 1
                    attributes.FramesInOverlay = item.Image.PageCount
                    attributes.ImageFrameOrigin = 1
                    attributes.Type = "G"
                    _rasterImageViewer.Image.UpdateOverlayAttributes(overlayIndex, attributes, RasterGetSetOverlayAttributesFlags.Flags Or RasterGetSetOverlayAttributesFlags.Origin Or RasterGetSetOverlayAttributesFlags.Color Or RasterGetSetOverlayAttributesFlags.Dicom)

                    _rasterImageList.Items(overlayIndex).IsSelected = True
                    EnableOverlayOptions()
                End If
            Catch ex As Exception
                Messager.ShowError(Me, ex)
         Finally
            EnableOverlayOptions()
            End Try
        End Sub

      Private Sub rasterImageList1_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
         If _rasterImageList.Items.GetSelected().Length > 0 Then
            Dim selected As Integer = _rasterImageList.Items.IndexOf(_rasterImageList.Items.GetSelected()(0))
            Dim attributes As RasterOverlayAttributes = _rasterImageViewer.Image.GetOverlayAttributes(selected, RasterGetSetOverlayAttributesFlags.Flags)
            _mnuOverlaysShowOverlay.Checked = attributes.AutoPaint
         End If
      End Sub

      Private Sub EnableOverlayOptions()

         Dim bValue As Boolean = _rasterImageList.Items.GetSelected().Length > 0
         _mnuOverlaysShowOverlay.Enabled = bValue
         _mnuOverlaysShowOverlay.Checked = bValue
         _mnuOverlaysChangeOverlayColor.Enabled = bValue
         _mnuOverlaysSaveOverlay.Enabled = bValue
         _mnuOverlaysShowOverlayAttributes.Enabled = bValue
      End Sub


      Private Sub _mnuFileSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _mnuFileSave.Click
         Dim dlg As SaveFileDialog = New SaveFileDialog()
         dlg.Filter = "DCM Files (*.dcm)|*.dcm|All files (*.*)|*.*"
         dlg.FilterIndex = 0

         If dlg.ShowDialog() = DialogResult.OK Then
            ' Get Image Information
            Dim imageInfo As DicomImageInformation = _DataSet.GetImageInformation(_PixelElement, 0)

            ' Replace image information in DicomDataSet
            _DataSet.SetImage(Nothing, _rasterImageViewer.Image, imageInfo.Compression, imageInfo.PhotometricInterpretation, 0, 0, DicomSetImageFlags.AutoSaveOverlays)

            ' Save to disk
            _DataSet.Save(dlg.FileName, DicomDataSetSaveFlags.None)
         End If
      End Sub

      Private Sub ResetGlobals()
         _DataSet.Reset()
         _PixelElement = Nothing
         _overlayColor = Color.White
         _mnuOverlaysShowOverlay.Checked = True

         _rasterImageList.Items.Clear()
         If Not _rasterImageViewer.Image Is Nothing Then
            _rasterImageViewer.Image.Dispose()
         End If
         _rasterImageViewer.Image = Nothing
      End Sub

      Private Sub _mnuHelpAboutOverlay_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _mnuHelpAboutOverlay.Click
         Using aboutDialog As New AboutDialog("DICOM Overlay", ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using
      End Sub

      Private Sub _mnuFileExit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _mnuFileExit.Click
         Application.Exit()
      End Sub

      Private Sub _mnuOverlaysShowOverlay_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _mnuOverlaysShowOverlay.CheckedChanged
         If (_rasterImageList.Items.GetSelected().Length > 0) Then
            Dim selected As Integer = _rasterImageList.Items.IndexOf(_rasterImageList.Items.GetSelected()(0))
            Dim attributes As RasterOverlayAttributes = _rasterImageViewer.Image.GetOverlayAttributes(selected, RasterGetSetOverlayAttributesFlags.Flags)
            attributes.AutoPaint = _mnuOverlaysShowOverlay.Checked
            _rasterImageViewer.Image.UpdateOverlayAttributes(selected, attributes, RasterGetSetOverlayAttributesFlags.Flags)
         End If
      End Sub
   End Class
End Namespace
