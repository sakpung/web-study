namespace PDFFileDemo
{
   partial class SecurityOptionsControl
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
         this._securityOptionsGroupBox = new System.Windows.Forms.GroupBox();
         this._ecnryptionModeComboBox = new System.Windows.Forms.ComboBox();
         this._encryptionModeLabel = new System.Windows.Forms.Label();
         this._assemblyEnabledCheckBox = new System.Windows.Forms.CheckBox();
         this._annotationsEnabledCheckBox = new System.Windows.Forms.CheckBox();
         this._editEnabledCheckBox = new System.Windows.Forms.CheckBox();
         this._copyEnabledCheckBox = new System.Windows.Forms.CheckBox();
         this._highQualityPrintEnabledCheckBox = new System.Windows.Forms.CheckBox();
         this._printEnabledCheckBox = new System.Windows.Forms.CheckBox();
         this._ownerPasswordTextBox = new System.Windows.Forms.TextBox();
         this._ownerPasswordLabel = new System.Windows.Forms.Label();
         this._userPasswordTextBox = new System.Windows.Forms.TextBox();
         this._userPasswordLabel = new System.Windows.Forms.Label();
         this._securityOptionsGroupBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // _securityOptionsGroupBox
         // 
         this._securityOptionsGroupBox.Controls.Add(this._ecnryptionModeComboBox);
         this._securityOptionsGroupBox.Controls.Add(this._encryptionModeLabel);
         this._securityOptionsGroupBox.Controls.Add(this._assemblyEnabledCheckBox);
         this._securityOptionsGroupBox.Controls.Add(this._annotationsEnabledCheckBox);
         this._securityOptionsGroupBox.Controls.Add(this._editEnabledCheckBox);
         this._securityOptionsGroupBox.Controls.Add(this._copyEnabledCheckBox);
         this._securityOptionsGroupBox.Controls.Add(this._highQualityPrintEnabledCheckBox);
         this._securityOptionsGroupBox.Controls.Add(this._printEnabledCheckBox);
         this._securityOptionsGroupBox.Controls.Add(this._ownerPasswordTextBox);
         this._securityOptionsGroupBox.Controls.Add(this._ownerPasswordLabel);
         this._securityOptionsGroupBox.Controls.Add(this._userPasswordTextBox);
         this._securityOptionsGroupBox.Controls.Add(this._userPasswordLabel);
         this._securityOptionsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
         this._securityOptionsGroupBox.Location = new System.Drawing.Point(0, 0);
         this._securityOptionsGroupBox.Name = "_securityOptionsGroupBox";
         this._securityOptionsGroupBox.Size = new System.Drawing.Size(315, 255);
         this._securityOptionsGroupBox.TabIndex = 0;
         this._securityOptionsGroupBox.TabStop = false;
         this._securityOptionsGroupBox.Text = "Security options:";
         // 
         // _ecnryptionModeComboBox
         // 
         this._ecnryptionModeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this._ecnryptionModeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._ecnryptionModeComboBox.FormattingEnabled = true;
         this._ecnryptionModeComboBox.Location = new System.Drawing.Point(125, 19);
         this._ecnryptionModeComboBox.Name = "_ecnryptionModeComboBox";
         this._ecnryptionModeComboBox.Size = new System.Drawing.Size(171, 21);
         this._ecnryptionModeComboBox.TabIndex = 1;
         this._ecnryptionModeComboBox.SelectedIndexChanged += new System.EventHandler(this._ecnryptionModeComboBox_SelectedIndexChanged);
         // 
         // _encryptionModeLabel
         // 
         this._encryptionModeLabel.AutoSize = true;
         this._encryptionModeLabel.Location = new System.Drawing.Point(30, 22);
         this._encryptionModeLabel.Name = "_encryptionModeLabel";
         this._encryptionModeLabel.Size = new System.Drawing.Size(89, 13);
         this._encryptionModeLabel.TabIndex = 0;
         this._encryptionModeLabel.Text = "Encryption mode:";
         // 
         // _assemblyEnabledCheckBox
         // 
         this._assemblyEnabledCheckBox.AutoSize = true;
         this._assemblyEnabledCheckBox.Location = new System.Drawing.Point(125, 190);
         this._assemblyEnabledCheckBox.Name = "_assemblyEnabledCheckBox";
         this._assemblyEnabledCheckBox.Size = new System.Drawing.Size(111, 17);
         this._assemblyEnabledCheckBox.TabIndex = 10;
         this._assemblyEnabledCheckBox.Text = "Assembly enabled";
         this._assemblyEnabledCheckBox.UseVisualStyleBackColor = true;
         // 
         // _annotationsEnabledCheckBox
         // 
         this._annotationsEnabledCheckBox.AutoSize = true;
         this._annotationsEnabledCheckBox.Location = new System.Drawing.Point(125, 144);
         this._annotationsEnabledCheckBox.Name = "_annotationsEnabledCheckBox";
         this._annotationsEnabledCheckBox.Size = new System.Drawing.Size(123, 17);
         this._annotationsEnabledCheckBox.TabIndex = 8;
         this._annotationsEnabledCheckBox.Text = "Annotations enabled";
         this._annotationsEnabledCheckBox.UseVisualStyleBackColor = true;
         // 
         // _editEnabledCheckBox
         // 
         this._editEnabledCheckBox.AutoSize = true;
         this._editEnabledCheckBox.Location = new System.Drawing.Point(125, 121);
         this._editEnabledCheckBox.Name = "_editEnabledCheckBox";
         this._editEnabledCheckBox.Size = new System.Drawing.Size(85, 17);
         this._editEnabledCheckBox.TabIndex = 7;
         this._editEnabledCheckBox.Text = "Edit enabled";
         this._editEnabledCheckBox.UseVisualStyleBackColor = true;
         this._editEnabledCheckBox.CheckedChanged += new System.EventHandler(this._editEnabledCheckBox_CheckedChanged);
         // 
         // _copyEnabledCheckBox
         // 
         this._copyEnabledCheckBox.AutoSize = true;
         this._copyEnabledCheckBox.Location = new System.Drawing.Point(125, 98);
         this._copyEnabledCheckBox.Name = "_copyEnabledCheckBox";
         this._copyEnabledCheckBox.Size = new System.Drawing.Size(91, 17);
         this._copyEnabledCheckBox.TabIndex = 6;
         this._copyEnabledCheckBox.Text = "Copy enabled";
         this._copyEnabledCheckBox.UseVisualStyleBackColor = true;
         // 
         // _highQualityPrintEnabledCheckBox
         // 
         this._highQualityPrintEnabledCheckBox.AutoSize = true;
         this._highQualityPrintEnabledCheckBox.Location = new System.Drawing.Point(125, 213);
         this._highQualityPrintEnabledCheckBox.Name = "_highQualityPrintEnabledCheckBox";
         this._highQualityPrintEnabledCheckBox.Size = new System.Drawing.Size(145, 17);
         this._highQualityPrintEnabledCheckBox.TabIndex = 11;
         this._highQualityPrintEnabledCheckBox.Text = "High quality print enabled";
         this._highQualityPrintEnabledCheckBox.UseVisualStyleBackColor = true;
         // 
         // _printEnabledCheckBox
         // 
         this._printEnabledCheckBox.AutoSize = true;
         this._printEnabledCheckBox.Location = new System.Drawing.Point(125, 167);
         this._printEnabledCheckBox.Name = "_printEnabledCheckBox";
         this._printEnabledCheckBox.Size = new System.Drawing.Size(88, 17);
         this._printEnabledCheckBox.TabIndex = 9;
         this._printEnabledCheckBox.Text = "Print enabled";
         this._printEnabledCheckBox.UseVisualStyleBackColor = true;
         this._printEnabledCheckBox.CheckedChanged += new System.EventHandler(this._printEnabledCheckBox_CheckedChanged);
         // 
         // _ownerPasswordTextBox
         // 
         this._ownerPasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this._ownerPasswordTextBox.Location = new System.Drawing.Point(125, 72);
         this._ownerPasswordTextBox.Name = "_ownerPasswordTextBox";
         this._ownerPasswordTextBox.Size = new System.Drawing.Size(171, 20);
         this._ownerPasswordTextBox.TabIndex = 5;
         // 
         // _ownerPasswordLabel
         // 
         this._ownerPasswordLabel.AutoSize = true;
         this._ownerPasswordLabel.Location = new System.Drawing.Point(30, 75);
         this._ownerPasswordLabel.Name = "_ownerPasswordLabel";
         this._ownerPasswordLabel.Size = new System.Drawing.Size(89, 13);
         this._ownerPasswordLabel.TabIndex = 4;
         this._ownerPasswordLabel.Text = "Owner password:";
         // 
         // _userPasswordTextBox
         // 
         this._userPasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this._userPasswordTextBox.Location = new System.Drawing.Point(125, 46);
         this._userPasswordTextBox.Name = "_userPasswordTextBox";
         this._userPasswordTextBox.Size = new System.Drawing.Size(171, 20);
         this._userPasswordTextBox.TabIndex = 3;
         // 
         // _userPasswordLabel
         // 
         this._userPasswordLabel.AutoSize = true;
         this._userPasswordLabel.Location = new System.Drawing.Point(39, 49);
         this._userPasswordLabel.Name = "_userPasswordLabel";
         this._userPasswordLabel.Size = new System.Drawing.Size(80, 13);
         this._userPasswordLabel.TabIndex = 2;
         this._userPasswordLabel.Text = "User password:";
         // 
         // SecurityOptionsControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._securityOptionsGroupBox);
         this.Name = "SecurityOptionsControl";
         this.Size = new System.Drawing.Size(315, 255);
         this._securityOptionsGroupBox.ResumeLayout(false);
         this._securityOptionsGroupBox.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _securityOptionsGroupBox;
      private System.Windows.Forms.TextBox _ownerPasswordTextBox;
      private System.Windows.Forms.Label _ownerPasswordLabel;
      private System.Windows.Forms.TextBox _userPasswordTextBox;
      private System.Windows.Forms.Label _userPasswordLabel;
      private System.Windows.Forms.Label _encryptionModeLabel;
      private System.Windows.Forms.CheckBox _assemblyEnabledCheckBox;
      private System.Windows.Forms.CheckBox _annotationsEnabledCheckBox;
      private System.Windows.Forms.CheckBox _editEnabledCheckBox;
      private System.Windows.Forms.CheckBox _copyEnabledCheckBox;
      private System.Windows.Forms.CheckBox _highQualityPrintEnabledCheckBox;
      private System.Windows.Forms.CheckBox _printEnabledCheckBox;
      private System.Windows.Forms.ComboBox _ecnryptionModeComboBox;
   }
}
