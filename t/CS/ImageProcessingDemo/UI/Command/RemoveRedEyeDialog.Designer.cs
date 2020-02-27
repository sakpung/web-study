namespace ImageProcessingDemo
{
   partial class RemoveRedEyeDialog
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RemoveRedEyeDialog));
          this._gbRemoveRedEye = new System.Windows.Forms.GroupBox();
          this._lblLightness = new System.Windows.Forms.Label();
          this._lblThreshold = new System.Windows.Forms.Label();
          this._lblBlue = new System.Windows.Forms.Label();
          this._lblGreen = new System.Windows.Forms.Label();
          this._lblRed = new System.Windows.Forms.Label();
          this._tbLightness = new System.Windows.Forms.TrackBar();
          this._tbThreshold = new System.Windows.Forms.TrackBar();
          this._tbBlue = new System.Windows.Forms.TrackBar();
          this._tbGreen = new System.Windows.Forms.TrackBar();
          this._tbRed = new System.Windows.Forms.TrackBar();
          this._numLightness = new System.Windows.Forms.NumericUpDown();
          this._numThreshold = new System.Windows.Forms.NumericUpDown();
          this._numBlue = new System.Windows.Forms.NumericUpDown();
          this._numGreen = new System.Windows.Forms.NumericUpDown();
          this._numRed = new System.Windows.Forms.NumericUpDown();
          this._btnCancel = new System.Windows.Forms.Button();
          this._btnOk = new System.Windows.Forms.Button();
          this._gbRemoveRedEye.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this._tbLightness)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._tbThreshold)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._tbBlue)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._tbGreen)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._tbRed)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._numLightness)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._numThreshold)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._numBlue)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._numGreen)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._numRed)).BeginInit();
          this.SuspendLayout();
          // 
          // _gbRemoveRedEye
          // 
          this._gbRemoveRedEye.Controls.Add(this._lblLightness);
          this._gbRemoveRedEye.Controls.Add(this._lblThreshold);
          this._gbRemoveRedEye.Controls.Add(this._lblBlue);
          this._gbRemoveRedEye.Controls.Add(this._lblGreen);
          this._gbRemoveRedEye.Controls.Add(this._lblRed);
          this._gbRemoveRedEye.Controls.Add(this._tbLightness);
          this._gbRemoveRedEye.Controls.Add(this._tbThreshold);
          this._gbRemoveRedEye.Controls.Add(this._tbBlue);
          this._gbRemoveRedEye.Controls.Add(this._tbGreen);
          this._gbRemoveRedEye.Controls.Add(this._tbRed);
          this._gbRemoveRedEye.Controls.Add(this._numLightness);
          this._gbRemoveRedEye.Controls.Add(this._numThreshold);
          this._gbRemoveRedEye.Controls.Add(this._numBlue);
          this._gbRemoveRedEye.Controls.Add(this._numGreen);
          this._gbRemoveRedEye.Controls.Add(this._numRed);
          resources.ApplyResources(this._gbRemoveRedEye, "_gbRemoveRedEye");
          this._gbRemoveRedEye.Name = "_gbRemoveRedEye";
          this._gbRemoveRedEye.TabStop = false;
          // 
          // _lblLightness
          // 
          this._lblLightness.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._lblLightness, "_lblLightness");
          this._lblLightness.Name = "_lblLightness";
          // 
          // _lblThreshold
          // 
          this._lblThreshold.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._lblThreshold, "_lblThreshold");
          this._lblThreshold.Name = "_lblThreshold";
          // 
          // _lblBlue
          // 
          this._lblBlue.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._lblBlue, "_lblBlue");
          this._lblBlue.Name = "_lblBlue";
          // 
          // _lblGreen
          // 
          this._lblGreen.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._lblGreen, "_lblGreen");
          this._lblGreen.Name = "_lblGreen";
          // 
          // _lblRed
          // 
          this._lblRed.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._lblRed, "_lblRed");
          this._lblRed.Name = "_lblRed";
          // 
          // _tbLightness
          // 
          resources.ApplyResources(this._tbLightness, "_tbLightness");
          this._tbLightness.Maximum = 255;
          this._tbLightness.Name = "_tbLightness";
          this._tbLightness.TickStyle = System.Windows.Forms.TickStyle.None;
          this._tbLightness.Scroll += new System.EventHandler(this._tbLightness_Scroll);
          // 
          // _tbThreshold
          // 
          resources.ApplyResources(this._tbThreshold, "_tbThreshold");
          this._tbThreshold.Maximum = 255;
          this._tbThreshold.Name = "_tbThreshold";
          this._tbThreshold.TickStyle = System.Windows.Forms.TickStyle.None;
          this._tbThreshold.Scroll += new System.EventHandler(this._tbThreshold_Scroll);
          // 
          // _tbBlue
          // 
          resources.ApplyResources(this._tbBlue, "_tbBlue");
          this._tbBlue.Maximum = 255;
          this._tbBlue.Name = "_tbBlue";
          this._tbBlue.TickStyle = System.Windows.Forms.TickStyle.None;
          this._tbBlue.Scroll += new System.EventHandler(this._tbBlue_Scroll);
          // 
          // _tbGreen
          // 
          resources.ApplyResources(this._tbGreen, "_tbGreen");
          this._tbGreen.Maximum = 255;
          this._tbGreen.Name = "_tbGreen";
          this._tbGreen.TickStyle = System.Windows.Forms.TickStyle.None;
          this._tbGreen.Scroll += new System.EventHandler(this._tbGreen_Scroll);
          // 
          // _tbRed
          // 
          resources.ApplyResources(this._tbRed, "_tbRed");
          this._tbRed.Maximum = 255;
          this._tbRed.Name = "_tbRed";
          this._tbRed.TickStyle = System.Windows.Forms.TickStyle.None;
          this._tbRed.Scroll += new System.EventHandler(this._tbRed_Scroll);
          // 
          // _numLightness
          // 
          resources.ApplyResources(this._numLightness, "_numLightness");
          this._numLightness.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
          this._numLightness.Name = "_numLightness";
          this._numLightness.ValueChanged += new System.EventHandler(this._numLightness_ValueChanged);
          this._numLightness.Leave += new System.EventHandler(this._numLightness_Leave);
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
          this._numThreshold.ValueChanged += new System.EventHandler(this._numThreshold_ValueChanged);
          this._numThreshold.Leave += new System.EventHandler(this._numThreshold_Leave);
          // 
          // _numBlue
          // 
          resources.ApplyResources(this._numBlue, "_numBlue");
          this._numBlue.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
          this._numBlue.Name = "_numBlue";
          this._numBlue.ValueChanged += new System.EventHandler(this._numBlue_ValueChanged);
          this._numBlue.Leave += new System.EventHandler(this._numBlue_Leave);
          // 
          // _numGreen
          // 
          resources.ApplyResources(this._numGreen, "_numGreen");
          this._numGreen.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
          this._numGreen.Name = "_numGreen";
          this._numGreen.ValueChanged += new System.EventHandler(this._numGreen_ValueChanged);
          this._numGreen.Leave += new System.EventHandler(this._numGreen_Leave);
          // 
          // _numRed
          // 
          resources.ApplyResources(this._numRed, "_numRed");
          this._numRed.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
          this._numRed.Name = "_numRed";
          this._numRed.ValueChanged += new System.EventHandler(this._numRed_ValueChanged);
          this._numRed.Leave += new System.EventHandler(this._numRed_Leave);
          // 
          // _btnCancel
          // 
          this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          resources.ApplyResources(this._btnCancel, "_btnCancel");
          this._btnCancel.Name = "_btnCancel";
          this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
          // 
          // _btnOk
          // 
          this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
          resources.ApplyResources(this._btnOk, "_btnOk");
          this._btnOk.Name = "_btnOk";
          this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
          // 
          // RemoveRedEyeDialog
          // 
          this.AcceptButton = this._btnOk;
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._btnCancel;
          this.Controls.Add(this._btnCancel);
          this.Controls.Add(this._btnOk);
          this.Controls.Add(this._gbRemoveRedEye);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "RemoveRedEyeDialog";
          this.ShowIcon = false;
          this._gbRemoveRedEye.ResumeLayout(false);
          ((System.ComponentModel.ISupportInitialize)(this._tbLightness)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._tbThreshold)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._tbBlue)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._tbGreen)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._tbRed)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._numLightness)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._numThreshold)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._numBlue)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._numGreen)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._numRed)).EndInit();
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gbRemoveRedEye;
      private System.Windows.Forms.Label _lblLightness;
      private System.Windows.Forms.Label _lblThreshold;
      private System.Windows.Forms.Label _lblBlue;
      private System.Windows.Forms.Label _lblGreen;
      private System.Windows.Forms.Label _lblRed;
      public System.Windows.Forms.TrackBar _tbLightness;
      public System.Windows.Forms.TrackBar _tbThreshold;
      public System.Windows.Forms.TrackBar _tbBlue;
      public System.Windows.Forms.TrackBar _tbGreen;
      public System.Windows.Forms.TrackBar _tbRed;
      private System.Windows.Forms.NumericUpDown _numLightness;
      private System.Windows.Forms.NumericUpDown _numThreshold;
      private System.Windows.Forms.NumericUpDown _numBlue;
      private System.Windows.Forms.NumericUpDown _numGreen;
      private System.Windows.Forms.NumericUpDown _numRed;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
   }
}