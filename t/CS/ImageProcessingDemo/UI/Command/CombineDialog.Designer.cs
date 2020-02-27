namespace ImageProcessingDemo
{
   partial class CombineDialog
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CombineDialog));
          this._gbSourceRectangle = new System.Windows.Forms.GroupBox();
          this._cmbSourceRectangle = new System.Windows.Forms.ComboBox();
          this._gbDestinationRectangle = new System.Windows.Forms.GroupBox();
          this._cmbDestinationRectangle = new System.Windows.Forms.ComboBox();
          this._gbOperation = new System.Windows.Forms.GroupBox();
          this._cmbOperation = new System.Windows.Forms.ComboBox();
          this._btnCancel = new System.Windows.Forms.Button();
          this._btnOk = new System.Windows.Forms.Button();
          this._gbResultImageRectangle = new System.Windows.Forms.GroupBox();
          this._cmbResultImageRectangle = new System.Windows.Forms.ComboBox();
          this.groupBox1 = new System.Windows.Forms.GroupBox();
          this._cmbSourceImageRectangle = new System.Windows.Forms.ComboBox();
          this._gbDestinationImageRectangle = new System.Windows.Forms.GroupBox();
          this._cmbDestinationImageRectangle = new System.Windows.Forms.ComboBox();
          this._gbChannelResultImageRectangle = new System.Windows.Forms.GroupBox();
          this._cmbChannelResultImageRectangle = new System.Windows.Forms.ComboBox();
          this._rbDestinationRectangle = new System.Windows.Forms.GroupBox();
          this._numHeight = new System.Windows.Forms.NumericUpDown();
          this._numWidth = new System.Windows.Forms.NumericUpDown();
          this._numY = new System.Windows.Forms.NumericUpDown();
          this._numX = new System.Windows.Forms.NumericUpDown();
          this._lblHeight = new System.Windows.Forms.Label();
          this._lblWidth = new System.Windows.Forms.Label();
          this._lblY = new System.Windows.Forms.Label();
          this._lblX = new System.Windows.Forms.Label();
          this._gbSourcePoint = new System.Windows.Forms.GroupBox();
          this._numPointY = new System.Windows.Forms.NumericUpDown();
          this._numPointX = new System.Windows.Forms.NumericUpDown();
          this._lblPointY = new System.Windows.Forms.Label();
          this._lblPointX = new System.Windows.Forms.Label();
          this._gbSourceRectangle.SuspendLayout();
          this._gbDestinationRectangle.SuspendLayout();
          this._gbOperation.SuspendLayout();
          this._gbResultImageRectangle.SuspendLayout();
          this.groupBox1.SuspendLayout();
          this._gbDestinationImageRectangle.SuspendLayout();
          this._gbChannelResultImageRectangle.SuspendLayout();
          this._rbDestinationRectangle.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this._numHeight)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._numWidth)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._numY)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._numX)).BeginInit();
          this._gbSourcePoint.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this._numPointY)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._numPointX)).BeginInit();
          this.SuspendLayout();
          // 
          // _gbSourceRectangle
          // 
          this._gbSourceRectangle.Controls.Add(this._cmbSourceRectangle);
          this._gbSourceRectangle.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gbSourceRectangle, "_gbSourceRectangle");
          this._gbSourceRectangle.Name = "_gbSourceRectangle";
          this._gbSourceRectangle.TabStop = false;
          // 
          // _cmbSourceRectangle
          // 
          this._cmbSourceRectangle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          resources.ApplyResources(this._cmbSourceRectangle, "_cmbSourceRectangle");
          this._cmbSourceRectangle.FormattingEnabled = true;
          this._cmbSourceRectangle.Name = "_cmbSourceRectangle";
          // 
          // _gbDestinationRectangle
          // 
          this._gbDestinationRectangle.Controls.Add(this._cmbDestinationRectangle);
          this._gbDestinationRectangle.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gbDestinationRectangle, "_gbDestinationRectangle");
          this._gbDestinationRectangle.Name = "_gbDestinationRectangle";
          this._gbDestinationRectangle.TabStop = false;
          // 
          // _cmbDestinationRectangle
          // 
          this._cmbDestinationRectangle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          resources.ApplyResources(this._cmbDestinationRectangle, "_cmbDestinationRectangle");
          this._cmbDestinationRectangle.FormattingEnabled = true;
          this._cmbDestinationRectangle.Name = "_cmbDestinationRectangle";
          // 
          // _gbOperation
          // 
          this._gbOperation.Controls.Add(this._cmbOperation);
          this._gbOperation.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gbOperation, "_gbOperation");
          this._gbOperation.Name = "_gbOperation";
          this._gbOperation.TabStop = false;
          // 
          // _cmbOperation
          // 
          this._cmbOperation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          resources.ApplyResources(this._cmbOperation, "_cmbOperation");
          this._cmbOperation.FormattingEnabled = true;
          this._cmbOperation.Name = "_cmbOperation";
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
          // _gbResultImageRectangle
          // 
          this._gbResultImageRectangle.Controls.Add(this._cmbResultImageRectangle);
          this._gbResultImageRectangle.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gbResultImageRectangle, "_gbResultImageRectangle");
          this._gbResultImageRectangle.Name = "_gbResultImageRectangle";
          this._gbResultImageRectangle.TabStop = false;
          // 
          // _cmbResultImageRectangle
          // 
          this._cmbResultImageRectangle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          resources.ApplyResources(this._cmbResultImageRectangle, "_cmbResultImageRectangle");
          this._cmbResultImageRectangle.FormattingEnabled = true;
          this._cmbResultImageRectangle.Name = "_cmbResultImageRectangle";
          // 
          // groupBox1
          // 
          this.groupBox1.Controls.Add(this._cmbSourceImageRectangle);
          this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this.groupBox1, "groupBox1");
          this.groupBox1.Name = "groupBox1";
          this.groupBox1.TabStop = false;
          // 
          // _cmbSourceImageRectangle
          // 
          this._cmbSourceImageRectangle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          resources.ApplyResources(this._cmbSourceImageRectangle, "_cmbSourceImageRectangle");
          this._cmbSourceImageRectangle.FormattingEnabled = true;
          this._cmbSourceImageRectangle.Name = "_cmbSourceImageRectangle";
          // 
          // _gbDestinationImageRectangle
          // 
          this._gbDestinationImageRectangle.Controls.Add(this._cmbDestinationImageRectangle);
          this._gbDestinationImageRectangle.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gbDestinationImageRectangle, "_gbDestinationImageRectangle");
          this._gbDestinationImageRectangle.Name = "_gbDestinationImageRectangle";
          this._gbDestinationImageRectangle.TabStop = false;
          // 
          // _cmbDestinationImageRectangle
          // 
          this._cmbDestinationImageRectangle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          resources.ApplyResources(this._cmbDestinationImageRectangle, "_cmbDestinationImageRectangle");
          this._cmbDestinationImageRectangle.FormattingEnabled = true;
          this._cmbDestinationImageRectangle.Name = "_cmbDestinationImageRectangle";
          // 
          // _gbChannelResultImageRectangle
          // 
          this._gbChannelResultImageRectangle.Controls.Add(this._cmbChannelResultImageRectangle);
          this._gbChannelResultImageRectangle.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gbChannelResultImageRectangle, "_gbChannelResultImageRectangle");
          this._gbChannelResultImageRectangle.Name = "_gbChannelResultImageRectangle";
          this._gbChannelResultImageRectangle.TabStop = false;
          // 
          // _cmbChannelResultImageRectangle
          // 
          this._cmbChannelResultImageRectangle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          resources.ApplyResources(this._cmbChannelResultImageRectangle, "_cmbChannelResultImageRectangle");
          this._cmbChannelResultImageRectangle.FormattingEnabled = true;
          this._cmbChannelResultImageRectangle.Name = "_cmbChannelResultImageRectangle";
          // 
          // _rbDestinationRectangle
          // 
          this._rbDestinationRectangle.Controls.Add(this._numHeight);
          this._rbDestinationRectangle.Controls.Add(this._numWidth);
          this._rbDestinationRectangle.Controls.Add(this._numY);
          this._rbDestinationRectangle.Controls.Add(this._numX);
          this._rbDestinationRectangle.Controls.Add(this._lblHeight);
          this._rbDestinationRectangle.Controls.Add(this._lblWidth);
          this._rbDestinationRectangle.Controls.Add(this._lblY);
          this._rbDestinationRectangle.Controls.Add(this._lblX);
          this._rbDestinationRectangle.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._rbDestinationRectangle, "_rbDestinationRectangle");
          this._rbDestinationRectangle.Name = "_rbDestinationRectangle";
          this._rbDestinationRectangle.TabStop = false;
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
          // _gbSourcePoint
          // 
          this._gbSourcePoint.Controls.Add(this._numPointY);
          this._gbSourcePoint.Controls.Add(this._numPointX);
          this._gbSourcePoint.Controls.Add(this._lblPointY);
          this._gbSourcePoint.Controls.Add(this._lblPointX);
          this._gbSourcePoint.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gbSourcePoint, "_gbSourcePoint");
          this._gbSourcePoint.Name = "_gbSourcePoint";
          this._gbSourcePoint.TabStop = false;
          // 
          // _numPointY
          // 
          resources.ApplyResources(this._numPointY, "_numPointY");
          this._numPointY.Name = "_numPointY";
          this._numPointY.Leave += new System.EventHandler(this._numPointY_Leave);
          // 
          // _numPointX
          // 
          resources.ApplyResources(this._numPointX, "_numPointX");
          this._numPointX.Name = "_numPointX";
          this._numPointX.Leave += new System.EventHandler(this._numPointX_Leave);
          // 
          // _lblPointY
          // 
          resources.ApplyResources(this._lblPointY, "_lblPointY");
          this._lblPointY.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblPointY.Name = "_lblPointY";
          // 
          // _lblPointX
          // 
          resources.ApplyResources(this._lblPointX, "_lblPointX");
          this._lblPointX.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblPointX.Name = "_lblPointX";
          // 
          // CombineDialog
          // 
          this.AcceptButton = this._btnOk;
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._btnCancel;
          this.Controls.Add(this._gbSourcePoint);
          this.Controls.Add(this._rbDestinationRectangle);
          this.Controls.Add(this._gbChannelResultImageRectangle);
          this.Controls.Add(this._gbDestinationImageRectangle);
          this.Controls.Add(this.groupBox1);
          this.Controls.Add(this._gbResultImageRectangle);
          this.Controls.Add(this._btnCancel);
          this.Controls.Add(this._btnOk);
          this.Controls.Add(this._gbOperation);
          this.Controls.Add(this._gbDestinationRectangle);
          this.Controls.Add(this._gbSourceRectangle);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "CombineDialog";
          this.ShowIcon = false;
          this._gbSourceRectangle.ResumeLayout(false);
          this._gbDestinationRectangle.ResumeLayout(false);
          this._gbOperation.ResumeLayout(false);
          this._gbResultImageRectangle.ResumeLayout(false);
          this.groupBox1.ResumeLayout(false);
          this._gbDestinationImageRectangle.ResumeLayout(false);
          this._gbChannelResultImageRectangle.ResumeLayout(false);
          this._rbDestinationRectangle.ResumeLayout(false);
          this._rbDestinationRectangle.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this._numHeight)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._numWidth)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._numY)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._numX)).EndInit();
          this._gbSourcePoint.ResumeLayout(false);
          this._gbSourcePoint.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this._numPointY)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._numPointX)).EndInit();
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gbSourceRectangle;
      private System.Windows.Forms.ComboBox _cmbSourceRectangle;
      private System.Windows.Forms.GroupBox _gbDestinationRectangle;
      private System.Windows.Forms.ComboBox _cmbDestinationRectangle;
      private System.Windows.Forms.GroupBox _gbOperation;
      private System.Windows.Forms.ComboBox _cmbOperation;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.GroupBox _gbResultImageRectangle;
      private System.Windows.Forms.ComboBox _cmbResultImageRectangle;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.ComboBox _cmbSourceImageRectangle;
      private System.Windows.Forms.GroupBox _gbDestinationImageRectangle;
      private System.Windows.Forms.ComboBox _cmbDestinationImageRectangle;
      private System.Windows.Forms.GroupBox _gbChannelResultImageRectangle;
      private System.Windows.Forms.ComboBox _cmbChannelResultImageRectangle;
      private System.Windows.Forms.GroupBox _rbDestinationRectangle;
      private System.Windows.Forms.NumericUpDown _numHeight;
      private System.Windows.Forms.NumericUpDown _numWidth;
      private System.Windows.Forms.NumericUpDown _numY;
      private System.Windows.Forms.NumericUpDown _numX;
      private System.Windows.Forms.Label _lblHeight;
      private System.Windows.Forms.Label _lblWidth;
      private System.Windows.Forms.Label _lblY;
      private System.Windows.Forms.Label _lblX;
      private System.Windows.Forms.GroupBox _gbSourcePoint;
      private System.Windows.Forms.NumericUpDown _numPointY;
      private System.Windows.Forms.NumericUpDown _numPointX;
      private System.Windows.Forms.Label _lblPointY;
      private System.Windows.Forms.Label _lblPointX;
   }
}