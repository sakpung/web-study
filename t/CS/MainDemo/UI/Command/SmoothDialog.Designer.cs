namespace MainDemo
{
   partial class SmoothDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SmoothDialog));
         this._cbFavorLong = new System.Windows.Forms.CheckBox();
         this._gbOptions = new System.Windows.Forms.GroupBox();
         this._lblLength = new System.Windows.Forms.Label();
         this._numLength = new System.Windows.Forms.NumericUpDown();
         this._gbFlags = new System.Windows.Forms.GroupBox();
         this._cbImageUnchanged = new System.Windows.Forms.CheckBox();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._gbOptions.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numLength)).BeginInit();
         this._gbFlags.SuspendLayout();
         this.SuspendLayout();
         // 
         // _cbFavorLong
         // 
         resources.ApplyResources(this._cbFavorLong, "_cbFavorLong");
         this._cbFavorLong.Name = "_cbFavorLong";
         // 
         // _gbOptions
         // 
         this._gbOptions.Controls.Add(this._lblLength);
         this._gbOptions.Controls.Add(this._numLength);
         this._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbOptions, "_gbOptions");
         this._gbOptions.Name = "_gbOptions";
         this._gbOptions.TabStop = false;
         // 
         // _lblLength
         // 
         this._lblLength.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblLength, "_lblLength");
         this._lblLength.Name = "_lblLength";
         // 
         // _numLength
         // 
         resources.ApplyResources(this._numLength, "_numLength");
         this._numLength.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
         this._numLength.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numLength.Name = "_numLength";
         this._numLength.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numLength.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _gbFlags
         // 
         this._gbFlags.Controls.Add(this._cbFavorLong);
         this._gbFlags.Controls.Add(this._cbImageUnchanged);
         this._gbFlags.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbFlags, "_gbFlags");
         this._gbFlags.Name = "_gbFlags";
         this._gbFlags.TabStop = false;
         // 
         // _cbImageUnchanged
         // 
         resources.ApplyResources(this._cbImageUnchanged, "_cbImageUnchanged");
         this._cbImageUnchanged.Name = "_cbImageUnchanged";
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         resources.ApplyResources(this._btnCancel, "_btnCancel");
         this._btnCancel.Name = "_btnCancel";
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         resources.ApplyResources(this._btnOk, "_btnOk");
         this._btnOk.Name = "_btnOk";
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // SmoothDialog
         // 
         this.AcceptButton = this._btnOk;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.Controls.Add(this._gbOptions);
         this.Controls.Add(this._gbFlags);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "SmoothDialog";
         this.ShowInTaskbar = false;
         this.Load += new System.EventHandler(this.SmoothDialog_Load);
         this._gbOptions.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this._numLength)).EndInit();
         this._gbFlags.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.CheckBox _cbFavorLong;
      private System.Windows.Forms.GroupBox _gbOptions;
      private System.Windows.Forms.Label _lblLength;
      private System.Windows.Forms.NumericUpDown _numLength;
      private System.Windows.Forms.GroupBox _gbFlags;
      private System.Windows.Forms.CheckBox _cbImageUnchanged;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
   }
}