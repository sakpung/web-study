namespace ImageProcessingDemo
{
   partial class HalfToneDialog
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HalfToneDialog));
          this._btnCancel = new System.Windows.Forms.Button();
          this._btnOk = new System.Windows.Forms.Button();
          this._gbAngle = new System.Windows.Forms.GroupBox();
          this._numAngle = new System.Windows.Forms.NumericUpDown();
          this._tbAngle = new System.Windows.Forms.TrackBar();
          this._gbDimension = new System.Windows.Forms.GroupBox();
          this._numDimension = new System.Windows.Forms.NumericUpDown();
          this._tbDimension = new System.Windows.Forms.TrackBar();
          this._lblType = new System.Windows.Forms.Label();
          this._cmbType = new System.Windows.Forms.ComboBox();
          this._gbAngle.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this._numAngle)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._tbAngle)).BeginInit();
          this._gbDimension.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this._numDimension)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._tbDimension)).BeginInit();
          this.SuspendLayout();
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
          // _gbAngle
          // 
          this._gbAngle.Controls.Add(this._numAngle);
          this._gbAngle.Controls.Add(this._tbAngle);
          this._gbAngle.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gbAngle, "_gbAngle");
          this._gbAngle.Name = "_gbAngle";
          this._gbAngle.TabStop = false;
          // 
          // _numAngle
          // 
          resources.ApplyResources(this._numAngle, "_numAngle");
          this._numAngle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
          this._numAngle.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
          this._numAngle.Name = "_numAngle";
          this._numAngle.ValueChanged += new System.EventHandler(this._numAngle_ValueChanged);
          this._numAngle.Leave += new System.EventHandler(this._numAngle_Leave);
          // 
          // _tbAngle
          // 
          resources.ApplyResources(this._tbAngle, "_tbAngle");
          this._tbAngle.Maximum = 360;
          this._tbAngle.Minimum = -360;
          this._tbAngle.Name = "_tbAngle";
          this._tbAngle.TickStyle = System.Windows.Forms.TickStyle.None;
          this._tbAngle.Scroll += new System.EventHandler(this._tbAngle_Scroll);
          // 
          // _gbDimension
          // 
          this._gbDimension.Controls.Add(this._numDimension);
          this._gbDimension.Controls.Add(this._tbDimension);
          this._gbDimension.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gbDimension, "_gbDimension");
          this._gbDimension.Name = "_gbDimension";
          this._gbDimension.TabStop = false;
          // 
          // _numDimension
          // 
          resources.ApplyResources(this._numDimension, "_numDimension");
          this._numDimension.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
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
          // _tbDimension
          // 
          resources.ApplyResources(this._tbDimension, "_tbDimension");
          this._tbDimension.Maximum = 30;
          this._tbDimension.Minimum = 1;
          this._tbDimension.Name = "_tbDimension";
          this._tbDimension.TickStyle = System.Windows.Forms.TickStyle.None;
          this._tbDimension.Value = 1;
          this._tbDimension.Scroll += new System.EventHandler(this._tbDimension_Scroll);
          // 
          // _lblType
          // 
          resources.ApplyResources(this._lblType, "_lblType");
          this._lblType.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblType.Name = "_lblType";
          // 
          // _cmbType
          // 
          this._cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          resources.ApplyResources(this._cmbType, "_cmbType");
          this._cmbType.FormattingEnabled = true;
          this._cmbType.Name = "_cmbType";
          this._cmbType.SelectedIndexChanged += new System.EventHandler(this._cmbType_SelectedIndexChanged);
          // 
          // HalfToneDialog
          // 
          this.AcceptButton = this._btnOk;
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._btnCancel;
          this.Controls.Add(this._cmbType);
          this.Controls.Add(this._lblType);
          this.Controls.Add(this._gbDimension);
          this.Controls.Add(this._gbAngle);
          this.Controls.Add(this._btnCancel);
          this.Controls.Add(this._btnOk);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "HalfToneDialog";
          this.ShowIcon = false;
          this._gbAngle.ResumeLayout(false);
          this._gbAngle.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this._numAngle)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._tbAngle)).EndInit();
          this._gbDimension.ResumeLayout(false);
          this._gbDimension.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this._numDimension)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._tbDimension)).EndInit();
          this.ResumeLayout(false);
          this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.GroupBox _gbAngle;
      private System.Windows.Forms.GroupBox _gbDimension;
      private System.Windows.Forms.Label _lblType;
      private System.Windows.Forms.ComboBox _cmbType;
      public System.Windows.Forms.TrackBar _tbAngle;
      public System.Windows.Forms.TrackBar _tbDimension;
      private System.Windows.Forms.NumericUpDown _numAngle;
      private System.Windows.Forms.NumericUpDown _numDimension;
   }
}