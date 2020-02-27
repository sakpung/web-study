namespace ImageProcessingDemo
{
   partial class CropDialog
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CropDialog));
          this._gbRectangle = new System.Windows.Forms.GroupBox();
          this._numHeight = new System.Windows.Forms.NumericUpDown();
          this._numWidth = new System.Windows.Forms.NumericUpDown();
          this._numY = new System.Windows.Forms.NumericUpDown();
          this._numX = new System.Windows.Forms.NumericUpDown();
          this._lblHeight = new System.Windows.Forms.Label();
          this._lblWidth = new System.Windows.Forms.Label();
          this._lblY = new System.Windows.Forms.Label();
          this._lblX = new System.Windows.Forms.Label();
          this._btnOk = new System.Windows.Forms.Button();
          this._btnCancel = new System.Windows.Forms.Button();
          this._gbRectangle.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this._numHeight)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._numWidth)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._numY)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._numX)).BeginInit();
          this.SuspendLayout();
          // 
          // _gbRectangle
          // 
          this._gbRectangle.Controls.Add(this._numHeight);
          this._gbRectangle.Controls.Add(this._numWidth);
          this._gbRectangle.Controls.Add(this._numY);
          this._gbRectangle.Controls.Add(this._numX);
          this._gbRectangle.Controls.Add(this._lblHeight);
          this._gbRectangle.Controls.Add(this._lblWidth);
          this._gbRectangle.Controls.Add(this._lblY);
          this._gbRectangle.Controls.Add(this._lblX);
          this._gbRectangle.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gbRectangle, "_gbRectangle");
          this._gbRectangle.Name = "_gbRectangle";
          this._gbRectangle.TabStop = false;
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
          // _numY
          // 
          resources.ApplyResources(this._numY, "_numY");
          this._numY.Name = "_numY";
          this._numY.Leave += new System.EventHandler(this._numY_Leave);
          // 
          // _numX
          // 
          resources.ApplyResources(this._numX, "_numX");
          this._numX.Name = "_numX";
          this._numX.Leave += new System.EventHandler(this._numX_Leave);
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
          // _lblY
          // 
          resources.ApplyResources(this._lblY, "_lblY");
          this._lblY.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblY.Name = "_lblY";
          // 
          // _lblX
          // 
          resources.ApplyResources(this._lblX, "_lblX");
          this._lblX.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblX.Name = "_lblX";
          // 
          // _btnOk
          // 
          resources.ApplyResources(this._btnOk, "_btnOk");
          this._btnOk.Name = "_btnOk";
          this._btnOk.UseVisualStyleBackColor = true;
          this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
          // 
          // _btnCancel
          // 
          this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          resources.ApplyResources(this._btnCancel, "_btnCancel");
          this._btnCancel.Name = "_btnCancel";
          this._btnCancel.UseVisualStyleBackColor = true;
          this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
          // 
          // CropDialog
          // 
          this.AcceptButton = this._btnOk;
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._btnCancel;
          this.Controls.Add(this._btnCancel);
          this.Controls.Add(this._btnOk);
          this.Controls.Add(this._gbRectangle);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "CropDialog";
          this.ShowIcon = false;
          this._gbRectangle.ResumeLayout(false);
          this._gbRectangle.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this._numHeight)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._numWidth)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._numY)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._numX)).EndInit();
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gbRectangle;
      private System.Windows.Forms.Label _lblHeight;
      private System.Windows.Forms.Label _lblWidth;
      private System.Windows.Forms.Label _lblY;
      private System.Windows.Forms.Label _lblX;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.NumericUpDown _numHeight;
      private System.Windows.Forms.NumericUpDown _numWidth;
      private System.Windows.Forms.NumericUpDown _numY;
      private System.Windows.Forms.NumericUpDown _numX;
   }
}