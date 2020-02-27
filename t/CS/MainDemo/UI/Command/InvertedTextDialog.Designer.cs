namespace MainDemo
{
   partial class InvertedTextDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InvertedTextDialog));
         this._lblUnitsHeight = new System.Windows.Forms.Label();
         this._lblUnitsWidth = new System.Windows.Forms.Label();
         this._numMaxBlackPercent = new System.Windows.Forms.NumericUpDown();
         this._lblMaxBlackPercent = new System.Windows.Forms.Label();
         this._gbOptions = new System.Windows.Forms.GroupBox();
         this._lblUnits = new System.Windows.Forms.Label();
         this._lblMinBlackPercent = new System.Windows.Forms.Label();
         this._numMinBlackPercent = new System.Windows.Forms.NumericUpDown();
         this._lblMinInvertHeight = new System.Windows.Forms.Label();
         this._numMinInvertHeight = new System.Windows.Forms.NumericUpDown();
         this._lblMinInvertWidth = new System.Windows.Forms.Label();
         this._numMinInvertWidth = new System.Windows.Forms.NumericUpDown();
         this._btnCancel = new System.Windows.Forms.Button();
         this._cbUseDiagonals = new System.Windows.Forms.CheckBox();
         this._cbImageUnchanged = new System.Windows.Forms.CheckBox();
         this._btnOk = new System.Windows.Forms.Button();
         this._cbUseDpi = new System.Windows.Forms.CheckBox();
         this._gbFlags = new System.Windows.Forms.GroupBox();
         ((System.ComponentModel.ISupportInitialize)(this._numMaxBlackPercent)).BeginInit();
         this._gbOptions.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numMinBlackPercent)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numMinInvertHeight)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numMinInvertWidth)).BeginInit();
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
         // _numMaxBlackPercent
         // 
         resources.ApplyResources(this._numMaxBlackPercent, "_numMaxBlackPercent");
         this._numMaxBlackPercent.Name = "_numMaxBlackPercent";
         this._numMaxBlackPercent.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numMaxBlackPercent.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _lblMaxBlackPercent
         // 
         this._lblMaxBlackPercent.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblMaxBlackPercent, "_lblMaxBlackPercent");
         this._lblMaxBlackPercent.Name = "_lblMaxBlackPercent";
         // 
         // _gbOptions
         // 
         this._gbOptions.Controls.Add(this._lblUnits);
         this._gbOptions.Controls.Add(this._lblUnitsHeight);
         this._gbOptions.Controls.Add(this._lblUnitsWidth);
         this._gbOptions.Controls.Add(this._lblMaxBlackPercent);
         this._gbOptions.Controls.Add(this._numMaxBlackPercent);
         this._gbOptions.Controls.Add(this._lblMinBlackPercent);
         this._gbOptions.Controls.Add(this._numMinBlackPercent);
         this._gbOptions.Controls.Add(this._lblMinInvertHeight);
         this._gbOptions.Controls.Add(this._numMinInvertHeight);
         this._gbOptions.Controls.Add(this._lblMinInvertWidth);
         this._gbOptions.Controls.Add(this._numMinInvertWidth);
         this._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbOptions, "_gbOptions");
         this._gbOptions.Name = "_gbOptions";
         this._gbOptions.TabStop = false;
         // 
         // _lblUnits
         // 
         this._lblUnits.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblUnits, "_lblUnits");
         this._lblUnits.Name = "_lblUnits";
         // 
         // _lblMinBlackPercent
         // 
         this._lblMinBlackPercent.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblMinBlackPercent, "_lblMinBlackPercent");
         this._lblMinBlackPercent.Name = "_lblMinBlackPercent";
         // 
         // _numMinBlackPercent
         // 
         resources.ApplyResources(this._numMinBlackPercent, "_numMinBlackPercent");
         this._numMinBlackPercent.Name = "_numMinBlackPercent";
         this._numMinBlackPercent.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numMinBlackPercent.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _lblMinInvertHeight
         // 
         this._lblMinInvertHeight.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblMinInvertHeight, "_lblMinInvertHeight");
         this._lblMinInvertHeight.Name = "_lblMinInvertHeight";
         // 
         // _numMinInvertHeight
         // 
         resources.ApplyResources(this._numMinInvertHeight, "_numMinInvertHeight");
         this._numMinInvertHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
         this._numMinInvertHeight.Name = "_numMinInvertHeight";
         this._numMinInvertHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numMinInvertHeight.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _lblMinInvertWidth
         // 
         this._lblMinInvertWidth.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblMinInvertWidth, "_lblMinInvertWidth");
         this._lblMinInvertWidth.Name = "_lblMinInvertWidth";
         // 
         // _numMinInvertWidth
         // 
         resources.ApplyResources(this._numMinInvertWidth, "_numMinInvertWidth");
         this._numMinInvertWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
         this._numMinInvertWidth.Name = "_numMinInvertWidth";
         this._numMinInvertWidth.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         resources.ApplyResources(this._btnCancel, "_btnCancel");
         this._btnCancel.Name = "_btnCancel";
         // 
         // _cbUseDiagonals
         // 
         resources.ApplyResources(this._cbUseDiagonals, "_cbUseDiagonals");
         this._cbUseDiagonals.Name = "_cbUseDiagonals";
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
         // _cbUseDpi
         // 
         resources.ApplyResources(this._cbUseDpi, "_cbUseDpi");
         this._cbUseDpi.Name = "_cbUseDpi";
         this._cbUseDpi.CheckedChanged += new System.EventHandler(this._cbUseDpi_CheckedChanged);
         // 
         // _gbFlags
         // 
         this._gbFlags.Controls.Add(this._cbUseDpi);
         this._gbFlags.Controls.Add(this._cbUseDiagonals);
         this._gbFlags.Controls.Add(this._cbImageUnchanged);
         this._gbFlags.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbFlags, "_gbFlags");
         this._gbFlags.Name = "_gbFlags";
         this._gbFlags.TabStop = false;
         // 
         // InvertedTextDialog
         // 
         this.AcceptButton = this._btnOk;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.Controls.Add(this._gbOptions);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._gbFlags);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "InvertedTextDialog";
         this.ShowInTaskbar = false;
         this.Load += new System.EventHandler(this.InvertedTextDialog_Load);
         ((System.ComponentModel.ISupportInitialize)(this._numMaxBlackPercent)).EndInit();
         this._gbOptions.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this._numMinBlackPercent)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numMinInvertHeight)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numMinInvertWidth)).EndInit();
         this._gbFlags.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Label _lblUnitsHeight;
      private System.Windows.Forms.Label _lblUnitsWidth;
      private System.Windows.Forms.NumericUpDown _numMaxBlackPercent;
      private System.Windows.Forms.Label _lblMaxBlackPercent;
      private System.Windows.Forms.GroupBox _gbOptions;
      private System.Windows.Forms.Label _lblUnits;
      private System.Windows.Forms.Label _lblMinBlackPercent;
      private System.Windows.Forms.NumericUpDown _numMinBlackPercent;
      private System.Windows.Forms.Label _lblMinInvertHeight;
      private System.Windows.Forms.NumericUpDown _numMinInvertHeight;
      private System.Windows.Forms.Label _lblMinInvertWidth;
      private System.Windows.Forms.NumericUpDown _numMinInvertWidth;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.CheckBox _cbUseDiagonals;
      private System.Windows.Forms.CheckBox _cbImageUnchanged;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.CheckBox _cbUseDpi;
      private System.Windows.Forms.GroupBox _gbFlags;
   }
}