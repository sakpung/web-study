namespace PDFFileDemo
{
   partial class FilePropertiesControl
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
         this._sourceFilePropertiesGroupBox = new System.Windows.Forms.GroupBox();
         this._isLinearizedTextBox = new System.Windows.Forms.TextBox();
         this._isLinearizedLabel = new System.Windows.Forms.Label();
         this._versionTextBox = new System.Windows.Forms.TextBox();
         this._versionLabel = new System.Windows.Forms.Label();
         this._isEncryptedTextBox = new System.Windows.Forms.TextBox();
         this._isEncryptedLabel = new System.Windows.Forms.Label();
         this._pageSizeTextBox = new System.Windows.Forms.TextBox();
         this._pageSizeLabel = new System.Windows.Forms.Label();
         this._numberOfPagesTextBox = new System.Windows.Forms.TextBox();
         this._numberOfPagesLabel = new System.Windows.Forms.Label();
         this._sourceFilePropertiesGroupBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // _sourceFilePropertiesGroupBox
         // 
         this._sourceFilePropertiesGroupBox.Controls.Add(this._isLinearizedTextBox);
         this._sourceFilePropertiesGroupBox.Controls.Add(this._isLinearizedLabel);
         this._sourceFilePropertiesGroupBox.Controls.Add(this._versionTextBox);
         this._sourceFilePropertiesGroupBox.Controls.Add(this._versionLabel);
         this._sourceFilePropertiesGroupBox.Controls.Add(this._isEncryptedTextBox);
         this._sourceFilePropertiesGroupBox.Controls.Add(this._isEncryptedLabel);
         this._sourceFilePropertiesGroupBox.Controls.Add(this._pageSizeTextBox);
         this._sourceFilePropertiesGroupBox.Controls.Add(this._pageSizeLabel);
         this._sourceFilePropertiesGroupBox.Controls.Add(this._numberOfPagesTextBox);
         this._sourceFilePropertiesGroupBox.Controls.Add(this._numberOfPagesLabel);
         this._sourceFilePropertiesGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
         this._sourceFilePropertiesGroupBox.Location = new System.Drawing.Point(0, 0);
         this._sourceFilePropertiesGroupBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
         this._sourceFilePropertiesGroupBox.Name = "_sourceFilePropertiesGroupBox";
         this._sourceFilePropertiesGroupBox.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
         this._sourceFilePropertiesGroupBox.Size = new System.Drawing.Size(440, 246);
         this._sourceFilePropertiesGroupBox.TabIndex = 2;
         this._sourceFilePropertiesGroupBox.TabStop = false;
         this._sourceFilePropertiesGroupBox.Text = "File properties";
         // 
         // _isLinearizedTextBox
         // 
         this._isLinearizedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._isLinearizedTextBox.Location = new System.Drawing.Point(162, 191);
         this._isLinearizedTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
         this._isLinearizedTextBox.Name = "_isLinearizedTextBox";
         this._isLinearizedTextBox.ReadOnly = true;
         this._isLinearizedTextBox.Size = new System.Drawing.Size(256, 26);
         this._isLinearizedTextBox.TabIndex = 9;
         // 
         // _isLinearizedLabel
         // 
         this._isLinearizedLabel.AutoSize = true;
         this._isLinearizedLabel.Location = new System.Drawing.Point(67, 194);
         this._isLinearizedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
         this._isLinearizedLabel.Name = "_isLinearizedLabel";
         this._isLinearizedLabel.Size = new System.Drawing.Size(86, 20);
         this._isLinearizedLabel.TabIndex = 8;
         this._isLinearizedLabel.Text = "Linearized:";
         // 
         // _versionTextBox
         // 
         this._versionTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._versionTextBox.Location = new System.Drawing.Point(162, 69);
         this._versionTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
         this._versionTextBox.Name = "_versionTextBox";
         this._versionTextBox.ReadOnly = true;
         this._versionTextBox.Size = new System.Drawing.Size(256, 26);
         this._versionTextBox.TabIndex = 3;
         // 
         // _versionLabel
         // 
         this._versionLabel.AutoSize = true;
         this._versionLabel.Location = new System.Drawing.Point(86, 74);
         this._versionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
         this._versionLabel.Name = "_versionLabel";
         this._versionLabel.Size = new System.Drawing.Size(67, 20);
         this._versionLabel.TabIndex = 2;
         this._versionLabel.Text = "Version:";
         // 
         // _isEncryptedTextBox
         // 
         this._isEncryptedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._isEncryptedTextBox.Location = new System.Drawing.Point(162, 29);
         this._isEncryptedTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
         this._isEncryptedTextBox.Name = "_isEncryptedTextBox";
         this._isEncryptedTextBox.ReadOnly = true;
         this._isEncryptedTextBox.Size = new System.Drawing.Size(256, 26);
         this._isEncryptedTextBox.TabIndex = 1;
         // 
         // _isEncryptedLabel
         // 
         this._isEncryptedLabel.AutoSize = true;
         this._isEncryptedLabel.Location = new System.Drawing.Point(66, 34);
         this._isEncryptedLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
         this._isEncryptedLabel.Name = "_isEncryptedLabel";
         this._isEncryptedLabel.Size = new System.Drawing.Size(85, 20);
         this._isEncryptedLabel.TabIndex = 0;
         this._isEncryptedLabel.Text = "Encrypted:";
         // 
         // _pageSizeTextBox
         // 
         this._pageSizeTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._pageSizeTextBox.Location = new System.Drawing.Point(162, 149);
         this._pageSizeTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
         this._pageSizeTextBox.Name = "_pageSizeTextBox";
         this._pageSizeTextBox.ReadOnly = true;
         this._pageSizeTextBox.Size = new System.Drawing.Size(256, 26);
         this._pageSizeTextBox.TabIndex = 7;
         // 
         // _pageSizeLabel
         // 
         this._pageSizeLabel.AutoSize = true;
         this._pageSizeLabel.Location = new System.Drawing.Point(69, 154);
         this._pageSizeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
         this._pageSizeLabel.Name = "_pageSizeLabel";
         this._pageSizeLabel.Size = new System.Drawing.Size(82, 20);
         this._pageSizeLabel.TabIndex = 6;
         this._pageSizeLabel.Text = "Page size:";
         // 
         // _numberOfPagesTextBox
         // 
         this._numberOfPagesTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
         this._numberOfPagesTextBox.Location = new System.Drawing.Point(162, 109);
         this._numberOfPagesTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
         this._numberOfPagesTextBox.Name = "_numberOfPagesTextBox";
         this._numberOfPagesTextBox.ReadOnly = true;
         this._numberOfPagesTextBox.Size = new System.Drawing.Size(256, 26);
         this._numberOfPagesTextBox.TabIndex = 5;
         // 
         // _numberOfPagesLabel
         // 
         this._numberOfPagesLabel.AutoSize = true;
         this._numberOfPagesLabel.Location = new System.Drawing.Point(16, 114);
         this._numberOfPagesLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
         this._numberOfPagesLabel.Name = "_numberOfPagesLabel";
         this._numberOfPagesLabel.Size = new System.Drawing.Size(135, 20);
         this._numberOfPagesLabel.TabIndex = 4;
         this._numberOfPagesLabel.Text = "Number of pages:";
         // 
         // FilePropertiesControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._sourceFilePropertiesGroupBox);
         this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
         this.Name = "FilePropertiesControl";
         this.Size = new System.Drawing.Size(440, 246);
         this._sourceFilePropertiesGroupBox.ResumeLayout(false);
         this._sourceFilePropertiesGroupBox.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _sourceFilePropertiesGroupBox;
      private System.Windows.Forms.TextBox _versionTextBox;
      private System.Windows.Forms.Label _versionLabel;
      private System.Windows.Forms.TextBox _isEncryptedTextBox;
      private System.Windows.Forms.Label _isEncryptedLabel;
      private System.Windows.Forms.TextBox _pageSizeTextBox;
      private System.Windows.Forms.Label _pageSizeLabel;
      private System.Windows.Forms.TextBox _numberOfPagesTextBox;
      private System.Windows.Forms.Label _numberOfPagesLabel;
      private System.Windows.Forms.TextBox _isLinearizedTextBox;
      private System.Windows.Forms.Label _isLinearizedLabel;
   }
}
