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
Imports Leadtools.Twain
Imports Leadtools.Codecs
Imports Leadtools.Demos
Imports Leadtools
Imports Leadtools.Ocr
Imports Leadtools.Barcode
Imports Leadtools.Forms.Auto
Imports Leadtools.Forms.Common
Imports Leadtools.Forms.Recognition
Imports Leadtools.Forms.Recognition.Barcode
Imports Leadtools.Forms.Recognition.Ocr
Imports Leadtools.Forms.Processing
Imports System.IO
Imports System.Diagnostics

Imports Leadtools.Drawing
Imports Leadtools.Annotations.Automation
Imports Leadtools.Annotations.Engine
Imports Leadtools.Controls
Imports System.Drawing.Drawing2D
Imports Leadtools.Annotations.Designers
Imports Leadtools.Annotations.Rendering
Imports Leadtools.Annotations.WinForms
Imports System.Runtime.Serialization.Formatters.Binary
Imports VBMasterFormsEditor.FormsDemo

#If FOR_DOTNET4 Then
Imports Leadtools.Forms.Recognition.Search
#End If

#If LEADTOOLS_V19_OR_LATER Then
Imports Leadtools.Demos.Dialogs
#End If

Partial Public Class MainForm
   Inherits Form
   Public Sub New()
      InitializeComponent()
   End Sub

   Public Sub New(MasterFormsPath As String)
      InitializeComponent()

      _masterformspath = MasterFormsPath
   End Sub

   Public Sub New(MasterFormsImage As RasterImage, MasterFormsName As String, MasterFormsDirectory As String, pageType As FormsPageType)
      InitializeComponent()

      _masterformsimage = MasterFormsImage
      _masterformsname = MasterFormsName
      _masterformsdirectory = MasterFormsDirectory
      _createdFormPageType = pageType
   End Sub

   Private twainSession As TwainSession = Nothing
   Private rasterCodecs As RasterCodecs
   Private ocrEngine As IOcrEngine
   Private barcodeEngine As BarcodeEngine
   Private recognitionEngine As FormRecognitionEngine
   Private workingRepository As DiskMasterFormsRepository
   Private annAutomationManager As AnnAutomationManager = Nothing
   Private automation As AnnAutomation = Nothing
   Private _noneInteractiveMode As ImageViewerNoneInteractiveMode = Nothing
   Private _panInteractiveMode As ImageViewerPanZoomInteractiveMode = Nothing
   Private _zoomToInteractiveMode As ImageViewerZoomToInteractiveMode = Nothing
   Private _currentSelectMode As SelectMultiFieldsMode = SelectMultiFieldsMode.None
   Private _createdFormPageType As FormsPageType = FormsPageType.Normal

   Private scannedImage As RasterImage = Nothing
   Private regionMode As Boolean = False
   Private cancelRegion As Boolean = False
   Private isFieldDirty As Boolean = False

   Private oldSelectedPageIndex As Integer = 0
   Private _openInitialPath As String = String.Empty
   Private _masterformspath As String
   Private _masterformsimage As RasterImage = Nothing
   Private _masterformsname As String = String.Empty
   Private _masterformsdirectory As String = String.Empty
   Private EditorStream As Stream = Nothing
   Private Enum SelectMultiFieldsMode
      None
      RenameFields
      ChangeSensitivity
      DeleteFields
   End Enum

   Public Property NoneInteractiveMode() As ImageViewerNoneInteractiveMode
      Get
         Return _noneInteractiveMode
      End Get
      Set(value As ImageViewerNoneInteractiveMode)
         _noneInteractiveMode = value
      End Set
   End Property

   Public Property PanInteractiveMode() As ImageViewerPanZoomInteractiveMode
      Get
         Return _panInteractiveMode
      End Get
      Set(value As ImageViewerPanZoomInteractiveMode)
         _panInteractiveMode = value
      End Set
   End Property

   Public Property ZoomToInteractiveMode() As ImageViewerZoomToInteractiveMode
      Get
         Return _zoomToInteractiveMode
      End Get
      Set(value As ImageViewerZoomToInteractiveMode)
         _zoomToInteractiveMode = value
      End Set
   End Property

   Private _automationInteractiveMode As AutomationInteractiveMode = Nothing
   Public Property AutomationInteractiveMode() As AutomationInteractiveMode
      Get
         Return _automationInteractiveMode
      End Get
      Set(value As AutomationInteractiveMode)
         _automationInteractiveMode = value
      End Set
   End Property

   Protected Overrides Sub OnLoad(e As EventArgs)
      If Not DesignMode Then
         InitViewers()
         BeginInvoke(New MethodInvoker(AddressOf Startup))
      End If

      MyBase.OnLoad(e)
   End Sub


   Private WithEvents rasterImageViewer1 As AutomationImageViewer
   Private WithEvents rasterImageList1 As ImageViewer

   Private Sub InitViewers()
      rasterImageViewer1 = New AutomationImageViewer()
      rasterImageViewer1.Dock = DockStyle.Fill
      rasterImageViewer1.UseDpi = True
      _splViewerList.Panel1.Controls.Add(rasterImageViewer1)
      rasterImageViewer1.BringToFront()


      rasterImageList1 = New ImageViewer(New ImageViewerHorizontalViewLayout() With {.Rows = 1})
      rasterImageList1.Dock = DockStyle.Fill
      rasterImageList1.ViewHorizontalAlignment = ControlAlignment.Center
      rasterImageList1.ViewVerticalAlignment = ControlAlignment.Center
      rasterImageList1.ItemSpacing = New LeadSize(20, 20)
      rasterImageList1.ItemBorderThickness = 2
      rasterImageList1.SelectedItemBorderColor = Color.Blue
      rasterImageList1.BackColor = SystemColors.AppWorkspace
      rasterImageList1.BorderStyle = BorderStyle.FixedSingle
      rasterImageList1.ItemSizeMode = ControlSizeMode.Fit
      rasterImageList1.ItemSize = New LeadSize(180, 200)
      rasterImageList1.InteractiveModes.Add(New ImageViewerSelectItemsInteractiveMode() With {.SelectionMode = ImageViewerSelectionMode.[Single]})
      _splViewerList.Panel2.Controls.Add(rasterImageList1)
      rasterImageList1.BringToFront()
   End Sub

   Private Sub Startup()
      Try
         'Check if ocr engine was passed in. The recognition demos have the ability to launch this demo and it will pass
         'the ocr engine it is using. We will default to that engine
         Dim commandArgs As String() = Environment.GetCommandLineArgs()
         If commandArgs.Length = 2 Then
            Dim settings As New Settings()
            settings.OcrEngineType = commandArgs(1)
            settings.Save()
         End If

         If Not StartUpEngines() Then
            Messager.ShowError(Me, "One or more required engines did not start. The application will now close.")
            Me.Close()
            Return
         End If

         SetUpViewers()
         SetupAnnotations()

         Messager.Caption = "LEADTOOLS Master Forms Editor"
         _splFormsViewer.Panel2MinSize = 270
         'Workaround for a bug in splitter container which restricts the values you can use for Panel2MinSize in the designer 
         '
         '            if (Properties.Settings.Default.FirstRun)
         '            {
         '               MessageBox.Show("LEADTOOLS provides extra sample forms available for download online. For more information and the download link, please see the How-to document under Help-->How To.", "Sample Forms", MessageBoxButtons.OK);
         '               Properties.Settings.Default.FirstRun = false;
         '               Properties.Settings.Default.Save();
         '            }
         '            


         'Load Default MasterForms Folder
         If _masterformsname = String.Empty Then
            LoadMasterForms()
         Else
            CreateMasterForms()
         End If

         UpdateControls()
      Catch exp As Exception
         Messager.ShowError(Me, exp)
      End Try

      _noneInteractiveMode = New ImageViewerNoneInteractiveMode()
      _panInteractiveMode = New ImageViewerPanZoomInteractiveMode()
      _panInteractiveMode.MouseButtons = System.Windows.Forms.MouseButtons.Left
      _zoomToInteractiveMode = New ImageViewerZoomToInteractiveMode()
      _automationInteractiveMode = New AutomationInteractiveMode()

      rasterImageViewer1.InteractiveModes.BeginUpdate()
      rasterImageViewer1.InteractiveModes.Add(_noneInteractiveMode)
      rasterImageViewer1.InteractiveModes.Add(_panInteractiveMode)
      rasterImageViewer1.InteractiveModes.Add(_zoomToInteractiveMode)
      rasterImageViewer1.InteractiveModes.Add(_automationInteractiveMode)
      rasterImageViewer1.InteractiveModes.EndUpdate()

      DisableInteractiveModes()

      rasterImageViewer1.InteractiveModes.EnableById(_automationInteractiveMode.Id)

      UpdateControls()
   End Sub

   Private Sub LoadMasterForms()
      Try
         CreateNewRepository(_masterformspath)

         'Clear viewer, imagelist, and fields
         If rasterImageViewer1.Image IsNot Nothing AndAlso Not rasterImageViewer1.Image.IsDisposed Then
            rasterImageViewer1.Image.Dispose()
            rasterImageViewer1.Image = Nothing
         End If

         rasterImageList1.Items.Clear()
         BuildFieldList()
      Catch exp As Exception
         Messager.ShowError(Me, exp)
      End Try
   End Sub

   Private Sub CreateMasterForms()
      Try
         Dim parentCategory As IMasterFormsCategory = Nothing
         Dim parentCategoryNode As TreeNode = Nothing
         If _tvMasterForms.SelectedNode Is Nothing Then
            'nothing selected, add it to root category
            workingRepository = New DiskMasterFormsRepository(rasterCodecs, _masterformsdirectory)
            BuildMasterFormList(workingRepository.RootCategory, _tvMasterForms.Nodes, True)
            parentCategory = workingRepository.RootCategory
            parentCategoryNode = _tvMasterForms.Nodes(0)
         Else
            'if selected node is category, add it as child. Otherwise add it to parent of selected node
            Dim type As Type = _tvMasterForms.SelectedNode.Tag.[GetType]()
            If type Is GetType(DiskMasterFormsCategory) Then
               'selected node is category
               parentCategory = TryCast(_tvMasterForms.SelectedNode.Tag, IMasterFormsCategory)
               parentCategoryNode = _tvMasterForms.SelectedNode
            Else
               'selected node is master form
               parentCategory = TryCast(_tvMasterForms.SelectedNode.Parent.Tag, IMasterFormsCategory)
               parentCategoryNode = _tvMasterForms.SelectedNode.Parent
            End If
         End If

         'Add master form to repository and treeview
         Dim newForm As IMasterForm = parentCategory.AddMasterForm(CreateMasterForm(_masterformsname), Nothing, CType(Nothing, RasterImage))
         Dim newNode As TreeNode = parentCategoryNode.Nodes.Add(newForm.Name)
         newNode.Tag = newForm
         _tvMasterForms.SelectedNode = newNode

         If _masterformsimage IsNot Nothing Then
            If _createdFormPageType = FormsPageType.Normal Then
               PageTypeToolStripMenuItem_Click(normalItem, Nothing)
            ElseIf _createdFormPageType = FormsPageType.IDCard Then
               PageTypeToolStripMenuItem_Click(cardItem, Nothing)
            ElseIf _createdFormPageType = FormsPageType.Omr Then
               PageTypeToolStripMenuItem_Click(omrItem, Nothing)
            End If

            AddMasterFormPages(_masterformsimage)
         End If
      Catch exp As Exception
         Messager.ShowError(Me, exp)
      End Try
   End Sub

   Private _magnagerHalper As AutomationManagerHelper = Nothing
   Private Sub SetupAnnotations()
      ' create and setup the automation manager
      annAutomationManager = New AnnAutomationManager()
      annAutomationManager.CreateDefaultObjects()


      _magnagerHalper = New AutomationManagerHelper(annAutomationManager)
      '_magnagerHalper.ContextMenu = null;

      annAutomationManager.EditObjectAfterDraw = True

      automation = New AnnAutomation(annAutomationManager, rasterImageViewer1)
      AddHandler automation.AfterObjectChanged, AddressOf automation_AfterObjectChanged
      AddHandler automation.Draw, AddressOf Children_CollectionChanged
      automation.Active = True
      AddHandler automation.CurrentDesignerChanged, AddressOf automation_CurrentDesignerChanged
      AddHandler automation.SetCursor, AddressOf automation_SetCursor
      AddHandler automation.RestoreCursor, AddressOf automation_RestoreCursor

      For Each obj As AnnAutomationObject In annAutomationManager.Objects
         obj.UseRotateThumbs = False
         obj.ContextMenu = Nothing
         'If obj.Id = AnnObject.GroupObjectId Then
         '   'Remove the grouping object
         '   annAutomationManager.Objects.Remove(obj)
         'End If
      Next
   End Sub

   Private Sub rasterImageViewer1_MouseUp(sender As Object, e As MouseEventArgs)
      'If no annotation is selected, make sure no field in the listbox is selected. keep them synched
      If automation.CurrentEditObject Is Nothing Then
         _lbFields.SelectedIndex = -1
         _lbFields_SelectedIndexChanged(Me, Nothing)
         _lbSelection.SelectedIndex = -1
         _lbSelection_SelectedIndexChanged(Me, Nothing)

         _lbBubble.SelectedIndex = -1
         _lbBubble_SelectedIndexChanged(Me, Nothing)
#If LEADTOOLS_V20_OR_LATER Then
         _lbAnswerArea.SelectedIndex = -1
         _lbAnswerArea_SelectedIndexChanged(Me, Nothing)

         _lbOmrDate.SelectedIndex = -1
         _lbOmrDate_SelectedIndexChanged(Me, Nothing)
#End If
      End If
   End Sub


   Private Function GetFreeFieldName() As String
      'Look for a field name that does not exist
      Dim i As Integer = 0
      Dim newName As String = [String].Empty
      While True
         newName = [String].Format("New Field {0}", i)
#If (LEADTOOLS_V20_OR_LATER) Then
         If ((_lbFields.Items.IndexOf(newName) = -1) _
                     AndAlso ((_lbSelection.Items.IndexOf(newName) = -1) _
                     AndAlso ((_lbBubble.Items.IndexOf(newName) = -1) _
                     AndAlso ((_lbAnswerArea.Items.IndexOf(newName) = -1) _
                     AndAlso (_lbOmrDate.Items.IndexOf(newName) = -1))))) Then
#Else
         If ((_lbFields.Items.IndexOf(newName) = -1) _
                     AndAlso ((_lbSelection.Items.IndexOf(newName) = -1) _
                     AndAlso (_lbBubble.Items.IndexOf(newName) = -1))) Then
#End If
            '#if LEADTOOLS_V20_OR_LATER
            Exit While
         End If
         i += 1
      End While

      Return newName
   End Function

   Private Sub automation_AfterObjectChanged(sender As Object, e As AnnAfterObjectChangedEventArgs)
      If TypeOf automation.CurrentDesigner Is AnnSelectionEditDesigner Then
         Return
      End If

      If e.ChangeType = AnnObjectChangedType.DesignerEdit Then
         If e.Objects(0).Tag Is Nothing Then
            Return
         End If

#If LEADTOOLS_V20_OR_LATER Then
         If TypeOf e.Objects(0).Tag Is SingleSelectionField OrElse TypeOf e.Objects(0).Tag Is BubbleWordField OrElse TypeOf e.Objects(0).Tag Is OmrAnswerAreaField OrElse TypeOf e.Objects(0).Tag Is OmrDateField Then
#Else
If TypeOf e.Objects(0).Tag Is SingleSelectionField OrElse TypeOf e.Objects(0).Tag Is BubbleWordField Then
#End If '#if LEADTOOLS_V20_OR_LATER
            Return
         End If

         'Field was edited/moved
         Dim selectedFieldName As String = TryCast(e.Objects(0).Tag, FormField).Name
         If Not [String].IsNullOrEmpty(selectedFieldName) Then
            Dim index As Integer = _lbFields.Items.IndexOf(selectedFieldName)
            If _lbFields.SelectedIndex <> index Then
               'new annotation field selected
               _lbFields.SelectedIndex = index
            End If
         End If
         'Get it's position
         Dim newBounds As LeadRect = RestrictZoneBoundsToPage(rasterImageViewer1.Image, BoundsFromAnnotations(e.Objects(0)))
         'Convert to rectangle to get whole number for pixel value

         Dim newBoundsRounded As LeadRect = newBounds

         'Check if field moved
         If TryCast(e.Objects(0).Tag, FormField).Bounds <> newBoundsRounded Then
            isFieldDirty = True
            UpdateField()
         End If

         If TypeOf getSelectedField() Is TableFormField Then
            UpdateTable(TryCast(getSelectedField(), TableFormField))
         End If

         If TypeOf getSelectedField() Is UnStructuredTextFormField Then
            UpdateUnStructuredText(TryCast(getSelectedField(), UnStructuredTextFormField))

         End If
      End If

      UpdateControls()
   End Sub

   Private Sub UpdateUnStructuredText(unstructuredTextField As UnStructuredTextFormField)
      If TypeOf automation.CurrentEditObject Is AnnHiliteObject OrElse TypeOf automation.CurrentEditObject Is AnnTextObject Then
         Dim AreaBounds As LeadRect = RestrictZoneBoundsToPage(rasterImageViewer1.Image, BoundsFromAnnotations(TryCast(unstructuredTextField.TextFormField.Tag, AnnObject)))
         Dim FieldsBounds As LeadRect = RestrictZoneBoundsToPage(rasterImageViewer1.Image, BoundsFromAnnotations(TryCast(unstructuredTextField.Tag, AnnObject)))
         Dim newBounds As New LeadRect()
         If unstructuredTextField.TextFormField.Tag Is automation.CurrentEditObject Then
            newBounds = New LeadRect(AreaBounds.X - FieldsBounds.X, Convert.ToInt32(0), (FieldsBounds.Right - FieldsBounds.X) - (AreaBounds.X - FieldsBounds.X), Convert.ToInt32(FieldsBounds.Height))
            If newBounds.Width < 1 OrElse newBounds.Width > FieldsBounds.Width Then
               newBounds.X = (Convert.ToInt32(FieldsBounds.Width) - Convert.ToInt32(AreaBounds.Width))
               newBounds.Width = Convert.ToInt32(AreaBounds.Width)
            End If
         Else
            newBounds = New LeadRect((Convert.ToInt32(FieldsBounds.Width) - Convert.ToInt32(AreaBounds.Width)), Convert.ToInt32(0), Convert.ToInt32(AreaBounds.Width), Convert.ToInt32(FieldsBounds.Height))
         End If

         unstructuredTextField.TextFormField.Bounds = newBounds
         automation.Container.Children.Remove(TryCast(unstructuredTextField.TextFormField.Tag, AnnObject))
         Dim obj As AnnTextObject = Nothing
         obj = New AnnTextObject()
         unstructuredTextField.TextFormField.Tag = obj
         automation.Container.Children.Add(obj)
         Dim c As New ColorConverter()
         Dim st As String = c.ConvertToString(Color.FromArgb(64, 0, 0, 0))
         obj.Fill = AnnSolidColorBrush.Create(st)
         obj.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Black"), New LeadLengthD(1))
         obj = TryCast(unstructuredTextField.TextFormField.Tag, AnnTextObject)

         If Not automation.Container.Children.Contains(obj) Then
            automation.Container.Children.Add(obj)
         End If

         obj.Text = unstructuredTextField.TextFormField.Name
         Dim lrc As LeadRect = UnStructuredTextField.TextFormField.Bounds
         lrc.Offset(unstructuredTextField.Bounds.Location)

         Dim rc As New RectangleF(lrc.Left, lrc.Top, lrc.Width, lrc.Height)
         obj.Rect = BoundsToAnnotations(obj, rc)
         obj.Tag = unstructuredTextField
         unstructuredTextField.TextFormField.Tag = obj
      End If
      rasterImageViewer1.Invalidate()
   End Sub

   Private Sub UpdateTable(tableField As TableFormField)
      If TypeOf automation.CurrentEditObject Is AnnHiliteObject Then
         Dim rc As LeadRect
         rc = tableField.Columns(tableField.Columns.Count - 1).OcrField.Bounds
         rc.Width = tableField.Bounds.Width - rc.Left
         tableField.Columns(tableField.Columns.Count - 1).OcrField.Bounds = rc

         updateColumnsPosition(tableField)
      End If

      If TypeOf automation.CurrentEditObject Is AnnTextObject Then
         For i As Integer = 0 To tableField.Columns.Count - 1
            If tableField.Columns(i).Tag Is automation.CurrentEditObject Then
               Dim columnBounds As LeadRect = RestrictZoneBoundsToPage(rasterImageViewer1.Image, BoundsFromAnnotations(TryCast(tableField.Columns(i).Tag, AnnObject)))
               Dim tableBounds As LeadRect = RestrictZoneBoundsToPage(rasterImageViewer1.Image, BoundsFromAnnotations(TryCast(tableField.Tag, AnnObject)))

               If tableBounds.Height = columnBounds.Height AndAlso LeadRect.Intersect(tableBounds, columnBounds) <> LeadRect.Empty Then
                  Dim newBounds As New LeadRect(columnBounds.X - tableBounds.X, Convert.ToInt32(0), Convert.ToInt32(columnBounds.Width), Convert.ToInt32(tableBounds.Height))
                  If Not IsOverlapped(tableField.Columns(i), newBounds, tableField) Then
                     Dim bIsLeft As Boolean = newBounds.Right = tableField.Columns(i).OcrField.Bounds.Right

                     tableField.Columns(i).OcrField.Bounds = newBounds

                     Dim rc As LeadRect
                     If bIsLeft OrElse i = tableField.Columns.Count - 1 Then
                        rc = tableField.Columns(i - 1).OcrField.Bounds
                        rc.Width = Math.Abs(newBounds.Left - rc.Left)
                        tableField.Columns(i - 1).OcrField.Bounds = rc
                     Else
                        rc = tableField.Columns(i + 1).OcrField.Bounds
                        rc.Width = Math.Abs(newBounds.Right - rc.Right)
                        tableField.Columns(i + 1).OcrField.Bounds = rc
                     End If
                     updateColumnsPosition(tableField)
                  End If
               End If
               Exit For
            End If
         Next
      End If

      updateColumnsList(TryCast(tableField, TableFormField))
      AlignmentTableFields(TryCast(tableField, TableFormField))
   End Sub

   Private Function IsOverlapped(Column As TableColumn, newBounds As LeadRect, tableField As TableFormField) As Boolean
      If Column.OcrField.Bounds.Width = newBounds.Width Then
         Return True
      ElseIf newBounds.Right > tableField.Bounds.Width Then
         Return True
      ElseIf newBounds.Left < 0 Then
         Return True
      ElseIf newBounds.Right <= Column.OcrField.Bounds.Left Then
         Return True
      ElseIf newBounds.Left >= Column.OcrField.Bounds.Right Then
         Return True
      End If

      For i As Integer = 0 To tableField.Columns.Count - 1
         If Column.Tag Is tableField.Columns(i).Tag Then
            If i = 0 AndAlso newBounds.Left <> 0 Then
               Return True
            ElseIf i + 2 < tableField.Columns.Count AndAlso newBounds.IntersectsWith(tableField.Columns(i + 2).OcrField.Bounds) Then
               Return True
            ElseIf i - 2 >= 0 AndAlso newBounds.IntersectsWith(tableField.Columns(i - 2).OcrField.Bounds) Then
               Return True
            End If
         End If
      Next
      Return False
   End Function

   Private Sub UnStructuredTextFormFieldDisplay(unstructuredTextField As UnStructuredTextFormField)
      If unstructuredTextField IsNot Nothing Then
         Dim hiliteObject As AnnHiliteObject = TryCast(unstructuredTextField.Tag, AnnHiliteObject)
         Dim tableRect As LeadRect = UnStructuredTextField.Bounds
         Dim tablerc As New RectangleF(tableRect.Left, tableRect.Top, tableRect.Width, tableRect.Height)

         hiliteObject.Rect = BoundsToAnnotations(hiliteObject, tablerc)
         Dim obj As AnnTextObject = Nothing
         obj = New AnnTextObject()
         unstructuredTextField.TextFormField.Tag = obj
         automation.Container.Children.Add(obj)
         Dim c As New ColorConverter()
         Dim st As String = c.ConvertToString(Color.FromArgb(64, 0, 0, 0))
         obj.Fill = AnnSolidColorBrush.Create(st)
         obj.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Black"), New LeadLengthD(1))
         obj = TryCast(unstructuredTextField.TextFormField.Tag, AnnTextObject)

         If Not automation.Container.Children.Contains(obj) Then
            automation.Container.Children.Add(obj)
         End If

         obj.Text = unstructuredTextField.TextFormField.Name
         Dim lrc As LeadRect = UnStructuredTextField.TextFormField.Bounds
         lrc.Offset(unstructuredTextField.Bounds.Location)

         Dim rc As New RectangleF(lrc.Left, lrc.Top, lrc.Width, lrc.Height)
         obj.Rect = BoundsToAnnotations(obj, rc)
         obj.Tag = unstructuredTextField
         unstructuredTextField.TextFormField.Tag = obj
      End If
      rasterImageViewer1.Invalidate()
   End Sub

