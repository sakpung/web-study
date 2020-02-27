namespace RasterizeDocumentDemo.Viewer
{
   partial class GotoPageDialog
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
         this._pagesLabel = new System.Windows.Forms.Label();
         this._pageTextBox = new System.Windows.Forms.TextBox();
         this._pageLabel = new System.Windows.Forms.Label();
         this._cancelButton = new System.Windows.Forms.Button();
         this._okButton = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // _pagesLabel
         // 
         this._pagesLabel.AutoSize = true;
         this._pagesLabel.Location = new System.Drawing.Point(166, 15);
         this._pagesLabel.Name = "_pagesLabel";
         this._pagesLabel.Size = new System.Drawing.Size(63, 13);
         this._pagesLabel.TabIndex = 2;
         this._pagesLabel.Text = "of WWWW";
         // 
         // _pageTextBox
         // 
         this._pageTextBox.Location = new System.Drawing.Point(60, 12);
         this._pageTextBox.Name = "_pageTextBox";
         this._pageTextBox.Size = new System.Drawing.Size(100, 20);
         this._pageTextBox.TabIndex = 1;
         // 
         // _pageLabel
         // 
         this._pageLabel.AutoSize = true;
         this._pageLabel.Location = new System.Drawing.Point(8, 15);
         this._pageLabel.Name = "_pageLabel";
         this._pageLabel.Size = new System.Drawing.Size(35, 13);
         this._pageLabel.TabIndex = 0;
         this._pageLabel.Text = "&Page:";
         // 
         // _cancelButton
         // 
         this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._cancelButton.Location = new System.Drawing.Point(153, 46);
         this._cancelButton.Name = "_cancelButton";
         this._cancelButton.Size = new System.Drawing.Size(75, 23);
         this._cancelButton.TabIndex = 4;
         this._cancelButton.Text = "Cancel";
         this._cancelButton.UseVisualStyleBackColor = true;
         // 
         // _okButton
         // 
         this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._okButton.Location = new System.Drawing.Point(72, 46);
         this._okButton.Name = "_okButton";
         this._okButton.Size = new System.Drawing.Size(75, 23);
         this._okButton.TabIndex = 3;
         this._okButton.Text = "OK";
         this._okButton.UseVisualStyleBackColor = true;
         this._okButton.Click += new System.EventHandler(this._okButton_Click);
         // 
         // GotoPageDialog
         // 
         this.AcceptButton = this._okButton;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._cancelButton;
         this.ClientSize = new System.Drawing.Size(245, 84);
         this.Controls.Add(this._pagesLabel);
         this.Controls.Add(this._pageTextBox);
         this.Controls.Add(this._pageLabel);
         this.Controls.Add(this._cancelButton);
         this.Controls.Add(this._okButton);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "GotoPageDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Go To Page";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label _pagesLabel;
      private System.Windows.Forms.TextBox _pageTextBox;
      private System.Windows.Forms.Label _pageLabel;
      private System.Windows.Forms.Button _cancelButton;
      private System.Windows.Forms.Button _okButton;
   }
}