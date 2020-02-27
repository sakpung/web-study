namespace MainDemo
{
   partial class GrayScaleFactorDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GrayScaleFactorDialog));
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._gbOptions = new System.Windows.Forms.GroupBox();
         this._numBlue = new System.Windows.Forms.NumericUpDown();
         this._numGreen = new System.Windows.Forms.NumericUpDown();
         this._numRed = new System.Windows.Forms.NumericUpDown();
         this._lblBlue = new System.Windows.Forms.Label();
         this._lblGreen = new System.Windows.Forms.Label();
         this._lblRed = new System.Windows.Forms.Label();
         this._lblMsg = new System.Windows.Forms.Label();
         this._gbOptions.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numBlue)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numGreen)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._numRed)).BeginInit();
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
         this._gbOptions.Controls.Add(this._numBlue);
         this._gbOptions.Controls.Add(this._numGreen);
         this._gbOptions.Controls.Add(this._numRed);
         this._gbOptions.Controls.Add(this._lblBlue);
         this._gbOptions.Controls.Add(this._lblGreen);
         this._gbOptions.Controls.Add(this._lblRed);
         this._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbOptions, "_gbOptions");
         this._gbOptions.Name = "_gbOptions";
         this._gbOptions.TabStop = false;
         // 
         // _numBlue
         // 
         resources.ApplyResources(this._numBlue, "_numBlue");
         this._numBlue.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
         this._numBlue.Name = "_numBlue";
         this._numBlue.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _numGreen
         // 
         resources.ApplyResources(this._numGreen, "_numGreen");
         this._numGreen.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
         this._numGreen.Name = "_numGreen";
         this._numGreen.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _numRed
         // 
         resources.ApplyResources(this._numRed, "_numRed");
         this._numRed.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
         this._numRed.Name = "_numRed";
         this._numRed.Leave += new System.EventHandler(this._num_Leave);
         // 
         // _lblBlue
         // 
         this._lblBlue.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblBlue, "_lblBlue");
         this._lblBlue.Name = "_lblBlue";
         // 
         // _lblGreen
         // 
         this._lblGreen.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblGreen, "_lblGreen");
         this._lblGreen.Name = "_lblGreen";
         // 
         // _lblRed
         // 
         this._lblRed.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblRed, "_lblRed");
         this._lblRed.Name = "_lblRed";
         // 
         // _lblMsg
         // 
         this._lblMsg.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblMsg, "_lblMsg");
         this._lblMsg.Name = "_lblMsg";
         // 
         // GrayScaleFactorDialog
         // 
         this.AcceptButton = this._btnOk;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.Controls.Add(this._lblMsg);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._gbOptions);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "GrayScaleFactorDialog";
         this.ShowInTaskbar = false;
         this._gbOptions.ResumeLayout(false);
         ((System.ComponentModel.ISupportInitialize)(this._numBlue)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numGreen)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._numRed)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.GroupBox _gbOptions;
      private System.Windows.Forms.Label _lblRed;
      private System.Windows.Forms.Label _lblBlue;
      private System.Windows.Forms.Label _lblGreen;
      private System.Windows.Forms.Label _lblMsg;
      private System.Windows.Forms.NumericUpDown _numRed;
      private System.Windows.Forms.NumericUpDown _numBlue;
      private System.Windows.Forms.NumericUpDown _numGreen;
   }
}