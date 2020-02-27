' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Leadtools
Imports Leadtools.Codecs

Public Class RasterizeDocumentOptionsControl
   Implements IOptionsUserControl

   ' The temporary CodecsRasterizeDocumentLoadOptions options to use
   Public _pageWidth As Double
   Public _pageHeight As Double
   Private _leftMargin As Double
   Private _topMargin As Double
   Private _rightMargin As Double
   Private _bottomMargin As Double
   Private _unit As CodecsRasterizeDocumentUnit
   Private _resolution As Integer
   Private _sizeMode As CodecsRasterizeDocumentSizeMode

   ''' <summary>
   ''' Called by the owner to initialize
   ''' </summary>
   Public Sub SetData(ByVal rasterCodecsInstance As RasterCodecs) Implements IOptionsUserControl.SetData
      ' Set the state of the controls

      ' Event hooks
      AddHandler _pageWidthTextBox.PreviewKeyDown, AddressOf _textBox_PreviewKeyDown
      AddHandler _pageWidthTextBox.LostFocus, AddressOf _textBox_LostFocus

      AddHandler _pageHeightTextBox.PreviewKeyDown, AddressOf _textBox_PreviewKeyDown
      AddHandler _pageHeightTextBox.LostFocus, AddressOf _textBox_LostFocus

      AddHandler _leftMarginTextBox.PreviewKeyDown, AddressOf _textBox_PreviewKeyDown
      AddHandler _leftMarginTextBox.LostFocus, AddressOf _textBox_LostFocus

      AddHandler _topMarginTextBox.PreviewKeyDown, AddressOf _textBox_PreviewKeyDown
      AddHandler _topMarginTextBox.LostFocus, AddressOf _textBox_LostFocus

      AddHandler _rightMarginTextBox.PreviewKeyDown, AddressOf _textBox_PreviewKeyDown
      AddHandler _rightMarginTextBox.LostFocus, AddressOf _textBox_LostFocus

      AddHandler _bottomMarginTextBox.PreviewKeyDown, AddressOf _textBox_PreviewKeyDown
      AddHandler _bottomMarginTextBox.LostFocus, AddressOf _textBox_LostFocus

      AddHandler _resolutionComboBox.PreviewKeyDown, AddressOf _textBox_PreviewKeyDown
      AddHandler _resolutionComboBox.LostFocus, AddressOf _resolutionComboBox_LostFocus

      ' Initialize the units
      _unitComboBox.Items.Add(New ValueNameItem(Of CodecsRasterizeDocumentUnit)(CodecsRasterizeDocumentUnit.Pixel, "Pixel"))
      _unitComboBox.Items.Add(New ValueNameItem(Of CodecsRasterizeDocumentUnit)(CodecsRasterizeDocumentUnit.Inch, "Inch"))
      _unitComboBox.Items.Add(New ValueNameItem(Of CodecsRasterizeDocumentUnit)(CodecsRasterizeDocumentUnit.Millimeter, "Millimeter"))

      _sizeModeComboBox.Items.Add(New ValueNameItem(Of CodecsRasterizeDocumentSizeMode)(CodecsRasterizeDocumentSizeMode.None, "None"))
      _sizeModeComboBox.Items.Add(New ValueNameItem(Of CodecsRasterizeDocumentSizeMode)(CodecsRasterizeDocumentSizeMode.Fit, "Fit"))
      _sizeModeComboBox.Items.Add(New ValueNameItem(Of CodecsRasterizeDocumentSizeMode)(CodecsRasterizeDocumentSizeMode.FitAlways, "Fit always"))
      _sizeModeComboBox.Items.Add(New ValueNameItem(Of CodecsRasterizeDocumentSizeMode)(CodecsRasterizeDocumentSizeMode.FitWidth, "Fit width"))
      _sizeModeComboBox.Items.Add(New ValueNameItem(Of CodecsRasterizeDocumentSizeMode)(CodecsRasterizeDocumentSizeMode.Stretch, "Stretch"))

      Dim rasterizeDocumentLoadOptions As CodecsRasterizeDocumentLoadOptions = rasterCodecsInstance.Options.RasterizeDocument.Load

      ' Get the temporary values
      _pageWidth = rasterizeDocumentLoadOptions.PageWidth
      _pageHeight = rasterizeDocumentLoadOptions.PageHeight
      _leftMargin = rasterizeDocumentLoadOptions.LeftMargin
      _topMargin = rasterizeDocumentLoadOptions.TopMargin
      _rightMargin = rasterizeDocumentLoadOptions.RightMargin
      _bottomMargin = rasterizeDocumentLoadOptions.BottomMargin
      _unit = rasterizeDocumentLoadOptions.Unit
      _resolution = rasterizeDocumentLoadOptions.XResolution
      _sizeMode = rasterizeDocumentLoadOptions.SizeMode

      ' Now set the current values

      UpdateControlsFromValues()

      UpdateUIState()
   End Sub

   ''' <summary>
   ''' Called by the owner to get the data
   ''' </summary>
   Public Function GetData(ByVal rasterCodecsInstance As RasterCodecs) As Boolean Implements IOptionsUserControl.GetData
      Dim ret As Boolean = True

      Dim rasterizeDocumentLoadOptions As CodecsRasterizeDocumentLoadOptions = rasterCodecsInstance.Options.RasterizeDocument.Load

      ' Get the rasterize document load settings

      If ret Then
         ret = GetResolution()
      End If

      If ret Then
         Dim valuesTextBox() As TextBox = _
         { _
            _pageWidthTextBox, _
            _pageHeightTextBox, _
            _leftMarginTextBox, _
            _topMarginTextBox, _
            _rightMarginTextBox, _
            _bottomMarginTextBox _
         }

         For i As Integer = 0 To valuesTextBox.Length - 1
            ret = GetTextBoxValue(valuesTextBox(i))
         Next
      End If

      If ret Then
         ' Everything is ok, update the options
         rasterizeDocumentLoadOptions.PageWidth = _pageWidth
         rasterizeDocumentLoadOptions.PageHeight = _pageHeight
         rasterizeDocumentLoadOptions.LeftMargin = _leftMargin
         rasterizeDocumentLoadOptions.TopMargin = _topMargin
         rasterizeDocumentLoadOptions.RightMargin = _rightMargin
         rasterizeDocumentLoadOptions.BottomMargin = _bottomMargin
         rasterizeDocumentLoadOptions.Unit = _unit
         rasterizeDocumentLoadOptions.XResolution = _resolution
         rasterizeDocumentLoadOptions.YResolution = _resolution
         rasterizeDocumentLoadOptions.SizeMode = _sizeMode
      End If

      Return ret
   End Function

   Private Sub _textBox_PreviewKeyDown(ByVal sender As Object, ByVal e As PreviewKeyDownEventArgs)
      If (e.KeyCode = Keys.Enter) AndAlso (e.Modifiers = Keys.None) Then
         e.IsInputKey = True
      End If
   End Sub

   Private Sub _resolutionComboBox_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
      _resolutionComboBox.Text = _resolution.ToString()
   End Sub

   Private Sub _resolutionComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _resolutionComboBox.SelectedIndexChanged
      GetResolution()
   End Sub

   Private Sub _resolutionComboBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _resolutionComboBox.KeyPress
      If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
         ' User has pressed enter, get the new resolution

         If GetResolution() Then
            GetNextControl(CType(sender, Control), True).Focus()
         End If
      End If
   End Sub

   Private Function GetResolution() As Boolean
      ' Check the new value
      Dim resolution As Integer

      Const minResolution As Integer = 10
      Const maxResolution As Integer = 4800

      Dim errorMessage As String = String.Format("Resolution must be a value between {0} and {1}", minResolution, maxResolution)

      If Not Integer.TryParse(_resolutionComboBox.Text, resolution) Then
         Messager.ShowWarning(Me, errorMessage)
         _resolutionComboBox.Focus()
         Return False
      End If

      ' A value of 0 is valid, means screen resolution
      If (resolution <> 0) AndAlso (resolution < minResolution OrElse resolution > maxResolution) Then
         Messager.ShowWarning(Me, errorMessage)
         _resolutionComboBox.Focus()
         Return False
      End If

      _resolution = resolution
      Return True
   End Function

   Private Sub _textBox_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
      If sender Is _pageWidthTextBox Then
         _pageWidthTextBox.Text = _pageWidth.ToString("0.00")
      ElseIf sender Is _pageHeightTextBox Then
         _pageHeightTextBox.Text = _pageHeight.ToString("0.00")
      ElseIf sender Is _leftMarginTextBox Then
         _leftMarginTextBox.Text = _leftMargin.ToString("0.00")
      ElseIf sender Is _topMarginTextBox Then
         _topMarginTextBox.Text = _topMargin.ToString("0.00")
      ElseIf sender Is _rightMarginTextBox Then
         _rightMarginTextBox.Text = _rightMargin.ToString("0.00")
      ElseIf sender Is _bottomMarginTextBox Then
         _bottomMarginTextBox.Text = _bottomMargin.ToString("0.00")
      End If
   End Sub

   Private Sub _textBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _topMarginTextBox.KeyPress, _rightMarginTextBox.KeyPress, _pageWidthTextBox.KeyPress, _pageHeightTextBox.KeyPress, _leftMarginTextBox.KeyPress, _bottomMarginTextBox.KeyPress
      If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
         ' User has pressed enter, get the new width

         If GetTextBoxValue(CType(sender, TextBox)) Then
            GetNextControl(CType(sender, Control), True).Focus()
         End If
      End If
   End Sub

   Private Function GetTextBoxValue(ByVal tb As TextBox) As Boolean
      ' Check the new value
      Dim value As Single

      Dim errorMessage As String
      Dim isLength As Boolean

      If (tb Is _pageWidthTextBox) OrElse (tb Is _pageHeightTextBox) Then
         errorMessage = "Page width or height must be value greater than zero"
         isLength = True
      Else
         errorMessage = "Margin must be value greater than or equal to zero"
         isLength = False
      End If

      If Not Single.TryParse(tb.Text, value) Then
         Messager.ShowWarning(Me, errorMessage)
         tb.Focus()
         Return False
      End If

      If (isLength AndAlso value <= 0) OrElse (Not isLength AndAlso value < 0) Then
         Messager.ShowWarning(Me, errorMessage)
         tb.Focus()
         Return False
      End If

      If (tb Is _pageWidthTextBox) Then
         _pageWidth = value
      ElseIf (tb Is _pageHeightTextBox) Then
         _pageHeight = value
      ElseIf (tb Is _leftMarginTextBox) Then
         _leftMargin = value
      ElseIf (tb Is _topMarginTextBox) Then
         _topMargin = value
      ElseIf (tb Is _rightMarginTextBox) Then
         _rightMargin = value
      ElseIf (tb Is _bottomMarginTextBox) Then
         _bottomMargin = value
      End If

      Return True
   End Function

   Private Sub _unitComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _unitComboBox.SelectedIndexChanged
      ' Save the old unit so we can do the converstion
      Dim newUnit As CodecsRasterizeDocumentUnit = ValueNameItem(Of CodecsRasterizeDocumentUnit).GetSelectedItem(_unitComboBox.SelectedItem)

      Dim resolution As Integer = _resolution

      If resolution = 0 Then
         resolution = Units.ScreenResolution
      End If

      ' Re-calculate the width and height and margins with new units

      _pageWidth = Units.Convert(_pageWidth, _unit, resolution, newUnit)
      _pageHeight = Units.Convert(_pageHeight, _unit, resolution, newUnit)
      _leftMargin = Units.Convert(_leftMargin, _unit, resolution, newUnit)
      _topMargin = Units.Convert(_topMargin, _unit, resolution, newUnit)
      _rightMargin = Units.Convert(_rightMargin, _unit, resolution, newUnit)
      _bottomMargin = Units.Convert(_bottomMargin, _unit, resolution, newUnit)

      ' Set the new unit and size
      _unit = newUnit
      _pageWidthTextBox.Text = _pageWidth.ToString("0.00")
      _pageHeightTextBox.Text = _pageHeight.ToString("0.00")
      _leftMarginTextBox.Text = _leftMargin.ToString("0.00")
      _topMarginTextBox.Text = _topMargin.ToString("0.00")
      _rightMarginTextBox.Text = _rightMargin.ToString("0.00")
      _bottomMarginTextBox.Text = _bottomMargin.ToString("0.00")
   End Sub

   Private Shared _sizeModeDescription() As String = _
   { _
      "Width and height are not used, the image will be loaded using its original size at the specified resolution.", _
      "Fit the image into the 'width' and 'height' while maintaining the aspect ratio.\n\nIf the original image dimension is smaller than 'width' and 'height', no resizing is done.\n\nThe result image dimension will be 'width' or 'height' or smaller.", _
      "Always fit the image into the 'width' and 'height' while maintaining the aspect ratio even if the original image dimension is smaller.\n\nThe result image dimension will always be 'width' or 'height'.", _
      "Fit the image width to be 'width' while maintaining the aspect ratio.\n\n'height' is not used.", _
      "Fit the image to be exactly 'width' and 'height'.\n\nAspect ratio might not be maintained." _
   }

   Private Sub _sizeModeComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _sizeModeComboBox.SelectedIndexChanged
      _sizeMode = ValueNameItem(Of CodecsRasterizeDocumentSizeMode).GetSelectedItem(_sizeModeComboBox.SelectedItem)

      ' Update the help
      _sizeModeHelp.Text = _sizeModeDescription(CType(_sizeMode, Integer))

      UpdateUIState()
   End Sub

   Private Sub _resetToDefaultsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _resetToDefaultsButton.Click
      _pageWidth = 8.5
      _pageHeight = 11
      _leftMargin = 1.25
      _topMargin = 1
      _rightMargin = 1.25
      _bottomMargin = 1
      _unit = CodecsRasterizeDocumentUnit.Inch
      _resolution = 0
      _sizeMode = CodecsRasterizeDocumentSizeMode.None

      UpdateControlsFromValues()
      UpdateUIState()
   End Sub

   Private Sub UpdateUIState()
      Dim sizeMode As CodecsRasterizeDocumentSizeMode = ValueNameItem(Of CodecsRasterizeDocumentSizeMode).GetSelectedItem(_sizeModeComboBox.SelectedItem)
      _pageWidthTextBox.Enabled = (sizeMode <> CodecsRasterizeDocumentSizeMode.None)
      _pageHeightTextBox.Enabled = (sizeMode <> CodecsRasterizeDocumentSizeMode.None) AndAlso (sizeMode <> CodecsRasterizeDocumentSizeMode.FitWidth)
      _leftMarginTextBox.Enabled = (sizeMode <> CodecsRasterizeDocumentSizeMode.None)
      _topMarginTextBox.Enabled = (sizeMode <> CodecsRasterizeDocumentSizeMode.None)
      _rightMarginTextBox.Enabled = (sizeMode <> CodecsRasterizeDocumentSizeMode.None)
      _bottomMarginTextBox.Enabled = (sizeMode <> CodecsRasterizeDocumentSizeMode.None)
      _unitComboBox.Enabled = (sizeMode <> CodecsRasterizeDocumentSizeMode.None)
   End Sub

   Private Sub UpdateControlsFromValues()
      _pageWidthTextBox.Text = _pageWidth.ToString("0.00")
      _pageHeightTextBox.Text = _pageHeight.ToString("0.00")
      _leftMarginTextBox.Text = _leftMargin.ToString("0.00")
      _topMarginTextBox.Text = _topMargin.ToString("0.00")
      _rightMarginTextBox.Text = _rightMargin.ToString("0.00")
      _bottomMarginTextBox.Text = _bottomMargin.ToString("0.00")

      _resolutionComboBox.Text = _resolution.ToString()

      _unitComboBox.SelectedItem = ValueNameItem(Of CodecsRasterizeDocumentUnit).SelectItem(_unit, _unitComboBox.Items)
      _sizeModeComboBox.SelectedItem = ValueNameItem(Of CodecsRasterizeDocumentSizeMode).SelectItem(_sizeMode, _sizeModeComboBox.Items)
   End Sub
End Class
