namespace ImageProcessingDemo
{
   partial class MultiplyDialog
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MultiplyDialog));
          this._gbParameters = new System.Windows.Forms.GroupBox();
          this._lblFactor = new System.Windows.Forms.Label();
          this._tbFactor = new System.Windows.Forms.TrackBar();
          this._numFactor = new System.Windows.Forms.NumericUpDown();
          this._btnCancel = new System.Windows.Forms.Button();
          this._btnOk = new System.Windows.Forms.Button();
          this._gbParameters.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this._tbFactor)).BeginInit();
          ((System.ComponentModel.ISupportInitialize)(this._numFactor)).BeginInit();
          this.SuspendLayout();
          // 
          // _gbParameters
          // 
          this._gbParameters.Controls.Add(this._lblFactor);
          this._gbParameters.Controls.Add(this._tbFactor);
          this._gbParameters.Controls.Add(this._numFactor);
          this._gbParameters.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gbParameters, "_gbParameters");
          this._gbParameters.Name = "_gbParameters";
          this._gbParameters.TabStop = false;
          // 
          // _lblFactor
          // 
          resources.ApplyResources(this._lblFactor, "_lblFactor");
          this._lblFactor.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblFactor.Name = "_lblFactor";
          // 
          // _tbFactor
          // 
          resources.ApplyResources(this._tbFactor, "_tbFactor");
          this._tbFactor.Maximum = 255;
          this._tbFactor.Name = "_tbFactor";
          this._tbFactor.TickStyle = System.Windows.Forms.TickStyle.None;
          this._tbFactor.Scroll += new System.EventHandler(this._tbFactor_Scroll);
          // 
          // _numFactor
          // 
          resources.ApplyResources(this._numFactor, "_numFactor");
          this._numFactor.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
          this._numFactor.Name = "_numFactor";
          this._numFactor.ValueChanged += new System.EventHandler(this._numFactor_ValueChanged);
          this._numFactor.Leave += new System.EventHandler(this._numFactor_Leave);
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
          // MultiplyDialog
          // 
          this.AcceptButton = this._btnOk;
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._btnCancel;
          this.Controls.Add(this._btnCancel);
          this.Controls.Add(this._gbParameters);
          this.Controls.Add(this._btnOk);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "MultiplyDialog";
          this.ShowIcon = false;
          this._gbParameters.ResumeLayout(false);
          this._gbParameters.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this._tbFactor)).EndInit();
          ((System.ComponentModel.ISupportInitialize)(this._numFactor)).EndInit();
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gbParameters;
      private System.Windows.Forms.Label _lblFactor;
      public System.Windows.Forms.TrackBar _tbFactor;
      private System.Windows.Forms.NumericUpDown _numFactor;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
   }
}