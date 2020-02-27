' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO
Imports System.Runtime.InteropServices

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Controls
Imports Leadtools.ImageProcessing
Imports Leadtools.Ocr
Imports Leadtools.Document.Writer
Imports Leadtools.ScreenCapture
Imports Leadtools.Drawing
Imports Leadtools.Demos.Dialogs


Namespace OcrScreenCaptureDemo
   Partial Public Class MainForm : Inherits Form
#Region "UI Code"
      Private _imageViewer As ImageViewer = Nothing ' The LEADTOOLS ImageViewer control
      Public Sub New()
         InitializeComponent()

         ' Setup the caption for this demo
         Messager.Caption = "VB OCR Screen Capture Demo"
         Me.Text = Messager.Caption

         ' Create the LEADTOOLS ImageViewer
         _imageViewer = New ImageViewer()
         ' Add it to the Form
         _splitContainer.Panel1.Controls.Add(_imageViewer)
         ' Set the display propertiesF
         _imageViewer.BeginUpdate()
         _imageViewer.Dock = DockStyle.Fill
         _imageViewer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
         _imageViewer.Cursor = System.Windows.Forms.Cursors.Default
         _imageViewer.ViewHorizontalAlignment = ControlAlignment.Center
         _imageViewer.ViewVerticalAlignment = ControlAlignment.Center
         _imageViewer.ItemHorizontalAlignment = ControlAlignment.Center
         _imageViewer.ItemVerticalAlignment = ControlAlignment.Center
         ' Set the layout
         _imageViewer.ViewLayout = New ImageViewerSingleViewLayout()
         _imageViewer.EndUpdate()
         ' Hook up the Mouse Events
         AddHandler _imageViewer.MouseDown, AddressOf imageViewer_MouseDown
         AddHandler _imageViewer.MouseMove, AddressOf imageViewer_MouseMove
         AddHandler _imageViewer.MouseUp, AddressOf imageViewer_MouseUp
         AddHandler _imageViewer.MouseLeave, AddressOf imageViewer_MouseLeave
         AddHandler _imageViewer.KeyDown, AddressOf imageViewer_KeyDown
         '		 #End Region ' LEADTOOLS ImageViewer
      End Sub

#Region "Main Form Events"
      Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
         Me.MinimumSize = New Size(545, 455)

         Dim sysMenuHandle As IntPtr = GetSystemMenu(Me.Handle, False)
         InsertMenu(sysMenuHandle, -1, MF_BYPOSITION Or MF_SEPARATOR, 0, String.Empty)
         InsertMenu(sysMenuHandle, -1, MF_BYPOSITION, IDM_ABOUT, "About...")

         Try
            ' Set up the Screen Capture
            ScreenCaptureEngine.Startup()
            _screenCaptureEngine = New ScreenCaptureEngine()
            AddHandler _screenCaptureEngine.CaptureInformation, AddressOf captureCallback

            ' Set up the OCR
            _ocrEngine = OcrEngineManager.CreateEngine(OcrEngineType.LEAD, False)

            ' Start up the OCR engine
#If LT_CLICKONCE Then
			_ocrEngine.Startup(Nothing, Nothing, Nothing, Application.StartupPath & "\OCR Engine")
#Else
            _ocrEngine.Startup(Nothing, Nothing, Nothing, Nothing)
#End If ' #if LT_CLICKONCE

            ' Load the OCR settings
            LoadOcrSettings(_ocrEngine)

            _ocrEngine.SettingManager.SetBooleanValue("Recognition.ShareOriginalImage", False) 'this demo does not support the sharing mode

            ' Load application settings
            Dim mySettings As My.Settings = New My.Settings()
            For Each ts As ToolStripMenuItem In _tsCaptureBtn.DropDownItems
               selectedScreenCapture = mySettings.CaptureArea
               If ts.Name = selectedScreenCapture Then
                  ts.Checked = True
               End If
            Next ts
            _tsUseHotkey.Checked = mySettings.UseHotKey
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub

      Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
         StopDrawing()

         ScreenCaptureEngine.Shutdown()

         If Not _ocrEngine Is Nothing Then
            _ocrEngine.Shutdown()
         End If

         Dim mySettings As My.Settings = New My.Settings()
         mySettings.UseHotKey = _tsUseHotkey.Checked
         mySettings.CaptureArea = selectedScreenCapture
         mySettings.Save()
      End Sub
