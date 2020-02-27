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
Imports System.Diagnostics
Imports System.Reflection

Imports Leadtools
Imports Leadtools.Barcode
Imports BarcodeMainDemo.Leadtools.Demos

Partial Public Class ReadBarcodesDialogBox : Inherits Form
   Private _barcodeEngine As BarcodeEngine
   Private _userSelectedSymbologies As BarcodeSymbology()
   Private _symbologies As BarcodeSymbology()
   Private _rasterImage As RasterImage
   Private _currentPageOnly As Boolean
   Private _bounds As LeadRect
   Private _extraUseAllSymbologies As Boolean = True
   Private _extraUseBothDirections As Boolean = True
   Private _extraUseDoublePass As Boolean = True
   Private _extraUsePreprocessing As Boolean = True

   Private _isAborted As Boolean
   Private _isWorking As Boolean

   Private _documentBarcodes As DocumentBarcodes
   Public ReadOnly Property DocumentBarcodes() As DocumentBarcodes
      Get
         Return _documentBarcodes
      End Get
   End Property

   Private _showReadBarcodeOptions As Boolean
   Public ReadOnly Property ShowReadBarcodeOptions() As Boolean
      Get
         Return _showReadBarcodeOptions
      End Get
   End Property

   Public Sub New(ByVal barcodeEngine As BarcodeEngine, ByVal symbologies As BarcodeSymbology(), ByVal image As RasterImage, ByVal currentPageOnly As Boolean, ByVal bounds As LeadRect)
      InitializeComponent()

      _barcodeEngine = barcodeEngine
      _symbologies = symbologies
      _userSelectedSymbologies = symbologies
      _rasterImage = image
      _currentPageOnly = currentPageOnly
      _bounds = bounds
      _showReadBarcodeOptions = False
   End Sub

   Protected Overrides Sub OnLoad(ByVal e As EventArgs)
      If (Not DesignMode) Then
         _isWorking = True

         BeginInvoke(New MethodInvoker(AddressOf DoReadBarcodes))
      End If

      MyBase.OnLoad(e)
   End Sub

   ' Stop watch to use in timing
   Private _stopWatch As Stopwatch
   Private _currentPageNumber As Integer
   Private _lastPageNumber As Integer

   Private Sub DoReadBarcodes()
      _documentBarcodes = New DocumentBarcodes()
      _barcodesListView.Groups.Clear()
      _barcodesListView.Items.Clear()

      _infoLabel.Text = DemosGlobalization.GetResxString(Me.GetType(), "Resx_SearchingForBarcode")
      _retryLinkLabel.Visible = False
      _retryLinkLabel.Enabled = False
      _messageLabel.Visible = True
      _messageLabel.Text = String.Empty
      _showReadOptionsDialogCheckBox.Visible = False
      _stopButton.DialogResult = DialogResult.None
      _stopButton.Text = "&Stop"
      Me.AcceptButton = Nothing
      Me.CancelButton = Nothing
      _isWorking = True

      Application.DoEvents()

      Dim firstPageNumber As Integer
      Dim lastPageNumber As Integer

      If _currentPageOnly Then
         firstPageNumber = _rasterImage.Page
         lastPageNumber = _rasterImage.Page
      Else
         firstPageNumber = 1
         lastPageNumber = _rasterImage.PageCount
      End If

      Dim [error] As Exception = Nothing
      _stopWatch = New Stopwatch()

      _lastPageNumber = lastPageNumber

      Dim pageNumber As Integer = firstPageNumber
      Do While pageNumber <= lastPageNumber AndAlso (Not _isAborted) AndAlso [error] Is Nothing
         _currentPageNumber = pageNumber
         UpdateMessageLabel(Nothing)
         Application.DoEvents()

         Dim savePageNumber As Integer = -1

         If _rasterImage.Page <> pageNumber Then
            _rasterImage.DisableEvents()
            savePageNumber = _rasterImage.Page
            _rasterImage.Page = pageNumber
         End If

         ' Continue on errors
         _barcodeEngine.Reader.ErrorMode = BarcodeReaderErrorMode.IgnoreAll
         AddHandler _barcodeEngine.Reader.ReadSymbology, AddressOf Reader_ReadSymbology

         Try
            Dim barcodes As BarcodeData() = _barcodeEngine.Reader.ReadBarcodes(_rasterImage, _bounds, 0, _symbologies, Nothing)

            Dim pageBarcodes As PageBarcodes = New PageBarcodes()
            For Each barcode As BarcodeData In barcodes
               pageBarcodes.Barcodes.Add(barcode)
            Next barcode

            _documentBarcodes.Pages.Add(pageBarcodes)
         Catch ex As Exception
            [error] = ex
         Finally
            If savePageNumber <> -1 Then
               _rasterImage.EnableEvents()
               _rasterImage.Page = savePageNumber
            End If

            RemoveHandler _barcodeEngine.Reader.ReadSymbology, AddressOf Reader_ReadSymbology
            _barcodeEngine.Reader.ErrorMode = BarcodeReaderErrorMode.Default
         End Try
         pageNumber += 1
      Loop

      _messageLabel.Visible = False
      _retryLinkLabel.Visible = True
      _retryLinkLabel.Enabled = True

      Dim count As Integer = 0
      For Each pageBarcodes As PageBarcodes In _documentBarcodes.Pages
         count += pageBarcodes.Barcodes.Count
      Next pageBarcodes

      If count > 0 Then
         _infoLabel.Text = String.Format(DemosGlobalization.GetResxString(Me.GetType(), "Resx_DoneBarcode"), count)
      Else
         _infoLabel.Text = String.Format(DemosGlobalization.GetResxString(Me.GetType(), "Resx_DoneNoBarcode"))
      End If

      If Not [error] Is Nothing Then
         _stopButton.DialogResult = DialogResult.Cancel
         MessageBox.Show(Me, [error].Message, DemosGlobalization.GetResxString(Me.GetType(), "Resx_Error"), MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
      End If

      If count = 0 AndAlso [error] Is Nothing Then
         _showReadOptionsDialogCheckBox.Visible = True
      End If

      _stopButton.Text = "C&lose"
      _stopButton.DialogResult = System.Windows.Forms.DialogResult.OK
      Me.AcceptButton = _stopButton
      Me.CancelButton = _stopButton
      _isWorking = False
      _stopButton.Focus()
   End Sub

   Private Sub UpdateMessageLabel(ByVal readOptions As BarcodeReadOptions)
      If Not readOptions Is Nothing Then
         _messageLabel.Text = String.Format(DemosGlobalization.GetResxString(Me.GetType(), "Resx_ReadingBarcode"), readOptions.FriendlyName, _currentPageNumber, _lastPageNumber)
      Else
         _messageLabel.Text = String.Format(DemosGlobalization.GetResxString(Me.GetType(), "Resx_ReadingBarcodes"), _currentPageNumber, _lastPageNumber)
      End If
   End Sub

   Private Sub Reader_ReadSymbology(ByVal sender As Object, ByVal e As BarcodeReadSymbologyEventArgs)
      Dim firstInGroup As Boolean
      Dim ms As Double = 0

      Select Case e.Operation
         Case BarcodeReadSymbologyOperation.PreRead
            UpdateMessageLabel(e.Options)
            _stopWatch.Start()

         Case BarcodeReadSymbologyOperation.PostRead
            If _stopWatch.IsRunning Then
               _stopWatch.Stop()
               ms = _stopWatch.ElapsedMilliseconds
               _stopWatch.Reset()
               firstInGroup = True
            Else
               firstInGroup = False
            End If

            ' Add this item to the list
            If Not e.Data Is Nothing Then
               If firstInGroup Then
                  Dim group As ListViewGroup = New ListViewGroup(String.Format(DemosGlobalization.GetResxString(Me.GetType(), "Resx_GroupRead"), ms))
                  _barcodesListView.Groups.Add(group)
               End If

               Dim item As ListViewItem = New ListViewItem()
               item.Text = _currentPageNumber.ToString()
               item.SubItems.Add(BarcodeEngine.GetSymbologyFriendlyName(e.Data.Symbology))

               Dim value As String = String.Empty
               Dim location As String = String.Empty

               Dim data As BarcodeData = e.Data
               If Not data Is Nothing Then
                  value = data.Value
                  If value Is Nothing Then
                     value = String.Empty
                  End If

                  location = String.Format("{0}, {1}, {2}, {3}", data.Bounds.Left, data.Bounds.Top, data.Bounds.Right, data.Bounds.Bottom)
               ElseIf Not e.Error Is Nothing Then
                  value = e.Error.Message
               End If

               Dim eciData As String = Nothing
               If data.Symbology = BarcodeSymbology.QR OrElse data.Symbology = BarcodeSymbology.MicroQR Then
                  eciData = BarcodeData.ParseECIData(data.GetData())
               End If

               If Not String.IsNullOrEmpty(eciData) Then
                  item.SubItems.Add(eciData)
               Else
                  item.SubItems.Add(value)
               End If
               item.SubItems.Add(location)

               item.Group = _barcodesListView.Groups(_barcodesListView.Groups.Count - 1)
               _barcodesListView.Items.Add(item)
            End If
      End Select

      Application.DoEvents()

      If _isAborted Then
         e.Status = BarcodeReadSymbologyStatus.Abort
      End If
   End Sub

   Protected Overrides Sub OnFormClosing(ByVal e As FormClosingEventArgs)
      If _isWorking Then
         e.Cancel = True
      End If

      MyBase.OnFormClosing(e)
   End Sub

   Private Sub _stopButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _stopButton.Click
      If _isWorking Then
         _isAborted = True
      End If
   End Sub

   Protected Overrides Sub OnFormClosed(ByVal e As FormClosedEventArgs)
      If _showReadOptionsDialogCheckBox.Visible Then
         _showReadBarcodeOptions = _showReadOptionsDialogCheckBox.Checked
      End If

      MyBase.OnFormClosed(e)
   End Sub

   Private Sub _retryLinkLabel_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles _retryLinkLabel.LinkClicked
      Dim dlg As ReadBarcodeExtraDialogBox = New ReadBarcodeExtraDialogBox()
      Try
         dlg.UseAllSymbologies = _extraUseAllSymbologies
         dlg.UseBothDirections = _extraUseBothDirections
         dlg.UseDoublePass = _extraUseDoublePass
         dlg.UsePreprocessing = _extraUsePreprocessing

         If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            _extraUseAllSymbologies = dlg.UseAllSymbologies
            _extraUseBothDirections = dlg.UseBothDirections
            _extraUseDoublePass = dlg.UseDoublePass
            _extraUsePreprocessing = dlg.UsePreprocessing

            If _extraUseAllSymbologies Then
               _symbologies = _barcodeEngine.Reader.GetAvailableSymbologies()
            Else
               _symbologies = _userSelectedSymbologies
            End If

            Dim searchDirection As BarcodeSearchDirection
            If (_extraUseBothDirections) Then
               searchDirection = BarcodeSearchDirection.HorizontalAndVertical
            Else
               searchDirection = BarcodeSearchDirection.Horizontal
            End If
            Dim useDoublePass As Boolean
            If (_extraUseDoublePass) Then
               useDoublePass = True
            Else
               useDoublePass = False
            End If

            Dim usePreprocessing As Boolean
            If (_extraUsePreprocessing) Then
               usePreprocessing = True
            Else
               usePreprocessing = False
            End If

            If _extraUseBothDirections OrElse _extraUseDoublePass OrElse _extraUsePreprocessing Then
               Dim allReadOptions As BarcodeReadOptions() = _barcodeEngine.Reader.GetAllDefaultOptions()

               For Each readOptions As BarcodeReadOptions In allReadOptions
                  Dim type As Type = readOptions.GetType()

                  If type Is GetType(OneDBarcodeReadOptions) Then
                     CType(IIf(TypeOf readOptions Is OneDBarcodeReadOptions, readOptions, Nothing), OneDBarcodeReadOptions).SearchDirection = searchDirection
                     CType(IIf(TypeOf readOptions Is OneDBarcodeReadOptions, readOptions, Nothing), OneDBarcodeReadOptions).EnableDoublePass = useDoublePass
                     CType(IIf(TypeOf readOptions Is OneDBarcodeReadOptions, readOptions, Nothing), OneDBarcodeReadOptions).EnablePreprocessing = usePreprocessing
                  ElseIf type Is GetType(FourStateBarcodeReadOptions) Then
                     CType(IIf(TypeOf readOptions Is FourStateBarcodeReadOptions, readOptions, Nothing), FourStateBarcodeReadOptions).SearchDirection = searchDirection
                  ElseIf type Is GetType(GS1DatabarStackedBarcodeReadOptions) Then
                     CType(IIf(TypeOf readOptions Is GS1DatabarStackedBarcodeReadOptions, readOptions, Nothing), GS1DatabarStackedBarcodeReadOptions).SearchDirection = searchDirection
                  ElseIf type Is GetType(PatchCodeBarcodeReadOptions) Then
                     CType(IIf(TypeOf readOptions Is PatchCodeBarcodeReadOptions, readOptions, Nothing), PatchCodeBarcodeReadOptions).SearchDirection = searchDirection
                  ElseIf type Is GetType(PostNetPlanetBarcodeReadOptions) Then
                     CType(IIf(TypeOf readOptions Is PostNetPlanetBarcodeReadOptions, readOptions, Nothing), PostNetPlanetBarcodeReadOptions).SearchDirection = searchDirection
                  ElseIf type Is GetType(MicroPDF417BarcodeReadOptions) Then
                     CType(IIf(TypeOf readOptions Is MicroPDF417BarcodeReadOptions, readOptions, Nothing), MicroPDF417BarcodeReadOptions).EnableDoublePassIfSuccess = useDoublePass
                     CType(IIf(TypeOf readOptions Is MicroPDF417BarcodeReadOptions, readOptions, Nothing), MicroPDF417BarcodeReadOptions).SearchDirection = searchDirection
                     CType(IIf(TypeOf readOptions Is MicroPDF417BarcodeReadOptions, readOptions, Nothing), MicroPDF417BarcodeReadOptions).EnablePreprocessing = usePreprocessing
                  ElseIf type Is GetType(PDF417BarcodeReadOptions) Then
                     CType(IIf(TypeOf readOptions Is PDF417BarcodeReadOptions, readOptions, Nothing), PDF417BarcodeReadOptions).EnableDoublePassIfSuccess = useDoublePass
                     CType(IIf(TypeOf readOptions Is PDF417BarcodeReadOptions, readOptions, Nothing), PDF417BarcodeReadOptions).SearchDirection = searchDirection
                     CType(IIf(TypeOf readOptions Is PDF417BarcodeReadOptions, readOptions, Nothing), PDF417BarcodeReadOptions).EnablePreprocessing = usePreprocessing
                  ElseIf type Is GetType(DatamatrixBarcodeReadOptions) Then
                     CType(IIf(TypeOf readOptions Is DatamatrixBarcodeReadOptions, readOptions, Nothing), DatamatrixBarcodeReadOptions).EnableDoublePassIfSuccess = useDoublePass
                     CType(IIf(TypeOf readOptions Is DatamatrixBarcodeReadOptions, readOptions, Nothing), DatamatrixBarcodeReadOptions).EnablePreprocessing = usePreprocessing
                  ElseIf type Is GetType(QRBarcodeReadOptions) Then
                     CType(IIf(TypeOf readOptions Is QRBarcodeReadOptions, readOptions, Nothing), QRBarcodeReadOptions).EnableDoublePassIfSuccess = useDoublePass
                     CType(IIf(TypeOf readOptions Is QRBarcodeReadOptions, readOptions, Nothing), QRBarcodeReadOptions).EnablePreprocessing = usePreprocessing
                  End If
               Next readOptions
            End If

            ' Ret-try reading using these options
            BeginInvoke(New MethodInvoker(AddressOf DoReadBarcodes))
         End If
      Finally
         CType(dlg, IDisposable).Dispose()
      End Try
   End Sub
End Class
