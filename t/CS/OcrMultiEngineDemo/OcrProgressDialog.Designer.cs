namespace OcrMultiEngineDemo
{
   partial class OcrProgressDialog
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OcrProgressDialog));
          this._cancelButton = new System.Windows.Forms.Button();
          this._descriptionLabel = new System.Windows.Forms.Label();
          this._progressBar = new System.Windows.Forms.ProgressBar();
          this._panel = new System.Windows.Forms.Panel();
          this._panel.SuspendLayout();
          this.SuspendLayout();
          // 
          // _cancelButton
          // 
          this._cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          resources.ApplyResources(this._cancelButton, "_cancelButton");
          this._cancelButton.Name = "_cancelButton";
          this._cancelButton.UseVisualStyleBackColor = true;
          this._cancelButton.Click += new System.EventHandler(this._cancelButton_Click);
          // 
          // _descriptionLabel
          // 
          resources.ApplyResources(this._descriptionLabel, "_descriptionLabel");
          this._descriptionLabel.Name = "_descriptionLabel";
          // 
          // _progressBar
          // 
          resources.ApplyResources(this._progressBar, "_progressBar");
          this._progressBar.MarqueeAnimationSpeed = 50;
          this._progressBar.Name = "_progressBar";
          // 
          // _panel
          // 
          this._panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          this._panel.Controls.Add(this._descriptionLabel);
          this._panel.Controls.Add(this._progressBar);
          this._panel.Controls.Add(this._cancelButton);
          resources.ApplyResources(this._panel, "_panel");
          this._panel.Name = "_panel";
          // 
          // OcrProgressDialog
          // 
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._cancelButton;
          this.Controls.Add(this._panel);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "OcrProgressDialog";
          this.ShowInTaskbar = false;
          this._panel.ResumeLayout(false);
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _cancelButton;
      private System.Windows.Forms.Label _descriptionLabel;
      private System.Windows.Forms.ProgressBar _progressBar;
      private System.Windows.Forms.Panel _panel;
   }
}