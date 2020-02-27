namespace ImageProcessingDemo
{
   partial class GaussianDialog
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GaussianDialog));
          this._btnCancel = new System.Windows.Forms.Button();
          this._btnOk = new System.Windows.Forms.Button();
          this._gbRadius = new System.Windows.Forms.GroupBox();
          this._txbRadius = new System.Windows.Forms.TextBox();
          this._tbRadius = new System.Windows.Forms.TrackBar();
          this._gbRadius.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this._tbRadius)).BeginInit();
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
          // _gbRadius
          // 
          this._gbRadius.Controls.Add(this._txbRadius);
          this._gbRadius.Controls.Add(this._tbRadius);
          this._gbRadius.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gbRadius, "_gbRadius");
          this._gbRadius.Name = "_gbRadius";
          this._gbRadius.TabStop = false;
          // 
          // _txbRadius
          // 
          this._txbRadius.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          resources.ApplyResources(this._txbRadius, "_txbRadius");
          this._txbRadius.Name = "_txbRadius";
          this._txbRadius.TextChanged += new System.EventHandler(this._txbRadius_TextChanged);
          // 
          // _tbRadius
          // 
          resources.ApplyResources(this._tbRadius, "_tbRadius");
          this._tbRadius.Maximum = 1000;
          this._tbRadius.Minimum = 1;
          this._tbRadius.Name = "_tbRadius";
          this._tbRadius.TickStyle = System.Windows.Forms.TickStyle.None;
          this._tbRadius.Value = 1;
          this._tbRadius.Scroll += new System.EventHandler(this._tbRadius_Scroll);
          // 
          // GaussianDialog
          // 
          this.AcceptButton = this._btnOk;
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._btnCancel;
          this.Controls.Add(this._gbRadius);
          this.Controls.Add(this._btnCancel);
          this.Controls.Add(this._btnOk);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "GaussianDialog";
          this.ShowIcon = false;
          this._gbRadius.ResumeLayout(false);
          this._gbRadius.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this._tbRadius)).EndInit();
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.GroupBox _gbRadius;
      private System.Windows.Forms.TextBox _txbRadius;
      public System.Windows.Forms.TrackBar _tbRadius;
   }
}