#If LEADTOOLS_V20_OR_LATER Then
   Private Sub OmrDateFieldDisplay(omrDateField As OmrDateField)
      If omrDateField IsNot Nothing Then
         Dim newObject As AnnObject = TryCast(omrDateField.Tag, AnnObject)

         If newObject IsNot Nothing Then
            newObject.Opacity = 0.3
            newObject.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Red"), New LeadLengthD(2))
         End If

         Dim newRectObject As AnnRectangleObject = Nothing

         If newObject IsNot Nothing Then
            newRectObject = New AnnRectangleObject(newObject.Bounds)

            Dim st As String = New ColorConverter().ConvertToString(Color.FromArgb(93, 255, 100, 100))
            newRectObject.Fill = AnnSolidColorBrush.Create(st)
            newRectObject.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Red"), New LeadLengthD(2))

            automation.Container.Children.Add(newRectObject)
            automation.Container.Children.Remove(newObject)
            omrDateField.Tag = newRectObject
            newRectObject.Tag = omrDateField
         End If

         SingleSelectionFieldDisplay(omrDateField.MonthField)
         BubbleWordFieldDisplay(omrDateField.YearField)
         BubbleWordFieldDisplay(omrDateField.DayField)
      End If
   End Sub

   Private Sub AnswerAreaFieldDisplay(answerAreaField As OmrAnswerAreaField)
      If answerAreaField IsNot Nothing Then
         Dim newObject As AnnObject = TryCast(answerAreaField.Tag, AnnObject)

         If newObject IsNot Nothing Then
            newObject.Opacity = 0.3
            newObject.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Aqua"), New LeadLengthD(2))
         End If

         Dim newRectObject As AnnRectangleObject = Nothing

         If newObject IsNot Nothing Then
            newRectObject = New AnnRectangleObject(newObject.Bounds)

            Dim st As String = New ColorConverter().ConvertToString(Color.FromArgb(93, 100, 192, 255))
            newRectObject.Fill = AnnSolidColorBrush.Create(st)
            newRectObject.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Aqua"), New LeadLengthD(2))

            automation.Container.Children.Add(newRectObject)
            automation.Container.Children.Remove(newObject)
            answerAreaField.Tag = newRectObject
            newRectObject.Tag = answerAreaField
         End If

         For Each field As SingleSelectionField In answerAreaField.Answers
            SingleSelectionFieldDisplay(field)
         Next
      End If
   End Sub
#End If


   Private Sub BubbleWordFieldDisplay(bubbleWordField As BubbleWordField)
      If bubbleWordField IsNot Nothing Then
         Dim bubbleWordRect As LeadRect = bubbleWordField.Bounds

         Dim newObject As AnnObject = TryCast(bubbleWordField.Tag, AnnObject)

         If newObject IsNot Nothing Then
            newObject.Opacity = 0.3
            newObject.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Red"), New LeadLengthD(2))
         End If

         Dim newRectObject As AnnRectangleObject = Nothing

         If newObject IsNot Nothing Then
            newRectObject = New AnnRectangleObject(newObject.Bounds)
            automation.Container.Children.Remove(newObject)
         Else
            Dim transformedRect As LeadRectD = BoundsToAnnotations(Nothing, New RectangleF(CSng(bubbleWordField.Bounds.X), CSng(bubbleWordField.Bounds.Y), CSng(bubbleWordField.Bounds.Width), CSng(bubbleWordField.Bounds.Height)))
            newRectObject = New AnnRectangleObject(transformedRect)
         End If

         Dim st As String = New ColorConverter().ConvertToString(Color.FromArgb(93, 255, 192, 203))
         newRectObject.Fill = AnnSolidColorBrush.Create(st)
         newRectObject.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Red"), New LeadLengthD(2))

         automation.Container.Children.Add(newRectObject)

         bubbleWordField.Tag = newRectObject
         newRectObject.Tag = bubbleWordField

         If [String].IsNullOrEmpty(bubbleWordField.Parent) Then
            For Each field As SingleSelectionField In bubbleWordField.Fields
               field.Parent = bubbleWordField.Name
               SingleSelectionFieldDisplay(field)
            Next
         End If
      End If

      rasterImageViewer1.Invalidate()
   End Sub

   Private Sub SingleSelectionFieldDisplay(singleSelection As SingleSelectionField)
      If singleSelection IsNot Nothing Then
         Dim selectionRect As LeadRect = singleSelection.Bounds
         Dim objectsRects As New List(Of LeadRect)()
         Dim nameRect As LeadRect = singleSelection.NameBounds

         For i As Integer = 0 To singleSelection.Fields.Count - 1
            objectsRects.Add(singleSelection.Fields(i).Bounds)
         Next

         Dim newObject As AnnObject = TryCast(singleSelection.Tag, AnnObject)
         Dim newRectObject As AnnRectangleObject = Nothing

         If newObject IsNot Nothing Then
            newRectObject = New AnnRectangleObject(newObject.Bounds)

            Dim st As String = New ColorConverter().ConvertToString(Color.FromArgb(30, 255, 0, 0))
            newRectObject.Fill = AnnSolidColorBrush.Create(st)
            newRectObject.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Red"), New LeadLengthD(1))

            automation.Container.Children.Add(newRectObject)
            automation.Container.Children.Remove(newObject)
            singleSelection.Tag = newRectObject
            newRectObject.Tag = singleSelection
         End If

         Dim obj As New AnnRectangleObject()

         automation.Container.Children.Add(obj)
         Dim c As New ColorConverter()
         Dim color__1 As String = c.ConvertToString(Color.FromArgb(20, 0, 0, 0))

         obj.Fill = AnnSolidColorBrush.Create(color__1)
         obj.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Red"), New LeadLengthD(1))
         obj.Tag = singleSelection

         obj.Rect = BoundsToAnnotations(obj, New RectangleF(nameRect.Left, nameRect.Top, nameRect.Width, nameRect.Height))

         If objectsRects IsNot Nothing Then
            For Each fieldRect As LeadRect In objectsRects
               Dim fieldObject As New AnnRectangleObject()
               automation.Container.Children.Add(fieldObject)

               fieldObject.Fill = AnnSolidColorBrush.Create(color__1)
               fieldObject.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Red"), New LeadLengthD(1))
               fieldObject.Tag = singleSelection

               fieldObject.Rect = BoundsToAnnotations(obj, New RectangleF(fieldRect.Left, fieldRect.Top, fieldRect.Width, fieldRect.Height))
            Next
         End If
      End If

      rasterImageViewer1.Invalidate()
   End Sub

   Private Sub AlignmentTableFields(tableField As TableFormField)
      If tableField IsNot Nothing Then
         Dim hiliteObject As AnnHiliteObject = TryCast(tableField.Tag, AnnHiliteObject)
         Dim tableRect As LeadRect = tableField.Bounds
         Dim tablerc As New RectangleF(tableRect.Left, tableRect.Top, tableRect.Width, tableRect.Height)
         hiliteObject.Rect = BoundsToAnnotations(hiliteObject, tablerc)


         For Each column As TableColumn In tableField.Columns
            Dim obj As AnnTextObject = Nothing

            If column.Tag Is Nothing Then
               obj = New AnnTextObject()
               column.Tag = obj
               automation.Container.Children.Add(obj)
               obj.TextForeground = AnnSolidColorBrush.Create("Black")
               Dim c As New ColorConverter()
               Dim st As String = c.ConvertToString(Color.FromArgb(64, 0, 0, 0))
               obj.Fill = AnnSolidColorBrush.Create(st)
               obj.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Black"), New LeadLengthD(1))
               obj.Font = New AnnFont("Arial", 12)
            End If

            obj = TryCast(column.Tag, AnnTextObject)

            If Not automation.Container.Children.Contains(obj) Then
               automation.Container.Children.Add(obj)
            End If

            obj.Text = column.OcrField.Name
            Dim lrc As LeadRect = column.OcrField.Bounds
            lrc.Offset(tableField.Bounds.Location)
            Dim rc As New RectangleF(lrc.Left, lrc.Top, lrc.Width, lrc.Height)
            obj.Rect = BoundsToAnnotations(obj, rc)
            obj.Tag = tableField
            column.Tag = obj
         Next

         rasterImageViewer1.Invalidate()
         UpdateControls()
      End If
   End Sub

   Private Function BoundsFromAnnotations(annObject As AnnObject) As LeadRect
      If annObject Is Nothing Then
         Return LeadRect.Empty
      End If

      ' Convert a rectangle from annotation object to logical coordinates (top-left)
      Dim temp As LeadRectD = automation.Container.Mapper.RectFromContainerCoordinates(annObject.Bounds, AnnFixedStateOperations.None)

      temp = rasterImageViewer1.ConvertRect(Nothing, ImageViewerCoordinateType.Control, ImageViewerCoordinateType.Image, temp)

      Dim rc As New RectangleF(CSng(temp.X), CSng(temp.Y), CSng(temp.Width), CSng(temp.Height))

      Dim rect As New LeadRect(CInt(Math.Round(rc.Left)), CInt(Math.Round(rc.Top)), CInt(Math.Round(rc.Width)), CInt(Math.Round(rc.Height)))

      Return rect
   End Function

   Private Function BoundsToAnnotations(annObject As AnnObject, rect As RectangleF) As LeadRectD
      ' Convert a rectangle from logical (top-left) to annotation object coordinates
      Dim rc As New LeadRectD(Math.Max(rect.X, 0), Math.Max(rect.Y, 0), Math.Max(rect.Width, 0), Math.Max(rect.Height, 0))

      rc = rasterImageViewer1.ConvertRect(Nothing, ImageViewerCoordinateType.Image, ImageViewerCoordinateType.Control, rc)

      rc = automation.Container.Mapper.RectToContainerCoordinates(rc)
      Return rc
   End Function

   Private Function RestrictZoneBoundsToPage(image As RasterImage, bounds As LeadRect) As LeadRect
      Dim pageBounds As New LeadRect(0, 0, image.Width, image.Height)
      Dim rc As LeadRect = bounds

      rc = LeadRect.Intersect(pageBounds, rc)

      Return rc
   End Function

   Private Function GetFormsDir() As String
      Dim formsDir As String
      formsDir = DemosGlobal.ImagesFolder + "\" + "Forms\MasterForm Sets"

      If ocrEngine.EngineType = OcrEngineType.LEAD Then
         formsDir += "\OCR"
      End If

      Return formsDir
   End Function

   Private Sub SetUpViewers()
      Try
         Dim properties As RasterPaintProperties = RasterPaintProperties.[Default]
         properties.PaintDisplayMode = RasterPaintDisplayModeFlags.Bicubic Or RasterPaintDisplayModeFlags.ScaleToGray
         properties.PaintEngine = RasterPaintEngine.Gdi
         properties.UsePaintPalette = True
         rasterImageViewer1.PaintProperties = properties
         rasterImageViewer1.UseDpi = _btnUseDpi.Checked
         rasterImageList1.UseDpi = _btnUseDpi.Checked
         rasterImageList1.PaintProperties = properties
         AddHandler rasterImageViewer1.MouseUp, AddressOf rasterImageViewer1_MouseUp
      Catch exp As Exception
         Messager.ShowError(Me, exp)
      End Try
   End Sub

   Private Sub StartupTwain()
      Try
         twainSession = New TwainSession()
         If twainSession.IsAvailable(Me.Handle) Then
            twainSession.Startup(Me.Handle, "LEAD Technologies, Inc.", "LEAD Test Applications", "Version 1.0", "TWAIN Test Application", TwainStartupFlags.None)
            AddHandler twainSession.AcquirePage, AddressOf twainSession_AcquirePage
         End If
      Catch ex As TwainException
         If ex.Code = TwainExceptionCode.InvalidDll Then
            twainSession = Nothing
            Messager.ShowError(Me, "You have an old version of TWAINDSM.DLL. Please download latest version of this DLL from www.twain.org")
         Else
            twainSession = Nothing
            Messager.ShowError(Me, ex)
         End If
      Catch ex As Exception
         Messager.ShowError(Me, ex)
         twainSession = Nothing
      End Try
   End Sub

   Public Function StartUpEngines() As Boolean
      Try
         StartUpRasterCodecs()
         StartUpOcrEngine()
         StartUpBarcodeEngine()
         StartupTwain()
         SetupRecognitionEngine()
         Return True
      Catch
         Return False
      End Try
   End Function

   Private Sub ShutDownEngines()
      If ocrEngine IsNot Nothing AndAlso ocrEngine.IsStarted Then
         Dim settings As New Settings()
         settings.OcrEngineType = ocrEngine.EngineType.ToString()
         settings.Save()

         ocrEngine.Shutdown()
         ocrEngine.Dispose()
      End If

      If twainSession IsNot Nothing Then
         twainSession.Shutdown()
      End If
   End Sub

   Private Sub StartUpRasterCodecs()
      Try
         rasterCodecs = New RasterCodecs()

         'To turn off the dithering method when converting colored images to 1-bit black and white image during the load
         'so the text in the image is not damaged.
         RasterDefaults.DitheringMethod = RasterDitheringMethod.None
         rasterCodecs.Options.Load.Resolution = 300
         rasterCodecs.Options.RasterizeDocument.Load.Resolution = 300
      Catch exp As Exception
         Messager.ShowError(Me, exp)
         Throw
      End Try
   End Sub

   Private Sub StartUpOcrEngine()
      Try
         Dim settings As New Settings()
         Dim engineType As String = settings.OcrEngineType

         ' Show the engine selection dialog
         Using dlg As New OcrEngineSelectDialog(Messager.Caption, engineType, False)
            If dlg.ShowDialog(Me) = DialogResult.OK Then
               ocrEngine = OcrEngineManager.CreateEngine(dlg.SelectedOcrEngineType, False)
               ocrEngine.Startup(Nothing, Nothing, Nothing, Nothing)

               If ocrEngine.EngineType = OcrEngineType.LEAD Then
                  If ocrEngine.SettingManager.IsSettingNameSupported("Recognition.RecognitionModuleTradeoff") Then
                     ocrEngine.SettingManager.SetEnumValue("Recognition.RecognitionModuleTradeoff", "Accurate")
                  End If
               End If

               Me.Text = [String].Format("{0} [{1} Engine]", Me.Text, dlg.SelectedOcrEngineType.ToString())
            Else
               Throw New Exception("No engine selected.")
            End If
         End Using
      Catch exp As Exception
         Messager.ShowError(Me, exp)
         Throw
      End Try
   End Sub

   Private Sub StartUpBarcodeEngine()
      Try
         barcodeEngine = New BarcodeEngine()
      Catch exp As Exception
         Messager.ShowError(Me, exp)
         Throw
      End Try
   End Sub

   Private Sub SetupRecognitionEngine()
      Try
         If recognitionEngine Is Nothing Then
            recognitionEngine = New FormRecognitionEngine()
         End If

         'Add appropriate object managers to recognition engine
         recognitionEngine.ObjectsManagers.Clear()
         If _menuItemDefaultManager.Checked Then
            Dim defaultObjectManager As New DefaultObjectsManager()
            recognitionEngine.ObjectsManagers.Add(defaultObjectManager)
         End If

         If _menuItemOCRManager.Checked AndAlso ocrEngine.IsStarted Then
            Dim ocrObejectManager As New OcrObjectsManager(ocrEngine)
            ocrObejectManager.Engine = ocrEngine
            recognitionEngine.ObjectsManagers.Add(ocrObejectManager)
         End If

         If _menuItemBarcodeManager.Checked AndAlso barcodeEngine IsNot Nothing Then
            Dim barcodeObjectManager As New BarcodeObjectsManager(barcodeEngine)
            barcodeObjectManager.Engine = barcodeEngine
            recognitionEngine.ObjectsManagers.Add(barcodeObjectManager)
         End If
      Catch exp As Exception
         Messager.ShowError(Me, exp)
         Throw
      End Try
   End Sub

   Private Sub LoadFormSet_Click(sender As Object, e As EventArgs) Handles _btnLoadFormSet.Click, _menuItemLoadFormSet.Click
      If Not CheckForUnsavedChanges() Then
         Return
      End If

      Try
         Dim fbd As New FolderBrowserDialogEx()
         fbd.Description = "Please select the root directory for your master form set."
         fbd.SelectedPath = GetFormsDir()
         fbd.ShowFullPathInEditBox = True
         fbd.ShowEditBox = True
         fbd.ShowNewFolderButton = False

         If fbd.ShowDialog() = DialogResult.OK Then
            CreateNewRepository(fbd.SelectedPath)

            'Clear viewer, imagelist, and fields
            If rasterImageViewer1.Image IsNot Nothing AndAlso Not rasterImageViewer1.Image.IsDisposed Then
               rasterImageViewer1.Image.Dispose()
               rasterImageViewer1.Image = Nothing
            End If

            rasterImageList1.Items.Clear()
            BuildFieldList()

         End If
      Catch exp As Exception
         Messager.ShowError(Me, exp)
      End Try
      UpdateControls()
   End Sub

   Private Sub BuildMasterFormList(rootCategory As IMasterFormsCategory, nodes As TreeNodeCollection, clearExisting As Boolean)
      If clearExisting Then
         'Loading new master form set
         _tvMasterForms.Nodes.Clear()
         Dim rootNode As TreeNode = nodes.Add("MasterForms")
         rootNode.Tag = rootCategory
         BuildMasterFormList(rootCategory, rootNode.Nodes, False)
         rootNode.Expand()
      Else
         'Processing child categories (from recursion)
         For Each masterForm As IMasterForm In rootCategory.MasterForms
            Dim masterFormNode As TreeNode = nodes.Add(masterForm.Name)
            masterFormNode.Tag = masterForm
         Next

         For Each childCategory As IMasterFormsCategory In rootCategory.ChildCategories
            Dim childNode As TreeNode = nodes.Add(childCategory.Name)
            childNode.Tag = childCategory
            BuildMasterFormList(childCategory, childNode.Nodes, False)
         Next
      End If
      UpdateControls()
   End Sub

   Private Sub _tvMasterForms_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles _tvMasterForms.AfterSelect
      Try
         'Clear viewer and image list
         If rasterImageViewer1.Image IsNot Nothing AndAlso Not rasterImageViewer1.Image.IsDisposed Then
            rasterImageViewer1.Image.Dispose()
            rasterImageViewer1.Image = Nothing
         End If
         rasterImageList1.Items.Clear()
         _lbFields.SelectedIndex = -1
         _lbSelection.SelectedIndex = -1
         _lbBubble.SelectedIndex = -1
#If LEADTOOLS_V20_OR_LATER Then
         _lbAnswerArea.SelectedIndex = -1
         _lbOmrDate.SelectedIndex = -1
         _lbAnswerArea.Items.Clear()
         _lbOmrDate.Items.Clear()
#End If
         _lbFields.Items.Clear()
         _lbSelection.Items.Clear()
         _lbBubble.Items.Clear()

         If e.Node.Tag IsNot Nothing Then
            Dim type As Type = e.Node.Tag.[GetType]()

            If type Is GetType(DiskMasterFormsCategory) Then
            ElseIf type Is GetType(DiskMasterForm) Then
               'A new master form has been selected. 
               BuildMasterPageList()
            End If
         End If
      Catch exp As Exception
         Messager.ShowError(Me, exp)
      End Try
      UpdateControls()
   End Sub

   Private Sub BuildMasterPageList()
      'Clear viewer and image list
      If rasterImageViewer1.Image IsNot Nothing AndAlso Not rasterImageViewer1.Image.IsDisposed Then
         rasterImageViewer1.Image.Dispose()
         rasterImageViewer1.Image = Nothing
      End If
      rasterImageList1.Items.Clear()
      _lbFields.Items.Clear()

      'Add pages of master form to imagelist
      Dim currentMasterForm As DiskMasterForm = GetCurrentMasterForm()
      If currentMasterForm Is Nothing Then
         Return
      End If

      Dim masterImage As RasterImage = currentMasterForm.ReadForm()
      If masterImage IsNot Nothing Then
         For i As Integer = 0 To masterImage.PageCount - 1
            masterImage.Page = i + 1
            Dim item As New ImageViewerItem()
            item.Image = masterImage.Clone()
            rasterImageList1.Items.Add(item)
         Next
         If masterImage IsNot Nothing AndAlso Not masterImage.IsDisposed Then
            masterImage.Dispose()
         End If

         If rasterImageList1.Items.Count > 0 Then
            rasterImageList1.Items(0).IsSelected = True
            rasterImageList1_SelectedIndexChanged(Me, Nothing)
         End If
      End If
      UpdateControls()
   End Sub

   Private Sub BuildFieldList()
      If _lbFields.IsDisposed Then
         Return
      End If

      'Add fields for current form and page to listbox
      _lbFields.Items.Clear()
      automation.SelectObject(Nothing)

      automation.Container.Children.Clear()

      Dim currentMasterForm As DiskMasterForm = GetCurrentMasterForm()
      If currentMasterForm Is Nothing Then
         Return
      End If

      If rasterImageList1.Items.Count = 0 Then
         Return
      End If

      Dim formPages As FormPages = currentMasterForm.ReadFields()

      If formPages IsNot Nothing Then
         Dim currentPage As Integer = 0
         For i As Integer = 0 To rasterImageList1.Items.Count - 1
            If rasterImageList1.Items(i).IsSelected Then
               currentPage = rasterImageList1.Items.IndexOf(rasterImageList1.Items(i))
               Exit For
            End If
         Next

         Dim highLevelFields As New List(Of FormField)()



         For Each field As FormField In formPages(currentPage)
#If LEADTOOLS_V20_OR_LATER Then
            If TypeOf field Is SingleSelectionField OrElse TypeOf field Is BubbleWordField OrElse TypeOf field Is OmrAnswerAreaField OrElse TypeOf field Is OmrDateField Then
#Else
            If TypeOf field Is SingleSelectionField OrElse TypeOf field Is BubbleWordField Then
#End If '#if LEADTOOLS_V20_OR_LATER
               highLevelFields.Add(field)
            Else
               AddField(field)
            End If
         Next

         If highLevelFields.Count > 0 Then
            For Each field As FormField In highLevelFields
               AddField(field)
            Next
         End If

         If _lbFields.Items.Count > 0 Then
            'Select first field
            _lbFields.SelectedIndex = 0
         End If
      End If

      UpdateControls()
   End Sub

   Private Sub AddField(fieldToAdd As FormField)
#If LEADTOOLS_V20_OR_LATER Then
      If Not (TypeOf fieldToAdd Is SingleSelectionField) AndAlso Not (TypeOf fieldToAdd Is BubbleWordField) AndAlso Not (TypeOf fieldToAdd Is OmrAnswerAreaField) AndAlso Not (TypeOf fieldToAdd Is OmrDateField) Then
#Else
      If Not (TypeOf fieldToAdd Is SingleSelectionField) AndAlso Not (TypeOf fieldToAdd Is BubbleWordField) Then
#End If '#if LEADTOOLS_V20_OR_LATER
         _lbFields.Items.Add(fieldToAdd.Name)
#If LEADTOOLS_V20_OR_LATER Then
      ElseIf (TypeOf fieldToAdd Is OmrAnswerAreaField) Then
         If (Not _lbAnswerArea.Items.Contains(fieldToAdd.Name)) Then
            _lbAnswerArea.Items.Add(fieldToAdd.Name)
         End If

      ElseIf (TypeOf fieldToAdd Is OmrDateField) Then
         If (Not _lbOmrDate.Items.Contains(fieldToAdd.Name)) Then
            _lbOmrDate.Items.Add(fieldToAdd.Name)
         End If
#End If '#if LEADTOOLS_V20_OR_LATER
      ElseIf TypeOf fieldToAdd Is SingleSelectionField Then
         If Not _lbSelection.Items.Contains(fieldToAdd.Name) Then
            If [String].IsNullOrEmpty(TryCast(fieldToAdd, SingleSelectionField).Parent) Then
               _lbSelection.Items.Add(fieldToAdd.Name)
            End If
         End If
      ElseIf TypeOf fieldToAdd Is BubbleWordField Then
         If Not _lbBubble.Items.Contains(fieldToAdd.Name) Then
            _lbBubble.Items.Add(fieldToAdd.Name)
         End If
      End If

      Dim annotationField As New AnnHiliteObject()
      annotationField.Tag = fieldToAdd
      annotationField.HiliteColor = GetHighlightColor(fieldToAdd.[GetType]())


      'temporarily disable item added event so it does not fire while adding these fields
      RemoveHandler automation.Draw, AddressOf Children_CollectionChanged
      automation.Container.Children.Add(annotationField)
      AddHandler automation.Draw, AddressOf Children_CollectionChanged

      ' Now we can calculate the object bounds correctly

      Dim lrc As LeadRect = fieldToAdd.Bounds
      Dim rc As New RectangleF(lrc.Left, lrc.Top, lrc.Width, lrc.Height)

      Dim rect As LeadRectD = BoundsToAnnotations(annotationField, rc)
      annotationField.Rect = rect

      If TypeOf fieldToAdd Is TableFormField Then
         fieldToAdd.Tag = annotationField
         updateColumnsList(TryCast(fieldToAdd, TableFormField))
         AlignmentTableFields(TryCast(fieldToAdd, TableFormField))
      End If

      If TypeOf fieldToAdd Is UnStructuredTextFormField Then
         fieldToAdd.Tag = annotationField
         UnStructuredTextFormFieldDisplay(TryCast(fieldToAdd, UnStructuredTextFormField))
      End If

      If TypeOf fieldToAdd Is SingleSelectionField Then
         fieldToAdd.Tag = annotationField
         SingleSelectionFieldDisplay(TryCast(fieldToAdd, SingleSelectionField))
         automation.Container.Children.BringToFront(TryCast(fieldToAdd.Tag, AnnObject), True)
      End If

      If TypeOf fieldToAdd Is BubbleWordField Then
         fieldToAdd.Tag = annotationField
         BubbleWordFieldDisplay(TryCast(fieldToAdd, BubbleWordField))
         automation.Container.Children.BringToFront(TryCast(fieldToAdd.Tag, AnnObject), True)
      End If
   End Sub

