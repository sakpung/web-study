namespace DocumentCleanupDemo
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
          this._gbFlags = new System.Windows.Forms.GroupBox();
          this._tbDPI = new System.Windows.Forms.TextBox();
          this._cbUseDiagonals = new System.Windows.Forms.CheckBox();
          this._cbUseDotDimensions = new System.Windows.Forms.CheckBox();
          this._cbUseDPI = new System.Windows.Forms.CheckBox();
          this._gbDotDimensions = new System.Windows.Forms.GroupBox();
          this._lbl5 = new System.Windows.Forms.Label();
          this._lbl6 = new System.Windows.Forms.Label();
          this._lbl7 = new System.Windows.Forms.Label();
          this._lbl8 = new System.Windows.Forms.Label();
          this._lblMaximumDotHeight = new System.Windows.Forms.Label();
          this._lblMaximumDotWidth = new System.Windows.Forms.Label();
          this._lblMinimumDotHeight = new System.Windows.Forms.Label();
          this._lblMinimumDotWidth = new System.Windows.Forms.Label();
          this._tbMaximumDotHeight = new System.Windows.Forms.TextBox();
          this._tbMaximumDotWidth = new System.Windows.Forms.TextBox();
          this._tbMinimumDotHeight = new System.Windows.Forms.TextBox();
          this._tbMinimumDotWidth = new System.Windows.Forms.TextBox();
          this._btnOk = new System.Windows.Forms.Button();
          this._btnCancel = new System.Windows.Forms.Button();
          this._gbFlags.SuspendLayout();
          this._gbDotDimensions.SuspendLayout();
          this.SuspendLayout();
          // 
          // _gbFlags
          // 
          this._gbFlags.Controls.Add(this._tbDPI);
          this._gbFlags.Controls.Add(this._cbUseDiagonals);
          this._gbFlags.Controls.Add(this._cbUseDotDimensions);
          this._gbFlags.Controls.Add(this._cbUseDPI);
          this._gbFlags.Location = new System.Drawing.Point(12, 12);
          this._gbFlags.Name = "_gbFlags";
          this._gbFlags.Size = new System.Drawing.Size(281, 100);
          this._gbFlags.TabIndex = 0;
          this._gbFlags.TabStop = false;
          this._gbFlags.Text = "Flags";
          // 
          // _tbDPI
          // 
          this._tbDPI.Enabled = false;
          this._tbDPI.Location = new System.Drawing.Point(96, 19);
          this._tbDPI.Name = "_tbDPI";
          this._tbDPI.Size = new System.Drawing.Size(100, 20);
          this._tbDPI.TabIndex = 3;
          // 
          // _cbUseDiagonals
          // 
          this._cbUseDiagonals.AutoSize = true;
          this._cbUseDiagonals.Location = new System.Drawing.Point(24, 65);
          this._cbUseDiagonals.Name = "_cbUseDiagonals";
          this._cbUseDiagonals.Size = new System.Drawing.Size(95, 17);
          this._cbUseDiagonals.TabIndex = 2;
          this._cbUseDiagonals.Text = "Use Diagonals";
          this._cbUseDiagonals.UseVisualStyleBackColor = true;
          // 
          // _cbUseDotDimensions
          // 
          this._cbUseDotDimensions.AutoSize = true;
          this._cbUseDotDimensions.Location = new System.Drawing.Point(24, 42);
          this._cbUseDotDimensions.Name = "_cbUseDotDimensions";
          this._cbUseDotDimensions.Size = new System.Drawing.Size(122, 17);
          this._cbUseDotDimensions.TabIndex = 1;
          this._cbUseDotDimensions.Text = "Use Dot Dimensions";
          this._cbUseDotDimensions.UseVisualStyleBackColor = true;
          this._cbUseDotDimensions.CheckedChanged += new System.EventHandler(this._cbUseDotDimensions_CheckedChanged);
          // 
          // _cbUseDPI
          // 
          this._cbUseDPI.AutoSize = true;
          this._cbUseDPI.Location = new System.Drawing.Point(24, 19);
          this._cbUseDPI.Name = "_cbUseDPI";
          this._cbUseDPI.Size = new System.Drawing.Size(66, 17);
          this._cbUseDPI.TabIndex = 0;
          this._cbUseDPI.Text = "Use DPI";
          this._cbUseDPI.UseVisualStyleBackColor = true;
          // 
          // _gbDotDimensions
          // 
          this._gbDotDimensions.Controls.Add(this._lbl5);
          this._gbDotDimensions.Controls.Add(this._lbl6);
          this._gbDotDimensions.Controls.Add(this._lbl7);
          this._gbDotDimensions.Controls.Add(this._lbl8);
          this._gbDotDimensions.Controls.Add(this._lblMaximumDotHeight);
          this._gbDotDimensions.Controls.Add(this._lblMaximumDotWidth);
          this._gbDotDimensions.Controls.Add(this._lblMinimumDotHeight);
          this._gbDotDimensions.Controls.Add(this._lblMinimumDotWidth);
          this._gbDotDimensions.Controls.Add(this._tbMaximumDotHeight);
          this._gbDotDimensions.Controls.Add(this._tbMaximumDotWidth);
          this._gbDotDimensions.Controls.Add(this._tbMinimumDotHeight);
          this._gbDotDimensions.Controls.Add(this._tbMinimumDotWidth);
          this._gbDotDimensions.Location = new System.Drawing.Point(12, 118);
          this._gbDotDimensions.Name = "_gbDotDimensions";
          this._gbDotDimensions.Size = new System.Drawing.Size(281, 152);
          this._gbDotDimensions.TabIndex = 1;
          this._gbDotDimensions.TabStop = false;
          this._gbDotDimensions.Text = "Dot Dimensions";
          // 
          // _lbl5
          // 
          this._lbl5.AutoSize = true;
          this._lbl5.Location = new System.Drawing.Point(211, 117);
          this._lbl5.Name = "_lbl5";
          this._lbl5.Size = new System.Drawing.Size(29, 13);
          this._lbl5.TabIndex = 11;
          this._lbl5.Text = "_lbl5";
          // 
          // _lbl6
          // 
          this._lbl6.AutoSize = true;
          this._lbl6.Location = new System.Drawing.Point(211, 91);
          this._lbl6.Name = "_lbl6";
          this._lbl6.Size = new System.Drawing.Size(29, 13);
          this._lbl6.TabIndex = 10;
          this._lbl6.Text = "_lbl6";
          // 
          // _lbl7
          // 
          this._lbl7.AutoSize = true;
          this._lbl7.Location = new System.Drawing.Point(211, 65);
          this._lbl7.Name = "_lbl7";
          this._lbl7.Size = new System.Drawing.Size(29, 13);
          this._lbl7.TabIndex = 9;
          this._lbl7.Text = "_lbl7";
          // 
          // _lbl8
          // 
          this._lbl8.AutoSize = true;
          this._lbl8.Location = new System.Drawing.Point(211, 39);
          this._lbl8.Name = "_lbl8";
          this._lbl8.Size = new System.Drawing.Size(29, 13);
          this._lbl8.TabIndex = 8;
          this._lbl8.Text = "_lbl8";
          // 
          // _lblMaximumDotHeight
          // 
          this._lblMaximumDotHeight.AutoSize = true;
          this._lblMaximumDotHeight.Location = new System.Drawing.Point(21, 117);
          this._lblMaximumDotHeight.Name = "_lblMaximumDotHeight";
          this._lblMaximumDotHeight.Size = new System.Drawing.Size(105, 13);
          this._lblMaximumDotHeight.TabIndex = 7;
          this._lblMaximumDotHeight.Text = "Maximum Dot Height";
          // 
          // _lblMaximumDotWidth
          // 
          this._lblMaximumDotWidth.AutoSize = true;
          this._lblMaximumDotWidth.Location = new System.Drawing.Point(21, 91);
          this._lblMaximumDotWidth.Name = "_lblMaximumDotWidth";
          this._lblMaximumDotWidth.Size = new System.Drawing.Size(102, 13);
          this._lblMaximumDotWidth.TabIndex = 6;
          this._lblMaximumDotWidth.Text = "Maximum Dot Width";
          // 
          // _lblMinimumDotHeight
          // 
          this._lblMinimumDotHeight.AutoSize = true;
          this._lblMinimumDotHeight.Location = new System.Drawing.Point(21, 65);
          this._lblMinimumDotHeight.Name = "_lblMinimumDotHeight";
          this._lblMinimumDotHeight.Size = new System.Drawing.Size(102, 13);
          this._lblMinimumDotHeight.TabIndex = 5;
          this._lblMinimumDotHeight.Text = "Minimum Dot Height";
          // 
          // _lblMinimumDotWidth
          // 
          this._lblMinimumDotWidth.AutoSize = true;
          this._lblMinimumDotWidth.Location = new System.Drawing.Point(21, 39);
          this._lblMinimumDotWidth.Name = "_lblMinimumDotWidth";
          this._lblMinimumDotWidth.Size = new System.Drawing.Size(99, 13);
          this._lblMinimumDotWidth.TabIndex = 4;
          this._lblMinimumDotWidth.Text = "Minimum Dot Width";
          // 
          // _tbMaximumDotHeight
          // 
          this._tbMaximumDotHeight.Location = new System.Drawing.Point(131, 110);
          this._tbMaximumDotHeight.Name = "_tbMaximumDotHeight";
          this._tbMaximumDotHeight.Size = new System.Drawing.Size(62, 20);
          this._tbMaximumDotHeight.TabIndex = 3;
          this._tbMaximumDotHeight.TextChanged += new System.EventHandler(this._tbMaximumDotHeight_TextChanged);
          // 
          // _tbMaximumDotWidth
          // 
          this._tbMaximumDotWidth.Location = new System.Drawing.Point(131, 84);
          this._tbMaximumDotWidth.Name = "_tbMaximumDotWidth";
          this._tbMaximumDotWidth.Size = new System.Drawing.Size(62, 20);
          this._tbMaximumDotWidth.TabIndex = 2;
          this._tbMaximumDotWidth.TextChanged += new System.EventHandler(this._tbMaximumDotWidth_TextChanged);
          // 
          // _tbMinimumDotHeight
          // 
          this._tbMinimumDotHeight.Location = new System.Drawing.Point(131, 58);
          this._tbMinimumDotHeight.Name = "_tbMinimumDotHeight";
          this._tbMinimumDotHeight.Size = new System.Drawing.Size(62, 20);
          this._tbMinimumDotHeight.TabIndex = 1;
          this._tbMinimumDotHeight.TextChanged += new System.EventHandler(this._tbMinimumDotHeight_TextChanged);
          // 
          // _tbMinimumDotWidth
          // 
          this._tbMinimumDotWidth.Location = new System.Drawing.Point(131, 32);
          this._tbMinimumDotWidth.Name = "_tbMinimumDotWidth";
          this._tbMinimumDotWidth.Size = new System.Drawing.Size(62, 20);
          this._tbMinimumDotWidth.TabIndex = 0;
          this._tbMinimumDotWidth.TextChanged += new System.EventHandler(this._tbMinimumDotWidth_TextChanged);
          // 
          // _btnOk
          // 
          this._btnOk.Location = new System.Drawing.Point(299, 12);
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
          this._btnCancel.Location = new System.Drawing.Point(299, 41);
          this._btnCancel.Name = "_btnCancel";
          this._btnCancel.Size = new System.Drawing.Size(75, 23);
          this._btnCancel.TabIndex = 3;
          this._btnCancel.Text = "Cancel";
          this._btnCancel.UseVisualStyleBackColor = true;
          this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
          // 
          // DotRemoveDialog
          // 
          this.AcceptButton = this._btnOk;
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._btnCancel;
          this.ClientSize = new System.Drawing.Size(384, 282);
          this.Controls.Add(this._btnCancel);
          this.Controls.Add(this._btnOk);
          this.Controls.Add(this._gbDotDimensions);
          this.Controls.Add(this._gbFlags);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "DotRemoveDialog";
          this.Text = "Dot Removal";
          this._gbFlags.ResumeLayout(false);
          this._gbFlags.PerformLayout();
          this._gbDotDimensions.ResumeLayout(false);
          this._gbDotDimensions.PerformLayout();
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gbFlags;
      private System.Windows.Forms.TextBox _tbDPI;
      private System.Windows.Forms.CheckBox _cbUseDiagonals;
      private System.Windows.Forms.CheckBox _cbUseDotDimensions;
      private System.Windows.Forms.CheckBox _cbUseDPI;
      private System.Windows.Forms.GroupBox _gbDotDimensions;
      private System.Windows.Forms.Label _lbl5;
      private System.Windows.Forms.Label _lbl6;
      private System.Windows.Forms.Label _lbl7;
      private System.Windows.Forms.Label _lbl8;
      private System.Windows.Forms.Label _lblMaximumDotHeight;
      private System.Windows.Forms.Label _lblMaximumDotWidth;
      private System.Windows.Forms.Label _lblMinimumDotHeight;
      private System.Windows.Forms.Label _lblMinimumDotWidth;
      private System.Windows.Forms.TextBox _tbMaximumDotHeight;
      private System.Windows.Forms.TextBox _tbMaximumDotWidth;
      private System.Windows.Forms.TextBox _tbMinimumDotHeight;
      private System.Windows.Forms.TextBox _tbMinimumDotWidth;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnCancel;
   }
}