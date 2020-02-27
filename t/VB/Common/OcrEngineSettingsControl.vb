' *************************************************************
' Copyright (c) 1991-2019 LEAD Technologies, Inc.              
' All Rights Reserved.                                         
' *************************************************************

Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Data
Imports System.Text
Imports System.Windows.Forms

Imports Leadtools
Imports Leadtools.Ocr
Imports System

Partial Public Class OcrEngineSettingsControl
   Inherits UserControl
   Public Sub New()
      InitializeComponent()
   End Sub

   Private _ocrEngine As IOcrEngine

   Public Sub SetEngine(engine As IOcrEngine)
      _ocrEngine = engine

      _tvCategories.BeginUpdate()

      ' Clear the old settings
      _tvCategories.Nodes.Clear()

      ' Get all the settings
      Dim settingNames As String() = _ocrEngine.SettingManager.GetSettingNames()

      Dim currentCatrgoryNode As TreeNode = Nothing

      For Each settingName As String In settingNames
         Dim settingDescriptor As IOcrSettingDescriptor = _ocrEngine.SettingManager.GetSettingDescriptor(settingName)

         If settingDescriptor.ValueType = OcrSettingValueType.BeginCategory Then
            Dim catrgoryNode As New TreeNode(settingDescriptor.FriendlyName)

            If currentCatrgoryNode IsNot Nothing Then
               currentCatrgoryNode.Nodes.Add(catrgoryNode)
            Else
               _tvCategories.Nodes.Add(catrgoryNode)
            End If

            catrgoryNode.Tag = Nothing

            currentCatrgoryNode = catrgoryNode
         ElseIf settingDescriptor.ValueType = OcrSettingValueType.EndCategory Then
            currentCatrgoryNode = currentCatrgoryNode.Parent
         Else
            Dim settingNode As New TreeNode(settingDescriptor.FriendlyName)
            settingNode.Tag = settingName
            currentCatrgoryNode.Nodes.Add(settingNode)
         End If
      Next

      _tvCategories.ExpandAll()

      _tvCategories.EndUpdate()
   End Sub

   Private Sub _tvCategories_AfterSelect(sender As Object, e As TreeViewEventArgs)
      ShowCurrentSetting()
   End Sub

   Private Sub ShowCurrentSetting()
      _pnlSettings.Controls.Clear()

      If _tvCategories.SelectedNode IsNot Nothing Then
         If _tvCategories.SelectedNode.Tag IsNot Nothing Then
            ' Get the setting
            Dim settingName As String = _tvCategories.SelectedNode.Tag.ToString()
            Dim settingDescriptor As IOcrSettingDescriptor = _ocrEngine.SettingManager.GetSettingDescriptor(settingName)

            ' Add a control for it
            Select Case settingDescriptor.ValueType
               Case OcrSettingValueType.[Integer]
                  AddIntegerSetting(settingDescriptor)
                  Exit Select

               Case OcrSettingValueType.[Enum]
                  If settingDescriptor.EnumIsFlags Then
                     AddEnumFlagsSetting(settingDescriptor)
                  Else
                     AddEnumSetting(settingDescriptor)
                  End If
                  Exit Select

               Case OcrSettingValueType.[Double]
                  AddDoubleSetting(settingDescriptor)
                  Exit Select

               Case OcrSettingValueType.[Boolean]
                  AddBooleanSetting(settingDescriptor)
                  Exit Select

               Case OcrSettingValueType.Character
                  AddCharacterSetting(settingDescriptor)
                  Exit Select

               Case OcrSettingValueType.[String]
                  AddStringSetting(settingDescriptor)
                  Exit Select
               Case Else

                  Exit Select
            End Select
         End If
      End If
   End Sub

   Private Const _edge As Integer = 6

   Private Sub AddIntegerSetting(settingDescriptor As IOcrSettingDescriptor)
      Dim lbl As New Label()
      lbl.AutoSize = True
      lbl.TextAlign = ContentAlignment.MiddleLeft
      lbl.Text = settingDescriptor.Units
      lbl.Location = New Point(_edge, _edge)
      _pnlSettings.Controls.Add(lbl)

      Dim tb As New TextBox()
      tb.Width = _pnlSettings.ClientSize.Width - lbl.Width - _edge * 3
      tb.Location = New Point(lbl.Right + _edge, _edge)
      tb.Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Right
      _pnlSettings.Controls.Add(tb)

      lbl.Top = CInt(tb.Top + (tb.Height - lbl.Height) / 2)

      tb.Text = _ocrEngine.SettingManager.GetIntegerValue(settingDescriptor.Name).ToString()
      tb.Tag = settingDescriptor.Name
      AddHandler tb.LostFocus, AddressOf IntegerTextBox_LostFocus
   End Sub

   Private Sub IntegerTextBox_LostFocus(sender As Object, e As EventArgs)
      If _ocrEngine Is Nothing OrElse Not _ocrEngine.IsStarted Then
         Return
      End If

      Dim tb As TextBox = TryCast(sender, TextBox)
      Dim settingName As String = tb.Tag.ToString()

      Dim valueOk As Boolean = True

      Dim value As Integer
      If Not Integer.TryParse(tb.Text, value) Then
         valueOk = False
      End If

      If valueOk Then
         Dim settingDescriptor As IOcrSettingDescriptor = _ocrEngine.SettingManager.GetSettingDescriptor(settingName)
         If value < settingDescriptor.IntegerMinimumValue Then
            valueOk = False
            MessageBox.Show(Me, String.Format("Value must be a value greater than or equal to " & settingDescriptor.IntegerMinimumValue), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         ElseIf value > settingDescriptor.IntegerMaximumValue Then
            valueOk = False
            MessageBox.Show(Me, String.Format("Value must be a value less than or equal to " & settingDescriptor.IntegerMaximumValue), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         End If
      End If

      If valueOk Then
         SetSettingValue(settingName, value.ToString())
      Else
         tb.Text = _ocrEngine.SettingManager.GetIntegerValue(settingName).ToString()
         tb.Focus()
      End If
   End Sub

   Private Sub AddDoubleSetting(settingDescriptor As IOcrSettingDescriptor)
      Dim lbl As New Label()
      lbl.AutoSize = True
      lbl.TextAlign = ContentAlignment.MiddleLeft
      lbl.Text = settingDescriptor.Units
      lbl.Location = New Point(_edge, _edge)
      _pnlSettings.Controls.Add(lbl)

      Dim tb As New TextBox()
      tb.Width = _pnlSettings.ClientSize.Width - lbl.Width - _edge * 3
      tb.Location = New Point(lbl.Right + _edge, _edge)
      tb.Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Right
      _pnlSettings.Controls.Add(tb)

      lbl.Top = CInt(tb.Top + (tb.Height - lbl.Height) / 2)

      tb.Text = _ocrEngine.SettingManager.GetDoubleValue(settingDescriptor.Name).ToString()
      tb.Tag = settingDescriptor.Name
      AddHandler tb.LostFocus, AddressOf DoubleTextBox_LostFocus
   End Sub

   Private Sub DoubleTextBox_LostFocus(sender As Object, e As EventArgs)
      If _ocrEngine Is Nothing OrElse Not _ocrEngine.IsStarted Then
         Return
      End If

      Dim tb As TextBox = TryCast(sender, TextBox)
      Dim settingName As String = tb.Tag.ToString()

      Dim valueOk As Boolean = True

      Dim value As Double
      If Not Double.TryParse(tb.Text, value) Then
         valueOk = False
      End If

      If valueOk Then
         Dim settingDescriptor As IOcrSettingDescriptor = _ocrEngine.SettingManager.GetSettingDescriptor(settingName)
         If value < settingDescriptor.DoubleMinimumValue Then
            valueOk = False
            MessageBox.Show(Me, String.Format("Value must be a value greater than or equal to " & settingDescriptor.IntegerMinimumValue), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         ElseIf value > settingDescriptor.DoubleMaximumValue Then
            valueOk = False
            MessageBox.Show(Me, String.Format("Value must be a value less than or equal to " & settingDescriptor.IntegerMaximumValue), "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
         End If
      End If

      If valueOk Then
         SetSettingValue(settingName, value.ToString())
      Else
         tb.Text = _ocrEngine.SettingManager.GetDoubleValue(settingName).ToString()
         tb.Focus()
      End If
   End Sub

   Private Sub AddBooleanSetting(settingDescriptor As IOcrSettingDescriptor)
      Dim cb As New ComboBox()
      cb.DropDownStyle = ComboBoxStyle.DropDownList
      cb.Width = _pnlSettings.ClientSize.Width - _edge * 2
      cb.Location = New Point(_edge, _edge)
      cb.Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Right
      _pnlSettings.Controls.Add(cb)

      cb.Items.Add(True)
      cb.Items.Add(False)

      cb.SelectedItem = _ocrEngine.SettingManager.GetBooleanValue(settingDescriptor.Name)
      cb.Tag = settingDescriptor.Name
      AddHandler cb.SelectedIndexChanged, AddressOf BooleanCheckBox_SelectedIndexChanged
   End Sub

   Private Sub BooleanCheckBox_SelectedIndexChanged(sender As Object, e As EventArgs)
      If _ocrEngine Is Nothing OrElse Not _ocrEngine.IsStarted Then
         Return
      End If

      Dim cb As ComboBox = TryCast(sender, ComboBox)
      Dim settingName As String = cb.Tag.ToString()
      SetSettingValue(settingName, cb.SelectedItem.ToString())
   End Sub

   Private Sub AddEnumFlagsSetting(settingDescriptor As IOcrSettingDescriptor)
      Dim clb As New CheckedListBox()
      clb.CheckOnClick = True
      clb.Location = New Point(_edge, _edge)
      clb.Size = New Size(_pnlSettings.ClientSize.Width - _edge * 2, _pnlSettings.ClientSize.Height - _edge * 2)
      clb.Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Right Or AnchorStyles.Bottom
      _pnlSettings.Controls.Add(clb)

      Dim memberNames As String() = settingDescriptor.GetEnumMemberFriendlyNames()
      Dim memberValues As Integer() = settingDescriptor.GetEnumMemberValues()

      Dim value As Integer = _ocrEngine.SettingManager.GetEnumValue(settingDescriptor.Name)

      For i As Integer = 0 To memberNames.Length - 1
         Dim memberValue As Integer = memberValues(i)
         If memberValue <> 0 Then
            Dim index As Integer = clb.Items.Add(memberNames(i))

            If (memberValue And value) = memberValue Then
               clb.SetItemChecked(index, True)
            End If
         End If
      Next

      clb.Tag = settingDescriptor.Name
      AddHandler clb.ItemCheck, AddressOf EnumFlagsCheckedListBox_ItemCheck
   End Sub

   Private Sub EnumFlagsCheckedListBox_ItemCheck(sender As Object, e As ItemCheckEventArgs)
      If _ocrEngine Is Nothing OrElse Not _ocrEngine.IsStarted Then
         Return
      End If

      Dim clb As CheckedListBox = TryCast(sender, CheckedListBox)

      Dim settingName As String = clb.Tag.ToString()

      Dim sb As New StringBuilder()

      For i As Integer = 0 To clb.Items.Count - 1
         If i <> e.Index Then
            If clb.GetItemChecked(i) Then
               sb.Append(clb.Items(i).ToString() & ", ")
            End If
         ElseIf e.NewValue = CheckState.Checked Then
            sb.Append(clb.Items(i).ToString() & ", ")
         End If
      Next

      If sb.Length > 0 Then
         sb.Remove(sb.Length - 2, 2)
      End If

      SetSettingValue(settingName, sb.ToString())
   End Sub

   Private Sub AddEnumSetting(settingDescriptor As IOcrSettingDescriptor)
      Dim cb As New ComboBox()
      cb.DropDownStyle = ComboBoxStyle.DropDownList
      cb.Width = _pnlSettings.ClientSize.Width - _edge * 2
      cb.Location = New Point(_edge, _edge)
      cb.Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Right
      _pnlSettings.Controls.Add(cb)

      cb.SelectedItem = _ocrEngine.SettingManager.GetValue(settingDescriptor.Name)

      Dim members As String() = settingDescriptor.GetEnumMemberFriendlyNames()

      For Each member As String In members
         cb.Items.Add(member)
      Next

      Dim value As Integer = _ocrEngine.SettingManager.GetEnumValue(settingDescriptor.Name)
      cb.SelectedIndex = value
      cb.Tag = settingDescriptor.Name
      AddHandler cb.SelectedIndexChanged, AddressOf EnumComboBox_SelectedIndexChanged
   End Sub

   Private Sub EnumComboBox_SelectedIndexChanged(sender As Object, e As EventArgs)
      If _ocrEngine Is Nothing OrElse Not _ocrEngine.IsStarted Then
         Return
      End If

      Dim cb As ComboBox = TryCast(sender, ComboBox)
      Dim settingName As String = cb.Tag.ToString()
      SetSettingValue(settingName, cb.SelectedItem.ToString())
   End Sub

   Private Sub AddCharacterSetting(settingDescriptor As IOcrSettingDescriptor)
      Dim tb As New TextBox()
      tb.Width = _pnlSettings.ClientSize.Width - _edge * 2
      tb.Location = New Point(_edge, _edge)
      tb.Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Right
      tb.MaxLength = 1
      tb.Font = New System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
      _pnlSettings.Controls.Add(tb)

      tb.Text = _ocrEngine.SettingManager.GetCharacterValue(settingDescriptor.Name).ToString()
      tb.Tag = settingDescriptor.Name
      AddHandler tb.LostFocus, AddressOf CharacterTextBox_LostFocus
   End Sub

   Private Sub CharacterTextBox_LostFocus(sender As Object, e As EventArgs)
      If _ocrEngine Is Nothing OrElse Not _ocrEngine.IsStarted Then
         Return
      End If

      Dim tb As TextBox = TryCast(sender, TextBox)
      Dim settingName As String = tb.Tag.ToString()

      Dim valueOk As Boolean = True

      Dim value As Char
      If Not Char.TryParse(tb.Text, value) Then
         valueOk = False
      End If

      If valueOk Then
         SetSettingValue(settingName, value.ToString())
      Else
         tb.Text = _ocrEngine.SettingManager.GetCharacterValue(settingName).ToString()
         tb.Focus()
      End If
   End Sub

   Private Sub AddStringSetting(settingDescriptor As IOcrSettingDescriptor)
      Dim tb As New TextBox()
      tb.Width = _pnlSettings.ClientSize.Width - _edge * 2
      tb.Location = New Point(_edge, _edge)
      tb.Anchor = AnchorStyles.Left Or AnchorStyles.Top Or AnchorStyles.Right
      tb.Font = New System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CByte(0))
      If settingDescriptor.StringMaximumLength <> -1 Then
         tb.MaxLength = settingDescriptor.StringMaximumLength
      End If
      _pnlSettings.Controls.Add(tb)

      tb.Text = _ocrEngine.SettingManager.GetStringValue(settingDescriptor.Name)
      tb.Tag = settingDescriptor.Name
      AddHandler tb.LostFocus, AddressOf StringTextBox_LostFocus
   End Sub

   Private Sub StringTextBox_LostFocus(sender As Object, e As EventArgs)
      If _ocrEngine Is Nothing OrElse Not _ocrEngine.IsStarted Then
         Return
      End If

      Dim tb As TextBox = TryCast(sender, TextBox)
      Dim settingName As String = tb.Tag.ToString()

      Dim valueOk As Boolean = True

      Dim value As String = tb.Text

      If valueOk Then
         Dim settingDescriptor As IOcrSettingDescriptor = _ocrEngine.SettingManager.GetSettingDescriptor(settingName)
         If settingDescriptor.StringNullAllowed AndAlso value.Length = 0 Then
            value = Nothing
         End If
      End If

      If valueOk Then
         SetSettingValue(settingName, value)
      Else
         tb.Text = _ocrEngine.SettingManager.GetStringValue(settingName)
         tb.Focus()
      End If
   End Sub

   Private Sub SetSettingValue(settingName As String, value As String)
      Try
         _ocrEngine.SettingManager.SetValue(settingName, value)
      Catch ex As Exception
         ShowError(ex)
      End Try
   End Sub

   Private Sub ShowError(ex As Exception)
      ' Shows an error, check if the exception is an OCR, raster or general one
      Dim ocr As OcrException = TryCast(ex, OcrException)
      If ocr IsNot Nothing Then
         Messager.ShowError(Me, String.Format("OCR Error&#13;&#13;Code: {0}&#13;&#13;{1}", ocr.Code, ocr.Message))
         Return
      End If

#If LEADTOOLS_V175_OR_LATER Then
      Dim ocrComponent As OcrComponentMissingException = TryCast(ex, OcrComponentMissingException)
      If ocrComponent IsNot Nothing Then
         Messager.ShowError(Me, String.Format("OCR Component Missing\n\n{0}\n\nUse 'Engine/Componets' from the menu to show the available components and instructions of how to install the additional components of this OCR engine.", ocrComponent.Message))
         Return
      End If
#End If

      Dim raster As RasterException = TryCast(ex, RasterException)
      If raster IsNot Nothing Then
         Messager.ShowError(Me, String.Format("LEADTOOLS Error&#13;&#13;Code: {0}&#13;&#13;{1}", raster.Code, raster.Message))
         Return
      End If

      Messager.ShowError(Me, ex)
   End Sub

   Private Sub OcrEngineSettingsControl_Resize(sender As Object, e As EventArgs)
      _tvCategories.Size = New Size(_pnlSettings.Location.X - _tvCategories.Location.X - _edge, ClientRectangle.Bottom)
      _pnlSettings.Size = New Size(ClientRectangle.Right - _pnlSettings.Location.X - _edge, ClientRectangle.Bottom)
   End Sub

   Private Sub _btnLoad_Click(sender As Object, e As EventArgs)
      Using dlg As New OpenFileDialog()
         dlg.Filter = "OCR engine settings (*.xml)|*.xml|All files|*.*"
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            Try
               _ocrEngine.SettingManager.Load(dlg.FileName)
            Catch ex As Exception
               ShowError(ex)
            Finally
               ShowCurrentSetting()
            End Try
         End If
      End Using
   End Sub

   Private Sub _btnSave_Click(sender As Object, e As EventArgs)
      Using dlg As New SaveFileDialog()
         dlg.Filter = "OCR engine settings (*.xml)|*.xml|All files|*.*"
         If dlg.ShowDialog(Me) = DialogResult.OK Then
            Try
               _ocrEngine.SettingManager.Save(dlg.FileName)
            Catch ex As Exception
               ShowError(ex)
            End Try
         End If
      End Using
   End Sub
End Class