#If LEADTOOLS_V20_OR_LATER Then
   Private Sub SetOmrDateParentName(omrDateField As OmrDateField)
      omrDateField.MonthField.Parent = omrDateField.Name
      omrDateField.DayField.Parent = omrDateField.Name
      For i As Integer = 0 To omrDateField.DayField.Fields.Count - 1
         omrDateField.DayField.Fields(i).Tag = omrDateField

         omrDateField.DayField.Fields(i).Parent = omrDateField.Name
      Next
      omrDateField.YearField.Parent = omrDateField.Name
      For i As Integer = 0 To omrDateField.YearField.Fields.Count - 1
         omrDateField.YearField.Fields(i).Tag = omrDateField

         omrDateField.YearField.Fields(i).Parent = omrDateField.Name
      Next
   End Sub
#End If

   Private Function GetOmrFormFields() As List(Of FormField)
      Dim fields As New List(Of FormField)()

      For Each annotationField As AnnObject In automation.Container.Children
         Dim currentField As FormField = TryCast(annotationField.Tag, OmrFormField)
         If currentField IsNot Nothing Then
            If Not fields.Contains(currentField) Then
               fields.Add(currentField)
            End If
         End If
      Next

      Return fields
   End Function


   Private Sub Children_CollectionChanged(sender As Object, e As AnnDrawDesignerEventArgs)

      If e.OperationStatus = AnnDesignerOperationStatus.[End] Then

         CheckToolButtons(_btnPointerTool)
         If regionMode Then
            Return
         End If

         Try
            'No object added yet
            If e.[Object] Is Nothing OrElse e.[Object].Bounds = LeadRectD.Empty Then
               Return
            End If

            Dim newObject As AnnHiliteObject = TryCast(e.[Object], AnnHiliteObject)
            Dim newField As FormField = Nothing

            If newObject Is Nothing Then
               Return
            End If

            'Check the type of field drawn
            If newObject.HiliteColor = "Green" Then
               If newObject.Tag Is Nothing Then
                  'This is a new field
                  newField = New TextFormField()
               Else
                  'This is a pasted field
                  newField = TryCast(newObject.Tag, TextFormField)
               End If
            ElseIf newObject.HiliteColor = "Purple" Then
               If newObject.Tag Is Nothing Then
                  'This is a new field
                  newField = New OmrFormField()
               Else
                  'This is a pasted field
                  newField = TryCast(newObject.Tag, OmrFormField)
               End If
            ElseIf newObject.HiliteColor = "Yellow" Then
               If newObject.Tag Is Nothing Then
                  'This is a new field
                  newField = New ImageFormField()
               Else
                  'This is a pasted field
                  newField = TryCast(newObject.Tag, ImageFormField)
               End If
            ElseIf newObject.HiliteColor = "Orange" Then
               If newObject.Tag Is Nothing Then
                  'This is a new field
                  newField = New BarcodeFormField()
               Else
                  'This is a pasted field
                  newField = TryCast(newObject.Tag, BarcodeFormField)
               End If
            ElseIf newObject.HiliteColor = "Red" Then
               If newObject.Tag Is Nothing Then
                  'This is a new field
                  newField = New TableFormField()
               Else
                  'This is a pasted field
                  newField = TryCast(newObject.Tag, TableFormField)
               End If
            ElseIf newObject.HiliteColor = "DarkSeaGreen" Then
               If newObject.Tag Is Nothing Then
                  'This is a new field
                  newField = New UnStructuredTextFormField()
               Else
                  'This is a pasted field
                  newField = TryCast(newObject.Tag, UnStructuredTextFormField)
               End If
            ElseIf newObject.HiliteColor = "Brown" Then
               If newObject.Tag Is Nothing Then
                  Dim currentPage As Integer = 0
                  For i As Integer = 0 To rasterImageList1.Items.Count - 1
                     If rasterImageList1.Items(i).IsSelected Then
                        currentPage = rasterImageList1.Items.IndexOf(rasterImageList1.Items(i))
                     End If
                  Next

                  Dim objectBounds As LeadRect = RestrictZoneBoundsToPage(rasterImageViewer1.Image, BoundsFromAnnotations(TryCast(e.[Object], AnnObject)))

                  Dim bounds As New LeadRect(objectBounds.X, objectBounds.Y, objectBounds.Width, objectBounds.Height)

                  Dim fields As List(Of FormField) = GetOmrFormFields()

                  Dim singleSelectionField As SingleSelectionField = GetCurrentMasterForm().CreateSingleSelectionField(fields, bounds, currentPage + 1)

                  If singleSelectionField Is Nothing Then
                     automation.Container.Children.Remove(newObject)
                     rasterImageViewer1.Invalidate()
                     Return
                  End If

                  newObject.Tag = singleSelectionField
                  singleSelectionField.Tag = newObject

                  If [String].IsNullOrEmpty(singleSelectionField.Name) Then
                     singleSelectionField.Name = GetFreeFieldName()
                  End If

                  SingleSelectionFieldDisplay(singleSelectionField)

                  Dim dlg As New SingleSelectionFieldDlg(Me, singleSelectionField)
                  If dlg.ShowDialog() = DialogResult.Cancel Then
                     For i As Integer = automation.Container.Children.Count - 1 To 0 Step -1
                        If automation.Container.Children(i).Tag Is singleSelectionField Then
                           automation.Container.Children.RemoveAt(i)
                        End If
                     Next
                     rasterImageViewer1.Invalidate()

                     Return
                  End If

                  If Not _lbSelection.Items.Contains(singleSelectionField.Name) Then
                     _lbSelection.Items.Add(singleSelectionField.Name)
                  End If

                  automation.Container.Children.BringToFront(CType(singleSelectionField.Tag, AnnObject), True)

                  DisableInteractiveModes()
                  rasterImageViewer1.InteractiveModes.EnableById(_automationInteractiveMode.Id)
                  rasterImageViewer1.Invalidate()

                  _lbSelection.SelectedIndex = _lbSelection.Items.IndexOf(singleSelectionField.Name)

                  UpdateControls()

                  Return
               End If
            ElseIf newObject.HiliteColor = "Pink" Then
               If newObject.Tag Is Nothing Then
                  Dim newRectObject As New AnnRectangleObject(newObject.Bounds)

                  Dim st As String = New ColorConverter().ConvertToString(Color.FromArgb(93, 255, 192, 203))
                  newRectObject.Fill = AnnSolidColorBrush.Create(st)
                  newRectObject.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Red"), New LeadLengthD(2))

                  automation.Container.Children.Add(newRectObject)
                  automation.Container.Children.Remove(newObject)

                  Dim currentPage As Integer = 0
                  For i As Integer = 0 To rasterImageList1.Items.Count - 1
                     If rasterImageList1.Items(i).IsSelected Then
                        currentPage = rasterImageList1.Items.IndexOf(rasterImageList1.Items(i))
                     End If
                  Next

                  Dim objectBounds As LeadRect = RestrictZoneBoundsToPage(rasterImageViewer1.Image, BoundsFromAnnotations(TryCast(e.[Object], AnnObject)))

                  Dim bounds As New LeadRect(objectBounds.X, objectBounds.Y, objectBounds.Width, objectBounds.Height)

                  Dim fields As List(Of FormField) = GetOmrFormFields()

                  Dim bubbleWordField As BubbleWordField = GetCurrentMasterForm().CreateBubbleWordField(rasterImageList1.Image, fields, bounds, currentPage + 1)

                  If bubbleWordField IsNot Nothing Then
                     bubbleWordField.Name = GetFreeFieldName()
                     bubbleWordField.Tag = newRectObject
                     newRectObject.Tag = bubbleWordField

                     If Not _lbBubble.Items.Contains(bubbleWordField.Name) Then
                        _lbBubble.Items.Add(bubbleWordField.Name)
                     End If

                     BubbleWordFieldDisplay(bubbleWordField)

                     Dim dlg As New BubbleWordFieldDlg(Me, bubbleWordField)
                     If dlg.ShowDialog() = DialogResult.Cancel Then
                        RemoveBubble(bubbleWordField)
                     Else
                        automation.Container.Children.BringToFront(TryCast(bubbleWordField.Tag, AnnObject), True)
                     End If
                  Else
                     automation.Container.Children.Remove(newRectObject)
                  End If

                  DisableInteractiveModes()
                  rasterImageViewer1.InteractiveModes.EnableById(_automationInteractiveMode.Id)
                  rasterImageViewer1.Invalidate()

                  UpdateControls()

                  Return
               End If

#If LEADTOOLS_V20_OR_LATER Then
            ElseIf newObject.HiliteColor = "Aqua" Then
               If newObject.Tag Is Nothing Then
                  Dim newRectObject As New AnnRectangleObject(newObject.Bounds)

                  Dim st As String = New ColorConverter().ConvertToString(Color.FromArgb(93, 255, 192, 203))
                  newRectObject.Fill = AnnSolidColorBrush.Create(st)
                  newRectObject.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Red"), New LeadLengthD(2))

                  automation.Container.Children.Add(newRectObject)
                  automation.Container.Children.Remove(newObject)

                  Dim currentPage As Integer = 0
                  For i As Integer = 0 To rasterImageList1.Items.Count - 1
                     If rasterImageList1.Items(i).IsSelected Then
                        currentPage = rasterImageList1.Items.IndexOf(rasterImageList1.Items(i))
                     End If
                  Next

                  Dim objectBounds As LeadRect = RestrictZoneBoundsToPage(rasterImageViewer1.Image, BoundsFromAnnotations(TryCast(e.[Object], AnnObject)))

                  Dim bounds As New LeadRect(objectBounds.X, objectBounds.Y, objectBounds.Width, objectBounds.Height)

                  Dim fields As List(Of FormField) = GetOmrFormFields()

                  Dim answerAreaField As OmrAnswerAreaField = GetCurrentMasterForm().CreateAnswerAreaField(rasterImageList1.Image, fields, bounds, currentPage + 1)

                  If answerAreaField IsNot Nothing Then
                     answerAreaField.Name = GetFreeFieldName()
                     answerAreaField.Tag = newRectObject
                     newRectObject.Tag = answerAreaField

                     For Each field As SingleSelectionField In answerAreaField.Answers
                        field.Parent = answerAreaField.Name
                     Next

                     If Not _lbAnswerArea.Items.Contains(answerAreaField.Name) Then
                        _lbAnswerArea.Items.Add(answerAreaField.Name)
                     End If

                     AnswerAreaFieldDisplay(answerAreaField)

                     Dim dlg As New OmrAnswerAreaFieldDlg(Me, answerAreaField)
                     If dlg.ShowDialog() = DialogResult.Cancel Then
                        RemoveAnswerAreaField(answerAreaField)
                     Else
                        automation.Container.Children.BringToFront(TryCast(answerAreaField.Tag, AnnObject), True)
                     End If
                  Else
                     automation.Container.Children.Remove(newRectObject)
                  End If

                  DisableInteractiveModes()
                  rasterImageViewer1.InteractiveModes.EnableById(_automationInteractiveMode.Id)
                  rasterImageViewer1.Invalidate()

                  UpdateControls()

                  Return
               End If
            ElseIf newObject.HiliteColor = "DeepPink" Then
               If newObject.Tag Is Nothing Then
                  Dim newRectObject As New AnnRectangleObject(newObject.Bounds)

                  Dim st As String = New ColorConverter().ConvertToString(Color.FromArgb(93, 255, 192, 203))
                  newRectObject.Fill = AnnSolidColorBrush.Create(st)
                  newRectObject.Stroke = AnnStroke.Create(AnnSolidColorBrush.Create("Red"), New LeadLengthD(2))

                  automation.Container.Children.Add(newRectObject)
                  automation.Container.Children.Remove(newObject)

                  Dim currentPage As Integer = 0
                  For i As Integer = 0 To rasterImageList1.Items.Count - 1
                     If rasterImageList1.Items(i).IsSelected Then
                        currentPage = rasterImageList1.Items.IndexOf(rasterImageList1.Items(i))
                     End If
                  Next

                  Dim objectBounds As LeadRect = RestrictZoneBoundsToPage(rasterImageViewer1.Image, BoundsFromAnnotations(TryCast(e.[Object], AnnObject)))

                  Dim bounds As New LeadRect(objectBounds.X, objectBounds.Y, objectBounds.Width, objectBounds.Height)

                  Dim fields As List(Of FormField) = GetOmrFormFields()

                  Dim omrDateField As OmrDateField = GetCurrentMasterForm().CreateOmrDateField(rasterImageList1.Image, fields, bounds, currentPage + 1)

                  If omrDateField IsNot Nothing Then
                     omrDateField.Name = GetFreeFieldName()
                     omrDateField.Tag = newRectObject
                     newRectObject.Tag = omrDateField

                     SetOmrDateParentName(omrDateField)

                     If Not _lbOmrDate.Items.Contains(omrDateField.Name) Then
                        _lbOmrDate.Items.Add(omrDateField.Name)
                     End If

                     OmrDateFieldDisplay(omrDateField)

                     Dim dlg As New OmrDateFieldDlg(Me, omrDateField)
                     If dlg.ShowDialog() = DialogResult.Cancel Then
                        RemoveOmrDateField(omrDateField)
                     Else
                        automation.Container.Children.BringToFront(TryCast(omrDateField.Tag, AnnObject), True)
                     End If
                  Else
                     automation.Container.Children.Remove(newRectObject)
                  End If

                  DisableInteractiveModes()
                  rasterImageViewer1.InteractiveModes.EnableById(_automationInteractiveMode.Id)
                  rasterImageViewer1.Invalidate()

                  UpdateControls()

                  Return
               End If
#End If
            End If

            newField.Name = GetFreeFieldName()

            Dim newBounds As LeadRect = RestrictZoneBoundsToPage(rasterImageViewer1.Image, BoundsFromAnnotations(TryCast(e.[Object], AnnObject)))
            'Convert to rectangle to get whole number for pixel value

            newField.Bounds = New LeadRect(newBounds.X, newBounds.Y, newBounds.Width, newBounds.Height)

            newObject.Tag = newField

            Dim tableField As TableFormField = TryCast(newField, TableFormField)
            If tableField IsNot Nothing Then
               'add two columns to new table field
               Dim column1 As New TextFormField()
               column1.Name = "Column1"
               column1.Bounds = New LeadRect(0, 0, CInt(tableField.Bounds.Width / 2), tableField.Bounds.Height)
               CType(tableField, TableFormField).Columns.Add(New TableColumn(column1))
               Dim column2 As New TextFormField()
               column2.Name = "Column2"
               column2.Bounds = New LeadRect(CInt(tableField.Bounds.Width / 2), 0, CInt(tableField.Bounds.Width / 2), tableField.Bounds.Height)
               CType(tableField, TableFormField).Columns.Add(New TableColumn(column2))

               tableField.Tag = newObject
               AlignmentTableFields(tableField)
               UpdateTable(tableField)
            End If

            Dim UnStructuredTextField As UnStructuredTextFormField = TryCast(newField, UnStructuredTextFormField)
            If UnStructuredTextField IsNot Nothing Then
               UnStructuredTextField.TextFormField.Bounds = New LeadRect(CInt(UnStructuredTextField.Bounds.Width / 2), 0, CInt(UnStructuredTextField.Bounds.Width / 2), UnStructuredTextField.Bounds.Height)
               UnStructuredTextField.Tag = newObject

               UnStructuredTextFormFieldDisplay(UnStructuredTextField)
            End If

            _lbFields.Items.Add(newField.Name)
            _lbFields.SelectedIndex = _lbFields.Items.IndexOf(newField.Name)

            _lbSelection.SelectedIndex = -1
            _lbBubble.SelectedIndex = -1
#If LEADTOOLS_V20_OR_LATER Then
            _lbAnswerArea.SelectedIndex = -1
            _lbOmrDate.SelectedIndex = -1
#End If '#if LEADTOOLS_V20_OR_LATER

         Catch exp As Exception
            Messager.ShowError(Me, exp)
         End Try

         isFieldDirty = True
         UpdateControls()
      End If
   End Sub

   Private Sub DeleteMultipleOmrFields()
      Dim annObject As AnnSelectionObject = TryCast(automation.CurrentEditObject, AnnSelectionObject)
      If annObject Is Nothing Then
         Return
      End If

      If Messager.ShowQuestion(Me, "This will permanently delete the selected Omr fields. Are you sure you want to continue?", MessageBoxButtons.YesNo) = DialogResult.No Then
         Return
      End If

      Dim objectsToDelete As New List(Of AnnObject)(annObject.SelectedObjects)

      For j As Integer = 0 To objectsToDelete.Count - 1
         Dim obj As AnnObject = objectsToDelete(j)
         Dim currentField As FormField = TryCast(obj.Tag, FormField)
         _lbFields.SelectedItem = currentField.Name

         DeleteSelectedField()
      Next

      rasterImageViewer1.Invalidate()
      isFieldDirty = True
      UpdateControls()
   End Sub

   Public Sub ApplyRenameMultipleFields(omrFieldsNames As List(Of String))
      Dim annObject As AnnSelectionObject = TryCast(automation.CurrentEditObject, AnnSelectionObject)
      If annObject Is Nothing Then
         Return
      End If

      Dim index As Integer = 0

      For j As Integer = 0 To annObject.SelectedObjects.Count - 1
         Dim obj As AnnObject = annObject.SelectedObjects(j)
         Dim currentField As FormField = TryCast(obj.Tag, FormField)
         _lbFields.SelectedItem = currentField.Name

         If TryCast(obj.Tag, FormField).Name = _lbFields.Text Then
            currentField.Name = omrFieldsNames(index)
            isFieldDirty = True
            _lbFields.Items(_lbFields.SelectedIndex) = omrFieldsNames(index)

            index += 1
         End If
      Next
   End Sub

   Public Sub ApplySetOmrSensitivity(sensitivity As OcrOmrSensitivity)
      Dim annObject As AnnSelectionObject = TryCast(automation.CurrentEditObject, AnnSelectionObject)
      If annObject Is Nothing Then
         Return
      End If

      For j As Integer = 0 To annObject.SelectedObjects.Count - 1
         Dim obj As AnnObject = annObject.SelectedObjects(j)
         Dim currentField As OmrFormField = TryCast(obj.Tag, OmrFormField)
         _lbFields.SelectedItem = currentField.Name

         If currentField.Name = _lbFields.Text Then
            currentField.Sensitivity = sensitivity
            isFieldDirty = True
         End If
      Next
   End Sub

   Private Sub automation_CurrentDesignerChanged(sender As Object, e As EventArgs)
      If TypeOf automation.CurrentDesigner Is AnnSelectionEditDesigner Then
         If _currentSelectMode = SelectMultiFieldsMode.None Then
            Return
         End If

         Dim annObject__1 As AnnSelectionObject = TryCast(automation.CurrentEditObject, AnnSelectionObject)
         If annObject__1 Is Nothing Then
            Return
         End If

         For Each field As AnnObject In annObject__1.SelectedObjects
            If field.Tag IsNot Nothing AndAlso Not (TypeOf field.Tag Is OmrFormField) Then
               Messager.ShowInformation(Me, "Select OMR fields only.")
               Return
            End If
         Next
         Dim result As DialogResult = DialogResult.None

         If _currentSelectMode = SelectMultiFieldsMode.ChangeSensitivity Then
            RemoveHandler _lbFields.SelectedIndexChanged, AddressOf _lbFields_SelectedIndexChanged

            Dim omrSensitivityDlg As New OmrSensitivityDialog(Me, annObject__1.SelectedObjects)
            result = omrSensitivityDlg.ShowDialog()

            AddHandler _lbFields.SelectedIndexChanged, AddressOf _lbFields_SelectedIndexChanged
         ElseIf _currentSelectMode = SelectMultiFieldsMode.RenameFields Then
            RemoveHandler _lbFields.SelectedIndexChanged, AddressOf _lbFields_SelectedIndexChanged

            Dim renameOmrFieldsDlg As New RenameOmrFieldsDlg(Me, annObject__1.SelectedObjects.Count)
            result = renameOmrFieldsDlg.ShowDialog()

            AddHandler _lbFields.SelectedIndexChanged, AddressOf _lbFields_SelectedIndexChanged
         ElseIf _currentSelectMode = SelectMultiFieldsMode.DeleteFields Then
            DeleteMultipleOmrFields()
         End If

         _currentSelectMode = SelectMultiFieldsMode.None

         If result = DialogResult.OK Then
            isFieldDirty = True
         End If

         DisableInteractiveModes()
         rasterImageViewer1.InteractiveModes.EnableById(_automationInteractiveMode.Id)
         automation.Manager.CurrentObjectId = AnnObject.None

         Return
      End If

      If automation.CurrentDesigner IsNot Nothing AndAlso TypeOf automation.CurrentDesigner Is AnnTextEditDesigner Then
         Dim textDesigner As AnnTextEditDesigner = TryCast(automation.CurrentDesigner, AnnTextEditDesigner)
         AddHandler textDesigner.EditText, AddressOf textDesigner_EditText
      End If

      If automation.CurrentEditObject IsNot Nothing Then
         CheckHighLevelMenuItem(Nothing)
         Dim annObject As AnnObject = automation.CurrentEditObject
         If TypeOf annObject.Tag Is SingleSelectionField Then
            Dim field As SingleSelectionField = TryCast(annObject.Tag, SingleSelectionField)
            _lbSelection.SelectedItem = field.Name
         ElseIf TypeOf annObject.Tag Is BubbleWordField Then
            Dim field As BubbleWordField = TryCast(annObject.Tag, BubbleWordField)
            _lbBubble.SelectedItem = field.Name
#If LEADTOOLS_V20_OR_LATER Then
         ElseIf TypeOf annObject.Tag Is OmrAnswerAreaField Then
            Dim field As OmrAnswerAreaField = TryCast(annObject.Tag, OmrAnswerAreaField)
            _lbAnswerArea.SelectedItem = field.Name
         ElseIf TypeOf annObject.Tag Is OmrDateField Then
            Dim field As OmrDateField = TryCast(annObject.Tag, OmrDateField)
            _lbOmrDate.SelectedItem = field.Name
