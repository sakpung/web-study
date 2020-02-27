namespace RasterizeDocumentDemo.UserControls
{
   partial class DocumentPathControl
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
         this._documentPathGroupBox = new System.Windows.Forms.GroupBox();
         this._documentPathTextBox = new System.Windows.Forms.TextBox();
         this._browseButton = new System.Windows.Forms.Button();
         this._documentPathGroupBox.SuspendLayout();
         this.SuspendLayout();
         // 
         // _documentPathGroupBox
         // 
         this._documentPathGroupBox.Controls.Add(this._documentPathTextBox);
         this._documentPathGroupBox.Controls.Add(this._browseButton);
         this._documentPathGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
         this._documentPathGroupBox.Location = new System.Drawing.Point(0, 0);
         this._documentPathGroupBox.Name = "_documentPathGroupBox";
         this._documentPathGroupBox.Size = new System.Drawing.Size(520, 70);
         this._documentPathGroupBox.TabIndex = 0;
         this._documentPathGroupBox.TabStop = false;
         this._documentPathGroupBox.Text = "Select the document to view:";
         // 
         // _documentPathTextBox
         // 
         this._documentPathTextBox.Location = new System.Drawing.Point(16, 35);
         this._documentPathTextBox.Name = "_documentPathTextBox";
         this._documentPathTextBox.Size = new System.Drawing.Size(407, 20);
         this._documentPathTextBox.TabIndex = 0;
         // 
         // _browseButton
         // 
         this._browseButton.Location = new System.Drawing.Point(429, 33);
         this._browseButton.Name = "_browseButton";
         this._browseButton.Size = new System.Drawing.Size(75, 23);
         this._browseButton.TabIndex = 1;
         this._browseButton.Text = "&Browse...";
         this._browseButton.UseVisualStyleBackColor = true;
         this._browseButton.Click += new System.EventHandler(this._browseButton_Click);
         // 
         // DocumentPathControl
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._documentPathGroupBox);
         this.Name = "DocumentPathControl";
         this.Size = new System.Drawing.Size(520, 70);
         this._documentPathGroupBox.ResumeLayout(false);
         this._documentPathGroupBox.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _documentPathGroupBox;
      private System.Windows.Forms.TextBox _documentPathTextBox;
      private System.Windows.Forms.Button _browseButton;
   }
}
