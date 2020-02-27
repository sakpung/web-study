namespace MainDemo
{
   partial class DotRemoveDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DotRemoveDialog));
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._gbFlags = new System.Windows.Forms.GroupBox();
         this._cbUseDiagonals = new System.Windows.Forms.CheckBox();
         this._cbUseSize = new System.Windows.Forms.CheckBox();
         this._cbUseDpi = new System.Windows.Forms.CheckBox();
         this._cbImageUnchanged = new System.Windows.Forms.CheckBox();
         this._gbOptions = new System.Windows.Forms.GroupBox();
         this._numMaxHeight = new System.Windows.Forms.NumericUpDown();
         this._numMaxWidth = new System.Windows.Forms.NumericUpDown();
         this._numMinHeight = new System.Windows.Forms.NumericUpDown();
         this._numMinWidth = new System.Windows.Forms.NumericUpDown();
         this._lblUnitsMaxHeight = new System.Windows.Forms.Label();
         this._lblUnitsMaxWidth = new System.Windows.Forms.Label();
         this._lblMaxHeight = new System.Windows.Forms.Label();
         this._lblUnitsMinHeight = new System.Windows.Forms.Label();
         this._lblMaxWidth = new System.Windows.Forms.Label();
         this._lblUnitsMinWidth = new System.Windows.Forms.Label();
         this._lblMinHeight = new System.Windows.Forms.Label();
         this._lblMinWidth = new System.Windows.Forms.Label();
         this._lblUnits = new System.Windows.Forms.Label();
         this._gbFlags.SuspendLayout();
         this._gbOptions.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numMaxHeight)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numMaxWidth)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numMinHeight)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numMinWidth)).BeginInit();
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
         // _gbFlags
         // 
         this._gbFlags.Controls.Add(this._cbUseDiagonals);
         this._gbFlags.Controls.Add(this._cbUseSize);
         this._gbFlags.Controls.Add(this._cbUseDpi);
         this._gbFlags.Controls.Add(this._cbImageUnchanged);
         this._gbFlags.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbFlags, "_gbFlags");
         this._gbFlags.Name = "_gbFlags";
         this._gbFlags.TabStop = false;
         // 
         // _cbUseDiagonals
         // 
         resources.ApplyResources(this._cbUseDiagonals, "_cbUseDiagonals");
         this._cbUseDiagonals.Name = "_cbUseDiagonals";
         this._cbUseDiagonals.UseVisualStyleBackColor = true;
         // 
         // _cbUseSize
         // 
         resources.ApplyResources(this._cbUseSize, "_cbUseSize");
         this._cbUseSize.Name = "_cbUseSize";
         this._cbUseSize.UseVisualStyleBackColor = true;
         this._cbUseSize.CheckedChanged += new System.EventHandler(this._cbUseSize_CheckedChanged);
         // 
         // _cbUseDpi
         // 
         resources.ApplyResources(this._cbUseDpi, "_cbUseDpi");
         this._cbUseDpi.Name = "_cbUseDpi";
         this._cbUseDpi.UseVisualStyleBackColor = true;
         this._cbUseDpi.CheckedChanged += new System.EventHandler(this._cbUseDpi_CheckedChanged);
         // 
         // _cbImageUnchanged
         // 
         resources.ApplyResources(this._cbImageUnchanged, "_cbImageUnchanged");
         this._cbImageUnchanged.Name = "_cbImageUnchanged";
         this._cbImageUnchanged.UseVisualStyleBackColor = true;
         // 
         // _gbOptions
         // 
         this._gbOptions.Controls.Add(this._numMaxHeight);
         this._gbOptions.Controls.Add(this._numMaxWidth);
         this._gbOptions.Controls.Add(this._numMinHeight);
         this._gbOptions.Controls.Add(this._numMinWidth);
         this._gbOptions.Controls.Add(this._lblUnitsMaxHeight);
         this._gbOptions.Controls.Add(this._lblUnitsMaxWidth);
         this._gbOptions.Controls.Add(this._lblMaxHeight);
         this._gbOptions.Controls.Add(this._lblUnitsMinHeight);
         this._gbOptions.Controls.Add(this._lblMaxWidth);
         this._gbOptions.Controls.Add(this._lblUnitsMinWidth);
         this._gbOptions.Controls.Add(this._lblMinHeight);
         this._gbOptions.Controls.Add(this._lblMinWidth);
         this._gbOptions.Controls.Add(this._lblUnits);
         this._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbOptions, "_gbOptions");
         this._gbOptions.Name = "_gbOptions";
         this._gbOptions.TabStop = false;
         // 
         // _numMaxHeight
         // 
         resources.ApplyResources(this._numMaxHeight, "_numMaxHeight");
         this._numMaxHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
         this._numMaxHeight.Name = "_numMaxHeight";
         this._numMaxHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numMaxHeight.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _numMaxWidth
         // 
         resources.ApplyResources(this._numMaxWidth, "_numMaxWidth");
         this._numMaxWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
         this._numMaxWidth.Name = "_numMaxWidth";
         this._numMaxWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numMaxWidth.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _numMinHeight
         // 
         resources.ApplyResources(this._numMinHeight, "_numMinHeight");
         this._numMinHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
         this._numMinHeight.Name = "_numMinHeight";
         this._numMinHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numMinHeight.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _numMinWidth
         // 
         resources.ApplyResources(this._numMinWidth, "_numMinWidth");
         this._numMinWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
         this._numMinWidth.Name = "_numMinWidth";
         this._numMinWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numMinWidth.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _lblUnitsMaxHeight
         // 
         this._lblUnitsMaxHeight.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblUnitsMaxHeight, "_lblUnitsMaxHeight");
         this._lblUnitsMaxHeight.Name = "_lblUnitsMaxHeight";
         // 
         // _lblUnitsMaxWidth
         // 
         this._lblUnitsMaxWidth.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblUnitsMaxWidth, "_lblUnitsMaxWidth");
         this._lblUnitsMaxWidth.Name = "_lblUnitsMaxWidth";
         // 
         // _lblMaxHeight
         // 
         this._lblMaxHeight.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblMaxHeight, "_lblMaxHeight");
         this._lblMaxHeight.Name = "_lblMaxHeight";
         // 
         // _lblUnitsMinHeight
         // 
         this._lblUnitsMinHeight.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblUnitsMinHeight, "_lblUnitsMinHeight");
         this._lblUnitsMinHeight.Name = "_lblUnitsMinHeight";
         // 
         // _lblMaxWidth
         // 
         this._lblMaxWidth.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblMaxWidth, "_lblMaxWidth");
         this._lblMaxWidth.Name = "_lblMaxWidth";
         // 
         // _lblUnitsMinWidth
         // 
         this._lblUnitsMinWidth.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblUnitsMinWidth, "_lblUnitsMinWidth");
         this._lblUnitsMinWidth.Name = "_lblUnitsMinWidth";
         // 
         // _lblMinHeight
         // 
         this._lblMinHeight.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblMinHeight, "_lblMinHeight");
         this._lblMinHeight.Name = "_lblMinHeight";
         // 
         // _lblMinWidth
         // 
         this._lblMinWidth.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblMinWidth, "_lblMinWidth");
         this._lblMinWidth.Name = "_lblMinWidth";
         // 
         // _lblUnits
         // 
         this._lblUnits.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblUnits, "_lblUnits");
         this._lblUnits.Name = "_lblUnits";
         // 
         // DotRemoveDialog
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
         this.Name = "DotRemoveDialog";
         this.ShowInTaskbar = false;
         this.Load += new System.EventHandler(this.DotRemoveDialog_Load);
         this._gbFlags.ResumeLayout(false);
         this._gbOptions.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this._numMaxHeight)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numMaxWidth)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numMinHeight)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numMinWidth)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.GroupBox _gbFlags;
      private System.Windows.Forms.GroupBox _gbOptions;
      private System.Windows.Forms.CheckBox _cbUseDiagonals;
      private System.Windows.Forms.CheckBox _cbUseSize;
      private System.Windows.Forms.CheckBox _cbUseDpi;
      private System.Windows.Forms.CheckBox _cbImageUnchanged;
      private System.Windows.Forms.Label _lblUnits;
      private System.Windows.Forms.Label _lblUnitsMaxHeight;
      private System.Windows.Forms.Label _lblUnitsMaxWidth;
      private System.Windows.Forms.Label _lblMaxHeight;
      private System.Windows.Forms.Label _lblUnitsMinHeight;
      private System.Windows.Forms.Label _lblMaxWidth;
      private System.Windows.Forms.Label _lblUnitsMinWidth;
      private System.Windows.Forms.Label _lblMinHeight;
      private System.Windows.Forms.Label _lblMinWidth;
      private System.Windows.Forms.NumericUpDown _numMaxHeight;
      private System.Windows.Forms.NumericUpDown _numMaxWidth;
      private System.Windows.Forms.NumericUpDown _numMinHeight;
      private System.Windows.Forms.NumericUpDown _numMinWidth;
   }
}