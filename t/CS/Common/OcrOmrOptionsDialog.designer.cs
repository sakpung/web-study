namespace Leadtools.Demos
{
   partial class OcrOmrOptionsDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OcrOmrOptionsDialog));
            this._okButton = new System.Windows.Forms.Button();
            this._cancelButton = new System.Windows.Forms.Button();
            this._descriptionLabel = new System.Windows.Forms.Label();
            this._optionsGroupBox = new System.Windows.Forms.GroupBox();
            this._filledStateCharacterTextBox = new System.Windows.Forms.TextBox();
            this._unfilledStateCharacterTextBox = new System.Windows.Forms.TextBox();
            this._filledStateCharacterLabel = new System.Windows.Forms.Label();
            this._unfilledStateCharacterLabel = new System.Windows.Forms.Label();
            this._sensitivityComboBox = new System.Windows.Forms.ComboBox();
            this._sensitivityLabel = new System.Windows.Forms.Label();
            this._frameDetectionMethodComboBox = new System.Windows.Forms.ComboBox();
            this._frameDetectionMethodLabel = new System.Windows.Forms.Label();
            this._lowSensitivityPictureBox = new System.Windows.Forms.PictureBox();
            this._lowSensitivityLabel = new System.Windows.Forms.Label();
            this._highSensitivityLabel = new System.Windows.Forms.Label();
            this._highSensitivityPictureBox = new System.Windows.Forms.PictureBox();
            this._optionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._lowSensitivityPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._highSensitivityPictureBox)).BeginInit();
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
            // _descriptionLabel
            // 
            resources.ApplyResources(this._descriptionLabel, "_descriptionLabel");
            this._descriptionLabel.Name = "_descriptionLabel";
            // 
            // _optionsGroupBox
            // 
            this._optionsGroupBox.Controls.Add(this._filledStateCharacterTextBox);
            this._optionsGroupBox.Controls.Add(this._unfilledStateCharacterTextBox);
            this._optionsGroupBox.Controls.Add(this._filledStateCharacterLabel);
            this._optionsGroupBox.Controls.Add(this._unfilledStateCharacterLabel);
            this._optionsGroupBox.Controls.Add(this._sensitivityComboBox);
            this._optionsGroupBox.Controls.Add(this._sensitivityLabel);
            this._optionsGroupBox.Controls.Add(this._frameDetectionMethodComboBox);
            this._optionsGroupBox.Controls.Add(this._frameDetectionMethodLabel);
            resources.ApplyResources(this._optionsGroupBox, "_optionsGroupBox");
            this._optionsGroupBox.Name = "_optionsGroupBox";
            this._optionsGroupBox.TabStop = false;
            // 
            // _filledStateCharacterTextBox
            // 
            resources.ApplyResources(this._filledStateCharacterTextBox, "_filledStateCharacterTextBox");
            this._filledStateCharacterTextBox.Name = "_filledStateCharacterTextBox";
            // 
            // _unfilledStateCharacterTextBox
            // 
            resources.ApplyResources(this._unfilledStateCharacterTextBox, "_unfilledStateCharacterTextBox");
            this._unfilledStateCharacterTextBox.Name = "_unfilledStateCharacterTextBox";
            // 
            // _filledStateCharacterLabel
            // 
            resources.ApplyResources(this._filledStateCharacterLabel, "_filledStateCharacterLabel");
            this._filledStateCharacterLabel.Name = "_filledStateCharacterLabel";
            // 
            // _unfilledStateCharacterLabel
            // 
            resources.ApplyResources(this._unfilledStateCharacterLabel, "_unfilledStateCharacterLabel");
            this._unfilledStateCharacterLabel.Name = "_unfilledStateCharacterLabel";
            // 
            // _sensitivityComboBox
            // 
            this._sensitivityComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._sensitivityComboBox.FormattingEnabled = true;
            resources.ApplyResources(this._sensitivityComboBox, "_sensitivityComboBox");
            this._sensitivityComboBox.Name = "_sensitivityComboBox";
            // 
            // _sensitivityLabel
            // 
            resources.ApplyResources(this._sensitivityLabel, "_sensitivityLabel");
            this._sensitivityLabel.Name = "_sensitivityLabel";
            // 
            // _frameDetectionMethodComboBox
            // 
            this._frameDetectionMethodComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this._frameDetectionMethodComboBox.FormattingEnabled = true;
            resources.ApplyResources(this._frameDetectionMethodComboBox, "_frameDetectionMethodComboBox");
            this._frameDetectionMethodComboBox.Name = "_frameDetectionMethodComboBox";
            // 
            // _frameDetectionMethodLabel
            // 
            resources.ApplyResources(this._frameDetectionMethodLabel, "_frameDetectionMethodLabel");
            this._frameDetectionMethodLabel.Name = "_frameDetectionMethodLabel";
            // 
            // _lowSensitivityPictureBox
            // 
            resources.ApplyResources(this._lowSensitivityPictureBox, "_lowSensitivityPictureBox");
            this._lowSensitivityPictureBox.Name = "_lowSensitivityPictureBox";
            this._lowSensitivityPictureBox.TabStop = false;
            // 
            // _lowSensitivityLabel
            // 
            resources.ApplyResources(this._lowSensitivityLabel, "_lowSensitivityLabel");
            this._lowSensitivityLabel.Name = "_lowSensitivityLabel";
            // 
            // _highSensitivityLabel
            // 
            resources.ApplyResources(this._highSensitivityLabel, "_highSensitivityLabel");
            this._highSensitivityLabel.Name = "_highSensitivityLabel";
            // 
            // _highSensitivityPictureBox
            // 
            resources.ApplyResources(this._highSensitivityPictureBox, "_highSensitivityPictureBox");
            this._highSensitivityPictureBox.Name = "_highSensitivityPictureBox";
            this._highSensitivityPictureBox.TabStop = false;
            // 
            // OcrOmrOptionsDialog
            // 
            this.AcceptButton = this._okButton;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._cancelButton;
            this.Controls.Add(this._highSensitivityLabel);
            this.Controls.Add(this._highSensitivityPictureBox);
            this.Controls.Add(this._lowSensitivityLabel);
            this.Controls.Add(this._lowSensitivityPictureBox);
            this.Controls.Add(this._optionsGroupBox);
            this.Controls.Add(this._descriptionLabel);
            this.Controls.Add(this._cancelButton);
            this.Controls.Add(this._okButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OcrOmrOptionsDialog";
            this.ShowInTaskbar = false;
            this._optionsGroupBox.ResumeLayout(false);
            this._optionsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._lowSensitivityPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._highSensitivityPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button _okButton;
      private System.Windows.Forms.Button _cancelButton;
      private System.Windows.Forms.Label _descriptionLabel;
      private System.Windows.Forms.GroupBox _optionsGroupBox;
      private System.Windows.Forms.Label _frameDetectionMethodLabel;
      private System.Windows.Forms.ComboBox _frameDetectionMethodComboBox;
      private System.Windows.Forms.ComboBox _sensitivityComboBox;
      private System.Windows.Forms.Label _sensitivityLabel;
      private System.Windows.Forms.Label _unfilledStateCharacterLabel;
      private System.Windows.Forms.Label _filledStateCharacterLabel;
      private System.Windows.Forms.TextBox _unfilledStateCharacterTextBox;
      private System.Windows.Forms.TextBox _filledStateCharacterTextBox;
      private System.Windows.Forms.PictureBox _lowSensitivityPictureBox;
      private System.Windows.Forms.Label _lowSensitivityLabel;
      private System.Windows.Forms.Label _highSensitivityLabel;
      private System.Windows.Forms.PictureBox _highSensitivityPictureBox;
   }
}