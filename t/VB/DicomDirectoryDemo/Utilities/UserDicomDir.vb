' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Microsoft.VisualBasic
Imports System.Windows.Forms
Imports Leadtools.Dicom

Namespace DicomDemo
   Public Class UserDicomDir : Inherits DicomDir
      ' Private members
      Private m_txtStatus As TextBox
      Private m_nAddedDicomFilesCount As Integer

      ' Constructors
      Public Sub New()
         MyBase.New()
         m_nAddedDicomFilesCount = 0
      End Sub

      Public Shadows Sub Reset(ByVal destinationFolder As String)
         m_nAddedDicomFilesCount = 0

         MyBase.Reset(destinationFolder)
      End Sub

      Public Shadows Sub Load(ByVal name As String, ByVal flags As DicomDataSetLoadFlags)

         MyBase.Load(name, flags)
      End Sub

      Public Sub SetStatus(ByVal status As String)
         If m_txtStatus IsNot Nothing Then
            m_txtStatus.Text = status
         End If
      End Sub

      Public Overrides Function OnInsertFile(ByVal fileName As String, ByVal ds As DicomDataSet, ByVal status As DicomDirInsertFileStatus, ByVal code As DicomExceptionCode) As DicomDirInsertFileCommand
         If MainForm.cancel Then
            SetStatus("Cancelled")
            Return DicomDirInsertFileCommand.Stop
         End If

         If status = DicomDirInsertFileStatus.PreAdd Then
            ' About to add the DICOM file
            If ds.InformationClass = DicomClassType.BasicDirectory Then
               Return DicomDirInsertFileCommand.Skip
            Else
               SetStatus(String.Format("Status: Adding the file ""{0}""", fileName))
            End If

         ElseIf status = DicomDirInsertFileStatus.Success Then
            ' The DICOM file has been added successfully
            m_nAddedDicomFilesCount += 1
         Else ' Failure
            Dim dlgRes As DialogResult = MessageBox.Show("Invalid File Id: " & fileName & vbLf & " Do you want to skip this file and continue?", "Error", MessageBoxButtons.YesNo)
            If dlgRes = DialogResult.Yes Then
               Return DicomDirInsertFileCommand.Skip
            Else
               Return DicomDirInsertFileCommand.Stop
            End If
         End If

			Application.DoEvents()
			Return DicomDirInsertFileCommand.Continue
		End Function

        ' Returns the number of Dicom files added to the DicomDir
        Public Function GetAddedDicomFilesCount() As Integer
            Return m_nAddedDicomFilesCount
        End Function

        ' Sets the TextBox on which it can write its status
        Public Sub SetStatusTextBox(ByRef t As TextBox)
            m_txtStatus = t
        End Sub
	End Class
End Namespace
