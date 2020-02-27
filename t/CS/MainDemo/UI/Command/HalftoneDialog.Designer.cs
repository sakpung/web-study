namespace MainDemo
{
   partial class HalftoneDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HalftoneDialog));
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._gbOptions = new System.Windows.Forms.GroupBox();
         this._cbType = new System.Windows.Forms.ComboBox();
         this._numDimension = new System.Windows.Forms.NumericUpDown();
         this._numAngle = new System.Windows.Forms.NumericUpDown();
         this._lblDimension = new System.Windows.Forms.Label();
         this._lblAngle = new System.Windows.Forms.Label();
         this._lblType = new System.Windows.Forms.Label();
         this._gbOptions.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numDimension)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numAngle)).BeginInit();
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
         this._gbOptions.Controls.Add(this._numDimension);
         this._gbOptions.Controls.Add(this._numAngle);
         this._gbOptions.Controls.Add(this._lblDimension);
         this._gbOptions.Controls.Add(this._lblAngle);
         this._gbOptions.Controls.Add(this._lblType);
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
         // _numDimension
         // 
         resources.ApplyResources(this._numDimension, "_numDimension");
         this._numDimension.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
         this._numDimension.Name = "_numDimension";
         this._numDimension.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
         this._numDimension.Leave += new System.EventHandler(this._num_Leave);
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
         this._numAngle.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _lblDimension
         // 
         this._lblDimension.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblDimension, "_lblDimension");
         this._lblDimension.Name = "_lblDimension";
         // 
         // _lblAngle
         // 
         this._lblAngle.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblAngle, "_lblAngle");
         this._lblAngle.Name = "_lblAngle";
         // 
         // _lblType
         // 
         this._lblType.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblType, "_lblType");
         this._lblType.Name = "_lblType";
         // 
         // HalftoneDialog
         // 
         this.AcceptButton = this._btnOk;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._gbOptions);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "HalftoneDialog";
         this.ShowInTaskbar = false;
         this.Load += new System.EventHandler(this.HalftoneDialog_Load);
         this._gbOptions.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this._numDimension)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numAngle)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.GroupBox _gbOptions;
      private System.Windows.Forms.NumericUpDown _numDimension;
      private System.Windows.Forms.NumericUpDown _numAngle;
      private System.Windows.Forms.Label _lblDimension;
      private System.Windows.Forms.Label _lblAngle;
      private System.Windows.Forms.Label _lblType;
      private System.Windows.Forms.ComboBox _cbType;

   }
}