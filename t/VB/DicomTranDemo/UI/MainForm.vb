' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports Leadtools.Dicom
Imports Leadtools.DicomDemos

Namespace DicomTranDemo
   Partial Public Class MainForm : Inherits Form
      Public LEAD_IMPLEMENTATION_CLASS_UID As String = "1.2.840.114257.0.1"
      Public LEAD_IMPLEMENTATION_VERSION_NAME As String = "LEADTOOLS Demo"
      Private m_J2KOptions As DicomJpeg2000Options

      Public Sub New()
         InitializeComponent()
      End Sub

      Private Sub InFile_Click(ByVal sender As Object, ByVal e As EventArgs) Handles InFile.Click
         Dim dlg As OpenFileDialog = New OpenFileDialog()
         dlg.Filter = "DICOM Files (*.dic;*.dcm)|*.dic;*.dcm|All files (*.*)|*.*||"
         dlg.FilterIndex = 1
         dlg.FileName = txtInFile.Text

         If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            txtInFile.Text = dlg.FileName
         End If
      End Sub

      Private Sub OutFile_Click(ByVal sender As Object, ByVal e As EventArgs) Handles OutFile.Click
         Dim dlg As SaveFileDialog = New SaveFileDialog()
         dlg.Filter = "DCM Files (*.dcm)|*.dcm||"
         dlg.FilterIndex = 1
         dlg.FileName = txtInFile.Text

         If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
            txtOutFile.Text = dlg.FileName
         End If
      End Sub

      Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
         DicomEngine.Startup()
         Dim DummyDS As DicomDataSet = New DicomDataSet()
         m_J2KOptions = DummyDS.Jpeg2000Options

         AddUID(DicomUidType.ImplicitVRLittleEndian, "Implicit VR Little Endian (1.2.840.10008.1.2)")
         AddUID(DicomUidType.ExplicitVRLittleEndian, "Explicit VR Little Endian (1.2.840.10008.1.2.1)")
         AddUID(DicomUidType.ExplicitVRBigEndian, "Explicit VR Big Endian (1.2.840.10008.1.2.2)")
         AddUID(DicomUidType.RLELossless, "RLE Lossless (1.2.840.10008.1.2.5)")
         AddUID(DicomUidType.JPEGBaseline1, "JPEG Baseline (Process 1) (1.2.840.10008.1.2.4.50)")
         AddUID(DicomUidType.JPEGExtended2_4, "JPEG Extended (Process 2 & 4) (1.2.840.10008.1.2.4.51)")
         AddUID(DicomUidType.JPEGLosslessNonhier14, "JPEG Lossless, Non-Hierarchical (Process 14) (1.2.840.10008.1.2.4.57)")
         AddUID(DicomUidType.JPEGLosslessNonhier14B, "JPEG Lossless, Non-Hierarchical,First-Order Prediction (1.2.840.10008.1.2.4.70)")
#If LEADTOOLS_V175_OR_LATER Then
         AddUID(DicomUidType.JPEGLSLossless, "JPEG-LS Lossless (1.2.840.10008.1.2.4.80)")
         AddUID(DicomUidType.JPEGLSLossy, "JPEG-LS Lossy (1.2.840.10008.1.2.4.81)")
#End If
         AddUID(DicomUidType.JPEG2000LosslessOnly, "JPEG 2000 Lossless Only (1.2.840.10008.1.2.4.90)")
         AddUID(DicomUidType.JPEG2000, "JPEG 2000 (1.2.840.10008.1.2.4.91)")
#If LEADTOOLS_V19_OR_LATER Then
         AddUID(DicomUidType.JPEG2000Part2MultiComponentImageCompressionLosslessOnly, "JPEG 2000 Part2, Multi Component Image Compression Lossless Only (1.2.840.10008.1.2.4.92)")
         AddUID(DicomUidType.JPEG2000Part2MultiComponentImageCompression, "JPEG 2000 Part2, Multi Component Image Compression (1.2.840.10008.1.2.4.93)")
#End If

         cmbTransferSyntax.SelectedIndex = 0
         J2kOptionsBtn.Enabled = False
         txtQFactor.Enabled = False
         txtQFactor.Text = "2"
      End Sub

      Private Sub AddUID(ByVal uid As String, ByVal description As String)
         Dim xferSyntax As MyTransferSyntax = New MyTransferSyntax()
         xferSyntax.szUID = uid
         xferSyntax.szDescription = description
         cmbTransferSyntax.Items.Add(xferSyntax)
      End Sub

      Private Sub UpdateOptions()
         Dim uid As String = (CType(cmbTransferSyntax.Items(cmbTransferSyntax.SelectedIndex), MyTransferSyntax)).szUID
         Dim enable As Boolean = (uid = DicomUidType.RLELossless) OrElse (uid = DicomUidType.ImplicitVRLittleEndian) OrElse (uid = DicomUidType.ExplicitVRLittleEndian) OrElse (uid = DicomUidType.ExplicitVRBigEndian)

         checkBoxYbrFull.Enabled = enable
         If (Not enable) Then
            checkBoxYbrFull.Checked = False
         End If

         Dim showYbrOptions As Boolean = False
