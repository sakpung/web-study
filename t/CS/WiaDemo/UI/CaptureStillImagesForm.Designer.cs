namespace WiaDemo
{
   partial class CaptureStillImagesForm
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CaptureStillImagesForm));
         this._btnTakePicture = new System.Windows.Forms.Button();
         this._btnLoadPictures = new System.Windows.Forms.Button();
         this._btnClose = new System.Windows.Forms.Button();
         this.label1 = new System.Windows.Forms.Label();
         this._pnlBrowser = new System.Windows.Forms.Panel();
         this._pnlVideoPreview = new System.Windows.Forms.Panel();
         this.SuspendLayout();
         // 
         // _btnTakePicture
         // 
         resources.ApplyResources(this._btnTakePicture, "_btnTakePicture");
         this._btnTakePicture.Name = "_btnTakePicture";
         this._btnTakePicture.UseVisualStyleBackColor = true;
         this._btnTakePicture.Click += new System.EventHandler(this._btnTakePicture_Click);
         // 
         // _btnLoadPictures
         // 
         resources.ApplyResources(this._btnLoadPictures, "_btnLoadPictures");
         this._btnLoadPictures.Name = "_btnLoadPictures";
         this._btnLoadPictures.UseVisualStyleBackColor = true;
         this._btnLoadPictures.Click += new System.EventHandler(this._btnLoadPictures_Click);
         // 
         // _btnClose
         // 
         resources.ApplyResources(this._btnClose, "_btnClose");
         this._btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this._btnClose.Name = "_btnClose";
         this._btnClose.UseVisualStyleBackColor = true;
         // 
         // label1
         // 
         resources.ApplyResources(this.label1, "label1");
         this.label1.Name = "label1";
         // 
         // _pnlBrowser
         // 
         resources.ApplyResources(this._pnlBrowser, "_pnlBrowser");
         this._pnlBrowser.BackColor = System.Drawing.Color.Bisque;
         this._pnlBrowser.Name = "_pnlBrowser";
         // 
         // _pnlVideoPreview
         // 
         resources.ApplyResources(this._pnlVideoPreview, "_pnlVideoPreview");
         this._pnlVideoPreview.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
         this._pnlVideoPreview.Name = "_pnlVideoPreview";
         this._pnlVideoPreview.SizeChanged += new System.EventHandler(this._pnlVideoPreview_SizeChanged);
         // 
         // CaptureStillImagesForm
         // 
         this.AcceptButton = this._btnTakePicture;
         this.CancelButton = this._btnClose;
         resources.ApplyResources(this, "$this");
         this.Controls.Add(this._btnTakePicture);
         this.Controls.Add(this._btnLoadPictures);
         this.Controls.Add(this._btnClose);
         this.Controls.Add(this.label1);
         this.Controls.Add(this._pnlBrowser);
         this.Controls.Add(this._pnlVideoPreview);
         this.MaximizeBox = false;
         this.MinimizeBox = false;
         this.Name = "CaptureStillImagesForm";
         this.ShowInTaskbar = false;
         this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
         this.Load += new System.EventHandler(this.CaptureStillImagesForm_Load);
         this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CaptureStillImagesForm_FormClosed);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button _btnTakePicture;
      private System.Windows.Forms.Button _btnLoadPictures;
      private System.Windows.Forms.Button _btnClose;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.Panel _pnlBrowser;
      private System.Windows.Forms.Panel _pnlVideoPreview;
   }
}