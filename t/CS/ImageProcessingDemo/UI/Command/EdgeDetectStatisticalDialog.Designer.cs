namespace ImageProcessingDemo
{
   partial class EdgeDetectStatisticalDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EdgeDetectStatisticalDialog));
         this._gbEdge = new System.Windows.Forms.GroupBox();
         this._lblThreshold = new System.Windows.Forms.Label();
         this._lblDimension = new System.Windows.Forms.Label();
         this._tbThreshold = new System.Windows.Forms.TrackBar();
         this._tbDimension = new System.Windows.Forms.TrackBar();
         this._numThreshold = new System.Windows.Forms.NumericUpDown();
         this._numDimension = new System.Windows.Forms.NumericUpDown();
         this._gbColor = new System.Windows.Forms.GroupBox();
         this._lblBackGroundColor = new System.Windows.Forms.Label();
         this._lblEdgeColor = new System.Windows.Forms.Label();
         this._BtnBackGroundColor = new System.Windows.Forms.Button();
         this._BtnEdgeColor = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._gbEdge.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._tbThreshold)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._tbDimension)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numThreshold)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numDimension)).BeginInit();
         this._gbColor.SuspendLayout();
         this.SuspendLayout();
         // 
         // _gbEdge
         // 
         this._gbEdge.Controls.Add(this._lblThreshold);
         this._gbEdge.Controls.Add(this._lblDimension);
         this._gbEdge.Controls.Add(this._tbThreshold);
         this._gbEdge.Controls.Add(this._tbDimension);
         this._gbEdge.Controls.Add(this._numThreshold);
         this._gbEdge.Controls.Add(this._numDimension);
         this._gbEdge.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbEdge, "_gbEdge");
         this._gbEdge.Name = "_gbEdge";
         this._gbEdge.TabStop = false;
         // 
         // _lblThreshold
         // 
         resources.ApplyResources(this._lblThreshold, "_lblThreshold");
         this._lblThreshold.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblThreshold.Name = "_lblThreshold";
         // 
         // _lblDimension
         // 
         resources.ApplyResources(this._lblDimension, "_lblDimension");
         this._lblDimension.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblDimension.Name = "_lblDimension";
         // 
         // _tbThreshold
         // 
         resources.ApplyResources(this._tbThreshold, "_tbThreshold");
         this._tbThreshold.Maximum = 255;
         this._tbThreshold.Name = "_tbThreshold";
         this._tbThreshold.TickStyle = System.Windows.Forms.TickStyle.None;
         this._tbThreshold.Scroll += new System.EventHandler(this._tbThreshold_Scroll);
         // 
         // _tbDimension
         // 
         resources.ApplyResources(this._tbDimension, "_tbDimension");
         this._tbDimension.Maximum = 100;
         this._tbDimension.Minimum = 1;
         this._tbDimension.Name = "_tbDimension";
         this._tbDimension.TickStyle = System.Windows.Forms.TickStyle.None;
         this._tbDimension.Value = 1;
         this._tbDimension.Scroll += new System.EventHandler(this._tbDimension_Scroll);
         // 
         // _numThreshold
         // 
         resources.ApplyResources(this._numThreshold, "_numThreshold");
         this._numThreshold.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
         this._numThreshold.Name = "_numThreshold";
         this._numThreshold.ValueChanged += new System.EventHandler(this._numThreshold_ValueChanged);
         this._numThreshold.Leave += new System.EventHandler(this._numThreshold_Leave);
         // 
         // _numDimension
         // 
         resources.ApplyResources(this._numDimension, "_numDimension");
         this._numDimension.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numDimension.Name = "_numDimension";
         this._numDimension.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numDimension.ValueChanged += new System.EventHandler(this._numDimension_ValueChanged);
         this._numDimension.Leave += new System.EventHandler(this._numDimension_Leave);
         // 
         // _gbColor
         // 
         this._gbColor.Controls.Add(this._lblBackGroundColor);
         this._gbColor.Controls.Add(this._lblEdgeColor);
         this._gbColor.Controls.Add(this._BtnBackGroundColor);
         this._gbColor.Controls.Add(this._BtnEdgeColor);
         this._gbColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbColor, "_gbColor");
         this._gbColor.Name = "_gbColor";
         this._gbColor.TabStop = false;
         // 
         // _lblBackGroundColor
         // 
         this._lblBackGroundColor.BackColor = System.Drawing.Color.Black;
         this._lblBackGroundColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._lblBackGroundColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblBackGroundColor, "_lblBackGroundColor");
         this._lblBackGroundColor.Name = "_lblBackGroundColor";
         // 
         // _lblEdgeColor
         // 
         this._lblEdgeColor.BackColor = System.Drawing.Color.White;
         this._lblEdgeColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._lblEdgeColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblEdgeColor, "_lblEdgeColor");
         this._lblEdgeColor.Name = "_lblEdgeColor";
         // 
         // _BtnBackGroundColor
         // 
         resources.ApplyResources(this._BtnBackGroundColor, "_BtnBackGroundColor");
         this._BtnBackGroundColor.Name = "_BtnBackGroundColor";
         this._BtnBackGroundColor.UseVisualStyleBackColor = true;
         this._BtnBackGroundColor.Click += new System.EventHandler(this._BtnBackGroundColor_Click);
         // 
         // _BtnEdgeColor
         // 
         resources.ApplyResources(this._BtnEdgeColor, "_BtnEdgeColor");
         this._BtnEdgeColor.Name = "_BtnEdgeColor";
         this._BtnEdgeColor.UseVisualStyleBackColor = true;
         this._BtnEdgeColor.Click += new System.EventHandler(this._BtnEdgeColor_Click);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         resources.ApplyResources(this._btnCancel, "_btnCancel");
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         resources.ApplyResources(this._btnOk, "_btnOk");
         this._btnOk.Name = "_btnOk";
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // EdgeDetectStatisticalDialog
         // 
         this.AcceptButton = this._btnOk;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._gbColor);
         this.Controls.Add(this._gbEdge);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "EdgeDetectStatisticalDialog";
         this.ShowIcon = false;
         this._gbEdge.ResumeLayout(false);
         this._gbEdge.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._tbThreshold)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._tbDimension)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numThreshold)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numDimension)).EndInit();
         this._gbColor.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gbEdge;
      private System.Windows.Forms.GroupBox _gbColor;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Label _lblThreshold;
      private System.Windows.Forms.Label _lblDimension;
      public System.Windows.Forms.TrackBar _tbThreshold;
      public System.Windows.Forms.TrackBar _tbDimension;
      private System.Windows.Forms.NumericUpDown _numThreshold;
      private System.Windows.Forms.NumericUpDown _numDimension;
      private System.Windows.Forms.Label _lblBackGroundColor;
      private System.Windows.Forms.Label _lblEdgeColor;
      private System.Windows.Forms.Button _BtnBackGroundColor;
      private System.Windows.Forms.Button _BtnEdgeColor;
   }
}