#If LEADTOOLS_V175_OR_LATER Then
         showYbrOptions = True
#End If
         checkBoxYbrFull.Visible = showYbrOptions
         labelYbrFull.Visible = showYbrOptions
      End Sub

      Private Shared Function IsUidJpeg2000(ByVal uid As String) As Boolean
         Dim isJpeg2000 As Boolean
         Select Case uid
            Case DicomUidType.JPEG2000, DicomUidType.JPEG2000LosslessOnly, DicomUidType.JPEG2000Part2MultiComponentImageCompressionLosslessOnly, DicomUidType.JPEG2000Part2MultiComponentImageCompression
               isJpeg2000 = True
            Case Else
               isJpeg2000 = False
         End Select
         Return isJpeg2000
      End Function

      Private Shared Function IsUidUsingQFactor(ByVal uid As String) As Boolean
         Dim isUsingQFactor As Boolean
         Select Case uid
            Case DicomUidType.JPEGBaseline1, DicomUidType.JPEGExtended2_4, DicomUidType.JPEG2000, DicomUidType.JPEG2000Part2MultiComponentImageCompression
               isUsingQFactor = True
            Case Else
               isUsingQFactor = False
         End Select
         Return isUsingQFactor
      End Function

      Private Sub cmbTransferSyntax_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cmbTransferSyntax.SelectedIndexChanged
         ' Get desired transfer syntax    
         Dim uid As String = (CType(cmbTransferSyntax.Items(cmbTransferSyntax.SelectedIndex), MyTransferSyntax)).szUID

         txtQFactor.Enabled = IsUidUsingQFactor(uid)
         J2kOptionsBtn.Enabled = IsUidJpeg2000(uid)

         UpdateOptions()
      End Sub

      Private Sub Change_Click(ByVal sender As Object, ByVal e As EventArgs) Handles Change.Click
         ' Some sanity checks !
         If txtInFile.Text.Length = 0 Then
            MessageBox.Show("Please enter a valid input file name ")
            Return
         End If

         If (Not System.IO.File.Exists(txtInFile.Text)) Then
            MessageBox.Show("Please enter a valid input file name ")
            Return
         End If

         If txtOutFile.Text.Length = 0 Then
            MessageBox.Show("Please enter a valid output file name ")
            Return
         End If
         If txtInFile.Text = txtOutFile.Text Then
            MessageBox.Show("Input and output file names can't be the same!")
            Return
         End If

         Dim saveFlags As DicomDataSetSaveFlags = (DicomDataSetSaveFlags.MetaHeaderPresent Or DicomDataSetSaveFlags.GroupLengths)

         ' Get desired transfer syntax 
         Dim uid As String = (CType(cmbTransferSyntax.Items(cmbTransferSyntax.SelectedIndex), MyTransferSyntax)).szUID
         Dim nQFactor As Integer
         If IsUidUsingQFactor(uid) Then
            nQFactor = Convert.ToInt16(txtQFactor.Text)
            If (nQFactor < 2 OrElse nQFactor > 255) AndAlso (nQFactor <> 0) Then
               Dim message As String = "Please enter a valid quality factor:" & Constants.vbCrLf & Constants.vbTab & " 0 (lossless)" & Constants.vbCrLf & Constants.vbTab & " 2 (lossy highest quality) to 255 (lossy most compression)"

               MessageBox.Show(message, "Please enter a valid quality factor.")
               Return
            End If
         Else
            nQFactor = 0
         End If

         'Load input dataset
         DicomEngine.Startup()
         Dim DicomDs As DicomDataSet = New DicomDataSet()
         DicomDs.Reset()
         Try
            DicomDs.Load(txtInFile.Text, 0)
         Catch ex As Exception
            MessageBox.Show(ex.Message, "Failed to load the Dataset!")
            Return
         End Try
         If IsUidJpeg2000(uid) Then
            ' Setting JPEG 2000 options 
            DicomDs.Jpeg2000Options = m_J2KOptions
         End If

         ' Ensure that the DICOM File Meta Information is added
         CheckFileMetaInfo(DicomDs)

         'Change dataset to desired transfer syntax
         Try
            Dim flags As ChangeTransferSyntaxFlags = ChangeTransferSyntaxFlags.None
#If LEADTOOLS_V175_OR_LATER Then
            If checkBoxYbrFull.Checked Then
               flags = flags Or ChangeTransferSyntaxFlags.YbrFull
            End If
#End If

#If LEADTOOLS_V19_OR_LATER Then
            DicomDs.ChangeTransferSyntax(txtOutFile.Text, uid, nQFactor, flags, saveFlags)
#Else
			DicomDs.ChangeTransferSyntax(uid, nQFactor, flags)
