' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************
Imports Leadtools
Imports Leadtools.Codecs

Public Class TxtOptionsControl
   Implements IOptionsUserControl

   Private _fontSize As Integer

   ''' <summary>
   ''' Called by the owner to initialize
   ''' </summary>
   Public Sub SetData(ByVal rasterCodecsInstance As RasterCodecs) Implements IOptionsUserControl.SetData
      AddHandler _fontSizeComboBox.PreviewKeyDown, AddressOf _textBox_PreviewKeyDown
      AddHandler _fontSizeComboBox.LostFocus, AddressOf _fontSizeComboBox_LostFocus

      Using g As Graphics = CreateGraphics()
         Dim fontFamilies() As FontFamily = FontFamily.GetFamilies(g)

         For Each ff As FontFamily In fontFamilies
            _fontNameComboBox.Items.Add(ff.Name)
         Next
      End Using

      ' Set the state of the controls

      Dim txtLoadOptions As CodecsTxtLoadOptions = rasterCodecsInstance.Options.Txt.Load

      _enabledCheckBox.Checked = txtLoadOptions.Enabled
      _useSystenLocaleCheckBox.Checked = txtLoadOptions.UseSystemLocale

      _fontSize = txtLoadOptions.FontSize
      _fontNameComboBox.Text = txtLoadOptions.FaceName
      _fontSizeComboBox.Text = _fontSize.ToString()
      _fontBoldCheckBox.Checked = txtLoadOptions.Bold
      _fontItalicCheckBox.Checked = txtLoadOptions.Italic
      _fontUnderlineCheckBox.Checked = txtLoadOptions.Underline
      _fontStrikethroughCheckBox.Checked = txtLoadOptions.Strikethrough

      _fontColorPanel.BackColor = Leadtools.Demos.Converters.ToGdiPlusColor(txtLoadOptions.FontColor)
      _backColorPanel.BackColor = Leadtools.Demos.Converters.ToGdiPlusColor(txtLoadOptions.BackColor)
      _highlightColorPanel.BackColor = Leadtools.Demos.Converters.ToGdiPlusColor(txtLoadOptions.Highlight)
   End Sub

   ''' <summary>
   ''' Called by the owner to get the data
   ''' </summary>
   Public Function GetData(ByVal rasterCodecsInstance As RasterCodecs) As Boolean Implements IOptionsUserControl.GetData
      If Not GetFontSize() Then
         Return False
      End If

      Dim txtLoadOptions As CodecsTxtLoadOptions = rasterCodecsInstance.Options.Txt.Load

      ' Get the TXT load settings

      txtLoadOptions.Enabled = _enabledCheckBox.Checked
      txtLoadOptions.UseSystemLocale = _useSystenLocaleCheckBox.Checked

      txtLoadOptions.FaceName = _fontNameComboBox.Text
      txtLoadOptions.FontSize = _fontSize

      txtLoadOptions.Bold = _fontBoldCheckBox.Checked
      txtLoadOptions.Italic = _fontItalicCheckBox.Checked
      txtLoadOptions.Underline = _fontUnderlineCheckBox.Checked
      txtLoadOptions.Strikethrough = _fontStrikethroughCheckBox.Checked

      txtLoadOptions.FontColor = Leadtools.Demos.Converters.FromGdiPlusColor(_fontColorPanel.BackColor)
      txtLoadOptions.BackColor = Leadtools.Demos.Converters.FromGdiPlusColor(_backColorPanel.BackColor)
      txtLoadOptions.Highlight = Leadtools.Demos.Converters.FromGdiPlusColor(_highlightColorPanel.BackColor)

      Return True
   End Function

   Private Sub _textBox_PreviewKeyDown(ByVal sender As Object, ByVal e As PreviewKeyDownEventArgs)
      If (e.KeyCode = Keys.Enter) AndAlso (e.Modifiers = Keys.None) Then
         e.IsInputKey = True
      End If
   End Sub

   Private Sub _fontSizeComboBox_LostFocus(ByVal sender As Object, ByVal e As EventArgs)
      _fontSizeComboBox.Text = _fontSize.ToString()
   End Sub

   Private Sub _fontSizeComboBox_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _fontSizeComboBox.SelectedIndexChanged
      GetFontSize()
   End Sub

   Private Sub _fontSizeComboBox_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles _fontSizeComboBox.KeyPress
      If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.Return) Then
         ' User has pressed enter, get the new resolution

         If GetFontSize() Then
            GetNextControl(CType(sender, Control), True).Focus()
         End If
      End If
   End Sub

   Private Function GetFontSize() As Boolean
      ' Check the new value
      Dim fontSize As Integer

      Const minFontSize As Integer = 1
      Const maxFontSize As Integer = 200

      Dim errorMessage As String = String.Format("Font size must be a value between {0} and {1}", minFontSize, maxFontSize)

      If Not Integer.TryParse(_fontSizeComboBox.Text, fontSize) Then
         Messager.ShowWarning(Me, errorMessage)
         _fontSizeComboBox.Focus()
         Return False
      End If

      If (fontSize < minFontSize) OrElse (fontSize > maxFontSize) Then
         Messager.ShowWarning(Me, errorMessage)
         _fontSizeComboBox.Focus()
         Return False
      End If

      _fontSize = fontSize
      Return True
   End Function

   Private Sub _fontColorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _fontColorButton.Click
      Using dlg As New ColorDialog()
         dlg.Color = _fontColorPanel.BackColor
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            _fontColorPanel.BackColor = dlg.Color
         End If
      End Using
   End Sub

   Private Sub _backColorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _backColorButton.Click
      Using dlg As New ColorDialog()
         dlg.Color = _backColorPanel.BackColor
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            _backColorPanel.BackColor = dlg.Color
         End If
      End Using
   End Sub

   Private Sub _highlightColorButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _highlightColorButton.Click
      Using dlg As New ColorDialog()
         dlg.Color = _highlightColorPanel.BackColor
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            _highlightColorPanel.BackColor = dlg.Color
         End If
      End Using
   End Sub

   Private Sub _resetToDefaultsButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles _resetToDefaultsButton.Click
      _enabledCheckBox.Checked = False
      _useSystenLocaleCheckBox.Checked = False

      _fontSize = 12
      _fontNameComboBox.Text = "Courier New"
      _fontSizeComboBox.Text = _fontSize.ToString()
      _fontBoldCheckBox.Checked = False
      _fontItalicCheckBox.Checked = False
      _fontUnderlineCheckBox.Checked = False
      _fontStrikethroughCheckBox.Checked = False

      _fontColorPanel.BackColor = Color.Black
      _backColorPanel.BackColor = Color.White
      _highlightColorPanel.BackColor = Color.White
   End Sub
End Class
