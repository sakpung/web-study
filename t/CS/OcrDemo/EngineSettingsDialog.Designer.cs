namespace OcrDemo
{
   partial class EngineSettingsDialog
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
         this._closeButton = new System.Windows.Forms.Button();
         this._descriptionLabel = new System.Windows.Forms.Label();
         this._ocrEngineSettingsControl = new Leadtools.Demos.OcrEngineSettingsControl();
         this.SuspendLayout();
         // 
         // _closeButton
         // 
         this._closeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
         this._closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._closeButton.Location = new System.Drawing.Point(452, 324);
         this._closeButton.Name = "_closeButton";
         this._closeButton.Size = new System.Drawing.Size(75, 23);
         this._closeButton.TabIndex = 2;
         this._closeButton.Text = "Close";
         this._closeButton.UseVisualStyleBackColor = true;
         // 
         // _descriptionLabel
         // 
         this._descriptionLabel.AutoSize = true;
         this._descriptionLabel.Location = new System.Drawing.Point(13, 13);
         this._descriptionLabel.Name = "_descriptionLabel";
         this._descriptionLabel.Size = new System.Drawing.Size(150, 13);
         this._descriptionLabel.TabIndex = 0;
         this._descriptionLabel.Text = "Change OCR Engine Settings:";
         // 
         // _ocrEngineSettingsControl
         // 
         this._ocrEngineSettingsControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                     | System.Windows.Forms.AnchorStyles.Left)
                     | System.Windows.Forms.AnchorStyles.Right)));
         this._ocrEngineSettingsControl.Location = new System.Drawing.Point(16, 45);
         this._ocrEngineSettingsControl.Name = "_ocrEngineSettingsControl";
         this._ocrEngineSettingsControl.Size = new System.Drawing.Size(510, 266);
         this._ocrEngineSettingsControl.TabIndex = 1;
         // 
         // EngineSettingsDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._closeButton;
         this.ClientSize = new System.Drawing.Size(539, 359);
         this.Controls.Add(this._ocrEngineSettingsControl);
         this.Controls.Add(this._descriptionLabel);
         this.Controls.Add(this._closeButton);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "EngineSettingsDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "OCR Engine Settings";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button _closeButton;
      private System.Windows.Forms.Label _descriptionLabel;
      private Leadtools.Demos.OcrEngineSettingsControl _ocrEngineSettingsControl;
   }
}