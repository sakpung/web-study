namespace DicomDemo
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
         this._cbColorSpace = new System.Windows.Forms.ComboBox();
         this._lblColorSpace = new System.Windows.Forms.Label();
         this._numThreshold = new System.Windows.Forms.NumericUpDown();
         this._lblThreshold = new System.Windows.Forms.Label();
         this._numRadius = new System.Windows.Forms.NumericUpDown();
         this._lblRadius = new System.Windows.Forms.Label();
         this._numAmount = new System.Windows.Forms.NumericUpDown();
         this._lblAmount = new System.Windows.Forms.Label();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._gbOptions.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numThreshold)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numRadius)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numAmount)).BeginInit();
         this.SuspendLayout();
         // 
         // _gbOptions
         // 
         this._gbOptions.Controls.Add(this._cbColorSpace);
         this._gbOptions.Controls.Add(this._lblColorSpace);
         this._gbOptions.Controls.Add(this._numThreshold);
         this._gbOptions.Controls.Add(this._lblThreshold);
         this._gbOptions.Controls.Add(this._numRadius);
         this._gbOptions.Controls.Add(this._lblRadius);
         this._gbOptions.Controls.Add(this._numAmount);
         this._gbOptions.Controls.Add(this._lblAmount);
         this._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._gbOptions.Location = new System.Drawing.Point(12, 12);
         this._gbOptions.Name = "_gbOptions";
         this._gbOptions.Size = new System.Drawing.Size(278, 166);
         this._gbOptions.TabIndex = 0;
         this._gbOptions.TabStop = false;
         // 
         // _cbColorSpace
         // 
         this._cbColorSpace.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbColorSpace.Location = new System.Drawing.Point(115, 129);
         this._cbColorSpace.Name = "_cbColorSpace";
         this._cbColorSpace.Size = new System.Drawing.Size(145, 24);
         this._cbColorSpace.TabIndex = 7;
         // 
         // _lblColorSpace
         // 
         this._lblColorSpace.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblColorSpace.Location = new System.Drawing.Point(19, 129);
         this._lblColorSpace.Name = "_lblColorSpace";
         this._lblColorSpace.Size = new System.Drawing.Size(87, 27);
         this._lblColorSpace.TabIndex = 6;
         this._lblColorSpace.Text = "Color Space";
         this._lblColorSpace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _numThreshold
         // 
         this._numThreshold.Location = new System.Drawing.Point(115, 92);
         this._numThreshold.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
         this._numThreshold.Name = "_numThreshold";
         this._numThreshold.Size = new System.Drawing.Size(144, 22);
         this._numThreshold.TabIndex = 5;
         this._numThreshold.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numThreshold.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _lblThreshold
         // 
         this._lblThreshold.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblThreshold.Location = new System.Drawing.Point(19, 92);
         this._lblThreshold.Name = "_lblThreshold";
         this._lblThreshold.Size = new System.Drawing.Size(87, 27);
         this._lblThreshold.TabIndex = 4;
         this._lblThreshold.Text = "Threshold";
         this._lblThreshold.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _numRadius
         // 
         this._numRadius.Location = new System.Drawing.Point(115, 55);
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
         this._numRadius.Size = new System.Drawing.Size(144, 22);
         this._numRadius.TabIndex = 3;
         this._numRadius.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numRadius.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _lblRadius
         // 
         this._lblRadius.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblRadius.Location = new System.Drawing.Point(19, 55);
         this._lblRadius.Name = "_lblRadius";
         this._lblRadius.Size = new System.Drawing.Size(87, 27);
         this._lblRadius.TabIndex = 2;
         this._lblRadius.Text = "Radius";
         this._lblRadius.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _numAmount
         // 
         this._numAmount.Location = new System.Drawing.Point(115, 18);
         this._numAmount.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
         this._numAmount.Name = "_numAmount";
         this._numAmount.Size = new System.Drawing.Size(144, 22);
         this._numAmount.TabIndex = 1;
         this._numAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numAmount.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _lblAmount
         // 
         this._lblAmount.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblAmount.Location = new System.Drawing.Point(19, 18);
         this._lblAmount.Name = "_lblAmount";
         this._lblAmount.Size = new System.Drawing.Size(87, 27);
         this._lblAmount.TabIndex = 0;
         this._lblAmount.Text = "Amount";
         this._lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnCancel.Location = new System.Drawing.Point(319, 58);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(90, 27);
         this._btnCancel.TabIndex = 2;
         this._btnCancel.Text = "Cancel";
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnOk.Location = new System.Drawing.Point(319, 21);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(90, 27);
         this._btnOk.TabIndex = 1;
         this._btnOk.Text = "OK";
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // UnsharpMaskDialog
         // 
         this.AcceptButton = this._btnOk;
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(420, 194);
         this.Controls.Add(this._gbOptions);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "UnsharpMaskDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Unsharp Mask";
         this.Load += new System.EventHandler(this.UnsharpMaskDialog_Load);
         this._gbOptions.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this._numThreshold)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numRadius)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numAmount)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gbOptions;
      private System.Windows.Forms.ComboBox _cbColorSpace;
      private System.Windows.Forms.Label _lblColorSpace;
      private System.Windows.Forms.NumericUpDown _numThreshold;
      private System.Windows.Forms.Label _lblThreshold;
      private System.Windows.Forms.NumericUpDown _numRadius;
      private System.Windows.Forms.Label _lblRadius;
      private System.Windows.Forms.NumericUpDown _numAmount;
      private System.Windows.Forms.Label _lblAmount;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
   }
}