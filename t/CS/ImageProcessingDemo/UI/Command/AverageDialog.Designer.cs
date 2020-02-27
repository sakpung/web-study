namespace ImageProcessingDemo
{
   partial class AverageDialog
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AverageDialog));
          this._txbDimension = new System.Windows.Forms.TextBox();
          this._gbDimension = new System.Windows.Forms.GroupBox();
          this._tbDimension = new System.Windows.Forms.TrackBar();
          this._btnOk = new System.Windows.Forms.Button();
          this._btnCancel = new System.Windows.Forms.Button();
          this._gbDimension.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this._tbDimension)).BeginInit();
          this.SuspendLayout();
          // 
          // _txbDimension
          // 
          this._txbDimension.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          resources.ApplyResources(this._txbDimension, "_txbDimension");
          this._txbDimension.Name = "_txbDimension";
          this._txbDimension.TextChanged += new System.EventHandler(this._txbDimension_TextChanged);
          // 
          // _gbDimension
          // 
          this._gbDimension.Controls.Add(this._tbDimension);
          this._gbDimension.Controls.Add(this._txbDimension);
          this._gbDimension.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gbDimension, "_gbDimension");
          this._gbDimension.Name = "_gbDimension";
          this._gbDimension.TabStop = false;
          // 
          // _tbDimension
          // 
          resources.ApplyResources(this._tbDimension, "_tbDimension");
          this._tbDimension.Maximum = 100;
          this._tbDimension.Minimum = 1;
          this._tbDimension.Name = "_tbDimension";
          this._tbDimension.TickStyle = System.Windows.Forms.TickStyle.None;
          this._tbDimension.Value = 1;
          this._tbDimension.Scroll += new System.EventHandler(this._tbDimension_Scroll);
          // 
          // _btnOk
          // 
          resources.ApplyResources(this._btnOk, "_btnOk");
          this._btnOk.Name = "_btnOk";
          this._btnOk.UseVisualStyleBackColor = true;
          this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
          // 
          // _btnCancel
          // 
          this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          resources.ApplyResources(this._btnCancel, "_btnCancel");
          this._btnCancel.Name = "_btnCancel";
          this._btnCancel.UseVisualStyleBackColor = true;
          this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
          // 
          // AverageDialog
          // 
          this.AcceptButton = this._btnOk;
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._btnCancel;
          this.Controls.Add(this._btnCancel);
          this.Controls.Add(this._btnOk);
          this.Controls.Add(this._gbDimension);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "AverageDialog";
          this.ShowIcon = false;
          this._gbDimension.ResumeLayout(false);
          this._gbDimension.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this._tbDimension)).EndInit();
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.TextBox _txbDimension;
      private System.Windows.Forms.GroupBox _gbDimension;
      public System.Windows.Forms.TrackBar _tbDimension;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnCancel;
   }
}