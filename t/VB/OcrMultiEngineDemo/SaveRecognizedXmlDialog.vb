' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Leadtools.Ocr

Public Class SaveRecognizedXmlDialog

   Private _ocrDocument As IOcrDocument

   Private Structure MyMode
      Public Name As String
      Public Options As OcrXmlOutputOptions

      Public Sub New(ByVal n As String, ByVal o As OcrXmlOutputOptions)
         Name = n
         Options = o
      End Sub

      Public Overrides Function ToString() As String
         Return Name
      End Function
   End Structure

   Public Sub New(ByVal ocrDocument As IOcrDocument)

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      _ocrDocument = ocrDocument
   End Sub

   Protected Overrides Sub OnLoad(ByVal e As System.EventArgs)
      If Not DesignMode Then
         Dim modes() As MyMode = _
         { _
            New MyMode("Save words", OcrXmlOutputOptions.None), _
            New MyMode("Save characters", OcrXmlOutputOptions.Characters), _
            New MyMode("Save characters with attributes", OcrXmlOutputOptions.Characters Or OcrXmlOutputOptions.CharacterAttributes) _
         }

         For Each mode As MyMode In modes
            _modeComboBox.Items.Add(mode)
         Next

         _modeComboBox.SelectedIndex = 0

         UpdateMyControls()
      End If

      MyBase.OnLoad(e)
   End Sub

   Private Sub UpdateMyControls()
      _okButton.Enabled = Not String.IsNullOrEmpty(_fileNameTextBox.Text.Trim())
   End Sub

   Private Sub _fileNameTextBox_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _fileNameTextBox.TextChanged
      UpdateMyControls()
   End Sub

   Private Sub _fileNameButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _fileNameButton.Click
      Using dlg As New SaveFileDialog()
         dlg.Filter = "XML Files|*.xml|All Files|*.*"
         dlg.DefaultExt = "xml"
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            _fileNameTextBox.Text = dlg.FileName
         End If
      End Using
   End Sub

   Private Sub _okButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _okButton.Click
      Try
         Using wait As New WaitCursor()
            Dim options As OcrXmlOutputOptions = CType(_modeComboBox.SelectedItem, MyMode).Options
            _ocrDocument.SaveXml(_fileNameTextBox.Text, options)

            System.Threading.Thread.Sleep(1000)
            System.Diagnostics.Process.Start(_fileNameTextBox.Text)
         End Using
      Catch ex As Exception
         MessageBox.Show(Me, ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         DialogResult = DialogResult.None
      End Try
   End Sub
End Class
