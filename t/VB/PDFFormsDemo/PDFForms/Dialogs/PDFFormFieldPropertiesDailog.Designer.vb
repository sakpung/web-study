
Namespace PDFFormsDemo
   Partial Class PDFFormFieldPropertiesDailog
      ''' <summary>
      ''' Required designer variable.
      ''' </summary>
      Private components As System.ComponentModel.IContainer = Nothing

      ''' <summary>
      ''' Clean up any resources being used.
      ''' </summary>
      ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      Protected Overrides Sub Dispose(disposing As Boolean)
         If disposing AndAlso (components IsNot Nothing) Then
            components.Dispose()
         End If
         MyBase.Dispose(disposing)
      End Sub

#Region "Windows Form Designer generated code"

      ''' <summary>
      ''' Required method for Designer support - do not modify
      ''' the contents of this method with the code editor.
      ''' </summary>
      Private Sub InitializeComponent()
         Me._propertiesTabControl = New System.Windows.Forms.TabControl()
         Me._generalTabPage = New System.Windows.Forms.TabPage()
         Me._generalCommonPropertiesGroupBox = New System.Windows.Forms.GroupBox()
         Me._generalReadOnlyCheckBox = New System.Windows.Forms.CheckBox()
         Me._generalFormFieldComboBox = New System.Windows.Forms.ComboBox()
         Me._generalReadOnlyLabel = New System.Windows.Forms.Label()
         Me._generalFormFieldLabel = New System.Windows.Forms.Label()
         Me._generalTooltipTextBox = New System.Windows.Forms.TextBox()
         Me._generalNameTextBox = New System.Windows.Forms.TextBox()
         Me._generalTooltipLabel = New System.Windows.Forms.Label()
         Me._generalNameLabel = New System.Windows.Forms.Label()
         Me._appearanceTabPage = New System.Windows.Forms.TabPage()
         Me._appearanceTextGroupBox = New System.Windows.Forms.GroupBox()
         Me._appearanceFontSizeLabel = New System.Windows.Forms.Label()
         Me._appearanceFontSizeComboBox = New System.Windows.Forms.ComboBox()
         Me._appearanceFontFamilyLabel = New System.Windows.Forms.Label()
         Me._appearanceFontFamilyComboBox = New System.Windows.Forms.ComboBox()
         Me._appearanceTextColorLabel = New System.Windows.Forms.Label()
         Me._appearanceBordersAndColorsGroupBox = New System.Windows.Forms.GroupBox()
         Me._appearanceBorderColorLabel = New System.Windows.Forms.Label()
         Me._appearanceBorderStyleComboBox = New System.Windows.Forms.ComboBox()
         Me._appearanceBorderThicknessComboBox = New System.Windows.Forms.ComboBox()
         Me._appearanceBorderStyleLabel = New System.Windows.Forms.Label()
         Me._appearanceFillColorLabel = New System.Windows.Forms.Label()
         Me._appearanceBorderThicknessLabel = New System.Windows.Forms.Label()
         Me._optionsTabPage = New System.Windows.Forms.TabPage()
         Me._bottomPanel = New System.Windows.Forms.Panel()
         Me._lockedCheckBox = New System.Windows.Forms.CheckBox()
         Me._lockedLabel = New System.Windows.Forms.Label()
         Me._okButton = New System.Windows.Forms.Button()
         Me._optionsItemsPanel = New System.Windows.Forms.Panel()
         Me._optionsMultipleSelectionCheckBox = New System.Windows.Forms.CheckBox()
         Me._optionsSortItemsCheckBox = New System.Windows.Forms.CheckBox()
         Me._optionsDownButton = New System.Windows.Forms.Button()
         Me._optionsUpButton = New System.Windows.Forms.Button()
         Me._optionsDeleteButton = New System.Windows.Forms.Button()
         Me._optionsAddItemButton = New System.Windows.Forms.Button()
         Me._optionsItemsListBox = New System.Windows.Forms.ListBox()
         Me._optionsAddItemTextBox = New System.Windows.Forms.TextBox()
         Me._optionsMultipleSelectionLabel = New System.Windows.Forms.Label()
         Me._optionsSortItemsLabel = New System.Windows.Forms.Label()
         Me._optionsItemsListLabel = New System.Windows.Forms.Label()
         Me._optionsAddItemLabel = New System.Windows.Forms.Label()
         Me._optionsTextBoxPanel = New System.Windows.Forms.Panel()
         Me._optionsMultiLineCheckBox = New System.Windows.Forms.CheckBox()
         Me._optionsAlignmentComboBox = New System.Windows.Forms.ComboBox()
         Me._optionsMultiLineLabel = New System.Windows.Forms.Label()
         Me._optionsAlignmentLabel = New System.Windows.Forms.Label()
         Me._appearanceTextColorColorPicker = New PDFFormsDemo.ColorPickerPanel()
         Me._appearanceFillColorColorPicker = New PDFFormsDemo.ColorPickerPanel()
         Me._appearanceBorderColorColorPicker = New PDFFormsDemo.ColorPickerPanel()
         Me._propertiesTabControl.SuspendLayout()
         Me._generalTabPage.SuspendLayout()
         Me._generalCommonPropertiesGroupBox.SuspendLayout()
         Me._appearanceTabPage.SuspendLayout()
         Me._appearanceTextGroupBox.SuspendLayout()
         Me._appearanceBordersAndColorsGroupBox.SuspendLayout()
         Me._optionsTabPage.SuspendLayout()
         Me._bottomPanel.SuspendLayout()
         Me._optionsItemsPanel.SuspendLayout()
         Me._optionsTextBoxPanel.SuspendLayout()
         Me.SuspendLayout()
         ' 
         ' _propertiesTabControl
         ' 
         Me._propertiesTabControl.Controls.Add(Me._generalTabPage)
         Me._propertiesTabControl.Controls.Add(Me._appearanceTabPage)
         Me._propertiesTabControl.Controls.Add(Me._optionsTabPage)
         Me._propertiesTabControl.Dock = System.Windows.Forms.DockStyle.Top
         Me._propertiesTabControl.Location = New System.Drawing.Point(0, 0)
         Me._propertiesTabControl.Name = "_propertiesTabControl"
         Me._propertiesTabControl.SelectedIndex = 0
         Me._propertiesTabControl.Size = New System.Drawing.Size(384, 257)
         Me._propertiesTabControl.TabIndex = 0
         ' 
         ' _generalTabPage
         ' 
         Me._generalTabPage.Controls.Add(Me._generalCommonPropertiesGroupBox)
         Me._generalTabPage.Controls.Add(Me._generalTooltipTextBox)
         Me._generalTabPage.Controls.Add(Me._generalNameTextBox)
         Me._generalTabPage.Controls.Add(Me._generalTooltipLabel)
         Me._generalTabPage.Controls.Add(Me._generalNameLabel)
         Me._generalTabPage.Location = New System.Drawing.Point(4, 22)
         Me._generalTabPage.Name = "_generalTabPage"
         Me._generalTabPage.Padding = New System.Windows.Forms.Padding(3)
         Me._generalTabPage.Size = New System.Drawing.Size(376, 231)
         Me._generalTabPage.TabIndex = 0
         Me._generalTabPage.Text = "General"
         Me._generalTabPage.UseVisualStyleBackColor = True
         ' 
         ' _generalCommonPropertiesGroupBox
         ' 
         Me._generalCommonPropertiesGroupBox.Controls.Add(Me._generalReadOnlyCheckBox)
         Me._generalCommonPropertiesGroupBox.Controls.Add(Me._generalFormFieldComboBox)
         Me._generalCommonPropertiesGroupBox.Controls.Add(Me._generalReadOnlyLabel)
         Me._generalCommonPropertiesGroupBox.Controls.Add(Me._generalFormFieldLabel)
         Me._generalCommonPropertiesGroupBox.Location = New System.Drawing.Point(26, 116)
         Me._generalCommonPropertiesGroupBox.Name = "_generalCommonPropertiesGroupBox"
         Me._generalCommonPropertiesGroupBox.Size = New System.Drawing.Size(325, 96)
         Me._generalCommonPropertiesGroupBox.TabIndex = 4
         Me._generalCommonPropertiesGroupBox.TabStop = False
         Me._generalCommonPropertiesGroupBox.Text = "Common Properties"
         ' 
         ' _generalReadOnlyCheckBox
         ' 
         Me._generalReadOnlyCheckBox.AutoSize = True
         Me._generalReadOnlyCheckBox.Location = New System.Drawing.Point(258, 45)
         Me._generalReadOnlyCheckBox.Name = "_generalReadOnlyCheckBox"
         Me._generalReadOnlyCheckBox.Size = New System.Drawing.Size(15, 14)
         Me._generalReadOnlyCheckBox.TabIndex = 6
         Me._generalReadOnlyCheckBox.UseVisualStyleBackColor = True
         ' 
         ' _generalFormFieldComboBox
         ' 
         Me._generalFormFieldComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._generalFormFieldComboBox.FormattingEnabled = True
         Me._generalFormFieldComboBox.Items.AddRange(New Object() {"Visible", "Hidden", "Visible but doesn't print", "Hidden but printable"})
         Me._generalFormFieldComboBox.Location = New System.Drawing.Point(78, 43)
         Me._generalFormFieldComboBox.Name = "_generalFormFieldComboBox"
         Me._generalFormFieldComboBox.Size = New System.Drawing.Size(107, 21)
         Me._generalFormFieldComboBox.TabIndex = 4
         ' 
         ' _generalReadOnlyLabel
         ' 
         Me._generalReadOnlyLabel.AutoSize = True
         Me._generalReadOnlyLabel.Location = New System.Drawing.Point(191, 46)
         Me._generalReadOnlyLabel.Name = "_generalReadOnlyLabel"
         Me._generalReadOnlyLabel.Size = New System.Drawing.Size(61, 13)
         Me._generalReadOnlyLabel.TabIndex = 2
         Me._generalReadOnlyLabel.Text = "Read Only:"
         ' 
         ' _generalFormFieldLabel
         ' 
         Me._generalFormFieldLabel.AutoSize = True
         Me._generalFormFieldLabel.Location = New System.Drawing.Point(12, 46)
         Me._generalFormFieldLabel.Name = "_generalFormFieldLabel"
         Me._generalFormFieldLabel.Size = New System.Drawing.Size(60, 13)
         Me._generalFormFieldLabel.TabIndex = 0
         Me._generalFormFieldLabel.Text = "Form Field:"
         ' 
         ' _generalTooltipTextBox
         ' 
         Me._generalTooltipTextBox.Location = New System.Drawing.Point(98, 59)
         Me._generalTooltipTextBox.Name = "_generalTooltipTextBox"
         Me._generalTooltipTextBox.Size = New System.Drawing.Size(253, 20)
         Me._generalTooltipTextBox.TabIndex = 3
         ' 
         ' _generalNameTextBox
         ' 
         Me._generalNameTextBox.Location = New System.Drawing.Point(98, 29)
         Me._generalNameTextBox.Name = "_generalNameTextBox"
         Me._generalNameTextBox.Size = New System.Drawing.Size(253, 20)
         Me._generalNameTextBox.TabIndex = 2
         ' 
         ' _generalTooltipLabel
         ' 
         Me._generalTooltipLabel.AutoSize = True
         Me._generalTooltipLabel.Location = New System.Drawing.Point(23, 62)
         Me._generalTooltipLabel.Name = "_generalTooltipLabel"
         Me._generalTooltipLabel.Size = New System.Drawing.Size(43, 13)
         Me._generalTooltipLabel.TabIndex = 1
         Me._generalTooltipLabel.Text = "Tooltip:"
         ' 
         ' _generalNameLabel
         ' 
         Me._generalNameLabel.AutoSize = True
         Me._generalNameLabel.Location = New System.Drawing.Point(28, 36)
         Me._generalNameLabel.Name = "_generalNameLabel"
         Me._generalNameLabel.Size = New System.Drawing.Size(38, 13)
         Me._generalNameLabel.TabIndex = 0
         Me._generalNameLabel.Text = "Name:"
         ' 
         ' _appearanceTabPage
         ' 
         Me._appearanceTabPage.Controls.Add(Me._appearanceTextGroupBox)
         Me._appearanceTabPage.Controls.Add(Me._appearanceBordersAndColorsGroupBox)
         Me._appearanceTabPage.Location = New System.Drawing.Point(4, 22)
         Me._appearanceTabPage.Name = "_appearanceTabPage"
         Me._appearanceTabPage.Padding = New System.Windows.Forms.Padding(3)
         Me._appearanceTabPage.Size = New System.Drawing.Size(376, 231)
         Me._appearanceTabPage.TabIndex = 1
         Me._appearanceTabPage.Text = "Appearance"
         Me._appearanceTabPage.UseVisualStyleBackColor = True
         ' 
         ' _appearanceTextGroupBox
         ' 
         Me._appearanceTextGroupBox.Controls.Add(Me._appearanceTextColorColorPicker)
         Me._appearanceTextGroupBox.Controls.Add(Me._appearanceFontSizeLabel)
         Me._appearanceTextGroupBox.Controls.Add(Me._appearanceFontSizeComboBox)
         Me._appearanceTextGroupBox.Controls.Add(Me._appearanceFontFamilyLabel)
         Me._appearanceTextGroupBox.Controls.Add(Me._appearanceFontFamilyComboBox)
         Me._appearanceTextGroupBox.Controls.Add(Me._appearanceTextColorLabel)
         Me._appearanceTextGroupBox.Location = New System.Drawing.Point(6, 110)
         Me._appearanceTextGroupBox.Name = "_appearanceTextGroupBox"
         Me._appearanceTextGroupBox.Size = New System.Drawing.Size(362, 90)
         Me._appearanceTextGroupBox.TabIndex = 14
         Me._appearanceTextGroupBox.TabStop = False
         Me._appearanceTextGroupBox.Text = "Text"
         ' 
         ' _appearanceFontSizeLabel
         ' 
         Me._appearanceFontSizeLabel.AutoSize = True
         Me._appearanceFontSizeLabel.Location = New System.Drawing.Point(19, 24)
         Me._appearanceFontSizeLabel.Name = "_appearanceFontSizeLabel"
         Me._appearanceFontSizeLabel.Size = New System.Drawing.Size(55, 13)
         Me._appearanceFontSizeLabel.TabIndex = 4
         Me._appearanceFontSizeLabel.Text = "Font Size:"
         ' 
         ' _appearanceFontSizeComboBox
         ' 
         Me._appearanceFontSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._appearanceFontSizeComboBox.FormattingEnabled = True
         Me._appearanceFontSizeComboBox.Items.AddRange(New Object() {"Auto", "6", "8", "9", "10", "12", _
          "14", "18"})
         Me._appearanceFontSizeComboBox.Location = New System.Drawing.Point(84, 21)
         Me._appearanceFontSizeComboBox.Name = "_appearanceFontSizeComboBox"
         Me._appearanceFontSizeComboBox.Size = New System.Drawing.Size(95, 21)
         Me._appearanceFontSizeComboBox.TabIndex = 7
         ' 
         ' _appearanceFontFamilyLabel
         ' 
         Me._appearanceFontFamilyLabel.AutoSize = True
         Me._appearanceFontFamilyLabel.Location = New System.Drawing.Point(8, 62)
         Me._appearanceFontFamilyLabel.Name = "_appearanceFontFamilyLabel"
         Me._appearanceFontFamilyLabel.Size = New System.Drawing.Size(66, 13)
         Me._appearanceFontFamilyLabel.TabIndex = 5
         Me._appearanceFontFamilyLabel.Text = "Font Family:"
         ' 
         ' _appearanceFontFamilyComboBox
         ' 
         Me._appearanceFontFamilyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._appearanceFontFamilyComboBox.FormattingEnabled = True
         Me._appearanceFontFamilyComboBox.Location = New System.Drawing.Point(80, 59)
         Me._appearanceFontFamilyComboBox.Name = "_appearanceFontFamilyComboBox"
         Me._appearanceFontFamilyComboBox.Size = New System.Drawing.Size(248, 21)
         Me._appearanceFontFamilyComboBox.TabIndex = 8
         ' 
         ' _appearanceTextColorLabel
         ' 
         Me._appearanceTextColorLabel.AutoSize = True
         Me._appearanceTextColorLabel.Location = New System.Drawing.Point(191, 24)
         Me._appearanceTextColorLabel.Name = "_appearanceTextColorLabel"
         Me._appearanceTextColorLabel.Size = New System.Drawing.Size(61, 13)
         Me._appearanceTextColorLabel.TabIndex = 6
         Me._appearanceTextColorLabel.Text = "Text Color:"
         ' 
         ' _appearanceBordersAndColorsGroupBox
         ' 
         Me._appearanceBordersAndColorsGroupBox.Controls.Add(Me._appearanceBorderColorLabel)
         Me._appearanceBordersAndColorsGroupBox.Controls.Add(Me._appearanceFillColorColorPicker)
         Me._appearanceBordersAndColorsGroupBox.Controls.Add(Me._appearanceBorderColorColorPicker)
         Me._appearanceBordersAndColorsGroupBox.Controls.Add(Me._appearanceBorderStyleComboBox)
         Me._appearanceBordersAndColorsGroupBox.Controls.Add(Me._appearanceBorderThicknessComboBox)
         Me._appearanceBordersAndColorsGroupBox.Controls.Add(Me._appearanceBorderStyleLabel)
         Me._appearanceBordersAndColorsGroupBox.Controls.Add(Me._appearanceFillColorLabel)
         Me._appearanceBordersAndColorsGroupBox.Controls.Add(Me._appearanceBorderThicknessLabel)
         Me._appearanceBordersAndColorsGroupBox.Location = New System.Drawing.Point(6, 7)
         Me._appearanceBordersAndColorsGroupBox.Name = "_appearanceBordersAndColorsGroupBox"
         Me._appearanceBordersAndColorsGroupBox.Size = New System.Drawing.Size(362, 97)
         Me._appearanceBordersAndColorsGroupBox.TabIndex = 13
         Me._appearanceBordersAndColorsGroupBox.TabStop = False
         Me._appearanceBordersAndColorsGroupBox.Text = "Borders and Colors"
         ' 
         ' _appearanceBorderColorLabel
         ' 
         Me._appearanceBorderColorLabel.AutoSize = True
         Me._appearanceBorderColorLabel.Location = New System.Drawing.Point(11, 24)
         Me._appearanceBorderColorLabel.Name = "_appearanceBorderColorLabel"
         Me._appearanceBorderColorLabel.Size = New System.Drawing.Size(71, 13)
         Me._appearanceBorderColorLabel.TabIndex = 0
         Me._appearanceBorderColorLabel.Text = "Border Color:"
         ' 
         ' _appearanceBorderStyleComboBox
         ' 
         Me._appearanceBorderStyleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._appearanceBorderStyleComboBox.FormattingEnabled = True
         Me._appearanceBorderStyleComboBox.Items.AddRange(New Object() {"Solid", "Dashed", "Beveled", "Inset", "Underlined"})
         Me._appearanceBorderStyleComboBox.Location = New System.Drawing.Point(258, 58)
         Me._appearanceBorderStyleComboBox.Name = "_appearanceBorderStyleComboBox"
         Me._appearanceBorderStyleComboBox.Size = New System.Drawing.Size(98, 21)
         Me._appearanceBorderStyleComboBox.TabIndex = 9
         ' 
         ' _appearanceBorderThicknessComboBox
         ' 
         Me._appearanceBorderThicknessComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._appearanceBorderThicknessComboBox.FormattingEnabled = True
         Me._appearanceBorderThicknessComboBox.Items.AddRange(New Object() {"Thin", "Medium", "Thick"})
         Me._appearanceBorderThicknessComboBox.Location = New System.Drawing.Point(258, 21)
         Me._appearanceBorderThicknessComboBox.Name = "_appearanceBorderThicknessComboBox"
         Me._appearanceBorderThicknessComboBox.Size = New System.Drawing.Size(98, 21)
         Me._appearanceBorderThicknessComboBox.TabIndex = 10
         ' 
         ' _appearanceBorderStyleLabel
         ' 
         Me._appearanceBorderStyleLabel.AutoSize = True
         Me._appearanceBorderStyleLabel.Location = New System.Drawing.Point(182, 61)
         Me._appearanceBorderStyleLabel.Name = "_appearanceBorderStyleLabel"
         Me._appearanceBorderStyleLabel.Size = New System.Drawing.Size(70, 13)
         Me._appearanceBorderStyleLabel.TabIndex = 3
         Me._appearanceBorderStyleLabel.Text = "Border Style:"
         ' 
         ' _appearanceFillColorLabel
         ' 
         Me._appearanceFillColorLabel.AutoSize = True
         Me._appearanceFillColorLabel.Location = New System.Drawing.Point(23, 61)
         Me._appearanceFillColorLabel.Name = "_appearanceFillColorLabel"
         Me._appearanceFillColorLabel.Size = New System.Drawing.Size(51, 13)
         Me._appearanceFillColorLabel.TabIndex = 1
         Me._appearanceFillColorLabel.Text = "Fill Color:"
         ' 
         ' _appearanceBorderThicknessLabel
         ' 
         Me._appearanceBorderThicknessLabel.AutoSize = True
         Me._appearanceBorderThicknessLabel.Location = New System.Drawing.Point(160, 24)
         Me._appearanceBorderThicknessLabel.Name = "_appearanceBorderThicknessLabel"
         Me._appearanceBorderThicknessLabel.Size = New System.Drawing.Size(92, 13)
         Me._appearanceBorderThicknessLabel.TabIndex = 2
         Me._appearanceBorderThicknessLabel.Text = "Border Thickness:"
         ' 
         ' _optionsTabPage
         ' 
         Me._optionsTabPage.Controls.Add(Me._optionsTextBoxPanel)
         Me._optionsTabPage.Controls.Add(Me._optionsItemsPanel)
         Me._optionsTabPage.Location = New System.Drawing.Point(4, 22)
         Me._optionsTabPage.Name = "_optionsTabPage"
         Me._optionsTabPage.Padding = New System.Windows.Forms.Padding(3)
         Me._optionsTabPage.Size = New System.Drawing.Size(376, 231)
         Me._optionsTabPage.TabIndex = 2
         Me._optionsTabPage.Text = "Options"
         Me._optionsTabPage.UseVisualStyleBackColor = True
         ' 
         ' _bottomPanel
         ' 
         Me._bottomPanel.Controls.Add(Me._lockedCheckBox)
         Me._bottomPanel.Controls.Add(Me._lockedLabel)
         Me._bottomPanel.Controls.Add(Me._okButton)
         Me._bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom
         Me._bottomPanel.Location = New System.Drawing.Point(0, 259)
         Me._bottomPanel.Name = "_bottomPanel"
         Me._bottomPanel.Size = New System.Drawing.Size(384, 44)
         Me._bottomPanel.TabIndex = 1
         ' 
         ' _lockedCheckBox
         ' 
         Me._lockedCheckBox.AutoSize = True
         Me._lockedCheckBox.Location = New System.Drawing.Point(108, 15)
         Me._lockedCheckBox.Name = "_lockedCheckBox"
         Me._lockedCheckBox.Size = New System.Drawing.Size(15, 14)
         Me._lockedCheckBox.TabIndex = 2
         Me._lockedCheckBox.UseVisualStyleBackColor = True
         ' 
         ' _lockedLabel
         ' 
         Me._lockedLabel.AutoSize = True
         Me._lockedLabel.Location = New System.Drawing.Point(58, 15)
         Me._lockedLabel.Name = "_lockedLabel"
         Me._lockedLabel.Size = New System.Drawing.Size(44, 13)
         Me._lockedLabel.TabIndex = 1
         Me._lockedLabel.Text = "Locked:"
         ' 
         ' _okButton
         ' 
         Me._okButton.DialogResult = System.Windows.Forms.DialogResult.OK
         Me._okButton.Location = New System.Drawing.Point(224, 10)
         Me._okButton.Name = "_okButton"
         Me._okButton.Size = New System.Drawing.Size(114, 23)
         Me._okButton.TabIndex = 0
         Me._okButton.Text = "Ok"
         Me._okButton.UseVisualStyleBackColor = True
         ' 
         ' _optionsItemsPanel
         ' 
         Me._optionsItemsPanel.Controls.Add(Me._optionsMultipleSelectionCheckBox)
         Me._optionsItemsPanel.Controls.Add(Me._optionsSortItemsCheckBox)
         Me._optionsItemsPanel.Controls.Add(Me._optionsDownButton)
         Me._optionsItemsPanel.Controls.Add(Me._optionsUpButton)
         Me._optionsItemsPanel.Controls.Add(Me._optionsDeleteButton)
         Me._optionsItemsPanel.Controls.Add(Me._optionsAddItemButton)
         Me._optionsItemsPanel.Controls.Add(Me._optionsItemsListBox)
         Me._optionsItemsPanel.Controls.Add(Me._optionsAddItemTextBox)
         Me._optionsItemsPanel.Controls.Add(Me._optionsMultipleSelectionLabel)
         Me._optionsItemsPanel.Controls.Add(Me._optionsSortItemsLabel)
         Me._optionsItemsPanel.Controls.Add(Me._optionsItemsListLabel)
         Me._optionsItemsPanel.Controls.Add(Me._optionsAddItemLabel)
         Me._optionsItemsPanel.Dock = System.Windows.Forms.DockStyle.Fill
         Me._optionsItemsPanel.Location = New System.Drawing.Point(3, 3)
         Me._optionsItemsPanel.Name = "_optionsItemsPanel"
         Me._optionsItemsPanel.Size = New System.Drawing.Size(370, 225)
         Me._optionsItemsPanel.TabIndex = 2
         Me._optionsItemsPanel.Visible = False
         ' 
         ' _optionsMultipleSelectionCheckBox
         ' 
         Me._optionsMultipleSelectionCheckBox.AutoSize = True
         Me._optionsMultipleSelectionCheckBox.Location = New System.Drawing.Point(99, 192)
         Me._optionsMultipleSelectionCheckBox.Name = "_optionsMultipleSelectionCheckBox"
         Me._optionsMultipleSelectionCheckBox.Size = New System.Drawing.Size(15, 14)
         Me._optionsMultipleSelectionCheckBox.TabIndex = 23
         Me._optionsMultipleSelectionCheckBox.UseVisualStyleBackColor = True
         Me._optionsMultipleSelectionCheckBox.Visible = False
         ' 
         ' _optionsSortItemsCheckBox
         ' 
         Me._optionsSortItemsCheckBox.AutoSize = True
         Me._optionsSortItemsCheckBox.Location = New System.Drawing.Point(99, 159)
         Me._optionsSortItemsCheckBox.Name = "_optionsSortItemsCheckBox"
         Me._optionsSortItemsCheckBox.Size = New System.Drawing.Size(15, 14)
         Me._optionsSortItemsCheckBox.TabIndex = 22
         Me._optionsSortItemsCheckBox.UseVisualStyleBackColor = True
         ' 
         ' _optionsDownButton
         ' 
         Me._optionsDownButton.Location = New System.Drawing.Point(292, 106)
         Me._optionsDownButton.Name = "_optionsDownButton"
         Me._optionsDownButton.Size = New System.Drawing.Size(75, 23)
         Me._optionsDownButton.TabIndex = 21
         Me._optionsDownButton.Text = "Down"
         Me._optionsDownButton.UseVisualStyleBackColor = True
         ' 
         ' _optionsUpButton
         ' 
         Me._optionsUpButton.Location = New System.Drawing.Point(292, 77)
         Me._optionsUpButton.Name = "_optionsUpButton"
         Me._optionsUpButton.Size = New System.Drawing.Size(75, 23)
         Me._optionsUpButton.TabIndex = 20
         Me._optionsUpButton.Text = "Up"
         Me._optionsUpButton.UseVisualStyleBackColor = True
         ' 
         ' _optionsDeleteButton
         ' 
         Me._optionsDeleteButton.Location = New System.Drawing.Point(292, 48)
         Me._optionsDeleteButton.Name = "_optionsDeleteButton"
         Me._optionsDeleteButton.Size = New System.Drawing.Size(75, 23)
         Me._optionsDeleteButton.TabIndex = 19
         Me._optionsDeleteButton.Text = "Delete"
         Me._optionsDeleteButton.UseVisualStyleBackColor = True
         ' 
         ' _optionsAddItemButton
         ' 
         Me._optionsAddItemButton.Location = New System.Drawing.Point(292, 14)
         Me._optionsAddItemButton.Name = "_optionsAddItemButton"
         Me._optionsAddItemButton.Size = New System.Drawing.Size(75, 23)
         Me._optionsAddItemButton.TabIndex = 18
         Me._optionsAddItemButton.Text = "Add"
         Me._optionsAddItemButton.UseVisualStyleBackColor = True
         ' 
         ' _optionsItemsListBox
         ' 
         Me._optionsItemsListBox.FormattingEnabled = True
         Me._optionsItemsListBox.Location = New System.Drawing.Point(99, 45)
         Me._optionsItemsListBox.Name = "_optionsItemsListBox"
         Me._optionsItemsListBox.Size = New System.Drawing.Size(187, 95)
         Me._optionsItemsListBox.TabIndex = 17
         ' 
         ' _optionsAddItemTextBox
         ' 
         Me._optionsAddItemTextBox.Location = New System.Drawing.Point(101, 16)
         Me._optionsAddItemTextBox.Name = "_optionsAddItemTextBox"
         Me._optionsAddItemTextBox.Size = New System.Drawing.Size(187, 20)
         Me._optionsAddItemTextBox.TabIndex = 16
         ' 
         ' _optionsMultipleSelectionLabel
         ' 
         Me._optionsMultipleSelectionLabel.AutoSize = True
         Me._optionsMultipleSelectionLabel.Location = New System.Drawing.Point(4, 192)
         Me._optionsMultipleSelectionLabel.Name = "_optionsMultipleSelectionLabel"
         Me._optionsMultipleSelectionLabel.Size = New System.Drawing.Size(93, 13)
         Me._optionsMultipleSelectionLabel.TabIndex = 15
         Me._optionsMultipleSelectionLabel.Text = "Multiple Selection:"
         Me._optionsMultipleSelectionLabel.Visible = False
         ' 
         ' _optionsSortItemsLabel
         ' 
         Me._optionsSortItemsLabel.AutoSize = True
         Me._optionsSortItemsLabel.Location = New System.Drawing.Point(32, 160)
         Me._optionsSortItemsLabel.Name = "_optionsSortItemsLabel"
         Me._optionsSortItemsLabel.Size = New System.Drawing.Size(61, 13)
         Me._optionsSortItemsLabel.TabIndex = 14
         Me._optionsSortItemsLabel.Text = "Sort Items:"
         ' 
         ' _optionsItemsListLabel
         ' 
         Me._optionsItemsListLabel.AutoSize = True
         Me._optionsItemsListLabel.Location = New System.Drawing.Point(36, 48)
         Me._optionsItemsListLabel.Name = "_optionsItemsListLabel"
         Me._optionsItemsListLabel.Size = New System.Drawing.Size(57, 13)
         Me._optionsItemsListLabel.TabIndex = 13
         Me._optionsItemsListLabel.Text = "Items List:"
         ' 
         ' _optionsAddItemLabel
         ' 
         Me._optionsAddItemLabel.AutoSize = True
         Me._optionsAddItemLabel.Location = New System.Drawing.Point(38, 19)
         Me._optionsAddItemLabel.Name = "_optionsAddItemLabel"
         Me._optionsAddItemLabel.Size = New System.Drawing.Size(55, 13)
         Me._optionsAddItemLabel.TabIndex = 12
         Me._optionsAddItemLabel.Text = "Add Item:"
         ' 
         ' _optionsTextBoxPanel
         ' 
         Me._optionsTextBoxPanel.Controls.Add(Me._optionsMultiLineCheckBox)
         Me._optionsTextBoxPanel.Controls.Add(Me._optionsAlignmentComboBox)
         Me._optionsTextBoxPanel.Controls.Add(Me._optionsMultiLineLabel)
         Me._optionsTextBoxPanel.Controls.Add(Me._optionsAlignmentLabel)
         Me._optionsTextBoxPanel.Dock = System.Windows.Forms.DockStyle.Fill
         Me._optionsTextBoxPanel.Location = New System.Drawing.Point(3, 3)
         Me._optionsTextBoxPanel.Name = "_optionsTextBoxPanel"
         Me._optionsTextBoxPanel.Size = New System.Drawing.Size(370, 225)
         Me._optionsTextBoxPanel.TabIndex = 3
         Me._optionsTextBoxPanel.Visible = False
         ' 
         ' _optionsMultiLineCheckBox
         ' 
         Me._optionsMultiLineCheckBox.AutoSize = True
         Me._optionsMultiLineCheckBox.Location = New System.Drawing.Point(101, 54)
         Me._optionsMultiLineCheckBox.Name = "_optionsMultiLineCheckBox"
         Me._optionsMultiLineCheckBox.Size = New System.Drawing.Size(15, 14)
         Me._optionsMultiLineCheckBox.TabIndex = 4
         Me._optionsMultiLineCheckBox.UseVisualStyleBackColor = True
         ' 
         ' _optionsAlignmentComboBox
         ' 
         Me._optionsAlignmentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
         Me._optionsAlignmentComboBox.FormattingEnabled = True
         Me._optionsAlignmentComboBox.Items.AddRange(New Object() {"Left", "Center", "Right"})
         Me._optionsAlignmentComboBox.Location = New System.Drawing.Point(101, 15)
         Me._optionsAlignmentComboBox.Name = "_optionsAlignmentComboBox"
         Me._optionsAlignmentComboBox.Size = New System.Drawing.Size(244, 21)
         Me._optionsAlignmentComboBox.TabIndex = 3
         ' 
         ' _optionsMultiLineLabel
         ' 
         Me._optionsMultiLineLabel.AutoSize = True
         Me._optionsMultiLineLabel.Location = New System.Drawing.Point(39, 54)
         Me._optionsMultiLineLabel.Name = "_optionsMultiLineLabel"
         Me._optionsMultiLineLabel.Size = New System.Drawing.Size(56, 13)
         Me._optionsMultiLineLabel.TabIndex = 1
         Me._optionsMultiLineLabel.Text = "Multi-Line:"
         ' 
         ' _optionsAlignmentLabel
         ' 
         Me._optionsAlignmentLabel.AutoSize = True
         Me._optionsAlignmentLabel.Location = New System.Drawing.Point(37, 18)
         Me._optionsAlignmentLabel.Name = "_optionsAlignmentLabel"
         Me._optionsAlignmentLabel.Size = New System.Drawing.Size(58, 13)
         Me._optionsAlignmentLabel.TabIndex = 0
         Me._optionsAlignmentLabel.Text = "Alignment:"
         '
         ' _appearanceTextColorColorPicker
         ' 
         Me._appearanceTextColorColorPicker.Color = System.Drawing.Color.Black
         Me._appearanceTextColorColorPicker.Location = New System.Drawing.Point(258, 21)
         Me._appearanceTextColorColorPicker.Name = "_appearanceTextColorColorPicker"
         Me._appearanceTextColorColorPicker.Size = New System.Drawing.Size(70, 21)
         Me._appearanceTextColorColorPicker.TabIndex = 14
         ' 
         ' _appearanceFillColorColorPicker
         ' 
         Me._appearanceFillColorColorPicker.Color = System.Drawing.Color.Black
         Me._appearanceFillColorColorPicker.Location = New System.Drawing.Point(84, 58)
         Me._appearanceFillColorColorPicker.Name = "_appearanceFillColorColorPicker"
         Me._appearanceFillColorColorPicker.Size = New System.Drawing.Size(70, 21)
         Me._appearanceFillColorColorPicker.TabIndex = 12
         ' 
         ' _appearanceBorderColorColorPicker
         ' 
         Me._appearanceBorderColorColorPicker.Color = System.Drawing.Color.Black
         Me._appearanceBorderColorColorPicker.Location = New System.Drawing.Point(84, 21)
         Me._appearanceBorderColorColorPicker.Name = "_appearanceBorderColorColorPicker"
         Me._appearanceBorderColorColorPicker.Size = New System.Drawing.Size(70, 21)
         Me._appearanceBorderColorColorPicker.TabIndex = 11
         ' 
         ' PDFFormFieldPropertiesDailog
         ' 
         Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
         Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
         Me.ClientSize = New System.Drawing.Size(384, 303)
         Me.Controls.Add(Me._bottomPanel)
         Me.Controls.Add(Me._propertiesTabControl)
         Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
         Me.MaximizeBox = False
         Me.MinimizeBox = False
         Me.Name = "PDFFormFieldPropertiesDailog"
         Me.ShowIcon = False
         Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
         Me.Text = "PDFFormFieldProperties"
         Me._propertiesTabControl.ResumeLayout(False)
         Me._generalTabPage.ResumeLayout(False)
         Me._generalTabPage.PerformLayout()
         Me._generalCommonPropertiesGroupBox.ResumeLayout(False)
         Me._generalCommonPropertiesGroupBox.PerformLayout()
         Me._appearanceTabPage.ResumeLayout(False)
         Me._appearanceTextGroupBox.ResumeLayout(False)
         Me._appearanceTextGroupBox.PerformLayout()
         Me._appearanceBordersAndColorsGroupBox.ResumeLayout(False)
         Me._appearanceBordersAndColorsGroupBox.PerformLayout()
         Me._optionsTabPage.ResumeLayout(False)
         Me._bottomPanel.ResumeLayout(False)
         Me._bottomPanel.PerformLayout()
         Me._optionsItemsPanel.ResumeLayout(False)
         Me._optionsItemsPanel.PerformLayout()
         Me._optionsTextBoxPanel.ResumeLayout(False)
         Me._optionsTextBoxPanel.PerformLayout()
         Me.ResumeLayout(False)

      End Sub