#End Region ' Main Form Events

#Region "Button Events"
      Private showMessagebox As Boolean = False
      Private Sub buttonScreenCapture_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _tsCaptureBtn.ButtonClick
         If _tsUseHotkey.Checked AndAlso (Not showMessagebox) Then
            Dim myMessageBox As MyMessageBox = New MyMessageBox("Hotkey Capture", "Press F11 to start capture")
            myMessageBox.Show(Me)
            showMessagebox = myMessageBox.Checked
         End If

         EnableUI(False)
         System.Threading.Thread.Sleep(500)
         Try
            ' Capture an area from the screen
            Dim image As RasterImage = DoCapture(_tsUseHotkey.Checked)

            Me.BringToFront()

            Dim colorRes As ColorResolutionCommand = New ColorResolutionCommand(ColorResolutionCommandMode.InPlace, 24, RasterByteOrder.Bgr, RasterDitheringMethod.None, ColorResolutionCommandPaletteFlags.Fixed, Nothing)
            colorRes.Run(image)

            EnableUI(True)
            If Not image Is Nothing Then
               ClearImage()
               _richTextBox.Clear()
               ' Store the new image
               _imageViewer.Image = image

               ' Set the image to the PictureBox
               UpdateViewer()

               ' OCR the image and get back an RTF file
               Dim rtf As String = DoOcr(_imageViewer.Image)

               If (Not String.IsNullOrEmpty(rtf)) Then
                  Try
                     ' Load the RTF file
                     _richTextBox.LoadFile(rtf)
                  Finally
                     ' Delete the RTF file
                     If System.IO.File.Exists(rtf) Then
                        System.IO.File.Delete(rtf)
                     End If
                  End Try
               End If
            End If
         Catch ex As Exception
            Dim rasex As RasterException = CType(IIf(TypeOf ex Is RasterException, ex, Nothing), RasterException)
            If Not rasex Is Nothing Then
               If rasex.Code <> RasterExceptionCode.UserAbort Then
                  Messager.ShowError(Me, ex)
               End If
            Else
               Messager.ShowError(Me, ex)
            End If
         End Try
      End Sub

      Private Sub buttonCopyImage_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _tsCopyImageBtn.Click
         CopyImage()
      End Sub

      Private Sub buttonCopyText_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _tsCopyTextBtn.Click
         CopyText()
      End Sub

      Private Sub buttonSaveText_Click(sender As Object, e As EventArgs) Handles _tsSaveTextBtn.Click
         SaveText()
      End Sub

      Private Sub buttonSaveImage_Click(sender As Object, e As EventArgs) Handles _tsSaveImageBtn.Click
         SaveImage()
      End Sub

      Private Sub buttonOcrOptions_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _tsOCROptionsBtn.Click
         Dim dlg As EngineSettingsDialog = New EngineSettingsDialog(_ocrEngine)
         dlg.ShowDialog()
         _ocrEngine.SettingManager.SetBooleanValue("Recognition.ShareOriginalImage", False) 'this demo does not support the sharing mode
         SaveOcrSettings(_ocrEngine)
      End Sub

      Private Sub _tsCaptureBtnItem_Clicked(ByVal sender As Object, ByVal e As EventArgs) Handles freehandArea.Click, rectangleArea.Click, windowCapture.Click, fullscreenCapture.Click
         Dim ts As ToolStripMenuItem = CType(IIf(TypeOf sender Is ToolStripMenuItem, sender, Nothing), ToolStripMenuItem)

         'uncheck all items in collection
         For Each items As ToolStripMenuItem In _tsCaptureBtn.DropDownItems
            items.Checked = False
         Next items

         'check the selected option
         ts.Checked = True

         selectedScreenCapture = ts.Name
      End Sub

      Private Sub _tsDrawingChoice_Click(ByVal sender As Object, ByVal e As EventArgs) Handles penToolStripMenuItem.Click, highlighterToolStripMenuItem.Click
         Dim ts As ToolStripMenuItem = CType(IIf(TypeOf sender Is ToolStripMenuItem, sender, Nothing), ToolStripMenuItem)

         For Each items As ToolStripMenuItem In _tsDrawingChoice.DropDownItems
            items.Checked = False
         Next items

         ts.Checked = True
      End Sub
