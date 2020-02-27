' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports Leadtools
Imports Leadtools.Barcode
Imports Leadtools.Codecs
Imports Leadtools.Demos
Imports Leadtools.Forms.Auto
Imports Leadtools.Ocr
Imports Leadtools.Forms.Processing
Imports Leadtools.Forms.Recognition

#If FOR_DOTNET4 Then
Imports Leadtools.Forms.Recognition.Search
#End If

Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms
Imports System

Partial Public Class UpdateMasterFormsData
   Inherits Form
   Public Sub New()
      InitializeComponent()
   End Sub

   Private _isRunning As Boolean
   Private _codecs As RasterCodecs
   Public ocrEngine As IOcrEngine
   Public barcodeEngine As BarcodeEngine
   Public recognitionEngine As FormRecognitionEngine
   Private UpdateMasterFormsThread As Thread

   Private Sub UpdateMasterFormsData_Load(sender As Object, e As EventArgs) Handles Me.Load
      Messager.Caption = "Update Master Forms Data Utility"
      Text = Messager.Caption
      _isRunning = False
      _codecs = New RasterCodecs()

      If Not [String].IsNullOrEmpty(Settings.[Default].SourceFolder) Then
         _txtSrcFolder.Text = Settings.[Default].SourceFolder
      End If

      UpdateControls()

#If Not FOR_DOTNET4 Then
      _cbUseFullTextSearch.Visible = False
#End If

   End Sub

   Private Sub UpdateControls()
      If _isRunning Then
         _btnCancel.Enabled = True
      Else
         _btnCancel.Enabled = False
      End If

      If [String].IsNullOrEmpty(_txtSrcFolder.Text) Then
         _btnConvert.Enabled = False
      Else
         _btnConvert.Enabled = True
      End If
   End Sub

   Private Sub _btnBrowseSrcFolder_Click(sender As Object, e As EventArgs) Handles _btnBrowseSrcFolder.Click
      Using dlg As New FolderBrowserDialogEx()
         dlg.Description = "Select Source Folder"
         dlg.ShowNewFolderButton = False
         dlg.ShowEditBox = True
         dlg.ShowFullPathInEditBox = True
         If Directory.Exists(_txtSrcFolder.Text) Then
            dlg.SelectedPath = _txtSrcFolder.Text
         End If
         If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            _txtSrcFolder.Text = dlg.SelectedPath
         End If
      End Using
      UpdateControls()
   End Sub

   Private Sub _txtSrcFolder_TextChanged(sender As Object, e As EventArgs) Handles _txtSrcFolder.TextChanged
      UpdateControls()
   End Sub

   Private Sub _btnConvert_Click(sender As Object, e As EventArgs) Handles _btnConvert.Click
      _isRunning = True
      UpdateControls()

      UpdateMasterFormsThread = New Thread(New ThreadStart(AddressOf UpdateData))
      UpdateMasterFormsThread.Start()
   End Sub

   Private Sub UpdateData()
      Dim recognitionEngineVersion As Integer = FormRecognitionEngine.Version
#If FOR_DOTNET4 Then
      Dim originalFullTextSearchManager As IFullTextSearchManager = recognitionEngine.FullTextSearchManager
#End If
      Try
         If Not Directory.Exists(_txtSrcFolder.Text) Then
            Invoke(CType(Sub() Messager.Show(Me, "Please select valid folder", MessageBoxIcon.[Error], MessageBoxButtons.OK), MethodInvoker))
            Return
         End If
         ' Set the data version to latest, we want to update the data to use the latest
         FormRecognitionEngine.Version = FormRecognitionEngine.LatestVersion

         ' Set the full text search engine
         Dim workingRepository As New DiskMasterFormsRepository(_codecs, _txtSrcFolder.Text)

#If FOR_DOTNET4 Then
         If _cbUseFullTextSearch.Checked Then
            Dim fullTextSearchManager As New DiskFullTextSearchManager()
            fullTextSearchManager.IndexDirectory = Path.Combine(workingRepository.Path, "index")
            recognitionEngine.FullTextSearchManager = fullTextSearchManager
         End If
