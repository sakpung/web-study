namespace ImageProcessingDemo
{
   partial class LocalHistogramEqualizeDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocalHistogramEqualizeDialog));
         this._lblColorSpace = new System.Windows.Forms.Label();
         this._cmbColorSpace = new System.Windows.Forms.ComboBox();
         this._gbParameter = new System.Windows.Forms.GroupBox();
         this._numSmooth = new System.Windows.Forms.NumericUpDown();
         this._lblSmooth = new System.Windows.Forms.Label();
         this._tbSmooth = new System.Windows.Forms.TrackBar();
         this._numHeightExtension = new System.Windows.Forms.NumericUpDown();
         this._lblHeightExtension = new System.Windows.Forms.Label();
         this._tbHeightExtension = new System.Windows.Forms.TrackBar();
         this._numWidthExtension = new System.Windows.Forms.NumericUpDown();
         this._lblWidthExtension = new System.Windows.Forms.Label();
         this._tbWidthExtension = new System.Windows.Forms.TrackBar();
         this._numHeight = new System.Windows.Forms.NumericUpDown();
         this._lblHeight = new System.Windows.Forms.Label();
         this._tbHeight = new System.Windows.Forms.TrackBar();
         this._numWidth = new System.Windows.Forms.NumericUpDown();
         this._lblWidth = new System.Windows.Forms.Label();
         this._tbWidth = new System.Windows.Forms.TrackBar();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._gbParameter.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numSmooth)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._tbSmooth)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numHeightExtension)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._tbHeightExtension)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numWidthExtension)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._tbWidthExtension)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numHeight)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._tbHeight)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numWidth)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._tbWidth)).BeginInit();
         this.SuspendLayout();
         // 
         // _lblColorSpace
         // 
         resources.ApplyResources(this._lblColorSpace, "_lblColorSpace");
         this._lblColorSpace.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblColorSpace.Name = "_lblColorSpace";
         // 
         // _cmbColorSpace
         // 
         this._cmbColorSpace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         resources.ApplyResources(this._cmbColorSpace, "_cmbColorSpace");
         this._cmbColorSpace.FormattingEnabled = true;
         this._cmbColorSpace.Name = "_cmbColorSpace";
         // 
         // _gbParameter
         // 
         this._gbParameter.Controls.Add(this._numSmooth);
         this._gbParameter.Controls.Add(this._lblSmooth);
         this._gbParameter.Controls.Add(this._tbSmooth);
         this._gbParameter.Controls.Add(this._numHeightExtension);
         this._gbParameter.Controls.Add(this._lblHeightExtension);
         this._gbParameter.Controls.Add(this._tbHeightExtension);
         this._gbParameter.Controls.Add(this._numWidthExtension);
         this._gbParameter.Controls.Add(this._lblWidthExtension);
         this._gbParameter.Controls.Add(this._tbWidthExtension);
         this._gbParameter.Controls.Add(this._numHeight);
         this._gbParameter.Controls.Add(this._lblHeight);
         this._gbParameter.Controls.Add(this._tbHeight);
         this._gbParameter.Controls.Add(this._numWidth);
         this._gbParameter.Controls.Add(this._lblWidth);
         this._gbParameter.Controls.Add(this._tbWidth);
         this._gbParameter.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbParameter, "_gbParameter");
         this._gbParameter.Name = "_gbParameter";
         this._gbParameter.TabStop = false;
         // 
         // _numSmooth
         // 
         resources.ApplyResources(this._numSmooth, "_numSmooth");
         this._numSmooth.Name = "_numSmooth";
         this._numSmooth.ValueChanged += new System.EventHandler(this._numSmooth_ValueChanged);
         this._numSmooth.Leave += new System.EventHandler(this._numSmooth_Leave);
         // 
         // _lblSmooth
         // 
         resources.ApplyResources(this._lblSmooth, "_lblSmooth");
         this._lblSmooth.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblSmooth.Name = "_lblSmooth";
         // 
         // _tbSmooth
         // 
         resources.ApplyResources(this._tbSmooth, "_tbSmooth");
         this._tbSmooth.Maximum = 7;
         this._tbSmooth.Name = "_tbSmooth";
         this._tbSmooth.TickStyle = System.Windows.Forms.TickStyle.None;
         this._tbSmooth.Scroll += new System.EventHandler(this._tbSmooth_Scroll);
         // 
         // _numHeightExtension
         // 
         resources.ApplyResources(this._numHeightExtension, "_numHeightExtension");
         this._numHeightExtension.Name = "_numHeightExtension";
         this._numHeightExtension.ValueChanged += new System.EventHandler(this._numHeightExtension_ValueChanged);
         this._numHeightExtension.Leave += new System.EventHandler(this._numHeightExtension_Leave);
         // 
         // _lblHeightExtension
         // 
         resources.ApplyResources(this._lblHeightExtension, "_lblHeightExtension");
         this._lblHeightExtension.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblHeightExtension.Name = "_lblHeightExtension";
         // 
         // _tbHeightExtension
         // 
         resources.ApplyResources(this._tbHeightExtension, "_tbHeightExtension");
         this._tbHeightExtension.Name = "_tbHeightExtension";
         this._tbHeightExtension.TickStyle = System.Windows.Forms.TickStyle.None;
         this._tbHeightExtension.Scroll += new System.EventHandler(this._tbHeightExtension_Scroll);
         // 
         // _numWidthExtension
         // 
         resources.ApplyResources(this._numWidthExtension, "_numWidthExtension");
         this._numWidthExtension.Name = "_numWidthExtension";
         this._numWidthExtension.ValueChanged += new System.EventHandler(this._numWidthExtension_ValueChanged);
         this._numWidthExtension.Leave += new System.EventHandler(this._numWidthExtension_Leave);
         // 
         // _lblWidthExtension
         // 
         resources.ApplyResources(this._lblWidthExtension, "_lblWidthExtension");
         this._lblWidthExtension.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblWidthExtension.Name = "_lblWidthExtension";
         // 
         // _tbWidthExtension
         // 
         resources.ApplyResources(this._tbWidthExtension, "_tbWidthExtension");
         this._tbWidthExtension.Name = "_tbWidthExtension";
         this._tbWidthExtension.TickStyle = System.Windows.Forms.TickStyle.None;
         this._tbWidthExtension.Scroll += new System.EventHandler(this._tbWidthExtension_Scroll);
         // 
         // _numHeight
         // 
         resources.ApplyResources(this._numHeight, "_numHeight");
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
         this._numHeight.ValueChanged += new System.EventHandler(this._numHeight_ValueChanged);
         this._numHeight.Leave += new System.EventHandler(this._numHeight_Leave);
         // 
         // _lblHeight
         // 
         resources.ApplyResources(this._lblHeight, "_lblHeight");
         this._lblHeight.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblHeight.Name = "_lblHeight";
         // 
         // _tbHeight
         // 
         resources.ApplyResources(this._tbHeight, "_tbHeight");
         this._tbHeight.Minimum = 1;
         this._tbHeight.Name = "_tbHeight";
         this._tbHeight.TickStyle = System.Windows.Forms.TickStyle.None;
         this._tbHeight.Value = 1;
         this._tbHeight.Scroll += new System.EventHandler(this._tbHeight_Scroll);
         // 
         // _numWidth
         // 
         resources.ApplyResources(this._numWidth, "_numWidth");
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
         this._numWidth.ValueChanged += new System.EventHandler(this._numWidth_ValueChanged);
         this._numWidth.Leave += new System.EventHandler(this._numWidth_Leave);
         // 
         // _lblWidth
         // 
         resources.ApplyResources(this._lblWidth, "_lblWidth");
         this._lblWidth.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblWidth.Name = "_lblWidth";
         // 
         // _tbWidth
         // 
         resources.ApplyResources(this._tbWidth, "_tbWidth");
         this._tbWidth.Minimum = 1;
         this._tbWidth.Name = "_tbWidth";
         this._tbWidth.TickStyle = System.Windows.Forms.TickStyle.None;
         this._tbWidth.Value = 1;
         this._tbWidth.Scroll += new System.EventHandler(this._tbWidth_Scroll);
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
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         resources.ApplyResources(this._btnOk, "_btnOk");
         this._btnOk.Name = "_btnOk";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // LocalHistogramEqualizeDialog
         // 
         this.AcceptButton = this._btnOk;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._gbParameter);
         this.Controls.Add(this._cmbColorSpace);
         this.Controls.Add(this._lblColorSpace);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "LocalHistogramEqualizeDialog";
         this.ShowIcon = false;
         this._gbParameter.ResumeLayout(false);
         this._gbParameter.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numSmooth)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._tbSmooth)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numHeightExtension)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._tbHeightExtension)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numWidthExtension)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._tbWidthExtension)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numHeight)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._tbHeight)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numWidth)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._tbWidth)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label _lblColorSpace;
      private System.Windows.Forms.ComboBox _cmbColorSpace;
      private System.Windows.Forms.GroupBox _gbParameter;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.NumericUpDown _numWidth;
      private System.Windows.Forms.Label _lblWidth;
      public System.Windows.Forms.TrackBar _tbWidth;
      private System.Windows.Forms.NumericUpDown _numHeight;
      private System.Windows.Forms.Label _lblHeight;
      public System.Windows.Forms.TrackBar _tbHeight;
      private System.Windows.Forms.NumericUpDown _numSmooth;
      private System.Windows.Forms.Label _lblSmooth;
      public System.Windows.Forms.TrackBar _tbSmooth;
      private System.Windows.Forms.NumericUpDown _numHeightExtension;
      private System.Windows.Forms.Label _lblHeightExtension;
      public System.Windows.Forms.TrackBar _tbHeightExtension;
      private System.Windows.Forms.NumericUpDown _numWidthExtension;
      private System.Windows.Forms.Label _lblWidthExtension;
      public System.Windows.Forms.TrackBar _tbWidthExtension;
   }
}