#End If
         Catch ex As Exception
            Dim errorString As String = ex.Message.ToLower()
            If errorString.Contains("parameter") Then
               Const strErr As String = "Failed to change dataset transfer syntax." & Constants.vbLf & "Possible cause:"" Bits Allocated"" for source dataset doesn't match desired ""Transfer Syntax""."
               MessageBox.Show(strErr, "Failed to change dataset transfer syntax.", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
               MessageBox.Show(ex.Message, "LEAD Error")
            End If

            Return
         End Try

#If (Not LEADTOOLS_V19_OR_LATER) Then
		 ' Save dataset!
		 Try
			DicomDs.Save(txtOutFile.Text, saveFlags)
		 Catch ex As Exception
			MessageBox.Show(ex.Message, "Failed to save dataset")
			Return
		 End Try
#End If ' #if !LEADTOOLS_V19_OR_LATER

         DicomEngine.Shutdown()
         MessageBox.Show("Conversion Succeeded", "SUCCESS")

         'this.Cursor = Cursors.WaitCursor;
         'this.Cursor = Cursors.Arrow;
      End Sub
      Private Sub CheckFileMetaInfo(ByVal ds As DicomDataSet)
         Dim Element, Temp As DicomElement
         Dim szValue As String

         ' File Meta Information Version
         Element = ds.FindFirstElement(Nothing, DemoDicomTags.FileMetaInformationVersion, False)
         If Element Is Nothing Then
            Element = ds.InsertElement(Nothing, False, DemoDicomTags.FileMetaInformationVersion, DicomVRType.UN, False, 0)
         End If
         If Not Element Is Nothing Then
            Dim Values As Byte() = New Byte(1) {}
            Values(0) = &H0
            Values(1) = &H1

            ds.SetByteValue(Element, Values, 2)
         End If

         ' Media Storage SOP Class UID
         Element = ds.FindFirstElement(Nothing, DemoDicomTags.MediaStorageSOPClassUID, False)
         If Element Is Nothing Then
            Element = ds.InsertElement(Nothing, False, DemoDicomTags.MediaStorageSOPClassUID, DicomVRType.UN, False, 0)
         End If
         If Not Element Is Nothing Then
            Temp = ds.FindFirstElement(Nothing, DemoDicomTags.SOPClassUID, False)
            If Not Temp Is Nothing Then
               szValue = ds.GetStringValue(Temp, 0)
               If szValue <> String.Empty Then
                  ds.SetStringValue(Element, szValue, DicomCharacterSetType.Default)
               End If
            End If
         End If

         ' Media Storage SOP Instance UID
         Element = ds.FindFirstElement(Nothing, DemoDicomTags.MediaStorageSOPInstanceUID, False)
         If Element Is Nothing Then
            Element = ds.InsertElement(Nothing, False, DemoDicomTags.MediaStorageSOPInstanceUID, DicomVRType.UN, False, 0)
         End If
         If Not Element Is Nothing Then
            Temp = ds.FindFirstElement(Nothing, DemoDicomTags.SOPInstanceUID, False)
            If Not Temp Is Nothing Then
               szValue = ds.GetStringValue(Temp, 0)
               If szValue <> String.Empty Then
                  ds.SetStringValue(Element, szValue, DicomCharacterSetType.Default)
               End If
            End If
         End If

         ' Implementation Class UID
         Element = ds.FindFirstElement(Nothing, DemoDicomTags.ImplementationClassUID, False)
         If Element Is Nothing Then
            Element = ds.InsertElement(Nothing, False, DemoDicomTags.ImplementationClassUID, DicomVRType.UN, False, 0)
         End If
         If Not Element Is Nothing Then
            ds.SetStringValue(Element, LEAD_IMPLEMENTATION_CLASS_UID, DicomCharacterSetType.Default)
         End If

         ' Implementation Version Name
         Element = ds.FindFirstElement(Nothing, DemoDicomTags.ImplementationVersionName, False)
         If Element Is Nothing Then
            Element = ds.InsertElement(Nothing, False, DemoDicomTags.ImplementationVersionName, DicomVRType.UN, False, 0)
         End If
         If Not Element Is Nothing Then
            ds.SetStringValue(Element, LEAD_IMPLEMENTATION_VERSION_NAME, DicomCharacterSetType.Default)
         End If
      End Sub

      Private Sub J2kOptionsBtn_Click(ByVal sender As Object, ByVal e As EventArgs) Handles J2kOptionsBtn.Click
         Dim DummyDS As DicomDataSet = New DicomDataSet()
         Dim J2KOptionsDlg As J2kOptDlg = New J2kOptDlg()

         DummyDS.Jpeg2000Options = m_J2KOptions
         J2KOptionsDlg.m_DS = DummyDS
         J2KOptionsDlg.m_nQFactor = System.Convert.ToInt16(txtQFactor.Text)

         Dim uid As String = (CType(cmbTransferSyntax.Items(cmbTransferSyntax.SelectedIndex), MyTransferSyntax)).szUID
         If uid = DicomUidType.JPEG2000LosslessOnly Then
            J2KOptionsDlg.m_bLossless = True
         End If
         J2KOptionsDlg.ShowDialog()
         m_J2KOptions = DummyDS.Jpeg2000Options
      End Sub

      Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
         DicomEngine.Shutdown()
      End Sub
   End Class
End Namespace