#End Region ' Button Events

#Region "LEADTOOLS ImageViewer Mouse Events"
      Private Sub imageViewer_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
         StartDrawing(e.Location)
      End Sub

      Private Sub imageViewer_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs)
         If Not _imageViewer.Image Is Nothing Then
            If highlighterToolStripMenuItem.Checked Then
               _imageViewer.Cursor = _highlighterCursor
            Else
               _imageViewer.Cursor = _penCursor
            End If
         End If

         Dim newPoint As Point = e.Location
         Draw(newPoint, highlighterToolStripMenuItem.Checked)
         _oldPoint = newPoint
      End Sub

      Private Sub imageViewer_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
         StopDrawing()
      End Sub

      Private Sub imageViewer_MouseLeave(ByVal sender As Object, ByVal e As EventArgs)
         StopDrawing()
      End Sub

      Private Sub imageViewer_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
         If e.KeyCode = Keys.C AndAlso e.Control Then
            CopyImage()
         End If

         If e.KeyCode = Keys.Z AndAlso e.Control Then
            Dim image As RasterImage = Undo()
            If Not image Is Nothing Then
               _imageViewer.Image = image
            End If
         End If
      End Sub

#End Region ' LEADTOOLS ImageViewer Mouse Events

#Region "Splitter Events"
      Private Sub splitContainer_SplitterMoved(ByVal sender As Object, ByVal e As SplitterEventArgs) Handles _splitContainer.SplitterMoved
      End Sub
#End Region ' Splitter Events

#Region "UI Tools"
      Private Sub EnableUI(ByVal enable As Boolean)
         _tsCaptureBtn.Enabled = enable
         _tsCopyTextBtn.Enabled = enable
         _tsCopyImageBtn.Enabled = enable
         _tsSaveTextBtn.Enabled = enable
         _tsSaveImageBtn.Enabled = enable
         _tsOCROptionsBtn.Enabled = enable

         _tsUseHotkey.Enabled = enable

         If (Not enable) Then
            Me.SendToBack()
         Else
            Me.BringToFront()
         End If
      End Sub

      Private Sub UpdateViewer()
         _imageViewer.Refresh()
      End Sub

      Private Sub ClearImage()
         ' Dispose the old viewer image
         If Not _imageViewer.Image Is Nothing Then
            _imageViewer.Image.Dispose()
         End If
         _imageViewer.Image = Nothing

         ' Cleanup the undo list
         Do While _undo.Count > 0
            _undo(_undo.Count - 1).Dispose()
            _undo.RemoveAt(_undo.Count - 1)
         Loop
      End Sub
#End Region ' UI Tools

#End Region ' UI Code

#Region "Settings Code"
      Private Function GetSettingsFile() As String
         Dim name As String = System.Reflection.Assembly.GetEntryAssembly().GetName().Name
         Return String.Format("{0}.Ocr.settings", name)
      End Function

      Private Sub SaveOcrSettings(ByVal ocrEngine As IOcrEngine)
         If Not ocrEngine Is Nothing Then
            Try
               ocrEngine.SettingManager.Save(System.IO.Path.Combine(Application.StartupPath, GetSettingsFile()))
            Catch
            End Try
         End If
      End Sub

      Private Sub LoadOcrSettings(ByVal ocrEngine As IOcrEngine)
         If Not ocrEngine Is Nothing Then
            Try
               ocrEngine.SettingManager.Load(System.IO.Path.Combine(Application.StartupPath, GetSettingsFile()))
            Catch
            End Try
         End If
      End Sub
