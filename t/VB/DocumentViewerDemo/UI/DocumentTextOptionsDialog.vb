Imports System
Imports Leadtools.Document

Public Class DocumentTextOptionsDialog

   Public Property ImagesRecognitionMode As DocumentTextImagesRecognitionMode
   Public Property TextExtractionMode As DocumentTextExtractionMode

   Structure ComboBoxItem
      Public Value As Object
      Public FriendlyName As String
      Public Overrides Function ToString() As String
         Return FriendlyName
      End Function
   End Structure

   Protected Overrides Sub OnLoad(e As EventArgs)
      If Not DesignMode Then
         Dim x As New ComboBoxItem With {.Value = DocumentTextImagesRecognitionMode.Auto, .FriendlyName = "Auto"}

         Dim imagesRecognitionModeItems() As ComboBoxItem =
         {
            New ComboBoxItem With {.Value = DocumentTextImagesRecognitionMode.Auto, .FriendlyName = "Auto"},
            New ComboBoxItem With {.Value = DocumentTextImagesRecognitionMode.Disabled, .FriendlyName = "Disabled"},
            New ComboBoxItem With {.Value = DocumentTextImagesRecognitionMode.Always, .FriendlyName = "Always"}
         }

         For Each ComboBoxItem As ComboBoxItem In imagesRecognitionModeItems
            _imagesRecognitionModeComboBox.Items.Add(ComboBoxItem)
            If (Me.ImagesRecognitionMode = CType(ComboBoxItem.Value, DocumentTextImagesRecognitionMode)) Then
               _imagesRecognitionModeComboBox.SelectedItem = ComboBoxItem
            End If
         Next

         Dim textExtractionModeItems() As ComboBoxItem =
         {
            New ComboBoxItem With {.Value = DocumentTextExtractionMode.Auto, .FriendlyName = "Auto"},
            New ComboBoxItem With {.Value = DocumentTextExtractionMode.SvgOnly, .FriendlyName = "SVG only"},
            New ComboBoxItem With {.Value = DocumentTextExtractionMode.OcrOnly, .FriendlyName = "OCR only"}
         }

         For Each comboBoxItem As ComboBoxItem In textExtractionModeItems
            _textExtractionModeComboBox.Items.Add(comboBoxItem)
            If (Me.TextExtractionMode = CType(comboBoxItem.Value, DocumentTextExtractionMode)) Then
               _textExtractionModeComboBox.SelectedItem = comboBoxItem
            End If
         Next
      End If

      MyBase.OnLoad(e)
   End Sub

   Private Sub _okButton_Click(sender As Object, e As System.EventArgs) Handles _okButton.Click
      Me.ImagesRecognitionMode = CType(CType(_imagesRecognitionModeComboBox.SelectedItem, ComboBoxItem).Value, DocumentTextImagesRecognitionMode)
      Me.TextExtractionMode = CType(CType(_textExtractionModeComboBox.SelectedItem, ComboBoxItem).Value, DocumentTextExtractionMode)
   End Sub
End Class