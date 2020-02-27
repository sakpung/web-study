' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Leadtools.Demos
Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports Leadtools.Dicom.Common.Editing
Imports Leadtools.Dicom
Imports Leadtools.Codecs
Imports Leadtools.MedicalViewer
Imports Leadtools
Imports System.Threading
Imports Leadtools.Demos.Dialogs

Namespace DicomEditorDemo
   Partial Public Class MainForm
      Inherits Form
      Private _DataSet As DicomDataSet
      Private _Filename As String = String.Empty
      Private _MedicalViewer As MedicalViewer

      Public ReadOnly Property Cell() As MedicalViewerCell
         Get
            Return TryCast(_MedicalViewer.Cells(0), MedicalViewerCell)
         End Get
      End Property

      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
         If DesignMode Then
            Return
         End If
         Messager.Caption = "VB DICOM Editor Demo"
         Text = Messager.Caption
         _DataSet = New DicomDataSet()
         If _DataSet Is Nothing Then
            MessageBox.Show("Can't create dicom object. Quitting app.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Application.Exit()
            Return
         End If

         splitContainer.SplitterDistance = ClientRectangle.Width \ 3
         InitializeMedicalViewer()
         LoadDefaultImage()
      End Sub

      Private Sub LoadDefaultImage()
         Try
            _DataSet.Load(DemosGlobal.ImagesFolder & "\image2.dcm", DicomDataSetLoadFlags.LoadAndClose)
            LoadImage(Nothing)
            _Filename = DemosGlobal.ImagesFolder & "\image2.dcm"
            propertyGridDataSet.DataSet = _DataSet
            Text = Messager.Caption & " : " & _Filename
         Catch
         End Try
      End Sub

      Private Sub InitializeMedicalViewer()
         Dim cell As New MedicalViewerCell()

         cell.AddAction(MedicalViewerActionType.Stack)
         cell.SetAction(MedicalViewerActionType.Stack, MedicalViewerMouseButtons.Wheel, MedicalViewerActionFlags.Active)

         _MedicalViewer = New MedicalViewer(1, 1)
         _MedicalViewer.Dock = DockStyle.Fill
         _MedicalViewer.SplitterStyle = MedicalViewerSplitterStyle.None
         _MedicalViewer.Cells.Add(cell)
         splitContainer.Panel2.Controls.Add(_MedicalViewer)
      End Sub

      Private Sub optionsToolStripMenuItem_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles optionsToolStripMenuItem.DropDownOpening
         showTagInfoToolStripMenuItem.Checked = propertyGridDataSet.ShowTagInfo
         showUsageImagesToolStripMenuItem.Checked = propertyGridDataSet.ShowUsageImages
         addCommandsToolStripMenuItem.Checked = propertyGridDataSet.ShowCommands
         readOnlyToolStripMenuItem.Checked = propertyGridDataSet.ReadOnly
      End Sub

      Private Sub showTagInfoToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles showTagInfoToolStripMenuItem.Click
         propertyGridDataSet.ShowTagInfo = showTagInfoToolStripMenuItem.Checked
      End Sub

      Private Sub showUsageImagesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles showUsageImagesToolStripMenuItem.Click
         propertyGridDataSet.ShowUsageImages = showUsageImagesToolStripMenuItem.Checked
      End Sub

      Private Sub addCommandsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles addCommandsToolStripMenuItem.Click
         propertyGridDataSet.ShowCommands = addCommandsToolStripMenuItem.Checked
      End Sub

      Private Sub exitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles exitToolStripMenuItem.Click
         Close()
      End Sub

      Private Sub openToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles openToolStripMenuItem.Click
         Using wait As New WaitCursor()
            openFileDialog.InitialDirectory = DemosGlobal.ImagesFolder
            If openFileDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
               Try
                  _DataSet.Load(openFileDialog.FileName, DicomDataSetLoadFlags.LoadAndClose)
                  LoadImage(Nothing)
                  _Filename = openFileDialog.FileName
                  propertyGridDataSet.DataSet = _DataSet
                  propertyGridDataSet.Refresh()
                  Text = Messager.Caption & " : " & openFileDialog.FileName
               Catch ex As Exception
                  Messager.ShowError(Me, ex.Message)
               End Try
            End If
         End Using
      End Sub

      Private Sub LoadImage(ByVal image As RasterImage)
         Dim count As Integer = 0

         Clear()
         If image Is Nothing Then
            count = _DataSet.GetImageCount(Nothing)
            If count > 0 Then
#If Not LEADTOOLS_V20_OR_LATER Then
               Dim getImageFlags As DicomGetImageFlags = DicomGetImageFlags.AutoApplyModalityLut Or DicomGetImageFlags.AutoApplyVoiLut Or DicomGetImageFlags.AutoScaleModalityLut Or DicomGetImageFlags.AutoScaleVoiLut Or DicomGetImageFlags.AutoDectectInvalidRleCompression
#Else
               Dim getImageFlags As DicomGetImageFlags = DicomGetImageFlags.AutoApplyModalityLut Or DicomGetImageFlags.AutoApplyVoiLut Or DicomGetImageFlags.AutoScaleModalityLut Or DicomGetImageFlags.AutoScaleVoiLut Or DicomGetImageFlags.AutoDetectInvalidRleCompression
#End If ' #If Not LEADTOOLS_V20_OR_LATER Then
               image = _DataSet.GetImages(Nothing, 0, count, 0, RasterByteOrder.Rgb Or RasterByteOrder.Gray, getImageFlags)
            End If

            animationToolStripMenuItem.Enabled = count > 1
         End If

         If image IsNot Nothing Then
            Dim cell As MedicalViewerCell = TryCast(_MedicalViewer.Cells(0), MedicalViewerCell)

            cell.Image = image
            cell.FitImageToCell = True
            If image.GrayscaleMode <> RasterGrayscaleMode.None Then
               cell.SetTag(2, MedicalViewerTagAlignment.BottomLeft, MedicalViewerTagType.WindowLevelData)
               cell.SetTag(0, MedicalViewerTagAlignment.TopRight, MedicalViewerTagType.Frame)
            End If

            animationToolStripMenuItem.Enabled = image.PageCount > 1
         End If
      End Sub

      Private Sub commandsToolStripMenuItem_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles commandsToolStripMenuItem.DropDownOpening
         Dim hasDataSet As Boolean = propertyGridDataSet.DataSet IsNot Nothing

            addTagsToolStripMenuItem.Enabled = hasDataSet AndAlso propertyGridDataSet.CanAddTag And Not propertyGridDataSet.ReadOnly
            addItemToolStripMenuItem.Enabled = hasDataSet AndAlso propertyGridDataSet.CanAddSequenceItem And Not propertyGridDataSet.ReadOnly
            deleteTagToolStripMenuItem.Enabled = hasDataSet And Not propertyGridDataSet.ReadOnly
         animationToolStripMenuItem.Enabled = hasDataSet AndAlso Cell.Image IsNot Nothing AndAlso Cell.Image.PageCount > 1
      End Sub

      Private Sub newtoolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles newtoolStripMenuItem.Click
         Dim dlgNew As New NewDatasetDlg(_DataSet)

         If dlgNew.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
            Clear()
            Using wait As New WaitCursor()
               _DataSet.Initialize(dlgNew.Class, dlgNew.Flags)
               propertyGridDataSet.DataSet = _DataSet
               Text = Messager.Caption
               _Filename = String.Empty
            End Using
         End If
      End Sub

      Private Sub addTagsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles addTagsToolStripMenuItem.Click
         Dim tags As List(Of Long) = propertyGridDataSet.ShowTagSelectionDialog()

         If tags.Count > 0 Then
            propertyGridDataSet.AddTags(tags)
         End If
      End Sub

      Private Sub fileToolStripMenuItem_DropDownOpening(ByVal sender As Object, ByVal e As EventArgs) Handles fileToolStripMenuItem.DropDownOpening
         saveAsToolStripMenuItem.Enabled = _DataSet.GetFirstElement(Nothing, False, True) IsNot Nothing
         saveToolStripMenuItem.Enabled = _DataSet.GetFirstElement(Nothing, False, True) IsNot Nothing AndAlso Not String.IsNullOrEmpty(_Filename)
      End Sub

      Private Sub saveToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles saveToolStripMenuItem.Click
         Dim oldFile As String = _Filename

         If String.IsNullOrEmpty(_Filename) Then
            Dim sf As New SaveFileDialog()

            sf.Filter = "DCM File(*.dcm)|*.dcm|All files (*.*)|*.*"
            sf.AddExtension = True
            sf.Title = "Save Dicom File"

            If sf.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
               _Filename = sf.FileName
            End If
         End If

         Try
            _DataSet.Save(_Filename, DicomDataSetSaveFlags.None)
            Text = Messager.Caption & " : " & _Filename
         Catch de As DicomException
            Dim err As String = String.Format("Error saving dicom dataset!" & Constants.vbCrLf & Constants.vbCrLf & "{0}", de.Code.ToString())

            _Filename = oldFile
            MessageBox.Show(err, "Error")
            Return
         End Try
      End Sub

      Private Sub saveAsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles saveAsToolStripMenuItem.Click
         If String.IsNullOrEmpty(_Filename) Then
            saveToolStripMenuItem_Click(saveToolStripMenuItem, e)
         Else
            Dim sf As New SaveFileDialog()

            sf.Filter = "DCM File(*.dcm)|*.dcm|All files (*.*)|*.*"
            sf.AddExtension = True
            sf.Title = "Save Dicom File As"
            sf.FileName = _Filename

            If sf.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
               Try
                  _DataSet.Save(sf.FileName, DicomDataSetSaveFlags.None)
                  _Filename = sf.FileName
                  Text = Messager.Caption & " : " & _Filename
               Catch de As DicomException
                  Dim err As String = String.Format("Error saving dicom dataset!" & Constants.vbCrLf & Constants.vbCrLf & "{0}", de.Code.ToString())

                  MessageBox.Show(err, "Error")
                  Return
               End Try
            End If
         End If
      End Sub

      Private Sub aboutToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles aboutToolStripMenuItem.Click
         Using aboutDialog As New AboutDialog("DICOM Editor", ProgrammingInterface.VB)
            aboutDialog.ShowDialog(Me)
         End Using
      End Sub

      Private Sub propertyGridDataSet_BeforeAddElement(ByVal sender As Object, ByVal e As BeforeAddElementEventArgs) Handles propertyGridDataSet.BeforeAddElement
         If CellHasImage() Then
            If e.Element.DicomElement.Tag = DicomTag.PatientID AndAlso e.Element.Value IsNot Nothing Then
               SetUserTag(0, MedicalViewerTagAlignment.TopLeft, "PID: " & e.Element.Value)
            End If

            If e.Element.DicomElement.Tag = DicomTag.PatientName AndAlso e.Element.Value IsNot Nothing Then
               SetUserTag(1, MedicalViewerTagAlignment.TopLeft, e.Element.Value)
            End If
         End If

         If _DataSet IsNot Nothing Then
            If _DataSet.IsVolatileElement(e.Element.DicomElement) Then
               e.Element.Attributes.Add(New ReadOnlyAttribute(True))
            End If
         End If
      End Sub

      Private Sub propertyGridDataSet_PropertyInfo(ByVal sender As Object, ByVal e As PropertyInfoEventArgs)
         e.PropertyImageInfo.Add(New PropertyImageInfo())
      End Sub

      Private Sub propertyGridDataSet_PropertyValueChanged(ByVal s As Object, ByVal e As PropertyValueChangedEventArgs) Handles propertyGridDataSet.PropertyValueChanged
         Dim pd As DicomEditablePropertyDescriptor = TryCast(e.ChangedItem.PropertyDescriptor, DicomEditablePropertyDescriptor)

         If pd IsNot Nothing Then
            If pd.Element.Tag = DicomTag.PixelData Then
               Dim image As RasterImage = TryCast(pd.GetValue(Nothing), RasterImage)

               If image IsNot Nothing Then
                  LoadImage(image)
               End If
            End If

            If pd.Element.Tag = DicomTag.PatientName Then
               If pd.Element.Tag = DicomTag.PatientName AndAlso pd.GetValue(Nothing) IsNot Nothing Then
                  SetUserTag(1, MedicalViewerTagAlignment.TopLeft, pd.GetValue(Nothing))
               End If
            End If
         End If
      End Sub

      Private Sub SetUserTag(ByVal row As Integer, ByVal align As MedicalViewerTagAlignment, ByVal value As Object)
         Cell.SetTag(row, align, MedicalViewerTagType.UserData, If(value IsNot Nothing, value.ToString(), CStr(value)))
      End Sub

      Private Function CellHasImage() As Boolean
         Return Cell.Image IsNot Nothing
      End Function

      Private Sub Clear()
         Cell.Image = Nothing
         SetUserTag(2, MedicalViewerTagAlignment.BottomLeft, String.Empty)
         SetUserTag(0, MedicalViewerTagAlignment.TopRight, String.Empty)
         SetUserTag(0, MedicalViewerTagAlignment.TopLeft, String.Empty)
         SetUserTag(1, MedicalViewerTagAlignment.TopLeft, String.Empty)
      End Sub

      Private Sub animationToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles animationToolStripMenuItem.Click
         Dim dlgAnimation As New AnimationDialog(_MedicalViewer)

         dlgAnimation.ShowDialog(Me)
      End Sub

      Private Sub readOnlyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles readOnlyToolStripMenuItem.Click
         propertyGridDataSet.ReadOnly = Not propertyGridDataSet.ReadOnly
      End Sub

      Private Sub deleteTagToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles deleteTagToolStripMenuItem.Click
         propertyGridDataSet.DeleteTag()
      End Sub

      Private Sub addItemToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles addItemToolStripMenuItem.Click
         propertyGridDataSet.AddSequenceItem()
      End Sub
   End Class
End Namespace