#End Region ' Settings Code

#Region "Screen Capture Code"
      Private _screenCaptureEngine As ScreenCaptureEngine = Nothing ' The LEADTOOLS Screen Capture Engine
      ' Callback for Screen Capture
      Private Sub captureCallback(ByVal sender As Object, ByVal e As ScreenCaptureInformationEventArgs)
         e.Cancel = False
      End Sub

      Private selectedScreenCapture As String
      ' Use LEADTOOLS to capture an area of the screen
      Private Function DoCapture(ByVal useHotkey As Boolean) As RasterImage
         ' Use default options for the capture process
         Dim screenCaptureOptions As ScreenCaptureOptions = _screenCaptureEngine.CaptureOptions
         ' Use default options for the area to capture
         Dim screenCaptureAreaOptions As ScreenCaptureAreaOptions = ScreenCaptureEngine.DefaultCaptureAreaOptions

         If useHotkey Then
            screenCaptureOptions.Hotkey = Keys.F11
         Else
            screenCaptureOptions.Hotkey = Keys.None
         End If

         _screenCaptureEngine.CaptureOptions = screenCaptureOptions

         Select Case selectedScreenCapture
            Case "rectangularArea"
               screenCaptureAreaOptions.AreaType = ScreenCaptureAreaType.Rectangle
               Return _screenCaptureEngine.CaptureArea(screenCaptureAreaOptions, Nothing)
            Case "freehandArea"
               screenCaptureAreaOptions.AreaType = ScreenCaptureAreaType.Freehand
               Return _screenCaptureEngine.CaptureArea(screenCaptureAreaOptions, Nothing)
            Case "windowCapture"
               Dim objectOptions As ScreenCaptureObjectOptions = ScreenCaptureEngine.DefaultCaptureObjectOptions
               Return _screenCaptureEngine.CaptureSelectedObject(objectOptions, Nothing)
            Case "fullscreenCapture"
               Return _screenCaptureEngine.CaptureFullScreen(Nothing)
            Case Else
               Return _screenCaptureEngine.CaptureArea(screenCaptureAreaOptions, Nothing)
         End Select

      End Function
#End Region ' Screen Capture Code

#Region "OCR Code"
      Private _ocrEngine As IOcrEngine = Nothing ' The LEADTOOLS OCR Engine

      ' Use LEADTOOLS to OCR the image and get back text (RTF)
      Private Function DoOcr(ByVal image As RasterImage) As String
         Me.Cursor = Cursors.WaitCursor
         Dim temp As String = System.IO.Path.GetTempFileName() ' temp file for the RTF

         If image Is Nothing Then
            Return String.Empty
         End If

         ' Create a page from the image
         Dim page As IOcrPage = _ocrEngine.CreatePage(image, OcrImageSharingMode.None)
         Try
            ' Get the text
            page.Recognize(Nothing)

            ' Create a document and add the page
            Dim document As IOcrDocument = _ocrEngine.DocumentManager.CreateDocument(Nothing, OcrCreateDocumentOptions.AutoDeleteFile)
            Try
               ' Add the page
               document.Pages.Add(page)
               Try
                  ' Save as RTF
                  document.Save(temp, DocumentFormat.Rtf, Nothing)
               Catch ex As Exception
                  If System.IO.File.Exists(temp) Then
                     System.IO.File.Delete(temp) ' delete the temp file on error
                  End If
                  Throw ex ' re-throw the error
               End Try
            Finally
               CType(document, IDisposable).Dispose()
            End Try
         Finally
            CType(page, IDisposable).Dispose()
         End Try
         Me.Cursor = Cursors.Default
         Return temp
      End Function
#End Region ' OCR Code

