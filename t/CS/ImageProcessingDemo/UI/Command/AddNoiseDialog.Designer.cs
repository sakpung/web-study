namespace ImageProcessingDemo
{
   partial class AddNoiseDialog
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddNoiseDialog));
          this._gbChannel = new System.Windows.Forms.GroupBox();
          this._rbMaster = new System.Windows.Forms.RadioButton();
          this._rbBlue = new System.Windows.Forms.RadioButton();
          this._rbGreen = new System.Windows.Forms.RadioButton();
          this._rbRed = new System.Windows.Forms.RadioButton();
          this._lblRange = new System.Windows.Forms.Label();
          this._btnCancel = new System.Windows.Forms.Button();
          this._btnOk = new System.Windows.Forms.Button();
          this._numRange = new System.Windows.Forms.NumericUpDown();
          this._gbChannel.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this._numRange)).BeginInit();
          this.SuspendLayout();
          // 
          // _gbChannel
          // 
          this._gbChannel.Controls.Add(this._rbMaster);
          this._gbChannel.Controls.Add(this._rbBlue);
          this._gbChannel.Controls.Add(this._rbGreen);
          this._gbChannel.Controls.Add(this._rbRed);
          resources.ApplyResources(this._gbChannel, "_gbChannel");
          this._gbChannel.Name = "_gbChannel";
          this._gbChannel.TabStop = false;
          // 
          // _rbMaster
          // 
          resources.ApplyResources(this._rbMaster, "_rbMaster");
          this._rbMaster.Name = "_rbMaster";
          this._rbMaster.TabStop = true;
          this._rbMaster.UseVisualStyleBackColor = true;
          // 
          // _rbBlue
          // 
          resources.ApplyResources(this._rbBlue, "_rbBlue");
          this._rbBlue.Name = "_rbBlue";
          this._rbBlue.TabStop = true;
          this._rbBlue.UseVisualStyleBackColor = true;
          // 
          // _rbGreen
          // 
          resources.ApplyResources(this._rbGreen, "_rbGreen");
          this._rbGreen.Name = "_rbGreen";
          this._rbGreen.TabStop = true;
          this._rbGreen.UseVisualStyleBackColor = true;
          // 
          // _rbRed
          // 
          resources.ApplyResources(this._rbRed, "_rbRed");
          this._rbRed.Name = "_rbRed";
          this._rbRed.TabStop = true;
          this._rbRed.UseVisualStyleBackColor = true;
          // 
          // _lblRange
          // 
          resources.ApplyResources(this._lblRange, "_lblRange");
          this._lblRange.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblRange.Name = "_lblRange";
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
          // _numRange
          // 
          resources.ApplyResources(this._numRange, "_numRange");
          this._numRange.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
          this._numRange.Name = "_numRange";
          this._numRange.Leave += new System.EventHandler(this._numRange_Leave);
          // 
          // AddNoiseDialog
          // 
          this.AcceptButton = this._btnOk;
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._btnCancel;
          this.Controls.Add(this._numRange);
          this.Controls.Add(this._btnCancel);
          this.Controls.Add(this._btnOk);
          this.Controls.Add(this._lblRange);
          this.Controls.Add(this._gbChannel);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "AddNoiseDialog";
          this.ShowIcon = false;
          this._gbChannel.ResumeLayout(false);
          this._gbChannel.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this._numRange)).EndInit();
          this.ResumeLayout(false);
          this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.GroupBox _gbChannel;
      private System.Windows.Forms.RadioButton _rbMaster;
      private System.Windows.Forms.RadioButton _rbBlue;
      private System.Windows.Forms.RadioButton _rbGreen;
      private System.Windows.Forms.RadioButton _rbRed;
      private System.Windows.Forms.Label _lblRange;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.NumericUpDown _numRange;
   }
}