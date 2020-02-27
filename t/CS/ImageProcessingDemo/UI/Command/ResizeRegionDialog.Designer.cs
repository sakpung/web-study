namespace ImageProcessingDemo
{
   partial class ResizeRegionDialog
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ResizeRegionDialog));
          this._gbDimension = new System.Windows.Forms.GroupBox();
          this._tbDimension = new System.Windows.Forms.TrackBar();
          this._txbDimension = new System.Windows.Forms.TextBox();
          this._btnCancel = new System.Windows.Forms.Button();
          this._btnOk = new System.Windows.Forms.Button();
          this._gbType = new System.Windows.Forms.GroupBox();
          this._cmbType = new System.Windows.Forms.ComboBox();
          this._chkFrame = new System.Windows.Forms.CheckBox();
          this._gbDimension.SuspendLayout();
          ((System.ComponentModel.ISupportInitialize)(this._tbDimension)).BeginInit();
          this._gbType.SuspendLayout();
          this.SuspendLayout();
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
          this._tbDimension.Maximum = 500;
          this._tbDimension.Minimum = 1;
          this._tbDimension.Name = "_tbDimension";
          this._tbDimension.TickStyle = System.Windows.Forms.TickStyle.None;
          this._tbDimension.Value = 1;
          this._tbDimension.Scroll += new System.EventHandler(this._tbDimension_Scroll);
          // 
          // _txbDimension
          // 
          this._txbDimension.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
          resources.ApplyResources(this._txbDimension, "_txbDimension");
          this._txbDimension.Name = "_txbDimension";
          this._txbDimension.TextChanged += new System.EventHandler(this._txbDimension_TextChanged);
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
          this._btnOk.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          resources.ApplyResources(this._btnOk, "_btnOk");
          this._btnOk.Name = "_btnOk";
          this._btnOk.UseVisualStyleBackColor = true;
          this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
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
          // _chkFrame
          // 
          resources.ApplyResources(this._chkFrame, "_chkFrame");
          this._chkFrame.Name = "_chkFrame";
          this._chkFrame.UseVisualStyleBackColor = true;
          // 
          // ResizeRegionDialog
          // 
          this.AcceptButton = this._btnOk;
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._btnCancel;
          this.Controls.Add(this._chkFrame);
          this.Controls.Add(this._gbType);
          this.Controls.Add(this._btnCancel);
          this.Controls.Add(this._btnOk);
          this.Controls.Add(this._gbDimension);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "ResizeRegionDialog";
          this.ShowIcon = false;
          this._gbDimension.ResumeLayout(false);
          this._gbDimension.PerformLayout();
          ((System.ComponentModel.ISupportInitialize)(this._tbDimension)).EndInit();
          this._gbType.ResumeLayout(false);
          this.ResumeLayout(false);
          this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.GroupBox _gbDimension;
      private System.Windows.Forms.TextBox _txbDimension;
      public System.Windows.Forms.TrackBar _tbDimension;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.GroupBox _gbType;
      private System.Windows.Forms.ComboBox _cmbType;
      private System.Windows.Forms.CheckBox _chkFrame;
   }
}