' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Printing
Imports System.Collections
Imports System.ComponentModel
Imports System.Windows.Forms
Imports System.Data
Imports System.Text
Imports System.Threading

Imports Leadtools
Imports Leadtools.Dicom
Imports Leadtools.Codecs
Imports Leadtools.Demos
Imports Leadtools.ImageProcessing
Imports Leadtools.MedicalViewer
Imports Leadtools.ImageProcessing.Color
Imports System.Diagnostics
Imports System.Collections.Generic
Imports System.Runtime.InteropServices
Imports Leadtools.Controls
Imports Leadtools.Demos.Dialogs

Namespace MedicalViewerLayoutDemo
   Partial Public Class MainForm : Inherits Form
      Private _images As Integer
      Private _cellIndex As Integer
      Private WithEvents _medicalViewer As MedicalViewer
      Private _applyToAll As Boolean
      Private _printDocument As PrintDocument
      Private _printImage As RasterImage
      Private _layoutFile As String = String.Empty

      <DllImport("user32.dll")> _
      Shared Function LockWindowUpdate(ByVal hWndLock As IntPtr) As Boolean
      End Function

      Public ReadOnly Property PrintDocument() As PrintDocument
         Get
            Return _printDocument
         End Get
      End Property


      Public Property PrintImage() As RasterImage
         Get
            Return _printImage
         End Get
         Set(ByVal value As RasterImage)
            _printImage = value
         End Set
      End Property

      Private Shared _GlobalCell As MedicalViewerMultiCell

      Public Shared ReadOnly Property GlobalCell() As MedicalViewerMultiCell
         Get
            If _GlobalCell Is Nothing Then
               _GlobalCell = New MedicalViewerMultiCell()
               InitalizeCell(_GlobalCell)
            End If
            Return _GlobalCell
         End Get
      End Property

      <STAThread()> _
      Shared Sub Main()
         
         If Not Support.SetLicense() Then
            Return
         End If

         If RasterSupport.IsLocked(RasterSupportType.Medical) Then
            MessageBox.Show("Medical support must be unlocked for this demo!", "Support Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
         End If

         Application.EnableVisualStyles()
         Application.SetCompatibleTextRenderingDefault(False)
         Application.EnableVisualStyles()
         Application.DoEvents()
         Application.Run(New MainForm())
      End Sub


      Public Sub New()
         InitializeComponent()
         InitClass()
         AddHandler Application.Idle, AddressOf Application_Idle
      End Sub

      Private Sub Application_Idle(ByVal sender As Object, ByVal e As EventArgs)
         Dim designMode As Boolean = Viewer.LayoutOptions.UserMode = MedicalViewerUserMode.Design

         toolStripButtonUserMode.Checked = designMode
         toolStripButtonSelect.Checked = Viewer.LayoutOptions.DesignTool = MedicalViewerDesignTool.Selection
         toolStripButtonDraw.Checked = Viewer.LayoutOptions.DesignTool = MedicalViewerDesignTool.Draw
         toolStripButtonSelect.Enabled = toolStripButtonDraw.Enabled = designMode
      End Sub

      Private Sub InitClass()
         Dim counter As CounterDialog = Nothing
         Try

            If Not PrinterSettings.InstalledPrinters Is Nothing AndAlso PrinterSettings.InstalledPrinters.Count > 0 Then
               _printDocument = New PrintDocument()
               AddHandler _printDocument.BeginPrint, AddressOf _printDocument_BeginPrint
               AddHandler _printDocument.PrintPage, AddressOf _printDocument_PrintPage
               AddHandler _printDocument.EndPrint, AddressOf _printDocument_EndPrint
            Else
               _printDocument = Nothing
            End If
         Catch e1 As Exception
            _printDocument = Nothing
         End Try

         Try
            DicomEngine.Startup()

            Using codecs As New RasterCodecs()
               counter = New CounterDialog(Me, codecs)
               _applyToAll = False

               _medicalViewer = New MedicalViewer(False)

               _medicalViewer.Location = New Point(0, 0)
               _medicalViewer.Dock = DockStyle.Fill
               AddHandler _medicalViewer.Cells.ItemAdded, AddressOf Cells_ItemAdded

               _mainPanel.Controls.Add(_medicalViewer)
            End Using
         Catch ex As Exception
            If Not counter Is Nothing Then
               If counter.Visible Then
                  counter.Close()
               End If
            End If
            MessageBox.Show(ex.Message, ex.Source)
         End Try
      End Sub

      Private Sub Cells_ItemAdded(ByVal sender As Object, ByVal e As MedicalViewerCollectionEventArgs(Of MedicalViewerBaseCell))
         Dim cell As MedicalViewerCell = TryCast(e.Item, MedicalViewerCell)

         InitalizeCell(cell)
         CopyPropertiesFromGlobalCell(cell)
         cell.Tag = _medicalViewer.Cells.Count - 1
         cell.SetTag(0, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData, "Image Box " + cell.Tag.ToString())
         cell.SetTag(0, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, cell.OverlapPriority.ToString())
      End Sub


      Private Shared Sub CopyPropertiesFromGlobalCell(ByVal cell As MedicalViewerCell)
         Dim actionType As MedicalViewerActionType
         Dim button As MedicalViewerMouseButtons
         Dim flags As MedicalViewerActionFlags
         Dim keys As MedicalViewerKeys

         actionType = MedicalViewerActionType.WindowLevel
         Do While actionType <= MedicalViewerActionType.Alpha
            button = GlobalCell.GetActionButton(actionType)
            flags = GlobalCell.GetActionFlags(actionType)

            If button <> MedicalViewerMouseButtons.None Then
               cell.SetAction(actionType, button, flags)
            End If

            keys = GlobalCell.GetActionKeys(actionType)
            cell.SetActionKeys(actionType, keys)

            actionType = CType(CType(actionType, Integer) + 1, MedicalViewerActionType)
         Loop

         Dim windowLevelAction As MedicalViewerWindowLevel = CType(GlobalCell.GetActionProperties(MedicalViewerActionType.WindowLevel), MedicalViewerWindowLevel)

         Dim windowLevel As MedicalViewerWindowLevel = New MedicalViewerWindowLevel()
         windowLevel.ActionCursor = windowLevelAction.ActionCursor
         windowLevel.CircularMouseMove = windowLevelAction.CircularMouseMove
         windowLevel.Sensitivity = windowLevelAction.Sensitivity

         cell.SetActionProperties(MedicalViewerActionType.WindowLevel, windowLevel)


         Dim AlphaAction As MedicalViewerAlpha = CType(GlobalCell.GetActionProperties(MedicalViewerActionType.Alpha), MedicalViewerAlpha)

         Dim Alpha As MedicalViewerAlpha = New MedicalViewerAlpha()
         Alpha.ActionCursor = AlphaAction.ActionCursor
         Alpha.CircularMouseMove = AlphaAction.CircularMouseMove
         Alpha.Sensitivity = AlphaAction.Sensitivity

         cell.SetActionProperties(MedicalViewerActionType.Alpha, Alpha)

         Dim ScaleAction As MedicalViewerScale = CType(GlobalCell.GetActionProperties(MedicalViewerActionType.Scale), MedicalViewerScale)

         Dim Scale As MedicalViewerScale = New MedicalViewerScale()
         Scale.ActionCursor = ScaleAction.ActionCursor
         Scale.CircularMouseMove = ScaleAction.CircularMouseMove
         Scale.Sensitivity = ScaleAction.Sensitivity

         cell.SetActionProperties(MedicalViewerActionType.Scale, Scale)


         Dim StackAction As MedicalViewerStack = CType(GlobalCell.GetActionProperties(MedicalViewerActionType.Stack), MedicalViewerStack)

         Dim Stack As MedicalViewerStack = New MedicalViewerStack()
         Stack.ActionCursor = StackAction.ActionCursor
         Stack.CircularMouseMove = StackAction.CircularMouseMove
         Stack.Sensitivity = StackAction.Sensitivity

         cell.SetActionProperties(MedicalViewerActionType.Stack, Stack)

         Dim offsetAction As MedicalViewerOffset = CType(GlobalCell.GetActionProperties(MedicalViewerActionType.Offset), MedicalViewerOffset)

         Dim offset As MedicalViewerOffset = New MedicalViewerOffset()
         offset.ActionCursor = offsetAction.ActionCursor
         offset.CircularMouseMove = offsetAction.CircularMouseMove
         offset.Sensitivity = offsetAction.Sensitivity

         cell.SetActionProperties(MedicalViewerActionType.Offset, offset)

         Dim magnifyAction As MedicalViewerMagnifyGlass = CType(GlobalCell.GetActionProperties(MedicalViewerActionType.MagnifyGlass), MedicalViewerMagnifyGlass)
         cell.SetActionProperties(MedicalViewerActionType.MagnifyGlass, magnifyAction)

         Dim index As Integer = 0
         Dim icon As MedicalViewerIcon
         Dim virtualCellIcon As MedicalViewerIcon

         index = 0
         Do While index < cell.Titlebar.Icons.Length
            icon = cell.Titlebar.Icons(index)
            virtualCellIcon = cell.Titlebar.Icons(index)

            If icon.Visible <> virtualCellIcon.Visible Then
               icon.Visible = virtualCellIcon.Visible
            End If

            If icon.Color <> virtualCellIcon.Color Then
               icon.Color = virtualCellIcon.Color
            End If

            If icon.ColorPressed <> virtualCellIcon.ColorPressed Then
               icon.ColorPressed = virtualCellIcon.ColorPressed
            End If

            If icon.ColorHover <> virtualCellIcon.ColorHover Then
               icon.ColorHover = virtualCellIcon.ColorHover
            End If

            If icon.ReadOnly <> virtualCellIcon.ReadOnly Then
               icon.ReadOnly = virtualCellIcon.ReadOnly
            End If
            index += 1
         Loop

         If cell.CellBackColor <> _GlobalCell.CellBackColor Then
            cell.CellBackColor = _GlobalCell.CellBackColor
         End If

         If cell.TextColor <> _GlobalCell.TextColor Then
            cell.TextColor = _GlobalCell.TextColor
         End If

         If cell.TextShadowColor <> _GlobalCell.TextShadowColor Then
            cell.TextShadowColor = _GlobalCell.TextShadowColor
         End If

         If cell.ActiveBorderColor <> _GlobalCell.ActiveBorderColor Then
            cell.ActiveBorderColor = _GlobalCell.ActiveBorderColor
         End If

         If cell.NonActiveBorderColor <> _GlobalCell.NonActiveBorderColor Then
            cell.NonActiveBorderColor = _GlobalCell.NonActiveBorderColor
         End If

         If cell.ActiveSubCellBorderColor <> _GlobalCell.ActiveSubCellBorderColor Then
            cell.ActiveSubCellBorderColor = _GlobalCell.ActiveSubCellBorderColor
         End If

         If cell.RulerInColor <> _GlobalCell.RulerInColor Then
            cell.RulerInColor = _GlobalCell.RulerInColor
         End If

         If cell.RulerOutColor <> _GlobalCell.RulerOutColor Then
            cell.RulerOutColor = _GlobalCell.RulerOutColor
         End If

         If cell.Titlebar.UseCustomColor <> _GlobalCell.Titlebar.UseCustomColor Then
            cell.Titlebar.UseCustomColor = _GlobalCell.Titlebar.UseCustomColor
         End If

         If cell.Titlebar.Color <> _GlobalCell.Titlebar.Color Then
            cell.Titlebar.Color = _GlobalCell.Titlebar.Color
         End If

         If cell.Titlebar.Visible <> _GlobalCell.Titlebar.Visible Then
            cell.Titlebar.Visible = _GlobalCell.Titlebar.Visible
         End If

         If cell.TextQuality <> _GlobalCell.TextQuality Then
            cell.TextQuality = _GlobalCell.TextQuality
         End If

         If cell.RulerStyle <> _GlobalCell.RulerStyle Then
            cell.RulerStyle = _GlobalCell.RulerStyle
         End If

         If cell.ShowCellScroll <> _GlobalCell.ShowCellScroll Then
            cell.ShowCellScroll = _GlobalCell.ShowCellScroll
         End If

         If cell.ShowFreezeText <> _GlobalCell.ShowFreezeText Then
            cell.ShowFreezeText = _GlobalCell.ShowFreezeText
         End If

         If cell.PaintingMethod <> _GlobalCell.PaintingMethod Then
            cell.PaintingMethod = _GlobalCell.PaintingMethod
         End If

         If cell.MeasurementUnit <> _GlobalCell.MeasurementUnit Then
            cell.MeasurementUnit = _GlobalCell.MeasurementUnit
         End If

         If cell.BorderStyle <> _GlobalCell.BorderStyle Then
            cell.BorderStyle = _GlobalCell.BorderStyle
         End If
      End Sub

      Private Shared Sub InitalizeCell(ByVal cell As MedicalViewerCell)
         Dim medicalKeys As MedicalViewerKeys = New MedicalViewerKeys()

         cell.AddAction(MedicalViewerActionType.WindowLevel)
         cell.AddAction(MedicalViewerActionType.Scale)
         cell.AddAction(MedicalViewerActionType.Offset)
         cell.AddAction(MedicalViewerActionType.Stack)
         cell.AddAction(MedicalViewerActionType.MagnifyGlass)
         cell.AddAction(MedicalViewerActionType.Alpha)
         cell.SetAction(MedicalViewerActionType.WindowLevel, MedicalViewerMouseButtons.Left, MedicalViewerActionFlags.Active)
         cell.SetAction(MedicalViewerActionType.Offset, MedicalViewerMouseButtons.Right, MedicalViewerActionFlags.Active)
         cell.SetAction(MedicalViewerActionType.Scale, MedicalViewerMouseButtons.Middle, MedicalViewerActionFlags.Active)
         cell.SetAction(MedicalViewerActionType.Stack, MedicalViewerMouseButtons.Wheel, MedicalViewerActionFlags.Active)

         medicalKeys.MouseDown = Keys.Down
         medicalKeys.MouseUp = Keys.Up
         medicalKeys.MouseLeft = Keys.Left
         medicalKeys.MouseRight = Keys.Right
         cell.SetActionKeys(MedicalViewerActionType.Offset, medicalKeys)

         medicalKeys.Modifiers = MedicalViewerModifiers.Ctrl
         cell.SetActionKeys(MedicalViewerActionType.WindowLevel, medicalKeys)
         medicalKeys.Modifiers = MedicalViewerModifiers.None
         medicalKeys.MouseDown = Keys.PageDown
         medicalKeys.MouseUp = Keys.PageUp
         cell.SetActionKeys(MedicalViewerActionType.Stack, medicalKeys)
         medicalKeys.MouseDown = Keys.Add
         medicalKeys.MouseUp = Keys.Subtract
         cell.SetActionKeys(MedicalViewerActionType.Scale, medicalKeys)
      End Sub

      Private Sub CreateLayout(ByVal l As Single(), ByVal t As Single(), ByVal r As Single(), ByVal b As Single())
         _medicalViewer.Cells.Clear()
         Try
            LockWindowUpdate(_medicalViewer.Handle)
            Dim i As Integer = 0
            Do While i < l.Length
               Dim cell As MedicalViewerMultiCell = New MedicalViewerMultiCell(Nothing, False, 1, 1)

               cell.LayoutPosition = New MedicalViewerLayoutPosition(l(i), t(i), r(i), b(i))

               Try
                  cell.FitImageToCell = True
                  _medicalViewer.Cells.Add(cell)
                  cell.Tag = _medicalViewer.Cells.Count
                  cell.SetTag(0, MedicalViewerTagAlignment.TopLeft, MedicalViewerTagType.UserData, "Image Box" & cell.Tag.ToString())
                  cell.SetTag(0, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.UserData, cell.OverlapPriority.ToString())
               Catch e As Exception
                  MessageBox.Show(e.Message)
               End Try
               i += 1
            Loop
         Finally
            LockWindowUpdate(IntPtr.Zero)
         End Try
      End Sub

      Private Sub _printDocument_BeginPrint(ByVal sender As Object, ByVal e As PrintEventArgs)
         ' This demo will print one page at a time, so no need to re-start the print page number
      End Sub

      Private Sub _printDocument_PrintPage(ByVal sender As Object, ByVal e As PrintPageEventArgs)
         Dim colorResolutionCommand As ColorResolutionCommand = New ColorResolutionCommand(ColorResolutionCommandMode.InPlace, 24, RasterByteOrder.Bgr, RasterDitheringMethod.None, ColorResolutionCommandPaletteFlags.None, Nothing)
         colorResolutionCommand.Run(PrintImage)

         ' Get the print document object
         Dim document As PrintDocument = TryCast(sender, PrintDocument)

         ' Create an new LEADTOOLS image printer class
         Dim printer As RasterImagePrinter = New RasterImagePrinter()

         ' Set the document object so page calculations can be performed
         printer.PrintDocument = document

         ' We want to fit and center the image into the maximum print area
         printer.SizeMode = RasterPaintSizeMode.FitAlways
         printer.HorizontalAlignMode = RasterPaintAlignMode.Center
         printer.VerticalAlignMode = RasterPaintAlignMode.Center

         ' Account for FAX images that may have different horizontal and vertical resolution
         printer.UseDpi = True

         ' Print the whole image
         printer.ImageRectangle = Rectangle.Empty

         ' Use maximum page dimension ignoring the margins, this will be equivalant of printing
         ' using Windows Photo Gallery
         printer.PageRectangle = RectangleF.Empty
         printer.UseMargins = False

         ' Print the current page
         printer.Print(PrintImage, PrintImage.Page, e)

         ' Inform the printer that we have no more pages to print
         e.HasMorePages = False
      End Sub

      Private Sub _printDocument_EndPrint(ByVal sender As Object, ByVal e As PrintEventArgs)
         ' Nothing to do here
      End Sub

      Public Property ApplyToAll() As Boolean
         Get
            Return _applyToAll
         End Get
         Set(ByVal value As Boolean)
            _applyToAll = value
         End Set
      End Property

      Public Property CellIndex() As Integer
         Get
            Return _cellIndex
         End Get
         Set(ByVal value As Integer)
            _cellIndex = value
         End Set
      End Property

      Public Property Images() As Integer
         Get
            Return _images
         End Get

         Set(ByVal value As Integer)
            _images = value
         End Set
      End Property

      Public ReadOnly Property Viewer() As MedicalViewer
         Get
            Return _medicalViewer
         End Get
      End Property

      Public Sub RemoveSelectedCells()
         Dim currentCellIndex As Integer = 0
         Do While currentCellIndex < Viewer.Cells.Count
            If Viewer.Cells(currentCellIndex).Selected Then
               Viewer.Cells.RemoveAt(currentCellIndex)
            Else
               currentCellIndex += 1
            End If
         Loop
      End Sub

      Private Sub _miEditRemoveSelectedCells_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miEditRemoveSelectedCells.Click
         RemoveSelectedCells()
      End Sub

      Private Sub _miEditSelectAll_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miEditSelectAll.Click
         _medicalViewer.Cells.SelectAll(True)
      End Sub

      Private Sub _miEditDeselectAll_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miEditDeselectAll.Click
         _medicalViewer.Cells.SelectAll(False)
      End Sub

      Private Sub _miEditInvertSelection_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miEditInvertSelection.Click
         _medicalViewer.Cells.InvertSelection()
      End Sub

      Private Function ShowViewerDialogs(ByVal Dialog As Form) As DialogResult
         Return Dialog.ShowDialog(Me)
      End Function

      ' Open "LEAD Open File Dialog" and return the selected image
      Private Function LoadImage() As RasterImage
         Dim loader As ImageFileLoader = New ImageFileLoader()

         Try
            loader.ShowLoadPagesDialog = True

            Using codecs As New RasterCodecs()
               If loader.Load(Me, codecs, False) > 0 Then
                  Dim counter As CounterDialog = New CounterDialog(Me, codecs)
                  _images = 1
                  counter.Show(Me)
                  counter.Update()
                  Return codecs.Load(loader.FileName, 0, CodecsLoadByteOrder.BgrOrGray, loader.FirstPage, loader.LastPage)
               End If
            End Using
         Catch ex As Exception
            Messager.ShowFileOpenError(Me, loader.FileName, ex)
         End Try

         Return Nothing
      End Function


      Private Sub _fileMenuItem_exit_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _fileMenuItem_exit.Click
         Close()
      End Sub

      Private Sub _miEditFreezeCell_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miEditFreezeCell.Click
         ShowViewerDialogs(New FreezeCellDialog(Me))
      End Sub

      Private Sub _miEditToggleFreeze_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miEditToggleFreeze.Click
         For Each cell As MedicalViewerCell In _medicalViewer.Cells
            If cell.Selected Then
               cell.Frozen = Not cell.Frozen
            End If
         Next cell
      End Sub

      Private Sub _miPropertiesViewerProperties_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miPropertiesViewerProperties.Click
         ShowViewerDialogs(New ViewerPropertiesDialog(Me, GlobalCell))
      End Sub

      Private Sub _miPropertiesCellProperties_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miPropertiesCellProperties.Click
         Dim i As Integer = 0
         Dim cell As MedicalViewerMultiCell = Nothing
         Do While (cell Is Nothing) AndAlso i < Me.Viewer.Cells.Count
            If Me.Viewer.Cells(i).Selected Then
               cell = CType(Me.Viewer.Cells(i), MedicalViewerMultiCell)
            Else
               i += 1
            End If
         Loop
         ShowViewerDialogs(New CellPropertiesDialog(Me, cell))
      End Sub

      Private Sub _miActionWindowLevelSet_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miActionWindowLevelSet.Click
         ShowViewerDialogs(New SetActionDialog(Me, _medicalViewer, GlobalCell, MedicalViewerActionType.WindowLevel))
      End Sub

      Private Sub _miActionAlphaSet_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miActionAlphaSet.Click
         ShowViewerDialogs(New SetActionDialog(Me, _medicalViewer, GlobalCell, MedicalViewerActionType.Alpha))
      End Sub

      Private Sub _miActionScaleSet_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miActionScaleSet.Click
         ShowViewerDialogs(New SetActionDialog(Me, _medicalViewer, GlobalCell, MedicalViewerActionType.Scale))
      End Sub

      Private Sub _miMagnifySet_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miMagnifySet.Click
         ShowViewerDialogs(New SetActionDialog(Me, _medicalViewer, GlobalCell, MedicalViewerActionType.MagnifyGlass))
      End Sub

      Private Sub _miActionStackSet_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miActionStackSet.Click
         ShowViewerDialogs(New SetActionDialog(Me, _medicalViewer, GlobalCell, MedicalViewerActionType.Stack))
      End Sub

      Private Sub _miActionOffsetSet_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miActionOffsetSet.Click
         ShowViewerDialogs(New SetActionDialog(Me, _medicalViewer, GlobalCell, MedicalViewerActionType.Offset))
      End Sub

      Private Sub _miActionWindowLevelCustomize_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miActionWindowLevelCustomize.Click
         ShowViewerDialogs(New WindowLevelPropertiesDialog(Me, GetSelectedCell()))
      End Sub

      ' This method add a key list to the specifid combo box
      Public Sub AddKeysToCombo(ByVal keyComboBox As ComboBox, ByVal currentKey As Keys)
         Dim keys__1 As Keys() = {Keys.None, Keys.Space, Keys.PageUp, Keys.PageDown, Keys.[End], Keys.Home, _
            Keys.Left, Keys.Up, Keys.Right, Keys.Down, Keys.PrintScreen, Keys.Insert, _
            Keys.Delete, Keys.D0, Keys.D1, Keys.D2, Keys.D3, Keys.D4, _
            Keys.D5, Keys.D6, Keys.D7, Keys.D8, Keys.D9, Keys.A, _
            Keys.B, Keys.C, Keys.D, Keys.E, Keys.F, Keys.G, _
            Keys.H, Keys.I, Keys.J, Keys.K, Keys.L, Keys.M, _
            Keys.N, Keys.O, Keys.P, Keys.Q, Keys.R, Keys.S, _
            Keys.T, Keys.U, Keys.V, Keys.W, Keys.X, Keys.Y, _
            Keys.Z, Keys.NumPad0, Keys.NumPad1, Keys.NumPad2, Keys.NumPad3, Keys.NumPad4, _
            Keys.NumPad5, Keys.NumPad6, Keys.NumPad7, Keys.NumPad8, Keys.NumPad9, Keys.Multiply, _
            Keys.Add, Keys.Subtract, Keys.[Decimal], Keys.F1, Keys.F2, Keys.F3, _
            Keys.F4, Keys.F5, Keys.F6, Keys.F7, Keys.F8, Keys.F9, _
            Keys.F10, Keys.F11, Keys.F12}

         For Each key As Keys In keys__1
            keyComboBox.Items.Add(key)
         Next

         keyComboBox.SelectedIndex = keyComboBox.Items.IndexOf(currentKey)
      End Sub

      Public Sub AddModifiersToCombo(ByVal keyComboBox As ComboBox, ByVal currentKey As MedicalViewerModifiers)
         Dim modifiers As MedicalViewerModifiers() = {MedicalViewerModifiers.None, MedicalViewerModifiers.Ctrl, MedicalViewerModifiers.Alt}

         For Each modifier As MedicalViewerModifiers In modifiers
            keyComboBox.Items.Add(modifier)
         Next modifier

         keyComboBox.SelectedIndex = keyComboBox.Items.IndexOf(currentKey)
      End Sub

      Public Function GetIndex(ByVal combo As ComboBox, ByVal text As NumericTextBox) As Integer
         If combo.Text = "None" Then
            Return -3
         ElseIf combo.Text = "Selected" Then
            Return -2
         ElseIf combo.Text = "All" Then
            Return -1
         Else
            Return text.Value
         End If
      End Function

      Public Function IsThereASelectedCell() As Boolean
         Dim index As Integer = 0
         Do While index < Viewer.Cells.Count
            If Viewer.Cells(index).Selected Then
               Return True
            Else
               index += 1
            End If
         Loop
         Return False
      End Function

      Public Function SearchForFirstSelected() As MedicalViewerCell
         For Each cell As MedicalViewerCell In Viewer.Cells
            If cell.Selected Then
               Return cell
            End If
         Next cell
         Return Nothing
      End Function

      Private Sub _miActionScaleCustomizeScale_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miActionScaleCustomizeScale.Click
         ShowViewerDialogs(New ScalePropertiesDialog(Me, GetSelectedCell()))
      End Sub

      Private Sub _miActionMagnifyCustomizeMagnify_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miActionMagnifyCustomizeMagnify.Click
         ShowViewerDialogs(New MagnifyGlassProperties(Me, GetSelectedCell()))
      End Sub

      Private Sub _miActionStackCustomizeStack_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miActionStackCustomizeStack.Click
         ShowViewerDialogs(New StackPropertiesDialog(Me, GetSelectedCell()))
      End Sub

      Private Sub _miActionOffsetCustomizeOffset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miActionOffsetCustomizeOffset.Click
         ShowViewerDialogs(New OffsetPropertiesDialog(Me, GetSelectedCell()))
      End Sub

      Private Sub _miEditAnimation_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miEditAnimation.Click
         ShowViewerDialogs(New AnimationDialog(SearchForFirstSelected()))
      End Sub

      Public Shared Sub ShowColorDialog(ByVal label As Label)
         Dim colorDlg As ColorDialog = New ColorDialog()

         colorDlg.Color = label.BackColor
         If colorDlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            label.BackColor = colorDlg.Color
         End If
      End Sub

      Private Sub _editMenuItem_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles _editMenuItem.DropDownOpening
         Dim selected As Boolean = GetSelectedCell() IsNot Nothing
         Dim enabled As Boolean = Viewer.Cells.Count <> 0

         _miEditAnimation.Enabled = enabled AndAlso selected AndAlso _medicalViewer.LayoutOptions.UserMode = MedicalViewerUserMode.Run AndAlso GetSelectedCell().Image IsNot Nothing AndAlso GetSelectedCell().Image.PageCount > 1
         _miEditFreezeCell.Enabled = enabled AndAlso _medicalViewer.LayoutOptions.UserMode = MedicalViewerUserMode.Run
         _miEditToggleFreeze.Enabled = enabled AndAlso selected AndAlso _medicalViewer.LayoutOptions.UserMode = MedicalViewerUserMode.Run
         _miEditSelectAll.Enabled = enabled
         _miEditDeselectAll.Enabled = enabled AndAlso selected
         _miEditInvertSelection.Enabled = enabled AndAlso _medicalViewer.LayoutOptions.UserMode = MedicalViewerUserMode.Run
         _miEditRemoveCell.Enabled = enabled AndAlso _medicalViewer.LayoutOptions.UserMode = MedicalViewerUserMode.Run
         _miEditRemoveSelectedCells.Enabled = enabled AndAlso _medicalViewer.LayoutOptions.UserMode = MedicalViewerUserMode.Run AndAlso selected

      End Sub

      Private Sub _miHelpAbout_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miHelpAbout.Click
         Using aboutDialog As New AboutDialog("Medical Viewer (Layout)", ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using
      End Sub

      Private Sub _propertiesMenuItem_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles _propertiesMenuItem.DropDownOpening
         Dim enabled As Boolean = Viewer.Cells.Count <> 0
         _miPropertiesCellProperties.Enabled = enabled
      End Sub

      Private Sub _fileMenuItem_DropDownOpening(ByVal sender As Object, ByVal e As System.EventArgs) Handles _fileMenuItem.DropDownOpening
         saveLayoutToolStripMenuItem.Enabled = Viewer.Cells.Count > 0
         insertImageToolStripMenuItem.Enabled = IsThereASelectedCell() AndAlso _medicalViewer.LayoutOptions.UserMode = MedicalViewerUserMode.Run
         _printCellMenuItem.Enabled = IsThereASelectedCell() AndAlso (Not GetSelectedCell().Image Is Nothing)
      End Sub

      Private Sub _miActionAlphaCustomizeAlpha_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miActionAlphaCustomizeAlpha.Click
         ShowViewerDialogs(New AlphaPropertiesDialog(Me, GetSelectedCell()))
      End Sub

      Private Sub _miEditRemoveCell_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _miEditRemoveCell.Click
         ShowViewerDialogs(New RemoveCellDialog(Me))
      End Sub

      Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
         DicomEngine.Shutdown()
      End Sub

      Private Sub _printCellMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _printCellMenuItem.Click
         ShowViewerDialogs(New PrintCellDialog(Me, GetSelectedCell()))
      End Sub

      Private Sub bW4ToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bW4ToolStripMenuItem.Click
         CreateLayout(New Single() {0.049217F, 0.2774049F, 0.5055928F, 0.7337807F}, New Single() {0.8248175F, 0.8248175F, 0.8248175F, 0.8248175F}, New Single() {0.246085F, 0.4742729F, 0.7024608F, 0.9306487F}, New Single() {0.4233577F, 0.4233577F, 0.4233577F, 0.4233577F})
      End Sub

      Private Sub fMX18ToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles fMX18ToolStripMenuItem.Click
         CreateLayout(New Single() {0.03412463F, 0.1928783F, 0.3531157F, 0.458457F, 0.5608308F, 0.6617211F, 0.8204748F, 0.03412463F, 0.1928783F, 0.6617211F, 0.8204748F, 0.03412463F, 0.1928783F, 0.3531157F, 0.458457F, 0.5608308F, 0.6617211F, 0.8204748F}, New Single() {0.9457364F, 0.9457364F, 0.9457364F, 0.9457364F, 0.9457364F, 0.9457364F, 0.9457364F, 0.6666666F, 0.6666666F, 0.6666666F, 0.6666666F, 0.3992248F, 0.3953488F, 0.4767442F, 0.4767442F, 0.4767442F, 0.3992248F, 0.3953488F}, New Single() {0.1646884F, 0.3234421F, 0.4272997F, 0.5326409F, 0.6350148F, 0.7922848F, 0.9510386F, 0.1646884F, 0.3234421F, 0.7922848F, 0.9510386F, 0.1646884F, 0.3234421F, 0.4272997F, 0.5326409F, 0.6350148F, 0.7922848F, 0.9510386F}, New Single() {0.7325581F, 0.7325581F, 0.6511628F, 0.6511628F, 0.6511628F, 0.7325581F, 0.7325581F, 0.4534883F, 0.4534883F, 0.4534883F, 0.4534883F, 0.1860465F, 0.1821706F, 0.1821706F, 0.1821706F, 0.1821706F, 0.1860465F, 0.1821706F})
      End Sub

      Private Sub bW2ToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles bW2ToolStripMenuItem.Click
         CreateLayout(New Single() {0.06F, 0.55F}, New Single() {0.75F, 0.75F}, New Single() {0.45F, 0.94F}, New Single() {0.25F, 0.25F})
      End Sub

      Private Sub fMX20ToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles fMX20ToolStripMenuItem.Click
         CreateLayout(New Single() {0.04262673F, 0.1831797F, 0.3087558F, 0.3847926F, 0.4608295F, 0.5368664F, 0.6129032F, 0.6947005F, 0.8352535F, 0.04262673F, 0.1831797F, 0.6947005F, 0.8352535F, 0.04262673F, 0.1831797F, 0.3778802F, 0.4608295F, 0.5437788F, 0.6947005F, 0.8352535F}, New Single() {0.9014925F, 0.9014925F, 0.8477612F, 0.8477612F, 0.8477612F, 0.8477612F, 0.8477612F, 0.9014925F, 0.9014925F, 0.6507462F, 0.6507462F, 0.6507462F, 0.6507462F, 0.4F, 0.4F, 0.5402985F, 0.5402985F, 0.5402985F, 0.4F, 0.4F}, New Single() {0.156682F, 0.297235F, 0.3778802F, 0.4539171F, 0.5299539F, 0.6059908F, 0.6820276F, 0.8087558F, 0.9493088F, 0.156682F, 0.297235F, 0.8087558F, 0.9493088F, 0.156682F, 0.297235F, 0.4470046F, 0.5299539F, 0.6129032F, 0.8087558F, 0.9493088F}, New Single() {0.7014925F, 0.7014925F, 0.5582089F, 0.5582089F, 0.5582089F, 0.5582089F, 0.5582089F, 0.7014925F, 0.7014925F, 0.4507463F, 0.4507463F, 0.4507463F, 0.4507463F, 0.2F, 0.2F, 0.2507463F, 0.2507463F, 0.2507463F, 0.2F, 0.2F})
      End Sub

      Private Sub layoutToolStripMenuItem_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles layoutToolStripMenuItem.DropDownOpening
         designToolStripMenuItem.Checked = Viewer.LayoutOptions.UserMode = MedicalViewerUserMode.Design
         gridToolStripMenuItem.Enabled = Viewer.LayoutOptions.UserMode = MedicalViewerUserMode.Design
         toolToolStripMenuItem.Enabled = Viewer.LayoutOptions.UserMode = MedicalViewerUserMode.Design
         allowCellsToOverlappToolStripMenuItem.Checked = Viewer.LayoutOptions.AllowOverlappingCells
         showLocationToolStripMenuItem.Checked = Viewer.LayoutOptions.ShowPosition
      End Sub

      Private Sub designToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles designToolStripMenuItem.Click, toolStripButtonUserMode.Click
         If _medicalViewer.LayoutOptions.UserMode = MedicalViewerUserMode.Run Then
            _medicalViewer.LayoutOptions.UserMode = MedicalViewerUserMode.Design
         Else
            _medicalViewer.LayoutOptions.UserMode = MedicalViewerUserMode.Run
         End If
         If _medicalViewer.LayoutOptions.UserMode = MedicalViewerUserMode.Run Then
            selectionToolStripMenuItem_Click(Me, EventArgs.Empty)
         End If
         _medicalViewer.Refresh()
      End Sub

      Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
         toolStripButtonOverlap.Checked = Viewer.LayoutOptions.AllowOverlappingCells
            toolStripButtonShowPosition.Checked = Viewer.LayoutOptions.ShowPosition
            SetDefaultLayout()
      End Sub

      Private Sub showToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles showToolStripMenuItem.Click
         showToolStripMenuItem.Checked = Not showToolStripMenuItem.Checked
         _medicalViewer.LayoutOptions.ShowGrid = showToolStripMenuItem.Checked
      End Sub

      Private Sub snapToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles snapToolStripMenuItem.Click
         snapToolStripMenuItem.Checked = Not snapToolStripMenuItem.Checked
         _medicalViewer.LayoutOptions.SnapToGrid = snapToolStripMenuItem.Checked
      End Sub

      Private Sub gridToolStripMenuItem_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles gridToolStripMenuItem.DropDownOpening
         showToolStripMenuItem.Checked = _medicalViewer.LayoutOptions.ShowGrid
         snapToolStripMenuItem.Checked = _medicalViewer.LayoutOptions.SnapToGrid
         showLinesToolStripMenuItem.Checked = _medicalViewer.LayoutOptions.ShowLines
      End Sub

      Private Sub sizeToolStripMenuItem_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles sizeToolStripMenuItem.DropDownOpening
         Select Case _medicalViewer.LayoutOptions.GridSize.Width
            Case 2
               x6ToolStripMenuItem.Checked = False
               x8ToolStripMenuItem.Checked = False
               x10ToolStripMenuItem.Checked = False
            Case 4
               x6ToolStripMenuItem.Checked = False
               x8ToolStripMenuItem.Checked = False
               x10ToolStripMenuItem.Checked = False
            Case 6
               x6ToolStripMenuItem.Checked = True
               x8ToolStripMenuItem.Checked = False
               x10ToolStripMenuItem.Checked = False
            Case 8
               x6ToolStripMenuItem.Checked = False
               x8ToolStripMenuItem.Checked = True
               x10ToolStripMenuItem.Checked = False
            Case 10
               x6ToolStripMenuItem.Checked = False
               x8ToolStripMenuItem.Checked = False
               x10ToolStripMenuItem.Checked = True
         End Select
      End Sub

      Private Sub SetGridSize(ByVal sender As Object, ByVal e As EventArgs) Handles x6ToolStripMenuItem.Click, x8ToolStripMenuItem.Click, x10ToolStripMenuItem.Click
         Dim item As ToolStripMenuItem = TryCast(sender, ToolStripMenuItem)
         Dim size As Integer = Convert.ToInt32(item.Tag)

         _medicalViewer.LayoutOptions.GridSize = New Size(size, size)
      End Sub

      Private Sub saveLayoutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles saveLayoutToolStripMenuItem.Click
         Dim sf As SaveFileDialog = New SaveFileDialog()

         sf.Title = "Save Layout"
         sf.Filter = "XML Layout Files | *.xml"
         If sf.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            Dim f As FileInfo = New FileInfo(sf.FileName)
            Dim stream As FileStream = f.Create()

            Try
               Viewer.SaveLayout(stream)
            Finally
               If Not stream Is Nothing Then
                  stream.Close()
               End If
            End Try
         End If
      End Sub

      Private Sub loadLayoutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles loadLayoutToolStripMenuItem.Click
         Dim open As OpenFileDialog = New OpenFileDialog()

         open.Title = "Open Layout File"
         open.Filter = "XML Layout Files | *.xml"
         open.Multiselect = False
         If open.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            Dim f As FileInfo = New FileInfo(open.FileName)
            Dim stream As FileStream = f.Open(FileMode.Open)

            Try
               Viewer.Cells.Clear()
               Viewer.LoadLayout(stream)
            Catch ex As Exception
               MessageBox.Show(ex.Message)
            Finally
               If Not stream Is Nothing Then
                  stream.Close()
               End If
            End Try
         End If
      End Sub

      Private Sub toolToolStripMenuItem_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles toolToolStripMenuItem.DropDownOpening
         selectionToolStripMenuItem.Checked = Viewer.LayoutOptions.DesignTool = MedicalViewerDesignTool.Selection
         drawToolStripMenuItem.Checked = Viewer.LayoutOptions.DesignTool = MedicalViewerDesignTool.Draw
      End Sub

      Private Sub selectionToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles selectionToolStripMenuItem.Click, toolStripButtonSelect.Click
         Viewer.LayoutOptions.DesignTool = MedicalViewerDesignTool.Selection
      End Sub

      Private Sub drawToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles drawToolStripMenuItem.Click, toolStripButtonDraw.Click
         Viewer.LayoutOptions.DesignTool = MedicalViewerDesignTool.Draw
      End Sub

      Private Sub allowCellsToOverlappToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles allowCellsToOverlappToolStripMenuItem.Click, toolStripButtonOverlap.Click
         Viewer.LayoutOptions.AllowOverlappingCells = Not Viewer.LayoutOptions.AllowOverlappingCells
         toolStripButtonOverlap.Checked = Viewer.LayoutOptions.AllowOverlappingCells
      End Sub

      Private Sub toolStripButtonShowPosition_Click(ByVal sender As Object, ByVal e As EventArgs) Handles showLocationToolStripMenuItem.Click, toolStripButtonShowPosition.Click
         _medicalViewer.LayoutOptions.ShowPosition = Not _medicalViewer.LayoutOptions.ShowPosition
         toolStripButtonShowPosition.Checked = _medicalViewer.LayoutOptions.ShowPosition
      End Sub

      Private Sub ChangeOverlapPriority(ByVal sender As Object, ByVal e As EventArgs) Handles overlapPriorityToolStripMenuItem.Click, toolStripButton1.Click
         Dim selectedCell As MedicalViewerCell = GetSelectedCell()
         Dim dlgOverlap As OverlapDialog = New OverlapDialog(_medicalViewer.Cells)

         If dlgOverlap.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            Dim i As Integer = 1

            For Each item As ListBoxCellItem In dlgOverlap.Items
               item.Cell.OverlapPriority = i
               i += 1
            Next item
         End If

         If Not selectedCell Is Nothing Then
            selectedCell.Selected = True
         End If
      End Sub

      Public Function GetSelectedCell() As MedicalViewerCell
         For Each cell As MedicalViewerCell In _medicalViewer.Cells
            If cell.Selected Then
               Return cell
            End If
         Next cell
         Return Nothing
      End Function

      Private Sub insertImageToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles insertImageToolStripMenuItem.Click
         Dim image As RasterImage = LoadImage()

         If Not image Is Nothing Then
            For Each cell As MedicalViewerCell In _medicalViewer.Cells
               If cell.Selected Then
                  cell.Image = image
               End If
            Next cell
         End If
      End Sub

      Private Sub showLinesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles showLinesToolStripMenuItem.Click
         _medicalViewer.LayoutOptions.ShowLines = Not _medicalViewer.LayoutOptions.ShowLines
      End Sub


      Public Shared Sub ApplyToCells(ByVal viewer_Renamed As MedicalViewer, ByVal cmbApplyToCell As ComboBox, ByVal txtCellIndex As NumericTextBox, ByVal cmbApplyToSubCell As ComboBox, ByVal txtSubcellIndex As NumericTextBox, ByVal actionType As MedicalViewerActionType, ByVal actionProperties As MedicalViewerBaseAction)
         If cmbApplyToCell Is Nothing Then
            Return
         End If

         If cmbApplyToCell.Text = "None" Then
            Return
         End If

         Dim from As Integer = 0
         Dim [to] As Integer = viewer_Renamed.Cells.Count

         Select Case cmbApplyToCell.Text
            Case "Custom"
               If txtCellIndex.Value >= viewer_Renamed.Cells.Count Then
                  Return
               End If
               from = txtCellIndex.Value
               [to] = txtCellIndex.Value + 1
         End Select

         Dim subCellIndex As Integer = 0

         If Not txtSubcellIndex Is Nothing Then
            subCellIndex = txtSubcellIndex.Value
            Select Case cmbApplyToSubCell.Text
               Case "All"
                  subCellIndex = -1
               Case "Selected"
                  subCellIndex = -2
            End Select
         End If

         Dim index As Integer
         Dim cell As MedicalViewerMultiCell = Nothing

         index = from
         Do While index < [to]
            cell = CType(viewer_Renamed.Cells(index), MedicalViewerMultiCell)
            If cell.Selected OrElse cmbApplyToCell.Text <> "Selected" Then
               cell.SetActionProperties(actionType, actionProperties, subCellIndex)
            End If
            index += 1
         Loop
      End Sub

      Public Shared Sub CopyKeysFromGlobalCell(ByVal sourceCell As MedicalViewerMultiCell, ByVal cell As MedicalViewerMultiCell, ByVal actionType As MedicalViewerActionType)
         Dim keys As MedicalViewerKeys = sourceCell.GetActionKeys(actionType)
         cell.SetActionKeys(actionType, keys)
      End Sub

      Public Shared Sub CopyActionPropertiesFromGlobalCell(ByVal sourceCell As MedicalViewerMultiCell, ByVal cell As MedicalViewerMultiCell, ByVal actionType As MedicalViewerActionType)
         Dim baseAction As MedicalViewerCommonActions = CType(cell.GetActionProperties(actionType), MedicalViewerCommonActions)
         Dim virtualBaseAction As MedicalViewerCommonActions = CType(sourceCell.GetActionProperties(actionType), MedicalViewerCommonActions)

         If TypeOf baseAction Is MedicalViewerCommonActions Then
            Dim commonAction As MedicalViewerCommonActions = CType(baseAction, MedicalViewerCommonActions)
            Dim virtualCommonAction As MedicalViewerCommonActions = CType(virtualBaseAction, MedicalViewerCommonActions)
            commonAction.ActionCursor = virtualCommonAction.ActionCursor
            commonAction.CircularMouseMove = virtualCommonAction.CircularMouseMove
            commonAction.Sensitivity = virtualCommonAction.Sensitivity
         End If

         cell.SetActionProperties(actionType, baseAction)
      End Sub

        Private Sub SetDefaultLayout()
            CreateLayout(New Single() {0.06F, 0.55F}, New Single() {0.75F, 0.75F}, New Single() {0.45F, 0.94F}, New Single() {0.25F, 0.25F})
            bW2ToolStripMenuItem.Checked = True

            Using codecs As New RasterCodecs()
                Dim image As RasterImage = codecs.Load(DemosGlobal.ImagesFolder & "\IMAGE2.dcm", 1)
                If (image IsNot Nothing) Then

                    For Each cell As MedicalViewerCell In _medicalViewer.Cells
                        cell.Image = image
                    Next
                End If
            End Using
        End Sub
    End Class


   ' A class that is derived from System.Windows.Forms.Label control
   Partial Public Class ColorBox : Inherits System.Windows.Forms.Label
      Private _color As Color

      Public Sub New()
         _color = Color.Transparent
      End Sub

      Public Property BoxColor() As Color
         Set(ByVal value As Color)
            _color = Color.FromArgb(255, value)
            If Me.Enabled Then
               BackColor = _color
            End If
         End Set
         Get
            Return Color.FromArgb(0, _color.R, _color.G, _color.B)
         End Get
      End Property

      Protected Overrides Sub OnBackColorChanged(ByVal e As EventArgs)
         MyBase.OnBackColorChanged(e)
         If BackColor <> Color.Transparent Then
            _color = BackColor
         End If
      End Sub

      Protected Overrides Sub OnEnabledChanged(ByVal e As EventArgs)
         MyBase.OnEnabledChanged(e)
         If Me.Enabled Then
            BackColor = _color
         Else
            BackColor = Color.Transparent
         End If
      End Sub

      Protected Overrides Sub OnDoubleClick(ByVal e As EventArgs)
         MainForm.ShowColorDialog(Me)
         _color = BackColor
         MyBase.OnDoubleClick(e)
      End Sub
   End Class


   ' A class that is derieved from TextBox control, that allows only
   ' 1) The numeric values.
   ' 2) The values that fall within the given range.
   Partial Public Class FNumericTextBox : Inherits System.Windows.Forms.TextBox
      Private _maximumAllowed As Double
      Private _minimumAllowed As Double
      Private _oldText As String

      Public Sub New()
         _maximumAllowed = 1000.0
         _minimumAllowed = -1000.0
         _oldText = ""
      End Sub

      <Description("The minimum allowed value to be entered"), Category("Allowed Values")> _
      Public Property MinimumAllowed() As Double
         Set(ByVal value As Double)
            _minimumAllowed = value
         End Set
         Get
            Return _minimumAllowed
         End Get
      End Property

      <Description("The maximum allowed value to be entered"), Category("Allowed Values")> _
      Public Property MaximumAllowed() As Double
         Set(ByVal value As Double)
            _maximumAllowed = value
         End Set
         Get
            Return _maximumAllowed
         End Get
      End Property

      <Description("The numeric value of the Text box"), Category("Current Value")> _
      Public Property Value() As Double
         Set(ByVal value As Double)
            Me.Text = value.ToString()
         End Set
         Get
            If Me.Text.Trim() = "" Then
               Return _minimumAllowed
            Else
               Return Convert.ToDouble(Me.Text)
            End If
         End Get
      End Property

      ' Is the entered number within the specified valid range
      Private Function IsAllowed(ByVal text As String) As Boolean
         Dim isAllowed_Renamed As Boolean = True

         Try
            Dim newNumber As Double = Convert.ToDouble(text)
            If (newNumber > _maximumAllowed) OrElse (newNumber < _minimumAllowed) Then
               isAllowed_Renamed = False
            End If
         Catch
            ' This happen if the entered value is not a numeric.
            isAllowed_Renamed = False
         End Try

         Return isAllowed_Renamed
      End Function

      Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
         If (Not IsAllowed(Me.Text)) Then
            ' If this condition doesn't exist, the user will be bugged. (trust me).
            If _minimumAllowed <= 0 Then
               Me.Text = _oldText
            End If
         Else
            _oldText = Me.Text
         End If

         MyBase.OnTextChanged(e)
      End Sub

      Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
         ' Increase or decrease the current value by 1 if the user presses the UP or DOWN
         ' and test if the new value is allowed
         If (e.KeyCode = Keys.Up) OrElse (e.KeyCode = Keys.Down) Then
            Dim value_Renamed As Double = Convert.ToDouble(Me.Text)

            If (e.KeyCode = Keys.Up) Then
               value_Renamed = value_Renamed + 0.1
            Else
               value_Renamed = value_Renamed - 0.1
            End If

            If IsAllowed(value_Renamed.ToString()) Then
               Me.Text = value_Renamed.ToString()
            End If
         End If

         MyBase.OnKeyDown(e)
      End Sub

      Protected Overrides Sub OnLostFocus(ByVal e As EventArgs)
         Dim value_Renamed As Double
         If (Me.Text.Trim() = "") Then
            value_Renamed = _minimumAllowed
         Else
            value_Renamed = Convert.ToDouble(Me.Text)
         End If
         If value_Renamed < _minimumAllowed Then
            Me.Text = _minimumAllowed.ToString()
         End If

         MyBase.OnLostFocus(e)
      End Sub

      Protected Overrides Sub OnKeyPress(ByVal e As KeyPressEventArgs)
         ' if Enter, Escape, Ctrl or Alt key is pressed, then there is no need to check
         ' since the user is not entering a new character...
         If ((Control.ModifierKeys And Keys.Control) = 0) AndAlso ((Control.ModifierKeys And Keys.Alt) = 0) AndAlso (e.KeyChar <> Convert.ToChar(Keys.Enter)) AndAlso (e.KeyChar <> Convert.ToChar(Keys.Escape)) AndAlso (e.KeyChar <> Convert.ToChar(Keys.Back)) Then
            ' Validate the entered character
            If (Not Char.IsNumber(e.KeyChar)) Then
               ' Here we check if the user wants to enter the "-" character.
               If Not ((Me.Text.IndexOf("-"c) = -1) AndAlso (Me.SelectionStart = 0) AndAlso (_minimumAllowed < 0) AndAlso (e.KeyChar = "-"c)) Then ' the character entered was a Minus character
                  If Not ((e.KeyChar = "."c) AndAlso (Me.Text.IndexOf("."c) = -1)) Then
                     e.KeyChar = Char.MinValue
                  End If
               End If
            End If

            If _minimumAllowed <= 0 Then
               If e.KeyChar <> Char.MinValue Then
                  ' Create the string that will be displayed, and check whether it's valid or not.
                  ' Remove the selected character(s).
                  Dim newString As String = Me.Text.Remove(Me.SelectionStart, Me.SelectionLength)
                  ' Insert the new character.
                  newString = newString.Insert(Me.SelectionStart, e.KeyChar.ToString())
                  If (Not IsAllowed(newString)) Then
                     ' the new string is not valid, cancel the whole operation.
                     e.KeyChar = Char.MinValue
                  End If
               End If
            End If
         End If
         MyBase.OnKeyPress(e)
      End Sub
   End Class


   Partial Public Class CursorButton : Inherits System.Windows.Forms.Button
      Private _buttonCursor As Cursor

      Public Sub New()
         _buttonCursor = Nothing
      End Sub

      <Description("The Cursor"), Category("Cursor")> _
      Public Property ButtonCursor() As Cursor
         Set(ByVal value As Cursor)
            _buttonCursor = value
         End Set
         Get
            Return _buttonCursor
         End Get
      End Property

      Protected Overrides Sub OnClick(ByVal e As EventArgs)
         MyBase.OnClick(e)
         Dim openDialog As OpenFileDialog = New OpenFileDialog()
         openDialog.Filter = "Cursor files (*.cur) | *.cur"
         openDialog.RestoreDirectory = True

         If openDialog.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            _buttonCursor = New System.Windows.Forms.Cursor(openDialog.FileName)
         End If
      End Sub

      Protected Overrides Sub OnPaint(ByVal pevent As PaintEventArgs)
         MyBase.OnPaint(pevent)
         If Not _buttonCursor Is Nothing Then
            Dim averageWidth As Integer = Convert.ToInt32((pevent.ClipRectangle.Width - _buttonCursor.Size.Width) / 2)
            Dim averageHeight As Integer = Convert.ToInt32((pevent.ClipRectangle.Height - _buttonCursor.Size.Height) / 2)

            _buttonCursor.Draw(pevent.Graphics, New Rectangle(averageWidth, averageHeight, _buttonCursor.Size.Width, _buttonCursor.Size.Height))
         End If
      End Sub
   End Class

   ' A class that is derieved from TextBox control, that allows only
   ' 1) The numeric values.
   ' 2) The values that fall within the given range.
   Partial Public Class NumericTextBox : Inherits System.Windows.Forms.TextBox
      Private _maximumAllowed As Integer
      Private _minimumAllowed As Integer
      Private _oldText As String

      Public Sub New()
         _maximumAllowed = 1000
         _minimumAllowed = -1000
         _oldText = ""
      End Sub

      <Description("The minimum allowed value to be entered"), Category("Allowed Values")> _
      Public Property MinimumAllowed() As Integer
         Set(ByVal value As Integer)
            _minimumAllowed = value
         End Set
         Get
            Return _minimumAllowed
         End Get
      End Property

      <Description("The maximum allowed value to be entered"), Category("Allowed Values")> _
      Public Property MaximumAllowed() As Integer
         Set(ByVal value As Integer)
            _maximumAllowed = value
         End Set
         Get
            Return _maximumAllowed
         End Get
      End Property

      <Description("The maximum allowed value to be entered"), Category("Current Value")> _
      Public Property Value() As Integer
         Set(ByVal value As Integer)
            Me.Text = value.ToString()
         End Set
         Get
            If Me.Text.Trim() = "" Then
               Return _minimumAllowed
            Else
               Return Convert.ToInt32(Me.Text)
            End If
         End Get
      End Property

      ' Is the entered number within the specified valid range
      Private Function IsAllowed(ByVal text As String) As Boolean
         Dim isAllowed_Renamed As Boolean = True

         Try
            Dim newNumber As Integer = Convert.ToInt32(text)
            If (newNumber > _maximumAllowed) OrElse (newNumber < _minimumAllowed) Then
               isAllowed_Renamed = False
            End If
         Catch
            ' This happen if the entered value is not a numeric.
            isAllowed_Renamed = False
         End Try

         Return isAllowed_Renamed
      End Function

      Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
         If (Not IsAllowed(Me.Text)) Then
            If _minimumAllowed <= 1 Then
               Me.Text = _oldText
            End If
         Else
            _oldText = Me.Text
         End If

         MyBase.OnTextChanged(e)
      End Sub

      Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
         ' Increase or decrease the current value by 1 if the user presses the UP or DOWN
         ' and test if the new value is allowed
         If (e.KeyCode = Keys.Up) OrElse (e.KeyCode = Keys.Down) Then
            Dim value_Renamed As Integer = Convert.ToInt32(Me.Text)

            If (e.KeyCode = Keys.Up) Then
               value_Renamed = value_Renamed + 1
            Else
               value_Renamed = value_Renamed - 1
            End If

            If IsAllowed(value_Renamed.ToString()) Then
               Me.Text = value_Renamed.ToString()
            End If
         End If

         MyBase.OnKeyDown(e)
      End Sub

      Protected Overrides Sub OnLostFocus(ByVal e As EventArgs)
         Dim value_Renamed As Integer = Convert.ToInt32(Me.Text)
         If value_Renamed < _minimumAllowed Then
            Me.Text = _minimumAllowed.ToString()
         End If

         MyBase.OnLostFocus(e)
      End Sub

      Protected Overrides Sub OnKeyPress(ByVal e As KeyPressEventArgs)
         ' if Enter, Escape, Ctrl or Alt key is pressed, then there is no need to check
         ' since the user is not entering a new character...
         If ((Control.ModifierKeys And Keys.Control) = 0) AndAlso ((Control.ModifierKeys And Keys.Alt) = 0) AndAlso (e.KeyChar <> Convert.ToChar(Keys.Enter)) AndAlso (e.KeyChar <> Convert.ToChar(Keys.Escape)) Then
            ' Validate the entered character
            If (Not Char.IsNumber(e.KeyChar)) Then

               ' Here we check if the user wants to enter the "-" character.
               If Not ((Me.Text.IndexOf("-"c) = -1) AndAlso (Me.SelectionStart = 0) AndAlso (_minimumAllowed < 0) AndAlso (e.KeyChar = "-"c)) Then ' the character entered was a Minus character
                  e.KeyChar = Char.MinValue
               End If
            End If

            If _minimumAllowed <= 1 Then
               If e.KeyChar <> Char.MinValue Then
                  ' Create the string that will be displayed, and check whether it's valid or not.

                  ' Remove the selected character(s).
                  Dim newString As String = Me.Text.Remove(Me.SelectionStart, Me.SelectionLength)
                  ' Insert the new character.
                  newString = newString.Insert(Me.SelectionStart, e.KeyChar.ToString())
                  If (Not IsAllowed(newString)) Then
                     ' the new string is not valid, cancel the whole operation.
                     e.KeyChar = Char.MinValue
                  End If
               End If
            End If
         End If
         MyBase.OnKeyPress(e)
      End Sub
   End Class
End Namespace

