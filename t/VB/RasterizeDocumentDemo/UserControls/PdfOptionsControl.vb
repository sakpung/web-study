' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Leadtools
Imports Leadtools.Codecs

Public Class PdfOptionsControl
   Implements IOptionsUserControl

   ''' <summary>
   ''' Called by the owner to initialize
   ''' </summary>
   Public Sub SetData(ByVal rasterCodecsInstance As RasterCodecs) Implements IOptionsUserControl.SetData
      ' First fill the controls with possible values

      _displayDepthComboBox.Items.Add(New ValueNameItem(Of Integer)(1, "1 bits per pixel"))
      _displayDepthComboBox.Items.Add(New ValueNameItem(Of Integer)(4, "4 bits per pixel"))
      _displayDepthComboBox.Items.Add(New ValueNameItem(Of Integer)(8, "8 bits per pixel"))
      _displayDepthComboBox.Items.Add(New ValueNameItem(Of Integer)(24, "24 bits per pixel"))

      _textAlphaComboBox.Items.Add(New ValueNameItem(Of Integer)(1, "Do not use font anti-aliasing"))
      _textAlphaComboBox.Items.Add(New ValueNameItem(Of Integer)(2, "Use 2-bit font anti-aliasing"))
      _textAlphaComboBox.Items.Add(New ValueNameItem(Of Integer)(4, "Use 4-bit font anti-aliasing"))

      _graphicsAlphaComboBox.Items.Add(New ValueNameItem(Of Integer)(1, "Do not use graphics anti-aliasing"))
      _graphicsAlphaComboBox.Items.Add(New ValueNameItem(Of Integer)(2, "Use 2-bit graphics anti-aliasing"))
      _graphicsAlphaComboBox.Items.Add(New ValueNameItem(Of Integer)(4, "Use 4-bit graphics anti-aliasing"))

      ' Now set the state of the controls

      Dim pdfLoadOptions As CodecsPdfLoadOptions = rasterCodecsInstance.Options.Pdf.Load

      _useLibFontsCheckBox.Checked = pdfLoadOptions.UseLibFonts
      _displayDepthComboBox.SelectedItem = ValueNameItem(Of Integer).SelectItem(pdfLoadOptions.DisplayDepth, _displayDepthComboBox.Items)
      _textAlphaComboBox.SelectedItem = ValueNameItem(Of Integer).SelectItem(pdfLoadOptions.TextAlpha, _textAlphaComboBox.Items)
      _graphicsAlphaComboBox.SelectedItem = ValueNameItem(Of Integer).SelectItem(pdfLoadOptions.GraphicsAlpha, _graphicsAlphaComboBox.Items)
      _disableCroppingCheckBox.Checked = pdfLoadOptions.DisableCropping
      _displayCieColorsCheckBox.Checked = pdfLoadOptions.DisableCieColors
      _passwordTextBox.Text = pdfLoadOptions.Password
   End Sub

   ''' <summary>
   ''' Called by the owner to get the data
   ''' </summary>
   Public Function GetData(ByVal rasterCodecsInstance As RasterCodecs) As Boolean Implements IOptionsUserControl.GetData
      Dim pdfLoadOptions As CodecsPdfLoadOptions = rasterCodecsInstance.Options.Pdf.Load
      ' Get the PDF load settings
      pdfLoadOptions.UseLibFonts = _useLibFontsCheckBox.Checked
      If _displayDepthComboBox.SelectedItem IsNot Nothing Then
         pdfLoadOptions.DisplayDepth = ValueNameItem(Of Integer).GetSelectedItem(_displayDepthComboBox.SelectedItem)
      End If
      pdfLoadOptions.TextAlpha = ValueNameItem(Of Integer).GetSelectedItem(_textAlphaComboBox.SelectedItem)
      pdfLoadOptions.GraphicsAlpha = ValueNameItem(Of Integer).GetSelectedItem(_graphicsAlphaComboBox.SelectedItem)
      pdfLoadOptions.DisableCropping = _disableCroppingCheckBox.Checked
      pdfLoadOptions.DisableCieColors = _displayCieColorsCheckBox.Checked
      pdfLoadOptions.Password = _passwordTextBox.Text

      Return True
   End Function

   Private Sub _resetToDefaultsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _resetToDefaultsButton.Click
      ' Reset all to default values
      _useLibFontsCheckBox.Checked = True
      _displayDepthComboBox.SelectedItem = ValueNameItem(Of Integer).SelectItem(24, _displayDepthComboBox.Items)
      _textAlphaComboBox.SelectedItem = ValueNameItem(Of Integer).SelectItem(4, _textAlphaComboBox.Items)
      _graphicsAlphaComboBox.SelectedItem = ValueNameItem(Of Integer).SelectItem(1, _graphicsAlphaComboBox.Items)
      _disableCroppingCheckBox.Checked = False
      _displayCieColorsCheckBox.Checked = False
      _passwordTextBox.Text = String.Empty
   End Sub
End Class
