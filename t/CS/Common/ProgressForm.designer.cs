namespace Leadtools.Demos
{
   partial class ProgressForm
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

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent()
      {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProgressForm));
         this._lblInformation = new System.Windows.Forms.Label();
         this._progress = new System.Windows.Forms.ProgressBar();
         this._btnCancel = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // _lblInformation
         // 
         resources.ApplyResources(this._lblInformation, "_lblInformation");
         this._lblInformation.Name = "_lblInformation";
         // 
         // _progress
         // 
         resources.ApplyResources(this._progress, "_progress");
         this._progress.Name = "_progress";
         // 
         // _btnCancel
         // 
         resources.ApplyResources(this._btnCancel, "_btnCancel");
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
         // 
         // ProgressForm
         // 
         this.AcceptButton = this._btnCancel;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._progress);
         this.Controls.Add(this._lblInformation);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Name = "ProgressForm";
         this.ShowInTaskbar = false;
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Label _lblInformation;
      private System.Windows.Forms.ProgressBar _progress;
      private System.Windows.Forms.Button _btnCancel;
   }
}