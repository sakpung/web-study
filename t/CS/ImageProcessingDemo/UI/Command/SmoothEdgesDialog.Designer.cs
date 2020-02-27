namespace ImageProcessingDemo
{
   partial class SmoothEdgesDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SmoothEdgesDialog));
         this._gbSmoothEdges = new System.Windows.Forms.GroupBox();
         this._lblThreshold = new System.Windows.Forms.Label();
         this._lblAmount = new System.Windows.Forms.Label();
         this._numThreshold = new System.Windows.Forms.NumericUpDown();
         this._numAmount = new System.Windows.Forms.NumericUpDown();
         this._tbThreshold = new System.Windows.Forms.TrackBar();
         this._tbAmount = new System.Windows.Forms.TrackBar();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._gbSmoothEdges.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numThreshold)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numAmount)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._tbThreshold)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._tbAmount)).BeginInit();
         this.SuspendLayout();
         // 
         // _gbSmoothEdges
         // 
         this._gbSmoothEdges.Controls.Add(this._lblThreshold);
         this._gbSmoothEdges.Controls.Add(this._lblAmount);
         this._gbSmoothEdges.Controls.Add(this._numThreshold);
         this._gbSmoothEdges.Controls.Add(this._numAmount);
         this._gbSmoothEdges.Controls.Add(this._tbThreshold);
         this._gbSmoothEdges.Controls.Add(this._tbAmount);
         this._gbSmoothEdges.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbSmoothEdges, "_gbSmoothEdges");
         this._gbSmoothEdges.Name = "_gbSmoothEdges";
         this._gbSmoothEdges.TabStop = false;
         // 
         // _lblThreshold
         // 
         resources.ApplyResources(this._lblThreshold, "_lblThreshold");
         this._lblThreshold.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblThreshold.Name = "_lblThreshold";
         // 
         // _lblAmount
         // 
         resources.ApplyResources(this._lblAmount, "_lblAmount");
         this._lblAmount.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblAmount.Name = "_lblAmount";
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
         // _numAmount
         // 
         resources.ApplyResources(this._numAmount, "_numAmount");
         this._numAmount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numAmount.Name = "_numAmount";
         this._numAmount.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numAmount.ValueChanged += new System.EventHandler(this._numAmount_ValueChanged);
         this._numAmount.Leave += new System.EventHandler(this._numAmount_Leave);
         // 
         // _tbThreshold
         // 
         resources.ApplyResources(this._tbThreshold, "_tbThreshold");
         this._tbThreshold.Maximum = 255;
         this._tbThreshold.Name = "_tbThreshold";
         this._tbThreshold.TickStyle = System.Windows.Forms.TickStyle.None;
         this._tbThreshold.Scroll += new System.EventHandler(this._tbThreshold_Scroll);
         // 
         // _tbAmount
         // 
         resources.ApplyResources(this._tbAmount, "_tbAmount");
         this._tbAmount.Maximum = 100;
         this._tbAmount.Minimum = 1;
         this._tbAmount.Name = "_tbAmount";
         this._tbAmount.TickStyle = System.Windows.Forms.TickStyle.None;
         this._tbAmount.Value = 1;
         this._tbAmount.Scroll += new System.EventHandler(this._tbAmount_Scroll);
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         resources.ApplyResources(this._btnCancel, "_btnCancel");
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
         // 
         // _btnOk
         // 
         resources.ApplyResources(this._btnOk, "_btnOk");
         this._btnOk.Name = "_btnOk";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // SmoothEdgesDialog
         // 
         this.AcceptButton = this._btnOk;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._gbSmoothEdges);
         this.Name = "SmoothEdgesDialog";
         this.ShowIcon = false;
         this._gbSmoothEdges.ResumeLayout(false);
         this._gbSmoothEdges.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numThreshold)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numAmount)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._tbThreshold)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._tbAmount)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gbSmoothEdges;
      private System.Windows.Forms.Label _lblThreshold;
      private System.Windows.Forms.Label _lblAmount;
      private System.Windows.Forms.NumericUpDown _numThreshold;
      private System.Windows.Forms.NumericUpDown _numAmount;
      public System.Windows.Forms.TrackBar _tbThreshold;
      public System.Windows.Forms.TrackBar _tbAmount;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
   }
}