namespace MainDemo
{
   partial class ContourDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContourDialog));
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._gbOptions = new System.Windows.Forms.GroupBox();
         this._cbType = new System.Windows.Forms.ComboBox();
         this._numMaximumError = new System.Windows.Forms.NumericUpDown();
         this._numDeltaDirection = new System.Windows.Forms.NumericUpDown();
         this._numThreshold = new System.Windows.Forms.NumericUpDown();
         this._lblType = new System.Windows.Forms.Label();
         this._lblMaximumError = new System.Windows.Forms.Label();
         this._lblDeltaDirection = new System.Windows.Forms.Label();
         this._lblThreshold = new System.Windows.Forms.Label();
         this._gbOptions.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numMaximumError)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numDeltaDirection)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numThreshold)).BeginInit();
         this.SuspendLayout();
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         resources.ApplyResources(this._btnCancel, "_btnCancel");
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         resources.ApplyResources(this._btnOk, "_btnOk");
         this._btnOk.Name = "_btnOk";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _gbOptions
         // 
         this._gbOptions.Controls.Add(this._cbType);
         this._gbOptions.Controls.Add(this._numMaximumError);
         this._gbOptions.Controls.Add(this._numDeltaDirection);
         this._gbOptions.Controls.Add(this._numThreshold);
         this._gbOptions.Controls.Add(this._lblType);
         this._gbOptions.Controls.Add(this._lblMaximumError);
         this._gbOptions.Controls.Add(this._lblDeltaDirection);
         this._gbOptions.Controls.Add(this._lblThreshold);
         this._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbOptions, "_gbOptions");
         this._gbOptions.Name = "_gbOptions";
         this._gbOptions.TabStop = false;
         // 
         // _cbType
         // 
         this._cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbType.FormattingEnabled = true;
         resources.ApplyResources(this._cbType, "_cbType");
         this._cbType.Name = "_cbType";
         this._cbType.SelectedIndexChanged += new System.EventHandler(this._cbType_SelectedIndexChanged);
         // 
         // _numMaximumError
         // 
         resources.ApplyResources(this._numMaximumError, "_numMaximumError");
         this._numMaximumError.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
         this._numMaximumError.Name = "_numMaximumError";
         this._numMaximumError.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numMaximumError.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _numDeltaDirection
         // 
         resources.ApplyResources(this._numDeltaDirection, "_numDeltaDirection");
         this._numDeltaDirection.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
         this._numDeltaDirection.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numDeltaDirection.Name = "_numDeltaDirection";
         this._numDeltaDirection.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numDeltaDirection.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _numThreshold
         // 
         resources.ApplyResources(this._numThreshold, "_numThreshold");
         this._numThreshold.Maximum = new decimal(new int[] {
            254,
            0,
            0,
            0});
         this._numThreshold.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numThreshold.Name = "_numThreshold";
         this._numThreshold.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
         this._numThreshold.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _lblType
         // 
         this._lblType.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblType, "_lblType");
         this._lblType.Name = "_lblType";
         // 
         // _lblMaximumError
         // 
         this._lblMaximumError.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblMaximumError, "_lblMaximumError");
         this._lblMaximumError.Name = "_lblMaximumError";
         // 
         // _lblDeltaDirection
         // 
         this._lblDeltaDirection.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblDeltaDirection, "_lblDeltaDirection");
         this._lblDeltaDirection.Name = "_lblDeltaDirection";
         // 
         // _lblThreshold
         // 
         this._lblThreshold.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblThreshold, "_lblThreshold");
         this._lblThreshold.Name = "_lblThreshold";
         // 
         // ContourDialog
         // 
         this.AcceptButton = this._btnOk;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.Controls.Add(this._gbOptions);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ContourDialog";
         this.ShowInTaskbar = false;
         this.Load += new System.EventHandler(this.ContourDialog_Load);
         this._gbOptions.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this._numMaximumError)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numDeltaDirection)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numThreshold)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.GroupBox _gbOptions;
      private System.Windows.Forms.Label _lblThreshold;
      private System.Windows.Forms.Label _lblType;
      private System.Windows.Forms.Label _lblMaximumError;
      private System.Windows.Forms.Label _lblDeltaDirection;
      private System.Windows.Forms.NumericUpDown _numMaximumError;
      private System.Windows.Forms.NumericUpDown _numDeltaDirection;
      private System.Windows.Forms.NumericUpDown _numThreshold;
      private System.Windows.Forms.ComboBox _cbType;
   }
}