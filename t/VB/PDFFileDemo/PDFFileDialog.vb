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

Imports Leadtools
Imports Leadtools.Pdf
Imports Leadtools.Demos.Dialogs

Namespace PDFFileDemo
   Partial Public Class PDFFileDialog : Inherits Form
      Private _sourceDocument As PDFFile
      Private _isSourcePostscript As Boolean
      Private _destinationDocument As PDFFile
      Private _destinationFileName As String
      Private _distillerOptions As PDFDistillerOptions
      Private _insertPageNumber As Integer
      Private _firstPageNumber As Integer
      Private _lastPageNumber As Integer

      Private Enum Operation
         UpdateProperties
         ConvertToPDFA
         Linearize
         Convert
         Merge
         DeletePages
         ExtractPages
         InsertPages
         Distill
         Optimizer
         InitialView
         DigitalSignature
      End Enum

      Private Structure OperationItem
         Public Operation As Operation
         Public Text As String
         Public ShowPages As Boolean
         Public CanUseAllPages As Boolean
         Public MutlipleSourceFiles As Boolean
         Public DestinationMustExist As Boolean
         Public ShowCompatibilityLevel As Boolean
         Public ShowSecurityOptions As Boolean
         Public ShowOptimizationOptions As Boolean
         Public ShowInitialViewOptions As Boolean
         Public ShowDigitalSignatureOptions As Boolean


         Public Sub New(operation_ As Operation, text_ As String, showPages_ As Boolean, canUseAllPages_ As Boolean, mutlipleSourceFiles_ As Boolean, destinationMustExist_ As Boolean,
          showCompatibilityLevel_ As Boolean, showSecurityOptions_ As Boolean, showOptimizationOptions_ As Boolean, showInitialViewOptions_ As Boolean, showDigitalSignatureOptions_ As Boolean)
            Operation = operation_
            Text = text_
            ShowPages = showPages_
            CanUseAllPages = canUseAllPages_
            MutlipleSourceFiles = mutlipleSourceFiles_
            DestinationMustExist = destinationMustExist_
            ShowCompatibilityLevel = showCompatibilityLevel_
            ShowSecurityOptions = showSecurityOptions_
            ShowOptimizationOptions = showOptimizationOptions_
            ShowInitialViewOptions = showInitialViewOptions_
            ShowDigitalSignatureOptions = showDigitalSignatureOptions_
         End Sub

         Public Overrides Function ToString() As String
            Return Text
         End Function
      End Structure

      Private ReadOnly _distillOperationItem As New OperationItem(Operation.Distill, Nothing, False, False, False, False, True, True, True, True, False)

      Public Sub New()
         InitializeComponent()
      End Sub

      Private Shared ReadOnly _updatePropertiesText As String = "Update the properties of a PDF file such as title, author, keywords, etc"
      Private Shared ReadOnly _convertToPDFAText As String = "Convert a PDF file to PDF/A"
      Private Shared ReadOnly _linearizeText As String = "Linearize a PDF file (optimize it for Web viewing)"
      Private Shared ReadOnly _convertText As String = "Convert or encrypt a PDF file to another versions"
      Private Shared ReadOnly _mergeText As String = "Merge a PDF file with one or more existing files"
      Private Shared ReadOnly _deletePagesText As String = "Delete one or more pages from an existing PDF file"
      Private Shared ReadOnly _extractPagesText As String = "Extract one or more pages from an existing PDF file"
      Private Shared ReadOnly _insertPagesText As String = "Insert pages from an existing PDF file into another"
      Private Shared ReadOnly _optimizerText As String = "Update PDF file optimizer options"
      Private Shared ReadOnly _initialViewText As String = "Update PDF file initial view options"
      Private Shared ReadOnly _digitalSignature As String = "Sign PDF File (Digital Signature)"

      Protected Overrides Sub OnLoad(ByVal e As EventArgs)
         If (Not DesignMode) Then
            Messager.Caption = "PDF File VB Demo"
            Text = Messager.Caption

            Me.Text = Messager.Caption


