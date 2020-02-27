namespace RasterizeDocumentDemo
{
   partial class LoadPagesDialog
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
         this._documentPagesControl = new RasterizeDocumentDemo.UserControls.DocumentPagesControl();
         this._okButton = new System.Windows.Forms.Button();
         this._cancelButton = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // _documentPagesControl
         // 
         this._documentPagesControl.Location = new System.Drawing.Point(12, 12);
         this._documentPagesControl.Name = "_documentPagesControl";
         this._documentPagesControl.Size = new System.Drawing.Size(489, 86);
         this._documentPagesControl.TabIndex = 0;
         // 
         // _okButton
         // 
         this._okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._okButton.Location = new System.Drawing.Point(335, 104);
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
         this._cancelButton.Location = new System.Drawing.Point(416, 104);
         this._cancelButton.Name = "_cancelButton";
         this._cancelButton.Size = new System.Drawing.Size(75, 23);
         this._cancelButton.TabIndex = 2;
         this._cancelButton.Text = "Cancel";
         this._cancelButton.UseVisualStyleBackColor = true;
         // 
         // LoadPagesDialog
         // 
         this.AcceptButton = this._okButton;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._cancelButton;
         this.ClientSize = new System.Drawing.Size(512, 134);
         this.Controls.Add(this._cancelButton);
         this.Controls.Add(this._okButton);
         this.Controls.Add(this._documentPagesControl);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "LoadPagesDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Select the Document Pages to Load";
         this.ResumeLayout(false);

      }

      #endregion

      private RasterizeDocumentDemo.UserControls.DocumentPagesControl _documentPagesControl;
      private System.Windows.Forms.Button _okButton;
      private System.Windows.Forms.Button _cancelButton;
   }
}