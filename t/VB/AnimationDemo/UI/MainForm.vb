' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Drawing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Text
Imports System.IO

Imports Leadtools.Demos
Imports Leadtools.Demos.Dialogs
Imports Leadtools
Imports Leadtools.Codecs
Imports Leadtools.ImageProcessing
Imports Leadtools.Controls

Imports Leadtools.Drawing
Imports System

Namespace AnimationDemo
   Partial Public Class MainForm
      Inherits Form
      Private _codecs As RasterCodecs
      Private _fillColor As RasterColor
      Public _progressDlg As ProgressForm
      Private _paintProperties As RasterPaintProperties
      Private _animateRegions As Boolean
      Private _saver As ImageFileSaver
      Private _useDpi As Boolean = True
      Private _animationMode As RasterPictureBoxAnimationMode = RasterPictureBoxAnimationMode.Infinite
      Private _frameSettings As FrameSettings
      Private _openInitialPath As String = String.Empty
      ''' <summary>
      ''' The main entry point for the application.
      ''' </summary>
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

         _saver = New ImageFileSaver()

         LoadImage(True, False)
         UpdateControls()
      End Sub

      Private Sub InitClass()
         Messager.Caption = "LEADTOOLS for .NET VB Animation Demo"
         Text = Messager.Caption

         _codecs = New RasterCodecs()
         _codecs.Options.Txt.Load.Enabled = False
         _fillColor = Leadtools.Demos.Converters.FromGdiPlusColor(Color.White)
         _paintProperties = RasterPaintProperties.[Default]
         _paintProperties.PaintDisplayMode = _paintProperties.PaintDisplayMode Or RasterPaintDisplayModeFlags.ScaleToGray
         _animateRegions = False

         UpdateControls()
      End Sub

      Private Sub CleanUp()
      End Sub

      Public ReadOnly Property ActiveViewerForm() As ViewerForm
         Get
            Return TryCast(ActiveMdiChild, ViewerForm)
         End Get
      End Property

      Public Sub UpdateControls()
         Dim activeForm As ViewerForm = ActiveViewerForm

         EnableAndVisibleMenu(_menuItemFileSave, activeForm IsNot Nothing)
         EnableAndVisibleMenu(_menuItemEditCopy, activeForm IsNot Nothing)
         EnableAndVisibleMenu(_menuItemPage, activeForm IsNot Nothing)
         EnableAndVisibleMenu(_menuItemView, activeForm IsNot Nothing)
         EnableAndVisibleMenu(_menuItemWindow, activeForm IsNot Nothing AndAlso MdiChildren.Length > 0)
         EnableAndVisibleMenu(_menuItemAnimation, activeForm IsNot Nothing)
         If activeForm IsNot Nothing Then
            EnableAndVisibleMenu(_menuItemPageFirst, activeForm.Image.PageCount > 1)
            EnableAndVisibleMenu(_menuItemPagePrevious, activeForm.Image.PageCount > 1)
            EnableAndVisibleMenu(_menuItemPageNext, activeForm.Image.PageCount > 1)
            EnableAndVisibleMenu(_menuItemPageLast, activeForm.Image.PageCount > 1)
            _menuItemPageSep1.Visible = activeForm.Image.PageCount > 1
            EnableAndVisibleMenu(_menuItemPageDeleteCurrentPage, activeForm.Image.PageCount > 1)

            If activeForm.Image.PageCount > 1 Then
               _menuItemPageFirst.Enabled = activeForm.Image.Page > 1
               _menuItemPagePrevious.Enabled = activeForm.Image.Page > 1
               _menuItemPageNext.Enabled = activeForm.Image.Page <> activeForm.Image.PageCount
               _menuItemPageLast.Enabled = activeForm.Image.Page <> activeForm.Image.PageCount
            End If

            _menuItemViewSizeModeNormal.Checked = activeForm.Viewer.SizeMode = RasterPictureBoxSizeMode.Normal
            _menuItemViewSizeModeStretch.Checked = activeForm.Viewer.SizeMode = RasterPictureBoxSizeMode.StretchImage
            _menuItemViewSizeModeCenter.Checked = activeForm.Viewer.SizeMode = RasterPictureBoxSizeMode.CenterImage
            _menuItemViewSizeModeZoom.Checked = activeForm.Viewer.SizeMode = RasterPictureBoxSizeMode.Fit
            _menuItemViewSizeModeAuto.Checked = activeForm.Viewer.SizeMode = RasterPictureBoxSizeMode.AutoSize
         End If
      End Sub

      Private Sub EnableAndVisibleMenu(menu As ToolStripMenuItem, value As Boolean)
         menu.Enabled = value
         menu.Visible = value
      End Sub

      Private Sub _menuItemFileOpen_Click(sender As Object, e As EventArgs) Handles _menuItemFileOpen.Click
         LoadImage(False, False)
         UpdateControls()
      End Sub

      Private Sub _menuItemFileSave_Click(sender As Object, e As EventArgs) Handles _menuItemFileSave.Click
         Try
            DemosGlobal.SetDefaultComments(ActiveViewerForm.Viewer.Image, _codecs)
            _saver.Save(Me, _codecs, ActiveViewerForm.Viewer.Image)
         Catch ex As Exception
            Messager.ShowFileSaveError(Me, _saver.FileName, ex)
         End Try
      End Sub

      Private Sub _menuItemFileExit_Click(sender As Object, e As EventArgs) Handles _menuItemFileExit.Click
         Close()
      End Sub

      Private Sub MainForm_MdiChildActivate(sender As Object, e As EventArgs) Handles Me.MdiChildActivate
         Dim activeForm As ViewerForm = ActiveViewerForm

         UpdateControls()
      End Sub

      Private Sub _menuItemEdit_DropDownOpened(sender As Object, e As EventArgs) Handles _menuItemEdit.DropDownOpened
         _menuItemEditPaste.Enabled = RasterClipboard.IsReady
      End Sub

      Private Sub _menuItemEditCopy_Click(sender As Object, e As EventArgs) Handles _menuItemEditCopy.Click
         Try
            Using wait As New WaitCursor()
               RasterClipboard.Copy(Me.Handle, ImageToRun, RasterClipboardCopyFlags.Empty Or RasterClipboardCopyFlags.Dib Or RasterClipboardCopyFlags.Palette Or RasterClipboardCopyFlags.Region)
            End Using
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         Finally
            UpdateControls()
         End Try
      End Sub

      Private Sub _menuItemEditPaste_Click(sender As Object, e As EventArgs) Handles _menuItemEditPaste.Click
         Try
            Using wait As New WaitCursor()
               Dim image As RasterImage = RasterClipboard.Paste(Me.Handle)
               If image IsNot Nothing Then
                  Dim activeForm As ViewerForm = ActiveViewerForm
                  NewImage(New ImageInformation(image))
               End If
            End Using
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         Finally
            UpdateControls()
         End Try
      End Sub


      Private Sub _menuItemPage_Click(sender As Object, e As EventArgs) Handles _menuItemPageFirst.Click, _menuItemPagePrevious.Click, _menuItemPageNext.Click, _menuItemPageLast.Click
         Try
            Dim activeForm As ViewerForm = ActiveViewerForm
            Dim background As RasterColor = activeForm.Image.AnimationBackground

            If activeForm.Viewer.Image.HasRegion Then
               activeForm.Viewer.Image.MakeRegionEmpty()
            End If

            If sender Is _menuItemPageFirst Then
               activeForm.Image.Page = 1
            ElseIf sender Is _menuItemPagePrevious Then
               activeForm.Image.Page -= 1
            ElseIf sender Is _menuItemPageNext Then
               activeForm.Image.Page += 1
            ElseIf sender Is _menuItemPageLast Then
               activeForm.Image.Page = activeForm.Image.PageCount
            End If

            activeForm.Image.AnimationBackground = background
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         Finally
            UpdateControls()
         End Try
      End Sub

      Private Sub _menuItemPageAdd_Click(sender As Object, e As EventArgs) Handles _menuItemPageAdd.Click
         LoadImage(False, True)
         UpdateControls()
      End Sub

      Private Sub _menuItemPageDeleteCurrentPage_Click(sender As Object, e As EventArgs) Handles _menuItemPageDeleteCurrentPage.Click
         Try
            Dim activeForm As ViewerForm = ActiveViewerForm

            activeForm.Image.RemovePageAt(activeForm.Image.Page)
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         Finally
            UpdateControls()
         End Try
      End Sub


      Private Sub _menuItemViewSizeMode_Click(sender As Object, e As EventArgs) Handles _menuItemViewSizeModeNormal.Click, _menuItemViewSizeModeStretch.Click, _menuItemViewSizeModeCenter.Click, _menuItemViewSizeModeZoom.Click, _menuItemViewSizeModeAuto.Click
         Dim activeForm As ViewerForm = ActiveViewerForm

         If sender Is _menuItemViewSizeModeNormal Then
            activeForm.Viewer.SizeMode = RasterPictureBoxSizeMode.Normal
         Else
            activeForm.Viewer.BeginUpdate()
            If sender Is _menuItemViewSizeModeStretch Then
               activeForm.Viewer.SizeMode = RasterPictureBoxSizeMode.StretchImage
            ElseIf sender Is _menuItemViewSizeModeCenter Then
               activeForm.Viewer.SizeMode = RasterPictureBoxSizeMode.CenterImage
            ElseIf sender Is _menuItemViewSizeModeZoom Then
               activeForm.Viewer.SizeMode = RasterPictureBoxSizeMode.Fit
            ElseIf sender Is _menuItemViewSizeModeAuto Then
               activeForm.Viewer.SizeMode = RasterPictureBoxSizeMode.AutoSize
            End If

            activeForm.Viewer.EndUpdate()
         End If

         UpdateControls()
      End Sub

      Private Sub _menuItemPreferencesPaintProperties_Click(sender As Object, e As EventArgs) Handles _menuItemPreferencesPaintProperties.Click
         Dim dlg As New PaintPropertiesDialog()
         dlg.PaintProperties = _paintProperties
         AddHandler dlg.Apply, AddressOf PaintPropertiesDialog_Apply
         dlg.ShowDialog(Me)
      End Sub

      Private Sub PaintPropertiesDialog_Apply(sender As Object, e As EventArgs)
         Dim dlg As PaintPropertiesDialog = TryCast(sender, PaintPropertiesDialog)
         _paintProperties = dlg.PaintProperties
         For Each i As ViewerForm In MdiChildren
            i.UpdatePaintProperties(_paintProperties)
         Next
      End Sub

      Private Sub _menuItemHelpAbout_Click(sender As Object, e As EventArgs) Handles _menuItemHelpAbout.Click
         Using aboutDialog As New AboutDialog("Animation", ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using
      End Sub

      Private Sub _menuItemWindow_Click(sender As Object, e As EventArgs) Handles _menuItemWindowCascade.Click, _menuItemWindowTileHorizontally.Click, _menuItemWindowTileVertically.Click, _menuItemWindowArrangeIcons.Click, _menuItemWindowCloseAll.Click
         If sender Is _menuItemWindowCascade Then
            LayoutMdi(MdiLayout.Cascade)
         ElseIf sender Is _menuItemWindowTileHorizontally Then
            LayoutMdi(MdiLayout.TileHorizontal)
         ElseIf sender Is _menuItemWindowTileVertically Then
            LayoutMdi(MdiLayout.TileVertical)
         ElseIf sender Is _menuItemWindowArrangeIcons Then
            LayoutMdi(MdiLayout.ArrangeIcons)
         ElseIf sender Is _menuItemWindowCloseAll Then
            While MdiChildren.Length > 0
               MdiChildren(0).Close()
            End While
            UpdateControls()
         End If
      End Sub

      Private Sub LoadImage(loadDefaultImage As Boolean, addingPage As Boolean)
         Dim loader As New ImageFileLoader()
         loader.OpenDialogInitialPath = _openInitialPath


         Try
            loader.ShowLoadPagesDialog = True

            If loadDefaultImage Then
               Dim imagePath As String = System.IO.Path.Combine(DemosGlobal.ImagesFolder, "image1.gif")
               If Not System.IO.File.Exists(imagePath) Then
                  imagePath = System.IO.Path.Combine(Application.StartupPath, "image1.gif")
               End If
               If loader.Load(Me, imagePath, _codecs, 1, -1) Then
                  NewImage(New ImageInformation(loader.Image, loader.FileName))
               End If
            Else
               If loader.Load(Me, _codecs, True) > 0 Then
                  _openInitialPath = Path.GetDirectoryName(loader.FileName)
                  If addingPage Then
                     ActiveViewerForm.Image.AddPages(loader.Image, 1, loader.Image.PageCount)
                  Else
                     NewImage(New ImageInformation(loader.Image, loader.FileName))
                  End If
               End If
            End If
         Catch ex As Exception
            Messager.ShowFileOpenError(Me, loader.FileName, ex)
         End Try
      End Sub

      Private Sub NewImage(info As ImageInformation)
         Dim child As New ViewerForm()
         child.MdiParent = Me
         child.Initialize(info, _paintProperties, _animateRegions, True, _useDpi, _animationMode)
         child.Show()
      End Sub

      Private Property ImageToRun() As RasterImage
         Get
            Dim activeForm As ViewerForm = ActiveViewerForm
            Return activeForm.Viewer.Image
         End Get
         Set(value As RasterImage)
            If value IsNot Nothing Then
               Dim activeForm As ViewerForm = ActiveViewerForm
               activeForm.Viewer.Image = value
            End If
         End Set
      End Property

      Public Sub LoadDropFiles(viewer As ViewerForm, files As String())
         Try
            If files IsNot Nothing Then
               For i As Integer = 0 To files.Length - 1
                  Try
                     Dim image As RasterImage = _codecs.Load(files(i))
                     Dim info As New ImageInformation(image, files(i))
                     If i = 0 AndAlso viewer IsNot Nothing Then
                        viewer.Initialize(info, _paintProperties, _animateRegions, False, _useDpi, _animationMode)
                     Else
                        NewImage(info)
                     End If
                  Catch ex As Exception
                     Messager.ShowFileOpenError(Me, files(i), ex)
                  End Try
               Next
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         Finally
            UpdateControls()
         End Try
      End Sub

      Private Sub MainForm_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
         CleanUp()
      End Sub

      Private Sub _menuItemPreferencesUseDpi_Click(sender As Object, e As EventArgs) Handles _menuItemPreferencesUseDpi.Click
         _menuItemPreferencesUseDpi.Checked = Not _menuItemPreferencesUseDpi.Checked
         For Each i As ViewerForm In MdiChildren
            i.Viewer.UseDpi = _menuItemPreferencesUseDpi.Checked
            i.Viewer.Invalidate(True)
         Next
         _useDpi = _menuItemPreferencesUseDpi.Checked
      End Sub

      Private Sub _menuItemAnimationPlay_Click(sender As Object, e As EventArgs) Handles _menuItemAnimationPlay.Click
         ActiveViewerForm.Viewer.PlayAnimation()
      End Sub

      Private Sub _menuItemAnimationPause_Click(sender As Object, e As EventArgs) Handles _menuItemAnimationPause.Click
         ActiveViewerForm.Viewer.PauseAnimation()
      End Sub

      Private Sub _menuItemAnimationLoop_Click(sender As Object, e As EventArgs) Handles _menuItemAnimationLoop.Click
         Dim mode As RasterPictureBoxAnimationMode = RasterPictureBoxAnimationMode.Infinite
         _menuItemAnimationLoop.Checked = Not _menuItemAnimationLoop.Checked
         If Not _menuItemAnimationLoop.Checked Then
            mode = RasterPictureBoxAnimationMode.UseImageGlobalLoop
         End If

         For Each i As ViewerForm In MdiChildren
            i.Viewer.AnimationMode = mode
         Next

         _animationMode = mode
      End Sub

      Private Sub _menuItemAnimationCreate_Click(sender As Object, e As EventArgs) Handles _menuItemAnimationCreate.Click
         Dim createAnimationDialog As New CreateAnimationDialog()
         createAnimationDialog.Owner = Me
         If createAnimationDialog.ShowDialog() = DialogResult.OK Then
            createAnimationDialog.Image.AnimationGlobalLoop = 1000
            createAnimationDialog.Image.AnimationDelay = 500
            Dim info As New ImageInformation(createAnimationDialog.Image)
            Dim child As New ViewerForm()
            child.MdiParent = Me
            child.Initialize(info, _paintProperties, _animateRegions, True, _useDpi, _animationMode)
            child.Show()
         End If
      End Sub

      Private Sub _menuItemAnimationFrameSettings_Click(sender As Object, e As EventArgs) Handles _menuItemAnimationFrameSettings.Click
         If _frameSettings Is Nothing Then
            _frameSettings = New FrameSettings(ActiveViewerForm.Viewer.Image)
         Else
            _frameSettings.Image = ActiveViewerForm.Viewer.Image
         End If

         _frameSettings.ShowDialog()
      End Sub

      Private Sub _menuItemBackground_Click(sender As Object, e As EventArgs) Handles _menuItemBackground.Click
         If ActiveViewerForm.Viewer.Image.BitsPerPixel <= 8 Then
            Dim colorDialog As New ChooseColorDialog(ActiveViewerForm.Viewer.Image, True)

            If colorDialog.ShowDialog() = DialogResult.OK Then
               ActiveViewerForm.Viewer.Image.AnimationBackground = Leadtools.Demos.Converters.FromGdiPlusColor(colorDialog.SelectedColor)
            End If
         Else
            Dim colorDialog As New System.Windows.Forms.ColorDialog()

            If colorDialog.ShowDialog() = DialogResult.OK Then
               ActiveViewerForm.Viewer.Image.AnimationBackground = Leadtools.Demos.Converters.FromGdiPlusColor(colorDialog.Color)
            End If
         End If
      End Sub

      Private Sub _menuItemAnimationOptimizeColors_Click(sender As Object, e As EventArgs) Handles _menuItemAnimationOptimizeColors.Click
         Try
            Dim command As RasterCommand = Nothing
            Dim activeForm As ViewerForm = ActiveViewerForm
            Dim dlg As New ColorResolutionDialog(activeForm.Viewer.Image)
            dlg.BitsPerPixel = activeForm.Viewer.Image.BitsPerPixel
            If dlg.ShowDialog(Me) = DialogResult.OK Then
               Dim page As Integer = activeForm.Viewer.Image.Page
               command = New ColorResolutionCommand(ColorResolutionCommandMode.InPlace, dlg.BitsPerPixel, dlg.Order, dlg.DitheringMethod, dlg.PaletteFlags, Nothing)

               For i As Integer = 0 To activeForm.Viewer.Image.PageCount - 1
                  activeForm.Viewer.Image.Page = i + 1
                  command.Run(activeForm.Viewer.Image)
               Next

               activeForm.Viewer.Image.Page = page
            End If
         Catch ex As System.Exception
            Messager.Show(Me, ex, MessageBoxIcon.Warning)
         End Try
      End Sub
   End Class
End Namespace
