namespace DocumentCleanupDemo
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
          this._btnOk = new System.Windows.Forms.Button();
          this._btnCancel = new System.Windows.Forms.Button();
          this._gb1 = new System.Windows.Forms.GroupBox();
          this._cbUseDPI = new System.Windows.Forms.CheckBox();
          this._tbDPI = new System.Windows.Forms.TextBox();
          this._gb2 = new System.Windows.Forms.GroupBox();
          this._lbl4 = new System.Windows.Forms.Label();
          this._lbl3 = new System.Windows.Forms.Label();
          this._tbMinimumInvertHeight = new System.Windows.Forms.TextBox();
          this._lblMinimumInvertHeight = new System.Windows.Forms.Label();
          this._tbMinimumInvertWidth = new System.Windows.Forms.TextBox();
          this._lblMinimumInvertWidth = new System.Windows.Forms.Label();
          this._gb3 = new System.Windows.Forms.GroupBox();
          this._tbMaximumBlackPercent = new System.Windows.Forms.TextBox();
          this._tbMinimumBlackPercent = new System.Windows.Forms.TextBox();
          this._lblMaximumBlackPercent = new System.Windows.Forms.Label();
          this._lblMinimumBlackPercent = new System.Windows.Forms.Label();
          this._gb1.SuspendLayout();
          this._gb2.SuspendLayout();
          this._gb3.SuspendLayout();
          this.SuspendLayout();
          // 
          // _btnOk
          // 
          this._btnOk.Location = new System.Drawing.Point(277, 12);
          this._btnOk.Name = "_btnOk";
          this._btnOk.Size = new System.Drawing.Size(75, 23);
          this._btnOk.TabIndex = 0;
          this._btnOk.Text = "OK";
          this._btnOk.UseVisualStyleBackColor = true;
          this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
          // 
          // _btnCancel
          // 
          this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          this._btnCancel.Location = new System.Drawing.Point(277, 41);
          this._btnCancel.Name = "_btnCancel";
          this._btnCancel.Size = new System.Drawing.Size(75, 23);
          this._btnCancel.TabIndex = 1;
          this._btnCancel.Text = "Cancel";
          this._btnCancel.UseVisualStyleBackColor = true;
          this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
          // 
          // _gb1
          // 
          this._gb1.Controls.Add(this._cbUseDPI);
          this._gb1.Controls.Add(this._tbDPI);
          this._gb1.Location = new System.Drawing.Point(12, 12);
          this._gb1.Name = "_gb1";
          this._gb1.Size = new System.Drawing.Size(259, 58);
          this._gb1.TabIndex = 2;
          this._gb1.TabStop = false;
          this._gb1.Text = "Flags";
          // 
          // _cbUseDPI
          // 
          this._cbUseDPI.AutoSize = true;
          this._cbUseDPI.Location = new System.Drawing.Point(21, 25);
          this._cbUseDPI.Name = "_cbUseDPI";
          this._cbUseDPI.Size = new System.Drawing.Size(66, 17);
          this._cbUseDPI.TabIndex = 2;
          this._cbUseDPI.Text = "Use DPI";
          this._cbUseDPI.UseVisualStyleBackColor = true;
          // 
          // _tbDPI
          // 
          this._tbDPI.Enabled = false;
          this._tbDPI.Location = new System.Drawing.Point(94, 22);
          this._tbDPI.Name = "_tbDPI";
          this._tbDPI.Size = new System.Drawing.Size(100, 20);
          this._tbDPI.TabIndex = 1;
          // 
          // _gb2
          // 
          this._gb2.Controls.Add(this._lbl4);
          this._gb2.Controls.Add(this._lbl3);
          this._gb2.Controls.Add(this._tbMinimumInvertHeight);
          this._gb2.Controls.Add(this._lblMinimumInvertHeight);
          this._gb2.Controls.Add(this._tbMinimumInvertWidth);
          this._gb2.Controls.Add(this._lblMinimumInvertWidth);
          this._gb2.Location = new System.Drawing.Point(12, 76);
          this._gb2.Name = "_gb2";
          this._gb2.Size = new System.Drawing.Size(259, 79);
          this._gb2.TabIndex = 3;
          this._gb2.TabStop = false;
          this._gb2.Text = "Inverted Text Dimensions";
          // 
          // _lbl4
          // 
          this._lbl4.AutoSize = true;
          this._lbl4.Location = new System.Drawing.Point(200, 58);
          this._lbl4.Name = "_lbl4";
          this._lbl4.Size = new System.Drawing.Size(29, 13);
          this._lbl4.TabIndex = 7;
          this._lbl4.Text = "_lbl4";
          // 
          // _lbl3
          // 
          this._lbl3.AutoSize = true;
          this._lbl3.Location = new System.Drawing.Point(200, 32);
          this._lbl3.Name = "_lbl3";
          this._lbl3.Size = new System.Drawing.Size(29, 13);
          this._lbl3.TabIndex = 6;
          this._lbl3.Text = "_lbl3";
          // 
          // _tbMinimumInvertHeight
          // 
          this._tbMinimumInvertHeight.Location = new System.Drawing.Point(133, 51);
          this._tbMinimumInvertHeight.Name = "_tbMinimumInvertHeight";
          this._tbMinimumInvertHeight.Size = new System.Drawing.Size(60, 20);
          this._tbMinimumInvertHeight.TabIndex = 5;
          this._tbMinimumInvertHeight.TextChanged += new System.EventHandler(this._tbMinimumInvertHeight_TextChanged);
          // 
          // _lblMinimumInvertHeight
          // 
          this._lblMinimumInvertHeight.AutoSize = true;
          this._lblMinimumInvertHeight.Location = new System.Drawing.Point(18, 52);
          this._lblMinimumInvertHeight.Name = "_lblMinimumInvertHeight";
          this._lblMinimumInvertHeight.Size = new System.Drawing.Size(112, 13);
          this._lblMinimumInvertHeight.TabIndex = 4;
          this._lblMinimumInvertHeight.Text = "Minimum Invert Height";
          // 
          // _tbMinimumInvertWidth
          // 
          this._tbMinimumInvertWidth.Location = new System.Drawing.Point(133, 25);
          this._tbMinimumInvertWidth.Name = "_tbMinimumInvertWidth";
          this._tbMinimumInvertWidth.Size = new System.Drawing.Size(60, 20);
          this._tbMinimumInvertWidth.TabIndex = 3;
          this._tbMinimumInvertWidth.TextChanged += new System.EventHandler(this._tbMinimumInvertWidth_TextChanged);
          // 
          // _lblMinimumInvertWidth
          // 
          this._lblMinimumInvertWidth.AutoSize = true;
          this._lblMinimumInvertWidth.Location = new System.Drawing.Point(18, 25);
          this._lblMinimumInvertWidth.Name = "_lblMinimumInvertWidth";
          this._lblMinimumInvertWidth.Size = new System.Drawing.Size(109, 13);
          this._lblMinimumInvertWidth.TabIndex = 0;
          this._lblMinimumInvertWidth.Text = "Minimum Invert Width";
          // 
          // _gb3
          // 
          this._gb3.Controls.Add(this._tbMaximumBlackPercent);
          this._gb3.Controls.Add(this._tbMinimumBlackPercent);
          this._gb3.Controls.Add(this._lblMaximumBlackPercent);
          this._gb3.Controls.Add(this._lblMinimumBlackPercent);
          this._gb3.Location = new System.Drawing.Point(12, 161);
          this._gb3.Name = "_gb3";
          this._gb3.Size = new System.Drawing.Size(259, 79);
          this._gb3.TabIndex = 4;
          this._gb3.TabStop = false;
          this._gb3.Text = "Opacity";
          // 
          // _tbMaximumBlackPercent
          // 
          this._tbMaximumBlackPercent.Location = new System.Drawing.Point(133, 43);
          this._tbMaximumBlackPercent.Name = "_tbMaximumBlackPercent";
          this._tbMaximumBlackPercent.Size = new System.Drawing.Size(60, 20);
          this._tbMaximumBlackPercent.TabIndex = 9;
          this._tbMaximumBlackPercent.TextChanged += new System.EventHandler(this._tbMaximumBlackPercent_TextChanged);
          // 
          // _tbMinimumBlackPercent
          // 
          this._tbMinimumBlackPercent.Location = new System.Drawing.Point(133, 17);
          this._tbMinimumBlackPercent.Name = "_tbMinimumBlackPercent";
          this._tbMinimumBlackPercent.Size = new System.Drawing.Size(60, 20);
          this._tbMinimumBlackPercent.TabIndex = 8;
          this._tbMinimumBlackPercent.TextChanged += new System.EventHandler(this._tbMinimumBlackPercent_TextChanged);
          // 
          // _lblMaximumBlackPercent
          // 
          this._lblMaximumBlackPercent.AutoSize = true;
          this._lblMaximumBlackPercent.Location = new System.Drawing.Point(9, 50);
          this._lblMaximumBlackPercent.Name = "_lblMaximumBlackPercent";
          this._lblMaximumBlackPercent.Size = new System.Drawing.Size(121, 13);
          this._lblMaximumBlackPercent.TabIndex = 9;
          this._lblMaximumBlackPercent.Text = "Maximum Black Percent";
          // 
          // _lblMinimumBlackPercent
          // 
          this._lblMinimumBlackPercent.AutoSize = true;
          this._lblMinimumBlackPercent.Location = new System.Drawing.Point(9, 24);
          this._lblMinimumBlackPercent.Name = "_lblMinimumBlackPercent";
          this._lblMinimumBlackPercent.Size = new System.Drawing.Size(118, 13);
          this._lblMinimumBlackPercent.TabIndex = 8;
          this._lblMinimumBlackPercent.Text = "Minimum Black Percent";
          // 
          // InvertedTextDialog
          // 
          this.AcceptButton = this._btnOk;
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._btnCancel;
          this.ClientSize = new System.Drawing.Size(359, 251);
          this.Controls.Add(this._gb3);
          this.Controls.Add(this._gb2);
          this.Controls.Add(this._gb1);
          this.Controls.Add(this._btnCancel);
          this.Controls.Add(this._btnOk);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "InvertedTextDialog";
          this.Text = "Inverted Text";
          this._gb1.ResumeLayout(false);
          this._gb1.PerformLayout();
          this._gb2.ResumeLayout(false);
          this._gb2.PerformLayout();
          this._gb3.ResumeLayout(false);
          this._gb3.PerformLayout();
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.GroupBox _gb1;
      private System.Windows.Forms.TextBox _tbDPI;
      private System.Windows.Forms.GroupBox _gb2;
      private System.Windows.Forms.GroupBox _gb3;
      private System.Windows.Forms.CheckBox _cbUseDPI;
      private System.Windows.Forms.Label _lbl4;
      private System.Windows.Forms.Label _lbl3;
      private System.Windows.Forms.TextBox _tbMinimumInvertHeight;
      private System.Windows.Forms.Label _lblMinimumInvertHeight;
      private System.Windows.Forms.TextBox _tbMinimumInvertWidth;
      private System.Windows.Forms.Label _lblMinimumInvertWidth;
      private System.Windows.Forms.Label _lblMaximumBlackPercent;
      private System.Windows.Forms.Label _lblMinimumBlackPercent;
      private System.Windows.Forms.TextBox _tbMaximumBlackPercent;
      private System.Windows.Forms.TextBox _tbMinimumBlackPercent;
   }
}