#End If
         Dim parentCategory As IMasterFormsCategory = workingRepository.RootCategory
         Invoke(CType(Sub() _prgbar.Maximum = parentCategory.MasterForms.Count, MethodInvoker))

         For i As Integer = 0 To _prgbar.Maximum - 1
            If Not _isRunning Then
               Return
            End If

            Invoke(CType(Sub() _prgbar.Value += 1, MethodInvoker))

            'Get the Original Attributes
            Dim originalMasterForm As DiskMasterForm = CType(parentCategory.MasterForms(i), DiskMasterForm)
            Dim originalAttributes As FormRecognitionAttributes = originalMasterForm.ReadAttributes()
            recognitionEngine.OpenMasterForm(originalAttributes)
            recognitionEngine.CloseMasterForm(originalAttributes)

            Dim options As New FormRecognitionOptions()
            Dim attributes As FormRecognitionAttributes = recognitionEngine.CreateMasterForm(parentCategory.MasterForms(i).Name, New Guid(), options)
            recognitionEngine.CloseMasterForm(attributes)

            Dim newForm As IMasterForm = parentCategory.AddMasterForm(attributes, Nothing, CType(Nothing, RasterImage))

            Dim currentMasterForm As DiskMasterForm = TryCast(parentCategory.MasterForms(i), DiskMasterForm)
            attributes = currentMasterForm.ReadAttributes()
            Dim formPages As FormPages = currentMasterForm.ReadFields()
            Dim formImage As RasterImage = currentMasterForm.ReadForm()

            For j As Integer = 0 To formImage.PageCount - 1
               'Get the Page Recognition Options for the original Attributes
               Dim pageOptions As PageRecognitionOptions = GetPageOptions(j, originalAttributes)

               'Add each new page to the masterform by creating attributes for each page
               formImage.Page = j + 1
               recognitionEngine.OpenMasterForm(attributes)
               recognitionEngine.DeleteMasterFormPage(attributes, j + 1)
               recognitionEngine.InsertMasterFormPage(j + 1, attributes, formImage.Clone(), pageOptions, Nothing)
#If FOR_DOTNET4 Then
               If _cbUseFullTextSearch.Checked Then
                  recognitionEngine.UpsertMasterFormToFullTextSearch(attributes, "index", Nothing, Nothing, Nothing, Nothing)
               End If
#End If
               recognitionEngine.CloseMasterForm(attributes)
            Next

            Dim tempProcessingEngine As New FormProcessingEngine()
            tempProcessingEngine.OcrEngine = ocrEngine
            tempProcessingEngine.BarcodeEngine = barcodeEngine

            For j As Integer = 0 To recognitionEngine.GetFormProperties(attributes).Pages - 1
               tempProcessingEngine.Pages.Add(New FormPage(j + 1, formImage.XResolution, formImage.YResolution))
            Next

            formPages = tempProcessingEngine.Pages
            currentMasterForm.WriteAttributes(attributes)

            currentMasterForm.WriteFields(parentCategory.MasterForms(i).ReadFields())
         Next
#If FOR_DOTNET4 Then
         If recognitionEngine.FullTextSearchManager IsNot Nothing Then
            recognitionEngine.FullTextSearchManager.Index()
         End If
#End If
         System.Diagnostics.Process.Start(_txtSrcFolder.Text)
      Catch ex As Exception
         Invoke(CType(Sub() Messager.Show(Me, ex, MessageBoxIcon.[Error]), MethodInvoker))
      Finally
         ' Restore the original version
         FormRecognitionEngine.Version = recognitionEngineVersion
#If FOR_DOTNET4 Then
         recognitionEngine.FullTextSearchManager = originalFullTextSearchManager
#End If
         _isRunning = False
         Invoke(CType(Sub()
                         _prgbar.Value = 0
                         UpdateControls()

                      End Sub, MethodInvoker))
      End Try
   End Sub

   Private Function GetPageOptions(pageIndex As Integer, attributes As FormRecognitionAttributes) As PageRecognitionOptions
      Dim options As PageRecognitionOptions = Nothing
      recognitionEngine.OpenMasterForm(attributes)
      options = recognitionEngine.GetPageOptions(attributes, pageIndex)
      recognitionEngine.CloseMasterForm(attributes)

      Return options
   End Function

   Private Sub _btnCancel_Click(sender As Object, e As EventArgs) Handles _btnCancel.Click
      _isRunning = False
      UpdateControls()
   End Sub

   Private Sub UpdateMasterFormsData_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
      If Not [String].IsNullOrEmpty(_txtSrcFolder.Text) Then
         Settings.[Default].SourceFolder = _txtSrcFolder.Text
      End If

      Settings.[Default].Save()

      If UpdateMasterFormsThread IsNot Nothing AndAlso UpdateMasterFormsThread.ThreadState = ThreadState.Running Then
         UpdateMasterFormsThread.Abort()
      End If

      _codecs.Dispose()
   End Sub
End Class
