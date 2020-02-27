namespace ImageProcessingDemo
{
   partial class ColorHalftoneDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorHalftoneDialog));
         this._gbBlackAngle = new System.Windows.Forms.GroupBox();
         this._numBlackAngle = new System.Windows.Forms.NumericUpDown();
         this._tbBlackAngle = new System.Windows.Forms.TrackBar();
         this._gbCyanAngle = new System.Windows.Forms.GroupBox();
         this._numCyanAngle = new System.Windows.Forms.NumericUpDown();
         this._tbCyanAngle = new System.Windows.Forms.TrackBar();
         this._gbMagentaAngle = new System.Windows.Forms.GroupBox();
         this._numMagentaAngle = new System.Windows.Forms.NumericUpDown();
         this._tbMagentaAngle = new System.Windows.Forms.TrackBar();
         this._gbYellowAngle = new System.Windows.Forms.GroupBox();
         this._numYellowAngle = new System.Windows.Forms.NumericUpDown();
         this._tbYellowAngle = new System.Windows.Forms.TrackBar();
         this._tbRadius = new System.Windows.Forms.TrackBar();
         this._gbRadius = new System.Windows.Forms.GroupBox();
         this._numRadius = new System.Windows.Forms.NumericUpDown();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._gbBlackAngle.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numBlackAngle)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._tbBlackAngle)).BeginInit();
         this._gbCyanAngle.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numCyanAngle)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._tbCyanAngle)).BeginInit();
         this._gbMagentaAngle.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numMagentaAngle)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._tbMagentaAngle)).BeginInit();
         this._gbYellowAngle.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numYellowAngle)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._tbYellowAngle)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._tbRadius)).BeginInit();
         this._gbRadius.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numRadius)).BeginInit();
         this.SuspendLayout();
         // 
         // _gbBlackAngle
         // 
         this._gbBlackAngle.Controls.Add(this._numBlackAngle);
         this._gbBlackAngle.Controls.Add(this._tbBlackAngle);
         this._gbBlackAngle.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbBlackAngle, "_gbBlackAngle");
         this._gbBlackAngle.Name = "_gbBlackAngle";
         this._gbBlackAngle.TabStop = false;
         // 
         // _numBlackAngle
         // 
         resources.ApplyResources(this._numBlackAngle, "_numBlackAngle");
         this._numBlackAngle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
         this._numBlackAngle.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
         this._numBlackAngle.Name = "_numBlackAngle";
         this._numBlackAngle.ValueChanged += new System.EventHandler(this._numBlackAngle_ValueChanged);
         this._numBlackAngle.Leave += new System.EventHandler(this._numBlackAngle_Leave);
         // 
         // _tbBlackAngle
         // 
         resources.ApplyResources(this._tbBlackAngle, "_tbBlackAngle");
         this._tbBlackAngle.Maximum = 360;
         this._tbBlackAngle.Minimum = -360;
         this._tbBlackAngle.Name = "_tbBlackAngle";
         this._tbBlackAngle.TickStyle = System.Windows.Forms.TickStyle.None;
         this._tbBlackAngle.Scroll += new System.EventHandler(this._tbBlackAngle_Scroll);
         // 
         // _gbCyanAngle
         // 
         this._gbCyanAngle.Controls.Add(this._numCyanAngle);
         this._gbCyanAngle.Controls.Add(this._tbCyanAngle);
         this._gbCyanAngle.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbCyanAngle, "_gbCyanAngle");
         this._gbCyanAngle.Name = "_gbCyanAngle";
         this._gbCyanAngle.TabStop = false;
         // 
         // _numCyanAngle
         // 
         resources.ApplyResources(this._numCyanAngle, "_numCyanAngle");
         this._numCyanAngle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
         this._numCyanAngle.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
         this._numCyanAngle.Name = "_numCyanAngle";
         this._numCyanAngle.ValueChanged += new System.EventHandler(this._numCyanAngle_ValueChanged);
         this._numCyanAngle.Leave += new System.EventHandler(this._numCyanAngle_Leave);
         // 
         // _tbCyanAngle
         // 
         resources.ApplyResources(this._tbCyanAngle, "_tbCyanAngle");
         this._tbCyanAngle.Maximum = 360;
         this._tbCyanAngle.Minimum = -360;
         this._tbCyanAngle.Name = "_tbCyanAngle";
         this._tbCyanAngle.TickStyle = System.Windows.Forms.TickStyle.None;
         this._tbCyanAngle.Scroll += new System.EventHandler(this._tbCyanAngle_Scroll);
         // 
         // _gbMagentaAngle
         // 
         this._gbMagentaAngle.Controls.Add(this._numMagentaAngle);
         this._gbMagentaAngle.Controls.Add(this._tbMagentaAngle);
         this._gbMagentaAngle.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbMagentaAngle, "_gbMagentaAngle");
         this._gbMagentaAngle.Name = "_gbMagentaAngle";
         this._gbMagentaAngle.TabStop = false;
         // 
         // _numMagentaAngle
         // 
         resources.ApplyResources(this._numMagentaAngle, "_numMagentaAngle");
         this._numMagentaAngle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
         this._numMagentaAngle.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
         this._numMagentaAngle.Name = "_numMagentaAngle";
         this._numMagentaAngle.ValueChanged += new System.EventHandler(this._numMagentaAngle_ValueChanged);
         this._numMagentaAngle.Leave += new System.EventHandler(this._numMagentaAngle_Leave);
         // 
         // _tbMagentaAngle
         // 
         resources.ApplyResources(this._tbMagentaAngle, "_tbMagentaAngle");
         this._tbMagentaAngle.Maximum = 360;
         this._tbMagentaAngle.Minimum = -360;
         this._tbMagentaAngle.Name = "_tbMagentaAngle";
         this._tbMagentaAngle.TickStyle = System.Windows.Forms.TickStyle.None;
         this._tbMagentaAngle.Scroll += new System.EventHandler(this._tbMagentaAngle_Scroll);
         // 
         // _gbYellowAngle
         // 
         this._gbYellowAngle.Controls.Add(this._numYellowAngle);
         this._gbYellowAngle.Controls.Add(this._tbYellowAngle);
         this._gbYellowAngle.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbYellowAngle, "_gbYellowAngle");
         this._gbYellowAngle.Name = "_gbYellowAngle";
         this._gbYellowAngle.TabStop = false;
         // 
         // _numYellowAngle
         // 
         resources.ApplyResources(this._numYellowAngle, "_numYellowAngle");
         this._numYellowAngle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
         this._numYellowAngle.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
         this._numYellowAngle.Name = "_numYellowAngle";
         this._numYellowAngle.ValueChanged += new System.EventHandler(this._numYellowAngle_ValueChanged);
         this._numYellowAngle.Leave += new System.EventHandler(this._numYellowAngle_Leave);
         // 
         // _tbYellowAngle
         // 
         resources.ApplyResources(this._tbYellowAngle, "_tbYellowAngle");
         this._tbYellowAngle.Maximum = 360;
         this._tbYellowAngle.Minimum = -360;
         this._tbYellowAngle.Name = "_tbYellowAngle";
         this._tbYellowAngle.TickStyle = System.Windows.Forms.TickStyle.None;
         this._tbYellowAngle.Scroll += new System.EventHandler(this._tbYellowAngle_Scroll);
         // 
         // _tbRadius
         // 
         resources.ApplyResources(this._tbRadius, "_tbRadius");
         this._tbRadius.Maximum = 127;
         this._tbRadius.Minimum = 5;
         this._tbRadius.Name = "_tbRadius";
         this._tbRadius.TickStyle = System.Windows.Forms.TickStyle.None;
         this._tbRadius.Value = 5;
         this._tbRadius.Scroll += new System.EventHandler(this._tbRadius_Scroll);
         // 
         // _gbRadius
         // 
         this._gbRadius.Controls.Add(this._numRadius);
         this._gbRadius.Controls.Add(this._tbRadius);
         this._gbRadius.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbRadius, "_gbRadius");
         this._gbRadius.Name = "_gbRadius";
         this._gbRadius.TabStop = false;
         // 
         // _numRadius
         // 
         resources.ApplyResources(this._numRadius, "_numRadius");
         this._numRadius.Maximum = new decimal(new int[] {
            127,
            0,
            0,
            0});
         this._numRadius.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
         this._numRadius.Name = "_numRadius";
         this._numRadius.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
         this._numRadius.ValueChanged += new System.EventHandler(this._numRadius_ValueChanged);
         this._numRadius.Leave += new System.EventHandler(this._numRadius_Leave);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         resources.ApplyResources(this._btnCancel, "_btnCancel");
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
         // 
         // _btnOk
         // 
         resources.ApplyResources(this._btnOk, "_btnOk");
         this._btnOk.Name = "_btnOk";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // ColorHalftoneDialog
         // 
         this.AcceptButton = this._btnOk;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._gbRadius);
         this.Controls.Add(this._gbYellowAngle);
         this.Controls.Add(this._gbMagentaAngle);
         this.Controls.Add(this._gbCyanAngle);
         this.Controls.Add(this._gbBlackAngle);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ColorHalftoneDialog";
         this.ShowIcon = false;
         this._gbBlackAngle.ResumeLayout(false);
         this._gbBlackAngle.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numBlackAngle)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._tbBlackAngle)).EndInit();
         this._gbCyanAngle.ResumeLayout(false);
         this._gbCyanAngle.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numCyanAngle)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._tbCyanAngle)).EndInit();
         this._gbMagentaAngle.ResumeLayout(false);
         this._gbMagentaAngle.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numMagentaAngle)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._tbMagentaAngle)).EndInit();
         this._gbYellowAngle.ResumeLayout(false);
         this._gbYellowAngle.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numYellowAngle)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._tbYellowAngle)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._tbRadius)).EndInit();
         this._gbRadius.ResumeLayout(false);
         this._gbRadius.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numRadius)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gbBlackAngle;
      private System.Windows.Forms.NumericUpDown _numBlackAngle;
      private System.Windows.Forms.GroupBox _gbCyanAngle;
      private System.Windows.Forms.NumericUpDown _numCyanAngle;
      private System.Windows.Forms.GroupBox _gbMagentaAngle;
      private System.Windows.Forms.NumericUpDown _numMagentaAngle;
      private System.Windows.Forms.GroupBox _gbYellowAngle;
      private System.Windows.Forms.NumericUpDown _numYellowAngle;
      public System.Windows.Forms.TrackBar _tbBlackAngle;
      public System.Windows.Forms.TrackBar _tbCyanAngle;
      public System.Windows.Forms.TrackBar _tbMagentaAngle;
      public System.Windows.Forms.TrackBar _tbYellowAngle;
      public System.Windows.Forms.TrackBar _tbRadius;
      private System.Windows.Forms.GroupBox _gbRadius;
      private System.Windows.Forms.NumericUpDown _numRadius;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
   }
}