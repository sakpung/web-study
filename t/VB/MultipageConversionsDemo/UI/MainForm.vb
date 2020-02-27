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
Imports System.IO

Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.WinForms.CommonDialogs.File
Imports System.Security.Permissions
Imports Leadtools.Demos.Dialogs

Namespace MultipageConversions
   Public Class MainForm : Inherits Form
      Private menuMain As System.Windows.Forms.MenuStrip
      Private _mnuOptions As System.Windows.Forms.ToolStripMenuItem
      Private _mnuHelp As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _mnuFileExit As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _mnuHelpAbout As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _mnuFileLoadTifFiles As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _mnuFileSave As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _mnuOptionsSingleRasterImage As System.Windows.Forms.ToolStripMenuItem
      Private WithEvents _mnuOptionsOnePageAtTime As System.Windows.Forms.ToolStripMenuItem
      Private label2 As System.Windows.Forms.Label
      Private _labelLoadedFiles As System.Windows.Forms.Label
      Private _labelConverted As System.Windows.Forms.Label
      Private label5 As System.Windows.Forms.Label
      Private groupBox1 As System.Windows.Forms.GroupBox
      Private label1 As System.Windows.Forms.Label
      Private _mnuFile As System.Windows.Forms.ToolStripMenuItem

      Private _codecs As RasterCodecs
      Private _saveDialog As SaveFileDialog
      Private _loader As ImageFileLoader
      Private _szMultiPageFile As String
      Private _lstImagesInfoMulti As List(Of ImageInformation) = Nothing
      Private components As System.ComponentModel.IContainer = Nothing

      Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
         If disposing AndAlso (Not components Is Nothing) Then
            components.Dispose()
         End If
         MyBase.Dispose(disposing)
      End Sub

      <STAThread()> _
      Shared Sub Main()
         
         If Not Support.SetLicense() Then
            Return
         End If

         Application.EnableVisualStyles()
         Application.SetCompatibleTextRenderingDefault(False)
         Application.Run(New MainForm())
      End Sub

      Public Sub New()
         InitializeComponent()
         InitClass()
      End Sub

      Private Sub InitClass()
         Messager.Caption = "LEADTOOLS for .NET VB Multipage Conversions"
         Text = Messager.Caption
         _codecs = New RasterCodecs()
         _saveDialog = New SaveFileDialog()
         _saveDialog.Filter = "Tiff Files (*.tif)|*.tif|Pdf Files (*.pdf)|*.pdf"
         If Directory.Exists(DemosGlobal.ImagesFolder) Then
            _saveDialog.InitialDirectory = DemosGlobal.ImagesFolder
         End If

         _mnuFileSave.Enabled = False
      End Sub

      Private Sub InitializeComponent()
         Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
         Me._mnuFile = New System.Windows.Forms.ToolStripMenuItem()
         Me._mnuFileLoadTifFiles = New System.Windows.Forms.ToolStripMenuItem()
         Me._mnuFileSave = New System.Windows.Forms.ToolStripMenuItem()
         Me._mnuFileExit = New System.Windows.Forms.ToolStripMenuItem()
         Me.menuMain = New System.Windows.Forms.MenuStrip()
         Me._mnuOptions = New System.Windows.Forms.ToolStripMenuItem()
         Me._mnuOptionsSingleRasterImage = New System.Windows.Forms.ToolStripMenuItem()
         Me._mnuOptionsOnePageAtTime = New System.Windows.Forms.ToolStripMenuItem()
         Me._mnuHelp = New System.Windows.Forms.ToolStripMenuItem()
         Me._mnuHelpAbout = New System.Windows.Forms.ToolStripMenuItem()
         Me.label2 = New System.Windows.Forms.Label()
         Me._labelLoadedFiles = New System.Windows.Forms.Label()
         Me._labelConverted = New System.Windows.Forms.Label()
         Me.label5 = New System.Windows.Forms.Label()
         Me.groupBox1 = New System.Windows.Forms.GroupBox()
         Me.label1 = New System.Windows.Forms.Label()
         Me.menuMain.SuspendLayout()
         Me.groupBox1.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _mnuFile
         ' 
         Me._mnuFile.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._mnuFileLoadTifFiles, Me._mnuFileSave, Me._mnuFileExit})
         Me._mnuFile.Name = "_mnuFile"
         Me._mnuFile.Size = New System.Drawing.Size(37, 20)
         Me._mnuFile.Text = "&File"
         ' 
         ' _mnuFileLoadTifFiles
         ' 
         Me._mnuFileLoadTifFiles.Name = "_mnuFileLoadTifFiles"
         Me._mnuFileLoadTifFiles.Size = New System.Drawing.Size(143, 22)
         Me._mnuFileLoadTifFiles.Text = "&Load Tif Files"
         ' 
         ' _mnuFileSave
         ' 
         Me._mnuFileSave.Name = "_mnuFileSave"
         Me._mnuFileSave.ShortcutKeys = (CType((System.Windows.Forms.Keys.Control Or System.Windows.Forms.Keys.S), System.Windows.Forms.Keys))
         Me._mnuFileSave.Size = New System.Drawing.Size(143, 22)
         Me._mnuFileSave.Text = "&Save"
         ' 
         ' _mnuFileExit
         ' 
         Me._mnuFileExit.Name = "_mnuFileExit"
         Me._mnuFileExit.Size = New System.Drawing.Size(143, 22)
         Me._mnuFileExit.Text = "E&xit"
         ' 
         ' menuMain
         ' 
         Me.menuMain.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me._mnuFile, Me._mnuOptions, Me._mnuHelp})
         Me.menuMain.Location = New System.Drawing.Point(0, 0)
         Me.menuMain.Name = "menuMain"
         Me.menuMain.Size = New System.Drawing.Size(586, 24)
         Me.menuMain.TabIndex = 4
         ' 
         ' _mnuOptions
         ' 
         Me._mnuOptions.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._mnuOptionsSingleRasterImage, Me._mnuOptionsOnePageAtTime})
         Me._mnuOptions.Name = "_mnuOptions"
         Me._mnuOptions.Size = New System.Drawing.Size(61, 20)
         Me._mnuOptions.Text = "&Options"
         ' 
         ' _mnuOptionsSingleRasterImage
         ' 
         Me._mnuOptionsSingleRasterImage.Checked = True
         Me._mnuOptionsSingleRasterImage.CheckState = System.Windows.Forms.CheckState.Checked
         Me._mnuOptionsSingleRasterImage.Name = "_mnuOptionsSingleRasterImage"
         Me._mnuOptionsSingleRasterImage.Size = New System.Drawing.Size(174, 22)
         Me._mnuOptionsSingleRasterImage.Text = "Single RasterImage"
         ' 
         ' _mnuOptionsOnePageAtTime
         ' 
         Me._mnuOptionsOnePageAtTime.Name = "_mnuOptionsOnePageAtTime"
         Me._mnuOptionsOnePageAtTime.Size = New System.Drawing.Size(174, 22)
         Me._mnuOptionsOnePageAtTime.Text = "One Page At time"
         ' 
         ' _mnuHelp
         ' 
         Me._mnuHelp.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me._mnuHelpAbout})
         Me._mnuHelp.Name = "_mnuHelp"
         Me._mnuHelp.Size = New System.Drawing.Size(44, 20)
         Me._mnuHelp.Text = "&Help"
         ' 
         ' _mnuHelpAbout
         ' 
         Me._mnuHelpAbout.Name = "_mnuHelpAbout"
         Me._mnuHelpAbout.Size = New System.Drawing.Size(107, 22)
         Me._mnuHelpAbout.Text = "&About"
         ' 
         ' label2
         ' 
         Me.label2.AutoSize = True
         Me.label2.Location = New System.Drawing.Point(12, 314)
         Me.label2.Name = "label2"
         Me.label2.Size = New System.Drawing.Size(127, 13)
         Me.label2.TabIndex = 6
         Me.label2.Text = "Number Of Loaded Files :"
         ' 
         ' _labelLoadedFiles
         ' 
         Me._labelLoadedFiles.AutoSize = True
         Me._labelLoadedFiles.Location = New System.Drawing.Point(145, 314)
         Me._labelLoadedFiles.Name = "_labelLoadedFiles"
         Me._labelLoadedFiles.Size = New System.Drawing.Size(13, 13)
         Me._labelLoadedFiles.TabIndex = 7
         Me._labelLoadedFiles.Text = "0"
         ' 
         ' _labelConverted
         ' 
         Me._labelConverted.AutoSize = True
         Me._labelConverted.Location = New System.Drawing.Point(347, 314)
         Me._labelConverted.Name = "_labelConverted"
         Me._labelConverted.Size = New System.Drawing.Size(13, 13)
         Me._labelConverted.TabIndex = 9
         Me._labelConverted.Text = "0"
         ' 
         ' label5
         ' 
         Me.label5.AutoSize = True
         Me.label5.Location = New System.Drawing.Point(255, 314)
         Me.label5.Name = "label5"
         Me.label5.Size = New System.Drawing.Size(86, 13)
         Me.label5.TabIndex = 8
         Me.label5.Text = "Converted Files :"
         ' 
         ' groupBox1
         ' 
         Me.groupBox1.Controls.Add(Me.label1)
         Me.groupBox1.Location = New System.Drawing.Point(12, 38)
         Me.groupBox1.Name = "groupBox1"
         Me.groupBox1.Size = New System.Drawing.Size(549, 185)
         Me.groupBox1.TabIndex = 10
         Me.groupBox1.TabStop = False
         ' 
         ' label1
         ' 
         Me.label1.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
         Me.label1.AutoSize = True
         Me.label1.Location = New System.Drawing.Point(15, 34)
         Me.label1.Name = "label1"
         Me.label1.Size = New System.Drawing.Size(510, 130)
         Me.label1.TabIndex = 6
         Me.label1.Text = resources.GetString("label1.Text")
         ' 
         ' MainForm
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(586, 336)
         Me.Controls.Add(Me.groupBox1)
         Me.Controls.Add(Me._labelConverted)
         Me.Controls.Add(Me.label5)
         Me.Controls.Add(Me._labelLoadedFiles)
         Me.Controls.Add(Me.label2)
         Me.Controls.Add(Me.menuMain)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.Icon = (CType(resources.GetObject("$this.Icon"), System.Drawing.Icon))
         Me.MainMenuStrip = Me.menuMain
         Me.MaximizeBox = False
         Me.Name = "MainForm"
         Me.Text = "MultipageConversions"
         Me.menuMain.ResumeLayout(False)
         Me.menuMain.PerformLayout()
         Me.groupBox1.ResumeLayout(False)
         Me.groupBox1.PerformLayout()
         Me.ResumeLayout(False)
         Me.PerformLayout()

      End Sub

      Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
