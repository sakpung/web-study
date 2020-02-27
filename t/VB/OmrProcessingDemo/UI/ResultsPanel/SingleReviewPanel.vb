Imports Leadtools
Imports Leadtools.Annotations.Automation
Imports Leadtools.Annotations.Engine
Imports Leadtools.Annotations.WinForms
Imports Leadtools.Controls
Imports Leadtools.Forms.Processing.Omr.Fields
Imports Leadtools.Forms.Processing.Omr
Imports Leadtools.ImageProcessing
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Partial Public Class SingleReviewPanel
   Inherits Form

   Private masterSheetViewer As AutomationImageViewer
   Private annAutomationManager As AnnAutomationManager = Nothing
   Private _annotationsHelper As AutomationManagerHelper = Nothing
   Private automation As AnnAutomation = Nothing
   Private masterSheet As RasterImage
   Private workspace As Workspace
   Private dgv As DataGridView
   Private columnIndex As Integer
   Private rowIndex As Integer
   Private answerViewer As ImageViewer
   Private annotationField As AnnHiliteObject
   Private sfp As SingleFieldPanel
   Private trp As TextResultPanel
   Private answerRow As DataGridViewRow
   Private Const LBL_FILENAME As String = "Filename: "
   Private Const LBL_IDENTIFIER As String = "Identifier: "
   Private Const LBL_ANSWERKEY_PRESENT As String = "Answer Key"
   Private Const LBL_ANSWERKEY_MISSING As String = "No Answer Key Present"
   Private Const INFLATE As Integer = 5
   Private currentPage As Integer = 1
   Private maxPages As Integer = 1
   Private isAnswerKeySelected As Boolean

   Public Sub New(ByVal workspace As Workspace, ByVal dgv As DataGridView)
      InitializeComponent()
      answerViewer = New ImageViewer()
      answerViewer.Dock = DockStyle.Fill
      answerViewer.Zoom(ControlSizeMode.Fit, 1, LeadPoint.Empty)
      pnlAnswerCrop.Controls.Add(answerViewer)
      masterSheetViewer = New AutomationImageViewer()
      masterSheetViewer.Dock = DockStyle.Fill
      masterSheetViewer.Zoom(ControlSizeMode.Fit, 1, LeadPoint.Empty)
      pnlFullSheet.Controls.Add(masterSheetViewer)
      Me.workspace = workspace
      Me.dgv = dgv
      sfp = New SingleFieldPanel()
      trp = New TextResultPanel()
      AddHandler trp.TextUpdated, AddressOf CellValueUpdated
      sfp.Visible = False
      trp.Visible = False
      spltInfo.Panel2.Controls.Add(sfp)
      spltInfo.Panel2.Controls.Add(trp)
      lblAnswerKey.Visible = False

      If workspace.AnswersPresent = False Then
         lblAnswerKey.Visible = True
         lblAnswerKey.Text = LBL_ANSWERKEY_MISSING
      End If
   End Sub

   Public Sub New(ByVal workspace As Workspace, ByVal dgv As DataGridView, ByVal columnIndex As Integer, ByVal rowIndex As Integer, ByVal isAnswers As Boolean, ByVal useWorkspaceParameters As Boolean, ByVal answerRow As DataGridViewRow)
      Me.New(workspace, dgv)
      Me.columnIndex = columnIndex
      Me.rowIndex = rowIndex
      isAnswerKeySelected = isAnswers

      If isAnswerKeySelected Then
         SetupAnswerKey()
      Else
         PopulateFileDropdown()
      End If

      PopulateZoneDropdown()
      Me.answerRow = answerRow
      rdbtnAllFields.Checked = Not useWorkspaceParameters
      rdbtnSpecific.Checked = useWorkspaceParameters
      btnChooseFilters.Enabled = rdbtnSpecific.Checked
      btnNextWorksheet.Visible = Not isAnswerKeySelected
      btnPreviousWorksheet.Visible = Not isAnswerKeySelected
      cbFiles.Visible = Not isAnswerKeySelected
      btnNextWorksheet.Enabled = (rowIndex < dgv.Rows.Count - 1) AndAlso (dgv.Rows(rowIndex + 1).Tag IsNot Nothing)
      btnPreviousWorksheet.Enabled = (rowIndex > 0) AndAlso (dgv.Rows(rowIndex - 1).Tag IsNot Nothing)
      maxPages = If(masterSheet IsNot Nothing, masterSheet.PageCount, 0)
      btnNextPage.Visible = masterSheet IsNot Nothing AndAlso masterSheet.PageCount > 1
      btnPreviousPage.Visible = masterSheet IsNot Nothing AndAlso masterSheet.PageCount > 1
      lblCurrentPage.Visible = masterSheet IsNot Nothing AndAlso masterSheet.PageCount > 1

      If useWorkspaceParameters Then
         AdvanceToNextZone(1)
      Else
         DoZoneSetup()
      End If
   End Sub

   Private Sub CellValueUpdated(ByVal sender As Object, ByVal e As EventArgs)
   End Sub

   Private Sub PopulateZoneDropdown()
      For i As Integer = 0 To dgv.Columns.Count - 1
         Dim dgvc As DataGridViewColumn = dgv.Columns(i)

         If dgvc.Tag IsNot Nothing Then
            cbZones.Items.Add(dgvc)
         End If
      Next

      cbZones.DisplayMember = "HeaderText"
      cbZones.SelectedItem = dgv.Columns(columnIndex)
   End Sub

   Private Sub PopulateFileDropdown()
      Dim startingRowIndex As Integer = rowIndex

      While startingRowIndex >= 0 AndAlso dgv.Rows(startingRowIndex).Tag IsNot Nothing
         startingRowIndex -= 1
      End While

      startingRowIndex += 1
      Dim startingForm As IRecognitionForm = TryCast(dgv.Rows(rowIndex).Tag, IRecognitionForm)
      cbFiles.DisplayMember = "Name"

      While dgv.Rows(startingRowIndex).Tag IsNot Nothing
         Dim form As IRecognitionForm = CType(dgv.Rows(startingRowIndex).Tag, IRecognitionForm)
         cbFiles.Items.Add(form)
         startingRowIndex += 1
      End While

      cbFiles.SelectedItem = startingForm
   End Sub

   Private Sub SetupAnswerKey()
      If rowIndex >= dgv.Rows.Count OrElse dgv.Rows(rowIndex).Tag Is Nothing Then
         Return
      End If

      Dim form As IRecognitionForm = CType(dgv.Rows(rowIndex).Tag, IRecognitionForm)
      Dim guid As String = form.Id
      Dim fileName As String = workspace.AnswerKeyPath
      lblFilename.Text = LBL_FILENAME & Path.GetFileName(fileName)

      If File.Exists(fileName) Then
         masterSheet = workspace.ImageManager.[Get](guid)
         SetupAnnotations(masterSheet)
      Else
         Dim lbl As Label = New Label()
         lbl.TextAlign = ContentAlignment.MiddleCenter
         lbl.Text = String.Format("The image file for the answer key " & Constants.vbLf & """{0}""" & vbLf & " was not found.", fileName)
         spltMain.Panel2.Controls.Add(lbl)
         lbl.AutoSize = False
         lbl.Dock = DockStyle.Fill
         lbl.BringToFront()
      End If

      Dim rc As Workspace.ReviewCounter = workspace.GetManualReviewCollection(form, workspace.VerificationParameters, workspace.Answers)
   End Sub

   Private Sub DoWorksheetSetup(ByVal form As IRecognitionForm)
      If rowIndex >= dgv.Rows.Count OrElse dgv.Rows(rowIndex).Tag Is Nothing Then
         Return
      End If

      Dim guid As String = form.Id
      Dim fileName As String = workspace.GetImageFilePath(guid)
      Dim rc As Workspace.ReviewCounter = workspace.GetManualReviewCollection(form, workspace.VerificationParameters, workspace.Answers)
      masterSheet = workspace.ImageManager.[Get](guid)
      SetupAnnotations(masterSheet)
   End Sub

   Private Sub DoZoneSetup()
      DoZoneSetup(False)
   End Sub

   Private Sub DoZoneSetup(ByVal stayOnPage As Boolean)
      Dim isZoneSetup As Boolean = False

      If dgv.Columns.Count = 1 AndAlso columnIndex = 0 Then
         Dim cell As DataGridViewCell = dgv(0, rowIndex)
         lblNoFieldSelected.Visible = False
         isZoneSetup = DoZoneSetup(cell, stayOnPage)
      ElseIf columnIndex >= 0 AndAlso columnIndex < dgv.ColumnCount Then
         Dim cell As DataGridViewCell = dgv(columnIndex, rowIndex)
         lblNoFieldSelected.Visible = False
         isZoneSetup = DoZoneSetup(cell, stayOnPage)
      End If

      If isZoneSetup = False OrElse (columnIndex < 0 OrElse columnIndex >= dgv.ColumnCount) Then
         UpdateNavigationEnables()
         sfp.Visible = False
         trp.Visible = False
         answerViewer.Image = Nothing
         annotationField.IsVisible = False
         lblNoFieldSelected.Visible = True
      End If
   End Sub

   Private Function DoZoneSetup(ByVal cell As DataGridViewCell, ByVal stayOnPage As Boolean) As Boolean
      Dim zoneIsOnCurrentPage As Boolean = DoPageSetup(cell, stayOnPage)
      UpdateNavigationEnables()

      If Not zoneIsOnCurrentPage Then
         Return False
      End If

      Dim ff As Object = cell.Tag

      If annotationField IsNot Nothing Then
         annotationField.IsVisible = True
      End If

      dgv.CurrentCell = cell
      Dim header As String = cell.OwningColumn.HeaderText
      Me.Text = "Review: " & header
      Dim bounds As LeadRect = LeadRect.Empty
      Dim answerBounds As LeadRect = LeadRect.Empty
      Dim color As String = "Green"

      If TypeOf ff Is OmrCollection Then
         Dim sff As OmrCollection = CType(ff, OmrCollection)
         Dim target As RasterImage = GetCroppedImage(masterSheet, sff.Bounds)
         sfp.Visible = True
         trp.Visible = False
         sfp.Populate(sff, target, cell)
         bounds = sff.Bounds
         color = "Green"
         Dim rp As ReviewParameters = TryCast(sff.Tag, ReviewParameters)
         Dim p As VerificationParameters = rp.ErroredParameters
         p.IsReviewed = True
         p.UseValueChanged = sff.Value <> sff.OriginalValue
         rp.ErroredParameters = p
      ElseIf TypeOf ff Is OmrField Then
         Dim omr As OmrField = CType(ff, OmrField)
         Dim ofr As OmrFieldResult = CType(omr.Result, OmrFieldResult)
         Dim target As RasterImage = GetCroppedImage(masterSheet, omr.Bounds)
         sfp.Visible = False
         trp.Visible = True
         trp.Populate(target, cell, ofr.Text)
         bounds = omr.Bounds
         color = "Green"
      ElseIf TypeOf ff Is BarcodeField Then
         Dim bcf As BarcodeField = CType(ff, BarcodeField)
         Dim bcfr As BarcodeFieldResult = CType(bcf.Result, BarcodeFieldResult)
         Dim target As RasterImage = GetCroppedImage(masterSheet, bcf.Bounds)
         sfp.Visible = False
         trp.Visible = True
         Dim value As String = ""

         If bcfr IsNot Nothing AndAlso bcfr.BarcodeData IsNot Nothing AndAlso bcfr.BarcodeData.Count > 0 Then
            value = bcfr.BarcodeData(0).Value
         End If

         trp.Populate(target, cell, value)
         bounds = bcf.Bounds
         color = "Blue"
      ElseIf TypeOf ff Is OcrField Then
         Dim ocf As OcrField = CType(ff, OcrField)
         Dim ofr As OcrFieldResult = CType(ocf.Result, OcrFieldResult)
         Dim target As RasterImage = GetCroppedImage(masterSheet, ocf.Bounds)
         sfp.Visible = False
         trp.Visible = True
         Dim text As String = If(ofr IsNot Nothing, ofr.Text, "")
         Dim confidence As Integer = If(ofr IsNot Nothing, ofr.Confidence, -1)
         trp.Populate(target, cell, text, confidence)
         bounds = ocf.Bounds
         color = "Red"
      ElseIf TypeOf ff Is ImageField Then
         Dim imf As ImageField = CType(ff, ImageField)
         Dim imfr As ImageFieldResult = CType(imf.Result, ImageFieldResult)
         sfp.Visible = False
         trp.Visible = True

         If imfr Is Nothing Then
            Dim target As RasterImage = GetCroppedImage(masterSheet, imf.Bounds)
            trp.Populate(target, cell, imf.Name)
         Else
            trp.Populate(imfr.Image, cell, imf.Name)
         End If

         bounds = imf.Bounds
         color = "Yellow"
      End If

      DoAnswerFieldSetup(cell)
      AddHighlight(bounds, color)
      Return True
   End Function

   Private Sub DoAnswerFieldSetup(ByVal cell As DataGridViewCell)
      If answerRow IsNot Nothing Then
         Dim bounds As LeadRect = LeadRect.Empty

         If TypeOf cell.Tag Is OmrCollection Then
            bounds = (CType(answerRow.Cells(cell.ColumnIndex).Tag, OmrCollection)).Bounds
         ElseIf TypeOf cell.Tag Is Field Then
            bounds = (CType(answerRow.Cells(cell.ColumnIndex).Tag, Field)).Bounds
         End If

         Using page As RasterImage = workspace.ImageManager.GetPage(workspace.IMGMGR_ANSWERS, currentPage)

            If page IsNot Nothing Then
               Dim answerCrop As RasterImage = GetCroppedImage(page, bounds)
               answerViewer.Image = answerCrop
               answerViewer.Zoom(ControlSizeMode.FitAlways, 1, LeadPoint.Empty)
            Else
               lblAnswerKey.Visible = True
               lblAnswerKey.Text = LBL_ANSWERKEY_MISSING
            End If
         End Using
      Else
         answerViewer.Image = Nothing
      End If
   End Sub

   Private Function DoPageSetup(ByVal cell As DataGridViewCell, ByVal stayOnPage As Boolean) As Boolean
      Dim ff As Object = cell.Tag
      Dim newPage As Integer = 0

      If TypeOf ff Is OmrCollection Then
         Dim oc As OmrCollection = TryCast(ff, OmrCollection)
         Dim rp As ReviewParameters = CType(oc.Tag, ReviewParameters)
         newPage = rp.PageNumber
      ElseIf TypeOf ff Is Field Then
         Dim f As Field = TryCast(ff, Field)
         newPage = f.PageNumber
      ElseIf ff Is Nothing Then
         Return False
      End If

      If masterSheet IsNot Nothing AndAlso Not stayOnPage Then
         AdvanceToNextPage(newPage - currentPage)
      End If

      Return newPage = currentPage
   End Function

   Private Sub AdvanceToNextPage(ByVal v As Integer)
      Dim newPage As Integer = currentPage + v

      If newPage > 0 AndAlso newPage <= maxPages Then
         currentPage = newPage
         masterSheet.Page = newPage
      End If

      lblCurrentPage.Text = String.Format("Page {0} of {1}", currentPage, maxPages)
   End Sub

   Private Sub PopulateAnswerArea(ByVal bounds As LeadRect, ByVal color As String)
   End Sub

   Private Function ExtractIdentifier(ByVal identifier As String) As String
      Dim idStart As Integer = identifier.LastIndexOf("["c)
      Dim idStop As Integer = identifier.LastIndexOf("]"c)

      If idStart < idStop Then
         idStart += 1
         idStop = Math.Min(idStop, identifier.Length)
         identifier = identifier.Substring(idStart, idStop - idStart)
      End If

      Return identifier
   End Function

   Private Sub SetupAnnotations(ByVal image As RasterImage)
      annAutomationManager = New AnnAutomationManager()
      _annotationsHelper = New AutomationManagerHelper(annAutomationManager)
      annAutomationManager.CreateDefaultObjects()
      annAutomationManager.UserMode = AnnUserMode.Render
      masterSheetViewer.Image = image
      automation = New AnnAutomation(annAutomationManager, masterSheetViewer)
      automation.Active = True
      automation.Container.Children.Clear()
      annotationField = New AnnHiliteObject()
      annotationField.HiliteColor = "Green"
      automation.Container.Children.Add(annotationField)
   End Sub

   Private Sub AddHighlight(ByVal highlightBounds As LeadRect, ByVal color As String)
      If masterSheet Is Nothing Then
         Return
      End If

      masterSheetViewer.BeginUpdate()
      Dim rect As LeadRectD = BoundsToAnnotations(highlightBounds)
      rect.Inflate(INFLATE, INFLATE)
      annotationField.HiliteColor = color
      annotationField.Rect = rect
      masterSheetViewer.EndUpdate()
   End Sub

   Private Function BoundsToAnnotations(ByVal rect As LeadRect) As LeadRectD
      Dim rc As LeadRectD = rect.ToLeadRectD()
      rc = masterSheetViewer.ConvertRect(Nothing, ImageViewerCoordinateType.Image, ImageViewerCoordinateType.Control, rc)
      rc = automation.Container.Mapper.RectToContainerCoordinates(rc)
      Return rc
   End Function

   Private Shared Function GetCroppedImage(ByVal input As RasterImage, ByVal boundaries As LeadRect) As RasterImage
      boundaries.Inflate(INFLATE, INFLATE)
      Dim target As RasterImage = Nothing

      Try
         target = input.Clone()
         Dim cc As CropCommand = New CropCommand()
         cc.Rectangle = boundaries
         cc.Run(target)
      Catch ex As Exception
         Return Nothing
      End Try

      Return target
   End Function

   Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs)
      Me.Close()
   End Sub

   Private Sub btnPreviousWorksheet_Click(ByVal sender As Object, ByVal e As EventArgs)
      cbFiles.SelectedIndex -= 1
   End Sub

   Private Sub btnNextWorksheet_Click(ByVal sender As Object, ByVal e As EventArgs)
      If cbFiles.SelectedIndex + 1 = cbFiles.Items.Count Then
         Return
      End If

      cbFiles.SelectedIndex += 1
   End Sub

   Private Function AdvanceToNextWorkSheet(ByVal v As Integer, ByVal newColumnIndex As Integer) As Boolean
      Dim tempRowIndex As Integer = rowIndex
      tempRowIndex += v

      While tempRowIndex >= 0 AndAlso tempRowIndex < dgv.Rows.Count

         If dgv.Rows(tempRowIndex).Tag IsNot Nothing Then
            rowIndex = tempRowIndex
            columnIndex = newColumnIndex
            cbFiles.SelectedIndex += v
            Return True
         Else
            Exit While
         End If
      End While

      Return False
   End Function

   Private Sub btnNextZone_Click(ByVal sender As Object, ByVal e As EventArgs)
      AdvanceToNextZone(1)
   End Sub

   Private Sub btnPreviousZone_Click(ByVal sender As Object, ByVal e As EventArgs)
      AdvanceToNextZone(-1)
   End Sub

   Private Sub AdvanceToNextZone(ByVal dir As Integer)
      Dim tempColumnIndex As Integer = columnIndex
      tempColumnIndex += dir
      Dim min As Integer = If(dgv.Columns(0).Tag Is Nothing, 1, 0)
      Dim max As Integer = dgv.Columns.Count
      Dim found As Boolean = True

      While found

         While tempColumnIndex >= min AndAlso tempColumnIndex < max
            Dim cell As DataGridViewCell = dgv(tempColumnIndex, rowIndex)

            If rdbtnAllFields.Checked AndAlso ((TypeOf cell.Tag Is Field AndAlso Not chkSkipNonOMR.Checked) OrElse (TypeOf cell.Tag Is Field = False)) Then
               columnIndex = tempColumnIndex
               cbZones.SelectedItem = dgv.Columns(columnIndex)
               Return
            End If

            If TypeOf cell.Tag Is OmrCollection Then
               Dim oc As OmrCollection = CType(cell.Tag, OmrCollection)
               Dim rp As ReviewParameters = CType(oc.Tag, ReviewParameters)
               Dim errorParams As VerificationParameters = rp.ErroredParameters

               If workspace.VerificationParameters.IsAtLeastOneTrue(errorParams) Then
                  columnIndex = tempColumnIndex
                  cbZones.SelectedItem = dgv.Columns(columnIndex)
                  Return
               End If
            ElseIf cell.Tag IsNot Nothing AndAlso chkSkipNonOMR.Checked = False Then
               columnIndex = tempColumnIndex
               cbZones.SelectedItem = dgv.Columns(columnIndex)
               Return
            End If

            tempColumnIndex += dir
         End While

         tempColumnIndex = If(dir = 1, min, max - 1)
         found = AdvanceToNextWorkSheet(dir, tempColumnIndex)
      End While

      MessageBox.Show("No other matches found for the specified criteria.")
   End Sub

   Private Sub UpdateNavigationEnables()
      btnPreviousPage.Enabled = masterSheet IsNot Nothing AndAlso masterSheet.Page > 1
      btnNextPage.Enabled = masterSheet IsNot Nothing AndAlso masterSheet.Page < masterSheet.PageCount
      btnNextWorksheet.Enabled = (rowIndex < dgv.Rows.Count - 1) AndAlso (dgv.Rows(rowIndex + 1).Tag IsNot Nothing)
      btnPreviousWorksheet.Enabled = (rowIndex > 0) AndAlso (dgv.Rows(rowIndex - 1).Tag IsNot Nothing)
   End Sub

   Private Sub rdbtnAllFields_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
      btnChooseFilters.Enabled = rdbtnSpecific.Checked
   End Sub

   Private Sub btnChooseFilters_Click(ByVal sender As Object, ByVal e As EventArgs)
      Dim mrp As ManualReviewPanel = New ManualReviewPanel(workspace.VerificationParameters, "Choose what to review manually")

      If isAnswerKeySelected Then
         mrp.UpdateUI(False)
      Else
         mrp.UpdateUI(workspace.AnswersPresent)
      End If

      Dim pid As ProcessInputDialog = New ProcessInputDialog(mrp, "Update Criteria")

      If pid.ShowDialog() = DialogResult.OK Then
         workspace.VerificationParameters = mrp.VerificationParameters
      End If
   End Sub

   Private Sub btnPreviousPage_Click(ByVal sender As Object, ByVal e As EventArgs)
      AdvanceToNextPage(-1)

      If dgv.ColumnCount = 1 Then
         columnIndex = 0
      Else

         If columnIndex >= dgv.ColumnCount Then
            columnIndex = dgv.ColumnCount - 1
         End If

         While columnIndex >= 0 AndAlso columnIndex < dgv.ColumnCount
            Dim cell As DataGridViewCell = dgv(columnIndex, rowIndex)

            If TypeOf cell.Tag Is OmrCollection Then

               If (CType((CType(cell.Tag, OmrCollection)).Tag, ReviewParameters)).PageNumber = currentPage Then
                  Exit While
               End If
            ElseIf TypeOf cell.Tag Is Field Then

               If (CType(cell.Tag, Field)).PageNumber = currentPage Then
                  Exit While
               End If
            End If

            columnIndex -= 1
         End While
      End If

      DoZoneSetup(True)
   End Sub

   Private Sub btnNextPage_Click(ByVal sender As Object, ByVal e As EventArgs)
      AdvanceToNextPage(1)
      columnIndex = If(columnIndex = -1, 0, columnIndex)

      If dgv.ColumnCount = 1 Then
         columnIndex = 0
      Else

         While columnIndex < dgv.ColumnCount
            Dim cell As DataGridViewCell = dgv(columnIndex, rowIndex)

            If TypeOf cell.Tag Is OmrCollection Then

               If (CType((CType(cell.Tag, OmrCollection)).Tag, ReviewParameters)).PageNumber = currentPage Then
                  Exit While
               End If
            ElseIf TypeOf cell.Tag Is Field Then

               If (CType(cell.Tag, Field)).PageNumber = currentPage Then
                  Exit While
               End If
            End If

            columnIndex += 1
         End While
      End If

      DoZoneSetup(True)
   End Sub

   Private Sub cbFiles_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
      Dim selectedForm As IRecognitionForm = CType(cbFiles.SelectedItem, IRecognitionForm)

      If selectedForm Is Nothing Then
         Return
      End If

      For i As Integer = 0 To dgv.Rows.Count - 1

         If dgv.Rows(i).HeaderCell.Value IsNot Nothing AndAlso dgv.Rows(i).HeaderCell.Value.ToString() = selectedForm.Name Then
            rowIndex = i
            Exit For
         End If
      Next

      DoWorksheetSetup(selectedForm)
      DoZoneSetup()
      UpdateNavigationEnables()
   End Sub

   Private Sub cbZones_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
      Dim dgvc As DataGridViewColumn = CType(cbZones.SelectedItem, DataGridViewColumn)

      If dgvc IsNot Nothing Then
         columnIndex = dgvc.Index
         DoZoneSetup()
      End If
   End Sub
End Class
