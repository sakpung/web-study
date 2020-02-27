namespace DocumentCleanupDemo
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
          this._gb1 = new System.Windows.Forms.GroupBox();
          this._tbDPI = new System.Windows.Forms.TextBox();
          this._cbUseDPI = new System.Windows.Forms.CheckBox();
          this._gb2 = new System.Windows.Forms.GroupBox();
          this._rbVerticalLines = new System.Windows.Forms.RadioButton();
          this._rbHorizontalLines = new System.Windows.Forms.RadioButton();
          this._gb3 = new System.Windows.Forms.GroupBox();
          this._lbl7 = new System.Windows.Forms.Label();
          this._lbl6 = new System.Windows.Forms.Label();
          this._lbl5 = new System.Windows.Forms.Label();
          this._tbMaximumWallPercent = new System.Windows.Forms.TextBox();
          this._lblMaxWallPercent = new System.Windows.Forms.Label();
          this._tbWallHeight = new System.Windows.Forms.TextBox();
          this._lblWallHeight = new System.Windows.Forms.Label();
          this._tbMaximumLineWidth = new System.Windows.Forms.TextBox();
          this._lblMaximumWidth = new System.Windows.Forms.Label();
          this._tbMinimumLineLength = new System.Windows.Forms.TextBox();
          this._lblMinimumLength = new System.Windows.Forms.Label();
          this._gb4 = new System.Windows.Forms.GroupBox();
          this._lbl9 = new System.Windows.Forms.Label();
          this._lbl8 = new System.Windows.Forms.Label();
          this._tbGapLength = new System.Windows.Forms.TextBox();
          this._tbVariance = new System.Windows.Forms.TextBox();
          this._cbRemoveEntireLine = new System.Windows.Forms.CheckBox();
          this._cbMaximumGap = new System.Windows.Forms.CheckBox();
          this._cbLineVariance = new System.Windows.Forms.CheckBox();
          this._btnOk = new System.Windows.Forms.Button();
          this._btnCancel = new System.Windows.Forms.Button();
          this._gb1.SuspendLayout();
          this._gb2.SuspendLayout();
          this._gb3.SuspendLayout();
          this._gb4.SuspendLayout();
          this.SuspendLayout();
          // 
          // _gb1
          // 
          this._gb1.Controls.Add(this._tbDPI);
          this._gb1.Controls.Add(this._cbUseDPI);
          this._gb1.Location = new System.Drawing.Point(12, 12);
          this._gb1.Name = "_gb1";
          this._gb1.Size = new System.Drawing.Size(280, 48);
          this._gb1.TabIndex = 0;
          this._gb1.TabStop = false;
          this._gb1.Text = "Flags";
          // 
          // _tbDPI
          // 
          this._tbDPI.Enabled = false;
          this._tbDPI.Location = new System.Drawing.Point(90, 17);
          this._tbDPI.Name = "_tbDPI";
          this._tbDPI.Size = new System.Drawing.Size(100, 20);
          this._tbDPI.TabIndex = 1;
          // 
          // _cbUseDPI
          // 
          this._cbUseDPI.AutoSize = true;
          this._cbUseDPI.Location = new System.Drawing.Point(18, 19);
          this._cbUseDPI.Name = "_cbUseDPI";
          this._cbUseDPI.Size = new System.Drawing.Size(66, 17);
          this._cbUseDPI.TabIndex = 0;
          this._cbUseDPI.Text = "Use DPI";
          this._cbUseDPI.UseVisualStyleBackColor = true;
          // 
          // _gb2
          // 
          this._gb2.Controls.Add(this._rbVerticalLines);
          this._gb2.Controls.Add(this._rbHorizontalLines);
          this._gb2.Location = new System.Drawing.Point(12, 66);
          this._gb2.Name = "_gb2";
          this._gb2.Size = new System.Drawing.Size(280, 70);
          this._gb2.TabIndex = 1;
          this._gb2.TabStop = false;
          this._gb2.Text = "Lines To Remove";
          // 
          // _rbVerticalLines
          // 
          this._rbVerticalLines.AutoSize = true;
          this._rbVerticalLines.Location = new System.Drawing.Point(18, 42);
          this._rbVerticalLines.Name = "_rbVerticalLines";
          this._rbVerticalLines.Size = new System.Drawing.Size(131, 17);
          this._rbVerticalLines.TabIndex = 1;
          this._rbVerticalLines.TabStop = true;
          this._rbVerticalLines.Text = "Remove Vertical Lines";
          this._rbVerticalLines.UseVisualStyleBackColor = true;
          // 
          // _rbHorizontalLines
          // 
          this._rbHorizontalLines.AutoSize = true;
          this._rbHorizontalLines.Location = new System.Drawing.Point(18, 19);
          this._rbHorizontalLines.Name = "_rbHorizontalLines";
          this._rbHorizontalLines.Size = new System.Drawing.Size(143, 17);
          this._rbHorizontalLines.TabIndex = 0;
          this._rbHorizontalLines.TabStop = true;
          this._rbHorizontalLines.Text = "Remove Horizontal Lines";
          this._rbHorizontalLines.UseVisualStyleBackColor = true;
          // 
          // _gb3
          // 
          this._gb3.Controls.Add(this._lbl7);
          this._gb3.Controls.Add(this._lbl6);
          this._gb3.Controls.Add(this._lbl5);
          this._gb3.Controls.Add(this._tbMaximumWallPercent);
          this._gb3.Controls.Add(this._lblMaxWallPercent);
          this._gb3.Controls.Add(this._tbWallHeight);
          this._gb3.Controls.Add(this._lblWallHeight);
          this._gb3.Controls.Add(this._tbMaximumLineWidth);
          this._gb3.Controls.Add(this._lblMaximumWidth);
          this._gb3.Controls.Add(this._tbMinimumLineLength);
          this._gb3.Controls.Add(this._lblMinimumLength);
          this._gb3.Location = new System.Drawing.Point(12, 142);
          this._gb3.Name = "_gb3";
          this._gb3.Size = new System.Drawing.Size(280, 130);
          this._gb3.TabIndex = 1;
          this._gb3.TabStop = false;
          this._gb3.Text = "Dimensions";
          // 
          // _lbl7
          // 
          this._lbl7.AutoSize = true;
          this._lbl7.Location = new System.Drawing.Point(175, 76);
          this._lbl7.Name = "_lbl7";
          this._lbl7.Size = new System.Drawing.Size(29, 13);
          this._lbl7.TabIndex = 10;
          this._lbl7.Text = "_lbl7";
          // 
          // _lbl6
          // 
          this._lbl6.AutoSize = true;
          this._lbl6.Location = new System.Drawing.Point(175, 52);
          this._lbl6.Name = "_lbl6";
          this._lbl6.Size = new System.Drawing.Size(29, 13);
          this._lbl6.TabIndex = 9;
          this._lbl6.Text = "_lbl6";
          // 
          // _lbl5
          // 
          this._lbl5.AutoSize = true;
          this._lbl5.Location = new System.Drawing.Point(175, 26);
          this._lbl5.Name = "_lbl5";
          this._lbl5.Size = new System.Drawing.Size(29, 13);
          this._lbl5.TabIndex = 8;
          this._lbl5.Text = "_lbl5";
          // 
          // _tbMaximumWallPercent
          // 
          this._tbMaximumWallPercent.Location = new System.Drawing.Point(114, 98);
          this._tbMaximumWallPercent.Name = "_tbMaximumWallPercent";
          this._tbMaximumWallPercent.Size = new System.Drawing.Size(45, 20);
          this._tbMaximumWallPercent.TabIndex = 7;
          this._tbMaximumWallPercent.TextChanged += new System.EventHandler(this._tbMaximumWallPercent_TextChanged);
          // 
          // _lblMaxWallPercent
          // 
          this._lblMaxWallPercent.AutoSize = true;
          this._lblMaxWallPercent.Location = new System.Drawing.Point(12, 104);
          this._lblMaxWallPercent.Name = "_lblMaxWallPercent";
          this._lblMaxWallPercent.Size = new System.Drawing.Size(91, 13);
          this._lblMaxWallPercent.TabIndex = 6;
          this._lblMaxWallPercent.Text = "Max Wall Percent";
          // 
          // _tbWallHeight
          // 
          this._tbWallHeight.Location = new System.Drawing.Point(114, 71);
          this._tbWallHeight.Name = "_tbWallHeight";
          this._tbWallHeight.Size = new System.Drawing.Size(45, 20);
          this._tbWallHeight.TabIndex = 5;
          this._tbWallHeight.TextChanged += new System.EventHandler(this._tbWallHeight_TextChanged);
          // 
          // _lblWallHeight
          // 
          this._lblWallHeight.AutoSize = true;
          this._lblWallHeight.Location = new System.Drawing.Point(12, 78);
          this._lblWallHeight.Name = "_lblWallHeight";
          this._lblWallHeight.Size = new System.Drawing.Size(62, 13);
          this._lblWallHeight.TabIndex = 4;
          this._lblWallHeight.Text = "Wall Height";
          // 
          // _tbMaximumLineWidth
          // 
          this._tbMaximumLineWidth.Location = new System.Drawing.Point(114, 45);
          this._tbMaximumLineWidth.Name = "_tbMaximumLineWidth";
          this._tbMaximumLineWidth.Size = new System.Drawing.Size(45, 20);
          this._tbMaximumLineWidth.TabIndex = 3;
          this._tbMaximumLineWidth.TextChanged += new System.EventHandler(this._tbMaximumLineWidth_TextChanged);
          // 
          // _lblMaximumWidth
          // 
          this._lblMaximumWidth.AutoSize = true;
          this._lblMaximumWidth.Location = new System.Drawing.Point(12, 52);
          this._lblMaximumWidth.Name = "_lblMaximumWidth";
          this._lblMaximumWidth.Size = new System.Drawing.Size(82, 13);
          this._lblMaximumWidth.TabIndex = 2;
          this._lblMaximumWidth.Text = "Maximum Width";
          // 
          // _tbMinimumLineLength
          // 
          this._tbMinimumLineLength.Location = new System.Drawing.Point(114, 19);
          this._tbMinimumLineLength.Name = "_tbMinimumLineLength";
          this._tbMinimumLineLength.Size = new System.Drawing.Size(45, 20);
          this._tbMinimumLineLength.TabIndex = 1;
          this._tbMinimumLineLength.TextChanged += new System.EventHandler(this._tbMinimumLineLength_TextChanged);
          // 
          // _lblMinimumLength
          // 
          this._lblMinimumLength.AutoSize = true;
          this._lblMinimumLength.Location = new System.Drawing.Point(12, 26);
          this._lblMinimumLength.Name = "_lblMinimumLength";
          this._lblMinimumLength.Size = new System.Drawing.Size(84, 13);
          this._lblMinimumLength.TabIndex = 0;
          this._lblMinimumLength.Text = "Minimum Length";
          // 
          // _gb4
          // 
          this._gb4.Controls.Add(this._lbl9);
          this._gb4.Controls.Add(this._lbl8);
          this._gb4.Controls.Add(this._tbGapLength);
          this._gb4.Controls.Add(this._tbVariance);
          this._gb4.Controls.Add(this._cbRemoveEntireLine);
          this._gb4.Controls.Add(this._cbMaximumGap);
          this._gb4.Controls.Add(this._cbLineVariance);
          this._gb4.Location = new System.Drawing.Point(12, 278);
          this._gb4.Name = "_gb4";
          this._gb4.Size = new System.Drawing.Size(280, 100);
          this._gb4.TabIndex = 1;
          this._gb4.TabStop = false;
          this._gb4.Text = "Optional Processing";
          // 
          // _lbl9
          // 
          this._lbl9.AutoSize = true;
          this._lbl9.Location = new System.Drawing.Point(175, 46);
          this._lbl9.Name = "_lbl9";
          this._lbl9.Size = new System.Drawing.Size(29, 13);
          this._lbl9.TabIndex = 6;
          this._lbl9.Text = "_lbl9";
          // 
          // _lbl8
          // 
          this._lbl8.AutoSize = true;
          this._lbl8.Location = new System.Drawing.Point(175, 19);
          this._lbl8.Name = "_lbl8";
          this._lbl8.Size = new System.Drawing.Size(29, 13);
          this._lbl8.TabIndex = 5;
          this._lbl8.Text = "_lbl8";
          // 
          // _tbGapLength
          // 
          this._tbGapLength.Location = new System.Drawing.Point(114, 39);
          this._tbGapLength.Name = "_tbGapLength";
          this._tbGapLength.Size = new System.Drawing.Size(45, 20);
          this._tbGapLength.TabIndex = 4;
          this._tbGapLength.TextChanged += new System.EventHandler(this._tbGapLength_TextChanged);
          // 
          // _tbVariance
          // 
          this._tbVariance.Location = new System.Drawing.Point(114, 13);
          this._tbVariance.Name = "_tbVariance";
          this._tbVariance.Size = new System.Drawing.Size(45, 20);
          this._tbVariance.TabIndex = 3;
          this._tbVariance.TextChanged += new System.EventHandler(this._tbVariance_TextChanged);
          // 
          // _cbRemoveEntireLine
          // 
          this._cbRemoveEntireLine.AutoSize = true;
          this._cbRemoveEntireLine.Location = new System.Drawing.Point(18, 65);
          this._cbRemoveEntireLine.Name = "_cbRemoveEntireLine";
          this._cbRemoveEntireLine.Size = new System.Drawing.Size(119, 17);
          this._cbRemoveEntireLine.TabIndex = 2;
          this._cbRemoveEntireLine.Text = "Remove Entire Line";
          this._cbRemoveEntireLine.UseVisualStyleBackColor = true;
          // 
          // _cbMaximumGap
          // 
          this._cbMaximumGap.AutoSize = true;
          this._cbMaximumGap.Location = new System.Drawing.Point(18, 42);
          this._cbMaximumGap.Name = "_cbMaximumGap";
          this._cbMaximumGap.Size = new System.Drawing.Size(93, 17);
          this._cbMaximumGap.TabIndex = 1;
          this._cbMaximumGap.Text = "Maximum Gap";
          this._cbMaximumGap.UseVisualStyleBackColor = true;
          this._cbMaximumGap.CheckedChanged += new System.EventHandler(this._cbMaximumGap_CheckedChanged);
          // 
          // _cbLineVariance
          // 
          this._cbLineVariance.AutoSize = true;
          this._cbLineVariance.Location = new System.Drawing.Point(18, 19);
          this._cbLineVariance.Name = "_cbLineVariance";
          this._cbLineVariance.Size = new System.Drawing.Size(91, 17);
          this._cbLineVariance.TabIndex = 0;
          this._cbLineVariance.Text = "Line Variance";
          this._cbLineVariance.UseVisualStyleBackColor = true;
          this._cbLineVariance.CheckedChanged += new System.EventHandler(this._cbLineVariance_CheckedChanged);
          // 
          // _btnOk
          // 
          this._btnOk.Location = new System.Drawing.Point(298, 12);
          this._btnOk.Name = "_btnOk";
          this._btnOk.Size = new System.Drawing.Size(75, 23);
          this._btnOk.TabIndex = 2;
          this._btnOk.Text = "OK";
          this._btnOk.UseVisualStyleBackColor = true;
          this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
          // 
          // _btnCancel
          // 
          this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          this._btnCancel.Location = new System.Drawing.Point(298, 41);
          this._btnCancel.Name = "_btnCancel";
          this._btnCancel.Size = new System.Drawing.Size(75, 23);
          this._btnCancel.TabIndex = 3;
          this._btnCancel.Text = "Cancel";
          this._btnCancel.UseVisualStyleBackColor = true;
          this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
          // 
          // LineRemoveDialog
          // 
          this.AcceptButton = this._btnOk;
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._btnCancel;
          this.ClientSize = new System.Drawing.Size(381, 389);
          this.Controls.Add(this._btnCancel);
          this.Controls.Add(this._btnOk);
          this.Controls.Add(this._gb2);
          this.Controls.Add(this._gb3);
          this.Controls.Add(this._gb4);
          this.Controls.Add(this._gb1);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "LineRemoveDialog";
          this.Text = "Line Removal";
          this._gb1.ResumeLayout(false);
          this._gb1.PerformLayout();
          this._gb2.ResumeLayout(false);
          this._gb2.PerformLayout();
          this._gb3.ResumeLayout(false);
          this._gb3.PerformLayout();
          this._gb4.ResumeLayout(false);
          this._gb4.PerformLayout();
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gb1;
      private System.Windows.Forms.CheckBox _cbUseDPI;
      private System.Windows.Forms.GroupBox _gb2;
      private System.Windows.Forms.RadioButton _rbVerticalLines;
      private System.Windows.Forms.RadioButton _rbHorizontalLines;
      private System.Windows.Forms.GroupBox _gb3;
      private System.Windows.Forms.Label _lbl7;
      private System.Windows.Forms.Label _lbl6;
      private System.Windows.Forms.Label _lbl5;
      private System.Windows.Forms.TextBox _tbMaximumWallPercent;
      private System.Windows.Forms.Label _lblMaxWallPercent;
      private System.Windows.Forms.TextBox _tbWallHeight;
      private System.Windows.Forms.Label _lblWallHeight;
      private System.Windows.Forms.TextBox _tbMaximumLineWidth;
      private System.Windows.Forms.Label _lblMaximumWidth;
      private System.Windows.Forms.TextBox _tbMinimumLineLength;
      private System.Windows.Forms.Label _lblMinimumLength;
      private System.Windows.Forms.GroupBox _gb4;
      private System.Windows.Forms.Label _lbl9;
      private System.Windows.Forms.Label _lbl8;
      private System.Windows.Forms.TextBox _tbGapLength;
      private System.Windows.Forms.TextBox _tbVariance;
      private System.Windows.Forms.CheckBox _cbRemoveEntireLine;
      private System.Windows.Forms.CheckBox _cbMaximumGap;
      private System.Windows.Forms.CheckBox _cbLineVariance;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.TextBox _tbDPI;
   }
}