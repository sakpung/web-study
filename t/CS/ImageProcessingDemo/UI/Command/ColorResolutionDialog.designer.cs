namespace ImageProcessingDemo
{
   partial class ColorResolutionDialog
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
          System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorResolutionDialog));
          this._btnOk = new System.Windows.Forms.Button();
          this._btnCancel = new System.Windows.Forms.Button();
          this._lblBitsPerPixel = new System.Windows.Forms.Label();
          this._lblDitherMethod = new System.Windows.Forms.Label();
          this._lblPalette = new System.Windows.Forms.Label();
          this._lblColorOrder = new System.Windows.Forms.Label();
          this._cmbBitsPerPixel = new System.Windows.Forms.ComboBox();
          this._cmbDitherMethod = new System.Windows.Forms.ComboBox();
          this._cmbPalette = new System.Windows.Forms.ComboBox();
          this._cmbColorOrder = new System.Windows.Forms.ComboBox();
          this.SuspendLayout();
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
          // _lblBitsPerPixel
          // 
          resources.ApplyResources(this._lblBitsPerPixel, "_lblBitsPerPixel");
          this._lblBitsPerPixel.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblBitsPerPixel.Name = "_lblBitsPerPixel";
          // 
          // _lblDitherMethod
          // 
          resources.ApplyResources(this._lblDitherMethod, "_lblDitherMethod");
          this._lblDitherMethod.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblDitherMethod.Name = "_lblDitherMethod";
          // 
          // _lblPalette
          // 
          resources.ApplyResources(this._lblPalette, "_lblPalette");
          this._lblPalette.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblPalette.Name = "_lblPalette";
          // 
          // _lblColorOrder
          // 
          resources.ApplyResources(this._lblColorOrder, "_lblColorOrder");
          this._lblColorOrder.FlatStyle = System.Windows.Forms.FlatStyle.System;
          this._lblColorOrder.Name = "_lblColorOrder";
          // 
          // _cmbBitsPerPixel
          // 
          this._cmbBitsPerPixel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          resources.ApplyResources(this._cmbBitsPerPixel, "_cmbBitsPerPixel");
          this._cmbBitsPerPixel.FormattingEnabled = true;
          this._cmbBitsPerPixel.Name = "_cmbBitsPerPixel";
          // 
          // _cmbDitherMethod
          // 
          this._cmbDitherMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          resources.ApplyResources(this._cmbDitherMethod, "_cmbDitherMethod");
          this._cmbDitherMethod.FormattingEnabled = true;
          this._cmbDitherMethod.Name = "_cmbDitherMethod";
          // 
          // _cmbPalette
          // 
          this._cmbPalette.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          resources.ApplyResources(this._cmbPalette, "_cmbPalette");
          this._cmbPalette.FormattingEnabled = true;
          this._cmbPalette.Name = "_cmbPalette";
          // 
          // _cmbColorOrder
          // 
          this._cmbColorOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          resources.ApplyResources(this._cmbColorOrder, "_cmbColorOrder");
          this._cmbColorOrder.FormattingEnabled = true;
          this._cmbColorOrder.Name = "_cmbColorOrder";
          // 
          // ColorResolutionDialog
          // 
          this.AcceptButton = this._btnOk;
          resources.ApplyResources(this, "$this");
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._btnCancel;
          this.Controls.Add(this._cmbColorOrder);
          this.Controls.Add(this._cmbPalette);
          this.Controls.Add(this._cmbDitherMethod);
          this.Controls.Add(this._cmbBitsPerPixel);
          this.Controls.Add(this._lblPalette);
          this.Controls.Add(this._lblColorOrder);
          this.Controls.Add(this._lblDitherMethod);
          this.Controls.Add(this._lblBitsPerPixel);
          this.Controls.Add(this._btnCancel);
          this.Controls.Add(this._btnOk);
          this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "ColorResolutionDialog";
          this.ShowIcon = false;
          this.ResumeLayout(false);
          this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Label _lblBitsPerPixel;
      private System.Windows.Forms.Label _lblDitherMethod;
      private System.Windows.Forms.Label _lblPalette;
      private System.Windows.Forms.Label _lblColorOrder;
      private System.Windows.Forms.ComboBox _cmbBitsPerPixel;
      private System.Windows.Forms.ComboBox _cmbDitherMethod;
      public System.Windows.Forms.ComboBox _cmbPalette;
      private System.Windows.Forms.ComboBox _cmbColorOrder;
   }
}