namespace OcrMultiEngineDemo
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EngineSettingsDialog));
         this._closeButton = new System.Windows.Forms.Button();
         this._descriptionLabel = new System.Windows.Forms.Label();
         this._ocrEngineSettingsControl = new Leadtools.Demos.OcrEngineSettingsControl();
         this.SuspendLayout();
         // 
         // _closeButton
         // 
         resources.ApplyResources(this._closeButton, "_closeButton");
         this._closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._closeButton.Name = "_closeButton";
         this._closeButton.UseVisualStyleBackColor = true;
         // 
         // _descriptionLabel
         // 
         resources.ApplyResources(this._descriptionLabel, "_descriptionLabel");
         this._descriptionLabel.Name = "_descriptionLabel";
         // 
         // _ocrEngineSettingsControl
         // 
         resources.ApplyResources(this._ocrEngineSettingsControl, "_ocrEngineSettingsControl");
         this._ocrEngineSettingsControl.Name = "_ocrEngineSettingsControl";
         // 
         // EngineSettingsDialog
         // 
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._closeButton;
         this.Controls.Add(this._ocrEngineSettingsControl);
         this.Controls.Add(this._descriptionLabel);
         this.Controls.Add(this._closeButton);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "EngineSettingsDialog";
         this.ShowInTaskbar = false;
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button _closeButton;
      private System.Windows.Forms.Label _descriptionLabel;
      private Leadtools.Demos.OcrEngineSettingsControl _ocrEngineSettingsControl;
   }
}