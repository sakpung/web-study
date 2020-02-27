namespace ImageProcessingDemo
{
   partial class AutoCropDialog
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AutoCropDialog));
          this._btnok = new System.Windows.Forms.Button();
          this._btncancel = new System.Windows.Forms.Button();
          this._gpThreshold = new System.Windows.Forms.GroupBox();
          this._txbThreshold = new System.Windows.Forms.TextBox();
          this._tbThreshold = new System.Windows.Forms.TrackBar();
          this._gpThreshold.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this._tbThreshold)).BeginInit();
          this.SuspendLayout();
          // 
          // _btnok
          // 
          resources.ApplyResources(this._btnok, "_btnok");
          this._btnok.Name = "_btnok";
          this._btnok.UseVisualStyleBackColor = true;
          this._btnok.Click += new System.EventHandler(this._btnok_Click);
          // 
          // _btncancel
          // 
          this._btncancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          resources.ApplyResources(this._btncancel, "_btncancel");
          this._btncancel.Name = "_btncancel";
          this._btncancel.UseVisualStyleBackColor = true;
          this._btncancel.Click += new System.EventHandler(this._btncancel_Click);
          // 
          // _gpThreshold
          // 
          this._gpThreshold.Controls.Add(this._txbThreshold);
          this._gpThreshold.Controls.Add(this._tbThreshold);
          this._gpThreshold.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gpThreshold, "_gpThreshold");
          this._gpThreshold.Name = "_gpThreshold";
          this._gpThreshold.TabStop = false;
          // 
          // _txbThreshold
          // 
          resources.ApplyResources(this._txbThreshold, "_txbThreshold");
          this._txbThreshold.Name = "_txbThreshold";
          this._txbThreshold.TextChanged += new System.EventHandler(this._txbThreshold_TextChanged);
          // 
          // _tbThreshold
          // 
          resources.ApplyResources(this._tbThreshold, "_tbThreshold");
          this._tbThreshold.Maximum = 255;
          this._tbThreshold.Name = "_tbThreshold";
          this._tbThreshold.TickStyle = System.Windows.Forms.TickStyle.None;
          this._tbThreshold.Value = 1;
          this._tbThreshold.Scroll += new System.EventHandler(this._tbThreshold_Scroll);
          // 
          // AutoCropDialog
          // 
          this.AcceptButton = this._btnok;
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._btncancel;
          this.Controls.Add(this._gpThreshold);
          this.Controls.Add(this._btncancel);
          this.Controls.Add(this._btnok);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "AutoCropDialog";
          this.ShowIcon = false;
          this._gpThreshold.ResumeLayout(false);
          this._gpThreshold.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this._tbThreshold)).EndInit();
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _btnok;
      private System.Windows.Forms.Button _btncancel;
      private System.Windows.Forms.GroupBox _gpThreshold;
      private System.Windows.Forms.TextBox _txbThreshold;
      public System.Windows.Forms.TrackBar _tbThreshold;
   }
}