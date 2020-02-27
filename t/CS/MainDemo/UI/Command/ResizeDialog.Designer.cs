namespace MainDemo
{
   partial class ResizeDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResizeDialog));
         this._gbOptionsFlags = new System.Windows.Forms.GroupBox();
         this._numWidth = new System.Windows.Forms.NumericUpDown();
         this._lblWidth = new System.Windows.Forms.Label();
         this._rbButtonResample = new System.Windows.Forms.RadioButton();
         this._btnCancel = new System.Windows.Forms.Button();
         this._gbOptions = new System.Windows.Forms.GroupBox();
         this._lblInterpolation = new System.Windows.Forms.Label();
         this._rbButtonFavorBlackOrBicubic = new System.Windows.Forms.RadioButton();
         this._rbButtonBicubic = new System.Windows.Forms.RadioButton();
         this._rbButtonFavorBlackOrResample = new System.Windows.Forms.RadioButton();
         this._numHeight = new System.Windows.Forms.NumericUpDown();
         this._lblHeight = new System.Windows.Forms.Label();
         this._rbButtonNormal = new System.Windows.Forms.RadioButton();
         this._rbButtonFavorBlack = new System.Windows.Forms.RadioButton();
         this._btnOk = new System.Windows.Forms.Button();
         ((System.ComponentModel.ISupportInitialize)(this._numWidth)).BeginInit();
         this._gbOptions.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numHeight)).BeginInit();
         this.SuspendLayout();
         // 
         // _gbOptionsFlags
         // 
         this._gbOptionsFlags.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbOptionsFlags, "_gbOptionsFlags");
         this._gbOptionsFlags.Name = "_gbOptionsFlags";
         this._gbOptionsFlags.TabStop = false;
         // 
         // _numWidth
         // 
         resources.ApplyResources(this._numWidth, "_numWidth");
         this._numWidth.Maximum = new decimal(new int[] {
            100000,
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
         // 
         // _lblWidth
         // 
         this._lblWidth.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblWidth, "_lblWidth");
         this._lblWidth.Name = "_lblWidth";
         // 
         // _rbButtonResample
         // 
         resources.ApplyResources(this._rbButtonResample, "_rbButtonResample");
         this._rbButtonResample.Name = "_rbButtonResample";
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         resources.ApplyResources(this._btnCancel, "_btnCancel");
         this._btnCancel.Name = "_btnCancel";
         // 
         // _gbOptions
         // 
         this._gbOptions.Controls.Add(this._lblInterpolation);
         this._gbOptions.Controls.Add(this._rbButtonFavorBlackOrBicubic);
         this._gbOptions.Controls.Add(this._rbButtonBicubic);
         this._gbOptions.Controls.Add(this._rbButtonFavorBlackOrResample);
         this._gbOptions.Controls.Add(this._numHeight);
         this._gbOptions.Controls.Add(this._lblHeight);
         this._gbOptions.Controls.Add(this._gbOptionsFlags);
         this._gbOptions.Controls.Add(this._numWidth);
         this._gbOptions.Controls.Add(this._lblWidth);
         this._gbOptions.Controls.Add(this._rbButtonResample);
         this._gbOptions.Controls.Add(this._rbButtonNormal);
         this._gbOptions.Controls.Add(this._rbButtonFavorBlack);
         this._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbOptions, "_gbOptions");
         this._gbOptions.Name = "_gbOptions";
         this._gbOptions.TabStop = false;
         // 
         // _lblInterpolation
         // 
         this._lblInterpolation.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblInterpolation, "_lblInterpolation");
         this._lblInterpolation.Name = "_lblInterpolation";
         // 
         // _rbButtonFavorBlackOrBicubic
         // 
         resources.ApplyResources(this._rbButtonFavorBlackOrBicubic, "_rbButtonFavorBlackOrBicubic");
         this._rbButtonFavorBlackOrBicubic.Name = "_rbButtonFavorBlackOrBicubic";
         // 
         // _rbButtonBicubic
         // 
         resources.ApplyResources(this._rbButtonBicubic, "_rbButtonBicubic");
         this._rbButtonBicubic.Name = "_rbButtonBicubic";
         // 
         // _rbButtonFavorBlackOrResample
         // 
         resources.ApplyResources(this._rbButtonFavorBlackOrResample, "_rbButtonFavorBlackOrResample");
         this._rbButtonFavorBlackOrResample.Name = "_rbButtonFavorBlackOrResample";
         // 
         // _numHeight
         // 
         resources.ApplyResources(this._numHeight, "_numHeight");
         this._numHeight.Maximum = new decimal(new int[] {
            100000,
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
         // 
         // _lblHeight
         // 
         this._lblHeight.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblHeight, "_lblHeight");
         this._lblHeight.Name = "_lblHeight";
         // 
         // _rbButtonNormal
         // 
         resources.ApplyResources(this._rbButtonNormal, "_rbButtonNormal");
         this._rbButtonNormal.Name = "_rbButtonNormal";
         // 
         // _rbButtonFavorBlack
         // 
         resources.ApplyResources(this._rbButtonFavorBlack, "_rbButtonFavorBlack");
         this._rbButtonFavorBlack.Name = "_rbButtonFavorBlack";
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         resources.ApplyResources(this._btnOk, "_btnOk");
         this._btnOk.Name = "_btnOk";
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // ResizeDialog
         // 
         this.AcceptButton = this._btnOk;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._gbOptions);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ResizeDialog";
         this.ShowInTaskbar = false;
         this.Load += new System.EventHandler(this.ResizeDialog_Load);
         ((System.ComponentModel.ISupportInitialize)(this._numWidth)).EndInit();
         this._gbOptions.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this._numHeight)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gbOptionsFlags;
      private System.Windows.Forms.NumericUpDown _numWidth;
      private System.Windows.Forms.Label _lblWidth;
      private System.Windows.Forms.RadioButton _rbButtonResample;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.GroupBox _gbOptions;
      private System.Windows.Forms.Label _lblInterpolation;
      private System.Windows.Forms.RadioButton _rbButtonFavorBlackOrBicubic;
      private System.Windows.Forms.RadioButton _rbButtonBicubic;
      private System.Windows.Forms.RadioButton _rbButtonFavorBlackOrResample;
      private System.Windows.Forms.NumericUpDown _numHeight;
      private System.Windows.Forms.Label _lblHeight;
      private System.Windows.Forms.RadioButton _rbButtonNormal;
      private System.Windows.Forms.RadioButton _rbButtonFavorBlack;
      private System.Windows.Forms.Button _btnOk;
   }
}