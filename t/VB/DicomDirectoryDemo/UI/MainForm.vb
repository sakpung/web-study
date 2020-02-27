' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.IO
Imports System.Windows.Forms
Imports System.Diagnostics

Imports Leadtools
Imports Leadtools.Dicom
Imports Leadtools.DicomDemos
Imports Leadtools.Controls

Namespace DicomDemo
   Partial Public Class MainForm : Inherits Form
      Private m_strDicomFilesFolder As String
      Private m_DicomDir As UserDicomDir
      Private rasterImageViewer1 As ImageViewer

      Public Shared cancel As Boolean = False

      Public Sub New()
         InitializeComponent()

         Utils.EngineStartup()
      End Sub

      ''' <summary>
      ''' The main entry point for the application.
      ''' </summary>
      <STAThread()> _
      Shared Sub Main()


         If Not Support.SetLicense() Then
            Return
         End If

         If RasterSupport.IsLocked(RasterSupportType.Medical) Then
            MessageBox.Show(String.Format("{0} Support is locked!", RasterSupportType.Medical.ToString()), "Warning")
            Return
         End If

         Application.Run(New MainForm())
      End Sub

      Private Sub SetStatus(ByVal status As String, ByVal doEvents As Boolean)
         txtStatus.Text = status
         If doEvents Then
            Application.DoEvents()
         End If
      End Sub

      Private Sub SetStatus(ByVal status As String)
         txtStatus.Text = status
      End Sub

      Private Sub UpdateUI(ByVal enable As Boolean)
         btnCreate.Enabled = enable
         btnInsert.Enabled = enable
         btnLoad.Enabled = enable

         Dim saveFolderSet As Boolean = Not String.IsNullOrEmpty(txtDirectory.Text)
         btnSave.Enabled = enable AndAlso saveFolderSet

         chkRejectInvalidFileIds.Enabled = enable
         chkInsertIconImageSequence.Enabled = enable
      End Sub

      ' Creates a new Dicom Directory based on a folder
      Private Sub btnCreate_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCreate.Click
         MainForm.cancel = False

         If (Not GetFolder()) Then
            MessageBox.Show("Please choose a valid directory")
            Return
         End If

         ' Reset and clear
         rasterImageViewer1.Visible = False
         rasterImageViewer1.Image = Nothing
         trvDicomDir.Nodes.Clear()
         m_DicomDir.Reset("")
         txtElementValue.Text = ""
         txtDirectory.Text = ""
         SetStatus("")
         Invalidate()

         Me.Cursor = Cursors.WaitCursor

         txtDirectory.Text = m_strDicomFilesFolder

         UpdateUI(False)

         ' Create a DICOM Directory for all the files in the folder 
         ' m_strDicomFilesFolder and all subfolders
         Try
            Debug.WriteLine("Start Creating DicomDir...")
            DoCreateDicomDirectory()
            Debug.WriteLine("End Creating DicomDir...")

         Catch ex As Exception
            SetStatus(String.Format("Status: Failed to create the DICOM Directory!  (Error Message: {0})  Make sure that only valid Dicom DataSet files exist in the directory.", ex.Message))
            Me.Cursor = Cursors.Default
            Return
         End Try

         UpdateUI(True)

         If m_DicomDir.GetAddedDicomFilesCount() = 0 Then
            SetStatus("Status: Search is complete. No DICOM files were added to the DICOM Directory.")

            Me.Cursor = Cursors.Default
         End If

         ' Populate the tree
         Try
            Debug.WriteLine("Start FillTree...")
            FillTreeKeys(Nothing, Nothing)
         Catch ex As Exception
            MessageBox.Show("Error while populating tree:" & Constants.vbCrLf & Constants.vbCrLf & ex.ToString())
         End Try
         Debug.WriteLine("End FillTree...")

         SetStatus(String.Format("Status: Search is complete. {0} file(s) were added to the DICOM Directory.", m_DicomDir.GetAddedDicomFilesCount()))

         Me.Cursor = Cursors.Default
      End Sub

      ' Creates a FolderBrowserDialog for the user to select the directory from which
      ' to create the Dicom Directory
      Private Function GetFolder() As Boolean
         Dim fbd As FolderBrowserDialog = New FolderBrowserDialog()
         fbd.ShowDialog(Me)
         If Directory.Exists(fbd.SelectedPath) Then
            m_strDicomFilesFolder = fbd.SelectedPath
            Return True
         End If
         Return False
      End Function

      ' Creates a Dicom Directory based on the value of m_strDicomFilesFolder
      Private Sub DoCreateDicomDirectory()
         Try
            ' Reset the DICOM Directory and set the destination folder where
            ' the DICOMDIR file will be saved
            m_DicomDir.Reset(m_strDicomFilesFolder)

            ' If it is desired to change the values of the Implementation Class
            ' UID (0002,0012) and the Implementation Version Name (0002,0013)...
            Dim element As DicomElement
            element = m_DicomDir.DataSet.FindFirstElement(Nothing, DemoDicomTags.ImplementationClassUID, False)
            If Not element Is Nothing Then
               m_DicomDir.DataSet.SetStringValue(element, "1.2.840.114257.0.1", DicomCharacterSetType.Default) ' Must be a UID
            End If
            element = m_DicomDir.DataSet.FindFirstElement(Nothing, DemoDicomTags.ImplementationVersionName, False)
            If Not element Is Nothing Then
               m_DicomDir.DataSet.SetStringValue(element, "LEADTOOLS", DicomCharacterSetType.Default) ' Must be a UID
            End If

            ' Set options
            Dim options As DicomDirOptions
            options = m_DicomDir.Options
            options.IncludeSubfolders = True
            options.InsertIconImageSequence = chkInsertIconImageSequence.Checked
            options.RejectInvalidFileId = chkRejectInvalidFileIds.Checked
            m_DicomDir.Options = options


            m_DicomDir.SetStatusTextBox(txtStatus)

            ' Add the DICOM files to the DICOM Directory.
            ' This is the function that does it all!
            ' You can always give the user feedback about the progress inside 
            ' this function by overriding the function DicomDir.OnInsertFile.   
            m_DicomDir.InsertFile(Nothing)
         Catch ex As Exception
            Throw ex
         End Try
      End Sub

      Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
         ' Do some initialization
         m_strDicomFilesFolder = ""
         m_DicomDir = New UserDicomDir()

         ' Add a RasterImageViewer in the same location as txtElementValue
         rasterImageViewer1 = New ImageViewer()
         rasterImageViewer1.Visible = False
         groupBox3.Controls.Add(rasterImageViewer1)
         rasterImageViewer1.Location = txtElementValue.Location
         rasterImageViewer1.Size = txtElementValue.Size
         rasterImageViewer1.Zoom(ControlSizeMode.Fit, 1, rasterImageViewer1.DefaultZoomOrigin)
         txtElementValue.SendToBack()
         UpdateUI(True)

         AddHandler Application.ApplicationExit, AddressOf Application_ApplicationExit
      End Sub

      Private Sub Application_ApplicationExit(ByVal sender As Object, ByVal e As EventArgs)
         Utils.EngineShutdown()
      End Sub

      ' Populates the TreeView with the keys to represent m_DicomDir
      Private Sub FillTreeKeys(ByVal ParentKeyElement As DicomElement, ByVal ParentNode As TreeNode)
         Dim CurrentKeyElement, CurrentKeyChildElement As DicomElement
         Dim node As TreeNode
         Dim name As String
         Dim temp As String = ""
         Dim counter As Integer = 0

         If ParentKeyElement Is Nothing Then
            CurrentKeyElement = m_DicomDir.DataSet.GetFirstKey(Nothing, True)
         Else
            CurrentKeyElement = m_DicomDir.DataSet.GetChildKey(ParentKeyElement)
         End If

         ' Add the keys to the TreeView
         Do While Not CurrentKeyElement Is Nothing
            ' Get key name
            temp = m_DicomDir.DataSet.GetKeyValueString(CurrentKeyElement)

            If (Not temp Is Nothing) OrElse (temp = "") Then
               name = temp
            Else
               name = "UNKNOWN"
            End If

            ' Add at root or beneath its parent
            If ParentNode Is Nothing Then
               node = trvDicomDir.Nodes.Add(name)
            Else
               node = ParentNode.Nodes.Add(name)
            End If

            node.Tag = CurrentKeyElement

            ' Add the current key's non-key child elements
            CurrentKeyChildElement = m_DicomDir.DataSet.GetChildElement(CurrentKeyElement, True)
            Do While Not CurrentKeyChildElement Is Nothing
               FillKeySubTree(CurrentKeyChildElement, node, False)
               CurrentKeyChildElement = m_DicomDir.DataSet.GetNextElement(CurrentKeyChildElement, True, True)
            Loop

            counter += 1
            If (counter Mod 100) = 0 Then

               SetStatus(String.Format("Added {0} Elements to Tree Display", counter))
               Application.DoEvents()
            End If

            ' Recursively add child keys
            If Not m_DicomDir.DataSet.GetChildKey(CurrentKeyElement) Is Nothing Then
               FillTreeKeys(CurrentKeyElement, node)
            End If

            CurrentKeyElement = m_DicomDir.DataSet.GetNextKey(CurrentKeyElement, True)
         Loop
      End Sub

      ' Populates the TreeView with the elements below each Key to represent m_DicomDir
      Private Sub FillKeySubTree(ByVal element As DicomElement, ByVal ParentNode As TreeNode, ByVal recurse As Boolean)
         Dim node As TreeNode
         Dim name As String
         Dim temp As String = ""
         Dim tempElement As DicomElement
         Dim tag As DicomTag

         ' Get the tag's numerical display value (XXXX:XXXX)
         tag = DicomTagTable.Instance.Find(element.Tag)
         temp = String.Format("{0:x4}:{1:x4} - ", Utils.GetGroup(CLng(element.Tag)), Utils.GetElement(CLng(element.Tag)))

         ' Get the tag's name
         If tag Is Nothing Then
            name = "Item"
         Else
            name = tag.Name
         End If

         temp = temp & name

         ' Add the node either on the root or beneath its parent
         If Not ParentNode Is Nothing Then
            node = ParentNode.Nodes.Add(temp)
         Else
            node = trvDicomDir.Nodes.Add(temp)
         End If

         node.Tag = element
         node.ImageIndex = 1
         node.SelectedImageIndex = 1

         ' If the element has children, recursively add them
         tempElement = m_DicomDir.DataSet.GetChildElement(element, True)
         If Not tempElement Is Nothing Then
            node.ImageIndex = 0
            node.SelectedImageIndex = 0
            FillKeySubTree(tempElement, node, True)
         End If

         If recurse Then
            tempElement = m_DicomDir.DataSet.GetNextElement(element, True, True)
            If Not tempElement Is Nothing Then
               FillKeySubTree(tempElement, ParentNode, True)
            End If
         End If
      End Sub

      ' Displays the value of the element.
      Private Sub trvDicomDir_AfterSelect(ByVal sender As Object, ByVal e As TreeViewEventArgs) Handles trvDicomDir.AfterSelect
         Dim element As DicomElement
         Dim value As String

         rasterImageViewer1.Visible = False
         rasterImageViewer1.Image = Nothing

         txtElementValue.Text = ""

         If trvDicomDir.SelectedNode.Tag Is Nothing Then
            Return
         End If

         element = CType(trvDicomDir.SelectedNode.Tag, DicomElement)

         Try
            If element.Tag = DemoDicomTags.PixelData Then
               rasterImageViewer1.Image = m_DicomDir.DataSet.GetImage(element, 0, 8, RasterByteOrder.Gray, DicomGetImageFlags.AutoApplyVoiLut)
               rasterImageViewer1.Visible = True
               Return
            End If

            value = m_DicomDir.DataSet.GetConvertValue(element)
            If Not value Is Nothing AndAlso value.Length > 0 Then
               value = value.Replace("\", Constants.vbCrLf)
            End If
            txtElementValue.Text = value
         Catch ex As Exception
            MessageBox.Show("Error getting element value:" & Constants.vbCrLf & Constants.vbCrLf & ex.ToString())
         End Try
      End Sub

      ' If the element is Referenced File ID, then display the full image in the viewer
      Private Sub trvDicomDir_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles trvDicomDir.DoubleClick
         Dim element As DicomElement

         If trvDicomDir.SelectedNode Is Nothing Then
            Return
         End If

         If trvDicomDir.SelectedNode.Tag Is Nothing Then
            Return
         End If

         element = CType(trvDicomDir.SelectedNode.Tag, DicomElement)

         If element.Tag = DemoDicomTags.ReferencedFileID Then
            DisplayImage(CType(trvDicomDir.SelectedNode.Tag, DicomElement))
         End If
      End Sub

      ' Loads an image based on the Referened File ID element
      '
      ' Preconditions:
      '   1. element != null
      '   2. element.Tag == DemoDicomTags.ReferencedFileID
      Private Sub DisplayImage(ByVal element As DicomElement)
         If (Not m_DicomDir.DataSet.ExistsElement(element)) Then
            Return
         End If

         txtElementValue.Text = ""

         Dim strFileName As String
         Dim ImageDS As DicomDataSet
         Dim PixelDataElement As DicomElement

         ' Get file name
         strFileName = m_strDicomFilesFolder
         Dim I As Integer = 0
         For I = 0 To m_DicomDir.DataSet.GetElementValueCount(element) - 1
            strFileName += "\" & m_DicomDir.DataSet.GetStringValue(element, I)
         Next I

         ' Load the data set
         ImageDS = New DicomDataSet()
         Try
            ImageDS.Load(strFileName, DicomDataSetLoadFlags.LoadAndClose)
         Catch ex As Exception
            SetStatus(String.Format("Failed to load DataSet.  Error Message: {0}", ex.Message))
            Return
         End Try

         ' Get the image from the Pixel Data element and display it in the viewer
         Try
            PixelDataElement = ImageDS.FindFirstElement(Nothing, DemoDicomTags.PixelData, False)
            If PixelDataElement Is Nothing Then
               SetStatus(String.Format("Dataset does not contain an image."))
               Return
            End If

            rasterImageViewer1.Image = ImageDS.GetImage(PixelDataElement, 0, 0, RasterByteOrder.Rgb, DicomGetImageFlags.AutoApplyModalityLut Or DicomGetImageFlags.AutoApplyVoiLut Or DicomGetImageFlags.AllowRangeExpansion)
            rasterImageViewer1.Visible = True
         Catch ex As Exception
            SetStatus(String.Format("Failed to load the image from the DataSet.  Error Message: {0}", ex.Message))
            Return
         End Try
      End Sub

      ' Loads an existing DICOMDIR file
      Private Sub btnLoad_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLoad.Click
         MainForm.cancel = False

         Dim ofd As OpenFileDialog
         ofd = New OpenFileDialog()
         ofd.Filter = "DICOMDIR|DICOMDIR|All Files|*.*"
         ofd.FilterIndex = 0
         If ofd.ShowDialog() <> DialogResult.OK Then
            Return
         End If

         ' Reset and clear
         rasterImageViewer1.Visible = False
         rasterImageViewer1.Image = Nothing
         trvDicomDir.Nodes.Clear()
         m_DicomDir.Reset("")
         m_strDicomFilesFolder = ""
         txtElementValue.Text = ""
         txtDirectory.Text = ""
         SetStatus("")
         Invalidate()

         ' Get the root directory of this DICOMDIR
         m_strDicomFilesFolder = ofd.FileName.Substring(0, ofd.FileName.LastIndexOf("\"))
         txtDirectory.Text = m_strDicomFilesFolder

         If (Not File.Exists(ofd.FileName)) Then
            MessageBox.Show("File does not exist.")
            Return
         End If

         ' Load the file and populate the TreeView
         Try
            m_DicomDir.Load(ofd.FileName, DicomDataSetLoadFlags.LoadAndClose)

            If m_DicomDir.DataSet.InformationClass <> DicomClassType.BasicDirectory Then
               MessageBox.Show("Please select a valid Dicom Directory file.")
               m_DicomDir = New UserDicomDir()
               Return
            End If
            Try
               FillTreeKeys(Nothing, Nothing)
            Catch ex As Exception
               MessageBox.Show("Error while populating tree:" & Constants.vbCrLf & Constants.vbCrLf & ex.ToString())
            End Try

            SetStatus("DICOMDIR successfully loaded")
         Catch ex As Exception
            SetStatus(String.Format("Status: Failed to add file to the DICOM Directory!  (Error Message: {0})  Make sure that this is a valid Dicom DataSet.", ex.Message))
            Return
         End Try
      End Sub

      ' Inserts a single dataset into the existing DicomDir
      Private Sub btnInsert_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnInsert.Click
         MainForm.cancel = False

         Dim ofd As OpenFileDialog
         Dim InsertDs As DicomDataSet

         If m_strDicomFilesFolder = "" Then
            MessageBox.Show("You must create a Dicom Directory first")
            Return
         End If

         ofd = New OpenFileDialog()
         ofd.Filter = "DICOM Files (*.dic; *.dcm)|*.dic;*.dcm|All Files|*.*"
         ofd.FilterIndex = 0
         If ofd.ShowDialog() <> DialogResult.OK Then
            Return
         End If

         If (Not File.Exists(ofd.FileName)) Then
            MessageBox.Show("File does not exist.")
            Return
         End If

         ' If the file doesn't exist in the DICOMDIR's root directory, copy it there
         If (Not ofd.FileName.Contains(m_strDicomFilesFolder)) Then
            Dim strDstFileName As String
            Try
               strDstFileName = m_strDicomFilesFolder & ofd.FileName.Substring(ofd.FileName.LastIndexOf("\"))
               File.Copy(ofd.FileName, strDstFileName)
               ofd.FileName = strDstFileName
            Catch ex As Exception
               SetStatus(String.Format("Failed to copy the DataSet to the folder ""{0}"".  Error Message: {1}", m_strDicomFilesFolder, ex.Message))
               Return
            End Try
         End If

         ' Load the DataSet to be inserted
         InsertDs = New DicomDataSet()
         Try
            InsertDs.Load(ofd.FileName, DicomDataSetLoadFlags.None)
         Catch ex As Exception
            SetStatus(String.Format("Failed to load the DataSet.  Error Message: {0}", ex.Message))
            Return
         End Try

         ' Make sure the file isn't a Directory
         If InsertDs.InformationClass = DicomClassType.BasicDirectory Then
            MessageBox.Show("Please select a valid Dicom DataSet file that is not a Basic Directory.")
            Return
         End If

         ' Add the file
         Try
            m_DicomDir.InsertDataSet(InsertDs, ofd.FileName)
         Catch ex As Exception
            SetStatus(String.Format("Status: Failed to add file to the DICOM Directory!  (Error Message: {0})  Make sure that this is a valid Dicom DataSet.", ex.Message))
            Return
         End Try

         ' Update tree
         trvDicomDir.Nodes.Clear()
         Try
            FillTreeKeys(Nothing, Nothing)
         Catch ex As Exception
            MessageBox.Show("Error while populating tree:" & Constants.vbCrLf & Constants.vbCrLf & ex.ToString())
         End Try
      End Sub

      Private Sub btnSave_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSave.Click
         MainForm.cancel = False

         If File.Exists(m_strDicomFilesFolder & "\DICOMDIR") Then
            If MessageBox.Show("A DICOMDIR file already exists, would you like to replace it?", "", MessageBoxButtons.YesNo) = DialogResult.No Then
               SetStatus("Saving of DICOMDIR file was cancelled.")
               Return
            End If
         End If

         UpdateUI(False)
         Try
            SetStatus("Saving the DICOMDIR...", True)
            Debug.WriteLine("Start Saving DICOMDIR ...")
            m_DicomDir.Save()
            Debug.WriteLine("End Save DICOMDIR")
            SetStatus(String.Format("A DICOMDIR file was saved to {0}\DICOMDIR", m_strDicomFilesFolder))
         Catch ex As Exception
            SetStatus(String.Format("Error saving DicomDir: {0}", ex.Message))
         End Try
         UpdateUI(True)
      End Sub

      Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
         cancel = True
         UpdateUI(True)
      End Sub

   End Class
End Namespace
