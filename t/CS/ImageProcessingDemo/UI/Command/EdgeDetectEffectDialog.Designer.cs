namespace ImageProcessingDemo
{
   partial class EdgeDetectEffectDialog
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EdgeDetectEffectDialog));
          this._gbLevel = new System.Windows.Forms.GroupBox();
          this._tbLevel = new System.Windows.Forms.TrackBar();
          this._txbLevel = new System.Windows.Forms.TextBox();
          this._gbThreshold = new System.Windows.Forms.GroupBox();
          this._tbThreshold = new System.Windows.Forms.TrackBar();
          this._txbThreshold = new System.Windows.Forms.TextBox();
          this._gbType = new System.Windows.Forms.GroupBox();
          this._cmbType = new System.Windows.Forms.ComboBox();
          this._btnCancel = new System.Windows.Forms.Button();
          this._btnOk = new System.Windows.Forms.Button();
          this._gbLevel.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this._tbLevel)).BeginInit();
          this._gbThreshold.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this._tbThreshold)).BeginInit();
          this._gbType.SuspendLayout();
          this.SuspendLayout();
          // 
          // _gbLevel
          // 
          this._gbLevel.Controls.Add(this._tbLevel);
          this._gbLevel.Controls.Add(this._txbLevel);
          this._gbLevel.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gbLevel, "_gbLevel");
          this._gbLevel.Name = "_gbLevel";
          this._gbLevel.TabStop = false;
          // 
          // _tbLevel
          // 
          resources.ApplyResources(this._tbLevel, "_tbLevel");
          this._tbLevel.Maximum = 100;
          this._tbLevel.Minimum = 1;
          this._tbLevel.Name = "_tbLevel";
          this._tbLevel.TickStyle = System.Windows.Forms.TickStyle.None;
          this._tbLevel.Value = 1;
          this._tbLevel.Scroll += new System.EventHandler(this._tbLevel_Scroll);
          // 
          // _txbLevel
          // 
          this._txbLevel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          resources.ApplyResources(this._txbLevel, "_txbLevel");
          this._txbLevel.Name = "_txbLevel";
          this._txbLevel.TextChanged += new System.EventHandler(this._txbLevel_TextChanged);
          // 
          // _gbThreshold
          // 
          this._gbThreshold.Controls.Add(this._tbThreshold);
          this._gbThreshold.Controls.Add(this._txbThreshold);
          this._gbThreshold.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gbThreshold, "_gbThreshold");
          this._gbThreshold.Name = "_gbThreshold";
          this._gbThreshold.TabStop = false;
          // 
          // _tbThreshold
          // 
          resources.ApplyResources(this._tbThreshold, "_tbThreshold");
          this._tbThreshold.Maximum = 255;
          this._tbThreshold.Name = "_tbThreshold";
          this._tbThreshold.TickStyle = System.Windows.Forms.TickStyle.None;
          this._tbThreshold.Scroll += new System.EventHandler(this._tbThreshold_Scroll);
          // 
          // _txbThreshold
          // 
          this._txbThreshold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          resources.ApplyResources(this._txbThreshold, "_txbThreshold");
          this._txbThreshold.Name = "_txbThreshold";
          this._txbThreshold.TextChanged += new System.EventHandler(this._txbThreshold_TextChanged);
          // 
          // _gbType
          // 
          this._gbType.Controls.Add(this._cmbType);
          this._gbType.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gbType, "_gbType");
          this._gbType.Name = "_gbType";
          this._gbType.TabStop = false;
          // 
          // _cmbType
          // 
          this._cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          resources.ApplyResources(this._cmbType, "_cmbType");
          this._cmbType.FormattingEnabled = true;
          this._cmbType.Name = "_cmbType";
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
          // EdgeDetectEffectDialog
          // 
          this.AcceptButton = this._btnOk;
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._btnCancel;
          this.Controls.Add(this._btnCancel);
          this.Controls.Add(this._btnOk);
          this.Controls.Add(this._gbType);
          this.Controls.Add(this._gbThreshold);
          this.Controls.Add(this._gbLevel);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "EdgeDetectEffectDialog";
          this.TopMost = true;
          this._gbLevel.ResumeLayout(false);
          this._gbLevel.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this._tbLevel)).EndInit();
          this._gbThreshold.ResumeLayout(false);
          this._gbThreshold.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this._tbThreshold)).EndInit();
          this._gbType.ResumeLayout(false);
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gbLevel;
      private System.Windows.Forms.GroupBox _gbThreshold;
      private System.Windows.Forms.GroupBox _gbType;
      private System.Windows.Forms.TrackBar _tbLevel;
      private System.Windows.Forms.TextBox _txbLevel;
      private System.Windows.Forms.TrackBar _tbThreshold;
      private System.Windows.Forms.TextBox _txbThreshold;
      private System.Windows.Forms.ComboBox _cmbType;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
   }
}