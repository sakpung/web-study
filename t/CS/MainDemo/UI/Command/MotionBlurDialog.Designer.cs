namespace MainDemo
{
   partial class MotionBlurDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MotionBlurDialog));
         this._lblAngle = new System.Windows.Forms.Label();
         this._numDimension = new System.Windows.Forms.NumericUpDown();
         this._gbOptions = new System.Windows.Forms.GroupBox();
         this._cbUniDirectional = new System.Windows.Forms.CheckBox();
         this._numAngle = new System.Windows.Forms.NumericUpDown();
         this._lblDimension = new System.Windows.Forms.Label();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         ((System.ComponentModel.ISupportInitialize)(this._numDimension)).BeginInit();
         this._gbOptions.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numAngle)).BeginInit();
         this.SuspendLayout();
         // 
         // _lblAngle
         // 
         this._lblAngle.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblAngle, "_lblAngle");
         this._lblAngle.Name = "_lblAngle";
         // 
         // _numDimension
         // 
         resources.ApplyResources(this._numDimension, "_numDimension");
         this._numDimension.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
         this._numDimension.Name = "_numDimension";
         this._numDimension.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numDimension.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _gbOptions
         // 
         this._gbOptions.Controls.Add(this._cbUniDirectional);
         this._gbOptions.Controls.Add(this._numAngle);
         this._gbOptions.Controls.Add(this._lblAngle);
         this._gbOptions.Controls.Add(this._numDimension);
         this._gbOptions.Controls.Add(this._lblDimension);
         this._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbOptions, "_gbOptions");
         this._gbOptions.Name = "_gbOptions";
         this._gbOptions.TabStop = false;
         // 
         // _cbUniDirectional
         // 
         resources.ApplyResources(this._cbUniDirectional, "_cbUniDirectional");
         this._cbUniDirectional.Name = "_cbUniDirectional";
         // 
         // _numAngle
         // 
         resources.ApplyResources(this._numAngle, "_numAngle");
         this._numAngle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
         this._numAngle.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numAngle.Name = "_numAngle";
         this._numAngle.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numAngle.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _lblDimension
         // 
         this._lblDimension.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblDimension, "_lblDimension");
         this._lblDimension.Name = "_lblDimension";
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
         // MotionBlurDialog
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
         this.Name = "MotionBlurDialog";
         this.ShowInTaskbar = false;
         this.Load += new System.EventHandler(this.MotionBlurDialog_Load);
         ((System.ComponentModel.ISupportInitialize)(this._numDimension)).EndInit();
         this._gbOptions.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this._numAngle)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Label _lblAngle;
      private System.Windows.Forms.NumericUpDown _numDimension;
      private System.Windows.Forms.GroupBox _gbOptions;
      private System.Windows.Forms.CheckBox _cbUniDirectional;
      private System.Windows.Forms.NumericUpDown _numAngle;
      private System.Windows.Forms.Label _lblDimension;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
   }
}