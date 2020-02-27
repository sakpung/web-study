Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms
Imports Leadtools
Imports Leadtools.Codecs
Imports System.IO
Imports System.Diagnostics
Imports Leadtools.Forms.Processing.Omr
Imports Leadtools.Forms.Processing.Omr.Fields
Imports Leadtools.Forms.Common
Imports Leadtools.ImageProcessing
Imports System.Runtime.Serialization.Formatters.Binary
Imports Leadtools.Controls
Imports System.Reflection
Imports Microsoft.VisualBasic

Partial Public Class ResultsPanel
   Inherits UserControl

   Private _riv As ImageViewer
   Private _answersRow As DataGridViewRow
   Private Const ROW_STATS_HEADER As String = "Statistics"
   Private _statsRowIndex As Integer = -1
   Private _gradesCol As DataGridViewColumn
   Friend TemplateImage As RasterImage
   Public Property CurrentTemplate As ITemplateForm
   Private _highlightOptionsDialog As HighlightOptionsDialog
   Private _workspace As Workspace

   Public ReadOnly Property CurrentWorkspace As Workspace
      Get
         Return _workspace
      End Get
   End Property

   Public Event CloseRequested As EventHandler(Of CloseRequestArgs)

   Public Sub New()
      InitializeComponent()
      _highlightOptionsDialog = New HighlightOptionsDialog()
      AddHandler _highlightOptionsDialog.ColorCodeUpdated, AddressOf ColorCodeUpdated
      _riv = New ImageViewer()
      _riv.Dock = DockStyle.Fill
      spltResults.Panel2.Controls.Add(_riv)
      Dim templateCell As DataGridViewCell = New DataGridViewTextBoxCell()
      _gradesCol = New DataGridViewColumn(templateCell)
      _gradesCol.Name = "Grades"
   End Sub

   Private Sub DgvResults_CellEndEdit(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)
   End Sub

   Private Function FillResults(ByVal form As IRecognitionForm, ByVal isAnswer As Boolean) As Integer
      Dim row As DataGridViewRow = Nothing

      If isAnswer Then
         _answersRow = New DataGridViewRow()
         row = _answersRow
      Else
         row = New DataGridViewRow()
      End If

      row.HeaderCell.Value = form.Name
      row.Tag = form
      Dim answerRowIdx As Integer = 0

      For Each page As Page In form.Pages

         For i As Integer = 0 To page.Fields.Count - 1
            Dim ff As Field = page.Fields(i)
            Dim dgvc As DataGridViewCell = CType(dgvResults.Columns(i).CellTemplate.Clone(), DataGridViewCell)
            dgvc.Tag = ff

            If TypeOf ff Is OmrField Then
               Dim ofr As OmrField = TryCast(ff, OmrField)

               If ofr.Options.TextFormat = OmrTextFormat.CSV Then

                  For j As Integer = 0 To ofr.Fields.Count - 1
                     Dim oc As OmrCollection = ofr.Fields(j)
                     dgvc = CType(dgvResults.Columns(j).CellTemplate.Clone(), DataGridViewCell)
                     dgvc.Value = oc.Value
                     dgvc.ValueType = GetType(String)
                     dgvc.Tag = oc
                     row.Cells.Add(dgvc)
                  Next
               Else
                  Dim output As String = ""
                  Dim offr As OmrFieldResult = TryCast(ofr.Result, OmrFieldResult)

                  If offr IsNot Nothing Then
                     output = offr.Text
                  Else

                     For j As Integer = 0 To ofr.Fields.Count - 1
                        Dim oc As OmrCollection = ofr.Fields(j)
                        output += oc.Value
                     Next
                  End If

                  dgvc.Value = output
                  dgvc.Tag = ofr
                  answerRowIdx += 1
                  row.Cells.Add(dgvc)
               End If

               Continue For
            ElseIf TypeOf ff Is BarcodeField Then
               Dim bcf As BarcodeField = TryCast(ff, BarcodeField)
               Dim bcfr As BarcodeFieldResult = CType(bcf.Result, BarcodeFieldResult)

               If bcfr Is Nothing OrElse bcfr.Status = FieldStatus.Failed OrElse bcfr.BarcodeData.Count < 1 Then
                  dgvc.Value = "Failed"
               Else
                  Dim bcd As Barcode.BarcodeData = bcfr.BarcodeData(0)
                  dgvc.Value = bcd.Value
               End If

               answerRowIdx += 1
            ElseIf TypeOf ff Is OcrField Then
               Dim ocf As OcrFieldResult = TryCast((CType(ff, OcrField)).Result, OcrFieldResult)

               If ocf IsNot Nothing Then
                  dgvc.Value = ocf.Text.Replace(Constants.vbCr, "").Replace(Constants.vbLf, "")
               Else
                  dgvc.Value = ""
               End If

               answerRowIdx += 1
            ElseIf TypeOf ff Is ImageField Then
               Dim imf As ImageField = CType(ff, ImageField)
               Dim ifr As ImageFieldResult = CType(imf.Result, ImageFieldResult)
               dgvc.Value = "View"
               answerRowIdx += 1
            End If

            row.Cells.Add(dgvc)
         Next
      Next

      dgvResults.Rows.Add(row)
      Return row.Index
   End Function

   Public Function DoOMRProcessing() As Boolean
      Dim isAnswerPresent As Boolean = CurrentTemplate.Pages.Any(Function(pg As Page) pg.Fields.Any(Function(ff As Field) If(TryCast(ff, OmrField) IsNot Nothing, (CType(ff, OmrField)).Options.GradeThisField, False)))
      Dim ip As InputPanel = New InputPanel(CurrentTemplate.Pages.Count)
      Dim kp As KeyPanel = New KeyPanel(isAnswerPresent, CurrentTemplate.Pages.Count)
      Dim pid As ProcessInputDialog = New ProcessInputDialog(New WizardStep() {ip, kp})

      If pid.ShowDialog() = DialogResult.Cancel Then
         Return False
      End If

      _workspace = New Workspace(ip, kp, CurrentTemplate)
      _workspace.Process()

      If ip.DoSaveWorkspace Then
         SaveWorkspace(ip.SelectedFilePath)
      End If

      If _workspace.ErrorList.Count > 0 Then
         Dim message As String = "Unable to recognize these files:"

         For i As Integer = 0 To _workspace.ErrorList.Count - 1
            message += Constants.vbLf & _workspace.ErrorList(i)
         Next

         MessageBox.Show(message)
      End If

      gradeToolStripMenuItem.Enabled = _workspace.AnswersPresent
      verifyAnswersToolStripMenuItem.Enabled = _workspace.AnswersPresent
      PopulateDefaultDataGridView()
      dgvStats.Rows.Clear()
      dgvStats.Columns.Clear()
      DoGrading()
      Return True
   End Function

   Public Sub ShowPostProcessingResults()
      If _workspace Is Nothing OrElse (_workspace.Answers Is Nothing AndAlso (_workspace.Results Is Nothing OrElse _workspace.Results.Count = 0)) Then
         Return
      End If

      Dim esp As ErrorStatisticsPanel = New ErrorStatisticsPanel(_workspace.AnswerReviewCounts, _workspace.ResultsReviewCounts)
      Dim pid As ProcessInputDialog = New ProcessInputDialog(esp, "&Close", False)
      pid.ShowDialog()
      ToggleColorCode()
   End Sub

   Private Sub PopulateDefaultDataGridView()
      If _workspace Is Nothing OrElse (_workspace.Answers Is Nothing AndAlso (_workspace.Results Is Nothing OrElse _workspace.Results.Count = 0)) Then
         Return
      End If

      Dim current As Cursor = Me.ParentForm.Cursor
      Me.ParentForm.Cursor = Cursors.WaitCursor
      PopulateDataGridView(_workspace.Template, _workspace.Answers, _workspace.Results)
      UpdateGridCellColors()
      saveWorkspaceToolStripMenuItem.Enabled = True
      saveWorkspaceAsToolStripMenuItem.Enabled = True
      exportCSVToolStripMenuItem.Enabled = True
      closeWorkspaceToolStripMenuItem.Enabled = True
      searchToolStripMenuItem.Enabled = True
      tssSearch.Enabled = True
      tssToggleColorLegend.Enabled = True
      lockToolStripMenuItem.Enabled = True
      colorsToolStripMenuItem.Enabled = True
      changeActiveFiltersToolStripMenuItem.Enabled = True
      swapStatisticsRowsAndColumnsToolStripMenuItem.Enabled = True
      tssUpdateItems.Enabled = True
      gradingToolStripMenuItem.Enabled = True
      Me.ParentForm.Cursor = current
   End Sub

   Private Sub PopulateDataGridView(ByVal otf As ITemplateForm, ByVal answers As IRecognitionForm, ByVal results As List(Of IRecognitionForm))
      dgvResults.Rows.Clear()
      dgvResults.Columns.Clear()
      _answersRow = Nothing
      BuildColumnHeaders(otf)
      _statsRowIndex = -1

      If answers IsNot Nothing AndAlso answers.Pages.Count > 0 Then
         PopulateAnswers(answers)
      End If

      For i As Integer = 0 To results.Count - 1
         Dim form As IRecognitionForm = results(i)
         FillResults(form, False)
      Next

      SetRowHeaderValues()
   End Sub

   Private Sub PopulateAnswers(ByVal answers As IRecognitionForm)
      FillResults(answers, True)
      _answersRow.Frozen = True
      Dim statsRow As DataGridViewRow = New DataGridViewRow()
      statsRow.HeaderCell.Value = ROW_STATS_HEADER
      statsRow.CreateCells(dgvResults)
      statsRow.Frozen = True
      _statsRowIndex = dgvResults.Rows.Add(statsRow)
      dgvResults.Rows.Add(New DataGridViewRow())
   End Sub

   Private Sub BuildColumnHeaders(ByVal otf As ITemplateForm)
      For i As Integer = 0 To otf.Pages.Count - 1
         Dim fp As Page = otf.Pages(i)

         For j As Integer = 0 To fp.Fields.Count - 1
            Dim ff As Field = fp.Fields(j)

            If TypeOf ff Is OmrField Then
               Dim orf As OmrField = CType(ff, OmrField)
               orf = TryCast(ff, OmrField)
               Dim orfr As OmrFieldResult = TryCast(orf.Result, OmrFieldResult)

               If orf.Options.TextFormat = OmrTextFormat.CSV Then

                  For k As Integer = 0 To orf.Fields.Count - 1
                     Dim oc As OmrCollection = orf.Fields(k)
                     oc.Tag = fp.PageNumber
                     Dim dgvcc As DataGridViewTextBoxCell = New DataGridViewTextBoxCell()
                     Dim dgCol As DataGridViewColumn = New DataGridViewColumn(dgvcc)
                     dgCol.Tag = oc
                     dgCol.Name = orf.Name & " " + oc.Name
                     dgvResults.Columns.Add(dgCol)
                  Next
               Else
                  Dim dgvcc As DataGridViewTextBoxCell = New DataGridViewTextBoxCell()
                  Dim dgCol As DataGridViewColumn = New DataGridViewColumn(dgvcc)
                  dgCol.Tag = orf
                  dgCol.Name = orf.Name
                  dgvResults.Columns.Add(dgCol)
               End If
            Else
               Dim dgvc As DataGridViewCell = New DataGridViewTextBoxCell()
               Dim dgcol As DataGridViewColumn = New DataGridViewColumn(dgvc)
               dgcol.Tag = ff
               dgcol.Name = ff.Name
               dgvResults.Columns.Add(dgcol)
            End If
         Next
      Next
   End Sub

   Private Sub DgvResults_CellValueChanged(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)
      If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then
         Return
      End If

      Dim modifiedCell As DataGridViewCell = dgvResults(e.ColumnIndex, e.RowIndex)
      CellValueModified(modifiedCell)
   End Sub

   Private Sub UpdateGridCellColors()
      For i As Integer = 0 To dgvResults.Rows.Count - 1
         Dim currentRow As DataGridViewRow = dgvResults.Rows(i)

         If currentRow.Tag Is Nothing Then
            Continue For
         End If

         If _answersRow IsNot Nothing AndAlso _answersRow.Index = currentRow.Index Then
            HandleAnswerRow(currentRow)
         Else
            HandleStandardRow(currentRow)
         End If
      Next
   End Sub

   Private Sub HandleAnswerRow(ByVal currentRow As DataGridViewRow)
      For i As Integer = 0 To currentRow.Cells.Count - 1
         Dim cell As DataGridViewCell = currentRow.Cells(i)
         Dim oc As OmrCollection = TryCast(cell.Tag, OmrCollection)

         If oc Is Nothing Then
            Continue For
         End If

         Dim rp As ReviewParameters = TryCast(oc.Tag, ReviewParameters)

         If rp Is Nothing Then
            Continue For
         End If

         Dim needsReview As Boolean = _workspace.VerificationParameters.IsAtLeastOneTrueWithoutKey(rp.ErroredParameters)
         cell.Style = If(needsReview, _highlightOptionsDialog.ClReview, _highlightOptionsDialog.ClExpected)
      Next
   End Sub

   Private Sub HandleStandardRow(ByVal currentRow As DataGridViewRow)
      For i As Integer = 0 To currentRow.Cells.Count - 1
         Dim cell As DataGridViewCell = currentRow.Cells(i)
         HandleCell(cell)
      Next
   End Sub

   Private Sub HandleCell(ByVal cell As DataGridViewCell)
      Dim answersPresent As Boolean = _answersRow IsNot Nothing
      Dim answerVal As String = If(_answersRow IsNot Nothing AndAlso _answersRow.Cells(cell.ColumnIndex).Value IsNot Nothing, _answersRow.Cells(cell.ColumnIndex).Value.ToString(), String.Empty)
      Dim isCorrect As Boolean = If(cell.Value IsNot Nothing, cell.Value.ToString() = answerVal, False)

      If TypeOf cell.Tag Is OmrCollection Then
         Dim oc As OmrCollection = TryCast(cell.Tag, OmrCollection)
         Dim rp As ReviewParameters = TryCast(oc.Tag, ReviewParameters)

         If rp Is Nothing Then
            Return
         End If

         If _workspace.VerificationParameters.IsAtLeastOneTrue(rp.ErroredParameters) Then
            cell.Style = _highlightOptionsDialog.ClReview
         ElseIf answersPresent AndAlso (rp.ReviewRequired = False OrElse rp.ErroredParameters.UseValueChanged) Then
            cell.Style = If(isCorrect, _highlightOptionsDialog.ClModifiedCorrect, _highlightOptionsDialog.ClModifiedIncorrect)
         ElseIf answersPresent Then
            cell.Style = If(isCorrect, _highlightOptionsDialog.ClCorrect, _highlightOptionsDialog.ClIncorrect)
         ElseIf rp.ErroredParameters.IsReviewed Then
            cell.Style = _highlightOptionsDialog.ClModifiedCorrect
         Else
            cell.Style = New DataGridViewCellStyle() With {
                .BackColor = Color.White
            }
         End If
      ElseIf TypeOf cell.Tag Is OcrField AndAlso answersPresent Then
      ElseIf _gradesCol IsNot Nothing AndAlso cell.ColumnIndex = _gradesCol.Index Then
      End If
   End Sub

   Private Sub CellValueModified(ByVal modifiedCell As DataGridViewCell)
      If lockToolStripMenuItem.Checked = False Then
         Return
      End If

      Dim ff As Object = modifiedCell.Tag

      If TypeOf ff Is OmrCollection Then
         Dim sff As OmrCollection = TryCast(ff, OmrCollection)
         Dim val As String = If(modifiedCell.Value IsNot Nothing, modifiedCell.Value.ToString(), Nothing)

         If sff.Value <> val Then
            Dim param As ReviewParameters = CType(sff.Tag, ReviewParameters)

            If param.OmrFieldValues.Contains(val) Then
               sff.Value = val
            Else
               modifiedCell.Value = sff.Value
            End If
         End If
      End If

      If _answersRow Is Nothing Then
         Dim cell As DataGridViewCell = modifiedCell
         Dim oc As OmrCollection = TryCast(cell.Tag, OmrCollection)

         If oc IsNot Nothing Then
            Dim rp As ReviewParameters = TryCast(oc.Tag, ReviewParameters)

            If rp IsNot Nothing AndAlso rp.ReviewRequired = False Then
               cell.Style = _highlightOptionsDialog.ClModifiedCorrect
            End If
         End If

         Return
      End If

      If modifiedCell.OwningRow Is _answersRow Then
         For i As Integer = 0 To dgvResults.Rows.Count - 1

            If i = _answersRow.Index Then
               Continue For
            End If

            Dim cell As DataGridViewCell = dgvResults(modifiedCell.ColumnIndex, i)
            Dim oc As OmrCollection = TryCast(cell.Tag, OmrCollection)

            If oc IsNot Nothing Then
               Dim rp As ReviewParameters = CType(oc.Tag, ReviewParameters)

               If (CType(oc.Tag, ReviewParameters)).ReviewRequired = False Then
                  cell.Style = If(cell.Value.ToString() = modifiedCell.Value.ToString(), _highlightOptionsDialog.ClModifiedCorrect, _highlightOptionsDialog.ClModifiedIncorrect)
               Else

                  If _workspace.VerificationParameters.IsAtLeastOneTrueWithoutKey(rp.ErroredParameters) Then
                     cell.Style = _highlightOptionsDialog.ClReview
                  Else
                     cell.Style = If(cell.Value.ToString() = modifiedCell.Value.ToString(), _highlightOptionsDialog.ClCorrect, _highlightOptionsDialog.ClIncorrect)
                  End If
               End If
            End If
         Next
      ElseIf TypeOf modifiedCell.Tag Is OmrCollection Then

         If TypeOf modifiedCell.Tag Is OmrCollection Then
            Dim oc As OmrCollection = TryCast(modifiedCell.Tag, OmrCollection)
            Dim rp As ReviewParameters = TryCast(oc.Tag, ReviewParameters)

            If rp IsNot Nothing Then
               Dim p As VerificationParameters = rp.ErroredParameters
               p.UseValueChanged = oc.Value <> oc.OriginalValue
               rp.ErroredParameters = p

               If rp.ReviewRequired = False Then
                  Dim answerVal As String = CStr(_answersRow.Cells(modifiedCell.ColumnIndex).Value)
                  modifiedCell.Style = If(CStr(modifiedCell.Value) = answerVal, _highlightOptionsDialog.ClModifiedCorrect, _highlightOptionsDialog.ClModifiedIncorrect)
               End If
            End If
         End If
      End If

      If TypeOf modifiedCell.Tag Is OmrField Then
         Dim f As OmrField = TryCast(modifiedCell.Tag, OmrField)

         If f.Tag IsNot Nothing AndAlso TypeOf f.Tag Is Boolean Then

            If CBool(f.Tag) AndAlso TypeOf modifiedCell.OwningRow.Tag Is IRecognitionForm Then
               Dim frm As IRecognitionForm = TryCast(modifiedCell.OwningRow.Tag, IRecognitionForm)
               Dim idStart As Integer = frm.Name.LastIndexOf("["c)
               Dim idStop As Integer = frm.Name.LastIndexOf("]"c)

               If idStart < idStop Then
                  Dim name As String = frm.Name.Remove(idStart)
                  name += "[" & modifiedCell.Value.ToString() & "]"
                  frm.Name = name
                  modifiedCell.OwningRow.HeaderCell.Value = name
               End If
            End If
         End If
      End If
   End Sub

   Private Sub DgvResults_CellLeave(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)
      CellValueModified(dgvResults(e.ColumnIndex, e.RowIndex))
   End Sub

   Private Sub DgvResults_RowHeaderMouseClick(ByVal sender As Object, ByVal e As DataGridViewCellMouseEventArgs)
      spltResults.Panel2.Controls.Clear()

      If dgvResults.Rows(e.RowIndex).Tag Is Nothing Then
         Return
      End If

      Dim guid As String = (CType(dgvResults.Rows(e.RowIndex).Tag, IRecognitionForm)).Id
      Dim image As RasterImage = _workspace.ImageManager.[Get](guid)
      Dim iv As ImageViewer = New ImageViewer()
      iv.Image = image
      iv.Dock = DockStyle.Fill
      iv.Zoom(ControlSizeMode.Fit, 1, LeadPoint.Empty)
      spltResults.Panel2.Controls.Add(iv)
   End Sub

   Private Sub DgvResults_CellClick(ByVal sender As Object, ByVal e As DataGridViewCellEventArgs)
      If lockToolStripMenuItem.Checked = False Then
         Return
      End If

      If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then
         Return
      End If

      Dim cell As DataGridViewCell = dgvResults(e.ColumnIndex, e.RowIndex)
      ShowReviewDialog(cell)
   End Sub

   Private Sub ShowReviewDialog(ByVal cell As DataGridViewCell, Optional ByVal useWorkspaceParameters As Boolean = False)
      If cell Is Nothing OrElse cell.OwningRow.Tag Is Nothing Then
         Return
      End If

      Dim ff As Object = cell.Tag

      If TypeOf ff Is OmrCollection OrElse TypeOf ff Is Field Then
         lockToolStripMenuItem.Checked = True
         Dim srp As SingleReviewPanel = New SingleReviewPanel(_workspace, dgvResults, cell.ColumnIndex, cell.RowIndex, cell.OwningRow Is _answersRow, useWorkspaceParameters, _answersRow)
         srp.ShowDialog(Me)
         DoGrading()
      End If
   End Sub

   Private Sub exportResultsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      DoExportOperation(dgvResults)
   End Sub

   Private Sub exportStatsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      DoExportOperation(dgvStats)
   End Sub

   Private Sub DoExportOperation(ByVal dgv As DataGridView)
      Dim sfd As SaveFileDialog = New SaveFileDialog()
      sfd.AddExtension = True
      sfd.Filter = "CSV Files (*.csv)|*.CSV|HTML Files (*.html)|*.html"
      sfd.FilterIndex = 0
      sfd.DefaultExt = ".csv"

      If sfd.ShowDialog() = DialogResult.OK Then
         Dim bo As BusyOperation

         If Path.GetExtension(sfd.FileName) = ".csv" Then
            bo = New DataExporter(sfd.FileName, dgv)
         Else
            bo = New HTMLExporter(sfd.FileName, dgv)
         End If

         bo.Start()
      End If
   End Sub

   Private Sub changeKeyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      Dim isAnswerPresent As Boolean = CurrentTemplate.Pages.Any(Function(pg As Page) pg.Fields.Any(Function(ff As Field) If(TryCast(ff, OmrField) IsNot Nothing, (CType(ff, OmrField)).Options.GradeThisField, False)))
      Dim kp As KeyPanel = New KeyPanel(isAnswerPresent, CurrentTemplate.Pages.Count)
      Dim pid As ProcessInputDialog = New ProcessInputDialog(kp, "Change Key")

      If pid.ShowDialog(Me.ParentForm) = DialogResult.OK Then
         _workspace.UpdateAnswerKey(kp)
         PopulateDefaultDataGridView()
         DoGrading()
      End If
   End Sub

   Private Sub DoGrading()
      Dim grader As GradeOperation = _workspace.DoGrading()
      grader.Start()

      If _statsRowIndex <> -1 Then
         PopulateStatistics(grader)
      End If

      If _workspace.AnswersPresent Then
         PopulateGradeColumn(grader)

         If _statsRowIndex <> -1 Then
            dgvResults(_gradesCol.Index, _statsRowIndex) = New DataGridViewTextBoxCell() With {
                .Value = String.Format("{0}%", grader.Statistics.Mean.ToString("F2"))
            }
         End If
      End If

      dgvResults.Invalidate()
      PopulateExtendedStatistics(grader)
      exportStatsToolStripMenuItem.Enabled = True
   End Sub

   Private Sub PopulateExtendedStatistics(ByVal grader As GradeOperation)
      Dim current As Cursor = Me.ParentForm.Cursor
      Me.ParentForm.Cursor = Cursors.WaitCursor
      Dim stats As String(,) = If(swapStatisticsRowsAndColumnsToolStripMenuItem.Checked, grader.InvertedStats, grader.StatsArray)

      If stats Is Nothing Then
         Me.ParentForm.Cursor = current
         Return
      End If

      If swapStatisticsRowsAndColumnsToolStripMenuItem.Checked Then
         dgvStats.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
         dgvStats.ColumnHeadersHeight = 50
         dgvStats.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader
         RemoveHandler dgvStats.CellPainting, AddressOf dgvStats_CellPainting
      Else
         dgvStats.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
         dgvStats.ColumnHeadersHeight = 50
         dgvStats.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
         AddHandler dgvStats.CellPainting, AddressOf dgvStats_CellPainting
      End If

      Dim length As Integer = stats.GetLength(0)
      Dim width As Integer = stats.GetLength(1)
      dgvStats.Rows.Clear()
      dgvStats.Columns.Clear()
      dgvStats.Invalidate()

      For i As Integer = 0 To width - 1
         Dim val As String = stats(0, i)

         If String.IsNullOrEmpty(val) = False Then
            Dim dgvcc As DataGridViewTextBoxCell = New DataGridViewTextBoxCell()
            Dim dgvc As DataGridViewColumn = New DataGridViewColumn(dgvcc)
            dgvc.HeaderText = val
            dgvStats.Columns.Add(dgvc)
         End If
      Next

      For i As Integer = 1 To length - 1
         Dim row As DataGridViewRow = New DataGridViewRow()
         row.HeaderCell.Value = stats(i, 0)

         For j As Integer = 1 To width - 1
            Dim dgvc As DataGridViewCell = New DataGridViewTextBoxCell()
            dgvc.Value = stats(i, j)
            row.Cells.Add(dgvc)
         Next

         dgvStats.Rows.Add(row)
      Next

      dgvStats.Invalidate()
      Me.ParentForm.Cursor = current
   End Sub

   Private Sub PopulateGradeColumn(ByVal grader As GradeOperation)
      If (_gradesCol.DataGridView Is Nothing OrElse dgvResults.Columns.Contains(_gradesCol) = False) AndAlso _workspace.AnswersPresent Then
         _gradesCol.Frozen = True
         dgvResults.Columns.Insert(0, _gradesCol)
      End If

      For i As Integer = 0 To dgvResults.Rows.Count - 1
         Dim cell As DataGridViewCell = New DataGridViewTextBoxCell()
         Dim dgvr As DataGridViewRow = dgvResults.Rows(i)
         Dim currentCell As String = CStr(dgvr.HeaderCell.Value)

         If currentCell Is Nothing Then
            Continue For
         End If

         Dim startId As Integer = currentCell.LastIndexOf("[")
         Dim stopId As Integer = currentCell.LastIndexOf("]")

         If startId <> -1 AndAlso stopId <> -1 Then
            currentCell = currentCell.Substring(0, startId)
         End If

         Dim frm As IRecognitionForm = grader.Results.Find(Function(form As IRecognitionForm) form.Name = currentCell)

         If String.IsNullOrWhiteSpace(currentCell) = False AndAlso frm IsNot Nothing Then
            cell.Value = String.Format("{0}%", frm.Grade.ToString("F2"))
            cell.Style = If(frm.Grade > grader.PassingScore, _highlightOptionsDialog.ClCorrect, _highlightOptionsDialog.ClIncorrect)
         End If

         dgvr.Cells(_gradesCol.Index) = cell
      Next
   End Sub

   Private Sub PopulateStatistics(ByVal grader As GradeOperation)
      For i As Integer = 0 To dgvResults.Columns.Count - 1
         Dim col As DataGridViewColumn = dgvResults.Columns(i)
         Dim res As DataGridViewCell = New DataGridViewTextBoxCell()

         If grader.QuestionAnswers Is Nothing Then
            Continue For
         End If

         Dim prefix As String = "Page {0} "

         If TypeOf col.Tag Is Field Then
            Dim f As Field = TryCast(col.Tag, Field)
            prefix = String.Format(prefix, f.PageNumber)
         ElseIf TypeOf col.Tag Is OmrCollection Then
            Dim oc As OmrCollection = TryCast(col.Tag, OmrCollection)

            If oc.Tag IsNot Nothing Then
               prefix = String.Format(prefix, oc.Tag)
            End If
         End If

         Dim key As String = prefix & col.HeaderCell.Value.ToString()

         If grader.QuestionAnswers.ContainsKey(key) Then
            Dim qa As QuestionAnswers = grader.QuestionAnswers(key)
            res.Tag = qa

            If qa.Answer IsNot Nothing Then

               If qa.AnswersCount.ContainsKey(qa.Answer) Then
                  Dim correct As Integer = qa.AnswersCount(qa.Answer)
                  Dim total As Integer = qa.AnswersCount.Sum(Function(q) q.Value)
                  Dim value As Single = CSng(Math.Round(correct / (total * 1.0F), 2)) * 100
                  res.Value = String.Format("{0}%", value)
               End If
            End If
         End If

         dgvResults.Rows(_statsRowIndex).Cells(i) = res
      Next
   End Sub

   Private Sub colorsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      If _workspace IsNot Nothing Then
         _highlightOptionsDialog.ManualReviewPanel = New ManualReviewPanel(_workspace.VerificationParameters, "Select ""Needs Review"" Highlight Criteria")
         _highlightOptionsDialog.ManualReviewPanel.UpdateUI(_workspace.AnswersPresent)
      End If

      _highlightOptionsDialog.ShowDialog(Me.ParentForm)

      If _workspace IsNot Nothing Then
         _workspace.VerificationParameters = _highlightOptionsDialog.ManualReviewPanel.VerificationParameters
      End If

      UpdateGridCellColors()
   End Sub

   Private Sub ColorCodeUpdated(ByVal sender As Object, ByVal e As EventArgs)
      If _workspace IsNot Nothing Then
         _workspace.VerificationParameters = _highlightOptionsDialog.ManualReviewPanel.VerificationParameters
         UpdateGridCellColors()
      End If
   End Sub

   Private Sub saveWorkspaceAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      Dim path As String = ""

      If MainForm.ChooseWorkspaceFilePath(path) Then
         SaveWorkspace(path)
      End If
   End Sub

   Private Sub saveWorkspaceToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      DoSaveWorkspace()
   End Sub

   Public Function DoSaveWorkspace() As Boolean
      If _workspace IsNot Nothing Then
         If String.IsNullOrEmpty(_workspace.LocationOnDisk) Then
            Dim path As String = ""

            If MainForm.ChooseWorkspaceFilePath(path) Then
               SaveWorkspace(path)
            Else
               Return False
            End If
         Else
            SaveWorkspace(_workspace.LocationOnDisk)
         End If
      End If

      Return True
   End Function

   Private Sub SaveWorkspace(ByVal path As String)
      Dim packWorkspace As BusyOperation = New SaveWorkspaceOperation(path, _workspace)
      packWorkspace.Start()
   End Sub

   Private Sub openToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      CloseWorkspace(CloseRequestArgs.ClosingReason.ToLoadExisting)
   End Sub

   Public Function OpenWorkspace() As Boolean
      Dim ofd As OpenFileDialog = New OpenFileDialog()
      ofd.Filter = String.Format("Workspace files|*{0}", MainForm.WORKSPACE_EXT)
      ofd.RestoreDirectory = False

      Dim defaultPath As String = Path.Combine(DemosGlobal.ImagesFolder, "\Forms\OMR Processing")
      ofd.InitialDirectory = defaultPath

      If ofd.ShowDialog() = DialogResult.OK Then
         Dim filename As String = ofd.FileName
         Dim lwo As LoadWorkspaceOperation = New LoadWorkspaceOperation(filename)
         lwo.Start()
         _workspace = lwo.LoadedWorkspace

         If _workspace IsNot Nothing Then
            Me.CurrentTemplate = _workspace.Template
            TemplateImage = _workspace.TemplateImage
            PopulateDefaultDataGridView()
            DoGrading()
            Return True
         End If
      End If

      Return False
   End Function

   Private Sub verifyAnswersToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      Dim mrp As ManualReviewPanel = New ManualReviewPanel(VerificationParameters.GetTemplate(VerificationParameters.FilterTemplate.CommonIssues), "Choose what to review manually")
      mrp.UpdateUI(False)
      Dim pid As ProcessInputDialog = New ProcessInputDialog(mrp, "Begin Review")

      If pid.ShowDialog() = DialogResult.OK Then
         _workspace.VerificationParameters = mrp.VerificationParameters
         Dim candidate As Integer = 0

         While _answersRow.Cells(candidate).Tag Is Nothing
            candidate += 1
         End While

         ShowReviewDialog(_answersRow.Cells(candidate), True)
      End If
   End Sub

   Private Sub tssUpdateItems_Click(ByVal sender As Object, ByVal e As EventArgs)
      DoGrading()
   End Sub

   Private Sub dgvResults_CellPainting(ByVal sender As Object, ByVal e As DataGridViewCellPaintingEventArgs)
      If e.RowIndex = -1 AndAlso e.ColumnIndex >= 0 AndAlso e.Value IsNot Nothing Then
         e.PaintBackground(e.ClipBounds, True)
         Dim rect As Rectangle = Me.dgvResults.GetColumnDisplayRectangle(e.ColumnIndex, True)
         Dim titleSize As Size = TextRenderer.MeasureText(e.Value.ToString(), e.CellStyle.Font)

         If Me.dgvResults.ColumnHeadersHeight < titleSize.Width Then
            Me.dgvResults.ColumnHeadersHeight = titleSize.Width
         End If

         e.Graphics.TranslateTransform(0, titleSize.Width)
         e.Graphics.RotateTransform(-90.0F)
         e.Graphics.DrawString(e.Value.ToString(), Me.Font, Brushes.Black, New PointF(rect.Y - (dgvResults.ColumnHeadersHeight - titleSize.Width), rect.X))
         e.Graphics.RotateTransform(90.0F)
         e.Graphics.TranslateTransform(0, -titleSize.Width)
         e.Handled = True
      End If
   End Sub

   Private Sub dgvStats_CellPainting(ByVal sender As Object, ByVal e As DataGridViewCellPaintingEventArgs)
      If e.RowIndex = -1 AndAlso e.ColumnIndex >= 0 AndAlso e.Value IsNot Nothing Then
         e.PaintBackground(e.ClipBounds, True)
         Dim rect As Rectangle = Me.dgvStats.GetColumnDisplayRectangle(e.ColumnIndex, True)
         Dim titleSize As Size = TextRenderer.MeasureText(e.Value.ToString(), e.CellStyle.Font)

         If Me.dgvStats.ColumnHeadersHeight < titleSize.Width Then
            Me.dgvStats.ColumnHeadersHeight = titleSize.Width
         End If

         e.Graphics.TranslateTransform(0, titleSize.Width)
         e.Graphics.RotateTransform(-90.0F)
         e.Graphics.DrawString(e.Value.ToString(), Me.Font, Brushes.Black, New PointF(rect.Y - (dgvStats.ColumnHeadersHeight - titleSize.Width), rect.X))
         e.Graphics.RotateTransform(90.0F)
         e.Graphics.TranslateTransform(0, -titleSize.Width)
         e.Handled = True
      End If
   End Sub

   Private Sub ResultsPanel_Load(ByVal sender As Object, ByVal e As EventArgs)
      dgvResults.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
      dgvResults.ColumnHeadersHeight = 50
      dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
      AddHandler dgvResults.CellValueChanged, AddressOf DgvResults_CellValueChanged
      AddHandler dgvResults.CellClick, AddressOf DgvResults_CellClick
      AddHandler dgvResults.CellEndEdit, AddressOf DgvResults_CellEndEdit
      AddHandler dgvResults.CellLeave, AddressOf DgvResults_CellLeave
   End Sub

   Private Sub lockToolStripMenuItem_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
      lockToolStripMenuItem.Image = If(Not lockToolStripMenuItem.Checked, Resources.locked, Resources.unlocked)
      lockToolStripMenuItem.Invalidate()

      If lockToolStripMenuItem.Checked Then
         ShowReviewDialog(dgvResults.CurrentCell)
      End If
   End Sub

   Private Sub searchToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      Dim rsd As ResultSearchDialog = New ResultSearchDialog(dgvResults)
      rsd.ShowDialog()
   End Sub

   Private Sub processReportToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      _workspace.ReprocessVerification(_workspace.VerificationParameters, _workspace.Answers, _workspace.Results)
      Dim esp As ErrorStatisticsPanel = New ErrorStatisticsPanel(_workspace.AnswerReviewCounts, _workspace.ResultsReviewCounts)
      Dim pid As ProcessInputDialog = New ProcessInputDialog(esp, "&Close", False)
      pid.ShowDialog()
   End Sub

   Private Sub aboutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      Dim ab As Demos.Dialogs.AboutDialog = New Demos.Dialogs.AboutDialog("OMR Processing", Demos.Dialogs.ProgrammingInterface.VB)
      ab.ShowDialog(Me.ParentForm)
   End Sub

   Private Sub changeActiveFiltersToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      Dim mrp As ManualReviewPanel = New ManualReviewPanel(_workspace.VerificationParameters, "Select ""Needs Review"" Highlight Criteria")
      mrp.UpdateUI(_workspace.AnswersPresent)
      Dim pid As ProcessInputDialog = New ProcessInputDialog(mrp, "Update Criteria")

      If pid.ShowDialog(Me.ParentForm) = DialogResult.OK Then
         _workspace.VerificationParameters = mrp.VerificationParameters
         UpdateGridCellColors()
      End If
   End Sub

   Private Sub reviewWorksheetsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      Dim mrp As ManualReviewPanel = New ManualReviewPanel(_workspace.VerificationParameters, "Choose what to review manually")
      mrp.UpdateUI(_workspace.AnswersPresent)
      Dim pid As ProcessInputDialog = New ProcessInputDialog(mrp, "Begin Review")

      If pid.ShowDialog() = DialogResult.OK Then
         _workspace.VerificationParameters = mrp.VerificationParameters
         Dim rowIndex As Integer = 0

         While dgvResults.Rows(rowIndex).Tag Is Nothing OrElse dgvResults.Rows(rowIndex) Is _answersRow
            rowIndex += 1
         End While

         Dim candidate As Integer = 0

         While dgvResults(candidate, rowIndex).Tag Is Nothing
            candidate += 1
         End While

         ShowReviewDialog(dgvResults(candidate, rowIndex), True)
      End If
   End Sub

   Private Sub showResultPanelToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      Dim showres As Boolean = showResultPanelToolStripMenuItem.Checked
      spltResults.Panel1Collapsed = Not showres
      showStatisticsPanelToolStripMenuItem.Enabled = showres
   End Sub

   Private Sub showStatisticsPanelToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      Dim showres As Boolean = showStatisticsPanelToolStripMenuItem.Checked
      spltResults.Panel2Collapsed = Not showres
      showResultPanelToolStripMenuItem.Enabled = showres
   End Sub

   Private Sub tssToggleColorLegend_Click(ByVal sender As Object, ByVal e As EventArgs)
      ToggleColorCode()
   End Sub

   Private Sub ToggleColorCode()
      _highlightOptionsDialog.ToggleColorCode()
   End Sub

   Friend Sub Deactivate()
      _highlightOptionsDialog.HideColorCode()
      '_highlightOptionsDialog.Dispose()
   End Sub

   Private Sub closeWorkspaceToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      CloseWorkspace(CloseRequestArgs.ClosingReason.RevertToIntro)
   End Sub

   Private Sub CloseWorkspace(ByVal closeReason As CloseRequestArgs.ClosingReason)
      If _workspace IsNot Nothing Then
         Dim saveHandled As Boolean = DoCloseWorkspace()

         If saveHandled Then
            OnCloseRequested(closeReason)
         End If
      Else
         OnCloseRequested(closeReason)
      End If
   End Sub

   Public Function DoCloseWorkspace() As Boolean
      If _workspace Is Nothing Then
         Return True
      End If

      Dim saved As Boolean = False
      Dim dr As DialogResult = MessageBox.Show(Me.ParentForm, "Save the currently open workspace?", "Closing", MessageBoxButtons.YesNoCancel)

      If dr = DialogResult.Yes Then
         saved = DoSaveWorkspace()
      ElseIf dr = DialogResult.No Then
         Return True
      ElseIf dr = DialogResult.Cancel Then
         Return False
      End If

      Return saved
   End Function

   Private Sub OnCloseRequested(ByVal closeReason As CloseRequestArgs.ClosingReason)
      RaiseEvent CloseRequested(Me, New CloseRequestArgs(closeReason))
   End Sub

   Private Sub dgv_MouseDown(ByVal sender As Object, ByVal e As MouseEventArgs)
      Dim dgv As DataGridView = TryCast(sender, DataGridView)

      If dgv Is Nothing Then
         Return
      End If

      Dim hti As System.Windows.Forms.DataGridView.HitTestInfo = dgv.HitTest(e.X, e.Y)

      If hti.ColumnIndex = -1 AndAlso hti.RowIndex >= 0 Then

         If dgv.SelectionMode <> DataGridViewSelectionMode.RowHeaderSelect Then
            dgv.SelectionMode = DataGridViewSelectionMode.RowHeaderSelect
         End If
      ElseIf hti.RowIndex = -1 AndAlso hti.ColumnIndex >= 0 Then

         If dgv.SelectionMode <> DataGridViewSelectionMode.ColumnHeaderSelect Then
            dgv.SelectionMode = DataGridViewSelectionMode.ColumnHeaderSelect
         End If
      End If
   End Sub

   Private Sub swapStatisticsRowsAndColumnsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      DoGrading()
   End Sub

   Private Sub exitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      CloseWorkspace(CloseRequestArgs.ClosingReason.ApplicationExiting)
   End Sub

   Private Sub SetRowHeaderValues()
      Dim newId As Field = Nothing

      If CurrentTemplate.IdentifierFieldId IsNot Nothing AndAlso CurrentTemplate.IdentifierFieldId.PageNumber > 0 Then
         newId = CurrentTemplate.Pages(CurrentTemplate.IdentifierFieldId.PageNumber - 1).Fields.FirstOrDefault(Function(f) f.Name = CurrentTemplate.IdentifierFieldId.FieldName)
      End If

      For i As Integer = 0 To dgvResults.Rows.Count - 1

         If dgvResults.Rows(i).Tag Is Nothing Then
            Continue For
         End If

         Dim frm As IRecognitionForm = CType(dgvResults.Rows(i).Tag, IRecognitionForm)
         Dim suffix As String = ""

         If newId IsNot Nothing Then
            Dim identifier As Field = frm.Pages(newId.PageNumber - 1).Fields.FirstOrDefault(Function(f) f.Name = newId.Name)

            If TypeOf identifier Is OmrField Then
               Dim omr As OmrField = CType(identifier, OmrField)
               Dim ofr As OmrFieldResult = CType(omr.Result, OmrFieldResult)
               suffix = If(ofr IsNot Nothing, ofr.Text, "")
            ElseIf TypeOf identifier Is BarcodeField Then
               Dim bcf As BarcodeField = CType(identifier, BarcodeField)
               Dim bcfr As BarcodeFieldResult = CType(bcf.Result, BarcodeFieldResult)

               If bcfr.BarcodeData.Count > 0 Then
                  suffix = bcfr.BarcodeData(0).Value
               End If
            ElseIf TypeOf identifier Is OcrField Then
               Dim ocr As OcrField = CType(identifier, OcrField)
               Dim ofr As OcrFieldResult = CType(ocr.Result, OcrFieldResult)
               suffix = If(ofr IsNot Nothing, ofr.Text, "")
            End If

            If String.IsNullOrEmpty(suffix) = False Then
               suffix = "[" & suffix & "]"
            End If
         End If

         dgvResults.Rows(i).HeaderCell.Value = frm.Name & suffix
      Next
   End Sub

   Private Sub changeIdentifierToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs)
      Dim fsd As FormSpecificDialog = New FormSpecificDialog(CurrentTemplate, False)

      If fsd.ShowDialog(Me.ParentForm) = DialogResult.OK Then
         SetRowHeaderValues()
      End If
   End Sub
End Class
