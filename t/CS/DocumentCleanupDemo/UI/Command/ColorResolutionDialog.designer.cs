namespace DocumentCleanupDemo
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
          this._btnOk.Location = new System.Drawing.Point(279, 10);
          this._btnOk.Name = "_btnOk";
          this._btnOk.Size = new System.Drawing.Size(75, 23);
          this._btnOk.TabIndex = 0;
          this._btnOk.Text = "OK";
          this._btnOk.UseVisualStyleBackColor = true;
          this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
          // 
          // _btnCancel
          // 
          this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
          this._btnCancel.Location = new System.Drawing.Point(279, 39);
          this._btnCancel.Name = "_btnCancel";
          this._btnCancel.Size = new System.Drawing.Size(75, 23);
          this._btnCancel.TabIndex = 1;
          this._btnCancel.Text = "Cancel";
          this._btnCancel.UseVisualStyleBackColor = true;
          this._btnCancel.Click += new System.EventHandler(this._btnCancel_Click);
          // 
          // _lblBitsPerPixel
          // 
          this._lblBitsPerPixel.AutoSize = true;
          this._lblBitsPerPixel.Location = new System.Drawing.Point(18, 20);
          this._lblBitsPerPixel.Name = "_lblBitsPerPixel";
          this._lblBitsPerPixel.Size = new System.Drawing.Size(68, 13);
          this._lblBitsPerPixel.TabIndex = 2;
          this._lblBitsPerPixel.Text = "Bits Per Pixel";
          // 
          // _lblDitherMethod
          // 
          this._lblDitherMethod.AutoSize = true;
          this._lblDitherMethod.Location = new System.Drawing.Point(18, 48);
          this._lblDitherMethod.Name = "_lblDitherMethod";
          this._lblDitherMethod.Size = new System.Drawing.Size(74, 13);
          this._lblDitherMethod.TabIndex = 3;
          this._lblDitherMethod.Text = "Dither Method";
          // 
          // _lblPalette
          // 
          this._lblPalette.AutoSize = true;
          this._lblPalette.Location = new System.Drawing.Point(18, 74);
          this._lblPalette.Name = "_lblPalette";
          this._lblPalette.Size = new System.Drawing.Size(40, 13);
          this._lblPalette.TabIndex = 5;
          this._lblPalette.Text = "Palette";
          // 
          // _lblColorOrder
          // 
          this._lblColorOrder.AutoSize = true;
          this._lblColorOrder.Location = new System.Drawing.Point(18, 101);
          this._lblColorOrder.Name = "_lblColorOrder";
          this._lblColorOrder.Size = new System.Drawing.Size(60, 13);
          this._lblColorOrder.TabIndex = 4;
          this._lblColorOrder.Text = "Color Order";
          // 
          // _cmbBitsPerPixel
          // 
          this._cmbBitsPerPixel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this._cmbBitsPerPixel.FormattingEnabled = true;
          this._cmbBitsPerPixel.Location = new System.Drawing.Point(92, 12);
          this._cmbBitsPerPixel.Name = "_cmbBitsPerPixel";
          this._cmbBitsPerPixel.Size = new System.Drawing.Size(181, 21);
          this._cmbBitsPerPixel.TabIndex = 6;
          // 
          // _cmbDitherMethod
          // 
          this._cmbDitherMethod.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this._cmbDitherMethod.FormattingEnabled = true;
          this._cmbDitherMethod.Location = new System.Drawing.Point(92, 39);
          this._cmbDitherMethod.Name = "_cmbDitherMethod";
          this._cmbDitherMethod.Size = new System.Drawing.Size(181, 21);
          this._cmbDitherMethod.TabIndex = 7;
          // 
          // _cmbPalette
          // 
          this._cmbPalette.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this._cmbPalette.FormattingEnabled = true;
          this._cmbPalette.Location = new System.Drawing.Point(92, 66);
          this._cmbPalette.Name = "_cmbPalette";
          this._cmbPalette.Size = new System.Drawing.Size(181, 21);
          this._cmbPalette.TabIndex = 8;
          // 
          // _cmbColorOrder
          // 
          this._cmbColorOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
          this._cmbColorOrder.FormattingEnabled = true;
          this._cmbColorOrder.Location = new System.Drawing.Point(92, 93);
          this._cmbColorOrder.Name = "_cmbColorOrder";
          this._cmbColorOrder.Size = new System.Drawing.Size(181, 21);
          this._cmbColorOrder.TabIndex = 9;
          // 
          // ColorResolutionDialog
          // 
          this.AcceptButton = this._btnOk;
          this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
          this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
          this.CancelButton = this._btnCancel;
          this.ClientSize = new System.Drawing.Size(361, 124);
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
          this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
          this.MaximizeBox = false;
          this.MinimizeBox = false;
          this.Name = "ColorResolutionDialog";
          this.Text = "Color Resolution";
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