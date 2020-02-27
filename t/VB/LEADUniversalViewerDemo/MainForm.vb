' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Forms
Imports System.Threading
Imports System.IO
Imports System.Resources
Imports System.Diagnostics
Imports System.Reflection

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Demos
Imports Leadtools.Controls
Imports Leadtools.Multimedia
Imports Leadtools.Drawing
Imports Leadtools.Demos.Dialogs

Namespace VBLEADUniversalViewer
   Partial Public Class MainForm : Inherits Form
      Private codecs As RasterCodecs = Nothing
      Private _panZoomInteractiveMode As ImageViewerPanZoomInteractiveMode = Nothing
      Private CurrentPageNum As Integer = 1
      Private _fileName As String = ""
      Private _logFileName As String = ""
      Private FolderName As String = ""
      'Flag to cancel the browsing process when the user presses Escape button
      Private CancelBrowse As Boolean = False
      'Recent Folders Queue
      Private MRUlist As Queue = New Queue()
      'Load File Writer
      Private LogFileWriter As System.IO.StreamWriter = Nothing
      'Loading resolution dialog
      Private loadingResolutionDialog As LoadingResolutionDialog = Nothing
      '
      Private TempImageViewerCellInTableLayout As TableLayoutPanelCellPosition
      '
      Private FullScreenPanel As Panel = New Panel()
      '
      Private MainFormBorderDefaultStyle As FormBorderStyle
      '
      Private ImageViewerDefaultBackColor As Color
      '
      Private playCtrl1 As PlayCtrl
      '
      Private PauseAnimation As Boolean
      '
      Private animatedImage As RasterImage
      '
      Private IsPlayingGif As Boolean = False

      Public Property PanZoomInteractiveMode() As ImageViewerPanZoomInteractiveMode
         Get
            Return _panZoomInteractiveMode
         End Get
         Set(value As ImageViewerPanZoomInteractiveMode)
            Value = _panZoomInteractiveMode
         End Set
      End Property

      Public Sub New()
         InitializeComponent()

         'Set LEADTOOLS license before deploying your application
         If (Not Support.SetLicense()) Then
            Return
         End If

         'RasterCodecs: provides support for loading and saving raster image files
         codecs = New RasterCodecs()

         _panZoomInteractiveMode = New ImageViewerPanZoomInteractiveMode()
         _panZoomInteractiveMode.AutoItemMode = ImageViewerAutoItemMode.AutoSet
         _panZoomInteractiveMode.DoubleTapSizeMode = imageViewer1.SizeMode
         _panZoomInteractiveMode.EnablePan = True
         _panZoomInteractiveMode.EnablePinchZoom = False
         _panZoomInteractiveMode.EnableZoom = False

         tableLayoutPanel1.SetRowSpan(listBox1, 2)

         trkPosition.SetRange(0, 10000)

         loadingResolutionDialog = New LoadingResolutionDialog()

         TempImageViewerCellInTableLayout = New TableLayoutPanelCellPosition()

         FullScreenPanel.Visible = False
      End Sub

      Private Sub MainForm_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles Me.KeyDown
         If (e.KeyCode = Keys.Escape) Then
            If CancelBrowse <> True AndAlso FullScreenPanel.Visible <> True Then
               CancelBrowse = True
               MessageBox.Show("Browsing has been canceled")
            End If

            ExitFullScreenMode(FullScreenPanel.Visible)
         End If
      End Sub

      Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
         Try
            Me.playCtrl1 = New PlayCtrl()
            CType(Me.playCtrl1, System.ComponentModel.ISupportInitialize).BeginInit()
            ' playCtrl1            
            Me.playCtrl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.playCtrl1.Location = New System.Drawing.Point(0, 0)
            Me.playCtrl1.Name = "playCtrl1"
            Me.playCtrl1.OcxState = Nothing
            Me.playCtrl1.Size = New System.Drawing.Size(1046, 713)
            Me.playCtrl1.SourceFile = Nothing
            Me.playCtrl1.TabIndex = 0
            Me.playCtrl1.Text = "playCtrl1"
            AddHandler playCtrl1.DoubleClick, AddressOf playCtrl1_DoubleClick
            AddHandler playCtrl1.TrackingPositionChanged, AddressOf playCtrl1_TrackingPositionChanged
            CType(Me.playCtrl1, System.ComponentModel.ISupportInitialize).EndInit()

            Me.PlayerPanel.Controls.Add(Me.playCtrl1)
            Me.PlayerPanel.Controls.Add(Me.imageViewer1)

            imageViewer1.Visible = False
            playCtrl1.Visible = False
            Me.MaximumSize = Me.Size
            Me.MinimumSize = New System.Drawing.Size(Me.Size.Width - 70, Me.Size.Height - 10)

            PauseAnimation = False

            animatedImage = Nothing
         Catch e1 As Exception
            Dim MsgBoxRes As DialogResult = MessageBox.Show(Me, "LEADTOOLS Multimedia SDK is not installed. Please download and install it to continue using this demo." & Microsoft.VisualBasic.Constants.vbLf & "Do you want to download LEADTOOLS Multimedia SDK?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)
            If MsgBoxRes = System.Windows.Forms.DialogResult.Yes Then
               System.Diagnostics.Process.Start("https://www.leadtools.com/downloads?category=mm")
            Else
               Return
            End If
         End Try

         Me.KeyPreview = True

         _logFileName = System.Environment.CurrentDirectory & "\LeadUniversalViewerLog.txt"

         ' First line in the Log file
         Dim strLogStart As String = "Start logging..." & Microsoft.VisualBasic.Constants.vbLf + Microsoft.VisualBasic.Constants.vbLf

         Try
            WriteToLogFile(_logFileName, strLogStart)

            'Load the text file that contains the names of the recent folders
            LoadRecentList()

            For Each item As String In MRUlist
               'populating menu
               Dim fileRecent As ToolStripMenuItem = New ToolStripMenuItem(item)
               'Add the files in the selcted folder
               AddHandler fileRecent.MouseUp, AddressOf fileRecent_MouseUp
               'add the menu to "recent" menu
               recentToolStripMenuItem.DropDownItems.Add(fileRecent)
            Next item

            Dim FileDuration As String = String.Format("{0:D2}:{1:D2}:{2:D2}:{3:D3}", 0, 0, 0, 0)

            Dim FileCurrentPosition As String = String.Format("{0:D2}:{1:D2}:{2:D2}:{3:D3}", 0, 0, 0, 0)

            lbltrkPosition.Text = String.Format(" {0} / {1}", FileCurrentPosition, FileDuration)

            'Set the default loading resolutions
            codecs.Options.RasterizeDocument.Load.XResolution = 150
            codecs.Options.RasterizeDocument.Load.YResolution = 150

            Dim UserInfoDialog As InfoDialog = New InfoDialog()
            UserInfoDialog.Show(Me)

            MainFormBorderDefaultStyle = Me.FormBorderStyle

            ImageViewerDefaultBackColor = imageViewer1.BackColor
         Catch ex As Exception
            Dim st As StackTrace = New StackTrace()
            Dim sf As StackFrame = st.GetFrame(0)
            Dim currentMethodName As MethodBase = sf.GetMethod()

            WriteToLogFile(_logFileName, String.Format("{0} " & Microsoft.VisualBasic.Constants.vbTab & " {1} " & Microsoft.VisualBasic.Constants.vbLf, currentMethodName, ex.Message))
         End Try
      End Sub

      Private Sub ExitFullScreenMode(ByVal IsVisible As Boolean)
         If IsVisible Then
            imageViewer1.Parent = PlayerPanel
            tableLayoutPanel1.SetCellPosition(imageViewer1, TempImageViewerCellInTableLayout)

            FullScreenPanel.Dock = DockStyle.None

            imageViewer1.Dock = DockStyle.Fill

            imageViewer1.Visible = True

            tableLayoutPanel1.Show()

            menuStrip1.Show()

            imageViewer1.BackColor = ImageViewerDefaultBackColor

            Me.FormBorderStyle = MainFormBorderDefaultStyle

            FullScreenPanel.Visible = False
         End If
      End Sub
      Private Sub BtnExitFullScreenMode_MouseClick(ByVal sender As Object, ByVal e As MouseEventArgs)
         ExitFullScreenMode(FullScreenPanel.Visible)
      End Sub

      Private Sub trkPosition_Scroll(ByVal sender As Object, ByVal e As System.EventArgs) Handles trkPosition.Scroll
         Try
            playCtrl1.CurrentTrackingPosition = trkPosition.Value

            SetSeekingButtonsState()

            Dim t As TimeSpan = TimeSpan.FromSeconds(playCtrl1.Duration)

            Dim FileDuration As String = String.Format("{0:D2}:{1:D2}:{2:D2}:{3:D3}", t.Hours, t.Minutes, t.Seconds, t.Milliseconds)

            t = TimeSpan.FromSeconds(playCtrl1.CurrentPosition)

            Dim FileCurrentPosition As String = String.Format("{0:D2}:{1:D2}:{2:D2}:{3:D3}", t.Hours, t.Minutes, t.Seconds, t.Milliseconds)

            lbltrkPosition.Text = String.Format(" {0} / {1}", FileCurrentPosition, FileDuration)

            lbltrkPosition.Refresh()
            trkPosition.Refresh()
         Catch ex As Exception
            Dim st As StackTrace = New StackTrace()
            Dim sf As StackFrame = st.GetFrame(0)
            Dim currentMethodName As MethodBase = sf.GetMethod()

            WriteToLogFile(_logFileName, String.Format("{0} " & Microsoft.VisualBasic.Constants.vbTab & " {1} " & Microsoft.VisualBasic.Constants.vbLf, currentMethodName, ex.Message))
         End Try
      End Sub

      Private Function FormatPosition(ByVal ts As Double) As String
         Dim h As String = Nothing
         Dim m As String = Nothing
         Dim s As String = Nothing
         h = (CInt(ts / 3600)).ToString()
         ts = ts Mod 3600
         m = (CInt(ts / 60)).ToString()
         ts = ts Mod 60
         s = ts.ToString("00.000")
         If h.Length < 2 Then
            h = "0" & h
         End If
         If m.Length < 2 Then
            m = "0" & m
         End If
         If s.Length < 2 Then
            s = "0" & s
         End If
         Return h & ":" & m & ":" & s
      End Function

      Private Sub SetSeekingButtonsState()
         Dim caps As PlaySeeking = 0

         caps = playCtrl1.CheckSeekingCapabilities(PlaySeeking.Forward Or PlaySeeking.Backward Or PlaySeeking.FrameForward Or PlaySeeking.FrameBackward)
         trkPosition.Enabled = (caps <> 0)
      End Sub

      Private Sub ChangePlayerSizeMode()
         'Toggle between normal and fit size modes of the player control
         If playCtrl1.VideoWindowSizeMode = SizeMode.Fit Then
            playCtrl1.VideoWindowSizeMode = SizeMode.Normal
            imageViewer1.Cursor = Cursors.Hand
         Else
            playCtrl1.VideoWindowSizeMode = SizeMode.Fit
            imageViewer1.Cursor = Cursors.Default
         End If
      End Sub

      Private Sub ChangeViewerSizeMode()
         'Toggle between ActualSize and fit size modes of the imageViewer control
         If imageViewer1.SizeMode = ControlSizeMode.Fit Then
            imageViewer1.Zoom(ControlSizeMode.ActualSize, 1, imageViewer1.DefaultZoomOrigin)
            imageViewer1.Cursor = Cursors.Hand
         Else
            imageViewer1.Zoom(ControlSizeMode.Fit, 1, imageViewer1.DefaultZoomOrigin)
            imageViewer1.Cursor = Cursors.Default
         End If
      End Sub

      Private Sub imageViewer1_MouseDoubleClick(ByVal sender As Object, ByVal e As MouseEventArgs) Handles imageViewer1.MouseDoubleClick
         'change the imageViewer's size mode when you double click the viewer
         Try
            If Not imageViewer1.Image Is Nothing Then
               ChangeViewerSizeMode()
            End If

            imageViewer1.Refresh()
         Catch ex As Exception
            Dim st As StackTrace = New StackTrace()
            Dim sf As StackFrame = st.GetFrame(0)
            Dim currentMethodName As MethodBase = sf.GetMethod()

            WriteToLogFile(_logFileName, String.Format("{0} " & Microsoft.VisualBasic.Constants.vbTab & " {1} " & Microsoft.VisualBasic.Constants.vbLf, currentMethodName, ex.Message))
         End Try
      End Sub

      Private Sub fileRecent_MouseUp(ByVal sender As Object, ByVal e As MouseEventArgs)
         Dim currentFolder As String = sender.ToString()
         Dim currentToolStripMenu As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)

         toolTip1.IsBalloon = False

         If Directory.Exists(currentFolder) Then
            'Change the application's Cursor
            Dim TempCursor As Cursor = Me.Cursor
            Me.Cursor = Cursors.WaitCursor

            For Each tempStripMenu As ToolStripMenuItem In recentToolStripMenuItem.DropDownItems
               tempStripMenu.Checked = False
            Next tempStripMenu

            currentToolStripMenu.Checked = True

            'Flag to cancel the browsing process when the user presses Escape button
            CancelBrowse = False

            menuStrip1.Enabled = False

            AddFileToList(currentFolder)

            menuStrip1.Enabled = True

            Me.Cursor = TempCursor
         End If
      End Sub

      Private Sub WriteToLogFile(ByVal LogFileName As String, ByVal TextToWrite As String)
         If LogFileWriter Is Nothing Then
            LogFileWriter = New System.IO.StreamWriter(_logFileName)
            LogFileWriter.AutoFlush = True
         ElseIf System.IO.File.Exists(LogFileName) Then
            LogFileWriter = New System.IO.StreamWriter(LogFileName, True)
         End If

         LogFileWriter.WriteLine(TextToWrite)
         LogFileWriter.Close()
      End Sub

      Private Sub playMoreFilesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles playMoreFilesToolStripMenuItem.Click
         Try
            'Browse the folder that contains your images and media files
            Using BrowserDialog As FolderBrowserDialog = New FolderBrowserDialog()

               If BrowserDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                  FolderName = BrowserDialog.SelectedPath

                  'Change the application's Cursor
                  Dim TempCursor As Cursor = Me.Cursor
                  Me.Cursor = Cursors.WaitCursor

                  toolTip1.IsBalloon = False

                  'Flag to cancel the browsing process when the user presses Escape button                  
                  CancelBrowse = False

                  menuStrip1.Enabled = False

                  AddFileToList(FolderName)

                  menuStrip1.Enabled = True

                  Dim fileRecent As ToolStripMenuItem = New ToolStripMenuItem(FolderName)


                  If Not (MRUlist.Contains(fileRecent.Text)) Then 'prevent duplication on recent list
                     Do While MRUlist.Count >= 5
                        MRUlist.Dequeue()
                     Loop

                     MRUlist.Enqueue(FolderName)

                     recentToolStripMenuItem.DropDownItems.Clear()

                     For Each item As String In MRUlist
                        Dim ItemToAdd As ToolStripMenuItem = New ToolStripMenuItem(item)
                        AddHandler ItemToAdd.MouseUp, AddressOf fileRecent_MouseUp
                        recentToolStripMenuItem.DropDownItems.Add(ItemToAdd)
                     Next item

                     menuStrip1.Refresh()
                  End If

                  'Reset the application's Cursor to the default
                  Me.Cursor = TempCursor
               End If
            End Using
         Catch ex As Exception
            Dim st As StackTrace = New StackTrace()
            Dim sf As StackFrame = st.GetFrame(0)
            Dim currentMethodName As MethodBase = sf.GetMethod()

            WriteToLogFile(_logFileName, String.Format("{0} " & Microsoft.VisualBasic.Constants.vbTab & " {1} " & Microsoft.VisualBasic.Constants.vbLf, currentMethodName, ex.Message))
         End Try
      End Sub


      Private Sub AddRasterImageToList(fileName As String)
         'try loading the current file
         Using TempImage As RasterImage = codecs.Load(fileName, 1)
            Dim strShortname As String = _fileName.Substring(fileName.LastIndexOf("\"))
            strShortname = strShortname.TrimStart(("\").ToCharArray())
            'Add the current file to the list-box
            Dim ItemToAdd As New MyListItem(fileName, strShortname, 1)
            '1 - Image File
            listBox1.Items.Add(ItemToAdd)
            Invoke(CType(Sub() Application.DoEvents(), MethodInvoker))
         End Using
      End Sub

      'Add the valid file names to the list-box

      Private Sub AddFileToList(SelectedFolder As String)
         Try
            'Get all files in the selected folder
            Dim filePaths As String() = Directory.GetFiles(SelectedFolder)

            If filePaths.Length = 0 Then
               MessageBox.Show(String.Format("{0} <{1}>", "No files found in", SelectedFolder))
               Return
            End If

            listBox1.DisplayMember = "FileShortName"
            listBox1.ValueMember = "FileType"


            listBox1.Items.Clear()
            Thread.Sleep(500)
            listBox1.Invalidate(True)


            Dim FileDuration As String = String.Format("{0:D2}:{1:D2}:{2:D2}:{3:D3}", 0, 0, 0, 0)

            Dim FileCurrentPosition As String = String.Format("{0:D2}:{1:D2}:{2:D2}:{3:D3}", 0, 0, 0, 0)

            lbltrkPosition.Text = String.Format(" {0} / {1}", FileCurrentPosition, FileDuration)

            codecs.Options.Load.AllPages = False
            codecs.Options.Txt.Load.Enabled = supportLoadingTEXTFilesToolStripMenuItem.Checked

            'Loop throgh the files
            For index As Integer = 0 To filePaths.Length - 1
               If CancelBrowse Then
                  CancelBrowse = False
                  Return
               End If

               Invoke(CType(Sub() Application.DoEvents(), MethodInvoker))

               'MediaInfo: provides detailed information about the source media file
               Using mediaInfo As New MediaInfo()
                  _fileName = filePaths(index)

                  mediaInfo.SourceFile = _fileName

                  If (mediaInfo.SourceFormat = SourceFormatType.Unknown) OrElse (mediaInfo.SourceFormat = SourceFormatType.Still) Then
                     'if the current file is image of any non-media file
                     Try
                        If CancelBrowse Then
                           CancelBrowse = False
                           Return
                        End If

                        mediaInfo.ResetSource()

                        AddRasterImageToList(_fileName)

                        Invoke(CType(Sub() Application.DoEvents(), MethodInvoker))
                     Catch ex As Exception
                        Dim st As New StackTrace()
                        Dim sf As StackFrame = st.GetFrame(0)
                        Dim currentMethodName As MethodBase = sf.GetMethod()

                        WriteToLogFile(_logFileName, String.Format("{0} " & vbTab & " {1} " & vbTab & " {2} " & vbLf, currentMethodName, _fileName, ex.Message))

                        Continue For
                     End Try
                  Else
                     Try
                        If mediaInfo.OutputStreams = 0 Then
                           mediaInfo.ResetSource()
                           AddRasterImageToList(_fileName)
                        Else
                           'Declare a temporary player control, and pass it to the Leadtools.Multimedia.PlayCtrl coconstructor
                           Using TempPlayer As New PlayCtrl(True)
                              If CancelBrowse Then
                                 CancelBrowse = False
                                 Return
                              End If

                              TempPlayer.AutoStart = False
                              TempPlayer.SourceFile = _fileName

                              Dim strShortname As String = _fileName.Substring(_fileName.LastIndexOf("\"))
                              strShortname = strShortname.TrimStart(("\").ToCharArray())

                              Dim ItemToAdd As New MyListItem(_fileName, strShortname, 2)
                              '2 - Media File (Video or Audio)
                              listBox1.Items.Add(ItemToAdd)

                              TempPlayer.ResetSource()
                           End Using
                           Invoke(CType(Sub() Application.DoEvents(), MethodInvoker))
                        End If
                     Catch ex As Exception
                        Dim st As New StackTrace()
                        Dim sf As StackFrame = st.GetFrame(0)
                        Dim currentMethodName As MethodBase = sf.GetMethod()

                        WriteToLogFile(_logFileName, String.Format("{0} " & vbTab & " {1} " & vbTab & " {2} " & vbLf, currentMethodName, _fileName, ex.Message))

                        Continue For
                     End Try
                  End If
               End Using

               If CancelBrowse Then
                  CancelBrowse = False
                  Return
               End If
            Next

            btnNext.Visible = True
            btnNext.Enabled = True

            btnPrev.Visible = True

            btnPrev.Enabled = True
         Catch ex As Exception
            Dim st As New StackTrace()
            Dim sf As StackFrame = st.GetFrame(0)
            Dim currentMethodName As MethodBase = sf.GetMethod()

            WriteToLogFile(_logFileName, String.Format("{0} " & vbTab & " {1} " & vbLf, currentMethodName, ex.Message))
         End Try
      End Sub

      Private Sub SaveRecentFile(ByVal path As String)
         Try
            'keep list number not exceeded the given value
            Do While MRUlist.Count > 5
               MRUlist.Dequeue()
            Loop

            'create file called "Recent.txt" located on app folder
            Dim RectFileName As String = System.Environment.CurrentDirectory & "\Recent.txt"

            Using stringToWrite As StreamWriter = New StreamWriter(RectFileName)

               For Each item As String In MRUlist
                  stringToWrite.WriteLine(item) 'write list to stream
               Next item

               stringToWrite.Flush() 'write stream to file
               stringToWrite.Close() 'close the stream and reclaim memory
            End Using

            'clear all recent list from menu
            recentToolStripMenuItem.DropDownItems.Clear()
         Catch ex As Exception
            Dim st As StackTrace = New StackTrace()
            Dim sf As StackFrame = st.GetFrame(0)
            Dim currentMethodName As MethodBase = sf.GetMethod()

            WriteToLogFile(_logFileName, String.Format("{0} " & Microsoft.VisualBasic.Constants.vbTab & " {1} " & Microsoft.VisualBasic.Constants.vbLf, currentMethodName, ex.Message))
         End Try
      End Sub

      Private Sub LoadRecentList()
         'try to load file. If file isn't found, do nothing
         Try
            Dim RectFileName As String = System.Environment.CurrentDirectory & "\Recent.txt"

            Dim listToRead As StreamReader = Nothing

            If File.Exists(RectFileName) Then
               'read file stream
               listToRead = New StreamReader(System.Environment.CurrentDirectory & "\Recent.txt")
            Else
               Return
            End If

            Dim line As String

            If MRUlist.Count > 0 Then
               MRUlist.Clear()
            End If

            line = Nothing
				line = listToRead.ReadLine()
				Do While (line <> Nothing) 'read each line until end of file
					MRUlist.Enqueue(line) 'insert to list
					line = listToRead.ReadLine()
				Loop

				listToRead.Close() 'close the stream

            If Not listToRead Is Nothing Then
               listToRead.Dispose()
            End If

         Catch ex As Exception
            Dim st As StackTrace = New StackTrace()
            Dim sf As StackFrame = st.GetFrame(0)
            Dim currentMethodName As MethodBase = sf.GetMethod()

            WriteToLogFile(_logFileName, String.Format("{0} " & Microsoft.VisualBasic.Constants.vbTab & " {1} " & Microsoft.VisualBasic.Constants.vbLf, currentMethodName, ex.Message))
         End Try
      End Sub


      Private Sub ListBox1_SelectedValueChanged(sender As Object, e As EventArgs) Handles listBox1.SelectedIndexChanged
         Try
            If listBox1.SelectedIndex <> -1 Then
               Dim SelectedListItem As MyListItem = TryCast(listBox1.SelectedItem, MyListItem)

               If SelectedListItem IsNot Nothing Then
                  'if the selected file is an image, load it and then display it in the viewer
                  If (SelectedListItem.FileType = 1) Then
                     ' set the codecs.Options.Load.AllPages property to True to support loading all pages of the image file
                     codecs.Options.Load.AllPages = loadAllPagesToolStripMenuItem.Checked

                     'Add the panning feature to the image viewer control
                     imageViewer1.InteractiveModes.Add(PanZoomInteractiveMode)
                     PanZoomInteractiveMode.IsEnabled = True

                     If IsPlayingGif Then
                        IsPlayingGif = False
                        PauseAnimation = False
                     End If

                     Invoke(CType(Sub() Application.DoEvents(), MethodInvoker))

                     If imageViewer1.HasImage Then
                        imageViewer1.Image.Page = 1
                     End If

                     'Load the image to the Viewer
                     imageViewer1.Image = codecs.Load(SelectedListItem.FileFullName)


                     CurrentPageNum = 1

                     imageViewer1.Image.Page = CurrentPageNum

                     numericUpDown1.Maximum = imageViewer1.Image.PageCount
                     numericUpDown1.Value = CurrentPageNum

                     'Change Visible and Enabled properties for some button and controls
                     btnFwd.Visible = True
                     btnRew.Visible = True

                     numericUpDown1.Visible = True

                     If imageViewer1.Image.PageCount > 1 Then
                        numericUpDown1.Enabled = True
                        btnFwd.Enabled = True
                        btnRew.Enabled = True
                     Else
                        numericUpDown1.Enabled = False
                        btnFwd.Enabled = False
                        btnRew.Enabled = False
                     End If

                     btnPlay.Visible = False
                     btnStop.Visible = False
                     btnPause.Visible = False
                     trkPosition.Visible = False
                     lbltrkPosition.Visible = False
                     'Show the imageViewer control
                     imageViewer1.Visible = True
                     imageViewer1.Dock = DockStyle.Fill
                     imageViewer1.Zoom(ControlSizeMode.Fit, 1, imageViewer1.DefaultZoomOrigin)

                     Using ImageInfo As CodecsImageInfo = codecs.GetInformation(SelectedListItem.FileFullName, True)
                        btnPlay.Visible = (ImageInfo.Format = RasterImageFormat.Gif)
                     End Using
                     'Hide the player control
                     playCtrl1.Visible = False
                     playCtrl1.Dock = DockStyle.None
                     playCtrl1.ResetSource()
                     playCtrl1.[Stop]()
                  ElseIf SelectedListItem.FileType = 2 Then
                     'Hide the imageViewer control
                     imageViewer1.Visible = False
                     imageViewer1.Image = Nothing
                     imageViewer1.Dock = DockStyle.None

                     'Show the player control
                     playCtrl1.Location = New Point(0, 0)
                     playCtrl1.Dock = DockStyle.Fill
                     playCtrl1.Visible = True

                     Dim playSeeking As PlaySeeking = playCtrl1.CheckSeekingCapabilities(playSeeking.Forward Or playSeeking.Backward)

                     If playSeeking = (playSeeking.Backward Or playSeeking.Forward) Then
                        playCtrl1.CurrentTrackingPosition = 0
                     End If


                     PlayerPanel.Visible = True

                     playCtrl1.AutoStart = playbackMediaFilesToolStripMenuItem.Checked
                     playCtrl1.SourceFile = SelectedListItem.FileFullName

                     trkPosition.Visible = True
                     lbltrkPosition.Visible = True

                     Dim t As TimeSpan = TimeSpan.FromSeconds(playCtrl1.Duration)

                     Dim FileDuration As String = String.Format("{0:D2}:{1:D2}:{2:D2}:{3:D3}", t.Hours, t.Minutes, t.Seconds, t.Milliseconds)

                     t = TimeSpan.FromSeconds(0)

                     Dim FileCurrentPosition As String = String.Format("{0:D2}:{1:D2}:{2:D2}:{3:D3}", t.Hours, t.Minutes, t.Seconds, t.Milliseconds)

                     lbltrkPosition.Text = String.Format(" {0} / {1}", FileCurrentPosition, FileDuration)

                     If playCtrl1.RenderedStreams = StreamFormatType.Audio Then
                        'If the selected file is an Audio file, show the AudioFile image from resources in the image viewer
                        Dim rm As ResourceManager = My.Resources.ResourceManager
                        Dim AudioImage As Image = CType(rm.GetObject("AudioFile"), Bitmap)

                        imageViewer1.Image = RasterImageConverter.ConvertFromImage(AudioImage, ConvertFromImageOptions.None)
                        imageViewer1.Dock = DockStyle.Fill
                        playCtrl1.Hide()
                        imageViewer1.Visible = True
                        imageViewer1.Show()
                     End If

                     'Change Visible and Enabled properties for some button and controls
                     numericUpDown1.Enabled = False
                     btnFwd.Enabled = True
                     btnRew.Enabled = True

                     btnFwd.Visible = True
                     btnRew.Visible = True
                     numericUpDown1.Visible = False
                     btnPlay.Visible = True
                     btnStop.Visible = True
                     btnPause.Visible = True

                     playCtrl1.Refresh()

                     listBox1.Focus()
                  Else
                     'If the selected file is not valid or not supported, show the NotSupportedFormat image from resources in the image viewer
                     Dim rm As ResourceManager = My.Resources.ResourceManager
                     Dim NotSupportedFormatImage As Image = CType(rm.GetObject("NotSupportedFormat"), Bitmap)

                     imageViewer1.Image = RasterImageConverter.ConvertFromImage(NotSupportedFormatImage, ConvertFromImageOptions.None)
                     imageViewer1.Dock = DockStyle.Fill
                     playCtrl1.Hide()
                     imageViewer1.Visible = True
                     imageViewer1.Show()
                  End If
               End If

               Me.Refresh()

               imageViewer1.Cursor = Cursors.[Default]
            End If
         Catch ex As Exception
            Dim st As New StackTrace()
            Dim sf As StackFrame = st.GetFrame(0)
            Dim currentMethodName As MethodBase = sf.GetMethod()

            WriteToLogFile(_logFileName, String.Format("{0} " & vbTab & " {1} " & vbLf, currentMethodName, ex.Message))
         End Try
      End Sub

      Private Sub btnRew_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnRew.Click
         Try
            'Get the selected item from the list-box
            Dim SelectedItem As MyListItem = TryCast(listBox1.SelectedItem, MyListItem)

            'If the selected file is multi-page file, show the Previous page
            If SelectedItem.FileType = 1 Then
               If imageViewer1.Visible AndAlso imageViewer1.HasImage Then
                  ShowPreviousPage()
               End If
               'If the selected file is a media file, change the playback rate
            ElseIf SelectedItem.FileType = 2 Then
               If playCtrl1.Rate > 0.5 Then
                  playCtrl1.Rate = playCtrl1.Rate / 2
               End If
            End If
         Catch ex As Exception
            Dim st As StackTrace = New StackTrace()
            Dim sf As StackFrame = st.GetFrame(0)
            Dim currentMethodName As MethodBase = sf.GetMethod()

            WriteToLogFile(_logFileName, String.Format("{0} " & Microsoft.VisualBasic.Constants.vbTab & " {1} " & Microsoft.VisualBasic.Constants.vbLf, currentMethodName, ex.Message))
         End Try
      End Sub

      Private Sub btnFwd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFwd.Click
         Try
            'Get the selected item from the list-box
            Dim SelectedItem As MyListItem = TryCast(listBox1.SelectedItem, MyListItem)

            'If the selected file is multi-page file, show the next page
            If SelectedItem.FileType = 1 Then
               If imageViewer1.Visible AndAlso imageViewer1.HasImage Then
                  ShowNextPage()
               End If

               'If the selected file is a media file, change the playback rate
            ElseIf SelectedItem.FileType = 2 Then
               If playCtrl1.Rate < 2 Then
                  playCtrl1.Rate = playCtrl1.Rate * 2
               End If
            End If
         Catch ex As Exception
            Dim st As StackTrace = New StackTrace()
            Dim sf As StackFrame = st.GetFrame(0)
            Dim currentMethodName As MethodBase = sf.GetMethod()

            WriteToLogFile(_logFileName, String.Format("{0} " & Microsoft.VisualBasic.Constants.vbTab & " {1} " & Microsoft.VisualBasic.Constants.vbLf, currentMethodName, ex.Message))
         End Try
      End Sub

      Private Sub btnNext_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnNext.Click
         'Show the next file in the list-box
         Dim NextIndex As Integer = -1

         If listBox1.Items.Count > 1 Then
            Dim SelectedItem As MyListItem = TryCast(listBox1.SelectedItem, MyListItem)

            If Not SelectedItem Is Nothing Then
               If listBox1.Items.IndexOf(SelectedItem) <> (listBox1.Items.Count - 1) Then
                  NextIndex = listBox1.Items.IndexOf(SelectedItem) + 1

                  If Not listBox1.Items(NextIndex) Is Nothing Then
                     listBox1.SelectedIndex = NextIndex
                  End If
               End If
            End If
         End If
      End Sub

      'Show previous page in multi-page image
      Private Sub ShowPreviousPage()
         If CurrentPageNum = 1 Then
            CurrentPageNum = 1
         Else
            CurrentPageNum -= 1
         End If

         imageViewer1.Image.Page = CurrentPageNum

         numericUpDown1.Maximum = imageViewer1.Image.PageCount

         numericUpDown1.Value = CurrentPageNum

         imageViewer1.Refresh()
      End Sub

      'Show next page in multi-page image
      Private Sub ShowNextPage()
         If CurrentPageNum = imageViewer1.Image.PageCount Then
            CurrentPageNum = imageViewer1.Image.PageCount
         Else
            CurrentPageNum += 1
         End If

         imageViewer1.Image.Page = CurrentPageNum

         numericUpDown1.Maximum = imageViewer1.Image.PageCount

         numericUpDown1.Value = CurrentPageNum

         imageViewer1.Refresh()
      End Sub

      Private Sub btnPrev_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPrev.Click
         'Show the next file in the list-box
         Dim PrevIndex As Integer = -1

         If listBox1.Items.Count > 1 Then
            Dim SelectedItem As MyListItem = TryCast(listBox1.SelectedItem, MyListItem)
            If Not SelectedItem Is Nothing Then
               If listBox1.Items.IndexOf(SelectedItem) <> 0 Then
                  PrevIndex = listBox1.Items.IndexOf(SelectedItem) - 1

                  If Not listBox1.Items(PrevIndex) Is Nothing Then
                     listBox1.SelectedIndex = PrevIndex
                  End If
               End If
            End If
         End If
      End Sub

      'Change the current page using the numericUpDown control
      Private Sub numericUpDown1_ValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles numericUpDown1.ValueChanged
			If (imageViewer1.Image IsNot Nothing) Then
				If (CInt(numericUpDown1.Value) >= 1) AndAlso (CInt(numericUpDown1.Value) <= imageViewer1.Image.PageCount) Then
					imageViewer1.Image.Page = CInt(numericUpDown1.Value)
				End If
			End If
		End Sub

      '

      Private Sub PlayGifFile(GifImage As RasterImage)
         Try
            If IsPlayingGif Then
               Dim CurrentPage As Integer = 1

               While CurrentPage <= animatedImage.PageCount
                  'imageViewer1.Image.Page = CurrentPage;
                  numericUpDown1.Value = CurrentPage

                  imageViewer1.Refresh()
                  Invoke(CType(Sub() Application.DoEvents(), MethodInvoker))

                  Thread.Sleep(200)

                  CurrentPage += 1

                  If PauseAnimation Then
                     IsPlayingGif = False
                     Exit While
                  End If
               End While
            End If
         Catch ex As Exception
            Dim st As New StackTrace()
            Dim sf As StackFrame = st.GetFrame(0)
            Dim currentMethodName As MethodBase = sf.GetMethod()

            WriteToLogFile(_logFileName, String.Format("{0} " & vbTab & " {1} " & vbLf, currentMethodName, ex.Message))
         End Try
      End Sub

      'Play button
      Private Sub btnPlay_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPlay.Click
         Dim SelectedListItem As MyListItem = TryCast(listBox1.SelectedItem, MyListItem)

         If Not SelectedListItem Is Nothing Then
            If SelectedListItem.FileType = 1 Then
               If Not SelectedListItem Is Nothing Then
                  Using ImageInfo As CodecsImageInfo = codecs.GetInformation(SelectedListItem.FileFullName, True)
                     If ImageInfo.Format = RasterImageFormat.Gif Then
                        animatedImage = codecs.Load(SelectedListItem.FileFullName)
                        IsPlayingGif = True
                        PlayGifFile(animatedImage)
                        IsPlayingGif = False
                     End If
                  End Using
               End If
            ElseIf SelectedListItem.FileType = 2 Then
               playCtrl1.Run()
            End If
         End If
      End Sub

      'Pause button
      Private Sub btnPause_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnPause.Click
         playCtrl1.Pause()
      End Sub
      'Stop button
      Private Sub btnStop_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnStop.Click
         playCtrl1.Stop()
      End Sub

      'Enable or disable loading all pages
      Private Sub loadAllPagesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles loadAllPagesToolStripMenuItem.Click
         loadAllPagesToolStripMenuItem.Checked = Not loadAllPagesToolStripMenuItem.Checked

         Dim SelectedItem As MyListItem = TryCast(listBox1.SelectedItem, MyListItem)

         If Not SelectedItem Is Nothing Then
            listBox1.BeginUpdate()
            listBox1.SetSelected(listBox1.SelectedIndex, True)
            listBox1.EndUpdate()
         End If
      End Sub

      'Enable or disable Instant playback of selected media files
      Private Sub playbackMediaFilesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles playbackMediaFilesToolStripMenuItem.Click
         playbackMediaFilesToolStripMenuItem.Checked = Not playbackMediaFilesToolStripMenuItem.Checked
      End Sub

      'Change the player's control size mode when the use double clicks the control
      Private Sub playCtrl1_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
         Try
            If Not playCtrl1.SourceFile Is Nothing Then
               ChangePlayerSizeMode()
            End If
         Catch ex As Exception
            Dim st As StackTrace = New StackTrace()
            Dim sf As StackFrame = st.GetFrame(0)
            Dim currentMethodName As MethodBase = sf.GetMethod()

            WriteToLogFile(_logFileName, String.Format("{0} " & Microsoft.VisualBasic.Constants.vbTab & " {1} " & Microsoft.VisualBasic.Constants.vbLf, currentMethodName, ex.Message))
         End Try
      End Sub

      Private Sub playCtrl1_TrackingPositionChanged(ByVal sender As Object, ByVal e As TrackingPositionChangedEventArgs)
         Try
            trkPosition.Value = e.position
            SetSeekingButtonsState()

            Dim t As TimeSpan = TimeSpan.FromSeconds(playCtrl1.Duration)

            Dim FileDuration As String = String.Format("{0:D2}:{1:D2}:{2:D2}:{3:D3}", t.Hours, t.Minutes, t.Seconds, t.Milliseconds)

            t = TimeSpan.FromSeconds(playCtrl1.CurrentPosition)

            Dim FileCurrentPosition As String = String.Format("{0:D2}:{1:D2}:{2:D2}:{3:D3}", t.Hours, t.Minutes, t.Seconds, t.Milliseconds)

            lbltrkPosition.Text = String.Format(" {0} / {1}", FileCurrentPosition, FileDuration)

            lbltrkPosition.Refresh()
            trkPosition.Refresh()
         Catch ex As Exception
            Dim st As StackTrace = New StackTrace()
            Dim sf As StackFrame = st.GetFrame(0)
            Dim currentMethodName As MethodBase = sf.GetMethod()

            WriteToLogFile(_logFileName, String.Format("{0} " & Microsoft.VisualBasic.Constants.vbTab & " {1} " & Microsoft.VisualBasic.Constants.vbLf, currentMethodName, ex.Message))
         End Try
      End Sub

      Private Sub clearAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
         recentToolStripMenuItem.DropDownItems.Clear()
      End Sub

      Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles Me.FormClosing
         Dim RectFileName As String = System.Environment.CurrentDirectory & "\Recent.txt"
         SaveRecentFile(RectFileName)
      End Sub

      Private Sub exitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles exitToolStripMenuItem.Click
         Application.Exit()
      End Sub

      Private Sub listBox1_MouseMove(ByVal sender As Object, ByVal e As MouseEventArgs) Handles listBox1.MouseMove
         Dim point As Point = listBox1.PointToClient(Cursor.Position)

         'Get the index of the current listbox item
         Dim index As Integer = listBox1.IndexFromPoint(point)

         If index < 0 Then
            Return
         End If

         'Get the listbox item in the selected index
         Dim SelectedListItem As MyListItem = TryCast(listBox1.Items(index), MyListItem)

         'Get the current text of the toolTip
         Dim strTool As String = toolTip1.GetToolTip(listBox1)

         'If the text of the toolTip does not equal the text of the selected item, show the text of the item
         If strTool <> SelectedListItem.FileShortName Then
            If Not SelectedListItem Is Nothing Then
               toolTip1.SetToolTip(listBox1, SelectedListItem.FileShortName)
            End If
         End If
      End Sub

      Private Sub changeloadingOrRasterizingResolutionToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles changeloadingOrRasterizingResolutionToolStripMenuItem.Click
         loadingResolutionDialog.ShowDialog()

         codecs.Options.RasterizeDocument.Load.XResolution = loadingResolutionDialog.LoadingResolution
         codecs.Options.RasterizeDocument.Load.YResolution = loadingResolutionDialog.LoadingResolution

         loadingResolutionDialog.Hide()
      End Sub

      Private Sub aboutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles aboutToolStripMenuItem.Click
         Using aboutDialog As New AboutDialog("Universal Viewer", ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using
      End Sub

      Private Sub ShowViewerInFullScreen(ByVal IsVisible As Boolean)
         If IsVisible = False Then
            TempImageViewerCellInTableLayout = tableLayoutPanel1.GetCellPosition(imageViewer1)

            FullScreenPanel.Width = Me.Width
            FullScreenPanel.Height = Me.Height
            FullScreenPanel.Dock = DockStyle.Fill

            imageViewer1.Parent = FullScreenPanel
            imageViewer1.Dock = DockStyle.Fill

            Me.WindowState = FormWindowState.Maximized
            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable

            Me.Controls.Add(FullScreenPanel)
            FullScreenPanel.BringToFront()
            tableLayoutPanel1.Hide()

            menuStrip1.Hide()

            imageViewer1.Zoom(ControlSizeMode.ActualSize, 1, imageViewer1.DefaultZoomOrigin)

            imageViewer1.BackColor = Color.Black

            Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None

            FullScreenPanel.Visible = True

            Me.Refresh()

            FullScreenPanel.Refresh()

            imageViewer1.Refresh()
         End If
      End Sub
      Private Sub btnFullScreen_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnFullScreen.Click
         If imageViewer1.Visible Then
            ShowViewerInFullScreen(FullScreenPanel.Visible)
         ElseIf playCtrl1.Visible Then
            playCtrl1.ToggleFullScreenMode()
         End If
      End Sub

      Private Sub supportLoadingTEXTFilesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles supportLoadingTEXTFilesToolStripMenuItem.Click
         supportLoadingTEXTFilesToolStripMenuItem.Checked = Not supportLoadingTEXTFilesToolStripMenuItem.Checked
      End Sub

      Private Sub btnFwd_MouseHover(ByVal sender As Object, ByVal e As EventArgs) Handles btnFwd.MouseHover
         Dim SelectedItem As MyListItem = TryCast(listBox1.SelectedItem, MyListItem)

         If Not SelectedItem Is Nothing Then
            If SelectedItem.FileType = 1 Then
               toolTip1.SetToolTip(btnFwd, "Next page")
            ElseIf SelectedItem.FileType = 2 Then
               toolTip1.SetToolTip(btnFwd, "Double Speed")
            End If
         End If
      End Sub

      Private Sub btnRew_MouseHover(ByVal sender As Object, ByVal e As EventArgs) Handles btnRew.MouseHover
         Dim SelectedItem As MyListItem = TryCast(listBox1.SelectedItem, MyListItem)

         If Not SelectedItem Is Nothing Then
            If SelectedItem.FileType = 1 Then
               toolTip1.SetToolTip(btnRew, "Previous page")
            ElseIf SelectedItem.FileType = 2 Then
               toolTip1.SetToolTip(btnRew, "Half Speed")
            End If
         End If
      End Sub
   End Class
End Namespace