#Region "Clipboard Code"
      ' Copy the image to the clipboard
      Private Sub CopyImage()
         If Not _imageViewer.Image Is Nothing Then
            Try
               RasterClipboard.Copy(Me.Handle, _imageViewer.Image, RasterClipboardCopyFlags.Dib Or RasterClipboardCopyFlags.Bitmap Or RasterClipboardCopyFlags.Empty)
            Catch ex As Exception
               Messager.ShowError(Me, ex)
            End Try
         End If
      End Sub

      ' Copy the text (RTF) to the clipboard
      Private Sub CopyText()
         ' save selection start point and length to restore them after we copy the whole text.
         Dim selectionStart As Integer = _richTextBox.SelectionStart
         Dim selectionLength As Integer = _richTextBox.SelectionLength

         _richTextBox.SelectAll()
         _richTextBox.Copy()

         ' restore the selected text
         _richTextBox.SelectionStart = selectionStart
         _richTextBox.SelectionLength = selectionLength
      End Sub
#End Region ' Clipboard Code


#Region "Save Code"
      Private Sub SaveImage()
         If _imageViewer.Image IsNot Nothing Then
            Try
               Dim dlg As New SaveFileDialog()
               dlg.Filter = "PNG | *.png"
               If dlg.ShowDialog() = DialogResult.OK Then
                  Using codecs As New RasterCodecs()
                     codecs.Save(_imageViewer.Image, dlg.FileName, RasterImageFormat.Png, 0)
                  End Using
               End If
            Catch ex As Exception
               Messager.ShowError(Me, ex)
            End Try
         End If
      End Sub

      Private Sub SaveText()
         If _richTextBox.TextLength > 0 Then
            Dim dlg As New SaveFileDialog()
            dlg.Filter = "RTF | *.rtf"
            If dlg.ShowDialog() = DialogResult.OK Then
               _richTextBox.SaveFile(dlg.FileName, RichTextBoxStreamType.RichText)
            End If
         End If
      End Sub

#End Region ' Save Code

#Region "Drawing Code"
#Region "dllImport"
      <DllImport("gdi32.dll")> _
      Shared Function LineTo(ByVal hdc As IntPtr, ByVal nXEnd As Integer, ByVal nYEnd As Integer) As Boolean
      End Function
      <DllImport("gdi32.dll")> _
      Shared Function CreatePen(ByVal fnPenStyle As Integer, ByVal nWidth As Integer, ByVal crColor As UInteger) As IntPtr
      End Function
      <DllImport("gdi32.dll")> _
      Shared Function MoveToEx(ByVal hdc As IntPtr, ByVal X As Integer, ByVal Y As Integer, ByVal lpPoint As IntPtr) As Boolean
      End Function
      <DllImport("Gdi32.dll")> _
      Public Shared Function SelectObject(ByVal hdc As IntPtr, ByVal hObject As IntPtr) As IntPtr
      End Function
      <DllImport("gdi32.dll")> _
      Private Shared Function DeleteObject(hObject As IntPtr) As <MarshalAs(UnmanagedType.Bool)> Boolean
      End Function
      <DllImport("gdi32.dll")> _
      Shared Function SetROP2(ByVal hdc As IntPtr, ByVal fnDrawMode As Integer) As Integer
      End Function
