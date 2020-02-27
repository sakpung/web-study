namespace ImageProcessingDemo
{
   partial class ContourFilterDialog
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContourFilterDialog));
          this._gbDeltaDirection = new System.Windows.Forms.GroupBox();
          this._tbDeltaDirection = new System.Windows.Forms.TrackBar();
          this._txbDeltaDirection = new System.Windows.Forms.TextBox();
          this._gbMaximumError = new System.Windows.Forms.GroupBox();
          this._tbMaximumError = new System.Windows.Forms.TrackBar();
          this._txbMaximumError = new System.Windows.Forms.TextBox();
          this._gbThreshold = new System.Windows.Forms.GroupBox();
          this._tbThreshold = new System.Windows.Forms.TrackBar();
          this._txbThreshold = new System.Windows.Forms.TextBox();
          this._gbType = new System.Windows.Forms.GroupBox();
          this._cmbType = new System.Windows.Forms.ComboBox();
          this._btnCancel = new System.Windows.Forms.Button();
          this._btnOk = new System.Windows.Forms.Button();
          this._gbDeltaDirection.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this._tbDeltaDirection)).BeginInit();
          this._gbMaximumError.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this._tbMaximumError)).BeginInit();
          this._gbThreshold.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this._tbThreshold)).BeginInit();
          this._gbType.SuspendLayout();
          this.SuspendLayout();
          // 
          // _gbDeltaDirection
          // 
          this._gbDeltaDirection.Controls.Add(this._tbDeltaDirection);
          this._gbDeltaDirection.Controls.Add(this._txbDeltaDirection);
          this._gbDeltaDirection.FlatStyle = System.Windows.Forms.FlatStyle.System;
          resources.ApplyResources(this._gbDeltaDirection, "_gbDeltaDirection");
          this._gbDeltaDirection.Name = "_gbDeltaDirection";
          this._gbDeltaDirection.TabStop = false;
          // 
          // _tbDeltaDirection
          // 
          resources.ApplyResources(this._tbDeltaDirection, "_tbDeltaDirection");
          this._tbDeltaDirection.Maximum = 64;
          this._tbDeltaDirection.Minimum = 1;
          this._tbDeltaDirection.Name = "_tbDeltaDirection";
          this._tbDeltaDirection.TickStyle = System.Windows.Forms.TickStyle.None;
          this._tbDeltaDirection.Value = 1;
          this._tbDeltaDirection.Scroll += new System.EventHandler(this._tbDeltaDirection_Scroll);
          // 
          // _txbDeltaDirection
          // 
          this._txbDeltaDirection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          resources.ApplyResources(this._txbDeltaDirection, "_txbDeltaDirection");
          this._txbDeltaDirection.Name = "_txbDeltaDirection";
          this._txbDeltaDirection.TextChanged += new System.EventHandler(this._txbDeltaDirection_TextChanged);
          // 
          // _gbMaximumError
          // 
          this._gbMaximumError.Controls.Add(this._tbMaximumError);
          this._gbMaximumError.Controls.Add(this._txbMaximumError);
          resources.ApplyResources(this._gbMaximumError, "_gbMaximumError");
          this._gbMaximumError.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._gbMaximumError.Name = "_gbMaximumError";
          this._gbMaximumError.TabStop = false;
          // 
          // _tbMaximumError
          // 
          resources.ApplyResources(this._tbMaximumError, "_tbMaximumError");
          this._tbMaximumError.Maximum = 255;
          this._tbMaximumError.Name = "_tbMaximumError";
          this._tbMaximumError.TickStyle = System.Windows.Forms.TickStyle.None;
          this._tbMaximumError.Scroll += new System.EventHandler(this._tbMaximumError_Scroll);
          // 
          // _txbMaximumError
          // 
          this._txbMaximumError.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          resources.ApplyResources(this._txbMaximumError, "_txbMaximumError");
          this._txbMaximumError.Name = "_txbMaximumError";
          this._txbMaximumError.TextChanged += new System.EventHandler(this._txbMaximumError_TextChanged);
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
          this._tbThreshold.Maximum = 254;
          this._tbThreshold.Minimum = 1;
          this._tbThreshold.Name = "_tbThreshold";
          this._tbThreshold.TickStyle = System.Windows.Forms.TickStyle.None;
          this._tbThreshold.Value = 1;
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
          this._cmbType.SelectedIndexChanged += new System.EventHandler(this._cmbType_SelectedIndexChanged);
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
          // ContourFilterDialog
          // 
          this.AcceptButton = this._btnOk;
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._btnCancel;
          this.Controls.Add(this._btnCancel);
          this.Controls.Add(this._btnOk);
          this.Controls.Add(this._gbType);
          this.Controls.Add(this._gbThreshold);
          this.Controls.Add(this._gbMaximumError);
          this.Controls.Add(this._gbDeltaDirection);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "ContourFilterDialog";
          this.ShowIcon = false;
          this._gbDeltaDirection.ResumeLayout(false);
          this._gbDeltaDirection.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this._tbDeltaDirection)).EndInit();
          this._gbMaximumError.ResumeLayout(false);
          this._gbMaximumError.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this._tbMaximumError)).EndInit();
          this._gbThreshold.ResumeLayout(false);
          this._gbThreshold.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this._tbThreshold)).EndInit();
          this._gbType.ResumeLayout(false);
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gbDeltaDirection;
      private System.Windows.Forms.GroupBox _gbMaximumError;
      private System.Windows.Forms.GroupBox _gbThreshold;
      public System.Windows.Forms.TrackBar _tbDeltaDirection;
      private System.Windows.Forms.TextBox _txbDeltaDirection;
      public System.Windows.Forms.TrackBar _tbMaximumError;
      private System.Windows.Forms.TextBox _txbMaximumError;
      public System.Windows.Forms.TrackBar _tbThreshold;
      private System.Windows.Forms.TextBox _txbThreshold;
      private System.Windows.Forms.GroupBox _gbType;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      protected System.Windows.Forms.ComboBox _cmbType;
   }
}