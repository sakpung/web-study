namespace ImageProcessingDemo
{
   partial class UnsharpMaskDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UnsharpMaskDialog));
         this._gbAmount = new System.Windows.Forms.GroupBox();
         this._tbAmount = new System.Windows.Forms.TrackBar();
         this._txbAmount = new System.Windows.Forms.TextBox();
         this._gbRadius = new System.Windows.Forms.GroupBox();
         this._tbRadius = new System.Windows.Forms.TrackBar();
         this._txbRadius = new System.Windows.Forms.TextBox();
         this._gbThreshold = new System.Windows.Forms.GroupBox();
         this._tbThreshold = new System.Windows.Forms.TrackBar();
         this._txbThreshold = new System.Windows.Forms.TextBox();
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._cmbColorType = new System.Windows.Forms.ComboBox();
         this._lblColorType = new System.Windows.Forms.Label();
         this._gbAmount.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._tbAmount)).BeginInit();
         this._gbRadius.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._tbRadius)).BeginInit();
         this._gbThreshold.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this._tbThreshold)).BeginInit();
         this.SuspendLayout();
         // 
         // _gbAmount
         // 
         this._gbAmount.Controls.Add(this._tbAmount);
         this._gbAmount.Controls.Add(this._txbAmount);
         this._gbAmount.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbAmount, "_gbAmount");
         this._gbAmount.Name = "_gbAmount";
         this._gbAmount.TabStop = false;
         // 
         // _tbAmount
         // 
         resources.ApplyResources(this._tbAmount, "_tbAmount");
         this._tbAmount.Maximum = 500;
         this._tbAmount.Name = "_tbAmount";
         this._tbAmount.TickStyle = System.Windows.Forms.TickStyle.None;
         this._tbAmount.Scroll += new System.EventHandler(this._tbAmount_Scroll);
         // 
         // _txbAmount
         // 
         this._txbAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         resources.ApplyResources(this._txbAmount, "_txbAmount");
         this._txbAmount.Name = "_txbAmount";
         this._txbAmount.TextChanged += new System.EventHandler(this._txbAmount_TextChanged);
         // 
         // _gbRadius
         // 
         this._gbRadius.Controls.Add(this._tbRadius);
         this._gbRadius.Controls.Add(this._txbRadius);
         this._gbRadius.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._gbRadius, "_gbRadius");
         this._gbRadius.Name = "_gbRadius";
         this._gbRadius.TabStop = false;
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
         // _txbRadius
         // 
         this._txbRadius.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         resources.ApplyResources(this._txbRadius, "_txbRadius");
         this._txbRadius.Name = "_txbRadius";
         this._txbRadius.TextChanged += new System.EventHandler(this._txbRadius_TextChanged);
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
         // _cmbColorType
         // 
         this._cmbColorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         resources.ApplyResources(this._cmbColorType, "_cmbColorType");
         this._cmbColorType.FormattingEnabled = true;
         this._cmbColorType.Name = "_cmbColorType";
         // 
         // _lblColorType
         // 
         resources.ApplyResources(this._lblColorType, "_lblColorType");
         this._lblColorType.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblColorType.Name = "_lblColorType";
         // 
         // UnsharpMaskDialog
         // 
         this.AcceptButton = this._btnOk;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.Controls.Add(this._lblColorType);
         this.Controls.Add(this._cmbColorType);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.Controls.Add(this._gbThreshold);
         this.Controls.Add(this._gbRadius);
         this.Controls.Add(this._gbAmount);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "UnsharpMaskDialog";
         this.ShowIcon = false;
         this._gbAmount.ResumeLayout(false);
         this._gbAmount.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._tbAmount)).EndInit();
         this._gbRadius.ResumeLayout(false);
         this._gbRadius.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._tbRadius)).EndInit();
         this._gbThreshold.ResumeLayout(false);
         this._gbThreshold.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this._tbThreshold)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.GroupBox _gbAmount;
      private System.Windows.Forms.GroupBox _gbRadius;
      private System.Windows.Forms.GroupBox _gbThreshold;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.ComboBox _cmbColorType;
      private System.Windows.Forms.Label _lblColorType;
      public System.Windows.Forms.TrackBar _tbAmount;
      private System.Windows.Forms.TextBox _txbAmount;
      public System.Windows.Forms.TrackBar _tbRadius;
      private System.Windows.Forms.TextBox _txbRadius;
      public System.Windows.Forms.TrackBar _tbThreshold;
      private System.Windows.Forms.TextBox _txbThreshold;
   }
}