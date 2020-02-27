namespace MainDemo
{
   partial class CropDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CropDialog));
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._gbOptions = new System.Windows.Forms.GroupBox();
         this._numHeight = new System.Windows.Forms.NumericUpDown();
         this._numWidth = new System.Windows.Forms.NumericUpDown();
         this._numTop = new System.Windows.Forms.NumericUpDown();
         this._numLeft = new System.Windows.Forms.NumericUpDown();
         this._lblHeight = new System.Windows.Forms.Label();
         this._lblWidth = new System.Windows.Forms.Label();
         this._lblTop = new System.Windows.Forms.Label();
         this._lblLeft = new System.Windows.Forms.Label();
         this._gbOptions.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numHeight)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numWidth)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numTop)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numLeft)).BeginInit();
         this.SuspendLayout();
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
         // _gbOptions
         // 
         this._gbOptions.Controls.Add(this._numHeight);
         this._gbOptions.Controls.Add(this._numWidth);
         this._gbOptions.Controls.Add(this._numTop);
         this._gbOptions.Controls.Add(this._numLeft);
         this._gbOptions.Controls.Add(this._lblHeight);
         this._gbOptions.Controls.Add(this._lblWidth);
         this._gbOptions.Controls.Add(this._lblTop);
         this._gbOptions.Controls.Add(this._lblLeft);
         this._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbOptions, "_gbOptions");
         this._gbOptions.Name = "_gbOptions";
         this._gbOptions.TabStop = false;
         // 
         // _numHeight
         // 
         resources.ApplyResources(this._numHeight, "_numHeight");
         this._numHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
         this._numHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numHeight.Name = "_numHeight";
         this._numHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numHeight.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _numWidth
         // 
         resources.ApplyResources(this._numWidth, "_numWidth");
         this._numWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
         this._numWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numWidth.Name = "_numWidth";
         this._numWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numWidth.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _numTop
         // 
         resources.ApplyResources(this._numTop, "_numTop");
         this._numTop.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
         this._numTop.Name = "_numTop";
         this._numTop.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numTop.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _numLeft
         // 
         resources.ApplyResources(this._numLeft, "_numLeft");
         this._numLeft.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
         this._numLeft.Name = "_numLeft";
         this._numLeft.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numLeft.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _lblHeight
         // 
         this._lblHeight.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblHeight, "_lblHeight");
         this._lblHeight.Name = "_lblHeight";
         // 
         // _lblWidth
         // 
         this._lblWidth.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblWidth, "_lblWidth");
         this._lblWidth.Name = "_lblWidth";
         // 
         // _lblTop
         // 
         this._lblTop.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblTop, "_lblTop");
         this._lblTop.Name = "_lblTop";
         // 
         // _lblLeft
         // 
         this._lblLeft.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblLeft, "_lblLeft");
         this._lblLeft.Name = "_lblLeft";
         // 
         // CropDialog
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
         this.Name = "CropDialog";
         this.ShowInTaskbar = false;
         this.Load += new System.EventHandler(this.CropDialog_Load);
         this._gbOptions.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this._numHeight)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numWidth)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numTop)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numLeft)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.GroupBox _gbOptions;
      private System.Windows.Forms.NumericUpDown _numWidth;
      private System.Windows.Forms.NumericUpDown _numTop;
      private System.Windows.Forms.NumericUpDown _numLeft;
      private System.Windows.Forms.Label _lblHeight;
      private System.Windows.Forms.Label _lblWidth;
      private System.Windows.Forms.Label _lblTop;
      private System.Windows.Forms.Label _lblLeft;
      private System.Windows.Forms.NumericUpDown _numHeight;
   }
}