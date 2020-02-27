namespace MainDemo
{
   partial class FlipDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FlipDialog));
         this._gbOptions = new System.Windows.Forms.GroupBox();
         this._rbVertical = new System.Windows.Forms.RadioButton();
         this._rbHorizontal = new System.Windows.Forms.RadioButton();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._gbOptions.SuspendLayout();
         this.SuspendLayout();
         // 
         // _gbOptions
         // 
         this._gbOptions.Controls.Add(this._rbVertical);
         this._gbOptions.Controls.Add(this._rbHorizontal);
         this._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbOptions, "_gbOptions");
         this._gbOptions.Name = "_gbOptions";
         this._gbOptions.TabStop = false;
         // 
         // _rbVertical
         // 
         resources.ApplyResources(this._rbVertical, "_rbVertical");
         this._rbVertical.Name = "_rbVertical";
         this._rbVertical.TabStop = true;
         this._rbVertical.UseVisualStyleBackColor = true;
         // 
         // _rbHorizontal
         // 
         resources.ApplyResources(this._rbHorizontal, "_rbHorizontal");
         this._rbHorizontal.Name = "_rbHorizontal";
         this._rbHorizontal.TabStop = true;
         this._rbHorizontal.UseVisualStyleBackColor = true;
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
         // FlipDialog
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
         this.Name = "FlipDialog";
         this.Load += new System.EventHandler(this.FlipDialog_Load);
         this._gbOptions.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gbOptions;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.RadioButton _rbVertical;
      private System.Windows.Forms.RadioButton _rbHorizontal;
   }
}