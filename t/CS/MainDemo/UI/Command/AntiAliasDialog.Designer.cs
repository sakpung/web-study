namespace MainDemo
{
   partial class AntiAliasDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AntiAliasDialog));
         this._gbOptions = new System.Windows.Forms.GroupBox();
         this._cbFilter = new System.Windows.Forms.ComboBox();
         this._numDimension = new System.Windows.Forms.NumericUpDown();
         this._numThreshold = new System.Windows.Forms.NumericUpDown();
         this._lblFilter = new System.Windows.Forms.Label();
         this._lblDimension = new System.Windows.Forms.Label();
         this._lblThreshold = new System.Windows.Forms.Label();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._gbOptions.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numDimension)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numThreshold)).BeginInit();
         this.SuspendLayout();
         // 
         // _gbOptions
         // 
         this._gbOptions.Controls.Add(this._cbFilter);
         this._gbOptions.Controls.Add(this._numDimension);
         this._gbOptions.Controls.Add(this._numThreshold);
         this._gbOptions.Controls.Add(this._lblFilter);
         this._gbOptions.Controls.Add(this._lblDimension);
         this._gbOptions.Controls.Add(this._lblThreshold);
         this._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbOptions, "_gbOptions");
         this._gbOptions.Name = "_gbOptions";
         this._gbOptions.TabStop = false;
         // 
         // _cbFilter
         // 
         this._cbFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbFilter.FormattingEnabled = true;
         resources.ApplyResources(this._cbFilter, "_cbFilter");
         this._cbFilter.Name = "_cbFilter";
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
         // _numThreshold
         // 
         resources.ApplyResources(this._numThreshold, "_numThreshold");
         this._numThreshold.Maximum = new decimal(new int[] {
            65535,
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
         // _lblFilter
         // 
         resources.ApplyResources(this._lblFilter, "_lblFilter");
         this._lblFilter.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblFilter.Name = "_lblFilter";
         // 
         // _lblDimension
         // 
         resources.ApplyResources(this._lblDimension, "_lblDimension");
         this._lblDimension.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblDimension.Name = "_lblDimension";
         // 
         // _lblThreshold
         // 
         resources.ApplyResources(this._lblThreshold, "_lblThreshold");
         this._lblThreshold.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblThreshold.Name = "_lblThreshold";
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
         // AntiAliasDialog
         // 
         this.AcceptButton = this._btnOk;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._gbOptions);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "AntiAliasDialog";
         this.ShowInTaskbar = false;
         this.Load += new System.EventHandler(this.AntiAliasDialog_Load);
         this._gbOptions.ResumeLayout(false);
         this._gbOptions.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numDimension)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numThreshold)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gbOptions;
      private System.Windows.Forms.ComboBox _cbFilter;
      private System.Windows.Forms.NumericUpDown _numDimension;
      private System.Windows.Forms.NumericUpDown _numThreshold;
      private System.Windows.Forms.Label _lblFilter;
      private System.Windows.Forms.Label _lblDimension;
      private System.Windows.Forms.Label _lblThreshold;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
   }
}