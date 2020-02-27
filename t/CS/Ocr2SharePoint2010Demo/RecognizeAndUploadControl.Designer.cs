namespace Ocr2SharePointDemo
{
   partial class RecognizeAndUploadControl
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
         this._imageDocumentFileNameLabel = new System.Windows.Forms.Label();
         this._itemsGroupBox = new System.Windows.Forms.GroupBox();
         this._serverDocumentNameTextBox = new System.Windows.Forms.TextBox();
         this._serverDocumentNameLabel = new System.Windows.Forms.Label();
         this._imageDocumentFileNameTextBox = new System.Windows.Forms.TextBox();
         this._successLabel = new System.Windows.Forms.Label();
         this._errorLabel = new System.Windows.Forms.Label();
         this._itemsGroupBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // _imageDocumentFileNameLabel
         // 
         this._imageDocumentFileNameLabel.AutoSize = true;
         this._imageDocumentFileNameLabel.Location = new System.Drawing.Point(6, 32);
         this._imageDocumentFileNameLabel.Name = "_imageDocumentFileNameLabel";
         this._imageDocumentFileNameLabel.Size = new System.Drawing.Size(105, 13);
         this._imageDocumentFileNameLabel.TabIndex = 0;
         this._imageDocumentFileNameLabel.Text = "Image document file:";
         // 
         // _itemsGroupBox
         // 
         this._itemsGroupBox.Controls.Add(this._serverDocumentNameTextBox);
         this._itemsGroupBox.Controls.Add(this._serverDocumentNameLabel);
         this._itemsGroupBox.Controls.Add(this._imageDocumentFileNameTextBox);
         this._itemsGroupBox.Controls.Add(this._imageDocumentFileNameLabel);
         this._itemsGroupBox.Location = new System.Drawing.Point(12, 3);
         this._itemsGroupBox.Name = "_itemsGroupBox";
         this._itemsGroupBox.Size = new System.Drawing.Size(714, 101);
         this._itemsGroupBox.TabIndex = 0;
         this._itemsGroupBox.TabStop = false;
         this._itemsGroupBox.Text = "Source document image file name and destination document on the server:";
         // 
         // _serverDocumentNameTextBox
         // 
         this._serverDocumentNameTextBox.Location = new System.Drawing.Point(128, 59);
         this._serverDocumentNameTextBox.Name = "_serverDocumentNameTextBox";
         this._serverDocumentNameTextBox.ReadOnly = true;
         this._serverDocumentNameTextBox.Size = new System.Drawing.Size(570, 20);
         this._serverDocumentNameTextBox.TabIndex = 3;
         // 
         // _serverDocumentNameLabel
         // 
         this._serverDocumentNameLabel.AutoSize = true;
         this._serverDocumentNameLabel.Location = new System.Drawing.Point(20, 62);
         this._serverDocumentNameLabel.Name = "_serverDocumentNameLabel";
         this._serverDocumentNameLabel.Size = new System.Drawing.Size(91, 13);
         this._serverDocumentNameLabel.TabIndex = 2;
         this._serverDocumentNameLabel.Text = "Server document:";
         // 
         // _imageDocumentFileNameTextBox
         // 
         this._imageDocumentFileNameTextBox.Location = new System.Drawing.Point(128, 29);
         this._imageDocumentFileNameTextBox.Name = "_imageDocumentFileNameTextBox";
         this._imageDocumentFileNameTextBox.ReadOnly = true;
         this._imageDocumentFileNameTextBox.Size = new System.Drawing.Size(570, 20);
         this._imageDocumentFileNameTextBox.TabIndex = 1;
         // 
         // _successLabel
         // 
         this._successLabel.AutoSize = true;
         this._successLabel.Location = new System.Drawing.Point(12, 111);
         this._successLabel.Name = "_successLabel";
         this._successLabel.Size = new System.Drawing.Size(379, 65);
         this._successLabel.TabIndex = 2;
         this._successLabel.Text = "Document recognized and uploaded successfully.\r\n\r\nClick \'Next\' to view the upload" +
             "ed document in the SharePoint browser\r\n\r\nClick \'Previous\' to recognize and uploa" +
             "d another document into the same folder";
         // 
         // _errorLabel
         // 
         this._errorLabel.AutoSize = true;
         this._errorLabel.Location = new System.Drawing.Point(12, 183);
         this._errorLabel.Name = "_errorLabel";
         this._errorLabel.Size = new System.Drawing.Size(379, 65);
         this._errorLabel.TabIndex = 1;
         this._errorLabel.Text = "An error occured while recognizing or uploading the document.\r\n\r\nClick \'Next\' to " +
             "go back to the SharePoint browser\r\n\r\nClick \'Previous\' to recognize and upload an" +
             "other document into the same folder";
         // 
         // RecognizeAndUploadControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._successLabel);
         this.Controls.Add(this._errorLabel);
         this.Controls.Add(this._itemsGroupBox);
         this.Name = "RecognizeAndUploadControl";
         this.Size = new System.Drawing.Size(740, 330);
         this._itemsGroupBox.ResumeLayout(false);
         this._itemsGroupBox.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label _imageDocumentFileNameLabel;
      private System.Windows.Forms.GroupBox _itemsGroupBox;
      private System.Windows.Forms.TextBox _imageDocumentFileNameTextBox;
      private System.Windows.Forms.Label _serverDocumentNameLabel;
      private System.Windows.Forms.TextBox _serverDocumentNameTextBox;
      private System.Windows.Forms.Label _successLabel;
      private System.Windows.Forms.Label _errorLabel;
   }
}
