' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D

Imports Leadtools
Imports Leadtools.Controls
Imports Leadtools.Drawing

Namespace SharePointDemo
   Partial Public Class ViewerControl : Inherits UserControl

      Private panZoomMode As ImageViewerPanZoomInteractiveMode
      Private zoomToMode As ImageViewerZoomToInteractiveMode
      Private noneMode As ImageViewerNoneInteractiveMode

      Private _minimumViewerScalePercentage As Double = 1
      Private _maximumViewerScalePercentage As Double = 6400

      Public Property NoneInteractiveMode As ImageViewerNoneInteractiveMode
         Get
            Return noneMode
         End Get
         Set(value As ImageViewerNoneInteractiveMode)
            noneMode = value
         End Set
      End Property


      Public Property PanZoomInteractiveMode As ImageViewerPanZoomInteractiveMode
         Get
            Return panZoomMode
         End Get
         Set(value As ImageViewerPanZoomInteractiveMode)
            panZoomMode = value
         End Set
      End Property

      Public Property ZoomToInteractiveMode As ImageViewerZoomToInteractiveMode
         Get
            Return zoomToMode
         End Get
         Set(value As ImageViewerZoomToInteractiveMode)
            zoomToMode = value
         End Set
      End Property

      Public Sub New()
         InitializeComponent()

         InitViewer()

         InitInteractiveModes()

         ' Use ScaleToGray paint
         Dim props As RasterPaintProperties = _ImageViewer.PaintProperties
         props.PaintDisplayMode = props.PaintDisplayMode Or RasterPaintDisplayModeFlags.ScaleToGray
         _ImageViewer.PaintProperties = props

         ' Pad the viewer
         ' Pad the viewer
         _ImageViewer.ViewPadding = New Padding(10)

         _zoomToSelectionToolStripButton.PerformClick()

         ' These events are needed and not visible from the designer, so
         ' hook into them here
         AddHandler _zoomToolStripComboBox.LostFocus, AddressOf _zoomToolStripComboBox_LostFocus
         AddHandler _pageToolStripTextBox.LostFocus, AddressOf _pageToolStripTextBox_LostFocus
      End Sub

      Private Sub InitViewer()
         _ImageViewer = New ImageViewer()
         _ImageViewer.BackColor = SystemColors.AppWorkspace
         _ImageViewer.BorderStyle = BorderStyle.None
         _ImageViewer.Dock = DockStyle.Fill
         _ImageViewer.ViewHorizontalAlignment = ControlAlignment.Center
         _ImageViewer.ViewVerticalAlignment = ControlAlignment.Center
         _ImageViewer.UseDpi = True
         AddHandler _ImageViewer.TransformChanged, AddressOf _ImageViewer_TransformChanged
         Controls.Add(_ImageViewer)
         _ImageViewer.BringToFront()
         _ImageViewer.Zoom(ControlSizeMode.Fit, 1, _ImageViewer.DefaultZoomOrigin)
      End Sub

      Private Sub InitInteractiveModes()
         _ImageViewer.InteractiveModes.BeginUpdate()
         _ImageViewer.InteractiveModes.Clear()

         noneMode = New ImageViewerNoneInteractiveMode()
         noneMode.IdleCursor = Cursors.Arrow
         noneMode.WorkingCursor = Cursors.Arrow
         noneMode.IsEnabled = True
         _ImageViewer.InteractiveModes.Add(noneMode)

         panZoomMode = New ImageViewerPanZoomInteractiveMode()
         panZoomMode.IdleCursor = Cursors.Hand
         panZoomMode.WorkingCursor = Cursors.Hand
         panZoomMode.IsEnabled = False
         panZoomMode.WorkOnBounds = True
         _ImageViewer.InteractiveModes.Add(panZoomMode)

         zoomToMode = New ImageViewerZoomToInteractiveMode()
         zoomToMode.IdleCursor = Cursors.Cross
         zoomToMode.WorkingCursor = Cursors.Cross
         zoomToMode.IsEnabled = False
         zoomToMode.WorkOnBounds = True
         _ImageViewer.InteractiveModes.Add(zoomToMode)

         _ImageViewer.InteractiveModes.EndUpdate()
      End Sub



      Protected Overrides Sub OnLoad(ByVal e As EventArgs)
         ' Call the transform changed
         _ImageViewer_TransformChanged(_ImageViewer, EventArgs.Empty)

         MyBase.OnLoad(e)
      End Sub

      Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
         _titleLabel.Text = Text

         MyBase.OnTextChanged(e)
      End Sub

      Public Event OpenFileClicked As EventHandler(Of EventArgs)

      Private Sub _openFileToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _openFileToolStripButton.Click
         If Not OpenFileClickedEvent Is Nothing Then
            RaiseEvent OpenFileClicked(Me, e)
         End If
      End Sub

      Public Event UploadClicked As EventHandler(Of EventArgs)

      Private Sub _uploadToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _uploadToolStripButton.Click
         If Not UploadClickedEvent Is Nothing Then
            RaiseEvent UploadClicked(Me, e)
         End If
      End Sub

      Private Sub _ImageViewer_TransformChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _ImageViewer.TransformChanged
         If IsHandleCreated Then
            UpdateZoomComboBoxValueFromViewer()
            UpdateMyControls()
         End If
      End Sub

      Private Delegate Sub UpdateMeDelagate()

      Private Sub UpdateZoomComboBoxValueFromViewer()
         ' We are invoking this instead of changing the properties
         ' directly because the Text value of a combo box is not updated
         ' till after the lost focus or enter event is exited
         Me.BeginInvoke(New UpdateMeDelagate(AddressOf UpdateMe))
      End Sub

      Private Sub UpdateMe()
         If Not _ImageViewer.Image Is Nothing Then
            Dim factor As Double = _ImageViewer.XScaleFactor * 100.0
            _zoomToolStripComboBox.Text = factor.ToString("F1") & "%"

            If ((_ImageViewer.XScaleFactor * 100) > _maximumViewerScalePercentage AndAlso _
               _ImageViewer.DefaultInteractiveMode Is zoomToMode) Then
               SetMode(noneMode)
            End If

         Else
            _zoomToolStripComboBox.Text = String.Empty
         End If
      End Sub

      Private Sub UpdateMyControls()
         If Not _ImageViewer.Image Is Nothing Then
            _uploadToolStripButton.Enabled = True

            Dim page As Integer = _ImageViewer.Image.Page
            Dim pageCount As Integer = _ImageViewer.Image.PageCount

            _pageToolStripTextBox.Text = page.ToString()
            _pageToolStripLabel.Enabled = True
            _pageToolStripLabel.Text = "/ " & pageCount.ToString()

            _previousPageToolStripButton.Enabled = page > 1
            _nextPageToolStripButton.Enabled = page < pageCount

            _pageToolStripTextBox.Enabled = True
            _zoomOutToolStripButton.Enabled = True
            _zoomInToolStripButton.Enabled = True
            _zoomToolStripComboBox.Enabled = True
            _fitPageWidthToolStripButton.Enabled = True
            _fitPageToolStripButton.Enabled = True
            _selectModeToolStripButton.Enabled = True
            _panModeToolStripButton.Enabled = True

            _fitPageWidthToolStripButton.Checked = _ImageViewer.SizeMode = ControlSizeMode.FitWidth
            _fitPageToolStripButton.Checked = _ImageViewer.SizeMode = ControlSizeMode.Fit

            _selectModeToolStripButton.Checked = noneMode.IsEnabled
            _panModeToolStripButton.Checked = panZoomMode.IsEnabled
            _zoomToSelectionToolStripButton.Checked = zoomToMode.IsEnabled
            _zoomToSelectionToolStripButton.Enabled = (_ImageViewer.XScaleFactor * 100) < _maximumViewerScalePercentage
         Else
            _pageToolStripTextBox.Text = "0"
            _pageToolStripLabel.Text = "/ 0"

            _fitPageWidthToolStripButton.Checked = False
            _fitPageToolStripButton.Checked = False

            _zoomToolStripComboBox.Text = String.Empty

            _uploadToolStripButton.Enabled = False
            _previousPageToolStripButton.Enabled = False
            _nextPageToolStripButton.Enabled = False
            _pageToolStripTextBox.Enabled = False
            _pageToolStripLabel.Enabled = False
            _zoomOutToolStripButton.Enabled = False
            _zoomInToolStripButton.Enabled = False
            _zoomToolStripComboBox.Enabled = False
            _fitPageWidthToolStripButton.Enabled = False
            _fitPageToolStripButton.Enabled = False
            _selectModeToolStripButton.Enabled = False
            _panModeToolStripButton.Enabled = False
            _zoomToSelectionToolStripButton.Enabled = False
         End If
      End Sub

      Private Sub _previousPageToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _previousPageToolStripButton.Click
         MoveToPage(True)
      End Sub

      Private Sub _nextPageToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _nextPageToolStripButton.Click
         MoveToPage(False)
      End Sub

      Public Sub MoveToPage(ByVal previous As Boolean)
         If _ImageViewer.Image Is Nothing Then
            Return
         End If

         If previous Then
            SetPage(_ImageViewer.Image.Page - 1)
         Else
            SetPage(_ImageViewer.Image.Page + 1)
         End If
      End Sub

      Private Sub _pageToolStripTextBox_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
         _pageToolStripTextBox.Text = _ImageViewer.Image.Page.ToString()
      End Sub

      Private Sub _pageToolStripTextBox_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles _pageToolStripTextBox.KeyPress
         If e.KeyChar = ControlChars.Cr Then
            ' User has pressed enter
            ' Get the new page numebr

            Dim str As String = _pageToolStripTextBox.Text.Trim()

            ' Try to parse the integer value
            Dim page As Integer
            If Integer.TryParse(str, page) Then
               SetPage(page)
            End If

            _pageToolStripTextBox.Text = _ImageViewer.Image.Page.ToString()
         End If
      End Sub

      Private Sub SetPage(ByVal page As Integer)
         If page >= 1 AndAlso page <= _ImageViewer.Image.PageCount Then
            _ImageViewer.Image.Page = page
            UpdateMyControls()
         End If
      End Sub

      Private Sub _zoomOutToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _zoomOutToolStripButton.Click
         ZoomViewer(True)
      End Sub

      Private Sub _zoomInToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _zoomInToolStripButton.Click
         ZoomViewer(False)
      End Sub

      Private Sub _zoomToolStripComboBox_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
         UpdateZoomComboBoxValueFromViewer()
      End Sub

      Private Sub _zoomToolStripComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _zoomToolStripComboBox.SelectedIndexChanged
         Dim str As String = _zoomToolStripComboBox.Text.ToString()

         If str = "Actual Size" Then
            SetViewerZoomPercentage(100)
         ElseIf str = "Fit Page" Then
            _fitPageToolStripButton.PerformClick()
         ElseIf str = "Fit Width" Then
            _fitPageWidthToolStripButton.PerformClick()
         Else
            Dim val As Double = Double.Parse(str.Substring(0, str.Length - 1))
            SetViewerZoomPercentage(val)
         End If
      End Sub

      Private Sub _zoomToolStripComboBox_KeyPress(ByVal sender As Object, ByVal e As KeyPressEventArgs) Handles _zoomToolStripComboBox.KeyPress
         If e.KeyChar = ControlChars.Cr Then
            ' User has pressed enter
            ' Get the new scale factor

            Dim str As String = _zoomToolStripComboBox.Text.Trim()

            ' Remove the % sign if present
            If str.EndsWith("%") Then
               str = str.Remove(str.Length - 1, 1)
            End If
            str = str.Trim()

            ' Try to parse the double value
            Dim percentage As Double
            If Double.TryParse(str, percentage) Then
               SetViewerZoomPercentage(percentage)
            End If

            UpdateZoomComboBoxValueFromViewer()
         End If
      End Sub

      Public Sub ZoomViewer(ByVal zoomOut As Boolean)
         ' Get the current scale factor
         Dim percentage As Double = _ImageViewer.XScaleFactor * 100.0

         ' The valid scale factors
         Dim validPercentages As Double() = {_minimumViewerScalePercentage, 6.25, 12.5, 25, 33.3, 50, 66.7, 73.6, 92.5, 100, 125, 150, 200, 300, 400, 600, 800, 1200, 1600, 2400, 3200, _maximumViewerScalePercentage}

         ' Find out where we are, move to the next one up or down
         If zoomOut Then
            For i As Integer = validPercentages.Length - 1 To 0 Step -1
               If percentage > validPercentages(i) Then
                  percentage = validPercentages(i)
                  Exit For
               End If
            Next i
         Else
            Dim i As Integer = 0
            Do While i < validPercentages.Length
               If percentage < validPercentages(i) Then
                  percentage = validPercentages(i)
                  Exit Do
               End If
               i += 1
            Loop
         End If

         SetViewerZoomPercentage(percentage)
      End Sub

      Private Sub SetViewerZoomPercentage(ByVal percentage As Double)
         ' Normalize the percentage based on min/max value allowed
         percentage = Math.Max(_minimumViewerScalePercentage, Math.Min(_maximumViewerScalePercentage, percentage))

         If (Math.Abs(_ImageViewer.XScaleFactor * 100 - percentage) > 0.01) Then
            ' Save the current center location in the viewer. We will zoom center
            _ImageViewer.BeginUpdate()

            ' Zoom
            Dim scaleFactor As Double = percentage / 100.0

            _ImageViewer.Zoom(ControlSizeMode.None, scaleFactor, _ImageViewer.DefaultZoomOrigin)

            _ImageViewer.EndUpdate()

            UpdateMyControls()
         End If
      End Sub

      Private Sub _fitPageWidthToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _fitPageWidthToolStripButton.Click
         FitPage(True)
      End Sub

      Private Sub _fitPageToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _fitPageToolStripButton.Click
         FitPage(False)
      End Sub

      Public Sub FitPage(ByVal fitWidth As Boolean)
         If _ImageViewer.Image Is Nothing Then
            Return
         End If

         Dim scaleFactor As Double = 1
         Dim sizeMode As ControlSizeMode = ControlSizeMode.Fit

         If (fitWidth) Then
            sizeMode = ControlSizeMode.FitWidth
         End If

         _ImageViewer.Zoom(sizeMode, scaleFactor, _ImageViewer.DefaultZoomOrigin)

         UpdateMyControls()
      End Sub

      Private Sub _selectModeToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _selectModeToolStripButton.Click
         SetMode(noneMode)
      End Sub

      Private Sub _panModeToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _panModeToolStripButton.Click
         SetMode(panZoomMode)
      End Sub

      Private Sub _zoomToSelectionToolStripButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _zoomToSelectionToolStripButton.Click
         SetMode(zoomToMode)
      End Sub

      Public Sub SetMode(ByVal modeToSet As ImageViewerInteractiveMode)
         If _ImageViewer.Image Is Nothing Then
            Return
         End If

         _ImageViewer.InteractiveModes.BeginUpdate()
         Dim i As Integer = 1
         For Each mode As ImageViewerInteractiveMode In _ImageViewer.InteractiveModes
            If (mode Is modeToSet) Then
               mode.IsEnabled = True
            Else
               mode.IsEnabled = False
            End If
         Next
         _ImageViewer.InteractiveModes.EndUpdate()

         UpdateMyControls()
      End Sub

      Public Property RasterImage() As RasterImage
         Get
            Return _ImageViewer.Image
         End Get
         Set(ByVal value As RasterImage)
            _ImageViewer.Image = value
            UpdateMyControls()
         End Set
      End Property

      Public ReadOnly Property RasterImageViewer() As ImageViewer
         Get
            Return _ImageViewer
         End Get
      End Property
   End Class
End Namespace
