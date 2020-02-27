' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Leadtools.Ocr

Public Class OcrOmrOptionsDialog

   Private _omrOptions As IOcrOmrOptions

   Sub New(ByVal ocrEngine As IOcrEngine)

      ' This call is required by the Windows Form Designer.
      InitializeComponent()

      ' Add any initialization after the InitializeComponent() call.
      ' Get the OMR options object
      _omrOptions = ocrEngine.ZoneManager.OmrOptions

      Dim a As System.Array = System.Enum.GetValues(GetType(OcrOmrFrameDetectionMethod))
      For Each i As OcrOmrFrameDetectionMethod In a
         _frameDetectionMethodComboBox.Items.Add(i)
      Next

      _frameDetectionMethodComboBox.SelectedItem = _omrOptions.FrameDetectionMethod

      a = System.Enum.GetValues(GetType(OcrOmrSensitivity))
      For Each i As OcrOmrSensitivity In a
         _sensitivityComboBox.Items.Add(i)
      Next

      _sensitivityComboBox.SelectedItem = _omrOptions.Sensitivity

      Dim unfilledCharacter As Char = _omrOptions.GetStateRecognitionCharacter(OcrOmrZoneState.Unfilled)
      _unfilledStateCharacterTextBox.Text = New String(unfilledCharacter, 1)

      Dim filledCharacter As Char = _omrOptions.GetStateRecognitionCharacter(OcrOmrZoneState.Filled)
      _filledStateCharacterTextBox.Text = New String(filledCharacter, 1)
   End Sub

   Private Sub _okButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _okButton.Click
      Dim frameDetectionMethod As OcrOmrFrameDetectionMethod = CType(_frameDetectionMethodComboBox.SelectedItem, OcrOmrFrameDetectionMethod)
      Dim sensitivity As OcrOmrSensitivity = CType(_sensitivityComboBox.SelectedItem, OcrOmrSensitivity)

      Dim unfilledCharacter As Char
      If Not String.IsNullOrEmpty(_unfilledStateCharacterTextBox.Text) Then
         unfilledCharacter = _unfilledStateCharacterTextBox.Text(0)
      Else
         unfilledCharacter = " "c
      End If

      Dim filledCharacter As Char
      If Not String.IsNullOrEmpty(_filledStateCharacterTextBox.Text) Then
         filledCharacter = _filledStateCharacterTextBox.Text(0)
      Else
         filledCharacter = " "c
      End If

      _omrOptions.FrameDetectionMethod = frameDetectionMethod
      _omrOptions.Sensitivity = sensitivity
      _omrOptions.SetStateRecognitionCharacter(OcrOmrZoneState.Unfilled, unfilledCharacter)
      _omrOptions.SetStateRecognitionCharacter(OcrOmrZoneState.Filled, filledCharacter)
   End Sub
End Class
