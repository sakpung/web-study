namespace RasterizeDocumentDemo.UserControls
{
   partial class DocumentInfoControl
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
         this._documentInfoGroupBox = new System.Windows.Forms.GroupBox();
         this._warningLabel = new System.Windows.Forms.Label();
         this._loadDocumentSizePixelsLabel = new System.Windows.Forms.Label();
         this._loadDocumentSizeValueLabel = new System.Windows.Forms.Label();
         this._originalDocumentSizeValueLabel = new System.Windows.Forms.Label();
         this._pagesValueLabel = new System.Windows.Forms.Label();
         this._formatValueLabel = new System.Windows.Forms.Label();
         this._loadDocumentSizeLabel = new System.Windows.Forms.Label();
         this._originalDocumentSizeLabel = new System.Windows.Forms.Label();
         this._pagesLabel = new System.Windows.Forms.Label();
         this._formatLabel = new System.Windows.Forms.Label();
         this._documentInfoGroupBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // _documentInfoGroupBox
         // 
         this._documentInfoGroupBox.Controls.Add(this._warningLabel);
         this._documentInfoGroupBox.Controls.Add(this._loadDocumentSizePixelsLabel);
         this._documentInfoGroupBox.Controls.Add(this._loadDocumentSizeValueLabel);
         this._documentInfoGroupBox.Controls.Add(this._originalDocumentSizeValueLabel);
         this._documentInfoGroupBox.Controls.Add(this._pagesValueLabel);
         this._documentInfoGroupBox.Controls.Add(this._formatValueLabel);
         this._documentInfoGroupBox.Controls.Add(this._loadDocumentSizeLabel);
         this._documentInfoGroupBox.Controls.Add(this._originalDocumentSizeLabel);
         this._documentInfoGroupBox.Controls.Add(this._pagesLabel);
         this._documentInfoGroupBox.Controls.Add(this._formatLabel);
         this._documentInfoGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
         this._documentInfoGroupBox.Location = new System.Drawing.Point(0, 0);
         this._documentInfoGroupBox.Name = "_documentInfoGroupBox";
         this._documentInfoGroupBox.Size = new System.Drawing.Size(520, 200);
         this._documentInfoGroupBox.TabIndex = 0;
         this._documentInfoGroupBox.TabStop = false;
         this._documentInfoGroupBox.Text = "Document information:";
         // 
         // _warningLabel
         // 
         this._warningLabel.Location = new System.Drawing.Point(22, 148);
         this._warningLabel.Name = "_warningLabel";
         this._warningLabel.Size = new System.Drawing.Size(455, 49);
         this._warningLabel.TabIndex = 9;
         this._warningLabel.Text = "Warning: This file is a normal raster format and not a document format. Loading t" +
             "his file will not use the Rasterize Document Options you set. The file will be l" +
             "oaded using its original size.";
         // 
         // _loadDocumentSizePixelsLabel
         // 
         this._loadDocumentSizePixelsLabel.AutoSize = true;
         this._loadDocumentSizePixelsLabel.Location = new System.Drawing.Point(151, 125);
         this._loadDocumentSizePixelsLabel.Name = "_loadDocumentSizePixelsLabel";
         this._loadDocumentSizePixelsLabel.Size = new System.Drawing.Size(188, 13);
         this._loadDocumentSizePixelsLabel.TabIndex = 8;
         this._loadDocumentSizePixelsLabel.Text = "9999 by 9999 pixels at 300 pixels/inch";
         // 
         // _loadDocumentSizeValueLabel
         // 
         this._loadDocumentSizeValueLabel.AutoSize = true;
         this._loadDocumentSizeValueLabel.Location = new System.Drawing.Point(151, 102);
         this._loadDocumentSizeValueLabel.Name = "_loadDocumentSizeValueLabel";
         this._loadDocumentSizeValueLabel.Size = new System.Drawing.Size(106, 13);
         this._loadDocumentSizeValueLabel.TabIndex = 7;
         this._loadDocumentSizeValueLabel.Text = "9999 by 9999 inches";
         // 
         // _originalDocumentSizeValueLabel
         // 
         this._originalDocumentSizeValueLabel.AutoSize = true;
         this._originalDocumentSizeValueLabel.Location = new System.Drawing.Point(151, 79);
         this._originalDocumentSizeValueLabel.Name = "_originalDocumentSizeValueLabel";
         this._originalDocumentSizeValueLabel.Size = new System.Drawing.Size(106, 13);
         this._originalDocumentSizeValueLabel.TabIndex = 5;
         this._originalDocumentSizeValueLabel.Text = "9999 by 9999 inches";
         // 
         // _pagesValueLabel
         // 
         this._pagesValueLabel.AutoSize = true;
         this._pagesValueLabel.Location = new System.Drawing.Point(151, 56);
         this._pagesValueLabel.Name = "_pagesValueLabel";
         this._pagesValueLabel.Size = new System.Drawing.Size(25, 13);
         this._pagesValueLabel.TabIndex = 3;
         this._pagesValueLabel.Text = "999";
         // 
         // _formatValueLabel
         // 
         this._formatValueLabel.AutoSize = true;
         this._formatValueLabel.Location = new System.Drawing.Point(151, 33);
         this._formatValueLabel.Name = "_formatValueLabel";
         this._formatValueLabel.Size = new System.Drawing.Size(197, 13);
         this._formatValueLabel.TabIndex = 1;
         this._formatValueLabel.Text = "Adobe Portable Document Format (PDF)";
         // 
         // _loadDocumentSizeLabel
         // 
         this._loadDocumentSizeLabel.AutoSize = true;
         this._loadDocumentSizeLabel.Location = new System.Drawing.Point(22, 102);
         this._loadDocumentSizeLabel.Name = "_loadDocumentSizeLabel";
         this._loadDocumentSizeLabel.Size = new System.Drawing.Size(105, 13);
         this._loadDocumentSizeLabel.TabIndex = 6;
         this._loadDocumentSizeLabel.Text = "Load document size:";
         // 
         // _originalDocumentSizeLabel
         // 
         this._originalDocumentSizeLabel.AutoSize = true;
         this._originalDocumentSizeLabel.Location = new System.Drawing.Point(22, 79);
         this._originalDocumentSizeLabel.Name = "_originalDocumentSizeLabel";
         this._originalDocumentSizeLabel.Size = new System.Drawing.Size(116, 13);
         this._originalDocumentSizeLabel.TabIndex = 4;
         this._originalDocumentSizeLabel.Text = "Original document size:";
         // 
         // _pagesLabel
         // 
         this._pagesLabel.AutoSize = true;
         this._pagesLabel.Location = new System.Drawing.Point(22, 56);
         this._pagesLabel.Name = "_pagesLabel";
         this._pagesLabel.Size = new System.Drawing.Size(40, 13);
         this._pagesLabel.TabIndex = 2;
         this._pagesLabel.Text = "Pages:";
         // 
         // _formatLabel
         // 
         this._formatLabel.AutoSize = true;
         this._formatLabel.Location = new System.Drawing.Point(22, 33);
         this._formatLabel.Name = "_formatLabel";
         this._formatLabel.Size = new System.Drawing.Size(42, 13);
         this._formatLabel.TabIndex = 0;
         this._formatLabel.Text = "Format:";
         // 
         // DocumentInfoControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._documentInfoGroupBox);
         this.Name = "DocumentInfoControl";
         this.Size = new System.Drawing.Size(520, 200);
         this._documentInfoGroupBox.ResumeLayout(false);
         this._documentInfoGroupBox.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _documentInfoGroupBox;
      private System.Windows.Forms.Label _formatLabel;
      private System.Windows.Forms.Label _pagesLabel;
      private System.Windows.Forms.Label _originalDocumentSizeLabel;
      private System.Windows.Forms.Label _formatValueLabel;
      private System.Windows.Forms.Label _loadDocumentSizeLabel;
      private System.Windows.Forms.Label _pagesValueLabel;
      private System.Windows.Forms.Label _originalDocumentSizeValueLabel;
      private System.Windows.Forms.Label _loadDocumentSizePixelsLabel;
      private System.Windows.Forms.Label _loadDocumentSizeValueLabel;
      private System.Windows.Forms.Label _warningLabel;
   }
}
