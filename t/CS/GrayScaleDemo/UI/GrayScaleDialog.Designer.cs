namespace GrayScaleDemo
{
   partial class GrayScaleDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GrayScaleDialog));
         this._rb8 = new System.Windows.Forms.RadioButton();
         this._rb12 = new System.Windows.Forms.RadioButton();
         this._gbOptions = new System.Windows.Forms.GroupBox();
         this._rb16 = new System.Windows.Forms.RadioButton();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._gbOptions.SuspendLayout();
         this.SuspendLayout();
         // 
         // _rb8
         // 
         resources.ApplyResources(this._rb8, "_rb8");
         this._rb8.Name = "_rb8";
         this._rb8.TabStop = true;
         this._rb8.UseVisualStyleBackColor = true;
         // 
         // _rb12
         // 
         resources.ApplyResources(this._rb12, "_rb12");
         this._rb12.Name = "_rb12";
         this._rb12.TabStop = true;
         this._rb12.UseVisualStyleBackColor = true;
         // 
         // _gbOptions
         // 
         this._gbOptions.Controls.Add(this._rb16);
         this._gbOptions.Controls.Add(this._rb12);
         this._gbOptions.Controls.Add(this._rb8);
         this._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbOptions, "_gbOptions");
         this._gbOptions.Name = "_gbOptions";
         this._gbOptions.TabStop = false;
         // 
         // _rb16
         // 
         resources.ApplyResources(this._rb16, "_rb16");
         this._rb16.Name = "_rb16";
         this._rb16.TabStop = true;
         this._rb16.UseVisualStyleBackColor = true;
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         resources.ApplyResources(this._btnCancel, "_btnCancel");
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         resources.ApplyResources(this._btnOk, "_btnOk");
         this._btnOk.Name = "_btnOk";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // GrayScaleDialog
         // 
         this.AcceptButton = this._btnOk;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.Controls.Add(this._gbOptions);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "GrayScaleDialog";
         this.ShowInTaskbar = false;
         this.Load += new System.EventHandler(this.GrayScaleDialog_Load);
         this._gbOptions.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.RadioButton _rb8;
      private System.Windows.Forms.RadioButton _rb12;
      private System.Windows.Forms.GroupBox _gbOptions;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.RadioButton _rb16;
   }
}