namespace MedicalViewerDemo
{
    partial class AdaptiveContrastDialog
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
         this._numAmount = new System.Windows.Forms.NumericUpDown();
         this._numSize = new System.Windows.Forms.NumericUpDown();
         this._lblRadius = new System.Windows.Forms.Label();
         this._lblAmount = new System.Windows.Forms.Label();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._lblColorSpace = new System.Windows.Forms.Label();
         this._cbType = new System.Windows.Forms.ComboBox();
         this._btnApply = new System.Windows.Forms.Button();
         this._gbOptions.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numAmount)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numSize)).BeginInit();
         this.SuspendLayout();
         // 
         // _gbOptions
         // 
         this._gbOptions.Controls.Add(this._numAmount);
         this._gbOptions.Controls.Add(this._numSize);
         this._gbOptions.Controls.Add(this._lblRadius);
         this._gbOptions.Controls.Add(this._lblAmount);
         this._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._gbOptions.Location = new System.Drawing.Point(9, 10);
         this._gbOptions.Margin = new System.Windows.Forms.Padding(2);
         this._gbOptions.Name = "_gbOptions";
         this._gbOptions.Padding = new System.Windows.Forms.Padding(2);
         this._gbOptions.Size = new System.Drawing.Size(208, 81);
         this._gbOptions.TabIndex = 0;
         this._gbOptions.TabStop = false;
         this._gbOptions.Text = "Parameters";
         // 
         // _numAmount
         // 
         this._numAmount.Location = new System.Drawing.Point(83, 48);
         this._numAmount.Margin = new System.Windows.Forms.Padding(2);
         this._numAmount.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
         this._numAmount.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
         this._numAmount.Name = "_numAmount";
         this._numAmount.Size = new System.Drawing.Size(109, 20);
         this._numAmount.TabIndex = 11;
         this._numAmount.Value = new decimal(new int[] {
            255,
            0,
            0,
            0});
         // 
         // _numSize
         // 
         this._numSize.Location = new System.Drawing.Point(83, 18);
         this._numSize.Margin = new System.Windows.Forms.Padding(2);
         this._numSize.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
         this._numSize.Name = "_numSize";
         this._numSize.Size = new System.Drawing.Size(109, 20);
         this._numSize.TabIndex = 10;
         this._numSize.Value = new decimal(new int[] {
            9,
            0,
            0,
            0});
         // 
         // _lblRadius
         // 
         this._lblRadius.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblRadius.Location = new System.Drawing.Point(14, 48);
         this._lblRadius.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this._lblRadius.Name = "_lblRadius";
         this._lblRadius.Size = new System.Drawing.Size(65, 22);
         this._lblRadius.TabIndex = 2;
         this._lblRadius.Text = "Amount:";
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
         this._lblAmount.Text = "Size:";
         this._lblAmount.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnCancel.Location = new System.Drawing.Point(235, 98);
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
         this._btnOk.Location = new System.Drawing.Point(235, 55);
         this._btnOk.Margin = new System.Windows.Forms.Padding(2);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(68, 22);
         this._btnOk.TabIndex = 1;
         this._btnOk.Text = "OK";
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _lblColorSpace
         // 
         this._lblColorSpace.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblColorSpace.Location = new System.Drawing.Point(23, 104);
         this._lblColorSpace.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this._lblColorSpace.Name = "_lblColorSpace";
         this._lblColorSpace.Size = new System.Drawing.Size(65, 22);
         this._lblColorSpace.TabIndex = 10;
         this._lblColorSpace.Text = "Type:";
         this._lblColorSpace.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _cbType
         // 
         this._cbType.FormattingEnabled = true;
         this._cbType.Items.AddRange(new object[] {
            "Exponential",
            "Linear"});
         this._cbType.Location = new System.Drawing.Point(80, 102);
         this._cbType.Name = "_cbType";
         this._cbType.Size = new System.Drawing.Size(121, 21);
         this._cbType.TabIndex = 12;
         // 
         // _btnApply
         // 
         this._btnApply.Location = new System.Drawing.Point(235, 12);
         this._btnApply.Name = "_btnApply";
         this._btnApply.Size = new System.Drawing.Size(68, 22);
         this._btnApply.TabIndex = 13;
         this._btnApply.Text = "Apply";
         this._btnApply.UseVisualStyleBackColor = true;
         this._btnApply.Click += new System.EventHandler(this._btnApply_Click);
         // 
         // AdaptiveContrastDialog
         // 
         this.AcceptButton = this._btnOk;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(315, 135);
         this.Controls.Add(this._btnApply);
         this.Controls.Add(this._cbType);
         this.Controls.Add(this._lblColorSpace);
         this.Controls.Add(this._gbOptions);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Margin = new System.Windows.Forms.Padding(2);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "AdaptiveContrastDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Adaptive Contrast";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdaptiveContrastDialog_FormClosing);
         this._gbOptions.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this._numAmount)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numSize)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gbOptions;
      private System.Windows.Forms.Label _lblRadius;
      private System.Windows.Forms.Label _lblAmount;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.NumericUpDown _numAmount;
      private System.Windows.Forms.NumericUpDown _numSize;
      private System.Windows.Forms.Label _lblColorSpace;
      private System.Windows.Forms.ComboBox _cbType;
      private System.Windows.Forms.Button _btnApply;
   }
}