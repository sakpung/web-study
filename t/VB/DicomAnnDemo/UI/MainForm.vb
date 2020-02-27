' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Drawing
Imports System.Collections.Generic
Imports System.IO
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.Dicom
Imports Leadtools.Dicom.Annotations
Imports System.Text
Imports Leadtools.Annotations.Automation
Imports Leadtools.Annotations.WinForms
Imports Leadtools.Annotations.Engine
Imports Leadtools.Controls
Imports Leadtools.Demos.Dialogs

Namespace DicomAnnDemo
    Public Class MainForm : Inherits System.Windows.Forms.Form
        Private components As System.ComponentModel.IContainer
        Private _mainMenu As System.Windows.Forms.MainMenu
        Private _menuItemHelp As System.Windows.Forms.MenuItem
        Private WithEvents _menuItemHelpAbout As System.Windows.Forms.MenuItem
        Private WithEvents _menuItemFile As System.Windows.Forms.MenuItem
        Private WithEvents _menuItemFileOpen As System.Windows.Forms.MenuItem
        Private WithEvents _menuItemFileSave As System.Windows.Forms.MenuItem
        Private WithEvents _menuItemFileExit As System.Windows.Forms.MenuItem
        Private WithEvents _menuItemView As System.Windows.Forms.MenuItem
        Private WithEvents _menuItemViewNormal As System.Windows.Forms.MenuItem
        Private WithEvents _menuItemViewFitToWindow As System.Windows.Forms.MenuItem
        Private _menuItemViewSpiltter1 As System.Windows.Forms.MenuItem
        Private WithEvents _menuItemViewAnnotationToolbar As System.Windows.Forms.MenuItem
        Private _menuItem_Annotations As System.Windows.Forms.MenuItem
        Private WithEvents _menuItemAnnotationsPresentationStateInfo As System.Windows.Forms.MenuItem
        Private _openFileDialog As System.Windows.Forms.OpenFileDialog
        Private _saveFileDialog As System.Windows.Forms.SaveFileDialog
        Private _treeView_Elements As System.Windows.Forms.TreeView
        Private _splitContainer As System.Windows.Forms.SplitContainer

        Private _presentationStateDialog As PresentationStateAttributesDialog
        Private _dsImage As DicomDataSet
        Private _imageInfo As DicomImageInformation = Nothing
        Private _automation As AnnAutomation = Nothing
        Private _annManager As AnnAutomationManager
        Private _automationHelper As AutomationManagerHelper
        Private _dicomAnnotationsUtilities As DicomAnnotationsUtilities
        Private WithEvents _imageList As System.Windows.Forms.ImageList
        Private _presentation As DicomPresentationStateInformation
        Private _openInitialPath As String = ""
        Private _automationInteractiveMode As AutomationInteractiveMode
        Private _automationTextBox As AutomationTextBox

        Public Sub New()
            Dim startupMsgBox As StartupMessageBox = New StartupMessageBox("VBDicomAnnDemo")
            If (startupMsgBox.ShowStartUpDialog) Then
                startupMsgBox.ShowDialog()
            End If
            '
            ' Required for Windows Form Designer support
            '
            InitializeComponent()
            InitClass()
        End Sub

        Private Sub InitClass()
            Messager.Caption = "LEADTOOLS for .NET VB Dicom Annotation Demo"
            Text = Messager.Caption
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
            Me.components = New System.ComponentModel.Container
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainForm))
            Me._mainMenu = New System.Windows.Forms.MainMenu(Me.components)
            Me._menuItemFile = New System.Windows.Forms.MenuItem
            Me._menuItemFileOpen = New System.Windows.Forms.MenuItem
            Me._menuItemFileSave = New System.Windows.Forms.MenuItem
            Me._menuItemFileExit = New System.Windows.Forms.MenuItem
            Me._menuItemView = New System.Windows.Forms.MenuItem
            Me._menuItemViewNormal = New System.Windows.Forms.MenuItem
            Me._menuItemViewFitToWindow = New System.Windows.Forms.MenuItem
            Me._menuItemViewSpiltter1 = New System.Windows.Forms.MenuItem
            Me._menuItemViewAnnotationToolbar = New System.Windows.Forms.MenuItem
            Me._menuItem_Annotations = New System.Windows.Forms.MenuItem
            Me._menuItemAnnotationsPresentationStateInfo = New System.Windows.Forms.MenuItem
            Me._menuItemHelp = New System.Windows.Forms.MenuItem
            Me._menuItemHelpAbout = New System.Windows.Forms.MenuItem
            Me._openFileDialog = New System.Windows.Forms.OpenFileDialog
            Me._saveFileDialog = New System.Windows.Forms.SaveFileDialog
            Me._treeView_Elements = New System.Windows.Forms.TreeView
            Me._splitContainer = New System.Windows.Forms.SplitContainer
            Me._imageList = New System.Windows.Forms.ImageList(Me.components)
            Me._splitContainer.Panel1.SuspendLayout()
            Me._splitContainer.SuspendLayout()
            Me.SuspendLayout()
            '
            '_mainMenu
            '
            Me._mainMenu.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemFile, Me._menuItemView, Me._menuItem_Annotations, Me._menuItemHelp})
            '
            '_menuItemFile
            '
            Me._menuItemFile.Index = 0
            Me._menuItemFile.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemFileOpen, Me._menuItemFileSave, Me._menuItemFileExit})
            Me._menuItemFile.Text = "&File"
            '
            '_menuItemFileOpen
            '
            Me._menuItemFileOpen.Index = 0
            Me._menuItemFileOpen.Text = "&Open..."
            '
            '_menuItemFileSave
            '
            Me._menuItemFileSave.Enabled = False
            Me._menuItemFileSave.Index = 1
            Me._menuItemFileSave.Text = "&Save..."
            '
            '_menuItemFileExit
            '
            Me._menuItemFileExit.Index = 2
            Me._menuItemFileExit.Text = "&Exit"
            '
            '_menuItemView
            '
            Me._menuItemView.Index = 1
            Me._menuItemView.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemViewNormal, Me._menuItemViewFitToWindow, Me._menuItemViewSpiltter1, Me._menuItemViewAnnotationToolbar})
            Me._menuItemView.Text = "&View"
            '
            '_menuItemViewNormal
            '
            Me._menuItemViewNormal.Index = 0
            Me._menuItemViewNormal.Text = "&Normal"
            '
            '_menuItemViewFitToWindow
            '
            Me._menuItemViewFitToWindow.Index = 1
            Me._menuItemViewFitToWindow.Text = "&Fit to Window"
            '
            '_menuItemViewSpiltter1
            '
            Me._menuItemViewSpiltter1.Index = 2
            Me._menuItemViewSpiltter1.Text = "-"
            '
            '_menuItemViewAnnotationToolbar
            '
            Me._menuItemViewAnnotationToolbar.Checked = True
            Me._menuItemViewAnnotationToolbar.Index = 3
            Me._menuItemViewAnnotationToolbar.Text = "Annotation Toolbar"
            '
            '_menuItem_Annotations
            '
            Me._menuItem_Annotations.Index = 2
            Me._menuItem_Annotations.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemAnnotationsPresentationStateInfo})
            Me._menuItem_Annotations.Text = "&Annotations"
            '
            '_menuItemAnnotationsPresentationStateInfo
            '
            Me._menuItemAnnotationsPresentationStateInfo.Index = 0
            Me._menuItemAnnotationsPresentationStateInfo.Text = "Presentation State Info"
            '
            '_menuItemHelp
            '
            Me._menuItemHelp.Index = 3
            Me._menuItemHelp.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me._menuItemHelpAbout})
            Me._menuItemHelp.Text = "&Help"
            '
            '_menuItemHelpAbout
            '
            Me._menuItemHelpAbout.Index = 0
            Me._menuItemHelpAbout.Text = "&About"
            '
            '_openFileDialog
            '
            Me._openFileDialog.Filter = "DICOM Files (*.dcm;*.dic)|*.dcm;*.dic|All files (*.*)|*.*"
            Me._openFileDialog.Multiselect = True
            Me._openFileDialog.Title = "Open Dicom File"
            '
            '_imageList
            '
            Me._imageList.ImageStream = CType(resources.GetObject("_imageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
            Me._imageList.TransparentColor = System.Drawing.Color.Transparent
            Me._imageList.Images.SetKeyName(0, "")
            Me._imageList.Images.SetKeyName(1, "")
            Me._imageList.Images.SetKeyName(2, "")
            Me._imageList.Images.SetKeyName(3, "")
            '
            '_treeView_Elements
            '
            Me._treeView_Elements.Dock = System.Windows.Forms.DockStyle.Fill
            Me._treeView_Elements.FullRowSelect = True
            Me._treeView_Elements.HideSelection = False
            Me._treeView_Elements.ImageIndex = 0
            Me._treeView_Elements.ImageList = Me._imageList
            Me._treeView_Elements.Location = New System.Drawing.Point(0, 0)
            Me._treeView_Elements.Name = "_treeView_Elements"
            Me._treeView_Elements.SelectedImageIndex = 0
            Me._treeView_Elements.Size = New System.Drawing.Size(80, 518)
            Me._treeView_Elements.TabIndex = 3
            '
            '_splitContainer
            '
            Me._splitContainer.Dock = System.Windows.Forms.DockStyle.Fill
            Me._splitContainer.Location = New System.Drawing.Point(0, 0)
            Me._splitContainer.Name = "_splitContainer"
            '
            '_splitContainer.Panel1
            '
            Me._splitContainer.Panel1.Controls.Add(Me._treeView_Elements)
            Me._splitContainer.Size = New System.Drawing.Size(673, 518)
            Me._splitContainer.SplitterDistance = 80
            Me._splitContainer.TabIndex = 4
            '
            'MainForm
            '
            Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
            Me.ClientSize = New System.Drawing.Size(673, 518)
            Me.Controls.Add(Me._splitContainer)
            Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
            Me.Menu = Me._mainMenu
            Me.Name = "MainForm"
            Me.Text = "DicomAnnDemo"
            Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
            Me._splitContainer.Panel1.ResumeLayout(False)
            Me._splitContainer.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub
#End Region

        ''' <summary>
        ''' The main entry point for the application.
        ''' </summary>
        <STAThread()>
        Shared Sub Main()

            If Not Support.SetLicense() Then
                Return
            End If

            Dim bMedicalLocked As Boolean = RasterSupport.IsLocked(RasterSupportType.Medical)
            If bMedicalLocked Then
                MessageBox.Show("Medical support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            Dim bDocLocked As Boolean = RasterSupport.IsLocked(RasterSupportType.Document)
            If bDocLocked Then
                MessageBox.Show("Document support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If

            If bMedicalLocked Or bDocLocked Then
                Return
            End If

            Application.Run(New MainForm())
        End Sub

        ' Automation viewer object.
        Private _viewer As MyAutomationImageViewer
        Private Sub menuItemAbout_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemHelpAbout.Click
            Using aboutDialog As New AboutDialog("DICOM Annotation", ProgrammingInterface.VB)
                aboutDialog.ShowDialog(Me)
            End Using
        End Sub

        Private Sub menuItemFileExit_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemFileExit.Click
            Application.Exit()
        End Sub

        Private Sub MainForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
            ' Initialize the viewer object.
            DicomEngine.Startup()

            _viewer = New MyAutomationImageViewer()
            _viewer.BackColor = SystemColors.Control
            AddHandler _viewer.KeyDown, AddressOf _viewer_KeyDown
            _viewer.Dock = DockStyle.Fill
            Me._splitContainer.Panel2.Controls.Add(_viewer)

            _automationInteractiveMode = New AutomationInteractiveMode()

            _automationInteractiveMode.IdleCursor = Cursors.Arrow
            _automationInteractiveMode.WorkingCursor = Cursors.Cross

            _viewer.InteractiveModes.BeginUpdate()
            _viewer.InteractiveModes.Add(_automationInteractiveMode)
            _viewer.InteractiveModes.EndUpdate()

            _dsImage = New DicomDataSet()

            If _dsImage Is Nothing Then
                Messager.ShowError(Me, "Can't create dicom object. Quitting app.")
                Application.Exit()
                Return
            End If

            BringToFront()

            InitAutomationManager()

            _presentation = New DicomPresentationStateInformation()
            _presentation.InstanceNumber = 1
            _presentation.PresentationLabel = "LABEL"

            _presentationStateDialog = New PresentationStateAttributesDialog()
            _dicomAnnotationsUtilities = New DicomAnnotationsUtilities()

            AddHandler Application.ApplicationExit, AddressOf Application_ApplicationExit

            LoadImage(True)
        End Sub

        Private Sub Application_ApplicationExit(ByVal sender As Object, ByVal e As EventArgs)
            DicomEngine.Shutdown()
        End Sub

        Private Sub FreeImage()
            If Not _viewer.Image Is Nothing Then
                If _viewer.Image.PageCount > 1 Then
                    _viewer.Image.RemoveAllPages()
                End If

                _viewer.Image.Dispose()
                _viewer.Image = Nothing
            End If
        End Sub

        Private Sub menuItemFileOpen_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemFileOpen.Click
            LoadImage(False)
        End Sub

        Private Sub menuItemView_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemView.Popup
            Dim enable As Boolean = False
            If _viewer.Image Is Nothing OrElse (_viewer.Image.PageCount < 1) Then
                enable = False
            Else
                enable = True
            End If

            _menuItemViewNormal.Enabled = enable
            _menuItemViewNormal.Checked = ((_viewer.SizeMode = RasterPaintSizeMode.Normal) AndAlso (_viewer.ScaleFactor = 1))

            _menuItemViewFitToWindow.Enabled = enable
            _menuItemViewFitToWindow.Checked = _viewer.SizeMode = RasterPaintSizeMode.FitAlways
        End Sub

        Private Sub ChangeView(ByVal rasterPaintSizeMode As ControlSizeMode)
            _viewer.Zoom(rasterPaintSizeMode, 1, _viewer.DefaultZoomOrigin)
        End Sub

        Private Sub menuItemViewNormal_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemViewNormal.Click
            ChangeView(ControlSizeMode.ActualSize)
        End Sub

        Private Sub menuItemViewFitToWindow_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemViewFitToWindow.Click
            ChangeView(ControlSizeMode.FitAlways)
        End Sub

        Private Sub _menuItemViewAnnotationToolbar_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemViewAnnotationToolbar.Click
            _automationHelper.ToolBar.Visible = Not _automationHelper.ToolBar.Visible
            TryCast(sender, MenuItem).Checked = _automationHelper.ToolBar.Visible
        End Sub

        Private Sub _menuItemAnnotationsPresentationStateInfo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _menuItemAnnotationsPresentationStateInfo.Click
            PresentationStateDialog(False)
        End Sub

        Private Sub CloseCurrentFile()
            _treeView_Elements.BeginUpdate()
            _treeView_Elements.Nodes.Clear()
            _treeView_Elements.EndUpdate()

            _dsImage.Reset()

            FreeImage()
        End Sub

        Private Sub menuItemFile_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemFile.Popup
            Dim valid As Boolean = IsDatasetValid()

            _menuItemFileSave.Enabled = valid
        End Sub

        Private Sub _viewer_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
            If e.KeyCode = Keys.Delete AndAlso _automation.CanDeleteObjects Then
                _automation.DeleteSelectedObjects()
            End If
        End Sub

        Private Sub LoadImage(ByVal loadDefaultImage As Boolean)
            Try
                If loadDefaultImage Then
#If LT_CLICKONCE Then
			   OpenDataset("image2.dcm", loadDefaultImage)
#Else
                    OpenDataset(DemosGlobal.ImagesFolder & "\image2.dcm", loadDefaultImage)
#End If ' LT_CLICKONCE
                Else
                    Me._openFileDialog.Filter = "DICOM Files (*.dcm;*.dic)|*.dcm;*.dic|All files (*.*)|*.*"
                    Me._openFileDialog.Multiselect = False
                    Me._openFileDialog.Title = "Open Dicom File"
                    Me._openFileDialog.InitialDirectory = _openInitialPath
                    If _openFileDialog.ShowDialog() = DialogResult.OK Then
                        OpenDataset(_openFileDialog.FileName, loadDefaultImage)
                        _openInitialPath = Path.GetDirectoryName(_openFileDialog.FileName)
                    End If
                End If

                EnableMenuItems(True)
            Catch
                EnableMenuItems(False)
                Messager.ShowError(Me, "Error loading image")
            End Try
        End Sub

        Private Sub InitAutomationManager()
            _annManager = New AnnAutomationManager()

            _annManager.CreateDefaultObjects()
            Dim objectsToRemove As List(Of AnnAutomationObject) = New List(Of AnnAutomationObject)()
            For Each obj As AnnAutomationObject In _annManager.Objects
                If System.Enum.GetName(GetType(AnnObjects), obj.Id) Is Nothing Then
                    objectsToRemove.Add(obj)
                End If
            Next obj

            For Each obj As AnnAutomationObject In objectsToRemove
                _annManager.Objects.Remove(obj)
            Next obj

            _automationHelper = New AutomationManagerHelper(_annManager)
            If _annManager.RenderingEngine IsNot Nothing Then
                AddHandler _annManager.RenderingEngine.LoadPicture, AddressOf renderingEngine_LoadPicture
            End If

            _automationHelper.CreateToolBar()
            _automationHelper.ToolBar.Visible = True
            _automationHelper.ToolBar.BringToFront()
            _automationHelper.ToolBar.AutoSize = False
            _automationHelper.ToolBar.Appearance = ToolBarAppearance.Flat
            _automationHelper.ToolBar.Dock = DockStyle.Right
            Me.Controls.Add(_automationHelper.ToolBar)

            For Each obj As AnnAutomationObject In _annManager.Objects
                obj.UseRotateThumbs = True
                obj.ContextMenu = Nothing
                If obj.ObjectTemplate IsNot Nothing AndAlso obj.ObjectTemplate.SupportsStroke Then
                    'obj.Object.Pen = new AnnPen(Color.White, new AnnLength(1));
                End If
            Next obj

            _automation = New AnnAutomation(_annManager, _viewer)

            AddHandler _automation.EditText, AddressOf automation_EditText
            'Change AnnText to use Pen
            Dim annLength As LeadLengthD = New LeadLengthD(1)
            Dim annAutText As AnnAutomationObject = _automation.Manager.FindObjectById(CInt(AnnObjects.TextObjectId))
            annAutText.ObjectTemplate.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Red"), annLength)

            _automation.Active = True

        End Sub

        Private Sub renderingEngine_LoadPicture(sender As Object, e As AnnLoadPictureEventArgs)
            _automation.Invalidate(LeadRectD.Empty)
        End Sub
        Private Sub automation_EditText(sender As Object, e As AnnEditTextEventArgs)
            RemoveAutomationTextBox(True)

            If e.TextObject Is Nothing Then
                Return
            End If

            _automationTextBox = New AutomationTextBox(_viewer, Me._automation, e, AddressOf RemoveAutomationTextBox)
        End Sub

        Private Sub RemoveAutomationTextBox(update As Boolean)
            If _automationTextBox Is Nothing Then
                Return
            End If

            _automationTextBox.Remove(update)
            _automationTextBox.Dispose()
            _automationTextBox = Nothing
        End Sub

        Private Sub ClearAnnotations()
            If Not _automation Is Nothing AndAlso Not _automation.Container Is Nothing AndAlso _automation.Container.Children.Count > 0 Then
                _automation.Container.Children.Clear()
            End If
        End Sub

#If Not LEADTOOLS_V20_OR_LATER Then
      Private Const _getImageFlags As DicomGetImageFlags = DicomGetImageFlags.AutoApplyModalityLut Or DicomGetImageFlags.AutoApplyVoiLut Or DicomGetImageFlags.AutoScaleModalityLut Or DicomGetImageFlags.AutoScaleVoiLut Or DicomGetImageFlags.AutoDectectInvalidRleCompression
#Else
        Private Const _getImageFlags As DicomGetImageFlags = DicomGetImageFlags.AutoApplyModalityLut Or DicomGetImageFlags.AutoApplyVoiLut Or DicomGetImageFlags.AutoScaleModalityLut Or DicomGetImageFlags.AutoScaleVoiLut Or DicomGetImageFlags.AutoDetectInvalidRleCompression
#End If ' #If Not LEADTOOLS_V20_OR_LATER Then

        Private Function ShowImage() As Boolean
            Try
                Dim element As DicomElement = Nothing
                element = _dsImage.FindFirstElement(Nothing, Leadtools.DicomDemos.DemoDicomTags.PixelData, True)
                Dim bitmapCount As Integer = _dsImage.GetImageCount(element)
                If bitmapCount > 0 Then
                    FreeImage()
                    If bitmapCount = 1 Then
                        If Not element Is Nothing Then
                            Dim image As RasterImage

                            image = _dsImage.GetImage(element, 0, 0, RasterByteOrder.Gray, _getImageFlags)

                            _viewer.Image = image
                        End If
                    Else
                        If Not element Is Nothing Then
                            LoadBitmapList(element)
                        End If
                    End If

                    If Not element Is Nothing Then
                        _imageInfo = _dsImage.GetImageInformation(element, 0)
                    End If

                    If (_dicomAnnotationsUtilities IsNot Nothing) AndAlso (_viewer.Image IsNot Nothing) Then
                        _dicomAnnotationsUtilities.DisplayWidth = _viewer.Image.Width
                        _dicomAnnotationsUtilities.DisplayHeight = _viewer.Image.Height
                    End If

                    Return True
                Else
                    Messager.ShowInformation(Me, "Please note that this dataset doesn't include any images.")
                End If
            Catch exception As Exception
                System.Diagnostics.Debug.Assert(False)
                Throw exception
            End Try
            Return False
        End Function


        Private Sub OpenDataset(ByVal dicomfileName As String, ByVal loadDefaultImage As Boolean)
            If File.Exists(dicomfileName) Then
                Cursor = Cursors.WaitCursor
                Dim bImageLoaded As Boolean = False
                Try
                    Try
                        _dsImage.Load(dicomfileName, DicomDataSetLoadFlags.LoadAndClose)
                        bImageLoaded = ShowImage()
                        _automation.Container.Size = _automation.Container.Mapper.SizeToContainerCoordinates(LeadSizeD.Create(_viewer.Image.ImageWidth, _viewer.Image.ImageHeight))
                    Catch e1 As Exception
                        Dim msg As String = String.Format("Failed to load '{0}'.  Make sure that this is a valid DICOM file.", dicomfileName)
                        Messager.ShowError(Me, msg)
                        Return
                    End Try

                    If _dsImage.InformationClass = DicomClassType.BasicDirectory Then
                        Messager.ShowError(Me, "This demo does not support opening Dicom Directory datasets.  " & "Please see the Dicom Directory demo.")
                        Return
                    End If

                    'if dicom file loaded successfully
                    If bImageLoaded Then
                        UpdateTree()
                        'Load ".pre" File
                        Dim fileName As String = Path.GetFileNameWithoutExtension(dicomfileName) & ".pre"
                        Dim DirectoryName As String = Path.GetDirectoryName(dicomfileName)
                        CloseAnnotations()
                        LoadAnnotationFile(Path.Combine(DirectoryName, fileName), loadDefaultImage)
                    End If
                Catch exception As Exception
                    System.Diagnostics.Debug.Assert(False)

                    Throw exception
                Finally
                    Cursor = Cursors.Arrow
                End Try

                If _treeView_Elements.Nodes.Count > 0 Then
                    _treeView_Elements.SelectedNode = _treeView_Elements.Nodes(0)
                End If
            Else
                Messager.ShowError(Me, String.Format("""{0}"" Not Found", Path.GetFileName(dicomfileName)))
            End If
        End Sub

        Private Function LoadAnnotationFile(ByVal fileName As String, ByVal loadDefaultImage As Boolean) As Boolean
            If File.Exists(fileName) Then
                Try
                    Dim dsPresentationState As New DicomDataSet()
                    dsPresentationState.Load(fileName, DicomDataSetLoadFlags.LoadAndClose)

                    Dim annContainer As AnnContainer = _dicomAnnotationsUtilities.FromDataSetToAnnContainer(dsPresentationState, Nothing, _dsImage)
                    If annContainer IsNot Nothing Then
                        For Each annObject As AnnObject In annContainer.Children
                            DrawLeadAnnotationObject(annObject)
                        Next annObject
                    End If


                    _presentation = dsPresentationState.GetPresentationStateInformation()

                    Dim PresState As DicomPresentationStateInformation = dsPresentationState.GetPresentationStateInformation()
                    If PresState IsNot Nothing Then
                        _presentationStateDialog.Presentation.InstanceNumber = PresState.InstanceNumber
                        _presentationStateDialog.Presentation.PresentationCreator = PresState.PresentationCreator
                        _presentationStateDialog.Presentation.PresentationLabel = PresState.PresentationLabel
                        _presentationStateDialog.Presentation.PresentationDescription = PresState.PresentationDescription
                        If PresState.PresentationCreationDate.Year <> 0 Then
                            _presentationStateDialog.Presentation.CreationDate = PresState.PresentationCreationDate.ToDateTime()
                        End If
                        If PresState.PresentationCreationTime.Hours <> 0 Then
                            _presentationStateDialog.Presentation.CreationTime = PresState.PresentationCreationTime.ToDateTime()
                        End If

                        _automation.SelectObjects(Nothing)
                        Return True
                    End If
                Catch ex As Exception
                    Messager.ShowError(Me, ex.Message)
                End Try
            Else
                ClearAnnotations()

                'if not the default file, show a message
                If (Not loadDefaultImage) Then
                    Messager.ShowInformation(Me, "No related Presentation State file (.pre) was found. A Grayscale Softcopy Presentation State object will be created for the loaded image.")
                End If
            End If
            Return False
        End Function

        Private Sub LoadBitmapList(ByVal element As DicomElement)
            Dim count As Integer

            count = _dsImage.GetImageCount(element)
            Dim x As Integer
            For x = 0 To count - 1
                Dim image As RasterImage

                image = _dsImage.GetImage(element, x, 0, RasterByteOrder.Rgb Or RasterByteOrder.Gray, _getImageFlags)

                If Not image Is Nothing Then
                    If x = 0 Then
                        _viewer.Image = image
                    Else
                        _viewer.Image.AddPage(image)
                    End If
                Else
                    Dim err As String = String.Format("Error reading dicom image ")

                    Messager.ShowError(Me, err)
                    Exit For
                End If
                x += 1
            Next x

            If _viewer.Image.PageCount > 0 Then
                _viewer.Image.Page = 1
            End If
        End Sub

        Private Sub FillTreeModules()
            Dim x As Integer
            For x = 0 To _dsImage.ModuleCount - 1
                Dim node As TreeNode
                Dim [module] As DicomModule
                Dim iod As DicomIod

                [module] = _dsImage.FindModuleByIndex(x)
                iod = DicomIodTable.Instance.FindModule(_dsImage.InformationClass, [module].Type)

                node = _treeView_Elements.Nodes.Add(iod.Name)
                node.Tag = [module]
                For Each element As DicomElement In [module].Elements
                    FillModuleSubTree(element, node, False)
                Next element
            Next x
        End Sub

        Private Sub FillModuleSubTree(ByVal element As DicomElement, ByVal ParentNode As TreeNode, ByVal recurse As Boolean)
            Dim node As TreeNode
            Dim name As String
            Dim temp As String = ""
            Dim tempElement As DicomElement

            Dim tag As DicomTag = DicomTagTable.Instance.Find(element.Tag)
            temp = String.Format("{0:x4}:{1:x4} - ", Leadtools.DicomDemos.Utils.GetGroup(CLng(element.Tag)), Leadtools.DicomDemos.Utils.GetElement(CLng(element.Tag)))

            If tag Is Nothing Then
                name = "Item"
            Else
                name = tag.Name
            End If

            temp = temp & name

            If Not ParentNode Is Nothing Then
                node = ParentNode.Nodes.Add(temp)
            Else
                node = _treeView_Elements.Nodes.Add(temp)
            End If

            node.Tag = element

            If _dsImage.IsVolatileElement(element) Then
                node.ForeColor = Color.Red
            End If

            node.ImageIndex = 1
            node.SelectedImageIndex = 1

            tempElement = _dsImage.GetChildElement(element, True)
            If Not tempElement Is Nothing Then
                node.ImageIndex = 0
                node.SelectedImageIndex = 0
                FillModuleSubTree(tempElement, node, True)
            End If

            If recurse Then
                tempElement = _dsImage.GetNextElement(element, True, True)
                If Not tempElement Is Nothing Then
                    FillModuleSubTree(tempElement, ParentNode, True)
                End If
            End If
        End Sub

        Private Function IsDatasetValid() As Boolean
            Dim element As DicomElement

            element = _dsImage.FindFirstElement(Nothing, Leadtools.DicomDemos.DemoDicomTags.SOPClassUID, True)
            If element Is Nothing Then
                Return False
            End If
            Return True
        End Function

        Private Sub UpdateTree()
            Try
                _treeView_Elements.BeginUpdate()
                _treeView_Elements.Nodes.Clear()
                FillTreeModules()
                _treeView_Elements.EndUpdate()
            Catch
            End Try
        End Sub

        Private Sub EnableMenuItems(ByVal bEnable As Boolean)
            _menuItemView.Enabled = bEnable
            _menuItem_Annotations.Enabled = bEnable
        End Sub

        Private Sub menuItemFileSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles _menuItemFileSave.Click
            PresentationStateDialog(True)

            _saveFileDialog.Filter = "DCM File(*.dcm)|*.dcm|All files (*.*)|*.*"
            _saveFileDialog.AddExtension = True
            _saveFileDialog.Title = "Save Dicom File"
            If _saveFileDialog.ShowDialog() = DialogResult.OK Then
                Try
                    _dsImage.Save(_saveFileDialog.FileName, DicomDataSetSaveFlags.None)
                    SaveDicomAnnotations(_saveFileDialog.FileName)
                Catch de As DicomException
                    Dim err As String = String.Format("Error saving dicom dataset!\n" & "{0}", de.Code.ToString())

                    Messager.ShowError(Me, err)
                    Return
                End Try
            End If
        End Sub

        Private Sub SaveDicomAnnotations(ByVal datasetFileName As String)
            If (_dsImage IsNot Nothing) Then
                _dicomAnnotationsUtilities.DisplayWidth = _viewer.Image.Width
                _dicomAnnotationsUtilities.DisplayHeight = _viewer.Image.Height
                SetPresentationStateInfo()

                Dim ds As New DicomDataSet()
                _dicomAnnotationsUtilities.FromAnnContainerToDataSet(ds, _automation.Container, _dsImage, String.Empty, String.Empty)

                Dim DirectoryName As String = Path.GetDirectoryName(datasetFileName)
                Dim fileName As String = Path.GetFileNameWithoutExtension(datasetFileName) & ".pre"
                Try
                    ds.Save(Path.Combine(DirectoryName, fileName), DicomDataSetSaveFlags.None)
                Catch ex As Exception
                    Messager.ShowError(Me, ex.Message)
                End Try
            End If
        End Sub

        Private Sub PresentationStateDialog(ByVal useCurrentDate As Boolean)
            If Nothing IsNot _presentation Then
                Dim now As DateTime = DateTime.Now

                _presentationStateDialog.Presentation.InstanceNumber = _presentation.InstanceNumber
                _presentationStateDialog.Presentation.PresentationLabel = _presentation.PresentationLabel
                _presentationStateDialog.Presentation.PresentationDescription = _presentation.PresentationDescription

                If (_presentation.PresentationCreationDate.Year = 0) OrElse useCurrentDate Then
                    _presentation.PresentationCreationDate = New DicomDateValue(now)
                End If

                If (_presentation.PresentationCreationTime.Hours = 0) OrElse useCurrentDate Then
                    _presentation.PresentationCreationTime = New DicomTimeValue(now)
                End If

                _presentationStateDialog.Presentation.CreationDate = _presentation.PresentationCreationDate.ToDateTime()
                _presentationStateDialog.Presentation.CreationTime = _presentation.PresentationCreationTime.ToDateTime()
            End If

            If _presentationStateDialog.ShowDialog() = DialogResult.OK Then
                _presentation.PresentationCreator = _presentationStateDialog.Presentation.PresentationCreator
                _presentation.InstanceNumber = _presentationStateDialog.Presentation.InstanceNumber
                _presentation.PresentationLabel = _presentationStateDialog.Presentation.PresentationLabel
                _presentation.PresentationDescription = _presentationStateDialog.Presentation.PresentationDescription
            End If
        End Sub



        Private Sub DrawLeadAnnotationObject(ByVal annObject As AnnObject)
            If _automation Is Nothing OrElse _automation.Container Is Nothing Then
                Return
            End If

            _automation.Container.Children.Add(annObject)
        End Sub

        Private Sub SetPresentationStateInfo()
            _dicomAnnotationsUtilities.PresentationStateIdentification = New PresentationStateIdentificationModule()
            _dicomAnnotationsUtilities.PresentationStateIdentification.ContentCreatorName = _presentationStateDialog.Presentation.PresentationCreator
            _dicomAnnotationsUtilities.PresentationStateIdentification.ContentDescription = _presentationStateDialog.Presentation.PresentationDescription
            _dicomAnnotationsUtilities.PresentationStateIdentification.ContentLabel = _presentationStateDialog.Presentation.PresentationLabel
            _dicomAnnotationsUtilities.PresentationStateIdentification.CreationDate = New DicomDateValue(_presentationStateDialog.Presentation.CreationDate)
            _dicomAnnotationsUtilities.PresentationStateIdentification.CreationTime = New DicomTimeValue(_presentationStateDialog.Presentation.CreationTime)
            _dicomAnnotationsUtilities.PresentationStateIdentification.InstanceNumber = _presentationStateDialog.Presentation.InstanceNumber
        End Sub

        Private Sub CloseAnnotations()
            If Not _automation.CurrentDesigner Is Nothing Then
                _automation.CurrentDesigner.Cancel()
            End If
            _automation.SelectObject(Nothing)
            _automation.Container.Children.Clear()

        End Sub
    End Class

    'We will create custom viewer to work on default image resolution 
    Public Class MyAutomationImageViewer
        Inherits AutomationImageViewer
        Public Overrides ReadOnly Property AutomationXResolution() As Double
            Get
                Return 96.0
            End Get
        End Property

        Public Overrides ReadOnly Property AutomationYResolution() As Double
            Get
                Return 96.0
            End Get
        End Property
    End Class

    Public Class DISPLAYEDAREA
        Public TLHCorner As Integer() ' Displayed Area Top Left Hand Corner. User should allocate two L_INT32 memory units for Column\Row
        Public BRHCorner As Integer() ' Displayed Area Top Left Hand Corner. User should allocate two L_INT32 memory units for Column\Row
        Public uSizeMode As DicomAnnotationSizeMode ' Presentation Size Mode
        Public PixelSpacing As Double() ' Presentation Pixel Spacing. User should allocate two L_DOUBLE memory units for Row spacing\Column spacing
        Public AspectRatio As Integer() ' Presentation Pixel Aspect Ratio. User should allocate two L_INT32 memory units for Row spacing\Column spacing
        Public fMagnifyRatio As Single ' Presentation Pixel Magnification Ratio

        Public Sub ZeroOut()
            TLHCorner = New Integer(1) {} ' Displayed Area Top Left Hand Corner. User should allocate two L_INT32 memory units for Column\Row
            BRHCorner = New Integer(1) {} ' Displayed Area Top Left Hand Corner. User should allocate two L_INT32 memory units for Column\Row
            uSizeMode = 0 ' Presentation Size Mode
            PixelSpacing = New Double(1) {} ' Presentation Pixel Spacing. User should allocate two L_DOUBLE memory units for Row spacing\Column spacing
            AspectRatio = New Integer(1) {} ' Presentation Pixel Aspect Ratio. User should allocate two L_INT32 memory units for Row spacing\Column spacing
            fMagnifyRatio = 0.0F
        End Sub

        Public Sub New()
            ZeroOut()
        End Sub
    End Class

    Public Enum DicomAnnotationSizeMode
        ScaleToFit = 0
        TrueSize = 1
        Magnify = 2
    End Enum

    Public Enum AnnObjects
        GroupObjectId = 0
        SelectObjectId = -1
        LineObjectId = -2
        RectangleObjectId = -3
        EllipseObjectId = -4
        PolylineObjectId = -5
        PolygonObjectId = -6
        CurveObjectId = -7
        ClosedCurveObjectId = -8
        PointerObjectId = -9
        TextObjectId = -12
        TextPointerObjectId = -14
        PointObjectId = -21
    End Enum

End Namespace
