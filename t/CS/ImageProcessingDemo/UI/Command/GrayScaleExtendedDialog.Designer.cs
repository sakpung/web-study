namespace ImageProcessingDemo
{
   partial class GrayScaleExtendedDialog
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GrayScaleExtendedDialog));
          this._gb1 = new System.Windows.Forms.GroupBox();
          this._numBlue = new System.Windows.Forms.NumericUpDown();
          this._numGreen = new System.Windows.Forms.NumericUpDown();
          this._numRed = new System.Windows.Forms.NumericUpDown();
          this._tbBlue = new System.Windows.Forms.TrackBar();
          this._tbGreen = new System.Windows.Forms.TrackBar();
          this._tbRed = new System.Windows.Forms.TrackBar();
          this._lblBlue = new System.Windows.Forms.Label();
          this._lblGreen = new System.Windows.Forms.Label();
          this._lblRed = new System.Windows.Forms.Label();
          this._btnCancel = new System.Windows.Forms.Button();
          this._btnOk = new System.Windows.Forms.Button();
          this._gb1.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this._numBlue)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._numGreen)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._numRed)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._tbBlue)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._tbGreen)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._tbRed)).BeginInit();
          this.SuspendLayout();
          // 
          // _gb1
          // 
          this._gb1.Controls.Add(this._numBlue);
          this._gb1.Controls.Add(this._numGreen);
          this._gb1.Controls.Add(this._numRed);
          this._gb1.Controls.Add(this._tbBlue);
          this._gb1.Controls.Add(this._tbGreen);
          this._gb1.Controls.Add(this._tbRed);
          this._gb1.Controls.Add(this._lblBlue);
          this._gb1.Controls.Add(this._lblGreen);
          this._gb1.Controls.Add(this._lblRed);
          resources.ApplyResources(this._gb1, "_gb1");
          this._gb1.Name = "_gb1";
          this._gb1.TabStop = false;
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
          this._numBlue.ValueChanged += new System.EventHandler(this._numBlue_ValueChanged);
          this._numBlue.Leave += new System.EventHandler(this._numBlue_Leave);
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
          this._numGreen.ValueChanged += new System.EventHandler(this._numGreen_ValueChanged);
          this._numGreen.Leave += new System.EventHandler(this._numGreen_Leave);
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
          this._numRed.ValueChanged += new System.EventHandler(this._numRed_ValueChanged);
          this._numRed.Leave += new System.EventHandler(this._numRed_Leave);
          // 
          // _tbBlue
          // 
          resources.ApplyResources(this._tbBlue, "_tbBlue");
          this._tbBlue.Maximum = 1000;
          this._tbBlue.Name = "_tbBlue";
          this._tbBlue.TickStyle = System.Windows.Forms.TickStyle.None;
          this._tbBlue.Scroll += new System.EventHandler(this._tbBlue_Scroll);
          // 
          // _tbGreen
          // 
          resources.ApplyResources(this._tbGreen, "_tbGreen");
          this._tbGreen.Maximum = 1000;
          this._tbGreen.Name = "_tbGreen";
          this._tbGreen.TickStyle = System.Windows.Forms.TickStyle.None;
          this._tbGreen.Scroll += new System.EventHandler(this._tbGreen_Scroll);
          // 
          // _tbRed
          // 
          resources.ApplyResources(this._tbRed, "_tbRed");
          this._tbRed.Maximum = 1000;
          this._tbRed.Name = "_tbRed";
          this._tbRed.TickStyle = System.Windows.Forms.TickStyle.None;
          this._tbRed.Scroll += new System.EventHandler(this._tbRed_Scroll);
          // 
          // _lblBlue
          // 
          resources.ApplyResources(this._lblBlue, "_lblBlue");
          this._lblBlue.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblBlue.Name = "_lblBlue";
          // 
          // _lblGreen
          // 
          resources.ApplyResources(this._lblGreen, "_lblGreen");
          this._lblGreen.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblGreen.Name = "_lblGreen";
          // 
          // _lblRed
          // 
          resources.ApplyResources(this._lblRed, "_lblRed");
          this._lblRed.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblRed.Name = "_lblRed";
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
          // GrayScaleExtendedDialog
          // 
          this.AcceptButton = this._btnOk;
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._btnCancel;
          this.Controls.Add(this._btnCancel);
          this.Controls.Add(this._btnOk);
          this.Controls.Add(this._gb1);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "GrayScaleExtendedDialog";
          this.ShowIcon = false;
          this._gb1.ResumeLayout(false);
          this._gb1.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this._numBlue)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._numGreen)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._numRed)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._tbBlue)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._tbGreen)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._tbRed)).EndInit();
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gb1;
      private System.Windows.Forms.NumericUpDown _numBlue;
      private System.Windows.Forms.NumericUpDown _numGreen;
      private System.Windows.Forms.NumericUpDown _numRed;
      private System.Windows.Forms.Label _lblBlue;
      private System.Windows.Forms.Label _lblGreen;
      private System.Windows.Forms.Label _lblRed;
      public System.Windows.Forms.TrackBar _tbBlue;
      public System.Windows.Forms.TrackBar _tbGreen;
      public System.Windows.Forms.TrackBar _tbRed;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
   }
}