#End Region ' dllImport
      Private _drawing As Boolean = False
      Private _oldPoint As Point = Point.Empty
      Private _highlighterCursor As Cursor = New Cursor(New MemoryStream(Global.OcrScreenCaptureDemo.Resources.highlight))
      Private _penCursor As Cursor = New Cursor(New MemoryStream(Global.OcrScreenCaptureDemo.Resources.pen))
      Private imageHDC As IntPtr = IntPtr.Zero
      Private _highlightWin32Pen As IntPtr = CreatePen(0, 10, CUInt(&H8000FFFFL)) 'yellow win32 pen
      Private _redWin32Pen As IntPtr = CreatePen(0, 2, CUInt(&H80000FF)) 'red win32 pen

      ' Translate Point From Control to RasterImage
      Private Function TranslatePoint(ByVal viewer As ImageViewer, ByVal image As RasterImage, ByVal point As Point) As Point
         If Not image Is Nothing AndAlso Not viewer Is Nothing Then
            Dim leadPoint As LeadPoint = New LeadPoint(point.X, point.Y)
            leadPoint = viewer.ConvertPoint(viewer.Items(0), ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, leadPoint)
            point.X = leadPoint.X
            point.Y = leadPoint.Y
         End If
         Return point
      End Function

      ' Start the drawing process
      Private Sub StartDrawing(ByVal point As Point)
         If _drawing Then
            Return
         End If

         If _imageViewer.Image Is Nothing Then
            Return
         End If

         AddUndoItem(_imageViewer.Image)

         _oldPoint = point
         _drawing = True
      End Sub

      ' Draw on the viewer control and the image
      Private Sub Draw(ByVal point As Point, ByVal useHighlighter As Boolean)
         If (Not _drawing) Then
            Return
         End If

         Dim pen As IntPtr
         If useHighlighter Then
            pen = _highlightWin32Pen
         Else
            pen = _redWin32Pen
         End If
         Dim mixMode As Integer
         If useHighlighter Then
            mixMode = 9
         Else
            mixMode = 13
         End If

         Dim point1 As Point = TranslatePoint(_imageViewer, _imageViewer.Image, _oldPoint)
         Dim point2 As Point = TranslatePoint(_imageViewer, _imageViewer.Image, point)

         imageHDC = RasterImagePainter.CreateLeadDC(_imageViewer.Image)
         SetROP2(imageHDC, mixMode)
         DeleteObject(SelectObject(imageHDC, pen))
         MoveToEx(imageHDC, point1.X, point1.Y, IntPtr.Zero)
         LineTo(imageHDC, point2.X, point2.Y)
         RasterImagePainter.DeleteLeadDC(imageHDC)
      End Sub

      ' Stop the drawing process
      Private Sub StopDrawing()
         If (Not _drawing) Then
            Return
         End If

         _drawing = False

         UpdateViewer()
      End Sub
#End Region ' Drawing Code

#Region "Undo Code"
      Private _undo As List(Of RasterImage) = New List(Of RasterImage)()

      ' Add an item to the undo list
      Private Sub AddUndoItem(ByVal image As RasterImage)
         If Not image Is Nothing Then
            _undo.Add(image.Clone()) ' add a copy of the image
         End If
      End Sub

      ' Remove the last undo item from the list and return it
      Private Function Undo() As RasterImage
         Dim image As RasterImage = Nothing
         If _undo.Count > 0 Then
            Dim index As Integer = _undo.Count - 1
            image = _undo(index)
            _undo.RemoveAt(index)
         End If
         Return image
      End Function

#End Region ' Undo Code

#Region "System Menu Code"
      <DllImport("user32.dll")> _
      Private Shared Function GetSystemMenu(ByVal hWnd As IntPtr, ByVal bRevert As Boolean) As IntPtr
      End Function
      <DllImport("user32.dll")> _
      Private Shared Function InsertMenu(ByVal hMenu As IntPtr, ByVal wPosition As Int32, ByVal wFlags As Int32, ByVal wIDNewItem As Int32, ByVal lpNewItem As String) As Boolean
      End Function

      Public Const WM_SYSCOMMAND As Int32 = &H112
      Public Const MF_SEPARATOR As Int32 = &H800
      Public Const MF_BYPOSITION As Int32 = &H400
      Public Const MF_STRING As Int32 = &H0
      Public Const IDM_ABOUT As Int32 = 1000

      Protected Overrides Sub WndProc(ByRef m As Message)
         If m.Msg = WM_SYSCOMMAND Then
            Select Case m.WParam.ToInt32()
               Case IDM_ABOUT
                  Using aboutDialog As New AboutDialog("OCR Screen Capture", ProgrammingInterface.VB)
                     aboutDialog.ShowDialog(Me)
                  End Using
                  Return
               Case Else
            End Select
         End If
         MyBase.WndProc(m)
      End Sub
#End Region ' System Menu Code

#Region "My Custom Message Box"
      Public Class MyMessageBox : Inherits Form
