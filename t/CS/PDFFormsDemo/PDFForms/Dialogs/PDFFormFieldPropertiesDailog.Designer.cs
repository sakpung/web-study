namespace PDFFormsDemo
{
   partial class PDFFormFieldPropertiesDailog
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing)
      {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this._propertiesTabControl = new System.Windows.Forms.TabControl();
         this._generalTabPage = new System.Windows.Forms.TabPage();
         this._generalCommonPropertiesGroupBox = new System.Windows.Forms.GroupBox();
         this._generalReadOnlyCheckBox = new System.Windows.Forms.CheckBox();
         this._generalFormFieldComboBox = new System.Windows.Forms.ComboBox();
         this._generalReadOnlyLabel = new System.Windows.Forms.Label();
         this._generalFormFieldLabel = new System.Windows.Forms.Label();
         this._generalTooltipTextBox = new System.Windows.Forms.TextBox();
         this._generalNameTextBox = new System.Windows.Forms.TextBox();
         this._generalTooltipLabel = new System.Windows.Forms.Label();
         this._generalNameLabel = new System.Windows.Forms.Label();
         this._appearanceTabPage = new System.Windows.Forms.TabPage();
         this._appearanceTextGroupBox = new System.Windows.Forms.GroupBox();
         this._appearanceFontSizeLabel = new System.Windows.Forms.Label();
         this._appearanceFontSizeComboBox = new System.Windows.Forms.ComboBox();
         this._appearanceFontFamilyLabel = new System.Windows.Forms.Label();
         this._appearanceFontFamilyComboBox = new System.Windows.Forms.ComboBox();
         this._appearanceTextColorLabel = new System.Windows.Forms.Label();
         this._appearanceBordersAndColorsGroupBox = new System.Windows.Forms.GroupBox();
         this._appearanceBorderColorLabel = new System.Windows.Forms.Label();
         this._appearanceBorderStyleComboBox = new System.Windows.Forms.ComboBox();
         this._appearanceBorderThicknessComboBox = new System.Windows.Forms.ComboBox();
         this._appearanceBorderStyleLabel = new System.Windows.Forms.Label();
         this._appearanceFillColorLabel = new System.Windows.Forms.Label();
         this._appearanceBorderThicknessLabel = new System.Windows.Forms.Label();
         this._optionsTabPage = new System.Windows.Forms.TabPage();
         this._bottomPanel = new System.Windows.Forms.Panel();
         this._lockedCheckBox = new System.Windows.Forms.CheckBox();
         this._lockedLabel = new System.Windows.Forms.Label();
         this._okButton = new System.Windows.Forms.Button();
         this._optionsItemsPanel = new System.Windows.Forms.Panel();
         this._optionsMultipleSelectionCheckBox = new System.Windows.Forms.CheckBox();
         this._optionsSortItemsCheckBox = new System.Windows.Forms.CheckBox();
         this._optionsDownButton = new System.Windows.Forms.Button();
         this._optionsUpButton = new System.Windows.Forms.Button();
         this._optionsDeleteButton = new System.Windows.Forms.Button();
         this._optionsAddItemButton = new System.Windows.Forms.Button();
         this._optionsItemsListBox = new System.Windows.Forms.ListBox();
         this._optionsAddItemTextBox = new System.Windows.Forms.TextBox();
         this._optionsMultipleSelectionLabel = new System.Windows.Forms.Label();
         this._optionsSortItemsLabel = new System.Windows.Forms.Label();
         this._optionsItemsListLabel = new System.Windows.Forms.Label();
         this._optionsAddItemLabel = new System.Windows.Forms.Label();
         this._optionsTextBoxPanel = new System.Windows.Forms.Panel();
         this._optionsMultiLineCheckBox = new System.Windows.Forms.CheckBox();
         this._optionsAlignmentComboBox = new System.Windows.Forms.ComboBox();
         this._optionsMultiLineLabel = new System.Windows.Forms.Label();
         this._optionsAlignmentLabel = new System.Windows.Forms.Label();
         this._appearanceTextColorColorPicker = new PDFFormsDemo.ColorPickerPanel();
         this._appearanceFillColorColorPicker = new PDFFormsDemo.ColorPickerPanel();
         this._appearanceBorderColorColorPicker = new PDFFormsDemo.ColorPickerPanel();
         this._propertiesTabControl.SuspendLayout();
         this._generalTabPage.SuspendLayout();
         this._generalCommonPropertiesGroupBox.SuspendLayout();
         this._appearanceTabPage.SuspendLayout();
         this._appearanceTextGroupBox.SuspendLayout();
         this._appearanceBordersAndColorsGroupBox.SuspendLayout();
         this._optionsTabPage.SuspendLayout();
         this._bottomPanel.SuspendLayout();
         this._optionsItemsPanel.SuspendLayout();
         this._optionsTextBoxPanel.SuspendLayout();
         this.SuspendLayout();
         // 
         // _propertiesTabControl
         // 
         this._propertiesTabControl.Controls.Add(this._generalTabPage);
         this._propertiesTabControl.Controls.Add(this._appearanceTabPage);
         this._propertiesTabControl.Controls.Add(this._optionsTabPage);
         this._propertiesTabControl.Dock = System.Windows.Forms.DockStyle.Top;
         this._propertiesTabControl.Location = new System.Drawing.Point(0, 0);
         this._propertiesTabControl.Name = "_propertiesTabControl";
         this._propertiesTabControl.SelectedIndex = 0;
         this._propertiesTabControl.Size = new System.Drawing.Size(384, 257);
         this._propertiesTabControl.TabIndex = 0;
         // 
         // _generalTabPage
         // 
         this._generalTabPage.Controls.Add(this._generalCommonPropertiesGroupBox);
         this._generalTabPage.Controls.Add(this._generalTooltipTextBox);
         this._generalTabPage.Controls.Add(this._generalNameTextBox);
         this._generalTabPage.Controls.Add(this._generalTooltipLabel);
         this._generalTabPage.Controls.Add(this._generalNameLabel);
         this._generalTabPage.Location = new System.Drawing.Point(4, 22);
         this._generalTabPage.Name = "_generalTabPage";
         this._generalTabPage.Padding = new System.Windows.Forms.Padding(3);
         this._generalTabPage.Size = new System.Drawing.Size(376, 231);
         this._generalTabPage.TabIndex = 0;
         this._generalTabPage.Text = "General";
         this._generalTabPage.UseVisualStyleBackColor = true;
         // 
         // _generalCommonPropertiesGroupBox
         // 
         this._generalCommonPropertiesGroupBox.Controls.Add(this._generalReadOnlyCheckBox);
         this._generalCommonPropertiesGroupBox.Controls.Add(this._generalFormFieldComboBox);
         this._generalCommonPropertiesGroupBox.Controls.Add(this._generalReadOnlyLabel);
         this._generalCommonPropertiesGroupBox.Controls.Add(this._generalFormFieldLabel);
         this._generalCommonPropertiesGroupBox.Location = new System.Drawing.Point(26, 116);
         this._generalCommonPropertiesGroupBox.Name = "_generalCommonPropertiesGroupBox";
         this._generalCommonPropertiesGroupBox.Size = new System.Drawing.Size(325, 96);
         this._generalCommonPropertiesGroupBox.TabIndex = 4;
         this._generalCommonPropertiesGroupBox.TabStop = false;
         this._generalCommonPropertiesGroupBox.Text = "Common Properties";
         // 
         // _generalReadOnlyCheckBox
         // 
         this._generalReadOnlyCheckBox.AutoSize = true;
         this._generalReadOnlyCheckBox.Location = new System.Drawing.Point(258, 45);
         this._generalReadOnlyCheckBox.Name = "_generalReadOnlyCheckBox";
         this._generalReadOnlyCheckBox.Size = new System.Drawing.Size(15, 14);
         this._generalReadOnlyCheckBox.TabIndex = 6;
         this._generalReadOnlyCheckBox.UseVisualStyleBackColor = true;
         // 
         // _generalFormFieldComboBox
         // 
         this._generalFormFieldComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._generalFormFieldComboBox.FormattingEnabled = true;
         this._generalFormFieldComboBox.Items.AddRange(new object[] {
            "Visible",
            "Hidden",
            "Visible but doesn\'t print",
            "Hidden but printable"});
         this._generalFormFieldComboBox.Location = new System.Drawing.Point(78, 43);
         this._generalFormFieldComboBox.Name = "_generalFormFieldComboBox";
         this._generalFormFieldComboBox.Size = new System.Drawing.Size(107, 21);
         this._generalFormFieldComboBox.TabIndex = 4;
         // 
         // _generalReadOnlyLabel
         // 
         this._generalReadOnlyLabel.AutoSize = true;
         this._generalReadOnlyLabel.Location = new System.Drawing.Point(191, 46);
         this._generalReadOnlyLabel.Name = "_generalReadOnlyLabel";
         this._generalReadOnlyLabel.Size = new System.Drawing.Size(61, 13);
         this._generalReadOnlyLabel.TabIndex = 2;
         this._generalReadOnlyLabel.Text = "Read Only:";
         // 
         // _generalFormFieldLabel
         // 
         this._generalFormFieldLabel.AutoSize = true;
         this._generalFormFieldLabel.Location = new System.Drawing.Point(12, 46);
         this._generalFormFieldLabel.Name = "_generalFormFieldLabel";
         this._generalFormFieldLabel.Size = new System.Drawing.Size(60, 13);
         this._generalFormFieldLabel.TabIndex = 0;
         this._generalFormFieldLabel.Text = "Form Field:";
         // 
         // _generalTooltipTextBox
         // 
         this._generalTooltipTextBox.Location = new System.Drawing.Point(98, 59);
         this._generalTooltipTextBox.Name = "_generalTooltipTextBox";
         this._generalTooltipTextBox.Size = new System.Drawing.Size(253, 20);
         this._generalTooltipTextBox.TabIndex = 3;
         // 
         // _generalNameTextBox
         // 
         this._generalNameTextBox.Location = new System.Drawing.Point(98, 29);
         this._generalNameTextBox.Name = "_generalNameTextBox";
         this._generalNameTextBox.Size = new System.Drawing.Size(253, 20);
         this._generalNameTextBox.TabIndex = 2;
         // 
         // _generalTooltipLabel
         // 
         this._generalTooltipLabel.AutoSize = true;
         this._generalTooltipLabel.Location = new System.Drawing.Point(23, 62);
         this._generalTooltipLabel.Name = "_generalTooltipLabel";
         this._generalTooltipLabel.Size = new System.Drawing.Size(43, 13);
         this._generalTooltipLabel.TabIndex = 1;
         this._generalTooltipLabel.Text = "Tooltip:";
         // 
         // _generalNameLabel
         // 
         this._generalNameLabel.AutoSize = true;
         this._generalNameLabel.Location = new System.Drawing.Point(28, 36);
         this._generalNameLabel.Name = "_generalNameLabel";
         this._generalNameLabel.Size = new System.Drawing.Size(38, 13);
         this._generalNameLabel.TabIndex = 0;
         this._generalNameLabel.Text = "Name:";
         // 
         // _appearanceTabPage
         // 
         this._appearanceTabPage.Controls.Add(this._appearanceTextGroupBox);
         this._appearanceTabPage.Controls.Add(this._appearanceBordersAndColorsGroupBox);
         this._appearanceTabPage.Location = new System.Drawing.Point(4, 22);
         this._appearanceTabPage.Name = "_appearanceTabPage";
         this._appearanceTabPage.Padding = new System.Windows.Forms.Padding(3);
         this._appearanceTabPage.Size = new System.Drawing.Size(376, 231);
         this._appearanceTabPage.TabIndex = 1;
         this._appearanceTabPage.Text = "Appearance";
         this._appearanceTabPage.UseVisualStyleBackColor = true;
         // 
         // _appearanceTextGroupBox
         // 
         this._appearanceTextGroupBox.Controls.Add(this._appearanceTextColorColorPicker);
         this._appearanceTextGroupBox.Controls.Add(this._appearanceFontSizeLabel);
         this._appearanceTextGroupBox.Controls.Add(this._appearanceFontSizeComboBox);
         this._appearanceTextGroupBox.Controls.Add(this._appearanceFontFamilyLabel);
         this._appearanceTextGroupBox.Controls.Add(this._appearanceFontFamilyComboBox);
         this._appearanceTextGroupBox.Controls.Add(this._appearanceTextColorLabel);
         this._appearanceTextGroupBox.Location = new System.Drawing.Point(6, 110);
         this._appearanceTextGroupBox.Name = "_appearanceTextGroupBox";
         this._appearanceTextGroupBox.Size = new System.Drawing.Size(362, 90);
         this._appearanceTextGroupBox.TabIndex = 14;
         this._appearanceTextGroupBox.TabStop = false;
         this._appearanceTextGroupBox.Text = "Text";
         // 
         // _appearanceFontSizeLabel
         // 
         this._appearanceFontSizeLabel.AutoSize = true;
         this._appearanceFontSizeLabel.Location = new System.Drawing.Point(19, 24);
         this._appearanceFontSizeLabel.Name = "_appearanceFontSizeLabel";
         this._appearanceFontSizeLabel.Size = new System.Drawing.Size(55, 13);
         this._appearanceFontSizeLabel.TabIndex = 4;
         this._appearanceFontSizeLabel.Text = "Font Size:";
         // 
         // _appearanceFontSizeComboBox
         // 
         this._appearanceFontSizeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._appearanceFontSizeComboBox.FormattingEnabled = true;
         this._appearanceFontSizeComboBox.Items.AddRange(new object[] {
            "Auto",
            "6",
            "8",
            "9",
            "10",
            "12",
            "14",
            "18"});
         this._appearanceFontSizeComboBox.Location = new System.Drawing.Point(84, 21);
         this._appearanceFontSizeComboBox.Name = "_appearanceFontSizeComboBox";
         this._appearanceFontSizeComboBox.Size = new System.Drawing.Size(95, 21);
         this._appearanceFontSizeComboBox.TabIndex = 7;
         // 
         // _appearanceFontFamilyLabel
         // 
         this._appearanceFontFamilyLabel.AutoSize = true;
         this._appearanceFontFamilyLabel.Location = new System.Drawing.Point(8, 62);
         this._appearanceFontFamilyLabel.Name = "_appearanceFontFamilyLabel";
         this._appearanceFontFamilyLabel.Size = new System.Drawing.Size(66, 13);
         this._appearanceFontFamilyLabel.TabIndex = 5;
         this._appearanceFontFamilyLabel.Text = "Font Family:";
         // 
         // _appearanceFontFamilyComboBox
         // 
         this._appearanceFontFamilyComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._appearanceFontFamilyComboBox.FormattingEnabled = true;
         this._appearanceFontFamilyComboBox.Location = new System.Drawing.Point(80, 59);
         this._appearanceFontFamilyComboBox.Name = "_appearanceFontFamilyComboBox";
         this._appearanceFontFamilyComboBox.Size = new System.Drawing.Size(248, 21);
         this._appearanceFontFamilyComboBox.TabIndex = 8;
         // 
         // _appearanceTextColorLabel
         // 
         this._appearanceTextColorLabel.AutoSize = true;
         this._appearanceTextColorLabel.Location = new System.Drawing.Point(191, 24);
         this._appearanceTextColorLabel.Name = "_appearanceTextColorLabel";
         this._appearanceTextColorLabel.Size = new System.Drawing.Size(61, 13);
         this._appearanceTextColorLabel.TabIndex = 6;
         this._appearanceTextColorLabel.Text = "Text Color:";
         // 
         // _appearanceBordersAndColorsGroupBox
         // 
         this._appearanceBordersAndColorsGroupBox.Controls.Add(this._appearanceBorderColorLabel);
         this._appearanceBordersAndColorsGroupBox.Controls.Add(this._appearanceFillColorColorPicker);
         this._appearanceBordersAndColorsGroupBox.Controls.Add(this._appearanceBorderColorColorPicker);
         this._appearanceBordersAndColorsGroupBox.Controls.Add(this._appearanceBorderStyleComboBox);
         this._appearanceBordersAndColorsGroupBox.Controls.Add(this._appearanceBorderThicknessComboBox);
         this._appearanceBordersAndColorsGroupBox.Controls.Add(this._appearanceBorderStyleLabel);
         this._appearanceBordersAndColorsGroupBox.Controls.Add(this._appearanceFillColorLabel);
         this._appearanceBordersAndColorsGroupBox.Controls.Add(this._appearanceBorderThicknessLabel);
         this._appearanceBordersAndColorsGroupBox.Location = new System.Drawing.Point(6, 7);
         this._appearanceBordersAndColorsGroupBox.Name = "_appearanceBordersAndColorsGroupBox";
         this._appearanceBordersAndColorsGroupBox.Size = new System.Drawing.Size(362, 97);
         this._appearanceBordersAndColorsGroupBox.TabIndex = 13;
         this._appearanceBordersAndColorsGroupBox.TabStop = false;
         this._appearanceBordersAndColorsGroupBox.Text = "Borders and Colors";
         // 
         // _appearanceBorderColorLabel
         // 
         this._appearanceBorderColorLabel.AutoSize = true;
         this._appearanceBorderColorLabel.Location = new System.Drawing.Point(11, 24);
         this._appearanceBorderColorLabel.Name = "_appearanceBorderColorLabel";
         this._appearanceBorderColorLabel.Size = new System.Drawing.Size(71, 13);
         this._appearanceBorderColorLabel.TabIndex = 0;
         this._appearanceBorderColorLabel.Text = "Border Color:";
         // 
         // _appearanceBorderStyleComboBox
         // 
         this._appearanceBorderStyleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._appearanceBorderStyleComboBox.FormattingEnabled = true;
         this._appearanceBorderStyleComboBox.Items.AddRange(new object[] {
            "Solid",
            "Dashed",
            "Beveled",
            "Inset",
            "Underlined"});
         this._appearanceBorderStyleComboBox.Location = new System.Drawing.Point(258, 58);
         this._appearanceBorderStyleComboBox.Name = "_appearanceBorderStyleComboBox";
         this._appearanceBorderStyleComboBox.Size = new System.Drawing.Size(98, 21);
         this._appearanceBorderStyleComboBox.TabIndex = 9;
         // 
         // _appearanceBorderThicknessComboBox
         // 
         this._appearanceBorderThicknessComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._appearanceBorderThicknessComboBox.FormattingEnabled = true;
         this._appearanceBorderThicknessComboBox.Items.AddRange(new object[] {
            "Thin",
            "Medium",
            "Thick"});
         this._appearanceBorderThicknessComboBox.Location = new System.Drawing.Point(258, 21);
         this._appearanceBorderThicknessComboBox.Name = "_appearanceBorderThicknessComboBox";
         this._appearanceBorderThicknessComboBox.Size = new System.Drawing.Size(98, 21);
         this._appearanceBorderThicknessComboBox.TabIndex = 10;
         // 
         // _appearanceBorderStyleLabel
         // 
         this._appearanceBorderStyleLabel.AutoSize = true;
         this._appearanceBorderStyleLabel.Location = new System.Drawing.Point(182, 61);
         this._appearanceBorderStyleLabel.Name = "_appearanceBorderStyleLabel";
         this._appearanceBorderStyleLabel.Size = new System.Drawing.Size(70, 13);
         this._appearanceBorderStyleLabel.TabIndex = 3;
         this._appearanceBorderStyleLabel.Text = "Border Style:";
         // 
         // _appearanceFillColorLabel
         // 
         this._appearanceFillColorLabel.AutoSize = true;
         this._appearanceFillColorLabel.Location = new System.Drawing.Point(23, 61);
         this._appearanceFillColorLabel.Name = "_appearanceFillColorLabel";
         this._appearanceFillColorLabel.Size = new System.Drawing.Size(51, 13);
         this._appearanceFillColorLabel.TabIndex = 1;
         this._appearanceFillColorLabel.Text = "Fill Color:";
         // 
         // _appearanceBorderThicknessLabel
         // 
         this._appearanceBorderThicknessLabel.AutoSize = true;
         this._appearanceBorderThicknessLabel.Location = new System.Drawing.Point(160, 24);
         this._appearanceBorderThicknessLabel.Name = "_appearanceBorderThicknessLabel";
         this._appearanceBorderThicknessLabel.Size = new System.Drawing.Size(92, 13);
         this._appearanceBorderThicknessLabel.TabIndex = 2;
         this._appearanceBorderThicknessLabel.Text = "Border Thickness:";
         // 
         // _optionsTabPage
         // 
         this._optionsTabPage.Controls.Add(this._optionsTextBoxPanel);
         this._optionsTabPage.Controls.Add(this._optionsItemsPanel);
         this._optionsTabPage.Location = new System.Drawing.Point(4, 22);
         this._optionsTabPage.Name = "_optionsTabPage";
         this._optionsTabPage.Padding = new System.Windows.Forms.Padding(3);
         this._optionsTabPage.Size = new System.Drawing.Size(376, 231);
         this._optionsTabPage.TabIndex = 2;
         this._optionsTabPage.Text = "Options";
         this._optionsTabPage.UseVisualStyleBackColor = true;
         // 
         // _bottomPanel
         // 
         this._bottomPanel.Controls.Add(this._lockedCheckBox);
         this._bottomPanel.Controls.Add(this._lockedLabel);
         this._bottomPanel.Controls.Add(this._okButton);
         this._bottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
         this._bottomPanel.Location = new System.Drawing.Point(0, 259);
         this._bottomPanel.Name = "_bottomPanel";
         this._bottomPanel.Size = new System.Drawing.Size(384, 44);
         this._bottomPanel.TabIndex = 1;
         // 
         // _lockedCheckBox
         // 
         this._lockedCheckBox.AutoSize = true;
         this._lockedCheckBox.Location = new System.Drawing.Point(108, 15);
         this._lockedCheckBox.Name = "_lockedCheckBox";
         this._lockedCheckBox.Size = new System.Drawing.Size(15, 14);
         this._lockedCheckBox.TabIndex = 2;
         this._lockedCheckBox.UseVisualStyleBackColor = true;
         this._lockedCheckBox.Click += new System.EventHandler(this._lockedCheckBox_Click);
         // 
         // _lockedLabel
         // 
         this._lockedLabel.AutoSize = true;
         this._lockedLabel.Location = new System.Drawing.Point(58, 15);
         this._lockedLabel.Name = "_lockedLabel";
         this._lockedLabel.Size = new System.Drawing.Size(44, 13);
         this._lockedLabel.TabIndex = 1;
         this._lockedLabel.Text = "Locked:";
         // 
         // _okButton
         // 
         this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._okButton.Location = new System.Drawing.Point(224, 10);
         this._okButton.Name = "_okButton";
         this._okButton.Size = new System.Drawing.Size(114, 23);
         this._okButton.TabIndex = 0;
         this._okButton.Text = "Ok";
         this._okButton.UseVisualStyleBackColor = true;
         this._okButton.Click += new System.EventHandler(this._okButton_Click);
         // 
         // _optionsItemsPanel
         // 
         this._optionsItemsPanel.Controls.Add(this._optionsMultipleSelectionCheckBox);
         this._optionsItemsPanel.Controls.Add(this._optionsSortItemsCheckBox);
         this._optionsItemsPanel.Controls.Add(this._optionsDownButton);
         this._optionsItemsPanel.Controls.Add(this._optionsUpButton);
         this._optionsItemsPanel.Controls.Add(this._optionsDeleteButton);
         this._optionsItemsPanel.Controls.Add(this._optionsAddItemButton);
         this._optionsItemsPanel.Controls.Add(this._optionsItemsListBox);
         this._optionsItemsPanel.Controls.Add(this._optionsAddItemTextBox);
         this._optionsItemsPanel.Controls.Add(this._optionsMultipleSelectionLabel);
         this._optionsItemsPanel.Controls.Add(this._optionsSortItemsLabel);
         this._optionsItemsPanel.Controls.Add(this._optionsItemsListLabel);
         this._optionsItemsPanel.Controls.Add(this._optionsAddItemLabel);
         this._optionsItemsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
         this._optionsItemsPanel.Location = new System.Drawing.Point(3, 3);
         this._optionsItemsPanel.Name = "_optionsItemsPanel";
         this._optionsItemsPanel.Size = new System.Drawing.Size(370, 225);
         this._optionsItemsPanel.TabIndex = 2;
         this._optionsItemsPanel.Visible = false;
         // 
         // _optionsMultipleSelectionCheckBox
         // 
         this._optionsMultipleSelectionCheckBox.AutoSize = true;
         this._optionsMultipleSelectionCheckBox.Location = new System.Drawing.Point(99, 192);
         this._optionsMultipleSelectionCheckBox.Name = "_optionsMultipleSelectionCheckBox";
         this._optionsMultipleSelectionCheckBox.Size = new System.Drawing.Size(15, 14);
         this._optionsMultipleSelectionCheckBox.TabIndex = 23;
         this._optionsMultipleSelectionCheckBox.UseVisualStyleBackColor = true;
         this._optionsMultipleSelectionCheckBox.Visible = false;
         // 
         // _optionsSortItemsCheckBox
         // 
         this._optionsSortItemsCheckBox.AutoSize = true;
         this._optionsSortItemsCheckBox.Location = new System.Drawing.Point(99, 159);
         this._optionsSortItemsCheckBox.Name = "_optionsSortItemsCheckBox";
         this._optionsSortItemsCheckBox.Size = new System.Drawing.Size(15, 14);
         this._optionsSortItemsCheckBox.TabIndex = 22;
         this._optionsSortItemsCheckBox.UseVisualStyleBackColor = true;
         this._optionsSortItemsCheckBox.CheckedChanged += new System.EventHandler(this._optionsSortItemsCheckBox_CheckedChanged);
         // 
         // _optionsDownButton
         // 
         this._optionsDownButton.Location = new System.Drawing.Point(292, 106);
         this._optionsDownButton.Name = "_optionsDownButton";
         this._optionsDownButton.Size = new System.Drawing.Size(75, 23);
         this._optionsDownButton.TabIndex = 21;
         this._optionsDownButton.Text = "Down";
         this._optionsDownButton.UseVisualStyleBackColor = true;
         this._optionsDownButton.Click += new System.EventHandler(this._optionsDownButton_Click);
         // 
         // _optionsUpButton
         // 
         this._optionsUpButton.Location = new System.Drawing.Point(292, 77);
         this._optionsUpButton.Name = "_optionsUpButton";
         this._optionsUpButton.Size = new System.Drawing.Size(75, 23);
         this._optionsUpButton.TabIndex = 20;
         this._optionsUpButton.Text = "Up";
         this._optionsUpButton.UseVisualStyleBackColor = true;
         this._optionsUpButton.Click += new System.EventHandler(this._optionsUpButton_Click);
         // 
         // _optionsDeleteButton
         // 
         this._optionsDeleteButton.Location = new System.Drawing.Point(292, 48);
         this._optionsDeleteButton.Name = "_optionsDeleteButton";
         this._optionsDeleteButton.Size = new System.Drawing.Size(75, 23);
         this._optionsDeleteButton.TabIndex = 19;
         this._optionsDeleteButton.Text = "Delete";
         this._optionsDeleteButton.UseVisualStyleBackColor = true;
         this._optionsDeleteButton.Click += new System.EventHandler(this._optionsDeleteButton_Click);
         // 
         // _optionsAddItemButton
         // 
         this._optionsAddItemButton.Location = new System.Drawing.Point(292, 14);
         this._optionsAddItemButton.Name = "_optionsAddItemButton";
         this._optionsAddItemButton.Size = new System.Drawing.Size(75, 23);
         this._optionsAddItemButton.TabIndex = 18;
         this._optionsAddItemButton.Text = "Add";
         this._optionsAddItemButton.UseVisualStyleBackColor = true;
         this._optionsAddItemButton.Click += new System.EventHandler(this._optionsAddItemButton_Click);
         // 
         // _optionsItemsListBox
         // 
         this._optionsItemsListBox.FormattingEnabled = true;
         this._optionsItemsListBox.Location = new System.Drawing.Point(99, 45);
         this._optionsItemsListBox.Name = "_optionsItemsListBox";
         this._optionsItemsListBox.Size = new System.Drawing.Size(187, 95);
         this._optionsItemsListBox.TabIndex = 17;
         this._optionsItemsListBox.SelectedIndexChanged += new System.EventHandler(this._optionItemsListBox_SelectedIndexChanged);
         // 
         // _optionsAddItemTextBox
         // 
         this._optionsAddItemTextBox.Location = new System.Drawing.Point(101, 16);
         this._optionsAddItemTextBox.Name = "_optionsAddItemTextBox";
         this._optionsAddItemTextBox.Size = new System.Drawing.Size(187, 20);
         this._optionsAddItemTextBox.TabIndex = 16;
         this._optionsAddItemTextBox.TextChanged += new System.EventHandler(this._optionsAddItemTextBox_TextChanged);
         // 
         // _optionsMultipleSelectionLabel
         // 
         this._optionsMultipleSelectionLabel.AutoSize = true;
         this._optionsMultipleSelectionLabel.Location = new System.Drawing.Point(4, 192);
         this._optionsMultipleSelectionLabel.Name = "_optionsMultipleSelectionLabel";
         this._optionsMultipleSelectionLabel.Size = new System.Drawing.Size(93, 13);
         this._optionsMultipleSelectionLabel.TabIndex = 15;
         this._optionsMultipleSelectionLabel.Text = "Multiple Selection:";
         this._optionsMultipleSelectionLabel.Visible = false;
         // 
         // _optionsSortItemsLabel
         // 
         this._optionsSortItemsLabel.AutoSize = true;
         this._optionsSortItemsLabel.Location = new System.Drawing.Point(32, 160);
         this._optionsSortItemsLabel.Name = "_optionsSortItemsLabel";
         this._optionsSortItemsLabel.Size = new System.Drawing.Size(61, 13);
         this._optionsSortItemsLabel.TabIndex = 14;
         this._optionsSortItemsLabel.Text = "Sort Items:";
         // 
         // _optionsItemsListLabel
         // 
         this._optionsItemsListLabel.AutoSize = true;
         this._optionsItemsListLabel.Location = new System.Drawing.Point(36, 48);
         this._optionsItemsListLabel.Name = "_optionsItemsListLabel";
         this._optionsItemsListLabel.Size = new System.Drawing.Size(57, 13);
         this._optionsItemsListLabel.TabIndex = 13;
         this._optionsItemsListLabel.Text = "Items List:";
         // 
         // _optionsAddItemLabel
         // 
         this._optionsAddItemLabel.AutoSize = true;
         this._optionsAddItemLabel.Location = new System.Drawing.Point(38, 19);
         this._optionsAddItemLabel.Name = "_optionsAddItemLabel";
         this._optionsAddItemLabel.Size = new System.Drawing.Size(55, 13);
         this._optionsAddItemLabel.TabIndex = 12;
         this._optionsAddItemLabel.Text = "Add Item:";
         // 
         // _optionsTextBoxPanel
         // 
         this._optionsTextBoxPanel.Controls.Add(this._optionsMultiLineCheckBox);
         this._optionsTextBoxPanel.Controls.Add(this._optionsAlignmentComboBox);
         this._optionsTextBoxPanel.Controls.Add(this._optionsMultiLineLabel);
         this._optionsTextBoxPanel.Controls.Add(this._optionsAlignmentLabel);
         this._optionsTextBoxPanel.Dock = System.Windows.Forms.DockStyle.Fill;
         this._optionsTextBoxPanel.Location = new System.Drawing.Point(3, 3);
         this._optionsTextBoxPanel.Name = "_optionsTextBoxPanel";
         this._optionsTextBoxPanel.Size = new System.Drawing.Size(370, 225);
         this._optionsTextBoxPanel.TabIndex = 3;
         this._optionsTextBoxPanel.Visible = false;
         // 
         // _optionsMultiLineCheckBox
         // 
         this._optionsMultiLineCheckBox.AutoSize = true;
         this._optionsMultiLineCheckBox.Location = new System.Drawing.Point(101, 54);
         this._optionsMultiLineCheckBox.Name = "_optionsMultiLineCheckBox";
         this._optionsMultiLineCheckBox.Size = new System.Drawing.Size(15, 14);
         this._optionsMultiLineCheckBox.TabIndex = 4;
         this._optionsMultiLineCheckBox.UseVisualStyleBackColor = true;
         // 
         // _optionsAlignmentComboBox
         // 
         this._optionsAlignmentComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._optionsAlignmentComboBox.FormattingEnabled = true;
         this._optionsAlignmentComboBox.Items.AddRange(new object[] {
            "Left",
            "Center",
            "Right"});
         this._optionsAlignmentComboBox.Location = new System.Drawing.Point(101, 15);
         this._optionsAlignmentComboBox.Name = "_optionsAlignmentComboBox";
         this._optionsAlignmentComboBox.Size = new System.Drawing.Size(244, 21);
         this._optionsAlignmentComboBox.TabIndex = 3;
         // 
         // _optionsMultiLineLabel
         // 
         this._optionsMultiLineLabel.AutoSize = true;
         this._optionsMultiLineLabel.Location = new System.Drawing.Point(39, 54);
         this._optionsMultiLineLabel.Name = "_optionsMultiLineLabel";
         this._optionsMultiLineLabel.Size = new System.Drawing.Size(56, 13);
         this._optionsMultiLineLabel.TabIndex = 1;
         this._optionsMultiLineLabel.Text = "Multi-Line:";
         // 
         // _optionsAlignmentLabel
         // 
         this._optionsAlignmentLabel.AutoSize = true;
         this._optionsAlignmentLabel.Location = new System.Drawing.Point(37, 18);
         this._optionsAlignmentLabel.Name = "_optionsAlignmentLabel";
         this._optionsAlignmentLabel.Size = new System.Drawing.Size(58, 13);
         this._optionsAlignmentLabel.TabIndex = 0;
         this._optionsAlignmentLabel.Text = "Alignment:";
         //
         // _appearanceTextColorColorPicker
         // 
         this._appearanceTextColorColorPicker.Color = System.Drawing.Color.Black;
         this._appearanceTextColorColorPicker.Location = new System.Drawing.Point(258, 21);
         this._appearanceTextColorColorPicker.Name = "_appearanceTextColorColorPicker";
         this._appearanceTextColorColorPicker.Size = new System.Drawing.Size(70, 21);
         this._appearanceTextColorColorPicker.TabIndex = 14;
         // 
         // _appearanceFillColorColorPicker
         // 
         this._appearanceFillColorColorPicker.Color = System.Drawing.Color.Black;
         this._appearanceFillColorColorPicker.Location = new System.Drawing.Point(84, 58);
         this._appearanceFillColorColorPicker.Name = "_appearanceFillColorColorPicker";
         this._appearanceFillColorColorPicker.Size = new System.Drawing.Size(70, 21);
         this._appearanceFillColorColorPicker.TabIndex = 12;
         // 
         // _appearanceBorderColorColorPicker
         // 
         this._appearanceBorderColorColorPicker.Color = System.Drawing.Color.Black;
         this._appearanceBorderColorColorPicker.Location = new System.Drawing.Point(84, 21);
         this._appearanceBorderColorColorPicker.Name = "_appearanceBorderColorColorPicker";
         this._appearanceBorderColorColorPicker.Size = new System.Drawing.Size(70, 21);
         this._appearanceBorderColorColorPicker.TabIndex = 11;
         // 
         // PDFFormFieldPropertiesDailog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(384, 303);
         this.Controls.Add(this._bottomPanel);
         this.Controls.Add(this._propertiesTabControl);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "PDFFormFieldPropertiesDailog";
         this.ShowIcon = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "PDFFormFieldProperties";
         this._propertiesTabControl.ResumeLayout(false);
         this._generalTabPage.ResumeLayout(false);
         this._generalTabPage.PerformLayout();
         this._generalCommonPropertiesGroupBox.ResumeLayout(false);
         this._generalCommonPropertiesGroupBox.PerformLayout();
         this._appearanceTabPage.ResumeLayout(false);
         this._appearanceTextGroupBox.ResumeLayout(false);
         this._appearanceTextGroupBox.PerformLayout();
         this._appearanceBordersAndColorsGroupBox.ResumeLayout(false);
         this._appearanceBordersAndColorsGroupBox.PerformLayout();
         this._optionsTabPage.ResumeLayout(false);
         this._bottomPanel.ResumeLayout(false);
         this._bottomPanel.PerformLayout();
         this._optionsItemsPanel.ResumeLayout(false);
         this._optionsItemsPanel.PerformLayout();
         this._optionsTextBoxPanel.ResumeLayout(false);
         this._optionsTextBoxPanel.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TabControl _propertiesTabControl;
      private System.Windows.Forms.TabPage _generalTabPage;
      private System.Windows.Forms.TabPage _appearanceTabPage;
      private System.Windows.Forms.TabPage _optionsTabPage;
      private System.Windows.Forms.TextBox _generalTooltipTextBox;
      private System.Windows.Forms.TextBox _generalNameTextBox;
      private System.Windows.Forms.Label _generalTooltipLabel;
      private System.Windows.Forms.Label _generalNameLabel;
      private System.Windows.Forms.GroupBox _generalCommonPropertiesGroupBox;
      private System.Windows.Forms.CheckBox _generalReadOnlyCheckBox;
      private System.Windows.Forms.ComboBox _generalFormFieldComboBox;
      private System.Windows.Forms.Label _generalReadOnlyLabel;
      private System.Windows.Forms.Label _generalFormFieldLabel;
      private System.Windows.Forms.Panel _bottomPanel;
      private System.Windows.Forms.CheckBox _lockedCheckBox;
      private System.Windows.Forms.Label _lockedLabel;
      private System.Windows.Forms.Button _okButton;
      private System.Windows.Forms.Label _appearanceTextColorLabel;
      private System.Windows.Forms.Label _appearanceFontFamilyLabel;
      private System.Windows.Forms.Label _appearanceFontSizeLabel;
      private System.Windows.Forms.Label _appearanceBorderStyleLabel;
      private System.Windows.Forms.Label _appearanceBorderThicknessLabel;
      private System.Windows.Forms.Label _appearanceFillColorLabel;
      private System.Windows.Forms.Label _appearanceBorderColorLabel;
      private System.Windows.Forms.ComboBox _appearanceBorderThicknessComboBox;
      private System.Windows.Forms.ComboBox _appearanceBorderStyleComboBox;
      private System.Windows.Forms.ComboBox _appearanceFontFamilyComboBox;
      private System.Windows.Forms.ComboBox _appearanceFontSizeComboBox;
      private PDFFormsDemo.ColorPickerPanel _appearanceBorderColorColorPicker;
      private PDFFormsDemo.ColorPickerPanel _appearanceFillColorColorPicker;
      private System.Windows.Forms.GroupBox _appearanceTextGroupBox;
      private System.Windows.Forms.GroupBox _appearanceBordersAndColorsGroupBox;
      private PDFFormsDemo.ColorPickerPanel _appearanceTextColorColorPicker;
      private System.Windows.Forms.Panel _optionsTextBoxPanel;
      private System.Windows.Forms.CheckBox _optionsMultiLineCheckBox;
      private System.Windows.Forms.ComboBox _optionsAlignmentComboBox;
      private System.Windows.Forms.Label _optionsMultiLineLabel;
      private System.Windows.Forms.Label _optionsAlignmentLabel;
      private System.Windows.Forms.Panel _optionsItemsPanel;
      private System.Windows.Forms.CheckBox _optionsMultipleSelectionCheckBox;
      private System.Windows.Forms.CheckBox _optionsSortItemsCheckBox;
      private System.Windows.Forms.Button _optionsDownButton;
      private System.Windows.Forms.Button _optionsUpButton;
      private System.Windows.Forms.Button _optionsDeleteButton;
      private System.Windows.Forms.Button _optionsAddItemButton;
      private System.Windows.Forms.ListBox _optionsItemsListBox;
      private System.Windows.Forms.TextBox _optionsAddItemTextBox;
      private System.Windows.Forms.Label _optionsMultipleSelectionLabel;
      private System.Windows.Forms.Label _optionsSortItemsLabel;
      private System.Windows.Forms.Label _optionsItemsListLabel;
      private System.Windows.Forms.Label _optionsAddItemLabel;
   }
}