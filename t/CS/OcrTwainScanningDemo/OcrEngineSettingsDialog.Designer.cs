namespace OcrTwainScanningDemo
{
   partial class OcrEngineSettingsDialog
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
         this._btnClose = new System.Windows.Forms.Button();
         this._ocrEngineSettings = new Leadtools.Demos.OcrEngineSettingsControl();
         this.SuspendLayout();
         // 
         // _btnClose
         // 
         this._btnClose.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnClose.Location = new System.Drawing.Point(447, 294);
         this._btnClose.Name = "_btnClose";
         this._btnClose.Size = new System.Drawing.Size(75, 23);
         this._btnClose.TabIndex = 0;
         this._btnClose.Text = "Close";
         this._btnClose.UseVisualStyleBackColor = true;
         // 
         // _ocrEngineSettings
         // 
         this._ocrEngineSettings.Location = new System.Drawing.Point(12, 12);
         this._ocrEngineSettings.Name = "_ocrEngineSettings";
         this._ocrEngineSettings.Size = new System.Drawing.Size(510, 266);
         this._ocrEngineSettings.TabIndex = 1;
         // 
         // OcrEngineSettingsDialog
         // 
         this.AcceptButton = this._btnClose;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnClose;
         this.ClientSize = new System.Drawing.Size(536, 326);
         this.Controls.Add(this._ocrEngineSettings);
         this.Controls.Add(this._btnClose);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "OcrEngineSettingsDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "OCR Engine Settings";
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _btnClose;
      private Leadtools.Demos.OcrEngineSettingsControl _ocrEngineSettings;
   }
}