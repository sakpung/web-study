namespace MainDemo
{
   partial class LineRemoveDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LineRemoveDialog));
         this._lblUnitsHeight = new System.Windows.Forms.Label();
         this._lblUnitsWidth = new System.Windows.Forms.Label();
         this._lblUnits = new System.Windows.Forms.Label();
         this._lblWall = new System.Windows.Forms.Label();
         this._numWall = new System.Windows.Forms.NumericUpDown();
         this._cbUseDpi = new System.Windows.Forms.CheckBox();
         this._cbUseGap = new System.Windows.Forms.CheckBox();
         this._cbUseVariance = new System.Windows.Forms.CheckBox();
         this._lblMinLineLength = new System.Windows.Forms.Label();
         this._numMinLineLength = new System.Windows.Forms.NumericUpDown();
         this._lblMaxWallPercent = new System.Windows.Forms.Label();
         this._numMaxWallPercent = new System.Windows.Forms.NumericUpDown();
         this._gbOptions = new System.Windows.Forms.GroupBox();
         this._lblMaxLineWidth = new System.Windows.Forms.Label();
         this._numMaxLineWidth = new System.Windows.Forms.NumericUpDown();
         this._numLineVariance = new System.Windows.Forms.NumericUpDown();
         this._lblGapLength = new System.Windows.Forms.Label();
         this._lblLineVariance = new System.Windows.Forms.Label();
         this._numGapLength = new System.Windows.Forms.NumericUpDown();
         this._btnCancel = new System.Windows.Forms.Button();
         this._cbRemoveEntire = new System.Windows.Forms.CheckBox();
         this._rbVertical = new System.Windows.Forms.RadioButton();
         this._cbImageUnchanged = new System.Windows.Forms.CheckBox();
         this._btnOk = new System.Windows.Forms.Button();
         this._gbBorder = new System.Windows.Forms.GroupBox();
         this._rbHorizontal = new System.Windows.Forms.RadioButton();
         this._gbFlags = new System.Windows.Forms.GroupBox();
         ((System.ComponentModel.ISupportInitialize)(this._numWall)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numMinLineLength)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numMaxWallPercent)).BeginInit();
         this._gbOptions.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numMaxLineWidth)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numLineVariance)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numGapLength)).BeginInit();
         this._gbBorder.SuspendLayout();
         this._gbFlags.SuspendLayout();
         this.SuspendLayout();
         // 
         // _lblUnitsHeight
         // 
         this._lblUnitsHeight.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblUnitsHeight, "_lblUnitsHeight");
         this._lblUnitsHeight.Name = "_lblUnitsHeight";
         // 
         // _lblUnitsWidth
         // 
         this._lblUnitsWidth.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblUnitsWidth, "_lblUnitsWidth");
         this._lblUnitsWidth.Name = "_lblUnitsWidth";
         // 
         // _lblUnits
         // 
         this._lblUnits.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblUnits, "_lblUnits");
         this._lblUnits.Name = "_lblUnits";
         // 
         // _lblWall
         // 
         this._lblWall.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblWall, "_lblWall");
         this._lblWall.Name = "_lblWall";
         // 
         // _numWall
         // 
         resources.ApplyResources(this._numWall, "_numWall");
         this._numWall.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
         this._numWall.Name = "_numWall";
         this._numWall.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _cbUseDpi
         // 
         resources.ApplyResources(this._cbUseDpi, "_cbUseDpi");
         this._cbUseDpi.Name = "_cbUseDpi";
         this._cbUseDpi.CheckedChanged += new System.EventHandler(this._cbUseDpi_CheckedChanged);
         // 
         // _cbUseGap
         // 
         resources.ApplyResources(this._cbUseGap, "_cbUseGap");
         this._cbUseGap.Name = "_cbUseGap";
         this._cbUseGap.CheckedChanged += new System.EventHandler(this._cbUseGap_CheckedChanged);
         // 
         // _cbUseVariance
         // 
         resources.ApplyResources(this._cbUseVariance, "_cbUseVariance");
         this._cbUseVariance.Name = "_cbUseVariance";
         this._cbUseVariance.CheckedChanged += new System.EventHandler(this._cbUseVariance_CheckedChanged);
         // 
         // _lblMinLineLength
         // 
         this._lblMinLineLength.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblMinLineLength, "_lblMinLineLength");
         this._lblMinLineLength.Name = "_lblMinLineLength";
         // 
         // _numMinLineLength
         // 
         resources.ApplyResources(this._numMinLineLength, "_numMinLineLength");
         this._numMinLineLength.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
         this._numMinLineLength.Name = "_numMinLineLength";
         this._numMinLineLength.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _lblMaxWallPercent
         // 
         this._lblMaxWallPercent.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblMaxWallPercent, "_lblMaxWallPercent");
         this._lblMaxWallPercent.Name = "_lblMaxWallPercent";
         // 
         // _numMaxWallPercent
         // 
         resources.ApplyResources(this._numMaxWallPercent, "_numMaxWallPercent");
         this._numMaxWallPercent.Name = "_numMaxWallPercent";
         this._numMaxWallPercent.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _gbOptions
         // 
         this._gbOptions.Controls.Add(this._lblUnitsHeight);
         this._gbOptions.Controls.Add(this._lblUnitsWidth);
         this._gbOptions.Controls.Add(this._lblUnits);
         this._gbOptions.Controls.Add(this._lblWall);
         this._gbOptions.Controls.Add(this._numWall);
         this._gbOptions.Controls.Add(this._lblMinLineLength);
         this._gbOptions.Controls.Add(this._numMinLineLength);
         this._gbOptions.Controls.Add(this._lblMaxWallPercent);
         this._gbOptions.Controls.Add(this._numMaxWallPercent);
         this._gbOptions.Controls.Add(this._lblMaxLineWidth);
         this._gbOptions.Controls.Add(this._numMaxLineWidth);
         this._gbOptions.Controls.Add(this._numLineVariance);
         this._gbOptions.Controls.Add(this._lblGapLength);
         this._gbOptions.Controls.Add(this._lblLineVariance);
         this._gbOptions.Controls.Add(this._numGapLength);
         this._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbOptions, "_gbOptions");
         this._gbOptions.Name = "_gbOptions";
         this._gbOptions.TabStop = false;
         // 
         // _lblMaxLineWidth
         // 
         this._lblMaxLineWidth.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblMaxLineWidth, "_lblMaxLineWidth");
         this._lblMaxLineWidth.Name = "_lblMaxLineWidth";
         // 
         // _numMaxLineWidth
         // 
         resources.ApplyResources(this._numMaxLineWidth, "_numMaxLineWidth");
         this._numMaxLineWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
         this._numMaxLineWidth.Name = "_numMaxLineWidth";
         this._numMaxLineWidth.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _numLineVariance
         // 
         resources.ApplyResources(this._numLineVariance, "_numLineVariance");
         this._numLineVariance.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
         this._numLineVariance.Name = "_numLineVariance";
         this._numLineVariance.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _lblGapLength
         // 
         this._lblGapLength.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblGapLength, "_lblGapLength");
         this._lblGapLength.Name = "_lblGapLength";
         // 
         // _lblLineVariance
         // 
         this._lblLineVariance.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblLineVariance, "_lblLineVariance");
         this._lblLineVariance.Name = "_lblLineVariance";
         // 
         // _numGapLength
         // 
         resources.ApplyResources(this._numGapLength, "_numGapLength");
         this._numGapLength.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
         this._numGapLength.Name = "_numGapLength";
         this._numGapLength.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numGapLength.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         resources.ApplyResources(this._btnCancel, "_btnCancel");
         this._btnCancel.Name = "_btnCancel";
         // 
         // _cbRemoveEntire
         // 
         resources.ApplyResources(this._cbRemoveEntire, "_cbRemoveEntire");
         this._cbRemoveEntire.Name = "_cbRemoveEntire";
         // 
         // _rbVertical
         // 
         resources.ApplyResources(this._rbVertical, "_rbVertical");
         this._rbVertical.Name = "_rbVertical";
         // 
         // _cbImageUnchanged
         // 
         resources.ApplyResources(this._cbImageUnchanged, "_cbImageUnchanged");
         this._cbImageUnchanged.Name = "_cbImageUnchanged";
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         resources.ApplyResources(this._btnOk, "_btnOk");
         this._btnOk.Name = "_btnOk";
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _gbBorder
         // 
         this._gbBorder.Controls.Add(this._rbVertical);
         this._gbBorder.Controls.Add(this._rbHorizontal);
         this._gbBorder.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbBorder, "_gbBorder");
         this._gbBorder.Name = "_gbBorder";
         this._gbBorder.TabStop = false;
         // 
         // _rbHorizontal
         // 
         resources.ApplyResources(this._rbHorizontal, "_rbHorizontal");
         this._rbHorizontal.Name = "_rbHorizontal";
         // 
         // _gbFlags
         // 
         this._gbFlags.Controls.Add(this._cbUseDpi);
         this._gbFlags.Controls.Add(this._cbUseGap);
         this._gbFlags.Controls.Add(this._cbUseVariance);
         this._gbFlags.Controls.Add(this._cbRemoveEntire);
         this._gbFlags.Controls.Add(this._cbImageUnchanged);
         this._gbFlags.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbFlags, "_gbFlags");
         this._gbFlags.Name = "_gbFlags";
         this._gbFlags.TabStop = false;
         // 
         // LineRemoveDialog
         // 
         this.AcceptButton = this._btnOk;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.Controls.Add(this._gbOptions);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._gbBorder);
         this.Controls.Add(this._gbFlags);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "LineRemoveDialog";
         this.ShowInTaskbar = false;
         this.Load += new System.EventHandler(this.LineRemoveDialog_Load);
         ((System.ComponentModel.ISupportInitialize)(this._numWall)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numMinLineLength)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numMaxWallPercent)).EndInit();
         this._gbOptions.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this._numMaxLineWidth)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numLineVariance)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numGapLength)).EndInit();
         this._gbBorder.ResumeLayout(false);
         this._gbFlags.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Label _lblUnitsHeight;
      private System.Windows.Forms.Label _lblUnitsWidth;
      private System.Windows.Forms.Label _lblUnits;
      private System.Windows.Forms.Label _lblWall;
      private System.Windows.Forms.NumericUpDown _numWall;
      private System.Windows.Forms.CheckBox _cbUseDpi;
      private System.Windows.Forms.CheckBox _cbUseGap;
      private System.Windows.Forms.CheckBox _cbUseVariance;
      private System.Windows.Forms.Label _lblMinLineLength;
      private System.Windows.Forms.NumericUpDown _numMinLineLength;
      private System.Windows.Forms.Label _lblMaxWallPercent;
      private System.Windows.Forms.NumericUpDown _numMaxWallPercent;
      private System.Windows.Forms.GroupBox _gbOptions;
      private System.Windows.Forms.Label _lblMaxLineWidth;
      private System.Windows.Forms.NumericUpDown _numMaxLineWidth;
      private System.Windows.Forms.NumericUpDown _numLineVariance;
      private System.Windows.Forms.Label _lblGapLength;
      private System.Windows.Forms.Label _lblLineVariance;
      private System.Windows.Forms.NumericUpDown _numGapLength;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.CheckBox _cbRemoveEntire;
      private System.Windows.Forms.RadioButton _rbVertical;
      private System.Windows.Forms.CheckBox _cbImageUnchanged;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.GroupBox _gbBorder;
      private System.Windows.Forms.RadioButton _rbHorizontal;
      private System.Windows.Forms.GroupBox _gbFlags;
   }
}