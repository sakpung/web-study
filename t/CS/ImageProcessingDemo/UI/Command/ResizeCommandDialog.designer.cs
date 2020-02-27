namespace ImageProcessingDemo
{
   partial class ResizeCommandDialog
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResizeCommandDialog));
          this._lblWidth = new System.Windows.Forms.Label();
          this._lblHeight = new System.Windows.Forms.Label();
          this._gbOptions = new System.Windows.Forms.GroupBox();
          this._cmbResizeType = new System.Windows.Forms.ComboBox();
          this._lblInterpolation = new System.Windows.Forms.Label();
          this._gbOptionsFlags = new System.Windows.Forms.GroupBox();
          this._numHeight = new System.Windows.Forms.NumericUpDown();
          this._numWidth = new System.Windows.Forms.NumericUpDown();
          this._btnCancel = new System.Windows.Forms.Button();
          this._btnOk = new System.Windows.Forms.Button();
          this._gbOptions.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this._numHeight)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._numWidth)).BeginInit();
          this.SuspendLayout();
          // 
          // _lblWidth
          // 
          resources.ApplyResources(this._lblWidth, "_lblWidth");
          this._lblWidth.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblWidth.Name = "_lblWidth";
          // 
          // _lblHeight
          // 
          resources.ApplyResources(this._lblHeight, "_lblHeight");
          this._lblHeight.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblHeight.Name = "_lblHeight";
          // 
          // _gbOptions
          // 
          this._gbOptions.Controls.Add(this._cmbResizeType);
          this._gbOptions.Controls.Add(this._lblInterpolation);
          this._gbOptions.Controls.Add(this._gbOptionsFlags);
          this._gbOptions.Controls.Add(this._numHeight);
          this._gbOptions.Controls.Add(this._numWidth);
          this._gbOptions.Controls.Add(this._lblHeight);
          this._gbOptions.Controls.Add(this._lblWidth);
          resources.ApplyResources(this._gbOptions, "_gbOptions");
          this._gbOptions.Name = "_gbOptions";
          this._gbOptions.TabStop = false;
          // 
          // _cmbResizeType
          // 
          this._cmbResizeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          resources.ApplyResources(this._cmbResizeType, "_cmbResizeType");
          this._cmbResizeType.FormattingEnabled = true;
          this._cmbResizeType.Name = "_cmbResizeType";
          this._cmbResizeType.SelectedIndexChanged += new System.EventHandler(this._cmbResizeType_SelectedIndexChanged);
          // 
          // _lblInterpolation
          // 
          this._lblInterpolation.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._lblInterpolation, "_lblInterpolation");
          this._lblInterpolation.Name = "_lblInterpolation";
          // 
          // _gbOptionsFlags
          // 
          this._gbOptionsFlags.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gbOptionsFlags, "_gbOptionsFlags");
          this._gbOptionsFlags.Name = "_gbOptionsFlags";
          this._gbOptionsFlags.TabStop = false;
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
          // ResizeCommandDialog
          // 
          this.AcceptButton = this._btnOk;
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._btnCancel;
          this.Controls.Add(this._btnCancel);
          this.Controls.Add(this._btnOk);
          this.Controls.Add(this._gbOptions);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "ResizeCommandDialog";
          this.ShowIcon = false;
          this._gbOptions.ResumeLayout(false);
          this._gbOptions.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this._numHeight)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._numWidth)).EndInit();
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Label _lblWidth;
      private System.Windows.Forms.Label _lblHeight;
      private System.Windows.Forms.GroupBox _gbOptions;
      private System.Windows.Forms.NumericUpDown _numHeight;
      private System.Windows.Forms.NumericUpDown _numWidth;
      private System.Windows.Forms.GroupBox _gbOptionsFlags;
      private System.Windows.Forms.ComboBox _cmbResizeType;
      private System.Windows.Forms.Label _lblInterpolation;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
   }
}