#If Not LEADTOOLS_V17_OR_LATER Then
		 RasterCodecs.Shutdown()
#End If
      End Sub

      Private Function LoadImages(ByVal bMultiSelect As Boolean) As List(Of ImageInformation)
         Try
            Dim bSetInitialPath As Boolean = False
            If _loader Is Nothing Then
               bSetInitialPath = True
            End If

            _loader = New ImageFileLoader()
            _loader.ShowLoadPagesDialog = False

            If bSetInitialPath Then
               If Directory.Exists(DemosGlobal.ImagesFolder) Then
                  _loader.OpenDialogInitialPath = DemosGlobal.ImagesFolder
               End If
            End If

            _loader.MultiSelect = bMultiSelect
            Dim filters As RasterOpenDialogLoadFormat() = {New RasterOpenDialogLoadFormat("Tiff", "*.tif;*.tiff")}
            _loader.Filters = filters
            _loader.Images.Clear()
            Dim filesCount As Integer = _loader.Load(Me, _codecs, True)
            If filesCount > 0 Then
               Dim i As Integer = 0
               Do While i < _loader.Images.Count
                  If Not _loader.Images(i).Image Is Nothing Then
                     _loader.Images(i).Image.Dispose()
                  End If
                  i += 1
               Loop

               Return _loader.Images
            End If
         Catch ex As Exception
            Messager.ShowFileOpenError(Me, _loader.FileName, ex)
         End Try

         Return Nothing
      End Function

      Private Sub EnableControls(ByVal bEnable As Boolean)
         _mnuFile.Enabled = bEnable
         _mnuOptions.Enabled = bEnable
      End Sub

      Private Sub _mnuFileExit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _mnuFileExit.Click
         Application.Exit()
      End Sub

      Private Sub _mnuFileLoadTifFiles_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _mnuFileLoadTifFiles.Click
         Dim cursor As Cursor = Nothing
         Try
            cursor = Me.Cursor
            Me.Cursor = Cursors.WaitCursor
            EnableControls(False)

            _lstImagesInfoMulti = LoadImages(True)

            If Not _lstImagesInfoMulti Is Nothing Then
               Me._labelLoadedFiles.Text = _lstImagesInfoMulti.Count.ToString()
               _mnuFileSave.Enabled = True
               Me._labelConverted.Text = "0"
            Else
               Me._labelLoadedFiles.Text = "0"
               Me._labelConverted.Text = "0"
               _mnuFileSave.Enabled = False
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         Finally
            EnableControls(True)
            Me.Cursor = cursor
         End Try
      End Sub

      Private Sub _mnuFileSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _mnuFileSave.Click
         If _lstImagesInfoMulti Is Nothing OrElse _lstImagesInfoMulti.Count <= 0 Then
            Messager.ShowError(Me, "Please Load Files")
            Return
         End If

         Dim img As RasterImage = Nothing
         Dim cursor As Cursor = Me.Cursor

         Try
            cursor = Me.Cursor
            Me.Cursor = Cursors.WaitCursor
            EnableControls(False)

            Me._labelConverted.Text = "0"

            If _saveDialog.ShowDialog() = DialogResult.OK Then
               Dim selectedformat As RasterImageFormat = RasterImageFormat.CcittGroup4
               If _saveDialog.FilterIndex = 2 Then
                  selectedformat = RasterImageFormat.RasPdfG4
               End If

               _szMultiPageFile = _saveDialog.FileName
               If _mnuOptionsSingleRasterImage.Checked Then
                  Dim i As Integer = 0
                  Do While i < _lstImagesInfoMulti.Count
                     Dim loadedImage As RasterImage = _codecs.Load(_lstImagesInfoMulti(i).Name, 0, CodecsLoadByteOrder.BgrOrGrayOrRomm, 1, -1)
                     If i = 0 Then
                        img = loadedImage
                     Else
                        img.AddPages(loadedImage, 1, -1)
                     End If

                     _labelConverted.Text = (Convert.ToInt32(_labelConverted.Text) + 1).ToString()
                     Application.DoEvents()
                     i += 1
                  Loop

                  _codecs.Save(img, _szMultiPageFile, selectedformat, 0)

                  img.Dispose()
               Else
                  Dim i As Integer = 0
                  Do While i < _lstImagesInfoMulti.Count
                     Dim info As CodecsImageInfo = _codecs.GetInformation(_lstImagesInfoMulti(i).Name, True)
                     Dim j As Integer = 1
                     Do While j <= info.TotalPages

                        img = _codecs.Load(_lstImagesInfoMulti(i).Name, 0, CodecsLoadByteOrder.BgrOrGrayOrRomm, j, j)
                        If i = 0 AndAlso j = 1 Then
                           _codecs.Save(img, _szMultiPageFile, selectedformat, 0, 1, 1, 1, CodecsSavePageMode.Overwrite)
                        Else
                           Do While Not ReadyToAccess(_szMultiPageFile) 'Insure File is not inused by other processes
                              Application.DoEvents()
                           Loop

                           _codecs.Save(img, _szMultiPageFile, selectedformat, 0, 1, 1, -1, CodecsSavePageMode.Append)
                        End If

                        img.Dispose()
                        Application.DoEvents()
                        j += 1
                     Loop
                     _labelConverted.Text = (Convert.ToInt32(_labelConverted.Text) + 1).ToString()
                     info.Dispose()
                     Application.DoEvents()
                     i += 1
                  Loop
               End If

               Messager.ShowInformation(Me, "Save in MultiPageFile Done")
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         Finally
            Me.Cursor = cursor
            EnableControls(True)
         End Try
      End Sub

      Private Function ReadyToAccess(ByVal szFileName As String) As Boolean
         Try
            Using stream As Stream = File.OpenWrite(szFileName)
            End Using
            Return True
         Catch
            Return False
         End Try
      End Function

      Private Sub _mnuOptionsSingleRasterImage_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _mnuOptionsSingleRasterImage.Click
         _mnuOptionsSingleRasterImage.Checked = True
         _mnuOptionsOnePageAtTime.Checked = False
      End Sub

      Private Sub _mnuOptionsOnePageAtTime_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _mnuOptionsOnePageAtTime.Click
         _mnuOptionsOnePageAtTime.Checked = True
         _mnuOptionsSingleRasterImage.Checked = False
      End Sub

      Private Sub _mnuHelpAbout_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _mnuHelpAbout.Click
         Using aboutDialog As New AboutDialog("MultipageConversions", ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using
      End Sub
   End Class
End Namespace
