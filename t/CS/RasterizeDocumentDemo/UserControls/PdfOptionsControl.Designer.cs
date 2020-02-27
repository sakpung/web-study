namespace RasterizeDocumentDemo.UserControls
{
   partial class PdfOptionsControl
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
         this._generalPdfLoadOptionsGroupBox = new System.Windows.Forms.GroupBox();
         this._resetToDefaultsButton = new System.Windows.Forms.Button();
         this._passwordTextBox = new System.Windows.Forms.TextBox();
         this._passwordLabel = new System.Windows.Forms.Label();
         this._displayCieColorsCheckBox = new System.Windows.Forms.CheckBox();
         this._disableCroppingCheckBox = new System.Windows.Forms.CheckBox();
         this._graphicsAlphaComboBox = new System.Windows.Forms.ComboBox();
         this._graphicsAlphaLabel = new System.Windows.Forms.Label();
         this._textAlphaComboBox = new System.Windows.Forms.ComboBox();
         this._textAlphaLabel = new System.Windows.Forms.Label();
         this._displayDepthComboBox = new System.Windows.Forms.ComboBox();
         this._displayDepthLabel = new System.Windows.Forms.Label();
         this._useLibFontsCheckBox = new System.Windows.Forms.CheckBox();
         this._controlsToolTip = new System.Windows.Forms.ToolTip(this.components);
         this._generalPdfLoadOptionsGroupBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // _generalPdfLoadOptionsGroupBox
         // 
         this._generalPdfLoadOptionsGroupBox.Controls.Add(this._resetToDefaultsButton);
         this._generalPdfLoadOptionsGroupBox.Controls.Add(this._passwordTextBox);
         this._generalPdfLoadOptionsGroupBox.Controls.Add(this._passwordLabel);
         this._generalPdfLoadOptionsGroupBox.Controls.Add(this._displayCieColorsCheckBox);
         this._generalPdfLoadOptionsGroupBox.Controls.Add(this._disableCroppingCheckBox);
         this._generalPdfLoadOptionsGroupBox.Controls.Add(this._graphicsAlphaComboBox);
         this._generalPdfLoadOptionsGroupBox.Controls.Add(this._graphicsAlphaLabel);
         this._generalPdfLoadOptionsGroupBox.Controls.Add(this._textAlphaComboBox);
         this._generalPdfLoadOptionsGroupBox.Controls.Add(this._textAlphaLabel);
         this._generalPdfLoadOptionsGroupBox.Controls.Add(this._displayDepthComboBox);
         this._generalPdfLoadOptionsGroupBox.Controls.Add(this._displayDepthLabel);
         this._generalPdfLoadOptionsGroupBox.Controls.Add(this._useLibFontsCheckBox);
         this._generalPdfLoadOptionsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
         this._generalPdfLoadOptionsGroupBox.Location = new System.Drawing.Point(0, 0);
         this._generalPdfLoadOptionsGroupBox.Name = "_generalPdfLoadOptionsGroupBox";
         this._generalPdfLoadOptionsGroupBox.Size = new System.Drawing.Size(500, 230);
         this._generalPdfLoadOptionsGroupBox.TabIndex = 0;
         this._generalPdfLoadOptionsGroupBox.TabStop = false;
         this._generalPdfLoadOptionsGroupBox.Text = "General Adobe Portable Format (PDF), Postscript (PS) and Enhanced Postscript (EPS) load options:";
         // 
         // _resetToDefaultsButton
         // 
         this._resetToDefaultsButton.Location = new System.Drawing.Point(305, 201);
         this._resetToDefaultsButton.Name = "_resetToDefaultsButton";
         this._resetToDefaultsButton.Size = new System.Drawing.Size(189, 23);
         this._resetToDefaultsButton.TabIndex = 11;
         this._resetToDefaultsButton.Text = "Reset to defa&ults";
         this._controlsToolTip.SetToolTip(this._resetToDefaultsButton, "Reset the options to LEADTOOLS default values");
         this._resetToDefaultsButton.UseVisualStyleBackColor = true;
         this._resetToDefaultsButton.Click += new System.EventHandler(this._resetToDefaultsButton_Click);
         // 
         // _passwordTextBox
         // 
         this._passwordTextBox.Location = new System.Drawing.Point(114, 113);
         this._passwordTextBox.Name = "_passwordTextBox";
         this._passwordTextBox.PasswordChar = '*';
         this._passwordTextBox.Size = new System.Drawing.Size(194, 20);
         this._passwordTextBox.TabIndex = 7;
         this._controlsToolTip.SetToolTip(this._passwordTextBox, "The user password to be used with encrypted PDF files");
         // 
         // _passwordLabel
         // 
         this._passwordLabel.AutoSize = true;
         this._passwordLabel.Location = new System.Drawing.Point(13, 116);
         this._passwordLabel.Name = "_passwordLabel";
         this._passwordLabel.Size = new System.Drawing.Size(56, 13);
         this._passwordLabel.TabIndex = 6;
         this._passwordLabel.Text = "&Password:";
         // 
         // _displayCieColorsCheckBox
         // 
         this._displayCieColorsCheckBox.AutoSize = true;
         this._displayCieColorsCheckBox.Location = new System.Drawing.Point(340, 88);
         this._displayCieColorsCheckBox.Name = "_displayCieColorsCheckBox";
         this._displayCieColorsCheckBox.Size = new System.Drawing.Size(112, 17);
         this._displayCieColorsCheckBox.TabIndex = 10;
         this._displayCieColorsCheckBox.Text = "Disable &CIE colors";
         this._controlsToolTip.SetToolTip(this._displayCieColorsCheckBox, "Enable or disable using CIE colors for both PDF and PostScript (PS) files");
         this._displayCieColorsCheckBox.UseVisualStyleBackColor = true;
         // 
         // _disableCroppingCheckBox
         // 
         this._disableCroppingCheckBox.AutoSize = true;
         this._disableCroppingCheckBox.Location = new System.Drawing.Point(340, 61);
         this._disableCroppingCheckBox.Name = "_disableCroppingCheckBox";
         this._disableCroppingCheckBox.Size = new System.Drawing.Size(105, 17);
         this._disableCroppingCheckBox.TabIndex = 9;
         this._disableCroppingCheckBox.Text = "Disable c&ropping";
         this._controlsToolTip.SetToolTip(this._disableCroppingCheckBox, "Enable or disable cropping for PostScript (PS) files to actual drawing size");
         this._disableCroppingCheckBox.UseVisualStyleBackColor = true;
         // 
         // _graphicsAlphaComboBox
         // 
         this._graphicsAlphaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._graphicsAlphaComboBox.FormattingEnabled = true;
         this._graphicsAlphaComboBox.Location = new System.Drawing.Point(114, 86);
         this._graphicsAlphaComboBox.Name = "_graphicsAlphaComboBox";
         this._graphicsAlphaComboBox.Size = new System.Drawing.Size(194, 21);
         this._graphicsAlphaComboBox.TabIndex = 5;
         this._controlsToolTip.SetToolTip(this._graphicsAlphaComboBox, "The type of anti-aliasing to use when rendering graphics");
         // 
         // _graphicsAlphaLabel
         // 
         this._graphicsAlphaLabel.AutoSize = true;
         this._graphicsAlphaLabel.Location = new System.Drawing.Point(13, 89);
         this._graphicsAlphaLabel.Name = "_graphicsAlphaLabel";
         this._graphicsAlphaLabel.Size = new System.Drawing.Size(81, 13);
         this._graphicsAlphaLabel.TabIndex = 4;
         this._graphicsAlphaLabel.Text = "&Graphics alpha:";
         // 
         // _textAlphaComboBox
         // 
         this._textAlphaComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._textAlphaComboBox.FormattingEnabled = true;
         this._textAlphaComboBox.Location = new System.Drawing.Point(114, 59);
         this._textAlphaComboBox.Name = "_textAlphaComboBox";
         this._textAlphaComboBox.Size = new System.Drawing.Size(194, 21);
         this._textAlphaComboBox.TabIndex = 3;
         this._controlsToolTip.SetToolTip(this._textAlphaComboBox, "The type of anti-aliasing to use when rendering text");
         // 
         // _textAlphaLabel
         // 
         this._textAlphaLabel.AutoSize = true;
         this._textAlphaLabel.Location = new System.Drawing.Point(13, 62);
         this._textAlphaLabel.Name = "_textAlphaLabel";
         this._textAlphaLabel.Size = new System.Drawing.Size(60, 13);
         this._textAlphaLabel.TabIndex = 2;
         this._textAlphaLabel.Text = "&Text alpha:";
         // 
         // _displayDepthComboBox
         // 
         this._displayDepthComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._displayDepthComboBox.FormattingEnabled = true;
         this._displayDepthComboBox.Location = new System.Drawing.Point(114, 32);
         this._displayDepthComboBox.Name = "_displayDepthComboBox";
         this._displayDepthComboBox.Size = new System.Drawing.Size(194, 21);
         this._displayDepthComboBox.TabIndex = 1;
         this._controlsToolTip.SetToolTip(this._displayDepthComboBox, "The resulting image pixel per pixel");
         // 
         // _displayDepthLabel
         // 
         this._displayDepthLabel.AutoSize = true;
         this._displayDepthLabel.Location = new System.Drawing.Point(13, 35);
         this._displayDepthLabel.Name = "_displayDepthLabel";
         this._displayDepthLabel.Size = new System.Drawing.Size(74, 13);
         this._displayDepthLabel.TabIndex = 0;
         this._displayDepthLabel.Text = "&Display depth:";
         // 
         // _useLibFontsCheckBox
         // 
         this._useLibFontsCheckBox.AutoSize = true;
         this._useLibFontsCheckBox.Location = new System.Drawing.Point(340, 34);
         this._useLibFontsCheckBox.Name = "_useLibFontsCheckBox";
         this._useLibFontsCheckBox.Size = new System.Drawing.Size(101, 17);
         this._useLibFontsCheckBox.TabIndex = 8;
         this._useLibFontsCheckBox.Text = "&Use library fonts";
         this._controlsToolTip.SetToolTip(this._useLibFontsCheckBox, "Use the library installed fonts, otherwise use the system fonts");
         this._useLibFontsCheckBox.UseVisualStyleBackColor = true;
         // 
         // _controlsToolTip
         // 
         this._controlsToolTip.IsBalloon = true;
         this._controlsToolTip.ShowAlways = true;
         // 
         // PdfOptionsControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._generalPdfLoadOptionsGroupBox);
         this.Name = "PdfOptionsControl";
         this.Size = new System.Drawing.Size(500, 230);
         this._generalPdfLoadOptionsGroupBox.ResumeLayout(false);
         this._generalPdfLoadOptionsGroupBox.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _generalPdfLoadOptionsGroupBox;
      private System.Windows.Forms.Button _resetToDefaultsButton;
      private System.Windows.Forms.TextBox _passwordTextBox;
      private System.Windows.Forms.Label _passwordLabel;
      private System.Windows.Forms.CheckBox _displayCieColorsCheckBox;
      private System.Windows.Forms.CheckBox _disableCroppingCheckBox;
      private System.Windows.Forms.ComboBox _graphicsAlphaComboBox;
      private System.Windows.Forms.Label _graphicsAlphaLabel;
      private System.Windows.Forms.ComboBox _textAlphaComboBox;
      private System.Windows.Forms.Label _textAlphaLabel;
      private System.Windows.Forms.ComboBox _displayDepthComboBox;
      private System.Windows.Forms.Label _displayDepthLabel;
      private System.Windows.Forms.CheckBox _useLibFontsCheckBox;
      private System.Windows.Forms.ToolTip _controlsToolTip;
   }
}
