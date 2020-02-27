namespace MainDemo
{
   partial class PaletteDialog
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PaletteDialog));
         this._lblPaletteInfo = new System.Windows.Forms.Label();
         this._lblCurrentColor = new System.Windows.Forms.Label();
         this._btnClose = new System.Windows.Forms.Button();
         this._pnlPalette = new System.Windows.Forms.Panel();
         this.SuspendLayout();
         // 
         // _lblPaletteInfo
         // 
         this._lblPaletteInfo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._lblPaletteInfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblPaletteInfo, "_lblPaletteInfo");
         this._lblPaletteInfo.Name = "_lblPaletteInfo";
         // 
         // _lblCurrentColor
         // 
         this._lblCurrentColor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._lblCurrentColor.FlatStyle = System.Windows.Forms.FlatStyle.System;
         resources.ApplyResources(this._lblCurrentColor, "_lblCurrentColor");
         this._lblCurrentColor.Name = "_lblCurrentColor";
         // 
         // _btnClose
         // 
         this._btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         resources.ApplyResources(this._btnClose, "_btnClose");
         this._btnClose.Name = "_btnClose";
         this._btnClose.UseVisualStyleBackColor = true;
         // 
         // _pnlPalette
         // 
         this._pnlPalette.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         resources.ApplyResources(this._pnlPalette, "_pnlPalette");
         this._pnlPalette.Name = "_pnlPalette";
         this._pnlPalette.Paint += new System.Windows.Forms.PaintEventHandler(this._pnlPalette_Paint);
         this._pnlPalette.MouseMove += new System.Windows.Forms.MouseEventHandler(this._pnlPalette_MouseMove);
         // 
         // PaletteDialog
         // 
         this.AcceptButton = this._btnClose;
         resources.ApplyResources(this, "$this");
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this._btnClose;
         this.Controls.Add(this._pnlPalette);
         this.Controls.Add(this._btnClose);
         this.Controls.Add(this._lblCurrentColor);
         this.Controls.Add(this._lblPaletteInfo);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "PaletteDialog";
         this.ShowInTaskbar = false;
         this.Load += new System.EventHandler(this.PaletteDialog_Load);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Label _lblPaletteInfo;
      private System.Windows.Forms.Label _lblCurrentColor;
      private System.Windows.Forms.Button _btnClose;
      private System.Windows.Forms.Panel _pnlPalette;
   }
}