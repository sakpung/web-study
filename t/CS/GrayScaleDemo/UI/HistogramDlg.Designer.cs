namespace GrayScaleDemo
{
    partial class HistogramDlg
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
           this._btnOk = new System.Windows.Forms.Button();
           this._pnlHistogram = new System.Windows.Forms.Panel();
           this._lblLevel = new System.Windows.Forms.Label();
           this._lblCount = new System.Windows.Forms.Label();
           this._lblMax = new System.Windows.Forms.Label();
           this._lblMin = new System.Windows.Forms.Label();
           this.label1 = new System.Windows.Forms.Label();
           this.groupBox1 = new System.Windows.Forms.GroupBox();
           this._cmbChanel = new System.Windows.Forms.ComboBox();
           this.label4 = new System.Windows.Forms.Label();
           this._gbGrayScaleRange = new System.Windows.Forms.GroupBox();
           this._numRangeMin = new System.Windows.Forms.NumericUpDown();
           this._numRangeMax = new System.Windows.Forms.NumericUpDown();
           this.label3 = new System.Windows.Forms.Label();
           this._btnDraw = new System.Windows.Forms.Button();
           this.label2 = new System.Windows.Forms.Label();
           this._numClipping = new System.Windows.Forms.NumericUpDown();
           this._lblClipping = new System.Windows.Forms.Label();
           this._lblPercentil = new System.Windows.Forms.Label();
           this._lblMedian = new System.Windows.Forms.Label();
           this._lblMean = new System.Windows.Forms.Label();
           this._lblToltalPixels = new System.Windows.Forms.Label();
           this.groupBox1.SuspendLayout();
           this._gbGrayScaleRange.SuspendLayout();
           ((System.ComponentModel.ISupportInitialize)(this._numRangeMin)).BeginInit();
           ((System.ComponentModel.ISupportInitialize)(this._numRangeMax)).BeginInit();
           ((System.ComponentModel.ISupportInitialize)(this._numClipping)).BeginInit();
           this.SuspendLayout();
           // 
           // _btnOk
           // 
           this._btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this._btnOk.Location = new System.Drawing.Point(220, 121);
           this._btnOk.Name = "_btnOk";
           this._btnOk.Size = new System.Drawing.Size(75, 27);
           this._btnOk.TabIndex = 0;
           this._btnOk.Text = "OK";
           this._btnOk.UseVisualStyleBackColor = true;
           this._btnOk.Click += new System.EventHandler(this._btnCancel_Click);
           // 
           // _pnlHistogram
           // 
           this._pnlHistogram.BackColor = System.Drawing.SystemColors.Control;
           this._pnlHistogram.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
           this._pnlHistogram.Location = new System.Drawing.Point(16, 19);
           this._pnlHistogram.Name = "_pnlHistogram";
           this._pnlHistogram.Size = new System.Drawing.Size(500, 200);
           this._pnlHistogram.TabIndex = 1;
           this._pnlHistogram.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
           // 
           // _lblLevel
           // 
           this._lblLevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this._lblLevel.Location = new System.Drawing.Point(104, 16);
           this._lblLevel.Name = "_lblLevel";
           this._lblLevel.Size = new System.Drawing.Size(123, 23);
           this._lblLevel.TabIndex = 2;
           this._lblLevel.Text = "Level";
           // 
           // _lblCount
           // 
           this._lblCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this._lblCount.Location = new System.Drawing.Point(104, 39);
           this._lblCount.Name = "_lblCount";
           this._lblCount.Size = new System.Drawing.Size(123, 23);
           this._lblCount.TabIndex = 4;
           this._lblCount.Text = "Count";
           // 
           // _lblMax
           // 
           this._lblMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this._lblMax.Location = new System.Drawing.Point(10, 16);
           this._lblMax.Name = "_lblMax";
           this._lblMax.Size = new System.Drawing.Size(89, 23);
           this._lblMax.TabIndex = 5;
           this._lblMax.Text = "Max";
           // 
           // _lblMin
           // 
           this._lblMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this._lblMin.Location = new System.Drawing.Point(10, 39);
           this._lblMin.Name = "_lblMin";
           this._lblMin.Size = new System.Drawing.Size(89, 23);
           this._lblMin.TabIndex = 6;
           this._lblMin.Text = "Min";
           // 
           // label1
           // 
           this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this.label1.Location = new System.Drawing.Point(56, 15);
           this.label1.Name = "label1";
           this.label1.Size = new System.Drawing.Size(45, 20);
           this.label1.TabIndex = 7;
           this.label1.Text = "Range";
           // 
           // groupBox1
           // 
           this.groupBox1.Controls.Add(this._cmbChanel);
           this.groupBox1.Controls.Add(this.label4);
           this.groupBox1.Controls.Add(this._btnOk);
           this.groupBox1.Controls.Add(this._gbGrayScaleRange);
           this.groupBox1.Controls.Add(this._numClipping);
           this.groupBox1.Controls.Add(this._lblClipping);
           this.groupBox1.Controls.Add(this._lblPercentil);
           this.groupBox1.Controls.Add(this._lblMedian);
           this.groupBox1.Controls.Add(this._lblMean);
           this.groupBox1.Controls.Add(this._lblToltalPixels);
           this.groupBox1.Controls.Add(this._lblMin);
           this.groupBox1.Controls.Add(this._lblMax);
           this.groupBox1.Controls.Add(this._lblCount);
           this.groupBox1.Controls.Add(this._lblLevel);
           this.groupBox1.Location = new System.Drawing.Point(9, 225);
           this.groupBox1.Name = "groupBox1";
           this.groupBox1.Size = new System.Drawing.Size(514, 157);
           this.groupBox1.TabIndex = 12;
           this.groupBox1.TabStop = false;
           // 
           // _cmbChanel
           // 
           this._cmbChanel.FormattingEnabled = true;
           this._cmbChanel.Items.AddRange(new object[] {
            "Master",
            "Red",
            "Green",
            "Blue"});
           this._cmbChanel.Location = new System.Drawing.Point(445, 69);
           this._cmbChanel.Name = "_cmbChanel";
           this._cmbChanel.Size = new System.Drawing.Size(63, 21);
           this._cmbChanel.TabIndex = 24;
           this._cmbChanel.SelectedIndexChanged += new System.EventHandler(this._cmbChanel_SelectedIndexChanged);
           // 
           // label4
           // 
           this.label4.AutoSize = true;
           this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this.label4.Location = new System.Drawing.Point(399, 72);
           this.label4.Name = "label4";
           this.label4.Size = new System.Drawing.Size(52, 13);
           this.label4.TabIndex = 23;
           this.label4.Text = "Channel: ";
           // 
           // _gbGrayScaleRange
           // 
           this._gbGrayScaleRange.Controls.Add(this._numRangeMin);
           this._gbGrayScaleRange.Controls.Add(this._numRangeMax);
           this._gbGrayScaleRange.Controls.Add(this.label3);
           this._gbGrayScaleRange.Controls.Add(this._btnDraw);
           this._gbGrayScaleRange.Controls.Add(this.label1);
           this._gbGrayScaleRange.Controls.Add(this.label2);
           this._gbGrayScaleRange.Location = new System.Drawing.Point(231, 9);
           this._gbGrayScaleRange.Name = "_gbGrayScaleRange";
           this._gbGrayScaleRange.Size = new System.Drawing.Size(162, 99);
           this._gbGrayScaleRange.TabIndex = 22;
           this._gbGrayScaleRange.TabStop = false;
           // 
           // _numRangeMin
           // 
           this._numRangeMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this._numRangeMin.Location = new System.Drawing.Point(6, 45);
           this._numRangeMin.Name = "_numRangeMin";
           this._numRangeMin.Size = new System.Drawing.Size(61, 20);
           this._numRangeMin.TabIndex = 21;
           this._numRangeMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
           // 
           // _numRangeMax
           // 
           this._numRangeMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this._numRangeMax.Location = new System.Drawing.Point(94, 45);
           this._numRangeMax.Name = "_numRangeMax";
           this._numRangeMax.Size = new System.Drawing.Size(61, 20);
           this._numRangeMax.TabIndex = 13;
           this._numRangeMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
           // 
           // label3
           // 
           this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this.label3.Location = new System.Drawing.Point(5, 27);
           this.label3.Name = "label3";
           this.label3.Size = new System.Drawing.Size(54, 23);
           this.label3.TabIndex = 15;
           this.label3.Text = "min value";
           // 
           // _btnDraw
           // 
           this._btnDraw.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this._btnDraw.Location = new System.Drawing.Point(53, 68);
           this._btnDraw.Name = "_btnDraw";
           this._btnDraw.Size = new System.Drawing.Size(51, 28);
           this._btnDraw.TabIndex = 13;
           this._btnDraw.Text = "Draw";
           this._btnDraw.UseVisualStyleBackColor = true;
           this._btnDraw.Click += new System.EventHandler(this._btnDraw_Click);
           // 
           // label2
           // 
           this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this.label2.Location = new System.Drawing.Point(99, 27);
           this.label2.Name = "label2";
           this.label2.Size = new System.Drawing.Size(56, 23);
           this.label2.TabIndex = 14;
           this.label2.Text = "max value";
           // 
           // _numClipping
           // 
           this._numClipping.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this._numClipping.Location = new System.Drawing.Point(445, 33);
           this._numClipping.Name = "_numClipping";
           this._numClipping.Size = new System.Drawing.Size(63, 20);
           this._numClipping.TabIndex = 20;
           this._numClipping.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
           this._numClipping.ValueChanged += new System.EventHandler(this._numClipping_ValueChanged);
           // 
           // _lblClipping
           // 
           this._lblClipping.AutoSize = true;
           this._lblClipping.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this._lblClipping.Location = new System.Drawing.Point(399, 35);
           this._lblClipping.Name = "_lblClipping";
           this._lblClipping.Size = new System.Drawing.Size(50, 13);
           this._lblClipping.TabIndex = 19;
           this._lblClipping.Text = "Clipping: ";
           // 
           // _lblPercentil
           // 
           this._lblPercentil.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this._lblPercentil.Location = new System.Drawing.Point(104, 62);
           this._lblPercentil.Name = "_lblPercentil";
           this._lblPercentil.Size = new System.Drawing.Size(123, 23);
           this._lblPercentil.TabIndex = 18;
           this._lblPercentil.Text = "percentil";
           // 
           // _lblMedian
           // 
           this._lblMedian.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this._lblMedian.Location = new System.Drawing.Point(10, 85);
           this._lblMedian.Name = "_lblMedian";
           this._lblMedian.Size = new System.Drawing.Size(89, 23);
           this._lblMedian.TabIndex = 17;
           this._lblMedian.Text = "Median";
           // 
           // _lblMean
           // 
           this._lblMean.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this._lblMean.Location = new System.Drawing.Point(10, 62);
           this._lblMean.Name = "_lblMean";
           this._lblMean.Size = new System.Drawing.Size(89, 23);
           this._lblMean.TabIndex = 16;
           this._lblMean.Text = "Mean:";
           // 
           // _lblToltalPixels
           // 
           this._lblToltalPixels.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
           this._lblToltalPixels.Location = new System.Drawing.Point(104, 85);
           this._lblToltalPixels.Name = "_lblToltalPixels";
           this._lblToltalPixels.Size = new System.Drawing.Size(123, 23);
           this._lblToltalPixels.TabIndex = 13;
           this._lblToltalPixels.Text = "Total Pixels";
           // 
           // HistogramDlg
           // 
           this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
           this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
           this.ClientSize = new System.Drawing.Size(533, 389);
           this.Controls.Add(this.groupBox1);
           this.Controls.Add(this._pnlHistogram);
           this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
           this.MaximizeBox = false;
           this.MinimizeBox = false;
           this.Name = "HistogramDlg";
           this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
           this.Text = "Histogram";
           this.Load += new System.EventHandler(this.HistogramDlg_Load);
           this.groupBox1.ResumeLayout(false);
           this.groupBox1.PerformLayout();
           this._gbGrayScaleRange.ResumeLayout(false);
           ((System.ComponentModel.ISupportInitialize)(this._numRangeMin)).EndInit();
           ((System.ComponentModel.ISupportInitialize)(this._numRangeMax)).EndInit();
           ((System.ComponentModel.ISupportInitialize)(this._numClipping)).EndInit();
           this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _btnOk;
        private System.Windows.Forms.Panel _pnlHistogram;
        private System.Windows.Forms.Label _lblLevel;
        private System.Windows.Forms.Label _lblCount;
        private System.Windows.Forms.Label _lblMax;
        private System.Windows.Forms.Label _lblMin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button _btnDraw;
        private System.Windows.Forms.Label _lblToltalPixels;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label _lblMean;
        private System.Windows.Forms.Label _lblMedian;
        private System.Windows.Forms.Label _lblPercentil;
        private System.Windows.Forms.NumericUpDown _numClipping;
        private System.Windows.Forms.Label _lblClipping;
        private System.Windows.Forms.NumericUpDown _numRangeMin;
        private System.Windows.Forms.NumericUpDown _numRangeMax;
        private System.Windows.Forms.GroupBox _gbGrayScaleRange;
        private System.Windows.Forms.ComboBox _cmbChanel;
        private System.Windows.Forms.Label label4;
    }
}