namespace GrayScaleDemo
{
    partial class BackgroundRemovalDialog
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
            this._gbOptions = new System.Windows.Forms.GroupBox();
            this._cbEnableEnhancements = new System.Windows.Forms.CheckBox();
            this._txtRemovalFactor = new System.Windows.Forms.TextBox();
            this._numRemovalFactor = new System.Windows.Forms.TrackBar();
            this._numContrast = new System.Windows.Forms.NumericUpDown();
            this._lblAmount = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this._cbInvert = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this._lblLevels = new System.Windows.Forms.Label();
            this._lblCoefficients = new System.Windows.Forms.Label();
            this._numEdgeLevel = new System.Windows.Forms.NumericUpDown();
            this._numEdgeCoef = new System.Windows.Forms.NumericUpDown();
            this._btnCancel = new System.Windows.Forms.Button();
            this._btnOk = new System.Windows.Forms.Button();
            this._btnApply = new System.Windows.Forms.Button();
            this._gbOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numRemovalFactor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numContrast)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numEdgeLevel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._numEdgeCoef)).BeginInit();
            this.SuspendLayout();
            // 
            // _gbOptions
            // 
            this._gbOptions.Controls.Add(this._cbEnableEnhancements);
            this._gbOptions.Controls.Add(this._txtRemovalFactor);
            this._gbOptions.Controls.Add(this._numRemovalFactor);
            this._gbOptions.Controls.Add(this._numContrast);
            this._gbOptions.Controls.Add(this._lblAmount);
            this._gbOptions.Controls.Add(this.label1);
            this._gbOptions.Controls.Add(this._cbInvert);
            this._gbOptions.Controls.Add(this.groupBox1);
            this._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._gbOptions.Location = new System.Drawing.Point(9, 4);
            this._gbOptions.Margin = new System.Windows.Forms.Padding(2);
            this._gbOptions.Name = "_gbOptions";
            this._gbOptions.Padding = new System.Windows.Forms.Padding(2);
            this._gbOptions.Size = new System.Drawing.Size(285, 279);
            this._gbOptions.TabIndex = 0;
            this._gbOptions.TabStop = false;
            this._gbOptions.Text = "Parameters";
            // 
            // _cbEnableEnhancements
            // 
            this._cbEnableEnhancements.AutoSize = true;
            this._cbEnableEnhancements.Checked = true;
            this._cbEnableEnhancements.CheckState = System.Windows.Forms.CheckState.Checked;
            this._cbEnableEnhancements.Location = new System.Drawing.Point(25, 112);
            this._cbEnableEnhancements.Name = "_cbEnableEnhancements";
            this._cbEnableEnhancements.Size = new System.Drawing.Size(133, 17);
            this._cbEnableEnhancements.TabIndex = 9;
            this._cbEnableEnhancements.Text = "Enable Enhancements";
            this._cbEnableEnhancements.UseVisualStyleBackColor = true;
            this._cbEnableEnhancements.CheckedChanged += new System.EventHandler(this._cbEnableEnhancements_CheckedChanged);
            // 
            // _txtRemovalFactor
            // 
            this._txtRemovalFactor.Location = new System.Drawing.Point(227, 72);
            this._txtRemovalFactor.MaxLength = 4;
            this._txtRemovalFactor.Name = "_txtRemovalFactor";
            this._txtRemovalFactor.ReadOnly = true;
            this._txtRemovalFactor.Size = new System.Drawing.Size(43, 20);
            this._txtRemovalFactor.TabIndex = 14;
            this._txtRemovalFactor.Text = "800";
            // 
            // _numRemovalFactor
            // 
            this._numRemovalFactor.Location = new System.Drawing.Point(12, 72);
            this._numRemovalFactor.Maximum = 1000;
            this._numRemovalFactor.Name = "_numRemovalFactor";
            this._numRemovalFactor.Size = new System.Drawing.Size(209, 45);
            this._numRemovalFactor.TabIndex = 13;
            this._numRemovalFactor.Value = 800;
            this._numRemovalFactor.Scroll += new System.EventHandler(this._numRemovalFactor_Scroll);
            // 
            // _numContrast
            // 
            this._numContrast.DecimalPlaces = 2;
            this._numContrast.Increment = new decimal(new int[] {
            50,
            0,
            0,
            131072});
            this._numContrast.Location = new System.Drawing.Point(161, 141);
            this._numContrast.Margin = new System.Windows.Forms.Padding(2);
            this._numContrast.Name = "_numContrast";
            this._numContrast.Size = new System.Drawing.Size(109, 20);
            this._numContrast.TabIndex = 1;
            this._numContrast.Value = new decimal(new int[] {
            60,
            0,
            0,
            65536});
            this._numContrast.Leave += new System.EventHandler(this._num_Leave);
            // 
            // _lblAmount
            // 
            this._lblAmount.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._lblAmount.Location = new System.Drawing.Point(27, 143);
            this._lblAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this._lblAmount.Name = "_lblAmount";
            this._lblAmount.Size = new System.Drawing.Size(65, 22);
            this._lblAmount.TabIndex = 0;
            this._lblAmount.Text = "Contrast";
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Location = new System.Drawing.Point(27, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 22);
            this.label1.TabIndex = 9;
            this.label1.Text = "Removal Factor";
            // 
            // _cbInvert
            // 
            this._cbInvert.AutoSize = true;
            this._cbInvert.Location = new System.Drawing.Point(28, 19);
            this._cbInvert.Name = "_cbInvert";
            this._cbInvert.Size = new System.Drawing.Size(53, 17);
            this._cbInvert.TabIndex = 4;
            this._cbInvert.Text = "Invert";
            this._cbInvert.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this._lblLevels);
            this.groupBox1.Controls.Add(this._lblCoefficients);
            this.groupBox1.Controls.Add(this._numEdgeLevel);
            this.groupBox1.Controls.Add(this._numEdgeCoef);
            this.groupBox1.Location = new System.Drawing.Point(11, 179);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(259, 83);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Edge Enhancment";
            // 
            // _lblLevels
            // 
            this._lblLevels.AutoSize = true;
            this._lblLevels.Location = new System.Drawing.Point(16, 21);
            this._lblLevels.Name = "_lblLevels";
            this._lblLevels.Size = new System.Drawing.Size(66, 13);
            this._lblLevels.TabIndex = 11;
            this._lblLevels.Text = "Edge Levels";
            // 
            // _lblCoefficients
            // 
            this._lblCoefficients.AutoSize = true;
            this._lblCoefficients.Location = new System.Drawing.Point(16, 51);
            this._lblCoefficients.Name = "_lblCoefficients";
            this._lblCoefficients.Size = new System.Drawing.Size(90, 13);
            this._lblCoefficients.TabIndex = 10;
            this._lblCoefficients.Text = "Edge Coefficients";
            // 
            // _numEdgeLevel
            // 
            this._numEdgeLevel.Location = new System.Drawing.Point(143, 16);
            this._numEdgeLevel.Margin = new System.Windows.Forms.Padding(2);
            this._numEdgeLevel.Maximum = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this._numEdgeLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this._numEdgeLevel.Name = "_numEdgeLevel";
            this._numEdgeLevel.Size = new System.Drawing.Size(109, 20);
            this._numEdgeLevel.TabIndex = 3;
            this._numEdgeLevel.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
            this._numEdgeLevel.Leave += new System.EventHandler(this._num_Leave);
            // 
            // _numEdgeCoef
            // 
            this._numEdgeCoef.DecimalPlaces = 2;
            this._numEdgeCoef.Increment = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this._numEdgeCoef.Location = new System.Drawing.Point(143, 49);
            this._numEdgeCoef.Margin = new System.Windows.Forms.Padding(2);
            this._numEdgeCoef.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this._numEdgeCoef.Name = "_numEdgeCoef";
            this._numEdgeCoef.Size = new System.Drawing.Size(109, 20);
            this._numEdgeCoef.TabIndex = 5;
            this._numEdgeCoef.Value = new decimal(new int[] {
            17,
            0,
            0,
            65536});
            // 
            // _btnCancel
            // 
            this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._btnCancel.Location = new System.Drawing.Point(211, 300);
            this._btnCancel.Margin = new System.Windows.Forms.Padding(2);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(68, 22);
            this._btnCancel.TabIndex = 2;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
            // 
            // _btnOk
            // 
            this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this._btnOk.Location = new System.Drawing.Point(122, 300);
            this._btnOk.Margin = new System.Windows.Forms.Padding(2);
            this._btnOk.Name = "_btnOk";
            this._btnOk.Size = new System.Drawing.Size(68, 22);
            this._btnOk.TabIndex = 1;
            this._btnOk.Text = "OK";
            this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
            // 
            // _btnApply
            // 
            this._btnApply.Location = new System.Drawing.Point(26, 300);
            this._btnApply.Name = "_btnApply";
            this._btnApply.Size = new System.Drawing.Size(75, 23);
            this._btnApply.TabIndex = 8;
            this._btnApply.Text = "Apply";
            this._btnApply.UseVisualStyleBackColor = true;
            this._btnApply.Click += new System.EventHandler(this._btnApply_Click);
            // 
            // BackgroundRemovalDialog
            // 
            this.AcceptButton = this._btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this._btnCancel;
            this.ClientSize = new System.Drawing.Size(315, 339);
            this.Controls.Add(this._btnApply);
            this.Controls.Add(this._gbOptions);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnOk);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BackgroundRemovalDialog";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Background Removal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BackgroundRemovalDialog_FormClosing);
            this._gbOptions.ResumeLayout(false);
            this._gbOptions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numRemovalFactor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numContrast)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this._numEdgeLevel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._numEdgeCoef)).EndInit();
            this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gbOptions;
      private System.Windows.Forms.NumericUpDown _numEdgeLevel;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.NumericUpDown _numEdgeCoef;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.Button _btnApply;
      private System.Windows.Forms.Label _lblLevels;
      private System.Windows.Forms.Label _lblCoefficients;
      private System.Windows.Forms.NumericUpDown _numContrast;
      private System.Windows.Forms.Label _lblAmount;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.CheckBox _cbInvert;
      private System.Windows.Forms.TrackBar _numRemovalFactor;
      private System.Windows.Forms.TextBox _txtRemovalFactor;
      private System.Windows.Forms.CheckBox _cbEnableEnhancements;
   }
}