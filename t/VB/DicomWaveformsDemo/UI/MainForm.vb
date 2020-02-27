' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Configuration
Imports System.Data
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Collections
Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.Dicom
Imports Leadtools.DicomDemos
Imports Leadtools.ImageProcessing
Imports Leadtools.ImageProcessing.Core
Imports Leadtools.ImageProcessing.Color
Imports System.IO
Imports Leadtools.Demos.Dialogs

Namespace DicomDemo
   ''' <summary>
   ''' Summary description for Form1.
   ''' </summary>
   Public Class MainForm : Inherits System.Windows.Forms.Form
      Private mainMenu1 As MainMenu
      Private menuItemHelp As MenuItem
      Private WithEvents menuItemAbout As MenuItem
      Private WithEvents menuItemOpen As MenuItem
      Private menuItemFile As MenuItem
      Private menuItemView As MenuItem
      Private menuItem8 As MenuItem
      Private WithEvents menuItemExit As MenuItem
      Private WithEvents menuItemWaveformInfo As MenuItem
      Private menuItemAudio As MenuItem
      Private WithEvents menuItemCreateAudio As MenuItem
      Private WithEvents menuItemPlayAudio As MenuItem
      Private components As IContainer
      Private imageList1 As ImageList
      Private treeViewElements As TreeView
      Private WithEvents splitContainer1 As SplitContainer

      Private ds As DicomDataSet
      Private m_CurrentWaveformGroup As DicomWaveformGroup
      Private m_bLoadedWaveform As Boolean
      Private m_nPageWidth As Integer = Screen.PrimaryScreen.Bounds.Width
      Private m_nPageHeight As Integer = Screen.PrimaryScreen.Bounds.Height
      Private m_nFrameWidth As Integer = 100
      Private m_nNumHorzPoints As Integer = 50
      Private m_nNumVerPoints As Integer = 50
      Private m_nCellWidth As Integer
      Private m_nCellHeight As Integer
      Private openFileDialog1 As OpenFileDialog
      Private m_nRibbonWidth As Integer = 0
      Private _openInitialPath As String = ""

      Public Sub New()
         '
         ' Required for Windows Form Designer support
         '
         InitializeComponent()

         Utils.EngineStartup()
      End Sub

      ''' <summary>
      ''' Clean up any resources being used.
      ''' </summary>
      Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
         If disposing Then
            If Not components Is Nothing Then
               components.Dispose()
            End If
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
         Me.mainMenu1 = New System.Windows.Forms.MainMenu(Me.components)
         Me.menuItemFile = New System.Windows.Forms.MenuItem()
         Me.menuItemOpen = New System.Windows.Forms.MenuItem()
         Me.menuItem8 = New System.Windows.Forms.MenuItem()
         Me.menuItemExit = New System.Windows.Forms.MenuItem()
         Me.menuItemView = New System.Windows.Forms.MenuItem()
         Me.menuItemWaveformInfo = New System.Windows.Forms.MenuItem()
         Me.menuItemAudio = New System.Windows.Forms.MenuItem()
         Me.menuItemCreateAudio = New System.Windows.Forms.MenuItem()
         Me.menuItemPlayAudio = New System.Windows.Forms.MenuItem()
         Me.menuItemHelp = New System.Windows.Forms.MenuItem()
         Me.menuItemAbout = New System.Windows.Forms.MenuItem()
         Me.treeViewElements = New System.Windows.Forms.TreeView()
         Me.imageList1 = New System.Windows.Forms.ImageList(Me.components)
         Me.splitContainer1 = New System.Windows.Forms.SplitContainer()
         Me.openFileDialog1 = New System.Windows.Forms.OpenFileDialog()
         Me.splitContainer1.Panel1.SuspendLayout()
         Me.splitContainer1.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' mainMenu1
         ' 
         Me.mainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItemFile, Me.menuItemView, Me.menuItemAudio, Me.menuItemHelp})
         ' 
         ' menuItemFile
         ' 
         Me.menuItemFile.Index = 0
         Me.menuItemFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItemOpen, Me.menuItem8, Me.menuItemExit})
         Me.menuItemFile.Text = "&File"
         ' 
         ' menuItemOpen
         ' 
         Me.menuItemOpen.Index = 0
         Me.menuItemOpen.Text = "&Open..."
         '			Me.menuItemOpen.Click += New System.EventHandler(Me.menuItemOpen_Click);
         ' 
         ' menuItem8
         ' 
         Me.menuItem8.Index = 1
         Me.menuItem8.Text = "-"
         ' 
         ' menuItemExit
         ' 
         Me.menuItemExit.Index = 2
         Me.menuItemExit.Text = "&Exit"
         '			Me.menuItemExit.Click += New System.EventHandler(Me.menuItemExit_Click);
         ' 
         ' menuItemView
         ' 
         Me.menuItemView.Index = 1
         Me.menuItemView.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItemWaveformInfo})
         Me.menuItemView.Text = "&View"
         ' 
         ' menuItemWaveformInfo
         ' 
         Me.menuItemWaveformInfo.Index = 0
         Me.menuItemWaveformInfo.Text = "&Waveform Info"
         '			Me.menuItemWaveformInfo.Click += New System.EventHandler(Me.menuItemWaveformInfo_Click);
         ' 
         ' menuItemAudio
         ' 
         Me.menuItemAudio.Index = 2
         Me.menuItemAudio.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItemCreateAudio, Me.menuItemPlayAudio})
         Me.menuItemAudio.Text = "Audio"
         ' 
         ' menuItemCreateAudio
         ' 
         Me.menuItemCreateAudio.Index = 0
         Me.menuItemCreateAudio.Text = "&Create Basic Voice Audio File"
         '			Me.menuItemCreateAudio.Click += New System.EventHandler(Me.menuItemCreateAudio_Click);
         ' 
         ' menuItemPlayAudio
         ' 
         Me.menuItemPlayAudio.Index = 1
         Me.menuItemPlayAudio.Text = "&Play Basic Voice Audio File"
         '			Me.menuItemPlayAudio.Click += New System.EventHandler(Me.menuItemPlayAudio_Click);
         ' 
         ' menuItemHelp
         ' 
         Me.menuItemHelp.Index = 3
         Me.menuItemHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.menuItemAbout})
         Me.menuItemHelp.Text = "&Help"
         ' 
         ' menuItemAbout
         ' 
         Me.menuItemAbout.Index = 0
         Me.menuItemAbout.Text = "&About"
         '			Me.menuItemAbout.Click += New System.EventHandler(Me.menuItemAbout_Click);
         ' 
         ' treeViewElements
         ' 
         Me.treeViewElements.Dock = System.Windows.Forms.DockStyle.Fill
         Me.treeViewElements.FullRowSelect = True
         Me.treeViewElements.HideSelection = False
         Me.treeViewElements.ImageIndex = 0
         Me.treeViewElements.ImageList = Me.imageList1
         Me.treeViewElements.Location = New System.Drawing.Point(0, 0)
         Me.treeViewElements.Name = "treeViewElements"
         Me.treeViewElements.SelectedImageIndex = 0
         Me.treeViewElements.Size = New System.Drawing.Size(158, 569)
         Me.treeViewElements.TabIndex = 0
         ' 
         ' imageList1
         ' 
         Me.imageList1.ImageStream = (CType(resources.GetObject("imageList1.ImageStream"), System.Windows.Forms.ImageListStreamer))
         Me.imageList1.TransparentColor = System.Drawing.Color.Transparent
         Me.imageList1.Images.SetKeyName(0, "")
         Me.imageList1.Images.SetKeyName(1, "")
         Me.imageList1.Images.SetKeyName(2, "")
         Me.imageList1.Images.SetKeyName(3, "")
         ' 
         ' splitContainer1
         ' 
         Me.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
         Me.splitContainer1.Location = New System.Drawing.Point(0, 0)
         Me.splitContainer1.Name = "splitContainer1"
         ' 
         ' splitContainer1.Panel1
         ' 
         Me.splitContainer1.Panel1.Controls.Add(Me.treeViewElements)
         ' 
         ' splitContainer1.Panel2
         ' 
         '			Me.splitContainer1.Panel2.Paint += New System.Windows.Forms.PaintEventHandler(Me.splitContainer1_Panel2_Paint);
         Me.splitContainer1.Size = New System.Drawing.Size(825, 569)
         Me.splitContainer1.SplitterDistance = 158
         Me.splitContainer1.TabIndex = 1
         ' 
         ' openFileDialog1
         ' 
         Me.openFileDialog1.Filter = "DICOM Files (*.dic;*.dcm)|*.dic;*.dcm|All files (*.*)|*.*"
         Me.openFileDialog1.Multiselect = True
         Me.openFileDialog1.Title = "Open Dicom File"
         ' 
         ' MainForm
         ' 
         Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
         Me.ClientSize = New System.Drawing.Size(825, 569)
         Me.Controls.Add(Me.splitContainer1)
         Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
         Me.Menu = Me.mainMenu1
         Me.Name = "MainForm"
         Me.Text = "DICOM Waveforms Demo"
         Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
         '			Me.Load += New System.EventHandler(Me.MainForm_Load);
         Me.splitContainer1.Panel1.ResumeLayout(False)
         Me.splitContainer1.ResumeLayout(False)
         Me.ResumeLayout(False)

      End Sub
