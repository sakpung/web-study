namespace MainDemo
{

   partial class MagicWandThresholdDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MagicWandThresholdDialog));
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._gbOptions = new System.Windows.Forms.GroupBox();
         this._tbThreshold = new System.Windows.Forms.TrackBar();
         this._txtThreshold = new System.Windows.Forms.TextBox();
         this._gbOptions.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._tbThreshold)).BeginInit();
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
         this._gbOptions.Controls.Add(this._tbThreshold);
         this._gbOptions.Controls.Add(this._txtThreshold);
         this._gbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbOptions, "_gbOptions");
         this._gbOptions.Name = "_gbOptions";
         this._gbOptions.TabStop = false;
         // 
         // _tbThreshold
         // 
         this._tbThreshold.LargeChange = 1;
         resources.ApplyResources(this._tbThreshold, "_tbThreshold");
         this._tbThreshold.Maximum = 255;
         this._tbThreshold.Minimum = 1;
         this._tbThreshold.Name = "_tbThreshold";
         this._tbThreshold.TickStyle = System.Windows.Forms.TickStyle.None;
         this._tbThreshold.Value = 5;
         this._tbThreshold.Scroll += new System.EventHandler(this._tbThreshold_Scroll);
         // 
         // _txtThreshold
         // 
         resources.ApplyResources(this._txtThreshold, "_txtThreshold");
         this._txtThreshold.Name = "_txtThreshold";
         this._txtThreshold.TextChanged += new System.EventHandler(this._txtThreshold_TextChanged);
         this._txtThreshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this._txtThreshold_KeyPress);
         // 
         // MagicWandThresholdDialog
         // 
         this.AcceptButton = this._btnOk;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.Controls.Add(this._gbOptions);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "MagicWandThresholdDialog";
         this.Load += new System.EventHandler(this.MagicWandThresholdDialog_Load);
         this._gbOptions.ResumeLayout(false);
         this._gbOptions.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._tbThreshold)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.GroupBox _gbOptions;
      private System.Windows.Forms.TrackBar _tbThreshold;
      private System.Windows.Forms.TextBox _txtThreshold;
   }
}