#Region "Private Data"
         Private _label As System.Windows.Forms.Label
         Private WithEvents _button As System.Windows.Forms.Button
         Private _checkBox As System.Windows.Forms.CheckBox
         Private _size As Size = New Size(250, 100)
         Private _margin As Size = New Size(10, 20)
         Private _title As String
         Private _message As String
#End Region ' Private Data

#Region "Public Properties"
         Public Property Title() As String
            Get
               Return _title
            End Get
            Set(value As String)
               _title = value
            End Set
         End Property

         Public Property Message() As String
            Get
               Return _message
            End Get
            Set(value As String)
               _message = value
            End Set
         End Property

         Public ReadOnly Property Checked() As Boolean
            Get
               Return _checkBox.Checked
            End Get
         End Property
#End Region ' Public Properties

#Region "Initialization"
         Public Sub New()
            InitializeComponent()
         End Sub

         Public Sub New(ByVal title_Renamed As String, ByVal message_Renamed As String)
            Me.Title = title_Renamed
            Me.Message = message_Renamed
            InitializeComponent()
         End Sub

         Private Sub InitializeComponent()
            Me._label = New System.Windows.Forms.Label()
            Me._button = New System.Windows.Forms.Button()
            Me._checkBox = New System.Windows.Forms.CheckBox()
            Me.SuspendLayout()
            ' 
            ' _label
            ' 
            Me._label.Location = New Point(Me._margin)
            Me._label.Size = New System.Drawing.Size(_size.Width - Me._label.Location.X * 2, 30)
            Me._label.Name = "_textBox"
            Me._label.Text = Me._message
            Me._label.TextAlign = ContentAlignment.TopCenter
            ' 
            ' _button
            ' 
            Me._button.Size = New System.Drawing.Size(75, 23)
            Me._button.Location = New System.Drawing.Point(Me._size.Width - Me._margin.Width - Me._button.Size.Width, Me._size.Height - Me._margin.Height - Me._button.Size.Height)
            Me._button.Name = "_button"
            Me._button.TabIndex = 0
            Me._button.Text = "OK"
            Me._button.UseVisualStyleBackColor = True
            ' 
            ' _checkBox
            ' 
            Me._checkBox.AutoSize = True
            Me._checkBox.Location = New System.Drawing.Point(Me._margin.Width, Me._button.Location.Y)
            Me._checkBox.Name = "_checkBox"
            Me._checkBox.Size = New System.Drawing.Size(80, 17)
            Me._checkBox.TabIndex = 1
            Me._checkBox.Text = "Don't show this again"
            Me._checkBox.UseVisualStyleBackColor = True
            Me._checkBox.Checked = False
            ' 
            ' MyMessageBox
            ' 
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
            Me.ClientSize = Me._size
            Me.Controls.Add(Me._button)
            Me.Controls.Add(Me._label)
            Me.Controls.Add(Me._checkBox)
            Me._checkBox.BringToFront()
            Me.Name = "MyMessageBox"
            Me.Text = Me._title
            Me.ResumeLayout(False)
            Me.PerformLayout()

         End Sub
#End Region ' Initialization

#Region "Event Handlers"
         Private Sub button_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _button.Click,_button.Click
            Me.Close()
         End Sub

         Private Sub MyMessageBox_Load(ByVal sender As Object, ByVal e As EventArgs)Handles Me.Load
            If Not Me.Owner Is Nothing Then
               Me.Location = New Point(CInt(Me.Owner.Location.X + (Me.Owner.Width / 2) - (Me.Width / 2)), CInt(Me.Owner.Location.Y + (Me.Owner.Height / 2) - (Me.Height / 2)))
            End If
         End Sub
#End Region ' Event Handlers

#Region "Overrides"
         Public Shadows Sub Show()
            ShowDialog()
         End Sub
         Public Shadows Sub Show(ByVal owner As IWin32Window)
            ShowDialog(owner)
         End Sub
#End Region ' Overrides
      End Class
#End Region ' My Custom Message Box
   End Class

End Namespace
