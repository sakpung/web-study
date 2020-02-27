namespace OcrDemo
{
   partial class SaveRecognizedXmlDialog
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
         this._optionsGroupBox = new System.Windows.Forms.GroupBox();
         this._fileNameButton = new System.Windows.Forms.Button();
         this._fileNameTextBox = new System.Windows.Forms.TextBox();
         this._fileNameLabel = new System.Windows.Forms.Label();
         this._modeComboBox = new System.Windows.Forms.ComboBox();
         this._modeLabel = new System.Windows.Forms.Label();
         this._optionsGroupBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // _okButton
         // 
         this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._okButton.Location = new System.Drawing.Point(322, 121);
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
         this._cancelButton.Location = new System.Drawing.Point(403, 121);
         this._cancelButton.Name = "_cancelButton";
         this._cancelButton.Size = new System.Drawing.Size(75, 23);
         this._cancelButton.TabIndex = 2;
         this._cancelButton.Text = "Cancel";
         this._cancelButton.UseVisualStyleBackColor = true;
         // 
         // _optionsGroupBox
         // 
         this._optionsGroupBox.Controls.Add(this._fileNameButton);
         this._optionsGroupBox.Controls.Add(this._fileNameTextBox);
         this._optionsGroupBox.Controls.Add(this._fileNameLabel);
         this._optionsGroupBox.Controls.Add(this._modeComboBox);
         this._optionsGroupBox.Controls.Add(this._modeLabel);
         this._optionsGroupBox.Location = new System.Drawing.Point(13, 13);
         this._optionsGroupBox.Name = "_optionsGroupBox";
         this._optionsGroupBox.Size = new System.Drawing.Size(469, 102);
         this._optionsGroupBox.TabIndex = 0;
         this._optionsGroupBox.TabStop = false;
         this._optionsGroupBox.Text = "&Options:";
         // 
         // _fileNameButton
         // 
         this._fileNameButton.Location = new System.Drawing.Point(421, 61);
         this._fileNameButton.Name = "_fileNameButton";
         this._fileNameButton.Size = new System.Drawing.Size(29, 23);
         this._fileNameButton.TabIndex = 4;
         this._fileNameButton.Text = "&...";
         this._fileNameButton.UseVisualStyleBackColor = true;
         this._fileNameButton.Click += new System.EventHandler(this._fileNameButton_Click);
         // 
         // _fileNameTextBox
         // 
         this._fileNameTextBox.Location = new System.Drawing.Point(91, 63);
         this._fileNameTextBox.Name = "_fileNameTextBox";
         this._fileNameTextBox.Size = new System.Drawing.Size(324, 20);
         this._fileNameTextBox.TabIndex = 3;
         this._fileNameTextBox.TextChanged += new System.EventHandler(this._fileNameTextBox_TextChanged);
         // 
         // _fileNameLabel
         // 
         this._fileNameLabel.AutoSize = true;
         this._fileNameLabel.Location = new System.Drawing.Point(16, 63);
         this._fileNameLabel.Name = "_fileNameLabel";
         this._fileNameLabel.Size = new System.Drawing.Size(56, 13);
         this._fileNameLabel.TabIndex = 2;
         this._fileNameLabel.Text = "&File name:";
         // 
         // _modeComboBox
         // 
         this._modeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._modeComboBox.FormattingEnabled = true;
         this._modeComboBox.Location = new System.Drawing.Point(91, 34);
         this._modeComboBox.Name = "_modeComboBox";
         this._modeComboBox.Size = new System.Drawing.Size(324, 21);
         this._modeComboBox.TabIndex = 1;
         // 
         // _modeLabel
         // 
         this._modeLabel.AutoSize = true;
         this._modeLabel.Location = new System.Drawing.Point(16, 34);
         this._modeLabel.Name = "_modeLabel";
         this._modeLabel.Size = new System.Drawing.Size(37, 13);
         this._modeLabel.TabIndex = 0;
         this._modeLabel.Text = "&Mode:";
         // 
         // SaveRecognizedXmlDialog
         // 
         this.AcceptButton = this._okButton;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._cancelButton;
         this.ClientSize = new System.Drawing.Size(498, 158);
         this.Controls.Add(this._optionsGroupBox);
         this.Controls.Add(this._cancelButton);
         this.Controls.Add(this._okButton);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "SaveRecognizedXmlDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Save Document Recognition Data as XML";
         this._optionsGroupBox.ResumeLayout(false);
         this._optionsGroupBox.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _okButton;
      private System.Windows.Forms.Button _cancelButton;
      private System.Windows.Forms.GroupBox _optionsGroupBox;
      private System.Windows.Forms.Label _modeLabel;
      private System.Windows.Forms.ComboBox _modeComboBox;
      private System.Windows.Forms.Label _fileNameLabel;
      private System.Windows.Forms.TextBox _fileNameTextBox;
      private System.Windows.Forms.Button _fileNameButton;
   }
}