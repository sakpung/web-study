namespace RasterizeDocumentDemo.UserControls
{
   partial class TxtOptionsControl
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
         if(disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this.components = new System.ComponentModel.Container();
         this._generalTxtLoadOptionsGroupBox = new System.Windows.Forms.GroupBox();
         this._fontStrikethroughCheckBox = new System.Windows.Forms.CheckBox();
         this._fontUnderlineCheckBox = new System.Windows.Forms.CheckBox();
         this._fontItalicCheckBox = new System.Windows.Forms.CheckBox();
         this._fontBoldCheckBox = new System.Windows.Forms.CheckBox();
         this._fontSizeComboBox = new System.Windows.Forms.ComboBox();
         this._fontSizeLabel = new System.Windows.Forms.Label();
         this._fontNameComboBox = new System.Windows.Forms.ComboBox();
         this._resetToDefaultsButton = new System.Windows.Forms.Button();
         this._useSystenLocaleCheckBox = new System.Windows.Forms.CheckBox();
         this._highlightColorButton = new System.Windows.Forms.Button();
         this._highlightColorPanel = new System.Windows.Forms.Panel();
         this._highlightColorLabel = new System.Windows.Forms.Label();
         this._fontColorButton = new System.Windows.Forms.Button();
         this._fontColorPanel = new System.Windows.Forms.Panel();
         this._fontColorLabel = new System.Windows.Forms.Label();
         this._fontLabel = new System.Windows.Forms.Label();
         this._enabledCheckBox = new System.Windows.Forms.CheckBox();
         this._backColorButton = new System.Windows.Forms.Button();
         this._backColorPanel = new System.Windows.Forms.Panel();
         this._backColorLabel = new System.Windows.Forms.Label();
         this._controlsToolTip = new System.Windows.Forms.ToolTip(this.components);
         this._generalTxtLoadOptionsGroupBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // _generalTxtLoadOptionsGroupBox
         // 
         this._generalTxtLoadOptionsGroupBox.Controls.Add(this._fontStrikethroughCheckBox);
         this._generalTxtLoadOptionsGroupBox.Controls.Add(this._fontUnderlineCheckBox);
         this._generalTxtLoadOptionsGroupBox.Controls.Add(this._fontItalicCheckBox);
         this._generalTxtLoadOptionsGroupBox.Controls.Add(this._fontBoldCheckBox);
         this._generalTxtLoadOptionsGroupBox.Controls.Add(this._fontSizeComboBox);
         this._generalTxtLoadOptionsGroupBox.Controls.Add(this._fontSizeLabel);
         this._generalTxtLoadOptionsGroupBox.Controls.Add(this._fontNameComboBox);
         this._generalTxtLoadOptionsGroupBox.Controls.Add(this._resetToDefaultsButton);
         this._generalTxtLoadOptionsGroupBox.Controls.Add(this._useSystenLocaleCheckBox);
         this._generalTxtLoadOptionsGroupBox.Controls.Add(this._highlightColorButton);
         this._generalTxtLoadOptionsGroupBox.Controls.Add(this._highlightColorPanel);
         this._generalTxtLoadOptionsGroupBox.Controls.Add(this._highlightColorLabel);
         this._generalTxtLoadOptionsGroupBox.Controls.Add(this._fontColorButton);
         this._generalTxtLoadOptionsGroupBox.Controls.Add(this._fontColorPanel);
         this._generalTxtLoadOptionsGroupBox.Controls.Add(this._fontColorLabel);
         this._generalTxtLoadOptionsGroupBox.Controls.Add(this._fontLabel);
         this._generalTxtLoadOptionsGroupBox.Controls.Add(this._enabledCheckBox);
         this._generalTxtLoadOptionsGroupBox.Controls.Add(this._backColorButton);
         this._generalTxtLoadOptionsGroupBox.Controls.Add(this._backColorPanel);
         this._generalTxtLoadOptionsGroupBox.Controls.Add(this._backColorLabel);
         this._generalTxtLoadOptionsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
         this._generalTxtLoadOptionsGroupBox.Location = new System.Drawing.Point(0, 0);
         this._generalTxtLoadOptionsGroupBox.Name = "_generalTxtLoadOptionsGroupBox";
         this._generalTxtLoadOptionsGroupBox.Size = new System.Drawing.Size(500, 230);
         this._generalTxtLoadOptionsGroupBox.TabIndex = 0;
         this._generalTxtLoadOptionsGroupBox.TabStop = false;
         this._generalTxtLoadOptionsGroupBox.Text = "General Text load options:";
         // 
         // _fontStrikethroughCheckBox
         // 
         this._fontStrikethroughCheckBox.AutoSize = true;
         this._fontStrikethroughCheckBox.Location = new System.Drawing.Point(377, 99);
         this._fontStrikethroughCheckBox.Name = "_fontStrikethroughCheckBox";
         this._fontStrikethroughCheckBox.Size = new System.Drawing.Size(89, 17);
         this._fontStrikethroughCheckBox.TabIndex = 10;
         this._fontStrikethroughCheckBox.Text = "Strikethrough";
         this._fontStrikethroughCheckBox.UseVisualStyleBackColor = true;
         // 
         // _fontUnderlineCheckBox
         // 
         this._fontUnderlineCheckBox.AutoSize = true;
         this._fontUnderlineCheckBox.Location = new System.Drawing.Point(277, 99);
         this._fontUnderlineCheckBox.Name = "_fontUnderlineCheckBox";
         this._fontUnderlineCheckBox.Size = new System.Drawing.Size(71, 17);
         this._fontUnderlineCheckBox.TabIndex = 9;
         this._fontUnderlineCheckBox.Text = "Underline";
         this._fontUnderlineCheckBox.UseVisualStyleBackColor = true;
         // 
         // _fontItalicCheckBox
         // 
         this._fontItalicCheckBox.AutoSize = true;
         this._fontItalicCheckBox.Location = new System.Drawing.Point(200, 99);
         this._fontItalicCheckBox.Name = "_fontItalicCheckBox";
         this._fontItalicCheckBox.Size = new System.Drawing.Size(48, 17);
         this._fontItalicCheckBox.TabIndex = 8;
         this._fontItalicCheckBox.Text = "Italic";
         this._fontItalicCheckBox.UseVisualStyleBackColor = true;
         // 
         // _fontBoldCheckBox
         // 
         this._fontBoldCheckBox.AutoSize = true;
         this._fontBoldCheckBox.Location = new System.Drawing.Point(124, 99);
         this._fontBoldCheckBox.Name = "_fontBoldCheckBox";
         this._fontBoldCheckBox.Size = new System.Drawing.Size(47, 17);
         this._fontBoldCheckBox.TabIndex = 7;
         this._fontBoldCheckBox.Text = "Bold";
         this._fontBoldCheckBox.UseVisualStyleBackColor = true;
         // 
         // _fontSizeComboBox
         // 
         this._fontSizeComboBox.FormattingEnabled = true;
         this._fontSizeComboBox.Items.AddRange(new object[] {
            "8",
            "9",
            "10",
            "11",
            "12",
            "14",
            "16",
            "18",
            "20",
            "22",
            "24",
            "26",
            "28",
            "36",
            "48",
            "72"});
         this._fontSizeComboBox.Location = new System.Drawing.Point(385, 72);
         this._fontSizeComboBox.Name = "_fontSizeComboBox";
         this._fontSizeComboBox.Size = new System.Drawing.Size(83, 21);
         this._fontSizeComboBox.TabIndex = 5;
         this._fontSizeComboBox.SelectedIndexChanged += new System.EventHandler(this._fontSizeComboBox_SelectedIndexChanged);
         this._fontSizeComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._fontSizeComboBox_KeyPress);
         // 
         // _fontSizeLabel
         // 
         this._fontSizeLabel.AutoSize = true;
         this._fontSizeLabel.Location = new System.Drawing.Point(337, 75);
         this._fontSizeLabel.Name = "_fontSizeLabel";
         this._fontSizeLabel.Size = new System.Drawing.Size(30, 13);
         this._fontSizeLabel.TabIndex = 4;
         this._fontSizeLabel.Text = "&Size:";
         // 
         // _fontNameComboBox
         // 
         this._fontNameComboBox.FormattingEnabled = true;
         this._fontNameComboBox.Location = new System.Drawing.Point(124, 72);
         this._fontNameComboBox.Name = "_fontNameComboBox";
         this._fontNameComboBox.Size = new System.Drawing.Size(196, 21);
         this._fontNameComboBox.TabIndex = 3;
         // 
         // _resetToDefaultsButton
         // 
         this._resetToDefaultsButton.Location = new System.Drawing.Point(305, 201);
         this._resetToDefaultsButton.Name = "_resetToDefaultsButton";
         this._resetToDefaultsButton.Size = new System.Drawing.Size(189, 23);
         this._resetToDefaultsButton.TabIndex = 20;
         this._resetToDefaultsButton.Text = "Reset to defa&ults";
         this._controlsToolTip.SetToolTip(this._resetToDefaultsButton, "Reset the options to LEADTOOLS default values");
         this._resetToDefaultsButton.UseVisualStyleBackColor = true;
         this._resetToDefaultsButton.Click += new System.EventHandler(this._resetToDefaultsButton_Click);
         // 
         // _useSystenLocaleCheckBox
         // 
         this._useSystenLocaleCheckBox.AutoSize = true;
         this._useSystenLocaleCheckBox.Location = new System.Drawing.Point(21, 42);
         this._useSystenLocaleCheckBox.Name = "_useSystenLocaleCheckBox";
         this._useSystenLocaleCheckBox.Size = new System.Drawing.Size(111, 17);
         this._useSystenLocaleCheckBox.TabIndex = 1;
         this._useSystenLocaleCheckBox.Text = "&Use system locale";
         this._controlsToolTip.SetToolTip(this._useSystenLocaleCheckBox, "Use current system locale (code page) when rendering text file");
         this._useSystenLocaleCheckBox.UseVisualStyleBackColor = true;
         // 
         // _highlightColorButton
         // 
         this._highlightColorButton.Location = new System.Drawing.Point(201, 180);
         this._highlightColorButton.Name = "_highlightColorButton";
         this._highlightColorButton.Size = new System.Drawing.Size(25, 23);
         this._highlightColorButton.TabIndex = 19;
         this._highlightColorButton.Text = "...";
         this._controlsToolTip.SetToolTip(this._highlightColorButton, "Change the text highlight color used when rendering Text documents");
         this._highlightColorButton.UseVisualStyleBackColor = true;
         this._highlightColorButton.Click += new System.EventHandler(this._highlightColorButton_Click);
         // 
         // _highlightColorPanel
         // 
         this._highlightColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._highlightColorPanel.Location = new System.Drawing.Point(124, 180);
         this._highlightColorPanel.Name = "_highlightColorPanel";
         this._highlightColorPanel.Size = new System.Drawing.Size(71, 23);
         this._highlightColorPanel.TabIndex = 18;
         this._controlsToolTip.SetToolTip(this._highlightColorPanel, "The text highlight color used when rendering Text documents");
         // 
         // _highlightColorLabel
         // 
         this._highlightColorLabel.AutoSize = true;
         this._highlightColorLabel.Location = new System.Drawing.Point(18, 185);
         this._highlightColorLabel.Name = "_highlightColorLabel";
         this._highlightColorLabel.Size = new System.Drawing.Size(77, 13);
         this._highlightColorLabel.TabIndex = 17;
         this._highlightColorLabel.Text = "&Highlight color:";
         // 
         // _fontColorButton
         // 
         this._fontColorButton.Location = new System.Drawing.Point(201, 122);
         this._fontColorButton.Name = "_fontColorButton";
         this._fontColorButton.Size = new System.Drawing.Size(25, 23);
         this._fontColorButton.TabIndex = 13;
         this._fontColorButton.Text = "...";
         this._controlsToolTip.SetToolTip(this._fontColorButton, "Change the font (foreground) color used when rendering Text documents");
         this._fontColorButton.UseVisualStyleBackColor = true;
         this._fontColorButton.Click += new System.EventHandler(this._fontColorButton_Click);
         // 
         // _fontColorPanel
         // 
         this._fontColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._fontColorPanel.Location = new System.Drawing.Point(124, 122);
         this._fontColorPanel.Name = "_fontColorPanel";
         this._fontColorPanel.Size = new System.Drawing.Size(71, 23);
         this._fontColorPanel.TabIndex = 12;
         this._controlsToolTip.SetToolTip(this._fontColorPanel, "The font (foreground) color used when rendering Text documents");
         // 
         // _fontColorLabel
         // 
         this._fontColorLabel.AutoSize = true;
         this._fontColorLabel.Location = new System.Drawing.Point(18, 127);
         this._fontColorLabel.Name = "_fontColorLabel";
         this._fontColorLabel.Size = new System.Drawing.Size(57, 13);
         this._fontColorLabel.TabIndex = 11;
         this._fontColorLabel.Text = "F&ont color:";
         // 
         // _fontLabel
         // 
         this._fontLabel.AutoSize = true;
         this._fontLabel.Location = new System.Drawing.Point(18, 75);
         this._fontLabel.Name = "_fontLabel";
         this._fontLabel.Size = new System.Drawing.Size(31, 13);
         this._fontLabel.TabIndex = 2;
         this._fontLabel.Text = "&Font:";
         // 
         // _enabledCheckBox
         // 
         this._enabledCheckBox.AutoSize = true;
         this._enabledCheckBox.Location = new System.Drawing.Point(21, 19);
         this._enabledCheckBox.Name = "_enabledCheckBox";
         this._enabledCheckBox.Size = new System.Drawing.Size(65, 17);
         this._enabledCheckBox.TabIndex = 0;
         this._enabledCheckBox.Text = "&Enabled";
         this._controlsToolTip.SetToolTip(this._enabledCheckBox, "Enable or disable the LEADTOOLS TXT codecs. If disable, TXT files will not be loa" +
                 "ded but overall system performance will be faster");
         this._enabledCheckBox.UseVisualStyleBackColor = true;
         // 
         // _backColorButton
         // 
         this._backColorButton.Location = new System.Drawing.Point(201, 151);
         this._backColorButton.Name = "_backColorButton";
         this._backColorButton.Size = new System.Drawing.Size(25, 23);
         this._backColorButton.TabIndex = 16;
         this._backColorButton.Text = "...";
         this._controlsToolTip.SetToolTip(this._backColorButton, "Change the background color used when rendering Text documents");
         this._backColorButton.UseVisualStyleBackColor = true;
         this._backColorButton.Click += new System.EventHandler(this._backColorButton_Click);
         // 
         // _backColorPanel
         // 
         this._backColorPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._backColorPanel.Location = new System.Drawing.Point(124, 151);
         this._backColorPanel.Name = "_backColorPanel";
         this._backColorPanel.Size = new System.Drawing.Size(71, 23);
         this._backColorPanel.TabIndex = 15;
         this._controlsToolTip.SetToolTip(this._backColorPanel, "The background color used when rendering Text documents");
         // 
         // _backColorLabel
         // 
         this._backColorLabel.AutoSize = true;
         this._backColorLabel.Location = new System.Drawing.Point(18, 156);
         this._backColorLabel.Name = "_backColorLabel";
         this._backColorLabel.Size = new System.Drawing.Size(61, 13);
         this._backColorLabel.TabIndex = 14;
         this._backColorLabel.Text = "&Back color:";
         // 
         // _controlsToolTip
         // 
         this._controlsToolTip.IsBalloon = true;
         this._controlsToolTip.ShowAlways = true;
         // 
         // TxtOptionsControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._generalTxtLoadOptionsGroupBox);
         this.Name = "TxtOptionsControl";
         this.Size = new System.Drawing.Size(500, 230);
         this._generalTxtLoadOptionsGroupBox.ResumeLayout(false);
         this._generalTxtLoadOptionsGroupBox.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _generalTxtLoadOptionsGroupBox;
      private System.Windows.Forms.Label _backColorLabel;
      private System.Windows.Forms.Panel _backColorPanel;
      private System.Windows.Forms.Button _backColorButton;
      private System.Windows.Forms.ToolTip _controlsToolTip;
      private System.Windows.Forms.CheckBox _enabledCheckBox;
      private System.Windows.Forms.Label _fontLabel;
      private System.Windows.Forms.Button _highlightColorButton;
      private System.Windows.Forms.Panel _highlightColorPanel;
      private System.Windows.Forms.Label _highlightColorLabel;
      private System.Windows.Forms.Button _fontColorButton;
      private System.Windows.Forms.Panel _fontColorPanel;
      private System.Windows.Forms.Label _fontColorLabel;
      private System.Windows.Forms.CheckBox _useSystenLocaleCheckBox;
      private System.Windows.Forms.Button _resetToDefaultsButton;
      private System.Windows.Forms.CheckBox _fontUnderlineCheckBox;
      private System.Windows.Forms.CheckBox _fontItalicCheckBox;
      private System.Windows.Forms.CheckBox _fontBoldCheckBox;
      private System.Windows.Forms.ComboBox _fontSizeComboBox;
      private System.Windows.Forms.Label _fontSizeLabel;
      private System.Windows.Forms.ComboBox _fontNameComboBox;
      private System.Windows.Forms.CheckBox _fontStrikethroughCheckBox;
   }
}
