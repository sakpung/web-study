namespace ImageProcessingDemo
{
   partial class AlphaBlendDialog
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AlphaBlendDialog));
          this._gbDestinationRectangle = new System.Windows.Forms.GroupBox();
          this._numHeight = new System.Windows.Forms.NumericUpDown();
          this._numY1 = new System.Windows.Forms.NumericUpDown();
          this._numWidth = new System.Windows.Forms.NumericUpDown();
          this._numX1 = new System.Windows.Forms.NumericUpDown();
          this._lblHeight = new System.Windows.Forms.Label();
          this._lblWidth = new System.Windows.Forms.Label();
          this._lblY1 = new System.Windows.Forms.Label();
          this._lblX1 = new System.Windows.Forms.Label();
          this._gbSourcePoint = new System.Windows.Forms.GroupBox();
          this._numY2 = new System.Windows.Forms.NumericUpDown();
          this._numX2 = new System.Windows.Forms.NumericUpDown();
          this._lblY2 = new System.Windows.Forms.Label();
          this._lblX2 = new System.Windows.Forms.Label();
          this._lblOpacity = new System.Windows.Forms.Label();
          this._tbOpacity = new System.Windows.Forms.TrackBar();
          this._numOpacity = new System.Windows.Forms.NumericUpDown();
          this._btnCancel = new System.Windows.Forms.Button();
          this._btnOk = new System.Windows.Forms.Button();
          this._gb1 = new System.Windows.Forms.GroupBox();
          this._gbDestinationRectangle.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this._numHeight)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._numY1)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._numWidth)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._numX1)).BeginInit();
          this._gbSourcePoint.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this._numY2)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._numX2)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._tbOpacity)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._numOpacity)).BeginInit();
          this._gb1.SuspendLayout();
          this.SuspendLayout();
          // 
          // _gbDestinationRectangle
          // 
          this._gbDestinationRectangle.Controls.Add(this._numHeight);
          this._gbDestinationRectangle.Controls.Add(this._numY1);
          this._gbDestinationRectangle.Controls.Add(this._numWidth);
          this._gbDestinationRectangle.Controls.Add(this._numX1);
          this._gbDestinationRectangle.Controls.Add(this._lblHeight);
          this._gbDestinationRectangle.Controls.Add(this._lblWidth);
          this._gbDestinationRectangle.Controls.Add(this._lblY1);
          this._gbDestinationRectangle.Controls.Add(this._lblX1);
          resources.ApplyResources(this._gbDestinationRectangle, "_gbDestinationRectangle");
          this._gbDestinationRectangle.Name = "_gbDestinationRectangle";
          this._gbDestinationRectangle.TabStop = false;
          // 
          // _numHeight
          // 
          resources.ApplyResources(this._numHeight, "_numHeight");
          this._numHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
          this._numHeight.Name = "_numHeight";
          this._numHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
          this._numHeight.Leave += new System.EventHandler(this._numHeight_Leave);
          // 
          // _numY1
          // 
          resources.ApplyResources(this._numY1, "_numY1");
          this._numY1.Name = "_numY1";
          this._numY1.Leave += new System.EventHandler(this._numY1_Leave);
          // 
          // _numWidth
          // 
          resources.ApplyResources(this._numWidth, "_numWidth");
          this._numWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
          this._numWidth.Name = "_numWidth";
          this._numWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
          this._numWidth.Leave += new System.EventHandler(this._numWidth_Leave);
          // 
          // _numX1
          // 
          resources.ApplyResources(this._numX1, "_numX1");
          this._numX1.Name = "_numX1";
          this._numX1.Leave += new System.EventHandler(this._numX1_Leave);
          // 
          // _lblHeight
          // 
          resources.ApplyResources(this._lblHeight, "_lblHeight");
          this._lblHeight.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblHeight.Name = "_lblHeight";
          // 
          // _lblWidth
          // 
          resources.ApplyResources(this._lblWidth, "_lblWidth");
          this._lblWidth.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblWidth.Name = "_lblWidth";
          // 
          // _lblY1
          // 
          resources.ApplyResources(this._lblY1, "_lblY1");
          this._lblY1.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblY1.Name = "_lblY1";
          // 
          // _lblX1
          // 
          resources.ApplyResources(this._lblX1, "_lblX1");
          this._lblX1.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblX1.Name = "_lblX1";
          // 
          // _gbSourcePoint
          // 
          this._gbSourcePoint.Controls.Add(this._numY2);
          this._gbSourcePoint.Controls.Add(this._numX2);
          this._gbSourcePoint.Controls.Add(this._lblY2);
          this._gbSourcePoint.Controls.Add(this._lblX2);
          resources.ApplyResources(this._gbSourcePoint, "_gbSourcePoint");
          this._gbSourcePoint.Name = "_gbSourcePoint";
          this._gbSourcePoint.TabStop = false;
          // 
          // _numY2
          // 
          resources.ApplyResources(this._numY2, "_numY2");
          this._numY2.Name = "_numY2";
          this._numY2.Leave += new System.EventHandler(this._numY2_Leave);
          // 
          // _numX2
          // 
          resources.ApplyResources(this._numX2, "_numX2");
          this._numX2.Name = "_numX2";
          this._numX2.Leave += new System.EventHandler(this._numX2_Leave);
          // 
          // _lblY2
          // 
          resources.ApplyResources(this._lblY2, "_lblY2");
          this._lblY2.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblY2.Name = "_lblY2";
          // 
          // _lblX2
          // 
          resources.ApplyResources(this._lblX2, "_lblX2");
          this._lblX2.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblX2.Name = "_lblX2";
          // 
          // _lblOpacity
          // 
          resources.ApplyResources(this._lblOpacity, "_lblOpacity");
          this._lblOpacity.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblOpacity.Name = "_lblOpacity";
          // 
          // _tbOpacity
          // 
          resources.ApplyResources(this._tbOpacity, "_tbOpacity");
          this._tbOpacity.Name = "_tbOpacity";
          this._tbOpacity.TickStyle = System.Windows.Forms.TickStyle.None;
          this._tbOpacity.Scroll += new System.EventHandler(this._tbOpacity_Scroll);
          // 
          // _numOpacity
          // 
          resources.ApplyResources(this._numOpacity, "_numOpacity");
          this._numOpacity.Name = "_numOpacity";
          this._numOpacity.ValueChanged += new System.EventHandler(this._numOpacity_ValueChanged);
          this._numOpacity.Leave += new System.EventHandler(this._numOpacity_Leave);
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
          // _gb1
          // 
          this._gb1.Controls.Add(this._btnCancel);
          this._gb1.Controls.Add(this._btnOk);
          resources.ApplyResources(this._gb1, "_gb1");
          this._gb1.Name = "_gb1";
          this._gb1.TabStop = false;
          // 
          // AlphaBlendDialog
          // 
          this.AcceptButton = this._btnOk;
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._btnCancel;
          this.Controls.Add(this._gb1);
          this.Controls.Add(this._numOpacity);
          this.Controls.Add(this._tbOpacity);
          this.Controls.Add(this._lblOpacity);
          this.Controls.Add(this._gbSourcePoint);
          this.Controls.Add(this._gbDestinationRectangle);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "AlphaBlendDialog";
          this.ShowIcon = false;
          this._gbDestinationRectangle.ResumeLayout(false);
          this._gbDestinationRectangle.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this._numHeight)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._numY1)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._numWidth)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._numX1)).EndInit();
          this._gbSourcePoint.ResumeLayout(false);
          this._gbSourcePoint.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this._numY2)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._numX2)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._tbOpacity)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._numOpacity)).EndInit();
          this._gb1.ResumeLayout(false);
          this.ResumeLayout(false);
          this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.GroupBox _gbDestinationRectangle;
      private System.Windows.Forms.GroupBox _gbSourcePoint;
      private System.Windows.Forms.NumericUpDown _numHeight;
      private System.Windows.Forms.NumericUpDown _numY1;
      private System.Windows.Forms.NumericUpDown _numWidth;
      private System.Windows.Forms.NumericUpDown _numX1;
      private System.Windows.Forms.Label _lblHeight;
      private System.Windows.Forms.Label _lblWidth;
      private System.Windows.Forms.Label _lblY1;
      private System.Windows.Forms.Label _lblX1;
      private System.Windows.Forms.NumericUpDown _numY2;
      private System.Windows.Forms.NumericUpDown _numX2;
      private System.Windows.Forms.Label _lblY2;
      private System.Windows.Forms.Label _lblX2;
      private System.Windows.Forms.Label _lblOpacity;
      public System.Windows.Forms.TrackBar _tbOpacity;
      private System.Windows.Forms.NumericUpDown _numOpacity;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.GroupBox _gb1;
   }
}