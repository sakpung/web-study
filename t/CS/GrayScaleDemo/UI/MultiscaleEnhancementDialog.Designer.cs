namespace GrayScaleDemo
{
    partial class MultiscaleEnhancementDialog
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
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this._cbLatCoef = new System.Windows.Forms.CheckBox();
         this._cbLatLevel = new System.Windows.Forms.CheckBox();
         this._cbLatitude = new System.Windows.Forms.CheckBox();
         this._numLatLevel = new System.Windows.Forms.NumericUpDown();
         this._numLatCoef = new System.Windows.Forms.NumericUpDown();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this._cbEdgeCoef = new System.Windows.Forms.CheckBox();
         this._cbEdgeLevel = new System.Windows.Forms.CheckBox();
         this._cbEdge = new System.Windows.Forms.CheckBox();
         this._numEdgeLevel = new System.Windows.Forms.NumericUpDown();
         this._numEdgeCoef = new System.Windows.Forms.NumericUpDown();
         this._numContrast = new System.Windows.Forms.NumericUpDown();
         this._lblAmount = new System.Windows.Forms.Label();
         this._cbFilter = new System.Windows.Forms.ComboBox();
         this._lblColorSpace = new System.Windows.Forms.Label();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._btnApply = new System.Windows.Forms.Button();
         this._gbOptions.SuspendLayout();
         this.groupBox2.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numLatLevel)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numLatCoef)).BeginInit();
         this.groupBox1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numEdgeLevel)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numEdgeCoef)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numContrast)).BeginInit();
         this.SuspendLayout();
         // 
         // _gbOptions
         // 
         this._gbOptions.Controls.Add(this.groupBox2);
         this._gbOptions.Controls.Add(this.groupBox1);
         this._gbOptions.Controls.Add(this._numContrast);
         this._gbOptions.Controls.Add(this._lblAmount);
         this._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._gbOptions.Location = new System.Drawing.Point(9, 4);
         this._gbOptions.Margin = new System.Windows.Forms.Padding(2);
         this._gbOptions.Name = "_gbOptions";
         this._gbOptions.Padding = new System.Windows.Forms.Padding(2);
         this._gbOptions.Size = new System.Drawing.Size(285, 277);
         this._gbOptions.TabIndex = 0;
         this._gbOptions.TabStop = false;
         this._gbOptions.Text = "Enhancement";
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this._cbLatCoef);
         this.groupBox2.Controls.Add(this._cbLatLevel);
         this.groupBox2.Controls.Add(this._cbLatitude);
         this.groupBox2.Controls.Add(this._numLatLevel);
         this.groupBox2.Controls.Add(this._numLatCoef);
         this.groupBox2.Location = new System.Drawing.Point(11, 162);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(259, 100);
         this.groupBox2.TabIndex = 6;
         this.groupBox2.TabStop = false;
         // 
         // _cbLatCoef
         // 
         this._cbLatCoef.AutoSize = true;
         this._cbLatCoef.Enabled = false;
         this._cbLatCoef.Location = new System.Drawing.Point(12, 64);
         this._cbLatCoef.Name = "_cbLatCoef";
         this._cbLatCoef.Size = new System.Drawing.Size(122, 17);
         this._cbLatCoef.TabIndex = 12;
         this._cbLatCoef.Text = "Latitude Coefficients";
         this._cbLatCoef.UseVisualStyleBackColor = true;
         this._cbLatCoef.CheckedChanged += new System.EventHandler(this._cbLatCoef_CheckedChanged);
         // 
         // _cbLatLevel
         // 
         this._cbLatLevel.AutoSize = true;
         this._cbLatLevel.Enabled = false;
         this._cbLatLevel.Location = new System.Drawing.Point(12, 33);
         this._cbLatLevel.Name = "_cbLatLevel";
         this._cbLatLevel.Size = new System.Drawing.Size(98, 17);
         this._cbLatLevel.TabIndex = 11;
         this._cbLatLevel.Text = "Latitude Levels";
         this._cbLatLevel.UseVisualStyleBackColor = true;
         this._cbLatLevel.CheckedChanged += new System.EventHandler(this._cbLatLevel_CheckedChanged);
         // 
         // _cbLatitude
         // 
         this._cbLatitude.AutoSize = true;
         this._cbLatitude.Location = new System.Drawing.Point(6, 0);
         this._cbLatitude.Name = "_cbLatitude";
         this._cbLatitude.Size = new System.Drawing.Size(116, 17);
         this._cbLatitude.TabIndex = 10;
         this._cbLatitude.Text = "Latitude Reduction";
         this._cbLatitude.UseVisualStyleBackColor = true;
         this._cbLatitude.CheckedChanged += new System.EventHandler(this.cbLatitude_CheckedChanged);
         // 
         // _numLatLevel
         // 
         this._numLatLevel.Enabled = false;
         this._numLatLevel.Location = new System.Drawing.Point(144, 30);
         this._numLatLevel.Margin = new System.Windows.Forms.Padding(2);
         this._numLatLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numLatLevel.Name = "_numLatLevel";
         this._numLatLevel.Size = new System.Drawing.Size(109, 20);
         this._numLatLevel.TabIndex = 7;
         this._numLatLevel.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
         // 
         // _numLatCoef
         // 
         this._numLatCoef.DecimalPlaces = 2;
         this._numLatCoef.Enabled = false;
         this._numLatCoef.Increment = new decimal(new int[] {
            2,
            0,
            0,
            65536});
         this._numLatCoef.Location = new System.Drawing.Point(144, 61);
         this._numLatCoef.Margin = new System.Windows.Forms.Padding(2);
         this._numLatCoef.Maximum = new decimal(new int[] {
            20,
            0,
            0,
            0});
         this._numLatCoef.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numLatCoef.Name = "_numLatCoef";
         this._numLatCoef.Size = new System.Drawing.Size(109, 20);
         this._numLatCoef.TabIndex = 9;
         this._numLatCoef.Value = new decimal(new int[] {
            14,
            0,
            0,
            65536});
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this._cbEdgeCoef);
         this.groupBox1.Controls.Add(this._cbEdgeLevel);
         this.groupBox1.Controls.Add(this._cbEdge);
         this.groupBox1.Controls.Add(this._numEdgeLevel);
         this.groupBox1.Controls.Add(this._numEdgeCoef);
         this.groupBox1.Location = new System.Drawing.Point(11, 56);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(259, 100);
         this.groupBox1.TabIndex = 8;
         this.groupBox1.TabStop = false;
         // 
         // _cbEdgeCoef
         // 
         this._cbEdgeCoef.AutoSize = true;
         this._cbEdgeCoef.Enabled = false;
         this._cbEdgeCoef.Location = new System.Drawing.Point(12, 63);
         this._cbEdgeCoef.Name = "_cbEdgeCoef";
         this._cbEdgeCoef.Size = new System.Drawing.Size(109, 17);
         this._cbEdgeCoef.TabIndex = 10;
         this._cbEdgeCoef.Text = "Edge Coefficients";
         this._cbEdgeCoef.UseVisualStyleBackColor = true;
         this._cbEdgeCoef.CheckedChanged += new System.EventHandler(this._cbEdgeCoef_CheckedChanged);
         // 
         // _cbEdgeLevel
         // 
         this._cbEdgeLevel.AutoSize = true;
         this._cbEdgeLevel.Enabled = false;
         this._cbEdgeLevel.Location = new System.Drawing.Point(12, 32);
         this._cbEdgeLevel.Name = "_cbEdgeLevel";
         this._cbEdgeLevel.Size = new System.Drawing.Size(85, 17);
         this._cbEdgeLevel.TabIndex = 9;
         this._cbEdgeLevel.Text = "Edge Levels";
         this._cbEdgeLevel.UseVisualStyleBackColor = true;
         this._cbEdgeLevel.CheckedChanged += new System.EventHandler(this._cbEdgeLevel_CheckedChanged);
         // 
         // _cbEdge
         // 
         this._cbEdge.AutoSize = true;
         this._cbEdge.Location = new System.Drawing.Point(6, 0);
         this._cbEdge.Name = "_cbEdge";
         this._cbEdge.Size = new System.Drawing.Size(120, 17);
         this._cbEdge.TabIndex = 8;
         this._cbEdge.Text = "Edge Enhancement";
         this._cbEdge.UseVisualStyleBackColor = true;
         this._cbEdge.CheckedChanged += new System.EventHandler(this._cbEdge_CheckedChanged);
         // 
         // _numEdgeLevel
         // 
         this._numEdgeLevel.Enabled = false;
         this._numEdgeLevel.Location = new System.Drawing.Point(144, 29);
         this._numEdgeLevel.Margin = new System.Windows.Forms.Padding(2);
         this._numEdgeLevel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numEdgeLevel.Name = "_numEdgeLevel";
         this._numEdgeLevel.Size = new System.Drawing.Size(109, 20);
         this._numEdgeLevel.TabIndex = 3;
         this._numEdgeLevel.Value = new decimal(new int[] {
            3,
            0,
            0,
            0});
         this._numEdgeLevel.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _numEdgeCoef
         // 
         this._numEdgeCoef.DecimalPlaces = 2;
         this._numEdgeCoef.Enabled = false;
         this._numEdgeCoef.Increment = new decimal(new int[] {
            2,
            0,
            0,
            65536});
         this._numEdgeCoef.Location = new System.Drawing.Point(144, 60);
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
         // _numContrast
         // 
         this._numContrast.DecimalPlaces = 2;
         this._numContrast.Increment = new decimal(new int[] {
            50,
            0,
            0,
            131072});
         this._numContrast.Location = new System.Drawing.Point(155, 27);
         this._numContrast.Margin = new System.Windows.Forms.Padding(2);
         this._numContrast.Name = "_numContrast";
         this._numContrast.Size = new System.Drawing.Size(109, 20);
         this._numContrast.TabIndex = 1;
         this._numContrast.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
         this._numContrast.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _lblAmount
         // 
         this._lblAmount.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblAmount.Location = new System.Drawing.Point(14, 27);
         this._lblAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this._lblAmount.Name = "_lblAmount";
         this._lblAmount.Size = new System.Drawing.Size(65, 22);
         this._lblAmount.TabIndex = 0;
         this._lblAmount.Text = "Contrast";
         this._lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _cbFilter
         // 
         this._cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbFilter.Items.AddRange(new object[] {
            "Normal",
            "Resample",
            "Bicubic",
            "Gaussian"});
         this._cbFilter.Location = new System.Drawing.Point(163, 285);
         this._cbFilter.Margin = new System.Windows.Forms.Padding(2);
         this._cbFilter.Name = "_cbFilter";
         this._cbFilter.Size = new System.Drawing.Size(110, 21);
         this._cbFilter.TabIndex = 7;
         // 
         // _lblColorSpace
         // 
         this._lblColorSpace.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblColorSpace.Location = new System.Drawing.Point(29, 289);
         this._lblColorSpace.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this._lblColorSpace.Name = "_lblColorSpace";
         this._lblColorSpace.Size = new System.Drawing.Size(65, 22);
         this._lblColorSpace.TabIndex = 6;
         this._lblColorSpace.Text = "Filter";
         this._lblColorSpace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnCancel.Location = new System.Drawing.Point(211, 321);
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
         this._btnOk.Location = new System.Drawing.Point(122, 321);
         this._btnOk.Margin = new System.Windows.Forms.Padding(2);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(68, 22);
         this._btnOk.TabIndex = 1;
         this._btnOk.Text = "OK";
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _btnApply
         // 
         this._btnApply.Location = new System.Drawing.Point(26, 321);
         this._btnApply.Name = "_btnApply";
         this._btnApply.Size = new System.Drawing.Size(75, 23);
         this._btnApply.TabIndex = 8;
         this._btnApply.Text = "Apply";
         this._btnApply.UseVisualStyleBackColor = true;
         this._btnApply.Click += new System.EventHandler(this._btnApply_Click);
         // 
         // MultiscaleEnhancementDialog
         // 
         this.AcceptButton = this._btnOk;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(315, 354);
         this.Controls.Add(this._btnApply);
         this.Controls.Add(this._lblColorSpace);
         this.Controls.Add(this._cbFilter);
         this.Controls.Add(this._gbOptions);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Margin = new System.Windows.Forms.Padding(2);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "MultiscaleEnhancementDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Multiscale Enhancement";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MultiscaleEnhancementDialog_FormClosing);
         this._gbOptions.ResumeLayout(false);
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numLatLevel)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numLatCoef)).EndInit();
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numEdgeLevel)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numEdgeCoef)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numContrast)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gbOptions;
      private System.Windows.Forms.ComboBox _cbFilter;
      private System.Windows.Forms.Label _lblColorSpace;
      private System.Windows.Forms.NumericUpDown _numEdgeLevel;
      private System.Windows.Forms.NumericUpDown _numContrast;
      private System.Windows.Forms.Label _lblAmount;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.NumericUpDown _numEdgeCoef;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.NumericUpDown _numLatLevel;
      private System.Windows.Forms.NumericUpDown _numLatCoef;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.CheckBox _cbLatitude;
      private System.Windows.Forms.CheckBox _cbEdge;
      private System.Windows.Forms.CheckBox _cbEdgeLevel;
      private System.Windows.Forms.CheckBox _cbLatCoef;
      private System.Windows.Forms.CheckBox _cbLatLevel;
      private System.Windows.Forms.CheckBox _cbEdgeCoef;
      private System.Windows.Forms.Button _btnApply;
   }
}