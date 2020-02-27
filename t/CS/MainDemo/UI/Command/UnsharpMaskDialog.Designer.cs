namespace MainDemo
{
   partial class UnsharpMaskDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnsharpMaskDialog));
         this._gbOptions = new System.Windows.Forms.GroupBox();
         this._cbColorSpace = new System.Windows.Forms.ComboBox();
         this._lblColorSpace = new System.Windows.Forms.Label();
         this._numThreshold = new System.Windows.Forms.NumericUpDown();
         this._lblThreshold = new System.Windows.Forms.Label();
         this._numRadius = new System.Windows.Forms.NumericUpDown();
         this._lblRadius = new System.Windows.Forms.Label();
         this._numAmount = new System.Windows.Forms.NumericUpDown();
         this._lblAmount = new System.Windows.Forms.Label();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._gbOptions.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numThreshold)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numRadius)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numAmount)).BeginInit();
         this.SuspendLayout();
         // 
         // _gbOptions
         // 
         this._gbOptions.Controls.Add(this._cbColorSpace);
         this._gbOptions.Controls.Add(this._lblColorSpace);
         this._gbOptions.Controls.Add(this._numThreshold);
         this._gbOptions.Controls.Add(this._lblThreshold);
         this._gbOptions.Controls.Add(this._numRadius);
         this._gbOptions.Controls.Add(this._lblRadius);
         this._gbOptions.Controls.Add(this._numAmount);
         this._gbOptions.Controls.Add(this._lblAmount);
         this._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbOptions, "_gbOptions");
         this._gbOptions.Name = "_gbOptions";
         this._gbOptions.TabStop = false;
         // 
         // _cbColorSpace
         // 
         this._cbColorSpace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         resources.ApplyResources(this._cbColorSpace, "_cbColorSpace");
         this._cbColorSpace.Name = "_cbColorSpace";
         // 
         // _lblColorSpace
         // 
         this._lblColorSpace.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblColorSpace, "_lblColorSpace");
         this._lblColorSpace.Name = "_lblColorSpace";
         // 
         // _numThreshold
         // 
         resources.ApplyResources(this._numThreshold, "_numThreshold");
         this._numThreshold.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
         this._numThreshold.Name = "_numThreshold";
         this._numThreshold.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numThreshold.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _lblThreshold
         // 
         this._lblThreshold.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblThreshold, "_lblThreshold");
         this._lblThreshold.Name = "_lblThreshold";
         // 
         // _numRadius
         // 
         resources.ApplyResources(this._numRadius, "_numRadius");
         this._numRadius.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
         this._numRadius.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numRadius.Name = "_numRadius";
         this._numRadius.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numRadius.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _lblRadius
         // 
         this._lblRadius.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblRadius, "_lblRadius");
         this._lblRadius.Name = "_lblRadius";
         // 
         // _numAmount
         // 
         resources.ApplyResources(this._numAmount, "_numAmount");
         this._numAmount.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
         this._numAmount.Name = "_numAmount";
         this._numAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numAmount.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _lblAmount
         // 
         this._lblAmount.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblAmount, "_lblAmount");
         this._lblAmount.Name = "_lblAmount";
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
         // UnsharpMaskDialog
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
         this.Name = "UnsharpMaskDialog";
         this.ShowInTaskbar = false;
         this.Load += new System.EventHandler(this.UnsharpMaskDialog_Load);
         this._gbOptions.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this._numThreshold)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numRadius)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numAmount)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gbOptions;
      private System.Windows.Forms.ComboBox _cbColorSpace;
      private System.Windows.Forms.Label _lblColorSpace;
      private System.Windows.Forms.NumericUpDown _numThreshold;
      private System.Windows.Forms.Label _lblThreshold;
      private System.Windows.Forms.NumericUpDown _numRadius;
      private System.Windows.Forms.Label _lblRadius;
      private System.Windows.Forms.NumericUpDown _numAmount;
      private System.Windows.Forms.Label _lblAmount;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
   }
}