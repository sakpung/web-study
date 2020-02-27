' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Microsoft.VisualBasic

Imports Leadtools.Demos
Imports Leadtools.Demos.Dialogs
Imports System.IO
Imports Leadtools.Document.Writer
Imports Leadtools
Imports System.Threading
Imports System

Partial Public Class LTDMergeDialog
   Inherits Form
   Private _docWriter As DocumentWriter
   Private _abort As Boolean

   Public Sub New()
      InitializeComponent()

      ' Setup the caption for this demo
      Messager.Caption = "VB LTD Merge Demo"
      _abort = False
   End Sub

   Protected Overrides Sub OnLoad(e As EventArgs)
      If Not DesignMode Then
         BeginInvoke(New MethodInvoker(AddressOf Startup))
      End If

      MyBase.OnLoad(e)
   End Sub

   Protected Overrides Sub OnFormClosed(e As FormClosedEventArgs)
      If Not DesignMode Then
         RemoveHandler _documentFormatOptionsControl.SelectedFormatChanged, AddressOf _documentFormatOptionsControl_SelectedFormatChanged
         RemoveHandler _docWriter.Progress, AddressOf DocumentWriterInstance_Progress

         ' Save the last setting
         Dim settings As New LTDMergeDemo.Settings()

         If _docWriter IsNot Nothing Then
            Using ms As New MemoryStream()
               _docWriter.SaveOptions(ms)
               settings.FormatOptionsXml = Encoding.Unicode.GetString(ms.ToArray())
            End Using
         End If

         settings.ViewFinalDocument = _viewDocumentCheckBox.Checked
         settings.OutputFileName = _outputFileNameTextBox.Text
         settings.LTDDocumentTypeIndex = _ltdDocumentTypeComboBox.SelectedIndex
         settings.Save()
      End If

      MyBase.OnFormClosed(e)
   End Sub

   Private Sub Startup()
      Dim settings As New LTDMergeDemo.Settings()

      _docWriter = New DocumentWriter()

      Dim docOptions As DocDocumentOptions = TryCast(_docWriter.GetOptions(DocumentFormat.Doc), DocDocumentOptions)
      docOptions.TextMode = DocumentTextMode.Framed

      Dim docxOptions As DocxDocumentOptions = TryCast(_docWriter.GetOptions(DocumentFormat.Docx), DocxDocumentOptions)
      docxOptions.TextMode = DocumentTextMode.Framed

      Dim rtfOptions As RtfDocumentOptions = TryCast(_docWriter.GetOptions(DocumentFormat.Rtf), RtfDocumentOptions)
      rtfOptions.TextMode = DocumentTextMode.Framed

      Dim altoXmlOptions As AltoXmlDocumentOptions = TryCast(_docWriter.GetOptions(DocumentFormat.AltoXml), AltoXmlDocumentOptions)
      altoXmlOptions.Formatted = True

      AddHandler _documentFormatOptionsControl.SelectedFormatChanged, AddressOf _documentFormatOptionsControl_SelectedFormatChanged

      _documentFormatOptionsControl.SetDocumentWriter(_docWriter)

      AddHandler _docWriter.Progress, AddressOf DocumentWriterInstance_Progress

      _viewDocumentCheckBox.Checked = settings.ViewFinalDocument
      _outputFileNameTextBox.Text = settings.OutputFileName
      _ltdDocumentTypeComboBox.SelectedIndex = settings.LTDDocumentTypeIndex

      UpdateUIState(False)
   End Sub

   Private Sub _documentFormatOptionsControl_SelectedFormatChanged(sender As Object, e As EventArgs)
      ' Change the Document Image file extension when the document format is changed.
      Dim format As DocumentFormat = _documentFormatOptionsControl.SelectedDocumentFormat
      Dim extension As String = DocumentWriter.GetFormatFileExtension(format)
      _outputFileNameTextBox.Text = Path.ChangeExtension(_outputFileNameTextBox.Text, extension)
      _viewDocumentCheckBox.Enabled = format <> DocumentFormat.Ltd
   End Sub

   Private Sub _exitButton_Click(sender As Object, e As EventArgs) Handles _exitButton.Click
      _documentFormatOptionsControl.UpdateDocumentWriterOptions()
      Close()
   End Sub

   Private Sub _aboutButton_Click(sender As Object, e As EventArgs) Handles _aboutButton.Click
      Using aboutDialog As New AboutDialog("LTD Merge", ProgrammingInterface.VB)
         aboutDialog.ShowDialog(Me)
      End Using
   End Sub

   Private Sub UpdateUIState(inProgress As Boolean)
      If _mainWizardControl.SelectedTab Is _sourceLTDFilesTabPage Then
         SourceLTDFilesUpdateUIState()
      ElseIf _mainWizardControl.SelectedTab Is _outputOptionsTabPage Then
         OutputOptionsUpdateUIState(inProgress)
      End If
   End Sub

   Private Sub SourceLTDFilesUpdateUIState()
      _sourceLTDFilesRemoveButton.Enabled = _sourceLTDFileListView.Items.Count > 0
      _sourceLTDFilesClearButton.Enabled = _sourceLTDFileListView.Items.Count > 0

      _moveTopButton.Enabled = _sourceLTDFileListView.SelectedItems.Count > 0
      _moveUpButton.Enabled = _sourceLTDFileListView.SelectedItems.Count > 0
      _moveDownButton.Enabled = _sourceLTDFileListView.SelectedItems.Count > 0
      _moveBottomButton.Enabled = _sourceLTDFileListView.SelectedItems.Count > 0

      _previousButton.Enabled = False
      _nextButton.Enabled = _sourceLTDFileListView.Items.Count > 0
      _nextButton.Text = "&Next"
   End Sub

   Private Sub OutputOptionsUpdateUIState(inProgress As Boolean)
      _previousButton.Enabled = True
      _nextButton.Enabled = _outputFileNameTextBox.Text.Length > 0
      If inProgress Then
         _nextButton.Text = "&Abort"
      Else
         _nextButton.Text = "&Finish"
      End If
   End Sub

   Private Sub _previousButton_Click(sender As Object, e As EventArgs) Handles _previousButton.Click
      If _mainWizardControl.SelectedTab Is _outputOptionsTabPage Then
         OutputOptionsPreviousPage()
      End If

      UpdateUIState(False)
   End Sub

   Private Sub _nextButton_Click(sender As Object, e As EventArgs) Handles _nextButton.Click
      If _mainWizardControl.SelectedTab Is _sourceLTDFilesTabPage Then
         SourceLTDFilesNextPage()
         UpdateUIState(False)
      ElseIf _mainWizardControl.SelectedTab Is _outputOptionsTabPage Then
         _abort = False
         If _nextButton.Text.Equals("&Abort") Then
            _abort = True
         End If

         If Not _abort Then
            _nextButton.Text = "&Abort"
            Application.DoEvents()

            _documentFormatOptionsControl.UpdateDocumentWriterOptions()
            Dim format As DocumentFormat = _documentFormatOptionsControl.SelectedDocumentFormat
            Dim outputFileName As String = _outputFileNameTextBox.Text
            Dim viewFinalDocument As Boolean = _viewDocumentCheckBox.Checked
            Dim sourceLTDFiles As New List(Of String)()

            Dim globalLTDType As LtdDocumentType = CType(_ltdDocumentTypeComboBox.SelectedIndex, LtdDocumentType)
            Dim totalPagesCount As Integer = 0
            For Each item As ListViewItem In _sourceLTDFileListView.Items
               Dim ltdFileInfo As LtdDocumentInfo = DocumentWriter.GetLtdInfo(item.Text)
               If ltdFileInfo.Type = globalLTDType Then
                  sourceLTDFiles.Add(item.Text)
                  totalPagesCount += ltdFileInfo.PageCount
               End If
            Next

            ' The document writer provides progress for two extra operations (BeginDocument and EndDocument) and hence the number 2 
            _progressBar.Maximum = totalPagesCount + 2

            ThreadPool.QueueUserWorkItem(
               Sub(sender1 As Object)
                  MergeLTDFiles(format, outputFileName, sourceLTDFiles.ToArray(), viewFinalDocument, globalLTDType)
               End Sub)

            UpdateUIState(True)
         End If
      End If
   End Sub

   Private Sub SourceLTDFilesNextPage()
      ' Check if any of the added LTD files in the list matches the globally selected 
      ' LTD document type from the combo box, if non, then stay on this page.
      Dim globalLTDType As LtdDocumentType = CType(_ltdDocumentTypeComboBox.SelectedIndex, LtdDocumentType)
      Dim validLTDFilesFound As Boolean = False
      For Each item As ListViewItem In _sourceLTDFileListView.Items
         Dim ltdFileInfo As LtdDocumentInfo = DocumentWriter.GetLtdInfo(item.Text)
         If ltdFileInfo.Type = globalLTDType Then
            validLTDFilesFound = True
            Exit For
         End If
      Next

      If validLTDFilesFound Then
         _mainWizardControl.SelectedTab = _outputOptionsTabPage
      Else
         Messager.ShowInformation(Me, "Non of the source LTD files you added matches the chosen global LTD document type." & vbLf & "You can either change the global LTD document type to match the type of your LTD files or add some LTD files that matches the global LTD document type to be able to move to the next page.")
      End If
   End Sub

   Private Sub OutputOptionsPreviousPage()
      _documentFormatOptionsControl.UpdateDocumentWriterOptions()

      _mainWizardControl.SelectedTab = _sourceLTDFilesTabPage
   End Sub

   Private Sub _sourceLTDFilesAddButton_Click(sender As Object, e As EventArgs) Handles _sourceLTDFilesAddButton.Click
      Dim ltdFiles As String() = ShowLTDOpenFilesDialog()
      If ltdFiles IsNot Nothing Then
         For Each ltdFile As String In ltdFiles
            If IsLTDFile(ltdFile) Then
               Dim ltdFileInfo As LtdDocumentInfo = DocumentWriter.GetLtdInfo(ltdFile)
               _sourceLTDFileListView.Items.Add(ltdFile).SubItems.Add(ltdFileInfo.Type.ToString())
            End If
         Next
      End If

      ' set the focus to the source LTD files list view
      _sourceLTDFileListView.[Select]()
      If _sourceLTDFileListView.Items.Count - 1 >= 0 Then
         _sourceLTDFileListView.EnsureVisible(_sourceLTDFileListView.Items.Count - 1)
      End If

      UpdateUIState(False)
   End Sub

   Private Sub _sourceLTDFilesRemoveButton_Click(sender As Object, e As EventArgs) Handles _sourceLTDFilesRemoveButton.Click
      SourceLTDFiles_RemoveSelectedItems()
   End Sub

   Private Sub _sourceLTDFilesClearButton_Click(sender As Object, e As EventArgs) Handles _sourceLTDFilesClearButton.Click
      _sourceLTDFileListView.Items.Clear()
      UpdateUIState(False)
   End Sub

   Private Sub _sourceLTDFileListView_KeyDown(sender As Object, e As KeyEventArgs) Handles _sourceLTDFileListView.KeyDown
      Dim lv As ListView = CType(sender, ListView)
      If e.KeyCode = Keys.Delete AndAlso lv.SelectedItems.Count > 0 Then
         ' delete currently selected item(s)
         SourceLTDFiles_RemoveSelectedItems()
      ElseIf e.Control AndAlso e.KeyCode = Keys.A Then
         ' select all items in the list
         For Each item As ListViewItem In _sourceLTDFileListView.Items
            item.Selected = True
         Next
      End If
   End Sub

   Private Function ShowLTDOpenFilesDialog() As String()
      Dim settings As New LTDMergeDemo.Settings()

      Using dlg As New OpenFileDialog()
         dlg.Filter = "LTD Files|*.ltd"
         dlg.Multiselect = True
         dlg.InitialDirectory = settings.SourceLTDFolder
         dlg.CheckFileExists = True
         dlg.Title = "Select LTD file(s)"

         If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            settings.SourceLTDFolder = Path.GetDirectoryName(dlg.FileName)
            settings.Save()

            Return dlg.FileNames
         End If
      End Using

      Return Nothing
   End Function

   Private Sub SourceLTDFiles_RemoveSelectedItems()
      ' set the focus to the source LTD files list view
      _sourceLTDFileListView.[Select]()

      Dim itemIndexToSelect As Integer = _sourceLTDFileListView.SelectedIndices(0)
      For Each item As ListViewItem In _sourceLTDFileListView.SelectedItems
         _sourceLTDFileListView.Items.Remove(item)
      Next

      ' set default selected item after deleting selected ones
      itemIndexToSelect = Math.Min(itemIndexToSelect, Math.Max(0, _sourceLTDFileListView.Items.Count - 1))
      If _sourceLTDFileListView.Items.Count > 0 Then
         _sourceLTDFileListView.Items(itemIndexToSelect).Selected = True
      End If

      UpdateUIState(False)
   End Sub

   Private Sub _sourceLTDFileListView_ItemDrag(sender As Object, e As ItemDragEventArgs) Handles _sourceLTDFileListView.ItemDrag
      _sourceLTDFileListView.DoDragDrop(e.Item, DragDropEffects.Move)
   End Sub

   Private Sub _sourceLTDFileListView_DragOver(sender As Object, e As DragEventArgs) Handles _sourceLTDFileListView.DragOver
      Dim targetPoint As Point = _sourceLTDFileListView.PointToClient(New Point(e.X, e.Y))
      Dim targetIndex As Integer = _sourceLTDFileListView.InsertionMark.NearestIndex(targetPoint)
      If targetIndex > -1 Then
         ' if the cursor location is near the top of the hit test item then show the insertion mark before the item otherwise show it after the item
         Dim hitTestItemYCenter As Integer = CInt(_sourceLTDFileListView.Items(targetIndex).Bounds.Y + (_sourceLTDFileListView.Items(targetIndex).Bounds.Height / 2))
         If targetPoint.Y < hitTestItemYCenter Then
            _sourceLTDFileListView.InsertionMark.AppearsAfterItem = False
         Else
            _sourceLTDFileListView.InsertionMark.AppearsAfterItem = True
         End If
      End If

      ' Set the location of the insertion mark. If the mouse is over the dragged item, the targetIndex value is -1 and the insertion mark disappears.
      _sourceLTDFileListView.InsertionMark.Index = targetIndex
   End Sub

   Private Sub _sourceLTDFileListView_DragEnter(sender As Object, e As DragEventArgs) Handles _sourceLTDFileListView.DragEnter
      ' Check if the Dataformat of the data can be accepted (we only accept file drops from Explorer, etc.)
      If e.Data.GetDataPresent(DataFormats.FileDrop) Then
         ' check if any of the drop files is LTD file then allow this action otherwise don't (this will show the not allowed operation cursor).
         Dim filesList As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())
         Dim ok As Boolean = False
         For Each file As String In filesList
            If IsLTDFile(file) Then
               ok = True
               Exit For
            End If
         Next

         If ok Then
            e.Effect = DragDropEffects.Copy
         Else
            ' Okay
            e.Effect = DragDropEffects.None
            ' Not Okay
         End If
      Else
         e.Effect = e.AllowedEffect
      End If
      ' Unknown data, ignore it
   End Sub

   Private Sub _sourceLTDFileListView_DragDrop(sender As Object, e As DragEventArgs) Handles _sourceLTDFileListView.DragDrop
      If e.Data.GetDataPresent(DataFormats.FileDrop) Then
         ' remove selection marks from all items in the list in order to select the newly added ones
         _sourceLTDFileListView.SelectedItems.Clear()

         Dim insertionIndex As Integer = If((_sourceLTDFileListView.InsertionMark.Index <> -1), (If((_sourceLTDFileListView.InsertionMark.AppearsAfterItem), _sourceLTDFileListView.InsertionMark.Index + 1, _sourceLTDFileListView.InsertionMark.Index)), _sourceLTDFileListView.Items.Count)

         Dim filesList As String() = CType(e.Data.GetData(DataFormats.FileDrop, False), String())

         ' Filter the dropped files list and only add the supported files types
         For Each file As String In filesList
            If IsLTDFile(file) Then
               Dim ltdFileInfo As LtdDocumentInfo = DocumentWriter.GetLtdInfo(file)
               Dim insertedItem As ListViewItem = _sourceLTDFileListView.Items.Insert(insertionIndex, file)
               insertedItem.SubItems.Add(ltdFileInfo.Type.ToString())
               insertedItem.Selected = True
               insertionIndex += 1
            End If
         Next

         _sourceLTDFileListView.[Select]()
         _sourceLTDFileListView.EnsureVisible(insertionIndex - 1)
         UpdateUIState(False)
      Else
         If _sourceLTDFileListView.InsertionMark.Index <> -1 Then
            Dim insertionIndex As Integer = If((_sourceLTDFileListView.InsertionMark.Index < _sourceLTDFileListView.SelectedIndices(0)), _sourceLTDFileListView.InsertionMark.Index, _sourceLTDFileListView.InsertionMark.Index - _sourceLTDFileListView.SelectedItems.Count + 1)
            SwapItems(insertionIndex)
            _sourceLTDFileListView.InsertionMark.Index = -1
         End If
      End If
   End Sub

   Private Function IsLTDFile(fileName As String) As Boolean
      Dim trimChars As Char() = New Char() {"."c}
      Dim fileExt As String = Path.GetExtension(fileName).TrimStart(trimChars)
      Return fileExt.ToLower().Equals("ltd")
   End Function

   Private Sub SwapItems(insertionIndex As Integer)
      If _sourceLTDFileListView.SelectedItems.Count <= 0 Then
         Return
      End If

      ' set the focus to the source LTD files list view
      _sourceLTDFileListView.[Select]()

      Dim selectedIndices As Integer() = New Integer(_sourceLTDFileListView.SelectedItems.Count - 1) {}
      _sourceLTDFileListView.SelectedIndices.CopyTo(selectedIndices, 0)

      Dim selectedItems As ListViewItem() = New ListViewItem(_sourceLTDFileListView.SelectedItems.Count - 1) {}
      _sourceLTDFileListView.SelectedItems.CopyTo(selectedItems, 0)

      ' Delete the selected items after we took a copy of them in order to insert the new ones at the new index
      For i As Integer = selectedItems.Length - 1 To 0 Step -1
         _sourceLTDFileListView.Items.RemoveAt(selectedIndices(i))
      Next

      Dim newIndex As Integer = Math.Max(0, Math.Min(insertionIndex, _sourceLTDFileListView.Items.Count))
      For i As Integer = 0 To selectedItems.Length - 1
         _sourceLTDFileListView.Items.Insert(newIndex, selectedItems(i))
         _sourceLTDFileListView.Items(newIndex).Selected = True
         newIndex += 1
      Next
   End Sub

   Private Sub _moveTopButton_Click(sender As Object, e As EventArgs) Handles _moveTopButton.Click
      SwapItems(0)
   End Sub

   Private Sub _moveUpButton_Click(sender As Object, e As EventArgs) Handles _moveUpButton.Click
      Dim insertionIndex As Integer = _sourceLTDFileListView.SelectedIndices(0) - 1
      SwapItems(insertionIndex)
   End Sub

   Private Sub _moveDownButton_Click(sender As Object, e As EventArgs) Handles _moveDownButton.Click
      Dim insertionIndex As Integer = _sourceLTDFileListView.SelectedIndices(0) + 1
      SwapItems(insertionIndex)
   End Sub

   Private Sub _moveBottomButton_Click(sender As Object, e As EventArgs) Handles _moveBottomButton.Click
      Dim insertionIndex As Integer = _sourceLTDFileListView.Items.Count - 1 - _sourceLTDFileListView.SelectedItems.Count + 1
      SwapItems(insertionIndex)
   End Sub

   Private Sub _sourceLTDFileListView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles _sourceLTDFileListView.SelectedIndexChanged
      UpdateUIState(False)
   End Sub

   Private Sub _outputFileNameTextBox_TextChanged(sender As Object, e As EventArgs) Handles _outputFileNameTextBox.TextChanged
      UpdateUIState(False)
   End Sub

   Private Sub _outputFileNameBrowseButton_Click(sender As Object, e As EventArgs) Handles _outputFileNameBrowseButton.Click
      Dim settings As New LTDMergeDemo.Settings()

      ' Show the save file dialog
      Using dlg As New SaveFileDialog()
         ' Get the selected format name and extension
         Dim format As DocumentFormat = _documentFormatOptionsControl.SelectedDocumentFormat

         Dim extension As String = DocumentWriter.GetFormatFileExtension(format)

         dlg.Filter = String.Format("{0} (*.{1})|*.{1}|All Files (*.*)|*.*", _documentFormatOptionsControl.SelectedDocumentFormatFriendlyName, extension)
         dlg.InitialDirectory = settings.SaveDialogLastPath
         dlg.DefaultExt = extension

         If dlg.ShowDialog(Me) = DialogResult.OK Then
            _outputFileNameTextBox.Text = dlg.FileName

            settings.SaveDialogLastPath = Path.GetDirectoryName(dlg.FileName)
            settings.Save()
         End If
      End Using
   End Sub

   Private Sub MergeLTDFiles(format As DocumentFormat, outputFileName As String, sourceLTDFiles As String(), viewFinalDocument As Boolean, globalLTDType As LtdDocumentType)
      ' If the output format is LTD then use the same target LTD file path specified by the user, otherwise create a temp file
      Dim mergedLTDFileName As String = Nothing
      If format <> DocumentFormat.Ltd Then
         mergedLTDFileName = Guid.NewGuid().ToString().Replace("-", Nothing) + "." + "ltd"
         mergedLTDFileName = Path.Combine(Path.GetTempPath(), mergedLTDFileName)
      Else
         mergedLTDFileName = outputFileName
         If File.Exists(outputFileName) Then
            File.Delete(outputFileName)
         End If
      End If

      Dim errorOccurred As Boolean = False
      Try
         If sourceLTDFiles.Length > 0 Then
            For Each fileName As String In sourceLTDFiles
               If _abort Then
                  Exit For
               End If

               _docWriter.AppendLtd(fileName, mergedLTDFileName)
            Next

            If format <> DocumentFormat.Ltd Then
               _docWriter.Convert(mergedLTDFileName, outputFileName, format)
            End If
         Else
            errorOccurred = True
            OnError("Non of the source LTD files you added matches the chosen global LTD document type from the previous page.")
         End If
      Catch ex As Exception
         errorOccurred = True
         OnError(ex.Message)
      Finally
         OnDone(format, mergedLTDFileName, outputFileName, viewFinalDocument, errorOccurred)
      End Try
   End Sub

   Private Sub OnError(message As String)
      Me.BeginInvoke(New MethodInvoker(Sub() Messager.ShowError(Me, message)))

      Application.DoEvents()
   End Sub

   Private Sub OnDone(format As DocumentFormat, tempMergedLTDFileName As String, outputFileName As String, viewFinalDocument As Boolean, errorOccurred As Boolean)
      Me.BeginInvoke(New MethodInvoker(Sub()
                                          _nextButton.Text = "&Finish"
                                          _progressBar.Value = 0

                                          ' Delete the temp LTD file
                                          If format <> DocumentFormat.Ltd AndAlso Not String.IsNullOrEmpty(tempMergedLTDFileName) AndAlso File.Exists(tempMergedLTDFileName) Then
                                             File.Delete(tempMergedLTDFileName)
                                          End If

                                          If Not _abort AndAlso Not errorOccurred Then
                                             If viewFinalDocument AndAlso format <> DocumentFormat.Ltd Then
                                                ' Put some delay before loading the saved file since Windows 7 is a little slow in creating the documents specially the EMF format.
                                                System.Threading.Thread.Sleep(1000)
                                                System.Diagnostics.Process.Start(outputFileName)
                                             Else
                                                Messager.ShowInformation(Me, "Operation completed.")
                                             End If
                                          End If

                                       End Sub))

      Application.DoEvents()
   End Sub

   Private Delegate Sub DoUpdateStatusDelegate(percentage As Integer)
   Private Sub DocumentWriterInstance_Progress(sender As Object, e As DocumentProgressEventArgs)
      If _abort Then
         e.Cancel = True
         Return
      End If

      If InvokeRequired AndAlso IsHandleCreated Then
         BeginInvoke(New DoUpdateStatusDelegate(AddressOf DoUpdateStatus), New Object() {e.Percentage})
      Else
         DoUpdateStatus(e.Percentage)
      End If
   End Sub

   Private Sub DoUpdateStatus(percentage As Integer)
      If percentage = 100 Then
         _progressBar.PerformStep()
      End If
   End Sub
End Class
