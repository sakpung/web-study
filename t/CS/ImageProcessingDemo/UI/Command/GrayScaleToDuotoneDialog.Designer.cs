namespace ImageProcessingDemo
{
   partial class GrayScaleToDuotoneDialog
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GrayScaleToDuotoneDialog));
          this._gb1 = new System.Windows.Forms.GroupBox();
          this._btnColor = new System.Windows.Forms.Button();
          this._lblColor = new System.Windows.Forms.Label();
          this._lblType = new System.Windows.Forms.Label();
          this._cmbType = new System.Windows.Forms.ComboBox();
          this._btnCancel = new System.Windows.Forms.Button();
          this._btnOk = new System.Windows.Forms.Button();
          this._gb1.SuspendLayout();
          this.SuspendLayout();
          // 
          // _gb1
          // 
          this._gb1.Controls.Add(this._btnColor);
          this._gb1.Controls.Add(this._lblColor);
          this._gb1.Controls.Add(this._lblType);
          this._gb1.Controls.Add(this._cmbType);
          resources.ApplyResources(this._gb1, "_gb1");
          this._gb1.Name = "_gb1";
          this._gb1.TabStop = false;
          // 
          // _btnColor
          // 
          resources.ApplyResources(this._btnColor, "_btnColor");
          this._btnColor.Name = "_btnColor";
          this._btnColor.UseVisualStyleBackColor = true;
          this._btnColor.Click += new System.EventHandler(this._btnColor_Click);
          // 
          // _lblColor
          // 
          this._lblColor.BackColor = System.Drawing.Color.Black;
          this._lblColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
          resources.ApplyResources(this._lblColor, "_lblColor");
          this._lblColor.Name = "_lblColor";
          // 
          // _lblType
          // 
          resources.ApplyResources(this._lblType, "_lblType");
          this._lblType.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblType.Name = "_lblType";
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
          // GrayScaleToDuotoneDialog
          // 
          this.AcceptButton = this._btnOk;
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._btnCancel;
          this.Controls.Add(this._btnCancel);
          this.Controls.Add(this._btnOk);
          this.Controls.Add(this._gb1);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "GrayScaleToDuotoneDialog";
          this.ShowIcon = false;
          this._gb1.ResumeLayout(false);
          this._gb1.PerformLayout();
          this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.GroupBox _gb1;
      private System.Windows.Forms.Button _btnColor;
      private System.Windows.Forms.Label _lblColor;
      private System.Windows.Forms.Label _lblType;
      private System.Windows.Forms.ComboBox _cmbType;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
   }
}