#End If
         ElseIf TypeOf annObject.Tag Is FormField Then
            Dim field As FormField = TryCast(annObject.Tag, FormField)
            _lbFields.SelectedItem = field.Name
         End If
      End If
   End Sub

   Private Sub automation_SetCursor(sender As Object, e As AnnCursorEventArgs)
      If Not _automationInteractiveMode.IsEnabled Then
         Return
      End If

      Dim automation As AnnAutomation = TryCast(sender, AnnAutomation)
      Dim newCursor As Cursor = Nothing

      Select Case e.DesignerType
         Case AnnDesignerType.Draw
            If True Then
               Dim allow As Boolean = True

               Dim drawDesigner As AnnDrawDesigner = TryCast(automation.CurrentDesigner, AnnDrawDesigner)
               If drawDesigner IsNot Nothing AndAlso Not drawDesigner.IsTargetObjectAdded AndAlso e.PointerEvent IsNot Nothing Then
                  ' See if we can draw or not
                  Dim container As AnnContainer = automation.ActiveContainer

                  allow = False

                  If automation.HitTestContainer(e.PointerEvent.Location, False) IsNot Nothing Then
                     allow = True
                  End If
               End If

               If allow Then
                  Dim annAutomationObject As AnnAutomationObject = automation.Manager.FindObjectById(e.Id)
                  If annAutomationObject IsNot Nothing Then
                     newCursor = TryCast(annAutomationObject.DrawCursor, Cursor)
                  End If
               Else
                  newCursor = Cursors.No
               End If
            End If
            Exit Select

         Case AnnDesignerType.Edit
            If True Then
               If e.IsRotateCenter Then
                  newCursor = AutomationManagerHelper.AutomationCursors(CursorType.RotateCenterControlPoint)
               ElseIf e.IsRotateGripper Then
                  newCursor = AutomationManagerHelper.AutomationCursors(CursorType.RotateGripperControlPoint)
               ElseIf e.ThumbIndex < 0 Then
                  If e.DragDropEvent IsNot Nothing AndAlso Not e.DragDropEvent.Allowed Then
                     newCursor = Cursors.No
                  Else
                     newCursor = AutomationManagerHelper.AutomationCursors(CursorType.SelectedObject)
                  End If
               Else
                  newCursor = AutomationManagerHelper.AutomationCursors(CursorType.ControlPoint)
               End If

            End If
            Exit Select

         Case AnnDesignerType.Run
            If True Then
               newCursor = AutomationManagerHelper.AutomationCursors(CursorType.Run)
            End If
            Exit Select
         Case Else

            newCursor = AutomationManagerHelper.AutomationCursors(CursorType.SelectObject)
            Exit Select

      End Select

      If rasterImageViewer1.Cursor <> newCursor Then
         rasterImageViewer1.Cursor = newCursor
      End If
   End Sub

   Private Sub automation_RestoreCursor(sender As Object, e As EventArgs)
      If rasterImageViewer1.Cursor <> Cursors.[Default] Then
         rasterImageViewer1.Cursor = Cursors.[Default]
      End If
   End Sub

   Private Sub textDesigner_EditText(sender As Object, e As AnnEditTextEventArgs)
      Dim text As New TextBox()
      Dim rc As New Rectangle(CInt(e.Bounds.Left), CInt(e.Bounds.Top), CInt(e.Bounds.Width), CInt(e.Bounds.Height))
      rc.Inflate(12, 12)
      text.Location = rc.Location
      text.Size = rc.Size
      text.AutoSize = False
      text.Tag = e.TextObject
      text.Text = e.TextObject.Text
      text.ForeColor = Color.FromName(TryCast(e.TextObject.TextForeground, AnnSolidColorBrush).Color)
      text.Font = AnnWinFormsRenderingEngine.ToFont(e.TextObject.Font)
      text.WordWrap = False
      text.AcceptsReturn = True
      text.Multiline = True
      text.Tag = e.TextObject

      AddHandler text.LostFocus, AddressOf text_LostFocus
      rasterImageViewer1.Controls.Add(text)
      text.Focus()
      text.SelectAll()
   End Sub

   Private Sub text_LostFocus(sender As Object, e As EventArgs)
      Dim textObject As TextBox = TryCast(sender, TextBox)
      If textObject IsNot Nothing And TypeOf getSelectedField() Is TableFormField Then
         Dim tableField As TableFormField = TryCast(automation.CurrentEditObject.Tag, TableFormField)
         Dim columnField As OcrFormField = Nothing
         For Each column As TableColumn In tableField.Columns
            If column.Tag Is automation.CurrentEditObject Then
               columnField = column.OcrField
               Exit For
            End If
         Next

         If columnField IsNot Nothing Then
            columnField.Name = textObject.Text
         End If

      End If

      rasterImageViewer1.Controls.Remove(textObject)

      updateColumnsList(TryCast(getSelectedField(), TableFormField))
      AlignmentTableFields(TryCast(getSelectedField(), TableFormField))
   End Sub

   Private Function LeadMatrixToMatrix(leadMatrix As LeadMatrix) As Matrix
      Return New Matrix(CSng(leadMatrix.M11), CSng(leadMatrix.M12), CSng(leadMatrix.M21), CSng(leadMatrix.M22), CSng(leadMatrix.OffsetX), CSng(leadMatrix.OffsetY))
   End Function

   Private Function GetCurrentMasterForm() As DiskMasterForm
      'get currently selected master form
      If _tvMasterForms.SelectedNode Is Nothing Then
         Return Nothing
      End If

      Dim type As Type = _tvMasterForms.SelectedNode.Tag.[GetType]()
      If type IsNot GetType(DiskMasterForm) Then
         Return Nothing
      End If

      Return CType(_tvMasterForms.SelectedNode.Tag, DiskMasterForm)
   End Function

   Private Sub _lbFields_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _lbFields.SelectedIndexChanged

      Try

         If rasterImageList1.Items.Count > 0 AndAlso _lbFields.SelectedIndex <> -1 Then
            Dim selectedObject As AnnObject = automation.CurrentEditObject

            'New field in listbox. 
            For i As Integer = 0 To automation.Container.Children.Count - 1
               If TypeOf automation.Container.Children(i).Tag Is FormField AndAlso Not (TypeOf automation.Container.Children(i).Tag Is SingleSelectionField) Then
                  If TryCast(automation.Container.Children(i).Tag, FormField).Name = _lbFields.Text Then
                     selectedObject = automation.Container.Children(i)
                     'Select correct annotation if it is not already selected
                     If automation.CurrentEditObject IsNot selectedObject Then
                        automation.SelectObject(selectedObject)
                     End If
                     Exit For
                  End If
               End If
            Next


            'Update UI properties
            'Temporarily disable events
            RemoveHandler _txtFieldName.TextChanged, AddressOf _txtFieldName_TextChanged
            RemoveHandler _cmbFieldType.SelectedIndexChanged, AddressOf _cmbFieldType_SelectedIndexChanged
            RemoveHandler _chkEnableIcr.CheckedChanged, AddressOf _chkOCRMethod_CheckedChanged
            RemoveHandler _chkEnableOcr.CheckedChanged, AddressOf _chkOCRMethod_CheckedChanged
            RemoveHandler _chkDropoutCells.CheckedChanged, AddressOf _chkDropoutCells_CheckedChanged
            RemoveHandler _chkDropoutWords.CheckedChanged, AddressOf _chkDropoutWords_CheckedChanged
            RemoveHandler _rbTextTypeChar.CheckedChanged, AddressOf _rbTextType_CheckedChanged
            RemoveHandler _rbtextTypeNum.CheckedChanged, AddressOf _rbTextType_CheckedChanged
            RemoveHandler _rbtextTypeData.CheckedChanged, AddressOf _rbTextType_CheckedChanged
            RemoveHandler _rbOMRWithFrame.CheckedChanged, AddressOf _rbOMRFrame_CheckedChanged
            RemoveHandler _rbOMRWithoutFrame.CheckedChanged, AddressOf _rbOMRFrame_CheckedChanged
            RemoveHandler _rbOMRAutoFrame.CheckedChanged, AddressOf _rbOMRFrame_CheckedChanged
            RemoveHandler _rbOMRSensitivityLowest.CheckedChanged, AddressOf _rbOMRSensitivity_CheckedChanged
            RemoveHandler _rbOMRSensitivityLow.CheckedChanged, AddressOf _rbOMRSensitivity_CheckedChanged
            RemoveHandler _rbOMRSensitivityHigh.CheckedChanged, AddressOf _rbOMRSensitivity_CheckedChanged
            RemoveHandler _rbOMRSensitivityHighest.CheckedChanged, AddressOf _rbOMRSensitivity_CheckedChanged

            Dim currentField As FormField = TryCast(selectedObject.Tag, FormField)
            Dim fieldType As Type = currentField.[GetType]()
            _txtFieldHeight.Text = currentField.Bounds.Height.ToString()
            _txtFieldWidth.Text = currentField.Bounds.Width.ToString()
            _txtFieldLeft.Text = currentField.Bounds.Left.ToString()
            _txtFieldTop.Text = currentField.Bounds.Top.ToString()
            _txtFieldName.Text = currentField.Name
            _gbFieldMethod.Enabled = fieldType Is GetType(TextFormField) Or fieldType Is GetType(UnStructuredTextFormField)
            _gbFieldTextType.Enabled = fieldType Is GetType(TextFormField) Or fieldType Is GetType(UnStructuredTextFormField)
            _gbOMRFrame.Enabled = fieldType Is GetType(OmrFormField)
            _gbOMRSensitivity.Enabled = fieldType Is GetType(OmrFormField)
            _tpTable.Enabled = fieldType Is GetType(TableFormField)
            _lbSelection.SelectedIndex = -1
            _lbBubble.SelectedIndex = -1
#If LEADTOOLS_V20_OR_LATER Then
            _lbAnswerArea.SelectedIndex = -1
            _lbOmrDate.SelectedIndex = -1
#End If '#if LEADTOOLS_V20_OR_LATER

            _cmbFieldType.Enabled = True

            If fieldType Is GetType(TextFormField) Then
               Dim textField As TextFormField = TryCast(currentField, TextFormField)
               _cmbFieldType.SelectedIndex = _cmbFieldType.Items.IndexOf("Text")

               _chkEnableIcr.Checked = textField.EnableIcr
               _chkEnableOcr.Checked = textField.EnableOcr
               _rbTextTypeChar.Checked = (textField.Type = TextFieldType.Character)
               _rbtextTypeNum.Checked = (textField.Type = TextFieldType.Numerical)
               _rbtextTypeData.Checked = (textField.Type = TextFieldType.Data)
               _chkDropoutCells.Checked = (textField.Dropout And DropoutFlag.CellsDropout) = DropoutFlag.CellsDropout
               _chkDropoutWords.Checked = (textField.Dropout And DropoutFlag.WordsDropout) = DropoutFlag.WordsDropout
            ElseIf fieldType Is GetType(OmrFormField) Then
               Dim omrField As OmrFormField = TryCast(currentField, OmrFormField)
               _cmbFieldType.SelectedIndex = _cmbFieldType.Items.IndexOf("Omr")

               _rbOMRWithFrame.Checked = omrField.FrameMethod = OcrOmrFrameDetectionMethod.WithFrame
               _rbOMRWithoutFrame.Checked = omrField.FrameMethod = OcrOmrFrameDetectionMethod.WithoutFrame
               _rbOMRAutoFrame.Checked = omrField.FrameMethod = OcrOmrFrameDetectionMethod.Auto
               _rbOMRSensitivityLowest.Checked = omrField.Sensitivity = OcrOmrSensitivity.Lowest
               _rbOMRSensitivityLow.Checked = omrField.Sensitivity = OcrOmrSensitivity.Low
               _rbOMRSensitivityHigh.Checked = omrField.Sensitivity = OcrOmrSensitivity.High
               _rbOMRSensitivityHighest.Checked = omrField.Sensitivity = OcrOmrSensitivity.Highest

            ElseIf fieldType Is GetType(ImageFormField) Then
               Dim imageField As ImageFormField = TryCast(currentField, ImageFormField)
               _cmbFieldType.SelectedIndex = _cmbFieldType.Items.IndexOf("Image")

            ElseIf fieldType Is GetType(BarcodeFormField) Then
               Dim barcodeField As BarcodeFormField = TryCast(currentField, BarcodeFormField)
               _cmbFieldType.SelectedIndex = _cmbFieldType.Items.IndexOf("Barcode")

            ElseIf fieldType Is GetType(TableFormField) Then
               _cmbFieldType.Enabled = False
               _cmbFieldType.SelectedIndex = _cmbFieldType.Items.IndexOf("Table")
            ElseIf fieldType Is GetType(UnStructuredTextFormField) Then
               Dim textField As UnStructuredTextFormField = TryCast(currentField, UnStructuredTextFormField)
               _cmbFieldType.SelectedIndex = _cmbFieldType.Items.IndexOf("UnStructured Text")

               _chkEnableIcr.Checked = textField.TextFormField.EnableIcr
               _chkEnableOcr.Checked = textField.TextFormField.EnableOcr
               _rbTextTypeChar.Checked = (textField.TextFormField.Type = TextFieldType.Character)
               _rbtextTypeNum.Checked = (textField.TextFormField.Type = TextFieldType.Numerical)
               _rbtextTypeData.Checked = (textField.TextFormField.Type = TextFieldType.Data)
               _chkDropoutCells.Checked = (textField.Dropout And DropoutFlag.CellsDropout) = DropoutFlag.CellsDropout
               _chkDropoutWords.Checked = (textField.Dropout And DropoutFlag.WordsDropout) = DropoutFlag.WordsDropout
            End If

            AddHandler _txtFieldName.TextChanged, AddressOf _txtFieldName_TextChanged
            AddHandler _cmbFieldType.SelectedIndexChanged, AddressOf _cmbFieldType_SelectedIndexChanged
            AddHandler _chkEnableIcr.CheckedChanged, AddressOf _chkOCRMethod_CheckedChanged
            AddHandler _chkEnableOcr.CheckedChanged, AddressOf _chkOCRMethod_CheckedChanged
            AddHandler _chkDropoutCells.CheckedChanged, AddressOf _chkDropoutCells_CheckedChanged
            AddHandler _chkDropoutWords.CheckedChanged, AddressOf _chkDropoutWords_CheckedChanged
            AddHandler _rbTextTypeChar.CheckedChanged, AddressOf _rbTextType_CheckedChanged
            AddHandler _rbtextTypeNum.CheckedChanged, AddressOf _rbTextType_CheckedChanged
            AddHandler _rbtextTypeData.CheckedChanged, AddressOf _rbTextType_CheckedChanged
            AddHandler _rbOMRWithFrame.CheckedChanged, AddressOf _rbOMRFrame_CheckedChanged
            AddHandler _rbOMRWithoutFrame.CheckedChanged, AddressOf _rbOMRFrame_CheckedChanged
            AddHandler _rbOMRAutoFrame.CheckedChanged, AddressOf _rbOMRFrame_CheckedChanged
            AddHandler _rbOMRSensitivityLowest.CheckedChanged, AddressOf _rbOMRSensitivity_CheckedChanged
            AddHandler _rbOMRSensitivityLow.CheckedChanged, AddressOf _rbOMRSensitivity_CheckedChanged
            AddHandler _rbOMRSensitivityHigh.CheckedChanged, AddressOf _rbOMRSensitivity_CheckedChanged
            AddHandler _rbOMRSensitivityHighest.CheckedChanged, AddressOf _rbOMRSensitivity_CheckedChanged
         End If
      Catch exp As Exception
         Messager.ShowError(Me, exp)
      End Try
      UpdateControls()
   End Sub

   Private Sub rasterImageList1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles rasterImageList1.SelectedItemsChanged
      If Not CheckForUnsavedChanges() Then
         'Temporarily disable event
         RemoveHandler rasterImageList1.SelectedItemsChanged, AddressOf rasterImageList1_SelectedIndexChanged
         rasterImageList1.Items(0).IsSelected = False
         rasterImageList1.Items(oldSelectedPageIndex).IsSelected = True
         AddHandler rasterImageList1.SelectedItemsChanged, AddressOf rasterImageList1_SelectedIndexChanged
         rasterImageList1.Refresh()
         Return
      End If

      If rasterImageList1.Items.Count > 0 Then
         For i As Integer = 0 To rasterImageList1.Items.Count - 1
            If rasterImageList1.Items(i).IsSelected Then
               oldSelectedPageIndex = rasterImageList1.Items.IndexOf(rasterImageList1.Items(i))
            End If
         Next
      Else
         oldSelectedPageIndex = -1
      End If

      'Clear viewer
      If rasterImageViewer1.Image IsNot Nothing AndAlso Not rasterImageViewer1.Image.IsDisposed Then
         rasterImageViewer1.Image.Dispose()
         rasterImageViewer1.Image = Nothing
      End If

      If rasterImageList1.Items.Count <> 0 Then
         'Copy selected image in list to main viewer
         For i As Integer = 0 To rasterImageList1.Items.Count - 1
            If rasterImageList1.Items(i).IsSelected Then
               rasterImageViewer1.Image = rasterImageList1.Items(i).Image.Clone()

               'when setting container size we should have identity trasnform for the viewer
               Dim useDpi As Boolean = rasterImageViewer1.UseDpi
               Dim sizeMode As ControlSizeMode = rasterImageViewer1.SizeMode

               rasterImageViewer1.UseDpi = False
               rasterImageViewer1.Zoom(ControlSizeMode.ActualSize, 1, rasterImageViewer1.DefaultZoomOrigin)

               'update annotations container size based on selected image size
               automation.Container.Size = automation.Container.Mapper.SizeToContainerCoordinates(LeadSizeD.Create(rasterImageViewer1.Image.Width, rasterImageViewer1.Image.Height))
               'restore use dpi value
               rasterImageViewer1.UseDpi = useDpi
               rasterImageViewer1.Zoom(sizeMode, 1, rasterImageViewer1.DefaultZoomOrigin)
            End If

         Next
      End If
      BuildFieldList()
      UpdatePageType()
   End Sub

   Private Sub UpdateControls()
      'Fields
      _lbFields.Enabled = Not regionMode
      _tsFields.Enabled = (Not regionMode)

      _chkEnableIcr.Enabled = (_tcFieldProps.Enabled AndAlso ocrEngine.EngineType <> OcrEngineType.LEAD)
      _btnApply.Enabled = Not regionMode AndAlso isFieldDirty
      _btnCutField.Enabled = _lbFields.SelectedIndex <> -1 AndAlso Not (TypeOf automation.CurrentEditObject Is AnnTextObject)
      _btnCopyField.Enabled = _lbFields.SelectedIndex <> -1 AndAlso Not (TypeOf automation.CurrentEditObject Is AnnTextObject)
      _btnPasteField.Enabled = automation.CanPaste AndAlso rasterImageList1.Items.Count > 0
      _btnDeleteField.Enabled = _lbFields.SelectedIndex <> -1


#If LEADTOOLS_V20_OR_LATER Then
      If automation.CurrentEditObject IsNot Nothing AndAlso (TryCast(automation.CurrentEditObject.Tag, SingleSelectionField) IsNot Nothing OrElse TryCast(automation.CurrentEditObject.Tag, BubbleWordField) IsNot Nothing OrElse TryCast(automation.CurrentEditObject.Tag, OmrAnswerAreaField) IsNot Nothing OrElse TryCast(automation.CurrentEditObject.Tag, OmrDateField) IsNot Nothing) Then
#Else
      If automation.CurrentEditObject IsNot Nothing AndAlso (TryCast(automation.CurrentEditObject.Tag, SingleSelectionField) IsNot Nothing OrElse TryCast(automation.CurrentEditObject.Tag, BubbleWordField) IsNot Nothing) Then
#End If '#if LEADTOOLS_V20_OR_LATER
         _tcFieldProps.Enabled = (Not regionMode)
         For Each tab As TabPage In _tcFieldProps.TabPages
#If LEADTOOLS_V20_OR_LATER Then
            If tab IsNot _tpSelection AndAlso tab IsNot _tpBubble AndAlso tab IsNot _tpAnswerArea AndAlso tab IsNot _tpOmrDate Then
#Else
            If tab IsNot _tpSelection AndAlso tab IsNot _tpBubble Then
#End If '#if LEADTOOLS_V20_OR_LATER
               TryCast(tab, Control).Enabled = False
            End If
         Next
      Else
         _tcFieldProps.Enabled = (Not regionMode)
         For Each tab As TabPage In _tcFieldProps.TabPages
#If LEADTOOLS_V20_OR_LATER Then
            If tab IsNot _tpSelection AndAlso tab IsNot _tpBubble AndAlso tab IsNot _tpAnswerArea AndAlso tab IsNot _tpOmrDate Then
#Else
            If tab IsNot _tpSelection AndAlso tab IsNot _tpBubble Then
#End If '#if LEADTOOLS_V20_OR_LATER
               TryCast(tab, Control).Enabled = _tcFieldProps.Enabled AndAlso _lbFields.SelectedIndex <> -1
            End If
         Next
      End If

      Dim tableField As TableFormField = TryCast(getSelectedField(), TableFormField)
      If tableField IsNot Nothing Then
         _tcFieldProps.Enabled = Not regionMode
      End If
      _tpTable.Enabled = Not regionMode AndAlso (tableField IsNot Nothing)
      updateColumnsList(tableField)

      'Main menu and image buttons
      _menuItemFile.Enabled = Not regionMode
      _menuItemOptions.Enabled = Not regionMode
      _menuItemHelp.Enabled = Not regionMode
      _tsForms.Enabled = Not regionMode
      _menuItemSaveChanges.Enabled = isFieldDirty
      _menuItemMasterFormPropsMain.Enabled = InlineAssignHelper(_btnMasterFormProps.Enabled, GetCurrentMasterForm() IsNot Nothing)
      _menuItemSaveFormSetAs.Enabled = InlineAssignHelper(_btnSaveMasterFormsAs.Enabled, _tvMasterForms.Nodes.Count > 0)
      _menuItemAddMasterMain.Enabled = InlineAssignHelper(_menuItemAddMaster.Enabled, _tvMasterForms.Nodes.Count > 0)
      _menuItemDeleteMasterMain.Enabled = InlineAssignHelper(_menuItemDeleteMaster.Enabled, GetCurrentMasterForm() IsNot Nothing)
      _menuItemAddMasterPageMain.Enabled = InlineAssignHelper(_menuItemAddMasterPage.Enabled, GetCurrentMasterForm() IsNot Nothing)
      _menuItemAddMasterPageDiskMain.Enabled = InlineAssignHelper(_menuItemAddMasterPageDisk.Enabled, GetCurrentMasterForm() IsNot Nothing)
      _menuItemAddMasterPageScannerMain.Enabled = InlineAssignHelper(_menuItemAddMasterPageScanner.Enabled, (GetCurrentMasterForm() IsNot Nothing AndAlso twainSession IsNot Nothing))
      _menuItemDeleteMasterPageMain.Enabled = InlineAssignHelper(_menuItemDeleteMasterPage.Enabled, rasterImageList1.Items.Count > 0)
      _menuItemAddChildCategoryMain.Enabled = InlineAssignHelper(_menuItemAddChildCategory.Enabled, _tvMasterForms.Nodes.Count > 0)
      _menuItemDeleteChildCategoryMain.Enabled = InlineAssignHelper(_menuItemDeleteChildCategory.Enabled, (_tvMasterForms.SelectedNode IsNot Nothing AndAlso _tvMasterForms.SelectedNode.Tag.[GetType]() Is GetType(DiskMasterFormsCategory)))

      _menuItemIncludeExcludeRegions.Enabled = rasterImageList1.Items.Count > 0
      pageTypeToolStripMenuItem.Enabled = GetCurrentMasterForm() IsNot Nothing
      _miDetectOmrFields.Enabled = (If(GetPageType() = FormsPageType.Omr, True, False)) AndAlso GetCurrentMasterForm() IsNot Nothing AndAlso pageTypeToolStripMenuItem.Enabled AndAlso rasterImageList1.ActiveItem IsNot Nothing
      _miRenameOmr.Enabled = _miDetectOmrFields.Enabled
      _miSetOmrSensitivity.Enabled = _miDetectOmrFields.Enabled
      _miDeleteOmrFields.Enabled = _miDetectOmrFields.Enabled

      'Viewer toolstrip buttons
      _btnPointerTool.Enabled = (Not regionMode AndAlso rasterImageViewer1.Image IsNot Nothing)
      _btnPanTool.Enabled = (Not regionMode AndAlso rasterImageViewer1.Image IsNot Nothing)
      _btnOcrTool.Enabled = (Not regionMode AndAlso rasterImageViewer1.Image IsNot Nothing)
      _btnUNOcrTool.Enabled = (Not regionMode AndAlso rasterImageViewer1.Image IsNot Nothing)
      _btnBarcodeTool.Enabled = (Not regionMode AndAlso rasterImageViewer1.Image IsNot Nothing)
      _btnImageTool.Enabled = (Not regionMode AndAlso rasterImageViewer1.Image IsNot Nothing)
      _btnOmrTool.Enabled = (Not regionMode AndAlso rasterImageViewer1.Image IsNot Nothing)
      _btnOmrHighLevelObjects.Enabled = (Not regionMode AndAlso rasterImageViewer1.Image IsNot Nothing)
      _btnShowFields.Enabled = (Not regionMode AndAlso rasterImageViewer1.Image IsNot Nothing)
      _btnZoomDrawTool.Enabled = (Not regionMode AndAlso rasterImageViewer1.Image IsNot Nothing)
      _btnTableTool.Enabled = (Not regionMode AndAlso rasterImageViewer1.Image IsNot Nothing)
      _btnSelectRegion.Enabled = (regionMode AndAlso rasterImageViewer1.Image IsNot Nothing)

      _btnRemoveSelection.Enabled = (Not regionMode AndAlso _lbSelection.SelectedIndex <> -1)
      _btnEditSelection.Enabled = (Not regionMode AndAlso _lbSelection.SelectedIndex <> -1)
      _cbHideSelectionAnn.Enabled = (Not regionMode AndAlso _lbSelection.Items.Count > 0)

      _btnRemoveBubble.Enabled = (Not regionMode AndAlso _lbBubble.SelectedIndex <> -1)
      _btnEditBubble.Enabled = (Not regionMode AndAlso _lbBubble.SelectedIndex <> -1)
      _cbHideBubbleAnn.Enabled = (Not regionMode AndAlso _lbBubble.Items.Count > 0)

#If LEADTOOLS_V20_OR_LATER Then
      _btnRemoveAnswerArea.Enabled = (Not regionMode AndAlso _lbAnswerArea.SelectedIndex <> -1)
      _btnEditAnswerArea.Enabled = (Not regionMode AndAlso _lbAnswerArea.SelectedIndex <> -1)
      _cbHideAnswerAnn.Enabled = (Not regionMode AndAlso _lbAnswerArea.Items.Count > 0)

      _btnRemoveOmrDate.Enabled = (Not regionMode AndAlso _lbOmrDate.SelectedIndex <> -1)
      _btnEditOmrDate.Enabled = (Not regionMode AndAlso _lbOmrDate.SelectedIndex <> -1)
      _cbHideOmrDateAnn.Enabled = (Not regionMode AndAlso _lbOmrDate.Items.Count > 0)
