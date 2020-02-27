' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports System
Imports System.Linq
Imports System.Collections.Generic
Imports System.Threading
Imports System.Windows.Forms
Imports Leadtools.Dicom
Imports Leadtools.Dicom.Common.Extensions
Imports DicomAnonymizer.UI.Controls
Imports DicomAnonymizer.Common
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.IO
Imports Leadtools.Dicom.Common.Anonymization
Imports System.Collections.ObjectModel
Imports Leadtools.Dicom.Common.Editing.Controls
Imports Leadtools.Dicom.Common.Editing
Imports Leadtools.Dicom.Common.Compare
Imports System.Diagnostics
Imports DicomAnonymizer.UI
Imports Leadtools.Dicom.Common.Diff
Imports Leadtools.Demos.Dialogs

Namespace DicomAnonymizer
   Partial Class MainForm : Inherits Form
      Private _TagItems As Dictionary(Of Long, Integer)
      Private _Anonymizer As Anonymizer
      Private _FileName As String = String.Empty
      Private _Modified As Boolean
      Private _OldValue As String
      Private _ActiveDataSet As DicomDataSet

      Private Const TAG_COLUMN As Integer = 0
      Private Const DESCRIPTION_COLUMN As Integer = 1
      Private Const TAGS_VALUE_COLUMN As Integer = 2

      Public Sub New()
         Try
            InitializeComponent()
         Catch
         End Try
      End Sub

      Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
         If DesignMode Then
            Return
         End If

         Try
            _TagItems = New Dictionary(Of Long, Integer)()
            Messager.Caption = "VB.NET DICOM Anonymizer Demo"
            Text = Messager.Caption & " - Untitled"
            _Anonymizer = New Anonymizer(True)
            _Anonymizer.ApplicationDescription = Messager.Caption
            AddHandler _Anonymizer.Progress, AddressOf _Anonymizer_Progress
            RegisterEvents()
            SizeColumns()
            InitializeMacroCombo()
            LoadMacros(_Anonymizer.TagMacros)
            _Modified = False
            Dim TempRowNumberDataGridViewDecorator As RowNumberDataGridViewDecorator = New RowNumberDataGridViewDecorator(treeGridViewTags)
            Dim TempSelectionDecorator As SelectionDecorator = New SelectionDecorator(treeGridViewDifference)
            toolStripProgressBar.Size = New Size(CType(Width / 4, Integer), toolStripProgressBar.Size.Height)
         Catch
         End Try
         AddHandler Application.Idle, AddressOf Application_Idle
         _ActiveDataSet = New DicomDataSet()
         LoadDefault()
      End Sub

      Private Sub _Anonymizer_Progress(ByVal sender As Object, ByVal e As ProgressEventArgs)
         toolStripProgressBar.Value = e.Progress
         Application.DoEvents()
      End Sub

      Private Sub Application_Idle(ByVal sender As Object, ByVal e As EventArgs)
         toolStripButtonSave.Enabled = _Modified
         toolStripButtonAnonymize.Enabled = treeGridViewTags.Nodes.Count > 0
         toolStripButtonSaveDataset.Enabled = treeGridViewDifference.Nodes.Count > 0
         If toolStripButtonSaveDataset.Enabled Then
            Dim info As AnonymizedInfo = TryCast(treeGridViewDifference.Tag, AnonymizedInfo)

            toolStripButtonView.Enabled = Not info Is Nothing AndAlso info.ImageCount > 0
         Else
            toolStripButtonView.Enabled = False
         End If
         toolStripButtonDeleteTag.Enabled = treeGridViewTags.SelectedCells.Count > 0
         toolStripButtonRefresh.Enabled = Not treeGridViewDifference.Tag Is Nothing
      End Sub

      Private Sub UpdateTitle()
         If _FileName.Length = 0 Then
            Text = Messager.Caption & " - " & ("Untitled")
         Else
            Text = Messager.Caption & " - " & (_FileName)
         End If
      End Sub

      Private Sub SizeColumns()
         Dim width As Integer = (Extensions.MeasureDisplayStringWidth(treeGridViewTags.CreateGraphics(), "(9999,9999)", treeGridViewTags.Font) + Resources.Tag_16x16.Width) * 2

         treeGridViewTags.Columns(TAG_COLUMN).Width = width
         treeGridViewTags.Columns(DESCRIPTION_COLUMN).Width = 250
      End Sub

      Private Sub RegisterEvents()
         AddHandler treeGridViewTags.CellBeginEdit, AddressOf treeGridViewTags_CellBeginEdit
         AddHandler treeGridViewTags.CellFormatting, AddressOf treeGridViewTags_CellFormatting
         AddHandler treeGridViewTags.CellEndEdit, AddressOf treeGridViewTags_CellEndEdit
         AddHandler treeGridViewTags.EditingControlShowing, AddressOf treeGridViewTags_EditingControlShowing
         AddHandler treeGridViewTags.CellValidating, AddressOf treeGridViewTags_CellValidating
         AddHandler treeGridViewTags.DataError, AddressOf treeGridViewTags_DataError

         AddHandler treeGridViewDifference.CellClick, AddressOf treeGridViewDifference_CellClick
         AddHandler treeGridViewDifference.RowStateChanged, AddressOf treeGridViewDifference_RowStateChanged
      End Sub

      Private Sub treeGridViewTags_DataError(ByVal sender As Object, ByVal e As DataGridViewDataErrorEventArgs)

      End Sub

      Private Sub treeGridViewTags_CellValidating(ByVal sender As Object, ByVal e As DataGridViewCellValidatingEventArgs)
         If e.ColumnIndex = TAGS_VALUE_COLUMN Then
            Dim efv As Object = e.FormattedValue
            Dim cell As DataGridViewComboBoxCell = TryCast(treeGridViewTags.Rows(e.RowIndex).Cells(e.ColumnIndex), DataGridViewComboBoxCell)
            Dim column As DataGridViewComboBoxColumn = CType(treeGridViewTags.Columns(TAGS_VALUE_COLUMN), DataGridViewComboBoxColumn)

            If (Not column.Items.Contains(efv)) Then
               column.Items.Add(efv)
            End If
            cell.Value = efv
         End If
      End Sub

      Private Sub treeGridViewDifference_RowStateChanged(ByVal sender As Object, ByVal e As DataGridViewRowStateChangedEventArgs)
         If e.Row.Selected = True Then
            Dim diff As Difference = TryCast(e.Row.Tag, Difference)

            If Not diff Is Nothing Then
               Dim node As TreeGridNode = (From n In treeGridViewTags.Nodes.OfType(Of DicomTagNode)() Where n.DicomTag.Code = diff.Tag Select n).FirstOrDefault()

               If Not node Is Nothing AndAlso node.IsSited Then
                  Dim selectedNode As TreeGridNode = (From n In treeGridViewTags.Nodes Where n.Selected = True Select n).FirstOrDefault()

                  If Not selectedNode Is Nothing Then
                     selectedNode.Selected = False
                  End If

                  node.Selected = True
                  treeGridViewTags.FirstDisplayedScrollingRowIndex = node.RowIndex
               End If
            End If
         End If
      End Sub

      Private Sub treeGridViewDifference_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)
         If e.ColumnIndex = 5 AndAlso e.RowIndex <> -1 Then
            Dim cell As DataGridViewDisableButtonCell = TryCast(treeGridViewDifference.Rows(e.RowIndex).Cells(5), DataGridViewDisableButtonCell)

            If cell.Enabled Then
               Dim popup As ToolStripDropDown = New ToolStripDropDown()
               Dim diff As Difference = TryCast(treeGridViewDifference.Rows(e.RowIndex).Tag, Difference)
               Dim location As Point = New Point(treeGridViewDifference.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Left, treeGridViewDifference.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, True).Bottom)

               popup.Margin = Padding.Empty
               popup.Padding = Padding.Empty

               Dim host As New ToolStripControlHost(New WebBrowser() With {.DocumentText = diff.HtmlDiff, .Width = cell.ContentBounds.Width * 2})
               host.Margin = Padding.Empty
               host.Padding = Padding.Empty
               host.AutoSize = False
               host.Size = host.Control.Size
               popup.Size = host.Size
               popup.DropShadowEnabled = True
               popup.Items.Add(host)
               popup.Show(treeGridViewDifference.PointToScreen(location))
            End If
         End If
      End Sub

      Private Sub treeGridViewTags_CellFormatting(ByVal sender As Object, ByVal e As DataGridViewCellFormattingEventArgs) Handles treeGridViewTags.CellFormatting
         If e.ColumnIndex = TAGS_VALUE_COLUMN Then
            e.CellStyle.ForeColor = Color.Blue
            e.CellStyle.Font = New Font(e.CellStyle.Font, FontStyle.Bold)
         End If
      End Sub

      Private Sub treeGridViewTags_CellBeginEdit(ByVal sender As Object, ByVal e As DataGridViewCellCancelEventArgs) Handles treeGridViewTags.CellBeginEdit
         If (e.RowIndex <= treeGridViewTags.Rows.Count) Then
            Dim macro As TagMacro = TryCast(treeGridViewTags.Nodes(e.RowIndex).Tag, TagMacro)
            e.Cancel = e.ColumnIndex <> TAGS_VALUE_COLUMN
         End If
      End Sub

      Private Sub treeGridViewTags_CellEndEdit(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)
         Dim macro As TagMacro = TryCast(treeGridViewTags.Nodes(e.RowIndex).Tag, TagMacro)
         Dim cell As DataGridViewComboBoxCell = TryCast(treeGridViewTags.Nodes(e.RowIndex).Cells(e.ColumnIndex), DataGridViewComboBoxCell)

         If Not cell.Value Is Nothing Then
            macro.Macro = cell.Value.ToString()
         Else
            macro.Macro = String.Empty
         End If
         If _OldValue.ToString() <> macro.Macro Then
            _Modified = True
         End If
      End Sub

      Private Sub treeGridViewTags_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs)
         Dim column As DataGridViewComboBoxEditingControl = TryCast(e.Control, DataGridViewComboBoxEditingControl)

         column.DropDownStyle = ComboBoxStyle.DropDown
         _OldValue = column.Text
      End Sub

      Private Function AddAnonymizationTag(ByVal tag As Long, ByVal name As String, ByVal macro As String) As DicomTagNode
         Dim node As DicomTagNode = Nothing
         Dim dicomTag As DicomTag = DicomTagTable.Instance.Find(tag)

         node = New DicomTagNode()
         treeGridViewTags.Nodes.Add(node)
         node.SetValues(String.Format("({0:X4},{1:X4})", tag.GetGroup(), tag.GetElement()), name, macro)
         node.DicomTag = dicomTag
         node.Image = Resources.Tag_16x16

         If Not dicomTag Is Nothing AndAlso dicomTag.VR = DicomVRType.SQ Then
            node.Image = Resources.Tags_16x16
         End If
         _Anonymizer(tag) = macro
         node.Tag = _Anonymizer.FindTag(tag)
         Return node
      End Function

      Private Sub InitializeMacroCombo()
         Dim column As DataGridViewComboBoxColumn = CType(treeGridViewTags.Columns(TAGS_VALUE_COLUMN), DataGridViewComboBoxColumn)

         column.Items.Clear()
         column.DisplayStyle = DataGridViewComboBoxDisplayStyle.DropDownButton
         For Each key As String In _Anonymizer.MacroProcessor.Macros.Keys
            column.Items.Add(String.Format("${{{0}}}", key))
         Next key
      End Sub

      Private Sub LoadMacros(ByVal macros As ObservableCollection(Of TagMacro))
         treeGridViewTags.Nodes.Clear()
         For Each macro As TagMacro In macros
            Dim dicomTag As DicomTag = DicomTagTable.Instance.Find(macro.Tag)
            Dim name As String
            If Not dicomTag Is Nothing Then
               name = dicomTag.Name
            Else
               name = String.Empty
            End If
            Dim node As DicomTagNode = New DicomTagNode()

            treeGridViewTags.Nodes.Add(node)
            node.SetValues(String.Format("({0:X4},{1:X4})", macro.Tag.GetGroup(), macro.Tag.GetElement()), name, macro.Macro)
            node.DicomTag = dicomTag
            node.Tag = macro
            AddToList(macro.Macro)

            If Not dicomTag Is Nothing Then
               If dicomTag.VR = DicomVRType.SQ Then
                  node.Image = Resources.Tags_16x16
               Else
                  node.Image = Resources.Tag_16x16
               End If
            End If
         Next macro
      End Sub

      Private Sub AddToList(ByVal macro As String)
         Dim column As DataGridViewComboBoxColumn = CType(treeGridViewTags.Columns(TAGS_VALUE_COLUMN), DataGridViewComboBoxColumn)

         If (Not column.Items.Contains(macro)) Then
            column.Items.Add(macro)
         End If
      End Sub

      Private Sub aboutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles aboutToolStripMenuItem.Click
         Using aboutDialog As New AboutDialog("DICOM Anonymizer", ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using
      End Sub

      Private Sub ToggleProgress(ByVal enable As Boolean)
         toolStripStatusLabel.Visible = enable
         toolStripProgressBar.Visible = enable
      End Sub

      Private Sub anonymizefileToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripButtonAnonymize.Click
         anonymizeopenFileDialog.Multiselect = False
         anonymizeopenFileDialog.Filter = "DICOM Files (*.dcm;*.dic)|*.dcm;*.dic|All files (*.*)|*.*"
         If anonymizeopenFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            Dim dsAnonymized As DicomDataSet = New DicomDataSet()

            _ActiveDataSet.Reset()
            Try
               _ActiveDataSet.Load(anonymizeopenFileDialog.FileName, DicomDataSetLoadFlags.None)
               dsAnonymized = Anonymize()

               Dim info As AnonymizedInfo = New AnonymizedInfo()
               info.AnonymizedDataset = dsAnonymized

               '
               ' Store the image count as a tag of the first node.  This is so we don't have to query the dataset during the Idle event.
               '
               If treeGridViewTags.Nodes.Count > 0 Then
                  Dim element As DicomElement = dsAnonymized.FindFirstElement(Nothing, DicomTag.PixelData, True)

                  If Not element Is Nothing Then
                     info.ImageCount = dsAnonymized.GetImageCount(element)
                  End If
               End If
               treeGridViewDifference.Tag = info
            Catch exception As Exception
               Messager.ShowError(Me, exception)
            Finally
               ToggleProgress(False)
            End Try
         End If
      End Sub

      Class AnonymizedInfo
         Public Property AnonymizedDataset() As DicomDataSet
            Get
               Return m_AnonymizedDataset
            End Get
            Set(ByVal value As DicomDataSet)
               m_AnonymizedDataset = value
            End Set
         End Property
         Private m_AnonymizedDataset As DicomDataSet
         Public Property ImageCount() As Integer
            Get
               Return m_ImageCount
            End Get
            Set(ByVal value As Integer)
               m_ImageCount = value
            End Set
         End Property
         Private m_ImageCount As Integer
      End Class

      Public Sub ShowDifference(ByVal original As DicomDataSet, ByVal anonymized As DicomDataSet)
         Dim difference As List(Of Difference)

         treeGridViewDifference.Nodes.Clear()
         difference = original.Compare(anonymized)
         Dim i As Integer
         For i = 0 To difference.Count - 1
            Dim diff As Difference = difference(i)
            Dim node As TreeGridNode = Nothing

            If diff.Parent Is Nothing Then
               node = treeGridViewDifference.Nodes.Add(String.Format("({0:X4},{1:X4})", diff.Tag.GetGroup(), diff.Tag.GetElement()), diff.Name, diff.VR)
               node.Tag = diff
               SetValue(node, diff)
            Else
               Dim tagNode As TreeGridNode = FindParentNode(treeGridViewDifference.Nodes, Function(n) TryCast(n.Tag, Difference).Path = diff.Parent.Path)

               node = tagNode.Nodes.Add(String.Format("({0:X4},{1:X4})", diff.Tag.GetGroup(), diff.Tag.GetElement()), diff.Name, diff.VR)
               node.Tag = diff
               SetValue(node, diff)
            End If

            If Not _Anonymizer.FindTag(diff.Tag) Is Nothing Then
               node.Image = Resources.ShowTag_16x16p
            End If
         Next i
      End Sub

      Private Sub SetValue(ByVal node As TreeGridNode, ByVal diff As Difference)
         If diff.VR <> DicomVRType.SQ Then
            node.Cells(3).Value = diff.FirstValue
            node.Cells(4).Value = diff.SecondValue
         End If

         '
         ' If the tag is located in both files we need to find the difference
         '
         If diff.Location = TagLocation.Both AndAlso diff.IsChanged() Then
            If diff.VR <> DicomVRType.SQ Then
               Dim cell As DataGridViewDisableButtonCell = TryCast(node.Cells(5), DataGridViewDisableButtonCell)

               cell.Value = "Show Diff"
            End If
         Else
            Dim cell As DataGridViewDisableButtonCell = TryCast(node.Cells(5), DataGridViewDisableButtonCell)

            cell.Value = String.Empty
            If diff.Location = TagLocation.First Then
               cell.Style.ForeColor = Color.Red
               cell.Value = "Deleted"
            End If
            cell.Enabled = False
         End If
      End Sub

      Private Function FindParentNode(ByVal nodes As TreeGridNodeCollection, ByVal predicate As Predicate(Of TreeGridNode)) As TreeGridNode
         For Each node As TreeGridNode In nodes
            If predicate(node) Then
               Return node
            Else
               Dim nodeChild As TreeGridNode = FindParentNode(node.Nodes, predicate)

               If Not nodeChild Is Nothing Then
                  Return nodeChild
               End If
            End If
         Next node
         Return Nothing
      End Function

      Private Sub exitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles exitToolStripMenuItem.Click
         Close()
      End Sub

      Private Function GetTags() As List(Of Long)
         Dim tags As List(Of Long) = New List(Of Long)()

         For Each node As DicomTagNode In treeGridViewTags.Nodes
            tags.Add(node.DicomTag.Code)
         Next node
         Return tags
      End Function

      Private Sub insertToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles insertToolStripMenuItem.Click
         Using dlgInsert As InsertElementDlg = New InsertElementDlg(GetTags())
            If dlgInsert.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
               Dim node As DicomTagNode = Nothing

               For Each tag As Long In dlgInsert.Tags
                  Dim dicomTag As DicomTag = DicomTagTable.Instance.Find(tag)
                  Dim tagNode As DicomTagNode = Nothing

                  If Not dicomTag Is Nothing Then
                     tagNode = AddAnonymizationTag(tag, dicomTag.Name, GetDefaultMacro(dicomTag))
                  Else
                     tagNode = AddAnonymizationTag(tag, String.Empty, GetDefaultMacro(dicomTag))
                  End If
                  If node Is Nothing Then
                     node = tagNode
                  End If
               Next tag
               _Modified = dlgInsert.Tags.Count > 0
               If Not node Is Nothing Then
                  treeGridViewTags.ClearSelection()
                  treeGridViewTags.SelectRow(node.Index)
                  treeGridViewTags.FirstDisplayedScrollingRowIndex = node.Index
               End If
            End If
         End Using
      End Sub

      Private Function GetDefaultMacro(ByVal tag As DicomTag) As String
         Dim macro As String = String.Empty

         If tag Is Nothing OrElse tag.VR = DicomVRType.UN Then
            Return "${empty}"
         End If

         Select Case tag.VR
            Case DicomVRType.UI
               macro = "${uid}"
            Case DicomVRType.DA, DicomVRType.DT
               macro = "${random_day}"
            Case DicomVRType.TM
               macro = "${random_time}"
            Case DicomVRType.PN
               macro = "${name}"
            Case DicomVRType.CS, DicomVRType.LO, DicomVRType.LT, DicomVRType.UT
               macro = "${random_string}"
            Case DicomVRType.SH
               macro = "${random_string(16)}"
            Case Else
               macro = "${empty}"
         End Select

         AddToList(macro)
         Return macro
      End Function

      Private Sub tagToolStripMenuItem_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles tagToolStripMenuItem.DropDownOpening
         deleteToolStripMenuItem.Enabled = treeGridViewTags.SelectedRows.Count > 0
      End Sub

      Private Sub deleteToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles deleteToolStripMenuItem.Click
         Dim nodes As List(Of DicomTagNode) = (From n In treeGridViewTags.Rows.Cast(Of DataGridViewRow)() Where n.Selected = True Select TryCast(n, DicomTagNode)).ToList()

         For Each node As DicomTagNode In nodes
            treeGridViewTags.Nodes.Remove(node)
            _Anonymizer.DeleteMacro(node.DicomTag.Code)
         Next node
         _Modified = nodes.Count > 0
      End Sub

      Private Sub fileToolStripMenuItem_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles fileToolStripMenuItem.DropDownOpening
         saveToolStripMenuItem.Enabled = _Modified
         saveAsToolStripMenuItem.Enabled = _FileName.Length > 0
         toolStripButtonAnonymize.Enabled = treeGridViewTags.Nodes.Count > 0
      End Sub

      Private Sub saveToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles saveToolStripMenuItem.Click
         Try
            If String.IsNullOrEmpty(_FileName) Then
               Using dlgSave As SaveFileDialog = New SaveFileDialog()
                  dlgSave.Title = "Save Anonymization Script"
                  dlgSave.Filter = "Dicom Anonymization Script (*.das)|*.das"
                  dlgSave.AddExtension = True

                  If dlgSave.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                     _Anonymizer.Save(dlgSave.FileName)
                     _FileName = dlgSave.FileName
                     UpdateTitle()
                     _Modified = False
                  End If
               End Using
            Else
               _Anonymizer.Save(_FileName)
               _Modified = False
            End If
         Catch exception As Exception
            Messager.ShowError(Me, exception)
         End Try
      End Sub

      Private Function PromptForSave() As Boolean
         If (Not _Modified) Then
            Return True
         End If

         ' ask the user to save.
         Dim result As DialogResult = MessageBox.Show(Me, "Current anonymization script has changed. Would you like to save?", "Save current script", MessageBoxButtons.YesNoCancel)

         If result = DialogResult.Cancel Then
            Return False
         End If

         If result = DialogResult.Yes Then
            ' Does the current file have a name?
            If String.IsNullOrEmpty(_FileName) Then
               Using dlgSave As SaveFileDialog = New SaveFileDialog()
                  dlgSave.Title = "Save Anonymization Script"
                  dlgSave.Filter = "Dicom Anonymization Script (*.das)|*.das"
                  dlgSave.AddExtension = True

                  If dlgSave.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                     _Anonymizer.Save(dlgSave.FileName)
                     _FileName = dlgSave.FileName
                     UpdateTitle()
                  Else
                     Return False
                  End If
               End Using
            Else
               _Anonymizer.Save(_FileName)
               UpdateTitle()
            End If
            _Modified = False
         End If
         Return True
      End Function

      Private Sub saveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles saveAsToolStripMenuItem.Click
         Try
            Using dlgSave As SaveFileDialog = New SaveFileDialog()
               dlgSave.Title = "Save Anonymization Script"
               dlgSave.Filter = "Dicom Anonymization Script (*.das)|*.das"
               dlgSave.AddExtension = True
               If dlgSave.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                  _Anonymizer.Save(dlgSave.FileName)
                  _FileName = dlgSave.FileName
                  UpdateTitle()
                  _Modified = False
               End If
            End Using
         Catch exception As Exception
            Messager.ShowError(Me, exception)
         End Try
      End Sub

      Private Sub newToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles newToolStripMenuItem.Click
         If PromptForSave() Then
            treeGridViewTags.Freeze()
            treeGridViewTags.Nodes.Clear()
            treeGridViewTags.Unfreeze()
            _Modified = False
            _Anonymizer.TagMacros.Clear()
            _FileName = String.Empty
            UpdateTitle()
         End If
      End Sub

      Private Sub openToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles openToolStripMenuItem.Click
         If PromptForSave() Then
            Using dlgOpen As OpenFileDialog = New OpenFileDialog()
               dlgOpen.Title = "Open Anonymization Script"
               dlgOpen.Filter = "Dicom Anonymization Script (*.das)|*.das"
               dlgOpen.Multiselect = False
               dlgOpen.AddExtension = True
               If dlgOpen.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                  _Anonymizer = Anonymizer.Load(dlgOpen.FileName)
                  _FileName = dlgOpen.FileName
                  UpdateTitle()
                  _Modified = False
                  LoadMacros(_Anonymizer.TagMacros)
               End If
            End Using
         End If
      End Sub

      Private Sub toolStripButtonView_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripButtonView.Click
         Dim info As AnonymizedInfo = TryCast(treeGridViewDifference.Tag, AnonymizedInfo)

         If Not info Is Nothing Then
            Try
               Using dlgView As ViewImageDialog = New ViewImageDialog(info.AnonymizedDataset)
                  dlgView.Text = "View Image"
                  dlgView.ShowDialog(Me)
               End Using
            Catch exception As Exception
               Messager.ShowError(Me, exception)
            End Try
         End If
      End Sub

      Private Sub toolStripButtonSaveDataset_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripButtonSaveDataset.Click
         Dim info As AnonymizedInfo = TryCast(treeGridViewDifference.Tag, AnonymizedInfo)

         If Not info Is Nothing Then
            Try
               Using dlgSave As SaveFileDialog = New SaveFileDialog()
                  dlgSave.Title = "Save Anonymized Dataset"
                  dlgSave.Filter = "Dicom Files (*.dic) | *.dic | All Files (*.*) | *.*"
                  dlgSave.AddExtension = True
                  If dlgSave.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
                     info.AnonymizedDataset.Save(dlgSave.FileName, DicomDataSetSaveFlags.None)
                  End If
               End Using
            Catch exception As Exception
               Messager.ShowError(Me, exception)
            End Try
         End If
      End Sub

      Private Sub defaultToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles defaultToolStripMenuItem.Click
         If PromptForSave() Then
            treeGridViewTags.Freeze()
            treeGridViewTags.Nodes.Clear()
            treeGridViewTags.Unfreeze()
            _Modified = False
            _Anonymizer.TagMacros.Clear()
            _FileName = String.Empty
            UpdateTitle()
            For Each item As TagMacro In BasicProfile.TagMacros
               _Anonymizer.TagMacros.Add(item)
            Next item
            LoadMacros(_Anonymizer.TagMacros)
         End If
      End Sub

      Private Sub LoadDefault()
         Try
            Dim dsAnonymized As DicomDataSet

            _ActiveDataSet.Load(DemosGlobal.ImagesFolder + "\Image2.dcm", DicomDataSetLoadFlags.None)
            dsAnonymized = Anonymize()

            Dim info As New AnonymizedInfo() With { .AnonymizedDataset = dsAnonymized }

            '
            ' Store the image count as a tag of the first node.  This is so we don't have to query the dataset during the Idle event.
            '
            If treeGridViewTags.Nodes.Count > 0 Then
               Dim element As DicomElement = dsAnonymized.FindFirstElement(Nothing, DicomTag.PixelData, True)

               If Not element Is Nothing Then
                  info.ImageCount = dsAnonymized.GetImageCount(element)
               End If
            End If
            treeGridViewDifference.Tag = info
         Catch e As Exception
            Messager.Show(Me, e, MessageBoxIcon.Error)
         End Try
      End Sub

      Private Function Anonymize() As DicomDataSet
         Dim dsAnonymized As DicomDataSet = New DicomDataSet()

         Try
            Dim pixelData As DicomElement = Nothing

            pixelData = _ActiveDataSet.FindFirstElement(Nothing, DicomTag.PixelData, True)
            _Anonymizer.BlackoutRects.Clear()
            If toolStripButtonRedact.Checked AndAlso Not pixelData Is Nothing AndAlso _ActiveDataSet.GetImageCount(pixelData) > 0 Then
               Using dlgRects As SelectBlackoutRectsDialog = New SelectBlackoutRectsDialog(_ActiveDataSet)
                  If dlgRects.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK AndAlso dlgRects.BlackoutRects.Count > 0 Then
                     _Anonymizer.BlackoutRects.AddRange(dlgRects.BlackoutRects)
                  End If
               End Using
            End If

            If _ActiveDataSet.InformationClass <> DicomClassType.BasicDirectory Then
               dsAnonymized.Copy(_ActiveDataSet, Nothing, Nothing)
               ToggleProgress(True)
               _Anonymizer.Anonymize(dsAnonymized)
               ShowDifference(_ActiveDataSet, dsAnonymized)
            End If
         Catch exception As Exception
            Messager.ShowError(Me, exception)
         Finally
            ToggleProgress(False)
         End Try
         Return dsAnonymized
      End Function

      Private Sub toolStripButtonRefresh_Click(ByVal sender As Object, ByVal e As EventArgs) Handles toolStripButtonRefresh.Click
         Dim dsAnonymized As DicomDataSet = Anonymize()
         Dim info As New AnonymizedInfo() With { _
                   .AnonymizedDataset = dsAnonymized }

         '
         ' Store the image count as a tag of the first node.  This is so we don't have to query the dataset during the Idle event.
         '
         If treeGridViewTags.Nodes.Count > 0 Then
            Dim element As DicomElement = dsAnonymized.FindFirstElement(Nothing, DicomTag.PixelData, True)

            If Not element Is Nothing Then
               info.ImageCount = dsAnonymized.GetImageCount(element)
            End If
         End If
         treeGridViewDifference.Tag = info
      End Sub
   End Class
End Namespace
