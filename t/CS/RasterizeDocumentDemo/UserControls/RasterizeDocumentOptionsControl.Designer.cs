namespace RasterizeDocumentDemo.UserControls
{
   partial class RasterizeDocumentOptionsControl
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
         this._rasterizeDocumentLoadOptionsGroupBox = new System.Windows.Forms.GroupBox();
         this._bottomMarginTextBox = new System.Windows.Forms.TextBox();
         this._bottomMarginLabel = new System.Windows.Forms.Label();
         this._rightMarginTextBox = new System.Windows.Forms.TextBox();
         this._rightMarginLabel = new System.Windows.Forms.Label();
         this._topMarginTextBox = new System.Windows.Forms.TextBox();
         this._topMarginLabel = new System.Windows.Forms.Label();
         this._leftMarginTextBox = new System.Windows.Forms.TextBox();
         this._leftMarginLabel = new System.Windows.Forms.Label();
         this._sizeModeHelp = new System.Windows.Forms.Label();
         this._sizeModeComboBox = new System.Windows.Forms.ComboBox();
         this._sizeModeLabel = new System.Windows.Forms.Label();
         this._unitComboBox = new System.Windows.Forms.ComboBox();
         this._unitLabel = new System.Windows.Forms.Label();
         this._resolutionComboBox = new System.Windows.Forms.ComboBox();
         this._resolutionLabel = new System.Windows.Forms.Label();
         this._pageHeightTextBox = new System.Windows.Forms.TextBox();
         this._pageHeightLabel = new System.Windows.Forms.Label();
         this._pageWidthTextBox = new System.Windows.Forms.TextBox();
         this._pageWidthLabel = new System.Windows.Forms.Label();
         this._resetToDefaultsButton = new System.Windows.Forms.Button();
         this._controlsToolTip = new System.Windows.Forms.ToolTip(this.components);
         this._rasterizeDocumentLoadOptionsGroupBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // _rasterizeDocumentLoadOptionsGroupBox
         // 
         this._rasterizeDocumentLoadOptionsGroupBox.Controls.Add(this._bottomMarginTextBox);
         this._rasterizeDocumentLoadOptionsGroupBox.Controls.Add(this._bottomMarginLabel);
         this._rasterizeDocumentLoadOptionsGroupBox.Controls.Add(this._rightMarginTextBox);
         this._rasterizeDocumentLoadOptionsGroupBox.Controls.Add(this._rightMarginLabel);
         this._rasterizeDocumentLoadOptionsGroupBox.Controls.Add(this._topMarginTextBox);
         this._rasterizeDocumentLoadOptionsGroupBox.Controls.Add(this._topMarginLabel);
         this._rasterizeDocumentLoadOptionsGroupBox.Controls.Add(this._leftMarginTextBox);
         this._rasterizeDocumentLoadOptionsGroupBox.Controls.Add(this._leftMarginLabel);
         this._rasterizeDocumentLoadOptionsGroupBox.Controls.Add(this._sizeModeHelp);
         this._rasterizeDocumentLoadOptionsGroupBox.Controls.Add(this._sizeModeComboBox);
         this._rasterizeDocumentLoadOptionsGroupBox.Controls.Add(this._sizeModeLabel);
         this._rasterizeDocumentLoadOptionsGroupBox.Controls.Add(this._unitComboBox);
         this._rasterizeDocumentLoadOptionsGroupBox.Controls.Add(this._unitLabel);
         this._rasterizeDocumentLoadOptionsGroupBox.Controls.Add(this._resolutionComboBox);
         this._rasterizeDocumentLoadOptionsGroupBox.Controls.Add(this._resolutionLabel);
         this._rasterizeDocumentLoadOptionsGroupBox.Controls.Add(this._pageHeightTextBox);
         this._rasterizeDocumentLoadOptionsGroupBox.Controls.Add(this._pageHeightLabel);
         this._rasterizeDocumentLoadOptionsGroupBox.Controls.Add(this._pageWidthTextBox);
         this._rasterizeDocumentLoadOptionsGroupBox.Controls.Add(this._pageWidthLabel);
         this._rasterizeDocumentLoadOptionsGroupBox.Controls.Add(this._resetToDefaultsButton);
         this._rasterizeDocumentLoadOptionsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
         this._rasterizeDocumentLoadOptionsGroupBox.Location = new System.Drawing.Point(0, 0);
         this._rasterizeDocumentLoadOptionsGroupBox.Name = "_rasterizeDocumentLoadOptionsGroupBox";
         this._rasterizeDocumentLoadOptionsGroupBox.Size = new System.Drawing.Size(500, 230);
         this._rasterizeDocumentLoadOptionsGroupBox.TabIndex = 0;
         this._rasterizeDocumentLoadOptionsGroupBox.TabStop = false;
         this._rasterizeDocumentLoadOptionsGroupBox.Text = "Load the document at the specific size and resolution:";
         // 
         // _bottomMarginTextBox
         // 
         this._bottomMarginTextBox.Location = new System.Drawing.Point(106, 149);
         this._bottomMarginTextBox.Name = "_bottomMarginTextBox";
         this._bottomMarginTextBox.Size = new System.Drawing.Size(100, 20);
         this._bottomMarginTextBox.TabIndex = 11;
         this._controlsToolTip.SetToolTip(this._bottomMarginTextBox, "The page bottom margin of the document (in unit)");
         this._bottomMarginTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._textBox_KeyPress);
         // 
         // _bottomMarginLabel
         // 
         this._bottomMarginLabel.AutoSize = true;
         this._bottomMarginLabel.Location = new System.Drawing.Point(21, 152);
         this._bottomMarginLabel.Name = "_bottomMarginLabel";
         this._bottomMarginLabel.Size = new System.Drawing.Size(77, 13);
         this._bottomMarginLabel.TabIndex = 10;
         this._bottomMarginLabel.Text = "&Bottom margin:";
         // 
         // _rightMarginTextBox
         // 
         this._rightMarginTextBox.Location = new System.Drawing.Point(106, 123);
         this._rightMarginTextBox.Name = "_rightMarginTextBox";
         this._rightMarginTextBox.Size = new System.Drawing.Size(100, 20);
         this._rightMarginTextBox.TabIndex = 9;
         this._controlsToolTip.SetToolTip(this._rightMarginTextBox, "The page right margin of the document (in unit)");
         this._rightMarginTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._textBox_KeyPress);
         // 
         // _rightMarginLabel
         // 
         this._rightMarginLabel.AutoSize = true;
         this._rightMarginLabel.Location = new System.Drawing.Point(21, 126);
         this._rightMarginLabel.Name = "_rightMarginLabel";
         this._rightMarginLabel.Size = new System.Drawing.Size(69, 13);
         this._rightMarginLabel.TabIndex = 8;
         this._rightMarginLabel.Text = "&Right margin:";
         // 
         // _topMarginTextBox
         // 
         this._topMarginTextBox.Location = new System.Drawing.Point(106, 97);
         this._topMarginTextBox.Name = "_topMarginTextBox";
         this._topMarginTextBox.Size = new System.Drawing.Size(100, 20);
         this._topMarginTextBox.TabIndex = 7;
         this._controlsToolTip.SetToolTip(this._topMarginTextBox, "The page top margin of the document (in unit)");
         this._topMarginTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._textBox_KeyPress);
         // 
         // _topMarginLabel
         // 
         this._topMarginLabel.AutoSize = true;
         this._topMarginLabel.Location = new System.Drawing.Point(21, 100);
         this._topMarginLabel.Name = "_topMarginLabel";
         this._topMarginLabel.Size = new System.Drawing.Size(63, 13);
         this._topMarginLabel.TabIndex = 6;
         this._topMarginLabel.Text = "&Top margin:";
         // 
         // _leftMarginTextBox
         // 
         this._leftMarginTextBox.Location = new System.Drawing.Point(106, 71);
         this._leftMarginTextBox.Name = "_leftMarginTextBox";
         this._leftMarginTextBox.Size = new System.Drawing.Size(100, 20);
         this._leftMarginTextBox.TabIndex = 5;
         this._controlsToolTip.SetToolTip(this._leftMarginTextBox, "The page left margin of the document (in unit)");
         this._leftMarginTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._textBox_KeyPress);
         // 
         // _leftMarginLabel
         // 
         this._leftMarginLabel.AutoSize = true;
         this._leftMarginLabel.Location = new System.Drawing.Point(21, 74);
         this._leftMarginLabel.Name = "_leftMarginLabel";
         this._leftMarginLabel.Size = new System.Drawing.Size(62, 13);
         this._leftMarginLabel.TabIndex = 4;
         this._leftMarginLabel.Text = "&Left margin:";
         // 
         // _sizeModeHelp
         // 
         this._sizeModeHelp.Location = new System.Drawing.Point(251, 51);
         this._sizeModeHelp.Name = "_sizeModeHelp";
         this._sizeModeHelp.Size = new System.Drawing.Size(240, 140);
         this._sizeModeHelp.TabIndex = 18;
         this._sizeModeHelp.Text = "###";
         // 
         // _sizeModeComboBox
         // 
         this._sizeModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._sizeModeComboBox.FormattingEnabled = true;
         this._sizeModeComboBox.Location = new System.Drawing.Point(314, 19);
         this._sizeModeComboBox.Name = "_sizeModeComboBox";
         this._sizeModeComboBox.Size = new System.Drawing.Size(121, 21);
         this._sizeModeComboBox.TabIndex = 17;
         this._controlsToolTip.SetToolTip(this._sizeModeComboBox, "Select the method to fit or stretch the doucment into width and height");
         this._sizeModeComboBox.SelectedIndexChanged += new System.EventHandler(this._sizeModeComboBox_SelectedIndexChanged);
         // 
         // _sizeModeLabel
         // 
         this._sizeModeLabel.AutoSize = true;
         this._sizeModeLabel.Location = new System.Drawing.Point(248, 22);
         this._sizeModeLabel.Name = "_sizeModeLabel";
         this._sizeModeLabel.Size = new System.Drawing.Size(59, 13);
         this._sizeModeLabel.TabIndex = 16;
         this._sizeModeLabel.Text = "&Size mode:";
         // 
         // _unitComboBox
         // 
         this._unitComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._unitComboBox.FormattingEnabled = true;
         this._unitComboBox.Location = new System.Drawing.Point(106, 175);
         this._unitComboBox.Name = "_unitComboBox";
         this._unitComboBox.Size = new System.Drawing.Size(121, 21);
         this._unitComboBox.TabIndex = 13;
         this._controlsToolTip.SetToolTip(this._unitComboBox, "Unit of page width, height and margins");
         this._unitComboBox.SelectedIndexChanged += new System.EventHandler(this._unitComboBox_SelectedIndexChanged);
         // 
         // _unitLabel
         // 
         this._unitLabel.AutoSize = true;
         this._unitLabel.Location = new System.Drawing.Point(21, 178);
         this._unitLabel.Name = "_unitLabel";
         this._unitLabel.Size = new System.Drawing.Size(29, 13);
         this._unitLabel.TabIndex = 12;
         this._unitLabel.Text = "&Unit:";
         // 
         // _resolutionComboBox
         // 
         this._resolutionComboBox.FormattingEnabled = true;
         this._resolutionComboBox.Items.AddRange(new object[] {
            "0",
            "10",
            "72",
            "96",
            "110",
            "150",
            "200",
            "300",
            "400",
            "600",
            "1200",
            "2400",
            "4800"});
         this._resolutionComboBox.Location = new System.Drawing.Point(106, 202);
         this._resolutionComboBox.Name = "_resolutionComboBox";
         this._resolutionComboBox.Size = new System.Drawing.Size(121, 21);
         this._resolutionComboBox.TabIndex = 15;
         this._controlsToolTip.SetToolTip(this._resolutionComboBox, "Resolution to use when loading the document. Select 0 for current screen resoluti" +
                 "on");
         this._resolutionComboBox.SelectedIndexChanged += new System.EventHandler(this._resolutionComboBox_SelectedIndexChanged);
         this._resolutionComboBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._resolutionComboBox_KeyPress);
         // 
         // _resolutionLabel
         // 
         this._resolutionLabel.AutoSize = true;
         this._resolutionLabel.Location = new System.Drawing.Point(21, 205);
         this._resolutionLabel.Name = "_resolutionLabel";
         this._resolutionLabel.Size = new System.Drawing.Size(60, 13);
         this._resolutionLabel.TabIndex = 14;
         this._resolutionLabel.Text = "&Resolution:";
         // 
         // _pageHeightTextBox
         // 
         this._pageHeightTextBox.Location = new System.Drawing.Point(106, 45);
         this._pageHeightTextBox.Name = "_pageHeightTextBox";
         this._pageHeightTextBox.Size = new System.Drawing.Size(100, 20);
         this._pageHeightTextBox.TabIndex = 3;
         this._controlsToolTip.SetToolTip(this._pageHeightTextBox, "The page height of the document (in unit)");
         this._pageHeightTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._textBox_KeyPress);
         // 
         // _pageHeightLabel
         // 
         this._pageHeightLabel.AutoSize = true;
         this._pageHeightLabel.Location = new System.Drawing.Point(21, 48);
         this._pageHeightLabel.Name = "_pageHeightLabel";
         this._pageHeightLabel.Size = new System.Drawing.Size(67, 13);
         this._pageHeightLabel.TabIndex = 2;
         this._pageHeightLabel.Text = "Page &height:";
         // 
         // _pageWidthTextBox
         // 
         this._pageWidthTextBox.Location = new System.Drawing.Point(106, 19);
         this._pageWidthTextBox.Name = "_pageWidthTextBox";
         this._pageWidthTextBox.Size = new System.Drawing.Size(100, 20);
         this._pageWidthTextBox.TabIndex = 1;
         this._controlsToolTip.SetToolTip(this._pageWidthTextBox, "The page width of the document (in unit)");
         this._pageWidthTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._textBox_KeyPress);
         // 
         // _pageWidthLabel
         // 
         this._pageWidthLabel.AutoSize = true;
         this._pageWidthLabel.Location = new System.Drawing.Point(21, 22);
         this._pageWidthLabel.Name = "_pageWidthLabel";
         this._pageWidthLabel.Size = new System.Drawing.Size(63, 13);
         this._pageWidthLabel.TabIndex = 0;
         this._pageWidthLabel.Text = "Page &width:";
         // 
         // _resetToDefaultsButton
         // 
         this._resetToDefaultsButton.Location = new System.Drawing.Point(305, 201);
         this._resetToDefaultsButton.Name = "_resetToDefaultsButton";
         this._resetToDefaultsButton.Size = new System.Drawing.Size(189, 23);
         this._resetToDefaultsButton.TabIndex = 19;
         this._resetToDefaultsButton.Text = "Reset to defa&ults";
         this._controlsToolTip.SetToolTip(this._resetToDefaultsButton, "Reset the options to LEADTOOLS default values");
         this._resetToDefaultsButton.UseVisualStyleBackColor = true;
         this._resetToDefaultsButton.Click += new System.EventHandler(this._resetToDefaultsButton_Click);
         // 
         // _controlsToolTip
         // 
         this._controlsToolTip.IsBalloon = true;
         this._controlsToolTip.ShowAlways = true;
         // 
         // RasterizeDocumentOptionsControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._rasterizeDocumentLoadOptionsGroupBox);
         this.Name = "RasterizeDocumentOptionsControl";
         this.Size = new System.Drawing.Size(500, 230);
         this._rasterizeDocumentLoadOptionsGroupBox.ResumeLayout(false);
         this._rasterizeDocumentLoadOptionsGroupBox.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _rasterizeDocumentLoadOptionsGroupBox;
      private System.Windows.Forms.ToolTip _controlsToolTip;
      private System.Windows.Forms.Button _resetToDefaultsButton;
      private System.Windows.Forms.Label _sizeModeHelp;
      private System.Windows.Forms.ComboBox _sizeModeComboBox;
      private System.Windows.Forms.Label _sizeModeLabel;
      private System.Windows.Forms.ComboBox _unitComboBox;
      private System.Windows.Forms.Label _unitLabel;
      private System.Windows.Forms.ComboBox _resolutionComboBox;
      private System.Windows.Forms.Label _resolutionLabel;
      private System.Windows.Forms.TextBox _pageHeightTextBox;
      private System.Windows.Forms.Label _pageHeightLabel;
      private System.Windows.Forms.TextBox _pageWidthTextBox;
      private System.Windows.Forms.Label _pageWidthLabel;
      private System.Windows.Forms.TextBox _bottomMarginTextBox;
      private System.Windows.Forms.Label _bottomMarginLabel;
      private System.Windows.Forms.TextBox _rightMarginTextBox;
      private System.Windows.Forms.Label _rightMarginLabel;
      private System.Windows.Forms.TextBox _topMarginTextBox;
      private System.Windows.Forms.Label _topMarginLabel;
      private System.Windows.Forms.TextBox _leftMarginTextBox;
      private System.Windows.Forms.Label _leftMarginLabel;
   }
}