#End If

      _tvMasterForms.Enabled = Not regionMode

      rasterImageList1.Enabled = Not regionMode
      automation.DefaultCurrentObjectId = AnnObject.None

      If automation.CurrentEditObject IsNot Nothing AndAlso TypeOf automation.CurrentEditObject.Tag Is FormField Then
         Dim currentField As FormField = TryCast(automation.CurrentEditObject.Tag, FormField)
         Dim fieldType As Type = currentField.[GetType]()
         _gbFieldMethod.Enabled = fieldType Is GetType(TextFormField) OrElse fieldType Is GetType(UnStructuredTextFormField)
         _gbFieldTextType.Enabled = fieldType Is GetType(TextFormField) OrElse fieldType Is GetType(UnStructuredTextFormField)
         _gbOMRFrame.Enabled = fieldType Is GetType(OmrFormField)
         _gbOMRSensitivity.Enabled = fieldType Is GetType(OmrFormField)
         _tpTable.Enabled = fieldType Is GetType(TableFormField)

         _gbDropoutOptions.Enabled = fieldType Is GetType(TextFormField) OrElse fieldType Is GetType(UnStructuredTextFormField)

         _cmbFieldType.Enabled = True
      End If

   End Sub

   Private Sub _menuItemExit_Click(sender As Object, e As EventArgs) Handles _menuItemExit.Click
      Close()
   End Sub

   Private Sub MainForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
      If regionMode Then
         e.Cancel = True
         Return
      End If

      If Not CheckForUnsavedChanges() Then
         e.Cancel = True
      End If

      If EditorStream IsNot Nothing Then
         EditorStream.Dispose()
      End If

      ShutDownEngines()
      Application.[Exit]()
   End Sub

   Private Function getSelectedField() As FormField
      Dim index As Integer = _lbFields.SelectedIndex
      If index = -1 Then
         Return Nothing
      End If

      If automation.CurrentEditObject Is Nothing Then
         Return Nothing
      End If

      Dim currentField As FormField = TryCast(automation.CurrentEditObject.Tag, FormField)
      Return currentField
   End Function

   Private Sub CreateNewRepository(newDirectory As String)
      Using cursor As New WaitCursor()
         'Create the repository 
         If workingRepository IsNot Nothing Then
            workingRepository = Nothing
         End If
         workingRepository = New DiskMasterFormsRepository(rasterCodecs, newDirectory)
         BuildMasterFormList(workingRepository.RootCategory, _tvMasterForms.Nodes, True)

         If Settings.[Default].MasterFormsPath <> newDirectory Then
            Settings.[Default].MasterFormsPath = newDirectory
            Settings.[Default].Save()
         End If
      End Using
   End Sub

   Private Sub _menuItemAddMasterSetMain_Click(sender As Object, e As EventArgs) Handles _menuItemAddMasterSet.Click, _menuItemAddMasterSetMain.Click
      If Not CheckForUnsavedChanges() Then
         Return
      End If

      Try
         Dim fbd As New FolderBrowserDialogEx()
         fbd.Description = "Please select a directory to create the new master form set"
         fbd.ShowFullPathInEditBox = True
         fbd.ShowEditBox = True
         fbd.ShowNewFolderButton = False
         If fbd.ShowDialog() = DialogResult.OK Then
            Dim existingDirs As String() = Directory.GetDirectories(fbd.SelectedPath)
            Dim newFormSet As New NewElement("Create a new form set", "Master Form Set Name:", existingDirs)
            If newFormSet.ShowDialog() = DialogResult.OK Then
               CreateNewRepository(Path.Combine(fbd.SelectedPath, newFormSet.ElementName))
            End If
         End If
      Catch exp As Exception
         Messager.ShowError(Me, exp)
      End Try
      UpdateControls()
   End Sub

   Private Sub _menuItemSaveChanges_Click(sender As Object, e As EventArgs) Handles _menuItemSaveChanges.Click
      If ApplyChanges() Then
         isFieldDirty = False
      End If
   End Sub

   Private Sub _menuItemSaveFormSetAs_Click(sender As Object, e As EventArgs) Handles _btnSaveMasterFormsAs.Click, _menuItemSaveFormSetAs.Click
      If Not CheckForUnsavedChanges() Then
         Return
      End If

      Try
         Dim fbd As New FolderBrowserDialogEx()
         fbd.Description = "Please select a directory to create the new master form set"
         fbd.ShowFullPathInEditBox = True
         fbd.ShowEditBox = True
         fbd.ShowNewFolderButton = True
         If fbd.ShowDialog() = DialogResult.OK Then
            Dim existingDirs As String() = Directory.GetDirectories(fbd.SelectedPath)
            Dim newFormSet As New NewElement("Create a new form set", "Master Form Set Name:", existingDirs)
            If newFormSet.ShowDialog() = DialogResult.OK Then
               'Create a new repository and copy the forms from the old repository to the new one
               Dim oldRepository As New DiskMasterFormsRepository(rasterCodecs, workingRepository.Path)
               CreateNewRepository(Path.Combine(fbd.SelectedPath, newFormSet.ElementName))
               CopyMasterForms(oldRepository.RootCategory, workingRepository.RootCategory)
               BuildMasterFormList(workingRepository.RootCategory, _tvMasterForms.Nodes, True)
               oldRepository = Nothing
               Messager.Show(Me, "Master form set saved.", MessageBoxIcon.Information, MessageBoxButtons.OK)
            End If
         End If
      Catch exp As Exception
         Messager.ShowError(Me, exp)
      End Try
      UpdateControls()
   End Sub

   Private Sub CopyMasterForms(sourceCategory As IMasterFormsCategory, targetCategory As IMasterFormsCategory)
      'Copy master forms
      For Each masterForm As IMasterForm In sourceCategory.MasterForms
         targetCategory.AddMasterForm(masterForm.ReadAttributes(), masterForm.ReadFields(), masterForm.ReadForm())
      Next

      'copy categories
      For Each sourceChildCategory As IMasterFormsCategory In sourceCategory.ChildCategories
         Dim targetChildCategory As IMasterFormsCategory = targetCategory.AddChildCategory(sourceChildCategory.Name)
         CopyMasterForms(sourceChildCategory, targetChildCategory)
      Next
   End Sub

   Private Sub _menuItemAddMasterMain_Click(sender As Object, e As EventArgs) Handles _menuItemAddMaster.Click, _menuItemAddMasterMain.Click
      If Not CheckForUnsavedChanges() Then
         Return
      End If

      Try
         Dim parentCategory As IMasterFormsCategory = Nothing
         Dim parentCategoryNode As TreeNode = Nothing
         If _tvMasterForms.SelectedNode Is Nothing Then
            'nothing selected, add it to root category
            parentCategory = workingRepository.RootCategory
            parentCategoryNode = _tvMasterForms.Nodes(0)
         Else
            'if selected node is category, add it as child. Otherwise add it to parent of selected node
            Dim type As Type = _tvMasterForms.SelectedNode.Tag.[GetType]()
            If type Is GetType(DiskMasterFormsCategory) Then
               'selected node is category
               parentCategory = TryCast(_tvMasterForms.SelectedNode.Tag, IMasterFormsCategory)
               parentCategoryNode = _tvMasterForms.SelectedNode
            Else
               'selected node is master form
               parentCategory = TryCast(_tvMasterForms.SelectedNode.Parent.Tag, IMasterFormsCategory)
               parentCategoryNode = _tvMasterForms.SelectedNode.Parent
            End If
         End If

         'Build array of current form names
         Dim existingForms As String() = New String(parentCategory.MasterForms.Count - 1) {}
         For i As Integer = 0 To parentCategory.MasterForms.Count - 1
            existingForms(i) = parentCategory.MasterForms(i).Name
         Next

         Dim newelement As New NewElement("Create a new master form", "Master Form Name:", existingForms)
         If newelement.ShowDialog() = DialogResult.OK Then
            'Add master form to repository and treeview
            Dim newForm As IMasterForm = parentCategory.AddMasterForm(CreateMasterForm(newelement.ElementName), Nothing, CType(Nothing, RasterImage))
            Dim newNode As TreeNode = parentCategoryNode.Nodes.Add(newForm.Name)
            newNode.Tag = newForm
            _tvMasterForms.SelectedNode = newNode
         End If
      Catch exp As Exception
         Messager.ShowError(Me, exp)
      End Try
      UpdateControls()
   End Sub

   Public Function CreateMasterForm(name As String) As FormRecognitionAttributes
      Dim options As New FormRecognitionOptions()
      Dim attributes As FormRecognitionAttributes = recognitionEngine.CreateMasterForm(name, New Guid(), options)
      recognitionEngine.CloseMasterForm(attributes)
      Return attributes
   End Function

   Private Sub _menuItemDeleteMasterMain_Click(sender As Object, e As EventArgs) Handles _menuItemDeleteMaster.Click, _menuItemDeleteMasterMain.Click
      Try
         If Messager.ShowQuestion(Me, "This will permanently delete the selected master form.  Are you sure you want to continue?", MessageBoxButtons.YesNo) <> DialogResult.Yes Then
            Return
         End If

         'We know the selected node is a masterform node, otherwise the delete button would have been disabled
         Dim parentCategory As IMasterFormsCategory = TryCast(_tvMasterForms.SelectedNode.Parent.Tag, IMasterFormsCategory)
         isFieldDirty = False
#If FOR_DOTNET4 Then
         If _useFullTextSearchButton.Checked AndAlso recognitionEngine.FullTextSearchManager IsNot Nothing Then
            recognitionEngine.DeleteMasterFormFromFullTextSearch("index", TryCast(_tvMasterForms.SelectedNode.Tag, IMasterForm).ReadAttributes())
            recognitionEngine.FullTextSearchManager.Index()
         End If
#End If
         parentCategory.DeleteMasterForm(TryCast(_tvMasterForms.SelectedNode.Tag, IMasterForm))
         _tvMasterForms.SelectedNode.Remove()
      Catch exp As Exception
         Messager.ShowError(Me, exp)
      End Try
      UpdateControls()
   End Sub

   Private Sub _menuItemAddMasterPageDiskMain_Click(sender As Object, e As EventArgs) Handles _menuItemAddMasterPageDisk.Click, _menuItemAddMasterPageDiskMain.Click
      If Not CheckForUnsavedChanges() Then
         Return
      End If

      Try
         Dim loader As New ImageFileLoader()
         loader.OpenDialogInitialPath = _openInitialPath
         loader.ShowLoadPagesDialog = True
         loader.MultiSelect = False
         loader.ShowPdfOptions = True
         If loader.Load(Me, rasterCodecs, True) > 0 Then
            _openInitialPath = Path.GetDirectoryName(loader.FileName)
            AddMasterFormPages(loader.Image)
         End If
      Catch exp As Exception
         Messager.ShowError(Me, exp)
      End Try
      UpdateControls()
   End Sub

#If LEADTOOLS_V19_OR_LATER Then
   Private Function GetPageType() As FormsPageType
      Dim type As FormsPageType = FormsPageType.Normal
      If cardItem.Checked Then
         type = FormsPageType.IDCard
      ElseIf omrItem.Checked Then
         type = FormsPageType.Omr
      End If

      Return type
   End Function
#End If

   Private Sub AddMasterFormPages(imagesToAdd As RasterImage)
      'Load masterform attributes, fields, and image
      Dim currentMasterForm As DiskMasterForm = GetCurrentMasterForm()
      Dim attributes As FormRecognitionAttributes = currentMasterForm.ReadAttributes()
      Dim formPages As FormPages = currentMasterForm.ReadFields()
      Dim formImage As RasterImage = currentMasterForm.ReadForm()

      Dim options As New PageRecognitionOptions()
#If LEADTOOLS_V19_OR_LATER Then
      options.PageType = GetPageType()
#End If

      For i As Integer = 0 To imagesToAdd.PageCount - 1
         'Add each new page to the masterform by creating attributes for each page
         imagesToAdd.Page = i + 1
         AddPageToMasterForm(imagesToAdd.Clone(), attributes, -1, options)
      Next

      'Add image
      If formImage IsNot Nothing Then
         formImage.AddPages(imagesToAdd.CloneAll(), 1, imagesToAdd.PageCount)
      Else
         formImage = imagesToAdd.CloneAll()
      End If

      'Only add processing pages for the new pages
      If formPages IsNot Nothing Then
         For i As Integer = 0 To imagesToAdd.PageCount - 1
            formPages.Add(New FormPage(formPages.Count + 1, imagesToAdd.XResolution, imagesToAdd.YResolution))
         Next
      Else
         'No processing pages exist so we must create them
         Dim tempProcessingEngine As New FormProcessingEngine()
         tempProcessingEngine.OcrEngine = ocrEngine
         tempProcessingEngine.BarcodeEngine = barcodeEngine

         For i As Integer = 0 To recognitionEngine.GetFormProperties(attributes).Pages - 1
            tempProcessingEngine.Pages.Add(New FormPage(i + 1, imagesToAdd.XResolution, imagesToAdd.YResolution))
         Next

         formPages = tempProcessingEngine.Pages
      End If

      currentMasterForm.WriteForm(formImage)
      currentMasterForm.WriteAttributes(attributes)
      currentMasterForm.WriteFields(formPages)

      BuildMasterPageList()
      UpdatePageType()
   End Sub

   Public Sub AddPageToMasterForm(image As RasterImage, attributes As FormRecognitionAttributes, pageIndex As Integer, pageOptions As PageRecognitionOptions)
      Using cursor As New WaitCursor()
         recognitionEngine.OpenMasterForm(attributes)
         recognitionEngine.InsertMasterFormPage(pageIndex, attributes, image, pageOptions, Nothing)
#If FOR_DOTNET4 Then
         If _useFullTextSearchButton.Checked Then
            If (recognitionEngine.FullTextSearchManager Is Nothing) Then
               recognitionEngine.FullTextSearchManager = CreateFullTextSearchManager(workingRepository.Path)
            End If

            recognitionEngine.UpsertMasterFormToFullTextSearch(attributes, "index", Nothing, Nothing, Nothing, Nothing)
         End If
#End If

         recognitionEngine.CloseMasterForm(attributes)

#If FOR_DOTNET4 Then
         If _useFullTextSearchButton.Checked Then
            recognitionEngine.FullTextSearchManager.Index()
         End If
#End If
      End Using
   End Sub

   Private Sub _menuItemAddMasterPageScannerMain_Click(sender As Object, e As EventArgs) Handles _menuItemAddMasterPageScanner.Click, _menuItemAddMasterPageScannerMain.Click
      If Not CheckForUnsavedChanges() Then
         Return
      End If

      Try
         Messager.Show(Me, "For best results, scan at 150DPI (or higher) and 1 bits per pixel", MessageBoxIcon.Information, MessageBoxButtons.OK)
         If twainSession.SelectSource([String].Empty) <> DialogResult.OK Then
            Return
         End If

         If (Not DemosGlobal.CheckKnown3rdPartyTwainIssues(Me, twainSession.SelectedSourceName())) Then
            Return
         End If

         If twainSession.Acquire(TwainUserInterfaceFlags.Show) <> DialogResult.OK Then
            Return
         End If

         AddMasterFormPages(scannedImage)
         scannedImage.Dispose()
         scannedImage = Nothing
      Catch exp As Exception
         Messager.ShowError(Me, exp)
      Finally
         UpdateControls()
      End Try
   End Sub

   Private Sub twainSession_AcquirePage(sender As Object, e As TwainAcquirePageEventArgs)
      If scannedImage Is Nothing Then
         scannedImage = e.Image.Clone()
      Else
         scannedImage.AddPage(e.Image.Clone())
      End If
   End Sub

   Private Sub _menuItemDeleteMasterPageMain_Click(sender As Object, e As EventArgs) Handles _menuItemDeleteMasterPage.Click, _menuItemDeleteMasterPageMain.Click
      Try
         If Messager.ShowQuestion(Me, "This will permanently delete the selected master form page.  Are you sure you want to continue?", MessageBoxButtons.YesNo) <> DialogResult.Yes Then
            Return
         End If

         Dim currentMasterForm As DiskMasterForm = GetCurrentMasterForm()
         Dim currentPageIdx As Integer = 0
         For i As Integer = 0 To rasterImageList1.Items.Count - 1
            If rasterImageList1.Items(i).IsSelected Then
               currentPageIdx = rasterImageList1.Items.IndexOf(rasterImageList1.Items(i))
            End If
         Next
         Dim attributes As FormRecognitionAttributes = currentMasterForm.ReadAttributes()
         Dim formPages As FormPages = currentMasterForm.ReadFields()
         Dim formImage As RasterImage = currentMasterForm.ReadForm()

         'Delete page from master form attaributes
         DeletePageFromMasterForm(currentPageIdx + 1, attributes)
         'page number here is 1 based
         'Delete fields page
         formPages.RemoveAt(currentPageIdx)
         'Delete the page from the image
         If formImage.PageCount = 1 Then
            formImage = Nothing
         Else
            'You cannot remove the only page from a rasterimage, an exception will occur
            formImage.RemovePageAt(currentPageIdx + 1)
         End If

         'We need to recreate the FormPages to ensure the page numbers are updated correctly
         For i As Integer = 0 To formPages.Count - 1
            Dim currentPage As FormPage = formPages(i)
            Dim newPage As New FormPage(i + 1, currentPage.DpiX, currentPage.DpiY)
            newPage.AddRange(currentPage.GetRange(0, currentPage.Count))
            formPages(i) = newPage
         Next

         isFieldDirty = False
         'Write the updated masterform to disk. Delete it first just in case the entire image was deleted
         Dim parentCategory As DiskMasterFormsCategory = TryCast(_tvMasterForms.SelectedNode.Parent.Tag, DiskMasterFormsCategory)
         parentCategory.DeleteMasterForm(currentMasterForm)
         parentCategory.AddMasterForm(attributes, formPages, formImage)

         'Delete the page from the imagelist
         rasterImageList1.Items.RemoveAt(currentPageIdx)
         rasterImageList1_SelectedIndexChanged(Me, Nothing)
      Catch exp As Exception
         Messager.ShowError(Me, exp)
      End Try
      UpdateControls()
   End Sub

   Private Sub DeletePageFromMasterForm(pagenumber As Integer, form As FormRecognitionAttributes)
      recognitionEngine.OpenMasterForm(form)
      recognitionEngine.DeleteMasterFormPage(form, pagenumber)
#If FOR_DOTNET4 Then
      If _useFullTextSearchButton.Checked Then
         recognitionEngine.UpsertMasterFormToFullTextSearch(form, "index", Nothing, Nothing, Nothing, Nothing)
      End If
#End If
      recognitionEngine.CloseMasterForm(form)
   End Sub

   Private Sub _menuItemAddChildCategoryMain_Click(sender As Object, e As EventArgs) Handles _menuItemAddChildCategory.Click, _menuItemAddChildCategoryMain.Click
      If Not CheckForUnsavedChanges() Then
         Return
      End If

      Try
         Dim parentCategory As IMasterFormsCategory = Nothing
         Dim parentCategoryNode As TreeNode = Nothing
         If _tvMasterForms.SelectedNode Is Nothing Then
            'nothing selected, add it as a child of the root
            parentCategory = workingRepository.RootCategory
            parentCategoryNode = _tvMasterForms.Nodes(0)
         Else
            'if selected node is category, add it as child. Otherwise add it to parent of selected node
            Dim type As Type = _tvMasterForms.SelectedNode.Tag.[GetType]()
            If type Is GetType(DiskMasterFormsCategory) Then
               'selected node is category
               parentCategory = TryCast(_tvMasterForms.SelectedNode.Tag, IMasterFormsCategory)
               parentCategoryNode = _tvMasterForms.SelectedNode
            Else
               'selected node is master form
               parentCategory = TryCast(_tvMasterForms.SelectedNode.Parent.Tag, IMasterFormsCategory)
               parentCategoryNode = _tvMasterForms.SelectedNode.Parent
            End If
         End If

         'Build array of current category names
         Dim existingCategories As String() = New String(parentCategory.ChildCategories.Count - 1) {}
         For i As Integer = 0 To parentCategory.ChildCategories.Count - 1
            existingCategories(i) = parentCategory.ChildCategories(i).Name
         Next

         Dim newelement As New NewElement("Create a new child category", "Category Name:", existingCategories)
         If newelement.ShowDialog() = DialogResult.OK Then
            'Add child category to repository and treeview
            Dim newCategory As IMasterFormsCategory = parentCategory.AddChildCategory(newelement.ElementName)
            Dim newNode As TreeNode = parentCategoryNode.Nodes.Add(newCategory.Name)
            newNode.Tag = newCategory
            _tvMasterForms.SelectedNode = newNode
         End If
      Catch exp As Exception
         Messager.ShowError(Me, exp)
      End Try
      UpdateControls()
   End Sub

   Private Sub _menuItemDeleteChildCategoryMain_Click(sender As Object, e As EventArgs) Handles _menuItemDeleteChildCategory.Click, _menuItemDeleteChildCategoryMain.Click
      Try
         If Messager.ShowQuestion(Me, "This will permanently delete the selected category.  Are you sure you want to continue?", MessageBoxButtons.YesNo) <> DialogResult.Yes Then
            Return
         End If

         Dim category As IMasterFormsCategory = TryCast(_tvMasterForms.SelectedNode.Tag, IMasterFormsCategory)
         isFieldDirty = False
         category.Clear()
         _tvMasterForms.SelectedNode.Remove()
      Catch exp As Exception
         Messager.ShowError(Me, exp)
      End Try
      UpdateControls()
   End Sub

   Private Sub _menuItemInformation_Click(sender As Object, e As EventArgs) Handles _menuItemInformation.Click
      Dim infoDlg As New InformationDlg()
      infoDlg.ShowDialog()
   End Sub

   Private Sub _menuItemHowTo_Click(sender As Object, e As EventArgs) Handles _menuItemHowTo.Click
      Try
         DemosGlobal.LaunchHowTo("FormsRecognitionDemo.html")
      Catch ex As Exception
         Messager.ShowError(Me, ex.Message)
      End Try
   End Sub

   Private Sub _menuItemAbout_Click(sender As Object, e As EventArgs) Handles _menuItemAbout.Click
#If LEADTOOLS_V19_OR_LATER Then
      Using aboutDialog As New AboutDialog("Master Forms Editor", ProgrammingInterface.VB)
         aboutDialog.ShowDialog(Me)
      End Using
#Else
      Using aboutDialog As New AboutDialog("Master Forms Editor")
         aboutDialog.ShowDialog(Me)
      End Using
#End If
   End Sub

   Private Sub RecognitionOptionsChanged(sender As Object, e As EventArgs) Handles _menuItemOCRManager.Click, _menuItemBarcodeManager.Click, _menuItemDefaultManager.Click
      SetupRecognitionEngine()
   End Sub

   Private Sub DisableInteractiveModes()
      For Each mode As ImageViewerInteractiveMode In rasterImageViewer1.InteractiveModes
         mode.IsEnabled = False
      Next
   End Sub

   Private Sub _btnPointerTool_Click(sender As Object, e As EventArgs) Handles _btnPointerTool.Click
      DisableInteractiveModes()
      rasterImageViewer1.InteractiveModes.EnableById(_automationInteractiveMode.Id)
      CheckToolButtons(sender)
   End Sub

   Private Sub _btnPanTool_Click(sender As Object, e As EventArgs) Handles _btnPanTool.Click
      DisableInteractiveModes()
      rasterImageViewer1.InteractiveModes.EnableById(_panInteractiveMode.Id)
      CheckToolButtons(sender)
   End Sub

   Private Sub EnableHighlight(fieldType As Type)
      DisableInteractiveModes()
      rasterImageViewer1.InteractiveModes.EnableById(_automationInteractiveMode.Id)

      For Each obj As AnnAutomationObject In annAutomationManager.Objects
         If obj.Id = AnnObject.HiliteObjectId Then
            Dim highlight As AnnHiliteObject = TryCast(obj.ObjectTemplate, AnnHiliteObject)
            highlight.HiliteColor = GetHighlightColor(fieldType).ToString()
            Exit For
         End If
      Next

      automation.Manager.CurrentObjectId = AnnObject.HiliteObjectId

      isFieldDirty = True
   End Sub

   Private Function GetHighlightColor(fieldType As Type) As [String]
      If GetType(TextFormField) Is fieldType Then
         Return "Green"

      ElseIf GetType(OmrFormField) Is fieldType Then
         Return "Purple"

      ElseIf GetType(ImageFormField) Is fieldType Then
         Return "Yellow"

      ElseIf GetType(BarcodeFormField) Is fieldType Then
         Return "Orange"

      ElseIf GetType(TableFormField) Is fieldType Then
         Return "Red"

      ElseIf GetType(UnStructuredTextFormField) Is fieldType Then
         Return "DarkSeaGreen"

      ElseIf GetType(SingleSelectionField) Is fieldType Then
         Return "Brown"

      ElseIf GetType(BubbleWordField) Is fieldType Then
         Return "Pink"
#If LEADTOOLS_V20_OR_LATER Then
      ElseIf GetType(OmrDateField) = fieldType Then
         Return "DeepPink"

      ElseIf GetType(OmrAnswerAreaField) = fieldType Then
         Return "Aqua"
