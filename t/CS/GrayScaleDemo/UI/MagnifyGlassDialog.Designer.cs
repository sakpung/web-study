namespace GrayScaleDemo
{
    partial class MagnifyGlassDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MagnifyGlassDialog));
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._gbOptions = new System.Windows.Forms.GroupBox();
         this._txtInterSectionColor = new System.Windows.Forms.TextBox();
         this._txtBorderColor = new System.Windows.Forms.TextBox();
         this._btnIntersectionColor = new System.Windows.Forms.Button();
         this.label2 = new System.Windows.Forms.Label();
         this._btnBorderColor = new System.Windows.Forms.Button();
         this.label1 = new System.Windows.Forms.Label();
         this._lblScaleFactor = new System.Windows.Forms.Label();
         this._numScaleFactor = new System.Windows.Forms.NumericUpDown();
         this._lblBorderSize = new System.Windows.Forms.Label();
         this._numBorderSize = new System.Windows.Forms.NumericUpDown();
         this._cmbShape = new System.Windows.Forms.ComboBox();
         this._lblShape = new System.Windows.Forms.Label();
         this._lblHeight = new System.Windows.Forms.Label();
         this._lblWidth = new System.Windows.Forms.Label();
         this._numHeight = new System.Windows.Forms.NumericUpDown();
         this._numWidth = new System.Windows.Forms.NumericUpDown();
         this._gbOptions.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numScaleFactor)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numBorderSize)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numHeight)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numWidth)).BeginInit();
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
         // _gbOptions
         // 
         this._gbOptions.Controls.Add(this._txtInterSectionColor);
         this._gbOptions.Controls.Add(this._txtBorderColor);
         this._gbOptions.Controls.Add(this._btnIntersectionColor);
         this._gbOptions.Controls.Add(this.label2);
         this._gbOptions.Controls.Add(this._btnBorderColor);
         this._gbOptions.Controls.Add(this.label1);
         this._gbOptions.Controls.Add(this._lblScaleFactor);
         this._gbOptions.Controls.Add(this._numScaleFactor);
         this._gbOptions.Controls.Add(this._lblBorderSize);
         this._gbOptions.Controls.Add(this._numBorderSize);
         this._gbOptions.Controls.Add(this._cmbShape);
         this._gbOptions.Controls.Add(this._lblShape);
         this._gbOptions.Controls.Add(this._lblHeight);
         this._gbOptions.Controls.Add(this._lblWidth);
         this._gbOptions.Controls.Add(this._numHeight);
         this._gbOptions.Controls.Add(this._numWidth);
         this._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbOptions, "_gbOptions");
         this._gbOptions.Name = "_gbOptions";
         this._gbOptions.TabStop = false;
         // 
         // _txtInterSectionColor
         // 
         resources.ApplyResources(this._txtInterSectionColor, "_txtInterSectionColor");
         this._txtInterSectionColor.Name = "_txtInterSectionColor";
         this._txtInterSectionColor.ReadOnly = true;
         // 
         // _txtBorderColor
         // 
         resources.ApplyResources(this._txtBorderColor, "_txtBorderColor");
         this._txtBorderColor.Name = "_txtBorderColor";
         this._txtBorderColor.ReadOnly = true;
         // 
         // _btnIntersectionColor
         // 
         resources.ApplyResources(this._btnIntersectionColor, "_btnIntersectionColor");
         this._btnIntersectionColor.Name = "_btnIntersectionColor";
         this._btnIntersectionColor.UseVisualStyleBackColor = true;
         this._btnIntersectionColor.Click += new System.EventHandler(this.Color_Click);
         // 
         // label2
         // 
         resources.ApplyResources(this.label2, "label2");
         this.label2.Name = "label2";
         // 
         // _btnBorderColor
         // 
         resources.ApplyResources(this._btnBorderColor, "_btnBorderColor");
         this._btnBorderColor.Name = "_btnBorderColor";
         this._btnBorderColor.UseVisualStyleBackColor = true;
         this._btnBorderColor.Click += new System.EventHandler(this.Color_Click);
         // 
         // label1
         // 
         resources.ApplyResources(this.label1, "label1");
         this.label1.Name = "label1";
         // 
         // _lblScaleFactor
         // 
         resources.ApplyResources(this._lblScaleFactor, "_lblScaleFactor");
         this._lblScaleFactor.Name = "_lblScaleFactor";
         // 
         // _numScaleFactor
         // 
         resources.ApplyResources(this._numScaleFactor, "_numScaleFactor");
         this._numScaleFactor.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
         this._numScaleFactor.Name = "_numScaleFactor";
         this._numScaleFactor.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
         // 
         // _lblBorderSize
         // 
         resources.ApplyResources(this._lblBorderSize, "_lblBorderSize");
         this._lblBorderSize.Name = "_lblBorderSize";
         // 
         // _numBorderSize
         // 
         resources.ApplyResources(this._numBorderSize, "_numBorderSize");
         this._numBorderSize.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numBorderSize.Name = "_numBorderSize";
         this._numBorderSize.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
         // 
         // _cmbShape
         // 
         this._cmbShape.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbShape.FormattingEnabled = true;
         this._cmbShape.Items.AddRange(new object[] {
            resources.GetString("_cmbShape.Items"),
            resources.GetString("_cmbShape.Items1"),
            resources.GetString("_cmbShape.Items2"),
            resources.GetString("_cmbShape.Items3")});
         resources.ApplyResources(this._cmbShape, "_cmbShape");
         this._cmbShape.Name = "_cmbShape";
         // 
         // _lblShape
         // 
         this._lblShape.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblShape, "_lblShape");
         this._lblShape.Name = "_lblShape";
         // 
         // _lblHeight
         // 
         resources.ApplyResources(this._lblHeight, "_lblHeight");
         this._lblHeight.Name = "_lblHeight";
         // 
         // _lblWidth
         // 
         resources.ApplyResources(this._lblWidth, "_lblWidth");
         this._lblWidth.Name = "_lblWidth";
         // 
         // _numHeight
         // 
         resources.ApplyResources(this._numHeight, "_numHeight");
         this._numHeight.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
         this._numHeight.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
         this._numHeight.Name = "_numHeight";
         this._numHeight.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
         // 
         // _numWidth
         // 
         resources.ApplyResources(this._numWidth, "_numWidth");
         this._numWidth.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
         this._numWidth.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
         this._numWidth.Name = "_numWidth";
         this._numWidth.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
         // 
         // MagnifyGlassDialog
         // 
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this._gbOptions);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "MagnifyGlassDialog";
         this.Load += new System.EventHandler(this.MagnifyGlassDialog_Load);
         this._gbOptions.ResumeLayout(false);
         this._gbOptions.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numScaleFactor)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numBorderSize)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numHeight)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numWidth)).EndInit();
         this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.Button _btnOk;
        private System.Windows.Forms.GroupBox _gbOptions;
        private System.Windows.Forms.ComboBox _cmbShape;
        private System.Windows.Forms.Label _lblShape;
        private System.Windows.Forms.Label _lblHeight;
        private System.Windows.Forms.Label _lblWidth;
        private System.Windows.Forms.NumericUpDown _numHeight;
        private System.Windows.Forms.NumericUpDown _numWidth;
        private System.Windows.Forms.Label _lblScaleFactor;
        private System.Windows.Forms.NumericUpDown _numScaleFactor;
        private System.Windows.Forms.Label _lblBorderSize;
        private System.Windows.Forms.NumericUpDown _numBorderSize;
        private System.Windows.Forms.Button _btnIntersectionColor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button _btnBorderColor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox _txtInterSectionColor;
        private System.Windows.Forms.TextBox _txtBorderColor;
    }
}