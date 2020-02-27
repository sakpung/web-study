namespace GrayScaleDemo
{
   partial class CLAHEDialog
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
         this._gbParamerters = new System.Windows.Forms.GroupBox();
         this._cmbBinsNumber = new System.Windows.Forms.ComboBox();
         this._numClipLimit = new System.Windows.Forms.NumericUpDown();
         this._numTiles = new System.Windows.Forms.NumericUpDown();
         this._numAlpha = new System.Windows.Forms.NumericUpDown();
         this._cmbFlags = new System.Windows.Forms.ComboBox();
         this.label5 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.label1 = new System.Windows.Forms.Label();
         this._btnOK = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._gbParamerters.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numClipLimit)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numTiles)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numAlpha)).BeginInit();
         this.SuspendLayout();
         // 
         // _gbParamerters
         // 
         this._gbParamerters.Controls.Add(this._cmbBinsNumber);
         this._gbParamerters.Controls.Add(this._numClipLimit);
         this._gbParamerters.Controls.Add(this._numTiles);
         this._gbParamerters.Controls.Add(this._numAlpha);
         this._gbParamerters.Controls.Add(this._cmbFlags);
         this._gbParamerters.Controls.Add(this.label5);
         this._gbParamerters.Controls.Add(this.label4);
         this._gbParamerters.Controls.Add(this.label3);
         this._gbParamerters.Controls.Add(this.label2);
         this._gbParamerters.Controls.Add(this.label1);
         this._gbParamerters.Location = new System.Drawing.Point(9, 7);
         this._gbParamerters.Name = "_gbParamerters";
         this._gbParamerters.Size = new System.Drawing.Size(246, 184);
         this._gbParamerters.TabIndex = 0;
         this._gbParamerters.TabStop = false;
         this._gbParamerters.Text = "Parameters";
         // 
         // _cmbBinsNumber
         // 
         this._cmbBinsNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbBinsNumber.FormattingEnabled = true;
         this._cmbBinsNumber.Items.AddRange(new object[] {
            "2",
            "4",
            "8",
            "16",
            "32",
            "64",
            "128",
            "256",
            "512",
            "1024"});
         this._cmbBinsNumber.Location = new System.Drawing.Point(125, 143);
         this._cmbBinsNumber.Name = "_cmbBinsNumber";
         this._cmbBinsNumber.Size = new System.Drawing.Size(103, 21);
         this._cmbBinsNumber.TabIndex = 9;
         // 
         // _numClipLimit
         // 
         this._numClipLimit.DecimalPlaces = 3;
         this._numClipLimit.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
         this._numClipLimit.Location = new System.Drawing.Point(125, 114);
         this._numClipLimit.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numClipLimit.Name = "_numClipLimit";
         this._numClipLimit.Size = new System.Drawing.Size(103, 20);
         this._numClipLimit.TabIndex = 8;
         // 
         // _numTiles
         // 
         this._numTiles.Location = new System.Drawing.Point(125, 85);
         this._numTiles.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
         this._numTiles.Name = "_numTiles";
         this._numTiles.Size = new System.Drawing.Size(103, 20);
         this._numTiles.TabIndex = 7;
         // 
         // _numAlpha
         // 
         this._numAlpha.DecimalPlaces = 2;
         this._numAlpha.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
         this._numAlpha.Location = new System.Drawing.Point(125, 56);
         this._numAlpha.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numAlpha.Name = "_numAlpha";
         this._numAlpha.Size = new System.Drawing.Size(103, 20);
         this._numAlpha.TabIndex = 6;
         // 
         // _cmbFlags
         // 
         this._cmbFlags.FormattingEnabled = true;
         this._cmbFlags.Items.AddRange(new object[] {
            "Normal",
            "Exponential",
            "Raylieh",
            "Sigmoid"});
         this._cmbFlags.Location = new System.Drawing.Point(125, 26);
         this._cmbFlags.Name = "_cmbFlags";
         this._cmbFlags.Size = new System.Drawing.Size(103, 21);
         this._cmbFlags.TabIndex = 5;
         this._cmbFlags.SelectedIndexChanged += new System.EventHandler(this._cmbFlags_SelectedIndexChanged);
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(22, 149);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(67, 13);
         this.label5.TabIndex = 4;
         this.label5.Text = "Bins Number";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(22, 119);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(48, 13);
         this.label4.TabIndex = 3;
         this.label4.Text = "Clip Limit";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(22, 89);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(69, 13);
         this.label3.TabIndex = 2;
         this.label3.Text = "Tiles Number";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(22, 59);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(34, 13);
         this.label2.TabIndex = 1;
         this.label2.Text = "Alpha";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(22, 29);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(32, 13);
         this.label1.TabIndex = 0;
         this.label1.Text = "Flags";
         // 
         // _btnOK
         // 
         this._btnOK.Location = new System.Drawing.Point(48, 197);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(75, 23);
         this._btnOK.TabIndex = 1;
         this._btnOK.Text = "OK";
         this._btnOK.UseVisualStyleBackColor = true;
         this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.Location = new System.Drawing.Point(134, 197);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(75, 23);
         this._btnCancel.TabIndex = 2;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
         // 
         // CLAHEDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(265, 240);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOK);
         this.Controls.Add(this._gbParamerters);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "CLAHEDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "CLAHE";
         this.Load += new System.EventHandler(this.CLAHEDialog_Load);
         this._gbParamerters.ResumeLayout(false);
         this._gbParamerters.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numClipLimit)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numTiles)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numAlpha)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gbParamerters;
      private System.Windows.Forms.ComboBox _cmbBinsNumber;
      private System.Windows.Forms.NumericUpDown _numClipLimit;
      private System.Windows.Forms.NumericUpDown _numTiles;
      private System.Windows.Forms.NumericUpDown _numAlpha;
      private System.Windows.Forms.ComboBox _cmbFlags;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Button _btnOK;
      private System.Windows.Forms.Button _btnCancel;
   }
}