#End If
      Else
         Return "Blue"
      End If
      'default
   End Function

   Private Sub _btnSelectRegion_Click(sender As Object, e As EventArgs) Handles _btnSelectRegion.Click
      EnableHighlight(Nothing)
      CheckToolButtons(sender)
   End Sub

   Private Sub _btnOcrTool_Click(sender As Object, e As EventArgs) Handles _btnOcrTool.Click
      EnableHighlight(GetType(TextFormField))
      CheckToolButtons(sender)
   End Sub

   Private Sub _btnUNOcrTool_Click(sender As Object, e As EventArgs) Handles _btnUNOcrTool.Click
      EnableHighlight(GetType(UnStructuredTextFormField))
      CheckToolButtons(sender)
   End Sub

   Private Sub _btnOmrTool_Click(sender As Object, e As EventArgs) Handles _btnOmrTool.Click
      EnableHighlight(GetType(OmrFormField))
      CheckToolButtons(sender)
   End Sub


   Private Sub _miSingleSelectionField_Click(sender As Object, e As EventArgs) Handles _miSingleSelectionField.Click
      EnableHighlight(GetType(SingleSelectionField))
      CheckToolButtons(_btnOmrHighLevelObjects)
      CheckHighLevelMenuItem(sender)
   End Sub

   Private Sub _miBubbleWordField_Click(sender As Object, e As EventArgs) Handles _miBubbleWordField.Click
      EnableHighlight(GetType(BubbleWordField))
      CheckToolButtons(_btnOmrHighLevelObjects)
      CheckHighLevelMenuItem(sender)
   End Sub

#If LEADTOOLS_V20_OR_LATER Then
   Private Sub _miAnswerAreaField_Click(sender As Object, e As EventArgs) Handles _miAnswerAreaField.Click
      EnableHighlight(GetType(OmrAnswerAreaField))
      CheckToolButtons(_btnOmrHighLevelObjects)
      CheckHighLevelMenuItem(sender)
   End Sub

   Private Sub _miOmrDateField_Click(sender As Object, e As EventArgs) Handles _miOmrDateField.Click
      EnableHighlight(GetType(OmrDateField))
      CheckToolButtons(_btnOmrHighLevelObjects)
      CheckHighLevelMenuItem(sender)
   End Sub
#End If

   Private Sub _btnOmrHighLevelObjects_Click(sender As Object, e As EventArgs) Handles _btnOmrHighLevelObjects.Click
      _cmHighLevelObjects.Show(MousePosition)

   End Sub

   Private Sub _btnBarcodeTool_Click(sender As Object, e As EventArgs) Handles _btnBarcodeTool.Click
      EnableHighlight(GetType(BarcodeFormField))
      CheckToolButtons(sender)
   End Sub

   Private Sub _btnImageTool_Click(sender As Object, e As EventArgs) Handles _btnImageTool.Click
      EnableHighlight(GetType(ImageFormField))
      CheckToolButtons(sender)
   End Sub

   Private Sub _btnTableTool_Click(sender As Object, e As EventArgs) Handles _btnTableTool.Click
      EnableHighlight(GetType(TableFormField))
      CheckToolButtons(sender)
   End Sub

   Private Sub _btnShowFields_Click(sender As Object, e As EventArgs) Handles _btnShowFields.Click
      automation.Container.IsVisible = Not automation.Container.IsVisible
      rasterImageViewer1.Refresh()
   End Sub

   Private Sub _btnZoomNormal_Click(sender As Object, e As EventArgs) Handles _btnZoomNormal.Click
      Try
         rasterImageViewer1.Zoom(ControlSizeMode.ActualSize, 1, rasterImageViewer1.DefaultZoomOrigin)
      Catch exp As Exception
         Messager.ShowError(Me, exp)
      End Try
   End Sub

   Private Sub _btnFit_Click(sender As Object, e As EventArgs) Handles _btnFit.Click
      Try
         rasterImageViewer1.Zoom(ControlSizeMode.FitAlways, 1, rasterImageViewer1.DefaultZoomOrigin)
      Catch exp As Exception
         Messager.ShowError(Me, exp)
      End Try
   End Sub

   Private Sub _btnFitWidth_Click(sender As Object, e As EventArgs) Handles _btnFitWidth.Click
      Try
         rasterImageViewer1.Zoom(ControlSizeMode.FitWidth, 1, rasterImageViewer1.DefaultZoomOrigin)
      Catch exp As Exception
         Messager.ShowError(Me, exp)
      End Try
   End Sub

   Private Sub _btnZoomIn_Click(sender As Object, e As EventArgs) Handles _btnZoomIn.Click
      Try
         Dim oldScaleFactor As Double = rasterImageViewer1.ScaleFactor
         rasterImageViewer1.Zoom(ControlSizeMode.None, oldScaleFactor + 0.1F, rasterImageViewer1.DefaultZoomOrigin)
      Catch exp As Exception
         Messager.ShowError(Me, exp)
      End Try
   End Sub

   Private Sub _btnZoomOut_Click(sender As Object, e As EventArgs) Handles _btnZoomOut.Click
      Try
         If rasterImageViewer1.ScaleFactor > 0.1F Then
            Dim oldScaleFactor As Double = rasterImageViewer1.ScaleFactor
            rasterImageViewer1.Zoom(ControlSizeMode.None, oldScaleFactor - 0.1F, rasterImageViewer1.DefaultZoomOrigin)
         End If
      Catch exp As Exception
         Messager.ShowError(Me, exp)
      End Try
   End Sub

   Private Sub _btnZoomDrawTool_Click(sender As Object, e As EventArgs) Handles _btnZoomDrawTool.Click
      DisableInteractiveModes()
      rasterImageViewer1.InteractiveModes.EnableById(_zoomToInteractiveMode.Id)
      CheckToolButtons(sender)
   End Sub

   Private Sub CheckToolButtons(sender As Object)
      _btnPointerTool.Checked = False
      _btnPanTool.Checked = False
      _btnZoomDrawTool.Checked = False
      _btnOcrTool.Checked = False
      _btnUNOcrTool.Checked = False
      _btnBarcodeTool.Checked = False
      _btnImageTool.Checked = False
      _btnOmrTool.Checked = False
      _btnSelectRegion.Checked = False
      _btnTableTool.Checked = False
      _btnOmrHighLevelObjects.Checked = False
      CType(sender, ToolStripButton).Checked = True
   End Sub

   Private Sub CheckHighLevelMenuItem(sender As Object)
      _miSingleSelectionField.Checked = False
      _miBubbleWordField.Checked = False
#If LEADTOOLS_V20_OR_LATER Then
      _miAnswerAreaField.Checked = False
      _miOmrDateField.Checked = False
