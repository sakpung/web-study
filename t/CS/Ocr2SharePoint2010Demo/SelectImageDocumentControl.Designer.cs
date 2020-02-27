namespace Ocr2SharePointDemo
{
   partial class SelectImageDocumentControl
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
         if (disposing && (components != null))
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
         this._descriptionLabel = new System.Windows.Forms.Label();
         this._fileNameLabel = new System.Windows.Forms.Label();
         this._fileNameTextBox = new System.Windows.Forms.TextBox();
         this._browseButton = new System.Windows.Forms.Button();
         this._formatComboBox = new System.Windows.Forms.ComboBox();
         this._formatLabel = new System.Windows.Forms.Label();
         this._documentFormatLabel = new System.Windows.Forms.Label();
         this._nextLabel = new System.Windows.Forms.Label();
         this.SuspendLayout();
         // 
         // _descriptionLabel
         // 
         this._descriptionLabel.AutoSize = true;
         this._descriptionLabel.Location = new System.Drawing.Point(14, 14);
         this._descriptionLabel.Name = "_descriptionLabel";
         this._descriptionLabel.Size = new System.Drawing.Size(402, 13);
         this._descriptionLabel.TabIndex = 0;
         this._descriptionLabel.Text = "Select the image document to recognize (OCR) and upload to the SharePoint server";
         // 
         // _fileNameLabel
         // 
         this._fileNameLabel.AutoSize = true;
         this._fileNameLabel.Location = new System.Drawing.Point(17, 45);
         this._fileNameLabel.Name = "_fileNameLabel";
         this._fileNameLabel.Size = new System.Drawing.Size(55, 13);
         this._fileNameLabel.TabIndex = 1;
         this._fileNameLabel.Text = "File name:";
         // 
         // _fileNameTextBox
         // 
         this._fileNameTextBox.Location = new System.Drawing.Point(78, 42);
         this._fileNameTextBox.Name = "_fileNameTextBox";
         this._fileNameTextBox.Size = new System.Drawing.Size(578, 20);
         this._fileNameTextBox.TabIndex = 2;
         this._fileNameTextBox.TextChanged += new System.EventHandler(this._fileNameTextBox_TextChanged);
         // 
         // _browseButton
         // 
         this._browseButton.Location = new System.Drawing.Point(662, 40);
         this._browseButton.Name = "_browseButton";
         this._browseButton.Size = new System.Drawing.Size(75, 23);
         this._browseButton.TabIndex = 3;
         this._browseButton.Text = "Browse...";
         this._browseButton.UseVisualStyleBackColor = true;
         this._browseButton.Click += new System.EventHandler(this._browseButton_Click);
         // 
         // _formatComboBox
         // 
         this._formatComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._formatComboBox.FormattingEnabled = true;
         this._formatComboBox.Location = new System.Drawing.Point(78, 135);
         this._formatComboBox.Name = "_formatComboBox";
         this._formatComboBox.Size = new System.Drawing.Size(578, 21);
         this._formatComboBox.TabIndex = 6;
         // 
         // _formatLabel
         // 
         this._formatLabel.AutoSize = true;
         this._formatLabel.Location = new System.Drawing.Point(17, 138);
         this._formatLabel.Name = "_formatLabel";
         this._formatLabel.Size = new System.Drawing.Size(42, 13);
         this._formatLabel.TabIndex = 5;
         this._formatLabel.Text = "Format:";
         // 
         // _documentFormatLabel
         // 
         this._documentFormatLabel.Location = new System.Drawing.Point(17, 77);
         this._documentFormatLabel.Name = "_documentFormatLabel";
         this._documentFormatLabel.Size = new System.Drawing.Size(711, 50);
         this._documentFormatLabel.TabIndex = 4;
         this._documentFormatLabel.Text = "Select the output document format\r\n\r\nNote: You can use the LEADTOOLS OCR Main Dem" +
             "o or Auto Recognize Demo for more OCR engines and options.";
         // 
         // _nextLabel
         // 
         this._nextLabel.AutoSize = true;
         this._nextLabel.Location = new System.Drawing.Point(17, 178);
         this._nextLabel.Name = "_nextLabel";
         this._nextLabel.Size = new System.Drawing.Size(409, 13);
         this._nextLabel.TabIndex = 7;
         this._nextLabel.Text = "Click \'Next\' to recognize the document and upload it to the selected SharePoint f" +
             "older";
         // 
         // SelectImageDocumentControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._nextLabel);
         this.Controls.Add(this._formatComboBox);
         this.Controls.Add(this._formatLabel);
         this.Controls.Add(this._documentFormatLabel);
         this.Controls.Add(this._browseButton);
         this.Controls.Add(this._fileNameTextBox);
         this.Controls.Add(this._fileNameLabel);
         this.Controls.Add(this._descriptionLabel);
         this.Name = "SelectImageDocumentControl";
         this.Size = new System.Drawing.Size(740, 330);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label _descriptionLabel;
      private System.Windows.Forms.Label _fileNameLabel;
      private System.Windows.Forms.TextBox _fileNameTextBox;
      private System.Windows.Forms.Button _browseButton;
      private System.Windows.Forms.ComboBox _formatComboBox;
      private System.Windows.Forms.Label _formatLabel;
      private System.Windows.Forms.Label _documentFormatLabel;
      private System.Windows.Forms.Label _nextLabel;
   }
}
