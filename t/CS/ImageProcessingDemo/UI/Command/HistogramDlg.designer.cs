namespace ImageProcessingDemo
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HistogramDlg));
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
         resources.ApplyResources(this._btnOk, "_btnOk");
         this._btnOk.Name = "_btnOk";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnCancel_Click);
         // 
         // _pnlHistogram
         // 
         this._pnlHistogram.BackColor = System.Drawing.SystemColors.Control;
         this._pnlHistogram.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         resources.ApplyResources(this._pnlHistogram, "_pnlHistogram");
         this._pnlHistogram.Name = "_pnlHistogram";
         this._pnlHistogram.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
         // 
         // _lblLevel
         // 
         resources.ApplyResources(this._lblLevel, "_lblLevel");
         this._lblLevel.Name = "_lblLevel";
         // 
         // _lblCount
         // 
         resources.ApplyResources(this._lblCount, "_lblCount");
         this._lblCount.Name = "_lblCount";
         // 
         // _lblMax
         // 
         resources.ApplyResources(this._lblMax, "_lblMax");
         this._lblMax.Name = "_lblMax";
         // 
         // _lblMin
         // 
         resources.ApplyResources(this._lblMin, "_lblMin");
         this._lblMin.Name = "_lblMin";
         // 
         // label1
         // 
         resources.ApplyResources(this.label1, "label1");
         this.label1.Name = "label1";
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
         resources.ApplyResources(this.groupBox1, "groupBox1");
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.TabStop = false;
         // 
         // _cmbChanel
         // 
         this._cmbChanel.FormattingEnabled = true;
         this._cmbChanel.Items.AddRange(new object[] {
            resources.GetString("_cmbChanel.Items"),
            resources.GetString("_cmbChanel.Items1"),
            resources.GetString("_cmbChanel.Items2"),
            resources.GetString("_cmbChanel.Items3")});
         resources.ApplyResources(this._cmbChanel, "_cmbChanel");
         this._cmbChanel.Name = "_cmbChanel";
         this._cmbChanel.SelectedIndexChanged += new System.EventHandler(this._cmbChanel_SelectedIndexChanged);
         // 
         // label4
         // 
         resources.ApplyResources(this.label4, "label4");
         this.label4.Name = "label4";
         // 
         // _gbGrayScaleRange
         // 
         this._gbGrayScaleRange.Controls.Add(this._numRangeMin);
         this._gbGrayScaleRange.Controls.Add(this._numRangeMax);
         this._gbGrayScaleRange.Controls.Add(this.label3);
         this._gbGrayScaleRange.Controls.Add(this._btnDraw);
         this._gbGrayScaleRange.Controls.Add(this.label1);
         this._gbGrayScaleRange.Controls.Add(this.label2);
         resources.ApplyResources(this._gbGrayScaleRange, "_gbGrayScaleRange");
         this._gbGrayScaleRange.Name = "_gbGrayScaleRange";
         this._gbGrayScaleRange.TabStop = false;
         // 
         // _numRangeMin
         // 
         resources.ApplyResources(this._numRangeMin, "_numRangeMin");
         this._numRangeMin.Name = "_numRangeMin";
         // 
         // _numRangeMax
         // 
         resources.ApplyResources(this._numRangeMax, "_numRangeMax");
         this._numRangeMax.Name = "_numRangeMax";
         // 
         // label3
         // 
         resources.ApplyResources(this.label3, "label3");
         this.label3.Name = "label3";
         // 
         // _btnDraw
         // 
         resources.ApplyResources(this._btnDraw, "_btnDraw");
         this._btnDraw.Name = "_btnDraw";
         this._btnDraw.UseVisualStyleBackColor = true;
         this._btnDraw.Click += new System.EventHandler(this._btnDraw_Click);
         // 
         // label2
         // 
         resources.ApplyResources(this.label2, "label2");
         this.label2.Name = "label2";
         // 
         // _numClipping
         // 
         resources.ApplyResources(this._numClipping, "_numClipping");
         this._numClipping.Name = "_numClipping";
         this._numClipping.ValueChanged += new System.EventHandler(this._numClipping_ValueChanged);
         // 
         // _lblClipping
         // 
         resources.ApplyResources(this._lblClipping, "_lblClipping");
         this._lblClipping.Name = "_lblClipping";
         // 
         // _lblPercentil
         // 
         resources.ApplyResources(this._lblPercentil, "_lblPercentil");
         this._lblPercentil.Name = "_lblPercentil";
         // 
         // _lblMedian
         // 
         resources.ApplyResources(this._lblMedian, "_lblMedian");
         this._lblMedian.Name = "_lblMedian";
         // 
         // _lblMean
         // 
         resources.ApplyResources(this._lblMean, "_lblMean");
         this._lblMean.Name = "_lblMean";
         // 
         // _lblToltalPixels
         // 
         resources.ApplyResources(this._lblToltalPixels, "_lblToltalPixels");
         this._lblToltalPixels.Name = "_lblToltalPixels";
         // 
         // HistogramDlg
         // 
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this._pnlHistogram);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "HistogramDlg";
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