namespace MedicalViewerDemo
{
    partial class UnsharpMaskDialog
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
         this._lblColorSpace = new System.Windows.Forms.Label();
         this._cbColorSpace = new System.Windows.Forms.ComboBox();
         this._numRadius = new System.Windows.Forms.NumericUpDown();
         this._numAmount = new System.Windows.Forms.NumericUpDown();
         this._numThreshold = new System.Windows.Forms.NumericUpDown();
         this._lblThreshold = new System.Windows.Forms.Label();
         this._lblRadius = new System.Windows.Forms.Label();
         this._lblAmount = new System.Windows.Forms.Label();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._btnApply = new System.Windows.Forms.Button();
         this._gbOptions.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numRadius)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numAmount)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numThreshold)).BeginInit();
         this.SuspendLayout();
         // 
         // _gbOptions
         // 
         this._gbOptions.Controls.Add(this._lblColorSpace);
         this._gbOptions.Controls.Add(this._cbColorSpace);
         this._gbOptions.Controls.Add(this._numRadius);
         this._gbOptions.Controls.Add(this._numAmount);
         this._gbOptions.Controls.Add(this._numThreshold);
         this._gbOptions.Controls.Add(this._lblThreshold);
         this._gbOptions.Controls.Add(this._lblRadius);
         this._gbOptions.Controls.Add(this._lblAmount);
         this._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._gbOptions.Location = new System.Drawing.Point(9, 10);
         this._gbOptions.Margin = new System.Windows.Forms.Padding(2);
         this._gbOptions.Name = "_gbOptions";
         this._gbOptions.Padding = new System.Windows.Forms.Padding(2);
         this._gbOptions.Size = new System.Drawing.Size(205, 137);
         this._gbOptions.TabIndex = 0;
         this._gbOptions.TabStop = false;
         this._gbOptions.Text = "Parameters";
         // 
         // _lblColorSpace
         // 
         this._lblColorSpace.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblColorSpace.Location = new System.Drawing.Point(14, 109);
         this._lblColorSpace.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this._lblColorSpace.Name = "_lblColorSpace";
         this._lblColorSpace.Size = new System.Drawing.Size(65, 22);
         this._lblColorSpace.TabIndex = 6;
         this._lblColorSpace.Text = "Color Space:";
         this._lblColorSpace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _cbColorSpace
         // 
         this._cbColorSpace.FormattingEnabled = true;
         this._cbColorSpace.Items.AddRange(new object[] {
            "RGB color space",
            "YUV color space"});
         this._cbColorSpace.Location = new System.Drawing.Point(86, 109);
         this._cbColorSpace.Name = "_cbColorSpace";
         this._cbColorSpace.Size = new System.Drawing.Size(107, 21);
         this._cbColorSpace.TabIndex = 9;
         // 
         // _numRadius
         // 
         this._numRadius.Location = new System.Drawing.Point(86, 45);
         this._numRadius.Margin = new System.Windows.Forms.Padding(2);
         this._numRadius.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
         this._numRadius.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numRadius.Name = "_numRadius";
         this._numRadius.Size = new System.Drawing.Size(109, 20);
         this._numRadius.TabIndex = 8;
         this._numRadius.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
         // 
         // _numAmount
         // 
         this._numAmount.Location = new System.Drawing.Point(86, 15);
         this._numAmount.Margin = new System.Windows.Forms.Padding(2);
         this._numAmount.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
         this._numAmount.Name = "_numAmount";
         this._numAmount.Size = new System.Drawing.Size(109, 20);
         this._numAmount.TabIndex = 7;
         this._numAmount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
         // 
         // _numThreshold
         // 
         this._numThreshold.Location = new System.Drawing.Point(86, 75);
         this._numThreshold.Margin = new System.Windows.Forms.Padding(2);
         this._numThreshold.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
         this._numThreshold.Name = "_numThreshold";
         this._numThreshold.Size = new System.Drawing.Size(109, 20);
         this._numThreshold.TabIndex = 5;
         this._numThreshold.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _lblThreshold
         // 
         this._lblThreshold.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblThreshold.Location = new System.Drawing.Point(14, 75);
         this._lblThreshold.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this._lblThreshold.Name = "_lblThreshold";
         this._lblThreshold.Size = new System.Drawing.Size(65, 22);
         this._lblThreshold.TabIndex = 4;
         this._lblThreshold.Text = "Threshold:";
         this._lblThreshold.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _lblRadius
         // 
         this._lblRadius.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblRadius.Location = new System.Drawing.Point(14, 46);
         this._lblRadius.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this._lblRadius.Name = "_lblRadius";
         this._lblRadius.Size = new System.Drawing.Size(65, 22);
         this._lblRadius.TabIndex = 2;
         this._lblRadius.Text = "Radius:";
         this._lblRadius.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _lblAmount
         // 
         this._lblAmount.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblAmount.Location = new System.Drawing.Point(14, 18);
         this._lblAmount.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this._lblAmount.Name = "_lblAmount";
         this._lblAmount.Size = new System.Drawing.Size(65, 22);
         this._lblAmount.TabIndex = 0;
         this._lblAmount.Text = "Amount:";
         this._lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnCancel.Location = new System.Drawing.Point(239, 84);
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
         this._btnOk.Location = new System.Drawing.Point(239, 48);
         this._btnOk.Margin = new System.Windows.Forms.Padding(2);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(68, 22);
         this._btnOk.TabIndex = 1;
         this._btnOk.Text = "OK";
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _btnApply
         // 
         this._btnApply.Location = new System.Drawing.Point(239, 12);
         this._btnApply.Name = "_btnApply";
         this._btnApply.Size = new System.Drawing.Size(68, 22);
         this._btnApply.TabIndex = 3;
         this._btnApply.Text = "Apply";
         this._btnApply.UseVisualStyleBackColor = true;
         this._btnApply.Click += new System.EventHandler(this._btnApply_Click);
         // 
         // UnsharpMaskDialog
         // 
         this.AcceptButton = this._btnOk;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(315, 158);
         this.Controls.Add(this._btnApply);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._gbOptions);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Margin = new System.Windows.Forms.Padding(2);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "UnsharpMaskDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Unsharp Mask";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.UnsharpMaskDialog_FormClosing);
         this._gbOptions.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this._numRadius)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numAmount)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numThreshold)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gbOptions;
      private System.Windows.Forms.Label _lblColorSpace;
      private System.Windows.Forms.NumericUpDown _numThreshold;
      private System.Windows.Forms.Label _lblThreshold;
      private System.Windows.Forms.Label _lblRadius;
      private System.Windows.Forms.Label _lblAmount;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.ComboBox _cbColorSpace;
      private System.Windows.Forms.NumericUpDown _numRadius;
      private System.Windows.Forms.NumericUpDown _numAmount;
      private System.Windows.Forms.Button _btnApply;
   }
}