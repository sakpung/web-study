namespace DocumentWritersDemo
{
   partial class SavePdfDialog
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
         this._documentFileNameGroupBox = new System.Windows.Forms.GroupBox();
         this._browseDocumentFileNameButton = new System.Windows.Forms.Button();
         this._documentFileNameTextBox = new System.Windows.Forms.TextBox();
         this._pdfOptionsTabControl = new System.Windows.Forms.TabControl();
         this._generalTabPage = new System.Windows.Forms.TabPage();
         this._pdfAdvancedOptionsButton = new System.Windows.Forms.Button();
         this._resolutionNumericUpDown = new System.Windows.Forms.NumericUpDown();
         this._pixelsInchesLabel = new System.Windows.Forms.Label();
         this._resolutionComboBox = new System.Windows.Forms.ComboBox();
         this._resolutionLabel = new System.Windows.Forms.Label();
         this._documentTypeComboBox = new System.Windows.Forms.ComboBox();
         this._documentTypeLabel = new System.Windows.Forms.Label();
         this._pdfOptionsLabel = new System.Windows.Forms.Label();
         this._documentFileNameGroupBox.SuspendLayout();
         this._pdfOptionsTabControl.SuspendLayout();
         this._generalTabPage.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._resolutionNumericUpDown)).BeginInit();
         this.SuspendLayout();
         // 
         // _okButton
         // 
         this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._okButton.Location = new System.Drawing.Point(460, 291);
         this._okButton.Name = "_okButton";
         this._okButton.Size = new System.Drawing.Size(75, 23);
         this._okButton.TabIndex = 3;
         this._okButton.Text = "OK";
         this._okButton.UseVisualStyleBackColor = true;
         this._okButton.Click += new System.EventHandler(this._okButton_Click);
         // 
         // _cancelButton
         // 
         this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._cancelButton.Location = new System.Drawing.Point(541, 291);
         this._cancelButton.Name = "_cancelButton";
         this._cancelButton.Size = new System.Drawing.Size(75, 23);
         this._cancelButton.TabIndex = 4;
         this._cancelButton.Text = "Cancel";
         this._cancelButton.UseVisualStyleBackColor = true;
         // 
         // _documentFileNameGroupBox
         // 
         this._documentFileNameGroupBox.Controls.Add(this._browseDocumentFileNameButton);
         this._documentFileNameGroupBox.Controls.Add(this._documentFileNameTextBox);
         this._documentFileNameGroupBox.Location = new System.Drawing.Point(12, 12);
         this._documentFileNameGroupBox.Name = "_documentFileNameGroupBox";
         this._documentFileNameGroupBox.Size = new System.Drawing.Size(604, 70);
         this._documentFileNameGroupBox.TabIndex = 0;
         this._documentFileNameGroupBox.TabStop = false;
         this._documentFileNameGroupBox.Text = "Output document file name:";
         // 
         // _browseDocumentFileNameButton
         // 
         this._browseDocumentFileNameButton.Location = new System.Drawing.Point(559, 26);
         this._browseDocumentFileNameButton.Name = "_browseDocumentFileNameButton";
         this._browseDocumentFileNameButton.Size = new System.Drawing.Size(29, 23);
         this._browseDocumentFileNameButton.TabIndex = 1;
         this._browseDocumentFileNameButton.Text = "...";
         this._browseDocumentFileNameButton.UseVisualStyleBackColor = true;
         this._browseDocumentFileNameButton.Click += new System.EventHandler(this._browseDocumentFileNameButton_Click);
         // 
         // _documentFileNameTextBox
         // 
         this._documentFileNameTextBox.Location = new System.Drawing.Point(21, 28);
         this._documentFileNameTextBox.Name = "_documentFileNameTextBox";
         this._documentFileNameTextBox.Size = new System.Drawing.Size(532, 20);
         this._documentFileNameTextBox.TabIndex = 0;
         // 
         // _pdfOptionsTabControl
         // 
         this._pdfOptionsTabControl.Controls.Add(this._generalTabPage);
         this._pdfOptionsTabControl.Location = new System.Drawing.Point(8, 112);
         this._pdfOptionsTabControl.Name = "_pdfOptionsTabControl";
         this._pdfOptionsTabControl.SelectedIndex = 0;
         this._pdfOptionsTabControl.Size = new System.Drawing.Size(608, 173);
         this._pdfOptionsTabControl.TabIndex = 2;
         // 
         // _generalTabPage
         // 
         this._generalTabPage.Controls.Add(this._pdfAdvancedOptionsButton);
         this._generalTabPage.Controls.Add(this._resolutionNumericUpDown);
         this._generalTabPage.Controls.Add(this._pixelsInchesLabel);
         this._generalTabPage.Controls.Add(this._resolutionComboBox);
         this._generalTabPage.Controls.Add(this._resolutionLabel);
         this._generalTabPage.Controls.Add(this._documentTypeComboBox);
         this._generalTabPage.Controls.Add(this._documentTypeLabel);
         this._generalTabPage.Location = new System.Drawing.Point(4, 22);
         this._generalTabPage.Name = "_generalTabPage";
         this._generalTabPage.Size = new System.Drawing.Size(600, 147);
         this._generalTabPage.TabIndex = 0;
         this._generalTabPage.Text = "General";
         this._generalTabPage.UseVisualStyleBackColor = true;
         // 
         // _pdfAdvancedOptionsButton
         // 
         this._pdfAdvancedOptionsButton.ImeMode = System.Windows.Forms.ImeMode.NoControl;
         this._pdfAdvancedOptionsButton.Location = new System.Drawing.Point(161, 45);
         this._pdfAdvancedOptionsButton.Name = "_pdfAdvancedOptionsButton";
         this._pdfAdvancedOptionsButton.Size = new System.Drawing.Size(225, 23);
         this._pdfAdvancedOptionsButton.TabIndex = 12;
         this._pdfAdvancedOptionsButton.Text = "Advanced Options...";
         this._pdfAdvancedOptionsButton.UseVisualStyleBackColor = true;
         this._pdfAdvancedOptionsButton.Click += new System.EventHandler(this._pdfAdvancedOptionsButton_Click);
         // 
         // _resolutionNumericUpDown
         // 
         this._resolutionNumericUpDown.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
         this._resolutionNumericUpDown.Location = new System.Drawing.Point(294, 74);
         this._resolutionNumericUpDown.Maximum = new decimal(new int[] {
            1200,
            0,
            0,
            0});
         this._resolutionNumericUpDown.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
         this._resolutionNumericUpDown.Name = "_resolutionNumericUpDown";
         this._resolutionNumericUpDown.Size = new System.Drawing.Size(49, 20);
         this._resolutionNumericUpDown.TabIndex = 5;
         this._resolutionNumericUpDown.Value = new decimal(new int[] {
            96,
            0,
            0,
            0});
         // 
         // _pixelsInchesLabel
         // 
         this._pixelsInchesLabel.AutoSize = true;
         this._pixelsInchesLabel.Location = new System.Drawing.Point(349, 77);
         this._pixelsInchesLabel.Name = "_pixelsInchesLabel";
         this._pixelsInchesLabel.Size = new System.Drawing.Size(96, 13);
         this._pixelsInchesLabel.TabIndex = 11;
         this._pixelsInchesLabel.Text = "pixels/inches (DPI)";
         // 
         // _resolutionComboBox
         // 
         this._resolutionComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._resolutionComboBox.FormattingEnabled = true;
         this._resolutionComboBox.Items.AddRange(new object[] {
            "Default",
            "Custom"});
         this._resolutionComboBox.Location = new System.Drawing.Point(161, 74);
         this._resolutionComboBox.Name = "_resolutionComboBox";
         this._resolutionComboBox.Size = new System.Drawing.Size(127, 21);
         this._resolutionComboBox.TabIndex = 4;
         this._resolutionComboBox.SelectedIndexChanged += new System.EventHandler(this._resolutionComboBox_SelectedIndexChanged);
         // 
         // _resolutionLabel
         // 
         this._resolutionLabel.AutoSize = true;
         this._resolutionLabel.Location = new System.Drawing.Point(14, 79);
         this._resolutionLabel.Name = "_resolutionLabel";
         this._resolutionLabel.Size = new System.Drawing.Size(140, 13);
         this._resolutionLabel.TabIndex = 9;
         this._resolutionLabel.Text = "Output document resolution:";
         // 
         // _documentTypeComboBox
         // 
         this._documentTypeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._documentTypeComboBox.FormattingEnabled = true;
         this._documentTypeComboBox.Location = new System.Drawing.Point(161, 19);
         this._documentTypeComboBox.Name = "_documentTypeComboBox";
         this._documentTypeComboBox.Size = new System.Drawing.Size(225, 21);
         this._documentTypeComboBox.TabIndex = 1;
         this._documentTypeComboBox.SelectedIndexChanged += new System.EventHandler(this._documentTypeComboBox_SelectedIndexChanged);
         // 
         // _documentTypeLabel
         // 
         this._documentTypeLabel.AutoSize = true;
         this._documentTypeLabel.Location = new System.Drawing.Point(14, 22);
         this._documentTypeLabel.Name = "_documentTypeLabel";
         this._documentTypeLabel.Size = new System.Drawing.Size(82, 13);
         this._documentTypeLabel.TabIndex = 0;
         this._documentTypeLabel.Text = "Document type:";
         // 
         // _pdfOptionsLabel
         // 
         this._pdfOptionsLabel.AutoSize = true;
         this._pdfOptionsLabel.Location = new System.Drawing.Point(9, 96);
         this._pdfOptionsLabel.Name = "_pdfOptionsLabel";
         this._pdfOptionsLabel.Size = new System.Drawing.Size(68, 13);
         this._pdfOptionsLabel.TabIndex = 1;
         this._pdfOptionsLabel.Text = "PDF options:";
         // 
         // SavePdfDialog
         // 
         this.AcceptButton = this._okButton;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._cancelButton;
         this.ClientSize = new System.Drawing.Size(632, 321);
         this.Controls.Add(this._pdfOptionsLabel);
         this.Controls.Add(this._pdfOptionsTabControl);
         this.Controls.Add(this._documentFileNameGroupBox);
         this.Controls.Add(this._cancelButton);
         this.Controls.Add(this._okButton);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "SavePdfDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Save Document";
         this._documentFileNameGroupBox.ResumeLayout(false);
         this._documentFileNameGroupBox.PerformLayout();
         this._pdfOptionsTabControl.ResumeLayout(false);
         this._generalTabPage.ResumeLayout(false);
         this._generalTabPage.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._resolutionNumericUpDown)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button _okButton;
      private System.Windows.Forms.Button _cancelButton;
      private System.Windows.Forms.GroupBox _documentFileNameGroupBox;
      private System.Windows.Forms.TextBox _documentFileNameTextBox;
      private System.Windows.Forms.Button _browseDocumentFileNameButton;
      private System.Windows.Forms.TabControl _pdfOptionsTabControl;
      private System.Windows.Forms.TabPage _generalTabPage;
      private System.Windows.Forms.Label _pdfOptionsLabel;
      private System.Windows.Forms.ComboBox _documentTypeComboBox;
      private System.Windows.Forms.Label _documentTypeLabel;
      private System.Windows.Forms.Label _pixelsInchesLabel;
      private System.Windows.Forms.ComboBox _resolutionComboBox;
      private System.Windows.Forms.Label _resolutionLabel;
      private System.Windows.Forms.NumericUpDown _resolutionNumericUpDown;
      private System.Windows.Forms.Button _pdfAdvancedOptionsButton;
   }
}