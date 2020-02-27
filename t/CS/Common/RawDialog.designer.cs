namespace Leadtools.Demos
{
   partial class RawDialog
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
         this._gbMain = new System.Windows.Forms.GroupBox();
         this._cmbPalette = new System.Windows.Forms.ComboBox();
         this._cmbColorOrder = new System.Windows.Forms.ComboBox();
         this._cmbViewPerspective = new System.Windows.Forms.ComboBox();
         this._cbBitsPerPixel = new System.Windows.Forms.ComboBox();
         this._cmbFormat = new System.Windows.Forms.ComboBox();
         this._tbOffst = new System.Windows.Forms.TextBox();
         this._tbVertical = new System.Windows.Forms.TextBox();
         this._tbHorizontal = new System.Windows.Forms.TextBox();
         this._tbHeight = new System.Windows.Forms.TextBox();
         this._tbWidth = new System.Windows.Forms.TextBox();
         this._cbWhiteOnBlack = new System.Windows.Forms.CheckBox();
         this._cbPadLine4Bytes = new System.Windows.Forms.CheckBox();
         this._cbLSBFirst = new System.Windows.Forms.CheckBox();
         this._lblVertical = new System.Windows.Forms.Label();
         this._lblPalette = new System.Windows.Forms.Label();
         this._lblColorOrder = new System.Windows.Forms.Label();
         this._lblBitsPerPixel = new System.Windows.Forms.Label();
         this._lblHeight = new System.Windows.Forms.Label();
         this._lblViewPerspective = new System.Windows.Forms.Label();
         this._lblHorizontal = new System.Windows.Forms.Label();
         this._lblOffset = new System.Windows.Forms.Label();
         this._lblWidth = new System.Windows.Forms.Label();
         this._lblFormat = new System.Windows.Forms.Label();
         this._gbMain.SuspendLayout();
         this.SuspendLayout();
         // 
         // _btnCancel
         // 
         this._btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnCancel.Location = new System.Drawing.Point(432, 55);
         this._btnCancel.Name = "_btnCancel";
         this._btnCancel.Size = new System.Drawing.Size(90, 27);
         this._btnCancel.TabIndex = 2;
         this._btnCancel.Text = "Cancel";
         this._btnCancel.UseVisualStyleBackColor = true;
         // 
         // _btnOk
         // 
         this._btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
         this._btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._btnOk.Location = new System.Drawing.Point(432, 18);
         this._btnOk.Name = "_btnOk";
         this._btnOk.Size = new System.Drawing.Size(90, 27);
         this._btnOk.TabIndex = 1;
         this._btnOk.Text = "OK";
         this._btnOk.UseVisualStyleBackColor = true;
         this._btnOk.Click += new System.EventHandler(this._btnOk_Click);
         // 
         // _gbMain
         // 
         this._gbMain.Controls.Add(this._cmbPalette);
         this._gbMain.Controls.Add(this._cmbColorOrder);
         this._gbMain.Controls.Add(this._cmbViewPerspective);
         this._gbMain.Controls.Add(this._cbBitsPerPixel);
         this._gbMain.Controls.Add(this._cmbFormat);
         this._gbMain.Controls.Add(this._tbOffst);
         this._gbMain.Controls.Add(this._tbVertical);
         this._gbMain.Controls.Add(this._tbHorizontal);
         this._gbMain.Controls.Add(this._tbHeight);
         this._gbMain.Controls.Add(this._tbWidth);
         this._gbMain.Controls.Add(this._cbWhiteOnBlack);
         this._gbMain.Controls.Add(this._cbPadLine4Bytes);
         this._gbMain.Controls.Add(this._cbLSBFirst);
         this._gbMain.Controls.Add(this._lblVertical);
         this._gbMain.Controls.Add(this._lblPalette);
         this._gbMain.Controls.Add(this._lblColorOrder);
         this._gbMain.Controls.Add(this._lblBitsPerPixel);
         this._gbMain.Controls.Add(this._lblHeight);
         this._gbMain.Controls.Add(this._lblViewPerspective);
         this._gbMain.Controls.Add(this._lblHorizontal);
         this._gbMain.Controls.Add(this._lblOffset);
         this._gbMain.Controls.Add(this._lblWidth);
         this._gbMain.Controls.Add(this._lblFormat);
         this._gbMain.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._gbMain.Location = new System.Drawing.Point(10, 0);
         this._gbMain.Name = "_gbMain";
         this._gbMain.Size = new System.Drawing.Size(403, 415);
         this._gbMain.TabIndex = 0;
         this._gbMain.TabStop = false;
         // 
         // _cmbPalette
         // 
         this._cmbPalette.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbPalette.FormattingEnabled = true;
         this._cmbPalette.Location = new System.Drawing.Point(173, 267);
         this._cmbPalette.Name = "_cmbPalette";
         this._cmbPalette.Size = new System.Drawing.Size(173, 24);
         this._cmbPalette.TabIndex = 19;
         // 
         // _cmbColorOrder
         // 
         this._cmbColorOrder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbColorOrder.FormattingEnabled = true;
         this._cmbColorOrder.Location = new System.Drawing.Point(173, 232);
         this._cmbColorOrder.Name = "_cmbColorOrder";
         this._cmbColorOrder.Size = new System.Drawing.Size(173, 24);
         this._cmbColorOrder.TabIndex = 17;
         // 
         // _cmbViewPerspective
         // 
         this._cmbViewPerspective.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbViewPerspective.FormattingEnabled = true;
         this._cmbViewPerspective.Location = new System.Drawing.Point(173, 197);
         this._cmbViewPerspective.Name = "_cmbViewPerspective";
         this._cmbViewPerspective.Size = new System.Drawing.Size(173, 24);
         this._cmbViewPerspective.TabIndex = 15;
         // 
         // _cbBitsPerPixel
         // 
         this._cbBitsPerPixel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cbBitsPerPixel.FormattingEnabled = true;
         this._cbBitsPerPixel.Location = new System.Drawing.Point(173, 163);
         this._cbBitsPerPixel.Name = "_cbBitsPerPixel";
         this._cbBitsPerPixel.Size = new System.Drawing.Size(173, 24);
         this._cbBitsPerPixel.TabIndex = 13;
         this._cbBitsPerPixel.SelectedIndexChanged += new System.EventHandler(this._cbBitsPerPixel_SelectedIndexChanged);
         // 
         // _cmbFormat
         // 
         this._cmbFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this._cmbFormat.FormattingEnabled = true;
         this._cmbFormat.Location = new System.Drawing.Point(173, 28);
         this._cmbFormat.Name = "_cmbFormat";
         this._cmbFormat.Size = new System.Drawing.Size(173, 24);
         this._cmbFormat.TabIndex = 1;
         this._cmbFormat.SelectedIndexChanged += new System.EventHandler(this._cmbFormat_SelectedIndexChanged);
         // 
         // _tbOffst
         // 
         this._tbOffst.Location = new System.Drawing.Point(173, 129);
         this._tbOffst.Name = "_tbOffst";
         this._tbOffst.Size = new System.Drawing.Size(173, 22);
         this._tbOffst.TabIndex = 11;
         // 
         // _tbVertical
         // 
         this._tbVertical.Location = new System.Drawing.Point(269, 96);
         this._tbVertical.Name = "_tbVertical";
         this._tbVertical.Size = new System.Drawing.Size(77, 22);
         this._tbVertical.TabIndex = 9;
         // 
         // _tbHorizontal
         // 
         this._tbHorizontal.Location = new System.Drawing.Point(269, 62);
         this._tbHorizontal.Name = "_tbHorizontal";
         this._tbHorizontal.Size = new System.Drawing.Size(77, 22);
         this._tbHorizontal.TabIndex = 5;
         // 
         // _tbHeight
         // 
         this._tbHeight.Location = new System.Drawing.Point(96, 96);
         this._tbHeight.Name = "_tbHeight";
         this._tbHeight.Size = new System.Drawing.Size(77, 22);
         this._tbHeight.TabIndex = 7;
         // 
         // _tbWidth
         // 
         this._tbWidth.Location = new System.Drawing.Point(96, 62);
         this._tbWidth.Name = "_tbWidth";
         this._tbWidth.Size = new System.Drawing.Size(77, 22);
         this._tbWidth.TabIndex = 3;
         // 
         // _cbWhiteOnBlack
         // 
         this._cbWhiteOnBlack.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._cbWhiteOnBlack.Location = new System.Drawing.Point(19, 377);
         this._cbWhiteOnBlack.Name = "_cbWhiteOnBlack";
         this._cbWhiteOnBlack.Size = new System.Drawing.Size(154, 28);
         this._cbWhiteOnBlack.TabIndex = 22;
         this._cbWhiteOnBlack.Text = "White on Black";
         this._cbWhiteOnBlack.UseVisualStyleBackColor = true;
         // 
         // _cbPadLine4Bytes
         // 
         this._cbPadLine4Bytes.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._cbPadLine4Bytes.Location = new System.Drawing.Point(19, 339);
         this._cbPadLine4Bytes.Name = "_cbPadLine4Bytes";
         this._cbPadLine4Bytes.Size = new System.Drawing.Size(154, 28);
         this._cbPadLine4Bytes.TabIndex = 21;
         this._cbPadLine4Bytes.Text = "Pad Line 4 Bytes";
         this._cbPadLine4Bytes.UseVisualStyleBackColor = true;
         // 
         // _cbLSBFirst
         // 
         this._cbLSBFirst.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._cbLSBFirst.Location = new System.Drawing.Point(19, 301);
         this._cbLSBFirst.Name = "_cbLSBFirst";
         this._cbLSBFirst.Size = new System.Drawing.Size(154, 28);
         this._cbLSBFirst.TabIndex = 20;
         this._cbLSBFirst.Text = "Fill Order - LSB First";
         this._cbLSBFirst.UseVisualStyleBackColor = true;
         // 
         // _lblVertical
         // 
         this._lblVertical.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblVertical.Location = new System.Drawing.Point(192, 98);
         this._lblVertical.Name = "_lblVertical";
         this._lblVertical.Size = new System.Drawing.Size(67, 19);
         this._lblVertical.TabIndex = 8;
         this._lblVertical.Text = "Y Res";
         this._lblVertical.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _lblPalette
         // 
         this._lblPalette.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblPalette.Location = new System.Drawing.Point(19, 269);
         this._lblPalette.Name = "_lblPalette";
         this._lblPalette.Size = new System.Drawing.Size(115, 18);
         this._lblPalette.TabIndex = 18;
         this._lblPalette.Text = "Palette";
         this._lblPalette.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _lblColorOrder
         // 
         this._lblColorOrder.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblColorOrder.Location = new System.Drawing.Point(19, 234);
         this._lblColorOrder.Name = "_lblColorOrder";
         this._lblColorOrder.Size = new System.Drawing.Size(115, 19);
         this._lblColorOrder.TabIndex = 16;
         this._lblColorOrder.Text = "Color Order";
         this._lblColorOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _lblBitsPerPixel
         // 
         this._lblBitsPerPixel.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblBitsPerPixel.Location = new System.Drawing.Point(19, 165);
         this._lblBitsPerPixel.Name = "_lblBitsPerPixel";
         this._lblBitsPerPixel.Size = new System.Drawing.Size(115, 18);
         this._lblBitsPerPixel.TabIndex = 12;
         this._lblBitsPerPixel.Text = "Bits Per Pixel";
         this._lblBitsPerPixel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _lblHeight
         // 
         this._lblHeight.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblHeight.Location = new System.Drawing.Point(19, 98);
         this._lblHeight.Name = "_lblHeight";
         this._lblHeight.Size = new System.Drawing.Size(58, 19);
         this._lblHeight.TabIndex = 6;
         this._lblHeight.Text = "Height";
         this._lblHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _lblViewPerspective
         // 
         this._lblViewPerspective.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblViewPerspective.Location = new System.Drawing.Point(19, 200);
         this._lblViewPerspective.Name = "_lblViewPerspective";
         this._lblViewPerspective.Size = new System.Drawing.Size(115, 18);
         this._lblViewPerspective.TabIndex = 14;
         this._lblViewPerspective.Text = "View Perspective";
         this._lblViewPerspective.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _lblHorizontal
         // 
         this._lblHorizontal.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblHorizontal.Location = new System.Drawing.Point(192, 65);
         this._lblHorizontal.Name = "_lblHorizontal";
         this._lblHorizontal.Size = new System.Drawing.Size(77, 18);
         this._lblHorizontal.TabIndex = 4;
         this._lblHorizontal.Text = "X Res";
         this._lblHorizontal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _lblOffset
         // 
         this._lblOffset.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblOffset.Location = new System.Drawing.Point(19, 132);
         this._lblOffset.Name = "_lblOffset";
         this._lblOffset.Size = new System.Drawing.Size(115, 18);
         this._lblOffset.TabIndex = 10;
         this._lblOffset.Text = "Offset";
         this._lblOffset.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _lblWidth
         // 
         this._lblWidth.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblWidth.Location = new System.Drawing.Point(19, 65);
         this._lblWidth.Name = "_lblWidth";
         this._lblWidth.Size = new System.Drawing.Size(48, 18);
         this._lblWidth.TabIndex = 2;
         this._lblWidth.Text = "Width";
         this._lblWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // _lblFormat
         // 
         this._lblFormat.FlatStyle = System.Windows.Forms.FlatStyle.System;
         this._lblFormat.Location = new System.Drawing.Point(19, 30);
         this._lblFormat.Name = "_lblFormat";
         this._lblFormat.Size = new System.Drawing.Size(120, 18);
         this._lblFormat.TabIndex = 0;
         this._lblFormat.Text = "Format";
         this._lblFormat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
         // 
         // RawDialog
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(534, 428);
         this.Controls.Add(this._gbMain);
         this.Controls.Add(this._btnCancel);
         this.Controls.Add(this._btnOk);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "RawDialog";
         this.ShowInTaskbar = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
         this.Text = "RawDialog";
         this.Load += new System.EventHandler(this.RawDialog_Load);
         this._gbMain.ResumeLayout(false);
         this._gbMain.PerformLayout();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button _btnCancel;
      private System.Windows.Forms.Button _btnOk;
      private System.Windows.Forms.GroupBox _gbMain;
      private System.Windows.Forms.Label _lblVertical;
      private System.Windows.Forms.Label _lblColorOrder;
      private System.Windows.Forms.Label _lblBitsPerPixel;
      private System.Windows.Forms.Label _lblHeight;
      private System.Windows.Forms.Label _lblViewPerspective;
      private System.Windows.Forms.Label _lblHorizontal;
      private System.Windows.Forms.Label _lblOffset;
      private System.Windows.Forms.Label _lblWidth;
      private System.Windows.Forms.Label _lblFormat;
      private System.Windows.Forms.Label _lblPalette;
      private System.Windows.Forms.CheckBox _cbLSBFirst;
      private System.Windows.Forms.CheckBox _cbWhiteOnBlack;
      private System.Windows.Forms.CheckBox _cbPadLine4Bytes;
      private System.Windows.Forms.TextBox _tbOffst;
      private System.Windows.Forms.TextBox _tbVertical;
      private System.Windows.Forms.TextBox _tbHorizontal;
      private System.Windows.Forms.TextBox _tbHeight;
      private System.Windows.Forms.TextBox _tbWidth;
      private System.Windows.Forms.ComboBox _cmbPalette;
      private System.Windows.Forms.ComboBox _cmbColorOrder;
      private System.Windows.Forms.ComboBox _cmbViewPerspective;
      private System.Windows.Forms.ComboBox _cbBitsPerPixel;
      private System.Windows.Forms.ComboBox _cmbFormat;
   }
}