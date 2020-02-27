namespace OcrMultiEngineDemo
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SaveRecognizedXmlDialog));
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
          resources.ApplyResources(this._okButton, "_okButton");
          this._okButton.Name = "_okButton";
          this._okButton.UseVisualStyleBackColor = true;
          this._okButton.Click += new System.EventHandler(this._okButton_Click);
          // 
          // _cancelButton
          // 
          this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          resources.ApplyResources(this._cancelButton, "_cancelButton");
          this._cancelButton.Name = "_cancelButton";
          this._cancelButton.UseVisualStyleBackColor = true;
          // 
          // _optionsGroupBox
          // 
          this._optionsGroupBox.Controls.Add(this._fileNameButton);
          this._optionsGroupBox.Controls.Add(this._fileNameTextBox);
          this._optionsGroupBox.Controls.Add(this._fileNameLabel);
          this._optionsGroupBox.Controls.Add(this._modeComboBox);
          this._optionsGroupBox.Controls.Add(this._modeLabel);
          resources.ApplyResources(this._optionsGroupBox, "_optionsGroupBox");
          this._optionsGroupBox.Name = "_optionsGroupBox";
          this._optionsGroupBox.TabStop = false;
          // 
          // _fileNameButton
          // 
          resources.ApplyResources(this._fileNameButton, "_fileNameButton");
          this._fileNameButton.Name = "_fileNameButton";
          this._fileNameButton.UseVisualStyleBackColor = true;
          this._fileNameButton.Click += new System.EventHandler(this._fileNameButton_Click);
          // 
          // _fileNameTextBox
          // 
          resources.ApplyResources(this._fileNameTextBox, "_fileNameTextBox");
          this._fileNameTextBox.Name = "_fileNameTextBox";
          this._fileNameTextBox.TextChanged += new System.EventHandler(this._fileNameTextBox_TextChanged);
          // 
          // _fileNameLabel
          // 
          resources.ApplyResources(this._fileNameLabel, "_fileNameLabel");
          this._fileNameLabel.Name = "_fileNameLabel";
          // 
          // _modeComboBox
          // 
          this._modeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this._modeComboBox.FormattingEnabled = true;
          resources.ApplyResources(this._modeComboBox, "_modeComboBox");
          this._modeComboBox.Name = "_modeComboBox";
          // 
          // _modeLabel
          // 
          resources.ApplyResources(this._modeLabel, "_modeLabel");
          this._modeLabel.Name = "_modeLabel";
          // 
          // SaveRecognizedXmlDialog
          // 
          this.AcceptButton = this._okButton;
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._cancelButton;
          this.Controls.Add(this._optionsGroupBox);
          this.Controls.Add(this._cancelButton);
          this.Controls.Add(this._okButton);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "SaveRecognizedXmlDialog";
          this.ShowInTaskbar = false;
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