#End Region

      ''' <summary>
      ''' The main entry point for the application.
      ''' </summary>
      <STAThread()> _
      Shared Sub Main()

         

         If Not Support.SetLicense() Then
            Return
         End If

         If RasterSupport.IsLocked(RasterSupportType.Medical) Then
            MessageBox.Show(String.Format("{0} Support is locked!", RasterSupportType.Medical.ToString()), "Warning")
            Return
         End If

         Application.Run(New MainForm())
      End Sub

      Private Sub menuItemAbout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemAbout.Click
         Using aboutDialog As New AboutDialog("DICOM Waveforms", ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using
      End Sub

      Private Sub menuItemExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemExit.Click
         Application.Exit()
      End Sub

      Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
         Try
            ' Initialize the right panel where drawing will take place
            splitContainer1.Panel2.AutoScroll = True
            splitContainer1.Panel2.AutoScrollMinSize = New Size(m_nPageWidth, m_nPageHeight)

            ' Calculate the cell width and height which we'll use later in the drawing code
            m_nCellWidth = CInt(CDbl(m_nPageWidth) / CDbl(m_nNumHorzPoints))
            m_nCellHeight = CInt(CDbl(m_nPageHeight) / CDbl(m_nNumVerPoints))

            m_bLoadedWaveform = False
            menuItemWaveformInfo.Enabled = m_bLoadedWaveform

            ds = New DicomDataSet()
            If ds Is Nothing Then
               MessageBox.Show("Can't create dicom object. Quitting app.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
               Application.Exit()
               Return
            End If

            BringToFront()

            AddHandler Application.ApplicationExit, AddressOf Application_ApplicationExit
         Catch ex As Exception
            MessageBox.Show(ex.ToString())
         End Try
      End Sub

      Private Sub Application_ApplicationExit(ByVal sender As Object, ByVal e As EventArgs)
         Utils.EngineShutdown()
      End Sub

      Private Sub menuItemOpen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles menuItemOpen.Click
         Try
            openFileDialog1.InitialDirectory = _openInitialPath
            If openFileDialog1.ShowDialog() = DialogResult.OK Then
               _openInitialPath = Path.GetDirectoryName(openFileDialog1.FileName)
               menuItemClose_Click(Nothing, New EventArgs())
               OpenDataset(openFileDialog1.FileName)
               Invalidate(True)
               menuItemWaveformInfo.Enabled = m_bLoadedWaveform
            End If
         Catch ex As Exception
            MessageBox.Show(ex.ToString())
         End Try
      End Sub

      '
      '* Loads a dataset, checks to make sure it has waveforms, and then builds the tree
      '
      Private Sub OpenDataset(ByVal file As String)
         Cursor = Cursors.WaitCursor

         Try
            m_bLoadedWaveform = False

            ds.Load(file, DicomDataSetLoadFlags.LoadAndClose)


            ' Do we have any waveform groups at all
            If ds.WaveformGroupCount = 0 Then
               MessageBox.Show("The DICOM file you are trying to load doesn't include any waveforms.")
               m_bLoadedWaveform = False
               Return
            Else
               m_bLoadedWaveform = True
            End If

            ' There is at least one waveform group in this DS, the first waveform group will be loaded
            If Not m_CurrentWaveformGroup Is Nothing Then
               m_CurrentWaveformGroup.Reset()
            End If
            m_CurrentWaveformGroup = ds.GetWaveformGroup(0)

            ' Update the Tree View
            UpdateTree()
         Catch exception As Exception
            MessageBox.Show(exception.ToString())
         Finally
            Cursor = Cursors.Arrow
         End Try

         If treeViewElements.Nodes.Count > 0 Then
            treeViewElements.SelectedNode = treeViewElements.Nodes(0)
         End If
      End Sub

      '
      '* Finds the first module and then continues to fill the tree
      '
      Private Sub FillTreeModules()
         Try
            Dim x As Integer = 0
            Do While x < ds.ModuleCount
               Dim node As TreeNode
               Dim [module] As DicomModule
               Dim iod As DicomIod

               [module] = ds.FindModuleByIndex(x)
               iod = DicomIodTable.Instance.FindModule(ds.InformationClass, [module].Type)

               node = treeViewElements.Nodes.Add(iod.Name)
               node.Tag = [module]
               For Each element As DicomElement In [module].Elements
                  FillModuleSubTree(element, node, False)
               Next element
               x += 1
            Loop
         Catch ex As Exception
            MessageBox.Show(ex.ToString())
         End Try
      End Sub

      '
      '* Recursively fills the tree with elements and modules
      '
      Private Sub FillModuleSubTree(ByVal element As DicomElement, ByVal ParentNode As TreeNode, ByVal recurse As Boolean)
         Try
            Dim node As TreeNode
            Dim name, value As String
            Dim temp As String = ""
            Dim tempElement As DicomElement

            Dim tag As DicomTag

            ' Build the string representing the tree node
            ' Get the tag
            tag = DicomTagTable.Instance.Find(element.Tag)
            temp = String.Format("{0:x4}:{1:x4} - ", Utils.GetGroup(CLng(element.Tag)), Utils.GetElement(CLng(element.Tag)))

            ' Get the tag name
            If tag Is Nothing Then
               name = "Item"
            Else
               name = tag.Name
            End If

            ' Get the tag value
            value = ""
            value = ds.GetConvertValue(element)

            temp = temp & name & " : " & value

            If Not ParentNode Is Nothing Then
               node = ParentNode.Nodes.Add(temp)
            Else
               node = treeViewElements.Nodes.Add(temp)
            End If

            node.Tag = element

            If ds.IsVolatileElement(element) Then
               node.ForeColor = Color.Red
            End If

            node.ImageIndex = 1
            node.SelectedImageIndex = 1

            ' Recursively fille the tree if there are children
            tempElement = ds.GetChildElement(element, True)
            If Not tempElement Is Nothing Then
               node.ImageIndex = 0
               node.SelectedImageIndex = 0
               FillModuleSubTree(tempElement, node, True)
            End If

            ' Recursively fill the tree for the next element
            If recurse Then
               tempElement = ds.GetNextElement(element, True, True)

               If Not tempElement Is Nothing Then
                  FillModuleSubTree(tempElement, ParentNode, True)
               End If
            End If
         Catch ex As Exception
            MessageBox.Show(ex.ToString())
         End Try
      End Sub

      Private Sub menuItemClose_Click(ByVal sender As Object, ByVal e As System.EventArgs)
         Try
            treeViewElements.BeginUpdate()
            treeViewElements.Nodes.Clear()
            treeViewElements.EndUpdate()

            ds.Reset()
         Catch ex As Exception
            MessageBox.Show(ex.ToString())
         End Try
      End Sub

      '
      '* Clears the tree and starts the recursive building process
      '
      Private Sub UpdateTree()
         Try
            treeViewElements.BeginUpdate()
            treeViewElements.Nodes.Clear()

            FillTreeModules()
            treeViewElements.EndUpdate()
         Catch ex As Exception
            Throw ex
         End Try
      End Sub

      '
      '* Paints the graph and the waveforms (if they exist) on the right panel
      '
      Private Sub splitContainer1_Panel2_Paint(ByVal sender As Object, ByVal e As PaintEventArgs) Handles splitContainer1.Panel2.Paint
         Try
            ' update the transform in case the panel has been scrolled
            e.Graphics.TranslateTransform(splitContainer1.Panel2.AutoScrollPosition.X, splitContainer1.Panel2.AutoScrollPosition.Y)

            ' Draw grid
            e.Graphics.FillRectangle(Brushes.Black, Screen.PrimaryScreen.Bounds)

            ' Horizontal lines
            Dim y As Integer
            Dim i As Integer = 0
            Do While i < m_nNumHorzPoints
               y = (i * m_nCellHeight) + m_nCellHeight
               e.Graphics.DrawLine(New Pen(Color.FromArgb(50, 50, 50)), New System.Drawing.Point(0, y), New System.Drawing.Point(m_nPageWidth, y))
               i += 1
            Loop

            ' Vertical Lines
            Dim x As Integer
            i = 0
            Do While i < m_nNumVerPoints
               x = (i * m_nCellWidth) + m_nRibbonWidth
               e.Graphics.DrawLine(New Pen(Color.FromArgb(50, 50, 50)), New System.Drawing.Point(x, 0), New System.Drawing.Point(x, m_nPageHeight))
               i += 1
            Loop

            ' Draw the waveform if one is loaded
            If m_bLoadedWaveform Then
               DrawWaveform(e.Graphics)
            End If
         Catch ex As Exception
            MessageBox.Show(ex.ToString())
         End Try
      End Sub

      '
      '* Draws the waveform(s) on the Graphics object
      '
      Private Sub DrawWaveform(ByVal g As Graphics)
         If m_CurrentWaveformGroup Is Nothing Then
            Return
         End If
         Try
            ' Get number of channels
            Dim nChannelsCount As Integer = m_CurrentWaveformGroup.ChannelCount
            If nChannelsCount = 0 Then
               Return
            End If

            ' How many samples do we have in a channel
            Dim nSamplesPerChannel As Integer = m_CurrentWaveformGroup.GetNumberOfSamplesPerChannel()
            If nSamplesPerChannel = 0 Then
               Return
            End If

            Dim nAllData As Integer()
            Dim nSampleIndex, nChannelIndex As Integer
            Dim iMaxVal, iMinVal As Integer
            Dim dExtent As Double = 0
            Dim dVertStep As Double = 0
            Dim DrawTextRect As RectangleF

            Dim nViewRectHeight As Integer = m_nPageHeight - m_nFrameWidth
            Dim nViewRectWidth As Integer = m_nPageWidth

            Dim ChannelSource As DicomCodeSequenceItem

            iMaxVal = -32768
            iMinVal = 32767

            ' Find the minimum and maximum value for all the channels
            nChannelIndex = 0
            Do While nChannelIndex < nChannelsCount
               nAllData = m_CurrentWaveformGroup.GetChannel(nChannelIndex).GetChannelSamples()

               nSampleIndex = 0
               Do While nSampleIndex < nSamplesPerChannel
                  If nAllData(nSampleIndex) > iMaxVal Then
                     iMaxVal = nAllData(nSampleIndex)
                  ElseIf nAllData(nSampleIndex) < iMinVal Then
                     iMinVal = nAllData(nSampleIndex)
                  End If
                  nSampleIndex += 1
               Loop

               dVertStep = nViewRectHeight / nChannelsCount
               dExtent = ((iMaxVal - iMinVal) * 1.2) / dVertStep
               nChannelIndex += 1
            Loop

            Dim nIndex As Integer = 0
            Dim strText As String
            Dim ann As DicomWaveformAnnotation
            Dim lStartPoint As Long

            ' Loop through the channels one by one
            nChannelIndex = 0
            Do While nChannelIndex < nChannelsCount
               strText = ""
               nIndex = nChannelsCount - nChannelIndex - 1

               'Get the data for this channel
               nAllData = m_CurrentWaveformGroup.GetChannel(nIndex).GetChannelSamples()
               '//lStartPoint = ((nViewRectHeight + (int)((double)((nChannelIndex) * -1 * (int)dVertStep) - (nAllData[0] - iMinVal) / dExtent))) + m_nFrameWidth / 2;
               lStartPoint = CLng(((nViewRectHeight + CInt(CDbl((nChannelIndex) * -1 * CInt(dVertStep)) - (nAllData(0) - iMinVal) / dExtent))) + m_nFrameWidth / 2)


               ' Get the channel source
               ChannelSource = m_CurrentWaveformGroup.GetChannel(nIndex).GetChannelSource()

               DrawTextRect = New RectangleF(5, lStartPoint, m_nFrameWidth - 5, CSng(dVertStep))

               If (Not ChannelSource Is Nothing) AndAlso (Not ChannelSource.CodeMeaning Is Nothing) Then
                  ' Display the channel source
                  strText = ChannelSource.CodeMeaning
                  If m_CurrentWaveformGroup.GetChannel(nIndex).GetAnnotationCount() > 0 Then
                     ' Display the channel annotation
                     ann = m_CurrentWaveformGroup.GetChannel(nIndex).GetAnnotation(0)
                     If Not ann Is Nothing Then
                        If (Not ann.UnformattedTextValue Is Nothing) AndAlso (ann.UnformattedTextValue <> "") Then
                           strText &= " ("
                           strText &= ann.UnformattedTextValue
                           strText &= ")"
                        Else
                           If (Not ann.CodedName Is Nothing) AndAlso ((Not ann.CodedName.CodeMeaning Is Nothing) AndAlso ann.CodedName.CodeMeaning <> "") Then
                              strText &= " ("
                              strText &= ann.CodedName.CodeMeaning
                              strText &= ")"
                           End If
                        End If
                     End If
                  End If

                  g.DrawString(strText, New Font(FontFamily.GenericSansSerif, 10), Brushes.Red, DrawTextRect)
               End If

               Dim nDiff As Integer
               Dim dRatio As Double
               Dim nOffset As Integer

               ' Draw the points/lines for this channel
               Dim ptPreviousPoint, ptCurrentPoint As System.Drawing.Point
               ptPreviousPoint = New System.Drawing.Point(m_nFrameWidth, CInt(lStartPoint))
               nSampleIndex = 1
               Do While nSampleIndex < nSamplesPerChannel
                  nDiff = nAllData(nSampleIndex) - iMinVal
                  dRatio = CDbl(nDiff) / dExtent
                  nOffset = CInt(CDbl(m_nFrameWidth) / 2.0)

                  ptCurrentPoint = New System.Drawing.Point(CInt((nSampleIndex * nViewRectWidth / nSamplesPerChannel) + m_nFrameWidth), ((nViewRectHeight + CInt((CDbl(nChannelIndex) * -1 * dVertStep) - dRatio))) + nOffset)

                  g.DrawLine(New Pen(Color.FromArgb(0, 255, 0)), ptPreviousPoint, ptCurrentPoint)

                  ptPreviousPoint = ptCurrentPoint
                  nSampleIndex += 1
               Loop
               nChannelIndex += 1
            Loop
         Catch ex As Exception
            MessageBox.Show(ex.ToString())
         End Try
      End Sub

      '
      '* Displays a dialog which reports the information about the
      '*   waveform group and different channels
      '
      Private Sub menuItemWaveformInfo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menuItemWaveformInfo.Click
         Dim AttributesDlg As WaveformAttributesDialog = New WaveformAttributesDialog(m_CurrentWaveformGroup)
         AttributesDlg.ShowDialog(Me)
      End Sub

      '
      '* Displays a dialog for creating a Basic Voice Audio dicom file
      '
      Private Sub menuItemCreateAudio_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menuItemCreateAudio.Click
         Dim BasicVoiceDlg As BasicVoiceDialog = New BasicVoiceDialog()
         BasicVoiceDlg.ShowDialog(Me)
      End Sub

      '
      '* Displays a dialog for playing a basic voice audio Dicom file.
      '
      Private Sub menuItemPlayAudio_Click(ByVal sender As Object, ByVal e As EventArgs) Handles menuItemPlayAudio.Click
         Dim PlayDlg As PlayBasicVoiceDialog = New PlayBasicVoiceDialog()
         PlayDlg.ShowDialog(Me)
      End Sub
   End Class
End Namespace
