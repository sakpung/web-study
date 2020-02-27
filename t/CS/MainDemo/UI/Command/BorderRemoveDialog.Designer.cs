namespace MainDemo
{
   partial class BorderRemoveDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BorderRemoveDialog));
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._gbFlags = new System.Windows.Forms.GroupBox();
         this._cbUseVariance = new System.Windows.Forms.CheckBox();
         this._cbImageUnchanged = new System.Windows.Forms.CheckBox();
         this._gbBorder = new System.Windows.Forms.GroupBox();
         this._cbBottom = new System.Windows.Forms.CheckBox();
         this._cbRight = new System.Windows.Forms.CheckBox();
         this._cbTop = new System.Windows.Forms.CheckBox();
         this._cbLeft = new System.Windows.Forms.CheckBox();
         this._gbOptions = new System.Windows.Forms.GroupBox();
         this._numWhiteNoiseLength = new System.Windows.Forms.NumericUpDown();
         this._numVariance = new System.Windows.Forms.NumericUpDown();
         this._numPercent = new System.Windows.Forms.NumericUpDown();
         this._lblWhiteNoiseLength = new System.Windows.Forms.Label();
         this._lblVariance = new System.Windows.Forms.Label();
         this._lblPercent = new System.Windows.Forms.Label();
         this._cbAutoRemove = new System.Windows.Forms.CheckBox();
         this._gbFlags.SuspendLayout();
         this._gbBorder.SuspendLayout();
         this._gbOptions.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numWhiteNoiseLength)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numVariance)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numPercent)).BeginInit();
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
         this._gbFlags.Controls.Add(this._cbAutoRemove);
         this._gbFlags.Controls.Add(this._cbUseVariance);
         this._gbFlags.Controls.Add(this._cbImageUnchanged);
         this._gbFlags.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbFlags, "_gbFlags");
         this._gbFlags.Name = "_gbFlags";
         this._gbFlags.TabStop = false;
         // 
         // _cbUseVariance
         // 
         resources.ApplyResources(this._cbAutoRemove, "_cbAutoRemove");
         this._cbAutoRemove.Name = "_cbAutoRemove";
         this._cbAutoRemove.UseVisualStyleBackColor = true;
         this._cbAutoRemove.CheckedChanged += new System.EventHandler(this._cbAutoRemove_CheckedChanged);
         // 
         // _cbUseVariance
         // 
         resources.ApplyResources(this._cbUseVariance, "_cbUseVariance");
         this._cbUseVariance.Name = "_cbUseVariance";
         this._cbUseVariance.UseVisualStyleBackColor = true;
         this._cbUseVariance.CheckedChanged += new System.EventHandler(this._cbUseVariance_CheckedChanged);
         // 
         // _cbImageUnchanged
         // 
         resources.ApplyResources(this._cbImageUnchanged, "_cbImageUnchanged");
         this._cbImageUnchanged.Name = "_cbImageUnchanged";
         this._cbImageUnchanged.UseVisualStyleBackColor = true;
         // 
         // _gbBorder
         // 
         this._gbBorder.Controls.Add(this._cbBottom);
         this._gbBorder.Controls.Add(this._cbRight);
         this._gbBorder.Controls.Add(this._cbTop);
         this._gbBorder.Controls.Add(this._cbLeft);
         this._gbBorder.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbBorder, "_gbBorder");
         this._gbBorder.Name = "_gbBorder";
         this._gbBorder.TabStop = false;
         // 
         // _cbBottom
         // 
         resources.ApplyResources(this._cbBottom, "_cbBottom");
         this._cbBottom.Name = "_cbBottom";
         this._cbBottom.UseVisualStyleBackColor = true;
         // 
         // _cbRight
         // 
         resources.ApplyResources(this._cbRight, "_cbRight");
         this._cbRight.Name = "_cbRight";
         this._cbRight.UseVisualStyleBackColor = true;
         // 
         // _cbTop
         // 
         resources.ApplyResources(this._cbTop, "_cbTop");
         this._cbTop.Name = "_cbTop";
         this._cbTop.UseVisualStyleBackColor = true;
         // 
         // _cbLeft
         // 
         resources.ApplyResources(this._cbLeft, "_cbLeft");
         this._cbLeft.Name = "_cbLeft";
         this._cbLeft.UseVisualStyleBackColor = true;
         // 
         // _gbOptions
         // 
         this._gbOptions.Controls.Add(this._numWhiteNoiseLength);
         this._gbOptions.Controls.Add(this._numVariance);
         this._gbOptions.Controls.Add(this._numPercent);
         this._gbOptions.Controls.Add(this._lblWhiteNoiseLength);
         this._gbOptions.Controls.Add(this._lblVariance);
         this._gbOptions.Controls.Add(this._lblPercent);
         this._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbOptions, "_gbOptions");
         this._gbOptions.Name = "_gbOptions";
         this._gbOptions.TabStop = false;
         // 
         // _numWhiteNoiseLength
         // 
         resources.ApplyResources(this._numWhiteNoiseLength, "_numWhiteNoiseLength");
         this._numWhiteNoiseLength.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
         this._numWhiteNoiseLength.Name = "_numWhiteNoiseLength";
         this._numWhiteNoiseLength.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _numVariance
         // 
         resources.ApplyResources(this._numVariance, "_numVariance");
         this._numVariance.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
         this._numVariance.Name = "_numVariance";
         this._numVariance.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _numPercent
         // 
         resources.ApplyResources(this._numPercent, "_numPercent");
         this._numPercent.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numPercent.Name = "_numPercent";
         this._numPercent.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numPercent.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _lblWhiteNoiseLength
         // 
         this._lblWhiteNoiseLength.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblWhiteNoiseLength, "_lblWhiteNoiseLength");
         this._lblWhiteNoiseLength.Name = "_lblWhiteNoiseLength";
         // 
         // _lblVariance
         // 
         this._lblVariance.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblVariance, "_lblVariance");
         this._lblVariance.Name = "_lblVariance";
         // 
         // _lblPercent
         // 
         this._lblPercent.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblPercent, "_lblPercent");
         this._lblPercent.Name = "_lblPercent";
         // 
         // _cbAutoRemove
         // 
         resources.ApplyResources(this._cbAutoRemove, "_cbAutoRemove");
         this._cbAutoRemove.Name = "_cbAutoRemove";
         this._cbAutoRemove.UseVisualStyleBackColor = true;
         // 
         // BorderRemoveDialog
         // 
         this.AcceptButton = this._btnOk;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.Controls.Add(this._gbOptions);
         this.Controls.Add(this._gbBorder);
         this.Controls.Add(this._gbFlags);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "BorderRemoveDialog";
         this.ShowInTaskbar = false;
         this.Load += new System.EventHandler(this.BorderRemoveDialog_Load);
         this._gbFlags.ResumeLayout(false);
         this._gbFlags.PerformLayout();
         this._gbBorder.ResumeLayout(false);
         this._gbOptions.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this._numWhiteNoiseLength)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numVariance)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numPercent)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.GroupBox _gbFlags;
      private System.Windows.Forms.GroupBox _gbBorder;
      private System.Windows.Forms.GroupBox _gbOptions;
      private System.Windows.Forms.CheckBox _cbUseVariance;
      private System.Windows.Forms.CheckBox _cbImageUnchanged;
      private System.Windows.Forms.CheckBox _cbBottom;
      private System.Windows.Forms.CheckBox _cbRight;
      private System.Windows.Forms.CheckBox _cbTop;
      private System.Windows.Forms.CheckBox _cbLeft;
      private System.Windows.Forms.Label _lblPercent;
      private System.Windows.Forms.NumericUpDown _numWhiteNoiseLength;
      private System.Windows.Forms.NumericUpDown _numVariance;
      private System.Windows.Forms.NumericUpDown _numPercent;
      private System.Windows.Forms.Label _lblWhiteNoiseLength;
      private System.Windows.Forms.Label _lblVariance;
      private System.Windows.Forms.CheckBox _cbAutoRemove;
   }
}