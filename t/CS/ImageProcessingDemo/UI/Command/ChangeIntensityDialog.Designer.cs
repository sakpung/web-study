namespace ImageProcessingDemo
{
   partial class ChangeIntensityDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChangeIntensityDialog));
         this._gbOptions = new System.Windows.Forms.GroupBox();
         this._lblBrightness = new System.Windows.Forms.Label();
         this._txbBrightness = new System.Windows.Forms.TextBox();
         this._tbBrightness = new System.Windows.Forms.TrackBar();
         this._btnOk = new System.Windows.Forms.Button();
         this._btnCancel = new System.Windows.Forms.Button();
         this._gbOptions.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._tbBrightness)).BeginInit();
         this.SuspendLayout();
         // 
         // _gbOptions
         // 
         this._gbOptions.Controls.Add(this._lblBrightness);
         this._gbOptions.Controls.Add(this._txbBrightness);
         this._gbOptions.Controls.Add(this._tbBrightness);
         resources.ApplyResources(this._gbOptions, "_gbOptions");
         this._gbOptions.Name = "_gbOptions";
         this._gbOptions.TabStop = false;
         // 
         // _lblBrightness
         // 
         resources.ApplyResources(this._lblBrightness, "_lblBrightness");
         this._lblBrightness.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblBrightness.Name = "_lblBrightness";
         // 
         // _txbBrightness
         // 
         this._txbBrightness.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         resources.ApplyResources(this._txbBrightness, "_txbBrightness");
         this._txbBrightness.Name = "_txbBrightness";
         this._txbBrightness.TextChanged += new System.EventHandler(this._txbBrightness_TextChanged);
         this._txbBrightness.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txbBrightness_KeyPress);
         // 
         // _tbBrightness
         // 
         resources.ApplyResources(this._tbBrightness, "_tbBrightness");
         this._tbBrightness.Maximum = 1000;
         this._tbBrightness.Minimum = -1000;
         this._tbBrightness.Name = "_tbBrightness";
         this._tbBrightness.TickStyle = System.Windows.Forms.TickStyle.None;
         this._tbBrightness.Value = 10;
         this._tbBrightness.Scroll += new System.EventHandler(this._tbBrightness_Scroll);
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
         // ChangeIntensityDialog
         // 
         this.AcceptButton = this._btnOk;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._gbOptions);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ChangeIntensityDialog";
         this.ShowIcon = false;
         this.Load += new System.EventHandler(this.ChangeIntensityDialog_Load);
         this._gbOptions.ResumeLayout(false);
         this._gbOptions.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._tbBrightness)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gbOptions;
      public System.Windows.Forms.Label _lblBrightness;
      private System.Windows.Forms.TextBox _txbBrightness;
      public System.Windows.Forms.TrackBar _tbBrightness;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnCancel;

   }
}