#If LEADTOOLS_V19_OR_LATER Then
#End If
            Dim items As OperationItem() = {New OperationItem(Operation.UpdateProperties, _updatePropertiesText, False, False, False, False,
             False, False, False, False, False), New OperationItem(Operation.ConvertToPDFA, _convertToPDFAText, False, False, False, False,
             False, False, False, False, False), New OperationItem(Operation.Linearize, _linearizeText, False, False, False, False,
             False, False, False, False, False), New OperationItem(Operation.Convert, _convertText, True, True, False, False,
             True, True, True, True, False), New OperationItem(Operation.Merge, _mergeText, False, False, True, False,
             True, True, True, True, False), New OperationItem(Operation.DeletePages, _deletePagesText, True, False, False, False,
             True, True, True, True, False),
             New OperationItem(Operation.ExtractPages, _extractPagesText, True, True, False, False,
             True, True, True, True, False), New OperationItem(Operation.InsertPages, _insertPagesText, True, True, False, True,
             True, True, True, True, False), New OperationItem(Operation.Optimizer, _optimizerText, False, False, False, False,
             False, False, True, False, False), New OperationItem(Operation.InitialView, _initialViewText, False, False, False, False,
             False, False, False, True, False), New OperationItem(Operation.DigitalSignature, _digitalSignature, False, False, False, False,
             False, False, False, False, True)}

            For Each item As OperationItem In items
               _operationComboBox.Items.Add(item)
            Next item

            _operationComboBox.SelectedIndex = 0

            _sourceDocumentPropertiesControl.SetDocumentProperties(Nothing, True)
            _sourceFileIsPostscriptLabel.Visible = False

            _distillOptionsOutputModeComboBox.Items.Add("Default - Useful across a wide variety of uses, at the expense of a larger output file")
            _distillOptionsOutputModeComboBox.Items.Add("Low-resolution similar to Acrobat Distiller 'Screen Optimized'")
            _distillOptionsOutputModeComboBox.Items.Add("Medium-resolution similar to the Acrobat Distiller 'eBook Optimized'")
            _distillOptionsOutputModeComboBox.Items.Add("High-resolution similar to the Acrobat Distiller 'Print Optimized'")
            _distillOptionsOutputModeComboBox.Items.Add("Highest-resolution similar to the Acrobat Distiller 'Prepress Optimized'")
            _distillOptionsOutputModeComboBox.SelectedIndex = 2

            _distillOptionsAutoRotatePageModeComboBox.Items.Add("No rotation")
            _distillOptionsAutoRotatePageModeComboBox.Items.Add("Rotation will be performed on a page by page bases")
            _distillOptionsAutoRotatePageModeComboBox.Items.Add("Rotation will be applied to all the pages in the final document")
            _distillOptionsAutoRotatePageModeComboBox.SelectedIndex = 1

            UpdateUIState()
         End If

         MyBase.OnLoad(e)
      End Sub

      Private Sub _exitButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _exitButton.Click
         Close()
      End Sub

      Private Sub _aboutButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _aboutButton.Click
         Using aboutDialog As New AboutDialog("PDF File", ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using
      End Sub

      Private Sub UpdateUIState()
         If _mainWizardControl.SelectedTab Is _sourceFileTabPage Then
            SourceFileUpdateUIState()
         ElseIf _mainWizardControl.SelectedTab Is _operationTabPage Then
            OperationUpdateUIState()
         ElseIf _mainWizardControl.SelectedTab Is _distillTabPage Then
            DistillUpdateUIState()
         ElseIf _mainWizardControl.SelectedTab Is _sourceFilesTabPage Then
            SourceFilesUpdateUIState()
         ElseIf _mainWizardControl.SelectedTab Is _destinationFileTabPage Then
            DestinationFileUpdateUIState()
         ElseIf _mainWizardControl.SelectedTab Is _optionsTabPage Then
            OptionsUpdateUIState()
         End If
      End Sub

      Private Sub _previousButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _previousButton.Click
         If _mainWizardControl.SelectedTab Is _operationTabPage Then
            OperationPreviousPage()
         End If
         If _mainWizardControl.SelectedTab Is _distillTabPage Then
            DistillPreviousPage()
         ElseIf _mainWizardControl.SelectedTab Is _sourceFilesTabPage Then
            SourceFilesPreviousPage()
         ElseIf _mainWizardControl.SelectedTab Is _destinationFileTabPage Then
            DestinationFilePreviousPage()
         ElseIf _mainWizardControl.SelectedTab Is _optionsTabPage Then
            OptionsPreviousPage()
         End If

         UpdateUIState()
      End Sub

      Private Sub _nextButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _nextButton.Click
         If _mainWizardControl.SelectedTab Is _sourceFileTabPage Then
            SourceFileNextPage()
         ElseIf _mainWizardControl.SelectedTab Is _operationTabPage Then
            OperationNextPage()
         ElseIf _mainWizardControl.SelectedTab Is _distillTabPage Then
            DistillNextPage()
         ElseIf _mainWizardControl.SelectedTab Is _sourceFilesTabPage Then
            SourceFilesNextPage()
         ElseIf _mainWizardControl.SelectedTab Is _destinationFileTabPage Then
            Dim operationItem As OperationItem = GetCurrentOperation()
            If operationItem.ShowDigitalSignatureOptions Then
               _destinationFileName = _destinationFileNameTextBox.Text
               OptionsNextPage()
               _filePasswordTextBox.Text = ""
            Else
               DestinationFileNextPage()
            End If
         ElseIf _mainWizardControl.SelectedTab Is _optionsTabPage Then
            OptionsNextPage()
         End If

         UpdateUIState()
      End Sub

#Region "Source File Page"
      Private Sub SourceFileUpdateUIState()
         _previousButton.Enabled = False
         _nextButton.Enabled = True
         _nextButton.Text = "&Next"
      End Sub

      Private Sub SourceFileNextPage()
         If String.IsNullOrEmpty(_sourceFileNameTextBox.Text) Then
            Messager.ShowWarning(Me, "You must select a source PDF file first")
            _sourceFileNameBrowseButton.Focus()
            Return
         End If

         If (Not _isSourcePostscript) Then
            _mainWizardControl.SelectedTab = _operationTabPage
         Else
            _mainWizardControl.SelectedTab = _distillTabPage
         End If
      End Sub

      Private Sub _sourceFileNameBrowseButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _sourceFileNameBrowseButton.Click
         Dim isPostscript As Boolean
         Dim document As PDFFile = BrowsePDFDocument(False, isPostscript)
         If Not document Is Nothing Then
            _sourceDocument = document
            _isSourcePostscript = isPostscript

            _sourceFileNameTextBox.Text = _sourceDocument.FileName

            If (Not _isSourcePostscript) Then
               _sourceFilePropertiesControl.Visible = True
               _sourceFilePropertiesControl.SetFileProperties(_sourceDocument)
               _sourceDocumentPropertiesControl.Visible = True
               _sourceDocumentPropertiesControl.SetDocumentProperties(_sourceDocument.DocumentProperties, True)

               _operationPageCountLabel.Text = String.Format("Document has {0} pages.", _sourceDocument.Pages.Count)
               _operationAllPagesCheckBox.Checked = True
               _operationFirstPageNumberTextBox.Text = "1"
               _operationLastPageNumberTextBox.Text = _sourceDocument.Pages.Count.ToString()
               _sourceFileIsPostscriptLabel.Visible = False
            Else
               _sourceFilePropertiesControl.Visible = False
               _sourceDocumentPropertiesControl.Visible = False
               _sourceFileIsPostscriptLabel.Visible = True
            End If

            UpdateUIState()
         End If
      End Sub
#End Region ' Source File Page

#Region "Operation Page"
      Private Function GetCurrentOperation() As OperationItem
         If (Not _isSourcePostscript) Then
            Return CType(_operationComboBox.SelectedItem, OperationItem)
         Else
            Return _distillOperationItem
         End If
      End Function

      Private Sub OperationUpdateUIState()
         _previousButton.Enabled = True
         _nextButton.Enabled = True
         _nextButton.Text = "&Next"

         Dim operationItem As OperationItem = GetCurrentOperation()
         _operationSourcePages.Visible = operationItem.ShowPages
         _operationAllPagesCheckBox.Visible = operationItem.CanUseAllPages
         If (Not _operationAllPagesCheckBox.Visible) Then
            _operationAllPagesCheckBox.Checked = False
         End If

         _operationFirstPageNumberTextBox.Enabled = Not _operationAllPagesCheckBox.Checked
         _operationLastPageNumberTextBox.Enabled = Not _operationAllPagesCheckBox.Checked
      End Sub

      Private Sub OperationPreviousPage()
         _mainWizardControl.SelectedTab = _sourceFileTabPage
      End Sub

      Private Sub OperationNextPage()
         Dim allOk As Boolean = True

         If _operationSourcePages.Visible AndAlso ((Not _operationAllPagesCheckBox.Visible) OrElse (Not _operationAllPagesCheckBox.Checked)) Then
            ' Check if the pages are OK
            Dim firstPageNumber As Integer = 1
            Dim lastPageNumber As Integer = _sourceDocument.Pages.Count

            If allOk AndAlso (Not Integer.TryParse(_operationFirstPageNumberTextBox.Text, firstPageNumber)) Then
               Messager.ShowWarning(Me, "Enter a valid page number")
               _operationFirstPageNumberTextBox.Focus()
               _operationFirstPageNumberTextBox.SelectAll()
               allOk = False
            End If

            If allOk AndAlso (Not Integer.TryParse(_operationLastPageNumberTextBox.Text, lastPageNumber)) Then
               Messager.ShowWarning(Me, "Enter a valid page number")
               _operationLastPageNumberTextBox.Focus()
               _operationLastPageNumberTextBox.SelectAll()
               allOk = False
            End If

            If allOk AndAlso (firstPageNumber < 1 OrElse firstPageNumber > lastPageNumber OrElse firstPageNumber > _sourceDocument.Pages.Count) Then
               Messager.ShowWarning(Me, "First page number must be a value between 1 and " & _sourceDocument.Pages.Count.ToString())
               _operationFirstPageNumberTextBox.Focus()
               _operationFirstPageNumberTextBox.SelectAll()
               allOk = False
            End If

            If allOk AndAlso (lastPageNumber < 1 OrElse firstPageNumber > lastPageNumber OrElse lastPageNumber > _sourceDocument.Pages.Count) Then
               Messager.ShowWarning(Me, "Last page number must be a value greater than first page number and less than " & _sourceDocument.Pages.Count.ToString())
               _operationLastPageNumberTextBox.Focus()
               _operationLastPageNumberTextBox.SelectAll()
               allOk = False
            End If

            If (Not _operationAllPagesCheckBox.Visible) Then
               If _sourceDocument.Pages.Count > 1 AndAlso firstPageNumber = 1 AndAlso (lastPageNumber = -1 OrElse lastPageNumber = _sourceDocument.Pages.Count) Then
                  Messager.ShowWarning(Me, "Cannot delete all the pages from a document")
                  _operationLastPageNumberTextBox.Focus()
                  _operationLastPageNumberTextBox.SelectAll()
                  allOk = False
               End If
            End If

            _firstPageNumber = firstPageNumber
            _lastPageNumber = lastPageNumber
         Else
            _firstPageNumber = 1
            _lastPageNumber = -1
         End If

         Dim operationItem As OperationItem = GetCurrentOperation()
         If operationItem.Operation = Operation.DeletePages AndAlso _sourceDocument.Pages.Count = 1 Then
            Messager.ShowWarning(Me, "This document contain a single page. 'Delete Pages' operation is not supported")
            allOk = False
         End If

         If allOk Then
            If operationItem.MutlipleSourceFiles Then
               _mainWizardControl.SelectedTab = _sourceFilesTabPage
            Else
               _signatureFileNameTextBox.Text = ""
               _filePasswordTextBox.Text = ""
               _mainWizardControl.SelectedTab = _destinationFileTabPage
            End If
         End If
      End Sub

      Private Sub _operationComboBox_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _operationComboBox.SelectedIndexChanged
         UpdateUIState()
      End Sub

      Private Sub _operationAllPagesCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _operationAllPagesCheckBox.CheckedChanged
         UpdateUIState()
      End Sub
#End Region ' Operation Page

#Region "Distill Page"
      Private Sub DistillUpdateUIState()
         _previousButton.Enabled = True
         _nextButton.Enabled = True
         _nextButton.Text = "&Next"
      End Sub

      Private Sub DistillPreviousPage()
         _mainWizardControl.SelectedTab = _sourceFileTabPage
      End Sub

      Private Sub DistillNextPage()
         If String.IsNullOrEmpty(_distillPDFFileTextBox.Text) Then
            Messager.ShowWarning(Me, "You must select the PDF file name to create.")
            Return
         End If

         _destinationFileName = _distillPDFFileTextBox.Text

         _distillerOptions = New PDFDistillerOptions()
         _distillerOptions.OutputMode = CType(_distillOptionsOutputModeComboBox.SelectedIndex, PDFDistillerOutputMode)
         _distillerOptions.AutoRotatePageMode = CType(_distillOptionsAutoRotatePageModeComboBox.SelectedIndex, PDFDistillerAutoRotatePageMode)

         _mainWizardControl.SelectedTab = _optionsTabPage
      End Sub

      Private Sub _distillPDFFileBrowseButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _distillPDFFileBrowseButton.Click
         Dim pdfFileName As String = RunPDFSaveFileDialog()
         If Not pdfFileName Is Nothing Then
            _distillPDFFileTextBox.Text = pdfFileName
         End If
      End Sub
#End Region ' Distill Page

#Region "Source Files Page"
      Private Sub SourceFilesUpdateUIState()
         _previousButton.Enabled = True
         _nextButton.Enabled = True
         _nextButton.Text = "&Next"
      End Sub

      Private Sub SourceFilesPreviousPage()
         _mainWizardControl.SelectedTab = _operationTabPage
      End Sub

      Private Sub SourceFilesNextPage()
         If _sourceFilesListBox.Items.Count = 0 Then
            Messager.ShowWarning(Me, "You must select at least one file to merge with.")
            _sourceFilesAddButton.Focus()
            Return
         End If

         _mainWizardControl.SelectedTab = _destinationFileTabPage
      End Sub

      Private Sub _sourceFilesAddButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _sourceFilesAddButton.Click
         Dim fileName As String = RunPDFOpenFileDialog(True)
         If Not fileName Is Nothing Then
            _sourceFilesListBox.Items.Add(fileName)
         End If
      End Sub

      Private Sub _sourceFilesClearButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _sourceFilesClearButton.Click
         _sourceFilesListBox.Items.Clear()
      End Sub
#End Region ' Source Files Page

#Region "Destination File Page"
      Private Sub DestinationFileUpdateUIState()
         _previousButton.Enabled = True
         _nextButton.Enabled = True

         Dim operationItem As OperationItem = GetCurrentOperation()
         If operationItem.DestinationMustExist Then
            ' Use must select a destination file
            _destinationFileUseSourceFileCheckBox.Checked = False
            _destinationFileUseSourceFileCheckBox.Visible = False
            _destinationFileNameGroupBox.Enabled = True
            _destinationFilePropertiesControl.Visible = True
            _destinationFileInsertPageNumberGroupBox.Visible = True
            If String.IsNullOrEmpty(_destinationFileInsertPageNumberTextBox.Text) Then
               _destinationFileInsertPageNumberTextBox.Text = "-1"
            End If
         Else
            _destinationFileUseSourceFileCheckBox.Visible = True
            _destinationFileNameGroupBox.Enabled = Not _destinationFileUseSourceFileCheckBox.Checked
            _destinationFilePropertiesControl.Visible = False
            _destinationFileInsertPageNumberGroupBox.Visible = False
         End If

         If operationItem.ShowDigitalSignatureOptions Then
            If _destinationFileUseSourceFileCheckBox.Checked Then
               _destinationFileNameTextBox.Text = _sourceDocument.FileName
            End If

            _signatureFileNameGroupBox.Visible = True
            _filePasswordGroupBox.Visible = True
            _nextButton.Text = "&Finish"
         Else
            _signatureFileNameGroupBox.Visible = False
            _filePasswordGroupBox.Visible = False
            _nextButton.Text = "&Next"
         End If
      End Sub

      Private Sub DestinationFilePreviousPage()
         Dim operationItem As OperationItem = GetCurrentOperation()
         If operationItem.MutlipleSourceFiles Then
            _mainWizardControl.SelectedTab = _sourceFilesTabPage
         Else
            If (Not _isSourcePostscript) Then
               _mainWizardControl.SelectedTab = _operationTabPage
               _destinationFileNameTextBox.Text = Nothing
               _destinationFileUseSourceFileCheckBox.Checked = False
            Else
               _mainWizardControl.SelectedTab = _distillTabPage
            End If
         End If
      End Sub

      Private Sub DestinationFileNextPage()
         If String.IsNullOrEmpty(_destinationFileNameTextBox.Text) AndAlso (Not _destinationFileUseSourceFileCheckBox.Checked) Then
            Messager.ShowWarning(Me, "You must select a destination PDF file")
            Return
         End If

         If _destinationFileInsertPageNumberGroupBox.Visible Then
            Dim insertPageNumber As Integer
            If (Not Integer.TryParse(_destinationFileInsertPageNumberTextBox.Text, insertPageNumber)) Then
               Messager.ShowWarning(Me, "Enter a valid page number")
               _destinationFileInsertPageNumberTextBox.Focus()
               _destinationFileInsertPageNumberTextBox.SelectAll()
               Return
            End If

            If insertPageNumber <> -1 AndAlso insertPageNumber <> 0 AndAlso (insertPageNumber < 1 OrElse insertPageNumber > _destinationDocument.Pages.Count) Then
               Messager.ShowWarning(Me, "Enter a valid page number")
               _destinationFileInsertPageNumberTextBox.Focus()
               _destinationFileInsertPageNumberTextBox.SelectAll()
               Return
            End If

            _insertPageNumber = insertPageNumber
            _destinationFileName = Nothing
         Else
            If _destinationFileUseSourceFileCheckBox.Checked Then
               _destinationFileName = Nothing
            Else
               _destinationFileName = _destinationFileNameTextBox.Text
            End If
         End If

         _mainWizardControl.SelectedTab = _optionsTabPage
      End Sub

      Private Sub _destinationFileNameBrowseButton_Click(ByVal sender As Object, ByVal e As EventArgs) Handles _destinationFileNameBrowseButton.Click
         Dim operationItem As OperationItem = GetCurrentOperation()
         If operationItem.DestinationMustExist Then
            ' Destination file must be a valid PDF file
            Dim isPostscript As Boolean
            Dim destinationDocument As PDFFile = BrowsePDFDocument(True, isPostscript)
            If Not destinationDocument Is Nothing Then
               _destinationDocument = destinationDocument

               _destinationFileNameTextBox.Text = _destinationDocument.FileName
               _destinationFilePropertiesControl.SetFileProperties(_destinationDocument)
            End If
         Else
            ' We will not check here
            Dim fileName As String = RunPDFSaveFileDialog()
            If Not fileName Is Nothing Then
               _destinationFileNameTextBox.Text = fileName
            End If
         End If

         UpdateUIState()
      End Sub

      Private Sub _signatureFileNameBrowseButton_Click(sender As Object, e As EventArgs) Handles _signatureFileNameBrowseButton.Click
         Dim fileName As String = BrowseDigitalSignature()
         If Not String.IsNullOrEmpty(fileName) Then
            _signatureFileNameTextBox.Text = fileName
         End If
      End Sub

      Private Sub _destinationFileUseSourceFileCheckBox_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles _destinationFileUseSourceFileCheckBox.CheckedChanged
         UpdateUIState()
      End Sub
#End Region ' Destination File Page

#Region "Option Page"
      Private Sub OptionsUpdateUIState()
         _previousButton.Enabled = True
         _nextButton.Enabled = True
         _nextButton.Text = "&Finish"

         Dim operationItem As OperationItem = GetCurrentOperation()
         If operationItem.DestinationMustExist Then
            _optionsConvertOptionsControl.SetDocument(_destinationDocument, True, operationItem.ShowSecurityOptions, operationItem.ShowOptimizationOptions, operationItem.ShowInitialViewOptions, _firstPageNumber, _lastPageNumber)
         Else
            _optionsConvertOptionsControl.SetDocument(_sourceDocument, operationItem.ShowCompatibilityLevel, operationItem.ShowSecurityOptions, operationItem.ShowOptimizationOptions, operationItem.ShowInitialViewOptions, _firstPageNumber, _lastPageNumber)
         End If
      End Sub

      Private Sub OptionsPreviousPage()
         If (Not _isSourcePostscript) Then
            _mainWizardControl.SelectedTab = _destinationFileTabPage
         Else
            _mainWizardControl.SelectedTab = _distillTabPage
         End If
      End Sub

      Private Sub OptionsNextPage()
         Dim operationItem As OperationItem = GetCurrentOperation()
         Dim viewFileName As String

         If operationItem.DestinationMustExist Then
            viewFileName = _destinationDocument.FileName
         Else
            If Not _destinationFileName Is Nothing Then
               viewFileName = _destinationFileName
            Else
               viewFileName = _sourceDocument.FileName
            End If
         End If

         If operationItem.DestinationMustExist Then
            _optionsConvertOptionsControl.UpdateDocument(_destinationDocument)
         Else
            _optionsConvertOptionsControl.UpdateDocument(_sourceDocument)
         End If

         Try
            Dim wait As WaitCursor = New WaitCursor()
            Try
               Select Case operationItem.Operation
                  Case Operation.UpdateProperties
                     _sourceDocument.SetDocumentProperties(_destinationFileName)

                  Case Operation.ConvertToPDFA
                     _sourceDocument.ConvertToPDFA(_destinationFileName)

                  Case Operation.Linearize
                     _sourceDocument.Linearize(_destinationFileName)

                  Case Operation.Convert
                     _sourceDocument.Convert(_firstPageNumber, _lastPageNumber, _destinationFileName)

                  Case Operation.Merge
                     Dim sourceFiles As String() = New String(_sourceFilesListBox.Items.Count - 1) {}
                     Dim i As Integer = 0
                     Do While i < _sourceFilesListBox.Items.Count
                        sourceFiles(i) = _sourceFilesListBox.Items(i).ToString()
                        i += 1
                     Loop

                     _sourceDocument.MergeWith(sourceFiles, _destinationFileName)

                  Case Operation.DeletePages
                     _sourceDocument.DeletePages(_firstPageNumber, _lastPageNumber, _destinationFileName)

                  Case Operation.ExtractPages
                     _sourceDocument.ExtractPages(_firstPageNumber, _lastPageNumber, _destinationFileName)

                  Case Operation.InsertPages
                     _destinationDocument.InsertPagesFrom(_insertPageNumber, _sourceDocument, _firstPageNumber, _lastPageNumber)

                  Case Operation.Distill
                     _sourceDocument.Distill(_distillerOptions, _destinationFileName)

                  Case Operation.InitialView
                     _sourceDocument.SetInitialView(_destinationFileName)

                  Case Operation.Optimizer
                     _sourceDocument.Optimize(_destinationFileName)

                  Case Operation.DigitalSignature
                     If Not HasDigitalSignatureSupport(Me) Then
                        Return
                     End If

                     _sourceDocument.SignDocument(_destinationFileNameTextBox.Text, _signatureFileNameTextBox.Text, _filePasswordTextBox.Text)
                  Case Else
               End Select
            Finally
               CType(wait, IDisposable).Dispose()
            End Try

            System.Diagnostics.Process.Start(viewFileName)
         Catch ex As Exception
            Messager.ShowError(Me, ex)
         End Try
      End Sub
#End Region ' Option Page

#Region "Tools"
      Private Function BrowsePDFDocument(ByVal pdfOnly As Boolean, <System.Runtime.InteropServices.Out()> ByRef isPostscript As Boolean) As PDFFile
         isPostscript = False
         Dim fileName As String = RunPDFOpenFileDialog(pdfOnly)
         If fileName Is Nothing Then
            Return Nothing
         End If

         Try
            Dim fileType As PDFFileType = PDFFile.GetPDFFileType(fileName, pdfOnly)
            If fileType = PDFFileType.Unknown Then
               If pdfOnly Then
                  Messager.ShowError(Me, String.Format("Not a valid PDF file." & Constants.vbLf + Constants.vbLf & "{0}", fileName))
               Else
                  Messager.ShowError(Me, String.Format("Not a valid PDF or Postscript file." & Constants.vbLf + Constants.vbLf & "{0}", fileName))
               End If
               Return Nothing
            End If

            If fileType = PDFFileType.Postscript OrElse fileType = PDFFileType.EncapsulatedPostscript Then
               isPostscript = True
            End If

            If (Not isPostscript) Then
               Dim password As String = Nothing

               ' Check if it is encrypted
               If PDFFile.IsEncrypted(fileName) Then
                  Dim dlg As GetPasswordDialog = New GetPasswordDialog()
                  Try
                     If dlg.ShowDialog(Me) = DialogResult.OK Then
                        password = dlg.Password
                     Else
                        Return Nothing
                     End If
                  Finally
                     CType(dlg, IDisposable).Dispose()
                  End Try
               End If

               Dim wait As WaitCursor = New WaitCursor()
               Try
                  Dim document As PDFFile = New PDFFile(fileName, password)
                  document.Load()
                  Return document
               Finally
                  CType(wait, IDisposable).Dispose()
               End Try
            Else
               Dim document As PDFFile = New PDFFile(fileName)
               Return document
            End If
         Catch ex As Exception
            Messager.ShowError(Me, ex.Message)
         End Try

         Return Nothing
      End Function

      Private Function RunPDFOpenFileDialog(ByVal pdfOnly As Boolean) As String
         Dim dlg As OpenFileDialog = New OpenFileDialog()
         Try
            If pdfOnly Then
               dlg.Filter = "PDF Documents|*.pdf|All Files|*.*"
            Else
               dlg.Filter = "PDF or Postscript Documents|*.pdf;*.ps;*.eps|All Files|*.*"
            End If

            If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
               Return dlg.FileName
            End If
         Finally
            CType(dlg, IDisposable).Dispose()
         End Try

         Return Nothing
      End Function

      Private Function RunPDFSaveFileDialog() As String
         Dim dlg As SaveFileDialog = New SaveFileDialog()
         Try
            dlg.Filter = "PDF Documents|*.pdf|All Files|*.*"
            dlg.DefaultExt = "pdf"
            If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
               Return dlg.FileName
            End If
         Finally
            CType(dlg, IDisposable).Dispose()
         End Try

         Return Nothing
      End Function

      Private Function BrowseDigitalSignature() As String
         Using dlg As New OpenFileDialog()
            dlg.Filter = "Digital Signature|*.pfx"

            If dlg.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
               Return dlg.FileName
            End If
         End Using

         Return ""
      End Function

      Private Shared Function HasDigitalSignatureSupport(owner As IWin32Window) As Boolean
         ' If the user selected to parse digital signature then verify the status
         Dim digitalSignatureSupportStatus As RasterExceptionCode = PDFDocument.GetDigitalSignatureSupportStatus()
         If digitalSignatureSupportStatus = RasterExceptionCode.OpenSSLDllMissing Then
            ' We have PDF digital signature support but Open SSL library Is missing.
            Dim Message As String = "To use this feature, download the latest version of the 1.1.0 OpenSSL libraries and copy libcrypto-1_1[-x64].dll and libssl-1_1[-x64].dll to the location of the LEADTOOLS binaries folder." + Environment.NewLine + Environment.NewLine +
               "LEAD Precompiled and Signed OpenSSL binaries:" + Environment.NewLine +
               "https://www.leadtools.com/openssl/binaries" + Environment.NewLine + Environment.NewLine +
               "OpenSSL source code:" + Environment.NewLine +
               "https://www.openssl.org"
            Dim caption As String = "Download OpenSSL"

            MessageBox.Show(owner, Message, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return False
         Else
            ' Nothing for us to do, will either work Or Not supported in this platform
            Return True
         End If
      End Function
#End Region ' Tools
   End Class
End Namespace
