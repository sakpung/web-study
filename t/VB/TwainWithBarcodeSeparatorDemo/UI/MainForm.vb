' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.IO

Imports Leadtools
Imports Leadtools.Twain
Imports Leadtools.Codecs
Imports Leadtools.Controls
Imports Leadtools.Drawing
Imports Leadtools.Barcode
Imports Leadtools.Demos.Dialogs

Namespace TwainWithBarcodeSeparatorDemo
   Partial Public Class MainForm : Inherits Form
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.IContainer = Nothing

      Public Sub New()
         Dim startDlg As StartUpDialog = New StartUpDialog()
         If startDlg.ShowStartUpDialog Then
            startDlg.ShowDialog()
         End If

         InitializeComponent()

         InitClass()
      End Sub

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

#Region "Windows Form Designer generated code"

      ''' <summary>
      ''' Required method for Designer support - do not modify
      ''' the contents of this method with the code editor.
      ''' </summary>
      Private Sub InitializeComponent()
         Me.components = New System.ComponentModel.Container()
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
         Me._mainMenu = New System.Windows.Forms.MainMenu(Me.components)
         Me._menuItemFile = New System.Windows.Forms.MenuItem()
         Me._menuItemFileSelectSource = New System.Windows.Forms.MenuItem()
         Me._menuItemFileAcuire = New System.Windows.Forms.MenuItem()
         Me._menuItemFileExit = New System.Windows.Forms.MenuItem()
         Me._menuItemPage = New System.Windows.Forms.MenuItem()
         Me._menuItemPageFirst = New System.Windows.Forms.MenuItem()
         Me._menuItemPagePrevious = New System.Windows.Forms.MenuItem()
         Me._menuItemPageNext = New System.Windows.Forms.MenuItem()
         Me._menuItemPageLast = New System.Windows.Forms.MenuItem()
         Me._menuItemOptions = New System.Windows.Forms.MenuItem()
         Me._menuItemOptionsSetSeparatorString = New System.Windows.Forms.MenuItem()
         Me._menuItemOptionsSetResultsPath = New System.Windows.Forms.MenuItem()
         Me._menuItemHelp = New System.Windows.Forms.MenuItem()
         Me._menuItemHelpAbout = New System.Windows.Forms.MenuItem()
         Me._sbMain = New System.Windows.Forms.StatusBar()
         Me.SuspendLayout()
         ' 
         ' _mainMenu
         ' 
         Me._mainMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemFile, Me._menuItemPage, Me._menuItemOptions, Me._menuItemHelp})
         ' 
         ' _menuItemFile
         ' 
         Me._menuItemFile.Index = 0
         Me._menuItemFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemFileSelectSource, Me._menuItemFileAcuire, Me._menuItemFileExit})
         Me._menuItemFile.Text = "&File"
         ' 
         ' _menuItemFileSelectSource
         ' 
         Me._menuItemFileSelectSource.Index = 0
         Me._menuItemFileSelectSource.Text = "&Select Source..."
         ' 
         ' _menuItemFileAcuire
         ' 
         Me._menuItemFileAcuire.Index = 1
         Me._menuItemFileAcuire.Text = "&Acquire..."
         ' 
         ' _menuItemFileExit
         ' 
         Me._menuItemFileExit.Index = 2
         Me._menuItemFileExit.Text = "E&xit"
         ' 
         ' _menuItemPage
         ' 
         Me._menuItemPage.Index = 1
         Me._menuItemPage.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemPageFirst, Me._menuItemPagePrevious, Me._menuItemPageNext, Me._menuItemPageLast})
         Me._menuItemPage.Text = "&Page"
         ' 
         ' _menuItemPageFirst
         ' 
         Me._menuItemPageFirst.Index = 0
         Me._menuItemPageFirst.Text = "&First"
         ' 
         ' _menuItemPagePrevious
         ' 
         Me._menuItemPagePrevious.Index = 1
         Me._menuItemPagePrevious.Text = "&Previous"
         ' 
         ' _menuItemPageNext
         ' 
         Me._menuItemPageNext.Index = 2
         Me._menuItemPageNext.Text = "&Next"
         ' 
         ' _menuItemPageLast
         ' 
         Me._menuItemPageLast.Index = 3
         Me._menuItemPageLast.Text = "&Last"
         ' 
         ' _menuItemOptions
         ' 
         Me._menuItemOptions.Index = 2
         Me._menuItemOptions.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemOptionsSetSeparatorString, Me._menuItemOptionsSetResultsPath})
         Me._menuItemOptions.Text = "&Options"
         ' 
         ' _menuItemOptionsSetSeparatorString
         ' 
         Me._menuItemOptionsSetSeparatorString.Index = 0
         Me._menuItemOptionsSetSeparatorString.Text = "Set Separator String"
         ' 
         ' _menuItemOptionsSetResultsPath
         ' 
         Me._menuItemOptionsSetResultsPath.Index = 1
         Me._menuItemOptionsSetResultsPath.Text = "Set Results Path"
         ' 
         ' _menuItemHelp
         ' 
         Me._menuItemHelp.Index = 3
         Me._menuItemHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemHelpAbout})
         Me._menuItemHelp.Text = "&Help"
         ' 
         ' _menuItemHelpAbout
         ' 
         Me._menuItemHelpAbout.Index = 0
         Me._menuItemHelpAbout.Text = "&About..."
         ' 
         ' _sbMain
         ' 
         Me._sbMain.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F)
         Me._sbMain.Location = New System.Drawing.Point(0, 326)
         Me._sbMain.Name = "_sbMain"
         Me._sbMain.Size = New System.Drawing.Size(558, 22)
         Me._sbMain.TabIndex = 2
         ' 
         ' MainForm
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0F, 15.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(558, 348)
         Me.Controls.Add(Me._sbMain)
         Me.Font = New System.Drawing.Font("Courier New", 9.0F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, (CByte(0)))
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
         Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
         Me.Margin = New System.Windows.Forms.Padding(4)
         Me.Menu = Me._mainMenu
         Me.Name = "MainForm"
         Me.Text = "MainForm"
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private _mainMenu As System.Windows.Forms.MainMenu
      Private _menuItemFile As System.Windows.Forms.MenuItem
      Private WithEvents _menuItemFileExit As System.Windows.Forms.MenuItem
      Private _menuItemHelp As System.Windows.Forms.MenuItem
      Private WithEvents _menuItemHelpAbout As System.Windows.Forms.MenuItem
      Private WithEvents _menuItemFileSelectSource As System.Windows.Forms.MenuItem
      Private WithEvents _menuItemFileAcuire As System.Windows.Forms.MenuItem
      Private _seperatorStringDlg As SeperatorStringDialog
      Private _viewer As ImageViewer
      Private _twnSession As TwainSession = Nothing
      Private _codecs As RasterCodecs

      'SaveFilesCount variable is used to count the number of files
      'to be saved to the disk when calling the Acquire method
      Private _saveFilesCount As Integer

      'TwainSaveFilePath variable is the twain images save path
      Private _twainSaveFilePath As String

      'TwainSaveFileName variable is the name of the current save file
      Private _twainSaveFileName As String
      Private _menuItemOptions As MenuItem
      Private WithEvents _menuItemOptionsSetSeparatorString As MenuItem
      Private WithEvents _menuItemOptionsSetResultsPath As MenuItem
      Private _menuItemPage As MenuItem
      Private WithEvents _menuItemPageFirst As MenuItem
      Private WithEvents _menuItemPagePrevious As MenuItem
      Private WithEvents _menuItemPageNext As MenuItem
      Private WithEvents _menuItemPageLast As MenuItem
      Private _sbMain As StatusBar

      Public _transferMode As TwainTransferMechanism = TwainTransferMechanism.Native

      <STAThread()> _
      Shared Sub Main()
         
         If Not Support.SetLicense() Then
            Return
         End If

         Application.EnableVisualStyles()
         Application.SetCompatibleTextRenderingDefault(False)
         Application.Run(New MainForm())
      End Sub

      Private Sub InitClass()
         Messager.Caption = "LEADTOOLS for .Net VB TwainWithBarcodeSeparator Demo"
         Text = Messager.Caption
      End Sub

      Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
         Try
            Dim bTwainAvailable As Boolean = TwainSession.IsAvailable(Me.Handle)
            If bTwainAvailable Then
               'Initialize codecs object
               _codecs = New RasterCodecs()

               'Initialize the number of Files to be saved using Twain
               _saveFilesCount = 0 'Variable

               _twainSaveFilePath = DemosGlobal.ImagesFolder
               'Set the name of the first file to be saved using Twain 
               _twainSaveFileName = ChangeSaveFileName("") 'variable

               'Initialize the twnSession object
               _twnSession = New TwainSession()

               ' For 32-bit driver support in 64-bit applications, use the following TWAIN initialization method instead:
               '_twnSession.Startup(Me.Handle, "LEADTOOLS", "LEADTOOLS for .NET", String.Empty, "TwainWithBarcodeSeparatorDemo", TwainStartupFlags.UseThunkServer)

               'Start the twnSession object
               _twnSession.Startup(Me.Handle, "LEADTOOLS", "LEADTOOLS for .NET", String.Empty, "TwainWithBarcodeSeparatorDemo", TwainStartupFlags.None)
               'handle the AcquirePage event
               AddHandler _twnSession.AcquirePage, AddressOf Twain_AcquirePage

               _seperatorStringDlg = New SeperatorStringDialog()

               InitViewer()
               UpdateControls()
               UpdateStatusBarText()
            End If
            EnableControls(bTwainAvailable)
         Catch ex As TwainException
            If ex.Code = TwainExceptionCode.InvalidDll Then
               Messager.ShowError(Me, "You have an old version of TWAINDSM.DLL. Please download latest version of this DLL from www.twain.org")
            Else
               Messager.ShowError(Me, ex)
            End If

            EnableControls(False)
         End Try
      End Sub

      Private Sub InitViewer()
         'set the properties to control the display of
         'the image on the rasterImageViewer control
         _viewer = New ImageViewer()
         Dim props As RasterPaintProperties = New RasterPaintProperties()
         props = _viewer.PaintProperties
         props.PaintDisplayMode = RasterPaintDisplayModeFlags.ScaleToGray Or RasterPaintDisplayModeFlags.Resample
         _viewer.PaintProperties = props
         _viewer.Dock = DockStyle.Fill
         Me.Controls.Add(_viewer)
         _viewer.BringToFront()
      End Sub

      Private Sub EnableControls(ByVal bEnable As Boolean)
         Me._menuItemFileSelectSource.Enabled = bEnable
         Me._menuItemFileAcuire.Enabled = bEnable
         Me._menuItemOptions.Enabled = bEnable
         Me._menuItemPage.Enabled = bEnable
      End Sub

      Private Sub _menuItemFileSelectSource_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemFileSelectSource.Click
         Try
            'Selct the Twain source
            _twnSession.SelectSource(String.Empty)
         Catch ex As Exception
            Messager.ShowError(Me, ex.Message)
         End Try
      End Sub

      Private Sub _menuItemFileAcuire_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemFileAcuire.Click
         If (Not DemosGlobal.CheckKnown3rdPartyTwainIssues(Me, _twnSession.SelectedSourceName())) Then
            Return
         End If
         If Directory.Exists(_twainSaveFilePath) Then
            Using cursor As WaitCursor = New WaitCursor()
               Try
                  If Not _viewer.Image Is Nothing Then
                     _viewer.Image.Dispose()
                  End If

                  _twainSaveFileName = ChangeSaveFileName(_saveFilesCount.ToString())
                  'Call the Acquire method to start the scanning process
                  If _twnSession.Acquire(TwainUserInterfaceFlags.Show) <> DialogResult.OK Then
                     Messager.ShowError(Me, "Error Acquiring From Source")
                  Else
                     _saveFilesCount += 1
                     _twainSaveFileName = ChangeSaveFileName(_saveFilesCount.ToString())
                  End If
               Catch ex As Exception
                  Messager.ShowError(Me, ex.Message)
               Finally
                  UpdateControls()
                  UpdateStatusBarText()
               End Try
            End Using
         Else
            Messager.ShowError(Me, "Set Results Path please.")
         End If
      End Sub

      Private Sub _menuItemOptionsSetSeparatorString_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemOptionsSetSeparatorString.Click
         Dim seperatorString As String = _seperatorStringDlg.SeperatorString
         _seperatorStringDlg.ShowDialog()
      End Sub

      Private Sub _menuItemOptionsSetResultsPath_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemOptionsSetResultsPath.Click
         Dim browserDlg As FolderBrowserDialog = New FolderBrowserDialog()
         browserDlg.SelectedPath = _twainSaveFilePath

         If browserDlg.ShowDialog() = DialogResult.OK Then
            'Set the Save path of twain images
            _twainSaveFilePath = browserDlg.SelectedPath
         End If
      End Sub

      Private Sub _menuItemPage_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemPageFirst.Click, _menuItemPagePrevious.Click, _menuItemPageNext.Click, _menuItemPageLast.Click
         Dim page As Integer = _viewer.Image.Page
         If sender Is _menuItemPageFirst Then
            page = 1
         ElseIf sender Is _menuItemPagePrevious Then
            page -= 1
         ElseIf sender Is _menuItemPageNext Then
            page += 1
         ElseIf sender Is _menuItemPageLast Then
            page = _viewer.Image.PageCount
         End If

         page = Math.Max(1, Math.Min(_viewer.Image.PageCount, page))

         If page <> _viewer.Image.Page Then
            _viewer.Image.Page = page
            UpdateControls()
            UpdateStatusBarText()
         End If
      End Sub

      Private Sub Twain_AcquirePage(ByVal sender As Object, ByVal e As TwainAcquirePageEventArgs)
         Dim barDataArray As String() = ReadBarcode(e.Image)

         'Check if Barcodes found
         If Not barDataArray Is Nothing Then
            For Each barData As String In barDataArray
               If Not barData Is Nothing AndAlso barData = _seperatorStringDlg.SeperatorString Then
                  'If barData equals "Separator" string, save the image to a sperate file
                  _saveFilesCount += 1
                  _twainSaveFileName = ChangeSaveFileName(_saveFilesCount.ToString())
               End If
            Next barData
         End If

         ' Save the scanned images to the TwainSaveFileName file
         _codecs.Save(e.Image, _twainSaveFileName, RasterImageFormat.Tif, e.Image.BitsPerPixel, 1, 1, 1, CodecsSavePageMode.Append)

         'Add the scanned image to the viewer control
         If _viewer.Image Is Nothing OrElse _viewer.Image.PageCount = 0 Then
            _viewer.Image = e.Image
         Else
            _viewer.Image.AddPage(e.Image)
         End If
      End Sub

      Private Sub MainForm_Closed(ByVal sender As Object, ByVal e As FormClosedEventArgs) Handles MyBase.FormClosed
         If Not _twnSession Is Nothing Then
            'Shutdown the twnSession object
            _twnSession.Shutdown()
         End If
      End Sub

      ' ReadBarcode function search the scanned image  for 1D Code128 barcodes
      Private Function ReadBarcode(ByVal TwainImage As RasterImage) As String()
         _codecs.ThrowExceptionsOnInvalidImages = True
         Dim barEngine As BarcodeEngine
         Dim strDataArray As String() = Nothing
         Try
            barEngine = New BarcodeEngine()

            ' Set the Barcode search rectangle
            Dim searchRect As LeadRect = LeadRect.Empty

            ' Read the barcodes using default options
            barEngine.Reader.ErrorMode = BarcodeReaderErrorMode.IgnoreAll
            Dim barcodes As BarcodeData() = barEngine.Reader.ReadBarcodes(TwainImage, searchRect, 0, New BarcodeSymbology() {BarcodeSymbology.Code128})

            If barcodes.Length > 0 Then
               strDataArray = New String(barcodes.Length - 1) {}
               Dim nIndex As Integer = 0
               For nIndex = 0 To barcodes.Length - 1
                  strDataArray(nIndex) = barcodes(nIndex).Value
               Next nIndex

               Return strDataArray
            Else
               Return Nothing
            End If
         Catch ex As BarcodeException
            Messager.ShowError(Me, ex.Message)
            Return Nothing
         End Try
      End Function

      Private Function ChangeSaveFileName(ByVal str As String) As String
         str = _twainSaveFilePath & "\File" & str
         str &= ".TIF"
         If File.Exists(str) Then
            File.Delete(str)
         End If
         Return str
      End Function

      Private Sub UpdateControls()
         ' update the menu items
         If Not _viewer.Image Is Nothing Then
            _menuItemPage.Enabled = True
            _menuItemPage.Visible = True
            Dim page As Integer = _viewer.Image.Page
            _menuItemPageFirst.Enabled = (page <> 1)
            _menuItemPageFirst.Visible = True
            _menuItemPagePrevious.Enabled = (page <> 1)
            _menuItemPagePrevious.Visible = True
            _menuItemPageNext.Enabled = (page <> _viewer.Image.PageCount)
            _menuItemPageNext.Visible = True
            _menuItemPageLast.Enabled = (page <> _viewer.Image.PageCount)
            _menuItemPageLast.Visible = True
         Else
            _menuItemPage.Enabled = False
            _menuItemPage.Visible = False
            _menuItemPageFirst.Enabled = False
            _menuItemPageFirst.Visible = False
            _menuItemPagePrevious.Enabled = False
            _menuItemPagePrevious.Visible = False
            _menuItemPageNext.Enabled = False
            _menuItemPageNext.Visible = False
            _menuItemPageLast.Enabled = False
            _menuItemPageLast.Visible = False
         End If
      End Sub

      Private Sub UpdateStatusBarText()
         If Not _viewer.Image Is Nothing Then
            _sbMain.Text = String.Format("Page {0}:{1}", _viewer.Image.Page, _viewer.Image.PageCount)
         Else
            _sbMain.Text = "Ready"
         End If
      End Sub

      Private Sub _menuItemFileExit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemFileExit.Click
         Close()
      End Sub

      Private Sub _menuItemHelpAbout_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemHelpAbout.Click
         Using aboutDialog As New AboutDialog("Twain With Barcode Separator", ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using
      End Sub
   End Class
End Namespace