#End Region

      Private _propertiesTabControl As System.Windows.Forms.TabControl
      Private _generalTabPage As System.Windows.Forms.TabPage
      Private _appearanceTabPage As System.Windows.Forms.TabPage
      Private _optionsTabPage As System.Windows.Forms.TabPage
      Private _generalTooltipTextBox As System.Windows.Forms.TextBox
      Private _generalNameTextBox As System.Windows.Forms.TextBox
      Private _generalTooltipLabel As System.Windows.Forms.Label
      Private _generalNameLabel As System.Windows.Forms.Label
      Private _generalCommonPropertiesGroupBox As System.Windows.Forms.GroupBox
      Private _generalReadOnlyCheckBox As System.Windows.Forms.CheckBox
      Private _generalFormFieldComboBox As System.Windows.Forms.ComboBox
      Private _generalReadOnlyLabel As System.Windows.Forms.Label
      Private _generalFormFieldLabel As System.Windows.Forms.Label
      Private _bottomPanel As System.Windows.Forms.Panel
      Private WithEvents _lockedCheckBox As System.Windows.Forms.CheckBox
      Private _lockedLabel As System.Windows.Forms.Label
      Private WithEvents _okButton As System.Windows.Forms.Button
      Private _appearanceTextColorLabel As System.Windows.Forms.Label
      Private _appearanceFontFamilyLabel As System.Windows.Forms.Label
      Private _appearanceFontSizeLabel As System.Windows.Forms.Label
      Private _appearanceBorderStyleLabel As System.Windows.Forms.Label
      Private _appearanceBorderThicknessLabel As System.Windows.Forms.Label
      Private _appearanceFillColorLabel As System.Windows.Forms.Label
      Private _appearanceBorderColorLabel As System.Windows.Forms.Label
      Private _appearanceBorderThicknessComboBox As System.Windows.Forms.ComboBox
      Private _appearanceBorderStyleComboBox As System.Windows.Forms.ComboBox
      Private _appearanceFontFamilyComboBox As System.Windows.Forms.ComboBox
      Private _appearanceFontSizeComboBox As System.Windows.Forms.ComboBox
      Private _appearanceBorderColorColorPicker As PDFFormsDemo.ColorPickerPanel
      Private _appearanceFillColorColorPicker As PDFFormsDemo.ColorPickerPanel
      Private _appearanceTextGroupBox As System.Windows.Forms.GroupBox
      Private _appearanceBordersAndColorsGroupBox As System.Windows.Forms.GroupBox
      Private _appearanceTextColorColorPicker As PDFFormsDemo.ColorPickerPanel
      Private _optionsTextBoxPanel As System.Windows.Forms.Panel
      Private _optionsMultiLineCheckBox As System.Windows.Forms.CheckBox
      Private _optionsAlignmentComboBox As System.Windows.Forms.ComboBox
      Private _optionsMultiLineLabel As System.Windows.Forms.Label
      Private _optionsAlignmentLabel As System.Windows.Forms.Label
      Private _optionsItemsPanel As System.Windows.Forms.Panel
      Private WithEvents _optionsMultipleSelectionCheckBox As System.Windows.Forms.CheckBox
      Private WithEvents _optionsSortItemsCheckBox As System.Windows.Forms.CheckBox
      Private WithEvents _optionsDownButton As System.Windows.Forms.Button
      Private WithEvents _optionsUpButton As System.Windows.Forms.Button
      Private WithEvents _optionsDeleteButton As System.Windows.Forms.Button
      Private WithEvents _optionsAddItemButton As System.Windows.Forms.Button
      Private WithEvents _optionsItemsListBox As System.Windows.Forms.ListBox
      Private WithEvents _optionsAddItemTextBox As System.Windows.Forms.TextBox
      Private _optionsMultipleSelectionLabel As System.Windows.Forms.Label
      Private _optionsSortItemsLabel As System.Windows.Forms.Label
      Private _optionsItemsListLabel As System.Windows.Forms.Label
      Private _optionsAddItemLabel As System.Windows.Forms.Label
   End Class
End Namespace