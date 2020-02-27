namespace ImageProcessingDemo
{
   partial class GrayScaleDialog
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GrayScaleDialog));
          this._lblBitsPerPixel = new System.Windows.Forms.Label();
          this._cmbBitsPerPixel = new System.Windows.Forms.ComboBox();
          this._btnOk = new System.Windows.Forms.Button();
          this._btnCancel = new System.Windows.Forms.Button();
          this.SuspendLayout();
          // 
          // _lblBitsPerPixel
          // 
          resources.ApplyResources(this._lblBitsPerPixel, "_lblBitsPerPixel");
          this._lblBitsPerPixel.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblBitsPerPixel.Name = "_lblBitsPerPixel";
          // 
          // _cmbBitsPerPixel
          // 
          this._cmbBitsPerPixel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          resources.ApplyResources(this._cmbBitsPerPixel, "_cmbBitsPerPixel");
          this._cmbBitsPerPixel.FormattingEnabled = true;
          this._cmbBitsPerPixel.Name = "_cmbBitsPerPixel";
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
          // GrayScaleDialog
          // 
          this.AcceptButton = this._btnOk;
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._btnCancel;
          this.Controls.Add(this._btnCancel);
          this.Controls.Add(this._btnOk);
          this.Controls.Add(this._cmbBitsPerPixel);
          this.Controls.Add(this._lblBitsPerPixel);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "GrayScaleDialog";
          this.ShowIcon = false;
          this.ResumeLayout(false);
          this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Label _lblBitsPerPixel;
      private System.Windows.Forms.ComboBox _cmbBitsPerPixel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnCancel;
   }
}