#End If

      If TryCast(sender, ToolStripMenuItem) IsNot Nothing Then
         CType(sender, ToolStripMenuItem).Checked = True
      End If
   End Sub

   Private Sub _btnUseDpi_Click(sender As Object, e As EventArgs) Handles _btnUseDpi.Click
      rasterImageViewer1.UseDpi = _btnUseDpi.Checked

      If _btnUseDpi.Checked Then
         _btnUseDpi.ToolTipText = "Ignore Image DPI When Viewing"
      Else
         _btnUseDpi.ToolTipText = "Use Image DPI When Viewing"
      End If
   End Sub

   Private Sub DeleteSelectedField()
      Try
         'Delete annotation field and remove from field listbox
         Dim currentAnnotationField As AnnObject = automation.CurrentEditObject
         automation.Cancel()

         Dim tableForm As TableFormField = TryCast(currentAnnotationField.Tag, TableFormField)
         Dim unstructuredTextForm As UnStructuredTextFormField = TryCast(currentAnnotationField.Tag, UnStructuredTextFormField)
         If tableForm IsNot Nothing Then
            For Each column As TableColumn In tableForm.Columns
               automation.Container.Children.Remove(TryCast(column.Tag, AnnObject))
            Next

            automation.Container.Children.Remove(TryCast(tableForm.Tag, AnnObject))
         ElseIf unstructuredTextForm IsNot Nothing Then
            automation.Container.Children.Remove(TryCast(unstructuredTextForm.TextFormField.Tag, AnnObject))
            automation.Container.Children.Remove(TryCast(unstructuredTextForm.Tag, AnnObject))
         Else
            automation.Container.Children.Remove(currentAnnotationField)
         End If

         _lbFields.Items.RemoveAt(_lbFields.SelectedIndex)
         rasterImageViewer1.Invalidate()
      Catch exp As Exception
         Messager.ShowError(Me, exp)
      End Try
   End Sub

   Private Sub _btnDeleteField_Click(sender As Object, e As EventArgs) Handles _btnDeleteField.Click
      DeleteSelectedField()
      isFieldDirty = True
      UpdateControls()
   End Sub

   Private Sub _btnApply_Click(sender As Object, e As EventArgs) Handles _btnApply.Click
      ApplyChanges()
   End Sub

   Private Sub _btnPasteField_Click(sender As Object, e As EventArgs) Handles _btnPasteField.Click
      If FormCopy Is Nothing AndAlso Origform Is Nothing Then
         Return
      End If

      automation.Paste()

      If FormCopy IsNot Nothing Then
         'copy
         automation.CurrentEditObject.Tag = FormCopy
         TryCast(automation.CurrentEditObject.Tag, FormField).Tag = automation.CurrentEditObject
         TryCast(automation.CurrentEditObject.Tag, FormField).Name = GetFreeFieldName()
      Else
         'cut
         automation.CurrentEditObject.Tag = Origform
      End If

      AlignmentTableFields(TryCast(automation.CurrentEditObject.Tag, TableFormField))
      UnStructuredTextFormFieldDisplay(TryCast(automation.CurrentEditObject.Tag, UnStructuredTextFormField))
      _lbFields.Items.Add(TryCast(automation.CurrentEditObject.Tag, FormField).Name)
      isFieldDirty = True

      Origform = TryCast(automation.CurrentEditObject.Tag, FormField)
      FormCopy = CType(Origform.Clone(), FormField)
      Origform = Nothing

      UpdateControls()
   End Sub

   Private FormCopy As FormField = Nothing
   Private Origform As FormField = Nothing

   Private Sub _btnCopyField_Click(sender As Object, e As EventArgs) Handles _btnCopyField.Click
      Origform = TryCast(automation.CurrentEditObject.Tag, FormField)
      FormCopy = CType(Origform.Clone(), FormField)

      automation.CurrentEditObject.Tag = Nothing
      automation.Copy()
      automation.CurrentEditObject.Tag = Origform
      Origform = Nothing

      UpdateControls()
   End Sub

   Private Sub _btnCutField_Click(sender As Object, e As EventArgs) Handles _btnCutField.Click
      FormCopy = Nothing

      Origform = CType(TryCast(automation.CurrentEditObject.Tag, FormField), FormField)
      automation.CurrentEditObject.Tag = Nothing
      automation.Copy()
      automation.CurrentEditObject.Tag = Origform

      DeleteSelectedField()
      isFieldDirty = True
      UpdateControls()
   End Sub

   Private Function GetPageOptions(pageIndex As Integer, attributes As FormRecognitionAttributes) As PageRecognitionOptions
      Dim options As PageRecognitionOptions = Nothing
      Using cursor As New WaitCursor()
         recognitionEngine.OpenMasterForm(attributes)
         options = recognitionEngine.GetPageOptions(attributes, pageIndex)
         recognitionEngine.CloseMasterForm(attributes)
      End Using

      Return options
   End Function

   Private Sub AddRectangle(fieldToAdd As LeadRect)
      Dim annotationField As New AnnHiliteObject()
      annotationField.HiliteColor = "Blue"
      'temporarily disable item added event so it does not fire while adding these fields
      RemoveHandler automation.Draw, AddressOf Children_CollectionChanged
      automation.Container.Children.Add(annotationField)
      AddHandler automation.Draw, AddressOf Children_CollectionChanged

      ' Now we can calculate the object bounds correctly

      Dim rc As New RectangleF(fieldToAdd.Left, fieldToAdd.Top, fieldToAdd.Width, fieldToAdd.Height)

      Dim rect As LeadRectD = BoundsToAnnotations(annotationField, rc)
      annotationField.Rect = rect
   End Sub

   Private Sub SelectRegions_Click(sender As Object, e As EventArgs) Handles _menuItemIncludeExcludeRegions.Click
      If Not CheckForUnsavedChanges() Then
         Return
      End If

      Using regionForm As New RegionForm()
         If regionForm.ShowDialog() <> DialogResult.OK Then
            Return
         End If

         Try
            Dim currentPage As Integer = 0
            For i As Integer = 0 To rasterImageList1.Items.Count - 1
               If rasterImageList1.Items(i).IsSelected Then
                  currentPage = rasterImageList1.Items.IndexOf(rasterImageList1.Items(i))
               End If
            Next

            Dim currentMasterForm As DiskMasterForm = GetCurrentMasterForm()
            Dim attributes As FormRecognitionAttributes = currentMasterForm.ReadAttributes()
            Dim regionList As LeadRect() = Nothing
            Dim pageOptions As PageRecognitionOptions = GetPageOptions(currentPage, attributes)

            If regionForm.UseInterestRegions Then
               cancelRegion = False
               regionList = Nothing
               'Select regions of interest
               If Messager.Show(Me, "Please select the regions of interest for this page using the ""Select Regions"" tool. Press Enter to accept your selections, or Escape to exit this mode.", MessageBoxIcon.Exclamation, MessageBoxButtons.OKCancel) = DialogResult.OK Then
                  regionList = SelectRectangles(pageOptions.RegionOfInterestRectangles)
                  If regionList IsNot Nothing Then
                     pageOptions.RegionOfInterestRectangles.Clear()
                     For Each regionOfInterest As LeadRect In regionList
                        pageOptions.RegionOfInterestRectangles.Add(regionOfInterest)
                     Next
                  End If
               End If
            End If
            If regionForm.UseIncludeRegions Then
               cancelRegion = False
               regionList = Nothing
               'Select include regions
               If Messager.Show(Me, "Please select the include regions for this page using the ""Select Regions"" tool. Press Enter to accept your selections, or Escape to exit this mode.", MessageBoxIcon.Exclamation, MessageBoxButtons.OKCancel) = DialogResult.OK Then
                  regionList = SelectRectangles(pageOptions.IncludeRectangles)
                  If regionList IsNot Nothing Then
                     pageOptions.IncludeRectangles.Clear()
                     For Each includeRegion As LeadRect In regionList
                        pageOptions.IncludeRectangles.Add(includeRegion)
                     Next
                  End If
               End If
            End If
            If regionForm.UseExcludeRegions Then
               cancelRegion = False
               regionList = Nothing
               'Select exclude regions
               If Messager.Show(Me, "Please select the regions to exclude for this page using the ""Select Regions"" tool. Press Enter to accept your selections, or Escape to exit this mode.", MessageBoxIcon.Exclamation, MessageBoxButtons.OKCancel) = DialogResult.OK Then
                  regionList = SelectRectangles(pageOptions.ExcludeRectangles)
                  If regionList IsNot Nothing Then
                     pageOptions.ExcludeRectangles.Clear()
                     For Each excludeRegion As LeadRect In regionList
                        pageOptions.ExcludeRectangles.Add(excludeRegion)
                     Next
                  End If
               End If
            End If

            If regionList IsNot Nothing AndAlso regionList.Length > 0 Then
               'Delete old page from attributes (1 based index)
               DeletePageFromMasterForm(currentPage + 1, attributes)
               'Insert new page into attributes (1 based index)
               AddPageToMasterForm(rasterImageViewer1.Image.Clone(), attributes, currentPage + 1, pageOptions)
               'Write updated masterform attributes
               currentMasterForm.WriteAttributes(attributes)
               'Reload fields
               isFieldDirty = False
               rasterImageList1_SelectedIndexChanged(Me, Nothing)
            End If
         Catch exp As Exception
            Messager.ShowError(Me, exp)
         End Try
      End Using

      UpdateControls()
   End Sub

   Private Function SelectRectangles(oldRects As IList(Of LeadRect)) As LeadRect()
      Dim oldInteractiveMode As ImageViewerInteractiveMode = Nothing
      For Each mode As ImageViewerInteractiveMode In rasterImageViewer1.InteractiveModes
         If mode.IsEnabled = True Then
            oldInteractiveMode = mode
         End If
      Next

      Try
         'Make sure we are not in any interactive modes for drawing annotations
         DisableInteractiveModes()
         rasterImageViewer1.InteractiveModes.EnableById(_automationInteractiveMode.Id)
         'temporarily disable after changed event so it does not fire while adding these regions
         RemoveHandler automation.AfterObjectChanged, AddressOf automation_AfterObjectChanged
         'clear current annotations
         automation.SelectObject(Nothing)
         automation.Container.Children.Clear()
         rasterImageViewer1.Invalidate()

         For Each rect As LeadRect In oldRects
            AddRectangle(rect)
         Next

         regionMode = True
         UpdateControls()
         _btnSelectRegion_Click(_btnSelectRegion, Nothing)
         While regionMode
            Application.DoEvents()
         End While
         UpdateControls()

         If cancelRegion Then
            automation.SelectObject(Nothing)
            automation.Container.Children.Clear()
            rasterImageViewer1.Invalidate()
            Return Nothing
         End If

         Dim regionsOfInterest As New List(Of LeadRect)()
         For Each obj As AnnObject In automation.Container.Children
            regionsOfInterest.Add(BoundsFromAnnotations(obj))
         Next

         Return regionsOfInterest.ToArray()
      Catch
         Throw
      Finally
         DisableInteractiveModes()
         rasterImageViewer1.InteractiveModes.EnableById(oldInteractiveMode.Id)
         annAutomationManager.EditObjectAfterDraw = True
         AddHandler automation.AfterObjectChanged, AddressOf automation_AfterObjectChanged
         rasterImageViewer1.Invalidate()
      End Try
   End Function

   Private Sub rasterImageViewer1_KeyUp(sender As Object, e As KeyEventArgs) Handles rasterImageViewer1.KeyUp
      If regionMode Then
         If e.KeyCode = Keys.Enter Then
            regionMode = False
         End If
         'region mode complete
         If e.KeyCode = Keys.Escape Then
            regionMode = False
            cancelRegion = True
         End If
      End If
   End Sub

   Private Sub _menuItemMasterFormPropsMain_Click(sender As Object, e As EventArgs) Handles _btnMasterFormProps.Click, _menuItemMasterFormPropsMain.Click
      Try
         Dim parentCategory As DiskMasterFormsCategory = TryCast(_tvMasterForms.SelectedNode.Parent.Tag, DiskMasterFormsCategory)
         Dim currentMasterForm As DiskMasterForm = GetCurrentMasterForm()
         Dim masterProps As FormRecognitionProperties = recognitionEngine.GetFormProperties(currentMasterForm.ReadAttributes())
         Dim properties As New MasterFormProperties(masterProps, parentCategory.Path)
         properties.ShowDialog(Me)
      Catch exp As Exception
         Messager.ShowError(Me, exp)
         UpdateControls()
      End Try
   End Sub

   Private Sub _menuItemLaunchFormsDemo_Click(sender As Object, e As EventArgs) Handles _menuItemLaunchFormsDemo.Click
      'When launching the demo, pass the current engine we are using, and the repository path, if available
      Dim startInfo As New ProcessStartInfo()
      startInfo.FileName = Path.Combine(Application.StartupPath, "VBFormsDemo.exe")
      startInfo.Arguments = [String].Format("""{0}""", ocrEngine.EngineType.ToString())
      If workingRepository IsNot Nothing Then
         startInfo.Arguments = [String].Format("{0} ""{1}""", startInfo.Arguments, workingRepository.Path)
      End If

      Try
         Using process As New Process()
            process.StartInfo = startInfo
            process.Start()
            process.Close()
         End Using
      Catch exp As Exception
         Messager.ShowError(Me, String.Format("Can't start process: {0}{1}Exception message: {2}", startInfo.FileName, Environment.NewLine, exp.Message))
      End Try
   End Sub

   Private Sub _menuItemUpdateMasterFormsData_Click(sender As Object, e As EventArgs) Handles _menuItemUpdateMasterFormsData.Click
      Dim updateMasterFormsData As New UpdateMasterFormsData()
      updateMasterFormsData.ocrEngine = ocrEngine
      updateMasterFormsData.barcodeEngine = barcodeEngine
      updateMasterFormsData.recognitionEngine = recognitionEngine
      updateMasterFormsData.ShowDialog(Me)
   End Sub

   Private Function ApplyChanges() As Boolean
      Try
         Dim currentMasterForm As DiskMasterForm = GetCurrentMasterForm()
         If currentMasterForm Is Nothing Then
            Return False
         End If

         Dim formPages As FormPages = currentMasterForm.ReadFields()
         formPages(oldSelectedPageIndex).Clear()

         'Clear Tags that we do not want to save.
         PushFieldsTags()

         'All of the field data is stored in each annotations UserData property.
         'We will enumerate each object to extract all the fields and save them.
         For Each annotationField As AnnObject In automation.Container.Children
            If TypeOf annotationField Is AnnTextObject Then
               Continue For
            End If

            Dim selectionField As SingleSelectionField = TryCast(annotationField.Tag, SingleSelectionField)
            If (selectionField IsNot Nothing) Then
               If Not String.IsNullOrEmpty(selectionField.Parent) Then
                  Continue For
               End If
            End If

            Dim bubbleField As BubbleWordField = TryCast(annotationField.Tag, BubbleWordField)
            If bubbleField IsNot Nothing Then
               If Not String.IsNullOrEmpty(bubbleField.Parent) Then
                  Continue For
               End If
            End If

            Dim currentField As FormField = TryCast(annotationField.Tag, FormField)
            If currentField IsNot Nothing Then
               If Not formPages(oldSelectedPageIndex).Contains(currentField) Then
                  formPages(oldSelectedPageIndex).Add(currentField)
               End If
            End If
         Next

         currentMasterForm.WriteFields(formPages)

         'Return back cleared Tags
         PopFieldsTags()
      Catch exp As Exception
         Messager.ShowError(Me, exp)
      End Try

      isFieldDirty = False
      UpdateControls()
      Return True
   End Function

   Private tags As Dictionary(Of FormField, [Object]) = New Dictionary(Of FormField, Object)()

   Private Sub PushFieldsTags()
      tags.Clear()

      For Each annotationField As AnnObject In automation.Container.Children
         If TypeOf annotationField Is AnnTextObject Then
            Continue For
         End If

         Dim currentField As FormField = TryCast(annotationField.Tag, FormField)
         If currentField IsNot Nothing AndAlso currentField.Tag IsNot Nothing Then
            tags.Add(currentField, currentField.Tag)
            currentField.Tag = Nothing
         End If
      Next
   End Sub

   Private Sub PopFieldsTags()
      For Each annotationField As AnnObject In automation.Container.Children
         If TypeOf annotationField Is AnnTextObject Then
            Continue For
         End If

         Dim currentField As FormField = TryCast(annotationField.Tag, FormField)
         If tags.ContainsKey(currentField) Then
            Dim tag As [Object] = tags(currentField)
            If tag IsNot Nothing Then
               currentField.Tag = tag
            End If
         End If
      Next

      tags.Clear()
   End Sub

   Private Function CheckForUnsavedChanges() As Boolean
      If isFieldDirty Then
         Dim result As DialogResult = MessageBox.Show("You have made changes to the fields on this form without saving them. Would you like to apply these changes?", "Warning", MessageBoxButtons.YesNoCancel)
         If result = DialogResult.Yes Then
            Return ApplyChanges()
         ElseIf result = DialogResult.Cancel Then
            Return False
         Else
            isFieldDirty = False
            ' There were dirty objects but the user chose not to save them
            Return True
         End If
      End If

      Return True
   End Function

   Private Sub _tvMasterForms_BeforeSelect(sender As Object, e As TreeViewCancelEventArgs) Handles _tvMasterForms.BeforeSelect
      If Not CheckForUnsavedChanges() Then
         e.Cancel = True
      End If
   End Sub

   Private Sub _txtFieldName_TextChanged(sender As Object, e As EventArgs) Handles _txtFieldName.TextChanged
      If _lbFields.SelectedIndex = -1 OrElse regionMode Then
         Return
      End If

      If [String].IsNullOrEmpty(_txtFieldName.Text) Then
         Messager.Show(Me, "You must specify a field name.", MessageBoxIcon.[Error], MessageBoxButtons.OK)
         _txtFieldName.Text = TryCast(automation.CurrentEditObject.Tag, FormField).Name
         _txtFieldName.Focus()
         Return
      End If

      For i As Integer = 0 To _lbFields.Items.Count - 1
         'Check for existing field name
         If [String].Compare(_txtFieldName.Text, TryCast(_lbFields.Items(i), String)) = 0 AndAlso i <> _lbFields.SelectedIndex Then
            Messager.Show(Me, "That field name already exist.", MessageBoxIcon.[Error], MessageBoxButtons.OK)
            _txtFieldName.Focus()
            Return
         End If
      Next

      'name is ok, update it
      For Each annotationField As AnnObject In automation.Container.Children
         If TryCast(annotationField.Tag, FormField).Name = _lbFields.Text Then
            Dim currentField As FormField = TryCast(annotationField.Tag, FormField)
            currentField.Name = _txtFieldName.Text
            isFieldDirty = True

            'temporaily disable event to prevent field data from reloading
            RemoveHandler _lbFields.SelectedIndexChanged, AddressOf _lbFields_SelectedIndexChanged
            _lbFields.Items(_lbFields.SelectedIndex) = _txtFieldName.Text
            AddHandler _lbFields.SelectedIndexChanged, AddressOf _lbFields_SelectedIndexChanged

            Exit For
         End If
      Next
      UpdateControls()
   End Sub

   Private Sub _cmbFieldType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _cmbFieldType.SelectedIndexChanged
      isFieldDirty = True
      UpdateField()
   End Sub

   Private Sub _rbTextType_CheckedChanged(sender As Object, e As EventArgs) Handles _rbtextTypeNum.CheckedChanged, _rbTextTypeChar.CheckedChanged, _rbtextTypeData.CheckedChanged
      isFieldDirty = True
      UpdateField()
   End Sub

   Private Sub _chkOCRMethod_CheckedChanged(sender As Object, e As EventArgs) Handles _chkEnableIcr.CheckedChanged, _chkEnableOcr.CheckedChanged
      isFieldDirty = True
      UpdateField()
   End Sub

   Private Sub _rbOMRSensitivity_CheckedChanged(sender As Object, e As EventArgs) Handles _rbOMRSensitivityHighest.CheckedChanged, _rbOMRSensitivityHigh.CheckedChanged, _rbOMRSensitivityLowest.CheckedChanged, _rbOMRSensitivityLow.CheckedChanged
      isFieldDirty = True
      UpdateField()
   End Sub

   Private Sub _rbOMRFrame_CheckedChanged(sender As Object, e As EventArgs) Handles _rbOMRWithoutFrame.CheckedChanged, _rbOMRWithFrame.CheckedChanged, _rbOMRAutoFrame.CheckedChanged
      isFieldDirty = True
      UpdateField()
   End Sub

   Private Sub CopyFieldAttributes(newField As FormField, oldField As FormField)
      newField.Name = oldField.Name
      newField.Bounds = oldField.Bounds
      newField.MasterPageNumber = oldField.MasterPageNumber

      If TypeOf newField Is UnStructuredTextFormField Then
         TryCast(newField, UnStructuredTextFormField).TextFormField.Bounds = New LeadRect(CInt(newField.Bounds.Width / 2), 0, CInt(newField.Bounds.Width / 2), newField.Bounds.Height)
      End If

      If TypeOf newField Is TableFormField Then
         Dim column1 As New TextFormField()
         column1.Name = "Column1"
         column1.Bounds = New LeadRect(0, 0, CInt(newField.Bounds.Width / 2), newField.Bounds.Height)
         column1.Tag = Nothing
         TryCast(newField, TableFormField).Columns.Add(New TableColumn(column1))
         Dim column2 As New TextFormField()
         column2.Name = "Column2"
         column2.Bounds = New LeadRect(CInt(newField.Bounds.Width / 2), 0, CInt(newField.Bounds.Width / 2), newField.Bounds.Height)
         column2.Tag = Nothing
         TryCast(newField, TableFormField).Columns.Add(New TableColumn(column2))

         AlignmentTableFields(TryCast(newField, TableFormField))
         UpdateTable(TryCast(newField, TableFormField))
      End If
   End Sub

   Private Sub UpdateField()
      'One or more of the fields properties changed so we need to update the field data
      'which is stored in the annotation objects UserData
      If (automation Is Nothing) Then
         Return
      End If

      Dim currentField As FormField = TryCast(automation.CurrentEditObject.Tag, FormField)
      Dim isNewField As Boolean = False
      Dim tempOldField As FormField = currentField

      Dim fieldType As String = _cmbFieldType.Text
      Select Case fieldType
         Case "Text"
            If Not (TypeOf currentField Is TextFormField) Then
               isNewField = True
               currentField = New TextFormField()
               _rbTextTypeChar.Checked = True
               CopyFieldAttributes(currentField, tempOldField)
            End If

            'set text field options
            TryCast(currentField, TextFormField).EnableIcr = _chkEnableIcr.Checked
            TryCast(currentField, TextFormField).EnableOcr = _chkEnableOcr.Checked
            TryCast(currentField, TextFormField).Type = If(_rbTextTypeChar.Checked, TextFieldType.Character, If(_rbtextTypeNum.Checked, TextFieldType.Numerical, TextFieldType.Data))

            If _chkDropoutCells.Checked Then
               currentField.Dropout = currentField.Dropout Or DropoutFlag.CellsDropout
            Else
               currentField.Dropout = currentField.Dropout And Not DropoutFlag.CellsDropout
            End If

            If _chkDropoutWords.Checked Then
               currentField.Dropout = currentField.Dropout Or DropoutFlag.WordsDropout
            Else
               currentField.Dropout = currentField.Dropout And Not DropoutFlag.WordsDropout
            End If

            Exit Select

         Case "Omr"
            If Not (TypeOf currentField Is OmrFormField) Then
               isNewField = True
               currentField = New OmrFormField()
               CopyFieldAttributes(currentField, tempOldField)
            End If

            'set omr field options
            If _rbOMRWithFrame.Checked Then
               TryCast(currentField, OmrFormField).FrameMethod = OcrOmrFrameDetectionMethod.WithFrame
            ElseIf _rbOMRWithoutFrame.Checked Then
               TryCast(currentField, OmrFormField).FrameMethod = OcrOmrFrameDetectionMethod.WithoutFrame
            ElseIf _rbOMRAutoFrame.Checked Then
               TryCast(currentField, OmrFormField).FrameMethod = OcrOmrFrameDetectionMethod.Auto
            End If

            If _rbOMRSensitivityLowest.Checked Then
               TryCast(currentField, OmrFormField).Sensitivity = OcrOmrSensitivity.Lowest
            ElseIf _rbOMRSensitivityLow.Checked Then
               TryCast(currentField, OmrFormField).Sensitivity = OcrOmrSensitivity.Low
            ElseIf _rbOMRSensitivityHigh.Checked Then
               TryCast(currentField, OmrFormField).Sensitivity = OcrOmrSensitivity.High
            ElseIf _rbOMRSensitivityHighest.Checked Then
               TryCast(currentField, OmrFormField).Sensitivity = OcrOmrSensitivity.Highest
            End If
            Exit Select

         Case "Image"
            'set image field options
            If Not (TypeOf currentField Is ImageFormField) Then
               isNewField = True
               currentField = New ImageFormField()
               CopyFieldAttributes(currentField, tempOldField)
            End If
            Exit Select

         Case "Barcode"
            'set barcode field options
            If Not (TypeOf currentField Is BarcodeFormField) Then
               isNewField = True
               currentField = New BarcodeFormField()
               CopyFieldAttributes(currentField, tempOldField)
            End If
            Exit Select

         Case "Table"
            'set Table fields options
            If Not (TypeOf currentField Is TableFormField) Then
               isNewField = True
               currentField = New TableFormField()
               currentField.Tag = automation.CurrentEditObject
               CopyFieldAttributes(currentField, tempOldField)
            Else
               Dim tableField As TableFormField = TryCast(currentField, TableFormField)
               updateColumnsList(tableField)
            End If
            Exit Select

         Case "UnStructured Text"
            If Not (TypeOf currentField Is UnStructuredTextFormField) Then
               isNewField = True
               currentField = New UnStructuredTextFormField()
               CopyFieldAttributes(currentField, tempOldField)
            End If

            'set text field options
            TryCast(currentField, UnStructuredTextFormField).TextFormField.EnableIcr = _chkEnableIcr.Checked
            TryCast(currentField, UnStructuredTextFormField).TextFormField.EnableOcr = _chkEnableOcr.Checked
            TryCast(currentField, UnStructuredTextFormField).TextFormField.Type = If(_rbTextTypeChar.Checked, TextFieldType.Character, If(_rbtextTypeNum.Checked, TextFieldType.Numerical, TextFieldType.Data))

            If _chkDropoutCells.Checked Then
               currentField.Dropout = currentField.Dropout Or DropoutFlag.CellsDropout
            Else
               currentField.Dropout = currentField.Dropout And Not DropoutFlag.CellsDropout
            End If

            If _chkDropoutWords.Checked Then
               currentField.Dropout = currentField.Dropout Or DropoutFlag.WordsDropout
            Else
               currentField.Dropout = currentField.Dropout And Not DropoutFlag.WordsDropout
            End If
            Exit Select
      End Select

      If isNewField Then
         DeleteSelectedField()
         AddField(currentField)
         _lbFields.SelectedItem = currentField.Name
      End If

      'Set field back to userdata in case a new form field type was created.
      automation.CurrentEditObject.Tag = currentField

      Dim newBounds As LeadRect = RestrictZoneBoundsToPage(rasterImageViewer1.Image, BoundsFromAnnotations(automation.CurrentEditObject))
      'Convert to rectangle to get whole number for pixel value

      If TypeOf getSelectedField() Is TableFormField AndAlso TypeOf automation.CurrentEditObject Is AnnHiliteObject Then
         If Not isValidBounds(newBounds, TryCast(currentField, TableFormField)) Then
            Return
         End If

         UpdateTableBounds(TryCast(currentField, TableFormField), newBounds)
      ElseIf Not (TypeOf automation.CurrentEditObject Is AnnTextObject) Then
         currentField.Bounds = New LeadRect(Convert.ToInt32(newBounds.Left), Convert.ToInt32(newBounds.Top), Convert.ToInt32(newBounds.Width), Convert.ToInt32(newBounds.Height))
         currentField.Name = _txtFieldName.Text
      End If
      UpdateControls()
   End Sub

   Private Sub UpdateTableBounds(tableField As TableFormField, newBoundsRounded As LeadRect)
      'Moving table, no need to edit Columns
      If tableField.Bounds.Width = newBoundsRounded.Width Then
      ElseIf newBoundsRounded.Right >= rasterImageViewer1.Image.Width Then
         newBoundsRounded.Width = rasterImageViewer1.Image.Width - newBoundsRounded.Left
      ElseIf tableField.Bounds.Left < newBoundsRounded.Left AndAlso (newBoundsRounded.Left - tableField.Bounds.Left) < tableField.Columns(0).OcrField.Bounds.Width Then
         Dim rc As LeadRect = tableField.Columns(0).OcrField.Bounds
         rc.Width = rc.Width - (newBoundsRounded.Left - tableField.Bounds.Left)
         tableField.Columns(0).OcrField.Bounds = rc
      ElseIf tableField.Bounds.Left >= newBoundsRounded.Left OrElse (tableField.Bounds.Left <= newBoundsRounded.Left AndAlso newBoundsRounded.Left < tableField.Bounds.Left + tableField.Columns(0).OcrField.Bounds.Right) Then
         Dim rc As LeadRect = tableField.Columns(0).OcrField.Bounds
         rc.Width = rc.Width + (tableField.Bounds.Left - newBoundsRounded.Left)
         tableField.Columns(0).OcrField.Bounds = rc
      End If

      tableField.Bounds = New LeadRect(Convert.ToInt32(newBoundsRounded.Left), Convert.ToInt32(newBoundsRounded.Top), Convert.ToInt32(newBoundsRounded.Width), Convert.ToInt32(newBoundsRounded.Height))
      tableField.Name = _txtFieldName.Text
   End Sub

   Private Function isValidBounds(newBoundsRounded As LeadRect, tableField As TableFormField) As Boolean
      If newBoundsRounded.Left >= tableField.Bounds.Right AndAlso newBoundsRounded.Width <> tableField.Bounds.Width OrElse newBoundsRounded.Right <= tableField.Bounds.Left AndAlso newBoundsRounded.Width <> tableField.Bounds.Width OrElse newBoundsRounded.Width <= tableField.Columns(tableField.Columns.Count - 1).OcrField.Bounds.Left AndAlso (newBoundsRounded.Left = tableField.Bounds.Left OrElse newBoundsRounded.Height <> tableField.Bounds.Height) OrElse newBoundsRounded.Left >= tableField.Columns(0).OcrField.Bounds.Right + tableField.Bounds.Left AndAlso (newBoundsRounded.Right = tableField.Bounds.Right OrElse newBoundsRounded.Height <> tableField.Bounds.Height) Then
         Return False
      End If
      Return True
   End Function

   Private Sub _menuItemLanguages_Click(sender As Object, e As EventArgs) Handles _menuItemLanguages.Click
      ' Show the dialog to let the user change the current enabled languages
      Using dlg As New EnableLanguagesDialog(ocrEngine)
         dlg.ShowDialog(Me)
      End Using
   End Sub

   Private Sub _menuItemComponents_Click(sender As Object, e As EventArgs) Handles _menuItemComponents.Click
      ' Show the dialog to let the user see the OCR components installed on this system
      Using dlg As New OcrEngineComponentsDialog(ocrEngine)
         dlg.ShowDialog(Me)
      End Using
   End Sub

   Private Sub _btn_RemoveColumn_Click(sender As Object, e As EventArgs) Handles _btn_RemoveColumn.Click
      Dim index As Integer = _lbColumns.SelectedIndex

      If index = -1 Then
         Return
      End If

      Dim tableField As TableFormField = TryCast(automation.CurrentEditObject.Tag, TableFormField)

      If tableField.Columns.Count = 1 Then
         'If the table contains only one column, delete entire table
         DeleteSelectedField()
         isFieldDirty = True
         UpdateControls()
         Return
      ElseIf index = 0 Then
         'If the deleted column is the first one, shift columns to the left
         tableField.Columns(index + 1).OcrField.Bounds = New LeadRect(0, 0, tableField.Columns(index + 1).OcrField.Bounds.Width + tableField.Columns(index).OcrField.Bounds.Width, tableField.Bounds.Height)
      Else
         'Shift columns to the right
         tableField.Columns(index - 1).OcrField.Bounds = New LeadRect(tableField.Columns(index - 1).OcrField.Bounds.X, 0, tableField.Columns(index - 1).OcrField.Bounds.Width + tableField.Columns(index).OcrField.Bounds.Width, tableField.Bounds.Height)
      End If

      Dim column As TableColumn = tableField.Columns(index)
      automation.Container.Children.Remove(TryCast(column.Tag, AnnObject))
      tableField.Columns.RemoveAt(index)
      isFieldDirty = True
      updateColumnsList(tableField)
      AlignmentTableFields(tableField)
   End Sub

   Private Sub updateColumnsPosition(tableField As TableFormField)
      If tableField IsNot Nothing Then
         Dim rc As LeadRect
         For i As Integer = 0 To tableField.Columns.Count - 1
            rc = tableField.Columns(i).OcrField.Bounds
            rc.Height = tableField.Bounds.Height
            rc.Y = 0

            If i = 0 Then
               rc.X = 0
            Else
               rc.X = tableField.Columns(i - 1).OcrField.Bounds.Right
            End If

            tableField.Columns(i).OcrField.Bounds = rc
         Next

         If tableField.Bounds.Width > tableField.Columns(tableField.Columns.Count - 1).OcrField.Bounds.Left Then
            rc = tableField.Columns(tableField.Columns.Count - 1).OcrField.Bounds
            rc.Width = tableField.Bounds.Width - tableField.Columns(tableField.Columns.Count - 1).OcrField.Bounds.Left
            tableField.Columns(tableField.Columns.Count - 1).OcrField.Bounds = rc
         End If
      End If
   End Sub

   Private Sub updateColumnsList(tableField As TableFormField)
      _lbColumns.Items.Clear()
      _lbColumns.Tag = tableField

      If tableField IsNot Nothing Then
         For i As Integer = 0 To tableField.Columns.Count - 1
            Dim index As Integer = _lbColumns.Items.Add(tableField.Columns(i).OcrField.Name)
         Next
      End If

      _btn_RemoveColumn.Enabled = (_lbColumns.SelectedIndex <> -1)
      _btn_ColumnOptions.Enabled = (_lbColumns.SelectedIndex <> -1)
      _gb_ColumnOcr.Enabled = (_lbColumns.SelectedIndex = -1)
   End Sub

   Private Sub _btn_AddColumn_Click(sender As Object, e As EventArgs) Handles _btn_AddColumn.Click
      Dim fileNameDlg As New FieldNameDlg("Column" + (Me._lbColumns.Items.Count + 1).ToString())
      If fileNameDlg.ShowDialog() <> DialogResult.OK Then
         Return
      End If

      Dim tableField As TableFormField = TryCast(automation.CurrentEditObject.Tag, TableFormField)
      If tableField IsNot Nothing Then
         Dim columnField As OcrFormField = Nothing

         If _rB_ColumnOcr.Checked Then
            columnField = New TextFormField()
         Else
            columnField = New OmrFormField()
         End If

         columnField.Name = fileNameDlg.TextFieldName
         If rasterImageViewer1.Image.Width <= tableField.Bounds.Right Then
            MessageBox.Show("Table's width exceeds the image's width", "Unable to add new column", MessageBoxButtons.OK, MessageBoxIcon.[Error])
            Return
         ElseIf tableField.Bounds.Right + tableField.Columns(tableField.Columns.Count - 1).OcrField.Bounds.Width > rasterImageViewer1.Image.Width Then
            columnField.Bounds = New LeadRect(tableField.Columns(tableField.Columns.Count - 1).OcrField.Bounds.Right, 0, rasterImageViewer1.Image.Width - tableField.Bounds.Right, tableField.Bounds.Height)
         Else
            columnField.Bounds = New LeadRect(tableField.Columns(tableField.Columns.Count - 1).OcrField.Bounds.Right, 0, tableField.Columns(tableField.Columns.Count - 1).OcrField.Bounds.Width, tableField.Bounds.Height)
         End If

         If columnField.Bounds.Right > tableField.Bounds.Width Then
            Dim rect As LeadRect = tableField.Bounds
            rect.Width = columnField.Bounds.Width + columnField.Bounds.X
            tableField.Bounds = rect
         End If

         tableField.Columns.Add(New TableColumn(columnField))
         isFieldDirty = True

         updateColumnsList(tableField)

         AlignmentTableFields(tableField)
      End If
   End Sub

   Private Sub _lbColumns_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _lbColumns.SelectedIndexChanged
      _btn_RemoveColumn.Enabled = (_lbColumns.SelectedIndex <> -1)
      _btn_ColumnOptions.Enabled = (_lbColumns.SelectedIndex <> -1)
      _gb_ColumnOcr.Enabled = (_lbColumns.SelectedIndex <> -1)

      If automation.CurrentEditObject Is Nothing Then
         automation.SelectObject(TryCast(TryCast(_lbColumns.Tag, TableFormField).Tag, AnnObject))
      End If

      Dim tableField As TableFormField = TryCast(automation.CurrentEditObject.Tag, TableFormField)
      If tableField IsNot Nothing AndAlso _lbColumns.SelectedIndex <> -1 Then
         Dim ocrField As OcrFormField = tableField.Columns(_lbColumns.SelectedIndex).OcrField
         If TypeOf ocrField Is TextFormField Then
            _rB_ColumnOcr.Checked = True
         Else
            _rB_ColumnOmr.Checked = True
         End If
      End If
   End Sub

   Private Sub _btn_ColumnOptions_Click(sender As Object, e As EventArgs) Handles _btn_ColumnOptions.Click
      Dim selectedTable As TableFormField = TryCast(getSelectedField(), TableFormField)

      If selectedTable IsNot Nothing Then
         Dim selectedItem As Object = _lbColumns.SelectedItem
         Dim options As New ColumnOptions(ocrEngine.EngineType <> OcrEngineType.LEAD)
         options.Column = selectedTable.Columns(_lbColumns.SelectedIndex)
         options.ShowDialog()
         updateColumnsList(selectedTable)
         AlignmentTableFields(selectedTable)
         isFieldDirty = True
         UpdateControls()
         _lbColumns.SelectedItem = selectedItem
      End If
   End Sub

   Private Sub _chkDropoutWords_CheckedChanged(sender As Object, e As EventArgs)
      isFieldDirty = True
      UpdateField()
   End Sub

   Private Sub _chkDropoutCells_CheckedChanged(sender As Object, e As EventArgs)
      isFieldDirty = True
      UpdateField()
   End Sub

   Private Sub _btn_Rules_Click(sender As Object, e As EventArgs) Handles _btn_Rules.Click
      Dim selectedTable As TableFormField = TryCast(getSelectedField(), TableFormField)

      If selectedTable IsNot Nothing Then
         Dim rulesForm As New TableRulesForm(selectedTable)
         rulesForm.ShowDialog()

         If rulesForm.RulesChanged Then
            isFieldDirty = True
            UpdateControls()
         End If

      End If
   End Sub
#If LEADTOOLS_V19_OR_LATER Then
   Private Sub UpdatePageType()

      If rasterImageList1.ActiveItem Is Nothing Then
         Return
      End If

      Dim options As PageRecognitionOptions = Nothing
      Dim currentPageIndex As Integer = rasterImageList1.Items.IndexOf(rasterImageList1.ActiveItem)
      Dim currentMaster As IMasterForm = GetCurrentMasterForm()
      Dim attributes As FormRecognitionAttributes = currentMaster.ReadAttributes()
      recognitionEngine.OpenMasterForm(attributes)
      options = recognitionEngine.GetPageOptions(attributes, currentPageIndex)
      recognitionEngine.CloseMasterForm(attributes)

      If options IsNot Nothing AndAlso options.PageType = FormsPageType.IDCard Then
         cardItem.Checked = True
         normalItem.Checked = False
         omrItem.Checked = False
      ElseIf options IsNot Nothing AndAlso options.PageType = FormsPageType.Omr Then
         cardItem.Checked = False
         normalItem.Checked = False
         omrItem.Checked = True
      Else
         cardItem.Checked = False
         normalItem.Checked = True
         omrItem.Checked = False
      End If

   End Sub
#End If


   Private Sub PageTypeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles normalItem.Click, cardItem.Click, omrItem.Click
#If LEADTOOLS_V19_OR_LATER Then
      Dim pageType As FormsPageType = FormsPageType.Normal
      If sender Is cardItem Then
         pageType = FormsPageType.IDCard
      ElseIf sender Is omrItem Then
         pageType = FormsPageType.Omr
      End If
#End If

      Dim options As PageRecognitionOptions = Nothing
      Dim currentPageIndex As Integer = rasterImageList1.Items.IndexOf(rasterImageList1.ActiveItem)
      Dim currentMaster As IMasterForm = GetCurrentMasterForm()
      Dim attributes As FormRecognitionAttributes = currentMaster.ReadAttributes()
      recognitionEngine.OpenMasterForm(attributes)
      options = recognitionEngine.GetPageOptions(attributes, currentPageIndex)
      If options Is Nothing Then
         options = New PageRecognitionOptions()
      End If
#If LEADTOOLS_V19_OR_LATER Then
      options.PageType = pageType
      recognitionEngine.SetPageOptions(attributes, currentPageIndex + 1, options)
      If rasterImageList1.ActiveItem IsNot Nothing Then
         recognitionEngine.UpdatePageType(attributes, rasterImageList1.ActiveItem.Image, currentPageIndex + 1)
      End If
#End If
      recognitionEngine.CloseMasterForm(attributes)

      Me.GetCurrentMasterForm().WriteAttributes(attributes)
#If LEADTOOLS_V19_OR_LATER Then
      If pageType = FormsPageType.Omr Then
         cardItem.Checked = False
         normalItem.Checked = False
         omrItem.Checked = True
      ElseIf pageType = FormsPageType.IDCard Then
         cardItem.Checked = True
         normalItem.Checked = False
         omrItem.Checked = False
      Else
         cardItem.Checked = False
         normalItem.Checked = True
         omrItem.Checked = False
      End If

      UpdatePageType()
      UpdateControls()
#End If
   End Sub

   Private Sub _miDetectOmrFields_Click(sender As Object, e As EventArgs) Handles _miDetectOmrFields.Click
      Dim dlg As OmrDetectionDialog = New OmrDetectionDialog(Me, GetCurrentMasterForm(), oldSelectedPageIndex + 1)
      dlg.ShowDialog(Me)
   End Sub

   Public Sub FillDetectedOmrFields(omrFields As List(Of OmrFormField))
      For Each field As OmrFormField In omrFields
         AddField(field)
      Next

      isFieldDirty = True
      UpdateControls()

      rasterImageViewer1.Invalidate()
   End Sub

   Private Sub _miRenameOmrFields_Click(sender As Object, e As EventArgs) Handles _miRenameOmr.Click
      _currentSelectMode = SelectMultiFieldsMode.RenameFields
      DisableInteractiveModes()
      rasterImageViewer1.InteractiveModes.EnableById(_automationInteractiveMode.Id)

      automation.Manager.CurrentObjectId = AnnSelectionObject.SelectObjectId
   End Sub

   Private Sub _miDeleteOmrFields_Click(sender As Object, e As EventArgs) Handles _miDeleteOmrFields.Click
      _currentSelectMode = SelectMultiFieldsMode.DeleteFields
      DisableInteractiveModes()
      rasterImageViewer1.InteractiveModes.EnableById(_automationInteractiveMode.Id)

      automation.Manager.CurrentObjectId = AnnSelectionObject.SelectObjectId
   End Sub

   Private Sub _miSetOmrSensitivity_Click(sender As Object, e As EventArgs) Handles _miSetOmrSensitivity.Click
      _currentSelectMode = SelectMultiFieldsMode.ChangeSensitivity
      DisableInteractiveModes()
      rasterImageViewer1.InteractiveModes.EnableById(_automationInteractiveMode.Id)

      automation.Manager.CurrentObjectId = AnnSelectionObject.SelectObjectId
   End Sub

   Private Sub _rB_Column_CheckedChanged(sender As Object, e As EventArgs) Handles _rB_ColumnOmr.CheckedChanged, _rB_ColumnOcr.CheckedChanged
      If sender IsNot Nothing AndAlso Not TryCast(sender, RadioButton).Checked Then
         Return
      End If

      If _lbColumns.SelectedItem Is Nothing Then
         Return
      End If

      Dim tableField As TableFormField = TryCast(automation.CurrentEditObject.Tag, TableFormField)
      If tableField IsNot Nothing Then
         Dim columnField As TableColumn = Nothing
         Dim index As Integer = -1
         For col As Integer = 0 To tableField.Columns.Count - 1
            Dim column As TableColumn = tableField.Columns(col)
            If column.OcrField.Name.Equals(_lbColumns.SelectedItem.ToString()) Then
               columnField = column
               index = col
               Exit For
            End If
         Next

         If index = -1 Then
            Return
         End If

         If (_rB_ColumnOcr.Checked AndAlso TypeOf columnField.OcrField Is TextFormField) OrElse (_rB_ColumnOmr.Checked AndAlso TypeOf columnField.OcrField Is OmrFormField) Then
            Return
         End If

         Dim tempField As OcrFormField = Nothing

         If _rB_ColumnOcr.Checked Then
            tempField = New TextFormField()
         Else
            tempField = New OmrFormField()
         End If

         tempField.Name = columnField.OcrField.Name
         tempField.Bounds = columnField.OcrField.Bounds

         tableField.Columns(index) = New TableColumn(tempField)
         tableField.Columns(index).Tag = columnField.Tag

         isFieldDirty = True

         updateColumnsList(tableField)

         AlignmentTableFields(tableField)
      End If
   End Sub


   Private Sub _lbSelection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _lbSelection.SelectedIndexChanged
      If rasterImageList1.Items.Count > 0 AndAlso _lbSelection.SelectedIndex <> -1 Then
         _lbFields.SelectedItem = Nothing
         _lbBubble.SelectedItem = Nothing

