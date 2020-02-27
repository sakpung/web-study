namespace ImageProcessingDemo
{
   partial class ChangeHueSaturationIntensityDialog
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeHueSaturationIntensityDialog));
          this._cmbMask = new System.Windows.Forms.ComboBox();
          this._lblMask = new System.Windows.Forms.Label();
          this._gbSourceChannels = new System.Windows.Forms.GroupBox();
          this._lblIntensity = new System.Windows.Forms.Label();
          this._lblSaturation = new System.Windows.Forms.Label();
          this._lblHue = new System.Windows.Forms.Label();
          this._tbIntensity = new System.Windows.Forms.TrackBar();
          this._tbSaturation = new System.Windows.Forms.TrackBar();
          this._tbHue = new System.Windows.Forms.TrackBar();
          this._numIntensity = new System.Windows.Forms.NumericUpDown();
          this._numSaturation = new System.Windows.Forms.NumericUpDown();
          this._numHue = new System.Windows.Forms.NumericUpDown();
          this._gbOuterRange = new System.Windows.Forms.GroupBox();
          this._numOuterHigh = new System.Windows.Forms.NumericUpDown();
          this._numOuterLow = new System.Windows.Forms.NumericUpDown();
          this._tbOuterHigh = new System.Windows.Forms.TrackBar();
          this._tbOuterLow = new System.Windows.Forms.TrackBar();
          this._lblOuterHigh = new System.Windows.Forms.Label();
          this._lblOuterLow = new System.Windows.Forms.Label();
          this._gbInnerRange = new System.Windows.Forms.GroupBox();
          this._lblInnerHigh = new System.Windows.Forms.Label();
          this._numInnerHigh = new System.Windows.Forms.NumericUpDown();
          this._lblInnerLow = new System.Windows.Forms.Label();
          this._tbInnerLow = new System.Windows.Forms.TrackBar();
          this._numInnerLow = new System.Windows.Forms.NumericUpDown();
          this._tbInnerHigh = new System.Windows.Forms.TrackBar();
          this._btnCancel = new System.Windows.Forms.Button();
          this._btnok = new System.Windows.Forms.Button();
          this._gbSourceChannels.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this._tbIntensity)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._tbSaturation)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._tbHue)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._numIntensity)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._numSaturation)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._numHue)).BeginInit();
          this._gbOuterRange.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this._numOuterHigh)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._numOuterLow)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._tbOuterHigh)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._tbOuterLow)).BeginInit();
          this._gbInnerRange.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this._numInnerHigh)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._tbInnerLow)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._numInnerLow)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._tbInnerHigh)).BeginInit();
          this.SuspendLayout();
          // 
          // _cmbMask
          // 
          this._cmbMask.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          resources.ApplyResources(this._cmbMask, "_cmbMask");
          this._cmbMask.FormattingEnabled = true;
          this._cmbMask.Name = "_cmbMask";
          this._cmbMask.SelectedIndexChanged += new System.EventHandler(this._cmbMask_SelectedIndexChanged);
          // 
          // _lblMask
          // 
          resources.ApplyResources(this._lblMask, "_lblMask");
          this._lblMask.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblMask.Name = "_lblMask";
          // 
          // _gbSourceChannels
          // 
          this._gbSourceChannels.Controls.Add(this._lblIntensity);
          this._gbSourceChannels.Controls.Add(this._lblSaturation);
          this._gbSourceChannels.Controls.Add(this._lblHue);
          this._gbSourceChannels.Controls.Add(this._tbIntensity);
          this._gbSourceChannels.Controls.Add(this._tbSaturation);
          this._gbSourceChannels.Controls.Add(this._tbHue);
          this._gbSourceChannels.Controls.Add(this._numIntensity);
          this._gbSourceChannels.Controls.Add(this._numSaturation);
          this._gbSourceChannels.Controls.Add(this._numHue);
          this._gbSourceChannels.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gbSourceChannels, "_gbSourceChannels");
          this._gbSourceChannels.Name = "_gbSourceChannels";
          this._gbSourceChannels.TabStop = false;
          // 
          // _lblIntensity
          // 
          resources.ApplyResources(this._lblIntensity, "_lblIntensity");
          this._lblIntensity.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblIntensity.Name = "_lblIntensity";
          // 
          // _lblSaturation
          // 
          resources.ApplyResources(this._lblSaturation, "_lblSaturation");
          this._lblSaturation.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblSaturation.Name = "_lblSaturation";
          // 
          // _lblHue
          // 
          resources.ApplyResources(this._lblHue, "_lblHue");
          this._lblHue.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblHue.Name = "_lblHue";
          // 
          // _tbIntensity
          // 
          resources.ApplyResources(this._tbIntensity, "_tbIntensity");
          this._tbIntensity.Maximum = 100;
          this._tbIntensity.Minimum = -100;
          this._tbIntensity.Name = "_tbIntensity";
          this._tbIntensity.TickStyle = System.Windows.Forms.TickStyle.None;
          this._tbIntensity.Scroll += new System.EventHandler(this._tbIntensity_Scroll);
          // 
          // _tbSaturation
          // 
          resources.ApplyResources(this._tbSaturation, "_tbSaturation");
          this._tbSaturation.Maximum = 100;
          this._tbSaturation.Minimum = -100;
          this._tbSaturation.Name = "_tbSaturation";
          this._tbSaturation.TickStyle = System.Windows.Forms.TickStyle.None;
          this._tbSaturation.Scroll += new System.EventHandler(this._tbSaturation_Scroll);
          // 
          // _tbHue
          // 
          resources.ApplyResources(this._tbHue, "_tbHue");
          this._tbHue.Maximum = 180;
          this._tbHue.Minimum = -180;
          this._tbHue.Name = "_tbHue";
          this._tbHue.TickStyle = System.Windows.Forms.TickStyle.None;
          this._tbHue.Scroll += new System.EventHandler(this._tbHue_Scroll);
          // 
          // _numIntensity
          // 
          resources.ApplyResources(this._numIntensity, "_numIntensity");
          this._numIntensity.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
          this._numIntensity.Name = "_numIntensity";
          this._numIntensity.ValueChanged += new System.EventHandler(this._numIntensity_ValueChanged);
          this._numIntensity.Leave += new System.EventHandler(this._numIntensity_Leave);
          // 
          // _numSaturation
          // 
          resources.ApplyResources(this._numSaturation, "_numSaturation");
          this._numSaturation.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
          this._numSaturation.Name = "_numSaturation";
          this._numSaturation.ValueChanged += new System.EventHandler(this._numSaturation_ValueChanged);
          this._numSaturation.Leave += new System.EventHandler(this._numSaturation_Leave);
          // 
          // _numHue
          // 
          resources.ApplyResources(this._numHue, "_numHue");
          this._numHue.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
          this._numHue.Minimum = new decimal(new int[] {
            180,
            0,
            0,
            -2147483648});
          this._numHue.Name = "_numHue";
          this._numHue.ValueChanged += new System.EventHandler(this._numHue_ValueChanged);
          this._numHue.Leave += new System.EventHandler(this._numHue_Leave);
          // 
          // _gbOuterRange
          // 
          this._gbOuterRange.Controls.Add(this._numOuterHigh);
          this._gbOuterRange.Controls.Add(this._numOuterLow);
          this._gbOuterRange.Controls.Add(this._tbOuterHigh);
          this._gbOuterRange.Controls.Add(this._tbOuterLow);
          this._gbOuterRange.Controls.Add(this._lblOuterHigh);
          this._gbOuterRange.Controls.Add(this._lblOuterLow);
          resources.ApplyResources(this._gbOuterRange, "_gbOuterRange");
          this._gbOuterRange.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._gbOuterRange.Name = "_gbOuterRange";
          this._gbOuterRange.TabStop = false;
          // 
          // _numOuterHigh
          // 
          resources.ApplyResources(this._numOuterHigh, "_numOuterHigh");
          this._numOuterHigh.Maximum = new decimal(new int[] {
            359,
            0,
            0,
            0});
          this._numOuterHigh.Name = "_numOuterHigh";
          this._numOuterHigh.ValueChanged += new System.EventHandler(this._numOuterHigh_ValueChanged);
          this._numOuterHigh.Leave += new System.EventHandler(this._numOuterHigh_Leave);
          // 
          // _numOuterLow
          // 
          resources.ApplyResources(this._numOuterLow, "_numOuterLow");
          this._numOuterLow.Maximum = new decimal(new int[] {
            356,
            0,
            0,
            0});
          this._numOuterLow.Name = "_numOuterLow";
          this._numOuterLow.ValueChanged += new System.EventHandler(this._numOuterLow_ValueChanged);
          this._numOuterLow.Leave += new System.EventHandler(this._numOuterLow_Leave);
          // 
          // _tbOuterHigh
          // 
          resources.ApplyResources(this._tbOuterHigh, "_tbOuterHigh");
          this._tbOuterHigh.Maximum = 359;
          this._tbOuterHigh.Name = "_tbOuterHigh";
          this._tbOuterHigh.TickStyle = System.Windows.Forms.TickStyle.None;
          this._tbOuterHigh.Scroll += new System.EventHandler(this._tbOuterHigh_Scroll);
          // 
          // _tbOuterLow
          // 
          resources.ApplyResources(this._tbOuterLow, "_tbOuterLow");
          this._tbOuterLow.Maximum = 356;
          this._tbOuterLow.Name = "_tbOuterLow";
          this._tbOuterLow.TickStyle = System.Windows.Forms.TickStyle.None;
          this._tbOuterLow.Scroll += new System.EventHandler(this._tbOuterLow_Scroll);
          // 
          // _lblOuterHigh
          // 
          resources.ApplyResources(this._lblOuterHigh, "_lblOuterHigh");
          this._lblOuterHigh.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblOuterHigh.Name = "_lblOuterHigh";
          // 
          // _lblOuterLow
          // 
          resources.ApplyResources(this._lblOuterLow, "_lblOuterLow");
          this._lblOuterLow.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblOuterLow.Name = "_lblOuterLow";
          // 
          // _gbInnerRange
          // 
          this._gbInnerRange.Controls.Add(this._lblInnerHigh);
          this._gbInnerRange.Controls.Add(this._numInnerHigh);
          this._gbInnerRange.Controls.Add(this._lblInnerLow);
          this._gbInnerRange.Controls.Add(this._tbInnerLow);
          this._gbInnerRange.Controls.Add(this._numInnerLow);
          this._gbInnerRange.Controls.Add(this._tbInnerHigh);
          resources.ApplyResources(this._gbInnerRange, "_gbInnerRange");
          this._gbInnerRange.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._gbInnerRange.Name = "_gbInnerRange";
          this._gbInnerRange.TabStop = false;
          // 
          // _lblInnerHigh
          // 
          resources.ApplyResources(this._lblInnerHigh, "_lblInnerHigh");
          this._lblInnerHigh.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblInnerHigh.Name = "_lblInnerHigh";
          // 
          // _numInnerHigh
          // 
          resources.ApplyResources(this._numInnerHigh, "_numInnerHigh");
          this._numInnerHigh.Maximum = new decimal(new int[] {
            358,
            0,
            0,
            0});
          this._numInnerHigh.Name = "_numInnerHigh";
          this._numInnerHigh.ValueChanged += new System.EventHandler(this._numInnerHigh_ValueChanged);
          this._numInnerHigh.Leave += new System.EventHandler(this._numInnerHigh_Leave);
          // 
          // _lblInnerLow
          // 
          resources.ApplyResources(this._lblInnerLow, "_lblInnerLow");
          this._lblInnerLow.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblInnerLow.Name = "_lblInnerLow";
          // 
          // _tbInnerLow
          // 
          resources.ApplyResources(this._tbInnerLow, "_tbInnerLow");
          this._tbInnerLow.Maximum = 357;
          this._tbInnerLow.Name = "_tbInnerLow";
          this._tbInnerLow.TickStyle = System.Windows.Forms.TickStyle.None;
          this._tbInnerLow.Scroll += new System.EventHandler(this._tbInnerLow_Scroll);
          // 
          // _numInnerLow
          // 
          resources.ApplyResources(this._numInnerLow, "_numInnerLow");
          this._numInnerLow.Maximum = new decimal(new int[] {
            357,
            0,
            0,
            0});
          this._numInnerLow.Name = "_numInnerLow";
          this._numInnerLow.ValueChanged += new System.EventHandler(this._numInnerLow_ValueChanged);
          this._numInnerLow.Leave += new System.EventHandler(this._numInnerLow_Leave);
          // 
          // _tbInnerHigh
          // 
          resources.ApplyResources(this._tbInnerHigh, "_tbInnerHigh");
          this._tbInnerHigh.Maximum = 358;
          this._tbInnerHigh.Name = "_tbInnerHigh";
          this._tbInnerHigh.TickStyle = System.Windows.Forms.TickStyle.None;
          this._tbInnerHigh.Scroll += new System.EventHandler(this._tbInnerHigh_Scroll);
          // 
          // _btnCancel
          // 
          this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          resources.ApplyResources(this._btnCancel, "_btnCancel");
          this._btnCancel.Name = "_btnCancel";
          this._btnCancel.UseVisualStyleBackColor = true;
          this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
          // 
          // _btnok
          // 
          resources.ApplyResources(this._btnok, "_btnok");
          this._btnok.Name = "_btnok";
          this._btnok.UseVisualStyleBackColor = true;
          this._btnok.Click += new System.EventHandler(this._btnok_Click);
          // 
          // ChangeHueSaturationIntensityDialog
          // 
          this.AcceptButton = this._btnok;
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._btnCancel;
          this.Controls.Add(this._btnCancel);
          this.Controls.Add(this._btnok);
          this.Controls.Add(this._gbInnerRange);
          this.Controls.Add(this._gbOuterRange);
          this.Controls.Add(this._gbSourceChannels);
          this.Controls.Add(this._lblMask);
          this.Controls.Add(this._cmbMask);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "ChangeHueSaturationIntensityDialog";
          this.ShowIcon = false;
          this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.ChangeHueSaturationIntensityDialog_MouseMove);
          this._gbSourceChannels.ResumeLayout(false);
          this._gbSourceChannels.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this._tbIntensity)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._tbSaturation)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._tbHue)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._numIntensity)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._numSaturation)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._numHue)).EndInit();
          this._gbOuterRange.ResumeLayout(false);
          this._gbOuterRange.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this._numOuterHigh)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._numOuterLow)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._tbOuterHigh)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._tbOuterLow)).EndInit();
          this._gbInnerRange.ResumeLayout(false);
          this._gbInnerRange.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this._numInnerHigh)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._tbInnerLow)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._numInnerLow)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._tbInnerHigh)).EndInit();
          this.ResumeLayout(false);
          this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.ComboBox _cmbMask;
      private System.Windows.Forms.Label _lblMask;
      private System.Windows.Forms.GroupBox _gbSourceChannels;
      private System.Windows.Forms.GroupBox _gbOuterRange;
      private System.Windows.Forms.GroupBox _gbInnerRange;
      public System.Windows.Forms.TrackBar _tbIntensity;
      public System.Windows.Forms.TrackBar _tbSaturation;
      public System.Windows.Forms.TrackBar _tbHue;
      private System.Windows.Forms.NumericUpDown _numIntensity;
      private System.Windows.Forms.NumericUpDown _numSaturation;
      private System.Windows.Forms.NumericUpDown _numHue;
      private System.Windows.Forms.Label _lblIntensity;
      private System.Windows.Forms.Label _lblSaturation;
      private System.Windows.Forms.Label _lblHue;
      private System.Windows.Forms.NumericUpDown _numOuterHigh;
      private System.Windows.Forms.NumericUpDown _numOuterLow;
      public System.Windows.Forms.TrackBar _tbOuterHigh;
      public System.Windows.Forms.TrackBar _tbOuterLow;
      private System.Windows.Forms.Label _lblOuterHigh;
      private System.Windows.Forms.Label _lblOuterLow;
      private System.Windows.Forms.Label _lblInnerHigh;
      private System.Windows.Forms.NumericUpDown _numInnerHigh;
      private System.Windows.Forms.Label _lblInnerLow;
      public System.Windows.Forms.TrackBar _tbInnerLow;
      private System.Windows.Forms.NumericUpDown _numInnerLow;
      public System.Windows.Forms.TrackBar _tbInnerHigh;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnok;
   }
}