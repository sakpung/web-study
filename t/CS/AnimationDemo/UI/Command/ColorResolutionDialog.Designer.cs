namespace AnimationDemo
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
         this._btnCancel = new System.Windows.Forms.Button();
         this._btnOk = new System.Windows.Forms.Button();
         this._grbOptions = new System.Windows.Forms.GroupBox();
         this._cbDither = new System.Windows.Forms.ComboBox();
         this._cbPalette = new System.Windows.Forms.ComboBox();
         this._cbOrder = new System.Windows.Forms.ComboBox();
         this._cbBitsPerPixel = new System.Windows.Forms.ComboBox();
         this._lblDither = new System.Windows.Forms.Label();
         this._lblPalette = new System.Windows.Forms.Label();
         this._lblOrder = new System.Windows.Forms.Label();
         this._lblBitsPerPixel = new System.Windows.Forms.Label();
         this._grbOptions.SuspendLayout();
         this.SuspendLayout();
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnCancel.Location = new System.Drawing.Point(310, 49);
         this._btnCancel.Margin = new System.Windows.Forms.Padding(2);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(68, 22);
         this._btnCancel.TabIndex = 2;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnOk.Location = new System.Drawing.Point(310, 17);
         this._btnOk.Margin = new System.Windows.Forms.Padding(2);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(68, 22);
         this._btnOk.TabIndex = 1;
         this._btnOk.Text = "OK";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _grbOptions
         // 
         this._grbOptions.Controls.Add(this._cbDither);
         this._grbOptions.Controls.Add(this._cbPalette);
         this._grbOptions.Controls.Add(this._cbOrder);
         this._grbOptions.Controls.Add(this._cbBitsPerPixel);
         this._grbOptions.Controls.Add(this._lblDither);
         this._grbOptions.Controls.Add(this._lblPalette);
         this._grbOptions.Controls.Add(this._lblOrder);
         this._grbOptions.Controls.Add(this._lblBitsPerPixel);
         this._grbOptions.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._grbOptions.Location = new System.Drawing.Point(8, 11);
         this._grbOptions.Margin = new System.Windows.Forms.Padding(2);
         this._grbOptions.Name = "_grbOptions";
         this._grbOptions.Padding = new System.Windows.Forms.Padding(2);
         this._grbOptions.Size = new System.Drawing.Size(288, 150);
         this._grbOptions.TabIndex = 0;
         this._grbOptions.TabStop = false;
         // 
         // _cbDither
         // 
         this._cbDither.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbDither.FormattingEnabled = true;
         this._cbDither.Location = new System.Drawing.Point(108, 112);
         this._cbDither.Margin = new System.Windows.Forms.Padding(2);
         this._cbDither.Name = "_cbDither";
         this._cbDither.Size = new System.Drawing.Size(147, 21);
         this._cbDither.TabIndex = 7;
         this._cbDither.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
         // 
         // _cbPalette
         // 
         this._cbPalette.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbPalette.FormattingEnabled = true;
         this._cbPalette.Location = new System.Drawing.Point(108, 83);
         this._cbPalette.Margin = new System.Windows.Forms.Padding(2);
         this._cbPalette.Name = "_cbPalette";
         this._cbPalette.Size = new System.Drawing.Size(147, 21);
         this._cbPalette.TabIndex = 5;
         this._cbPalette.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
         // 
         // _cbOrder
         // 
         this._cbOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbOrder.FormattingEnabled = true;
         this._cbOrder.Location = new System.Drawing.Point(108, 53);
         this._cbOrder.Margin = new System.Windows.Forms.Padding(2);
         this._cbOrder.Name = "_cbOrder";
         this._cbOrder.Size = new System.Drawing.Size(147, 21);
         this._cbOrder.TabIndex = 3;
         this._cbOrder.SelectedIndexChanged += new System.EventHandler(this.SelectedIndexChanged);
         // 
         // _cbBitsPerPixel
         // 
         this._cbBitsPerPixel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbBitsPerPixel.FormattingEnabled = true;
         this._cbBitsPerPixel.Location = new System.Drawing.Point(108, 23);
         this._cbBitsPerPixel.Margin = new System.Windows.Forms.Padding(2);
         this._cbBitsPerPixel.Name = "_cbBitsPerPixel";
         this._cbBitsPerPixel.Size = new System.Drawing.Size(147, 21);
         this._cbBitsPerPixel.TabIndex = 1;
         this._cbBitsPerPixel.SelectedIndexChanged += new System.EventHandler(this._cbBitsPerPixel_SelectedIndexChanged);
         // 
         // _lblDither
         // 
         this._lblDither.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblDither.Location = new System.Drawing.Point(14, 112);
         this._lblDither.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this._lblDither.Name = "_lblDither";
         this._lblDither.Size = new System.Drawing.Size(86, 22);
         this._lblDither.TabIndex = 6;
         this._lblDither.Text = "Dither";
         this._lblDither.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _lblPalette
         // 
         this._lblPalette.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblPalette.Location = new System.Drawing.Point(14, 83);
         this._lblPalette.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this._lblPalette.Name = "_lblPalette";
         this._lblPalette.Size = new System.Drawing.Size(86, 22);
         this._lblPalette.TabIndex = 4;
         this._lblPalette.Text = "Palette";
         this._lblPalette.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _lblOrder
         // 
         this._lblOrder.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblOrder.Location = new System.Drawing.Point(14, 53);
         this._lblOrder.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this._lblOrder.Name = "_lblOrder";
         this._lblOrder.Size = new System.Drawing.Size(86, 22);
         this._lblOrder.TabIndex = 2;
         this._lblOrder.Text = "Order:";
         this._lblOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _lblBitsPerPixel
         // 
         this._lblBitsPerPixel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblBitsPerPixel.Location = new System.Drawing.Point(14, 23);
         this._lblBitsPerPixel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
         this._lblBitsPerPixel.Name = "_lblBitsPerPixel";
         this._lblBitsPerPixel.Size = new System.Drawing.Size(86, 22);
         this._lblBitsPerPixel.TabIndex = 0;
         this._lblBitsPerPixel.Text = "Bits Per Pixel:";
         this._lblBitsPerPixel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // ColorResolutionDialog
         // 
         this.AcceptButton = this._btnOk;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnCancel;
         this.ClientSize = new System.Drawing.Size(385, 165);
         this.Controls.Add(this._grbOptions);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Margin = new System.Windows.Forms.Padding(2);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "ColorResolutionDialog";
         this.ShowIcon = false;
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "Color Resolution";
         this.Load += new System.EventHandler(this.ColorResolutionDialog_Load);
         this._grbOptions.ResumeLayout(false);
         this.ResumeLayout(false);

      }
      #endregion

      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.GroupBox _grbOptions;
      private System.Windows.Forms.Label _lblBitsPerPixel;
      private System.Windows.Forms.ComboBox _cbDither;
      private System.Windows.Forms.ComboBox _cbPalette;
      private System.Windows.Forms.ComboBox _cbOrder;
      private System.Windows.Forms.ComboBox _cbBitsPerPixel;
      private System.Windows.Forms.Label _lblDither;
      private System.Windows.Forms.Label _lblPalette;
      private System.Windows.Forms.Label _lblOrder;
   }
}