#If LEADTOOLS_V20_OR_LATER Then
         _lbAnswerArea.SelectedItem = Nothing
         _lbOmrDate.SelectedItem = Nothing
#End If

         Dim selectedObject As AnnObject = automation.CurrentEditObject

         'New field in listbox. 
         For i As Integer = 0 To automation.Container.Children.Count - 1
            Dim obj As SingleSelectionField = TryCast(automation.Container.Children(i).Tag, SingleSelectionField)
            If obj IsNot Nothing AndAlso obj.Name = _lbSelection.Text Then
               selectedObject = automation.Container.Children(i)

               If automation.CurrentEditObject IsNot selectedObject Then
                  automation.SelectObject(selectedObject)
               End If
               Exit For
            End If
         Next

         If TryCast(selectedObject.Tag, SingleSelectionField) IsNot Nothing Then
            Dim obj As SingleSelectionField = TryCast(selectedObject.Tag, SingleSelectionField)

            _tbSelectionLeft.Text = obj.Bounds.Left.ToString()
            _tbSelectionTop.Text = obj.Bounds.Top.ToString()
            _tbSelectionWidth.Text = obj.Bounds.Width.ToString()
            _tbSelectionHeight.Text = obj.Bounds.Height.ToString()
         End If

         UpdateControls()
      Else
         'if (_lbSelection.SelectedIndex == -1)
         _tbSelectionLeft.Text = ""
         _tbSelectionTop.Text = ""
         _tbSelectionWidth.Text = ""
         _tbSelectionHeight.Text = ""
      End If
   End Sub

   Private Sub _lbBubble_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _lbBubble.SelectedIndexChanged
      If rasterImageList1.Items.Count > 0 AndAlso _lbBubble.SelectedIndex <> -1 Then
         _lbFields.SelectedItem = Nothing
         _lbSelection.SelectedItem = Nothing

#If LEADTOOLS_V20_OR_LATER Then
         _lbAnswerArea.SelectedItem = Nothing
         _lbOmrDate.SelectedItem = Nothing
#End If

         Dim selectedObject As AnnObject = automation.CurrentEditObject

         'New field in listbox. 
         For i As Integer = 0 To automation.Container.Children.Count - 1
            Dim obj As BubbleWordField = TryCast(automation.Container.Children(i).Tag, BubbleWordField)
            If obj IsNot Nothing AndAlso obj.Name = _lbBubble.Text Then
               selectedObject = automation.Container.Children(i)

               If automation.CurrentEditObject IsNot selectedObject Then
                  automation.SelectObject(selectedObject)
               End If
               Exit For
            End If
         Next

         If TryCast(selectedObject.Tag, BubbleWordField) IsNot Nothing Then
            Dim obj As BubbleWordField = TryCast(selectedObject.Tag, BubbleWordField)

            _tbBubbleLeft.Text = obj.Bounds.Left.ToString()
            _tbBubbleTop.Text = obj.Bounds.Top.ToString()
            _tbBubbleWidth.Text = obj.Bounds.Width.ToString()
            _tbBubbleHeight.Text = obj.Bounds.Height.ToString()
         End If

         UpdateControls()
      End If

      If _lbBubble.SelectedIndex = -1 Then
         _tbBubbleLeft.Text = ""
         _tbBubbleTop.Text = ""
         _tbBubbleWidth.Text = ""
         _tbBubbleHeight.Text = ""
      End If
   End Sub

   Private Sub _cbHideSelection_CheckedChanged(sender As Object, e As EventArgs) Handles _cbHideSelectionAnn.CheckedChanged
      For Each obj As AnnObject In automation.Container.Children
         Dim singleField As SingleSelectionField = TryCast(obj.Tag, SingleSelectionField)
         If singleField IsNot Nothing AndAlso [String].IsNullOrEmpty(singleField.Parent) Then
            obj.IsVisible = Not _cbHideSelectionAnn.Checked
         End If
      Next

      If _cbHideSelectionAnn.Checked Then
         _cbHideSelectionAnn.Text = "Show Annotations"
      Else
         _cbHideSelectionAnn.Text = "Hide Annotations"
      End If

      rasterImageViewer1.Invalidate()
   End Sub

   Private Sub _cbHideBubbleAnn_CheckedChanged(sender As Object, e As EventArgs) Handles _cbHideBubbleAnn.CheckedChanged
      For Each obj As AnnObject In automation.Container.Children
         Dim singleField As SingleSelectionField = TryCast(obj.Tag, SingleSelectionField)
         If singleField IsNot Nothing AndAlso Not [String].IsNullOrEmpty(singleField.Parent) AndAlso _lbBubble.Items.Contains(singleField.Parent) Then
            obj.IsVisible = Not _cbHideBubbleAnn.Checked
         ElseIf TypeOf obj.Tag Is BubbleWordField AndAlso [String].IsNullOrEmpty(TryCast(obj.Tag, BubbleWordField).Parent) Then
            obj.IsVisible = Not _cbHideBubbleAnn.Checked
         End If
      Next

      If _cbHideBubbleAnn.Checked Then
         _cbHideBubbleAnn.Text = "Show Annotations"
      Else
         _cbHideBubbleAnn.Text = "Hide Annotations"
      End If

      rasterImageViewer1.Invalidate()
   End Sub

   Private Sub _btnEditSelection_Click(sender As Object, e As EventArgs) Handles _btnEditSelection.Click
      Dim selectedObject As AnnObject = automation.CurrentEditObject

      Dim singleSelectionField As SingleSelectionField = TryCast(selectedObject.Tag, SingleSelectionField)

      If singleSelectionField IsNot Nothing Then
         Dim dlg As New SingleSelectionFieldDlg(Me, singleSelectionField)
         If dlg.ShowDialog() = DialogResult.OK Then
            isFieldDirty = True
            UpdateControls()
         End If
      End If
   End Sub

   Public Sub UpdateSingleSelection(oldName As String, singleSelectionField As SingleSelectionField)
      If _lbSelection.Items.Contains(oldName) Then
         _lbSelection.Items.Remove(oldName)
         _lbSelection.Items.Add(singleSelectionField.Name)
         _lbSelection.SelectedIndex = _lbSelection.Items.IndexOf(singleSelectionField.Name)
         rasterImageViewer1.Invalidate()
      End If
   End Sub

   Public Sub UpdateBubbleWord(oldName As String, bubbleWordField As BubbleWordField)
      If _lbBubble.Items.Contains(oldName) Then
         _lbBubble.Items.Remove(oldName)
         _lbBubble.Items.Add(bubbleWordField.Name)
         _lbBubble.SelectedIndex = _lbBubble.Items.IndexOf(bubbleWordField.Name)
         rasterImageViewer1.Invalidate()
      End If
   End Sub


#If LEADTOOLS_V20_OR_LATER Then
   Public Sub UpdateOmrAnswerArea(oldName As String, omrAnswerAreaField As OmrAnswerAreaField)
      If _lbAnswerArea.Items.Contains(oldName) Then
         _lbAnswerArea.Items.Remove(oldName)
         _lbAnswerArea.Items.Add(omrAnswerAreaField.Name)
         _lbAnswerArea.SelectedIndex = _lbAnswerArea.Items.IndexOf(omrAnswerAreaField.Name)
         rasterImageViewer1.Invalidate()
      End If
   End Sub

   Public Sub UpdateOmrDateField(oldName As String, omrDateField As OmrDateField)
      If _lbOmrDate.Items.Contains(oldName) Then
         _lbOmrDate.Items.Remove(oldName)
         _lbOmrDate.Items.Add(omrDateField.Name)
         _lbOmrDate.SelectedIndex = _lbOmrDate.Items.IndexOf(omrDateField.Name)
         rasterImageViewer1.Invalidate()

         SetOmrDateParentName(omrDateField)
      End If
   End Sub
#End If
   Private Sub _btnRemoveSelection_Click(sender As Object, e As EventArgs) Handles _btnRemoveSelection.Click
      Dim selectedObject As AnnObject = automation.CurrentEditObject

      Dim singleSelectionField As SingleSelectionField = TryCast(selectedObject.Tag, SingleSelectionField)

      If singleSelectionField IsNot Nothing Then
         For i As Integer = automation.Container.Children.Count - 1 To 0 Step -1
            Dim field As AnnObject = automation.Container.Children(i)
            If TypeOf field.Tag Is SingleSelectionField AndAlso field.Tag Is singleSelectionField Then
               automation.Container.Children.RemoveAt(i)
            End If
         Next

         _lbSelection.Items.Remove(singleSelectionField.Name)
         If _lbSelection.Items.Count > 0 Then
            _lbSelection.SetSelected(_lbSelection.Items.Count - 1, True)
         End If

         isFieldDirty = True

         rasterImageViewer1.Invalidate()
         UpdateControls()
      End If
   End Sub

   Private Sub _btnEditBubble_Click(sender As Object, e As EventArgs) Handles _btnEditBubble.Click
      Dim selectedObject As AnnObject = automation.CurrentEditObject

      Dim bubbleWordField As BubbleWordField = TryCast(selectedObject.Tag, BubbleWordField)

      If bubbleWordField IsNot Nothing Then
         Dim dlg As New BubbleWordFieldDlg(Me, bubbleWordField)
         If dlg.ShowDialog() = DialogResult.OK Then
            isFieldDirty = True
            UpdateControls()
         End If
      End If
   End Sub


#If LEADTOOLS_V20_OR_LATER Then
   Private Sub RemoveAnswerAreaField(answerAreaField As OmrAnswerAreaField)
      For i As Integer = automation.Container.Children.Count - 1 To 0 Step -1
         Dim field As AnnObject = automation.Container.Children(i)
         If TypeOf field.Tag Is OmrAnswerAreaField AndAlso field.Tag Is answerAreaField Then
            automation.Container.Children.RemoveAt(i)
         ElseIf TypeOf field.Tag Is SingleSelectionField AndAlso TryCast(field.Tag, SingleSelectionField).Parent = answerAreaField.Name Then
            automation.Container.Children.RemoveAt(i)
         End If
      Next

      _lbAnswerArea.Items.Remove(answerAreaField.Name)
      If _lbAnswerArea.Items.Count > 0 Then
         _lbAnswerArea.SetSelected(_lbAnswerArea.Items.Count - 1, True)
      End If
   End Sub

   Private Sub RemoveOmrDateField(omrDateField As OmrDateField)
      For i As Integer = automation.Container.Children.Count - 1 To 0 Step -1
         Dim field As AnnObject = automation.Container.Children(i)
         If TypeOf field.Tag Is OmrDateField AndAlso field.Tag Is omrDateField Then
            automation.Container.Children.RemoveAt(i)
         ElseIf TypeOf field.Tag Is SingleSelectionField AndAlso Not [String].IsNullOrEmpty(TryCast(field.Tag, SingleSelectionField).Parent) AndAlso TryCast(field.Tag, SingleSelectionField).Parent = omrDateField.Name Then
            automation.Container.Children.RemoveAt(i)
         ElseIf TypeOf field.Tag Is BubbleWordField AndAlso Not [String].IsNullOrEmpty(TryCast(field.Tag, BubbleWordField).Parent) AndAlso TryCast(field.Tag, BubbleWordField).Parent = omrDateField.Name Then
            RemoveBubble(TryCast(field.Tag, BubbleWordField))
            i = automation.Container.Children.Count
         End If
      Next

      _lbOmrDate.Items.Remove(omrDateField.Name)
      If _lbOmrDate.Items.Count > 0 Then
         _lbOmrDate.SetSelected(_lbOmrDate.Items.Count - 1, True)
      End If
   End Sub
#End If

   Private Sub RemoveBubble(bubbleWordField As BubbleWordField)
      Dim singleSelectionFields As New List(Of SingleSelectionField)(bubbleWordField.Fields)
      For i As Integer = automation.Container.Children.Count - 1 To 0 Step -1
         Dim field As AnnObject = automation.Container.Children(i)
         If TypeOf field.Tag Is BubbleWordField AndAlso field.Tag Is bubbleWordField Then
            automation.Container.Children.RemoveAt(i)
         ElseIf TypeOf field.Tag Is SingleSelectionField AndAlso Not [String].IsNullOrEmpty(TryCast(field.Tag, SingleSelectionField).Parent) AndAlso (TryCast(field.Tag, SingleSelectionField).Parent = bubbleWordField.Name OrElse singleSelectionFields.Contains(TryCast(field.Tag, SingleSelectionField))) Then
            automation.Container.Children.RemoveAt(i)
         End If
      Next

      _lbBubble.Items.Remove(bubbleWordField.Name)
      If _lbBubble.Items.Count > 0 Then
         _lbBubble.SetSelected(_lbBubble.Items.Count - 1, True)
      End If
   End Sub

   Private Sub _btnRemoveBubble_Click(sender As Object, e As EventArgs) Handles _btnRemoveBubble.Click
      Dim selectedObject As AnnObject = automation.CurrentEditObject

      Dim bubbleWordField As BubbleWordField = TryCast(selectedObject.Tag, BubbleWordField)

      If bubbleWordField IsNot Nothing Then
         RemoveBubble(bubbleWordField)
         isFieldDirty = True

         rasterImageViewer1.Invalidate()
         UpdateControls()
      End If
   End Sub


#If LEADTOOLS_V20_OR_LATER Then
   Private Sub _btnOmrDate_Click(sender As Object, e As EventArgs)
      EnableHighlight(GetType(OmrDateField))
   End Sub

   Private Sub _btnOmrAnswerArea_Click(sender As Object, e As EventArgs)
      EnableHighlight(GetType(OmrAnswerAreaField))
   End Sub


   Private Sub _lbAnswerArea_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _lbAnswerArea.SelectedIndexChanged
      If rasterImageList1.Items.Count > 0 AndAlso _lbAnswerArea.SelectedIndex <> -1 Then
         _lbFields.SelectedItem = Nothing
         _lbBubble.SelectedItem = Nothing
         _lbSelection.SelectedItem = Nothing

         Dim selectedObject As AnnObject = automation.CurrentEditObject

         'New field in listbox. 
         For i As Integer = 0 To automation.Container.Children.Count - 1
            Dim obj As OmrAnswerAreaField = TryCast(automation.Container.Children(i).Tag, OmrAnswerAreaField)
            If obj IsNot Nothing AndAlso obj.Name = _lbAnswerArea.Text Then
               selectedObject = automation.Container.Children(i)

               If automation.CurrentEditObject IsNot selectedObject Then
                  automation.SelectObject(selectedObject)
               End If
               Exit For
            End If
         Next

         If TryCast(selectedObject.Tag, OmrAnswerAreaField) IsNot Nothing Then
            Dim obj As OmrAnswerAreaField = TryCast(selectedObject.Tag, OmrAnswerAreaField)

            _tbAnswerAreaLeft.Text = obj.Bounds.Left.ToString()
            _tbAnswerAreaTop.Text = obj.Bounds.Top.ToString()
            _tbAnswerAreaWidth.Text = obj.Bounds.Width.ToString()
            _tbAnswerAreaHeight.Text = obj.Bounds.Height.ToString()
         End If
      End If

      If _lbAnswerArea.SelectedIndex = -1 Then
         _tbAnswerAreaLeft.Text = ""
         _tbAnswerAreaTop.Text = ""
         _tbAnswerAreaWidth.Text = ""
         _tbAnswerAreaHeight.Text = ""
      End If

      UpdateControls()
   End Sub

   Private Sub _btnRemoveAnswerArea_Click(sender As Object, e As EventArgs) Handles _btnRemoveAnswerArea.Click
      Dim selectedObject As AnnObject = automation.CurrentEditObject

      Dim answerAreaField As OmrAnswerAreaField = TryCast(selectedObject.Tag, OmrAnswerAreaField)

      If answerAreaField IsNot Nothing Then
         RemoveAnswerAreaField(answerAreaField)
         isFieldDirty = True

         rasterImageViewer1.Invalidate()
         UpdateControls()
      End If
   End Sub

   Private Sub _cbHideAnswerAnn_CheckedChanged(sender As Object, e As EventArgs) Handles _cbHideAnswerAnn.CheckedChanged
      For Each obj As AnnObject In automation.Container.Children
         Dim singleField As SingleSelectionField = TryCast(obj.Tag, SingleSelectionField)
         If singleField IsNot Nothing AndAlso Not [String].IsNullOrEmpty(singleField.Parent) AndAlso _lbAnswerArea.Items.Contains(singleField.Parent) Then
            obj.IsVisible = Not _cbHideAnswerAnn.Checked
         ElseIf TypeOf obj.Tag Is OmrAnswerAreaField Then
            obj.IsVisible = Not _cbHideAnswerAnn.Checked
         End If
      Next

      If _cbHideAnswerAnn.Checked Then
         _cbHideAnswerAnn.Text = "Show Annotations"
      Else
         _cbHideAnswerAnn.Text = "Hide Annotations"
      End If

      rasterImageViewer1.Invalidate()
   End Sub

   Private Sub _btnEditAnswerArea_Click(sender As Object, e As EventArgs) Handles _btnEditAnswerArea.Click
      Dim selectedObject As AnnObject = automation.CurrentEditObject

      Dim omrAnswerAreaField As OmrAnswerAreaField = TryCast(selectedObject.Tag, OmrAnswerAreaField)

      If omrAnswerAreaField IsNot Nothing Then
         Dim dlg As New OmrAnswerAreaFieldDlg(Me, omrAnswerAreaField)
         If dlg.ShowDialog() = DialogResult.OK Then
            isFieldDirty = True
            UpdateControls()
         End If
      End If
   End Sub

   Private Sub _btnRemoveOmrDate_Click(sender As Object, e As EventArgs) Handles _btnRemoveOmrDate.Click
      Dim selectedObject As AnnObject = automation.CurrentEditObject

      Dim omrDateField As OmrDateField = TryCast(selectedObject.Tag, OmrDateField)

      If omrDateField IsNot Nothing Then
         RemoveOmrDateField(omrDateField)
         isFieldDirty = True

         rasterImageViewer1.Invalidate()
         UpdateControls()
      End If
   End Sub

   Private Sub _lbOmrDate_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _lbOmrDate.SelectedIndexChanged
      If rasterImageList1.Items.Count > 0 AndAlso _lbOmrDate.SelectedIndex <> -1 Then
         _lbFields.SelectedItem = Nothing
         _lbBubble.SelectedItem = Nothing
         _lbSelection.SelectedItem = Nothing
         _lbAnswerArea.SelectedItem = Nothing

         Dim selectedObject As AnnObject = automation.CurrentEditObject

         'New field in listbox. 
         For i As Integer = 0 To automation.Container.Children.Count - 1
            Dim obj As OmrDateField = TryCast(automation.Container.Children(i).Tag, OmrDateField)
            If obj IsNot Nothing AndAlso obj.Name = _lbOmrDate.Text Then
               selectedObject = automation.Container.Children(i)

               If automation.CurrentEditObject IsNot selectedObject Then
                  automation.SelectObject(selectedObject)
               End If
               Exit For
            End If
         Next

         If TryCast(selectedObject.Tag, OmrDateField) IsNot Nothing Then
            Dim obj As OmrDateField = TryCast(selectedObject.Tag, OmrDateField)

            _tbOmrDateLeft.Text = obj.Bounds.Left.ToString()
            _tbOmrDateTop.Text = obj.Bounds.Top.ToString()
            _tbOmrDateWidth.Text = obj.Bounds.Width.ToString()
            _tbOmrDateHeight.Text = obj.Bounds.Height.ToString()
         End If
      End If

      If _lbOmrDate.SelectedIndex = -1 Then
         _tbOmrDateLeft.Text = ""
         _tbOmrDateTop.Text = ""
         _tbOmrDateWidth.Text = ""
         _tbOmrDateHeight.Text = ""
      End If

      UpdateControls()
   End Sub

   Private Sub _cbHideOmrDateAnn_CheckedChanged(sender As Object, e As EventArgs) Handles _cbHideOmrDateAnn.CheckedChanged
      Dim singleSelectionFields As New List(Of SingleSelectionField)()

      For i As Integer = 0 To automation.Container.Children.Count - 1
         If TypeOf automation.Container.Children(i).Tag Is OmrDateField Then
            singleSelectionFields.Add(TryCast(automation.Container.Children(i).Tag, OmrDateField).MonthField)
            singleSelectionFields.AddRange(TryCast(automation.Container.Children(i).Tag, OmrDateField).DayField.Fields)
            singleSelectionFields.AddRange(TryCast(automation.Container.Children(i).Tag, OmrDateField).YearField.Fields)
         End If
      Next

      For Each obj As AnnObject In automation.Container.Children
         Dim singleField As SingleSelectionField = TryCast(obj.Tag, SingleSelectionField)
         If singleField IsNot Nothing AndAlso ((Not [String].IsNullOrEmpty(singleField.Parent) AndAlso _lbOmrDate.Items.Contains(singleField.Parent)) OrElse singleSelectionFields.Contains(singleField)) Then
            obj.IsVisible = Not _cbHideOmrDateAnn.Checked
         ElseIf TypeOf obj.Tag Is BubbleWordField AndAlso Not [String].IsNullOrEmpty(TryCast(obj.Tag, BubbleWordField).Parent) AndAlso _lbOmrDate.Items.Contains(TryCast(obj.Tag, BubbleWordField).Parent) Then
            obj.IsVisible = Not _cbHideOmrDateAnn.Checked
         ElseIf TypeOf obj.Tag Is OmrDateField Then
            obj.IsVisible = Not _cbHideOmrDateAnn.Checked
         End If
      Next

      If _cbHideOmrDateAnn.Checked Then
         _cbHideOmrDateAnn.Text = "Show Annotations"
      Else
         _cbHideOmrDateAnn.Text = "Hide Annotations"
      End If

      rasterImageViewer1.Invalidate()
   End Sub

   Private Sub _btnEditOmrDate_Click(sender As Object, e As EventArgs) Handles _btnEditOmrDate.Click
      Dim selectedObject As AnnObject = automation.CurrentEditObject

      Dim omrDateField As OmrDateField = TryCast(selectedObject.Tag, OmrDateField)

      If omrDateField IsNot Nothing Then
         Dim dlg As New OmrDateFieldDlg(Me, omrDateField)
         If dlg.ShowDialog() = DialogResult.OK Then
            isFieldDirty = True
            UpdateControls()
         End If
      End If
   End Sub
#End If

#If FOR_DOTNET4 Then
   Private Function CreateFullTextSearchManager(path__1 As String) As IFullTextSearchManager
      Dim fullTextSearchManager As New DiskFullTextSearchManager()
      fullTextSearchManager.IndexDirectory = Path.Combine(path__1, "index")
      Return fullTextSearchManager
   End Function
#End If

   Private Sub _useFullTextSearchButton_Click(sender As Object, e As EventArgs) Handles _useFullTextSearchButton.Click
#If FOR_DOTNET4 Then
      Dim resources As ComponentResourceManager = New ComponentResourceManager(GetType(MainForm))

      If _useFullTextSearchButton.Checked Then
         _useFullTextSearchButton.Image = CType(resources.GetObject("_useFullTextSearchButton_checked.Image"), System.Drawing.Image)
      Else
         _useFullTextSearchButton.Image = CType(resources.GetObject("_useFullTextSearchButton_Unchecked.Image"), System.Drawing.Image)
      End If

      If _useFullTextSearchButton.Checked Then
         recognitionEngine.FullTextSearchManager = CreateFullTextSearchManager(workingRepository.Path)
      End If
#End If
   End Sub

   Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
      target = value
      Return value
   End Function
End Class
