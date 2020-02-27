namespace MedicalViewerDemo
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
         this._btnOK = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this._cbBinsNumber = new System.Windows.Forms.ComboBox();
         this.label5 = new System.Windows.Forms.Label();
         this._numClipLimit = new System.Windows.Forms.NumericUpDown();
         this.label4 = new System.Windows.Forms.Label();
         this._numTilesNumber = new System.Windows.Forms.NumericUpDown();
         this.label3 = new System.Windows.Forms.Label();
         this._numAlpha = new System.Windows.Forms.NumericUpDown();
         this._cbFlags = new System.Windows.Forms.ComboBox();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this._btnApply = new System.Windows.Forms.Button();
         this.groupBox1.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numClipLimit)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numTilesNumber)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numAlpha)).BeginInit();
         this.SuspendLayout();
         // 
         // _btnOK
         // 
         this._btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOK.Location = new System.Drawing.Point(108, 228);
         this._btnOK.Name = "_btnOK";
         this._btnOK.Size = new System.Drawing.Size(75, 23);
         this._btnOK.TabIndex = 0;
         this._btnOK.Text = "OK";
         this._btnOK.UseVisualStyleBackColor = true;
         this._btnOK.Click += new System.EventHandler(this._btnOK_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.Location = new System.Drawing.Point(204, 228);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(75, 23);
         this._btnCancel.TabIndex = 1;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this._cbBinsNumber);
         this.groupBox1.Controls.Add(this.label5);
         this.groupBox1.Controls.Add(this._numClipLimit);
         this.groupBox1.Controls.Add(this.label4);
         this.groupBox1.Controls.Add(this._numTilesNumber);
         this.groupBox1.Controls.Add(this.label3);
         this.groupBox1.Controls.Add(this._numAlpha);
         this.groupBox1.Controls.Add(this._cbFlags);
         this.groupBox1.Controls.Add(this.label1);
         this.groupBox1.Controls.Add(this.label2);
         this.groupBox1.Location = new System.Drawing.Point(12, 12);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(268, 202);
         this.groupBox1.TabIndex = 2;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "Parameters";
         // 
         // _cbBinsNumber
         // 
         this._cbBinsNumber.AutoCompleteCustomSource.AddRange(new string[] {
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
         this._cbBinsNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbBinsNumber.FormattingEnabled = true;
         this._cbBinsNumber.Items.AddRange(new object[] {
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
         this._cbBinsNumber.Location = new System.Drawing.Point(130, 163);
         this._cbBinsNumber.Name = "_cbBinsNumber";
         this._cbBinsNumber.Size = new System.Drawing.Size(121, 21);
         this._cbBinsNumber.TabIndex = 12;
         this._cbBinsNumber.SelectedIndexChanged += new System.EventHandler(this._cbBinsNumber_SelectedIndexChanged);
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(25, 166);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(66, 13);
         this.label5.TabIndex = 11;
         this.label5.Text = "Bins Number";
         // 
         // _numClipLimit
         // 
         this._numClipLimit.DecimalPlaces = 3;
         this._numClipLimit.Increment = new decimal(new int[] {
            5,
            0,
            0,
            196608});
         this._numClipLimit.Location = new System.Drawing.Point(131, 130);
         this._numClipLimit.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numClipLimit.Name = "_numClipLimit";
         this._numClipLimit.Size = new System.Drawing.Size(120, 20);
         this._numClipLimit.TabIndex = 10;
         this._numClipLimit.Value = new decimal(new int[] {
            8,
            0,
            0,
            131072});
         this._numClipLimit.ValueChanged += new System.EventHandler(this._numClipLimit_ValueChanged);
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(25, 133);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(48, 13);
         this.label4.TabIndex = 9;
         this.label4.Text = "Clip Limit";
         // 
         // _numTilesNumber
         // 
         this._numTilesNumber.Location = new System.Drawing.Point(131, 97);
         this._numTilesNumber.Maximum = new decimal(new int[] {
            60,
            0,
            0,
            0});
         this._numTilesNumber.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numTilesNumber.Name = "_numTilesNumber";
         this._numTilesNumber.Size = new System.Drawing.Size(120, 20);
         this._numTilesNumber.TabIndex = 8;
         this._numTilesNumber.Value = new decimal(new int[] {
            25,
            0,
            0,
            0});
         this._numTilesNumber.ValueChanged += new System.EventHandler(this._numTilesNumber_ValueChanged);
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(25, 100);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(68, 13);
         this.label3.TabIndex = 7;
         this.label3.Text = "Tiles Number";
         // 
         // _numAlpha
         // 
         this._numAlpha.DecimalPlaces = 2;
         this._numAlpha.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
         this._numAlpha.Location = new System.Drawing.Point(131, 64);
         this._numAlpha.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numAlpha.Name = "_numAlpha";
         this._numAlpha.Size = new System.Drawing.Size(120, 20);
         this._numAlpha.TabIndex = 6;
         this._numAlpha.Value = new decimal(new int[] {
            65,
            0,
            0,
            131072});
         this._numAlpha.ValueChanged += new System.EventHandler(this._numAlpha_ValueChanged);
         // 
         // _cbFlags
         // 
         this._cbFlags.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbFlags.FormattingEnabled = true;
         this._cbFlags.Items.AddRange(new object[] {
            "Normal",
            "Exponential",
            "Raylieh",
            "Sigmoid"});
         this._cbFlags.Location = new System.Drawing.Point(131, 21);
         this._cbFlags.Name = "_cbFlags";
         this._cbFlags.Size = new System.Drawing.Size(121, 21);
         this._cbFlags.TabIndex = 5;
         this._cbFlags.SelectedIndexChanged += new System.EventHandler(this._cbFlags_SelectedIndexChanged);
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(25, 24);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(32, 13);
         this.label1.TabIndex = 3;
         this.label1.Text = "Flags";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(25, 67);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(34, 13);
         this.label2.TabIndex = 4;
         this.label2.Text = "Alpha";
         // 
         // _btnApply
         // 
         this._btnApply.Location = new System.Drawing.Point(12, 228);
         this._btnApply.Name = "_btnApply";
         this._btnApply.Size = new System.Drawing.Size(75, 23);
         this._btnApply.TabIndex = 3;
         this._btnApply.Text = "Apply";
         this._btnApply.UseVisualStyleBackColor = true;
         this._btnApply.Click += new System.EventHandler(this._btnApply_Click);
         // 
         // CLAHEDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(292, 265);
         this.Controls.Add(this._btnApply);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOK);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "CLAHEDialog";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "CLAHE Dialog";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CLAHEDialog_FormClosing);
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numClipLimit)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numTilesNumber)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numAlpha)).EndInit();
         this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btnOK;
        private System.Windows.Forms.Button _btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown _numAlpha;
        private System.Windows.Forms.ComboBox _cbFlags;
        private System.Windows.Forms.Button _btnApply;
        private System.Windows.Forms.NumericUpDown _numTilesNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox _cbBinsNumber;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown _numClipLimit;
        private System.Windows.Forms.Label label4;
    }
}