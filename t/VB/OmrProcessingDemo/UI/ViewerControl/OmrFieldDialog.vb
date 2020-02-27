Imports Leadtools
Imports Leadtools.Controls
Imports Leadtools.Forms.Processing.Omr.Fields
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Partial Public Class OmrFieldDialog
   Inherits Form

   Private _omrField As OmrField
   Private _values As List(Of List(Of String))
   Private _fieldImage As RasterImage
   Private _localOptions As OmrFieldOptions
   Private _indexRows As Integer
   Private _indexCols As Integer
   Private _imageViewer As ImageViewer
   Private _labels As List(Of OmrBubbleLabel)
   Private Const CUSTOM As String = " [CUSTOM]"

   Private Class OmrBubbleLabel
      Public Property Label As String
      Public Property Value As String
      Public Property Bounds As LeadRect

      Public Sub New(ByVal labelParam As String, ByVal valueParam As String, ByVal boundsParam As LeadRect)
         Me.Label = labelParam
         Me.Bounds = boundsParam
         Me.Value = valueParam
      End Sub
   End Class

   Public Sub New(ByVal omrField As OmrField, ByVal fieldImage As RasterImage)
      InitializeComponent()
      _fieldImage = fieldImage
      _imageViewer = New ImageViewer()
      _imageViewer.Dock = DockStyle.Fill
      AddHandler _imageViewer.ItemChanged, AddressOf ImageViewer_ItemChanged
      pnlImg.Controls.Add(_imageViewer)
      _omrField = omrField
      _localOptions = _omrField.Options
      DataToControls()
   End Sub

   Private Sub ImageViewer_ItemChanged(ByVal sender As Object, ByVal e As ImageViewerItemChangedEventArgs)
      If e.Reason = ImageViewerItemChangedReason.Image Then
         _imageViewer.Zoom(ControlSizeMode.Fit, 1, LeadPoint.Empty)
      End If
   End Sub

   Private Sub DataToControls()
      _values = New List(Of List(Of String))()
      rdbtnOrRows.Text = "Rows: " & _omrField.RowsCount
      rdbtnOrCols.Text = "Columns: " & _omrField.ColumnsCount
      _labels = New List(Of OmrBubbleLabel)()

      If _omrField.FieldBubbleLayoutType = OmrFieldBubbleLayoutType.BubbleWithLabel Then
         grpLabelOptions.Enabled = True
         grpLabelOptions.Visible = True
         grpGrid.Enabled = False
         grpGrid.Visible = False

         For i As Integer = 0 To _omrField.Fields.Count - 1

            For j As Integer = 0 To _omrField.Fields(i).Fields.Count - 1
               Dim bub As OmrBubble = _omrField.Fields(i).Fields(j)
               Dim label As OmrBubbleLabel = New OmrBubbleLabel(bub.Label, bub.Value, bub.LabelBounds)
               _labels.Add(label)
            Next
         Next

         cboxValues.Items.AddRange(_labels.ToArray())
         cboxValues.DisplayMember = "Label"

         If _labels.Count > 0 Then
            cboxValues.SelectedIndex = 0
         End If
      Else
         grpGrid.Enabled = True
         grpGrid.Visible = True
         grpLabelOptions.Enabled = False
         grpLabelOptions.Visible = False
         rdbtnOrFreeflow.Enabled = False
         rdbtnOrFreeflow.Visible = False
      End If

      _txtFieldName.Text = _omrField.Name

      Select Case _omrField.Options.OmrSensitivity
         Case Ocr.OcrOmrSensitivity.Highest
            rdbtnSensHighest.Checked = True
         Case Ocr.OcrOmrSensitivity.High
            rdbtnSensHigh.Checked = True
         Case Ocr.OcrOmrSensitivity.Low
            rdbtnSensLow.Checked = True
         Case Ocr.OcrOmrSensitivity.Lowest
            rdbtnSensLowest.Checked = True
         Case Else
      End Select

      Select Case _omrField.Options.FieldOrientation
         Case OmrFieldOrientation.RowWise
            rdbtnOrRows.Checked = True
         Case OmrFieldOrientation.ColumnWise
            rdbtnOrCols.Checked = True
         Case OmrFieldOrientation.FreeFlow
            rdbtnOrFreeflow.Checked = True
            rdbtnOrRows.Enabled = False
            rdbtnOrCols.Enabled = False
         Case Else
      End Select

      Select Case _omrField.Options.TextFormat
         Case OmrTextFormat.CSV
            rdbtnFormatCSV.Checked = True
         Case OmrTextFormat.Aggregated
            rdbtnFormatAggregated.Checked = True
         Case Else
      End Select

      _cbGrade.Checked = _omrField.Options.GradeThisField
      _numCorrect.Value = Convert.ToDecimal(_omrField.Options.CorrectGrade)
      _numIncorrect.Value = Convert.ToDecimal(_omrField.Options.IncorrectGrade)
      _numNoResponse.Value = Convert.ToDecimal(_omrField.Options.NoResponseGrade)
      _cbRightToLeft.Checked = _omrField.Options.ColumnsReportOrder = ColumnsReportOrder.RightToLeft
   End Sub

   Private Sub PopulateValues()
      lstValues.Items.Clear()

      For Each value As List(Of String) In _values

         If value.Count > 0 Then
            Dim text As String = ValuesString(value)
            lstValues.Items.Add(text)
         End If
      Next

      Dim fieldValues As List(Of String) = _omrField.GetValues()

      If fieldValues IsNot Nothing Then
         Dim x As Integer = fieldValues.ToArray.Count(Function(input As String)
                                                         Return input Is ""
                                                      End Function)

         If Not lstValues.Items.Contains(ValuesString(fieldValues)) AndAlso x = 0 AndAlso _values(0).Count = fieldValues.Count Then
            _values.Add(fieldValues)
            Dim index As Integer = lstValues.Items.Add(ValuesString(fieldValues) & CUSTOM)
            lstValues.SelectedIndex = index
         ElseIf x = 0 Then
            lstValues.SelectedItem = ValuesString(fieldValues)
         End If
      End If
   End Sub

   Private Function ValuesString(ByVal values As List(Of String)) As String
      Return values(0) & " To " & values(values.Count - 1)
   End Function

   Private Sub rdbtnOrientation_CheckChanged(ByVal sender As Object, ByVal e As EventArgs)
      If _omrField.FieldBubbleLayoutType = OmrFieldBubbleLayoutType.BubbleWithLabel Then
         Return
      End If

      If rdbtnOrRows.Checked Then
         _imageViewer.Image = Nothing
         _values = GenerateOmrFieldValues.Generate(_omrField.RowsCount, _omrField.ColumnsCount, OmrFieldOrientation.RowWise)
         PopulateValues()
         lstValues.SelectedIndex = If(_indexRows < lstValues.Items.Count, _indexRows, 0)
      ElseIf rdbtnOrCols.Checked Then
         _imageViewer.Image = Nothing
         _values = GenerateOmrFieldValues.Generate(_omrField.RowsCount, _omrField.ColumnsCount, OmrFieldOrientation.ColumnWise)
         PopulateValues()
         lstValues.SelectedIndex = If(_indexCols < lstValues.Items.Count, _indexCols, 0)
      End If
   End Sub

   Private Sub lstValues_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
      If rdbtnOrRows.Checked Then
         _indexRows = lstValues.SelectedIndex
      End If

      If rdbtnOrCols.Checked Then
         _indexCols = lstValues.SelectedIndex
      End If
   End Sub

   Private Sub cboxValues_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs)
      Dim label As OmrBubbleLabel = CType(cboxValues.SelectedItem, OmrBubbleLabel)
      txtValue.Text = label.Value
      If (Not label.Bounds.IsEmpty) Then
         _imageViewer.Image = _fieldImage.Clone(label.Bounds)
      End If
   End Sub

   Private Sub txtValue_Leave(ByVal sender As Object, ByVal e As EventArgs)
      Dim label As OmrBubbleLabel = CType(cboxValues.SelectedItem, OmrBubbleLabel)
      label.Value = txtValue.Text
   End Sub

   Private Sub btnOK_Click(ByVal sender As Object, ByVal e As EventArgs)
   End Sub

   Private Sub _cbGrade_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs)
      _numCorrect.Enabled = _cbGrade.Checked
      _numIncorrect.Enabled = _cbGrade.Checked
      _numNoResponse.Enabled = _cbGrade.Checked
   End Sub

   Private Function ControlsToData() As Boolean
      _omrField.Name = _txtFieldName.Text
      Dim options As OmrFieldOptions = _omrField.Options

      If rdbtnOrRows.Checked Then
         options.FieldOrientation = OmrFieldOrientation.RowWise
      ElseIf rdbtnOrCols.Checked Then
         options.FieldOrientation = OmrFieldOrientation.ColumnWise
      ElseIf rdbtnOrFreeflow.Checked Then
         options.FieldOrientation = OmrFieldOrientation.FreeFlow
      End If

      options.GradeThisField = _cbGrade.Checked
      options.CorrectGrade = Convert.ToDouble(_numCorrect.Value)
      options.IncorrectGrade = Convert.ToDouble(_numIncorrect.Value)
      options.NoResponseGrade = Convert.ToDouble(_numNoResponse.Value)
      options.TextFormat = If(rdbtnFormatCSV.Checked, OmrTextFormat.CSV, OmrTextFormat.Aggregated)
      options.ColumnsReportOrder = If(_cbRightToLeft.Checked, ColumnsReportOrder.RightToLeft, ColumnsReportOrder.LeftToRight)

      If rdbtnSensLowest.Checked Then
         options.OmrSensitivity = Ocr.OcrOmrSensitivity.Lowest
      ElseIf rdbtnSensLow.Checked Then
         options.OmrSensitivity = Ocr.OcrOmrSensitivity.Low
      ElseIf rdbtnSensHigh.Checked Then
         options.OmrSensitivity = Ocr.OcrOmrSensitivity.High
      ElseIf rdbtnSensHighest.Checked Then
         options.OmrSensitivity = Ocr.OcrOmrSensitivity.Highest
      End If

      Try
         _omrField.Options = options
      Catch __unusedException1__ As Exception
         MessageBox.Show("The options for this field are invalid.")
         Return False
      End Try

      If _omrField.Options.FieldOrientation = OmrFieldOrientation.FreeFlow Then

         For i As Integer = 0 To _omrField.Fields.Count - 1
            Dim name As String = _omrField.Fields(i).Name
            _omrField.Fields(i).Name = If(String.IsNullOrEmpty(name), String.Format("Freeflow {0}", i + 1), name)
         Next
      End If

      If _omrField.FieldBubbleLayoutType = OmrFieldBubbleLayoutType.BubbleWithLabel Then

         Try
            _omrField.SetValues(_labels.ConvertAll(Of String)(Function(bub As OmrBubbleLabel) bub.Value))
         Catch ex As Exception
            MessageBox.Show("The field count does not match the label count.")
            Return False
         End Try
      Else
         _omrField.SetValues(_values(lstValues.SelectedIndex))
      End If

      Return True
   End Function

   Private Sub rdbtnFormatValue_CheckChanged(ByVal sender As Object, ByVal e As EventArgs)
      If rdbtnFormatAggregated.Checked Then
         lblFormatExample.Text = "ABCD"
      ElseIf rdbtnFormatCSV.Checked Then
         lblFormatExample.Text = "A, B, C, D"
      End If
   End Sub

   Private Sub btnCreateCustom_Click(ByVal sender As Object, ByVal e As EventArgs)
      Dim range As Integer = _values(0).Count
      MessageBox.Show(String.Format("To create a custom range, enter {0} values separated by commas.", range))
      Dim isValid As Func(Of String, String) = New Func(Of String, String)(Function(input As String)
                                                                              Dim values As String() = input.Split(New Char() {","c})

                                                                              If values.Length <> range Then
                                                                                 Return "Exactly " & range.ToString() & " values must be specified."
                                                                              End If

                                                                              Dim filteredValues As List(Of String) = New List(Of String)(values.Distinct())

                                                                              If filteredValues.Count <> range Then
                                                                                 Return "Values must be unique."
                                                                              End If

                                                                              If filteredValues.Any(Function(str As String) String.IsNullOrWhiteSpace(str)) Then
                                                                                 Return "Blank values cannot be used"
                                                                              End If

                                                                              Return String.Empty
                                                                           End Function)
      Dim tid As TextInputDialog = New TextInputDialog(isValid)

      If tid.ShowDialog(Me) = DialogResult.OK Then
         Dim text As String = tid.Value
         Dim newSource As List(Of String) = New List(Of String)(text.Split(New Char() {","c}))
         _values.Add(newSource)
         lstValues.Items.Add(ValuesString(newSource) & CUSTOM)

         If rdbtnOrCols.Checked Then
            _indexCols = lstValues.Items.Count - 1
         ElseIf rdbtnOrRows.Checked Then
            _indexRows = lstValues.Items.Count - 1
         End If

         lstValues.SelectedIndex = lstValues.Items.Count - 1
      End If
   End Sub

   Private Sub lstValues_DoubleClick(ByVal sender As Object, ByVal e As EventArgs)
      Dim index As Integer = lstValues.SelectedIndex
      Dim values As List(Of String) = _values(index)
      Dim text As String = ""

      For i As Integer = 0 To values.Count - 1
         text += values(i)

         If i < values.Count - 1 Then
            text += ", "
         End If
      Next

      MessageBox.Show(text)
   End Sub

   Private Sub OmrFieldDialog_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs)
      If Me.DialogResult = DialogResult.OK Then
         e.Cancel = Not ControlsToData()
      End If
   End Sub
End Class
