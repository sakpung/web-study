namespace ImageProcessingDemo
{
   partial class SharpenDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SharpenDialog));
         this._gbSharpness = new System.Windows.Forms.GroupBox();
         this._numSharpness = new System.Windows.Forms.NumericUpDown();
         this._tbSharpness = new System.Windows.Forms.TrackBar();
         this._btnOk = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._gbSharpness.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numSharpness)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this._tbSharpness)).BeginInit();
         this.SuspendLayout();
         // 
         // _gbSharpness
         // 
         this._gbSharpness.Controls.Add(this._numSharpness);
         this._gbSharpness.Controls.Add(this._tbSharpness);
         this._gbSharpness.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbSharpness, "_gbSharpness");
         this._gbSharpness.Name = "_gbSharpness";
         this._gbSharpness.TabStop = false;
         // 
         // _numSharpness
         // 
         resources.ApplyResources(this._numSharpness, "_numSharpness");
         this._numSharpness.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
         this._numSharpness.Minimum = new decimal(new int[] {
            1000,
            0,
            0,
            -2147483648});
         this._numSharpness.Name = "_numSharpness";
         this._numSharpness.Leave += new System.EventHandler(this._numSharpness_Leave);
         // 
         // _tbSharpness
         // 
         resources.ApplyResources(this._tbSharpness, "_tbSharpness");
         this._tbSharpness.Maximum = 1000;
         this._tbSharpness.Minimum = -1000;
         this._tbSharpness.Name = "_tbSharpness";
         this._tbSharpness.TickStyle = System.Windows.Forms.TickStyle.None;
         this._tbSharpness.Value = 100;
         this._tbSharpness.Scroll += new System.EventHandler(this._tbSharpness_Scroll);
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
         // SharpenDialog
         // 
         this.AcceptButton = this._btnOk;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._gbSharpness);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "SharpenDialog";
         this.ShowIcon = false;
         this._gbSharpness.ResumeLayout(false);
         this._gbSharpness.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._numSharpness)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this._tbSharpness)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gbSharpness;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnCancel;
      public System.Windows.Forms.TrackBar _tbSharpness;
      private System.Windows.Forms.NumericUpDown _numSharpness;
   }
}