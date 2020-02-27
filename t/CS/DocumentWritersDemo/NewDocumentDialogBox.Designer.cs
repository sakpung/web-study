namespace DocumentWritersDemo
{
   partial class NewDocumentDialogBox
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

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         this._okButton = new System.Windows.Forms.Button();
         this._cancelButton = new System.Windows.Forms.Button();
         this._widthLabel = new System.Windows.Forms.Label();
         this._heightLabel = new System.Windows.Forms.Label();
         this._dimensionsGroupBox = new System.Windows.Forms.GroupBox();
         this._heightNumericUpDown = new System.Windows.Forms.NumericUpDown();
         this._widthNumericUpDown = new System.Windows.Forms.NumericUpDown();
         this._pixelsInchesLabel = new System.Windows.Forms.Label();
         this._physicalSizeValueLabel = new System.Windows.Forms.Label();
         this._pixelsLabel = new System.Windows.Forms.Label();
         this._physicalSizeLabel = new System.Windows.Forms.Label();
         this._resolutionComboBox = new System.Windows.Forms.ComboBox();
         this._resolutionLabel = new System.Windows.Forms.Label();
         this._heightInchesLabel = new System.Windows.Forms.Label();
         this._widthInchesLabel = new System.Windows.Forms.Label();
         this._defaultButton = new System.Windows.Forms.Button();
         this._dimensionsGroupBox.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._heightNumericUpDown)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._widthNumericUpDown)).BeginInit();
         this.SuspendLayout();
         // 
         // _okButton
         // 
         this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._okButton.Location = new System.Drawing.Point(231, 193);
         this._okButton.Name = "_okButton";
         this._okButton.Size = new System.Drawing.Size(75, 23);
         this._okButton.TabIndex = 1;
         this._okButton.Text = "OK";
         this._okButton.UseVisualStyleBackColor = true;
         this._okButton.Click += new System.EventHandler(this._okButton_Click);
         // 
         // _cancelButton
         // 
         this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._cancelButton.Location = new System.Drawing.Point(312, 193);
         this._cancelButton.Name = "_cancelButton";
         this._cancelButton.Size = new System.Drawing.Size(75, 23);
         this._cancelButton.TabIndex = 2;
         this._cancelButton.Text = "Cancel";
         this._cancelButton.UseVisualStyleBackColor = true;
         // 
         // _widthLabel
         // 
         this._widthLabel.AutoSize = true;
         this._widthLabel.Location = new System.Drawing.Point(24, 37);
         this._widthLabel.Name = "_widthLabel";
         this._widthLabel.Size = new System.Drawing.Size(38, 13);
         this._widthLabel.TabIndex = 0;
         this._widthLabel.Text = "Width:";
         // 
         // _heightLabel
         // 
         this._heightLabel.AutoSize = true;
         this._heightLabel.Location = new System.Drawing.Point(24, 67);
         this._heightLabel.Name = "_heightLabel";
         this._heightLabel.Size = new System.Drawing.Size(41, 13);
         this._heightLabel.TabIndex = 3;
         this._heightLabel.Text = "Height:";
         // 
         // _dimensionsGroupBox
         // 
         this._dimensionsGroupBox.Controls.Add(this._heightNumericUpDown);
         this._dimensionsGroupBox.Controls.Add(this._widthNumericUpDown);
         this._dimensionsGroupBox.Controls.Add(this._pixelsInchesLabel);
         this._dimensionsGroupBox.Controls.Add(this._physicalSizeValueLabel);
         this._dimensionsGroupBox.Controls.Add(this._pixelsLabel);
         this._dimensionsGroupBox.Controls.Add(this._physicalSizeLabel);
         this._dimensionsGroupBox.Controls.Add(this._resolutionComboBox);
         this._dimensionsGroupBox.Controls.Add(this._resolutionLabel);
         this._dimensionsGroupBox.Controls.Add(this._heightInchesLabel);
         this._dimensionsGroupBox.Controls.Add(this._widthInchesLabel);
         this._dimensionsGroupBox.Controls.Add(this._widthLabel);
         this._dimensionsGroupBox.Controls.Add(this._heightLabel);
         this._dimensionsGroupBox.Location = new System.Drawing.Point(12, 12);
         this._dimensionsGroupBox.Name = "_dimensionsGroupBox";
         this._dimensionsGroupBox.Size = new System.Drawing.Size(375, 175);
         this._dimensionsGroupBox.TabIndex = 0;
         this._dimensionsGroupBox.TabStop = false;
         this._dimensionsGroupBox.Text = "&Dimensions";
         // 
         // _heightNumericUpDown
         // 
         this._heightNumericUpDown.DecimalPlaces = 2;
         this._heightNumericUpDown.Location = new System.Drawing.Point(105, 65);
         this._heightNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._heightNumericUpDown.Name = "_heightNumericUpDown";
         this._heightNumericUpDown.Size = new System.Drawing.Size(136, 20);
         this._heightNumericUpDown.TabIndex = 13;
         this._heightNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._heightNumericUpDown.ValueChanged += new System.EventHandler(this._numericUpDown_ValueChanged);
         // 
         // _widthNumericUpDown
         // 
         this._widthNumericUpDown.DecimalPlaces = 2;
         this._widthNumericUpDown.Location = new System.Drawing.Point(105, 35);
         this._widthNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._widthNumericUpDown.Name = "_widthNumericUpDown";
         this._widthNumericUpDown.Size = new System.Drawing.Size(136, 20);
         this._widthNumericUpDown.TabIndex = 12;
         this._widthNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._widthNumericUpDown.ValueChanged += new System.EventHandler(this._numericUpDown_ValueChanged);
         // 
         // _pixelsInchesLabel
         // 
         this._pixelsInchesLabel.AutoSize = true;
         this._pixelsInchesLabel.Location = new System.Drawing.Point(247, 98);
         this._pixelsInchesLabel.Name = "_pixelsInchesLabel";
         this._pixelsInchesLabel.Size = new System.Drawing.Size(96, 13);
         this._pixelsInchesLabel.TabIndex = 8;
         this._pixelsInchesLabel.Text = "pixels/inches (DPI)";
         // 
         // _physicalSizeValueLabel
         // 
         this._physicalSizeValueLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this._physicalSizeValueLabel.Location = new System.Drawing.Point(105, 129);
         this._physicalSizeValueLabel.Name = "_physicalSizeValueLabel";
         this._physicalSizeValueLabel.Size = new System.Drawing.Size(136, 23);
         this._physicalSizeValueLabel.TabIndex = 10;
         this._physicalSizeValueLabel.Text = "label1";
         this._physicalSizeValueLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // _pixelsLabel
         // 
         this._pixelsLabel.AutoSize = true;
         this._pixelsLabel.Location = new System.Drawing.Point(247, 134);
         this._pixelsLabel.Name = "_pixelsLabel";
         this._pixelsLabel.Size = new System.Drawing.Size(33, 13);
         this._pixelsLabel.TabIndex = 11;
         this._pixelsLabel.Text = "pixels";
         // 
         // _physicalSizeLabel
         // 
         this._physicalSizeLabel.AutoSize = true;
         this._physicalSizeLabel.Location = new System.Drawing.Point(24, 134);
         this._physicalSizeLabel.Name = "_physicalSizeLabel";
         this._physicalSizeLabel.Size = new System.Drawing.Size(70, 13);
         this._physicalSizeLabel.TabIndex = 9;
         this._physicalSizeLabel.Text = "Physical size:";
         // 
         // _resolutionComboBox
         // 
         this._resolutionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._resolutionComboBox.FormattingEnabled = true;
         this._resolutionComboBox.Items.AddRange(new object[] {
            "75",
            "96",
            "192",
            "200",
            "300",
            "600",
            "1200"});
         this._resolutionComboBox.Location = new System.Drawing.Point(105, 95);
         this._resolutionComboBox.Name = "_resolutionComboBox";
         this._resolutionComboBox.Size = new System.Drawing.Size(136, 21);
         this._resolutionComboBox.TabIndex = 7;
         this._resolutionComboBox.SelectedIndexChanged += new System.EventHandler(this._resolutionComboBox_SelectedIndexChanged);
         // 
         // _resolutionLabel
         // 
         this._resolutionLabel.AutoSize = true;
         this._resolutionLabel.Location = new System.Drawing.Point(24, 98);
         this._resolutionLabel.Name = "_resolutionLabel";
         this._resolutionLabel.Size = new System.Drawing.Size(60, 13);
         this._resolutionLabel.TabIndex = 6;
         this._resolutionLabel.Text = "Resolution:";
         // 
         // _heightInchesLabel
         // 
         this._heightInchesLabel.AutoSize = true;
         this._heightInchesLabel.Location = new System.Drawing.Point(247, 67);
         this._heightInchesLabel.Name = "_heightInchesLabel";
         this._heightInchesLabel.Size = new System.Drawing.Size(38, 13);
         this._heightInchesLabel.TabIndex = 5;
         this._heightInchesLabel.Text = "inches";
         // 
         // _widthInchesLabel
         // 
         this._widthInchesLabel.AutoSize = true;
         this._widthInchesLabel.Location = new System.Drawing.Point(247, 37);
         this._widthInchesLabel.Name = "_widthInchesLabel";
         this._widthInchesLabel.Size = new System.Drawing.Size(38, 13);
         this._widthInchesLabel.TabIndex = 2;
         this._widthInchesLabel.Text = "inches";
         // 
         // _defaultButton
         // 
         this._defaultButton.Location = new System.Drawing.Point(12, 194);
         this._defaultButton.Name = "_defaultButton";
         this._defaultButton.Size = new System.Drawing.Size(121, 23);
         this._defaultButton.TabIndex = 3;
         this._defaultButton.Text = "Default dimension";
         this._defaultButton.UseVisualStyleBackColor = true;
         this._defaultButton.Click += new System.EventHandler(this._defaultButton_Click);
         // 
         // NewDocumentDialogBox
         // 
         this.AcceptButton = this._okButton;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._cancelButton;
         this.ClientSize = new System.Drawing.Size(400, 228);
         this.Controls.Add(this._defaultButton);
         this.Controls.Add(this._dimensionsGroupBox);
         this.Controls.Add(this._cancelButton);
         this.Controls.Add(this._okButton);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "NewDocumentDialogBox";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Create new document";
         this._dimensionsGroupBox.ResumeLayout(false);
         this._dimensionsGroupBox.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._heightNumericUpDown)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._widthNumericUpDown)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _okButton;
      private System.Windows.Forms.Button _cancelButton;
      private System.Windows.Forms.Label _widthLabel;
      private System.Windows.Forms.Label _heightLabel;
      private System.Windows.Forms.GroupBox _dimensionsGroupBox;
      private System.Windows.Forms.Label _widthInchesLabel;
      private System.Windows.Forms.Label _heightInchesLabel;
      private System.Windows.Forms.ComboBox _resolutionComboBox;
      private System.Windows.Forms.Label _resolutionLabel;
      private System.Windows.Forms.Label _physicalSizeValueLabel;
      private System.Windows.Forms.Label _pixelsLabel;
      private System.Windows.Forms.Label _physicalSizeLabel;
      private System.Windows.Forms.Label _pixelsInchesLabel;
      private System.Windows.Forms.NumericUpDown _widthNumericUpDown;
      private System.Windows.Forms.NumericUpDown _heightNumericUpDown;
      private System.Windows.Forms.Button _defaultButton;
   }
}